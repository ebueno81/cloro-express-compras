Public Class FrmListaLetras
    ' Imprimimos Registros '
    Private Sub FrmListaLetras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.P Then Call BtnImp_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmConLetras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    '--> 
    Private Sub FrmConLetras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnBcos.get_MnBcos_Cbo(" and c_anula_reg=0 order by c_desc_bco", CboBanco)
        c_Neg_StatusLetra.Get_StatusLetra_Cbo(" order by c_desc_stletra", CboEstado)
    End Sub

    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        ' " and L.c_nro_liq='" & c_nro_liq & "' order by L.c_nro_liq"
        Dim Fecha As String = "" : Dim Bancos As String = "" : Dim Estado As String = "" : Dim Cliente As String = ""
        Dim Cancel As String = ""
        Fecha = " and L.c_fecha_venci>='" & DtpFec_Inicio.Text & "' and L.c_fecha_venci<='" & DtpFec_Final.Text & "' "
        ' Validamos si letras estan pendientes o canceladas '
        If Rdb06.Checked = True Then Cancel = " and L.c_cancel_letra in (0,2) " ' Pendientes
        If Rdb05.Checked = True Then Cancel = " and L.c_cancel_letra=1 " ' Canceladas
        If Rdb04.Checked = True Then Cancel = " " ' todas
        ' Criterio de busqueda para clientes '
        If Len(TxtCod_Prov.Text) > 0 Then Cliente = " And P.c_codi_prov='" & TxtCod_Prov.Text & "' "
        ' Criterio de busqueda estado de letra '
        If Len(CboEstado.Text) > 0 Then Estado = " And L.c_codi_stletra='" & CboEstado.SelectedValue & "' "
        ' Criterio  de busqueda por banco '
        If Len(CboBanco.Text) > 0 Then Bancos = " And L.c_codi_bco='" & CboBanco.SelectedValue & "' "
        Call cargar_Grid(" and L.c_anula_reg=0 " & Fecha & Cliente & Estado & Bancos & Cancel & " order by L.c_nro_letra ")
    End Sub
    Private Sub cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_LetCab.get_LetCab_Datos(Cadena, "LIS", FrmMenu.TxtCod_Emp.Text)
            .Columns("Letra").Width = 80
            .Columns("Proveedor").Width = 260
            .Columns("Dias").Width = 40
            .Columns("F.Venci.").Width = 100
            .Columns("Estado").Width = 130
            .Columns("Banco").Width = 180
            .Columns(" ").Width = 30
            .Columns("Importe").Width = 50
            ' Alineacion '
            .Columns("Letra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Dias").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("F.Venci.").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' Visible '
            .Columns("c_anula_reg").Visible = False
            ' Mostramos documentos amarrados a la letra '
            Call Dgv01_SelectionChanged(Nothing, Nothing)
            ' Coloreamos registros anulados '
            Call Grid_Registros_anulados(Dgv01)
            Call Calcular_Totales()
        End With
    End Sub
    ' Calculamos Totales '
    Private Sub Calcular_Totales()
        With Dgv01
            Dim Tot_Mn As Decimal = 0 : Dim Tot_Us As Decimal = 0
            For I = 0 To .RowCount - 1
                If .Rows(I).Cells(" ").Value = "S/" Then Tot_Mn = Tot_Mn + Val(.Rows(I).Cells("Importe").Value)
                If .Rows(I).Cells(" ").Value = "$." Then Tot_Us = Tot_Us + Val(.Rows(I).Cells("Importe").Value)
            Next
            TxtTot_Mn.Text = Format(Tot_Mn, Forma_2_2)
            TxtTot_Us.Text = Format(Tot_Us, Forma_2_2)
        End With
    End Sub
    Private Sub TxtLetra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtLetra.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtLetra.Text) > 0 Then
                Call cargar_Grid(" And L.c_nro_letra='" & TxtLetra.Text & "' order by c_fecha_giro")
            End If
        End If
    End Sub

    Private Sub TxtLetra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLetra.TextChanged

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
    ' Cerramos Ventana '
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub CboEstado_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboEstado.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.F4 Then Call Combo_Jalar_Codigo(CboEstado, TxtCod_Estado)
    End Sub
    ' Convertimos en Estado '
    Private Sub CboEstado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboEstado.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEstado.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboEstado, TxtCod_Estado)
    End Sub
    ' Mostramos datos por el banco '
    Private Sub CboBanco_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CboBanco.KeyDown
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.F4 Then Call Combo_Jalar_Codigo(CboBanco, TxtCod_Bco)
    End Sub
    ' Convertimos en mayusculas '
    Private Sub CboBanco_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboBanco.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub

    Private Sub CboBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboBanco.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboBanco, TxtCod_Bco)
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
                TxtRuta.Text = Folder01.SelectedPath & "Listado_Letras.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Listado_Letras.XLS"
            End If
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub
    ' Imprimimos Reporte de Letras '
    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        ' " and L.c_nro_liq='" & c_nro_liq & "' order by L.c_nro_liq"
        Dim Fecha As String = "" : Dim Bancos As String = "" : Dim Estado As String = "" : Dim Cliente As String = ""
        Dim Cancel As String = "" : Dim Titulo As String = ""
        Fecha = " and L.c_fecha_venci>='" & DtpFec_Inicio.Text & "' and L.c_fecha_venci<='" & DtpFec_Final.Text & "' "
        ' Validamos si letras estan pendientes o canceladas '
        If Rdb06.Checked = True Then Cancel = " and L.c_cancel_letra in(0,2) " ' Anuladas
        If Rdb05.Checked = True Then Cancel = " and L.c_cancel_letra=1 " ' Canceladas
        If Rdb04.Checked = True Then Cancel = " " ' todas
        ' Criterio de busqueda para clientes '
        If Len(TxtProve.Text) > 0 Then Cliente = " And P.c_codi_prov='" & TxtCod_Prov.Text & "' "
        ' Criterio de busqueda estado de letra '
        If Len(CboEstado.Text) > 0 Then Estado = " And L.c_codi_stletra='" & CboEstado.SelectedValue & "' "
        ' Criterio  de busqueda por banco '
        If Len(CboBanco.Text) > 0 Then Bancos = " And L.c_codi_bco='" & CboBanco.SelectedValue & "' "
        c_Neg_LetCab.get_LetCab_Datos(" and L.c_anula_Reg=0 " & Fecha & Cliente & Estado & Bancos & Cancel & " order by L.c_nro_letra ", "RPT", FrmMenu.TxtCod_Emp.Text)
        If Rdb06.Checked = True Then Titulo = "Listado de Letras Pendientes Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text
        If Rdb05.Checked = True Then Titulo = "Listado de Letras Canceladas Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text
        If Rdb04.Checked = True Then Titulo = "Listado de Todas las Letras Del: " & DtpFec_Inicio.Text & " Al: " & DtpFec_Final.Text
        FrmReportes.Reporte_LetrasLista(Titulo)
    End Sub

    Private Sub BtnConTpoDoc_Click(sender As System.Object, e As System.EventArgs) Handles BtnConTpoDoc.Click
        FrmConProve.Show() : FrmConProve.MdiParent = FrmMenu
        FrmConProve.Cargar_Grid(" and c_anula_reg=0 order by c_desc_prov")
        FrmConProve.TxtVar.Text = 10
    End Sub
    ' nuevo registro
    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        TxtCod_Bco.Clear() : CboBanco.SelectedValue = "" : TxtCod_Prov.Clear() : CboEstado.SelectedValue = "" : TxtProve.Clear()
    End Sub
End Class