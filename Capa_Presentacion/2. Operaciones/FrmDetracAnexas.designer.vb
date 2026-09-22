<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetracAnexas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDetracAnexas))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Tipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Documento = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Proveedor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Porc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total_Us = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Detraccion_Us = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Total_Mn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Detraccion_Mn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_ruc_prove = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_fecha_cancel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_nro_constancia = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_codi_det = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_codi_prove = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_codi_doc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_opc_cancel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pan03 = New System.Windows.Forms.Panel()
        Me.TxtCod_Det = New System.Windows.Forms.TextBox()
        Me.TxtNro_Ing = New System.Windows.Forms.TextBox()
        Me.TxtCod_Doc = New System.Windows.Forms.TextBox()
        Me.TxtItem = New System.Windows.Forms.TextBox()
        Me.TxtConstancia = New System.Windows.Forms.TextBox()
        Me.DtpFec_Pago = New System.Windows.Forms.DateTimePicker()
        Me.TxtDetrac_Mn = New System.Windows.Forms.TextBox()
        Me.TxtTotal_Mn = New System.Windows.Forms.TextBox()
        Me.TxtTc = New System.Windows.Forms.TextBox()
        Me.TxtDetrac_Us = New System.Windows.Forms.TextBox()
        Me.TxtTotal_Us = New System.Windows.Forms.TextBox()
        Me.TxtPorc = New System.Windows.Forms.TextBox()
        Me.TxtFecha = New System.Windows.Forms.TextBox()
        Me.TxtFactura = New System.Windows.Forms.TextBox()
        Me.TxtCod_Prove = New System.Windows.Forms.TextBox()
        Me.Pan01.SuspendLayout()
        Me.Pan02.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan03.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pan01
        '
        Me.Pan01.BackColor = System.Drawing.Color.White
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.BtnNuevo)
        Me.Pan01.Controls.Add(Me.BtnEditar)
        Me.Pan01.Controls.Add(Me.BtnEliminar)
        Me.Pan01.Location = New System.Drawing.Point(1, 189)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(260, 29)
        Me.Pan01.TabIndex = 192
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNuevo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(2, 2)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(84, 23)
        Me.BtnNuevo.TabIndex = 175
        Me.BtnNuevo.Text = "&Agregar"
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnEditar
        '
        Me.BtnEditar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEditar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditar.Image = CType(resources.GetObject("BtnEditar.Image"), System.Drawing.Image)
        Me.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEditar.Location = New System.Drawing.Point(87, 2)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(84, 23)
        Me.BtnEditar.TabIndex = 177
        Me.BtnEditar.Text = "Editar"
        Me.BtnEditar.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(172, 2)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(84, 23)
        Me.BtnEliminar.TabIndex = 178
        Me.BtnEliminar.Text = "Eliminar"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'Pan02
        '
        Me.Pan02.BackColor = System.Drawing.Color.White
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.BtnGrabar)
        Me.Pan02.Controls.Add(Me.BtnCerrar)
        Me.Pan02.Location = New System.Drawing.Point(589, 189)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(172, 29)
        Me.Pan02.TabIndex = 193
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnGrabar.Enabled = False
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(2, 2)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(84, 23)
        Me.BtnGrabar.TabIndex = 0
        Me.BtnGrabar.Text = "Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(87, 2)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(81, 23)
        Me.BtnCerrar.TabIndex = 1
        Me.BtnCerrar.Text = "&Cancelar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.AllowUserToDeleteRows = False
        Me.Dgv01.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv01.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Tipo, Me.Documento, Me.Fecha, Me.Proveedor, Me.Porc, Me.Total_Us, Me.Detraccion_Us, Me.Tc, Me.Total_Mn, Me.Detraccion_Mn, Me.c_ruc_prove, Me.c_fecha_cancel, Me.c_nro_constancia, Me.c_codi_det, Me.c_codi_prove, Me.c_codi_doc, Me.Item, Me.c_opc_cancel})
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(1, 2)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle11
        Me.Dgv01.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowTemplate.Height = 20
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Dgv01.Size = New System.Drawing.Size(761, 186)
        Me.Dgv01.TabIndex = 194
        '
        'Tipo
        '
        Me.Tipo.HeaderText = "Tipo"
        Me.Tipo.Name = "Tipo"
        Me.Tipo.ReadOnly = True
        Me.Tipo.Visible = False
        Me.Tipo.Width = 90
        '
        'Documento
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Documento.DefaultCellStyle = DataGridViewCellStyle2
        Me.Documento.HeaderText = "Documento"
        Me.Documento.Name = "Documento"
        Me.Documento.ReadOnly = True
        Me.Documento.Width = 90
        '
        'Fecha
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Fecha.DefaultCellStyle = DataGridViewCellStyle3
        Me.Fecha.HeaderText = "Fecha"
        Me.Fecha.Name = "Fecha"
        Me.Fecha.ReadOnly = True
        Me.Fecha.Width = 80
        '
        'Proveedor
        '
        Me.Proveedor.HeaderText = "Proveedor"
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.ReadOnly = True
        Me.Proveedor.Visible = False
        Me.Proveedor.Width = 220
        '
        'Porc
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Porc.DefaultCellStyle = DataGridViewCellStyle4
        Me.Porc.HeaderText = "%"
        Me.Porc.Name = "Porc"
        Me.Porc.ReadOnly = True
        Me.Porc.Width = 30
        '
        'Total_Us
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total_Us.DefaultCellStyle = DataGridViewCellStyle5
        Me.Total_Us.HeaderText = "Total-$."
        Me.Total_Us.Name = "Total_Us"
        Me.Total_Us.ReadOnly = True
        Me.Total_Us.Width = 75
        '
        'Detraccion_Us
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Detraccion_Us.DefaultCellStyle = DataGridViewCellStyle6
        Me.Detraccion_Us.HeaderText = "Detrac.$."
        Me.Detraccion_Us.Name = "Detraccion_Us"
        Me.Detraccion_Us.ReadOnly = True
        Me.Detraccion_Us.Width = 65
        '
        'Tc
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Tc.DefaultCellStyle = DataGridViewCellStyle7
        Me.Tc.HeaderText = "Tc."
        Me.Tc.Name = "Tc"
        Me.Tc.ReadOnly = True
        Me.Tc.Width = 45
        '
        'Total_Mn
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Total_Mn.DefaultCellStyle = DataGridViewCellStyle8
        Me.Total_Mn.HeaderText = "Total-S/."
        Me.Total_Mn.Name = "Total_Mn"
        Me.Total_Mn.ReadOnly = True
        Me.Total_Mn.Width = 75
        '
        'Detraccion_Mn
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Detraccion_Mn.DefaultCellStyle = DataGridViewCellStyle9
        Me.Detraccion_Mn.HeaderText = "Detrac.S/."
        Me.Detraccion_Mn.Name = "Detraccion_Mn"
        Me.Detraccion_Mn.ReadOnly = True
        Me.Detraccion_Mn.Width = 65
        '
        'c_ruc_prove
        '
        Me.c_ruc_prove.HeaderText = "c_ruc_prove"
        Me.c_ruc_prove.Name = "c_ruc_prove"
        Me.c_ruc_prove.ReadOnly = True
        Me.c_ruc_prove.Visible = False
        '
        'c_fecha_cancel
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.c_fecha_cancel.DefaultCellStyle = DataGridViewCellStyle10
        Me.c_fecha_cancel.HeaderText = "Fecha-Pago"
        Me.c_fecha_cancel.Name = "c_fecha_cancel"
        Me.c_fecha_cancel.ReadOnly = True
        Me.c_fecha_cancel.Width = 85
        '
        'c_nro_constancia
        '
        Me.c_nro_constancia.HeaderText = "Constancia"
        Me.c_nro_constancia.Name = "c_nro_constancia"
        Me.c_nro_constancia.ReadOnly = True
        Me.c_nro_constancia.Width = 115
        '
        'c_codi_det
        '
        Me.c_codi_det.HeaderText = "c_codi_det"
        Me.c_codi_det.Name = "c_codi_det"
        Me.c_codi_det.ReadOnly = True
        Me.c_codi_det.Visible = False
        '
        'c_codi_prove
        '
        Me.c_codi_prove.HeaderText = "c_codi_prove"
        Me.c_codi_prove.Name = "c_codi_prove"
        Me.c_codi_prove.ReadOnly = True
        Me.c_codi_prove.Visible = False
        '
        'c_codi_doc
        '
        Me.c_codi_doc.HeaderText = "c_codi_doc"
        Me.c_codi_doc.Name = "c_codi_doc"
        Me.c_codi_doc.ReadOnly = True
        Me.c_codi_doc.Visible = False
        '
        'Item
        '
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        Me.Item.Visible = False
        '
        'c_opc_cancel
        '
        Me.c_opc_cancel.HeaderText = "c_opc_cancel"
        Me.c_opc_cancel.Name = "c_opc_cancel"
        Me.c_opc_cancel.ReadOnly = True
        Me.c_opc_cancel.Visible = False
        '
        'Pan03
        '
        Me.Pan03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan03.Controls.Add(Me.TxtCod_Det)
        Me.Pan03.Controls.Add(Me.TxtNro_Ing)
        Me.Pan03.Controls.Add(Me.TxtCod_Doc)
        Me.Pan03.Controls.Add(Me.TxtItem)
        Me.Pan03.Controls.Add(Me.TxtConstancia)
        Me.Pan03.Controls.Add(Me.DtpFec_Pago)
        Me.Pan03.Controls.Add(Me.TxtDetrac_Mn)
        Me.Pan03.Controls.Add(Me.TxtTotal_Mn)
        Me.Pan03.Controls.Add(Me.TxtTc)
        Me.Pan03.Controls.Add(Me.TxtDetrac_Us)
        Me.Pan03.Controls.Add(Me.TxtTotal_Us)
        Me.Pan03.Controls.Add(Me.TxtPorc)
        Me.Pan03.Controls.Add(Me.TxtFecha)
        Me.Pan03.Controls.Add(Me.TxtFactura)
        Me.Pan03.Enabled = False
        Me.Pan03.Location = New System.Drawing.Point(1, 2)
        Me.Pan03.Name = "Pan03"
        Me.Pan03.Size = New System.Drawing.Size(761, 30)
        Me.Pan03.TabIndex = 195
        '
        'TxtCod_Det
        '
        Me.TxtCod_Det.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Det.Enabled = False
        Me.TxtCod_Det.Location = New System.Drawing.Point(667, 9)
        Me.TxtCod_Det.Name = "TxtCod_Det"
        Me.TxtCod_Det.Size = New System.Drawing.Size(52, 20)
        Me.TxtCod_Det.TabIndex = 15
        Me.TxtCod_Det.Visible = False
        '
        'TxtNro_Ing
        '
        Me.TxtNro_Ing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNro_Ing.Enabled = False
        Me.TxtNro_Ing.Location = New System.Drawing.Point(650, 9)
        Me.TxtNro_Ing.Name = "TxtNro_Ing"
        Me.TxtNro_Ing.Size = New System.Drawing.Size(52, 20)
        Me.TxtNro_Ing.TabIndex = 14
        Me.TxtNro_Ing.Visible = False
        '
        'TxtCod_Doc
        '
        Me.TxtCod_Doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Doc.Enabled = False
        Me.TxtCod_Doc.Location = New System.Drawing.Point(667, 9)
        Me.TxtCod_Doc.Name = "TxtCod_Doc"
        Me.TxtCod_Doc.Size = New System.Drawing.Size(52, 20)
        Me.TxtCod_Doc.TabIndex = 13
        Me.TxtCod_Doc.Visible = False
        '
        'TxtItem
        '
        Me.TxtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtItem.Enabled = False
        Me.TxtItem.Location = New System.Drawing.Point(650, 3)
        Me.TxtItem.Name = "TxtItem"
        Me.TxtItem.Size = New System.Drawing.Size(52, 20)
        Me.TxtItem.TabIndex = 11
        Me.TxtItem.Visible = False
        '
        'TxtConstancia
        '
        Me.TxtConstancia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConstancia.Location = New System.Drawing.Point(626, 4)
        Me.TxtConstancia.MaxLength = 15
        Me.TxtConstancia.Name = "TxtConstancia"
        Me.TxtConstancia.Size = New System.Drawing.Size(112, 20)
        Me.TxtConstancia.TabIndex = 9
        '
        'DtpFec_Pago
        '
        Me.DtpFec_Pago.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFec_Pago.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFec_Pago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Pago.Location = New System.Drawing.Point(540, 3)
        Me.DtpFec_Pago.Name = "DtpFec_Pago"
        Me.DtpFec_Pago.Size = New System.Drawing.Size(86, 21)
        Me.DtpFec_Pago.TabIndex = 8
        '
        'TxtDetrac_Mn
        '
        Me.TxtDetrac_Mn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDetrac_Mn.Location = New System.Drawing.Point(475, 4)
        Me.TxtDetrac_Mn.Name = "TxtDetrac_Mn"
        Me.TxtDetrac_Mn.Size = New System.Drawing.Size(64, 20)
        Me.TxtDetrac_Mn.TabIndex = 7
        Me.TxtDetrac_Mn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotal_Mn
        '
        Me.TxtTotal_Mn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotal_Mn.Location = New System.Drawing.Point(401, 4)
        Me.TxtTotal_Mn.Name = "TxtTotal_Mn"
        Me.TxtTotal_Mn.Size = New System.Drawing.Size(73, 20)
        Me.TxtTotal_Mn.TabIndex = 6
        Me.TxtTotal_Mn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTc
        '
        Me.TxtTc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTc.Location = New System.Drawing.Point(357, 4)
        Me.TxtTc.Name = "TxtTc"
        Me.TxtTc.Size = New System.Drawing.Size(43, 20)
        Me.TxtTc.TabIndex = 5
        Me.TxtTc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtDetrac_Us
        '
        Me.TxtDetrac_Us.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDetrac_Us.Location = New System.Drawing.Point(292, 4)
        Me.TxtDetrac_Us.Name = "TxtDetrac_Us"
        Me.TxtDetrac_Us.Size = New System.Drawing.Size(64, 20)
        Me.TxtDetrac_Us.TabIndex = 4
        Me.TxtDetrac_Us.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotal_Us
        '
        Me.TxtTotal_Us.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTotal_Us.Location = New System.Drawing.Point(217, 4)
        Me.TxtTotal_Us.Name = "TxtTotal_Us"
        Me.TxtTotal_Us.Size = New System.Drawing.Size(74, 20)
        Me.TxtTotal_Us.TabIndex = 3
        Me.TxtTotal_Us.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPorc
        '
        Me.TxtPorc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPorc.Enabled = False
        Me.TxtPorc.Location = New System.Drawing.Point(186, 4)
        Me.TxtPorc.Name = "TxtPorc"
        Me.TxtPorc.Size = New System.Drawing.Size(30, 20)
        Me.TxtPorc.TabIndex = 2
        '
        'TxtFecha
        '
        Me.TxtFecha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFecha.Enabled = False
        Me.TxtFecha.Location = New System.Drawing.Point(105, 4)
        Me.TxtFecha.Name = "TxtFecha"
        Me.TxtFecha.Size = New System.Drawing.Size(80, 20)
        Me.TxtFecha.TabIndex = 1
        '
        'TxtFactura
        '
        Me.TxtFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFactura.Enabled = False
        Me.TxtFactura.Location = New System.Drawing.Point(22, 4)
        Me.TxtFactura.Name = "TxtFactura"
        Me.TxtFactura.Size = New System.Drawing.Size(82, 20)
        Me.TxtFactura.TabIndex = 0
        '
        'TxtCod_Prove
        '
        Me.TxtCod_Prove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Prove.Enabled = False
        Me.TxtCod_Prove.Location = New System.Drawing.Point(592, 63)
        Me.TxtCod_Prove.Name = "TxtCod_Prove"
        Me.TxtCod_Prove.Size = New System.Drawing.Size(52, 20)
        Me.TxtCod_Prove.TabIndex = 10
        Me.TxtCod_Prove.Visible = False
        '
        'FrmDetracAnexas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(763, 220)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Pan03)
        Me.Controls.Add(Me.TxtCod_Prove)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Pan01)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmDetracAnexas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detracciones Anexas"
        Me.Pan01.ResumeLayout(False)
        Me.Pan02.ResumeLayout(False)
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan03.ResumeLayout(False)
        Me.Pan03.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnEditar As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Pan03 As System.Windows.Forms.Panel
    Friend WithEvents TxtConstancia As System.Windows.Forms.TextBox
    Friend WithEvents TxtDetrac_Mn As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal_Mn As System.Windows.Forms.TextBox
    Friend WithEvents TxtTc As System.Windows.Forms.TextBox
    Friend WithEvents TxtDetrac_Us As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal_Us As System.Windows.Forms.TextBox
    Friend WithEvents TxtPorc As System.Windows.Forms.TextBox
    Friend WithEvents TxtFecha As System.Windows.Forms.TextBox
    Friend WithEvents TxtFactura As System.Windows.Forms.TextBox
    Friend WithEvents DtpFec_Pago As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtCod_Prove As System.Windows.Forms.TextBox
    Friend WithEvents TxtItem As System.Windows.Forms.TextBox
    Friend WithEvents TxtCod_Doc As System.Windows.Forms.TextBox
    Friend WithEvents TxtNro_Ing As System.Windows.Forms.TextBox
    Friend WithEvents TxtCod_Det As System.Windows.Forms.TextBox
    Friend WithEvents Tipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Documento As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Proveedor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Porc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total_Us As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detraccion_Us As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Total_Mn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Detraccion_Mn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_ruc_prove As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_fecha_cancel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_nro_constancia As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_codi_det As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_codi_prove As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_codi_doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_opc_cancel As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
