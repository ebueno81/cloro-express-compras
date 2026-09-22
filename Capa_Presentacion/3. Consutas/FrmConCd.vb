Imports Capa_Negocios
Public Class FrmConCd
    Dim x As Integer = 0 : Dim Foco As Integer = 0
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    'Mostramos al formulario transformacion...
                    If Val(TxtVar.Text) = 1 Then
                        FrmMnArticulos.TxtCod_Cd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmMnArticulos.TxtCd.Text = .Rows(fila).Cells("Caida").Value
                    End If
                    'Mostramos al formulario Listar Articulos...
                    If Val(TxtVar.Text) = 2 Then
                        FrmConArtListar.TxtCod_Cd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmConArtListar.TxtCd.Text = .Rows(fila).Cells("Caida").Value
                    End If
                    'Mostramos al formulario orden de requerimietos...
                    If Val(TxtVar.Text) = 3 Then
                        FrmOQ.TxtCod_Cd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmOQ.TxtCd.Text = .Rows(fila).Cells("Caida").Value
                        FrmOQ.BtnCon4.Focus()
                    End If
                    'Consulta de stock IQ...
                    If Val(TxtVar.Text) = 4 Then
                        FrmRptStockIQ.TxtCod_Cd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptStockIQ.TxtCd.Text = .Rows(fila).Cells("Caida").Value
                        FrmRptStockIQ.BtnConScd.Focus()
                    End If
                    ' Mantenimiento de Proveedores '
                    If Val(TxtVar.Text) = 5 Then
                        FrmMnProve.TxtCod_Cd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmMnProve.TxtCaida.Text = .Rows(fila).Cells("Caida").Value
                        FrmMnProve.BtnCon_2.Focus()
                    End If
                    ' DUAS '
                    If Val(TxtVar.Text) = 6 Then
                        FrmDuas.TxtCod_Cd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmDuas.TxtCd.Text = .Rows(fila).Cells("Caida").Value
                    End If
                    ' Reporte de Ingresos '
                    If Val(TxtVar.Text) = 7 Then
                        FrmRptIngAlm.TxtCod_Cd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptIngAlm.TxtCd.Text = .Rows(fila).Cells("Caida").Value
                    End If
                    ' Reporte de Ingresos '
                    If Val(TxtVar.Text) = 8 Then
                        FrmOC.TxtCod_Cd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmOC.TxtCd.Text = .Rows(fila).Cells("Caida").Value
                    End If
                    ' Reporte de Kardex Valorizado '
                    If Val(TxtVar.Text) = 9 Then
                        FrmRptKardexValor.TxtCod_Cd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptKardexValor.TxtCod_Scd.Focus()
                    End If
                    ' Reporte de Transformaciones '
                    If Val(TxtVar.Text) = 10 Then
                        FrmRptTransforCompras.TxtCodCd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptTransforCompras.TxtCd.Text = .Rows(fila).Cells("Caida").Value
                        FrmRptTransforCompras.TxtCodArt.Focus()
                    End If
                    ' Reporte de Kardex unidades fisicas'
                    If Val(TxtVar.Text) = 11 Then
                        FrmRptKardex.TxtCod_Cd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptKardex.TxtCod_Scd.Focus()
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnCaidas.get_Caidas_Datos(Cadena, "DG2")
        With Dgv01
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(0).DefaultCellStyle.BackColor = Color.Ivory
            .Columns(0).Width = 60
            .Columns(1).Width = 320
            .Columns(0).HeaderCell.Style.BackColor = Color.Yellow
            .Columns(0).HeaderCell.Style.ForeColor = Color.Blue
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
        Call Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' and c_desc_cd like '%" & TxtBus_Art.Text & "%' order by c_desc_cd")
    End Sub

    Private Sub FrmConCd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Val(TxtVar.Text) = 1 Then
            FrmMnArticulos.BtnConScd.Focus()
        End If
        If Val(TxtVar.Text) = 2 Then
            FrmConArtListar.BtnCon1.Focus()
        End If
        If Val(TxtVar.Text) = 3 Then
            FrmOQ.Enabled = True
            FrmOQ.TxtScd.Focus()
        End If
        If Val(TxtVar.Text) = 4 Then
            FrmRptStockIQ.BtnConScd.Focus()
        End If
        ' Mantenimiento de proveedores '
        If Val(TxtVar.Text) = 5 Then
            FrmMnProve.BtnCon_3.Focus()
        End If
        ' DUAS '
        If Val(TxtVar.Text) = 6 Then
            FrmDuas.BtnCon4.Focus()
        End If
        ' Reporte de Ingresos '
        If Val(TxtVar.Text) = 7 Then
            FrmRptIngAlm.BtnConScd.Focus()
        End If
        ' Reporte de Ingresos '
        If Val(TxtVar.Text) = 8 Then
            FrmOC.BtnCon4.Focus()
        End If

    End Sub

    Private Sub FrmConCd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConCd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmConCd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class