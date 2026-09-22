Public Class FrmConGuiaFact

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        If Len(TxtProve.Text) > 0 Then
            Call Cargar_Grid(" and P.c_desc_prov like '%" & TxtProve.Text & "%' order by I.c_nro_ing, c_serie_oc, c_nro_oc, c_desc_prov")
            TxtBuscar.Clear()
        End If
    End Sub
    ' METODO PARA CARGAR GRID '
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_IngComp.get_IngComp_DatosOC(Cadena, "DGV", FrmMenu.TxtCod_Emp.Text)
            .Columns("Ingreso").Width = 60
            .Columns("Fecha-Guia").Width = 90
            .Columns("Tipo").Width = 50
            .Columns("Nro.Guia").Width = 90
            .Columns("Tpo.Doc.").Width = 50
            .Columns("Nro.Documento").Width = 90
            .Columns("Proveedor").Width = 320
            ' Alineacion '
            .Columns("Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha-Guia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nro.Guia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Tpo.Doc.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nro.Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' totales '
            LblTotal.Text = "Total de Registros: " & .RowCount
        End With
    End Sub
    ' --> Buscamos al Presionar la tecla Enter <-- '
    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBuscar.Text) > 0 Then
                TxtBuscar.Text = Strings.Right(Val(TxtBuscar.Text) + 10000000, 7)
                Call Cargar_Grid(" and O.c_nro_oc ='" & TxtBuscar.Text & "' order by I.c_nro_ing, c_serie_oc, c_nro_oc, c_desc_prov")
                TxtProve.Clear()
            End If
        End If
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged

    End Sub
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Guias_Facturadas.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Guias_Facturadas.XLS"
            End If
        End If
    End Sub
    ' Avanzamos presionando la tecla enter '
    Private Sub FrmConGuiaFact_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmConGuiaFact_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    ' Cerramos al presionar la tecla escape '
    Private Sub FrmConGuiaFact_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
End Class