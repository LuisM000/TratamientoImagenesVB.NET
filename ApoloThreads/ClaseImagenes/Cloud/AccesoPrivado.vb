Public Class AccesoPrivado

    Dim pass, user As String
    Private Sub AccesoPrivado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UsernameTextBox.Text = My.Settings.CloudUser
        PasswordTextBox.Text = My.Settings.CloudPass
    End Sub


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text <> "" And PasswordTextBox.Text <> "" Then
            If BackgroundWorker1.IsBusy = False Then
                OK.Text = "Accediendo..."
                picCargando.Image = My.Resources.cargandogris
                pass = PasswordTextBox.Text
                user = UsernameTextBox.Text
                BackgroundWorker1.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Dim valor As Boolean
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim objetoConexion As New Conexion("ftp://93.188.160.15/", "u398464172", "luis000luis000")
        valor = objetoConexion.AccederCarpetaPrivada(user, pass)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        OK.Text = "Acceder"
        picCargando.Image = Nothing
        If valor = True Then
            MessageBox.Show("Hola " & user & ". Gracias por iniciar sesión." & vbCrLf & "¡Bienvenido!", "Carpeta privada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If checkCreden.Checked = True Then
                My.Settings.CloudPass = pass
                My.Settings.CloudUser = user
                My.Settings.Save()
            End If
            Dim frm As New Compartir(user)
            frm.Show()
            Me.Close()
        End If
    End Sub

End Class
