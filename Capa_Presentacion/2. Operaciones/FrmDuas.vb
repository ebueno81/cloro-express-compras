Public Class FrmDuas
    Dim vOpt As Integer = 0
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Call Nuevo_Registro() : TxtSerie_Dua.Focus() : CboMon.SelectedIndex = -1 : DtpFec_Emi.Text = Now.Date
        Dgv01.Rows.Clear() : CboProve.SelectedValue = "" : CboProve.Focus() : BtnEstado.Text = "Pendiente" : BtnEstado.BackColor = Color.Maroon
        Dgv02.Rows(0).Cells("SubTotal").Value = "0.00" : CboMon.Enabled = True : TxtSerie_Dua.Focus() : Call Limpiar_Texto(Pan11) : DtpFec_Prd.Enabled = True
    End Sub
    Private Sub Nuevo_Registro()
        Call Limpiar_Texto(Pan01) : Call Activar(Pan01) : TxtNro_Mov.Enabled = False : TxtUsua_Crea.Enabled = False
        Call Limpiar_Texto(Pan02) : Call Activar(Pan02) : TxtNro_Mov.Enabled = False : TxtTC.Enabled = False
        TxtUsua_Modi.Enabled = False : TxtFecha_Crea.Enabled = False : TxtFecha_Modi.Enabled = False
        BtnCerrar.Text = "&Cancelar" : BtnGrabar.Enabled = True : TxtNro_Mov.Enabled = False
        Pan09.Enabled = True : Pan10.Enabled = False : Call Limpiar_Texto(Pan08) : CboProve.Enabled = True : DtpFec_Emi.Enabled = True
    End Sub
    Private Sub Cancelar_Registro()
        Call Desactivar(Pan02) : BtnCerrar.Text = "&Cerrar" : BtnGrabar.Enabled = False
        Pan09.Enabled = False : CboProve.Enabled = False : CboMon.Enabled = False : DtpFec_Emi.Enabled = False
        DtpFec_Prd.Enabled = False : DtpFec_Emi.Text = Now.Date : DtpFec_Prd.Text = Now.Date
    End Sub

    Private Sub FrmDuas_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then Call BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then Call BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F5 Then
            If BtnGrabar.Enabled = True Then
                Dim f As String = MsgBox("¿Desea actualizar el tipo de cambio?", vbYesNo, Compañia)
                If f = vbYes Then
                    Call DtpFec_Emi_ValueChanged(Nothing, Nothing)
                    MsgBox("Tipo de cambio se actualizo correctamente...", vbExclamation, Compañia)
                End If
            End If
        End If
    End Sub

    Private Sub FrmDuas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmDuas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnMoneda.Get_Moneda_Cbo(" AND c_anula_reg=0 order by c_codi_mon", CboMon)
        c_Neg_mnProve.get_MtProve_Cbo(" and c_anula_reg=0 order by c_desc_prov", CboProve)
        Me.Location = New Point(0, 0) : Dgv02.Rows.Add() : BtnFin_Click(Nothing, Nothing)
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Call Nuevo_Detalles() : TxtCod_UniMed.Text = "001" : vOpt = 0
    End Sub
    ' metodo para nuevo detalle '
    Private Sub Nuevo_Detalles()
        With Dgv01
            .Size = New Size(772, 112) : .Location = New Point(2, 262)
        End With
        Call Limpiar_Texto(Pan07) : Pan07.Enabled = True : Pan09.Enabled = False : Pan10.Enabled = True : TxtCant.Enabled = True : TxtP_Unit.Enabled = True
        TxtUni_Med.Text = "UNID" : TxtCant.Focus()
    End Sub
    ' metodo para cancelar detalle '
    Private Sub Cancelar_Detalles()
        With Dgv01
            .Size = New Size(772, 186) : .Location = New Point(2, 188)
        End With
        Call Limpiar_Texto(Pan07) : Pan07.Enabled = False : Pan09.Enabled = True : Pan10.Enabled = False
    End Sub
    ' Cancelamos detalles '
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call Cancelar_Detalles()
    End Sub
    ' editamos registro '
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("anula").Value) = 0 Then
                        Call Nuevo_Detalles() : Call Mostrar_Detalles(Fila) : TxtCant.Focus() : vOpt = 1
                    Else
                        MsgBox("Registro se encuentra anulado... no podra realizar ninguna modificación...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    ' metodo para mostrar detalles '
    Private Sub Mostrar_Detalles(ByVal Fila As Integer)
        With Dgv01
            TxtCant.Text = .Rows(Fila).Cells("Cantidad").Value
            TxtUni_Med.Text = .Rows(Fila).Cells("Unid").Value
            TxtP_Unit.Text = .Rows(Fila).Cells("Precio").Value
            TxtCod_Tg.Text = .Rows(Fila).Cells("Mot").Value
            TxtCod_Cd.Text = .Rows(Fila).Cells("Cd").Value
            TxtCod_Scd.Text = .Rows(Fila).Cells("Scd").Value
            TxtScd.Text = .Rows(Fila).Cells("Descripcion").Value
            TxTImpor.Text = .Rows(Fila).Cells("Importe").Value
            TxtItem.Text = .Rows(Fila).Cells("item").Value
            TxtCod_UniMed.Text = .Rows(Fila).Cells("c_codi_unimed").Value
            ' Validamos si esta, inafecto o es igv... '
            If Val(.Rows(Fila).Cells("c_opc_afecto").Value) = 1 Then Rdb01.Checked = True
            If Val(.Rows(Fila).Cells("c_opc_afecto").Value) = 2 Then Rdb02.Checked = True
            If Val(.Rows(Fila).Cells("c_opc_afecto").Value) = 0 Then Rdb03.Checked = True
            ' mostramos los datos de la tabla general '
            With c_Neg_MnScaidas.get_sCaidas_Datos(" and S.c_codi_tg='" & TxtCod_Tg.Text & "' and S.c_codi_cd='" & TxtCod_Cd.Text & "' and S.c_codi_scd='" & TxtCod_Scd.Text & "' ", "DAT")
                If .Rows.Count > 0 Then
                    TxtTg.Text = .Rows(0)("c_desc_tg").ToString
                    TxtCd.Text = .Rows(0)("c_desc_cd").ToString
                End If
            End With
        End With
    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        With Dgv01
            Dim Fila As Integer
            If Val(vOpt) > 0 Then
                Fila = .CurrentCellAddress.Y
            Else
                Dgv01.Rows.Add()
                Fila = .RowCount - 1
            End If
            Call Aceptar_Detalles(Fila) : Call Cancelar_Detalles() : Dgv01.Focus()
            Call Calcular_Total_Cuotas() : focos = 1 : BtnAdd.Focus()
        End With
    End Sub
    ' metodo para aceptar detalles'
    Private Sub Aceptar_Detalles(ByVal Fila As Integer)
        With Dgv01
            Dim afecto As Integer = 0
            .Rows(Fila).Cells("Cantidad").Value = Format(Val(TxtCant.Text), Forma_1_2)
            .Rows(Fila).Cells("Unid").Value = TxtUni_Med.Text
            .Rows(Fila).Cells("Precio").Value = Format(Val(TxtP_Unit.Text), Forma_1_2)
            .Rows(Fila).Cells("Mot").Value = TxtCod_Tg.Text
            .Rows(Fila).Cells("Cd").Value = TxtCod_Cd.Text
            .Rows(Fila).Cells("Scd").Value = TxtCod_Scd.Text
            .Rows(Fila).Cells("Descripcion").Value = TxtScd.Text
            .Rows(Fila).Cells("Importe").Value = Format(Val(TxTImpor.Text), Forma_1_2)
            .Rows(Fila).Cells("Item").Value = TxtItem.Text
            .Rows(Fila).Cells("c_codi_unimed").Value = TxtCod_UniMed.Text
            .Rows(Fila).Cells("Anula").Value = 0
            If Rdb01.Checked = True Then afecto = 1 'Afecto
            If Rdb02.Checked = True Then afecto = 2 'igv
            If Rdb03.Checked = True Then afecto = 0 'inafecto
            .Rows(Fila).Cells("c_opc_afecto").Value = afecto
        End With
    End Sub
    ' metodo para calcular los totales '
    Private Sub Calcular_Total_Cuotas()
        With Dgv01
            Dim Total_pagar, Tot_Afecto, Tot_Inaf, Tot_Igv As Decimal
            For i = 0 To .RowCount - 1
                If Val(.Rows(i).Cells("Anula").Value) = 0 Then
                    Total_pagar = Format(Total_pagar + Val(.Rows(i).Cells("Importe").Value), Forma_1_2)
                    If Val(.Rows(i).Cells("c_opc_afecto").Value) = 0 Then Tot_Inaf = Tot_Inaf + Val(.Rows(i).Cells("Importe").Value)
                    If Val(.Rows(i).Cells("c_opc_afecto").Value) = 1 Then Tot_Afecto = Tot_Afecto + Val(.Rows(i).Cells("Importe").Value)
                    If Val(.Rows(i).Cells("c_opc_afecto").Value) = 2 Then Tot_Igv = Tot_Igv + Val(.Rows(i).Cells("Importe").Value)
                End If
            Next
            TxtTot_Afecto.Text = Format(Tot_Afecto, Forma_1_2)
            TxtTot_Igv.Text = Format(Tot_Igv, Forma_1_2)
            TxtTot_Inaf.Text = Format(Tot_Inaf, Forma_1_2)
            TxtTotal.Text = Format(Total_pagar, Forma_1_2)

            Dgv02.Rows(0).Cells("SubTotal").Value = Format(Total_pagar, Forma_2_2)
            Dgv02.Rows(0).Cells("Titulo").Value = "Total"
        End With
    End Sub

    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        If BtnCerrar.Text = "&Cerrar" Then
            Me.Close()
        Else
            If Len(TxtNro_Mov.Text) = 0 Then
                Call BtnFin_Click(Nothing, Nothing)
            Else
                Call Mostrar_Duas(" and c_nro_operacion='" & TxtNro_Mov.Text & "' ")
            End If
        End If
    End Sub
    ' Inicio 
    Private Sub BtnIni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIni.Click
        Call Mostrar_Duas(" and c_nro_operacion=(select min(c_nro_operacion) from scom_DuasCab) ")
    End Sub
    ' Metodo para mostrar leasing
    Public Sub Mostrar_Duas(ByVal Cadena As String)
        With c_Neg_DuasCab.get_DuasCab_Datos(Cadena, "DAT")
            Call Cancelar_Registro() : Call Cancelar_Detalles() : Pan09.Enabled = False
            Call Limpiar_Texto(Pan11) : Dgv01.Rows.Clear() : Call Limpiar_Texto(Pan02) : Call Limpiar_Texto(Pan08)
            Dgv02.Rows(0).Cells("SubTotal").Value = "0.00"
            If .Rows.Count > 0 Then
                TxtBuscar.Text = .Rows(0)("c_nro_operacion").ToString
                TxtNro_Mov.Text = .Rows(0)("c_nro_operacion").ToString
                CboProve.SelectedValue = .Rows(0)("c_codi_prov").ToString
                CboMon.SelectedValue = .Rows(0)("c_Codi_mon").ToString
                TxtSerie_Dua.Text = .Rows(0)("c_serie_dua").ToString
                TxtNro_Dua.Text = .Rows(0)("c_nro_dua").ToString
                DtpFec_Emi.Text = .Rows(0)("c_fecha_emi").ToString
                DtpFec_Prd.Text = .Rows(0)("c_fecha_prd").ToString
                TxtTC.Text = Format(Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_3)
                TxtObs.Text = .Rows(0)("c_obs").ToString
                TxtTot_Afecto.Text = Format(Val(.Rows(0)("c_imp_afecto").ToString), Forma_1_2)
                TxtTot_Inaf.Text = Format(Val(.Rows(0)("c_imp_inaf").ToString), Forma_1_2)
                TxtTot_Igv.Text = Format(Val(.Rows(0)("c_imp_igv").ToString), Forma_1_2)
                TxtTotal.Text = Format(Val(.Rows(0)("c_imp_total").ToString), Forma_1_2)

                TxtUsua_Crea.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_Modi.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                If Val(.Rows(0)("c_anula_reg").ToString) = 1 Then
                    BtnEstado.Text = "Anulado" : BtnEstado.BackColor = Color.Red : BtnEstado.ForeColor = Color.White
                Else
                    If Val(.Rows(0)("c_opc_cancel").ToString) = 0 Then
                        BtnEstado.Text = "Pendiente" : BtnEstado.BackColor = Color.Maroon : BtnEstado.ForeColor = Color.White
                    Else
                        If Val(.Rows(0)("c_opc_cancel").ToString) = 1 Then
                            BtnEstado.Text = "Cancelado" : BtnEstado.BackColor = Color.Blue : BtnEstado.ForeColor = Color.White
                        Else
                            BtnEstado.Text = "Amortizado" : BtnEstado.BackColor = Color.SteelBlue : BtnEstado.ForeColor = Color.White
                        End If
                    End If
                End If
                With c_Neg_DuasDet.get_DuaDet_Datos(" and D.c_nro_operacion='" & TxtNro_Mov.Text & "' order by c_nro_correl", "DAT")
                    Dgv01.Rows.Clear()
                    For i = 0 To .Rows.Count - 1
                        Dgv01.Rows.Add()
                        Dgv01.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), Forma_1_2)
                        Dgv01.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                        Dgv01.Rows(i).Cells("c_codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                        Dgv01.Rows(i).Cells("Mot").Value = .Rows(i)("c_codi_tg").ToString
                        Dgv01.Rows(i).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString
                        Dgv01.Rows(i).Cells("Scd").Value = .Rows(i)("c_codi_scd").ToString
                        Dgv01.Rows(i).Cells("Descripcion").Value = .Rows(i)("c_desc_scd").ToString
                        Dgv01.Rows(i).Cells("Precio").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_2)
                        Dgv01.Rows(i).Cells("Importe").Value = Format(Val(.Rows(i)("c_imp_total").ToString), Forma_1_2)
                        Dgv01.Rows(i).Cells("Item").Value = .Rows(i)("c_nro_correl").ToString
                        Dgv01.Rows(i).Cells("Anula").Value = Val(.Rows(i)("c_anula_reg").ToString)
                        Dgv01.Rows(i).Cells("c_opc_afecto").Value = Val(.Rows(i)("c_opc_afecto").ToString)
                    Next
                End With
                ' Calculamos los totales '
                Call Calcular_Total_Cuotas()
                Call Grid_Registro_Campo_Anula(Dgv01)
            End If
        End With
    End Sub

    Private Sub CboMon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMon.SelectedIndexChanged

    End Sub

    Private Sub DtpFec_Emi_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Emi.ValueChanged
        Call Mostrar_TpoCambio(DtpFec_Emi.Text, TxtTC)
    End Sub

    Private Sub BtnCon2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon2.Click
        With FrmConTg
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 6
            .Cargar_Grid(" and c_anula_reg=0  order by c_desc_tg")
        End With
    End Sub

    Private Sub BtnCon3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon3.Click
        With FrmConCd
            .Show() : .MdiParent = FrmMenu : .TxtVar.Text = 6 : .TxtCod_Tg.Text = TxtCod_Tg.Text
            .Cargar_Grid(" and c_anula_reg=0 and c_codi_tg='" & TxtCod_Tg.Text & "' order by c_desc_cd")
        End With
    End Sub

    Private Sub BtnCon4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon4.Click
        With FrmConScd
            .Show() : .MdiParent = FrmMenu
            .TxtVar.Text = 6 : .TxtCod_Tg.Text = TxtCod_Tg.Text : .TxtCod_Cd.Text = TxtCod_Cd.Text
            .Cargar_Grid(" and S.c_anula_reg=0 and S.c_codi_tg='" & TxtCod_Tg.Text & "' and S.c_codi_cd='" & TxtCod_Cd.Text & "' order by c_desc_scd")
        End With
    End Sub
    Dim focos As Integer = 0
    ' funcion para grabar registros '
    Private Function ValidarDatos() As Boolean
        If CboMon.SelectedIndex > -1 Then
            If CboProve.SelectedIndex > -1 Then
                If Val(TxtTC.Text) > 0 Then
                    If Len(TxtNro_Dua.Text) > 0 And Len(TxtSerie_Dua.Text) > 0 Then
                        If Val(Dgv02.Rows(0).Cells("SubTotal").Value) > 0 Then
                            ValidarDatos = True
                        Else
                            ValidarDatos = False
                            MsgBox("1. Falta ingresar el importe de la Dua", vbCritical, Compañia)
                        End If
                    Else
                        ValidarDatos = False
                        MsgBox("2. Falta ingresar el número de Dua", vbCritical, Compañia)
                    End If
                Else
                    ValidarDatos = False
                    MsgBox("3. Falta ingresar el tipo de cambio", vbCritical, Compañia)
                End If
            Else
                ValidarDatos = False
                MsgBox("4. Falta seleccionar el tipo de proveedor", vbCritical, Compañia)
            End If
        Else
            ValidarDatos = False
            MsgBox("5. Falta seleccionar la moneda", vbCritical, Compañia)
        End If
    End Function
    ' Metodo grabar numero de leasing '
    Private Function ValidarNroDoc() As Boolean
        With c_Neg_DuasCab.get_DuasCab_Datos(" and C.c_serie_dua='" & TxtSerie_Dua.Text & "' and C.c_nro_dua='" & TxtNro_Dua.Text & "' and C.c_codi_prov='" & CboProve.SelectedValue & "' " _
                                                       & " and C.c_anula_reg=0 ", "DAT")
            If Val(TxtNro_Mov.Text) > 0 Then
                If .Rows.Count > 1 Then
                    ValidarNroDoc = False
                    MsgBox("1. Nro. de D.U.A. ya fue ingresado anteriormente... Revisar", vbCritical, Compañia)
                Else
                    ValidarNroDoc = True
                End If
            Else
                If .Rows.Count > 0 Then
                    ValidarNroDoc = False
                    MsgBox("2. Nro. de D.U.A. ya fue ingresado anteriormente... Revisar", vbCritical, Compañia)
                Else
                    ValidarNroDoc = True
                End If
            End If
        End With
    End Function
    ' grabamos registro
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        If ValidarCierre(DtpFec_Prd.Text) = True Then
            If ValidarDatos() = True Then
                If ValidarNroDoc() = True Then
                    Dim F As String = MsgBox("¿Desea Grabar el D.U.A.?", vbYesNo + MsgBoxStyle.Question, Compañia)
                    If F = vbYes Then
                        Call Grabar_DuaCab("ADD")
                        With Dgv01
                            For i = 0 To .RowCount - 1
                                If Val(.Rows(i).Cells("Anula").Value) = 0 Then
                                    Call Grabar_DuaDet(i, "ADD")
                                Else
                                    Call Grabar_DuaDet(i, "DEL")
                                End If
                            Next
                        End With
                        Call BtnCerrar_Click(Nothing, Nothing)
                        MsgBox("Registro se grabo correctamente...", vbExclamation, Compañia)
                    End If
                End If
            End If
        End If
    End Sub
    'metodo para grabar '
    Private Sub Grabar_DuaCab(ByVal cOpcion As String)
        With c_Ent_DuasCab
            .c_nro_operacion = TxtNro_Mov.Text
            .c_fecha_emision = DtpFec_Emi.Text
            .c_fecha_prd = DtpFec_Prd.Text
            .c_tpo_cambio = Val(TxtTC.Text)
            .c_codi_prove = CboProve.SelectedValue
            .c_serie_dua = TxtSerie_Dua.Text
            .c_nro_dua = TxtNro_Dua.Text
            .c_codi_mon = CboMon.SelectedValue
            .c_imp_inaf = Val(TxtTot_Inaf.Text)
            .c_imp_afecto = Val(TxtTot_Afecto.Text)
            .c_imp_igv = Val(TxtTot_Igv.Text)
            .c_imp_total = Val(TxtTotal.Text)
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .cOpcion = cOpcion
            If Len(TxtNro_Mov.Text) = 0 Then
                TxtNro_Mov.Text = c_Neg_DuasCab.set_DuasCab_Save(c_Ent_DuasCab)
            Else
                c_Neg_DuasCab.set_DuasCab_Save(c_Ent_DuasCab)
            End If
            TxtBuscar.Text = TxtNro_Mov.Text
        End With
    End Sub
    'metodo para grabar '
    Private Sub Grabar_DuaDet(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_DuasDet
            .c_nro_correl = Dgv01.Rows(Fila).Cells("Item").Value
            .c_nro_operacion = TxtNro_Mov.Text
            .c_codi_tg = Dgv01.Rows(Fila).Cells("Mot").Value
            .c_codi_cd = Dgv01.Rows(Fila).Cells("Cd").Value
            .c_codi_scd = Dgv01.Rows(Fila).Cells("Scd").Value
            .c_codi_unimed = Dgv01.Rows(Fila).Cells("c_codi_unimed").Value
            .c_nro_cant = Val(Dgv01.Rows(Fila).Cells("Cantidad").Value)
            .c_prec_unit = Val(Dgv01.Rows(Fila).Cells("Precio").Value.ToString)
            .c_imp_total = Val(Dgv01.Rows(Fila).Cells("Importe").Value)
            .c_opc_afecto = Val(Dgv01.Rows(Fila).Cells("c_opc_afecto").Value)
            .cOpcion = cOpcion
            ' Validamos registro '
            If Val(Dgv01.Rows(Fila).Cells("Item").Value) = 0 Then
                Dgv01.Rows(Fila).Cells("Item").Value = c_Neg_DuasDet.set_DuaDet_Save(c_Ent_DuasDet)
            Else
                c_Neg_DuasDet.set_DuaDet_Save(c_Ent_DuasDet)
            End If
        End With
    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If ValidarCierre(DtpFec_Prd.Text) = True Then
            If UCase(BtnEstado.Text) = "PENDIENTE" Then
                Pan09.Enabled = True : CboProve.Enabled = True : BtnGrabar.Enabled = True : TxtSerie_Dua.Enabled = True : TxtNro_Dua.Enabled = True
                DtpFec_Emi.Enabled = True
                BtnCerrar.Text = "&Cancelar" : CboMon.Enabled = False : DtpFec_Emi.Enabled = True : DtpFec_Prd.Enabled = True
            Else
                MsgBox("Registro se encuentra anulado no podra realizar ninguna modifiación...", vbCritical, Compañia)
            End If
        End If
    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If ValidarCierre(DtpFec_Prd.Text) = True Then
            If UCase(BtnEstado.Text) = "PENDIENTE" Then
                Dim F As String = MsgBox("¿Desea eliminar registro?", vbYesNo + vbQuestion, Compañia)
                If F = vbYes Then
                    Call Grabar_DuaCab("DEL") : BtnEstado.Text = "Anulado" : BtnEstado.BackColor = Color.Red
                End If
            Else
                MsgBox("Registro no puede ser eliminado", vbCritical, Compañia)
            End If
        End If
    End Sub

    Private Sub TxtCant_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtCant.TextChanged
        Call Calcular_Importe()
    End Sub
    ' metodo para calcular importe '
    Private Sub Calcular_Importe()
        TxTImpor.Text = Format(Val(TxtCant.Text) * Val(TxtP_Unit.Text), Forma_1_2)
    End Sub
    ' metodo para precio unitario '
    Private Sub TxtP_Unit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtP_Unit.TextChanged
        Call Calcular_Importe()
    End Sub

    Private Sub BtnFin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFin.Click
        Call Mostrar_Duas(" and c_nro_operacion=(select max(c_nro_operacion) from scom_DuasCab) ")
    End Sub

    Private Sub BtnAdd_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.LostFocus
        If focos = 1 Then
            focos = 0 : BtnAdd.Focus()
        End If
    End Sub

    Private Sub TxtBuscar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBuscar.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBuscar.Text) > 0 Then
                TxtBuscar.Text = Strings.Right(Val(TxtBuscar.Text) + 10000000, 7)
                Call Mostrar_Duas(" and  c_nro_operacion='" & TxtBuscar.Text & "' ")
            End If
        End If
    End Sub

    Private Sub TxtBuscar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBuscar.TextChanged

    End Sub

    Private Sub BtnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAtr.Click
        If Val(TxtBuscar.Text) > 1 Then
            TxtBuscar.Text = Strings.Right((Val(TxtBuscar.Text) - 1) + 10000000, 7)
            Call Mostrar_Duas(" and  c_nro_operacion='" & TxtBuscar.Text & "' ")
        End If
    End Sub
    ' Avanzamos 
    Private Sub BtnAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAva.Click
        If Val(TxtBuscar.Text) > 0 Then
            TxtBuscar.Text = Strings.Right(Val(TxtBuscar.Text) + 10000001, 7)
            Call Mostrar_Duas(" and c_nro_operacion='" & TxtBuscar.Text & "' ")
        End If
    End Sub
    ' Eliminamos detalles '
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("anula").Value) = 0 Then
                        Dim F As String = MsgBox("¿Desea eliminar el registro?", vbQuestion + vbYesNo, Compañia)
                        If F = vbYes Then
                            If Val(.Rows(Fila).Cells("Item").Value) = 0 Then
                                Dgv01.Rows.RemoveAt(Fila)
                            Else
                                Dgv01.Rows(Fila).DefaultCellStyle.BackColor = Color.Gainsboro
                                Dgv01.Rows(Fila).Cells("Anula").Value = 1
                            End If
                            Call Calcular_Importe()
                        End If
                    Else
                        MsgBox("Registro se encuentra Anulado...", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registro_Campo_Anula(Dgv01)
    End Sub
    ' historial 
    Private Sub LnkHistorial_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkHistorial.LinkClicked
        If UCase(BtnEstado.Text) = "AMORTIZADO" Or UCase(BtnEstado.Text) = "CANCELADO" Then
            FrmConHistoCancel.MdiParent = FrmMenu : FrmConHistoCancel.Show()
            FrmConHistoCancel.Cargar_Grid(" and I.c_serie_dua='" & TxtSerie_Dua.Text & _
                                          "' and I.c_nro_dua='" & TxtNro_Dua.Text & "' and P.c_codi_mon='" & CboMon.SelectedValue & "' and P.c_codi_prov='" & CboProve.SelectedValue & _
                                          "' order by P.c_fecha_pago", "DUA")
        Else
            MsgBox("No se registran pagos a cuenta...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub LnkConDuas_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkConDuas.LinkClicked
        With FrmConDuas
            .MdiParent = FrmMenu : .Show()
            .TxtVar.Text = 1
        End With
    End Sub
End Class