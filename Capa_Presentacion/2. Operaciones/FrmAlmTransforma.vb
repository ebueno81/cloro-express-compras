Public Class FrmAlmTransforma
    Dim focos As Integer = 0

    Private Sub FrmAlmTransforma_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.KeyCode = Keys.Escape Then
            If BtnGrabar.Enabled = True Then
                Call BtnCerrar_Click(Nothing, Nothing)
            Else
                Me.Close()
            End If
        End If
    End Sub
    Private Sub FrmAlmTransforma_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmAlmTransforma_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnAlmacen.get_Almacen_Cbo(" and c_anula_reg=0 order by c_desc_alm", CboAlm01)
        c_Neg_MnAlmacen.get_Almacen_Cbo(" and c_anula_reg=0 order by c_desc_alm", CboAlm02)
        c_Neg_MnArticulos.Get_Articulo_Cbo(" and A.c_opc_ingtransforma=0 and A.c_opc_transforma=1 and A.c_anula_reg=0 order by c_desc_articulo", CboArticulo01)
        c_Neg_MnArticulos.Get_Articulo_Cbo(" and A.c_opc_ingtransforma=1 and A.c_opc_transforma=1 and A.c_anula_reg=0 order by c_desc_articulo", CboArticulo02)
        Call BtnFin_Click(Nothing, Nothing)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Public Sub AnularTransforma(ByVal c_nro_transforma As String)
        Call Mostrar_Transforma(c_nro_transforma, "DAT")
        Call Grabar_Transforma_Cab("DEL")
        ' Grabamos la salida por transformacion '
        With Dgv01
            For I = 0 To .RowCount - 1
                Call Grabar_Transforma_DetSal(I, "DEL")
            Next
        End With
        ' Grabamos la ingreso por transformacion '
        With Dgv02
            For I = 0 To .RowCount - 1
                Call Grabar_Transforma_DetIng(I, "DEL")
            Next
        End With
        ' Actualizamos kardex '
        If FrmRptKardex.Visible = True Then
            FrmRptKardex.IniciarGrid()
        End If
        MsgBox("Transformacion se anulo correctamente...", vbExclamation, Compañia)
        Me.Close()
    End Sub
    Public Sub EditarTransforma(ByVal c_nro_transforma As String)
        Call Mostrar_Transforma(c_nro_transforma, "DAT")
        Call BtnEditar_Click(Nothing, Nothing)
    End Sub


    Private Sub CboArticulo01_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboArticulo01.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    ' Buscamos Articulo salida de insumos quimicos '
    Private Sub CboArticulo01_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboArticulo01.SelectedIndexChanged
        On Error Resume Next
        Dim moneda As String = "" : Dim TpoCambio As Decimal = 0
        With c_Neg_TpoCambio.get_TpoCambio_Datos(" and c_fecha_cbo<='" & DtpFec_Sal.Text & "' order by c_fecha_cbo desc", "ACT")
            If .Rows.Count > 0 Then
                TpoCambio = Val(.Rows(0)("c_venta_sunat").ToString)
            End If
        End With
        With c_Neg_MnArticulos.get_Articulo_Datos(" and A.c_codi_articulo='" & CboArticulo01.SelectedValue & "'", "DAT")
            TxtCod_01.Clear() : TxtUniMed01.Clear() : TxtPrec01.Clear() : TxtMon01.Clear() : TxtItem01.Clear()
            If .Rows.Count > 0 Then
                TxtCod_01.Text = .Rows(0)("c_codi_articulo").ToString
                TxtUniMed01.Text = .Rows(0)("c_desc_unimed").ToString
                TxtMon01.Text = "02"
                moneda = .Rows(0)("c_codi_mon").ToString
                TxtCod_UniMed.Text = .Rows(0)("c_codi_unimed").ToString
                ' validamos si es agua para realizar la transferencia '
                If Val(.Rows(0)("c_opc_agua").ToString) = 1 Then
                    TxtPrec01.Text = Format(Val(.Rows(0)("c_precio_art").ToString), Forma_1_6)
                    If moneda = "01" Then
                        TxtPrec01.Text = Format(Val(.Rows(0)("c_precio_art").ToString), Forma_1_6)
                        TxtPrec01.Text = Format(Val(TxtPrec01.Text) / TpoCambio, Forma_1_6)
                    End If
                Else
                    ' --> Artículos de Almacen <-- '
                    With c_Neg_MnArticulos.get_Articulo_Datos(" and K.c_codi_articulo='" & TxtCod_01.Text & "' and K.c_fecha_kdx<='" & DtpFec_Sal.Text &
                                                              "' and K.c_codi_alm='" & CboAlm01.SelectedValue & "' order by K.c_fecha_kdx desc, K.c_nro_kdx desc ", "STO")
                        If .Rows.Count > 0 Then
                            TxtPrec01.Text = Format(Val(.Rows(0)("c_prec_prom").ToString), Forma_1_6)
                        End If
                    End With
                    ' --> Validamos si el precio es cero aun para jalar <-- '
                    If Val(TxtPrec01.Text) = 0 Then
                        TxtPrec01.Text = Val(.Rows(0)("c_prec_unit").ToString)
                        ' Validamos la moneda '
                        If moneda = "01" Then
                            TxtPrec01.Text = Format(Val(TxtPrec01.Text) / TpoCambio, Forma_1_6)
                        End If
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub CboArticulo02_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles CboArticulo02.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    ' Buscamos artpiculo por ingreso de insumos quimicos '
    Private Sub CboArticulo02_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboArticulo02.SelectedIndexChanged
        On Error Resume Next
        With c_Neg_MnArticulos.get_Articulo_Datos(" and A.c_codi_articulo='" & CboArticulo02.SelectedValue & "'", "DAT")
            TxtCod_02.Clear() : TxtUniMed02.Clear() : TxtPrec02.Clear() : TxtMon02.Clear() : TxtItem02.Clear()
            If .Rows.Count > 0 Then
                TxtCod_02.Text = .Rows(0)("c_codi_articulo").ToString
                TxtUniMed02.Text = .Rows(0)("c_desc_unimed").ToString
                TxtPrec01.Text = Format(Val(.Rows(0)("c_precio_art").ToString), Forma_1_3)
                TxtMon02.Text = .Rows(0)("c_codi_mon").ToString
                TxtCod_UniMed2.Text = .Rows(0)("c_codi_unimed").ToString
            End If
        End With
    End Sub
    ' Aceptamos registro '
    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        If Len(TxtCod_01.Text) > 0 Then
            If Val(TxtCant01.Text) <> 0 Then
                If Len(TxtItem01.Text) = 0 Then
                    Dgv01.Rows.Add()
                    Call Agregar_Registro_Sal(Dgv01.RowCount - 1)
                Else
                    Call Agregar_Registro_Sal(Dgv01.CurrentCellAddress.Y)
                End If
                Call BtnCancel_Click(Nothing, Nothing) : Call Calcular_Totales()
            Else
                MsgBox("1. Falta ingresar una cantidad Valida...", vbCritical, Compañia)
            End If
        Else
            MsgBox("2. Falta Seleccionar un Artículo...", vbCritical, Compañia)
        End If
    End Sub
    ' metodo para calcular el total de salida para hallar costo de transformacion '
    Private Sub Calcular_Totales()
        With Dgv01
            Dim c_total As Decimal = 0
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 0 Then
                    c_total = c_total + Val(.Rows(i).Cells("Total").Value)
                End If
            Next
            TxtTotal.Text = c_total
        End With
    End Sub
    ' Agregamos registros para salida para trasnformacion '
    Private Sub Agregar_Registro_Sal(ByVal Fila As Integer)
        With Dgv01
            .Rows(Fila).Cells("Codigo").Value = TxtCod_01.Text
            .Rows(Fila).Cells("Articulo").Value = CboArticulo01.Text
            .Rows(Fila).Cells("Cantidad").Value = Format(Val(TxtCant01.Text), Forma_1_4)
            .Rows(Fila).Cells("Unid").Value = TxtUniMed01.Text
            .Rows(Fila).Cells("Precio").Value = Format(Val(TxtPrec01.Text), Forma_1_6)
            .Rows(Fila).Cells("Total").Value = Format(Val(TxtPrec01.Text) * Val(TxtCant01.Text), Forma_1_2)
            .Rows(Fila).Cells("c_codi_unimed").Value = TxtCod_UniMed.Text
            .Rows(Fila).Cells("Nick").Value = TxtMon01.Text
            .Rows(Fila).Cells("Item").Value = TxtItem01.Text
            .Rows(Fila).Cells("c_anula_reg").Value = 0

        End With
    End Sub
    ' Agregamos registros para Ingreso por trasnformacion '
    Private Sub Agregar_Registro_Ing(ByVal Fila As Integer)
        With Dgv02
            .Rows(Fila).Cells("Codigo2").Value = TxtCod_02.Text
            .Rows(Fila).Cells("Articulo2").Value = CboArticulo02.Text
            .Rows(Fila).Cells("Cantidad2").Value = Format(Val(TxtCant02.Text), Forma_1_4)
            .Rows(Fila).Cells("Unid2").Value = TxtUniMed02.Text
            .Rows(Fila).Cells("Precio2").Value = Format(Val(TxtTotal.Text) / Val(TxtCant02.Text), Forma_1_2)
            .Rows(Fila).Cells("Total2").Value = Format(Val(TxtTotal.Text), Forma_1_2)
            .Rows(Fila).Cells("Nick2").Value = "02" ' Calculo sera siempre en dolares '
            .Rows(Fila).Cells("c_codi_unimed2").Value = TxtCod_UniMed2.Text
            .Rows(Fila).Cells("Item2").Value = TxtItem02.Text
            .Rows(Fila).Cells("c_anula_reg2").Value = 0
        End With
    End Sub
    ' Aceptamos Registro '
    Private Sub BtnAceptar2_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar2.Click
        If Len(TxtCod_02.Text) > 0 Then
            If Val(TxtCant02.Text) <> 0 Then
                If Len(TxtItem02.Text) = 0 Then
                    Dgv02.Rows.Add()
                    Call Agregar_Registro_Ing(Dgv02.RowCount - 1)
                Else
                    Call Agregar_Registro_Ing(Dgv02.CurrentCellAddress.Y)
                End If
                Call BtnCancel2_Click(Nothing, Nothing)
            Else
                MsgBox("1. Falta ingresar una cantidad Valida...", vbCritical, Compañia)
            End If
        Else
            MsgBox("2. Falta Seleccionar un Artículo...", vbCritical, Compañia)
        End If
    End Sub
    ' Editamos registro Salida '
    Private Sub BtnEdit_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Call Nuevo_Detalle_Sal() : CboArticulo01.Enabled = False : TxtCant01.Enabled = True : TxtCant01.Focus()
                    CboArticulo01.SelectedValue = .Rows(Fila).Cells("Codigo").Value
                    TxtCod_01.Text = .Rows(Fila).Cells("Codigo").Value
                    TxtCant01.Text = Format(Val(.Rows(Fila).Cells("Cantidad").Value), Forma_1_4)
                    TxtPrec01.Text = .Rows(Fila).Cells("Precio").Value
                    TxtMon01.Text = .Rows(Fila).Cells("Nick").Value
                    TxtItem01.Text = .Rows(Fila).Cells("Item").Value
                    TxtCod_UniMed.Text = .Rows(Fila).Cells("c_codi_unimed").Value
                    TxtUniMed01.Text = .Rows(Fila).Cells("Unid").Value
                    ' obtenemos el precio promedio en dolares cuando se grabe se convertira en soles y dolares '
                    With c_Neg_MnArticulos.get_Articulo_Datos(" AND K.c_fecha_kdx<='" & DtpFec_Sal.Text & "' AND K.c_codi_articulo='" & TxtCod_01.Text & _
                                                              "' AND K.c_codi_alm='" & CboAlm01.SelectedValue & "' ORDER BY c_fecha_kdx desc, c_nro_kdx", "ULT")
                        If .Rows.Count > 0 Then
                            TxtPrec01.Text = Format(Val(.Rows(0)("c_prec_prom").ToString), Forma_1_3)
                        End If
                    End With
                End If
            End If
        End With
    End Sub
    ' Editamos Registro '
    Private Sub BtnEdit2_Click(sender As System.Object, e As System.EventArgs) Handles BtnEdit2.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Call Nuevo_Detalle_Ing() : CboArticulo02.Enabled = False : TxtCant02.Enabled = True : TxtCant02.Focus()
                    CboArticulo02.SelectedValue = .Rows(Fila).Cells("Codigo2").Value
                    TxtCod_02.Text = .Rows(Fila).Cells("Codigo2").Value
                    TxtCant02.Text = Format(Val(.Rows(Fila).Cells("Cantidad2").Value), Forma_1_4)
                    TxtPrec02.Text = .Rows(Fila).Cells("Precio2").Value
                    TxtMon02.Text = .Rows(Fila).Cells("Nick2").Value
                    TxtItem02.Text = .Rows(Fila).Cells("Item2").Value
                    TxtCod_UniMed2.Text = .Rows(Fila).Cells("c_codi_unimed2").Value
                    TxtUniMed02.Text = .Rows(Fila).Cells("Unid2").Value
                End If
            End If
        End With
    End Sub
    ' Aceptamos registro '
    Private Sub TxtCant01_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCant01.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnAceptar_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtCant01_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCant01.TextChanged

    End Sub
    ' Aceptamos Registro '
    Private Sub TxtCant02_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCant02.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnAceptar2_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtCant02_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCant02.TextChanged

    End Sub
    ' Nuevo detalle Salida de Transformación '
    Private Sub BtnAdd_Click(sender As System.Object, e As System.EventArgs) Handles BtnAdd.Click
        Call Nuevo_Detalle_Sal() : CboArticulo01.Focus()
    End Sub
    ' Nuevo Detalle '
    Private Sub Nuevo_Detalle_Sal()
        With Dgv01
            .Size = New Size(435, 145) : .Location = New Point(2, 24) : CboArticulo01.SelectedIndex = -1
            Call Limpiar_Texto(Pan05) : TxtCant01.Enabled = True : CboArticulo01.Enabled = True
            Pan10.Enabled = False : Pan11.Enabled = True
        End With
    End Sub
    ' Cancelar Detalle de ingreso por transformacion'
    Private Sub Cancelar_Detalle_Sal()
        With Dgv01
            .Size = New Size(435, 168) : .Location = New Point(2, 1) : CboArticulo01.SelectedIndex = -1
            CboArticulo01.Enabled = False : TxtCant01.Enabled = False : Pan10.Enabled = True : Pan11.Enabled = False
        End With
    End Sub
    ' Agregamos el detalle '
    Private Sub BtnAdd2_Click(sender As System.Object, e As System.EventArgs) Handles BtnAdd2.Click
        Call Nuevo_Detalle_Ing() : CboArticulo02.Enabled = True : TxtCant02.Enabled = True : CboArticulo02.Focus()
    End Sub
    ' Nuevo Detalle de ingreso por transformacion'
    Private Sub Nuevo_Detalle_Ing()
        With Dgv02
            .Size = New Size(435, 145) : .Location = New Point(2, 24) : CboArticulo01.SelectedIndex = -1
            Call Limpiar_Texto(Pan06) : Pan13.Enabled = False : Pan14.Enabled = True
        End With
    End Sub
    ' Nuevo Detalle de ingreso por transformacion'
    Private Sub Cancelar_Detalle_Ing()
        With Dgv02
            .Size = New Size(435, 168) : .Location = New Point(2, 1) : CboArticulo02.SelectedIndex = -1
            CboArticulo02.Enabled = False : TxtCant02.Enabled = False : Pan14.Enabled = False : Pan13.Enabled = True
        End With
    End Sub
    ' Nuevo Ingreso '
    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Ingreso() : CboAlm01.SelectedIndex = -1 : CboAlm02.SelectedIndex = -1
        TxtNro_Egr.Clear() : TxtNro_Ing.Clear() : Dgv01.Rows.Clear() : Dgv02.Rows.Clear()
        DtpFec_Ing.Enabled = True : DtpFec_Sal.Enabled = True : CboAlm01.Enabled = True
        CboAlm01.Focus() : CboAlm01.SelectedIndex = 0 : CboAlm02.SelectedIndex = 0
        DtpFec_Ing.Text = Now.Date : DtpFec_Sal.Text = Now.Date : TxtObs.Clear()
        Pan20.Visible = False : TxtOpcEspecial.Clear()
    End Sub
    ' Nuevo de Ingreso '
    Private Sub Nuevo_Ingreso()
        Pan01.Enabled = False : Pan10.Enabled = True : Pan11.Enabled = False
        Pan13.Enabled = True : BtnGrabar.Enabled = True : BtnCerrar.Text = "&Cancelar"
        Pan03.Enabled = False : Pan08.Visible = False
        Call Limpiar_Texto(Pan21) : Call Limpiar_Texto(Pan22)
    End Sub
    ' Cancelamos Ingreso
    Private Sub Cancela_Ingreso()
        Pan01.Enabled = True : Pan10.Enabled = False : Pan11.Enabled = True
        Pan13.Enabled = False : BtnGrabar.Enabled = False : BtnCerrar.Text = "Cerrar"
        Pan03.Enabled = True
    End Sub
    ' Cerramos Ventana '
    Private Sub BtnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "Cerrar" Then
            Me.Close()
        Else
            If Len(TxtNro_Ing.Text) = 0 Then
                Call Cancela_Ingreso() : Call BtnFin_Click(Nothing, Nothing)
            Else
                Dim c_nro_ing As String = TxtNro_Ing.Text
                Call Cancela_Ingreso() : Call Mostrar_Transforma(c_nro_ing, "DAT")
                Call Cancelar_Detalle_Ing() : Call Cancelar_Detalle_Sal()
            End If
        End If
    End Sub
    ' Cancelamos Detalles de Ingresos '
    Private Sub BtnCancel2_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel2.Click
        Call Cancelar_Detalle_Ing() : focos = 1 : BtnAdd2.Focus()
    End Sub
    ' Cancelamos Salidas por Transformacion '
    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        Call Cancelar_Detalle_Sal() : focos = 1 : BtnAdd.Focus()
    End Sub
    ' Agregamos para salida por trasnformacion '
    Private Sub BtnAdd2_LostFocus(sender As Object, e As System.EventArgs) Handles BtnAdd2.LostFocus
        If focos = 1 Then
            focos = 0 : BtnAdd2.Focus()
        End If
    End Sub
    ' Agregamos para ingreso por transformacion '
    Private Sub BtnAdd_LostFocus(sender As Object, e As System.EventArgs) Handles BtnAdd.LostFocus
        If focos = 1 Then
            focos = 0 : BtnAdd.Focus()
        End If
    End Sub

    Private Sub CboAlm01_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboAlm01.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    ' Seleccionamos almacen por defecto '
    Private Sub CboAlm01_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboAlm01.SelectedIndexChanged
        On Error Resume Next
        CboAlm02.SelectedValue = CboAlm01.SelectedValue
    End Sub
    ' Funcion para validar grabacion de Registro
    Private Function ValidarDatos() As Boolean
        If Dgv01.RowCount > 0 Then
            If CboAlm01.SelectedIndex > -1 Then
                ValidarDatos = True
            Else
                MsgBox("1. Falta seleccionar el almacen de Salida...", vbCritical, Compañia)
                ValidarDatos = False
            End If
        Else
            MsgBox("2. Falta Ingresar los artículos para la Sálida...", vbCritical, Compañia)
            ValidarDatos = False
        End If
    End Function
    Private Sub validarTransformacionEspecial()
        TxtOpcEspecial.Clear()
        With Dgv02
            If .RowCount > 0 Then
                With c_Neg_MnArticulos.get_Articulo_Datos(" and A.c_anula_reg=0 and A.c_codi_arttransforma='" & .Rows(0).Cells("Codigo2").Value & "'", "DAT")
                    If .Rows.Count > 0 Then
                        TxtOpcEspecial.Text = 1
                    End If
                End With
            End If
        End With
    End Sub
    ' Grabamos Registro '
    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarCierre(DtpFec_Sal.Text) = True Then
            If ValidarDatos() = True Then
                Dim F As String = MsgBox("¿Desea Grabar la Transformación?...", vbYesNo + vbQuestion, Compañia)
                If F = vbYes Then
                    ' validamos si es una transformacion x el kardex especial 
                    Call validarTransformacionEspecial()

                    Call Grabar_Transforma_Cab("ADD")
                    ' Grabamos la salida por transformacion '
                    With Dgv01
                        For I = 0 To .RowCount - 1
                            Call Grabar_Transforma_DetSal(I, "ADD")
                        Next
                    End With
                    ' Grabamos la ingreso por transformacion '
                    With Dgv02
                        For I = 0 To .RowCount - 1
                            Call Grabar_Transforma_DetIng(I, "ADD")
                        Next
                    End With
                    Call BtnCerrar_Click(Nothing, Nothing)
                    ' Actualizamos kardex '
                    If FrmRptKardex.Visible = True Then
                        FrmRptKardex.IniciarGrid()
                        MsgBox("Se grabo correctamente la transformacion...", vbExclamation, Compañia)
                    Else
                        BtnVista_Click(Nothing, Nothing)
                    End If
                    'MsgBox("Registro se Grabo Correctamente...", vbExclamation, Compañia)
                End If
            End If
        End If
    End Sub
    ' Grabamos Cabecera de Transformacion '
    Public Sub Grabar_Transforma_Cab(ByVal cOpcion As String)
        With c_Ent_AlmTransforCab
            .c_nro_transforma = TxtNro_Egr.Text
            .c_codi_alm_sal = CboAlm01.SelectedValue
            .c_codi_alm_ing = CboAlm02.SelectedValue
            .c_fecha_sal = DtpFec_Sal.Text
            .c_fecha_ing = DtpFec_Ing.Text
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            If Val(TxtNro_Egr.Text) = 0 Then
                TxtNro_Egr.Text = c_Neg_AlmTransforCab.set_c_AlmTransforCab_Save(c_Ent_AlmTransforCab)
            Else
                c_Neg_AlmTransforCab.set_c_AlmTransforCab_Save(c_Ent_AlmTransforCab)
            End If
            TxtNro_Ing.Text = TxtNro_Egr.Text
        End With
    End Sub
    ' Grabamos Detalles de Salida por Transformación '
    Public Sub Grabar_Transforma_DetSal(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_AlmTransfordet
            .c_nro_correl = Dgv01.Rows(Fila).Cells("Item").Value
            .c_nro_transforma = TxtNro_Egr.Text
            .c_tpo_mov = "SAL"
            .c_codi_articulo = Dgv01.Rows(Fila).Cells("Codigo").Value
            .c_codi_mon = Dgv01.Rows(Fila).Cells("Nick").Value
            .c_codi_unimed = Dgv01.Rows(Fila).Cells("c_codi_unimed").Value
            .c_nro_cant = Val(Dgv01.Rows(Fila).Cells("Cantidad").Value)
            .c_prec_unit = Val(Dgv01.Rows(Fila).Cells("Precio").Value)
            .c_imp_total = Val(Dgv01.Rows(Fila).Cells("Total").Value)
            .c_opc_transespecial = TxtOpcEspecial.Text
            .copcion = cOpcion
            ' Validamos si grabamos por primera vez '
            If Val(Dgv01.Rows(Fila).Cells("Item").Value) = 0 Then
                Dgv01.Rows(Fila).Cells("Item").Value = c_Neg_AlmTransfordet.set_AlmTransforDet_Save(c_Ent_AlmTransfordet)
            Else
                c_Neg_AlmTransfordet.set_AlmTransforDet_Save(c_Ent_AlmTransfordet)
            End If
        End With
    End Sub
    ' Grabamos Detalles de Ingresos por Transformación '
    Public Sub Grabar_Transforma_DetIng(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_AlmTransfordet
            .c_nro_correl = Dgv02.Rows(Fila).Cells("Item2").Value
            .c_nro_transforma = TxtNro_Ing.Text
            .c_tpo_mov = "ING"
            .c_codi_articulo = Dgv02.Rows(Fila).Cells("Codigo2").Value
            .c_codi_mon = Dgv02.Rows(Fila).Cells("Nick2").Value
            .c_codi_unimed = Dgv02.Rows(Fila).Cells("c_codi_unimed2").Value
            .c_nro_cant = Val(Dgv02.Rows(Fila).Cells("Cantidad2").Value)
            .c_prec_unit = Val(Dgv02.Rows(Fila).Cells("Precio2").Value)
            .c_imp_total = Val(Dgv02.Rows(Fila).Cells("Total2").Value)
            .c_opc_transespecial = TxtOpcEspecial.Text
            .copcion = cOpcion
            ' Validamos si grabamos por primera vez '
            If Val(Dgv02.Rows(Fila).Cells("Item2").Value) = 0 Then
                Dgv02.Rows(Fila).Cells("Item2").Value = c_Neg_AlmTransfordet.set_AlmTransforDet_Save(c_Ent_AlmTransfordet)
            Else
                c_Neg_AlmTransfordet.set_AlmTransforDet_Save(c_Ent_AlmTransfordet)
            End If
        End With
    End Sub
    ' Metodo para mostrar los datos '
    Private Sub Mostrar_Transforma(ByVal c_nro_transforma As String, ByVal vOpt As String)
        With c_Neg_AlmTransforCab.get_AlmTransforCab_Datos(c_nro_transforma, vOpt)
            TxtNro_Egr.Clear() : TxtNro_Ing.Clear() : TxtObs.Clear() : Dgv01.Rows.Clear() : Dgv02.Rows.Clear()
            If .Rows.Count > 0 Then
                TxtUsuaCrea.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsuaModi.Text = .Rows(0)("c_usua_modi").ToString
                TxtFechaCrea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFechaModi.Text = .Rows(0)("c_fecha_modi").ToString
                ' validate if is mannagent
                If FrmMenu.ChkAdmin.Checked = True Then
                    Pan20.Visible = False
                    BtnImprimir.Enabled = True
                    BtnVista.Enabled = True
                Else 'validate if is tranformers
                    If FrmMenu.ChkTransforma.Checked = True Then
                        If FrmMenu.lblusuario.Text = TxtUsuaCrea.Text Then
                            Pan20.Visible = False
                            BtnImprimir.Enabled = True
                            BtnVista.Enabled = True
                        Else
                            Pan20.Visible = True
                            BtnImprimir.Enabled = False
                            BtnVista.Enabled = False
                        End If
                    Else
                        Pan20.Visible = True
                        BtnImprimir.Enabled = False
                        BtnVista.Enabled = False
                    End If
                End If
                TxtBus.Text = .Rows(0)("c_nro_transforma").ToString
                TxtNro_Egr.Text = .Rows(0)("c_nro_transforma").ToString
                TxtNro_Ing.Text = .Rows(0)("c_nro_transforma").ToString
                CboAlm01.SelectedValue = .Rows(0)("c_codi_alm_sal").ToString
                CboAlm02.SelectedValue = .Rows(0)("c_codi_alm_ing").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                DtpFec_Ing.Text = .Rows(0)("c_fecha_sal").ToString
                DtpFec_Sal.Text = .Rows(0)("c_fecha_ing").ToString
                ' Validamos si registro esta anulado '
                If Val(.Rows(0)("c_anula_reg").ToString) = 1 Then
                    Pan08.Visible = True
                Else
                    Pan08.Visible = False
                End If
                ' Mostramos salidas por transformacion '
                With c_Neg_AlmTransfordet.get_AlmTransforDet_Datos(TxtBus.Text, "SAL")
                    Dgv01.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            Dgv01.Rows.Add()
                            Dgv01.Rows(I).Cells("Codigo").Value = .Rows(I)("c_codi_articulo").ToString
                            Dgv01.Rows(I).Cells("Articulo").Value = .Rows(I)("c_desc_articulo").ToString
                            Dgv01.Rows(I).Cells("Cantidad").Value = .Rows(I)("c_nro_cant").ToString
                            Dgv01.Rows(I).Cells("Precio").Value = .Rows(I)("c_prec_unit").ToString
                            Dgv01.Rows(I).Cells("Total").Value = .Rows(I)("c_imp_total").ToString
                            Dgv01.Rows(I).Cells("Unid").Value = .Rows(I)("c_desc_unimed").ToString
                            Dgv01.Rows(I).Cells("Nick").Value = .Rows(I)("c_codi_mon").ToString
                            Dgv01.Rows(I).Cells("c_codi_unimed").Value = .Rows(I)("c_codi_unimed").ToString
                            Dgv01.Rows(I).Cells("Item").Value = .Rows(I)("c_nro_correl").ToString
                            Dgv01.Rows(I).Cells("c_anula_reg").Value = .Rows(I)("c_anula_reg").ToString
                        Next
                        Call Grid_Registro_Anulado(Dgv01)
                    End If
                End With
                ' Mostramos Ingresos por transformacion '
                With c_Neg_AlmTransfordet.get_AlmTransforDet_Datos(TxtBus.Text, "ING")
                    Dgv02.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            Dgv02.Rows.Add()
                            Dgv02.Rows(I).Cells("Codigo2").Value = .Rows(I)("c_codi_articulo").ToString
                            Dgv02.Rows(I).Cells("Articulo2").Value = .Rows(I)("c_desc_articulo").ToString
                            Dgv02.Rows(I).Cells("Cantidad2").Value = .Rows(I)("c_nro_cant").ToString
                            Dgv02.Rows(I).Cells("Precio2").Value = .Rows(I)("c_prec_unit").ToString
                            Dgv02.Rows(I).Cells("Total2").Value = .Rows(I)("c_imp_total").ToString
                            Dgv02.Rows(I).Cells("Unid2").Value = .Rows(I)("c_desc_unimed").ToString
                            Dgv02.Rows(I).Cells("Nick2").Value = .Rows(I)("c_codi_mon").ToString
                            Dgv02.Rows(I).Cells("c_codi_unimed2").Value = .Rows(I)("c_codi_unimed").ToString
                            Dgv02.Rows(I).Cells("Item2").Value = .Rows(I)("c_nro_correl").ToString
                            Dgv02.Rows(I).Cells("c_anula_reg2").Value = .Rows(I)("c_anula_reg").ToString
                        Next
                        Call Grid_Registro_Anulado2(Dgv02)
                    End If
                End With
            End If
        End With
    End Sub
    ' Inicio '
    Private Sub BtnIni_Click(sender As System.Object, e As System.EventArgs) Handles BtnIni.Click
        TxtBus.Text = "0000001"
        Call Mostrar_Transforma(TxtBus.Text, "DAT")
    End Sub
    ' Final '
    Private Sub BtnFin_Click(sender As System.Object, e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_Transforma(TxtBus.Text, "FIN")
    End Sub
    ' Atras '
    Private Sub BtnAtr_Click(sender As System.Object, e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBus.Text) > 0 Then
            If Val(TxtBus.Text) > 1 Then
                TxtBus.Text = Strings.Right((Val(TxtBus.Text) - 1) + 10000000, 7)
                Call Mostrar_Transforma(TxtBus.Text, "DAT")
            End If
        End If
    End Sub
    ' Adelante '
    Private Sub BtnAva_Click(sender As System.Object, e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBus.Text) > 0 Then
            TxtBus.Text = Strings.Right((Val(TxtBus.Text) + 1) + 10000000, 7)
            Call Mostrar_Transforma(TxtBus.Text, "DAT")
        End If
    End Sub
    ' Editamos Registro '
    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        If ValidarCierre(DtpFec_Sal.Text) = True Then
            If Pan08.Visible = True Then
                MsgBox("Registro se encuentra Anulado...", vbCritical, Compañia)
            Else
                Call Nuevo_Ingreso() : CboAlm01.Enabled = False : CboAlm02.Enabled = False
                DtpFec_Ing.Enabled = False : DtpFec_Sal.Enabled = False : BtnAdd.Focus()
            End If
        End If
    End Sub
    ' Eliminamos Registro '
    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminar.Click
        If ValidarCierre(DtpFec_Sal.Text) = True Then
            If Pan08.Visible = False Then
                If Val(TxtNro_Egr.Text) > 0 Then
                    Dim F As String = MsgBox("¿Desea Eliminar El Registro?...", vbYesNo + vbQuestion, Compañia)
                    If F = vbYes Then
                        Call Grabar_Transforma_Cab("DEL")
                        ' Grabamos la salida por transformacion '
                        With Dgv01
                            For I = 0 To .RowCount - 1
                                Call Grabar_Transforma_DetSal(I, "DEL")
                            Next
                        End With
                        ' Grabamos la ingreso por transformacion '
                        With Dgv02
                            For I = 0 To .RowCount - 1
                                Call Grabar_Transforma_DetIng(I, "DEL")
                            Next
                        End With
                        MsgBox("Registro se elimino Correctamente...", vbExclamation, Compañia)
                    End If
                Else
                    MsgBox(" No existen Registro por Eliminar...", vbYesNo + vbQuestion, Compañia)
                End If
            Else
                MsgBox(" Registro se encuentra Anulado, no puede ser eliminado...", vbCritical, Compañia)
            End If
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registro_Anulado(Dgv01)
    End Sub

    Private Sub Dgv02_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv02.CellContentClick

    End Sub

    Private Sub Dgv02_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv02.ColumnHeaderMouseClick
        Call Grid_Registro_Anulado(Dgv02)
    End Sub
    ' Eliminamos Detalle '
    Private Sub BtnDel_Click(sender As System.Object, e As System.EventArgs) Handles BtnDel.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("Item").Value) = 0 Then
                        .Rows.RemoveAt(Fila) : Call Calcular_Totales()
                    Else
                        MsgBox("Registro se grabo correctamente, no puede ser eliminado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    ' Eliminamos Registro del ingreso por Transformacion
    Private Sub BtnDel2_Click(sender As System.Object, e As System.EventArgs) Handles BtnDel2.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("Item2").Value) = 0 Then
                        .Rows.RemoveAt(Fila)
                    Else
                        MsgBox("Registro se grabo correctamente, no puede ser modificado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    ' Impresión de Transformación '
    Private Sub BtnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles BtnImprimir.Click
        FrmReportes.Impresion_transforma(TxtNro_Egr.Text)
    End Sub
    ' Vista Preliminar '
    Private Sub BtnVista_Click(sender As System.Object, e As System.EventArgs) Handles BtnVista.Click
        FrmReportes.Impresion_transforma(TxtNro_Egr.Text)
    End Sub

    Private Sub CboAlm02_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboAlm02.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboAlm02_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboAlm02.SelectedIndexChanged

    End Sub

    Private Sub TxtBus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus.Text) > 0 Then
                TxtBus.Text = Strings.Right(Val(TxtBus.Text) + 10000000, 7)
            End If
            Call Mostrar_Transforma(TxtBus.Text, "DAT")
        End If
    End Sub

    Private Sub TxtBus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus.TextChanged

    End Sub
End Class