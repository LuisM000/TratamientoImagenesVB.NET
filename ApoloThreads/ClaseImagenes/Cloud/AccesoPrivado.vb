Imports System.Text.RegularExpressions

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
    Dim emailRe As String
    Private Sub lblrecuperar_Click(sender As Object, e As EventArgs) Handles lblrecuperar.Click
        If lblrecuperar.Text = "Recuperar contraseña" Then
            Dim email = InputBox("Introduzca su dirección de correo electrónico asociado", "Recuperación de contraseña")
            If ValidarEmail(email) = True Then
                If BackgroundWorker2.IsBusy = False Then
                    emailRe = email
                    lblrecuperar.Text = "Recuperando..."
                    pcRec.Image = My.Resources.cargandogris
                    BackgroundWorker2.RunWorkerAsync()
                End If
            Else
                MessageBox.Show("El formato del email no es correcto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        End If
    End Sub
    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Dim objetoConexion As New Conexion("ftp://93.188.160.15/", "u398464172", "luis000luis000")
        objetoConexion.RecuperarContraseña(emailRe)
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        lblrecuperar.Text = "Recuperar contraseña"
        pcRec.Image = Nothing
    End Sub
    Private Function ValidarEmail(ByVal email As String) As Boolean
        If email = String.Empty Then Return False
        ' Compruebo si el formato de la dirección es correcto.
        Dim re As Regex = New Regex("^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
        Dim m As Match = re.Match(email)
        Return (m.Captures.Count <> 0)
    End Function

   
    Private Sub lblrecuperar_MouseEnter(sender As Object, e As EventArgs) Handles lblrecuperar.MouseEnter
        If lblrecuperar.Text = "Recuperar contraseña" Then
            Me.Cursor = Cursors.Hand
            lblrecuperar.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Underline)
        End If
    End Sub

    Private Sub lblrecuperar_MouseLeave(sender As Object, e As EventArgs) Handles lblrecuperar.MouseLeave
        Me.Cursor = Cursors.Default
        lblrecuperar.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
    End Sub

End Class
