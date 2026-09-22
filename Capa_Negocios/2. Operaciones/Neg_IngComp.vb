Imports Capa_Entidades
Imports Capa_Acceso
Imports System.Windows.Forms
Public Class Neg_IngComp
    Dim c_IngComp As New Cls_IngComp
    Public Function set_IngComp_Save(ByVal c_Entidades As Ent_IngComp, ByVal Emp As String)
        Return c_IngComp.scom_IngComp_SAVE(c_Entidades, Emp)
    End Function
    Public Function set_IngCompOC_Save(ByVal c_Entidades As Ent_IngCompOC, ByVal Emp As String)
        Return c_IngComp.scom_IngCompOC_SAVE(c_Entidades, Emp)
    End Function
    Public Function get_IngComp_Datos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_IngComp.Get_IngComp_Datos(Cadena, vOpt, Emp)
    End Function
    Public Function get_IngComp_DatosOC(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_IngComp.Get_IngCompOC_Datos(Cadena, vOpt, Emp)
    End Function
    Public Function get_IngComp_DatosPagos(ByVal Cadena As String, ByVal vOpt As String, ByVal Emp As String) As DataTable
        Return c_IngComp.Get_IngCompPagos_Datos(Cadena, vOpt, Emp)
    End Function
    Public Function get_CargarHistorialCancel_Cbo(ByVal Cadena As String, ByVal Combo As ComboBox)
        Return c_IngComp.Get_Cargar_HistorialCancelacion_Cbo(Cadena, Combo)
    End Function
End Class
