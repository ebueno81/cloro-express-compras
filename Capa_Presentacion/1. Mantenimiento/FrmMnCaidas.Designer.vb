<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMnCaidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMnCaidas))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Pcb01 = New System.Windows.Forms.PictureBox()
        Me.lblcod = New System.Windows.Forms.Label()
        Me.lbltg = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnSCaidas = New System.Windows.Forms.Button()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.BtnEdi = New System.Windows.Forms.Button()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.TxtCod = New System.Windows.Forms.TextBox()
        Me.TxtDesc = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Pan03 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Pan04 = New System.Windows.Forms.Panel()
        Me.TxtArea = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtAnexo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtCtaCompra = New System.Windows.Forms.TextBox()
        Me.TxtCosto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtCtaVenta = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan02.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan03.SuspendLayout()
        Me.Pan01.SuspendLayout()
        Me.Pan04.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Pcb01)
        Me.Panel2.Controls.Add(Me.lblcod)
        Me.Panel2.Controls.Add(Me.lbltg)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.BtnSCaidas)
        Me.Panel2.Location = New System.Drawing.Point(1, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(473, 78)
        Me.Panel2.TabIndex = 5
        '
        'Pcb01
        '
        Me.Pcb01.Image = CType(resources.GetObject("Pcb01.Image"), System.Drawing.Image)
        Me.Pcb01.Location = New System.Drawing.Point(7, 5)
        Me.Pcb01.Name = "Pcb01"
        Me.Pcb01.Size = New System.Drawing.Size(66, 59)
        Me.Pcb01.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pcb01.TabIndex = 161
        Me.Pcb01.TabStop = False
        '
        'lblcod
        '
        Me.lblcod.AutoSize = True
        Me.lblcod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcod.ForeColor = System.Drawing.Color.Red
        Me.lblcod.Location = New System.Drawing.Point(415, 18)
        Me.lblcod.Name = "lblcod"
        Me.lblcod.Size = New System.Drawing.Size(50, 14)
        Me.lblcod.TabIndex = 4
        Me.lblcod.Text = "Codigo"
        '
        'lbltg
        '
        Me.lbltg.AutoSize = True
        Me.lbltg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltg.ForeColor = System.Drawing.Color.Red
        Me.lbltg.Location = New System.Drawing.Point(185, 36)
        Me.lbltg.Name = "lbltg"
        Me.lbltg.Size = New System.Drawing.Size(105, 14)
        Me.lbltg.TabIndex = 3
        Me.lbltg.Text = "Y su Descripción"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(86, 36)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 14)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Y su Descripción"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(86, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(323, 14)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Aqui se crean las Caidas para el codigo de la Tabla General"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(86, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tabla Caidas"
        '
        'BtnSCaidas
        '
        Me.BtnSCaidas.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSCaidas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSCaidas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSCaidas.Image = CType(resources.GetObject("BtnSCaidas.Image"), System.Drawing.Image)
        Me.BtnSCaidas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSCaidas.Location = New System.Drawing.Point(370, 50)
        Me.BtnSCaidas.Name = "BtnSCaidas"
        Me.BtnSCaidas.Size = New System.Drawing.Size(94, 22)
        Me.BtnSCaidas.TabIndex = 2
        Me.BtnSCaidas.Text = "  Sub-Caídas"
        Me.BtnSCaidas.UseVisualStyleBackColor = False
        '
        'Pan02
        '
        Me.Pan02.BackColor = System.Drawing.Color.White
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.BtnEdi)
        Me.Pan02.Controls.Add(Me.BtnNuevo)
        Me.Pan02.Controls.Add(Me.BtnEliminar)
        Me.Pan02.Location = New System.Drawing.Point(2, 452)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(249, 29)
        Me.Pan02.TabIndex = 0
        '
        'BtnEdi
        '
        Me.BtnEdi.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEdi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEdi.Image = CType(resources.GetObject("BtnEdi.Image"), System.Drawing.Image)
        Me.BtnEdi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEdi.Location = New System.Drawing.Point(83, 2)
        Me.BtnEdi.Name = "BtnEdi"
        Me.BtnEdi.Size = New System.Drawing.Size(81, 23)
        Me.BtnEdi.TabIndex = 1
        Me.BtnEdi.Text = "Editar"
        Me.BtnEdi.UseVisualStyleBackColor = False
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(2, 2)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(80, 23)
        Me.BtnNuevo.TabIndex = 0
        Me.BtnNuevo.Text = "&Agregar"
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(165, 2)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(80, 23)
        Me.BtnEliminar.TabIndex = 2
        Me.BtnEliminar.Text = "Anular"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'TxtCod
        '
        Me.TxtCod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod.Enabled = False
        Me.TxtCod.Location = New System.Drawing.Point(2, 2)
        Me.TxtCod.Name = "TxtCod"
        Me.TxtCod.Size = New System.Drawing.Size(64, 20)
        Me.TxtCod.TabIndex = 0
        Me.TxtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtDesc
        '
        Me.TxtDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtDesc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtDesc.Location = New System.Drawing.Point(67, 2)
        Me.TxtDesc.Name = "TxtDesc"
        Me.TxtDesc.Size = New System.Drawing.Size(400, 20)
        Me.TxtDesc.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(2, 81)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(472, 21)
        Me.Label22.TabIndex = 171
        Me.Label22.Text = "Mantenimiento de Caidas"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(2, 102)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(472, 347)
        Me.Dgv01.TabIndex = 1
        '
        'Pan03
        '
        Me.Pan03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan03.Controls.Add(Me.BtnCerrar)
        Me.Pan03.Controls.Add(Me.BtnGrabar)
        Me.Pan03.Location = New System.Drawing.Point(307, 452)
        Me.Pan03.Name = "Pan03"
        Me.Pan03.Size = New System.Drawing.Size(167, 29)
        Me.Pan03.TabIndex = 4
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(82, 2)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(81, 23)
        Me.BtnCerrar.TabIndex = 1
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnGrabar.Enabled = False
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(2, 2)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(79, 23)
        Me.BtnGrabar.TabIndex = 0
        Me.BtnGrabar.Text = "Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'Pan01
        '
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.TxtDesc)
        Me.Pan01.Controls.Add(Me.TxtCod)
        Me.Pan01.Location = New System.Drawing.Point(2, 326)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(472, 26)
        Me.Pan01.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(2, 353)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(473, 20)
        Me.Label12.TabIndex = 177
        Me.Label12.Text = "Cuentas Contables"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pan04
        '
        Me.Pan04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan04.Controls.Add(Me.TxtArea)
        Me.Pan04.Controls.Add(Me.Label6)
        Me.Pan04.Controls.Add(Me.TxtAnexo)
        Me.Pan04.Controls.Add(Me.Label11)
        Me.Pan04.Controls.Add(Me.Label5)
        Me.Pan04.Controls.Add(Me.TxtCtaCompra)
        Me.Pan04.Controls.Add(Me.TxtCosto)
        Me.Pan04.Controls.Add(Me.Label7)
        Me.Pan04.Controls.Add(Me.TxtCtaVenta)
        Me.Pan04.Controls.Add(Me.Label8)
        Me.Pan04.Location = New System.Drawing.Point(2, 373)
        Me.Pan04.Name = "Pan04"
        Me.Pan04.Size = New System.Drawing.Size(472, 76)
        Me.Pan04.TabIndex = 3
        '
        'TxtArea
        '
        Me.TxtArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtArea.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtArea.Location = New System.Drawing.Point(412, 16)
        Me.TxtArea.Name = "TxtArea"
        Me.TxtArea.Size = New System.Drawing.Size(40, 20)
        Me.TxtArea.TabIndex = 3
        Me.TxtArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 21)
        Me.Label6.TabIndex = 33
        Me.Label6.Text = "Cuenta Compra"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtAnexo
        '
        Me.TxtAnexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAnexo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAnexo.Location = New System.Drawing.Point(259, 40)
        Me.TxtAnexo.Name = "TxtAnexo"
        Me.TxtAnexo.Size = New System.Drawing.Size(76, 20)
        Me.TxtAnexo.TabIndex = 4
        Me.TxtAnexo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TxtAnexo.Visible = False
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(337, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 21)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "Area - Caja"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(175, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 21)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Anexo"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label5.Visible = False
        '
        'TxtCtaCompra
        '
        Me.TxtCtaCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCtaCompra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCtaCompra.Location = New System.Drawing.Point(94, 17)
        Me.TxtCtaCompra.Name = "TxtCtaCompra"
        Me.TxtCtaCompra.Size = New System.Drawing.Size(80, 20)
        Me.TxtCtaCompra.TabIndex = 1
        Me.TxtCtaCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCosto
        '
        Me.TxtCosto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCosto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCosto.Location = New System.Drawing.Point(94, 41)
        Me.TxtCosto.Name = "TxtCosto"
        Me.TxtCosto.Size = New System.Drawing.Size(80, 20)
        Me.TxtCosto.TabIndex = 5
        Me.TxtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(176, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 21)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Cuenta Venta"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCtaVenta
        '
        Me.TxtCtaVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCtaVenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCtaVenta.Location = New System.Drawing.Point(259, 16)
        Me.TxtCtaVenta.Name = "TxtCtaVenta"
        Me.TxtCtaVenta.Size = New System.Drawing.Size(76, 20)
        Me.TxtCtaVenta.TabIndex = 2
        Me.TxtCtaVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 21)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Centro Costo"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmMnCaidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 483)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Pan04)
        Me.Controls.Add(Me.Pan01)
        Me.Controls.Add(Me.Pan03)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Pan02)
        Me.Controls.Add(Me.Label22)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmMnCaidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Caidas"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan02.ResumeLayout(False)
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan03.ResumeLayout(False)
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        Me.Pan04.ResumeLayout(False)
        Me.Pan04.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnSCaidas As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents TxtCod As System.Windows.Forms.TextBox
    Friend WithEvents TxtDesc As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents lblcod As System.Windows.Forms.Label
    Friend WithEvents lbltg As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Pcb01 As System.Windows.Forms.PictureBox
    Friend WithEvents BtnEdi As System.Windows.Forms.Button
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents Pan03 As System.Windows.Forms.Panel
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Pan04 As System.Windows.Forms.Panel
    Friend WithEvents TxtArea As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaCompra As System.Windows.Forms.TextBox
    Friend WithEvents TxtCosto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtCtaVenta As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
