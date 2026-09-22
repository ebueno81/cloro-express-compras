Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_OQDet
    Dim c_OQDet As New Cls_OQDet
    Public Function set_OQDet_Save(ByVal c_Entidades As Ent_OQDet, ByVal Emp As String)
        Return c_OQDet.spro_OQDet_SAVE(c_Entidades, Emp)
    End Function
    Public Function get_OQDet_Datos(ByVal Cadena As String, ByVal Emp As String, ByVal vOpt As String) As DataTable
        Return c_OQDet.Get_OQDet_Datos(Cadena, Emp, vOpt)
    End Function
End Class
