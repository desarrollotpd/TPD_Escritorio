<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ObtenerOrdenVenta
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
        Me.components = New System.ComponentModel.Container()
        Me.panelOV = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.txtSerie = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnCancelarOV = New System.Windows.Forms.Button()
        Me.btnPrintOV = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvNuevaOV = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.panelOV.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvNuevaOV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelOV
        '
        Me.panelOV.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.panelOV.Controls.Add(Me.Label1)
        Me.panelOV.Controls.Add(Me.DataGridView1)
        Me.panelOV.Controls.Add(Me.txtFolio)
        Me.panelOV.Controls.Add(Me.txtSerie)
        Me.panelOV.Controls.Add(Me.Label9)
        Me.panelOV.Controls.Add(Me.Label8)
        Me.panelOV.Controls.Add(Me.btnCancelarOV)
        Me.panelOV.Controls.Add(Me.btnPrintOV)
        Me.panelOV.Controls.Add(Me.Label7)
        Me.panelOV.Controls.Add(Me.Label6)
        Me.panelOV.Controls.Add(Me.dgvNuevaOV)
        Me.panelOV.Controls.Add(Me.Label5)
        Me.panelOV.Location = New System.Drawing.Point(7, 13)
        Me.panelOV.Name = "panelOV"
        Me.panelOV.Size = New System.Drawing.Size(762, 561)
        Me.panelOV.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(417, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Telemarketing:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Default
        Me.DataGridView1.Location = New System.Drawing.Point(514, 84)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(233, 93)
        Me.DataGridView1.TabIndex = 11
        Me.DataGridView1.VirtualMode = True
        '
        'txtFolio
        '
        Me.txtFolio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.Location = New System.Drawing.Point(142, 517)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(45, 20)
        Me.txtFolio.TabIndex = 10
        Me.txtFolio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSerie
        '
        Me.txtSerie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerie.Location = New System.Drawing.Point(53, 517)
        Me.txtSerie.Name = "txtSerie"
        Me.txtSerie.Size = New System.Drawing.Size(30, 20)
        Me.txtSerie.TabIndex = 9
        Me.txtSerie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(113, 520)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Folio"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 520)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(31, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Serie"
        '
        'btnCancelarOV
        '
        Me.btnCancelarOV.Location = New System.Drawing.Point(596, 511)
        Me.btnCancelarOV.Name = "btnCancelarOV"
        Me.btnCancelarOV.Size = New System.Drawing.Size(151, 31)
        Me.btnCancelarOV.TabIndex = 6
        Me.btnCancelarOV.Text = "Salir de Ordenes de Venta"
        Me.btnCancelarOV.UseVisualStyleBackColor = True
        '
        'btnPrintOV
        '
        Me.btnPrintOV.Location = New System.Drawing.Point(420, 511)
        Me.btnPrintOV.Name = "btnPrintOV"
        Me.btnPrintOV.Size = New System.Drawing.Size(151, 31)
        Me.btnPrintOV.TabIndex = 5
        Me.btnPrintOV.Text = "Imprimir Orden de venta"
        Me.btnPrintOV.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 490)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 20)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "PASADA"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(27, 157)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 20)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "NUEVAS"
        '
        'dgvNuevaOV
        '
        Me.dgvNuevaOV.AllowUserToResizeColumns = False
        Me.dgvNuevaOV.AllowUserToResizeRows = False
        Me.dgvNuevaOV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvNuevaOV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvNuevaOV.Location = New System.Drawing.Point(17, 183)
        Me.dgvNuevaOV.Name = "dgvNuevaOV"
        Me.dgvNuevaOV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvNuevaOV.Size = New System.Drawing.Size(730, 304)
        Me.dgvNuevaOV.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(90, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(542, 32)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "ORDENES DE VENTA"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10000
        '
        'ObtenerOrdenVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.ClientSize = New System.Drawing.Size(781, 586)
        Me.ControlBox = False
        Me.Controls.Add(Me.panelOV)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ObtenerOrdenVenta"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevas ordenes de venta"
        Me.panelOV.ResumeLayout(False)
        Me.panelOV.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvNuevaOV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelOV As Panel
 Friend WithEvents txtFolio As TextBox
 Friend WithEvents txtSerie As TextBox
 Friend WithEvents Label9 As Label
 Friend WithEvents Label8 As Label
 Friend WithEvents btnCancelarOV As Button
 Friend WithEvents btnPrintOV As Button
 Friend WithEvents Label7 As Label
 Friend WithEvents Label6 As Label
 Friend WithEvents dgvNuevaOV As DataGridView
 Friend WithEvents Label5 As Label
 Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
End Class
