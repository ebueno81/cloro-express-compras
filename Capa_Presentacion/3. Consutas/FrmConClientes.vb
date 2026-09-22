Imports Capa_Negocios
Public Class FrmConClientes
    Dim c_Neg_Clientes As New Neg_MnCliente : Dim x As Integer = 0 'Trabaja con la movilizacion del grid
    Dim foco As Integer = 0 '

    Private Sub FrmConClientes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Val(TxtVar.Text) = 1 Then
            FrmAlmIngIQ.TxtObs.Focus()
        End If
    End Sub
    Private Sub FrmConClientes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConClientes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmConClientes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_Clientes.get_Cliente_Datos(Cadena, "DG3")
        With Dgv01
            .Columns("Codigo").Width = 60
            .Columns("Cliente").Width = 320
            .Columns("R.U.C.").Width = 90
            .Columns(0).HeaderCell.Style.BackColor = Color.Yellow
            .Columns(0).HeaderCell.Style.ForeColor = Color.Blue
            ' Alineacion '
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("R.U.C.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub TxtBuscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBuscar.GotFocus
        With Dgv01
            If .RowCount > 0 Then
                If .CurrentCell.RowIndex > -1 Then
                    x = .CurrentCell.RowIndex : On Error Resume Next
                    .CurrentCell = Dgv01(Dgv01.CurrentRow.Cells("Art.").ColumnIndex, x)
                End If
            End If
        End With
    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        With Dgv01
            If .RowCount > 0 Then
                x = .CurrentCell.RowIndex
                If e.KeyCode = Keys.Down Then
                    e.Handled = True : foco = 1 : x += 1 : Call Movilizar_Grid(Dgv01, x, "ABAJO")
                End If
                If e.KeyCode = Keys.Up Then
                    foco = 1 : e.Handled = True : x -= 1 : Call Movilizar_Grid(Dgv01, x, "ARRIBA")
                End If
                If e.KeyCode = Keys.Enter Then
                    Call Dgv01_DoubleClick(Nothing, Nothing)
                End If
            End If
        End With 'Mostramos los datos al presionar la tecla enter
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        Call Cargar_Grid(" and c_anula_reg=0 and c_desc_clie like '%" & TxtBuscar.Text & "%' order by c_desc_clie ")
    End Sub

    Private Sub Dgv01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.Click
        Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    'ingreso de retencion...
                    If Val(TxtVar.Text) = 1 Then
                        'FrmRetencion.TxtCod_Clie.Text = .Rows(fila).Cells("Codigo").Value
                        With c_Neg_Clientes.get_Cliente_Datos(" and c_codi_clie='" & .Rows(fila).Cells("Codigo").Value & "' ", "DAT")
                            If .Rows.Count > 0 Then
                                FrmAlmIngIQ.TxtCod_Prove.Text = .Rows(0)("c_codi_clie").ToString
                                'FrmAlmIngIQ.TxtRuc.Text = .Rows(0)("c_ruc_clie").ToString
                                FrmAlmIngIQ.TxtProve.Text = .Rows(0)("c_desc_clie").ToString
                                ' FrmRetencion.Mostrar_Documentos()
                            End If
                        End With
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub
    'mostramos al dar doble clic
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Dgv01_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class