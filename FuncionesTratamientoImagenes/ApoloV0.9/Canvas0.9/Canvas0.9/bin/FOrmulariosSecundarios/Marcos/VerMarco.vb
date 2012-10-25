Public Class VerMarco

    Private Sub VerMarco_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Select Case tipoMarco
            Case 0
                PictureBox1.Image = My.Resources.marco
            Case 1
                PictureBox1.Image = My.Resources.negativoMarco
            Case 2
                PictureBox1.Image = My.Resources.MarcoOndul
            Case 3
                PictureBox1.Image = My.Resources.marcoNegro
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class