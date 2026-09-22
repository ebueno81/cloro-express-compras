Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_CostosCab
    Dim c_CostosCab As New Cls_CostosCab
    Public Function set_CostosCab_Save(ByVal c_Entidades As Ent_CostosCab)
        Return c_CostosCab.Scom_CostosCab_SAVE(c_Entidades)
    End Function
    'Datos costos cabecera...
    Public Function get_CostosCab_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_CostosCab.Get_CostosCab_Datos(Cadena, vOpt)
    End Function
End Class
