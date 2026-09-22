Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnCliente
    Dim c_Cliente As New Cls_MnCliente
    Public Function get_Cliente_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Cliente.Get_Cliente_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_Clientes_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_Cliente.Get_Cargar_Clientes_Cbo(Cadena, Combo)
    End Function
End Class
