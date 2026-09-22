Public Class FrmConLeasingCoutas
    Dim x As Integer = 0 : Dim Foco As Integer = 0
    Private Sub FrmConLeasingCoutas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Val(TxtVar.Text) = 1 Then
            FrmIngComp.BtnGrabar.Focus()
        End If
    End Sub

    Private Sub FrmConLeasingCoutas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConLeasingCoutas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmConLeasingCoutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    ' metodo para cargar grid
    Public Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_LeasingDet.get_LeasingDet_Datos(Cadena, "DGV")
            .Columns("Nro.Cuota").Width = 70
            .Columns("Nro.Leasing").Width = 70
            .Columns("Vcto.").Width = 80
            .Columns("Proveedor").Width = 240
            .Columns("Total").Width = 70
        
            ' Alineacion '
            .Columns("Nro.Cuota").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nro.Leasing").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Vcto.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' Visible '
            .Columns("c_nro_correl").Visible = False
        End With
    End Sub

    Private Sub TxtBus_Leasing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Leasing.KeyDown
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
    ' buscamos por cuota de leasing '
    Private Sub TxtBus_Leasing_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Leasing.TextChanged
        Call Cargar_Grid(" and C.c_codi_mon='" & TxtCod_Mon.Text & "' and D.c_opc_cancel=0 and D.c_opc_doc=0 and C.c_anula_reg=0 and D.c_anula_Reg=0 and C.c_codi_prov like '%" & TxtCod_Prove.Text & "%' and C.c_nro_operacion like '%" & TxtBus_Leasing.Text & _
                         "%' and C.c_codi_doc='13' order by C.c_nro_operacion, D.c_nro_cuota")
    End Sub
    ' mostramos datos al dar doble click '
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    'Mostramos al formulario transformacion...
                    If Val(TxtVar.Text) = 1 Then
                        FrmIngComp.TxtNro_Leasing.Text = .Rows(fila).Cells("Nro.Leasing").Value
                        FrmIngComp.TxtNro_Cuota.Text = .Rows(fila).Cells("Nro.Cuota").Value
                        FrmIngComp.TxtCorrel_Leasing.Text = .Rows(fila).Cells("c_nro_correl").Value
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub
End Class