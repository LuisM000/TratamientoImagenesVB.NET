Imports ClaseImagenes.Apolo
Public Class Redimensionar

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal
  

    Sub actualizarDimensiones()
        If ComboBox1.SelectedIndex = 1 Then 'Porcentaje
            lbldimensiones.Text = (numAncho.Value / 100) * bmpP.Width & " x " & (numAlto.Value / 100) * bmpP.Height & " píxeles"
        Else
            lbldimensiones.Text = numAncho.Value.ToString & " x " & numAlto.Value.ToString & " píxeles"
        End If
    End Sub
    Private Sub Redimensionar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
        numAncho.Value = bmpP.Width
        numAlto.Value = bmpP.Height
        actualizarDimensiones()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 7
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim tipoInterpolacion As Integer
        Dim ancho, alto As Double
        tipoInterpolacion = ComboBox2.SelectedIndex
        If ComboBox1.SelectedIndex = 1 Then 'Si está seleccionado porcentaje
            ancho = (numAncho.Value / 100) * bmpP.Width
            alto = (numAlto.Value / 100) * bmpP.Height
        Else
            ancho = numAncho.Value
            alto = numAlto.Value
        End If
        Principal.PictureBox1.Image = objetoTratamiento.Redimensionar(bmpP, New Rectangle(0, 0, ancho, alto), tipoInterpolacion)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub numAncho_ValueChanged(sender As Object, e As EventArgs) Handles numAncho.ValueChanged
        actualizarDimensiones()
    End Sub

    Private Sub numAlto_ValueChanged(sender As Object, e As EventArgs) Handles numAlto.ValueChanged
        actualizarDimensiones()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex = 1 Then 'Porcentaje
            numAncho.Value = 100
            numAlto.Value = 100
        Else
            numAncho.Value = bmpP.Width
            numAlto.Value = bmpP.Height
        End If
    End Sub
 
End Class