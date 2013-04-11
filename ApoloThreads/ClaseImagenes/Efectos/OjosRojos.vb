Imports ClaseImagenes.Apolo

Public Class OjosRojos

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal
    Dim bmpOriginal As New Bitmap(Principal.PictureBox2.Image) 'Copia de la imagen inicial

    Private Sub OjosRojos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
    End Sub

    'Rojo izquierdo
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False And BackgroundWorker2.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    'Ojo derecho
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If BackgroundWorker1.IsBusy = False And BackgroundWorker2.IsBusy = False Then
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Principal.PictureBox1.Image = objetoTratamiento.EliminarOjosRojos(bmpP, New Point(txtCentroX.Text, txtCentroY.Text), txtRadio.Text, txtminimo.Text)
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Principal.PictureBox1.Image = objetoTratamiento.EliminarOjosRojos(bmpP, New Point(txtCentroX_2.Text, txtCentroY_2.Text), txtRadio_2.Text, txtminimo_2.Text)
    End Sub

    'Imagen original (inicial)
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        bmpP = bmpOriginal
    End Sub
    'Imagen actual
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        bmpP = Principal.PictureBox2.Image
    End Sub

   

   
End Class