Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_OC
    Dim c_OC As New Cls_OC
    Public Function set_OC_Save(ByVal c_Entidades As Ent_OC, ByVal c_codi_emp As String)
        Return c_OC.scom_OC_SAVE(c_Entidades, c_codi_emp)
    End Function
    'Datos de orden de compra...
    Public Function get_OC_Datos(ByVal Cadena As String, ByVal c_codi_emp As String, ByVal vOpt As String) As DataTable
        Return c_OC.Get_OC_Datos(Cadena, c_codi_emp, vOpt)
    End Function
End Class
