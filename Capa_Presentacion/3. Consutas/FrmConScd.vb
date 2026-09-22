
Public Class FrmConScd
    Dim x As Integer = 0 : Dim Foco As Integer = 0

    Private Sub FrmConScd_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Val(TxtVar.Text) = 1 Then
            FrmMnArticulos.TxtObs.Focus()
        End If
        If Val(TxtVar.Text) = 2 Then
            FrmConArtListar.CboOrden.Focus()
        End If
        'orden de requerimientos...
        If Val(TxtVar.Text) = 3 Then
            FrmOQ.Enabled = True : FrmOQ.TxtCant.Focus()
        End If
        If Val(TxtVar.Text) = 4 Then
            FrmRptStockIQ.CboAño.Focus()
        End If
        ' Mantenimiento de Proveedores '
        If Val(TxtVar.Text) = 5 Then
            FrmMnProve.CboMon.Focus()
        End If
        ' DUAS '
        If Val(TxtVar.Text) = 6 Then
            FrmDuas.BtnAceptar.Focus()
        End If
        ' Reporte de Ingresos '
        If Val(TxtVar.Text) = 7 Then
            FrmRptIngAlm.BtnMostrar.Focus()
        End If
        ' Reporte de Ingresos '
        If Val(TxtVar.Text) = 8 Then
            FrmOC.ChkAfecto.Focus()
        End If

    End Sub

    Private Sub FrmConScd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConScd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmConScd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    'Mostramos al formulario de Artículos...
                    If Val(TxtVar.Text) = 1 Then
                        FrmMnArticulos.TxtCod_Scd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmMnArticulos.TxtScd.Text = .Rows(fila).Cells("SubCaida").Value
                    End If
                    'Mostramos al formulario listar articulos...
                    If Val(TxtVar.Text) = 2 Then
                        FrmConArtListar.TxtCod_Scd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmConArtListar.TxtScd.Text = .Rows(fila).Cells("SubCaida").Value
                    End If
                    'Mostramos al formulario listar articulos...
                    If Val(TxtVar.Text) = 3 Then
                        FrmOQ.TxtCod_Scd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmOQ.TxtScd.Text = .Rows(fila).Cells("SubCaida").Value
                        FrmOQ.TxtCodigo.Text = .Rows(fila).Cells("Articulo").Value.ToString
                        FrmOQ.TxtCant.Focus()
                        FrmOQ.Mostrar_Scaidas()
                    End If
                    'Consulta de Stock IQ...
                    If Val(TxtVar.Text) = 4 Then
                        FrmRptStockIQ.TxtCod_Scd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptStockIQ.TxtScd.Text = .Rows(fila).Cells("SubCaida").Value
                        FrmRptStockIQ.TxtCod_Articulo.Text = .Rows(fila).Cells("Articulo").Value.ToString
                    End If
                    'Mantenimiento de Proveedores...
                    If Val(TxtVar.Text) = 5 Then
                        FrmMnProve.TxtCod_Scd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmMnProve.TxtScd.Text = .Rows(fila).Cells("SubCaida").Value
                        If Len(.Rows(fila).Cells("Articulo").Value.ToString) > 0 Then
                            FrmMnProve.TxtCod_Articulo.Text = .Rows(fila).Cells("Articulo").Value.ToString
                        Else
                            FrmMnProve.TxtCod_Articulo.Text = "00000000"
                        End If
                    End If
                    'Mantenimiento de Proveedores...
                    If Val(TxtVar.Text) = 6 Then
                        FrmDuas.TxtCod_Scd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmDuas.TxtScd.Text = .Rows(fila).Cells("SubCaida").Value
                    End If
                    'Reporte de Ingresos...
                    If Val(TxtVar.Text) = 7 Then
                        FrmRptIngAlm.TxtCod_Scd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptIngAlm.TxtScd.Text = .Rows(fila).Cells("SubCaida").Value
                    End If
                    'oc...
                    If Val(TxtVar.Text) = 8 Then
                        FrmOC.TxtCod_Scd.Text = .Rows(fila).Cells("Codigo").Value
                        FrmOC.TxtScd.Text = .Rows(fila).Cells("SubCaida").Value
                        FrmOC.TxtCod_Articulo.Text = .Rows(fila).Cells("Articulo").Value.ToString
                        ' mostramos datos del articulo '
                        With c_Neg_MnScaidas.get_sCaidas_Datos(" AND S.C_ANULA_REG=0 AND S.c_codi_scd='" & .Rows(fila).Cells("Codigo").Value &
                                                               "' and S.c_codi_cd='" & .Rows(fila).Cells("Cd").Value & "' and S.c_codi_tg='" & .Rows(fila).Cells("Tg").Value & "' ", "DAT")
                            If .Rows.Count > 0 Then
                                FrmOC.TxtCod_Tg.Text = .Rows(0)("c_codi_tg").ToString
                                FrmOC.TxtCod_Cd.Text = .Rows(0)("c_codi_cd").ToString
                                FrmOC.TxtCod_Scd.Text = .Rows(0)("c_codi_scd").ToString
                                FrmOC.TxtTg.Text = .Rows(0)("c_desc_tg").ToString
                                FrmOC.TxtCd.Text = .Rows(0)("c_desc_cd").ToString
                                FrmOC.TxtScd.Text = .Rows(0)("c_desc_scd").ToString
                            End If
                        End With
                        ' mostramos la unidad de medida
                        With c_Neg_MnArticulos.get_Articulo_Datos(" AND A.C_ANULA_REG=0 AND A.c_codi_articulo='" & .Rows(fila).Cells("Articulo").Value.ToString & "' ", "DAT")
                            If .Rows.Count > 0 Then
                                FrmOC.CboUniMed.SelectedValue = .Rows(0)("c_codi_unimed").ToString
                            End If
                        End With
                    End If
                    'Reporte de Transformaciones...
                    If Val(TxtVar.Text) = 10 Then
                        FrmRptTransforCompras.TxtCodArt.Text = .Rows(fila).Cells("Articulo").Value
                        FrmRptTransforCompras.TxtArt.Text = .Rows(fila).Cells("SubCaida").Value
                        FrmRptTransforCompras.BtnMostrar.Focus()
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
        Dgv01.DataSource = c_Neg_MnScaidas.get_sCaidas_Datos(Cadena, "DG4")
        'InputBox("", "", Cadena)
        With Dgv01
            .Columns("Tg").Width = 35
            .Columns("Cd").Width = 35
            .Columns("Tg").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(2).Width = 60
            .Columns(2).DefaultCellStyle.BackColor = Color.Ivory
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(3).Width = 320
            .Columns(2).HeaderCell.Style.BackColor = Color.Yellow
            .Columns(2).HeaderCell.Style.ForeColor = Color.Blue
            '.Columns(2).Visible = False
            '.Columns("Tg").Visible = False
            '.Columns("Cd").Visible = False

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
    ' Buscamos por Codigo de Tabla General '
    Private Sub TxtBus_Art_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Art.TextChanged
        Call Cargar_Grid(" and S.c_codi_tg like '%" & TxtCod_Tg.Text & "%' and S.c_codi_cd like '%" & TxtCod_Cd.Text & "%' and S.c_anula_reg=0 and c_desc_scd like '%" & TxtBus_Art.Text & "%' order by c_desc_scd")
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub TxtBus_Art_LostFocus(sender As Object, e As EventArgs) Handles TxtBus_Art.LostFocus
        If Val(TxtFocus.Text) = 1 Then
            TxtFocus.Text = 0 : TxtBus_Art.Focus()
        End If
    End Sub
End Class