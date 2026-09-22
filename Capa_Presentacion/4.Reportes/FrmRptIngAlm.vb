Public Class FrmRptIngAlm
    Dim X As Integer = 0
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Dim c_opc_noingsal As String = ""
        If ChkArtEspecial.Checked = True Then c_opc_noingsal = "0"
        'Sp_Scal_Rpt_IngAlm
        Dgv01.DataSource = c_Neg_IngAlmIQ.get_IngAlm_Rpt(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Mt.Text, TxtCod_Prove.Text, TxtCod_Tg.Text,
                                     TxtCod_Cd.Text, TxtCod_Scd.Text, TxtCod_Ing.Text, TxtSerie_Guia.Text, TxtGuia.Text,
                                      TxtSerie_Doc.Text, TxtFactura.Text, CboMon.SelectedValue, c_opc_noingsal,
                                                         CboAlm.SelectedValue, "RPT")
        Call Cargar_Grid()
    End Sub
    ' Metodo para ajustar el tamaño del grid '
    Private Sub Cargar_Grid()
        With Dgv01
            .Columns("Ingreso").Width = 60
            .Columns("Motivo").Width = 110
            .Columns("Guia").Width = 35
            .Columns("Remision").Width = 55
            .Columns("Serie").Width = 35
            .Columns("Factura").Width = 55
            .Columns("Fecha").Width = 70
            .Columns("Codigo").Width = 50
            .Columns("Articulo").Width = 120
            .Columns("Proveedor/Cliente").Width = 120
            .Columns("Cant.(Kgrs.)").Width = 70
            .Columns("_").Width = 30
            .Columns("Precio").Width = 50
            .Columns("Total").Width = 65
            ' Alineacion de Columnas '
            .Columns("Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Motivo").Width = 120
            .Columns("Guia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Remision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Serie").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Factura").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Codigo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Articulo").Width = 120
            .Columns("Proveedor/Cliente").Width = 120
            .Columns("Cant.(Kgrs.)").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("_").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            ' Columnas Visibles '
            .Columns("c_Codi_prov").Visible = False
            .Columns("c_codi_mt").Visible = False
            .Columns("c_codi_tg").Visible = False
            .Columns("c_desc_tg").Visible = False
            .Columns("c_codi_cd").Visible = False
            .Columns("c_desc_cd").Visible = False
            .Columns("c_codi_scd").Visible = False
            .Columns("c_desc_scd").Visible = False
            If FrmMenu.ChkAdmin.Checked = False Then
                .Columns("Precio").Visible = False
                .Columns("Total").Visible = False
            End If
            Call Calcular_Totales() : Call Dgv01_SelectionChanged(Nothing, Nothing)
        End With
    End Sub
    ' Calculamos Totales '
    Private Sub Calcular_Totales()
        With Dgv01
            TxtConta_1.Clear() : TxtConta_2.Clear()
            TxtTot_05.Clear() : TxtTot_06.Clear() : TxtTot_07.Clear() : TxtTot_08.Clear()
            Dim Tot_5, Tot_6, Tot_7, Tot_8 As Decimal
            Dim Tot_Reg_1, Tot_Reg_2 As Integer
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("_").Value = "S/" Then
                    Tot_Reg_1 = Tot_Reg_1 + 1
                    Tot_5 = Tot_5 + Val(.Rows(i).Cells("Cant.(Kgrs.)").Value)
                    Tot_7 = Tot_7 + Val(.Rows(i).Cells("Total").Value.ToString)
                Else
                    Tot_Reg_2 = Tot_Reg_2 + 1
                    Tot_6 = Tot_6 + Val(.Rows(i).Cells("Cant.(Kgrs.)").Value)
                    Tot_8 = Tot_8 + Val(.Rows(i).Cells("Total").Value)
                End If
            Next
            TxtConta_1.Text = Tot_Reg_1 : TxtConta_2.Text = Tot_Reg_2
            TxtTot_05.Text = Format(Val(Tot_5), Forma_2_2)
            TxtTot_06.Text = Format(Val(Tot_6), Forma_2_2)
            TxtTot_07.Text = Format(Val(Tot_7), Forma_2_2)
            TxtTot_08.Text = Format(Val(Tot_8), Forma_2_2)
        End With
    End Sub
    ' Buscamos por tabla general '
    Private Sub BtnConTg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConTg.Click
        FrmConTg.MdiParent = FrmMenu : FrmConTg.Show() : FrmConTg.TxtVar.Text = 7 : FrmConTg.Cargar_Grid(" and c_anula_reg=0 order by c_desc_tg")
    End Sub
    ' Buscamos por Caidas '
    Private Sub BtnConCd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConCd.Click
        FrmConCd.MdiParent = FrmMenu : FrmConCd.Show() : FrmConCd.TxtVar.Text = 7 : FrmConCd.TxtCod_Tg.Text = TxtCod_Tg.Text
        FrmConCd.Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' order by c_Desc_cd")
    End Sub

    Private Sub BtnConScd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConScd.Click
        FrmConScd.MdiParent = FrmMenu : FrmConScd.Show() : FrmConScd.TxtVar.Text = 7 : FrmConScd.TxtCod_Tg.Text = TxtCod_Tg.Text
        FrmConScd.TxtCod_Cd.Text = TxtCod_Cd.Text
        FrmConScd.Cargar_Grid(" and S.c_anula_reg=0 and S.c_codi_tg='" & TxtCod_Tg.Text & "' and S.c_codi_cd='" & TxtCod_Cd.Text & "' order by c_desc_scd")
    End Sub

    Private Sub FrmRptIngAlm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmRptIngAlm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnMtMov.get_MtMov_Cbo(" and c_anula_reg=0 order by c_desc_mt", CboMt)
        c_Neg_mnProve.get_MtProve_Cbo(" and P.c_anula_reg=0 order by c_desc_prov", CboProve)
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 ", CboMon)
        c_Neg_MnAlmacen.get_Almacen_Cbo(" and c_anula_reg=0 order by c_desc_alm", CboAlm)
        CboAlm.SelectedIndex = 0
        CboMt.SelectedIndex = -1 : CboProve.SelectedIndex = -1 : CboMon.SelectedIndex = 0
    End Sub

    Private Sub CboMt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboMt.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    ' Obtenempos el codigo '
    Private Sub CboMt_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMt.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboMt, TxtCod_Mt)
    End Sub

    Private Sub CboProve_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CboProve.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    ' Obtenemos el codigo del proveedor '
    Private Sub CboProve_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboProve.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboProve, TxtCod_Prove)
    End Sub
    ' Abrimos ruta de archivo '
    Private Sub BtnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnOpen.Click
        Folder01.ShowDialog()
        If Len(Folder01.SelectedPath.ToString) > 0 Then
            If Len(Folder01.SelectedPath.ToString) = 3 Then
                TxtRuta.Text = Folder01.SelectedPath & "MovIngresos_Almacen.XLS"
            Else
                TxtRuta.Text = Folder01.SelectedPath & "\MovIngresos_Almacen.XLS"
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
    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    ' Buscamos por codigo de ingreso '
    Private Sub TxtCod_Ing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCod_Ing.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtCod_Ing.Text) > 0 Then
                Dim c_opc_noingsal As String = ""
                If ChkArtEspecial.Checked = True Then c_opc_noingsal = "0"
                TxtCod_Ing.Text = Strings.Right(Val(TxtCod_Ing.Text) + 10000000, 7)
                Dgv01.DataSource = c_Neg_IngAlmIQ.get_IngAlm_Rpt(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Mt.Text, TxtCod_Prove.Text, TxtCod_Tg.Text,
                                         TxtCod_Cd.Text, TxtCod_Scd.Text, TxtCod_Ing.Text, TxtSerie_Guia.Text, TxtGuia.Text,
                                          TxtSerie_Doc.Text, TxtFactura.Text, CboMon.SelectedValue, c_opc_noingsal,
                                                                 CboAlm.SelectedValue, "02")

                Call Cargar_Grid()
            End If
        End If
    End Sub

    Private Sub TxtCod_Ing_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCod_Ing.TextChanged

    End Sub

    Private Sub TxtSerie_Guia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSerie_Guia.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtSerie_Guia.Text) > 0 Then
                TxtSerie_Guia.Text = Strings.Right(Val(TxtSerie_Guia.Text) + 1000, 3)
            End If
        End If
    End Sub

    Private Sub TxtSerie_Guia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSerie_Guia.TextChanged

    End Sub
    ' --> Guia de Remision <-- '
    Private Sub TxtGuia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGuia.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtGuia.Text) > 0 Then
                Dim c_opc_noingsal As String = ""
                If ChkArtEspecial.Checked = True Then c_opc_noingsal = "0"
                TxtGuia.Text = Strings.Right(Val(TxtGuia.Text) + 10000000, 7)
                Dgv01.DataSource = c_Neg_IngAlmIQ.get_IngAlm_Rpt(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Mt.Text, TxtCod_Prove.Text, TxtCod_Tg.Text,
                                         TxtCod_Cd.Text, TxtCod_Scd.Text, TxtCod_Ing.Text, TxtSerie_Guia.Text, TxtGuia.Text,
                                          TxtSerie_Doc.Text, TxtFactura.Text, CboMon.SelectedValue, c_opc_noingsal, CboAlm.SelectedValue, "GUI")
                Call Cargar_Grid()
            End If
        End If
    End Sub

    Private Sub TxtGuia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGuia.TextChanged

    End Sub

    Private Sub TxtSerie_Doc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSerie_Doc.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtSerie_Doc.Text) > 0 Then
                TxtSerie_Doc.Text = Strings.Right(Val(TxtSerie_Doc.Text) + 1000, 3)
            End If
        End If
    End Sub

    Private Sub TxtSerie_Doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSerie_Doc.TextChanged

    End Sub
    ' Buscamos por numero de factura '
    Private Sub TxtFactura_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFactura.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtFactura.Text) > 0 Then
                Dim c_opc_noingsal As String = ""
                If ChkArtEspecial.Checked = True Then c_opc_noingsal = "0"
                TxtFactura.Text = Strings.Right(Val(TxtFactura.Text) + 10000000, 7)
                Dgv01.DataSource = c_Neg_IngAlmIQ.get_IngAlm_Rpt(DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Mt.Text, TxtCod_Prove.Text, TxtCod_Tg.Text,
                                         TxtCod_Cd.Text, TxtCod_Scd.Text, TxtCod_Ing.Text, TxtSerie_Guia.Text, TxtGuia.Text,
                                          TxtSerie_Doc.Text, TxtFactura.Text, CboMon.SelectedValue, c_opc_noingsal, CboAlm.SelectedValue, "FAC")
                Call Cargar_Grid()
            End If
        End If
    End Sub

    Private Sub TxtFactura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtFactura.TextChanged

    End Sub
    ' Impresion de Listado de Ingresos de Almacen '
    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        Dim Titulo As String = "Reporte de Ingreso a Almacén General DEL : " & DtpFec_Inicio.Text & " AL : " & DtpFec_Final.Text
        Dim c_opc_noingsal As String = ""
        If ChkArtEspecial.Checked = True Then c_opc_noingsal = "0"
        FrmReportes.Close()
        FrmReportes.Reporte_IngAlmacen(Titulo, DtpFec_Inicio.Text, DtpFec_Final.Text, TxtCod_Mt.Text, TxtCod_Prove.Text, TxtCod_Tg.Text,
                                        TxtCod_Cd.Text, TxtCod_Scd.Text, TxtSerie_Guia.Text, TxtGuia.Text,
                                        TxtSerie_Doc.Text, TxtFactura.Text, TxtCod_Ing.Text, CboMon.SelectedValue, c_opc_noingsal,
                                       CboAlm.SelectedValue, "RPT")
    End Sub
    ' Cerramos 
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub

    Private Sub TxtCod_Tg_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Tg.TextChanged

    End Sub

    Private Sub TxtCod_Tg_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCod_Tg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Len(TxtCod_Tg.Text) = 0 Then TxtTg.Clear()
            If Val(TxtCod_Tg.Text) > 0 Then
                TxtCod_Tg.Text = Strings.Right(Val(TxtCod_Tg.Text) + 100, 2)
                With c_Neg_MnTblGral.get_TblGral_Datos(" and c_codi_tg='" & TxtCod_Tg.Text & "' and c_anula_reg=0", "DAT")
                    TxtTg.Clear()
                    If .Rows.Count > 0 Then
                        TxtTg.Text = .Rows(0)("c_Desc_tg").ToString
                        X = 1 : TxtCod_Cd.Focus()
                    End If
                End With
            End If
        End If
    End Sub
    Private Sub TxtCod_Cd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCod_Cd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtCod_Cd.Text) > 0 Then
                TxtCod_Cd.Text = Strings.Right(Val(TxtCod_Cd.Text) + 100, 2)
                With c_Neg_MnCaidas.get_Caidas_Datos(" and c_codi_cd='" & TxtCod_Cd.Text & "' and c_codi_tg='" & TxtCod_Tg.Text & "' and c_anula_reg=0", "DAT")
                    TxtCd.Clear()
                    If .Rows.Count > 0 Then
                        TxtCd.Text = .Rows(0)("c_Desc_cd").ToString
                        X = 1 : TxtCod_Scd.Focus()
                    End If
                End With
            Else
                TxtCd.Clear()
            End If
        End If
    End Sub
    Private Sub TxtCod_Scd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCod_Scd.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtCod_Scd.Text) > 0 Then
                TxtCod_Scd.Text = Strings.Right(Val(TxtCod_Scd.Text) + 10000, 4)
                With c_Neg_MnScaidas.get_sCaidas_Datos(" and S.c_codi_scd='" & TxtCod_Scd.Text & "' and S.c_codi_cd='" & TxtCod_Cd.Text & "' and S.c_codi_tg='" & TxtCod_Tg.Text & "' and S.c_anula_reg=0", "DAT")
                    TxtScd.Clear()
                    If .Rows.Count > 0 Then
                        TxtScd.Text = .Rows(0)("c_Desc_scd").ToString
                        Txtcod_Articulo.Text = .Rows(0)("c_codi_articulo").ToString
                        X = 1 : BtnMostrar.Focus()
                    End If
                End With
            Else
                TxtScd.Clear() : Txtcod_Articulo.Clear()
            End If
        End If
    End Sub

    Private Sub TxtCod_Cd_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Cd.TextChanged

    End Sub

    Private Sub TxtCod_Cd_LostFocus(sender As Object, e As EventArgs) Handles TxtCod_Cd.LostFocus
        If X = 1 Then
            X = 0 : TxtCod_Cd.Focus()
        End If
    End Sub

    Private Sub TxtCod_Scd_TextChanged(sender As Object, e As EventArgs) Handles TxtCod_Scd.TextChanged

    End Sub

    Private Sub TxtCod_Scd_LostFocus(sender As Object, e As EventArgs) Handles TxtCod_Scd.LostFocus
        If X = 1 Then
            X = 0 : TxtCod_Scd.Focus()
        End If
    End Sub
End Class