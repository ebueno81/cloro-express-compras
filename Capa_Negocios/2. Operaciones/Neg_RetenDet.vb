Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_RetenDet
    Dim c_RetenDet As New Cls_RetenDet
    Public Function set_RetenDet_Save(ByVal c_Entidades As Ent_RetenDet, ByVal Emp As String)
        Return c_RetenDet.Sca_RetenDet_Save(c_Entidades, Emp)
    End Function
    Public Function get_RetenDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_RetenDet.Get_RetenDet_Datos(Cadena, vOpt, Emp)
    End Function
End Class
