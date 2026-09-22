Public Class FrmMnSeriesDoc
    Private Sub Pan01_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pan01.Paint

    End Sub

    Private Sub FrmMnSalSeries_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmMnSalSeries_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmMnSalSeries_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dgv01.DataSource = c_Neg_MnSeries.get_Series_Datos(" and c_anula_reg=0 order by c_nro_serie", "DGV", FrmMenu.TxtCod_Emp.Text)
        With Dgv01
            .Columns("Serie").Width = 45
            .Columns("Documento").Width = 65
            .Columns("Descripcion").Width = 175
            .Columns("c_anula_reg").Visible = False
            'Alineacion
            .Columns("Serie").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Color de cabecera...
            .Columns("Serie").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Serie").HeaderCell.Style.ForeColor = Color.Blue
        End With
        Call Validar_Permiso(Me.Name, BtnEditar, BtnEditar, BtnEditar)
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If BtnGrabar.Text = "&Grabar" Then
            Dim F As String = MsgBox("¿Desea grabar el registro?", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                With c_Ent_SeriesDoc
                    .c_codi_doc = "11"
                    .c_nro_serie = TxtSerie.Text
                    .c_nro_doc = TxtGuia.Text
                    .c_desc_serie = TxtDesc.Text
                    .copcion = "ADD"
                    c_Neg_MnSeries.set_Series_Save(c_Ent_SeriesDoc, FrmMenu.TxtCod_Emp.Text)
                End With
                MsgBox("Los datos se grabaron corectamente...", vbInformation, Compañia)
                Call Cancelar_Registro()
                Dgv01.DataSource = c_Neg_MnSeries.get_Series_Datos(" and c_anula_reg=0 order by c_nro_serie", "DGV", FrmMenu.TxtCod_Emp.Text)
            End If
        Else
            Call Limpiar_Texto(Pan01) : Call nuevo_registro()
        End If
    End Sub
    'Cerramos ventna
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro()
        End If
    End Sub
    Private Sub Cancelar_Registro()
        Dgv01.Size = New Size(318, 217) : BtnGrabar.Text = "&Agregar" : BtnEditar.Enabled = True
        BtnCerrar.Text = "&Cerrar" : BtnGrabar.Enabled = True ': Call Validar_Permisos()
    End Sub
    Private Sub TxtGuia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtGuia.LostFocus
        TxtGuia.Text = Strings.Right(Val(TxtGuia.Text) + 10000000, 7)
    End Sub

    Private Sub TxtGuia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGuia.TextChanged

    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    'Editamos registro...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
    End Sub
    'Editamos registro...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    TxtSerie.Text = .Rows(fila).Cells("Serie").Value
                    TxtGuia.Text = .Rows(fila).Cells("documento").Value
                    TxtDesc.Text = .Rows(fila).Cells("Descripcion").Value.ToString
                    Call nuevo_registro()
                End If
            End If
        End With
    End Sub
    Private Sub nuevo_registro()
        Dgv01.Size = New Size(318, 122)
        BtnGrabar.Text = "&Grabar"
        BtnEditar.Enabled = False : BtnCerrar.Text = "Cancelar"
    End Sub
End Class