Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnUniMed
    Dim c_UniMed As New Cls_MnUniMed
    Public Function set_UniMed_Save(ByVal c_Entidades As Ent_MnUniMed)
        Return c_UniMed.set_UniMed_Save(c_Entidades)
    End Function
    Public Function get_UniMed_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_UniMed.Get_UniMed_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_UniMed_Cbo(ByVal Cadena As String, ByVal Combo1 As ComboBox)
        c_UniMed.Get_Cargar_UniMed_Cbo(Cadena, Combo1)
    End Function
End Class
