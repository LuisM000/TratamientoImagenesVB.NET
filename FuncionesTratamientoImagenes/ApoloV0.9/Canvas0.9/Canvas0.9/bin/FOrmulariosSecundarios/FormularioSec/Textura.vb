
Public Class Textura

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            colorB = ColorDialog1.Color
        End If
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If Not IsNumeric(TextBox1.Text) Then
            MessageBox.Show("Por favor, introduzca un valor correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        End If
        If Not IsNumeric(TextBox2.Text) Then
            MessageBox.Show("Por favor, introduzca un valor correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        anchoB = CInt(TextBox1.Text)
        altoB = CInt(TextBox2.Text)
        volteado = ComboBox1.SelectedIndex
        aceptar = True
        Me.Close()
    End Sub

    Private Sub Textura_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = 5000
        TextBox2.Text = 5000
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class