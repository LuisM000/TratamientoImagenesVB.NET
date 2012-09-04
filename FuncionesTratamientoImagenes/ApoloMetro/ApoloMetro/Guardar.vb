Imports WindowsApplication1.Class1

Public Class Guardar
    Dim ancho As Integer

    Private Sub PictureBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.ImageLocation = "imagenes\white\save.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.ImageLocation = "imagenes\black\save.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub PictureBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        PictureBox2.ImageLocation = "imagenes\white\back.png"
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.ImageLocation = "imagenes\black\back.png"
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Guardar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Visible = False
        Dim objeto As New tratamiento

        If redimens = True Then
            Dim bmp2 As New Bitmap(ruta)
            Dim bmp As New Bitmap(bmp2, New Size(anchoRed, altoRed))
            If bmp.Width >= 600 Then
                Panel1.Width = 600
                Me.Width = 746
                PictureBox3.Left = 680

            Else
                Panel1.Width = bmp.Width + 10
                Me.Width = bmp.Width + 146
                PictureBox3.Left = 70 + Panel1.Width + 10
            End If

            If bmp.Height >= 600 Then
                Panel1.Height = 600
                Me.Height = 693
                PictureBox3.Top = 622
            Else
                Panel1.Height = bmp.Height + 18
                If bmp.Width >= 600 Then
                    Me.Height = bmp.Height + 30

                Else
                    Me.Height = bmp.Height + 93
                End If
                PictureBox3.Top = (70 + PictureBox1.Height) - 48
            End If
            PictureBox1.Image = bmp

        Else
            Dim bmp As New Bitmap(ruta)
            If bmp.Width >= 600 Then
                Panel1.Width = 600
                Me.Width = 746
                PictureBox3.Left = 680

            Else
                Panel1.Width = bmp.Width + 10
                Me.Width = bmp.Width + 146
                PictureBox3.Left = 70 + Panel1.Width + 10
            End If

            If bmp.Height >= 600 Then
                Panel1.Height = 600
                Me.Height = 693
                PictureBox3.Top = 622
            Else
                Panel1.Height = bmp.Height + 18
                If bmp.Width >= 600 Then
                    Me.Height = bmp.Height + 30

                Else
                    Me.Height = bmp.Height + 93
                End If
                PictureBox3.Top = (70 + PictureBox1.Height) - 48
            End If

            Select Case accionGuardar
                Case "oleo"
                    PictureBox1.Image = objeto.Oleo(bmp, 28, 80)
                Case "gris"
                    PictureBox1.Image = objeto.grises(bmp)
                Case "original"
                    PictureBox1.Image = bmp
                Case "BN"
                    PictureBox1.Image = objeto.blanconegro(bmp)
                Case "sepia"
                    PictureBox1.Image = objeto.sepia(bmp)
                Case "contorno"
                    PictureBox1.Image = objeto.contornos(bmp, 30)
                Case "mosaico"
                    PictureBox1.Image = objeto.mosaico(bmp, 3, 3)
                Case "BGR"
                    PictureBox1.Image = objeto.RGBtoBGR(bmp)
                Case "50"
                    PictureBox1.Image = objeto.reducircolores(bmp, 50)
                Case "etiopia"
                    PictureBox1.Image = objeto.etiopia(bmp)
                Case "invertir"
                    PictureBox1.Image = objeto.invertir(bmp)
                Case "GRB"
                    PictureBox1.Image = objeto.RGBtoGRB(bmp)
                Case "RBG"
                    PictureBox1.Image = objeto.RGBtoRBG(bmp)
                Case "pixel"
                    PictureBox1.Image = objeto.pixelarX3(bmp)
                Case "desenfoque"
                    PictureBox1.Image = objeto.desenfoqueHorVert(bmp, 4, 4)
                Case "desierto"
                    PictureBox1.Image = objeto.desierto(bmp)
                Case Else

            End Select
        End If


        Cargando.Hide()
        Panel1.AutoScrollMinSize = PictureBox1.Image.Size
        PictureBox1.Refresh()
        ancho = Me.Width
        Me.Width = 69
        Me.Visible = True
        Timer2.Enabled = True

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Timer1.Enabled = True

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Dim objeto As New tratamiento
        Dim bmp As New Bitmap(PictureBox1.Image)
        objeto.guardarcomo(bmp)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Me.Width > 2 Then
            Me.Width = Me.Width - 15
        Else
            Me.Close()
            If redimens = False Then
                Efectos.Show()
            Else
                Redimensionar.Show()
            End If
            redimens = False
        End If

    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        If Me.Width < ancho Then
            Me.Width = Me.Width + 15
        Else
            Timer2.Enabled = False
        End If

    End Sub
     
End Class