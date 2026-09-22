Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_RetenCab
    Dim c_RetenCab As New Cls_RetenCab
    Public Function set_RetenCab_Save(ByVal c_Entidades As Ent_RetenCab, ByVal Emp As String)
        Return c_RetenCab.Sca_RetenCab_Save(c_Entidades, Emp)
    End Function
    Public Function get_RetenCab_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_RetenCab.Get_RetenCab_Datos(Cadena, vOpt, Emp)
    End Function
End Class
