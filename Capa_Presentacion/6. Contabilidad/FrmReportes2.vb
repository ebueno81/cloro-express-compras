Imports Microsoft.Reporting.WinForms
Public Class FrmReportes2

    Private Sub FrmReportes2_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.Control And e.KeyCode = Keys.P Then
            Rpt01.PrintDialog()
        End If
    End Sub

    Private Sub FrmReportes2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Rpt01.RefreshReport()
    End Sub
    ' Reporte de Facturas pendientes totalizado '
    Public Sub Reporte_FactPendPagarTot(ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, ByVal c_codi_prov As String, _
                                  ByVal titulo As String, ByVal vOpt As String)
        Rpt01.ProcessingMode = ProcessingMode.Remote
        Rpt01.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt01.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptFactPendTot"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", titulo, False))
        paramList.Add(New ReportParameter("c_fecha_ini", Fecha_Inicio, False))
        paramList.Add(New ReportParameter("c_fecha_fin", Fecha_Final, False))
        paramList.Add(New ReportParameter("c_codi_prov", c_codi_prov, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))

        Rpt01.ServerReport.Refresh()
        Rpt01.ServerReport.SetParameters(paramList)

        Rpt01.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt01.ZoomMode = ZoomMode.Percent
        Rpt01.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Registro de Compras '
    Public Sub Reporte_Registro_ComprasTot(ByVal titulo As String)
        Rpt01.ProcessingMode = ProcessingMode.Remote
        Rpt01.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt01.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptRegComprasTot"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", FrmMenu.TxtEmpresa.Text & " - " & FrmMenu.TxtRuc_Emp.Text, False))

        Rpt01.ServerReport.Refresh()
        Rpt01.ServerReport.SetParameters(paramList)

        Rpt01.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt01.ZoomMode = ZoomMode.Percent
        Rpt01.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Reporte de Compras Detallados
    Public Sub Reporte_MovTot(ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, ByVal c_codi_tg As String, ByVal c_codi_cd As String, _
                                  ByVal c_codi_scd As String, ByVal c_codi_mon As String, ByVal titulo As String)
        Rpt01.ProcessingMode = ProcessingMode.Remote
        Rpt01.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt01.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptMovDetTotCd"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", titulo, False))
        paramList.Add(New ReportParameter("c_fecha_inicial", Fecha_Inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", Fecha_Final, False))
        paramList.Add(New ReportParameter("c_codi_tg", c_codi_tg, False))
        paramList.Add(New ReportParameter("c_codi_cd", c_codi_cd, False))
        paramList.Add(New ReportParameter("c_codi_scd", c_codi_scd, False))
        paramList.Add(New ReportParameter("c_codi_mon", c_codi_mon, False))

        Rpt01.ServerReport.Refresh()
        Rpt01.ServerReport.SetParameters(paramList)

        Rpt01.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt01.ZoomMode = ZoomMode.Percent
        Rpt01.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
End Class