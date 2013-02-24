Imports ClaseImagenes.Apolo
Public Class Cuadricula

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal

    Private Sub Cuadricula_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Ajustamos los valores de los numeric
        NumericUpDown1.Minimum = 1 : NumericUpDown2.Minimum = 1
        NumericUpDown1.Maximum = bmpP.Width : NumericUpDown2.Maximum = bmpP.Height
        Button4.BackColor = Color.Black
        Button5.BackColor = Color.Black
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Principal.PictureBox1.Image = objetoTratamiento.cuadricula(bmpP, Button5.BackColor, Button4.BackColor, NumericUpDown1.Value, NumericUpDown2.Value)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Button4.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Button5.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class