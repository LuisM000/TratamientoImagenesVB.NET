Imports WindowsApplication1.Class1

Public Class Cuadricula
    Dim ratioH, ratioV As Integer
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Button4.BackColor = ColorDialog1.Color
        End If
    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Button5.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Cuadricula_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Button4.BackColor = Color.Black
        Button5.BackColor = Color.Black
        NumericUpDown1.Value = 20
        NumericUpDown2.Value = 20
        Dim objeto As New tratamiento 'Cargamos la imagen con umbral 128 
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        ratioH = bmpentreForm.Width / bmpaux.Width
        ratioV = bmpentreForm.Height / bmpaux.Height
        If ratioH = 0 Or ratioV = 0 Then
            MessageBox.Show("Por favor, desactive la vista previa desde el menú Herramientas/configuración para poder realizar la acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Exit Sub
        End If
        Me.PictureBox1.Image = objeto.cuadricula(bmpaux, 20 / ratioH, 20 / ratioV)
    End Sub


    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim objeto As New tratamiento 'Vista previa
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = objeto.cuadriculaColor(bmpaux, Button5.BackColor, Button4.BackColor, NumericUpDown1.Value / ratioH, NumericUpDown2.Value / ratioV)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        aceptar = True 'Usuario acepta
        colorh = Button5.BackColor
        colorv = Button4.BackColor
        valorH = NumericUpDown1.Value
        valorV = NumericUpDown2.Value
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class