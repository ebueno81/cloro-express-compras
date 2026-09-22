Public Class FrmLeasingCancel
    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    Public Sub CargarBancosCancelacion(ByVal Cadena As String, ByVal vOpt As String)
        If vOpt = "ING" Then
            'InputBox("", "", Cadena)
            CboVoucher.DropDownStyle = ComboBoxStyle.DropDownList
            c_Neg_IngComp.get_CargarHistorialCancel_Cbo(Cadena, CboVoucher)
        Else ' eliminamos
            CboVoucher.DropDownStyle = ComboBoxStyle.Simple
            CboVoucher.Text = Cadena
        End If
    End Sub

    Private Sub FrmLeasingCancel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub FrmLeasingCancel_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub BtnGrabar_Click(sender As Object, e As EventArgs) Handles BtnGrabar.Click
        Dim F As String = MsgBox("¿Desea grabar el registro?", vbYesNo + vbQuestion, Compañia)
        If F = vbYes Then
            Call GrabarRegistro("ADD")
            BtnGrabar.Enabled = False
            MsgBox("Registro se grabo correctamente...", vbInformation, Compañia)
            FrmLeasing.Mostrar_Leasing(" and  c_nro_operacion='" & FrmLeasing.TxtBuscar.Text & "' ")
            Me.Close()
        End If
    End Sub
    Private Sub GrabarRegistro(ByVal vOpt As String)
        With c_Ent_LeasingDet
            .c_nro_correl = TxtNroCorrel.Text
            .c_serie_cyb = TxtSerieVoucher.Text
            .c_ing_cyb = CboVoucher.Text
            .c_tpo_cyb = "B"
            .c_usuario = FrmMenu.lblusuario.Text
            .cOpcion=vOpt
            c_Neg_LeasingDet.set_LeasingDetCancel_Save(c_Ent_LeasingDet)
        End With
    End Sub

    Private Sub BtnEliminar_Click(sender As Object, e As EventArgs) Handles BtnEliminar.Click
        Dim F As String = MsgBox("¿Desea eliminar el registro?", vbYesNo + vbQuestion, Compañia)
        If F = vbYes Then
            Call GrabarRegistro("DEL")
            BtnGrabar.Enabled = False
            MsgBox("Registro se elimino correctamente...", vbInformation, Compañia)
            FrmLeasing.Mostrar_Leasing(" and  c_nro_operacion='" & FrmLeasing.TxtBuscar.Text & "' ")
            Me.Close()
        End If
    End Sub
End Class