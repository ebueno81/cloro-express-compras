Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnBcos
    Dim c_MnBcos As New Cls_MnBancos
    Public Function get_MnBcos_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_MnBcos.Get_Bcos_Datos(Cadena, vOpt)
    End Function
    Public Function get_MnBcos_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        Return c_MnBcos.Get_Cargar_Bcos_Cbo(Cadena, Combo)
    End Function
End Class
