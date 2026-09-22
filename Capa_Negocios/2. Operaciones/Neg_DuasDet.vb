Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_DuasDet
    Dim c_DuasDet As New Cls_DuasDet
    Public Function set_DuaDet_Save(ByVal c_Entidades As Ent_DuasDet)
        Return c_DuasDet.Scom_DuasDet_SAVE(c_Entidades)
    End Function
    'Datos de leasing detalles...
    Public Function get_DuaDet_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_DuasDet.Get_DuasDet_Datos(Cadena, vOpt)
    End Function
End Class
