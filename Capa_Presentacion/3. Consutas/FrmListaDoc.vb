Public Class FrmListaDoc

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    ' Exportamos Datos a Excel '
    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    ' Exportamos datos a una carpeta '
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub
    ' Abrimos ARchivo donde se graba registros o listrado '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath.ToString) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Listado_Documentos.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Listado_Documentos.XLS"
            End If
        End If
    End Sub
    ' Avanzar con enter '
    Private Sub FrmListaDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmListaDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnTpoDoc.Get_TpoDoc_Cbo(" and c_anula_reg=0  order by c_desc_doc", CboDoc)
    End Sub

    Private Sub CboDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboDoc.KeyDown
        If e.KeyCode = Keys.F4 Or e.KeyCode = Keys.Enter Then Call CboDoc_SelectedIndexChanged(Nothing, Nothing)
    End Sub
    ' Cambiamos todo a mayusculas '
    Private Sub CboDoc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboDoc.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboDoc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboDoc.LostFocus
        If Len(CboDoc.Text) = 0 Then TxtCod_Doc.Clear()
    End Sub

    Private Sub CboDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDoc.SelectedIndexChanged
        If Len(CboDoc.Text) = 0 Then
            TxtCod_Doc.Clear()
        Else
            Call Combo_Jalar_Codigo(CboDoc, TxtCod_Doc)
        End If
    End Sub
    ' Mostramos Registros '
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim anula As String = "" : Dim Cancel As String = "" : Dim vOpt As String = "" : Dim Fechas As String = "" : Dim c_codi_doc As String = ""
        Dim c_opc_cancel As String = "" : Dim Fechas2 As String = ""
        If Rdb01.Checked = True Then ' Anuladas
            anula = " and a.c_anula_reg=1 "
        Else ' No anuladas
            anula = " and a.c_anula_reg=0 "
        End If
        If TxtCod_Doc.Text = "03" Then
            If Rdb03.Checked = True Then Cancel = " "
            vOpt = "NDC" : Fechas = " and a.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and a.c_fecha_emi<='" & DtpFec_Final.Text & "' "
        Else
            If TxtCod_Doc.Text = "05" Then
                If Rdb03.Checked = True Then
                    Cancel = " and c_cancel_letra=0 " : c_opc_cancel = " and c_cancel_ing=0 "
                End If
                If Rdb04.Checked = True Then
                    Cancel = " and c_cancel_letra=1 " : c_opc_cancel = " and c_cancel_ing=1 "
                End If
                If Rdb05.Checked = True Then
                    Cancel = " " : c_opc_cancel = " "
                End If
                vOpt = "LET"
                Fechas = " and a.c_fecha_venci>='" & DtpFec_Inicio.Text & "' and a.c_fecha_venci<='" & DtpFec_Final.Text & "' "
                Fechas2 = " and a.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and a.c_fecha_emi<='" & DtpFec_Final.Text & "' "
            Else ' Documentos leasing '
                If TxtCod_Doc.Text = "13" Or TxtCod_Doc.Text = "14" Then
                    If Rdb03.Checked = True Then Cancel = " and c_opc_cancel in (0,2) "
                    If Rdb04.Checked = True Then Cancel = " and c_opc_cancel=1 "
                    If Rdb05.Checked = True Then Cancel = " "
                    vOpt = "LES" : Fechas = " and a.c_fecha_emision>='" & DtpFec_Inicio.Text & "' and a.c_fecha_emision<='" & DtpFec_Final.Text & "' "
                    c_codi_doc = " and a.c_codi_doc='" & TxtCod_Doc.Text & "' "
                Else
                    If TxtCod_Doc.Text = "11" Then
                        If Rdb03.Checked = True Then Cancel = " and c_opc_cancel (0,2) "
                        If Rdb04.Checked = True Then Cancel = " and c_opc_cancel=1 "
                        If Rdb05.Checked = True Then Cancel = " "
                        vOpt = "DUA" : Fechas = " and a.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and a.c_fecha_emi<='" & DtpFec_Final.Text & "' "
                        c_codi_doc = " "
                    Else
                        ' Documentos Varios '
                        If Rdb03.Checked = True Then Cancel = " and c_cancel_ing in (0,2) "
                        If Rdb04.Checked = True Then Cancel = " and c_cancel_ing=1 "
                        If Rdb05.Checked = True Then Cancel = " "
                        vOpt = "DOC" : Fechas = " and a.c_fecha_venci>='" & DtpFec_Inicio.Text & "' and a.c_fecha_venci<='" & DtpFec_Final.Text & "' "
                        c_codi_doc = " and a.c_codi_doc='" & TxtCod_Doc.Text & "' "
                    End If
                End If
            End If
        End If
        If Len(CboDoc.Text) > 0 Then
            Dgv01.DataSource = c_Neg_RptRegCompras.get_IngComp_Lista(Fechas & anula & Cancel & c_codi_doc, vOpt, Fechas2 & anula & c_opc_cancel & c_codi_doc)
            Call Configurar_Grid()
        Else
            MsgBox("Falta seleccionar Tipo de Documento...", vbCritical, Compañia)
        End If
    End Sub
    ' Buscamos por numero de Documentos... '
    Private Sub TxtNro_Doc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNro_Doc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtNro_Doc.Text) > 0 Then
                Dim Cadena As String = "" : Dim vOpt As String = ""
                If Len(CboDoc.Text) > 0 Then
                    If TxtCod_Doc.Text = "03" Then
                        TxtNro_Doc.Text = Strings.Right(Val(TxtNro_Doc.Text) + 10000000, 7)
                        Cadena = " AND  a.c_nro_nc ='" & TxtNro_Doc.Text & "' order by a.c_fecha_emi" : vOpt = "NDC"
                    Else
                        If TxtCod_Doc.Text = "05" Then
                            Cadena = " AND  a.c_nro_letra ='" & TxtNro_Doc.Text & "' order by a.c_fecha_giro" : vOpt = "LET"
                        Else
                            TxtNro_Doc.Text = Strings.Right(Val(TxtNro_Doc.Text) + 10000000, 7)
                            Cadena = " AND  a.c_nro_doc ='" & TxtNro_Doc.Text & "' order by a.c_fecha_emi" : vOpt = "DOC"
                        End If
                    End If
                Else
                    TxtNro_Doc.Text = Strings.Right(Val(TxtNro_Doc.Text) + 10000000, 7)
                    Cadena = " AND  a.c_nro_doc ='" & TxtNro_Doc.Text & "' order by a.c_fecha_emi" : vOpt = "DOC"
                End If
                Dgv01.DataSource = c_Neg_RptRegCompras.get_IngComp_Lista(Cadena, vOpt, FrmMenu.TxtCod_Emp.Text)
                Call Configurar_Grid()
            End If
        End If
    End Sub

    Private Sub Configurar_Grid()
        With Dgv01
            .Columns("Proveedor").Width = 160
            .Columns("TD").Width = 25
            .Columns("Tpo.Documento").Width = 90
            .Columns("Fecha Emision").Width = 100
            .Columns("Nro.").Width = 40
            .Columns("Documento").Width = 65
            .Columns("Fecha Venc.").Width = 110
            .Columns("Condicion de Pago").Width = 120
            .Columns("T.C.").Width = 40
            .Columns(" ").Width = 25
            .Columns("Total").Width = 55
            .Columns("Saldo").Width = 55
            ' Alineación de Columnas '
            .Columns("TD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Emision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Nro.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Documento").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Venc.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(" ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' Visibles ' 
            .Columns("c_anula_Reg").Visible = False
            Call Dgv01_SelectionChanged(Nothing, Nothing)
            ' Coloreamos registros anulados '
            Call Grid_Registros_anulados(Dgv01)
            Call Calcular_Totales()
        End With
    End Sub
    ' Calculamos Totales '
    Private Sub Calcular_Totales()
        With Dgv01
            Dim Tot_Mn As Decimal = 0 : Dim Tot_Us As Decimal = 0 : Dim Saldo_Mn As Decimal = 0 : Dim Saldo_Us As Decimal = 0
            For I = 0 To .RowCount - 1
                If .Rows(I).Cells(" ").Value = "S/" Then
                    Tot_Mn = Tot_Mn + Val(.Rows(I).Cells("Total").Value)
                    Saldo_Mn = Saldo_Mn + Val(.Rows(I).Cells("Saldo").Value)
                End If
                If .Rows(I).Cells(" ").Value = "$." Then
                    Tot_Us = Tot_Us + Val(.Rows(I).Cells("Total").Value)
                    Saldo_Us = Saldo_Us + Val(.Rows(I).Cells("Saldo").Value)
                End If
            Next
            TxtTot_Mn.Text = Format(Tot_Mn, Forma_2_2)
            TxtTot_Us.Text = Format(Tot_Us, Forma_2_2)
            TxtSaldo_Mn.Text = Format(Saldo_Mn, Forma_2_2)
            TxtSaldo_Us.Text = Format(Saldo_Us, Forma_2_2)
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

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub
    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub

    Private Sub TxtNro_Doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNro_Doc.TextChanged

    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' Vista Preliminar para la impresion '
    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim anula As String = "" : Dim Cancel As String = "" : Dim vOpt As String = "" : Dim Fechas As String = "" : Dim c_codi_doc As String = ""
        Dim Titulo As String = "" : Dim c_opc_cancel As String = "" : Dim Fechas2 As String = ""
        If Rdb01.Checked = True Then ' Anuladas
            anula = " and a.c_anula_reg=1 "
        Else ' No anuladas
            anula = " and a.c_anula_reg=0 "
        End If
        If TxtCod_Doc.Text = "03" Then
            If Rdb03.Checked = True Then Cancel = " "
            vOpt = "NDC" : Fechas = " and a.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and a.c_fecha_emi<='" & DtpFec_Final.Text & "' "
        Else
            If TxtCod_Doc.Text = "05" Then
                If Rdb03.Checked = True Then
                    Cancel = " and c_cancel_letra=0 " : c_opc_cancel = " and c_cancel_ing=0 "
                End If
                If Rdb04.Checked = True Then
                    Cancel = " and c_cancel_letra=1 " : c_opc_cancel = " and c_cancel_ing=1 "
                End If
                If Rdb05.Checked = True Then
                    Cancel = " " : c_opc_cancel = " "
                End If
                vOpt = "LET"
                Fechas = " and a.c_fecha_venci>='" & DtpFec_Inicio.Text & "' and a.c_fecha_venci<='" & DtpFec_Final.Text & "' "
                Fechas2 = " and a.c_fecha_venci>='" & DtpFec_Inicio.Text & "' and a.c_fecha_venci<='" & DtpFec_Final.Text & "' "
            Else ' Leasing Prestamos y otros financiamientos '
                If TxtCod_Doc.Text = "13" Or TxtCod_Doc.Text = "14" Then
                    If Rdb03.Checked = True Then Cancel = " and c_opc_cancel (0,2) "
                    If Rdb04.Checked = True Then Cancel = " and c_opc_cancel=1 "
                    If Rdb05.Checked = True Then Cancel = " "
                    vOpt = "LES" : Fechas = " and a.c_fecha_emision>='" & DtpFec_Inicio.Text & "' and a.c_fecha_emision<='" & DtpFec_Final.Text & "' "
                    c_codi_doc = " and a.c_codi_doc='" & TxtCod_Doc.Text & "' "
                Else
                    If TxtCod_Doc.Text = "11" Then
                        If Rdb03.Checked = True Then Cancel = " and c_opc_cancel (0,2) "
                        If Rdb04.Checked = True Then Cancel = " and c_opc_cancel=1 "
                        If Rdb05.Checked = True Then Cancel = " "
                        vOpt = "DUA" : Fechas = " and a.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and a.c_fecha_emi<='" & DtpFec_Final.Text & "' "
                        c_codi_doc = " "
                    Else
                        ' Documentos Varios '
                        If Rdb03.Checked = True Then Cancel = " and c_cancel_ing in (0,2) "
                        If Rdb04.Checked = True Then Cancel = " and c_cancel_ing=1 "
                        If Rdb05.Checked = True Then Cancel = " "
                        vOpt = "DOC" : Fechas = " and a.c_fecha_venci>='" & DtpFec_Inicio.Text & "' and a.c_fecha_venci<='" & DtpFec_Final.Text & "' "
                        c_codi_doc = " and a.c_codi_doc='" & TxtCod_Doc.Text & "' "
                    End If
                End If
            End If
        End If
        If Len(CboDoc.Text) > 0 Then
            c_Neg_RptRegCompras.get_IngComp_Lista(Fechas & anula & Cancel & c_codi_doc, vOpt, Fechas2 & anula & c_opc_cancel & c_codi_doc)
            Titulo = "Reporte de " & CboDoc.Text & " Del : " & DtpFec_Inicio.Text & " Al : " & DtpFec_Final.Text
            FrmReportes.Reporte_DocLista(Titulo, TxtTot_Mn.Text, TxtTot_Us.Text, TxtSaldo_Mn.Text, TxtSaldo_Us.Text)
        Else
            MsgBox("Falta seleccionar Tipo de Documento...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub Rdb05_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles Rdb05.CheckedChanged

    End Sub
End Class