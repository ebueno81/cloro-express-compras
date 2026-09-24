
Public Class FrmMnArticulos
   

    Private Sub FrmMnInsumos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F5 Then
            On Error Resume Next
            c_Neg_MnLineas.get_Linea_Cbo(" And c_anula_reg=0 order by c_Desc_linea", CboBusLinea)
            c_Neg_MnLineas.get_Linea_Cbo(" and c_anula_reg=0 order by c_Desc_linea", CboLinea)
            MsgBox("Se actualizaron las lineas satisfactoriamente...", vbExclamation, Compañia)
        End If
    End Sub
    'avanzamos al presionar la tecla..
    Private Sub FrmMnInsumos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmMnInsumos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(10, 10)
        On Error Resume Next
        c_Neg_MnLineas.get_Linea_Cbo(" And c_anula_reg=0 order by c_Desc_linea", CboBusLinea)
        c_Neg_MnLineas.get_Linea_Cbo(" and c_anula_reg=0 order by c_Desc_linea", CboLinea)
        c_Neg_MnFamilias.get_Familia_Cbo(" and c_anula_reg=0 order by c_Desc_familia", CboBusFamilia)
        c_Neg_MnUniMed.Get_UniMed_Cbo(" And c_anula_Reg=0 order by c_desc_unimed", CboUniMed)
        c_Neg_MnMonedas.Get_Moneda_Cbo(" and c_anula_Reg=0 order by c_codi_mon", CboMon)
        ' c_Neg_MnPresenta.get_Presenta_Cbo(" and c_anula_reg=0 order by c_desc_presenta", CboPresenta)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    'Buscamos por linea...
    Private Sub CboBusLinea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboBusLinea.KeyDown
        If e.KeyCode = Keys.Enter Then Call CboBusLinea_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CboBusLinea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboBusLinea.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    'Buscamos por linea de articulos...
    Private Sub CboBusLinea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboBusLinea.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboBusLinea, TxtBus_CodLinea)
    End Sub
    '76018
    Private Sub CboBusFamilia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboBusFamilia.KeyDown
        If e.KeyCode = Keys.Enter Then Call CboBusLinea_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CboBusFamilia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboBusFamilia.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    'Buscamos por Codigo de Familia
    Private Sub CboBusFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboBusFamilia.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboBusFamilia, TxtBus_CodFamilia)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_MnArticulos.get_Articulo_Datos(Cadena, "DGV")
            Call Grid_Registro_Anulado(Dgv01)
            .Columns("Codigo").Width = 60
            .Columns("Descripcion").Width = 200
            .Columns("Linea").Width = 160
            .Columns("Familia").Width = 160
            .Columns("Stock Min.").Width = 85
            .Columns("Unid.").Width = 45
            'Visible
            .Columns("c_anula_Reg").Visible = False
            'Colorear
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue
            'Alineacion...
            .Columns("Unid.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Stock Min.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    'Mostramos registros...
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim Familia As String = "" : Dim Linea As String = ""
        If Len(TxtBus_CodFamilia.Text) > 0 Then Familia = " and A.c_codi_familia='" & TxtBus_CodFamilia.Text & "' "
        'Validamos busqueda por Linea
        If Len(TxtBus_CodLinea.Text) > 0 Then Linea = " and A.c_codi_linea='" & TxtBus_CodLinea.Text & "' "
        Call Cargar_Grid(Linea & Familia & " order by A.c_Desc_articulo")
    End Sub
    'Buscamos por codigo de articulo...
    Private Sub TxtBus_Codigo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Codigo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_Codigo.Text) > 0 Then
                Call Cargar_Grid(" and A.c_codi_Articulo='" & TxtBus_Codigo.Text & "' order by A.c_Desc_articulo")
                TxtBus_Codigo.Focus()
            End If
        End If
    End Sub

    Private Sub TxtBus_Codigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Codigo.TextChanged

    End Sub
    'Buscamos por nombre de articulo...
    Private Sub TxtBus_Articulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Articulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtBus_Articulo.Text) > 0 Then
                Call Cargar_Grid(" and A.c_desc_articulo like '%" & TxtBus_Articulo.Text & "%' order by A.c_Desc_articulo")
            End If
        End If
    End Sub
    'Cerramos ventana...
    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
    End Sub
    ' Nuevo Registro '
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : Pan01.Enabled = True : TxtDes.Focus() : CboLinea.Enabled = True
        CboFamilia.Enabled = True : CboSFamilia.Enabled = True
        TxtUniMed.Text = "Kg." : TxtMon.Text = "$." : TxtUnidad.Text = 1
    End Sub
    'Nuevo Registro...
    Public Sub Nuevo_Registro()
        Tbc01.SelectedTab = Tab02 : Call Limpiar_Texto(Pan01)
        CboLinea.Text = "" : CboFamilia.Text = "" : CboSFamilia.Text = ""
        CboUniMed.Text = "" : CboUniMed.Text = "" : BtnGrabar.Enabled = True
        Pan01.Enabled = True : Pan02.Enabled = True : Pan03.Enabled = True
        Pan08.Enabled = True : Pan09.Enabled = True : TxtCod_Linea.Text = "" : TxtCod_Familia.Text = ""
        TxtCod_SFamilia.Text = "" : TxtCod_UniMed.Clear() : CboFamilia.Text = "" : CboSFamilia.Text = ""
        CboLinea.Text = "" : CboUniMed.Text = "" : TxtDes.Enabled = True : TxtObs.Enabled = True : BtnConTg.Enabled = True
        BtnConCd.Enabled = True : BtnConScd.Enabled = True : CboSFamilia.Enabled = True : CboUniMed.Enabled = True
        Pan10.Enabled = True : Pan11.Enabled = False : Dgv02.Rows.Clear() : BtnConProve.Enabled = True : Call Limpiar_Texto(Pan03)
        TxtStock_Min.Enabled = True : TxtPrecio.Enabled = True : TxtUnidad.Enabled = True : ChkOpcNoInventario.Checked = False
        TxtCodArtSunat.Enabled = True : ChkTransforma.Checked = False : ChkOpcIngTransforma.Checked = False
    End Sub
    'Cancelamos registros...
    Private Sub Cancelar_Registro()
        BtnGrabar.Enabled = False : Tbc01.SelectedTab = Tab01 : Call Desactivar(Pan01) : Call Desactivar(Pan02)
        Pan03.Enabled = False
    End Sub
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Call Cancelar_Registro()
    End Sub
    'Consultamos tabla general...
    Private Sub BtnConTg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConTg.Click
        With FrmConTg
            .Show() : .MdiParent = FrmMenu : .Cargar_Grid(" and c_anula_reg=0 order by c_desc_tg")
            .TxtVar.Text = 1
        End With
    End Sub
    'Consultamos Caidas...
    Private Sub BtnConCd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConCd.Click
        With FrmConCd
            .MdiParent = FrmMenu : .Show() : .TxtCod_Tg.Text = TxtCod_Tg.Text
            .Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' order by c_desc_cd")
            .TxtVar.Text = 1 : .Text = "Listado de Registros de : " & TxtTg.Text
        End With
    End Sub
    'Consultamos Sub CAidas...
    Private Sub BtnConScd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConScd.Click
        With FrmConScd
            .Show() : .MdiParent = FrmMenu : .TxtCod_Tg.Text = TxtCod_Tg.Text : .TxtCod_Cd.Text = TxtCod_Cd.Text
            .Cargar_Grid(" and S.c_anula_reg=0 and S.c_codi_tg='" & TxtCod_Tg.Text & "' and S.c_codi_cd='" & TxtCod_Cd.Text & "' order by c_desc_scd")
            .TxtVar.Text = 1 : .Text = "Listado de Registros de : " & TxtTg.Text & " " & TxtCd.Text
        End With
    End Sub
    'mostramos familia segun la linea...
    Private Sub CboCod_Linea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        c_Neg_MnFamilias.get_Familia_Cbo(" and F.c_codi_linea='" & TxtBus_Codigo.Text & "' and F.c_anula_reg=0", CboFamilia)
    End Sub

    Private Sub CboLinea_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboLinea.KeyDown
        If e.KeyCode = Keys.Enter Then Call CboLinea_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CboLinea_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboLinea.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    'Lineas de insumos quimicos...
    Private Sub CboLinea_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboLinea.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboLinea, TxtCod_Linea)
        c_Neg_MnFamilias.get_Familia_Cbo(" And c_codi_linea='" & TxtCod_Linea.Text & "' and c_anula_reg=0 order by c_desc_familia", CboFamilia)
        TxtCod_Familia.Clear() : TxtCod_SFamilia.Clear()
    End Sub

    Private Sub CboFamilia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboFamilia.KeyDown
        If e.KeyCode = Keys.Enter Then Call CboFamilia_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CboFamilia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboFamilia.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    'Familia de insumos quimicos...
    Private Sub CboFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboFamilia.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboFamilia, TxtCod_Familia)
        c_Neg_MnSFamilias.get_sFamilia_Cbo(" and S.c_codi_linea='" & TxtCod_Linea.Text & "' and S.c_codi_familia='" & TxtCod_Familia.Text & "' and S.c_anula_reg=0", CboSFamilia)
        TxtCod_SFamilia.Clear()
    End Sub

    Private Sub CboSFamilia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboSFamilia.KeyDown
        If e.KeyCode = Keys.Enter Then Call CboSFamilia_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CboSFamilia_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboSFamilia.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    'Sub Familia de insumos quimicos....
    Private Sub CboSFamilia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSFamilia.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboSFamilia, TxtCod_SFamilia)
    End Sub

    Private Sub CboUniMed_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboUniMed.KeyDown
        If e.KeyCode = Keys.Enter Then Call CboUniMed_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CboUniMed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboUniMed.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboUniMed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboUniMed.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboUniMed, TxtCod_UniMed)
    End Sub
    'Agregamos nuevo precios...
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Call Nuevo_Ingreso() : CboMon.SelectedIndex = 1
    End Sub
    'Nuevo Ingreso de precios...
    Private Sub Nuevo_Ingreso()
        Call Limpiar_Texto(Pan02)
        With Dgv02
            .Location = New Point(12, 25)
            .Size = New Size(529, 114)
        End With
        CboMon.Enabled = True : TxtPrecio_Compra.Enabled = True : TxtMotivo.Enabled = True
        TxtPrecio_Compra.Focus() : Pan11.Enabled = True : Pan10.Enabled = False
    End Sub
    'Cancela ingreso de precios...
    Private Sub Cancela_Ingreso()
        With Dgv02
            .Location = New Point(12, 2)
            .Size = New Size(529, 137)
        End With
        CboMon.Enabled = False : TxtPrecio_Compra.Enabled = False : TxtMotivo.Enabled = False : Dgv02.Enabled = True
        Pan11.Enabled = False : Pan10.Enabled = True
    End Sub
    'Cancelamos ingreso
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call Cancela_Ingreso()
    End Sub
    'Cancelamos ingreso
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("Anula").Value) = 0 Then
                        Call Nuevo_Ingreso() : Dgv02.Enabled = False
                        TxtItem.Text = .Rows(Fila).Cells("Item").Value
                        TxtPrecio_Compra.Text = .Rows(Fila).Cells("Precio").Value
                        TxtMotivo.Text = .Rows(Fila).Cells("Motivo").Value
                        DtpFec_Emi.Text = .Rows(Fila).Cells("Fecha").Value
                        'Validamos el tipo de moneda...
                        If .Rows(Fila).Cells("Moneda").Value = "S/." Then CboMon.SelectedIndex = 0
                        If .Rows(Fila).Cells("Moneda").Value = "$." Then CboMon.SelectedIndex = 1
                    Else
                        MsgBox("Registro se encuentra anulada, no puede ser editado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    'Consultamos proveedores...
    Private Sub BtnConProve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConProve.Click
        With FrmConProve
            .MdiParent = FrmMenu : .Show() : .TxtVar.Text = 1 : .Cargar_Grid(" and c_anula_Reg=0 order by c_desc_prov")
        End With
    End Sub
    'Aceptamos el ingreso de precios...
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If Len(TxtMotivo.Text) > 0 Then
            If Dgv02.Enabled = True Then
                Dgv02.Rows.Add() : Call Agregar_Precios(Dgv02.RowCount - 1)
            Else
                Call Agregar_Precios(Dgv02.CurrentCellAddress.Y)
            End If
        End If
    End Sub
    'Agregamos precios
    Private Sub Agregar_Precios(ByVal Fila As Integer)
        With Dgv02
            .Rows(Fila).Cells("Item").Value = TxtItem.Text
            .Rows(Fila).Cells("Moneda").Value = CboMon.Text
            .Rows(Fila).Cells("Precio").Value = Format(Val(TxtPrecio_Compra.Text), Forma_1_2)
            .Rows(Fila).Cells("Fecha").Value = DtpFec_Emi.Text
            .Rows(Fila).Cells("Motivo").Value = TxtMotivo.Text
        End With
        Call Cancela_Ingreso() : Call Limpiar_Texto(Pan02)
    End Sub
    'Eliminamos registro...
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("Anula").Value) = 0 Then
                        Dim F As String = MsgBox("¿Desea eliminar el Registro?", vbYesNo + vbCritical, Compañia)
                        If F = vbYes Then
                            If Val(.Rows(Fila).Cells("Item").Value) > 0 Then
                                .Rows(Fila).Cells("Anula").Value = 1
                                .Rows(Fila).DefaultCellStyle.BackColor = Color.Gainsboro
                            Else
                                .Rows.RemoveAt(Fila)
                            End If
                        End If
                    Else
                        MsgBox("Registro se encuentra anulado, no puede ser eliminado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    ' Validamos si grabamos el articulo'
    Private Function ValidarDatos() As Boolean
        If Len(TxtCodArtSunat.Text) = 8 Then
            If Len(TxtDes.Text) > 0 Then ' Validamos si grabamos la tabla general la caida y la subcaida 
                If Len(TxtCod_Tg.Text) > 0 And Len(TxtCod_Cd.Text) > 0 And Len(TxtCod_Scd.Text) > 0 Then
                    If Len(TxtCod_Linea.Text) > 0 And Len(TxtCod_Familia.Text) > 0 And Len(TxtCod_SFamilia.Text) > 0 Then
                        If Val(TxtUnidad.Text) > 0 Then
                            ValidarDatos = True
                        Else
                            MsgBox("1. La unidad debe ser mayor a Cero...", vbCritical, Compañia)
                            ValidarDatos = False
                        End If
                    Else
                        MsgBox("2. Falta ingresar las Caídas...", vbCritical, Compañia)
                        ValidarDatos = False
                    End If
                Else
                    MsgBox("3. Falta ingresar la Líneas o Familias...", vbCritical, Compañia)
                    ValidarDatos = False
                End If
            Else
                MsgBox("4. Falta Ingresar la Descripción del Artículo...", vbCritical, Compañia)
                ValidarDatos = False
            End If
        Else
            MsgBox("5. Falta Ingresar el código de Artículo SUNAT, Recuerde que el codigo de SUNAT debera contar con 8 digitos...", vbCritical, Compañia)
            ValidarDatos = False : TxtCodArtSunat.Focus()
        End If
    End Function
    ' Metodo para validar SubCaidas
    Private Function ValidarCaidas() As Boolean
        With c_Neg_MnSCaidas.get_sCaidas_Datos(" and S.c_anula_reg=0 and S.c_codi_tg='" & TxtCod_Tg.Text & "' and S.c_codi_cd='" & TxtCod_Cd.Text & _
                                               "' and S.c_codi_scd='" & TxtCod_Scd.Text & "' ", "DAT")
            If .Rows.Count > 0 Then
                If .Rows(0)("c_codi_articulo").ToString = "00000000" Or Len(.Rows(0)("c_codi_articulo").ToString) = 0 Then
                    ValidarCaidas = True
                Else ' Validamos si es el mismo código '
                    If TxtCodigo.Text = .Rows(0)("c_codi_articulo").ToString Then
                        ValidarCaidas = True
                    Else
                        ValidarCaidas = False
                        MsgBox("Caída ya fue registrado para el Codigo de articulo: " & .Rows(0)("c_codi_articulo").ToString, vbExclamation, Compañia)
                    End If
                End If
            Else
                ValidarCaidas = True
                'MsgBox("No existe Caída para Enlazar al artículo...", vbCritical, Compañia)
            End If
        End With
    End Function
    'Grabamos registros...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            If ValidarCaidas() = True Then
                Dim F As String = MsgBox("¿Desea grabar el registro?", vbYesNo + vbQuestion, Compañia)
                If F = vbYes Then
                    If ChkActivo.Checked = False Then
                        Call Grabar_Articulo("ADD")
                    Else
                        Call Grabar_Articulo("DEL")
                    End If
                End If
            End If
        End If
    End Sub
    'Grabamos registro...
    Private Sub Grabar_Articulo(ByVal cOpcion As String)
        With c_Ent_MnArticulos
            Dim c_opc_ingtransforma As Integer = 0
            .c_codi_articulo = TxtCodigo.Text
            .c_desc_articulo = TxtDes.Text
            .c_codi_linea = TxtCod_Linea.Text
            .c_codi_familia = TxtCod_Familia.Text
            .c_codi_sfamilia = TxtCod_SFamilia.Text
            .c_codi_artsunat = TxtCodArtSunat.Text
            .c_codi_unimed = TxtCod_UniMed.Text
            .c_valor_unidad = Val(TxtUnidad.Text)
            .c_codi_prov = TxtCod_Prov.Text
            .c_obs = TxtObs.Text 'Validamos tipo de moneda...
            .c_codi_mon = CboMon.SelectedValue
            If Len(.c_codi_mon) = 0 Then .c_codi_mon = "02"
            .c_precio_art = Val(TxtPrecio.Text)
            .c_stock_min = Val(TxtStock_Min.Text)
            .c_codi_tg = TxtCod_Tg.Text
            .c_codi_cd = TxtCod_Cd.Text
            .c_codi_scd = TxtCod_Scd.Text
            Dim Activo, Control As Integer
            If ChkActivo.Checked = True Then
                Activo = 1
            Else
                Activo = 0
            End If
            If ChkControl.Checked = True Then
                Control = 1
            Else
                Control = 0
            End If
            .c_control_art = Control
            ' Validamos si esta afecto al control de inventario '
            Dim c_opc_noinventario As Integer = 0
            If ChkOpcNoInventario.Checked = True Then
                c_opc_noinventario = 1
            End If
            .c_opc_noinventario = c_opc_noinventario
            ' Validamos si esta afecto al control de transformacion '
            Dim c_opc_transforma As Integer = 0
            If ChkTransforma.Checked = True Then
                c_opc_transforma = 1
            End If
            .c_opc_transforma = c_opc_transforma
            If ChkOpcIngTransforma.Checked = True Then c_opc_ingtransforma = 1
            .c_opc_ingtransforma = c_opc_ingtransforma
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            'Validamos si grabamos o modificamos...
            If Len(TxtCodigo.Text) = 0 Then
                TxtCodigo.Text = c_Neg_MnArticulos.set_Articulo_Save(c_Ent_MnArticulos)
            Else
                c_Neg_MnArticulos.set_Articulo_Save(c_Ent_MnArticulos)
            End If
        End With
        Call Grabar_ArtPrecios() : BtnGrabar.Enabled = False : Call BtnMostrar_Click(Nothing, Nothing)
        If FrmMnSCaidas.Visible = True Then
            FrmMnSCaidas.Cargar_Grid()
            Me.Close()
        End If
        MsgBox("Registro se grabo correctamente...", vbInformation, Compañia)
    End Sub
    'Grabamos precios de articulos
    Private Sub Grabar_ArtPrecios()
        With Dgv02
            For I = 0 To .RowCount - 1
                With c_Ent_MnArtPrecio
                    .c_codi_precio = Dgv02.Rows(I).Cells("Item").Value
                    .c_codi_articulo = TxtCodigo.Text
                    If Dgv02.Rows(I).Cells("moneda").Value = "S/" Then .c_codi_mon = "01"
                    If Dgv02.Rows(I).Cells("moneda").Value = "$." Then .c_codi_mon = "02"
                    .c_precio_art = Val(Dgv02.Rows(I).Cells("Precio").Value)
                    .c_fecha_art = FormatDateTime(Dgv02.Rows(I).Cells("Fecha").Value, DateFormat.ShortDate)
                    .c_obs = Dgv02.Rows(I).Cells("Motivo").Value
                    .c_usuario = FrmMenu.lblusuario.Text
                    If Val(Dgv02.Rows(I).Cells("Item").Value) = 0 Then
                        .copcion = "ADD"
                        Dgv02.Rows(I).Cells("Item").Value = c_Neg_MnArticulos.set_ArtPrecio_Save(c_Ent_MnArtPrecio)
                    Else
                        If Val(Dgv02.Rows(I).Cells("Anula").Value) = 1 Then
                            .copcion = "DEL"
                            c_Neg_MnArticulos.set_ArtPrecio_Save(c_Ent_MnArtPrecio)
                        Else 'Eliminamos si registro se encuentra anulado...
                            .copcion = "EDI"
                            c_Neg_MnArticulos.set_ArtPrecio_Save(c_Ent_MnArtPrecio)
                        End If
                    End If
                End With
            Next
        End With
    End Sub
    Public Sub Mostrar_Articulos(ByVal Codigo As String)
        With c_Neg_MnArticulos.get_Articulo_Datos(" and A.c_codi_articulo='" & Codigo & "'", "DAT")
            Call Limpiar_Texto(Pan01) : Call Limpiar_Texto(Pan02)
            If .Rows.Count > 0 Then
                TxtCodigo.Text = .Rows(0)("c_codi_articulo").ToString
                TxtDes.Text = .Rows(0)("c_desc_articulo").ToString
                TxtCod_Tg.Text = .Rows(0)("c_codi_tg").ToString
                TxtCod_Cd.Text = .Rows(0)("c_codi_cd").ToString
                TxtCod_Scd.Text = .Rows(0)("c_codi_scd").ToString
                TxtTg.Text = .Rows(0)("c_desc_tg").ToString
                TxtCd.Text = .Rows(0)("c_desc_cd").ToString
                TxtScd.Text = .Rows(0)("c_desc_scd").ToString
                TxtUsua_Crea.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_Modi.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                CboLinea.Text = .Rows(0)("c_desc_linea").ToString
                CboFamilia.Text = .Rows(0)("c_desc_familia").ToString
                CboSFamilia.Text = .Rows(0)("c_desc_sfamilia").ToString
                TxtCod_Linea.Text = .Rows(0)("c_codi_linea").ToString
                TxtCod_Familia.Text = .Rows(0)("c_codi_familia").ToString
                TxtCod_SFamilia.Text = .Rows(0)("c_codi_Sfamilia").ToString

                TxtCod_UniMed.Text = .Rows(0)("c_codi_unimed").ToString
                TxtCodArtSunat.Text = .Rows(0)("c_codi_artsunat").ToString
                TxtUnidad.Text = Val(.Rows(0)("c_valor_unidad").ToString)
                CboUniMed.Text = .Rows(0)("c_desc_unimed").ToString
                TxtStock_Min.Text = .Rows(0)("c_stock_min").ToString
                TxtUniMed.Text = .Rows(0)("c_desc_unimed").ToString
                TxtMon.Text = .Rows(0)("c_nick_mon").ToString
                TxtPrecio.Text = Format(Val(.Rows(0)("c_precio_art").ToString), Forma_1_6)
                TxtCod_Prov.Text = .Rows(0)("c_codi_prov").ToString
                TxtProveedor.Text = .Rows(0)("c_Desc_prov").ToString
                'Validamos si articulo esta descontinuado...
                If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                    ChkActivo.Checked = False
                Else
                    ChkActivo.Checked = True
                End If 'Validamos si articulo esta controlado...
                If Val(.Rows(0)("c_control_art").ToString) = 0 Then
                    ChkControl.Checked = False
                Else
                    ChkControl.Checked = True
                End If
                ' Validamos si el producto esta activo para inventario
                If Val(.Rows(0)("c_opc_noinventario").ToString) = 0 Then
                    ChkOpcNoInventario.Checked = False
                Else
                    ChkOpcNoInventario.Checked = True
                End If
                ' Validamos si el producto es para transforma
                If Val(.Rows(0)("c_opc_transforma").ToString) = 0 Then
                    ChkTransforma.Checked = False
                Else
                    ChkTransforma.Checked = True
                End If
                ' Validamos si el producto ingreso x transformacion
                If Val(.Rows(0)("c_opc_ingtransforma").ToString) = 1 Then
                    ChkOpcIngTransforma.Checked = True
                Else
                    ChkOpcIngTransforma.Checked = False
                End If
                With c_Neg_MnArticulos.get_Articulo_Datos(" and P.c_codi_Articulo='" & TxtCodigo.Text & "' order by c_codi_precio desc", "PRE")
                    Dgv02.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            Dgv02.Rows.Add()
                            Dgv02.Rows(I).Cells("Item").Value = .Rows(I)("c_codi_precio").ToString
                            Dgv02.Rows(I).Cells("Moneda").Value = .Rows(I)("c_nick_mon").ToString
                            Dgv02.Rows(I).Cells("Precio").Value = .Rows(I)("c_precio_art").ToString
                            Dgv02.Rows(I).Cells("Fecha").Value = FormatDateTime(.Rows(I)("c_fecha_art").ToString, DateFormat.ShortDate)
                            Dgv02.Rows(I).Cells("Motivo").Value = .Rows(I)("c_obs").ToString
                            'Validamos si la fila esta anulada...
                            If Val(.Rows(I)("c_anula_reg").ToString) = 1 Then
                                Dgv02.Rows(I).DefaultCellStyle.BackColor = Color.Gainsboro
                            End If
                            Dgv02.Rows(I).Cells("Anula").Value = .Rows(I)("c_anula_reg").ToString
                        Next
                    End If
                End With
            End If
        End With
    End Sub
    'Editamos Registro...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Call Nuevo_Registro() : CboLinea.Enabled = False : CboFamilia.Enabled = False
                    TxtStock_Min.Enabled = True : TxtPrecio.Enabled = True
                    Call Mostrar_Articulos(.Rows(Fila).Cells("Codigo").Value)
                    Tbc01.SelectedTab = Tab02 : TxtDes.Focus()
                    CboLinea.Enabled = True : CboFamilia.Enabled = True : CboSFamilia.Enabled = True
                End If
            End If
        End With
    End Sub

    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 1 Then
            Call Dgv01_DoubleClick(Nothing, Nothing)
        Else
            BtnGrabar.Enabled = False : Call Cancela_Ingreso()
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registro_Anulado(Dgv01)
    End Sub
    'Mostrar registro de insumos quimicos al dar doble click...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Tbc01.SelectedTab = Tab02 : Call Desactivar(Pan08) : Call Desactivar(Pan09) : Call Desactivar(Pan01)
                    BtnConCd.Enabled = False : BtnConTg.Enabled = False : BtnConScd.Enabled = False
                    Call Mostrar_Articulos(.Rows(Fila).Cells("Codigo").Value)
                    Pan10.Enabled = False : Pan11.Enabled = False
                End If
            End If
        End With
    End Sub
    'Eliminamos Registro...
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_Reg").Value) = 0 Then
                        Dim F As String = MsgBox("¿Confirma la eliminación del Registro?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then
                            TxtCodigo.Text = .Rows(Fila).Cells("Codigo").Value
                            ChkActivo.Checked = True
                            Call Grabar_Articulo("DEL")
                            .Rows(Fila).Cells("c_anula_reg").Value = 1
                            .Rows(Fila).DefaultCellStyle.BackColor = Color.Gainsboro
                        End If
                    Else
                        MsgBox("Registro se encuentra eliminado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    'Inicio
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 1)
    End Sub
    'Atras
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 2)
    End Sub
    'Avanza
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 3)
    End Sub
    'Final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 4)
    End Sub
    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    ' Metodo para Agregar Directamente desde la tabla de Caidas '
    Public Sub Agregar_Articulos()
        Call BtnNuevo_Click(Nothing, Nothing)
    End Sub
End Class