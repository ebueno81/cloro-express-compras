Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_Leasing
    Dim c_LeasingCab As New Cls_LeasingCab
    Public Function set_Leasing_Save(ByVal c_Entidades As Ent_LeasingCab)
        Return c_LeasingCab.Scom_LeasingCab_SAVE(c_Entidades)
    End Function
    'Datos de leasing cabecera...
    Public Function get_LeasingCab_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_LeasingCab.Get_LeasingCab_Datos(Cadena, vOpt)
    End Function
End Class
