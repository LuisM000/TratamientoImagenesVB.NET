Imports ClaseImagenes.Apolo

Public Class AbrirRecurso
    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    'Cerramos la ventana
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    'Abrimos el recurso
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim bmp As Bitmap
        bmp = objetoTratamiento.abrirRecursoWeb(Me.TextBox1.Text)
        If bmp IsNot Nothing Then 'Si realmente se abre alguna imagen la asignamos al Picture pricipal
            Principal.PictureBox1.Image = bmp
            'Aprovechamos y actualizamos el Panel1
            Principal.Panel1.AutoScrollMinSize = Principal.PictureBox1.Image.Size
            Principal.Panel1.AutoScroll = True
        End If
    End Sub

    Private Sub AbrirRecurso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
    End Sub
End Class