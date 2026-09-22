Public Class FrmRetencion
    Dim Anula As Integer = 0
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro() : Call BtnFin_Click(Nothing, Nothing) : Call Validar_Permiso(Me.Name, BtnNuevo, BtnNuevo, BtnAnular)
        End If
    End Sub
    ' Metodo para Cancelar registro '
    Private Sub Cancelar_Registro()
        Call Limpiar_Texto(Pan05) : BtnCon1.Enabled = True : Pan01.Enabled = True : BtnGrabar.Enabled = False
        BtnCerrar.Text = "Cerrar" : BtnCon1.Enabled = False : Dgv01.Rows.Clear() : Dgv02.Rows.Clear() : Pan12.Enabled = True
        CboSerie.Enabled = False : BtnMostrar.Enabled = False
    End Sub
    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        With FrmConProve
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 7 : .Cargar_Grid(" order by c_Desc_prov")
        End With
    End Sub
    Public Sub Cargar_Retenciones_Pendientes()
        With c_Neg_Retencion.get_Retencion_Datos(" And R.c_anula_reg=0 And R.c_opc_fact=0 And R.c_opc_cancel=1 and R.c_codi_prov='" & TxtCod_Prov.Text & "' order by R.c_fecha_emi", "DAT", FrmMenu.TxtCod_Emp.Text)
            Dgv01.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To .Rows.Count - 1
                    Dgv01.Rows.Add()
                    Dgv01.Rows(I).Cells("Tipo_Doc").Value = .Rows(I)("c_desc_doc").ToString
                    Dgv01.Rows(I).Cells("Documento").Value = .Rows(I)("c_serie_doc").ToString & " " & .Rows(I)("c_nro_doc").ToString
                    Dgv01.Rows(I).Cells("Total").Value = Format(Val(.Rows(I)("c_imp_doc").ToString), Forma_1_2)
                    Dgv01.Rows(I).Cells("c_nro_correl").Value = .Rows(I)("c_nro_correl").ToString
                Next
            Else
                MsgBox(" No existen Retenciones Pendientes por Emitir...")
            End If
        End With
    End Sub
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : BtnCon1_Click(Nothing, Nothing) : Anula = 0
        If CboSerie.Items.Count > 0 Then CboSerie.SelectedIndex = 0 : BtnEstado.BackColor = Color.Maroon : BtnEstado.Text = "PENDIENTE"
        CboSerie_SelectedIndexChanged(Nothing, Nothing) : DtpFec_Emi.Text = Now.Date
    End Sub
    ' Metodo para un nuevo registro '
    Private Sub Nuevo_Registro()
        Call Limpiar_Texto(Pan05) : BtnCon1.Enabled = True : Pan01.Enabled = False : BtnGrabar.Enabled = True
        BtnCerrar.Text = "Cancelar" : LblTot_Doc.Text = "" : LblTot_Reten.Text = "" : LblTotal.Text = ""
        Dgv01.Rows.Clear() : Dgv02.Rows.Clear() : CboSerie.Enabled = True : Pan12.Enabled = False : BtnMostrar.Enabled = True
    End Sub

    Private Sub FrmRetencion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If BtnGrabar.Enabled = True Then If e.Control And e.KeyCode = Keys.G Then Call BtnGrabar_Click(Nothing, Nothing)
        If Pan01.Enabled = True Then If e.Control And e.KeyCode = Keys.N Then Call BtnNuevo_Click(Nothing, Nothing)
        If BtnImprimir.Enabled = True Then If e.Control And e.KeyCode = Keys.P Then Call BtnImprimir_Click(Nothing, Nothing)
    End Sub


    Private Sub FrmRetencion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnSeries.get_Series_Cbo(" And c_anula_reg=0 and c_codi_doc='11' order by c_nro_serie", CboSerie, FrmMenu.TxtCod_Emp.Text)
        c_Neg_MnSeries.get_Series_Cbo(" And c_anula_reg=0 and c_codi_doc='11' order by c_nro_serie", CboBus_Serie, FrmMenu.TxtCod_Emp.Text)
        If CboBus_Serie.Items.Count > 0 Then CboBus_Serie.SelectedIndex = 0
        Call BtnFin_Click(Nothing, Nothing)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnNuevo, BtnAnular)
    End Sub
    ' Metodo para mostrar las retenciones '
    Public Sub Mostrar_Retenciones(ByVal Cadena As String)
        With c_Neg_RetenCab.get_RetenCab_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
            Call Cancelar_Registro()
            If .Rows.Count > 0 Then
                CboSerie.SelectedValue = .Rows(0)("c_nro_serie").ToString
                TxtRetencion.Text = .Rows(0)("c_nro_reten").ToString
                TxtBus.Text = .Rows(0)("c_nro_reten").ToString
                CboProve.Text = .Rows(0)("c_Desc_prov").ToString
                TxtRuc.Text = .Rows(0)("c_ruc_prov").ToString
                TxtCod_Prov.Text = .Rows(0)("c_Codi_prov").ToString
                TxtDir.Text = .Rows(0)("c_direc_reten").ToString
                DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                LblTot_Doc.Text = Format(Val(.Rows(0)("c_total_doc").ToString), Forma_2_2)
                LblTot_Reten.Text = Format(Val(.Rows(0)("c_total_reten").ToString), Forma_2_2)
                LblLetras.Text = .Rows(0)("c_letras_Reten").ToString
                '''--> Anulamos registros <--'''
                If Val(.Rows(0)("c_anula_Reg").ToString) = 1 Then
                    BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Color.Red
                Else
                    BtnEstado.Text = "PENDIENTE" : BtnEstado.BackColor = Color.Maroon
                End If
                ' Cargamos Detalles '
                With c_Neg_RetenDet.get_RetenDet_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            ' Llenamos para las dos grid
                            ' Grid # 1 '
                            Dgv01.Rows.Add()
                            Dgv01.Rows(I).Cells("Tipo_doc").Value = .Rows(I)("c_desc_doc").ToString
                            Dgv01.Rows(I).Cells("Documento").Value = .Rows(I)("c_serie_doc").ToString & " " & .Rows(I)("c_nro_doc").ToString
                            Dgv01.Rows(I).Cells("Total").Value = .Rows(I)("c_imp_doc").ToString
                            Dgv01.Rows(I).Cells("c_nro_correl").Value = .Rows(I)("c_correl_reten").ToString
                            Dgv01.Rows(I).Cells("Chk").Value = True
                            ' Grid # 2 '
                            Dgv02.Rows.Add()
                            Dgv02.Rows(I).Cells("Tipo").Value = .Rows(I)("c_desc_doc").ToString
                            Dgv02.Rows(I).Cells("Factura").Value = .Rows(I)("c_serie_doc").ToString & " " & .Rows(I)("c_nro_doc").ToString
                            Dgv02.Rows(I).Cells("Fecha").Value = FormatDateTime(.Rows(I)("c_fecha_doc").ToString, DateFormat.ShortDate)
                            Dgv02.Rows(I).Cells("Total_Doc").Value = .Rows(I)("c_imp_doc").ToString
                            Dgv02.Rows(I).Cells("Total_Reten").Value = .Rows(I)("c_imp_reten").ToString
                            Dgv02.Rows(I).Cells("Item").Value = .Rows(I)("c_nro_correl").ToString
                            Dgv02.Rows(I).Cells("c_correl_reten").Value = .Rows(I)("c_correl_reten").ToString
                            Dgv02.Rows(I).Cells("c_nro_ing").Value = .Rows(I)("c_nro_ing").ToString
                            Dgv02.Rows(I).Cells("c_codi_mon").Value = .Rows(I)("c_codi_mon").ToString
                            Dgv02.Rows(I).Cells("c_codi_doc").Value = .Rows(I)("c_codi_doc").ToString
                        Next
                    End If
                End With
                ' Total de Documentos '
                LblTotal.Text = Dgv02.RowCount
            End If
        End With
    End Sub
    Private Sub CboSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSerie.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboSerie, TxtRetencion)
        With c_Neg_MnSeries.get_Series_Datos(" and c_codi_doc='11' and c_anula_reg=0", "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                TxtRetencion.Text = Strings.Right(Val(.Rows(0)("c_nro_doc").ToString) + 10000001, 7)
            Else
                TxtRetencion.Clear()
            End If
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' Cargamos Registro '
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        With Dgv01
            Dgv02.Rows.Clear()
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("Chk").Value = True Then
                    Call Cargar_Detalles(.Rows(i).Cells("c_nro_correl").Value)
                End If
            Next
            Call Calcular_Totales()
        End With
    End Sub
    ' Metodo para Cargar Registros '
    Private Sub Cargar_Detalles(ByVal c_nro_correl As String)
        With c_Neg_Retencion.get_Retencion_Datos(" and c_nro_correl='" & c_nro_correl & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                For I = 0 To .Rows.Count - 1
                    Dgv02.Rows.Add()
                    Dim Fila As Integer = Dgv02.RowCount - 1
                    Dgv02.Rows(Fila).Cells("Tipo").Value = .Rows(I)("c_desc_Doc").ToString
                    Dgv02.Rows(Fila).Cells("Factura").Value = .Rows(I)("c_serie_doc").ToString & " " & .Rows(I)("c_nro_doc").ToString
                    Dgv02.Rows(Fila).Cells("Fecha").Value = FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate)
                    Dgv02.Rows(Fila).Cells("Total_Doc").Value = .Rows(I)("c_imp_doc").ToString
                    Dgv02.Rows(Fila).Cells("Total_Reten").Value = Format(Val(.Rows(I)("c_imp_reten").ToString), Forma_1_2)
                    Dgv02.Rows(Fila).Cells("Item").Value = ""
                    Dgv02.Rows(Fila).Cells("c_correl_reten").Value = .Rows(I)("c_nro_correl").ToString
                    Dgv02.Rows(Fila).Cells("c_nro_ing").Value = .Rows(I)("c_nro_ing").ToString
                    Dgv02.Rows(Fila).Cells("c_codi_doc").Value = .Rows(I)("c_codi_doc").ToString
                    Dgv02.Rows(Fila).Cells("c_codi_mon").Value = .Rows(I)("c_codi_mon").ToString
                Next
            End If
        End With
    End Sub
    ' Metodo para calcular los totales '
    Private Sub Calcular_Totales()
        With Dgv02
            Dim Tot_Reten As Decimal = 0 : Dim Tot_Doc As Decimal = 0
            For I = 0 To .RowCount - 1
                Tot_Reten = Tot_Reten + Val(.Rows(I).Cells("Total_Reten").Value)
                Tot_Doc = Tot_Doc + Val(.Rows(I).Cells("Total_doc").Value)
            Next
            '--> Totales de Retenciones <--'
            LblTotal.Text = Dgv02.RowCount
            LblTot_Doc.Text = Format(Tot_Doc, Forma_2_2)
            LblTot_Reten.Text = Format(Tot_Reten, Forma_1_2)

            LblLetras.Text = StrConv(num2text(Mid(LblTot_Reten.Text, 1, Len(LblTot_Reten.Text) - 3)) & " Y " & Strings.Right(LblTot_Reten.Text, 2) & "/100 NUEVOS SOLES", VbStrConv.Uppercase)
        End With
    End Sub
    ' Grabar Retencion '
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If Len(TxtCod_Prov.Text) > 0 Then
                Dim x As Integer = 0
                If Dgv02.RowCount = 0 Then
                    Dim S As String = MsgBox("¿ No existen registros desea grabar ?", vbYesNo + vbCritical, Compañia)
                    If S = vbNo Then x = 1
                End If
                If x = 0 Then
                    Dim F As String = MsgBox("¿  Desea Grabar la Retención  ?", vbYesNo + vbQuestion, Compañia)
                    If F = vbYes Then
                        Call Grabar_Retencion("ADD")
                        With Dgv02
                            For I = 0 To .RowCount - 1
                                Call Grabar_Retencion_Det(I, "ADD")
                            Next
                        End With
                        MsgBox(" Registro se Grabo Correctamente... ", vbExclamation, Compañia)
                        Call Cancelar_Registro() : Call BtnFin_Click(Nothing, Nothing) : Call BtnImprimir_Click(Nothing, Nothing)
                    End If
                End If
            Else
                MsgBox(" Falta Seleccionar el Proveedor...", vbCritical, Compañia)
            End If
        End If
    End Sub
    Private Sub Grabar_Retencion(ByVal cOpcion As String)
        With c_Ent_RetenCab
            .c_nro_serie = CboSerie.Text
            .c_nro_reten = TxtRetencion.Text
            .c_direc_reten = TxtDir.Text
            .c_fecha_emi = DtpFec_Emi.Text
            .c_codi_prov = TxtCod_Prov.Text
            .c_codi_mon = "01"
            .c_total_doc = Val(Replace(LblTot_Doc.Text, ",", ""))
            .c_total_reten = Val(Replace(LblTot_Reten.Text, ",", ""))
            .c_letras_reten = LblLetras.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            TxtRetencion.Text = c_Neg_RetenCab.set_RetenCab_Save(c_Ent_RetenCab, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub
    ' Metodo para Grabar el Detalle de la Retencion '
    Private Sub Grabar_Retencion_Det(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_RetenDet
            .c_nro_correl = Dgv02.Rows(Fila).Cells("Item").Value
            .c_nro_serie = CboSerie.Text
            .c_nro_reten = TxtRetencion.Text
            .c_nro_ing = Dgv02.Rows(Fila).Cells("c_nro_ing").Value
            .c_correl_reten = Dgv02.Rows(Fila).Cells("c_correl_reten").Value
            .c_fecha_doc = Dgv02.Rows(Fila).Cells("Fecha").Value
            .c_codi_doc = Dgv02.Rows(Fila).Cells("c_Codi_doc").Value
            .c_serie_doc = Strings.Left(Dgv02.Rows(Fila).Cells("Factura").Value, 3)
            .c_nro_doc = Strings.Right(Dgv02.Rows(Fila).Cells("Factura").Value, 7)
            .c_codi_mon = Dgv02.Rows(Fila).Cells("c_codi_mon").Value
            .c_imp_doc = Val(Dgv02.Rows(Fila).Cells("Total_Doc").Value)
            .c_imp_reten = Val(Dgv02.Rows(Fila).Cells("Total_Reten").Value)
            .copcion = cOpcion
            Dgv02.Rows(Fila).Cells("Item").Value = c_Neg_RetenDet.set_RetenDet_Save(c_Ent_RetenDet, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub

    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_Retenciones(" And c_nro_Serie='" & CboBus_Serie.Text & "'  and R.c_nro_reten = (Select Max(c_nro_Reten) From Scom_" & FrmMenu.TxtCod_Emp.Text & "_RetenCab Where R.c_nro_Serie='" & CboBus_Serie.Text & "') ")
    End Sub

    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_Retenciones(" And c_nro_Serie='" & CboBus_Serie.Text & "'  and R.c_nro_reten= (Select Min(c_nro_Reten) From Scom_" & FrmMenu.TxtCod_Emp.Text & "_RetenCab Where R.c_nro_serie='" & CboBus_Serie.Text & "') ")
    End Sub
    ' Eliminamos Registro '
    Private Sub BtnAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnular.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If BtnEstado.Text = "ANULADO" Then
                MsgBox("Registro se encuentra Anulado, no puede ser eliminado...", vbCritical, Compañia)
            Else
                Dim F As String = MsgBox("  ¿  Confirma la eliminación de la Retención  ?  ", vbYesNo + vbQuestion, Compañia)
                If F = vbYes Then
                    Anula = 1
                    Call Grabar_Retencion("DEL")
                    With Dgv02
                        For i = 0 To .RowCount - 1
                            Call Grabar_Retencion_Det(i, "DEL")
                        Next
                    End With
                    MsgBox(" Registro se Elimino Correctamente... ", vbCritical, Compañia)
                    Call Cancelar_Registro()
                    Call Mostrar_Retenciones(" And R.c_nro_serie='" & CboSerie.Text & "' and R.c_nro_reten='" & TxtRetencion.Text & "'")
                    Anula = 0
                End If
            End If
        End If
    End Sub

    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBus.Text) > 0 Then
            TxtBus.Text = Strings.Right(Val(TxtBus.Text) + 10000001, 7)
            Call Mostrar_Retenciones(" And R.c_nro_serie='" & CboBus_Serie.Text & "' and R.c_nro_reten='" & TxtBus.Text & "'")
        End If
    End Sub

    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBus.Text) > 1 Then
            TxtBus.Text = Strings.Right((Val(TxtBus.Text) - 1) + 10000000, 7)
            Call Mostrar_Retenciones(" And R.c_nro_serie='" & CboBus_Serie.Text & "' and R.c_nro_reten='" & TxtBus.Text & "'")
        End If
    End Sub

    Private Sub TxtBus_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus.Text) > 0 Then
                Call Mostrar_Retenciones(" And R.c_nro_serie='" & CboBus_Serie.Text & "' and R.c_nro_reten='" & TxtBus.Text & "'")
            End If
        End If
    End Sub

    Private Sub TxtBus_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus.TextChanged

    End Sub

    Private Sub BtnAva_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BtnAva.KeyDown
        
    End Sub
    ' Listado de Retenciones '
    Private Sub LnkConFact_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkConFact.LinkClicked
        FrmRetenConsul.MdiParent = FrmMenu : FrmRetenConsul.Show()
    End Sub

    Private Sub TxtDir_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDir.TextChanged

    End Sub
    ' Imprimir Retencion '
    Private Sub BtnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprimir.Click
        FrmReportes.Imprimir_Retencion(" And D.c_nro_serie='" & CboSerie.Text & "' and D.c_nro_reten='" & TxtRetencion.Text & "' ", CboSerie.Text, TxtRetencion.Text, LblTot_Doc.Text, LblTot_Reten.Text)
    End Sub
    ' Lista de Retenciones Pendientes por emitir '
    Private Sub LnkRetenPend_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkRetenPend.LinkClicked
        FrmRetenPend.MdiParent = FrmMenu : FrmRetenPend.Show()
    End Sub
End Class
