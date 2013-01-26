Imports ClaseImagenes.Apolo
Public Class RegistroCambio
    Dim objetoTratamiento As New TratamientoImagenes 'Objeto para todo el formulario así no se inicializan las variables de la clase en cada instancia

    Private Sub RegistroCambio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Controls.Clear() 'Borramos todos los controles ya creados
        Dim listaCompletaImagenes = objetoTratamiento.ListadoTotalDeImagenes 'Listado de los bitmaps
        Dim picImagenes(listaCompletaImagenes.Count - 1) As PictureBox 'Listado de picturebox

        Dim listaCompletaInfo = objetoTratamiento.ListadoTotalDeInfo
        Dim labelInfo(listaCompletaInfo.Count - 1) As Label
        Dim alto As Integer = 80

        For i = 0 To listaCompletaInfo.Count - 1 'Creamos la lista de labels
            'Labels
            labelInfo(i) = New Label
            Panel1.Controls.Add(labelInfo(i))
            labelInfo(i).Text = listaCompletaInfo(i)
            labelInfo(i).Size = New Size(250, 150)
            labelInfo(i).Location = New Size(255, alto)
            labelInfo(i).Font = New Font("Segoe UI", 10)
            alto += 180
            '-----
        Next


        alto = 25

        For i = 0 To listaCompletaImagenes.Count - 1 'Creamos la lista de picturebox
            'Pictures
            picImagenes(i) = New PictureBox
            Panel1.Controls.Add(picImagenes(i))
            picImagenes(i).Image = listaCompletaImagenes(i)
            picImagenes(i).Size = New Size(200, 150)
            picImagenes(i).Location = New Size(30, alto)
            picImagenes(i).SizeMode = PictureBoxSizeMode.StretchImage
            picImagenes(i).BorderStyle = BorderStyle.FixedSingle
            alto += 180
            '-----

        Next

        '-- Scroll Vertical
        Me.Panel1.VerticalScroll.Visible = True
        Me.Panel1.AutoScroll = True

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

    Private Sub conFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
    End Sub


    Private Sub sinFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Pulsa(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim bmp As New Bitmap(DirectCast(sender, PictureBox).Image)
        Me.Cursor = Cursors.Default
        Principal.PictureBox1.Image = objetoTratamiento.ActualizarImagen(bmp) 'La imagen seleccionado la actualizamos
        RegistroCambio_Load(sender, e) 'Recargamos
    End Sub


End Class