Public Class PropiedadesClon

    Private Sub PropiedadesClon_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        NumericUpDown1.Value = My.Settings.AnchoClon
        NumericUpDown2.Value = My.Settings.AltoClon
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        My.Settings.AnchoClon = NumericUpDown1.Value
        My.Settings.AltoClon = NumericUpDown2.Value
        My.Settings.Save()
        Me.Close()
    End Sub
End Class