Imports System.Windows.Forms

Public Class Dialog1ClonParc

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If CheckBox1.Checked = True Then
            My.Settings.MensajeClon = False
        Else
            My.Settings.MensajeClon = True
        End If
        My.Settings.Save()
        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
 
End Class
