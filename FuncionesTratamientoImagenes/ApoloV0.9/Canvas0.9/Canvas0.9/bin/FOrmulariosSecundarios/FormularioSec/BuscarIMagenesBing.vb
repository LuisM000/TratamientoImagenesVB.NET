Imports WindowsApplication1.Class2
Imports WindowsApplication1.Class1

Public Class BuscarIMagenesBing
    Dim contador = 0
    Dim numeroAbrir As Integer = 0
    Dim datos As New ArrayList
    Public thIMG As Threading.Thread

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
            Dim objeto As New trataformu
            Dim objeto2 As New tratamiento
            Dim precarga = False
            If CheckBox1.Checked = True Then
                precarga = True
            Else
                precarga = False
            End If
            Button2.Enabled = True
            Select Case ComboBox1.SelectedIndex
                Case -1
                    datos = objeto.BuscarImagenes(TextBox1.Text, 50, , precarga)
                Case 0
                    datos = objeto.BuscarImagenes(TextBox1.Text, 50, , precarga)
                Case 1
                    datos = objeto.BuscarImagenes(TextBox1.Text, 50, "Small", precarga)
                Case 2
                    datos = objeto.BuscarImagenes(TextBox1.Text, 50, "Medium", precarga)
                Case 3
                    datos = objeto.BuscarImagenes(TextBox1.Text, 50, "Large", precarga)
                Case Else
                    datos = objeto.BuscarImagenes(TextBox1.Text, 50, , precarga)
            End Select
        End If
        Me.Cursor = Cursors.AppStarting
    End Sub

    Sub resultados()

        Try
            Dim objeto2 As New tratamiento
            PictureBox1.Image = objeto2.cargarrecursoweb(datos(0 + contador).ToString)
            PictureBox2.Image = objeto2.cargarrecursoweb(datos(1 + contador).ToString)
            PictureBox3.Image = objeto2.cargarrecursoweb(datos(2 + contador).ToString)
            PictureBox4.Image = objeto2.cargarrecursoweb(datos(3 + contador).ToString)
            PictureBox5.Image = objeto2.cargarrecursoweb(datos(4 + contador).ToString)
            PictureBox6.Image = objeto2.cargarrecursoweb(datos(5 + contador).ToString)
            PictureBox7.Image = objeto2.cargarrecursoweb(datos(6 + contador).ToString)
            PictureBox8.Image = objeto2.cargarrecursoweb(datos(7 + contador).ToString)
            PictureBox10.Image = objeto2.cargarrecursoweb(datos(8 + contador).ToString)
            PictureBox11.Image = objeto2.cargarrecursoweb(datos(9 + contador).ToString)
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

    Private Sub BuscarIMagenesBing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        url = ""
        IMGBing = Nothing
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


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        IMGBing = Nothing
        url = ""
        If numeroAbrir <> 0 Then
            If CheckBox1.Checked = False Then
                Select Case numeroAbrir
                    Case 1
                        url = datos2(0 + contador)
                    Case 2
                        url = datos2(1 + contador)
                    Case 3
                        url = datos2(2 + contador)
                    Case 4
                        url = datos2(3 + contador)
                    Case 5
                        url = datos2(4 + contador)
                    Case 6
                        url = datos2(5 + contador)
                    Case 7
                        url = datos2(6 + contador)
                    Case 8
                        url = datos2(7 + contador)
                    Case 9
                        url = datos2(8 + contador)
                    Case 10
                        url = datos2(9 + contador)
                End Select
            Else
                Select Case numeroAbrir
                    Case 1
                        IMGBing = PictureBox1.Image
                    Case 2
                        IMGBing = PictureBox2.Image
                    Case 3
                        IMGBing = PictureBox3.Image
                    Case 4
                        IMGBing = PictureBox4.Image
                    Case 5
                        IMGBing = PictureBox5.Image
                    Case 6
                        IMGBing = PictureBox6.Image
                    Case 7
                        IMGBing = PictureBox7.Image
                    Case 8
                        IMGBing = PictureBox8.Image
                    Case 9
                        IMGBing = PictureBox10.Image
                    Case 10
                        IMGBing = PictureBox11.Image
                End Select
            End If
            Me.Close()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Me.Height < 490 Then
            Me.Height = Me.Height + 50
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        Timer2.Enabled = True 'Para que se marque la casilla
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        comprobar()
        thIMG = New Threading.Thread(AddressOf resultados)
        If thIMG.ThreadState <> Threading.ThreadState.Running Then
            thIMG.Start()
        End If
        Timer2.Enabled = False
    End Sub

  
End Class