Imports ClaseImagenes.Apolo
Public Class Compartir
    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim objetoConexion As Conexion 'Variable de la clase colección
    Dim listaImagenes As ArrayList 'Contiene todas las imágenes públicas (los nombres)
    Dim nombreImagen As String 'Contiene el nombre de la imagen seleccionada
    Dim infoImagen As String 'Variable con la información recuperada del servidor 
    Dim imagenACtual As Integer = 0 'Variable que informa sobre qué 10 imágenes hay que mostrar
    Dim valoracionImagen(1) As String 'Variable con valoración de usuario y número de votos
    Dim directorioActual As String 'Variable con el nombre actual (para sesiones privadas)
    Dim directorioConstructor As String 'Variable con string recibido en el constructor

    Public Sub New(Optional ByVal directorio As String = "") 'Constructor
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        If directorio <> "" Then
            ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
            directorioConstructor = directorio
            directorioActual = "DatosUsuarios/" & directorio & "/"
            btnBorrar.Enabled = True
            btnCompartir.Enabled = True
            lblEliminar.Enabled = True
            lblEliminar.Visible = True
        End If
    End Sub

    Private Sub dentroP(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
    End Sub
    Private Sub fueraP(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub ClicP(ByVal sender As Object, ByVal e As System.EventArgs)
        If DirectCast(sender, PictureBox).Image IsNot Nothing Then
            Principal.PictureBox1.Image = objetoTratamiento.OriginalApoloCloud(DirectCast(sender, PictureBox).Image)
        End If
    End Sub
 

    Private Sub Compartir_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Location = New Size(50, 50)
        Me.Size = New Size(200, 5)
        picSubir.Image = Principal.PictureBox1.Image
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

        For Each c As Object In Me.Controls
            If c.GetType Is GetType(PictureBox) Then
                AddHandler DirectCast(c, PictureBox).MouseEnter, AddressOf dentroP
                AddHandler DirectCast(c, PictureBox).MouseLeave, AddressOf fueraP
                AddHandler DirectCast(c, PictureBox).MouseClick, AddressOf ClicP

            End If
        Next

        For Each c As Object In Panel2.Controls
            If c.GetType Is GetType(PictureBox) Then
                AddHandler DirectCast(c, PictureBox).MouseEnter, AddressOf dentroEs
                AddHandler DirectCast(c, PictureBox).MouseLeave, AddressOf fueraEs
                AddHandler DirectCast(c, PictureBox).MouseClick, AddressOf ClicEs

            End If
        Next

        If BackgroundWorker1.IsBusy = False Then
            Me.Text = "Estableciendo conexión con el servidor remoto..."
            BackgroundWorker1.RunWorkerAsync() 'Comprobamos conexión
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        objetoConexion = New Conexion("ftp://93.188.160.15/" & directorioActual, "u398464172", "luis000luis000")
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.Text = "Apolo Cloud"
        If directorioActual <> "" Then
            Me.Text += " [Sesión privada - " & directorioConstructor & "]"
        End If
        Me.Enabled = True 'Lo activamos
        Me.Size = New Size(899, 473)

        'Mostramos las primeras 10 imágenes
        If BackgroundWorker5.IsBusy = False Then
            imagenACtual = 0
            btnInicio.Text = "Cargando imágenes"
            picTodas.Image = My.Resources.cargandogris
            BackgroundWorker5.RunWorkerAsync()
        End If
    End Sub


    'Compartir imagen
    Private Sub btnSubir_Click(sender As Object, e As EventArgs) Handles btnSubir.Click
        If BackgroundWorker2.IsBusy = False And txtnombre.Text <> "" And txtdescrip.Text <> "" And BackgroundWorker8.IsBusy = False Then
            btnSubir.Text = "Compartiendo..."
            picCargando.Image = My.Resources.cargandogris
            BackgroundWorker2.RunWorkerAsync()
        ElseIf txtnombre.Text = "" Or txtdescrip.Text = "" Then
            MessageBox.Show("Por favor, rellene los campos nombre y descripción para poder compartir la imagen.", "Apolo Cloud", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        objetoConexion.SubirFotoPublica(picSubir.Image, txtnombre.Text, txtdescrip.Text)
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        picCargando.Image = Nothing
        txtdescrip.Text = ""
        txtnombre.Text = ""
        btnSubir.Text = "Compartir imagen"
        If BackgroundWorker4.IsBusy = False Then 'Recargamos el listbox
            btnRecargar.Text = "Recargando"
            picRecargar.Image = My.Resources.cargandogris
            BackgroundWorker4.RunWorkerAsync()
        End If
    End Sub

    'Ver imagen desde listbox
    Private Sub btnVerImagen_Click_1(sender As Object, e As EventArgs) Handles btnVerImagen.Click
        If BackgroundWorker3.IsBusy = False And ListBox1.SelectedIndex >= 0 Then
            picCargandoImagen.Image = My.Resources.cargandogris
            btnVerImagen.Text = "Visualizando imagen"
            nombreImagen = ListBox1.SelectedItem.ToString.Replace(".jpg", "")
            BackgroundWorker3.RunWorkerAsync()
        End If
    End Sub
   
    Private Sub BackgroundWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork
        picImagenVisualizada.Image = objetoConexion.DescargarFotosPublicas(nombreImagen)
        infoImagen = objetoConexion.DescargarInfoFotosPublicas(nombreImagen)
        valoracionImagen = objetoConexion.DescargaValoracionFotoPublica(nombreImagen)
    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        btnVerImagen.Text = "Ver imagen"
        picCargandoImagen.Image = Nothing
        lblNombreImagen.Text = objetoConexion.NombreImagenActual
        lblinfo.Text = infoImagen
        If valoracionImagen(0).ToString <> "NaN" Then
            lblval.Text = "Valoración: " & FormatNumber(valoracionImagen(0), 1)
        Else
            lblval.Text = "Valoración: " & "Sin puntuación"
        End If
        lblvot.Text = "Número votos: " & valoracionImagen(1)
        picStar1.Image = My.Resources.starGris : picStar2.Image = My.Resources.starGris : picStar3.Image = My.Resources.starGris : picStar4.Image = My.Resources.starGris : picStar5.Image = My.Resources.starGris
        Select Case valoracionImagen(0)
            Case Is <= 1.5
                picStar1.Image = My.Resources.star
                Exit Select
            Case Is <= 2.5
                picStar1.Image = My.Resources.star : picStar2.Image = My.Resources.star
                Exit Select
            Case Is <= 3.5
                picStar1.Image = My.Resources.star : picStar2.Image = My.Resources.star : picStar3.Image = My.Resources.star
                Exit Select
            Case Is <= 4.99
                picStar1.Image = My.Resources.star : picStar2.Image = My.Resources.star : picStar3.Image = My.Resources.star : picStar4.Image = My.Resources.star
                Exit Select
            Case Is <= 5
                picStar1.Image = My.Resources.star : picStar2.Image = My.Resources.star : picStar3.Image = My.Resources.star : picStar4.Image = My.Resources.star : picStar5.Image = My.Resources.star
                Exit Select
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRecargar.Click
        If BackgroundWorker4.IsBusy = False And BackgroundWorker8.IsBusy = False Then
            btnRecargar.Text = "Recargando"
            picRecargar.Image = My.Resources.cargandogris
            BackgroundWorker4.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker4_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker4.DoWork
        listaImagenes = objetoConexion.listarImagenesPublicas
    End Sub


    Private Sub BackgroundWorker4_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker4.RunWorkerCompleted
        'Incluimos en el listbox todas las imágenes
        ListBox1.Items.Clear()
        If listaImagenes.Count > 0 Then 'Si hay alguna imagen
            For Each item In listaImagenes
                ListBox1.Items.Add(item)
            Next
            btnRecargar.Text = "Recargar"
            picRecargar.Image = Nothing
            'Si no hay ninguna imagen en el picture al lado del listbox
            '(esto sirve para que la primera vez carguemos una imagen)
            If BackgroundWorker3.IsBusy = False And picImagenVisualizada.Image Is Nothing Then
                picCargandoImagen.Image = My.Resources.cargandogris
                btnVerImagen.Text = "Visualizando imagen"
                Dim nombre As ArrayList
                nombre = objetoConexion.listarImagenesPublicas
                'Cargamos la primera imagen de la lista
                nombreImagen = nombre(0).ToString.Replace(".jpg", "")
                BackgroundWorker3.RunWorkerAsync()
            End If
        Else
            btnRecargar.Text = "Recargar"
            picRecargar.Image = Nothing
        End If
    End Sub

    Private Sub btnTodasImg_Click(sender As Object, e As EventArgs) Handles btnTodasImg.Click
        If BackgroundWorker5.IsBusy = False And BackgroundWorker8.IsBusy = False Then
            imagenACtual += 10
            btnTodasImg.Text = "Cargando imágenes"
            picTodas.Image = My.Resources.cargandogris
            BackgroundWorker5.RunWorkerAsync()
        End If
    End Sub

    Private Sub btnInicio_Click(sender As Object, e As EventArgs) Handles btnInicio.Click
        If BackgroundWorker5.IsBusy = False And BackgroundWorker8.IsBusy = False Then
            imagenACtual = 0
            btnInicio.Text = "Cargando imágenes"
            picTodas.Image = My.Resources.cargandogris
            BackgroundWorker5.RunWorkerAsync()
        End If
    End Sub

    Private Sub btnUltimas_Click(sender As Object, e As EventArgs) Handles btnUltimas.Click
        If BackgroundWorker5.IsBusy = False And BackgroundWorker8.IsBusy = False Then
            imagenACtual = objetoConexion.NumeroImagenPublic - 10
            btnUltimas.Text = "Cargando imágenes"
            picTodas.Image = My.Resources.cargandogris
            BackgroundWorker5.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker5_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker5.DoWork
        PictureBox1.Image = objetoConexion.DescargarFotosPublicas(imagenACtual)
        SetText1(objetoConexion.DescargarInfoFotosPublicas(imagenACtual))
        PictureBox2.Image = objetoConexion.DescargarFotosPublicas(imagenACtual + 1)
        SetText2(objetoConexion.DescargarInfoFotosPublicas(imagenACtual + 1))
        PictureBox3.Image = objetoConexion.DescargarFotosPublicas(imagenACtual + 2)
        SetText3(objetoConexion.DescargarInfoFotosPublicas(imagenACtual + 2))
        PictureBox4.Image = objetoConexion.DescargarFotosPublicas(imagenACtual + 3)
        SetText4(objetoConexion.DescargarInfoFotosPublicas(imagenACtual + 3))
        PictureBox5.Image = objetoConexion.DescargarFotosPublicas(imagenACtual + 4)
        SetText5(objetoConexion.DescargarInfoFotosPublicas(imagenACtual + 4))
        PictureBox6.Image = objetoConexion.DescargarFotosPublicas(imagenACtual + 5)
        SetText6(objetoConexion.DescargarInfoFotosPublicas(imagenACtual + 5))
        PictureBox7.Image = objetoConexion.DescargarFotosPublicas(imagenACtual + 6)
        SetText7(objetoConexion.DescargarInfoFotosPublicas(imagenACtual + 6))
        PictureBox8.Image = objetoConexion.DescargarFotosPublicas(imagenACtual + 7)
        SetText8(objetoConexion.DescargarInfoFotosPublicas(imagenACtual + 7))
        PictureBox9.Image = objetoConexion.DescargarFotosPublicas(imagenACtual + 8)
        SetText9(objetoConexion.DescargarInfoFotosPublicas(imagenACtual + 8))
        PictureBox10.Image = objetoConexion.DescargarFotosPublicas(imagenACtual + 9)
        SetText10(objetoConexion.DescargarInfoFotosPublicas(imagenACtual + 9))

    End Sub
#Region "Actualizar texto con delegado"
    Delegate Sub SetTextCallback(ByVal text As String)

    Private Sub SetText1(ByVal text As String)
        If TextBox1.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText1)
            Me.Invoke(d, New Object() {text})
        Else
            TextBox1.Text = text
        End If
    End Sub

    Private Sub SetText2(ByVal text As String)
        If TextBox2.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText2)
            Me.Invoke(d, New Object() {text})
        Else
            TextBox2.Text = text
        End If
    End Sub

    Private Sub SetText3(ByVal text As String)
        If TextBox3.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText3)
            Me.Invoke(d, New Object() {text})
        Else
            TextBox3.Text = text
        End If
    End Sub

    Private Sub SetText4(ByVal text As String)
        If TextBox4.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText4)
            Me.Invoke(d, New Object() {text})
        Else
            TextBox4.Text = text
        End If
    End Sub

    Private Sub SetText5(ByVal text As String)
        If TextBox5.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText5)
            Me.Invoke(d, New Object() {text})
        Else
            TextBox5.Text = text
        End If
    End Sub

    Private Sub SetText6(ByVal text As String)
        If TextBox6.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText6)
            Me.Invoke(d, New Object() {text})
        Else
            TextBox6.Text = text
        End If
    End Sub

    Private Sub SetText7(ByVal text As String)
        If TextBox7.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText7)
            Me.Invoke(d, New Object() {text})
        Else
            TextBox7.Text = text
        End If
    End Sub

    Private Sub SetText8(ByVal text As String)
        If TextBox8.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText8)
            Me.Invoke(d, New Object() {text})
        Else
            TextBox8.Text = text
        End If
    End Sub

    Private Sub SetText9(ByVal text As String)
        If TextBox9.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText9)
            Me.Invoke(d, New Object() {text})
        Else
            TextBox9.Text = text
        End If
    End Sub

    Private Sub SetText10(ByVal text As String)
        If TextBox10.InvokeRequired Then
            Dim d As New SetTextCallback(AddressOf SetText10)
            Me.Invoke(d, New Object() {text})
        Else
            TextBox10.Text = text
        End If
    End Sub
