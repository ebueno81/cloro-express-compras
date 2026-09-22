
Public Class FrmConTg
    Dim x As Integer = 0 : Dim Foco As Integer = 0

    Private Sub FrmConTg_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FrmMenu.Enabled = True
        If FrmConArtListar.Enabled = False And FrmConArtListar.Visible = True Then
            FrmConArtListar.Enabled = True
            FrmConArtListar.TxtCd.Focus()
        End If 'Orde de requerimientos...
        If Val(TxtVar.Text) = 1 Then
            FrmMnArticulos.BtnConCd.Focus()
        End If
        If Val(TxtVar.Text) = 3 Then
            FrmOQ.BtnCon3.Focus()
        End If
        ' Stock de insumos quimicos '
        If Val(TxtVar.Text) = 4 Then
            FrmRptStockIQ.BtnConCd.Focus()
        End If
        ' Mantenimiento de proveedores '
        If Val(TxtVar.Text) = 5 Then
            FrmMnProve.BtnCon_2.Focus()
        End If
        ' Duas '
        If Val(TxtVar.Text) = 6 Then
            FrmDuas.BtnCon3.Focus()
        End If
        ' Reporte de Ingresos '
        If Val(TxtVar.Text) = 7 Then
            FrmRptIngAlm.BtnConCd.Focus()
        End If
        ' orden de compra '
        If Val(TxtVar.Text) = 8 Then
            FrmOC.BtnCon3.Focus()
        End If

    End Sub

    Private Sub FrmConTg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub FrmConTg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnTblGral.get_TblGral_Datos(Cadena, "DG2")
        With Dgv01
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).Width = 60
            .Columns(1).Width = 320
            .Columns(0).HeaderCell.Style.BackColor = Color.Yellow
            .Columns(0).HeaderCell.Style.ForeColor = Color.Blue
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
        Call Cargar_Grid(" and c_anula_reg=0 and c_desc_tg like '%" & TxtBus_Art.Text & "%' order by c_desc_tg")
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    'Mostramos al Orden de Transformacion...
                    If Val(TxtVar.Text) = 1 Then
                        FrmMnArticulos.TxtCod_Tg.Text = .Rows(fila).Cells("Codigo").Value
                        FrmMnArticulos.TxtTg.Text = .Rows(fila).Cells("Motivo").Value
                    End If
                    'Mostramos al formulario Listado de articulos...
                    If Val(TxtVar.Text) = 2 Then
                        FrmConArtListar.TxtCod_Tg.Text = .Rows(fila).Cells("Codigo").Value
                        FrmConArtListar.TxtTg.Text = .Rows(fila).Cells("Motivo").Value
                        FrmConArtListar.BtnCon2.Focus()
                    End If
                    'Mostramos al formulario Listado de articulos...
                    If Val(TxtVar.Text) = 3 Then
                        FrmOQ.TxtCod_Tg.Text = .Rows(fila).Cells("Codigo").Value
                        FrmOQ.TxtTg.Text = .Rows(fila).Cells("Motivo").Value
                        FrmOQ.TxtCd.Focus()
                    End If
                    'Consulta de Stock de IQ...
                    If Val(TxtVar.Text) = 4 Then
                        FrmRptStockIQ.TxtCod_Tg.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptStockIQ.TxtTg.Text = .Rows(fila).Cells("Motivo").Value
                    End If
                    ' Mantemiento de proveedores '
                    If Val(TxtVar.Text) = 5 Then
                        FrmMnProve.TxtCod_Mt.Text = .Rows(fila).Cells("Codigo").Value
                        FrmMnProve.TxtMt.Text = .Rows(fila).Cells("Motivo").Value
                    End If
                    ' DUAS '
                    If Val(TxtVar.Text) = 6 Then
                        FrmDuas.TxtCod_Tg.Text = .Rows(fila).Cells("Codigo").Value
                        FrmDuas.TxtTg.Text = .Rows(fila).Cells("Motivo").Value
                    End If
                    ' Ingreso de Almacen '
                    If Val(TxtVar.Text) = 7 Then
                        FrmRptIngAlm.TxtCod_Tg.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptIngAlm.TxtTg.Text = .Rows(fila).Cells("Motivo").Value
                    End If
                    ' orden de compra '
                    If Val(TxtVar.Text) = 8 Then
                        FrmOC.TxtCod_Tg.Text = .Rows(fila).Cells("Codigo").Value
                        FrmOC.TxtTg.Text = .Rows(fila).Cells("Motivo").Value
                    End If
                    ' Kardex Valorizado '
                    If Val(TxtVar.Text) = 9 Then
                        FrmRptKardexValor.TxtCod_Tg.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptKardexValor.TxtCod_Cd.Focus()
                    End If
                    ' Reporte de Transformaciones '
                    If Val(TxtVar.Text) = 10 Then
                        FrmRptTransforCompras.TxtcodTg.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptTransforCompras.TxtTg.Text = .Rows(fila).Cells("Motivo").Value
                        FrmRptTransforCompras.TxtCodCd.Focus()
                    End If
                    ' Kardex unidades fiscas '
                    If Val(TxtVar.Text) = 11 Then
                        FrmRptKardex.TxtCod_Tg.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptKardex.TxtCod_Cd.Focus()
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

    Private Sub FrmConTg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class