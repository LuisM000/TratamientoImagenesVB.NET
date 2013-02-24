Imports System.Net.Mail

Public Class AyudanosAmejorar

    Sub cargando()
        ToolStripProgressBar1.Style = ProgressBarStyle.Marquee
        ToolStripStatusLabel1.Text = "Enviando"
        ToolStripProgressBar1.Size = New Size(100, ToolStripProgressBar1.Size.Height)
        ToolStripProgressBar1.MarqueeAnimationSpeed = 30
    End Sub
    Sub cargado()
        Try
            ToolStripStatusLabel1.Text = "Enviado"
            ToolStripProgressBar1.Size = New Size(100, ToolStripProgressBar1.Size.Height)
            ToolStripProgressBar1.Style = ProgressBarStyle.Continuous
            ToolStripProgressBar1.Value = 100
        Catch
        End Try
    End Sub
    Sub cargadoError()
        Try
            ToolStripStatusLabel1.Text = "No enviado"
            ToolStripProgressBar1.Size = New Size(100, ToolStripProgressBar1.Size.Height)
            ToolStripProgressBar1.Style = ProgressBarStyle.Continuous
            ToolStripProgressBar1.Value = 100
        Catch
        End Try
    End Sub

    Dim aspectos As String
    Dim rapidez, usabilidad, util, general As Integer

    Private Sub AyudanosAmejorar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        ComboBox4.SelectedIndex = 0
        ToolStripProgressBar1.Size = New Size(0, 0)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Computer.Network.IsAvailable = True Then 'Comprobamos conexión a internet
            If BackgroundWorker1.IsBusy = False Then
                BackgroundWorker1.RunWorkerAsync()
                aspectos = RichTextBox1.Text
                rapidez = ComboBox1.SelectedItem
                usabilidad = ComboBox2.SelectedItem
                util = ComboBox4.SelectedItem
                general = ComboBox3.SelectedItem
                cargando()
            End If
        Else
            cargadoError()
            MessageBox.Show("No se ha podido enviar. Revise que está conectado a internet e inténtelo de nuevo.", "Error Apolo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim SMTP As New System.Net.Mail.SmtpClient 'Variable con la que se envia el correo
            envioOK = True
            Dim CORREO As New System.Net.Mail.MailMessage
            CORREO.From = New System.Net.Mail.MailAddress("apolothreads@gmail.com", "Encuesta Apolo threads", System.Text.Encoding.UTF8)

            Dim cuerpoCorreo As String
            cuerpoCorreo = "Aspectos a mejorar: " & aspectos & " ----  "
            cuerpoCorreo += "Rapidez: " & rapidez & " ----  "
            cuerpoCorreo += "Usabilidad: " & usabilidad & " ----  "
            cuerpoCorreo += "Util: " & util & " ----  "
            cuerpoCorreo += "General: " & general & " ----  "


            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(cuerpoCorreo, Nothing, "text/html")

            CORREO.To.Add("luis.m.r@outlook.com")
            'Adicionando copia oculta
            CORREO.Bcc.Add("luis.m.r@outlook.com")

            CORREO.IsBodyHtml = True
            CORREO.AlternateViews.Add(htmlView)

            CORREO.Subject = "Encuesta Apolo threads"
            SMTP.Host = "smtp.gmail.com"
            SMTP.Port = "587"

            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("apolothreads@gmail.com", "Apolo0525")
            SMTP.Send(CORREO)

        Catch ex As Exception
            envioOK = False
            cargadoError()
            MessageBox.Show("No se ha podido enviar. Vuelva a intentarlo por favor.", "Error Apolo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Dim envioOK As Boolean = True
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If envioOK = True Then
            cargado()
            MessageBox.Show("Enviado con éxito. Muchas gracias por su colaboración", "Apolo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            cargadoError()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class