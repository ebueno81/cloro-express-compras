Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_IngAlmIQ
    Dim c_IngAlmIQ As New Cls_IngAlmIQ
    Public Function set_IngAlmIQ_Save(ByVal c_Entidades As Ent_IngAlmIQ, ByVal Emp As String)
        Return c_IngAlmIQ.set_IngAlmIQ_Save(c_Entidades, Emp)
    End Function
    Public Function get_IngAlmIQ_Datos(ByVal Cadena As String, ByVal Emp As String, ByVal vOpt As String) As DataTable
        Return c_IngAlmIQ.Get_IngAlm_Datos(Cadena, Emp, vOpt)
    End Function
    Public Function get_IngAlm_Rpt(ByVal c_fecha_inicio As Date, ByVal c_fecha_final As Date, ByVal c_codi_mt As String, ByVal c_codi_prov As String,
                                       ByVal c_codi_tg As String, ByVal c_codi_cd As String, ByVal c_codi_scd As String,
                                        ByVal c_nro_ing As String, ByVal c_serie_guia As String, ByVal c_nro_guia As String,
                                         ByVal c_serie_doc As String, ByVal c_nro_doc As String, ByVal c_codi_mon As String,
                                    ByVal c_opc_noingsal As String, ByVal c_codi_alm As String, ByVal cOpcion As String) As DataTable
        Return c_IngAlmIQ.Get_IngAlmRpt_Datos(c_fecha_inicio, c_fecha_final, c_codi_mt, c_codi_prov, c_codi_tg, c_codi_cd, c_codi_scd, c_nro_ing,
                                              c_serie_guia, c_nro_guia, c_serie_doc, c_nro_doc, c_codi_mon, c_opc_noingsal, c_codi_alm, cOpcion)
    End Function
End Class
