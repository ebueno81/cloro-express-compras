Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_LetCab
    Dim c_LetCab As New Cls_LetCab
    Public Function set_LetCab_Save(ByVal c_Entidades As Ent_LetCab, ByVal c_codi_emp As String)
        Return c_LetCab.scom_LetCab_SAVE(c_Entidades, c_codi_emp)
    End Function
    Public Function get_LetCab_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal c_codi_emp As String) As DataTable
        Return c_LetCab.Get_LetCab_Datos(Cadena, vOpt, c_codi_emp)
    End Function
End Class
