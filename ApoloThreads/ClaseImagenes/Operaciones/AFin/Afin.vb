Imports ClaseImagenes.Apolo


Public Class Afin

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes

    Private Sub Afin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        PictureBox1.Image = Principal.PictureBox2.Image
        PictureBox2.Image = Principal.PictureBox2.Image
        'PictureBox3.BorderStyle = BorderStyle.FixedSingle
        PictureBox3.Visible = True
        PictureBox3.Image = PictureBox1.Image
        Timer1.Enabled = True
        TextBox1.Text = 2000 : TextBox2.Text = 2000
        PictureBox1.Visible = True
        SplitContainer1.SplitterDistance = Me.Size.Width - 345
        SplitContainer1.Panel1.AutoScroll = True
        SplitContainer1.Panel1.AutoScrollMinSize = PictureBox1.Image.Size
        Panel1.Location = New Point(SplitContainer1.Panel2.Width / 2 - (Panel1.Width / 2), 30)
        Panel2.Location = New Point(SplitContainer1.Panel2.Width - (Panel2.Width) - (Panel2.Width / 2), (Me.Size.Height - PictureBox3.Size.Height) - 70)

        Label8.Text = "----------------------------Imagen general----------------------------------------------"


        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim giro = NumericUpDown1.Value
        Dim tranX = NumericUpDown4.Value
        Dim tranY = NumericUpDown5.Value
        Dim escX = NumericUpDown2.Value
        Dim escY = NumericUpDown3.Value
        If RadioButton2.Checked = True Then
            Dim G As Graphics
            Try
                Dim bmp As New Bitmap(CInt(TextBox1.Text), CInt(TextBox2.Text))
                Dim img As Image
                img = CType(bmp, Image)
                PictureBox2.Image = img
                G = Graphics.FromImage(bmp)
                'Borra la Matriz de transformación
                G.ResetTransform()
                G.TranslateTransform(tranX, tranY)
                G.ScaleTransform(escX, escY)
                G.RotateTransform(giro)
                G.DrawImage(PictureBox1.Image, New PointF(0, 0))
                PictureBox1.Refresh()
                SplitContainer1.Panel1.AutoScrollMinSize = PictureBox2.Image.Size
                PictureBox1.Visible = False
            Catch
                MessageBox.Show("El tamaño de la imagen de salida no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try

        Else
            Dim G As Graphics
            Try
                Dim bmp As New Bitmap(CInt(TextBox1.Text), CInt(TextBox2.Text))
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
                SplitContainer1.Panel1.AutoScrollMinSize = PictureBox2.Image.Size
                PictureBox1.Visible = False
            Catch
                MessageBox.Show("El tamaño de la imagen de salida no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            End Try
        End If
        Timer1.Enabled = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PictureBox1.Visible = True
        PictureBox3.Image = PictureBox1.Image
        Timer1.Enabled=False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If PictureBox2.Image IsNot Nothing And PictureBox1.Visible = False Then
            PictureBox3.Image = PictureBox2.Image
        End If
    End Sub


    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint
        Panel1.Location = New Point(SplitContainer1.Panel2.Width / 2 - (Panel1.Width / 2), 30)
        Panel2.Location = New Point(SplitContainer1.Panel2.Width / 2 - (Panel2.Width / 2), (Me.Size.Height - PictureBox3.Size.Height) - 70)

    End Sub

    Private Sub AbrirImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirImagenToolStripMenuItem.Click
        PictureBox1.Image = abrirImagen() 'Abrimos imagen y al PictureBox
        PictureBox3.Image = PictureBox1.Image
    End Sub

    Private Sub GuardarImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarImagenToolStripMenuItem.Click
        guardarcomo(PictureBox2.Image) 'Guardamos imagen
    End Sub

    Private Sub SalirAProgramaPrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirAProgramaPrincipalToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub EnviaImagenAProgramaPrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviaImagenAProgramaPrincipalToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox2.Image)
        Principal.PictureBox1.Image = objetoTratamiento.ActualizarImagen(bmp, True)
        Dim pregunta = MessageBox.Show("La imagen ha sido enviada. ¿Desea cerrar el módulo de transformación afín?", "Apolo v0.9", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If pregunta = Windows.Forms.DialogResult.Yes Then
            Me.Close()
        End If

    End Sub

    Private Sub AbrirImagenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirImagenToolStripMenuItem1.Click
        AbrirImagenToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub GuardarImagenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarImagenToolStripMenuItem1.Click
        GuardarImagenToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub SalirAProgramaPrincipalToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirAProgramaPrincipalToolStripMenuItem1.Click
        SalirAProgramaPrincipalToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub EnviarImagenAlProgramaPrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarImagenAlProgramaPrincipalToolStripMenuItem.Click
        EnviaImagenAProgramaPrincipalToolStripMenuItem_Click(sender, e)
    End Sub

  

    Private Sub ActivarImagenGeneralToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ActivarImagenGeneralToolStripMenuItem.Click
        Timer1.Enabled = True
        PictureBox3.Visible = True
        Label8.Visible = True
    End Sub

    Private Sub DesactivarImagenGeneralToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesactivarImagenGeneralToolStripMenuItem1.Click
        Timer1.Enabled = False
        PictureBox3.Visible = False
        PictureBox3.Image = Nothing
        Label8.Visible = False
    End Sub


    Function abrirImagen(Optional filtrado As Integer = 1) As Bitmap
        Try
            Dim dialogo As New OpenFileDialog

            With dialogo
                .Filter = "Todos los formatos compatibles|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif" & _
                          "|Ficheros BMP|*.bmp" & _
                          "|Ficheros GIF|*.gif" & _
                          "|Ficheros JPG o JPEG|*.jpg;*.jpeg" & _
                          "|Ficheros PNG|*.png" & _
                          "|Ficheros TIFF|*.tif" & _
                          "|Todos los archivos|*.*"
                .FilterIndex = filtrado
                If (.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    abrirImagen = Image.FromFile(.FileName)
                    Return abrirImagen
                Else
                    abrirImagen = PictureBox1.Image
                    Return abrirImagen
                End If
            End With
        Catch e As Exception
            MessageBox.Show(e.ToString)
            abrirImagen = Nothing
            Return abrirImagen
        End Try
    End Function
    Sub guardarcomo(ByVal bmp As Bitmap, Optional ByVal filtrado As Integer = 4)
        Dim salvar As New SaveFileDialog
        With salvar
            .Filter = "Ficheros BMP|*.bmp" & _
                      "|Ficheros GIF|*.gif" & _
                      "|Ficheros JPG o JPEG|*.jpg;*.jpeg" & _
                      "|Ficheros PNG|*.png" & _
                      "|Ficheros TIFF|*.tif"
            .FilterIndex = filtrado
            .FileName = "Nueva_imagen"
            If (.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                If salvar.FileName <> "" Then
                    Dim fs As System.IO.FileStream = CType(salvar.OpenFile, System.IO.FileStream)
                    Dim formato As String = ""
                    Select Case salvar.FilterIndex
                        Case 1
                            bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp)
                            formato = "bmp"
                        Case 2
                            bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Gif)
                            formato = "gif"
                        Case 3
                            bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg)
                            formato = "jpeg"
                        Case 4
                            bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Png)
                            formato = "png"
                        Case 5
                            bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Tiff)
                            formato = "tiff"
                    End Select
                    fs.Close()
                End If
            End If
        End With
    End Sub

   
    
End Class