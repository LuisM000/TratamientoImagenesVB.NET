Public Class PropiedadesFiltrL1

    Private Sub PropiedadesFiltrL1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        NumericUpDown1.Value = My.Settings.AnchoFIltro
        NumericUpDown2.Value = My.Settings.AltoFIltro
        HScrollBar1.Value = My.Settings.RojoFi
        HScrollBar2.Value = My.Settings.VErdeFi
        HScrollBar3.Value = My.Settings.AzulFi
        Label9.Text = HScrollBar1.Value
        Label10.Text = HScrollBar2.Value
        Label11.Text = HScrollBar3.Value
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        My.Settings.AnchoFIltro = NumericUpDown1.Value
        My.Settings.AltoFIltro = NumericUpDown2.Value
        My.Settings.RojoFi = HScrollBar1.Value
        My.Settings.VErdeFi = HScrollBar2.Value
        My.Settings.AzulFi = HScrollBar3.Value
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub HScrollBar1_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Label9.Text = HScrollBar1.Value
    End Sub

    Private Sub HScrollBar2_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar2.Scroll
        Label10.Text = HScrollBar2.Value
    End Sub

    Private Sub HScrollBar3_Scroll(sender As System.Object, e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar3.Scroll
        Label11.Text = HScrollBar3.Value
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class