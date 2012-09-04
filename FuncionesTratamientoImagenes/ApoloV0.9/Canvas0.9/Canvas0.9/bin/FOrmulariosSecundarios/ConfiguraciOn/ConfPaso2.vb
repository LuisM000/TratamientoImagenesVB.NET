Public Class ConfPaso2

    Dim PanelColor As Color
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
         My.Settings.TipoBorde = seleccionarBordeF(ComboBox1.SelectedItem)
        My.Settings.ColorPanel = PanelColor
        If CheckBox1.Checked = True Then
            My.Settings.BarraLateral = True
        Else
            My.Settings.BarraLateral = False
        End If
        If CheckBox4.Checked = True Then
            My.Settings.pantallainicial = True
        Else
            My.Settings.pantallainicial = False
        End If
        If CheckBox2.Checked = True Then
            My.Settings.vistapr = True
        Else
            My.Settings.vistapr = False
        End If
        If CheckBox3.Checked = True Then
            My.Settings.MensajeClon = True
            My.Settings.MensajeFiltro = True
            My.Settings.MensajeClonParcial = True
            My.Settings.MensajesFiltroParc = True
            My.Settings.MensajeRecortar = True
            My.Settings.MensajeSegmentacion = True
            My.Settings.MensajeBorrar = True
        Else
            My.Settings.MensajeClon = False
            My.Settings.MensajeFiltro = False
            My.Settings.MensajeClonParcial = False
            My.Settings.MensajesFiltroParc = False
            My.Settings.MensajeRecortar = False
            My.Settings.MensajeSegmentacion = False
            My.Settings.MensajeBorrar = False
        End If
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dlgcolor.ShowDialog = Windows.Forms.DialogResult.OK Then
            Panelcolor = dlgcolor.Color
        End If
    End Sub
    Function seleccionarBordeF(ByVal borde As String)
        Select Case ComboBox1.SelectedIndex
            Case 0
                borde = "none"
            Case 1
                borde = "single"
            Case 2
                borde = "3d"
            Case Else
                borde = "none"
        End Select
        Return borde
    End Function
End Class