Imports System.Net.Mail

Public Class NotificacionError

    Dim capturaP As Bitmap
    Dim excep As Exception

    'Constructor del formulario (recibe captura de pantalla y excepción)
    Sub New(ByVal captura As Bitmap, ByVal excepcion As Exception)  'Recibimos variables en el constructor
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        capturaP = captura
        excep = excepcion
    End Sub
    Private Sub NotificacionError_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = capturaP
        RichTextBox1.Text = excep.ToString
        RichTextBox1.ReadOnly = True
        capturaP.Save("Excepcion.jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
            cargando()
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If My.Computer.Network.IsAvailable = True Then 'Comprobamos conexión a internet
            Try
                envioOK = True
                Dim SMTP As New System.Net.Mail.SmtpClient 'Variable con la que se envia el correo
                Dim CORREO As New System.Net.Mail.MailMessage
                CORREO.From = New System.Net.Mail.MailAddress("apolothreads@gmail.com", "Notificación error Apolo-threads", System.Text.Encoding.UTF8)

                Dim cuerpo As String
                cuerpo = "Error: " & vbCrLf & RichTextBox1.Text & vbCrLf & vbCrLf
                cuerpo += "Descripción: " & vbCrLf & RichTextBox2.Text & vbCrLf & vbCrLf
                If CheckBox2.Checked = True Then
                    cuerpo += "Email usuario: " & vbCrLf & TextBox1.Text & vbCrLf & vbCrLf
                End If

                Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(cuerpo, Nothing, "text/html")
                If CheckBox1.Checked = True Then
                    'Path de la imagen
                    Dim CapturaError As New LinkedResource("Excepcion.jpg")
                    CapturaError.ContentId = "Captura de pantalla del error"
                    'Adicionando logo
                    htmlView.LinkedResources.Add(CapturaError)
                End If

                CORREO.To.Add("luis.m.r@outlook.com")
                'Adicionando copia oculta
                CORREO.Bcc.Add("luis.m.r@outlook.com")

                CORREO.IsBodyHtml = True
                CORREO.AlternateViews.Add(htmlView)

                CORREO.Subject = "Notificación error Apolo-threads"
                SMTP.Host = "smtp.gmail.com"
                SMTP.Port = "587"

                SMTP.EnableSsl = True
                SMTP.Credentials = New System.Net.NetworkCredential("apolothreads@gmail.com", "Apolo0525")
                SMTP.Send(CORREO)

            Catch ex As Exception
                BackgroundWorker1.CancelAsync()
                envioOK = False
                cargadoError()
                MessageBox.Show("No se ha podido enviar. Vuelva a intentarlo por favor.", "Error Apolo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End Try
        Else
            BackgroundWorker1.CancelAsync()
            envioOK = False
            cargadoError()
            MessageBox.Show("No se ha podido enviar. Revise que está conectado a internet e inténtelo de nuevo.", "Error Apolo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Dim envioOK As Boolean = True
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If envioOK = True Then
            cargado()
            MessageBox.Show("Enviado con éxito. Muchas gracias por su colaboración", "Error Apolo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox1.Enabled = True
        Else
            TextBox1.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Timer1.Enabled = True
        Else
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Panel1.Location.Y < 479 Then
            Panel1.Location = New Size(Panel1.Location.X, Panel1.Location.Y + 5)
            Me.Size = New Size(Me.Width, Me.Height + 5)
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Panel1.Location.Y > 320 Then
            Panel1.Location = New Size(Panel1.Location.X, Panel1.Location.Y - 5)
            Me.Size = New Size(Me.Width, Me.Height - 5)
        Else
            Timer2.Enabled = False
        End If
    End Sub
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
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class