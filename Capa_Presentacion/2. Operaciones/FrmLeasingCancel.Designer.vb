<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLeasingCancel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLeasingCancel))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtSerie_Credito = New System.Windows.Forms.TextBox()
        Me.TxtNro_Credito = New System.Windows.Forms.TextBox()
        Me.CboVoucher = New System.Windows.Forms.ComboBox()
        Me.TxtSerieVoucher = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtNroCuota = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtProveedor = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtNroMov = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnCerrar = New System.Windows.Forms.Button()
        Me.BtnGrabar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnEliminar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtNroCorrel = New System.Windows.Forms.TextBox()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TxtNroCorrel)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.TxtSerie_Credito)
        Me.Panel4.Controls.Add(Me.TxtNro_Credito)
        Me.Panel4.Controls.Add(Me.CboVoucher)
        Me.Panel4.Controls.Add(Me.TxtSerieVoucher)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.TxtNroCuota)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.TxtProveedor)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.TxtNroMov)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Location = New System.Drawing.Point(2, 35)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(562, 121)
        Me.Panel4.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(349, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 14)
        Me.Label6.TabIndex = 202
        Me.Label6.Text = "Nro.Movimiento"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtSerie_Credito
        '
        Me.TxtSerie_Credito.BackColor = System.Drawing.Color.White
        Me.TxtSerie_Credito.Enabled = False
        Me.TxtSerie_Credito.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerie_Credito.Location = New System.Drawing.Point(100, 4)
        Me.TxtSerie_Credito.MaxLength = 3
        Me.TxtSerie_Credito.Name = "TxtSerie_Credito"
        Me.TxtSerie_Credito.Size = New System.Drawing.Size(40, 21)
        Me.TxtSerie_Credito.TabIndex = 200
        Me.TxtSerie_Credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TxtNro_Credito
        '
        Me.TxtNro_Credito.BackColor = System.Drawing.Color.White
        Me.TxtNro_Credito.Enabled = False
        Me.TxtNro_Credito.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNro_Credito.Location = New System.Drawing.Point(141, 4)
        Me.TxtNro_Credito.MaxLength = 10
        Me.TxtNro_Credito.Name = "TxtNro_Credito"
        Me.TxtNro_Credito.Size = New System.Drawing.Size(101, 21)
        Me.TxtNro_Credito.TabIndex = 201
        Me.TxtNro_Credito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CboVoucher
        '
        Me.CboVoucher.BackColor = System.Drawing.Color.White
        Me.CboVoucher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboVoucher.Enabled = False
        Me.CboVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CboVoucher.FormattingEnabled = True
        Me.CboVoucher.Location = New System.Drawing.Point(154, 79)
        Me.CboVoucher.Name = "CboVoucher"
        Me.CboVoucher.Size = New System.Drawing.Size(102, 21)
        Me.CboVoucher.TabIndex = 199
        '
        'TxtSerieVoucher
        '
        Me.TxtSerieVoucher.BackColor = System.Drawing.Color.White
        Me.TxtSerieVoucher.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtSerieVoucher.Enabled = False
        Me.TxtSerieVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSerieVoucher.Location = New System.Drawing.Point(100, 79)
        Me.TxtSerieVoucher.Name = "TxtSerieVoucher"
        Me.TxtSerieVoucher.Size = New System.Drawing.Size(52, 21)
        Me.TxtSerieVoucher.TabIndex = 198
        Me.TxtSerieVoucher.Text = "002"
        Me.TxtSerieVoucher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(10, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 14)
        Me.Label5.TabIndex = 197
        Me.Label5.Text = "Nro. Voucher"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtNroCuota
        '
        Me.TxtNroCuota.BackColor = System.Drawing.Color.White
        Me.TxtNroCuota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNroCuota.Enabled = False
        Me.TxtNroCuota.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNroCuota.Location = New System.Drawing.Point(100, 53)
        Me.TxtNroCuota.Name = "TxtNroCuota"
        Me.TxtNroCuota.Size = New System.Drawing.Size(92, 21)
        Me.TxtNroCuota.TabIndex = 196
        Me.TxtNroCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(10, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 195
        Me.Label4.Text = "Proveedor"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtProveedor
        '
        Me.TxtProveedor.BackColor = System.Drawing.Color.White
        Me.TxtProveedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtProveedor.Enabled = False
        Me.TxtProveedor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProveedor.Location = New System.Drawing.Point(100, 28)
        Me.TxtProveedor.Name = "TxtProveedor"
        Me.TxtProveedor.Size = New System.Drawing.Size(451, 21)
        Me.TxtProveedor.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(10, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 14)
        Me.Label3.TabIndex = 192
        Me.Label3.Text = "N° Prestamo"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtNroMov
        '
        Me.TxtNroMov.BackColor = System.Drawing.Color.White
        Me.TxtNroMov.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNroMov.Enabled = False
        Me.TxtNroMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNroMov.Location = New System.Drawing.Point(459, 4)
        Me.TxtNroMov.Name = "TxtNroMov"
        Me.TxtNroMov.Size = New System.Drawing.Size(92, 21)
        Me.TxtNroMov.TabIndex = 0
        Me.TxtNroMov.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(10, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 14)
        Me.Label2.TabIndex = 191
        Me.Label2.Text = "Nro. Cuota"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnCerrar)
        Me.Panel3.Controls.Add(Me.BtnGrabar)
        Me.Panel3.Location = New System.Drawing.Point(407, 157)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(157, 30)
        Me.Panel3.TabIndex = 4
        '
        'BtnCerrar
        '
        Me.BtnCerrar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCerrar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCerrar.Image = CType(resources.GetObject("BtnCerrar.Image"), System.Drawing.Image)
        Me.BtnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnCerrar.Location = New System.Drawing.Point(78, 2)
        Me.BtnCerrar.Name = "BtnCerrar"
        Me.BtnCerrar.Size = New System.Drawing.Size(75, 24)
        Me.BtnCerrar.TabIndex = 1
        Me.BtnCerrar.Text = "&Cerrar"
        Me.BtnCerrar.UseVisualStyleBackColor = False
        '
        'BtnGrabar
        '
        Me.BtnGrabar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnGrabar.Enabled = False
        Me.BtnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnGrabar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGrabar.Image = CType(resources.GetObject("BtnGrabar.Image"), System.Drawing.Image)
        Me.BtnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGrabar.Location = New System.Drawing.Point(2, 2)
        Me.BtnGrabar.Name = "BtnGrabar"
        Me.BtnGrabar.Size = New System.Drawing.Size(75, 24)
        Me.BtnGrabar.TabIndex = 0
        Me.BtnGrabar.Text = "  &Grabar"
        Me.BtnGrabar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BtnEliminar)
        Me.Panel1.Location = New System.Drawing.Point(2, 157)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(157, 30)
        Me.Panel1.TabIndex = 9
        '
        'BtnEliminar
        '
        Me.BtnEliminar.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.BtnEliminar.Enabled = False
        Me.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnEliminar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEliminar.Image = CType(resources.GetObject("BtnEliminar.Image"), System.Drawing.Image)
        Me.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnEliminar.Location = New System.Drawing.Point(2, 2)
        Me.BtnEliminar.Name = "BtnEliminar"
        Me.BtnEliminar.Size = New System.Drawing.Size(150, 24)
        Me.BtnEliminar.TabIndex = 0
        Me.BtnEliminar.Text = "&Eliminar Pago"
        Me.BtnEliminar.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(562, 32)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Cancelacion de Cuotas"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtNroCorrel
        '
        Me.TxtNroCorrel.BackColor = System.Drawing.Color.White
        Me.TxtNroCorrel.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TxtNroCorrel.Enabled = False
        Me.TxtNroCorrel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNroCorrel.Location = New System.Drawing.Point(459, 55)
        Me.TxtNroCorrel.Name = "TxtNroCorrel"
        Me.TxtNroCorrel.Size = New System.Drawing.Size(92, 21)
        Me.TxtNroCorrel.TabIndex = 203
        Me.TxtNroCorrel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmLeasingCancel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 190)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmLeasingCancel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cancelacion de Leasing"
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents TxtSerieVoucher As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtNroCuota As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtProveedor As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtNroMov As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents BtnCerrar As Button
    Friend WithEvents BtnGrabar As Button
    Friend WithEvents CboVoucher As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnEliminar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtSerie_Credito As TextBox
    Friend WithEvents TxtNro_Credito As TextBox
    Friend WithEvents TxtNroCorrel As TextBox
End Class
