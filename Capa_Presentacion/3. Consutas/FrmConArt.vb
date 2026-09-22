Public Class FrmConArt
    Dim x As Integer = 0 : Dim Foco As Integer = 0

    Private Sub FrmConArt_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' Kardex de unidades fisicas '
        If Val(TxtVar.Text) = 1 Then
            FrmRptKardex.CboAlm.Focus()
        End If
        ' Kardex Valorizado '
        If Val(TxtVar.Text) = 2 Then
            FrmRptKardex.CboAlm.Focus()
        End If

    End Sub

    Private Sub FrmConArticulos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConArticulos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    'Cargamos grid
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnArticulo.get_Articulo_Datos(Cadena, "DG3")
        With Dgv01
            ' Ajustamos el ancho de las columnas '
            .Columns("Mot").Width = 50
            .Columns("Cd").Width = 50
            .Columns("SCd").Width = 50
            .Columns("Codigo").Width = 70
            .Columns("Articulo").Width = 280
            ' Alineacion '
            .Columns("Mot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("SCd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' Coloreamos Cabecera '
            .Columns("Articulo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Articulo").HeaderCell.Style.ForeColor = Color.Blue
            .Columns("Articulo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        End With
    End Sub

    Private Sub TxtBus_Art_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBus_Art.GotFocus
        With Dgv01
            'On Error Resume Next
            If .RowCount > 0 Then
                If .CurrentCell.RowIndex > -1 Then
                    x = .CurrentCell.RowIndex : .CurrentCell = Dgv01(Dgv01.CurrentRow.Cells(0).ColumnIndex, x)
                End If
            End If
        End With
    End Sub

    Private Sub TxtBus_Art_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Art.KeyDown
        With Dgv01
            ' Dim caja As New TextBox
            If .RowCount > 0 Then
                ' On Error Resume Next
                x = .CurrentCell.RowIndex
                If e.KeyCode = Keys.Down Then
                    e.Handled = True : Foco = 1
                    x += 1 : Call Movilizar_Grid(Dgv01, x, "ABAJO")
                End If
                If e.KeyCode = Keys.Up Then
                    Foco = 1 : e.Handled = True
                    x -= 1 : Call Movilizar_Grid(Dgv01, x, "ARRIBA")
                End If
                If e.KeyCode = Keys.Enter Then
                    If Foco = 1 Then
                        Call Dgv01_DoubleClick(Nothing, Nothing)
                    End If
                End If
            End If
        End With 'Mostramos los datos al presionar la tecla enter
    End Sub

    Private Sub TxtBus_Art_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Art.TextChanged
        Call Cargar_Grid(" and c_anula_reg=0 and c_desc_articulo like '" & TxtBus_Art.Text & _
                                                           "%'  order by c_desc_articulo")
    End Sub

    Private Sub FrmConArticulos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    ' Kardex de Unidades Fisicas '
                    If Val(TxtVar.Text) = 1 Then
                        FrmRptKardex.TxtCod_Articulo.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptKardex.TxtCod_Scd.Text = .Rows(fila).Cells("Scd").Value
                        FrmRptKardex.TxtCod_Cd.Text = .Rows(fila).Cells("Cd").Value
                        FrmRptKardex.TxtCod_Tg.Text = .Rows(fila).Cells("Mot").Value
                        FrmRptKardex.TxtArticulo.Text = .Rows(fila).Cells("Articulo").Value
                        FrmRptKardex.CboAlm.Focus()
                    End If
                    ' Kardex de Valorizado '
                    If Val(TxtVar.Text) = 2 Then
                        FrmRptKardexValor.TxtCod_Articulo.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptKardexValor.TxtCod_Scd.Text = .Rows(fila).Cells("Scd").Value
                        FrmRptKardexValor.TxtCod_Cd.Text = .Rows(fila).Cells("Cd").Value
                        FrmRptKardexValor.TxtCod_Tg.Text = .Rows(fila).Cells("Mot").Value
                        FrmRptKardexValor.TxtArticulo.Text = .Rows(fila).Cells("Articulo").Value
                        FrmRptKardexValor.CboAlm.Focus()
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub

    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.KeyCode = Keys.Enter Then Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub
End Class