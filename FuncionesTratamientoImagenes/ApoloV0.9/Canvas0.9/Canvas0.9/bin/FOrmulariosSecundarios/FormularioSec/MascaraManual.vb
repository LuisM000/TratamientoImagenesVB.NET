Imports WindowsApplication1.Class1

Public Class MascaraManual
    Dim mascara(2, 2) As Double
    Dim comp As Boolean
    Dim factor, desviacion As Double
    Sub valores()
        mascara(0, 0) = TextBox1.Text : mascara(0, 1) = TextBox2.Text : mascara(0, 2) = TextBox3.Text
        mascara(1, 0) = TextBox4.Text : mascara(1, 1) = TextBox5.Text : mascara(1, 2) = TextBox6.Text
        mascara(2, 0) = TextBox7.Text : mascara(2, 1) = TextBox8.Text : mascara(2, 2) = TextBox9.Text
        If CheckBox2.Checked = True Then
            factor = TextBox11.Text
        Else
            factor = 0
        End If
        If CheckBox1.Checked = True Then desviacion = TextBox10.Text Else desviacion = 0
    End Sub
    Sub comprobar()
        If Not (IsNumeric(TextBox1.Text) And IsNumeric(TextBox2.Text) And IsNumeric(TextBox3.Text) And IsNumeric(TextBox4.Text) And IsNumeric(TextBox5.Text) And IsNumeric(TextBox6.Text) And IsNumeric(TextBox7.Text) And IsNumeric(TextBox8.Text) And IsNumeric(TextBox9.Text)) Then
            MessageBox.Show("Por favor, compruebe los datos de la matriz", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            comp = False
            Exit Sub
        End If
        If CheckBox1.Checked = True Then
            If Not (IsNumeric(TextBox10.Text)) Then
                MessageBox.Show("Por favor, compruebe el campo desviación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                comp = False
                Exit Sub
            End If
        End If
        If CheckBox2.Checked = True Then
            If Not (IsNumeric(TextBox11.Text)) Then
                MessageBox.Show("Por favor, compruebe el campo factor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                comp = False
                Exit Sub
            End If
        End If
        comp = True
    End Sub
    Private Sub MascaraManual_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.Select()
        TextBox1.Text = 1
        TextBox2.Text = 1
        TextBox3.Text = 1
        TextBox4.Text = 1
        TextBox5.Text = 1
        TextBox6.Text = 1
        TextBox7.Text = 1
        TextBox8.Text = 1
        TextBox9.Text = 1
        TextBox10.Text = 1
        TextBox11.Text = 0
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        RadioButton1.Checked = False
        RadioButton2.Checked = True
        Dim objeto As New tratamiento
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        valores()
        Me.PictureBox1.Image = objeto.mascara3x3RGB(bmpaux, mascara, TextBox10.Text, TextBox11.Text)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        comprobar()
        If comp = True Then
            valores()
            Dim objeto As New tratamiento
            Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
            valores()
            If RadioButton1.Checked = True Then
                Me.PictureBox1.Image = objeto.mascara3x3Gris(bmpaux, mascara, desviacion, factor)
            Else
                Me.PictureBox1.Image = objeto.mascara3x3RGB(bmpaux, mascara, desviacion, factor)
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If RadioButton1.Checked = True Then grisO = True Else grisO = False
        comprobar()
        If comp = True Then
            valores()
            pasoMascara = mascara
            desviacionP = desviacion
            factorP = factor
            aceptar = True 'Usuario acepta
            Me.Close()
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class