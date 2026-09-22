Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_Cierres
    Dim c_Cierres As New Cls_Cierres
    Public Function set_Usuario_Save(ByVal c_Entidades As Ent_Cierres)
        Return c_Cierres.scom_Cierres_Save(c_Entidades)
    End Function
    Public Function get_Cierres_Datos(ByVal Cadena As String) As DataTable
        Return c_Cierres.Get_Cierres_Datos(Cadena)
    End Function
    Public Function get_Cierres_Dgv(ByVal Cadena As String) As DataTable
        Return c_Cierres.Get_Cierres_Dgv(Cadena)
    End Function
End Class
