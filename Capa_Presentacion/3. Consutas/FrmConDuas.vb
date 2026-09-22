Public Class FrmConDuas
    Dim x As Integer = 0 : Dim Foco As Integer = 0

    Private Sub FrmConDuas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConDuas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmConDuas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_DuasCab.get_DuasCab_Datos(Cadena, "DGV")
            .Columns("Codigo").Width = 50
            .Columns("Nro.").Width = 45
            .Columns("Dua").Width = 60
            .Columns("Fecha").Width = 65
            .Columns("Proveedor").Width = 220
            .Columns("Total").Width = 90
            'Alineacion
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nro.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Dua").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'Visibles
            .Columns("c_anula_reg").Visible = False

            'Validamos si registro esta activo...
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
        End With
    End Sub
    'Grabamos registro...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Dim Rango_Fechas As String = ""
        If DtpFec_Fin.Text = DtpFec_Inicio.Text Then
            Rango_Fechas = " "
        Else
            Rango_Fechas = " And C.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and C.c_fecha_emi<='" & DtpFec_Fin.Text & "' "
        End If
        Call Cargar_Grid(" And c_nro_dua like '%" & TxtBuscar.Text & "%' " & Rango_Fechas)
    End Sub

    Private Sub TxtBuscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBuscar.GotFocus
        With Dgv01
            If .RowCount > 0 Then
                If .CurrentCell.RowIndex > -1 Then
                    x = .CurrentCell.RowIndex : .CurrentCell = Dgv01(Dgv01.CurrentRow.Cells(0).ColumnIndex, x)
                End If
            End If
        End With
    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
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

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged

    End Sub
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    'Mostramos al formulario Salidas...
                    If Val(TxtVar.Text) = 1 Then
                        FrmDuas.TxtBuscar.Text = .Rows(fila).Cells("Codigo").Value
                        FrmDuas.TxtNro_Dua.Text = .Rows(fila).Cells("Codigo").Value
                        FrmDuas.Mostrar_Duas(" and C.c_nro_operacion='" & FrmDuas.TxtBuscar.Text & "' ")
                    End If
                    'Mostramos al formulario Duas Costos...
                    If Val(TxtVar.Text) = 2 Then
                        With c_Neg_DuasCab.get_DuasCab_Datos(" and C.c_nro_operacion='" & .Rows(fila).Cells("Codigo").Value & "' ", "DAT")
                            If .Rows.Count > 0 Then
                                ' Validamos si dua esta anulada '
                                If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                                    FrmDuasCostos.TxtCod_Dua.Text = .Rows(0)("c_nro_operacion").ToString
                                    FrmDuasCostos.TxtDua.Text = .Rows(0)("c_serie_dua").ToString & "-" & .Rows(0)("c_nro_dua").ToString
                                    ' Validamos el tipo de moneda '
                                    If .Rows(0)("c_codi_mon").ToString = "01" Then
                                        FrmDuasCostos.TxtTot_Dua_Mn.Text = Format(Val(.Rows(0)("c_imp_afecto").ToString), Forma_1_2)
                                        FrmDuasCostos.TxtTot_Dua.Text = Format(Val(.Rows(0)("c_imp_afecto").ToString) / Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_2)
                                    Else
                                        FrmDuasCostos.TxtTot_Dua.Text = Format(Val(.Rows(0)("c_imp_afecto").ToString), Forma_1_2)
                                        FrmDuasCostos.TxtTot_Dua_Mn.Text = Format(Val(.Rows(0)("c_imp_afecto").ToString) * Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_2)
                                    End If
                                    FrmDuasCostos.Calcular_Todos() : FrmDuasCostos.TxtGastos.Focus()
                                Else
                                    MsgBox("Dua se encuentra anulado no podra realizar ninguna modificación...", vbCritical, Compañia)
                                End If
                            End If
                        End With
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