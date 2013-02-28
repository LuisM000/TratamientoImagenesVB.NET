<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DensityScilingManual
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
        Me.numericDivision = New System.Windows.Forms.NumericUpDown()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAnadir = New System.Windows.Forms.Button()
        Me.btnColor = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumerFin = New System.Windows.Forms.NumericUpDown()
        Me.NumerInicio = New System.Windows.Forms.NumericUpDown()
        Me.lbltramo = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.numericDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.NumerFin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumerInicio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(207, 211)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 30)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Cerrar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(298, 211)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 30)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Aplicar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Número de divisiones"
        '
        'numericDivision
        '
        Me.numericDivision.Location = New System.Drawing.Point(140, 24)
        Me.numericDivision.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.numericDivision.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numericDivision.Name = "numericDivision"
        Me.numericDivision.Size = New System.Drawing.Size(43, 23)
        Me.numericDivision.TabIndex = 13
        Me.numericDivision.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(194, 24)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(40, 23)
        Me.btnOK.TabIndex = 14
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAnadir)
        Me.Panel1.Controls.Add(Me.btnColor)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.NumerFin)
        Me.Panel1.Controls.Add(Me.NumerInicio)
        Me.Panel1.Controls.Add(Me.lbltramo)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(5, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(382, 151)
        Me.Panel1.TabIndex = 17
        '
        'btnAnadir
        '
        Me.btnAnadir.Location = New System.Drawing.Point(298, 9)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(54, 23)
        Me.btnAnadir.TabIndex = 31
        Me.btnAnadir.Text = "Añadir"
        Me.btnAnadir.UseVisualStyleBackColor = True
        '
        'btnColor
        '
        Me.btnColor.Location = New System.Drawing.Point(228, 9)
        Me.btnColor.Name = "btnColor"
        Me.btnColor.Size = New System.Drawing.Size(54, 23)
        Me.btnColor.TabIndex = 30
        Me.btnColor.Text = "Color"
        Me.btnColor.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(157, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 15)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "a"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(81, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 15)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "De"
        '
        'NumerFin
        '
        Me.NumerFin.Location = New System.Drawing.Point(179, 7)
        Me.NumerFin.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NumerFin.Name = "NumerFin"
        Me.NumerFin.Size = New System.Drawing.Size(43, 23)
        Me.NumerFin.TabIndex = 27
        '
        'NumerInicio
        '
        Me.NumerInicio.Location = New System.Drawing.Point(108, 7)
        Me.NumerInicio.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NumerInicio.Name = "NumerInicio"
        Me.NumerInicio.Size = New System.Drawing.Size(43, 23)
        Me.NumerInicio.TabIndex = 26
        '
        'lbltramo
        '
        Me.lbltramo.AutoSize = True
        Me.lbltramo.Location = New System.Drawing.Point(15, 9)
        Me.lbltramo.Name = "lbltramo"
        Me.lbltramo.Size = New System.Drawing.Size(45, 15)
        Me.lbltramo.TabIndex = 25
        Me.lbltramo.Text = "Tramo "
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(18, 42)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(350, 101)
        Me.TextBox1.TabIndex = 24
        '
        'BackgroundWorker1
        '
        '
        'DensityScilingManual
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(395, 253)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.numericDivision)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DensityScilingManual"
        Me.Text = "Density Slicing manual"
        CType(Me.numericDivision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NumerFin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumerInicio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numericDivision As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAnadir As System.Windows.Forms.Button
    Friend WithEvents btnColor As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NumerFin As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumerInicio As System.Windows.Forms.NumericUpDown
    Friend WithEvents lbltramo As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
