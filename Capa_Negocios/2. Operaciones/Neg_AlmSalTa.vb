Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_AlmSalTa
    Dim c_AlmSalTa As New Cls_AlmSalTa
    Public Function get_AlmSalTa_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_AlmSalTa.Get_AlmSalTa_Datos(Cadena, vOpt, Emp)
    End Function
    Public Function get_AlmSalTa_Rpt(ByVal c_nro_serie As String, ByVal c_nro_salidaTa As String, ByVal c_nro_ingreso As String, ByVal c_fecha_inicio As Date, _
                                     ByVal c_fecha_final As Date, ByVal c_codi_clie As String, ByVal c_anula_reg As String, ByVal vOpt As String) As DataTable
        Return c_AlmSalTa.Get_AlmSalTa_Rpt(c_nro_serie, c_nro_salidaTa, c_nro_ingreso, c_fecha_inicio, c_fecha_final, c_codi_clie, c_anula_reg, vOpt)
    End Function
End Class
