﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidaAcceso
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValidaAcceso))
    Me.btnAceptar = New System.Windows.Forms.Button()
    Me.btnCancelar = New System.Windows.Forms.Button()
    Me.txtClave = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'btnAceptar
    '
    Me.btnAceptar.Location = New System.Drawing.Point(146, 83)
    Me.btnAceptar.Name = "btnAceptar"
    Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
    Me.btnAceptar.TabIndex = 7
    Me.btnAceptar.Text = "Aceptar"
    Me.btnAceptar.UseVisualStyleBackColor = True
    '
    'btnCancelar
    '
    Me.btnCancelar.Location = New System.Drawing.Point(244, 83)
    Me.btnCancelar.Name = "btnCancelar"
    Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
    Me.btnCancelar.TabIndex = 6
    Me.btnCancelar.Text = "Cancelar"
    Me.btnCancelar.UseVisualStyleBackColor = True
    '
    'txtClave
    '
    Me.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
    Me.txtClave.Location = New System.Drawing.Point(176, 42)
    Me.txtClave.MaxLength = 8
    Me.txtClave.Name = "txtClave"
    Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
    Me.txtClave.Size = New System.Drawing.Size(143, 20)
    Me.txtClave.TabIndex = 5
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(46, 43)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(113, 16)
    Me.Label1.TabIndex = 4
    Me.Label1.Text = "Clave de acceso:"
    '
    'frmValidaAcceso
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(364, 139)
    Me.ControlBox = False
    Me.Controls.Add(Me.btnAceptar)
    Me.Controls.Add(Me.btnCancelar)
    Me.Controls.Add(Me.txtClave)
    Me.Controls.Add(Me.Label1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.Name = "frmValidaAcceso"
    Me.Text = "Validación de usuario"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub

  Friend WithEvents btnAceptar As Button
  Friend WithEvents btnCancelar As Button
  Friend WithEvents txtClave As TextBox
  Friend WithEvents Label1 As Label
End Class
