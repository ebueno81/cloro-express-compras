Public Class FrmLeasingConsul
    Private Sub FrmLeasingConsul_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call Cargar_Grid(" and P.c_desc_prov like '" & TxtBus.Text & "%' and L.c_fecha_emision>='" & DtpFec_Inicio.Text &
                                                            "' and L.c_fecha_emision<='" & DtpFec_Final.Text & "' order by L.c_fecha_emision")
    End Sub
    ' Cargar Grid '
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_LeasingCab.get_LeasingCab_Datos(Cadena, "DGV")
            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            'Alineacion
            .Columns("Proveedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Observaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Acta.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Call Grid_Registros_anulados(Dgv01)

            .Columns("Codigo").Width = 50
            .Columns("Tipo").Width = 120
            .Columns("Nro.Credito").Width = 100
            .Columns("Fecha").Width = 80
            .Columns("Proveedor").Width = 220
            .Columns("Observaciones").Width = 240
            .Columns("_").Width = 30
            .Columns("Total").Width = 55
            .Columns("Acta.").Width = 55
            .Columns("Saldo").Width = 55

            ' .Columns("c_anula_reg").Visible = False
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue
            .Focus()
        End With
    End Sub
    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        'Call Grid_Registros_anulados(Dgv01)
    End Sub
    'Mostramos registros al dar doble click
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(TxtVar.Text) = 1 Then
                        FrmLeasing.Mostrar_Leasing(" and  c_nro_operacion='" & .Rows(Fila).Cells("Codigo").Value & "' ")
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub
    'Mostramos datos de la factura al presionar la tecla enter...
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub
    ' Buscamos por numero de facturas '
    Private Sub TxtBus_Fact_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Fact.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtBus_Fact.Text) > 0 Then
                Call Cargar_Grid(" And L.c_nro_credito like '%" & TxtBus_Fact.Text & "%' ")
            End If
        End If
    End Sub

    Private Sub TxtBus_Fact_TextChanged(sender As Object, e As EventArgs) Handles TxtBus_Fact.TextChanged

    End Sub

    Private Sub FrmLeasingConsul_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
End Class