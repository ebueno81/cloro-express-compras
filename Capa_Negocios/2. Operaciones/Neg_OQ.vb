Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_OQ
    Dim c_OQ As New cLS_OQ
    Public Function set_OQ_Save(ByVal c_Entidades As Ent_OQ, ByVal c_codi_emp As String)
        Return c_OQ.scom_OQ_SAVE(c_Entidades, c_codi_emp)
    End Function
    Public Function get_OQ_Datos(ByVal Cadena As String, ByVal c_codi_emp As String, ByVal vOpt As String) As DataTable
        Return c_OQ.Get_OQ_Datos(Cadena, c_codi_emp, vOpt)
    End Function
End Class
