Public Class FrmConHistoCancel
    'Cerramos ventana al presionar la tecla enter...
    Private Sub FrmConHistoCancel_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub FrmConHistoCancel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    'Cargamos grid para facturas...
    Public Sub Cargar_Grid(ByVal Cadena As String, ByVal vOpt As String)
        Dgv01.DataSource = c_Neg_IngComp.get_IngComp_DatosPagos(Cadena, vOpt, FrmMenu.TxtCod_Emp.Text)
        With Dgv01
            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            Dim Tot_Dol, Tot_Sol As Decimal
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                Else
                    If .Rows(i).Cells(" ").Value = "S/." Then Tot_Sol = Tot_Sol + Val(.Rows(i).Cells("Monto").Value)
                    If .Rows(i).Cells(" ").Value = "$." Then Tot_Dol = Tot_Dol + Val(.Rows(i).Cells("Monto").Value)
                End If
            Next
            TxtTol_Dol.Text = Format(Tot_Dol, Forma_2_2)
            TxtTol_Sol.Text = Format(Tot_Sol, Forma_2_2)

            .Columns("Nro.").Width = 50
            
            .Columns("Tipo").Width = 70
            .Columns("Fecha").Width = 70
            .Columns("T.C.").Width = 40
            .Columns(" ").Width = 30
            .Columns("Monto").Width = 70
            .Columns("c_anula_reg").Visible = False
            .Columns(1).HeaderCell.Style.BackColor = Color.Yellow
            .Columns(1).HeaderCell.Style.ForeColor = Color.Blue
            If .RowCount = 0 Then
                Me.Close()
                MsgBox("No existen pagos para el Documento...", vbCritical, Compañia)
            Else
                If vOpt = "ING" Then
                    .Columns("Voucher").Width = 70
                Else
                    If vOpt = "LES" Then
                        .Columns("Voucher").Width = 70
                    Else
                        .Columns("Documento").Width = 70
                        .Columns("Vcto.").Width = 70
                        .Columns("Dias").Width = 40
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' Resaltamos o cambiamos de color a los registros anulados '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
End Class