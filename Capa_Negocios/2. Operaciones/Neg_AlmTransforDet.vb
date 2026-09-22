Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_AlmTransforDet
    Dim c_AlmTranforCab As New Cls_AlmTransforDet
    Public Function set_AlmTransforDet_Save(ByVal c_Entidades As Ent_AlmTransforDet)
        Return c_AlmTranforCab.set_AlmTransforDet_Save(c_Entidades)
    End Function
    Public Function get_AlmTransforDet_Datos(ByVal c_nro_transforma As String, ByVal vOpt As String) As DataTable
        Return c_AlmTranforCab.Get_AlmTransforDet_Datos(c_nro_transforma, vOpt)
    End Function
End Class
