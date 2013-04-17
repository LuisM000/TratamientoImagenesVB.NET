Imports ClaseImagenes.Apolo
Imports System.ComponentModel
Imports System.IO

Public Class Principal
    Dim WithEvents objetoTratamiento As New TratamientoImagenes 'Objeto para todo el formulario así no se inicializan las variables de la clase en cada instancia
    Dim transformacion As String 'Transformación a aplicar

#Region "control de excepciones"
    Private Shared Sub Application_ThreadException(ByVal sender As Object, ByVal e As System.Threading.ThreadExceptionEventArgs)
        Dim objetoTra As New TratamientoImagenes
        Dim captura As Bitmap = objetoTra.capturarPantalla(True)
        Dim excepc As Exception = e.Exception
        'Hay que crear la instancia con constructor
        Dim frmError As New NotificacionError(captura, excepc)
        frmError.Show()
    End Sub
#End Region

    Private Sub Principal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Forzamos una recolección de elementos no utilizados
        GC.Collect()
        GC.WaitForPendingFinalizers()
        'Al cerrar el formulario borramos todo lo acumulador por el programa
        Dim folder As New DirectoryInfo(System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\") 'Directorio
        Dim listaDearchivos As New ArrayList
        For Each file As FileInfo In folder.GetFiles() 'Comprobamos si los archivos xml
            Try
                My.Computer.FileSystem.DeleteFile(folder.ToString & file.ToString)
            Catch
            End Try
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Manejamos cualquier excepción no controlada
        AddHandler Application.ThreadException, AddressOf Application_ThreadException

        'borramos todo lo acumulador por el programa
        Dim folder As New DirectoryInfo(System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\") 'Directorio
        Dim listaDearchivos As New ArrayList
        For Each file As FileInfo In folder.GetFiles() 'Comprobamos si los archivos xml
            Try
                My.Computer.FileSystem.DeleteFile(folder.ToString & file.ToString)
            Catch
            End Try
        Next
        'Manejamos cualquier excepción no controlada
        AddHandler Application.ThreadException, AddressOf Application_ThreadException

        'Establecemos el control del botón derecho  
        Me.ContextMenuStrip = ContextMenuStrip1
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf actualizarNombrePicture)

        'Habilitamos el arrastre para el control PictureBox1 (No lo tiene permitido en tiempo de diseño)
        PictureBox1.AllowDrop = True
        Panel1.AllowDrop = True
        'ACtualizamos la imagen Lena
        Dim bmp As New Bitmap(Me.PictureBox1.Image)
        Me.PictureBox1.Image = objetoTratamiento.ActualizarImagen(bmp, True)
        'ACtualizamos de forma manual el histograma
        actualizarHistrograma()
        tiempo = 0 'Para que el contador se pare
        Button1.Text = "Actualizar histograma"

        'Tamaño del Picturebox 4 del tabpage 2 que muestra zoo
        PictureBox4.Size = New Size(My.Settings.TamanoPictuZoomfijo, My.Settings.TamanoPictuZoomfijo)

        'Comprobamos actualizaciones automáticas
        Actualizar = Nothing
        If My.Settings.Actualizaciones_Comprobar = True Then
            ActualizacionesAutomáticasToolStripMenuItem.Checked = True
            If BackgroundWorkerACtual_Automaticas.IsBusy = False Then
                BackgroundWorkerACtual_Automaticas.RunWorkerAsync()
            End If
        Else
            ActualizacionesAutomáticasToolStripMenuItem.Checked = False
        End If

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
        Bing2.Show()
    End Sub

    'Abrir imágenes con BING con precarga
    Private Sub AsdasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsdasToolStripMenuItem.Click
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
        Dim bmp As New Bitmap(Me.PictureBox2.Image)
        objetoTratamiento.guardarcomo(bmp, 4)
    End Sub
    Private Sub AbrirCompiladorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirCompiladorToolStripMenuItem.Click
        'Abrimos el exe y guardamos la imagen actual
        Dim bmpComp As New Bitmap(PictureBox2.Image)
        bmpComp.Save(System.IO.Directory.GetCurrentDirectory().ToString & "\Compilador\imgforCompilador.png", System.Drawing.Imaging.ImageFormat.Png)
        Dim Process1 As New Process
        Process1.StartInfo.RedirectStandardOutput = True
        Process1.StartInfo.FileName = System.IO.Directory.GetCurrentDirectory().ToString & "\Compilador\FastSharp.exe"
        Process1.StartInfo.UseShellExecute = False
        Process1.StartInfo.CreateNoWindow = True
        Process1.Start()
        'A la espera de que se cierre...
        Process1.WaitForExit()
        'Aquí listar todas las imágenes que se han creado
        ImgCompilador.ShowDialog()
    End Sub

    Private Sub CompartirImagenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompartirImagenToolStripMenuItem.Click
        Dim form As New Compartir()
        form.Show()
    End Sub
#End Region

#Region "Editar"
    Private Sub RefrescarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefrescarToolStripMenuItem.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox1.Image.Size
            Panel1.AutoScroll = True
        End If
    End Sub

    'Deshacer
    Private Sub DeshacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeshacerToolStripMenuItem.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ListadoImagenesAtras
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox2.Image.Size
            Panel1.AutoScroll = True
            ToolStripStatusLabel4.Text = "Zoom: x" & objetoTratamiento.Zoom
        End If
    End Sub

    'Rehacer
    Private Sub RehacerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RehacerToolStripMenuItem.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ListadoImagenesAdelante
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox2.Image.Size
            Panel1.AutoScroll = True
            ToolStripStatusLabel4.Text = "Zoom: x" & objetoTratamiento.Zoom
        End If
    End Sub

    Private Sub RegistroDeCambiosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistroDeCambiosToolStripMenuItem.Click
        RegistroCambio.Show()
    End Sub

    'Actualizar imagen
    Private Sub ActualizarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem.Click
        Dim bmp As New Bitmap(Me.PictureBox2.Image)
        Me.PictureBox1.Image = objetoTratamiento.ActualizarImagen(bmp)
        'Actualizamos el Panel1
        Panel1.AutoScrollMinSize = PictureBox1.Image.Size
        Panel1.AutoScroll = True
        ToolStripStatusLabel4.Text = "Zoom: x" & objetoTratamiento.Zoom
    End Sub

    'Deshacer imagen original
    Private Sub ImagenOriginalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImagenOriginalToolStripMenuItem.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ImagenOriginalGuardada
        End If
    End Sub
    'Propiedades de la imagen
    Private Sub PropiedadesDeLaImagenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropiedadesDeLaImagenToolStripMenuItem.Click
        PropImagen.Show()
    End Sub
    Private Sub ZoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem.Click
        If BackgroundWorker2.IsBusy = False Then
            BackgroundWorker2.RunWorkerAsync()
            objetoTratamiento.Zoom += 0.1
        End If
    End Sub

    Private Sub ZoomToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem1.Click
        If objetoTratamiento.Zoom - 0.1 > 0 Then
            If BackgroundWorker2.IsBusy = False Then
                BackgroundWorker2.RunWorkerAsync()
                objetoTratamiento.Zoom -= 0.1
            End If
        Else
            MessageBox.Show("Zoom mínimo superado.", "Apolo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    'Zoom interactivo
    Private Sub EmpezarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmpezarToolStripMenuItem.Click
        MessageBox.Show("Pulse la tecla SHIFT y muévase por la imagen para ver la imagen ampliada." & vbCrLf & "Mueva la rueda del ratón para ampliar o disminuir el zoom.", "Zoom interactivo", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub

    Private Sub PropiedadesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PropiedadesToolStripMenuItem.Click
        PropiedadesZoom.Show()
    End Sub
    Private Sub DeshacerZoomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeshacerZoomToolStripMenuItem.Click
        If BackgroundWorker2.IsBusy = False Then
            objetoTratamiento.Zoom = 1
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub

    Private Sub AjustarAPantallaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AjustarAPantallaToolStripMenuItem.Click
        Dim bmpAjustado As New Bitmap(PictureBox1.Image, SplitContainer1.Panel1.Width, SplitContainer1.Panel1.Height)
        PictureBox1.Image = bmpAjustado
        objetoTratamiento.ActualizarImagen(bmpAjustado)
        Panel1.AutoScroll = False 'Quitamos los scrolls para que se vea la imagen completa
    End Sub
    'Captura de pantalla
    Private Sub CapturaDePantallaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CapturaDePantallaToolStripMenuItem.Click
        If BackgroundWorker2.IsBusy = False Then
            Dim bmpCaptura As Bitmap
            bmpCaptura = objetoTratamiento.capturarPantalla(False)
            PictureBox1.Image = bmpCaptura
            refrescar()
        End If
    End Sub
    'Copiar
    Private Sub CopiarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem.Click
        My.Computer.Clipboard.SetImage(PictureBox1.Image)
    End Sub
    'Pegar
    Private Sub PegarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem.Click
        If My.Computer.Clipboard.ContainsImage() Then
            PictureBox1.Image = objetoTratamiento.ActualizarImagen(My.Computer.Clipboard.GetImage(), True)
        End If
    End Sub
#End Region



#Region "OperacionesBasicas"
    Private Sub EscalaDeGrisesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EscalaDeGrisesToolStripMenuItem.Click
        transformacion = "blancoNegro"
        transformar()
    End Sub

    Private Sub EscalaDeGrisesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EscalaDeGrisesToolStripMenuItem1.Click
        transformacion = "escalaGrises"
        transformar()
    End Sub


    Private Sub RGBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RGBToolStripMenuItem.Click
        transformacion = "invertir"
        transformar()
    End Sub

    Private Sub RojoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RojoToolStripMenuItem.Click
        transformacion = "invertirRojo"
        transformar()
    End Sub

    Private Sub VerdeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerdeToolStripMenuItem.Click
        transformacion = "invertirVerde"
        transformar()
    End Sub

    Private Sub AzulToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AzulToolStripMenuItem.Click
        transformacion = "invertirAzul"
        transformar()
    End Sub

    Private Sub SepiaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SepiaToolStripMenuItem.Click
        transformacion = "sepia"
        transformar()
    End Sub

    Private Sub FiltroAzulToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltroAzulToolStripMenuItem.Click
        transformacion = "FiltroAzul"
        transformar()
    End Sub
    Private Sub FiltroVerdeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltroVerdeToolStripMenuItem.Click
        transformacion = "FiltroVerde"
        transformar()
    End Sub
    Private Sub FiltroRojoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FiltroRojoToolStripMenuItem.Click
        transformacion = "FiltroRojo"
        transformar()
    End Sub

    Private Sub BGRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BGRToolStripMenuItem.Click
        transformacion = "RGBtoBGR"
        transformar()
    End Sub

    Private Sub GRBToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GRBToolStripMenuItem.Click
        transformacion = "RGBtoGRB"
        transformar()
    End Sub

    Private Sub RBGToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RBGToolStripMenuItem.Click
        transformacion = "RGBtoRBG"
        transformar()
    End Sub

    'Histograma detallada
    Private Sub DetalladoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DetalladoToolStripMenuItem1.Click
        'Hay que crear la instancia con constructor y el valor del color
        Dim frmHisto As New Histogramas(Color.Red)
        frmHisto.Show()
    End Sub
    'Todos los histogramas
    Private Sub TodosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TodosToolStripMenuItem1.Click
        TodosHistogramas.Show()
    End Sub
    'Redimensionar imagen
    Private Sub RedimensionarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RedimensionarToolStripMenuItem.Click
        Redimensionar.Show()
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
        Contraste1.Show()
    End Sub

    Private Sub Contraste2ToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles Contraste2ToolStripMenuItem.Click
        Contraste2.Show()
    End Sub
    Private Sub GamaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GamaToolStripMenuItem.Click
        Gamma.Show()
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

    Private Sub CorregirOjosRojosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorregirOjosRojosToolStripMenuItem.Click
        OjosRojos.Show()
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
    Private Sub OperacionesEstadísticasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperacionesEstadísticasToolStripMenuItem.Click
        OperacionesEstadisticas.Show()
    End Sub
    Private Sub OperacionesMorfológicasbetaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperacionesMorfológicasbetaToolStripMenuItem.Click
        OperadoresMorfologicos.Show()
    End Sub
#Region "Transformaciones geométricas"
    'Reflexión horizontal
    Private Sub HorizontalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HorizontalToolStripMenuItem.Click
        transformacion = "ReflexionHori"
        transformar()
    End Sub
    'Reflexión vertical
    Private Sub VerticalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VerticalToolStripMenuItem.Click
        transformacion = "ReflexionVert"
        transformar()
    End Sub
    'Traslación
    Private Sub TraslaciónToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles TraslaciónToolStripMenuItem2.Click
        Traslacion.Show()
    End Sub
    'Voltear
    Private Sub VolteadosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VolteadosToolStripMenuItem.Click
        Voltear.Show()
    End Sub
    'Sesgar imagen (T afín manual)
    Private Sub ManualsesgarImagenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualsesgarImagenToolStripMenuItem.Click
        Afin.Show()
    End Sub

    Private Sub PersonalizadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PersonalizadaToolStripMenuItem.Click
        TAfinPers.Show()
    End Sub
#End Region
    'Density Sciling
    Private Sub AutomáticoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AutomáticoToolStripMenuItem.Click
        DensityScilingAuto.Show()
    End Sub
    'Density Sciling manual
    Private Sub ManualToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualToolStripMenuItem.Click
        DensityScilingManual.Show()
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

    Private Sub MáscaraPersonalizadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MáscaraPersonalizadaToolStripMenuItem.Click
        MascaraPersonal.Show()
    End Sub
    Private Sub SobelTotalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SobelTotalToolStripMenuItem.Click
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
        transformacion = "blur"
        transformar()
    End Sub

    Private Sub PixeladoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PixeladoToolStripMenuItem.Click
        Pixelar.Show()
    End Sub

    Private Sub CuadrículaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CuadrículaToolStripMenuItem.Click
        Cuadricula.Show()
    End Sub

    Private Sub SombraDeVidrioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SombraDeVidrioToolStripMenuItem.Click
        SombraVidrio.Show()
    End Sub
    Private Sub TresPartesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TresPartesToolStripMenuItem.Click
        transformacion = "3partes"
        transformar()
    End Sub

    Private Sub SeisPartesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeisPartesToolStripMenuItem.Click
        transformacion = "6partes"
        transformar()
    End Sub
    Private Sub PonerLosDosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PonerLosDosToolStripMenuItem.Click
        Ruido.Show()
    End Sub

    Private Sub SadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SadToolStripMenuItem.Click
        RuidoDe.Show()
    End Sub

    Private Sub ÓleoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÓleoToolStripMenuItem.Click
        Oleo.Show()
    End Sub
    Private Sub EfectoMarteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EfectoMarteToolStripMenuItem.Click
        transformacion = "Marte"
        transformar()
    End Sub

    Private Sub EfectoAntiguoSobreexpuestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EfectoAntiguoSobreexpuestoToolStripMenuItem.Click
        transformacion = "AntiguiSobreexpu"
        transformar()
    End Sub
    Private Sub EfectoMarinoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EfectoMarinoToolStripMenuItem.Click
        transformacion = "Marino"
        transformar()
    End Sub
    Private Sub AumentarRasgosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AumentarRasgosToolStripMenuItem.Click
        transformacion = "AumentarRasgos"
        transformar()
    End Sub
    Private Sub DisminuirRasgosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DisminuirRasgosToolStripMenuItem.Click
        transformacion = "DisminuirRasgos"
        transformar()
    End Sub
    Private Sub ContenidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContenidoToolStripMenuItem.Click
        transformacion = "ContSombreado1"
        transformar()
    End Sub

    Private Sub DesmedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesmedidoToolStripMenuItem.Click
        transformacion = "ContSombreado2"
        transformar()
    End Sub

    Private Sub ColorearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColorearToolStripMenuItem.Click
        transformacion = "AumentarLuz"
        transformar()
    End Sub
    Private Sub MarcoDeCineToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MarcoDeCineToolStripMenuItem1.Click
        Cine.Show()
    End Sub
    Private Sub Marco4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Marco4ToolStripMenuItem.Click
        transformacion = "Marco4"
        transformar()
    End Sub

    Private Sub Marco3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Marco3ToolStripMenuItem.Click
        transformacion = "Marco3"
        transformar()
    End Sub

    Private Sub Marco2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Marco2ToolStripMenuItem.Click
        transformacion = "Marco2"
        transformar()
    End Sub

    Private Sub Marco1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Marco1ToolStripMenuItem.Click
        transformacion = "Marco1"
        transformar()
    End Sub

#End Region

#Region "Operaciones con dos imágenes"
    Private Sub SumaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SumaToolStripMenuItem.Click
        OperacionesAritmeticasDosImagenes.Show()
    End Sub

    Private Sub OperacionesLógicasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OperacionesLógicasToolStripMenuItem1.Click
        OperacionesLogicasDosImagenes.Show()
    End Sub

    Private Sub LocalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LocalToolStripMenuItem.Click
        CompararImagenes.Show()
    End Sub

    Private Sub AnaglifoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnaglifoToolStripMenuItem.Click
        Anaglifo.Show()
    End Sub
    Private Sub VecinosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VecinosToolStripMenuItem.Click
        CompararImagenesVecinos.Show()
    End Sub
#End Region

#Region "Cloud"
    Private Sub GuardarImágenesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarImágenesToolStripMenuItem.Click
        Dim form As New Compartir()
        form.Show()
    End Sub
    Private Sub CrearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearToolStripMenuItem.Click
        CrearCarpetaPrivada.Show()
    End Sub

    Private Sub AccesoCarpetaPrivadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccesoCarpetaPrivadaToolStripMenuItem.Click
        AccesoPrivado.Show()
    End Sub
#End Region

#Region "Herramientas"
    Dim HistogramasAutomáticos As Boolean = True
    'Activa/desactiva histogramas automáticos
    Private Sub HistogramasAutomáticosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistogramasAutomáticosToolStripMenuItem.Click
        If HistogramasAutomáticosToolStripMenuItem.Checked = True Then
            tiempo = 0 'Para que el contador se pare
            Button1.Text = "Actualizar histograma"
            TabPage1.Text = "Histograma"
            TabPage2.Text = "Registro cambios"
            HistogramasAutomáticos = True
        Else
            tiempo = 0 'Para que el contador se pare
            Button1.Text = "Actualizar histograma"
            TabPage1.Text = "Histograma"
            TabPage2.Text = "Registro cambios"
            HistogramasAutomáticos = False
        End If
    End Sub
    'Liberar memoria (libera todas las imágenes guardadas para hacer retroceso)
    Private Sub LiberarMemoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LiberarMemoriaToolStripMenuItem.Click
        Dim resultado = MessageBox.Show("Esta opción borrará todo el historial de imágenes y no podrá ser recuperado. Además, es posible que durante unos segundos se ralentice el sistema. ¿Está seguro de querer hacerlo?", "Apolo thread", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If resultado = Windows.Forms.DialogResult.Yes Then
            Dim objeto As New TratamientoImagenes
            objeto.LiberarImagenes()
            'forzamos la actualización del tabpage 2 (registro imágenes). Los histogramas no son necesarios puesto que nos quedamos con la imagen actual
            TabControl1_SelectedIndexChanged(sender, e)
            ClearMemory()
        End If
    End Sub
    'Ocultar/mostrar barra de accesos rápidos
    Private Sub BarraAccesosRápidosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarraAccesosRápidosToolStripMenuItem.Click
        If BarraAccesosRápidosToolStripMenuItem.Checked = False Then
            ToolStrip1.Visible = False
        Else
            ToolStrip1.Visible = True
        End If
    End Sub

    'Código para liberar RAM disponible en************************
    'http://gdev.wordpress.com/2005/11/30/liberar-memoria-con-vb-net/
    'Declaración de la API
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean
    Public Sub ClearMemory()

        Try
            Dim Mem As Process
            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)
        Catch ex As Exception
            'Control de errores
        End Try
    End Sub
    'Comprobar actualizaciones automáticamente
    Private Sub ActualizacionesAutomáticasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActualizacionesAutomáticasToolStripMenuItem.Click
        If ActualizacionesAutomáticasToolStripMenuItem.Checked = False Then
            ActualizacionesAutomáticasToolStripMenuItem.Checked = False
        Else
            ActualizacionesAutomáticasToolStripMenuItem.Checked = True
        End If
        My.Settings.Save()
    End Sub
    Private Sub BackgroundWorkerACtual_Automaticas_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorkerACtual_Automaticas.DoWork
        Actualizar = objetoActualizacion.ComprobarVersion()
    End Sub

    Private Sub BackgroundWorkerACtual_Automaticas_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorkerACtual_Automaticas.RunWorkerCompleted
          Select Actualizar(0)
            Case "Error"
                MessageBox.Show("No se pudo conectar. Compruebe las actualizaciones más tarde.", "Error comprobar actualizaciones", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Case My.Application.Info.Version.ToString
                'MessageBox.Show("¡Apolo está actualizado!" & vbCrLf & "Versión: " & My.Application.Info.Version.ToString, "Comprobar actualizaciones", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            Case Else
                Dim textoMejoras As String
                textoMejoras = "Hay una nueva versión disponible:" & vbCrLf
                textoMejoras += "Versión: " & Actualizar(0) & vbCrLf & "Mejoras: "
                For i = 1 To Actualizar.Length - 1
                    textoMejoras += Actualizar(i)
                Next
                textoMejoras += vbCrLf & "-----------------------" & vbCrLf & "Si decide instalar la nueva actualización se cerrará Apolo, ¿está seguro de que desea actualizar ahora?"
                Dim respuestaActualizacion = MessageBox.Show(textoMejoras, "Comprobar actualizaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If respuestaActualizacion = Windows.Forms.DialogResult.Yes Then
                    Dim rutaArchivo As String
                    If System.Environment.Is64BitOperatingSystem = True Then 'Comprobamos el tipo de sistema operativo
                        rutaArchivo = objetoActualizacion.DescargarActualizacion(True)
                    Else
                        rutaArchivo = objetoActualizacion.DescargarActualizacion(False)
                    End If
                    Process.Start(rutaArchivo)
                    Application.Exit()
                End If
        End Select
    End Sub
     
    'Grabar secuencia
    Private Sub GrabarSecuenciaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrabarSecuenciaToolStripMenuItem.Click
        GrabarSecuencia.Show()
    End Sub
#End Region

#Region "Menú ayuda"

    Private Sub AyudaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem1.Click
        Process.Start(System.IO.Directory.GetCurrentDirectory().ToString & "\HelpApolo.chm")
    End Sub

    Private Sub AyudaEnLaWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaEnLaWebToolStripMenuItem.Click
        System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory().ToString & "\DocumentacionHTML\DocumentacionApolo.html")
    End Sub

    Private Sub ArchivoAyudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchivoAyudaToolStripMenuItem.Click
        System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory().ToString & "\DocumentacionDesarrolloClaseImagenes.chm")
    End Sub

    Private Sub EnLaWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EnLaWebToolStripMenuItem.Click
        System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory().ToString & "\DocumentacionDesarrolloClaseImagenesHTML\DocumentacionDesarrolloClaseImagenes.html")
    End Sub

    Private Sub ArchivoDeAyudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArchivoDeAyudaToolStripMenuItem.Click
        System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory().ToString & "\DocumentacionTecnica\DocumentationTecnica.chm")
    End Sub

    Private Sub EnLaWebToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EnLaWebToolStripMenuItem1.Click
        System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory().ToString & "\DocumentacionTecnica\Index.html")
    End Sub
    Private Sub ClaseImagenesToolStripMenuItem_Click(sender As Object, e As EventArgs)
        System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory().ToString & "\DocumentacionTecnica\DocumentationTecnica.chm")
    End Sub

    Private Sub ClaseImagenesEnLaWebToolStripMenuItem_Click(sender As Object, e As EventArgs)
        System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory().ToString & "\DocumentacionTecnica\index.html")
    End Sub
    Private Sub NotificarUnErrorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NotificarUnErrorToolStripMenuItem.Click
        NotificarErrorAyuda.Show()
    End Sub

    Private Sub AyúdanosAMejorarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyúdanosAMejorarToolStripMenuItem.Click
        AyudanosAmejorar.Show()
    End Sub
    Private Sub ColaboraConElProyectoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColaboraConElProyectoToolStripMenuItem.Click
        Colabora.Show()
    End Sub
    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub

    'Comprobar actualizaciones
    Dim objetoActualizacion As New Actualizar 'Instancia a la clase actualizar
    Dim Actualizar() As String 'contendrá los datos de la actualización (datos del archivo descargado)

    Private Sub ComprobarActualizacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprobarActualizacionesToolStripMenuItem.Click
        If BackgroundWorkerACTUALIZACION.IsBusy = False Then
            Actualizar = Nothing
            BackgroundWorkerACTUALIZACION.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorkerACTUALIZACION_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorkerACTUALIZACION.DoWork
        Actualizar = objetoActualizacion.ComprobarVersion()
    End Sub

    Private Sub BackgroundWorkerACTUALIZACION_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorkerACTUALIZACION.RunWorkerCompleted
        Select Case Actualizar(0)
            Case "Error"
                MessageBox.Show("No se pudo conectar. Compruebe las actualizaciones más tarde.", "Error comprobar actualizaciones", MessageBoxButtons.OKCancel, MessageBoxIcon.Error)
            Case My.Application.Info.Version.ToString
                MessageBox.Show("¡Apolo está actualizado!" & vbCrLf & "Versión: " & My.Application.Info.Version.ToString, "Comprobar actualizaciones", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            Case Else
                Dim textoMejoras As String
                textoMejoras = "Hay una nueva versión disponible:" & vbCrLf
                textoMejoras += "Versión: " & Actualizar(0) & vbCrLf & "Mejoras: "
                For i = 1 To Actualizar.Length - 1
                    textoMejoras += Actualizar(i)
                Next
                textoMejoras += vbCrLf & "-----------------------" & vbCrLf & "Si decide instalar la nueva actualización se cerrará Apolo, ¿está seguro de que desea actualizar ahora?"
                Dim respuestaActualizacion = MessageBox.Show(textoMejoras, "Comprobar actualizaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If respuestaActualizacion = Windows.Forms.DialogResult.Yes Then
                    Dim rutaArchivo As String
                    If System.Environment.Is64BitOperatingSystem = True Then 'Comprobamos el tipo de sistema operativo
                        rutaArchivo = objetoActualizacion.DescargarActualizacion(True)
                    Else
                        rutaArchivo = objetoActualizacion.DescargarActualizacion(False)
                    End If
                    Process.Start(rutaArchivo)
                    Application.Exit()
                End If
        End Select
    End Sub

#End Region

#Region "Crear proceso con thread"
    'ACtualizamos el estado del proceso
    Private Sub Timer1_Tick_1(sender As Object, e As EventArgs) Handles Timer1.Tick
        barraestado.Value = CInt(TratamientoImagenes.porcentaje(0))
        Estadoactual.Text = TratamientoImagenes.porcentaje(1)
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
        Dim bmp As New Bitmap(PictureBox2.Image)

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
            Case "Marte"
                PictureBox1.Image = objetoTratamiento.EfectoMarte(bmp)
            Case "AntiguiSobreexpu"
                PictureBox1.Image = objetoTratamiento.EfectoAntigSobreex(bmp)
            Case "Marino"
                PictureBox1.Image = objetoTratamiento.EfectoMarino(bmp)
            Case "AumentarRasgos"
                PictureBox1.Image = objetoTratamiento.EfectoAumentarRasgos(bmp)
            Case "DisminuirRasgos"
                PictureBox1.Image = objetoTratamiento.EfectoDisminuirRasgos(bmp)
            Case "ContSombreado1"
                PictureBox1.Image = objetoTratamiento.EfectoContornoSombreado(bmp)
            Case "ContSombreado2"
                PictureBox1.Image = objetoTratamiento.EfectoContornoSombreado2(bmp)
            Case "AumentarLuz"
                PictureBox1.Image = objetoTratamiento.EfectoAumentarLuz(bmp)
            Case "Marco1"
                PictureBox1.Image = objetoTratamiento.marco(bmp, 0)
            Case "Marco2"
                PictureBox1.Image = objetoTratamiento.marco(bmp, 1)
            Case "Marco3"
                PictureBox1.Image = objetoTratamiento.marco(bmp, 2)
            Case "Marco4"
                PictureBox1.Image = objetoTratamiento.marco(bmp, 3)
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
    Dim tiempo As Integer = 5 'Variable que controla el tiempo de actualización

    Sub actualizarHistrograma() 'Función que recibe y dibuja el histograma
        Try
            'Los ponesmos del colores correspondiente
            Chart1.Series("Rojo").Color = Color.Red
            Chart2.Series("Verde").Color = Color.Green
            Chart3.Series("Azul").Color = Color.Blue
            'Borramos el contenido
            Chart1.Series("Rojo").Points.Clear()
            Chart2.Series("Verde").Points.Clear()
            Chart3.Series("Azul").Points.Clear()
            Dim bmpHisto As New Bitmap(PictureBox2.Image, New Size(New Point(100, 100)))
            Dim histoAcumulado = objetoTratamiento.histogramaAcumulado(bmpHisto)
            For i = 0 To UBound(histoAcumulado)
                Chart1.Series("Rojo").Points.AddXY(i + 1, histoAcumulado(i, 0))
                Chart2.Series("Verde").Points.AddXY(i + 1, histoAcumulado(i, 1))
                Chart3.Series("Azul").Points.AddXY(i + 1, histoAcumulado(i, 2))
            Next

        Catch
            tiempo = 0 'Pasamos el tiempo a cero para que no siga descontando y no estre en esta sentencia de control
            MessageBox.Show("Lo sentimos, algo ha ocurrido. Pruebe a deshacer los cambios y desactivar el histograma automático (Herramientas/Histograma automático)", "Apolo thread", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        actualizarHistrograma()
        tiempo = 0 'Para que el contador se pare
        Button1.Text = "Actualizar histograma"
        TabPage1.Text = "Histograma"
        TabPage2.Text = "Registro cambios"
    End Sub 'Botón para actualizar histograma manualmente

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        If HistogramasAutomáticos = True Then 'Variable global que controla si está activado o desactivado
            If tiempo > 1 Then 'Si es mayor que uno vamos mostrando la cuenta atrás en el botón
                tiempo -= 1
                Button1.Text = "Actualizando en (" & tiempo & ")"
                TabPage1.Text = "Actualizando(" & tiempo & ")"
                TabPage2.Text = "Actualizando(" & tiempo & ")"
            ElseIf tiempo = 1 Then 'Cuando llega a uno actualizamos
                TabPage1.Text = "Histograma"
                TabPage2.Text = "Registro de cambios"
                Button1.Text = "Actualizar histograma"
                actualizarHistrograma()
                TabControl1_SelectedIndexChanged(sender, e)
                tiempo = 0 'Pasamos el tiempo a cero para que no siga descontando y no estre en esta sentencia de control
            End If
        End If
    End Sub
#End Region
#Region "Abrir histogramas"
    'Botón de mostrar todos los histográmas
    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        TodosHistogramas.Show()
    End Sub

    Private Sub Chart3_Click_1(sender As Object, e As EventArgs) Handles Chart3.Click
        'Hay que crear la instancia con constructor y el valor del color
        Dim frmHisto As New Histogramas(Color.Blue)
        frmHisto.Show()
    End Sub

    Private Sub Chart2_Click_1(sender As Object, e As EventArgs) Handles Chart2.Click
        'Hay que crear la instancia con constructor y el valor del color
        Dim frmHisto As New Histogramas(Color.Green)
        frmHisto.Show()

    End Sub

    Private Sub Chart1_Click_1(sender As Object, e As EventArgs) Handles Chart1.Click
        'Hay que crear la instancia con constructor y el valor del color
        Dim frmHisto As New Histogramas(Color.Red)
        frmHisto.Show()
    End Sub

    Private Sub Chart1_MouseEnter(sender As Object, e As EventArgs) Handles Chart1.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Chart1_MouseLeave(sender As Object, e As EventArgs) Handles Chart1.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Chart3_MouseEnter(sender As Object, e As EventArgs) Handles Chart3.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Chart3_MouseLeave(sender As Object, e As EventArgs) Handles Chart3.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Chart2_MouseEnter(sender As Object, e As EventArgs) Handles Chart2.MouseEnter
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Chart2_MouseLeave(sender As Object, e As EventArgs) Handles Chart2.MouseLeave
        Me.Cursor = Cursors.Default
    End Sub

#End Region


#Region "Actualizar registro cambios tabcontrol/"


    Sub RefrescarTab()
        Dim ancho As Integer = TabPage2.Width / 3 * 2.5
        For Each c As Control In TabPage2.Controls
            If TypeOf c Is PictureBox Then
                c.Width = ancho
            End If
        Next
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        Try
            If TabControl1.SelectedIndex = 1 Then
                TabPage2.Controls.Clear() 'Borramos todos los controles creados anteriormente
                Dim listaCompletaInfo = objetoTratamiento.ListadoTotalDeInfo
                Dim labelInfo(listaCompletaInfo.Count - 1) As Label
                Dim alto As Integer = 5

                For i = 0 To listaCompletaInfo.Count - 1 'Creamos los labls
                    'Labels
                    labelInfo(i) = New Label
                    TabPage2.Controls.Add(labelInfo(i))
                    labelInfo(i).Text = listaCompletaInfo(i)
                    labelInfo(i).Size = New Size(TabPage2.Width - 5, 12)
                    labelInfo(i).Location = New Size(5, alto)
                    labelInfo(i).Font = New Font("Segoe UI", 7, FontStyle.Bold)
                    alto += 115
                    '-----
                Next

                Dim listaCompletaImagenes = objetoTratamiento.ListadoTotalDeImagenes
                Dim picImagenes(listaCompletaImagenes.Count - 1) As PictureBox
                alto = 20
                Dim ancho As Integer = TabPage2.Width / 3 * 2.5
                For i = 0 To listaCompletaImagenes.Count - 1 'Creamos los picturebox
                    'Labels
                    picImagenes(i) = New PictureBox
                    TabPage2.Controls.Add(picImagenes(i))
                    picImagenes(i).Image = listaCompletaImagenes(i)
                    picImagenes(i).Size = New Size(ancho, 100)
                    picImagenes(i).Location = New Size(5, alto)
                    picImagenes(i).SizeMode = PictureBoxSizeMode.StretchImage
                    picImagenes(i).BorderStyle = BorderStyle.FixedSingle
                    alto += 115
                    '-----
                Next

                '-- Scroll Vertical
                Me.TabPage2.VerticalScroll.Visible = True
                Me.TabPage2.AutoScroll = True


                'Recorremos los picturebox del tabcontrol para crear el evento que gestione todo
                For Each c As Object In TabPage2.Controls
                    If c.GetType Is GetType(PictureBox) Then
                        AddHandler DirectCast(c, PictureBox).MouseEnter, AddressOf conFoco
                        AddHandler DirectCast(c, PictureBox).MouseLeave, AddressOf sinFoco
                        AddHandler DirectCast(c, PictureBox).MouseClick, AddressOf Pulsa
                    End If
                Next
            End If
        Catch
        End Try
        'ACtualizamos datos zoom fijo
        If TabControl1.SelectedIndex = 2 Then
            NumVentana.Value = My.Settings.TamanoPictuZoomfijo
            NumTamanoPuntero.Value = My.Settings.TamanoPunteroZoomFijo
            NumZoom.Value = My.Settings.ValorZoomFijo
            If My.Settings.PunteroZoomfijo Then
                chbPuntero.Checked = True
                Button3.Enabled = True
                NumTamanoPuntero.Enabled = True
            Else
                chbPuntero.Checked = False
                Button3.Enabled = False
                NumTamanoPuntero.Enabled = False
            End If
            Button3.BackColor = My.Settings.ColorPunterZoomFijo
            'Adpatamos tabpage 2 (zoom)
            Label3.Location = New Size((SplitContainer1.Panel2.Width / 2) - (Label3.Width / 2), Label3.Location.Y)
            PictureBox4.Location = New Size((SplitContainer1.Panel2.Width / 2) - (PictureBox4.Width / 2), PictureBox4.Location.Y)
            Panel2.Location = New Size((SplitContainer1.Panel2.Width / 2) - (Panel2.Width / 2), PictureBox4.Location.Y + PictureBox4.Height + 10)
            SplitContainer1.SplitterDistance = Me.Width - (PictureBox4.Width + 50)
        End If
    End Sub

    Private Sub conFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
    End Sub


    Private Sub sinFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Pulsa(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim bmp As New Bitmap(DirectCast(sender, PictureBox).Image)
        Me.Cursor = Cursors.Default
        PictureBox1.Image = objetoTratamiento.ActualizarImagen(bmp) 'La imagen seleccionado la actualizamos
        'Actualizamos el Panel1
        Panel1.AutoScrollMinSize = PictureBox1.Image.Size
        Panel1.AutoScroll = True
        If HistogramasAutomáticos = False Then 'Si no se actualiza automáticamente (está deshabiltado), forzamos la actualización
            TabControl1_SelectedIndexChanged(sender, e)
        End If
    End Sub





#End Region

#Region "Actualizar imagen secundaria/ actualizar hacer y deshacer."
    'Realizamos esto cuando recibimos el evento
    Sub actualizarPicture(ByVal bmp As Bitmap)
        Try
            ToolStripStatusLabel4.Text = "Zoom: x1"
            PictureBox1.Image = bmp
            PictureBox2.Image = bmp
            'ACtualizamos el nombre del menú hacer/rehacer
            Timer2.Enabled = True
            'Con esto actualizamos el histograma
            tiempo = 5 '3 segundos para actualización
            Timer3.Enabled = True
            Panel1.AutoScrollMinSize = PictureBox1.Image.Size
            Panel1.AutoScroll = True
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


    Private Sub PictureBox1_DragDrop1(sender As Object, e As DragEventArgs) Handles PictureBox1.DragDrop
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
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

    Private Sub PictureBox1_DragEnter1(sender As Object, e As DragEventArgs) Handles PictureBox1.DragEnter

        'DataFormats.FileDrop nos devuelve el array de rutas de archivos
        If e.Data.GetDataPresent(DataFormats.Bitmap) Then
            'Los archivos son externos a nuestra aplicación por lo que de indicaremos All ya que dará lo mismo.
            e.Effect = DragDropEffects.All
        End If
    End Sub

#End Region



#Region "Adaptar panel secundario y formuPrincipal"
    Private Sub SplitContainer1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer1.SplitterMoved
        PictureBox2.Width = SplitContainer1.Panel2.Width - 5 'Imagen general
        Chart1.Width = SplitContainer1.Panel2.Width   'Chart-->histogramas
        Chart2.Width = SplitContainer1.Panel2.Width
        Chart3.Width = SplitContainer1.Panel2.Width
        Button1.Width = SplitContainer1.Panel2.Width - 50 'Botón de actualizar histograma
        Button2.Width = SplitContainer1.Panel2.Width - 50 'Botón de actualizar histograma
        'Adaptamos label --> imagen general
        Label1.Location = New Size((SplitContainer1.Panel2.Width / 2) - (Label1.Width / 2), PictureBox2.Location.Y - 20)
        'Adaptamos el tabcontrol
        TabControl1.Size = New Size(SplitContainer1.Panel2.Width, SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + 30))

        'Adpatamos tabpage 2 (zoom)
        Label3.Location = New Size((SplitContainer1.Panel2.Width / 2) - (Label3.Width / 2), Label3.Location.Y)
        PictureBox4.Location = New Size((SplitContainer1.Panel2.Width / 2) - (PictureBox4.Width / 2), PictureBox4.Location.Y)
        Panel2.Location = New Size((SplitContainer1.Panel2.Width / 2) - (Panel2.Width / 2), PictureBox4.Location.Y + PictureBox4.Height + 10)

        RefrescarTab() 'Actualizamos el registro de cambios
    End Sub


    Private Sub Principal_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'Colocamos la imagen secundaria en la parte inferior
        PictureBox2.Location = New Size(PictureBox2.Location.X, SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + 5))
        'Colocamos label imagen general
        Label1.Location = New Size((SplitContainer1.Panel2.Width / 2) - (Label1.Width / 2), PictureBox2.Location.Y - 20)
        ''Colocamos los chart y el botón
        'Chart1.Location = New Size(-7, SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + Chart1.Size.Height + 100))
        'Chart2.Location = New Size(-7, SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + (Chart1.Size.Height * 2) + 100))
        'Chart3.Location = New Size(-7, SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + (Chart1.Size.Height * 3) + 100))
        'Button1.Location = New Size((TabControl1.Width / 2) - (Button1.Width / 2) - 3, SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + 102))
        ''Botón de todos los histogramas
        'Button2.Location = New Size((TabControl1.Width / 2) - (Button2.Width / 2) - 3, SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + 130) - ((Chart1.Size.Height * 3)))

        'Colocamos los chart y el botón
        Chart1.Location = New Size(-7, SplitContainer1.Location.Y - 5)
        Chart2.Location = New Size(-7, SplitContainer1.Location.Y + Chart1.Height - 5)
        Chart3.Location = New Size(-7, SplitContainer1.Location.Y + Chart1.Height + Chart2.Height - 5)
        Button1.Location = New Size((TabControl1.Width / 2) - (Button1.Width / 2) - 3, Chart3.Location.Y + Chart3.Height)
        'Botón de todos los histogramas
        Button2.Location = New Size((TabControl1.Width / 2) - (Button2.Width / 2) - 3, Button1.Location.Y + Button1.Height + 3)


        'Adaptamos el tabcontrol
        TabControl1.Size = New Size(SplitContainer1.Panel2.Width, SplitContainer1.Panel2.Height - (PictureBox2.Size.Height + 30))
        If TabControl1.Height < 500 Then 'Mostramos los scrolls si es demasiado pequeño
            TabPage1.AutoScroll = True
        Else
            TabPage1.AutoScroll = False

        End If

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
        Dim bmp As New Bitmap(Me.PictureBox2.Image)
        objetoTratamiento.guardarcomo(bmp, 4)
    End Sub
    'ABrir imagen desde bing
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        Bing2.Show()
    End Sub
    'ABrir imagen desde facebook
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        AbrirFacebook.Show()
    End Sub
    'Deshacer
    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ListadoImagenesAtras
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox2.Image.Size
            Panel1.AutoScroll = True
            ToolStripStatusLabel4.Text = "Zoom: x" & objetoTratamiento.Zoom
        End If
    End Sub
    'Rehacer
    Private Sub ToolStripButton6_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ListadoImagenesAdelante
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox2.Image.Size
            Panel1.AutoScroll = True
            ToolStripStatusLabel4.Text = "Zoom: x" & objetoTratamiento.Zoom
        End If
    End Sub
    'Refrescar
    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox1.Image.Size
            Panel1.AutoScroll = True
        End If
    End Sub
    'Actualizar
    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        Dim bmp As New Bitmap(Me.PictureBox2.Image)
        Me.PictureBox1.Image = objetoTratamiento.ActualizarImagen(bmp)
        'Actualizamos el Panel1
        Panel1.AutoScrollMinSize = PictureBox1.Image.Size
        Panel1.AutoScroll = True
        ToolStripStatusLabel4.Text = "Zoom: x" & objetoTratamiento.Zoom
    End Sub
    'Imagen original
    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ImagenOriginalGuardada
        End If
    End Sub
    'Histogramas
    Private Sub ToolStripButton18_Click(sender As Object, e As EventArgs) Handles ToolStripButton18.Click
        TodosHistogramas.Show()
    End Sub
    'Blanco y negro
    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        transformacion = "blancoNegro"
        transformar()
    End Sub
    'Escala de grises
    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles ToolStripButton11.Click
        transformacion = "escalaGrises"
        transformar()
    End Sub
    'Detectar contornos
    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        Contornos.Show()
    End Sub
    'Reducir colores
    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        ReducirColores.Show()
    End Sub
    'Operaciones aritméticas
    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        OperacionesAritmeticas.Show()
    End Sub
    'Transformación afín
    Private Sub ToolStripButton16_Click(sender As Object, e As EventArgs) Handles ToolStripButton16.Click
        TAfinPers.Show()
    End Sub
    'Voltear imagen
    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        Voltear.Show()
    End Sub
    'Mascara manual
    Private Sub ToolStripButton19_Click(sender As Object, e As EventArgs) Handles ToolStripButton19.Click
        MascaraManual.Show()
    End Sub
    'Bordes y contornos
    Private Sub ToolStripButton21_Click(sender As Object, e As EventArgs) Handles ToolStripButton21.Click
        BordesYContornos.Show()
    End Sub
    'Sobel total
    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        transformacion = "SobelTotal"
        transformar()
    End Sub
    'Ruido
    Private Sub ToolStripButton22_Click(sender As Object, e As EventArgs) Handles ToolStripButton22.Click
        RuidoDe.Show()
    End Sub
    'Sombra de vidrio
    Private Sub ToolStripButton23_Click(sender As Object, e As EventArgs) Handles ToolStripButton23.Click
        SombraVidrio.Show()
    End Sub
    'Trocear imagen
    Private Sub ToolStripButton24_Click(sender As Object, e As EventArgs) Handles ToolStripButton24.Click
        transformacion = "6partes"
        transformar()
    End Sub

    'Crear anaglifo
    Private Sub ToolStripButton25_Click(sender As Object, e As EventArgs) Handles ToolStripButton25.Click
        Anaglifo.Show()
    End Sub
    'Comparar imágenes
    Private Sub ToolStripButton26_Click(sender As Object, e As EventArgs) Handles ToolStripButton26.Click
        CompararImagenesVecinos.Show()
    End Sub

    'Compartir imagen
    Private Sub ToolStripButton27_Click(sender As Object, e As EventArgs) Handles ToolStripButton27.Click
        Dim form As New Compartir()
        form.Show()
    End Sub
    'Sesión Cloud Privada
    Private Sub ToolStripButton28_Click(sender As Object, e As EventArgs) Handles ToolStripButton28.Click
        AccesoPrivado.Show()
    End Sub
    'Liberar memoria (libera todas las imágenes guardadas para hacer retroceso)
    Private Sub ToolStripButton29_Click(sender As Object, e As EventArgs) Handles ToolStripButton29.Click
        Dim resultado = MessageBox.Show("Esta opción borrará todo el historial de imágenes y no podrá ser recuperado. Además, es posible que durante unos segundos se ralentice el sistema. ¿Está seguro de querer hacerlo?", "Apolo thread", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If resultado = Windows.Forms.DialogResult.Yes Then
            Dim objeto As New TratamientoImagenes
            objeto.LiberarImagenes()
            'forzamos la actualización del tabpage 2 (registro imágenes). Los histogramas no son necesarios puesto que nos quedamos con la imagen actual
            TabControl1_SelectedIndexChanged(sender, e)
            ClearMemory()
        End If
    End Sub

    'Notificar error
    Private Sub ToolStripButton30_Click(sender As Object, e As EventArgs) Handles ToolStripButton30.Click
        NotificarErrorAyuda.Show()
    End Sub
    'Colabora
    Private Sub ToolStripButton31_Click(sender As Object, e As EventArgs) Handles ToolStripButton31.Click
        Colabora.Show()
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
        Dim bmp As New Bitmap(Me.PictureBox2.Image)
        objetoTratamiento.guardarcomo(bmp, 4)
    End Sub

    Private Sub RefrescarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles RefrescarToolStripMenuItem2.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox1.Image.Size
            Panel1.AutoScroll = True
        End If
    End Sub

    Private Sub ActualizarToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem2.Click
        Dim bmp As New Bitmap(Me.PictureBox1.Image)
        Me.PictureBox1.Image = objetoTratamiento.ActualizarImagen(bmp)
        'Actualizamos el Panel1
        Panel1.AutoScrollMinSize = PictureBox1.Image.Size
        Panel1.AutoScroll = True
    End Sub
    'zoom +
    Private Sub ZoomToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem2.Click
        If BackgroundWorker2.IsBusy = False Then
            BackgroundWorker2.RunWorkerAsync()
            objetoTratamiento.Zoom += 0.1
        End If
    End Sub
    'zoom -
    Private Sub ZoomToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem3.Click
        If objetoTratamiento.Zoom - 0.1 > 0 Then
            If BackgroundWorker2.IsBusy = False Then
                BackgroundWorker2.RunWorkerAsync()
                objetoTratamiento.Zoom -= 0.1
            End If
        Else
            MessageBox.Show("Zoom mínimo superado.", "Apolo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    'Deshacer zoom
    Private Sub DeshacerZoomToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeshacerZoomToolStripMenuItem1.Click
        If BackgroundWorker2.IsBusy = False Then
            objetoTratamiento.Zoom = 1
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub
    'Imagen origina
    Private Sub ImagenOriginalToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ImagenOriginalToolStripMenuItem2.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ImagenOriginalGuardada
        End If
    End Sub

    '*******ARCHIVO**********

    Private Sub AbrirImagenToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles AbrirImagenToolStripMenuItem2.Click
        Dim bmp As Bitmap
        bmp = objetoTratamiento.abrirImagen()
        If bmp IsNot Nothing Then
            PictureBox1.Image = bmp
            Panel1.AutoScrollMinSize = PictureBox1.Image.Size
            Panel1.AutoScroll = True
        End If
    End Sub

    Private Sub AbrirRecursoWebToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirRecursoWebToolStripMenuItem.Click
        AbrirRecurso.Show()
    End Sub

    Private Sub BuscarImágenesEnLaWebToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BuscarImágenesEnLaWebToolStripMenuItem1.Click
        Bing2.Show()
    End Sub

    Private Sub ToolStripMenuItem24_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem24.Click
        AbrirBing.Show()
    End Sub

    Private Sub BuscarImágenesEnFacebookToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BuscarImágenesEnFacebookToolStripMenuItem1.Click
        AbrirFacebook.Show()
    End Sub

    Private Sub GuardaComoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardaComoToolStripMenuItem.Click
        Dim bmp As New Bitmap(Me.PictureBox2.Image)
        objetoTratamiento.guardarcomo(bmp, 4)
    End Sub

    Private Sub CrearTapizToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CrearTapizToolStripMenuItem1.Click
        Tapiz.Show()
    End Sub

    Private Sub CompartirImagenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CompartirImagenToolStripMenuItem1.Click
        Dim form As New Compartir()
        form.Show()
    End Sub

    Private Sub AbrirCompiladorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AbrirCompiladorToolStripMenuItem1.Click
        'Abrimos el exe y guardamos la imagen actual
        Dim bmpComp As New Bitmap(PictureBox2.Image)
        bmpComp.Save(System.IO.Directory.GetCurrentDirectory().ToString & "\Compilador\imgforCompilador.png", System.Drawing.Imaging.ImageFormat.Png)
        Dim Process1 As New Process
        Process1.StartInfo.RedirectStandardOutput = True
        Process1.StartInfo.FileName = System.IO.Directory.GetCurrentDirectory().ToString & "\Compilador\FastSharp.exe"
        Process1.StartInfo.UseShellExecute = False
        Process1.StartInfo.CreateNoWindow = True
        Process1.Start()
        'A la espera de que se cierre...
        Process1.WaitForExit()
        'Aquí listar todas las imágenes que se han creado
        ImgCompilador.ShowDialog()
    End Sub
    '************************

    '******EDICIÓN***********

    Private Sub RegistroDeCambiosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RegistroDeCambiosToolStripMenuItem1.Click
        RegistroCambio.Show()
    End Sub

    Private Sub ImagenOriginalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ImagenOriginalToolStripMenuItem1.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ImagenOriginalGuardada
        End If
    End Sub

    Private Sub RehacerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RehacerToolStripMenuItem1.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ListadoImagenesAdelante
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox2.Image.Size
            Panel1.AutoScroll = True
            ToolStripStatusLabel4.Text = "Zoom: x" & objetoTratamiento.Zoom
        End If
    End Sub

    Private Sub DeshacerToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DeshacerToolStripMenuItem1.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            PictureBox1.Image = objetoTratamiento.ListadoImagenesAtras
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox2.Image.Size
            Panel1.AutoScroll = True
            ToolStripStatusLabel4.Text = "Zoom: x" & objetoTratamiento.Zoom
        End If
    End Sub

    Private Sub PropiedadesDeLaImagenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PropiedadesDeLaImagenToolStripMenuItem1.Click
        PropImagen.Show()
    End Sub

    Private Sub PegarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PegarToolStripMenuItem1.Click
        If My.Computer.Clipboard.ContainsImage() Then
            PictureBox1.Image = objetoTratamiento.ActualizarImagen(My.Computer.Clipboard.GetImage(), True)
        End If
    End Sub

    Private Sub CopiarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CopiarToolStripMenuItem1.Click
        My.Computer.Clipboard.SetImage(PictureBox1.Image)
    End Sub

    Private Sub CapturaDePantallaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CapturaDePantallaToolStripMenuItem1.Click
        If BackgroundWorker2.IsBusy = False Then
            Dim bmpCaptura As Bitmap
            bmpCaptura = objetoTratamiento.capturarPantalla(False)
            PictureBox1.Image = bmpCaptura
            refrescar()
        End If
    End Sub

    Private Sub RefrescarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RefrescarToolStripMenuItem1.Click
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox1.Image.Size
            Panel1.AutoScroll = True
        End If
    End Sub

    Private Sub ActualizarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ActualizarToolStripMenuItem1.Click
        Dim bmp As New Bitmap(Me.PictureBox2.Image)
        Me.PictureBox1.Image = objetoTratamiento.ActualizarImagen(bmp)
        'Actualizamos el Panel1
        Panel1.AutoScrollMinSize = PictureBox1.Image.Size
        Panel1.AutoScroll = True
        ToolStripStatusLabel4.Text = "Zoom: x" & objetoTratamiento.Zoom
    End Sub

    Private Sub AjustarAPantallaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AjustarAPantallaToolStripMenuItem1.Click
        Dim bmpAjustado As New Bitmap(PictureBox1.Image, SplitContainer1.Panel1.Width, SplitContainer1.Panel1.Height)
        PictureBox1.Image = bmpAjustado
        objetoTratamiento.ActualizarImagen(bmpAjustado)
        Panel1.AutoScroll = False 'Quitamos los scrolls para que se vea la imagen completa
    End Sub

    Private Sub DeshacerZoomToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles DeshacerZoomToolStripMenuItem2.Click
        If BackgroundWorker2.IsBusy = False Then
            objetoTratamiento.Zoom = 1
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub


    Private Sub EmpezarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EmpezarToolStripMenuItem1.Click
        MessageBox.Show("Pulse la tecla SHIFT y muévase por la imagen para ver la imagen ampliada." & vbCrLf & "Mueva la rueda del ratón para ampliar o disminuir el zoom.", "Zoom interactivo", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub PropiedadesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PropiedadesToolStripMenuItem1.Click
        PropiedadesZoom.Show()
    End Sub

    Private Sub ZoomToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem5.Click
        If objetoTratamiento.Zoom - 0.1 > 0 Then
            If BackgroundWorker2.IsBusy = False Then
                BackgroundWorker2.RunWorkerAsync()
                objetoTratamiento.Zoom -= 0.1
            End If
        Else
            MessageBox.Show("Zoom mínimo superado.", "Apolo", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ZoomToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ZoomToolStripMenuItem4.Click
        If BackgroundWorker2.IsBusy = False Then
            BackgroundWorker2.RunWorkerAsync()
            objetoTratamiento.Zoom += 0.1
        End If

        Dim bmp As New Bitmap(PictureBox1.Image)
    End Sub
    '************************

    '**Operaciones básicas***

    Private Sub BlancoYNegroToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BlancoYNegroToolStripMenuItem1.Click
        transformacion = "blancoNegro"
        transformar()
    End Sub

    Private Sub EscalaDeGrisesToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles EscalaDeGrisesToolStripMenuItem3.Click
        transformacion = "escalaGrises"
        transformar()
    End Sub

    Private Sub RGBToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RGBToolStripMenuItem1.Click
        transformacion = "invertir"
        transformar()
    End Sub

    Private Sub RojoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RojoToolStripMenuItem1.Click
        transformacion = "invertirRojo"
        transformar()
    End Sub

    Private Sub VerdeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VerdeToolStripMenuItem1.Click
        transformacion = "invertirVerde"
        transformar()
    End Sub

    Private Sub AzulToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AzulToolStripMenuItem1.Click
        transformacion = "invertirAzul"
        transformar()
    End Sub

    Private Sub SepiaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SepiaToolStripMenuItem1.Click
        transformacion = "sepia"
        transformar()
    End Sub

    Private Sub FiltroRojoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FiltroRojoToolStripMenuItem1.Click
        transformacion = "FiltroRojo"
        transformar()
    End Sub

    Private Sub FiltroVerdeToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FiltroVerdeToolStripMenuItem1.Click
        transformacion = "FiltroVerde"
        transformar()
    End Sub

    Private Sub FiltroAzulToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FiltroAzulToolStripMenuItem1.Click
        transformacion = "FiltroAzul"
        transformar()
    End Sub

    Private Sub BGRToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BGRToolStripMenuItem1.Click
        transformacion = "RGBtoBGR"
        transformar()
    End Sub

    Private Sub GRBToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GRBToolStripMenuItem1.Click
        transformacion = "RGBtoGRB"
        transformar()
    End Sub

    Private Sub RBGToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RBGToolStripMenuItem1.Click
        transformacion = "RGBtoRBG"
        transformar()
    End Sub

    Private Sub DetalladoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DetalladoToolStripMenuItem.Click
        'Hay que crear la instancia con constructor y el valor del color
        Dim frmHisto As New Histogramas(Color.Red)
        frmHisto.Show()
    End Sub

    Private Sub TodosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TodosToolStripMenuItem.Click
        TodosHistogramas.Show()
    End Sub

    Private Sub RedimensionarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles RedimensionarToolStripMenuItem1.Click
        Redimensionar.Show()
    End Sub
    '************************

    '*Operaciones básicas personalizadas***************

    Private Sub BlancoYNegroToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles BlancoYNegroToolStripMenuItem2.Click
        BlancoYnegro.Show()
    End Sub

    Private Sub EscalaDeGrisesToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles EscalaDeGrisesToolStripMenuItem4.Click
        EscalaDeGrises.Show()
    End Sub

    Private Sub BrilloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrilloToolStripMenuItem.Click
        Brillo.Show()
    End Sub

    Private Sub Contraste1recomendadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Contraste1recomendadoToolStripMenuItem.Click
        Contraste1.Show()
    End Sub

    Private Sub Contraste2ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Contraste2ToolStripMenuItem1.Click
        Contraste2.Show()
    End Sub

    Private Sub CorrecciónDeGammaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CorrecciónDeGammaToolStripMenuItem.Click
        Gamma.Show()
    End Sub

    Private Sub ExposiciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExposiciónToolStripMenuItem.Click
        Exposicion.Show()
    End Sub

    Private Sub ModificarCanalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ModificarCanalesToolStripMenuItem.Click
        Canales.Show()
    End Sub

    Private Sub ReducirColoresToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReducirColoresToolStripMenuItem1.Click
        ReducirColores.Show()
    End Sub

    Private Sub FiltrarColoresToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FiltrarColoresToolStripMenuItem1.Click
        FiltrarColores.Show()
    End Sub

    Private Sub CorregirOjosRojosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CorregirOjosRojosToolStripMenuItem1.Click
        OjosRojos.Show()
    End Sub

    Private Sub MatrizToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MatrizToolStripMenuItem1.Click
        Matriz.Show()
    End Sub

    Private Sub DetectarContornosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DetectarContornosToolStripMenuItem1.Click
        Contornos.Show()
    End Sub
    '**************************************************

    '***********Operaciones********

    Private Sub OperacionesAritméticasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OperacionesAritméticasToolStripMenuItem1.Click
        OperacionesAritmeticas.Show()
    End Sub

    Private Sub OperacionesLógicasToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles OperacionesLógicasToolStripMenuItem2.Click
        OperacionesLogicas.Show()
    End Sub

    Private Sub OperacionesEstadísticasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OperacionesEstadísticasToolStripMenuItem1.Click
        OperacionesEstadisticas.Show()
    End Sub

    Private Sub OperacionesMorfológicasbetaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OperacionesMorfológicasbetaToolStripMenuItem1.Click
        OperadoresMorfologicos.Show()
    End Sub

    Private Sub HorizontalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles HorizontalToolStripMenuItem1.Click
        transformacion = "ReflexionHori"
        transformar()
    End Sub

    Private Sub VerticalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VerticalToolStripMenuItem1.Click
        transformacion = "ReflexionVert"
        transformar()
    End Sub

    Private Sub TraslaciónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TraslaciónToolStripMenuItem.Click
        Traslacion.Show()
    End Sub

    Private Sub VoltearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VoltearToolStripMenuItem.Click
        Voltear.Show()
    End Sub

    Private Sub ManualsesgarImagenToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ManualsesgarImagenToolStripMenuItem1.Click
        Afin.Show()
    End Sub

    Private Sub PersonalizadaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PersonalizadaToolStripMenuItem1.Click
        TAfinPers.Show()
    End Sub

    Private Sub AutomáticoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AutomáticoToolStripMenuItem1.Click
        DensityScilingAuto.Show()
    End Sub

    Private Sub ManualToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ManualToolStripMenuItem1.Click
        DensityScilingManual.Show()
    End Sub
    '*************************

    '******* Máscaras ********
    Private Sub PasoAltoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PasoAltoToolStripMenuItem1.Click
        PasoAlto.Show()
    End Sub

    Private Sub PasoBajoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PasoBajoToolStripMenuItem1.Click
        PasoBajo.Show()
    End Sub

    Private Sub BordesYContornosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BordesYContornosToolStripMenuItem1.Click
        BordesYContornos.Show()
    End Sub

    Private Sub MáscaraManualToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MáscaraManualToolStripMenuItem1.Click
        MascaraManual.Show()
    End Sub

    Private Sub MáscaraManualmásTamañosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MáscaraManualmásTamañosToolStripMenuItem.Click
        MascaraPersonal.Show()
    End Sub

    Private Sub SobelTotalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SobelTotalToolStripMenuItem1.Click
        transformacion = "SobelTotal"
        transformar()
    End Sub
    '***************************

    '***** Efectos *************
    Private Sub DenfoqueDistorsiónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DenfoqueDistorsiónToolStripMenuItem.Click
        Distorsion.Show()
    End Sub

    Private Sub DenfoqueMovimientoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DenfoqueMovimientoToolStripMenuItem.Click
        Desenfocar.Show()
    End Sub

    Private Sub DenfoqueBlurToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DenfoqueBlurToolStripMenuItem.Click
        transformacion = "blur"
        transformar()
    End Sub

    Private Sub PixeladoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PixeladoToolStripMenuItem1.Click
        Pixelar.Show()
    End Sub

    Private Sub CuadrículaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles CuadrículaToolStripMenuItem1.Click
        Cuadricula.Show()
    End Sub

    Private Sub SombraDeVidrioToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SombraDeVidrioToolStripMenuItem1.Click
        SombraVidrio.Show()
    End Sub

    Private Sub TresPartesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TresPartesToolStripMenuItem1.Click
        transformacion = "3partes"
        transformar()
    End Sub

    Private Sub SeisPartesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SeisPartesToolStripMenuItem1.Click
        transformacion = "6partes"
        transformar()
    End Sub

    Private Sub RuidoAleatorioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RuidoAleatorioToolStripMenuItem.Click
        Ruido.Show()
    End Sub

    Private Sub RuidoDesplazadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RuidoDesplazadoToolStripMenuItem.Click
        RuidoDe.Show()
    End Sub

    Private Sub ÓleoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ÓleoToolStripMenuItem1.Click
        Oleo.Show()
    End Sub

    Private Sub EfectoMarteToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EfectoMarteToolStripMenuItem1.Click
        transformacion = "Marte"
        transformar()
    End Sub

    Private Sub EfectoAntiguoSobreexpuestoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EfectoAntiguoSobreexpuestoToolStripMenuItem1.Click
        transformacion = "AntiguiSobreexpu"
        transformar()
    End Sub

    Private Sub EfectoMarinoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EfectoMarinoToolStripMenuItem1.Click
        transformacion = "Marino"
        transformar()
    End Sub

    Private Sub AumentarRasgosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AumentarRasgosToolStripMenuItem1.Click
        transformacion = "AumentarRasgos"
        transformar()
    End Sub

    Private Sub DisminuirRasgosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DisminuirRasgosToolStripMenuItem1.Click
        transformacion = "DisminuirRasgos"
        transformar()
    End Sub

    Private Sub ContenidoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ContenidoToolStripMenuItem1.Click
        transformacion = "ContSombreado1"
        transformar()
    End Sub

    Private Sub DesmedidoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles DesmedidoToolStripMenuItem1.Click
        transformacion = "ContSombreado2"
        transformar()
    End Sub

    Private Sub AumentarLuzToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AumentarLuzToolStripMenuItem.Click
        transformacion = "AumentarLuz"
        transformar()
    End Sub
    Private Sub Marco1ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Marco1ToolStripMenuItem1.Click
        transformacion = "Marco1"
        transformar()
    End Sub

    Private Sub Marco2ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Marco2ToolStripMenuItem1.Click
        transformacion = "Marco2"
        transformar()
    End Sub

    Private Sub Marco3ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Marco3ToolStripMenuItem1.Click
        transformacion = "Marco3"
        transformar()
    End Sub

    Private Sub Marco4ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles Marco4ToolStripMenuItem1.Click
        transformacion = "Marco4"
        transformar()
    End Sub

    Private Sub MarcoDeCineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MarcoDeCineToolStripMenuItem.Click
        Cine.Show()
    End Sub
    '***************************

    '****** Operaciones con dos imágenes ***
    Private Sub OperacionesAritméticasToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles OperacionesAritméticasToolStripMenuItem2.Click
        OperacionesAritmeticasDosImagenes.Show()
    End Sub

    Private Sub OperacionesLógicasToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles OperacionesLógicasToolStripMenuItem3.Click
        OperacionesLogicasDosImagenes.Show()
    End Sub

    Private Sub AnaglifoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AnaglifoToolStripMenuItem1.Click
        Anaglifo.Show()
    End Sub

    Private Sub LocalToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LocalToolStripMenuItem1.Click
        CompararImagenes.Show()
    End Sub

    Private Sub VecinosToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles VecinosToolStripMenuItem1.Click
        CompararImagenesVecinos.Show()
    End Sub
    '***************************************

    '************ CLOUD **********************
    Private Sub CompartirImagenToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles CompartirImagenToolStripMenuItem2.Click
        Dim form As New Compartir()
        form.Show()
    End Sub

    Private Sub CrearCarpetaPrivadaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CrearCarpetaPrivadaToolStripMenuItem.Click
        CrearCarpetaPrivada.Show()
    End Sub

    Private Sub AccesoCarpetaPrivadaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AccesoCarpetaPrivadaToolStripMenuItem1.Click
        AccesoPrivado.Show()
    End Sub

    '****************************************************


    '************ Herramientas *****************
    Private Sub LiberarMemoriaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LiberarMemoriaToolStripMenuItem1.Click
        Dim resultado = MessageBox.Show("Esta opción borrará todo el historial de imágenes y no podrá ser recuperado. Además, es posible que durante unos segundos se ralentice el sistema. ¿Está seguro de querer hacerlo?", "Apolo thread", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If resultado = Windows.Forms.DialogResult.Yes Then
            Dim objeto As New TratamientoImagenes
            objeto.LiberarImagenes()
            'forzamos la actualización del tabpage 2 (registro imágenes). Los histogramas no son necesarios puesto que nos quedamos con la imagen actual
            TabControl1_SelectedIndexChanged(sender, e)
            ClearMemory()
        End If
    End Sub

    Private Sub GrabarSecuenciaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles GrabarSecuenciaToolStripMenuItem1.Click
        GrabarSecuencia.Show()
    End Sub
    '****************************************************


    '************* Ayuda *****************************
    Private Sub AyudaToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem3.Click
        Process.Start(System.IO.Directory.GetCurrentDirectory().ToString & "\HelpApolo.chm")
    End Sub

    Private Sub AyudaEnLaWebToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AyudaEnLaWebToolStripMenuItem1.Click
        System.Diagnostics.Process.Start(System.IO.Directory.GetCurrentDirectory().ToString & "\DocumentacionHTML\DocumentacionApolo.html")
    End Sub

    Private Sub NotificarUnErrorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles NotificarUnErrorToolStripMenuItem1.Click
        NotificarErrorAyuda.Show()
    End Sub

    Private Sub AyúdanosAMejorarToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AyúdanosAMejorarToolStripMenuItem1.Click
        AyudanosAmejorar.Show()
    End Sub

    Private Sub ColaboraConElProyectoToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ColaboraConElProyectoToolStripMenuItem1.Click
        Colabora.Show()
    End Sub

    Private Sub ComprobarActualizacionesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ComprobarActualizacionesToolStripMenuItem1.Click
        If BackgroundWorkerACTUALIZACION.IsBusy = False Then
            Actualizar = Nothing
            BackgroundWorkerACTUALIZACION.RunWorkerAsync()
        End If
    End Sub

    Private Sub AcercaDeApoloToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeApoloToolStripMenuItem.Click
        AboutBox1.Show()
    End Sub
    '*************************************************
#End Region


#Region "Capturar tecla pulsada//Posición puntero en Picturebox//Color picturebox//Zoom interactivo y fijo// Mover los scrollbar del panel al pulsar//Hacer roaming en el picturebox secundarios"
    Dim TeclaActual As String
    'Capturar la tecla pulsada
    Private Sub Principal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        TeclaActual = e.KeyChar.ToString
    End Sub

    'Calculamos la posición del puntero dentro del picturebox
    Dim valorY, valorY2, valorX, valorX2 As Integer

    Private Sub PictureBox1_MouseMove1(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left And (barraestado.Value = 0 Or barraestado.Value = 100) Then
            PictureBox2.Refresh()
            PictureBox1.Refresh()
            'Marcar en el picturebox 2 la zona (roaming)
            '-------------------------------------------------------
            Dim bmp1 As Bitmap
            bmp1 = PictureBox1.Image
            Dim ratioH As Single = bmp1.Width / PictureBox2.Width
            Dim ratioV As Single = bmp1.Height / PictureBox2.Height
            Dim Picture1 As Graphics = PictureBox2.CreateGraphics
            Dim Picture2 As Graphics = PictureBox1.CreateGraphics
            Dim x As Single = e.X / ratioH
            Dim y As Single = e.Y / ratioV
            Picture1.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(x - 10, y - 10), New Size(20, 20)))
            Picture1.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(x - 1, y - 1), New Size(2, 2)))
            Picture2.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(e.X - 10, e.Y - 10), New Size(20, 20)))
            Picture2.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(e.X - 1, e.Y - 1), New Size(2, 2)))
        End If
        'Con esto se mueven los scrollbars al pulsar con el ratón
        '-------------------------------------------------------
        valorY = e.Y - valorY2
        If (Panel1.VerticalScroll.Value + (valorY / 2)) > 0 Then
            Try
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    Panel1.VerticalScroll.Value += valorY / 2
                End If
                valorY2 = e.Y
            Catch
            End Try
        End If

        valorX = e.X - valorX2

        If (Panel1.HorizontalScroll.Value + (valorX / 2)) > 0 Then
            Try
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    Panel1.HorizontalScroll.Value += valorX / 2
                End If
                valorX2 = e.X
            Catch
            End Try
        End If

        '-------------------------------------------------------
        '-------------------------------------------------------

        'Detectar posición del ratón con respecto al Picturebox
        '-------------------------------------------------------
        Dim dpiH, dpiV As Integer 'Puntos por pulgada
        Dim Resolucion As Size 'Resolución de pantalla
        Dim gr As Graphics
        gr = Me.CreateGraphics
        dpiH = gr.DpiX 'Puntos por pulgada
        dpiV = gr.DpiY
        Resolucion = System.Windows.Forms.SystemInformation.PrimaryMonitorSize 'Resolución de pantalla
        Dim ResHeight As Integer = Resolucion.Height
        Dim ResWidth As Integer = Resolucion.Width


        Dim mouseDownLocation As New Point(e.X, e.Y) 'Situación del puntero

        If PíxelesToolStripMenuItem.Checked = True Then 'Si están selecionado píxeles
            ToolStripStatusLabel2.Text = "(" & CInt((mouseDownLocation.X / objetoTratamiento.Zoom)) & "," & CInt((mouseDownLocation.Y / objetoTratamiento.Zoom)) & ") px"
        ElseIf CentímetrosToolStripMenuItem.Checked = True Then 'Centímetros
            ToolStripStatusLabel2.Text = "(" & CInt(FormatNumber((mouseDownLocation.X / dpiH) * 2.54, 2) / objetoTratamiento.Zoom) & "," & CInt(FormatNumber((mouseDownLocation.Y / dpiV) * 2.54, 2) / objetoTratamiento.Zoom) & ") cm"
        ElseIf MilímetrosToolStripMenuItem.Checked = True Then 'Centímetros
            ToolStripStatusLabel2.Text = "(" & CInt(FormatNumber((mouseDownLocation.X / dpiH) * 254, 0) / objetoTratamiento.Zoom) & "," & CInt(FormatNumber((mouseDownLocation.Y / dpiV) * 254, 0) / objetoTratamiento.Zoom) & ") mm"
        ElseIf PulgadasToolStripMenuItem.Checked = True Then 'Pulgadas
            ToolStripStatusLabel2.Text = "(" & CInt(FormatNumber((mouseDownLocation.X / dpiH), 2) / objetoTratamiento.Zoom) & "," & CInt(FormatNumber((mouseDownLocation.Y / dpiV), 2) / objetoTratamiento.Zoom) & ") in"
        End If

        '-------------------------------------------------------
        '-------------------------------------------------------

        'Zoom interactivo-------------------------------------
        '-------------------------------------------------------
        'Muestra el zoom a medida que nos desplazamos por el Picturebox
        If ModifierKeys = Keys.Shift Then
            zoomInteractivo(PictureBox3, e.X, e.Y, My.Settings.ValorZoom, New Size(My.Settings.TamanoVentanaZoom, My.Settings.TamanoVentanaZoom), My.Settings.DistanciaPunteroZoom, My.Settings.PunteroZoom, My.Settings.ColorPunteroZoom, My.Settings.TamanoPunteroZoom, My.Settings.EtiquetaZoom)
        End If

        'Zoom interactivo desde tabpage-------------------------------------
        '-------------------------------------------------------
        If TabControl1.SelectedIndex = 2 Then
            zoomFijo(PictureBox4, e.X, e.Y, My.Settings.ValorZoomFijo, New Size(My.Settings.TamanoPictuZoomfijo, My.Settings.TamanoPictuZoomfijo), My.Settings.PunteroZoomfijo, My.Settings.ColorPunterZoomFijo, My.Settings.TamanoPunteroZoomFijo)
        End If
    End Sub

    Private Sub PictureBox3_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox3.MouseMove
        'Si el cursor está encima del picturebox2, calcula dónde tiene que coger el valor del Picturebox2
        If ModifierKeys = Keys.Shift Then
            zoomInteractivo(PictureBox3, PictureBox3.Location.X + e.X + Panel1.HorizontalScroll.Value, PictureBox3.Location.Y + e.Y + Panel1.VerticalScroll.Value, My.Settings.ValorZoom, New Size(My.Settings.TamanoVentanaZoom, My.Settings.TamanoVentanaZoom), My.Settings.DistanciaPunteroZoom, My.Settings.PunteroZoom, My.Settings.ColorPunteroZoom, My.Settings.TamanoPunteroZoom, My.Settings.EtiquetaZoom)
        End If
    End Sub
    Dim valzoom As Single = 2

    Private Sub Principal_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        PictureBox3.Visible = False
        Label2.Visible = False
        PictureBox1.Refresh()
        PictureBox3.Refresh()
        TeclaActual = ""
    End Sub
    'PicSecundario: Picturebox donde se irá mostrando el zoom interactivo
    'X: Coordenada X del puntero con respecto al Picturebox1
    'Y: Coordenada Y del puntero con respecto al Picturebox1
    'ValorZoom: Aumento con respecto al picturebox1
    'ValorPicturebox: Valor del lado (ancho/alto) del Picturebox2 
    'Puntero (opcional): Indica se se va a mostrar un puntero en la posición actual 
    'ColorPuntero(opcional): Color del puntero .
    'TamanoPuntero(opcional): tamaño del lado del puntero
    'EtiquetaZoom(opcional): Indica si se va a mostrar un label con el zoom actual
    Sub zoomInteractivo(ByVal PicSecundario As PictureBox, ByVal x As Integer, ByVal y As Integer, ByVal valorZoom As Decimal, ByVal valorPicturebox As Size, Optional DistanciaPuntero As Integer = 0, Optional ByVal puntero As Boolean = False, Optional colorPuntero As Color = Nothing, Optional tamanoPuntero As Integer = 1, Optional etiquetaZoom As Boolean = False)


        Dim xResta, yResta As Single
        PicSecundario.Size = valorPicturebox
        valorZoom = Decimal.Round(valorZoom, 2)
        xResta = CInt((PicSecundario.Width / 2) / valorZoom)
        yResta = CInt((PicSecundario.Height / 2) / valorZoom)

        Dim bmpAux As New Bitmap(PictureBox1.Image)


        If x > 0 And y > 0 Then
            PicSecundario.Visible = True

            'Solucionamos problema con esquinas
            If x > bmpAux.Width - xResta Then
                x = bmpAux.Width - xResta
            End If
            If y > bmpAux.Height - yResta Then
                y = bmpAux.Height - yResta
            End If
            If x - xResta < 0 Then
                x = xResta
            End If

            If y - yResta < 0 Then
                y = yResta
            End If

            'Creamos el bitmap con el tamaño elegido
            Dim bmp As Bitmap = bmpAux.Clone(New Rectangle(New Point(x - xResta, y - yResta), New Size(xResta * 2, yResta * 2)), Imaging.PixelFormat.DontCare)
            Dim bmpSalida As New Bitmap(bmp, PicSecundario.Width, PicSecundario.Height)
            PicSecundario.Image = bmpSalida


            'Situamos el Picturebox 2
            Dim localizacion As Point
            localizacion.X = x + DistanciaPuntero
            localizacion.Y = y + DistanciaPuntero

            If x + PicSecundario.Width > PictureBox1.Width Then
                localizacion.X = x - PicSecundario.Width
            End If
            If y + PicSecundario.Height > PictureBox1.Height Then
                localizacion.Y = y - PicSecundario.Height
            End If

            If Panel1.HorizontalScroll.Value > 0 Then
                localizacion.X -= Panel1.HorizontalScroll.Value + DistanciaPuntero
            End If
            If Panel1.VerticalScroll.Value > 0 Then
                localizacion.Y -= Panel1.VerticalScroll.Value
            End If
            PicSecundario.Location = localizacion


            'Con esto forzamos la recolección de basura y destruimos el bitmap
            'El uso no es aconsejable pero imprescindible en este caso
            GC.Collect()
            GC.WaitForPendingFinalizers()
            PictureBox1.Refresh()
            PicSecundario.Refresh()

            'Pintamos el puntero
            If puntero = True Then
                'Si el puntero no tiene color lo ponemos rojo
                If colorPuntero = Nothing Then colorPuntero = Color.Red
                'Calculamos el lado del cuadrado
                Dim lado As Integer = tamanoPuntero * 2
                Dim Picture1 As Graphics = PictureBox1.CreateGraphics
                Picture1.DrawRectangle(New Pen(colorPuntero, 1), New Rectangle(New Point(x - tamanoPuntero, y - tamanoPuntero), New Size(lado, lado)))
                Dim Picture2 As Graphics = PicSecundario.CreateGraphics
                Picture2.DrawRectangle(New Pen(colorPuntero, 1), New Rectangle(New Point(PicSecundario.Width / 2 - tamanoPuntero, PicSecundario.Height / 2 - tamanoPuntero), New Size(lado, lado)))
            End If

            'Si mostramos el label con el zoom
            If etiquetaZoom = True Then
                Label2.Visible = True
                Label2.Text = "x" & valorZoom
                Label2.Location = New Size(PicSecundario.Location.X + PicSecundario.Width / 2 - 10, PicSecundario.Location.Y - 20)
            End If
        End If


    End Sub
    Sub zoomFijo(ByVal PicSecundario As PictureBox, ByVal x As Integer, ByVal y As Integer, ByVal valorZoom As Decimal, ByVal valorPicturebox As Size, Optional ByVal puntero As Boolean = False, Optional colorPuntero As Color = Nothing, Optional tamanoPuntero As Integer = 1)
        Try
            Dim xResta, yResta As Single
            PicSecundario.Size = valorPicturebox
            valorZoom = Decimal.Round(valorZoom, 2)
            xResta = CInt((PicSecundario.Width / 2) / valorZoom)
            yResta = CInt((PicSecundario.Height / 2) / valorZoom)

            Dim bmpAux As New Bitmap(PictureBox1.Image)


            If x > 0 And y > 0 Then
                PicSecundario.Visible = True

                'Solucionamos problema con esquinas
                If x > bmpAux.Width - xResta Then
                    x = bmpAux.Width - xResta
                End If
                If y > bmpAux.Height - yResta Then
                    y = bmpAux.Height - yResta
                End If
                If x - xResta < 0 Then
                    x = xResta
                End If

                If y - yResta < 0 Then
                    y = yResta
                End If

                'Creamos el bitmap con el tamaño elegido
                Dim bmp As Bitmap = bmpAux.Clone(New Rectangle(New Point(x - xResta, y - yResta), New Size(xResta * 2, yResta * 2)), Imaging.PixelFormat.DontCare)
                Dim bmpSalida As New Bitmap(bmp, PicSecundario.Width, PicSecundario.Height)
                PicSecundario.Image = bmpSalida


                'Con esto forzamos la recolección de basura y destruimos el bitmap
                'El uso no es aconsejable pero imprescindible en este caso
                GC.Collect()
                GC.WaitForPendingFinalizers()
                PictureBox1.Refresh()
                PicSecundario.Refresh()

                'Pintamos el puntero
                If puntero = True Then
                    'Si el puntero no tiene color lo ponemos rojo
                    If colorPuntero = Nothing Then colorPuntero = Color.Red
                    'Calculamos el lado del cuadrado
                    Dim lado As Integer = tamanoPuntero * 2
                    Dim Picture1 As Graphics = PictureBox1.CreateGraphics
                    Picture1.DrawRectangle(New Pen(colorPuntero, 1), New Rectangle(New Point(x - tamanoPuntero, y - tamanoPuntero), New Size(lado, lado)))
                    Dim Picture2 As Graphics = PicSecundario.CreateGraphics
                    Picture2.DrawRectangle(New Pen(colorPuntero, 1), New Rectangle(New Point(PicSecundario.Width / 2 - tamanoPuntero, PicSecundario.Height / 2 - tamanoPuntero), New Size(lado, lado)))
                End If

                'Si mostramos el label con el zoom
                Label3.Visible = True
                Label3.Text = "Zoom x" & valorZoom
            End If
        Catch
        End Try

    End Sub


    Private Sub PictureBox1_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseUp
        PictureBox2.Refresh()
        PictureBox1.Refresh()
    End Sub

    '-------------------------------------
    'Extraemos el color y pintamos recuadro (roaming)
    Private Sub PictureBox1_MouseClick1(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseClick
        If ModifierKeys = Keys.Control Then 'Si pulsa control al hacer clic
            Dim bmp As Bitmap
            bmp = PictureBox1.Image
            Dim rojo, verde, azul, alfa As Byte
            Try
                'Obetentemos color
                rojo = bmp.GetPixel(e.X, e.Y).R
                verde = bmp.GetPixel(e.X, e.Y).G
                azul = bmp.GetPixel(e.X, e.Y).B
                alfa = bmp.GetPixel(e.X, e.Y).A
                'Creamos un bitmap para ponerlo como imagen (con el color obtenido)
                Dim bmpAux As New Bitmap(16, 16)
                For i = 0 To 15
                    For j = 0 To 15
                        bmpAux.SetPixel(i, j, Color.FromArgb(alfa, rojo, verde, azul))
                    Next
                Next
                'Asignamos la imagen
                ToolStripStatusImagen.Image = bmpAux
                'Escribimos los valores
                ToolStripStatusColor.Text = bmp.GetPixel(e.X, e.Y).ToString()
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left And (barraestado.Value = 0 Or barraestado.Value = 100) Then
            'Marcar en el picturebox 2 la zona (roaming)
            '-------------------------------------------------------
            Dim bmp1 As Bitmap
            bmp1 = PictureBox1.Image
            Dim ratioH As Single = bmp1.Width / PictureBox2.Width
            Dim ratioV As Single = bmp1.Height / PictureBox2.Height
            Dim Picture1 As Graphics = PictureBox2.CreateGraphics
            Dim Picture2 As Graphics = PictureBox1.CreateGraphics
            Dim x As Single = e.X / ratioH
            Dim y As Single = e.Y / ratioV
            Picture1.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(x - 10, y - 10), New Size(20, 20)))
            Picture1.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(x - 1, y - 1), New Size(2, 2)))
            Picture2.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(e.X - 10, e.Y - 10), New Size(20, 20)))
            Picture2.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(e.X - 1, e.Y - 1), New Size(2, 2)))
        End If
    End Sub

