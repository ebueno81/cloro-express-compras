<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptIngAlm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptIngAlm))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Txtcod_Articulo = New System.Windows.Forms.TextBox()
        Me.BtnConTg = New System.Windows.Forms.Button()
        Me.BtnConCd = New System.Windows.Forms.Button()
        Me.BtnConScd = New System.Windows.Forms.Button()
        Me.TxtScd = New System.Windows.Forms.TextBox()
        Me.TxtCd = New System.Windows.Forms.TextBox()
        Me.TxtTg = New System.Windows.Forms.TextBox()
        Me.TxtCod_Scd = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtCod_Cd = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtCod_Tg = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtCod_Prove = New System.Windows.Forms.TextBox()
        Me.CboProve = New System.Windows.Forms.ComboBox()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCod_Mt = New System.Windows.Forms.TextBox()
        Me.CboMt = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DtpFec_Final = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpFec_Inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CboMon = New System.Windows.Forms.ComboBox()
        Me.TxtSerie_Doc = New System.Windows.Forms.TextBox()
        Me.TxtGuia = New System.Windows.Forms.TextBox()
        Me.TxtSerie_Guia = New System.Windows.Forms.TextBox()
        Me.TxtCod_Ing = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtFactura = New System.Windows.Forms.TextBox()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnExcel = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.TxtRuta = New System.Windows.Forms.TextBox()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnImp = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.TxtReg = New System.Windows.Forms.TextBox()
        Me.BtnFin = New System.Windows.Forms.Button()
        Me.BtnAva = New System.Windows.Forms.Button()
        Me.BtnAtr = New System.Windows.Forms.Button()
        Me.BtnIni = New System.Windows.Forms.Button()
        Me.TxtTot_08 = New System.Windows.Forms.TextBox()
        Me.TxtTot_07 = New System.Windows.Forms.TextBox()
        Me.TxtTot_06 = New System.Windows.Forms.TextBox()
        Me.TxtTot_05 = New System.Windows.Forms.TextBox()
        Me.TxtTot_04 = New System.Windows.Forms.TextBox()
        Me.TxtTot_03 = New System.Windows.Forms.TextBox()
        Me.TxtTitulo_2 = New System.Windows.Forms.TextBox()
        Me.TxtTitulo_1 = New System.Windows.Forms.TextBox()
        Me.TxtConta_2 = New System.Windows.Forms.TextBox()
        Me.TxtConta_1 = New System.Windows.Forms.TextBox()
        Me.Folder01 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Prb01 = New System.Windows.Forms.ProgressBar()
        Me.ChkArtEspecial = New System.Windows.Forms.CheckBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CboAlm = New System.Windows.Forms.ComboBox()
        Me.Panel1.SuspendLayout()
        Me.Pan01.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Pan02.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Txtcod_Articulo)
        Me.Panel1.Controls.Add(Me.BtnConTg)
        Me.Panel1.Controls.Add(Me.BtnConCd)
        Me.Panel1.Controls.Add(Me.BtnConScd)
        Me.Panel1.Controls.Add(Me.TxtScd)
        Me.Panel1.Controls.Add(Me.TxtCd)
        Me.Panel1.Controls.Add(Me.TxtTg)
        Me.Panel1.Controls.Add(Me.TxtCod_Scd)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TxtCod_Cd)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TxtCod_Tg)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TxtCod_Prove)
        Me.Panel1.Controls.Add(Me.CboProve)
        Me.Panel1.Controls.Add(Me.BtnMostrar)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TxtCod_Mt)
        Me.Panel1.Controls.Add(Me.CboMt)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.DtpFec_Final)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DtpFec_Inicio)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(703, 76)
        Me.Panel1.TabIndex = 0
        '
        'Txtcod_Articulo
        '
        Me.Txtcod_Articulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtcod_Articulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Txtcod_Articulo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcod_Articulo.Location = New System.Drawing.Point(608, 49)
        Me.Txtcod_Articulo.Name = "Txtcod_Articulo"
        Me.Txtcod_Articulo.Size = New System.Drawing.Size(64, 21)
        Me.Txtcod_Articulo.TabIndex = 207
        Me.Txtcod_Articulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Txtcod_Articulo.Visible = False
        '
        'BtnConTg
        '
        Me.BtnConTg.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnConTg.Image = CType(resources.GetObject("BtnConTg.Image"), System.Drawing.Image)
        Me.BtnConTg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConTg.Location = New System.Drawing.Point(672, 3)
        Me.BtnConTg.Name = "BtnConTg"
        Me.BtnConTg.Size = New System.Drawing.Size(25, 21)
        Me.BtnConTg.TabIndex = 8
        Me.BtnConTg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConTg.UseVisualStyleBackColor = True
        '
        'BtnConCd
        '
        Me.BtnConCd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnConCd.Image = CType(resources.GetObject("BtnConCd.Image"), System.Drawing.Image)
        Me.BtnConCd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConCd.Location = New System.Drawing.Point(672, 26)
        Me.BtnConCd.Name = "BtnConCd"
        Me.BtnConCd.Size = New System.Drawing.Size(25, 21)
        Me.BtnConCd.TabIndex = 11
        Me.BtnConCd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConCd.UseVisualStyleBackColor = True
        '
        'BtnConScd
        '
        Me.BtnConScd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnConScd.Image = CType(resources.GetObject("BtnConScd.Image"), System.Drawing.Image)
        Me.BtnConScd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConScd.Location = New System.Drawing.Point(672, 49)
        Me.BtnConScd.Name = "BtnConScd"
        Me.BtnConScd.Size = New System.Drawing.Size(25, 21)
        Me.BtnConScd.TabIndex = 14
        Me.BtnConScd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConScd.UseVisualStyleBackColor = True
        '
        'TxtScd
        '
        Me.TxtScd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtScd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtScd.Enabled = False
        Me.TxtScd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtScd.Location = New System.Drawing.Point(474, 49)
        Me.TxtScd.Name = "TxtScd"
        Me.TxtScd.Size = New System.Drawing.Size(198, 21)
        Me.TxtScd.TabIndex = 13
        Me.TxtScd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCd
        '
        Me.TxtCd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCd.Enabled = False
        Me.TxtCd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCd.Location = New System.Drawing.Point(474, 26)
        Me.TxtCd.Name = "TxtCd"
        Me.TxtCd.Size = New System.Drawing.Size(198, 21)
        Me.TxtCd.TabIndex = 10
        Me.TxtCd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTg
        '
        Me.TxtTg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTg.Enabled = False
        Me.TxtTg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTg.Location = New System.Drawing.Point(474, 3)
        Me.TxtTg.Name = "TxtTg"
        Me.TxtTg.Size = New System.Drawing.Size(198, 21)
        Me.TxtTg.TabIndex = 7
        Me.TxtTg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCod_Scd
        '
        Me.TxtCod_Scd.BackColor = System.Drawing.Color.White
        Me.TxtCod_Scd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Scd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCod_Scd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Scd.Location = New System.Drawing.Point(431, 49)
        Me.TxtCod_Scd.MaxLength = 4
        Me.TxtCod_Scd.Name = "TxtCod_Scd"
        Me.TxtCod_Scd.Size = New System.Drawing.Size(43, 21)
        Me.TxtCod_Scd.TabIndex = 12
        Me.TxtCod_Scd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(357, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 23)
        Me.Label7.TabIndex = 206
        Me.Label7.Text = "Sub-Caídas"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCod_Cd
        '
        Me.TxtCod_Cd.BackColor = System.Drawing.Color.White
        Me.TxtCod_Cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Cd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCod_Cd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Cd.Location = New System.Drawing.Point(431, 26)
        Me.TxtCod_Cd.MaxLength = 2
        Me.TxtCod_Cd.Name = "TxtCod_Cd"
        Me.TxtCod_Cd.Size = New System.Drawing.Size(43, 21)
        Me.TxtCod_Cd.TabIndex = 9
        Me.TxtCod_Cd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.SteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(357, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 22)
        Me.Label5.TabIndex = 203
        Me.Label5.Text = "Motivo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCod_Tg
        '
        Me.TxtCod_Tg.BackColor = System.Drawing.Color.White
        Me.TxtCod_Tg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Tg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCod_Tg.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Tg.Location = New System.Drawing.Point(431, 3)
        Me.TxtCod_Tg.MaxLength = 2
        Me.TxtCod_Tg.Name = "TxtCod_Tg"
        Me.TxtCod_Tg.Size = New System.Drawing.Size(43, 21)
        Me.TxtCod_Tg.TabIndex = 6
        Me.TxtCod_Tg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.SteelBlue
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(357, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 23)
        Me.Label6.TabIndex = 202
        Me.Label6.Text = "Caídas"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCod_Prove
        '
        Me.TxtCod_Prove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Prove.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCod_Prove.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Prove.Location = New System.Drawing.Point(78, 48)
        Me.TxtCod_Prove.Name = "TxtCod_Prove"
        Me.TxtCod_Prove.Size = New System.Drawing.Size(43, 21)
        Me.TxtCod_Prove.TabIndex = 4
        Me.TxtCod_Prove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CboProve
        '
        Me.CboProve.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboProve.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboProve.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboProve.FormattingEnabled = True
        Me.CboProve.Location = New System.Drawing.Point(122, 48)
        Me.CboProve.Name = "CboProve"
        Me.CboProve.Size = New System.Drawing.Size(233, 22)
        Me.CboProve.TabIndex = 5
        '
        'BtnMostrar
        '
        Me.BtnMostrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnMostrar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMostrar.Image = CType(resources.GetObject("BtnMostrar.Image"), System.Drawing.Image)
        Me.BtnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMostrar.Location = New System.Drawing.Point(280, 2)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(75, 22)
        Me.BtnMostrar.TabIndex = 15
        Me.BtnMostrar.Text = "&Mostrar"
        Me.BtnMostrar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(7, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 22)
        Me.Label4.TabIndex = 197
        Me.Label4.Text = "Motivo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCod_Mt
        '
        Me.TxtCod_Mt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Mt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCod_Mt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Mt.Location = New System.Drawing.Point(78, 26)
        Me.TxtCod_Mt.Name = "TxtCod_Mt"
        Me.TxtCod_Mt.Size = New System.Drawing.Size(43, 21)
        Me.TxtCod_Mt.TabIndex = 2
        Me.TxtCod_Mt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CboMt
        '
        Me.CboMt.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboMt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboMt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMt.FormattingEnabled = True
        Me.CboMt.Location = New System.Drawing.Point(122, 26)
        Me.CboMt.Name = "CboMt"
        Me.CboMt.Size = New System.Drawing.Size(233, 22)
        Me.CboMt.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.SteelBlue
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(7, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 23)
        Me.Label3.TabIndex = 195
        Me.Label3.Text = "Proveedor"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFec_Final
        '
        Me.DtpFec_Final.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DtpFec_Final.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DtpFec_Final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Final.Location = New System.Drawing.Point(171, 3)
        Me.DtpFec_Final.Name = "DtpFec_Final"
        Me.DtpFec_Final.Size = New System.Drawing.Size(103, 22)
        Me.DtpFec_Final.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Navy
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(144, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 22)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "Al"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFec_Inicio
        '
        Me.DtpFec_Inicio.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DtpFec_Inicio.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DtpFec_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Inicio.Location = New System.Drawing.Point(40, 3)
        Me.DtpFec_Inicio.Name = "DtpFec_Inicio"
        Me.DtpFec_Inicio.Size = New System.Drawing.Size(103, 22)
        Me.DtpFec_Inicio.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.SteelBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(7, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 22)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "Del"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pan01
        '
        Me.Pan01.BackColor = System.Drawing.Color.White
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pan01.Controls.Add(Me.Panel2)
        Me.Pan01.Controls.Add(Me.Panel1)
        Me.Pan01.Location = New System.Drawing.Point(1, 2)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(1008, 85)
        Me.Pan01.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.CboAlm)
        Me.Panel2.Controls.Add(Me.Label14)
        Me.Panel2.Controls.Add(Me.CboMon)
        Me.Panel2.Controls.Add(Me.TxtSerie_Doc)
        Me.Panel2.Controls.Add(Me.TxtGuia)
        Me.Panel2.Controls.Add(Me.TxtSerie_Guia)
        Me.Panel2.Controls.Add(Me.TxtCod_Ing)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.TxtFactura)
        Me.Panel2.Location = New System.Drawing.Point(709, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(292, 76)
        Me.Panel2.TabIndex = 1
        '
        'CboMon
        '
        Me.CboMon.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMon.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboMon.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMon.FormattingEnabled = True
        Me.CboMon.Location = New System.Drawing.Point(59, 1)
        Me.CboMon.Name = "CboMon"
        Me.CboMon.Size = New System.Drawing.Size(42, 22)
        Me.CboMon.TabIndex = 210
        '
        'TxtSerie_Doc
        '
        Me.TxtSerie_Doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSerie_Doc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerie_Doc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerie_Doc.Location = New System.Drawing.Point(59, 48)
        Me.TxtSerie_Doc.MaxLength = 4
        Me.TxtSerie_Doc.Name = "TxtSerie_Doc"
        Me.TxtSerie_Doc.Size = New System.Drawing.Size(44, 21)
        Me.TxtSerie_Doc.TabIndex = 19
        Me.TxtSerie_Doc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtGuia
        '
        Me.TxtGuia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtGuia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtGuia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGuia.Location = New System.Drawing.Point(103, 25)
        Me.TxtGuia.MaxLength = 8
        Me.TxtGuia.Name = "TxtGuia"
        Me.TxtGuia.Size = New System.Drawing.Size(83, 21)
        Me.TxtGuia.TabIndex = 18
        Me.TxtGuia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSerie_Guia
        '
        Me.TxtSerie_Guia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSerie_Guia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerie_Guia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerie_Guia.Location = New System.Drawing.Point(59, 25)
        Me.TxtSerie_Guia.MaxLength = 4
        Me.TxtSerie_Guia.Name = "TxtSerie_Guia"
        Me.TxtSerie_Guia.Size = New System.Drawing.Size(44, 21)
        Me.TxtSerie_Guia.TabIndex = 17
        Me.TxtSerie_Guia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCod_Ing
        '
        Me.TxtCod_Ing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Ing.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCod_Ing.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCod_Ing.Location = New System.Drawing.Point(145, 48)
        Me.TxtCod_Ing.Name = "TxtCod_Ing"
        Me.TxtCod_Ing.Size = New System.Drawing.Size(26, 21)
        Me.TxtCod_Ing.TabIndex = 16
        Me.TxtCod_Ing.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtCod_Ing.Visible = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(1, 47)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 23)
        Me.Label8.TabIndex = 209
        Me.Label8.Text = "Factura"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(1, 2)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(58, 22)
        Me.Label9.TabIndex = 208
        Me.Label9.Text = "Moneda"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.SteelBlue
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(1, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 23)
        Me.Label10.TabIndex = 207
        Me.Label10.Text = "Guia"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtFactura
        '
        Me.TxtFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtFactura.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtFactura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFactura.Location = New System.Drawing.Point(103, 48)
        Me.TxtFactura.MaxLength = 8
        Me.TxtFactura.Name = "TxtFactura"
        Me.TxtFactura.Size = New System.Drawing.Size(83, 21)
        Me.TxtFactura.TabIndex = 20
        Me.TxtFactura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(1, 109)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv01.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowTemplate.Height = 20
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(1008, 353)
        Me.Dgv01.TabIndex = 5
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(1, 86)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(1008, 23)
        Me.Label11.TabIndex = 198
        Me.Label11.Text = "Ingresos"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.BtnExcel)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.BtnExportar)
        Me.Panel5.Location = New System.Drawing.Point(37, 506)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(359, 31)
        Me.Panel5.TabIndex = 241
        '
        'BtnExcel
        '
        Me.BtnExcel.BackColor = System.Drawing.Color.White
        Me.BtnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExcel.Image = CType(resources.GetObject("BtnExcel.Image"), System.Drawing.Image)
        Me.BtnExcel.Location = New System.Drawing.Point(321, 1)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(34, 27)
        Me.BtnExcel.TabIndex = 5
        Me.BtnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExcel.UseVisualStyleBackColor = False
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.White
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.BtnOpen)
        Me.Panel8.Controls.Add(Me.TxtRuta)
        Me.Panel8.Location = New System.Drawing.Point(1, 1)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(286, 27)
        Me.Panel8.TabIndex = 4
        '
        'BtnOpen
        '
        Me.BtnOpen.BackColor = System.Drawing.Color.White
        Me.BtnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOpen.Image = CType(resources.GetObject("BtnOpen.Image"), System.Drawing.Image)
        Me.BtnOpen.Location = New System.Drawing.Point(252, 2)
        Me.BtnOpen.Name = "BtnOpen"
        Me.BtnOpen.Size = New System.Drawing.Size(31, 22)
        Me.BtnOpen.TabIndex = 5
        Me.BtnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnOpen.UseVisualStyleBackColor = False
        '
        'TxtRuta
        '
        Me.TxtRuta.BackColor = System.Drawing.Color.White
        Me.TxtRuta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRuta.Location = New System.Drawing.Point(3, 2)
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.ReadOnly = True
        Me.TxtRuta.Size = New System.Drawing.Size(249, 22)
        Me.TxtRuta.TabIndex = 4
        Me.TxtRuta.Text = "D:\MovIngresos_Almacen.XLS"
        '
        'BtnExportar
        '
        Me.BtnExportar.BackColor = System.Drawing.Color.White
        Me.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExportar.Image = CType(resources.GetObject("BtnExportar.Image"), System.Drawing.Image)
        Me.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.Location = New System.Drawing.Point(288, 1)
        Me.BtnExportar.Name = "BtnExportar"
        Me.BtnExportar.Size = New System.Drawing.Size(68, 27)
        Me.BtnExportar.TabIndex = 6
        Me.BtnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnExportar.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.BtnCerrar)
        Me.Panel7.Controls.Add(Me.BtnImp)
        Me.Panel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.Location = New System.Drawing.Point(814, 507)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(159, 29)
        Me.Panel7.TabIndex = 240
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(81, 2)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(74, 22)
        Me.BtnCerrar.TabIndex = 2
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'BtnImp
        '
        Me.BtnImp.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnImp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnImp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImp.Image = CType(resources.GetObject("BtnImp.Image"), System.Drawing.Image)
        Me.BtnImp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImp.Location = New System.Drawing.Point(2, 2)
        Me.BtnImp.Name = "BtnImp"
        Me.BtnImp.Size = New System.Drawing.Size(77, 22)
        Me.BtnImp.TabIndex = 2
        Me.BtnImp.Text = "&Imprimir"
        Me.BtnImp.UseVisualStyleBackColor = False
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.TxtReg)
        Me.Panel10.Controls.Add(Me.BtnFin)
        Me.Panel10.Controls.Add(Me.BtnAva)
        Me.Panel10.Controls.Add(Me.BtnAtr)
        Me.Panel10.Controls.Add(Me.BtnIni)
        Me.Panel10.Location = New System.Drawing.Point(463, 507)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(223, 29)
        Me.Panel10.TabIndex = 239
        '
        'TxtReg
        '
        Me.TxtReg.BackColor = System.Drawing.Color.White
        Me.TxtReg.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReg.Location = New System.Drawing.Point(57, 2)
        Me.TxtReg.Name = "TxtReg"
        Me.TxtReg.ReadOnly = True
        Me.TxtReg.Size = New System.Drawing.Size(105, 23)
        Me.TxtReg.TabIndex = 176
        Me.TxtReg.Text = "1/100"
        Me.TxtReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnFin
        '
        Me.BtnFin.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnFin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFin.Image = CType(resources.GetObject("BtnFin.Image"), System.Drawing.Image)
        Me.BtnFin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFin.Location = New System.Drawing.Point(188, 2)
        Me.BtnFin.Name = "BtnFin"
        Me.BtnFin.Size = New System.Drawing.Size(25, 23)
        Me.BtnFin.TabIndex = 175
        Me.BtnFin.UseVisualStyleBackColor = False
        '
        'BtnAva
        '
        Me.BtnAva.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAva.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAva.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAva.Image = CType(resources.GetObject("BtnAva.Image"), System.Drawing.Image)
        Me.BtnAva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAva.Location = New System.Drawing.Point(163, 2)
        Me.BtnAva.Name = "BtnAva"
        Me.BtnAva.Size = New System.Drawing.Size(25, 23)
        Me.BtnAva.TabIndex = 174
        Me.BtnAva.UseVisualStyleBackColor = False
        '
        'BtnAtr
        '
        Me.BtnAtr.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAtr.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAtr.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAtr.Image = CType(resources.GetObject("BtnAtr.Image"), System.Drawing.Image)
        Me.BtnAtr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAtr.Location = New System.Drawing.Point(32, 2)
        Me.BtnAtr.Name = "BtnAtr"
        Me.BtnAtr.Size = New System.Drawing.Size(25, 23)
        Me.BtnAtr.TabIndex = 173
        Me.BtnAtr.UseVisualStyleBackColor = False
        '
        'BtnIni
        '
        Me.BtnIni.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnIni.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnIni.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnIni.Image = CType(resources.GetObject("BtnIni.Image"), System.Drawing.Image)
        Me.BtnIni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnIni.Location = New System.Drawing.Point(7, 2)
        Me.BtnIni.Name = "BtnIni"
        Me.BtnIni.Size = New System.Drawing.Size(25, 23)
        Me.BtnIni.TabIndex = 172
        Me.BtnIni.UseVisualStyleBackColor = False
        '
        'TxtTot_08
        '
        Me.TxtTot_08.BackColor = System.Drawing.Color.White
        Me.TxtTot_08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_08.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_08.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_08.Location = New System.Drawing.Point(866, 483)
        Me.TxtTot_08.Name = "TxtTot_08"
        Me.TxtTot_08.ReadOnly = True
        Me.TxtTot_08.Size = New System.Drawing.Size(107, 21)
        Me.TxtTot_08.TabIndex = 238
        Me.TxtTot_08.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTot_07
        '
        Me.TxtTot_07.BackColor = System.Drawing.Color.White
        Me.TxtTot_07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_07.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_07.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_07.Location = New System.Drawing.Point(866, 463)
        Me.TxtTot_07.Name = "TxtTot_07"
        Me.TxtTot_07.ReadOnly = True
        Me.TxtTot_07.Size = New System.Drawing.Size(107, 21)
        Me.TxtTot_07.TabIndex = 237
        Me.TxtTot_07.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTot_06
        '
        Me.TxtTot_06.BackColor = System.Drawing.Color.White
        Me.TxtTot_06.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_06.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_06.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_06.Location = New System.Drawing.Point(768, 483)
        Me.TxtTot_06.Name = "TxtTot_06"
        Me.TxtTot_06.ReadOnly = True
        Me.TxtTot_06.Size = New System.Drawing.Size(97, 21)
        Me.TxtTot_06.TabIndex = 236
        Me.TxtTot_06.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTot_05
        '
        Me.TxtTot_05.BackColor = System.Drawing.Color.White
        Me.TxtTot_05.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_05.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_05.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_05.Location = New System.Drawing.Point(768, 463)
        Me.TxtTot_05.Name = "TxtTot_05"
        Me.TxtTot_05.ReadOnly = True
        Me.TxtTot_05.Size = New System.Drawing.Size(97, 21)
        Me.TxtTot_05.TabIndex = 235
        Me.TxtTot_05.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTot_04
        '
        Me.TxtTot_04.BackColor = System.Drawing.Color.White
        Me.TxtTot_04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_04.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_04.Location = New System.Drawing.Point(727, 483)
        Me.TxtTot_04.Name = "TxtTot_04"
        Me.TxtTot_04.ReadOnly = True
        Me.TxtTot_04.Size = New System.Drawing.Size(37, 21)
        Me.TxtTot_04.TabIndex = 234
        Me.TxtTot_04.Text = "Kg."
        Me.TxtTot_04.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTot_03
        '
        Me.TxtTot_03.BackColor = System.Drawing.Color.White
        Me.TxtTot_03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_03.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_03.Location = New System.Drawing.Point(727, 463)
        Me.TxtTot_03.Name = "TxtTot_03"
        Me.TxtTot_03.ReadOnly = True
        Me.TxtTot_03.Size = New System.Drawing.Size(37, 21)
        Me.TxtTot_03.TabIndex = 233
        Me.TxtTot_03.Text = "Kg."
        Me.TxtTot_03.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTitulo_2
        '
        Me.TxtTitulo_2.BackColor = System.Drawing.Color.White
        Me.TxtTitulo_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitulo_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTitulo_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitulo_2.Location = New System.Drawing.Point(97, 483)
        Me.TxtTitulo_2.Name = "TxtTitulo_2"
        Me.TxtTitulo_2.ReadOnly = True
        Me.TxtTitulo_2.Size = New System.Drawing.Size(626, 21)
        Me.TxtTitulo_2.TabIndex = 230
        Me.TxtTitulo_2.Text = "TOTAL EN DOLARES AMERICANOS ( $. )"
        Me.TxtTitulo_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTitulo_1
        '
        Me.TxtTitulo_1.BackColor = System.Drawing.Color.White
        Me.TxtTitulo_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitulo_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTitulo_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitulo_1.Location = New System.Drawing.Point(97, 463)
        Me.TxtTitulo_1.Name = "TxtTitulo_1"
        Me.TxtTitulo_1.ReadOnly = True
        Me.TxtTitulo_1.Size = New System.Drawing.Size(626, 21)
        Me.TxtTitulo_1.TabIndex = 229
        Me.TxtTitulo_1.Text = "TOTAL EN NUEVOS SOLES ( S/. )"
        Me.TxtTitulo_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtConta_2
        '
        Me.TxtConta_2.BackColor = System.Drawing.Color.White
        Me.TxtConta_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConta_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConta_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConta_2.Location = New System.Drawing.Point(1, 483)
        Me.TxtConta_2.Name = "TxtConta_2"
        Me.TxtConta_2.ReadOnly = True
        Me.TxtConta_2.Size = New System.Drawing.Size(95, 21)
        Me.TxtConta_2.TabIndex = 228
        Me.TxtConta_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtConta_1
        '
        Me.TxtConta_1.BackColor = System.Drawing.Color.White
        Me.TxtConta_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConta_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConta_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConta_1.Location = New System.Drawing.Point(1, 463)
        Me.TxtConta_1.Name = "TxtConta_1"
        Me.TxtConta_1.ReadOnly = True
        Me.TxtConta_1.Size = New System.Drawing.Size(95, 21)
        Me.TxtConta_1.TabIndex = 227
        Me.TxtConta_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Pan02
        '
        Me.Pan02.BackColor = System.Drawing.Color.White
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.Label13)
        Me.Pan02.Controls.Add(Me.Label12)
        Me.Pan02.Controls.Add(Me.Prb01)
        Me.Pan02.Location = New System.Drawing.Point(315, 234)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(344, 68)
        Me.Pan02.TabIndex = 242
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
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.ForeColor = System.Drawing.Color.Navy
        Me.Label12.Location = New System.Drawing.Point(6, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(325, 13)
        Me.Label12.TabIndex = 210
        Me.Label12.Text = "Espere unos Instantes mientras el Sistema Procesa la Información..."
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
        'ChkArtEspecial
        '
        Me.ChkArtEspecial.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ChkArtEspecial.Checked = True
        Me.ChkArtEspecial.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkArtEspecial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkArtEspecial.Location = New System.Drawing.Point(4, 88)
        Me.ChkArtEspecial.Name = "ChkArtEspecial"
        Me.ChkArtEspecial.Size = New System.Drawing.Size(353, 19)
        Me.ChkArtEspecial.TabIndex = 243
        Me.ChkArtEspecial.Text = "No Incluir Articulos Trans. Especiales(HipoClorito al 10%)"
        Me.ChkArtEspecial.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.SteelBlue
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(103, 1)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 22)
        Me.Label14.TabIndex = 211
        Me.Label14.Text = "Almacen"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CboAlm
        '
        Me.CboAlm.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboAlm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAlm.FormattingEnabled = True
        Me.CboAlm.Location = New System.Drawing.Point(163, 1)
        Me.CboAlm.Name = "CboAlm"
        Me.CboAlm.Size = New System.Drawing.Size(126, 21)
        Me.CboAlm.TabIndex = 212
        '
        'FrmRptIngAlm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1011, 537)
        Me.Controls.Add(Me.ChkArtEspecial)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.TxtTot_08)
        Me.Controls.Add(Me.TxtTot_07)
        Me.Controls.Add(Me.TxtTot_06)
        Me.Controls.Add(Me.TxtTot_05)
        Me.Controls.Add(Me.TxtTot_04)
        Me.Controls.Add(Me.TxtTot_03)
        Me.Controls.Add(Me.TxtTitulo_2)
        Me.Controls.Add(Me.TxtTitulo_1)
        Me.Controls.Add(Me.TxtConta_2)
        Me.Controls.Add(Me.TxtConta_1)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Pan01)
        Me.Controls.Add(Me.Dgv01)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRptIngAlm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Ingresos - [Almacén General]"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Pan01.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Pan02.ResumeLayout(False)
        Me.Pan02.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtScd As System.Windows.Forms.TextBox
    Friend WithEvents TxtCd As System.Windows.Forms.TextBox
    Friend WithEvents TxtTg As System.Windows.Forms.TextBox
    Friend WithEvents TxtCod_Scd As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtCod_Cd As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCod_Tg As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtCod_Prove As System.Windows.Forms.TextBox
    Friend WithEvents CboProve As System.Windows.Forms.ComboBox
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCod_Mt As System.Windows.Forms.TextBox
    Friend WithEvents CboMt As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DtpFec_Final As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpFec_Inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnConTg As System.Windows.Forms.Button
    Friend WithEvents BtnConCd As System.Windows.Forms.Button
    Friend WithEvents BtnConScd As System.Windows.Forms.Button
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TxtFactura As System.Windows.Forms.TextBox
    Friend WithEvents TxtSerie_Doc As System.Windows.Forms.TextBox
    Friend WithEvents TxtGuia As System.Windows.Forms.TextBox
    Friend WithEvents TxtSerie_Guia As System.Windows.Forms.TextBox
    Friend WithEvents TxtCod_Ing As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents BtnExcel As System.Windows.Forms.Button
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents BtnOpen As System.Windows.Forms.Button
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents BtnImp As System.Windows.Forms.Button
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents TxtReg As System.Windows.Forms.TextBox
    Friend WithEvents BtnFin As System.Windows.Forms.Button
    Friend WithEvents BtnAva As System.Windows.Forms.Button
    Friend WithEvents BtnAtr As System.Windows.Forms.Button
    Friend WithEvents BtnIni As System.Windows.Forms.Button
    Friend WithEvents TxtTot_08 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTot_07 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTot_06 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTot_05 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTot_04 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTot_03 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTitulo_2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTitulo_1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtConta_2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtConta_1 As System.Windows.Forms.TextBox
    Friend WithEvents Folder01 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Prb01 As System.Windows.Forms.ProgressBar
    Friend WithEvents Txtcod_Articulo As System.Windows.Forms.TextBox
    Friend WithEvents CboMon As ComboBox
    Friend WithEvents ChkArtEspecial As CheckBox
    Friend WithEvents CboAlm As ComboBox
    Friend WithEvents Label14 As Label
End Class
