<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptKardexValor
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptKardexValor))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Dgv02 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ingreso_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Salida_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Saldo_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe_3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Prb01 = New System.Windows.Forms.ProgressBar()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.TxtRuta = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.TxtCod_Sunat = New System.Windows.Forms.TextBox()
        Me.TxtDesc_TgSunat = New System.Windows.Forms.TextBox()
        Me.CboMon = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ChkSaldo = New System.Windows.Forms.CheckBox()
        Me.DtpFec_Final = New System.Windows.Forms.DateTimePicker()
        Me.DtpFec_Inicio = New System.Windows.Forms.DateTimePicker()
        Me.CboAlm = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCod_Articulo = New System.Windows.Forms.TextBox()
        Me.CboProv = New System.Windows.Forms.ComboBox()
        Me.CboMt = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnConArt = New System.Windows.Forms.Button()
        Me.TxtCod_Scd = New System.Windows.Forms.TextBox()
        Me.TxtArticulo = New System.Windows.Forms.TextBox()
        Me.TxtCod_Cd = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.TxtCod_Tg = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Folder01 = New System.Windows.Forms.FolderBrowserDialog()
        Me.BtnVista = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnKdxExpecial = New System.Windows.Forms.Button()
        Me.BtnHoja = New System.Windows.Forms.Button()
        Me.BtnKdxFisico = New System.Windows.Forms.Button()
        Me.BtnKdxValor = New System.Windows.Forms.Button()
        Me.BtnExcel = New System.Windows.Forms.Button()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LblActualizar = New System.Windows.Forms.Label()
        CType(Me.Dgv02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan02.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Pan01.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(51, 49)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(112, 13)
        Me.Label13.TabIndex = 211
        Me.Label13.Text = "Cargando el Archivo..."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(6, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(325, 13)
        Me.Label4.TabIndex = 210
        Me.Label4.Text = "Espere unos Instantes mientras el Sistema Procesa la Información..."
        '
        'Dgv02
        '
        Me.Dgv02.AllowUserToAddRows = False
        Me.Dgv02.AllowUserToDeleteRows = False
        Me.Dgv02.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv02.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv02.ColumnHeadersHeight = 19
        Me.Dgv02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv02.ColumnHeadersVisible = False
        Me.Dgv02.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Ingreso_1, Me.Importe_1, Me.Salida_1, Me.Importe_2, Me.Saldo_1, Me.Importe_3})
        Me.Dgv02.EnableHeadersVisualStyles = False
        Me.Dgv02.Location = New System.Drawing.Point(1, 493)
        Me.Dgv02.Name = "Dgv02"
        Me.Dgv02.ReadOnly = True
        Me.Dgv02.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.Dgv02.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv02.RowTemplate.Height = 18
        Me.Dgv02.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Dgv02.Size = New System.Drawing.Size(1107, 23)
        Me.Dgv02.TabIndex = 236
        '
        'Column1
        '
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 50
        '
        'Column3
        '
        Me.Column3.HeaderText = "Column3"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 70
        '
        'Column4
        '
        Me.Column4.HeaderText = "Column4"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 140
        '
        'Column5
        '
        Me.Column5.HeaderText = "Column5"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 55
        '
        'Column6
        '
        Me.Column6.HeaderText = "Column6"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Width = 120
        '
        'Ingreso_1
        '
        Me.Ingreso_1.HeaderText = "Ingreso"
        Me.Ingreso_1.Name = "Ingreso_1"
        Me.Ingreso_1.ReadOnly = True
        Me.Ingreso_1.Width = 75
        '
        'Importe_1
        '
        Me.Importe_1.HeaderText = "Importe_1"
        Me.Importe_1.Name = "Importe_1"
        Me.Importe_1.ReadOnly = True
        Me.Importe_1.Width = 65
        '
        'Salida_1
        '
        Me.Salida_1.HeaderText = "Salida"
        Me.Salida_1.Name = "Salida_1"
        Me.Salida_1.ReadOnly = True
        Me.Salida_1.Width = 65
        '
        'Importe_2
        '
        Me.Importe_2.HeaderText = "Importe_2"
        Me.Importe_2.Name = "Importe_2"
        Me.Importe_2.ReadOnly = True
        Me.Importe_2.Width = 65
        '
        'Saldo_1
        '
        Me.Saldo_1.HeaderText = "Saldo"
        Me.Saldo_1.Name = "Saldo_1"
        Me.Saldo_1.ReadOnly = True
        Me.Saldo_1.Width = 70
        '
        'Importe_3
        '
        Me.Importe_3.HeaderText = "Importe_3"
        Me.Importe_3.Name = "Importe_3"
        Me.Importe_3.ReadOnly = True
        Me.Importe_3.Width = 75
        '
        'Prb01
        '
        Me.Prb01.Location = New System.Drawing.Point(46, 23)
        Me.Prb01.Name = "Prb01"
        Me.Prb01.Size = New System.Drawing.Size(252, 23)
        Me.Prb01.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.Prb01.TabIndex = 209
        Me.Prb01.Visible = False
        '
        'Pan02
        '
        Me.Pan02.BackColor = System.Drawing.Color.White
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.Label13)
        Me.Pan02.Controls.Add(Me.Label4)
        Me.Pan02.Controls.Add(Me.Prb01)
        Me.Pan02.Location = New System.Drawing.Point(327, 244)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(344, 68)
        Me.Pan02.TabIndex = 235
        Me.Pan02.Visible = False
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.Color.Transparent
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(1, 1)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(101, 30)
        Me.BtnCerrar.TabIndex = 4
        Me.BtnCerrar.Text = "Cerrar "
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'BtnOpen
        '
        Me.BtnOpen.BackColor = System.Drawing.Color.White
        Me.BtnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOpen.Image = CType(resources.GetObject("BtnOpen.Image"), System.Drawing.Image)
        Me.BtnOpen.Location = New System.Drawing.Point(241, 3)
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.Size = New System.Drawing.Size(31, 22)
        Me.BtnOpen.TabIndex = 5
        Me.BtnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOpen.UseVisualStyleBackColor = False
        '
        'TxtRuta
        '
        Me.TxtRuta.BackColor = System.Drawing.Color.White
        Me.TxtRuta.Location = New System.Drawing.Point(3, 3)
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.ReadOnly = True
        Me.TxtRuta.Size = New System.Drawing.Size(237, 20)
        Me.TxtRuta.TabIndex = 4
        Me.TxtRuta.Text = "D:\Reporte_Kardex.XLS"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnCerrar)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(1002, 518)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(105, 34)
        Me.Panel2.TabIndex = 234
        '
        'Pan01
        '
        Me.Pan01.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pan01.BackColor = System.Drawing.Color.Silver
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pan01.Controls.Add(Me.TxtCod_Sunat)
        Me.Pan01.Controls.Add(Me.TxtDesc_TgSunat)
        Me.Pan01.Controls.Add(Me.CboMon)
        Me.Pan01.Controls.Add(Me.Label2)
        Me.Pan01.Controls.Add(Me.ChkSaldo)
        Me.Pan01.Controls.Add(Me.DtpFec_Final)
        Me.Pan01.Controls.Add(Me.DtpFec_Inicio)
        Me.Pan01.Controls.Add(Me.CboAlm)
        Me.Pan01.Controls.Add(Me.Label3)
        Me.Pan01.Controls.Add(Me.TxtCod_Articulo)
        Me.Pan01.Controls.Add(Me.CboProv)
        Me.Pan01.Controls.Add(Me.CboMt)
        Me.Pan01.Controls.Add(Me.Label1)
        Me.Pan01.Controls.Add(Me.BtnConArt)
        Me.Pan01.Controls.Add(Me.TxtCod_Scd)
        Me.Pan01.Controls.Add(Me.TxtArticulo)
        Me.Pan01.Controls.Add(Me.TxtCod_Cd)
        Me.Pan01.Controls.Add(Me.PictureBox1)
        Me.Pan01.Controls.Add(Me.Panel1)
        Me.Pan01.Controls.Add(Me.TxtCod_Tg)
        Me.Pan01.Controls.Add(Me.Label17)
        Me.Pan01.Controls.Add(Me.Label16)
        Me.Pan01.Controls.Add(Me.Label14)
        Me.Pan01.Controls.Add(Me.Label15)
        Me.Pan01.Location = New System.Drawing.Point(1, 2)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(1107, 82)
        Me.Pan01.TabIndex = 230
        '
        'TxtCod_Sunat
        '
        Me.TxtCod_Sunat.BackColor = System.Drawing.Color.White
        Me.TxtCod_Sunat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Sunat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Sunat.Location = New System.Drawing.Point(1015, 6)
        Me.TxtCod_Sunat.MaxLength = 3
        Me.TxtCod_Sunat.Multiline = True
        Me.TxtCod_Sunat.Name = "TxtCod_Sunat"
        Me.TxtCod_Sunat.Size = New System.Drawing.Size(34, 22)
        Me.TxtCod_Sunat.TabIndex = 188
        Me.TxtCod_Sunat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtCod_Sunat.Visible = False
        '
        'TxtDesc_TgSunat
        '
        Me.TxtDesc_TgSunat.BackColor = System.Drawing.Color.White
        Me.TxtDesc_TgSunat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDesc_TgSunat.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDesc_TgSunat.Location = New System.Drawing.Point(1015, 26)
        Me.TxtDesc_TgSunat.MaxLength = 3
        Me.TxtDesc_TgSunat.Multiline = True
        Me.TxtDesc_TgSunat.Name = "TxtDesc_TgSunat"
        Me.TxtDesc_TgSunat.Size = New System.Drawing.Size(56, 22)
        Me.TxtDesc_TgSunat.TabIndex = 187
        Me.TxtDesc_TgSunat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtDesc_TgSunat.Visible = False
        '
        'CboMon
        '
        Me.CboMon.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMon.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboMon.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMon.FormattingEnabled = True
        Me.CboMon.Location = New System.Drawing.Point(776, 51)
        Me.CboMon.Name = "CboMon"
        Me.CboMon.Size = New System.Drawing.Size(42, 22)
        Me.CboMon.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(715, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 24)
        Me.Label2.TabIndex = 186
        Me.Label2.Text = "Moneda"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChkSaldo
        '
        Me.ChkSaldo.AutoSize = True
        Me.ChkSaldo.BackColor = System.Drawing.Color.White
        Me.ChkSaldo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkSaldo.Checked = True
        Me.ChkSaldo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkSaldo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkSaldo.Location = New System.Drawing.Point(821, 54)
        Me.ChkSaldo.Name = "ChkSaldo"
        Me.ChkSaldo.Size = New System.Drawing.Size(161, 17)
        Me.ChkSaldo.TabIndex = 12
        Me.ChkSaldo.Text = "Mostrar Saldos Iniciales"
        Me.ChkSaldo.UseVisualStyleBackColor = False
        '
        'DtpFec_Final
        '
        Me.DtpFec_Final.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFec_Final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Final.Location = New System.Drawing.Point(163, 28)
        Me.DtpFec_Final.Name = "DtpFec_Final"
        Me.DtpFec_Final.Size = New System.Drawing.Size(98, 21)
        Me.DtpFec_Final.TabIndex = 1
        '
        'DtpFec_Inicio
        '
        Me.DtpFec_Inicio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFec_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Inicio.Location = New System.Drawing.Point(63, 28)
        Me.DtpFec_Inicio.Name = "DtpFec_Inicio"
        Me.DtpFec_Inicio.Size = New System.Drawing.Size(98, 21)
        Me.DtpFec_Inicio.TabIndex = 0
        '
        'CboAlm
        '
        Me.CboAlm.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CboAlm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboAlm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboAlm.FormattingEnabled = True
        Me.CboAlm.Location = New System.Drawing.Point(781, 27)
        Me.CboAlm.Name = "CboAlm"
        Me.CboAlm.Size = New System.Drawing.Size(211, 22)
        Me.CboAlm.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(780, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(212, 22)
        Me.Label3.TabIndex = 182
        Me.Label3.Text = "Almacén"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCod_Articulo
        '
        Me.TxtCod_Articulo.BackColor = System.Drawing.Color.White
        Me.TxtCod_Articulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Articulo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Articulo.Location = New System.Drawing.Point(363, 28)
        Me.TxtCod_Articulo.MaxLength = 3
        Me.TxtCod_Articulo.Multiline = True
        Me.TxtCod_Articulo.Name = "TxtCod_Articulo"
        Me.TxtCod_Articulo.Size = New System.Drawing.Size(74, 22)
        Me.TxtCod_Articulo.TabIndex = 5
        Me.TxtCod_Articulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CboProv
        '
        Me.CboProv.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CboProv.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboProv.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboProv.FormattingEnabled = True
        Me.CboProv.Location = New System.Drawing.Point(135, 51)
        Me.CboProv.Name = "CboProv"
        Me.CboProv.Size = New System.Drawing.Size(264, 22)
        Me.CboProv.TabIndex = 9
        '
        'CboMt
        '
        Me.CboMt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CboMt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboMt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMt.FormattingEnabled = True
        Me.CboMt.Location = New System.Drawing.Point(509, 51)
        Me.CboMt.Name = "CboMt"
        Me.CboMt.Size = New System.Drawing.Size(204, 22)
        Me.CboMt.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(62, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 23)
        Me.Label1.TabIndex = 179
        Me.Label1.Text = "Proveedor"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnConArt
        '
        Me.BtnConArt.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnConArt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnConArt.Image = CType(resources.GetObject("BtnConArt.Image"), System.Drawing.Image)
        Me.BtnConArt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConArt.Location = New System.Drawing.Point(755, 28)
        Me.BtnConArt.Name = "BtnConArt"
        Me.BtnConArt.Size = New System.Drawing.Size(25, 22)
        Me.BtnConArt.TabIndex = 7
        Me.BtnConArt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConArt.UseVisualStyleBackColor = False
        '
        'TxtCod_Scd
        '
        Me.TxtCod_Scd.BackColor = System.Drawing.Color.White
        Me.TxtCod_Scd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Scd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Scd.Location = New System.Drawing.Point(329, 28)
        Me.TxtCod_Scd.MaxLength = 3
        Me.TxtCod_Scd.Multiline = True
        Me.TxtCod_Scd.Name = "TxtCod_Scd"
        Me.TxtCod_Scd.Size = New System.Drawing.Size(34, 22)
        Me.TxtCod_Scd.TabIndex = 4
        Me.TxtCod_Scd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtArticulo
        '
        Me.TxtArticulo.BackColor = System.Drawing.Color.White
        Me.TxtArticulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtArticulo.Enabled = False
        Me.TxtArticulo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtArticulo.Location = New System.Drawing.Point(437, 28)
        Me.TxtArticulo.MaxLength = 7
        Me.TxtArticulo.Multiline = True
        Me.TxtArticulo.Name = "TxtArticulo"
        Me.TxtArticulo.Size = New System.Drawing.Size(318, 22)
        Me.TxtArticulo.TabIndex = 6
        Me.TxtArticulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCod_Cd
        '
        Me.TxtCod_Cd.BackColor = System.Drawing.Color.White
        Me.TxtCod_Cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Cd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Cd.Location = New System.Drawing.Point(295, 28)
        Me.TxtCod_Cd.MaxLength = 3
        Me.TxtCod_Cd.Multiline = True
        Me.TxtCod_Cd.Name = "TxtCod_Cd"
        Me.TxtCod_Cd.Size = New System.Drawing.Size(34, 22)
        Me.TxtCod_Cd.TabIndex = 3
        Me.TxtCod_Cd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 21)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 171
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnMostrar)
        Me.Panel1.Location = New System.Drawing.Point(999, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(79, 27)
        Me.Panel1.TabIndex = 13
        '
        'BtnMostrar
        '
        Me.BtnMostrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnMostrar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMostrar.Image = CType(resources.GetObject("BtnMostrar.Image"), System.Drawing.Image)
        Me.BtnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMostrar.Location = New System.Drawing.Point(1, 1)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(75, 23)
        Me.BtnMostrar.TabIndex = 4
        Me.BtnMostrar.Text = "&Mostrar"
        Me.BtnMostrar.UseVisualStyleBackColor = False
        '
        'TxtCod_Tg
        '
        Me.TxtCod_Tg.BackColor = System.Drawing.Color.White
        Me.TxtCod_Tg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Tg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Tg.Location = New System.Drawing.Point(261, 28)
        Me.TxtCod_Tg.MaxLength = 3
        Me.TxtCod_Tg.Multiline = True
        Me.TxtCod_Tg.Name = "TxtCod_Tg"
        Me.TxtCod_Tg.Size = New System.Drawing.Size(34, 22)
        Me.TxtCod_Tg.TabIndex = 2
        Me.TxtCod_Tg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(63, 6)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 22)
        Me.Label17.TabIndex = 166
        Me.Label17.Text = "Del"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(261, 6)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(519, 22)
        Me.Label16.TabIndex = 163
        Me.Label16.Text = "Artículo"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(162, 6)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 22)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Al"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(400, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(107, 23)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Mótivo Despacho"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnVista
        '
        Me.BtnVista.BackColor = System.Drawing.Color.Transparent
        Me.BtnVista.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnVista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVista.Image = CType(resources.GetObject("BtnVista.Image"), System.Drawing.Image)
        Me.BtnVista.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnVista.Location = New System.Drawing.Point(356, 1)
        Me.BtnVista.Name = "BtnVista"
        Me.BtnVista.Size = New System.Drawing.Size(101, 30)
        Me.BtnVista.TabIndex = 4
        Me.BtnVista.Text = "Vista Preliminar"
        Me.BtnVista.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnVista.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtnOpen)
        Me.Panel4.Controls.Add(Me.TxtRuta)
        Me.Panel4.Location = New System.Drawing.Point(69, 1)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(277, 30)
        Me.Panel4.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnKdxExpecial)
        Me.Panel3.Controls.Add(Me.BtnHoja)
        Me.Panel3.Controls.Add(Me.BtnKdxFisico)
        Me.Panel3.Controls.Add(Me.BtnKdxValor)
        Me.Panel3.Controls.Add(Me.BtnVista)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.BtnExcel)
        Me.Panel3.Controls.Add(Me.BtnExportar)
        Me.Panel3.Location = New System.Drawing.Point(2, 518)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(964, 34)
        Me.Panel3.TabIndex = 233
        '
        'BtnKdxExpecial
        '
        Me.BtnKdxExpecial.BackColor = System.Drawing.Color.Transparent
        Me.BtnKdxExpecial.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnKdxExpecial.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKdxExpecial.Image = CType(resources.GetObject("BtnKdxExpecial.Image"), System.Drawing.Image)
        Me.BtnKdxExpecial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnKdxExpecial.Location = New System.Drawing.Point(832, 1)
        Me.BtnKdxExpecial.Name = "BtnKdxExpecial"
        Me.BtnKdxExpecial.Size = New System.Drawing.Size(129, 30)
        Me.BtnKdxExpecial.TabIndex = 9
        Me.BtnKdxExpecial.Text = "Kardex Especial"
        Me.BtnKdxExpecial.UseVisualStyleBackColor = False
        '
        'BtnHoja
        '
        Me.BtnHoja.BackColor = System.Drawing.Color.Transparent
        Me.BtnHoja.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnHoja.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHoja.Image = CType(resources.GetObject("BtnHoja.Image"), System.Drawing.Image)
        Me.BtnHoja.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnHoja.Location = New System.Drawing.Point(702, 1)
        Me.BtnHoja.Name = "BtnHoja"
        Me.BtnHoja.Size = New System.Drawing.Size(129, 30)
        Me.BtnHoja.TabIndex = 8
        Me.BtnHoja.Text = "Hoja de Resumen"
        Me.BtnHoja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnHoja.UseVisualStyleBackColor = False
        '
        'BtnKdxFisico
        '
        Me.BtnKdxFisico.BackColor = System.Drawing.Color.Transparent
        Me.BtnKdxFisico.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnKdxFisico.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKdxFisico.Image = CType(resources.GetObject("BtnKdxFisico.Image"), System.Drawing.Image)
        Me.BtnKdxFisico.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnKdxFisico.Location = New System.Drawing.Point(584, 1)
        Me.BtnKdxFisico.Name = "BtnKdxFisico"
        Me.BtnKdxFisico.Size = New System.Drawing.Size(117, 30)
        Me.BtnKdxFisico.TabIndex = 7
        Me.BtnKdxFisico.Text = "   Kardex Físico"
        Me.BtnKdxFisico.UseVisualStyleBackColor = False
        '
        'BtnKdxValor
        '
        Me.BtnKdxValor.BackColor = System.Drawing.Color.Transparent
        Me.BtnKdxValor.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnKdxValor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnKdxValor.Image = CType(resources.GetObject("BtnKdxValor.Image"), System.Drawing.Image)
        Me.BtnKdxValor.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnKdxValor.Location = New System.Drawing.Point(458, 1)
        Me.BtnKdxValor.Name = "BtnKdxValor"
        Me.BtnKdxValor.Size = New System.Drawing.Size(125, 30)
        Me.BtnKdxValor.TabIndex = 6
        Me.BtnKdxValor.Text = "Kardex Sunat"
        Me.BtnKdxValor.UseVisualStyleBackColor = False
        '
        'BtnExcel
        '
        Me.BtnExcel.BackColor = System.Drawing.Color.White
        Me.BtnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExcel.Image = CType(resources.GetObject("BtnExcel.Image"), System.Drawing.Image)
        Me.BtnExcel.Location = New System.Drawing.Point(33, 1)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(34, 30)
        Me.BtnExcel.TabIndex = 2
        Me.BtnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExcel.UseVisualStyleBackColor = False
        '
        'BtnExportar
        '
        Me.BtnExportar.BackColor = System.Drawing.Color.Transparent
        Me.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExportar.Image = CType(resources.GetObject("BtnExportar.Image"), System.Drawing.Image)
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.Location = New System.Drawing.Point(1, 1)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(67, 30)
        Me.BtnExportar.TabIndex = 1
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.UseVisualStyleBackColor = False
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.AllowUserToDeleteRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv01.ColumnHeadersHeight = 19
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(1, 102)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv01.RowTemplate.Height = 18
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(1107, 390)
        Me.Dgv01.TabIndex = 231
        '
        'Label12
        '
        Me.Label12.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(1, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(1108, 18)
        Me.Label12.TabIndex = 232
        Me.Label12.Text = "Artículos"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblActualizar
        '
        Me.LblActualizar.BackColor = System.Drawing.Color.Red
        Me.LblActualizar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblActualizar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblActualizar.ForeColor = System.Drawing.Color.White
        Me.LblActualizar.Location = New System.Drawing.Point(971, 468)
        Me.LblActualizar.Name = "LblActualizar"
        Me.LblActualizar.Size = New System.Drawing.Size(134, 22)
        Me.LblActualizar.TabIndex = 238
        Me.LblActualizar.Text = "[F5] Actualiza KARDEX"
        Me.LblActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LblActualizar.Visible = False
        '
        'FrmRptKardexValor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1110, 554)
        Me.Controls.Add(Me.LblActualizar)
        Me.Controls.Add(Me.Dgv02)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Pan01)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Label12)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRptKardexValor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kardex Valorizado - [Almacen General]"
        CType(Me.Dgv02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan02.ResumeLayout(False)
        Me.Pan02.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Dgv02 As System.Windows.Forms.DataGridView
    Friend WithEvents Prb01 As System.Windows.Forms.ProgressBar
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents BtnOpen As System.Windows.Forms.Button
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents ChkSaldo As System.Windows.Forms.CheckBox
    Friend WithEvents DtpFec_Final As System.Windows.Forms.DateTimePicker
    Friend WithEvents DtpFec_Inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents CboAlm As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtCod_Articulo As System.Windows.Forms.TextBox
    Friend WithEvents CboProv As System.Windows.Forms.ComboBox
    Friend WithEvents CboMt As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnConArt As System.Windows.Forms.Button
    Friend WithEvents TxtCod_Scd As System.Windows.Forms.TextBox
    Friend WithEvents TxtArticulo As System.Windows.Forms.TextBox
    Friend WithEvents TxtCod_Cd As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents TxtCod_Tg As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Folder01 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents BtnVista As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtnExcel As System.Windows.Forms.Button
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CboMon As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnKdxFisico As System.Windows.Forms.Button
    Friend WithEvents BtnKdxValor As System.Windows.Forms.Button
    Friend WithEvents TxtCod_Sunat As System.Windows.Forms.TextBox
    Friend WithEvents TxtDesc_TgSunat As System.Windows.Forms.TextBox
    Friend WithEvents BtnHoja As Button
    Friend WithEvents LblActualizar As Label
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Ingreso_1 As DataGridViewTextBoxColumn
    Friend WithEvents Importe_1 As DataGridViewTextBoxColumn
    Friend WithEvents Salida_1 As DataGridViewTextBoxColumn
    Friend WithEvents Importe_2 As DataGridViewTextBoxColumn
    Friend WithEvents Saldo_1 As DataGridViewTextBoxColumn
    Friend WithEvents Importe_3 As DataGridViewTextBoxColumn
    Friend WithEvents BtnKdxExpecial As Button
End Class
