Imports ClaseImagenes.Apolo
Public Class Cine

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal
    Dim bmp As Bitmap

    Private Sub Cine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox2.SelectedIndex = 1
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
        Dim pic As PictureBox
        For Each c As Control In Me.Controls
            If TypeOf c Is PictureBox Then
                pic = c
                pic.Image = bmpP
                c = pic
                AddHandler DirectCast(c, PictureBox).MouseEnter, AddressOf conFoco
                AddHandler DirectCast(c, PictureBox).MouseLeave, AddressOf sinFoco
                AddHandler DirectCast(c, PictureBox).MouseClick, AddressOf Pulsa
            End If
        Next
      
    End Sub
    Private Sub conFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
    End Sub
    Private Sub sinFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Pulsa(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
        bmp = abrirImagen()
        If bmp IsNot Nothing Then
            DirectCast(sender, PictureBox).Image = bmp
        End If
    End Sub

    Dim eleccionCombo As Integer
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If BackgroundWorker1.IsBusy = False Then
            eleccionCombo = ComboBox2.SelectedIndex
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Principal.PictureBox1.Image = objetoTratamiento.cine(PictureBox1.Image, PictureBox2.Image, PictureBox3.Image, PictureBox4.Image, PictureBox5.Image, PictureBox6.Image, eleccionCombo)
    End Sub


    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Me.Close()
    End Sub

   

    Private Function abrirImagen(Optional filtrado As Integer = 1) As Bitmap
        Try
            Dim dialogo As New OpenFileDialog
            With dialogo
                .Filter = "Todos los formatos compatibles|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif" & _
                          "|Ficheros BMP|*.bmp" & _
                          "|Ficheros GIF|*.gif" & _
                          "|Ficheros JPG o JPEG|*.jpg;*.jpeg" & _
                          "|Ficheros PNG|*.png" & _
                          "|Ficheros TIFF|*.tif" & _
                          "|Todos los archivos|*.*"
                .FilterIndex = filtrado
                If (.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    abrirImagen = Image.FromFile(.FileName)
                    Return abrirImagen
                Else
                    abrirImagen = Nothing
                    Return abrirImagen
                End If
            End With
        Catch e As Exception
            MessageBox.Show(e.ToString)
            abrirImagen = Nothing
            Return abrirImagen
        End Try
    End Function

  

End Class