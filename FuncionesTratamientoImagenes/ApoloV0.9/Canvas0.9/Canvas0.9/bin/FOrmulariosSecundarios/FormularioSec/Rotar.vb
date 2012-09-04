Public Class Rotar

   

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For Each elemento In ListBox1.SelectedItems
            ListBox2.Items.Add(elemento)
        Next
        ListBox1.ClearSelected()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        While ListBox2.SelectedIndex <> -1
            For Each elemento In ListBox2.SelectedIndices
                ListBox2.Items.RemoveAt(elemento)
            Next
        End While
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        For Each elemento In ListBox2.Items
            rotacion(elemento)
        Next
    End Sub

    Sub rotacion(ByVal rota As String)
        Select Case rota
            Case "RotateNoneFlipNone"
                PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone)
            Case "Rotate90FlipNone"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Case "Rotate180FlipNone"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Case "Rotate270FlipNone"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Case "RotateNoneFlipX"
                PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Case "Rotate90FlipX"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipX)
            Case "Rotate180FlipX"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipX)
            Case "Rotate270FlipX"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipX)
            Case "RotateNoneFlipY"
                PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Case "Rotate90FlipY"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
            Case "Rotate180FlipY"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipY)
            Case "Rotate270FlipY"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipY)
            Case "RotateNoneFlipXY"
                PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipXY)
            Case "Rotate90FlipXY"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipXY)
            Case "Rotate180FlipXY"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipXY)
            Case "Rotate270FlipXY"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipXY)
        End Select
        PictureBox1.Refresh()
    End Sub

    Private Sub Rotar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.Image = bmpentreForm
        ListBox2.Items.Clear()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Me.Close()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
    End Sub
End Class