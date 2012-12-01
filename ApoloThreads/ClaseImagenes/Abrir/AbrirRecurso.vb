Imports ClaseImagenes.Apolo

Public Class AbrirRecurso
    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    'Cerramos la ventana
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    'Abrimos el recurso
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
            cargando()
        End If
    End Sub

    Private Sub AbrirRecurso_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
    End Sub

    Dim cargadoOK As Boolean
    Dim bmp As Bitmap
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        bmp = objetoTratamiento.abrirRecursoWebAxu(Me.TextBox1.Text)
        If bmp IsNot Nothing Then 'Si realmente se abre alguna imagen la asignamos al Picture pricipal
            cargadoOK = True
            Principal.PictureBox1.Image = bmp
            'Aprovechamos y actualizamos el Panel1
            Principal.Panel1.AutoScrollMinSize = Principal.PictureBox1.Image.Size
            Principal.Panel1.AutoScroll = True
        Else
            cargadoOK = False
        End If
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If cargadoOK = True Then
            cargado()
            objetoTratamiento.InfoImagenPrecarga(bmp, TextBox1.Text) 'Lo hacemos en dos pasos (el abrir la imagen y cargar los recursos) porque si no había fallo y no se guardaba la info (por el delegado..)
        Else
            cargadoError()
        End If
    End Sub

    Sub cargando()
        ToolStripProgressBar1.Style = ProgressBarStyle.Marquee
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Size = New Size(100, ToolStripProgressBar1.Size.Height)
        ToolStripProgressBar1.MarqueeAnimationSpeed = 30
    End Sub
    Sub cargado()
        ToolStripStatusLabel1.Text = "Imagen cargada"
        ToolStripProgressBar1.Size = New Size(100, ToolStripProgressBar1.Size.Height)
        ToolStripProgressBar1.Style = ProgressBarStyle.Continuous
        ToolStripProgressBar1.Value = 100
    End Sub

    Sub cargadoError()
        ToolStripStatusLabel1.Text = "Recurso no encontrado"
        ToolStripProgressBar1.Size = New Size(100, ToolStripProgressBar1.Size.Height)
        ToolStripProgressBar1.Style = ProgressBarStyle.Continuous
        ToolStripProgressBar1.Value = 0
    End Sub


End Class