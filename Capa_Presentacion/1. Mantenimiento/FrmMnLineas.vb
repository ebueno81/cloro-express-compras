Imports Capa_Negocios
Imports Capa_Entidades
Public Class FrmMnLineas
    Dim c_neg_MnLinea As New Neg_MnLinea : Dim c_Ent_MnLinea As New Ent_MnLinea
    'Juego de teclas...
    Private Sub FrmMnLineas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub
    ' Avanzamos presionado la tecla enter... '
    Private Sub FrmMnLineas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmMnLineas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Public Sub Cargar_Grid()
        With Dgv01
            .DataSource = c_neg_MnLinea.get_Linea_Datos(" order by c_codi_linea", "DGV")
            .Columns("Codigo").Width = 60
            .Columns("Descripcion").Width = 420
            .Columns("c_anula_Reg").Visible = False
            Call Grid_Registro_Anulado(Dgv01)
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    'Inicio
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 1)
    End Sub
    'Atras
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 2)
    End Sub
    'Avanza
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 3)
    End Sub
    'Final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Movilizar_Registros(Dgv01, TxtReg, 4)
    End Sub
    ' Validamos si el registro se encuentra anulado '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registro_Anulado(Dgv01)
    End Sub
    'Mostramos registros...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Tbc01.SelectedTab = Tab02 : Call Tbc01_Click(Nothing, Nothing)
            End If
        End With
    End Sub

    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    'Mantenimiento de familias...
    Private Sub BtnFamilias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFamilias.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    FrmMnFamilias.MdiParent = FrmMenu : FrmMnFamilias.Show()
                    FrmMnFamilias.LblCod_Linea.Text = .Rows(Fila).Cells("Codigo").Value
                    FrmMnFamilias.LblLinea.Text = .Rows(Fila).Cells("Descripcion").Value
                    FrmMnFamilias.Cargar_Grid()
                End If
            End If
        End With
    End Sub
    'Cerramos formularios...
    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Tbc01.SelectedTab = Tab01 : BtnGrabar.Enabled = False
    End Sub
    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 0 Then

        Else
            With Dgv01
                If .RowCount > 0 Then
                    Dim Fila As Integer = .CurrentCellAddress.Y
                    If Fila > -1 Then
                        Call Mostrar_Lineas(Fila) : TxtLinea.Enabled = False
                    End If
                End If
            End With
        End If
    End Sub
    Private Sub Mostrar_Lineas(ByVal Fila As Integer)
        With c_neg_MnLinea.get_Linea_Datos(" and c_codi_linea='" & Dgv01.Rows(Fila).Cells("Codigo").Value & "'", "DAT")
            If .Rows.Count > 0 Then
                Call Limpiar_Texto(Pan01)
                TxtCodigo.Text = .Rows(0)("c_codi_linea").ToString
                TxtLinea.Text = .Rows(0)("c_desc_linea").ToString
                TxtUsua_Crea.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_Modi.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
            End If
        End With
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Len(TxtLinea.Text) > 0 Then
            Call Grabar_Lineas("ADD")
        Else
            MsgBox("Falta ingresar el nombre de la Línea...", vbCritical, Compañia)
        End If
    End Sub
    'Grabamos tipo de cambio
    Private Sub Grabar_Lineas(ByVal cOpcion As String)
        With c_Ent_MnLinea
            .c_codi_linea = TxtCodigo.Text
            .c_desc_linea = TxtLinea.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            TxtCodigo.Text = c_neg_MnLinea.set_Linea_Save(c_Ent_MnLinea)
        End With
        Call Cargar_Grid()
        MsgBox("Registro se grabo correctamente...", vbInformation, Compañia)
        BtnCancelar_Click(Nothing, Nothing) : BtnGrabar.Enabled = False
    End Sub
    'Nuevo Registro...
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : TxtLinea.Enabled = True : TxtLinea.Focus() : BtnGrabar.Enabled = True
    End Sub
    Private Sub Nuevo_Registro()
        Tbc01.SelectedTab = Tab02 : Call Limpiar_Texto(Pan01) : TxtLinea.Enabled = True
    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If Dgv01.RowCount > 0 Then
            Tbc01.SelectedTab = Tab02
            Call Nuevo_Registro()
            Call Tbc01_Click(Nothing, Nothing) : TxtLinea.Enabled = True : TxtLinea.Focus() : BtnGrabar.Enabled = True
        End If
    End Sub
    'Eliminar Registros
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(.Rows(fila).Cells("c_anula_reg").Value) = 0 Then
                        Dim f As String = MsgBox("¿Confirma la eliminación del registro?", vbYesNo + MsgBoxStyle.Question, Compañia)
                        If f = vbYes Then
                            TxtCodigo.Text = .Rows(fila).Cells("Codigo").Value
                            Call Grabar_Lineas("DEL")
                        End If
                    Else
                        MsgBox("Registro se encuentra anulado", MsgBoxStyle.Critical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class