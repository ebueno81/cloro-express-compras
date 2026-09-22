Imports Capa_Negocios
Public Class FrmIngCompBus
    Dim c_Neg_MnTpoDoc As New Neg_MnTpoDoc : Dim c_Neg_IngComp As New Neg_IngComp
    'Cerramos...
    Private Sub FrmIngCompBus_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Val(TxtVar1.Text) = 1 Then FrmIngComp.Enabled = True
        ' --> Facturas de Importacion Artículos <-- '
        If Val(TxtVar1.Text) = 3 Then FrmDuasCostos.TxtObs.Focus()
        ' --> Facturas de Importacion doc. anexos <-- '
        If Val(TxtVar1.Text) = 4 Then FrmDuasCostos.BtnAdd.Focus()
    End Sub

    Private Sub FrmIngCompBus_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmIngCompBus_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnTpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0 order by c_desc_doc", CboDoc)
    End Sub
    'Mostramos al presionar la tecla enter...
    Private Sub BtnMos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMos.Click
        Call TxtDoc_LostFocus(Nothing, Nothing) : Call TxtSerie_LostFocus(Nothing, Nothing)
        Dim Buscar_Nro As String = "" : Dim Criterio As String = "" : Dim Fechas As String = "" 
        If CboDoc.SelectedIndex > -1 Then
            Criterio = " and I.c_codi_doc='" & CboDoc.SelectedValue & "' "
        Else
            Criterio = " "
        End If
        Fechas = " and I.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and I.c_fecha_emi<='" & DtpFec_Fin.Text & "' "
        Buscar_Nro = " and P.c_desc_prov like '%" & TxtProve.Text & _
            "%' " & Criterio & Fechas & " order by I.c_fecha_emi "
        Dgv01.DataSource = c_Neg_IngComp.get_IngComp_Datos(Buscar_Nro, "DGV", FrmMenu.TxtCod_Emp.Text)
        Call Tamaño_Grid() : Dgv01.Focus()
    End Sub
    Private Sub Tamaño_Grid()
        With Dgv01
            .Columns("Ingreso").Width = 50
            .Columns("Tpo.Documento").Width = 150
            .Columns("Serie").Width = 45
            .Columns("Documento").Width = 70
            .Columns("Fecha Emision").Width = 100
            .Columns("Proveedor").Width = 220
            'Alineacion
            .Columns("Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Tpo.Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Serie").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Emision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'visible
            .Columns("Codigo").Visible = False
            .Columns("c_codi_doc").Visible = False
        End With
    End Sub

    Private Sub TxtSerie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSerie.LostFocus
        'If CboDoc.SelectedValue = "05" Then

        'Else
        'TxtSerie.Text = Strings.Right(Val(TxtSerie.Text) + 1000, 3)
        'End If
    End Sub

    Private Sub TxtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSerie.TextChanged

    End Sub
    'MOSTRAMOS REGISTROS AL PRESIONAR LA TECLA ENTER...
    Private Sub TxtDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtDoc.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim Doc As String = " "
            If Val(TxtDoc.Text) > 0 Then
                Doc = " And I.c_serie_doc LIKE '%" & TxtSerie.Text & "%' and I.c_nro_doc LIKE '%" & TxtDoc.Text & "%' "
                Dgv01.DataSource = c_Neg_IngComp.get_IngComp_Datos(" AND I.c_anula_reg=0 " & Doc, "DGV", FrmMenu.TxtCod_Emp.Text)
                Call Tamaño_Grid() : Dgv01.Focus()
            End If
        End If
    End Sub

    Private Sub TxtDoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDoc.LostFocus
        TxtDoc.Text = Strings.Right(Val(TxtDoc.Text) + 10000000, 7)
    End Sub

    Private Sub TxtDoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDoc.TextChanged

    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(TxtVar1.Text) = 1 Then 'Ingreso de Comprobantes...
                        FrmIngComp.TxtBus_Ing.Text = .Rows(Fila).Cells("Ingreso").Value
                        FrmIngComp.Mostrar_Ingreso()
                    End If
                    If Val(TxtVar1.Text) = 2 Then 'Ingreso de Detracciones...
                        
                    End If
                    If Val(TxtVar1.Text) = 3 Then 'Costos de Importacion...
                        FrmDuasCostos.Cargar_grid_Detalles(" and I.c_nro_ing='" & .Rows(Fila).Cells("Ingreso").Value & "' and I.c_anula_reg=0 ")
                        FrmDuasCostos.Calcular_Todos()
                    End If
                    If Val(TxtVar1.Text) = 4 Then ' Facturas ingreso factura de importacion '
                        FrmDuasCostos.Cargar_grid(" and I.c_nro_ing='" & .Rows(Fila).Cells("Ingreso").Value & "' and I.c_anula_reg=0 ")
                        FrmDuasCostos.Calcular_Todos()
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub
    'Mostramos datos al dar doble clic...
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Call Dgv01_DoubleClick(Nothing, Nothing)
    End Sub
End Class