Imports Capa_Entidades
Imports Capa_Negocios
Public Class FrmCierres
    'Cerramos Ventana...
    Dim c_Neg_Cierres As New Neg_Cierres
    Dim c_Ent_Cierres As New Ent_Cierres
    Private Sub FrmCierres_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 27 Then Me.Close()
    End Sub

    Private Sub FrmCierres_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmCierres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i = 1 To 12
            CboMes.Items.Add(UCase(MonthName(i)) & " / " & Strings.Right(i + 100, 2))
        Next
        CboMes.SelectedIndex = 0
        Call Cargar_Grid(" order by c_fecha_prd desc")
        CboEstado.SelectedIndex = 0
        cbocriterio.SelectedIndex = 1
        lbltotal.Text = "Total de Registros = " & dgv01.RowCount
    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        dgv01.DataSource = c_Neg_Cierres.get_Cierres_Dgv(Cadena)
        With dgv01
            .Columns("Fecha").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Fecha").HeaderCell.Style.ForeColor = Color.Blue
            .Columns("Fecha").Width = 90
            .Columns("Mes").Width = 80
            .Columns("Año").Width = 60
            .Columns("Observaciones").Width = 180
            For i = 0 To 3
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Next
        End With
    End Sub
    'mostrar datos del cierre...
    Private Sub Cierres_Mostrar(ByVal Codigo As Date)
        With c_Neg_Cierres.get_Cierres_Datos(" and c_fecha_prd='" & Codigo & "'")
            Call Limpiar_Texto(Pan03)
            If .Rows.Count > 0 Then
                TxtObs.Text = .Rows(0)("c_obs").ToString
                TxtAño.Text = .Rows(0)("c_año_prd")
                For i = 0 To CboMes.Items.Count - 1
                    If Val(Strings.Right(CboMes.Items(i).ToString, 2)) = Val(Month(.Rows(0)("c_fecha_prd"))) Then
                        CboMes.SelectedIndex = i
                        i = CboMes.Items.Count
                    End If
                Next
                'Validamos el estado del mes con fecha de cierre..
                If Val(.Rows(0)("c_estado_prd")) = 0 Then CboEstado.SelectedIndex = 0
                If Val(.Rows(0)("c_estado_prd")) = 1 Then CboEstado.SelectedIndex = 1
            End If
        End With
    End Sub

    Private Sub dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv01.CellContentClick

    End Sub
    'Mostramos al dar doble click...
    Private Sub dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgv01.DoubleClick
        With dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                Call Cierres_Mostrar(.Rows(fila).Cells("Fecha").Value)
            End If
        End With
    End Sub
    'Grabamos nuevo cierre mensual
    Private Sub Grabar()
        Dim c_Fecha_prd As Date = "01/" & Strings.Right(CboMes.Text, 2) & "/" & Val(TxtAño.Text)
        With c_Ent_Cierres
            .c_fecha_prd = c_Fecha_prd
            .c_año_prd = Val(TxtAño.Text)
            .c_mes_prd = Strings.Right(CboMes.Text, 2)
            .c_estado_prd = CboEstado.SelectedIndex
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = "ADD"
            c_Neg_Cierres.set_Usuario_Save(c_Ent_Cierres)
        End With
    End Sub
    Private Sub Eliminar_Cierre(ByVal Fila As Integer)
        Dim c_Fecha_prd As Date = "01/" & Strings.Right(CboMes.Text, 2) & "/" & Val(TxtAño.Text)
        With c_Ent_Cierres
            .c_fecha_prd = dgv01.Rows(Fila).Cells("Fecha").Value
            .c_año_prd = Val(TxtAño.Text)
            .c_mes_prd = Strings.Right(CboMes.Text, 2)
            .c_estado_prd = CboEstado.SelectedIndex
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = "DEL"
            c_Neg_Cierres.set_Usuario_Save(c_Ent_Cierres)
        End With
    End Sub
    Private Sub btncerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "[Esc] &Cerrar" Then
            Me.Close()
        Else
            Call Limpiar_Texto(Pan02)
            Call Limpiar_Texto(Pan03)
            CboMes.SelectedIndex = 0
            dgv01.Height = 195
            Pan01.Height = 201
            BtnCerrar.Text = "[Esc] &Cerrar"
            BtnGrabar.Enabled = True
            BtnBus2.Enabled = True
            CboMes.Focus()
            BtnEliminar.Enabled = True
            CboMes.Enabled = True
        End If
    End Sub

    Private Sub BtnBus2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBus2.Click
        Pan01.Height = 168
        dgv01.Height = 166
        BtnCerrar.Text = "&Cancelar"
        txtbus.Clear()
        txtbus.Focus()
        Call Limpiar_Texto(Pan03)
    End Sub

    Private Sub btnbus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnbus.Click
        Dim buscar As String = ""
        If UCase(cbocriterio.Text) = "AÑO" Then buscar = " And c_año_prd like '%" & txtbus.Text & "%' order by c_fecha_prd desc"
        If UCase(cbocriterio.Text) = "MES" Then buscar = " And c_mes_prd like '%" & txtbus.Text & "%' order by c_fecha_prd desc"
        CboEstado.SelectedIndex = 0
        Call Cargar_Grid(buscar)
        lbltotal.Text = "Total de Registros = " & dgv01.RowCount
    End Sub
    'Eliminar o anular registro...
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                Dim f As String = MsgBox("¿Desea anular Cierre?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                If f = vbYes Then
                    Call Eliminar_Cierre(fila)
                    MsgBox("Registro fue anulado correctamente...", MsgBoxStyle.Information)
                    txtbus.Clear()
                    btnbus_Click(Nothing, Nothing)
                End If
            End If
        End With
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If Val(TxtAño.Text) > 2000 And Val(TxtAño.Text) < 2020 Then
            Dim f As String = MsgBox("¿Desea grabar los datos?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
            If f = vbYes Then
                Call Grabar()
                Call btnbus_Click(Nothing, Nothing)
                CboMes.Focus()
                MsgBox("Datos se Grabaron Correctamente...", MsgBoxStyle.Exclamation)
            End If
        Else
            MsgBox("Ingrese un año valido...", MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class