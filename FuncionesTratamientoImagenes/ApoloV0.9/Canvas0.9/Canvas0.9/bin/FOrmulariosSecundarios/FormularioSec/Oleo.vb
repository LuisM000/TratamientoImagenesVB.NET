Imports WindowsApplication1.Class1

Public Class Oleo

    Private Sub Oleo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        HScrollBar1.Value = 30
        HScrollBar2.Value = 210
        Label1.Text = 30
        Label2.Text = 210
        Dim objeto As New tratamiento
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = objeto.Oleo(bmpaux, 30, 210)
        
    End Sub

    Private Sub HScrollBar1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Label1.Text = HScrollBar1.Value
    End Sub

    Private Sub HScrollBar2_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar2.Scroll
        Label2.Text = HScrollBar2.Value
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        aceptar = True 'Usuario acepta
        valorcontorno = HScrollBar1.Value
        numerocolores = HScrollBar2.Value

        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim objeto As New tratamiento 'Vista previa
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = objeto.Oleo(bmpaux, HScrollBar1.Value, HScrollBar2.Value)

    End Sub
End Class