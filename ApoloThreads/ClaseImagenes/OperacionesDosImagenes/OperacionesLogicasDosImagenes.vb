Imports ClaseImagenes.Apolo

Public Class OperacionesLogicasDosImagenes

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal

    Function abrirImagen(Optional ByVal imagenActual As Bitmap = Nothing) As Bitmap
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
                .FilterIndex = 0
                If (.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    abrirImagen = Image.FromFile(.FileName)
                    Return abrirImagen
                Else
                    Return imagenActual
                End If
            End With
        Catch e As Exception
            MessageBox.Show(e.ToString)
            abrirImagen = Nothing
            Return imagenActual
        End Try
    End Function

    Private Sub OperacionesLogicasDosImagenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckBox1.Checked = True
        RadioButton1.Checked = True
        PictureBox1.Image = bmpP
        PictureBox2.Image = bmpP
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox1.Image = abrirImagen(PictureBox1.Image)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PictureBox2.Image = abrirImagen(PictureBox2.Image)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim alfa As Boolean = True
        If CheckBox1.Checked = True Then 'Comprobamos si queremos omitir el canal alfa
            alfa = True
        Else
            alfa = False
        End If
        If RadioButton1.Checked = True Then 'Unión
            Principal.PictureBox1.Image = objetoTratamiento.OperacionAND(PictureBox1.Image, PictureBox2.Image, alfa)
        End If
        If RadioButton2.Checked = True Then 'Suma 
            Principal.PictureBox1.Image = objetoTratamiento.OperacionOR(PictureBox1.Image, PictureBox2.Image, alfa)
        End If
        If RadioButton3.Checked = True Then 'Resta
            Principal.PictureBox1.Image = objetoTratamiento.OperacionXOR(PictureBox1.Image, PictureBox2.Image, alfa)
        End If
       
    End Sub
End Class