Imports Capa_Negocios
Public Class FrmConArtListar
    Dim c_Neg_SCaidas As New Neg_Scaidas
    Dim c_Neg_Almacen As New Neg_MnAlmacen

    Private Sub FrmConStockArt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConStockArt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmConStockArt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CboOrden.SelectedIndex = 0
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_SCaidas.get_sCaidas_Datos(Cadena, "DG3")
        With Dgv01
            '.Columns("Alm.").Width = 30
            .Columns("Tg").Width = 45
            .Columns("Cd").Width = 45
            .Columns("Scd").Width = 70
            .Columns("Descripcion").Width = 450
            '.Columns("Partida").Width = 70
            .Columns("Codigo IQ").Width = 100
            '.Columns("Stock").Width = 80
            '.Columns("Precio").Width = 80
            '.Columns("importe").Width = 80
            'alineacion
            ' .Columns("Alm.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Tg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Scd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo IQ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Partida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Unid.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '.Columns("Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            '.Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            'color
            '.Columns("Alm.").HeaderCell.Style.BackColor = Color.Yellow
            '.Columns("Alm.").HeaderCell.Style.ForeColor = Color.Blue
            .Columns("Descripcion").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Descripcion").HeaderCell.Style.ForeColor = Color.Blue
        End With
    End Sub

    Private Sub BtnBus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBus.Click
        Call Cargar_Grid(" and S.c_anula_reg=0 and S.c_codi_tg ='" & TxtCod_Tg.Text & "' and S.c_codi_cd ='" & TxtCod_Cd.Text & _
                                                                 "' and S.c_desc_scd like '%" & TxtScd.Text & "%' order by S.c_desc_scd ")
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub BtnCon3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon3.Click
        FrmConTg.Show() : FrmConTg.Cargar_Grid(" and c_anula_reg=0  order by c_desc_tg")
        FrmConTg.TxtVar.Text = 2
    End Sub

    Private Sub TxtTg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtTg.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon3.Enabled = True Then Call BtnCon3_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtTg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTg.TextChanged

    End Sub

    Private Sub BtnCon2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon2.Click
        FrmConCd.Show()
        FrmConCd.Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "'  order by c_desc_cd")
        FrmConCd.TxtVar.Text = 2
        FrmConCd.TxtCod_Tg.Text = TxtCod_Tg.Text
    End Sub
    Private Sub TxtCd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCd.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon2.Enabled = True Then Call BtnCon2_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        FrmConScd.Show()
        FrmConScd.Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' and c_codi_cd='" & TxtCod_Cd.Text & "'  order by c_desc_scd")
        FrmConScd.TxtVar.Text = 2
        FrmConScd.TxtCod_Tg.Text = TxtCod_Tg.Text
        FrmConScd.TxtCod_Cd.Text = TxtCod_Cd.Text
    End Sub

    Private Sub TxtScd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtScd.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon1.Enabled = True Then Call BtnCon1_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtScd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtScd.TextChanged

    End Sub
End Class