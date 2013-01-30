Imports System.IO
Imports ClaseImagenes.Apolo

Public Class ImgCompilador

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmp As Bitmap 'Bitmap para mostrar la imagen seleccionada
        Function listaImagenes(ByVal rutaDirectorio As String) 'Listar los archivos xml de un directorio
            Dim folder As New DirectoryInfo(rutaDirectorio) 'Directorio
            Dim listaDearchivos As New ArrayList
            For Each file As FileInfo In folder.GetFiles() 'Comprobamos si los archivos xml
                listaDearchivos.Add(file.ToString)
            Next
            Return listaDearchivos
        End Function

    Private Sub ImgCompilador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

        ListBox1.Items.Clear()
        Dim lista = listaImagenes("Compilador\ImagenesCompiladas")
        For Each item In lista
            ListBox1.Items.Add(item)
        Next
        If ListBox1.Items.Count <> 0 Then
            ListBox1.SelectedIndex = 0
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Try
            bmp = New Bitmap("Compilador\ImagenesCompiladas\" & ListBox1.SelectedItem.ToString)
            PictureBox1.Image = bmp
        Catch
            PictureBox1.Image = My.Resources.cancel
        End Try
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Principal.PictureBox1.Image = objetoTratamiento.abririmgRuta("Compilador\ImagenesCompiladas\" & ListBox1.SelectedItem.ToString)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListBox1.SelectedIndex <> -1 Then 'Si hay algún ítem seleccionado
            Try
                Dim respuesta As DialogResult = MessageBox.Show("¿Realmente desea eliminar de forma permanente el archivo?", "Apolo threads", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Select Case respuesta
                    Case Windows.Forms.DialogResult.Yes 'Borramos el archivo
                        Dim ruta As String
                        ruta = System.IO.Directory.GetCurrentDirectory() & "\Compilador\ImagenesCompiladas\" & ListBox1.SelectedItem 'Seleccionamos la ruta del archivo a borrar
                        bmp.Dispose() 'Liberamos la imagen para poder borrarla
                        Kill(ruta)
                    Case Windows.Forms.DialogResult.No
                        'No hacemos nada
                End Select
                'Recargamos el listbox
                ImgCompilador_Load(sender, e)
            Catch
                MessageBox.Show("Algo ha fallado... inténtelo más tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Recargamos el listbox
                ImgCompilador_Load(sender, e)
            End Try
        End If
    End Sub
End Class