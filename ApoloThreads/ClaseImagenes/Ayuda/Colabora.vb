Imports System.Net.Mail

Public Class Colabora


    Private Sub conFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
    End Sub
    Private Sub sinFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub
    Dim email, colabora As String
    Private Sub Colabora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Todos los picturebox los controlamos
        For Each c As Object In Me.Controls
            If c.GetType Is GetType(PictureBox) Then
                AddHandler DirectCast(c, PictureBox).MouseEnter, AddressOf conFoco
                AddHandler DirectCast(c, PictureBox).MouseLeave, AddressOf sinFoco
            End If
        Next
    End Sub



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        System.Diagnostics.Process.Start("https://github.com/LuisM000/TratamientoImagenesVB.NET")
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        System.Diagnostics.Process.Start("https://github.com/LuisM000/TratamientoImagenesVB.NET")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Computer.Network.IsAvailable = True Then 'Comprobamos conexión a internet
            If BackgroundWorker1.IsBusy = False Then
                BackgroundWorker1.RunWorkerAsync()
                email = TextBox1.Text
                colabora = TextBox2.Text
                Button1.Text = "Enviando"
            End If
        Else
            MessageBox.Show("No se ha podido enviar. Revise que está conectado a internet e inténtelo de nuevo.", "Error Apolo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim SMTP As New System.Net.Mail.SmtpClient 'Variable con la que se envia el correo
            envioOK = True
            Dim CORREO As New System.Net.Mail.MailMessage
            CORREO.From = New System.Net.Mail.MailAddress("apolothreads@gmail.com", "Petición colaborar Apolo threads", System.Text.Encoding.UTF8)

            Dim cuerpoCorreo As String
            cuerpoCorreo = "Email: " & email & " ----  "
            cuerpoCorreo += "Colabora en: " & colabora & " ----  "

            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(cuerpoCorreo, Nothing, "text/html")

            CORREO.To.Add("luis.m.r@outlook.com")
            'Adicionando copia oculta
            CORREO.Bcc.Add("luis.m.r@outlook.com")

            CORREO.IsBodyHtml = True
            CORREO.AlternateViews.Add(htmlView)

            CORREO.Subject = "Petición colaborar Apolo threads"
            SMTP.Host = "smtp.gmail.com"
            SMTP.Port = "587"

            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("apolothreads@gmail.com", "Apolo0525")
            SMTP.Send(CORREO)

        Catch ex As Exception
            envioOK = False
            MessageBox.Show("No se ha podido enviar. Vuelva a intentarlo por favor.", "Error Apolo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Dim envioOK As Boolean = True
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If envioOK = True Then
            MessageBox.Show("Enviado con éxito. Muchas gracias por su colaboración", "Apolo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Button1.Text = "Enviar"
        End If
    End Sub
End Class