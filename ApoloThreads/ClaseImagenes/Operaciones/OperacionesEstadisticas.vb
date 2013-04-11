Imports ClaseImagenes.Apolo
Public Class OperacionesEstadisticas

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal
    Dim ladoCuadrado As Integer = 1
    Dim valorListBox As Integer = 0

    Private Sub OperacionesEstadisticas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        ListBox1.SelectedIndex = 0
        valorListBox = 0
        ladoCuadrado = ComboBox1.SelectedIndex + 1
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            valorListBox = ListBox1.SelectedIndex
            ladoCuadrado = ComboBox1.SelectedIndex + 1
            If valorListBox = 2 And ladoCuadrado > 5 Then 'La media geométrica no permita valores mayores de 11
                MessageBox.Show("El valor máximo permitido para el lado del cuadrado en la media geométrica es de 11.", "Apolo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                ListBox1.Enabled = False
                BackgroundWorker1.RunWorkerAsync()
            End If
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Select Case valorListBox
            Case 0 'media aritmética
                Principal.PictureBox1.Image = objetoTratamiento.EstadisticoMedia(bmpP, ladoCuadrado)
            Case 1 'media armónica
                Principal.PictureBox1.Image = objetoTratamiento.EstadisticoMediaArmonica(bmpP, ladoCuadrado)
            Case 2 'media geométrica
                Principal.PictureBox1.Image = objetoTratamiento.EstadisticoMediaGeométrica(bmpP, ladoCuadrado)
            Case 3 'mediana
                Principal.PictureBox1.Image = objetoTratamiento.EstadisticoMediana(bmpP, ladoCuadrado)
            Case 4 'moda 
                Principal.PictureBox1.Image = objetoTratamiento.EstadisticoModa(bmpP, ladoCuadrado)
            Case 5 'rango
                Principal.PictureBox1.Image = objetoTratamiento.EstadisticoRango(bmpP, ladoCuadrado)

        End Select
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ListBox1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class