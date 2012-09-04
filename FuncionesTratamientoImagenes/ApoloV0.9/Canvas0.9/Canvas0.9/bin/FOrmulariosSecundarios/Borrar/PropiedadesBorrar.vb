Public Class PropiedadesBorrar

    Private Sub PropiedadesBorrar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumericUpDown1.Value = My.Settings.AnchoBorrar
        NumericUpDown2.Value = My.Settings.AltoBorrar
        HScrollBar1.Value = My.Settings.RojoBorrar
        HScrollBar2.Value = My.Settings.VerdeBorrar
        HScrollBar3.Value = My.Settings.AzulBorrar
        HScrollBar4.Value = My.Settings.AlfaBorrar
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
        My.Settings.AnchoBorrar = NumericUpDown1.Value
        My.Settings.AltoBorrar = NumericUpDown2.Value
        My.Settings.RojoBorrar = HScrollBar1.Value
        My.Settings.VerdeBorrar = HScrollBar2.Value
        My.Settings.AzulBorrar = HScrollBar3.Value
        My.Settings.AlfaBorrar = HScrollBar4.Value
        My.Settings.Save()
        Me.Close()
    End Sub
End Class