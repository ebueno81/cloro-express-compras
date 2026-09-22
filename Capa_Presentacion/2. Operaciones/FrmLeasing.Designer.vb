<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLeasing
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLeasing))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.BtnEstado = New System.Windows.Forms.Label()
        Me.LnkHistorial = New System.Windows.Forms.LinkLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtBuscar = New System.Windows.Forms.TextBox()
        Me.BtnFin = New System.Windows.Forms.Button()
        Me.BtnAva = New System.Windows.Forms.Button()
        Me.BtnAtr = New System.Windows.Forms.Button()
        Me.BtnIni = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.BtnCon1 = New System.Windows.Forms.Button()
        Me.TxtCodProve = New System.Windows.Forms.TextBox()
        Me.TxtProve = New System.Windows.Forms.TextBox()
        Me.TxtSerie_Credito = New System.Windows.Forms.TextBox()
        Me.CboTpoDoc = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Pan08 = New System.Windows.Forms.Panel()
        Me.TxtFecha_Crea = New System.Windows.Forms.TextBox()
        Me.TxtFecha_Modi = New System.Windows.Forms.TextBox()
        Me.TxtUsua_Modi = New System.Windows.Forms.TextBox()
        Me.TxtUsua_Crea = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.DtpFec_Emi = New System.Windows.Forms.DateTimePicker()
        Me.TxtNr_Cuotas = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TxtObs = New System.Windows.Forms.TextBox()
        Me.TxtNro_Credito = New System.Windows.Forms.TextBox()
        Me.TxtTotal = New System.Windows.Forms.TextBox()
        Me.TxtNro_Mov = New System.Windows.Forms.TextBox()
        Me.CboMon = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Nro = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Vcto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Capital = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Principal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Interes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Igv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotPagar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Estado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Serie = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Doc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Anula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_opc_cancel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_opc_doc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pan03 = New System.Windows.Forms.Panel()
        Me.BtnBuscar = New System.Windows.Forms.Button()
        Me.BtnImp = New System.Windows.Forms.Button()
        Me.BtnEditar = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.Pan09 = New System.Windows.Forms.Panel()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.BtnDel = New System.Windows.Forms.Button()
        Me.Dgv02 = New System.Windows.Forms.DataGridView()
        Me.Titulo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SubTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.espacio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pan10 = New System.Windows.Forms.Panel()
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Pan07 = New System.Windows.Forms.Panel()
        Me.TxtNro_Doc = New System.Windows.Forms.TextBox()
        Me.TxtSerie = New System.Windows.Forms.TextBox()
        Me.TxtEstado = New System.Windows.Forms.TextBox()
        Me.TxtTot_Cuota = New System.Windows.Forms.TextBox()
        Me.TxtIgv = New System.Windows.Forms.TextBox()
        Me.TxtInteres = New System.Windows.Forms.TextBox()
        Me.TxtPrincipal = New System.Windows.Forms.TextBox()
        Me.TxtCapital = New System.Windows.Forms.TextBox()
        Me.DtpVcto = New System.Windows.Forms.DateTimePicker()
        Me.TxtCuota = New System.Windows.Forms.TextBox()
        Me.Pan02.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan01.SuspendLayout()
        Me.Pan08.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan03.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Pan09.SuspendLayout()
        CType(Me.Dgv02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan10.SuspendLayout()
        Me.Pan07.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pan02
        '
        Me.Pan02.BackColor = System.Drawing.Color.White
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pan02.Controls.Add(Me.LinkLabel1)
        Me.Pan02.Controls.Add(Me.BtnEstado)
        Me.Pan02.Controls.Add(Me.LnkHistorial)
        Me.Pan02.Controls.Add(Me.Panel2)
        Me.Pan02.Controls.Add(Me.Label3)
        Me.Pan02.Controls.Add(Me.PictureBox1)
        Me.Pan02.Location = New System.Drawing.Point(1, 3)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(805, 43)
        Me.Pan02.TabIndex = 262
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(330, 4)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(57, 14)
        Me.LinkLabel1.TabIndex = 195
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Consultar"
        '
        'BtnEstado
        '
        Me.BtnEstado.BackColor = System.Drawing.Color.Maroon
        Me.BtnEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BtnEstado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnEstado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.BtnEstado.Location = New System.Drawing.Point(679, 5)
        Me.BtnEstado.Name = "BtnEstado"
        Me.BtnEstado.Size = New System.Drawing.Size(119, 29)
        Me.BtnEstado.TabIndex = 194
        Me.BtnEstado.Text = "Pendiente"
        Me.BtnEstado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LnkHistorial
        '
        Me.LnkHistorial.AutoSize = True
        Me.LnkHistorial.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LnkHistorial.Location = New System.Drawing.Point(196, 19)
        Me.LnkHistorial.Name = "LnkHistorial"
        Me.LnkHistorial.Size = New System.Drawing.Size(133, 14)
        Me.LnkHistorial.TabIndex = 193
        Me.LnkHistorial.TabStop = True
        Me.LnkHistorial.Text = "Historial de Cancelación"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.TxtBuscar)
        Me.Panel2.Controls.Add(Me.BtnFin)
        Me.Panel2.Controls.Add(Me.BtnAva)
        Me.Panel2.Controls.Add(Me.BtnAtr)
        Me.Panel2.Controls.Add(Me.BtnIni)
        Me.Panel2.Location = New System.Drawing.Point(397, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(270, 33)
        Me.Panel2.TabIndex = 191
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(2, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 24)
        Me.Label1.TabIndex = 189
        Me.Label1.Text = "Movimiento"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtBuscar
        '
        Me.TxtBuscar.BackColor = System.Drawing.Color.White
        Me.TxtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBuscar.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuscar.Location = New System.Drawing.Point(132, 4)
        Me.TxtBuscar.Name = "TxtBuscar"
        Me.TxtBuscar.Size = New System.Drawing.Size(77, 23)
        Me.TxtBuscar.TabIndex = 176
        Me.TxtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'BtnFin
        '
        Me.BtnFin.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnFin.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFin.Image = CType(resources.GetObject("BtnFin.Image"), System.Drawing.Image)
        Me.BtnFin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnFin.Location = New System.Drawing.Point(238, 4)
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
        Me.BtnAva.Location = New System.Drawing.Point(213, 4)
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
        Me.BtnAtr.Location = New System.Drawing.Point(104, 4)
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
        Me.BtnIni.Location = New System.Drawing.Point(79, 4)
        Me.BtnIni.Name = "BtnIni"
        Me.BtnIni.Size = New System.Drawing.Size(25, 23)
        Me.BtnIni.TabIndex = 172
        Me.BtnIni.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(41, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(274, 36)
        Me.Label3.TabIndex = 164
        Me.Label3.Text = "Registro de Leasing - Pagares - Prestamos y Otros Financiamientos"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 37)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 163
        Me.PictureBox1.TabStop = False
        '
        'Pan01
        '
        Me.Pan01.BackColor = System.Drawing.Color.White
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pan01.Controls.Add(Me.BtnCon1)
        Me.Pan01.Controls.Add(Me.TxtCodProve)
        Me.Pan01.Controls.Add(Me.TxtProve)
        Me.Pan01.Controls.Add(Me.TxtSerie_Credito)
        Me.Pan01.Controls.Add(Me.CboTpoDoc)
        Me.Pan01.Controls.Add(Me.Label2)
        Me.Pan01.Controls.Add(Me.Label11)
        Me.Pan01.Controls.Add(Me.Pan08)
        Me.Pan01.Controls.Add(Me.DtpFec_Emi)
        Me.Pan01.Controls.Add(Me.TxtNr_Cuotas)
        Me.Pan01.Controls.Add(Me.Label10)
        Me.Pan01.Controls.Add(Me.TxtObs)
        Me.Pan01.Controls.Add(Me.TxtNro_Credito)
        Me.Pan01.Controls.Add(Me.TxtTotal)
        Me.Pan01.Controls.Add(Me.TxtNro_Mov)
        Me.Pan01.Controls.Add(Me.CboMon)
        Me.Pan01.Controls.Add(Me.Label9)
        Me.Pan01.Controls.Add(Me.Label8)
        Me.Pan01.Controls.Add(Me.Label7)
        Me.Pan01.Controls.Add(Me.Label6)
        Me.Pan01.Controls.Add(Me.Label5)
        Me.Pan01.Controls.Add(Me.Label4)
        Me.Pan01.Location = New System.Drawing.Point(0, 48)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(806, 119)
        Me.Pan01.TabIndex = 261
        '
        'BtnCon1
        '
        Me.BtnCon1.Enabled = False
        Me.BtnCon1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCon1.Image = CType(resources.GetObject("BtnCon1.Image"), System.Drawing.Image)
        Me.BtnCon1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon1.Location = New System.Drawing.Point(491, 25)
        Me.BtnCon1.Name = "BtnCon1"
        Me.BtnCon1.Size = New System.Drawing.Size(23, 21)
        Me.BtnCon1.TabIndex = 27
        Me.BtnCon1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon1.UseVisualStyleBackColor = True
        '
        'TxtCodProve
        '
        Me.TxtCodProve.BackColor = System.Drawing.Color.White
        Me.TxtCodProve.Enabled = False
        Me.TxtCodProve.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCodProve.Location = New System.Drawing.Point(117, 25)
        Me.TxtCodProve.MaxLength = 3
        Me.TxtCodProve.Name = "TxtCodProve"
        Me.TxtCodProve.Size = New System.Drawing.Size(40, 21)
        Me.TxtCodProve.TabIndex = 25
        Me.TxtCodProve.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtProve
        '
        Me.TxtProve.BackColor = System.Drawing.Color.White
        Me.TxtProve.Enabled = False
        Me.TxtProve.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProve.Location = New System.Drawing.Point(158, 25)
        Me.TxtProve.MaxLength = 10
        Me.TxtProve.Name = "TxtProve"
        Me.TxtProve.Size = New System.Drawing.Size(332, 21)
        Me.TxtProve.TabIndex = 26
        Me.TxtProve.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSerie_Credito
        '
        Me.TxtSerie_Credito.BackColor = System.Drawing.Color.White
        Me.TxtSerie_Credito.Enabled = False
        Me.TxtSerie_Credito.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerie_Credito.Location = New System.Drawing.Point(117, 48)
        Me.TxtSerie_Credito.MaxLength = 4
        Me.TxtSerie_Credito.Name = "TxtSerie_Credito"
        Me.TxtSerie_Credito.Size = New System.Drawing.Size(40, 21)
        Me.TxtSerie_Credito.TabIndex = 3
        Me.TxtSerie_Credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CboTpoDoc
        '
        Me.CboTpoDoc.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CboTpoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboTpoDoc.Enabled = False
        Me.CboTpoDoc.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboTpoDoc.FormattingEnabled = True
        Me.CboTpoDoc.Location = New System.Drawing.Point(117, 70)
        Me.CboTpoDoc.Name = "CboTpoDoc"
        Me.CboTpoDoc.Size = New System.Drawing.Size(139, 21)
        Me.CboTpoDoc.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(3, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 21)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Tpo. Documento"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Navy
        Me.Label11.Location = New System.Drawing.Point(3, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(108, 20)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Proveedor"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Pan08
        '
        Me.Pan08.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan08.Controls.Add(Me.TxtFecha_Crea)
        Me.Pan08.Controls.Add(Me.TxtFecha_Modi)
        Me.Pan08.Controls.Add(Me.TxtUsua_Modi)
        Me.Pan08.Controls.Add(Me.TxtUsua_Crea)
        Me.Pan08.Controls.Add(Me.Label14)
        Me.Pan08.Controls.Add(Me.Label13)
        Me.Pan08.Location = New System.Drawing.Point(519, 26)
        Me.Pan08.Name = "Pan08"
        Me.Pan08.Size = New System.Drawing.Size(281, 65)
        Me.Pan08.TabIndex = 10
        '
        'TxtFecha_Crea
        '
        Me.TxtFecha_Crea.BackColor = System.Drawing.Color.White
        Me.TxtFecha_Crea.Enabled = False
        Me.TxtFecha_Crea.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecha_Crea.Location = New System.Drawing.Point(172, 10)
        Me.TxtFecha_Crea.Name = "TxtFecha_Crea"
        Me.TxtFecha_Crea.Size = New System.Drawing.Size(102, 21)
        Me.TxtFecha_Crea.TabIndex = 23
        '
        'TxtFecha_Modi
        '
        Me.TxtFecha_Modi.BackColor = System.Drawing.Color.White
        Me.TxtFecha_Modi.Enabled = False
        Me.TxtFecha_Modi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFecha_Modi.Location = New System.Drawing.Point(172, 33)
        Me.TxtFecha_Modi.Name = "TxtFecha_Modi"
        Me.TxtFecha_Modi.Size = New System.Drawing.Size(102, 21)
        Me.TxtFecha_Modi.TabIndex = 25
        '
        'TxtUsua_Modi
        '
        Me.TxtUsua_Modi.BackColor = System.Drawing.Color.White
        Me.TxtUsua_Modi.Enabled = False
        Me.TxtUsua_Modi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsua_Modi.Location = New System.Drawing.Point(84, 33)
        Me.TxtUsua_Modi.Name = "TxtUsua_Modi"
        Me.TxtUsua_Modi.Size = New System.Drawing.Size(87, 21)
        Me.TxtUsua_Modi.TabIndex = 24
        '
        'TxtUsua_Crea
        '
        Me.TxtUsua_Crea.BackColor = System.Drawing.Color.White
        Me.TxtUsua_Crea.Enabled = False
        Me.TxtUsua_Crea.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUsua_Crea.Location = New System.Drawing.Point(84, 10)
        Me.TxtUsua_Crea.Name = "TxtUsua_Crea"
        Me.TxtUsua_Crea.Size = New System.Drawing.Size(87, 21)
        Me.TxtUsua_Crea.TabIndex = 22
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Navy
        Me.Label14.Location = New System.Drawing.Point(5, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(76, 20)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Modificado"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Navy
        Me.Label13.Location = New System.Drawing.Point(5, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 21)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Creado"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DtpFec_Emi
        '
        Me.DtpFec_Emi.Enabled = False
        Me.DtpFec_Emi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpFec_Emi.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpFec_Emi.Location = New System.Drawing.Point(117, 91)
        Me.DtpFec_Emi.Name = "DtpFec_Emi"
        Me.DtpFec_Emi.Size = New System.Drawing.Size(139, 22)
        Me.DtpFec_Emi.TabIndex = 6
        '
        'TxtNr_Cuotas
        '
        Me.TxtNr_Cuotas.BackColor = System.Drawing.Color.White
        Me.TxtNr_Cuotas.Enabled = False
        Me.TxtNr_Cuotas.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNr_Cuotas.Location = New System.Drawing.Point(374, 47)
        Me.TxtNr_Cuotas.Name = "TxtNr_Cuotas"
        Me.TxtNr_Cuotas.Size = New System.Drawing.Size(50, 21)
        Me.TxtNr_Cuotas.TabIndex = 7
        Me.TxtNr_Cuotas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Navy
        Me.Label10.Location = New System.Drawing.Point(262, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(106, 21)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Observacion"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TxtObs
        '
        Me.TxtObs.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObs.Location = New System.Drawing.Point(374, 94)
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.Size = New System.Drawing.Size(426, 21)
        Me.TxtObs.TabIndex = 9
        '
        'TxtNro_Credito
        '
        Me.TxtNro_Credito.BackColor = System.Drawing.Color.White
        Me.TxtNro_Credito.Enabled = False
        Me.TxtNro_Credito.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNro_Credito.Location = New System.Drawing.Point(158, 48)
        Me.TxtNro_Credito.MaxLength = 10
        Me.TxtNro_Credito.Name = "TxtNro_Credito"
        Me.TxtNro_Credito.Size = New System.Drawing.Size(101, 21)
        Me.TxtNro_Credito.TabIndex = 4
        Me.TxtNro_Credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTotal
        '
        Me.TxtTotal.BackColor = System.Drawing.Color.White
        Me.TxtTotal.Enabled = False
        Me.TxtTotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(374, 70)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(116, 21)
        Me.TxtTotal.TabIndex = 8
        Me.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtNro_Mov
        '
        Me.TxtNro_Mov.BackColor = System.Drawing.Color.White
        Me.TxtNro_Mov.Enabled = False
        Me.TxtNro_Mov.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNro_Mov.Location = New System.Drawing.Point(117, 3)
        Me.TxtNro_Mov.Name = "TxtNro_Mov"
        Me.TxtNro_Mov.Size = New System.Drawing.Size(96, 21)
        Me.TxtNro_Mov.TabIndex = 0
        Me.TxtNro_Mov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CboMon
        '
        Me.CboMon.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CboMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMon.Enabled = False
        Me.CboMon.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboMon.FormattingEnabled = True
        Me.CboMon.Location = New System.Drawing.Point(467, 2)
        Me.CboMon.Name = "CboMon"
        Me.CboMon.Size = New System.Drawing.Size(47, 21)
        Me.CboMon.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Navy
        Me.Label9.Location = New System.Drawing.Point(262, 69)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(106, 23)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Capital Financiado"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Navy
        Me.Label8.Location = New System.Drawing.Point(3, 92)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 19)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Fecha Emisión"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Navy
        Me.Label7.Location = New System.Drawing.Point(262, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 20)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Nro. Cuotas"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Navy
        Me.Label6.Location = New System.Drawing.Point(357, 2)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 21)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Moneda"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(3, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 21)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Nro. Credito"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(3, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Nro. Movimiento"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Dgv01
        '
        Me.Dgv01.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nro, Me.Vcto, Me.Capital, Me.Principal, Me.Interes, Me.Igv, Me.TotPagar, Me.Estado, Me.Serie, Me.Doc, Me.Item, Me.Anula, Me.c_opc_cancel, Me.c_opc_doc})
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(0, 166)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.Dgv01.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowTemplate.Height = 19
        Me.Dgv01.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(806, 300)
        Me.Dgv01.TabIndex = 263
        '
        'Nro
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Nro.DefaultCellStyle = DataGridViewCellStyle2
        Me.Nro.HeaderText = "Nro."
        Me.Nro.Name = "Nro"
        Me.Nro.ReadOnly = True
        Me.Nro.Width = 40
        '
        'Vcto
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Vcto.DefaultCellStyle = DataGridViewCellStyle3
        Me.Vcto.HeaderText = "Vencimiento"
        Me.Vcto.Name = "Vcto"
        Me.Vcto.ReadOnly = True
        '
        'Capital
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Capital.DefaultCellStyle = DataGridViewCellStyle4
        Me.Capital.HeaderText = "Capital"
        Me.Capital.Name = "Capital"
        Me.Capital.ReadOnly = True
        Me.Capital.Width = 60
        '
        'Principal
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Principal.DefaultCellStyle = DataGridViewCellStyle5
        Me.Principal.HeaderText = "Principal"
        Me.Principal.Name = "Principal"
        Me.Principal.ReadOnly = True
        Me.Principal.Width = 60
        '
        'Interes
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Interes.DefaultCellStyle = DataGridViewCellStyle6
        Me.Interes.HeaderText = "Interes"
        Me.Interes.Name = "Interes"
        Me.Interes.ReadOnly = True
        Me.Interes.Width = 60
        '
        'Igv
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Igv.DefaultCellStyle = DataGridViewCellStyle7
        Me.Igv.HeaderText = "IGV"
        Me.Igv.Name = "Igv"
        Me.Igv.ReadOnly = True
        Me.Igv.Width = 60
        '
        'TotPagar
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.TotPagar.DefaultCellStyle = DataGridViewCellStyle8
        Me.TotPagar.HeaderText = "Total-Pagar"
        Me.TotPagar.Name = "TotPagar"
        Me.TotPagar.ReadOnly = True
        Me.TotPagar.Width = 95
        '
        'Estado
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Estado.DefaultCellStyle = DataGridViewCellStyle9
        Me.Estado.HeaderText = "Estado"
        Me.Estado.Name = "Estado"
        Me.Estado.ReadOnly = True
        Me.Estado.Width = 70
        '
        'Serie
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Serie.DefaultCellStyle = DataGridViewCellStyle10
        Me.Serie.HeaderText = "Nro."
        Me.Serie.Name = "Serie"
        Me.Serie.ReadOnly = True
        Me.Serie.Width = 60
        '
        'Doc
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Doc.DefaultCellStyle = DataGridViewCellStyle11
        Me.Doc.HeaderText = "Documento"
        Me.Doc.Name = "Doc"
        Me.Doc.ReadOnly = True
        Me.Doc.Width = 110
        '
        'Item
        '
        Me.Item.HeaderText = "Item"
        Me.Item.Name = "Item"
        Me.Item.ReadOnly = True
        Me.Item.Visible = False
        '
        'Anula
        '
        Me.Anula.HeaderText = "Anula"
        Me.Anula.Name = "Anula"
        Me.Anula.ReadOnly = True
        Me.Anula.Visible = False
        '
        'c_opc_cancel
        '
        Me.c_opc_cancel.HeaderText = "c_opc_cancel"
        Me.c_opc_cancel.Name = "c_opc_cancel"
        Me.c_opc_cancel.ReadOnly = True
        Me.c_opc_cancel.Visible = False
        '
        'c_opc_doc
        '
        Me.c_opc_doc.HeaderText = "c_opc_doc"
        Me.c_opc_doc.Name = "c_opc_doc"
        Me.c_opc_doc.ReadOnly = True
        Me.c_opc_doc.Visible = False
        '
        'Pan03
        '
        Me.Pan03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan03.Controls.Add(Me.BtnBuscar)
        Me.Pan03.Controls.Add(Me.BtnImp)
        Me.Pan03.Controls.Add(Me.BtnEditar)
        Me.Pan03.Controls.Add(Me.BtnNuevo)
        Me.Pan03.Controls.Add(Me.BtnEliminar)
        Me.Pan03.Location = New System.Drawing.Point(0, 503)
        Me.Pan03.Name = "Pan03"
        Me.Pan03.Size = New System.Drawing.Size(333, 54)
        Me.Pan03.TabIndex = 265
        '
        'BtnBuscar
        '
        Me.BtnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnBuscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBuscar.Image = CType(resources.GetObject("BtnBuscar.Image"), System.Drawing.Image)
        Me.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnBuscar.Location = New System.Drawing.Point(265, 1)
        Me.BtnBuscar.Name = "BtnBuscar"
        Me.BtnBuscar.Size = New System.Drawing.Size(65, 50)
        Me.BtnBuscar.TabIndex = 14
        Me.BtnBuscar.Text = "Buscar"
        Me.BtnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBuscar.UseVisualStyleBackColor = False
        '
        'BtnImp
        '
        Me.BtnImp.BackColor = System.Drawing.SystemColors.Control
        Me.BtnImp.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnImp.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImp.Image = CType(resources.GetObject("BtnImp.Image"), System.Drawing.Image)
        Me.BtnImp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnImp.Location = New System.Drawing.Point(199, 1)
        Me.BtnImp.Name = "BtnImp"
        Me.BtnImp.Size = New System.Drawing.Size(65, 50)
        Me.BtnImp.TabIndex = 13
        Me.BtnImp.Text = "Imprimir"
        Me.BtnImp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnImp.UseVisualStyleBackColor = False
        '
        'BtnEditar
        '
        Me.BtnEditar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEditar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEditar.Image = CType(resources.GetObject("BtnEditar.Image"), System.Drawing.Image)
        Me.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnEditar.Location = New System.Drawing.Point(67, 1)
        Me.BtnEditar.Name = "BtnEditar"
        Me.BtnEditar.Size = New System.Drawing.Size(65, 50)
        Me.BtnEditar.TabIndex = 11
        Me.BtnEditar.Text = "&Editar"
        Me.BtnEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnEditar.UseVisualStyleBackColor = False
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.SystemColors.Control
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNuevo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnNuevo.Location = New System.Drawing.Point(1, 1)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(65, 50)
        Me.BtnNuevo.TabIndex = 10
        Me.BtnNuevo.Text = "&Nuevo"
        Me.BtnNuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnEliminar.Location = New System.Drawing.Point(133, 1)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(65, 50)
        Me.BtnEliminar.TabIndex = 12
        Me.BtnEliminar.Text = "&Anular"
        Me.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtnCerrar)
        Me.Panel4.Controls.Add(Me.BtnGrabar)
        Me.Panel4.Location = New System.Drawing.Point(671, 502)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(135, 55)
        Me.Panel4.TabIndex = 266
        '
        'BtnCerrar
        '
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCerrar.Location = New System.Drawing.Point(67, 1)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(65, 51)
        Me.BtnCerrar.TabIndex = 9
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCerrar.UseVisualStyleBackColor = True
        '
        'BtnGrabar
        '
        Me.BtnGrabar.Enabled = False
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnGrabar.Location = New System.Drawing.Point(1, 1)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(65, 51)
        Me.BtnGrabar.TabIndex = 8
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnGrabar.UseVisualStyleBackColor = True
        '
        'Pan09
        '
        Me.Pan09.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan09.Controls.Add(Me.BtnAdd)
        Me.Pan09.Controls.Add(Me.BtnEdit)
        Me.Pan09.Controls.Add(Me.BtnDel)
        Me.Pan09.Enabled = False
        Me.Pan09.Location = New System.Drawing.Point(2, 469)
        Me.Pan09.Name = "Pan09"
        Me.Pan09.Size = New System.Drawing.Size(252, 29)
        Me.Pan09.TabIndex = 267
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAdd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.Image = CType(resources.GetObject("BtnAdd.Image"), System.Drawing.Image)
        Me.BtnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAdd.Location = New System.Drawing.Point(2, 2)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(84, 23)
        Me.BtnAdd.TabIndex = 176
        Me.BtnAdd.Text = "&Agregar"
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEdit.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdit.Image = CType(resources.GetObject("BtnEdit.Image"), System.Drawing.Image)
        Me.BtnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEdit.Location = New System.Drawing.Point(87, 2)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(82, 23)
        Me.BtnEdit.TabIndex = 1
        Me.BtnEdit.Text = "Modificar"
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'BtnDel
        '
        Me.BtnDel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnDel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDel.Image = CType(resources.GetObject("BtnDel.Image"), System.Drawing.Image)
        Me.BtnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDel.Location = New System.Drawing.Point(170, 2)
        Me.BtnDel.Name = "BtnDel"
        Me.BtnDel.Size = New System.Drawing.Size(78, 23)
        Me.BtnDel.TabIndex = 2
        Me.BtnDel.Text = "Eliminar"
        Me.BtnDel.UseVisualStyleBackColor = False
        '
        'Dgv02
        '
        Me.Dgv02.AllowUserToAddRows = False
        Me.Dgv02.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv02.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.Dgv02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv02.ColumnHeadersVisible = False
        Me.Dgv02.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Titulo, Me.SubTotal, Me.espacio})
        Me.Dgv02.EnableHeadersVisualStyles = False
        Me.Dgv02.Location = New System.Drawing.Point(0, 467)
        Me.Dgv02.Name = "Dgv02"
        Me.Dgv02.ReadOnly = True
        Me.Dgv02.RowHeadersVisible = False
        Me.Dgv02.RowHeadersWidth = 15
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv02.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.Dgv02.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv02.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.Dgv02.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.Dgv02.RowTemplate.Height = 28
        Me.Dgv02.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv02.Size = New System.Drawing.Size(806, 33)
        Me.Dgv02.TabIndex = 264
        '
        'Titulo
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Titulo.DefaultCellStyle = DataGridViewCellStyle14
        Me.Titulo.HeaderText = "Titulo"
        Me.Titulo.Name = "Titulo"
        Me.Titulo.ReadOnly = True
        Me.Titulo.Width = 400
        '
        'SubTotal
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.SubTotal.DefaultCellStyle = DataGridViewCellStyle15
        Me.SubTotal.HeaderText = "SubTotal"
        Me.SubTotal.Name = "SubTotal"
        Me.SubTotal.ReadOnly = True
        Me.SubTotal.Width = 80
        '
        'espacio
        '
        Me.espacio.HeaderText = "espacio"
        Me.espacio.Name = "espacio"
        Me.espacio.ReadOnly = True
        Me.espacio.Width = 300
        '
        'Pan10
        '
        Me.Pan10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan10.Controls.Add(Me.BtnAceptar)
        Me.Pan10.Controls.Add(Me.BtnCancel)
        Me.Pan10.Enabled = False
        Me.Pan10.Location = New System.Drawing.Point(637, 469)
        Me.Pan10.Name = "Pan10"
        Me.Pan10.Size = New System.Drawing.Size(167, 29)
        Me.Pan10.TabIndex = 268
        '
        'BtnAceptar
        '
        Me.BtnAceptar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnAceptar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAceptar.Image = CType(resources.GetObject("BtnAceptar.Image"), System.Drawing.Image)
        Me.BtnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAceptar.Location = New System.Drawing.Point(2, 2)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(82, 23)
        Me.BtnAceptar.TabIndex = 1
        Me.BtnAceptar.Text = "&Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCancel.Image = CType(resources.GetObject("BtnCancel.Image"), System.Drawing.Image)
        Me.BtnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCancel.Location = New System.Drawing.Point(85, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(78, 23)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "Cancelar"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'Pan07
        '
        Me.Pan07.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan07.Controls.Add(Me.TxtNro_Doc)
        Me.Pan07.Controls.Add(Me.TxtSerie)
        Me.Pan07.Controls.Add(Me.TxtEstado)
        Me.Pan07.Controls.Add(Me.TxtTot_Cuota)
        Me.Pan07.Controls.Add(Me.TxtIgv)
        Me.Pan07.Controls.Add(Me.TxtInteres)
        Me.Pan07.Controls.Add(Me.TxtPrincipal)
        Me.Pan07.Controls.Add(Me.TxtCapital)
        Me.Pan07.Controls.Add(Me.DtpVcto)
        Me.Pan07.Controls.Add(Me.TxtCuota)
        Me.Pan07.Location = New System.Drawing.Point(2, 168)
        Me.Pan07.Name = "Pan07"
        Me.Pan07.Size = New System.Drawing.Size(804, 30)
        Me.Pan07.TabIndex = 269
        '
        'TxtNro_Doc
        '
        Me.TxtNro_Doc.BackColor = System.Drawing.Color.White
        Me.TxtNro_Doc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNro_Doc.Enabled = False
        Me.TxtNro_Doc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNro_Doc.Location = New System.Drawing.Point(619, 3)
        Me.TxtNro_Doc.Name = "TxtNro_Doc"
        Me.TxtNro_Doc.Size = New System.Drawing.Size(79, 22)
        Me.TxtNro_Doc.TabIndex = 15
        Me.TxtNro_Doc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtSerie
        '
        Me.TxtSerie.BackColor = System.Drawing.Color.White
        Me.TxtSerie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSerie.Enabled = False
        Me.TxtSerie.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerie.Location = New System.Drawing.Point(559, 3)
        Me.TxtSerie.Name = "TxtSerie"
        Me.TxtSerie.Size = New System.Drawing.Size(60, 22)
        Me.TxtSerie.TabIndex = 14
        Me.TxtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtEstado
        '
        Me.TxtEstado.BackColor = System.Drawing.Color.White
        Me.TxtEstado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtEstado.Enabled = False
        Me.TxtEstado.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEstado.Location = New System.Drawing.Point(489, 3)
        Me.TxtEstado.Name = "TxtEstado"
        Me.TxtEstado.Size = New System.Drawing.Size(70, 22)
        Me.TxtEstado.TabIndex = 13
        Me.TxtEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtTot_Cuota
        '
        Me.TxtTot_Cuota.BackColor = System.Drawing.Color.White
        Me.TxtTot_Cuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTot_Cuota.Enabled = False
        Me.TxtTot_Cuota.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTot_Cuota.Location = New System.Drawing.Point(393, 3)
        Me.TxtTot_Cuota.Name = "TxtTot_Cuota"
        Me.TxtTot_Cuota.Size = New System.Drawing.Size(96, 22)
        Me.TxtTot_Cuota.TabIndex = 12
        Me.TxtTot_Cuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtIgv
        '
        Me.TxtIgv.BackColor = System.Drawing.Color.White
        Me.TxtIgv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtIgv.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIgv.Location = New System.Drawing.Point(333, 3)
        Me.TxtIgv.Name = "TxtIgv"
        Me.TxtIgv.Size = New System.Drawing.Size(60, 22)
        Me.TxtIgv.TabIndex = 11
        Me.TxtIgv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtInteres
        '
        Me.TxtInteres.BackColor = System.Drawing.Color.White
        Me.TxtInteres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtInteres.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInteres.Location = New System.Drawing.Point(273, 3)
        Me.TxtInteres.Name = "TxtInteres"
        Me.TxtInteres.Size = New System.Drawing.Size(60, 22)
        Me.TxtInteres.TabIndex = 10
        Me.TxtInteres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtPrincipal
        '
        Me.TxtPrincipal.BackColor = System.Drawing.Color.White
        Me.TxtPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPrincipal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrincipal.Location = New System.Drawing.Point(213, 3)
        Me.TxtPrincipal.Name = "TxtPrincipal"
        Me.TxtPrincipal.Size = New System.Drawing.Size(60, 22)
        Me.TxtPrincipal.TabIndex = 9
        Me.TxtPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCapital
        '
        Me.TxtCapital.BackColor = System.Drawing.Color.White
        Me.TxtCapital.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCapital.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCapital.Location = New System.Drawing.Point(154, 3)
        Me.TxtCapital.Name = "TxtCapital"
        Me.TxtCapital.Size = New System.Drawing.Size(59, 22)
        Me.TxtCapital.TabIndex = 8
        Me.TxtCapital.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DtpVcto
        '
        Me.DtpVcto.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpVcto.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtpVcto.Location = New System.Drawing.Point(54, 3)
        Me.DtpVcto.Name = "DtpVcto"
        Me.DtpVcto.Size = New System.Drawing.Size(99, 22)
        Me.DtpVcto.TabIndex = 7
        '
        'TxtCuota
        '
        Me.TxtCuota.BackColor = System.Drawing.Color.White
        Me.TxtCuota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCuota.Enabled = False
        Me.TxtCuota.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCuota.Location = New System.Drawing.Point(14, 3)
        Me.TxtCuota.Name = "TxtCuota"
        Me.TxtCuota.Size = New System.Drawing.Size(40, 22)
        Me.TxtCuota.TabIndex = 1
        Me.TxtCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmLeasing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 559)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Pan07)
        Me.Controls.Add(Me.Pan10)
        Me.Controls.Add(Me.Pan09)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Pan03)
        Me.Controls.Add(Me.Dgv02)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Pan01)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmLeasing"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registro de Leasing - Pagares - Prestamos y Otros Financiamientos"
        Me.Pan02.ResumeLayout(False)
        Me.Pan02.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        Me.Pan08.ResumeLayout(False)
        Me.Pan08.PerformLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan03.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Pan09.ResumeLayout(False)
        CType(Me.Dgv02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan10.ResumeLayout(False)
        Me.Pan07.ResumeLayout(False)
        Me.Pan07.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents BtnFin As System.Windows.Forms.Button
    Friend WithEvents BtnAva As System.Windows.Forms.Button
    Friend WithEvents BtnAtr As System.Windows.Forms.Button
    Friend WithEvents BtnIni As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtObs As System.Windows.Forms.TextBox
    Friend WithEvents TxtNro_Credito As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtNro_Mov As System.Windows.Forms.TextBox
    Friend WithEvents CboMon As System.Windows.Forms.ComboBox
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Pan03 As System.Windows.Forms.Panel
    Friend WithEvents BtnImp As System.Windows.Forms.Button
    Friend WithEvents BtnEditar As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents TxtNr_Cuotas As System.Windows.Forms.TextBox
    Friend WithEvents DtpFec_Emi As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnBuscar As System.Windows.Forms.Button
    Friend WithEvents Pan08 As System.Windows.Forms.Panel
    Friend WithEvents TxtFecha_Crea As System.Windows.Forms.TextBox
    Friend WithEvents TxtFecha_Modi As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsua_Modi As System.Windows.Forms.TextBox
    Friend WithEvents TxtUsua_Crea As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Pan09 As System.Windows.Forms.Panel
    Friend WithEvents BtnAdd As System.Windows.Forms.Button
    Friend WithEvents BtnEdit As System.Windows.Forms.Button
    Friend WithEvents BtnDel As System.Windows.Forms.Button
    Friend WithEvents Dgv02 As System.Windows.Forms.DataGridView
    Friend WithEvents Pan10 As System.Windows.Forms.Panel
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Pan07 As System.Windows.Forms.Panel
    Friend WithEvents TxtNro_Doc As System.Windows.Forms.TextBox
    Friend WithEvents TxtSerie As System.Windows.Forms.TextBox
    Friend WithEvents TxtEstado As System.Windows.Forms.TextBox
    Friend WithEvents TxtTot_Cuota As System.Windows.Forms.TextBox
    Friend WithEvents TxtIgv As System.Windows.Forms.TextBox
    Friend WithEvents TxtInteres As System.Windows.Forms.TextBox
    Friend WithEvents TxtPrincipal As System.Windows.Forms.TextBox
    Friend WithEvents TxtCapital As System.Windows.Forms.TextBox
    Friend WithEvents DtpVcto As System.Windows.Forms.DateTimePicker
    Friend WithEvents TxtCuota As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LnkHistorial As System.Windows.Forms.LinkLabel
    Friend WithEvents BtnEstado As System.Windows.Forms.Label
    Friend WithEvents Titulo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents espacio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nro As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Vcto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Capital As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Principal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Interes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Igv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotPagar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Estado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Serie As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Anula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_opc_cancel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_opc_doc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CboTpoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSerie_Credito As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents TxtCodProve As TextBox
    Friend WithEvents TxtProve As TextBox
    Friend WithEvents BtnCon1 As Button
End Class
