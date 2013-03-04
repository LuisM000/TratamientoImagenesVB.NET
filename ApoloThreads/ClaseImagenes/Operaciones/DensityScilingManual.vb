Imports ClaseImagenes.Apolo

Public Class DensityScilingManual

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal
    Dim MatrizRangos(,) As Integer 'Matriz con los rangos
    Dim VectColores() As Color 'Vector con los colores para cada tramo

    Private Sub DensityScilingManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel1.Enabled = False
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
    End Sub

    'Boton de OK
    Dim valorActual As Integer  'Indica en qué tramo estamos
    Dim numeroDivisiones As Integer 'Número de divisiones
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        valorActual = 0
        numeroDivisiones = numericDivision.Value
        restoAcumulado = 0

        Panel1.Enabled = True
        lbltramo.Text = "Tramo 1"
        TextBox1.Text = ""

        btnColor.BackColor = ObtenerColor(15)
        NumerInicio.Value = 0
        NumerFin.Value = CInt(256 \ numericDivision.Value)

        'Redimensionamos los arrays en función del número de tramos
        ReDim MatrizRangos(numericDivision.Value - 1, 1)
        ReDim VectColores(numericDivision.Value - 1)
    End Sub

    'Botón de añadir
    Dim restoAcumulado As Double
    Private Sub btnAnadir_Click(sender As Object, e As EventArgs) Handles btnAnadir.Click
        valorActual += 1
        Dim cuentaConDecimales As Double = (256 / numeroDivisiones)
        Dim parteDecimal() As String = cuentaConDecimales.ToString.Split(".")
        If parteDecimal.Length = 2 Then 'Si hay decimales
            parteDecimal(1) = "0." & parteDecimal(1)
            restoAcumulado = restoAcumulado + parteDecimal(1)
        End If


        If valorActual = 1 Then
            Dim colorbtn As Integer = btnColor.BackColor.ToArgb
            TextBox1.Text += NumerInicio.Value & "," & NumerFin.Value & "," & colorbtn & ","
            btnColor.BackColor = ObtenerColor(valorActual + 1)
            lbltramo.Text = "Tramo " & valorActual
            btnColor.BackColor = ObtenerColor(valorActual)
            lbltramo.Text = "Tramo " & valorActual
            NumerInicio.Value = NumerFin.Value + 1
            Dim valorAux As Integer
            If restoAcumulado >= 1 Then
                valorAux = NumerFin.Value + CInt((256 \ numeroDivisiones)) + restoAcumulado
            Else
                valorAux = NumerFin.Value + CInt((256 \ numeroDivisiones))
            End If

            If valorAux >= 253 Then valorAux = 255
            NumerFin.Value = valorAux
        ElseIf valorActual <= numeroDivisiones Then
            Dim colorbtn As Integer = btnColor.BackColor.ToArgb
            TextBox1.Text += vbCrLf
            TextBox1.Text += NumerInicio.Value & "," & NumerFin.Value & "," & colorbtn & ","
            Try
                btnColor.BackColor = ObtenerColor(valorActual + 1)
                btnColor.BackColor = ObtenerColor(valorActual)
                lbltramo.Text = "Tramo " & valorActual
                NumerInicio.Value = NumerFin.Value + 1
                Dim valorAux As Integer
                If restoAcumulado >= 1 Then
                    valorAux = NumerFin.Value + CInt((256 \ numeroDivisiones)) + restoAcumulado
                Else
                    valorAux = NumerFin.Value + CInt((256 \ numeroDivisiones))
                End If

                If valorAux >= 253 Then valorAux = 255
                NumerFin.Value = valorAux
            Catch
            End Try
        End If
        If restoAcumulado >= 1 Then restoAcumulado = 0
    End Sub

    Private Sub btnColor_Click(sender As Object, e As EventArgs) Handles btnColor.Click
        Dim dcol As New ColorDialog
        dcol.ShowDialog()
        btnColor.BackColor = dcol.Color
    End Sub

    Function ObtenerColor(ByVal numero As Integer) As Color
        Select Case numero
            Case 1
                Return Color.FromName("Red")
            Case 2
                Return Color.FromName("Green")
            Case 3
                Return Color.FromName("Blue")
            Case 4
                Return Color.FromName("Black")
            Case 5
                Return Color.FromName("White")
            Case 6
                Return Color.FromName("Yellow")
            Case 7
                Return Color.FromName("Maroon")
            Case 8
                Return Color.FromName("Gray")
            Case 9
                Return Color.FromName("LightGreen")
            Case 10
                Return Color.FromName("LightBlue")
            Case 11
                Return Color.FromName("Orange")
            Case 12
                Return Color.FromName("Pink")
            Case 13
                Return Color.FromName("Gold")
            Case 14
                Return Color.FromName("DarkBlue")
            Case 15
                Return Color.FromName("DarkGreen")

        End Select
    End Function


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim texto() As String
            TextBox1.Text = TextBox1.Text.Replace(" ", "")
            texto = TextBox1.Text.Split(",")

            Dim contador As Integer = 0
            For i = 0 To texto.GetUpperBound(0) Step 3
                If texto(i) <> "" Then
                    MatrizRangos(contador, 0) = texto(i)
                    contador += 1
                End If
            Next
            contador = 0
            For i = 1 To texto.GetUpperBound(0) Step 3
                If texto(i) <> "" Then
                    MatrizRangos(contador, 1) = texto(i)
                    contador += 1
                End If
            Next
            contador = 0
            For i = 2 To texto.GetUpperBound(0) Step 3
                If texto(i) <> "" Then
                    VectColores(contador) = Color.FromArgb(texto(i))
                    contador += 1
                End If
            Next
            If BackgroundWorker1.IsBusy = False Then
                BackgroundWorker1.RunWorkerAsync()
            End If
        Catch
            MessageBox.Show("Algo ha ocurrido. Por favor, revise que el cuadro de texto tiene el formato correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Principal.PictureBox1.Image = objetoTratamiento.DensitySlicing(bmpP, MatrizRangos, VectColores)
    End Sub
End Class