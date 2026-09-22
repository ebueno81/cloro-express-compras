Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_CostosDocs
    Dim c_CostosDocs As New Cls_CostosDocs
    Public Function set_CostosDocs_Save(ByVal c_Entidades As Ent_CostosDocs)
        Return c_CostosDocs.Scom_CostosDocs_SAVE(c_Entidades)
    End Function
    'Datos de costos detalles...
    Public Function get_CostosDocs_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_CostosDocs.Get_CostosDocs_Datos(Cadena, vOpt)
    End Function
End Class
