<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropiedadesZoom
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chbPuntero = New System.Windows.Forms.CheckBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chbEtiqueta = New System.Windows.Forms.CheckBox()
        Me.NumVentana = New System.Windows.Forms.NumericUpDown()
        Me.NumZoom = New System.Windows.Forms.NumericUpDown()
        Me.NumTamanoPuntero = New System.Windows.Forms.NumericUpDown()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NumDistanciaPuntero = New System.Windows.Forms.NumericUpDown()
        CType(Me.NumVentana, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumTamanoPuntero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumDistanciaPuntero, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Tamaño de la ventana:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Valor del zoom:"
        '
        'chbPuntero
        '
        Me.chbPuntero.AutoSize = True
        Me.chbPuntero.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbPuntero.Location = New System.Drawing.Point(26, 130)
        Me.chbPuntero.Name = "chbPuntero"
        Me.chbPuntero.Size = New System.Drawing.Size(108, 19)
        Me.chbPuntero.TabIndex = 2
        Me.chbPuntero.Text = "Activar puntero"
        Me.chbPuntero.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(189, 159)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Color"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(70, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tamaño:"
        '
        'chbEtiqueta
        '
        Me.chbEtiqueta.AutoSize = True
        Me.chbEtiqueta.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbEtiqueta.Location = New System.Drawing.Point(26, 194)
        Me.chbEtiqueta.Name = "chbEtiqueta"
        Me.chbEtiqueta.Size = New System.Drawing.Size(103, 19)
        Me.chbEtiqueta.TabIndex = 5
        Me.chbEtiqueta.Text = "Etiqueta zoom"
        Me.chbEtiqueta.UseVisualStyleBackColor = True
        '
        'NumVentana
        '
        Me.NumVentana.Location = New System.Drawing.Point(152, 19)
        Me.NumVentana.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NumVentana.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumVentana.Name = "NumVentana"
        Me.NumVentana.Size = New System.Drawing.Size(66, 23)
        Me.NumVentana.TabIndex = 6
        Me.NumVentana.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'NumZoom
        '
        Me.NumZoom.DecimalPlaces = 1
        Me.NumZoom.Increment = New Decimal(New Integer() {2, 0, 0, 65536})
        Me.NumZoom.Location = New System.Drawing.Point(152, 54)
        Me.NumZoom.Maximum = New Decimal(New Integer() {52, 0, 0, 65536})
        Me.NumZoom.Minimum = New Decimal(New Integer() {4, 0, 0, 65536})
        Me.NumZoom.Name = "NumZoom"
        Me.NumZoom.Size = New System.Drawing.Size(41, 23)
        Me.NumZoom.TabIndex = 7
        Me.NumZoom.Value = New Decimal(New Integer() {4, 0, 0, 65536})
        '
        'NumTamanoPuntero
        '
        Me.NumTamanoPuntero.Location = New System.Drawing.Point(130, 159)
        Me.NumTamanoPuntero.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumTamanoPuntero.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumTamanoPuntero.Name = "NumTamanoPuntero"
        Me.NumTamanoPuntero.Size = New System.Drawing.Size(48, 23)
        Me.NumTamanoPuntero.TabIndex = 8
        Me.NumTamanoPuntero.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(93, 228)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 30)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Cerrar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(184, 228)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(85, 30)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Aplicar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(23, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Distancia al puntero:"
        '
        'NumDistanciaPuntero
        '
        Me.NumDistanciaPuntero.Increment = New Decimal(New Integer() {2, 0, 0, 65536})
        Me.NumDistanciaPuntero.Location = New System.Drawing.Point(152, 89)
        Me.NumDistanciaPuntero.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumDistanciaPuntero.Name = "NumDistanciaPuntero"
        Me.NumDistanciaPuntero.Size = New System.Drawing.Size(41, 23)
        Me.NumDistanciaPuntero.TabIndex = 12
        Me.NumDistanciaPuntero.Value = New Decimal(New Integer() {4, 0, 0, 65536})
        '
        'PropiedadesZoom
        '
        Me.AcceptButton = Me.Button3
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(281, 269)
        Me.Controls.Add(Me.NumDistanciaPuntero)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.NumTamanoPuntero)
        Me.Controls.Add(Me.NumZoom)
        Me.Controls.Add(Me.NumVentana)
        Me.Controls.Add(Me.chbEtiqueta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.chbPuntero)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "PropiedadesZoom"
        Me.Text = "Propiedades zoom interactivo"
        CType(Me.NumVentana, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumZoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumTamanoPuntero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumDistanciaPuntero, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chbPuntero As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chbEtiqueta As System.Windows.Forms.CheckBox
    Friend WithEvents NumVentana As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumZoom As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumTamanoPuntero As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents NumDistanciaPuntero As System.Windows.Forms.NumericUpDown
End Class
