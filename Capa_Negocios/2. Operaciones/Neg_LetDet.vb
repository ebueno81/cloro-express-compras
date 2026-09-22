Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_LetDet
    Dim c_LetDet As New Cls_LetDet
    Public Function set_LetDet_Save(ByVal c_Entidades As Ent_LetDet, ByVal c_codi_emp As String)
        Return c_LetDet.scom_LetDet_SAVE(c_Entidades, c_codi_emp)
    End Function
    Public Function get_LetDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_LetDet.Get_LetDet_Datos(Cadena, vOpt, Emp)
    End Function
  
End Class
