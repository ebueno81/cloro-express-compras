Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnPresenta
    Dim c_Presenta As New Cls_MnPresenta
    Public Function set_Presenta_Save(ByVal c_Entidades As Ent_MnPresenta)
        Return c_Presenta.set_Presenta(c_Entidades)
    End Function
    Public Function get_Presenta_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Presenta.Get_Presenta_Datos(Cadena, vOpt)
    End Function
    Public Function get_Presenta_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        Return c_Presenta.get_Presenta_Cbo(Cadena, Combo)
    End Function
End Class
