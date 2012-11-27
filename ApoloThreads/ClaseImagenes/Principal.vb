Imports ClaseImagenes.Apolo
Imports System.ComponentModel

Public Class Principal
    Dim WithEvents objetoTratamiento As New TratamientoImagenes 'Objeto para todo el formulario así no se inicializan las variables de la clase en cada instancia
    Dim transformacion As String 'Transformación a aplicar



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Habilitamos el arrastre para el control PictureBox1 (No lo tiene permitido en tiempo de diseño)
        PictureBox1.AllowDrop = True
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf actualizarNombrePicture)
    End Sub


#Region "Archivo"
    'Abrir imagen desde archivo
    Private Sub AbrirImagenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AbrirImagenToolStripMenuItem1.Click
        Dim bmp As Bitmap
        bmp = objetoTratamiento.abrirImagen()
        If bmp IsNot Nothing Then
            PictureBox1.Image = bmp
            Panel1.AutoScrollMinSize = PictureBox1.Image.Size
            Panel1.AutoScroll = True
        End If
    End Sub

    'Abrir imagen como recurso web
    Private Sub CargarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CargarToolStripMenuItem.Click
        AbrirRecurso.Show()
    End Sub

    'Abrir imágenes con BING
    Private Sub BuscarImágenesEnLaWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarImágenesEnLaWebToolStripMenuItem.Click
        AbrirBing.Show()
    End Sub
#End Region

#Region "Editar"
    Private Sub RefrescarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefrescarToolStripMenuItem.Click
        'Actualizamos el Panel1
        Panel1.AutoScrollMinSize = PictureBox2.Image.Size
        Panel1.AutoScroll = True
    End Sub

    'Deshacer
    Private Sub DeshacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeshacerToolStripMenuItem.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ListadoImagenesAtras
        End If
    End Sub

    'Rehacer
    Private Sub RehacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RehacerToolStripMenuItem.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ListadoImagenesAdelante
        End If
    End Sub


#End Region

#Region "OperacionesBasicas"
    Private Sub EscalaDeGrisesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EscalaDeGrisesToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "blancoNegro"
        transformar()
    End Sub

    Private Sub EscalaDeGrisesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EscalaDeGrisesToolStripMenuItem1.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "escalaGrises"
        transformar()
    End Sub


    Private Sub RGBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RGBToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "invertir"
        transformar()
    End Sub

    Private Sub RojoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RojoToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "invertirRojo"
        transformar()
    End Sub

    Private Sub VerdeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerdeToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "invertirVerde"
        transformar()
    End Sub

    Private Sub AzulToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AzulToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "invertirAzul"
        transformar()
    End Sub

    Private Sub SepiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SepiaToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "sepia"
        transformar()
    End Sub

    Private Sub BrilloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrilloToolStripMenuItem.Click
        Brillo.Show()
    End Sub
#End Region


#Region "Crear proceso con thread"
    'ACtualizamos el estado del proceso
    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        BarraEstado.Value = CInt(TratamientoImagenes.porcentaje(0))
        EstadoActual.Text = TratamientoImagenes.porcentaje(1)
        PorcentajeActual.Text = CInt(TratamientoImagenes.porcentaje(0)) & " %"
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
        Dim bmp As New Bitmap(PictureBox1.Image)

        Select Case transformacion
            Case "escalaGrises"
                PictureBox1.Image = objetoTratamiento.EscalaGrises(bmp)
            Case "blancoNegro"
                PictureBox1.Image = objetoTratamiento.BlancoNegro(bmp)
            Case "invertir"
                PictureBox1.Image = objetoTratamiento.Invertir(bmp)
            Case "invertirRojo"
                PictureBox1.Image = objetoTratamiento.Invertir(bmp, True, False, False)
            Case "invertirVerde"
                PictureBox1.Image = objetoTratamiento.Invertir(bmp, False, True, False)
            Case "invertirAzul"
                PictureBox1.Image = objetoTratamiento.Invertir(bmp, False, False, True)
            Case "sepia"
                PictureBox1.Image = objetoTratamiento.sepia(bmp)
        End Select
    End Sub

    'Cuando acaba el hilo..
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'Aprovechamos y actualizamos el Panel1
        Panel1.AutoScrollMinSize = PictureBox1.Image.Size
        Panel1.AutoScroll = True
        BackgroundWorker1.Dispose()
    End Sub

#End Region


#Region "Actualizar imagen secundaria/ actualizar hacer y deshacer"
    'Realizamos esto cuando recibimos el evento
    Sub actualizarPicture(ByVal bmp As Bitmap)
        Try
            PictureBox1.Image = bmp
            PictureBox2.Image = bmp
            Timer2.Enabled = True
        Catch
        End Try
    End Sub
    'Actualizar deshacer/hacer
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        DeshacerToolStripMenuItem.Text = "Deshacer - " & objetoTratamiento.ListadoInfoAtras
        RehacerToolStripMenuItem.Text = "Rehacer - " & objetoTratamiento.ListadoInfoAdelante
    End Sub
    'FIN de actualizar imagen secundaria
#End Region

#Region "Actualizar nombre imagen"
    'Realizamos esto cuando recibimos el evento
    Sub actualizarNombrePicture(ByVal nombre() As String)
        ImagenActual.Text = nombre(0)
        Me.Text = "[" & nombre(0) & "]  " & "(" & nombre(1) & " x " & nombre(2) & ")   " & nombre(3)

    End Sub
    'FIN de actualizar imagen secundaria
#End Region



#Region "DRAG&DROP"
    Private Sub PictureBox1_DragEnter(sender As Object, e As DragEventArgs) Handles PictureBox1.DragEnter
        'DataFormats.FileDrop nos devuelve el array de rutas de archivos
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'Los archivos son externos a nuestra aplicación por lo que de indicaremos All ya que dará lo mismo.
            e.Effect = DragDropEffects.All
        End If
    End Sub
    Private Sub PictureBox1_DragDrop(sender As Object, e As DragEventArgs) Handles PictureBox1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim rutaImagen As String
            'Asignamos la primera posición del array de ruta de archivos a la variable de tipo string
            'declarada anteriormente ya que en este caso sólo mostraremos una imagen en el control.
            rutaImagen = e.Data.GetData(DataFormats.FileDrop)(0)
            'La cargamos al control
            Dim bmp As Bitmap
            bmp = objetoTratamiento.abrirDragDrop(rutaImagen)
            If bmp IsNot Nothing Then
                PictureBox1.Image = bmp
            End If
        End If
    End Sub
#End Region


End Class
