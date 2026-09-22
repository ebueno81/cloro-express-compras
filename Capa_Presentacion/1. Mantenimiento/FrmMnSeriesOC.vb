Imports Capa_Negocios
Imports Capa_Entidades
Public Class FrmMnSeriesOC
    Dim c_Neg_Series As New Neg_MnOcSerie

    Private Sub FrmMnSalSeries_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmMnSalSeries_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmMnSalSeries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dgv01.DataSource = c_Neg_Series.get_OCSerie_Dgv(" and c_anula_reg=0 order by c_nro_serie")
        With Dgv01
            .Columns("Serie").Width = 45
            .Columns("Descripcion").Width = 280
        End With
    End Sub
End Class