Imports Capa_Acceso
Public Class Neg_Asientos_Cab
    Dim c_AsientosCab As New Cls_Asientos_Cab
    Public Function get_AsientosCab_Datos(ByVal c_codi_doc As String, ByVal c_Fecha_Inicio As Date, ByVal c_Fecha_final As Date) As DataTable
        Return c_AsientosCab.get_AsientosCab_Datos(c_codi_doc, c_Fecha_Inicio, c_Fecha_final)
    End Function
    Public Function set_AsientosCab_Save(ByVal c_nro_ing As String, ByVal Ccompro As String, ByVal codi_doc As String)
        Return c_AsientosCab.Sca_AsientosCab_Save(c_nro_ing, Ccompro, codi_doc)
    End Function
End Class
