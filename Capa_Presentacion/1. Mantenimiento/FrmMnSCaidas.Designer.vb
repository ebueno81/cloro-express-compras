<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMnSCaidas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMnSCaidas))
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BtnEdi = New System.Windows.Forms.Button()
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.TxtAnexo = New System.Windows.Forms.TextBox()
        Me.TxtCod_Articulo = New System.Windows.Forms.TextBox()
        Me.TxtCod = New System.Windows.Forms.TextBox()
        Me.TxtScd = New System.Windows.Forms.TextBox()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.lbltg = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblcod = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblcod2 = New System.Windows.Forms.Label()
        Me.lblcd = New System.Windows.Forms.Label()
        Me.Pcb01 = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnArticulos = New System.Windows.Forms.Button()
        Me.Pan04 = New System.Windows.Forms.Panel()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.Pan03 = New System.Windows.Forms.Panel()
        Me.BtnNuevo = New System.Windows.Forms.Button()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan01.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Pan04.SuspendLayout()
        Me.Pan03.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
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
        Me.Dgv01.Location = New System.Drawing.Point(2, 103)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(617, 360)
        Me.Dgv01.TabIndex = 173
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.Black
        Me.Label22.Location = New System.Drawing.Point(2, 81)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(617, 21)
        Me.Label22.TabIndex = 176
        Me.Label22.Text = "Mantenimiento de Sub-Caidas [Artículos]"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnEdi
        '
        Me.BtnEdi.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEdi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEdi.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEdi.Image = CType(resources.GetObject("BtnEdi.Image"), System.Drawing.Image)
        Me.BtnEdi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEdi.Location = New System.Drawing.Point(89, 1)
        Me.BtnEdi.Name = "BtnEdi"
        Me.BtnEdi.Size = New System.Drawing.Size(88, 23)
        Me.BtnEdi.TabIndex = 1
        Me.BtnEdi.Text = "Editar"
        Me.BtnEdi.UseVisualStyleBackColor = False
        '
        'Pan01
        '
        Me.Pan01.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan01.Controls.Add(Me.TxtAnexo)
        Me.Pan01.Controls.Add(Me.TxtCod_Articulo)
        Me.Pan01.Controls.Add(Me.TxtCod)
        Me.Pan01.Controls.Add(Me.TxtScd)
        Me.Pan01.Location = New System.Drawing.Point(2, 102)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(617, 25)
        Me.Pan01.TabIndex = 0
        '
        'TxtAnexo
        '
        Me.TxtAnexo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAnexo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtAnexo.Location = New System.Drawing.Point(426, 1)
        Me.TxtAnexo.MaxLength = 18
        Me.TxtAnexo.Name = "TxtAnexo"
        Me.TxtAnexo.Size = New System.Drawing.Size(110, 21)
        Me.TxtAnexo.TabIndex = 2
        Me.TxtAnexo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCod_Articulo
        '
        Me.TxtCod_Articulo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Articulo.Location = New System.Drawing.Point(537, 1)
        Me.TxtCod_Articulo.MaxLength = 8
        Me.TxtCod_Articulo.Name = "TxtCod_Articulo"
        Me.TxtCod_Articulo.Size = New System.Drawing.Size(69, 21)
        Me.TxtCod_Articulo.TabIndex = 3
        Me.TxtCod_Articulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtCod
        '
        Me.TxtCod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod.Enabled = False
        Me.TxtCod.Location = New System.Drawing.Point(14, 1)
        Me.TxtCod.Name = "TxtCod"
        Me.TxtCod.Size = New System.Drawing.Size(53, 21)
        Me.TxtCod.TabIndex = 0
        Me.TxtCod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtScd
        '
        Me.TxtScd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtScd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtScd.Location = New System.Drawing.Point(68, 1)
        Me.TxtScd.MaxLength = 500
        Me.TxtScd.Name = "TxtScd"
        Me.TxtScd.Size = New System.Drawing.Size(357, 21)
        Me.TxtScd.TabIndex = 1
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(178, 1)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(84, 23)
        Me.BtnEliminar.TabIndex = 2
        Me.BtnEliminar.Text = "Anular"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'lbltg
        '
        Me.lbltg.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltg.ForeColor = System.Drawing.Color.Red
        Me.lbltg.Location = New System.Drawing.Point(393, 27)
        Me.lbltg.Name = "lbltg"
        Me.lbltg.Size = New System.Drawing.Size(218, 14)
        Me.lbltg.TabIndex = 3
        Me.lbltg.Text = "Y su Descripción"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(86, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 14)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Y la Caida"
        '
        'lblcod
        '
        Me.lblcod.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcod.ForeColor = System.Drawing.Color.Red
        Me.lblcod.Location = New System.Drawing.Point(369, 27)
        Me.lblcod.Name = "lblcod"
        Me.lblcod.Size = New System.Drawing.Size(23, 14)
        Me.lblcod.TabIndex = 4
        Me.lblcod.Text = "01"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.lblcod2)
        Me.Panel2.Controls.Add(Me.lblcd)
        Me.Panel2.Controls.Add(Me.Pcb01)
        Me.Panel2.Controls.Add(Me.lblcod)
        Me.Panel2.Controls.Add(Me.lbltg)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(1, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(618, 78)
        Me.Panel2.TabIndex = 177
        '
        'lblcod2
        '
        Me.lblcod2.AutoSize = True
        Me.lblcod2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcod2.ForeColor = System.Drawing.Color.Red
        Me.lblcod2.Location = New System.Drawing.Point(147, 49)
        Me.lblcod2.Name = "lblcod2"
        Me.lblcod2.Size = New System.Drawing.Size(23, 14)
        Me.lblcod2.TabIndex = 163
        Me.lblcod2.Text = "01"
        '
        'lblcd
        '
        Me.lblcd.AutoSize = True
        Me.lblcd.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcd.ForeColor = System.Drawing.Color.Red
        Me.lblcd.Location = New System.Drawing.Point(173, 49)
        Me.lblcd.Name = "lblcd"
        Me.lblcd.Size = New System.Drawing.Size(105, 14)
        Me.lblcd.TabIndex = 162
        Me.lblcd.Text = "Y su Descripción"
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(86, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(277, 14)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Aqui se crean las Sub Caidas para la Tabla General"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(86, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(178, 14)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Tabla Sub Caidas [Artículos]"
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(81, 1)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(81, 23)
        Me.BtnCerrar.TabIndex = 1
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Pan04)
        Me.Panel1.Controls.Add(Me.Pan03)
        Me.Panel1.Location = New System.Drawing.Point(2, 465)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(617, 31)
        Me.Panel1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnArticulos)
        Me.Panel3.Location = New System.Drawing.Point(268, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(88, 27)
        Me.Panel3.TabIndex = 7
        '
        'BtnArticulos
        '
        Me.BtnArticulos.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnArticulos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnArticulos.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnArticulos.Image = CType(resources.GetObject("BtnArticulos.Image"), System.Drawing.Image)
        Me.BtnArticulos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnArticulos.Location = New System.Drawing.Point(1, 1)
        Me.BtnArticulos.Name = "BtnArticulos"
        Me.BtnArticulos.Size = New System.Drawing.Size(84, 23)
        Me.BtnArticulos.TabIndex = 0
        Me.BtnArticulos.Text = "   Ar&tículos"
        Me.BtnArticulos.UseVisualStyleBackColor = False
        '
        'Pan04
        '
        Me.Pan04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan04.Controls.Add(Me.BtnGrabar)
        Me.Pan04.Controls.Add(Me.BtnCerrar)
        Me.Pan04.Location = New System.Drawing.Point(446, 1)
        Me.Pan04.Name = "Pan04"
        Me.Pan04.Size = New System.Drawing.Size(165, 27)
        Me.Pan04.TabIndex = 5
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnGrabar.Enabled = False
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(1, 1)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(79, 23)
        Me.BtnGrabar.TabIndex = 0
        Me.BtnGrabar.Text = "Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'Pan03
        '
        Me.Pan03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan03.Controls.Add(Me.BtnEliminar)
        Me.Pan03.Controls.Add(Me.BtnEdi)
        Me.Pan03.Controls.Add(Me.BtnNuevo)
        Me.Pan03.Location = New System.Drawing.Point(1, 1)
        Me.Pan03.Name = "Pan03"
        Me.Pan03.Size = New System.Drawing.Size(265, 27)
        Me.Pan03.TabIndex = 4
        '
        'BtnNuevo
        '
        Me.BtnNuevo.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnNuevo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNuevo.Image = CType(resources.GetObject("BtnNuevo.Image"), System.Drawing.Image)
        Me.BtnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNuevo.Location = New System.Drawing.Point(1, 1)
        Me.BtnNuevo.Name = "BtnNuevo"
        Me.BtnNuevo.Size = New System.Drawing.Size(87, 23)
        Me.BtnNuevo.TabIndex = 0
        Me.BtnNuevo.Text = "&Agregar"
        Me.BtnNuevo.UseVisualStyleBackColor = False
        '
        'FrmMnSCaidas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 496)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Pan01)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmMnSCaidas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Archivo de Sub-Caídas"
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan01.ResumeLayout(False)
        Me.Pan01.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.Pcb01, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Pan04.ResumeLayout(False)
        Me.Pan03.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents BtnEdi As System.Windows.Forms.Button
    Friend WithEvents Pan01 As System.Windows.Forms.Panel
    Friend WithEvents TxtCod As System.Windows.Forms.TextBox
    Friend WithEvents TxtScd As System.Windows.Forms.TextBox
    Friend WithEvents BtnEliminar As System.Windows.Forms.Button
    Friend WithEvents lbltg As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblcod As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Pcb01 As System.Windows.Forms.PictureBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnNuevo As System.Windows.Forms.Button
    Friend WithEvents lblcod2 As System.Windows.Forms.Label
    Friend WithEvents lblcd As System.Windows.Forms.Label
    Friend WithEvents TxtCod_Articulo As System.Windows.Forms.TextBox
    Friend WithEvents Pan04 As System.Windows.Forms.Panel
    Friend WithEvents Pan03 As System.Windows.Forms.Panel
    Friend WithEvents BtnGrabar As System.Windows.Forms.Button
    Friend WithEvents TxtAnexo As System.Windows.Forms.TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnArticulos As Button
End Class
