Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_OCDet
    Dim c_OCDet As New Cls_OCDet
    Public Function set_OCDet_Save(ByVal c_Entidades As Ent_OCDet, ByVal c_codi_emp As String)
        Return c_OCDet.scom_OCDet_SAVE(c_Entidades, c_codi_emp)
    End Function
    Public Function get_OCDet_Datos(ByVal Cadena As String, ByVal c_codi_emp As String, ByVal vOpt As String) As DataTable
        Return c_OCDet.Get_OCDet_Datos(Cadena, c_codi_emp, vOpt)
    End Function
End Class
