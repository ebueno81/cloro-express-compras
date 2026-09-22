Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_NotaC
    Dim c_NotaC As New Cls_NotaC
    Public Function set_NotaC_Save(ByVal c_Entidades As Ent_NotaC, ByVal c_codi_emp As String)
        Return c_NotaC.scom_NotaC_SAVE(c_Entidades, c_codi_emp)
    End Function
    Public Function get_NotaC_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_NotaC.Get_NotaC_Datos(Cadena, vOpt, Emp)
    End Function
    Public Function get_NotaCVentas_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_NotaC.Get_NotaCVentas_Datos(Cadena, vOpt, Emp)
    End Function
End Class
