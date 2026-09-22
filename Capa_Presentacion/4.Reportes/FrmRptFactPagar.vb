Public Class FrmRptFactPagar
    ' Vista Preliminar '
    Private Sub BtnVista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVista.Click
        Dim c_codi_prov As String = "" : Dim Titulo As String = ""
        If Len(TxtProve.Text) > 0 Then
            c_codi_prov = TxtCod_Prove.Text : Titulo = "Reporte de Documentos Pendientes por Pagar - " & TxtProve.Text
        Else
            Titulo = "Reporte de Documentos Pendientes por Pagar Del : " & DtpFec_Ini.Text & " Al : " & DtpFec_Fin.Text
        End If
        Dim F As String = MsgBox("¿Desea mostrar el reporte ordenado por fecha de vencimiento?", vbYesNo + vbQuestion, Compañia)
        If F = vbYes Then
            FrmReportes2.Reporte_FactPendPagarTot(DtpFec_Ini.Text, DtpFec_Fin.Text, c_codi_prov, Titulo, "PRV")
            FrmReportes.Reporte_FactPendPagarFechas(DtpFec_Ini.Text, DtpFec_Fin.Text, c_codi_prov, Titulo, "PRV")
        Else
            ' Buscamos por leasing y pagares '
            If Val(TxtVar.Text) = 1 Then
                FrmReportes2.Reporte_FactPendPagarTot(DtpFec_Ini.Text, DtpFec_Fin.Text, c_codi_prov, Titulo, "LES")
                FrmReportes.Reporte_FactPendPagar(DtpFec_Ini.Text, DtpFec_Fin.Text, c_codi_prov, Titulo, "LES")
            Else 'todos los documentos menos el leasing y el pagare '
                FrmReportes2.Reporte_FactPendPagarTot(DtpFec_Ini.Text, DtpFec_Fin.Text, c_codi_prov, Titulo, "PRV")
                FrmReportes.Reporte_FactPendPagar(DtpFec_Ini.Text, DtpFec_Fin.Text, c_codi_prov, Titulo, "PRV")
            End If
        End If
    End Sub

    Private Sub FrmRptFactPagar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRptFactPagar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DtpFec_Ini.Text = "01/01/2013"
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Dim c_codi_prov As String = ""
        If Len(TxtProve.Text) > 0 Then c_codi_prov = TxtCod_Prove.Text
        Dgv01.DataSource = c_Neg_RptRegCompras.get_RptRegFactPend_Rpt(DtpFec_Ini.Text, DtpFec_Fin.Text, c_codi_prov, "PRV", FrmMenu.TxtCod_Emp.Text)
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Dim c_codi_prov As String = ""
        If Len(TxtProve.Text) > 0 Then c_codi_prov = TxtCod_Prove.Text
        Dgv01.DataSource = c_Neg_RptRegCompras.get_RptRegFactPend_Rpt(DtpFec_Ini.Text, DtpFec_Fin.Text, c_codi_prov, "PRV", FrmMenu.TxtCod_Emp.Text)
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Reporte_FactPagar.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Reporte_FactPagar.XLS"
            End If
        End If
    End Sub
    ' consultamos proveedores '
    Private Sub BtnConProve_Click(sender As System.Object, e As System.EventArgs) Handles BtnConProve.Click
        With FrmConProve
            .MdiParent = FrmMenu : .Show() : .TxtVar.Text = 9 : .Cargar_Grid(" and c_anula_reg=0 ")
        End With
    End Sub
End Class