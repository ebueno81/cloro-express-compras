Public Class FrmDetracAnexas
    Dim vEditar As Integer = 0 ' Variable que nos permite saber si se esta editando o no la detraccion '
    Private Sub BtnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro()
        End If
    End Sub

    Private Sub FrmDetracAnexas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FrmIngComp.Mostrar_IngComp(" and c_nro_ing='" & FrmIngComp.TxtBus_Ing.Text & "'")
    End Sub
    ' Cerramos ventana '
    Private Sub FrmDetracAnexas_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    ' Avanzamos presionando la tecla enter '
    Private Sub FrmDetracAnexas_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmDetracAnexas_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    ' Metodo para cargar grid de detracciones '
    Public Sub Detracciones_Anexadas(ByVal c_nro_ing As String)
        ' Cargamos detalle de detraccion '
        With c_Neg_DetracDet.get_DetracDet_Datos(" and I.c_nro_ing='" & c_nro_ing & "' AND D.c_anula_reg=0 ")
            Dgv01.Rows.Clear()
            TxtNro_Ing.Text = c_nro_ing
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    Dgv01.Rows.Add()
                    'Dgv01.Rows(i).Cells("Tipo").Value = .Rows(i)("Tipo").ToString
                    Dgv01.Rows(i).Cells("Documento").Value = .Rows(i)("c_serie_doc").ToString & "-" & .Rows(i)("c_nro_doc").ToString
                    'Dgv01.Rows(i).Cells("Cliente").Value = .Rows(i)("Cliente").ToString
                    Dgv01.Rows(i).Cells("Porc").Value = Format(Val(.Rows(i)("c_porc_detracc").ToString), Forma_1_1)
                    Dgv01.Rows(i).Cells("Total_Us").Value = Format(Val(.Rows(i)("c_monto_us").ToString), Forma_1_2)
                    Dgv01.Rows(i).Cells("Detraccion_us").Value = Format(Val(.Rows(i)("c_detracc_us").ToString), Forma_1_2)
                    Dgv01.Rows(i).Cells("Tc").Value = Format(Val(.Rows(i)("c_tpo_cambio").ToString), Forma_1_3)
                    Dgv01.Rows(i).Cells("Total_Mn").Value = Format(Val(.Rows(i)("c_monto_mn").ToString), Forma_1_2)
                    Dgv01.Rows(i).Cells("Detraccion_mn").Value = Format(Val(.Rows(i)("c_detracc_mn").ToString), Forma_1_2)
                    Dgv01.Rows(i).Cells("c_ruc_prove").Value = .Rows(i)("c_ruc_prov").ToString
                    Dgv01.Rows(i).Cells("c_codi_det").Value = .Rows(i)("c_codi_detracc").ToString
                    Dgv01.Rows(i).Cells("c_codi_prove").Value = .Rows(i)("c_codi_prov").ToString
                    Dgv01.Rows(i).Cells("c_codi_doc").Value = .Rows(i)("c_codi_doc").ToString
                    Dgv01.Rows(i).Cells("Fecha").Value = FormatDateTime(.Rows(i)("c_Fecha_emi").ToString, DateFormat.ShortDate)
                    Dgv01.Rows(i).Cells("c_fecha_cancel").Value = FormatDateTime(.Rows(i)("c_fecha_cancel").ToString, DateFormat.ShortDate)
                    Dgv01.Rows(i).Cells("c_nro_constancia").Value = .Rows(i)("c_nro_constancia").ToString
                    Dgv01.Rows(i).Cells("item").Value = .Rows(i)("c_nro_correl").ToString
                    Dgv01.Rows(i).Cells("c_opc_cancel").Value = Val(.Rows(i)("c_opc_cancel").ToString)
                Next
            End If
        End With
    End Sub
    ' METODO PARA CARGAR LAS DETRACCIONES ANEXADAS
    Public Sub Mostrar_Detracciones(ByVal c_nro_ing As String)
        With c_Neg_IngComp.get_IngComp_Datos(" and I.c_afecto_detracc=1 and I.c_codi_doc in('01','04') and I.c_anula_reg=0 and I.c_detracc_emi=0 " & _
                                                 " and I.c_cancel_detracc=0 and I.c_nro_ing='" & c_nro_ing & "' ", "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                Dim Importe_Us As Decimal = 0 : Dim Importe_Mn As Decimal = 0
                Dim Detracc_Us As Decimal = 0 : Dim Detracc_Mn As Decimal = 0

                If .Rows(0)("c_codi_mon").ToString = "02" Then
                    Importe_Us = Format(Val(.Rows(0)("c_imp_total").ToString), Forma_1_2)
                    Importe_Mn = Format(Val(.Rows(0)("c_imp_total").ToString) * Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_2)
                    Detracc_Us = Format(Val(.Rows(0)("c_imp_total").ToString) * (Val(.Rows(0)("c_porc_detracc").ToString) / 100), Forma_1_2)
                    Detracc_Mn = Format((Val(.Rows(0)("c_imp_total").ToString) * (Val(.Rows(0)("c_porc_detracc").ToString) / 100)) * Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_2)
                Else
                    Importe_Mn = Format(Val(.Rows(0)("c_imp_total").ToString), Forma_1_2)
                    Importe_Us = Format(Val(.Rows(0)("c_imp_total").ToString) / Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_2)
                    Detracc_Mn = Format(Val(.Rows(0)("c_imp_total").ToString) * (Val(.Rows(0)("c_porc_detracc").ToString) / 100), Forma_1_2)
                    Detracc_Us = Format((Val(.Rows(0)("c_imp_total").ToString) * (Val(.Rows(0)("c_porc_detracc").ToString) / 100)) / Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_2)
                End If
                TxtNro_Ing.Text = .Rows(0)("c_nro_ing").ToString
                'TxtTipo.Text = .Rows(0)("c_desc_doc").ToString
                TxtCod_Doc.Text = .Rows(0)("c_codi_doc").ToString
                TxtFactura.Text = .Rows(0)("c_serie_doc").ToString & " " & .Rows(0)("c_nro_doc").ToString
                TxtFecha.Text = FormatDateTime(.Rows(0)("c_fecha_emi").ToString, DateFormat.ShortDate)
                TxtCod_Det.Text = .Rows(0)("c_codi_detracc").ToString
                'TxtRuc.Text = .Rows(0)("c_ruc_prov").ToString
                TxtTotal_Us.Text = Importe_Us
                TxtTc.Text = Format(Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_3)
                TxtTotal_Mn.Text = Importe_Mn
                TxtPorc.Text = Val(.Rows(0)("c_porc_detracc").ToString) & "%"
                TxtDetrac_Mn.Text = Detracc_Mn
                TxtDetrac_Us.Text = Detracc_Us
                TxtItem.Text = ""
                TxtConstancia.Text = ""
                DtpFec_Pago.Text = Now.Date
            End If
        End With
    End Sub
    ' Grabar nuevo registro '
    Private Sub Grabar_Detracciones_Det(ByVal cOpcion As String)
       With c_Ent_DetracDet
            .c_nro_correl = TxtItem.Text
            .c_año_lote = ""
            .c_nro_lote = ""
            .c_nro_ing = TxtNro_Ing.Text
            .c_monto_mn = Val(TxtTotal_Mn.Text)
            .c_monto_us = Val(TxtTotal_Us.Text)
            .c_tpo_cambio = Val(TxtTc.Text)
            .c_detracc_mn = Val(TxtDetrac_Mn.Text)
            .c_detracc_us = Val(TxtDetrac_Us.Text)
            .c_fecha_cancel = DtpFec_Pago.Text
            .c_nro_constancia = TxtConstancia.Text
            .copcion = cOpcion
            If Val(TxtItem.Text) = 0 Then
                TxtItem.Text = c_Neg_DetracDet.set_DetracDet_Save(c_Ent_DetracDet)
            Else
                c_Neg_DetracDet.set_DetracDet_Save(c_Ent_DetracDet)
            End If
        End With
    End Sub
    ' NUEVO ITEM
    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : vEditar = 0
        With FrmIngComp
            TxtNro_Ing.Text = .TxtCod_Ing.Text
            TxtCod_Det.Text = .CboDetrac.Text
            TxtFactura.Text = .TxtSerie.Text & "-" & .TxtNro_Doc.Text
            TxtFecha.Text = .DtpFec_Emi.Text
            TxtPorc.Text = .TxtPorcDetrac.Text
            TxtTc.Text = .TxtTC.Text
            If .CboMon.Text = "S/" Then
                TxtTotal_Us.Text = Format(Val(.TxtTotal.Text) / Val(TxtTc.Text), Forma_1_2)
                TxtDetrac_Us.Text = Format((Val(.TxtTotal.Text) * (Val(.TxtPorcDetrac.Text) / 100)) / Val(TxtTc.Text), Forma_1_2)
                TxtTotal_Mn.Text = Format(Val(.TxtTotal.Text), Forma_1_2)
                TxtDetrac_Mn.Text = Format(Val(.TxtTotal.Text) * (Val(.TxtPorcDetrac.Text) / 100), Forma_1_2)
            Else
                TxtTotal_Us.Text = .TxtTotal.Text
                TxtDetrac_Us.Text = Format(Val(.TxtTotal.Text) * (Val(.TxtPorcDetrac.Text) / 100), Forma_1_2)
                TxtTotal_Mn.Text = Format(Val(.TxtTotal.Text) * Val(TxtTc.Text), Forma_1_2)
                TxtDetrac_Mn.Text = Format((Val(.TxtTotal.Text) * Val(TxtTc.Text)) * (Val(.TxtPorcDetrac.Text) / 100), Forma_1_2)
            End If
            DtpFec_Pago.Text = .DtpFec_Emi.Text : DtpFec_Pago.Focus()
        End With
    End Sub
    ' metodo para nuevo registro '
    Public Sub Nuevo_Registro()
        With Dgv01
            .Location = New Point(1, 33) : .Size = New Size(754, 156) : Pan03.Enabled = True
            Pan01.Enabled = False : BtnGrabar.Enabled = True : BtnCerrar.Text = "&Cancelar" : TxtConstancia.Enabled = True
        End With
    End Sub
    ' metodo para cancelar registro '
    Private Sub Cancelar_Registro()
        With Dgv01
            .Location = New Point(1, 2) : .Size = New Size(754, 186) : BtnCerrar.Text = "&Cerrar"
            Pan01.Enabled = True : BtnGrabar.Enabled = False : Call Limpiar_Texto(Pan03)
        End With
    End Sub
    ' Funcion para validar si la constancia es duplicado '
    Private Function ValidarConstancia() As Boolean
        If vEditar = 0 Then
            With c_Neg_DetracDet.get_DetracDet_Datos(" and D.c_nro_constancia='" & TxtConstancia.Text & "' and D.c_anula_reg=0 ")
                If .Rows.Count > 0 Then
                    ValidarConstancia = False : MsgBox("Constancia ya fue registrada anteriormente...", vbCritical, Compañia)
                Else
                    ValidarConstancia = True
                End If
            End With
        Else
            With c_Neg_DetracDet.get_DetracDet_Datos(" and D.c_nro_constancia='" & TxtConstancia.Text & "' and D.c_anula_reg=0 ")
                If .Rows.Count = 1 Then
                    ValidarConstancia = True
                Else
                    ValidarConstancia = False : MsgBox("Constancia ya fue registrada anteriormente...", vbCritical, Compañia)
                End If
            End With
        End If
    End Function
    ' Grabar Detalles '
    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarConstancia() = True Then
            Dim F As String = MsgBox("¿Desea Grabar el Registro?", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                Call Grabar_Detracciones_Det("ADD") : Call Cancelar_Registro()
                Call Detracciones_Anexadas(FrmIngComp.TxtCod_Ing.Text)
            End If
        End If
    End Sub
    ' Editamos registro '
    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                vEditar = 1
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_opc_cancel").Value) = 0 Then
                        Call Nuevo_Registro() : Call Mostrar_Detalles(Fila) : TxtConstancia.Enabled = False
                    Else
                        MsgBox("Detracción se encuentra cancelada, no podra realizar ninguna modificación...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    ' metodo para mostrar las detracciones 
    Public Sub Mostrar_Detalles(ByVal Fila As Integer)
        With Dgv01
            If .RowCount > 0 Then
                TxtFactura.Text = .Rows(Fila).Cells("Documento").Value
                TxtFecha.Text = .Rows(Fila).Cells("Fecha").Value
                TxtTc.Text = .Rows(Fila).Cells("Tc").Value
                TxtTotal_Us.Text = .Rows(Fila).Cells("Total_Us").Value
                TxtTotal_Mn.Text = .Rows(Fila).Cells("Total_Mn").Value
                TxtDetrac_Us.Text = .Rows(Fila).Cells("Detraccion_Us").Value
                TxtDetrac_Mn.Text = .Rows(Fila).Cells("Detraccion_Mn").Value
                TxtPorc.Text = .Rows(Fila).Cells("Porc").Value
                DtpFec_Pago.Text = .Rows(Fila).Cells("c_fecha_cancel").Value
                TxtConstancia.Text = .Rows(Fila).Cells("c_nro_Constancia").Value
                TxtCod_Prove.Text = .Rows(Fila).Cells("c_codi_prove").Value
                TxtItem.Text = .Rows(Fila).Cells("Item").Value
            End If
        End With
    End Sub
    ' --> Eliminamos el registro <-- '
    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_opc_cancel").Value) = 0 Then
                        Dim F As String = MsgBox("¿Desea Eliminar el Registro?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then
                            Call BtnEditar_Click(Nothing, Nothing)
                            If Val(.Rows(Fila).Cells("Item").Value) > 0 Then
                                Call Grabar_Detracciones_Det("DEL")
                                .Rows.RemoveAt(Fila)
                            Else
                                .Rows.RemoveAt(Fila)
                            End If
                            Call Cancelar_Registro()
                        End If
                    Else
                        MsgBox("Detraccion se encuentra cancelada, no podra realizar ninguna modificación...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub TxtConstancia_TextChanged(sender As Object, e As EventArgs) Handles TxtConstancia.TextChanged

    End Sub
    ' Numero de Constancia '
    Private Sub TxtConstancia_LostFocus(sender As Object, e As EventArgs) Handles TxtConstancia.LostFocus
        If Len(TxtConstancia.Text) > 0 Then
            TxtConstancia.Text = Strings.Right("000000000000000" & TxtConstancia.Text, 15)
        End If
    End Sub
End Class