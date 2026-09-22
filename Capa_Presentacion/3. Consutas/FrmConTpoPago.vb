Public Class FrmConTpoPago
    Dim x As Integer = 0 : Dim Foco As Integer = 0
    Private Sub FrmConTpoPago_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FrmMenu.Enabled = True
        'ingreso de documentos...
        If Val(TxtVar.Text) = 1 Then
            FrmIngComp.BtnConTpoDoc.Focus()
        End If
        ' Validamos consulta de forma de pago orden de compra '
        If Val(TxtVar.Text) = 2 Then
            FrmOC.CboSerie_Oq.Focus()
        End If
    End Sub

    Private Sub FrmConTpoPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConTpoPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmConTpoPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnTpoPago.get_TpoPago_Datos(Cadena, "DGV")
        With Dgv01
            .Columns("Codigo").Width = 60
            .Columns("Descripcion").Width = 280
            .Columns("Dias").Width = 50
            .Columns("c_anula_reg").Visible = False
            'Alineacion
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub TxtBus_Art_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBus_Art.GotFocus
        With Dgv01
            If .RowCount > 0 Then
                If .CurrentCell.RowIndex > -1 Then
                    x = .CurrentCell.RowIndex : .CurrentCell = Dgv01(Dgv01.CurrentRow.Cells(0).ColumnIndex, x)
                End If
            End If
        End With
    End Sub

    Private Sub TxtBus_Art_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Art.KeyDown
        With Dgv01
            If .RowCount > 0 Then
                x = .CurrentCell.RowIndex
                If e.KeyCode = Keys.Down Then
                    e.Handled = True : Foco = 1 : x += 1 : Call Movilizar_Grid(Dgv01, x, "ABAJO")
                End If
                If e.KeyCode = Keys.Up Then
                    Foco = 1 : e.Handled = True : x -= 1 : Call Movilizar_Grid(Dgv01, x, "ARRIBA")
                End If
                If e.KeyCode = Keys.Enter Then
                    If Foco = 1 Then Call Dgv01_DoubleClick(Nothing, Nothing)
                End If
            End If
        End With 'Mostramos los datos al presionar la tecla enter
    End Sub
    Private Sub TxtBus_Art_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Art.TextChanged
        Call Cargar_Grid(" and c_anula_reg=0 and c_desc_pago like '%" & TxtBus_Art.Text & "%' order by c_desc_pago")
    End Sub
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    'ingreso de comprobantes...
                    If Val(TxtVar.Text) = 1 Then
                        FrmIngComp.TxtFPago.Text = .Rows(fila).Cells("descripcion").Value
                        FrmIngComp.TxtCod_Fpago.Text = .Rows(fila).Cells("codigo").Value
                        FrmIngComp.TxtDias.Text = Val(.Rows(fila).Cells("dias").Value)
                        FrmIngComp.DtpFec_Venci.Text = DateAdd("d", Val(.Rows(fila).Cells("dias").Value), FrmIngComp.DtpFec_Emi.Text)
                    End If
                    'Orden de Compra...
                    If Val(TxtVar.Text) = 2 Then
                        FrmOC.TxtFPago.Text = .Rows(fila).Cells("descripcion").Value
                        FrmOC.TxtCod_Pago.Text = .Rows(fila).Cells("codigo").Value
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class