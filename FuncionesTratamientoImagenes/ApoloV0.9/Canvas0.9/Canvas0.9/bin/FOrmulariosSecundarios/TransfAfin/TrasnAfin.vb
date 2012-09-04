Public Class Transf
     


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SplitContainer1.SplitterDistance = Me.Size.Width - 345
        SplitContainer1.Panel1.AutoScrollMinSize = PictureBox1.Image.Size
        Timer1.Enabled = True
        TextBox1.Text = 5000 : TextBox2.Text = 5000
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PictureBox1.Visible = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If PictureBox2.Image IsNot Nothing Then
            PictureBox3.BorderStyle = BorderStyle.FixedSingle
            PictureBox3.Image = PictureBox2.Image
        End If
    End Sub
End Class
