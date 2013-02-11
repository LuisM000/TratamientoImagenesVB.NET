Imports System.Net

Public Class Conexion
    Private datoConex(2) As String 'Variaable con los datos de conexión
    Private listaDirectorios As New ArrayList 'Variable con directorios
    Private listaImagenes As New ArrayList 'Variable con imágenes públicas
    Private listainfoImagenes As New ArrayList 'Variable con información imágenes públicas
    Private NumeroImagenesPub As Integer 'Variable con el número de imágenes públicas encontradas
    Private NumPeticionesPublicas As Integer 'Variable con el número de peticiones realizadas

    'Constructor que comprueba si los datos del servidor son correctos
    'Lista directorios, imágenes públicas (con su info)
    Sub New(ByVal direccionConexion As String, ByVal usuario As String, ByVal contraseña As String)
        Dim ftp As FtpWebRequest = CType(FtpWebRequest.Create(direccionConexion), FtpWebRequest)
        Dim cred As New NetworkCredential(usuario, contraseña)
        ftp.Credentials = cred
        ftp.KeepAlive = False
        ftp.AuthenticationLevel = Security.AuthenticationLevel.MutualAuthRequested
        ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails

        'Comprobación de si la conexión es correcta
        Try
            Dim ftpresp As FtpWebResponse = DirectCast(ftp.GetResponse, FtpWebResponse)
            DatosConexion = {(direccionConexion), (usuario), (contraseña)}

            'Listamos los directorios
            Directorios = listarDirectorios()

            'Listamos imágenes públicas
            ImagenesPublicas = listarImagenesPublicas()

            'Listamos info imágenes públicas
            InfoimagenesPublicas = listarInfoImagenesPublicas()

            ftpresp.Close()
        Catch ex As Exception
            MessageBox.Show("Algo ha ocurrido, no se ha podido establecer conexión con el servidor. Reinténtelo más tarde o contacte con el administrador", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#Region "Propiedades"

    'Propiedad privada con los datos de la conexión
    Private Property DatosConexion As Array
        Get
            Return datoConex
        End Get
        Set(value As Array)
            datoConex(0) = value(0)
            datoConex(1) = value(1)
            datoConex(2) = value(2)
        End Set
    End Property

    'Listado de directorios
    Private Property Directorios As ArrayList
        Get
            Return listaDirectorios
        End Get
        Set(value As ArrayList)
            listaDirectorios.Clear()
            listaDirectorios = value
        End Set
    End Property

    'Listado de imágenes públicas
    Private Property ImagenesPublicas As ArrayList
        Get
            Return listaImagenes
        End Get
        Set(value As ArrayList)
            listaImagenes.Clear()
            listaImagenes = value
            'Almacenamos el número de imágenes públicas
            NumeroImagenPublic = listaImagenes.Count
        End Set
    End Property

    'Listado de información imágenes públicas
    Private Property InfoimagenesPublicas As ArrayList
        Get
            Return listainfoImagenes
        End Get
        Set(value As ArrayList)
            listainfoImagenes.Clear()
            listainfoImagenes = value
        End Set
    End Property

    'Número de imágenes públicas
    Public Property NumeroImagenPublic As Integer
        Get
            Return NumeroImagenesPub
        End Get
        Set(value As Integer)
            NumeroImagenesPub = value
        End Set
    End Property

    'Número de peticiones imágenes Públicas
    Public Property PeticionimagPublic As Integer
        Get
            Return NumPeticionesPublicas
        End Get
        Set(value As Integer)
            NumPeticionesPublicas = value
        End Set
    End Property

#End Region

    'Función que lista todos los directorios
    Private Function listarDirectorios()
        Dim listadirectorios As New ArrayList
        Try

            Dim ftp As FtpWebRequest = CType(FtpWebRequest.Create(DatosConexion(0).ToString), FtpWebRequest)
            Dim cred As New NetworkCredential(DatosConexion(1).ToString, DatosConexion(2).ToString)
            ftp.Credentials = cred
            ftp.KeepAlive = False
            ftp.AuthenticationLevel = Security.AuthenticationLevel.MutualAuthRequested
            ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails
            'ftp.Proxy = Nothing
            Dim ftpresp As FtpWebResponse = DirectCast(ftp.GetResponse, FtpWebResponse)

            Dim sreader As New IO.StreamReader(ftpresp.GetResponseStream)
            While Not sreader.Peek = -1
                Dim ftpList As String() = sreader.ReadLine.Split(" ")
                Dim ftpfile As String = ftpList(ftpList.GetUpperBound(0))
                If ftpfile.ToString.EndsWith(".jpg") = False Then 'Evitamos listar imágenes
                    listadirectorios.Add(ftpfile)
                End If

            End While
            ftpresp.Close()
        Catch ex As Exception
            MessageBox.Show("Algo ha ocurrido, no se ha podido listar los directorios. Reinténtelo más tarde o contacte con el administrador", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return listadirectorios
    End Function

    'Función que lista todas las imágenes públicas
    Public Function listarImagenesPublicas()
        Dim listaImagen As New ArrayList
        Try

            Dim ftp As FtpWebRequest = CType(FtpWebRequest.Create(DatosConexion(0).ToString), FtpWebRequest)
            Dim cred As New NetworkCredential(DatosConexion(1).ToString, DatosConexion(2).ToString)
            ftp.Credentials = cred
            ftp.KeepAlive = False
            ftp.AuthenticationLevel = Security.AuthenticationLevel.MutualAuthRequested
            ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails
            'ftp.Proxy = Nothing
            Dim ftpresp As FtpWebResponse = DirectCast(ftp.GetResponse, FtpWebResponse)

            Dim sreader As New IO.StreamReader(ftpresp.GetResponseStream)
            While Not sreader.Peek = -1
                Dim ftpList As String() = sreader.ReadLine.Split(" ")
                Dim ftpfile As String = ftpList(ftpList.GetUpperBound(0))
                If ftpfile.ToString.EndsWith(".jpg") = True Then 'Evitamos listar imágenes
                    listaImagen.Add(ftpfile)
                End If

            End While
            ftpresp.Close()
        Catch ex As Exception
            MessageBox.Show("Algo ha ocurrido, no se ha podido listar las imágenes públicas. Reinténtelo más tarde o contacte con el administrador", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return listaImagen
    End Function

    'Función que lista todas los txt con la info de la imagen
    Public Function listarInfoImagenesPublicas()
        Dim listaImagen As New ArrayList
        Try

            Dim ftp As FtpWebRequest = CType(FtpWebRequest.Create(DatosConexion(0).ToString), FtpWebRequest)
            Dim cred As New NetworkCredential(DatosConexion(1).ToString, DatosConexion(2).ToString)
            ftp.Credentials = cred
            ftp.KeepAlive = False
            ftp.AuthenticationLevel = Security.AuthenticationLevel.MutualAuthRequested
            ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails
            'ftp.Proxy = Nothing
            Dim ftpresp As FtpWebResponse = DirectCast(ftp.GetResponse, FtpWebResponse)

            Dim sreader As New IO.StreamReader(ftpresp.GetResponseStream)
            While Not sreader.Peek = -1
                Dim ftpList As String() = sreader.ReadLine.Split(" ")
                Dim ftpfile As String = ftpList(ftpList.GetUpperBound(0))
                If ftpfile.ToString.EndsWith(".txt") = True Then 'Evitamos listar imágenes
                    listaImagen.Add(ftpfile)
                End If

            End While
            ftpresp.Close()
        Catch ex As Exception
            MessageBox.Show("Algo ha ocurrido, no se ha podido listar la información de las imágenes. Reinténtelo más tarde o contacte con el administrador", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return listaImagen
    End Function

    'Subir una imagen a la carpeta pública
    Public Function SubirFotoPublica(ByVal bmp As Bitmap, ByVal nombreImagen As String, ByVal infoImagen As String) As Boolean
        Try
           
            For Each item In ImagenesPublicas
                If item = nombreImagen & ".jpg" Then
                    MessageBox.Show("La imagen ya existe, por favor, cambie el nombre e inténtelo de nuevo.", "Error al guardar la imagen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                    Exit Function
                End If
            Next
            Dim nombreArchivo As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & nombreImagen & ".jpg"
            bmp.Save(nombreArchivo, System.Drawing.Imaging.ImageFormat.Jpeg)
            My.Computer.Network.UploadFile(nombreArchivo, DatosConexion(0) & nombreImagen & ".jpg", DatosConexion(1), DatosConexion(2), True, 500)
            'Creamos un archivo de texto con la información de la imagen
            Dim nombreArchivoinfo As String = TxtInfoFoto(nombreImagen, infoImagen)
            My.Computer.Network.UploadFile(nombreArchivoinfo, DatosConexion(0) & nombreImagen & ".txt", DatosConexion(1), DatosConexion(2), True, 500)
            'Creamos un archivo con el archivo de texto donde se guardarán las valoraciones
            Dim archivoVacio As String = TxtInfoFoto(nombreImagen, "")
            My.Computer.Network.UploadFile(archivoVacio, DatosConexion(0) & "Valoraciones/" & nombreImagen & ".txt", DatosConexion(1), DatosConexion(2), True, 500)

            'Listamos imágenes públicas
            ImagenesPublicas = listarImagenesPublicas()
            'Listamos info imágenes públicas
            InfoimagenesPublicas = listarInfoImagenesPublicas()
            MessageBox.Show("La imagen se ha compartido. Gracias por su colaboración", "Apolo Cloud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Catch
            MessageBox.Show("Algo ha ocurrido. Inténtelo de nuevo más tarde.", "Error al guardar la imagen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    'Valorar una imagen en la carpeta pública
    Public Function ValorarFotoPublica(ByVal numeroImagen As Integer, ByVal valoracion As Integer) As Boolean
        Try
           
            Dim informacion As String = ""
            'Primero descargamos el archivo (si existe)
            informacion = ModificarValoracion(numeroImagen)
            'Modificamos la información
            informacion = informacion & valoracion & "/"
            'Subimos el archivo
        'Creamos un archivo de texto con la valoración de la imagen (valoracionLena.txt)
        'Nombre de la imagen
        Dim nombreTxt As String = listaImagenes(numeroImagen).ToString.Replace(".jpg", ".txt")

            Dim nombreArchivoinfo As String = TxtInfoFoto("Valoracion" & nombreTxt, informacion)
            My.Computer.Network.UploadFile(nombreArchivoinfo, DatosConexion(0) & "Valoraciones/" & nombreTxt, DatosConexion(1), DatosConexion(2), False, 500)
            MessageBox.Show("Su voto se ha enviado. Gracias por colaborar", "Apolo Cloud", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Return True
        Catch
            MessageBox.Show("Algo ha ocurrido. Inténtelo de nuevo más tarde.", "Error al votar imagen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function ValorarFotoPublica(ByVal nombreImagen As String, ByVal valoracion As Integer) As Boolean
        Try

            Dim informacion As String = ""
            'Primero descargamos el archivo (si existe)
            informacion = ModificarValoracion(nombreImagen)
            'Modificamos la información
            informacion = informacion & valoracion & "/"
            'Subimos el archivo
            'Creamos un archivo de texto con la valoración de la imagen (valoracionLena.txt)


            Dim nombreArchivoinfo As String = TxtInfoFoto("Valoracion" & nombreImagen, informacion)
            My.Computer.Network.UploadFile(nombreArchivoinfo, DatosConexion(0) & "Valoraciones/" & nombreImagen & ".txt", DatosConexion(1), DatosConexion(2), False, 500)
            MessageBox.Show("Su voto se ha enviado. Gracias por colaborar", "Apolo Cloud", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
        Catch
            MessageBox.Show("Algo ha ocurrido. Inténtelo de nuevo más tarde.", "Error al votar imagen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    'Modifica valoración de una imágen de la carpeta pública
    Private Function ModificarValoracion(ByVal NumeroFoto As Integer) As String
        Dim InfoDescargada As String = Nothing
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & NumeroFoto & ".txt"
        Try 'Si ya existe lo borramos
            Kill(rutaGuardar)
        Catch
        End Try
        Try
            Dim direccionFTPimagen As String = (DatosConexion(0) & "Valoraciones/" & InfoimagenesPublicas(NumeroFoto))
            My.Computer.Network.DownloadFile(direccionFTPimagen, rutaGuardar, DatosConexion(1), DatosConexion(2))
            InfoDescargada = TxtInfoFotoLeer(rutaGuardar)
            Return InfoDescargada
        Catch
            Return ""
        End Try
    End Function
    Private Function ModificarValoracion(ByVal NombreFoto As String) As String
        Dim InfoDescargada As String = Nothing
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & NombreFoto & ".txt"
        Try 'Si ya existe lo borramos
            Kill(rutaGuardar)
        Catch
        End Try
        Try
            Dim direccionFTPimagen As String = (DatosConexion(0) & "Valoraciones/" & NombreFoto)
            My.Computer.Network.DownloadFile(direccionFTPimagen & ".txt", rutaGuardar, DatosConexion(1), DatosConexion(2))
            InfoDescargada = TxtInfoFotoLeer(rutaGuardar)
            Return InfoDescargada
        Catch
            Return ""
        End Try
    End Function



    Public Sub ActualizarDatos()
        'Listamos imágenes públicas
        ImagenesPublicas = listarImagenesPublicas()
        'Listamos info imágenes públicas
        InfoimagenesPublicas = listarInfoImagenesPublicas()
    End Sub



    'Descargar una imágen de la carpeta pública
    Public Function DescargarFotosPublicas(ByVal NumeroFoto As Integer) As Bitmap
        Dim bmpDescargado As Bitmap = My.Resources.SinImagen
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & NumeroFoto & ".jpg"
       
        Try 'Si ya existe lo borramos
            Kill(rutaGuardar)
        Catch
        End Try
        Try
            Dim direccionFTPimagen As String = (DatosConexion(0) & ImagenesPublicas(NumeroFoto))
            PeticionimagPublic += 1
            My.Computer.Network.DownloadFile(direccionFTPimagen, rutaGuardar, DatosConexion(1), DatosConexion(2))
            bmpDescargado = New Bitmap(rutaGuardar)
            Return bmpDescargado
        Catch
            Return bmpDescargado
        End Try
    End Function
    Public Function DescargarFotosPublicas(ByVal NombreFoto As String) As Bitmap
        Dim bmpDescargado As Bitmap = My.Resources.SinImagen
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & NombreFoto & ".jpg"

        Try 'Si ya existe lo borramos
            Kill(rutaGuardar)
        Catch
        End Try
        Try
            Dim direccionFTPimagen As String = (DatosConexion(0) & NombreFoto)
            PeticionimagPublic += 1
            My.Computer.Network.DownloadFile(direccionFTPimagen & ".jpg", rutaGuardar, DatosConexion(1), DatosConexion(2))
            bmpDescargado = New Bitmap(rutaGuardar)
            Return bmpDescargado
        Catch
            Return bmpDescargado
        End Try
    End Function

    'Descargar info de una imágen de la carpeta pública
    Public Function DescargarInfoFotosPublicas(ByVal NumeroFoto As Integer) As String
        Dim InfoDescargada As String = Nothing
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & NumeroFoto & ".txt"
        Try 'Si ya existe lo borramos
            Kill(rutaGuardar)
        Catch
        End Try
        Try
            Dim direccionFTPimagen As String = (DatosConexion(0) & InfoimagenesPublicas(NumeroFoto))
            My.Computer.Network.DownloadFile(direccionFTPimagen, rutaGuardar, DatosConexion(1), DatosConexion(2))
            InfoDescargada = TxtInfoFotoLeer(rutaGuardar)
            Return InfoDescargada
        Catch
            Return "Sin información"
        End Try
    End Function
    Public Function DescargarInfoFotosPublicas(ByVal nombreFoto As String) As String
        Dim InfoDescargada As String = Nothing
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & nombreFoto & ".txt"
        Try 'Si ya existe lo borramos
            Kill(rutaGuardar)
        Catch
        End Try
        Try
            Dim direccionFTPimagen As String = (DatosConexion(0) & nombreFoto)
            My.Computer.Network.DownloadFile(direccionFTPimagen & ".txt", rutaGuardar, DatosConexion(1), DatosConexion(2))
            InfoDescargada = TxtInfoFotoLeer(rutaGuardar)
            Return InfoDescargada
        Catch
            Return "Sin información"
        End Try
    End Function

    'Modifica valoración de una imágen de la carpeta pública
    Public Function DescargaValoracionFotoPublica(ByVal NumeroFoto As Integer) As Array
        Dim InfoDescargada(1) As String
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & NumeroFoto & ".txt"
        Try 'Si ya existe lo borramos
            Kill(rutaGuardar)
        Catch
        End Try
        Try
            Dim direccionFTPimagen As String = (DatosConexion(0) & "Valoraciones/" & InfoimagenesPublicas(NumeroFoto))
            My.Computer.Network.DownloadFile(direccionFTPimagen, rutaGuardar, DatosConexion(1), DatosConexion(2))
            InfoDescargada = RecuperaValoraciónImagen(rutaGuardar)
            Return InfoDescargada
        Catch
            Return {("Sin puntuación"), ("0")}
        End Try
    End Function
    Public Function DescargaValoracionFotoPublica(ByVal nombreFoto As String) As Array
        Dim InfoDescargada(1) As String
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & nombreFoto & ".txt"
        Try 'Si ya existe lo borramos
            Kill(rutaGuardar)
        Catch
        End Try
        Try
            Dim direccionFTPimagen As String = (DatosConexion(0) & "Valoraciones/" & nombreFoto)
            My.Computer.Network.DownloadFile(direccionFTPimagen & ".txt", rutaGuardar, DatosConexion(1), DatosConexion(2))
            InfoDescargada = RecuperaValoraciónImagen(rutaGuardar)
            Return InfoDescargada
        Catch
            Return {("Sin puntuación"), ("0")}
        End Try
    End Function
 



    'Crear archivo de texto con la información
    Private Function TxtInfoFoto(ByVal nombreImagen As String, ByVal info As String) As String
        Dim fic As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & nombreImagen & ".txt"
        Dim texto As String = info
        Dim sw As New System.IO.StreamWriter(fic)
        sw.WriteLine(texto)
        sw.Close()
        Return fic
    End Function

    'Leer archivo de texto con la información
    Private Function TxtInfoFotoLeer(ByVal ruta As String) As String
        Dim texto As String
        Dim sr As New System.IO.StreamReader(ruta)
        texto = sr.ReadToEnd()
        sr.Close()
        Return texto
    End Function

    'Leer archivo de texto con la información
    Private Function RecuperaValoraciónImagen(ByVal ruta As String)
        Dim texto As String
        Dim sr As New System.IO.StreamReader(ruta)
        texto = sr.ReadToEnd()
        texto = texto.Replace(vbCrLf, "")
        texto.Replace(" ", "")
        texto.Replace("  ", "")
        sr.Close()
        Dim textoSeparado() As String
        textoSeparado = texto.Split("/")
       
        Dim cuentaValoracion As Integer = 0
        For i = 0 To textoSeparado.Count - 2 'La última está siempre vacía
            cuentaValoracion += textoSeparado(i)
        Next
        Dim valoracionFinal(1) As String
        'Valoración final
        valoracionFinal(0) = cuentaValoracion / (textoSeparado.Length - 1)
        'Número de votos
        valoracionFinal(1) = (textoSeparado.Length - 1)
        Return valoracionFinal
    End Function

End Class
