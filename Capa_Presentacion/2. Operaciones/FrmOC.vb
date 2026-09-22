Imports System.IO
Public Class FrmOC
    Private stringToPrint As String
    Dim x As Integer = 0 'variable que trabajara con el grid enfoque al presionar la tecla enter
    Dim Focos As Integer = 0
    Dim pos As Integer = 0 'posicion q toma el grid cuando se modifica un registro...
    Dim Agregar As Integer = 0 ' agregamos registro o editamos 
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro()
    End Sub
    Private Sub Nuevo_Registro()
        Call Limpiar_Texto(Pan01) : Call Limpiar_Texto(Pan04)
        Call Limpiar_Texto(Pan03) : Call Limpiar_Texto(Pan05)
        Call Limpiar_Texto(Pan06) : Call Limpiar_Texto(Pan07)
        Call Limpiar_Texto(Pan08) : BtnGenerar.Enabled = False
        TxtObs.Enabled = True : DtpFec_Emi.Enabled = True
        BtnGrabar.Enabled = True
        Tbc01.SelectedTab = Tab02 : TxtProve.Focus()
        txtCod_Prove.Enabled = False : TxtDir.Enabled = False
        TxtRuc.Enabled = False : TxtCod_Tg.Enabled = False
        TxtCod_Cd.Enabled = False : TxtCod_Scd.Enabled = False
        LblTC.Visible = True : LblIgv.Visible = True
        LblPor.Visible = True : TxtTC.Visible = True
        TxtCant_Igv.Visible = True : DtpFec_Emi.Enabled = True
        CboMon.Enabled = True : BtnCon1.Enabled = True
        CboSerie_Oq.Enabled = True : Dgv01.Rows.Clear()
        BtnEstado.BackColor = Color.Maroon
        BtnEstado.Text = "PENDIENTE"
        Pan09.Enabled = True : BtnAceptar.Enabled = False
        CboMon.SelectedIndex = -1 : CboSerie_Oq.SelectedIndex = -1 : TxtNro_Oq.Enabled = True
        DtpFec_Emi.Text = Now.Date : BtnEdit.Enabled = True : BtnCancel2.Enabled = True
        CboSerie_Oq.Enabled = True : Call Mostrar_TpoCambio() : BtnCon1.Focus()
        BtnConFPago.Enabled = True : BtnIng1.Enabled = True
        ChkIGV.Visible = True : ChkIGV.Checked = False
        TxtCant_Igv.Enabled = True
    End Sub

    Private Sub FrmOrdCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Dim f As String = MsgBox("¿Desea cerrar la aplicación...?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Compañia)
            If f = vbYes Then Me.Close()
        End If
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then BtnGrabar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.P Then If BtnImp.Enabled = True Then BtnImp_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmOrdCompra_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmOrdCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 ", CboMon)
        c_Neg_OCSerie.Get_OCSerie_Cbo(" and c_anula_reg=0", 0, CboSerie)
        c_Neg_OCSerie.Get_OCSerie_Cbo(" and c_anula_reg=0", 0, CboSerie_Oq)
        c_Neg_MnUniMed.Get_UniMed_Cbo(" and c_anula_reg=0 order by c_desc_unimed", CboUniMed)
        CboSerie.SelectedIndex = 0
        DtpFec_Inicio.Text = "01/" & Strings.Right(Month(Date.Now) + 100, 2) & "/" & Year(Date.Now)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEli)
    End Sub

    Public Sub Cargar_GRid_OC(ByVal Cadena As String)
        Dim Rango_Fechas As String = " "
        If DtpFec_Fin.Text = DtpFec_Inicio.Text Then
            Rango_Fechas = " "
        Else
            Rango_Fechas = " and O.c_fecha_emi>='" & DtpFec_Inicio.Text & "' and O.c_fecha_emi<='" & DtpFec_Fin.Text & "' "
        End If

        Dgv02.DataSource = c_Neg_OC.get_OC_Datos(Rango_Fechas & Cadena, FrmMenu.TxtCod_Emp.Text, "DGV")
        With Dgv02
            .Columns("Compra").Width = 60
            .Columns("Compra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Compra").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Fecha Registro").Width = 105
            .Columns("Fecha Registro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Fecha Emision").Width = 100
            .Columns("Fecha Emision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Emision").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Proveedor").Width = 260
            .Columns("Observaciones").Width = 260
            .Columns("c_anula_reg").Visible = False
            .Columns("c_estado_oc").Visible = False
            .Columns("Fecha Registro").DefaultCellStyle.BackColor = Drawing.Color.Ivory
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("c_anula_reg").Value = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
            'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = "1 / " & .RowCount
        End With
    End Sub
    'Metodo que nos permite buscar solo por numero de orden de compra...
    Private Sub Cargar_Grid_2(ByVal Cadena As String)
        Dgv02.DataSource = c_Neg_OC.get_OC_Datos(Cadena, FrmMenu.TxtCod_Emp.Text, "DGV")
        With Dgv02
            .Columns("Compra").Width = 60
            .Columns("Compra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Compra").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Fecha Registro").Width = 105
            .Columns("Fecha Registro").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Fecha Emision").Width = 100
            .Columns("Fecha Emision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Fecha Emision").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("Proveedor").Width = 260
            .Columns("Observaciones").Width = 260
            .Columns("c_anula_reg").Visible = False
            .Columns("c_estado_oc").Visible = False

            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("c_anula_reg").Value = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                End If
            Next
            'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = "1 / " & .RowCount
        End With
    End Sub

    Private Sub TxtProve_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProve.KeyDown
        If e.KeyCode = Keys.F1 Then
            If BtnCon1.Enabled = True Then Call BtnCon1_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TxtProve_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtProve.LostFocus
        If x = 1 Then
            TxtProve.Focus()
            x = 0
        End If
    End Sub

    Private Sub TxtProve_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProve.TextChanged

    End Sub
    Private Sub CboMon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If x = 1 Then
            CboMon.Focus()
            x = 0
        End If
    End Sub



    Private Sub TxtCant_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCant.TextChanged
        Call Calcular()
    End Sub
    Private Sub Calcular()
        TxTImpor.Text = Format(Val(TxtCant.Text) * Val(TxtP_Unit.Text), Forma_1_2)
    End Sub

    Private Sub TxtP_Unit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtP_Unit.TextChanged
        Call Calcular()
    End Sub

    Private Sub ChkAfecto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAfecto.CheckedChanged

    End Sub

    Private Sub BtnCon3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub Agregar_Registro(ByVal Fila As Integer)
        With Dgv01
            .Rows(Fila).Cells("Mot").Value = TxtCod_Tg.Text
            .Rows(Fila).Cells("Cantidad").Value = Format(Val(TxtCant.Text), Forma_1_4)
            .Rows(Fila).Cells("Unid").Value = CboUniMed.Text
            .Rows(Fila).Cells("c_codi_unimed").Value = CboUniMed.SelectedValue
            .Rows(Fila).Cells("Mot").Value = TxtCod_Tg.Text
            .Rows(Fila).Cells("Cd").Value = TxtCod_Cd.Text
            .Rows(Fila).Cells("Scd").Value = TxtCod_Scd.Text
            '.Rows(Fila).Cells("Codigo").Value = TxtCodigo.Text
            .Rows(Fila).Cells("Descripcion").Value = TxtScd.Text
            'MsgBox(Format(Val(TxtP_Unit.Text), Forma_1_6))
            'MsgBox(Fila)
            .Rows(Fila).Cells("Precio").Value = Format(Val(TxtP_Unit.Text), Forma_1_6)
            .Rows(Fila).Cells("Importe").Value = Format(Val(TxTImpor.Text), Forma_1_2)
            .Rows(Fila).Cells("Obs").Value = TxtObs2.Text
            .Rows(Fila).Cells("Item").Value = TxtItem.Text
            .Rows(Fila).Cells("Codigo").Value = TxtCod_Articulo.Text
            'Validamos si artículo esta afecto a igv
            If ChkAfecto.Checked = True Then
                .Rows(Fila).Cells("Afecto").Value = 1
            Else
                .Rows(Fila).Cells("Afecto").Value = 0
            End If
        End With
        Call Calcular_Totales()
    End Sub
    Private Sub Calcular_Totales()
        With Dgv01
            Dim Importe As Decimal = 0
            Call Limpiar_Texto(Pan07)
            For i = 0 To .Rows.Count - 1
                ' Validamos si registro se encuentra anulado '
                If Val(.Rows(i).Cells("anula").Value) = 0 Then
                    If Val(.Rows(i).Cells("afecto").Value) = 1 Then
                        TxtTot_Afecto.Text = Format(Val(TxtTot_Afecto.Text) + Val(.Rows(i).Cells("importe").Value), Forma_1_2)
                    Else
                        TxtTot_Inaf.Text = Format(Val(TxtTot_Inaf.Text) + Val(.Rows(i).Cells("importe").Value), Forma_1_2)
                    End If
                End If
            Next
            TxtTot_Igv.Text = Format(Val(TxtTot_Afecto.Text) * (Val(TxtCant_Igv.Text) / 100), Forma_1_3)
            TxtTot_Igv.Text = Format(Val(TxtTot_Igv.Text), Forma_1_2)
            TxtTotal.Text = Format(Val(TxtTot_Afecto.Text) + Val(TxtTot_Igv.Text) + Val(TxtTot_Inaf.Text), Forma_1_2)
        End With
    End Sub
    ' funcion para validar la grabacion de la orden de compra
    Private Function ValidarDatos() As Boolean
        If Len(TxtCod_Pago.Text) > 0 Then
            If Val(TxtTC.Text) > 0 Then
                If CboMon.SelectedIndex > -1 Then
                    If CboSerie_Oq.SelectedIndex > -1 Then
                        If Len(txtCod_Prove.Text) > 0 Then
                            If Dgv01.RowCount > 0 Then
                                ValidarDatos = True
                            Else
                                ValidarDatos = False
                                MsgBox("Falta ingresar los artículos para la Orden de compra", MsgBoxStyle.Critical)
                            End If
                        Else
                            ValidarDatos = False
                            MsgBox("No ha seleccionado el proveedor...", MsgBoxStyle.Critical)
                            TxtProve.Focus()
                        End If
                    Else
                        ValidarDatos = False
                        MsgBox("Falta el tipo de Orden...", MsgBoxStyle.Critical)
                    End If
                Else
                    ValidarDatos = False
                    MsgBox("Falta seleccionar el tipo de moneda...", MsgBoxStyle.Critical, Compañia)
                    CboMon.Focus()
                End If
            Else
                ValidarDatos = False
                MsgBox("Falta ingresar el tipo de cambio para el dia: " & DtpFec_Emi.Text, MsgBoxStyle.Critical, Compañia)
            End If
        Else
            ValidarDatos = False
            MsgBox("Falta Seleccionar la forma de Pago...", vbCritical, Compañia)
        End If
    End Function
    Private Function ValidarCodigoArticulo() As Boolean
        With Dgv01
            If TxtSerie.Text = "001" Then
                If .RowCount > 0 Then
                    Dim x1 As Integer = 0
                    For i = 0 To .RowCount - 1
                        If Val(.Rows(i).Cells("Codigo").Value) > 0 Then
                            x1 = x1 + 1
                        Else
                            i = .RowCount
                            ValidarCodigoArticulo = False
                            MsgBox("1. Existe un Item que no ha sido creado como Artículo, debera crearlo en el maestro de artículos...", vbCritical, Compañia)
                        End If
                    Next
                    If x1 > 0 Then ValidarCodigoArticulo = True
                Else
                    ValidarCodigoArticulo = True
                End If
            Else
                ValidarCodigoArticulo = True
            End If
        End With
    End Function
    'Grabamos registro de la orden de compra... 
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Call Mostrar_TpoCambio()
        'validamos si el igv ingresado es valido
        If ValidarIGV(Val(TxtCant_Igv.Text)) = True Then
            If ValidarCodigoArticulo() = True Then
                If ValidarCierre(DtpFec_Emi.Text) = True Then
                    If ValidarDatos() = True Then
                        Dim f As String = MsgBox("¿Desea grabar la Orden de Compra?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)
                        If f = vbYes Then
                            Call Grabar_OC("ADD")
                            With Dgv01
                                For i = 0 To .RowCount - 1
                                    If Val(.Rows(i).Cells("Anula").Value) = 1 Then
                                        Call Grabar_OCDet(i, "DEL")
                                    Else
                                        Call Grabar_OCDet(i, "ADD")
                                    End If
                                Next
                            End With
                            Call Cancelar_Detalles() : BtnGrabar.Enabled = False : BtnGenerar.Enabled = True
                            FrmReportes.Impresion_OC(" and D.c_anula_reg=0 and D.c_nro_Serie='" & TxtSerie.Text & "' and D.c_nro_oc='" & TxtOrden.Text & "' order by D.c_nro_correl",
                                       TxtSerie.Text, TxtOrden.Text)
                            Call BtnMos_Click(Nothing, Nothing)
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub Grabar_OC(ByVal cOpcion As String)
        With c_Ent_OC
            .c_nro_serie = TxtSerie.Text : .c_nro_oc = TxtOrden.Text
            'Definimos si O.S. es por servicio de Teñido
            Dim fila As Integer
            With Dgv01
                If .RowCount > 0 Then fila = .CurrentCellAddress.Y
            End With
            'vlaidamos si es por orden de servicio de transformacion teñido y tejeduria de telas....
            If CboSerie_Oq.Text = "001" Then
                .c_tpo_oc = 0 'Orden de compra
            Else
                .c_tpo_oc = 1 'Orden Servicio  
            End If
            'Validamos el codigo opcional
            .c_serie_oq = CboSerie_Oq.Text
            .c_nro_oq = TxtNro_Oq.Text
            .c_codi_prove = txtCod_Prove.Text
            .c_codi_mon = CboMon.SelectedValue
            .c_codi_pago = TxtCod_Pago.Text
            .c_codi_alm = ""
            .c_fecha_emi = DtpFec_Emi.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .c_obs = TxtObs.Text
            .c_tpo_cambio = Val(TxtTC.Text)
            .c_cant_igv = Val(TxtCant_Igv.Text)
            .c_imp_inaf = Val(TxtTot_Inaf.Text)
            .c_imp_igv = Val(TxtTot_Igv.Text)
            .c_imp_afecto = Val(TxtTot_Afecto.Text)
            .c_imp_total = Val(TxtTotal.Text)
            .copcion = cOpcion
            If Val(TxtOrden.Text) = 0 Then
                TxtOrden.Text = c_Neg_OC.set_OC_Save(c_Ent_OC, FrmMenu.TxtCod_Emp.Text)
                BtnGenerar.Enabled = True
            Else
                c_Neg_OC.set_OC_Save(c_Ent_OC, FrmMenu.TxtCod_Emp.Text)
                BtnGenerar.Enabled = False
            End If
        End With
    End Sub
    ' Metodo para Grabar Detalles de OC '
    Private Sub Grabar_OCDet(ByVal I As Integer, ByVal cOpcion As String)
        'GRabamos el detalle de la orden de compra
        With c_Ent_OcDet
            .c_nro_correl = IIf(Len(Dgv01.Rows(i).Cells("Item").Value) = 0, "", Dgv01.Rows(i).Cells("Item").Value)
            .c_nro_serie = TxtSerie.Text
            .c_nro_oc = TxtOrden.Text
            .c_codi_tg = Dgv01.Rows(i).Cells("Mot").Value
            .c_codi_cd = Dgv01.Rows(i).Cells("Cd").Value
            .c_codi_scd = Dgv01.Rows(i).Cells("Scd").Value
            .c_codi_articulo = Dgv01.Rows(i).Cells("Codigo").Value
            .c_nro_cant = Val(Dgv01.Rows(i).Cells("cantidad").Value)
            .c_codi_unimed = Dgv01.Rows(i).Cells("c_codi_unimed").Value
            .c_prec_unit = Val(Dgv01.Rows(i).Cells("Precio").Value)
            .c_imp_total = Val(Dgv01.Rows(i).Cells("Importe").Value)
            .c_opt_igv = Val(Dgv01.Rows(i).Cells("Afecto").Value)
            .c_obs = Dgv01.Rows(i).Cells("Obs").Value
            .copcion = cOpcion
            'VALIDAMOS SI REGISTRO ESTA ACTIVO
            If Val(Dgv01.Rows(i).Cells("Anula").Value) = 0 Then
                If Val(Dgv01.Rows(i).Cells("Item").Value) = 0 Then
                    Dgv01.Rows(i).Cells("Item").Value = c_Neg_OCDet.set_OCDet_Save(c_Ent_OcDet, FrmMenu.TxtCod_Emp.Text).ToString
                Else
                    c_Neg_OCDet.set_OCDet_Save(c_Ent_OcDet, FrmMenu.TxtCod_Emp.Text)
                End If
            Else
                c_Neg_OCDet.set_OCDet_Save(c_Ent_OcDet, FrmMenu.TxtCod_Emp.Text)
            End If
        End With

    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Tbc01.SelectedTab = Tab01
        LblTC.Visible = False
        LblIgv.Visible = False
        LblPor.Visible = False
        TxtTC.Visible = False
        TxtCant_Igv.Visible = False
        Call Cancelar_Ingreso() : Call Cancelar_Detalles()
        ChkIGV.Visible = False
    End Sub
    'Cargamos los registros...
    Private Sub BtnMos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMos.Click
        Call Cargar_GRid_OC(" and O.c_nro_Serie='" & CboSerie.Text & _
                                             "' and  P.c_nom_prov like '%" & TxtBus_Prove.Text & "%'    order by c_nro_oc")
    End Sub

    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 1 Then
            Call Mostrar_OC()
            LblIgv.Visible = True : LblTC.Visible = True
            LblPor.Visible = True : TxtTC.Visible = True
            TxtCant_Igv.Visible = True : LblPor.Visible = True
            CboSerie_Oq.Enabled = False : TxtNro_Oq.Enabled = False : BtnConFPago.Enabled = False : BtnGrabar.Enabled = False
            BtnCon1.Enabled = False : BtnIng1.Enabled = False : Pan09.Enabled = False : BtnAceptar.Enabled = False
            ChkIGV.Visible = True
        Else
            LblIgv.Visible = False : LblTC.Visible = False
            LblPor.Visible = False : TxtTC.Visible = False
            TxtCant_Igv.Visible = False
            ChkIGV.Visible = False
        End If

    End Sub
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If ValidarCierre(.Rows(fila).Cells("Fecha Emision").Value) = True Then
                        If Val(.Rows(fila).Cells("c_anula_reg").Value) = 1 Then
                            MsgBox("Orden de Compra se encuentra anulada...", MsgBoxStyle.Critical, Compañia)
                        Else
                            If Val(.Rows(fila).Cells("c_estado_oc").Value.ToString) <= 2 Then
                                Tbc01.SelectedTab = Tab02
                                Call Mostrar_OC() : TxtProve.Enabled = False : TxtFPago.Enabled = False : BtnCon1.Enabled = True
                                BtnEdit.Enabled = True : BtnAceptar.Enabled = True : CboSerie_Oq.Enabled = False : DtpFec_Emi.Enabled = True
                                TxtObs.Enabled = True : Pan09.Enabled = True : BtnGrabar.Enabled = True : CboMon.Enabled = True
                                BtnCon1.Focus() : BtnGenerar.Enabled = False : BtnGenerar.Enabled = True
                            Else
                                MsgBox(" Orden de Compra se encuentra Cerrada, no podra realizar ninguna modificación...  ", vbCritical, Compañia)
                            End If
                        End If
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub Mostrar_OC()
        With Dgv02
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    With c_Neg_OC.get_OC_Datos(" and O.c_nro_serie='" & CboSerie.Text & "' and O.c_nro_oc='" & .Rows(fila).Cells("Compra").Value & "'", FrmMenu.TxtCod_Emp.Text, "DAT")
                        If .Rows.Count > 0 Then
                            TxtNro_Oq.Text = .Rows(0)("c_nro_oq").ToString
                            txtCod_Prove.Text = .Rows(0)("c_codi_prov").ToString
                            TxtProve.Text = .Rows(0)("c_desc_prov").ToString
                            TxtDir.Text = .Rows(0)("c_direc_prov").ToString
                            TxtRuc.Text = .Rows(0)("c_ruc_prov").ToString
                            TxtSerie.Text = .Rows(0)("c_nro_Serie").ToString
                            TxtOrden.Text = .Rows(0)("c_nro_oc").ToString
                            TxtCod_Pago.Text = .Rows(0)("c_codi_pago").ToString
                            TxtFPago.Text = .Rows(0)("c_desc_pago").ToString
                            '--->---Buscamos la serie OQ---<---
                            'Validamos el numero de serie de la OQ
                            For i = 0 To CboSerie_Oq.Items.Count - 1
                                If CboSerie_Oq.Items(i).ToString = .Rows(0)("c_serie_oq").ToString Then
                                    CboSerie_Oq.SelectedIndex = i
                                    i = CboSerie_Oq.Items.Count
                                End If
                            Next
                            '''''''''''''''----------------------''''''''''''''
                            TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                            TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                            TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                            TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                            TxtObs.Text = .Rows(0)("c_obs").ToString
                            DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                            TxtTot_Inaf.Text = .Rows(0)("c_imp_inaf").ToString
                            TxtTot_Afecto.Text = .Rows(0)("c_imp_afecto").ToString
                            TxtTot_Igv.Text = .Rows(0)("c_imp_igv").ToString
                            TxtTotal.Text = .Rows(0)("c_imp_total").ToString
                            TxtCant_Igv.Text = .Rows(0)("c_cant_igv").ToString
                            'cargamos detalles de la O.Compra
                            If Val(.Rows(0)("c_codi_mon").ToString) = "01" Then CboMon.SelectedIndex = 0
                            If Val(.Rows(0)("c_codi_mon").ToString) = "02" Then CboMon.SelectedIndex = 1
                            Dgv01.Rows.Clear()
                            With c_Neg_OCDet.get_OCDet_Datos("  and D.c_nro_serie='" & TxtSerie.Text & "' and D.c_nro_oc='" & TxtOrden.Text & "' ORDER BY C_NRO_CORREL", FrmMenu.TxtCod_Emp.Text, "DAT")
                                If .Rows.Count > 0 Then
                                    For i = 0 To .Rows.Count - 1
                                        Dgv01.Rows.Add()
                                        Dgv01.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), Forma_1_4)
                                        Dgv01.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                                        Dgv01.Rows(i).Cells("Mot").Value = .Rows(i)("c_codi_tg").ToString
                                        Dgv01.Rows(i).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString
                                        Dgv01.Rows(i).Cells("Scd").Value = .Rows(i)("c_codi_scd").ToString
                                        Dgv01.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                                        Dgv01.Rows(i).Cells("Descripcion").Value = .Rows(i)("c_desc_scd").ToString
                                        Dgv01.Rows(i).Cells("Precio").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_6)
                                        Dgv01.Rows(i).Cells("Importe").Value = Format(Val(.Rows(i)("c_imp_total").ToString), Forma_1_2)
                                        Dgv01.Rows(i).Cells("Afecto").Value = .Rows(i)("c_opt_igv").ToString
                                        Dgv01.Rows(i).Cells("Anula").Value = Val(.Rows(i)("c_anula_reg").ToString)
                                        Dgv01.Rows(i).Cells("c_codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                                        Dgv01.Rows(i).Cells("Item").Value = .Rows(i)("c_nro_correl").ToString
                                        Dgv01.Rows(i).Cells("Obs").Value = .Rows(i)("c_obs").ToString
                                        '--> Validamos si registro se encuentra anulado <--'
                                        If Val(Dgv01.Rows(i).Cells("Anula").Value) = 1 Then Dgv01.Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                                    Next
                                End If
                            End With
                            BtnGrabar.Enabled = False : LblTC.Visible = True : LblIgv.Visible = True
                            LblPor.Visible = True : TxtTC.Visible = True : TxtCant_Igv.Visible = True
                            TxtTC.Text = Format(Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_3)
                            If .Rows(0)("c_anula_reg").ToString = 0 Then
                                If Val(.Rows(0)("c_estado_oc").ToString) = 0 Then
                                    BtnEstado.BackColor = Color.Maroon
                                    BtnEstado.Text = "PENDIENTE"
                                Else
                                    If .Rows(0)("c_estado_oc").ToString = 1 Then
                                        BtnEstado.BackColor = Color.Blue
                                        BtnEstado.Text = "INGRESADO"
                                    Else 'COMPROBANTE INGRESADO...
                                        BtnEstado.BackColor = Color.Blue
                                        BtnEstado.Text = "CERRADO"
                                    End If
                                End If
                            Else
                                BtnEstado.BackColor = Color.Red
                                BtnEstado.Text = "ANULADO"
                            End If
                        End If
                    End With
                End If
            End If
        End With
    End Sub
    'Mostramos registro al presionar la tecla enter...
    Private Sub TxtBus_OQ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            With c_Neg_OQ.get_OQ_Datos(" and c_nro_serie='" & CboSerie_Oq.Text & "' and c_nro_oq='" & TxtNro_Oq.Text & "'", FrmMenu.TxtCod_Emp.Text, "DAT")
                If .Rows.Count > 0 Then
                    If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                        If Val(.Rows(0)("c_estado_oq").ToString) = 0 Then
                            TxtNro_Oq.Text = .Rows(0)("c_nro_oq").ToString
                            TxtSerie.Text = CboSerie_Oq.Text
                            Dgv01.Rows.Clear()
                            With c_Neg_OQDet.get_OQDet_Datos(" and c_nro_serie='" & CboSerie_Oq.Text & "' and c_nro_oq='" & TxtNro_Oq.Text & "' AND D.c_anula_reg=0", FrmMenu.TxtCod_Emp.Text, "DAT")
                                If .Rows.Count > 0 Then
                                    For i = 0 To .Rows.Count - 1
                                        Dgv01.Rows.Add()
                                        Dgv01.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_cant_oq").ToString), Forma_1_2)
                                        Dgv01.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                                        Dgv01.Rows(i).Cells("Mot").Value = .Rows(i)("c_codi_tg").ToString
                                        Dgv01.Rows(i).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString
                                        Dgv01.Rows(i).Cells("Art").Value = .Rows(i)("c_codi_scd").ToString
                                        Dgv01.Rows(i).Cells("Descripcion").Value = .Rows(i)("c_desc_scd").ToString
                                        Dgv01.Rows(i).Cells("Codi_Um").Value = .Rows(i)("c_codi_unimed").ToString
                                        Dgv01.Rows(i).Cells("Obs").Value = .Rows(i)("c_obs").ToString
                                    Next
                                End If
                            End With
                            TxtProve.Focus()
                            x = 1
                        Else 'Validamos si actualizamos los requerimientos...
                            If Val(TxtOrden.Text) > 0 Then
                                Call Actualizar_OQRequerimientos()
                            Else
                                MsgBox("1. La orden de requerimiento ya fue ingresda...", MsgBoxStyle.Critical)
                            End If
                        End If
                    Else
                        MsgBox("2. Orden de Requerimiento se encuentra Anulada", MsgBoxStyle.Critical)
                    End If
                Else
                    MsgBox("3. La orden ingresada no existe...", MsgBoxStyle.Critical)
                End If
            End With
        End If
    End Sub
    Private Sub Actualizar_OQRequerimientos()
        TxtNro_Oq.Text = Strings.Right(Val(TxtNro_Oq.Text) + 10000000, 7)
        With c_Neg_OQ.get_OQ_Datos(" and c_nro_serie='" & CboSerie_Oq.Text & "' and c_nro_oq='" & TxtNro_Oq.Text & "'", FrmMenu.TxtCod_Emp.Text, "DAT")
            If .Rows.Count > 0 Then
                TxtNro_Oq.Text = .Rows(0)("c_nro_oq").ToString
                TxtSerie.Text = CboSerie_Oq.Text
                'Validamos si el tipo de Requerimiento es por servicio o Compra 001=Compra 002=Servicio
                With c_Neg_OQDet.get_OQDet_Datos(" and c_nro_serie='" & CboSerie_Oq.Text & "' and c_nro_oq='" & TxtNro_Oq.Text & "' AND D.c_anula_reg=0", FrmMenu.TxtCod_Emp.Text, "DAT")
                    If .Rows.Count > 0 Then
                        Dim Fila As Integer = 0
                        For i = 0 To .Rows.Count - 1
                            For u = 0 To Dgv01.RowCount - 1
                                If Dgv01.Rows(u).Cells("Mot").Value = .Rows(i)("c_codi_tg").ToString And Dgv01.Rows(u).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString And _
                                    Dgv01.Rows(u).Cells("Art").Value = .Rows(i)("c_codi_scd").ToString And Dgv01.Rows(u).Cells("CodColor").Value = .Rows(i)("c_codi_color").ToString Then
                                    u = Dgv01.RowCount : x = 1
                                Else
                                    If u = Dgv01.RowCount - 1 Then
                                        x = 2
                                    End If
                                End If
                            Next 'Si existe solo se modificara las cantidades
                            If x = 1 Then
                                Dgv01.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_cant_oq").ToString), Forma_1_2)
                                Dgv01.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                                Dgv01.Rows(i).Cells("Obs").Value = .Rows(i)("c_obs").ToString
                                Dgv01.Rows(i).Cells("Importe").Value = Format(Val(.Rows(i)("c_cant_oq").ToString) * Val(Dgv01.Rows(i).Cells("Precio").Value), Forma_1_2)
                            Else
                                Dgv01.Rows.Add() : Fila = Dgv01.RowCount - 1
                                Dgv01.Rows(Fila).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_cant_oq").ToString), Forma_1_2)
                                Dgv01.Rows(Fila).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                                Dgv01.Rows(Fila).Cells("Mot").Value = .Rows(i)("c_codi_tg").ToString
                                Dgv01.Rows(Fila).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString
                                Dgv01.Rows(Fila).Cells("Art").Value = .Rows(i)("c_codi_scd").ToString
                                Dgv01.Rows(Fila).Cells("Descripcion").Value = .Rows(i)("c_desc_scdcompra").ToString & " " & .Rows(i)("c_desc_color").ToString
                                Dgv01.Rows(Fila).Cells("CodColor").Value = .Rows(i)("c_codi_color").ToString
                                Dgv01.Rows(Fila).Cells("Codi_Um").Value = .Rows(i)("c_codi_unimed").ToString
                                Dgv01.Rows(Fila).Cells("Obs").Value = .Rows(i)("c_obs").ToString
                                Dgv01.Rows(Fila).Cells("Estado").Value = 0
                            End If
                        Next
                    End If
                End With
                TxtProve.Focus() : x = 1 : Call Calcular_Totales()
            Else
                MsgBox("3. La orden ingresada no existe...", MsgBoxStyle.Critical)
            End If
        End With
    End Sub
    Private Sub TxtBus_OQ_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        With Dgv01
            If .RowCount > 0 Then
                Call Limpiar_Texto(Pan08)
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If .Rows.Count > 0 Then
                        Call Nuevo_Detalles() : Call Mostrar_Grid(fila) : Agregar = 1
                        TxtP_Unit.Focus() : BtnAceptar.Enabled = True
                    Else
                        MsgBox("no existe registros...")
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub Mostrar_Grid(ByVal Fila As Integer)
        With Dgv01
            TxtCod_Articulo.Text = .Rows(Fila).Cells("Codigo").Value
            TxtCant.Text = Format(Val(.Rows(Fila).Cells("Cantidad").Value), Forma_1_2)
            CboUniMed.SelectedValue = .Rows(Fila).Cells("c_codi_unimed").Value
            TxtCod_Tg.Text = .Rows(Fila).Cells("Mot").Value
            TxtCod_Cd.Text = .Rows(Fila).Cells("Cd").Value
            TxtCod_Scd.Text = .Rows(Fila).Cells("Scd").Value
            TxtScd.Text = Dgv01.Rows(Fila).Cells("descripcion").Value
            TxtCod_UniMed.Text = .Rows(Fila).Cells("c_codi_unimed").Value
            TxtP_Unit.Text = Format(Val(Dgv01.Rows(Fila).Cells("Precio").Value), Forma_1_6)
            TxTImpor.Text = Format(Val(Dgv01.Rows(Fila).Cells("Importe").Value), Forma_1_2)
            TxtItem.Text = .Rows(Fila).Cells("Item").Value
            'Validamos si articulo esta afecto 
            If Val(Dgv01.Rows(Fila).Cells("Afecto").Value) = 1 Then
                ChkAfecto.Checked = True
            Else 'Validamos si es por primera vez
                ChkAfecto.Checked = False
            End If
            Call Mostrar_Caidas()
        End With
    End Sub
    Private Sub Mostrar_Caidas()
        With c_Neg_MnScaidas.get_sCaidas_Datos(" and S.c_codi_tg='" & TxtCod_Tg.Text & "' and S.c_codi_cd='" & TxtCod_Cd.Text & "' and S.c_codi_scd='" & TxtCod_Scd.Text & "'", "DAT")
            If .Rows.Count > 0 Then
                TxtTg.Text = .Rows(0)("c_desc_tg").ToString
                TxtCd.Text = .Rows(0)("c_desc_cd").ToString
                TxtCod_Tg.Text = .Rows(0)("c_codi_tg").ToString
                TxtCod_Cd.Text = .Rows(0)("c_codi_cd").ToString
                TxtCod_Scd.Text = .Rows(0)("c_codi_scd").ToString
            End If
        End With
    End Sub
    Private Sub Cancelar_Detalles()
        With Dgv01
            .Height = 201 : .Width = 689
            .Location = New Point(3, 24)
        End With
        Pan08.Enabled = False : Pan11.Enabled = False : Pan09.Enabled = True
    End Sub
    Private Sub Nuevo_Detalles()
        Call Limpiar_Texto(Pan08)
        With Dgv01
            .Height = 129
            .Width = 689
            .Location = New Point(3, 96)
            TxtP_Unit.Enabled = True : Pan08.Enabled = True : Pan09.Enabled = False : Pan11.Enabled = True
        End With
    End Sub

    Private Sub BtnCancel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel2.Click
        Call Cancelar_Detalles()
    End Sub
    ' Aceptamos Registro '
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If CboUniMed.SelectedIndex > -1 Then
            If Val(TxtP_Unit.Text) > 0 Then
                With Dgv01
                    If Agregar = 1 Then
                        If .RowCount > 0 Then
                            Dim fila As Integer = .CurrentCellAddress.Y
                            If fila > -1 Then
                                Call Agregar_Registro(fila) : Call Cancelar_Detalles()
                                'On Error Resume Next
                                .ClearSelection()
                                If fila + 2 > .RowCount Then
                                    Focos = 2
                                    BtnAdd.Focus()
                                    .CurrentCell = .Rows(fila).Cells(0)
                                Else
                                    Focos = 1
                                    BtnEdit.Focus()
                                    .CurrentCell = .Rows(Val(Dgv01.CurrentRow.Index + 1)).Cells(0)
                                End If
                            End If
                        End If
                    Else
                        Dgv01.Rows.Add()
                        Call Agregar_Registro(Dgv01.RowCount - 1) : Call Cancelar_Detalles()
                        .ClearSelection() : Focos = 1 : BtnAdd.Focus()
                    End If
                End With
            Else
                MsgBox("1. Falta ingresar el precio unitario", MsgBoxStyle.Critical)
            End If
        Else
            MsgBox("2. Falta seleccionar la unidad de medida...", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub CboSerie_Oq_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TxtSerie.Text = CboSerie_Oq.Text
        'Validamos si el tipo de Requerimiento es por servicio o Compra 001=Compra 002=Servicio
        If CboSerie_Oq.Text = "001" Then
            Me.Text = "Orden de Compra [NORMAL]"
        Else
            Me.Text = "Orden de Compra [SERVICIO]"
        End If
    End Sub

    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Me.Close()
    End Sub

    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        With FrmConProve
            .Show() : .MdiParent = FrmMenu
            .TxtVar.Text = 2 : .Cargar_Grid(" and c_anula_reg=0 and c_desc_prov like '%" & TxtProve.Text & "%' order by c_desc_prov")
        End With
    End Sub


    Private Sub CboSerie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CboSerie_Oq.Items.Count > 0 Then If BtnMos.Enabled = True Then Call BtnMos_Click(Nothing, Nothing)
        'If CboSerie.SelectedIndex = 0 Then Me.Text = "Orden de c [SERVICIOS]"
        'If CboSerie.SelectedIndex = 1 Then Me.Text = "Orden de Requerimiento [COMPRAS]"

    End Sub
    'Enviamos por Email...
    Private Sub BtnEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEmail.Click
        If Dgv02.RowCount > 0 Then
            Dim fila As Integer = Dgv02.CurrentCellAddress.Y
            If fila > -1 Then 'obtenemos el codigo del cliente por medio de la orden de compra...
                MsgBox(" Módulo pendiente por Desarrollar...", vbExclamation, Compañia)
                'FrmReportes.Impresion_Directa_Pruebas()
            End If
        End If
    End Sub
    'Mostramos tipo de cambio..
    Private Sub Mostrar_TpoCambio()
        With c_Neg_TpoCambio.get_TpoCambio_Datos(" and T.c_fecha_cbo='" & DtpFec_Emi.Text & "'", "DAT")
            If .Rows.Count > 0 Then
                TxtTC.Text = Format(Val(.Rows(0)("c_venta_sunat").ToString), Forma_1_3)
            End If
        End With
    End Sub

    Private Sub DtpFec_Emi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Emi.ValueChanged
        Call Mostrar_TpoCambio()
    End Sub
    'Eliminamos registro...
    Private Sub BtnEli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEli.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    If ValidarCierre(.Rows(fila).Cells("Fecha Emision").Value) = True Then
                        If Val(.Rows(fila).Cells("c_anula_reg").Value) = 1 Then
                            MsgBox("Orden de Compra se encuentra anulada...", MsgBoxStyle.Critical, Compañia)
                        Else
                            If Val(.Rows(fila).Cells("c_estado_oc").Value.ToString) = 0 Then
                                Dim F As String = MsgBox("¿Confirma la eliminación del Registro?", vbYesNo + MsgBoxStyle.Question, Compañia)
                                If F = vbYes Then
                                    TxtSerie.Text = CboSerie.Text
                                    TxtOrden.Text = .Rows(fila).Cells("Compra").Value
                                    Call Grabar_OC("DEL")
                                    .Rows(fila).DefaultCellStyle.BackColor = Color.Gainsboro
                                    .Rows(fila).Cells("c_anula_reg").Value = 1
                                    MsgBox(" Registro se elimino Correctamente...", vbCritical, Compañia)
                                End If
                            Else
                                MsgBox("Orden de compra ya fue ingresada, no podra realizar ninguna modificación...", MsgBoxStyle.Exclamation, Compañia)
                            End If
                        End If
                    End If
                End If
            End If
        End With
    End Sub
    'Editamos registro...
    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        If BtnEdit.Enabled = True Then Call BtnEdit_Click(Nothing, Nothing)
    End Sub
    Private Sub Dgv02_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv02.CellContentClick
        If e.RowIndex = -1 Then
            With Dgv02
                For i = 0 To .RowCount - 1
                    If .Rows(i).Cells("c_anula_reg").Value = 1 Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                    End If
                Next
            End With
        End If
    End Sub
    'Inicio
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Movilizar_Registros(Dgv02, TxtReg, 1)
    End Sub
    'Atras
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        Call Movilizar_Registros(Dgv02, TxtReg, 2)
    End Sub
    'Avanza
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        Call Movilizar_Registros(Dgv02, TxtReg, 3)
    End Sub
    'Final
    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Movilizar_Registros(Dgv02, TxtReg, 4)
    End Sub

    Private Sub Dgv02_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv02.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv02)
    End Sub
    'Mostramos datos al dar doble click
    Private Sub Dgv02_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv02.DoubleClick
        With Dgv02
            If .RowCount > 0 Then
                Tbc01.SelectedTab = Tab02 : Call Tbc01_Click(Nothing, Nothing)
            End If
        End With
    End Sub

    Private Sub Dgv02_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv02.SelectionChanged
        With Dgv02 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub
    'ingresamos nuevo cliente...
    Private Sub BtnIng1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIng1.Click
        FrmMnProveIng.Show()
        FrmMnProveIng.MdiParent = FrmMenu : FrmMnProveIng.TxtVar1.Text = 1
        FrmMnProveIng.Show()
        If Val(txtCod_Prove.Text) > 0 And Len(TxtProve.Text) > 0 Then FrmMnProveIng.Mostrar_Proveedor(txtCod_Prove.Text)
    End Sub
    'Buscamos por orden de compra
    Private Sub TxtBus_OC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_OC.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_OC.Text) > 0 Then
                TxtBus_OC.Text = Strings.Right(Val(TxtBus_OC.Text) + 10000000, 7)
                Call Cargar_Grid_2(" and O.c_nro_Serie='" & CboSerie.Text & "' and O.c_nro_oc ='" & TxtBus_OC.Text & "'  order by c_nro_oc")
            End If
        End If
    End Sub

    Private Sub TxtBus_OC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_OC.TextChanged

    End Sub

    Private Sub TxtNro_Oq_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNro_Oq.KeyDown
        If Val(TxtNro_Oq.Text) > 0 Then
            If e.KeyCode = Keys.Enter Then
                TxtNro_Oq.Text = Strings.Right(Val(TxtNro_Oq.Text) + 10000000, 7)
                Dgv01.Rows.Clear()
                With c_Neg_OQ.get_OQ_Datos(" and O.c_nro_serie='" & CboSerie_Oq.Text & "' and O.c_nro_oq='" & TxtNro_Oq.Text & "'", FrmMenu.TxtCod_Emp.Text, "DAT")
                    If .Rows.Count > 0 Then
                        If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                            If Val(.Rows(0)("c_estado_oq").ToString) = 0 Then
                                With c_Neg_OQDet.get_OQDet_Datos(" AND D.c_nro_serie='" & CboSerie_Oq.Text & "' and D.c_nro_oq='" & TxtNro_Oq.Text & "' and D.c_anula_reg=0 order by c_nro_correl", FrmMenu.TxtCod_Emp.Text, "DAT")
                                    If .Rows.Count > 0 Then
                                        For I = 0 To .Rows.Count - 1
                                            Dgv01.Rows.Add()
                                            Dgv01.Rows(I).Cells("Cantidad").Value = Format(Val(.Rows(I)("c_Cant_oq").ToString), Forma_1_2)
                                            Dgv01.Rows(I).Cells("Unid").Value = .Rows(I)("c_desc_unimed").ToString
                                            Dgv01.Rows(I).Cells("Mot").Value = .Rows(I)("c_codi_tg").ToString
                                            Dgv01.Rows(I).Cells("Cd").Value = .Rows(I)("c_codi_cd").ToString
                                            Dgv01.Rows(I).Cells("Scd").Value = .Rows(I)("c_codi_scd").ToString
                                            Dgv01.Rows(I).Cells("Codigo").Value = .Rows(I)("c_codi_articulo").ToString
                                            Dgv01.Rows(I).Cells("Descripcion").Value = .Rows(I)("c_desc_scd").ToString
                                            Dgv01.Rows(I).Cells("Precio").Value = "0.00"
                                            Dgv01.Rows(I).Cells("Importe").Value = "0.00"
                                            Dgv01.Rows(I).Cells("Obs").Value = ""
                                            Dgv01.Rows(I).Cells("Anula").Value = 0
                                            Dgv01.Rows(I).Cells("c_codi_oq").Value = .Rows(I)("c_nro_correl").ToString
                                            Dgv01.Rows(I).Cells("c_codi_unimed").Value = .Rows(I)("c_codi_unimed").ToString
                                            Dgv01.Rows(I).Cells("Item").Value = ""
                                            Dgv01.Rows(I).Cells("Afecto").Value = 1
                                            ' Hallamos el precio de compra '
                                            Call Hallar_Precio(I, .Rows(I)("c_codi_articulo").ToString)
                                        Next
                                    Else
                                        MsgBox("No existen registros para mostrar...", vbCritical, Compañia)
                                    End If
                                End With
                            Else
                                MsgBox(" Requerimiento ya fue ingresado...", vbCritical, Compañia)
                            End If
                        Else
                            MsgBox(" Requerimiento se encuentra anulado...", vbCritical, Compañia)
                        End If
                    Else
                        MsgBox(" Requerimiento no Existe...", vbCritical, Compañia)
                    End If
                End With
            End If
        End If
    End Sub
    ' Metodo para hallar el precio de compra '
    Private Sub Hallar_Precio(ByVal Fila As Integer, ByVal Codigo As String)
        With c_Neg_MnProveDet.get_ProveDet_Datos(" And D.c_codi_prov='" & txtCod_Prove.Text & "' And A.c_codi_articulo='" & Codigo & _
                                                                                     "' And D.c_anula_reg=0 ", "DAT")
            If .Rows.Count > 0 Then ' Validamos si las monedas distintas '
                If .Rows(0)("c_codi_mon").ToString = CboMon.SelectedValue Then
                    Dgv01.Rows(Fila).Cells("Precio").Value = Format(Val(.Rows(0)("c_prec_prv").ToString), Forma_1_2)
                Else ' Validamos la moneda en soles '
                    If .Rows(0)("c_codi_mon").ToString = "01" Then
                        Dgv01.Rows(Fila).Cells("Precio").Value = Format(Val(.Rows(0)("c_prec_prv").ToString) / Val(TxtTC.Text), Forma_1_2)
                    End If
                    ' Validamos la moneda dolares '
                    If .Rows(0)("c_codi_mon").ToString = "02" Then
                        Dgv01.Rows(Fila).Cells("Precio").Value = Format(Val(.Rows(0)("c_prec_prv").ToString) * Val(TxtTC.Text), Forma_1_2)
                    End If
                End If
                Dgv01.Rows(Fila).Cells("Importe").Value = Format(Val(Dgv01.Rows(Fila).Cells("Precio").Value) * Val(Dgv01.Rows(Fila).Cells("Cantidad").Value), Forma_1_2)
            End If
            Call Calcular_Totales()
        End With
    End Sub
    Private Sub Cancelar_Ingreso()
        BtnGrabar.Enabled = False : Pan09.Enabled = False : BtnAceptar.Enabled = False
        CboSerie_Oq.Enabled = False : BtnEdit.Enabled = True : Pan11.Enabled = False
        Call Desactivar(Pan01) : Call Desactivar(Pan03) : BtnGenerar.Enabled = False
        Call Desactivar(Pan09) : TxtObs.Enabled = True : CboMon.Enabled = False
        BtnCon1.Enabled = False : DtpFec_Emi.Enabled = False : TxtObs.Enabled = False
    End Sub

    Private Sub TxtNro_Oq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNro_Oq.TextChanged

    End Sub
    ' Agregamos datos al presionar la tecla enter '
    Private Sub ChkAfecto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ChkAfecto.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call BtnAceptar_Click(Nothing, Nothing) : Focos = 3 : BtnGrabar.Focus()
        End If
    End Sub

    Private Sub BtnEdit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnEdit.LostFocus
        If Focos = 1 Then
            Focos = 0 : BtnEdit.Focus()
        End If
    End Sub
    ' Evitamos el perder el enfoque '
    Private Sub BtnGrabar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGrabar.LostFocus
        If Focos = 2 Then
            Focos = 0 : BtnGrabar.Focus()
        End If
        ' Validamos la perdida del enfoque '
        If Focos = 3 Then
            Focos = 0 : BtnGrabar.Focus()
        End If
    End Sub

    Private Sub CboSerie_Oq_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSerie_Oq.SelectedIndexChanged
        TxtSerie.Text = CboSerie_Oq.Text
        If CboSerie_Oq.Text = "001" Then
            Rdb01.Checked = True
        Else
            Rdb02.Checked = True
        End If
    End Sub

    Private Sub BtnConFPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConFPago.Click
        With FrmConTpoPago
            .Show() : .MdiParent = FrmMenu
            .Cargar_Grid(" and c_anula_reg=0 order by c_desc_pago")
            .TxtVar.Text = 2
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                FrmReportes.Impresion_OC(" and D.c_anula_reg=0 and D.c_nro_Serie='" & CboSerie.Text & "' and D.c_nro_oc='" & .Rows(fila).Cells("compra").Value & "' order by D.c_nro_correl", _
                                          CboSerie.Text, .Rows(fila).Cells("compra").Value)
            End If
        End With
    End Sub

    Private Sub CboMon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMon.SelectedIndexChanged
        With Dgv01
            For i = 0 To .RowCount - 1
                ' Hallamos el precio de compra '
                Call Hallar_Precio(i, .Rows(i).Cells("Codigo").Value)
            Next
        End With
    End Sub
   
    Private Sub BtnCon2_Click(sender As System.Object, e As System.EventArgs) Handles BtnCon2.Click
        With FrmConTg
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 8
            .Cargar_Grid(" and c_anula_reg=0  order by c_desc_tg")
        End With
    End Sub

    Private Sub BtnCon3_Click_1(sender As System.Object, e As System.EventArgs) Handles BtnCon3.Click
        With FrmConCd
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 8 : .TxtCod_Tg.Text = TxtCod_Tg.Text
            .Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' order by c_desc_cd")
        End With
    End Sub

    Private Sub BtnCon4_Click(sender As System.Object, e As System.EventArgs) Handles BtnCon4.Click
        With FrmConScd2
            .Show() : .MdiParent = FrmMenu
            .TxtVar.Text = 1 : .TxtCod_Tg.Text = TxtCod_Tg.Text : .TxtCod_Cd.Text = TxtCod_Cd.Text
            .Cargar_Grid(" and S.c_anula_reg=0 and S.c_codi_tg like '%" & TxtCod_Tg.Text & "' and S.c_codi_cd like '%" & TxtCod_Cd.Text & "%' order by c_desc_scd")
            .TxtFocus.Text = 1 : .TxtBus_Art.Focus()
        End With
    End Sub

    Private Sub BtnAdd_Click(sender As System.Object, e As System.EventArgs) Handles BtnAdd.Click
        Call Nuevo_Detalles() : TxtCant.Focus() : Agregar = 0 : BtnAceptar.Enabled = True
    End Sub
    ' Eliminamos registro '
    Private Sub BtnDel_Click(sender As System.Object, e As System.EventArgs) Handles BtnDel.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("Anula").Value) = 0 Then
                        Dim F As String = MsgBox("¿Desea Eliminar el Registro?", vbQuestion + vbYesNo, Compañia)
                        If F = vbYes Then
                            If Val(.Rows(Fila).Cells("Item").Value) > 0 Then
                                .Rows(Fila).Cells("Anula").Value = 1
                                .Rows(Fila).DefaultCellStyle.BackColor = Color.Gainsboro
                            Else
                                .Rows.RemoveAt(Fila)
                            End If
                            Call Calcular_Totales()
                        End If
                    Else
                        MsgBox("Registro se encuentra anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        If TxtSerie.Text = "002" Then
            If UCase(BtnEstado.Text) = "PENDIENTE" Then
                If Val(TxtOrden.Text) > 0 Then
                    FrmIngCompDirecto.MdiParent = FrmMenu : FrmIngCompDirecto.Show() : FrmIngCompDirecto.CboDoc.SelectedValue = "01"
                    FrmIngCompDirecto.TxtSerie.Focus()
                Else
                    MsgBox("1. La orden debe estar grabada antes de ingresar la factura...", vbCritical, Compañia)
                End If
            Else
                MsgBox("Solo puede ingresar cuando la factura se encuentre pendiente...", vbCritical, Compañia)
            End If
        Else
            MsgBox(" Solo se puede realizar esta operacion para Servicio serie 002", vbCritical, Compañia)
        End If
    End Sub

    Private Sub TxtP_Unit_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtP_Unit.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtP_Unit.Text) > 0 Then
                If ChkIGV.Checked = True Then
                    TxtP_Unit.Text = Val(TxtP_Unit.Text) / (Val(TxtCant_Igv.Text) / 100 + 1)
                    Call Calcular()
                End If
                Call BtnCon4_Click(Nothing, Nothing)
            End If
        End If
    End Sub

    Private Sub BtnGrabar_GotFocus(sender As Object, e As EventArgs) Handles BtnGrabar.GotFocus
        If Focos = 1 Then
            Focos = 0 : BtnAdd.Focus()
        End If
    End Sub

    Private Sub BtnAdd_LostFocus(sender As Object, e As EventArgs) Handles BtnAdd.LostFocus

        If Focos = 1 Or Focos = 3 Then
            Focos = 0 : BtnAdd.Focus()
        End If
    End Sub

    Private Sub TxtCant_Igv_TextChanged(sender As Object, e As EventArgs) Handles TxtCant_Igv.TextChanged
        If TxtCant_Igv.Enabled = True Then Call Calcular_Totales()
    End Sub
End Class