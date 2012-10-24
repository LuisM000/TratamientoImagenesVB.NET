Imports WindowsApplication1.Class1

Public Class Cine

    Dim objetol As New tratamiento
    Private Sub Cine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ImgCINEtrasf = Nothing
        PictureBox1.Image = ImgCINE
        PictureBox2.Image = ImgCINE
        PictureBox3.Image = ImgCINE
        PictureBox4.Image = ImgCINE
        PictureBox5.Image = ImgCINE
        PictureBox6.Image = ImgCINE

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim objeto As New tratamiento

        ImgCINEtrasf = objeto.cine(PictureBox1.Image, PictureBox2.Image, PictureBox3.Image, PictureBox4.Image, PictureBox5.Image, PictureBox6.Image, ComboBox1.SelectedIndex, ComboBox3.SelectedIndex, ComboBox4.SelectedIndex, ComboBox5.SelectedIndex, ComboBox6.SelectedIndex, ComboBox7.SelectedIndex, ComboBox2.SelectedIndex)
        Me.Close()
    End Sub

   

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox1.Image = objetol.abirImagen()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        PictureBox6.Image = objetol.abirImagen()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        PictureBox5.Image = objetol.abirImagen()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PictureBox4.Image = objetol.abirImagen()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PictureBox3.Image = objetol.abirImagen()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox2.Image = objetol.abirImagen()
    End Sub



End Class