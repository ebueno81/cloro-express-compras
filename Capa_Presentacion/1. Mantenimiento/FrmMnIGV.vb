Imports Capa_Entidades
Imports Capa_Negocios
Public Class FrmMnIGV
    Dim c_neg_mnigv As New Neg_MnIgv : Dim c_ent_igv As New Ent_MnIgv
    'teclas de acceso rapido...
    Private Sub FrmMnIGV_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub
    'Avanzamos al presionar la tecla enter...
    Private Sub FrmMnIGV_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmMnIGV_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    'Configurar Grid...
    Public Sub cargar_grid()
        With Dgv01
            .DataSource = c_neg_mnigv.get_Igv_Datos(" order by c_fecha_emi", "DGV")
            .Columns("Codigo").Width = 70
            .Columns("Fecha").Width = 120
            .Columns("porcentaje").Width = 100
            .Columns("c_anula_reg").Visible = False
            .Columns("codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("porcentaje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Call Grid_Registros_anulados(Dgv01)
        End With
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro()
    End Sub
    Private Sub Nuevo_Registro()
        With Dgv01
            .Size = New Size(453, 104)
            .Location = New Point(1, 57)
            Call Limpiar_Texto(Pan03) : Pan03.Enabled = True
        End With
        Pan01.Enabled = False : BtnCerrar.Text = "&Cancelar" : BtnGrabar.Enabled = True : Dgv01.Enabled = False
        TxtPorc.Focus()
    End Sub
    Private Sub Cancelar_Registro()
        With Dgv01
            .Size = New Size(453, 132)
            .Location = New Point(1, 34)
            TxtCodigo.Clear() : TxtPorc.Clear() : Pan03.Enabled = False
        End With
        Pan01.Enabled = True : BtnCerrar.Text = "&Cerrar" : BtnGrabar.Enabled = False : Dgv01.Enabled = True
    End Sub
    'Editamos registros...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If .Rows(Fila).Cells("c_anula_reg").Value = 0 Then
                        Call Nuevo_Registro() : TxtPorc.Focus()
                        TxtCodigo.Text = .Rows(Fila).Cells("Codigo").Value
                        TxtPorc.Text = .Rows(Fila).Cells("porcentaje").Value
                        DtpFec_Emision.Text = .Rows(Fila).Cells("Fecha").Value
                    Else
                        MsgBox("Registro se encuentra anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' Validamos los registros anulados de un color distinto '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub

    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing) '75259 65 66 69
    End Sub
    'Grabamos registro...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Val(TxtPorc.Text) > 0 Then
            Dim f As String = MsgBox("¿Desea grabar el registro?", vbYesNo + vbQuestion, Compañia)
            If f = vbYes Then
                Call Grabar_Igv() : Call Cancelar_Registro() : Call cargar_grid()
            End If
        End If
    End Sub
    Private Sub Grabar_Igv()
        With c_ent_igv
            .c_codi_igv = TxtCodigo.Text
            .c_por_igv = Val(TxtPorc.Text)
            .c_fecha_emi = DtpFec_Emision.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = "ADD"
            c_neg_mnigv.set_IGV_Save(c_ent_igv)
            MsgBox("Registro se grabo correctamente...", vbInformation, Compañia)
        End With
    End Sub
    'Metodo que nos permite eliminar el registro...
    Private Sub Eliminar_Igv(ByVal Fila As Integer)
        With c_ent_igv
            .c_codi_igv = Dgv01.Rows(Fila).Cells("Codigo").Value
            .c_por_igv = 0
            .c_fecha_emi = Now.Date
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = "DEL"
            c_neg_mnigv.set_IGV_Save(c_ent_igv)
            MsgBox("Registro se elimino correctamente...", vbInformation, Compañia)
            Call cargar_grid()
        End With
    End Sub

    Private Sub TxtPorc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPorc.KeyPress
        Call solonumeros(e)
    End Sub

    Private Sub TxtPorc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPorc.TextChanged

    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro()
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If .Rows(Fila).Cells("c_anula_reg").Value = 0 Then
                        Dim F As String = MsgBox("¿Confirma la eliminación del registro?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then Call Eliminar_Igv(Fila)
                    Else
                        MsgBox("Registro se encuentra anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
End Class