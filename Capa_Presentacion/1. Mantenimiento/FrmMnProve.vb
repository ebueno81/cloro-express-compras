Public Class FrmMnProve
    Dim Focos As Integer = 0 : Dim x As Integer = 0 : Dim Foco As Integer = 0
    Private Sub FrmMnProve_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            If Pan02.Visible = True Then
                Pan02.Visible = False
            Else
                Me.Close()
            End If
        End If
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        'consultamos ruc en la pagina de la sunat
        If e.KeyCode = 112 Then
            Dim proceso As New System.Diagnostics.Process
            With proceso
                .StartInfo.FileName = "http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias"
                .Start()
            End With
        End If
    End Sub

    Private Sub FrmMnProve_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmMnProve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CboBusca.SelectedIndex = 0
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnAnular)
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 ", CboMon)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_mnProve.get_Prove_Datos(Cadena, "DGV")
        With Dgv01
            .Columns("Codigo").Width = 60
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue

            .Columns("Razon Social").Width = 250
            .Columns("Telefono").Width = 125
            .Columns("Celular").Width = 125
            .Columns("Ruc").Width = 80

            .Columns("c_anula_reg").Visible = False
            .Columns("Nombre Comercial").Visible = False
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value.ToString) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
            ' Alineacion '
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ruc").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = "1 / " & .RowCount
        End With
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Tbc01.SelectedTab = Tab01
        BtnGrabar.Enabled = False
        Call Cancelar_Registro()
    End Sub

    Private Sub Cancelar_Registro()
        Call Desactivar(Pan03)
        Call Desactivar(Pan04)
        Call Desactivar(Pan05)
        Call Desactivar(Pan06)
        Call Desactivar(Pan07)
    End Sub
    Private Function ValidarDatos() As Boolean
        If Len(TxtUbigeo.Text) >= 5 Then
            ValidarDatos = True
        Else
            ValidarDatos = False
            MsgBox("1. Es necesario ingresar el codigo de ubigeo", MsgBoxStyle.Critical, Compañia)
        End If
    End Function
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            If Len(TxtRaz.Text) = 0 Then
                MsgBox("Es necesario ingresar la razón social", MsgBoxStyle.Critical)
                TxtRaz.Focus()
            Else
                If Len(TxtRuc.Text) = 0 Then MsgBox("Falta ingresar el número de RUC", MsgBoxStyle.Critical)
                Dim f As String = MsgBox("¿Desea Grabar el registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If f = vbYes Then
                    Call Grabar_Proveedor("ADD")
                    With Dgv02
                        For I = 0 To .RowCount - 1
                            Call Grabar_Detalles("ADD", I)
                        Next
                    End With
                    MsgBox("Se registro se grabo correctamente...", MsgBoxStyle.Exclamation)
                    Call Cancelar_Detalles() : Pan10.Enabled = False
                End If
            End If
        End If
    End Sub
    Private Sub Grabar_Proveedor(ByVal cOpcion As String)
        With c_Ent_MnProve
            Dim TpoProve As String = ""
            Dim Tpo_Compra As Integer = 0 'Variable que nos permitira saber si el proveedor es nacional=1 o 2=Importacion
            If Rdb01.Checked = True Then Tpo_Compra = 1
            If Rdb02.Checked = True Then Tpo_Compra = 2
            'Validamos el tipo de proveedor
            If Rdb03.Checked = True Then TpoProve = "01"
            If Rdb04.Checked = True Then TpoProve = "02"
            If Rdb05.Checked = True Then TpoProve = "03"
            .c_codi_prov = TxtCod_Prov.Text
            .c_desc_prov = TxtRaz.Text
            .c_nom_prov = TxtNom.Text
            .c_codi_ubigeo = TxtUbigeo.Text
            .c_pais_prov = TxtPais.Text
            .c_ciudad_prov = TxtCiu.Text
            .c_dist_prov = TxtDis.Text
            .c_direc_prov = TxtDir.Text
            .c_ruc_prov = TxtRuc.Text
            .c_telf_prov = TxtFono.Text
            .c_cel_prov = TxtCel.Text
            .c_contac_prov = TxtCon.Text
            .c_mail_prov = TxtMail.Text
            .c_web_prov = TxtWeb.Text
            .c_codi_tpoprov = TpoProve
            .c_cta_detraccion = TxtCta_Detraccion.Text
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .c_tpo_compra = Tpo_Compra
            .copcion = cOpcion
            c_Neg_mnProve.set_Prove_Save(c_Ent_MnProve)
            BtnGrabar.Enabled = False
            Call Cargar_Grid(" order by c_desc_prov")
            Call Cancelar_Registro()
        End With
    End Sub
    ' Metodo para grabar los detalles '
    Public Sub Grabar_Detalles(ByVal cOpcion As String, ByVal Fila As Integer)
        With c_Ent_MnProveDet
            .c_nro_correl = Dgv02.Rows(Fila).Cells("Item").Value
            .c_codi_prov = TxtCod_Prov.Text
            .c_codi_tg = Dgv02.Rows(Fila).Cells("Mot").Value
            .c_codi_cd = Dgv02.Rows(Fila).Cells("Cd").Value
            .c_codi_scd = Dgv02.Rows(Fila).Cells("Art").Value
            .c_codi_articulo = Dgv02.Rows(Fila).Cells("Codigo").Value
            .c_codi_mon = Dgv02.Rows(Fila).Cells("c_codi_mon").Value
            .c_prec_prv = Val(Dgv02.Rows(Fila).Cells("Precio").Value)
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_MnProveDet.set_ProveDet_Save(c_Ent_MnProveDet)
        End With
    End Sub
    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 1 Then
            With Dgv01
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    With c_Neg_mnProve.get_Prove_Datos(" and P.c_codi_prov='" & .Rows(Fila).Cells("Codigo").Value & "' ", "DAT")
                        If .Rows.Count > 0 Then
                            TxtCod_Prov.Text = .Rows(0)("c_codi_prov").ToString
                            TxtRuc.Text = .Rows(0)("c_ruc_prov").ToString
                            TxtRaz.Text = .Rows(0)("c_desc_prov").ToString
                            TxtNom.Text = .Rows(0)("c_nom_prov").ToString
                            TxtDir.Text = .Rows(0)("c_direc_prov").ToString
                            TxtPais.Text = .Rows(0)("c_pais_prov").ToString
                            TxtCiu.Text = .Rows(0)("c_ciudad_prov").ToString
                            TxtDis.Text = .Rows(0)("c_dist_prov").ToString
                            TxtDir.Text = .Rows(0)("c_direc_prov").ToString
                            TxtFono.Text = .Rows(0)("c_telf_prov").ToString
                            TxtCel.Text = .Rows(0)("c_cel_prov").ToString
                            TxtCon.Text = .Rows(0)("c_contac_prov").ToString
                            TxtUbigeo.Text = .Rows(0)("c_codi_ubigeo").ToString
                            TxtWeb.Text = .Rows(0)("c_web_prov").ToString
                            TxtMail.Text = .Rows(0)("c_mail_prov").ToString
                            TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                            TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                            TxtFec_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                            TxtFec_Mod.Text = .Rows(0)("c_fecha_modi").ToString
                            TxtCta_Detraccion.Text = .Rows(0)("c_cta_detraccion").ToString
                            TxtObs.Text = .Rows(0)("c_obs").ToString
                            'Tipo de proveedor nacional e importado
                            If Val(.Rows(0)("c_tpo_compra").ToString) = 1 Then Rdb01.Checked = True
                            If Val(.Rows(0)("c_tpo_compra").ToString) = 2 Then Rdb02.Checked = True
                            'Tipo de proveedor 
                            If Val(.Rows(0)("c_codi_tpoprov").ToString) = "01" Then Rdb03.Checked = True
                            If Val(.Rows(0)("c_codi_tpoprov").ToString) = "02" Then Rdb04.Checked = True
                            If Val(.Rows(0)("c_codi_tpoprov").ToString) = "03" Then Rdb05.Checked = True

                            'Llenamos Lista de Compras...
                            Dgv02.Rows.Clear()
                            With c_Neg_MnProveDet.get_ProveDet_Datos(" And D.c_codi_prov='" & TxtCod_Prov.Text & "' And D.c_anula_reg=0 order by c_nro_correl", "DAT")
                                For i = 0 To .Rows.Count - 1
                                    Dgv02.Rows.Add()
                                    Dgv02.Rows(i).Cells("Mot").Value = .Rows(i)("c_codi_tg").ToString
                                    Dgv02.Rows(i).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString
                                    Dgv02.Rows(i).Cells("Art").Value = .Rows(i)("c_codi_scd").ToString
                                    Dgv02.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                                    Dgv02.Rows(i).Cells("Articulo").Value = .Rows(i)("c_desc_articulo").ToString
                                    Dgv02.Rows(i).Cells("Mon").Value = .Rows(i)("c_nick_mon").ToString
                                    Dgv02.Rows(i).Cells("c_codi_mon").Value = .Rows(i)("c_codi_mon").ToString
                                    Dgv02.Rows(i).Cells("Precio").Value = Format(Val(.Rows(i)("c_prec_prv").ToString), Forma_1_4)
                                    Dgv02.Rows(i).Cells("Item").Value = .Rows(i)("c_nro_correl").ToString
                                Next
                            End With

                        End If
                    End With
                    BtnGrabar.Enabled = False
                End If
            End With
        End If
    End Sub
    
    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
    End Sub
    ' Nuevo Registro '
    Private Sub Nuevo_Registro()
        Tbc01.SelectedTab = Tab02
        Call Activar(Pan03) : Call Activar(Pan04) : Call Activar(Pan05) : Call Activar(Pan06) : Call Activar(Pan07)
        Call Limpiar_Texto(Pan03) : Call Limpiar_Texto(Pan04) : Call Limpiar_Texto(Pan05) : Call Limpiar_Texto(Pan06) : Call Limpiar_Texto(Pan07)
        TxtCod_Prov.Enabled = False : TxtUsua_1.Enabled = False : TxtUsua_2.Enabled = False : TxtFec_Crea.Enabled = False : TxtFec_Mod.Enabled = False
    End Sub


    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim Criterio As String = ""
        If UCase(CboBusca.Text) = "RAZON SOCIAL" Then Criterio = " and c_desc_prov like '%" & TxtBus.Text & "%'"
        If UCase(CboBusca.Text) = "NOMBRE COMERCIAL" Then Criterio = " and c_nom_prov like '%" & TxtBus.Text & "%'"
        If UCase(CboBusca.Text) = "R.U.C." Then Criterio = " and c_ruc_prov like '%" & TxtBus.Text & "%'"
        If UCase(CboBusca.Text) = "CONTACTO" Then Criterio = " and c_contac_prov like '%" & TxtBus.Text & "%'"
        Criterio.Replace("'", "''")
        Call Cargar_Grid(Criterio & " AND c_codi_prov>0  order by c_desc_prov")
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' Mostramos Registros '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub

    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        Tbc01.SelectedTab = Tab02 : Call Tbc01_Click(Nothing, Nothing)
    End Sub
    'Inicio
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 1)
    End Sub
    'Final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 4)
    End Sub
    'Atras
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 2)
    End Sub
    'Avanzamos
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 3)
    End Sub

    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    'Imprimir registros...

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Tbc01.SelectedTab = Tab02
        Call Nuevo_Registro() : TxtRuc.Focus() : BtnGrabar.Enabled = True
        TxtPais.Text = "PERU" : TxtCiu.Text = "LIMA" : Rdb01.Checked = True : Pan10.Enabled = True
    End Sub
    ' Anulamos proveedor '
    Private Sub BtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim f As String = MsgBox("¿Confirma la Eliminación del proveedor?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical)
                        If f = vbYes Then
                            TxtCod_Prov.Text = Dgv01.Rows(fila).Cells("codigo").Value
                            Call Grabar_Proveedor("DEL")
                            Call BtnMostrar_Click(Nothing, Nothing)
                            MsgBox("Registro se elimino correctamente...", MsgBoxStyle.Critical)
                        End If
                    Else
                        MsgBox("  Registro se encuentr anulado...  ", MsgBoxStyle.Critical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If .Rows(fila).Cells("c_anula_Reg").Value = 0 Then
                        Call Nuevo_Registro()
                        Call Tbc01_Click(Nothing, Nothing)
                        TxtRuc.Focus() : Pan10.Enabled = True
                        BtnGrabar.Enabled = True
                    Else
                        MsgBox("Registro se encuentra anulado", MsgBoxStyle.Critical)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim Criterio As String = ""
        If UCase(CboBusca.Text) = "RAZON SOCIAL" Then Criterio = " and c_desc_prov like '%" & TxtBus.Text & "%'"
        If UCase(CboBusca.Text) = "NOMBRE COMERCIAL" Then Criterio = " and c_nom_prov like '%" & TxtBus.Text & "%'"
        If UCase(CboBusca.Text) = "R.U.C." Then Criterio = " and c_ruc_prov like '%" & TxtBus.Text & "%'"
        If UCase(CboBusca.Text) = "CONTACTO" Then Criterio = " and c_contac_prov like '%" & TxtBus.Text & "%'"
    End Sub

    Private Sub TxtBus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus.TextChanged
        Call BtnMostrar_Click(Nothing, Nothing)
    End Sub
    ' Enviamos enfoque al botoo grabar '
    Private Sub TxtCta_Detraccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCta_Detraccion.KeyDown
        If e.KeyCode = Keys.Enter Then
            Focos = 1 : BtnGrabar.Focus()
        End If
    End Sub

    Private Sub TxtCta_Detraccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCta_Detraccion.TextChanged

    End Sub
    ' Grabamos '
    Private Sub BtnGrabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGrabar.LostFocus
        If Focos = 1 Then
            Focos = 0 : BtnGrabar.Focus()
        End If
    End Sub
    ' Consultar tabla general o tabla de motivos '
    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        With FrmConTg
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 5
            .Cargar_Grid(" and c_anula_reg=0  order by c_desc_tg")
        End With
    End Sub
    ' Consultamos Caidas '
    Private Sub BtnCon_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon_2.Click
        With FrmConCd
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 5 : .TxtCod_Tg.Text = TxtCod_Mt.Text
            .Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Mt.Text & "' order by c_desc_cd")
        End With
    End Sub
    ' Consulta SubCaidas de Articulo '
    Private Sub BtnCon_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon_3.Click
        With FrmConScd
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 5 : .TxtCod_Tg.Text = TxtCod_Mt.Text : TxtCod_Cd.Text = TxtCod_Cd.Text
            .Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Mt.Text & "' and c_codi_cd='" & TxtCod_Cd.Text & "' order by c_desc_scd")
        End With
    End Sub
    ' Nuevo de Detalles '
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Call Nuevo_Detalles() : BtnCon1.Focus()
    End Sub
    ' Metodo Nuevo detalles '
    Private Sub Nuevo_Detalles()
        With Dgv02
            .Size = New Size(687, 129) : .Location = New Point(3, 94) : .Enabled = False
        End With
        Pan01.Enabled = True
        Call Limpiar_Texto(Pan01) : Pan09.Enabled = True : Pan10.Enabled = False
        BtnCon1.Enabled = True : BtnCon_2.Enabled = True : BtnCon_3.Enabled = True
    End Sub
    ' Metodo Cancelar detalles '
    Private Sub Cancelar_Detalles()
        With Dgv02
            .Size = New Size(687, 202) : .Location = New Point(3, 21) : .Enabled = True
        End With
        Pan09.Enabled = False : Pan10.Enabled = True : Pan01.Enabled = True : Pan02.Visible = False
    End Sub
    ' Editamos Registros Detalles '
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        With Dgv02
            Dim Fila As Integer = .CurrentCellAddress.Y
            If Fila > -1 Then
                Call Nuevo_Detalles()
                BtnCon1.Enabled = False : BtnCon_2.Enabled = False : BtnCon_3.Enabled = False
                With c_Neg_MnProveDet.get_ProveDet_Datos(" And D.c_nro_correl='" & .Rows(Fila).Cells("Item").Value & "'", "DAT")
                    If .Rows.Count > 0 Then
                        TxtCod_Mt.Text = .Rows(0)("c_codi_tg").ToString
                        TxtCod_Cd.Text = .Rows(0)("c_codi_cd").ToString
                        TxtCod_Scd.Text = .Rows(0)("c_codi_scd").ToString
                        TxtMt.Text = .Rows(0)("c_desc_tg").ToString
                        TxtCaida.Text = .Rows(0)("c_desc_cd").ToString
                        TxtScd.Text = .Rows(0)("c_desc_scd").ToString
                        CboMon.SelectedValue = .Rows(0)("c_codi_mon").ToString
                        TxtCod_Articulo.Text = .Rows(0)("c_codi_articulo").ToString
                        TxtPrecio.Text = Format(Val(.Rows(0)("c_prec_prv").ToString), Forma_1_4)
                        TxtItem.Text = .Rows(0)("c_nro_Correl").ToString
                    End If
                End With
            End If
        End With
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call Cancelar_Detalles()
    End Sub
    ' Eliminamos Registros '
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Dim F As String = MsgBox("¿Confirma la Eliminación del Registro?", vbYesNo + vbQuestion, Compañia)
                    If F = vbYes Then
                        If Val(.Rows(Fila).Cells("Item").Value) > 0 Then
                            Call Grabar_Detalles("DEL", Fila)
                        End If
                        .Rows.RemoveAt(Fila)
                    End If
                End If
            End If
        End With
    End Sub
    ' Aceptamos Registros '
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If Len(TxtCod_Articulo.Text) > 0 Then
            If Val(TxtPrecio.Text) > 0 Then
                If Len(CboMon.Text) > 0 Then
                    If Val(TxtItem.Text) = 0 Then
                        Dgv02.Rows.Add()
                        Call Agregar_Detalles(Dgv02.RowCount - 1) : Call Cancelar_Detalles()
                    Else
                        With Dgv02
                            If .RowCount > 0 Then
                                Dim Fila As Integer = .CurrentCellAddress.Y
                                Call Agregar_Detalles(Fila) : Call Cancelar_Detalles()
                            End If
                        End With
                    End If
                Else
                    MsgBox("1. Falta Seleccionar la moneda...", vbCritical, Compañia)
                End If
            Else
                MsgBox("2. Falta Ingresar el Precio...", vbCritical, Compañia)
            End If
        Else
            MsgBox("3. Falta Seleccionar el Artículo...", vbCritical, Compañia)
        End If
    End Sub
    ' Metodo para insetar o editar un nuevo detalle de registro
    Private Sub Agregar_Detalles(ByVal Fila As Integer)
        With Dgv02
            .Rows(Fila).Cells("Mot").Value = TxtCod_Mt.Text
            .Rows(Fila).Cells("Cd").Value = TxtCod_Cd.Text
            .Rows(Fila).Cells("Art").Value = TxtCod_Scd.Text
            .Rows(Fila).Cells("Codigo").Value = TxtCod_Articulo.Text
            .Rows(Fila).Cells("Articulo").Value = TxtScd.Text
            .Rows(Fila).Cells("Mon").Value = CboMon.Text
            .Rows(Fila).Cells("c_codi_mon").Value = CboMon.SelectedValue
            .Rows(Fila).Cells("Precio").Value = Format(Val(TxtPrecio.Text), Forma_1_4)
            .Rows(Fila).Cells("Item").Value = TxtItem.Text
        End With
    End Sub

    Private Sub TxtPrecio_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
                Call BtnAceptar_Click(Nothing, Nothing)
            End If
    End Sub

    Private Sub TxtPrecio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrecio.TextChanged

    End Sub
    ' Buscamos por nombre de articulos '
    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        Pan02.Visible = True
        Call Cargar_Articulos(" And A.c_anula_reg=0 order by c_desc_Articulo") : TxtBus_Art.Focus()
    End Sub
    ' Metodo para buscar los articulos '
    Private Sub Cargar_Articulos(ByVal Cadena As String)
        With Dgv03
            .DataSource = c_Neg_MnArticulo.get_Articulo_Datos(Cadena, "DG3")
            .Columns("Mot").Width = 50
            .Columns("Cd").Width = 50
            .Columns("Scd").Width = 50
            .Columns("Articulo").Width = 280
            ' Alineacion de Columnas '
            .Columns("Mot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Scd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo").Visible = False
        End With
    End Sub
    ' Enviamos enfoque '
    Private Sub TxtBus_Art_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Art.KeyDown
        With Dgv03
            ' Dim caja As New TextBox
            If .RowCount > 0 Then
                ' On Error Resume Next
                x = .CurrentCell.RowIndex
                If e.KeyCode = Keys.Down Then
                    e.Handled = True : Foco = 1
                    x += 1 : Call Movilizar_Grid(Dgv03, x, "ABAJO")
                End If
                If e.KeyCode = Keys.Up Then
                    Foco = 1 : e.Handled = True
                    x -= 1 : Call Movilizar_Grid(Dgv03, x, "ARRIBA")
                End If
                If e.KeyCode = Keys.Enter Then
                    If Foco = 1 Then
                        Call Dgv03_DoubleClick(Nothing, Nothing)
                    End If
                End If
            End If
        End With 'Mostramos los datos al presionar la tecla enter
    End Sub
    ' Buscamos por nombre de articulo '
    Private Sub TxtBus_Art_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Art.TextChanged
        Call Cargar_Articulos(" And A.c_anula_reg=0 and A.c_desc_articulo like '" & TxtBus_Art.Text & "%' order by c_desc_articulo")
    End Sub

    Private Sub Dgv03_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv03.CellContentClick

    End Sub
    ' Mostramos datos al dar doble click '
    Private Sub Dgv03_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv03.DoubleClick
        With Dgv03
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    For I = 0 To Dgv02.RowCount - 1
                        If .Rows(Fila).Cells("Codigo").Value = Dgv02.Rows(I).Cells("Codigo").Value Then
                            Dgv02.CurrentCell = Dgv02.Rows(I).Cells("Codigo")
                            I = Dgv02.RowCount : Pan02.Visible = False
                        End If
                    Next
                End If
            End If
        End With
    End Sub
    ' Mostramos datos al dar doble click '
    Private Sub Dgv03_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv03.KeyDown
        If e.KeyCode = Keys.Enter Then Call Dgv03_DoubleClick(Nothing, Nothing)
    End Sub
End Class