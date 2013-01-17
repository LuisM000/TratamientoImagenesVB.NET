﻿Imports ClaseImagenes.Apolo
Imports System.ComponentModel

Public Class Principal
    Dim WithEvents objetoTratamiento As New TratamientoImagenes 'Objeto para todo el formulario así no se inicializan las variables de la clase en cada instancia
    Dim transformacion As String 'Transformación a aplicar



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Establecemos el control del botón derecho  
        Me.ContextMenuStrip = ContextMenuStrip1
        'Colocamos la imagen secundaria en la parte inferior
        PictureBox2.Location = New Size(PictureBox2.Location.X, SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + 5))
        'Colocamos label imagen general
        Label1.Location = New Size((SplitContainer1.Panel2.Width / 2) - (Label1.Width / 2), PictureBox2.Location.Y - 20)
        'Colocamos los chart y el botón
        Chart1.Location = New Size(Chart1.Location.X, SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + Chart1.Size.Height + 100))
        Chart2.Location = New Size(Chart2.Location.X, SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + (Chart1.Size.Height * 2) + 100))
        Chart3.Location = New Size(Chart3.Location.X, SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + (Chart1.Size.Height * 3) + 100))
        Button1.Location = New Size((SplitContainer1.Panel2.Width / 2) - (Button1.Width / 2), SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + 90))

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
    'Abrir imágenes con FB
    Private Sub BuscarImágenesEnFacebookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarImágenesEnFacebookToolStripMenuItem.Click
        AbrirFacebook.Show()
    End Sub
    'Creamos nuevo tapiz
    Private Sub CrearTapizToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearTapizToolStripMenuItem.Click
        Tapiz.Show()
    End Sub
    'Guardamos imagen
    Private Sub GuardarComoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarComoToolStripMenuItem.Click
        Dim bmp As New Bitmap(Me.PictureBox1.Image)
        objetoTratamiento.guardarcomo(bmp, 4)
    End Sub
#End Region

#Region "Editar"
    Private Sub RefrescarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefrescarToolStripMenuItem.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox2.Image.Size
            Panel1.AutoScroll = True
        End If
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

    Private Sub RegistroDeCambiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeCambiosToolStripMenuItem.Click
        RegistroCambio.Show()
    End Sub

    'Actualizar imagen
    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click
        Dim bmp As New Bitmap(Me.PictureBox1.Image)
        Me.PictureBox1.Image = objetoTratamiento.ActualizarImagen(bmp)
        'Actualizamos el Panel1
        Panel1.AutoScrollMinSize = PictureBox2.Image.Size
        Panel1.AutoScroll = True
    End Sub

    'Deshacer imagen original
    Private Sub ImagenOriginalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImagenOriginalToolStripMenuItem.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ImagenOriginalGuardada
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

    Private Sub FiltroAzulToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltroAzulToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "FiltroAzul"
        transformar()
    End Sub
    Private Sub FiltroVerdeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltroVerdeToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "FiltroVerde"
        transformar()
    End Sub
    Private Sub FiltroRojoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltroRojoToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "FiltroRojo"
        transformar()
    End Sub

    Private Sub BGRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BGRToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "RGBtoBGR"
        transformar()
    End Sub

    Private Sub GRBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GRBToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "RGBtoGRB"
        transformar()
    End Sub

    Private Sub RBGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RBGToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "RGBtoRBG"
        transformar()
    End Sub

    Private Sub HorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HorizontalToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "ReflexionHori"
        transformar()
    End Sub

    Private Sub VerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerticalToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "ReflexionVert"
        transformar()
    End Sub
#End Region

#Region "Operaciones básicos personalizadas"
    Private Sub BlancoYNegroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BlancoYNegroToolStripMenuItem.Click
        BlancoYnegro.Show()
    End Sub

    Private Sub EscalaDeGrisesToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles EscalaDeGrisesToolStripMenuItem2.Click
        EscalaDeGrises.Show()
    End Sub

    Private Sub BrilloToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BrilloToolStripMenuItem1.Click
        Brillo.Show()
    End Sub
    Private Sub Contraste1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Contraste1ToolStripMenuItem.Click
        Contraste1.show()
    End Sub

    Private Sub Contraste2ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles Contraste2ToolStripMenuItem.Click
        Contraste2.Show()
    End Sub
    Private Sub ExposiciónToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExposiciónToolStripMenuItem1.Click
        Exposicion.Show()
    End Sub

    Private Sub ModificarCanalesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModificarCanalesToolStripMenuItem1.Click
        Canales.Show()
    End Sub
    Private Sub ReducirColoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReducirColoresToolStripMenuItem.Click
        ReducirColores.Show()
    End Sub

    Private Sub FiltrarColoresToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltrarColoresToolStripMenuItem.Click
        FiltrarColores.Show()
    End Sub

    Private Sub MatrizToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MatrizToolStripMenuItem.Click
        Matriz.Show()
    End Sub

    Private Sub DetectarContornosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetectarContornosToolStripMenuItem.Click
        Contornos.Show()
    End Sub
