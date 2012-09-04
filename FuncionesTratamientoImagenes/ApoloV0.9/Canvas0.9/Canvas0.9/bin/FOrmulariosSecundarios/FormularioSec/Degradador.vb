Imports WindowsApplication1.Class1

Public Class Degradador

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim objeto As New tratamiento

        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        If HScrollBar2.Value >= 0 Then
            Me.PictureBox1.Image = objeto.degradadoHorizontal(bmpaux, HScrollBar1.Value, HScrollBar2.Value)
        Else
            Me.PictureBox1.Image = objeto.degradadoHorizontalInvertido(bmpaux, HScrollBar1.Value, -HScrollBar2.Value)
        End If
        Dim bmpaux2 As New Bitmap(bmpaux)
        If VScrollBar2.Value >= 0 Then
            Me.PictureBox1.Image = objeto.degradadoVertical(bmpaux, VScrollBar1.Value, VScrollBar2.Value)
        Else

            Me.PictureBox1.Image = objeto.degradadoVertical(bmpaux, VScrollBar1.Value, -VScrollBar2.Value)
        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        aceptar = True 'Usuario acepta
        degH = HScrollBar1.Value
        degH1 = HScrollBar2.Value
        degV = VScrollBar1.Value
        degV1 = VScrollBar2.Value
        Me.Close()
    End Sub



    Private Sub Degradador_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        HScrollBar1.Value = 0
        HScrollBar2.Value = 100
        VScrollBar1.Value = 0
        VScrollBar2.Value = 100
        Label3.Text = 0
        Label4.Text = 100
        Label7.Text = 0
        Label8.Text = 100
        Dim objeto As New tratamiento
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = objeto.degradadoHorizontal(bmpaux, HScrollBar1.Value, HScrollBar2.Value)
        Dim bmpaux2 As New Bitmap(bmpaux)
        Me.PictureBox1.Image = objeto.degradadoVerticalInvertido(bmpaux, VScrollBar1.Value, VScrollBar2.Value)
    End Sub

    Private Sub HScrollBar1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Label3.Text = HScrollBar1.Value
    End Sub

    Private Sub HScrollBar2_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar2.Scroll
        Label4.Text = HScrollBar2.Value
    End Sub

    Private Sub VScrollBar1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar1.Scroll
        Label7.Text = VScrollBar1.Value
    End Sub

    Private Sub VScrollBar2_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles VScrollBar2.Scroll
        Label8.Text = VScrollBar2.Value
    End Sub
End Class