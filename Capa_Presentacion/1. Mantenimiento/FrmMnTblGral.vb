Imports Capa_Negocios

Public Class FrmMnTblGral

    Dim negGiroNegocio As New Neg_MnGiroNegocio

    Private Sub FrmTblGral_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmTblGral_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmTblGral_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = New Point(60, 60)

        'Cargar giros
        negGiroNegocio.Get_GiroNegocio_Cbo(CboGiro)

        Call Cargar_Grid()

        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEdi, BtnEliminar)

    End Sub

    Public Sub Cargar_Grid()
        Dgv01.DataSource = c_Neg_MnTblGral.get_TblGral_Datos(" order by c_codi_tg ", "DGV")
        With Dgv01
            .Columns("Codigo").Width = 50
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Tabla General").Width = 300
            .Columns("Giro").Width = 140

            .Columns("c_anula_reg").Visible = False
            .Columns("c_codi_giro").Visible = False
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next

        End With
    End Sub
    Private Sub Grabar_TblGral(ByVal cOpcion As String)
        With c_Ent_MnTblGral
            .c_codi_tg = TxtCod.Text
            .c_desc_tg = TxtDesc.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            .c_codi_giro = CboGiro.SelectedValue
            c_Neg_MnTblGral.set_TblGral_Save(c_Ent_MnTblGral)
            Call Cargar_Grid()
        End With
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            BtnCerrar.Text = "&Cerrar"
            Pan02.Enabled = True : BtnGrabar.Enabled = False
            Call Cancelar_Ingreso()
            TxtCod.Clear() : TxtDesc.Clear()
            BtnEdi.Enabled = True
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        With Dgv01
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
        End With
    End Sub
    'Consultamos familias...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        Call BtnFamilia_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnFamilia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFamilia.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    FrmMnCaidas.MdiParent = FrmMenu
                    FrmMnCaidas.Show()
                    FrmMnCaidas.lblcod.Text = .Rows(fila).Cells("Codigo").Value
                    FrmMnCaidas.lbltg.Text = .Rows(fila).Cells("Tabla General").Value
                    FrmMnCaidas.Cargar_Grid()
                End If
            End If
        End With

    End Sub
    ' Editmaos Registro '
    Private Sub BtnEdi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdi.Click
        With Dgv01
            If Dgv01.RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then 'validamos si seleccionamos por error la cabecera
                    If .Rows.Count > 0 Then
                        If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                            Call Nuevo_Ingreso()
                            TxtCod.Text = Dgv01.Rows(fila).Cells("Codigo").Value
                            TxtDesc.Text = Dgv01.Rows(fila).Cells("Tabla General").Value
                            CboGiro.SelectedValue = Dgv01.Rows(fila).Cells("c_codi_giro").Value
                        Else
                            MsgBox(" Registro esta eliminado...", vbCritical, Compañia)
                        End If
                    End If
                End If
            End If
        End With
    End Sub
    'Nuevo Registro...
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        BtnCerrar.Text = "&Cancelar"
        TxtDesc.Focus()
        Call Nuevo_Ingreso()
    End Sub

    'Grabamos Registro
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Len(TxtDesc.Text) > 0 Then
            Call Grabar_TblGral("ADD")
            Call Cancelar_Ingreso() : BtnNuevo.Focus()
            MsgBox("Registro se Grabo correctamente...", MsgBoxStyle.Exclamation)
        Else
            MsgBox("Falta ingresar en nombre de la Tabla General...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub TxtDesc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDesc.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDesc.TextChanged

    End Sub
    Private Sub Cancelar_Ingreso()
        With Dgv01
            .Size = New Size(538, 245)
            .Location = New Point(1, 72)
        End With
        BtnCerrar.Text = "&Cerrar" : Pan02.Enabled = False : Pan02.Enabled = True
        Dgv01.Focus() : BtnGrabar.Enabled = False : Pan02.Enabled = True
    End Sub
    Private Sub Nuevo_Ingreso()
        BtnGrabar.Enabled = True : Pan02.Enabled = False : Pan02.Enabled = False
        TxtCod.Clear() : TxtDesc.Clear() : BtnCerrar.Text = "Cancelar"
        With Dgv01
            .Size = New Size(538, 218)
            .Location = New Point(1, 95)
            TxtDesc.Focus()
        End With
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
                            Call Grabar_TblGral("DEL") : Call Cargar_Grid()
                        End If
                    Else
                        MsgBox(" Registro se encuentra Anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With

    End Sub
End Class