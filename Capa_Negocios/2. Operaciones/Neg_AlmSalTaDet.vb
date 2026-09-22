Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_AlmSalTaDet
    Dim c_AlmSalTaDet As New Cls_AlmSalTaDet
    Public Function get_AlmSalTaDet_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_AlmSalTaDet.Get_AlmSalTaDet_Datos(Cadena, vOpt, Emp)
    End Function
End Class
