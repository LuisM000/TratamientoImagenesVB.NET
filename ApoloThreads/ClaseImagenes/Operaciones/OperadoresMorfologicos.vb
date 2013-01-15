Imports System.IO
Imports System.Xml.XPath
Imports System.Xml
Imports ClaseImagenes.Apolo
Public Class OperadoresMorfologicos
    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox1.Image) 'Imagen de principal
    Dim elementoEstructural(,) As Integer 'Matriz de elemento estructural
    Dim imagenOriginal As New Bitmap(Principal.PictureBox1.Image)
    Dim transformacion As String 'Con esto controlamos la transformación a realizar
    Sub inhabilitarControles()
        ListBox1.Enabled = False
        Button14.Enabled = False
    End Sub

    Private Sub OperadoresMorfologicos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
        ListBox1.SelectedIndex = 0
        Label4.Text = HScrollBar1.Value
        Label6.Text = HScrollBar2.Value
    End Sub


  
#Region "Creación y selección del elemento estructural"
    'Seleccionamos el elemento estructural desde le listbox
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If BackgroundWorker1.IsBusy = False Then
            Dim objetoTratamientoElemEstruc As New TratamientoImagenes.ElementoEstructural
            Select Case ListBox1.SelectedIndex
                Case 0
                    ReDim elementoEstructural(2, 2)
                    elementoEstructural = objetoTratamientoElemEstruc.Cuadrado3x3
                Case 1
                    ReDim elementoEstructural(4, 4)
                    elementoEstructural = objetoTratamientoElemEstruc.Cuadrado5x5
                Case 2
                    ReDim elementoEstructural(6, 6)
                    elementoEstructural = objetoTratamientoElemEstruc.Cuadrado7x7
                Case 3
                    ReDim elementoEstructural(8, 8)
                    elementoEstructural = objetoTratamientoElemEstruc.Cuadrado9x9
                Case 4
                    ReDim elementoEstructural(2, 2)
                    elementoEstructural = objetoTratamientoElemEstruc.DiagonalA3x3
                Case 5
                    ReDim elementoEstructural(4, 4)
                    elementoEstructural = objetoTratamientoElemEstruc.DiagonalA5x5
                Case 6
                    ReDim elementoEstructural(6, 6)
                    elementoEstructural = objetoTratamientoElemEstruc.DiagonalA7x7
                Case 7
                    ReDim elementoEstructural(8, 8)
                    elementoEstructural = objetoTratamientoElemEstruc.DiagonalA9x9
                Case 8
                    ReDim elementoEstructural(2, 2)
                    elementoEstructural = objetoTratamientoElemEstruc.DiagonalB3x3
                Case 9
                    ReDim elementoEstructural(4, 4)
                    elementoEstructural = objetoTratamientoElemEstruc.DiagonalB5x5
                Case 10
                    ReDim elementoEstructural(6, 6)
                    elementoEstructural = objetoTratamientoElemEstruc.DiagonalB7x7
                Case 11
                    ReDim elementoEstructural(8, 8)
                    elementoEstructural = objetoTratamientoElemEstruc.DiagonalB9x9
                Case 12
                    ReDim elementoEstructural(2, 2)
                    elementoEstructural = objetoTratamientoElemEstruc.Diamante3x3
                Case 13
                    ReDim elementoEstructural(4, 4)
                    elementoEstructural = objetoTratamientoElemEstruc.Diamante5x5
                Case 14
                    ReDim elementoEstructural(6, 6)
                    elementoEstructural = objetoTratamientoElemEstruc.Diamante7x7
                Case 15
                    ReDim elementoEstructural(8, 8)
                    elementoEstructural = objetoTratamientoElemEstruc.Diamante9x9
                Case 16
                    ReDim elementoEstructural(4, 4)
                    elementoEstructural = objetoTratamientoElemEstruc.Disco5x5
                Case 17
                    ReDim elementoEstructural(6, 6)
                    elementoEstructural = objetoTratamientoElemEstruc.Disco7x7
                Case 18
                    ReDim elementoEstructural(8, 8)
                    elementoEstructural = objetoTratamientoElemEstruc.Disco9x9
            End Select
            actualizarTexto()
        End If
    End Sub
    'Escribimos en el texbox el elemento estructural
    Sub actualizarTexto()
        TextBox1.Text = ""
        For i = 0 To UBound(elementoEstructural)
            For j = 0 To UBound(elementoEstructural)
                TextBox1.Text = TextBox1.Text & elementoEstructural(i, j)
                TextBox1.Text = TextBox1.Text & "  "
            Next
            TextBox1.Text = TextBox1.Text & vbCrLf
        Next
    End Sub
    'Creamos elemento estructural cuadrado personalizado
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        txtalto.BackColor = Color.White
        txtancho.BackColor = Color.White
        If IsNumeric(txtancho.Text) And IsNumeric(txtalto.Text) Then 'Si son números
            'Si es cuadrada la matriz e impar
            If (CInt(txtalto.Text) = CInt(txtancho.Text)) And (CInt(txtalto.Text) Mod 2 <> 0 And CInt(txtancho.Text) Mod 2 <> 0) Then
                If txtalto.Text < 30 Then 'Acotamos la matriz para que no sea excesivamente grande
                    Dim objetoTratamientoElemEstruc As New TratamientoImagenes.ElementoEstructural
                    ReDim elementoEstructural(CInt(txtancho.Text - 1), CInt(txtalto.Text - 1))
                    elementoEstructural = objetoTratamientoElemEstruc.CuadradoPersonal(CInt(txtancho.Text))
                    actualizarTexto()
                Else
                    MessageBox.Show("El elemento estructural debe ser inferior a 30", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else 'Si la matriz no es cuadrada
                MessageBox.Show("El elemento estructural debe ser cuadrado e impar (3x3, 5x5)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else 'Si alguno de los dos no es número pintamos de rojo
            If IsNumeric(txtancho.Text) = False Then
                txtancho.BackColor = Color.Red
            End If
            If IsNumeric(txtalto.Text) = False Then
                txtalto.BackColor = Color.Red
            End If
        End If
    End Sub
#End Region

    'Manejo de los scrollbars
    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Label4.Text = HScrollBar1.Value
    End Sub
    'Manejo de los scrollbars
    Private Sub HScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar2.Scroll
        Label6.Text = HScrollBar2.Value
    End Sub


    'Pasa a blanco y negro y guarda la imagen
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If BackgroundWorker1.IsBusy = False Then
            transformacion = "B/N"
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    'Pasa a grises y guarda la imagen
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If BackgroundWorker1.IsBusy = False Then
            transformacion = "gris"
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub


    'Actuar sobre imagen actual
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If BackgroundWorker1.IsBusy = False Then
            bmpP = Principal.PictureBox1.Image
        End If
    End Sub



    'Manejo de hilo
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Select Case transformacion
            Case "B/N"
                Principal.PictureBox1.Image = objetoTratamiento.BlancoNegro(imagenOriginal, HScrollBar1.Value)
            Case "gris"
                Principal.PictureBox1.Image = objetoTratamiento.EscalaGrises(imagenOriginal, HScrollBar2.Value)
            Case "Dilatacion"
                Principal.PictureBox1.Image = objetoTratamiento.MorfologicasDilatacion(bmpP, elementoEstructural)
            Case "Erosion"
                Principal.PictureBox1.Image = objetoTratamiento.MorfologicasErosion(bmpP, elementoEstructural)
            Case "Original"
                Principal.PictureBox1.Image = objetoTratamiento.ActualizarImagen(imagenOriginal)
            Case "BottomHat"
                Principal.PictureBox1.Image = objetoTratamiento.MorfologicasBottomHat(bmpP, elementoEstructural)
            Case "TopHat"
                Principal.PictureBox1.Image = objetoTratamiento.MorfologicasTopHat(bmpP, elementoEstructural)
            Case "PerimetroD-O"
                Principal.PictureBox1.Image = objetoTratamiento.MorfologicasPerimetroDilatOrigin(bmpP, elementoEstructural)
            Case "PerimetroO-E"
                Principal.PictureBox1.Image = objetoTratamiento.MorfologicasPerimetroOrigEros(bmpP, elementoEstructural)
            Case "PerimetroD-E"
                Principal.PictureBox1.Image = objetoTratamiento.MorfologicasPerimetroDilatEros(bmpP, elementoEstructural)
            Case "Cerradura"
                Principal.PictureBox1.Image = objetoTratamiento.MorfologicasCerradura(bmpP, elementoEstructural)
            Case "Apertura"
                Principal.PictureBox1.Image = objetoTratamiento.MorfologicasApertura(bmpP, elementoEstructural)
        End Select
    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ListBox1.Enabled = True
        Button14.Enabled = True
    End Sub


    'Dilatación
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            transformacion = "Dilatacion"
            inhabilitarControles()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    'Erosión
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If BackgroundWorker1.IsBusy = False Then
            transformacion = "Erosion"
            inhabilitarControles()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    'Imagen original
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If BackgroundWorker1.IsBusy = False Then
            transformacion = "Original"
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    'Bottom hat
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If BackgroundWorker1.IsBusy = False Then
            transformacion = "BottomHat"
            inhabilitarControles()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    'Top hat
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If BackgroundWorker1.IsBusy = False Then
            transformacion = "TopHat"
            inhabilitarControles()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    'Perímetro dilatación - original
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If BackgroundWorker1.IsBusy = False Then
            transformacion = "PerimetroD-O"
            inhabilitarControles()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    'Perímetro original - erosión
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If BackgroundWorker1.IsBusy = False Then
            transformacion = "PerimetroO-E"
            inhabilitarControles()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    'perímetro dilatación - erosión
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If BackgroundWorker1.IsBusy = False Then
            transformacion = "PerimetroD-E"
            inhabilitarControles()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    'Cerradura
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If BackgroundWorker1.IsBusy = False Then
            transformacion = "Cerradura"
            inhabilitarControles()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    'Apertura
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If BackgroundWorker1.IsBusy = False Then
            transformacion = "Apertura"
            inhabilitarControles()
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    'Importar/Exportar elemento estructural personalizado
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        ImportarExportarElementoEstructural.ShowDialog()
        'Si el usuario carga algo...
        If ImportarExportarElementoEstructural.ElementoFormato IsNot Nothing Then
            elementoEstructural = ImportarExportarElementoEstructural.ElementoFormato
            actualizarTexto()
        End If
    End Sub

  
End Class
