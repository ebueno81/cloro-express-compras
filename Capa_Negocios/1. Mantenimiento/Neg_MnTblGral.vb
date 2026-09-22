Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnTblGral
    Dim c_TblGral As New Cls_MnTblGral
    Public Function set_TblGral_Save(ByVal c_Entidades As Ent_MnTblGral)
        Return c_TblGral.scom_TblGral(c_Entidades)
    End Function
    Public Function get_TblGral_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_TblGral.Get_TblGral_Datos(Cadena, vOpt)
    End Function
    'Cargamos Registros al ComboBox...
    Public Function Get_TblGral_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_TblGral.Get_Cargar_TblGral_Cbo(Cadena, Combo)
    End Function
End Class
