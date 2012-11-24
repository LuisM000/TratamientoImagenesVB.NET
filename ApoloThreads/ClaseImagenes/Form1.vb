Imports ClaseImagenes.Apolo
Imports System.ComponentModel

Public Class Form1
    Dim WithEvents objetoTratamiento As New TratamientoImagenes 'Objeto para todo el formulario así no se inicializan las variables de la clase en cada instancia
    Dim transformacion As String 'Transformación a aplicar



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Habilitamos el arrastre para el control PictureBox2 (No lo tiene permitido en tiempo de diseño)
        PictureBox2.AllowDrop = True
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf actualizarNombrePicture)
    End Sub


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

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim bmp As Bitmap
        bmp = objetoTratamiento.abrirRecursoWeb(TextBox4.Text)
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
    'Realizamos esto cuando recibimos el evento
    Sub actualizarPicture(ByVal bmp As Bitmap)
        PictureBox1.Image = bmp
    End Sub
    'FIN de actualizar imagen secundaria
#End Region

#Region "Actualizar nombre imagen"
    'Realizamos esto cuando recibimos el evento
    Sub actualizarNombrePicture(ByVal nombre As String)
        TextBox3.Text = nombre
    End Sub
    'FIN de actualizar imagen secundaria
#End Region



#Region "DRAG&DROP"
    Private Sub PictureBox2_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox2.DragEnter
        'DataFormats.FileDrop nos devuelve el array de rutas de archivos
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'Los archivos son externos a nuestra aplicación por lo que de indicaremos All ya que dará lo mismo.
            e.Effect = DragDropEffects.All
        End If
    End Sub
    Private Sub PictureBox2_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox2.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim rutaImagen As String
            'Asignamos la primera posición del array de ruta de archivos a la variable de tipo string
            'declarada anteriormente ya que en este caso sólo mostraremos una imagen en el control.
            rutaImagen = e.Data.GetData(DataFormats.FileDrop)(0)
            'La cargamos al control
            Dim bmp As Bitmap
            bmp = objetoTratamiento.abrirDragDrop(rutaImagen)
            If bmp IsNot Nothing Then
                PictureBox2.Image = bmp
            End If
        End If
    End Sub
#End Region

End Class
