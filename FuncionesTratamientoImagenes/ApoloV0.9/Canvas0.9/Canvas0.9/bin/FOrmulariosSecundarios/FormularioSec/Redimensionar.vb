Imports WindowsApplication1.Class1


Public Class Redimensionar
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not (IsNumeric(TextBox1.Text) And IsNumeric(TextBox2.Text)) Then
            MessageBox.Show("Por favor, introduzca un valor correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim objeto As New tratamiento 'Objeto de la clase tratamiento
            bitmapPic = objeto.redimensionar(bitmapPic, TextBox1.Text, TextBox2.Text)
            Me.Close()
        End If
    End Sub

    Private Sub Redimensionar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Select()
        TextBox1.Text = "500"
        TextBox2.Text = "500"
    End Sub
End Class