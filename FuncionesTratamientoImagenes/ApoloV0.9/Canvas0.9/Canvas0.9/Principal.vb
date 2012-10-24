Imports WindowsApplication1.Class1
Imports WindowsApplication1.Class2
Imports System
Imports System.IO
Imports System.Collections
Imports System.Windows.Input
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class Principal
    Dim objeto As New tratamiento 'Objeto de la clase tratamiento
    Dim objetoform As New trataformu 'Objeto de la clase para formulario
    Dim bmp As Bitmap


    Private Sub Principal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) And tipoPuntero = "segmentacion" Then
            PictureBox1.Image = New Bitmap(bmpsegmentacion, anchoClonar, altoCLonar)
            RefrescarImagenToolStripMenuItem_Click(sender, e)
            tipoPuntero = "normal"

        End If
        If e.KeyChar = ChrW(Keys.Enter) And tipoPuntero = "RectanguloRecortar" Then
            If rectanguloRec.X <> 0 And rectanguloRec.Y <> 0 Then
                Dim bmp As New Bitmap(PictureBox1.Image)
                PictureBox1.Image = objetoform.RecortarImagen(bmp, rectanguloRec)
                PunteroToolStripMenuItem_Click(sender, e)
                rectanguloRec.Y = 0
                rectanguloRec.X = 0
            End If
        End If
        If e.KeyChar = "c" And tipoPuntero = "RectanguloRecortar" Then
            Dim bmp As New Bitmap(PictureBox1.Image)
            Dim bmp2 As Bitmap
            bmp2 = objetoform.RecortarImagen(bmp, rectanguloRec)
            Dim img As Image
            img = bmp2
            My.Computer.Clipboard.SetImage(img)
            rectanguloRec.Y = 0
            rectanguloRec.X = 0
        End If
        If e.KeyChar = ChrW(Keys.Escape) And tipoPuntero = "RectanguloRecortar" Then
            PunteroToolStripMenuItem_Click(sender, e)
            PictureBox1.Image = imagenAntesRec
            objetoform.refrescar(PictureBox1, Panel1)
            rectanguloRec.Y = 0
            rectanguloRec.X = 0
        End If

        If e.KeyChar = ChrW(Keys.Escape) Then
            If tipoPuntero = "clonar" Then
                Dim bmp As New Bitmap(PictureBox1.Image, anchoClonar, altoCLonar)
                PictureBox1.Image = bmp
                RefrescarImagenToolStripMenuItem_Click(sender, e)
                tipoPuntero = "normal"
            End If
            If tipoPuntero = "filtro" Then
                Dim bmp As New Bitmap(PictureBox1.Image, anchoClonar, altoCLonar)
                PictureBox1.Image = bmp
                RefrescarImagenToolStripMenuItem_Click(sender, e)
                tipoPuntero = "normal"
            End If
            If tipoPuntero = "filtroBN" Then
                Dim bmp As New Bitmap(PictureBox1.Image, anchoClonar, altoCLonar)
                PictureBox1.Image = bmp
                RefrescarImagenToolStripMenuItem_Click(sender, e)
                tipoPuntero = "normal"
                FiltroInicioBN = False
                originala = False
            End If
            If tipoPuntero = "clonarParcial" Then
                Dim bmp As New Bitmap(PictureBox1.Image, anchoClonar, altoCLonar)
                PictureBox1.Image = bmp
                RefrescarImagenToolStripMenuItem_Click(sender, e)
                tipoPuntero = "normal"
            End If
            If tipoPuntero = "borrar" Then
                Dim bmp As New Bitmap(PictureBox1.Image, anchoClonar, altoCLonar)
                PictureBox1.Image = bmp
                RefrescarImagenToolStripMenuItem_Click(sender, e)
                tipoPuntero = "normal"
            End If
            If e.KeyChar = ChrW(Keys.Escape) Then
                tipoPuntero = "normal"
                Me.Cursor = Windows.Forms.Cursors.Default
                FiltroInicio = False
            End If
            tipoPuntero = "normal"
            Me.Cursor = Windows.Forms.Cursors.Default
            FiltroInicio = False
        End If

        If e.KeyChar = ChrW(Keys.Space) And tipoPuntero = "filtroBN" Then
            If originala = True Then originala = False Else originala = True
        End If


        If e.KeyChar = "+" Then
            If tipoPuntero = "clonar" Then
                If My.Settings.AnchoClon < 30 Then My.Settings.AnchoClon = My.Settings.AnchoClon + 1
                If My.Settings.AltoClon < 30 Then My.Settings.AltoClon = My.Settings.AltoClon + 1
                ToolStripStatusLabel7.Text = "Ancho " & My.Settings.AnchoClon & " Alto " & My.Settings.AltoClon
            End If
            If tipoPuntero = "filtro" Then
                If My.Settings.AnchoFIltro < 30 Then My.Settings.AnchoFIltro = My.Settings.AnchoFIltro + 1
                If My.Settings.AltoFIltro < 30 Then My.Settings.AltoFIltro = My.Settings.AltoFIltro + 1
                ToolStripStatusLabel7.Text = "Ancho " & My.Settings.AnchoFIltro & " Alto " & My.Settings.AltoFIltro
            End If
            If tipoPuntero = "filtroBN" Then
                If My.Settings.AnchoFpar < 30 Then My.Settings.AnchoFpar = My.Settings.AnchoFpar + 1
                If My.Settings.AltoFpar < 30 Then My.Settings.AltoFpar = My.Settings.AltoFpar + 1
                ToolStripStatusLabel7.Text = "Ancho " & My.Settings.AnchoFpar & " Alto " & My.Settings.AltoFpar
            End If
            If tipoPuntero = "clonarParcial" Then
                If My.Settings.AnchoclonPar < 30 Then My.Settings.AnchoclonPar = My.Settings.AnchoclonPar + 1
                If My.Settings.AltoclonPar < 30 Then My.Settings.AltoclonPar = My.Settings.AltoclonPar + 1
                ToolStripStatusLabel7.Text = "Ancho " & My.Settings.AnchoclonPar & " Alto " & My.Settings.AltoclonPar
            End If
            If tipoPuntero = "borrar" Then
                If My.Settings.AnchoBorrar < 30 Then My.Settings.AnchoBorrar = My.Settings.AnchoBorrar + 1
                If My.Settings.AltoBorrar < 30 Then My.Settings.AltoBorrar = My.Settings.AltoBorrar + 1
                ToolStripStatusLabel7.Text = "Ancho " & My.Settings.AnchoBorrar & " Alto " & My.Settings.AltoBorrar
            End If
        End If

        If e.KeyChar = "-" Then
            If tipoPuntero = "clonar" Then
                If My.Settings.AnchoClon > 1 Then My.Settings.AnchoClon = My.Settings.AnchoClon - 1
                If My.Settings.AltoClon > 1 Then My.Settings.AltoClon = My.Settings.AltoClon - 1
                ToolStripStatusLabel7.Text = "Ancho " & My.Settings.AnchoClon & " Alto " & My.Settings.AltoClon
            End If
            If tipoPuntero = "filtro" Then
                If My.Settings.AnchoFIltro > 1 Then My.Settings.AnchoFIltro = My.Settings.AnchoFIltro - 1
                If My.Settings.AltoFIltro > 1 Then My.Settings.AltoFIltro = My.Settings.AltoFIltro - 1
                ToolStripStatusLabel7.Text = "Ancho " & My.Settings.AnchoFIltro & " Alto " & My.Settings.AltoFIltro
            End If
            If tipoPuntero = "filtroBN" Then
                If My.Settings.AnchoFpar > 1 Then My.Settings.AnchoFpar = My.Settings.AnchoFpar - 1
                If My.Settings.AltoFpar > 1 Then My.Settings.AltoFpar = My.Settings.AltoFpar - 1
                ToolStripStatusLabel7.Text = "Ancho " & My.Settings.AnchoFpar & " Alto " & My.Settings.AltoFpar
            End If
            If tipoPuntero = "clonarParcial" Then
                If My.Settings.AnchoclonPar > 1 Then My.Settings.AnchoclonPar = My.Settings.AnchoclonPar - 1
                If My.Settings.AltoclonPar > 1 Then My.Settings.AltoclonPar = My.Settings.AltoclonPar - 1
                ToolStripStatusLabel7.Text = "Ancho " & My.Settings.AnchoclonPar & " Alto " & My.Settings.AltoclonPar
            End If
            If tipoPuntero = "borrar" Then
                If My.Settings.AnchoBorrar > 1 Then My.Settings.AnchoBorrar = My.Settings.AnchoBorrar - 1
                If My.Settings.AltoBorrar > 1 Then My.Settings.AltoBorrar = My.Settings.AltoBorrar - 1
                ToolStripStatusLabel7.Text = "Ancho " & My.Settings.AnchoBorrar & " Alto " & My.Settings.AltoBorrar
            End If
        End If



    End Sub

    Sub Borde(ByVal borde As String)
        Select Case My.Settings.TipoBorde
            Case "none"
                SplitContainer1.BorderStyle = BorderStyle.None
            Case "single"
                SplitContainer1.BorderStyle = BorderStyle.FixedSingle
            Case "3d"
                SplitContainer1.BorderStyle = BorderStyle.Fixed3D
            Case Else
                SplitContainer1.BorderStyle = BorderStyle.None
        End Select
    End Sub

    '***********CARGAR FORMULARIO*****************************
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Abriendo.Show()
        Me.Visible = False
        PictureBox4.Height = Panel2.Height - 230
        PictureBox4.Location = New Point(Panel2.Width / 2 + 80, Panel2.Location.Y + (130))
        Label4.Location = New Point(PictureBox4.Location.X - 400, Panel2.Location.Y + (70))
        Label8.Location = New Point(PictureBox4.Location.X - 360, Panel2.Location.Y + 150)
        Label10.Location = New Point(PictureBox4.Location.X - 360, Panel2.Location.Y + 190)
        Label17.Location = New Point(PictureBox4.Location.X - 360, Panel2.Location.Y + 230)

        CheckBox1.Checked = My.Settings.Pantallapresentación
        CheckBox1.Location = New Point(PictureBox4.Location.X - 400, Panel2.Location.Y + (Panel2.Height - 120))
        TabControlModificado2.Height = Panel2.Height / 2.7
        TabControlModificado2.Width = Panel2.Width / 2.5
        PictureBox5.Location = New Point(Label8.Location.X - 40, Label8.Location.Y - 7)
        PictureBox6.Location = New Point(Label10.Location.X - 40, Label10.Location.Y - 7)
        PictureBox7.Location = New Point(Label4.Location.X, PictureBox4.Location.Y)
        PictureBox7.Width = 800
        PictureBox8.Location = New Point(Label17.Location.X + 125, Label17.Location.Y + 10)
        PictureBox9.Location = New Point(PictureBox6.Location.X, Label17.Location.Y + 10)
        PictureBox9.Width = PictureBox6.Width
        Dim ancho As Integer
        ancho = (PictureBox4.Location.X - Label17.Location.X) - 140
        PictureBox8.Width = ancho





        TabControlModificado2.Location = New Point(PictureBox4.Location.X + 30, Panel2.Location.Y + (Panel2.Height - TabControlModificado2.Height) - 100)
        Label5.ForeColor = Color.Black
        Label18.ForeColor = Color.Black
        Label6.ForeColor = Color.Black
        Label7.ForeColor = Color.Black
        Label9.ForeColor = Color.Black
        Label5.Location = New Point(PictureBox4.Location.X + 30, Panel2.Location.Y + 150)
        Label18.Location = New Point(PictureBox4.Location.X + 30, Panel2.Location.Y + 185)
        Label6.Location = New Point(PictureBox4.Location.X + 30, Panel2.Location.Y + 220)
        Label7.Location = New Point(PictureBox4.Location.X + 30, Panel2.Location.Y + 255)
        Label9.Location = New Point(PictureBox4.Location.X + 30, Panel2.Location.Y + 290)

        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)

        Label5.Font = fuente
        Label18.Font = fuente
        Label6.Font = fuente
        Label7.Font = fuente
        Label9.Font = fuente

        Label11.Location = New Point(PictureBox4.Location.X - 320, Panel2.Location.Y + 280)
        Label12.Location = New Point(PictureBox4.Location.X - 320, Panel2.Location.Y + 330)
        Label13.Location = New Point(PictureBox4.Location.X - 320, Panel2.Location.Y + 380)
        Label14.Location = New Point(PictureBox4.Location.X - 320, Panel2.Location.Y + 430)
        Label15.Location = New Point(PictureBox4.Location.X - 320, Panel2.Location.Y + 480)
        Label16.Location = New Point(PictureBox4.Location.X - 320, Panel2.Location.Y + 530)

        PictureBox10.Location = New Point(PictureBox4.Location.X - 370, Panel2.Location.Y + 270)
        PictureBox11.Location = New Point(PictureBox4.Location.X - 370, Panel2.Location.Y + 320)
        PictureBox12.Location = New Point(PictureBox4.Location.X - 370, Panel2.Location.Y + 370)
        PictureBox13.Location = New Point(PictureBox4.Location.X - 370, Panel2.Location.Y + 420)
        PictureBox14.Location = New Point(PictureBox4.Location.X - 370, Panel2.Location.Y + 470)
        PictureBox15.Location = New Point(PictureBox4.Location.X - 370, Panel2.Location.Y + 520)

        Dim folder As New DirectoryInfo("ImagenesRecientes\")
        Dim contador = 0
        Dim matriz(60) As String
        Dim matriz1(60) As String
        For Each file As FileInfo In folder.GetFiles()
            contador = contador + 1
        Next

        If contador > 50 Then
            contador = 0
            For Each file As FileInfo In folder.GetFiles()
                If contador > 5 Then
                    Try
                        Kill("ImagenesRecientes/" & file.Name)
                    Catch
                    End Try
                End If
                contador = contador + 1
            Next
        End If
        contador = 0
        For Each file As FileInfo In folder.GetFiles()
            matriz(contador) = file.Name
            contador = contador + 1
        Next

        For i = contador To 0 Step -1
            matriz1(contador - i) = matriz(i)
        Next
        contador = 0
        For i = 1 To UBound(matriz1)
            Select Case contador
                Case 0
                    Label11.Text = matriz1(i)
                    If Label11.Text = "Thumbs.db" Then Label11.Enabled = False : PictureBox15.Enabled = False
                    Try
                        Dim bmpLabel = Image.FromFile("ImagenesRecientes/" & Label11.Text)
                        PictureBox10.Image = bmpLabel
                    Catch
                    End Try
                Case 1
                    Label12.Text = matriz1(i)
                    Try
                        Dim bmpLabel = Image.FromFile("ImagenesRecientes/" & Label12.Text)
                        PictureBox11.Image = bmpLabel
                    Catch
                    End Try
                Case 2
                    Label13.Text = matriz1(i)
                    Try
                        Dim bmpLabel = Image.FromFile("ImagenesRecientes/" & Label13.Text)
                        PictureBox12.Image = bmpLabel
                    Catch
                    End Try
                Case 3
                    Label14.Text = matriz1(i)
                    Try
                        Dim bmpLabel = Image.FromFile("ImagenesRecientes/" & Label14.Text)
                        PictureBox13.Image = bmpLabel
                    Catch
                    End Try
                Case 4
                    Label15.Text = matriz1(i)
                    Try
                        Dim bmpLabel = Image.FromFile("ImagenesRecientes/" & Label15.Text)
                        PictureBox14.Image = bmpLabel
                    Catch
                    End Try
                Case 5
                    Label16.Text = matriz1(i)
                    Try
                        Dim bmpLabel = Image.FromFile("ImagenesRecientes/" & Label16.Text)
                        PictureBox15.Image = bmpLabel
                    Catch
                    End Try
            End Select
            contador = contador + 1
        Next
        Dim Random As New Random()
        Dim numero As Integer
        numero = Random.Next(1, 11)
        Try
            RichTextBox1.LoadFile("Sugerencia\" & numero & ".rtf", RichTextBoxStreamType.RichText)
        Catch ex As Exception
        End Try



        If My.Settings.BarraLateral = True Then
            SplitContainer1.Panel1Collapsed = False
        Else
            SplitContainer1.Panel1Collapsed = True
        End If
        Borde(My.Settings.TipoBorde)
        Timer1.Enabled = True
        Me.Visible = False
        SplitContainer1.SplitterDistance = 165
        ToolStripStatusLabel4.Text = "Apolo versión 0.9"
        ToolStripStatusLabel5.Text = "Sin imagen cargada"
        ToolStripStatusLabel7.Text = ""
        Application.EnableVisualStyles()
        'Los puntos son caracteres de separación decimal
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

        'Nombre formulario
        Me.Text = "Apolo v0.9"
        'Cargar logo
        Dim bmp As New Bitmap("logo_300.jpg")
        Dim bmp2 As New Bitmap(bmp, New Size(PictureBox1.Width / 2, PictureBox1.Height))
        PictureBox1.Image = objeto.aumentarbrillo(bmp, 0)
        PictureBox1.Image = bmp2
        escala = 1
        copiaimagenZoom = bmp2.Clone
        Dim alto = Me.Height
        PictureBox2.Location = New Point(10, alto - 250)
        Label1.Location = New Point(38, alto - 272)
        Label2.Location = New Point(0, alto - 290)
        Label3.Location = New Point(0, alto - 100)
        PictureBox1.BackColor = My.Settings.ColorPanel
        Me.Visible = True

        If My.Settings.actualizacion = True Then
            Abriendo.Text = "Buscando actualizaciones"
            Abriendo.ShowInTaskbar = False
            Abriendo.BringToFront()
            If objetoform.conexionInternet = True Then
                Abriendo.Close()
                objetoform.actualizacioninicio()
            End If
        End If

        If My.Settings.Pantallapresentación = False Then
            Panel2.Visible = False
        End If
        Me.Visible = True
        Abriendo.Close()

    End Sub



    Private Sub ImagenOriginalToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagenOriginalToolStripMenuItem1.Click
        ImagenOriginalToolStripMenuItem2_Click(sender, e)
    End Sub

    Private Sub ZoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomToolStripMenuItem.Click
        SsssToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ZoomToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomToolStripMenuItem1.Click
        ZoomToolStripMenuItem2_Click(sender, e)
    End Sub

    Private Sub DeshacerZoomToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeshacerZoomToolStripMenuItem1.Click
        DeshacerZoomToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub PropiedadesDeLaImagenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesDeLaImagenToolStripMenuItem1.Click
        PropiedadesDeLaImagenToolStripMenuItem3_Click(sender, e)
    End Sub


    Private Sub AbrirToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirToolStripMenuItem1.Click
        AbrirToolStripMenuItem2_Click(sender, e)
    End Sub
    Private Sub AbrirRecursoWebToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirRecursoWebToolStripMenuItem1.Click
        AbrirRecursoWebToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub BuscarImágenesToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BuscarImágenesToolStripMenuItem1.Click
        BuscarImágenesToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub BuscarImágenesEnFacebookToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BuscarImágenesEnFacebookToolStripMenuItem1.Click
        BuscarImágenesEnFacebookToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub GuardarComoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarComoToolStripMenuItem1.Click
        GuardarToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub AtrásToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtrásToolStripMenuItem1.Click
        AtrásToolStripMenuItem2_Click(sender, e)
    End Sub

    Private Sub AjustarAPantallaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjustarAPantallaToolStripMenuItem.Click
        AjustarAPantallaToolStripMenuItem1_Click(sender, e)
    End Sub
    Private Sub RefrescarImagenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefrescarImagenToolStripMenuItem1.Click
        RefrescarImagenToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub AbrirToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirToolStripMenuItem2.Click
        PictureBox1.Image = objeto.abirImagen() 'Abrimos imagen y al PictureBox
        objetoform.refrescar(PictureBox1, Panel1) 'Refrescamos Picture y Panel
        ToolStripStatusLabel5.Text = objeto.nombreImagen() 'nombre al Status
        Me.Text = objeto.nombreImagen 'nombre al formulario
        copiaimagenZoom = PictureBox1.Image.Clone
        escala = 1
        Panel2.Visible = False
    End Sub
    Private Sub ImagenPngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagenPngToolStripMenuItem.Click
        objeto.guardarcomo(PictureBox1.Image, 4) 'Guardamos imagen
    End Sub

    Private Sub ImagenJpgToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagenJpgToolStripMenuItem.Click
        objeto.guardarcomo(PictureBox1.Image, 3) 'Guardamos imagen
    End Sub

    Private Sub ImagenBmpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagenBmpToolStripMenuItem.Click
        objeto.guardarcomo(PictureBox1.Image, 1) 'Guardamos imagen
    End Sub

    Private Sub ImagenGIFToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagenGIFToolStripMenuItem.Click
        objeto.guardarcomo(PictureBox1.Image, 2) 'Guardamos imagen
    End Sub

    Private Sub OtrosFormatosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OtrosFormatosToolStripMenuItem.Click
        objeto.guardarcomo(PictureBox1.Image, 4) 'Guardamos imagen
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarToolStripMenuItem.Click
        objeto.guardarcomo(PictureBox1.Image) 'Guardamos imagen
    End Sub

    Private Sub SalirToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem1.Click
        If My.Settings.salir = True Then
            bmpGuardar = PictureBox1.Image
            Dim bmp As New Bitmap(PictureBox1.Image)
            objetoform.GuardarSalir(bmp)
            objetoform.salir() 'Salir
        Else
            End
        End If
    End Sub
    Private Sub Principal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If My.Settings.salir = True Then
            bmpGuardar = PictureBox1.Image
            Dim respuesta As DialogResult = MessageBox.Show("¿Desea guardar la imagen antes de salir?", "Apolo v 0.9", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Select Case respuesta
                Case Windows.Forms.DialogResult.Yes
                    objeto.guardarcomo(bmpGuardar)
                    End
                Case Windows.Forms.DialogResult.No
                    Try
                        Dim bmp As New Bitmap(PictureBox1.Image)
                        objetoform.GuardarSalir(bmp)
                        End
                    Catch
                        End
                    End Try

                Case Windows.Forms.DialogResult.Cancel
                    e.Cancel = True

            End Select
        Else
            End
        End If

    End Sub

    Private Sub AtrásToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AtrásToolStripMenuItem2.Click
        PictureBox1.Image = objeto.undo()
    End Sub

    Private Sub AjustarAPantallaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjustarAPantallaToolStripMenuItem1.Click
        objetoform.ajustarpantalla(PictureBox1, Panel1)
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub
    Private Sub RefrescarImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefrescarImagenToolStripMenuItem.Click
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub VolteadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VolteadoToolStripMenuItem.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Rotar.ShowDialog() 'Lanzamos nueva ventana
        If Rotar.DialogResult = Windows.Forms.DialogResult.OK Then 'Si el usuario acepta
            Cargando.Show()
            For Each elemento In Rotar.ListBox2.Items
                rotacion(elemento)
            Next
            Cargando.Close()
        End If
    End Sub
    Sub rotacion(ByVal rota As String)
        Select Case rota
            Case "RotateNoneFlipNone"
                PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipNone)
            Case "Rotate90FlipNone"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
            Case "Rotate180FlipNone"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
            Case "Rotate270FlipNone"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipNone)
            Case "RotateNoneFlipX"
                PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX)
            Case "Rotate90FlipX"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipX)
            Case "Rotate180FlipX"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipX)
            Case "Rotate270FlipX"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipX)
            Case "RotateNoneFlipY"
                PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Case "Rotate90FlipY"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipY)
            Case "Rotate180FlipY"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipY)
            Case "Rotate270FlipY"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipY)
            Case "RotateNoneFlipXY"
                PictureBox1.Image.RotateFlip(RotateFlipType.RotateNoneFlipXY)
            Case "Rotate90FlipXY"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipXY)
            Case "Rotate180FlipXY"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate180FlipXY)
            Case "Rotate270FlipXY"
                PictureBox1.Image.RotateFlip(RotateFlipType.Rotate270FlipXY)
        End Select
        PictureBox1.Refresh()
    End Sub


    Private Sub AutomáticoToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutomáticoToolStripMenuItem2.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.blanconegro(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.blanconegro(bmp)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.blanconegro(bmp)
            Cargando.Close()
        End If

    End Sub


    Private Sub ManualToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualToolStripMenuItem2.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        BlancoNegroM.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.blanconegro(bmp, valorumbral)
            Cargando.Close()
        End If
        aceptar = False
    End Sub

    Private Sub EscalaDeGrisesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EscalaDeGrisesToolStripMenuItem1.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "grises")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem25_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem25.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "etiopia")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem25_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem25.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "etiopiaV")
        PictureBox1.Refresh()
    End Sub


    Private Sub AumentarDisminuirBrilloToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AumentarDisminuirBrilloToolStripMenuItem1.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Brillo.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            If valorumbral >= 0 Then
                PictureBox1.Image = objeto.aumentarbrillo(bmp, valorumbral)
            Else
                PictureBox1.Image = objeto.disminuirbrillo(bmp, -valorumbral)
            End If
            Cargando.Close()
        End If
        aceptar = False
    End Sub

    Private Sub RojoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RojoToolStripMenuItem1.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "filtro rojo")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerdeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerdeToolStripMenuItem1.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "filtro verde")
        PictureBox1.Refresh()
    End Sub

    Private Sub AzulToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AzulToolStripMenuItem1.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "filtro azul")
        PictureBox1.Refresh()
    End Sub

    Private Sub BGRToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGRToolStripMenuItem1.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "BGR")
        PictureBox1.Refresh()
    End Sub

    Private Sub GRBToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRBToolStripMenuItem1.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "GRB")
        PictureBox1.Refresh()
    End Sub

    Private Sub RBGToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGToolStripMenuItem1.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "RBG")
        PictureBox1.Refresh()
    End Sub

    Private Sub DefectoToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefectoToolStripMenuItem5.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "2defecto")
        PictureBox1.Refresh()
    End Sub

    Private Sub ExcesoToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcesoToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "2exceso")
        PictureBox1.Refresh()
    End Sub

    Private Sub DefectoToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefectoToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "4defecto")
        PictureBox1.Refresh()
    End Sub

    Private Sub ExcesoToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcesoToolStripMenuItem5.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "4exceso")
        PictureBox1.Refresh()
    End Sub

    Private Sub DefectoToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefectoToolStripMenuItem7.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "8defecto")
        PictureBox1.Refresh()
    End Sub

    Private Sub ExcesoToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcesoToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "8exceso")
        PictureBox1.Refresh()
    End Sub

    Private Sub DefectoToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DefectoToolStripMenuItem8.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "16exceso")
        PictureBox1.Refresh()
    End Sub

    Private Sub ExcesoToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExcesoToolStripMenuItem7.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "16exceso")
        PictureBox1.Refresh()
    End Sub

    Private Sub Coeficiente9ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coeficiente9ToolStripMenuItem.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LOW9")
        PictureBox1.Refresh()
    End Sub

    Private Sub Coeficiente10ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coeficiente10ToolStripMenuItem1.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LOW10")
        PictureBox1.Refresh()
    End Sub

    Private Sub Coeficiente12ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coeficiente12ToolStripMenuItem.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LOW12")
        PictureBox1.Refresh()
    End Sub

    Private Sub Coeficiente9ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coeficiente9ToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LOW9g")
        PictureBox1.Refresh()
    End Sub

    Private Sub Coeficiente10ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coeficiente10ToolStripMenuItem2.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LOW10g")
        PictureBox1.Refresh()
    End Sub

    Private Sub Coeficiente12ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coeficiente12ToolStripMenuItem3.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LOW12g")
        PictureBox1.Refresh()
    End Sub

    Private Sub Coeficiente1ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coeficiente1ToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "HIG1a")
        PictureBox1.Refresh()
    End Sub

    Private Sub Coeficiente1ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coeficiente1ToolStripMenuItem5.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "HIG1b")
        PictureBox1.Refresh()
    End Sub

    Private Sub Coeficiente16ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coeficiente16ToolStripMenuItem2.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "HIG16")
        PictureBox1.Refresh()
    End Sub

    Private Sub Coeficiente1ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coeficiente1ToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "HIG1ag")
        PictureBox1.Refresh()
    End Sub

    Private Sub Coeficiente1ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coeficiente1ToolStripMenuItem7.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "HIG1bg")
        PictureBox1.Refresh()
    End Sub

    Private Sub Coeficiente16ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Coeficiente16ToolStripMenuItem3.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "HIG16g")
        PictureBox1.Refresh()
    End Sub



    Private Sub Resta1ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Resta1ToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "REST1")
        PictureBox1.Refresh()
    End Sub

    Private Sub Resta2ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Resta2ToolStripMenuItem3.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "REST2")
        PictureBox1.Refresh()
    End Sub

    Private Sub Resta3ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Resta3ToolStripMenuItem3.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "REST3")
        PictureBox1.Refresh()
    End Sub

    Private Sub Resta1ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Resta1ToolStripMenuItem7.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "REST1G")
        PictureBox1.Refresh()
    End Sub

    Private Sub Resta2ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Resta2ToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "REST2G")
        PictureBox1.Refresh()
    End Sub

    Private Sub Resta3ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Resta3ToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "REST3G")
        PictureBox1.Refresh()
    End Sub

    Private Sub Laplaciano1ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Laplaciano1ToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAP1")
        PictureBox1.Refresh()
    End Sub

    Private Sub Laplaciano1ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Laplaciano1ToolStripMenuItem7.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAP2")
        PictureBox1.Refresh()
    End Sub

    Private Sub Laplaciano1ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Laplaciano1ToolStripMenuItem8.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAP3")
        PictureBox1.Refresh()
    End Sub

    Private Sub Laplaciano1ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Laplaciano1ToolStripMenuItem9.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAP4")
        PictureBox1.Refresh()
    End Sub

    Private Sub Laplaciano1ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Laplaciano1ToolStripMenuItem10.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAP1g")
        PictureBox1.Refresh()
    End Sub

    Private Sub Laplaciano2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Laplaciano2ToolStripMenuItem.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAP2g")
        PictureBox1.Refresh()
    End Sub

    Private Sub Laplaciano3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Laplaciano3ToolStripMenuItem.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAP3g")
        PictureBox1.Refresh()
    End Sub

    Private Sub Laplaciano4ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Laplaciano4ToolStripMenuItem2.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAP4g")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem13.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAPV")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem13.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAPH")
        PictureBox1.Refresh()
    End Sub

    Private Sub DiagonalToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiagonalToolStripMenuItem2.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAPD")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem14.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAPVg")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem14.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAPHg")
        PictureBox1.Refresh()
    End Sub

    Private Sub DiagonalToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiagonalToolStripMenuItem3.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LAPDg")
        PictureBox1.Refresh()
    End Sub

    Private Sub EsteToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EsteToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Geste")
        PictureBox1.Refresh()
    End Sub

    Private Sub SudesteToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SudesteToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Gsud")
        PictureBox1.Refresh()
    End Sub

    Private Sub SurToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SurToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Gsur")
        PictureBox1.Refresh()
    End Sub

    Private Sub OesteToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OesteToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Goeste")
        PictureBox1.Refresh()
    End Sub

    Private Sub NoresteToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoresteToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Gnore")
        PictureBox1.Refresh()
    End Sub

    Private Sub NorteToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NorteToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Gnor")
        PictureBox1.Refresh()
    End Sub

    Private Sub EsteToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EsteToolStripMenuItem5.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Gesteg")
        PictureBox1.Refresh()
    End Sub

    Private Sub SudesteToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SudesteToolStripMenuItem5.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Gsudg")
        PictureBox1.Refresh()
    End Sub

    Private Sub SurToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SurToolStripMenuItem5.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Gsurg")
        PictureBox1.Refresh()
    End Sub

    Private Sub OesteToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OesteToolStripMenuItem5.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Goesteg")
        PictureBox1.Refresh()
    End Sub

    Private Sub NoresteToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoresteToolStripMenuItem5.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Gnoreg")
        PictureBox1.Refresh()
    End Sub

    Private Sub NorteToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NorteToolStripMenuItem5.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Gnorg")
        PictureBox1.Refresh()
    End Sub

    Private Sub EsteToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EsteToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Eeste")
        PictureBox1.Refresh()
    End Sub

    Private Sub SudesteToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SudesteToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Esud")
        PictureBox1.Refresh()
    End Sub

    Private Sub SurToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SurToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Esur")
        PictureBox1.Refresh()
    End Sub

    Private Sub OesteToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OesteToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Eoeste")
        PictureBox1.Refresh()
    End Sub

    Private Sub NoresteToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoresteToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Enore")
        PictureBox1.Refresh()
    End Sub

    Private Sub NorteToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NorteToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Enor")
        PictureBox1.Refresh()
    End Sub

    Private Sub EsteToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EsteToolStripMenuItem7.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Eesteg")
        PictureBox1.Refresh()
    End Sub

    Private Sub SudesteToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SudesteToolStripMenuItem7.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Esudg")
        PictureBox1.Refresh()
    End Sub

    Private Sub SurToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SurToolStripMenuItem7.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Esurg")
        PictureBox1.Refresh()
    End Sub

    Private Sub OesteToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OesteToolStripMenuItem7.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Eoesteg")
        PictureBox1.Refresh()
    End Sub

    Private Sub NoresteToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoresteToolStripMenuItem7.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Enoreg")
        PictureBox1.Refresh()
    End Sub

    Private Sub NorteToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NorteToolStripMenuItem7.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Enorg")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem15.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelH")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem15.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelV")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal1ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal1ToolStripMenuItem8.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelD1")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal2ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal2ToolStripMenuItem8.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelD2")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem16.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelHg")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem16.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelVg")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal1ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal1ToolStripMenuItem9.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelD1g")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal2ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal2ToolStripMenuItem9.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelD2g")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem17.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelH2")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem17.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelV2")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal1ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal1ToolStripMenuItem10.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelD12")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal2ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal2ToolStripMenuItem10.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelD22")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem18.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelHg2")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem18.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelVg2")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal1ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal1ToolStripMenuItem11.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelD1g2")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal2ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal2ToolStripMenuItem11.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "SobelD2g2")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem19.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHH")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem19.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHV")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal1ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal1ToolStripMenuItem12.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHD1")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal2ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal2ToolStripMenuItem12.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHD2")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem20.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHHG")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem20.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHVG")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal1ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal1ToolStripMenuItem13.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHD1G")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal2ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal2ToolStripMenuItem13.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHD2G")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem21.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHH2")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem21.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHV2")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal1ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal1ToolStripMenuItem14.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHD12")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal2ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal2ToolStripMenuItem14.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHD22")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem22.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHH2g")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem22.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHV2g")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal1ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal1ToolStripMenuItem15.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHD12g")
        PictureBox1.Refresh()
    End Sub

    Private Sub Diagonal2ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Diagonal2ToolStripMenuItem15.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "PHD22g")
        PictureBox1.Refresh()
    End Sub

    Private Sub RGBToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGBToolStripMenuItem11.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LH")
        PictureBox1.Refresh()
    End Sub

    Private Sub GrisesToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrisesToolStripMenuItem10.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LHg")
        PictureBox1.Refresh()
    End Sub

    Private Sub RGBToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGBToolStripMenuItem12.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LV")
        PictureBox1.Refresh()
    End Sub

    Private Sub GrisesToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrisesToolStripMenuItem11.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "LVg")
        PictureBox1.Refresh()
    End Sub

    Private Sub RGBToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGBToolStripMenuItem13.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Repujado")
        PictureBox1.Refresh()
    End Sub

    Private Sub GrisesToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrisesToolStripMenuItem12.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "Repujadog")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem16.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR0")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem17.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR45")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem18.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR90")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem19.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR135")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem20.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR180")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem21.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR225")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem22.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR270")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem23.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR315")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem24.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR0g")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem25.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR45g")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem26.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR90g")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem27.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR135g")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem28.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR180g")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem29.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR225g")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem30.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR270g")
        PictureBox1.Refresh()
    End Sub

    Private Sub ºToolStripMenuItem31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ºToolStripMenuItem31.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "KIR315g")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem23.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "FRH")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem23.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "FRV")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem24.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "FRHg")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerticalToolStripMenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem24.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "FRHg")
        PictureBox1.Refresh()
    End Sub



    Private Sub AutomáticoToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutomáticoToolStripMenuItem3.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "conto")
        PictureBox1.Refresh()
    End Sub

    Private Sub ManualToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualToolStripMenuItem3.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Contornos.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.contornos(bmp, valorumbral, rojo, verde, azul)
            Cargando.Close()
        End If
        aceptar = False
    End Sub



    Private Sub AbrirRecursoWebToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirRecursoWebToolStripMenuItem.Click
        Recurso.ShowDialog()
        If imagenRecurso IsNot Nothing Then
            PictureBox1.Image = imagenRecurso
            copiaimagenZoom = PictureBox1.Image.Clone
            escala = 1
        End If
        Panel2.Visible = False
        RefrescarImagenToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub BuscarImágenesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarImágenesToolStripMenuItem.Click
        BuscarIMagenesBing.ShowDialog()
        If url <> "" Or IMGBing IsNot Nothing Then
            If url <> "" Then
                Dim objeto As New tratamiento
                PictureBox1.Image = objeto.cargarrecursoweb(url)
                copiaimagenZoom = PictureBox1.Image.Clone
                escala = 1
            Else
                Dim objeto As New tratamiento
                PictureBox1.Image = IMGBing
                copiaimagenZoom = PictureBox1.Image.Clone
                escala = 1
            End If
            Panel2.Visible = False
            RefrescarImagenToolStripMenuItem_Click(sender, e)
        End If
    End Sub

    Private Sub BuscarImágenesEnFacebookToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarImágenesEnFacebookToolStripMenuItem.Click
        facebook.ShowDialog()
        If urlFB <> "" Then
            PictureBox1.Image = objeto.cargarrecursoweb(urlFB)
            copiaimagenZoom = PictureBox1.Image.Clone
            escala = 1
        End If
        Panel2.Visible = False
        RefrescarImagenToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ConfiguraciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciónToolStripMenuItem1.Click
        configu.ShowDialog()
        PictureBox1.BackColor = My.Settings.ColorPanel
        SplitContainer1.Panel1Collapsed = Not (My.Settings.BarraLateral)
        Borde(My.Settings.TipoBorde)
    End Sub
    Private Sub ConfiguraciónRápidaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConfiguraciónRápidaToolStripMenuItem.Click
        ConfPaso1.ShowDialog()
        PictureBox1.BackColor = My.Settings.ColorPanel
        SplitContainer1.Panel1Collapsed = Not (My.Settings.BarraLateral)
        Borde(My.Settings.TipoBorde)
    End Sub

    Private Sub FiltroÚnicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FiltroÚnicoToolStripMenuItem.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Filtro.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.filtro(bmp, rojof, rojofs, verdef, verdefs, azulf, azulfs)
            Cargando.Close()
        End If
        aceptar = False
    End Sub


    Private Sub FiltroRangoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FiltroRangoToolStripMenuItem.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Filtrorango.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.filtroRangoRed(bmp, rojoIn, rojoSup, rojosal)
            PictureBox1.Image = objeto.filtroRangoGreen(bmp, verdeIn, verdeSup, verdesal)
            PictureBox1.Image = objeto.filtroRangoBlue(bmp, azulIn, azulSup, azulsal)
            Cargando.Close()
        End If
        aceptar = False
    End Sub

    Private Sub RGBToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGBToolStripMenuItem17.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "invertir")
        PictureBox1.Refresh()
    End Sub

    Private Sub RojoToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RojoToolStripMenuItem2.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "invertirrojo")
        PictureBox1.Refresh()
    End Sub

    Private Sub VerdeToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerdeToolStripMenuItem2.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "invertirverde")
        PictureBox1.Refresh()
    End Sub

    Private Sub AzulToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AzulToolStripMenuItem2.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "invertirazul")
        PictureBox1.Refresh()
    End Sub

    Private Sub HorizontalToolStripMenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem26.Click
        bmp = PictureBox1.Image
        Dim desenfoque As Short
        Dim mensaje As String
        'Parámetros
        mensaje = (InputBox("Introduzca el número de píxeles a desenfocar", , 0))

        If Not IsNumeric(mensaje) Then
            MessageBox.Show("Por favor, introduzca un valor correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Exit Sub
        Else
            desenfoque = CShort(mensaje)
            If My.Settings.vistapr = True Then
                Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
                Dim ratioH As Integer
                ratioH = bmp.Width / bmpaux.Width
                If ratioH = 0 Then MessageBox.Show("Por favor, desactive la vista previa desde el menú Herramientas/configuración para poder realizar la acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
                VistaPrevia.PictureBox1.Image = objeto.desenfoqueHorizontal(bmpaux, desenfoque / ratioH) 'Lazamos vista previa y asignamos imagen
                VistaPrevia.ShowDialog()
            End If
        End If
        If aceptar = True Or My.Settings.vistapr = False Then 'Si el usuario acepta
            Cargando.Show()
            Me.PictureBox1.Image = objeto.desenfoqueHorizontal(bmp, desenfoque) 'Lazamos vista previa y asignamos imagen
            Cargando.Close()
        End If
        aceptar = False
        objetoform.refrescar(PictureBox1, Panel1) 'Refrescamos Picture y Panel
    End Sub

    Private Sub VerticalToolStripMenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem26.Click
        bmp = PictureBox1.Image
        Dim desenfoque As Short
        Dim mensaje As String
        'Parámetros
        mensaje = (InputBox("Introduzca el número de píxeles a desenfocar", , 0))

        If Not IsNumeric(mensaje) Then
            MessageBox.Show("Por favor, introduzca un valor correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            desenfoque = CShort(mensaje)
            If My.Settings.vistapr = True Then
                Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
                Dim ratioV As Integer
                ratioV = bmp.Height / bmpaux.Height
                If ratioV = 0 Then MessageBox.Show("Por favor, desactive la vista previa desde el menú Herramientas/configuración para poder realizar la acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
                VistaPrevia.PictureBox1.Image = objeto.desenfoqueVertical(bmpaux, desenfoque / ratioV) 'Lazamos vista previa y asignamos imagen
                VistaPrevia.ShowDialog()
            End If
        End If
        If aceptar = True Or My.Settings.vistapr = False Then 'Si el usuario acepta
            Cargando.Show()
            Me.PictureBox1.Image = objeto.desenfoqueVertical(bmp, desenfoque) 'Lazamos vista previa y asignamos imagen
            Cargando.Close()
        End If
        aceptar = False
        objetoform.refrescar(PictureBox1, Panel1) 'Refrescamos Picture y Panel
    End Sub

    Private Sub HorizontaverticalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontaverticalToolStripMenuItem.Click
        bmp = PictureBox1.Image
        Dim desenfoque, desenfoque2 As Short
        Dim mensaje, mensaje2 As String
        'Parámetros
        mensaje = (InputBox("Introduzca el número de píxeles a desenfocar horizontal", , 0))
        mensaje2 = (InputBox("Introduzca el número de píxeles a desenfocar vertical", , 0))

        If Not (IsNumeric(mensaje) And IsNumeric(mensaje2)) Then
            MessageBox.Show("Por favor, introduzca un valor correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        Else
            desenfoque = CShort(mensaje)
            desenfoque2 = CShort(mensaje2)
            If My.Settings.vistapr = True Then
                Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
                Dim ratioH, ratioV As Integer
                ratioH = bmp.Width / bmpaux.Width
                ratioV = bmp.Height / bmpaux.Height
                If ratioV = 0 Then MessageBox.Show("Por favor, desactive la vista previa desde el menú Herramientas/configuración para poder realizar la acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub
                If ratioH = 0 Then MessageBox.Show("Por favor, desactive la vista previa desde el menú Herramientas/configuración para poder realizar la acción", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Exit Sub

                VistaPrevia.PictureBox1.Image = objeto.desenfoqueHorVert(bmpaux, desenfoque / ratioH, desenfoque2 / ratioV) 'Lazamos vista previa y asignamos imagen
                VistaPrevia.ShowDialog()
            End If
        End If
        If aceptar = True Or My.Settings.vistapr = False Then 'Si el usuario acepta
            Cargando.Show()
            Me.PictureBox1.Image = objeto.desenfoqueHorVert(bmp, desenfoque, desenfoque2) 'Lazamos vista previa y asignamos imagen
            Cargando.Close()
        End If
        aceptar = False
        objetoform.refrescar(PictureBox1, Panel1) 'Refrescamos Picture y Panel
    End Sub

    Private Sub CuadrículaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadrículaToolStripMenuItem2.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Cuadricula.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            Dim hilo As Threading.Thread
            hilo = PictureBox1.Image = objeto.cuadriculaColor(bmp, colorh, colorv, valorH, valorV)
            Cargando.Close()
        End If
        aceptar = False
    End Sub

    Private Sub UnirImágenesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnirImágenesToolStripMenuItem.Click
        Dim bmp As New Bitmap(Me.PictureBox1.Image, Unir.PictureBox1.Width, Unir.PictureBox1.Height)
        Unir.PictureBox1.Image = bmp
        bmpunir1 = PictureBox1.Image
        Unir.ShowDialog()
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.unir(bmpunir1, bmpunir2)
            Cargando.Close()
        End If
        aceptar = False
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub SepiaToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SepiaToolStripMenuItem2.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "sepia")
        PictureBox1.Refresh()
    End Sub

    Private Sub SepiaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SepiaToolStripMenuItem1.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "sepia")
        PictureBox1.Refresh()
    End Sub

    Private Sub RGBToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RGBToolStripMenuItem18.Click
        formucolores = True
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Reducircolores.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.reducircolores(bmp, valorcolor)
            Cargando.Close()
        End If
        aceptar = False
    End Sub

    Private Sub GrisesToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrisesToolStripMenuItem16.Click
        formucolores = False
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Reducircolores.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.reducircoloresgris(bmp, valorcolor)
            Cargando.Close()
        End If
        aceptar = False
    End Sub

    Private Sub AutomáticoToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutomáticoToolStripMenuItem5.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "ruido")
        PictureBox1.Refresh()
    End Sub

    Private Sub AleatorioToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AleatorioToolStripMenuItem1.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "ruidoaleatorio")
        PictureBox1.Refresh()

    End Sub

    Private Sub ManualToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualToolStripMenuItem5.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        ruido.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.ruido(bmp, valoraleat, rojoaleatorio, verdealeatorio, azulaleatorio)
            Cargando.Close()
        End If
        aceptar = False
    End Sub



    Private Sub PropiedadesDeLaImagenToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesDeLaImagenToolStripMenuItem3.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        Dim propiedades(5) As String
        propiedades = objeto.PropiedadesBitmap(bmp)
        propiedades(0) = objeto.nombreImagen()

        PropiedadesImagen.Label12.Text = propiedades(0)
        PropiedadesImagen.Label13.Text = propiedades(1)
        PropiedadesImagen.Label14.Text = propiedades(2)
        PropiedadesImagen.Label15.Text = propiedades(3)
        PropiedadesImagen.Label16.Text = propiedades(4)
        PropiedadesImagen.Label17.Text = propiedades(5)
        PropiedadesImagen.ShowDialog()
    End Sub

    Private Sub TiposDeMáscarasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TiposDeMáscarasToolStripMenuItem.Click
        Mascaras.ShowDialog()
    End Sub

    Private Sub AnchoToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnchoToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.reducirX2bitmap(bmpaux, True, False) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.reducirX2bitmap(bmp, True, False)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.reducirX2bitmap(bmp, True, False)
            Cargando.Close()
        End If
    End Sub

    Private Sub AltoToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltoToolStripMenuItem6.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.reducirX2bitmap(bmpaux, False, True) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.reducirX2bitmap(bmp, False, True)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.reducirX2bitmap(bmp, False, True)
            Cargando.Close()
        End If
    End Sub

    Private Sub AmbosToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmbosToolStripMenuItem5.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.reducirX2bitmap(bmpaux, True, True) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.reducirX2bitmap(bmp, True, True)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.reducirX2bitmap(bmp, True, True)
            Cargando.Close()
        End If
    End Sub

    Private Sub AnchoToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnchoToolStripMenuItem7.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.reducirX2interpolado(bmpaux, True, False)  'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
        End If
        If aceptar = True Or My.Settings.vistapr = False Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.reducirX2interpolado(bmp, True, False) 'Lazamos vista previa y asignamos imagen
            Cargando.Close()
        End If

        aceptar = False
    End Sub

    Private Sub AltoToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltoToolStripMenuItem7.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.reducirX2interpolado(bmpaux, False, True)  'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
        End If
        If aceptar = True Or My.Settings.vistapr = False Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.reducirX2interpolado(bmp, False, True) 'Lazamos vista previa y asignamos imagen
            Cargando.Close()
        End If

        aceptar = False
    End Sub

    Private Sub AmbosToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmbosToolStripMenuItem6.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.reducirX2interpolado(bmpaux, True, True)  'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
        End If
        If aceptar = True Or My.Settings.vistapr = False Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.reducirX2interpolado(bmp, True, True) 'Lazamos vista previa y asignamos imagen
            Cargando.Close()
        End If

        aceptar = False
    End Sub

    Private Sub AltoToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltoToolStripMenuItem8.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.aumentarX2bitmap(bmpaux, True, False) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.aumentarX2bitmap(bmp, True, False)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.aumentarX2bitmap(bmp, True, False)
            Cargando.Close()
        End If
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub AnchoToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnchoToolStripMenuItem8.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.aumentarX2bitmap(bmpaux, False, True) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.aumentarX2bitmap(bmp, False, True)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.aumentarX2bitmap(bmp, False, True)
            Cargando.Close()
        End If
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub AmbosToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmbosToolStripMenuItem7.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.aumentarX2bitmap(bmpaux, True, True) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.aumentarX2bitmap(bmp, True, True)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.aumentarX2bitmap(bmp, True, True)
            Cargando.Close()
        End If
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub AnchoToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnchoToolStripMenuItem9.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.aumentarX2interpolado(bmpaux, True, False)  'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
        End If
        If aceptar = True Or My.Settings.vistapr = False Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.aumentarX2interpolado(bmp, True, False) 'Lazamos vista previa y asignamos imagen
            Cargando.Close()
        End If
        objetoform.refrescar(PictureBox1, Panel1) 'Refrescamos Picture y Panel
        aceptar = False
    End Sub

    Private Sub AltoToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AltoToolStripMenuItem9.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.aumentarX2interpolado(bmpaux, False, True)  'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
        End If
        If aceptar = True Or My.Settings.vistapr = False Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.aumentarX2interpolado(bmp, False, True) 'Lazamos vista previa y asignamos imagen
            Cargando.Close()
        End If
        objetoform.refrescar(PictureBox1, Panel1) 'Refrescamos Picture y Panel
        aceptar = False
    End Sub

    Private Sub AmbosToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmbosToolStripMenuItem8.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.aumentarX2interpolado(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
        End If
        If aceptar = True Or My.Settings.vistapr = False Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.aumentarX2interpolado(bmp) 'Lazamos vista previa y asignamos imagen
            Cargando.Close()
        End If
        objetoform.refrescar(PictureBox1, Panel1) 'Refrescamos Picture y Panel
        aceptar = False
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.relacion4_3(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.relacion4_3(bmp)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.relacion4_3(bmp)
            Cargando.Close()
        End If
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.relacion3_2(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.relacion3_2(bmp)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.relacion3_2(bmp)
            Cargando.Close()
        End If
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.relacion16_9(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.relacion16_9(bmp)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.relacion16_9(bmp)
            Cargando.Close()
        End If
    End Sub

    Private Sub ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.relacion185_100(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.relacion185_100(bmp)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.relacion185_100(bmp)
            Cargando.Close()
        End If
    End Sub

    Private Sub ToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem16.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.relacion239_100(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.relacion239_100(bmp)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.relacion239_100(bmp)
            Cargando.Close()
        End If
    End Sub

    Private Sub BuscarActualizacionesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuscarActualizacionesToolStripMenuItem1.Click

        If objetoform.conexionInternet = True Then
            objetoform.actualizacion()
        Else
            MessageBox.Show("No hay conexión a Internet", "Actualizaciones", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If

    End Sub

    Private Sub RedimensionarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RedimensionarToolStripMenuItem.Click
        bitmapPic = PictureBox1.Image
        Redimensionar.ShowDialog()
        PictureBox1.Image = bitmapPic
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub PolaroidToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PolaroidToolStripMenuItem.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.polaroid(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.polaroid(bmp)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.polaroid(bmp)
            Cargando.Close()
        End If
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub X3ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles X3ToolStripMenuItem1.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "pixelarx3")
        PictureBox1.Refresh()
    End Sub

    Private Sub X5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles X5ToolStripMenuItem.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "pixelarx5")
        PictureBox1.Refresh()
    End Sub

    Private Sub X7ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles X7ToolStripMenuItem.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "pixelarx7")
        PictureBox1.Refresh()
    End Sub

    Private Sub KasjdToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KasjdToolStripMenuItem.Click
        bmp = PictureBox1.Image
        objetoform.pintar(bmp, "pixelarx3interpolado")
        PictureBox1.Refresh()
    End Sub

    Private Sub MosaicoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MosaicoToolStripMenuItem.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Mosaico.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.mosaico(bmp, mosaicohorizontal, mosaicovertical)
            Cargando.Close()
        End If
        aceptar = False
    End Sub

    Private Sub TexturaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TexturaToolStripMenuItem.Click
        bmp = PictureBox1.Image
        Textura.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            Dim Picture1 As Graphics = PictureBox1.CreateGraphics
            Dim tBrush As New TextureBrush(bmp)
            Dim lapizB As New Pen(colorB)
            Select Case volteado
                Case 0

                Case 1
                    tBrush.WrapMode = Drawing2D.WrapMode.TileFlipX
                Case 2
                    tBrush.WrapMode = Drawing2D.WrapMode.TileFlipY
                Case 3
                    tBrush.WrapMode = Drawing2D.WrapMode.TileFlipXY
                Case Else

            End Select

            Picture1.FillRectangle(tBrush, New Rectangle(0, 0, anchoB, altoB))
            Picture1.DrawRectangle(lapizB, New Rectangle(0, 0, anchoB, altoB))
            Cargando.Close()
        End If
        aceptar = False
    End Sub
    Private Sub ModificarCanalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModificarCanalesToolStripMenuItem.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        ModificarCanales.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.modificarCanales(bmp, canalrojo, canalverde, canalazul)
            Cargando.Close()
        End If
        aceptar = False
    End Sub



    Private Sub CopiarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarToolStripMenuItem.Click
        My.Computer.Clipboard.SetImage(PictureBox1.Image)
    End Sub

    Private Sub PegarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PegarToolStripMenuItem.Click
        If My.Computer.Clipboard.ContainsImage() Then
            PictureBox1.Image = My.Computer.Clipboard.GetImage()
        End If
    End Sub

    Private Sub CopiarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopiarToolStripMenuItem1.Click
        CopiarToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub PegarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PegarToolStripMenuItem1.Click
        PegarToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub FondoDePantallaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FondoDePantallaToolStripMenuItem1.Click
        FondoDePantallaToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub SsssToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SsssToolStripMenuItem.Click
        If escala = 1 Then copiaimagenZoom = PictureBox1.Image
        escala = escala + 0.2
        Dim bmpaxu As New Bitmap(copiaimagenZoom, copiaimagenZoom.Width * escala, copiaimagenZoom.Height * escala)
        PictureBox1.Image = bmpaxu
        objetoform.refrescar(PictureBox1, Panel1)
        ToolStripStatusLabel9.Text = "   Zoom x" & escala
    End Sub

    Private Sub ZoomToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ZoomToolStripMenuItem2.Click
        escala = escala - 0.2
        If CInt(escala) <= 0 Then
            MessageBox.Show("Limite de escala alcanzado", "Apolo v0.9", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If
        Dim bmpaxu As New Bitmap(copiaimagenZoom, copiaimagenZoom.Width * escala, copiaimagenZoom.Height * escala)
        PictureBox1.Image = bmpaxu
        objetoform.refrescar(PictureBox1, Panel1)
        ToolStripStatusLabel9.Text = "   Zoom x" & escala
    End Sub

    Private Sub DeshacerZoomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeshacerZoomToolStripMenuItem.Click
        PictureBox1.Image = copiaimagenZoom
        objetoform.refrescar(PictureBox1, Panel1)
        escala = 1
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Select Case tipoPuntero
            Case "normal"
            Case "zoom+"
                SsssToolStripMenuItem_Click(sender, e)
            Case "zoom-"
                ZoomToolStripMenuItem2_Click(sender, e)
        End Select

    End Sub

    Private Sub Puntero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Puntero.Click
        PunteroToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Me.Cursor = New System.Windows.Forms.Cursor("zoom-mas.ico")
        tipoPuntero = "zoom+"
    End Sub

    Private Sub ToolStripButton4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        Me.Cursor = New System.Windows.Forms.Cursor("zoom-menos.ico")
        tipoPuntero = "zoom-"
    End Sub

    Private Sub copiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CopiarToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub ToolStripButton10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton10.Click
        RecortarImagenToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        PegarToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub Atrás_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Atrás.Click
        AtrásToolStripMenuItem2_Click(sender, e)
    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        ImagenOriginalToolStripMenuItem2_Click(sender, e)
    End Sub

    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        AjustarAPantallaToolStripMenuItem1_Click(sender, e)
    End Sub



    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        RefrescarImagenToolStripMenuItem_Click(sender, e)
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If My.Settings.Original = True Then
            Label1.Text = " Imagen general"
            Label2.Text = "--------------------------------------------------"
            Label3.Text = "--------------------------------------------------"
            Timer1.Interval = 2000

            Dim bmp As New Bitmap(PictureBox1.Image)
            Dim bmppeq As New Bitmap(bmp, PictureBox2.Width, PictureBox2.Height)
            PictureBox2.BorderStyle = BorderStyle.FixedSingle
            PictureBox2.Image = bmppeq
        Else
            Label1.Text = ""
            Label2.Text = ""
            Label3.Text = ""
            Timer1.Interval = 5000
            PictureBox2.BorderStyle = BorderStyle.None
            PictureBox2.Image = Nothing
        End If

    End Sub


    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        PictureBox3.BorderStyle = BorderStyle.FixedSingle
        PictureBox3.Refresh()
        Dim dashValues As Single()
        Select Case My.Settings.TrazoForm
            Case "normal"
                dashValues = {9999, 1, 1, 1}
            Case "disc1"
                dashValues = {5, 2, 15, 4}
            Case "disc2"
                dashValues = {1, 2, 1, 2}
            Case "disc3"
                dashValues = {5, 1, 5, 1}
            Case "disc4"
                dashValues = {10, 1, 1, 1}
            Case "disc5"
                dashValues = {2, 3, 15, 9}

            Case Else
                dashValues = {9999, 1, 1, 1}
        End Select

        Dim lapiz As New Pen(My.Settings.TrazoColor, My.Settings.TrazoAnch)
        lapiz.DashPattern = dashValues
        Dim Picture1 As Graphics = PictureBox3.CreateGraphics
        Picture1.DrawLine(lapiz, New Point(15, 15), New Point(130, 15))

    End Sub

    Private Sub ManualToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManualToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Oleo.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.Oleo(bmp, valorcontorno, numerocolores)
            Cargando.Close()
        End If
        aceptar = False
    End Sub

    Private Sub AutomáticoToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutomáticoToolStripMenuItem4.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.Oleo(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.Oleo(bmp)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.Oleo(bmp)
            Cargando.Close()
        End If
    End Sub

    Private Sub HistogramaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistogramaToolStripMenuItem.Click
        bmpauxhist = PictureBox1.Image
        Histograma.ShowDialog()
    End Sub

    Private Sub VerTablaImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerTablaImagenToolStripMenuItem.Click

        Dim bmp As New Bitmap(PictureBox1.Image)
        Dim mensaje As String
        'Parámetros
        mensaje = MessageBox.Show("Esta acción puede durar varios minutos. ¿Está seguro de continuar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
        If mensaje = vbYes Then
            objeto.tabla(bmp, Tabla.DataGridView1, False, True)
            Tabla.ShowDialog()
        End If
    End Sub

    Private Sub AcercaDeCanvasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcercaDeCanvasToolStripMenuItem.Click
        AboutBox1.ShowDialog()
    End Sub



    ''''''Dibujar línea'''''''
    '''''''''''''''''''''''''''

    Private m_lstOflapiz As New List(Of Lapiz)
    Private m_lapiz As Lapiz

    Private m_lstOfLine As New List(Of Linea)
    Private m_line As Linea

    Private m_poli As Polilinea
    Private m_lstOfpoli As New List(Of Polilinea)

    Private m_lstOfcuadra As New List(Of cuadrado)
    Private m_cuadra As cuadrado

    Private m_lstOfrect As New List(Of Rectangulo)
    Private m_rect As Rectangulo

    Private m_lstOfelip As New List(Of elipse)
    Private m_elip As elipse

    Private m_lstOfcirc As New List(Of circulo)
    Private m_circ As circulo

    Private m_lstOftexto As New List(Of Texto)
    Private m_texto As Texto

    Private rec_rec As RectanguloRecortar

    Private Sub PictureBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        If tipoPuntero = "clonar" Then
            If puntoClon2 = True Then
                puntoAclonarAux = e.Location
                puntoClon = False
            End If
            If tipoPuntero = "clonar" Then
                If puntoClon = True Then
                    puntoAclonar = e.Location
                    puntoClon2 = True
                End If
            End If
        End If
        If tipoPuntero = "filtro" Then
            FiltroInicio = True
        End If
        If tipoPuntero = "filtroBN" Then
            FiltroInicioBN = True
        End If
        If tipoPuntero = "clonarParcial" Then
            If puntoClonPar2 = True Then
                puntoAclonarParAux = e.Location
                puntoClonPar = False
            End If
            If tipoPuntero = "clonarParcial" Then
                If puntoClonPar = True Then
                    puntoAclonarPar = e.Location
                    puntoClonPar2 = True
                End If
            End If
        End If
        If tipoPuntero = "borrar" Then
            BorrarInicio = True
        End If



    End Sub




    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        ' Solamente se ejecutará si se ha pulsado el botón izquierdo del ratón.
        '
        If (e.Button = MouseButtons.Left) Then

            If tipoPuntero = "lapiz" Then

                m_lapiz = New Lapiz()
                m_lapiz.Point1 = e.Location

                m_lstOflapiz.Add(m_lapiz)
                m_lapiz = Nothing

                PictureBox1.Capture = False
                PictureBox1.Refresh()

            End If

            If tipoPuntero = "linea" Then
                PictureBox1.Capture = True

                ' Iniciamos una nueva línea
                '

                m_line = New Linea()
                m_line.Point1 = e.Location
                m_line.color = My.Settings.TrazoColor
                m_line.ancho = My.Settings.TrazoAnch
                m_line.formatoLinea = My.Settings.TrazoForm
            End If


            If tipoPuntero = "polilinea" Then
                PictureBox1.Capture = True

                ' Iniciamos una nueva línea
                '
                m_poli = New Polilinea()

                puntosPol(contadorPoli) = New Point(e.Location)
                m_poli.color = My.Settings.TrazoColor
                m_poli.ancho = My.Settings.TrazoAnch
                m_poli.formatoLinea = My.Settings.TrazoForm
                contadorPoli += 1
                m_lstOfpoli.Add(m_poli)
                m_poli = Nothing
                PictureBox1.Capture = False
                PictureBox1.Refresh()

            End If

            If tipoPuntero = "cuadrado" Then
                PictureBox1.Capture = True

                ' Iniciamos una nueva línea
                '
                m_cuadra = New cuadrado()
                m_cuadra.Point1 = e.Location
                m_cuadra.color = My.Settings.TrazoColor
                m_cuadra.ancho = My.Settings.TrazoAnch
                m_cuadra.colorInt = My.Settings.TrazoInter
                m_cuadra.formatoLinea = My.Settings.TrazoForm
            End If

            If tipoPuntero = "rectangulo" Then
                PictureBox1.Capture = True

                ' Iniciamos una nueva línea
                '
                m_rect = New Rectangulo()
                m_rect.Point1 = e.Location
                m_rect.color = My.Settings.TrazoColor
                m_rect.ancho = My.Settings.TrazoAnch
                m_rect.colorInt = My.Settings.TrazoInter
                m_rect.formatoLinea = My.Settings.TrazoForm
            End If

            If tipoPuntero = "elipse" Then
                PictureBox1.Capture = True

                ' Iniciamos una nueva línea
                m_elip = New elipse()
                m_elip.Point1 = e.Location
                m_elip.color = My.Settings.TrazoColor
                m_elip.ancho = My.Settings.TrazoAnch
                m_elip.colorInt = My.Settings.TrazoInter
                m_elip.formatoLinea = My.Settings.TrazoForm
            End If

            If tipoPuntero = "circulo" Then
                PictureBox1.Capture = True

                ' Iniciamos una nueva línea
                '

                m_circ = New circulo()
                m_circ.Point1 = e.Location
                m_circ.color = My.Settings.TrazoColor
                m_circ.ancho = My.Settings.TrazoAnch
                m_circ.colorInt = My.Settings.TrazoInter
                m_circ.formatoLinea = My.Settings.TrazoForm
            End If

            If tipoPuntero = "texto" Then
                PictureBox1.Capture = True

                ' Iniciamos una nueva línea
                '

                m_texto = New Texto()
                m_texto.Point1 = e.Location
                m_texto.texto_ = textoImagen

                If tipofuente IsNot Nothing Then
                    m_texto.fuente_ = tipofuente
                End If

                m_texto.color_ = colorFuente
                m_lstOftexto.Add(m_texto)
                m_texto = Nothing
                PictureBox1.Capture = False
                PictureBox1.Refresh()
            End If

            If tipoPuntero = "RectanguloRecortar" Then
                PictureBox1.Capture = True

                ' Iniciamos una nueva línea
                '
                rec_rec = New RectanguloRecortar()
                rec_rec.Point1 = e.Location
            End If

            If (e.Button = MouseButtons.Left) Then

                If tipoPuntero = "segmentacion" Then
                    bmpsegmentacion = PictureBox1.Image
                    PictureBox1.Image = objeto.segmentacion(bmpsegmentacion, e.Location, My.Settings.RojoSe, My.Settings.VerdeSe, My.Settings.AzulSe, My.Settings.AlfaSe, My.Settings.AnchoSe, My.Settings.AltoSe)

                End If
            End If

        End If

    End Sub


    Public Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        Dim mouseDownLocation As New Point(e.X, e.Y)
        ToolStripStatusLabel7.Text = "Coordenadas " & mouseDownLocation.X & "," & mouseDownLocation.Y
        ToolStripStatusLabel9.Text = "Coordenadas " & mouseDownLocation.X & "," & mouseDownLocation.Y
        Dim bmp As New Bitmap(1, 1, PixelFormat.Format32bppArgb)
        bmp = PictureBox1.Image
        Try
            ToolStripStatusLabel8.Text = bmp.GetPixel(e.X, e.Y).ToString
        Catch
        End Try

        If tipoPuntero = "clonar" And puntoClon = False And puntoClon2 = True Then
            Dim ancho = puntoAclonarAux.X - e.Location.X
            Dim alto = puntoAclonarAux.Y - e.Location.Y

            PictureBox1.Image = objeto.clonar(bmp, New Point(puntoAclonar.X - ancho, puntoAclonar.Y - alto), e.Location, My.Settings.AnchoClon, My.Settings.AltoClon)

        End If

        If tipoPuntero = "clonarParcial" And puntoClonPar = False And puntoClonPar2 = True Then
            Dim ancho = puntoAclonarParAux.X - e.Location.X
            Dim alto = puntoAclonarParAux.Y - e.Location.Y

            PictureBox1.Image = objeto.clonarParcial(bmp, New Point(puntoAclonarPar.X - ancho, puntoAclonarPar.Y - alto), e.Location, My.Settings.AnchoclonPar, My.Settings.AltoclonPar)

        End If

        If tipoPuntero = "filtro" And FiltroInicio = True Then
            PictureBox1.Image = objeto.filtroLocal(bmp, e.Location, My.Settings.AnchoFIltro, My.Settings.AltoFIltro, My.Settings.RojoFi, My.Settings.VErdeFi, My.Settings.AzulFi)
        End If
        If tipoPuntero = "filtroBN" And FiltroInicioBN = True Then
            PictureBox1.Image = objeto.filtroBN(bmp, e.Location, My.Settings.AnchoFpar, My.Settings.AltoFpar, originala)
        End If
        If tipoPuntero = "borrar" And borrarInicio = True Then
            PictureBox1.Image = objeto.Borrar(bmp, e.Location, My.Settings.AnchoBorrar, My.Settings.AltoBorrar, My.Settings.RojoBorrar, My.Settings.VerdeBorrar, My.Settings.AzulBorrar, My.Settings.AlfaBorrar)
        End If


        If tipoPuntero = "lapiz" Then

            If (e.Button = MouseButtons.Left) Then


                m_lapiz = New Lapiz()
                m_lapiz.Point1 = e.Location

                m_lstOflapiz.Add(m_lapiz)
                m_lapiz = Nothing

                PictureBox1.Capture = False
                PictureBox1.Refresh()
            End If
        End If



        If tipoPuntero = "linea" Then

            If ((m_line Is Nothing) OrElse _
               (Not PictureBox1.Capture) OrElse _
               (e.Button <> MouseButtons.Left)) Then _
               Return

            m_line.Point2 = e.Location
            PictureBox1.Refresh()
        End If


        If tipoPuntero = "cuadrado" Then
            If ((m_cuadra Is Nothing) OrElse _
              (Not PictureBox1.Capture) OrElse _
              (e.Button <> MouseButtons.Left)) Then _
              Return

            m_cuadra.Point2 = e.Location
            PictureBox1.Refresh()
        End If

        If tipoPuntero = "rectangulo" Then
            If ((m_rect Is Nothing) OrElse _
              (Not PictureBox1.Capture) OrElse _
              (e.Button <> MouseButtons.Left)) Then _
              Return

            m_rect.Point2 = e.Location
            PictureBox1.Refresh()
        End If

        If tipoPuntero = "elipse" Then

            If ((m_elip Is Nothing) OrElse _
               (Not PictureBox1.Capture) OrElse _
               (e.Button <> MouseButtons.Left)) Then _
               Return

            m_elip.Point2 = e.Location
            PictureBox1.Refresh()
        End If

        If tipoPuntero = "circulo" Then

            If ((m_circ Is Nothing) OrElse _
               (Not PictureBox1.Capture) OrElse _
               (e.Button <> MouseButtons.Left)) Then _
               Return

            m_circ.Point2 = e.Location
            PictureBox1.Refresh()
        End If

        If tipoPuntero = "RectanguloRecortar" Then
            If ((rec_rec Is Nothing) OrElse _
              (Not PictureBox1.Capture) OrElse _
              (e.Button <> MouseButtons.Left)) Then _
              Return

            rec_rec.Point2 = e.Location
            PictureBox1.Refresh()
        End If

    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        If tipoPuntero = "linea" Then
            If ((m_line Is Nothing) OrElse _
               (Not PictureBox1.Capture) OrElse _
               (e.Button <> MouseButtons.Left)) Then _
               Return

            m_line.Point2 = e.Location
            m_lstOfLine.Add(m_line)
            m_line = Nothing

            PictureBox1.Capture = False
            PictureBox1.Refresh()
        End If


        If tipoPuntero = "cuadrado" Then
            If ((m_cuadra Is Nothing) OrElse _
              (Not PictureBox1.Capture) OrElse _
              (e.Button <> MouseButtons.Left)) Then _
              Return

            m_cuadra.Point2 = e.Location
            m_lstOfcuadra.Add(m_cuadra)
            m_cuadra = Nothing

            PictureBox1.Capture = False
            PictureBox1.Refresh()
        End If

        If tipoPuntero = "rectangulo" Then
            If ((m_rect Is Nothing) OrElse _
              (Not PictureBox1.Capture) OrElse _
              (e.Button <> MouseButtons.Left)) Then _
              Return

            m_rect.Point2 = e.Location
            m_lstOfrect.Add(m_rect)
            m_rect = Nothing

            PictureBox1.Capture = False
            PictureBox1.Refresh()
        End If

        If tipoPuntero = "elipse" Then
            If ((m_elip Is Nothing) OrElse _
               (Not PictureBox1.Capture) OrElse _
               (e.Button <> MouseButtons.Left)) Then _
               Return

            m_elip.Point2 = e.Location
            m_lstOfelip.Add(m_elip)
            m_elip = Nothing

            PictureBox1.Capture = False
            PictureBox1.Refresh()
        End If

        If tipoPuntero = "circulo" Then
            If ((m_circ Is Nothing) OrElse _
               (Not PictureBox1.Capture) OrElse _
               (e.Button <> MouseButtons.Left)) Then _
               Return

            m_circ.Point2 = e.Location
            m_lstOfcirc.Add(m_circ)
            m_circ = Nothing

            PictureBox1.Capture = False
            PictureBox1.Refresh()
        End If

        If tipoPuntero = "RectanguloRecortar" Then
            If ((rec_rec Is Nothing) OrElse _
              (Not PictureBox1.Capture) OrElse _
              (e.Button <> MouseButtons.Left)) Then _
              Return
            rec_rec.Point2 = e.Location
            rec_rec = Nothing
            PictureBox1.Capture = False
        End If

    End Sub
    Private Sub Principal_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        If Panel2.Visible = False Then
            If e.Delta > 0 Then
                SsssToolStripMenuItem_Click(sender, e)
            Else
                ZoomToolStripMenuItem2_Click(sender, e)
            End If
        End If
    End Sub
    Private Sub Picture1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles PictureBox1.Paint


        m_lstOflapiz.ForEach(Sub(item As Lapiz)
                                 item.Draw(e.Graphics)
                             End Sub)
        If (Not (m_lapiz) Is Nothing) Then m_lapiz.Draw(e.Graphics)



        m_lstOfLine.ForEach(Sub(item As Linea)
                                item.Draw(e.Graphics)
                            End Sub)

        If (Not (m_line) Is Nothing) Then m_line.Draw(e.Graphics)

        m_lstOfpoli.ForEach(Sub(item As Polilinea)
                                item.Draw(e.Graphics)
                            End Sub)

        If (Not (m_poli) Is Nothing) Then m_poli.Draw(e.Graphics)

        m_lstOfcuadra.ForEach(Sub(item As cuadrado)
                                  item.Draw(e.Graphics)
                              End Sub)

        If (Not (m_cuadra) Is Nothing) Then m_cuadra.Draw(e.Graphics)



        m_lstOfrect.ForEach(Sub(item As Rectangulo)
                                item.Draw(e.Graphics)
                            End Sub)

        If (Not (m_rect) Is Nothing) Then m_rect.Draw(e.Graphics)

        m_lstOfelip.ForEach(Sub(item As elipse)
                                item.Draw(e.Graphics)
                            End Sub)

        If (Not (m_elip) Is Nothing) Then m_elip.Draw(e.Graphics)

        m_lstOfcirc.ForEach(Sub(item As circulo)
                                item.Draw(e.Graphics)
                            End Sub)

        If (Not (m_circ) Is Nothing) Then m_circ.Draw(e.Graphics)



        m_lstOftexto.ForEach(Sub(item As Texto)
                                 item.Draw(e.Graphics)
                             End Sub)

        If (Not (m_texto) Is Nothing) Then m_texto.Draw(e.Graphics)

        If (Not (rec_rec) Is Nothing) Then
            rec_rec.Draw(e.Graphics)
        End If
    End Sub



    Private Sub ToolStripButton8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton8.Click
        LíneaToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub ToolStripButton9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton9.Click
        ElipseToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub ToolStripButton10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CírculoToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton11.Click
        RectánguloToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton12_ButtonClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton12.ButtonClick
        TextoToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub PropiedadesDelTextoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesDelTextoToolStripMenuItem1.Click
        PropiedadesDelTextoToolStripMenuItem_Click(sender, e)
    End Sub


    Private Sub CuadradoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadradoToolStripMenuItem1.Click
        CuadradoToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem18.Click
        CírculoToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub PolilíneaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PolilíneaToolStripMenuItem.Click
        POlilineaToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub LápizToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LápizToolStripMenuItem1.Click
        LápizToolStripMenuItem_Click(sender, e)
    End Sub


    Private Sub PropiedadesDelTextoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesDelTextoToolStripMenuItem.Click
        FontDialog1.ShowColor = True
        If FontDialog1.ShowDialog() <> DialogResult.Cancel Then
            tipofuente = FontDialog1.Font
            colorFuente = FontDialog1.Color

        End If

    End Sub

    Private Sub PunteroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PunteroToolStripMenuItem.Click
        Me.Cursor = Windows.Forms.Cursors.Default
        tipoPuntero = "normal"
        FiltroInicio = False
    End Sub
    Private Sub LápizToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LápizToolStripMenuItem3.Click
        Me.Cursor = Windows.Forms.Cursors.Cross
        tipoPuntero = "lapiz"
    End Sub

    Private Sub LíneaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LíneaToolStripMenuItem.Click
        Me.Cursor = Windows.Forms.Cursors.Cross
        tipoPuntero = "linea"
    End Sub
    Private Sub POlilineaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POlilineaToolStripMenuItem.Click
        Me.Cursor = Windows.Forms.Cursors.Cross
        tipoPuntero = "polilinea"
    End Sub
    Private Sub CuadradoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadradoToolStripMenuItem.Click
        Me.Cursor = Windows.Forms.Cursors.Cross
        tipoPuntero = "cuadrado"
    End Sub
    Private Sub RectánguloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectánguloToolStripMenuItem.Click
        Me.Cursor = Windows.Forms.Cursors.Cross
        tipoPuntero = "rectangulo"
    End Sub
    Private Sub ElipseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ElipseToolStripMenuItem.Click
        Me.Cursor = Windows.Forms.Cursors.Cross
        tipoPuntero = "elipse"
    End Sub

    Private Sub CírculoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CírculoToolStripMenuItem.Click
        Me.Cursor = Windows.Forms.Cursors.Cross
        tipoPuntero = "circulo"
    End Sub

    Private Sub TextoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextoToolStripMenuItem.Click
        Me.Cursor = Windows.Forms.Cursors.IBeam
        tipoPuntero = "texto"
        Dim mensaje As String
        mensaje = (InputBox("Introduzca el texto", ))
        If mensaje = "" Then Me.Cursor = Windows.Forms.Cursors.Default : tipoPuntero = "normal"
        textoImagen = mensaje
    End Sub


    Private Sub PropiedadesDelTrazoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesDelTrazoToolStripMenuItem.Click

        TipoTrazo.ShowDialog()

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        TipoTrazo.ShowDialog()
    End Sub


    Private Sub PictureBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        ToolTip1.Active = True

        With (ToolTip1)

            .ToolTipIcon = ToolTipIcon.Info
            .ToolTipTitle = "Haga clic para modificar el tipo de trazo" ' titulo  
            .InitialDelay = 1 'tiempo en aparecer  
            Dim sText As String = " "
            ' Lo establece  
            .SetToolTip(PictureBox3, sText)
        End With
    End Sub


    Private Sub MáscaraManualToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MáscaraManualToolStripMenuItem.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        MascaraManual.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            If grisO = True Then
                PictureBox1.Image = objeto.mascara3x3Gris(bmp, pasoMascara, desviacionP, factorP)
            Else
                PictureBox1.Image = objeto.mascara3x3RGB(bmp, pasoMascara, desviacionP, factorP)
            End If

            Cargando.Close()
        End If
        aceptar = False
    End Sub


    Private Sub AjustarExposiciónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AjustarExposiciónToolStripMenuItem.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Exposicion.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.exposicion(bmp, valorexposi)
            Cargando.Close()
        End If
        aceptar = False
    End Sub

    Private Sub MatrizToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MatrizToolStripMenuItem.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Matriz.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            PictureBox1.Image = objeto.filtroponderado(bmp, r1, r2, r3, g1, g2, g3, b1, b2, b3)
            Cargando.Close()
        End If
        aceptar = False
    End Sub

    Private Sub DegradadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DegradadoToolStripMenuItem.Click
        bmp = PictureBox1.Image
        bmpentreForm = bmp.Clone() 'Clonamos el bmp a una bitmap de variables globales
        Degradador.ShowDialog() 'Lanzamos nueva ventana
        If aceptar = True Then 'Si el usuario acepta
            Cargando.Show()
            If degH1 >= 0 Then
                PictureBox1.Image = objeto.degradadoHorizontal(bmp, degH, degH1)
            Else
                PictureBox1.Image = objeto.degradadoHorizontalInvertido(bmp, degH, -degH1)
            End If
            If degV1 >= 0 Then
                PictureBox1.Image = objeto.degradadoVertical(bmp, degV, degV1)
            Else
                PictureBox1.Image = objeto.degradadoVerticalInvertido(bmp, degV, -degV1)
            End If
            Cargando.Close()
        End If
        aceptar = False
    End Sub

    Private Sub ImagenOriginalToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagenOriginalToolStripMenuItem2.Click
        If objeto.rutaimagen <> "" Then
            Dim bmp As New Bitmap(objeto.rutaimagen)
            PictureBox1.Image = bmp
            objetoform.refrescar(PictureBox1, Panel1) 'Refrescar
        End If
    End Sub

    Private Sub EmpezarAClonarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpezarAClonarToolStripMenuItem1.Click
        anchoClonar = PictureBox1.Image.Width
        altoCLonar = PictureBox1.Image.Height
        If My.Settings.MensajeClon = True Then
            DialogoClon.ShowDialog()
            If DialogoClon.DialogResult = Windows.Forms.DialogResult.OK Then
                Cargando.Show()
                AjustarAPantallaToolStripMenuItem1_Click(sender, e)
                Dim bmp As New Bitmap(PictureBox1.Image)
                clonarVal = True
                PictureBox1.Image = objeto.clonar(bmp, New Point(0, 0), New Point(0, 0))
                tipoPuntero = "clonar"
                puntoClon = True
                puntoClon2 = False
                Cargando.Close()
            Else
                tipoPuntero = "normal"
            End If
        Else
            Cargando.Show()
            AjustarAPantallaToolStripMenuItem1_Click(sender, e)
            Dim bmp As New Bitmap(PictureBox1.Image)
            AjustarAPantallaToolStripMenuItem1_Click(sender, e)
            clonarVal = True
            PictureBox1.Image = objeto.clonar(bmp, New Point(0, 0), New Point(0, 0))
            tipoPuntero = "clonar"
            puntoClon = True
            puntoClon2 = False
            Cargando.Close()
        End If
    End Sub

    Private Sub PropiedadesToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesToolStripMenuItem3.Click
        PropiedadesClon.ShowDialog()
    End Sub

    Private Sub EmpezarAFiltrarToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpezarAFiltrarToolStripMenuItem1.Click
        anchoClonar = PictureBox1.Image.Width
        altoCLonar = PictureBox1.Image.Height
        If My.Settings.MensajeFiltro = True Then
            DialogFiltro.ShowDialog()
            If DialogFiltro.DialogResult = Windows.Forms.DialogResult.OK Then
                Cargando.Show()
                AjustarAPantallaToolStripMenuItem1_Click(sender, e)
                Dim bmp As New Bitmap(PictureBox1.Image)
                FiltroVal = True
                PictureBox1.Image = objeto.filtroLocal(bmp, New Point(0, 0))
                tipoPuntero = "filtro"
                Cargando.Close()
            Else
                tipoPuntero = "normal"
            End If
        Else
            Cargando.Show()
            AjustarAPantallaToolStripMenuItem1_Click(sender, e)
            Dim bmp As New Bitmap(PictureBox1.Image)
            FiltroVal = True
            PictureBox1.Image = objeto.filtroLocal(bmp, New Point(0, 0))
            tipoPuntero = "filtro"
            Cargando.Close()
        End If

    End Sub

    Private Sub PropiedadesToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesToolStripMenuItem4.Click
        PropiedadesFiltrL1.ShowDialog()
    End Sub

    Private Sub EmpezarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpezarToolStripMenuItem.Click
        anchoClonar = PictureBox1.Image.Width
        altoCLonar = PictureBox1.Image.Height
        If My.Settings.MensajeClonParcial = True Then
            Dialog1ClonParc.ShowDialog()
            If Dialog1ClonParc.DialogResult = Windows.Forms.DialogResult.OK Then
                Cargando.Show()
                AjustarAPantallaToolStripMenuItem1_Click(sender, e)
                Dim bmp As New Bitmap(PictureBox1.Image)
                AjustarAPantallaToolStripMenuItem1_Click(sender, e)
                clonarParVal = True
                PictureBox1.Image = objeto.clonarParcial(bmp, New Point(0, 0), New Point(0, 0))
                tipoPuntero = "clonarParcial"
                puntoClonPar = True
                puntoClonPar2 = False
                Cargando.Close()
            Else
                tipoPuntero = "normal"
            End If
        Else
            Cargando.Show()
            AjustarAPantallaToolStripMenuItem1_Click(sender, e)
            Dim bmp As New Bitmap(PictureBox1.Image)
            AjustarAPantallaToolStripMenuItem1_Click(sender, e)
            clonarParVal = True
            PictureBox1.Image = objeto.clonarParcial(bmp, New Point(0, 0), New Point(0, 0))
            tipoPuntero = "clonarParcial"
            puntoClonPar = True
            puntoClonPar2 = False
            Cargando.Close()
        End If
    End Sub

    Private Sub PropiedadesToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesToolStripMenuItem5.Click
        PropiedadesClonParcial.ShowDialog()
    End Sub


    Private Sub BlancoYNegroToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BlancoYNegroToolStripMenuItem.Click
        filtroloc("BN")
    End Sub
    Private Sub GrisesToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrisesToolStripMenuItem15.Click
        filtroloc("gris")
    End Sub

    Private Sub InvertidoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvertidoToolStripMenuItem.Click
        filtroloc("invertir")
    End Sub

    Private Sub SepiaToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SepiaToolStripMenuItem3.Click
        filtroloc("sepia")
    End Sub

    Private Sub RojoToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RojoToolStripMenuItem3.Click
        filtroloc("rojo")
    End Sub

    Private Sub VerdeToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerdeToolStripMenuItem3.Click
        filtroloc("verde")
    End Sub

    Private Sub AzulToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AzulToolStripMenuItem3.Click
        filtroloc("azul")
    End Sub

    Private Sub BGRToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BGRToolStripMenuItem2.Click
        filtroloc("BGR")
    End Sub

    Private Sub GRBToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GRBToolStripMenuItem2.Click
        filtroloc("GRB")
    End Sub

    Private Sub RBGToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBGToolStripMenuItem2.Click
        filtroloc("RBG")
    End Sub

    Private Sub ContornosToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContornosToolStripMenuItem2.Click
        filtroloc("contornos")
    End Sub

    Private Sub ProbarConMásToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProbarConMásToolStripMenuItem.Click
        filtroloc("reducir")
    End Sub
    Private Sub ÓleoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÓleoToolStripMenuItem1.Click
        filtroloc("oleo")
    End Sub

    Private Sub HorizontalToolStripMenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HorizontalToolStripMenuItem27.Click
        filtroloc("etiopiaH")
    End Sub

    Private Sub VerticalToolStripMenuItem27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerticalToolStripMenuItem27.Click
        filtroloc("etiopiaV")
    End Sub

    Private Sub X5ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles X5ToolStripMenuItem1.Click
        filtroloc("x5")
    End Sub

    Private Sub X7ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles X7ToolStripMenuItem1.Click
        filtroloc("x7")
    End Sub

    Private Sub PersonalizadoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonalizadoToolStripMenuItem.Click
        Filtrpersonal.ShowDialog()
        If pasoFiltrPer = True Then
            filtroloc(filtroPersonalString1, filtroPersonalString2)
        End If
        pasoFiltrPer = False
    End Sub

    Private Sub PropiedadesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesToolStripMenuItem1.Click
        PpiedadesParcilaFiltro.ShowDialog()
    End Sub

    Sub filtroloc(ByVal tipofiltroInicial As String, Optional ByVal filtroFinal As String = "original")
        anchoClonar = PictureBox1.Image.Width
        altoCLonar = PictureBox1.Image.Height
        If My.Settings.MensajesFiltroParc = True Then
            DialogFiltroPar.ShowDialog()
            If DialogFiltroPar.DialogResult = Windows.Forms.DialogResult.OK Then
                Cargando.Show()
                objetoform.ajustarpantalla(PictureBox1, Panel1)
                objetoform.refrescar(PictureBox1, Panel1)
                Dim bmp As New Bitmap(PictureBox1.Image)
                FiltroBNN = True
                PictureBox1.Image = objeto.filtroBN(bmp, New Point(0, 0), , , , tipofiltroInicial, filtroFinal)
                tipoPuntero = "filtroBN"
                Cargando.Close()
            Else
                tipoPuntero = "normal"
            End If
        Else
            Cargando.Show()
            objetoform.ajustarpantalla(PictureBox1, Panel1)
            objetoform.refrescar(PictureBox1, Panel1)
            Dim bmp As New Bitmap(PictureBox1.Image)
            FiltroBNN = True
            PictureBox1.Image = objeto.filtroBN(bmp, New Point(0, 0), , , , tipofiltroInicial, filtroFinal)
            tipoPuntero = "filtroBN"
            Cargando.Close()
        End If
    End Sub

    Private Sub FondoDePantallaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FondoDePantallaToolStripMenuItem.Click
        Dim bmp As New Bitmap(PictureBox1.Image)
        objeto.FondoPantalla(bmp)
    End Sub

    Private Sub RecortarImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RecortarImagenToolStripMenuItem.Click
        If My.Settings.MensajeRecortar = True Then
            MensajeRecortar.ShowDialog()
            If MensajeRecortar.DialogResult = Windows.Forms.DialogResult.OK Then
                imagenAntesRec = PictureBox1.Image
                AjustarAPantallaToolStripMenuItem1_Click(sender, e)
                Me.Cursor = Windows.Forms.Cursors.Cross
                tipoPuntero = "RectanguloRecortar"
            End If
        Else
            imagenAntesRec = PictureBox1.Image
            AjustarAPantallaToolStripMenuItem1_Click(sender, e)
            Me.Cursor = Windows.Forms.Cursors.Cross
            tipoPuntero = "RectanguloRecortar"
        End If
    End Sub

    Private Sub TabControlModificado2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControlModificado2.SelectedIndexChanged
        If TabControlModificado2.SelectedIndex = 1 Then
            Dim url As New Uri("http://www.mueblesdelhogar.com.ar/imagenes/Cargando.gif")
            WebBrowser1.Url = url
            Timer3.Enabled = True
        End If
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        TabPage2.BackgroundImage = Nothing
        Dim url As New Uri("http://algoimagen.blogspot.com.es/?m=1")
        WebBrowser1.Url = url
        Timer3.Enabled = False
    End Sub


    Private Sub Label5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseEnter
        Label5.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)
        Label5.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub
    Private Sub Label18_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label18.MouseEnter
        Label18.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)
        Label18.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub
    Private Sub Label6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseEnter
        Label6.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)
        Label6.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label7_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseEnter
        Label7.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)
        Label7.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label9_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseEnter
        Label9.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)
        Label9.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub


    Private Sub Label5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label5.MouseLeave
        Label5.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Font = fuente
    End Sub
    Private Sub Label18_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label18.MouseLeave
        Label18.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)
        Label18.Font = fuente
    End Sub
    Private Sub Label6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label6.MouseLeave
        Label6.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Font = fuente
    End Sub
    Private Sub Label7_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label7.MouseLeave
        Label7.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Font = fuente
    End Sub
    Private Sub Label9_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label9.MouseLeave
        Label9.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)
        Label9.Font = fuente
    End Sub


    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click
        BuscarActualizacionesToolStripMenuItem1_Click(sender, e)
    End Sub

    Private Sub Label18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label18.Click
        ConfiguraciónRápidaToolStripMenuItem_Click(sender, e)
    End Sub


    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click
        ConfiguraciónToolStripMenuItem1_Click(sender, e)
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click
        AcercaDeCanvasToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click
        Panel2.Visible = False
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            My.Settings.Pantallapresentación = True
        Else
            My.Settings.Pantallapresentación = False
        End If
        My.Settings.Save()
    End Sub


    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        Label8_Click(sender, e)
    End Sub


    Private Sub PictureBox5_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseEnter
        Me.Cursor = Windows.Forms.Cursors.Hand
        Dim bmp As New Bitmap("folder-open2.png")
        PictureBox5.Image = bmp

    End Sub

    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
        Dim bmp As New Bitmap("folder-open.png")
        PictureBox5.Image = bmp

    End Sub

    Private Sub Label8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label8.Click
        AbrirToolStripMenuItem2_Click(sender, e)
    End Sub

    Private Sub Label8_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseEnter
        Label8.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)
        Label8.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
        Dim bmp As New Bitmap("folder-open2.png")
        PictureBox5.Image = bmp

    End Sub

    Private Sub Label8_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label8.MouseLeave
        Label8.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)
        Label8.Font = fuente
        Dim bmp As New Bitmap("folder-open.png")
        PictureBox5.Image = bmp
    End Sub


    Private Sub Label10_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label10.MouseEnter
        Label10.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)
        Label10.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
        Dim bmp As New Bitmap("world_add2.png")
        PictureBox6.Image = bmp
    End Sub

    Private Sub Label10_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label10.MouseLeave
        Label10.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)
        Label10.Font = fuente
        Dim bmp As New Bitmap("world_add.png")
        PictureBox6.Image = bmp
    End Sub

    Private Sub Label10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label10.Click
        AbrirRecursoWebToolStripMenuItem_Click(sender, e)
        Panel2.Visible = False
    End Sub

    Private Sub PictureBox6_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseDown
        Dim bmp As New Bitmap("world_adsadd2.png")
        PictureBox6.Image = bmp
    End Sub
    Private Sub PictureBox6_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseEnter
        Me.Cursor = Windows.Forms.Cursors.Hand
        Dim bmp As New Bitmap("world_add2.png")
        PictureBox6.Image = bmp

    End Sub

    Private Sub PictureBox6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
        Dim bmp As New Bitmap("world_add.png")
        PictureBox6.Image = bmp
    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        Label10_Click(sender, e)

    End Sub


    Private Sub Label11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label11.Click
        Dim bmp = Image.FromFile("ImagenesRecientes/" & Label11.Text)
        PictureBox1.Image = bmp
        objetoform.refrescar(PictureBox1, Panel1)
        Panel2.Visible = False
    End Sub

    Private Sub Label12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label12.Click
        Dim bmp = Image.FromFile("ImagenesRecientes/" & Label12.Text)
        PictureBox1.Image = bmp
        objetoform.refrescar(PictureBox1, Panel1)
        Panel2.Visible = False
    End Sub

    Private Sub Label13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label13.Click
        Dim bmp = Image.FromFile("ImagenesRecientes/" & Label13.Text)
        PictureBox1.Image = bmp
        objetoform.refrescar(PictureBox1, Panel1)
        Panel2.Visible = False
    End Sub

    Private Sub Label14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label14.Click
        Dim bmp = Image.FromFile("ImagenesRecientes/" & Label14.Text)
        PictureBox1.Image = bmp
        objetoform.refrescar(PictureBox1, Panel1)
        Panel2.Visible = False
    End Sub

    Private Sub Label15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label15.Click
        Dim bmp = Image.FromFile("ImagenesRecientes/" & Label15.Text)
        PictureBox1.Image = bmp
        Panel2.Visible = False
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub Label16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label16.Click
        Dim bmp = Image.FromFile("ImagenesRecientes/" & Label16.Text)
        PictureBox1.Image = bmp
        Panel2.Visible = False
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub Label12_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label12.MouseEnter
        Label12.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)
        Label12.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label12_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label12.MouseLeave
        Label12.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)
        Label12.Font = fuente
    End Sub

    Private Sub Label11_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.MouseEnter
        Label11.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)
        Label11.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label11_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label11.MouseLeave
        Label11.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)
        Label11.Font = fuente
    End Sub

    Private Sub Label13_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label13.MouseEnter
        Label13.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)
        Label13.Font = fuente

        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label13_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label13.MouseLeave
        Label13.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)

        Label13.Font = fuente
    End Sub

    Private Sub Label14_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label14.MouseEnter
        Label14.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)

        Label14.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label14_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label14.MouseLeave
        Label14.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)

        Label14.Font = fuente
    End Sub

    Private Sub Label15_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label15.MouseEnter
        Label15.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)
        Label15.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label15_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label15.MouseLeave
        Label15.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)
        Label15.Font = fuente
    End Sub

    Private Sub Label16_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label16.MouseEnter
        Label16.ForeColor = Color.Black
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Underline, GraphicsUnit.Point)
        Label16.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label16_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label16.MouseLeave
        Label16.ForeColor = Color.Black
        PunteroToolStripMenuItem_Click(sender, e)
        Dim fuente As New Font("Segoe Print", 10, FontStyle.Regular, GraphicsUnit.Point)
        Label16.Font = fuente
    End Sub


    Private Sub PictureBox14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox14.Click
        Label15_Click(sender, e)
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox10.Click
        If Label11.Text <> "Thumbs.db" Then
            Label11_Click(sender, e)
        End If
    End Sub

    Private Sub PictureBox15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox15.Click
        Label16_Click(sender, e)
    End Sub

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox11.Click
        Label12_Click(sender, e)
    End Sub

    Private Sub PictureBox13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox13.Click
        Label14_Click(sender, e)
    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox12.Click
        Label13_Click(sender, e)
    End Sub

    Private Sub PictureBox10_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseEnter
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub PictureBox10_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox10.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBox11_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox11.MouseEnter
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub PictureBox11_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox11.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBox12_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox12.MouseEnter
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub PictureBox12_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox12.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBox13_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox13.MouseEnter
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub PictureBox13_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox13.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBox14_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox14.MouseEnter
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub PictureBox14_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox14.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub PictureBox15_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox15.MouseEnter
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub PictureBox15_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox15.MouseLeave
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub


    Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
        Dim y As Integer = 0
        Dim x As Integer = 0
        Dim ancho As Integer = Me.Width
        Dim alto As Integer = Me.Height
        Dim color1 As Color
        Dim color2 As Color

        color1 = Color.Gainsboro
        color2 = Color.WhiteSmoke

        Dim black_white_brush As New LinearGradientBrush(New Point(x, y), New Point(x + ancho, y), color1, color2)
        Dim color_blend As New ColorBlend(3)
        color_blend.Colors = New Color() {color1, color2, color1}
        color_blend.Positions = New Single() {0.0, 0.6, 1.0}
        black_white_brush.InterpolationColors = color_blend
        e.Graphics.FillRectangle(black_white_brush, x, y, ancho, alto)
    End Sub

    Private Sub ToolStripMenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IrAWebToolStripMenuItem.Click
        Dim proceso As New System.Diagnostics.Process
        With proceso
            .StartInfo.FileName = "http://algoimagen.blogspot.com.es/"
            .Start()
        End With
    End Sub



    Private Sub SegmentaciónToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SegmentaciónToolStripMenuItem1.Click
        anchoClonar = PictureBox1.Image.Width
        altoCLonar = PictureBox1.Image.Height
        If My.Settings.MensajeSegmentacion = True Then
            Segmentacion.ShowDialog()
            If Segmentacion.DialogResult = Windows.Forms.DialogResult.OK Then
                AjustarAPantallaToolStripMenuItem1_Click(sender, e)
                tipoPuntero = "segmentacion"
            End If
        Else
            AjustarAPantallaToolStripMenuItem1_Click(sender, e)
            tipoPuntero = "segmentacion"
        End If
    End Sub

    Private Sub PropiedadesToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesToolStripMenuItem2.Click
        PpiedadesSegmentacion.ShowDialog()
    End Sub


    Private Sub LápizToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LápizToolStripMenuItem2.Click
        m_lstOflapiz.Clear()
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub LíneaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LíneaToolStripMenuItem1.Click
        m_lstOfLine.Clear()
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub PolilíneaToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PolilíneaToolStripMenuItem1.Click
        m_lstOfpoli.Clear()
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CuadradoToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CuadradoToolStripMenuItem2.Click
        m_lstOfcuadra.Clear()
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub RectánguloToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RectánguloToolStripMenuItem1.Click
        m_lstOfrect.Clear()
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub CírculoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CírculoToolStripMenuItem1.Click
        m_lstOfcirc.Clear()
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub ElipseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ElipseToolStripMenuItem1.Click
        m_lstOfelip.Clear()
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub TextoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextoToolStripMenuItem1.Click
        m_lstOftexto.Clear()
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub BorrarTodoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BorrarTodoToolStripMenuItem1.Click
        m_lstOflapiz.Clear()
        m_lstOfLine.Clear()
        m_lstOfpoli.Clear()
        m_lstOfcuadra.Clear()
        m_lstOfrect.Clear()
        m_lstOfcirc.Clear()
        m_lstOfelip.Clear()
        m_lstOftexto.Clear()
        Me.WindowState = FormWindowState.Normal
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub EmpezarABorrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmpezarABorrarToolStripMenuItem.Click
        anchoClonar = PictureBox1.Image.Width
        altoCLonar = PictureBox1.Image.Height
        If My.Settings.MensajeBorrar = True Then
            MensajeBorrar.ShowDialog()
            If MensajeBorrar.DialogResult = Windows.Forms.DialogResult.OK Then
                Cargando.Show()
                objetoform.ajustarpantalla(PictureBox1, Panel1)
                objetoform.refrescar(PictureBox1, Panel1)
                Dim bmp As New Bitmap(PictureBox1.Image)
                BorrarVal = True
                PictureBox1.Image = objeto.Borrar(bmp, New Point(0, 0), , , , , , )
                tipoPuntero = "borrar"
                Cargando.Close()
            Else
                tipoPuntero = "normal"
            End If
        Else
            Cargando.Show()
            objetoform.ajustarpantalla(PictureBox1, Panel1)
            objetoform.refrescar(PictureBox1, Panel1)
            Dim bmp As New Bitmap(PictureBox1.Image)
            BorrarVal = True
            PictureBox1.Image = objeto.Borrar(bmp, New Point(0, 0), , , , , , )
            tipoPuntero = "borrar"
            Cargando.Close()
        End If
    End Sub

    Private Sub PropiedadesToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesToolStripMenuItem6.Click
        PropiedadesBorrar.ShowDialog()
    End Sub

    Private Sub VeranoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VeranoToolStripMenuItem.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.Calor(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.Calor(bmp)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.Calor(bmp)
            Cargando.Close()
        End If
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub DesiertoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesiertoToolStripMenuItem.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.desierto(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.desierto(bmp)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.desierto(bmp)
            Cargando.Close()
        End If
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub HieloToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HieloToolStripMenuItem.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.hielo(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.hielo(bmp)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.hielo(bmp)
            Cargando.Close()
        End If
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub ResaltarPaisajesNaturalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResaltarPaisajesNaturalesToolStripMenuItem.Click
        bmp = PictureBox1.Image
        If My.Settings.vistapr = True Then
            Dim bmpaux As New Bitmap(bmp, New Size(VistaPrevia.PictureBox1.Width, VistaPrevia.PictureBox1.Height)) 'Datos del Bitmap pequeño (para la ventana auxiliar)
            VistaPrevia.PictureBox1.Image = objeto.naturaleza(bmpaux) 'Lazamos vista previa y asignamos imagen
            VistaPrevia.ShowDialog()
            If aceptar = True Then 'Si el usuario acepta
                Cargando.Show()
                PictureBox1.Image = objeto.naturaleza(bmp)
                Cargando.Close()
            End If
            aceptar = False
        Else
            Cargando.Show()
            PictureBox1.Image = objeto.naturaleza(bmp)
            Cargando.Close()
        End If
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub AbrirMóduloTransformaciónAfínToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirMóduloTransformaciónAfínToolStripMenuItem.Click
        bmpAfin = PictureBox1.Image
        SeleccionAfin.ShowDialog()

        If afinImagen = True Then
            PictureBox1.Image = bmpAfinRetorno
        End If
        afinImagen = False
        If afinImagenper = True Then
            PictureBox1.Image = bmpAfinRetornoPer
        End If
        afinImagenper = False
        objetoform.refrescar(PictureBox1, Panel1)

    End Sub

    Private Sub AbrirMóduloDeTransformaciónAfínToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirMóduloDeTransformaciónAfínToolStripMenuItem.Click
        AbrirMóduloTransformaciónAfínToolStripMenuItem_Click(sender, e)
    End Sub


    Private Sub SesgarImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SesgarImagenToolStripMenuItem.Click
        bmpAfin = PictureBox1.Image
        Afin.ShowDialog()

        If afinImagen = True Then
            PictureBox1.Image = bmpAfinRetorno
        End If
        afinImagen = False

        objetoform.refrescar(PictureBox1, Panel1)
    End Sub


    Private Sub EnviarFeedbackToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarFeedbackToolStripMenuItem.Click
        Dim proceso As New System.Diagnostics.Process
        With proceso
            .StartInfo.FileName = "http://algoimagen.blogspot.com.es/2012/07/feedback.html"
            .Start()
        End With
    End Sub

    Private Sub CineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CineToolStripMenuItem.Click
        ImgCINE = PictureBox1.Image
        Cine.ShowDialog()
        If ImgCINEtrasf IsNot Nothing Then
            PictureBox1.Image = ImgCINEtrasf
        End If
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub AsdToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AsdToolStripMenuItem.Click
        Dim bmp = PictureBox1.Image
        Dim objeto As New tratamiento
        PictureBox1.Image = objeto.marco(bmp, 0)
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub Marco2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Marco2ToolStripMenuItem.Click
        Dim bmp = PictureBox1.Image
        Dim objeto As New tratamiento
        PictureBox1.Image = objeto.marco(bmp, 1)
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub Marco3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Marco3ToolStripMenuItem.Click
        Dim bmp = PictureBox1.Image
        Dim objeto As New tratamiento
        PictureBox1.Image = objeto.marco(bmp, 2)
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub

    Private Sub Marco4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Marco4ToolStripMenuItem.Click
        Dim bmp = PictureBox1.Image
        Dim objeto As New tratamiento
        PictureBox1.Image = objeto.marco(bmp, 3)
        objetoform.refrescar(PictureBox1, Panel1)
    End Sub
End Class

