Imports WindowsApplication1.Class1

Public Class Histograma

    Dim objeto As New tratamiento
    Private Sub Histograma_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PictureBox1.Image = Nothing
        PictureBox1.Width = 258
        PictureBox1.BackColor = Color.LightGray
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        objeto.histogramaR(bmpauxhist, Me.PictureBox1, False)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        objeto.histogramaG(bmpauxhist, Me.PictureBox1, False)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        objeto.histogramaB(bmpauxhist, Me.PictureBox1, False)
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        objeto.histogramaGris(bmpauxhist, Me.PictureBox1, False)
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        PictureBox1.Image = Nothing

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        Me.Close()
    End Sub
End Class