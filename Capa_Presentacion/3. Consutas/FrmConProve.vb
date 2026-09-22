Imports Capa_Negocios

Public Class FrmConProve
    Dim c_Neg_Prove As New Neg_MnProve : Dim x As Integer = 0 : Dim Foco As Integer = 0

    Private Sub FrmConProve_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' Ordenes de compras '
        If Val(TxtVar.Text) = 2 Then
            FrmOC.CboMon.Focus()
        End If
        'registro de compras
        If Val(TxtVar.Text) = 3 Then
            FrmIngComp.Show() : FrmIngComp.BtnCon2.Focus() : FrmIngComp.Cargar_Ordenes()
        End If
        'nota de credito
        If Val(TxtVar.Text) = 4 Then
            FrmIngNC.Enabled = True
            FrmIngNC.DtpFec_Prd.Focus()
        End If
        'nota de credito
        If Val(TxtVar.Text) = 5 Then
            FrmLetras.CboMon.Focus()
        End If
        'letras proveedor 2
        If Val(TxtVar.Text) = 6 Then
            FrmLetras.TxtNro_Letra2.Focus()
        End If
        'Retenciones '
        If Val(TxtVar.Text) = 7 Then
            FrmRetencion.DtpFec_Emi.Focus()
        End If
        'Costos '
        If Val(TxtVar.Text) = 8 Then
            FrmDuasCostos.TxtSerie.Focus()
        End If
        ' Facturas por pagar '
        If Val(TxtVar.Text) = 9 Then
            FrmRptFactPagar.BtnVista.Focus()
        End If
        ' Listado de Letras '
        If Val(TxtVar.Text) = 10 Then
            FrmListaLetras.CboEstado.Focus()
        End If
        ' Listado de Leasing '
        If Val(TxtVar.Text) = 11 Then
            FrmRptLeasing.BtnMostrar.Focus()
        End If

    End Sub

    Private Sub FrmConProve_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
    End Sub

    Private Sub FrmConProve_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmConProve_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub Cargar_Grid(ByVal Cadena As String)
        Dgv01.DataSource = c_Neg_Prove.get_Prove_Datos(Cadena, "DG2")
        With Dgv01
            .Columns("Codigo").Width = 60
            .Columns("Proveedor").Width = 320
            .Columns("Ruc").Width = 90
            .Columns("Codigo").HeaderCell.Style.BackColor = Color.Yellow
            .Columns("Codigo").HeaderCell.Style.ForeColor = Color.Blue
            ' Alineacion '
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub

    Private Sub TxtBuscar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBuscar.GotFocus
        With Dgv01
            If .RowCount > 0 Then
                If .CurrentCell.RowIndex > -1 Then
                    x = .CurrentCell.RowIndex : .CurrentCell = Dgv01(Dgv01.CurrentRow.Cells(0).ColumnIndex, x)
                End If
            End If
        End With
    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        With Dgv01
            If .RowCount > 0 Then
                x = .CurrentCell.RowIndex
                If e.KeyCode = Keys.Down Then
                    e.Handled = True : Foco = 1 : x += 1 : Call Movilizar_Grid(Dgv01, x, "ABAJO")
                End If
                If e.KeyCode = Keys.Up Then
                    Foco = 1 : e.Handled = True : x -= 1 : Call Movilizar_Grid(Dgv01, x, "ARRIBA")
                End If
                If e.KeyCode = Keys.Enter Then
                    If Foco = 1 Then Call Dgv01_DoubleClick(Nothing, Nothing)
                End If
            End If
        End With 'Mostramos los datos al presionar la tecla enter
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged
        Call Cargar_Grid(" and c_anula_reg=0 and c_desc_prov like '%" & Replace(TxtBuscar.Text, "'", "''") & "%' order by c_desc_prov")
    End Sub
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    'Mostramos al formulario OT...
                    If Val(TxtVar.Text) = 1 Then
                        
                    End If 'Orden de Compra
                    If Val(TxtVar.Text) = 2 Then
                        FrmOC.txtCod_Prove.Text = .Rows(fila).Cells("Codigo").Value
                        FrmOC.TxtProve.Text = .Rows(fila).Cells("Proveedor").Value
                        FrmOC.TxtRuc.Text = .Rows(fila).Cells("Ruc").Value.ToString
                        With c_Neg_Prove.get_Prove_Datos(" and c_codi_prov='" & .Rows(fila).Cells("Codigo").Value & "' ", "DAT")
                            If .Rows.Count > 0 Then
                                FrmOC.TxtDir.Text = .Rows(0)("c_direc_prov").ToString
                            End If
                        End With
                        FrmOC.CboMon.Focus()
                    End If
                    'Registro de compras
                    If Val(TxtVar.Text) = 3 Then
                        FrmIngComp.TxtCod_Prov.Text = .Rows(fila).Cells("Codigo").Value
                        FrmIngComp.TxtProve.Text = .Rows(fila).Cells("Proveedor").Value
                        FrmIngComp.Dgv01.Rows.Clear() : FrmIngComp.Dgv02.Rows.Clear()
                    End If
                    'Registro de notas de crédito
                    If Val(TxtVar.Text) = 4 Then
                        FrmIngNC.TxtCod_Prov.Text = .Rows(fila).Cells("Codigo").Value
                        FrmIngNC.TxtProve.Text = .Rows(fila).Cells("Proveedor").Value
                        FrmIngNC.Mostrar_documentos()
                    End If
                    'Registro de letras
                    If Val(TxtVar.Text) = 5 Then
                        FrmLetras.TxtCod_Prov.Text = .Rows(fila).Cells("Codigo").Value
                        FrmLetras.TxtProv.Text = .Rows(fila).Cells("Proveedor").Value
                        FrmLetras.Mostrar_documentos()
                    End If
                    'Registro de letras proveedor 2
                    If Val(TxtVar.Text) = 6 Then
                        FrmLetras.TxtCod_Prov2.Text = .Rows(fila).Cells("Codigo").Value
                        FrmLetras.TxtProv2.Text = .Rows(fila).Cells("Proveedor").Value
                    End If
                    ' Registro de Retenciones '
                    If Val(TxtVar.Text) = 7 Then
                        FrmRetencion.TxtCod_Prov.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRetencion.CboProve.Text = .Rows(fila).Cells("Proveedor").Value
                        With c_Neg_Prove.get_Prove_Datos(" and c_codi_prov='" & .Rows(fila).Cells("Codigo").Value & "' ", "DAT")
                            If .Rows.Count > 0 Then
                                FrmRetencion.TxtDir.Text = StrConv(RTrim(.Rows(0)("c_direc_prov").ToString) & " " & RTrim(.Rows(0)("c_ciudad_prov").ToString) & " " & RTrim(.Rows(0)("c_dist_prov").ToString), VbStrConv.ProperCase)
                                FrmRetencion.TxtRuc.Text = .Rows(0)("c_ruc_prov").ToString
                                FrmRetencion.Cargar_Retenciones_Pendientes() : Dgv01.Focus()
                            End If
                        End With
                    End If
                    'Registro de proveedor
                    If Val(TxtVar.Text) = 8 Then
                        FrmDuasCostos.TxtCod_Prove.Text = .Rows(fila).Cells("Codigo").Value
                        FrmDuasCostos.TXTPROVE.Text = .Rows(fila).Cells("Proveedor").Value
                    End If
                    'Facturas por pagar
                    If Val(TxtVar.Text) = 9 Then
                        FrmRptFactPagar.TxtCod_Prove.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptFactPagar.TxtProve.Text = .Rows(fila).Cells("Proveedor").Value
                    End If
                    'Listado de Letras
                    If Val(TxtVar.Text) = 10 Then
                        FrmListaLetras.TxtCod_Prov.Text = .Rows(fila).Cells("Codigo").Value
                        FrmListaLetras.TxtProve.Text = .Rows(fila).Cells("Proveedor").Value
                    End If
                    'Listado de Leasing
                    If Val(TxtVar.Text) = 11 Then
                        FrmRptLeasing.Txtcod_Prove.Text = .Rows(fila).Cells("Codigo").Value
                        FrmRptLeasing.TxtProve.Text = .Rows(fila).Cells("Proveedor").Value
                    End If
                    'Registro de leasing prestamos pagares y otros financiamientos
                    If Val(TxtVar.Text) = 12 Then
                        FrmLeasing.TxtCodProve.Text = .Rows(fila).Cells("Codigo").Value
                        FrmLeasing.TxtProve.Text = .Rows(fila).Cells("Proveedor").Value
                        FrmLeasing.TxtSerie_Credito.Focus()
                    End If
                    Me.Close()
                End If
            End If
        End With
    End Sub
    'mostramos al dar doble clic
    Private Sub Dgv01_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Enter Then Dgv01_DoubleClick(Nothing, Nothing)
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class