Imports WindowsApplication1.Class1

Public Class BlancoNegroM


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        aceptar = True 'Usuario acepta
        valorumbral = NumericUpDown1.Value 'Guardamos valor
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim objeto As New tratamiento 'Vista previa
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = objeto.blanconegro(bmpaux, NumericUpDown1.Value)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close() 'Usuario declina
    End Sub

    Private Sub BlancoNegroM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumericUpDown1.Value = 128
        Dim objeto As New tratamiento 'Cargamos la imagen con umbral 128 
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = objeto.blanconegro(bmpaux, 128)
    End Sub
End Class