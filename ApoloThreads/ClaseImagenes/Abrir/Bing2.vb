Imports ClaseImagenes.Apolo

Public Class Bing2
    Dim objetoTratamiento As New Apolo.TratamientoImagenes
    Dim picImagenes() As PictureBox
    Dim bmpBing(50) As Bitmap
    Dim thIMG As Threading.Thread

    Private Sub Bing2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        Panel1.Controls.Clear() 'Borramos todos los controles ya creados
        ReDim picImagenes(49) 'Hay un total de 50 imágenes
        Dim SeparacionAncho As Integer = 5
        Dim separacionAlto As Integer = 10
        Dim contador As Integer = 0


        For i = 0 To picImagenes.Count - 1 'Creamos la lista de labels
            picImagenes(i) = New PictureBox
            Panel1.Controls.Add(picImagenes(i))
            picImagenes(i).Image = My.Resources.FondoCargando_1_
            picImagenes(i).Size = New Size(167, 167)
            picImagenes(i).BorderStyle = BorderStyle.None
            picImagenes(i).Name = i
            contador += 10
            picImagenes(i).Location = New Size(SeparacionAncho + contador, separacionAlto)
            picImagenes(i).SizeMode = PictureBoxSizeMode.StretchImage

            '-----
            SeparacionAncho += 167
            If SeparacionAncho > 800 Then SeparacionAncho = 0 : separacionAlto += 180 : contador = 0

        Next


        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

        'Recorremos los picturebox para crear el evento
        For Each c As Object In Panel1.Controls
            If c.GetType Is GetType(PictureBox) Then
                AddHandler DirectCast(c, PictureBox).MouseEnter, AddressOf conFoco
                AddHandler DirectCast(c, PictureBox).MouseLeave, AddressOf sinFoco
                AddHandler DirectCast(c, PictureBox).MouseClick, AddressOf Pulsa
            End If
        Next

    End Sub
#Region "Pulsar y abrir imagen"

    Private Sub conFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
    End Sub
    Private Sub sinFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub

    Dim valorImagen As Integer
    Dim cargadoOK As Boolean
    Dim bmpOriginal As Bitmap = Nothing
    Private Sub Pulsa(ByVal sender As Object, ByVal e As System.EventArgs)
        If BackgroundWorker1.IsBusy = False Then
            valorImagen = DirectCast(sender, PictureBox).Name
            PictureBox1.Image = My.Resources.cargandogris
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        bmpOriginal = Nothing
        bmpOriginal = (objetoTratamiento.abrirRecursoWebAxu(ImagenesBing(valorImagen, 1)))
        cargadoOK = False
        If bmpOriginal IsNot Nothing Then 'Si realmente se abre alguna imagen la asignamos al Picture pricipal
            cargadoOK = True
            Principal.PictureBox1.Image = bmpOriginal
            'Aprovechamos y actualizamos el Panel1
            Principal.Panel1.AutoScrollMinSize = Principal.PictureBox1.Image.Size
            Principal.Panel1.AutoScroll = True
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If cargadoOK = True Then
            objetoTratamiento.InfoImagenPrecarga(bmpOriginal, ImagenesBing(valorImagen, 1)) 'Lo hacemos en dos pasos (el abrir la imagen y cargar los recursos) porque si no había fallo y no se guardaba la info (por el delegado..)
            PictureBox1.Image = Nothing
        End If
    End Sub
#End Region

    Dim tamaño As String
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        thIMG = New Threading.Thread(AddressOf resultados)
        If thIMG.ThreadState <> Threading.ThreadState.Running Then
            Label2.Visible = True
            Label2.Text = "Buscando " & TextBox1.Text & " en la web..."
            PictureBox1.Image = My.Resources.cargandogris
            Timer1.Enabled = True
            Timer2.Enabled = True
            Select ComboBox1.SelectedIndex
                Case 0
                    tamaño = ""
                Case 1
                    tamaño = "Small"
                Case 2
                    tamaño = "Medium"
                Case 3
                    tamaño = "Large"
            End Select

            thIMG.Start()
        End If
    End Sub

    Dim ImagenesBing(49, 49) As String
    Sub resultados()
        ImagenesBing = objetoTratamiento.BuscarImagenesBing(TextBox1.Text, 50, tamaño, False)
        Dim rdn As New Random()
        ' generar un random entre 1 y 10000
        Dim numero As Integer
        For i = 0 To picImagenes.Count - 1
            numero = rdn.Next(1, 10000)
            Dim nombreFoto = System.IO.Directory.GetCurrentDirectory().ToString & "\BingImages\" & numero
            Try
                bmpBing(i) = objetoTratamiento.abrirRecursoWebAxu(ImagenesBing(i, 0))
                picImagenes(i).Image = bmpBing(i)
            Catch
            End Try
        Next
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If thIMG.IsAlive = False Then
            Label2.Visible = False
            PictureBox1.Image = Nothing
            Timer1.Enabled = False
        End If
    End Sub

  
 
  

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Interval = 10
        If Me.Height < 600 Then
            Me.Height += 10
        Else
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub Bing2_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        Try
            If e.Delta <= 0 Then
                Panel1.VerticalScroll.Value += 50
            Else
                Panel1.VerticalScroll.Value -= 50
            End If
        Catch
            Panel1.VerticalScroll.Value = 0
        End Try
    End Sub


End Class