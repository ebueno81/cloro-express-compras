Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_IngAlmIQDet
    Dim c_IngAlmDetIQ As New Cls_IngAlmIQDet
    Public Function set_IngAlmIQDet_Save(ByVal c_Entidades As Ent_IngAlmIQDet, ByVal Emp As String)
        Return c_IngAlmDetIQ.set_AlmIngDet_Save(c_Entidades, Emp)
    End Function
    Public Function get_IngAlmIQDet_Datos(ByVal Cadena As String, ByVal c_codi_emp As String, ByVal vOpt As String) As DataTable
        Return c_IngAlmDetIQ.Get_IngAlmDet_DATOS(Cadena, c_codi_emp, vOpt)
    End Function
End Class
