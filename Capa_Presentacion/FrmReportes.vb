Imports System.IO
Imports Microsoft.Reporting.WinForms
'Imports System.Drawing.Printing

Public Class FrmReportes
   
    Public myPRT As Reporting
    Private Sub FrmReportes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.P Then
            Rpt01.PrintDialog()
        End If
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub FrmReportes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Rpt02.RefreshReport()

    End Sub
    ' Impresion de Orden de Compra '
    Public Sub Impresion_OC(ByVal Cadena As String, ByVal c_nro_serie As String, ByVal c_nro_oc As String)
        Dim myRPTForm As New FrmReportes
        Dim Report As New ReportViewer


        Report = myRPTForm.Rpt02
        Report.LocalReport.DataSources.Clear()

        Report.ProcessingMode = ProcessingMode.Remote
        Report.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Report.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_Fa_RptOC"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_nro_serie", c_nro_serie, False))
        paramList.Add(New ReportParameter("c_nro_oc", c_nro_oc, False))
        paramList.Add(New ReportParameter("c_codi_emp", FrmMenu.TxtCod_Emp.Text, False))


        myPRT = New Reporting

        Report.ServerReport.Refresh()
        Report.ServerReport.SetParameters(paramList)
        Report.SetDisplayMode(DisplayMode.PrintLayout)
        Report.ZoomMode = ZoomMode.Percent
        Report.ZoomPercent = FrmMenu.TxtZoom.Text
        myRPTForm.Show()
        ' EXPORTAR E IMPRIMIR OC MUY BUEN EJEMPLO '
        'myPRT.Export(Report.LocalReport)
        'myPRT.m_currentPageIndex = 0
        ' myPRT.Print()
    End Sub
    Public Sub Impresion_Directa_Pruebas()
        Dim myRPTForm As New FrmReportes  ' This would be your rdlc report for your labels
        Dim Report As New ReportViewer
        Dim midataset As New DataSet
        Dim rds As New ReportDataSource

        Report = myRPTForm.Rpt02

        Report.LocalReport.DataSources.Clear()
        Report.LocalReport.ReportPath = FrmMenu.LblRutaReport.Text & "Scom_" & FrmMenu.TxtCod_Emp.Text & "_RptOC.rdl"
        ' Nro. Serie '
        Dim parametro As ReportParameter = New ReportParameter
        parametro.Name = "c_nro_serie"
        parametro.Values.Add("001")
        Report.LocalReport.SetParameters(parametro)
        ' Nro. SalidaTA '
        Dim parametro2 As ReportParameter = New ReportParameter
        parametro2.Name = "c_nro_oc"
        parametro2.Values.Add("0000008")
        Report.LocalReport.SetParameters(parametro2)

        midataset.Merge(c_Neg_OCDet.get_OCDet_Datos(" and D.c_nro_serie='001' and D.c_nro_oc='0000008'", FrmMenu.TxtCod_Emp.Text, "IMP"))
        myPRT = New Reporting

        rds.Name = "DataSet1"
        rds.Value = midataset.Tables(0)
        ' Set the physical path to your report rdlc file.      
        ' This next code binds my datasource to my report. I suspect you may be handling this differently.
        Report.LocalReport.DataSources.Add(rds)
        myRPTForm.Show()
        ' This next code prepares the rdlc file for printing and calls the print function from the Reporting class file
        myPRT.Export(Report.LocalReport)
        myPRT.m_currentPageIndex = 0
        myPRT.Print()
    End Sub
    'Impresión de Retención '
    Public Sub Imprimir_Retencion(ByVal Cadena As String, ByVal c_nro_serie As String, ByVal c_nro_reten As String, ByVal Tot_Doc As Decimal,
                                  ByVal Tot_Reten As Decimal)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_ImpRetencion"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_nro_serie", c_nro_serie, False))
        paramList.Add(New ReportParameter("c_nro_reten", c_nro_reten, False))
        paramList.Add(New ReportParameter("Tot_Doc", Tot_Doc, False))
        paramList.Add(New ReportParameter("Tot_Reten", Tot_Reten, False))


        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    'Impresión de Retención '
    Public Sub Reporte_Registro_Compras(ByVal titulo As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptRegCompras"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", FrmMenu.TxtEmpresa.Text & " - " & FrmMenu.TxtRuc_Emp.Text, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    'Impresión de Facturas por pagar ordenado por fecha de vencimiento'
    Public Sub Reporte_FactPendPagarFechas(ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, ByVal c_codi_prov As String,
                                  ByVal titulo As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        'Sp_Scom_Fa_Rpt_DocPendxPagar
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptFactPendFechasV2"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_fecha_ini", Fecha_Inicio, False))
        paramList.Add(New ReportParameter("c_fecha_fin", Fecha_Final, False))
        paramList.Add(New ReportParameter("c_codi_prov", c_codi_prov, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Titulo", titulo, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    'Impresión de Facturas por pagar agrupado por proveedor'
    Public Sub Reporte_FactPendPagar(ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, ByVal c_codi_prov As String,
                                  ByVal titulo As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptFactPend"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", titulo, False))
        paramList.Add(New ReportParameter("c_fecha_ini", Fecha_Inicio, False))
        paramList.Add(New ReportParameter("c_fecha_fin", Fecha_Final, False))
        paramList.Add(New ReportParameter("c_codi_prov", c_codi_prov, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    ' Impresión de Detracciones '
    Public Sub Impresion_Detraccion()
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_" & FrmMenu.TxtCod_Emp.Text & "_ImpDetraccion"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", FrmMenu.TxtEmpresa.Text & " - " & FrmMenu.TxtRuc_Emp.Text, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    ' Reporte de Detraccion '
    Public Sub Reporte_Detraccion(ByVal c_año_lote As String, ByVal c_nro_lote As String, ByVal Titulo As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptDetraccion"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("c_año_lote", c_año_lote, False))
        paramList.Add(New ReportParameter("c_nro_lote", c_nro_lote, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    ' Reporte de Leasing '
    Public Sub Reporte_Leasing(ByVal c_codi_prov As String, ByVal vOpt As String, ByVal Titulo As String,
                               ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        'Sp_Scom_Rpt_Leasing
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptLeasing"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_codi_prov", c_codi_prov, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))


        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    ' Reporte de Leasing '
    Public Sub Reporte_LeasingDet(ByVal c_codi_prov As String, ByVal vOpt As String, ByVal Titulo As String,
                               ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptLeasingDet"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_codi_prov", c_codi_prov, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))


        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    ' Reporte de Compras Detallados
    Public Sub Reporte_MovDet(ByVal Fecha_Inicio As Date, ByVal Fecha_Final As Date, ByVal c_codi_tg As String, ByVal c_codi_cd As String,
                                  ByVal c_codi_scd As String, ByVal c_codi_mon As String, ByVal titulo As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptMovDet"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", titulo, False))
        paramList.Add(New ReportParameter("c_fecha_inicial", Fecha_Inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", Fecha_Final, False))
        paramList.Add(New ReportParameter("c_codi_tg", c_codi_tg, False))
        paramList.Add(New ReportParameter("c_codi_cd", c_codi_cd, False))
        paramList.Add(New ReportParameter("c_codi_scd", c_codi_scd, False))
        paramList.Add(New ReportParameter("c_codi_mon", c_codi_mon, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    ' Reporte de Tipo de Cambio Promedio '
    Public Sub Reporte_TpoCambio(ByVal titulo As String, ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptTpoCambio"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", titulo, False))
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    ' Reporte de Insumos Quimicos Unidades Fisicas '
    Public Sub Reporte_StockIQ(ByVal Almacen As String, ByVal Mes As String, ByVal Año As String)

        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_StockIQ"


        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Almacen", Almacen, False))
        paramList.Add(New ReportParameter("mes", Mes, False))
        paramList.Add(New ReportParameter("año", Año, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    ' Reporte de Insumos Quimicos Unidades Fisicas '
    Public Sub Reporte_StockIQValor(ByVal Almacen As String, ByVal c_nick_mon As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptStockValor"


        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Almacen, False))
        paramList.Add(New ReportParameter("M", c_nick_mon, False))


        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    ' Reporte de kardex Valorizados '
    Public Sub Reporte_KardexIQ_Unidad(ByVal Titulo As String, ByVal c_codi_prov As String, ByVal c_codi_mt As String, ByVal c_fecha_inicio As Date,
                                ByVal c_fecha_final As Date, ByVal c_codi_articulo As String, ByVal c_codi_alm As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptKardexUnid"


        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("c_codi_prov", c_codi_prov, False))
        paramList.Add(New ReportParameter("c_codi_mt", c_codi_mt, False))
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_Articulo", c_codi_articulo, False))
        paramList.Add(New ReportParameter("c_codi_alm", c_codi_alm, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    ' Reporte de kardex Valorizados '
    Public Sub Reporte_KardexIQ(ByVal Titulo As String, ByVal c_codi_prov As String, ByVal c_codi_mt As String, ByVal c_fecha_inicio As Date,
                                ByVal c_fecha_final As Date, ByVal c_codi_articulo As String, ByVal c_codi_alm As String, ByVal c_codi_mon As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptKardex"


        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))
        paramList.Add(New ReportParameter("c_codi_prov", c_codi_prov, False))
        paramList.Add(New ReportParameter("c_codi_mt", c_codi_mt, False))
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_Articulo", c_codi_articulo, False))
        paramList.Add(New ReportParameter("c_codi_alm", c_codi_alm, False))
        paramList.Add(New ReportParameter("c_codi_mon", c_codi_mon, False))
        paramList.Add(New ReportParameter("vOpt", vOpt, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    ' Reporte de Tipo de Cambio Promedio '
    Public Sub Reporte_LetrasLista(ByVal titulo As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptLetras"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", titulo, False))


        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    Public Sub Reporte_DocLista(ByVal titulo As String,
                                ByVal Total_Mn As Decimal, ByVal Total_Us As Decimal,
                                ByVal Saldo_Mn As Decimal, ByVal Saldo_Us As Decimal)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptIngCompLista"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", titulo, False))
        paramList.Add(New ReportParameter("Total_Mn", Total_Mn, False))
        paramList.Add(New ReportParameter("Total_Us", Total_Us, False))
        paramList.Add(New ReportParameter("Saldo_Mn", Saldo_Mn, False))
        paramList.Add(New ReportParameter("Saldo_Us", Saldo_Us, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = FrmMenu.TxtZoom.Text
        Me.Show()
    End Sub
    Public Sub Mas_Pruebas()
        Dim myRPTForm As New FrmReportes  ' This would be your rdlc report for your labels
        Dim report As LocalReport = New LocalReport()

        Dim midataset As New DataSet
        Dim rds As New ReportDataSource

        Rpt02.LocalReport.DataSources.Clear()
        report.ReportPath = FrmMenu.LblRutaReport.Text & "Scom_" & FrmMenu.TxtCod_Emp.Text & "_RptOC.rdl"
        ' Nro. Serie '
        Dim parametro As ReportParameter = New ReportParameter
        parametro.Name = "c_nro_serie"
        parametro.Values.Add("001")
        report.SetParameters(parametro)
        ' Nro. SalidaTA '
        Dim parametro2 As ReportParameter = New ReportParameter
        parametro2.Name = "c_nro_oc"
        parametro2.Values.Add("0000020")
        report.SetParameters(parametro2)

        midataset.Merge(c_Neg_OCDet.get_OCDet_Datos("", FrmMenu.TxtCod_Emp.Text, "IMP"))

        myPRT = New Reporting

        rds.Name = "DataSet1"
        rds.Value = midataset.Tables(0)
        ' Set the physical path to your report rdlc file.      


        ' This next code binds my datasource to my report.  I suspect you may be handling this differently.

        report.DataSources.Add(rds)

        ' This next code prepares the rdlc file for printing and calls the print function from the Reporting class file

        myPRT.Export(report)
        myPRT.m_currentPageIndex = 0
        myPRT.Print()
    End Sub

    ' Reporte de Sub-Caidas
    Public Sub Reporte_Caidas()
        Dim myRPTForm As New FrmReportes
        Dim Report As New ReportViewer

        Report = myRPTForm.Rpt02
        Report.LocalReport.DataSources.Clear()

        Report.ProcessingMode = ProcessingMode.Remote
        Report.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Report.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptCaidas"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))

        myPRT = New Reporting

        Report.ServerReport.Refresh()
        Report.ServerReport.SetParameters(paramList)
        Report.SetDisplayMode(DisplayMode.PrintLayout)
        Report.ZoomMode = ZoomMode.Percent
        Report.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        myRPTForm.Show()
        '--> EXPORTAR E IMPRIMIR OC MUY BUEN EJEMPLO <--'
        'myPRT.Export(Report.LocalReport)
        'myPRT.m_currentPageIndex = 0
        'myPRT.Print()
    End Sub
    ' Reporte de Caidas
    Public Sub Reporte_SubCaidas()
        Dim myRPTForm As New FrmReportes
        Dim Report As New ReportViewer

        Report = myRPTForm.Rpt02
        Report.LocalReport.DataSources.Clear()

        Report.ProcessingMode = ProcessingMode.Remote
        Report.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Report.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_RptSCaidas"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))

        myPRT = New Reporting

        Report.ServerReport.Refresh()
        Report.ServerReport.SetParameters(paramList)
        Report.SetDisplayMode(DisplayMode.PrintLayout)
        Report.ZoomMode = ZoomMode.Percent
        Report.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        myRPTForm.Show()
        '--> EXPORTAR E IMPRIMIR OC MUY BUEN EJEMPLO <--'
        'myPRT.Export(Report.LocalReport)
        'myPRT.m_currentPageIndex = 0
        'myPRT.Print()
    End Sub
    Private Sub Rpt01_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rpt02.Load

    End Sub
    ' Impresión de Transformacion '
    Public Sub Impresion_transforma(ByVal c_nro_comis As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_Transformacion"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("c_nro_transforma", c_nro_comis, False))
        paramList.Add(New ReportParameter("vOpt", "IMP", False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Impresion de Lista de Documentos '
    Public Sub Reporte_IngAlmacen(ByVal Titulo As String, ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_mt As String,
                                ByVal c_codi_prov As String, ByVal c_codi_tg As String, ByVal c_codi_cd As String, ByVal c_codi_scd As String,
                                ByVal c_serie_guia As String, ByVal c_nro_guia As String, ByVal c_serie_doc As String, ByVal c_nro_doc As String, ByVal c_nro_ing As String,
                                ByVal c_codi_mon As String, ByVal c_opc_noingsal As String, ByVal c_codi_alm As String, ByVal vOpt As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptIngAlm"

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_mt", c_codi_mt, False))
        paramList.Add(New ReportParameter("c_codi_prov", c_codi_prov, False))
        paramList.Add(New ReportParameter("c_codi_tg", c_codi_tg, False))
        paramList.Add(New ReportParameter("c_codi_cd", c_codi_cd, False))
        paramList.Add(New ReportParameter("c_codi_scd", c_codi_scd, False))
        paramList.Add(New ReportParameter("c_nro_ing", c_nro_ing, False))
        paramList.Add(New ReportParameter("c_serie_guia", c_serie_guia, False))
        paramList.Add(New ReportParameter("c_nro_guia", c_nro_guia, False))
        paramList.Add(New ReportParameter("c_serie_doc", c_serie_doc, False))
        paramList.Add(New ReportParameter("c_nro_doc", c_nro_doc, False))

        paramList.Add(New ReportParameter("cOpcion", vOpt, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))

        paramList.Add(New ReportParameter("c_codi_mon", c_codi_mon, False))
        paramList.Add(New ReportParameter("c_opc_noingsal", c_opc_noingsal, False))

        paramList.Add(New ReportParameter("c_codi_alm", c_codi_alm, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Reporte de kardex Valorizados '
    Public Sub Reporte_KardexIQSunatValEspecial(ByVal Mes As String, ByVal Año As Integer, ByVal almacen As String,
                                        ByVal c_desc_tg As String, ByVal c_codi_sunat As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_KardexValSunatEspecial"


        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Ruc", FrmMenu.TxtRuc_Emp.Text, False))
        paramList.Add(New ReportParameter("Mes", Mes, False))
        paramList.Add(New ReportParameter("Año", Año, False))
        paramList.Add(New ReportParameter("Almacen", almacen, False))
        paramList.Add(New ReportParameter("c_desc_tg", c_desc_tg, False))
        paramList.Add(New ReportParameter("c_codi_sunat", c_codi_sunat, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Reporte de kardex Valorizados '
    Public Sub Reporte_KardexIQSunatVal(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_tg As String, ByVal c_codi_cd As String,
                                        ByVal c_codi_articulo As String, ByVal c_codi_alm As String,
                                        ByVal Mes As String, ByVal Año As Integer, ByVal c_codi_mon As String, ByVal almacen As String,
                                        ByVal c_desc_tg As String, ByVal c_codi_sunat As String, ByVal cOpcion As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_KardexValSunat_3"
        'sp_Scal_upt_KdxAlmSunatValor

        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_alm", c_codi_alm, False))
        paramList.Add(New ReportParameter("c_codi_articulo", c_codi_articulo, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Ruc", FrmMenu.TxtRuc_Emp.Text, False))
        paramList.Add(New ReportParameter("Mes", Mes, False))
        paramList.Add(New ReportParameter("Año", Año, False))
        paramList.Add(New ReportParameter("c_codi_mon", c_codi_mon, False))
        paramList.Add(New ReportParameter("cOpcion", cOpcion, False))
        paramList.Add(New ReportParameter("c_codi_tg", c_codi_tg, False))
        paramList.Add(New ReportParameter("c_codi_cd", c_codi_cd, False))
        paramList.Add(New ReportParameter("Almacen", almacen, False))
        paramList.Add(New ReportParameter("c_desc_tg", c_desc_tg, False))
        paramList.Add(New ReportParameter("c_codi_sunat", c_codi_sunat, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Reporte de Hojas de Resumen '
    Public Sub Reporte_HojaKardex(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_tg As String, ByVal c_codi_cd As String,
                                        ByVal c_codi_alm As String,
                                        ByVal Mes As String, ByVal Año As Integer, ByVal c_codi_mon As String, ByVal almacen As String,
                                        ByVal c_desc_tg As String, ByVal c_codi_sunat As String, ByVal c_codi_scd As String, ByVal cOpcion As String,
                                  ByVal c_codi_articulo As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        'sp_Scal_upt_KdxAlmSunatHoja
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptKardexHoja"


        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_alm", c_codi_alm, False))
        paramList.Add(New ReportParameter("c_codi_tg", c_codi_tg, False))
        paramList.Add(New ReportParameter("c_codi_scd", c_codi_scd, False))
        paramList.Add(New ReportParameter("c_codi_cd", c_codi_cd, False))
        paramList.Add(New ReportParameter("c_codi_mon", c_codi_mon, False))
        paramList.Add(New ReportParameter("cOpcion", cOpcion, False))

        paramList.Add(New ReportParameter("Mes", Mes, False))
        paramList.Add(New ReportParameter("Año", Año, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Almacen", almacen, False))
        paramList.Add(New ReportParameter("Ruc", FrmMenu.TxtRuc_Emp.Text, False))
        paramList.Add(New ReportParameter("c_codi_articulo", c_codi_articulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()

    End Sub
    ' Reporte de kardex Unidades '
    Public Sub Reporte_KardexIQSunatFisico(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_tg As String, ByVal c_codi_cd As String,
                                        ByVal c_codi_articulo As String, ByVal c_codi_alm As String,
                                        ByVal Mes As String, ByVal Año As Integer, ByVal c_codi_mon As String, ByVal almacen As String,
                                        ByVal c_desc_tg As String, ByVal c_codi_sunat As String, ByVal cOpcion As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scom_KardexFisicoSunat"


        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("c_fecha_inicio", c_fecha_inicio, False))
        paramList.Add(New ReportParameter("c_fecha_final", c_fecha_final, False))
        paramList.Add(New ReportParameter("c_codi_alm", c_codi_alm, False))
        paramList.Add(New ReportParameter("c_codi_articulo", c_codi_articulo, False))
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Ruc", FrmMenu.TxtRuc_Emp.Text, False))
        paramList.Add(New ReportParameter("Mes", Mes, False))
        paramList.Add(New ReportParameter("Año", Año, False))
        paramList.Add(New ReportParameter("c_codi_mon", c_codi_mon, False))
        paramList.Add(New ReportParameter("cOpcion", cOpcion, False))
        paramList.Add(New ReportParameter("c_codi_tg", c_codi_tg, False))
        paramList.Add(New ReportParameter("c_codi_cd", c_codi_cd, False))
        paramList.Add(New ReportParameter("Almacen", almacen, False))
        paramList.Add(New ReportParameter("c_desc_tg", c_desc_tg, False))
        paramList.Add(New ReportParameter("c_codi_sunat", c_codi_sunat, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()
    End Sub
    ' Reporte de Hojas de Resumen '
    Public Sub Reporte_TransformaCompras(ByVal Titulo As String)
        Rpt02.ProcessingMode = ProcessingMode.Remote
        Rpt02.ServerReport.ReportServerUrl = New Uri(FrmMenu.LblRutaReport.Text)
        Rpt02.ServerReport.ReportPath = FrmMenu.TxtRptCarpeta.Text & "Scal_RptTransCompra"


        Dim paramList As New Generic.List(Of ReportParameter)
        paramList.Add(New ReportParameter("Empresa", FrmMenu.TxtEmpresa.Text, False))
        paramList.Add(New ReportParameter("Titulo", Titulo, False))

        Rpt02.ServerReport.Refresh()
        Rpt02.ServerReport.SetParameters(paramList)

        Rpt02.SetDisplayMode(DisplayMode.PrintLayout)
        Rpt02.ZoomMode = ZoomMode.Percent
        Rpt02.ZoomPercent = Val(FrmMenu.TxtZoom.Text)
        Me.Show()

    End Sub
End Class