#End Region

#Region "Operaciones aritmeticas 1 imagen"

    Private Sub OperacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperacionesToolStripMenuItem.Click
        OperacionesAritmeticas.Show()
    End Sub
    Private Sub OperacionesLógicasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperacionesLógicasToolStripMenuItem.Click
        OperacionesLogicas.Show()
    End Sub
    Private Sub OperacionesMorfológicasbetaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperacionesMorfológicasbetaToolStripMenuItem.Click
        OperadoresMorfologicos.Show()
    End Sub
#End Region

#Region "Máscaras"
    Private Sub PasoAltoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasoAltoToolStripMenuItem.Click
        PasoAlto.Show()
    End Sub

    Private Sub PasoBajoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasoBajoToolStripMenuItem.Click
        PasoBajo.Show()
    End Sub

    Private Sub BordesYContornosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BordesYContornosToolStripMenuItem.Click
        BordesYContornos.Show()
    End Sub

    Private Sub MáscaraManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MáscaraManualToolStripMenuItem.Click
        MascaraManual.Show()
    End Sub
    Private Sub SobelTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SobelTotalToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "SobelTotal"
        transformar()
    End Sub
#End Region

#Region "Efectos"

    Private Sub DesenfoqueMovimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesenfoqueMovimientoToolStripMenuItem.Click
        Desenfocar.Show()
    End Sub
    Private Sub DesenfonqueDistorsiónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesenfonqueDistorsiónToolStripMenuItem.Click
        Distorsion.Show()
    End Sub
    Private Sub DesenfoqueBLURToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesenfoqueBLURToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "blur"
        transformar()
    End Sub

    Private Sub PixeladoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PixeladoToolStripMenuItem.Click
        pixelar.show()
    End Sub

    Private Sub CuadrículaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuadrículaToolStripMenuItem.Click
        Cuadricula.Show()
    End Sub

    Private Sub SombraDeVidrioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SombraDeVidrioToolStripMenuItem.Click
        SombraVidrio.Show()
    End Sub
    Private Sub TresPartesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TresPartesToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "3partes"
        transformar()
    End Sub

    Private Sub SeisPartesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeisPartesToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "6partes"
        transformar()
    End Sub
    Private Sub PonerLosDosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PonerLosDosToolStripMenuItem.Click
        Ruido.Show()
    End Sub

    Private Sub SadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SadToolStripMenuItem.Click
        RuidoDe.Show()
    End Sub

#End Region

#Region "Operaciones con dos imágenes"
    Private Sub SumaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SumaToolStripMenuItem.Click
        OperacionesAritmeticasDosImagenes.Show()
    End Sub

    Private Sub OperacionesLógicasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OperacionesLógicasToolStripMenuItem1.Click
        OperacionesLogicasDosImagenes.Show()
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
            Case "FiltroRojo"
                PictureBox1.Image = objetoTratamiento.filtrosBasicos(bmp, True, False, False)
            Case "FiltroVerde"
                PictureBox1.Image = objetoTratamiento.filtrosBasicos(bmp, False, True, False)
            Case "FiltroAzul"
                PictureBox1.Image = objetoTratamiento.filtrosBasicos(bmp, False, False, True)
            Case "RGBtoBGR"
                PictureBox1.Image = objetoTratamiento.RGBto(bmp, True, False, False)
            Case "RGBtoGRB"
                PictureBox1.Image = objetoTratamiento.RGBto(bmp, False, True, False)
            Case "RGBtoRBG"
                PictureBox1.Image = objetoTratamiento.RGBto(bmp, False, False, True)
            Case "SobelTotal"
                PictureBox1.Image = objetoTratamiento.sobelTotal(bmp)
            Case "ReflexionHori"
                PictureBox1.Image = objetoTratamiento.Reflexion(bmp, True, False)
            Case "ReflexionVert"
                PictureBox1.Image = objetoTratamiento.Reflexion(bmp, False, True)
            Case "3partes"
                PictureBox1.Image = objetoTratamiento.ImagenTresPartes(bmp)
            Case "6partes"
                PictureBox1.Image = objetoTratamiento.ImagenSeisPartes(bmp)
            Case "blur"
                Dim objetoMascara As New TratamientoImagenes.mascaras
                Dim mascara = objetoMascara.LOW9
                PictureBox1.Image = objetoTratamiento.mascara3x3RGB(bmp, mascara, , )
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

