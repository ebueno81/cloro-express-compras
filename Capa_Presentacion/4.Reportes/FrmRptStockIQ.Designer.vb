<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptStockIQ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptStockIQ))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.CboAlm = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtCod_Articulo = New System.Windows.Forms.TextBox()
        Me.CboMes = New System.Windows.Forms.ComboBox()
        Me.CboAño = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnConCd = New System.Windows.Forms.Button()
        Me.BtnConTg = New System.Windows.Forms.Button()
        Me.BtnConScd = New System.Windows.Forms.Button()
        Me.TxtCod_Scd = New System.Windows.Forms.TextBox()
        Me.TxtScd = New System.Windows.Forms.TextBox()
        Me.TxtCod_Cd = New System.Windows.Forms.TextBox()
        Me.TxtCd = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.TxtCod_Tg = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Pcb01 = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtTg = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnVista = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.TxtRuta = New System.Windows.Forms.TextBox()
        Me.BtnExcel = New System.Windows.Forms.Button()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.Folder01 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Prb01 = New System.Windows.Forms.ProgressBar()
        Me.CboMon = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtTot_07 = New System.Windows.Forms.TextBox()
        Me.TxtTot_05 = New System.Windows.Forms.TextBox()
        Me.TxtTot_03 = New System.Windows.Forms.TextBox()
        Me.TxtTitulo_1 = New System.Windows.Forms.TextBox()
        Me.TxtConta_1 = New System.Windows.Forms.TextBox()
        Me.Pan01.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Pan02.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pan01
        '
        Me.Pan01.BackColor = System.Drawing.Color.White
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pan01.Controls.Add(Me.CboMon)
        Me.Pan01.Controls.Add(Me.Label5)
        Me.Pan01.Controls.Add(Me.CboAlm)
        Me.Pan01.Controls.Add(Me.Label3)
        Me.Pan01.Controls.Add(Me.TxtCod_Articulo)
        Me.Pan01.Controls.Add(Me.CboMes)
        Me.Pan01.Controls.Add(Me.CboAño)
        Me.Pan01.Controls.Add(Me.Label2)
        Me.Pan01.Controls.Add(Me.Label1)
        Me.Pan01.Controls.Add(Me.BtnConCd)
        Me.Pan01.Controls.Add(Me.BtnConTg)
        Me.Pan01.Controls.Add(Me.BtnConScd)
        Me.Pan01.Controls.Add(Me.TxtCod_Scd)
        Me.Pan01.Controls.Add(Me.TxtScd)
        Me.Pan01.Controls.Add(Me.TxtCod_Cd)
        Me.Pan01.Controls.Add(Me.TxtCd)
        Me.Pan01.Controls.Add(Me.PictureBox1)
        Me.Pan01.Controls.Add(Me.Panel1)
        Me.Pan01.Controls.Add(Me.TxtCod_Tg)
        Me.Pan01.Controls.Add(Me.Label17)
        Me.Pan01.Controls.Add(Me.Label16)
        Me.Pan01.Controls.Add(Me.Pcb01)
        Me.Pan01.Controls.Add(Me.Label14)
        Me.Pan01.Controls.Add(Me.TxtTg)
        Me.Pan01.Controls.Add(Me.Label15)
        Me.Pan01.Location = New System.Drawing.Point(1, 1)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(902, 87)
        Me.Pan01.TabIndex = 0
        '
        'CboAlm
        '
        Me.CboAlm.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboAlm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboAlm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboAlm.FormattingEnabled = True
        Me.CboAlm.Location = New System.Drawing.Point(683, 7)
        Me.CboAlm.Name = "CboAlm"
        Me.CboAlm.Size = New System.Drawing.Size(129, 22)
        Me.CboAlm.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(606, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 22)
        Me.Label3.TabIndex = 182
        Me.Label3.Text = "Almacén"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCod_Articulo
        '
        Me.TxtCod_Articulo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TxtCod_Articulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Articulo.Enabled = False
        Me.TxtCod_Articulo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Articulo.Location = New System.Drawing.Point(514, 52)
        Me.TxtCod_Articulo.MaxLength = 3
        Me.TxtCod_Articulo.Name = "TxtCod_Articulo"
        Me.TxtCod_Articulo.Size = New System.Drawing.Size(91, 21)
        Me.TxtCod_Articulo.TabIndex = 11
        Me.TxtCod_Articulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CboMes
        '
        Me.CboMes.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboMes.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMes.FormattingEnabled = True
        Me.CboMes.Location = New System.Drawing.Point(514, 29)
        Me.CboMes.Name = "CboMes"
        Me.CboMes.Size = New System.Drawing.Size(91, 22)
        Me.CboMes.TabIndex = 10
        '
        'CboAño
        '
        Me.CboAño.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAño.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboAño.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboAño.FormattingEnabled = True
        Me.CboAño.Location = New System.Drawing.Point(514, 7)
        Me.CboAño.Name = "CboAño"
        Me.CboAño.Size = New System.Drawing.Size(91, 22)
        Me.CboAño.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(435, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 22)
        Me.Label2.TabIndex = 180
        Me.Label2.Text = "Código IQ"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(435, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 22)
        Me.Label1.TabIndex = 179
        Me.Label1.Text = "Mes"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnConCd
        '
        Me.BtnConCd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnConCd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnConCd.Image = CType(resources.GetObject("BtnConCd.Image"), System.Drawing.Image)
        Me.BtnConCd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConCd.Location = New System.Drawing.Point(409, 30)
        Me.BtnConCd.Name = "BtnConCd"
        Me.BtnConCd.Size = New System.Drawing.Size(25, 21)
        Me.BtnConCd.TabIndex = 5
        Me.BtnConCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConCd.UseVisualStyleBackColor = False
        '
        'BtnConTg
        '
        Me.BtnConTg.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnConTg.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnConTg.Image = CType(resources.GetObject("BtnConTg.Image"), System.Drawing.Image)
        Me.BtnConTg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConTg.Location = New System.Drawing.Point(409, 8)
        Me.BtnConTg.Name = "BtnConTg"
        Me.BtnConTg.Size = New System.Drawing.Size(25, 21)
        Me.BtnConTg.TabIndex = 2
        Me.BtnConTg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConTg.UseVisualStyleBackColor = False
        '
        'BtnConScd
        '
        Me.BtnConScd.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnConScd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnConScd.Image = CType(resources.GetObject("BtnConScd.Image"), System.Drawing.Image)
        Me.BtnConScd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConScd.Location = New System.Drawing.Point(409, 52)
        Me.BtnConScd.Name = "BtnConScd"
        Me.BtnConScd.Size = New System.Drawing.Size(25, 21)
        Me.BtnConScd.TabIndex = 8
        Me.BtnConScd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConScd.UseVisualStyleBackColor = False
        '
        'TxtCod_Scd
        '
        Me.TxtCod_Scd.BackColor = System.Drawing.Color.White
        Me.TxtCod_Scd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Scd.Enabled = False
        Me.TxtCod_Scd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Scd.Location = New System.Drawing.Point(131, 52)
        Me.TxtCod_Scd.MaxLength = 3
        Me.TxtCod_Scd.Name = "TxtCod_Scd"
        Me.TxtCod_Scd.Size = New System.Drawing.Size(36, 21)
        Me.TxtCod_Scd.TabIndex = 6
        Me.TxtCod_Scd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtScd
        '
        Me.TxtScd.BackColor = System.Drawing.Color.White
        Me.TxtScd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtScd.Enabled = False
        Me.TxtScd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtScd.Location = New System.Drawing.Point(168, 52)
        Me.TxtScd.MaxLength = 7
        Me.TxtScd.Name = "TxtScd"
        Me.TxtScd.Size = New System.Drawing.Size(240, 21)
        Me.TxtScd.TabIndex = 7
        Me.TxtScd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCod_Cd
        '
        Me.TxtCod_Cd.BackColor = System.Drawing.Color.White
        Me.TxtCod_Cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Cd.Enabled = False
        Me.TxtCod_Cd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Cd.Location = New System.Drawing.Point(131, 30)
        Me.TxtCod_Cd.MaxLength = 3
        Me.TxtCod_Cd.Name = "TxtCod_Cd"
        Me.TxtCod_Cd.Size = New System.Drawing.Size(36, 21)
        Me.TxtCod_Cd.TabIndex = 3
        Me.TxtCod_Cd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCd
        '
        Me.TxtCd.BackColor = System.Drawing.Color.White
        Me.TxtCd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCd.Enabled = False
        Me.TxtCd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCd.Location = New System.Drawing.Point(168, 30)
        Me.TxtCd.MaxLength = 7
        Me.TxtCd.Name = "TxtCd"
        Me.TxtCd.Size = New System.Drawing.Size(240, 21)
        Me.TxtCd.TabIndex = 4
        Me.TxtCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(5, 40)
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
        Me.Panel1.Location = New System.Drawing.Point(816, 52)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(79, 27)
        Me.Panel1.TabIndex = 12
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
        Me.TxtCod_Tg.Enabled = False
        Me.TxtCod_Tg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Tg.Location = New System.Drawing.Point(131, 8)
        Me.TxtCod_Tg.MaxLength = 3
        Me.TxtCod_Tg.Name = "TxtCod_Tg"
        Me.TxtCod_Tg.Size = New System.Drawing.Size(36, 21)
        Me.TxtCod_Tg.TabIndex = 0
        Me.TxtCod_Tg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(51, 8)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(80, 22)
        Me.Label17.TabIndex = 166
        Me.Label17.Text = "Motivo"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(51, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 22)
        Me.Label16.TabIndex = 163
        Me.Label16.Text = "Artículo"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pcb01
        '
        Me.Pcb01.Image = CType(resources.GetObject("Pcb01.Image"), System.Drawing.Image)
        Me.Pcb01.Location = New System.Drawing.Point(5, 4)
        Me.Pcb01.Name = "Pcb01"
        Me.Pcb01.Size = New System.Drawing.Size(32, 30)
        Me.Pcb01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pcb01.TabIndex = 162
        Me.Pcb01.TabStop = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(51, 30)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 22)
        Me.Label14.TabIndex = 33
        Me.Label14.Text = "Caída"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTg
        '
        Me.TxtTg.BackColor = System.Drawing.Color.White
        Me.TxtTg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTg.Enabled = False
        Me.TxtTg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTg.Location = New System.Drawing.Point(168, 8)
        Me.TxtTg.MaxLength = 7
        Me.TxtTg.Name = "TxtTg"
        Me.TxtTg.Size = New System.Drawing.Size(240, 21)
        Me.TxtTg.TabIndex = 1
        Me.TxtTg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(435, 8)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 22)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Año"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.AllowUserToDeleteRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(1, 105)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv01.RowTemplate.Height = 18
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(902, 383)
        Me.Dgv01.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(1, 87)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(903, 18)
        Me.Label12.TabIndex = 188
        Me.Label12.Text = "Artículos"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnVista)
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.BtnExcel)
        Me.Panel3.Controls.Add(Me.BtnExportar)
        Me.Panel3.Location = New System.Drawing.Point(1, 513)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(465, 34)
        Me.Panel3.TabIndex = 2
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
        Me.BtnVista.Size = New System.Drawing.Size(106, 30)
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
        Me.Panel4.Size = New System.Drawing.Size(286, 30)
        Me.Panel4.TabIndex = 2
        '
        'BtnOpen
        '
        Me.BtnOpen.BackColor = System.Drawing.Color.White
        Me.BtnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOpen.Image = CType(resources.GetObject("BtnOpen.Image"), System.Drawing.Image)
        Me.BtnOpen.Location = New System.Drawing.Point(252, 3)
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
        Me.TxtRuta.Size = New System.Drawing.Size(249, 20)
        Me.TxtRuta.TabIndex = 4
        Me.TxtRuta.Text = "D:\Reporte_Stock.XLS"
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
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnCerrar)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(714, 513)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(105, 34)
        Me.Panel2.TabIndex = 3
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
        'Pan02
        '
        Me.Pan02.BackColor = System.Drawing.Color.White
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.Label13)
        Me.Pan02.Controls.Add(Me.Label4)
        Me.Pan02.Controls.Add(Me.Prb01)
        Me.Pan02.Location = New System.Drawing.Point(239, 240)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(344, 68)
        Me.Pan02.TabIndex = 222
        Me.Pan02.Visible = False
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
        'Prb01
        '
        Me.Prb01.Location = New System.Drawing.Point(46, 23)
        Me.Prb01.Name = "Prb01"
        Me.Prb01.Size = New System.Drawing.Size(252, 23)
        Me.Prb01.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.Prb01.TabIndex = 209
        Me.Prb01.Visible = False
        '
        'CboMon
        '
        Me.CboMon.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMon.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboMon.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMon.FormattingEnabled = True
        Me.CboMon.Location = New System.Drawing.Point(683, 28)
        Me.CboMon.Name = "CboMon"
        Me.CboMon.Size = New System.Drawing.Size(49, 22)
        Me.CboMon.TabIndex = 185
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(606, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 22)
        Me.Label5.TabIndex = 186
        Me.Label5.Text = "Moneda"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtTot_07
        '
        Me.TxtTot_07.BackColor = System.Drawing.Color.White
        Me.TxtTot_07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_07.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_07.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_07.Location = New System.Drawing.Point(805, 490)
        Me.TxtTot_07.Name = "TxtTot_07"
        Me.TxtTot_07.ReadOnly = True
        Me.TxtTot_07.Size = New System.Drawing.Size(100, 21)
        Me.TxtTot_07.TabIndex = 264
        Me.TxtTot_07.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTot_05
        '
        Me.TxtTot_05.BackColor = System.Drawing.Color.White
        Me.TxtTot_05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_05.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_05.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_05.Location = New System.Drawing.Point(650, 490)
        Me.TxtTot_05.Name = "TxtTot_05"
        Me.TxtTot_05.ReadOnly = True
        Me.TxtTot_05.Size = New System.Drawing.Size(97, 21)
        Me.TxtTot_05.TabIndex = 263
        Me.TxtTot_05.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTot_03
        '
        Me.TxtTot_03.BackColor = System.Drawing.Color.White
        Me.TxtTot_03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_03.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_03.Location = New System.Drawing.Point(767, 490)
        Me.TxtTot_03.Name = "TxtTot_03"
        Me.TxtTot_03.ReadOnly = True
        Me.TxtTot_03.Size = New System.Drawing.Size(37, 21)
        Me.TxtTot_03.TabIndex = 262
        Me.TxtTot_03.Text = "Kg."
        Me.TxtTot_03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTitulo_1
        '
        Me.TxtTitulo_1.BackColor = System.Drawing.Color.White
        Me.TxtTitulo_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitulo_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTitulo_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitulo_1.Location = New System.Drawing.Point(97, 490)
        Me.TxtTitulo_1.Name = "TxtTitulo_1"
        Me.TxtTitulo_1.ReadOnly = True
        Me.TxtTitulo_1.Size = New System.Drawing.Size(552, 21)
        Me.TxtTitulo_1.TabIndex = 261
        Me.TxtTitulo_1.Text = "TOTAL GENERAL"
        Me.TxtTitulo_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtConta_1
        '
        Me.TxtConta_1.BackColor = System.Drawing.Color.White
        Me.TxtConta_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConta_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConta_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConta_1.Location = New System.Drawing.Point(1, 490)
        Me.TxtConta_1.Name = "TxtConta_1"
        Me.TxtConta_1.ReadOnly = True
        Me.TxtConta_1.Size = New System.Drawing.Size(95, 21)
        Me.TxtConta_1.TabIndex = 260
        Me.TxtConta_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmRptStockIQ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 549)
        Me.Controls.Add(Me.TxtTot_07)
        Me.Controls.Add(Me.TxtTot_05)
        Me.Controls.Add(Me.TxtTot_03)
        Me.Controls.Add(Me.TxtTitulo_1)
        Me.Controls.Add(Me.TxtConta_1)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Pan01)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRptStockIQ"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock de Almacén - General"
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Pan02.ResumeLayout(False)
        Me.Pan02.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents TxtCod_Scd As System.Windows.Forms.TextBox
    Friend WithEvents TxtScd As System.Windows.Forms.TextBox
    Friend WithEvents TxtCod_Cd As System.Windows.Forms.TextBox
    Friend WithEvents TxtCd As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents TxtCod_Tg As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Pcb01 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtTg As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnConCd As System.Windows.Forms.Button
    Friend WithEvents BtnConTg As System.Windows.Forms.Button
    Friend WithEvents BtnConScd As System.Windows.Forms.Button
    Friend WithEvents TxtCod_Articulo As System.Windows.Forms.TextBox
    Friend WithEvents CboMes As System.Windows.Forms.ComboBox
    Friend WithEvents CboAño As System.Windows.Forms.ComboBox
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents BtnVista As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtnOpen As System.Windows.Forms.Button
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents BtnExcel As System.Windows.Forms.Button
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents Folder01 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents CboAlm As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Prb01 As System.Windows.Forms.ProgressBar
    Friend WithEvents CboMon As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtTot_07 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTot_05 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTot_03 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTitulo_1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtConta_1 As System.Windows.Forms.TextBox
End Class
