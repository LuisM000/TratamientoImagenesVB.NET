Imports WindowsApplication1.Class1

Public Class Filtro

    Private Sub Filtro_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.NumericUpDown1.Value = 0
        Me.NumericUpDown2.Value = 0
        Me.NumericUpDown3.Value = 0
        Me.NumericUpDown4.Value = 0
        Me.NumericUpDown5.Value = 0
        Me.NumericUpDown6.Value = 0
        Dim objeto As New tratamiento
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = bmpaux
    End Sub

  

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim objeto As New tratamiento
        Dim bmp As New Bitmap(Me.PictureBox1.Image)
        Me.PictureBox1.Image = objeto.filtro(bmp, NumericUpDown1.Value, NumericUpDown2.Value, NumericUpDown3.Value, NumericUpDown4.Value, NumericUpDown5.Value, NumericUpDown6.Value)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        rojof = Me.NumericUpDown1.Value
        rojofs = Me.NumericUpDown2.Value
        verdef = Me.NumericUpDown3.Value
        verdefs = Me.NumericUpDown4.Value
        azulf = Me.NumericUpDown5.Value
        azulfs = Me.NumericUpDown6.Value
        aceptar = True 'Usuario acepta
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class