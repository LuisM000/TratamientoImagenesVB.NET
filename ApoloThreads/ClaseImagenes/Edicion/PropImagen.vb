Imports ClaseImagenes.Apolo
Imports System.Drawing.Imaging

Public Class PropImagen
    Dim objetoTratamiento As New TratamientoImagenes
    Private Sub PropImagen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabPage1.AutoScroll = True
        TabPage2.AutoScroll = True
        Dim objetoTratamiento As New TratamientoImagenes
        PictureBox1.Image = Principal.PictureBox1.Image
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Text = Principal.Text
        Dim bmp As New Bitmap(Principal.PictureBox1.Image)


        'Nombre del archivo
        lblnombre.Text = TextBox1.Text.Substring(0, InStr(TextBox1.Text, "]"))

        'Tamaño en píxeles
        lblTamanoPixe.Text = FormatNumber(bmp.Width, 2) & " x " & FormatNumber(bmp.Height, 2) & " píxeles"


        'Tamaño en pulgadas
        Dim dpiH, dpiV As Integer 'Puntos por pulgada
        Dim gr As Graphics
        gr = Me.CreateGraphics
        dpiH = gr.DpiX 'Puntos por pulgada
        dpiV = gr.DpiY
        lblpulgadas.Text = FormatNumber(bmp.Width / dpiH, 2) & " x " & FormatNumber(bmp.Height / dpiV, 2) & " pulgadas"

        'Resolución (puntos por pulgada)
        lblResolucion.Text = dpiH & " x " & dpiV & " ppp"

        'Obtención de imagen
        Try
            lblobtenida.Text = TextBox1.Text.Substring(InStr(TextBox1.Text, ")"), TextBox1.Text.Length - InStr(TextBox1.Text, ")"))
            'Quitamos espacios iniciales
            lblobtenida.Text = lblobtenida.Text.Substring(3, lblobtenida.Text.Length - 3)
        Catch
            lblobtenida.Text = "Origen desconocido"
        End Try

        'Obtención del formato
        Try
            Dim cadenaAux() As String
            cadenaAux = lblnombre.Text.Split(".")
            lblformato.Text = cadenaAux(cadenaAux.Count - 1).Substring(0, cadenaAux(cadenaAux.Count - 1).Count - 1)
        Catch
            lblformato.Text = "Formato desconocido"
        End Try
        'Obtención del número de píxeles
        lblnumPix.Text = CInt((Principal.PictureBox1.Image.Width * Principal.PictureBox1.Image.Height)) & " píxeles"
        'Creamos los histogramas
        actualizarHistrograma()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub


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
            Dim bmpHisto As New Bitmap(PictureBox1.Image, New Size(New Point(100, 100)))
            Dim histoAcumulado = objetoTratamiento.histogramaAcumulado(bmpHisto)
            For i = 0 To UBound(histoAcumulado)
                Chart1.Series("Rojo").Points.AddXY(i + 1, histoAcumulado(i, 0))
                Chart2.Series("Verde").Points.AddXY(i + 1, histoAcumulado(i, 1))
                Chart3.Series("Azul").Points.AddXY(i + 1, histoAcumulado(i, 2))
            Next
        Catch
            MessageBox.Show("Lo sentimos, algo ha ocurrido. Pruebe a deshacer los cambios y desactivar el histograma automático (Herramientas/Histograma automático)", "Apolo threads", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub PropImagen_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PictureBox1.Location = New Size(Panel1.Width - 65, PictureBox1.Location.Y)
        Button1.Location = New Size(Panel1.Width - 92, Button1.Location.Y)
        TextBox1.Width = Panel1.Width - 100
        TabControl1.Width = Me.Width - 11
        Chart1.Width = Me.Width * 0.67
        Chart2.Width = Me.Width * 0.67
        Chart3.Width = Me.Width * 0.67
    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click
        'Hay que crear la instancia con constructor y el valor del color
        Dim frmHisto As New Histogramas(Color.Red)
        frmHisto.Show()
    End Sub

    Private Sub Chart2_Click(sender As Object, e As EventArgs) Handles Chart2.Click
        'Hay que crear la instancia con constructor y el valor del color
        Dim frmHisto As New Histogramas(Color.Green)
        frmHisto.Show()
    End Sub

    Private Sub Chart3_Click(sender As Object, e As EventArgs) Handles Chart3.Click
        'Hay que crear la instancia con constructor y el valor del color
        Dim frmHisto As New Histogramas(Color.Blue)
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
End Class