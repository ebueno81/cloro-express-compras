Imports Capa_Acceso
Public Class Neg_RptRegCompras
    Dim c_RptRegCompras As New Cls_RptRegCompras
    Public Function get_RptRegCompras_Rpt(ByVal Cadena As String, ByVal Fecha_Inicio As Date, ByVal Fecha_final As Date, _
                                          ByVal c_codi_mon As String, ByVal Emp As String) As DataTable
        Return c_RptRegCompras.Get_RptRegCompras_Rpt(Cadena, Fecha_Inicio, Fecha_final, c_codi_mon, Emp)
    End Function
    Public Function get_RptRegComprasTot_Rpt(ByVal Cadena As String, ByVal Fecha_Inicio As Date, ByVal Fecha_final As Date, _
                                          ByVal c_codi_mon As String, ByVal Emp As String) As DataTable
        Return c_RptRegCompras.Get_RptRegComprasTot_Rpt(Cadena, Fecha_Inicio, Fecha_final, c_codi_mon, Emp)
    End Function
    Public Function get_RptRegFactPend_Rpt(ByVal Fecha_Inicio As Date, ByVal Fecha_final As Date, _
                                          ByVal c_codi_prov As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_RptRegCompras.Get_RptRegDocPend_Rpt(Fecha_Inicio, Fecha_final, c_codi_prov, vOpt, Emp)
    End Function
    Public Function get_RptRegFactPendTotal_Rpt(ByVal Fecha_Inicio As Date, ByVal Fecha_final As Date, _
                                          ByVal c_codi_prov As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_RptRegCompras.Get_RptRegDocPendTotal_Rpt(Fecha_Inicio, Fecha_final, c_codi_prov, vOpt, Emp)
    End Function
    Public Function get_RptMovDet(ByVal Fecha_Inicio As Date, ByVal Fecha_final As Date, _
                                          ByVal c_codi_tg As String, ByVal c_codi_cd As String, ByVal c_codi_scd As String, _
                                          ByVal c_codi_mon As String, ByVal Emp As String) As DataTable
        Return c_RptRegCompras.Get_RptMovDet(Fecha_Inicio, Fecha_final, c_codi_tg, c_codi_cd, c_codi_scd, c_codi_mon, Emp)
    End Function
    Public Function get_RptMovTot(ByVal Fecha_Inicio As Date, ByVal Fecha_final As Date, _
                                        ByVal c_codi_tg As String, ByVal c_codi_cd As String, ByVal c_codi_scd As String, _
                                        ByVal c_codi_mon As String, ByVal Emp As String) As DataTable
        Return c_RptRegCompras.Get_RptMovTot(Fecha_Inicio, Fecha_final, c_codi_tg, c_codi_cd, c_codi_scd, c_codi_mon, Emp)
    End Function
    ' Reporte de Ingresos Listado '
    Public Function get_IngComp_Lista(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_RptRegCompras.Get_IngCompLista_Datos(Cadena, vOpt, Emp)
    End Function
End Class
