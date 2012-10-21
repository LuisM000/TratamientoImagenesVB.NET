Imports System.Xml.XPath
Imports System.Net
Imports Newtonsoft.Json
Imports System.Text
Imports WindowsApplication1.Class2
Imports WindowsApplication1.Class1

Public Class facebook
    Dim contador As Integer
    Dim numAbrir As Integer
    Dim fotos As New ArrayList 'Contenedor de los enlaces

    Private Sub facebook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        urlFB = ""
        limpiarPic()
        For Each c As Object In Panel1.Controls
            If c.GetType Is GetType(PictureBox) Then
                AddHandler DirectCast(c, PictureBox).MouseEnter, AddressOf dentroP
                AddHandler DirectCast(c, PictureBox).MouseLeave, AddressOf fueraP

            End If
        Next
        If PictureBox1.Image Is Nothing Then
            numAbrir = 0
            fotos.Clear()
            Dim urlfacebook As New Uri("https://graph.facebook.com/oauth/authorize?type=user_agent&client_id=504262102918292&redirect_uri=http://www.facebook.com/connect/login_success.html&scope=user_photos")
            WebBrowser1.Url = urlfacebook
            Timer1.Enabled = True
            WebBrowser1.ScrollBarsEnabled = False
            contador = 0
            WebBrowser1.Visible = True
            PictureBox1.Visible = False
            PictureBox2.Visible = False
            PictureBox3.Visible = False
            PictureBox4.Visible = False
            PictureBox5.Visible = False
            PictureBox6.Visible = False
            PictureBox7.Visible = False
            PictureBox8.Visible = False
            PictureBox9.Visible = False
            PictureBox10.Visible = False
            PictureBox11.Visible = False
            PictureBox12.Visible = False
            Button1.Visible = False
            Button2.Visible = False
            Button3.Visible = False
            Panel1.Location = New Size(12, 352)
        End If
    End Sub

    Private Sub dentroP(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub fueraP(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
    End Sub

  


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If WebBrowser1.Url IsNot Nothing Then
            If WebBrowser1.Url.ToString.Contains("access_token") = True Then
                Timer1.Enabled = False
                mostrarImagenes()
            End If
        End If
    End Sub

    Sub mostrarImagenes()
        Dim objetoTra As New trataformu
        Dim objeto As New tratamiento
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

            Dim xml = objetoTra.JsonToXml(obj2.ToString)


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
            WebBrowser1.Visible = False
            Timer2.Enabled = True

            PictureBox1.Image = objeto.cargarrecursoweb(fotos(7 + contador))
            PictureBox2.Image = objeto.cargarrecursoweb(fotos(17 + contador))
            PictureBox3.Image = objeto.cargarrecursoweb(fotos(27 + contador))
            PictureBox4.Image = objeto.cargarrecursoweb(fotos(37 + contador))
            PictureBox5.Image = objeto.cargarrecursoweb(fotos(47 + contador))
            PictureBox6.Image = objeto.cargarrecursoweb(fotos(57 + contador))
            PictureBox7.Image = objeto.cargarrecursoweb(fotos(67 + contador))
            PictureBox8.Image = objeto.cargarrecursoweb(fotos(77 + contador))
            PictureBox9.Image = objeto.cargarrecursoweb(fotos(87 + contador))
            PictureBox10.Image = objeto.cargarrecursoweb(fotos(97 + contador))
            PictureBox11.Image = objeto.cargarrecursoweb(fotos(107 + contador))
            PictureBox12.Image = objeto.cargarrecursoweb(fotos(117 + contador))
            
        Catch ex As Exception
            Button1.Enabled = False
        End Try

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        contador += 60
        mostrarImagenes()

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        contador = 0
        mostrarImagenes()
        Button1.Enabled = True
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Panel1.Location.Y > 15 Then
            Panel1.Location = New Size(Panel1.Location.X, Panel1.Location.Y - 15)

        End If
    End Sub




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



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            If numAbrir <> 0 Then
                Select Case numAbrir
                    Case 1
                        urlFB = fotos(0 + contador)
                    Case 2
                        urlFB = fotos(10 + contador)
                    Case 3
                        urlFB = fotos(20 + contador)
                    Case 4
                        urlFB = fotos(30 + contador)
                    Case 5
                        urlFB = fotos(40 + contador)
                    Case 6
                        urlFB = fotos(50 + contador)
                    Case 7
                        urlFB = fotos(60 + contador)
                    Case 8
                        urlFB = fotos(70 + contador)
                    Case 9
                        urlFB = fotos(80 + contador)
                    Case 10
                        urlFB = fotos(90 + contador)
                    Case 11
                        urlFB = fotos(100 + contador)
                    Case 12
                        urlFB = fotos(110 + contador)
                End Select
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
End Class