Imports System.Net
Imports System.Net.Mail

Public Class Conexion
    Const directorioRaiz As String = "ftp://31.170.164.110/"
    Private datoConex(2) As String 'Variaable con los datos de conexión
    Private listaDirectorios As New ArrayList 'Variable con directorios
    Private listaDirectoriosPrivados As New ArrayList 'Variable con directorios privados
    Private listaImagenes As New ArrayList 'Variable con imágenes públicas
    Private listainfoImagenes As New ArrayList 'Variable con información imágenes públicas
    Private NumeroImagenesPub As Integer 'Variable con el número de imágenes públicas encontradas
    Private NumPeticionesPublicas As Integer 'Variable con el número de peticiones realizadas
    Private NombreImagen As String 'Variable que almacena el nombre de la imagen visualizada

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

            'Con esto hacemos que no se dupliquen las imágenes
            Dim rdn As New Random()
            ' generar un random entre 1 y 1000
            Dim numero As Integer = rdn.Next(1, 1000)
            PeticionimagPublic += 1 + numero
            '---------------

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
            listaDirectorios = value
        End Set
    End Property

    'Listado de directorios privados
    Private Property DirectoriosPrivados As ArrayList
        Get
            Return listaDirectoriosPrivados
        End Get
        Set(value As ArrayList)
            listaDirectoriosPrivados = value
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

    'Nombre de imagen actual
    Public Property NombreImagenActual As String
        Get
            Return NombreImagen
        End Get
        Set(value As String)
            NombreImagen = value
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

    'Función que lista todos los directorios
    Private Function listarDirectoriosPrivados()
        Dim listadirectorios As New ArrayList
        Try
            Dim dire = DatosConexion(0).ToString & "DatosUsuarios"
            Dim ftp As FtpWebRequest = CType(FtpWebRequest.Create(DatosConexion(0).ToString & "DatosUsuarios"), FtpWebRequest)
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
                listaDirectoriosPrivados.Add(ftpfile)

            End While
            ftpresp.Close()
        Catch ex As Exception
            MessageBox.Show("Algo ha ocurrido, no se ha podido listar los directorios. Reinténtelo más tarde o contacte con el administrador", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return listaDirectoriosPrivados
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
            'Listamos los directorios
            Directorios = listarDirectorios()

            'Listamos imágenes públicas
            ImagenesPublicas = listarImagenesPublicas()

            'Listamos info imágenes públicas
            InfoimagenesPublicas = listarInfoImagenesPublicas()

            For Each item In ImagenesPublicas
                If item = nombreImagen & ".jpg" Then
                    MessageBox.Show("La imagen ya existe, por favor, cambie el nombre e inténtelo de nuevo.", "Error al guardar la imagen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                    Exit Function
                End If
            Next

            Dim nombreArchivo As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & nombreImagen & ".jpg"
            bmp.Save(nombreArchivo, System.Drawing.Imaging.ImageFormat.Jpeg)

            My.Computer.Network.UploadFile(nombreArchivo, DatosConexion(0) & nombreImagen & ".jpg", DatosConexion(1), DatosConexion(2))
            'Creamos un archivo de texto con la información de la imagen
            Dim nombreArchivoinfo As String = TxtInfoFoto(nombreImagen, infoImagen)

            My.Computer.Network.UploadFile(nombreArchivoinfo, DatosConexion(0) & nombreImagen & ".txt", DatosConexion(1), DatosConexion(2))
            'Creamos un archivo con el archivo de texto donde se guardarán las valoraciones
            Dim archivoVacio As String = TxtInfoFoto("valoracion" & nombreImagen, "")
            My.Computer.Network.UploadFile(archivoVacio, DatosConexion(0) & "Valoraciones/" & nombreImagen & ".txt", DatosConexion(1), DatosConexion(2))

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
            My.Computer.Network.UploadFile(nombreArchivoinfo, DatosConexion(0) & "Valoraciones/" & nombreImagen & ".txt", DatosConexion(1), DatosConexion(2))
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
            My.Computer.FileSystem.DeleteFile(rutaGuardar)
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
        'Con esto hacemos que no se dupliquen las imágenes
        Dim rdn As New Random()
        ' generar un random entre 1 y 1000
        Dim numero As Integer = rdn.Next(1, 1000)
        PeticionimagPublic += 1 + numero

        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & NombreFoto & ".txt"
        Try 'Si ya existe lo borramos
            My.Computer.FileSystem.DeleteFile(rutaGuardar)
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
        'Con esto hacemos que no se dupliquen las imágenes
        Dim rdn As New Random()
        ' generar un random entre 1 y 1000
        Dim numero As Integer = rdn.Next(1, 1000)
        PeticionimagPublic += 1 + numero
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & NumeroFoto & ".jpg"

        Try 'Si ya existe lo borramos
            My.Computer.FileSystem.DeleteFile(rutaGuardar)
        Catch
        End Try
        Try
            Dim direccionFTPimagen As String = (DatosConexion(0) & ImagenesPublicas(NumeroFoto))
            My.Computer.Network.DownloadFile(direccionFTPimagen, rutaGuardar, DatosConexion(1), DatosConexion(2))
            bmpDescargado = New Bitmap(rutaGuardar)
            Return bmpDescargado
        Catch
            Return bmpDescargado
        End Try
    End Function
    Public Function DescargarFotosPublicas(ByVal NombreFoto As String) As Bitmap
        Dim bmpDescargado As Bitmap = My.Resources.SinImagen
        'Con esto hacemos que no se dupliquen las imágenes

        Dim rdn As New Random()
        ' generar un random entre 1 y 1000
        Dim numero As Integer = rdn.Next(1, 1000)
        PeticionimagPublic += 1 + numero
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & NombreFoto & ".jpg"

        Try 'Si ya existe lo borramos
            My.Computer.FileSystem.DeleteFile(rutaGuardar)
        Catch
        End Try
        Try
            Dim direccionFTPimagen As String = (DatosConexion(0) & NombreFoto)
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
        'Con esto hacemos que no se dupliquen las imágenes
        Dim rdn As New Random()
        ' generar un random entre 1 y 1000
        Dim numero As Integer = rdn.Next(1, 1000)
        PeticionimagPublic += 1 + numero
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & NumeroFoto & ".txt"
        Try 'Si ya existe lo borramos
            My.Computer.FileSystem.DeleteFile(rutaGuardar)
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
        'Con esto hacemos que no se dupliquen las imágenes
        Dim rdn As New Random()
        ' generar un random entre 1 y 1000
        Dim numero As Integer = rdn.Next(1, 1000)
        PeticionimagPublic += 1 + numero
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & nombreFoto & ".txt"
        Try 'Si ya existe lo borramos
            My.Computer.FileSystem.DeleteFile(rutaGuardar)
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
        'Con esto hacemos que no se dupliquen las imágenes
        Dim rdn As New Random()
        ' generar un random entre 1 y 1000
        Dim numero As Integer = rdn.Next(1, 1000)
        PeticionimagPublic += 1 + numero
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & NumeroFoto & ".txt"
        Try 'Si ya existe lo borramos
            My.Computer.FileSystem.DeleteFile(rutaGuardar)
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
        'Con esto hacemos que no se dupliquen las imágenes
        Dim rdn As New Random()
        ' generar un random entre 1 y 1000
        Dim numero As Integer = rdn.Next(1, 1000)
        PeticionimagPublic += 1 + numero
        NombreImagenActual = nombreFoto 'Actualizamos el nombre de la imagen 

        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & nombreFoto & ".txt"
        Try 'Si ya existe lo borramos
            My.Computer.FileSystem.DeleteFile(rutaGuardar)
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


    'Crear Carpeta privada
    Public Function CrearCarpetaPrivada(ByVal nombre As String, ByVal pass As String, ByVal email As String)
        'Listamos los directorios
        DirectoriosPrivados = listarDirectoriosPrivados()

        Try
            For Each item In DirectoriosPrivados
                If item = nombre Then
                    MessageBox.Show("El usuario ya existe.", "Error al crear directorio", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                    Exit Function
                End If
            Next
            'Creamos el archivo para luego subirlo
            Dim datosUsuario = TxtInfoFoto(nombre, nombre & "/" & pass & "/" & email)
            Dim directorio As Boolean = CrearDirectorio(nombre)
            Dim directorioValoraciones As Boolean = CrearDirectorio(nombre & "/Valoraciones")
            If directorio = False And directorioValoraciones Then
                MessageBox.Show("No se pudo crear el directorio, inténtelo más tarde.", "Error al crear directorio", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End If
            Dim direccion As String = DatosConexion(0) & "DatosUsuarios/" & nombre & "/DatosUser"
            My.Computer.Network.UploadFile(datosUsuario, direccion, DatosConexion(1), DatosConexion(2))
            'Creamos un registro para poder recuperar la contraseña
            My.Computer.Network.UploadFile(datosUsuario, DatosConexion(0) & "DatosUsuarios/Emails/" & email & ".txt", DatosConexion(1), DatosConexion(2))
            Return True
        Catch
            MessageBox.Show("Algo ha ocurrido. Inténtelo de nuevo más tarde.", "Error al crear carpeta", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function CrearDirectorio(ByVal nombreDirectorio As String) As Boolean
        Try
            Dim peticionFTP As FtpWebRequest
            ' Creamos una peticion FTP con la dirección del directorio que queremos crear
            peticionFTP = CType(WebRequest.Create(New Uri(DatosConexion(0) & "DatosUsuarios/" & nombreDirectorio)), FtpWebRequest)

            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(DatosConexion(1).ToString, DatosConexion(2).ToString)

            ' Seleccionamos el comando que vamos a utilizar: Crear un directorio
            peticionFTP.Method = WebRequestMethods.Ftp.MakeDirectory
            Dim response As WebResponse = peticionFTP.GetResponse()
            Return True
        Catch
            Return False
        End Try
    End Function

    'Acceder a carpeta privada
    Public Function AccederCarpetaPrivada(ByVal nombreUsuario As String, ByVal password As String) As Boolean
        'Listamos los directorios
        DirectoriosPrivados = listarDirectoriosPrivados()

        Try
            Dim comprobacionUser As Boolean = False
            For Each item In DirectoriosPrivados 'Comprobamos que haya alguno que exista
                If item = nombreUsuario Then
                    comprobacionUser = True
                End If
            Next
            If comprobacionUser = False Then 'Si ninguno existe, salimos
                MessageBox.Show("El nombre de usuario o la contraseña no son correctos.", "Error de credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
                Exit Function
            End If
            'La carpeta existe, ahora comprobamos que la contraseña coincida
            Dim InfoDescargada As String = Nothing
            Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & nombreUsuario & ".txt"
            Try 'Si ya existe lo borramos
                My.Computer.FileSystem.DeleteFile(rutaGuardar)
            Catch
            End Try
            Dim direccion As String = DatosConexion(0) & "DatosUsuarios/" & nombreUsuario & "/DatosUser"
            My.Computer.Network.DownloadFile(direccion, rutaGuardar, DatosConexion(1), DatosConexion(2))
            InfoDescargada = TxtInfoFotoLeer(rutaGuardar)
            'Extraemos la contraseña
            Dim InfoContr = InfoDescargada.Split("/")
            If InfoContr(1).ToString = password Then 'Comprobamos si la contraseña es correcta
                Return True
                Exit Function
            Else
                MessageBox.Show("El nombre de usuario o la contraseña no son correctos.", "Error de credenciales", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
                Exit Function
            End If


        Catch
            MessageBox.Show("No se ha podido conectar con su carpeta. Revise sus credenciales o inténtelo más tarde", "Error al acceder a carpeta privada", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    'Compartir imagen privada como pública
    Public Function CompartirImagen(ByVal bmp As Bitmap, ByVal nombreImagen As String, ByVal informacionImagen As String)
        Dim direccionFtp = DatosConexion(0).ToString.Split("/") 'Separamos para extraer el nombre del usuario
        'Extraemos el nombre del usuario
        Dim nombreUsuario As String = direccionFtp(direccionFtp.Length - 2)
        informacionImagen = "Compartida por " & nombreUsuario & ". " & informacionImagen
        Dim direccionConexionProvisional = DatosConexion(0)
        DatosConexion(0) = directorioRaiz

        Try

            'Cambiamos temporalmenta la dirección de datosConexión
            SubirFotoPublica(bmp, nombreImagen, informacionImagen)
            'Volvemos a asignar la dirección actual
            DatosConexion(0) = direccionConexionProvisional
            ActualizarDatos() 'Volvemos a listar los directorios de la carpeta privada
            Return True
        Catch
            DatosConexion(0) = direccionConexionProvisional
            ActualizarDatos()
            Return False
        End Try
    End Function


    'Recuperar contraseña
    Public Sub RecuperarContraseña(ByVal email As String)
        Dim infoDescargada As String
        Dim rdn As New Random()
        ' generar un random entre 1 y 1000
        Dim numero As Integer = rdn.Next(1, 1000)
        PeticionimagPublic += 1 + numero
        Dim rutaGuardar As String = System.IO.Directory.GetCurrentDirectory().ToString & "\ImagenesCloud\" & PeticionimagPublic & "-" & "Recup" & email & ".txt"
        Try 'Si ya existe lo borramos
            My.Computer.FileSystem.DeleteFile(rutaGuardar)
        Catch
        End Try
        Try
            Dim direccionFTPimagen As String = (DatosConexion(0) & "DatosUsuarios/Emails/" & email & ".txt")
            My.Computer.Network.DownloadFile(direccionFTPimagen, rutaGuardar, DatosConexion(1), DatosConexion(2))
            infoDescargada = TxtInfoFotoLeer(rutaGuardar)
            Dim contraseña = infoDescargada.Split("/")
            Dim resultado As Boolean = Me.EnviarContraseña(contraseña(0), contraseña(1), contraseña(2))
            If resultado = True Then
                MessageBox.Show("Su contraseña ha sido enviada al correo electrónico. Revise la bandeja de correos no deseados en caso de no recibir el correo o contacte con el administrador.", "Recuperación de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch
            MessageBox.Show("No se ha encontrado la dirección de correo asociada.", "Recuperación de contraseña", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
        End Try
    End Sub
    'Enviar contraseña
    Private Function EnviarContraseña(ByVal usuario As String, ByVal pass As String, ByVal email As String) As Boolean
        Try
            Dim SMTP As New System.Net.Mail.SmtpClient 'Variable con la que se envia el correo
            Dim CORREO As New System.Net.Mail.MailMessage
            CORREO.From = New System.Net.Mail.MailAddress("apolothreads@gmail.com", "Recuperación de contraseña Apolo Cloud", System.Text.Encoding.UTF8)

            Dim cuerpoCorreo As String
            cuerpoCorreo = "Su usuario/contraseña es: " & usuario & "/" & pass
            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(cuerpoCorreo, Nothing, "text/html")

            CORREO.To.Add(email)
            'Adicionando copia oculta
            CORREO.Bcc.Add(email)

            CORREO.IsBodyHtml = True
            CORREO.AlternateViews.Add(htmlView)

            CORREO.Subject = "Recuperación de contraseña Apolo Cloud"
            SMTP.Host = "smtp.gmail.com"
            SMTP.Port = "587"

            SMTP.EnableSsl = True
            SMTP.Credentials = New System.Net.NetworkCredential("apolothreads@gmail.com", "Apolo0525")
            SMTP.Send(CORREO)
            Return True
        Catch ex As Exception
            MessageBox.Show("No se ha podido enviar. Vuelva a intentarlo por favor.", "Error Apolo", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End Try
    End Function


    'Borrar archivo
    Public Function EliminarArchivos(ByVal nombreArchivo As String) As Boolean
        Try
            Dim peticionFTP As FtpWebRequest

            ' Creamos una petición FTP con la dirección del fichero a eliminar
            peticionFTP = CType(WebRequest.Create(New Uri(DatosConexion(0) & nombreArchivo)), FtpWebRequest)
            ' Fijamos el usuario y la contraseña de la petición
            peticionFTP.Credentials = New NetworkCredential(DatosConexion(1).ToString, DatosConexion(2).ToString)
            ' Seleccionamos el comando que vamos a utilizar: Eliminar un fichero
            peticionFTP.Method = WebRequestMethods.Ftp.DeleteFile
            peticionFTP.UsePassive = False
            Dim respuestaFTP As FtpWebResponse
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)

            ' Creamos una petición FTP con la dirección del fichero a eliminar (comentarios)
            Dim direccionComentarios As String
            'Eliminamos .jpg y lo reemplzamos por .txt
            direccionComentarios = nombreArchivo.Substring(0, nombreArchivo.Length - 4)
            direccionComentarios += ".txt"
            peticionFTP = CType(WebRequest.Create(New Uri(DatosConexion(0) & direccionComentarios)), FtpWebRequest)
            peticionFTP.Credentials = New NetworkCredential(DatosConexion(1).ToString, DatosConexion(2).ToString)
            peticionFTP.Method = WebRequestMethods.Ftp.DeleteFile
            peticionFTP.UsePassive = False
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)

            ' Creamos una petición FTP con la dirección del fichero a eliminar (Valoraciones)
            Dim direccionValoraciones As String
            'Eliminamos .jpg y lo reemplzamos por .txt
            direccionValoraciones = nombreArchivo.Substring(0, nombreArchivo.Length - 4)
            direccionValoraciones += ".txt"
            direccionValoraciones = "Valoraciones/" & direccionValoraciones
            peticionFTP = CType(WebRequest.Create(New Uri(DatosConexion(0) & direccionValoraciones)), FtpWebRequest)
            peticionFTP.Credentials = New NetworkCredential(DatosConexion(1).ToString, DatosConexion(2).ToString)
            peticionFTP.Method = WebRequestMethods.Ftp.DeleteFile
            peticionFTP.UsePassive = False
            respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)

            ' Si todo ha ido bien, devolvemos true
            respuestaFTP.Close()

            Return True
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            MessageBox.Show("Algo ha ocurrido. Inténtelo de nuevo más tarde.", "Error al borrar archivo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function


    'Borrar archivo
    Public Function EliminarCuentaPrivada() As Boolean
        Try
            BorrarArchivosPrivados("") 'Borramos las fotos y la info
            BorrarArchivosPrivados("Valoraciones/") 'Borramos las valoraciones
            borrarCarpeta(DatosConexion(0).ToString & "Valoraciones") 'Borramos la carpeta de valoraciones
            'Borramos la carpeta del usuario
            Dim direccionCarp As String = ""
            Dim aux = DatosConexion(0).ToString.Split("/")
            For i = 0 To aux.Count - 2
                direccionCarp += aux(i) & "/"
            Next
            borrarCarpeta(direccionCarp)
            Return True
        Catch ex As Exception
            ' Si se produce algún fallo, se devolverá el mensaje del error
            MessageBox.Show("Algo ha ocurrido. Inténtelo de nuevo más tarde o contacte con el administrador.", "Error al borrar cuenta", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    'Función que lista todos los directorios
    Private Sub BorrarArchivosPrivados(ByVal carpeta As String)
        Dim listadirectorios As New ArrayList
        Try

            Dim ftp As FtpWebRequest = CType(FtpWebRequest.Create(DatosConexion(0).ToString & carpeta), FtpWebRequest)
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
                If ftpfile.ToString <> "." And ftpfile.ToString <> ".." And ftpfile.ToString <> "Valoraciones" Then
                    Me.borrararchivo(ftpfile.ToString, carpeta)
                End If

            End While
            ftpresp.Close()
        Catch ex As Exception
            MessageBox.Show("Algo ha ocurrido, no se ha podido borrar los directorios. Reinténtelo más tarde o contacte con el administrador", "Error conexión", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub borrararchivo(ByVal nombreArchivo As String, ByVal carpeta As String)
        Dim peticionFTP As FtpWebRequest

        ' Creamos una petición FTP con la dirección del fichero a eliminar
        peticionFTP = CType(WebRequest.Create(New Uri(DatosConexion(0) & carpeta & nombreArchivo)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(DatosConexion(1).ToString, DatosConexion(2).ToString)
        ' Seleccionamos el comando que vamos a utilizar: Eliminar un fichero
        peticionFTP.Method = WebRequestMethods.Ftp.DeleteFile
        peticionFTP.UsePassive = False
        Dim respuestaFTP As FtpWebResponse
        respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
    End Sub
    Private Sub borrarCarpeta(ByVal carpeta As String)
        Dim peticionFTP As FtpWebRequest

        ' Creamos una petición FTP con la dirección del fichero a eliminar
        peticionFTP = CType(WebRequest.Create(New Uri(carpeta)), FtpWebRequest)
        ' Fijamos el usuario y la contraseña de la petición
        peticionFTP.Credentials = New NetworkCredential(DatosConexion(1).ToString, DatosConexion(2).ToString)
        ' Seleccionamos el comando que vamos a utilizar: Eliminar un fichero
        peticionFTP.Method = WebRequestMethods.Ftp.RemoveDirectory
        peticionFTP.UsePassive = False
        Dim respuestaFTP As FtpWebResponse
        respuestaFTP = CType(peticionFTP.GetResponse(), FtpWebResponse)
    End Sub




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
        My.Computer.FileSystem.DeleteFile(ruta)
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
