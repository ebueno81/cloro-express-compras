Public Class FrmDuasCostos

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : TxtNro_Costo.Clear() : CboMon.Focus() : DtpFec_Emi.Text = Now.Date
        TxtGastos.Clear() : TxtNro_File.Clear() : TxtTot_Dua.Clear() : BtnConDua.Enabled = True
        DtpFec_Embarque.Enabled = True : DtpFec_Llegada.Enabled = True : TxtAgencia.Enabled = True
        TxtCod_Dua.Clear() : TxtDua.Clear() : TxtTot_Dua.Clear() : TxtAgencia.Clear() : DtpFec_Emi.Text = Now.Date
        DtpFec_Embarque.Text = Now.Date : DtpFec_Llegada.Text = Now.Date : TxtOtros.Clear()
    End Sub
    ' metodo para nuevo registros '
    Private Sub Nuevo_Registro()
        Pan09.Enabled = True : BtnGrabar.Enabled = True : DtpFec_Emi.Enabled = True : Pan07.Enabled = False
        BtnCerrar.Text = "&Cancelar" : BtnGrabar.Enabled = True : Pan12.Enabled = False : Pan07.Enabled = False
        DtpFec_Emi.Enabled = True : CboMon.Enabled = True : BtnConTpoDoc.Enabled = True : DtpFec_Emi.Enabled = True
        Dgv01.Rows.Clear() : Dgv02.Rows.Clear() : CboMon.SelectedIndex = -1 : TxtSerie.Clear() : TxtFactura.Clear()
        Call Limpiar_Texto(Pan08) : TxtObs.Clear() : LblTotal_Item.Text = "" : LblTotales.Text = "" : BtnEliDua.Enabled = True
        TxtCod_Prove.Clear() : TxtProve.Clear() : TxtObs.Enabled = True : LblPeso.Text = "" : BtnEstado.Text = "Pendiente"
        BtnEstado.BackColor = Color.Maroon : TxtGastos.Enabled = True : TxtNro_File.Enabled = True : TxtTot_Dua.Enabled = True
        Pan12.Enabled = False : TxtOtros.Enabled = True : LblTotInvoice_Mn.Text = "" : TxtTot_Dua_Mn.Clear()
        TxtGastos_Mn.Clear() : TxtOtros_Mn.Clear() : Txttot_Gastos_Mn.Clear() : TxtTot_Dua_Mn.Enabled = True
        TxtGastos_Mn.Enabled = True : TxtOtros_Mn.Enabled = True : Txttot_Gastos_Mn.Enabled = True
    End Sub
    ' metodo para cancelar registros '
    Private Sub Cancelar_Registro()
        Pan09.Enabled = False : BtnGrabar.Enabled = False : DtpFec_Emi.Enabled = False : Pan07.Enabled = True
        BtnCerrar.Text = "&Cerrar" : Pan12.Enabled = True : BtnConTpoDoc.Enabled = False
        DtpFec_Emi.Enabled = False : CboMon.Enabled = False : Call Limpiar_Texto(Pan08) : TxtObs.Clear()
        TxtSerie.Clear() : TxtFactura.Clear() :  LblTotal_Item.Text = "" : LblTotales.Text = ""
        TxtObs.Enabled = False : TxtGastos.Enabled = False : TxtNro_File.Enabled = False : BtnConDua.Enabled = False
        DtpFec_Embarque.Enabled = False : DtpFec_Llegada.Enabled = False : TxtAgencia.Enabled = False : TxtTot_Dua.Enabled = False
        BtnConDua.Enabled = False : TxtTot_Dua.Enabled = False : BtnEliDua.Enabled = False
        Pan12.Enabled = True : TxtOtros.Enabled = False : TxtDua.Clear() : TxtCod_Dua.Clear() : TxtTot_Dua.Clear()
        LblTotInvoice_Mn.Text = "" : TxtTot_Dua_Mn.Clear()
        TxtGastos_Mn.Clear() : TxtOtros_Mn.Clear() : Txttot_Gastos_Mn.Clear() : TxtTot_Dua_Mn.Enabled = False
        TxtGastos_Mn.Enabled = False : TxtOtros_Mn.Enabled = False : Txttot_Gastos_Mn.Enabled = False
    End Sub

    Private Sub BtnAdd_Click(sender As System.Object, e As System.EventArgs) Handles BtnAdd.Click
        If CboMon.SelectedIndex > -1 Then
            With FrmIngCompBus
                .Show() : .MdiParent = FrmMenu : .TxtVar1.Text = 4 : .TxtSerie.Focus()
            End With
        Else
            MsgBox("Falta seleccionar la moneda de costo...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs)

    End Sub
    ' METODO PARA AGREGAR FACTURAS 
    Public Sub Cargar_grid(ByVal Cadena As String)
        With c_Neg_IngComp.get_IngComp_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                Dgv01.Rows.Add()
                Dim Fila As Integer = Dgv01.RowCount - 1
                Dgv01.Rows(Fila).Cells("Documento").Value = .Rows(0)("c_serie_doc").ToString & " " & .Rows(0)("c_nro_doc").ToString
                Dgv01.Rows(Fila).Cells("Total").Value = Format(Val(.Rows(0)("c_imp_afecto").ToString) + Val(.Rows(0)("c_imp_inaf").ToString), Forma_1_2)
                Dgv01.Rows(Fila).Cells("Fecha").Value = FormatDateTime(.Rows(0)("c_fecha_emi").ToString, DateFormat.ShortDate)
                Dgv01.Rows(Fila).Cells("c_tpo_cambio").Value = Format(Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_3)
                Dgv01.Rows(Fila).Cells("c_codi_mon").Value = .Rows(0)("c_codi_mon").ToString
                Dgv01.Rows(Fila).Cells("c_codi_doc").Value = .Rows(0)("c_codi_doc").ToString
                Dgv01.Rows(Fila).Cells("c_nro_ing").Value = .Rows(0)("c_nro_ing").ToString
                Dgv01.Rows(Fila).Cells("c_nro_correl").Value = ""

                ' --> Validamos si las monedas son diferentes <-- '
                If .Rows(0)("c_codi_mon").ToString = "02" Then
                    Dgv01.Rows(Fila).Cells("Total").Value = Format((Val(.Rows(0)("c_imp_afecto").ToString) + Val(.Rows(0)("c_imp_inaf").ToString)), Forma_1_2)
                    Dgv01.Rows(Fila).Cells("Total_Mn").Value = Format((Val(.Rows(0)("c_imp_afecto").ToString) + Val(.Rows(0)("c_imp_inaf").ToString)) * Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_2)
                Else
                    Dgv01.Rows(Fila).Cells("Total").Value = Format((Val(.Rows(0)("c_imp_afecto").ToString) + Val(.Rows(0)("c_imp_inaf").ToString)) / Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_2)
                    Dgv01.Rows(Fila).Cells("Total_Mn").Value = Format((Val(.Rows(0)("c_imp_afecto").ToString) + Val(.Rows(0)("c_imp_inaf").ToString)), Forma_1_2)
                End If
                ' --> Calculamos <-- '
                Call Calcular_Todos()
            End If
        End With
    End Sub
    ' METODO PARA AGREGAR FACTURAS 
    Public Sub Cargar_grid_NC(ByVal Cadena As String)
        With c_Neg_NotaC.get_NotaC_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                Dgv01.Rows.Add()
                Dim Fila As Integer = Dgv01.RowCount - 1
                Dgv01.Rows(Fila).Cells("Documento").Value = .Rows(0)("c_serie_nc").ToString & " " & .Rows(0)("c_nro_nc").ToString
                Dgv01.Rows(Fila).Cells("Total").Value = Format(Val(.Rows(0)("c_imp_total").ToString) * -1, Forma_1_2)
                Dgv01.Rows(Fila).Cells("Fecha").Value = FormatDateTime(.Rows(0)("c_fecha_emi").ToString, DateFormat.ShortDate)
                Dgv01.Rows(Fila).Cells("c_tpo_cambio").Value = Format(Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_3)
                Dgv01.Rows(Fila).Cells("c_codi_mon").Value = .Rows(0)("c_codi_mon").ToString
                Dgv01.Rows(Fila).Cells("c_nro_ing").Value = .Rows(0)("c_ing_nc").ToString
                Dgv01.Rows(Fila).Cells("c_codi_doc").Value = "03"
                Dgv01.Rows(Fila).Cells("c_nro_correl").Value = ""
                ' --> Validamos si las monedas son diferentes <-- '
                If .Rows(0)("c_codi_mon").ToString = "02" Then
                    Dgv01.Rows(Fila).Cells("Total").Value = Format(Val(.Rows(0)("c_imp_total").ToString) * -1, Forma_1_2)
                    Dgv01.Rows(Fila).Cells("Total_Mn").Value = Format(Val(.Rows(0)("c_imp_total").ToString) * Val(.Rows(0)("c_tpo_cambio").ToString) * -1, Forma_1_2)
                Else
                    Dgv01.Rows(Fila).Cells("Total").Value = Format(Val(.Rows(0)("c_imp_total").ToString) / Val(.Rows(0)("c_tpo_cambio").ToString) * -1, Forma_1_2)
                    Dgv01.Rows(Fila).Cells("Total_Mn").Value = Format(Val(.Rows(0)("c_imp_afecto").ToString) * -1, Forma_1_2)
                End If
                ' --> Calculamos <-- '
                Call Calcular_Todos()
            End If
        End With
    End Sub
    ' metodo para calcular todos '
    Public Sub Calcular_Todos()
        Call Calcular_Gastos() : Call Calcular_Porcentajes() : Call Calcular_Costos() : Call Calcular_Totales()
    End Sub
    ' Metodo para cargar articulos '
    Public Sub Cargar_grid_Detalles(ByVal Cadena As String)
        With c_Neg_IngCompDet.get_IngCompDet_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
            Dgv02.Rows.Clear() : LblPeso.Text = "0.00"
            If .Rows.Count > 0 Then
                With c_Neg_IngComp.get_IngComp_Datos(" and c_nro_ing='" & .Rows(0)("c_nro_ing").ToString & "' ", "DAT", FrmMenu.TxtCod_Emp.Text)
                    Call Limpiar_Texto(Pan05)
                    If .Rows.Count > 0 Then
                        TxtCod_Prove.Text = .Rows(0)("c_codi_prov").ToString
                        TxtProve.Text = .Rows(0)("c_desc_prov").ToString
                        TxtMon_Doc.Text = .Rows(0)("c_codi_mon").ToString
                        LblTpoDoc.Text = .Rows(0)("c_desc_doc").ToString & " " & .Rows(0)("c_codi_doc").ToString
                        TxtSerie.Text = .Rows(0)("c_serie_doc").ToString
                        TxtFactura.Text = .Rows(0)("c_nro_doc").ToString
                        TxtTC.Text = Format(Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_3)
                        DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                        LblTotInvoice.Text = Format(Val(.Rows(0)("c_imp_total").ToString), Forma_1_2)
                        ' Cargamos el total de la factura de imporacion segun moneda original '
                        If .Rows(0)("c_codi_mon").ToString = "02" Then
                            LblTotInvoice.Text = Format(Val(.Rows(0)("c_imp_total").ToString), Forma_1_2)
                            LblTotInvoice_Mn.Text = Format(Val(.Rows(0)("c_imp_total").ToString) * Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_2)
                        Else
                            LblTotInvoice_Mn.Text = Format(Val(.Rows(0)("c_imp_total").ToString), Forma_1_2)
                            LblTotInvoice.Text = Format(Val(.Rows(0)("c_imp_total").ToString) / Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_2)
                        End If
                    End If
                End With
                For i = 0 To .Rows.Count - 1
                    Dgv02.Rows.Add()
                    Dgv02.Rows(i).Cells("c_nro_guia").Value = Strings.Left(.Rows(i)("c_nro_oc").ToString, 3) & "-" & Strings.Right(.Rows(i)("c_nro_oc").ToString, 7)
                    Dgv02.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                    Dgv02.Rows(i).Cells("c_codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                    Dgv02.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), Forma_1_2)
                    Dgv02.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                    Dgv02.Rows(i).Cells("Descripcion").Value = .Rows(i)("c_desc_scd").ToString
                    ' Validamos si las monedas son iguales '
                    If TxtMon_Doc.Text = "02" Then
                        Dgv02.Rows(i).Cells("Precio").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_6)
                        Dgv02.Rows(i).Cells("Costo").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_6)
                        Dgv02.Rows(i).Cells("c_precio_mn").Value = Format(Val(.Rows(i)("c_prec_unit").ToString) * Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_6)
                        Dgv02.Rows(i).Cells("c_costo_mn").Value = Format(Val(.Rows(i)("c_prec_unit").ToString) * Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_6)
                    Else
                        Dgv02.Rows(i).Cells("c_precio_mn").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_6)
                        Dgv02.Rows(i).Cells("c_costo_mn").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_6)
                        Dgv02.Rows(i).Cells("Precio").Value = Format(Val(.Rows(i)("c_prec_unit").ToString) / Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_6)
                        Dgv02.Rows(i).Cells("Costo").Value = Format(Val(.Rows(i)("c_prec_unit").ToString) / Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_6)
                    End If

                    Dgv02.Rows(i).Cells("Importe").Value = Format(Val(Dgv02.Rows(i).Cells("Precio").Value) * Val(.Rows(i)("c_nro_cant").ToString), Forma_1_2)
                    Dgv02.Rows(i).Cells("c_imp_mn").Value = Format(Val(Dgv02.Rows(i).Cells("c_precio_mn").Value) * Val(.Rows(i)("c_nro_cant").ToString), Forma_1_2)

                    Dgv02.Rows(i).Cells("Item").Value = ""
                    Dgv02.Rows(i).Cells("c_correl_ing").Value = .Rows(i)("c_nro_correl").ToString
                    Dgv02.Rows(i).Cells("c_correl_guia").Value = .Rows(i)("c_correl_ing").ToString
                    ' Primero obtenemos el codigo de ingreso en el almacen huachipa = 01 (eso es una limitacion del sistema si hubiera varios almacenes tendriamos problemas mas adelante)'
                    Dim c_codi_ing As String = ""
                    With c_Neg_IngAlmIQ.get_IngAlmIQ_Datos(" and I.c_serie_guia='" & Strings.Left(.Rows(i)("c_nro_oc").ToString, 3) & "' and I.c_nro_guia='" & Strings.Right(.Rows(i)("c_nro_oc").ToString, 7) & _
                                                           "' and I.c_anula_reg=0 and I.c_Codi_alm='01' ", FrmMenu.TxtCod_Emp.Text, "DAT")
                        If .Rows.Count > 0 Then
                            c_codi_ing = .Rows(0)("c_codi_ing").ToString
                        End If
                    End With
                    ' Mostramos el verdadero correlativo de ingreso '
                    With c_Neg_IngAlmIQDet.get_IngAlmIQDet_Datos(" and D.c_anula_reg=0 and D.c_codi_ing='" & c_codi_ing & "' and D.c_codi_articulo='" & .Rows(i)("c_codi_Articulo").ToString & "' ", FrmMenu.TxtCod_Emp.Text, "DAT")
                        If .Rows.Count > 0 Then
                            Dgv02.Rows(i).Cells("c_correl_guia").Value = .Rows(0)("c_nro_Correl").ToString
                        End If
                    End With
                    LblPeso.Text = Format(Val(LblPeso.Text) + Val(.Rows(i)("c_nro_cant").ToString), Forma_1_2)
                    LblTotales.Text = Format(Val(LblTotales.Text) + Val(Dgv02.Rows(i).Cells("Importe").Value), Forma_1_2)
                Next
                LblTotal_Item.Text = Dgv02.RowCount

                Call Calcular_Porcentajes() : Call Calcular_Costos()
            End If
        End With
    End Sub
    ' metodo para calcular porcentajes '
    Public Sub Calcular_Porcentajes()
        With Dgv02
            For i = 0 To .RowCount - 1
                '.Rows(i).Cells("porc").Value = Format(Val(Txttot_Gastos_Mn.Text) / Val(LblTotInvoice_Mn.Text), Forma_1_6)
                .Rows(i).Cells("porc").Value = Format(Val(.Rows(i).Cells("Cantidad").Value) / Val(LblPeso.Text), Forma_1_6)

                'MsgBox("Total gastos: " & Val(Txttot_Gastos_Mn.Text) & " y Total Invoice: " & Val(LblTotInvoice_Mn.Text))
            Next
        End With
    End Sub
    ' metodo para calcular gastos '
    Public Sub Calcular_Gastos()
        With Dgv01
            Dim Tot_Gastos As Decimal = 0 : Dim Tot_Gastos_Mn As Decimal = 0
            For i = 0 To .RowCount - 1
                Tot_Gastos = Tot_Gastos + Val(.Rows(i).Cells("Total").Value)
                Tot_Gastos_Mn = Tot_Gastos_Mn + Val(.Rows(i).Cells("Total_Mn").Value)
            Next
            Txttot_Gastos.Text = Format(Tot_Gastos + Val(TxtGastos.Text) + Val(TxtTot_Dua.Text) + Val(TxtOtros.Text), Forma_1_2)
            Txttot_Gastos_Mn.Text = Format(Tot_Gastos_Mn + Val(TxtGastos_Mn.Text) + Val(TxtTot_Dua_Mn.Text) + Val(TxtOtros_Mn.Text), Forma_1_2)

            LblTotales.Text = Format(Val(Txttot_Gastos.Text) + Val(LblTotInvoice.Text), Forma_1_2)
            LblTotales_Mn.Text = Format(Val(Txttot_Gastos_Mn.Text) + Val(LblTotInvoice_Mn.Text), Forma_1_2)
        End With
    End Sub
    ' metodo para calcular los totales
    Public Sub Calcular_Totales()
        With Dgv02
            Dim Total_Costo As Decimal = 0 : Dim Cantidad As Decimal = 0 : Dim TotInvoice As Decimal = 0
            Dim Total_Costo_Mn As Decimal = 0 : Dim TotInvoice_Mn As Decimal = 0
            For i = 0 To .RowCount - 1
                Total_Costo = Total_Costo + Val(Dgv02.Rows(i).Cells("importe").Value)
                Total_Costo_Mn = Total_Costo_Mn + Val(Dgv02.Rows(i).Cells("c_imp_mn").Value)
                ' Calculamos el total invoice '
                TotInvoice = TotInvoice + (Val(Dgv02.Rows(i).Cells("Precio").Value) * Val(Dgv02.Rows(i).Cells("Cantidad").Value))
                TotInvoice_Mn = TotInvoice_Mn + (Val(Dgv02.Rows(i).Cells("c_precio_mn").Value) * Val(Dgv02.Rows(i).Cells("Cantidad").Value))
                ' Total de Cantidad '
                Cantidad = Cantidad + Val(Dgv02.Rows(i).Cells("Cantidad").Value)
            Next
            'LblTotales.Text = Format(Total_Costo, Forma_1_2)
            LblTotales.Text = Format(Total_Costo, Forma_1_2) : LblTotales_Mn.Text = Format(Total_Costo_Mn, Forma_1_2)
            LblTotInvoice.Text = Format(TotInvoice, Forma_1_2) : LblTotInvoice_Mn.Text = Format(TotInvoice_Mn, Forma_1_2)

            LblPeso.Text = Format(Cantidad, Forma_1_2) : LblTotal_Item.Text = .RowCount
        End With
    End Sub
    ' metodo para calcular costos '
    Public Sub Calcular_Costos()
        With Dgv02
            For i = 0 To .Rows.Count - 1
                ' Dolares '
                .Rows(i).Cells("Costo").Value = Format(Val(.Rows(i).Cells("Precio").Value) + ((Val(.Rows(i).Cells("Porc").Value) * Val(Txttot_Gastos.Text)) / Val(.Rows(i).Cells("Cantidad").Value)), Forma_1_6)
                .Rows(i).Cells("Importe").Value = Format(Val(.Rows(i).Cells("Costo").Value) * Val(.Rows(i).Cells("Cantidad").Value), Forma_1_2)
                ' Soles '
                .Rows(i).Cells("c_costo_mn").Value = Format(Val(.Rows(i).Cells("c_precio_mn").Value) + ((Val(.Rows(i).Cells("Porc").Value) * Val(Txttot_Gastos.Text)) / Val(.Rows(i).Cells("Cantidad").Value)), Forma_1_6)
                .Rows(i).Cells("c_imp_mn").Value = Format(Val(.Rows(i).Cells("c_Costo_mn").Value) * Val(.Rows(i).Cells("Cantidad").Value), Forma_1_2)
            Next
        End With
    End Sub
    ' Function for recalculate type of change '
    Private Function Hallar_Tipo_Cambio() As Decimal
        With c_Neg_IngComp.get_IngComp_Datos(" and I.c_codi_prov='" & Trim(TxtCod_Prove.Text) & "' and I.c_anula_reg=0 and I.c_serie_doc='" & TxtSerie.Text &
                                             "' and I.c_nro_doc='" & TxtFactura.Text & "' ", "DAT", "FA")
            If .Rows.Count > 0 Then
                Hallar_Tipo_Cambio = Format(Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_3)
            End If
        End With
    End Function
    ' Recalcular Cambios '
    Private Sub FrmDuasCostos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            If BtnGrabar.Enabled = True Then
                TxtTC.Text = Hallar_Tipo_Cambio()
                Call Recalcular_Tpo_Cambio() ': Call Recalcular_Tpo_Cambio()
            Else
                MsgBox("1.Para recalcular primero se debe Editar...", vbCritical, Compañia)
            End If
        End If
    End Sub
    ' Metodo para recalcular el tipo de cambio
    Private Sub Recalcular_Tpo_Cambio()
        If BtnGrabar.Enabled = True Then
            With Dgv02
                For i = 0 To .RowCount - 1
                    'Dolares
                    If CboMon.SelectedValue = "02" Then
                        .Rows(i).Cells("c_precio_mn").Value = Format(Val(.Rows(i).Cells("Precio").Value) * Val(TxtTC.Text), Forma_1_6)
                    End If
                    'Soles
                    If CboMon.SelectedValue = "01" Then
                        .Rows(i).Cells("Precio").Value = Format(Val(.Rows(i).Cells("c_precio_mn").Value) / Val(TxtTC.Text), Forma_1_6)
                    End If
                    ' Actualizamos el costo '
                    .Rows(i).Cells("Importe").Value = Format(Val(.Rows(i).Cells("Precio").Value) * Val(.Rows(i).Cells("Cantidad").Value) + (Val(Txttot_Gastos.Text) * Val(.Rows(i).Cells("Porc").Value)), Forma_1_2)
                    .Rows(i).Cells("Costo").Value = Format(Val(.Rows(i).Cells("Importe").Value) / Val(.Rows(i).Cells("Cantidad").Value), Forma_1_6)

                    .Rows(i).Cells("c_imp_mn").Value = Format(Val(.Rows(i).Cells("c_Precio_mn").Value) * Val(.Rows(i).Cells("Cantidad").Value) + (Val(Txttot_Gastos_Mn.Text) * Val(.Rows(i).Cells("Porc").Value)), Forma_1_2)
                    .Rows(i).Cells("c_costo_mn").Value = Format(Val(.Rows(i).Cells("c_imp_mn").Value) / Val(.Rows(i).Cells("Cantidad").Value), Forma_1_6)
                Next
                Call Calcular_Gastos() : Call Calcular_Totales() ': Call Calcular_Porcentajes()
                ' Call Calcular_Todos()
            End With
        End If
    End Sub
    Private Sub FrmDuasCostos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    Private Sub FrmDuasCostos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_Reg=0 order by c_codi_mon", CboMon)
        Call BtnFin_Click(Nothing, Nothing)
    End Sub

    Private Sub BtnCon1_Click(sender As System.Object, e As System.EventArgs)
        FrmConProve.Show() : FrmConProve.MdiParent = FrmMenu
        FrmConProve.Cargar_Grid(" and c_anula_reg=0 order by c_desc_prov")
        FrmConProve.TxtVar.Text = 8
    End Sub

    Private Sub BtnDel_Click(sender As System.Object, e As System.EventArgs) Handles BtnDel.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Dim F As String = MsgBox("¿Confirma la eliminación del Registro?", vbYesNo + vbQuestion, Compañia)
                    If F = vbYes Then
                        Call Grabar_CostosDocs(Fila, "DEL")
                        .Rows.RemoveAt(Fila) : Call Calcular_Todos()
                        ' Activamos moneda '
                        If .RowCount = 0 Then CboMon.Enabled = True
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub TxtSerie_LostFocus(sender As Object, e As System.EventArgs) Handles TxtSerie.LostFocus
        If Len(TxtSerie.Text) > 0 Then
            TxtSerie.Text = Strings.Right(Val(TxtSerie.Text) + 1000, 3)
        End If
    End Sub

    Private Sub TxtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtSerie.TextChanged

    End Sub

    Private Sub TxtFactura_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtFactura.KeyDown

    End Sub
  
    Private Sub TxtFactura_LostFocus(sender As Object, e As System.EventArgs) Handles TxtFactura.LostFocus
        If Len(TxtFactura.Text) > 0 Then
            TxtFactura.Text = Strings.Right(Val(TxtFactura.Text) + 10000000, 7)
        End If
    End Sub

    Private Sub TxtFactura_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtFactura.TextChanged

    End Sub

    Private Sub BtnConTpoDoc_Click(sender As System.Object, e As System.EventArgs) Handles BtnConTpoDoc.Click
        If CboMon.SelectedIndex > -1 Then
            With FrmIngCompBus
                .Show() : .MdiParent = FrmMenu : .TxtVar1.Text = 3
            End With
        Else
            MsgBox("Falta seleccionar la moneda de Costo...", vbCritical, Compañia)
        End If
    End Sub
    ' funcion para validar la grabacion del registro
    Private Function ValidarDatos() As Boolean
        If Val(TxtTC.Text) > 0 Then
            If CboMon.SelectedIndex > -1 Then
                If Len(TxtCod_Prove.Text) > 0 Then
                    If Len(TxtSerie.Text) > 0 And Len(TxtFactura.Text) Then
                        If Dgv01.RowCount > 0 Then
                            If Dgv02.RowCount > 0 Then
                                ValidarDatos = True
                            Else
                                MsgBox("1. Falta ingresar el detalle de Artículos...", vbCritical, Compañia)
                                ValidarDatos = False
                            End If
                        Else
                            MsgBox("2. Falta ingresar las facturas anexas por la nacionalización...", vbCritical, Compañia)
                            ValidarDatos = False
                        End If
                    Else
                        MsgBox("3. Falta Seleccionar la factura...", vbCritical, Compañia)
                        ValidarDatos = False
                    End If
                Else
                    MsgBox("4. Falta Seleccionar el Proveedor...", vbCritical, Compañia)
                    ValidarDatos = False
                End If
            Else
                MsgBox("5. Falta Seleccionar la moneda para el costeo...", vbCritical, Compañia)
                ValidarDatos = False
            End If
        Else
            MsgBox("6. Falta registrar el tipo de cambio para la fecha: " & DtpFec_Emi.Text, vbCritical, Compañia)
            ValidarDatos = False
        End If
    End Function
    Private Sub BtnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarDatos() = True Then
            Dim F As String = MsgBox("¿Desea Grabar el Costo?", vbYesNo + vbQuestion, Compañia)
            If F = vbYes Then
                Call Grabar_CostosCab("ADD")
                If Len(TxtNro_Costo.Text) > 0 Then
                    With Dgv01
                        ' grabamos documentos
                        For i = 0 To .RowCount - 1
                            Call Grabar_CostosDocs(i, "ADD")
                        Next
                    End With
                    ' grabamos detalles
                    For i = 0 To Dgv02.RowCount - 1
                        Call Grabar_CostosDet(i, "ADD")
                    Next
                    If Len(TxtNro_Costo.Text) > 0 Then
                        Call Mostrar_Costos(" and  c_nro_costo='" & TxtNro_Costo.Text & "' ")
                    Else
                        Call Cancelar_Registro() : MsgBox("Registro se grabo correctamente...", vbExclamation, Compañia)
                        Call BtnFin_Click(Nothing, Nothing)
                    End If
                Else
                    MsgBox("1.Costo no se pudo grabar, revisar...", vbCritical, Compañia)
                End If
            End If
        End If
    End Sub
    ' metodo para grabar registros
    Private Sub Grabar_CostosCab(ByVal vOpt As String)
        With c_Ent_CostosCab
            .c_nro_costo = TxtNro_Costo.Text
            .c_nro_file = TxtNro_File.Text
            .c_codi_prov = TxtCod_Prove.Text
            .c_fecha_costo = DtpFec_Emi.Text
            .c_fecha_emi = DtpFec_Emi.Text
            .c_fecha_embarque = DtpFec_Embarque.Text
            .c_fecha_llegada = DtpFec_Llegada.Text
            .c_agencia_comercial = TxtAgencia.Text
            .c_nro_dua = TxtCod_Dua.Text
            .c_imp_dua = Val(TxtTot_Dua.Text)
            .c_tpo_cambio = Val(TxtTC.Text)
            .c_mon_costo = CboMon.SelectedValue
            .c_codi_mon = TxtMon_Doc.Text
            .c_codi_doc = Strings.Right(LblTpoDoc.Text, 2)
            .c_serie_doc = TxtSerie.Text
            .c_nro_doc = TxtFactura.Text
            .c_total_costo = Val(Txttot_Gastos.Text)
            .c_total_peso = Val(LblPeso.Text)
            .c_total_item = Val(LblTotal_Item.Text)
            .c_imp_total = Val(LblTotales.Text)
            .c_total_invoice = Val(LblTotInvoice.Text)
            .c_costo_bcos = Val(TxtGastos.Text)
            .c_imp_otros = Val(TxtOtros.Text)

            .c_imp_dua_mn = Val(TxtTot_Dua_Mn.Text)
            .c_total_costo_mn = Val(TxtGastos_Mn.Text)
            .c_imp_total_mn = Val(LblTotales_Mn.Text)
            .c_total_invoice_mn = Val(LblTotInvoice_Mn.Text)
            .c_costo_bcos_mn = Val(TxtGastos_Mn.Text)
            .c_imp_otros_mn = Val(TxtOtros_Mn.Text)

            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .cOpcion = vOpt
            If Val(TxtNro_Costo.Text) = 0 Then
                TxtNro_Costo.Text = c_Neg_CostosCab.set_CostosCab_Save(c_Ent_CostosCab)
            Else
                c_Neg_CostosCab.set_CostosCab_Save(c_Ent_CostosCab)
            End If
        End With
    End Sub
    ' metodo para grabar el detalle del costo 
    Private Sub Grabar_CostosDet(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_CostosDet
            .c_nro_correl = Dgv02.Rows(Fila).Cells("Item").Value
            .c_nro_costo = TxtNro_Costo.Text
            .c_serie_guia = Strings.Left(Dgv02.Rows(Fila).Cells("c_nro_guia").Value, 3)
            .c_nro_guia = Strings.Right(Dgv02.Rows(Fila).Cells("c_nro_guia").Value, 7)
            .c_codi_articulo = Dgv02.Rows(Fila).Cells("Codigo").Value
            .c_codi_unimed = Dgv02.Rows(Fila).Cells("c_codi_unimed").Value
            .c_nro_cant = Val(Dgv02.Rows(Fila).Cells("Cantidad").Value)
            .c_precio_unit = Val(Dgv02.Rows(Fila).Cells("Precio").Value)
            .c_precio_costo = Val(Dgv02.Rows(Fila).Cells("Costo").Value)
            .c_imp_total = Val(Dgv02.Rows(Fila).Cells("Importe").Value)

            .c_precio_unit_mn = Val(Dgv02.Rows(Fila).Cells("c_precio_mn").Value)
            .c_precio_costo_mn = Val(Dgv02.Rows(Fila).Cells("c_costo_mn").Value)
            .c_imp_total_mn = Val(Dgv02.Rows(Fila).Cells("c_imp_mn").Value)

            .c_porc_costo = Val(Dgv02.Rows(Fila).Cells("Porc").Value)
            .c_correl_guia = Dgv02.Rows(Fila).Cells("c_correl_guia").Value
            .c_correl_ing = Dgv02.Rows(Fila).Cells("c_correl_ing").Value
            .copcion = cOpcion
            If Val(Dgv02.Rows(Fila).Cells("Item").Value) = 0 Then
                Dgv02.Rows(Fila).Cells("Item").Value = c_Neg_CostosDet.set_CostosDet_Save(c_Ent_CostosDet)
            Else
                c_Neg_CostosDet.set_CostosDet_Save(c_Ent_CostosDet)
            End If
        End With
    End Sub
    ' metodo para grabar los documentos anexos '
    Private Sub Grabar_CostosDocs(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_CostosDocs
            .c_nro_correl = Dgv01.Rows(Fila).Cells("c_nro_correl").Value
            .c_nro_costo = TxtNro_Costo.Text
            .c_codi_doc = Dgv01.Rows(Fila).Cells("c_codi_doc").Value
            .c_nro_ing = Dgv01.Rows(Fila).Cells("c_nro_ing").Value
            .c_fecha_emi = Dgv01.Rows(Fila).Cells("Fecha").Value
            .c_tpo_cambio = Dgv01.Rows(Fila).Cells("c_tpo_cambio").Value
            .c_codi_mon = CboMon.SelectedValue
            .c_mon_doc = Dgv01.Rows(Fila).Cells("c_codi_mon").Value
            .c_imp_total = Dgv01.Rows(Fila).Cells("Total").Value
            .c_imp_total_mn = Val(Dgv01.Rows(Fila).Cells("Total_Mn").Value)
            .copcion = cOpcion
            If Val(Dgv01.Rows(Fila).Cells("c_nro_correl").Value) = 0 Then
                Dgv01.Rows(Fila).Cells("c_nro_correl").Value = c_Neg_CostosDocs.set_CostosDocs_Save(c_Ent_CostosDocs)
            Else
                c_Neg_CostosDocs.set_CostosDocs_Save(c_Ent_CostosDocs)
            End If
        End With
    End Sub

    Private Sub BtnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            If Len(TxtNro_Costo.Text) > 0 Then
                Call Mostrar_Costos(" and  c_nro_costo='" & TxtNro_Costo.Text & "' ")
            Else
                Call Cancelar_Registro() : Call BtnFin_Click(Nothing, Nothing)
            End If

        End If
    End Sub

    Private Sub BtnFin_Click(sender As System.Object, e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_Costos(" and c_nro_costo=(select max(c_nro_costo) from scom_CostosCab) ")
    End Sub
    ' metodo para mostrar costos
    Private Sub Mostrar_Costos(ByVal Cadena As String)
        With c_Neg_CostosCab.get_CostosCab_Datos(Cadena, "DAT")
            Call Cancelar_Registro() : Dgv01.Rows.Clear() : Dgv02.Rows.Clear()
            LblTotal_Item.Text = "" : LblTotales.Text = ""
            If .Rows.Count > 0 Then
                CboMon.SelectedValue = .Rows(0)("c_mon_costo").ToString
                DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                DtpFec_Embarque.Text = .Rows(0)("c_fecha_embarque").ToString
                DtpFec_Llegada.Text = .Rows(0)("c_fecha_llegada").ToString
                TxtAgencia.Text = .Rows(0)("c_agencia_comercial").ToString
                TxtCod_Dua.Text = .Rows(0)("c_nro_dua").ToString
                'MOSTRAMOS NUMERO DE DUA'
                With c_Neg_DuasCab.get_DuasCab_Datos(" AND c.c_nro_operacion='" & TxtCod_Dua.Text & "'", "DAT")
                    If .Rows.Count > 0 Then
                        TxtDua.Text = .Rows(0)("c_serie_dua").ToString & "-" & .Rows(0)("c_nro_dua").ToString
                    End If
                End With
                TxtTot_Dua.Text = Format(Val(.Rows(0)("c_imp_dua").ToString), Forma_1_2)
                TxtTot_Dua_Mn.Text = Format(Val(.Rows(0)("c_imp_dua_mn").ToString), Forma_1_2)
                TxtTC.Text = Format(Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_3)
                TxtCod_Prove.Text = .Rows(0)("c_codi_prov").ToString
                TxtProve.Text = .Rows(0)("c_desc_prov").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                TxtMon_Doc.Text = .Rows(0)("c_codi_mon").ToString
                TxtNro_Costo.Text = .Rows(0)("c_nro_costo").ToString
                TxtBuscar.Text = .Rows(0)("c_nro_costo").ToString
                LblTpoDoc.Text = .Rows(0)("c_desc_doc").ToString & " " & .Rows(0)("c_codi_doc").ToString
                TxtSerie.Text = .Rows(0)("c_serie_doc").ToString
                TxtFactura.Text = .Rows(0)("c_nro_doc").ToString
                TxtUsua_Crea.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_Modi.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                LblPeso.Text = Format(Val(.Rows(0)("c_total_peso").ToString), Forma_1_2)
                LblTotal_Item.Text = Format(Val(.Rows(0)("c_total_item").ToString), Forma_1_2)

                LblTotales.Text = Format(Val(.Rows(0)("c_imp_total").ToString), Forma_1_2)
                LblTotales_Mn.Text = Format(Val(.Rows(0)("c_imp_total_mn").ToString), Forma_1_2)
                TxtOtros.Text = Format(Val(.Rows(0)("c_imp_otros").ToString), Forma_1_2)
                TxtOtros_Mn.Text = Format(Val(.Rows(0)("c_imp_otros_mn").ToString), Forma_1_2)

                TxtNro_File.Text = .Rows(0)("c_nro_file").ToString

                TxtGastos.Text = Format(Val(.Rows(0)("c_costo_bcos").ToString), Forma_1_2)
                TxtGastos_Mn.Text = Format(Val(.Rows(0)("c_costo_bcos_mn").ToString), Forma_1_2)
                LblTotInvoice.Text = Format(Val(.Rows(0)("c_total_invoice").ToString), Forma_1_2)
                LblTotInvoice_Mn.Text = Format(Val(.Rows(0)("c_total_invoice_mn").ToString), Forma_1_2)

                ' Validamos documento anulado '
                If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                    BtnEstado.Text = "Pendiente" : BtnEstado.BackColor = Color.Maroon
                Else
                    BtnEstado.Text = "Anulado" : BtnEstado.BackColor = Color.Red
                End If
                ' detalles de articulos
                With c_Neg_CostosDet.get_CostosDet_Datos(" and D.c_nro_costo='" & .Rows(0)("c_nro_costo").ToString & "' and D.c_anula_reg=0 order by D.c_nro_correl", "DAT")
                    Dgv02.Rows.Clear()
                    For I = 0 To .Rows.Count - 1
                        Dgv02.Rows.Add()
                        Dgv02.Rows(I).Cells("c_nro_guia").Value = .Rows(I)("c_serie_guia").ToString & "-" & .Rows(I)("c_nro_guia").ToString
                        Dgv02.Rows(I).Cells("Codigo").Value = .Rows(I)("c_codi_articulo").ToString
                        Dgv02.Rows(I).Cells("Cantidad").Value = Format(Val(.Rows(I)("c_nro_cant").ToString), Forma_1_2)
                        Dgv02.Rows(I).Cells("c_codi_unimed").Value = .Rows(I)("c_codi_unimed").ToString
                        Dgv02.Rows(I).Cells("Unid").Value = .Rows(I)("c_desc_unimed").ToString
                        Dgv02.Rows(I).Cells("Descripcion").Value = .Rows(I)("c_desc_articulo").ToString
                        Dgv02.Rows(I).Cells("Precio").Value = Format(Val(.Rows(I)("c_precio_unit").ToString), Forma_1_4)
                        Dgv02.Rows(I).Cells("Costo").Value = Format(Val(.Rows(I)("c_precio_costo").ToString), Forma_1_6)
                        Dgv02.Rows(I).Cells("Importe").Value = Format(Val(.Rows(I)("c_imp_total").ToString), Forma_1_2)

                        Dgv02.Rows(I).Cells("c_precio_mn").Value = Format(Val(.Rows(I)("c_precio_unit_mn").ToString), Forma_1_4)
                        Dgv02.Rows(I).Cells("c_costo_mn").Value = Format(Val(.Rows(I)("c_precio_costo_mn").ToString), Forma_1_6)
                        Dgv02.Rows(I).Cells("c_imp_mn").Value = Format(Val(.Rows(I)("c_imp_total_mn").ToString), Forma_1_2)

                        Dgv02.Rows(I).Cells("Item").Value = .Rows(I)("c_nro_correl").ToString
                        Dgv02.Rows(I).Cells("c_correl_guia").Value = .Rows(I)("c_correl_guia").ToString
                        Dgv02.Rows(I).Cells("c_correl_ing").Value = .Rows(I)("c_correl_ing").ToString
                        Dgv02.Rows(I).Cells("Porc").Value = .Rows(I)("c_porc_costo").ToString
                    Next
                End With
                ' Documentos anexos
                With c_Neg_CostosDocs.get_CostosDocs_Datos(" and D.c_nro_costo='" & .Rows(0)("c_nro_costo").ToString & "' and D.c_anula_reg=0 order by D.c_nro_correl", "DAT")
                    Dgv01.Rows.Clear()
                    For I = 0 To .Rows.Count - 1
                        Dgv01.Rows.Add()
                        Dgv01.Rows(I).Cells("Documento").Value = .Rows(I)("c_serie_doc").ToString & "-" & .Rows(I)("c_nro_doc").ToString
                        Dgv01.Rows(I).Cells("Total").Value = Format(Val(.Rows(I)("c_imp_total").ToString), Forma_1_2)
                        Dgv01.Rows(I).Cells("Total_Mn").Value = Format(Val(.Rows(I)("c_imp_total_mn").ToString), Forma_1_2)
                        Dgv01.Rows(I).Cells("fecha").Value = FormatDateTime(.Rows(I)("c_fecha_emi").ToString, DateFormat.ShortDate)
                        Dgv01.Rows(I).Cells("c_nro_ing").Value = .Rows(I)("c_nro_ing").ToString
                        Dgv01.Rows(I).Cells("c_tpo_cambio").Value = Format(Val(.Rows(I)("c_tpo_cambio").ToString), Forma_1_3)
                        Dgv01.Rows(I).Cells("c_codi_mon").Value = .Rows(I)("c_codi_mon").ToString
                        Dgv01.Rows(I).Cells("c_codi_doc").Value = .Rows(I)("c_codi_doc").ToString
                        Dgv01.Rows(I).Cells("c_nro_correl").Value = .Rows(I)("c_nro_correl").ToString
                    Next
                End With
                'Call Calcular_Todos()
                Call Calcular_Gastos() : Call Calcular_Porcentajes() : Call Calcular_Totales()
            End If
        End With
    End Sub

    Private Sub BtnIni_Click(sender As System.Object, e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_Costos(" and c_nro_costo=(select min(c_nro_costo) from scom_CostosCab) ")
    End Sub

    Private Sub BtnAtr_Click(sender As System.Object, e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBuscar.Text) > 1 Then
            TxtBuscar.Text = Strings.Right((Val(TxtBuscar.Text) - 1) + 10000000, 7)
            Call Mostrar_Costos(" and  c_nro_costo='" & TxtBuscar.Text & "' ")
        End If
    End Sub

    Private Sub BtnAva_Click(sender As System.Object, e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBuscar.Text) > 0 Then
            TxtBuscar.Text = Strings.Right(Val(TxtBuscar.Text) + 10000001, 7)
            Call Mostrar_Costos(" and c_nro_costo='" & TxtBuscar.Text & "' ")
        End If
    End Sub

    Private Sub TxtBuscar_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBuscar.Text) > 0 Then
                TxtBuscar.Text = Strings.Right(Val(TxtBuscar.Text) + 10000000, 7)
                Call Mostrar_Costos(" and  c_nro_costo='" & TxtBuscar.Text & "' ")
            End If
        End If
    End Sub

    Private Sub TxtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtBuscar.TextChanged

    End Sub
    ' --> Editamos Registros <-- '
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If ValidarCierre(DtpFec_Emi.Text) = True Then
            If UCase(BtnEstado.Text) = "PENDIENTE" Then
                If Len(TxtNro_Costo.Text) > 0 Then
                    BtnConTpoDoc.Enabled = False : CboMon.Enabled = False : Pan09.Enabled = True : TxtObs.Enabled = True
                    Pan07.Enabled = False : BtnGrabar.Enabled = True : BtnCerrar.Text = "&Cancelar" : DtpFec_Emi.Enabled = False
                    TxtGastos.Enabled = True : DtpFec_Embarque.Enabled = True : DtpFec_Llegada.Enabled = True : TxtAgencia.Enabled = True
                    BtnConDua.Enabled = True : BtnEliDua.Enabled = True : TxtOtros.Enabled = True
                    TxtOtros_Mn.Enabled = True : Txttot_Gastos_Mn.Enabled = True : TxtGastos_Mn.Enabled = True : Pan12.Enabled = False
                Else
                    MsgBox("Registro no puede ser modificado...", MsgBoxStyle.Critical, Compañia)
                End If
            Else
                MsgBox("Registro se encuentra Cerrado o esta anulado, no podra realizar ninguna modificación", MsgBoxStyle.Critical, Compañia)
            End If
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If UCase(BtnEstado.Text) = "PENDIENTE" Then
                        If ValidarCierre(DtpFec_Emi.Text) = True Then
                            Dim F As String = MsgBox(" ¿Confirma la Anulación del Registro? ", vbYesNo + vbQuestion, Compañia)
                            If F = vbYes Then
                                Call Grabar_CostosCab("DEL")
                                ' Grabamos detalles de documentos '
                                With Dgv01
                                    For i = 0 To .RowCount - 1
                                        Call Grabar_CostosDocs(i, "DEL")
                                    Next
                                End With
                                ' Grabamos detalles de documentos '
                                With Dgv02
                                    For i = 0 To .RowCount - 1
                                        Call Grabar_CostosDet(i, "DEL")
                                    Next
                                End With
                                BtnEstado.Text = "Anulado" : BtnEstado.BackColor = Color.Red
                                MsgBox(" Registro se Anulo Correctamente...", vbExclamation, Compañia)
                            End If
                        End If
                    Else
                        MsgBox(" Registro se encuentra Anulado... ", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    ' consultamos nota de credito '
    Private Sub BtnNc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNc.Click
        If CboMon.SelectedIndex > -1 Then
            With FrmConNotaC
                .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 2
            End With
        Else
            MsgBox("Falta seleccionar la moneda de costo...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub DtpFec_Emi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Emi.ValueChanged
        Call Mostrar_TpoCambio(DtpFec_Emi.Text, TxtTC)
    End Sub

    Private Sub CboMon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMon.SelectedIndexChanged
        With Dgv01
            .Columns("Total").HeaderText = "Total $."
            .Columns("Total_Mn").HeaderText = "Total S/"
        End With
    End Sub
    ' Calculamos todos '
    Private Sub TxtGastos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGastos.TextChanged
        If TxtGastos.Enabled = True Then Call Calcular_Todos()
    End Sub

    Private Sub TxtTot_Dua_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTot_Dua.TextChanged
        If TxtTot_Dua.Enabled = True Then Call Calcular_Todos()
    End Sub

    Private Sub Txttot_Gastos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Txttot_Gastos.TextChanged

    End Sub

    Private Sub BtnConDua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConDua.Click
        With FrmConDuas
            .MdiParent = FrmMenu : .Show() : .TxtVar.Text = 2
        End With
    End Sub

    Private Sub BtnEliDua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliDua.Click
        TxtDua.Clear() : TxtCod_Dua.Clear() : TxtTot_Dua.Text = "0.00"
    End Sub

    Private Sub TxtOtros_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOtros.TextChanged
        If TxtOtros.Enabled = True Then Call Calcular_Todos()
    End Sub

    Private Sub TxtOtros_Mn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOtros_Mn.TextChanged
        If TxtOtros_Mn.Enabled = True Then Call Calcular_Todos()
    End Sub

    Private Sub TxtGastos_Mn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtGastos_Mn.TextChanged
        If TxtGastos_Mn.Enabled = True Then Call Calcular_Todos()
    End Sub

    Private Sub Txttot_Gastos_Mn_TextChanged(sender As Object, e As EventArgs) Handles Txttot_Gastos_Mn.TextChanged

    End Sub
End Class