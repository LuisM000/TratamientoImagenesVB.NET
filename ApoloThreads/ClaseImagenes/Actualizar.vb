Public Class Actualizar
    Public Function ComprobarVersion() As String()
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "Version.txt"
        Try 'Si ya existe lo borramos
            Kill(rutaGuardar)
        Catch
        End Try
        Try
            'Descargamos el archivo y separamos las partes del archivo 
            'Están separadas por "///", el primer apartado es versión y los restantes son 
            'las mejoras que se incluyen
            My.Computer.Network.DownloadFile("ftp://31.170.165.82/Version.txt", rutaGuardar, "u643642961", "luis000luis000")
            Dim InfoDescargada As String = TxtInfoFotoLeer(rutaGuardar)
            Dim versionDescargada() As String = Split(InfoDescargada, "///")
            Return versionDescargada
        Catch
            Return {"Error"}
        End Try
    End Function
    'Leer archivo de texto con la información
    'Abre el archivo de texto y devuelve la cadena
    Private Function TxtInfoFotoLeer(ByVal ruta As String) As String
        Dim texto As String
        Dim sr As New System.IO.StreamReader(ruta)
        texto = sr.ReadToEnd()
        sr.Close()
        Kill(ruta)
        Return texto
    End Function
    'Descarga el programa
    Public Function DescargarActualizacion(ByVal SO_64 As Boolean) As String
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "Setup.exe"
        Try 'Si ya existe lo borramos
            Kill(rutaGuardar)
        Catch
        End Try
        Try
            If SO_64 = True Then
                My.Computer.Network.DownloadFile("ftp://31.170.165.82/Setupx64.exe", rutaGuardar, "u643642961", "luis000luis000", True, 500, False)
            Else
                My.Computer.Network.DownloadFile("ftp://31.170.165.82/Setupx86.exe", rutaGuardar, "u643642961", "luis000luis000", True, 500, False)
            End If
            Return rutaGuardar
            'Process.Start(rutaGuardar)
            'Me.Close()
        Catch
            Return "Error"
        End Try
    End Function

   
End Class
