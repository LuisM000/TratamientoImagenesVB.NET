<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GrabarSecuencia
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.NomFunc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Param1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Param2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Param3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Param = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Param5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.listBoxFunciones = New System.Windows.Forms.ListBox()
        Me.txtnombreFuncion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Combo1 = New System.Windows.Forms.ComboBox()
        Me.combo2 = New System.Windows.Forms.ComboBox()
        Me.combo3 = New System.Windows.Forms.ComboBox()
        Me.combo4 = New System.Windows.Forms.ComboBox()
        Me.combo5 = New System.Windows.Forms.ComboBox()
        Me.txtBuscador = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtdescripción = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnAnadir = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NomFunc, Me.Param1, Me.Param2, Me.Param3, Me.Param, Me.Param5})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 244)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(902, 208)
        Me.DataGridView1.TabIndex = 0
        '
        'NomFunc
        '
        Me.NomFunc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NomFunc.HeaderText = "Nombre función"
        Me.NomFunc.Name = "NomFunc"
        Me.NomFunc.ReadOnly = True
        '
        'Param1
        '
        Me.Param1.HeaderText = "Parámetro 1"
        Me.Param1.Name = "Param1"
        '
        'Param2
        '
        Me.Param2.HeaderText = "Parámetro 2"
        Me.Param2.Name = "Param2"
        '
        'Param3
        '
        Me.Param3.HeaderText = "Parámetro 3"
        Me.Param3.Name = "Param3"
        '
        'Param
        '
        Me.Param.HeaderText = "Parámetro 4"
        Me.Param.Name = "Param"
        '
        'Param5
        '
        Me.Param5.HeaderText = "Parámetro 5"
        Me.Param5.Name = "Param5"
        '
        'listBoxFunciones
        '
        Me.listBoxFunciones.FormattingEnabled = True
        Me.listBoxFunciones.ItemHeight = 15
        Me.listBoxFunciones.Items.AddRange(New Object() {"Blanco y negro", "Escala de grises", "Brillo", "Invertir colores (rojo, verde, azul)", "Sepia", "Filtros básicos (rojo, verde, azul)", "RGB a (BGR, GRB, RBG)", "Redimensionar", "Contraste (recomendado)", "Contraste", "Correción de gamma", "Exposición", "Modificar canales", "Reducir colores", "Filtrar colores (rojo)", "Filtrar colores (verde)", "Filtrar colores (azul)", "Detectar contornos", "Operación aritmética - Suma", "Operación aritmética - Resta", "Operación aritmética - División", "Operación aritmética - Multiplicación", "Operación lógicas - AND", "Operación lógicas - OR", "Operación lógicas - XOR", "Reflexión horizontal", "Reflexión vertical", "Traslación", "Voltear", "Density Slicing automático"})
        Me.listBoxFunciones.Location = New System.Drawing.Point(12, 55)
        Me.listBoxFunciones.Name = "listBoxFunciones"
        Me.listBoxFunciones.Size = New System.Drawing.Size(264, 169)
        Me.listBoxFunciones.TabIndex = 0
        '
        'txtnombreFuncion
        '
        Me.txtnombreFuncion.Location = New System.Drawing.Point(20, 46)
        Me.txtnombreFuncion.Name = "txtnombreFuncion"
        Me.txtnombreFuncion.ReadOnly = True
        Me.txtnombreFuncion.Size = New System.Drawing.Size(159, 23)
        Me.txtnombreFuncion.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(287, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Parámetro 2"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Combo1)
        Me.Panel1.Controls.Add(Me.combo2)
        Me.Panel1.Controls.Add(Me.combo3)
        Me.Panel1.Controls.Add(Me.combo4)
        Me.Panel1.Controls.Add(Me.combo5)
        Me.Panel1.Location = New System.Drawing.Point(185, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(413, 40)
        Me.Panel1.TabIndex = 19
        '
        'Combo1
        '
        Me.Combo1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Combo1.Enabled = False
        Me.Combo1.FormattingEnabled = True
        Me.Combo1.Location = New System.Drawing.Point(28, 5)
        Me.Combo1.Name = "Combo1"
        Me.Combo1.Size = New System.Drawing.Size(64, 23)
        Me.Combo1.TabIndex = 0
        '
        'combo2
        '
        Me.combo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo2.Enabled = False
        Me.combo2.FormattingEnabled = True
        Me.combo2.Location = New System.Drawing.Point(105, 5)
        Me.combo2.Name = "combo2"
        Me.combo2.Size = New System.Drawing.Size(64, 23)
        Me.combo2.TabIndex = 1
        '
        'combo3
        '
        Me.combo3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo3.Enabled = False
        Me.combo3.FormattingEnabled = True
        Me.combo3.Location = New System.Drawing.Point(182, 5)
        Me.combo3.Name = "combo3"
        Me.combo3.Size = New System.Drawing.Size(64, 23)
        Me.combo3.TabIndex = 2
        '
        'combo4
        '
        Me.combo4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo4.Enabled = False
        Me.combo4.FormattingEnabled = True
        Me.combo4.Location = New System.Drawing.Point(259, 5)
        Me.combo4.Name = "combo4"
        Me.combo4.Size = New System.Drawing.Size(64, 23)
        Me.combo4.TabIndex = 3
        '
        'combo5
        '
        Me.combo5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo5.Enabled = False
        Me.combo5.FormattingEnabled = True
        Me.combo5.Location = New System.Drawing.Point(336, 5)
        Me.combo5.Name = "combo5"
        Me.combo5.Size = New System.Drawing.Size(64, 23)
        Me.combo5.TabIndex = 4
        '
        'txtBuscador
        '
        Me.txtBuscador.Location = New System.Drawing.Point(12, 26)
        Me.txtBuscador.Name = "txtBuscador"
        Me.txtBuscador.Size = New System.Drawing.Size(264, 23)
        Me.txtBuscador.TabIndex = 100
        Me.txtBuscador.Text = "Buscador de funciones"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(441, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 15)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "Parámetro 4"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(364, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "Parámetro 3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(518, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 15)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "Parámetro 5"
        '
        'txtdescripción
        '
        Me.txtdescripción.Location = New System.Drawing.Point(20, 112)
        Me.txtdescripción.Multiline = True
        Me.txtdescripción.Name = "txtdescripción"
        Me.txtdescripción.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtdescripción.Size = New System.Drawing.Size(565, 89)
        Me.txtdescripción.TabIndex = 105
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 15)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "Descripción"
        '
        'btnAnadir
        '
        Me.btnAnadir.Location = New System.Drawing.Point(920, 53)
        Me.btnAnadir.Name = "btnAnadir"
        Me.btnAnadir.Size = New System.Drawing.Size(136, 31)
        Me.btnAnadir.TabIndex = 107
        Me.btnAnadir.Text = "Añadir función"
        Me.btnAnadir.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(920, 421)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(136, 31)
        Me.Button1.TabIndex = 108
        Me.Button1.Text = "Aplicar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(920, 318)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(136, 31)
        Me.Button2.TabIndex = 109
        Me.Button2.Text = "Borrar secuencia"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(920, 244)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(136, 31)
        Me.Button3.TabIndex = 110
        Me.Button3.Text = "Exportar secuencia"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(920, 281)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(136, 31)
        Me.Button4.TabIndex = 111
        Me.Button4.Text = "Importar secuencia"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(210, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 15)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Parámetro 1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtdescripción)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtnombreFuncion)
        Me.GroupBox1.Location = New System.Drawing.Point(301, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(613, 212)
        Me.GroupBox1.TabIndex = 112
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Función"
        '
        'GrabarSecuencia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1070, 467)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnAnadir)
        Me.Controls.Add(Me.txtBuscador)
        Me.Controls.Add(Me.listBoxFunciones)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "GrabarSecuencia"
        Me.Text = "Grabar secuencia"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents listBoxFunciones As System.Windows.Forms.ListBox
    Friend WithEvents txtnombreFuncion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Combo1 As System.Windows.Forms.ComboBox
    Friend WithEvents combo2 As System.Windows.Forms.ComboBox
    Friend WithEvents combo3 As System.Windows.Forms.ComboBox
    Friend WithEvents combo4 As System.Windows.Forms.ComboBox
    Friend WithEvents combo5 As System.Windows.Forms.ComboBox
    Friend WithEvents txtBuscador As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtdescripción As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnAnadir As System.Windows.Forms.Button
    Friend WithEvents NomFunc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Param1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Param2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Param3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Param As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Param5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
End Class
