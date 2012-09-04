<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfPaso1
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Activar animaciones")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Comprobar actualizaciones al inicio")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Activar imagen general")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pantalla de presentación")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Activar animaciones")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Comprobar actualizaciones al inicio")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Activar imagen general")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pantalla de presentación")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Activar animaciones")
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Comprobar actualizaciones al inicio")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Activar imagen general")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pantalla de presentación")
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TreeView3 = New System.Windows.Forms.TreeView()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TreeView3)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.TreeView1)
        Me.GroupBox1.Controls.Add(Me.TreeView2)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(344, 360)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Rendimiento"
        '
        'TreeView3
        '
        Me.TreeView3.BackColor = System.Drawing.SystemColors.Control
        Me.TreeView3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView3.CheckBoxes = True
        Me.TreeView3.Location = New System.Drawing.Point(54, 280)
        Me.TreeView3.Name = "TreeView3"
        TreeNode1.Checked = True
        TreeNode1.Name = "Nodo0"
        TreeNode1.Text = "Activar animaciones"
        TreeNode2.Name = "Nodo1"
        TreeNode2.Text = "Comprobar actualizaciones al inicio"
        TreeNode3.Checked = True
        TreeNode3.Name = "Nodo2"
        TreeNode3.Text = "Activar imagen general"
        TreeNode4.Checked = True
        TreeNode4.Name = "Nodo4"
        TreeNode4.Text = "Pantalla de presentación"
        Me.TreeView3.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Me.TreeView3.Size = New System.Drawing.Size(257, 74)
        Me.TreeView3.TabIndex = 6
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(32, 257)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(152, 17)
        Me.RadioButton3.TabIndex = 5
        Me.RadioButton3.Text = "Rendimiento personalizado"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.SystemColors.Control
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Enabled = False
        Me.TreeView1.Location = New System.Drawing.Point(54, 54)
        Me.TreeView1.Name = "TreeView1"
        TreeNode5.Checked = True
        TreeNode5.Name = "Nodo0"
        TreeNode5.Text = "Activar animaciones"
        TreeNode6.Checked = True
        TreeNode6.Name = "Nodo1"
        TreeNode6.Text = "Comprobar actualizaciones al inicio"
        TreeNode7.Checked = True
        TreeNode7.Name = "Nodo2"
        TreeNode7.Text = "Activar imagen general"
        TreeNode8.Checked = True
        TreeNode8.Name = "Nodo4"
        TreeNode8.Text = "Pantalla de presentación"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode6, TreeNode7, TreeNode8})
        Me.TreeView1.Size = New System.Drawing.Size(257, 74)
        Me.TreeView1.TabIndex = 4
        '
        'TreeView2
        '
        Me.TreeView2.BackColor = System.Drawing.SystemColors.Control
        Me.TreeView2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView2.CheckBoxes = True
        Me.TreeView2.Enabled = False
        Me.TreeView2.Location = New System.Drawing.Point(54, 167)
        Me.TreeView2.Name = "TreeView2"
        TreeNode9.Name = "Nodo0"
        TreeNode9.Text = "Activar animaciones"
        TreeNode10.Name = "Nodo1"
        TreeNode10.Text = "Comprobar actualizaciones al inicio"
        TreeNode11.Name = "Nodo2"
        TreeNode11.Text = "Activar imagen general"
        TreeNode12.Name = "Nodo4"
        TreeNode12.Text = "Pantalla de presentación"
        Me.TreeView2.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode9, TreeNode10, TreeNode11, TreeNode12})
        Me.TreeView2.Size = New System.Drawing.Size(257, 73)
        Me.TreeView2.TabIndex = 3
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(32, 144)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(115, 17)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Rendimiento medio"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(32, 31)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(100, 17)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Alto rendimiento"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(256, 387)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Siguiente"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Location = New System.Drawing.Point(12, 387)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 23)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Cancelar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ConfPaso1
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(368, 422)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConfPaso1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Configuración rápida"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TreeView3 As System.Windows.Forms.TreeView
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button

End Class
