<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OperadoresMorfologicos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OperadoresMorfologicos))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.txtalto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtancho = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.HScrollBar1 = New System.Windows.Forms.HScrollBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.HScrollBar2 = New System.Windows.Forms.HScrollBar()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 66)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 35)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Dilatación"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 105)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(144, 35)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Erosión"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 144)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(144, 35)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Apertura"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(12, 183)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(144, 35)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Cerradura"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(12, 222)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(144, 35)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Perímetro (Dilat - Eros)"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(12, 261)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(144, 35)
        Me.Button6.TabIndex = 6
        Me.Button6.Text = "Perímetro (Orig - Eros)"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(12, 300)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(144, 35)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = "Perímetro (Dilat - Orig)"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(12, 339)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(144, 35)
        Me.Button8.TabIndex = 8
        Me.Button8.Text = "Top Hat"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(12, 378)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(144, 35)
        Me.Button9.TabIndex = 9
        Me.Button9.Text = "Bottom Hat"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Button15)
        Me.GroupBox1.Controls.Add(Me.Button10)
        Me.GroupBox1.Controls.Add(Me.txtalto)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtancho)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(191, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(678, 206)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Elemento estructural"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.ClaseImagenes.My.Resources.Resources.help
        Me.PictureBox1.Location = New System.Drawing.Point(279, 164)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 37
        Me.PictureBox1.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox1, resources.GetString("PictureBox1.ToolTip"))
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(363, 151)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(289, 43)
        Me.Button15.TabIndex = 36
        Me.Button15.TabStop = False
        Me.Button15.Text = "Importar/exportar elemento estructural"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(242, 161)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(31, 22)
        Me.Button10.TabIndex = 24
        Me.Button10.Text = "OK"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'txtalto
        '
        Me.txtalto.Location = New System.Drawing.Point(207, 162)
        Me.txtalto.Multiline = True
        Me.txtalto.Name = "txtalto"
        Me.txtalto.Size = New System.Drawing.Size(29, 20)
        Me.txtalto.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(189, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "x"
        '
        'txtancho
        '
        Me.txtancho.Location = New System.Drawing.Point(154, 162)
        Me.txtancho.Multiline = True
        Me.txtancho.Name = "txtancho"
        Me.txtancho.Size = New System.Drawing.Size(29, 20)
        Me.txtancho.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 165)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Cuadrado personalizado"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(353, 29)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox1.Size = New System.Drawing.Size(308, 109)
        Me.TextBox1.TabIndex = 19
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.SystemColors.Control
        Me.ListBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Items.AddRange(New Object() {"Cuadrado 3x3", "Cuadrado 5x5", "Cuadrado 7x7", "Cuadrado 9x9", "Diagonal A 3x3", "Diagonal A 5x5", "Diagonal A 7x7", "Diagonal A 9x9", "Diagonal B 3x3", "Diagonal B 5x5", "Diagonal B 7x7", "Diagonal B 9x9", "Diamante 3x3", "Diamante 5x5", "Diamante 7x7", "Diamante 9x9", "Disco 5x5", "Disco 7x7", "Disco 9x9"})
        Me.ListBox1.Location = New System.Drawing.Point(16, 29)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(308, 109)
        Me.ListBox1.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(163, 15)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Transformar en blanco/negro"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(264, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "128"
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Location = New System.Drawing.Point(9, 67)
        Me.HScrollBar1.Maximum = 264
        Me.HScrollBar1.Minimum = 1
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New System.Drawing.Size(242, 20)
        Me.HScrollBar1.TabIndex = 11
        Me.HScrollBar1.Value = 128
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(350, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(172, 15)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Transformar en escala de grises"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(608, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(13, 15)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "0"
        '
        'HScrollBar2
        '
        Me.HScrollBar2.Location = New System.Drawing.Point(353, 67)
        Me.HScrollBar2.Maximum = 136
        Me.HScrollBar2.Name = "HScrollBar2"
        Me.HScrollBar2.Size = New System.Drawing.Size(242, 20)
        Me.HScrollBar2.TabIndex = 14
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(294, 67)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(31, 22)
        Me.Button11.TabIndex = 25
        Me.Button11.Text = "OK"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(638, 66)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(31, 22)
        Me.Button12.TabIndex = 26
        Me.Button12.Text = "OK"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(255, 110)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(168, 35)
        Me.Button14.TabIndex = 28
        Me.Button14.Text = "Actuar sobre imagen actual"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Button14)
        Me.GroupBox2.Controls.Add(Me.HScrollBar1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Button12)
        Me.GroupBox2.Controls.Add(Me.HScrollBar2)
        Me.GroupBox2.Controls.Add(Me.Button11)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(191, 259)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(678, 154)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Transformaciones previas"
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(12, 27)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(144, 35)
        Me.Button13.TabIndex = 0
        Me.Button13.Text = "Imagen original"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 10000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        Me.ToolTip1.ToolTipTitle = "Ayuda"
        '
        'OperadoresMorfologicos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 428)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "OperadoresMorfologicos"
        Me.Text = "Operaciones morfológicas (beta)"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents txtalto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtancho As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents HScrollBar1 As System.Windows.Forms.HScrollBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents HScrollBar2 As System.Windows.Forms.HScrollBar
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
