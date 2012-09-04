Public Class PpiedadesParcilaFiltro

    Private Sub PpiedadesParcilaFiltro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumericUpDown1.Value = My.Settings.AnchoFpar
        NumericUpDown2.Value = My.Settings.AltoFpar
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.AnchoFpar = NumericUpDown1.Value
        My.Settings.AltoFpar = NumericUpDown2.Value
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        pasoFiltrPer = False
        Me.Close()
    End Sub
End Class