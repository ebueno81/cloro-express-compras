Public Class FrmRetenLista

    Private Sub FrmRetenLista_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub
    ' Avanzamos al presionar la tecla enter '
    Private Sub FrmRetenLista_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRetenLista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnSeries.get_Series_Cbo(" and c_anula_reg=0 and c_codi_doc='20'", CboSerie, FrmMenu.TxtCod_Emp.Text)
        If CboSerie.Items.Count > 0 Then CboSerie.SelectedIndex = 0
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim Proveedor As String = ""
        If Len(TxtClie.Text) > 0 Then Proveedor = " and P.c_desc_prov like '" & TxtClie.Text & "%' "
        Call Cargar_Grid(Proveedor & " And R.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and R.c_fecha_emi<='" & DtpFec_Final.Text & _
                         "' order by c_nro_serie, c_nro_reten")
    End Sub
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_RetenCab.get_RetenCab_Datos(Cadena, "LIS", FrmMenu.TxtCod_Emp.Text)

            For i = 0 To .ColumnCount - 1
                .Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
            'Alineacion
            .Columns("Proveedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("Monto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Retencion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Dim Tot_1, Tot_2, Tot_3, Tot_4, Tot_5, Tot_6, Tot_7, Tot_8 As Decimal
            Dim Tot_Reg_1, Tot_Reg_2 As Integer
            For i = 0 To .RowCount - 1
                Tot_Reg_1 = Tot_Reg_1 + 1
                Tot_1 = Tot_1 + Val(.Rows(i).Cells("Monto").Value)
                Tot_3 = Tot_3 + Val(.Rows(i).Cells("Retencion").Value)
            Next
            TxtConta_1.Text = Tot_Reg_1
            TxtTot_01.Text = Format(Val(Tot_1), Forma_2_2)
            TxtTot_03.Text = Format(Val(Tot_3), Forma_2_2)

            Call Grid_Registros_anulados(Dgv01)

            .Columns("Nro.Retencion").Width = 90
            .Columns("Proveedor").Width = 350
            .Columns("Fecha Emision").Width = 140
            .Columns(" ").Width = 30
            .Columns("Monto").Width = 90
            .Columns("Retencion").Width = 90

            .Columns("c_anula_reg").Visible = False
            .Columns("Nro.Retencion").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Nro.Retencion").HeaderCell.Style.ForeColor = Color.Blue
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
    ' Mostramos datos al presionar la tecla enter '
    Private Sub TxtFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFactura.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtFactura.Text) > 0 Then
                TxtFactura.Text = Strings.Right(Val(TxtFactura.Text) + 10000000, 7)
                Call Cargar_Grid(" And R.c_nro_reten='" & TxtFactura.Text & "'  And R.c_nro_serie='" & CboSerie.Text & "'")
            End If
        End If
    End Sub

    Private Sub TxtFactura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFactura.TextChanged

    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    ' Generamos Archivo de Texto '
    Private Sub BtnTxt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTxt.Click
        Dim nombre_archivo As String = "0626" & FrmMenu.TxtRuc_Emp.Text & Year(DtpFec_Inicio.Text) & Strings.Right(Month(DtpFec_Inicio.Text) + 100, 2)
        Call Generar_TXT(" And C.c_fecha_emi>='" & DtpFec_Inicio.Text & "' And C.c_fecha_emi<='" & DtpFec_Final.Text & _
                         "' order by c_nro_Serie, c_nro_reten", nombre_archivo)
    End Sub
   
End Class