Imports WindowsApplication1.Class1
Public Class Efectos

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.ImageLocation = "imagenes\white\back.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.ImageLocation = "imagenes\black\back.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Timer1.Enabled = True
    End Sub

    Private Sub Efectos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Size = New Point(69, 562)
        Timer2.Enabled = True
        PictureBox2.ImageLocation = ruta
        Dim bmp As New Bitmap(ruta)
        Dim bmp2 As New Bitmap(bmp, New Size(New Point(150, 75)))
        Dim objeto As New tratamiento
        PictureBox3.Image = objeto.Oleo(bmp2, 28, 80)
        Dim bmp3 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox4.Image = objeto.grises(bmp3)
        Dim bmp4 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox5.Image = objeto.sepia(bmp4)
        Dim bmp5 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox6.Image = objeto.contornos(bmp5, 30)
        Dim bmp6 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox7.Image = objeto.mosaico(bmp6, 3, 3)
        Dim bmp7 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox8.Image = objeto.reducircolores(bmp7, 50)
        Dim bmp8 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox9.Image = objeto.etiopia(bmp8, True)
        Dim bmp9 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox10.Image = objeto.invertir(bmp9)
        Dim bmp10 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox11.Image = objeto.blanconegro(bmp10)
        Dim bmp11 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox12.Image = objeto.RGBtoBGR(bmp11)
        Dim bmp12 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox13.Image = objeto.RGBtoGRB(bmp12)
        Dim bmp13 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox14.Image = objeto.RGBtoRBG(bmp13)
        Dim bmp14 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox15.Image = objeto.pixelarX3(bmp14)
        Dim bmp15 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox16.Image = objeto.desenfoqueHorVert(bmp15, 4, 4)
        Dim bmp16 As New Bitmap(bmp, New Size(New Point(150, 75)))
        PictureBox17.Image = objeto.desierto(bmp16)

    End Sub

    Private Sub PictureBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        Me.Cursor = Cursors.Hand
        Label1.ForeColor = Color.White
        Label1.Font = New Font(Label1.Font, FontStyle.Bold)
    End Sub
    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        Me.Cursor = Cursors.Default
        Label1.ForeColor = Color.Black
        Label1.Font = New Font(Label1.Font, FontStyle.Regular)
    End Sub
    Private Sub PictureBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        Me.Cursor = Cursors.Hand
        Label2.ForeColor = Color.White
        Label2.Font = New Font(Label2.Font, FontStyle.Bold)
    End Sub
    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        Me.Cursor = Cursors.Default
        Label2.ForeColor = Color.Black
        Label2.Font = New Font(Label2.Font, FontStyle.Regular)
    End Sub
    Private Sub PictureBox4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseEnter
        Me.Cursor = Cursors.Hand
        Label3.ForeColor = Color.White
        Label3.Font = New Font(Label3.Font, FontStyle.Bold)
    End Sub
    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        Me.Cursor = Cursors.Default
        Label3.ForeColor = Color.Black
        Label3.Font = New Font(Label3.Font, FontStyle.Regular)
    End Sub
    Private Sub PictureBox5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseEnter
        Me.Cursor = Cursors.Hand
        Label8.ForeColor = Color.White
        Label8.Font = New Font(Label8.Font, FontStyle.Bold)
    End Sub
    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        Me.Cursor = Cursors.Default
        Label8.ForeColor = Color.Black
        Label8.Font = New Font(Label8.Font, FontStyle.Regular)
    End Sub
    Private Sub Picturebox6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseEnter
        Me.Cursor = Cursors.Hand
        Label7.ForeColor = Color.White
        Label7.Font = New Font(Label7.Font, FontStyle.Bold)
    End Sub
    Private Sub Picturebox6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseLeave
        Me.Cursor = Cursors.Default
        Label7.ForeColor = Color.Black
        Label7.Font = New Font(Label7.Font, FontStyle.Regular)
    End Sub

    Private Sub Picturebox7_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseEnter
        Me.Cursor = Cursors.Hand
        Label6.ForeColor = Color.White
        Label6.Font = New Font(Label6.Font, FontStyle.Bold)
    End Sub
    Private Sub Picturebox7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox7.MouseLeave
        Me.Cursor = Cursors.Default
        Label6.ForeColor = Color.Black
        Label6.Font = New Font(Label6.Font, FontStyle.Regular)
    End Sub
    Private Sub Picturebox8_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseEnter
        Me.Cursor = Cursors.Hand
        Label16.ForeColor = Color.White
        Label16.Font = New Font(Label16.Font, FontStyle.Bold)
    End Sub
    Private Sub Picturebox8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox8.MouseLeave
        Me.Cursor = Cursors.Default
        Label16.ForeColor = Color.Black
        Label16.Font = New Font(Label16.Font, FontStyle.Regular)
    End Sub
    Private Sub Picturebox9_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox9.MouseEnter
        Me.Cursor = Cursors.Hand
        Label15.ForeColor = Color.White
        Label15.Font = New Font(Label15.Font, FontStyle.Bold)
    End Sub
    Private Sub Picturebox9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox9.MouseLeave
        Me.Cursor = Cursors.Default
        Label15.ForeColor = Color.Black
        Label15.Font = New Font(Label15.Font, FontStyle.Regular)
    End Sub
    Private Sub Picturebox10_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseEnter
        Me.Cursor = Cursors.Hand
        Label14.ForeColor = Color.White
        Label14.Font = New Font(Label14.Font, FontStyle.Bold)
    End Sub
    Private Sub Picturebox10_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseLeave
        Me.Cursor = Cursors.Default
        Label14.ForeColor = Color.Black
        Label14.Font = New Font(Label14.Font, FontStyle.Regular)
    End Sub
    Private Sub Picturebox11_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox11.MouseEnter
        Me.Cursor = Cursors.Hand
        Label4.ForeColor = Color.White
        Label4.Font = New Font(Label4.Font, FontStyle.Bold)
    End Sub
    Private Sub Picturebox11_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox11.MouseLeave
        Me.Cursor = Cursors.Default
        Label4.ForeColor = Color.Black
        Label4.Font = New Font(Label4.Font, FontStyle.Regular)
    End Sub
    Private Sub Picturebox12_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox12.MouseEnter
        Me.Cursor = Cursors.Hand
        Label5.ForeColor = Color.White
        Label5.Font = New Font(Label5.Font, FontStyle.Bold)
    End Sub
    Private Sub Picturebox12_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox12.MouseLeave
        Me.Cursor = Cursors.Default
        Label5.ForeColor = Color.Black
        Label5.Font = New Font(Label5.Font, FontStyle.Regular)
    End Sub
    Private Sub Picturebox13_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox13.MouseEnter
        Me.Cursor = Cursors.Hand
        Label13.ForeColor = Color.White
        Label13.Font = New Font(Label13.Font, FontStyle.Bold)
    End Sub
    Private Sub Picturebox13_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox13.MouseLeave
        Me.Cursor = Cursors.Default
        Label13.ForeColor = Color.Black
        Label13.Font = New Font(Label13.Font, FontStyle.Regular)
    End Sub
    Private Sub Picturebox14_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox14.MouseEnter
        Me.Cursor = Cursors.Hand
        Label12.ForeColor = Color.White
        Label12.Font = New Font(Label12.Font, FontStyle.Bold)
    End Sub
    Private Sub Picturebox14_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox14.MouseLeave
        Me.Cursor = Cursors.Default
        Label12.ForeColor = Color.Black
        Label12.Font = New Font(Label12.Font, FontStyle.Regular)
    End Sub
    Private Sub Picturebox15_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox15.MouseEnter
        Me.Cursor = Cursors.Hand
        Label11.ForeColor = Color.White
        Label11.Font = New Font(Label11.Font, FontStyle.Bold)
    End Sub
    Private Sub Picturebox15_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox15.MouseLeave
        Me.Cursor = Cursors.Default
        Label11.ForeColor = Color.Black
        Label11.Font = New Font(Label11.Font, FontStyle.Regular)
    End Sub
    Private Sub Picturebox16_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox16.MouseEnter
        Me.Cursor = Cursors.Hand
        Label10.ForeColor = Color.White
        Label10.Font = New Font(Label10.Font, FontStyle.Bold)
    End Sub
    Private Sub Picturebox16_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox16.MouseLeave
        Me.Cursor = Cursors.Default
        Label10.ForeColor = Color.Black
        Label10.Font = New Font(Label10.Font, FontStyle.Regular)
    End Sub
    Private Sub Picturebox17_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox17.MouseEnter
        Me.Cursor = Cursors.Hand
        Label9.ForeColor = Color.White
        Label9.Font = New Font(Label9.Font, FontStyle.Bold)
    End Sub
    Private Sub Picturebox17_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox17.MouseLeave
        Me.Cursor = Cursors.Default
        Label9.ForeColor = Color.Black
        Label9.Font = New Font(Label9.Font, FontStyle.Regular)
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        accionGuardar = "original"
        Timer3.Enabled = True
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        accionGuardar = "oleo"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        accionGuardar = "gris"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        accionGuardar = "BN"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        accionGuardar = "sepia"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        accionGuardar = "contorno"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox7.Click
        accionGuardar = "mosaico"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.Click
        accionGuardar = "BGR"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox8.Click
        accionGuardar = "50"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox9.Click
        accionGuardar = "etiopia"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        accionGuardar = "invertir"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        accionGuardar = "GRB"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox14.Click
        accionGuardar = "RBG"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        accionGuardar = "pixel"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox16.Click
        accionGuardar = "desenfoque"

        Timer3.enabled = True
    End Sub

    Private Sub PictureBox17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox17.Click
        accionGuardar = "desierto"
        Timer3.Enabled = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.Width < 922 Then
            Me.Width = Me.Width + 15
        Else
            Timer2.Enabled = False
        End If


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

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If Me.Width > 2 Then
            Me.Width = Me.Width - 15
            If Me.Width < 40 Then Cargando.Show()
        Else

            Me.Close()

            Timer3.Enabled = False
            Guardar.Show()
        End If
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        PictureBox2_Click(sender, e)
    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        PictureBox2_MouseEnter(sender, e)
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        PictureBox2_MouseLeave(sender, e)
    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        PictureBox5_Click(sender, e)
    End Sub
    Private Sub Label8_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseEnter
        PictureBox5_MouseEnter(sender, e)
    End Sub

    Private Sub Label8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseLeave
        PictureBox5_MouseLeave(sender, e)
    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click
        PictureBox8_Click(sender, e)
    End Sub
    Private Sub Label16_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label16.MouseEnter
        Picturebox8_MouseEnter(sender, e)
    End Sub

    Private Sub Label16_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label16.MouseLeave
        Picturebox8_MouseLeave(sender, e)
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        PictureBox14_Click(sender, e)
    End Sub
    Private Sub Label12_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label12.MouseEnter
        Picturebox14_MouseEnter(sender, e)
    End Sub

    Private Sub Label12_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label12.MouseLeave
        Picturebox14_MouseLeave(sender, e)
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        PictureBox3_Click(sender, e)
    End Sub
    Private Sub Label2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseEnter
        PictureBox3_MouseEnter(sender, e)
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        PictureBox3_MouseLeave(sender, e)
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        PictureBox6_Click(sender, e)
    End Sub
    Private Sub Label7_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseEnter
        Picturebox6_MouseEnter(sender, e)
    End Sub

    Private Sub Label7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseLeave
        Picturebox6_MouseLeave(sender, e)
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        PictureBox9_Click(sender, e)
    End Sub
    Private Sub Label15_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label15.MouseEnter
        Picturebox9_MouseEnter(sender, e)
    End Sub

    Private Sub Label15_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label15.MouseLeave
        Picturebox9_MouseLeave(sender, e)
    End Sub

    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        PictureBox15_Click(sender, e)
    End Sub
    Private Sub Label11_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.MouseEnter
        Picturebox15_MouseEnter(sender, e)
    End Sub

    Private Sub Label11_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.MouseLeave
        Picturebox15_MouseLeave(sender, e)
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        PictureBox4_Click(sender, e)
    End Sub
    Private Sub Label3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseEnter
        PictureBox4_MouseEnter(sender, e)
    End Sub

    Private Sub Label3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseLeave
        PictureBox4_MouseLeave(sender, e)
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        PictureBox7_Click(sender, e)
    End Sub
    Private Sub Label6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseEnter
        Picturebox7_MouseEnter(sender, e)
    End Sub

    Private Sub Label6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseLeave
        Picturebox7_MouseLeave(sender, e)
    End Sub
    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click
        PictureBox10_Click(sender, e)
    End Sub
    Private Sub Label14_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label14.MouseEnter
        Picturebox10_MouseEnter(sender, e)
    End Sub

    Private Sub Label14_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label14.MouseLeave
        Picturebox10_MouseLeave(sender, e)
    End Sub

    Private Sub Label10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label10.Click
        PictureBox16_Click(sender, e)
    End Sub
    Private Sub Label10_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label10.MouseEnter
        Picturebox16_MouseEnter(sender, e)
    End Sub

    Private Sub Label10_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label10.MouseLeave
        Picturebox16_MouseLeave(sender, e)
    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click
        PictureBox11_Click(sender, e)
    End Sub
    Private Sub Label4_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseEnter
        Picturebox11_MouseEnter(sender, e)
    End Sub

    Private Sub Label4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label4.MouseLeave
        Picturebox11_MouseLeave(sender, e)
    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        PictureBox12_Click(sender, e)
    End Sub
    Private Sub Label5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseEnter
        Picturebox12_MouseEnter(sender, e)
    End Sub

    Private Sub Label5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseLeave
        Picturebox12_MouseLeave(sender, e)
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click
        PictureBox13_Click(sender, e)
    End Sub
    Private Sub Label13_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label13.MouseEnter
        Picturebox13_MouseEnter(sender, e)
    End Sub

    Private Sub Label13_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label13.MouseLeave
        Picturebox13_MouseLeave(sender, e)
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        PictureBox17_Click(sender, e)
    End Sub

    Private Sub Label9_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseEnter
        Picturebox17_MouseEnter(sender, e)
    End Sub

    Private Sub Label9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseLeave
        Picturebox17_MouseLeave(sender, e)
    End Sub
End Class