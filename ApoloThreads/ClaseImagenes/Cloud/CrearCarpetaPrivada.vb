Imports System.Text.RegularExpressions

Public Class CrearCarpetaPrivada

    Private Function ValidarEmail(ByVal email As String) As Boolean
        If email = String.Empty Then Return False
        ' Compruebo si el formato de la dirección es correcto.
        Dim re As Regex = New Regex("^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
        Dim m As Match = re.Match(email)
        Return (m.Captures.Count <> 0)
    End Function

    Dim usuario, contrasena As String
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If PassRepite.Text <> "" And UsernameTextBox.Text <> "" And PasswordTextBox.Text <> "" And EmailTextBox.Text <> "" Then
            If PassRepite.Text = PasswordTextBox.Text Then
                If PassRepite.Text.Length >= 4 Then
                    If ValidarEmail(EmailTextBox.Text) = True Then
                        If BackgroundWorker1.IsBusy = False Then
                            OK.Text = "Creando..."
                            picCargando.Image = My.Resources.cargandogris
                            usuario = UsernameTextBox.Text
                            contrasena = PasswordTextBox.Text
                            BackgroundWorker1.RunWorkerAsync()
                        End If

                    Else
                        MessageBox.Show("El formato del email no es correcto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

                    End If
                Else
                    MessageBox.Show("El nombre de usuario y la contraseña deben tener al menos 4 caracteres respectivamente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                End If


            Else
                MessageBox.Show("Las contraseñas no coinciden.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            End If
        Else
            MessageBox.Show("Por favor, rellene todos los campos antes de continuar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End If
    End Sub
    Dim valor As Boolean
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim objetoConexion As New Conexion("ftp://31.170.164.110/", "u610031309", "luis000luis000")
        valor = objetoConexion.CrearCarpetaPrivada(usuario, contrasena, EmailTextBox.Text)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        OK.Text = "Crear"
        picCargando.Image = Nothing
        If valor = True Then
            MessageBox.Show("Su carpeta privada se ha creado con éxito. No olvide su usuario/contraseña.", "Carpeta privada", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If checkCreden.Checked = True Then
                My.Settings.CloudUser = usuario
                My.Settings.CloudPass = contrasena
                My.Settings.Save()
                'Abrimos la sesión privada
                Dim frm As New Compartir(usuario)
                frm.Show()
                Me.Close()
            End If
        End If
    End Sub


    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub UsernameTextBox_KeyPress(sender As Object, e As KeyPressEventArgs) Handles UsernameTextBox.KeyPress
        'Sólo valores (A-z),(0,9),-_
        If InStr(1, "0123456789,-abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_-" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub CrearCarpetaPrivada_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
