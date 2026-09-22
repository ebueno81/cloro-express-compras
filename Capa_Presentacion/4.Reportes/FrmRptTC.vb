Public Class FrmRptTC

    Private Sub FrmRptTC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRptTC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(50, 50)
    End Sub

    Private Sub BtnVista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVista.Click
        Dim Titulo As String = ""
        Titulo = "Tipo de Cambio Promedio del : " & DtpFec_Ini.Text & " Al : " & DtpFec_Fin.Text
        FrmReportes.Reporte_TpoCambio(Titulo, DtpFec_Ini.Text, DtpFec_Fin.Text)
    End Sub
    ' Exportar Registros '
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Dgv01.DataSource = c_Neg_TpoCambio.get_TpoCambio_Datos(" and c_fecha_cbo>='" & DtpFec_Ini.Text & "' and c_fecha_cbo<='" & DtpFec_Fin.Text & "' order by c_Fecha_cbo", "DAT")
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    ' Mostramos en excel '
    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        Dgv01.DataSource = c_Neg_TpoCambio.get_TpoCambio_Datos(" and c_fecha_cbo>='" & DtpFec_Ini.Text & "' and c_fecha_cbo<='" & DtpFec_Fin.Text & "' order by c_Fecha_cbo", "DAT")
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    ' Seleccionamos el directorio '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Tipo_Cambio_Promedio.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Tipo_Cambio_Promedio.XLS"
            End If
        End If
    End Sub
End Class