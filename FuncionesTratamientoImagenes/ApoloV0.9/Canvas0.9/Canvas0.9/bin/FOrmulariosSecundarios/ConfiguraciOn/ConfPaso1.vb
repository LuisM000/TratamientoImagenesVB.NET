Public Class ConfPaso1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If RadioButton1.Checked = True Then
            My.Settings.animacion = True
            My.Settings.actualizacion = True
            My.Settings.Original = True
            My.Settings.Pantallapresentación = True
        End If
        If RadioButton2.Checked = True Then
            My.Settings.animacion = False
            My.Settings.actualizacion = False
            My.Settings.Original = False
            My.Settings.Pantallapresentación = False
        End If
        If RadioButton3.Checked = True Then
            If TreeView3.Nodes(0).Checked = True Then
                My.Settings.animacion = True
            Else
                My.Settings.animacion = False
            End If
            If TreeView3.Nodes(1).Checked = True Then
                My.Settings.actualizacion = True
            Else
                My.Settings.actualizacion = False
            End If
            If TreeView3.Nodes(2).Checked = True Then
                My.Settings.Original = True
            Else
                My.Settings.Original = False
            End If
            If TreeView3.Nodes(3).Checked = True Then
                My.Settings.Pantallapresentación = True
            Else
                My.Settings.Pantallapresentación = False
            End If
        End If

        My.Settings.Save()
        Me.Visible = False
        Me.Close()
        ConfPaso2.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TreeView3.Enabled = False
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            TreeView3.Enabled = False
        End If
    End Sub

   
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            TreeView3.Enabled = True
        End If
    End Sub
End Class
