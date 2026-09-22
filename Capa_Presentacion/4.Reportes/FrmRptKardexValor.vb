Public Class FrmRptKardexValor

    Private Sub FrmRptKardexValor_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.P And e.Control Then Call BtnVista_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F5 Then
            If ValidarCierre(DtpFec_Inicio.Text) = True Then
                If ValidarDatos() = True Then
                    Call Actualizar_Kardex()
                End If
            End If
        End If
    End Sub
    Private Function ValidarDatos() As Boolean
        With Dgv01
            If .RowCount > 0 Then
                If CboAlm.SelectedIndex > -1 Then
                    If Len(TxtCod_Tg.Text) = 2 Then
                        If Len(TxtCod_Cd.Text) = 2 Then
                            If Len(TxtCod_Scd.Text) > 0 Then
                                ValidarDatos = True
                            Else
                                ValidarDatos = False
                                MsgBox("2. Es necesario ingresar la SubCaída...", vbCritical, Compañia)
                            End If
                        Else
                            ValidarDatos = False
                            MsgBox("3. Es necesario ingresar la Caída...", vbCritical, Compañia)
                        End If
                    Else
                        ValidarDatos = False
                        MsgBox("4. Es necesario ingresar la Tabla General...", vbCritical, Compañia)
                    End If
                Else
                    ValidarDatos = False
                    MsgBox("5. Es necesario seleccionar un almacen válido...", vbCritical, Compañia)
                End If
            Else
                ValidarDatos = False
                MsgBox("6. No existen registro por actualizar...", vbCritical, Compañia)
            End If
        End With
    End Function
    ' metodo para actualizar el kardex en masivo
    Private Sub Actualizar_Kardex()
        If ValidarDatos() = True Then
            With Dgv01
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Dim F As String = MsgBox("¿Deseas actualizar el kardex de forma masiva?", vbYesNo + vbQuestion, Compañia)
                    If F = vbYes Then
                        c_Neg_RptKardexIQ.set_ActualizarKdx_Save(.Rows(Fila).Cells("Fecha").Value, CboAlm.SelectedValue, TxtCod_Articulo.Text)
                        Call BtnMostrar_Click(Nothing, Nothing)
                        MsgBox("Kardex se actualizo correctamente...", vbExclamation, Compañia)
                    End If
                End If
            End With
        End If
    End Sub
    Private Sub FrmRptKardexValor_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRptKardexValor_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnAlmacen.get_Almacen_Cbo(" and c_anula_reg=0 order by c_desc_alm", CboAlm)
        c_Neg_MnMtMov.get_MtMov_Cbo(" and c_anula_reg=0 order by c_desc_mt", CboMt)
        c_Neg_mnProve.get_MtProve_Cbo(" and c_anula_reg=0 order by c_desc_prov", CboProv)
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_nick_mon", CboMon)
        Dgv02.Rows.Add() : CboMon.SelectedIndex = 0 : CboAlm.SelectedIndex = 0
    End Sub
    ' Metodo para buscar los datos de la sunat por codigo de tabla general '
    Public Sub Mostrar_TblGral_Sunat()
        With c_Neg_MnTblGral.get_TblGral_Datos(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "'", "DAT")
            TxtCod_Sunat.Clear() : TxtDesc_TgSunat.Clear()
            If .Rows.Count > 0 Then
                TxtCod_Sunat.Text = .Rows(0)("c_codi_sunat").ToString
                TxtDesc_TgSunat.Text = .Rows(0)("c_desc_sunat").ToString
            End If
        End With
    End Sub
    ' Cerramos Ventana '
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    ' Mostramos Registros '
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim Prove As String = "" : Dim Mt As String = "" : Dim Saldo_Inicial As String = ""
        If CboProv.SelectedIndex > -1 Then Prove = " and K.c_codi_prov='" & CboProv.SelectedValue & "' "
        If CboMt.SelectedIndex > -1 Then Mt = " and K.c_codi_mt='" & CboMt.SelectedValue & "' "
        If ChkSaldo.Checked = False Then Saldo_Inicial = " and (Isnull(K.c_cant_ing,0) + Isnull(K.c_cant_sal,0))>0  "
        ' Cargamos de Registros '
        Call Cargar_Grid(Mt & Prove & " and K.c_fecha_kdx>='" & DtpFec_Inicio.Text & "' and K.c_fecha_kdx<='" & DtpFec_Final.Text & _
                         "' and K.c_codi_alm='" & CboAlm.SelectedValue & "' AND K.c_codi_articulo='" & TxtCod_Articulo.Text & "' And K.c_anula_reg=0 " & _
                         Saldo_Inicial & " order by K.c_fecha_kdx, K.c_nro_kdx")
    End Sub
    ' Metodo para cargar Grid '
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            'Sp_Scal_Datos_KardexIQ
            ' InputBox("", "", Cadena)
            .DataSource = c_Neg_RptKardexIQ.get_KardexIQ_Datos(Cadena, CboMon.SelectedValue)
            .Columns("Fecha").Width = 70
            .Columns("Guia").Width = 50
            .Columns("Remision").Width = 70
            .Columns("Proveedor").Width = 140
            .Columns("N.Salida").Width = 55
            .Columns("Motivo Despacho").Width = 100
            .Columns("Ingreso").Width = 75
            .Columns("Importe ").Width = 60
            .Columns("Salida").Width = 65
            .Columns("Importe  ").Width = 60
            .Columns("Saldo").Width = 70
            .Columns("Importe").Width = 70
            .Columns("Prec.Prom").Width = 65
            .Columns("Tc").Width = 35


            ' Alineacion '
            .Columns("fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Guia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Remision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Salida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Motivo Despacho").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
            .Columns("Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Importe ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Salida").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Importe  ").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Saldo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Importe").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Prec.Prom").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            ' Coloreamos Columnas '
            .Columns("Fecha").DefaultCellStyle.BackColor = Color.Ivory
            .Columns("Ingreso").DefaultCellStyle.BackColor = Color.Lavender
            .Columns("Importe ").DefaultCellStyle.BackColor = Color.Lavender
            .Columns("Salida").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("Importe  ").DefaultCellStyle.BackColor = Color.MistyRose
            .Columns("Saldo").DefaultCellStyle.BackColor = Color.Ivory
            .Columns("Importe").DefaultCellStyle.BackColor = Color.Ivory
            ' validamos si es usuario administrador para los precios '
            If FrmMenu.ChkAdmin.Checked = False Then
                .Columns("Importe ").Visible = False
                .Columns("Importe  ").Visible = False
                .Columns("Importe").Visible = False
                .Columns("Prec.Prom").Visible = False
            End If
            ' llamamos al metodo para calcular los totales '
            Call Calcular_Totales()
        End With
    End Sub
    ' Metodo para calcular Totales '
    Private Sub Calcular_Totales()
        Dim Tot_Ing As Decimal = 0 : Dim Imp_Ing As Decimal = 0
        Dim Tot_Sal As Decimal = 0 : Dim Imp_Sal As Decimal = 0
        Dim Tot_Saldo As Decimal = 0 : Dim Imp_Saldo As Decimal = 0
        ' Calculamos Totales '
        With Dgv01
            For I = 0 To .RowCount - 1
                Tot_Ing = Tot_Ing + Val(.Rows(I).Cells("Ingreso").Value)
                Imp_Ing = Imp_Ing + Val(.Rows(I).Cells("Importe ").Value.ToString)
                Tot_Sal = Tot_Sal + Val(.Rows(I).Cells("Salida").Value.ToString)
                Imp_Sal = Imp_Sal + Val(.Rows(I).Cells("Importe  ").Value.ToString)
                Tot_Saldo = Tot_Saldo + Val(.Rows(I).Cells("Saldo").Value.ToString)
                Imp_Saldo = Imp_Saldo + Val(.Rows(I).Cells("Importe").Value.ToString)
            Next

            '-- Totalizamos--'
            '-- Totalizamos--'
            If .RowCount > 0 Then
                Tot_Saldo = Val(.Rows(.RowCount - 1).Cells("Saldo").Value)
                Imp_Saldo = Val(.Rows(.RowCount - 1).Cells("Importe").Value.ToString)
            Else
                Tot_Saldo = "0.00" : Imp_Saldo = "0.00"
            End If
        End With
        With Dgv02
            .Rows(0).Cells("Ingreso_1").Value = Format(Tot_Ing, Forma_2_2)
            .Rows(0).Cells("Importe_1").Value = Format(Imp_Ing, Forma_2_2)
            .Rows(0).Cells("Salida_1").Value = Format(Tot_Sal, Forma_2_2)
            .Rows(0).Cells("Importe_2").Value = Format(Imp_Sal, Forma_2_2)
            .Rows(0).Cells("Saldo_1").Value = Format(Tot_Saldo, Forma_2_2)
            .Rows(0).Cells("Importe_3").Value = Format(Imp_Saldo, Forma_2_2)
            For i = 0 To .ColumnCount - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
            Next
            .Rows(0).Cells(0).Value = Dgv01.RowCount
        End With
    End Sub
    ' Listado de Articulos '
    Private Sub BtnConArt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConArt.Click
        With FrmConArt
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 2
            .Cargar_Grid(" and c_anula_reg=0 order by c_desc_articulo")
        End With
    End Sub
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "Reporte_Kardex.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\Reporte_Kardex.XLS"
            End If
        End If
    End Sub
    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 1, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        With Dgv01
            If .Rows.Count > 0 Then
                Call GridAExcel_Valor(Dgv01, 0, Pan02, Prb01, TxtRuta.Text)
            Else
                MsgBox("No existen registro para ser enviados a Excel...", MsgBoxStyle.Critical, Compañia)
            End If
        End With
    End Sub

    Private Sub BtnVista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVista.Click
        Dim Prove As String = "" : Dim Mt As String = "" : Dim Titulo As String = ""
        Dim vOpt As String = ""
        Titulo = "Kardex de Almacen General Del : " & DtpFec_Inicio.Text & " al : " & DtpFec_Final.Text & " Artículo : " & TxtArticulo.Text
        If CboProv.SelectedIndex > -1 Then Prove = " and K.c_codi_prov='" & CboProv.SelectedValue & "' "
        If CboMt.SelectedIndex > -1 Then Mt = " and K.c_codi_mt='" & CboMt.SelectedValue & "' "
        ' Cargamos de Registros ' 
        If CboMon.SelectedValue = "01" And ChkSaldo.Checked = True Then vOpt = "01"
        If CboMon.SelectedValue = "02" And ChkSaldo.Checked = True Then vOpt = "02"
        If CboMon.SelectedValue = "01" And ChkSaldo.Checked = False Then vOpt = "03"
        If CboMon.SelectedValue = "02" And ChkSaldo.Checked = False Then vOpt = "04"
        FrmReportes.Close()
        FrmReportes.Reporte_KardexIQ(Titulo, Prove, Mt, DtpFec_Inicio.Text, DtpFec_Final.Text, _
                                     TxtCod_Articulo.Text, CboAlm.SelectedValue, CboMon.SelectedValue, vOpt)
    End Sub

    Private Sub BtnKdxValor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKdxValor.Click
        Dim cOpcion As String = ""
        If CboMon.SelectedValue = "01" Then cOpcion = "VA1"
        If CboMon.SelectedValue = "02" Then cOpcion = "VA2"
        FrmReportes.Close()
        FrmReportes.Reporte_KardexIQSunatVal(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Tg.Text, TxtCod_Cd.Text, TxtCod_Articulo.Text, CboAlm.SelectedValue, _
                                             UCase(MonthName(Month(DtpFec_Inicio.Text))), Year(DtpFec_Inicio.Text), CboMon.SelectedValue, CboAlm.Text, TxtDesc_TgSunat.Text, TxtCod_Sunat.Text, cOpcion)
    End Sub

    Private Sub TxtCod_Tg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCod_Tg.TextChanged

    End Sub
    Private Sub TxtCod_Tg_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCod_Tg.LostFocus
        If Len(TxtCod_Tg.Text) > 0 Then
            Call Mostrar_TblGral_Sunat()
        End If
    End Sub
    ' Kardex Fisico '
    Private Sub BtnKdxFisico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKdxFisico.Click
        Dim cOpcion As String = ""
        If CboMon.SelectedValue = "01" Then cOpcion = "VA1"
        If CboMon.SelectedValue = "02" Then cOpcion = "VA2"

        FrmReportes.Reporte_KardexIQSunatFisico(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Tg.Text, TxtCod_Cd.Text, TxtCod_Articulo.Text, CboAlm.SelectedValue, _
                                             UCase(MonthName(Month(DtpFec_Inicio.Text))), Year(DtpFec_Inicio.Text), CboMon.SelectedValue, CboAlm.Text, TxtDesc_TgSunat.Text, TxtCod_Sunat.Text, cOpcion)
    End Sub

    Private Sub BtnHoja_Click(sender As Object, e As EventArgs) Handles BtnHoja.Click
        Dim cOpcion As String = ""
        If CboMon.SelectedValue = "01" Then cOpcion = "VA1"
        If CboMon.SelectedValue = "02" Then cOpcion = "VA2"
        FrmReportes.Close()
        With c_Neg_MnTblGral.get_TblGral_Datos(" and c_codi_tg='" & TxtCod_Tg.Text & "' ", "DAT")
            If .Rows.Count > 0 Then
                TxtDesc_TgSunat.Text = .Rows(0)("c_desc_tg").ToString
            End If
        End With
        ' Cargamos Reporte '
        FrmReportes.Close()
        FrmReportes.Reporte_HojaKardex(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Tg.Text, TxtCod_Cd.Text, CboAlm.SelectedValue,
                                             UCase(MonthName(Month(DtpFec_Inicio.Text))), Year(DtpFec_Inicio.Text), CboMon.SelectedValue, CboAlm.Text, TxtDesc_TgSunat.Text, TxtCod_Sunat.Text,
                                             TxtCod_Scd.Text, cOpcion, TxtCod_Articulo.Text)
    End Sub

    Private Sub TxtCod_Tg_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Tg.KeyDown
        If e.KeyCode = Keys.F1 Then
            FrmConTg.MdiParent = FrmMenu : FrmConTg.Show() : FrmConTg.TxtVar.Text = 9
            FrmConTg.Cargar_Grid(" and c_anula_reg=0 order by c_desc_tg")
        End If
    End Sub

    Private Sub TxtCod_Cd_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Cd.TextChanged

    End Sub

    Private Sub TxtCod_Cd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Cd.KeyDown
        If e.KeyCode = Keys.F1 Then
            FrmConCd.MdiParent = FrmMenu : FrmConCd.Show() : FrmConCd.TxtVar.Text = 9 : FrmConCd.TxtCod_Tg.Text = TxtCod_Tg.Text
            FrmConCd.Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' order by c_desc_cd")

        End If
    End Sub
    Private Function validarDatosKKdxEspecial() As Boolean
        If Val(TxtCod_Articulo.Text) > 0 Then
            With c_Neg_MnArticulo.get_Articulo_Datos(" and A.c_codi_articulo='" & TxtCod_Articulo.Text & "'  and A.c_anula_reg=0 ", "DAT")
                If .Rows.Count > 0 Then
                    If Val(.Rows(0)("c_opc_kdxespecial").ToString) = 1 Then
                        validarDatosKKdxEspecial = True
                    Else
                        validarDatosKKdxEspecial = False
                        MsgBox("1. Artículo no esta considerado para kardex especial...", vbCritical, Compañia)
                    End If
                Else
                    validarDatosKKdxEspecial = False
                    MsgBox("2. Artículo no existe...", vbCritical, Compañia)
                End If
            End With
        Else
            validarDatosKKdxEspecial = False
            MsgBox("3. Falta seleccionar un artículo especifico...", vbCritical, Compañia)
        End If
    End Function
    Private Sub BtnKdxExpecial_Click(sender As Object, e As EventArgs) Handles BtnKdxExpecial.Click
        If validarDatosKKdxEspecial() = True Then
            Dim cOpcion As String = ""
            If CboMon.SelectedValue = "01" Then cOpcion = "VA1"
            If CboMon.SelectedValue = "02" Then cOpcion = "VA2"
            FrmRptKdxEspecial.MdiParent = FrmMenu : FrmRptKdxEspecial.Show()
            ' Kardex Especial 
            c_Neg_RptKardexIQ.set_KdxValorEspecial_Rpt(DtpFec_Inicio.Text, DtpFec_Final.Text, CboAlm.SelectedValue, TxtCod_Articulo.Text, cOpcion)
            With FrmRptKdxEspecial
                'Sp_Scal_Datos_KardexIQ
                .Dgv01.DataSource = c_Neg_RptKardexIQ.get_KardexIQ_Datos("", "KDE")
                .ConfigurarGrid()
                .lblFechaIni.Text = DtpFec_Inicio.Text
                .lblFechaFin.Text = DtpFec_Final.Text
                .lblArticulo.Text = TxtArticulo.Text
                .lblAlmacen.Text = CboAlm.Text
                '.Dgv01.DataSource = c_Neg_RptKardexIQ.set_KdxValorEspecial_Rpt(DtpFec_Inicio.Text, DtpFec_Final.Text, CboAlm.SelectedValue, TxtCod_Articulo.Text, cOpcion)
            End With

        Else
            MsgBox("Debera seleccionar un articulo para mostrar el kardex especial...", vbExclamation, Compañia)
        End If

    End Sub

    Private Sub Dgv01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub TxtCod_Scd_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Scd.TextChanged

    End Sub
End Class