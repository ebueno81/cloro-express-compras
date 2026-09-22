Public Class FrmMnAlmacen
    Private Sub FrmMnAlmacen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmMnAlmacen_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmMnAlmacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnAlmacen.get_Almacen_Datos(Cadena, "DGV")
        With Dgv01
            .Columns("Codigo").Width = 60
            .Columns("Almacen").Width = 220
            .Columns("Ubicacion").Width = 200

            'alineacion
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'color
            '.Columns("Codigo").HeaderCell.Style.BackColor = Color.Black
            '.Columns("Codigo").HeaderCell.Style.ForeColor = Color.WhiteSmoke
            .Columns("c_anula_reg").Visible = False
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                    Dgv01.Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
        End With
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Cancelar_Registro() : Call Cargar_Grid(" order by c_desc_alm")
        End If
    End Sub
    Private Sub Cancelar_Registro()
        With Dgv01
            .Location = New Point(3, 63) : .Size = New Size(475, 239) : Call Desactivar(Pan01)
            BtnNuevo.Enabled = True : BtnEditar.Enabled = True : BtnEliminar.Enabled = True
            .Enabled = True : BtnCerrar.Text = "&Cerrar" : BtnGrabar.Enabled = False
        End With
    End Sub
    ' nuevo registro
    Private Sub Nuevo_Registro()
        With Dgv01
            Call Limpiar_Texto(Pan01) : Call Activar(Pan01) : TxtCod.Enabled = False
            .Location = New Point(3, 63) : .Size = New Size(475, 139)
            BtnNuevo.Enabled = False : BtnEditar.Enabled = False : BtnEliminar.Enabled = False
            .Enabled = False : BtnCerrar.Text = "&Cancelar" : BtnGrabar.Enabled = True
        End With
    End Sub
    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_Reg").Value) = 0 Then
                        Call Nuevo_Registro() : TxtDesc.Focus()
                        TxtCod.Text = .Rows(Fila).Cells("Codigo").Value
                        TxtDesc.Text = .Rows(Fila).Cells("Almacen").Value
                        Txtdireccion.Text = .Rows(Fila).Cells("Ubicacion").Value.ToString
                        TxtDist.Text = .Rows(Fila).Cells("Distrito").Value
                        TxtProv.Text = .Rows(Fila).Cells("Provincia").Value
                        TxtDpto.Text = .Rows(Fila).Cells("Dpto.").Value
                    Else
                        MsgBox("Registro se encuentra anulado no podra realizar ninguna modificación...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : TxtDesc.Focus()
    End Sub

    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGrabar.Click
        If Len(TxtDesc.Text) > 0 Then
            Call Grabar_Registro("ADD")
            Call Cancelar_Registro() : Call Cargar_Grid(" order by c_desc_alm")
        End If
    End Sub
    Private Sub Grabar_Registro(ByVal cOpcion As String)
        With c_Ent_MnAlmacen
            .c_codi_alm = TxtCod.Text
            .c_desc_alm = TxtDesc.Text
            .c_direc_alm = Txtdireccion.Text
            .c_dist_alm = TxtDist.Text
            .c_prov_alm = TxtProv.Text
            .c_dpto_alm = TxtDpto.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_MnAlmacen.set_Almacen_Save(c_Ent_MnAlmacen)
        End With
    End Sub

    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_Reg").Value) = 0 Then
                        Dim F As String = MsgBox("¿Desea eliminar el registro?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then
                            TxtCod.Text = .Rows(Fila).Cells("Codigo").Value
                            Call Grabar_Registro("DEL") : Call Cargar_Grid(" order by c_desc_alm")
                        End If
                    Else
                        MsgBox("Registro se encuentra eliminado no podra realizar ninguna modificación...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
End Class