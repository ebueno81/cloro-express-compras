Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_CostosDet
    Dim c_CostosDet As New Cls_CostosDet
    Public Function set_CostosDet_Save(ByVal c_Entidades As Ent_CostosDet)
        Return c_CostosDet.Scom_CostosDet_SAVE(c_Entidades)
    End Function
    'Datos de leasing detalles...
    Public Function get_CostosDet_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_CostosDet.Get_CostosDet_Datos(Cadena, vOpt)
    End Function
End Class
