Imports WindowsApplication1.Class1
Imports WindowsApplication1.Class2

Public Class Unir
    Dim objeto As New tratamiento
    Dim objetoform As New trataformu
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PictureBox1.Location = New Size(12, 82)
        PictureBox1.Visible = True
        PictureBox2.Location = New Size(432, 82)
        PictureBox2.Visible = True
        PictureBox3.Visible = False
        bmpunir1 = objeto.abirImagen() 'Abrimos imagen y al PictureBox
        Dim bmpaux As New Bitmap(bmpunir1, PictureBox1.Width, PictureBox1.Height)
        PictureBox1.Image = bmpaux
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PictureBox2.Location = New Size(432, 82)
        PictureBox2.Visible = True
        PictureBox1.Location = New Size(12, 82)
        PictureBox1.Visible = True
        PictureBox3.Visible = False
        bmpunir2 = objeto.abirImagen() 'Abrimos imagen y al PictureBox
        Dim bmpaux As New Bitmap(bmpunir2, PictureBox2.Width, PictureBox2.Height)
        PictureBox2.Image = bmpaux
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If IsNothing(PictureBox1.Image) Or IsNothing(PictureBox2.Image) Then
            MessageBox.Show("Por favor, seleccione dos imágenes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim bmp1 As New Bitmap(PictureBox1.Image)
        Dim bmp2 As New Bitmap(PictureBox2.Image)
        Timer1.Enabled = True

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim bmp1 As New Bitmap(PictureBox1.Image)
        Dim bmp2 As New Bitmap(PictureBox2.Image)
        If My.Settings.animacion = True Then
            PictureBox1.Left = PictureBox1.Left + 7
            PictureBox2.Left = PictureBox2.Left - 7
            If PictureBox1.Left + 7 >= PictureBox2.Left Then
                Timer1.Enabled = False
                PictureBox3.Image = objeto.unir(bmp1, bmp2)
                PictureBox1.Visible = False
                PictureBox2.Visible = False
                PictureBox3.Visible = True
                Exit Sub
            End If
        Else
            Timer1.Enabled = False
            PictureBox3.Image = objeto.unir(bmp1, bmp2)
            PictureBox1.Visible = False
            PictureBox2.Visible = False
            PictureBox3.Visible = True
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If IsNothing(PictureBox1.Image) Or IsNothing(PictureBox2.Image) Then
            MessageBox.Show("Por favor, seleccione dos imágenes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        aceptar = True
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

    Private Sub Unir_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If My.Settings.animacion = True Then
            Timer1.Interval = 1
        End If
        PictureBox1.Location = New Size(12, 82)
        PictureBox1.Visible = True
        PictureBox2.Location = New Size(432, 82)
        PictureBox2.Visible = True
        PictureBox3.Visible = False
    End Sub
End Class