Public Class FrmIngCompDirecto

    Private Sub FrmIngCompDirecto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmIngCompDirecto_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call c_Neg_MnTpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0 order by c_desc_doc", CboDoc)
    End Sub
    'Metodo que nos permite validar que no se registre 2 veces un mismo numero de comprobante del mismo proveedor
    Private Function Validar_Grabacion() As Boolean
        With c_Neg_IngComp.get_IngComp_Datos(" and I.c_anula_reg=0 and I.c_codi_prov='" & FrmOC.txtCod_Prove.Text & "' and I.c_serie_doc='" & TxtSerie.Text & _
                                             "' and I.c_nro_doc='" & TxtNro_Doc.Text & "' and I.c_codi_doc='" & CboDoc.SelectedValue & "' ", "DAT", FrmMenu.TxtCod_Emp.Text)

            Validar_Grabacion = True
            If .Rows.Count > 0 Then
                If Val(TxtCod_Ing.Text) = 0 Then 'cuando grabamos no debe existir coincidencias...
                    If .Rows.Count > 0 Then
                        Validar_Grabacion = False
                        MsgBox("1. Factura ya fue ingresado  anteriormente, no podra ingresar la misma factura...", vbCritical, Compañia)
                    End If
                Else 'cuando editamos solo debe existir un registro...
                    If .Rows.Count > 1 Then
                        Validar_Grabacion = False
                        MsgBox("2. Factura ya fue ingresado  anteriormente, no podra ingresar la misma factura...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Function
    ' Grabamos Registro '
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If FrmOC.Visible = True Then
            If FrmOC.Tbc01.SelectedIndex = 1 Then
                If CboDoc.SelectedIndex > -1 Then
                    If Len(TxtSerie.Text) > 0 And Len(TxtNro_Doc.Text) > 0 Then
                        Call TxtSerie_LostFocus(Nothing, Nothing) : TxtNro_Doc_LostFocus(Nothing, Nothing)
                        If Validar_Grabacion() = True Then
                            Dim F As String = MsgBox("¿Desea Generar el ingreso del Comprobante?", vbYesNo + vbQuestion, Compañia)
                            If F = vbYes Then
                                Call Grabar_IngComp("ADD") : Call Grabar_Ingresos_OC("ADD")
                                With FrmOC.Dgv01
                                    For i = 0 To .RowCount - 1
                                        Call Grabar_Detalles(i, "ADD")
                                    Next
                                End With
                                MsgBox("Se grabo correctamente Nro. de Ingreso: " & TxtCod_Ing.Text, vbExclamation, Compañia)
                                FrmOC.BtnGenerar.Enabled = False
                                Me.Close()
                            End If
                        End If
                    Else
                        MsgBox("1. Debe ingresar el número de factura correctamente...", vbCritical, Compañia)
                    End If
                Else
                    MsgBox("2. Falta Seleccionar el tipo de documento...", vbCritical, Compañia)
                End If
            End If
        End If
    End Sub
    'Grabamos ingreso de comprobantes...
    Private Sub Grabar_IngComp(ByVal cOpcion As String)
        With c_Ent_IngComp
            .c_nro_ing = ""
            .c_codi_mon = FrmOC.CboMon.SelectedValue
            .c_codi_doc = CboDoc.SelectedValue
            .c_serie_doc = TxtSerie.Text
            .c_nro_doc = TxtNro_Doc.Text
            .c_nro_maq = ""
            .c_fecha_emi = FrmOC.DtpFec_Emi.Text
            .c_fecha_prd = FrmOC.DtpFec_Emi.Text
            .c_fecha_venci = FrmOC.DtpFec_Emi.Text
            .c_nro_dias = 0
            .c_codi_prov = FrmOC.txtCod_Prove.Text
            .c_codi_pago = FrmOC.TxtCod_Pago.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .c_obs = FrmOC.TxtObs.Text
            .c_tpo_cambio = Val(FrmOC.TxtTC.Text)
            .c_cant_igv = FrmOC.TxtCant_Igv.Text
            .c_imp_inaf = Val(FrmOC.TxtTot_Inaf.Text)
            .c_imp_igv = FrmOC.TxtTot_Igv.Text
            .c_imp_afecto = FrmOC.TxtTot_Afecto.Text
            .c_imp_total = FrmOC.TxtTotal.Text
            .c_mt_anula = ""
            ' Detracciones '
            .c_opc_detracc = 0 : .c_codi_detracc = "" : .c_porc_detracc = 0 : .c_imp_detracc = 0
            ' Retenciones '
            .c_opc_reten = 0 : .c_porc_reten = 0 : .c_base_reten = 0 : .c_imp_reten = 0
            .c_nro_leasing = ""
            .c_nro_cuota = 0
            .c_correl_leasing = ""
            .c_opc_apertura = 0
            .c_opc_importacion = 0
            .copcion = cOpcion
            TxtCod_Ing.Text = c_Neg_IngComp.set_IngComp_Save(c_Ent_IngComp, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub
    ' Metodo para Grabar el Detalle del Ingreso de Comprobante '
    Private Sub Grabar_Ingresos_OC(ByVal cOpcion As String)
        With c_Ent_IngCompOC
            .c_nro_correl = ""
            .c_nro_ing = TxtCod_Ing.Text
            .c_serie_oc = FrmOC.TxtSerie.Text
            .c_nro_oc = FrmOC.TxtOrden.Text
            .c_tpo_doc = "OS"
            .c_codi_ing = TxtCod_Ing.Text
            .c_imp_total = Val(FrmOC.TxtTotal.Text)
            .c_fecha_emi = FrmOC.DtpFec_Emi.Text
            .copcion = cOpcion
            c_Neg_IngComp.set_IngCompOC_Save(c_Ent_IngCompOC, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub
    ' Metodo para grabar las guias por ingreso '
    Private Sub Grabar_Detalles(ByVal Fila As Integer, ByVal cOpcion As String)
        'Grabamos el detalle de la factura...
        With c_Ent_ingCompDet
            .c_nro_correl = ""
            .c_correl_ing = ""
            .c_nro_ing = TxtCod_Ing.Text
            .c_nro_oc = FrmOC.TxtSerie.Text & FrmOC.TxtOrden.Text
            .c_codi_prov = FrmOC.txtCod_Prove.Text
            .c_codi_doc = CboDoc.SelectedValue
            .c_codi_tg = FrmOC.Dgv01.Rows(Fila).Cells("Mot").Value
            .c_codi_cd = FrmOC.Dgv01.Rows(Fila).Cells("Cd").Value
            .c_codi_scd = FrmOC.Dgv01.Rows(Fila).Cells("Scd").Value
            .c_nro_cant = FrmOC.Dgv01.Rows(Fila).Cells("cantidad").Value
            .c_codi_unimed = FrmOC.Dgv01.Rows(Fila).Cells("c_codi_unimed").Value
            .c_prec_unit = FrmOC.Dgv01.Rows(Fila).Cells("Precio").Value
            .c_imp_total = FrmOC.Dgv01.Rows(Fila).Cells("Importe").Value
            .c_opt_igv = FrmOC.Dgv01.Rows(Fila).Cells("Afecto").Value
            .c_obs = ""
            .copcion = cOpcion
            ' Validamos si se ingresa como nuevo '
            c_Neg_IngCompDet.set_IngCompDet_Save(c_Ent_ingCompDet, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub

    Private Sub TxtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSerie.TextChanged

    End Sub
    Private Sub TxtSerie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSerie.LostFocus
        If Len(TxtSerie.Text) > 0 Then
            If CboDoc.SelectedValue = "06" Then

            Else
                If IsNumeric(TxtSerie.Text) = True Then
                    TxtSerie.Text = Strings.Right(Val(TxtSerie.Text) + 1000, 3)
                Else

                End If
            End If
        End If
    End Sub
    ' # de Documento '
    Private Sub TxtNro_Doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNro_Doc.LostFocus
        If Len(TxtNro_Doc.Text) > 0 Then TxtNro_Doc.Text = Strings.Right(Val(TxtNro_Doc.Text) + 10000000, 7)
    End Sub

    Private Sub TxtNro_Doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNro_Doc.TextChanged

    End Sub
    ' Cerramos Ventana '
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
End Class