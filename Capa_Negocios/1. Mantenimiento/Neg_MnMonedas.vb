Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnMonedas
    Dim c_monedas As New Cls_MnMonedas
    'Cargamos Registros al ComboBox...
    Public Function Get_Moneda_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_monedas.Get_Cargar_Moneda_Cbo(Cadena, Combo)
    End Function
End Class
