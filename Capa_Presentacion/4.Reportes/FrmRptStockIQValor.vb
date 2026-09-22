Public Class FrmRptStockIQValor

    Private Sub FrmRptStockIQValor_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.P Then Call BtnVista_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmRptStockIQValor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRptStockIQValor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnArticulo.Get_Articulo_Cbo(" and A.c_anula_Reg=0 order by c_desc_articulo", CboArticulo)
        c_Neg_MnAlmacen.get_Almacen_Cbo(" and c_anula_reg=0 order by c_desc_alm", CboAlm)
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_codi_mon", CboMon)
        CboAlm.SelectedIndex = 0 : CboMon.SelectedIndex = 0
    End Sub

    Private Sub CboArticulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboArticulo.KeyDown
        If e.KeyCode = Keys.F4 Or e.KeyCode = Keys.Enter Then Call CboArticulo_SelectedIndexChanged(Nothing, Nothing)
    End Sub
    ' Cambiamos a mayusculas '
    Private Sub CboArticulo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboArticulo.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboArticulo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboArticulo.SelectedIndexChanged
        If CboArticulo.Items.Count > 0 Then Call Combo_Jalar_Codigo(CboArticulo, TxtCod_Articulo)
    End Sub
    ' Mostramos datos '
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        If Len(CboAlm.Text) > 0 And Len(CboMon.Text) > 0 Then
            Dim c_codi_articulo As String = ""
            If Len(CboArticulo.Text) > 0 Then c_codi_articulo = " And A.c_codi_articulo='" & TxtCod_Articulo.Text & "' order by c_desc_articulo"
            Call Cargar_Grid(c_codi_articulo)
        Else
            MsgBox("Falta seleccionar el Almacen o tipo de Moneda...", vbExclamation, Compañia)
        End If
    End Sub
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_RptStockIQ.get_StockIQ_Datos(Cadena, Year(Now.Date), Month(Now.Date), CboAlm.SelectedValue, CboMon.SelectedValue, "VAL")
            .Columns("Mot").Width = 50
            .Columns("Cd").Width = 50
            .Columns("Scd").Width = 50
            .Columns("Codigo I.Q.").Width = 90
            .Columns("Articulo").Width = 290
            .Columns("Cantidad").Width = 80
            ' Validamos el tipo de moneda '
            If CboMon.SelectedValue = "01" Then
                .Columns("Total-S/.").Width = 70
                .Columns("Precio-S/.").Width = 70
            Else
                .Columns("Total-$.").Width = 70
                .Columns("Precio-$.").Width = 70
            End If
            ' Alineacion '
            .Columns("Mot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Scd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo I.Q.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' Validamos el tipo de moneda '
            If CboMon.SelectedValue = "01" Then
                .Columns("Total-S/.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Precio-S/.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Else
                .Columns("Total-$.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Precio-$.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub
    ' Cerramos Ventana '
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
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
    ' Seleccion de Grid '
    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    ' Abrimos '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Reporte_StockValorizado.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Reporte_StockValorizado.XLS"
            End If
        End If
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
    ' Vista Preliminar '
    Private Sub BtnVista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVista.Click
        If Len(CboAlm.Text) > 0 And Len(CboMon.Text) > 0 Then
            Dim c_codi_articulo As String = ""
            If Len(CboArticulo.Text) > 0 Then c_codi_articulo = " And A.c_codi_articulo='" & TxtCod_Articulo.Text & "' order by c_desc_articulo"
            c_Neg_RptStockIQ.get_StockIQ_Datos(c_codi_articulo, Year(Now.Date), Month(Date.Now), CboAlm.SelectedValue, CboMon.SelectedValue, "RPT")
            FrmReportes.Reporte_StockIQValor(CboAlm.Text, CboMon.Text)
        Else
            MsgBox("Falta seleccionar el almacen o el Tipo de Moneda...", vbExclamation, Compañia)
        End If
    End Sub
End Class