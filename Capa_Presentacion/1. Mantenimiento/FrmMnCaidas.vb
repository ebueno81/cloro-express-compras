Public Class FrmMnCaidas
    Private Sub FrmCaidas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If FrmMnTblGral.Visible = True And FrmMnTblGral.Enabled = False Then FrmMnTblGral.Enabled = True
    End Sub

    Private Sub FrmCaidas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEdi.Enabled = True Then Call BtnEdi_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmCaidas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmCaidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEdi, BtnEliminar)
    End Sub
    ' Metodo para Cargar Grid '
    Public Sub Cargar_Grid()
        Dgv01.DataSource = c_Neg_MnCaidas.get_Caidas_Datos(" and C.c_codi_tg='" & lblcod.Text & "' order by c_codi_cd ", "DGV")
        With Dgv01
            .Columns("Codigo").Width = 50
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue

            .Columns("Caida").Width = 380
            .Columns("c_anula_reg").Visible = False
            Call Grid_Registros_anulados(Dgv01)
            ' Alineacion '
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    Private Sub Grabar_Caidas(ByVal cOpcion As String)
        With c_Ent_MnCaidas
            .c_codi_tg = lblcod.Text
            .c_codi_cd = TxtCod.Text
            .c_desc_cd = TxtDesc.Text
            .c_concar_cta = TxtCtaCompra.Text
            .c_concar_ctavta = TxtCtaVenta.Text
            .c_concar_anexo = TxtAnexo.Text
            .c_concar_costo = TxtCosto.Text
            .c_concar_area = TxtArea.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            If Len(TxtCod.Text) = 0 Then
                TxtCod.Text = c_Neg_MnCaidas.set_Caidas_Save(c_Ent_MnCaidas)
            Else
                c_Neg_MnCaidas.set_Caidas_Save(c_Ent_MnCaidas)
            End If
        End With
    End Sub
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            BtnCerrar.Text = "&Cerrar"
            BtnNuevo.Text = "&Agregar"
            Call Cancelar_Registro()
            Dgv01.Focus()
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    'Subcaidas...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        Call BtnSCaidas_Click(Nothing, Nothing)
    End Sub


    Private Sub BtnSCaidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSCaidas.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    FrmMnSCaidas.MdiParent = FrmMenu
                    FrmMnSCaidas.Show()
                    FrmMnSCaidas.lblcod.Text = lblcod.Text
                    FrmMnSCaidas.lbltg.Text = lbltg.Text

                    FrmMnSCaidas.lblcod2.Text = .Rows(fila).Cells("Codigo").Value
                    FrmMnSCaidas.lblcd.Text = .Rows(fila).Cells("Caida").Value
                    FrmMnSCaidas.Cargar_Grid()
                End If
            End If
        End With
    End Sub
    ' Editar los registros '
    Private Sub BtnEdi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdi.Click
        With Dgv01
            If Dgv01.RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then 'validamos si seleccionamos por error la cabecera
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim Cadena As String = " And C.c_codi_tg='" & lblcod.Text & "' And C.c_codi_cd ='" & .Rows(fila).Cells("Codigo").Value & "'"
                        With c_Neg_MnCaidas.get_Caidas_Datos(Cadena, "DAT")
                            If .Rows.Count > 0 Then
                                Call Nuevo_Registro()
                                TxtCod.Text = .Rows(0)("c_codi_cd").ToString
                                TxtDesc.Text = .Rows(0)("c_desc_cd").ToString
                                TxtCtaCompra.Text = .Rows(0)("c_concar_cta").ToString
                                TxtCtaVenta.Text = .Rows(0)("c_concar_ctavta").ToString
                                TxtArea.Text = .Rows(0)("c_concar_area").ToString
                                TxtAnexo.Text = .Rows(0)("c_concar_anexo").ToString
                                TxtCosto.Text = .Rows(0)("c_concar_costo").ToString
                            End If
                        End With
                    Else
                        MsgBox("Registro se encuentra Anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    'Nuevo Registro
    Private Sub Nuevo_Registro()
        BtnGrabar.Enabled = True : BtnCerrar.Text = "&Cancelar"
        TxtDesc.Focus() : Pan02.Enabled = False : Call Limpiar_Texto(Pan04)
        With Dgv01
            .Size = New Size(472, 223) : .Location = New Point(2, 102) : .Enabled = False
        End With
        TxtDesc.Focus()
    End Sub
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro()
    End Sub
    'Cancelar registro...
    Private Sub Cancelar_Registro()
        Call Limpiar_Texto(Pan01) : BtnCerrar.Text = "&Cerrar"
        With Dgv01
            .Size = New Size(472, 347) : .Location = New Point(2, 102) : .Enabled = True
        End With
        Pan02.Enabled = True : BtnGrabar.Enabled = False
    End Sub
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Call Grabar_Caidas("ADD")
        Call Cargar_Grid() : Call Cancelar_Registro()
    End Sub
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim F As String = MsgBox("¿Confirma la eliminación del Registro?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then
                            TxtCod.Text = .Rows(Fila).Cells("Codigo").Value
                            Call Grabar_Caidas("DEL") : Call Cargar_Grid()
                        End If
                    Else
                        MsgBox(" Registro se encuentra Anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub

    Private Sub TxtCtaCompra_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCtaCompra.KeyDown
        'buscamos en el concar la cuenta '
        If e.KeyCode = Keys.F1 Then
            With FrmConConcarCta
                .Show() : .MdiParent = FrmMenu : .TxtVar1.Text = 1
                .Cargar_Grid(" Len(Pcuenta)>0  order by pcuenta")
            End With
        End If
    End Sub

    Private Sub TxtCtaCompra_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCtaCompra.TextChanged

    End Sub
    ' Consultamos cuenta de ventas '
    Private Sub TxtCtaVenta_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCtaVenta.KeyDown
        If e.KeyCode = Keys.F1 Then
            With FrmConConcarCta
                .Show() : .MdiParent = FrmMenu : .TxtVar1.Text = 2
                .Cargar_Grid(" len(Pcuenta)>0  order by pcuenta")
            End With
        End If
    End Sub

    Private Sub TxtCtaVenta_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCtaVenta.TextChanged

    End Sub

    Private Sub TxtArea_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtArea.KeyDown
        If e.KeyCode = Keys.F1 Then
            With FrmConConcarCta
                .Show() : .MdiParent = FrmMenu : .TxtVar1.Text = 3
                '.Cargar_Grid(" len(Pcuenta)>0  order by pcuenta")
                .Cargar_Grid(" ")
            End With
        End If
    End Sub

    Private Sub TxtArea_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtArea.TextChanged

    End Sub

    Private Sub TxtCosto_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCosto.KeyDown
        If e.KeyCode = Keys.F1 Then
            With FrmConConcarCta
                .Show() : .MdiParent = FrmMenu : .TxtVar1.Text = 4
                .Cargar_Grid(" ")
            End With
        End If
    End Sub

    Private Sub TxtCosto_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCosto.TextChanged

    End Sub
End Class