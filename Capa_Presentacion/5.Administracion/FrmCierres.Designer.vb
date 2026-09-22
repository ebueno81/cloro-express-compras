<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCierres
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCierres))
        Me.lbltotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnbus = New System.Windows.Forms.Button()
        Me.Pan03 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtObs = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CboEstado = New System.Windows.Forms.ComboBox()
        Me.CboMes = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtAño = New System.Windows.Forms.TextBox()
        Me.dgv01 = New System.Windows.Forms.DataGridView()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BtnImprimir = New System.Windows.Forms.Button()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.status01 = New System.Windows.Forms.StatusStrip()
        Me.Pan02 = New System.Windows.Forms.Panel()
        Me.txtbus = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbocriterio = New System.Windows.Forms.ComboBox()
        Me.BtnBus2 = New System.Windows.Forms.Button()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Pan03.SuspendLayout()
        CType(Me.dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan01.SuspendLayout()
        Me.status01.SuspendLayout()
        Me.Pan02.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbltotal
        '
        Me.lbltotal.BackColor = System.Drawing.Color.Maroon
        Me.lbltotal.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(85, 17)
        Me.lbltotal.Text = "Total Registros"
        '
        'btnbus
        '
        Me.btnbus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnbus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnbus.Location = New System.Drawing.Point(408, 5)
        Me.btnbus.Name = "btnbus"
        Me.btnbus.Size = New System.Drawing.Size(77, 21)
        Me.btnbus.TabIndex = 2
        Me.btnbus.Text = "&Buscar"
        Me.btnbus.UseVisualStyleBackColor = True
        '
        'Pan03
        '
        Me.Pan03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan03.Controls.Add(Me.Label7)
        Me.Pan03.Controls.Add(Me.TxtObs)
        Me.Pan03.Controls.Add(Me.Label6)
        Me.Pan03.Controls.Add(Me.CboEstado)
        Me.Pan03.Controls.Add(Me.CboMes)
        Me.Pan03.Controls.Add(Me.Label5)
        Me.Pan03.Controls.Add(Me.Label4)
        Me.Pan03.Controls.Add(Me.TxtAño)
        Me.Pan03.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pan03.Location = New System.Drawing.Point(1, 224)
        Me.Pan03.Name = "Pan03"
        Me.Pan03.Size = New System.Drawing.Size(492, 132)
        Me.Pan03.TabIndex = 131
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(31, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 21)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Observaciones"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TxtObs
        '
        Me.TxtObs.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtObs.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtObs.Location = New System.Drawing.Point(113, 88)
        Me.TxtObs.MaxLength = 300
        Me.TxtObs.Name = "TxtObs"
        Me.TxtObs.Size = New System.Drawing.Size(366, 21)
        Me.TxtObs.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(31, 64)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 22)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Estado"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CboEstado
        '
        Me.CboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboEstado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboEstado.FormattingEnabled = True
        Me.CboEstado.Items.AddRange(New Object() {"Abierto", "Cerrado"})
        Me.CboEstado.Location = New System.Drawing.Point(113, 64)
        Me.CboEstado.Name = "CboEstado"
        Me.CboEstado.Size = New System.Drawing.Size(93, 21)
        Me.CboEstado.TabIndex = 3
        '
        'CboMes
        '
        Me.CboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CboMes.FormattingEnabled = True
        Me.CboMes.Location = New System.Drawing.Point(113, 40)
        Me.CboMes.Name = "CboMes"
        Me.CboMes.Size = New System.Drawing.Size(167, 21)
        Me.CboMes.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Blue
        Me.Label5.Location = New System.Drawing.Point(31, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 22)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Año Cierre"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(31, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 22)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Mes Cierre"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtAño
        '
        Me.TxtAño.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAño.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAño.Location = New System.Drawing.Point(113, 16)
        Me.TxtAño.MaxLength = 4
        Me.TxtAño.Name = "TxtAño"
        Me.TxtAño.Size = New System.Drawing.Size(66, 21)
        Me.TxtAño.TabIndex = 2
        '
        'dgv01
        '
        Me.dgv01.AllowUserToAddRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Navy
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv01.EnableHeadersVisualStyles = False
        Me.dgv01.Location = New System.Drawing.Point(0, 1)
        Me.dgv01.Name = "dgv01"
        Me.dgv01.ReadOnly = True
        Me.dgv01.RowHeadersWidth = 25
        Me.dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv01.Size = New System.Drawing.Size(488, 197)
        Me.dgv01.TabIndex = 5
        '
        'Pan01
        '
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.dgv01)
        Me.Pan01.Location = New System.Drawing.Point(1, 22)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(492, 201)
        Me.Pan01.TabIndex = 137
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(1, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Buscar por"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(1, 1)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(492, 21)
        Me.Label22.TabIndex = 139
        Me.Label22.Text = "Mantenimiento de Familias"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnImprimir
        '
        Me.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnImprimir.Image = CType(resources.GetObject("BtnImprimir.Image"), System.Drawing.Image)
        Me.BtnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnImprimir.Location = New System.Drawing.Point(103, 1)
        Me.BtnImprimir.Name = "BtnImprimir"
        Me.BtnImprimir.Size = New System.Drawing.Size(86, 26)
        Me.BtnImprimir.TabIndex = 136
        Me.BtnImprimir.Text = "&Imprimir"
        Me.BtnImprimir.UseVisualStyleBackColor = True
        '
        'BtnCerrar
        '
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(169, 1)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(88, 25)
        Me.BtnCerrar.TabIndex = 134
        Me.BtnCerrar.Text = "[Esc] &Cerrar"
        Me.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnCerrar.UseVisualStyleBackColor = True
        '
        'status01
        '
        Me.status01.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lbltotal})
        Me.status01.Location = New System.Drawing.Point(0, 387)
        Me.status01.Name = "status01"
        Me.status01.Size = New System.Drawing.Size(495, 22)
        Me.status01.TabIndex = 138
        Me.status01.Text = "StatusStrip1"
        '
        'Pan02
        '
        Me.Pan02.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan02.Controls.Add(Me.btnbus)
        Me.Pan02.Controls.Add(Me.Label2)
        Me.Pan02.Controls.Add(Me.txtbus)
        Me.Pan02.Controls.Add(Me.Label1)
        Me.Pan02.Controls.Add(Me.cbocriterio)
        Me.Pan02.Location = New System.Drawing.Point(1, 191)
        Me.Pan02.Name = "Pan02"
        Me.Pan02.Size = New System.Drawing.Size(492, 32)
        Me.Pan02.TabIndex = 140
        '
        'txtbus
        '
        Me.txtbus.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtbus.Location = New System.Drawing.Point(229, 5)
        Me.txtbus.Name = "txtbus"
        Me.txtbus.Size = New System.Drawing.Size(179, 21)
        Me.txtbus.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(174, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Buscar"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cbocriterio
        '
        Me.cbocriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbocriterio.FormattingEnabled = True
        Me.cbocriterio.Items.AddRange(New Object() {"Codigo", "Año", "Mes"})
        Me.cbocriterio.Location = New System.Drawing.Point(63, 5)
        Me.cbocriterio.Name = "cbocriterio"
        Me.cbocriterio.Size = New System.Drawing.Size(109, 21)
        Me.cbocriterio.TabIndex = 0
        '
        'BtnBus2
        '
        Me.BtnBus2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnBus2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBus2.Image = CType(resources.GetObject("BtnBus2.Image"), System.Drawing.Image)
        Me.BtnBus2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBus2.Location = New System.Drawing.Point(89, 1)
        Me.BtnBus2.Name = "BtnBus2"
        Me.BtnBus2.Size = New System.Drawing.Size(79, 25)
        Me.BtnBus2.TabIndex = 133
        Me.BtnBus2.Text = "&Buscar"
        Me.BtnBus2.UseVisualStyleBackColor = True
        '
        'BtnGrabar
        '
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(1, 1)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(87, 25)
        Me.BtnGrabar.TabIndex = 132
        Me.BtnGrabar.Text = "&Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnGrabar)
        Me.Panel1.Controls.Add(Me.BtnBus2)
        Me.Panel1.Controls.Add(Me.BtnCerrar)
        Me.Panel1.Location = New System.Drawing.Point(0, 357)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(260, 29)
        Me.Panel1.TabIndex = 141
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.BtnEliminar)
        Me.Panel2.Controls.Add(Me.BtnImprimir)
        Me.Panel2.Location = New System.Drawing.Point(301, 357)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(192, 30)
        Me.Panel2.TabIndex = 143
        '
        'BtnEliminar
        '
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(1, 1)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(101, 26)
        Me.BtnEliminar.TabIndex = 135
        Me.BtnEliminar.Text = "&Anular Cierre"
        Me.BtnEliminar.UseVisualStyleBackColor = True
        '
        'FrmCierres
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 409)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pan03)
        Me.Controls.Add(Me.Pan01)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.status01)
        Me.Controls.Add(Me.Pan02)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "FrmCierres"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cierres Mensual..."
        Me.Pan03.ResumeLayout(False)
        Me.Pan03.PerformLayout()
        CType(Me.dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan01.ResumeLayout(False)
        Me.status01.ResumeLayout(False)
        Me.status01.PerformLayout()
        Me.Pan02.ResumeLayout(False)
        Me.Pan02.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbltotal As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnbus As System.Windows.Forms.Button
    Friend WithEvents Pan03 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtObs As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CboEstado As System.Windows.Forms.ComboBox
    Friend WithEvents CboMes As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtAño As System.Windows.Forms.TextBox
    Friend WithEvents dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents BtnImprimir As System.Windows.Forms.Button
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents status01 As System.Windows.Forms.StatusStrip
    Friend WithEvents Pan02 As System.Windows.Forms.Panel
    Friend WithEvents txtbus As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbocriterio As System.Windows.Forms.ComboBox
    Friend WithEvents BtnBus2 As System.Windows.Forms.Button
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
End Class
