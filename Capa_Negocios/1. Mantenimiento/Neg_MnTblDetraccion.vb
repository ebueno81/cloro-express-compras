Imports Capa_Acceso
Imports Capa_Entidades
Imports System.Windows.Forms
Public Class Neg_MnTblDetraccion
    Dim c_Neg_MnTblDetraccion As New Cls_MnTblDetraccion
    Public Function set_MnTblDetraccion_Save(ByVal c_Entidades As Ent_MnTblDetraccion)
        Return c_Neg_MnTblDetraccion.scom_Detraccion_Save(c_Entidades)
    End Function
    Public Function get_MntblDetraccion_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Neg_MnTblDetraccion.Get_Detraccion_Datos(Cadena, vOpt)
    End Function
    Public Function Get_MntblDetraccion_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        c_Neg_MnTblDetraccion.Get_Cargar_TblDetraccion_Cbo(Cadena, Combo)
    End Function
End Class
