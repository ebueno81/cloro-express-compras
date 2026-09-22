Public Class FrmMnTpoDoc
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If BtnGrabar.Text = "&Grabar" Then
            If Len(TxtDesc.Text) > 0 Then
                Call Grabar_TpoPago("ADD")
                Call Cancelar_Registro()
                Call Cargar_Grid(" order by c_desc_doc")
            Else
                MsgBox("Falta ingresar el documento...", MsgBoxStyle.Critical, Compañia)
            End If
        Else
            TxtDesc.Focus()
            Call Nuevo_Registro()
        End If
    End Sub
    'Grabamos nueva forma de pago...
    Private Sub Grabar_TpoPago(ByVal cOpcion As String)
        With c_Ent_MnTpoDoc
            Dim c_opt_regcomp As Integer = 0
            If ChkOpt.Checked = True Then c_opt_regcomp = 1
            .c_codi_doc = TxtCodigo.Text
            .c_desc_doc = TxtDesc.Text
            .c_codi_concar = TxtCod_Concar.Text
            .c_opt_regcomp = c_opt_regcomp
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            If Len(TxtCodigo.Text) = 0 Then
                TxtCodigo.Text = c_Neg_MnTpoDoc.set_TpoPago_Save(c_Ent_MnTpoDoc)
            Else
                c_Neg_MnTpoDoc.set_TpoPago_Save(c_Ent_MnTpoDoc)
            End If
        End With
    End Sub
    'Editamos registro...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Call Nuevo_Registro()
                        TxtCodigo.Text = .Rows(fila).Cells("codigo").Value
                        TxtDesc.Text = .Rows(fila).Cells("Descripcion").Value
                        TxtCod_Concar.Text = .Rows(fila).Cells("c_codi_concar").Value.ToString
                        '-- > Registros de Compras < --'
                        If Val(.Rows(fila).Cells("c_opt_regcomp").Value) = 1 Then
                            ChkOpt.Checked = True
                        Else
                            ChkOpt.Checked = False
                        End If
                        TxtDesc.Focus()
                    Else
                        MsgBox("Registro se encuentra eliminado, no puede ser modificado...", MsgBoxStyle.Critical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    'Cancelamos registro...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro()
        End If
    End Sub
    'manejo de teclas...
    Private Sub FrmMnFPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmMnFPago_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    ' Iniciamos Formuario '
    Private Sub FrmMnFPago_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        Call Validar_Permiso(Me.Name, BtnGrabar, BtnEditar, BtnEliminar)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnTpoDoc.get_TpoPago_Datos(Cadena, "DGV")
        With Dgv01
            .Columns("Codigo").Width = 50
            .Columns("Descripcion").Width = 260
            .Columns("c_anula_reg").Visible = False
            .Columns("c_codi_concar").Visible = False
            .Columns("c_opt_regcomp").Visible = False
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Call Grid_Registros_anulados(Dgv01)
        End With
    End Sub
    ' Columnas Anuladas '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
    'Editamos registro...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim f As String = MsgBox("¿Desea eliminar el registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Compañia)
                        If f = vbYes Then
                            TxtCodigo.Text = Dgv01.Rows(fila).Cells("codigo").Value
                            Call Grabar_TpoPago("DEL")
                            MsgBox("Registro se fue eliminado...", MsgBoxStyle.Exclamation, Compañia)
                            Call Cargar_Grid(" order by c_desc_doc")
                        End If
                    Else
                        MsgBox("Registro se encuentra Anulado, no podra realizar")
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub Nuevo_Registro()
        Call Limpiar_Texto(Pan01)
        BtnGrabar.Text = "&Grabar"
        BtnEditar.Enabled = False
        BtnEliminar.Enabled = False
        BtnCerrar.Text = "&Cancelar"
        Dgv01.Size = New Size(349, 166)
    End Sub
    Private Sub Cancelar_Registro()
        BtnGrabar.Text = "&Agregar"
        BtnEditar.Enabled = True
        BtnEliminar.Enabled = True
        BtnCerrar.Text = "&Cerrar"
        Dgv01.Size = New Size(349, 250)
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class