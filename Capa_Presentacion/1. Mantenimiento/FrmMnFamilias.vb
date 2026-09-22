Imports Capa_Entidades
Imports Capa_Negocios
Public Class FrmMnFamilias
    Dim c_Neg_MnFamilias As New Neg_MnFamilia : Dim c_Ent_MnFamilia As New Ent_MnFamilia
    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
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
   
    Public Sub Cargar_Grid()
        With Dgv01
            .DataSource = c_Neg_MnFamilias.get_Familia_Datos(" and c_codi_linea='" & LblCod_Linea.Text & "' order by c_codi_familia", "DGV")
            .Columns("Codigo").Width = 60
            .Columns("Descripcion").Width = 420
            .Columns("c_anula_Reg").Visible = False
            Call Grid_Registro_Anulado(Dgv01)
            ' Alineacion de Columna Codigo ' 
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
    ' Validamos los registros anulados '
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

    Private Sub BtnSFamilias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSFamilias.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    FrmMnSubFamilias.MdiParent = FrmMenu : FrmMnSubFamilias.Show()
                    FrmMnSubFamilias.LblCod_Familia.Text = .Rows(Fila).Cells("Codigo").Value
                    FrmMnSubFamilias.LblFamilia.Text = .Rows(Fila).Cells("Descripcion").Value
                    FrmMnSubFamilias.LblCod_Linea.Text = LblCod_Linea.Text
                    FrmMnSubFamilias.LblLinea.Text = LblLinea.Text
                    FrmMnSubFamilias.Cargar_Grid()
                End If
            End If
        End With
    End Sub
    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 0 Then

        Else
            With Dgv01
                If .RowCount > 0 Then
                    Dim Fila As Integer = .CurrentCellAddress.Y
                    If Fila > -1 Then
                        Call Mostrar_Familias(Fila) : TxtFamilia.Enabled = False
                    End If
                End If
            End With
        End If
    End Sub
    Private Sub Mostrar_Familias(ByVal Fila As Integer)
        With c_Neg_MnFamilias.get_Familia_Datos(" and c_codi_familia='" & Dgv01.Rows(Fila).Cells("Codigo").Value & "' and c_codi_linea='" & LblCod_Linea.Text & "'", "DAT")
            If .Rows.Count > 0 Then
                Call Limpiar_Texto(Pan01)
                TxtCodi_Linea.Text = .Rows(0)("c_codi_linea").ToString
                TxtCodigo.Text = .Rows(0)("c_codi_familia").ToString
                TxtFamilia.Text = .Rows(0)("c_desc_familia").ToString
                TxtUsua_Crea.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_Modi.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
            End If
        End With
    End Sub
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Len(TxtFamilia.Text) > 0 Then
            Call Grabar_Familias("ADD")
        Else
            MsgBox("Falta ingresar el nombre de la linea...", vbCritical, Compañia)
        End If
    End Sub
    'Grabamos tipo de cambio
    Private Sub Grabar_Familias(ByVal cOpcion As String)
        With c_Ent_MnFamilia
            .c_codi_linea = LblCod_Linea.Text
            .c_codi_familia = TxtCodigo.Text
            .c_desc_familia = TxtFamilia.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            c_Neg_MnFamilias.set_Familia_Save(c_Ent_MnFamilia)
        End With
        Call Cargar_Grid()
        MsgBox("Registro se grabo correctamente...", vbInformation, Compañia)
        BtnCancelar_Click(Nothing, Nothing) : BtnGrabar.Enabled = False
    End Sub
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Tbc01.SelectedTab = Tab01 : BtnGrabar.Enabled = False
    End Sub
    'Nuevo Registro...
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : TxtFamilia.Enabled = True : TxtFamilia.Focus() : BtnGrabar.Enabled = True
        TxtCodi_Linea.Text = LblCod_Linea.Text
    End Sub
    Private Sub Nuevo_Registro()
        Tbc01.SelectedTab = Tab02 : Call Limpiar_Texto(Pan01) : TxtFamilia.Enabled = True
    End Sub
    'Editamos registros...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_Reg").Value) = 0 Then
                        Tbc01.SelectedTab = Tab02 : Call Nuevo_Registro()
                        Call Tbc01_Click(Nothing, Nothing) : TxtFamilia.Enabled = True : TxtFamilia.Focus() : BtnGrabar.Enabled = True
                    Else
                        MsgBox("Registro se encuentra anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
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
                            Call Mostrar_Familias(fila) : Call Grabar_Familias("DEL")
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
    'Juego de Teclas...
    Private Sub FrmMnFamilias_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub
    'Avanzamos al presionar la tecla enter...
    Private Sub FrmMnFamilias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    ' Validamos los permisos '
    Private Sub FrmMnFamilias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
End Class