Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_NotaCDet
    Dim c_NotaCDet As New Cls_NotaCDet
    Public Function set_NotaCDet_Save(ByVal c_Entidades As Ent_NotaCDet, ByVal c_codi_emp As String)
        Return c_NotaCDet.scom_IngCompDet_SAVE(c_Entidades, c_codi_emp)
    End Function
    Public Function get_NotaCDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_NotaCDet.Get_NotaCDet_Datos(Cadena, vOpt, Emp)
    End Function
End Class
