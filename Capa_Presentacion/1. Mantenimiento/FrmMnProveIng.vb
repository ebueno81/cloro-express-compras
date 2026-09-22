Imports Capa_Negocios
Imports Capa_Entidades
Public Class FrmMnProveIng
    Dim c_Negocio As New Neg_MnProve
    Dim e_Entidad As New Ent_MnProve
    Dim c_Neg_OcDet As New Neg_OCDet

    Private Sub FrmMnProveIng_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If Val(TxtVar1.Text) = 1 Then 'Generación de Facturas...
            If Len(TxtCod_Prov.Text) > 0 Then
                With FrmOC
                    .txtCod_Prove.Text = TxtCod_Prov.Text : .TxtProve.Text = TxtRaz.Text
                    .TxtRuc.Text = TxtRuc.Text : .TxtDir.Text = TxtDir.Text & " " & TxtDis.Text
                    .CboMon.Focus()
                End With
            End If
        End If
    End Sub
    Private Sub FrmMnProveIng_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then Me.Close()
        'If e.Control And e.KeyCode = Keys.N Then If BtnAdd.Enabled = True Then Call BtnAdd_Click(Nothing, Nothing)
        'If e.Control And e.KeyCode = Keys.E Then If BtnEdit.Enabled = True Then Call BtnEdit_Click(Nothing, Nothing)
        If e.Control And e.KeyCode = Keys.G Then If BtnGrabar.Enabled = True Then Call BtnGrabar_Click(Nothing, Nothing)
        'consultamos ruc en la pagina de la sunat
        If e.KeyCode = 112 Then
            Dim proceso As New System.Diagnostics.Process
            With proceso
                .StartInfo.FileName = "http://www.sunat.gob.pe/cl-ti-itmrconsruc/jcrS00Alias"
                .Start()
            End With
        End If
    End Sub
    'Avanzamos presionando la tecla enter...
    Private Sub FrmMnProveIng_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Call Avanzar_Enter(e)
    End Sub
    'Cargarmos 
    Private Sub FrmMnProveIng_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TxtCiu.Text = "LIMA" : TxtPais.Text = "PERU"
    End Sub
    Private Sub Grabar_Proveedor()
        With e_Entidad
            Dim Tpo_Compra As Integer = 0 'Variable que nos permitira saber si el proveedor es nacional=1 o 2=Importacion
            If Rdb01.Checked = True Then Tpo_Compra = 1
            If Rdb02.Checked = True Then Tpo_Compra = 2

            .c_codi_prov = TxtCod_Prov.Text
            .c_desc_prov = TxtRaz.Text
            .c_nom_prov = TxtRaz.Text
            .c_pais_prov = TxtPais.Text
            .c_ciudad_prov = TxtCiu.Text
            .c_dist_prov = TxtDis.Text
            .c_direc_prov = TxtDir.Text
            .c_ruc_prov = TxtRuc.Text
            .c_telf_prov = TxtFono.Text
            .c_cel_prov = TxtCel.Text
            .c_contac_prov = TxtCon.Text
            .c_mail_prov = TxtMail.Text
            .c_web_prov = TxtWeb.Text
            .c_codi_tpoprov = Strings.Right(CboTpo.Text, 2)
            .c_cta_detraccion = TxtCta_Detraccion.Text
            .c_obs = TxtObs.Text
            .c_usuario = FrmMenu.lblusuario.Text
            .c_tpo_compra = Tpo_Compra
            If Len(TxtCod_Prov.Text) = 0 Then
                .copcion = "ADD"
                TxtCod_Prov.Text = c_Negocio.set_Prove_Save(e_Entidad)
            Else
                .copcion = "EDI"
                c_Negocio.set_Prove_Save(e_Entidad)
            End If

            BtnGrabar.Enabled = False
            MsgBox("Se registro se grabo correctamente...", MsgBoxStyle.Exclamation)
        End With
    End Sub
    Public Sub Mostrar_Proveedor(ByVal Codigo As String)
        With c_Negocio.get_Prove_Datos(" and P.c_codi_prov='" & Codigo & "' ", "DAT")
            If .Rows.Count > 0 Then
                TxtCod_Prov.Text = .Rows(0)("c_codi_prov").ToString
                TxtRuc.Text = .Rows(0)("c_ruc_prov").ToString
                TxtRaz.Text = .Rows(0)("c_desc_prov").ToString
                'TxtNom.Text = .Rows(0)("c_nom_prov").ToString
                TxtDir.Text = .Rows(0)("c_direc_prov").ToString
                TxtPais.Text = .Rows(0)("c_pais_prov").ToString
                TxtCiu.Text = .Rows(0)("c_ciudad_prov").ToString
                TxtDis.Text = .Rows(0)("c_dist_prov").ToString
                TxtDir.Text = .Rows(0)("c_direc_prov").ToString
                TxtFono.Text = .Rows(0)("c_telf_prov").ToString
                TxtCel.Text = .Rows(0)("c_cel_prov").ToString
                TxtCon.Text = .Rows(0)("c_contac_prov").ToString
                TxtWeb.Text = .Rows(0)("c_web_prov").ToString
                TxtMail.Text = .Rows(0)("c_mail_prov").ToString
                TxtUsua_1.Text = .Rows(0)("c_usua_crea").ToString
                TxtUsua_2.Text = .Rows(0)("c_usua_modi").ToString
                TxtFec_Crea.Text = .Rows(0)("c_fecha_crea").ToString
                TxtFec_Mod.Text = .Rows(0)("c_fecha_modi").ToString
                TxtCta_Detraccion.Text = .Rows(0)("c_cta_detraccion").ToString
                TxtObs.Text = .Rows(0)("c_obs").ToString
                'Tipo de proveedor nacional e importado
                If Val(.Rows(0)("c_tpo_compra").ToString) = 1 Then Rdb01.Checked = True
                If Val(.Rows(0)("c_tpo_compra").ToString) = 2 Then Rdb02.Checked = True
                'Tipo de proveedor 
                For i = 0 To CboTpo.Items.Count - 1
                    If Strings.Right(CboTpo.Items(i).ToString, 2) = .Rows(0)("c_codi_tpoprov").ToString Then
                        CboTpo.SelectedIndex = i
                        i = CboTpo.Items.Count + 1
                    End If
                Next
            End If
        End With
    End Sub
    'Grabamos nuevo proveedor...
    Private Sub BtnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGrabar.Click
        Dim x As New TextBox
        Call Validar_Ingreso(x)
        If Val(x.Text) = 1 Then
            MsgBox("El R.U.C. del Proveedor, ya fue ingresado anteriormente...", vbCritical, Compañia)
        Else
            Call Grabar_Proveedor()
        End If
    End Sub
    Private Sub Validar_Ingreso(ByVal x As TextBox)
        With c_Negocio.get_Prove_Datos(" And c_ruc_prov='" & TxtRuc.Text & "' and P.c_anula_Reg=0", "DAT")
            If Len(TxtCod_Prov.Text) = 0 Then
                If .Rows.Count > 0 Then x.Text = 1
            Else 'modificamos 
                If .Rows.Count > 1 Then x.Text = 1
            End If
        End With
    End Sub
    Private Sub BtnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrar.Click
        Me.Close()
    End Sub
End Class