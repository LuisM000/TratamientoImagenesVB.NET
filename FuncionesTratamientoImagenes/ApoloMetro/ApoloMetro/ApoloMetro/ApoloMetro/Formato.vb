Imports WindowsApplication1.Class1

Public Class Formato


    Private Sub Label5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseEnter
        Label5.ForeColor = Color.White
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Label5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseLeave
        Label5.ForeColor = Color.Black
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        Label1.ForeColor = Color.White
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Black
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Label2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseEnter
        Label2.ForeColor = Color.White
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        Label2.ForeColor = Color.Black
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Label4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseEnter
        Label4.ForeColor = Color.White
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Label4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseLeave
        Label4.ForeColor = Color.Black
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Label6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseEnter
        Label6.ForeColor = Color.White
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Label6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseLeave
        Label6.ForeColor = Color.Black
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.ImageLocation = "imagenes\white\back.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.ImageLocation = "imagenes\black\back.png"
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        Dim objeto As New tratamiento
        Dim bmp As New Bitmap(ruta)
        objeto.guardarcomo(bmp, 5)
    End Sub
    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Dim objeto As New tratamiento
        Dim bmp As New Bitmap(ruta)
        objeto.guardarcomo(bmp, 1)
    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Dim objeto As New tratamiento
        Dim bmp As New Bitmap(ruta)
        objeto.guardarcomo(bmp, 3)
    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        Dim objeto As New tratamiento
        Dim bmp As New Bitmap(ruta)
        objeto.guardarcomo(bmp, 2)
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        Dim objeto As New tratamiento
        Dim bmp As New Bitmap(ruta)
        objeto.guardarcomo(bmp, 4)
    End Sub
    Private Sub Formato_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Point(69, 301)
        Timer1.Enabled = True
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Timer2.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Width < 340 Then
            Me.Width = Me.Width + 10
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.Width > 2 Then
            Me.Width = Me.Width - 10
        Else
            Me.Close()
            Timer2.Enabled = False
            Eleccion.Visible = True
        End If
    End Sub

End Class