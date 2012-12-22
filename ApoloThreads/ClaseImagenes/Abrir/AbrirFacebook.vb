Imports System.Xml.XPath
Imports System.Net
Imports Newtonsoft.Json
Imports System.Text
Imports System.Xml
Imports ClaseImagenes.Apolo
Public Class AbrirFacebook
    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim contador As Integer
    Dim numAbrir As Integer
    Dim fotos As New ArrayList 'Contenedor de los enlaces

#Region "Procedimientos y funciones extra"
    Sub limpiarPic()
        PictureBox1.BorderStyle = BorderStyle.None
        PictureBox2.BorderStyle = BorderStyle.None
        PictureBox3.BorderStyle = BorderStyle.None
        PictureBox4.BorderStyle = BorderStyle.None
        PictureBox5.BorderStyle = BorderStyle.None
        PictureBox6.BorderStyle = BorderStyle.None
        PictureBox7.BorderStyle = BorderStyle.None
        PictureBox8.BorderStyle = BorderStyle.None
        PictureBox9.BorderStyle = BorderStyle.None
        PictureBox10.BorderStyle = BorderStyle.None
        PictureBox11.BorderStyle = BorderStyle.None
        PictureBox12.BorderStyle = BorderStyle.None
    End Sub
    Sub limpiar()
        PictureBox1.Image = Nothing
        PictureBox2.Image = Nothing
        PictureBox3.Image = Nothing
        PictureBox4.Image = Nothing
        PictureBox5.Image = Nothing
        PictureBox6.Image = Nothing
        PictureBox7.Image = Nothing
        PictureBox8.Image = Nothing
        PictureBox9.Image = Nothing
        PictureBox10.Image = Nothing
        PictureBox11.Image = Nothing
        PictureBox12.Image = Nothing
    End Sub
   
    Private Sub dentroP(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub fueraP(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub

    Sub cargando()
        ToolStripProgressBar1.Style = ProgressBarStyle.Marquee
        ToolStripStatusLabel1.Text = "Cargando"
        ToolStripProgressBar1.Size = New Size(100, ToolStripProgressBar1.Size.Height)
        ToolStripProgressBar1.MarqueeAnimationSpeed = 30
    End Sub
    Sub cargado()
        Try
            ToolStripStatusLabel1.Text = "Imágenes cargadas"
            ToolStripProgressBar1.Size = New Size(100, ToolStripProgressBar1.Size.Height)
            ToolStripProgressBar1.Style = ProgressBarStyle.Continuous
            ToolStripProgressBar1.Value = 100
        Catch
        End Try
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
#End Region


    Private Sub AbrirFacebook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

        For Each c As Object In Panel1.Controls
            If c.GetType Is GetType(PictureBox) Then
                AddHandler DirectCast(c, PictureBox).MouseEnter, AddressOf dentroP
                AddHandler DirectCast(c, PictureBox).MouseLeave, AddressOf fueraP

            End If
        Next

        numAbrir = 0
        Dim urlfacebook As New Uri("https://graph.facebook.com/oauth/authorize?type=user_agent&client_id=504262102918292&redirect_uri=http://www.facebook.com/connect/login_success.html&scope=user_photos")
        WebBrowser1.Url = urlfacebook
        Timer1.Enabled = True
        WebBrowser1.ScrollBarsEnabled = False
        contador = 0
        WebBrowser1.Visible = True
        Panel1.Visible = False
        Panel1.Location = New Size(12, 352)
    End Sub


    Sub mostrarImagenes()

        Dim datos = WebBrowser1.Url.ToString
        datos = datos.Replace("http://www.facebook.com/connect/login_success.html#access_token=", "")
        Dim aux = datos.Split("&expires_in")
        datos = aux(0)

        Try

            Dim web As New WebClient, obj As Object
            Dim link As String = "https://graph.facebook.com/me?access_token=" & datos

            obj = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(web.DownloadData(link)))

            Dim ID = obj("id").value




            Dim web2 As New WebClient, obj2 As Object
            Dim link2 As String = "https://graph.facebook.com/" & ID & "/photos?access_token=" & datos


            obj2 = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(web2.DownloadData(link2)))
            Dim s As String
            s = 30

            Dim xml = JsonToXml(obj2.ToString)


            Dim NodeIter As XPathNodeIterator
            Dim nav = xml.CreateNavigator

            Dim Exfotos = "//source"

            'Recorremos el xml
            NodeIter = nav.Select(Exfotos)
            While (NodeIter.MoveNext())
                fotos.Add(NodeIter.Current.Value)
            End While
            For i = 0 To fotos.Count - 1
                fotos(i) = fotos(i).ToString.Replace("http//", "http://")
            Next
            PictureBox1.Visible = True
            PictureBox2.Visible = True
            PictureBox3.Visible = True
            PictureBox4.Visible = True
            PictureBox5.Visible = True
            PictureBox6.Visible = True
            PictureBox7.Visible = True
            PictureBox8.Visible = True
            PictureBox9.Visible = True
            PictureBox10.Visible = True
            PictureBox11.Visible = True
            PictureBox12.Visible = True
            Button1.Visible = True
            Button2.Visible = True
            Button3.Visible = True
            Panel1.Visible = True
            WebBrowser1.Visible = False
            If BackgroundWorker1.IsBusy = False Then
                cargando()
                BackgroundWorker1.RunWorkerAsync() 'Cargamos las imágenes en otro hilo
                Timer2.Enabled = True
            End If
        Catch ex As Exception
            Button1.Enabled = False

        End Try


    End Sub

    Public Function JsonToXml(json As String) As XmlDocument 'De JSON a XML
        Dim newNode As XmlNode = Nothing
        Dim appendToNode As XmlNode = Nothing
        Dim returnXmlDoc As New XmlDocument()
        returnXmlDoc.LoadXml("<Document />")
        Dim rootNode As XmlNode = returnXmlDoc.SelectSingleNode("Document")
        appendToNode = rootNode

        Dim arrElementData As String()
        Dim arrElements As String() = json.Split(ControlChars.Cr)
        For Each element As String In arrElements
            Dim processElement As String = element.Replace(vbCr, "").Replace(vbLf, "").Replace(vbTab, "").Trim()
            If (processElement.IndexOf("}") > -1 OrElse processElement.IndexOf("]") > -1) AndAlso appendToNode IsNot rootNode Then
                appendToNode = appendToNode.ParentNode
            ElseIf processElement.IndexOf("[") > -1 Then
                processElement = processElement.Replace(":", "").Replace("[", "").Replace("""", "").Trim()
                newNode = returnXmlDoc.CreateElement(processElement)
                appendToNode.AppendChild(newNode)
                appendToNode = newNode
            ElseIf processElement.IndexOf("{") > -1 AndAlso processElement.IndexOf(":") > -1 Then
                processElement = processElement.Replace(":", "").Replace("{", "").Replace("""", "").Trim()
                newNode = returnXmlDoc.CreateElement(processElement)
                appendToNode.AppendChild(newNode)
                appendToNode = newNode
            Else
                If processElement.IndexOf(":") > -1 Then
                    arrElementData = processElement.Replace(": """, ":").Replace(""",", "").Replace("""", "").Split(":"c)
                    newNode = returnXmlDoc.CreateElement(arrElementData(0))
                    For i As Integer = 1 To arrElementData.Length - 1
                        newNode.InnerText += arrElementData(i)
                    Next
                    appendToNode.AppendChild(newNode)
                End If
            End If
        Next

        Return returnXmlDoc
    End Function

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Panel1.Location.Y > 15 Then
            Panel1.Location = New Size(Panel1.Location.X, Panel1.Location.Y - 20)

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If WebBrowser1.Url IsNot Nothing Then
            If WebBrowser1.Url.ToString.Contains("access_token") = True Then
                mostrarImagenes()
                Timer1.Enabled = False
            End If
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            PictureBox1.Image = abrirRecursoWeb(fotos(7 + contador))
            PictureBox2.Image = abrirRecursoWeb(fotos(17 + contador))
            PictureBox3.Image = abrirRecursoWeb(fotos(27 + contador))
            PictureBox4.Image = abrirRecursoWeb(fotos(37 + contador))
            PictureBox5.Image = abrirRecursoWeb(fotos(47 + contador))
            PictureBox6.Image = abrirRecursoWeb(fotos(57 + contador))
            PictureBox7.Image = abrirRecursoWeb(fotos(67 + contador))
            PictureBox8.Image = abrirRecursoWeb(fotos(77 + contador))
            PictureBox9.Image = abrirRecursoWeb(fotos(87 + contador))
            PictureBox10.Image = abrirRecursoWeb(fotos(97 + contador))
            PictureBox11.Image = abrirRecursoWeb(fotos(107 + contador))
            PictureBox12.Image = abrirRecursoWeb(fotos(117 + contador))
        Catch
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        cargado()
    End Sub
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


#Region "PintarBordesPict"
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If PictureBox1.Image IsNot Nothing Then
            limpiarPic()
            PictureBox1.BorderStyle = BorderStyle.FixedSingle
            numAbrir = 1
        End If
    End Sub

    Private Sub PictureBox12_Click(sender As Object, e As EventArgs) Handles PictureBox12.Click
        If PictureBox12.Image IsNot Nothing Then
            limpiarPic()
            PictureBox12.BorderStyle = BorderStyle.FixedSingle
            numAbrir = 12
        End If
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click
        If PictureBox11.Image IsNot Nothing Then
            limpiarPic()
            PictureBox11.BorderStyle = BorderStyle.FixedSingle
            numAbrir = 11
        End If
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click
        If PictureBox10.Image IsNot Nothing Then
            limpiarPic()
            PictureBox10.BorderStyle = BorderStyle.FixedSingle
            numAbrir = 10
        End If
    End Sub

    Private Sub PictureBox9_Click(sender As Object, e As EventArgs) Handles PictureBox9.Click
        If PictureBox9.Image IsNot Nothing Then
            limpiarPic()
            PictureBox9.BorderStyle = BorderStyle.FixedSingle
            numAbrir = 9
        End If
    End Sub

    Private Sub PictureBox8_Click(sender As Object, e As EventArgs) Handles PictureBox8.Click
        If PictureBox8.Image IsNot Nothing Then
            limpiarPic()
            PictureBox8.BorderStyle = BorderStyle.FixedSingle
            numAbrir = 8
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If PictureBox7.Image IsNot Nothing Then
            limpiarPic()
            PictureBox7.BorderStyle = BorderStyle.FixedSingle
            numAbrir = 7
        End If
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If PictureBox6.Image IsNot Nothing Then
            limpiarPic()
            PictureBox6.BorderStyle = BorderStyle.FixedSingle
            numAbrir = 6
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        If PictureBox5.Image IsNot Nothing Then
            limpiarPic()
            PictureBox5.BorderStyle = BorderStyle.FixedSingle
            numAbrir = 5
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If PictureBox4.Image IsNot Nothing Then
            limpiarPic()
            PictureBox4.BorderStyle = BorderStyle.FixedSingle
            numAbrir = 4
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If PictureBox3.Image IsNot Nothing Then
            limpiarPic()
            PictureBox3.BorderStyle = BorderStyle.FixedSingle
            numAbrir = 3
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If PictureBox2.Image IsNot Nothing Then
            limpiarPic()
            PictureBox2.BorderStyle = BorderStyle.FixedSingle
            numAbrir = 2
        End If
    End Sub
#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            limpiarPic() 'Quitamos el border style
            limpiar() 'Lo dejamos sin imagen
            contador += 100
            cargando()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If BackgroundWorker1.IsBusy = False Then
            contador = 0
            cargando()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If BackgroundWorker2.IsBusy = False Then
            abriendo()
            BackgroundWorker2.RunWorkerAsync()
        End If
    End Sub

    Dim bmpt As Bitmap
    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Try
            If numAbrir <> 0 Then
                Select Case numAbrir
                    Case 1
                        bmpt = objetoTratamiento.abrirRecursoWebAxu(fotos(0 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                    Case 2
                        bmpt = objetoTratamiento.abrirRecursoWebAxu(fotos(10 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                    Case 3
                        bmpt = objetoTratamiento.abrirRecursoWebAxu(fotos(20 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                    Case 4
                        bmpt = objetoTratamiento.abrirRecursoWebAxu(fotos(30 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                    Case 5
                        bmpt = objetoTratamiento.abrirRecursoWebAxu(fotos(40 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                    Case 6
                        bmpt = objetoTratamiento.abrirRecursoWebAxu(fotos(50 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                    Case 7
                        bmpt = objetoTratamiento.abrirRecursoWebAxu(fotos(60 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                    Case 8
                        bmpt = objetoTratamiento.abrirRecursoWebAxu(fotos(70 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                    Case 9
                        bmpt = objetoTratamiento.abrirRecursoWebAxu(fotos(80 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                    Case 10
                        bmpt = objetoTratamiento.abrirRecursoWebAxu(fotos(90 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                    Case 11
                        bmpt = objetoTratamiento.abrirRecursoWebAxu(fotos(100 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                    Case 12
                        bmpt = objetoTratamiento.abrirRecursoWebAxu(fotos(110 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
                End Select
                Principal.PictureBox1.Image = bmpt
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        abierto()
        Select Case numAbrir
            Case 1
                objetoTratamiento.InfoImagenPrecarga(bmpt, fotos(0 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 2
                objetoTratamiento.InfoImagenPrecarga(bmpt, fotos(10 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 3
                objetoTratamiento.InfoImagenPrecarga(bmpt, fotos(20 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 4
                objetoTratamiento.InfoImagenPrecarga(bmpt, fotos(30 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 5
                objetoTratamiento.InfoImagenPrecarga(bmpt, fotos(40 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 6
                objetoTratamiento.InfoImagenPrecarga(bmpt, fotos(50 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 7
                objetoTratamiento.InfoImagenPrecarga(bmpt, fotos(60 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 8
                objetoTratamiento.InfoImagenPrecarga(bmpt, fotos(70 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 9
                objetoTratamiento.InfoImagenPrecarga(bmpt, fotos(80 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 10
                objetoTratamiento.InfoImagenPrecarga(bmpt, fotos(90 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 11
                objetoTratamiento.InfoImagenPrecarga(bmpt, fotos(100 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
            Case 12
                objetoTratamiento.InfoImagenPrecarga(bmpt, fotos(110 + contador)) 'Abrimos el vínculo de la imagen a tamaño completo en el PictureBox Principal
        End Select

    End Sub

    Private Sub AbrirFacebook_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        BackgroundWorker1.CancelAsync()
        BackgroundWorker2.CancelAsync()
    End Sub
    Private Sub AbrirFacebook_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        BackgroundWorker1.CancelAsync()
        BackgroundWorker2.CancelAsync()
    End Sub

End Class