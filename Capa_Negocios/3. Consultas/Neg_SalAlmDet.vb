Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_SalAlmDet
    Dim c_SalAlmDet As New Cls_SalAlmDet
    ' Public Function set_SalAlmDet_Save(ByVal c_Entidades As Ent_SalAlmDet)
    '    Return c_SalAlmDet.scom_SalAlmDet_SAVE(c_Entidades)
    'End Function
    Public Function get_SalAlmDet_Dgv(ByVal Cadena As String) As DataTable
        Return c_SalAlmDet.Get_SalAlmDet_GRID(Cadena)
    End Function
    Public Function get_SalAlmDet_Datos(ByVal Cadena As String) As DataTable
        Return c_SalAlmDet.Get_SalAlmDet_Datos(Cadena)
    End Function
    Public Function get_SalAlmDetCostos_Datos(ByVal Cadena As String) As DataTable
        Return c_SalAlmDet.Get_SalAlmDetCostos_Datos(Cadena)
    End Function
    Public Function get_SalAlmDetMP_DGV(ByVal Cadena As String) As DataTable
        Return c_SalAlmDet.Get_SalAlmDetMP_GRID(Cadena)
    End Function
End Class
