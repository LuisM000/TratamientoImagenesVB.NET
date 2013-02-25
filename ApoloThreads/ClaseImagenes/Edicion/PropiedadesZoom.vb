Public Class PropiedadesZoom

    Private Sub PropiedadesZoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        NumZoom.Value = My.Settings.ValorZoom
        NumVentana.Value = My.Settings.TamanoVentanaZoom
        NumTamanoPuntero.Value = My.Settings.TamanoPunteroZoom
        Button1.BackColor = My.Settings.ColorPunteroZoom
        chbEtiqueta.Checked = My.Settings.EtiquetaZoom
        chbPuntero.Checked = My.Settings.PunteroZoom
        NumDistanciaPuntero.Value = My.Settings.DistanciaPunteroZoom
        If My.Settings.PunteroZoom = True Then
            Button1.Enabled = True
            NumTamanoPuntero.Enabled = True
        Else
            Button1.Enabled = False
            NumTamanoPuntero.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ColorDialog1.ShowDialog()
        Button1.BackColor = ColorDialog1.Color

    End Sub

    Private Sub chbPuntero_CheckedChanged(sender As Object, e As EventArgs) Handles chbPuntero.CheckedChanged
        If chbPuntero.Checked = True Then
            Button1.Enabled = True
            NumTamanoPuntero.Enabled = True
        Else
            Button1.Enabled = False
            NumTamanoPuntero.Enabled = False
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.ValorZoom = NumZoom.Value
        My.Settings.TamanoVentanaZoom = NumVentana.Value
        My.Settings.TamanoPunteroZoom = NumTamanoPuntero.Value
        My.Settings.ColorPunteroZoom = Button1.BackColor
        My.Settings.EtiquetaZoom = chbEtiqueta.Checked
        My.Settings.PunteroZoom = chbPuntero.Checked
        My.Settings.DistanciaPunteroZoom = NumDistanciaPuntero.Value
        My.Settings.Save()
        Me.Close()
    End Sub
End Class