Imports ClaseImagenes.Apolo
Public Class Tapiz

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes

    Function comprobarDatos()
        For Each c As Control In Me.Panel1.Controls
            If TypeOf c Is TextBox Then
                If IsNumeric(c.Text) = False Then
                    c.BackColor = Color.Red
                Else
                    c.BackColor = Color.White
                End If
            End If
        Next
        Return comprobarColores()
    End Function
    Function comprobarColores()
        For Each c As Control In Me.Panel1.Controls
            If TypeOf c Is TextBox Then
                If c.BackColor = Color.Red Then
                    Return False
                    Exit Function
                End If
            End If
        Next
        Return True
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False And comprobarDatos() = True Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub Tapiz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button4.BackColor = Color.White
        TextBox1.Text = 500
        TextBox2.Text = 500
        TextBox3.Text = "Nuevo tapiz"
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

    End Sub
 

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Button4.BackColor = ColorDialog1.Color
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Principal.PictureBox1.Image = objetoTratamiento.tapiz(TextBox1.Text, TextBox2.Text, Button4.BackColor, TextBox3.Text)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        objetoTratamiento.actualizarNombreTapiz(TextBox3.Text, TextBox1.Text, TextBox2.Text) 'Lo hacemos en dos pasos para controlar la excepción del evento (delegado)
    End Sub
End Class