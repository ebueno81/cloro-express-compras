Imports Capa_Acceso
Imports Capa_Entidades
Public Class Neg_DetracDet
    Dim c_DetracDet As New Cls_DetracDet
    Public Function set_DetracDet_Save(ByVal c_Entidades As Ent_DetracDet)
        Return c_DetracDet.scom_Detrac_SAVE(c_Entidades)
    End Function
    Public Function set_DetracCancel_Save(ByVal c_Entidades As Ent_DetracCancel)
        Return c_DetracDet.scom_DetracCancel_SAVE(c_Entidades)
    End Function
    Public Function get_DetracDet_Datos(ByVal Cadena As String) As DataTable
        Return c_DetracDet.Get_DetracDet_Datos(Cadena)
    End Function
End Class