#End Region

    Private Sub BackgroundWorker5_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker5.RunWorkerCompleted
        btnTodasImg.Text = "Ver más imágenes"
        btnInicio.Text = "Volver al inicio"
        btnUltimas.Text = "Ver últimas imágenes"
        picTodas.Image = Nothing

        'Mostramos todo en el listbox al inciar formulario
        If BackgroundWorker4.IsBusy = False And picImagenVisualizada.Image Is Nothing Then
            btnRecargar.Text = "Recargando"
            picRecargar.Image = My.Resources.cargandogris
            BackgroundWorker4.RunWorkerAsync()
        End If


    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        picSubir.Image = Principal.PictureBox1.Image
    End Sub
    'Borrar imagen (sólo en carpetas privadas)
    Private Sub btnBorrar_Click(sender As Object, e As EventArgs) Handles btnBorrar.Click
        If ListBox1.SelectedIndex >= 0 And ComprobarHilos() Then
            Dim respuesta = MessageBox.Show("¿Está seguro de eliminar la imagen? Esta acción no se puede deshacer.", "Apolo Cloud", MessageBoxButtons.YesNo, MessageBoxIcon.Stop)
            If respuesta = Windows.Forms.DialogResult.Yes Then
                btnBorrar.Text = "Borrando"
                picBorrar.Image = My.Resources.cargandogris
                ImagenSeleccionada = ListBox1.SelectedItem.ToString
                If BackgroundWorker7.IsBusy = False And ComprobarHilos() = True Then
                    BackgroundWorker7.RunWorkerAsync()
                Else
                    btnBorrar.Text = "Borrar"
                    picBorrar.Image = Nothing
                End If
            End If
        End If
    End Sub
    Dim borrada As Boolean
    Dim ImagenSeleccionada As String
    Private Sub BackgroundWorker7_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker7.DoWork
        borrada = objetoConexion.EliminarArchivos(ImagenSeleccionada)
    End Sub

    Private Sub BackgroundWorker7_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker7.RunWorkerCompleted
        btnBorrar.Text = "Borrar"
        picBorrar.Image = Nothing
        If borrada = True Then
            MessageBox.Show("La imagen ha sido removida con éxito.", "Apolo Cloud", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        If BackgroundWorker4.IsBusy = False Then 'Recargamos el listbox
            btnRecargar.Text = "Recargando"
            picRecargar.Image = My.Resources.cargandogris
            BackgroundWorker4.RunWorkerAsync()
        End If
    End Sub

    Private Sub SubirImagenActualApoloToolStripMenuItem_Click(sender As Object, e As EventArgs)
        picSubir.Image = Principal.PictureBox1.Image
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblTodasImagenes.Click
        If lblTodasImagenes.Text = "[--Ver listado completo de imágenes--]" And Timer1.Enabled = False Then
            Me.Location = New Size(Me.Location.X, 5)
            lblTodasImagenes.Text = "[--Ocultar listado completo de imágenes--]"
            Timer2.Enabled = True
        ElseIf lblTodasImagenes.Text = "[--Ocultar listado completo de imágenes--]" And Timer2.Enabled = False Then
            lblTodasImagenes.Text = "[--Ver listado completo de imágenes--]"
            Timer1.Enabled = True
        End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Me.Height < 690 Then
            Me.Height += 10
        Else
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.Height > 473 Then
            Me.Height -= 10
        Else
            Timer1.Enabled = False
        End If
    End Sub
    Private Sub Label1_MouseEnter(sender As Object, e As EventArgs) Handles lblTodasImagenes.MouseEnter
        Me.Cursor = Cursors.Hand
        lblTodasImagenes.ForeColor = Color.Black
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles lblTodasImagenes.MouseLeave
        Me.Cursor = Cursors.Default
        lblTodasImagenes.ForeColor = Color.FromArgb(150, 150, 150)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If picImagenVisualizada.Image IsNot Nothing Then
            Principal.PictureBox1.Image = objetoTratamiento.OriginalApoloCloud(picImagenVisualizada.Image)
        End If
    End Sub

    Private Sub txtnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnombre.KeyPress
        'Sólo valores (A-z),(0,9),-_
        If InStr(1, "0123456789,-abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ_-" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub


    Private Sub ClicEs(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case DirectCast(sender, PictureBox).Name
            Case "PicValora1"
                ValorVoto = 1
            Case "PicValora2"
                ValorVoto = 2
            Case "PicValora3"
                ValorVoto = 3
            Case "PicValora4"
                ValorVoto = 4
            Case "PicValora5"
                ValorVoto = 5
        End Select
        If BackgroundWorker6.IsBusy = False And ValorVoto > 0 And ComprobarHilos() = True Then
            picCargandoVoto.Image = My.Resources.cargandogris
            nombreImagen = ListBox1.SelectedItem.ToString.Replace(".jpg", "")
            BackgroundWorker6.RunWorkerAsync()
        End If
    End Sub
    Dim ValorVoto As Integer
    Dim estatus As Boolean
    Private Sub BackgroundWorker6_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker6.DoWork
        estatus = objetoConexion.ValorarFotoPublica(nombreImagen, ValorVoto)
    End Sub
    Private Sub BackgroundWorker6_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker6.RunWorkerCompleted
        picCargandoVoto.Image = Nothing
        If estatus = True And BackgroundWorker3.IsBusy = False Then 'Actualizamos los datos
            picCargandoImagen.Image = My.Resources.cargandogris
            btnVerImagen.Text = "Actualizando datos"
            BackgroundWorker3.RunWorkerAsync()
        End If
    End Sub
#Region "Pintar Estrellas"
    Private Sub dentroEs(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
        Select Case DirectCast(sender, PictureBox).Name
            Case "PicValora1"
                PicValora1.Image = My.Resources.star
            Case "PicValora2"
                PicValora1.Image = My.Resources.star : PicValora2.Image = My.Resources.star
            Case "PicValora3"
                PicValora1.Image = My.Resources.star : PicValora2.Image = My.Resources.star : PicValora3.Image = My.Resources.star
            Case "PicValora4"
                PicValora1.Image = My.Resources.star : PicValora2.Image = My.Resources.star : PicValora3.Image = My.Resources.star : PicValora4.Image = My.Resources.star
            Case "PicValora5"
                PicValora1.Image = My.Resources.star : PicValora2.Image = My.Resources.star : PicValora3.Image = My.Resources.star : PicValora4.Image = My.Resources.star : PicValora5.Image = My.Resources.star
        End Select
    End Sub
#End Region
    Private Sub fueraEs(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
        PicValora1.Image = My.Resources.starGris : PicValora2.Image = My.Resources.starGris : PicValora3.Image = My.Resources.starGris : PicValora4.Image = My.Resources.starGris : PicValora5.Image = My.Resources.starGris
    End Sub


    'Compartir foto como pública
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnCompartir.Click
        If ComprobarHilos() = True And BackgroundWorker8.IsBusy = False And picImagenVisualizada.Image IsNot Nothing And ListBox1.SelectedIndex >= 0 Then
            btnCompartir.Text = "Compartiendo"
            picCompartir.Image = My.Resources.cargandogris
            nombredeImagen = ListBox1.SelectedItem.ToString.Substring(0, ListBox1.SelectedItem.ToString.Length - 4)
            BackgroundWorker8.RunWorkerAsync()
        End If
    End Sub
    Dim compartirImg As Boolean
    Dim nombredeImagen As String
    Private Sub BackgroundWorker8_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker8.DoWork
        compartirImg = objetoConexion.CompartirImagen(picImagenVisualizada.Image, nombredeImagen, lblinfo.Text)
    End Sub

    Private Sub BackgroundWorker8_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker8.RunWorkerCompleted
        btnCompartir.Text = "Hazla pública"
        picCompartir.Image = Nothing
    End Sub

    Private Function ComprobarHilos() As Boolean
        If BackgroundWorker1.IsBusy = False And BackgroundWorker2.IsBusy = False And BackgroundWorker3.IsBusy = False And BackgroundWorker4.IsBusy = False And BackgroundWorker5.IsBusy = False And BackgroundWorker6.IsBusy = False And BackgroundWorker7.IsBusy = False And BackgroundWorker8.IsBusy = False Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub TextBox11_GotFocus(sender As Object, e As EventArgs) Handles TextBox11.GotFocus
        Me.AcceptButton = btnVerImagen
        If TextBox11.Text = "Buscador de imágenes" Then
            TextBox11.Text = "" 'Borramos contenido
        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs) Handles TextBox11.TextChanged
        Dim returnValue As Boolean
        Dim comparisonType As StringComparison
        For i = ListBox1.Items.Count - 1 To 0 Step -1
            returnValue = LCase(ListBox1.Items(i)).StartsWith(LCase(TextBox11.Text), comparisonType)
            If returnValue = True Then
                ListBox1.ClearSelected() 'Borramos las selecciones anteriores
                TextBox11.Focus() 'Establecemos el foco en el texbox
                ListBox1.SetSelected(i, True)
            End If
        Next
    End Sub


    Private Sub txtdescrip_GotFocus(sender As Object, e As EventArgs) Handles txtdescrip.GotFocus
        Me.AcceptButton = btnSubir
    End Sub
    Private Sub txtnombre_GotFocus(sender As Object, e As EventArgs) Handles txtnombre.GotFocus
        Me.AcceptButton = btnSubir
    End Sub

   


    Private Sub lblEliminar_Click(sender As Object, e As EventArgs) Handles lblEliminar.Click
        Dim respuesta = MessageBox.Show("¿Está seguro de eliminar su cuenta? Esta acción no se puede deshacer.", "Apolo Cloud", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If respuesta = Windows.Forms.DialogResult.Yes Then
            If BackgroundWorker9.IsBusy = False Then
                picTodas.Image = My.Resources.cargandogris
                lblEliminar.Text = "Eliminando..."
                BackgroundWorker9.RunWorkerAsync()
            End If
        End If
    End Sub
    Dim borrarCuenta As Boolean
    Private Sub BackgroundWorker9_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker9.DoWork
        borrarCuenta = objetoConexion.EliminarCuentaPrivada()
    End Sub

    Private Sub BackgroundWorker9_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker9.RunWorkerCompleted
        lblEliminar.Text = "Eliminar cuenta"
        picTodas.Image = Nothing
        If borrarCuenta = True Then
            MessageBox.Show("La cuenta ha sido borrada con éxito.", "Apolo Cloud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        End If
    End Sub



    Private Sub lblEliminar_MouseEnter(sender As Object, e As EventArgs) Handles lblEliminar.MouseEnter
        lblEliminar.Font = New Font("Segoe UI", 9, FontStyle.Underline)
        Me.Cursor = Cursors.Hand
        lblEliminar.ForeColor = Color.Black
    End Sub

    Private Sub lblEliminar_MouseLeave(sender As Object, e As EventArgs) Handles lblEliminar.MouseLeave
        lblEliminar.Font = New Font("Segoe UI", 9)
        Me.Cursor = Cursors.Default
        lblEliminar.ForeColor = Color.FromArgb(150, 150, 150)
    End Sub
End Class