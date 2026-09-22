Public Class FrmMnTblDetraccion

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : TxtCod.Focus()
    End Sub
    ' Metodo para un nuevo detalle '
    Private Sub Nuevo_Registro()
        Pan01.Enabled = True
        With Dgv01
            .Size = New Size(471, 242) : .Location = New Point(3, 116)
            .Enabled = False
        End With
        Call Limpiar_Texto(Pan01) : Call Activar(Pan01) : BtnGrabar.Enabled = True : Pan02.Enabled = False : BtnCerrar.Text = "Cancelar"
    End Sub
    ' Metodo para un nuevo detalle '
    Private Sub Cancelar_Registro()
        With Dgv01
            .Size = New Size(471, 269) : .Location = New Point(3, 89)
            .Enabled = True
        End With
        Call Limpiar_Texto(Pan01) : Pan01.Enabled = False : BtnGrabar.Enabled = False : Pan02.Enabled = True : BtnCerrar.Text = "&Cerrar"
    End Sub

    ' Validamos el juego de teclas '
    Private Sub FrmMnTblDetraccion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmMnDetraccion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmMnDetraccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    ' Metodo para cargar '
    Public Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_MnTblDetraccion.get_MntblDetraccion_Datos(Cadena, "DGV")
            .Columns("Codigo").Width = 50
            .Columns("Descripcion").Width = 335
            .Columns("%").Width = 60
            ' Columna Visible '
            .Columns("c_anula_reg").Visible = False
            ' Alineación de Columnas '
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("%").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Call Grid_Registros_anulados(Dgv01)
        End With
    End Sub
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Len(TxtCod.Text) > 0 Then
            If Len(TxtDesc.Text) > 0 Then
                If Val(TxtPorc.Text) > 0 Then
                    Call Grabar_Detraccion("ADD") : Call Cargar_Grid(" order by c_codi_detracc") : Call Cancelar_Registro()
                Else
                    MsgBox("Falta ingresar el porcentaje", vbCritical, Compañia)
                End If
            Else
                MsgBox("Falta ingresar la Descripcion de la Detracción...", vbCritical, Compañia)
            End If
        Else
            MsgBox("Falta ingresar el Código", vbCritical, Compañia)
        End If
    End Sub
    ' Grabamos Registros '
    Private Sub Grabar_Detraccion(ByVal cOpcion As String)
        With c_Ent_MnTblDetraccion
            .c_codi_detracc = TxtCod.Text
            .c_desc_detracc = TxtDesc.Text
            .c_porc_detracc = Val(TxtPorc.Text)
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_MnTblDetraccion.set_MnTblDetraccion_Save(c_Ent_MnTblDetraccion)
        End With
    End Sub
    
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro()
        End If
    End Sub
    ' Eliminamos Registro '
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim F As String = MsgBox("¿Confirma la eliminacion de la detracción?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then
                            TxtCod.Text = .Rows(Fila).Cells("Codigo").Value
                            Call Grabar_Detraccion("DEL")
                            .Rows(Fila).Cells("c_anula_reg").Value = 1 : .Rows(Fila).DefaultCellStyle.BackColor = Color.Gainsboro
                        End If
                    Else
                        MsgBox(" Registro se encuentra anulado, no puede ser eliminado... ", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Call Nuevo_Registro() : TxtCod.Enabled = False : TxtDesc.Focus()
                        TxtCod.Text = .Rows(Fila).Cells("Codigo").Value
                        TxtDesc.Text = .Rows(Fila).Cells("Descripcion").Value
                        TxtPorc.Text = .Rows(Fila).Cells("%").Value
                    Else
                        MsgBox(" Registro se encuentra anulado no puede ser editado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    ' Validamos los registros anulados '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
End Class