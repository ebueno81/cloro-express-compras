<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConArtListar
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConArtListar))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.TxtCod_Scd = New System.Windows.Forms.TextBox()
        Me.TxtCod_Cd = New System.Windows.Forms.TextBox()
        Me.TxtTg = New System.Windows.Forms.TextBox()
        Me.Dgv02 = New System.Windows.Forms.DataGridView()
        Me.TxtCod_Tg = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.Pan03 = New System.Windows.Forms.Panel()
        Me.BtnExcel = New System.Windows.Forms.Button()
        Me.BtnBus = New System.Windows.Forms.Button()
        Me.BtnReporte = New System.Windows.Forms.Button()
        Me.CboOrden = New System.Windows.Forms.ComboBox()
        Me.BtnCon3 = New System.Windows.Forms.Button()
        Me.BtnCon2 = New System.Windows.Forms.Button()
        Me.BtnTitulo = New System.Windows.Forms.Button()
        Me.BtnCon1 = New System.Windows.Forms.Button()
        Me.Pan04 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtCd = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtScd = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Pan03.SuspendLayout()
        Me.Pan04.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Teal
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(492, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(303, 20)
        Me.Label3.TabIndex = 188
        Me.Label3.Text = "Ordenado"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv01.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(2, 121)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.Dgv01.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowTemplate.Height = 20
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(800, 346)
        Me.Dgv01.TabIndex = 197
        '
        'TxtCod_Scd
        '
        Me.TxtCod_Scd.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCod_Scd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Scd.Enabled = False
        Me.TxtCod_Scd.Location = New System.Drawing.Point(84, 70)
        Me.TxtCod_Scd.Name = "TxtCod_Scd"
        Me.TxtCod_Scd.Size = New System.Drawing.Size(64, 21)
        Me.TxtCod_Scd.TabIndex = 5
        '
        'TxtCod_Cd
        '
        Me.TxtCod_Cd.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCod_Cd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Cd.Enabled = False
        Me.TxtCod_Cd.Location = New System.Drawing.Point(84, 47)
        Me.TxtCod_Cd.Name = "TxtCod_Cd"
        Me.TxtCod_Cd.Size = New System.Drawing.Size(64, 21)
        Me.TxtCod_Cd.TabIndex = 3
        '
        'TxtTg
        '
        Me.TxtTg.BackColor = System.Drawing.Color.White
        Me.TxtTg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtTg.Enabled = False
        Me.TxtTg.Location = New System.Drawing.Point(149, 24)
        Me.TxtTg.Name = "TxtTg"
        Me.TxtTg.Size = New System.Drawing.Size(317, 21)
        Me.TxtTg.TabIndex = 0
        '
        'Dgv02
        '
        Me.Dgv02.AllowUserToAddRows = False
        Me.Dgv02.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv02.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Blue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv02.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.Dgv02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Dgv02.EnableHeadersVisualStyles = False
        Me.Dgv02.Location = New System.Drawing.Point(2, 468)
        Me.Dgv02.Name = "Dgv02"
        Me.Dgv02.ReadOnly = True
        Me.Dgv02.RowHeadersWidth = 15
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv02.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.Dgv02.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv02.Size = New System.Drawing.Size(800, 30)
        Me.Dgv02.TabIndex = 198
        '
        'TxtCod_Tg
        '
        Me.TxtCod_Tg.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.TxtCod_Tg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCod_Tg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCod_Tg.Enabled = False
        Me.TxtCod_Tg.Location = New System.Drawing.Point(84, 24)
        Me.TxtCod_Tg.Name = "TxtCod_Tg"
        Me.TxtCod_Tg.Size = New System.Drawing.Size(64, 21)
        Me.TxtCod_Tg.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 21)
        Me.Label1.TabIndex = 180
        Me.Label1.Text = "Tabla Gral."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnCerrar.Location = New System.Drawing.Point(226, 1)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(74, 44)
        Me.BtnCerrar.TabIndex = 7
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'Pan03
        '
        Me.Pan03.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan03.Controls.Add(Me.BtnCerrar)
        Me.Pan03.Controls.Add(Me.BtnExcel)
        Me.Pan03.Controls.Add(Me.BtnBus)
        Me.Pan03.Controls.Add(Me.BtnReporte)
        Me.Pan03.Location = New System.Drawing.Point(492, 45)
        Me.Pan03.Name = "Pan03"
        Me.Pan03.Size = New System.Drawing.Size(303, 48)
        Me.Pan03.TabIndex = 4
        '
        'BtnExcel
        '
        Me.BtnExcel.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExcel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExcel.Image = CType(resources.GetObject("BtnExcel.Image"), System.Drawing.Image)
        Me.BtnExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnExcel.Location = New System.Drawing.Point(151, 1)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(74, 44)
        Me.BtnExcel.TabIndex = 6
        Me.BtnExcel.Text = "&Excel"
        Me.BtnExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnExcel.UseVisualStyleBackColor = False
        '
        'BtnBus
        '
        Me.BtnBus.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnBus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnBus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBus.Image = CType(resources.GetObject("BtnBus.Image"), System.Drawing.Image)
        Me.BtnBus.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnBus.Location = New System.Drawing.Point(1, 1)
        Me.BtnBus.Name = "BtnBus"
        Me.BtnBus.Size = New System.Drawing.Size(74, 44)
        Me.BtnBus.TabIndex = 4
        Me.BtnBus.Text = "&Buscar"
        Me.BtnBus.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnBus.UseVisualStyleBackColor = False
        '
        'BtnReporte
        '
        Me.BtnReporte.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnReporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReporte.Image = CType(resources.GetObject("BtnReporte.Image"), System.Drawing.Image)
        Me.BtnReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnReporte.Location = New System.Drawing.Point(76, 1)
        Me.BtnReporte.Name = "BtnReporte"
        Me.BtnReporte.Size = New System.Drawing.Size(74, 44)
        Me.BtnReporte.TabIndex = 5
        Me.BtnReporte.Text = "&Reporte"
        Me.BtnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnReporte.UseVisualStyleBackColor = False
        '
        'CboOrden
        '
        Me.CboOrden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboOrden.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboOrden.FormattingEnabled = True
        Me.CboOrden.Items.AddRange(New Object() {"Descripción"})
        Me.CboOrden.Location = New System.Drawing.Point(492, 23)
        Me.CboOrden.Name = "CboOrden"
        Me.CboOrden.Size = New System.Drawing.Size(302, 21)
        Me.CboOrden.TabIndex = 3
        '
        'BtnCon3
        '
        Me.BtnCon3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCon3.Image = CType(resources.GetObject("BtnCon3.Image"), System.Drawing.Image)
        Me.BtnCon3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon3.Location = New System.Drawing.Point(466, 24)
        Me.BtnCon3.Name = "BtnCon3"
        Me.BtnCon3.Size = New System.Drawing.Size(25, 21)
        Me.BtnCon3.TabIndex = 0
        Me.BtnCon3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon3.UseVisualStyleBackColor = True
        '
        'BtnCon2
        '
        Me.BtnCon2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCon2.Image = CType(resources.GetObject("BtnCon2.Image"), System.Drawing.Image)
        Me.BtnCon2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon2.Location = New System.Drawing.Point(466, 47)
        Me.BtnCon2.Name = "BtnCon2"
        Me.BtnCon2.Size = New System.Drawing.Size(25, 21)
        Me.BtnCon2.TabIndex = 1
        Me.BtnCon2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon2.UseVisualStyleBackColor = True
        '
        'BtnTitulo
        '
        Me.BtnTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.BtnTitulo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnTitulo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTitulo.ForeColor = System.Drawing.Color.White
        Me.BtnTitulo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnTitulo.Location = New System.Drawing.Point(2, 1)
        Me.BtnTitulo.Name = "BtnTitulo"
        Me.BtnTitulo.Size = New System.Drawing.Size(799, 22)
        Me.BtnTitulo.TabIndex = 199
        Me.BtnTitulo.Text = "Listado de Sub-Caídas"
        Me.BtnTitulo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnTitulo.UseVisualStyleBackColor = False
        '
        'BtnCon1
        '
        Me.BtnCon1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCon1.Image = CType(resources.GetObject("BtnCon1.Image"), System.Drawing.Image)
        Me.BtnCon1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon1.Location = New System.Drawing.Point(466, 70)
        Me.BtnCon1.Name = "BtnCon1"
        Me.BtnCon1.Size = New System.Drawing.Size(25, 21)
        Me.BtnCon1.TabIndex = 2
        Me.BtnCon1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCon1.UseVisualStyleBackColor = True
        '
        'Pan04
        '
        Me.Pan04.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Pan04.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Pan04.Controls.Add(Me.Label4)
        Me.Pan04.Controls.Add(Me.TxtCd)
        Me.Pan04.Controls.Add(Me.Label2)
        Me.Pan04.Controls.Add(Me.Pan03)
        Me.Pan04.Controls.Add(Me.CboOrden)
        Me.Pan04.Controls.Add(Me.Label3)
        Me.Pan04.Controls.Add(Me.TxtCod_Scd)
        Me.Pan04.Controls.Add(Me.TxtCod_Cd)
        Me.Pan04.Controls.Add(Me.BtnCon3)
        Me.Pan04.Controls.Add(Me.TxtTg)
        Me.Pan04.Controls.Add(Me.TxtCod_Tg)
        Me.Pan04.Controls.Add(Me.Label1)
        Me.Pan04.Controls.Add(Me.BtnCon2)
        Me.Pan04.Controls.Add(Me.BtnCon1)
        Me.Pan04.Controls.Add(Me.TxtScd)
        Me.Pan04.Controls.Add(Me.Label15)
        Me.Pan04.Location = New System.Drawing.Point(2, 24)
        Me.Pan04.Name = "Pan04"
        Me.Pan04.Size = New System.Drawing.Size(799, 96)
        Me.Pan04.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 21)
        Me.Label4.TabIndex = 194
        Me.Label4.Text = "Artículo"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtCd
        '
        Me.TxtCd.BackColor = System.Drawing.Color.White
        Me.TxtCd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtCd.Enabled = False
        Me.TxtCd.Location = New System.Drawing.Point(149, 47)
        Me.TxtCd.Name = "TxtCd"
        Me.TxtCd.Size = New System.Drawing.Size(317, 21)
        Me.TxtCd.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 21)
        Me.Label2.TabIndex = 192
        Me.Label2.Text = "Caidas"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtScd
        '
        Me.TxtScd.BackColor = System.Drawing.Color.White
        Me.TxtScd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtScd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtScd.Enabled = False
        Me.TxtScd.Location = New System.Drawing.Point(149, 70)
        Me.TxtScd.Name = "TxtScd"
        Me.TxtScd.Size = New System.Drawing.Size(317, 21)
        Me.TxtScd.TabIndex = 2
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Teal
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(3, 2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(489, 21)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Artículo"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmConArtListar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(803, 499)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Dgv02)
        Me.Controls.Add(Me.BtnTitulo)
        Me.Controls.Add(Me.Pan04)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmConArtListar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Listado de Sub-Caídas"
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Pan03.ResumeLayout(False)
        Me.Pan04.ResumeLayout(False)
        Me.Pan04.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Dgv01 As System.Windows.Forms.DataGridView
    Friend WithEvents TxtCod_Scd As System.Windows.Forms.TextBox
    Friend WithEvents TxtCod_Cd As System.Windows.Forms.TextBox
    Friend WithEvents TxtTg As System.Windows.Forms.TextBox
    Friend WithEvents Dgv02 As System.Windows.Forms.DataGridView
    Friend WithEvents TxtCod_Tg As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnCerrar As System.Windows.Forms.Button
    Friend WithEvents Pan03 As System.Windows.Forms.Panel
    Friend WithEvents BtnExcel As System.Windows.Forms.Button
    Friend WithEvents BtnBus As System.Windows.Forms.Button
    Friend WithEvents BtnReporte As System.Windows.Forms.Button
    Friend WithEvents CboOrden As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCon3 As System.Windows.Forms.Button
    Friend WithEvents BtnCon2 As System.Windows.Forms.Button
    Friend WithEvents BtnTitulo As System.Windows.Forms.Button
    Friend WithEvents BtnCon1 As System.Windows.Forms.Button
    Friend WithEvents Pan04 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtCd As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtScd As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
