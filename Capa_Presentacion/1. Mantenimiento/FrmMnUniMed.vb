Public Class FrmMnUniMed


    Private Sub FrmMnUniMed_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmMnUniMed_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmMnUniMed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_MnUniMed.get_UniMed_Datos(Cadena, "DGV")
        With Dgv01
            .Columns("Codigo").Width = 60
            .Columns("Descripcion").Width = 320
            'alineacion
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Descripcion").Width = 260
            .Columns("Cod.Sunat").Width = 60
            'color
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue
            ' Visible '
            .Columns("c_anula_reg").Visible = False
            Call Grid_Registro_Anulado(Dgv01)
        End With
    End Sub
    ' Cerramos ventana
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call cancelar_detalles()
        End If
    End Sub
    Private Sub Cancelar_Detalles()
        BtnCerrar.Text = "&Cerrar" : Pan02.Enabled = True : Pan03.Enabled = True : BtnGrabar.Enabled = False
        With Dgv01
            .Size = New Size(424, 265) : .Location = New Point(3, 74) : .Enabled = True
        End With
        TxtCod_Sunat.Enabled = False
    End Sub
    ' Nuevo Registro '
    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Call Nuevo_Registro()
                        TxtCod.Text = .Rows(Fila).Cells("Codigo").Value
                        TxtDesc.Text = .Rows(Fila).Cells("Descripcion").Value
                        TxtCod_Sunat.Text = .Rows(Fila).Cells("Cod.Sunat").Value
                    Else
                        MsgBox("Registro se encuentra Anulado no podra editarlo...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    ' Metodo para crear nuevo registro '
    Private Sub Nuevo_Registro()
        Pan02.Enabled = False : BtnCerrar.Text = "&Cancelar" : BtnGrabar.Enabled = True
        TxtCod_Sunat.Enabled = True
        With Dgv01
            .Size = New Size(424, 244) : .Location = New Point(3, 96) : .Enabled = False
        End With
        TxtCod.Clear() : TxtDesc.Clear() : TxtDesc.Focus()
    End Sub
    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro()
    End Sub
    ' Grabamos Registro '
    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            Call Grabar_UniMed("ADD") : Call Cancelar_Detalles()
        End If
    End Sub
    
    Private Sub Grabar_UniMed(ByVal cOpcion As String)
        With c_Ent_MnUnidMed
            .c_codi_unimed = TxtCod.Text
            .c_desc_unimed = TxtDesc.Text
            .c_codi_sunat = TxtCod_Sunat.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_MnUniMed.set_UniMed_Save(c_Ent_MnUnidMed)
            Call Cargar_Grid(" order by c_codi_unimed")
        End With
    End Sub
    ' Validamos registro '
    Public Function ValidarDatos() As Boolean
        If Len(TxtDesc.Text) > 0 Then
            If Len(TxtCod_Sunat.Text) > 0 Then
                ValidarDatos = True
            Else
                MsgBox("1. Falta ingresar el codigo de sunat...", vbCritical, Compañia)
                ValidarDatos = False
            End If
        Else
            MsgBox("2. Falta ingresar el nombre de la Unidad de Medida...", vbCritical, Compañia)
            ValidarDatos = False
        End If
    End Function
    ' Eliminamos registro '
    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim F As String = MsgBox("¿Desea Eliminar el Registro?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then
                            TxtCod.Text = .Rows(Fila).Cells("Codigo").Value
                            TxtDesc.Text = .Rows(Fila).Cells("Descripcion").Value
                            Call Grabar_UniMed("DEL") : Call Cancelar_Detalles()
                            Call Cargar_Grid(" order by c_desc_unimed")
                        End If
                    Else
                        MsgBox("Registro se encuentra anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    ' Grabamos registro '
    Private Sub TxtDesc_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtDesc.KeyDown

    End Sub

    Private Sub TxtDesc_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtDesc.TextChanged

    End Sub

    Private Sub Dgv01_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registro_Anulado(Dgv01)
    End Sub

    Private Sub TxtCod_Sunat_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Sunat.TextChanged

    End Sub

    Private Sub TxtCod_Sunat_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Sunat.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call BtnGrabar_Click(Nothing, Nothing)
        End If
    End Sub
End Class