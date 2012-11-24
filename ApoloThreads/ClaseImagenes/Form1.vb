Imports ClaseImagenes.Apolo
Imports System.ComponentModel

Public Class Form1
    Dim WithEvents objetoTratamiento As New TratamientoImagenes 'Objeto para todo el formulario así no se inicializan las variables de la clase en cada instancia
    Dim transformacion As String 'Transformación a aplicar

    Private Sub Atras_Click(sender As Object, e As EventArgs) Handles Atras.Click
        PictureBox2.Image = objetoTratamiento.ListadoImagenesAtras
        TextBox1.Text = objetoTratamiento.ListadoInfoAtras
        TextBox2.Text = objetoTratamiento.ListadoInfoAdelante
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PictureBox2.Image = objetoTratamiento.ListadoImagenesAdelante
        TextBox1.Text = objetoTratamiento.ListadoInfoAtras
        TextBox2.Text = objetoTratamiento.ListadoInfoAdelante
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = objetoTratamiento.ListadoInfoAtras
        TextBox2.Text = objetoTratamiento.ListadoInfoAdelante
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim bmp As New Bitmap(PictureBox2.Image)
        transformacion = "blancoNegro"
        transformar()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim bmp As New Bitmap(PictureBox2.Image)
        transformacion = "invertir"
        transformar()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim bmp As New Bitmap(PictureBox2.Image)
        transformacion = "escalaGrises"
        transformar()
    End Sub

  
    Private Sub AbrirImagenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirImagenToolStripMenuItem.Click
        Dim bmp As Bitmap
        bmp = objetoTratamiento.abrirImagen()
        If bmp IsNot Nothing Then
            PictureBox2.Image = bmp
        End If
    End Sub


#Region "Crear proceso con thread"
    'ACtualizamos el estado del proceso
    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label2.Text = objetoTratamiento.porcentaje(1) & " " & CInt(objetoTratamiento.porcentaje(0)) & " %"
        ProgressBar1.Value = CInt(objetoTratamiento.porcentaje(0))
    End Sub


    'Si no está ocupado activamos el control BackgroundWorker1
    Sub transformar()
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        'Obtener el objeto BackgroundWorker que provocó este evento
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim bmp As New Bitmap(PictureBox2.Image)

        Select Case transformacion
            Case "escalaGrises"
                PictureBox2.Image = objetoTratamiento.EscalaGrises(bmp)
            Case "blancoNegro"
                PictureBox2.Image = objetoTratamiento.BlancoNegro(bmp)
            Case "invertir"
                PictureBox2.Image = objetoTratamiento.Invertir(bmp)
        End Select

    End Sub
    
#End Region

#Region "Actualizar imagen secundaria"

    '******************Actualizar imagen secundaria
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf actualizarPicture)
    End Sub

    'Realizamos esto cuando recibimos el evento
    Sub actualizarPicture(ByVal bmp As Bitmap)
        PictureBox1.Image = bmp
    End Sub

    'FIN de actualizar imagen secundaria
#End Region


End Class
