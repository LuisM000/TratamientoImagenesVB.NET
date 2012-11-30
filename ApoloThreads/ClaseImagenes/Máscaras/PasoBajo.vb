Imports ClaseImagenes.Apolo
Public Class PasoBajo
    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim objetoMascaras As New TratamientoImagenes.mascaras 'Instancia a la clase TratamientoImagenes.mascaras
    Dim bmpP As New Bitmap(Principal.PictureBox1.Image) 'Imagen de principal
    Dim coefmascara(3, 3) As Double 'Máscara

    Private Sub PasoBajo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RbRGB.Checked = True
        RBGrises.Checked = False
        ListBox1.SelectedIndex = 0
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If BackgroundWorker1.IsBusy = False Then
            Select Case ListBox1.SelectedIndex
                Case 0
                    coefmascara = objetoMascaras.LOW9()
                Case 1
                    coefmascara = objetoMascaras.LOW10()
                Case 2
                    coefmascara = objetoMascaras.LOW12()
            End Select
            actualizarTexto()
        End If
    End Sub
    Sub actualizarTexto()
        TextBox1.Text = "  (" & coefmascara(0, 0) & vbTab & coefmascara(0, 1) & vbTab & coefmascara(0, 2) & " )" & vbCrLf &
        "  (" & coefmascara(1, 0) & vbTab & coefmascara(1, 1) & vbTab & coefmascara(1, 2) & " )" & vbCrLf &
         "  (" & coefmascara(2, 0) & vbTab & coefmascara(2, 1) & vbTab & coefmascara(2, 2) & " )" & vbCrLf
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        If RBGrises.Checked = True Then
            Principal.PictureBox1.Image = objetoTratamiento.mascara3x3Grises(bmpP, coefmascara)
        Else
            Principal.PictureBox1.Image = objetoTratamiento.mascara3x3RGB(bmpP, coefmascara)
        End If
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ListBox1.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class