#Region "Actualizar histograma"
    Dim tiempo As Integer = 3 'Variable que controla el tiempo de actualización

    Sub actualizarHistrograma() 'Función que recibe y dibuja el histograma
        'Los ponesmos del colores correspondiente
        Chart1.Series("Rojo").Color = Color.Red
        Chart2.Series("Verde").Color = Color.Green
        Chart3.Series("Azul").Color = Color.Blue
        'Borramos el contenido
        Chart1.Series("Rojo").Points.Clear()
        Chart2.Series("Verde").Points.Clear()
        Chart3.Series("Azul").Points.Clear()
        Dim bmp As New Bitmap(PictureBox1.Image, New Size(New Point(100, 100)))
        Dim histoAcumulado = objetoTratamiento.histogramaAcumulado(bmp)
        For i = 0 To UBound(histoAcumulado)
            Chart1.Series("Rojo").Points.AddXY(i + 1, histoAcumulado(i, 0))
            Chart2.Series("Verde").Points.AddXY(i + 1, histoAcumulado(i, 1))
            Chart3.Series("Azul").Points.AddXY(i + 1, histoAcumulado(i, 2))
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        actualizarHistrograma()
        tiempo = 0 'Para que el contador se pare
        Button1.Text = "Actualizar histograma"
    End Sub 'Botón para actualizar histograma manualmente
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If tiempo > 1 Then 'Si es mayor que uno vamos mostrando la cuenta atrás en el botón
            tiempo -= 1
            Button1.Text = "Actualizando en (" & tiempo & ")"
        ElseIf tiempo = 1 Then 'Cuando llega a uno actualizamos
            Button1.Text = "Actualizar histograma"
            actualizarHistrograma()
            tiempo = 0 'Pasamos el tiempo a cero para que no siga descontando y no estre en esta sentencia de control
        End If
    End Sub
#End Region

#Region "Actualizar imagen secundaria/ actualizar hacer y deshacer."
    'Realizamos esto cuando recibimos el evento
    Sub actualizarPicture(ByVal bmp As Bitmap)
        Try
            PictureBox1.Image = bmp
            PictureBox2.Image = bmp
            Timer2.Enabled = True
            'Con esto actualizamos el histograma
            tiempo = 3 '3 segundos para actualización
            Timer3.Enabled = True
        Catch
        End Try
    End Sub

    'Actualizar deshacer/hacer
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        DeshacerToolStripMenuItem.Text = "Deshacer - " & objetoTratamiento.ListadoInfoAtras
        RehacerToolStripMenuItem.Text = "Rehacer - " & objetoTratamiento.ListadoInfoAdelante
        ImagenOriginalToolStripMenuItem.Text = objetoTratamiento.imagenOriginalInfo
    End Sub


    'FIN de actualizar imagen secundaria
#End Region

#Region "Actualizar nombre imagen"
    'Realizamos esto cuando recibimos el evento
    Sub actualizarNombrePicture(ByVal nombre() As String)
        ImagenActual.Text = nombre(0)
        Me.Text = "[" & nombre(0) & "]  " & "(" & nombre(1) & " x " & nombre(2) & ")   " & nombre(3)
        Try 'Actualizamos panel
            Panel1.AutoScrollMinSize = PictureBox1.Image.Size
            Panel1.AutoScroll = True
        Catch ex As Exception

        End Try
    End Sub
    'FIN de actualizar imagen secundaria
#End Region



#Region "DRAG&DROP"
    Private Sub PictureBox1_DragEnter1(sender As Object, e As DragEventArgs)
        'DataFormats.FileDrop nos devuelve el array de rutas de archivos
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            'Los archivos son externos a nuestra aplicación por lo que de indicaremos All ya que dará lo mismo.
            e.Effect = DragDropEffects.All
        End If
    End Sub
    Private Sub PictureBox1_DragDrop1(sender As Object, e As DragEventArgs)
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



