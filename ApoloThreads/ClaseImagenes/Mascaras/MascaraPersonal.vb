Imports ClaseImagenes.Apolo

Public Class MascaraPersonal

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal


    Sub CrearcuadrosTexto(ByVal NumeroCuadros As Integer)
        Panel1.Controls.Clear()
        Dim listatexbox(,) As TextBox
        ReDim listatexbox(NumeroCuadros - 1, NumeroCuadros - 1)
        Dim ancho, alto As Integer
        ancho = 1 : alto = 1
        For i = 0 To NumeroCuadros - 1
            For j = 0 To NumeroCuadros - 1
                listatexbox(i, j) = New TextBox
                With listatexbox(i, j)
                    .Size = New Size(25, 20)
                    .Name = "TextBox" & i & j
                    .Location = New Size(ancho, alto)
                End With
                Me.Panel1.Controls.Add(listatexbox(i, j))
                ancho += 30
            Next
            alto += 25
            ancho = 1
        Next
        RellenarCuadrosTexto(ComboBox2.SelectedItem)
    End Sub
    Sub RellenarCuadrosTexto(ByVal numeroRelleno As Integer)
        For Each c As Control In Panel1.Controls
            If TypeOf c Is TextBox Then
                c.Text = numeroRelleno
            End If
        Next
    End Sub
    Private Function ObtenerValores(ByVal matriz(,) As Double)
        Dim valoresTextBox As New ArrayList

        For Each c As Control In Panel1.Controls
            If TypeOf c Is TextBox Then
                valoresTextBox.Add(c.Text)
            End If
        Next

        Dim contador As Integer = 0
        For i = 0 To matriz.GetUpperBound(0)
            For j = 0 To matriz.GetUpperBound(0)
                matriz(i, j) = valoresTextBox(contador)
                contador += 1
            Next
        Next
        Return matriz
    End Function
    Private Function comprobarValores()
        For Each c As Control In Panel1.Controls
            If TypeOf c Is TextBox Then
                If IsNumeric(c.Text) = False Then
                    MessageBox.Show("Algo ha ocurrido. Revise los valores de la matriz y asegúrese de que todos son números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            End If
        Next
        Return True
    End Function
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        CrearcuadrosTexto(ComboBox1.SelectedItem)
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        RellenarCuadrosTexto(ComboBox2.SelectedItem)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

        ComboBox1.SelectedIndex = 3
        For i = -100 To 100
            ComboBox2.Items.Add(i)
        Next
        ComboBox2.SelectedIndex = 101
    End Sub


    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtDesvi.Enabled = True
        Else
            txtDesvi.Enabled = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            txtFact.Enabled = True
        Else
            txtFact.Enabled = False
        End If
    End Sub





    Dim matrizValores(,) As Double
    Dim factor As Integer
    Dim desviacion As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If BackgroundWorker1.IsBusy = False And comprobarValores() = True Then
            If CheckBox1.Checked = True Then
                If IsNumeric(txtFact.Text) Then
                    factor = txtFact.Text
                Else
                    MessageBox.Show("El valor factor no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Else
                factor = 1
            End If

            If CheckBox2.Checked = True Then
                If IsNumeric(txtDesvi.Text) Then
                    desviacion = txtDesvi.Text
                Else
                    MessageBox.Show("El valor desviación no es correcto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Exit Sub
                End If
            Else
                desviacion = 0
            End If

            Panel1.Enabled = False
            Panel2.Enabled = False
            Dim matrizMascara(ComboBox1.SelectedItem - 1, ComboBox1.SelectedItem - 1) As Double
            matrizValores = ObtenerValores(matrizMascara)
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Principal.PictureBox1.Image = objetoTratamiento.mascaraManualRGB(bmpP, matrizValores, desviacion, factor)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Panel1.Enabled = True
        Panel2.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class
