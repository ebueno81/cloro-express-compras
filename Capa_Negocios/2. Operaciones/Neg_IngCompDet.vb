Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_IngCompDet
    Dim c_IngCompDet As New Cls_IngCompDet
    Public Function set_IngCompDet_Save(ByVal c_Entidades As Ent_IngCompDet, ByVal c_codi_emp As String)
        Return c_IngCompDet.scom_IngCompDet_SAVE(c_Entidades, c_codi_emp)
    End Function
    Public Function get_IngCompDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_IngCompDet.Get_IngComp_Datos(Cadena, vOpt, Emp)
    End Function
End Class