#Region "Adaptar panel secundario"
    Private Sub SplitContainer1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        PictureBox2.Width = SplitContainer1.Panel2.Width - 5
        Chart1.Width = SplitContainer1.Panel2.Width
        Chart2.Width = SplitContainer1.Panel2.Width
        Chart3.Width = SplitContainer1.Panel2.Width
        Button1.Width = SplitContainer1.Panel2.Width - 10
        Label1.Location = New Size((SplitContainer1.Panel2.Width / 2) - (Label1.Width / 2), PictureBox2.Location.Y - 20) 'Adaptamos label
    End Sub
#End Region

#Region "Barra de herramientas con imágenes"
    'ABrir imagen
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim bmp As Bitmap
        bmp = objetoTratamiento.abrirImagen()
        If bmp IsNot Nothing Then
            PictureBox1.Image = bmp
            Panel1.AutoScrollMinSize = PictureBox1.Image.Size
            Panel1.AutoScroll = True
        End If
    End Sub
    'ABrir imagen (como recurso)
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        AbrirRecurso.Show()
    End Sub
    'Guardar como...
    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        Dim bmp As New Bitmap(Me.PictureBox1.Image)
        objetoTratamiento.guardarcomo(bmp, 4)
    End Sub
    'ABrir imagen desde bing
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        AbrirBing.Show()
    End Sub
    'ABrir imagen desde facebook
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        AbrirFacebook.Show()
    End Sub
    'Deshacer
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ListadoImagenesAtras
        End If
    End Sub
    'Rehacer
    Private Sub ToolStripButton6_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ListadoImagenesAdelante
        End If
    End Sub
    'Refrescar
    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox2.Image.Size
            Panel1.AutoScroll = True
        End If
    End Sub
    'Actualizar
    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Dim bmp As New Bitmap(Me.PictureBox1.Image)
        Me.PictureBox1.Image = objetoTratamiento.ActualizarImagen(bmp)
        'Actualizamos el Panel1
        Panel1.AutoScrollMinSize = PictureBox2.Image.Size
        Panel1.AutoScroll = True
    End Sub
    'Blanco y negro
    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "blancoNegro"
        transformar()
    End Sub
    'Escala de grises
    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        transformacion = "escalaGrises"
        transformar()
    End Sub
#End Region

#Region "ContextMenuStrip (Botón derecho)"

    Private Sub AbrirImagenToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles AbrirImagenToolStripMenuItem3.Click
        Dim bmp As Bitmap
        bmp = objetoTratamiento.abrirImagen()
        If bmp IsNot Nothing Then
            PictureBox1.Image = bmp
            Panel1.AutoScrollMinSize = PictureBox1.Image.Size
            Panel1.AutoScroll = True
        End If
    End Sub

    Private Sub GuardarImagenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarImagenToolStripMenuItem.Click
        Dim bmp As New Bitmap(Me.PictureBox1.Image)
        objetoTratamiento.guardarcomo(bmp, 4)
    End Sub

    Private Sub RefrescarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RefrescarToolStripMenuItem2.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox2.Image.Size
            Panel1.AutoScroll = True
        End If
    End Sub

    Private Sub ActualizarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem2.Click
        Dim bmp As New Bitmap(Me.PictureBox1.Image)
        Me.PictureBox1.Image = objetoTratamiento.ActualizarImagen(bmp)
        'Actualizamos el Panel1
        Panel1.AutoScrollMinSize = PictureBox2.Image.Size
        Panel1.AutoScroll = True
    End Sub
#End Region



    Private Sub Chart3_Click(sender As Object, e As EventArgs) Handles Chart3.Click
        'Hay que crear la instancia con constructor y el valor del color
        Dim frmHisto As New Histogramas(Color.Blue)
        frmHisto.Show()

    End Sub

    Private Sub Chart2_Click(sender As Object, e As EventArgs) Handles Chart2.Click
        'Hay que crear la instancia con constructor y el valor del color
        Dim frmHisto As New Histogramas(Color.Green)
        frmHisto.Show()

    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click
        'Hay que crear la instancia con constructor y el valor del color
        Dim frmHisto As New Histogramas(Color.Red)
        frmHisto.Show()
    End Sub
End Class
