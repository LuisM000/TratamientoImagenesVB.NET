Imports ClaseImagenes.Apolo
Public Class DensityScilingAuto

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal

    Private Sub DensityScilingAuto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HScrollBar1.Value = 5
        Label1.Text = HScrollBar1.Value
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
    End Sub

    Dim matrizColores() As Color
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            ReDim matrizColores(ListBox2.Items.Count - 1) 'Extraemos colores
            For i = 0 To ListBox2.Items.Count - 1
                matrizColores(i) = Color.FromName(ListBox2.Items(i).ToString)
            Next
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If CheckBox1.Checked = True Then
            Principal.PictureBox1.Image = objetoTratamiento.DensitySlicingNormalizado(bmpP, HScrollBar1.Value, matrizColores)
        Else
            Principal.PictureBox1.Image = objetoTratamiento.DensitySlicing(bmpP, HScrollBar1.Value, matrizColores)
        End If

    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ListBox2.Items.Clear()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ListBox2.Items.Add(ListBox1.SelectedItem.ToString)
    End Sub
    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Label1.Text = HScrollBar1.Value
        ListBox2.Items.Clear()
        For i = 0 To HScrollBar1.Value - 1
            ListBox2.Items.Add(ListBox1.Items(i).ToString)
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class