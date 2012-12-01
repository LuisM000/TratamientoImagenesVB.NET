Imports ClaseImagenes.Apolo
Public Class BordesYContornos

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim objetoMascaras As New TratamientoImagenes.mascaras 'Instancia a la clase TratamientoImagenes.mascaras
    Dim bmpP As New Bitmap(Principal.PictureBox1.Image) 'Imagen de principal
    Dim coefmascara(3, 3) As Double 'Máscara


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

End Class