Imports WindowsApplication1.Class1

Public Class Exposicion

    Private Sub HScrollBar1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Label1.Text = HScrollBar1.Value / 1000
    End Sub

    Private Sub Exposicion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        HScrollBar1.Value = 1000
        Label1.Text = 1
        Dim objeto As New tratamiento 'Cargamos la imagen con umbral 128 
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = objeto.exposicion(bmpaux, 1)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim objeto As New tratamiento 'Vista previa
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        PictureBox1.Image = objeto.exposicion(bmpaux, HScrollBar1.Value / 1000)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        aceptar = True 'Usuario acepta
        valorexposi = HScrollBar1.Value / 1000 'Guardamos valo
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class