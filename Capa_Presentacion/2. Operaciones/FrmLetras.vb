Public Class FrmLetras
    Dim Var1 As Integer = 0 'Variable que nos permitira saber si estamos grabando o modificando el registro...

    'metodo que nos permite mostrar los documentos de fact
    Public Sub Mostrar_documentos()
        Dgv01.Rows.Clear() : Dgv02.Rows.Clear()
        'buscamos por el tipo de moneda y solo los documentos perteneciente al proveedor y que tenga un saldo por factura...
        With c_Neg_IngComp.get_IngComp_Datos(" and I.c_anula_reg=0 and I.c_imp_saldo>0 and I.c_codi_prov='" & TxtCod_Prov.Text & _
                                             "' and I.c_codi_mon='" & CboMon.SelectedValue & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                For i = 0 To .Rows.Count - 1
                    Dgv01.Rows.Add()
                    Dgv01.Rows(i).Cells("check").Value = False
                    Dgv01.Rows(i).Cells("tpo").Value = .Rows(i)("c_desc_doc").ToString
                    Dgv01.Rows(i).Cells("c_nro_serie").Value = .Rows(i)("c_serie_doc").ToString
                    Dgv01.Rows(i).Cells("doc").Value = .Rows(i)("c_nro_doc").ToString
                    Dgv01.Rows(i).Cells("total").Value = Format(Val(.Rows(i)("c_imp_saldo").ToString), Forma_1_2)
                    Dgv01.Rows(i).Cells("Detraccion").Value = Format(Val(.Rows(i)("c_imp_detracc").ToString), Forma_1_2)
                    Dgv01.Rows(i).Cells("Retencion").Value = Format(Val(.Rows(i)("c_imp_reten").ToString), Forma_1_2)
                    Dgv01.Rows(i).Cells("c_nro_ing").Value = .Rows(i)("c_nro_ing").ToString
                    Dgv01.Rows(i).Cells("c_codi_doc").Value = .Rows(i)("c_codi_doc").ToString
                Next
            End If
        End With
        '-->mostramos las letras que podran ser amarradas para el mismo proveedor....<---'
        With c_Neg_LetCab.get_LetCab_Datos(" and L.c_anula_reg=0 and L.c_imp_saldo>0 and L.c_codi_prov='" & TxtCod_Prov.Text & "' and L.c_codi_mon='" & _
                                           CboMon.SelectedValue & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                Dim pos As Integer = Dgv01.RowCount
                For i = 0 To .Rows.Count - 1
                    Dgv01.Rows.Add()
                    Dgv01.Rows(pos + i).Cells("check").Value = False
                    Dgv01.Rows(pos + i).Cells("tpo").Value = "LETRA"
                    Dgv01.Rows(pos + i).Cells("doc").Value = .Rows(i)("c_nro_letra").ToString
                    Dgv01.Rows(pos + i).Cells("total").Value = Format(Val(.Rows(i)("c_imp_saldo").ToString), Forma_1_2)
                    Dgv01.Rows(pos + i).Cells("Detraccion").Value = ""
                    Dgv01.Rows(pos + i).Cells("Retencion").Value = ""
                    Dgv01.Rows(pos + i).Cells("c_nro_ing").Value = .Rows(i)("c_nro_letra").ToString
                    Dgv01.Rows(pos + i).Cells("c_codi_doc").Value = "05" ' Codigo de Letras '
                Next
            End If
        End With
        Call Calcular_Totales_Fact()
        Call Calcular_Totales_Letras()
    End Sub
    ' Consultar Proveedores '
    Private Sub BtnCon_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon_2.Click
        FrmConProve.Show() : FrmConProve.MdiParent = FrmMenu
        FrmConProve.Cargar_Grid(" and c_anula_reg=0 order by c_desc_prov")
        FrmConProve.TxtVar.Text = 6
    End Sub
    'mostramos segun las monedas...
    Private Sub CboMon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboMon.SelectedIndexChanged
        On Error Resume Next
        Call Mostrar_documentos()
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If Val(Dgv03.Rows(0).Cells("Total_2").Value) > 0 Then
            Call Nuevo_Ingreso()
            Var1 = 1 'mostrmamos el saldo total por defecto siempre y cuando sea una sola letra por el total de factura...
            If Dgv02.RowCount = 0 Then TxtImporte.Text = Format(Val(Dgv03.Rows(0).Cells(1).Value), Forma_1_2)
        Else
            MsgBox("No existen facturas seleccionadas...", MsgBoxStyle.Critical, Compañia)
        End If
    End Sub
    Private Sub Nuevo_Ingreso()
        With Dgv02
            .Size = New Size(447, 155)
            .Location = New Point(1, 23)
        End With
        Call Limpiar_Texto(Pan03)
        BtnAceptar.Enabled = True : BtnCancel.Enabled = True
        BtnAdd.Enabled = False : BtnEdit.Enabled = False : BtnDel.Enabled = False
        DtpFec_Giro.Text = Now.Date : DtpFec_Venci.Text = Now.Date : TxtNro_Letra.Focus()
    End Sub
    Private Sub Cancela_Ingreso()
        With Dgv02
            .Size = New Size(447, 177)
            .Location = New Point(1, 1)
        End With
        BtnAceptar.Enabled = False : BtnCancel.Enabled = False
        BtnAdd.Enabled = True : BtnEdit.Enabled = True : BtnDel.Enabled = True
        Call Limpiar_Texto(Pan03) : Dgv02.Enabled = True
        Call Validar_Permiso(Me.Name, BtnRenova, BtnEditar, BtnEliminar)
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    Call Nuevo_Ingreso()
                    Var1 = 2
                    TxtNro_Letra.Text = .Rows(fila).Cells("Letra").Value
                    TxtDias.Text = .Rows(fila).Cells("Dias").Value
                    DtpFec_Giro.Text = .Rows(fila).Cells("Fecha_Giro").Value
                    DtpFec_Venci.Text = .Rows(fila).Cells("Fecha_Venci").Value
                    TxtImporte.Text = Val(.Rows(fila).Cells("Importe").Value)
                    Dgv02.Enabled = False
                End If
            End If
        End With
    End Sub
    'Eliminamos el registro seleccionado...
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDel.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim fila As Integer = .CurrentCellAddress.Y
                If fila > -1 Then
                    Dim f As String = MsgBox("¿Confirma la elimimación del registro...?", MsgBoxStyle.YesNo + vbQuestion, Compañia)
                    If f = vbYes Then
                        .Rows.RemoveAt(fila) : Calcular_Totales_Letras()
                    End If
                End If
            End If
        End With
    End Sub
    'Validamos ingreso...
    Private Sub Validar_Ingreso(ByVal x As TextBox)
        With Dgv02
            Dim total As Decimal = 0
            For i = 0 To .RowCount - 1
                total = total + Val(.Rows(i).Cells("Importe").Value)
            Next
            If (Val(TxtImporte.Text) + total) > Val(Dgv03.Rows(0).Cells("Total_2").Value) Then
                MsgBox("Esta tratando de ingresar un monto mayor a las facturas seleccionadas...", MsgBoxStyle.Critical, Compañia)
                x.Text = 1
            End If
        End With
    End Sub
    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If ValidarCierre(DtpFec_Giro.Text) = True Then
            If Var1 = 1 Then
                Dim x As New TextBox
                Call Validar_Ingreso(x)
                If Val(x.Text) = 0 Then
                    With Dgv02
                        .Rows.Add()
                        Call Agregar_Registro(.RowCount - 1)
                        Call Cancela_Ingreso()
                        Call Calcular_Totales_Letras()
                    End With
                End If
            End If
            If Var1 = 2 Then
                With Dgv02
                    Dim pos As Integer = .CurrentCellAddress.Y
                    Call Agregar_Registro(pos)
                    Call Cancela_Ingreso()
                    Call Calcular_Totales_Letras()
                End With
            End If
            BtnAdd.Focus()
        End If
    End Sub
    Private Sub Agregar_Registro(ByVal Pos As Integer)
        With Dgv02
            .Rows(Pos).Cells("Letra").Value = TxtNro_Letra.Text
            .Rows(Pos).Cells("Dias").Value = TxtDias.Text
            .Rows(Pos).Cells("Fecha_Giro").Value = DtpFec_Giro.Text
            .Rows(Pos).Cells("Fecha_Venci").Value = DtpFec_Venci.Text
            .Rows(Pos).Cells("Importe").Value = Format(Val(TxtImporte.Text), Forma_1_2)
        End With
    End Sub
    'Metodo que nos permite calcular los totales
    Private Sub Calcular_Totales_Letras()
        With Dgv02
            Dim Total As Decimal = 0
            Dgv04.Rows(0).Cells("Total_1").Value = ""
            For i = 0 To .RowCount - 1
                Total = Total + Val(.Rows(i).Cells("Importe").Value)
            Next
            Dgv04.Rows(0).Cells("Total_1").Value = Format(Total, Forma_1_2)
        End With
    End Sub
    'Metodo que nos permite calcular los totales de facturas
    Private Sub Calcular_Totales_Fact()
        With Dgv01
            Dim Total As Decimal = 0
            Dgv03.Rows(0).Cells("Total_2").Value = ""
            For i = 0 To .RowCount - 1
                If Dgv01.Rows(i).Cells("Check").Value = True Then
                    Total = Total + Val(.Rows(i).Cells("Total").Value)
                End If
            Next
            Dgv03.Rows(0).Cells("Total_2").Value = Format(Total, Forma_1_2)
        End With
    End Sub
    'cancelamos registro...
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Call Cancela_Ingreso()
    End Sub

    Private Sub TxtDias_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDias.KeyPress
        Call solonumeros(e)
    End Sub

    Private Sub TxtDias_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDias.TextChanged
        DtpFec_Venci.Text = DateAdd("d", Val(TxtDias.Text), DtpFec_Giro.Text)
    End Sub

    Private Sub TxtImporte_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtImporte.KeyPress
        Call solonumeros(e)
    End Sub

    Private Sub TxtImporte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtImporte.TextChanged

    End Sub

    Private Sub FrmLetras_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
   
    End Sub

    Private Sub FrmLetras_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmLetras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dgv03.Rows.Add() : Dgv04.Rows.Add()
        c_Neg_StatusLetra.Get_StatusLetra_Cbo(" order by c_codi_StLetra", CboStatus)
        Dgv06.Rows.Add() : Dgv08.Rows.Add()
        c_Neg_MnBcos.get_MnBcos_Cbo(" order by c_codi_bco", CboBanco)
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_nick_mon", CboMon)
        Call Validar_Permiso(Me.Name, BtnRenova, BtnEditar, BtnEliminar)
    End Sub
   
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        Call Mostrar_documentos()
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick
        If e.RowIndex = -1 Then
            Return
        End If
        If Dgv01.Columns(e.ColumnIndex).Name = "Check" Then
            Dgv02.Rows.Clear()
            Call Calcular_Totales_Fact()
            Call Calcular_Totales_Letras()
        End If
    End Sub
    Private Sub Dgv01_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.CurrentCellDirtyStateChanged
        If Dgv01.IsCurrentCellDirty Then
            Dgv01.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Call Buscar_TpoCambio(DtpFec_Giro.Text, TxtTC) 'mostramos el tipo de cambio 
        If Dgv02.RowCount > 0 Then
            If Val(TxtTC.Text) > 0 Then
                If Len(TxtCod_Prov.Text) > 0 Then
                    If CboMon.SelectedIndex > -1 Then 'Validamos el ingreso...
                        If Val(Dgv03.Rows(0).Cells(1).Value) = Val(Dgv04.Rows(0).Cells(1).Value) Then
                            Dim F As String = MsgBox("¿Desea grabar el registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Compañia)
                            If F = vbYes Then Call Grabar_Letras("ADD")
                            Call Cancela_Ingreso()
                            Dgv01.Rows.Clear() : Dgv02.Rows.Clear()
                            Call Limpiar_Texto(Pan01) : CboMon.SelectedIndex = -1
                        Else
                            MsgBox("5. Los montos totales deben ser iguales...", MsgBoxStyle.Critical, Compañia)
                        End If
                    Else
                        MsgBox("1. Falta seleccionar el tipo de moneda...", MsgBoxStyle.Critical, Compañia)
                    End If
                Else
                    MsgBox("2. Falta seleccionar el proveedor...", MsgBoxStyle.Critical, Compañia)
                End If
            Else
                MsgBox("3. Falta ingresar el tipo de cambio...", MsgBoxStyle.Critical, Compañia)
            End If
        Else
            MsgBox("4. Falta seleccionar un documento...", MsgBoxStyle.Critical, Compañia)
        End If
    End Sub
    Private Sub Modificar_Letra()
        Dim moneda As String = ""
        'Validamos el tipo de moneda que se esta emitiendo la letra...
        If TxtMon.Text = "S/." Then
            moneda = "01"
        Else
            moneda = "02"
        End If
        'Grabamos Detalles 
        With c_Ent_LetCab
            .c_nro_liq = TxtNro_Liq.Text
            .c_id_letra = 1 'numeros de letras
            .c_nro_letra = TxtLetra_2.Text
            .c_codi_prove = TxtCod_Prov2.Text : .c_codi_mon = moneda
            .c_codi_stletra = Strings.Right(CboStatus.Text, 2)
            .c_nro_dias = DateDiff("d", DtpFec_Giro1.Text, DtpFec_Venci1.Text)
            .c_fecha_giro = DtpFec_Giro1.Text
            .c_fecha_venci = DtpFec_Venci1.Text
            .c_codi_bco = CboBanco.SelectedValue : .c_mt_anula = "" : .c_nro_unico = TxtNro_Unico.Text
            .c_imp_letra = Val(TxtImporte2.Text)
            .c_renovac_letra = 0
            .c_tpo_cambio = Val(TxtTC2.Text)
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = "EDI"
            TxtNro_Liq.Text = c_Neg_LetCab.set_LetCab_Save(c_Ent_LetCab, FrmMenu.TxtCod_Emp.Text)
        End With
        MsgBox("Registro se grabo correctamente...", MsgBoxStyle.Exclamation, Compañia)
    End Sub
    Private Sub Grabar_Letras(ByVal cOpcion As String)
        With Dgv02
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    With c_Ent_LetCab
                        .c_nro_liq = TxtNro_Liq.Text
                        .c_id_letra = i + 1 'numeros de letras
                        .c_nro_letra = Dgv02.Rows(i).Cells("Letra").Value
                        .c_codi_prove = TxtCod_Prov.Text : .c_codi_mon = CboMon.SelectedValue
                        .c_codi_stletra = "01"
                        .c_nro_dias = Dgv02.Rows(i).Cells("Dias").Value
                        .c_fecha_giro = Dgv02.Rows(i).Cells("Fecha_Giro").Value
                        .c_fecha_venci = Dgv02.Rows(i).Cells("Fecha_Venci").Value
                        .c_codi_bco = "00" : .c_mt_anula = "" : .c_nro_unico = ""
                        .c_imp_letra = Val(Dgv02.Rows(i).Cells("Importe").Value)
                        .c_renovac_letra = 0
                        .c_tpo_cambio = Val(TxtTC.Text)
                        .c_usuario = FrmMenu.lblusuario.Text
                        .copcion = cOpcion
                        TxtNro_Liq.Text = c_Neg_LetCab.set_LetCab_Save(c_Ent_LetCab, FrmMenu.TxtCod_Emp.Text)
                        With Dgv01 '-GRABAMOS EL DETALLE DE LA LETRA AMARRADAS...
                            If .RowCount > 0 Then
                                For u = 0 To .RowCount - 1 'Validamos que el check se encuentre activo...
                                    If .Rows(u).Cells("Check").Value = True Then
                                        With c_Ent_LetDet
                                            .c_nro_letra = Dgv02.Rows(i).Cells("Letra").Value
                                            .c_codi_prov = TxtCod_Prov.Text
                                            .c_nro_ing = Dgv01.Rows(u).Cells("c_nro_ing").Value
                                            .c_monto_doc = Val(Dgv01.Rows(u).Cells("Total").Value)
                                            .c_id_letra = Dgv02.RowCount
                                            .c_codi_mon = CboMon.SelectedValue
                                            .c_codi_doc = Dgv01.Rows(u).Cells("c_codi_doc").Value
                                            'VALIDAMOS SI DOCUMENTO ES UNA FACTURA O UNA LETRA PARA ENVIAR LOS NUMEROS DE SERIE...
                                            If Dgv01.Rows(u).Cells("c_codi_doc").Value <> "05" Then ' todos los documentos menos letras 
                                                .c_serie_doc = Dgv01.Rows(u).Cells("c_nro_serie").Value
                                                .c_nro_doc = Dgv01.Rows(u).Cells("doc").Value
                                            Else ' solo para letras
                                                .c_serie_doc = ""
                                                .c_nro_doc = Dgv01.Rows(u).Cells("doc").Value
                                            End If
                                            .c_fecha_giro = Dgv02.Rows(0).Cells("Fecha_Giro").Value
                                            .c_tpo_cambio = Val(TxtTC.Text)
                                            .copcion = cOpcion
                                            c_Neg_LetDet.set_LetDet_Save(c_Ent_LetDet, FrmMenu.TxtCod_Emp.Text)
                                        End With
                                    End If
                                Next
                            End If
                        End With
                    End With
                Next
                MsgBox("Registro se grabo correctamente...", MsgBoxStyle.Exclamation, Compañia)
            End If
        End With
    End Sub
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    'buscamos tipo de cambio ni bien cae el enfoque
    Private Sub DtpFec_Giro_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtpFec_Giro.GotFocus
        Call Buscar_TpoCambio(DtpFec_Giro.Text, TxtTC)
    End Sub

    Private Sub DtpFec_Giro_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Giro.ValueChanged
        Call Buscar_TpoCambio(DtpFec_Giro.Text, TxtTC)
    End Sub
    Private Sub Buscar_TpoCambio(ByVal Fecha As Date, ByVal x As TextBox)
        With c_Neg_TpoCambio.get_TpoCambio_Datos(" and c_fecha_cbo='" & Fecha & "'", "DAT")
            x.Clear()
            If .Rows.Count > 0 Then x.Text = Format(Val(.Rows(0)("c_compra_sunat").ToString), Forma_1_3)
        End With
    End Sub
    ' Consultamos Letras '
    Private Sub BtnConLetra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnConLetra.Click
        With FrmConLetras
            .MdiParent = FrmMenu : .Show()
            .Cargar_Grid(" and C.c_codi_prov='" & TxtCod_Prov2.Text & "' and C.c_anula_reg=0 order by C.c_fecha_venci")
            .TxtVar.Text = 1
            .TxtCod_Prov.Text = TxtCod_Prov2.Text
            .Text = "Listado de Letras [" & RTrim(TxtProv2.Text) & "]"
        End With
    End Sub

    Private Sub BtnMostrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar2.Click
        Call Mostrar_Letras()
    End Sub
    Public Sub Mostrar_Letras()
        With c_Neg_LetCab.get_LetCab_Datos(" and L.c_codi_prov='" & TxtCod_Prov2.Text & "' and L.c_nro_letra='" & TxtNro_Letra2.Text & _
                                           "' and L.c_anula_reg=0", "DAT", FrmMenu.TxtCod_Emp.Text)
            Dim Cant_Let As Integer = 0 'Variable que nos permitira saber cuantos documentos estan amarradas a la letra...
            If .Rows.Count > 0 Then
                TxtLetra_2.Text = .Rows(0)("c_nro_letra").ToString
                DtpFec_Giro.Text = FormatDateTime(.Rows(0)("c_fecha_giro").ToString, DateFormat.ShortDate)
                DtpFec_Venci1.Text = FormatDateTime(.Rows(0)("c_fecha_venci").ToString, DateFormat.ShortDate)
                TxtNro_Unico.Text = .Rows(0)("c_nro_unico").ToString
                TxtNro_Liq2.Text = .Rows(0)("c_nro_liq").ToString
                'Obtenemos la cantidad de documentos anexados a la letra...
                With c_Neg_LetCab.get_LetCab_Datos(" and L.c_nro_liq='" & .Rows(0)("c_nro_liq").ToString & "'  and L.c_anula_reg=0 order by c_id_let desc", _
                                                   "DAT", FrmMenu.TxtCod_Emp.Text)
                    If .Rows.Count > 0 Then Cant_Let = Val(.Rows(0)("c_id_let").ToString)
                End With
                'Validamos el tipo de moneda soles o dolares...
                If .Rows(0)("c_codi_mon").ToString = "01" Then
                    TxtMon.Text = "S/."
                Else
                    TxtMon.Text = "$."
                End If
                TxtImporte2.Text = Format(Val(.Rows(0)("c_imp_letra").ToString), Forma_1_2)
                'Mostramos status de letra
                For i = 0 To CboStatus.Items.Count - 1
                    If Strings.Right(CboStatus.Items(i).ToString, 2) = .Rows(0)("c_codi_stletra").ToString Then
                        CboStatus.SelectedIndex = i
                        i = CboStatus.Items.Count
                    End If
                Next
                'MOSTRAMOS EL BANCO
                For i = 0 To CboBanco.Items.Count - 1
                    If Strings.Right(CboBanco.Items(i).ToString, 2) = .Rows(0)("c_codi_bco").ToString Then
                        CboBanco.SelectedIndex = i
                        i = CboBanco.Items.Count
                    End If
                Next
                TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                TxtCancel.Text = Format(Val(.Rows(0)("c_imp_saldo").ToString), Forma_1_2)
                TxtTC2.Text = Format(Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_3)
                'Validamos si documento se encuentra anulado
                If Val(.Rows(0)("c_anula_reg").ToString) = 0 Then
                    If Val(.Rows(0)("c_imp_saldo").ToString) > 0 Then
                        BtnEstado.Text = "PENDIENTE" : BtnEstado.BackColor = Color.Maroon
                    Else
                        BtnEstado.Text = "CANCELADO" : BtnEstado.BackColor = Color.Gray
                    End If
                Else
                    BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Color.Red
                End If
                LblTitulo.Text = "Por esta LETRA DE CAMBIO, se servirá(n) pagar incondicionalmente a 31 dias a la orden de: " & TxtProv2.Text
                'Cargamos las letras amarradas...
                With c_Neg_LetDet.get_LetDet_Datos(" and D.c_codi_doc='05' and D.c_nro_letra='" & TxtLetra_2.Text & "' And D.c_codi_prov='" & _
                                                   TxtCod_Prov2.Text & "' And D.c_anula_reg=0", "DA2", FrmMenu.TxtCod_Emp.Text)
                    Dgv05.Rows.Clear()
                    Dim Total As Decimal = 0
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dgv05.Rows.Add()
                            Dgv05.Rows(i).Cells("Tipo").Value = "LETRA"
                            Dgv05.Rows(i).Cells("Nro").Value = "000"
                            Dgv05.Rows(i).Cells("Docu").Value = .Rows(i)("c_nro_ing").ToString
                            If .Rows(i)("c_codi_mon").ToString = "01" Then
                                Dgv05.Rows(i).Cells("Mon").Value = "S/."
                            Else
                                Dgv05.Rows(i).Cells("Mon").Value = "$."
                            End If
                            Dgv05.Rows(i).Cells("Import").Value = Format(Val(.Rows(i)("c_monto_doc").ToString), Forma_1_2)
                            Total = Total + Val(.Rows(i)("c_monto_doc").ToString)
                        Next
                    End If
                    Dgv06.Rows(0).Cells(1).Value = Format(Total, Forma_2_2)
                End With
                'Cargamos las facturas...
                With c_Neg_LetDet.get_LetDet_Datos(" and D.c_codi_doc='01' and D.c_nro_letra='" & TxtLetra_2.Text & "' and D.c_codi_prov='" & _
                                                   TxtCod_Prov2.Text & "' and D.c_anula_reg=0", "DAT", FrmMenu.TxtCod_Emp.Text)
                    Dgv07.Rows.Clear()
                    Dim Total2 As Decimal = 0
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dgv07.Rows.Add()
                            Dgv07.Rows(i).Cells("Tipo2").Value = "FACTURA"
                            Dgv07.Rows(i).Cells("Nro2").Value = .Rows(i)("c_serie_doc")
                            Dgv07.Rows(i).Cells("Doc2").Value = .Rows(i)("c_nro_doc").ToString
                            If .Rows(i)("c_codi_mon").ToString = "01" Then
                                Dgv07.Rows(i).Cells("Mon2").Value = "S/."
                            Else
                                Dgv07.Rows(i).Cells("Mon2").Value = "$."
                            End If
                            Dgv07.Rows(i).Cells("Importe2").Value = Format(Val(.Rows(i)("c_monto_doc").ToString) / Cant_Let, Forma_1_2)
                            Dgv07.Rows(i).Cells("c_nro_ing2").Value = .Rows(i)("c_nro_ing").ToString
                            Total2 = Total2 + (Val(.Rows(i)("c_monto_doc").ToString) / Cant_Let)
                        Next
                    End If 'Total del Registro
                    Dgv08.Rows(0).Cells(1).Value = Format(Total2, Forma_2_2)
                End With
            End If
        End With
    End Sub
    'Mostramos la letra al presionar la tecla enter...
    Private Sub TxtNro_Letra2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtNro_Letra2.KeyDown
        If e.KeyCode = Keys.Enter Then If BtnMostrar2.Enabled = True Then Call BtnMostrar2_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtPor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtPor.KeyPress
        Call solonumeros(e)
    End Sub
    'porcentaje...
    Private Sub TxtPor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPor.TextChanged
        TxtImporte3.Text = Format(Val(TxtImporte2.Text) * Val(TxtPor.Text) / 100, Forma_1_2)
    End Sub

    Private Sub TxtImporte3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtImporte3.KeyPress
        Call solonumeros(e)
    End Sub

    Private Sub TxtImporte3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtImporte3.TextChanged

    End Sub

    Private Sub TxtImporte4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtImporte4.KeyPress
        Call solonumeros(e)
    End Sub

    Private Sub TxtImporte4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtImporte4.TextChanged

    End Sub

    Private Sub TxtDias_3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDias_3.KeyPress
        Call solonumeros(e)
    End Sub

    Private Sub TxtDias_3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDias_3.TextChanged

    End Sub

    Private Sub TxtDias_4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtDias_4.KeyPress
        Call solonumeros(e)
    End Sub

    Private Sub TxtDias_4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtDias_4.TextChanged

    End Sub
    'Renovación de letra...
    Private Sub BtnRenova_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRenova.Click
        If UCase(BtnEstado.Text) = "PENDIENTE" Then
            If Len(TxtLetra_2.Text) > 0 Then
                Call Limpiar_Texto(PanRenova)
                PanRenova.Visible = True
                TxtLetra_3.Text = TxtLetra_2.Text
                DtpFec_Giro3.Text = DtpFec_Giro1.Text
                DtpFec_Venci3.Text = DtpFec_Venci1.Text
                TxtMon3.Text = TxtMon.Text : TxtMon4.Text = TxtMon.Text
                TxtDias_3.Text = DateDiff("d", DtpFec_Giro3.Text, DtpFec_Venci3.Text)
                Call Nuevo_Ingreso_2()
                TxtPor.Focus()
            Else
                MsgBox("1. Debe seleccionar un registro, para poder realizar la renovación...", MsgBoxStyle.Critical, Compañia)
            End If
        Else
            MsgBox("2. Registro se encuentra cerrado o esta anulado, no podra realizar ninguna operación...", MsgBoxStyle.Critical, Compañia)
        End If
    End Sub
    Private Sub Nuevo_Ingreso_2()
        BtnGrabar2.Enabled = True
        BtnCerrar2.Text = "&Cancelar"
        Pan05.Enabled = False
        Pan08.Enabled = False
    End Sub
    Private Sub Cancela_Ingreso_2()
        BtnGrabar2.Enabled = False
        BtnCerrar2.Text = "Cerrar"
        Pan05.Enabled = True
        PanRenova.Visible = False
        DtpFec_Giro1.Enabled = False
        DtpFec_Venci1.Enabled = False
        CboStatus.Enabled = False
        TxtNro_Unico.Enabled = False
        Pan08.Enabled = True

    End Sub
    'Metodo que nos permite validar si se esta ingresando dos veces una misma letra de un mismo proveedor....
    Private Sub Validar_Ingreso_Renovacion(ByVal x As TextBox)
        With c_Neg_LetCab.get_LetCab_Datos(" and L.c_nro_letra='" & TxtLetra_4.Text & "' and L.c_anula_reg=0 and L.c_codi_prov='" & _
                                           TxtCod_Prov2.Text & "'", "DAT", FrmMenu.TxtCod_Emp.Text)
            x.Clear()
            If .Rows.Count > 0 Then
                x.Text = 1
            End If
        End With
    End Sub
    Private Sub BtnGrabar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar2.Click
        If CboBanco.SelectedIndex > -1 Then
            Dim x As New TextBox
            If PanRenova.Visible = True Then
                Call Validar_Ingreso_Renovacion(x)
                If Val(x.Text) = 0 Then
                    If Val(TxtTC4.Text) > 0 Then
                        If Val(TxtDias_4.Text) > 0 Then
                            If Val(TxtImporte4.Text) > 0 Then
                                Dim f As String = MsgBox("¿Desea grabar el registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Compañia)
                                If f = vbYes Then
                                    Call Grabar_Letra_Renovacion()
                                    Call Cancela_Ingreso_2()
                                End If
                            Else
                                MsgBox("1. Falta ingresar el monto de la letra", MsgBoxStyle.Critical, Compañia)
                            End If
                        Else
                            MsgBox("2. Falta ingresar el número de días", MsgBoxStyle.Critical, Compañia)
                        End If
                    Else
                        MsgBox("3. Falta ingresar el tipo de cambio para la letra...", MsgBoxStyle.Critical, Compañia)
                    End If
                Else
                    MsgBox("4. La letra ya fue ingresada anteriormente...", MsgBoxStyle.Critical, Compañia)
                End If
            Else
                If Val(TxtTC2.Text) > 0 Then
                    Dim f As String = MsgBox("¿Desea grabar el registro?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, Compañia)
                    If f = vbYes Then
                        Call Modificar_Letra()
                        Call Cancela_Ingreso_2()
                    End If
                Else
                    MsgBox("1. Falta ingresar el tipo de cambio para la letra...", MsgBoxStyle.Critical, Compañia)
                End If
            End If
        Else
            MsgBox("Falta seleccionar el banco...", vbCritical, Compañia)
        End If
    End Sub
    Private Sub Grabar_Letra_Renovacion()
        With c_Ent_LetCab
            .c_nro_liq = ""
            .c_id_letra = 1 'numeros de letras
            .c_nro_letra = TxtLetra_4.Text
            .c_codi_prove = TxtCod_Prov2.Text : .c_codi_mon = CboMon.SelectedValue
            .c_codi_stletra = "01"
            .c_nro_dias = Val(TxtDias_4.Text)
            .c_fecha_giro = DtpFec_Giro4.Text
            .c_fecha_venci = DtpFec_Venci4.Text
            .c_codi_bco = "00" : .c_mt_anula = "" : .c_nro_unico = TxtNro_Unico.Text
            .c_imp_letra = Val(TxtImporte4.Text)
            .c_renovac_letra = 0
            .c_tpo_cambio = Val(TxtTC4.Text)
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = "ADD"
            TxtNro_Liq.Text = c_Neg_LetCab.set_LetCab_Save(c_Ent_LetCab, FrmMenu.TxtCod_Emp.Text)
            'Grabamos el detalle de la factura...
            With c_Ent_LetDet
                .c_nro_letra = TxtLetra_4.Text
                .c_codi_prov = TxtCod_Prov2.Text
                .c_nro_ing = TxtLetra_3.Text
                .c_monto_doc = Val(TxtImporte2.Text)
                .c_id_letra = 1
                .c_codi_mon = CboMon.SelectedValue
                .c_codi_doc = "05"
                'VALIDAMOS SI DOCUMENTO ES UNA FACTURA O UNA LETRA PARA ENVIAR LOS NUMEROS DE SERIE...
                .c_serie_doc = ""
                .c_nro_doc = TxtLetra_3.Text
                .copcion = "ADD"
                c_Neg_LetDet.set_LetDet_Save(c_Ent_LetDet, FrmMenu.TxtCod_Emp.Text)
            End With
        End With
        MsgBox("Registro se grabo correctamente...", MsgBoxStyle.Exclamation, Compañia)
    End Sub
    Private Sub DtpFec_Giro4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Giro4.ValueChanged
        Call Buscar_TpoCambio(DtpFec_Giro4.Text, TxtTC4)
    End Sub
    'Cerramos ventana para la pagina numero dos...
    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        If BtnCerrar2.Text = "Cerrar" Then
            Me.Close()
        Else
            Call Cancela_Ingreso_2() : Call Validar_Permiso(Me.Name, BtnRenova, BtnEditar, BtnEliminar)
        End If
    End Sub
    'Editamos registro...
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        If ValidarCierre(DtpFec_Giro1.Text) = True Then
            'Validamos si letra se encuentra cerrada o anulada para poder realizar alguna modificación el registro deberá estar como pendiente...
            If BtnEstado.Text = "CANCELADO" Or UCase(BtnEstado.Text) = "ANULADO" Then
                MsgBox("Registro se encuentra cancelado o Anulado, no podra realizar ninguna modificación...", MsgBoxStyle.Critical, Compañia)
            Else
                If Len(TxtLetra_2.Text) > 0 Then
                    Call Nuevo_Ingreso_2()
                    DtpFec_Giro1.Enabled = True
                    DtpFec_Venci1.Enabled = True
                    CboStatus.Enabled = True
                    TxtNro_Unico.Enabled = True
                Else
                    MsgBox("Para modificar debe seleccionar una letra...", MsgBoxStyle.Critical, Compañia)
                End If
            End If
        End If
    End Sub
    'BUSCAMOS EL TIPO DE CAMBIO PARA MODIFICARLO...
    Private Sub DtpFec_Giro1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtpFec_Giro1.ValueChanged
        Call Buscar_TpoCambio(DtpFec_Giro1.Text, TxtTC2)
    End Sub

    Private Sub TxtProv2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProv2.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon_2.Enabled = True Then Call BtnCon_2_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtProv2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProv2.TextChanged

    End Sub
    ' Consultamos '
    Private Sub BtnCon_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCon_1.Click
        FrmConProve.Show() : FrmConProve.MdiParent = FrmMenu
        FrmConProve.Cargar_Grid(" and c_anula_reg=0 order by c_desc_prov")
        FrmConProve.TxtVar.Text = 5
    End Sub

    Private Sub TxtProv_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtProv.KeyDown
        If e.KeyCode = Keys.F1 Then If BtnCon_1.Enabled = True Then Call BtnCon_1_Click(Nothing, Nothing)
    End Sub

    Private Sub TxtProv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtProv.TextChanged

    End Sub
    'Eliminamos registro...
    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        If ValidarCierre(DtpFec_Giro1.Text) = True Then
            If Len(TxtLetra_2.Text) > 0 Then
                If UCase(BtnEstado.Text) = "PENDIENTE" Then
                    Dim F As String = MsgBox("¿Confirma la eliminación del registro...?", vbYesNo + MsgBoxStyle.Question, Compañia)
                    If F = vbYes Then
                        Call Eliminar_Letras()
                        BtnEstado.Text = "ANULADO" : BtnEstado.BackColor = Color.Red
                    End If
                Else
                    MsgBox("1. Documento se encuentra cerrado o esta anulado, no podra realizar ninguna operación...", MsgBoxStyle.Critical, Compañia)
                End If
            Else
                MsgBox("2. Falta seleccionar un registro...", MsgBoxStyle.Critical, Compañia)
            End If
        End If
    End Sub
    'Metodo que nos permite eliminar letras y devolver los saldos...
    Private Sub Eliminar_Letras()
        Dim moneda As String = ""
        'Validamos el tipo de moneda que se esta emitiendo la letra...
        If TxtMon.Text = "S/." Then
            moneda = "01"
        Else
            moneda = "02"
        End If
        With c_Ent_LetCab
            .c_nro_liq = TxtNro_Liq2.Text
            .c_id_letra = Val(TxtId_Letra.Text) 'numeros de letras)
            .c_nro_letra = TxtLetra_2.Text
            .c_codi_prove = TxtCod_Prov2.Text : .c_codi_mon = moneda
            .c_codi_stletra = "01"
            .c_nro_dias = 0 : .c_fecha_giro = Now.Date
            .c_fecha_venci = Now.Date
            .c_codi_bco = "00" : .c_mt_anula = "" : .c_nro_unico = TxtNro_Unico.Text
            .c_imp_letra = Val(TxtImporte2.Text)
            .c_renovac_letra = 0 : .c_tpo_cambio = 0
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = "DEL"
            c_Neg_LetCab.set_LetCab_Save(c_Ent_LetCab, FrmMenu.TxtCod_Emp.Text)
            'Grabamos el detalle de las letras amarradas a una misma letra...
            With Dgv05
                For i = 0 To .RowCount - 1
                    With c_Ent_LetDet
                        .c_nro_letra = TxtLetra_2.Text
                        .c_codi_prov = TxtCod_Prov2.Text
                        .c_nro_ing = Dgv05.Rows(i).Cells("docu").Value
                        .c_monto_doc = Val(Dgv05.Rows(i).Cells("Import").Value)
                        .c_id_letra = 0
                        .c_codi_mon = moneda
                        .c_codi_doc = "05"
                        'VALIDAMOS SI DOCUMENTO ES UNA FACTURA O UNA LETRA PARA ENVIAR LOS NUMEROS DE SERIE...
                        .c_serie_doc = ""
                        .c_nro_doc = Dgv05.Rows(i).Cells("docu").Value
                        .copcion = "DEL"
                        c_Neg_LetDet.set_LetDet_Save(c_Ent_LetDet, FrmMenu.TxtCod_Emp.Text)
                    End With
                Next
            End With
            'Grabamos el Detalle de facturas amarradas a la letra...
            With Dgv07
                For i = 0 To .RowCount - 1
                    With c_Ent_LetDet
                        .c_nro_letra = TxtLetra_2.Text
                        .c_codi_prov = TxtCod_Prov2.Text
                        .c_nro_ing = Dgv07.Rows(i).Cells("c_nro_ing2").Value
                        .c_monto_doc = Val(Dgv07.Rows(i).Cells("Importe2").Value)
                        .c_id_letra = 0
                        .c_codi_mon = moneda
                        .c_codi_doc = "01"
                        'VALIDAMOS SI DOCUMENTO ES UNA FACTURA O UNA LETRA PARA ENVIAR LOS NUMEROS DE SERIE...
                        .c_serie_doc = Dgv07.Rows(i).Cells("nro2").Value
                        .c_nro_doc = Dgv07.Rows(i).Cells("doc2").Value
                        .copcion = "DEL"
                        c_Neg_LetDet.set_LetDet_Save(c_Ent_LetDet, FrmMenu.TxtCod_Emp.Text)
                    End With
                Next
            End With

        End With
        MsgBox("Registro se anulo correctamente...", MsgBoxStyle.Critical, Compañia)
    End Sub

End Class