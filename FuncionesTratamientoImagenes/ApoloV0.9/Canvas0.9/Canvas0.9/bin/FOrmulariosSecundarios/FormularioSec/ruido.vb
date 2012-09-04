Imports WindowsApplication1.Class1

Public Class ruido

    Private Sub ruido_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        HScrollBar1.Value = 70
        HScrollBar1.Value = 150
        HScrollBar1.Value = 29
        Label2.Text = 70
        Label3.Text = 150
        Label4.Text = 29
        Me.NumericUpDown1.Value = 20
        Dim objeto As New tratamiento
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = objeto.ruido(bmpaux, 20, 70, 150, 29)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        aceptar = True
        rojoaleatorio = HScrollBar1.Value
        verdealeatorio = HScrollBar2.Value
        azulaleatorio = HScrollBar3.Value
        valoraleat = NumericUpDown1.Value
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim objeto As New tratamiento
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = objeto.ruido(bmpaux, NumericUpDown1.Value, HScrollBar1.Value, HScrollBar2.Value, HScrollBar3.Value)
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub HScrollBar1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Label2.Text = HScrollBar1.Value
    End Sub

    Private Sub HScrollBar2_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar2.Scroll
        Label3.Text = HScrollBar2.Value
    End Sub

    Private Sub HScrollBar3_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar3.Scroll
        Label4.Text = HScrollBar3.Value
    End Sub
End Class