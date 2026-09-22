Public Class FrmLeasing
    Dim focos As Integer = 0
    ' funcion para grabar registros '
    Private Function ValidarDatos() As Boolean
        If CboMon.SelectedIndex > -1 Then
            If Len(TxtCodProve.Text) > -1 Then
                If CboTpoDoc.SelectedIndex > -1 Then
                    If Len(TxtNro_Credito.Text) > 0 Then
                        If Val(TxtTotal.Text) > 0 Then
                            ValidarDatos = True
                        Else
                            ValidarDatos = False
                            MsgBox("1. Falta ingresar el importe del crédito", vbCritical, Compañia)
                        End If
                    Else
                        ValidarDatos = False
                        MsgBox("2. Falta ingresar el número de crédito", vbCritical, Compañia)
                    End If
                Else
                    ValidarDatos = False
                    MsgBox("3. Falta seleccionar el tipo de operación", vbCritical, Compañia)
                End If
            Else
                ValidarDatos = False
                MsgBox("4. Falta seleccionar el tipo de proveedor", vbCritical, Compañia)
            End If
        Else
            ValidarDatos = False
            MsgBox("5. Falta seleccionar la moneda", vbCritical, Compañia)
        End If
    End Function
    ' Metodo grabar numero de leasing '
    Private Function ValidarNroDoc() As Boolean
        '  InputBox("", "", " and L.c_nro_credito='" & TxtNro_Credito.Text & "' and L.c_codi_prov='" & CboProve.SelectedValue & "' " _
        '                                                & "and L.c_codi_doc='" & CboTpoDoc.SelectedValue & "' and L.c_anula_reg=0 ")
        With c_Neg_LeasingCab.get_LeasingCab_Datos(" and L.c_nro_Serie='" & TxtSerie_Credito.Text & "' and L.c_nro_credito='" & TxtNro_Credito.Text & "' and L.c_codi_prov='" & TxtCodProve.Text & "' " _
                                                       & "and L.c_codi_doc='" & CboTpoDoc.SelectedValue & "' and L.c_anula_reg=0 ", "DAT")
            If Val(TxtNro_Mov.Text) > 0 Then
                If .Rows.Count > 1 Then
                    ValidarNroDoc = False
                    MsgBox("1. Nro. de Crédito ya fue ingresado anteriormente... Revisar", vbCritical, Compañia)
                Else
                    ValidarNroDoc = True
                End If
            Else
                If .Rows.Count > 0 Then
                    ValidarNroDoc = False
                    MsgBox("2. Nro. de Crédito ya fue ingresado anteriormente... Revisar", vbCritical, Compañia)
                Else
                    ValidarNroDoc = True
                End If
            End If
        End With
    End Function
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If ValidarDatos() = True Then
                If ValidarNroDoc() = True Then
                    Dim F As String = MsgBox("¿Desea Grabar el Leasing?", vbYesNo + MsgBoxStyle.Question, Compañia)
                    If F = vbYes Then
                        Call Grabar_LeasingCab("ADD")
                        If Val(TxtNro_Mov.Text) > 0 Then
                            With Dgv01
                                For i = 0 To .RowCount - 1
                                    If Val(.Rows(i).Cells("Anula").Value) = 0 Then
                                        Call Grabar_LeasingDet(i, "ADD")
                                    Else
                                        Call Grabar_LeasingDet(i, "DEL")
                                    End If
                                Next
                            End With
                            Call BtnCerrar_Click(Nothing, Nothing)
                            MsgBox("Registro se grabo correctamente...", vbExclamation, Compañia)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    'metodo para grabar '
    Private Sub Grabar_LeasingCab(ByVal cOpcion As String)
        With c_Ent_LeasingCab
            .c_nro_operacion = TxtNro_Mov.Text
            .c_fecha_emision = DtpFec_Emi.Text
            .c_codi_prove = TxtCodProve.Text
            .c_nro_serie = TxtSerie_Credito.Text
            .c_nro_credito = TxtNro_Credito.Text
            .c_codi_mon = CboMon.SelectedValue
            .c_codi_doc = CboTpoDoc.SelectedValue
            .c_nro_cuotas = Val(TxtNr_Cuotas.Text)
            .c_imp_total = Val(TxtTotal.Text)
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .cOpcion = cOpcion
            If Len(TxtNro_Mov.Text) = 0 Then
                TxtNro_Mov.Text = c_Neg_LeasingCab.set_Leasing_Save(c_Ent_LeasingCab)
            Else
                c_Neg_LeasingCab.set_Leasing_Save(c_Ent_LeasingCab)
            End If
        End With
    End Sub
    'metodo para grabar '
    Private Sub Grabar_LeasingDet(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_LeasingDet
            .c_nro_correl = Dgv01.Rows(Fila).Cells("Item").Value
            .c_nro_operacion = TxtNro_Mov.Text
            .c_nro_cuota = Val(Dgv01.Rows(Fila).Cells("Nro").Value)
            .c_fecha_venci = Dgv01.Rows(Fila).Cells("Vcto").Value
            .c_imp_capital = Val(Dgv01.Rows(Fila).Cells("Capital").Value)
            .c_imp_principal = Val(Dgv01.Rows(Fila).Cells("Principal").Value)
            .c_imp_interes = Val(Dgv01.Rows(Fila).Cells("Interes").Value)
            .c_imp_igv = Val(Dgv01.Rows(Fila).Cells("Igv").Value.ToString)
            .c_imp_total = Val(Dgv01.Rows(Fila).Cells("TotPagar").Value)
            .c_usuario = FrmMenu.lblusuario.Text
            .cOpcion = cOpcion
            ' Validamos registro '
            If Val(Dgv01.Rows(Fila).Cells("Item").Value) = 0 Then
                Dgv01.Rows(Fila).Cells("Item").Value = c_Neg_LeasingDet.set_LeasingDet_Save(c_Ent_LeasingDet)
            Else
                c_Neg_LeasingDet.set_LeasingDet_Save(c_Ent_LeasingDet)
            End If
        End With
    End Sub

    Private Sub FrmLeasing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F2 Then
            If BtnGrabar.Enabled = False Then
                If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
                    If CboTpoDoc.SelectedValue = "17" Then
                        Call CargarCancelacionCuotas()
                    Else
                        MsgBox("1. Solo se puede aplicar cancelaciones cuando el tipo de documento sea Prestamos...", vbCritical, Compañia)
                    End If
                Else
                    MsgBox("2. Registro debe estar en modo amortizado o cancelado...", vbCritical, Compañia)
                End If
            Else
                MsgBox("3. Para cancelar cuotas registro debe estar grabado...", vbCritical, Compañia)
            End If
        End If
    End Sub
    Private Sub CargarCancelacionCuotas()
        With Dgv01
            If .RowCount > 0 Then
                Dim F As Integer = .CurrentCellAddress.Y
                If F > -1 Then
                    FrmLeasingCancel.Close()
                    FrmLeasingCancel.MdiParent = FrmMenu : FrmLeasingCancel.Show()
                    With FrmLeasingCancel
                        .TxtNroMov.Text = TxtNro_Mov.Text
                        .TxtProveedor.Text = TxtProve.Text
                        .TxtSerie_Credito.Text = TxtSerie_Credito.Text
                        .TxtNro_Credito.Text = TxtNro_Credito.Text
                        .TxtNroCuota.Text = Dgv01.Rows(F).Cells("Nro").Value
                        .TxtNroCorrel.Text = Dgv01.Rows(F).Cells("Item").Value
                        ' Validamos si ya existe un numero registrado '
                        If Len(Dgv01.Rows(F).Cells("Doc").Value) > 0 Then
                            FrmLeasingCancel.CargarBancosCancelacion(Dgv01.Rows(F).Cells("Doc").Value, "DEL")
                            .CboVoucher.Enabled = False
                            .BtnEliminar.Enabled = True
                            .BtnGrabar.Enabled = False
                        Else
                            FrmLeasingCancel.CargarBancosCancelacion(" and I.c_nro_CREDITO='" & TxtNro_Credito.Text & "' and I.c_nro_serie='" & TxtSerie_Credito.Text & "'" &
                                       "  and P.c_codi_prov='" & TxtCodProve.Text &
                                       "' order by P.c_fecha_pago", "ING")
                            .CboVoucher.Enabled = True
                            .BtnEliminar.Enabled = False
                            .BtnGrabar.Enabled = True
                        End If
                    End With
                End If
            End If
        End With


    End Sub
    Private Sub FrmLeasing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmLeasing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnMoneda.Get_Moneda_Cbo(" AND c_anula_reg=0 order by c_codi_mon", CboMon)
        c_Neg_MnTpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0 and c_opt_leasing=1 order by c_desc_doc", CboTpoDoc)
        Me.Location = New Point(10, 10) : Dgv02.Rows.Add() : Call BtnFin_Click(Nothing, Nothing)
        ' no se podra ordenar por cabecera '
        With Dgv01
            For i = 0 To .ColumnCount - 1
                .Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
        End With

    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : TxtNro_Credito.Focus() : CboMon.SelectedIndex = -1 : DtpFec_Emi.Text = Now.Date
        Dgv01.Rows.Clear() : TxtSerie.Focus() : BtnEstado.Text = "Pendiente" : BtnEstado.BackColor = Color.Maroon
        Dgv02.Rows(0).Cells("SubTotal").Value = "0.00" : CboMon.Enabled = True : CboTpoDoc.Enabled = True : CboMon.Focus()
        CboMon.SelectedIndex = 0 : BtnCon1_Click(Nothing, Nothing)
    End Sub
    Private Sub Nuevo_Registro()
        Call Limpiar_Texto(Pan01) : Call Activar(Pan01) : TxtNro_Mov.Enabled = False : TxtUsua_Crea.Enabled = False
        TxtUsua_Modi.Enabled = False : TxtFecha_Crea.Enabled = False : TxtFecha_Modi.Enabled = False
        BtnCerrar.Text = "&Cancelar" : BtnGrabar.Enabled = True : Pan03.Enabled = False : TxtNro_Mov.Enabled = False
        Pan09.Enabled = True : Pan10.Enabled = False : Call Limpiar_Texto(Pan08) : BtnCon1.Enabled = True : DtpFec_Emi.Enabled = True
        Pan02.Enabled = False : TxtCodProve.Enabled = False : TxtProve.Enabled = False
    End Sub
    Private Sub Cancelar_Registro()
        Call Desactivar(Pan01) : BtnCerrar.Text = "&Cerrar" : BtnGrabar.Enabled = False : Pan03.Enabled = True
        Pan09.Enabled = False : BtnCon1.Enabled = False : CboMon.Enabled = False : DtpFec_Emi.Enabled = False
        CboTpoDoc.Enabled = False : Pan02.Enabled = True
    End Sub
    ' Cerramos ventana '
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            If Len(TxtNro_Mov.Text) = 0 Then
                Call BtnFin_Click(Nothing, Nothing)
            Else
                Call Mostrar_Leasing(" and c_nro_operacion='" & TxtNro_Mov.Text & "' ")
            End If
        End If
    End Sub
    ' Validamos si hay número de cuotas '
    Private Sub TxtNr_Cuotas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNr_Cuotas.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtNr_Cuotas.Text) > 0 Then
                If Val(TxtNr_Cuotas.Text) > 100 Then
                    MsgBox("No se aceptan mas de 100 cuotas...", vbCritical, Compañia)
                Else
                    Dgv01.Rows.Clear()
                    For i = 0 To Val(TxtNr_Cuotas.Text) - 1
                        Dgv01.Rows.Add()
                        Dgv01.Rows(i).Cells("Nro").Value = i + 1
                        Dgv01.Rows(i).Cells("Vcto").Value = FormatDateTime(DateAdd("m", i, DtpFec_Emi.Text), DateFormat.ShortDate)
                        Dgv01.Rows(i).Cells("TotPagar").Value = "0.00"
                        Dgv01.Rows(i).Cells("Estado").Value = "PENDIENTE"
                        ' Columnas vacias '
                        Dgv01.Rows(i).Cells("Capital").Value = ""
                        Dgv01.Rows(i).Cells("Principal").Value = ""
                        Dgv01.Rows(i).Cells("Interes").Value = ""
                        Dgv01.Rows(i).Cells("Igv").Value = ""
                        Dgv01.Rows(i).Cells("Serie").Value = ""
                        Dgv01.Rows(i).Cells("Doc").Value = ""
                        Dgv01.Rows(i).Cells("Item").Value = ""
                        Dgv01.Rows(i).Cells("Anula").Value = ""
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub TxtNr_Cuotas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNr_Cuotas.TextChanged

    End Sub

    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Call Nuevo_Detalles() : DtpFec_Emi.Focus()
    End Sub
    ' metodo para nuevo detalle '
    Private Sub Nuevo_Detalles()
        With Dgv01
            .Size = New Size(806, 268) : .Location = New Point(0, 198)
        End With
        Call Limpiar_Texto(Pan07) : Pan07.Enabled = True : Pan09.Enabled = False : Pan10.Enabled = True
    End Sub
    ' metodo para cancelar detalle '
    Private Sub Cancelar_Detalles()
        With Dgv01
            .Size = New Size(806, 300) : .Location = New Point(0, 166)
        End With
        Call Limpiar_Texto(Pan07) : Pan07.Enabled = False : Pan09.Enabled = True : Pan10.Enabled = False
    End Sub
    ' Cancelamos detalles '
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call Cancelar_Detalles()
    End Sub
    ' editamos registro '
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("anula").Value) = 0 Then
                        ' Validamos si ya se recibio cancelaciones '
                        If Val(.Rows(Fila).Cells("c_opc_cancel").Value) = 0 Then
                            ' Validamos si ya se ingreso documentos....
                            If Val(.Rows(Fila).Cells("c_opc_doc").Value) = 0 Then
                                Call Nuevo_Detalles() : Call Mostrar_Detalles(Fila) : DtpVcto.Focus()
                            Else
                                MsgBox("Cuota ya tiene documento ingresado...", vbCritical, Compañia)
                            End If
                        Else
                            MsgBox("Cuota ya fue cancelada...", vbCritical, Compañia)
                        End If
                    Else
                        MsgBox("Registro se encuentra anulado... no podra realizar ninguna modificación...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    ' metodo para mostrar detalles '
    Private Sub Mostrar_Detalles(ByVal Fila As Integer)
        With Dgv01
            TxtCuota.Text = .Rows(Fila).Cells("Nro").Value
            DtpVcto.Text = .Rows(Fila).Cells("Vcto").Value
            TxtCapital.Text = .Rows(Fila).Cells("Capital").Value
            TxtPrincipal.Text = .Rows(Fila).Cells("Principal").Value
            TxtInteres.Text = .Rows(Fila).Cells("Interes").Value
            TxtIgv.Text = .Rows(Fila).Cells("Igv").Value
            TxtTot_Cuota.Text = .Rows(Fila).Cells("TotPagar").Value
            TxtEstado.Text = .Rows(Fila).Cells("Estado").Value
            TxtSerie.Text = .Rows(Fila).Cells("Serie").Value
            TxtNro_Doc.Text = .Rows(Fila).Cells("Doc").Value
        End With
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Call Aceptar_Detalles(Fila) : Call Cancelar_Detalles() : Dgv01.Focus()
                    'Dgv01.CurrentCell = Dgv01.Rows(Dgv01.RowCount - 1).Cells(0)
                    Call Calcular_Total_Cuotas()
                End If
            End If
        End With
    End Sub
    ' metodo para aceptar detalles'
    Private Sub Aceptar_Detalles(ByVal Fila As Integer)
        With Dgv01
            .Rows(Fila).Cells("Nro").Value = TxtCuota.Text
            .Rows(Fila).Cells("Vcto").Value = DtpVcto.Text
            .Rows(Fila).Cells("Capital").Value = Format(Val(TxtCapital.Text), Forma_1_2)
            .Rows(Fila).Cells("Principal").Value = Format(Val(TxtPrincipal.Text), Forma_1_2)
            .Rows(Fila).Cells("Interes").Value = Format(Val(TxtInteres.Text), Forma_1_2)
            .Rows(Fila).Cells("Igv").Value = Format(Val(TxtIgv.Text), Forma_1_2)
            .Rows(Fila).Cells("Totpagar").Value = Format(Val(TxtTot_Cuota.Text), Forma_1_2)
            .Rows(Fila).Cells("Estado").Value = TxtEstado.Text
            .Rows(Fila).Cells("Serie").Value = TxtSerie.Text
            .Rows(Fila).Cells("Doc").Value = TxtNro_Doc.Text
        End With
    End Sub
    ' Editamos registro '
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If UCase(BtnEstado.Text) = "PENDIENTE" Then
                Pan09.Enabled = True : TxtNr_Cuotas.Enabled = False : BtnCon1.Enabled = False : BtnGrabar.Enabled = True
                BtnCerrar.Text = "&Cancelar" : Pan03.Enabled = False : CboMon.Enabled = False : TxtTotal.Enabled = True
                DtpFec_Emi.Enabled = True : TxtObs.Enabled = True
            Else
                MsgBox("Registro se encuentra anulado no podra realizar ninguna modifiación...", vbCritical, Compañia)
            End If
        End If
    End Sub

    Private Sub TxtIgv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtIgv.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnAceptar_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtIgv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtIgv.TextChanged
        Call Calcular_Totales()
    End Sub

    Private Sub TxtCapital_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCapital.TextChanged
        Call Calcular_Totales()
    End Sub
    ' metodo para calcular total pago cuota '
    Private Sub Calcular_Totales()
        TxtTot_Cuota.Text = Format(Val(TxtCapital.Text) + Val(TxtPrincipal.Text) + Val(TxtIgv.Text) + Val(TxtInteres.Text), Forma_1_2)
    End Sub

    Private Sub TxtPrincipal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrincipal.TextChanged
        Call Calcular_Totales()
    End Sub

    Private Sub TxtInteres_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtInteres.TextChanged
        Call Calcular_Totales()
    End Sub
    ' Eliminamos registro '
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("anula").Value) = 0 Then
                        ' Validamos si ya se recibio cancelaciones '
                        If Val(.Rows(Fila).Cells("c_opc_cancel").Value) = 0 Then
                            ' Validamos si ya se ingreso documentos....
                            If Val(.Rows(Fila).Cells("c_opc_doc").Value) = 0 Then
                                Dim F As String = MsgBox("¿Desea eliminar el registro?", vbQuestion + vbYesNo, Compañia)
                                If F = vbYes Then
                                    If Val(.Rows(Fila).Cells("Item").Value) = 0 Then
                                        Dgv01.Rows.RemoveAt(Fila)
                                    Else
                                        Dgv01.Rows(Fila).DefaultCellStyle.BackColor = Color.Gainsboro
                                        Dgv01.Rows(Fila).Cells("Anula").Value = 1
                                    End If
                                End If
                            Else
                                MsgBox("Cuota ya tiene documento ingresado...", vbCritical, Compañia)
                            End If
                        Else
                            MsgBox("Documento ya fue cancelado...", vbCritical, Compañia)
                        End If
                    Else

                    End If
                    
                End If
                End If
        End With
    End Sub
    ' Inicio 
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_Leasing(" and c_nro_operacion=(select min(c_nro_operacion) from scom_LeasingCab) ")
    End Sub
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBuscar.Text) > 1 Then
            TxtBuscar.Text = Strings.Right((Val(TxtBuscar.Text) - 1) + 10000000, 7)
            Call Mostrar_Leasing(" and  c_nro_operacion='" & TxtBuscar.Text & "' ")
        End If
    End Sub
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBuscar.Text) > 0 Then
            TxtBuscar.Text = Strings.Right(Val(TxtBuscar.Text) + 10000001, 7)
            Call Mostrar_Leasing(" and c_nro_operacion='" & TxtBuscar.Text & "' ")
        End If
    End Sub
    Private Sub TxtBuscar_Lote_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBuscar.Text) > 0 Then
                TxtBuscar.Text = Strings.Right(Val(TxtBuscar.Text) + 10000000, 7)
                Call Mostrar_Leasing(" and  c_nro_operacion='" & TxtBuscar.Text & "' ")
            End If
        End If
    End Sub
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_Leasing(" and c_nro_operacion=(select max(c_nro_operacion) from scom_LeasingCab) ")
    End Sub
    ' metodo para mostrar leasing
    Public Sub Mostrar_Leasing(ByVal Cadena As String)
        With c_Neg_LeasingCab.get_LeasingCab_Datos(Cadena, "DAT")
            Call Cancelar_Registro() : Call Cancelar_Detalles() : Pan09.Enabled = False
            Dgv01.Rows.Clear() : Call Limpiar_Texto(Pan01)
            If .Rows.Count > 0 Then
                TxtBuscar.Text = .Rows(0)("c_nro_operacion").ToString
                TxtNro_Mov.Text = .Rows(0)("c_nro_operacion").ToString
                TxtCodProve.Text = .Rows(0)("c_codi_prov").ToString
                TxtProve.Text = .Rows(0)("c_desc_prov").ToString
                CboMon.SelectedValue = .Rows(0)("c_Codi_mon").ToString
                TxtSerie_Credito.Text = .Rows(0)("c_nro_serie").ToString
                TxtNro_Credito.Text = .Rows(0)("c_nro_credito").ToString
                DtpFec_Emi.Text = .Rows(0)("c_fecha_emision").ToString
                TxtNr_Cuotas.Text = .Rows(0)("c_nro_cuotas").ToString
                TxtTotal.Text = Format(Val(.Rows(0)("c_imp_total").ToString), Forma_1_2)
                TxtObs.Text = .Rows(0)("c_obs").ToString
                TxtUsua_Crea.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_Modi.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                CboTpoDoc.SelectedValue = .Rows(0)("c_codi_doc").ToString
                If Val(.Rows(0)("c_anula_reg").ToString) = 1 Then
                    BtnEstado.Text = "Anulado" : BtnEstado.BackColor = Color.Red : BtnEstado.ForeColor = Color.White
                Else
                    If Val(.Rows(0)("c_opc_cancel").ToString) = 0 Then
                        If Val(.Rows(0)("c_opc_doc").ToString) = 1 Then
                            BtnEstado.Text = "Ingresado" : BtnEstado.BackColor = Color.SteelBlue : BtnEstado.ForeColor = Color.White
                        Else
                            BtnEstado.Text = "Pendiente" : BtnEstado.BackColor = Color.Maroon : BtnEstado.ForeColor = Color.White
                        End If
                    Else
                        If Val(.Rows(0)("c_opc_cancel").ToString) = 1 Then
                            BtnEstado.Text = "Cancelado" : BtnEstado.BackColor = Color.Blue : BtnEstado.ForeColor = Color.White
                        Else
                            BtnEstado.Text = "Amortizado" : BtnEstado.BackColor = Color.SteelBlue : BtnEstado.ForeColor = Color.White
                        End If
                    End If
                End If
                With c_Neg_LeasingDet.get_LeasingDet_Datos(" and D.c_nro_operacion='" & TxtNro_Mov.Text & "' order by c_nro_cuota", "DAT")
                    Dgv01.Rows.Clear()
                    For i = 0 To .Rows.Count - 1
                        Dgv01.Rows.Add()
                        Dgv01.Rows(i).Cells("Nro").Value = Val(.Rows(i)("c_nro_cuota").ToString)
                        Dgv01.Rows(i).Cells("Vcto").Value = FormatDateTime(.Rows(i)("c_fecha_venci").ToString, DateFormat.ShortDate)
                        Dgv01.Rows(i).Cells("Capital").Value = Format(Val(.Rows(i)("c_imp_capital").ToString), Forma_1_2)
                        Dgv01.Rows(i).Cells("Principal").Value = Format(Val(.Rows(i)("c_imp_principal").ToString), Forma_1_2)
                        Dgv01.Rows(i).Cells("Interes").Value = Format(Val(.Rows(i)("c_imp_interes").ToString), Forma_1_2)
                        Dgv01.Rows(i).Cells("Igv").Value = Format(Val(.Rows(i)("c_imp_igv").ToString), Forma_1_2)
                        Dgv01.Rows(i).Cells("TotPagar").Value = Format(Val(.Rows(i)("c_imp_total").ToString), Forma_1_2)
                        'Validamos estado cuota '
                        If Val(.Rows(i)("c_opc_cancel").ToString) = 0 Then
                            Dgv01.Rows(i).Cells("Estado").Value = "PENDIENTE"
                        Else
                            Dgv01.Rows(i).Cells("Estado").Value = "CERRADO"
                        End If
                        Dgv01.Rows(i).Cells("Serie").Value = .Rows(i)("c_serie_doc").ToString
                        Dgv01.Rows(i).Cells("Doc").Value = .Rows(i)("c_nro_doc").ToString
                        Dgv01.Rows(i).Cells("Item").Value = .Rows(i)("c_nro_correl").ToString
                        Dgv01.Rows(i).Cells("Anula").Value = Val(.Rows(i)("c_anula_reg").ToString)
                        Dgv01.Rows(i).Cells("c_opc_cancel").Value = Val(.Rows(i)("c_opc_cancel").ToString)
                        Dgv01.Rows(i).Cells("c_opc_doc").Value = Val(.Rows(i)("c_opc_doc").ToString)
                        If Val(Dgv01.Rows(i).Cells("Anula").Value) = 1 Then
                            Dgv01.Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                        End If
                    Next
                End With

                ' Calculamos los totales '
                Call Calcular_Total_Cuotas()
            End If
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        If Pan09.Enabled = True Then Call BtnEdit_Click(Nothing, Nothing)
    End Sub

    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call Dgv01_DoubleClick(Nothing, Nothing) : e.Handled = True
        End If

    End Sub

    Private Sub Dgv01_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.LostFocus
        If focos = 1 Then
            focos = 0 : Dgv01.Focus()
        End If
    End Sub
    ' eliminamos registro '
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If UCase(BtnEstado.Text) = "PENDIENTE" Then
                Dim F As String = MsgBox("¿Desea eliminar registro?", vbYesNo + vbQuestion, Compañia)
                If F = vbYes Then
                    Call Grabar_LeasingCab("DEL") : BtnEstado.Text = "Anulado" : BtnEstado.BackColor = Color.Red
                End If
            Else
                MsgBox("Registro no puede ser eliminado", vbCritical, Compañia)
            End If
        End If
    End Sub
    ' metodo para calcular los totales '
    Private Sub Calcular_Total_Cuotas()
        With Dgv01
            Dim Total_pagar As Decimal
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("Anula").Value) = 0 Then
                    Total_pagar = Format(Total_pagar + Val(.Rows(i).Cells("TotPagar").Value), Forma_1_2)
                End If
            Next
            Dgv02.Rows(0).Cells("SubTotal").Value = Format(Total_pagar, Forma_2_2)
            Dgv02.Rows(0).Cells("Titulo").Value = "Total"
        End With
    End Sub

    Private Sub LnkHistorial_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkHistorial.LinkClicked
        If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
            FrmConHistoCancel.MdiParent = FrmMenu : FrmConHistoCancel.Show()
            ' 14=Pagares 17=Prestamos 18=Otros financiamientos 
            If CboTpoDoc.SelectedValue = "14" Or CboTpoDoc.SelectedValue = "17" Or CboTpoDoc.SelectedValue = "18" Then
                FrmConHistoCancel.Cargar_Grid(" and I.c_nro_CREDITO='" & TxtNro_Credito.Text & "' and I.c_nro_serie='" & TxtSerie_Credito.Text & "'" &
                                         "  and P.c_codi_prov='" & TxtCodProve.Text &
                                         "' order by P.c_fecha_pago", "LES")
            Else
                FrmConHistoCancel.Cargar_Grid(" and I.c_nro_leasing='" & TxtNro_Mov.Text &
                                                         "' and P.c_codi_mon='" & CboMon.SelectedValue & "' and P.c_codi_prov='" & TxtCodProve.Text &
                                                         "' order by P.c_fecha_pago", "ING")
            End If
        Else
            MsgBox("1. No se registran pagos a cuenta...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub TxtBuscar_TextChanged(sender As Object, e As EventArgs) Handles TxtBuscar.TextChanged

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        FrmLeasingConsul.MdiParent = FrmMenu : FrmLeasingConsul.Show() : FrmLeasingConsul.TxtVar.Text = 1
    End Sub

    Private Sub BtnCon1_Click(sender As Object, e As EventArgs) Handles BtnCon1.Click
        FrmConProve.MdiParent = FrmMenu : FrmConProve.Show()
        FrmConProve.TxtVar.Text = 12
        FrmConProve.Cargar_Grid(" and c_anula_reg=0 order by c_desc_prov")
    End Sub
End Class