Imports ClaseImagenes.Apolo

Public Class Contraste2

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal

    Private Sub Contraste2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HScrollBar1.Value = 255
        Label1.Text = HScrollBar1.Value
        HScrollBar2.Value = 0
        Label3.Text = HScrollBar2.Value
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Label1.Text = HScrollBar1.Value
    End Sub

    Private Sub HScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar2.Scroll
        Label3.Text = HScrollBar2.Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If HScrollBar1.Value > HScrollBar2.Value Then
            Principal.PictureBox1.Image = objetoTratamiento.ContrasteEstirar(bmpP, HScrollBar1.Value, HScrollBar2.Value)
        Else
            MessageBox.Show("El valor máximo debe ser mayor que el mínimo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class