Public Class Juego
    Public checSeec As Byte
    'Private Function GetHexColor(ByVal colorObj As System.Drawing.Color) As String
    '    Return "#" & Hex(colorObj.R) & Hex(colorObj.G) & Hex(colorObj.B)
    'End Function
    Private Function Aleatorio(ByVal Minimo As Long, ByVal Maximo As Long) As Long
        Randomize() ' inicializar la semilla  
        Aleatorio = CLng((Minimo - Maximo) * Rnd() + Maximo)
    End Function
    Sub CheckAleat()
        Dim contador As Byte
        contador = Aleatorio(1, 4)
        Dim check As String
        check = "CheckBox" + contador.ToString
        Select Case check
            Case "CheckBox1"
                CheckBox1.Text = Aleatorio(0, 255) & "/" & Aleatorio(0, 255) & "/" & Aleatorio(0, 255)
            Case "CheckBox2"
                CheckBox2.Text = Aleatorio(0, 255) & "/" & Aleatorio(0, 255) & "/" & Aleatorio(0, 255)
            Case "CheckBox3"
                CheckBox3.Text = Aleatorio(0, 255) & "/" & Aleatorio(0, 255) & "/" & Aleatorio(0, 255)
            Case "CheckBox4"
                CheckBox4.Text = Aleatorio(0, 255) & "/" & Aleatorio(0, 255) & "/" & Aleatorio(0, 255)
        End Select

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PictureBox1.Image = Nothing
        CheckBox1.Text = "" : CheckBox2.Text = "" : CheckBox3.Text = "" : CheckBox4.Text = ""
        CheckBox1.Checked = False : CheckBox2.Checked = False : CheckBox3.Checked = False : CheckBox4.Checked = False
        Dim ColorFondo As Color = Color.FromArgb(Aleatorio(0, 255), Aleatorio(0, 255), Aleatorio(0, 255))
        Dim colorVerdadero() As Byte = {ColorFondo.R, ColorFondo.G, ColorFondo.B}
        PictureBox1.BackColor = ColorFondo
        While CheckBox1.Text = ""
            CheckAleat()
        End While
        While CheckBox2.Text = ""
            CheckAleat()
        End While
        While CheckBox3.Text = ""
            CheckAleat()
        End While
        While CheckBox4.Text = ""
            CheckAleat()
        End While
        Dim original As Byte
        original = Aleatorio(1, 4)
        Select Case original.ToString
            Case "1"
                CheckBox1.Text = colorVerdadero(0) & "/" & colorVerdadero(1) & "/" & colorVerdadero(2)
            Case "2"
                CheckBox2.Text = colorVerdadero(0) & "/" & colorVerdadero(1) & "/" & colorVerdadero(2)
            Case "3"
                CheckBox3.Text = colorVerdadero(0) & "/" & colorVerdadero(1) & "/" & colorVerdadero(2)
            Case "4"
                CheckBox4.Text = colorVerdadero(0) & "/" & colorVerdadero(1) & "/" & colorVerdadero(2)
        End Select
        checSeec = original
    End Sub



    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1_Click(sender, e)
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If checSeec = 1 And CheckBox1.Checked = True Then
            Dim bmp As New Bitmap("win.gif")
            Dim bmp2 As New Bitmap(bmp, New Size(PictureBox1.Width, PictureBox1.Height))
            PictureBox1.Image = bmp2
            CheckBox3.Enabled = False
            CheckBox2.Enabled = False
            CheckBox4.Enabled = False
            CheckBox1.AutoCheck = False
            Button1.Enabled = True
        Else

            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If checSeec = 2 And CheckBox2.Checked = True Then
            Dim bmp As New Bitmap("win.gif")
            Dim bmp2 As New Bitmap(bmp, New Size(PictureBox1.Width, PictureBox1.Height))
            PictureBox1.Image = bmp2
            CheckBox1.Enabled = False
            CheckBox3.Enabled = False
            CheckBox4.Enabled = False
            CheckBox2.AutoCheck = False
            Button1.Enabled = True
        Else

            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If checSeec = 3 And CheckBox3.Checked = True Then
            Dim bmp As New Bitmap("win.gif")
            Dim bmp2 As New Bitmap(bmp, New Size(PictureBox1.Width, PictureBox1.Height))
            PictureBox1.Image = bmp2
            CheckBox1.Enabled = False
            CheckBox2.Enabled = False
            CheckBox4.Enabled = False
            CheckBox3.AutoCheck = False
            Button1.Enabled = True
        Else

            Button1_Click(sender, e)
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If checSeec = 4 And CheckBox4.Checked = True Then
            Dim bmp As New Bitmap("win.gif")
            Dim bmp2 As New Bitmap(bmp, New Size(PictureBox1.Width, PictureBox1.Height))
            PictureBox1.Image = bmp2
            CheckBox1.Enabled = False
            CheckBox3.Enabled = False
            CheckBox2.Enabled = False
            CheckBox4.AutoCheck = False
            Button1.Enabled = True
        Else

            Button1_Click(sender, e)
        End If
    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
        Button1.Enabled = False
        CheckBox1.Enabled = True
        CheckBox3.Enabled = True
        CheckBox2.Enabled = True
        CheckBox4.Enabled = True
        CheckBox1.AutoCheck = True
        CheckBox3.AutoCheck = True
        CheckBox2.AutoCheck = True
        CheckBox4.AutoCheck = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MessageBox.Show("Seleccione la combinación RGB correcta para poder continuar", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
End Class
