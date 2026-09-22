Public Class FrmIngNC
    Dim Focos As Integer = 0 : Dim sw As Integer = 0
    Private Sub FrmIngNC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
    End Sub

    Private Sub FrmIngNC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmIngNC_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_codi_mon", CboMon)
        Call BtnFin_Click(Nothing, Nothing)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
    End Sub
    Private Sub BtnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon1.Click
        FrmConProve.Show() : FrmConProve.MdiParent = FrmMenu
        FrmConProve.Cargar_Grid(" and c_anula_reg=0 AND c_desc_prov like '%" & TxtProve.Text & "%' order by c_desc_prov")
        FrmConProve.TxtVar.Text = 4
    End Sub
    'metodo que nos permite mostrar los documentos de fact
    Public Sub Mostrar_documentos()
        Dim Moneda As String = ""
        If CboMon.SelectedIndex = 0 Then Moneda = "01"
        If CboMon.SelectedIndex = 1 Then Moneda = "02"
        'buscamos por el tipo de moneda y solo los documentos perteneciente al proveedor y que tenga un saldo por factura...
        With c_Neg_IngComp.get_IngComp_Datos(" and I.c_anula_reg=0 and I.c_imp_saldo>0 and I.c_codi_prov='" & TxtCod_Prov.Text & "' and I.c_codi_mon='" & Moneda & "'", _
                                             "DAT", FrmMenu.TxtCod_Emp.Text)
            Dgv01.Rows.Clear()
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    Dgv01.Rows.Add()
                    Dgv01.Rows(i).Cells("check").Value = False
                    Dgv01.Rows(i).Cells("tpo").Value = .Rows(i)("c_desc_doc").ToString
                    Dgv01.Rows(i).Cells("doc").Value = .Rows(i)("c_serie_doc").ToString & " " & .Rows(i)("c_nro_doc").ToString
                    Dgv01.Rows(i).Cells("total").Value = .Rows(i)("c_imp_saldo").ToString
                    Dgv01.Rows(i).Cells("saldo").Value = .Rows(i)("c_imp_saldo").ToString
                    Dgv01.Rows(i).Cells("codigo").Value = .Rows(i)("c_nro_ing").ToString
                Next
            End If
        End With
    End Sub
    ' Nuevo de Registro '
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Limpiar_Texto(Pan02) : Call Limpiar_Texto(Pan03) : Call Limpiar_Texto(Pan04) : Call Limpiar_Texto(Pan05)
        DtpFec_Emi.Text = Date.Now : DtpFec_Prd.Text = Date.Now
        TxtProve.Enabled = False : CboMon.Enabled = True
        BtnCon1.Enabled = True : CboMon.SelectedIndex = -1
        CboMon.Focus() : CboMon.Select() : Dgv01.Rows.Clear()
        Dgv01.Enabled = True : Call Nuevo_Registro() : TxtObs.Clear() : BtnEstado.Visible = False
        ChkAfectoIGV.Checked = False : ChkAfectoIGV.Enabled = True
        sw = 0
    End Sub
    Private Sub Nuevo_Registro()
        TxtBus_Ing.Clear() : BtnGrabar.Enabled = True : BtnEditar.Enabled = False
        BtnNuevo.Enabled = False : BtnEliminar.Enabled = False : BtnCerrar.Text = "&Cancelar"
        TxtObs.Enabled = True : DtpFec_Emi.Enabled = True : DtpFec_Prd.Enabled = True
        Pan04.Enabled = True : Pan06.Enabled = False : Pan07.Enabled = False : Pan01.Enabled = False
    End Sub
    Private Sub Cancela_Registro()
        Call Limpiar_Texto(Pan02) : Call Limpiar_Texto(Pan03) : Call Limpiar_Texto(Pan04) : Call Limpiar_Texto(Pan05)
        CboMon.Enabled = False : TxtBus_Ing.Clear() : BtnGrabar.Enabled = False : BtnEditar.Enabled = True
        BtnNuevo.Enabled = True : BtnEliminar.Enabled = True : BtnCerrar.Text = "&Cerrar" : Dgv01.Rows.Clear()
        DtpFec_Emi.Enabled = False : DtpFec_Prd.Enabled = False : Pan04.Enabled = False : Pan06.Enabled = True : Pan07.Enabled = True
        BtnCon1.Enabled = False
    End Sub
    'editamos registro...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If ValidarCierre(DtpFec_Prd.Text) = True Then
            If Val(TxtCod_Ing.Text) > 0 Then 'validamos que exista un registro activo
                If BtnEstado.Visible = False Then
                    BtnCon1.Enabled = False
                    DtpFec_Prd.Focus() : CboMon.Enabled = False
                    CboMon.Enabled = False : Dgv01.Enabled = False
                    Call Nuevo_Registro() : sw = 1
                Else
                    MsgBox("Registro se encuentra anulado, no podra realizar ninguna modificación", MsgBoxStyle.Critical, Compañia)
                End If
            End If
        End If
    End Sub

    Private Sub TxtProve_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProve.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon1.Enabled = True Then Call BtnCon1_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtProve_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProve.TextChanged

    End Sub

    Private Sub DtpFec_Emi_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DtpFec_Emi.KeyDown
        If e.KeyCode = Keys.Enter Then
            Focos = 1 : TxtObs.Focus()
        End If
    End Sub

    Private Sub DtpFec_Emi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Emi.ValueChanged
        Call Buscar_TC_IGV()
    End Sub
    Private Sub Buscar_TC_IGV()
        'hallamos el porcentaje de igv...
        With c_Neg_Igv.get_Igv_Datos(" and c_fecha_emi<='" & DtpFec_Emi.Text & "' order by c_fecha_emi desc", "DAT")
            TxtPor_Igv.Clear()
            If .Rows.Count > 0 Then
                TxtPor_Igv.Text = Format(Val(.Rows(0)("c_por_igv").ToString), Forma_1_3)
            End If
        End With
        'hallamos el tipo de cambio
        With c_Neg_TpoCambio.get_TpoCambio_Datos(" and c_fecha_cbo='" & DtpFec_Emi.Text & "' ", "DAT")
            TxtTC.Clear()
            If .Rows.Count > 0 Then
                TxtTC.Text = Format(Val(.Rows(0)("c_compra_sunat").ToString), Forma_1_3)
            End If
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
            Dim fila As Integer = Dgv01.CurrentCellAddress.Y
            If Convert.ToBoolean(cellSelecion.Value) Then
                row.Cells("Cantidad").Value = ""
            Else 'Eliminamos registro de la oc de compra que fue desabilitada...
                Dgv01.Columns("Cantidad").ReadOnly = True
            End If
            Dgv01.Columns("Cantidad").ReadOnly = False
            Call Calcular_Totales(fila)
        End If
    End Sub
    Private Sub Dgv01_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.CurrentCellDirtyStateChanged
        If Dgv01.IsCurrentCellDirty Then
            Dgv01.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub Dgv01_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellEndEdit
        If e.ColumnIndex = 4 Then
            With Dgv01
                On Error Resume Next
                Dim Value As Decimal = Val(.CurrentCell.Value.ToString)
                Dim row As DataGridViewRow = .CurrentRow
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Value > Val(row.Cells("Total").Value) Then
                    MsgBox("Esta ingresando un monto mayor al documento...", MsgBoxStyle.Critical, Compañia)
                    row.Cells("Cantidad").Value = 0.0
                End If
                row.Cells("Cantidad").Value = Format(Val(row.Cells("Cantidad").Value), Forma_1_2)
                row.Cells("Saldo").Value = Format(Val(row.Cells("Total").Value) - Val(row.Cells("Cantidad").Value), Forma_1_2)
                Call Calcular_Totales(Fila)
            End With
        End If
    End Sub
    'metodo que nos permite calcular los registros...
    Private Sub Calcular_Totales(ByVal Fila As Integer)
        With Dgv01
            Call Limpiar_Texto(Pan05)
            On Error Resume Next
            For i = 0 To .RowCount - 1
                TxtTotal.Text = Format(Val(TxtTotal.Text) + Val(.Rows(i).Cells("Cantidad").Value.ToString), Forma_1_2)
            Next
            ' --> Validamos la factura de importacion <-- '
            If ChkAfectoIGV.Checked = True Then
                TxtIgv.Text = "0.00"
            Else
                TxtIgv.Text = Format((Val(TxtTotal.Text) / Val(1 & "." & TxtPor_Igv.Text)) * (Val(TxtPor_Igv.Text) / 100), Forma_1_2)
            End If
            TxtSubTotal.Text = Format(Val(TxtTotal.Text) - Val(TxtIgv.Text), Forma_1_2)
        End With
    End Sub
    'Grabamos la nueva nota de credito...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarCierre(DtpFec_Prd.Text) = True Then
            If CboMon.SelectedIndex > -1 Then
                If Len(TxtCod_Prov.Text) > 0 Then
                    If Val(TxtTC.Text) > 0 Then
                        If Val(TxtPor_Igv.Text) > 0 Then
                            If Val(TxtSerie.Text) > 0 Then
                                If Val(TxtNro_NC.Text) > 0 Then
                                    If Len(TxtObs.Text) > 0 Then
                                        If Val(TxtTotal.Text) > 0 Then
                                            Dim x As New TextBox
                                            Call Validar_Grabacion(x)
                                            If Val(x.Text) = 0 Then
                                                Dim f As String = MsgBox("¿Desea grabar el registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Compañia)
                                                If f = vbYes Then
                                                    Call TxtSerie_LostFocus(Nothing, Nothing)
                                                    Call TxtNro_NC_LostFocus(Nothing, Nothing)
                                                    Call Grabar_NC("ADD")
                                                    ' Validamos si grabamos detalles '
                                                    If sw = 0 Then
                                                        Call Grabar_Detalles("ADD")
                                                    End If
                                                    If Val(TxtCod_Ing.Text) = 0 Then
                                                        Call BtnFin_Click(Nothing, Nothing)
                                                    Else
                                                        Call Mostrar_NotaC(" and c_ing_nc=" & TxtCod_Ing.Text & "")
                                                    End If
                                                    Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
                                                End If
                                            Else
                                                MsgBox("1. Nota de crédito ya fue registrada anteriormente...", MsgBoxStyle.Critical, Compañia)
                                            End If
                                        Else
                                            MsgBox("2. Falta ingresar el monto para la Nota de Crédito...", MsgBoxStyle.Critical, Compañia)
                                        End If
                                    Else
                                        MsgBox("3. Falta ingresar el detalle para la nota de crédito...", MsgBoxStyle.Critical, Compañia)
                                    End If
                                Else
                                    MsgBox("4. Falta ingresar el número de nota de crédito...", MsgBoxStyle.Critical, Compañia)
                                End If
                            Else
                                MsgBox("5. Falta ingresar la serie de nota de crédito...", MsgBoxStyle.Critical, Compañia)
                            End If
                        Else
                            MsgBox("6. Falta ingresar el I.G.V. comunicarse con el administrador del sistema...", MsgBoxStyle.Critical, Compañia)
                        End If
                    Else
                        MsgBox("7. Falta ingresar el tipo de cambio...", MsgBoxStyle.Critical, Compañia)
                    End If
                Else
                    MsgBox("8. Falta seleccionar el proveedor...", MsgBoxStyle.Critical, Compañia)
                End If
            Else
                MsgBox("9. Falta seleccionar el tipo de moneda...", MsgBoxStyle.Critical, Compañia)
            End If
        End If
    End Sub
    Private Sub Grabar_NC(ByVal cOpcion As String)
        With c_Ent_NotaC
            Dim c_opc_afecto As Integer = 1
            If ChkAfectoIGV.Checked = False Then c_opc_afecto = 0
            'mostramos el codigo de la moneda para poder grabar...
            .c_ing_nc = TxtCod_Ing.Text
            .c_serie_nc = TxtSerie.Text
            .c_nro_nc = TxtNro_NC.Text
            .c_fecha_emi = DtpFec_Emi.Text
            .c_fecha_prd = DtpFec_Prd.Text
            .c_codi_prov = TxtCod_Prov.Text
            .c_codi_mon = CboMon.SelectedValue
            .c_tpo_cambio = Val(TxtTC.Text)
            .c_cant_igv = Val(TxtPor_Igv.Text)
            .c_imp_afecto = Val(TxtSubTotal.Text)
            .c_imp_igv = Val(TxtIgv.Text)
            .c_imp_total = Val(TxtTotal.Text)
            .c_opc_afecto = c_opc_afecto
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            If Val(TxtCod_Ing.Text) = 0 Then
                TxtCod_Ing.Text = c_Neg_NotaC.set_NotaC_Save(c_Ent_NotaC, FrmMenu.TxtCod_Emp.Text)
                'solo tendra detalles cuando es nuevo en caso de haber un mal ingreso se debera
                'anula nota de credito...
            Else
                c_Neg_NotaC.set_NotaC_Save(c_Ent_NotaC, FrmMenu.TxtCod_Emp.Text)
            End If
            MsgBox("Los datos se grabaron correctamente...", MsgBoxStyle.Exclamation, Compañia)
        End With
    End Sub
    ' Grabamos Detalles de NOTA de CREDITO
    Private Sub Grabar_Detalles(ByVal cOpcion As String)
        With Dgv01 'GRabamos solo si el check se encuentra activado...
            For I = 0 To .RowCount - 1
                If .Rows(I).Cells("Check").Value = True Then
                    With c_Ent_NotaCDet
                        .c_ing_nc = TxtCod_Ing.Text
                        .c_nro_ing = Dgv01.Rows(I).Cells("Codigo").Value
                        .c_imp_ing = Val(Dgv01.Rows(I).Cells("Total").Value)
                        .c_imp_nc = Val(Dgv01.Rows(I).Cells("Cantidad").Value)
                        .c_imp_saldo = Val(Dgv01.Rows(I).Cells("Saldo").Value)
                        .copcion = cOpcion
                        c_Neg_NotaCDet.set_NotaCDet_Save(c_Ent_NotaCDet, FrmMenu.TxtCod_Emp.Text)
                    End With
                End If
            Next
        End With
    End Sub
    'Metodo que nos permite validar que no se registre 2 veces un mismo numero de comprobante del mismo proveedor
    Private Sub Validar_Grabacion(ByVal x As TextBox)
        With c_Neg_NotaC.get_NotaC_Datos(" and N.c_anula_reg=0 and N.c_codi_prov='" & TxtCod_Prov.Text & "' and N.c_serie_nc='" & TxtSerie.Text & _
                                             "' and N.c_nro_nc='" & TxtNro_NC.Text & "' ", "DAT", FrmMenu.TxtCod_Emp.Text)

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
    'cerramos o cancelamos registro de nota de credito...
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            If Val(TxtCod_Ing.Text) > 0 Then
                Call Mostrar_NotaC(" and c_ing_nc='" & TxtCod_Ing.Text & "' ")
            Else
                Call BtnFin_Click(Nothing, Nothing)
            End If
            Pan01.Enabled = True : ChkAfectoIGV.Enabled = False
            Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
        End If
    End Sub

    Private Sub TxtSerie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtSerie.KeyPress
        Call solonumeros(e)
    End Sub

    Private Sub TxtSerie_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSerie.LostFocus
        If Val(TxtSerie.Text) > 0 Then
            TxtSerie.Text = Strings.Right(Val(TxtSerie.Text) + 1000, 3)
        End If
    End Sub

    Private Sub TxtSerie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSerie.TextChanged

    End Sub

    Private Sub TxtNro_NC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtNro_NC.KeyPress
        Call solonumeros(e)
    End Sub

    Private Sub TxtNro_NC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNro_NC.LostFocus
        If Val(TxtNro_NC.Text) > 0 Then
            TxtNro_NC.Text = Strings.Right(Val(TxtNro_NC.Text) + 10000000, 7)
        End If
    End Sub

    Private Sub TxtNro_Doc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtNro_NC.TextChanged

    End Sub

    Private Sub TxtBus_Ing_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBus_Ing.KeyPress
        Call solonumeros(e)
    End Sub


    Private Sub TxtBus_Serie_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBus_Serie.KeyPress
        Call solonumeros(e)
    End Sub



    Private Sub TxtBus_NC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtBus_NC.KeyPress
        Call solonumeros(e)
    End Sub
    'mostramos los detalles de las nota de credito...
    Public Sub Mostrar_NotaC(ByVal Cadena As String)
        With c_Neg_NotaC.get_NotaC_Datos(Cadena, "DAT", FrmMenu.TxtCod_Emp.Text)
            Call Cancela_Registro()
            If .Rows.Count > 0 Then
                TxtBus_Ing.Text = .Rows(0)("c_ing_nc").ToString
                TxtCod_Ing.Text = .Rows(0)("c_ing_nc").ToString
                TxtCod_Prov.Text = .Rows(0)("c_codi_prov").ToString
                TxtProve.Text = .Rows(0)("c_desc_prov").ToString
                TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                TxtTC.Text = .Rows(0)("c_tpo_cambio").ToString
                TxtPor_Igv.Text = .Rows(0)("c_cant_igv").ToString
                TxtSerie.Text = .Rows(0)("c_serie_nc").ToString
                TxtNro_NC.Text = .Rows(0)("c_nro_nc").ToString
                DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                DtpFec_Prd.Text = .Rows(0)("c_fecha_prd").ToString
                'validamos si nota de credito se encuentra anulada
                Dim Cadena2 As String = "" 'Variable que nos permitira trabajar con los anulados...
                If Val(.Rows(0)("c_anula_reg").ToString) = 1 Then
                    BtnEstado.Visible = True
                    Cadena2 = " and D.c_anula_reg=1 and D.c_ing_nc='" & TxtCod_Ing.Text & "'"
                Else
                    BtnEstado.Visible = False
                    Cadena2 = " and D.c_anula_reg=0 and D.c_ing_nc='" & TxtCod_Ing.Text & "'"
                End If
                ' Validamos IGV '
                If Val(.Rows(0)("c_opc_afecto").ToString) = 1 Then
                    ChkAfectoIGV.Checked = False
                Else
                    ChkAfectoIGV.Checked = True
                End If
                CboMon.SelectedValue = .Rows(0)("c_codi_mon").ToString
                TxtIgv.Text = .Rows(0)("c_imp_igv").ToString
                TxtSubTotal.Text = .Rows(0)("c_imp_afecto").ToString
                TxtTotal.Text = .Rows(0)("c_imp_total").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                'Mostramos los detalles de las facturas amarradas...
                With c_Neg_NotaCDet.get_NotaCDet_Datos(Cadena2, "DAT", FrmMenu.TxtCod_Emp.Text)
                    Dgv01.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dgv01.Rows.Add()
                            Dgv01.Rows(i).Cells("check").Value = True
                            Dgv01.Rows(i).Cells("codigo").Value = .Rows(i)("c_nro_ing").ToString
                            Dgv01.Rows(i).Cells("Tpo").Value = .Rows(i)("c_desc_doc").ToString
                            Dgv01.Rows(i).Cells("Doc").Value = .Rows(i)("c_serie_doc").ToString & " " & .Rows(i)("c_nro_doc").ToString
                            Dgv01.Rows(i).Cells("Total").Value = Format(Val(.Rows(i)("c_imp_ing").ToString), Forma_1_2)
                            Dgv01.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_imp_nc").ToString), Forma_1_2)
                            Dgv01.Rows(i).Cells("Saldo").Value = Format(Val(.Rows(i)("c_imp_saldo").ToString), Forma_1_2)
                        Next
                    End If
                End With
                Dgv01.Enabled = False
            End If
        End With
    End Sub

    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_NotaC(" and N.c_ing_nc=(select max(c_ing_nc) from scom_" & FrmMenu.TxtCod_Emp.Text & "_notac)")
    End Sub

    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_NotaC(" and N.c_ing_nc=(select min(c_ing_nc) from scom_" & FrmMenu.TxtCod_Emp.Text & "_notac)")
    End Sub

    Private Sub TxtBus_Ing_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Ing.TextChanged

    End Sub
    Private Sub TxtBus_Ing_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Ing.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_Ing.Text) > 0 Then
                TxtBus_Ing.Text = Strings.Right(Val(TxtBus_Ing.Text) + 10000000, 7)
                Call Mostrar_NotaC(" and c_ing_nc='" & TxtBus_Ing.Text & "'")
            End If
        End If
    End Sub
    ' metodo para mostrar nota de credito '
    Public Sub Mostrar_notaC()
        TxtBus_Ing.Text = Strings.Right(Val(TxtBus_Ing.Text) + 10000000, 7)
        Call Mostrar_NotaC(" and c_ing_nc='" & TxtBus_Ing.Text & "'")
    End Sub
    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBus_Ing.Text) > 1 Then
            TxtBus_Ing.Text = Strings.Right((Val(TxtBus_Ing.Text) - 1) + 10000000, 7)
            Call Mostrar_NotaC(" and c_ing_nc='" & TxtBus_Ing.Text & "'")
        End If
    End Sub
    'avanzamos
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBus_Ing.Text) > 0 Then
            TxtBus_Ing.Text = Strings.Right(Val(TxtBus_Ing.Text) + 10000001, 7)
            Call Mostrar_NotaC(" and c_ing_nc='" & TxtBus_Ing.Text & "'")
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If ValidarCierre(DtpFec_Prd.Text) = True Then
            If BtnEstado.Visible = False Then
                Dim f As String = MsgBox("¿Confirma la eliminación del registro?", vbYesNo + MsgBoxStyle.Question, Compañia)
                If f = vbYes Then
                    Call Grabar_NC("DEL") : Call Grabar_Detalles("DEL") : BtnEstado.Visible = True
                End If
            Else
                MsgBox("Registro ya fue eliminado, no podra realizar esta operación", MsgBoxStyle.Critical, Compañia)
            End If
        End If
    End Sub
    'mostramos el tipo de moneda
    Private Sub CboMon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMon.SelectedIndexChanged
        LblMon1.Text = CboMon.Text : LblMon2.Text = CboMon.Text : LblMon3.Text = CboMon.Text
        Call Mostrar_documentos()
    End Sub

    Private Sub TxtObs_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtObs.LostFocus
        If Focos = 1 Then
            Focos = 0 : TxtObs.Focus()
        End If
    End Sub

    Private Sub TxtObs_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtObs.TextChanged

    End Sub
    ' Listado de nota de credito '
    Private Sub LnkListado_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkListado.LinkClicked
        FrmConNotaC.MdiParent = FrmMenu : FrmConNotaC.Show()
    End Sub

End Class