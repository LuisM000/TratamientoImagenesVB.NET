Public Class Redimensionar
    Dim pulsado As Integer



    Private Sub Redimensionar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim bmp As New Bitmap(ruta)
        Label1.Text = bmp.Width
        Label2.Text = bmp.Height
        Label3.Text = "Tamaño original (" + Label1.Text + "x" + Label2.Text + ")"
        Me.Size = New Size(69, 224)
        Timer5.Enabled = True
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Timer6.Enabled = True
    End Sub
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        If Label1.Text <= 0 Or Label2.Text < 0 Then
            PictureBox2.ImageLocation = "imagenes\white\cancel.png"
        Else
            Timer7.Enabled = True
            redimens = True
            anchoRed = Label1.Text
            altoRed = Label2.Text
        End If
        
    End Sub



    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.ImageLocation = "imagenes\white\back.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.ImageLocation = "imagenes\black\back.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        PictureBox2.ImageLocation = "imagenes\white\check.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.ImageLocation = "imagenes\black\check.png"
        Me.Cursor = Cursors.Default
    End Sub



    Private Sub PictureBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.ImageLocation = "imagenes\white\minus.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.ImageLocation = "imagenes\black\minus.png"
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub PictureBox5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseEnter
        PictureBox5.ImageLocation = "imagenes\white\minus.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        PictureBox5.ImageLocation = "imagenes\black\minus.png"
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub PictureBox4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseEnter
        PictureBox4.ImageLocation = "imagenes\white\add.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.ImageLocation = "imagenes\black\add.png"
        Me.Cursor = Cursors.Default
    End Sub

     

    Private Sub PictureBox6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseEnter
        PictureBox6.ImageLocation = "imagenes\white\add.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.ImageLocation = "imagenes\black\add.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseUp
        Dim ancho As Integer
        ancho = Label1.Text
        ancho -= 1
        Label1.Text = ancho
        Timer3.Enabled = False
        pulsado = 0
    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        Dim ancho As Integer
        ancho = Label1.Text
        ancho += 1
        Label1.Text = ancho
        Timer1.Enabled = False
        pulsado = 0
    End Sub

    Private Sub PictureBox5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseUp
        Dim alto As Integer
        alto = Label2.Text
        alto -= 1
        Label2.Text = alto
        Timer4.Enabled = False
        pulsado = 0
    End Sub

    Private Sub PictureBox6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseUp
        Dim alto As Integer
        alto = Label2.Text
        alto += 1
        Label2.Text = alto
        Timer2.Enabled = False
        pulsado = 0
    End Sub


    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        Timer1.Interval = 100
        Timer1.Enabled = True
    End Sub

    Private Sub PictureBox6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseDown
        Timer2.Interval = 100
        Timer2.Enabled = True
    End Sub

    Private Sub PictureBox3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseDown
        Timer3.Interval = 100
        Timer3.Enabled = True
    End Sub

    Private Sub PictureBox5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseDown
        Timer4.Interval = 100
        Timer4.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim ancho As Integer
            ancho = Label1.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer1.Interval = 10
            End If
            If pulsado > 200 Then
                ancho += 9
            End If
            ancho += 1
            Label1.Text = ancho

        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim ancho As Integer
            ancho = Label2.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer2.Interval = 10
            End If
            If pulsado > 200 Then
                ancho += 9
            End If
            ancho += 1
            Label2.Text = ancho

        End If

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim ancho As Integer
            ancho = Label1.Text

            pulsado += 1
            If pulsado > 10 Then
                Timer3.Interval = 10
            End If
            If pulsado > 200 Then
                ancho -= 9
            End If
            ancho -= 1
            Label1.Text = ancho

        End If

    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim ancho As Integer
            ancho = Label2.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer4.Interval = 10
            End If
            If pulsado > 200 Then
                ancho -= 9
            End If
            ancho -= 1
            Label2.Text = ancho

        End If

    End Sub

    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        If Me.Width < 370 Then
            Me.Width = Me.Width + 10
        Else
            Timer5.Enabled = False
        End If
    End Sub

    
    Private Sub Timer6_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer6.Tick
        If Me.Width > 2 Then
            Me.Width = Me.Width - 10
        Else
            Me.Close()
            Timer6.Enabled = False
            Eleccion.Show()
        End If
    End Sub

 
    Private Sub Timer7_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer7.Tick
        If Me.Width > 2 Then
            Me.Width = Me.Width - 10
        Else
            Me.Close()
            Timer7.Enabled = False
            Guardar.Show()
        End If
    End Sub

    
End Class