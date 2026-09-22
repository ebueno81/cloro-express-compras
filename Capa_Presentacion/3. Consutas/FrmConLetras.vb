Imports Capa_Negocios
Public Class FrmConLetras
    Dim c_Neg_LetCab As New Neg_LetCab
    'Cerramos la ventana del formulario
    Private Sub FrmConLetras_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FrmMenu.Enabled = True
        If Val(TxtVar.Text) = 1 Then

        End If
    End Sub

    Private Sub FrmConLetras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub
    Private Sub FrmConLetras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_LetCab.get_LetCab_Datos(Cadena, "DGV", FrmMenu.TxtCod_Emp.Text)
        With Dgv01
            .Columns("Letra").Width = 80
            .Columns("Fecha Venci.").Width = 90
            .Columns("Estado").Width = 180
            .Columns("M").Width = 40
            .Columns("Importe").Width = 70
            .Columns("c_anula_reg").Visible = False
            .Columns("c_nro_unico").Visible = False
            '.Columns("c_id_let").Visible = False
            'Alineacion...
            .Columns("Letra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Venci.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
    End Sub
    'mostramos registros
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim Rango_Fechas As String = "" : Dim Importe As String = ""
        If DtpFec_Inicio.Text = DtpFec_Final.Text Then
            Rango_Fechas = " "
        Else
            Rango_Fechas = " And C.c_fecha_venci>='" & DtpFec_Inicio.Text & "' and C.c_fecha_venci<='" & DtpFec_Final.Text & "' "
        End If
        If Val(TxtImporte.Text) > 0 Then
            Importe = " and C.c_imp_letra =" & Val(TxtImporte.Text)
        End If
        Call Cargar_Grid(" and C.c_anula_reg=0 and C.c_codi_prov like '%" & TxtCod_Prov.Text & "%'" & Rango_Fechas & Importe)
    End Sub
    'Mostramos registros al presionar la tecla enter...
    Private Sub TxtImporte_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtImporte.KeyDown
        If e.KeyCode = Keys.Enter Then Call BtnMostrar_Click(Nothing, Nothing)
    End Sub

    'mostramos registros al dar doble click
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Val(TxtVar.Text) = 1 Then
                        FrmLetras.TxtNro_Letra2.Text = .Rows(fila).Cells("Letra").Value
                        FrmLetras.Mostrar_Letras()
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub
End Class