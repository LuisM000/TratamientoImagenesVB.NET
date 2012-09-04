Imports WindowsApplication1.Class1

Public Class Afin

    Dim objeto As New tratamiento
    Dim pulsado As Integer
   
    Private Sub Afin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Point(69, 700)
        Timer2.Enabled = True
        Dim bmp As New Bitmap(ruta)
        PictureBox1.Image = bmp
        PictureBox2.Image = bmp
        PictureBox1.Visible = True
        Panel1.AutoScroll = True
        Panel1.AutoScrollMinSize = PictureBox1.Image.Size

    End Sub



    Private Sub PictureBox17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox17.Click
        If Label13.ForeColor <> Color.Red And Label11.ForeColor <> Color.Red And Label2.ForeColor <> Color.Red And Label8.ForeColor <> Color.Red And Label1.ForeColor <> Color.Red And Label3.ForeColor <> Color.Red And Label4.ForeColor <> Color.Red Then
            Dim giro = Label13.Text
            Dim tranX = Label8.Text
            Dim tranY = Label1.Text
            Dim escX = Label11.Text
            Dim escY = Label2.Text

            Dim G As Graphics
            Try
                Dim bmp As New Bitmap(CInt(Label4.Text), CInt(Label3.Text))
                Dim img As Image
                img = CType(bmp, Image)
                PictureBox2.Image = img
                G = Graphics.FromImage(bmp)
                'Borra la Matriz de transformación
                G.ResetTransform()
                Dim TAfin As New Drawing2D.Matrix
                TAfin.Translate(tranX, tranY)
                TAfin.Scale(escX, escY)
                TAfin.Rotate(giro)
                G.Transform = TAfin
                G.DrawImage(PictureBox1.Image, New PointF(0, 0))
                PictureBox2.Refresh()
                Panel1.AutoScrollMinSize = PictureBox2.Image.Size
                PictureBox1.Visible = False
            Catch
                MessageBox.Show("El tamaño de la imagen de salida no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try

            Panel1.AutoScrollMinSize = PictureBox2.Image.Size
            Panel1.AutoScroll = True
        Else
            PictureBox17.ImageLocation = "imagenes\white\cancel.png"
        End If

    End Sub

    Private Sub PictureBox19_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox19.MouseEnter
        PictureBox19.ImageLocation = "imagenes\white\save.png"
        Me.Cursor = Cursors.Hand
    End Sub


    Private Sub PictureBox19_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox19.MouseLeave
        PictureBox19.ImageLocation = "imagenes\black\save.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox18_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox18.MouseEnter
        PictureBox18.ImageLocation = "imagenes\white\back.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox18_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox18.MouseLeave
        PictureBox18.ImageLocation = "imagenes\black\back.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox17_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox17.MouseEnter
        PictureBox17.ImageLocation = "imagenes\white\check.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox17_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox17.MouseLeave
        PictureBox17.ImageLocation = "imagenes\black\check.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox10_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseEnter
        PictureBox10.ImageLocation = "imagenes\white\minus.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox10_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseLeave
        PictureBox10.ImageLocation = "imagenes\black\minus.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseEnter
        PictureBox6.ImageLocation = "imagenes\white\minus.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.ImageLocation = "imagenes\black\minus.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox11_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox11.MouseEnter
        PictureBox11.ImageLocation = "imagenes\white\minus.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox11_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox11.MouseLeave
        PictureBox11.ImageLocation = "imagenes\black\minus.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox8_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseEnter
        PictureBox8.ImageLocation = "imagenes\white\minus.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseLeave
        PictureBox8.ImageLocation = "imagenes\black\minus.png"
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

    Private Sub PictureBox16_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox16.MouseEnter
        PictureBox16.ImageLocation = "imagenes\white\minus.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox16_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox16.MouseLeave
        PictureBox16.ImageLocation = "imagenes\black\minus.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox14_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox14.MouseEnter
        PictureBox14.ImageLocation = "imagenes\white\minus.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox14_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox14.MouseLeave
        PictureBox14.ImageLocation = "imagenes\black\minus.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox9_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox9.MouseEnter
        PictureBox9.ImageLocation = "imagenes\white\add.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox9.MouseLeave
        PictureBox9.ImageLocation = "imagenes\black\add.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseEnter
        PictureBox5.ImageLocation = "imagenes\white\add.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        PictureBox5.ImageLocation = "imagenes\black\add.png"
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

    Private Sub PictureBox7_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseEnter
        PictureBox7.ImageLocation = "imagenes\white\add.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseLeave
        PictureBox7.ImageLocation = "imagenes\black\add.png"
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub PictureBox12_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox12.MouseEnter
        PictureBox12.ImageLocation = "imagenes\white\add.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox12_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox12.MouseLeave
        PictureBox12.ImageLocation = "imagenes\black\add.png"
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub PictureBox15_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox15.MouseEnter
        PictureBox15.ImageLocation = "imagenes\white\add.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox15_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox15.MouseLeave
        PictureBox15.ImageLocation = "imagenes\black\add.png"
        Me.Cursor = Cursors.Default
    End Sub

    
    Private Sub PictureBox13_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox13.MouseEnter
        PictureBox13.ImageLocation = "imagenes\white\add.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox13_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox13.MouseLeave
        PictureBox13.ImageLocation = "imagenes\black\add.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox18.Click
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Width > 2 Then
            Me.Width = Me.Width - 15
        Else
            Me.Close()
            Timer1.Enabled = False
            Eleccion.Show()
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.Width < 1102 Then
            Me.Width = Me.Width + 15
        Else
            Timer2.Enabled = False
        End If
    End Sub



    Private Sub PictureBox10_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox10.MouseUp
        Dim giromenos As Integer
        giromenos = Label13.Text
        giromenos -= 1
        Label13.Text = giromenos
        Timer3.Enabled = False
        pulsado = 0
    End Sub

    Private Sub PictureBox10_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox10.MouseDown
        Timer3.Interval = 100
        Timer3.Enabled = True
    End Sub

    Private Sub PictureBox9_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox9.MouseUp
        Dim giromas As Integer
        giromas = Label13.Text
        giromas += 1
        Label13.Text = giromas
        Timer5.Enabled = False
        pulsado = 0
    End Sub

    Private Sub PictureBox9_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox9.MouseDown
        Timer5.Interval = 100
        Timer5.Enabled = True
    End Sub
    Private Sub PictureBox6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseUp
        Dim escalamenos As Double
        escalamenos = Label11.Text
        escalamenos -= 0.1
        Label11.Text = escalamenos
        Timer6.Enabled = False
        pulsado = 0
    End Sub

    Private Sub PictureBox6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseDown
        Timer6.Interval = 100
        Timer6.Enabled = True
    End Sub

    Private Sub PictureBox8_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox8.MouseUp
        Dim escalamenos As Double
        escalamenos = Label2.Text
        escalamenos -= 0.1
        Label2.Text = escalamenos
        Timer7.Enabled = False
        pulsado = 0
    End Sub

    Private Sub PictureBox8_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox8.MouseDown
        Timer7.Interval = 100
        Timer7.Enabled = True
    End Sub

    Private Sub PictureBox5_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseDown
        Timer8.Interval = 100
        Timer8.Enabled = True
    End Sub

    Private Sub PictureBox5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox5.MouseUp
        Dim escalamas As Double
        escalamas = Label11.Text
        escalamas += 0.1
        Label11.Text = escalamas
        Timer8.Enabled = False
        pulsado = 0
    End Sub

    Private Sub PictureBox7_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox7.MouseDown
        Timer9.Interval = 100
        Timer9.Enabled = True
    End Sub

    Private Sub PictureBox7_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox7.MouseUp
        Dim escalamas As Double
        escalamas = Label2.Text
        escalamas += 0.1
        Label2.Text = escalamas
        Timer9.Enabled = False
        pulsado = 0
    End Sub
    Private Sub PictureBox11_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox11.MouseDown
        Timer10.Interval = 100
        Timer10.Enabled = True
    End Sub

    Private Sub PictureBox11_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox11.MouseUp
        Dim trasmenos As Double
        trasmenos = Label8.Text
        trasmenos -= 1
        Label8.Text = trasmenos
        Timer10.Enabled = False
        pulsado = 0
    End Sub

    Private Sub PictureBox3_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseDown
        Timer11.Interval = 100
        Timer11.Enabled = True
    End Sub
    Private Sub PictureBox3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox3.MouseUp
        Dim trasmenos As Double
        trasmenos = Label1.Text
        trasmenos -= 1
        Label1.Text = trasmenos
        Timer11.Enabled = False
        pulsado = 0
    End Sub
    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        Timer12.Interval = 100
        Timer12.Enabled = True
    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        Dim trasmas As Double
        trasmas = Label8.Text
        trasmas += 1
        Label8.Text = trasmas
        Timer12.Enabled = False
        pulsado = 0
    End Sub

    Private Sub PictureBox12_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox12.MouseDown
        Timer13.Interval = 100
        Timer13.Enabled = True
    End Sub

    Private Sub PictureBox12_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox12.MouseUp
        Dim trasmas As Double
        trasmas = Label1.Text
        trasmas += 1
        Label1.Text = trasmas
        Timer13.Enabled = False
        pulsado = 0
    End Sub

    Private Sub PictureBox16_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox16.MouseDown
        Timer14.Interval = 100
        Timer14.Enabled = True
    End Sub

    Private Sub PictureBox16_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox16.MouseUp
        Dim tammenos As Double
        tammenos = Label4.Text
        tammenos -= 1
        Label4.Text = tammenos
        Timer14.Enabled = False
        pulsado = 0
    End Sub

    Private Sub PictureBox14_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox14.MouseDown
        Timer15.Interval = 100
        Timer15.Enabled = True
    End Sub

    Private Sub PictureBox14_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox14.MouseUp
        Dim tammenos As Double
        tammenos = Label3.Text
        tammenos -= 1
        Label3.Text = tammenos
        Timer15.Enabled = False
        pulsado = 0
    End Sub
    Private Sub PictureBox15_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox15.MouseDown
        Timer16.Interval = 100
        Timer16.Enabled = True
    End Sub

    Private Sub PictureBox15_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox15.MouseUp
        Dim tammenos As Double
        tammenos = Label4.Text
        tammenos += 1
        Label4.Text = tammenos
        Timer16.Enabled = False
        pulsado = 0
    End Sub
    Private Sub PictureBox13_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox13.MouseDown
        Timer17.Interval = 100
        Timer17.Enabled = True
    End Sub

    Private Sub PictureBox13_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox13.MouseUp
        Dim tammenos As Double
        tammenos = Label3.Text
        tammenos += 1
        Label3.Text = tammenos
        Timer17.Enabled = False
        pulsado = 0
    End Sub
    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim giromenos As Integer
            giromenos = Label13.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer3.Interval = 50
            End If
            giromenos -= 1
            Label13.Text = giromenos

        End If
    End Sub

    Private Sub Timer5_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer5.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim giromas As Integer
            giromas = Label13.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer5.Interval = 50
            End If
            giromas += 1
            Label13.Text = giromas

        End If
    End Sub

    Private Sub Timer6_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer6.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim escamenos As Double
            escamenos = Label11.Text
            pulsado += 1
            escamenos -= 0.1
            Label11.Text = escamenos
        End If
    End Sub
    Private Sub Timer7_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer7.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim escamenos As Double
            escamenos = Label2.Text
            pulsado += 1
            escamenos -= 0.1
            Label2.Text = escamenos
        End If
    End Sub

    Private Sub Timer8_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer8.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim escamenos As Double
            escamenos = Label11.Text
            pulsado += 1
            escamenos += 0.1
            Label11.Text = escamenos
        End If
    End Sub


    Private Sub Timer9_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer9.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim escamenos As Double
            escamenos = Label2.Text
            pulsado += 1
            escamenos += 0.1
            Label2.Text = escamenos
        End If
    End Sub

    Private Sub Timer10_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer10.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim trasmenos As Integer
            trasmenos = Label8.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer10.Interval = 10
            End If
            If pulsado > 200 Then
                trasmenos -= 9
            End If
            trasmenos -= 1
            Label8.Text = trasmenos
        End If
    End Sub

    Private Sub Timer11_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer11.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim trasmenos As Integer
            trasmenos = Label1.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer11.Interval = 10
            End If
            If pulsado > 200 Then
                trasmenos -= 9
            End If
            trasmenos -= 1
            Label1.Text = trasmenos
        End If
    End Sub

    Private Sub Timer12_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer12.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim trasmas As Integer
            trasmas = Label8.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer12.Interval = 10
            End If
            If pulsado > 200 Then
                trasmas += 9
            End If
            trasmas += 1
            Label8.Text = trasmas
        End If
    End Sub

    Private Sub Timer13_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer13.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim trasmas As Integer
            trasmas = Label1.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer13.Interval = 10
            End If
            If pulsado > 200 Then
                trasmas += 9
            End If
            trasmas += 1
            Label1.Text = trasmas
        End If
    End Sub

    Private Sub Timer14_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer14.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim tammenos As Integer
            tammenos = Label4.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer14.Interval = 10
            End If
            If pulsado > 200 Then
                tammenos -= 9
            End If
            tammenos -= 1
            Label4.Text = tammenos
        End If
    End Sub

    Private Sub Timer15_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer15.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim tammenos As Integer
            tammenos = Label3.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer15.Interval = 10
            End If
            If pulsado > 200 Then
                tammenos -= 9
            End If
            tammenos -= 1
            Label3.Text = tammenos
        End If
    End Sub

    Private Sub Timer16_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer16.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim tammenos As Integer
            tammenos = Label4.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer16.Interval = 10
            End If
            If pulsado > 200 Then
                tammenos += 9
            End If
            tammenos += 1
            Label4.Text = tammenos
        End If
    End Sub

    Private Sub Timer17_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer17.Tick
        If pulsado = 0 Then
            pulsado += 1
        Else
            Dim tammenos As Integer
            tammenos = Label3.Text
            pulsado += 1
            If pulsado > 10 Then
                Timer17.Interval = 10
            End If
            If pulsado > 200 Then
                tammenos += 9
            End If
            tammenos += 1
            Label3.Text = tammenos
        End If
    End Sub

    Private Sub Timer4_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer4.Tick
        If CInt(Label13.Text) > 360 Or CInt(Label13.Text) < 0 Then
            Label13.ForeColor = Color.Red
        Else
            Label13.ForeColor = Color.Black
        End If
        If Label11.Text > 5 Or Label11.Text < 0 Then
            Label11.ForeColor = Color.Red
        Else
            Label11.ForeColor = Color.Black
        End If
        If Label2.Text > 5 Or Label2.Text < 0 Then
            Label2.ForeColor = Color.Red
        Else
            Label2.ForeColor = Color.Black
        End If
        If Label8.Text > 5000 Or Label8.Text < 0 Then
            Label8.ForeColor = Color.Red
        Else
            Label8.ForeColor = Color.Black
        End If
        If Label1.Text > 5000 Or Label1.Text < 0 Then
            Label1.ForeColor = Color.Red
        Else
            Label1.ForeColor = Color.Black
        End If
        If Label4.Text > 5000 Or Label4.Text < 0 Then
            Label4.ForeColor = Color.Red
        Else
            Label4.ForeColor = Color.Black
        End If
        If Label3.Text > 5000 Or Label3.Text < 0 Then
            Label3.ForeColor = Color.Red
        Else
            Label3.ForeColor = Color.Black
        End If

    End Sub

   
    Private Sub PictureBox19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox19.Click
        Dim objeto As New tratamiento
        Dim bmp As New Bitmap(PictureBox2.Image)
        objeto.guardarcomo(bmp)
    End Sub
End Class