Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnOcSerie
    Dim c_OCNSerie As New Cls_MnOCSerie
    Public Function get_OCSerie_Datos(ByVal Cadena As String) As DataTable
        Return c_OCNSerie.Get_OCSerie_Datos(Cadena)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_OCSerie_Cbo(ByVal Cadena As String, ByVal Tipo As Integer, ByVal Combo As ComboBox)
        c_OCNSerie.Get_Cargar_OCSerie_Cbo(Cadena, Tipo, Combo)
    End Function
    'Cargamos datos de Serie...
    Public Function get_OCSerie_Dgv(ByVal Cadena As String) As DataTable
        Return c_OCNSerie.Get_OCSerie_Dgv(Cadena)
    End Function
End Class
