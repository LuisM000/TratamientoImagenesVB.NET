Imports ClaseImagenes.Apolo
Public Class BordesYContornos

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim objetoMascaras As New TratamientoImagenes.mascaras 'Instancia a la clase TratamientoImagenes.mascaras
    Dim bmpP As New Bitmap(Principal.PictureBox1.Image) 'Imagen de principal
    Dim coefmascara(2, 2) As Double 'Máscara


    Private Sub BordesYContornos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RbRGB.Checked = False
        RBGrises.Checked = True
        ListBox1.SelectedIndex = 0
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

    End Sub





    Private Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        If TextBox2.Text = "Buscador de máscaras" Then
            TextBox2.Text = "" 'Borramos contenido
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim returnValue As Boolean
        Dim comparisonType As StringComparison
        For i = ListBox1.Items.Count - 1 To 0 Step -1
            returnValue = LCase(ListBox1.Items(i)).StartsWith(LCase(TextBox2.Text), comparisonType)
            If returnValue = True Then
                ListBox1.ClearSelected() 'Borramos las selecciones anteriores
                TextBox2.Focus() 'Establecemos el foco en el texbox
                ListBox1.SetSelected(i, True)
            End If
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            ListBox1.Enabled = False
            TextBox2.Enabled = False
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Sub actualizarTexto()
        TextBox1.Text = "  (" & coefmascara(0, 0) & vbTab & coefmascara(0, 1) & vbTab & coefmascara(0, 2) & " )" & vbCrLf &
        "  (" & coefmascara(1, 0) & vbTab & coefmascara(1, 1) & vbTab & coefmascara(1, 2) & " )" & vbCrLf &
         "  (" & coefmascara(2, 0) & vbTab & coefmascara(2, 1) & vbTab & coefmascara(2, 2) & " )" & vbCrLf
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If BackgroundWorker1.IsBusy = False Then
            valor = 0
            Select Case ListBox1.SelectedIndex
                Case 0
                    coefmascara = objetoMascaras.Resta1()
                Case 1
                    coefmascara = objetoMascaras.Resta2()
                Case 2
                    coefmascara = objetoMascaras.Resta3()
                Case 3
                    coefmascara = objetoMascaras.Laplaciana1()
                Case 4
                    coefmascara = objetoMascaras.Laplaciana2()
                Case 5
                    coefmascara = objetoMascaras.Laplaciana3()
                Case 6
                    coefmascara = objetoMascaras.Laplaciana4()
                Case 7
                    coefmascara = objetoMascaras.LaplacianaHorizont()
                Case 8
                    coefmascara = objetoMascaras.LaplacianaVertical()
                Case 9
                    coefmascara = objetoMascaras.LaplacianaDiagonal()
                Case 10
                    coefmascara = objetoMascaras.GradienteEste()
                Case 11
                    coefmascara = objetoMascaras.GradienteSudeste()
                Case 12
                    coefmascara = objetoMascaras.GradienteSur()
                Case 13
                    coefmascara = objetoMascaras.GradienteOeste()
                Case 14
                    coefmascara = objetoMascaras.GradienteNoreste()
                Case 15
                    coefmascara = objetoMascaras.GradienteNorte()
                Case 16
                    coefmascara = objetoMascaras.EmbossingEste()
                Case 17
                    coefmascara = objetoMascaras.EmbossingSudeste()
                Case 18
                    coefmascara = objetoMascaras.EmbossingSur()
                Case 19
                    coefmascara = objetoMascaras.EmbossingOeste()
                Case 20
                    coefmascara = objetoMascaras.EmbossingNoreste()
                Case 21
                    coefmascara = objetoMascaras.EmbossingNorte()
                Case 22
                    coefmascara = objetoMascaras.SobelH()
                Case 23
                    coefmascara = objetoMascaras.SobelV()
                Case 24
                    coefmascara = objetoMascaras.SobelDiagonal1()
                Case 25
                    coefmascara = objetoMascaras.SobelDiagonal2()
                Case 26
                    coefmascara = objetoMascaras.SobelH()
                    valor = 1
                Case 27
                    coefmascara = objetoMascaras.SobelV()
                    valor = 1
                Case 28
                    coefmascara = objetoMascaras.SobelDiagonal1()
                    valor = 1
                Case 29
                    coefmascara = objetoMascaras.SobelDiagonal2()
                    valor = 1
                Case 30
                    coefmascara = objetoMascaras.PrewittHoriz
                Case 31
                    coefmascara = objetoMascaras.PrewittVert()
                Case 32
                    coefmascara = objetoMascaras.PrewittDiag1()
                Case 33
                    coefmascara = objetoMascaras.PrewittDiag2()
                Case 34
                    coefmascara = objetoMascaras.PrewittHoriz
                    valor = 2
                Case 35
                    coefmascara = objetoMascaras.PrewittVert()
                    valor = 2
                Case 36
                    coefmascara = objetoMascaras.PrewittDiag1()
                    valor = 2
                Case 37
                    coefmascara = objetoMascaras.PrewittDiag2()
                    valor = 2
                Case 38
                    coefmascara = objetoMascaras.LineasHorizontales()
                Case 39
                    coefmascara = objetoMascaras.LineasVerticales()
                Case 40
                    coefmascara = objetoMascaras.Repujado()
                Case 41
                    coefmascara = objetoMascaras.Kirsch0()
                Case 42
                    coefmascara = objetoMascaras.Kirsch45()
                Case 43
                    coefmascara = objetoMascaras.Kirsch90()
                Case 44
                    coefmascara = objetoMascaras.Kirsch135()
                Case 45
                    coefmascara = objetoMascaras.Kirsch180()
                Case 46
                    coefmascara = objetoMascaras.Kirsch225()
                Case 47
                    coefmascara = objetoMascaras.Kirsch270()
                Case 48
                    coefmascara = objetoMascaras.Kirsch315()
                Case 49
                    coefmascara = objetoMascaras.FreichenHori()
                    valor = 3
                Case 50
                    coefmascara = objetoMascaras.FreichenVert()
                    valor = 3
            End Select
            actualizarTexto()
        End If
    End Sub

    Dim valor = 0
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If RBGrises.Checked = True Then
            If valor = 1 Then 'Sobel
                Principal.PictureBox1.Image = objetoTratamiento.mascara3x3Grises(bmpP, coefmascara, 0, 4)
            ElseIf valor = 2 Then 'Previewtt
                Principal.PictureBox1.Image = objetoTratamiento.mascara3x3Grises(bmpP, coefmascara, 0, 3)
            ElseIf valor = 3 Then 'Frei-Chen
                Dim cuenta = 1 / (2 + Math.Sqrt(2))
                Principal.PictureBox1.Image = objetoTratamiento.mascara3x3Grises(bmpP, coefmascara, 0, cuenta)
            Else
                Principal.PictureBox1.Image = objetoTratamiento.mascara3x3Grises(bmpP, coefmascara)
            End If
        Else
            If valor = 1 Then 'Sobel
                Principal.PictureBox1.Image = objetoTratamiento.mascara3x3RGB(bmpP, coefmascara, 0, 4)
            ElseIf valor = 2 Then 'Previewtt
                Principal.PictureBox1.Image = objetoTratamiento.mascara3x3RGB(bmpP, coefmascara, 0, 3)
            ElseIf valor = 3 Then 'Frei-Chen
                Dim cuenta = 1 / (2 + Math.Sqrt(2))
                Principal.PictureBox1.Image = objetoTratamiento.mascara3x3RGB(bmpP, coefmascara, 0, cuenta)
            Else
                Principal.PictureBox1.Image = objetoTratamiento.mascara3x3RGB(bmpP, coefmascara)
            End If
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ListBox1.Enabled = True
        TextBox2.Enabled = True
    End Sub
End Class