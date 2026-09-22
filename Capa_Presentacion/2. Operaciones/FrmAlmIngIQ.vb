Public Class FrmAlmIngIQ

    Dim vEdit As Integer = 0 : Dim Focos As Integer = 0
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
    ' Mostramos datos al presionar la tecla enter '
    Private Sub TxtOC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtOC.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtOC.Text) > 0 Then
                TxtOC.Text = Strings.Right(Val(TxtOC.Text) + 10000000, 7) : Dgv02.Rows.Clear()
                If Val(TxtOpc_Devol.Text) = 1 Then
                    Call Mostrar_GuiaRemision()
                Else
                    Call Mostrar_Oc(0, 2)
                    Focos = 1
                    TxtSerie_Guia.Focus()
                End If
            End If
        End If
    End Sub
    ' metodo para mostrar datos de la guia de remision para devolucion '
    Private Sub Mostrar_GuiaRemision()
        With c_Neg_AlmSal.get_AlmSalTa_Datos(" and S.c_nro_Serie='" & TxtSerie_OC.Text & "' and S.c_nro_salidaTA='" & TxtOC.Text & "' and S.c_anula_reg=0" _
                                             , "DAT", FrmMenu.TxtCod_Emp.Text)
            If .Rows.Count > 0 Then
                If Val(.Rows(0)("c_fact_guia").ToString) <> 1 Then
                    Pan09.Enabled = True : BtnAdd.Enabled = False
                    Dim cCodiMt, cDescMt As String
                    cCodiMt = TxtCodMt.Text
                    cDescMt = TxtDescMt.Text
                    Call Limpiar_Texto(Pan01) : Dgv02.Rows.Clear()
                    Focos = 1
                    TxtSerie_Guia.Focus()
                    ' lo tuvimos que hacer porque cuando se limpia no pemite grabar
                    TxtCodMt.Text = cCodiMt : TxtDescMt.Text = cDescMt
                    TxtSerie_OC.Text = .Rows(0)("c_nro_serie").ToString
                    TxtOC.Text = .Rows(0)("c_nro_salidaTA").ToString
                    TxtCod_Prove.Text = .Rows(0)("c_codi_clie").ToString
                    TxtProve.Text = .Rows(0)("c_desc_clie").ToString
                    TxtDir.Text = .Rows(0)("c_direc_clie").ToString
                    TxtObs.Text = .Rows(0)("c_obs").ToString
                    TxtCod_Mon.Text = "01"
                    Mostrar_TpoCambio(DtpFec_Ing.Text, TxtTc)
                    TxtRuc.Text = .Rows(0)("c_ruc_clie").ToString
                    TxtTotal.Text = 0 ' Val(.Rows(0)("c_imp_total").ToString)
                    With c_Neg_AlmSalDet.get_AlmSalTaDet_Datos(" and D.c_anula_reg=0 and D.c_nro_serie='" & TxtSerie_OC.Text & "' and D.c_nro_salidaTA='" & TxtOC.Text & "' and D.c_nro_cant>D.c_cant_devol ", "DAT", FrmMenu.TxtCod_Emp.Text)
                        If .Rows.Count > 0 Then
                            For i = 0 To .Rows.Count - 1
                                Dgv02.Rows.Add()
                                Dgv02.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_nro_cant").ToString) - Val(.Rows(i)("c_cant_devol").ToString), Forma_1_2)
                                Dgv02.Rows(i).Cells("Original").Value = Format(Val(.Rows(i)("c_nro_cant").ToString) - Val(.Rows(i)("c_cant_devol").ToString), Forma_1_2)
                                Dgv02.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                                Dgv02.Rows(i).Cells("Mot").Value = .Rows(i)("c_codi_tg").ToString
                                Dgv02.Rows(i).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString
                                Dgv02.Rows(i).Cells("Scd").Value = .Rows(i)("c_codi_scd").ToString
                                Dgv02.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                                Dgv02.Rows(i).Cells("Descripcion").Value = .Rows(i)("c_desc_articulo").ToString
                                Dgv02.Rows(i).Cells("Precio").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_3)
                                Dgv02.Rows(i).Cells("Importe").Value = Val(.Rows(i)("c_imp_total").ToString)
                                Dgv02.Rows(i).Cells("Obs").Value = .Rows(i)("c_obs").ToString
                                Dgv02.Rows(i).Cells("c_Anula_reg").Value = 0
                                Dgv02.Rows(i).Cells("c_codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                                Dgv02.Rows(i).Cells("c_correl_oc").Value = .Rows(i)("c_nro_correl").ToString
                                Dgv02.Rows(i).Cells("Item").Value = ""
                                Dgv02.Rows(i).Cells("Afecto").Value = 0
                            Next
                        End If
                    End With
                Else
                    MsgBox("1.1 Registro ya fue ingresado anteriormente...", vbCritical, Compañia)
                End If
            Else
                MsgBox("1.2 No existe guía de remisión...", vbCritical, Compañia)
            End If
        End With
    End Sub
    ' metodo para mostrar datos de la orden de compra '
    Private Sub Mostrar_Oc(ByVal c_estado_oc As Integer, ByVal c_estado_oc_2 As Integer)
        Dim c_Estado As Integer = 0
        With c_Neg_OC.get_OC_Datos(" and O.c_nro_Serie='" & TxtSerie_OC.Text & "' and O.c_nro_oc='" & TxtOC.Text & "' and O.c_anula_reg=0", FrmMenu.TxtCod_Emp.Text, "DAT")
            If .Rows.Count > 0 Then
                If Val(.Rows(0)("c_estado_oc").ToString) = c_estado_oc Or Val(.Rows(0)("c_estado_oc").ToString) = c_estado_oc_2 Then

                    Dim c_codi_mt As String = TxtCodMt.Text
                    Dim c_desc_mt As String = TxtDescMt.Text
                    Call Limpiar_Texto(Pan01) : Dgv02.Rows.Clear()
                    TxtCodMt.Text = c_codi_mt
                    TxtDescMt.Text = c_desc_mt

                    TxtSerie_OC.Text = .Rows(0)("c_nro_serie").ToString
                    TxtOC.Text = .Rows(0)("c_nro_oc").ToString
                    TxtCod_Prove.Text = .Rows(0)("c_codi_prov").ToString
                    TxtProve.Text = .Rows(0)("c_desc_prov").ToString
                    TxtDir.Text = .Rows(0)("c_direc_prov").ToString
                    TxtObs.Text = .Rows(0)("c_obs").ToString
                    TxtCod_Mon.Text = .Rows(0)("c_codi_mon").ToString
                    CboMon.SelectedValue = .Rows(0)("c_codi_mon").ToString
                    TxtTc.Text = Format(Val(.Rows(0)("c_tpo_cambio").ToString), Forma_1_3)
                    TxtRuc.Text = .Rows(0)("c_ruc_prov").ToString
                    TxtTotal.Text = Val(.Rows(0)("c_imp_total").ToString)
                    c_Estado = Val(.Rows(0)("c_estado_oc").ToString)
                    With c_Neg_OCDet.get_OCDet_Datos(" and D.c_anula_reg=0 and D.c_nro_serie='" & TxtSerie_OC.Text & "' and D.c_nro_oc='" & TxtOC.Text & "'", FrmMenu.TxtCod_Emp.Text, "DAT")
                        If .Rows.Count > 0 Then
                            For i = 0 To .Rows.Count - 1
                                Dgv02.Rows.Add()
                                If c_Estado = 0 Then
                                    Dgv02.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), Forma_1_4)
                                Else
                                    Dgv02.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_pend_cant").ToString), Forma_1_4)
                                End If
                                Dgv02.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                                Dgv02.Rows(i).Cells("Mot").Value = .Rows(i)("c_codi_tg").ToString
                                Dgv02.Rows(i).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString
                                Dgv02.Rows(i).Cells("Scd").Value = .Rows(i)("c_codi_scd").ToString
                                Dgv02.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                                Dgv02.Rows(i).Cells("Descripcion").Value = .Rows(i)("c_desc_scd").ToString
                                Dgv02.Rows(i).Cells("Precio").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_3)
                                Dgv02.Rows(i).Cells("Importe").Value = Val(.Rows(i)("c_imp_total").ToString)
                                Dgv02.Rows(i).Cells("Obs").Value = .Rows(i)("c_obs").ToString
                                Dgv02.Rows(i).Cells("c_Anula_reg").Value = 0
                                Dgv02.Rows(i).Cells("c_codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                                Dgv02.Rows(i).Cells("c_correl_oc").Value = .Rows(i)("c_nro_correl").ToString
                                Dgv02.Rows(i).Cells("Item").Value = ""
                                Dgv02.Rows(i).Cells("Afecto").Value = Val(.Rows(i)("c_opt_igv").ToString)
                            Next
                        End If
                    End With
                Else
                    MsgBox(" 2.1 Registro ya fue ingresado anteriormente...", vbCritical, Compañia)
                End If
            End If
        End With
    End Sub
    Private Sub TxtOC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOC.TextChanged

    End Sub
    ' Nuevo Registro '
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Tbc01.SelectedTab = Tab02 : Call Nuevo_Ingreso() : TxtCodMt.Focus() : DtpFec_Ing.Text = Now.Date : TxtNro_Ing.Text = ""
        Pan09.Enabled = False : Pan10.Enabled = False : CboAlm.SelectedIndex = 0 : TxtCodMt.Enabled = True
        CboMon.SelectedValue = "01" : TxtCodMt.Focus() : Call Mostrar_TpoCambio(DtpFec_Ing.Text, TxtTc)
    End Sub
    ' Nuevo Registro '
    Private Sub Nuevo_Ingreso()
        Call Limpiar_Texto(Pan01) : TxtSerie_OC.Enabled = True : TxtOC.Enabled = True : DtpFec_Ing.Enabled = True
        TxtDescMt.Enabled = True : CboAlm.Enabled = True : TxtSerie_Guia.Enabled = True : TxtNro_Guia.Enabled = True
        TxtObs.Enabled = True : TxtObs.Clear() : Dgv02.Rows.Clear() : TxtCodMt.Text = "" : TxtDescMt.Clear() : CboAlm.SelectedValue = ""
        TxtSerie_Guia.Clear() : TxtNro_Guia.Clear() : TxtCod_Mon.Clear() : TxtTotal.Clear() : BtnGrabar.Enabled = True
        BtnEstado.Visible = True : BtnEstado.Text = "Pendiente" : TxtDescMt.Enabled = False
    End Sub

    Private Sub TxtSerie_OC_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSerie_OC.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtSerie_OC.Text) > 0 Then
                TxtSerie_OC.Text = Strings.Right(Val(TxtSerie_OC.Text) + 1000, 3)
            End If
        End If
    End Sub

    Private Sub TxtSerie_OC_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSerie_OC.TextChanged

    End Sub

    Private Sub FrmAlmIngIQ_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And e.KeyCode = Keys.N Then If BtnNuevo.Enabled = True Then BtnNuevo_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.E Then If BtnEditar.Enabled = True Then BtnEditar_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then BtnGrabar_Click(Nothing, Nothing)
        If e.KeyCode = Keys.F4 Then
            If BtnGrabar.Enabled = True Then
                If TxtCodMt.Text = "12" And Val(TxtNro_Ing.Text) = 0 Then
                    Call cargarTransferencia()
                Else
                    MsgBox("Solo puede cargar guias cuando sea transferencias...", vbCritical, Compañia)
                End If
            End If
        End If
        'If e.Control And e.KeyCode = Keys.P Then If BtnImp.Enabled = True Then BtnImp_Click(Nothing, Nothing)
    End Sub
    Private Sub cargarTransferencia()
        With c_Neg_AlmSal.get_AlmSalTa_Datos(" and S.c_anula_reg=0 and S.c_codi_mt='16' and S.c_nro_serie='" & TxtSerie_Guia.Text &
                                                "' and S.c_nro_salidaTa='" & TxtNro_Guia.Text & "'", "DAT", "")
            If .Rows.Count > 0 Then
                Dgv02.Rows.Clear()
                With c_Neg_AlmSalDet.get_AlmSalTaDet_Datos(" and D.c_anula_reg=0 and D.c_nro_serie='" & TxtSerie_Guia.Text & "' and D.c_nro_salidaTA='" & TxtNro_Guia.Text & "' order by D.c_nro_correl", "DAT", FrmMenu.TxtCod_Emp.Text)
                    If .Rows.Count > 0 Then
                        DtpFec_Ing.Text = .Rows(0)("c_fecha_sal").ToString
                        For i = 0 To .Rows.Count - 1
                            Dgv02.Rows.Add()
                            Dgv02.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), Forma_1_4)
                            Dgv02.Rows(i).Cells("Original").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), Forma_1_2)
                            Dgv02.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                            Dgv02.Rows(i).Cells("Mot").Value = .Rows(i)("c_codi_tg").ToString
                            Dgv02.Rows(i).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString
                            Dgv02.Rows(i).Cells("Scd").Value = .Rows(i)("c_codi_scd").ToString
                            Dgv02.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                            Dgv02.Rows(i).Cells("Descripcion").Value = .Rows(i)("c_desc_articulo").ToString
                            Dgv02.Rows(i).Cells("Precio").Value = Format(Val(.Rows(i)("c_prec_unit").ToString), Forma_1_3)
                            Dgv02.Rows(i).Cells("Importe").Value = Val(.Rows(i)("c_imp_total").ToString)
                            Dgv02.Rows(i).Cells("Obs").Value = .Rows(i)("c_obs").ToString
                            Dgv02.Rows(i).Cells("c_Anula_reg").Value = 0
                            Dgv02.Rows(i).Cells("c_codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                            Dgv02.Rows(i).Cells("c_correl_oc").Value = .Rows(i)("c_nro_correl").ToString
                            Dgv02.Rows(i).Cells("Item").Value = ""
                            Dgv02.Rows(i).Cells("Afecto").Value = 0
                        Next
                    End If
                End With
            End If
        End With
    End Sub
    Private Sub FrmAlmIngIQ_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub

    Private Sub FrmAlmIngIQ_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        c_Neg_MnAlmacen.get_Almacen_Cbo(" and c_anula_reg=0 order by c_desc_alm", CboAlm)
        Call Validar_Permiso(Me.Name, BtnNuevo, BtnEditar, BtnEliminar)
        c_Neg_MnArticulo.Get_Articulo_Cbo(" and A.c_anula_Reg=0 order by c_desc_articulo", CboArticulo)
        c_Neg_MnMoneda.Get_Moneda_Cbo(" and c_anula_reg=0 order by c_codi_mon", CboMon)
    End Sub
    Public Sub Cargar_GRid(ByVal Cadena As String, ByVal vOpt As String)
        Dgv01.DataSource = c_Neg_IngAlmIQ.get_IngAlmIQ_Datos(Cadena, FrmMenu.TxtCod_Emp.Text, vOpt)
        With Dgv01
            .Columns("Ingreso").Width = 60
            .Columns("Guia Remision").Width = 105
            .Columns("Fecha Ingreso").Width = 105
            .Columns("Proveedor/Cliente").Width = 260
            .Columns("Observaciones").Width = 260

            .Columns("Fecha Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Ingreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns("Guia Remision").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns("c_anula_reg").Visible = False
            .Columns("c_estado_ing").Visible = False
            .Columns("Ingreso").DefaultCellStyle.BackColor = Drawing.Color.Ivory
            Call Grid_Registros_anulados(Dgv01)
            'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = "1 / " & .RowCount
        End With
    End Sub

    Private Sub TxtSerie_Guia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSerie_Guia.LostFocus
        If Focos = 1 Then
            TxtSerie_Guia.Focus()
            Focos = 0
        End If
        If Val(TxtSerie_Guia.Text) > 0 Then
            TxtSerie_Guia.Text = Strings.Right(Val(TxtSerie_Guia.Text) + 1000, 3)
        End If
    End Sub

    Private Sub TxtSerie_Guia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtSerie_Guia.TextChanged

    End Sub
    
    Private Sub TxtNro_Guia_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtNro_Guia.LostFocus
        If Val(TxtNro_Guia.Text) > 0 Then
            TxtNro_Guia.Text = Strings.Right(Val(TxtNro_Guia.Text) + 10000000, 7)
        End If
    End Sub
    ' Metodo para validar que se cumplan los requisitos de grabacion '
    Private Function ValidarDatos()
        If Len(TxtCodAlm.Text) = 2 Then
            If Len(TxtCodMt.Text) = 2 And Len(TxtDescMt.Text) > 0 Then
                If ValidarMotivo(TxtCodMt.Text) = True Then
                    If Len(TxtSerie_OC.Text) > 0 And Len(TxtOC.Text) > 0 Then
                        If Len(TxtSerie_Guia.Text) > 0 And Len(TxtNro_Guia.Text) > 0 Then
                            If Dgv02.RowCount > 0 Then
                                If DtpFec_Ing.Text > Now.Date Then
                                    MsgBox("1. Esta tratando de ingresar una fecha invalida... revisar...", vbCritical, Compañia)
                                Else
                                    ValidarDatos = True
                                End If
                            Else
                                ValidarDatos = False
                                MsgBox("2. No existen Registros que grabar...", vbCritical, Compañia)
                            End If
                        Else
                            ValidarDatos = False
                            MsgBox("3. Ingrese una Guía Válida...", vbCritical, Compañia)
                        End If
                    Else
                        ValidarDatos = False
                        MsgBox("4. Ingrese una Orden de Compra, Válida...", vbCritical, Compañia)
                    End If
                End If
            Else
                ValidarDatos = False
                MsgBox("5. Ingrese un Mótivo Válido...", vbCritical, Compañia)
            End If
        Else
            ValidarDatos = False
            MsgBox("6. Seleccione el Álmacen...", vbCritical, Compañia)
        End If
    End Function
    ' Funcion para validar que esten los codigos ingresados y no sean ceros '
    Public Function ValidarDetalles() As Boolean
        With Dgv02
            ValidarDetalles = True
            For i = 0 To .RowCount - 1
                If .Rows(i).Cells("Codigo").Value = "00000000" Then
                    i = .RowCount : ValidarDetalles = False
                    MsgBox("Falta ingresar el Código del Artículo, debe ingresar el código de Artículo a la SubCaída...", vbCritical, Compañia)
                End If
            Next
        End With
    End Function
    Private Function ValidarNotaC() As Boolean
        If TxtCodMt.Text = "11" Then
            ' InputBox("", "", " and N.c_codi_clie='" & TxtCod_Prove.Text & "' and N.c_nro_serie='" & TxtSerie_Guia.Text & "' and N.c_nro_nc='" & TxtNro_Guia.Text & "' and N.c_anula_reg=0 ")
            With c_Neg_NotaC.get_NotaCVentas_Datos(" and N.c_codi_clie='" & TxtCod_Prove.Text & "' and N.c_nro_serie='" & TxtSerie_Guia.Text & "' and N.c_nro_nc='" & TxtNro_Guia.Text & "' and N.c_anula_reg=0 ", "DAT", FrmMenu.TxtCod_Emp.Text)
                If .Rows.Count > 0 Then
                    ValidarNotaC = True
                Else
                    MsgBox("1. La devolucion como Nota de credito no es valida, revisar...", vbCritical, Compañia)
                    ValidarNotaC = False
                End If
            End With
        Else
            ValidarNotaC = True
        End If
    End Function
    Private Function ValidarAlmacenTransferencia() As Boolean
        If Val(TxtCodMt.Text) = 12 Then
            With c_Neg_AlmSal.get_AlmSalTa_Datos(" and S.c_nro_serie='" & TxtSerie_Guia.Text & "' and S.c_nro_salidaTA='" & TxtNro_Guia.Text & "' and S.c_anula_Reg=0", "DAT", "")
                If .Rows.Count > 0 Then
                    If .Rows(0)("c_codi_alm").ToString <> TxtCodAlm.Text Then
                        ValidarAlmacenTransferencia = True
                    Else
                        ValidarAlmacenTransferencia = False
                        MsgBox("1. Almacen de salida no puede ser igual al almacen de entrada, revisar...", vbCritical, Compañia)
                    End If
                Else
                    ValidarAlmacenTransferencia = False
                    MsgBox("2. Guia transferencia no existe, revisar...", vbCritical, Compañia)
                End If
            End With
        Else
            ValidarAlmacenTransferencia = True
        End If

    End Function
    ' Validar Guia de transferencia
    Private Function ValidarGuiaTransferencia() As Boolean
        If Val(TxtNro_Ing.Text) = 0 Then
            If TxtSerie_Guia.Enabled = False Then
                ValidarGuiaTransferencia = True
            Else
                With c_Neg_IngAlmIQ.get_IngAlmIQ_Datos(" and I.c_anula_reg=0 and I.c_codi_prov='" & TxtCod_Prove.Text & "' and I.c_serie_guia='" & TxtSerie_Guia.Text &
                                           "' and I.c_nro_guia='" & TxtNro_Guia.Text & "' and I.c_codi_mt='" & TxtCodMt.Text & "' ", FrmMenu.TxtCod_Emp.Text, "DAT")
                    If .Rows.Count > 0 Then
                        ValidarGuiaTransferencia = False
                        MsgBox("1. Numero de guia ya fue ingresada anteriormente...", vbCritical, Compañia)
                    Else
                        ValidarGuiaTransferencia = True
                    End If
                End With
            End If
        Else
            ValidarGuiaTransferencia = True
        End If
    End Function
    ' Grabamos Registro '
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Call TxtSerie_Guia_LostFocus(Nothing, Nothing) : Call TxtSerie_Guia_LostFocus(Nothing, Nothing)
        If ValidarNotaC() = True Then
            If ValidarCierre(DtpFec_Ing.Text) = True Then
                If ValidarDatos() = True Then
                    If Validar_SerieDoc() = True Then
                        If ValidarGuiaTransferencia() = True Then
                            If ValidarAlmacenTransferencia() = True Then
                                If ValidarDetalles() = True Then
                                    Dim F As String = MsgBox(" ¿Desea Grabar el Registro? ", vbYesNo + vbQuestion, Compañia)
                                    If F = vbYes Then
                                        Call Grabar_IngAlmIQ("ADD")
                                        If Val(TxtNro_Ing.Text) > 0 Then
                                            With Dgv02
                                                For i = 0 To .RowCount - 1
                                                    Call Grabar_IngAlmIQDet(i, "ADD") : Call BtnMostrar_Click(Nothing, Nothing)
                                                Next
                                            End With
                                            Pan09.Enabled = False : Pan10.Enabled = False
                                            BtnGrabar.Enabled = False : MsgBox("Registro se Grabo Correctamente...", vbExclamation, Compañia)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    'Metodo que nos permite validar que no se registre 2 veces un mismo numero de comprobante del mismo proveedor
    Private Function Validar_SerieDoc() As Boolean
        If Val(TxtOpc_Devol.Text) = 0 Then
            Validar_SerieDoc = True
        Else
            If Val(TxtOpc_Clie.Text) = 0 Then
                If TxtSerie_Guia.Enabled = False Then
                    Validar_SerieDoc = True
                Else
                    With c_Neg_IngAlmIQ.get_IngAlmIQ_Datos(" and I.c_anula_reg=0 and I.c_codi_prov='" & TxtCod_Prove.Text & "' and I.c_serie_guia='" & TxtSerie_Guia.Text &
                                            "' and I.c_nro_guia='" & TxtNro_Guia.Text & "' and I.c_codi_mt='" & TxtCodMt.Text & "' ", FrmMenu.TxtCod_Emp.Text, "DAT")

                        If .Rows.Count > 0 Then
                            If Val(TxtNro_Ing.Text) = 0 Then 'cuando grabamos no debe existir coincidencias...
                                If .Rows.Count > 0 Then
                                    Validar_SerieDoc = False
                                    MsgBox("1. Guía ya fue ingresada anteriormente... Revisar", vbCritical, Compañia)
                                Else
                                    Validar_SerieDoc = True
                                End If
                            Else 'cuando editamos solo debe existir un registro...
                                If .Rows.Count > 1 Then
                                    Validar_SerieDoc = False
                                    MsgBox("2. Guía ya fue ingresada anteriormente... Revisar", vbCritical, Compañia)
                                Else
                                    Validar_SerieDoc = True
                                End If
                            End If
                        Else
                            Validar_SerieDoc = True
                        End If
                    End With
                End If
            Else ' Validamos número de documento '
                With c_Neg_IngAlmIQ.get_IngAlmIQ_Datos(" and I.c_anula_reg=0 and I.c_codi_clie='" & TxtCod_Prove.Text & "' and I.c_serie_guia='" & TxtSerie_Guia.Text &
                                             "' and I.c_nro_guia='" & TxtNro_Guia.Text & "' and I.c_codi_mt='" & TxtCodMt.Text & "' ", FrmMenu.TxtCod_Emp.Text, "DAT")
                    If TxtCodMt.Text = "03" Or TxtCodMt.Text = "10" Then
                        Validar_SerieDoc = True ' SOLO PARA DEVOL. DE ENVASES TE PERMITE INGRESAR LA GUIA MAS DE UNA VEZ
                    Else
                        If .Rows.Count > 0 Then
                            If Val(TxtNro_Ing.Text) = 0 Then 'cuando grabamos no debe existir coincidencias...
                                If .Rows.Count > 0 Then
                                    Validar_SerieDoc = False
                                    MsgBox("1. Guía ya fue ingresada anteriormente... Revisar", vbCritical, Compañia)
                                Else
                                    Validar_SerieDoc = True
                                End If
                            Else 'cuando editamos solo debe existir un registro...
                                If .Rows.Count > 1 Then
                                    Validar_SerieDoc = False
                                    MsgBox("2. Guía ya fue ingresada anteriormente... Revisar", vbCritical, Compañia)
                                Else
                                    Validar_SerieDoc = True
                                End If
                            End If
                        Else
                            Validar_SerieDoc = True
                        End If
                    End If
                End With
            End If
        End If
    End Function
    ' Metodo para Grabar la Cabecera '
    Private Sub Grabar_IngAlmIQ(ByVal cOpcion As String)
        With c_Ent_IngAlmIQ
            .c_codi_ing = TxtNro_Ing.Text
            .c_serie_oc = TxtSerie_OC.Text
            .c_nro_oc = TxtOC.Text
            .c_sist_bahia = 1
            ' validamos cliente '
            If Val(TxtOpc_Clie.Text) > 0 Then
                .c_codi_prov = ""
                .c_codi_clie = TxtCod_Prove.Text
            Else
                .c_codi_prov = TxtCod_Prove.Text
                .c_codi_clie = ""
            End If
            .c_serie_guia = TxtSerie_Guia.Text
            .c_nro_guia = TxtNro_Guia.Text
            .c_fecha_ing = DtpFec_Ing.Text
            .c_codi_mon = TxtCod_Mon.Text
            .c_tpo_cambio = Val(TxtTc.Text)
            .c_codi_mt = TxtCodMt.Text
            .c_codi_alm = TxtCodAlm.Text
            .c_total_ing = Val(TxtTotal.Text)
            .c_opc_devol = Val(TxtOpc_Devol.Text)
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .copcion = cOpcion
            If Len(TxtNro_Ing.Text) = 0 Then
                TxtNro_Ing.Text = c_Neg_IngAlmIQ.set_IngAlmIQ_Save(c_Ent_IngAlmIQ, FrmMenu.TxtCod_Emp.Text)
                ' solo para propieda del cliente  se devuelve como motivo 5
                If TxtCodMt.Text = "05" Then TxtNro_Guia.Text = TxtNro_Ing.Text
            Else
                c_Neg_IngAlmIQ.set_IngAlmIQ_Save(c_Ent_IngAlmIQ, FrmMenu.TxtCod_Emp.Text)
            End If
        End With
    End Sub
    ' Metodo para Grabar el detalle '
    Private Sub Grabar_IngAlmIQDet(ByVal Fila As Integer, ByVal cOpcion As String)
        With c_Ent_IngAlmIQDet
            .c_nro_correl = Dgv02.Rows(Fila).Cells("Item").Value
            .c_codi_ing = TxtNro_Ing.Text
            .c_sist_bahia = 1
            .c_nro_lote = ""
            .c_codi_articulo = Dgv02.Rows(Fila).Cells("Codigo").Value
            .c_nro_cant = Val(Dgv02.Rows(Fila).Cells("Cantidad").Value)
            .c_cant_caja = 0

            .c_codi_unimed = Dgv02.Rows(Fila).Cells("c_codi_unimed").Value
            .c_prec_unit = Val(Dgv02.Rows(Fila).Cells("Precio").Value)
            .c_imp_total = Val(Dgv02.Rows(Fila).Cells("Importe").Value)
            .c_opt_igv = Val(Dgv02.Rows(Fila).Cells("Afecto").Value)
            .c_codi_mon = TxtCod_Mon.Text
            .c_correl_sal = Dgv02.Rows(Fila).Cells("c_correl_oc").Value
            .copcion = cOpcion
            c_Neg_IngAlmIQDet.set_IngAlmIQDet_Save(c_Ent_IngAlmIQDet, FrmMenu.TxtCod_Emp.Text)
        End With
    End Sub

    Private Sub BtnCerrar2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar2.Click
        Tbc01.SelectedTab = Tab01 : Call Cancelar_Registro() : BtnEstado.Visible = False
    End Sub
    ' Metodo para cancelar Registro '
    Private Sub Cancelar_Registro()
        DtpFec_Ing.Enabled = False : TxtCodMt.Enabled = False : TxtSerie_Guia.Enabled = False
        TxtNro_Guia.Enabled = False : CboMon.Enabled = False
        TxtObs.Enabled = False : CboAlm.Enabled = False : BtnGrabar.Enabled = False
        Call Cancelar_Detalles() : Pan10.Enabled = False : BtnConClie.Enabled = False
        TxtCodMt.Enabled = False
    End Sub
    ' Cargamos Registro '
    Private Sub BtnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        If Len(TxtBus_Prove.Text) > 0 Then
            Call Cargar_GRid(" and c_fecha_ing>='" & DtpFec_Inicio.Text & "' and c_fecha_ing<='" & DtpFec_Final.Text & "' and c_desc_prov like '%" & TxtBus_Prove.Text & "%' ", "DGV")
        Else
            Call Cargar_GRid(" and c_fecha_ing>='" & DtpFec_Inicio.Text & "' and c_fecha_ing<='" & DtpFec_Final.Text & "' ", "DGP")
        End If
    End Sub
    ' Editamos Registro '
    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        If Val(.Rows(Fila).Cells("c_estado_ing").Value) = 0 Then
                            If ValidarCierre(.Rows(Fila).Cells("Fecha Ingreso").Value) = True Then
                                Tbc01.SelectedTab = Tab02
                                Call Mostrar_Ingreso(.Rows(Fila).Cells("Ingreso").Value) : TxtCodMt.Enabled = False : CboAlm.Enabled = False : TxtSerie_Guia.Enabled = False
                                TxtNro_Guia.Enabled = False : TxtSerie_OC.Enabled = False : TxtOC.Enabled = False : DtpFec_Ing.Enabled = False
                                TxtSerie_Guia.Enabled = True : TxtNro_Guia.Enabled = True
                                ' validamos si es por transferencia '
                                If TxtCodMt.Text = "12" Then
                                    TxtSerie_Guia.Enabled = False : TxtNro_Guia.Enabled = False
                                    TxtCodMt.Enabled = False
                                End If
                            End If
                        Else
                            MsgBox(" Ingreso ya tiene Facturas Anexadas...", vbCritical, Compañia)
                        End If
                    Else
                        MsgBox(" Registro se encuentra Anulado... ", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub
    Private Sub Mostrar_Ingreso(ByVal c_codi_ing As String)
        With c_Neg_IngAlmIQ.get_IngAlmIQ_Datos(" and I.c_codi_ing='" & c_codi_ing & "'", FrmMenu.TxtCod_Emp.Text, "DAT")
            Call Nuevo_Ingreso()
            If .Rows.Count > 0 Then
                CboAlm.SelectedValue = .Rows(0)("c_codi_alm").ToString
                TxtCodAlm.Text = .Rows(0)("c_codi_alm").ToString
                TxtCodMt.Text = .Rows(0)("c_codi_mt").ToString
                TxtDescMt.Text = .Rows(0)("c_desc_mt").ToString

                TxtNro_Ing.Text = .Rows(0)("c_codi_ing").ToString
                DtpFec_Ing.Text = .Rows(0)("c_fecha_ing").ToString
                TxtSerie_Guia.Text = .Rows(0)("c_serie_guia").ToString
                TxtNro_Guia.Text = .Rows(0)("c_nro_guia").ToString
                TxtCod_Prove.Text = .Rows(0)("c_codi_prov").ToString
                TxtProve.Text = .Rows(0)("c_desc_prov").ToString
                TxtDir.Text = .Rows(0)("c_direc_prov").ToString
                TxtRuc.Text = .Rows(0)("c_ruc_prov").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                TxtTotal.Text = .Rows(0)("c_total_ing").ToString
                TxtTc.Text = .Rows(0)("c_tpo_cambio").ToString
                CboMon.SelectedValue = .Rows(0)("c_codi_mon").ToString
                TxtCod_Mon.Text = .Rows(0)("c_codi_mon").ToString
                TxtSerie_OC.Text = .Rows(0)("c_serie_oc").ToString
                TxtOC.Text = .Rows(0)("c_nro_oc").ToString
                TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                TxtFecha_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFecha_Modi.Text = .Rows(0)("c_fecha_modi").ToString
                TxtOpc_Devol.Text = Val(.Rows(0)("c_opc_devol").ToString)
                ' VAlidamos la devolucion '
                If Val(TxtOpc_Devol.Text) = 1 Then Pan09.Enabled = True

                If Val(.Rows(0)("c_anula_reg").ToString) = 1 Then
                    BtnEstado.Text = "Anulado" : BtnEstado.BackColor = Color.Red
                Else
                    If Val(.Rows(0)("c_estado_ing").ToString) = 0 Then
                        BtnEstado.Text = "Pendiente" : BtnEstado.BackColor = Color.Maroon
                    Else
                        BtnEstado.Text = "Cerrado" : BtnEstado.BackColor = Color.Blue
                    End If
                End If
                '--- Llenamos detalles del ingreso ---
                With c_Neg_IngAlmIQDet.get_IngAlmIQDet_Datos(" and D.c_codi_ing='" & TxtNro_Ing.Text & "' order by D.c_nro_correl", FrmMenu.TxtCod_Emp.Text, "DAT")
                    If .Rows.Count > 0 Then
                        For i = 0 To .Rows.Count - 1
                            Dgv02.Rows.Add()
                            Dgv02.Rows(i).Cells("Cantidad").Value = Format(Val(.Rows(i)("c_nro_cant").ToString), Forma_1_4)
                            Dgv02.Rows(i).Cells("Unid").Value = .Rows(i)("c_desc_unimed").ToString
                            Dgv02.Rows(i).Cells("Mot").Value = .Rows(i)("c_codi_tg").ToString
                            Dgv02.Rows(i).Cells("Cd").Value = .Rows(i)("c_codi_cd").ToString
                            Dgv02.Rows(i).Cells("Scd").Value = .Rows(i)("c_codi_scd").ToString
                            Dgv02.Rows(i).Cells("Codigo").Value = .Rows(i)("c_codi_articulo").ToString
                            Dgv02.Rows(i).Cells("Descripcion").Value = .Rows(i)("c_desc_articulo").ToString
                            Dgv02.Rows(i).Cells("Precio").Value = .Rows(i)("c_prec_unit").ToString
                            Dgv02.Rows(i).Cells("Importe").Value = .Rows(i)("c_imp_total").ToString
                            Dgv02.Rows(i).Cells("Obs").Value = ""
                            Dgv02.Rows(i).Cells("c_anula_Reg").Value = .Rows(i)("c_anula_reg").ToString
                            Dgv02.Rows(i).Cells("Item").Value = .Rows(i)("c_nro_correl").ToString
                            Dgv02.Rows(i).Cells("c_codi_unimed").Value = .Rows(i)("c_codi_unimed").ToString
                            Dgv02.Rows(i).Cells("Afecto").Value = .Rows(i)("c_opt_igv").ToString
                            Dgv02.Rows(i).Cells("c_correl_oc").Value = .Rows(i)("c_correl_sal").ToString
                            Dgv02.Rows(i).Cells("Devol").Value = Format(Val(.Rows(i)("c_cant_devol").ToString), Forma_1_2)
                            ' Validamos el color para los anulados '
                            If Val(Dgv02.Rows(i).Cells("c_anula_reg").Value) = 1 Then
                                Dgv02.Rows(i).DefaultCellStyle.BackColor = Color.Gainsboro
                            End If
                        Next
                    End If
                End With
            Else
                MsgBox("no existe regisrto")
            End If
        End With
    End Sub

    Private Sub Tbc01_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbc01.Click
        If Tbc01.SelectedIndex = 1 Then
            Call Dgv01_DoubleClick(Nothing, Nothing)
        Else
            Call Cancelar_Registro() : BtnEstado.Visible = False
        End If
    End Sub

    Private Sub Dgv01_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv01.CellContentClick

    End Sub

    Private Sub Dgv01_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv01.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv01)
    End Sub

    Private Sub Dgv01_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.DoubleClick
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    Call Mostrar_Ingreso(.Rows(Fila).Cells("Ingreso").Value)
                    Tbc01.SelectedTab = Tab02 : TxtCodMt.Enabled = False : CboAlm.Enabled = False : TxtSerie_Guia.Enabled = False
                    TxtNro_Guia.Enabled = False : TxtSerie_OC.Enabled = False : TxtOC.Enabled = False : DtpFec_Ing.Enabled = False
                    BtnGrabar.Enabled = False : Pan09.Enabled = False : Pan10.Enabled = False
                End If
            End If
        End With
    End Sub

    Private Sub TxtBus_Guia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Guia.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtBus_Guia.Text) > 0 Then
                TxtBus_Guia.Text = Strings.Right(Val(TxtBus_Guia.Text) + 10000000, 7)
                Call Cargar_GRid(" AND I.c_serie_guia='" & TxtBus_Serie.Text & "' and I.c_nro_guia='" & TxtBus_Guia.Text & "' ", "DGP")
            End If
        End If
    End Sub

    Private Sub TxtBus_Guia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Guia.TextChanged

    End Sub

    Private Sub TxtBus_Serie_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtBus_Serie.KeyDown
        If e.KeyCode = Keys.Enter Then
            If IsNumeric(TxtBus_Serie.Text) = True Then
                TxtBus_Serie.Text = Strings.Right(Val(TxtBus_Serie.Text) + 1000, 3)
            End If
        End If
    End Sub

    Private Sub TxtBus_Serie_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtBus_Serie.TextChanged

    End Sub

    Private Sub BtnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEliminar.Click
        With Dgv01
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 0 Then
                        If Val(.Rows(Fila).Cells("c_estado_ing").Value) = 0 Then
                            If ValidarCierre(.Rows(Fila).Cells("Fecha Ingreso").Value) = True Then
                                Dim F As String = MsgBox(" ¿Confirma la Anulación del Registro? ", vbYesNo + vbQuestion, Compañia)
                                If F = vbYes Then
                                    Call Mostrar_Ingreso(.Rows(Fila).Cells("Ingreso").Value)
                                    With Dgv02
                                        For i = 0 To .RowCount - 1
                                            Call Grabar_IngAlmIQDet(i, "DEL")
                                        Next
                                    End With
                                    Call Grabar_IngAlmIQ("DEL")
                                    .Rows(Fila).Cells("c_anula_Reg").Value = 1
                                    .Rows(Fila).DefaultCellStyle.BackColor = Color.Gainsboro
                                    BtnEstado.Visible = False
                                    MsgBox(" Registro se Anulo Correctamente...", vbExclamation, Compañia)
                                End If
                            End If
                        Else
                            MsgBox(" Ingreso ya tiene Facturas Anexadas...", vbCritical, Compañia)
                        End If
                    Else
                        MsgBox(" Registro se encuentra Anulado... ", vbCritical, Compañia)
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_Reg").Value) = 1 Then
                        MsgBox("Registro se encuentra anulado no podra realizar ninguna Modificación...", vbCritical, Compañia)
                    Else
                        vEdit = 1 : Dgv02.Enabled = False
                        Call Mostrar_Detalles(Fila)
                    End If
                End If
            End If
        End With
    End Sub
    ' Metodo para mostrar el detalle '
    Private Sub Mostrar_Detalles(ByVal Fila As Integer)
        With Dgv02
            Call Nuevo_Detalles()
            TxtCant.Text = .Rows(Fila).Cells("Cantidad").Value
            TxtUniMed.Text = .Rows(Fila).Cells("Unid").Value
            TxtMt.Text = .Rows(Fila).Cells("Mot").Value
            TxtCd.Text = .Rows(Fila).Cells("Cd").Value
            TxtScd.Text = .Rows(Fila).Cells("Scd").Value
            TxtCodigo.Text = .Rows(Fila).Cells("Codigo").Value
            TxtPrecio.Text = Format(Val(.Rows(Fila).Cells("Precio").Value), Forma_1_6)
            TxtImporte.Text = Format(Val(.Rows(Fila).Cells("Importe").Value), Forma_1_2)
            TxtCod_UniMed.Text = .Rows(Fila).Cells("c_codi_unimed").Value
            TxtItem.Text = .Rows(Fila).Cells("Item").Value
            Txtcorrel_Oc.Text = .Rows(Fila).Cells("c_correl_oc").Value
            CboArticulo.SelectedValue = .Rows(Fila).Cells("Codigo").Value
            CboArticulo.Enabled = False : TxtCant.Focus()
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
    ' Seleccion de Grid '
    Private Sub Dgv01_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgv01.SelectionChanged
        With Dgv01 'Mostranos por defecto al primer registro del total...
            If .RowCount > 0 Then TxtReg.Text = .CurrentCellAddress.Y + 1 & " / " & .RowCount
        End With
    End Sub

    ' Agregamos registro '
    Private Sub BtnAdd_Click(sender As System.Object, e As System.EventArgs) Handles BtnAdd.Click
        Call Nuevo_Detalles() : vEdit = 0
    End Sub
    ' Metodo para nuevo Detalles '
    Private Sub Nuevo_Detalles()
        With Dgv02
            .Size = New Size(830, 262) : .Location = New Point(3, 48)
            Call Limpiar_Texto(Pan05) : CboArticulo.SelectedIndex = -1
            TxtCant.Enabled = True : TxtCant.Focus() : CboArticulo.Enabled = True
            Pan10.Enabled = True : Pan09.Enabled = False : .Enabled = False
            Pan08.Enabled = True : TxtCant.Focus() : TxtPrecio.Enabled = True
        End With
    End Sub
    ' Metodo para cancelar Detalles '
    Private Sub Cancelar_Detalles()
        With Dgv02
            .Size = New Size(830, 292) : .Location = New Point(3, 23)
            Call Limpiar_Texto(Pan05) : Call Desactivar(Pan05) : CboArticulo.SelectedIndex = -1
            TxtCant.Enabled = False : TxtCant.Focus() : CboArticulo.Enabled = False
            Pan10.Enabled = False : Pan09.Enabled = True : .Enabled = True
            Pan08.Enabled = False
        End With
    End Sub

    Private Sub BtnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles BtnAceptar.Click
        With Dgv02
            If CboArticulo.SelectedIndex > -1 Then
                If vEdit = 0 Then
                    .Rows.Add()
                    Call Agregar_Registro(.RowCount - 1)
                Else
                    Call Agregar_Registro(.CurrentCellAddress.Y)
                End If
                Focos = 1 : BtnAdd.Focus()
                On Error Resume Next
                Dgv02.CurrentCell = Dgv02.Rows(Dgv01.RowCount - 1).Cells(0)
            Else
                MsgBox("Falta seleccionar el articulo", vbCritical, Compañia)
            End If
        End With
    End Sub
    ' Metodo para agregar Registro '
    Private Sub Agregar_Registro(ByVal Fila As Integer)
        With Dgv02
            .Rows(Fila).Cells("Cantidad").Value = Format(Val(TxtCant.Text), Forma_1_4)
            .Rows(Fila).Cells("Unid").Value = TxtUniMed.Text
            .Rows(Fila).Cells("Mot").Value = TxtMt.Text
            .Rows(Fila).Cells("Cd").Value = TxtCd.Text
            .Rows(Fila).Cells("Scd").Value = TxtScd.Text
            .Rows(Fila).Cells("Codigo").Value = TxtCodigo.Text
            .Rows(Fila).Cells("Descripcion").Value = CboArticulo.Text
            .Rows(Fila).Cells("Precio").Value = Val(TxtPrecio.Text)
            .Rows(Fila).Cells("Importe").Value = Format(Val(TxtImporte.Text), Forma_1_2)
            .Rows(Fila).Cells("Item").Value = TxtItem.Text
            .Rows(Fila).Cells("c_anula_reg").Value = 0
            .Rows(Fila).Cells("Obs").Value = ""
            .Rows(Fila).Cells("c_codi_unimed").Value = TxtCod_UniMed.Text
            .Rows(Fila).Cells("Afecto").Value = 1
            .Rows(Fila).Cells("c_correl_oc").Value = Txtcorrel_Oc.Text
            Call Cancelar_Detalles()
        End With
    End Sub
    ' Cancelamos detalles '
    Private Sub BtnCancel_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancel.Click
        Call Cancelar_Detalles()
    End Sub

    Private Sub CboArticulo_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles CboArticulo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtPrecio.Enabled = False Then Call BtnAceptar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub CboArticulo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboArticulo.SelectedIndexChanged
        Call Combo_Jalar_Codigo(CboArticulo, TxtCodigo)
        With c_Neg_MnArticulo.get_Articulo_Datos(" and A.c_codi_articulo='" & TxtCodigo.Text & "'", "DAT")
            If .Rows.Count > 0 Then
                TxtCod_UniMed.Text = .Rows(0)("c_codi_unimed").ToString
                TxtMt.Text = .Rows(0)("c_codi_tg").ToString
                TxtCd.Text = .Rows(0)("c_codi_cd").ToString
                TxtScd.Text = .Rows(0)("c_codi_scd").ToString
                TxtUniMed.Text = .Rows(0)("c_desc_unimed").ToString
            End If
        End With
    End Sub
    ' Evitamos que se pierda el enfoque '
    Private Sub BtnAdd_LostFocus(sender As Object, e As System.EventArgs) Handles BtnAdd.LostFocus
        If Focos = 1 Then
            Focos = 0 : BtnAdd.Focus()
        End If
    End Sub
    ' Eliminamos Registros
    Private Sub BtnDel_Click(sender As System.Object, e As System.EventArgs) Handles BtnDel.Click
        With Dgv02
            If .RowCount > 0 Then
                Dim Fila As Integer = .CurrentCellAddress.Y
                If Fila > -1 Then
                    If Val(.Rows(Fila).Cells("c_anula_reg").Value) = 1 Then
                        MsgBox("Registro se encuentra anulado no podra realizar ninguna Modificación...", vbCritical, Compañia)
                    Else
                        If Val(.Rows(Fila).Cells("Item").Value) = 0 Then
                            Dim F As String = MsgBox("¿Confirma la Eliminacion del Registro?", vbYesNo + vbQuestion, Compañia)
                            If F = vbYes Then
                                .Rows.RemoveAt(Fila)
                            End If
                        Else
                            MsgBox("Registro no puede ser eliminado ya fue ingresado al sistema", vbCritical, Compañia)
                        End If
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub Dgv02_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgv02.CellContentClick

    End Sub
    ' Validar registro anulados '
    Private Sub Dgv02_ColumnHeaderMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgv02.ColumnHeaderMouseClick
        Call Grid_Registros_anulados(Dgv02)
    End Sub

    Private Sub CboAlm_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CboAlm.SelectedIndexChanged
        If CboAlm.Enabled = True And BtnGrabar.Enabled = True Then
            TxtCodAlm.Text = CboAlm.SelectedValue
        End If
    End Sub

    Private Sub TxtCant_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtCant.KeyDown
        If e.KeyCode = Keys.Enter Then
            If CboArticulo.Enabled = False Then Call BtnAceptar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub TxtCant_TextChanged(sender As System.Object, e As System.EventArgs) Handles TxtCant.TextChanged
        TxtImporte.Text = Format(Val(TxtCant.Text) * Val(TxtPrecio.Text), Forma_1_2)
    End Sub
    ' Consulta de clientes '
    Private Sub BtnConClie_Click(sender As System.Object, e As System.EventArgs) Handles BtnConClie.Click
        FrmConClientes.MdiParent = FrmMenu : FrmConClientes.Show() : FrmConClientes.TxtVar.Text = 1 : FrmConClientes.Cargar_Grid(" and c_anula_reg=0 order by c_desc_clie")
    End Sub
    ' Mostramos el tipo de cambio '
    Private Sub DtpFec_Ing_ValueChanged(sender As Object, e As EventArgs) Handles DtpFec_Ing.ValueChanged
        Call Mostrar_TpoCambio(DtpFec_Ing.Text, TxtTc)
    End Sub

    Private Sub TxtPrecio_TextChanged(sender As Object, e As EventArgs) Handles TxtPrecio.TextChanged
        TxtImporte.Text = Format(Val(TxtCant.Text) * Val(TxtPrecio.Text), Forma_1_2)
    End Sub

    Private Sub TxtPrecio_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtPrecio.KeyDown
        If e.KeyCode = Keys.Enter Then
            If TxtImporte.Enabled = False Then Call BtnAceptar_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub CboMon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboMon.SelectedIndexChanged
        If CboMon.Enabled = True Then
            TxtCod_Mon.Text = CboMon.SelectedValue
        End If
    End Sub

    Private Sub TxtCodMt_TextChanged(sender As Object, e As EventArgs) Handles TxtCodMt.TextChanged

    End Sub

    Private Sub TxtCodMt_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtCodMt.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TxtCodMt.Text) > 0 Then
                TxtCodMt.Text = Strings.Right(TxtCodMt.Text + 100, 2)
                TxtDescMt.Clear() : Dgv02.Rows.Clear()
                With c_Neg_MnMtMov.get_MtMov_Datos(" and c_anula_Reg=0 and c_codi_mt ='" & TxtCodMt.Text & "'", "DAT")
                    If .Rows.Count > 0 Then
                        TxtDescMt.Text = .Rows(0)("c_desc_mt").ToString
                        Call CargarConfigMt()
                    Else
                        TxtCodMt.Clear()
                        MsgBox("Codigo de motivo no existe...", vbCritical, Compañia)
                    End If
                End With
            End If
        End If
    End Sub
    Private Sub CargarConfigMt()
        If TxtCodMt.Enabled = True Then
            LblOC.Text = "Orden de Compra" : BtnConClie.Visible = False
            ' compras o saldo inicial '
            If TxtCodMt.Text = "00" Or TxtCodMt.Text = "10" Or TxtCodMt.Text = "12" Then
                TxtSerie_Guia.Text = "000" : TxtNro_Guia.Text = "0000000"
                TxtSerie_OC.Text = "000" : TxtOC.Text = "0000000"
                TxtSerie_Guia.Enabled = False : TxtNro_Guia.Enabled = False
                TxtSerie_OC.Enabled = False : TxtOC.Enabled = False
                Pan09.Enabled = True
                TxtCod_Prove.Text = "00000"
                TxtProve.Text = "NINGUNO"
                Pan09.Enabled = True : Pan10.Enabled = False
                If TxtCodMt.Text = "00" Then
                    TxtObs.Text = "Saldo Inicial"
                    CboMon.Enabled = False
                Else
                    If TxtCodMt.Text = "12" Then
                        TxtSerie_Guia.Enabled = True : TxtNro_Guia.Enabled = True
                        Call MostrarProveDefecto(TxtCod_Prove, TxtProve)
                        TxtObs.Text = "Transferencia entre almacenes"
                        CboMon.SelectedValue = "01"
                        Call CboMon_SelectedIndexChanged(Nothing, Nothing)
                        TxtCod_Mon.Text = "01"
                        Pan09.Enabled = False
                    Else
                        TxtObs.Text = "Ajuste por inventario"
                        Pan09.Enabled = True
                    End If
                    CboMon.Enabled = True
                End If
            Else ' Devolucion de cliente 07=Devolucion de mercaderia 11= Devolucion de Cliente
                CboMon.Enabled = False
                If TxtCodMt.Text = "05" Or TxtCodMt.Text = "07" Or TxtCodMt.Text = "11" Then
                    BtnConClie.Visible = True : TxtSerie_OC.Text = "000" : TxtOC.Text = "0000000"
                    TxtSerie_Guia.Enabled = False : TxtNro_Guia.Enabled = False : TxtSerie_OC.Enabled = False : TxtOC.Enabled = False
                    TxtSerie_Guia.Text = "001" : TxtNro_Guia.Text = "0000000" : Pan09.Enabled = True : Pan10.Enabled = False
                    LblProve.Text = "Cliente" : BtnConClie.Enabled = True : BtnConClie.Visible = True
                    ' We validate if is for devolucion de mercaderia '
                    Pan09.Enabled = True : Pan10.Enabled = False
                    If TxtCodMt.Text = "07" Or TxtCodMt.Text = "11" Then
                        TxtSerie_Guia.Enabled = True : TxtNro_Guia.Enabled = True : TxtSerie_Guia.Clear() : TxtNro_Guia.Clear()
                        CboMon.Enabled = True
                    End If
                Else
                    TxtSerie_Guia.Clear() : TxtNro_Guia.Clear()
                    TxtSerie_OC.Clear() : TxtOC.Clear()
                    TxtSerie_Guia.Enabled = True : TxtNro_Guia.Enabled = True : TxtSerie_OC.Enabled = True : TxtOC.Enabled = True
                    Pan09.Enabled = False
                    TxtCod_Prove.Clear() : TxtProve.Clear() : TxtObs.Clear()
                    Pan09.Enabled = False : Pan10.Enabled = False
                    Focos = 1
                    TxtSerie_OC.Focus()
                End If
            End If
        End If
        '--> Validamos si trabajamos con clientes o proveedores <--'
        With c_Neg_MnMtMov.get_MtMov_Datos(" and c_codi_mt='" & TxtCodMt.Text & "' ", "DAT")
            If .Rows.Count > 0 Then
                TxtOpc_Clie.Text = Val(.Rows(0)("c_opc_clie").ToString)
                TxtOpc_Devol.Text = Val(.Rows(0)("c_opc_devol").ToString)
            End If
        End With
        ' validamos '
        If Val(TxtOpc_Devol.Text) = 1 Then
            LblOC.Text = "Guia Remision"
        End If

    End Sub

    Private Sub TxtSerie_OC_LostFocus(sender As Object, e As EventArgs) Handles TxtSerie_OC.LostFocus
        If Focos = 1 Then
            Focos = 0 : TxtSerie_OC.Focus()
        End If
    End Sub
End Class