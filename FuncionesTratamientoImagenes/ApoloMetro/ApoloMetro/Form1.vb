Imports WindowsApplication1.Class1
Public Class Form1

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.ImageLocation = "imagenes\white\folder.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.ImageLocation = "imagenes\black\folder.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        PictureBox2.ImageLocation = "imagenes\white\cancel.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.ImageLocation = "imagenes\black\cancel.png"
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub PictureBox4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseEnter
        PictureBox4.ImageLocation = "imagenes\white\check.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.ImageLocation = "imagenes\black\check.png"
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Me.Close()
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        Dim objeto As New tratamiento
        ruta = objeto.abirImagen()
        Me.Size = New Point(199, 73)
        If ruta <> "-1" Then
            'Me.Visible = False
            'RutaEle.ShowDialog()
            Timer1.Enabled = True

        End If
        Dim posicion As Double
        Label1.Text = objeto.extraenombre(ruta)
        posicion = (Me.Width / 2) - (Label1.Width / 2)
        Label1.Left = posicion
    End Sub
 
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = True
        Me.Size = New Point(199, 73)
        Timer1.Enabled = False

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Height < 180 Then
            Me.Height = Me.Size.Height + 10
        Else
            Timer1.Enabled = False
        End If
    End Sub

   
   
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Timer2.Enabled = True
    End Sub

    Private Sub Form1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Me.Size = New Point(199, 73)
        Timer1.Enabled = False
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.Height > 65 Then
            Me.Height = Me.Height - 10
        Else
            Me.Visible = False
            Eleccion.Show()
            Timer2.Enabled = False
        End If
    End Sub
End Class
