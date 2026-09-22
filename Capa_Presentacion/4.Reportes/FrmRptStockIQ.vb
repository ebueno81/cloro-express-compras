Public Class FrmRptStockIQ

    Private Sub FrmConStockIQ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmConStockIQ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Agregamos Año '
        For I = 2013 To Year(Now.Date)
            CboAño.Items.Add(I)
        Next
        ' Agregamos Meses '
        For I = 1 To 12
            CboMes.Items.Add(StrConv(MonthName(I), VbStrConv.ProperCase))
        Next
        ' Agregamos Almacen '
        c_Neg_MnAlmacen.get_Almacen_Cbo(" and c_anula_reg=0 order by c_desc_alm", CboAlm)
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_desc_mon", CboMon)
        CboAño.SelectedIndex = CboAño.Items.Count - 1 : CboMes.SelectedIndex = Month(Date.Now) - 1
        CboAlm.SelectedIndex = 0 : CboMon.SelectedIndex = 0
    End Sub


    Private Sub BtnConTg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConTg.Click
        With FrmConTg
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 4
            .Cargar_Grid(" and c_anula_reg=0  order by c_desc_tg")
        End With
    End Sub

    Private Sub BtnConCd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConCd.Click
        With FrmConCd
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 4 : .TxtCod_Tg.Text = TxtCod_Tg.Text
            .Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' order by c_desc_cd")
        End With
    End Sub

    Private Sub BtnConScd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConScd.Click
        With FrmConScd
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 4 : .TxtCod_Tg.Text = TxtCod_Tg.Text : .TxtCod_Cd.Text = TxtCod_Cd.Text
            .Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' and c_codi_cd='" & TxtCod_Cd.Text & "' order by c_desc_scd")
        End With
    End Sub
    ' Cargamos Registro '
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim Tg As String = "" : Dim Cd As String = "" : Dim Scd As String = ""
        If Len(TxtTg.Text) > 0 Then Tg = " and A.c_codi_tg='" & TxtCod_Tg.Text & "' "
        If Len(TxtCd.Text) > 0 Then Cd = " and A.c_codi_cd='" & TxtCod_Cd.Text & "' "
        If Len(TxtScd.Text) > 0 Then Scd = " and A.c_codi_scd='" & TxtCod_Scd.Text & "' "
        Call Cargar_Grid(Tg & Cd & Scd & " order by c_desc_articulo")
    End Sub
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_RptStockIQ.get_StockIQ_Datos(Cadena, Val(CboAño.Text), CboMes.SelectedIndex + 1, CboAlm.SelectedValue, CboMon.SelectedValue, "DGV")
            .Columns("Mot").Width = 50
            .Columns("Cd").Width = 50
            .Columns("Scd").Width = 50
            .Columns("Codigo I.Q.").Width = 90
            .Columns("Articulo").Width = 290
            .Columns("Mes").Width = 100
            .Columns("Año").Width = 70
            .Columns("Cantidad").Width = 80
            .Columns("Precio").Visible = False
            .Columns("Total").Width = 80
            ' Alineacion '
            .Columns("Mot").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Scd").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo I.Q.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Mes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Año").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Call Calcular_Totales()
        End With
    End Sub
    ' METODO PARA CALCULAR TOTALES
    Private Sub Calcular_Totales()
        With Dgv01
            Dim Cantidad As Decimal = 0 : Dim Total As Decimal = 0
            For i = 0 To .RowCount - 1
                Cantidad = Cantidad + Val(.Rows(i).Cells("Cantidad").Value)
                Total = Total + Val(.Rows(i).Cells("Total").Value.ToString)
            Next
            TxtConta_1.Text = .RowCount : TxtTot_05.Text = Format(Cantidad, Forma_2_2) : TxtTot_07.Text = Format(Total, Forma_2_2)
            TxtTot_03.Text = CboMon.Text
        End With
    End Sub
    ' Cerramos Formulario '
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Reporte_Stock.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Reporte_Stock.XLS"
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

    Private Sub BtnVista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVista.Click
        Dim Tg As String = "" : Dim Cd As String = "" : Dim Scd As String = ""
        If Len(TxtTg.Text) > 0 Then Tg = " and A.c_codi_tg='" & TxtCod_Tg.Text & "' "
        If Len(TxtCd.Text) > 0 Then Cd = " and A.c_codi_cd='" & TxtCod_Cd.Text & "' "
        If Len(TxtScd.Text) > 0 Then Scd = " and A.c_codi_scd='" & TxtCod_Scd.Text & "' "
        'c_Neg_RptStockIQ.get_StockIQ_Datos(Tg & Cd & Scd, Val(CboAño.Text), CboMes.SelectedIndex + 1, CboAlm.SelectedValue, CboMon.SelectedValue, "RPT")
        'FrmReportes.Reporte_StockIQ(CboAlm.Text, UCase(MonthName(CboMes.SelectedIndex + 1)), CboAño.Text)
        c_Neg_RptStockIQ.get_StockIQ_Datos(Tg & Cd & Scd, Val(CboAño.Text), CboMes.SelectedIndex + 1, CboAlm.SelectedValue, CboMon.SelectedValue, "RPT")
        FrmReportes.Reporte_StockIQ(CboAlm.Text, CboMes.Text, CboAño.Text)
    End Sub
End Class