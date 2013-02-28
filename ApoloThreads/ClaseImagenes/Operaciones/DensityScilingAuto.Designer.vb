<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DensityScilingAuto
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(174, 237)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 30)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Cerrar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(265, 237)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 30)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Aplicar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(24, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Número de divisiones"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(297, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Label1"
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Location = New System.Drawing.Point(27, 53)
        Me.HScrollBar1.Maximum = 24
        Me.HScrollBar1.Minimum = 2
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(242, 20)
        Me.HScrollBar1.TabIndex = 5
        Me.HScrollBar1.Value = 5
        '
        'BackgroundWorker1
        '
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Items.AddRange(New Object() {"Red", "Green", "Blue", "Black", "White", "Yellow", "Maroon", "Gray", "LightGreen", "LightBlue", "Orange", "Pink", "Gold", "DarkBlue", "DarkGreen"})
        Me.ListBox1.Location = New System.Drawing.Point(18, 90)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(128, 124)
        Me.ListBox1.TabIndex = 10
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(152, 135)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(57, 34)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "<<"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(152, 95)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(57, 34)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = ">>"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(152, 175)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(57, 34)
        Me.Button5.TabIndex = 13
        Me.Button5.Text = "[x]"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ListBox2
        '
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.ItemHeight = 15
        Me.ListBox2.Items.AddRange(New Object() {"Red", "Green", "Blue", "Black", "White"})
        Me.ListBox2.Location = New System.Drawing.Point(215, 90)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(128, 124)
        Me.ListBox2.TabIndex = 14
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(18, 244)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(94, 19)
        Me.CheckBox1.TabIndex = 15
        Me.CheckBox1.Text = "Normalizado"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DensityScilingAuto
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 279)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.ListBox2)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DensityScilingAuto"
        Me.Text = "Density Slicing automático"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
