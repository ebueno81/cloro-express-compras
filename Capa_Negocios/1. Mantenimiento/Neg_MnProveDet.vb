Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_MnProveDet
    Dim c_Proveedor As New Cls_MnProvedet
    Public Function set_ProveDet_Save(ByVal c_Entidades As Ent_MnProveDet)
        Return c_Proveedor.scom_ProveedorDet_Save(c_Entidades)
    End Function
    Public Function get_ProveDet_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_Proveedor.Get_ProveedorDet_Datos(Cadena, vOpt)
    End Function
End Class
