Imports ClaseImagenes.Apolo
Imports System.ComponentModel

Public Class AbrirBing
    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim contador = 0
    Dim numeroAbrir As Integer = 0
    Dim datos(50, 50) As String
    Public thIMG As Threading.Thread

    Private Sub AbrirBing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

        'Recorremos los Picturebox y al entrar dentro o salir se cambia el cursor 
        For Each c As Object In Me.Controls
            If c.GetType Is GetType(PictureBox) Then
                AddHandler DirectCast(c, PictureBox).MouseEnter, AddressOf dentroP
                AddHandler DirectCast(c, PictureBox).MouseLeave, AddressOf fueraP
            End If
        Next
    End Sub


    Private Sub dentroP(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
    End Sub
    Private Sub fueraP(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        contador = 0
        comprobar()
        thIMG = New Threading.Thread(AddressOf resultados)
        If thIMG.ThreadState <> Threading.ThreadState.Running Then
            thIMG.Start()
        End If
    End Sub
    Sub comprobar()
        If TextBox1.Text <> "" Then
            Me.Cursor = Cursors.AppStarting
            Timer1.Enabled = True
            Dim precarga = False
            If CheckBox1.Checked = True Then
                precarga = True
            Else
                precarga = False
            End If
            Button2.Enabled = True
            Select Case ComboBox1.SelectedIndex
                Case -1
                    datos = objetoTratamiento.BuscarImagenesBing(TextBox1.Text, 50, , precarga)
                Case 0
                    datos = objetoTratamiento.BuscarImagenesBing(TextBox1.Text, 50, , precarga)
                Case 1
                    datos = objetoTratamiento.BuscarImagenesBing(TextBox1.Text, 50, "Small", precarga)
                Case 2
                    datos = objetoTratamiento.BuscarImagenesBing(TextBox1.Text, 50, "Medium", precarga)
                Case 3
                    datos = objetoTratamiento.BuscarImagenesBing(TextBox1.Text, 50, "Large", precarga)
                Case Else
                    datos = objetoTratamiento.BuscarImagenesBing(TextBox1.Text, 50, , precarga)
            End Select
        End If
        Me.Cursor = Cursors.AppStarting
    End Sub

    Sub resultados()

        Try
            Me.PictureBox1.Image = abrirRecursoWeb(datos(0 + contador, 0).ToString)
            Me.PictureBox2.Image = abrirRecursoWeb(datos(1 + contador, 0).ToString)
            Me.PictureBox3.Image = abrirRecursoWeb(datos(2 + contador, 0).ToString)
            Me.PictureBox4.Image = abrirRecursoWeb(datos(3 + contador, 0).ToString)
            Me.PictureBox5.Image = abrirRecursoWeb(datos(4 + contador, 0).ToString)
            Me.PictureBox6.Image = abrirRecursoWeb(datos(5 + contador, 0).ToString)
            Me.PictureBox7.Image = abrirRecursoWeb(datos(6 + contador, 0).ToString)
            Me.PictureBox8.Image = abrirRecursoWeb(datos(7 + contador, 0).ToString)
            Me.PictureBox10.Image = abrirRecursoWeb(datos(8 + contador, 0).ToString)
            Me.PictureBox11.Image = abrirRecursoWeb(datos(9 + contador, 0).ToString)
        Catch
            contador -= 10
        End Try
        thIMG = Nothing

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        contador += 10
        limpiar()
        thIMG = New Threading.Thread(AddressOf resultados)
        If thIMG.ThreadState <> Threading.ThreadState.Running Then
            thIMG.Start()
        End If
    End Sub


#Region "MarcarPictureBox"
    Sub limpiar()
        numeroAbrir = 0

        PictureBox1.BorderStyle = BorderStyle.None
        PictureBox2.BorderStyle = BorderStyle.None
        PictureBox3.BorderStyle = BorderStyle.None
        PictureBox4.BorderStyle = BorderStyle.None
        PictureBox5.BorderStyle = BorderStyle.None
        PictureBox6.BorderStyle = BorderStyle.None
        PictureBox7.BorderStyle = BorderStyle.None
        PictureBox8.BorderStyle = BorderStyle.None
        PictureBox10.BorderStyle = BorderStyle.None
        PictureBox11.BorderStyle = BorderStyle.None

    End Sub
#End Region
#Region "PintarBordesPict"
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        limpiar()
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        numeroAbrir = 1
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        limpiar()
        PictureBox5.BorderStyle = BorderStyle.FixedSingle
        numeroAbrir = 5
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        limpiar()
        PictureBox6.BorderStyle = BorderStyle.FixedSingle
        numeroAbrir = 6
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        limpiar()
        PictureBox7.BorderStyle = BorderStyle.FixedSingle
        numeroAbrir = 7
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        limpiar()
        PictureBox8.BorderStyle = BorderStyle.FixedSingle
        numeroAbrir = 8
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        limpiar()
        PictureBox2.BorderStyle = BorderStyle.FixedSingle
        numeroAbrir = 2
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        limpiar()
        PictureBox3.BorderStyle = BorderStyle.FixedSingle
        numeroAbrir = 3
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        limpiar()
        PictureBox4.BorderStyle = BorderStyle.FixedSingle
        numeroAbrir = 4
    End Sub
    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        limpiar()
        PictureBox11.BorderStyle = BorderStyle.FixedSingle
        numeroAbrir = 10
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        limpiar()
        PictureBox10.BorderStyle = BorderStyle.FixedSingle
        numeroAbrir = 9
    End Sub

#End Region

 


    'no lo incluimos en la clase para que no altere las imagenes guardadas
    Function abrirRecursoWeb(ByVal enlace As String) As Bitmap
        Try
            Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(enlace)
            Dim response As System.Net.WebResponse = request.GetResponse()
            Dim responseStream As System.IO.Stream = response.GetResponseStream()
            Dim bmp As New Bitmap(responseStream)
            Return bmp
        Catch
            Dim bmp As Bitmap
            bmp = Nothing
            Return bmp
        End Try
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.Height < 489 Then
            Me.Height = Me.Height + 39
        Else
            Timer1.Enabled = False
        End If
    End Sub


    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        comprobar()
        thIMG = New Threading.Thread(AddressOf resultados)
        If thIMG.ThreadState <> Threading.ThreadState.Running Then
            cargando()
            thIMG.Start()
        End If
        Timer2.Enabled = False
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Timer2.Enabled = True 'Para que se marque la casilla
    End Sub

    Sub cargando()
        PictureBox1.Image = My.Resources.cargando1
        PictureBox2.Image = My.Resources.cargando1
        PictureBox3.Image = My.Resources.cargando1
        PictureBox4.Image = My.Resources.cargando1
        PictureBox5.Image = My.Resources.cargando1
        PictureBox6.Image = My.Resources.cargando1
        PictureBox7.Image = My.Resources.cargando1
        PictureBox8.Image = My.Resources.cargando1
        PictureBox10.Image = My.Resources.cargando1
        PictureBox11.Image = My.Resources.cargando1
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If numeroAbrir <> 0 Then
            If CheckBox1.Checked = False Then
                abriendo()
                BackgroundWorker1.RunWorkerAsync()
            Else
                Select Case numeroAbrir
                    Case 1
                        Principal.PictureBox1.Image = PictureBox1.Image 'Cargamos la imagen en en Picture del formulario
                        objetoTratamiento.InfoImagenPrecarga(PictureBox1.Image, datos(0 + contador, 0).ToString)
                    Case 2
                        Principal.PictureBox1.Image = PictureBox2.Image
                        objetoTratamiento.InfoImagenPrecarga(PictureBox2.Image, datos(1 + contador, 0).ToString)
                    Case 3
                        Principal.PictureBox1.Image = PictureBox3.Image
                        objetoTratamiento.InfoImagenPrecarga(PictureBox3.Image, datos(2 + contador, 0).ToString)
                    Case 4
                        Principal.PictureBox1.Image = PictureBox4.Image
                        objetoTratamiento.InfoImagenPrecarga(PictureBox4.Image, datos(3 + contador, 0).ToString)
                    Case 5
                        Principal.PictureBox1.Image = PictureBox5.Image
                        objetoTratamiento.InfoImagenPrecarga(PictureBox5.Image, datos(4 + contador, 0).ToString)
                    Case 6
                        Principal.PictureBox1.Image = PictureBox6.Image
                        objetoTratamiento.InfoImagenPrecarga(PictureBox6.Image, datos(5 + contador, 0).ToString)
                    Case 7
                        Principal.PictureBox1.Image = PictureBox7.Image
                        objetoTratamiento.InfoImagenPrecarga(PictureBox7.Image, datos(6 + contador, 0).ToString)
                    Case 8
                        Principal.PictureBox1.Image = PictureBox8.Image
                        objetoTratamiento.InfoImagenPrecarga(PictureBox8.Image, datos(7 + contador, 0).ToString)
                    Case 9
                        Principal.PictureBox1.Image = PictureBox10.Image
                        objetoTratamiento.InfoImagenPrecarga(PictureBox10.Image, datos(8 + contador, 0).ToString)
                    Case 10
                        Principal.PictureBox1.Image = PictureBox11.Image
                        objetoTratamiento.InfoImagenPrecarga(PictureBox11.Image, datos(9 + contador, 0).ToString)
                End Select
            End If
            'Actualizamos el Panel1
            Principal.Panel1.AutoScrollMinSize = PictureBox1.Image.Size
            Principal.Panel1.AutoScroll = True
        End If
    End Sub

    Dim bmpt As Bitmap 'Variable global con imagen
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Select Case numeroAbrir
                Case 1
                    bmpt = objetoTratamiento.abrirRecursoWebAxu(datos(0 + contador, 1).ToString) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                Case 2
                    bmpt = objetoTratamiento.abrirRecursoWebAxu(datos(1 + contador, 1).ToString)
                Case 3
                    bmpt = objetoTratamiento.abrirRecursoWebAxu(datos(2 + contador, 1).ToString)
                Case 4
                    bmpt = objetoTratamiento.abrirRecursoWebAxu(datos(3 + contador, 1).ToString)
                Case 5
                    bmpt = objetoTratamiento.abrirRecursoWebAxu(datos(4 + contador, 1).ToString)
                Case 6
                    bmpt = objetoTratamiento.abrirRecursoWebAxu(datos(5 + contador, 1).ToString)
                Case 7
                    bmpt = objetoTratamiento.abrirRecursoWebAxu(datos(6 + contador, 1).ToString)
                Case 8
                    bmpt = objetoTratamiento.abrirRecursoWebAxu(datos(7 + contador, 1).ToString)
                Case 9
                    bmpt = objetoTratamiento.abrirRecursoWebAxu(datos(8 + contador, 1).ToString)
                Case 10
                    bmpt = objetoTratamiento.abrirRecursoWebAxu(datos(9 + contador, 1).ToString)
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        abierto()
        Select Case numeroAbrir
            Case 1
                objetoTratamiento.InfoImagenPrecarga(bmpt, (datos(0 + contador, 1).ToString)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 2
                objetoTratamiento.InfoImagenPrecarga(bmpt, (datos(1 + contador, 1).ToString)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 3
                objetoTratamiento.InfoImagenPrecarga(bmpt, (datos(2 + contador, 1).ToString)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 4
                objetoTratamiento.InfoImagenPrecarga(bmpt, (datos(3 + contador, 1).ToString)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 5
                objetoTratamiento.InfoImagenPrecarga(bmpt, (datos(4 + contador, 1).ToString)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 6
                objetoTratamiento.InfoImagenPrecarga(bmpt, (datos(5 + contador, 1).ToString)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 7
                objetoTratamiento.InfoImagenPrecarga(bmpt, (datos(6 + contador, 1).ToString)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 8
                objetoTratamiento.InfoImagenPrecarga(bmpt, (datos(7 + contador, 1).ToString)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 9
                objetoTratamiento.InfoImagenPrecarga(bmpt, (datos(8 + contador, 1).ToString)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 10
                objetoTratamiento.InfoImagenPrecarga(bmpt, (datos(9 + contador, 1).ToString)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 11
                objetoTratamiento.InfoImagenPrecarga(bmpt, (datos(10 + contador, 1).ToString)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 12
                objetoTratamiento.InfoImagenPrecarga(bmpt, (datos(11 + contador, 1).ToString)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
        End Select

    End Sub


    Sub abriendo()
        ToolStripProgressBar1.Style = ProgressBarStyle.Marquee
        ToolStripStatusLabel1.Text = "Abriendo  imagen"
        ToolStripProgressBar1.Size = New Size(100, ToolStripProgressBar1.Size.Height)
        ToolStripProgressBar1.MarqueeAnimationSpeed = 30
    End Sub
    Sub abierto()
        ToolStripStatusLabel1.Text = "Imagen abierta"
        ToolStripProgressBar1.Size = New Size(100, ToolStripProgressBar1.Size.Height)
        ToolStripProgressBar1.Style = ProgressBarStyle.Continuous
        ToolStripProgressBar1.Value = 100
    End Sub
End Class