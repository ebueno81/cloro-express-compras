Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_LeasingDet
    Dim c_LeasingDet As New Cls_LeasingDet
    Public Function set_LeasingDet_Save(ByVal c_Entidades As Ent_LeasingDet)
        Return c_LeasingDet.Scom_LeasingDet_SAVE(c_Entidades)
    End Function
    Public Function set_LeasingDetCancel_Save(ByVal c_Entidades As Ent_LeasingDet)
        Return c_LeasingDet.Scom_LeasingDetCancel_SAVE(c_Entidades)
    End Function
    'Datos de leasing detalles...
    Public Function get_LeasingDet_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_LeasingDet.Get_LeasingDet_Datos(Cadena, vOpt)
    End Function
End Class
