Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnOQSerie
    Dim c_OQNSerie As New Cls_MnOQSerie
    Public Function get_OQSerie_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_OQNSerie.Get_OQSerie_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_OQSerie_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_OQNSerie.Get_Cargar_OQSerie_Cbo(Cadena, Combo)
    End Function
End Class
