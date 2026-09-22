Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnTpoDoc
    Dim c_MnTpoDoc As New Cls_MnTpoDoc
    Public Function set_TpoPago_Save(ByVal c_Entidades As Ent_MnTpoDoc)
        Return c_MnTpoDoc.scom_TpoPago_Save(c_Entidades)
    End Function
    Public Function get_TpoPago_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_MnTpoDoc.Get_TpoDoc_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_TpoDoc_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_MnTpoDoc.Get_Cargar_TpoDoc_Cbo(Cadena, Combo)
    End Function
End Class


