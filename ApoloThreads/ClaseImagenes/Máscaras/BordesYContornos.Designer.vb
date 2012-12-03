<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BordesYContornos
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
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RBGrises = New System.Windows.Forms.RadioButton()
        Me.RbRGB = New System.Windows.Forms.RadioButton()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(302, 240)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 30)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Cerrar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(393, 240)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 30)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Aplicar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ListBox1)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(222, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 182)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Seleccione el tipo de máscara"
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.Control
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Items.AddRange(New Object() {"Resta movimiento 1", "Resta movimiento 2", "Resta movimiento 3", "Laplaciano 1", "Laplaciano 2", "Laplaciano 3", "Laplaciano 4", "Laplaciano horizontal", "Laplaciano vertical", "Laplaciano diagonal", "Gradiente este", "Gradiente sudeste ", "Gradiente sur", "Gradiente oeste", "Gradiente noreste", "Gradiente norte", "Embossing este", "Embossing sudeste ", "Embossing sur", "Embossing oeste", "Embossing noreste", "Embossing norte", "Sobel horizontal", "Sobel vertical", "Sobel diagonal 1", "Sobel diagonal 2", "Sobel (1/4) horizontal", "Sobel (1/4) vertical", "Sobel (1/4) diagonal 1", "Sobel (1/4) diagonal 2", "Prewitt horizontal", "Prewitt vertical", "Prewitt diagonal 1", "Prewitt diagonal 2", "Prewitt (1/3) horizontal", "Prewitt (1/3) vertical", "Prewitt (1/3) diagonal 1", "Prewitt (1/3) diagonal 2", "Líneas horizontales", "Líneas verticales", "Repujado", "Kirsch 0º", "Kirsch 45º", "Kirsch 90º", "Kirsch 135º", "Kirsch 180º", "Kirsch 225º", "Kirsch 270º", "Kirsch 315º", "Frei-Chen horizontal", "Frei-Chen vertical"})
        Me.ListBox1.Location = New System.Drawing.Point(6, 25)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(244, 150)
        Me.ListBox1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RBGrises)
        Me.GroupBox1.Controls.Add(Me.RbRGB)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(118, 82)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Aplicar en "
        '
        'RBGrises
        '
        Me.RBGrises.AutoSize = True
        Me.RBGrises.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBGrises.Location = New System.Drawing.Point(6, 54)
        Me.RBGrises.Name = "RBGrises"
        Me.RBGrises.Size = New System.Drawing.Size(56, 19)
        Me.RBGrises.TabIndex = 2
        Me.RBGrises.TabStop = True
        Me.RBGrises.Text = "Grises"
        Me.RBGrises.UseVisualStyleBackColor = True
        '
        'RbRGB
        '
        Me.RbRGB.AutoSize = True
        Me.RbRGB.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbRGB.Location = New System.Drawing.Point(6, 22)
        Me.RbRGB.Name = "RbRGB"
        Me.RbRGB.Size = New System.Drawing.Size(47, 19)
        Me.RbRGB.TabIndex = 1
        Me.RbRGB.TabStop = True
        Me.RbRGB.Text = "RGB"
        Me.RbRGB.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(228, 12)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(243, 23)
        Me.TextBox2.TabIndex = 17
        Me.TextBox2.Text = "Buscador de máscaras"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(12, 118)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(158, 61)
        Me.TextBox1.TabIndex = 18
        '
        'BackgroundWorker1
        '
        '
        'BordesYContornos
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 284)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "BordesYContornos"
        Me.Text = "Máscaras de bordes y contornos"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RBGrises As System.Windows.Forms.RadioButton
    Friend WithEvents RbRGB As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
