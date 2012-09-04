Public Class PpiedadesSegmentacion

    Private Sub PpiedadesSegmentacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumericUpDown1.Value = My.Settings.AnchoSe
        NumericUpDown2.Value = My.Settings.AltoSe
        HScrollBar1.Value = My.Settings.RojoSe
        HScrollBar2.Value = My.Settings.VerdeSe
        HScrollBar3.Value = My.Settings.AzulSe
        HScrollBar4.Value = My.Settings.AlfaSe
        Label9.Text = HScrollBar1.Value
        Label10.Text = HScrollBar2.Value
        Label11.Text = HScrollBar3.Value
        Label8.Text = HScrollBar4.Value
    End Sub
 

    Private Sub HScrollBar1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar1.Scroll
        Label9.Text = HScrollBar1.Value
    End Sub

    Private Sub HScrollBar2_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar2.Scroll
        Label10.Text = HScrollBar2.Value
    End Sub

    Private Sub HScrollBar3_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar3.Scroll
        Label11.Text = HScrollBar3.Value
    End Sub

    Private Sub HScrollBar4_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles HScrollBar4.Scroll
        Label8.Text = HScrollBar4.Value
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        My.Settings.AnchoSe = NumericUpDown1.Value
        My.Settings.AltoSe = NumericUpDown2.Value
        My.Settings.RojoSe = HScrollBar1.Value
        My.Settings.VerdeSe = HScrollBar2.Value
        My.Settings.AzulSe = HScrollBar3.Value
        My.Settings.AlfaSe = HScrollBar4.Value
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class