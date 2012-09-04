Imports WindowsApplication1.Class2

Public Class VistaPrevia

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        aceptar = True
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            My.Settings.vistapr = False
        Else
            My.Settings.vistapr = True
        End If
        My.Settings.Save()
    End Sub

    Private Sub VistaPrevia_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If My.Settings.vistapr = True Then
            CheckBox1.Checked = False
        Else
            CheckBox1.Checked = True
        End If
    End Sub
End Class