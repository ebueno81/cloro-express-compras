Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnAlmacen
    Dim c_Almacen As New Cls_MnAlmacen
    Public Function set_Almacen_Save(ByVal c_Entidades As Ent_MnAlmacen)
        Return c_Almacen.set_Almacen_Save(c_Entidades)
    End Function
    Public Function get_Almacen_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        Return c_Almacen.Get_Cargar_Almacen_Cbo(Cadena, Combo)
    End Function
    Public Function get_Almacen_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Almacen.Get_Almacen_Datos(Cadena, vOpt)
    End Function

End Class
