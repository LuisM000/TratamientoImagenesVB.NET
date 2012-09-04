Public Class PropiedadesClonParcial

    Private Sub HScrollBar1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Label4.Text = HScrollBar1.Value & " %"
    End Sub

    Private Sub PropiedadesClonParcial_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Label4.Text = My.Settings.Porcentaje & " %"
        HScrollBar1.Value = My.Settings.Porcentaje
        NumericUpDown1.Value = My.Settings.AnchoclonPar
        NumericUpDown2.Value = My.Settings.AltoclonPar
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        My.Settings.AnchoclonPar = NumericUpDown1.Value
        My.Settings.AltoclonPar = NumericUpDown2.Value
        My.Settings.Porcentaje = HScrollBar1.Value
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class