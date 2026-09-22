Public Class FrmRptLeasing

    Private Sub FrmRptLeasing_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRptLeasing_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DtpFec_Inicio.Text = "01/01/2014"
        Call BtnMostrar_Click(Nothing, Nothing)
    End Sub
    Private Sub BtnMostrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnMostrar.Click
        Dim c_opc_cancel As String = "" : Dim Cadena As String = "" : Dim Prove As String = ""
        Dim c_opc_cancel2 As String = ""
        ' Pendientes o amortizados
        If Rdb01.Checked = True Then
            c_opc_cancel = " and L.c_opc_cancel not in (1) "
            c_opc_cancel2 = " and D.c_opc_cancel not in (1) "
        End If
        ' Cancelados
        If Rdb02.Checked = True Then
            c_opc_cancel = " and L.c_opc_cancel = 1 "
            c_opc_cancel2 = " and D.c_opc_cancel = 1 "
        End If
        ' proveedor 
        If Len(Txtcod_Prove.Text) > 0 Then Prove = " and L.c_codi_prov ='" & Txtcod_Prove.Text & "' "
        ' Mostramos grid general '
        If Rdb03.Checked = True Then
            Cadena = " and L.c_fecha_emision>='" & DtpFec_Inicio.Text & "' and L.c_fecha_emision<='" & DtpFec_Final.Text & "' " & Prove & c_opc_cancel & " order by c_fecha_emision"
            Call Cargar_Grid(Cadena, "DGV")
        End If
        ' Mostramos grid por cuotas '
        If Rdb04.Checked = True Then
            Cadena = " and D.c_anula_reg=0 and D.c_fecha_venci>='" & DtpFec_Inicio.Text & "' and D.c_fecha_venci<='" & DtpFec_Final.Text & "' " & Prove & c_opc_cancel2 & " order by c_desc_prov, c_desc_doc, c_fecha_venci"
            Call Cargar_Grid(Cadena, "RPT")
        End If

    End Sub
    ' metodo para cargar grid
    Private Sub Cargar_Grid(ByVal Cadena As String, ByVal vOpt As String)
        With Dgv01
            Dim c_codi_clie As String = Txtcod_Prove.Text
            If Len(TxtProve.Text) = 0 Then c_codi_clie = ""
            ' facturas pendietes de detracciones
            If vOpt = "DGV" Then
                .DataSource = c_Neg_LeasingCab.get_LeasingCab_Datos(Cadena, vOpt)
            Else
                .DataSource = c_Neg_LeasingDet.get_LeasingDet_Datos(Cadena, vOpt)
            End If

            .Columns("Codigo").Width = 60
            .Columns("Tipo").Width = 100
            .Columns("Nro.Credito").Width = 70
            If vOpt = "DGV" Then
                .Columns("Fecha").Width = 70
            Else
                .Columns("Vcto.").Width = 70
            End If
            .Columns("Proveedor").Width = 220
            .Columns("Observaciones").Width = 120
            .Columns("_").Width = 30
            .Columns("Total").Width = 70
            .Columns("Acta.").Width = 70
            .Columns("Saldo").Width = 70

            ' alineacion 
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nro.Credito").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            If vOpt = "DGV" Then
                .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Else
                .Columns("Vcto.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If
            .Columns("_").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Acta.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            Call Calcular_Totales() : Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub
    ' metodo para calcular totales
    Private Sub Calcular_Totales()
        With Dgv01
            Dim Tot_1, Tot_2, Tot_3, Tot_4, Tot_5, Tot_6 As Decimal
            Dim Tot_Reg_1, Tot_Reg_2 As Integer
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("_").Value = "S/" Then
                    Tot_Reg_1 = Tot_Reg_1 + 1
                    Tot_1 = Tot_1 + Val(.Rows(i).Cells("Total").Value)
                    Tot_3 = Tot_3 + Val(.Rows(i).Cells("Acta.").Value)
                    Tot_5 = Tot_5 + Val(.Rows(i).Cells("Saldo").Value)
                Else
                    Tot_Reg_2 = Tot_Reg_2 + 1
                    Tot_2 = Tot_2 + Val(.Rows(i).Cells("Total").Value)
                    Tot_4 = Tot_4 + Val(.Rows(i).Cells("Acta.").Value)
                    Tot_6 = Tot_6 + Val(.Rows(i).Cells("Saldo").Value)
                End If
            Next
            TxtConta_1.Text = Tot_Reg_1 : TxtConta_2.Text = Tot_Reg_2
            TxtTot_Mn.Text = Format(Val(Tot_1), Forma_2_2)
            TxtTot_Us.Text = Format(Val(Tot_2), Forma_2_2)
            TxtActa_Mn.Text = Format(Val(Tot_3), Forma_2_2)
            TxtActa_Us.Text = Format(Val(Tot_4), Forma_2_2)
            TxtSaldo_Mn.Text = Format(Val(Tot_5), Forma_2_2)
            TxtSaldo_Us.Text = Format(Val(Tot_6), Forma_2_2)

        End With
    End Sub
    'Cerramos formulario...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
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
    ' Coloreamos si registro se encuentra anulado '
    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        'On Error Resume Next
        'Call Grid_Registros_anulados(Dgv01)
    End Sub
    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    ' Abrimos ruta de archivo '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath.ToString) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Listado_Retenciones.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Listado_Retenciones.XLS"
            End If
        End If
    End Sub
    ' Exportamos Registros de Boletas '
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    ' Exportamos datos a excel '
    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub BtnImp_Click(sender As System.Object, e As System.EventArgs) Handles BtnImp.Click
        Dim Titulo As String = "" : Dim c_codi_prov As String = "" : Dim vOpt As String = ""
        Dim Titulo2 As String = ""
        If Len(TxtProve.Text) > 0 Then c_codi_prov = Txtcod_Prove.Text
        ' leasing pendientes
        If Rdb01.Checked = True Then
            vOpt = "PEN"
            Titulo = "Listado de Financiamientos Pendientes: " & TxtProve.Text & " Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text
            Titulo2 = "Listado de Financiamientos Pendientes por Cuotas: " & TxtProve.Text & " Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text
        End If
        ' leasing cancelados
        If Rdb02.Checked = True Then
            vOpt = "CER"
            Titulo = "Listado de Financiamientos Cancelados: " & TxtProve.Text & " Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text
            Titulo2 = "Listado de Financiamientos Cancelados por Cuotas: " & TxtProve.Text & " Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text
        End If
        ' Reporte general '
        If Rdb03.Checked = True Then
            FrmReportes.Reporte_Leasing(c_codi_prov, vOpt, Titulo, DtpFec_Inicio.Text, DtpFec_Final.Text)
        End If
        ' Reporte detallado por cuotas '
        If Rdb04.Checked = True Then
            FrmReportes.Reporte_LeasingDet(c_codi_prov, vOpt, Titulo2, DtpFec_Inicio.Text, DtpFec_Final.Text)
        End If

    End Sub

    Private Sub BtnConProve_Click(sender As System.Object, e As System.EventArgs) Handles BtnConProve.Click
        With FrmConProve
            .MdiParent = FrmMenu : .Show() : .TxtVar.Text = 11 : .Cargar_Grid(" and c_anula_reg=0 ")
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
End Class