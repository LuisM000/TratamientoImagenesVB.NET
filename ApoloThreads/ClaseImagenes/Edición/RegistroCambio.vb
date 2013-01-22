Imports ClaseImagenes.Apolo
Public Class RegistroCambio
    Dim WithEvents objetoTratamiento As New TratamientoImagenes 'Objeto para todo el formulario así no se inicializan las variables de la clase en cada instancia
    Private Sub RegistroCambio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim listaCompletaInfo = objetoTratamiento.ListadoTotalDeInfo
        Dim labelInfo(listaCompletaInfo.Count - 1) As Label
        Dim alto As Integer = 80
      
        For i = 0 To listaCompletaInfo.Count - 1
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

        Dim listaCompletaImagenes = objetoTratamiento.ListadoTotalDeImagenes
        Dim picImagenes(listaCompletaImagenes.Count - 1) As PictureBox
        alto = 25

        For i = 0 To listaCompletaImagenes.Count - 1
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

    End Sub
End Class