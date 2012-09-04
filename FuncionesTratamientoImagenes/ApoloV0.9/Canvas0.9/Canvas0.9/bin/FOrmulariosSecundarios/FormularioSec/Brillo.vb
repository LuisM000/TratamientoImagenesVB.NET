Imports WindowsApplication1.Class1

Public Class Brillo


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        aceptar = True 'Usuario acepta
        valorumbral = HScrollBar1.Value 'Guardamos valo
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim objeto As New tratamiento 'Vista previa
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        If HScrollBar1.Value < 0 Then
            Me.PictureBox1.Image = objeto.disminuirbrillo(bmpaux, -HScrollBar1.Value)
        Else
            Me.PictureBox1.Image = objeto.aumentarbrillo(bmpaux, HScrollBar1.Value)
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close() 'Usuario declina
    End Sub

    Private Sub BlancoNegroM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        HScrollBar1.Value = 0
        Dim objeto As New tratamiento 'Cargamos la imagen con umbral 128 
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = objeto.aumentarbrillo(bmpaux, 0)
    End Sub

    Private Sub HScrollBar1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Label1.Text = HScrollBar1.Value
    End Sub

    Private Sub TableLayoutPanel2_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel2.Paint

    End Sub

    Private Sub PictureBox1_Click(sender As System.Object, e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub
End Class