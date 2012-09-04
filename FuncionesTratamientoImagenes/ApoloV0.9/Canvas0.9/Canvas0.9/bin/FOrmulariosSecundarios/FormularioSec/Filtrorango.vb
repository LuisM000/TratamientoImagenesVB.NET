Imports WindowsApplication1.Class1

Public Class Filtrorango

    Private Sub Filtrorango_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.NumericUpDown1.Value = 0
        Me.NumericUpDown2.Value = 0
        Me.NumericUpDown3.Value = 0
        Me.NumericUpDown4.Value = 0
        Me.NumericUpDown5.Value = 0
        Me.NumericUpDown6.Value = 0
        Me.NumericUpDown7.Value = 0
        Me.NumericUpDown8.Value = 0
        Me.NumericUpDown9.Value = 0
        Dim objeto As New tratamiento
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = bmpaux
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        rojoIn = Me.NumericUpDown1.Value
        rojoSup = Me.NumericUpDown2.Value
        rojosal = Me.NumericUpDown3.Value
        verdeIn = Me.NumericUpDown4.Value
        verdeSup = Me.NumericUpDown5.Value
        verdesal = Me.NumericUpDown6.Value
        azulIn = Me.NumericUpDown7.Value
        azulSup = Me.NumericUpDown8.Value
        azulsal = Me.NumericUpDown9.Value
        aceptar = True
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim objeto As New tratamiento
        Dim bmpaux As New Bitmap(bmpentreForm, New Size(Me.PictureBox1.Width, Me.PictureBox1.Height))
        Me.PictureBox1.Image = objeto.filtroRangoRed(bmpaux, NumericUpDown1.Value, NumericUpDown2.Value, NumericUpDown3.Value)
        Me.PictureBox1.Image = objeto.filtroRangoGreen(bmpaux, NumericUpDown4.Value, NumericUpDown5.Value, NumericUpDown6.Value)
        Me.PictureBox1.Image = objeto.filtroRangoBlue(bmpaux, NumericUpDown7.Value, NumericUpDown8.Value, NumericUpDown9.Value)
    End Sub
End Class