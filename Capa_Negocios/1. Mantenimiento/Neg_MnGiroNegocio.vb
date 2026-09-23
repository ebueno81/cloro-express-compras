Imports Capa_Acceso
Imports System.Windows.Forms

Public Class Neg_MnGiroNegocio

    Private Datos As New Cls_MnGiroNegocio


    Public Function Get_GiroNegocio_Datos(
        ByVal soloActivos As Boolean
    ) As DataTable

        Return Datos.Get_GiroNegocio_Datos(soloActivos)

    End Function


    Public Sub Get_GiroNegocio_Cbo(ByVal Cbo As ComboBox)

        Dim dt As DataTable = Get_GiroNegocio_Datos(True)

        Cbo.DataSource = dt

        Cbo.DisplayMember = "Descripcion"
        Cbo.ValueMember = "IdGiro"

        Cbo.SelectedIndex = -1

    End Sub

End Class