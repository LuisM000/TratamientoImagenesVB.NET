Imports System.Xml
Imports System.Net



Namespace Apolo

    Public Delegate Sub ActualizamosImagen(ByVal bmp As Bitmap) 'Definimos el Tipo de evento
    Public Delegate Sub ActualizamosNombreImagen(ByVal NombreImagen As String) 'Definimos el Tipo de evento

    Public Class TratamientoImagenes


        'Variables para controlar atrás/adelante 
        Public Shared imagenesGuardadas As New ArrayList 'Para ir atrás y adelante, Lo creamos como
        'Se crea como shared para que no se cree de nuevo en cada instancia
        Private Shared contadorImagenes As Integer 'Para saber en qué índice de las imágenesGUardadas estamos
        Private Shared Informacion As New ArrayList 'Para saber qué se hizo
        '************************************

        'Estado hilo
        Public porcentaje(2) As String

        'Evento de tipo ActualizamosImagen
        Event actualizaBMP As ActualizamosImagen

        'Evento de tipo ActualizamosImagen
        Event actualizaNombreImagen As ActualizamosNombreImagen



#Region "Hacer/deshacerImagenes"
        Public ReadOnly Property ListadoImagenesAtras() As Bitmap 'Imagen hacia atrás
            Get
                Try
                    contadorImagenes -= 1
                    RaiseEvent actualizaBMP(imagenesGuardadas.Item(contadorImagenes - 1))
                    Return imagenesGuardadas.Item(contadorImagenes - 1)
                Catch e As System.ArgumentOutOfRangeException
                    contadorImagenes += 1
                    Return imagenesGuardadas.Item(contadorImagenes - 1)
                End Try
            End Get
        End Property

        Public ReadOnly Property ListadoImagenesAdelante() As Bitmap 'Imagen hacia delante
            Get
                Try
                    contadorImagenes += 1
                    RaiseEvent actualizaBMP(imagenesGuardadas.Item(contadorImagenes - 1))
                    Return imagenesGuardadas.Item(contadorImagenes - 1)
                Catch e As System.ArgumentOutOfRangeException
                    contadorImagenes -= 1
                    Return imagenesGuardadas.Item(contadorImagenes - 1)
                End Try
            End Get
        End Property


        Public ReadOnly Property ListadoInfoAtras() As String 'Imagen hacia atrás
            Get
                Try
                    Return Informacion.Item(contadorImagenes - 2)
                Catch e As System.ArgumentOutOfRangeException
                    Return "No disponible"
                End Try
            End Get
        End Property

        Public ReadOnly Property ListadoInfoAdelante() As String 'Imagen hacia delante
            Get
                Try
                    Return Informacion.Item(contadorImagenes)
                Catch e As System.ArgumentOutOfRangeException
                    Return "No disponible"
                End Try
            End Get
        End Property

        'Almacenamos la imagen
        Private Sub guardarImagen(ByVal bmp As Bitmap, ByVal info As String) 'Para almacenar el bitmap y la información
            'Almacenamos la imagen con su información y añadimos +1 al contador
            If imagenesGuardadas.Count < 40 Then
                contadorImagenes += 1
                imagenesGuardadas.Add(bmp)
                Informacion.Add(info)
            Else
                'Con esto controlamos que si hemos almacenado más de 40 imágenes
                'Quitamos la primera y la nueva la incluimos en el último lugar
                imagenesGuardadas.RemoveAt(0)
                Informacion.RemoveAt(0)
                imagenesGuardadas.Add(bmp)
                Informacion.Add(info)
            End If
        End Sub

#End Region

        Public ReadOnly Property estadoCarga() As Array 'Propiedad con el estado de la carga
            Get
                'Serán dos valores, el porcentaje de carga y quién está realizando la acción
                Return porcentaje
            End Get
        End Property


