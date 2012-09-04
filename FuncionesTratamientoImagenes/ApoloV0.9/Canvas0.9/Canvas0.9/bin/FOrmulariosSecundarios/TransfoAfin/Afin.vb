Imports WindowsApplication1.Class1
Imports WindowsApplication1.Class2

Public Class Afin

    Dim objeto As New tratamiento
    Dim objetoform As New trataformu

    Private Sub Afin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        PictureBox1.Image = bmpAfin
        PictureBox2.Image = bmpAfin
        'PictureBox3.BorderStyle = BorderStyle.FixedSingle
        PictureBox3.Visible = True
        PictureBox3.Image = PictureBox1.Image
        Timer1.Enabled = True
        TextBox1.Text = 2000 : TextBox2.Text = 2000
        PictureBox1.Visible = True
        SplitContainer1.SplitterDistance = Me.Size.Width - 345
        SplitContainer1.Panel1.AutoScroll = True
        SplitContainer1.Panel1.AutoScrollMinSize = PictureBox1.Image.Size
        GroupBox1.Location = New Point(23, 30)
        GroupBox2.Location = New Point(GroupBox1.Location.X, 290)
        PictureBox3.Location = New Point(GroupBox1.Location.X, (Me.Size.Height - PictureBox3.Size.Height) - 70)

        Label8.Text = "----------------------------Imagen general-----------------------------"

        Label8.Location = New Point(GroupBox1.Location.X, PictureBox3.Location.Y - 20)




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
        objetoform.refrescar(PictureBox2, SplitContainer1.Panel1) 'Refrescamos Picture y Panel
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PictureBox1.Visible = True
        objetoform.refrescar(PictureBox1, SplitContainer1.Panel1) 'Refrescamos Picture y Panel
        PictureBox3.Image = PictureBox1.Image
        Timer1.Enabled=False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If PictureBox2.Image IsNot Nothing And PictureBox1.Visible = False Then
            PictureBox3.Image = PictureBox2.Image
        End If
    End Sub


    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint
        PictureBox3.Location = New Point(GroupBox1.Location.X, (Me.Size.Height - PictureBox3.Size.Height) - 70)
    End Sub

    Private Sub AbrirImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirImagenToolStripMenuItem.Click
        PictureBox1.Image = objeto.abirImagen() 'Abrimos imagen y al PictureBox
        objetoform.refrescar(PictureBox1, SplitContainer1.Panel1) 'Refrescamos Picture y Panel
        Me.Text = objeto.nombreImagen 'nombre al formulario
        PictureBox3.Image = PictureBox1.Image
    End Sub

    Private Sub GuardarImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarImagenToolStripMenuItem.Click
        objeto.guardarcomo(PictureBox2.Image) 'Guardamos imagen
    End Sub

    Private Sub SalirAProgramaPrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirAProgramaPrincipalToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub EnviaImagenAProgramaPrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviaImagenAProgramaPrincipalToolStripMenuItem.Click
        afinImagen = True
        bmpAfinRetorno = PictureBox2.Image
        Dim pregunta = MessageBox.Show("La imagen ha sido enviada. ¿Desea cerrar el módulo de transformación afín?", "Apolo v0.9", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If pregunta = Windows.Forms.DialogResult.OK Then
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
End Class