Public Class FrmRepCompras

    Private Sub FrmRepCompras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Cargar_TpoDoc()
        DtpFec_Ini.Text = "01/" & Strings.Right(Month(Now.Date) + 100, 2) & "/" & Year(Now.Date)
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_codi_mon", CboMon)
        If CboMon.Items.Count > 0 Then CboMon.SelectedIndex = 0
    End Sub
    Private Sub Cargar_TpoDoc()
        With c_Neg_MnTpoDoc.get_TpoPago_Datos(" and c_anula_reg=0 and c_opt_regcomp=1 order by c_codi_doc", "DAT")
            Lsb01.Items.Clear()
            For i = 0 To .Rows.Count - 1
                Lsb01.Items.Add(.Rows(i)("c_desc_doc").ToString & " / " & .Rows(i)("c_codi_doc").ToString)
                Lsb01.SetItemChecked(i, True)
            Next
        End With
    End Sub

    Private Sub BtnVista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVista.Click
        Dim Moneda As String = "" : Dim TpoDoc As String = ""
        If CboMon.Text = "$." Then
            Moneda = "$. - DOLARES AMERICANOS"
        Else
            Moneda = "S/. - NUEVOS SOLES"
        End If
        If Lsb01.Items.Count > 0 Then
            For i = 0 To Lsb01.Items.Count - 1
                If (Lsb01.GetItemChecked(i)) Then
                    If Len(TpoDoc) = 0 Then
                        TpoDoc = "('" & Strings.Right(Lsb01.Items(i).ToString, 2)
                    Else
                        TpoDoc = TpoDoc & "','" & Strings.Right(Lsb01.Items(i).ToString, 2)
                    End If
                End If
            Next
        End If
        'Validamos los tipo de documentos...
        If Len(TpoDoc) > 0 Then
            Dim Titulo As String = " Registro de Compras del : " & DtpFec_Ini.Text & " Al : " & DtpFec_Fin.Text & " " & Moneda
            TpoDoc = " And c_codi_doc not In " & TpoDoc & "')"
            c_Neg_RptRegCompras.get_RptRegCompras_Rpt(TpoDoc, DtpFec_Ini.Text, DtpFec_Fin.Text, CboMon.SelectedValue, FrmMenu.TxtCod_Emp.Text)
            FrmReportes2.Reporte_Registro_ComprasTot(Titulo)
            FrmReportes.Reporte_Registro_Compras(Titulo)
        Else
            MsgBox("Debe seleccionar el tipo de documento...", MsgBoxStyle.Critical, Compañia)
        End If
    End Sub

    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Registro_Compras.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Registro_Compras.XLS"
            End If
        End If
    End Sub
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Dim TpoDoc As String = ""
        If Lsb01.Items.Count > 0 Then
            For i = 0 To Lsb01.Items.Count - 1
                If (Lsb01.GetItemChecked(i)) Then
                    If Len(TpoDoc) = 0 Then
                        TpoDoc = "('" & Strings.Right(Lsb01.Items(i).ToString, 2)
                    Else
                        TpoDoc = TpoDoc & "','" & Strings.Right(Lsb01.Items(i).ToString, 2)
                    End If
                End If
            Next
        End If
        'Validamos los tipo de documentos...
        If Len(TpoDoc) > 0 Then
            TpoDoc = " And T.c_codi_doc In " & TpoDoc & "')"
            Dgv01.DataSource = c_Neg_RptRegCompras.get_RptRegCompras_Rpt(TpoDoc, DtpFec_Ini.Text, DtpFec_Fin.Text, CboMon.SelectedValue, FrmMenu.TxtCod_Emp.Text)
        Else
            MsgBox("Debe seleccionar el tipo de documento...", MsgBoxStyle.Critical, Compañia)
        End If
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Dim TpoDoc As String = ""
        If Lsb01.Items.Count > 0 Then
            For i = 0 To Lsb01.Items.Count - 1
                If (Lsb01.GetItemChecked(i)) Then
                    If Len(TpoDoc) = 0 Then
                        TpoDoc = "('" & Strings.Right(Lsb01.Items(i).ToString, 2)
                    Else
                        TpoDoc = TpoDoc & "','" & Strings.Right(Lsb01.Items(i).ToString, 2)
                    End If
                End If
            Next
        End If
        'Validamos los tipo de documentos...
        If Len(TpoDoc) > 0 Then
            TpoDoc = " And T.c_codi_doc In " & TpoDoc & "')"
            Dgv01.DataSource = c_Neg_RptRegCompras.get_RptRegCompras_Rpt(TpoDoc, DtpFec_Ini.Text, DtpFec_Fin.Text, CboMon.SelectedValue, FrmMenu.TxtCod_Emp.Text)
        Else
            MsgBox("Debe seleccionar el tipo de documento...", MsgBoxStyle.Critical, Compañia)
        End If
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
End Class