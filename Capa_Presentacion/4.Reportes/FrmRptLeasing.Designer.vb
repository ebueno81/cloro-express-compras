<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptLeasing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptLeasing))
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Txtcod_Prove = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DtpFec_Inicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DtpFec_Final = New System.Windows.Forms.DateTimePicker()
        Me.BtnMostrar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.BtnOpen = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnImp = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnExportar = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnExcel = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.TxtRuta = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtnConProve = New System.Windows.Forms.Button()
        Me.TxtProve = New System.Windows.Forms.TextBox()
        Me.TxtReg = New System.Windows.Forms.TextBox()
        Me.Rdb01 = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.BtnFin = New System.Windows.Forms.Button()
        Me.BtnAva = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.BtnAtr = New System.Windows.Forms.Button()
        Me.BtnIni = New System.Windows.Forms.Button()
        Me.Prb01 = New System.Windows.Forms.ProgressBar()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.Rdb02 = New System.Windows.Forms.RadioButton()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.TxtTot_Us = New System.Windows.Forms.TextBox()
        Me.Folder01 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TxtTot_Mn = New System.Windows.Forms.TextBox()
        Me.TxtTitulo_2 = New System.Windows.Forms.TextBox()
        Me.TxtConta_1 = New System.Windows.Forms.TextBox()
        Me.TxtConta_2 = New System.Windows.Forms.TextBox()
        Me.TxtTitulo_1 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Rdb04 = New System.Windows.Forms.RadioButton()
        Me.Rdb03 = New System.Windows.Forms.RadioButton()
        Me.TxtActa_Us = New System.Windows.Forms.TextBox()
        Me.TxtActa_Mn = New System.Windows.Forms.TextBox()
        Me.TxtSaldo_Us = New System.Windows.Forms.TextBox()
        Me.TxtSaldo_Mn = New System.Windows.Forms.TextBox()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.Pan02.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(1, 93)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv01.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowTemplate.Height = 20
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(915, 338)
        Me.Dgv01.TabIndex = 257
        '
        'Txtcod_Prove
        '
        Me.Txtcod_Prove.BackColor = System.Drawing.Color.White
        Me.Txtcod_Prove.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtcod_Prove.Enabled = False
        Me.Txtcod_Prove.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txtcod_Prove.Location = New System.Drawing.Point(71, 2)
        Me.Txtcod_Prove.Multiline = True
        Me.Txtcod_Prove.Name = "Txtcod_Prove"
        Me.Txtcod_Prove.Size = New System.Drawing.Size(54, 22)
        Me.Txtcod_Prove.TabIndex = 206
        Me.Txtcod_Prove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.DtpFec_Inicio)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.DtpFec_Final)
        Me.Panel3.Location = New System.Drawing.Point(88, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(268, 29)
        Me.Panel3.TabIndex = 0
        '
        'DtpFec_Inicio
        '
        Me.DtpFec_Inicio.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DtpFec_Inicio.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DtpFec_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Inicio.Location = New System.Drawing.Point(30, 3)
        Me.DtpFec_Inicio.Name = "DtpFec_Inicio"
        Me.DtpFec_Inicio.Size = New System.Drawing.Size(103, 22)
        Me.DtpFec_Inicio.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(2, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 22)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "Del"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(134, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 22)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "Al"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DtpFec_Final
        '
        Me.DtpFec_Final.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.DtpFec_Final.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DtpFec_Final.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Final.Location = New System.Drawing.Point(159, 3)
        Me.DtpFec_Final.Name = "DtpFec_Final"
        Me.DtpFec_Final.Size = New System.Drawing.Size(103, 22)
        Me.DtpFec_Final.TabIndex = 2
        '
        'BtnMostrar
        '
        Me.BtnMostrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnMostrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnMostrar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMostrar.Image = CType(resources.GetObject("BtnMostrar.Image"), System.Drawing.Image)
        Me.BtnMostrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnMostrar.Location = New System.Drawing.Point(1, 1)
        Me.BtnMostrar.Name = "BtnMostrar"
        Me.BtnMostrar.Size = New System.Drawing.Size(90, 25)
        Me.BtnMostrar.TabIndex = 1
        Me.BtnMostrar.Text = "&Mostrar"
        Me.BtnMostrar.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnMostrar)
        Me.Panel2.Location = New System.Drawing.Point(784, 34)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(94, 29)
        Me.Panel2.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(2, 2)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 23)
        Me.Label5.TabIndex = 204
        Me.Label5.Text = "Proveedor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.BtnCerrar)
        Me.Panel7.Controls.Add(Me.BtnImp)
        Me.Panel7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.Location = New System.Drawing.Point(756, 478)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(159, 29)
        Me.Panel7.TabIndex = 266
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
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(914, 22)
        Me.Label4.TabIndex = 258
        Me.Label4.Text = "Registro de Retenciones"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'Panel5
        '
        Me.Panel5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.BtnExcel)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Controls.Add(Me.BtnExportar)
        Me.Panel5.Location = New System.Drawing.Point(1, 477)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(359, 31)
        Me.Panel5.TabIndex = 267
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
        'TxtRuta
        '
        Me.TxtRuta.BackColor = System.Drawing.Color.White
        Me.TxtRuta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRuta.Location = New System.Drawing.Point(3, 2)
        Me.TxtRuta.Name = "TxtRuta"
        Me.TxtRuta.ReadOnly = True
        Me.TxtRuta.Size = New System.Drawing.Size(249, 21)
        Me.TxtRuta.TabIndex = 4
        Me.TxtRuta.Text = "D:\Registro_Letras.XLS"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtnConProve)
        Me.Panel4.Controls.Add(Me.TxtProve)
        Me.Panel4.Controls.Add(Me.Txtcod_Prove)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Location = New System.Drawing.Point(358, 34)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(421, 29)
        Me.Panel4.TabIndex = 2
        '
        'BtnConProve
        '
        Me.BtnConProve.BackColor = System.Drawing.Color.White
        Me.BtnConProve.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnConProve.Image = CType(resources.GetObject("BtnConProve.Image"), System.Drawing.Image)
        Me.BtnConProve.Location = New System.Drawing.Point(387, 2)
        Me.BtnConProve.Name = "BtnConProve"
        Me.BtnConProve.Size = New System.Drawing.Size(31, 22)
        Me.BtnConProve.TabIndex = 208
        Me.BtnConProve.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnConProve.UseVisualStyleBackColor = False
        '
        'TxtProve
        '
        Me.TxtProve.BackColor = System.Drawing.Color.White
        Me.TxtProve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtProve.Enabled = False
        Me.TxtProve.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TxtProve.Location = New System.Drawing.Point(125, 2)
        Me.TxtProve.Name = "TxtProve"
        Me.TxtProve.ReadOnly = True
        Me.TxtProve.Size = New System.Drawing.Size(261, 22)
        Me.TxtProve.TabIndex = 207
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
        'Rdb01
        '
        Me.Rdb01.AutoSize = True
        Me.Rdb01.Checked = True
        Me.Rdb01.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb01.Location = New System.Drawing.Point(5, 4)
        Me.Rdb01.Name = "Rdb01"
        Me.Rdb01.Size = New System.Drawing.Size(165, 19)
        Me.Rdb01.TabIndex = 0
        Me.Rdb01.TabStop = True
        Me.Rdb01.Text = "Pendientes - Amortizados"
        Me.Rdb01.UseVisualStyleBackColor = True
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
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel10.Controls.Add(Me.TxtReg)
        Me.Panel10.Controls.Add(Me.BtnFin)
        Me.Panel10.Controls.Add(Me.BtnAva)
        Me.Panel10.Controls.Add(Me.BtnAtr)
        Me.Panel10.Controls.Add(Me.BtnIni)
        Me.Panel10.Location = New System.Drawing.Point(449, 478)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(223, 29)
        Me.Panel10.TabIndex = 265
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
        Me.Pan02.Controls.Add(Me.Label12)
        Me.Pan02.Controls.Add(Me.Prb01)
        Me.Pan02.Location = New System.Drawing.Point(271, 219)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(344, 68)
        Me.Pan02.TabIndex = 268
        Me.Pan02.Visible = False
        '
        'Rdb02
        '
        Me.Rdb02.AutoSize = True
        Me.Rdb02.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb02.Location = New System.Drawing.Point(173, 4)
        Me.Rdb02.Name = "Rdb02"
        Me.Rdb02.Size = New System.Drawing.Size(92, 19)
        Me.Rdb02.TabIndex = 1
        Me.Rdb02.Text = "Cancelados"
        Me.Rdb02.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Rdb02)
        Me.Panel6.Controls.Add(Me.Rdb01)
        Me.Panel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.Location = New System.Drawing.Point(88, 35)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(268, 28)
        Me.Panel6.TabIndex = 1
        '
        'TxtTot_Us
        '
        Me.TxtTot_Us.BackColor = System.Drawing.Color.White
        Me.TxtTot_Us.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_Us.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_Us.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_Us.Location = New System.Drawing.Point(692, 454)
        Me.TxtTot_Us.Name = "TxtTot_Us"
        Me.TxtTot_Us.ReadOnly = True
        Me.TxtTot_Us.Size = New System.Drawing.Size(73, 21)
        Me.TxtTot_Us.TabIndex = 264
        Me.TxtTot_Us.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTot_Mn
        '
        Me.TxtTot_Mn.BackColor = System.Drawing.Color.White
        Me.TxtTot_Mn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_Mn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTot_Mn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_Mn.Location = New System.Drawing.Point(692, 434)
        Me.TxtTot_Mn.Name = "TxtTot_Mn"
        Me.TxtTot_Mn.ReadOnly = True
        Me.TxtTot_Mn.Size = New System.Drawing.Size(73, 21)
        Me.TxtTot_Mn.TabIndex = 263
        Me.TxtTot_Mn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTitulo_2
        '
        Me.TxtTitulo_2.BackColor = System.Drawing.Color.White
        Me.TxtTitulo_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitulo_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTitulo_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitulo_2.Location = New System.Drawing.Point(98, 454)
        Me.TxtTitulo_2.Name = "TxtTitulo_2"
        Me.TxtTitulo_2.ReadOnly = True
        Me.TxtTitulo_2.Size = New System.Drawing.Size(595, 21)
        Me.TxtTitulo_2.TabIndex = 262
        Me.TxtTitulo_2.Text = "TOTAL EN DOLARES AMERICANOS ( $. )"
        Me.TxtTitulo_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtConta_1
        '
        Me.TxtConta_1.BackColor = System.Drawing.Color.White
        Me.TxtConta_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConta_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConta_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConta_1.Location = New System.Drawing.Point(2, 434)
        Me.TxtConta_1.Name = "TxtConta_1"
        Me.TxtConta_1.ReadOnly = True
        Me.TxtConta_1.Size = New System.Drawing.Size(95, 21)
        Me.TxtConta_1.TabIndex = 259
        Me.TxtConta_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtConta_2
        '
        Me.TxtConta_2.BackColor = System.Drawing.Color.White
        Me.TxtConta_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtConta_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtConta_2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConta_2.Location = New System.Drawing.Point(2, 454)
        Me.TxtConta_2.Name = "TxtConta_2"
        Me.TxtConta_2.ReadOnly = True
        Me.TxtConta_2.Size = New System.Drawing.Size(95, 21)
        Me.TxtConta_2.TabIndex = 260
        Me.TxtConta_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTitulo_1
        '
        Me.TxtTitulo_1.BackColor = System.Drawing.Color.White
        Me.TxtTitulo_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTitulo_1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTitulo_1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTitulo_1.Location = New System.Drawing.Point(98, 434)
        Me.TxtTitulo_1.Name = "TxtTitulo_1"
        Me.TxtTitulo_1.ReadOnly = True
        Me.TxtTitulo_1.Size = New System.Drawing.Size(595, 21)
        Me.TxtTitulo_1.TabIndex = 261
        Me.TxtTitulo_1.Text = "TOTAL EN NUEVOS SOLES ( S/. )"
        Me.TxtTitulo_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel9)
        Me.Panel1.Controls.Add(Me.Panel6)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(913, 67)
        Me.Panel1.TabIndex = 0
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.White
        Me.Panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel9.Controls.Add(Me.Rdb04)
        Me.Panel9.Controls.Add(Me.Rdb03)
        Me.Panel9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel9.Location = New System.Drawing.Point(358, 4)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(421, 28)
        Me.Panel9.TabIndex = 4
        '
        'Rdb04
        '
        Me.Rdb04.AutoSize = True
        Me.Rdb04.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb04.Location = New System.Drawing.Point(173, 3)
        Me.Rdb04.Name = "Rdb04"
        Me.Rdb04.Size = New System.Drawing.Size(177, 19)
        Me.Rdb04.TabIndex = 1
        Me.Rdb04.Text = "Mostrar Reporte por Cuotas"
        Me.Rdb04.UseVisualStyleBackColor = True
        '
        'Rdb03
        '
        Me.Rdb03.AutoSize = True
        Me.Rdb03.Checked = True
        Me.Rdb03.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rdb03.Location = New System.Drawing.Point(5, 3)
        Me.Rdb03.Name = "Rdb03"
        Me.Rdb03.Size = New System.Drawing.Size(160, 19)
        Me.Rdb03.TabIndex = 0
        Me.Rdb03.TabStop = True
        Me.Rdb03.Text = "Mostrar Reporte General"
        Me.Rdb03.UseVisualStyleBackColor = True
        '
        'TxtActa_Us
        '
        Me.TxtActa_Us.BackColor = System.Drawing.Color.White
        Me.TxtActa_Us.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtActa_Us.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtActa_Us.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtActa_Us.Location = New System.Drawing.Point(764, 454)
        Me.TxtActa_Us.Name = "TxtActa_Us"
        Me.TxtActa_Us.ReadOnly = True
        Me.TxtActa_Us.Size = New System.Drawing.Size(73, 21)
        Me.TxtActa_Us.TabIndex = 270
        Me.TxtActa_Us.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtActa_Mn
        '
        Me.TxtActa_Mn.BackColor = System.Drawing.Color.White
        Me.TxtActa_Mn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtActa_Mn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtActa_Mn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtActa_Mn.Location = New System.Drawing.Point(764, 434)
        Me.TxtActa_Mn.Name = "TxtActa_Mn"
        Me.TxtActa_Mn.ReadOnly = True
        Me.TxtActa_Mn.Size = New System.Drawing.Size(73, 21)
        Me.TxtActa_Mn.TabIndex = 269
        Me.TxtActa_Mn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSaldo_Us
        '
        Me.TxtSaldo_Us.BackColor = System.Drawing.Color.White
        Me.TxtSaldo_Us.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSaldo_Us.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSaldo_Us.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldo_Us.Location = New System.Drawing.Point(836, 454)
        Me.TxtSaldo_Us.Name = "TxtSaldo_Us"
        Me.TxtSaldo_Us.ReadOnly = True
        Me.TxtSaldo_Us.Size = New System.Drawing.Size(72, 21)
        Me.TxtSaldo_Us.TabIndex = 272
        Me.TxtSaldo_Us.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtSaldo_Mn
        '
        Me.TxtSaldo_Mn.BackColor = System.Drawing.Color.White
        Me.TxtSaldo_Mn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSaldo_Mn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSaldo_Mn.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaldo_Mn.Location = New System.Drawing.Point(836, 434)
        Me.TxtSaldo_Mn.Name = "TxtSaldo_Mn"
        Me.TxtSaldo_Mn.ReadOnly = True
        Me.TxtSaldo_Mn.Size = New System.Drawing.Size(72, 21)
        Me.TxtSaldo_Mn.TabIndex = 271
        Me.TxtSaldo_Mn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FrmRptLeasing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 509)
        Me.Controls.Add(Me.TxtSaldo_Us)
        Me.Controls.Add(Me.TxtSaldo_Mn)
        Me.Controls.Add(Me.TxtActa_Us)
        Me.Controls.Add(Me.TxtActa_Mn)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.TxtTot_Us)
        Me.Controls.Add(Me.TxtTot_Mn)
        Me.Controls.Add(Me.TxtTitulo_2)
        Me.Controls.Add(Me.TxtConta_1)
        Me.Controls.Add(Me.TxtConta_2)
        Me.Controls.Add(Me.TxtTitulo_1)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRptLeasing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Otros Financiamientos"
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.Pan02.ResumeLayout(False)
        Me.Pan02.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Txtcod_Prove As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DtpFec_Inicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DtpFec_Final As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnMostrar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BtnOpen As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents BtnImp As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BtnExportar As System.Windows.Forms.Button
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents BtnExcel As System.Windows.Forms.Button
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents TxtRuta As System.Windows.Forms.TextBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TxtReg As System.Windows.Forms.TextBox
    Friend WithEvents Rdb01 As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BtnFin As System.Windows.Forms.Button
    Friend WithEvents BtnAva As System.Windows.Forms.Button
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents BtnAtr As System.Windows.Forms.Button
    Friend WithEvents BtnIni As System.Windows.Forms.Button
    Friend WithEvents Prb01 As System.Windows.Forms.ProgressBar
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents Rdb02 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents TxtTot_Us As System.Windows.Forms.TextBox
    Friend WithEvents Folder01 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents TxtTot_Mn As System.Windows.Forms.TextBox
    Friend WithEvents TxtTitulo_2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtConta_1 As System.Windows.Forms.TextBox
    Friend WithEvents TxtConta_2 As System.Windows.Forms.TextBox
    Friend WithEvents TxtTitulo_1 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtActa_Us As System.Windows.Forms.TextBox
    Friend WithEvents TxtActa_Mn As System.Windows.Forms.TextBox
    Friend WithEvents TxtSaldo_Us As System.Windows.Forms.TextBox
    Friend WithEvents TxtSaldo_Mn As System.Windows.Forms.TextBox
    Friend WithEvents BtnConProve As System.Windows.Forms.Button
    Friend WithEvents TxtProve As System.Windows.Forms.TextBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Rdb04 As System.Windows.Forms.RadioButton
    Friend WithEvents Rdb03 As System.Windows.Forms.RadioButton
End Class
