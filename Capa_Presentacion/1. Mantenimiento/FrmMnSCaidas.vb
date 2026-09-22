Public Class FrmMnSCaidas
    Dim var1 As Integer = 0 : Dim x2 As Integer = 0
    Private Sub FrmSCaidas_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If FrmMnCaidas.Visible = True And FrmMnCaidas.Enabled = False Then FrmMnCaidas.Enabled = True
    End Sub

    Private Sub FrmSCaidas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        If e.Control And e.KeyCode = Keys.N Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then Call BtnEdi_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmSCaidas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmSubCaidas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEdi, BtnEliminar)
    End Sub
    Public Sub Cargar_Grid()
        Dgv01.DataSource = c_Neg_MnScaidas.get_sCaidas_Datos(" and S.c_codi_tg='" & lblcod.Text & "' and S.c_codi_cd='" & lblcod2.Text & "' order by c_codi_scd ", "DGV")
        With Dgv01
            .Columns("Codigo").Width = 50
            .Columns("Codigo-I.Q.").Width = 70
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue

            .Columns("Descripcion").Width = 360

            .Columns("c_anula_reg").Visible = False
            Call Grid_Registros_anulados(Dgv01)
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo-I.Q.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    Private Sub Nuevo_Registro()
        BtnCerrar.Text = "&Cancelar"
        Pan03.Enabled = False : BtnGrabar.Enabled = True : TxtScd.Focus()
        Dgv01.Size = New Size(617, 330) : Dgv01.Location = New Point(2, 128) : Dgv01.Enabled = False
        Call Limpiar_Texto(Pan01)
    End Sub
    Private Sub Grabar_sCaidas(ByVal cOpcion As String)
        With c_Ent_MnScaidas
            .c_codi_tg = lblcod.Text
            .c_codi_cd = lblcod2.Text
            .c_codi_scd = TxtCod.Text
            .c_desc_scd = TxtScd.Text
            .c_codi_articulo = TxtCod_Articulo.Text
            .c_anexo_concar = TxtAnexo.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_MnScaidas.set_sCaidas_Save(c_Ent_MnScaidas)
            Call Cargar_Grid()
        End With
    End Sub
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            BtnCerrar.Text = "&Cerrar" : Call Cancelar_Registro()
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub

    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        If BtnEdi.Enabled = True Then Call BtnEdi_Click(Nothing, Nothing)
    End Sub
    'Editar Registros... de caidas...
    Private Sub BtnEdi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdi.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then 'validamos si seleccionamos por error la cabecera
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim Cadena As String = " And S.c_codi_tg='" & lblcod.Text & "' And S.c_codi_cd='" & lblcod2.Text & "' And S.c_codi_scd ='" & .Rows(fila).Cells("Codigo").Value & "'"
                        With c_Neg_MnScaidas.get_sCaidas_Datos(Cadena, "DAT")
                            If .Rows.Count > 0 Then
                                Call Nuevo_Registro()
                                TxtCod.Text = .Rows(0)("c_codi_scd").ToString
                                TxtScd.Text = .Rows(0)("c_desc_scd").ToString
                                TxtCod_Articulo.Text = .Rows(0)("c_codi_articulo").ToString
                                TxtAnexo.Text = .Rows(0)("c_anexo_concar").ToString
                            End If
                        End With
                    Else
                        MsgBox(" Registro se encuentra Anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : TxtScd.Focus()
    End Sub
    ' Funcion para validar grabar registro '
    Private Function ValidarDatos() As Boolean
        If Len(TxtCod_Articulo.Text) = 8 Then
            If Len(TxtScd.Text) > 0 Then ' Validamos si se ha ingresado el nombre de la subcaida
                If TxtCod_Articulo.Text = "00000000" Then ' Validamos si el codigo es 00000000
                    ValidarDatos = True
                Else ' Validamos si el codigo existe en la tabla de articulos '
                    With c_Neg_MnArticulo.get_Articulo_Datos(" And A.c_anula_reg=0 And A.c_codi_articulo='" & TxtCod_Articulo.Text & "'", "DAT")
                        If .Rows.Count > 0 Then
                            ' Validamos si codigo de articulo esta ingresado a las subcaidas '
                            With c_Neg_MnScaidas.get_sCaidas_Datos(" And S.c_anula_reg=0 And S.c_codi_articulo='" & TxtCod_Articulo.Text & "' ", "DAT")
                                If .Rows.Count > 0 Then
                                    ' Validamos si registro esta ingresado '
                                    If Len(TxtCod.Text) > 0 Then
                                        If .Rows(0)("c_codi_tg").ToString = lblcod.Text And .Rows(0)("c_codi_cd").ToString = lblcod2.Text _
                                        And .Rows(0)("c_codi_scd").ToString = TxtCod.Text And .Rows(0)("c_codi_Articulo").ToString = TxtCod_Articulo.Text Then
                                            ValidarDatos = True
                                        Else
                                            MsgBox("Código de Artículo ya fue registrado anteriomente para la Tabla General: " & .Rows(0)("c_codi_tg").ToString &
                                                   " Caída: " & .Rows(0)("c_codi_cd").ToString & " SubCaída: " & .Rows(0)("c_codi_scd").ToString)
                                            ValidarDatos = False
                                        End If
                                    Else
                                        MsgBox("Código de Artículo ya fue registrado anteriomente para la Tabla General: " & .Rows(0)("c_codi_tg").ToString &
                                                   " Caída: " & .Rows(0)("c_codi_cd").ToString & " SubCaída: " & .Rows(0)("c_codi_scd").ToString)
                                        ValidarDatos = False
                                    End If
                                Else
                                    ValidarDatos = True
                                End If
                            End With
                        Else
                            ValidarDatos = False
                            MsgBox("Código de Artículo no existe, revisar...", vbCritical, Compañia)
                        End If
                    End With
                End If
            Else
                ValidarDatos = False
                MsgBox("Falta ingresar el nombre de la SubCaída...", vbCritical, Compañia)
            End If
        Else
            MsgBox("Código de Articulo debe tener 8 dígitos...", vbCritical, Compañia)
            ValidarDatos = False
        End If
    End Function
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            Call Grabar_sCaidas("ADD")
            Call Cancelar_Registro() : Dgv01.Focus()
        End If
    End Sub
    Private Sub Cancelar_Registro()
        Pan03.Enabled = True : BtnGrabar.Enabled = False
        Dgv01.Size = New Size(617, 360) : Dgv01.Location = New Point(2, 102) : Dgv01.Enabled = True
        Call Limpiar_Texto(Pan01) : BtnCerrar.Text = "&Cerrar"
        Dgv01.Enabled = True : Dgv01.Focus() : Pan03.Enabled = True : BtnGrabar.Enabled = False
    End Sub

    Private Sub Pan04_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pan04.Paint

    End Sub
    ' Grabamos al presionar la tecla enter '
    Private Sub TxtCod_Articulo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCod_Articulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCod_Articulo.Text) = 0 Then
                TxtCod_Articulo.Text = "00000000"
            End If
            Call BtnGrabar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TxtCod_Articulo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCod_Articulo.TextChanged

    End Sub
    ' Anulamos subcaida
    Private Sub BtnEliminar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then 'validamos si seleccionamos por error la cabecera
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        TxtCod.Text = .Rows(fila).Cells("Codigo").Value
                        Dim F As String = MsgBox("¿Desea eliminar registro?", vbYesNo + vbQuestion, Compañia)
                        If F = vbYes Then
                            Call Grabar_sCaidas("DEL") : Call Cargar_Grid()
                        End If
                    Else
                        MsgBox(" Registro se encuentra Anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnArticulos_Click(sender As Object, e As EventArgs) Handles BtnArticulos.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If .Rows(Fila).Cells("c_anula_reg").Value = 0 Then
                        var1 = Fila
                        If Val(.Rows(Fila).Cells("Codigo-I.Q.").Value.ToString) > 0 Then
                            'MsgBox("1. Caida ya fue creada como artículo para realizar alguna modificación debera realizarla desde el maestro de Artículos", vbCritical, Compañia)
                            FrmMnArticulos.Close()
                            FrmMnArticulos.MdiParent = FrmMenu : FrmMnArticulos.Show()
                            FrmMnArticulos.Nuevo_Registro()
                            FrmMnArticulos.Mostrar_Articulos(.Rows(Fila).Cells("Codigo-I.Q.").Value.ToString)
                            FrmMnArticulos.TxtObs.Focus()
                        Else
                            FrmMnArticulos.Close()
                            FrmMnArticulos.MdiParent = FrmMenu : FrmMnArticulos.Show() : FrmMnArticulos.Agregar_Articulos()
                            FrmMnArticulos.TxtDes.Text = .Rows(Fila).Cells("Descripcion").Value
                            FrmMnArticulos.TxtCod_Scd.Text = .Rows(Fila).Cells("Codigo").Value
                            FrmMnArticulos.TxtScd.Text = .Rows(Fila).Cells("Descripcion").Value
                            FrmMnArticulos.TxtCod_Cd.Text = lblcod2.Text
                            FrmMnArticulos.TxtCd.Text = lblcd.Text
                            FrmMnArticulos.TxtCod_Tg.Text = lblcod.Text
                            FrmMnArticulos.TxtTg.Text = lbltg.Text
                            FrmMnArticulos.BtnConTg.Enabled = False
                            FrmMnArticulos.BtnConCd.Enabled = False
                            FrmMnArticulos.BtnConScd.Enabled = False
                            FrmMnArticulos.CboUniMed.SelectedIndex = 1
                            If x2 = 0 Then
                                FrmMnArticulos.TxtObs.Focus()
                            Else
                                FrmMnArticulos.TxtObs.Focus()
                            End If
                        End If
                    Else
                        MsgBox("2. Registro se encuentra anulado no podra realizar ninguna creacion...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
End Class