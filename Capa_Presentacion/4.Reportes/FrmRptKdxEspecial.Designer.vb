<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptKdxEspecial
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRptKdxEspecial))
        Me.Pan01 = New System.Windows.Forms.Panel()
        Me.lblAlmacen = New System.Windows.Forms.Label()
        Me.lblFechaIni = New System.Windows.Forms.Label()
        Me.lblArticulo = New System.Windows.Forms.Label()
        Me.lblFechaFin = New System.Windows.Forms.Label()
        Me.Dgv01 = New System.Windows.Forms.DataGridView()
        Me.Dgv02 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ingreso_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Salida_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe_2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Saldo_1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Importe_3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Precio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BtnVista = New System.Windows.Forms.Button()
        Me.Pan01.SuspendLayout()
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgv02, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pan01
        '
        Me.Pan01.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Pan01.BackColor = System.Drawing.Color.White
        Me.Pan01.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Pan01.Controls.Add(Me.BtnVista)
        Me.Pan01.Controls.Add(Me.lblAlmacen)
        Me.Pan01.Controls.Add(Me.lblFechaIni)
        Me.Pan01.Controls.Add(Me.lblArticulo)
        Me.Pan01.Controls.Add(Me.lblFechaFin)
        Me.Pan01.Location = New System.Drawing.Point(1, 2)
        Me.Pan01.Name = "Pan01"
        Me.Pan01.Size = New System.Drawing.Size(943, 41)
        Me.Pan01.TabIndex = 231
        '
        'lblAlmacen
        '
        Me.lblAlmacen.BackColor = System.Drawing.Color.Transparent
        Me.lblAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAlmacen.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblAlmacen.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblAlmacen.Location = New System.Drawing.Point(714, 6)
        Me.lblAlmacen.Name = "lblAlmacen"
        Me.lblAlmacen.Size = New System.Drawing.Size(158, 22)
        Me.lblAlmacen.TabIndex = 182
        Me.lblAlmacen.Text = "Almacén"
        Me.lblAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFechaIni
        '
        Me.lblFechaIni.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaIni.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFechaIni.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaIni.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblFechaIni.Location = New System.Drawing.Point(7, 6)
        Me.lblFechaIni.Name = "lblFechaIni"
        Me.lblFechaIni.Size = New System.Drawing.Size(99, 22)
        Me.lblFechaIni.TabIndex = 166
        Me.lblFechaIni.Text = "Del"
        Me.lblFechaIni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblArticulo
        '
        Me.lblArticulo.BackColor = System.Drawing.Color.Transparent
        Me.lblArticulo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblArticulo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblArticulo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblArticulo.Location = New System.Drawing.Point(205, 6)
        Me.lblArticulo.Name = "lblArticulo"
        Me.lblArticulo.Size = New System.Drawing.Size(506, 22)
        Me.lblArticulo.TabIndex = 163
        Me.lblArticulo.Text = "Artículo"
        Me.lblArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFechaFin
        '
        Me.lblFechaFin.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaFin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFechaFin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaFin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblFechaFin.Location = New System.Drawing.Point(106, 6)
        Me.lblFechaFin.Name = "lblFechaFin"
        Me.lblFechaFin.Size = New System.Drawing.Size(99, 22)
        Me.lblFechaFin.TabIndex = 33
        Me.lblFechaFin.Text = "Al"
        Me.lblFechaFin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Dgv01
        '
        Me.Dgv01.AllowUserToAddRows = False
        Me.Dgv01.AllowUserToDeleteRows = False
        Me.Dgv01.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv01.BackgroundColor = System.Drawing.Color.White
        Me.Dgv01.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv01.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dgv01.ColumnHeadersHeight = 19
        Me.Dgv01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv01.EnableHeadersVisualStyles = False
        Me.Dgv01.Location = New System.Drawing.Point(2, 45)
        Me.Dgv01.Name = "Dgv01"
        Me.Dgv01.ReadOnly = True
        Me.Dgv01.RowHeadersWidth = 15
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dgv01.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.Dgv01.RowTemplate.Height = 18
        Me.Dgv01.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Dgv01.Size = New System.Drawing.Size(942, 330)
        Me.Dgv01.TabIndex = 232
        '
        'Dgv02
        '
        Me.Dgv02.AllowUserToAddRows = False
        Me.Dgv02.AllowUserToDeleteRows = False
        Me.Dgv02.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Dgv02.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.SlateGray
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dgv02.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.Dgv02.ColumnHeadersHeight = 19
        Me.Dgv02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.Dgv02.ColumnHeadersVisible = False
        Me.Dgv02.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Ingreso_1, Me.Importe_1, Me.Salida_1, Me.Importe_2, Me.Saldo_1, Me.Importe_3, Me.Precio})
        Me.Dgv02.EnableHeadersVisualStyles = False
        Me.Dgv02.Location = New System.Drawing.Point(2, 377)
        Me.Dgv02.Name = "Dgv02"
        Me.Dgv02.ReadOnly = True
        Me.Dgv02.RowHeadersWidth = 15
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        Me.Dgv02.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.Dgv02.RowTemplate.Height = 18
        Me.Dgv02.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.Dgv02.Size = New System.Drawing.Size(941, 23)
        Me.Dgv02.TabIndex = 237
        '
        'Column1
        '
        Me.Column1.HeaderText = "Fecha"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 70
        '
        'Column2
        '
        Me.Column2.HeaderText = "Guia"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 80
        '
        'Column3
        '
        Me.Column3.HeaderText = "Proveedor"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 140
        '
        'Column4
        '
        Me.Column4.HeaderText = "Salida"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 55
        '
        'Column5
        '
        Me.Column5.HeaderText = "Motivo"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        Me.Column5.Width = 90
        '
        'Ingreso_1
        '
        Me.Ingreso_1.HeaderText = "Ingreso"
        Me.Ingreso_1.Name = "Ingreso_1"
        Me.Ingreso_1.ReadOnly = True
        Me.Ingreso_1.Width = 65
        '
        'Importe_1
        '
        Me.Importe_1.HeaderText = "Importe"
        Me.Importe_1.Name = "Importe_1"
        Me.Importe_1.ReadOnly = True
        Me.Importe_1.Width = 60
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
        Me.Importe_2.HeaderText = "Importe"
        Me.Importe_2.Name = "Importe_2"
        Me.Importe_2.ReadOnly = True
        Me.Importe_2.Width = 60
        '
        'Saldo_1
        '
        Me.Saldo_1.HeaderText = "Saldo"
        Me.Saldo_1.Name = "Saldo_1"
        Me.Saldo_1.ReadOnly = True
        Me.Saldo_1.Width = 75
        '
        'Importe_3
        '
        Me.Importe_3.HeaderText = "Importe"
        Me.Importe_3.Name = "Importe_3"
        Me.Importe_3.ReadOnly = True
        Me.Importe_3.Width = 75
        '
        'Precio
        '
        Me.Precio.HeaderText = "Precio"
        Me.Precio.Name = "Precio"
        Me.Precio.ReadOnly = True
        Me.Precio.Width = 60
        '
        'BtnVista
        '
        Me.BtnVista.BackColor = System.Drawing.Color.White
        Me.BtnVista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnVista.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVista.Image = CType(resources.GetObject("BtnVista.Image"), System.Drawing.Image)
        Me.BtnVista.Location = New System.Drawing.Point(878, 4)
        Me.BtnVista.Name = "BtnVista"
        Me.BtnVista.Size = New System.Drawing.Size(35, 30)
        Me.BtnVista.TabIndex = 183
        Me.BtnVista.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnVista.UseVisualStyleBackColor = False
        '
        'FrmRptKdxEspecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(945, 403)
        Me.Controls.Add(Me.Dgv02)
        Me.Controls.Add(Me.Dgv01)
        Me.Controls.Add(Me.Pan01)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRptKdxEspecial"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Kardex Especial"
        Me.Pan01.ResumeLayout(False)
        CType(Me.Dgv01, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgv02, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Pan01 As Panel
    Friend WithEvents lblAlmacen As Label
    Friend WithEvents lblFechaIni As Label
    Friend WithEvents lblArticulo As Label
    Friend WithEvents lblFechaFin As Label
    Friend WithEvents Dgv01 As DataGridView
    Friend WithEvents Dgv02 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Ingreso_1 As DataGridViewTextBoxColumn
    Friend WithEvents Importe_1 As DataGridViewTextBoxColumn
    Friend WithEvents Salida_1 As DataGridViewTextBoxColumn
    Friend WithEvents Importe_2 As DataGridViewTextBoxColumn
    Friend WithEvents Saldo_1 As DataGridViewTextBoxColumn
    Friend WithEvents Importe_3 As DataGridViewTextBoxColumn
    Friend WithEvents Precio As DataGridViewTextBoxColumn
    Friend WithEvents BtnVista As Button
End Class
