Public Class FrmRptMovDet
    ' Avanzamos presionando la tecla enter '
    Private Sub FrmRptMovDet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRptMovDet_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(20, 20)
        c_Neg_MnTblGral.Get_TblGral_Cbo(" and c_anula_reg=0 order by c_desc_tg", CboMt)
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_codi_mon", CboMon)
        If CboMon.Items.Count > 0 Then CboMon.SelectedIndex = 0
    End Sub

    Private Sub CboMt_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboMt.KeyDown
        If e.KeyCode = Keys.F4 Or e.KeyCode = Keys.Enter Then Call CboMt_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CboMt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboMt.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    ' Motivos '
    Private Sub CboMt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMt.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboMt, TxtCod_Mt)
        CboCd.DataSource = Nothing
        c_Neg_MnCaidas.Get_Caidas_Cbo(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Mt.Text & "' order by c_desc_cd", CboCd)
        TxtCod_Cd.Clear() : CboCd.Text = "" : TxtCod_Scd.Clear() : CboScd.Text = ""
    End Sub

    Private Sub CboCd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboCd.KeyDown
        If e.KeyCode = Keys.F4 Or e.KeyCode = Keys.Enter Then Call CboCd_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CboCd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboCd.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    ' Caidas '
    Private Sub CboCd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboCd.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboCd, TxtCod_Cd)
        CboScd.DataSource = Nothing
        c_Neg_MnScaidas.Get_sCaidas_Cbo(" AND S.c_anula_reg=0 and S.c_codi_tg='" & TxtCod_Mt.Text & "' and S.c_codi_cd='" & TxtCod_Cd.Text & "' order by S.c_desc_scd", CboScd)
        TxtCod_Scd.Clear() : CboScd.Text = ""
    End Sub

    Private Sub CboScd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboScd.KeyDown
        If e.KeyCode = Keys.F4 Or e.KeyCode = Keys.Enter Then Call CboScd_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub CboScd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboScd.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboScd_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboScd.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboScd, TxtCod_Scd)
    End Sub

    Private Sub BtnVista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVista.Click
        Dim c_codi_tg As String = "" : Dim c_codi_cd As String = "" : Dim c_codi_scd As String = ""
        If Len(CboMt.Text) > 0 Then c_codi_tg = TxtCod_Mt.Text
        If Len(CboCd.Text) > 0 Then c_codi_cd = TxtCod_Cd.Text
        If Len(CboScd.Text) > 0 Then c_codi_scd = TxtCod_Scd.Text

        Dim Titulo As String = "Reporte de Movimientos Detallado - Compras : " & DtpFec_Inicio.Text & " Al : " & DtpFec_Final.Text & " Moneda : " & CboMon.Text
        FrmReportes2.Reporte_MovTot(DtpFec_Inicio.Text, DtpFec_Final.Text, c_codi_tg, c_codi_cd, c_codi_scd, CboMon.SelectedValue, Titulo)
        FrmReportes.Reporte_MovDet(DtpFec_Inicio.Text, DtpFec_Final.Text, c_codi_tg, c_codi_cd, c_codi_scd, CboMon.SelectedValue, Titulo)
    End Sub
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Dim c_codi_tg As String = "" : Dim c_codi_cd As String = "" : Dim c_codi_scd As String = ""
        If Len(CboMt.Text) > 0 Then c_codi_tg = TxtCod_Mt.Text
        If Len(CboCd.Text) > 0 Then c_codi_cd = TxtCod_Cd.Text
        If Len(CboScd.Text) > 0 Then c_codi_scd = TxtCod_Scd.Text

        Dgv01.DataSource = c_Neg_RptRegCompras.get_RptMovDet(DtpFec_Inicio.Text, DtpFec_Final.Text, c_codi_tg, c_codi_cd, c_codi_scd, CboMon.SelectedValue, FrmMenu.TxtCod_Emp.Text)
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Dim c_codi_tg As String = "" : Dim c_codi_cd As String = "" : Dim c_codi_scd As String = ""
        If Len(CboMt.Text) > 0 Then c_codi_tg = TxtCod_Mt.Text
        If Len(CboCd.Text) > 0 Then c_codi_cd = TxtCod_Cd.Text
        If Len(CboScd.Text) > 0 Then c_codi_scd = TxtCod_Scd.Text

        Dgv01.DataSource = c_Neg_RptRegCompras.get_RptMovDet(DtpFec_Inicio.Text, DtpFec_Final.Text, c_codi_tg, c_codi_cd, c_codi_scd, CboMon.SelectedValue, FrmMenu.TxtCod_Emp.Text)
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    ' Abrimos archivo '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Reporte_MovDetallado.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Reporte_MovDetallado.XLS"
            End If
        End If
    End Sub
End Class