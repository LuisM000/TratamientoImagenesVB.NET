<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Afin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Afin))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirImagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarImagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SalirAProgramaPrincipalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnlazarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnviaImagenAProgramaPrincipalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropiedadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActivarImagenGeneralToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesactivarImagenGeneralToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AbrirImagenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarImagenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirAProgramaPrincipalToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.EnviarImagenAlProgramaPrincipalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivoToolStripMenuItem, Me.EnlazarToolStripMenuItem, Me.PropiedadesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(768, 24)
        Me.MenuStrip1.TabIndex = 3
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirImagenToolStripMenuItem, Me.GuardarImagenToolStripMenuItem, Me.ToolStripMenuItem2, Me.SalirAProgramaPrincipalToolStripMenuItem})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'AbrirImagenToolStripMenuItem
        '
        Me.AbrirImagenToolStripMenuItem.Image = CType(resources.GetObject("AbrirImagenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AbrirImagenToolStripMenuItem.Name = "AbrirImagenToolStripMenuItem"
        Me.AbrirImagenToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.AbrirImagenToolStripMenuItem.Text = "Abrir imagen"
        '
        'GuardarImagenToolStripMenuItem
        '
        Me.GuardarImagenToolStripMenuItem.Image = CType(resources.GetObject("GuardarImagenToolStripMenuItem.Image"), System.Drawing.Image)
        Me.GuardarImagenToolStripMenuItem.Name = "GuardarImagenToolStripMenuItem"
        Me.GuardarImagenToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.GuardarImagenToolStripMenuItem.Text = "Guardar imagen"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(209, 6)
        '
        'SalirAProgramaPrincipalToolStripMenuItem
        '
        Me.SalirAProgramaPrincipalToolStripMenuItem.Image = CType(resources.GetObject("SalirAProgramaPrincipalToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalirAProgramaPrincipalToolStripMenuItem.Name = "SalirAProgramaPrincipalToolStripMenuItem"
        Me.SalirAProgramaPrincipalToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.SalirAProgramaPrincipalToolStripMenuItem.Text = "Salir al programa principal"
        '
        'EnlazarToolStripMenuItem
        '
        Me.EnlazarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnviaImagenAProgramaPrincipalToolStripMenuItem})
        Me.EnlazarToolStripMenuItem.Name = "EnlazarToolStripMenuItem"
        Me.EnlazarToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.EnlazarToolStripMenuItem.Text = "Enlazar"
        '
        'EnviaImagenAProgramaPrincipalToolStripMenuItem
        '
        Me.EnviaImagenAProgramaPrincipalToolStripMenuItem.Image = CType(resources.GetObject("EnviaImagenAProgramaPrincipalToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EnviaImagenAProgramaPrincipalToolStripMenuItem.Name = "EnviaImagenAProgramaPrincipalToolStripMenuItem"
        Me.EnviaImagenAProgramaPrincipalToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.EnviaImagenAProgramaPrincipalToolStripMenuItem.Text = "Enviar imagen al programa principal"
        '
        'PropiedadesToolStripMenuItem
        '
        Me.PropiedadesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivarImagenGeneralToolStripMenuItem, Me.DesactivarImagenGeneralToolStripMenuItem1})
        Me.PropiedadesToolStripMenuItem.Name = "PropiedadesToolStripMenuItem"
        Me.PropiedadesToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.PropiedadesToolStripMenuItem.Text = "Propiedades"
        '
        'ActivarImagenGeneralToolStripMenuItem
        '
        Me.ActivarImagenGeneralToolStripMenuItem.Image = CType(resources.GetObject("ActivarImagenGeneralToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ActivarImagenGeneralToolStripMenuItem.Name = "ActivarImagenGeneralToolStripMenuItem"
        Me.ActivarImagenGeneralToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ActivarImagenGeneralToolStripMenuItem.Text = "Activar imagen general"
        '
        'DesactivarImagenGeneralToolStripMenuItem1
        '
        Me.DesactivarImagenGeneralToolStripMenuItem1.Image = CType(resources.GetObject("DesactivarImagenGeneralToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.DesactivarImagenGeneralToolStripMenuItem1.Name = "DesactivarImagenGeneralToolStripMenuItem1"
        Me.DesactivarImagenGeneralToolStripMenuItem1.Size = New System.Drawing.Size(213, 22)
        Me.DesactivarImagenGeneralToolStripMenuItem1.Text = "Desactivar imagen general"
        '
        'Timer1
        '
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PictureBox2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(768, 753)
        Me.SplitContainer1.SplitterDistance = 232
        Me.SplitContainer1.TabIndex = 2
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirImagenToolStripMenuItem1, Me.GuardarImagenToolStripMenuItem1, Me.SalirAProgramaPrincipalToolStripMenuItem1, Me.ToolStripMenuItem1, Me.EnviarImagenAlProgramaPrincipalToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(266, 98)
        '
        'AbrirImagenToolStripMenuItem1
        '
        Me.AbrirImagenToolStripMenuItem1.Image = CType(resources.GetObject("AbrirImagenToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.AbrirImagenToolStripMenuItem1.Name = "AbrirImagenToolStripMenuItem1"
        Me.AbrirImagenToolStripMenuItem1.Size = New System.Drawing.Size(265, 22)
        Me.AbrirImagenToolStripMenuItem1.Text = "Abrir imagen"
        '
        'GuardarImagenToolStripMenuItem1
        '
        Me.GuardarImagenToolStripMenuItem1.Image = CType(resources.GetObject("GuardarImagenToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.GuardarImagenToolStripMenuItem1.Name = "GuardarImagenToolStripMenuItem1"
        Me.GuardarImagenToolStripMenuItem1.Size = New System.Drawing.Size(265, 22)
        Me.GuardarImagenToolStripMenuItem1.Text = "Guardar imagen"
        '
        'SalirAProgramaPrincipalToolStripMenuItem1
        '
        Me.SalirAProgramaPrincipalToolStripMenuItem1.Image = CType(resources.GetObject("SalirAProgramaPrincipalToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.SalirAProgramaPrincipalToolStripMenuItem1.Name = "SalirAProgramaPrincipalToolStripMenuItem1"
        Me.SalirAProgramaPrincipalToolStripMenuItem1.Size = New System.Drawing.Size(265, 22)
        Me.SalirAProgramaPrincipalToolStripMenuItem1.Text = "Salir al programa principal"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(262, 6)
        '
        'EnviarImagenAlProgramaPrincipalToolStripMenuItem
        '
        Me.EnviarImagenAlProgramaPrincipalToolStripMenuItem.Image = CType(resources.GetObject("EnviarImagenAlProgramaPrincipalToolStripMenuItem.Image"), System.Drawing.Image)
        Me.EnviarImagenAlProgramaPrincipalToolStripMenuItem.Name = "EnviarImagenAlProgramaPrincipalToolStripMenuItem"
        Me.EnviarImagenAlProgramaPrincipalToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.EnviarImagenAlProgramaPrincipalToolStripMenuItem.Text = "Enviar imagen al programa principal"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(228, 749)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.White
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(228, 749)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(3, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(318, 388)
        Me.Panel1.TabIndex = 55
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox2)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(9, 306)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(298, 68)
        Me.GroupBox2.TabIndex = 53
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Tamaño imagen salida"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(188, 33)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(78, 20)
        Me.TextBox2.TabIndex = 11
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(58, 33)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(78, 20)
        Me.TextBox1.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(157, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(25, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Alto"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Ancho"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown3)
        Me.GroupBox1.Controls.Add(Me.NumericUpDown2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(298, 246)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(21, 41)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(53, 17)
        Me.RadioButton1.TabIndex = 1
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Matrix"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(178, 41)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(78, 17)
        Me.RadioButton2.TabIndex = 2
        Me.RadioButton2.Text = "Drawimage"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(87, 85)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown1.TabIndex = 3
        Me.NumericUpDown1.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(42, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Giro (º)"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(178, 191)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(95, 36)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Imagen original"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 139)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Traslación (x)"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(21, 191)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 36)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Transformar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Escala (x)"
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.Location = New System.Drawing.Point(234, 137)
        Me.NumericUpDown5.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown5.TabIndex = 7
        Me.NumericUpDown5.Value = New Decimal(New Integer() {35, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(175, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 41
        Me.Label4.Text = "Escala (y)"
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.Location = New System.Drawing.Point(87, 137)
        Me.NumericUpDown4.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown4.TabIndex = 6
        Me.NumericUpDown4.Value = New Decimal(New Integer() {25, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(158, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "Traslación (y)"
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.DecimalPlaces = 1
        Me.NumericUpDown3.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericUpDown3.Location = New System.Drawing.Point(234, 111)
        Me.NumericUpDown3.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown3.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown3.TabIndex = 5
        Me.NumericUpDown3.Value = New Decimal(New Integer() {17, 0, 0, 65536})
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.DecimalPlaces = 1
        Me.NumericUpDown2.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericUpDown2.Location = New System.Drawing.Point(87, 111)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown2.TabIndex = 4
        Me.NumericUpDown2.Value = New Decimal(New Integer() {12, 0, 0, 65536})
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(3, 400)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(318, 374)
        Me.Panel2.TabIndex = 56
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox3.Location = New System.Drawing.Point(9, 27)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(298, 298)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 52
        Me.PictureBox3.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Label8"
        '
        'Afin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(768, 777)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "Afin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Afin"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirImagenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarImagenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirAProgramaPrincipalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnlazarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EnviaImagenAProgramaPrincipalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents NumericUpDown1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AbrirImagenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarImagenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirAProgramaPrincipalToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EnviarImagenAlProgramaPrincipalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PropiedadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivarImagenGeneralToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesactivarImagenGeneralToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