#Region "funcionesTratamiento"

        'Obtenemos los niveles de la imagen
        Private Function nivel(ByVal bmp As Bitmap)
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            porcentaje(0) = 0 'Actualizamos el estado
            porcentaje(1) = "Cargando imagen" 'Actualizamos el estado
            'Este primer bloque, guarda los niveles digitales de la imagen en la variable Niveles
            Dim i, j As Long
            ReDim Niveles(bmp.Width - 1, bmp.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            For i = 0 To bmp.Width - 1 'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 1 'Recorremos la matriz a lo largo
                    Niveles(i, j) = bmp.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                    porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
                Next
            Next
            Return Niveles
        End Function


        Public Function EscalaGrises(ByVal bmp As Bitmap) As Bitmap
            guardarImagen(bmp, "Escala de grises") 'Guardamos la imagen para poder hacer retroceso
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Transformando a escala de grises" 'Actualizar el estado


            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim media As Double 'Variable para calcular la media
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    rojoaux = Niveles(i, j).R
                    verdeaux = Niveles(i, j).G
                    azulaux = Niveles(i, j).B
                    media = CInt((rojoaux + verdeaux + azulaux) / 3) 'Hacemos la media
                    Rojo = media
                    Verde = media
                    Azul = media
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp) 'generamos el evento
            Return bmp
        End Function
        Public Function Invertir(ByVal bmp As Bitmap) As Bitmap
            guardarImagen(bmp, "Invertir") 'Guardamos la imagen para poder hacer retroceso
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Inviertiendo colores" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = 255 - (Niveles(i, j).R) 'Realizamos la inversión de los colores
                    Verde = 255 - (Niveles(i, j).G)
                    Azul = 255 - (Niveles(i, j).B)
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp) 'generamos el evento
            Return bmp
        End Function

        Public Function BlancoNegro(ByVal bmp As Bitmap) As Bitmap
            guardarImagen(bmp, "Blanco y negro") 'Guardamos la imagen para poder hacer retroceso
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Transformando a blanco y negro" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte
            Dim media As Double
            Dim rojoaux, verdeaux, azulaux As Double

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    rojoaux = Niveles(i, j).R
                    verdeaux = Niveles(i, j).G
                    azulaux = Niveles(i, j).B

                    'Calculamos la media 
                    media = (rojoaux + verdeaux + azulaux) / 3
                    'En función de si el valor es mayor o menor de 128 (mitad aproximada
                    'de 255), lo convertimos en blanco o negro
                    If media >= 128 Then
                        Rojo = 255
                        Verde = 255
                        Azul = 255
                    Else
                        Rojo = 0
                        Verde = 0
                        Azul = 0
                    End If
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp) 'generamos el evento
            Return bmp
        End Function
#End Region

