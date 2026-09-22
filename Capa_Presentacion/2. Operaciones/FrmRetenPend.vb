Public Class FrmRetenPend

    Private Sub FrmRetenPend_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRetenPend_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_Retencion.get_Retencion_Datos(Cadena, "PEN", FrmMenu.TxtCod_Emp.Text)
            .Columns("Tipo").Width = 120
            .Columns("Nro.Documento").Width = 100
            .Columns("Proveedor").Width = 270
            .Columns("Fecha Emision").Width = 120
            .Columns(" ").Width = 30
            .Columns("Monto").Width = 80
            .Columns("Retencion").Width = 80
            ' Alineacion '
            .Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Nro.Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Emision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(" ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Monto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Retencion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' Coloreamos la cabecera
            .Columns("Tipo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Tipo").HeaderCell.Style.ForeColor = Color.Blue
            ' Llamamos al metodo para mostrar los registros seleccionados por grid '
            Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub
    'Inicio
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 1)
    End Sub
    'Atras
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 2)
    End Sub
    'Avanza
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 3)
    End Sub
    'Final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 4)
    End Sub

    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.Click
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub

    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath.ToString) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Listado_Retenciones.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Listado_Retenciones.XLS"
            End If
        End If
    End Sub
    ' Exportamos Registros de Boletas '
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    ' Exportamos datos a excel '
    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim Cancel As String = ""
        If Rdb01.Checked = True Then
            Cancel = " And R.c_opc_cancel=0 "
        Else
            Cancel = " And R.c_opc_cancel=1 And R.c_opc_fact=0 "
        End If
        Call Cargar_Grid(Cancel & " And P.c_desc_prov like '" & TxtClie.Text & "%' order by R.c_fecha_emi")
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub TxtClie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtClie.TextChanged

    End Sub
    ' Cerramos Ventana '
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    ' Buscamos la presionar la tecla enter '
    Private Sub TxtFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFactura.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtFactura.Text) > 0 Then
                TxtFactura.Text = Strings.Right(Val(TxtFactura.Text) + 10000000, 7)
                Call Cargar_Grid(" And R.c_opc_fact=0 And R.c_nro_doc='" & TxtFactura.Text & "' order by R.c_fecha_emi")
            End If
        End If
    End Sub

    Private Sub TxtFactura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFactura.TextChanged

    End Sub
End Class