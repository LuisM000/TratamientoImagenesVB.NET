Imports ClaseImagenes.Apolo
Public Class Voltear

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal

    Private Function Volteado(ByVal VolteadoSelec As String) As RotateFlipType
        Select Case VolteadoSelec
            Case "RotateNoneFlipNone"
                Volteado = (RotateFlipType.RotateNoneFlipNone)
            Case "Rotate90FlipNone"
                Volteado = (RotateFlipType.Rotate90FlipNone)
            Case "Rotate180FlipNone"
                Volteado = (RotateFlipType.Rotate180FlipNone)
            Case "Rotate270FlipNone"
                Volteado = (RotateFlipType.Rotate270FlipNone)
            Case "RotateNoneFlipX"
                Volteado = (RotateFlipType.RotateNoneFlipX)
            Case "Rotate90FlipX"
                Volteado = (RotateFlipType.Rotate90FlipX)
            Case "Rotate180FlipX"
                Volteado = (RotateFlipType.Rotate180FlipX)
            Case "Rotate270FlipX"
                Volteado = (RotateFlipType.Rotate270FlipX)
            Case "RotateNoneFlipY"
                Volteado = (RotateFlipType.RotateNoneFlipY)
            Case "Rotate90FlipY"
                Volteado = (RotateFlipType.Rotate90FlipY)
            Case "Rotate180FlipY"
                Volteado = (RotateFlipType.Rotate180FlipY)
            Case "Rotate270FlipY"
                Volteado = (RotateFlipType.Rotate270FlipY)
            Case "RotateNoneFlipXY"
                Volteado = (RotateFlipType.RotateNoneFlipXY)
            Case "Rotate90FlipXY"
                Volteado = (RotateFlipType.Rotate90FlipXY)
            Case "Rotate180FlipXY"
                Volteado = (RotateFlipType.Rotate180FlipXY)
            Case "Rotate270FlipXY"
                Volteado = (RotateFlipType.Rotate270FlipXY)
        End Select
        Return Volteado
    End Function

    Private Sub VoltearlistaVolteados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.SelectedIndex = 0
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'ActualizarlistaVolteados()
        Principal.PictureBox1.Image = objetoTratamiento.Volteados(bmpP, Volteado(ListBox1.SelectedItem))
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub

  
End Class