#Region "FuncionesAbrir"
        'Se abre desde archivo
        Function abrirImagen(Optional filtrado As Integer = 1) As Bitmap
            Try
                Dim dialogo As New OpenFileDialog

                With dialogo
                    .Filter = "Todos los formatos compatibles|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.tif" & _
                              "|Ficheros BMP|*.bmp" & _
                              "|Ficheros GIF|*.gif" & _
                              "|Ficheros JPG o JPEG|*.jpg;*.jpeg" & _
                              "|Ficheros PNG|*.png" & _
                              "|Ficheros TIFF|*.tif" & _
                              "|Todos los archivos|*.*"
                    .FilterIndex = filtrado
                    If (.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                        abrirImagen = Image.FromFile(.FileName)
                        guardarImagen(abrirImagen, "Imagen original desde archivo") 'Almacenamos info y bitmap
                        contadorImagenes = imagenesGuardadas.Count 'Lo asignamos como el contador actual
                        RaiseEvent actualizaBMP(abrirImagen) 'Generamos evento
                        RaiseEvent actualizaNombreImagen(nombreImagen(.FileName)) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
                        Return abrirImagen
                    Else
                        abrirImagen = Nothing
                        Return abrirImagen
                    End If
                End With
            Catch e As Exception
                MessageBox.Show(e.ToString)
                abrirImagen = Nothing
                Return abrirImagen
            End Try
        End Function

        'Se abre desde una URL
        Function abrirRecursoWeb(ByVal enlace As String) As Bitmap
            Try
                Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(enlace)
                Dim response As System.Net.WebResponse = request.GetResponse()
                Dim responseStream As System.IO.Stream = response.GetResponseStream()
                Dim bmp As New Bitmap(responseStream)
                guardarImagen(bmp, "Imagen original como recurso web") 'Almacenamos info y bitmap
                contadorImagenes = imagenesGuardadas.Count 'Lo asignamos como el contador actual
                RaiseEvent actualizaBMP(bmp) 'Generamos evento
                RaiseEvent actualizaNombreImagen(nombreRecursoWeb(enlace)) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
                Return bmp
            Catch
                Dim bmp As Bitmap
                bmp = Nothing
                Return bmp
            End Try
        End Function

        'Se buscan imágenes en Bing
        Public Function BuscarImagenesBing(ByVal texto As String, Optional ByVal numeroImagenes As Integer = 10, Optional ByVal tamaño As String = "", Optional Precarga As Boolean = False)
            Dim datosVuelta(50, 50) As String
            Try
                If tamaño <> "" Then
                    tamaño = "&ImageFilters=%27Size%3a" & tamaño & "%27"
                End If
                Dim accountKey As String = "URndltgY4xIFqjJOhdozXaBilXhSo76PIW7YWedDkJI="
                Dim serviceRoot As String = "https://api.datamarket.azure.com/Bing/Search/"
                Dim imageQueryRoot As String = serviceRoot + "Image?"
                Dim imageQuery As String = imageQueryRoot + "Query=%27" + texto + "%27" + "&$top=" & numeroImagenes & tamaño

                'XmlDocument que usaremos para leer los resultados
                Dim document As XmlDocument = New XmlDocument()

                'Las siguientes cuatro líneas configurar el XmlDocument para utilizar las credenciales 
                Dim accountCredential As New NetworkCredential(accountKey, accountKey)
                Dim resolver As New XmlUrlResolver()
                resolver.Credentials = accountCredential
                document.XmlResolver = resolver

                ' Con las credenciales configuradas, cargamos el archivo
                document.Load(imageQuery)

                'Creamos nameespace para configurar resultados
                Dim namespaceManager As XmlNamespaceManager = New XmlNamespaceManager(document.NameTable)

                namespaceManager.AddNamespace("atom", "http://www.w3.org/2005/Atom")

                namespaceManager.AddNamespace("m", "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata")

                namespaceManager.AddNamespace("d", "http://schemas.microsoft.com/ado/2007/08/dataservices")


                Dim nextResultSet As String = document.SelectSingleNode(
                                                  "/atom:feed/atom:link[@rel='next']/@href",
                                                  namespaceManager).Value


                Dim imageResultsReducida As XmlNodeList = document.SelectNodes("/atom:feed/atom:entry/atom:content/m:properties/d:Thumbnail", namespaceManager)
                Dim imageResults As XmlNodeList = document.SelectNodes("/atom:feed/atom:entry/atom:content/m:properties", namespaceManager)

                Dim i = 0
                If Precarga = True Then
                    For Each imageResult As XmlNode In imageResults
                        Dim title As String = imageResult.SelectSingleNode(".//d:MediaUrl", namespaceManager).InnerText
                        datosVuelta(i, 0) = title
                        i += 1
                    Next

                    i = 0
                    For Each imageResult As XmlNode In imageResultsReducida
                        Dim title As String = imageResult.SelectSingleNode(".//d:MediaUrl", namespaceManager).InnerText
                        datosVuelta(i, 1) = title
                        i += 1
                    Next
                Else

                    i = 0
                    For Each imageResult As XmlNode In imageResultsReducida
                        Dim title As String = imageResult.SelectSingleNode(".//d:MediaUrl", namespaceManager).InnerText
                        datosVuelta(i, 0) = title
                        i += 1
                    Next

                    i = 0
                    For Each imageResult As XmlNode In imageResults
                        Dim title As String = imageResult.SelectSingleNode(".//d:MediaUrl", namespaceManager).InnerText
                        datosVuelta(i, 1) = title
                        i += 1
                    Next
                End If

            Catch
            End Try

            Return datosVuelta
        End Function

        Public Sub InfoImagenPrecarga(ByVal bmp As Bitmap, ByVal direccionURL As String) 'Con esto guardamos los datos si el usuario ha activado precarga
            guardarImagen(bmp, "Imagen original como recurso web") 'Almacenamos info y bitmap
            contadorImagenes = imagenesGuardadas.Count 'Lo asignamos como el contador actual
            RaiseEvent actualizaBMP(bmp) 'Generamos evento
            RaiseEvent actualizaNombreImagen(nombreRecursoWeb(direccionURL)) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
        End Sub

        Function abrirDragDrop(ByVal ruta As String) As Bitmap
            Try
                Dim bmp As New Bitmap(ruta)
                abrirDragDrop = bmp
                guardarImagen(abrirDragDrop, "Imagen original arrastrada") 'Almacenamos info y bitmap
                contadorImagenes = imagenesGuardadas.Count 'Lo asignamos como el contador actual
                RaiseEvent actualizaBMP(abrirDragDrop) 'Generamos evento
                RaiseEvent actualizaNombreImagen(nombreImagen(ruta)) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
                Return abrirDragDrop
            Catch
                Dim bmp As Bitmap
                bmp = Nothing
                Return bmp
            End Try
        End Function

#End Region
   
#Region "Funciones extra"
        Function nombreImagen(ByVal rutaImagen As String)
            Dim auxiliar, auxiliar2, nombre_imagen As String
            Dim nombre_imagen2() As String
            auxiliar = rutaimagen
            nombre_imagen2 = Split(auxiliar, "\")
            auxiliar2 = UBound(nombre_imagen2)
            nombre_imagen = nombre_imagen2(auxiliar2)
            Return nombre_imagen
        End Function

        Function nombreRecursoWeb(ByVal url As String)
            Dim auxiliar, auxiliar2, nombre_imagen As String
            Dim nombre_imagen2() As String
            auxiliar = url
            nombre_imagen2 = Split(auxiliar, "/")
            auxiliar2 = UBound(nombre_imagen2)
            nombre_imagen = nombre_imagen2(auxiliar2)
            Return nombre_imagen
        End Function

#End Region

    End Class

End Namespace