Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_DuasCab
    Dim c_DuasCab As New Cls_DuasCab
    Public Function set_DuasCab_Save(ByVal c_Entidades As Ent_DuasCab)
        Return c_DuasCab.Scom_DuasCab_SAVE(c_Entidades)
    End Function
    'Datos de leasing cabecera...
    Public Function get_DuasCab_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_DuasCab.Get_DuasCab_Datos(Cadena, vOpt)
    End Function
End Class
