Imports WindowsApplication1.Class1

Public Class Matriz
    Dim comp As Boolean
    Sub comprobar()
        If Not (IsNumeric(TextBox1.Text) And IsNumeric(TextBox2.Text) And IsNumeric(TextBox3.Text) And IsNumeric(TextBox4.Text) And IsNumeric(TextBox5.Text) And IsNumeric(TextBox6.Text) And IsNumeric(TextBox7.Text) And IsNumeric(TextBox8.Text) And IsNumeric(TextBox9.Text)) Then
            MessageBox.Show("Por favor, compruebe los datos de la matriz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            comp = False
            Exit Sub
        End If
        comp = True
    End Sub
    Private Sub Matriz_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.Select()
        TextBox1.Text = 1
        TextBox2.Text = 0
        TextBox3.Text = 0
        TextBox4.Text = 0
        TextBox5.Text = 1
        TextBox6.Text = 0
        TextBox7.Text = 0
        TextBox8.Text = 0
        TextBox9.Text = 1
        Dim objeto As New tratamiento
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = objeto.filtroponderado(bmpaux, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, TextBox9.Text)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        comprobar()
        If comp = True Then
            Dim objeto As New tratamiento
            Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
            Me.PictureBox1.Image = objeto.filtroponderado(bmpaux, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, TextBox9.Text)
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        comprobar()
        If comp = True Then
            r1 = TextBox1.Text
            r2 = TextBox2.Text
            r3 = TextBox3.Text
            g1 = TextBox4.Text
            g2 = TextBox5.Text
            g3 = TextBox6.Text
            b1 = TextBox7.Text
            b2 = TextBox8.Text
            b3 = TextBox9.Text
            aceptar = True 'Usuario acepta
            Me.Close()
        End If
    End Sub
End Class