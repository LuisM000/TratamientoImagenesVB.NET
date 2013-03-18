Imports System.Net.Mail

Public Class NotificarErrorAyuda

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

    Dim cuerpo As String
    Dim email As String
    Dim captura As Bitmap

    Private Sub NotificarErrorAyuda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripProgressBar1.Size = New Size(0, 0)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Computer.Network.IsAvailable = True Then 'Comprobamos conexión a internet
            If BackgroundWorker1.IsBusy = False Then
                BackgroundWorker1.RunWorkerAsync()
                cuerpo = RichTextBox2.Text
                email = TextBox1.Text
                If PictureBox1.Image IsNot Nothing Then
                    captura = PictureBox1.Image
                    captura.Save("Captura.jpg", System.Drawing.Imaging.ImageFormat.Jpeg) 'Guardamos la imagen para luego obtener la ruta al enviar el correo
                End If
                cargando()
            End If
        Else
            cargadoError()
            MessageBox.Show("No se ha podido enviar. Revise que está conectado a internet e inténtelo de nuevo.", "Error Apolo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim SMTP As New System.Net.Mail.SmtpClient 'Variable con la que se envia el correo
            envioOK = True
            Dim CORREO As New System.Net.Mail.MailMessage
            CORREO.From = New System.Net.Mail.MailAddress("apolothreads@gmail.com", "Notificación error detectado por usuario Apolo-threads", System.Text.Encoding.UTF8)

            Dim cuerpoCorreo As String
            cuerpoCorreo = "Descripción: " & cuerpo & "----  "
            If CheckBox2.Checked = True Then
                cuerpoCorreo += "Email usuario: " & email & "----  "
            End If

            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(cuerpoCorreo, Nothing, "text/html")
            If CheckBox1.Checked = True Then
                'Path de la imagen
                Dim CapturaError As New LinkedResource("Captura.jpg")
                CapturaError.ContentId = "Captura de pantalla del error"
                'Adicionando logo
                htmlView.LinkedResources.Add(CapturaError)
            End If

            CORREO.To.Add("luis.m.r@outlook.com")
            'Adicionando copia oculta
            CORREO.Bcc.Add("luis.m.r@outlook.com")

            CORREO.IsBodyHtml = True
            CORREO.AlternateViews.Add(htmlView)

            CORREO.Subject = "Notificación error detectado por usuario Apolo-threads"
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

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Dim objetoTratamiento As New Apolo.TratamientoImagenes
            PictureBox1.Image = objetoTratamiento.capturarPantalla(True)
            Timer1.Enabled = True
        Else
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox1.Enabled = True
        Else
            TextBox1.Enabled = False
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Panel1.Location.Y > 194 And Timer1.Enabled = False Then
            Panel1.Location = New Size(Panel1.Location.X, Panel1.Location.Y - 5)
            Me.Size = New Size(Me.Width, Me.Height - 5)
        Else
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Panel1.Location.Y < 360 And Timer2.Enabled = False Then
            Panel1.Location = New Size(Panel1.Location.X, Panel1.Location.Y + 5)
            Me.Size = New Size(Me.Width, Me.Height + 5)
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Dim objetoTratamiento As New Apolo.TratamientoImagenes
        PictureBox1.Image = objetoTratamiento.capturarPantalla(True)
    End Sub
    Private Sub PictureBox2_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox2.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub PictureBox2_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub
End Class