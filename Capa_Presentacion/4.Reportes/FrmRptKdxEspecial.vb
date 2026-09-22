Public Class FrmRptKdxEspecial
    Private Sub FrmRptKdxEspecial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dgv02.Rows.Add()
    End Sub
    Public Sub ConfigurarGrid()
        With Dgv01
            .Columns("Fecha").Width = 70
            .Columns("Guia").Width = 80
            .Columns("Proveedor").Width = 140
            .Columns("N.Salida").Width = 55
            .Columns("Motivo").Width = 90
            .Columns("Ingreso").Width = 65
            .Columns("Importe").Width = 60
            .Columns("Salida").Width = 65
            .Columns("Importe ").Width = 60
            .Columns("Saldo").Width = 75
            .Columns("Importe  ").Width = 75
             .Columns("Precio").Width = 60
            '.Columns("Tc").Width = 35


            ' Alineacion '
            .Columns("fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Guia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("N.Salida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Motivo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Columns("Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Salida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Importe ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Importe  ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Coloreamos Columnas '
            .Columns("Fecha").DefaultCellStyle.BackColor = Color.Ivory
            .Columns("Ingreso").DefaultCellStyle.BackColor = Color.Lavender
            .Columns("Importe").DefaultCellStyle.BackColor = Color.Lavender
            .Columns("Salida").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("Importe ").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("Saldo").DefaultCellStyle.BackColor = Color.Ivory
            .Columns("Importe  ").DefaultCellStyle.BackColor = Color.Ivory
            ' validamos si es usuario administrador para los precios '
            If FrmMenu.ChkAdmin.Checked = False Then
                .Columns("Importe ").Visible = False
                .Columns("Importe  ").Visible = False
                .Columns("Importe").Visible = False
                .Columns("Prec.Prom").Visible = False
            End If
            ' llamamos al metodo para calcular los totales '
            Call Calcular_Totales()
        End With
    End Sub
    ' Metodo para calcular Totales '
    Private Sub Calcular_Totales()
        Dim Tot_Ing As Decimal = 0 : Dim Imp_Ing As Decimal = 0
        Dim Tot_Sal As Decimal = 0 : Dim Imp_Sal As Decimal = 0
        Dim Tot_Saldo As Decimal = 0 : Dim Imp_Saldo As Decimal = 0
        ' Calculamos Totales '
        With Dgv01
            For I = 0 To .RowCount - 1
                Tot_Ing = Tot_Ing + Val(.Rows(I).Cells("Ingreso").Value.ToString)
                Imp_Ing = Imp_Ing + Val(.Rows(I).Cells("Importe").Value.ToString)
                Tot_Sal = Tot_Sal + Val(.Rows(I).Cells("Salida").Value.ToString)
                Imp_Sal = Imp_Sal + Val(.Rows(I).Cells("Importe ").Value.ToString)
                'Tot_Saldo = Tot_Saldo + Val(.Rows(I).Cells("Saldo").Value.ToString)
                'Imp_Saldo = Imp_Saldo + Val(.Rows(I).Cells("Importe  ").Value.ToString)
            Next

            '-- Totalizamos--'
            '-- Totalizamos--'
            If .RowCount > 0 Then
                Tot_Saldo = Val(.Rows(.RowCount - 1).Cells("Saldo").Value)
                Imp_Saldo = Val(.Rows(.RowCount - 1).Cells("Importe  ").Value.ToString)
            Else
                Tot_Saldo = "0.00" : Imp_Saldo = "0.00"
            End If
        End With
        With Dgv02
            .Rows(0).Cells("Ingreso_1").Value = Format(Tot_Ing, Forma_2_2)
            .Rows(0).Cells("Importe_1").Value = Format(Imp_Ing, Forma_2_2)
            .Rows(0).Cells("Salida_1").Value = Format(Tot_Sal, Forma_2_2)
            .Rows(0).Cells("Importe_2").Value = Format(Imp_Sal, Forma_2_2)
            .Rows(0).Cells("Saldo_1").Value = Format(Tot_Saldo, Forma_2_2)
            .Rows(0).Cells("Importe_3").Value = Format(Imp_Saldo, Forma_2_2)
            For i = 0 To .ColumnCount - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
            Next
            .Rows(0).Cells(0).Value = Dgv01.RowCount
        End With
    End Sub
    Private Sub FrmRptKdxEspecial_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub BtnVista_Click(sender As Object, e As EventArgs) Handles BtnVista.Click
        FrmReportes.Close()
        FrmReportes.Reporte_KardexIQSunatValEspecial(UCase(MonthName(Month(lblFechaIni.Text))), Year(lblFechaFin.Text), lblAlmacen.Text, FrmRptKardexValor.TxtDesc_TgSunat.Text, FrmRptKardexValor.TxtCod_Sunat.Text)
    End Sub
End Class