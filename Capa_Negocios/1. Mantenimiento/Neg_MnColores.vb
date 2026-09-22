Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_MnColores
    Dim c_Colores As New Cls_MnColores
    Public Function set_Caidas_Save(ByVal c_Entidades As Ent_MnColores)
        Return c_Colores.spro_Colores_Save(c_Entidades)
    End Function
    Public Function get_Colores_Dgv(ByVal Cadena As String) As DataTable
        Return c_Colores.Get_Colores_GRID(Cadena)
    End Function
    Public Function get_Colores_Datos(ByVal Cadena As String) As DataTable
        Return c_Colores.Get_Colores_DATOS(Cadena)
    End Function

End Class
