Public Class FrmOQ  
    Dim X, Y As Integer
    Dim pos As Integer = 0
    Dim focos As Integer = 0 ' Variable que trabajara con el enfoque para agregar items '
    Dim vEditar As Integer = 0 ' Variable que nos permitira saber si estamos editando registro o grabar nuevo registro '
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        With Dgv01
            If .RowCount > 0 Then
                If CboSerie.SelectedIndex > -1 Then
                    If CboArea.SelectedIndex > -1 Then
                        Dim f As String = MsgBox("¿Desea grabar el registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                        If f = vbYes Then
                            Call Grabar_OQ("ADD")
                            For i = 0 To .RowCount - 1
                                ' Validamos si eliminamos el registro '
                                If Val(.Rows(i).Cells("Anula").Value) = 0 Then
                                    Call Grabar_OQDET(i, "ADD")
                                Else
                                    Call Grabar_OQDET(i, "DEL")
                                End If
                            Next
                            Call BtnMos_Click(Nothing, Nothing)
                            BtnGrabar.Enabled = False
                            Pan09.Enabled = False
                            Pan11.Enabled = False
                        End If
                    Else
                        MsgBox("Falta seleccionar el Area...", MsgBoxStyle.Critical, Compañia)
                        CboArea.Focus()
                    End If
                Else
                    MsgBox("Falta seleccionar le Tipo de Requerimiento, Compras o Servicios...", MsgBoxStyle.Critical, Compañia)
                    CboSerie.Focus()
                End If
            Else
                MsgBox("Falta ingresar los artículos para la orden de Requerimiento", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    Private Sub Grabar_OQ(ByVal cOpcion As String)
        With c_Ent_OQ
            Dim tpo_ord As Integer = 0
            If Rdb01.Checked = True Then tpo_ord = 1
            If Rdb02.Checked = True Then tpo_ord = 2

            .c_nro_serie = CboSerie.Text
            .c_nro_oq = TxtOrden.Text
            .c_tpo_oq = tpo_ord
            .c_fecha_emi = DtpFec_Emi.Text
            .c_codi_area = CboArea.SelectedValue
            .c_usuario = FrmMenu.lblusuario.Text
            .c_obs = TxtObs.Text
            .copcion = cOpcion
            If Len(TxtOrden.Text) = 0 Then
                TxtOrden.Text = c_Neg_OQ.set_OQ_Save(c_Ent_OQ, FrmMenu.TxtCod_Emp.Text)
            Else
                c_Neg_OQ.set_OQ_Save(c_Ent_OQ, FrmMenu.TxtCod_Emp.Text)
            End If
        End With

    End Sub
    ' Grabamos detalles dde OQDET '
    Private Sub Grabar_OQDET(ByVal Fila As Integer, ByVal cOpcion As String)
        With Dgv01
            If .RowCount > 0 Then
                With c_Ent_OQDet
                    .c_nro_correl = Dgv01.Rows(Fila).Cells("Item").Value
                    .c_nro_serie = CboSerie.Text
                    .c_nro_oq = TxtOrden.Text
                    .c_codi_tg = Dgv01.Rows(Fila).Cells("Tg").Value
                    .c_codi_cd = Dgv01.Rows(Fila).Cells("Cd").Value
                    .c_codi_scd = Dgv01.Rows(Fila).Cells("Scd").Value
                    .c_codi_articulo = Dgv01.Rows(Fila).Cells("Codigo").Value
                    .c_cant_oq = Dgv01.Rows(Fila).Cells("cantidad").Value
                    .c_codi_unimed = Dgv01.Rows(Fila).Cells("Codi_UniMed").Value
                    .c_obs = Dgv01.Rows(Fila).Cells("Obs").Value
                    .copcion = cOpcion
                    c_Neg_OQDet.set_OQDet_Save(c_Ent_OQDet, FrmMenu.TxtCod_Emp.Text)
                End With
            End If
        End With
    End Sub
    Private Sub FrmOrdOQ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown


        'nuevo registro
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        'editamos registro
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        'Grabamos registros
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmOrdOQ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmOrdIQ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnOQSerie.Get_OQSerie_Cbo(" and c_anula_reg=0", CboBus_Serie)
        c_Neg_MnOQSerie.Get_OQSerie_Cbo(" and c_anula_reg=0", CboSerie)
        c_Neg_MnAreas.Get_Areas_Cbo(" and c_anula_reg=0 order by c_desc_area", CboArea)
        c_Neg_MnAreas.Get_Areas_Cbo(" and c_anula_reg=0 order by c_desc_area", CboBus_Area)
        c_Neg_MnUniMed.Get_UniMed_Cbo(" and c_anula_reg=0 order by c_desc_unimed", CboUniMed)
        CboBus_Serie.SelectedIndex = 0
        CboSerie.SelectedIndex = -1
        DtpFec_Inicio.Text = "01/" & Strings.Right(Month(Date.Now) + 100, 2) & "/" & Year(Date.Now)
        Call Configurar_Grid_Det()
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Private Sub Configurar_Grid_Det()
        With Dgv01
            .Columns("Anula").Visible = False
            .Columns("Codi_UniMed").Visible = False

            'Ajustamos tamaño del grid
            .Columns("Cantidad").Width = 80
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Unid").Width = 50
            .Columns("Unid").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Tg").Width = 50
            .Columns("Tg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cd").Width = 50
            .Columns("Cd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo").Width = 70
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Descripcion").Width = 260
            .Columns("Obs").Width = 200
            'color
            .Columns("Descripcion").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Descripcion").HeaderCell.Style.ForeColor = Color.Blue
        End With
    End Sub
    Public Sub Cargar_Grid()
        Dim Area As String = ""
        If Len(CboBus_Area.Text) = 0 Then
            Area = " "
        Else
            Area = " and O.c_codi_area='" & CboBus_Area.SelectedValue & "' "
        End If

        Dim Rango_Fechas As String = ""
        If DtpFec_Inicio.Text = DtpFec_Fin.Text Then
            Rango_Fechas = " "
        Else
            Rango_Fechas = " and O.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and O.c_fecha_emi<='" & DtpFec_Fin.Text & "' "
        End If
        Dgv02.DataSource = c_Neg_OQ.get_OQ_Datos(Rango_Fechas & " and O.c_nro_Serie='" & CboBus_Serie.Text & _
                                            "' " & Area & "    order by c_nro_oq", FrmMenu.TxtCod_Emp.Text, "DGV")
        With Dgv02
            .Columns("O.").Width = 40
            .Columns("Requerim.").Width = 60
            .Columns("Requerim.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Requerim.").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("O.").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("O.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Fecha Registro").Width = 105
            .Columns("Fecha Registro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Fecha Emision").Width = 100
            .Columns("Fecha Emision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Emision").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Area").Width = 200
            .Columns("Observaciones").Width = 200
            .Columns("c_anula_reg").Visible = False
            .Columns("c_estado_oq").Visible = False
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("c_anula_reg").Value = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
            'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = "1 / " & .RowCount
        End With
    End Sub
    'metodo que nos permite buscar solo por numero de orden de compra
    Private Sub Cargar_Grid_2(ByVal Cadena As String)
        Dgv02.DataSource = c_Neg_OQ.get_OQ_Datos(Cadena, FrmMenu.TxtCod_Emp.Text, "DGV")
        With Dgv02
            .Columns("O.").Width = 40
            .Columns("Requerim.").Width = 60
            .Columns("Requerim.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Requerim.").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Fecha Registro").Width = 105
            .Columns("Fecha Registro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Fecha Emision").Width = 100
            .Columns("Fecha Emision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Emision").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Area").Width = 200
            .Columns("Observaciones").Width = 200
            .Columns("c_anula_reg").Visible = False
            .Columns("c_estado_oq").Visible = False
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("c_anula_reg").Value = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
            'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = "1 / " & .RowCount
        End With
    End Sub
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        DtpFec_Emi.Text = Date.Now
        CboArea.SelectedValue = ""
        Call Nuevo_Registro()
        CboSerie.Enabled = True
        CboSerie.SelectedIndex = -1
        CboArea.SelectedIndex = -1
        Rdb01.Checked = False
        Rdb02.Checked = False
        Rdb01.Enabled = True
        Rdb02.Enabled = True
        CboSerie.Enabled = True : CboSerie.SelectedIndex = 0 : BtnEstado.Visible = False
    End Sub
    Private Sub Nuevo_Registro()
        Call Activar(Pan01) : Call Activar(Pan04) : Call Activar(Pan06) : Call Activar(Pan08)
        Call Limpiar_Texto(Pan01) : Call Limpiar_Texto(Pan04) : Call Limpiar_Texto(Pan03)
        Call Limpiar_Texto(Pan05) : Call Limpiar_Texto(Pan06) : Call Limpiar_Texto(Pan07)
        Call Limpiar_Texto(Pan08)
        Dgv01.Rows.Clear() : BtnGrabar.Enabled = True : Tbc01.SelectedTab = Tab02
        Pan11.Enabled = True : Pan09.Enabled = True : TxtOrden.Enabled = False
        CboSerie.Focus() : BtnEstado.Visible = True : Call Cancelar_Detalles()
    End Sub
    'Metodo que nos permitira restringir el ingreso de un articulo 2 veces
    Private Sub Validar_Ingreso(ByVal x As TextBox)
        With Dgv01
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    If Val(.Rows(i).Cells("anula").Value) = 0 Then
                        If .Rows(i).Cells("tg").Value = TxtCod_Tg.Text And .Rows(i).Cells("cd").Value = TxtCod_Cd.Text And _
                            .Rows(i).Cells("art").Value = TxtCod_Scd.Text Then
                            x.Text = 1
                            i = .RowCount
                        End If
                    End If
                Next
            End If
        End With
    End Sub
    ' Metodo para validar Grabacion de Detalles '
    Public Function ValidarDetalles() As Boolean
        With Dgv01
            If Len(TxtCod_Cd.Text) > 0 Then
                If Len(TxtCod_Scd.Text) > 0 Then
                    If Len(TxtCod_Tg.Text) > 0 Then
                        If Val(TxtCant.Text) > 0 Then
                            If Len(CboUniMed.SelectedValue) > 0 Then
                                ValidarDetalles = True
                            Else
                                MsgBox("Falta Seleccionar la Unidad de Medida...", vbCritical, Compañia)
                                ValidarDetalles = False
                            End If
                        Else
                            MsgBox("Falta ingresar la Cantidad", MsgBoxStyle.Critical)
                            TxtCant.Focus() : ValidarDetalles = False
                        End If
                    Else
                        MsgBox("Falta seleccionar la tabla general", MsgBoxStyle.Critical)
                        TxtTg.Focus() : ValidarDetalles = False
                    End If
                Else
                    MsgBox("Falta seleccionar la SubCaida", MsgBoxStyle.Critical)
                    TxtScd.Focus() : ValidarDetalles = False
                End If
            Else
                MsgBox("Falta seleccionar la Caida", MsgBoxStyle.Critical)
                TxtCd.Focus() : ValidarDetalles = False
            End If
        End With
    End Function
    ' Aceptamos Registro '
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        With Dgv01
            If ValidarDetalles() = True Then
                If vEditar = 0 Then
                    .Rows.Add()
                    Call Agregar_Registro(.RowCount - 1)
                Else
                    Dim Fila As Integer = .CurrentCellAddress.Y
                    Call Agregar_Registro(Fila)
                End If
                Call Cancelar_Detalles() : focos = 1 : BtnAdd.Focus()
            End If
        End With
    End Sub
    Private Sub Agregar_Registro(ByVal Fila As Integer)
        With Dgv01
            .Rows(Fila).Cells("Cantidad").Value = Format(Val(TxtCant.Text), Forma_1_4)
            .Rows(Fila).Cells("Unid").Value = CboUniMed.Text
            .Rows(Fila).Cells("Tg").Value = TxtCod_Tg.Text
            .Rows(Fila).Cells("Cd").Value = TxtCod_Cd.Text
            .Rows(Fila).Cells("Scd").Value = TxtCod_Scd.Text
            .Rows(Fila).Cells("Codigo").Value = TxtCodigo.Text
            .Rows(Fila).Cells("Descripcion").Value = TxtScd.Text
            .Rows(Fila).Cells("Anula").Value = 0
            .Rows(Fila).Cells("Item").Value = TxtItem.Text
            .Rows(Fila).Cells("Codi_UniMed").Value = CboUniMed.SelectedValue
            .Rows(Fila).Cells("obs").Value = ""
        End With
    End Sub
    Private Sub TxtTg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTg.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon2.Enabled = True Then Call BtnCon2_Click(Nothing, Nothing)
    End Sub


    Private Sub TxtCd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCd.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon2.Enabled = True Then Call BtnCon3_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtCd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCd.LostFocus

    End Sub

    Private Sub TxtCd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCd.TextChanged

    End Sub

    Private Sub TxtScd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtScd.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon4.Enabled = True Then Call BtnCon4_Click(Nothing, Nothing)
    End Sub



    Private Sub TxtScd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtScd.LostFocus
        If X = 2 Then
            X = 0
            TxtScd.Focus()
        End If
        If Y = 2 Then
            Y = 0
            TxtScd.Focus()
        End If
    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Call Nuevo_Detalles() : vEditar = 0
        BtnCon2.Focus()
    End Sub

    Private Sub CboSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSerie.SelectedIndexChanged
        If CboSerie.SelectedIndex = 0 Then Rdb01.Checked = True
        If CboSerie.SelectedIndex = 1 Then Rdb02.Checked = True
    End Sub

    Private Sub BtnMos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMos.Click
        Call Cargar_Grid()
    End Sub
    Private Sub Editar_Registro()
        Call Mostrar_OQ() : Tbc01.SelectedTab = Tab02
        Call Activar(Pan03) : Call Activar(Pan06)
        Call Activar(Pan08) : Pan11.Enabled = True
        Pan09.Enabled = True : Pan11.Enabled = True
        Call Limpiar_Texto(Pan08) : CboSerie.Enabled = False
        BtnGrabar.Enabled = True : TxtCod_Tg.Enabled = False
        TxtCod_Cd.Enabled = False : TxtCod_Scd.Enabled = False
        CboUniMed.Enabled = False
        Rdb01.Enabled = False : Rdb02.Enabled = False
    End Sub
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_estado_oq").Value) = 0 Then
                        If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                            Call Editar_Registro() : CboSerie.Enabled = False : TxtOrden.Enabled = False
                        Else
                            MsgBox("Orden se encuentra anulada...", MsgBoxStyle.Critical)
                        End If
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub Mostrar_OQ()
        With Dgv02
            Call Desactivar(Pan03) : Call Desactivar(Pan06)
            Call Desactivar(Pan04) : Call Desactivar(Pan08)
            Call Desactivar(Pan05) : Pan09.Enabled = False
            Pan11.Enabled = False
            Call Limpiar_Texto(Pan08) : Call Limpiar_Texto(Pan03)
            Call Limpiar_Texto(Pan05) : Call Cancelar_Detalles()
            Dgv01.Rows.Clear()
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    With c_Neg_OQ.get_OQ_Datos(" and c_nro_serie='" & .Rows(fila).Cells("O.").Value & "' and c_nro_oq='" & .Rows(fila).Cells("Requerim.").Value & "'", FrmMenu.TxtCod_Emp.Text, "DAT")
                        If .Rows.Count > 0 Then
                            'mostramos series
                            CboSerie.SelectedValue = .Rows(0)("c_nro_serie").ToString
                            'mostramos areas
                            CboArea.SelectedValue = .Rows(0)("c_codi_area").ToString
                            TxtOrden.Text = .Rows(0)("c_nro_oq").ToString
                            DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                            TxtObs.Text = .Rows(0)("c_obs").ToString
                            TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                            TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                            TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                            TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                            'validamos si registro se encuentra anulado
                            BtnEstado.Visible = True
                            If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then 'Validamos estado
                                If Val(.Rows(0)("c_estado_oq").ToString) = 0 Then
                                    BtnEstado.BackColor = Color.Maroon
                                    BtnEstado.ForeColor = Color.WhiteSmoke
                                    BtnEstado.Text = "PENDIENTE"
                                Else
                                    BtnEstado.BackColor = Color.Blue
                                    BtnEstado.ForeColor = Color.WhiteSmoke
                                    BtnEstado.Text = "INGRESADO"
                                End If
                            Else
                                BtnEstado.BackColor = Color.Red
                                BtnEstado.ForeColor = Color.WhiteSmoke
                                BtnEstado.Text = "ANULADO"
                            End If
                            'cargamos detalles de O.Requerimientos
                            With c_Neg_OQDet.get_OQDet_Datos(" and c_nro_serie='" & .Rows(0)("c_nro_Serie").ToString & "' and c_nro_oq='" & .Rows(0)("c_nro_oq").ToString & "'", FrmMenu.TxtCod_Emp.Text, "DAT")
                                If .Rows.Count > 0 Then
                                    For i = 0 To .Rows.Count - 1
                                        Dgv01.Rows.Add()
                                        Dgv01.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_cant_oq").ToString), Forma_1_2)
                                        Dgv01.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                                        Dgv01.Rows(i).Cells("tg").Value = .Rows(i)("c_codi_tg").ToString
                                        Dgv01.Rows(i).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString
                                        Dgv01.Rows(i).Cells("Scd").Value = .Rows(i)("c_codi_scd").ToString
                                        Dgv01.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                                        Dgv01.Rows(i).Cells("Descripcion").Value = .Rows(i)("c_desc_scd").ToString
                                        Dgv01.Rows(i).Cells("Obs").Value = .Rows(i)("c_obs").ToString
                                        'Validamos el color...
                                        If Val(.Rows(i)("c_anula_reg").ToString) = 1 Then
                                            Dgv01.Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                                            Dgv01.Rows(i).Cells("Anula").Value = Val(.Rows(i)("c_anula_reg").ToString)
                                        End If
                                        Dgv01.Rows(i).Cells("Codi_UniMed").Value = .Rows(i)("c_codi_unimed").ToString
                                        Dgv01.Rows(i).Cells("Item").Value = .Rows(i)("c_nro_correl").ToString
                                    Next
                                End If
                            End With
                        End If
                    End With
                End If
            End If
        End With
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Tbc01.SelectedTab = Tab01
        Call Desactivar(Pan03)
        Call Desactivar(Pan06)
        Call Desactivar(Pan04)
        Call Limpiar_Texto(Pan08)
        Dgv01.Enabled = True
        CboSerie.Enabled = False
        TxtBus_OQ.Focus()

        BtnEstado.Visible = False
    End Sub

    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 1 Then
            Call Mostrar_OQ()
            Tbc01.SelectedTab = Tab02
            BtnGrabar.Enabled = False
            BtnEstado.Visible = True
        Else
            BtnEstado.Visible = False
        End If

    End Sub

    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
    End Sub

    Private Sub TxtScd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtScd.TextChanged

    End Sub

    Private Sub Dgv03_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("anula").Value) = 0 Then
                        vEditar = 1
                        Call Nuevo_Detalles()
                        TxtScd.Enabled = False : TxtCd.Enabled = False : TxtTg.Enabled = False
                        'validamos si registro fue grabado anteriormente
                        TxtCod_Tg.Text = .Rows(fila).Cells("Tg").Value
                        TxtCod_Cd.Text = .Rows(fila).Cells("Cd").Value
                        TxtCod_Scd.Text = .Rows(fila).Cells("Scd").Value
                        TxtCodigo.Text = .Rows(fila).Cells("Codigo").Value
                        TxtScd.Text = .Rows(fila).Cells("Descripcion").Value
                        TxtCant.Text = Format(Val(.Rows(fila).Cells("Cantidad").Value), Forma_1_4)
                        TxtItem.Text = .Rows(fila).Cells("Item").Value
                        CboUniMed.SelectedValue = .Rows(fila).Cells("Codi_UniMed").Value
                        BtnCon2.Enabled = False : BtnCon3.Enabled = False : BtnCon4.Enabled = False
                        TxtCant.Focus() : Call Mostrar_Caidas()
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub Mostrar_Caidas()
        With c_Neg_MnScaidas.get_sCaidas_Datos(" and S.c_codi_tg='" & TxtCod_Tg.Text & "' and S.c_codi_cd='" & TxtCod_Cd.Text & "' and S.c_codi_scd='" & TxtCod_Scd.Text & "'", "DAT")
            If .Rows.Count > 0 Then
                TxtTg.Text = .Rows(0)("c_desc_tg").ToString
                TxtCd.Text = .Rows(0)("c_desc_cd").ToString
                TxtCod_Tg.Text = .Rows(0)("c_codi_tg").ToString
                TxtCod_Cd.Text = .Rows(0)("c_codi_cd").ToString
                TxtCod_Scd.Text = .Rows(0)("c_codi_scd").ToString

            End If
        End With
    End Sub
    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        If BtnDel.Text = "Cancelar" Then
            Call Cancelar_Detalles()
        Else
            With Dgv01
                If .RowCount > 0 Then
                    Dim fila As Integer = .CurrentCellAddress.Y
                    If fila > -1 Then
                        If Val(.Rows(fila).Cells("Anula").Value) = 0 Then
                            Dim f As String = MsgBox("¿Desea Eliminar el artículo?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                            If Val(.Rows(fila).Cells("Item").Value) = 0 Then 'si no ha sido grabado anteriormente se elimina del grid...
                                Dgv01.Rows.RemoveAt(fila)
                            Else 'si ya fue grabado anteriormente solo se cambia de color...
                                If f = vbYes Then
                                    .Rows(fila).Cells("anula").Value = 1
                                    .Rows(fila).DefaultCellStyle.BackColor = Color.Gainsboro
                                End If
                            End If
                        End If
                    End If
                End If
            End With
        End If
    End Sub
    Private Sub Cancelar_Detalles()
        With Dgv01
            .Height = 294
            .Width = 689
            .Location = New Point(3, 24)
            Pan08.Visible = False
            .Enabled = True
        End With
        BtnAdd.Enabled = True
        BtnEdit.Enabled = True
        BtnDel.Text = "&Eliminar"
        BtnAceptar.Enabled = False

    End Sub

    Private Sub Nuevo_Detalles()
        With Dgv01
            .Size = New Size(689, 220)
            .Location = New Point(3, 98)
            Pan08.Visible = True
        End With
        BtnAdd.Enabled = False : BtnEdit.Enabled = False : BtnAceptar.Enabled = True
        BtnDel.Text = "Cancelar"
        BtnEdit.Enabled = False
        BtnAceptar.Enabled = True
        Call Limpiar_Texto(Pan08)
        BtnCon2.Enabled = True : BtnCon3.Enabled = True : BtnCon4.Enabled = True
        CboUniMed.Enabled = True
        TxtCod_Tg.Enabled = False : TxtCod_Cd.Enabled = False : TxtCod_Scd.Enabled = False
        TxtTg.Enabled = False : TxtCd.Enabled = False : TxtScd.Enabled = False : TxtCodigo.Enabled = False
    End Sub

    Private Sub BtnEdit_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnEdit.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnAdd.Enabled = False
            TxtCant.Focus()
        End If

    End Sub
    ' Consultamos por Tabla General '
    Private Sub BtnCon2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon2.Click
        With FrmConTg
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 3
            .Cargar_Grid(" and c_anula_reg=0  order by c_desc_tg")
        End With
    End Sub

    Private Sub BtnCon3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon3.Click
        With FrmConCd
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 3 : .TxtCod_Tg.Text = TxtCod_Tg.Text
            .Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' order by c_desc_cd")
        End With
    End Sub
    ' Consultar SubCaidas '
    Private Sub BtnCon4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon4.Click
        With FrmConScd
            .Show() : .MdiParent = FrmMenu
            .TxtVar.Text = 3 : .TxtCod_Tg.Text = TxtCod_Tg.Text : .TxtCod_Cd.Text = TxtCod_Cd.Text
            .Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' and c_codi_cd='" & TxtCod_Cd.Text & "' order by c_desc_scd")
        End With
    End Sub
    Public Sub Mostrar_Scaidas()
        With c_Neg_MnScaidas.get_sCaidas_Datos(" and s.c_codi_scd='" & TxtCod_Scd.Text & "' and S.c_codi_tg='" & TxtCod_Tg.Text & "' and s.c_codi_cd='" & TxtCod_Cd.Text & "'", "DAT")
            If .Rows.Count > 0 Then
                CboUniMed.SelectedValue = .Rows(0)("c_codi_articulo").ToString
                Pan11.Focus()
            End If
        End With
    End Sub

    Private Sub TxtColor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    'Validamos si las areas ya fueron cargadas, esto permitira no utilizar los recursos innecesariamente...
    Private Sub CboBus_Serie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboBus_Serie.SelectedIndexChanged
        If CboArea.Items.Count > 0 Then Call BtnMos_Click(Nothing, Nothing)
        If CboBus_Serie.SelectedIndex = 0 Then Me.Text = "Orden de Requerimiento [SERVICIOS]"
        If CboBus_Serie.SelectedIndex = 1 Then Me.Text = "Orden de Requerimiento [COMPRAS]"

    End Sub

    Private Sub Rdb01_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb01.CheckedChanged
        If Rdb01.Checked = True Then CboSerie.SelectedIndex = 0
    End Sub

    Private Sub Rdb02_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb02.CheckedChanged
        If Rdb02.Checked = True Then CboSerie.SelectedIndex = 1
    End Sub

    Private Sub Dgv02_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv02.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv02)
    End Sub
    'MOSTRAmos los datos...
    Private Sub Dgv02_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv02.DoubleClick
        Tbc01.SelectedIndex = 1 : Call Tbc01_Click(Nothing, Nothing)
    End Sub

    'Eliminamos registro
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        If Val(.Rows(fila).Cells("c_estado_oq").Value) = 0 Then
                            Dim F As String = MsgBox("¿Confirma la elminación del registro?", vbYesNo + MsgBoxStyle.Critical, Compañia)
                            If F = vbYes Then
                                CboSerie.SelectedValue = .Rows(fila).Cells("O.").Value
                                TxtOrden.Text = .Rows(fila).Cells("Requerim.").Value
                                Call Grabar_OQ("DEL")
                                .Rows(fila).Cells("c_anula_reg").Value = 1
                                .Rows(fila).DefaultCellStyle.BackColor = Color.Gainsboro
                            End If
                        Else
                            MsgBox("Orden ya fue ingresada no podra realizar ninguna modificación...", MsgBoxStyle.Critical, Compañia)
                        End If
                    Else
                        MsgBox("Registro se encuentra anulado, no podra realizar ninguna operación", MsgBoxStyle.Critical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        MsgBox("  Módulo pendiente, se encuentra en construcción...  ", vbCritical, Compañia)
    End Sub
    'Inicio
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Movilizar_Registros(Dgv02, TxtReg, 1)
    End Sub
    'Atras
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        Call Movilizar_Registros(Dgv02, TxtReg, 2)
    End Sub
    'Avanza
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        Call Movilizar_Registros(Dgv02, TxtReg, 3)
    End Sub
    'Final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Movilizar_Registros(Dgv02, TxtReg, 4)
    End Sub

    Private Sub Dgv02_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv02.CellContentClick

    End Sub

    Private Sub Dgv02_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv02.SelectionChanged
        With Dgv02 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub

    Private Sub TxtBus_OQ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_OQ.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_OQ.Text) > 0 Then
                TxtBus_OQ.Text = Strings.Right(Val(TxtBus_OQ.Text) + 10000000, 7)
                Call Cargar_Grid_2(" and c_nro_oq='" & TxtBus_OQ.Text & "' and c_nro_serie='" & CboBus_Serie.Text & "'")
            End If
        End If
    End Sub

    Private Sub TxtBus_OQ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_OQ.TextChanged

    End Sub

    Private Sub TxtObs_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtObs.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call BtnAdd_Click(Nothing, Nothing) : Call BtnCon2_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TxtObs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtObs.TextChanged

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        With Dgv01
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("anula").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
        End With
    End Sub
    ' Cambiamos a mayusculas '
    Private Sub CboUniMed_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboUniMed.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboUniMed_LostFocus(sender As Object, e As System.EventArgs) Handles CboUniMed.LostFocus
        focos = 1 : BtnAdd.Focus()
    End Sub

    Private Sub CboUniMed_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboUniMed.SelectedIndexChanged

    End Sub
    ' Evitamos que se pierda en el enfoque '
    Private Sub BtnAdd_LostFocus(sender As Object, e As System.EventArgs) Handles BtnAdd.LostFocus
        If focos = 1 Then
            focos = 0 : BtnAdd.Focus()
        End If
    End Sub
    ' Cambiamos a Mayusculas '
    Private Sub CboArea_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboArea.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboArea_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboArea.SelectedIndexChanged

    End Sub
End Class