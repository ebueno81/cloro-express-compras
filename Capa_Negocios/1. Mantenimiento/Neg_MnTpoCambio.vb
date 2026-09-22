Imports Capa_Entidades
Imports Capa_Acceso
Public Class Neg_MnTpoCambio
    Dim c_tpocambio As New Cls_MnTpoCambio
    Public Function set_TpoCambio_Save(ByVal c_Entidades As Ent_TpoCambio)
        Return c_tpocambio.scom_TpoCambio_Save(c_Entidades)
    End Function
    Public Function set_ActuMasivoTpoCambio_Save(ByVal c_fecha_inicio As String, ByVal c_fecha_final As String)
        Return c_tpocambio.scom_ActuMasivoTpoCambio_Save(c_fecha_inicio, c_fecha_final)
    End Function
    Public Function get_TpoCambio_Datos(ByVal Cadena As String, ByVal vOpt As String) As DataTable
        Return c_tpocambio.Get_TpoCambio_Datos(Cadena, vOpt)
    End Function

End Class
