Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnLinea
    Dim c_Linea As New Cls_MnLinea
    Public Function set_Linea_Save(ByVal c_Entidades As Ent_MnLinea)
        Return c_Linea.set_Linea(c_Entidades)
    End Function
    Public Function get_Linea_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Linea.Get_Linea_Datos(Cadena, vOpt)
    End Function
    Public Function get_Linea_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        Return c_Linea.get_Linea_Cbo(Cadena, Combo)
    End Function
 End Class
