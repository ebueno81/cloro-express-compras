Imports System.Windows.Forms
Imports Capa_Negocios
Public Class FrmMenu
    Dim c_Neg_UsuaAcceso As New Neg_Usuario
    Private Sub FrmMenu_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub
    'Validamos permiso de usuarios...
    Private Sub FrmMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Validar_Menu()
        Me.BackgroundImage = System.Drawing.Image.FromFile(My.Application.Info.DirectoryPath & "\Logo.jpg")
    End Sub
    Public Sub Validar_Menu()
        Dim Dt_NombreMenu As String = ""
        With Dgv01
            If .RowCount > 0 Then
                For i = 0 To .RowCount - 1
                    Dt_NombreMenu = .Rows(i).Cells("c_nom_menu").Value
                    If Val(.Rows(i).Cells("c_find_obj").Value) = 0 Then
                        For Each Dt_Menu In MenuStrip.Items ' ---> Items del MenuStrip
                            For Each item In Dt_Menu.DropDownItems ' ---> Items del ToolStripItem
                                If UCase(item.Name) = UCase(Dt_NombreMenu) Then ' ---> Si el item pertenece al usuario
                                    CType(item, ToolStripMenuItem).Enabled = False ' ----> lo muestra
                                End If
                            Next
                        Next
                    End If
                    ' Validamos si el Tool esta Activo '
                    On Error Resume Next
                    If .Rows(i).Cells("c_find_obj").Value = 0 Then
                        For u = 0 To Tool_01.Items.Count - 1
                            If Tool_01.Items(u).Name = .Rows(i).Cells("c_nom_tool").Value Then
                                Tool_01.Items(u).Enabled = False : u = Tool_01.Items.Count
                            End If
                        Next
                    End If
                Next
            End If
        End With
    End Sub
    Private Sub MnuMnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnSalir.Click
        End
    End Sub

    Private Sub MnuMnTg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnTg.Click
        With FrmMnTblGral
            .MdiParent = Me : .Show() : .Cargar_Grid()
        End With
    End Sub

    Private Sub MnuMnProve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnProve.Click
        FrmMnProve.MdiParent = Me
        FrmMnProve.Show()
        FrmMnProve.Cargar_Grid(" order by c_desc_prov") : FrmMnProve.TxtBus.Focus()
    End Sub



    Private Sub MnuOpeOQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeOQ.Click
        FrmOQ.MdiParent = Me
        FrmOQ.Show()
        FrmOQ.Cargar_Grid()
    End Sub
    Private Sub MnuConLisArticulos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuConLisArticulos.Click
        FrmConArtListar.MdiParent = Me : FrmConArtListar.Show()
        'FrmConArtListar.Cargar_Grid(" and S.c_anula_reg=0  order by S.c_desc_scd")
    End Sub
    'Tipo de cambio...
    Private Sub MnuMnTpoCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnTpoCambio.Click
        FrmMnTpoCambio.MdiParent = Me
        FrmMnTpoCambio.Show()
    End Sub

    Private Sub MnuOpeIngComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeIngComp.Click
        FrmIngComp.Close() : FrmIngComp.MdiParent = Me : FrmIngComp.Show() : FrmIngComp.TxtOpc_Apertura.Text = 0
    End Sub

    Private Sub MnuMnPagoTpo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnPagoTpo.Click
        FrmMnTpoPago.MdiParent = Me
        FrmMnTpoPago.Show()
        FrmMnTpoPago.Cargar_Grid(" order by c_desc_pago")
    End Sub

    Private Sub MnuMnTpoDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnTpoDoc.Click
        FrmMnTpoDoc.MdiParent = Me
        FrmMnTpoDoc.Show()
        FrmMnTpoDoc.Cargar_Grid(" order by c_desc_doc")
    End Sub

    Private Sub MnuOpeIngNC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeIngNC.Click
        FrmIngNC.MdiParent = Me
        FrmIngNC.Show()
    End Sub

    Private Sub MnuOpeIngLetras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeIngLetras.Click
        FrmLetras.MdiParent = Me
        FrmLetras.Show()
    End Sub

    Private Sub MnuAdmUsuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAdmUsuarios.Click
        FrmUsuarios.MdiParent = Me
        FrmUsuarios.Show() : FrmUsuarios.Cargar_Grid("")
    End Sub

    Private Sub MnuAdmCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAdmCierre.Click
        FrmCierres.MdiParent = Me
        FrmCierres.Show()
    End Sub

    Private Sub MnuRepRegCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRepRegCompras.Click
        FrmRepCompras.MdiParent = Me
        FrmRepCompras.Show()
    End Sub

    Private Sub MnuConPartidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolCerrar.Click
        End
    End Sub

    Private Sub Tool_Calcu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Calcu.Click
        Dim Proceso As New Process()
        Proceso.StartInfo.FileName = "calc.exe"
        Proceso.StartInfo.Arguments = ""
        Proceso.Start()
    End Sub

    'Mantenimiento de proveedores...
    Private Sub Tool_Prove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Prove.Click
        If MnuMnProve.Enabled = True Then
            Call MnuMnProve_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los permisos necesarios para acceder a este Módulo...", vbCritical, Compañia)
        End If
    End Sub
    'Mantenimiento de series...
    Private Sub MnuMnSeries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnSeries.Click
        FrmMnSeriesOC.MdiParent = Me : FrmMnSeriesOC.Show() : Me.Location = New Point(10, 10)
    End Sub
    'Tipo de cambio...
    Private Sub Tool_TpoCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_TpoCambio.Click
        If MnuMnTpoCambio.Enabled = True Then
            Call MnuMnTpoCambio_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los permisos necesarios para acceder a este Módulo...", vbCritical, Compañia)
        End If
    End Sub

    'Articulos
    Private Sub Tool_Articulos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Articulos.Click
        If MnuMnTg.Enabled = True Then
            Call MnuMnTg_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los permisos necesarios para acceder a este Módulo...", vbCritical, Compañia)
        End If
    End Sub
    'Tipo de documentos...
    Private Sub Tool_Docu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Docu.Click
        If MnuMnTpoDoc.Enabled = True Then
            Call MnuMnTpoDoc_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los permisos necesarios para acceder a este Módulo...", vbCritical, Compañia)
        End If
    End Sub
    'Orden de requerimientos...
    Private Sub Tool_OQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_OQ.Click
        If MnuOpeOQ.Enabled = True Then
            MnuOpeOQ_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los permisos necesarios para acceder a este Módulo...", vbCritical, Compañia)
        End If
    End Sub
    'Ordenes de compras...
    Private Sub Tool_OC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_OC.Click
        If MnuOpeOC.Enabled = True Then
            MnuOpeOC_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los permisos necesarios para acceder a este Módulo...", vbCritical, Compañia)
        End If
    End Sub
    'Notas de credito...
    Private Sub Tool_Nc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Nc.Click
        If MnuOpeIngNC.Enabled = True Then
            Call MnuOpeIngNC_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los permisos necesarios para acceder a este Módulo...", vbCritical, Compañia)
        End If
    End Sub
    'Administración de usuarios...
    Private Sub Tool_Usuarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Usuarios.Click
        If MnuAdmUsuarios.Enabled = True Then
            MnuAdmUsuarios_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los permisos necesarios para acceder a este Módulo...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub MnuOpeOC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeOC.Click
        FrmOC.MdiParent = Me
        FrmOC.Show()
        FrmOC.Cargar_GRid_OC(" and O.c_nro_Serie='001' order by c_nro_oc")
    End Sub
    'Ingreso de letras...
    Private Sub Tool_Letras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Letras.Click
        If MnuOpeIngLetras.Enabled = True Then
            Call MnuOpeIngLetras_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los permisos necesarios para acceder a este Módulo...", vbCritical, Compañia)
        End If
    End Sub
    'Registro de Compras
    Private Sub Tool_RegCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_RegCompras.Click
        If MnuRepRegCompras.Enabled = True Then
            Call MnuRepRegCompras_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los permisos necesarios para acceder a este Módulo...", vbCritical, Compañia)
        End If
    End Sub

    Private Sub Tool_Ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_Ayuda.Click
        MsgBox("  Módulo pendiente por Definir...  ", vbExclamation, Compañia)
    End Sub
    'Asientos Automaticos...
    Private Sub MnuContaAsientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuContaAsientos.Click
        FrmAsientos.MdiParent = Me : FrmAsientos.Show()
    End Sub
    'Modulos del sistema de compras...
    Private Sub MnuAdmModulos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuAdmModulos.Click
        FrmModulos.MdiParent = Me : FrmModulos.Show()
    End Sub
    'Mantenimiento de IGV
    Private Sub MnuMnIgv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnIgv.Click
        FrmMnIGV.MdiParent = Me : FrmMnIGV.Show() : FrmMnIGV.cargar_grid()
    End Sub

    Private Sub MnuOpeIngAlm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeIngAlm.Click
        With FrmAlmIngIQ
            .MdiParent = Me : .Show() : .Cargar_GRid(" and I.c_fecha_ing='" & Now.Date & "' ", "DGP")
        End With
    End Sub
    ' Reporte de Stock Valorizado '
    Private Sub MnuRepStockIQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRepStockIQValor.Click
        FrmRptStockIQValor.MdiParent = Me : FrmRptStockIQValor.Show()
    End Sub
    ' Kardex General '
    Private Sub MnuRepKardex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRepKardex.Click
        FrmRptKardex.MdiParent = Me : FrmRptKardex.Show()
    End Sub
    ' Generacion de Retenciones '
    Private Sub MnuOpeRetencion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeRetencion.Click
        FrmRetencion.MdiParent = Me : FrmRetencion.Show()
    End Sub
    ' Series de documentos - Comprobantes de pagos'
    Private Sub MnuMnSeriesDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnSeriesDoc.Click
        FrmMnSeriesDoc.MdiParent = Me : FrmMnSeriesDoc.Show()
    End Sub
    ' Consulta de Retenciones Emitidas '
    Private Sub MnuConReten_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuConReten.Click
        FrmRetenPend.MdiParent = Me : FrmRetenPend.Show()
    End Sub
    ' Facturas pendientes por pagar '
    Private Sub MnuRepFactPagar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRepFactPagar.Click
        FrmRptFactPagar.Close() : FrmRptFactPagar.MdiParent = Me : FrmRptFactPagar.Show()
    End Sub
    ' Reporte de Movimientos Detallados '
    Private Sub MnuRepMovDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRepMovDet.Click
        FrmRptMovDet.MdiParent = Me : FrmRptMovDet.Show()
    End Sub
    ' Reporte de Tipo de Cambio '
    Private Sub MnuRepTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRepTC.Click
        FrmRptTC.MdiParent = Me : FrmRptTC.Show()
    End Sub
    ' Reporte de Stock Fisico '
    Private Sub MnuRepStockIQFisico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRepStockIQFisico.Click
        FrmRptStockIQ.MdiParent = Me : FrmRptStockIQ.Show()
    End Sub
    ' Tabla de Detracciones '
    Private Sub MnuMnTblDetrac_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuMnTblDetrac.Click
        FrmMnTblDetraccion.MdiParent = Me : FrmMnTblDetraccion.Show() : FrmMnTblDetraccion.Cargar_Grid(" Order by c_codi_detracc")
    End Sub
    ' Ingresos de comprobantes de pago '
    Private Sub Tool_IngComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_IngComp.Click
        If MnuOpeIngComp.Enabled = True Then
            Call MnuOpeIngComp_Click(Nothing, Nothing)
        Else
            MsgBox("No tiene los permisos necesarios para acceder a este Módulo...", vbCritical, Compañia)
        End If
    End Sub
    ' Consultamos Listado de Letras '
    Private Sub MnuConListaLetras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuConListaLetras.Click
        FrmListaLetras.MdiParent = Me : FrmListaLetras.Show()
    End Sub
    ' Ingresos a Almacen '
    Private Sub Tool_IngAlm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_IngAlm.Click
        If MnuOpeIngAlm.Enabled = True Then Call MnuOpeIngAlm_Click(Nothing, Nothing)
    End Sub
    ' Listado de Documentos '
    Private Sub MnuConLstDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuConLstDoc.Click
        FrmListaDoc.MdiParent = Me : FrmListaDoc.Show()
    End Sub
    ' Documentos pendientes '
    Private Sub Tool_DocPend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_DocPend.Click
        If MnuRepFactPagar.Enabled = True Then Call MnuRepFactPagar_Click(Nothing, Nothing)
    End Sub
    ' Reporte de movimientos detallados '
    Private Sub Tool_MovDet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_MovDet.Click
        If MnuRepMovDet.Enabled = True Then Call MnuRepMovDet_Click(Nothing, Nothing)
    End Sub
    ' stock de insumos quimicos '
    Private Sub Tool_RepStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_RepStock.Click
        If MnuRepStockIQFisico.Enabled = True Then Call MnuRepStockIQ_Click(Nothing, Nothing)
    End Sub
    ' movimientos de kardex '
    Private Sub Tool_RepKardex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tool_RepKardex.Click
        If MnuRepKardex.Enabled = True Then Call MnuRepKardex_Click(Nothing, Nothing)
    End Sub
    ' Mantenimiento de Líneas '
    Private Sub MnuMnLineas_Click(sender As System.Object, e As System.EventArgs) Handles MnuMnLineas.Click
        FrmMnLineas.MdiParent = Me : FrmMnLineas.Show() : FrmMnLineas.Cargar_Grid()
    End Sub
    ' Mantenimiento de Artículos '
    Private Sub MnuMnArticulos_Click(sender As System.Object, e As System.EventArgs) Handles MnuMnArticulos.Click
        FrmMnArticulos.MdiParent = Me : FrmMnArticulos.Show() : FrmMnArticulos.Cargar_Grid(" order by c_desc_articulo")
    End Sub
    ' Motivo de movimieentos '
    Private Sub MnuMnTpoMov_Click(sender As System.Object, e As System.EventArgs) Handles MnuMnTpoMov.Click
        FrmMnMotivos.MdiParent = Me : FrmMnMotivos.Show() : FrmMnMotivos.Cargar_Grid()
    End Sub
    ' Mantenimiento de Unidad de Medidas '
    Private Sub MnuMnUnidMed_Click(sender As System.Object, e As System.EventArgs) Handles MnuMnUnidMed.Click
        FrmMnUniMed.MdiParent = Me : FrmMnUniMed.Show() : Call FrmMnUniMed.Cargar_Grid(" order by c_desc_unimed")
    End Sub

    Private Sub MnuMnAlmacen_Click(sender As System.Object, e As System.EventArgs) Handles MnuMnAlmacen.Click
        FrmMnAlmacen.Show() : FrmMnAlmacen.MdiParent = Me : FrmMnAlmacen.Cargar_Grid(" order by c_Desc_alm")
    End Sub
    ' leasing y pagares '
    Private Sub MnuOpeLeasing_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeLeasing.Click
        FrmLeasing.MdiParent = Me : FrmLeasing.Show()
    End Sub
    ' Registro de Duas
    Private Sub MnuOpeDuas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuOpeDuas.Click
        FrmDuas.MdiParent = Me : FrmDuas.Show()
    End Sub
    ' Reporte de ingresos de compras '


    Private Sub MnuRepCaidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRepCaidas.Click
        FrmReportes.Reporte_Caidas()
    End Sub

    Private Sub MnuRepSCaidas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuRepSCaidas.Click
        FrmReportes.Reporte_SubCaidas()
    End Sub
    ' Asiento de apertura '
    Private Sub MnuConApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuConApertura.Click
        With FrmIngComp
            .Close() : FrmIngComp.MdiParent = Me : FrmIngComp.Show() : FrmIngComp.TxtOpc_Apertura.Text = 1
        End With
    End Sub
    ' Transformacion '
    Private Sub MnuOpeTransforma_Click(sender As System.Object, e As System.EventArgs) Handles MnuOpeTransforma.Click
        FrmAlmTransforma.MdiParent = Me : FrmAlmTransforma.Show()
    End Sub
    ' Reporte de Leasing por Pagar '
    Private Sub MnuRepLeasingPagar_Click(sender As System.Object, e As System.EventArgs) Handles MnuRepLeasingPagar.Click
        FrmRptFactPagar.Close() : FrmRptFactPagar.MdiParent = Me : FrmRptFactPagar.Show() : FrmRptFactPagar.TxtVar.Text = 1
    End Sub
    ' Kardex Valorizado '
    Private Sub MnuRepKardexValor_Click(sender As System.Object, e As System.EventArgs) Handles MnuRepKardexValor.Click
        FrmRptKardexValor.MdiParent = Me : FrmRptKardexValor.Show()
    End Sub
    ' costos de importaciones '
    Private Sub MnuOpeCostos_Click(sender As System.Object, e As System.EventArgs) Handles MnuOpeCostos.Click
        FrmDuasCostos.MdiParent = Me : FrmDuasCostos.Show()
    End Sub
    ' listado de otros financiamientos
    Private Sub MnuConLstLeasing_Click(sender As System.Object, e As System.EventArgs) Handles MnuConLstLeasing.Click
        FrmRptLeasing.MdiParent = Me : FrmRptLeasing.Show()
    End Sub
    ' Consultamos guias facturadas '
    Private Sub MnuConGuiasFactu_Click(sender As Object, e As EventArgs) Handles MnuConGuiasFactu.Click
        FrmConGuiaFact.MdiParent = Me : FrmConGuiaFact.Show()
    End Sub

    Private Sub MnuRepIngIQ_Click(sender As Object, e As EventArgs) Handles MnuRepIngIQ.Click
        FrmRptIngAlm.MdiParent = Me : FrmRptIngAlm.Show()
    End Sub

    Private Sub MnuRepTransCompras_Click(sender As Object, e As EventArgs) Handles MnuRepTransCompras.Click
        FrmRptTransforCompras.MdiParent = Me
        FrmRptTransforCompras.Show()
        FrmRptTransforCompras.TxtcodTg.Text = "01"
        FrmRptTransforCompras.TxtTg.Text = "MERCADERIA"
        FrmRptTransforCompras.TxtCodCd.Text = "01"
        FrmRptTransforCompras.TxtCd.Text = "INSUMOS QUIMICOS"
        FrmRptTransforCompras.CargarGrid()

    End Sub
End Class
