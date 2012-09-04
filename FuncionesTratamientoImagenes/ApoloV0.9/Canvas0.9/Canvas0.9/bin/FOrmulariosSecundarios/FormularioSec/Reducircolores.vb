Imports WindowsApplication1.Class1

Public Class Reducircolores

    Private Sub Reducircolores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        HScrollBar1.Value = 256
        Label2.Text = 256
        Dim objeto As New tratamiento 'Cargamos la imagen con umbral 128 
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        If formucolores = True Then
            Me.Text = "Reducir colores"
            Me.PictureBox1.Image = bmpaux
        Else
            Me.Text = "Reducir colores grises"
            Me.PictureBox1.Image = objeto.reducircoloresgris(bmpaux, 0)
        End If

        
        Me.PictureBox1.Image = bmpaux
    End Sub

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Label2.Text = HScrollBar1.Value
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        aceptar = True 'Usuario acepta
        valorcolor = (256 - HScrollBar1.Value) / 2
        If valorcolor Mod 2 <> 0 Then valorcolor = valorcolor - 1
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim objeto As New tratamiento 'Vista previa
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Dim valorc As Integer
        valorc = (256 - HScrollBar1.Value) / 2
        If valorc Mod 2 <> 0 Then valorc = valorc - 1
        If formucolores = True Then
            Me.PictureBox1.Image = objeto.reducircolores(bmpaux, valorc)
        Else
            Me.PictureBox1.Image = objeto.reducircoloresgris(bmpaux, valorc)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close() 'Usuario declina
    End Sub
End Class