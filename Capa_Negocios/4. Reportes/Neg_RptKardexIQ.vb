Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_RptKardexIQ
    Dim c_RptKardexIQkIQ As New Cls_RptKardexIQ
    Public Function get_KardexIQ_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_RptKardexIQkIQ.Get_KardexIQ_Datos(Cadena, vOpt)
    End Function
    Public Function set_ActualizarKdx_Save(ByVal c_fecha_ing As Date, ByVal c_codi_alm As String, ByVal c_codi_articulo As String)
        Return c_RptKardexIQkIQ.scal_ActualizarKdx_SAVE(c_fecha_ing, c_codi_alm, c_codi_articulo)
    End Function
    Public Function set_KdxValorEspecial_Rpt(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_alm As String,
                                              ByVal c_codi_articulo As String, ByVal cOpcion As String) As String
        Return c_RptKardexIQkIQ.scal_KdxValorEspecial_rpt(c_fecha_inicio, c_fecha_final, c_codi_alm, c_codi_articulo, cOpcion)
    End Function
End Class
