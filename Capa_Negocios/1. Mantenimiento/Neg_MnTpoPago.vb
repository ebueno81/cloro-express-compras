Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_MnTpoPago
    Dim c_mntpopago As New Cls_MnTpoPagos
    Public Function set_TpoPago_Save(ByVal c_Entidades As Ent_MnTpoPago)
        Return c_mntpopago.scom_TpoPago_Save(c_Entidades)
    End Function
    Public Function get_TpoPago_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_mntpopago.Get_TpoPago_Datos(Cadena, vOpt)
    End Function
End Class