#Region "Roaming desde imagen secundaria"

    Dim valorYY, valorYY2 As Integer

    Private Sub PictureBox2_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PictureBox1.Refresh()
            PictureBox2.Refresh()
            Dim bmp1 As New Bitmap(PictureBox1.Image)
            Dim ratioH As Single = bmp1.Width / PictureBox2.Width
            Dim ratioV As Single = bmp1.Height / PictureBox2.Height
            Dim Picture1 As Graphics = PictureBox1.CreateGraphics
            Dim Picture2 As Graphics = PictureBox2.CreateGraphics
            Dim x As Single = e.X * ratioH
            Dim y As Single = e.Y * ratioV
            Picture1.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(x - 10, y - 10), New Size(20, 20)))
            Picture1.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(x - 1, y - 1), New Size(2, 2)))
            Picture2.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(e.X - 10, e.Y - 10), New Size(20, 20)))
            Picture2.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(e.X - 1, e.Y - 1), New Size(2, 2)))
            Try
                Panel1.HorizontalScroll.Value = x - (Panel1.Width / 2) - 10
            Catch
                Try
                    Panel1.HorizontalScroll.Value = x - 10
                Catch
                    Panel1.HorizontalScroll.Value = 0
                End Try
            End Try

            Try
                Panel1.VerticalScroll.Value = y - (Panel1.Height / 2) - 10
            Catch
                Try
                    Panel1.VerticalScroll.Value = y - 10
                Catch
                    Panel1.VerticalScroll.Value = 0
                End Try
            End Try
        End If
    End Sub
    Private Sub PictureBox2_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            PictureBox1.Refresh()
            PictureBox2.Refresh()
            Dim bmp1 As New Bitmap(PictureBox1.Image)
            Dim ratioH As Single = bmp1.Width / PictureBox2.Width
            Dim ratioV As Single = bmp1.Height / PictureBox2.Height
            Dim Picture1 As Graphics = PictureBox1.CreateGraphics
            Dim Picture2 As Graphics = PictureBox2.CreateGraphics
            Dim x As Single = e.X * ratioH
            Dim y As Single = e.Y * ratioV
            Picture1.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(x - 10, y - 10), New Size(20, 20)))
            Picture1.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(x - 1, y - 1), New Size(2, 2)))
            Picture2.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(e.X - 10, e.Y - 10), New Size(20, 20)))
            Picture2.DrawRectangle(New Pen(Brushes.Red, 1), New Rectangle(New Point(e.X - 1, e.Y - 1), New Size(2, 2)))
            Try
                Panel1.HorizontalScroll.Value = x - (Panel1.Width / 2) - 10
            Catch
                Try
                    Panel1.HorizontalScroll.Value = x - 10
                Catch
                    Panel1.HorizontalScroll.Value = 0
                End Try
            End Try

            Try
                Panel1.VerticalScroll.Value = y - (Panel1.Height / 2) - 10
            Catch
                Try
                    Panel1.VerticalScroll.Value = y - 10
                Catch
                    Panel1.VerticalScroll.Value = 0
                End Try
            End Try
        End If
    End Sub
    Private Sub PictureBox2_MouseUp(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseUp
        PictureBox1.Refresh()
        PictureBox2.Refresh()
    End Sub
#End Region

    Sub quitarCheck()
        PulgadasToolStripMenuItem.Checked = False
        MilímetrosToolStripMenuItem.Checked = False
        PíxelesToolStripMenuItem.Checked = False
        CentímetrosToolStripMenuItem.Checked = False
    End Sub

    Private Sub PulgadasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PulgadasToolStripMenuItem.Click
        quitarCheck()
        PulgadasToolStripMenuItem.Checked = True
    End Sub

    Private Sub PíxelesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PíxelesToolStripMenuItem.Click
        quitarCheck()
        PíxelesToolStripMenuItem.Checked = True
    End Sub

    Private Sub CentímetrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CentímetrosToolStripMenuItem.Click
        quitarCheck()
        CentímetrosToolStripMenuItem.Checked = True
    End Sub

    Private Sub MilímetrosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MilímetrosToolStripMenuItem.Click
        quitarCheck()
        MilímetrosToolStripMenuItem.Checked = True
    End Sub

#End Region

#Region "Zoom + -//Eliminar zoom/Ajustar a pantalla//scrollvertical/Zoom interactivo y fijo"
    Private Sub refrescar()
        If BackgroundWorker1.IsBusy = False Then 'Si el hilo no está en uso
            'Actualizamos el Panel1
            Panel1.AutoScrollMinSize = PictureBox1.Image.Size
            Panel1.AutoScroll = True
        End If
    End Sub
    Private Sub Principal_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        'Hacer zoom
        If ModifierKeys = Keys.Control Then 'Si pulsa control al dar a la rueda
            If (objetoTratamiento.Zoom + (e.Delta / 1000)) - 0.1 > 0 Then
                If BackgroundWorker2.IsBusy = False Then
                    BackgroundWorker2.RunWorkerAsync()
                    objetoTratamiento.Zoom += (e.Delta / 1000)
                End If
            Else
                MessageBox.Show("Zoom mínimo superado.", "Apolo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
        'Mover el scroll vertical
        If ModifierKeys = Nothing And TeclaActual = "" Then 'Si no estamos haciendo ninguna acción
            Try
                Dim valorMovimiento As Integer
                valorMovimiento = 50
                If e.Delta > 0 Then
                    If Panel1.VerticalScroll.Value > valorMovimiento Then
                        Panel1.VerticalScroll.Value -= valorMovimiento
                    Else
                        Panel1.VerticalScroll.Value = 0
                    End If
                Else
                    Panel1.VerticalScroll.Value += valorMovimiento
                End If
            Catch
            End Try
        End If
        'Aumenta el zoom interactivo con la rueda del ratón
        If ModifierKeys = Keys.Shift Then 'Si pulsa control al dar a la rueda
            If e.Delta > 0 And My.Settings.ValorZoom <= 5 Then
                My.Settings.ValorZoom += 0.2
                Dim tamañoBarra As Integer = 0
                If ToolStrip1.Visible = True Then tamañoBarra = ToolStrip1.Height
                zoomInteractivo(PictureBox3, e.X - 2 + Panel1.HorizontalScroll.Value, e.Y - (MenuStrip1.Height + tamañoBarra + 2) + Panel1.VerticalScroll.Value, My.Settings.ValorZoom, New Size(My.Settings.TamanoVentanaZoom, My.Settings.TamanoVentanaZoom), My.Settings.DistanciaPunteroZoom, My.Settings.PunteroZoom, My.Settings.ColorPunteroZoom, My.Settings.TamanoPunteroZoom, My.Settings.EtiquetaZoom)
            ElseIf My.Settings.ValorZoom > 0.4 Then 'No puede ser menor
                My.Settings.ValorZoom -= 0.2
                Dim tamañoBarra As Integer = 0
                If ToolStrip1.Visible = True Then tamañoBarra = ToolStrip1.Height
                zoomInteractivo(PictureBox3, e.X - 2 + Panel1.HorizontalScroll.Value, e.Y - (MenuStrip1.Height + tamañoBarra + 2) + Panel1.VerticalScroll.Value, My.Settings.ValorZoom, New Size(My.Settings.TamanoVentanaZoom, My.Settings.TamanoVentanaZoom), My.Settings.DistanciaPunteroZoom, My.Settings.PunteroZoom, My.Settings.ColorPunteroZoom, My.Settings.TamanoPunteroZoom, My.Settings.EtiquetaZoom)
            End If
        End If
        'Aumenta el zoom interactivo con la rueda del ratón en el zoom fijo (del tabpage 2)
        If TabControl1.SelectedIndex = 2 And TeclaActual = "z" Then 'Si está seleccionado el tabpage del zoom y pulsado Z
            If e.Delta > 0 And My.Settings.ValorZoomFijo <= 5 Then
                My.Settings.ValorZoomFijo += 0.2
                NumZoom.Value = My.Settings.ValorZoomFijo 'ACtualizamosd el label
                Dim tamañoBarra As Integer = 0
                If ToolStrip1.Visible = True Then tamañoBarra = ToolStrip1.Height
                zoomFijo(PictureBox4, e.X - 2 + Panel1.HorizontalScroll.Value, e.Y - (MenuStrip1.Height + tamañoBarra + 2) + Panel1.VerticalScroll.Value, My.Settings.ValorZoomFijo, New Size(My.Settings.TamanoPictuZoomfijo, My.Settings.TamanoPictuZoomfijo), My.Settings.PunteroZoomfijo, My.Settings.ColorPunterZoomFijo, My.Settings.TamanoPunteroZoomFijo)
            ElseIf My.Settings.ValorZoomFijo > 1 Then 'No puede ser menor
                My.Settings.ValorZoomFijo -= 0.2
                Dim tamañoBarra As Integer = 0
                If ToolStrip1.Visible = True Then tamañoBarra = ToolStrip1.Height
                NumZoom.Value = My.Settings.ValorZoomFijo
                zoomFijo(PictureBox4, e.X - 2 + Panel1.HorizontalScroll.Value, e.Y - (MenuStrip1.Height + tamañoBarra + 2) + Panel1.VerticalScroll.Value, My.Settings.ValorZoomFijo, New Size(My.Settings.TamanoPictuZoomfijo, My.Settings.TamanoPictuZoomfijo), My.Settings.PunteroZoomfijo, My.Settings.ColorPunterZoomFijo, My.Settings.TamanoPunteroZoomFijo)
            End If
        End If
    End Sub


   
    Private Sub BackgroundWorker2_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Dim bmp As New Bitmap(PictureBox2.Image)
        Dim bmp2 As New Bitmap(bmp, bmp.Width * objetoTratamiento.Zoom, bmp.Height * objetoTratamiento.Zoom)
        PictureBox1.Image = bmp2
        ToolStripStatusLabel4.Text = "Zoom: x" & objetoTratamiento.Zoom
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        refrescar()
    End Sub
#End Region



#Region "Modificar cambios zoom fijo.. Tabpage 2"
    Private Sub chbPuntero_CheckedChanged(sender As Object, e As EventArgs) Handles chbPuntero.CheckedChanged
        If chbPuntero.Checked = True Then
            Button3.Enabled = True
            NumTamanoPuntero.Enabled = True
        Else
            Button3.Enabled = False
            NumTamanoPuntero.Enabled = False
        End If
    End Sub

    Dim dcolor As New ColorDialog
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        dcolor.ShowDialog()
        Button3.BackColor = dcolor.Color
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If chbPuntero.Checked = True Then
            My.Settings.PunteroZoomfijo = True
            Button3.Enabled = True
            NumTamanoPuntero.Enabled = True
        Else
            My.Settings.PunteroZoomfijo = False
            Button3.Enabled = False
            NumTamanoPuntero.Enabled = False
        End If
        My.Settings.TamanoPictuZoomfijo = NumVentana.Value
        My.Settings.ValorZoomFijo = NumZoom.Value
        My.Settings.TamanoPunteroZoomFijo = NumTamanoPuntero.Value
        My.Settings.ColorPunterZoomFijo = Button3.BackColor
        My.Settings.Save()

        PictureBox4.Size = New Size(My.Settings.TamanoPictuZoomfijo, My.Settings.TamanoPictuZoomfijo)
        Label3.Text = "Zoom x" & My.Settings.ValorZoomFijo

        'Adpatamos tabpage 2 (zoom)
        Label3.Location = New Size((SplitContainer1.Panel2.Width / 2) - (Label3.Width / 2), Label3.Location.Y)
        PictureBox4.Location = New Size((SplitContainer1.Panel2.Width / 2) - (PictureBox4.Width / 2), PictureBox4.Location.Y)
        Panel2.Location = New Size((SplitContainer1.Panel2.Width / 2) - (Panel2.Width / 2), PictureBox4.Location.Y + PictureBox4.Height + 10)
        SplitContainer1.SplitterDistance = Me.Width - (PictureBox4.Width + 50)

    End Sub
#End Region
 
  

  
 

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class
