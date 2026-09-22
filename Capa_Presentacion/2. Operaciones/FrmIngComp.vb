Public Class FrmIngComp

    Private isLoading As Boolean = True

    Private Sub FrmIngComp_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.KeyCode = Keys.Escape Then
            If Pan13.Visible = True Then
                Call Aceptar_Ingreso()
            Else
                Dim f As String = MsgBox("¿Desea cerrar la aplicación?", vbYesNo + vbQuestion, Compañia)
                If f = vbYes Then Me.Close()
            End If
        End If
    End Sub
    Private Sub FrmIngComp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmIngComp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_codi_mon", CboMon)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
        c_Neg_MnTblDetraccion.Get_MntblDetraccion_Cbo(" And c_anula_reg=0 order by c_codi_detracc", CboDetrac)
        isLoading = False
        Call BtnFin_Click(Nothing, Nothing)
    End Sub
 
    Private Sub Iniciar_IngComp()
        Call Mostrar_IngComp(" and c_nro_ing=(select max(c_nro_ing) from scom_" & FrmMenu.TxtCod_Emp.Text & "_ingcomp) ")
    End Sub
    Private Sub Configurar_Grid()
        With Dgv01
            .Columns.Add("Check", "")
            .Columns.Add("Doc", "Doc.")
            .Columns.Add("Total", "Total")
            .Columns.Add("Fecha", "Fecha")
        End With
        With Dgv02
            .Columns.Add("Cant", "Cant")
            .Columns.Add("Unid", "Unid.")
            .Columns.Add("Descripcion", "Descripcion")
            .Columns.Add("Precio", "P.Unit.")
            .Columns.Add("Importe", "Importe")
        End With
    End Sub
    'mostramos orden de compra...
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        'Insertamos por guia de remision solo las ordenes de compras...tpo
        With c_Neg_IngAlmIQ.get_IngAlmIQ_Datos(" and c_codi_prov='" & TxtCod_Prov.Text & "' And I.c_codi_mon='" & CboMon.SelectedValue & "' ", FrmMenu.TxtCod_Emp.Text, "COM") 'c_Neg_IngAlm.get_IngAlmCOM_Datos2("")
            Dim pos As Integer = 0
            'validamos si grabamos o editamos registro...
            If Val(TxtCod_Ing.Text) > 0 Then
                pos = Dgv01.RowCount
            Else
                Dgv01.Rows.Clear()
                Dgv02.Rows.Clear()
            End If
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    Dgv01.Rows.Add()
                    Dgv01.Rows(i + pos).Cells("Check").Value = False
                    Dgv01.Rows(i + pos).Cells("Tpo").Value = .Rows(i)("Tpo.").ToString
                    Dgv01.Rows(i + pos).Cells("Doc").Value = .Rows(i)("Doc.").ToString
                    Dgv01.Rows(i + pos).Cells("Total").Value = Format(Val(.Rows(i)("Total").ToString), Forma_1_2)
                    Dgv01.Rows(i + pos).Cells("Fecha").Value = FormatDateTime(.Rows(i)("Fecha").ToString, DateFormat.ShortDate)
                    Dgv01.Rows(i + pos).Cells("c_nro_correl").Value = ""
                    Dgv01.Rows(i + pos).Cells("c_codi_ing").Value = .Rows(i)("c_codi_ing").ToString
                Next
            End If
            Call Calcular_Retencion_Detraccion()
        End With
    End Sub
    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick
        '
        ' Detecta si se ha seleccionado el header de la grilla
        '
        If e.RowIndex = -1 Then
            Return
        End If

        If Dgv01.Columns(e.ColumnIndex).Name = "Check" Then

            '
            ' Se toma la fila seleccionada
            '
            Dim row As DataGridViewRow = Dgv01.Rows(e.RowIndex)

            '
            ' Se selecciona la celda del checkbox
            '
            Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("check"), DataGridViewCheckBoxCell)
            Dim fila As Integer = 0
            If Convert.ToBoolean(cellSelecion.Value) Then
                With Dgv01
                    If .Rows.Count > 0 Then
                        fila = .CurrentCellAddress.Y
                        If .Rows(fila).Cells("Tpo").Value = "OS" Then 'Para orden de servicio
                            Call Mostrar_Detalle_OC(" and D.c_anula_reg=0 and D.c_nro_serie='" & Strings.Left(.Rows(fila).Cells("Doc").Value, 3) & _
                                                "' and D.c_nro_oc='" & Strings.Right(.Rows(fila).Cells("Doc").Value, 7) & "' ")
                        Else 'Guia de remision
                            Call Mostrar_Detalle_Ing(" and Ca.c_codi_prov='" & TxtCod_Prov.Text & "' and D.c_anula_reg=0 and Ca.c_serie_guia='" & Strings.Left(.Rows(fila).Cells("Doc").Value, 3) & _
                                                "' and Ca.c_nro_guia='" & Strings.Right(.Rows(fila).Cells("Doc").Value, 7) & "' ")

                        End If
                    End If
                End With
            Else 'Eliminamos registro de la oc de compra que fue desabilitada...
                With Dgv02
                    If .RowCount > 0 Then
                        fila = Dgv01.CurrentCellAddress.Y
                        For i = .RowCount - 1 To 0 Step -1
                            ' MsgBox(Strings.Left(.Rows(i).Cells("c_nro_oc").Value, 3) & " " & Strings.Right(.Rows(i).Cells("c_nro_oc").Value, 7) & " = " & Dgv01.Rows(fila).Cells("doc").Value)
                            If Strings.Left(.Rows(i).Cells("c_nro_oc").Value, 3) & " " & Strings.Right(.Rows(i).Cells("c_nro_oc").Value, 7) = Dgv01.Rows(fila).Cells("doc").Value Then
                                .Rows.RemoveAt(i)
                            End If
                        Next
                    End If
                End With
            End If
            Call Calcular_Totales()
        End If
    End Sub
    Private Sub Dgv01_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.CurrentCellDirtyStateChanged
        If Dgv01.IsCurrentCellDirty Then
            Dgv01.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub
    Private Sub Mostrar_Detalle_OC(ByVal Cadena As String) 'cadena=detalles de O.C. 
        With c_Neg_OCDet.get_OCDet_Datos(Cadena, FrmMenu.TxtCod_Emp.Text, "DAT")
            If .Rows.Count > 0 Then
                Dim Pos As Integer = Dgv02.RowCount
                For i = 0 To .Rows.Count - 1
                    Dgv02.Rows.Add()
                    Dgv02.Rows(Pos + i).Cells("Tg").Value = .Rows(i)("c_codi_tg").ToString
                    Dgv02.Rows(Pos + i).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString
                    Dgv02.Rows(Pos + i).Cells("Scd").Value = .Rows(i)("c_codi_scd").ToString
                    Dgv02.Rows(Pos + i).Cells("Descripcion").Value = .Rows(i)("c_desc_scd").ToString
                    Dgv02.Rows(Pos + i).Cells("Cant").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), Forma_1_2)
                    Dgv02.Rows(Pos + i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                    Dgv02.Rows(Pos + i).Cells("Precio").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_3)
                    Dgv02.Rows(Pos + i).Cells("Importe").Value = Format(Val(.Rows(i)("c_imp_total").ToString), Forma_1_2)
                    Dgv02.Rows(Pos + i).Cells("Igv").Value = .Rows(i)("c_opt_igv").ToString
                    Dgv02.Rows(Pos + i).Cells("codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                    Dgv02.Rows(Pos + i).Cells("c_nro_oc").Value = .Rows(i)("c_nro_serie").ToString & " " & .Rows(i)("c_nro_oc").ToString
                    Dgv02.Rows(Pos + i).Cells("c_correl_ing").Value = .Rows(i)("c_nro_correl").ToString
                    Dgv02.Rows(Pos + i).Cells("c_codi_doc").Value = "OS"
                    Dgv02.Rows(Pos + i).Cells("Item").Value = ""
                Next
            End If
        End With
    End Sub
    Private Sub Mostrar_Detalle_Ing(ByVal Cadena As String) 'cadena=detalles de O.C. 
        With c_Neg_IngAlmIQDet.get_IngAlmIQDet_Datos(Cadena, FrmMenu.TxtCod_Emp.Text, "DAT")
            If .Rows.Count > 0 Then
                Dim Pos As Integer = Dgv02.RowCount
                For i = 0 To .Rows.Count - 1
                    Dgv02.Rows.Add()
                    Dgv02.Rows(Pos + i).Cells("Tg").Value = .Rows(i)("c_codi_tg").ToString
                    Dgv02.Rows(Pos + i).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString
                    Dgv02.Rows(Pos + i).Cells("Scd").Value = .Rows(i)("c_codi_scd").ToString
                    Dgv02.Rows(Pos + i).Cells("Descripcion").Value = .Rows(i)("c_desc_articulo").ToString
                    Dgv02.Rows(Pos + i).Cells("Cant").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), Forma_1_4)

                    Dgv02.Rows(Pos + i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                    Dgv02.Rows(Pos + i).Cells("Precio").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_3)
                    Dgv02.Rows(Pos + i).Cells("Importe").Value = Format(Val(.Rows(i)("c_imp_total").ToString), Forma_1_2)
                    Dgv02.Rows(Pos + i).Cells("Igv").Value = Val(.Rows(i)("c_opt_igv").ToString)
                    Dgv02.Rows(Pos + i).Cells("codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                    Dgv02.Rows(Pos + i).Cells("c_nro_oc").Value = .Rows(i)("c_serie_guia").ToString & " " & .Rows(i)("c_nro_guia").ToString
                    Dgv02.Rows(Pos + i).Cells("c_codi_doc").Value = "GR"
                    Dgv02.Rows(Pos + i).Cells("c_correl_ing").Value = .Rows(i)("c_nro_correl").ToString
                    Dgv02.Rows(Pos + i).Cells("Item").Value = ""
                Next
            End If
        End With
    End Sub

    Private Sub Calcular_Totales()
        With Dgv02
            Call Limpiar_Texto(Pan11)
            Dgv03.Rows.Clear()
            Dim SubTotal As Decimal = 0 : Dim Inaf, Afecto As Decimal
            For i = 0 To .RowCount - 1
                SubTotal = SubTotal + Val(.Rows(i).Cells("Importe").Value)
                If Val(.Rows(i).Cells("Igv").Value) = 0 Then
                    Inaf = Inaf + Val(.Rows(i).Cells("Importe").Value)
                Else 'Importe afecto a Igv
                    Afecto = Afecto + Val(.Rows(i).Cells("Importe").Value)
                End If
            Next
            Dgv03.Rows.Add()
            Dgv03.Rows(0).Cells("Titulo").Value = "Sub-Total"
            Dgv03.Rows(0).Cells("SubTotal").Value = Format(SubTotal, Forma_2_2)
            'mostramos los totales
            TxtInaf.Text = Format(Inaf, Forma_1_2)
            TxtAfecto.Text = Format(Afecto, Forma_1_2)
            TxtImp_Igv.Text = Format((Val(TxtPor_Igv.Text) / 100) * Val(TxtAfecto.Text), Forma_1_2)
            TxtTotal.Text = Format(Val(TxtAfecto.Text) + Val(TxtImp_Igv.Text) + Val(TxtInaf.Text), Forma_1_2)
        End With
    End Sub
    'buscamos al presionar la tecla enter
    Private Sub TxtBus_Oc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Oc.KeyDown
        If e.KeyCode = Keys.Enter Then If Val(TxtBus_Oc.Text) > 0 Then If BtnMostrar.Enabled = True Then Call BtnMostrar_Click(Nothing, Nothing)
    End Sub
    'agregamos los ceros alrededor para efectuar la busqueda....
    Private Sub TxtBus_Oc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBus_Oc.LostFocus
        If Val(TxtBus_Oc.Text) > 0 Then
            TxtBus_Oc.Text = Strings.Right(Val(TxtBus_Oc.Text) + 10000000, 7)
        End If
    End Sub

    Private Sub TxtBus_Oc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Oc.TextChanged

    End Sub
    'NUEVO REGISTRO...
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call nuevo_registro() : CboMon.Focus() : DtpFec_Emi.Text = Date.Now : DtpFec_Prdo.Text = Date.Now : DtpFec_Venci.Text = Date.Now
        Call Limpiar_Texto(Pan02) : Call Limpiar_Texto(Pan04) : Call Limpiar_Texto(Pan11) 'totales
        CboMon.SelectedIndex = -1 : BtnDoc.Text = "" : Dgv01.Rows.Clear() : Dgv02.Rows.Clear() : Dgv03.Rows.Clear()
        Pan16.Enabled = False : ChkRetencion.Enabled = True : ChkRetencion.Checked = False : Rdb02.Checked = True
        Call Limpiar_Texto(Pan11) : BtnConLeasing.Enabled = True : Call Limpiar_Texto(Pan21) : ChkImportacion.Checked = False : ChkImportacion.Enabled = True
        TxtCod_Maq.Enabled = True : TxtCod_Maq.Clear()
    End Sub
    Private Sub Buscar_TC_IGV()
        'hallamos el porcentaje de igv...
        If Val(TxtPor_Igv.Text) = 0 Then
            With c_Neg_Igv.get_Igv_Datos(" and c_fecha_emi<='" & DtpFec_Emi.Text & "' order by c_fecha_emi desc", "DAT")
                TxtPor_Igv.Clear()
                If .Rows.Count > 0 Then
                    TxtPor_Igv.Text = Format(Val(.Rows(0)("c_por_igv").ToString), Forma_1_3)
                End If
            End With
        End If

        'hallamos el tipo de 

        With c_Neg_TpoCambio.get_TpoCambio_Datos(" and c_fecha_cbo='" & DtpFec_Emi.Text & "' ", "DAT")
            TxtTC.Clear()
            If .Rows.Count > 0 Then
                TxtTC.Text = Format(Val(.Rows(0)("c_venta_sunat").ToString), Forma_1_3)
            End If
        End With
        'hallamos la fecha de vencimiento
        DtpFec_Venci.Text = DateAdd("d", Val(TxtDias.Text), DtpFec_Emi.Text)
    End Sub
    'NUEVO REGISTRO...
    Private Sub Nuevo_Registro()
        CboMon.Enabled = True : BtnCon1.Enabled = True : BtnCon2.Enabled = True
        Pan04.Enabled = True : TxtObs.Enabled = True : BtnEstado.Text = "PENDIENTE"
        BtnEstado.BackColor = Drawing.Color.Maroon : BtnNuevo.Enabled = False : BtnEditar.Enabled = False
        BtnEliminar.Enabled = False : BtnGrabar.Enabled = True : BtnCerrar.Text = "Cancelar"
        Dgv01.Columns("Check").ReadOnly = False
        Dgv01.Enabled = True : Pan12.Enabled = False
        BtnBuscar.Enabled = False : BtnHistorial.Enabled = False : BtnAnexarDet.Enabled = False : BtnMostrar.Enabled = True
        DtpFec_Emi.Enabled = True : DtpFec_Prdo.Enabled = True : DtpFec_Venci.Enabled = True
        BtnConTpoDoc.Enabled = True : BtnDoc.Enabled = True : Dgv02.AllowUserToDeleteRows = True
        Call Buscar_TC_IGV() : BtnImp.Enabled = False
        BtnEstado.Text = "PENDIENTE" : BtnEstado.BackColor = Drawing.Color.Maroon : BtnEstado.ForeColor = Color.White
        TxtObs.Clear() : ChkRetencion.Enabled = True : Rdb01.Enabled = True : Rdb02.Enabled = True : CboDetrac.Enabled = True
        ChkImportacion.Enabled = True : TxtPor_Igv.Enabled = True
    End Sub
    'NUEVO REGISTRO...
    Private Sub cancela_registro()
        TxtProve.Enabled = False : Dgv01.Columns("Check").ReadOnly = True : BtnMostrar.Enabled = False
        TxtFPago.Enabled = False : BtnImp.Enabled = True
        CboMon.Enabled = False : BtnCon1.Enabled = False : BtnCon2.Enabled = False
        Pan04.Enabled = False : TxtObs.Enabled = False : Dgv01.Rows.Clear()
        Dgv02.Rows.Clear() : Dgv03.Rows.Clear() : Pan12.Enabled = True
        Call Limpiar_Texto(Pan01) : Call Limpiar_Texto(Pan02)
        Call Limpiar_Texto(Pan04) : Call Limpiar_Texto(Pan11) 'totales
        BtnEstado.Text = "PENDIENTE"
        BtnEstado.BackColor = Drawing.Color.Maroon
        BtnNuevo.Enabled = True : BtnEditar.Enabled = True : BtnEliminar.Enabled = True : BtnGrabar.Enabled = False
        BtnCerrar.Text = "&Cerrar" : Dgv01.Enabled = False
        BtnBuscar.Enabled = True : BtnHistorial.Enabled = True : BtnAnexarDet.Enabled = True
        DtpFec_Emi.Enabled = False : DtpFec_Prdo.Enabled = False : DtpFec_Venci.Enabled = False
        BtnConTpoDoc.Enabled = False : Dgv02.AllowUserToDeleteRows = False
        Rdb01.Enabled = False : Rdb02.Enabled = False : CboDetrac.Enabled = False : BtnConLeasing.Enabled = True
        ChkImportacion.Enabled = False : TxtCod_Maq.Enabled = False : TxtCod_Maq.Clear()
        TxtPor_Igv.Enabled = False
    End Sub
    'Consultamos tipo de documento...
    Private Sub BtnConTpoDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConTpoDoc.Click
        FrmConTpoDoc.Show() : FrmConTpoDoc.MdiParent = FrmMenu
        FrmConTpoDoc.Cargar_Grid(" and c_anula_reg=0 order by c_desc_doc")
        FrmConTpoDoc.TxtVar.Text = 1
    End Sub

    Private Sub BtnCon2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon2.Click
        FrmConTpoPago.Show() : FrmConTpoPago.MdiParent = FrmMenu
        FrmConTpoPago.Cargar_Grid(" and c_anula_reg=0 order by c_desc_pago")
        FrmConTpoPago.TxtVar.Text = 1
    End Sub

    
    'CONSULTAMOS FORMAS DE PAGO PRESIONANDO LA TECLA F1...
    Private Sub TxtFPago_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtFPago.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon2.Enabled = True Then Call BtnCon2_Click(Nothing, Nothing)
    End Sub
    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        FrmConProve.Show() : FrmConProve.MdiParent = FrmMenu
        FrmConProve.Cargar_Grid(" and c_anula_reg=0 order by c_desc_prov")
        FrmConProve.TxtVar.Text = 3
    End Sub

    'mostramos los registros al presionar la tecla F1...
    Private Sub TxtProve_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProve.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon1.Enabled = True Then Call BtnCon1_Click(Nothing, Nothing)
    End Sub
    'cerramos registro...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            Call Aceptar_Ingreso() : Pan16.Enabled = True : ChkRetencion.Enabled = False
            If Val(TxtCod_Ing.Text) = 0 Then
                Call BtnFin_Click(Nothing, Nothing)
            Else
                Call Mostrar_IngComp(" and c_nro_ing=" & TxtCod_Ing.Text & "")
            End If
        End If
    End Sub
    'Metodo que nos permite validar que no se registre 2 veces un mismo numero de comprobante del mismo proveedor
    Private Sub Validar_Grabacion(ByVal x As TextBox)
        With c_Neg_IngComp.get_IngComp_Datos(" and I.c_anula_reg=0 and I.c_codi_prov='" & TxtCod_Prov.Text & "' and I.c_serie_doc='" & TxtSerie.Text & _
                                             "' and I.c_nro_doc='" & TxtNro_Doc.Text & "' and I.c_codi_doc='" & Strings.Right(BtnDoc.Text, 2) & "'", "DAT", FrmMenu.TxtCod_Emp.Text)

            If .Rows.Count > 0 Then
                If Val(TxtCod_Ing.Text) = 0 Then 'cuando grabamos no debe existir coincidencias...
                    If .Rows.Count > 0 Then
                        x.Text = 1
                    End If
                Else 'cuando editamos solo debe existir un registro...
                    If .Rows.Count > 1 Then
                        x.Text = 1
                    End If
                End If
            End If
        End With
    End Sub
    ' Funcion para validar datos '
    Private Function ValidarDatos() As Boolean
        '   If ChkRetencion.Checked = True And Val(TxtPorcReten.Text) > 0 Then
        If Len(TxtCod_Prov.Text) > 0 Then
            If Len(TxtCod_Fpago.Text) > 0 Then
                If Len(BtnDoc.Text) > 0 Then
                    If CboMon.SelectedIndex > -1 Then
                        If Len(TxtSerie.Text) > 0 Then
                            If Val(TxtNro_Doc.Text) > 0 Then
                                If Val(TxtTC.Text) > 0 Then
                                    If Val(TxtPor_Igv.Text) > 0 Then
                                        If Val(TxtTotal.Text) > 0 Then
                                            ValidarDatos = True
                                        Else
                                            MsgBox("1. documento no tiene montos...", MsgBoxStyle.Critical, Compañia)
                                            ValidarDatos = False
                                        End If
                                    Else
                                        MsgBox("2. Documento no tiene porcentaje de I.G.V....", MsgBoxStyle.Critical, Compañia)
                                        ValidarDatos = False
                                    End If
                                Else
                                    MsgBox("3. Falta ingresar el Tipo de cambio...", MsgBoxStyle.Critical, Compañia)
                                    ValidarDatos = False
                                End If
                            Else
                                MsgBox("4. Falta ingresar el número de documento...", MsgBoxStyle.Critical, Compañia)
                                ValidarDatos = False
                            End If
                        Else
                            MsgBox("5. Falta ingresar el número de serie...", MsgBoxStyle.Critical, Compañia)
                            ValidarDatos = False
                        End If
                    Else
                        MsgBox("6. Falta seleccionar el tipo de moneda...", MsgBoxStyle.Critical, Compañia)
                        ValidarDatos = False
                    End If
                Else
                    MsgBox("7. Falta seleccionar el tipo de documento...", MsgBoxStyle.Critical, Compañia)
                    ValidarDatos = False
                End If
            Else
                MsgBox("8. Falta seleccionar la forma de pago...", MsgBoxStyle.Critical, Compañia)
                ValidarDatos = False
            End If
        Else
            MsgBox("9. Falta seleccionar el proveedor...", MsgBoxStyle.Critical, Compañia)
            ValidarDatos = False
        End If
        'Else
        ' MsgBox("10. Falta ingresar un porcentaje válido para la retención...", MsgBoxStyle.Critical, Compañia)
        ' ValidarDatos = False
        'End If
    End Function
    ' metodo para validar guias '
    Private Function ValidarGuias() As Boolean
        With Dgv01
            Dim TotGuiaSelect As Decimal = 0
            If Val(TxtOpc_Apertura.Text) = 0 Then
                For i = 0 To .RowCount - 1
                    If .Rows(i).Cells("Check").Value = True Then
                        TotGuiaSelect = TotGuiaSelect + 1
                    End If
                Next
                If TotGuiaSelect = 0 Then
                    ValidarGuias = False
                    MsgBox("1. Falta seleccionar una Guía de Remisión", vbCritical, Compañia)
                Else
                    ValidarGuias = True
                End If
            Else
                ValidarGuias = True
            End If
        End With
    End Function
    'Grabamos nuevo registro...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarIGV(Val(TxtPor_Igv.Text)) = True Then
            If ValidarCierre(DtpFec_Prdo.Text) = True Then
                If ValidarDatos() = True Then
                    If ValidarGuias() = True Then
                        ' Validamos si se ingresa un comprobante pago si leasing '
                        If Strings.Right(BtnDoc.Text, 2) = "07" And Val(TxtNro_Leasing.Text) = 0 Then MsgBox("Revisar si este documento lleva N° de Leasing", vbExclamation, Compañia)
                        Dim x As New TextBox
                        Call Validar_Grabacion(x)
                        If Val(x.Text) = 0 Then
                            Call Validar_Fecha_Cierre(x, DtpFec_Prdo.Text)
                            If Val(x.Text) = 0 Then
                                Dim f As String = MsgBox("¿Desea grabar el registro...?", vbYesNo + MsgBoxStyle.Question, Compañia)
                                If f = vbYes Then
                                    Call TxtSerie_LostFocus(Nothing, Nothing)
                                    Call TxtNro_Doc_LostFocus(Nothing, Nothing)
                                    ' Grabamos Cabececera '
                                    Call Grabar_IngComp("ADD")
                                    ' Grabamos Ordenes y Guias x Ingreso '
                                    With Dgv01
                                        If .RowCount > 0 Then
                                            For i = 0 To .RowCount - 1
                                                If .Rows(i).Cells("Check").Value = True Then
                                                    Call Grabar_Ingresos_OC(i, "ADD")
                                                End If
                                            Next
                                        End If
                                    End With
                                    ' Grabamos Detalles del Ingreso '
                                    With Dgv02
                                        If .RowCount > 0 Then
                                            For i = 0 To .RowCount - 1
                                                Call Grabar_Detalles(i, "ADD")
                                            Next
                                        End If
                                    End With
                                    MsgBox("Registro se Grabo Correctamente...", vbExclamation, Compañia)
                                    If Val(TxtCod_Ing.Text) = 0 Then
                                        Call BtnFin_Click(Nothing, Nothing)
                                    Else
                                        Call Mostrar_IngComp(" and c_nro_ing=" & TxtCod_Ing.Text & "")
                                    End If
                                    Pan16.Enabled = True : ChkRetencion.Enabled = False
                                End If
                            Else
                                MsgBox("11. Fecha no valida, mes se encuentra cerrado", MsgBoxStyle.Critical, Compañia)
                            End If
                        Else
                            MsgBox("10. Número de documento ya fue ingresado anteriormente, revisar...", MsgBoxStyle.Critical, Compañia)
                        End If
                    End If
                End If
            End If
        End If

    End Sub
    'Grabamos ingreso de comprobantes...
    Private Sub Grabar_IngComp(ByVal cOpcion As String)
        Dim c_opc_detracc As Integer = 0 : Dim c_opc_reten As Integer = 0 : Dim c_opc_detraccion As Integer = 0
        With c_Ent_IngComp
            .c_nro_ing = TxtCod_Ing.Text
            ' Validamos de Detraccion '
            If Rdb01.Checked = True Then c_opc_detracc = 1
            If Rdb02.Checked = True Then c_opc_detracc = 0
            ' Validamos si es por importacion '
            If ChkImportacion.Checked = True Then c_opc_detraccion = 1
            ' Validamos la Retencion '
            If ChkRetencion.Checked = True Then c_opc_reten = 1

            .c_codi_mon = CboMon.SelectedValue
            .c_codi_doc = Strings.Right(BtnDoc.Text, 2)
            .c_serie_doc = TxtSerie.Text
            .c_nro_doc = TxtNro_Doc.Text
            .c_nro_maq = TxtCod_Maq.Text
            .c_fecha_emi = DtpFec_Emi.Text
            .c_fecha_prd = DtpFec_Prdo.Text
            .c_fecha_venci = DtpFec_Venci.Text
            .c_nro_dias = Val(TxtDias.Text)
            .c_codi_prov = TxtCod_Prov.Text
            .c_codi_pago = TxtCod_Fpago.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .c_obs = TxtObs.Text
            .c_tpo_cambio = Val(TxtTC.Text)
            .c_cant_igv = Val(TxtPor_Igv.Text)
            .c_imp_inaf = Val(TxtInaf.Text)
            .c_imp_igv = Val(TxtImp_Igv.Text)
            .c_imp_afecto = Val(TxtAfecto.Text)
            .c_imp_total = Val(TxtTotal.Text)
            .c_mt_anula = ""
            ' Detracciones '
            .c_opc_detracc = c_opc_detracc
            .c_codi_detracc = CboDetrac.Text
            .c_porc_detracc = Val(TxtPorcDetrac.Text)
            .c_imp_detracc = Val(TxtMonto_Detrac.Text)
            ' Retenciones '
            .c_opc_reten = c_opc_reten
            .c_porc_reten = Val(TxtPorcReten.Text)
            .c_base_reten = Val(TxtTotal.Text) - Val(TxtMonto_Reten.Text)
            .c_imp_reten = Val(TxtMonto_Reten.Text)
            .c_nro_leasing = TxtNro_Leasing.Text
            .c_nro_cuota = Val(TxtNro_Cuota.Text)
            .c_correl_leasing = TxtCorrel_Leasing.Text
            .c_opc_apertura = Val(TxtOpc_Apertura.Text)
            .c_opc_importacion = c_opc_detraccion
            .copcion = cOpcion
            'Validamos si se graba o modifica...'
            If Val(TxtCod_Ing.Text) = 0 Then
                TxtCod_Ing.Text = c_Neg_IngComp.set_IngComp_Save(c_Ent_IngComp, FrmMenu.TxtCod_Emp.Text)
            Else
                c_Neg_IngComp.set_IngComp_Save(c_Ent_IngComp, FrmMenu.TxtCod_Emp.Text)
            End If
        End With
    End Sub
    ' Metodo para Grabar el Detalle del Ingreso de Comprobante '
    Private Sub Grabar_Ingresos_OC(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_IngCompOC
            .c_nro_correl = Dgv01.Rows(Fila).Cells("c_nro_correl").Value
            .c_nro_ing = TxtCod_Ing.Text
            .c_serie_oc = RTrim(Strings.Left(Dgv01.Rows(Fila).Cells("Doc").Value, 4))
            .c_nro_oc = Strings.Right(Dgv01.Rows(Fila).Cells("Doc").Value, 7)
            .c_tpo_doc = Dgv01.Rows(Fila).Cells("tpo").Value
            .c_codi_ing = Dgv01.Rows(Fila).Cells("c_codi_ing").Value
            .c_imp_total = Val(Dgv01.Rows(Fila).Cells("Total").Value)
            .c_fecha_emi = Dgv01.Rows(Fila).Cells("Fecha").Value
            .copcion = cOpcion
            c_Neg_IngComp.set_IngCompOC_Save(c_Ent_IngCompOC, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub
    ' Metodo para grabar las guias por ingreso '
    Private Sub Grabar_Detalles(ByVal Fila As Integer, ByVal cOpcion As String)
        'Grabamos el detalle de la factura...
        With c_Ent_ingCompDet
            .c_nro_correl = Dgv02.Rows(Fila).Cells("item").Value
            .c_correl_ing = Dgv02.Rows(Fila).Cells("c_correl_ing").Value
            .c_nro_ing = TxtCod_Ing.Text
            .c_nro_oc = Strings.Left(Dgv02.Rows(Fila).Cells("c_nro_oc").Value, 3) & Strings.Right(Dgv02.Rows(Fila).Cells("c_nro_oc").Value, 7)
            .c_codi_prov = TxtCod_Prov.Text
            .c_codi_doc = Dgv02.Rows(Fila).Cells("c_codi_doc").Value
            .c_codi_tg = Dgv02.Rows(Fila).Cells("Tg").Value
            .c_codi_cd = Dgv02.Rows(Fila).Cells("Cd").Value
            .c_codi_scd = Dgv02.Rows(Fila).Cells("Scd").Value
            .c_nro_cant = Dgv02.Rows(Fila).Cells("cant").Value
            .c_codi_unimed = Dgv02.Rows(Fila).Cells("Codi_Unimed").Value
            .c_prec_unit = Dgv02.Rows(Fila).Cells("Precio").Value
            .c_imp_total = Dgv02.Rows(Fila).Cells("Importe").Value
            .c_opt_igv = Dgv02.Rows(Fila).Cells("Igv").Value
            .c_obs = ""
            .copcion = cOpcion
            ' Validamos si se ingresa como nuevo '
            If Val(Dgv02.Rows(Fila).Cells("Item").Value) = 0 Then
                Dgv02.Rows(Fila).Cells("Item").Value = c_Neg_IngCompDet.set_IngCompDet_Save(c_Ent_ingCompDet, FrmMenu.TxtCod_Emp.Text)
            Else
                c_Neg_IngCompDet.set_IngCompDet_Save(c_Ent_ingCompDet, FrmMenu.TxtCod_Emp.Text)
            End If
        End With
    End Sub
    Private Sub DtpFec_Emi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Emi.ValueChanged
        Call Buscar_TC_IGV()
        DtpFec_Prdo.Text = DtpFec_Emi.Text
    End Sub
    Private Sub TxtSerie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSerie.LostFocus
         If Len(TxtSerie.Text) > 0 Then
            If IsNumeric(TxtSerie.Text) = True Then
                TxtSerie.Text = Strings.Right(Val(TxtSerie.Text) + 1000, 3)
            Else

            End If
        End If
    End Sub

    Private Sub TxtNro_Doc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNro_Doc.KeyPress
        e.KeyChar = e.KeyChar.ToString.ToUpper
    End Sub
    Private Sub TxtNro_Doc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNro_Doc.LostFocus
        If Len(TxtNro_Doc.Text) > 0 Then
            If Strings.Right(BtnDoc.Text, 2) = "05" Then

            Else
                If IsNumeric(TxtNro_Doc.Text) = True Then
                    TxtNro_Doc.Text = Strings.Right(Val(TxtNro_Doc.Text) + 10000000, 7)
                Else

                End If
            End If
        End If
    End Sub

    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_IngComp(" and I.c_nro_ing=(select max(c_nro_ing) from scom_Fa_ingcomp) ")
        TxtBus_Ing.Text = TxtCod_Ing.Text
    End Sub
    Public Sub Mostrar_IngComp(ByVal Cadena As String)
        With c_Neg_IngComp.get_IngComp_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
            'mostramos los datos del ingreso de compras...
            Call cancela_registro()
            If .Rows.Count > 0 Then
                TxtCod_Ing.Text = .Rows(0)("c_nro_ing").ToString
                TxtCod_Prov.Text = .Rows(0)("c_codi_prov").ToString
                TxtCod_Fpago.Text = .Rows(0)("c_codi_pago").ToString
                TxtProve.Text = .Rows(0)("c_desc_prov").ToString
                TxtFPago.Text = .Rows(0)("c_desc_pago").ToString
                TxtSerie.Text = .Rows(0)("c_serie_doc").ToString
                TxtNro_Doc.Text = .Rows(0)("c_nro_doc").ToString
                TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                TxtDias.Text = .Rows(0)("c_nro_dias").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                TxtPor_Igv.Text = .Rows(0)("c_cant_igv").ToString
                TxtCod_Maq.Text = .Rows(0)("c_nro_maq").ToString
                DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                DtpFec_Prdo.Text = .Rows(0)("c_fecha_prd").ToString
                DtpFec_Venci.Text = .Rows(0)("c_fecha_venci").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                ' Mostramos leasing '
                TxtNro_Leasing.Text = .Rows(0)("c_nro_leasing").ToString
                TxtNro_Cuota.Text = Val(.Rows(0)("c_nro_cuota").ToString)
                TxtCorrel_Leasing.Text = .Rows(0)("c_correl_leasing").ToString

                ' Mostramos Detracciones '
                If Val(.Rows(0)("c_opc_detracc").ToString) = 1 Then
                    Rdb01.Checked = True
                Else
                    Rdb02.Checked = True
                End If
                If Val(.Rows(0)("c_opc_reten").ToString) = 1 Then
                    ChkRetencion.Checked = True
                Else
                    ChkRetencion.Checked = False
                End If

                ' Validamos si es para importacion '
                If Val(.Rows(0)("c_opc_importacion").ToString) = 0 Then
                    ChkImportacion.Checked = False
                Else
                    ChkImportacion.Checked = True
                End If
                ' Validamos el asiento de apertura '
                If Val(TxtOpc_Apertura.Text) = 0 Then
                    Me.Text = "Ingreso de Compras"
                Else
                    Me.Text = "Ingreso de Compras - [DOCUMENTO DE APERTURA]"
                End If
                '--->Validamos si registro se encuentra anulado..<---'
                If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                    If Val(.Rows(0)("c_cancel_ing").ToString) = 1 Then
                        BtnEstado.Text = "CANCELADO" : BtnEstado.BackColor = Drawing.Color.Blue : BtnEstado.ForeColor = Color.White
                    Else
                        If Val(.Rows(0)("c_cancel_ing").ToString) = 2 Then
                            BtnEstado.Text = "AMORTIZADO" : BtnEstado.BackColor = Drawing.Color.MediumTurquoise : BtnEstado.ForeColor = Color.White
                        Else
                            BtnEstado.Text = "PENDIENTE" : BtnEstado.BackColor = Drawing.Color.Maroon : BtnEstado.ForeColor = Color.White
                        End If
                    End If
                Else
                    BtnEstado.Text = "ANULADO"
                    BtnEstado.BackColor = Drawing.Color.Red : BtnEstado.ForeColor = Color.White
                End If
                CboMon.SelectedValue = .Rows(0)("c_codi_mon").ToString

                BtnDoc.Text = .Rows(0)("c_desc_doc").ToString & " " & .Rows(0)("c_codi_doc").ToString
                'mostramos las ordenes de compras amarradas a la factura..
                With c_Neg_IngComp.get_IngComp_DatosOC(" and O.c_nro_ing='" & TxtCod_Ing.Text & "' order by O.c_serie_oc,O.c_nro_oc", "DAT", FrmMenu.TxtCod_Emp.Text)
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dgv01.Rows.Add()
                            Dgv01.Rows(i).Cells("check").Value = True
                            Dgv01.Rows(i).Cells("c_nro_correl").Value = .Rows(i)("c_nro_correl").ToString
                            Dgv01.Rows(i).Cells("tpo").Value = .Rows(i)("c_tpo_ing").ToString
                            Dgv01.Rows(i).Cells("c_codi_ing").Value = .Rows(i)("c_codi_ing").ToString
                            Dgv01.Rows(i).Cells("doc").Value = .Rows(i)("c_serie_oc").ToString & " " & .Rows(i)("c_nro_oc").ToString
                            Dgv01.Rows(i).Cells("total").Value = .Rows(i)("c_imp_total").ToString
                            Dgv01.Rows(i).Cells("fecha").Value = .Rows(i)("c_fecha_emi").ToString
                            'Validamos si documento amarrado es por guia de remision...
                            If .Rows(i)("c_tpo_ing").ToString = "GR" Then
                                With c_Neg_IngAlmIQ.get_IngAlmIQ_Datos(" and I.c_codi_prov='" & TxtCod_Prov.Text & "' and c_serie_guia='" & .Rows(i)("c_serie_oc").ToString & _
                                                                   "' and c_nro_guia='" & .Rows(i)("c_nro_oc").ToString & "' ", FrmMenu.TxtCod_Emp.Text, "DAT")
                                    If .Rows.Count > 0 Then
                                        Dgv01.Rows(i).Cells("nro_oc").Value = .Rows(0)("c_serie_oc").ToString & " " & .Rows(0)("c_nro_oc").ToString
                                    End If
                                End With
                            End If
                        Next
                    End If
                End With
                '--------------------------------------------------------------------------------------------------------------------------------------------'
                ' Mostramos detalles '
                With c_Neg_IngCompDet.get_IngCompDet_Datos(" and D.c_nro_ing='" & TxtCod_Ing.Text & "' order by c_nro_oc", "DAT", FrmMenu.TxtCod_Emp.Text)
                    Dgv02.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dgv02.Rows.Add()
                            Dgv02.Rows(i).Cells("Item").Value = .Rows(i)("c_nro_correl").ToString
                            Dgv02.Rows(i).Cells("c_nro_oc").Value = .Rows(i)("c_nro_oc").ToString
                            Dgv02.Rows(i).Cells("tg").Value = .Rows(i)("c_codi_tg").ToString
                            Dgv02.Rows(i).Cells("cd").Value = .Rows(i)("c_codi_cd").ToString
                            Dgv02.Rows(i).Cells("scd").Value = .Rows(i)("c_codi_scd").ToString
                            Dgv02.Rows(i).Cells("Cant").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), Forma_1_4)
                            Dgv02.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                            Dgv02.Rows(i).Cells("codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                            Dgv02.Rows(i).Cells("descripcion").Value = .Rows(i)("c_desc_scd").ToString
                            Dgv02.Rows(i).Cells("precio").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_3)
                            Dgv02.Rows(i).Cells("importe").Value = Format(Val(.Rows(i)("c_imp_total").ToString), Forma_1_2)
                            Dgv02.Rows(i).Cells("igv").Value = .Rows(i)("c_opt_igv").ToString
                            Dgv02.Rows(i).Cells("c_codi_doc").Value = .Rows(i)("c_codi_doc").ToString
                            Dgv02.Rows(i).Cells("c_correl_ing").Value = .Rows(i)("c_correl_ing").ToString
                        Next
                    End If
                End With
                '--------------------------------------------------------------------------------------------------------------------------------------------'
                'mostramos el total
                Call Calcular_Totales()
                TxtInaf.Text = .Rows(0)("c_imp_inaf").ToString
                TxtAfecto.Text = .Rows(0)("c_imp_afecto").ToString
                TxtImp_Igv.Text = .Rows(0)("c_imp_igv").ToString
                TxtTotal.Text = .Rows(0)("c_imp_total").ToString
                TxtInaf.Text = .Rows(0)("c_imp_inaf").ToString
                TxtTC.Text = .Rows(0)("c_tpo_cambio").ToString
                ' detraccion '
                CboDetrac.SelectedValue = .Rows(0)("c_codi_detracc").ToString
                TxtPorcDetrac.Text = Format(Val(.Rows(0)("c_porc_detracc").ToString), "##0")
                TxtMonto_Detrac.Text = Format(Val(.Rows(0)("c_imp_detracc").ToString), Forma_1_2)
                TxtPorcReten.Text = Format(Val(.Rows(0)("c_porc_reten").ToString), "##0")
                TxtMonto_Reten.Text = Format(Val(.Rows(0)("c_imp_reten").ToString), Forma_1_2)
                TxtOpc_Apertura.Text = Val(.Rows(0)("c_opc_apertura").ToString)
            End If
        End With
    End Sub

    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_IngComp(" and I.c_nro_ing=(select min(c_nro_ing) from scom_" & FrmMenu.TxtCod_Emp.Text & "_ingcomp) ")
        TxtBus_Ing.Text = TxtCod_Ing.Text
    End Sub

    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBus_Ing.Text) > 1 Then
            TxtBus_Ing.Text = Strings.Right((Val(TxtBus_Ing.Text) - 1) + 10000000, 7)
            Call Mostrar_IngComp(" and I.c_nro_ing='" & TxtBus_Ing.Text & "'")
        End If
    End Sub

    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBus_Ing.Text) > 0 Then
            TxtBus_Ing.Text = Strings.Right(Val(TxtBus_Ing.Text) + 10000001, 7)
            Call Mostrar_IngComp(" and I.c_nro_ing='" & TxtBus_Ing.Text & "'")
        End If
    End Sub
    'buscamos al presionar la tecla enter...
    Private Sub TxtBus_Ing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Ing.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_Ing.Text) > 0 Then
                TxtBus_Ing.Text = Strings.Right(Val(TxtBus_Ing.Text) + 10000000, 7)
                Call Mostrar_IngComp(" and c_nro_ing='" & TxtBus_Ing.Text & "'")
            End If
        End If
    End Sub

    Private Sub TxtBus_Ing_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Ing.TextChanged

    End Sub
    ' Metodo para cargar Guias '
    Public Sub Cargar_Ordenes()
        If BtnMostrar.Enabled = True Then Call BtnMostrar_Click(Nothing, Nothing)
    End Sub
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If ValidarCierre(DtpFec_Prdo.Text) = True Then
            If UCase(BtnEstado.Text) = "PENDIENTE" Then
                If Len(TxtCod_Ing.Text) > 0 Then
                    Call Nuevo_Registro() : BtnCon1.Enabled = False : CboMon.Enabled = False : BtnMostrar.Enabled = True
                    TxtCod_Maq.Enabled = True
                Else
                    MsgBox("Registro no puede ser modificado...", MsgBoxStyle.Critical, Compañia)
                End If
            Else
                MsgBox("Registro se encuentra Cerrado o esta anulado, no podra realizar ninguna modificación", MsgBoxStyle.Critical, Compañia)
            End If
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If ValidarCierre(DtpFec_Prdo.Text) = True Then
            If Val(TxtCod_Ing.Text) > 0 Then
                If UCase(BtnEstado.Text) = "PENDIENTE" Then
                    Dim f As String = MsgBox("¿Confirmar la eliminación del registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical, Compañia)
                    If f = vbYes Then
                        ' Grabamos Cabececera '
                        Call Grabar_IngComp("DEL")
                        ' Grabamos Ordenes y Guias x Ingreso '
                        With Dgv01
                            If .RowCount > 0 Then
                                For i = 0 To .RowCount - 1
                                    If .Rows(i).Cells("Check").Value = True Then
                                        Call Grabar_Ingresos_OC(i, "DEL")
                                    End If
                                Next
                            End If
                        End With
                        BtnEstado.BackColor = Drawing.Color.Red : BtnEstado.Text = "ANULADO"
                        MsgBox("Registro fue eliminado correctamente...", MsgBoxStyle.Exclamation, Compañia)
                    End If
                Else
                    MsgBox("Registro no puede ser Eliminado...", vbCritical, Compañia)
                End If
            End If
        End If
    End Sub
    Private Sub TxtCant_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCant.TextChanged
        TxtImporte.Text = Format(Val(TxtCant.Text) * Val(TxtPrec.Text), Forma_1_2)
    End Sub
    'mostramos datos al dar doble clic
    Private Sub TxtPrec_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtPrec.KeyDown
        If e.KeyCode = Keys.Enter Then
            With Dgv02
                If .RowCount > 0 Then
                    Dim fila As Integer = .CurrentCellAddress.Y
                    If fila > -1 Then
                        .Rows(fila).Cells("Cant").Value = Format(Val(TxtCant.Text), Forma_1_2)
                        .Rows(fila).Cells("Precio").Value = Format(Val(TxtPrec.Text), Forma_1_2)
                        .Rows(fila).Cells("Importe").Value = Format(Val(TxtImporte.Text), Forma_1_2)
                        Call Aceptar_Ingreso()
                        Call Calcular_Totales()
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub TxtPrec_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPrec.TextChanged
        TxtImporte.Text = Format(Val(TxtCant.Text) * Val(TxtPrec.Text), Forma_1_2)
    End Sub
    'mostramos datos al dar doble click...
    Private Sub Dgv02_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv02.DoubleClick
        With Dgv02
            Call Limpiar_Texto(Pan13)
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then 'Validamos  si estamos en navegación o edicion
                    If BtnEditar.Enabled = False Then
                        .Enabled = False : Call Modificar_Ingreso()
                        TxtCant.Text = .Rows(fila).Cells("Cant").Value : TxtDesc.Text = .Rows(fila).Cells("Descripcion").Value
                        TxtUnid.Text = .Rows(fila).Cells("Unid").Value : TxtPrec.Text = .Rows(fila).Cells("Precio").Value
                        TxtImporte.Text = .Rows(fila).Cells("importe").Value
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub Modificar_Ingreso()
        With Dgv02
            .Location = New Point(298, 264)
            .Size = New Size(497, 154)
        End With
        Pan13.Visible = True
        TxtCant.Focus()
    End Sub
    Private Sub Aceptar_Ingreso()
        With Dgv02
            .Location = New Point(298, 238)
            .Size = New Size(497, 180)
            .Enabled = True
        End With
        Pan13.Visible = False
    End Sub

    Private Sub Dgv02_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgv02.KeyDown
        If e.KeyCode = Keys.Delete Then
            Call Calcular_Totales()
        End If
    End Sub

    Private Sub Dgv02_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv02.SelectionChanged
        Call Calcular_Totales()
    End Sub

    Private Sub BtnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBuscar.Click
        With FrmIngCompBus
            .Show() : .MdiParent = FrmMenu : .TxtVar1.Text = 1
        End With

    End Sub
    Public Sub Mostrar_Ingreso()
        Call Mostrar_IngComp(" and I.c_nro_ing='" & TxtBus_Ing.Text & "'")
    End Sub
    ' Metodo para validar el ingreso por detraccion o retenciones '
    Private Sub Validar_Detraccion_Retencion()
        If ChkRetencion.Checked = True Then
            TxtPorcReten.Text = Format(Val(FrmMenu.TxtRetencion.Text), "##")
            TxtPorcReten.Enabled = True
            Rdb02.Checked = True : Call Limpiar_Texto(Pan15)
            On Error Resume Next
            CboDetrac.SelectedValue = ""
            CboDetrac.Enabled = False : ChkRetencion.Focus()
        Else
            Call Limpiar_Texto(Pan14) : Call Limpiar_Texto(Pan15)
            If Rdb01.Checked = True Then
                CboDetrac.Enabled = True
            Else
                CboDetrac.Enabled = False : CboDetrac.SelectedValue = ""
            End If
        End If
        Call Calcular_Retencion_Detraccion()
    End Sub
    ' Metodo para calcular retenciones y detracciones '
    Private Sub Calcular_Retencion_Detraccion()
        If ChkRetencion.Checked = True Then
            TxtMonto_Reten.Text = Format(Val(TxtTotal.Text) * (Val(TxtPorcReten.Text) / 100), Forma_1_2)
        Else
            If Rdb01.Checked = True Then
                TxtMonto_Detrac.Text = Format(Val(TxtTotal.Text) * (Val(TxtPorcDetrac.Text) / 100), Forma_1_2)
            End If
        End If
    End Sub
    Private Sub TxtDetrac_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPorcDetrac.KeyPress
        Call solonumeros(e)
    End Sub


    Private Sub TxtInaf_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtInaf.TextChanged
        TxtTotal.Text = Format(Val(TxtInaf.Text) + Val(TxtAfecto.Text) + Val(TxtImp_Igv.Text), Forma_1_2)
    End Sub
    'Imprimir Detraccion...
    Private Sub BtnImp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImp.Click
        'c_Neg_DetracDet.get_DetracDet_Rpt(" And I.c_nro_ing='" & TxtCod_Ing.Text & "'", "RPT", FrmMenu.TxtCod_Emp.Text)
        'FrmReportes.Impresion_Detraccion()
    End Sub

    Private Sub ChkRetencion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkRetencion.CheckedChanged
        Call Validar_Detraccion_Retencion()
    End Sub

    Private Sub CboMon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMon.SelectedIndexChanged

    End Sub

    Private Sub Rdb01_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb01.CheckedChanged
        Call Validar_Detraccion_Retencion()
    End Sub

    Private Sub CboDetrac_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDetrac.SelectedIndexChanged
        ' Evitar ejecución si aún no hay datos correctos
        If CboDetrac.SelectedValue Is Nothing OrElse TypeOf CboDetrac.SelectedValue Is DataRowView Then
            Exit Sub
        End If

        Dim valor As String = CboDetrac.SelectedValue.ToString()

        With c_Neg_MnTblDetraccion.get_MntblDetraccion_Datos(" And c_codi_detracc='" & valor & "' ", "DAT")
            TxtPorcDetrac.Text = "0"
            If .Rows.Count > 0 Then
                TxtPorcDetrac.Text = Format(Val(.Rows(0)("c_porc_detracc").ToString()), "##")
                Call Calcular_Retencion_Detraccion()
            End If
        End With
    End Sub


    Private Sub Rdb02_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rdb02.CheckedChanged
        Call Validar_Detraccion_Retencion()
    End Sub
    ' Listado de cuotas '
    Private Sub BtnConLeasing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConLeasing.Click
        With FrmConLeasingCoutas
            .MdiParent = FrmMenu : .Show() : .TxtVar.Text = 1 : .TxtCod_Prove.Text = TxtCod_Prov.Text : .TxtCod_Mon.Text = CboMon.SelectedValue
            ' solo consultamos leasing '
            .Cargar_Grid(" and C.c_codi_doc in('13','15','17') and D.c_anula_Reg=0 and C.c_anula_reg=0 and C.c_codi_prov='" & TxtCod_Prov.Text & _
                "' and D.c_opc_Cancel=0 and D.c_opc_doc=0 and C.c_codi_mon='" & CboMon.SelectedValue & "' order by C.c_nro_operacion, D.c_nro_cuota")
        End With
    End Sub

    Private Sub BtnEstado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEstado.Click
        If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
            FrmConHistoCancel.MdiParent = FrmMenu : FrmConHistoCancel.Show()
            FrmConHistoCancel.Cargar_Grid(" and P.c_Serie_doc='" & TxtSerie.Text & "' and P.c_nro_doc='" & TxtNro_Doc.Text & _
                                          "' and P.c_codi_mon='" & CboMon.SelectedValue & "' and P.c_codi_prov='" & TxtCod_Prov.Text & _
                                          "' and P.c_codi_doc='" & Strings.Right(BtnDoc.Text, 2) & "' order by P.c_fecha_pago", "ING")
        Else
            MsgBox("No se registran pagos a cuenta...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub TxtSerie_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtSerie.TextChanged

    End Sub

    Private Sub TxtNro_Doc_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtNro_Doc.TextChanged

    End Sub
    ' historial de cancelación '
    Private Sub BtnHistorial_Click(sender As System.Object, e As System.EventArgs) Handles BtnHistorial.Click
        If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
            FrmConHistoCancel.MdiParent = FrmMenu : FrmConHistoCancel.Show()
            FrmConHistoCancel.Cargar_Grid(" and P.c_Serie_doc='" & TxtSerie.Text & "' and P.c_nro_doc='" & TxtNro_Doc.Text & _
                                          "' and P.c_codi_mon='" & CboMon.SelectedValue & "' and P.c_codi_prov='" & TxtCod_Prov.Text & _
                                          "' and P.c_codi_doc='" & Strings.Right(BtnDoc.Text, 2) & "' order by P.c_fecha_pago", "ANE")
        Else
            MsgBox("No se registran pagos a cuenta...", vbCritical, Compañia)
        End If
    End Sub
    ' Anexamos detracciones '
    Private Sub BtnAnexarDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAnexarDet.Click
        If Rdb01.Checked = True Then
            With FrmDetracAnexas
                .MdiParent = FrmMenu : .Show() : .TxtCod_Prove.Text = TxtCod_Prov.Text
                .Detracciones_Anexadas(TxtCod_Ing.Text)
            End With
        Else
            MsgBox("Documento no esta afecto a detracción no podra anexar Constancia, editar y modificar...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub TxtPorcReten_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPorcReten.TextChanged
        Call Calcular_Retencion_Detraccion()
    End Sub

    Private Sub DtpFec_Prdo_ValueChanged(sender As Object, e As EventArgs) Handles DtpFec_Prdo.ValueChanged

    End Sub

    Private Sub TxtPor_Igv_TextChanged(sender As Object, e As EventArgs) Handles TxtPor_Igv.TextChanged
        If TxtPor_Igv.Enabled = True Then
            Call Calcular_Totales()
            Call Calcular_Retencion_Detraccion()
        End If
    End Sub
End Class