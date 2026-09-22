Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_Detrac
    Dim c_Detrac As New Cls_DetracCab
    Public Function set_Detrac_Save(ByVal c_Entidades As Ent_Detrac)
        Return c_Detrac.scom_Detrac_SAVE(c_Entidades)
    End Function
    Public Function get_Detrac_Datos(ByVal Cadena As String) As DataTable
        Return c_Detrac.Get_Detrac_Datos(Cadena)
    End Function
    Public Function get_Detrac_Rpt(ByVal Cadena As String) As DataTable
        Return c_Detrac.Get_Detrac_Reporte(Cadena)
    End Function
End Class
