Imports ClaseImagenes.Apolo
Public Class CompararImagenes

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox1.Image) 'Imagen de principal

    Function abrirImagen(Optional ByVal imagenActual As Bitmap = Nothing) As Bitmap
        Try
            Dim dialogo As New OpenFileDialog
            With dialogo
                .Filter = "Todos los formatos compatibles|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif" & _
                          "|Ficheros BMP|*.bmp" & _
                          "|Ficheros GIF|*.gif" & _
                          "|Ficheros JPG o JPEG|*.jpg;*.jpeg" & _
                          "|Ficheros PNG|*.png" & _
                          "|Ficheros TIFF|*.tif" & _
                          "|Todos los archivos|*.*"
                .FilterIndex = 0
                If (.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    abrirImagen = Image.FromFile(.FileName)
                    Return abrirImagen
                Else
                    Return imagenActual
                End If
            End With
        Catch e As Exception
            MessageBox.Show(e.ToString)
            abrirImagen = Nothing
            Return imagenActual
        End Try
    End Function
    Sub BorrarLabels()
        For Each c As Control In Panel1.Controls
            If TypeOf c Is Label Then
                c.Text = ""
            End If
        Next
    End Sub
    Sub LabelsBlanco()
        For Each c As Control In Panel1.Controls
            If TypeOf c Is Label Then
                c.ForeColor = Color.Black
            End If
        Next
    End Sub
    Sub pintarLabels()
        If resultados(0) >= 80 Then
            PictureBox3.Image = My.Resources.check
        Else
            PictureBox3.Image = My.Resources.cancel
            LabelRojo.ForeColor = Color.Red
        End If

        If resultados(1) >= 80 Then
            PictureBox4.Image = My.Resources.check
        Else
            PictureBox4.Image = My.Resources.cancel
            Labelverde.ForeColor = Color.Red
        End If
        If resultados(2) >= 80 Then
            PictureBox5.Image = My.Resources.check
        Else
            PictureBox5.Image = My.Resources.cancel
            Labelazul.ForeColor = Color.Red
        End If
        If resultados(3) >= 80 Then
            PictureBox6.Image = My.Resources.check
        Else
            PictureBox6.Image = My.Resources.cancel
            Labelgrises.ForeColor = Color.Red
        End If
        If ((resultados(0) + resultados(1) + resultados(2) + resultados(3)) / 4) >= 80 Then
            PictureBox7.Image = My.Resources.check
        Else
            PictureBox7.Image = My.Resources.cancel
            Labelmedia.ForeColor = Color.Red
        End If
    End Sub
    Sub comparando()
        Try
            ToolStripProgressBar2.Style = ProgressBarStyle.Marquee
            ToolStripStatusLabel1.Text = "Comparando imágenes"
            ToolStripProgressBar2.Size = New Size(100, ToolStripProgressBar1.Size.Height)
            ToolStripProgressBar2.MarqueeAnimationSpeed = 30
        Catch
        End Try
    End Sub
    Sub cargando()
        Try
            ToolStripProgressBar2.Style = ProgressBarStyle.Marquee
            ToolStripStatusLabel1.Text = "Cargando histograma"
            ToolStripProgressBar2.Size = New Size(100, ToolStripProgressBar1.Size.Height)
            ToolStripProgressBar2.MarqueeAnimationSpeed = 30
        Catch
        End Try
    End Sub
    Sub cargado()
        Try
            ToolStripStatusLabel1.Text = "Histograma cargado"
            ToolStripProgressBar2.Size = New Size(100, ToolStripProgressBar1.Size.Height)
            ToolStripProgressBar2.Style = ProgressBarStyle.Continuous
            ToolStripProgressBar2.Value = 100
        Catch
        End Try
    End Sub

    Private Sub CompararImagenes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = bmpP
        PictureBox2.Image = bmpP
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PictureBox1.Image = abrirImagen(PictureBox1.Image)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PictureBox2.Image = abrirImagen(PictureBox2.Image)
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            comparando()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Dim resultados As New ArrayList
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        resultados = objetoTratamiento.CompararDosImagenes(PictureBox1.Image, PictureBox2.Image)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        BorrarLabels()
        LabelsBlanco()
        LabelRojo.Text = "Aciertos rojo:" & " " & resultados(0).ToString & "%"
        Labelverde.Text = "Aciertos verde:" & " " & resultados(1).ToString & "%"
        Labelazul.Text = "Aciertos azul:" & " " & resultados(2).ToString & "%"
        Labelgrises.Text = "Aciertos grises" & " " & resultados(3).ToString & "%"
        Dim media As Integer
        media = (resultados(0) + resultados(1) + resultados(2) + resultados(3)) / 4
        Labelmedia.Text = "Media de aciertos" & " " & media & "%"
        pintarLabels()
        If BackgroundWorker2.IsBusy = False Then
            cargando()
            'Los ponesmos del colores correspondiente
            Chart1.Series("Rojo").Color = Color.Red
            Chart2.Series("Verde").Color = Color.Green
            Chart3.Series("Azul").Color = Color.Blue
            Chart4.Series("Gris").Color = Color.Black
            'Borramos el contenido
            Chart1.Series("Rojo").Points.Clear()
            Chart2.Series("Verde").Points.Clear()
            Chart3.Series("Azul").Points.Clear()
            Chart4.Series("Gris").Points.Clear()
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub

     
    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork

        'Creamos los bitmaps para luego crear su histograma
        Dim matrizRojo(,) As Integer = resultados(4)
        Dim matrizVerde(,) As Integer = resultados(5)
        Dim matrizAzul(,) As Integer = resultados(6)
        Dim matrizGris(,) As Integer = resultados(7)
        Dim bmp1 As New Bitmap(matrizRojo.GetUpperBound(0), matrizRojo.GetUpperBound(1))
        Dim bmp2 As New Bitmap(matrizVerde.GetUpperBound(0), matrizVerde.GetUpperBound(1))
        Dim bmp3 As New Bitmap(matrizAzul.GetUpperBound(0), matrizAzul.GetUpperBound(1))
        Dim bmp4 As New Bitmap(matrizGris.GetUpperBound(0), matrizGris.GetUpperBound(1))

        Dim Valcolor As Integer
        For i = 0 To matrizRojo.GetUpperBound(0) - 1
            For j = 0 To matrizRojo.GetUpperBound(1) - 1
                Valcolor = matrizRojo(i, j)
                bmp1.SetPixel(i, j, Color.FromArgb(Valcolor, Valcolor, Valcolor))

                Valcolor = matrizVerde(i, j)
                bmp2.SetPixel(i, j, Color.FromArgb(Valcolor, Valcolor, Valcolor))

                Valcolor = matrizAzul(i, j)
                bmp3.SetPixel(i, j, Color.FromArgb(Valcolor, Valcolor, Valcolor))

                Valcolor = matrizGris(i, j)
                bmp4.SetPixel(i, j, Color.FromArgb(Valcolor, Valcolor, Valcolor))
            Next
        Next

        Dim histoAcumulado1 = objetoTratamiento.histogramaAcumuladoH(bmp1)
        Dim histoAcumulado2 = objetoTratamiento.histogramaAcumuladoH(bmp2)
        Dim histoAcumulado3 = objetoTratamiento.histogramaAcumuladoH(bmp3)
        Dim histoAcumulado4 = objetoTratamiento.histogramaAcumuladoH(bmp4)
        For i = 0 To UBound(histoAcumulado1)
            SetChart(i + 1, histoAcumulado1(i, 0), histoAcumulado2(i, 0), histoAcumulado3(i, 0), histoAcumulado4(i, 0))
        Next

        For i = 0 To matrizRojo.GetUpperBound(0) - 1
            For j = 0 To matrizRojo.GetUpperBound(1) - 1
                Valcolor = matrizRojo(i, j)
                bmp1.SetPixel(i, j, Color.FromArgb(Valcolor, 0, 0))

                Valcolor = matrizVerde(i, j)
                bmp2.SetPixel(i, j, Color.FromArgb(0, Valcolor, 0))

                Valcolor = matrizAzul(i, j)
                bmp3.SetPixel(i, j, Color.FromArgb(0, 0, Valcolor))

                Valcolor = matrizGris(i, j)
                bmp4.SetPixel(i, j, Color.FromArgb(Valcolor, Valcolor, Valcolor))
            Next
        Next

        PictureBox1.Image = bmp1
        PictureBox2.Image = bmp2sdad
        
    End Sub

    'Con este bloque podemos manejar los controles chart desde un hilo ------
    '--------------------------------------
#Region "Delegado/invokeRequired"
    Delegate Sub SetHistoCallback(ByVal i As Integer, ByVal histoR As ULong, ByVal histoG As ULong, ByVal histoB As ULong, ByVal histoGrises As ULong)

    Private Sub SetChart(ByVal i As Integer, ByVal histoR As ULong, ByVal histoG As ULong, ByVal histoB As ULong, ByVal histoGrises As ULong)
        Try
            ' InvokeRequired required compares the thread ID of the
            ' calling thread to the thread ID of the creating thread.
            ' If these threads are different, it returns true.
            If Chart1.InvokeRequired Then
                Dim d As New SetHistoCallback(AddressOf SetChart)
                Me.Invoke(d, New Object() {i, histoR, histoG, histoB, histoG})
            Else
                Chart1.Series("Rojo").Points.AddXY(i, histoR)
                Chart2.Series("Verde").Points.AddXY(i, histoG)
                Chart3.Series("Azul").Points.AddXY(i, histoB)
                Chart4.Series("Gris").Points.AddXY(i, histoGrises)
            End If
        Catch
        End Try
    End Sub
#End Region
    '-----------------------------------------------------------------------


    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        cargado()
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.Width < 970 Then
            Me.Width += 10
        Else
            Timer1.Enabled = False
        End If
    End Sub
End Class