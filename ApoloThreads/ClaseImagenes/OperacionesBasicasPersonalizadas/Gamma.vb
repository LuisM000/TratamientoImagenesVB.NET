Imports ClaseImagenes.Apolo
Public Class Gamma

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal

    Private Sub Vincular(ByVal valor As Double)
        Label1.Text = valor / 100
        HScrollBar1.Value = valor
        Label3.Text = valor / 100
        HScrollBar2.Value = valor
        Label4.Text = valor / 100
        HScrollBar3.Value = valor
    End Sub

    Private Sub Gamma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
    End Sub


    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Label1.Text = HScrollBar1.Value / 100
        If CheckBox1.Checked = True Then
            Vincular(HScrollBar1.Value)
        End If
    End Sub
    Private Sub HScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar2.Scroll
        Label3.Text = HScrollBar2.Value / 100
        If CheckBox1.Checked = True Then
            Vincular(HScrollBar2.Value)
        End If
    End Sub
    Private Sub HScrollBar3_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar3.Scroll
        Label4.Text = HScrollBar3.Value / 100
        If CheckBox1.Checked = True Then
            Vincular(HScrollBar3.Value)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Principal.PictureBox1.Image = objetoTratamiento.Gamma(bmpP, HScrollBar1.Value / 100, HScrollBar2.Value / 100, HScrollBar3.Value / 100)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        HScrollBar1.Value = 100
        HScrollBar2.Value = 100
        HScrollBar3.Value = 100
        Label1.Text = 1
        Label3.Text = 1
        Label4.Text = 1
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class