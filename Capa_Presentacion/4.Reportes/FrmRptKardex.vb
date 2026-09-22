Public Class FrmRptKardex

    Private Sub FrmRptKardex_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.P And e.Control Then Call BtnVista_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F5 Then
            If ValidarDatos() = True Then
                Call Actualizar_Kardex()
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
    Private Sub FrmRptKardex_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRptKardex_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnAlmacen.get_Almacen_Cbo(" and c_anula_reg=0 order by c_desc_alm", CboAlm)
        c_Neg_MnMtMov.get_MtMov_Cbo(" and c_anula_reg=0 order by c_desc_mt", CboMt)
        c_Neg_mnProve.get_MtProve_Cbo(" and c_anula_reg=0 order by c_desc_prov", CboProv)
        Dgv02.Rows.Add()
        CboAlm.SelectedIndex = 0
    End Sub
    ' Cerramos Ventana '
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    Public Sub IniciarGrid()
        Call BtnMostrar_Click(Nothing, Nothing)
    End Sub
    ' Mostramos Registros '
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim Prove As String = "" : Dim Mt As String = "" : Dim Saldo_Inicial As String = ""
        If CboProv.SelectedIndex > -1 Then Prove = " and K.c_codi_prov='" & CboProv.SelectedValue & "' "
        If CboMt.SelectedIndex > -1 Then
            Mt = " and K.c_codi_mt='" & CboMt.SelectedValue & "' and Isnull(K.c_cant_ing,0)>0 "
        End If

        If ChkSaldo.Checked = False Then Saldo_Inicial = " and (Isnull(K.c_cant_ing,0) + Isnull(K.c_cant_sal,0))>0  "
        ' Cargamos de Registros '
        Call Cargar_Grid(Mt & Prove & " and K.c_fecha_kdx>='" & DtpFec_Inicio.Text & "' and K.c_fecha_kdx<='" & DtpFec_Final.Text & _
                         "' and K.c_codi_alm='" & CboAlm.SelectedValue & "' AND K.c_codi_articulo='" & TxtCod_Articulo.Text & "' And K.c_anula_reg=0 " & _
                         Saldo_Inicial & " order by K.c_fecha_kdx, K.c_nro_kdx")
    End Sub
    ' Metodo para cargar Grid '
    Private Sub Cargar_Grid(ByVal Cadena As String)
        With Dgv01
            .DataSource = c_Neg_RptKardexIQ.get_KardexIQ_Datos(Cadena, "DGV")
            .Columns("Fecha").Width = 70
            .Columns("Guia").Width = 50
            .Columns("Remision").Width = 70
            .Columns("Proveedor").Width = 190
            .Columns("N.Salida").Width = 55
            .Columns("Motivo Despacho").Width = 120
            .Columns("Ingreso").Width = 75
            .Columns("Importe ").Width = 65
            .Columns("Salida").Width = 65
            .Columns("Importe  ").Width = 65
            .Columns("Saldo").Width = 70
            .Columns("Importe").Width = 75
            .Columns("Prec.Prom").Width = 65
            ' Visible '
            .Columns("Importe  ").Visible = False
            .Columns("Importe ").Visible = False
            .Columns("Importe").Visible = False
            .Columns("Prec.Prom").Visible = False
            '.Columns("Tc").Visible = False
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
                Imp_Ing = Imp_Ing + Val(.Rows(I).Cells("Importe ").Value)
                Tot_Sal = Tot_Sal + Val(.Rows(I).Cells("Salida").Value.ToString)
                Imp_Sal = Imp_Sal + Val(.Rows(I).Cells("Importe  ").Value.ToString)
            Next
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
            .Rows(0).Cells("Importe_1").Value = Format(Imp_Saldo, Forma_2_2)
            For i = 0 To .ColumnCount - 1
                .Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(i).DefaultCellStyle.BackColor = Color.WhiteSmoke
            Next
        End With
    End Sub
    ' Listado de Articulos '
    Private Sub BtnConArt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConArt.Click
        With FrmConArt
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 1
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
        Dim vOpt As String = "01"

        Titulo = "Kardex de Almacen General Del : " & DtpFec_Inicio.Text & " al : " & DtpFec_Final.Text & " Artículo : " & TxtArticulo.Text
        If CboProv.SelectedIndex > -1 Then Prove = " and K.c_codi_prov='" & CboProv.SelectedValue & "' "
        If CboMt.SelectedIndex > -1 Then Mt = " and K.c_codi_mt='" & CboMt.SelectedValue & "' "
        If ChkSaldo.Checked = False Then vOpt = "02"
        ' Cargamos de Registros ' 
        FrmReportes.Reporte_KardexIQ_Unidad(Titulo, Prove, Mt, DtpFec_Inicio.Text, DtpFec_Final.Text, _
                                     TxtCod_Articulo.Text, CboAlm.SelectedValue, vOpt)
    End Sub

    Private Sub Dgv01_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_KeyDown(sender As Object, e As KeyEventArgs) Handles Dgv01.KeyDown
        If e.KeyCode = Keys.Delete Then
            With Dgv01
                If .RowCount > 0 Then
                    Dim fila As Integer = .CurrentCellAddress.Y
                    If fila > -1 Then
                        If Strings.Right(.Rows(fila).Cells("motivo despacho").Value, 2) = "02" Then
                            If Val(.Rows(fila).Cells("Ingreso").Value.ToString) > 0 Then
                                Dim f As String = MsgBox("¿Confirma la eliminacion de la trasformacion?", vbYesNo + vbQuestion, Compañia)
                                If f = vbYes Then
                                    FrmAlmTransforma.MdiParent = FrmMenu : FrmAlmTransforma.Show()
                                    FrmAlmTransforma.AnularTransforma(.Rows(fila).Cells("N.Salida").Value.ToString)
                                End If
                            End If
                        End If
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub Dgv01_DoubleClick(sender As Object, e As EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If Strings.Right(.Rows(fila).Cells("motivo despacho").Value, 2) = "02" Then
                        If Val(.Rows(fila).Cells("Ingreso").Value.ToString) > 0 Then
                            FrmAlmTransforma.MdiParent = FrmMenu : FrmAlmTransforma.Show()
                            FrmAlmTransforma.EditarTransforma(.Rows(fila).Cells("N.Salida").Value.ToString)
                        End If
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub TxtCod_Tg_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Tg.TextChanged

    End Sub

    Private Sub TxtCod_Tg_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Tg.KeyDown
        If e.KeyCode = Keys.F1 Then
            FrmConTg.MdiParent = FrmMenu : FrmConTg.Show() : FrmConTg.TxtVar.Text = 11
            FrmConTg.Cargar_Grid(" and c_anula_reg=0 order by c_desc_tg")
        End If
    End Sub

    Private Sub TxtCod_Cd_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Cd.TextChanged

    End Sub

    Private Sub TxtCod_Cd_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Cd.KeyDown
        If e.KeyCode = Keys.F1 Then
            FrmConCd.MdiParent = FrmMenu : FrmConCd.Show() : FrmConCd.TxtVar.Text = 11 : FrmConCd.TxtCod_Tg.Text = TxtCod_Tg.Text
            FrmConCd.Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' order by c_desc_cd")
        End If
    End Sub
End Class