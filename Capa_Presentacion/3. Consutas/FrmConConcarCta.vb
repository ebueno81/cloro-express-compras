Public Class FrmConConcarCta
    Dim x As Integer = 0 : Dim foco As Integer = 0

    Private Sub FrmConConcarCta_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Val(TxtVar1.Text) = 1 Then FrmMnCaidas.TxtCtaVenta.Focus() ' cta de compras
        If Val(TxtVar1.Text) = 2 Then FrmMnCaidas.TxtArea.Focus() ' cta de ventas
        If Val(TxtVar1.Text) = 3 Then FrmMnCaidas.TxtCosto.Focus() ' areas
        If Val(TxtVar1.Text) = 4 Then FrmMnCaidas.BtnGrabar.Focus() ' costo
    End Sub

    Private Sub FrmConConcarCta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub FrmConConcarCta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmConConcarCta_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
    ' Metodo para cargar grid '
    Public Sub Cargar_Grid(ByVal Cadena As String)
        If Val(TxtVar1.Text) = 1 Or Val(TxtVar1.Text) = 2 Then
            Call Mostrar_cuentas(Cadena, Dgv01)
        End If
        ' Centro de areas '
        If Val(TxtVar1.Text) = 3 Then
            Call Mostrar_Areas(Cadena, Dgv01)
        End If
        ' Centro de costos '
        If Val(TxtVar1.Text) = 4 Then
            Call Mostrar_Costos(Cadena, Dgv01)
        End If
    End Sub

    Private Sub TxtBusCodigo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtBusCodigo.KeyDown
        With Dgv01
            ' Dim caja As New TextBox
            If .RowCount > 0 Then
                ' On Error Resume Next
                x = .CurrentCell.RowIndex
                If e.KeyCode = Keys.Down Then
                    e.Handled = True : foco = 1
                    x += 1 : Call Movilizar_Grid(Dgv01, x, "ABAJO")
                End If
                If e.KeyCode = Keys.Up Then
                    foco = 1 : e.Handled = True
                    x -= 1 : Call Movilizar_Grid(Dgv01, x, "ARRIBA")
                End If
                If e.KeyCode = Keys.Enter Then
                    If foco = 1 Then
                        Call Dgv01_DoubleClick(Nothing, Nothing)
                    End If
                End If
            End If
        End With 'Mostramos los datos al presionar la tecla enter
    End Sub

    Private Sub TxtBusCodigo_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBusCodigo.TextChanged
        ' Buscamos por codigo de cuenta '
        If Val(TxtVar1.Text) = 1 Or Val(TxtVar1.Text) = 2 Then
            Cargar_Grid(" Pcuenta like '" & TxtBusCodigo.Text & "%' order by pcuenta")
        End If
        ' Buscamos por codigo de area '
        If Val(TxtVar1.Text) = 3 Then
            Cargar_Grid(" and Tclave like '" & TxtBusCodigo.Text & "%' order by Tclave")
        End If
        ' cargamos areas
        If Val(TxtVar1.Text) = 4 Then
            Cargar_Grid(" and Tclave like '" & TxtBusCodigo.Text & "%' order by Tclave")
        End If
    End Sub

    Private Sub TxtBusCta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtBusCta.KeyDown
        With Dgv01
            ' Dim caja As New TextBox
            If .RowCount > 0 Then
                ' On Error Resume Next
                x = .CurrentCell.RowIndex
                If e.KeyCode = Keys.Down Then
                    e.Handled = True : foco = 1
                    x += 1 : Call Movilizar_Grid(Dgv01, x, "ABAJO")
                End If
                If e.KeyCode = Keys.Up Then
                    foco = 1 : e.Handled = True
                    x -= 1 : Call Movilizar_Grid(Dgv01, x, "ARRIBA")
                End If
                If e.KeyCode = Keys.Enter Then
                    If foco = 1 Then
                        Call Dgv01_DoubleClick(Nothing, Nothing)
                    End If
                End If
            End If
        End With 'Mostramos los datos al presionar la tecla enter
    End Sub

    Private Sub TxtBusCta_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBusCta.TextChanged
        ' Buscamos por codigo de cuenta '
        If Val(TxtVar1.Text) = 1 Or Val(TxtVar1.Text) = 2 Then
            Cargar_Grid(" Pdescri like '%" & TxtBusCta.Text & "%' order by Pdescri")
        End If
        ' Buscamos por cuenta '
        If Val(TxtVar1.Text) = 3 Then
            Cargar_Grid(" and Tdescri like '%" & TxtBusCta.Text & "%' order by Tdescri")
        End If
        ' Buscamos por areas '
        If Val(TxtVar1.Text) = 4 Then
            Cargar_Grid(" and Tdescri like '%" & TxtBusCta.Text & "%' order by Tdescri")
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_DoubleClick(sender As Object, e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    ' mostramos cta de compras '
                    If Val(TxtVar1.Text) = 1 Then
                        FrmMnCaidas.TxtCtaCompra.Text = .Rows(Fila).Cells("Pcuenta").Value
                    End If
                    ' mostramos cta de ventas'
                    If Val(TxtVar1.Text) = 2 Then
                        FrmMnCaidas.TxtCtaVenta.Text = .Rows(Fila).Cells("Pcuenta").Value
                    End If
                    ' mostramos areas'
                    If Val(TxtVar1.Text) = 3 Then
                        FrmMnCaidas.TxtArea.Text = .Rows(Fila).Cells("Tclave").Value
                    End If
                    ' mostramos areas'
                    If Val(TxtVar1.Text) = 4 Then
                        FrmMnCaidas.TxtCosto.Text = .Rows(Fila).Cells("Tclave").Value
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub

    Private Sub Dgv01_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub
End Class