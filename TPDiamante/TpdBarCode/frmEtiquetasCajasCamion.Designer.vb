<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEtiquetasCajasCamion
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
  Me.Panel1 = New System.Windows.Forms.Panel()
  Me.cmbRutas = New System.Windows.Forms.ComboBox()
  Me.cmbNombreCliente = New System.Windows.Forms.ComboBox()
  Me.cmbCodigoCliente = New System.Windows.Forms.ComboBox()
  Me.Label9 = New System.Windows.Forms.Label()
  Me.Label6 = New System.Windows.Forms.Label()
  Me.txtCopias = New System.Windows.Forms.TextBox()
  Me.Label5 = New System.Windows.Forms.Label()
  Me.Label3 = New System.Windows.Forms.Label()
  Me.Button1 = New System.Windows.Forms.Button()
  Me.Panel1.SuspendLayout()
  Me.SuspendLayout()
  '
  'Panel1
  '
  Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
  Me.Panel1.Controls.Add(Me.cmbRutas)
  Me.Panel1.Controls.Add(Me.cmbNombreCliente)
  Me.Panel1.Controls.Add(Me.cmbCodigoCliente)
  Me.Panel1.Controls.Add(Me.Label9)
  Me.Panel1.Controls.Add(Me.Label6)
  Me.Panel1.Controls.Add(Me.txtCopias)
  Me.Panel1.Controls.Add(Me.Label5)
  Me.Panel1.Controls.Add(Me.Label3)
  Me.Panel1.Controls.Add(Me.Button1)
  Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
  Me.Panel1.Location = New System.Drawing.Point(0, 0)
  Me.Panel1.Name = "Panel1"
  Me.Panel1.Size = New System.Drawing.Size(637, 143)
  Me.Panel1.TabIndex = 4
  '
  'cmbRutas
  '
  Me.cmbRutas.FormattingEnabled = True
  Me.cmbRutas.Location = New System.Drawing.Point(102, 78)
  Me.cmbRutas.Name = "cmbRutas"
  Me.cmbRutas.Size = New System.Drawing.Size(183, 21)
  Me.cmbRutas.TabIndex = 21
  '
  'cmbNombreCliente
  '
  Me.cmbNombreCliente.FormattingEnabled = True
  Me.cmbNombreCliente.Location = New System.Drawing.Point(102, 43)
  Me.cmbNombreCliente.Name = "cmbNombreCliente"
  Me.cmbNombreCliente.Size = New System.Drawing.Size(521, 21)
  Me.cmbNombreCliente.TabIndex = 20
  '
  'cmbCodigoCliente
  '
  Me.cmbCodigoCliente.FormattingEnabled = True
  Me.cmbCodigoCliente.Location = New System.Drawing.Point(102, 12)
  Me.cmbCodigoCliente.Name = "cmbCodigoCliente"
  Me.cmbCodigoCliente.Size = New System.Drawing.Size(80, 21)
  Me.cmbCodigoCliente.TabIndex = 19
  '
  'Label9
  '
  Me.Label9.Location = New System.Drawing.Point(10, 44)
  Me.Label9.Name = "Label9"
  Me.Label9.Size = New System.Drawing.Size(91, 13)
  Me.Label9.TabIndex = 18
  Me.Label9.Text = "Nombre Cte.:"
  Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
  '
  'Label6
  '
  Me.Label6.Location = New System.Drawing.Point(10, 80)
  Me.Label6.Name = "Label6"
  Me.Label6.Size = New System.Drawing.Size(91, 13)
  Me.Label6.TabIndex = 12
  Me.Label6.Text = "Ruta:"
  Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
  '
  'txtCopias
  '
  Me.txtCopias.Location = New System.Drawing.Point(102, 109)
  Me.txtCopias.Name = "txtCopias"
  Me.txtCopias.Size = New System.Drawing.Size(46, 20)
  Me.txtCopias.TabIndex = 7
  '
  'Label5
  '
  Me.Label5.AutoSize = True
  Me.Label5.Location = New System.Drawing.Point(59, 111)
  Me.Label5.Name = "Label5"
  Me.Label5.Size = New System.Drawing.Size(42, 13)
  Me.Label5.TabIndex = 10
  Me.Label5.Text = "Copias:"
  '
  'Label3
  '
  Me.Label3.Location = New System.Drawing.Point(10, 15)
  Me.Label3.Name = "Label3"
  Me.Label3.Size = New System.Drawing.Size(91, 13)
  Me.Label3.TabIndex = 6
  Me.Label3.Text = "Num. Cliente:"
  Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
  '
  'Button1
  '
  Me.Button1.Location = New System.Drawing.Point(367, 80)
  Me.Button1.Name = "Button1"
  Me.Button1.Size = New System.Drawing.Size(75, 23)
  Me.Button1.TabIndex = 8
  Me.Button1.Text = "Imprimir"
  Me.Button1.UseVisualStyleBackColor = True
  '
  'frmEtiquetasCajasCamion
  '
  Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
  Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
  Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
  Me.ClientSize = New System.Drawing.Size(637, 145)
  Me.Controls.Add(Me.Panel1)
  Me.MaximizeBox = False
  Me.MinimizeBox = False
  Me.Name = "frmEtiquetasCajasCamion"
  Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
  Me.Text = "Etiquetas para Cajas de Camión"
  Me.Panel1.ResumeLayout(False)
  Me.Panel1.PerformLayout()
  Me.ResumeLayout(False)

 End Sub
 Friend WithEvents Panel1 As Panel
 Friend WithEvents Label9 As Label
 Friend WithEvents Label6 As Label
 Friend WithEvents txtCopias As TextBox
 Friend WithEvents Label5 As Label
 Friend WithEvents Label3 As Label
 Friend WithEvents Button1 As Button
    Friend WithEvents cmbCodigoCliente As ComboBox
    Friend WithEvents cmbNombreCliente As ComboBox
    Friend WithEvents cmbRutas As ComboBox
End Class
