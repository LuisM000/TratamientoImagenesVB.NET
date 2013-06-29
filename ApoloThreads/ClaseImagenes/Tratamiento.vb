Imports System.Xml
Imports System.Net

Namespace Apolo
    ''' <summary>
    ''' Este delegado, recibe un Bitmap en cuanto se realiza una función dentro de la clase y se genera un evento indicando que se ha modificado la imagen.
    ''' <example><para>La forma de utilizar el evento (fuera de la clase) es la siguiente:
    ''' En el load del formulario se pone el siguiente código:</para>
    ''' <code>'Asignamos el gestor que controle cuando sale imagen
    '''AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf actualizarPicture)</code>
    ''' <para>Una vez hecho esto, se crea un procedimiento (por ejemplo), que muestre la imagen en un Picturebox:
    ''' <code>Sub actualizarPicture(ByVal bmp As Bitmap)
    '''PictureBox2.Image = bmp
    '''End Sub
    ''' </code></para></example>
    ''' </summary>
    ''' <param name="bmp">Imagen en formato Bitmap.</param>
    Public Delegate Sub ActualizamosImagen(ByVal bmp As Bitmap) 'Definimos el Tipo de evento

    ''' <summary>
    ''' Este delegado, recibe un string en cuanto se realiza una función de abrir una imagen original(desde archivo, FB, recurso web, etc) dentro de la clase y se genera un evento indicando que se ha abierto una imagen original y se dispone de información de ella.
    ''' <example><para>La forma de utilizar el evento (fuera de la clase) es la siguiente:
    ''' En el load del formulario se pone el siguiente código:</para>
    ''' <code>'Asignamos el gestor que controle cuando se abre una imagen nueva
    ''' AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf actualizarNombrePicture)</code>
    ''' <para>Una vez hecho esto, se crea un procedimiento (por ejemplo), que muestre la información recibida:
    ''' <code>Sub actualizarNombrePicture(ByVal nombre() As String)
    ''' 'Se le pone la información a la cabecera del formulario
    '''Me.Text = "[" + nombre(0) + "]  " + "(" + nombre(1) + " x " + nombre(2) + ")   " + nombre(3)
    '''End Sub
    ''' </code></para></example>
    ''' </summary>
    ''' <param name="NombreImagen">Esta variable es un string que tiene (generalmente) cuatro campos: nombre de la imagen, ancho de la imagen, alto de la imagen y procedencia de la imagen (desde archivo, BING, etc.).</param>
    Public Delegate Sub ActualizamosNombreImagen(ByVal NombreImagen() As String) 'Definimos el Tipo de evento

    ''' <summary>
    ''' La clase TratamientoImagenes permite crear aplicaciones con multitud de funcionalidades, todas ellas orientadas a tratamiento de imágenes. Con esta clase se pretende englobar todo el proceso
    ''' de creación de una aplicación de tratamiento de imágenes, desde la propias transformaciones, hasta la adquisición de imágenes o las funciones de deshacer/rehacer. 
    ''' <example><para>Para utilizar la clase en una aplicación, primero se debe hacer referencia con la sentencia Imports:</para>
    ''' <code>Imports nombredeaplicacion.Tratamiento</code>
    ''' <para>A continuación, se puede instanciar a la clase y por ejemplo asignar a un Picturebox una imagen transformada a tonos sepia:
    '''<code>Dim objetoTratamiento as new Tratamiento
    '''Dim bmp as new bitmap(Picturebox1.image) 
    '''Picturebox1.image=ObjetoTratamiento.sepia(bmp)</code></para>
    ''' </example>
    ''' </summary>
    ''' <remarks>Clase creada por Luis Marcos Rivera.</remarks>
    Public Class TratamientoImagenes

        'Variables para controlar atrás/adelante 
        ''' <summary>
        ''' Variable arraylist que almacena todas las imágenes que van entrando a la clase.
        ''' </summary>
        Public Shared imagenesGuardadas As New ArrayList 'Para ir atrás y adelante, Lo creamos como
        'Se crea como shared para que no se cree de nuevo en cada instancia
        Private Shared contadorImagenes As Integer 'Para saber en qué índice de las imágenesGUardadas estamos
        Private Shared Informacion As New ArrayList 'Para saber qué se hizo
        '************************************

        'Variables para controlar atrás/adelante imágenes originales

        ''' <summary>
        ''' Variable bitmap que almacena la última imagen original abierta.
        ''' </summary>
        Public Shared imagenOriginal As Bitmap 'Imagen original guardada
        'Se crea como shared para que no se cree de nuevo en cada instancia
        Private Shared InformacionOrig As String 'Para saber qué se hizo
        '************************************

        Private Shared ZoomActual As Double = 1 'Variable para conocer el zoom actual


        'Estado hilo
        ''' <summary>
        ''' Variable que indica el estado de progreso de una transformación. Se puede utilizar con un timer..
        ''' </summary>
        ''' <remarks>La primera posición del string porcentaje(0) indica el porcentaje de progreso. La segunda posición indica el estado del progreso.</remarks>
        Public Shared porcentaje(1) As String

        'Evento de tipo ActualizamosImagen
        ''' <summary>
        ''' Evento que gestiona cuándo se modifica la imagen (entra una imagen en la clase y se devuelve transformada).
        ''' </summary>
        Event actualizaBMP As ActualizamosImagen

        'Evento de tipo ActualizamosImagen
        ''' <summary>
        ''' Evento que gestiona cuándo se abre una imagen original, ya sea desde archivo, BING, Facebook, etc.
        ''' </summary>
        Event actualizaNombreImagen As ActualizamosNombreImagen


        'Propiedad con el estado de la carga
        ''' <summary>
        ''' Proporciona información sobre el estado actual de carga.
        ''' Devuelve un array con 2 valores. El primero, es porcentaje de carga (0 a 100) y el segundo, la función que se está realizando (por ejemplo, "Transformando en escala de grises".
        ''' </summary>
        Public ReadOnly Property estadoCarga() As Array 'Propiedad con el estado de la carga
            Get
                'Serán dos valores, el porcentaje de carga y quién está realizando la acción
                Return porcentaje
            End Get
        End Property

        'Propiedades y métodos para hacer y rehacer el conjunto de imágenes
#Region "Hacer/deshacerImagenes"

        ''' <summary>
        ''' Proporciona la imagen anterior a la actual (para hacer retroceso).
        ''' </summary>
        Public ReadOnly Property ListadoImagenesAtras() As Bitmap 'Imagen hacia atrás
            Get
                Try
                    contadorImagenes -= 1
                    RaiseEvent actualizaBMP(imagenesGuardadas.Item(contadorImagenes - 1))
                    Zoom = 1
                    Return imagenesGuardadas.Item(contadorImagenes - 1)

                Catch e As System.ArgumentOutOfRangeException
                    contadorImagenes += 1
                    Zoom = 1
                    Return imagenesGuardadas.Item(contadorImagenes - 1)
                End Try
            End Get
        End Property

        ''' <summary>
        ''' Proporciona la imagen posterior (en caso de haberla) a la actual.
        ''' </summary>
        Public ReadOnly Property ListadoImagenesAdelante() As Bitmap 'Imagen hacia delante
            Get
                Try
                    contadorImagenes += 1
                    RaiseEvent actualizaBMP(imagenesGuardadas.Item(contadorImagenes - 1))
                    Zoom = 1
                    Return imagenesGuardadas.Item(contadorImagenes - 1)
                Catch e As System.ArgumentOutOfRangeException
                    contadorImagenes -= 1
                    Zoom = 1
                    Return imagenesGuardadas.Item(contadorImagenes - 1)
                End Try
            End Get
        End Property

        ''' <summary>
        ''' Proporciona la información del estado de la imagen anterior a la actual (para hacer retroceso).
        ''' </summary>
        Public ReadOnly Property ListadoInfoAtras() As String 'Imagen hacia atrás
            Get
                Try
                    Return Informacion.Item(contadorImagenes - 1)
                Catch e As System.ArgumentOutOfRangeException
                    Return "No disponible"
                End Try
            End Get
        End Property

        ''' <summary>
        ''' Proporciona la información del estado de la imagen posterior (en caso de haberla) a la actual.
        ''' </summary>
        Public ReadOnly Property ListadoInfoAdelante() As String 'Imagen hacia delante
            Get
                Try
                    Return Informacion.Item(contadorImagenes)
                Catch e As System.ArgumentOutOfRangeException
                    Return "No disponible"
                End Try
            End Get
        End Property

        ''' <summary>
        ''' Devuelve una lista (arraylist) con toda la información de todas las transformaciones realizadas.
        ''' </summary>
        Public ReadOnly Property ListadoTotalDeInfo() As ArrayList 'Toda la info de imágenes
            Get
                Return Informacion
            End Get
        End Property

        ''' <summary>
        ''' Devuelve una lista (arraylist) con todas las imágenes (en formato Bitmap) de todas las transformaciones realizadas.
        ''' </summary>
        Public ReadOnly Property ListadoTotalDeImagenes() As ArrayList 'Todas las imágenes
            Get
                Return imagenesGuardadas
            End Get
        End Property

        ''' <summary>
        ''' Devuelve el estado del zoom actual de la imagen (si devuelve 1, la imagen no tiene aumento)
        ''' </summary>
        Public Property Zoom As Double
            Get
                Return ZoomActual
            End Get
            Set(value As Double)
                ZoomActual = Math.Round(value, 1)
            End Set
        End Property


        'Almacenamos la imagen
        ''' <summary>
        ''' Almacena la imagen y su información para poder deshacer/rehacer
        ''' </summary>
        ''' <param name="bmp">Imagen (en formato Bitmap) tras la transformación</param>
        ''' <param name="info">Información (string) de qué transformación ha sufrido la imagen</param>
        Private Sub guardarImagen(ByVal bmp As Bitmap, ByVal info As String) 'Para almacenar el bitmap y la información
            'Almacenamos la imagen con su información y añadimos +1 al contador
            If imagenesGuardadas.Count < 100 Then
                imagenesGuardadas.Add(bmp)
                contadorImagenes = imagenesGuardadas.Count
                Informacion.Add(info)
                Zoom = 1 'Establecemos el zoom a 1
            Else
                'Con esto controlamos que si hemos almacenado más de 100 imágenes
                'Quitamos la primera y la nueva la incluimos en el último lugar
                imagenesGuardadas.RemoveAt(0)
                Informacion.RemoveAt(0)
                imagenesGuardadas.Add(bmp)
                Informacion.Add(info)
                Zoom = 1 'Establecemos el zoom a 1
            End If
        End Sub

        'Liberar todas imágenes 
        ''' <summary>
        ''' Elimina todo el contenido de imágenes e información almacenada, dejando únicamente la imagen actual.
        ''' </summary>
        Public Sub LiberarImagenes() 'Borra todas las imágenes excepto la última
            'Guardamos la última imagen y la última info asociada a esa imagen
            Dim imgFinal As New Bitmap(CType(imagenesGuardadas.Item(imagenesGuardadas.Count - 1), Bitmap))
            Dim infoFinal As String = Informacion.Item(Informacion.Count - 1)
            'Borramos los arraylist que contienen la imagen e info
            imagenesGuardadas.Clear()
            Informacion.Clear()
            'Se añaden sendas variables a los arraylist
            imagenesGuardadas.Add(imgFinal)
            Informacion.Add(infoFinal)
        End Sub

#End Region


        'Gestionar la imagen original actual
#Region "Hacer/deshacer imagenes originales"

        ''' <summary>
        ''' Devuelve la última imagen abierta como original (desde archivo, bing, etc). 
        ''' En caso de asignar un valor, éste debe ser una imagen abierta como original (no recomendable asignar un valor desde fuera de la clase).
        ''' <example>Para obtener la última imagen abierta, el código sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.ImagenOriginalGuardada</code></example>
        ''' </summary>
        Public Property ImagenOriginalGuardada() As Bitmap 'Imagen original hacia atrás
            Get
                RaiseEvent actualizaBMP(imagenOriginal) 'generamos el evento
                guardarImagen(imagenOriginal, InformacionOrig)
                Return imagenOriginal
            End Get

            Set(value As Bitmap)
                imagenOriginal = value
            End Set
        End Property


        ''' <summary>
        ''' Devuelve la INFORMACIÓN de la última imagen abierta como original (desde archivo, bing, etc) . //
        ''' En caso de asignar un valor, éste debe ser la información de una imagen abierta como original (no recomendable asignar un valor desde fuera de la clase).
        ''' <example>Para obtener la información (de dónde se ha obtenido el recurso), de la última imagen abierta, se haría así:
        ''' <code>Picturebox1.image=objetoTratamiento.ImagenOriginalGuardada</code></example>
        ''' </summary>
        Public Property imagenOriginalInfo() As String 'Imagen hacia atrás
            Get
                Return InformacionOrig
            End Get
            Set(value As String)
                InformacionOrig = value
            End Set
        End Property


#End Region




        'Contiene el conjunto de funciones para tratamiento de imágenes digitales
#Region "FuncionesTratamiento"

        'Función para obtener los niveles digitales de la imagen
        ''' <summary>
        ''' Devuelve una matriz con los colores de cada píxel.
        ''' <example>A continuación se muestra un ejemplo de llamada a la función: // 
        ''' <code> Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen  //
        ''' Niveles = nivel(bmp2) 'Obtenemos valores
        ''' </code>
        ''' </example>
        ''' </summary>
        ''' <param name="bmp">Imagen en formato Bitmap de la cual se quiere extraer los colores.</param>
        ''' <returns>Devuelve una matriz de dos dimensiones (ancho*alto de la imagen) y cada celda contiene un System.Drawing.Color con el valor del píxel.</returns>
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

        'Hace que la imagen enviada se guarde
        ''' <summary>
        ''' Actualiza la imagen enviada para que pase a ser la primera en la lista de deshacer/rehacer, y devuelve la imagen enviada.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así: 
        ''' <code>Picturebox1.image=objetoTratamiento.ActualizarImagen(bmp,False)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen en formato Bitmap que pasará a ser la primera de la lista (y será devuelta).</param>
        ''' <param name="imagenOriginal">En caso de ser TRUE, la imagen enviada se almacenará como una imagen original.</param>
        ''' <returns>Devuelve un Bitmap con la imagen enviada.</returns>
        Public Function ActualizarImagen(ByVal bmp As Bitmap, Optional ByVal imagenOriginal As Boolean = False) As Bitmap
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp, "Actualizar imagen") 'Guardamos la imagen para poder hacer retroceso
            If imagenOriginal = True Then 'Si queremos guardarla como imagen original
                'Guardamos la imagen original
                ImagenOriginalGuardada = bmp
                imagenOriginalInfo = "Imagen original"
            End If
            RaiseEvent actualizaBMP(bmp) 'generamos el evento
            Return bmp
        End Function

        'Contiene todas las funciones con operaciones básicas (devuelven un Bitmap)
        'Escala de grises// invertir// Blanco y negro// contraste// sepia// Filtro ponderado// Brillo// Exposición
        'Modificar canales// Filtros básicos// RGBto// Reducir colores//Filtrar colores por rango//
        'Detectar contornos// reflexión
#Region "OperacionesBasicas"

        ''' <summary>
        ''' Función que transforma una imagen en escala de grises.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así: 
        ''' <code>Picturebox1.image=objetoTratamiento.EscalaGrises(bmp,20)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="valorcontraste">Este valor reduce el número de grises utilizados (0 a 127). El 0 es toda la gama de grises y el 127 es blanco y negro.</param>
        ''' <returns>Devuelve un bitmap.</returns>
        Public Function EscalaGrises(ByVal bmp As Bitmap, Optional ByVal valorcontraste As Byte = 0) As Bitmap
            'Copia del bitmap original
            Dim bmp2 As Bitmap = bmp
            'Matriz que almacenará los niveles digitales de la imagen
            Dim Niveles(,) As System.Drawing.Color
            'Se obtienen los valores de la imagen
            Niveles = nivel(bmp2)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Transformando a escala de grises (" & valorcontraste & ")" 'Actualizar el estado
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            Dim valoralto, valorbajo As Byte
            valorbajo = 128 - valorcontraste
            valoralto = 128 + valorcontraste
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim media As Double 'Variable para calcular la media
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    rojoaux = Niveles(i, j).R
                    verdeaux = Niveles(i, j).G
                    azulaux = Niveles(i, j).B
                    media = CInt((rojoaux + verdeaux + azulaux) / 3) 'Hacemos la media
                    If media >= valorbajo And media <= valoralto Then 'Calculamos a qué valor lo asignamos
                        If (media - valorbajo) <= (valoralto - media) Then
                            media = valorbajo
                        Else
                            media = valoralto
                        End If
                    End If
                    Rojo = media
                    Verde = media
                    Azul = media
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp3, "Escala de grises (" & valorcontraste & ")") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            'Se devuelve el bitmap pasado a escala de grises
            Return bmp3
        End Function


        ''' <summary>
        ''' Función que invierte los colores de una imagen (para los canales RGB).
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así: 
        ''' <code>Picturebox1.image=objetoTratamiento.Invertir(bmp,TRUE,TRUE,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="Irojo">Para invertir el canal rojo, TRUE. Si no se quiere afectar al canal rojo, FALSE.</param>
        ''' <param name="Iverde">Para invertir el canal verde, TRUE. Si no se quiere afectar al canal verde, FALSE.</param>
        ''' <param name="Iazul">Para invertir el canal azul, TRUE. Si no se quiere afectar al canal azul, FALSE.</param>
        ''' <returns>Devuelve un bitmap.</returns>
        Public Function Invertir(ByVal bmp As Bitmap, Optional ByVal Irojo As Boolean = True, Optional ByVal Iverde As Boolean = True, Optional ByVal Iazul As Boolean = True) As Bitmap
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp) 'Obtenemos valores
            Dim TipoEstado As String = "Invertir"
            'Creamos el estado
            If Irojo = True Then TipoEstado = "Invertir rojo" Else If Iverde = True Then TipoEstado = "Invertir verde" Else If Iazul = True Then TipoEstado = "Invertir azul"
            If Irojo = True And Iverde = True And Iazul = True Then TipoEstado = "Invertir RGB"
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = TipoEstado 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    If Irojo = True Then
                        Rojo = 255 - (Niveles(i, j).R) 'Realizamos la inversión de los colores
                    Else
                        Rojo = Niveles(i, j).R
                    End If
                    If Iverde = True Then
                        Verde = 255 - (Niveles(i, j).G)
                    Else
                        Verde = Niveles(i, j).G
                    End If
                    If Iazul = True Then
                        Azul = 255 - (Niveles(i, j).B)
                    Else
                        Azul = Niveles(i, j).B
                    End If
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            guardarImagen(bmp, TipoEstado) 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp) 'generamos el evento
            Return bmp
        End Function

        ''' <summary>
        ''' Función que transforma una imagen a blanco y negro (binariza).
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así: 
        ''' <code>Picturebox1.image=objetoTratamiento.BlancoNegro(bmp,128)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="valortope">Indica el valor umbral a partir del cual el píxel será negro o blanco. Si por ejemplo se selecciona 128, los valores 
        ''' inferiores pasarán a ser negro (0), y los superiores blanco (128).</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function BlancoNegro(ByVal bmp As Bitmap, Optional ByVal valortope As Byte = 128) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Transformando a blanco y negro (" & valortope & ")" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte
            Dim media As Double
            Dim rojoaux, verdeaux, azulaux As Double

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    rojoaux = Niveles(i, j).R
                    verdeaux = Niveles(i, j).G
                    azulaux = Niveles(i, j).B

                    'Calculamos la media 
                    media = CInt((rojoaux + verdeaux + azulaux) / 3)
                    'En función de si el valor es mayor o menor de 128 (mitad aproximada
                    'de 255), lo convertimos en blanco o negro
                    If media >= valortope Then
                        Rojo = 255
                        Verde = 255
                        Azul = 255
                    Else
                        Rojo = 0
                        Verde = 0
                        Azul = 0
                    End If
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp3, "Blanco y negro (" & valortope & ")") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que aumenta o disminuye el contraste. "Estira" o "encoge" los valores de la imagen hasta el tope superior e inferior seleccionado.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así: 
        ''' <code>Picturebox1.image=objetoTratamiento.ContrasteEstirar(bmp,0,255)</code></example>
        ''' En este ejemplo, la imagen pasará a ocupar todos los niveles (de 0 a 255), siempre que sea posible.
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="valorContrasteMax">Valor máximo que pasará a tener el píxel con valor más alto.</param>
        ''' <param name="valorContrasteMin">Valor mínimo que pasará a tener el píxel con valor más bajo</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Debe tenerse en cuenta que el valor valorContrasteMax debe ser mayor que valorContrasteMin.</remarks>
        Public Function ContrasteEstirar(ByVal bmp As Bitmap, ByVal valorContrasteMax As Byte, ByVal valorContrasteMin As Byte) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)

            'Creamos el estado
            porcentaje(0) = 0 'Actualizar el estado

            Dim RojoMax, VerdeMax, AzulMax As Byte
            Dim RojoMin, VerdeMin, AzulMin As Byte
            RojoMax = 0 : VerdeMax = 0 : AzulMax = 0
            RojoMin = 255 : VerdeMin = 255 : AzulMin = 255
            porcentaje(1) = "Calculando extremos" 'Actualizar el estado
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz para calcular valor mínimo y máximo
                For j = 0 To Niveles.GetUpperBound(1)
                    If Niveles(i, j).R > RojoMax Then RojoMax = Niveles(i, j).R
                    If Niveles(i, j).G > VerdeMax Then VerdeMax = Niveles(i, j).G
                    If Niveles(i, j).B > AzulMax Then AzulMax = Niveles(i, j).A
                    If Niveles(i, j).R < RojoMin Then RojoMin = Niveles(i, j).R
                    If Niveles(i, j).G < VerdeMin Then VerdeMin = Niveles(i, j).G
                    If Niveles(i, j).B < AzulMin Then AzulMin = Niveles(i, j).B
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next

            porcentaje(1) = "Modificando contraste estirado" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz para calcular valor mínimo y máximo
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = CByte((valorContrasteMax - valorContrasteMin) * ((Niveles(i, j).R - RojoMin) / (RojoMax - RojoMin)) + valorContrasteMin)
                    Verde = CByte((valorContrasteMax - valorContrasteMin) * ((Niveles(i, j).G - VerdeMin) / (VerdeMax - VerdeMin)) + valorContrasteMin)
                    Azul = CByte((valorContrasteMax - valorContrasteMin) * ((Niveles(i, j).B - AzulMin) / (AzulMax - AzulMin)) + valorContrasteMin)

                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next

            guardarImagen(bmp3, "Contraste modificado estirado") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que aumenta o disminuye el contraste. "Estira" o "encoge" el histograma de la imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así: 
        ''' <code>Picturebox1.image=objetoTratamiento.Contraste(bmp,1.2)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="valorContraste">Valor de contraste. Debe oscilar entre -1 y 1 para unos resultados óptimos.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function Contraste(ByVal bmp As Bitmap, ByVal valorContraste As Double) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)


            'Creamos el estado
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Modificando contraste" 'Actualizar el estado

            Dim Rojo, Verde, Azul, alfa As Byte
            Dim Rojoaxu, Verdeaux, Azulaux As Double
            Dim calculo, calculoAux As Double
            calculoAux = (1 / ((Math.PI) / 4)) 'Con esto hacemos que si recibimos 0 (valorcontraste) no haya modificación en la imagen
            calculo = (valorContraste + 1) * (Math.PI / 4) 'Pi/4
            calculo *= calculoAux


            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz para calcular valor mínimo y máximo
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaxu = ((Niveles(i, j).R - 128) * calculo) + 128
                    Verdeaux = ((Niveles(i, j).G - 128) * calculo) + 128
                    Azulaux = ((Niveles(i, j).B - 128) * calculo) + 128
                    If Rojoaxu > 255 Then Rojoaxu = 255
                    If Verdeaux > 255 Then Verdeaux = 255
                    If Azulaux > 255 Then Azulaux = 255

                    If Rojoaxu < 0 Then Rojoaxu = 0
                    If Verdeaux < 0 Then Verdeaux = 0
                    If Azulaux < 0 Then Azulaux = 0

                    Rojo = Rojoaxu
                    Verde = Verdeaux
                    Azul = Azulaux

                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next

            guardarImagen(bmp3, "Contraste modificado") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que transforma una imagen a tonos sepia.
        '''<example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así: 
        ''' <code>Picturebox1.image=objetoTratamiento.sepia(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Los pesos para el filtro sepia son: 0.393, 0.769, 0.189, 0.349, 0.686, 0.168, 0.272, 0.534, 0.131 .</remarks>
        Public Function sepia(ByVal bmp As Bitmap)
            Return filtroponderado(bmp, 0.393, 0.769, 0.189, 0.349, 0.686, 0.168, 0.272, 0.534, 0.131)
        End Function

        ''' <summary>
        ''' Esta función aplica a cada canal un peso específico multiplicándolo por los 3 canales (RGB).
        ''' <para>Rojo = Rojo * Rr + Verde * Rg + Azul * Rb</para>
        ''' <para>Verde = Rojo * Gr + Verde * Gg + Azul * Gb</para>
        ''' <para>Azul = Rojo * Br + Verde * Bg + Azul * Bb</para>
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.filtroponderado(bmp, 0.393, 0.769, 0.189, 0.349, 0.686, 0.168, 0.272, 0.534, 0.131)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="Rr">Peso que será multiplicado por el rojo y aplicado en el canal rojo.</param>
        ''' <param name="Rg">Peso que será multiplicado por el verde y aplicado en el canal rojo.</param>
        ''' <param name="Rb">Peso que será multiplicado por el azul y aplicado en el canal rojo.</param>
        ''' <param name="Gr">Peso que será multiplicado por el rojo y aplicado en el canal verde.</param>
        ''' <param name="Gg">Peso que será multiplicado por el verde y aplicado en el canal verde.</param>
        ''' <param name="Gb">Peso que será multiplicado por el azul y aplicado en el canal verde.</param>
        ''' <param name="Br">Peso que será multiplicado por el rojo y aplicado en el canal azul.</param>
        ''' <param name="Bg">Peso que será multiplicado por el verde y aplicado en el canal azul.</param>
        ''' <param name="Bb">Peso que será multiplicado por el azul y aplicado en el canal azul.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Para no alterar los tonos de la imagen, la suma de los 3 pesos por cada canal debe ser igual a 1.</remarks>
        Public Function filtroponderado(ByVal bmp As Bitmap, Optional ByVal Rr As Double = 1, Optional ByVal Rg As Double = 0, Optional ByVal Rb As Double = 0, Optional ByVal Gr As Double = 0, Optional ByVal Gg As Double = 1, Optional ByVal Gb As Double = 0, Optional ByVal Br As Double = 0, Optional ByVal Bg As Double = 0, Optional ByVal Bb As Double = 1)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Aplicando filtro ponderado" 'Actualizar el estado

            Dim Rojo, Verde, Azul, alfa As Byte
            Dim Rojoaux, Verdeaux, Azulaux As UInteger

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = (Niveles(i, j).R)
                    Verde = (Niveles(i, j).G)
                    Azul = (Niveles(i, j).B)
                    'Ponderamos los valores
                    Rojoaux = CInt(Rojo * Rr + Verde * Rg + Azul * Rb)
                    Verdeaux = CInt(Rojo * Gr + Verde * Gg + Azul * Gb)
                    Azulaux = CInt(Rojo * Br + Verde * Bg + Azul * Bb)
                    'Eliminamos excesos
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeaux > 255 Then Verdeaux = 255
                    If Azulaux > 255 Then Azulaux = 255
                    Rojo = Rojoaux : Verde = Verdeaux : Azul = Azulaux
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp3, "Filtro ponderado") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que aumenta o disminuye el brillo de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.Brillo(bmp,20)</code>
        ''' Esta función aumenta en 20 puntos el brillo de la imagen.</example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="cantidad">Cantidad de brillo que se sumará/restará a cada píxel.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function Brillo(ByVal bmp As Bitmap, ByVal cantidad As Integer)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2)
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Modificando brillo" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim AuxiliarR, AuxiliarG, AuxiliarB As Integer
            Dim AuxiliarR2, AuxiliarG2, AuxiliarB2 As Integer

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    'Realizamos primeramente el cálculo con variables auxiliares, para 
                    'que no se desborde las variables Rojo, Verde, Azul
                    AuxiliarR2 = Niveles(i, j).R
                    AuxiliarG2 = Niveles(i, j).G
                    AuxiliarB2 = Niveles(i, j).B
                    AuxiliarR = AuxiliarR2 + cantidad 'Aumentamos/dismin el color rojo
                    AuxiliarG = AuxiliarG2 + cantidad 'Aumentamos/dismin el color verde
                    AuxiliarB = AuxiliarB2 + cantidad 'Aumentamos/dismin el color azul
                    'Comprobamos que no hay valores no válidos, es decir, mayores de 255
                    'Si hay valores mayores, los igualamos a 255
                    If AuxiliarR > 255 Then AuxiliarR = 255
                    If AuxiliarG > 255 Then AuxiliarG = 255
                    If AuxiliarB > 255 Then AuxiliarB = 255
                    'Comprobamos que no hay valores no válidos, es decir, menores de 0
                    'Si hay valores menores, los igualamos a 0
                    If AuxiliarR < 0 Then AuxiliarR = 0
                    If AuxiliarG < 0 Then AuxiliarG = 0
                    If AuxiliarB < 0 Then AuxiliarB = 0
                    Rojo = AuxiliarR
                    Verde = AuxiliarG
                    Azul = AuxiliarB
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Modificar brillo") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que modifica la gamma de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.gamma(bmp,2,2,2)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="ValorGammaRojo">Correción de gamma que se aplicará al canal rojo. Debe ser mayor que 0. El valor 1 no aplica ninguna correción.</param>
        ''' <param name="ValorGammaVerde">Correción de gamma que se aplicará al canal verde. Debe ser mayor que 0. El valor 1 no aplica ninguna correción.</param>
        ''' <param name="ValorGammaAzul">Correción de gamma que se aplicará al canal azul. Debe ser mayor que 0. El valor 1 no aplica ninguna correción.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function Gamma(ByVal bmp As Bitmap, ByVal ValorGammaRojo As Double, ByVal ValorGammaVerde As Double, ByVal ValorGammaAzul As Double)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2)
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Modificando gamma" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    'Cambiamos la gamma creando una rampa de contraste
                    Rojo = CByte(Math.Min(255, CInt(Math.Truncate((255.0 * Math.Pow(Niveles(i, j).R / 255.0, 1.0 / ValorGammaRojo)) + 0.5))))
                    Verde = CByte(Math.Min(255, CInt(Math.Truncate((255.0 * Math.Pow(Niveles(i, j).G / 255.0, 1.0 / ValorGammaVerde)) + 0.5))))
                    Azul = CByte(Math.Min(255, CInt(Math.Truncate((255.0 * Math.Pow(Niveles(i, j).B / 255.0, 1.0 / ValorGammaAzul)) + 0.5))))
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Modificar gamma") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que aumenta o disminuye la exposición de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:</example>
        ''' <code>Picturebox1.image=objetotratamiento.Exposicion(bmp,0.6)</code>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="valorSobreexposicion">Variable que indica el aumento o disminución de la exposición. Valores menores que 1 aumentan la exposición y mayores la disminuyen.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function Exposicion(ByVal bmp As Bitmap, ByVal valorSobreexposicion As Double)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2)
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Modificando exposición" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            If valorSobreexposicion = 0 Then valorSobreexposicion = 0.001
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R / valorSobreexposicion 'Ajustamos la exposición
                    Verde = Niveles(i, j).G / valorSobreexposicion
                    Azul = Niveles(i, j).B / valorSobreexposicion
                    If Rojo > 255 Then Rojo = 255
                    If Verde > 255 Then Verde = 255
                    If Azul > 255 Then Azul = 255
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Modificar exposición") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que aumenta o disminuye canal por canal (ARGB) los valores de los píxeles.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.Canales(bmp,10,30,-20,0)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="canalrojo">Variable que indica el valor que se va a modificar en el canal rojo.</param>
        ''' <param name="canalverde">Variable que indica el valor que se va a modificar en el canal verde.</param>
        ''' <param name="canalazul">Variable que indica el valor que se va a modificar en el canal azul.</param>
        ''' <param name="canaalfa">Variable que indica el valor que se va a modificar en el canal alfa.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function Canales(ByVal bmp As Bitmap, Optional ByVal canalrojo As Integer = 0, Optional ByVal canalverde As Integer = 0, Optional ByVal canalazul As Integer = 0, Optional ByVal canaalfa As Integer = 0)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2)
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Modificando canales" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux, Alfaaux As Double 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R + canalrojo 'Aumentamos/disminuimos por canal
                    Verdeuax = Niveles(i, j).G + canalverde 'Realizamos la inversión de los colores
                    Azulaux = Niveles(i, j).B + canalazul 'Realizamos la inversión de los colores
                    Alfaaux = Niveles(i, j).A + canaalfa 'Realizamos la inversión de los colores
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeuax > 255 Then Verdeuax = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If Alfaaux > 255 Then Alfaaux = 255
                    If Rojoaux < 0 Then Rojoaux = 0
                    If Verdeuax < 0 Then Verdeuax = 0
                    If Azulaux < 0 Then Azulaux = 0
                    If Alfaaux < 0 Then Alfaaux = 0
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux : alfa = Alfaaux
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Modificar canales") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que calcula la media de las canales RGB para cada píxel, y el valor resultante lo asignan al canal al que se le ha asignado el valor TRUE.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.filtrosBasicos(bmp,TRUE,FALSE,FALSE)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="FRojo">Si el valor es TRUE, la media calculada se asignará al canal rojo. En caso de ser FALSE el canal rojo será 0.</param>
        ''' <param name="FVerde">Si el valor es TRUE, la media calculada se asignará al canal verde. En caso de ser FALSE el canal verde será 0.</param>
        ''' <param name="Fazul">Si el valor es TRUE, la media calculada se asignará al canal azul. En caso de ser FALSE el canal azul será 0.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Tenga en cuenta que sólo se debería poner un único canal como TRUE.</remarks>
        Public Function filtrosBasicos(ByVal bmp As Bitmap, Optional ByVal FRojo As Boolean = False, Optional ByVal FVerde As Boolean = False, Optional ByVal Fazul As Boolean = False)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2)
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            Dim TipoEstado As String = "Filtro básico"
            'Creamos el estado
            If FRojo = True Then TipoEstado = "Filtro básico rojo" Else If FVerde = True Then TipoEstado = "Filtro básico verde" Else If Fazul = True Then TipoEstado = "Filtro básico azul"
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = TipoEstado 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeaux, Azulaux As Double 'Declaramos tres variables que almacenarán los colores
            'Calculamos la media, y asignamos el color al rojo (por ejemplo) y al resto 0
            Dim media As Double 'Variable para calcular la media
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R
                    Verdeaux = Niveles(i, j).G
                    Azulaux = Niveles(i, j).B
                    'Calculamos la media conviertiendo el resultado en un integer (CInt)
                    media = CInt((Rojoaux + Verdeaux + Azulaux) / 3)
                    If FRojo = True Then
                        Rojo = media
                        Verde = 0
                        Azul = 0
                    ElseIf FVerde = True Then
                        Rojo = 0
                        Verde = media
                        Azul = 0
                    ElseIf Fazul = True Then
                        Rojo = 0
                        Verde = 0
                        Azul = media
                    End If
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, TipoEstado) 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que intercambia, para cada píxel, el valor de sus canales RGB.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.RGBto(bmp,TRUE,FALSE,FALSE)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="BGR">Si el valor es TRUE, el canal rojo pasará a tener el valor del canal azul, el canal azul pasará a tener el valor del canal rojo, y el canal verde mantendrá su valor.</param>
        ''' <param name="GRB">Si el valor es TRUE, , el canal rojo pasará a tener el valor del canal verde, el canal verde pasará a tener el valor del canal rojo, y el canal azul mantendrá su valor.</param>
        ''' <param name="RBG">Si el valor es TRUE, el canal verde pasará a tener el valor del canal azul, el canal azul pasará a tener el valor del canal verde, y el canal rojo mantendrá su valor.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Tenga en cuenta que sólo se debería asignar TRUE a una de las tres variables (BGR, GRB, RBG).</remarks>
        Public Function RGBto(ByVal bmp As Bitmap, Optional ByVal BGR As Boolean = False, Optional ByVal GRB As Boolean = True, Optional ByVal RBG As Boolean = False)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            Dim TipoEstado As String = "RGB a"
            'Creamos el estado
            If BGR = True Then TipoEstado = "RGB a BGR" Else If GRB = True Then TipoEstado = "RGB a GRB" Else If RBG = True Then TipoEstado = "RGB a RBG"
            porcentaje(1) = TipoEstado
            Dim Rojo, Verde, Azul, alfa As Byte

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    If BGR = True Then
                        Rojo = Niveles(i, j).B 'Realizamos la modificacion de los colores
                        Verde = Niveles(i, j).G 'Realizamos la modificacion de los colores
                        Azul = Niveles(i, j).R 'Realizamos la modificacion de los colores
                    ElseIf GRB = True Then
                        Rojo = Niveles(i, j).G 'Realizamos la modificacion de los colores
                        Verde = Niveles(i, j).R 'Realizamos la modificacion de los colores
                        Azul = Niveles(i, j).B 'Realizamos la modificacion de los colores
                    Else
                        Rojo = Niveles(i, j).R 'Realizamos la modificacion de los colores
                        Verde = Niveles(i, j).B 'Realizamos la modificacion de los colores
                        Azul = Niveles(i, j).G 'Realizamos la modificacion de los colores
                    End If
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, TipoEstado) 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function


        ''' <summary>
        ''' Función que reduce los colores de la imagen. Pudiendo pasar de 255 por canal a 1 por canal.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.reducircolores(bmp,60)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="valorcolores">Variable que indica el número de colores de cada canal.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Tenga en cuenta que el valor 0 equivale a un color por canal.</remarks>
        Public Function reducircolores(ByVal bmp As Bitmap, ByVal valorcolores As Byte)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Reduciendo colores (" & valorcolores & ")" 'Actualizar el estado
            Dim valoralto, valorbajo As Byte
            valorbajo = 128 - valorcolores
            valoralto = 128 + valorcolores
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).B
                    If Rojo >= valorbajo And Rojo <= valoralto Then
                        If (Rojo - valorbajo) <= (valoralto - Rojo) Then
                            Rojo = valorbajo
                        Else
                            Rojo = valoralto
                        End If
                    End If

                    If Verde >= valorbajo And Verde <= valoralto Then
                        If (Verde - valorbajo) <= (valoralto - Verde) Then
                            Verde = valorbajo
                        Else
                            Verde = valoralto
                        End If
                    End If

                    If Azul >= valorbajo And Azul <= valoralto Then
                        If (Azul - valorbajo) <= (valoralto - Azul) Then
                            Azul = valorbajo
                        Else
                            Azul = valoralto
                        End If
                    End If
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Reducir colores (" & valorcolores & ")")
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que permite seleccionar un rango de colores (por canal RGB) y pasar todos los píxeles de ese rango a un valor determinado.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.filtroColoresRango(bmp,0,100,0,0,0,0,0,0,0)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="valorRojoinf">Valor inferior del rango para el canal rojo.</param>
        ''' <param name="valorRojosup">Valor superior del rango para el canal rojo.</param>
        ''' <param name="salidaRojo">Valor de salida para los píxeles dentro del rango del canal rojo.</param>
        ''' <param name="valorVerdeinf">Valor inferior del rango para el canal verde.</param>
        ''' <param name="valorVerdesup">Valor superior del rango para el canal verde.</param>
        ''' <param name="salidaVerde">Valor de salida para los píxeles dentro del rango del canal verde.</param>
        ''' <param name="valorAzulinf">Valor inferior del rango para el canal azul.</param>
        ''' <param name="valorAzulsup">Valor superior del rango para el canal azul.</param>
        ''' <param name="salidaAzul">Valor de salida para los píxeles dentro del rango del canal azul.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Los valores inferiores siempre deben ser mayores que los superiores.</remarks>
        Public Function filtroColoresRango(ByVal bmp As Bitmap, Optional ByVal valorRojoinf As Byte = 0, Optional ByVal valorRojosup As Byte = 0, Optional ByVal salidaRojo As Byte = 0, Optional ByVal valorVerdeinf As Byte = 0, Optional ByVal valorVerdesup As Byte = 0, Optional ByVal salidaVerde As Byte = 0, Optional ByVal valorAzulinf As Byte = 0, Optional ByVal valorAzulsup As Byte = 0, Optional ByVal salidaAzul As Byte = 0)
            If valorRojoinf > valorRojosup Or valorVerdeinf > valorVerdesup Or valorAzulinf > valorAzulsup Then
                MessageBox.Show("El valor inferior debe ser mayor que el superior.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return bmp
            Else
                Dim bmp2 = bmp
                Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
                Niveles = nivel(bmp2) 'Obtenemos valores
                Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
                porcentaje(0) = 0 'Actualizar el estado
                porcentaje(1) = "Filtrando colores" 'Actualizar el estado
                Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
                For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                    For j = 0 To Niveles.GetUpperBound(1)
                        Rojo = Niveles(i, j).R
                        If Rojo >= valorRojoinf And Rojo <= valorRojosup Then 'Comprobamos el color
                            Rojo = salidaRojo
                        End If
                        Verde = Niveles(i, j).G
                        If Verde >= valorVerdeinf And Verde <= valorVerdesup Then 'Comprobamos el color
                            Verde = salidaVerde
                        End If

                        Azul = Niveles(i, j).B
                        If Azul >= valorAzulinf And Azul <= valorAzulsup Then 'Comprobamos el color
                            Azul = salidaAzul
                        End If
                        alfa = Niveles(i, j).A
                        bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                    Next
                    porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
                Next
                porcentaje(1) = "Finalizado" 'Actualizamos el estado
                RaiseEvent actualizaBMP(bmp3) 'generamos el evento
                guardarImagen(bmp3, "Filtrado de colores")
                Return bmp3
            End If
        End Function

        ''' <summary>
        ''' Función que permite eliminar el efecto de ojos rojos en una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EliminarOjosRojos(bmp, New Point(300,40),8,1.5)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="CentroOjo">Esta variable indica la coordenada X e Y del centro del ojo (en píxeles).</param>
        ''' <param name="radioOjo">Variable que indica el valor del radio del ojo (en píxeles).</param>
        ''' <param name="valorMinimo">Valor mínimo a partir del cual se aplicará la función. La correción se aplica a los píxeles cuya operación (rojo / ((verde + azul) / 2)) es mayor que esta variable (valorMinimo).</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EliminarOjosRojos(ByVal bmp As Bitmap, ByVal CentroOjo As Point, ByVal radioOjo As Integer, Optional valorMinimo As Double = 1.5) As Bitmap
            Dim bmpCirculo As New Bitmap(bmp)
            Dim bmpCopia As New Bitmap(bmp)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Corrigiendo ojos rojos" 'Actualizar el estado

            Dim gr As Graphics = Graphics.FromImage(bmpCirculo)

            'Le damos un color poco problable para un ojo (amarillo puro) ya que luego evaluaremos el cuadrado circunscrito a la circunferencia
            Dim relleno As Brush = New SolidBrush(Color.FromArgb(255, 255, 255, 0))
            gr.FillEllipse(relleno, CentroOjo.X - radioOjo, CentroOjo.Y - radioOjo, radioOjo * 2, radioOjo * 2)
            Dim bmpPintado As New Bitmap(bmpCirculo) 'Almacenamos una copia de la imagen con la primera línea

            Dim rojo, verde, azul As Integer
            Dim PorcentajeTotal = (CentroOjo.X + (radioOjo + 1)) - (CentroOjo.X - (radioOjo - 1)) + CentroOjo.X - (radioOjo - 1)

            'Recorremos el cuadrado circunscrito a la circunferencia
            For i = CentroOjo.X - (radioOjo - 1) To CentroOjo.X + (radioOjo + 1)
                For j = CentroOjo.Y - (radioOjo - 1) To CentroOjo.Y + (radioOjo + 1)
                    'Si el valor es amarillo (es decir, es el círculo que creamos)
                    If bmpPintado.GetPixel(i, j) = (Color.FromArgb(255, 255, 255, 0)) Then
                        Dim intensidadRojo As Double
                        verde = bmp.GetPixel(i, j).G
                        azul = bmp.GetPixel(i, j).B
                        rojo = bmp.GetPixel(i, j).R
                        intensidadRojo = (rojo / ((verde + azul) / 2))
                        'Hacemos la comprobación de que sea un ojo rojo (el valor más adecuado por norma general es 1.5)
                        If intensidadRojo > valorMinimo Then
                            'Creamos el valor rojo a partir del verde y azul
                            rojo = (verde + azul) / 2
                            bmpCopia.SetPixel(i, j, Color.FromArgb(rojo, verde, azul))
                        End If

                    End If
                Next
                porcentaje(0) = ((i * 100) / PorcentajeTotal) 'Actualizamos el estado
            Next
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmpCopia) 'generamos el evento
            guardarImagen(bmpCopia, "Corregir ojos rojos")
            Return bmpCopia
        End Function

        ''' <summary>
        ''' Función que detecta los contornos de una imagen y devuelve los contornos en color blanco y el resto de la imagen en color negro.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.contornos(bmp, 20,70,50,80)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="contorno">Valor que indica el grado de contorno que se va a detectar. Valores más pequeños detectan más contornos y superiores menos contornos.</param>
        ''' <param name="valorrojo">Peso para la detección del contorno para el canal rojo. Valores mayores detectan más contornos. El valor debe estar comprendido entre 0 y 255.</param>
        ''' <param name="valorverde">Peso para la detección del contorno para el canal verde. Valores mayores detectan más contornos. El valor debe estar comprendido entre 0 y 255.</param>
        ''' <param name="valorazul">Peso para la detección del contorno para el canal azul. Valores mayores detectan más contornos. El valor debe estar comprendido entre 0 y 255.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function contornos(ByVal bmp As Bitmap, ByVal contorno As Integer, ByVal valorrojo As Integer, ByVal valorverde As Integer, ByVal valorazul As Integer)
            Dim bmp2 = bmp
            Dim color1 As Color
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Cargando imagen" 'Actualizar el estado
            Dim almacen(,) As Integer
            ReDim almacen(bmp2.Width, bmp2.Height)
            'para que no se desborde
            For i = 0 To bmp2.Width - 1 'Recorremos la matriz
                For j = 0 To bmp2.Height - 1
                    color1 = bmp2.GetPixel(i, j)
                    almacen(i, j) = (color1.R * valorrojo + color1.G * valorverde + color1.B * valorazul) / 256
                Next
                porcentaje(0) = ((i * 100) / bmp2.Width) 'Actualizamos el estado
            Next
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Detectando contornos" 'Actualizar el estado
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            For i = 1 To bmp3.Width - 1
                For j = 1 To bmp3.Height - 1
                    If Math.Abs(almacen(i, j) - almacen(i, j - 1)) > contorno Or Math.Abs(almacen(i, j) - almacen(i - 1, j)) > contorno Then
                        bmp3.SetPixel(i, j, Color.Black)
                    Else
                        bmp3.SetPixel(i, j, Color.White)
                    End If
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp3, "Contornos") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3

        End Function

        ''' <summary>
        ''' Función que permite cambiar el tamaño de una imagen (bitmap).
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.Redimensionar(bmp, New Rectangle(New Point(0, 0), New Size(500, 500)), Drawing2D.InterpolationMode.Bilinear)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="tamaño">Tamaño al que se quiere transformar la imagen.</param>
        ''' <param name="interpolación">Tipo de interpolación a la hora de modificar el tamaño de la imagen.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Para comparar los diferentes algoritmos de interpolación, acceder a la siguiente web: msdn.microsoft.com/es-es/library/system.drawing.drawing2d.interpolationmode.aspx</remarks>
        Public Function Redimensionar(ByVal bmp As Bitmap, ByVal tamaño As System.Drawing.Rectangle, Optional ByVal interpolación As Drawing2D.InterpolationMode = 0) As Bitmap
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Redimensionando imagen" 'Actualizar el estado
            'Creamos un bitmap nuevo
            Dim bmp2 As New Bitmap(bmp)
            'Creamos un bitmap con el tamaño
            Dim bmp3 As New Bitmap(tamaño.Width, tamaño.Height)
            'Creamos objeto graphics con el bitmap
            Dim G As Graphics = Graphics.FromImage(bmp3)
            porcentaje(0) = 20 'Actualizar el estado
            'Seleccionamos el tipo de interpolación
            G.InterpolationMode = interpolación
            G.DrawImage(bmp2, tamaño, New Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel)
            porcentaje(0) = 70 'Actualizar el estado
            'Devolvemos el resultado
            porcentaje(0) = 100 'Actualizar el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp3, "Redimensionar (" & interpolación.ToString & ")") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

#End Region


        'Contiene las funciones para aplicar máscaras a Bitmaps.
        'Además incluye una subclase con el conjunto de máscaras disponibles (sobel, repujado, etc)
        'Incluye una función (sobelTotal) que aplica la máscara de sobel en 4 direcciones y une las imágenes
#Region "Máscaras"
        ''' <summary>
        ''' Esta función permite aplicar una matriz de convolución (kernel) a la imagen. Recorre toda la imagen mediante una matriz de 3x3, aplicando los diferentes pesos de la matriz a los píxeles de la imagen. La matriz actúa en los 3 canales RGB.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim objetoMascara As New TratamientoImagenes.mascaras 'Se instancia a la clase máscaras (se puede crear también una matriz de 3x3)
        '''Dim mascara = objetoMascara.SobelH 'Se define una máscara Sobel
        '''Picturebox1.image=objetoTratamiento.mascara3x3RGB(bmp, mascara,0, 1)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="matrizMascara">Matriz de 3x3 que define el kernel.</param>
        ''' <param name="desviacion">Variable por la cual el resultado se dividará (este parámetro se suma a la variable factor)</param>
        ''' <param name="factor">Variable por la cual el resultado se dividará (este parámetro se suma a la variable desviación)</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Véase también la clase Tratamiento.mascaras para ver cómo se crean máscaras (kernels) predefinidos.</remarks>
        Public Function mascara3x3RGB(ByVal bmp As Bitmap, ByVal matrizMascara(,) As Double, Optional ByVal desviacion As Double = 0, Optional ByVal factor As Double = 1)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado

            'Creamos el estado*****
            Dim tipoEstado As String = "("
            For Each item In matrizMascara
                tipoEstado = tipoEstado & item & ","
            Next
            tipoEstado = tipoEstado.Remove(tipoEstado.Length - 1) 'Eliminamos la última coma
            tipoEstado = tipoEstado & ")" 'Ponemos el último cierre de paréntesis
            '*****
            porcentaje(1) = "Aplicando máscara 3x3 RGB " & tipoEstado 'Actualizar el estado
            Dim SumaRojo, SumaVerde, SumaAzul, SumaMascara As Long
            Dim Rojo, verde, azul, alfa As Integer

            For mi = -1 To 1
                For mj = -1 To 1
                    SumaMascara = SumaMascara + matrizMascara(mi + 1, mj + 1)
                Next
            Next

            If SumaMascara = 0 Then SumaMascara = 1

            For i = 1 To Niveles.GetUpperBound(0) - 1
                For j = 1 To Niveles.GetUpperBound(1) - 1
                    SumaRojo = 0
                    For mi = -1 To 1
                        For mj = -1 To 1

                            SumaRojo = SumaRojo + Niveles(i + mi, j + mj).R * matrizMascara(mi + 1, mj + 1)
                        Next
                    Next

                    SumaVerde = 0
                    For mi = -1 To 1
                        For mj = -1 To 1
                            SumaVerde = SumaVerde + Niveles(i + mi, j + mj).G * matrizMascara(mi + 1, mj + 1)

                        Next
                    Next

                    SumaAzul = 0
                    For mi = -1 To 1
                        For mj = -1 To 1
                            SumaAzul = SumaAzul + Niveles(i + mi, j + mj).B * matrizMascara(mi + 1, mj + 1)
                        Next
                    Next

                    If factor + desviacion = 0 Then factor = 1 : desviacion = 0
                    Rojo = Math.Abs((SumaRojo / SumaMascara) / (factor + desviacion))
                    verde = Math.Abs((SumaVerde / SumaMascara) / (factor + desviacion))
                    azul = Math.Abs((SumaAzul / SumaMascara) / (factor + desviacion))
                    If Rojo > 255 Then Rojo = 255
                    If verde > 255 Then verde = 255
                    If azul > 255 Then azul = 255
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, verde, azul))
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Máscara 3x3 RGB " & tipoEstado)
            Return bmp3
        End Function

        ''' <summary>
        ''' Esta función permite aplicar una matriz de convolución (kernel) a la imagen. Recorre toda la imagen mediante una matriz de 3x3, aplicando los diferentes pesos de la matriz a los píxeles de la imagen. La matriz actúa en escala de grises.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim objetoMascara As New TratamientoImagenes.mascaras 'Se instancia a la clase máscaras (se puede crear también una matriz de 3x3)
        '''Dim mascara = objetoMascara.SobelH 'Se define una máscara Sobel
        '''Picturebox1.image=objetoTratamiento.mascara3x3RGB(bmp, mascara,0, 1)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="matrizMascara">Matriz de 3x3 que define el kernel.</param>
        ''' <param name="desviacion">Variable por la cual el resultado se dividará (este parámetro se suma a la variable factor)</param>
        ''' <param name="factor">Variable por la cual el resultado se dividará (este parámetro se suma a la variable desviación)</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Véase también la clase Tratamiento.mascaras para ver cómo se crean máscaras (kernels) predefinidos.</remarks>
        Public Function mascara3x3Grises(ByVal bmp As Bitmap, ByVal matrizMascara(,) As Double, Optional ByVal desviacion As Double = 0, Optional ByVal factor As Double = 1)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado

            'Creamos el estado*****
            Dim tipoEstado As String = "("
            For Each item In matrizMascara
                tipoEstado = tipoEstado & item & ","
            Next
            tipoEstado = tipoEstado.Remove(tipoEstado.Length - 1) 'Eliminamos la última coma
            tipoEstado = tipoEstado & ")" 'Ponemos el último cierre de paréntesis
            '*****
            porcentaje(1) = "Aplicando máscara 3x3 Gris " & tipoEstado 'Actualizar el estado
            Dim SumaRojo, SumaVerde, SumaAzul, SumaMascara As Long
            Dim Rojo, verde, azul, alfa, grises As Integer

            For mi = -1 To 1
                For mj = -1 To 1
                    SumaMascara = SumaMascara + matrizMascara(mi + 1, mj + 1)
                Next
            Next

            If SumaMascara = 0 Then SumaMascara = 1

            For i = 1 To Niveles.GetUpperBound(0) - 1
                For j = 1 To Niveles.GetUpperBound(1) - 1
                    SumaRojo = 0
                    For mi = -1 To 1
                        For mj = -1 To 1
                            SumaRojo = SumaRojo + Niveles(i + mi, j + mj).R * matrizMascara(mi + 1, mj + 1)
                        Next
                    Next

                    SumaVerde = 0
                    For mi = -1 To 1
                        For mj = -1 To 1
                            SumaVerde = SumaVerde + Niveles(i + mi, j + mj).G * matrizMascara(mi + 1, mj + 1)

                        Next
                    Next

                    SumaAzul = 0
                    For mi = -1 To 1
                        For mj = -1 To 1
                            SumaAzul = SumaAzul + Niveles(i + mi, j + mj).B * matrizMascara(mi + 1, mj + 1)
                        Next
                    Next

                    If factor + desviacion = 0 Then factor = 1 : desviacion = 0
                    Rojo = Math.Abs((SumaRojo / SumaMascara) / (factor + desviacion))
                    verde = Math.Abs((SumaVerde / SumaMascara) / (factor + desviacion))
                    azul = Math.Abs((SumaAzul / SumaMascara) / (factor + desviacion))
                    If Rojo > 255 Then Rojo = 255
                    If verde > 255 Then verde = 255
                    If azul > 255 Then azul = 255
                    grises = CInt(Rojo + azul + verde) / 3
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, grises, grises, grises))
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next

            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Máscara 3x3 Gris " & tipoEstado)
            Return bmp3
        End Function

        ''' <summary>
        ''' Esta función permite aplicar una matriz de convolución (kernel) a la imagen. Recorre toda la imagen mediante una matriz de tamaño determinado, aplicando los diferentes pesos de la matriz a los píxeles de la imagen. La matriz actúa en los 3 canales RGB.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim objetoMascara As New TratamientoImagenes.mascaras 'Se instancia a la clase máscaras (se puede crear también una matriz de 3x3)
        '''Dim mascara = objetoMascara.SobelH 'Se define una máscara Sobel
        '''Picturebox1.image=objetoTratamiento.mascara3x3RGB(bmp, mascara,0, 1)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="matrizMascara">Matriz del tamaño que se quiera siempre y cuando sea cuadrada e impar (5x5, 7x7...). Dicha matriz será quien defina el kernel.</param>
        ''' <param name="desviacion">Variable por la cual el resultado se dividará (este parámetro se suma a la variable factor)</param>
        ''' <param name="factor">Variable por la cual el resultado se dividará (este parámetro se suma a la variable desviación)</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Véase también la clase Tratamiento.mascaras para ver cómo se crean máscaras (kernels) predefinidos.</remarks>
        Public Function mascaraManualRGB(ByVal bmp As Bitmap, ByVal matrizMascara(,) As Double, Optional ByVal desviacion As Double = 0, Optional ByVal factor As Double = 1)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado

            'Creamos el estado*****
            Dim tipoEstado As String = "(" & matrizMascara.GetUpperBound(0) + 1 & "x" & matrizMascara.GetUpperBound(0) + 1 & ")"
             
            tipoEstado = tipoEstado.Remove(tipoEstado.Length - 1) 'Eliminamos la última coma
            tipoEstado = tipoEstado & ")" 'Ponemos el último cierre de paréntesis
            '*****
            porcentaje(1) = "Aplicando máscara personalizada " & tipoEstado 'Actualizar el estado
            Dim SumaRojo, SumaVerde, SumaAzul, SumaMascara As Long
            Dim Rojo, verde, azul, alfa As Integer

            For mi = -(matrizMascara.GetUpperBound(0) / 2) To matrizMascara.GetUpperBound(0) / 2
                For mj = -(matrizMascara.GetUpperBound(0) / 2) To matrizMascara.GetUpperBound(0) / 2
                    SumaMascara = SumaMascara + matrizMascara(mi + matrizMascara.GetUpperBound(0) / 2, mj + matrizMascara.GetUpperBound(0) / 2)
                Next
            Next

            If SumaMascara = 0 Then SumaMascara = 1

            For i = (matrizMascara.GetUpperBound(0) / 2) To Niveles.GetUpperBound(0) - (matrizMascara.GetUpperBound(0) / 2)
                For j = (matrizMascara.GetUpperBound(0) / 2) To Niveles.GetUpperBound(1) - (matrizMascara.GetUpperBound(0) / 2)
                    SumaRojo = 0
                    For mi = -(matrizMascara.GetUpperBound(0) / 2) To (matrizMascara.GetUpperBound(0) / 2)
                        For mj = -(matrizMascara.GetUpperBound(0) / 2) To (matrizMascara.GetUpperBound(0) / 2)

                            SumaRojo = SumaRojo + Niveles(i + mi, j + mj).R * matrizMascara(mi + (matrizMascara.GetUpperBound(0) / 2), mj + (matrizMascara.GetUpperBound(0) / 2))
                        Next
                    Next

                    SumaVerde = 0
                    For mi = -(matrizMascara.GetUpperBound(0) / 2) To (matrizMascara.GetUpperBound(0) / 2)
                        For mj = -(matrizMascara.GetUpperBound(0) / 2) To (matrizMascara.GetUpperBound(0) / 2)
                            SumaVerde = SumaVerde + Niveles(i + mi, j + mj).G * matrizMascara(mi + (matrizMascara.GetUpperBound(0) / 2), mj + (matrizMascara.GetUpperBound(0) / 2))

                        Next
                    Next

                    SumaAzul = 0
                    For mi = -(matrizMascara.GetUpperBound(0) / 2) To (matrizMascara.GetUpperBound(0) / 2)
                        For mj = -(matrizMascara.GetUpperBound(0) / 2) To (matrizMascara.GetUpperBound(0) / 2)
                            SumaAzul = SumaAzul + Niveles(i + mi, j + mj).B * matrizMascara(mi + (matrizMascara.GetUpperBound(0) / 2), mj + (matrizMascara.GetUpperBound(0) / 2))
                        Next
                    Next

                    If factor + desviacion = 0 Then factor = 1 : desviacion = 0
                    Rojo = Math.Abs((SumaRojo / SumaMascara) / (factor + desviacion))
                    verde = Math.Abs((SumaVerde / SumaMascara) / (factor + desviacion))
                    azul = Math.Abs((SumaAzul / SumaMascara) / (factor + desviacion))
                    If Rojo > 255 Then Rojo = 255
                    If verde > 255 Then verde = 255
                    If azul > 255 Then azul = 255
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, verde, azul))
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(0) = 100
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Máscara personalizada " & tipoEstado)
            Return bmp3
        End Function

#Region "Subclase con conjunto de máscaras"
        ''' <summary>
        ''' La clase Tratamiento.Mascaras, permite obtener diferentes matrices de 3x3 predefinidas (kernels) para después aplicar máscaras a imágenes. El proceso
        ''' de obtención de máscaras es muy sencillo. A continuación se muestra cómo realizarlo.
        ''' <example><para>Para instancia un objeto de la clase Tratamiento.Mascaras, primeramente debe hacer referencia a la clase en su proyecto:</para>
        ''' <code>Imports nombredeaplicacion.Tratamiento.Mascaras</code>
        ''' <para>A continuación se instancia a la clase y ya se puede obtener una máscara de 3x3 predefinida (este proceso es asistido, si utiliza Visual Studio, por IntelliSense):
        ''' <code>Dim objetoMascara as new Tratamiento.Mascaras 
        '''Dim mascara=objetoMascara.SobelH</code></para></example>
        ''' </summary>
        ''' <remarks>Clase creada por Luis Marcos Rivera.</remarks>
        Public Class Mascaras
            Private coefmascara(2, 2) As Double
#Region "Paso bajo"
            ''' <summary>
            ''' Función que devuelve una máscara de paso bajo con coeficiente 9.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.LOW9</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function LOW9()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara de paso bajo con coeficiente 10.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.LOW10</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function LOW10()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1

                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara de paso bajo con coeficiente 12.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.LOW12</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function LOW12()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = 4 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
#End Region 'Máscaras de paso bajo
#Region "Paso alto"
            ''' <summary>
            ''' Función que devuelve una máscara de paso alto con coeficiente 1.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.HIGH1a</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function HIGH1a()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 9 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara de paso alto con coeficiente 1.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.HIGH1b</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function HIGH1b()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 5 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara de paso alto con coeficiente 16.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.HIGH16</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function HIGH16()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 20 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function
#End Region 'Máscaras de paso alto
#Region "Bordes y contornos"
            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (resta-movimiento).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Resta1</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Resta1()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (resta-movimiento).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Resta2</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Resta2()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (resta-movimiento).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Resta3</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Resta3()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (operador Laplaciano).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Laplaciana1</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Laplaciana1()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = -4 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (operador Laplaciano).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Laplaciana2</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Laplaciana2()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 4 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (operador Laplaciano).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Laplaciana3</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Laplaciana3()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 8 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (operador Laplaciano).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Laplaciana4</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Laplaciana4()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = -2 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = -2 : coefmascara(1, 1) = 4 : coefmascara(1, 2) = -2
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = -2 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (operador Laplaciano).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.LaplacianaDiagonal</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function LaplacianaDiagonal()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 4 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (operador Laplaciano).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.LaplacianaHorizont</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function LaplacianaHorizont()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (operador Laplaciano).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.LaplacianaVertical</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function LaplacianaVertical()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (calcula el gradiente dirección Este).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.GradienteEste</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function GradienteEste()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (calcula el gradiente dirección Sudeste).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.GradienteSedeste</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function GradienteSudeste()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (calcula el gradiente dirección Sur).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.GradienteSur</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function GradienteSur()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (calcula el gradiente dirección Oeste).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.GradienteOeste</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function GradienteOeste()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (calcula el gradiente dirección Noreste).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.GradienteNoreste</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function GradienteNoreste()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (calcula el gradiente dirección Norte).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.GradienteNorte</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function GradienteNorte()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara que imita el efecto embossing (relieve), orientación Este.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.EmbossingEste</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function EmbossingEste()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara que imita el efecto embossing (relieve), orientación Sudeste.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.EmbossingSudeste</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function EmbossingSudeste()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara que imita el efecto embossing (relieve), orientación Sur.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.EmbossingSur</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function EmbossingSur()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara que imita el efecto embossing (relieve), orientación Oeste.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.EmbossingOeste</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function EmbossingOeste()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara que imita el efecto embossing (relieve), orientación Noreste.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.EmbossingNoreste</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function EmbossingNoreste()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara que imita el efecto embossing (relieve), orientación Norte.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.EmbossingNorte</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function EmbossingNorte()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (vertical). Para resultados óptimos, es conveniente aplicar desviación 0 y factor 4.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.SobelV</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function SobelV()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 2 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -2 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (horizontal). Para resultados óptimos, es conveniente aplicar desviación 0 y factor 4.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.SobelH</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function SobelH()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 2 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -2
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (diagonal). Para resultados óptimos, es conveniente aplicar desviación 0 y factor 4.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.SobelDiagonal1</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function SobelDiagonal1()
                coefmascara(0, 0) = -2 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 2
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (diagonal). Para resultados óptimos, es conveniente aplicar desviación 0 y factor 4.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.SobelDiagonal2</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function SobelDiagonal2()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 2
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = -2 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function


            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (vertical). Para resultados óptimos, es conveniente aplicar desviación 0 y factor 3.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.PrewittVert</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function PrewittVert()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (horizontal). Para resultados óptimos, es conveniente aplicar desviación 0 y factor 3.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.PrewittHoriz</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function PrewittHoriz()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (diagonal). Para resultados óptimos, es conveniente aplicar desviación 0 y factor 3.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.PrewittDiag1</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function PrewittDiag1()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (diagonal). Para resultados óptimos, es conveniente aplicar desviación 0 y factor 3.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.PrewittDiag2</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function PrewittDiag2()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar líneas verticales.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.LineasVerticales</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function LineasVerticales()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 2 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = 2
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar líneas horizontales.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.LineasHorizontales</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function LineasHorizontales()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = 2 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = 2 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para imitar un efecto de repujado.
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Repujado</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Repujado()
                coefmascara(0, 0) = -2 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 2
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (orientación 0º).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Kirsch0</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Kirsch0()
                coefmascara(0, 0) = -3 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = 5
                coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 5
                coefmascara(2, 0) = -3 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = 5
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (orientación 45º).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Kirsch45</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Kirsch45()
                coefmascara(0, 0) = -3 : coefmascara(0, 1) = 5 : coefmascara(0, 2) = 5
                coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 5
                coefmascara(2, 0) = -3 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = -3
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (orientación 90º).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Kirsch90</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Kirsch90()
                coefmascara(0, 0) = 5 : coefmascara(0, 1) = 5 : coefmascara(0, 2) = 5
                coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                coefmascara(2, 0) = -3 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = -3
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (orientación 135º).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Kirsch135</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Kirsch135()
                coefmascara(0, 0) = 5 : coefmascara(0, 1) = 5 : coefmascara(0, 2) = 5
                coefmascara(1, 0) = 5 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                coefmascara(2, 0) = -3 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = -3
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (orientación 180º).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Kirsch180</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Kirsch180()
                coefmascara(0, 0) = 5 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = -3
                coefmascara(1, 0) = 5 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                coefmascara(2, 0) = 5 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = -3
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (orientación 225º).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Kirsch225</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Kirsch225()
                coefmascara(0, 0) = -3 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = -3
                coefmascara(1, 0) = 5 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                coefmascara(2, 0) = 5 : coefmascara(2, 1) = 5 : coefmascara(2, 2) = -3
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (orientación 270º).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Kirsch270</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Kirsch270()
                coefmascara(0, 0) = -3 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = -3
                coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                coefmascara(2, 0) = 5 : coefmascara(2, 1) = 5 : coefmascara(2, 2) = 5
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (orientación 315º).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.Kirsch315</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Kirsch315()
                coefmascara(0, 0) = -3 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = -3
                coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 5
                coefmascara(2, 0) = -3 : coefmascara(2, 1) = 5 : coefmascara(2, 2) = 5
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (horizontal). Para resultados óptimos, es conveniente aplicar desviación 0 y factor (1 / (2 + Math.Sqrt(2))).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.FreichenHori</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function FreichenHori()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = Math.Sqrt(2) : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -Math.Sqrt(2)
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function

            ''' <summary>
            ''' Función que devuelve una máscara para detectar bordes (vertical). Para resultados óptimos, es conveniente aplicar desviación 0 y factor (1 / (2 + Math.Sqrt(2))).
            ''' <example>Para obtener esta máscara, se debe proceder así:
            ''' <code>Dim mascara=objetoMascara.FreichenVert</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function FreichenVert()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -Math.Sqrt(2) : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = Math.Sqrt(2) : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
#End Region 'Máscaras para detectar bordes y contornos

        End Class

#End Region 'Contiene todas las máscaras disponibles

        'Funciones para crear Sobel total
        ''' <summary>
        ''' Función que aplica el operador Sobel (kernel) sobre la imagen. Este operador se aplica en vertical, horizontal y ambas diagonales y por último une las imágenes.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.sobelTotal(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>La función puede demorarse varios segundos.</remarks>
        Public Function sobelTotal(ByVal bmp As Bitmap)
            Dim bmp2 = bmp
            Dim bmp3 = bmp
            Dim bmp4 = bmp
            Dim bmp5 = bmp

            Dim objetoMascaras As New Mascaras
            Dim MatrizMascara(2, 2) As Double

            'Sobel horizontal
            MatrizMascara = objetoMascaras.SobelH
            bmp2 = mascara3x3Grises(bmp2, MatrizMascara, 0, 4)
            'Sobel vertical
            MatrizMascara = objetoMascaras.SobelV
            bmp3 = mascara3x3Grises(bmp3, MatrizMascara, 0, 4)
            'Sobel diagonal 1
            MatrizMascara = objetoMascaras.SobelDiagonal1
            bmp4 = mascara3x3Grises(bmp4, MatrizMascara, 0, 4)
            'Sobel diagonal 2
            MatrizMascara = objetoMascaras.SobelDiagonal2
            bmp5 = mascara3x3Grises(bmp5, MatrizMascara, 0, 4)

            Dim bmpTotal As New ArrayList
            bmpTotal.Add(bmp2)
            bmpTotal.Add(bmp3)
            bmpTotal.Add(bmp4)
            bmpTotal.Add(bmp5)

            Return Me.Unir4(bmpTotal)

        End Function

        ''' <summary>
        ''' Función que une cuatro imágenes que se le pasen como arraylist de bitmaps.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Bitmap sería así:
        ''' <code>Dim bmpUnido as bitmap=objetoTratamiento.sobelTotal(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Variable arraylist que debe contener cuatro bitmaps.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Private Function Unir4(ByVal bmp As ArrayList)
            Dim bmp2 As New ArrayList(bmp)

            'Almacenará los niveles digitales de la imagen
            Dim Niveles1(,) As System.Drawing.Color
            Dim Niveles2(,) As System.Drawing.Color
            Dim Niveles3(,) As System.Drawing.Color
            Dim Niveles4(,) As System.Drawing.Color

            Niveles1 = nivel((bmp2(0))) 'Obtenemos valores
            Niveles2 = nivel((bmp2(1)))
            Niveles3 = nivel((bmp2(2)))
            Niveles4 = nivel((bmp2(3)))

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Uniendo imágenes" 'Actualizar el estado
            Dim bmp3 As Bitmap
            bmp3 = bmp(0)

            Dim media1, media2, media3, media4 As Double 'Variable para calcular la media
            Dim rojoaux1, verdeaux1, azulaux1, rojoaux2, verdeaux2, azulaux2, rojoaux3, verdeaux3, azulaux3, rojoaux4, verdeaux4, azulaux4 As Double 'Variables auxiliares

            For i = 0 To Niveles1.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles1.GetUpperBound(1)

                    'Calculamos la media
                    rojoaux1 = Niveles1(i, j).R
                    verdeaux1 = Niveles1(i, j).G
                    azulaux1 = Niveles1(i, j).B
                    media1 = CInt((rojoaux1 + verdeaux1 + azulaux1) / 3) 'Hacemos la media

                    rojoaux2 = Niveles2(i, j).R
                    verdeaux2 = Niveles2(i, j).G
                    azulaux2 = Niveles2(i, j).B
                    media2 = CInt((rojoaux2 + verdeaux2 + azulaux2) / 3) 'Hacemos la media

                    rojoaux3 = Niveles3(i, j).R
                    verdeaux3 = Niveles3(i, j).G
                    azulaux3 = Niveles3(i, j).B
                    media3 = CInt((rojoaux3 + verdeaux3 + azulaux3) / 3) 'Hacemos la media

                    rojoaux4 = Niveles4(i, j).R
                    verdeaux4 = Niveles4(i, j).G
                    azulaux4 = Niveles4(i, j).B
                    media4 = CInt((rojoaux4 + verdeaux4 + azulaux4) / 3) 'Hacemos la media

                    Dim mediaTo = CInt((media1 + media2 + media3 + media4) / 4)
                    bmp3.SetPixel(i, j, Color.FromArgb(255, mediaTo, mediaTo, mediaTo))

                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            guardarImagen(bmp3, "Sobel total") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function
#End Region


        'Funciones para realizar suma/resta/multiplicación/división sobre píxeles de una imagen
#Region "Operaciones aritméticas"
        ''' <summary>
        ''' Función que suma valores a los píxeles de la imagen. Se aumentan los valores en los 4 canales ARGB.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.Suma(bmp, 20,20,20,0,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="Sumarojo">Variable que indica que valor que se va a aumentar en el canal rojo.</param>
        ''' <param name="Sumaverde">Variable que indica que valor que se va a aumentar en el canal verde.</param>
        ''' <param name="Sumaazul">Variable que indica que valor que se va a aumentar en el canal azul.</param>
        ''' <param name="sumaAlfa">Variable que indica que valor que se va a aumentar en el canal alfa.</param>
        ''' <param name="omitirAlfa">Si la variable es TRUE, no se aumentará el canal alfa. En caso de ser FALSE, se aumentará en función del valor incluido en la variable sumaAlfa.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function Suma(ByVal bmp As Bitmap, ByVal Sumarojo As Integer, ByVal Sumaverde As Integer, ByVal Sumaazul As Integer, ByVal sumaAlfa As Integer, Optional ByVal omitirAlfa As Boolean = True) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Operación aritmética. Suma" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux, Alfaaux As Double 'Declaramos tres variables que almacenarán los colores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R + Sumarojo 'Aumentamos/  por canal
                    Verdeuax = Niveles(i, j).G + Sumaverde
                    Azulaux = Niveles(i, j).B + Sumaazul
                    Alfaaux = Niveles(i, j).A + sumaAlfa
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeuax > 255 Then Verdeuax = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If Alfaaux > 255 Then Alfaaux = 255
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux : alfa = Alfaaux
                    If omitirAlfa = True Then
                        alfa = Niveles(i, j).A
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            guardarImagen(bmp3, "Operación aritmética. Suma") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que resta valores a los píxeles de la imagen. Se resta los valores en los 4 canales ARGB.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.Resta(bmp, 20,20,20,0,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="Restarojo">Variable que indica que valor que se va a disminuir en el canal rojo.</param>
        ''' <param name="Restaverde">Variable que indica que valor que se va a disminuir en el canal verde.</param>
        ''' <param name="Restaazul">Variable que indica que valor que se va a disminuir en el canal azul.</param>
        ''' <param name="RestaAlfa">Variable que indica que valor que se va a disminuir en el canal alfa.</param>
        ''' <param name="omitirAlfa">Si la variable es TRUE, no se disminuirá el canal alfa. En caso de ser FALSE, se disminuirá en función del valor incluido en la variable RestaAlfa.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Las variables Restarojo, Restaverde, Restazul y RestaAlfa deben ser positivas para que la función reste los valores.</remarks>
        Public Function Resta(ByVal bmp As Bitmap, ByVal Restarojo As Integer, ByVal Restaverde As Integer, ByVal Restaazul As Integer, ByVal RestaAlfa As Integer, Optional ByVal omitirAlfa As Boolean = True) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Operación aritmética. Resta" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux, Alfaaux As Double 'Declaramos tres variables que almacenarán los colores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R - Restarojo ' /disminuimos por canal
                    Verdeuax = Niveles(i, j).G - Restaverde
                    Azulaux = Niveles(i, j).B - Restaazul
                    Alfaaux = Niveles(i, j).A - RestaAlfa
                    If Rojoaux < 0 Then Rojoaux = 0
                    If Verdeuax < 0 Then Verdeuax = 0
                    If Azulaux < 0 Then Azulaux = 0
                    If Alfaaux < 0 Then Alfaaux = 0
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux : alfa = Alfaaux
                    If omitirAlfa = True Then
                        alfa = Niveles(i, j).A
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            guardarImagen(bmp3, "Operación aritmética. Resta") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que multiplica valores a los píxeles de la imagen. Se multiplica los valores en los 4 canales ARGB.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.Multiplicacion(bmp, 1.5,1,1,0,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="Multiplicacionrojo">Variable que indica el valor por el cual se multiplicarán los píxeles del canal rojo.</param>
        ''' <param name="Multiplicacionverde">Variable que indica el valor por el cual se multiplicarán los píxeles del canal verde.</param>
        ''' <param name="Multiplicacionazul">Variable que indica el valor por el cual se multiplicarán los píxeles del canal azul.</param>
        ''' <param name="MultiplicacionAlfa">Variable que indica el valor por el cual se multiplicarán los píxeles del canal alfa.</param>
        ''' <param name="omitirAlfa">Si la variable es TRUE, no se multiplicará el canal alfa. En caso de ser FALSE, se multiplicará en función del valor incluido en la variable MultiplicacionAlfa.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function Multiplicacion(ByVal bmp As Bitmap, ByVal Multiplicacionrojo As Double, ByVal Multiplicacionverde As Double, ByVal Multiplicacionazul As Double, ByVal MultiplicacionAlfa As Double, Optional ByVal omitirAlfa As Boolean = True) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Operación aritmética. Multiplicación" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux, Alfaaux As Double 'Declaramos tres variables que almacenarán los colores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R * Multiplicacionrojo 'Multiplicamos canal
                    Verdeuax = Niveles(i, j).G * Multiplicacionverde
                    Azulaux = Niveles(i, j).B * Multiplicacionazul
                    Alfaaux = Niveles(i, j).A * MultiplicacionAlfa
                    If Rojoaux < 0 Then Rojoaux = 0
                    If Verdeuax < 0 Then Verdeuax = 0
                    If Azulaux < 0 Then Azulaux = 0
                    If Alfaaux < 0 Then Alfaaux = 0
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeuax > 255 Then Verdeuax = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If Alfaaux > 255 Then Alfaaux = 255
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux : alfa = Alfaaux
                    If omitirAlfa = True Then
                        alfa = Niveles(i, j).A
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            guardarImagen(bmp3, "Operación aritmética. Multiplicación") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que divide valores a los píxeles de la imagen. Se dividen los valores en los 4 canales ARGB.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.Division(bmp, 1.5,1,1,0,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="Divisionrojo">Variable que indica el valor por el cual se dividirán los píxeles del canal rojo.</param>
        ''' <param name="Divisionverde">Variable que indica el valor por el cual se dividirán los píxeles del canal verde.</param>
        ''' <param name="Divisionazul">Variable que indica el valor por el cual se dividirán los píxeles del canal azul.</param>
        ''' <param name="DivisionAlfa">Variable que indica el valor por el cual se dividirán los píxeles del canal alfa.</param>
        ''' <param name="omitirAlfa">Si la variable es TRUE, no se dividirá el canal alfa. En caso de ser FALSE, se dividirá en función del valor incluido en la variable MultiplicacionAlfa.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>El valor cero en las variables Divisionrojo, Divisionverde, Divisionazul, DivisionAlfa produciría un error.</remarks>
        Public Function Division(ByVal bmp As Bitmap, ByVal Divisionrojo As Double, ByVal Divisionverde As Double, ByVal Divisionazul As Double, ByVal DivisionAlfa As Double, Optional ByVal omitirAlfa As Boolean = True) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Operación aritmética. División" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux, Alfaaux As Double 'Declaramos tres variables que almacenarán los colores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R / Divisionrojo 'Dividimos canal
                    Verdeuax = Niveles(i, j).G / Divisionverde
                    Azulaux = Niveles(i, j).B / Divisionazul
                    Alfaaux = Niveles(i, j).A / DivisionAlfa
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeuax > 255 Then Verdeuax = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If Alfaaux > 255 Then Alfaaux = 255
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux : alfa = Alfaaux
                    If omitirAlfa = True Then
                        alfa = Niveles(i, j).A
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            guardarImagen(bmp3, "Operación aritmética. División") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function
#End Region

        'Funciones para realizar and/or/xor sobre píxeles de una imagen
#Region "Operaciones lógicas"
        ''' <summary>
        ''' Función que realiza la operación AND a los valores de los píxeles de la imagen. Se opera en los valores en los 4 canales ARGB.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.OperAND(bmp, 1,1,0,0,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="Arojo">Variable que indica el valor por el cual se operará (con el operador AND) los píxeles del canal rojo.</param>
        ''' <param name="Averde">Variable que indica el valor por el cual se operará (con el operador AND) los píxeles del canal verde.</param>
        ''' <param name="Aazul">Variable que indica el valor por el cual se operará (con el operador AND) los píxeles del canal azul.</param>
        ''' <param name="AAlfa">Variable que indica el valor por el cual se operará (con el operador AND) los píxeles del canal alfa.</param>
        ''' <param name="omitirAlfa">Si la variable es TRUE, no se operará en el canal alfa. En caso de ser FALSE, se hará en AND en función del valor incluido en la variable AAlfa.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Las operaciones lógicas tiene más sentido realizarlas en imágenes binarias.</remarks>
        Public Function OperAND(ByVal bmp As Bitmap, ByVal Arojo As Integer, ByVal Averde As Integer, ByVal Aazul As Integer, ByVal AAlfa As Integer, Optional ByVal omitirAlfa As Boolean = True) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Operación lógica. AND" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux, Alfaaux As Double 'Declaramos tres variables que almacenarán los colores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R And Arojo 'Aumentamos/  por canal
                    Verdeuax = Niveles(i, j).G And Averde
                    Azulaux = Niveles(i, j).B And Aazul
                    Alfaaux = Niveles(i, j).A And AAlfa
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeuax > 255 Then Verdeuax = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If Alfaaux > 255 Then Alfaaux = 255
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux : alfa = Alfaaux
                    If omitirAlfa = True Then
                        alfa = Niveles(i, j).A
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            guardarImagen(bmp3, "Operación lógica. AND") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que realiza la operación OR a los valores de los píxeles de la imagen. Se opera en los valores en los 4 canales ARGB.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.OperOR(bmp, 1,1,0,0,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="Orojo">Variable que indica el valor por el cual se operará (con el operador OR) los píxeles del canal rojo.</param>
        ''' <param name="Overde">Variable que indica el valor por el cual se operará (con el operador OR) los píxeles del canal verde.</param>
        ''' <param name="Oazul">Variable que indica el valor por el cual se operará (con el operador OR) los píxeles del canal azul.</param>
        ''' <param name="OAlfa">Variable que indica el valor por el cual se operará (con el operador OR) los píxeles del canal alfa.</param>
        ''' <param name="omitirAlfa">Si la variable es TRUE, no se operará en el canal alfa. En caso de ser FALSE, se hará en OR en función del valor incluido en la variable OAlfa.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Las operaciones lógicas tiene más sentido realizarlas en imágenes binarias.</remarks>
        Public Function OperOR(ByVal bmp As Bitmap, ByVal Orojo As Integer, ByVal Overde As Integer, ByVal Oazul As Integer, ByVal OAlfa As Integer, Optional ByVal omitirAlfa As Boolean = True) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Operación lógica. OR" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux, Alfaaux As Double 'Declaramos tres variables que almacenarán los colores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R Or Orojo 'Aumentamos/  por canal
                    Verdeuax = Niveles(i, j).G Or Overde
                    Azulaux = Niveles(i, j).B Or Oazul
                    Alfaaux = Niveles(i, j).A Or OAlfa
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeuax > 255 Then Verdeuax = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If Alfaaux > 255 Then Alfaaux = 255
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux : alfa = Alfaaux
                    If omitirAlfa = True Then
                        alfa = Niveles(i, j).A
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            guardarImagen(bmp3, "Operación lógica. OR") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que realiza la operación XOR a los valores de los píxeles de la imagen. Se opera en los valores en los 4 canales ARGB.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.OperXOR(bmp, 255,255,255,0,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="Xrojo">Variable que indica el valor por el cual se operará (con el operador XOR) los píxeles del canal rojo.</param>
        ''' <param name="Xverde">Variable que indica el valor por el cual se operará (con el operador XOR) los píxeles del canal verde.</param>
        ''' <param name="Xazul">Variable que indica el valor por el cual se operará (con el operador XOR) los píxeles del canal azul.</param>
        ''' <param name="XAlfa">Variable que indica el valor por el cual se operará (con el operador XOR) los píxeles del canal alfa.</param>
        ''' <param name="omitirAlfa">Si la variable es TRUE, no se operará en el canal alfa. En caso de ser FALSE, se hará en XOR en función del valor incluido en la variable XAlfa.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Las operaciones lógicas tiene más sentido realizarlas en imágenes binarias.</remarks>
        Public Function OperXOR(ByVal bmp As Bitmap, ByVal Xrojo As Integer, ByVal Xverde As Integer, ByVal Xazul As Integer, ByVal XAlfa As Integer, Optional ByVal omitirAlfa As Boolean = True) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Operación lógica. XOR" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux, Alfaaux As Double 'Declaramos tres variables que almacenarán los colores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R Xor Xrojo 'Aumentamos/  por canal
                    Verdeuax = Niveles(i, j).G Xor Xverde
                    Azulaux = Niveles(i, j).B Xor Xazul
                    Alfaaux = Niveles(i, j).A Xor XAlfa
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeuax > 255 Then Verdeuax = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If Alfaaux > 255 Then Alfaaux = 255
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux : alfa = Alfaaux
                    If omitirAlfa = True Then
                        alfa = Niveles(i, j).A
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            guardarImagen(bmp3, "Operación lógica. XOR") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function
#End Region

        'Funciones morfológicas sobre píxeles de una imagen. Erosión, dilatación, bottom hat, top hatt, cerradura, apertura, diámetro
#Region "Operaciones morfológicas"
        ''' <summary>
        ''' Función que calcula el operador morfológico de dilatación de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim objetoEstructura As New TratamientoImagenes.ElementoEstructural 'Se instancia a la clase ElementoEstructural (se puede crear también una matrices personalizadas)
        '''Dim estructura = objetoEstructura.Cuadrado3x3 'Se define una cuadrada de 3x3
        '''Picturebox1.image=objetoTratamiento.MorfologicasDilatacion(bmp, estructura)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="ElementoEstructural">Matriz (impar, por ejemplo 3x3, 5x5...) de dos dimensiones que debe contener exclusivamente 0 y/o 1. </param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Véase también la clase Tratamiento.ElementoEstructural para ver cómo se crean elementos estructurales predefinidos.</remarks>
        Public Function MorfologicasDilatacion(ByVal bmp As Bitmap, ByVal ElementoEstructural(,) As Integer)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim tamañoMascara = ElementoEstructural.GetUpperBound(0) \ 2 'División entera

            'Dim bmp3 As New Bitmap(bmp2.Width - tamañoMascara, bmp2.Height - tamañoMascara) 'Redmiensionamos menos el tamaño de la máscara
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height) 'Redmiensionamos  
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Aplicando operador morfológico. Dilatación" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte

            For i = tamañoMascara To Niveles.GetUpperBound(0) - tamañoMascara
                For j = tamañoMascara To Niveles.GetUpperBound(1) - tamañoMascara
                    Rojo = 0
                    For mi = -tamañoMascara To tamañoMascara
                        For mj = -tamañoMascara To tamañoMascara
                            If Rojo < ElementoEstructural(mi + tamañoMascara, mj + tamañoMascara) * Niveles(i + mi, j + mj).R Then 'Buscamos el valor más alto dentro de la unidad estrucutural (máscara)
                                Rojo = Niveles(i + mi, j + mj).R
                            End If
                        Next
                    Next

                    Verde = 0
                    For mi = -tamañoMascara To tamañoMascara
                        For mj = -tamañoMascara To tamañoMascara
                            If Verde < ElementoEstructural(mi + tamañoMascara, mj + tamañoMascara) * Niveles(i + mi, j + mj).G Then 'Buscamos el valor más alto dentro de la unidad estrucutural (máscara)
                                Verde = Niveles(i + mi, j + mj).G
                            End If
                        Next
                    Next

                    Azul = 0
                    For mi = -tamañoMascara To tamañoMascara
                        For mj = -tamañoMascara To tamañoMascara
                            If Azul < ElementoEstructural(mi + tamañoMascara, mj + tamañoMascara) * Niveles(i + mi, j + mj).B Then 'Buscamos el valor más alto dentro de la unidad estrucutural (máscara)
                                Azul = Niveles(i + mi, j + mj).B
                            End If
                        Next
                    Next

                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next

            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Operador morfológico. Dilatación") 'Actualizar el estado
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que calcula el operador morfológico de erosión de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim objetoEstructura As New TratamientoImagenes.ElementoEstructural 'Se instancia a la clase ElementoEstructural (se puede crear también una matrices personalizadas)
        '''Dim estructura = objetoEstructura.Cuadrado3x3 'Se define una cuadrada de 3x3
        '''Picturebox1.image=objetoTratamiento.MorfologicasErosión(bmp, estructura)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="ElementoEstructural">Matriz (impar, por ejemplo 3x3, 5x5...) de dos dimensiones que debe contener exclusivamente 0 y/o 1. </param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Véase también la clase Tratamiento.ElementoEstructural para ver cómo se crean elementos estructurales predefinidos.</remarks>
        Public Function MorfologicasErosion(ByVal bmp As Bitmap, ByVal ElementoEstructural(,) As Integer)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim tamañoMascara = ElementoEstructural.GetUpperBound(0) \ 2 'División entera

            'Dim bmp3 As New Bitmap(bmp2.Width - tamañoMascara, bmp2.Height - tamañoMascara) 'Redmiensionamos menos el tamaño de la máscara
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Aplicando operador morfológico. Erosión" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte

            For i = tamañoMascara To Niveles.GetUpperBound(0) - tamañoMascara
                For j = tamañoMascara To Niveles.GetUpperBound(1) - tamañoMascara
                    Rojo = 255
                    For mi = -tamañoMascara To tamañoMascara
                        For mj = -tamañoMascara To tamañoMascara
                            If Rojo > ElementoEstructural(mi + tamañoMascara, mj + tamañoMascara) * Niveles(i + mi, j + mj).R Then 'Buscamos el valor más alto dentro de la unidad estrucutural (máscara)
                                Rojo = Niveles(i + mi, j + mj).R
                            End If
                        Next
                    Next

                    Verde = 255
                    For mi = -tamañoMascara To tamañoMascara
                        For mj = -tamañoMascara To tamañoMascara
                            If Verde > ElementoEstructural(mi + tamañoMascara, mj + tamañoMascara) * Niveles(i + mi, j + mj).G Then 'Buscamos el valor más alto dentro de la unidad estrucutural (máscara)
                                Verde = Niveles(i + mi, j + mj).G
                            End If
                        Next
                    Next

                    Azul = 255
                    For mi = -tamañoMascara To tamañoMascara
                        For mj = -tamañoMascara To tamañoMascara
                            If Azul > ElementoEstructural(mi + tamañoMascara, mj + tamañoMascara) * Niveles(i + mi, j + mj).B Then 'Buscamos el valor más alto dentro de la unidad estrucutural (máscara)
                                Azul = Niveles(i + mi, j + mj).B
                            End If
                        Next
                    Next

                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next

            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Operador morfológico. Erosión") 'Actualizar el estado
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que calcula el operador morfológico de apertura de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim objetoEstructura As New TratamientoImagenes.ElementoEstructural 'Se instancia a la clase ElementoEstructural (se puede crear también una matrices personalizadas)
        '''Dim estructura = objetoEstructura.Cuadrado3x3 'Se define una cuadrada de 3x3
        '''Picturebox1.image=objetoTratamiento.MorfologicasApertura(bmp, estructura)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="ElementoEstructural">Matriz (impar, por ejemplo 3x3, 5x5...) de dos dimensiones que debe contener exclusivamente 0 y/o 1. </param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Véase también la clase Tratamiento.ElementoEstructural para ver cómo se crean elementos estructurales predefinidos.</remarks>
        Public Function MorfologicasApertura(ByVal bmp As Bitmap, ByVal ElementoEstructural(,) As Integer)
            Dim bmp2 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim objeto As New TratamientoImagenes
            Dim bmp3 = objeto.MorfologicasErosion(bmp2, ElementoEstructural)
            Dim bmp4 = objeto.MorfologicasDilatacion(bmp3, ElementoEstructural)
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp4) 'generamos el evento
            guardarImagen(bmp3, "Operador morfológico. Apertura") 'Actualizar el estado
            Return bmp4
        End Function

        ''' <summary>
        ''' Función que calcula el operador morfológico de cerradura de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim objetoEstructura As New TratamientoImagenes.ElementoEstructural 'Se instancia a la clase ElementoEstructural (se puede crear también una matrices personalizadas)
        '''Dim estructura = objetoEstructura.Cuadrado3x3 'Se define una cuadrada de 3x3
        '''Picturebox1.image=objetoTratamiento.MorfologicasCerradura(bmp, estructura)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="ElementoEstructural">Matriz (impar, por ejemplo 3x3, 5x5...) de dos dimensiones que debe contener exclusivamente 0 y/o 1. </param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Véase también la clase Tratamiento.ElementoEstructural para ver cómo se crean elementos estructurales predefinidos.</remarks>
        Public Function MorfologicasCerradura(ByVal bmp As Bitmap, ByVal ElementoEstructural(,) As Integer)
            Dim bmp2 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim objeto As New TratamientoImagenes
            Dim bmp3 = objeto.MorfologicasDilatacion(bmp2, ElementoEstructural)
            Dim bmp4 = objeto.MorfologicasErosion(bmp3, ElementoEstructural)
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp4) 'generamos el evento
            guardarImagen(bmp3, "Operador morfológico. Cerradura") 'Actualizar el estado
            Return bmp4
        End Function
        'Public Function MorfologicasGanaciaPerdida(ByVal bmp As Bitmap, ByVal ElementoEstructural1(,) As Integer, ByVal ElementoEstructural2(,) As Integer)
        '    Dim bmp2 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
        '    Dim bmp3 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
        '    Dim objeto As New TratamientoImagenes
        '    Dim bmp4 = objeto.MorfologicasErosion(bmp2, ElementoEstructural1)
        '    Dim bmp5 = objeto.Invertir(bmp3)
        '    Dim bmp6 = objeto.MorfologicasErosion(bmp5, ElementoEstructural2)
        '    Dim bmpSalida = objeto.OperacionAND(bmp4, bmp6, True)
        '    porcentaje(0) = 100 'Actualizamos el estado
        '    porcentaje(1) = "Finalizado" 'Actualizamos el estado
        '    RaiseEvent actualizaBMP(bmpSalida) 'generamos el evento
        '    guardarImagen(bmpSalida, "Operador morfológico. Transformada de ganancia o pérdida") 'Actualizar el estado
        '    Return bmpSalida
        'End Function

        ''' <summary>
        ''' Función que calcula el operador morfológico de perímetro (a través de diltación y erosión) de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim objetoEstructura As New TratamientoImagenes.ElementoEstructural 'Se instancia a la clase ElementoEstructural (se puede crear también una matrices personalizadas)
        '''Dim estructura = objetoEstructura.Cuadrado3x3 'Se define una cuadrada de 3x3
        '''Picturebox1.image=objetoTratamiento.MorfologicasPerimetroDilatEros(bmp, estructura)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="ElementoEstructural">Matriz (impar, por ejemplo 3x3, 5x5...) de dos dimensiones que debe contener exclusivamente 0 y/o 1. </param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Véase también la clase Tratamiento.ElementoEstructural para ver cómo se crean elementos estructurales predefinidos.</remarks>
        Public Function MorfologicasPerimetroDilatEros(ByVal bmp As Bitmap, ByVal ElementoEstructural(,) As Integer)
            Dim bmp2 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim bmp3 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim objeto As New TratamientoImagenes
            Dim bmp4 = objeto.MorfologicasErosion(bmp2, ElementoEstructural)
            Dim bmp5 = objeto.MorfologicasDilatacion(bmp3, ElementoEstructural)
            Dim bmp6 = objeto.OperacionResta(bmp5, bmp4)
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp6) 'generamos el evento
            guardarImagen(bmp6, "Operador morfológico. Perímetro (Dilatación-Erosión)") 'Actualizar el estado
            Return bmp6
        End Function

        ''' <summary>
        ''' Función que calcula el operador morfológico de perímetro (a través de la imagen original y erosionada) de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim objetoEstructura As New TratamientoImagenes.ElementoEstructural 'Se instancia a la clase ElementoEstructural (se puede crear también una matrices personalizadas)
        '''Dim estructura = objetoEstructura.Cuadrado3x3 'Se define una cuadrada de 3x3
        '''Picturebox1.image=objetoTratamiento.MorfologicasPerimetroOrigEros(bmp, estructura)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="ElementoEstructural">Matriz (impar, por ejemplo 3x3, 5x5...) de dos dimensiones que debe contener exclusivamente 0 y/o 1. </param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Véase también la clase Tratamiento.ElementoEstructural para ver cómo se crean elementos estructurales predefinidos.</remarks>
        Public Function MorfologicasPerimetroOrigEros(ByVal bmp As Bitmap, ByVal ElementoEstructural(,) As Integer)
            Dim bmp2 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim objeto As New TratamientoImagenes
            Dim bmp4 As Bitmap = objeto.MorfologicasErosion(bmp2, ElementoEstructural)
            Dim bmp6 = objeto.OperacionResta(bmp2, bmp4)
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp6) 'generamos el evento
            guardarImagen(bmp6, "Operador morfológico. Perímetro (Original-Erosión)") 'Actualizar el estado
            Return bmp6
        End Function

        ''' <summary>
        ''' Función que calcula el operador morfológico de perímetro (a través de la imagen dilatada y la original) de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim objetoEstructura As New TratamientoImagenes.ElementoEstructural 'Se instancia a la clase ElementoEstructural (se puede crear también una matrices personalizadas)
        '''Dim estructura = objetoEstructura.Cuadrado3x3 'Se define una cuadrada de 3x3
        '''Picturebox1.image=objetoTratamiento.MorfologicasPerimetroDilatOrigin(bmp, estructura)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="ElementoEstructural">Matriz (impar, por ejemplo 3x3, 5x5...) de dos dimensiones que debe contener exclusivamente 0 y/o 1. </param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Véase también la clase Tratamiento.ElementoEstructural para ver cómo se crean elementos estructurales predefinidos.</remarks>
        Public Function MorfologicasPerimetroDilatOrigin(ByVal bmp As Bitmap, ByVal ElementoEstructural(,) As Integer)
            Dim bmp2 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim objeto As New TratamientoImagenes
            Dim bmp4 = objeto.MorfologicasDilatacion(bmp2, ElementoEstructural)
            Dim bmp6 = objeto.OperacionResta(bmp4, bmp2)
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp6) 'generamos el evento
            guardarImagen(bmp6, "Operador morfológico. Perímetro (Dilatación-Original)") 'Actualizar el estado
            Return bmp6
        End Function

        ''' <summary>
        ''' Función que calcula el operador morfológico Top Hat de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim objetoEstructura As New TratamientoImagenes.ElementoEstructural 'Se instancia a la clase ElementoEstructural (se puede crear también una matrices personalizadas)
        '''Dim estructura = objetoEstructura.Cuadrado3x3 'Se define una cuadrada de 3x3
        '''Picturebox1.image=objetoTratamiento.MorfologicasTopHat(bmp, estructura)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="ElementoEstructural">Matriz (impar, por ejemplo 3x3, 5x5...) de dos dimensiones que debe contener exclusivamente 0 y/o 1. </param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Véase también la clase Tratamiento.ElementoEstructural para ver cómo se crean elementos estructurales predefinidos.</remarks>
        Public Function MorfologicasTopHat(ByVal bmp As Bitmap, ByVal ElementoEstructural(,) As Integer)
            Dim bmp2 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim bmp3 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim objeto As New TratamientoImagenes
            Dim bmp4 = objeto.MorfologicasApertura(bmp2, ElementoEstructural)
            Dim bmp6 = objeto.OperacionResta(bmp3, bmp4)
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp6) 'generamos el evento
            guardarImagen(bmp6, "Operador morfológico. Top Hat") 'Actualizar el estado
            Return bmp6
        End Function

        ''' <summary>
        ''' Función que calcula el operador morfológico Bottom Hat de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim objetoEstructura As New TratamientoImagenes.ElementoEstructural 'Se instancia a la clase ElementoEstructural (se puede crear también una matrices personalizadas)
        '''Dim estructura = objetoEstructura.Cuadrado3x3 'Se define una cuadrada de 3x3
        '''Picturebox1.image=objetoTratamiento.MorfologicasBottomHat(bmp, estructura)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="ElementoEstructural">Matriz (impar, por ejemplo 3x3, 5x5...) de dos dimensiones que debe contener exclusivamente 0 y/o 1. </param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Véase también la clase Tratamiento.ElementoEstructural para ver cómo se crean elementos estructurales predefinidos.</remarks>
        Public Function MorfologicasBottomHat(ByVal bmp As Bitmap, ByVal ElementoEstructural(,) As Integer)
            Dim bmp2 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim bmp3 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim objeto As New TratamientoImagenes
            Dim bmp4 = objeto.MorfologicasCerradura(bmp2, ElementoEstructural)
            Dim bmp6 = objeto.OperacionResta(bmp3, bmp4)
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp6) 'generamos el evento
            guardarImagen(bmp6, "Operador morfológico. Top Hat") 'Actualizar el estado
            Return bmp6
        End Function

        'Contiene clase con todos los elementos estructurales predefinidos
#Region "Clase con elementos estructurales"
        ''' <summary>
        ''' Esta función permite definir elementos estructurales predefinidos para aplicar junto con operadores morfológicos. Su principal función es devolver matrices impares formadas por 0 y/o 1.
        ''' El proceso de obtención de un elemento estructural es muy sencillo. A continuación se muestra cómo realizarlo.
        ''' <example><para>Para instancia un objeto de la clase Tratamiento.ElementoEstructural, primeramente debe hacer referencia a la clase en su proyecto:</para>
        ''' <code>Imports nombredeaplicacion.Tratamiento.ElementoEstructural</code>
        ''' <para>A continuación se instancia a la clase y ya se puede obtener un elemento estrucutral predefinido (este proceso es asistido, si utiliza Visual Studio, por IntelliSense):
        ''' <code>Dim objetoEstructura as new Tratamiento.ElementoEstructural 
        '''Dim mascara=objetoEstructura.Cuadrado3x3</code></para></example>
        ''' </summary>
        ''' <remarks>Clase creada por Luis Marcos Rivera.</remarks>
        Public Class ElementoEstructural
            Private Estructura(,) As Integer
            ''' <summary>
            ''' Función que devuelve una matriz de 3x3 formada por todo unos.
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.Cuadrado3x3</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Cuadrado3x3()
                ReDim Estructura(2, 2)
                For i = 0 To Estructura.GetUpperBound(0)
                    For j = 0 To Estructura.GetUpperBound(0)
                        Estructura(i, j) = 1
                    Next
                Next
                Return Estructura
            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 5x5 formada por todo unos.
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.Cuadrado5x5</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 5x5.</returns>
            Public Function Cuadrado5x5()
                ReDim Estructura(4, 4)
                For i = 0 To Estructura.GetUpperBound(0)
                    For j = 0 To Estructura.GetUpperBound(0)
                        Estructura(i, j) = 1
                    Next
                Next
                Return Estructura
            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 7x7 formada por todo unos.
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.Cuadrado7x7</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 7x7.</returns>
            Public Function Cuadrado7x7()
                ReDim Estructura(6, 6)
                For i = 0 To Estructura.GetUpperBound(0)
                    For j = 0 To Estructura.GetUpperBound(0)
                        Estructura(i, j) = 1
                    Next
                Next
                Return Estructura
            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 9x9 formada por todo unos.
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.Cuadrado9x9</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 9x9.</returns>
            Public Function Cuadrado9x9()
                ReDim Estructura(8, 8)
                For i = 0 To Estructura.GetUpperBound(0)
                    For j = 0 To Estructura.GetUpperBound(0)
                        Estructura(i, j) = 1
                    Next
                Next
                Return Estructura
            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de las dimensiones seleccionadas formada por todo unos.
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.CuadradoPersonal(5)</code></example>
            ''' </summary>
            ''' <param name="tamañoLado">Variable que indica el lado del cuadrado.</param>
            ''' <returns>Devuelve una matriz de 9x9.</returns>
            ''' <remarks>Si quiere crearse un cuadrado personalizado para utilizar en conjunto con los operadores morfológicos, éste debe ser impar.</remarks>
            Public Function CuadradoPersonal(ByVal tamañoLado As Integer)
                ReDim Estructura(tamañoLado - 1, tamañoLado - 1)
                For i = 0 To Estructura.GetUpperBound(0)
                    For j = 0 To Estructura.GetUpperBound(0)
                        Estructura(i, j) = 1
                    Next
                Next
                Return Estructura
            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 3x3 en forma de diamante (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.Diamante3x3</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function Diamante3x3()
                ReDim Estructura(2, 2)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 1 : Estructura(0, 2) = 0
                Estructura(1, 0) = 1 : Estructura(1, 1) = 1 : Estructura(1, 2) = 1
                Estructura(2, 0) = 0 : Estructura(2, 1) = 1 : Estructura(2, 2) = 0
                Return Estructura
            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 5x5 en forma de diamante (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.Diamante5x5</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 5x5.</returns>
            Public Function Diamante5x5()
                ReDim Estructura(4, 4)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 0 : Estructura(0, 2) = 1 : Estructura(0, 3) = 0 : Estructura(0, 4) = 0
                Estructura(1, 0) = 0 : Estructura(1, 1) = 1 : Estructura(1, 2) = 1 : Estructura(1, 3) = 1 : Estructura(1, 4) = 0
                Estructura(2, 0) = 1 : Estructura(2, 1) = 1 : Estructura(2, 2) = 1 : Estructura(2, 3) = 1 : Estructura(2, 4) = 1
                Estructura(3, 0) = 0 : Estructura(3, 1) = 1 : Estructura(3, 2) = 1 : Estructura(3, 3) = 1 : Estructura(3, 4) = 0
                Estructura(4, 0) = 0 : Estructura(4, 1) = 0 : Estructura(4, 2) = 1 : Estructura(4, 3) = 0 : Estructura(4, 4) = 0
                Return Estructura
            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 7x7 en forma de diamante (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.Diamante7x7</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 7x7.</returns>
            Public Function Diamante7x7()
                ReDim Estructura(6, 6)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0 : Estructura(0, 3) = 1 : Estructura(0, 4) = 0 : Estructura(0, 5) = 0 : Estructura(0, 6) = 0
                Estructura(1, 0) = 0 : Estructura(1, 1) = 0 : Estructura(1, 2) = 1 : Estructura(1, 3) = 1 : Estructura(1, 4) = 1 : Estructura(1, 5) = 0 : Estructura(1, 6) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 1 : Estructura(2, 2) = 1 : Estructura(2, 3) = 1 : Estructura(2, 4) = 1 : Estructura(2, 5) = 1 : Estructura(2, 6) = 0
                Estructura(3, 0) = 1 : Estructura(3, 1) = 1 : Estructura(3, 2) = 1 : Estructura(3, 3) = 1 : Estructura(3, 4) = 1 : Estructura(3, 5) = 1 : Estructura(3, 6) = 1
                Estructura(4, 0) = 0 : Estructura(4, 1) = 1 : Estructura(4, 2) = 1 : Estructura(4, 3) = 1 : Estructura(4, 4) = 1 : Estructura(4, 5) = 1 : Estructura(4, 6) = 0
                Estructura(5, 0) = 0 : Estructura(5, 1) = 0 : Estructura(5, 2) = 1 : Estructura(5, 3) = 1 : Estructura(5, 4) = 1 : Estructura(5, 5) = 0 : Estructura(5, 6) = 0
                Estructura(6, 0) = 0 : Estructura(6, 1) = 0 : Estructura(6, 2) = 0 : Estructura(6, 3) = 1 : Estructura(6, 4) = 0 : Estructura(6, 5) = 0 : Estructura(6, 6) = 0
                Return Estructura

            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 9x9 en forma de diamante (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.Diamante9x9</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 9x9.</returns>
            Public Function Diamante9x9()
                ReDim Estructura(8, 8)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0 : Estructura(0, 3) = 0 : Estructura(0, 4) = 1 : Estructura(0, 5) = 0 : Estructura(0, 6) = 0 : Estructura(0, 7) = 0 : Estructura(0, 8) = 0
                Estructura(1, 0) = 0 : Estructura(1, 1) = 0 : Estructura(1, 2) = 0 : Estructura(1, 3) = 1 : Estructura(1, 4) = 1 : Estructura(1, 5) = 1 : Estructura(1, 6) = 0 : Estructura(1, 7) = 0 : Estructura(1, 8) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 0 : Estructura(2, 2) = 1 : Estructura(2, 3) = 1 : Estructura(2, 4) = 1 : Estructura(2, 5) = 1 : Estructura(2, 6) = 1 : Estructura(2, 7) = 0 : Estructura(2, 8) = 0
                Estructura(3, 0) = 0 : Estructura(3, 1) = 1 : Estructura(3, 2) = 1 : Estructura(3, 3) = 1 : Estructura(3, 4) = 1 : Estructura(3, 5) = 1 : Estructura(3, 6) = 1 : Estructura(3, 7) = 1 : Estructura(3, 8) = 0
                Estructura(4, 0) = 1 : Estructura(4, 1) = 1 : Estructura(4, 2) = 1 : Estructura(4, 3) = 1 : Estructura(4, 4) = 1 : Estructura(4, 5) = 1 : Estructura(4, 6) = 1 : Estructura(4, 7) = 1 : Estructura(4, 8) = 1
                Estructura(5, 0) = 0 : Estructura(5, 1) = 1 : Estructura(5, 2) = 1 : Estructura(5, 3) = 1 : Estructura(5, 4) = 1 : Estructura(5, 5) = 1 : Estructura(5, 6) = 1 : Estructura(5, 7) = 1 : Estructura(5, 8) = 0
                Estructura(6, 0) = 0 : Estructura(6, 1) = 0 : Estructura(6, 2) = 1 : Estructura(6, 3) = 1 : Estructura(6, 4) = 1 : Estructura(6, 5) = 1 : Estructura(6, 6) = 1 : Estructura(6, 7) = 0 : Estructura(6, 8) = 0
                Estructura(7, 0) = 0 : Estructura(7, 1) = 0 : Estructura(7, 2) = 0 : Estructura(7, 3) = 1 : Estructura(7, 4) = 1 : Estructura(7, 5) = 1 : Estructura(7, 6) = 0 : Estructura(7, 7) = 0 : Estructura(7, 8) = 0
                Estructura(8, 0) = 0 : Estructura(8, 1) = 0 : Estructura(8, 2) = 0 : Estructura(8, 3) = 0 : Estructura(8, 4) = 1 : Estructura(8, 5) = 0 : Estructura(8, 6) = 0 : Estructura(8, 7) = 0 : Estructura(8, 8) = 0
                Return Estructura

            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 5x5 en forma de disco (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.Disco5x5</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 5x5.</returns>
            Public Function Disco5x5()
                ReDim Estructura(4, 4)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 1 : Estructura(0, 2) = 1 : Estructura(0, 3) = 1 : Estructura(0, 4) = 0
                Estructura(1, 0) = 1 : Estructura(1, 1) = 1 : Estructura(1, 2) = 1 : Estructura(1, 3) = 1 : Estructura(1, 4) = 1
                Estructura(2, 0) = 1 : Estructura(2, 1) = 1 : Estructura(2, 2) = 1 : Estructura(2, 3) = 1 : Estructura(2, 4) = 1
                Estructura(3, 0) = 1 : Estructura(3, 1) = 1 : Estructura(3, 2) = 1 : Estructura(3, 3) = 1 : Estructura(3, 4) = 1
                Estructura(4, 0) = 0 : Estructura(4, 1) = 1 : Estructura(4, 2) = 1 : Estructura(4, 3) = 1 : Estructura(4, 4) = 0
                Return Estructura
            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 7x7 en forma de disco (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.Disco7x7</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 7x7.</returns>
            Public Function Disco7x7()
                ReDim Estructura(6, 6)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 0 : Estructura(0, 2) = 1 : Estructura(0, 3) = 1 : Estructura(0, 4) = 1 : Estructura(0, 5) = 0 : Estructura(0, 6) = 0
                Estructura(1, 0) = 0 : Estructura(1, 1) = 1 : Estructura(1, 2) = 1 : Estructura(1, 3) = 1 : Estructura(1, 4) = 1 : Estructura(1, 5) = 1 : Estructura(1, 6) = 0
                Estructura(2, 0) = 1 : Estructura(2, 1) = 1 : Estructura(2, 2) = 1 : Estructura(2, 3) = 1 : Estructura(2, 4) = 1 : Estructura(2, 5) = 1 : Estructura(2, 6) = 1
                Estructura(3, 0) = 1 : Estructura(3, 1) = 1 : Estructura(3, 2) = 1 : Estructura(3, 3) = 1 : Estructura(3, 4) = 1 : Estructura(3, 5) = 1 : Estructura(3, 6) = 1
                Estructura(4, 0) = 1 : Estructura(4, 1) = 1 : Estructura(4, 2) = 1 : Estructura(4, 3) = 1 : Estructura(4, 4) = 1 : Estructura(4, 5) = 1 : Estructura(4, 6) = 1
                Estructura(5, 0) = 0 : Estructura(5, 1) = 1 : Estructura(5, 2) = 1 : Estructura(5, 3) = 1 : Estructura(5, 4) = 1 : Estructura(5, 5) = 1 : Estructura(5, 6) = 0
                Estructura(6, 0) = 0 : Estructura(6, 1) = 0 : Estructura(6, 2) = 1 : Estructura(6, 3) = 1 : Estructura(6, 4) = 1 : Estructura(6, 5) = 0 : Estructura(6, 6) = 0
                Return Estructura

            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 9x9 en forma de disco (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.Disco9x9</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 9x9.</returns>
            Public Function Disco9x9()
                ReDim Estructura(8, 8)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0 : Estructura(0, 3) = 1 : Estructura(0, 4) = 1 : Estructura(0, 5) = 1 : Estructura(0, 6) = 0 : Estructura(0, 7) = 0 : Estructura(0, 8) = 0
                Estructura(1, 0) = 0 : Estructura(1, 1) = 1 : Estructura(1, 2) = 1 : Estructura(1, 3) = 1 : Estructura(1, 4) = 1 : Estructura(1, 5) = 1 : Estructura(1, 6) = 1 : Estructura(1, 7) = 1 : Estructura(1, 8) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 1 : Estructura(2, 2) = 1 : Estructura(2, 3) = 1 : Estructura(2, 4) = 1 : Estructura(2, 5) = 1 : Estructura(2, 6) = 1 : Estructura(2, 7) = 1 : Estructura(2, 8) = 0
                Estructura(3, 0) = 1 : Estructura(3, 1) = 1 : Estructura(3, 2) = 1 : Estructura(3, 3) = 1 : Estructura(3, 4) = 1 : Estructura(3, 5) = 1 : Estructura(3, 6) = 1 : Estructura(3, 7) = 1 : Estructura(3, 8) = 1
                Estructura(4, 0) = 1 : Estructura(4, 1) = 1 : Estructura(4, 2) = 1 : Estructura(4, 3) = 1 : Estructura(4, 4) = 1 : Estructura(4, 5) = 1 : Estructura(4, 6) = 1 : Estructura(4, 7) = 1 : Estructura(4, 8) = 1
                Estructura(5, 0) = 1 : Estructura(5, 1) = 1 : Estructura(5, 2) = 1 : Estructura(5, 3) = 1 : Estructura(5, 4) = 1 : Estructura(5, 5) = 1 : Estructura(5, 6) = 1 : Estructura(5, 7) = 1 : Estructura(5, 8) = 1
                Estructura(6, 0) = 0 : Estructura(6, 1) = 1 : Estructura(6, 2) = 1 : Estructura(6, 3) = 1 : Estructura(6, 4) = 1 : Estructura(6, 5) = 1 : Estructura(6, 6) = 1 : Estructura(6, 7) = 1 : Estructura(6, 8) = 0
                Estructura(7, 0) = 0 : Estructura(7, 1) = 1 : Estructura(7, 2) = 1 : Estructura(7, 3) = 1 : Estructura(7, 4) = 1 : Estructura(7, 5) = 1 : Estructura(7, 6) = 1 : Estructura(7, 7) = 1 : Estructura(7, 8) = 0
                Estructura(8, 0) = 0 : Estructura(8, 1) = 0 : Estructura(8, 2) = 0 : Estructura(8, 3) = 1 : Estructura(8, 4) = 1 : Estructura(8, 5) = 1 : Estructura(8, 6) = 0 : Estructura(8, 7) = 0 : Estructura(8, 8) = 0
                Return Estructura

            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 3x3 formando una diagonal de izquierda a derecha (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.DiagonalA3x3</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function DiagonalA3x3()
                ReDim Estructura(2, 2)
                Estructura(0, 0) = 1 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0
                Estructura(1, 0) = 0 : Estructura(1, 1) = 1 : Estructura(1, 2) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 0 : Estructura(2, 2) = 1
                Return Estructura
            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 5x5 formando una diagonal de izquierda a derecha (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.DiagonalA5x5</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 5x5.</returns>
            Public Function DiagonalA5x5()
                ReDim Estructura(4, 4)
                Estructura(0, 0) = 1 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0 : Estructura(0, 3) = 0 : Estructura(0, 4) = 0
                Estructura(1, 0) = 0 : Estructura(1, 1) = 1 : Estructura(1, 2) = 0 : Estructura(1, 3) = 0 : Estructura(1, 4) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 0 : Estructura(2, 2) = 1 : Estructura(2, 3) = 0 : Estructura(2, 4) = 0
                Estructura(3, 0) = 0 : Estructura(3, 1) = 0 : Estructura(3, 2) = 0 : Estructura(3, 3) = 1 : Estructura(3, 4) = 0
                Estructura(4, 0) = 0 : Estructura(4, 1) = 0 : Estructura(4, 2) = 0 : Estructura(4, 3) = 0 : Estructura(4, 4) = 1
                Return Estructura
            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 7x7 formando una diagonal de izquierda a derecha (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.DiagonalA7x7</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 7x7.</returns>
            Public Function DiagonalA7x7()
                ReDim Estructura(6, 6)
                Estructura(0, 0) = 1 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0 : Estructura(0, 3) = 0 : Estructura(0, 4) = 0 : Estructura(0, 5) = 0 : Estructura(0, 6) = 0
                Estructura(1, 0) = 0 : Estructura(1, 1) = 1 : Estructura(1, 2) = 0 : Estructura(1, 3) = 0 : Estructura(1, 4) = 0 : Estructura(1, 5) = 0 : Estructura(1, 6) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 0 : Estructura(2, 2) = 1 : Estructura(2, 3) = 0 : Estructura(2, 4) = 0 : Estructura(2, 5) = 0 : Estructura(2, 6) = 0
                Estructura(3, 0) = 0 : Estructura(3, 1) = 0 : Estructura(3, 2) = 0 : Estructura(3, 3) = 1 : Estructura(3, 4) = 0 : Estructura(3, 5) = 0 : Estructura(3, 6) = 0
                Estructura(4, 0) = 0 : Estructura(4, 1) = 0 : Estructura(4, 2) = 0 : Estructura(4, 3) = 0 : Estructura(4, 4) = 1 : Estructura(4, 5) = 0 : Estructura(4, 6) = 0
                Estructura(5, 0) = 0 : Estructura(5, 1) = 0 : Estructura(5, 2) = 0 : Estructura(5, 3) = 0 : Estructura(5, 4) = 0 : Estructura(5, 5) = 1 : Estructura(5, 6) = 0
                Estructura(6, 0) = 0 : Estructura(6, 1) = 0 : Estructura(6, 2) = 0 : Estructura(6, 3) = 0 : Estructura(6, 4) = 0 : Estructura(6, 5) = 0 : Estructura(6, 6) = 1
                Return Estructura

            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 9x9 formando una diagonal de izquierda a derecha (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.DiagonalA9x9</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 9x9.</returns>
            Public Function DiagonalA9x9()
                ReDim Estructura(8, 8)
                Estructura(0, 0) = 1 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0 : Estructura(0, 3) = 0 : Estructura(0, 4) = 0 : Estructura(0, 5) = 0 : Estructura(0, 6) = 0 : Estructura(0, 7) = 0 : Estructura(0, 8) = 0
                Estructura(1, 0) = 0 : Estructura(1, 1) = 1 : Estructura(1, 2) = 0 : Estructura(1, 3) = 0 : Estructura(1, 4) = 0 : Estructura(1, 5) = 0 : Estructura(1, 6) = 0 : Estructura(1, 7) = 0 : Estructura(1, 8) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 0 : Estructura(2, 2) = 1 : Estructura(2, 3) = 0 : Estructura(2, 4) = 0 : Estructura(2, 5) = 0 : Estructura(2, 6) = 0 : Estructura(2, 7) = 0 : Estructura(2, 8) = 0
                Estructura(3, 0) = 0 : Estructura(3, 1) = 0 : Estructura(3, 2) = 0 : Estructura(3, 3) = 1 : Estructura(3, 4) = 0 : Estructura(3, 5) = 0 : Estructura(3, 6) = 0 : Estructura(3, 7) = 0 : Estructura(3, 8) = 0
                Estructura(4, 0) = 0 : Estructura(4, 1) = 0 : Estructura(4, 2) = 0 : Estructura(4, 3) = 0 : Estructura(4, 4) = 1 : Estructura(4, 5) = 0 : Estructura(4, 6) = 0 : Estructura(4, 7) = 0 : Estructura(4, 8) = 0
                Estructura(5, 0) = 0 : Estructura(5, 1) = 0 : Estructura(5, 2) = 0 : Estructura(5, 3) = 0 : Estructura(5, 4) = 0 : Estructura(5, 5) = 1 : Estructura(5, 6) = 0 : Estructura(5, 7) = 0 : Estructura(5, 8) = 0
                Estructura(6, 0) = 0 : Estructura(6, 1) = 0 : Estructura(6, 2) = 0 : Estructura(6, 3) = 0 : Estructura(6, 4) = 0 : Estructura(6, 5) = 0 : Estructura(6, 6) = 1 : Estructura(6, 7) = 0 : Estructura(6, 8) = 0
                Estructura(7, 0) = 0 : Estructura(7, 1) = 0 : Estructura(7, 2) = 0 : Estructura(7, 3) = 0 : Estructura(7, 4) = 0 : Estructura(7, 5) = 0 : Estructura(7, 6) = 0 : Estructura(7, 7) = 1 : Estructura(7, 8) = 0
                Estructura(8, 0) = 0 : Estructura(8, 1) = 0 : Estructura(8, 2) = 0 : Estructura(8, 3) = 0 : Estructura(8, 4) = 0 : Estructura(8, 5) = 0 : Estructura(8, 6) = 0 : Estructura(8, 7) = 0 : Estructura(8, 8) = 1
                Return Estructura

            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 3x3 formando una diagonal de derecha a izquieda (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.DiagonalB3x3</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 3x3.</returns>
            Public Function DiagonalB3x3()
                ReDim Estructura(2, 2)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 0 : Estructura(0, 2) = 1
                Estructura(1, 0) = 0 : Estructura(1, 1) = 1 : Estructura(1, 2) = 0
                Estructura(2, 0) = 1 : Estructura(2, 1) = 0 : Estructura(2, 2) = 0
                Return Estructura
            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 5x5 formando una diagonal de derecha a izquieda (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.DiagonalB5x5</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 5x5.</returns>
            Public Function DiagonalB5x5()
                ReDim Estructura(4, 4)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0 : Estructura(0, 3) = 0 : Estructura(0, 4) = 1
                Estructura(1, 0) = 0 : Estructura(1, 1) = 0 : Estructura(1, 2) = 0 : Estructura(1, 3) = 1 : Estructura(1, 4) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 0 : Estructura(2, 2) = 1 : Estructura(2, 3) = 0 : Estructura(2, 4) = 0
                Estructura(3, 0) = 0 : Estructura(3, 1) = 1 : Estructura(3, 2) = 0 : Estructura(3, 3) = 0 : Estructura(3, 4) = 0
                Estructura(4, 0) = 1 : Estructura(4, 1) = 0 : Estructura(4, 2) = 0 : Estructura(4, 3) = 0 : Estructura(4, 4) = 0
                Return Estructura
            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 7x7 formando una diagonal de derecha a izquieda (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.DiagonalB7x7</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 7x7.</returns>
            Public Function DiagonalB7x7()
                ReDim Estructura(6, 6)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0 : Estructura(0, 3) = 0 : Estructura(0, 4) = 0 : Estructura(0, 5) = 0 : Estructura(0, 6) = 1
                Estructura(1, 0) = 0 : Estructura(1, 1) = 0 : Estructura(1, 2) = 0 : Estructura(1, 3) = 0 : Estructura(1, 4) = 0 : Estructura(1, 5) = 1 : Estructura(1, 6) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 0 : Estructura(2, 2) = 0 : Estructura(2, 3) = 0 : Estructura(2, 4) = 1 : Estructura(2, 5) = 0 : Estructura(2, 6) = 0
                Estructura(3, 0) = 0 : Estructura(3, 1) = 0 : Estructura(3, 2) = 0 : Estructura(3, 3) = 1 : Estructura(3, 4) = 0 : Estructura(3, 5) = 0 : Estructura(3, 6) = 0
                Estructura(4, 0) = 0 : Estructura(4, 1) = 0 : Estructura(4, 2) = 1 : Estructura(4, 3) = 0 : Estructura(4, 4) = 0 : Estructura(4, 5) = 0 : Estructura(4, 6) = 0
                Estructura(5, 0) = 0 : Estructura(5, 1) = 1 : Estructura(5, 2) = 0 : Estructura(5, 3) = 0 : Estructura(5, 4) = 0 : Estructura(5, 5) = 0 : Estructura(5, 6) = 0
                Estructura(6, 0) = 1 : Estructura(6, 1) = 0 : Estructura(6, 2) = 0 : Estructura(6, 3) = 0 : Estructura(6, 4) = 0 : Estructura(6, 5) = 0 : Estructura(6, 6) = 0
                Return Estructura

            End Function

            ''' <summary>
            ''' Función que devuelve una matriz de 9x9 formando una diagonal de derecha a izquieda (formada por ceros y unos).
            ''' <example>Para obtener esta matriz, se debe proceder así:
            ''' <code>Dim estructura=objetoEstructura.DiagonalB9x9</code></example>
            ''' </summary>
            ''' <returns>Devuelve una matriz de 9x9.</returns>
            Public Function DiagonalB9x9()
                ReDim Estructura(8, 8)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0 : Estructura(0, 3) = 0 : Estructura(0, 4) = 0 : Estructura(0, 5) = 0 : Estructura(0, 6) = 0 : Estructura(0, 7) = 0 : Estructura(0, 8) = 1
                Estructura(1, 0) = 0 : Estructura(1, 1) = 0 : Estructura(1, 2) = 0 : Estructura(1, 3) = 0 : Estructura(1, 4) = 0 : Estructura(1, 5) = 0 : Estructura(1, 6) = 0 : Estructura(1, 7) = 1 : Estructura(1, 8) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 0 : Estructura(2, 2) = 0 : Estructura(2, 3) = 0 : Estructura(2, 4) = 0 : Estructura(2, 5) = 0 : Estructura(2, 6) = 1 : Estructura(2, 7) = 0 : Estructura(2, 8) = 0
                Estructura(3, 0) = 0 : Estructura(3, 1) = 0 : Estructura(3, 2) = 0 : Estructura(3, 3) = 0 : Estructura(3, 4) = 0 : Estructura(3, 5) = 1 : Estructura(3, 6) = 0 : Estructura(3, 7) = 0 : Estructura(3, 8) = 0
                Estructura(4, 0) = 0 : Estructura(4, 1) = 0 : Estructura(4, 2) = 0 : Estructura(4, 3) = 0 : Estructura(4, 4) = 1 : Estructura(4, 5) = 0 : Estructura(4, 6) = 0 : Estructura(4, 7) = 0 : Estructura(4, 8) = 0
                Estructura(5, 0) = 0 : Estructura(5, 1) = 0 : Estructura(5, 2) = 0 : Estructura(5, 3) = 1 : Estructura(5, 4) = 0 : Estructura(5, 5) = 0 : Estructura(5, 6) = 0 : Estructura(5, 7) = 0 : Estructura(5, 8) = 0
                Estructura(6, 0) = 0 : Estructura(6, 1) = 0 : Estructura(6, 2) = 1 : Estructura(6, 3) = 0 : Estructura(6, 4) = 0 : Estructura(6, 5) = 0 : Estructura(6, 6) = 0 : Estructura(6, 7) = 0 : Estructura(6, 8) = 0
                Estructura(7, 0) = 0 : Estructura(7, 1) = 1 : Estructura(7, 2) = 0 : Estructura(7, 3) = 0 : Estructura(7, 4) = 0 : Estructura(7, 5) = 0 : Estructura(7, 6) = 0 : Estructura(7, 7) = 0 : Estructura(7, 8) = 0
                Estructura(8, 0) = 1 : Estructura(8, 1) = 0 : Estructura(8, 2) = 0 : Estructura(8, 3) = 0 : Estructura(8, 4) = 0 : Estructura(8, 5) = 0 : Estructura(8, 6) = 0 : Estructura(8, 7) = 0 : Estructura(8, 8) = 0
                Return Estructura

            End Function
        End Class
#End Region
#End Region

        'Funciones estadísticas sobre píxeles de una imagen. Media
#Region "Operaciones estadísticas"
        ''' <summary>
        ''' Funcíón que calcula la media de un conjunto de píxeles que forman un kernel. El valor de la media lo asigna al conjunto de píxeles evaluados.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EstadisticoMedia(bmp, 3)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="LadoCuadrado">Variable que indica que lado del cuadrado. El lado real que va a tener el kernel, será LadoCuadrado*2+1.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EstadisticoMedia(ByVal bmp As Bitmap, Optional ByVal LadoCuadrado As Integer = 1)
            Dim bmp2 = bmp

            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Calculando media (lado " & LadoCuadrado + LadoCuadrado + 1 & ")"
            Dim Rojo, Verde, Azul As Integer
            Dim numeroPixelesEvaluados As Integer = Math.Pow(LadoCuadrado + LadoCuadrado + 1, 2)

            For i = LadoCuadrado To bmp2.Width - (LadoCuadrado + 1) Step LadoCuadrado + LadoCuadrado + 1  'Recorremos la matriz
                For j = LadoCuadrado To bmp2.Height - (LadoCuadrado + 1) Step LadoCuadrado + LadoCuadrado + 1
                    Rojo = 0 : Verde = 0 : Azul = 0
                    For mi = -LadoCuadrado To LadoCuadrado
                        For mj = -LadoCuadrado To LadoCuadrado
                            Rojo += bmp2.GetPixel(i + mi, j + mj).R
                            Verde += bmp2.GetPixel(i + mi, j + mj).G
                            Azul += bmp2.GetPixel(i + mi, j + mj).B
                        Next
                    Next
                    For mi = -LadoCuadrado To LadoCuadrado
                        For mj = -LadoCuadrado To LadoCuadrado
                            bmp3.SetPixel(i + mi, j + mj, Color.FromArgb(CInt(Rojo / numeroPixelesEvaluados), CInt(Verde / numeroPixelesEvaluados), CInt(Azul / numeroPixelesEvaluados))) 'Asignamos a bmp los colores 
                        Next
                    Next
                    porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
                Next
            Next
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Cálculo de media (lado " & LadoCuadrado + LadoCuadrado + 1 & ")") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Funcíón que calcula la media armónica de un conjunto de píxeles que forman un kernel. El valor de la media lo asigna al conjunto de píxeles evaluados.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EstadisticoArmonica(bmp, 3)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="LadoCuadrado">Variable que indica que lado del cuadrado. El lado real que va a tener el kernel, será LadoCuadrado*2+1.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EstadisticoMediaArmonica(ByVal bmp As Bitmap, Optional ByVal LadoCuadrado As Integer = 1)
            Dim bmp2 = bmp

            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Calculando media armónica (lado " & LadoCuadrado + LadoCuadrado + 1 & ")"
            Dim Rojo, Verde, Azul As Double
            Dim numeroPixelesEvaluados As Integer = Math.Pow(LadoCuadrado + LadoCuadrado + 1, 2)

            For i = LadoCuadrado To bmp2.Width - (LadoCuadrado + 1) Step LadoCuadrado + LadoCuadrado + 1  'Recorremos la matriz
                For j = LadoCuadrado To bmp2.Height - (LadoCuadrado + 1) Step LadoCuadrado + LadoCuadrado + 1
                    Rojo = 0 : Verde = 0 : Azul = 0
                    For mi = -LadoCuadrado To LadoCuadrado
                        For mj = -LadoCuadrado To LadoCuadrado
                            Rojo += 1 / bmp2.GetPixel(i + mi, j + mj).R
                            Verde += 1 / bmp2.GetPixel(i + mi, j + mj).G
                            Azul += 1 / bmp2.GetPixel(i + mi, j + mj).B
                        Next
                    Next
                    For mi = -LadoCuadrado To LadoCuadrado
                        For mj = -LadoCuadrado To LadoCuadrado
                            bmp3.SetPixel(i + mi, j + mj, Color.FromArgb(CInt(numeroPixelesEvaluados / Rojo), CInt(numeroPixelesEvaluados / Verde), CInt(numeroPixelesEvaluados / Azul))) 'Asignamos a bmp los colores 
                        Next
                    Next
                    porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
                Next
            Next
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Cálculo de media armónica (lado " & LadoCuadrado + LadoCuadrado + 1 & ")") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Funcíón que calcula la media geométrica de un conjunto de píxeles que forman un kernel. El valor de la media lo asigna al conjunto de píxeles evaluados.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EstadisticoGeometrica(bmp, 3)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="LadoCuadrado">Variable que indica que lado del cuadrado. El lado real que va a tener el kernel, será LadoCuadrado*2+1. El valor máximo posible es 5.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EstadisticoMediaGeométrica(ByVal bmp As Bitmap, Optional ByVal LadoCuadrado As Integer = 1)
            Dim bmp2 = bmp

            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Calculando media geométrica (lado " & LadoCuadrado + LadoCuadrado + 1 & ")"
            Dim Rojo, Verde, Azul As Double
            Dim numeroPixelesEvaluados As Integer = Math.Pow(LadoCuadrado + LadoCuadrado + 1, 2)

            For i = LadoCuadrado To bmp2.Width - (LadoCuadrado + 1) Step LadoCuadrado + LadoCuadrado + 1  'Recorremos la matriz
                For j = LadoCuadrado To bmp2.Height - (LadoCuadrado + 1) Step LadoCuadrado + LadoCuadrado + 1
                    Rojo = 1 : Verde = 1 : Azul = 1
                    For mi = -LadoCuadrado To LadoCuadrado
                        For mj = -LadoCuadrado To LadoCuadrado
                            Rojo *= bmp2.GetPixel(i + mi, j + mj).R
                            Verde *= bmp2.GetPixel(i + mi, j + mj).G
                            Azul *= bmp2.GetPixel(i + mi, j + mj).B
                        Next
                    Next
                    For mi = -LadoCuadrado To LadoCuadrado
                        For mj = -LadoCuadrado To LadoCuadrado
                            bmp3.SetPixel(i + mi, j + mj, Color.FromArgb(CInt(Math.Pow(Rojo, 1 / numeroPixelesEvaluados)), CInt(Math.Pow(Verde, 1 / numeroPixelesEvaluados)), CInt(Math.Pow(Azul, 1 / numeroPixelesEvaluados)))) 'Asignamos a bmp los colores 
                        Next
                    Next
                    porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
                Next
            Next
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Cálculo de media geométrica (lado " & LadoCuadrado + LadoCuadrado + 1 & ")") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Funcíón que calcula la mediana de un conjunto de píxeles que forman un kernel. El valor de la media lo asigna al conjunto de píxeles evaluados.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EstadisticoMediana(bmp, 3)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="LadoCuadrado">Variable que indica que lado del cuadrado. El lado real que va a tener el kernel, será LadoCuadrado*2+1.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EstadisticoMediana(ByVal bmp As Bitmap, Optional ByVal LadoCuadrado As Integer = 1)
            Dim bmp2 = bmp

            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Calculando mediana (lado " & LadoCuadrado + LadoCuadrado + 1 & ")"
            Dim Rojo, Verde, Azul As Integer()

            ReDim Rojo(Math.Pow((LadoCuadrado + LadoCuadrado + 1), 2) - 1)
            ReDim Verde(Math.Pow((LadoCuadrado + LadoCuadrado + 1), 2) - 1)
            ReDim Azul(Math.Pow((LadoCuadrado + LadoCuadrado + 1), 2) - 1)

            Dim numeroPixelesEvaluados As Integer = Math.Pow(LadoCuadrado + LadoCuadrado + 1, 2)
            Dim contador As Integer = 0
            For i = LadoCuadrado To bmp2.Width - (LadoCuadrado + 1) Step LadoCuadrado + LadoCuadrado + 1  'Recorremos la matriz
                For j = LadoCuadrado To bmp2.Height - (LadoCuadrado + 1) Step LadoCuadrado + LadoCuadrado + 1
                    contador = 0
                    For mi = -LadoCuadrado To LadoCuadrado
                        For mj = -LadoCuadrado To LadoCuadrado
                            Rojo(contador) = bmp2.GetPixel(i + mi, j + mj).R
                            Verde(contador) = bmp2.GetPixel(i + mi, j + mj).G
                            Azul(contador) = bmp2.GetPixel(i + mi, j + mj).B
                            contador += 1
                        Next
                    Next
                    'Ordenamos las matrices
                    Array.Sort(Rojo)
                    Array.Sort(Verde)
                    Array.Sort(Azul)
                    Dim rojoMedio, verdeMedio, azulMedio As Byte
                    'Buscamos valor intermedio (mediana)
                    rojoMedio = Rojo((Math.Pow((2 + 2 + 1), 2) - 1) / 2)
                    verdeMedio = Verde((Math.Pow((2 + 2 + 1), 2) - 1) / 2)
                    azulMedio = Azul((Math.Pow((2 + 2 + 1), 2) - 1) / 2)
                    For mi = -LadoCuadrado To LadoCuadrado
                        For mj = -LadoCuadrado To LadoCuadrado
                            bmp3.SetPixel(i + mi, j + mj, Color.FromArgb(rojoMedio, verdeMedio, azulMedio))
                        Next
                    Next
                    porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
                Next
            Next
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Cálculo de mediana (lado " & LadoCuadrado + LadoCuadrado + 1 & ")") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Funcíón que calcula la moda de un conjunto de píxeles que forman un kernel. El valor de la media lo asigna al conjunto de píxeles evaluados.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EstadisticoModa(bmp, 3)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="LadoCuadrado">Variable que indica que lado del cuadrado. El lado real que va a tener el kernel, será LadoCuadrado*2+1.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EstadisticoModa(ByVal bmp As Bitmap, Optional ByVal LadoCuadrado As Integer = 1)
            Dim bmp2 = bmp

            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Calculando moda (lado " & LadoCuadrado + LadoCuadrado + 1 & ")"
            Dim Rojo, Verde, Azul As Integer()

            ReDim Rojo(Math.Pow((LadoCuadrado + LadoCuadrado + 1), 2) - 1)
            ReDim Verde(Math.Pow((LadoCuadrado + LadoCuadrado + 1), 2) - 1)
            ReDim Azul(Math.Pow((LadoCuadrado + LadoCuadrado + 1), 2) - 1)

            Dim numeroPixelesEvaluados As Integer = Math.Pow(LadoCuadrado + LadoCuadrado + 1, 2)
            Dim contador As Integer = 0
            For i = LadoCuadrado To bmp2.Width - (LadoCuadrado + 1) Step LadoCuadrado + LadoCuadrado + 1  'Recorremos la matriz
                For j = LadoCuadrado To bmp2.Height - (LadoCuadrado + 1) Step LadoCuadrado + LadoCuadrado + 1
                    contador = 0
                    For mi = -LadoCuadrado To LadoCuadrado
                        For mj = -LadoCuadrado To LadoCuadrado
                            Rojo(contador) = bmp2.GetPixel(i + mi, j + mj).R
                            Verde(contador) = bmp2.GetPixel(i + mi, j + mj).G
                            Azul(contador) = bmp2.GetPixel(i + mi, j + mj).B
                            contador += 1
                        Next
                    Next
                    Dim rojoModaAux, verdeModaAux, azulModaAux As Integer
                    Dim rojoModa, verdeModa, azulModa As Byte
                    'Buscamos valor moda (más repetido)
                    Dim matrizAcumulada(255, 2) As ULong
                    For si = 0 To Rojo.Length - 1 'Acumulamos los valores
                        'ACumulamos los valores
                        matrizAcumulada(Rojo(si), 0) += 1
                        matrizAcumulada(Verde(si), 1) += 1
                        matrizAcumulada(Azul(si), 2) += 1
                    Next
                    rojoModaAux = 0 : verdeModaAux = 0 : azulModaAux = 0
                    For ri = 0 To 255 'Buscamos el valor más grande
                        If matrizAcumulada(ri, 0) > rojoModaAux Then rojoModaAux = ri
                        If matrizAcumulada(ri, 1) > verdeModaAux Then verdeModaAux = ri
                        If matrizAcumulada(ri, 2) > azulModaAux Then azulModaAux = ri
                    Next
                    rojoModa = rojoModaAux
                    verdeModa = verdeModaAux
                    azulModa = azulModaAux
                    For mi = -LadoCuadrado To LadoCuadrado
                        For mj = -LadoCuadrado To LadoCuadrado
                            bmp3.SetPixel(i + mi, j + mj, Color.FromArgb(rojoModa, verdeModa, azulModa))
                        Next
                    Next
                    porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
                Next
            Next
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Cálculo de moda (lado " & LadoCuadrado + LadoCuadrado + 1 & ")") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Funcíón que calcula el rango de un conjunto de píxeles que forman un kernel. El valor de la media lo asigna al conjunto de píxeles evaluados.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EstadisticoRango(bmp, 3)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="LadoCuadrado">Variable que indica que lado del cuadrado. El lado real que va a tener el kernel, será LadoCuadrado*2+1.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EstadisticoRango(ByVal bmp As Bitmap, Optional ByVal LadoCuadrado As Integer = 1)
            Dim bmp2 = bmp

            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Calculando rango (lado " & LadoCuadrado + LadoCuadrado + 1 & ")"
            Dim Rojo, Verde, Azul As Integer()

            ReDim Rojo(Math.Pow((LadoCuadrado + LadoCuadrado + 1), 2) - 1)
            ReDim Verde(Math.Pow((LadoCuadrado + LadoCuadrado + 1), 2) - 1)
            ReDim Azul(Math.Pow((LadoCuadrado + LadoCuadrado + 1), 2) - 1)

            Dim numeroPixelesEvaluados As Integer = Math.Pow(LadoCuadrado + LadoCuadrado + 1, 2)
            Dim contador As Integer = 0
            For i = LadoCuadrado To bmp2.Width - (LadoCuadrado + 1) Step LadoCuadrado + LadoCuadrado + 1  'Recorremos la matriz
                For j = LadoCuadrado To bmp2.Height - (LadoCuadrado + 1) Step LadoCuadrado + LadoCuadrado + 1
                    contador = 0
                    For mi = -LadoCuadrado To LadoCuadrado
                        For mj = -LadoCuadrado To LadoCuadrado
                            Rojo(contador) = bmp2.GetPixel(i + mi, j + mj).R
                            Verde(contador) = bmp2.GetPixel(i + mi, j + mj).G
                            Azul(contador) = bmp2.GetPixel(i + mi, j + mj).B
                            contador += 1
                        Next
                    Next
                    'Ordenamos las matrices
                    Array.Sort(Rojo)
                    Array.Sort(Verde)
                    Array.Sort(Azul)
                    Dim rojoRango, verdeRango, azulRango As Byte
                    'Buscamos valor intermedio (mediana)
                    rojoRango = Rojo(Rojo.Length - 1) - Rojo(0)
                    verdeRango = Verde(Verde.Length - 1) - Verde(0)
                    azulRango = Azul(Azul.Length - 1) - Azul(0)
                    For mi = -LadoCuadrado To LadoCuadrado
                        For mj = -LadoCuadrado To LadoCuadrado
                            bmp3.SetPixel(i + mi, j + mj, Color.FromArgb(rojoRango, verdeRango, azulRango))
                        Next
                    Next
                    porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
                Next
            Next
            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Cálculo de rango (lado " & LadoCuadrado + LadoCuadrado + 1 & ")") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

#End Region


#Region "Operaciones geométricas"
        ''' <summary>
        ''' Función que efectúa la reflexión vertical u horizontal de una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Picturebox1.image=objetoTratamiento.Reflexion(bmp, TRUE, FALSE)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="horizontal">Si es TRUE, indica que se va a efectuar la reflexión horizontal de la imagen. En caso de ser FALSE no se hará la reflexión horizontal.</param>
        ''' <param name="vertical">Si es TRUE, indica que se va a efectuar la reflexión vertical de la imagen. En caso de ser FALSE no se hará la reflexión vertical.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Tenga en cuenta que sólo se puede hacer una reflexión a la vez, por lo tanto sólo podrá haber un valor (horizontal o vertical) como TRUE.</remarks>
        Public Function Reflexion(ByVal bmp As Bitmap, Optional ByVal horizontal As Boolean = True, Optional ByVal vertical As Boolean = False) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            Dim tipoEstado As String = ""
            If horizontal = True Then tipoEstado = " horizontal" Else tipoEstado = " vertical"
            porcentaje(1) = "Aplicando reflexión" & tipoEstado 'Actualizar el estado
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).B
                    alfa = Niveles(i, j).A
                    If horizontal = True Then
                        bmp3.SetPixel(Niveles.GetUpperBound(0) - i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores 
                    Else
                        bmp3.SetPixel(i, Niveles.GetUpperBound(1) - j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores 
                    End If
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp3, "Reflexión" & tipoEstado) 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que traslada la imagen en X e Y y asigna valores sin color (ARGB=0) a la porción trasladada.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Picturebox1.image=objetoTratamiento.Traslacion(bmp, 20, 20)
        ''' </code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="Traslacionhorizontal">Valor en píxeles que se va a trasladar la imagen en el eje X. Debe ser positivo.</param>
        ''' <param name="Traslacionvertical">Valor en píxeles que se va a trasladar la imagen en el eje Y. Debe ser positivo.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function Traslacion(ByVal bmp As Bitmap, ByVal Traslacionhorizontal As Integer, ByVal Traslacionvertical As Integer) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Aplicando traslación. Horizontal: " & Traslacionhorizontal & " , Vertical: " & Traslacionvertical 'Actualizar el estado
            Dim bmp3 As New Bitmap(bmp2.Width + Traslacionhorizontal, bmp2.Height + Traslacionvertical)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).B
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i + Traslacionhorizontal, j + Traslacionvertical, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores desplazando
                Next
                porcentaje(0) = ((i * 100) / bmp2.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp3, "Traslación: " & Traslacionhorizontal & "," & Traslacionvertical) 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function
        'Public Function Rotacion(ByVal bmp As Bitmap, ByVal CoordenadaX As Integer, ByVal CoordenadaY As Integer, ByVal Giro As Integer, Optional AnchoBMPsalida As Integer = 5000, Optional altoBMPsalida As Integer = 5000) As Bitmap
        '    Dim bmp2 As Bitmap = bmp
        '    porcentaje(0) = 0 'Actualizar el estado
        '    porcentaje(1) = "Girando imagen" 'Actualizar el estado
        '    Dim G As Graphics
        '    Dim bmp3 As New Bitmap(AnchoBMPsalida, altoBMPsalida)
        '    G = Graphics.FromImage(bmp3)
        '    'Borra la Matriz de transformación
        '    G.ResetTransform()
        '    Dim TAfin As New Drawing2D.Matrix
        '    TAfin.RotateAt(Giro, New PointF(CoordenadaX, CoordenadaY))
        '    G.Transform = TAfin
        '    G.DrawImage(bmp2, New PointF(0, 0))
        '    porcentaje(0) = 100 'Actualizar el estado
        '    porcentaje(1) = "Finalizado" 'Actualizamos el estado
        '    guardarImagen(bmp3, "Imagen rotada " & Giro & "º")
        '    RaiseEvent actualizaBMP(bmp3) 'generamos el evento
        '    Return bmp3
        'End Function

        ''' <summary>
        ''' Función que efectúa un volteo de la imagen. Los volteos, son los predefinidos en .NET. Para los diferentes volteos, si se utilizar Visual Studio, IntelliSense le asistirá.
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="rotacion">Indica el tipo de volteo que se va a realizar.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Para ver la información de los diferentes tipos de volteos, visitar la siguiente web: msdn.microsoft.com/es-es/library/system.drawing.rotatefliptype(v=vs.80).aspx</remarks>
        Public Function Volteados(ByVal bmp As Bitmap, ByVal rotacion As RotateFlipType)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Aplicando volteado"
            Dim bmp2 As Bitmap = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            bmp2.RotateFlip(rotacion)
            porcentaje(0) = 100 'Actualizar el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            Dim bmp3 As Bitmap = bmp2
            guardarImagen(bmp3, "Volteado")
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

#End Region

#Region "Otras operaciones"
        ''' <summary>
        ''' Esta función es un tipo de segmentación simple. Consiste en pasar la imagen a escala de grises e ir asignando por rangos, diferentes colores. Se selecciona el número de divisiones y automáticamente se calculan las divisiones.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.DensitySlicing(bmp, 3, {Color.Red, Color.Black, Color.Blue})</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="Divisiones">Número de divisiones que se van a efectuar. Tenga en cuenta que el número máximo serían 256. Valores mayores de 15 dan resultados poco satisfactorios.</param>
        ''' <param name="colores">Matriz con los colores para diferentes divisiones.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>El número de divisiones (Divisiones) debe de ser el mismo que el número de colores (colores).</remarks>
        Public Function DensitySlicing(ByVal bmp As Bitmap, ByVal Divisiones As Integer, ByVal colores() As Color)
            If Divisiones <> colores.Length Then
                MessageBox.Show("El número de colores debe ser igual al número de divisiones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return bmp
                Exit Function
            End If
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            Dim bmp3 As New Bitmap(bmp.Width, bmp.Height)
            'Creamos el estado
            porcentaje(1) = "Aplicando density slicing"
            Dim Rojo, Verde, Azul, alfa As Integer
            Dim ValorCapa As Integer = 256 / Divisiones
            Dim valorMedia, valorAcumulado As Integer
            Dim valor As Integer = 0
            Dim colorSalida As Color
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    valorAcumulado = 0 : valor = 0
                    Rojo = Niveles(i, j).B
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).R
                    alfa = Niveles(i, j).A
                    valorMedia = (Rojo + Verde + Azul) / 3

                    For s = 1 To Divisiones
                        If valorMedia >= valorAcumulado And valorMedia < valorAcumulado + ValorCapa Then
                            colorSalida = colores(valor)
                            Exit For
                        End If
                        valorAcumulado += ValorCapa
                        valor += 1
                    Next
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, colorSalida))
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Density Slicing") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Esta función es un tipo de segmentación simple. Consiste en pasar la imagen a escala de grises e ir asignando por rangos, diferentes colores. Se seleccionan los diferentes rangos y se le asignan los colores.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code> Dim rango(2, 2) As Integer
        '''rango(0, 0) = 0 : rango(0, 1) = 100
        '''rango(1, 0) = 101 : rango(0, 2) = 200
        '''rango(2, 0) = 201 : rango(0, 3) = 255
        '''Picturebox1.image=objetoTratamiento.DensitySlicing(bmp, rango, {Color.Red, Color.Black, Color.Blue})</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="rangos">Intervalos de las diferentes divisiones. Es una matriz bidimensional en la que cada fila debe incluir el rango de una división.</param>
        ''' <param name="colores">Matriz con los colores para diferentes divisiones.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>El número de divisiones (Divisiones) debe de ser el mismo que el rango de colores (rangos).</remarks>
        Public Function DensitySlicing(ByVal bmp As Bitmap, ByVal rangos(,) As Integer, ByVal colores() As Color)
            If rangos.GetUpperBound(0) + 1 <> colores.Length Then
                MessageBox.Show("El número de colores debe ser igual al número de divisiones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return bmp
                Exit Function
            End If
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            Dim bmp3 As New Bitmap(bmp.Width, bmp.Height)
            'Creamos el estado
            porcentaje(1) = "Aplicando density slicing"
            Dim Rojo, Verde, Azul, alfa As Integer

            Dim valorMedia As Integer
            Dim valor As Integer = 0
            Dim colorSalida As Color
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).B
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).R
                    alfa = Niveles(i, j).A
                    valorMedia = (Rojo + Verde + Azul) / 3
                    colorSalida = Color.FromArgb(0, 0, 0, 0)
                    For s = 0 To rangos.GetUpperBound(0)
                        If valorMedia >= rangos(s, 0) And valorMedia <= rangos(s, 1) Then
                            colorSalida = colores(s)
                            Exit For
                        End If
                    Next
                    bmp3.SetPixel(i, j, colorSalida)
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Density Slicing") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Esta función es un tipo de segmentación simple. Consiste en pasar la imagen a escala de grises e ir asignando por rangos, diferentes colores. Se selecciona el número de divisiones y automáticamente el algoritmo lo adapatará en función del valor máximo y mínimo de la imagen, es decir, está normalizada.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.DensitySlicingNormalizado(bmp, 3, {Color.Red, Color.Black, Color.Blue})</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="Divisiones">Número de divisiones que se van a efectuar. Tenga en cuenta que el número máximo serían 256. Valores mayores de 15 dan resultados poco satisfactorios.</param>
        ''' <param name="colores">Matriz con los colores para diferentes divisiones.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>El número de divisiones (Divisiones) debe de ser el mismo que el número de colores (colores).</remarks>
        Public Function DensitySlicingNormalizado(ByVal bmp As Bitmap, ByVal Divisiones As Integer, ByVal colores() As Color)
            If Divisiones <> colores.Length Then
                MessageBox.Show("El número de colores debe ser igual al número de divisiones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return bmp
                Exit Function
            End If
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            porcentaje(0) = 0 'Actualizamos el estado
            porcentaje(1) = "Cargando imagen" 'Actualizamos el estado
            Dim minimo As Byte = 255
            Dim maximo As Byte = 0

            'Este primer bloque, guarda los niveles digitales de la imagen en la variable Niveles
            Dim i, j As Long
            Dim ValorGris, Rojoaxu, Verdeaxu, Azulaux As Integer
            ReDim Niveles(bmp2.Width - 1, bmp2.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            For i = 0 To bmp2.Width - 1 'Recorremos la matriz a lo ancho
                For j = 0 To bmp2.Height - 1 'Recorremos la matriz a lo largo
                    Niveles(i, j) = bmp2.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                    Rojoaxu = Niveles(i, j).R : Verdeaxu = Niveles(i, j).G : Azulaux = Niveles(i, j).B
                    ValorGris = (Rojoaxu + Verdeaxu + Azulaux) / 3
                    If ValorGris > maximo Then maximo = ValorGris
                    If ValorGris < minimo Then minimo = ValorGris
                    porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
                Next
            Next

            'Creamos el estado
            porcentaje(1) = "Aplicando density slicing"
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            'Mientras cargo la imagen buscar el valor mínimo y máximo

            Dim valoresIntermedios As Integer = maximo - minimo

            Dim Rojo, Verde, Azul, alfa As Integer
            Dim ValorCapa As Integer = valoresIntermedios / Divisiones
            Dim valorMedia, valorAcumulado As Integer
            Dim valor As Integer = 0
            Dim colorSalida As Color
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    valorAcumulado = minimo : valor = 0
                    Rojo = Niveles(i, j).B
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).R
                    alfa = Niveles(i, j).A
                    valorMedia = (Rojo + Verde + Azul) / 3

                    For s = 1 To Divisiones
                        If valorMedia >= valorAcumulado And valorMedia < valorAcumulado + ValorCapa Then
                            colorSalida = colores(valor)
                            Exit For
                        End If
                        valorAcumulado += ValorCapa
                        valor += 1
                    Next
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, colorSalida))
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Density Slicing normalizado") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function
#End Region



        'Principales efectos sobre imágenes. Contiene funciones que devuelven bitmaps
#Region "Efectos"
        ''' <summary>
        ''' Función que desenfoca creando un efecto de duplicidad de imágenes estando una de ellas movida.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.desenfoque(bmp,20,20)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="desenfoqueHor">Variable que indica el número de píxeles que se van a desenfocar en la imagen en horizontal.</param>
        ''' <param name="desenfoqueVer">Variable que indica el número de píxeles que se van a desenfocar en la imagen en vertical.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function desenfoque(ByVal bmp As Bitmap, Optional ByVal desenfoqueHor As Short = 0, Optional ByVal desenfoqueVer As Short = 0)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp.Width, bmp.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Desenfocando imagen. Etapa 1/2" 'Actualizar el estado

            'Esto lo hacemos para asignar lo del bmp al bmp3
            Dim Rojo3, Verde3, Azul3, alfa3 As Byte
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo3 = Niveles(i, j).R
                    Verde3 = Niveles(i, j).G
                    Azul3 = Niveles(i, j).B
                    alfa3 = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa3, Rojo3, Verde3, Azul3)) 'Asignamos a bmp los colores invertidos
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next



            Dim desenfoquePos, desenfoqueNeg As Short
            If desenfoqueHor > 0 Then desenfoquePos = desenfoqueHor : desenfoqueNeg = 0 Else desenfoqueNeg = desenfoqueHor : desenfoquePos = 0

            Dim desenfoquePos1, desenfoqueNeg1 As Short
            If desenfoqueVer > 0 Then desenfoquePos1 = desenfoqueVer : desenfoqueNeg1 = 0 Else desenfoqueNeg1 = desenfoqueVer : desenfoquePos1 = 0

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Desenfocando imagen. Etapa 2/2" 'Actualizar el estado

            Dim Rojoaux, Verdeaux, Azulaux As UInteger 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux1, Verdeaux1, Azulaux1 As UInteger 'Declaramos tres variables que almacenarán los colores
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 - desenfoqueNeg To Niveles.GetUpperBound(0) - desenfoquePos   'Recorremos la matriz
                For j = 0 - desenfoqueNeg1 To Niveles.GetUpperBound(1) - desenfoquePos1
                    Rojoaux = Niveles(i, j).R
                    Rojoaux1 = Niveles(i + desenfoqueHor, j + desenfoqueVer).R ' 
                    Verdeaux = Niveles(i, j).G
                    Verdeaux1 = Niveles(i + desenfoqueHor, j + desenfoqueVer).G
                    Azulaux = Niveles(i, j).B
                    Azulaux1 = Niveles(i + desenfoqueHor, j + desenfoqueVer).B
                    Rojoaux = CInt(Rojoaux + Rojoaux1) / 2
                    Verdeaux = CInt(Verdeaux + Verdeaux1) / 2
                    Azulaux = CInt(Azulaux + Azulaux1) / 2
                    Rojo = Rojoaux : Verde = Verdeaux : Azul = Azulaux
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp3, "Desenfoque") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que crea una cuadricula por encima de la imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.cuadricula(bmp,color.Red,color.Red,20,20)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="colorHorizontal">Color que se asignará a las líneas horizontales de la cuadrícula.</param>
        ''' <param name="colorVertical">Color que se asignará a las líneas verticales de la cuadrícula.</param>
        ''' <param name="horizontal">Espaciado horizontal entre las líneas verticales. El valor debe ser mayor que 0.</param>
        ''' <param name="vertical">Espaciado vertical entre las líneas horizontales. El valor debe ser mayor que 0.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function cuadricula(ByVal bmp As Bitmap, ByVal colorHorizontal As Color, ByVal colorVertical As Color, ByVal horizontal As Integer, Optional ByVal vertical As Integer = 20)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Creando cuadrícula. Etapa 1/2" 'Actualizar el estado

            If horizontal = 0 Or vertical = 0 Then MessageBox.Show("El valor no puede ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : Return bmp2

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).B
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Creando cuadrícula. Etapa 2/2" 'Actualizar el estado

            For i = 0 To Niveles.GetUpperBound(0) Step horizontal   'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    bmp3.SetPixel(i, j, colorHorizontal)
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1) Step vertical
                    bmp3.SetPixel(i, j, colorVertical)
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp3, "Cuadrícula") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que crea una imagen espejo en la parte inferior de la imagen original, pudiendo estar ésta atenuada.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.SombraVidrio(bmp,100,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="altoSombra">Indica el tamaño en píxeles de la sombra creada en la parte inferior de la imagen. El tamaño no puede ser mayor que el alto de la imagen original.</param>
        ''' <param name="atenuarSombra">Si la variable es TRUE, el canal alfa disminuye a lo largo de la sombra. En caso de ser FALSE, el canal alfa no se varía.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function SombraVidrio(ByVal bmp As Bitmap, ByVal altoSombra As Integer, Optional ByVal atenuarSombra As Boolean = True) As Bitmap
            Dim bmp2 = bmp

            Dim bmpRota As Bitmap = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores

            bmpRota.RotateFlip(RotateFlipType.RotateNoneFlipY)
            Dim NivelesRota(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            NivelesRota = nivel(bmpRota) 'Obtenemos valores

            Dim bmp3 As New Bitmap(bmp2.Width, CInt(bmp2.Height + altoSombra))

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Aplicando efecto sombre de vidrio" 'Actualizar el estado

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim alfaaxu As Double
            Dim contadorAlfa As Double = 0
            Dim cuentaAux As Double = 255 / (altoSombra)
            Dim i, j As Integer
            For j = 0 To bmp3.Height - 1
                If j > Niveles.GetUpperBound(1) And atenuarSombra = True Then
                    contadorAlfa += cuentaAux 'Restamos una "unidad" al canal alfa
                End If
                For i = 0 To bmp3.Width - 1  'Recorremos la matriz
                    If j < Niveles.GetUpperBound(1) Then 'Si es menor que el alto de la imagen original
                        Rojo = Niveles(i, j).R
                        Verde = Niveles(i, j).G
                        Azul = Niveles(i, j).B
                        alfa = Niveles(i, j).A
                        bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores 
                    Else
                        Rojo = NivelesRota(i, j - Niveles.GetUpperBound(1)).R
                        Verde = NivelesRota(i, j - Niveles.GetUpperBound(1)).G
                        Azul = NivelesRota(i, j - Niveles.GetUpperBound(1)).B
                        alfaaxu = NivelesRota(i, j - Niveles.GetUpperBound(1)).A - contadorAlfa
                        If alfaaxu < 0 Then
                            alfaaxu = 0 'Para evitar que el último píxel sea menor de 0
                        End If

                        alfa = alfaaxu
                        bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores 
                    End If

                Next
                porcentaje(0) = CInt(((j * 100) / (bmp3.Height))) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp3, "Efecto sombra de vidrio") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que divide la imagen en tres partes (verticales) y las alterna.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.ImagenTresPartes(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function ImagenTresPartes(ByVal bmp As Bitmap) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 = bmp
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Creando partes" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            porcentaje(1) = "Creando partes. Etapa 1/3" 'Actualizar el estado
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1) / 3
                    Rojo = Niveles(i, j + (Niveles.GetUpperBound(1) / 3 * 2)).R
                    Verde = Niveles(i, j + (Niveles.GetUpperBound(1) / 3 * 2)).G
                    Azul = Niveles(i, j + (Niveles.GetUpperBound(1) / 3 * 2)).B
                    alfa = Niveles(i, j + (Niveles.GetUpperBound(1) / 3 * 2)).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores  
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Creando partes. Etapa 2/3" 'Actualizar el estado
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = Niveles.GetUpperBound(1) / 3 To Niveles.GetUpperBound(1) / 3 * 2
                    Rojo = Niveles(i, j).R
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).B
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores  
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Creando partes. Etapa 3/3" 'Actualizar el estado
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = Niveles.GetUpperBound(1) / 3 * 2 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j - (Niveles.GetUpperBound(1) / 3 * 2)).R
                    Verde = Niveles(i, j - (Niveles.GetUpperBound(1) / 3 * 2)).G
                    Azul = Niveles(i, j - (Niveles.GetUpperBound(1) / 3 * 2)).B
                    alfa = Niveles(i, j - (Niveles.GetUpperBound(1) / 3 * 2)).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores  
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next

            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp3, "Imagen en tres partes") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que divide la imagen en seis partes (dos horizontales y tres verticales) y las alterna.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.ImagenSeisPartes(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function ImagenSeisPartes(ByVal bmp As Bitmap) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp.Width, bmp.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Creando partes" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            porcentaje(1) = "Creando partes. Etapa 1/6" 'Actualizar el estado
            For i = 0 To Niveles.GetUpperBound(0) / 3  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1) / 2
                    Rojo = Niveles(i + (Niveles.GetUpperBound(0) / 3 * 2), j).R
                    Verde = Niveles(i + (Niveles.GetUpperBound(0) / 3 * 2), j).G
                    Azul = Niveles(i + (Niveles.GetUpperBound(0) / 3 * 2), j).B
                    alfa = Niveles(i + (Niveles.GetUpperBound(0) / 3 * 2), j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores  
                Next
                porcentaje(0) = ((i * 100) / bmp.Width)  'Actualizamos el estado
            Next
            porcentaje(1) = "Creando partes. Etapa 2/6" 'Actualizar el estado
            For i = Niveles.GetUpperBound(0) / 3 To Niveles.GetUpperBound(0) / 3 * 2  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1) / 2
                    Rojo = Niveles(i, j).R
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).B
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores  
                Next
                porcentaje(0) = ((i * 100) / bmp.Width)  'Actualizamos el estado
            Next
            porcentaje(1) = "Creando partes. Etapa 3/6" 'Actualizar el estado
            For i = Niveles.GetUpperBound(0) / 3 * 2 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1) / 2
                    Rojo = Niveles(i - (Niveles.GetUpperBound(0) / 3 * 2), j).R
                    Verde = Niveles(i - (Niveles.GetUpperBound(0) / 3 * 2), j).G
                    Azul = Niveles(i - (Niveles.GetUpperBound(0) / 3 * 2), j).B
                    alfa = Niveles(i - (Niveles.GetUpperBound(0) / 3 * 2), j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores  
                Next
                porcentaje(0) = ((i * 100) / bmp.Width)  'Actualizamos el estado
            Next

            porcentaje(1) = "Creando partes. Etapa 4/6" 'Actualizar el estado
            For i = 0 To Niveles.GetUpperBound(0) / 3  'Recorremos la matriz
                For j = CInt(Niveles.GetUpperBound(1) / 2) To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i + (Niveles.GetUpperBound(0) / 3), j).R
                    Verde = Niveles(i + (Niveles.GetUpperBound(0) / 3), j).G
                    Azul = Niveles(i + (Niveles.GetUpperBound(0) / 3), j).B
                    alfa = Niveles(i + (Niveles.GetUpperBound(0) / 3), j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores  
                Next
                porcentaje(0) = ((i * 100) / bmp.Width)  'Actualizamos el estado
            Next
            porcentaje(1) = "Creando partes. Etapa 5/6" 'Actualizar el estado
            For i = Niveles.GetUpperBound(0) / 3 To Niveles.GetUpperBound(0) / 3 * 2  'Recorremos la matriz
                For j = CInt(Niveles.GetUpperBound(1) / 2) To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i - (Niveles.GetUpperBound(0) / 3), j).R
                    Verde = Niveles(i - (Niveles.GetUpperBound(0) / 3), j).G
                    Azul = Niveles(i - (Niveles.GetUpperBound(0) / 3), j).B
                    alfa = Niveles(i - (Niveles.GetUpperBound(0) / 3), j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores  
                Next
                porcentaje(0) = ((i * 100) / bmp.Width)  'Actualizamos el estado
            Next
            porcentaje(1) = "Creando partes. Etapa 6/6" 'Actualizar el estado
            For i = Niveles.GetUpperBound(0) / 3 * 2 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = CInt(Niveles.GetUpperBound(1) / 2) To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).B
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores  
                Next
                porcentaje(0) = ((i * 100) / bmp.Width)  'Actualizamos el estado
            Next


            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp3, "Imagen en seis partes") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que introduce a la imagen píxeles con valores aleatorios.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.RuidoAleatorio(bmp,2)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="valorRuido">Indica el grado de píxeles aleatorios. A partir de valores mayores de 20, la imagen pierde casi por totalidad su aspecto original.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function RuidoAleatorio(ByVal bmp As Bitmap, ByVal valorRuido As Byte)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Generando ruido aleatorio" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte

            'Inicializar la clase Random  
            Dim Random As New Random()

            Dim numeroHo, numeroVert As Integer
            For i = 0 To Niveles.GetUpperBound(0)   'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    If j Mod valorRuido <> 0 And i Mod valorRuido <> 0 Then
                        numeroHo = Random.Next(0, bmp2.Width - 1)
                        numeroVert = Random.Next(0, bmp2.Height - 1)
                        Rojo = Niveles(numeroHo, numeroVert).R
                        Verde = Niveles(numeroHo, numeroVert).G
                        Azul = Niveles(numeroHo, numeroVert).B
                        alfa = Niveles(numeroHo, numeroVert).A
                    Else
                        Rojo = Niveles(i, j).R
                        Verde = Niveles(i, j).G
                        Azul = Niveles(i, j).B
                        alfa = Niveles(i, j).A
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            guardarImagen(bmp3, "Imagen con ruido aleatorio") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que altera los valores originales de los píxeles de forma aleatoria.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.RuidoProgresivo(bmp,50,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="valorRuido">Indica el rango entre el que oscilará el nuevo valor del píxel con respecto al valor original.</param>
        ''' <param name="blancoNegro">Si el parámetro es TRUE, los valores alterados estarán en blanco y negro.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function RuidoProgresivo(ByVal bmp As Bitmap, ByVal valorRuido As Integer, Optional blancoNegro As Boolean = False)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Generando ruido progresivo" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte
            Dim Rojoaux, Verdeaux, Azulaux As Integer
            'Inicializar la clase Random  
            Dim Random As New Random()

            Dim ValorRandomRuido As Integer
            For i = 0 To Niveles.GetUpperBound(0)   'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    ValorRandomRuido = Random.Next(-(valorRuido - 1), valorRuido + 1)
                    Rojoaux = Niveles(i, j).R + ValorRandomRuido
                    If blancoNegro = False Then
                        ValorRandomRuido = Random.Next(-(valorRuido - 1), valorRuido + 1)
                    End If
                    Verdeaux = Niveles(i, j).G + ValorRandomRuido

                    If blancoNegro = False Then
                        ValorRandomRuido = Random.Next(-(valorRuido - 1), valorRuido + 1)
                    End If
                    Azulaux = Niveles(i, j).B + ValorRandomRuido

                    If Rojoaux < 0 Then Rojoaux = 0
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeaux < 0 Then Verdeaux = 0
                    If Verdeaux > 255 Then Verdeaux = 255
                    If Azulaux < 0 Then Azulaux = 0
                    If Azulaux > 255 Then Azulaux = 255
                    Rojo = Rojoaux
                    Verde = Verdeaux
                    Azul = Azulaux
                    alfa = Niveles(i, j).A
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            guardarImagen(bmp3, "Imagen con ruido progresivo") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que distorsiona la posición de los píxeles de forma aleatoria en función del parámetro valorDesenfoque.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.Distorsión(bmp,8)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="valorDesenfoque">Variable que indica el rango en que se moverán de su posición original los píxeles de la imagen.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function Distorsion(ByVal bmp As Bitmap, ByVal valorDesenfoque As Byte)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Distorsionando imagen" 'Actualizar el estado
            Dim Rojo, Verde, Azul, alfa As Byte

            'Inicializar la clase Random  
            Dim Random As New Random()

            Dim numeroRandom As Integer
            For i = 0 To Niveles.GetUpperBound(0)   'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    numeroRandom = Random.Next(valorDesenfoque + 1)
                    If j < Niveles.GetUpperBound(1) - valorDesenfoque And i < Niveles.GetUpperBound(0) - valorDesenfoque Then
                        Rojo = Niveles(i + numeroRandom, j + numeroRandom).R
                        Verde = Niveles(i + numeroRandom, j + numeroRandom).G
                        Azul = Niveles(i + numeroRandom, j + numeroRandom).B
                        alfa = Niveles(i + numeroRandom, j + numeroRandom).A
                    ElseIf j > Niveles.GetUpperBound(1) - valorDesenfoque And i < Niveles.GetUpperBound(0) - valorDesenfoque Then
                        Rojo = Niveles(i + numeroRandom, j - numeroRandom).R
                        Verde = Niveles(i + numeroRandom, j - numeroRandom).G
                        Azul = Niveles(i + numeroRandom, j - numeroRandom).B
                        alfa = Niveles(i + numeroRandom, j - numeroRandom).A
                    ElseIf j < Niveles.GetUpperBound(1) - valorDesenfoque And i > Niveles.GetUpperBound(0) - valorDesenfoque Then
                        Rojo = Niveles(i - numeroRandom, j + numeroRandom).R
                        Verde = Niveles(i - numeroRandom, j + numeroRandom).G
                        Azul = Niveles(i - numeroRandom, j + numeroRandom).B
                        alfa = Niveles(i - numeroRandom, j + numeroRandom).A
                    Else
                        Rojo = Niveles(i, j).R
                        Verde = Niveles(i, j).G
                        Azul = Niveles(i, j).B
                        alfa = Niveles(i, j).A
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            guardarImagen(bmp3, "Imagen distorsionada") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que pixela la imagen creando cuadrados con píxeles con el mismo valor.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.Pixelar(bmp,8)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="numeroPixeles">Variable que define el ancho de los nuevos píxeles.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function Pixelar(ByVal bmp As Bitmap, ByVal numeroPixeles As Integer)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width - Niveles.GetUpperBound(0) Mod numeroPixeles, bmp2.Height - Niveles.GetUpperBound(1) Mod numeroPixeles) 'Al tamaño se le quita el excedente
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Pixelando imagen x" & numeroPixeles 'Actualizar el estado
            Dim almacenAux(3) As Byte

            For i = 0 To Niveles.GetUpperBound(0) - numeroPixeles Step numeroPixeles   'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1) - numeroPixeles Step numeroPixeles
                    almacenAux = calculaValorInterpolado(Niveles, {(i), (j)}, numeroPixeles) 'Calculamos el valor medio de los píxeles
                    For mi = i To i + numeroPixeles
                        For mj = j To j + numeroPixeles
                            bmp3.SetPixel(mi, mj, Color.FromArgb(almacenAux(3), almacenAux(0), almacenAux(1), almacenAux(2))) 'Asignamos a bmp los colores 
                        Next
                    Next
                Next
                porcentaje(0) = ((i * 100) / (bmp3.Width - numeroPixeles)) 'Actualizamos el estado
            Next
            guardarImagen(bmp3, "Imagen pixelada x" & numeroPixeles) 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que crea un efecto que imita a una imagen pintada al óleo. Se crea en tres etapas, primeramente reduce los colores de la imagen, detecta los contornos, y por último une las imágenes.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.Oleo(bmp,30,170)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="contorno">Variable que indica el grado de contornos que se va a detectar. Valores más bajos detectan más contornos que los superiores.</param>
        ''' <param name="colores">Variable que indica que número de colores máximo que tendrá la imagen por canal.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function Oleo(ByVal bmp As Bitmap, Optional ByVal contorno As Byte = 30, Optional ByVal colores As Byte = 210)
            Dim bmp2 = bmp
            Dim bmp22 = bmp
            'Reducimos los colores de la imagen
            Dim bmp3 As Bitmap
            bmp3 = Me.reducircolores(bmp2, colores)

            'Creamos los contornos
            Dim bmp4 As Bitmap
            bmp4 = Me.contornos(bmp22, contorno, 70, 150, 29)


            'Obtenemos valores de la imagen con los colores reducidos
            Dim Niveles2(,) As System.Drawing.Color
            Niveles2 = nivel(bmp3)

            'Obtenemos valores de la imagen con los contornos
            Dim Niveles(,) As System.Drawing.Color
            Niveles = nivel(bmp4)

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Pintando al óleo" 'Actualizar el estado

            Dim bmpSalida As New Bitmap(bmp.Width, bmp.Height)
            Dim Rojo, Verde, Azul As Byte 'Declaramos tres variables que almacenarán los colores
            Dim Rojo2, Verde2, Azul2 As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)     'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).B
                    Rojo2 = Niveles2(i, j).R
                    Verde2 = Niveles2(i, j).G
                    Azul2 = Niveles2(i, j).B
                    If Rojo = 0 And Verde = 0 And Azul = 0 Then 'Si el píxel es negro
                        bmpSalida.SetPixel(i, j, Color.FromArgb(Rojo, Verde, Azul)) 'Dejamos el contorno
                    Else
                        bmpSalida.SetPixel(i, j, Color.FromArgb(Rojo2, Verde2, Azul2)) 'Pintamos con la imagen con colores reducidos
                    End If
                    porcentaje(0) = ((i * 100) / (bmp3.Width)) 'Actualizamos el estado
                Next
            Next
            guardarImagen(bmpSalida, "Efecto óleo") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmpSalida) 'generamos el evento
            Return bmpSalida

        End Function
        Private Function calculaValorInterpolado(ByVal valorniveles(,) As System.Drawing.Color, ByVal anchoAlto() As Integer, ByVal numeroPixeles As Integer)
            Dim rojo, verde, azul, alfa As Integer
            Dim contador = 0
            For mi = anchoAlto(0) To anchoAlto(0) + numeroPixeles
                For mj = anchoAlto(1) To anchoAlto(1) + numeroPixeles
                    rojo += valorniveles(mi, mj).R
                    verde += valorniveles(mi, mj).G
                    azul += valorniveles(mi, mj).B
                    alfa += valorniveles(mi, mj).A
                    contador += 1
                Next
            Next
            rojo = rojo / contador
            verde = verde / contador
            azul = azul / contador
            alfa = alfa / contador
            Dim nivelesCalculado(3) As Byte
            nivelesCalculado(0) = CInt(rojo)
            nivelesCalculado(1) = CInt(verde)
            nivelesCalculado(2) = CInt(azul)
            nivelesCalculado(3) = CInt(alfa)
            Return nivelesCalculado
        End Function

        ''' <summary>
        ''' Función que crea un efecto rojizo (depende los tonos de la imagen) sobre la imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EfectoMarte(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EfectoMarte(ByVal bmp As Bitmap) As Bitmap
            Dim bmp2 = bmp
            Dim objetoMasc As New Mascaras
            'Aplicamos efecto repujado
            Dim mascara = objetoMasc.Repujado
            Dim bmp3 = Me.mascara3x3Grises(bmp2, mascara)

            Dim bmpSalida As Bitmap
            bmpSalida = Me.OperacionResta(bmp2, bmp3)

            guardarImagen(bmpSalida, "Efecto marte") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmpSalida) 'generamos el evento
            Return bmpSalida

        End Function

        ''' <summary>
        ''' Función que crea un efecto de imagen sobreexpuesta.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EfectoAntigSobreex(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EfectoAntigSobreex(ByVal bmp As Bitmap) As Bitmap
            Dim bmp2 = bmp
            Dim objetoMasc As New Mascaras
            'Aplicamos efecto repujado
            Dim mascara = objetoMasc.Repujado
            Dim bmp3 = Me.mascara3x3Grises(bmp2, mascara)

            Dim bmpSalida As Bitmap
            bmpSalida = Me.OperacionSuma(bmp2, bmp3)

            guardarImagen(bmpSalida, "Efecto antiguo y sobreexpuesto") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmpSalida) 'generamos el evento
            Return bmpSalida

        End Function

        ''' <summary>
        ''' Función que crea un efecto marino (depende los tonos de la imagen) sobre la imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EfectoMarino(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EfectoMarino(ByVal bmp As Bitmap) As Bitmap
            Dim bmp2 = bmp
            Dim objetoMasc As New Mascaras
            'Aplicamos efecto repujado
            Dim mascara = objetoMasc.Repujado
            Dim bmp3 = Me.mascara3x3Grises(bmp2, mascara)

            Dim bmpSalida As Bitmap
            bmpSalida = Me.OperacionResta(bmp3, bmp2)

            guardarImagen(bmpSalida, "Efecto marino") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmpSalida) 'generamos el evento
            Return bmpSalida

        End Function

        ''' <summary>
        ''' Función que crea un efecto que oscure las zonas más negras de la imagen, y en fotografías retrato, aumentan los rasgos de los rostros.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EfectoAumentarRasgos(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EfectoAumentarRasgos(ByVal bmp As Bitmap) As Bitmap
            Dim bmp2 = bmp
            Dim objetoMasc As New Mascaras
            'Aplicamos efecto repujado
            Dim mascara = objetoMasc.PrewittHoriz
            Dim bmp3 = Me.mascara3x3Grises(bmp2, mascara, 0, 3)
            mascara = objetoMasc.PrewittVert
            Dim bmp4 = Me.mascara3x3Grises(bmp2, mascara, 0, 3)
            Dim PrewiUnido = Me.OperacionUnir(bmp3, bmp4)
            Dim bmpSalida As Bitmap
            bmpSalida = Me.OperacionResta(bmp2, PrewiUnido)

            guardarImagen(bmpSalida, "Efecto aumentar rasgos") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmpSalida) 'generamos el evento
            Return bmpSalida

        End Function

        ''' <summary>
        ''' Función que crea un efecto que aclara las zonas más negras de la imagen, y en fotografías retrato, disminuye los rasgos de los rostros.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EfectoDisminuirRasgos(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EfectoDisminuirRasgos(ByVal bmp As Bitmap) As Bitmap
            Dim bmp2 = bmp
            Dim objetoMasc As New Mascaras
            'Aplicamos efecto repujado
            Dim mascara = objetoMasc.PrewittHoriz
            Dim bmp3 = Me.mascara3x3Grises(bmp2, mascara, 0, 3)
            mascara = objetoMasc.PrewittVert
            Dim bmp4 = Me.mascara3x3Grises(bmp2, mascara, 0, 3)
            Dim PrewiUnido = Me.OperacionUnir(bmp3, bmp4)
            Dim bmpSalida As Bitmap
            bmpSalida = Me.OperacionSuma(bmp2, PrewiUnido)

            guardarImagen(bmpSalida, "Efecto disminuir rasgos") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmpSalida) 'generamos el evento
            Return bmpSalida

        End Function

        ''' <summary>
        ''' Función que crea un efecto de detección de contornos con sombras.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EfectoContornoSombreado(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EfectoContornoSombreado(ByVal bmp As Bitmap) As Bitmap
            Dim bmp2 = bmp
            Dim objetoMasc As New Mascaras
            'Aplicamos efecto repujado
            Dim mascara = objetoMasc.Repujado
            Dim bmp3 = Me.mascara3x3RGB(bmp2, mascara)

            Dim bmpSalida As Bitmap
            bmpSalida = Me.OperacionResta(bmp2, bmp3)

            guardarImagen(bmpSalida, "Efecto contorno sombreado 1") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmpSalida) 'generamos el evento
            Return bmpSalida

        End Function

        ''' <summary>
        ''' Función que crea un efecto de detección de contornos con sombras.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EfectoContornoSombreado2(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EfectoContornoSombreado2(ByVal bmp As Bitmap) As Bitmap
            Dim bmp2 = bmp
            Dim objetoMasc As New Mascaras
            'Aplicamos efecto repujado
            Dim mascara = objetoMasc.Repujado
            Dim bmp3 = Me.mascara3x3RGB(bmp2, mascara)

            Dim bmpSalida As Bitmap
            bmpSalida = Me.OperacionResta(bmp3, bmp2)

            guardarImagen(bmpSalida, "Efecto contorno sombreado 2") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmpSalida) 'generamos el evento
            Return bmpSalida

        End Function

        ''' <summary>
        ''' Función que crea aumenta el valor de los píxeles creando un efecto de luz rojiza.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.EfectoAumentarLuz(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function EfectoAumentarLuz(ByVal bmp As Bitmap) As Bitmap
            Dim bmp2 = bmp
            Dim bmp3 = Me.EscalaGrises(bmp2)
            Dim bmp4 = Me.OperacionResta(bmp2, bmp3)
            Dim bmpSalida As Bitmap
            bmpSalida = Me.OperacionSuma(bmp2, bmp4)

            guardarImagen(bmpSalida, "Efecto aumentar luz") 'Guardamos la imagen para poder hacer retroceso
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmpSalida) 'generamos el evento
            Return bmpSalida

        End Function

        ''' <summary>
        ''' Función que crear un marco a partir de cine a partir de 6 imágenes.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.cine(bmp1,bmp2,bmp3,bmp4,bmp5, eleccionCombo)</code></example>
        ''' </summary>
        ''' <param name="bmpP0">Imagen que formará parte del marco. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmpP1">Imagen que formará parte del marco. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmpP2">Imagen que formará parte del marco. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmpP3">Imagen que formará parte del marco. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmpP4">Imagen que formará parte del marco. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmpP5">Imagen que formará parte del marco. Se debe pasar en formato Bitmap.</param>
        ''' <param name="tamañoImagen">Indica el tamaño de salida del marco. Si se le pasa un 0, el tamaño será pequeño, un 1 mediano y 2 grande.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Esta función fue recuperar de otro proyecto anterior y no está bien optimizada, podría demorarse varios segundos.</remarks>
        Public Function cine(ByVal bmpP0 As Bitmap, ByVal bmpP1 As Bitmap, ByVal bmpP2 As Bitmap, ByVal bmpP3 As Bitmap, ByVal bmpP4 As Bitmap, ByVal bmpP5 As Bitmap, Optional tamañoImagen As Integer = 2)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Creando efecto marco de cine" 'Actualizar el estado

            Dim PicColor1, PicColor2, PicColor3, PicColor4, PicColor5, PicColor6, PicColor7 As Color
            Dim r, g, b, a As Integer
            Dim x As Integer
            Dim y As Integer
            Dim bmp3 As New Bitmap(bmpP0)
            Dim bmp2 As New Bitmap(My.Resources.CineFotos)

            Dim imgtemp1 As New Bitmap(bmpP0)
            Dim imgtemp2 As New Bitmap(bmp2)


            Dim imgtemp4 As New Bitmap(bmp2)

            Dim imgtemp5 As New Bitmap(bmpP0, 690, 520)
            Dim imgtemp6 As New Bitmap(bmpP1, 690, 520)
            Dim imgtemp7 As New Bitmap(bmpP2, 690, 520)
            Dim imgtemp8 As New Bitmap(bmpP3, 690, 520)
            Dim imgtemp9 As New Bitmap(bmpP4, 690, 520)
            Dim imgtemp10 As New Bitmap(bmpP5, 690, 520)


            For x = 0 To bmp2.Width - 1
                For y = 0 To bmp2.Height - 1
                    PicColor1 = imgtemp4.GetPixel(x, y)

                    If (x > 68 And x < 754) And (y > 342 And y < 857) Then
                        PicColor2 = imgtemp5.GetPixel(x - 68, y - 342)
                        r = PicColor2.R
                        g = PicColor2.G
                        b = PicColor2.B
                        a = PicColor2.A

                    Else
                        r = PicColor1.R
                        g = PicColor1.G
                        b = PicColor1.B
                        a = PicColor1.A
                    End If

                    If (x > 819 And x < 1505) And (y > 342 And y < 857) Then
                        PicColor3 = imgtemp6.GetPixel(x - 819, y - 342)
                        r = PicColor3.R
                        g = PicColor3.G
                        b = PicColor3.B
                        a = PicColor3.A
                    End If

                    If (x > 1570 And x < 2257) And (y > 342 And y < 857) Then
                        PicColor4 = imgtemp7.GetPixel(x - 1570, y - 342)
                        r = PicColor4.R
                        g = PicColor4.G
                        b = PicColor4.B
                        a = PicColor4.A
                    End If


                    If (x > 2320 And x < 3008) And (y > 342 And y < 857) Then
                        PicColor5 = imgtemp8.GetPixel(x - 2320, y - 342)
                        r = PicColor5.R
                        g = PicColor5.G
                        b = PicColor5.B
                        a = PicColor5.A
                    End If

                    If (x > 3071 And x < 3760) And (y > 342 And y < 857) Then
                        PicColor6 = imgtemp9.GetPixel(x - 3071, y - 342)
                        r = PicColor6.R
                        g = PicColor6.G
                        b = PicColor6.B
                        a = PicColor6.A
                    End If

                    If (x > 3821) And (y > 342 And y < 861) Then
                        PicColor7 = imgtemp10.GetPixel(x - 3821, y - 342)
                        r = PicColor7.R
                        g = PicColor7.G
                        b = PicColor7.B
                        a = PicColor7.A

                    End If
                    imgtemp2.SetPixel(x, y, Color.FromArgb(a, r, g, b))

                Next
                porcentaje(0) = ((x * 100) / imgtemp2.Width) 'Actualizamos el estado

            Next

            If tamañoImagen = 0 Then imgtemp2 = Me.Redimensionar(imgtemp2, New Rectangle(New Point(0, 0), New Size(imgtemp2.Width / 4, imgtemp2.Height / 4)), Drawing2D.InterpolationMode.HighQualityBilinear)
            If tamañoImagen = 1 Then imgtemp2 = Me.Redimensionar(imgtemp2, New Rectangle(New Point(0, 0), New Size(imgtemp2.Width / 2, imgtemp2.Height / 2)))

            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(imgtemp2, "Efecto marco de cine") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(imgtemp2) 'generamos el evento

            Return imgtemp2

        End Function

        ''' <summary>
        ''' Función que crear un marco rodeando a una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.marco(bmp,1)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que formará parte del marco. Se debe pasar en formato Bitmap.</param>
        ''' <param name="numeroMarco">Indica el marco que se va a seleccionar. Los valores posibles son, 0, 1, 2 o 3.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Public Function marco(ByVal bmp As Bitmap, Optional numeroMarco As Integer = 0)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Creando efecto marco" 'Actualizar el estado

            Dim PicColor1, PicColor2 As Color
            Dim r, g, b, a As Integer
            Dim x As Integer
            Dim y As Integer
            Dim x1, x2, y1, y2 As Integer
            Dim bmp3 As New Bitmap(bmp, 1127, 908)
            Dim bmp2 As New Bitmap(My.Resources.marco)
            If numeroMarco = 0 Then
                x1 = 185 : x2 = 1308
                y1 = 185 : y2 = 1090
                Dim bmp3aux As New Bitmap(bmp, 1127, 908)
                bmp3 = bmp3aux
                bmp2 = (My.Resources.marco)
            End If

            If numeroMarco = 1 Then
                x1 = 54 : x2 = 1295
                y1 = 94 : y2 = 700
                Dim bmp3aux As New Bitmap(bmp, 1241, 606)
                bmp3 = bmp3aux
                bmp2 = (My.Resources.negativoMarco)
            End If

            If numeroMarco = 2 Then
                x1 = 51 : x2 = 281
                y1 = 51 : y2 = 281
                Dim bmp3aux As New Bitmap(bmp, 230, 230)
                bmp3 = bmp3aux
                bmp2 = (My.Resources.MarcoOndul)
            End If

            If numeroMarco = 3 Then
                x1 = 285 : x2 = 2795
                y1 = 285 : y2 = 2194
                Dim bmp3aux As New Bitmap(bmp, 2510, 1909)
                bmp3 = bmp3aux
                bmp2 = (My.Resources.marcoNegro)
            End If


            Dim imgtemp2 As New Bitmap(bmp2.Width, bmp2.Height)

            For x = 0 To bmp2.Width - 1
                For y = 0 To bmp2.Height - 1
                    PicColor1 = bmp2.GetPixel(x, y)

                    If (x > x1 And x < x2) And (y > y1 And y < y2) Then
                        PicColor2 = bmp3.GetPixel(x - x1, y - y1)
                        r = PicColor2.R
                        g = PicColor2.G
                        b = PicColor2.B
                        a = PicColor2.A

                    Else
                        r = PicColor1.R
                        g = PicColor1.G
                        b = PicColor1.B
                        a = PicColor1.A
                    End If
                    imgtemp2.SetPixel(x, y, Color.FromArgb(a, r, g, b))
                Next
                porcentaje(0) = ((x * 100) / imgtemp2.Width) 'Actualizamos el estado
            Next

            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(imgtemp2, "Efecto marco") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(imgtemp2) 'generamos el evento

            Return imgtemp2
        End Function

#End Region

        'Suma/Resta/multip/división/Unión/AND/OR/XOR de DOS imágenes. Devuelve un bitmap con el alto/ancho del bitmap más pequeño
#Region "operaciones con dos imágenes"
        ''' <summary>
        ''' Función que hace que dos imágenes de diferentes tamaño tengan el mismo tamaño. Busca y aplica el alto/ancho más pequeño del par de imágenes.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>bmpCuadrado=me.CuadrarImagenes(bmp,bmp2)</code></example>
        ''' </summary>
        ''' <param name="bmp1">Imagen 1 a cuadrar.</param>
        ''' <param name="bmp2">Imagen 2 a cuadrar.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Private Function CuadrarImagenes(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap)
            Dim alto, ancho As Integer
            If bmp1.Height >= bmp2.Height Then alto = bmp2.Height Else alto = bmp1.Height
            If bmp1.Width >= bmp2.Width Then ancho = bmp2.Width Else ancho = bmp1.Width
            Dim bmpAjustado1 As New Bitmap(bmp1, ancho, alto)
            Dim bmpAjustado2 As New Bitmap(bmp2, ancho, alto)
            Dim bmpRetorno(1) As Bitmap
            bmpRetorno(0) = bmpAjustado1
            bmpRetorno(1) = bmpAjustado2
            Return bmpRetorno
        End Function

        ''' <summary>
        ''' Función que suma los píxeles de dos imágenes. La suma se hace canal a canal (ARGB).
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.OperacionSuma(bmp1,bmp2,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp1">Imagen 1 de la suma. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmp2">Imagen 2 de la suma. Se debe pasar en formato Bitmap.</param>
        ''' <param name="omitirAlfa">Si esta opción es TRUE, el canal alfa se omitirá al hacer la suma, en caso contrario, el canal alfa se tratará de forma normal.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Si las imágenes son de diferentes tamaños, la imagen de salida tendrá el ancho y alto menor del par de imágenes.</remarks>
        Public Function OperacionSuma(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap, Optional ByVal omitirAlfa As Boolean = True)
            Dim bmpAux1 = bmp1
            Dim bmpAux2 = bmp2
            Dim bmpCuadrados = CuadrarImagenes(bmpAux1, bmpAux2)

            bmpAux1 = bmpCuadrados(0)
            bmpAux2 = bmpCuadrados(1)

            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmpAux1)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles2 = nivel(bmpAux2)

            Dim bmp3 As New Bitmap(bmpAux1.Width, bmpAux1.Height)

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Sumando imágenes" 'Actualizar el estado
            Dim Rojoaux, Verdeaux, Azulaux, alfaaux As Integer
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R    'Sumamos los valores
                    Rojoaux += Niveles2(i, j).R
                    Verdeaux = Niveles(i, j).G
                    Verdeaux += +Niveles2(i, j).G
                    Azulaux = Niveles(i, j).B
                    Azulaux += Niveles2(i, j).B
                    alfaaux = Niveles(i, j).A
                    alfaaux += Niveles2(i, j).A
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeaux > 255 Then Verdeaux = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If alfaaux > 255 Then alfaaux = 255
                    Rojo = CInt(Rojoaux)
                    Verde = CInt(Verdeaux)
                    Azul = CInt(Azulaux)
                    alfa = CInt(alfaaux)
                    If omitirAlfa = True Then
                        alfa = 255
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Suma de imágenes") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function


        ''' <summary>
        ''' Función que resta los píxeles de dos imágenes. La resta se hace canal a canal (ARGB).
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.OperacionResta(bmp1,bmp2,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp1">Imagen 1 de la resta. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmp2">Imagen 2 de la resta. Se debe pasar en formato Bitmap.</param>
        ''' <param name="omitirAlfa">Si esta opción es TRUE, el canal alfa se omitirá al hacer la resta, en caso contrario, el canal alfa se tratará de forma normal.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Si las imágenes son de diferentes tamaños, la imagen de salida tendrá el ancho y alto menor del par de imágenes.</remarks>
        Public Function OperacionResta(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap, Optional ByVal omitirAlfa As Boolean = True)
            Dim bmpAux1 = bmp1
            Dim bmpAux2 = bmp2
            Dim bmpCuadrados = CuadrarImagenes(bmpAux1, bmpAux2) 'Cuadramos las imágenes

            bmpAux1 = bmpCuadrados(0)
            bmpAux2 = bmpCuadrados(1)
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmpAux1)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles2 = nivel(bmpAux2)

            Dim bmp3 As New Bitmap(bmpAux1.Width, bmpAux1.Height)

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Restando imágenes" 'Actualizar el estado
            Dim Rojoaux, Verdeaux, Azulaux, alfaaux As Integer
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R    'Restando los valores
                    Rojoaux -= Niveles2(i, j).R
                    Verdeaux = Niveles(i, j).G
                    Verdeaux -= +Niveles2(i, j).G
                    Azulaux = Niveles(i, j).B
                    Azulaux -= Niveles2(i, j).B
                    alfaaux = Niveles(i, j).A
                    alfaaux -= Niveles2(i, j).A
                    If Rojoaux < 0 Then Rojoaux = 0
                    If Verdeaux < 0 Then Verdeaux = 0
                    If Azulaux < 0 Then Azulaux = 0
                    If alfaaux < 0 Then alfaaux = 0
                    Rojo = CInt(Rojoaux)
                    Verde = CInt(Verdeaux)
                    Azul = CInt(Azulaux)
                    alfa = CInt(alfaaux)
                    If omitirAlfa = True Then
                        alfa = 255
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Resta de imágenes") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que multiplica los píxeles de dos imágenes. La multiplicación se hace canal a canal (ARGB).
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.OperacionMultiplicacion(bmp1,bmp2,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp1">Imagen 1 de la multiplicación. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmp2">Imagen 2 de la multiplicación. Se debe pasar en formato Bitmap.</param>
        ''' <param name="omitirAlfa">Si esta opción es TRUE, el canal alfa se omitirá al hacer la multiplicación, en caso contrario, el canal alfa se tratará de forma normal.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Si las imágenes son de diferentes tamaños, la imagen de salida tendrá el ancho y alto menor del par de imágenes.</remarks>
        Public Function OperacionMultiplicacion(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap, Optional ByVal omitirAlfa As Boolean = True)
            Dim bmpAux1 = bmp1
            Dim bmpAux2 = bmp2
            Dim bmpCuadrados = CuadrarImagenes(bmpAux1, bmpAux2) 'Cuadramos las imágenes

            bmpAux1 = bmpCuadrados(0)
            bmpAux2 = bmpCuadrados(1)
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmpAux1)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles2 = nivel(bmpAux2)

            Dim bmp3 As New Bitmap(bmpAux1.Width, bmpAux1.Height)

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Multiplicando imágenes" 'Actualizar el estado
            Dim Rojoaux, Verdeaux, Azulaux, alfaaux As Integer
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R    'ultiplicando los valores
                    Rojoaux *= Niveles2(i, j).R
                    Verdeaux = Niveles(i, j).G
                    Verdeaux *= +Niveles2(i, j).G
                    Azulaux = Niveles(i, j).B
                    Azulaux *= Niveles2(i, j).B
                    alfaaux = Niveles(i, j).A
                    alfaaux *= Niveles2(i, j).A
                    If Rojoaux < 0 Then Rojoaux = 0
                    If Verdeaux < 0 Then Verdeaux = 0
                    If Azulaux < 0 Then Azulaux = 0
                    If alfaaux < 0 Then alfaaux = 0
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeaux > 255 Then Verdeaux = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If alfaaux > 255 Then alfaaux = 255
                    Rojo = CInt(Rojoaux)
                    Verde = CInt(Verdeaux)
                    Azul = CInt(Azulaux)
                    alfa = CInt(alfaaux)
                    If omitirAlfa = True Then
                        alfa = 255
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Multiplicación de imágenes") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que divide los píxeles de dos imágenes. La división se hace canal a canal (ARGB).
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.OperacionDivisión(bmp1,bmp2,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp1">Imagen 1 de la división (dividendo). Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmp2">Imagen 2 de la división (divisor). Se debe pasar en formato Bitmap.</param>
        ''' <param name="omitirAlfa">Si esta opción es TRUE, el canal alfa se omitirá al hacer la división, en caso contrario, el canal alfa se tratará de forma normal.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks><para>Si las imágenes son de diferentes tamaños, la imagen de salida tendrá el ancho y alto menor del par de imágenes.</para>
        ''' <para>En caso de que algún valor en el dividendo sea 0, automáticamente pasará a ser 1.</para></remarks>
        Public Function OperacionDivision(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap, Optional ByVal omitirAlfa As Boolean = True)
            Dim bmpAux1 = bmp1
            Dim bmpAux2 = bmp2
            Dim bmpCuadrados = CuadrarImagenes(bmpAux1, bmpAux2) 'Cuadramos las imágenes

            bmpAux1 = bmpCuadrados(0)
            bmpAux2 = bmpCuadrados(1)
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmpAux1)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles2 = nivel(bmpAux2)

            Dim bmp3 As New Bitmap(bmpAux1.Width, bmpAux1.Height)

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Dividiendo imágenes" 'Actualizar el estado
            Dim Rojoaux, Verdeaux, Azulaux, alfaaux As Integer
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            Dim nivelAux As Double = 0
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R    'Dividimos los valores
                    If Niveles2(i, j).R = 0 Then nivelAux = 1 Else nivelAux = Niveles2(i, j).R 'Controlamos que no haya 0 en el denominador
                    Rojoaux /= nivelAux
                    Verdeaux = Niveles(i, j).G
                    If Niveles2(i, j).G = 0 Then nivelAux = 1 Else nivelAux = Niveles2(i, j).G
                    Verdeaux /= nivelAux
                    Azulaux = Niveles(i, j).B
                    If Niveles2(i, j).B = 0 Then nivelAux = 1 Else nivelAux = Niveles2(i, j).B
                    Azulaux /= nivelAux
                    alfaaux = Niveles(i, j).A
                    If Niveles2(i, j).A = 0 Then nivelAux = 1 Else nivelAux = Niveles2(i, j).A
                    alfaaux /= nivelAux
                    If Rojoaux < 0 Then Rojoaux = 0
                    If Verdeaux < 0 Then Verdeaux = 0
                    If Azulaux < 0 Then Azulaux = 0
                    If alfaaux < 0 Then alfaaux = 0
                    Rojo = CInt(Rojoaux)
                    Verde = CInt(Verdeaux)
                    Azul = CInt(Azulaux)
                    alfa = CInt(alfaaux)
                    If omitirAlfa = True Then
                        alfa = 255
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "División de imágenes") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que une los píxeles de dos imágenes. La unión se hace canal a canal (ARGB). Se trata de sumar cada canal de cada píxel y dividirlo entre 2.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.OperacionUnir(bmp1,bmp2,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp1">Imagen 1 de la unión. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmp2">Imagen 2 de la unión. Se debe pasar en formato Bitmap.</param>
        ''' <param name="omitirAlfa">Si esta opción es TRUE, el canal alfa se omitirá al hacer la división, en caso contrario, el canal alfa se tratará de forma normal.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Si las imágenes son de diferentes tamaños, la imagen de salida tendrá el ancho y alto menor del par de imágenes.</remarks>
        Public Function OperacionUnir(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap, Optional ByVal omitirAlfa As Boolean = True)
            Dim bmpAux1 = bmp1
            Dim bmpAux2 = bmp2
            Dim bmpCuadrados = CuadrarImagenes(bmpAux1, bmpAux2) 'Cuadramos las imágenes

            bmpAux1 = bmpCuadrados(0)
            bmpAux2 = bmpCuadrados(1)
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmpAux1)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles2 = nivel(bmpAux2)

            Dim bmp3 As New Bitmap(bmpAux1.Width, bmpAux1.Height)

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Uniendo imágenes" 'Actualizar el estado
            Dim Rojoaux, Verdeaux, Azulaux, alfaaux As Integer
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R    'Uniendo los valores
                    Rojoaux = (Rojoaux + Niveles2(i, j).R) / 2

                    Verdeaux = Niveles(i, j).G
                    Verdeaux = (Verdeaux + Niveles2(i, j).G) / 2
                    Azulaux = Niveles(i, j).B
                    Azulaux = (Azulaux + Niveles2(i, j).B) / 2
                    alfaaux = Niveles(i, j).A
                    alfaaux = (alfaaux + Niveles2(i, j).A) / 2

                    Rojo = CInt(Rojoaux)
                    Verde = CInt(Verdeaux)
                    Azul = CInt(Azulaux)
                    alfa = CInt(alfaaux)
                    If omitirAlfa = True Then
                        alfa = 255
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "Unión de imágenes") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que hace la operación AND de dos imágenes. El operador AND se hace canal a canal (ARGB).
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.OperacionAND(bmp1,bmp2,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp1">Imagen 1 del operador AND. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmp2">Imagen 2 del operador AND. Se debe pasar en formato Bitmap.</param>
        ''' <param name="omitirAlfa">Si esta opción es TRUE, el canal alfa se omitirá al hacer la división, en caso contrario, el canal alfa se tratará de forma normal.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks><para>Si las imágenes son de diferentes tamaños, la imagen de salida tendrá el ancho y alto menor del par de imágenes.</para>
        ''' <para>Este tipo de operaciones lógicas, tienen más sentido con imágenes binarias.</para></remarks>
        Public Function OperacionAND(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap, Optional ByVal omitirAlfa As Boolean = True)
            Dim bmpAux1 = bmp1
            Dim bmpAux2 = bmp2
            Dim bmpCuadrados = CuadrarImagenes(bmpAux1, bmpAux2)

            bmpAux1 = bmpCuadrados(0)
            bmpAux2 = bmpCuadrados(1)

            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmpAux1)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles2 = nivel(bmpAux2)

            Dim bmp3 As New Bitmap(bmpAux1.Width, bmpAux1.Height)

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Realizando operación AND en imágenes" 'Actualizar el estado
            Dim Rojoaux, Verdeaux, Azulaux, alfaaux As Integer
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R And Niveles2(i, j).R  'Sumamos los valores
                    Verdeaux = Niveles(i, j).G And Niveles2(i, j).G
                    Azulaux = Niveles(i, j).B And Niveles2(i, j).B
                    alfaaux = Niveles(i, j).A And Niveles2(i, j).A

                    Rojo = CInt(Rojoaux)
                    Verde = CInt(Verdeaux)
                    Azul = CInt(Azulaux)
                    alfa = CInt(alfaaux)
                    If omitirAlfa = True Then
                        alfa = 255
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "AND de imágenes") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que hace la operación OR de dos imágenes. El operador OR se hace canal a canal (ARGB).
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.OperacionOR(bmp1,bmp2,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp1">Imagen 1 del operador OR. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmp2">Imagen 2 del operador OR. Se debe pasar en formato Bitmap.</param>
        ''' <param name="omitirAlfa">Si esta opción es TRUE, el canal alfa se omitirá al hacer la división, en caso contrario, el canal alfa se tratará de forma normal.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks><para>Si las imágenes son de diferentes tamaños, la imagen de salida tendrá el ancho y alto menor del par de imágenes.</para>
        ''' <para>Este tipo de operaciones lógicas, tienen más sentido con imágenes binarias.</para></remarks>
        Public Function OperacionOR(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap, Optional ByVal omitirAlfa As Boolean = True)
            Dim bmpAux1 = bmp1
            Dim bmpAux2 = bmp2
            Dim bmpCuadrados = CuadrarImagenes(bmpAux1, bmpAux2)

            bmpAux1 = bmpCuadrados(0)
            bmpAux2 = bmpCuadrados(1)

            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmpAux1)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles2 = nivel(bmpAux2)

            Dim bmp3 As New Bitmap(bmpAux1.Width, bmpAux1.Height)

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Realizando operación OR en imágenes" 'Actualizar el estado
            Dim Rojoaux, Verdeaux, Azulaux, alfaaux As Integer
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R Or Niveles2(i, j).R  'Sumamos los valores
                    Verdeaux = Niveles(i, j).G Or Niveles2(i, j).G
                    Azulaux = Niveles(i, j).B Or Niveles2(i, j).B
                    alfaaux = Niveles(i, j).A Or Niveles2(i, j).A

                    Rojo = CInt(Rojoaux)
                    Verde = CInt(Verdeaux)
                    Azul = CInt(Azulaux)
                    alfa = CInt(alfaaux)
                    If omitirAlfa = True Then
                        alfa = 255
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "OR de imágenes") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que hace la operación XOR de dos imágenes. El operador XOR se hace canal a canal (ARGB).
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.OperacionXOR(bmp1,bmp2,TRUE)</code></example>
        ''' </summary>
        ''' <param name="bmp1">Imagen 1 del operador XOR. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmp2">Imagen 2 del operador XOR. Se debe pasar en formato Bitmap.</param>
        ''' <param name="omitirAlfa">Si esta opción es TRUE, el canal alfa se omitirá al hacer la división, en caso contrario, el canal alfa se tratará de forma normal.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks><para>Si las imágenes son de diferentes tamaños, la imagen de salida tendrá el ancho y alto menor del par de imágenes.</para>
        ''' <para>Este tipo de operaciones lógicas, tienen más sentido con imágenes binarias.</para></remarks>
        Public Function OperacionXOR(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap, Optional ByVal omitirAlfa As Boolean = True)
            Dim bmpAux1 = bmp1
            Dim bmpAux2 = bmp2
            Dim bmpCuadrados = CuadrarImagenes(bmpAux1, bmpAux2)

            bmpAux1 = bmpCuadrados(0)
            bmpAux2 = bmpCuadrados(1)

            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmpAux1)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles2 = nivel(bmpAux2)

            Dim bmp3 As New Bitmap(bmpAux1.Width, bmpAux1.Height)

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Realizando operación XOR en imágenes" 'Actualizar el estado
            Dim Rojoaux, Verdeaux, Azulaux, alfaaux As Integer
            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R Xor Niveles2(i, j).R  'Sumamos los valores
                    Verdeaux = Niveles(i, j).G Xor Niveles2(i, j).G
                    Azulaux = Niveles(i, j).B Xor Niveles2(i, j).B
                    alfaaux = Niveles(i, j).A Xor Niveles2(i, j).A

                    Rojo = CInt(Rojoaux)
                    Verde = CInt(Verdeaux)
                    Azul = CInt(Azulaux)
                    alfa = CInt(alfaaux)
                    If omitirAlfa = True Then
                        alfa = 255
                    End If
                    bmp3.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores modificados
                Next
                porcentaje(0) = ((i * 100) / bmp3.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp3) 'generamos el evento
            guardarImagen(bmp3, "XOR de imágenes") 'Guardamos la imagen para poder hacer retroceso
            Return bmp3
        End Function

        ''' <summary>
        ''' Función que crea una imagen anaglifo a partir de dos imágenes muy cercanas al mismo objeto.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.OperacionAnaglifo(bmp1,bmp2)</code></example>
        ''' </summary>
        ''' <param name="bmpIzquierda">Imagen izquierda del par de imágenes que formarán el anaglifo. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmpDerecha">Imagen derecha del par de imágenes que formarán el anaglifo. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Si las imágenes son de diferentes tamaños, la imagen de salida tendrá el ancho y alto menor del par de imágenes.</remarks>
        Public Function Anaglifo(ByVal bmpIzquierda As Bitmap, ByVal bmpDerecha As Bitmap)
            Dim bmp3 = bmpDerecha
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp3) 'Obtenemos valores

            Dim bmpAnag1 As New Bitmap(bmp3.Width, bmp3.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Creando anaglifo. Etapa 1/3" 'Actualizar el estado

            'Dejamos pasar sólo el rojo
            Dim Rojo, Verde, Azul, alfa As Byte
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R
                    alfa = Niveles(i, j).A
                    bmpAnag1.SetPixel(i, j, Color.FromArgb(alfa, Rojo, 0, 0)) 'Asignamos a bmp los colores
                Next
                porcentaje(0) = ((i * 100) / bmpAnag1.Width) 'Actualizamos el estado
            Next


            Dim bmp4 = bmpIzquierda
            Dim bmpAnag2 As New Bitmap(bmp4.Width, bmp4.Height)
            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles2 = nivel(bmp4) 'Obtenemos valores

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Creando anaglifo. Etapa 2/3" 'Actualizar el estado

            'Dejamos pasar sólo verde y azul
            For i = 0 To Niveles2.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles2.GetUpperBound(1)
                    Verde = Niveles2(i, j).G
                    Azul = Niveles2(i, j).B
                    alfa = Niveles2(i, j).A
                    bmpAnag2.SetPixel(i, j, Color.FromArgb(alfa, 0, Verde, Azul)) 'Asignamos a bmp los colores
                Next
                porcentaje(0) = ((i * 100) / bmpAnag2.Width) 'Actualizamos el estado
            Next

            Dim bmpSalida As Bitmap
            bmpSalida = Me.OperacionSuma(bmpAnag1, bmpAnag2)
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmpSalida, "Anaglifo") 'Guardamos la imagen para poder hacer retroceso
            RaiseEvent actualizaBMP(bmpSalida) 'generamos el evento
            Return bmpSalida
        End Function
#End Region

        'Comparador de imágenes a partir de dos bitmaps
#Region "comparar dos imágenes"
        ''' <summary>
        ''' Función que compara dos imágenes píxel a píxel y canal a canal.
        ''' <example>La llamada a la función, asignando los resultados a un arraylist, sería:
        ''' <code>Dim resultadoComparacion As New ArrayList(Me.CompararDosImagenes(bmp1, bmp2))</code></example>
        ''' </summary>
        ''' <param name="bmp1">Imagen 1 a comparar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmp2">Imagen 2 a comparar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un arraylist con la información de la comparación. En las 4 primeras posiciones devuelve el porcentaje de aciertos del canal rojo, verde, azul y alfa, respectivamente. En 
        ''' las siguientes 4 posiciones, devuelve matrices de dos dimensiones (ancho y alto más pequeño del par de imágenes), con todas las comparaciones píxel a píxel (las diferencias en valor absoluto
        ''' entre los píxeles de la primera imagen con respecto a la segunda). Esta cuatro matrices son del canal rojo, verde, azul y alfa, respectivamente.</returns>
        ''' <remarks>Si las imágenes son de diferentes tamaños, la imagen de salida tendrá el ancho y alto menor del par de imágenes.</remarks>
        Public Function CompararDosImagenes(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap) As ArrayList

            'Clonamos los bitmaps originales
            Dim bmp1clon = bmp1.Clone(New Rectangle(0, 0, bmp1.Width, bmp1.Height), Imaging.PixelFormat.DontCare)
            Dim bmp2clon = bmp2.Clone(New Rectangle(0, 0, bmp2.Width, bmp2.Height), Imaging.PixelFormat.DontCare)
            'Cuadramos los bitmaps y los asignamos a bmp4 y bmp5
            Dim bmp3 = Me.CuadrarImagenes(bmp1clon, bmp2clon)
            Dim bmp4 As Bitmap = bmp3(0)
            Dim bmp5 As Bitmap = bmp3(1)


            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Comparación de imágenes (local)" 'Actualizar el estado

            'Este primer bloque, guarda los niveles digitales de la imagen en la variable Niveles
            Dim i, j As Long
            Dim Niveles1(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            ReDim Niveles1(bmp4.Width - 1, bmp4.Height - 1)
            ReDim Niveles2(bmp4.Width - 1, bmp4.Height - 1)
            Dim rojo1, rojo2, verde1, verde2, azul1, azul2, grises1, grises2 As Integer 'Almacenamos temporalmente los colores

            Dim Arojo, Averde, Aazul, Agrises As Integer 'Variable con las diferencias

            Dim restaAcRojo, restaAcAzul, restaAcVerde, restaAcGrises As ULong 'Resta acumulada

            'Matrices con diferencias
            Dim matrizGrises(bmp4.Width - 1, bmp4.Height - 1) As Integer
            Dim matrizRojo(bmp4.Width - 1, bmp4.Height - 1) As Integer
            Dim matrizAzul(bmp4.Width - 1, bmp4.Height - 1) As Integer
            Dim matrizVerde(bmp4.Width - 1, bmp4.Height - 1) As Integer

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Comparando imágenes" 'Actualizar el estado
            For i = 0 To bmp4.Width - 1 'Recorremos la matriz a lo ancho
                For j = 0 To bmp4.Height - 1 'Recorremos la matriz a lo largo
                    Niveles1(i, j) = bmp4.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                    Niveles2(i, j) = bmp5.GetPixel(i, j)

                    'Almacenamos los rojos
                    rojo1 = Niveles1(i, j).R
                    rojo2 = Niveles2(i, j).R
                    'Almacenamos los verde
                    verde1 = Niveles1(i, j).G
                    verde2 = Niveles2(i, j).G
                    'Almacenamos los azul
                    azul1 = Niveles1(i, j).B
                    azul2 = Niveles2(i, j).B

                    'Calculamos la media (grises)
                    grises1 = CInt(rojo1 + verde1 + azul1) / 3
                    grises2 = CInt(rojo2 + verde2 + azul2) / 3

                    'Calculamoms las diferencias
                    Arojo = Math.Abs(rojo1 - rojo2)
                    Averde = Math.Abs(verde1 - verde2)
                    Aazul = Math.Abs(azul1 - azul2)
                    Agrises = Math.Abs(grises1 - grises2)

                    'Calculamos el total de diferencias (acumuladas)
                    restaAcRojo += Arojo
                    restaAcVerde += Averde
                    restaAcAzul += Aazul
                    restaAcGrises += Agrises

                    'Creamos las matrices con las diferencias
                    matrizRojo(i, j) = Arojo
                    matrizVerde(i, j) = Averde
                    matrizAzul(i, j) = Aazul
                    matrizGrises(i, j) = Agrises

                    porcentaje(0) = ((i * 100) / bmp4.Width) 'Actualizamos el estado
                Next
            Next

            Dim resultado As New ArrayList 'Creamos un arraylist con los resultados que serán devueltos

            Dim maximo = ((bmp4.Width - 1) * (bmp4.Height - 1)) * 255

            'Porcentaje de aciertos para cada canal y escala de grises
            resultado.Add(CInt(100 - (restaAcRojo * 100) / maximo))
            resultado.Add(CInt(100 - (restaAcVerde * 100) / maximo))
            resultado.Add(CInt(100 - (restaAcAzul * 100) / maximo))
            resultado.Add(CInt(100 - (restaAcGrises * 100) / maximo))

            'Matriz con las diferencias
            resultado.Add(matrizRojo)
            resultado.Add(matrizVerde)
            resultado.Add(matrizAzul)
            resultado.Add(matrizGrises)

            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            'RaiseEvent actualizaBMP(bmp1) 'generamos el evento
            'guardarImagen(bmp1, "Comparador de imágenes (local)") 'Guardamos la imagen para poder hacer retroceso
            Return resultado
        End Function

        ''' <summary>
        ''' Función que comparar dos imágenes teniendo en cuenta sus vecinos más próximos y las diferencias entre ellos (los incrementos en sus valores).
        ''' <example>La llamada a la función, asignando los resultados a un arraylist, sería:
        ''' <code>Dim resultadoComparacion As New ArrayList(Me.CompararDosImagenes(bmp1, bmp2))</code></example>
        ''' </summary>
        ''' <param name="bmp1">Imagen 1 a comparar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="bmp2">Imagen 2 a comparar. Se debe pasar en formato Bitmap.</param>
        ''' <param name="DistanciaVecinos">Variable que indica el número de vecinos que se van a utilizar para la comparación. Para saber el lado del kernel evaluado, se debe calcular (DistanciaVecinos*2+1).</param>
        ''' <param name="PasoAlto">Si esta opción es TRUE, previamente a comparar las imágenes se aplica un filtro de paso alto para acentuar las diferencias en la imagen. En caso de ser FALSE, no se aplica filtro previo.</param>
        ''' <param name="Grafica">Esta variable si toma valor 0, no modificará los valores de la comparación. En caso de ser 1, se aplicará a la matriz con los resultados la función math.E^x, y si es 2 se aplicará x^raiz(2).</param>
        ''' <param name="ComparadorRapido">Si esta opción es TRUE, se reducirá el tamaño de la imagen para hacer una comparación rápida pero menos exahustiva. En caso de ser FALSE, se compararán las imágenes con su tamaño original.</param>
        ''' <returns>Devuelve un arraylist con la información de la comparación. En las 4 primeras posiciones devuelve el porcentaje de aciertos del canal rojo, verde, azul y alfa, respectivamente. En 
        ''' las siguientes 4 posiciones, devuelve matrices de dos dimensiones (ancho y alto más pequeño del par de imágenes), con todas las comparaciones píxel a píxel (las diferencias en valor absoluto
        ''' entre los píxeles de la primera imagen con respecto a la segunda). Esta cuatro matrices son del canal rojo, verde, azul y alfa, respectivamente.</returns>
        ''' <remarks>Si las imágenes son de diferentes tamaños, la imagen de salida tendrá el ancho y alto menor del par de imágenes.</remarks>
        Public Function CompararDosImagenesVecinos(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap, Optional ByVal DistanciaVecinos As Integer = 1, Optional ByVal PasoAlto As Boolean = False, Optional ByVal Grafica As Integer = 0, Optional ComparadorRapido As Boolean = False) As ArrayList
            'Clonamos los bitmaps originales
            Dim bmp1clon = bmp1.Clone(New Rectangle(0, 0, bmp1.Width, bmp1.Height), Imaging.PixelFormat.DontCare)
            Dim bmp2clon = bmp2.Clone(New Rectangle(0, 0, bmp2.Width, bmp2.Height), Imaging.PixelFormat.DontCare)
            'Cuadramos los bitmaps y los asignamos a bmp4 y bmp5
            Dim bmp4, bmp5 As Bitmap
            If ComparadorRapido = True Then
                bmp4 = New Bitmap(bmp1clon, 50, 50)
                bmp5 = New Bitmap(bmp2clon, 50, 50)
            Else
                Dim bmp3 = Me.CuadrarImagenes(bmp1clon, bmp2clon)
                bmp4 = bmp3(0)
                bmp5 = bmp3(1)
            End If



            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Comparación de imágenes (vecindad)" 'Actualizar el estado

            'Pasamos por filtro paso alto si PasoAlto=true
            Dim bmp6, bmp7 As Bitmap
            If PasoAlto = True Then
                Dim objmascara As New TratamientoImagenes.Mascaras
                Dim mascara = objmascara.HIGH1a
                bmp6 = Me.mascara3x3RGB(bmp4, mascara)
                bmp7 = Me.mascara3x3RGB(bmp5, mascara)
            Else
                bmp6 = bmp4
                bmp7 = bmp5
            End If


            Dim Niveles1(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles1 = Me.nivel(bmp6)
            Niveles2 = Me.nivel(bmp7)
            Dim matrizRojoResta(bmp6.Width - (DistanciaVecinos * 2) - 1, bmp6.Height - (DistanciaVecinos * 2) - 1) As Integer
            Dim matrizVerdeResta(bmp6.Width - (DistanciaVecinos * 2 - 1), bmp6.Height - (DistanciaVecinos * 2 - 1)) As Integer
            Dim matrizAzulResta(bmp6.Width - (DistanciaVecinos * 2 - 1), bmp6.Height - (DistanciaVecinos * 2 - 1)) As Integer
            Dim matrizGrisResta(bmp6.Width - (DistanciaVecinos * 2 - 1), bmp6.Height - (DistanciaVecinos * 2 - 1)) As Integer

            Dim valorCentro1r, valorCentro2r, valorCentro1g, valorCentro2g, valorCentro1b, valorCentro2b, valorCentro1gris, valorCentro2gris As Integer
            Dim valorMovido1r, valorMovido2r, valorMovido1g, valorMovido2g, valorMovido1b, valorMovido2b, valorMovido1gris, valorMovido2gris As Integer
            Dim acumuladoR, acumuladoG, acumuladoB, acumuladoGris As Integer
            Dim total As Integer = (DistanciaVecinos + DistanciaVecinos + 1) * (DistanciaVecinos + DistanciaVecinos + 1) - 1 'Restamos uno porque el píxel central también lo usamos y siempre será 0

            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Comparando imágenes" 'Actualizar el estado

            For i = DistanciaVecinos To Niveles1.GetUpperBound(0) - DistanciaVecinos 'Reducimos y excluimos la distancia al vecino
                For j = DistanciaVecinos To Niveles1.GetUpperBound(1) - DistanciaVecinos
                    valorCentro1r = Niveles1(i, j).R
                    valorCentro2r = Niveles2(i, j).R
                    valorCentro1g = Niveles1(i, j).G
                    valorCentro2g = Niveles2(i, j).G
                    valorCentro1b = Niveles1(i, j).B
                    valorCentro2b = Niveles2(i, j).B
                    valorCentro1gris = CInt(valorCentro1r + valorCentro1g + valorCentro1b) / 3
                    valorCentro2gris = CInt(valorCentro2r + valorCentro2g + valorCentro2b) / 3
                    acumuladoR = 0
                    acumuladoG = 0
                    acumuladoB = 0
                    acumuladoGris = 0
                    For mi = -DistanciaVecinos To DistanciaVecinos
                        For mj = -DistanciaVecinos To DistanciaVecinos
                            'Calculamos los tres canales y grises
                            valorMovido1r = Niveles1(i + mi, j + mj).R
                            valorMovido2r = Niveles2(i + mi, j + mj).R
                            acumuladoR += Math.Abs((Math.Abs(valorCentro1r - valorMovido1r)) - (Math.Abs(valorCentro2r - valorMovido2r)))

                            valorMovido1g = Niveles1(i + mi, j + mj).G
                            valorMovido2g = Niveles2(i + mi, j + mj).G
                            acumuladoG += Math.Abs((Math.Abs(valorCentro1g - valorMovido1g)) - (Math.Abs(valorCentro2g - valorMovido2g)))

                            valorMovido1b = Niveles1(i + mi, j + mj).B
                            valorMovido2b = Niveles2(i + mi, j + mj).B
                            acumuladoB += Math.Abs((Math.Abs(valorCentro1b - valorMovido1b)) - (Math.Abs(valorCentro2b - valorMovido2b)))

                            valorMovido1gris = CInt(valorMovido1r + valorMovido1g + valorMovido1b) / 3
                            valorMovido2gris = CInt(valorMovido2r + valorMovido2g + valorMovido2b) / 3
                            acumuladoGris += Math.Abs((Math.Abs(valorCentro1gris - valorMovido1gris)) - (Math.Abs(valorCentro2gris - valorMovido2gris)))
                        Next
                    Next

                    'Calculamos el porcentaje de acierto (Si Grafica=0 normal, Si Grafica=1 Math.E ^x, Si Grafica=2 x^raiz(2))
                    If Grafica = 0 Then 'CÁlculo normal

                        matrizRojoResta(i - DistanciaVecinos, j - DistanciaVecinos) = acumuladoR / total
                        matrizVerdeResta(i - DistanciaVecinos, j - DistanciaVecinos) = acumuladoG / total
                        matrizAzulResta(i - DistanciaVecinos, j - DistanciaVecinos) = acumuladoB / total
                        matrizGrisResta(i - DistanciaVecinos, j - DistanciaVecinos) = acumuladoGris / total

                    ElseIf Grafica = 1 Then 'Calculo math.E^x

                        If (acumuladoR / total < Math.Log(255)) Then 'Logaritmo neperiano de 255
                            matrizRojoResta(i - DistanciaVecinos, j - DistanciaVecinos) = Math.E ^ (acumuladoR / total)
                        Else
                            matrizRojoResta(i - DistanciaVecinos, j - DistanciaVecinos) = 255
                        End If

                        If (acumuladoG / total < Math.Log(255)) Then 'Logaritmo neperiano de 255
                            matrizVerdeResta(i - DistanciaVecinos, j - DistanciaVecinos) = Math.E ^ (acumuladoG / total)
                        Else
                            matrizVerdeResta(i - DistanciaVecinos, j - DistanciaVecinos) = 255
                        End If

                        If (acumuladoB / total < Math.Log(255)) Then 'Logaritmo neperiano de 255
                            matrizAzulResta(i - DistanciaVecinos, j - DistanciaVecinos) = Math.E ^ (acumuladoB / total)
                        Else
                            matrizAzulResta(i - DistanciaVecinos, j - DistanciaVecinos) = 255
                        End If

                        If (acumuladoGris / total < Math.Log(255)) Then 'Logaritmo neperiano de 255
                            matrizGrisResta(i - DistanciaVecinos, j - DistanciaVecinos) = Math.E ^ (acumuladoGris / total)
                        Else
                            matrizGrisResta(i - DistanciaVecinos, j - DistanciaVecinos) = 255
                        End If

                    ElseIf Grafica = 2 Then 'Cálculo para x^raiz(2)

                        If (acumuladoR / total < 50.3133) Then 'Valor igual a 255
                            matrizRojoResta(i - DistanciaVecinos, j - DistanciaVecinos) = (acumuladoR / total) ^ Math.Sqrt(2)
                        Else
                            matrizRojoResta(i - DistanciaVecinos, j - DistanciaVecinos) = 255
                        End If

                        If (acumuladoG / total < 50.3133) Then 'Valor igual a 255
                            matrizVerdeResta(i - DistanciaVecinos, j - DistanciaVecinos) = (acumuladoG / total) ^ Math.Sqrt(2)
                        Else
                            matrizVerdeResta(i - DistanciaVecinos, j - DistanciaVecinos) = 255
                        End If

                        If (acumuladoB / total < 50.3133) Then 'Valor igual a 255
                            matrizAzulResta(i - DistanciaVecinos, j - DistanciaVecinos) = (acumuladoB / total) ^ Math.Sqrt(2)
                        Else
                            matrizAzulResta(i - DistanciaVecinos, j - DistanciaVecinos) = 255
                        End If

                        If (acumuladoGris / total < 50.3133) Then 'Valor igual a 255
                            matrizGrisResta(i - DistanciaVecinos, j - DistanciaVecinos) = (acumuladoGris / total) ^ Math.Sqrt(2)
                        Else
                            matrizGrisResta(i - DistanciaVecinos, j - DistanciaVecinos) = 255
                        End If

                    End If
                    porcentaje(0) = ((i * 100) / bmp6.Width) 'Actualizamos el estado
                Next
            Next

            Dim cuentaAcumuladaR, cuentaAcumuladaG, cuentaAcumuladaB, cuentaAcumuladaGris As ULong
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Calculando incrementos" 'Actualizar el estado
            For i = 0 To matrizRojoResta.GetUpperBound(0)
                For j = 0 To matrizRojoResta.GetUpperBound(1)
                    cuentaAcumuladaR += matrizRojoResta(i, j)
                    cuentaAcumuladaG += matrizVerdeResta(i, j)
                    cuentaAcumuladaB += matrizAzulResta(i, j)
                    cuentaAcumuladaGris += matrizGrisResta(i, j)
                    porcentaje(0) = ((i * 100) / matrizRojoResta.GetUpperBound(0)) 'Actualizamos el estado
                Next
            Next
            Dim maximo = ((matrizRojoResta.GetUpperBound(0) - 1) * (matrizRojoResta.GetUpperBound(1) - 1) * 255)
            Dim resultado As New ArrayList
            resultado.Add(CInt(100 - (cuentaAcumuladaR * 100) / maximo))
            resultado.Add(CInt(100 - (cuentaAcumuladaG * 100) / maximo))
            resultado.Add(CInt(100 - (cuentaAcumuladaB * 100) / maximo))
            resultado.Add(CInt(100 - (cuentaAcumuladaGris * 100) / maximo))
            resultado.Add(matrizRojoResta)
            resultado.Add(matrizVerdeResta)
            resultado.Add(matrizAzulResta)
            resultado.Add(matrizGrisResta)

            porcentaje(0) = 100 'Actualizamos el estado
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            'RaiseEvent actualizaBMP(bmp1) 'generamos el evento
            'guardarImagen(bmp1, "Comparador de imágenes (local)") 'Guardamos la imagen para poder hacer retroceso
            Return resultado
        End Function
#End Region

#End Region


        'Contiene el conjunto de funciones para abrir imágenes desde archivo, URL, BING, FB, etc
#Region "FuncionesAbrirGuardar"

        'Función para crear tapiz con alto/ancho y color
        ''' <summary>
        ''' Función que crea un rectángulo con el color y las dimensiones especificadas.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.tapiz(500,500,color.Red,"Nueva imagen como tapiz")</code></example>
        ''' </summary>
        ''' <param name="ancho">Variable que indica el ancho del tapiz de salida.</param>
        ''' <param name="alto">Variable que indica el alto del tapiz de salida.</param>
        ''' <param name="color">Variable que indica el color del tapiz de salida.</param>
        ''' <param name="nombreTapiz">Esta variable no tiene efecto en esta función.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Para almacenar el nombre del tapiz (nombreTapiz) y que luego sea su nombre de cara a su aplicación, debe llamar al procedimiento actualizarNombreTapiz y pasarle como parámetros el nombre, ancho y alto.</remarks>
        Function tapiz(ByVal ancho As Integer, ByVal alto As Integer, ByVal color As Color, Optional ByVal nombreTapiz As String = "Nuevo tapiz")
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Creando tapiz" 'Actualizar el estado
            Dim bmp As New Bitmap(ancho, alto)

            For i = 0 To ancho - 1  'Recorremos la matriz
                For j = 0 To alto - 1
                    bmp.SetPixel(i, j, color) 'Asignamos a bmp los colores 
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            guardarImagen(bmp, "Imagen original como tapiz") 'Almacenamos info y bitmap
            contadorImagenes = imagenesGuardadas.Count 'Lo asignamos como el contador actual
            RaiseEvent actualizaBMP(bmp) 'Generamos evento
            'Guardamos la imagen original
            ImagenOriginalGuardada = bmp
            imagenOriginalInfo = "Imagen original como tapiz"

            Return bmp
        End Function

        'Procedimiento auxiliar para gestionar evento de nombre tapiz (sirve para evitar problemas al llamar desde un proceso en segundo plano
        ''' <summary>
        ''' Para ver su utilidad, revisar las observaciones (remarks) de la función tapiz en la documentación.
        ''' </summary>
        ''' <param name="nombre">Nombre del tapiz creado.</param>
        ''' <param name="ancho">Ancho del tapiz creado.</param>
        ''' <param name="alto">Alto del tapiz creado.</param>
        ''' <remarks>Véase las observaciones (remarks) de la función tapiz.</remarks>
        Sub actualizarNombreTapiz(ByVal nombre As String, ByVal ancho As Integer, ByVal alto As Integer)
            RaiseEvent actualizaNombreImagen({nombre, ancho, alto, "Imagen tapiz"}) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
        End Sub

        'Se abre imagen desde archivo
        ''' <summary>
        ''' Función que muestra un cuadro de diálogo para seleccionar una imagen desde el pc y devuelve la imagen en formato bitmap.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así (haciendo una comprobación de que la imagen no está vacía):
        ''' <code>Dim bmpArchivo as bitmap=objetoTratamiento.abrirImagen(1)
        ''' If bmpArchivo IsNot Nothing Then Picturebox1.image=bmpArchivo</code></example>
        ''' </summary>
        ''' <param name="filtrado">Esta variable indica el filtro seleccionado para el formato de las imágenes que se mostrarán en el cuadro de diálogo. 1 (todos los formatos compatibles),
        ''' 2 (BMP), 3 (GIF), 4 (JPG/JPEG), 5 (PNG), 6 (TIFF), 7 (todos los archivos). (</param>
        ''' <returns>Devuelve un bitmap.</returns>
        ''' <remarks>En caso de que haya algún fallo a la hora de seleccionar la imagen, la función devolverá un bitmap vacío.</remarks>
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
                        RaiseEvent actualizaNombreImagen({nombreImagen(.FileName), abrirImagen.Width, abrirImagen.Height, "Desde archivo"}) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta

                        'Guardamos la imagen original
                        ImagenOriginalGuardada = abrirImagen
                        imagenOriginalInfo = "Imagen original desde archivo"

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

        'Se abre imagen desde una ruta loca
        ''' <summary>
        ''' Función que abre una imagen desde una ruta del pc.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así (haciendo una comprobación de que la imagen no está vacía):
        ''' <code>Dim bmpWeb as bitmap=objetoTratamiento.abririmgRuta("C:/Users/Usuario/Desktop/imagen.png")
        ''' If bmpArchivo IsNot Nothing Then Picturebox1.image=bmpWeb</code></example>
        ''' </summary>
        ''' <param name="ruta">Indica la ruta donde se encuentra la imagen en el pc (local).</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>En caso de que haya algún fallo a la hora buscar la imagen, la función devolverá un bitmap vacío.</remarks>
        Function abririmgRuta(ByVal ruta As String) As Bitmap
            Try
                Dim bmpRuta As New Bitmap(ruta)
                guardarImagen(bmpRuta, "Imagen original desde ruta") 'Almacenamos info y bitmap
                contadorImagenes = imagenesGuardadas.Count 'Lo asignamos como el contador actual
                RaiseEvent actualizaBMP(bmpRuta) 'Generamos evento
                RaiseEvent actualizaNombreImagen({nombreImagen(ruta), bmpRuta.Width, bmpRuta.Height, "Desde ruta"}) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta

                'Guardamos la imagen original
                ImagenOriginalGuardada = bmpRuta
                imagenOriginalInfo = "Imagen original desde ruta"
                Return bmpRuta
            Catch
                Dim bmp As Bitmap
                bmp = Nothing
                Return bmp
            End Try
        End Function

        'Se abre imagen desde una URL
        ''' <summary>
        ''' Función que abre una imagen desde una URL de internet.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así (haciendo una comprobación de que la imagen no está vacía):
        ''' <code>Dim bmpWeb as bitmap=objetoTratamiento.abririmgRuta("www.imagenes.com/imagenEjemplo)
        ''' If bmpArchivo IsNot Nothing Then Picturebox1.image=bmpWeb</code></example>
        ''' </summary>
        ''' <param name="enlace">Indica el recurso web donde se halla la imagen.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>En caso de que haya algún fallo a la hora buscar/descargar la imagen, la función devolverá un bitmap vacío.</remarks>
        Function abrirRecursoWeb(ByVal enlace As String) As Bitmap
            Try
                Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(enlace)
                Dim response As System.Net.WebResponse = request.GetResponse()
                Dim responseStream As System.IO.Stream = response.GetResponseStream()
                Dim bmp As New Bitmap(responseStream)
                guardarImagen(bmp, "Imagen original como recurso web") 'Almacenamos info y bitmap
                contadorImagenes = imagenesGuardadas.Count 'Lo asignamos como el contador actual
                RaiseEvent actualizaBMP(bmp) 'Generamos evento
                RaiseEvent actualizaNombreImagen({nombreRecursoWeb(enlace), bmp.Width, bmp.Height, "Recurso web"}) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta

                'Guardamos la imagen original
                ImagenOriginalGuardada = bmp
                imagenOriginalInfo = "Imagen original como recurso web"
                Return bmp
            Catch
                Dim bmp As Bitmap
                bmp = Nothing
                Return bmp
            End Try
        End Function

        'Se abre imagen desde archivo arrastrándola al picturebox principal
        ''' <summary>
        ''' Función que abre una imagen desde una ruta del pc y la guarda como si se hubiese arrastrado a la aplicación. Esta función sólo debe utilizarse para imágenes que se abren arrastrándolas a la aplicación.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así (haciendo una comprobación de que la imagen no está vacía):
        ''' <code>Dim bmpWeb as bitmap=objetoTratamiento.abririmgRuta("C:/Users/Usuario/Desktop/imagen.png")
        ''' If bmpArchivo IsNot Nothing Then Picturebox1.image=bmpWeb</code></example>
        ''' </summary>
        ''' <param name="ruta">Indica la ruta donde se encuentra la imagen en el pc (local).</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>En caso de que haya algún fallo a la hora buscar la imagen, la función devolverá un bitmap vacío.</remarks>
        Function abrirDragDrop(ByVal ruta As String) As Bitmap
            Try
                Dim bmp As New Bitmap(ruta)
                abrirDragDrop = bmp
                guardarImagen(abrirDragDrop, "Imagen original arrastrada") 'Almacenamos info y bitmap
                contadorImagenes = imagenesGuardadas.Count 'Lo asignamos como el contador actual

                'Guardamos la imagen original
                ImagenOriginalGuardada = abrirDragDrop
                imagenOriginalInfo = "Imagen original arrastrada"

                RaiseEvent actualizaBMP(abrirDragDrop) 'Generamos evento
                RaiseEvent actualizaNombreImagen({nombreRecursoWeb(ruta), abrirDragDrop.Width, abrirDragDrop.Height, "Desde archivo (arrastrada)"}) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
                Return abrirDragDrop
            Catch
                Dim bmp As Bitmap
                bmp = Nothing
                Return bmp
            End Try
        End Function

        'Funciones auxiliares para procesos en segundo plano problemáticos
        ''' <summary>
        ''' Función que abre una imagen sin dejar rastro. No guarda información en las listas de hacer/rehacer, en imágenes originales, etc.
        ''' </summary>
        ''' <param name="enlace">Indica el recurso web donde se halla la imagen.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>En caso de que haya algún fallo a la hora buscar/descargar la imagen, la función devolverá un bitmap vacío.</remarks>
        Function abrirRecursoWebAxu(ByVal enlace As String) As Bitmap 'Duplicamos esta función porque hay un error con la opción de abrir desde archivo
            Try
                Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(enlace)
                Dim response As System.Net.WebResponse = request.GetResponse()
                Dim responseStream As System.IO.Stream = response.GetResponseStream()
                Dim bmp As New Bitmap(responseStream)
                Return bmp
            Catch
                Dim bmp As Bitmap
                bmp = Nothing
                Return bmp
            End Try
        End Function

        ''' <summary>
        ''' Función que guarda una imagen como recurso web. No es recomendable utilizar esta función.
        ''' </summary>
        ''' <param name="bmp">Imagen en formato bitmap.</param>
        ''' <param name="direccionURL">Dirección URL del recurso web.</param>
        ''' <remarks></remarks>
        Public Sub InfoImagenPrecarga(ByVal bmp As Bitmap, ByVal direccionURL As String) 'Con esto guardamos los datos si el usuario ha activado precarga
            Try
                guardarImagen(bmp, "Imagen original como recurso web") 'Almacenamos info y bitmap
                contadorImagenes = imagenesGuardadas.Count 'Lo asignamos como el contador actual
                'Guardamos la imagen original
                ImagenOriginalGuardada = bmp
                imagenOriginalInfo = "Imagen original como recurso web"
                RaiseEvent actualizaBMP(bmp) 'Generamos evento
                RaiseEvent actualizaNombreImagen({nombreRecursoWeb(direccionURL), bmp.Width, bmp.Height, "Recurso web"}) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
            Catch
            End Try
        End Sub

        'Hace que la imagen enviada se guarde
        ''' <summary>
        ''' Función que no debe utilizarse
        ''' </summary>
        ''' <param name="bmp">Imagen que se ha extraido de Cloud y se quiere guardar como imagen original.</param>
        ''' <returns>Devuelve un bitmap (la imagen enviada).</returns>
        ''' <remarks></remarks>
        Public Function OriginalApoloCloud(ByVal bmp As Bitmap) As Bitmap
            guardarImagen(bmp, "Imagen original desde Apolo Cloud") 'Almacenamos info y bitmap
            contadorImagenes = imagenesGuardadas.Count 'Lo asignamos como el contador actual
            RaiseEvent actualizaBMP(bmp) 'Generamos evento
            RaiseEvent actualizaNombreImagen({"Imagen Apolo Cloud", bmp.Width, bmp.Height, "Recurso web (Apolo Cloud)"}) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
            'Guardamos la imagen original
            ImagenOriginalGuardada = bmp
            imagenOriginalInfo = "Imagen original desde Apolo Cloud"
            Return bmp
        End Function

        'Función para guardar imagen
        ''' <summary>
        ''' Procedimiento que guarda una imagen que se le pase como bitmap, mostrando un cuadro de diálogo al usuario de dónde guardarla en su pc.
        ''' <example>La llamada al procedimiento sería así:
        ''' <code>objetoTratamiento.guardarcomo(bmp,4)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen que se quiere guardar. Debe pasarse en formato bitmap.</param>
        ''' <param name="filtrado">Tipo de formato que aparecerá como predeterminado a la hora de guardar la imagen. 1 (BMP), 2 (GIF), 3 (JPG/JPEG), 4 (PNG), 5 (TIFF).</param>
        ''' <remarks>La imagen guardada se almacena como primera imagen del hacer/deshacer.</remarks>
        Sub guardarcomo(ByVal bmp As Bitmap, Optional ByVal filtrado As Integer = 4)
            Dim salvar As New SaveFileDialog
            With salvar
                .Filter = "Ficheros BMP|*.bmp" & _
                          "|Ficheros GIF|*.gif" & _
                          "|Ficheros JPG o JPEG|*.jpg;*.jpeg" & _
                          "|Ficheros PNG|*.png" & _
                          "|Ficheros TIFF|*.tif"
                .FilterIndex = filtrado
                .FileName = "Nueva_imagen"
                If (.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                    If salvar.FileName <> "" Then
                        Dim fs As System.IO.FileStream = CType(salvar.OpenFile, System.IO.FileStream)
                        Dim formato As String = ""
                        Select Case salvar.FilterIndex
                            Case 1
                                bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp)
                                formato = "bmp"
                            Case 2
                                bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Gif)
                                formato = "gif"
                            Case 3
                                bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg)
                                formato = "jpeg"
                            Case 4
                                bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Png)
                                formato = "png"
                            Case 5
                                bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Tiff)
                                formato = "tiff"
                        End Select
                        'Guardamos la imagen para que quede en el registro (aunque se duplique)
                        porcentaje(0) = 100 'Actualizamos el estado
                        porcentaje(1) = "Finalizado" 'Actualizamos el estado
                        guardarImagen(bmp, "Imagen guardada como " & formato) 'Guardamos la imagen para poder hacer retroceso
                        RaiseEvent actualizaBMP(bmp) 'generamos el evento
                        fs.Close()
                    End If
                End If
            End With
        End Sub

#End Region

        'Contiene funciones no relacionadas directamente con el tratamiento de imágenes.
        'Obtener nombre de una imagen a partir de su ruta// Nombre de un recurso web a partir de su URL
        'Obtener URL de imágenes desde BING imágenes.
#Region "Funciones extra"
        ''' <summary>
        ''' Función que devuelve el nombre de una imagen a partir de una ruta local del pc.
        ''' <example>La llamada a la función sería así:
        ''' <code>Dim ImagenEnPC as string="C:\Users\Usuario\Desktop\ImagenEjemplo.jpg"
        ''' Dim nombreDeImagen as string=objetoTratamiento.nombreImagen(ImagenEnPC)</code></example>
        ''' </summary>
        ''' <param name="rutaImagen">Variable que indica la ruta de donde se quiere extraer el nombre.</param>
        ''' <returns>Devuelve un string con el nombre de la imagen.</returns>
        Function nombreImagen(ByVal rutaImagen As String) As String
            Dim auxiliar, auxiliar2, nombre_imagen As String
            Dim nombre_imagen2() As String
            auxiliar = rutaImagen
            nombre_imagen2 = Split(auxiliar, "\")
            auxiliar2 = UBound(nombre_imagen2)
            nombre_imagen = nombre_imagen2(auxiliar2)
            Return nombre_imagen
        End Function 'Nombre desde archivo

        ''' <summary>
        ''' Función que devuelve el nombre de una imagen a partir de una URL.
        ''' <example>La llamada a la función sería así:
        ''' <code>Dim ImagenWEB as string="imagenes.com/imagenPrueba.jpg"
        ''' Dim nombreDeImagen as string=objetoTratamiento.nombreRecursoWeb(ImagenWEB)</code></example>
        ''' </summary>
        ''' <param name="url">Variable que indica la ruta de donde se quiere extraer el nombre.</param>
        ''' <returns>Devuelve un string con el nombre de la imagen.</returns>
        Function nombreRecursoWeb(ByVal url As String)
            Dim auxiliar, auxiliar2, nombre_imagen As String
            Dim nombre_imagen2() As String
            auxiliar = url
            nombre_imagen2 = Split(auxiliar, "/")
            auxiliar2 = UBound(nombre_imagen2)
            nombre_imagen = nombre_imagen2(auxiliar2)
            Return nombre_imagen
        End Function 'Nombre desde URL

        'Se buscan imágenes en Bing
        ''' <summary>
        ''' Función que devuelve URLs con imágenes encontradas en BING imágenes.
        ''' <example>Para hacer una petición a la función, sería así:</example>
        ''' <code>Dim matrizConURL=objetoTratamiento.BuscarImagenesBing("Gatos",50,"Large",FALSE)</code>
        ''' </summary>
        ''' <param name="texto">Indica el texto con el que se buscarán imágenes.</param>
        ''' <param name="numeroImagenes">Indica el número de imágenes que será devuelto. Un máximo de 50.</param>
        ''' <param name="tamaño">Indica el tamaño de las imágenes. Si el valor es una cadena vacía se buscarán todas los tamaños. Se puede seleccionar "Small", "Medium", "Large" (sin las comillas).</param>
        ''' <param name="Precarga">Si esta opción es TRUE, el primer resultado será la imagen original, en caso de ser false, el primer resultado será una miniatura.</param>
        ''' <returns>Devuelve una matriz bidimensional en la que, por cada fila, los dos primeros resultados corresponden a una imagen y su miniatura. Por ejemplo, el resultado 0,0 será la miniatura, el 0,1 la imagen original, y el 1,0 será la miniatura de otro resultado y el 1,1 la original.</returns>
        ''' <remarks>Está limitado a 5000 peticiones por mes.</remarks>
        Public Function BuscarImagenesBing(ByVal texto As String, Optional ByVal numeroImagenes As Integer = 10, Optional ByVal tamaño As String = "", Optional Precarga As Boolean = False) As String(,)
            Dim datosVuelta(50, 50) As String
            Try
                If tamaño <> "" Then
                    tamaño = "&ImageFilters=%27Size%3a" & tamaño & "%27"
                End If
                Dim ClaveCuenta As String = "URndltgY4xIFqjJOhdozXaBilXhSo76PIW7YWedDkJI="
                Dim raizServicio As String = "https://api.datamarket.azure.com/Bing/Search/"
                Dim imageQueryRoot As String = raizServicio + "Image?"
                Dim imageQuery As String = imageQueryRoot + "Query=%27" + texto + "%27" + "&$top=" & numeroImagenes & tamaño

                'XmlDocument que usaremos para leer los resultados
                Dim document As XmlDocument = New XmlDocument()

                'Las siguientes cuatro líneas configurar el XmlDocument para utilizar las credenciales 
                Dim accountCredential As New NetworkCredential(ClaveCuenta, ClaveCuenta)
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


        'Duplicamos la función (histogramaAcumulado, histogramaAcumuladoH) para que no haya fallos con los hilos)
        ''' <summary>
        ''' Función que devuelve el histograma acumulado de una imagen.
        ''' <example>Para utilizar la función, se procedería así:
        ''' <code>Dim matrizAcumulada=objetoTratamiento.histogramaAcumulado(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen de la cual se quiere obtener el histograma acumulado. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve una matriz de dimensiones (255,2) siendo 255,0 para el rojo, 255,1 para el verde y 255,2 para el azul. Dentro de cada canal
        ''' los 256 valores indica el valor acumulado, por ejemplo, para el 0. Es decir, por ejemplo, el valor (150,1) informa del número de veces que se
        ''' repite el valor 150 en el canal verde.</returns>
        Public Function histogramaAcumulado(ByVal bmp As Bitmap) As ULong(,)
            Dim bmp2 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim NivelesHist(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Dim i, j As Long
            ReDim NivelesHist(bmp2.Width - 1, bmp2.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            For i = 0 To bmp2.Width - 1 'Recorremos la matriz a lo ancho
                For j = 0 To bmp2.Height - 1 'Recorremos la matriz a lo largo
                    NivelesHist(i, j) = bmp2.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                Next
            Next

            Dim Rojo, Verde, Azul As Byte 'Declaramos tres variables que almacenarán los colores
            Dim matrizAcumulada(255, 2) As ULong
            For i = 0 To NivelesHist.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To NivelesHist.GetUpperBound(1)
                    Rojo = NivelesHist(i, j).R 'ASignamos el color
                    Verde = NivelesHist(i, j).G
                    Azul = NivelesHist(i, j).B
                    'ACumulamos los valores
                    matrizAcumulada(Rojo, 0) += 1
                    matrizAcumulada(Verde, 1) += 1
                    matrizAcumulada(Azul, 2) += 1
                Next
            Next
            Return matrizAcumulada
        End Function

        ''' <summary>
        ''' Función que devuelve el histograma acumulado de una imagen.
        ''' <example>Para utilizar la función, se procedería así:
        ''' <code>Dim matrizAcumulada=objetoTratamiento.histogramaAcumulado(bmp)</code></example>
        ''' </summary>
        ''' <param name="bmp">Imagen de la cual se quiere obtener el histograma acumulado. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve una matriz de dimensiones (255,2) siendo 255,0 para el rojo, 255,1 para el verde y 255,2 para el azul. Dentro de cada canal
        ''' los 256 valores indica el valor acumulado, por ejemplo, para el 0. Es decir, por ejemplo, el valor (150,1) informa del número de veces que se
        ''' repite el valor 150 en el canal verde.</returns>
        Public Function histogramaAcumuladoH(ByVal bmp As Bitmap)
            Dim bmp2 = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)
            Dim NivelesHist(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Dim i, j As Long
            ReDim NivelesHist(bmp2.Width - 1, bmp2.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            For i = 0 To bmp2.Width - 1 'Recorremos la matriz a lo ancho
                For j = 0 To bmp2.Height - 1 'Recorremos la matriz a lo largo
                    NivelesHist(i, j) = bmp2.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                Next
            Next

            Dim Rojo, Verde, Azul, Alfa As Integer 'Declaramos tres variables que almacenarán los colores (como integer, para que no se desborde al calcular la escala de grises)
            Dim grises As Integer
            Dim matrizAcumulada(255, 4) As ULong
            For i = 0 To NivelesHist.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To NivelesHist.GetUpperBound(1)
                    Rojo = NivelesHist(i, j).R 'ASignamos el color
                    Verde = NivelesHist(i, j).G
                    Azul = NivelesHist(i, j).B
                    Alfa = NivelesHist(i, j).A
                    grises = CInt((Rojo + Verde + Azul) / 3)
                    'ACumulamos los valores
                    matrizAcumulada(Rojo, 0) += 1 'rojo
                    matrizAcumulada(Verde, 1) += 1 'verde
                    matrizAcumulada(Azul, 2) += 1 'azul
                    matrizAcumulada(Alfa, 3) += 1 'alfa
                    matrizAcumulada(grises, 4) += 1 'escala de grises
                Next
            Next
            Return matrizAcumulada
        End Function

        ''' <summary>
        ''' Función que devuelve una captura de pantalla en el momento en que se llama a la función.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Picturebox1.image=objetoTratamiento.capturarPantalla(FALSE)</code></example>
        ''' </summary>
        ''' <param name="ControlExcepciones">Este valor siempre debe ser FALSE.</param>
        ''' <returns>Devuelve un bitmap</returns>
        Function capturarPantalla(ByVal ControlExcepciones As Boolean)
            Dim tamaño As Size = Screen.PrimaryScreen.Bounds.Size 'Establecemos el tamaño de la captura
            Dim Bm As New Bitmap(tamaño.Width, tamaño.Height) 'Creamos un bitmap con ese tamaño
            Dim Gf As Graphics 'Objeto graphics
            Gf = Graphics.FromImage(Bm)
            Gf.CopyFromScreen(0, 0, 0, 0, tamaño) 'Capturamos la pantalla
            If ControlExcepciones = False Then 'Si no la ha capturado el control de excepciones (es decir, la ha realizado el usuario)
                porcentaje(1) = "Finalizado" 'Actualizamos el estado
                RaiseEvent actualizaBMP(Bm) 'generamos el evento
                guardarImagen(Bm, "Captura de pantalla") 'Guardamos la imagen para poder hacer retroceso
            End If

            Return Bm

        End Function

        ''' <summary>
        ''' Función que a partir de una secuencia de operaciones las aplica a una imagen.
        ''' <example>La llamada a la función, asignando la imagen de salida a un Picturebox sería así:
        ''' <code>Dim PasosSecuencia(1,1) as string
        ''' PasosSecuencia(0,0)="Blanco y negro" : PasosSecuencia(0,1)="128"
        ''' PasosSecuencia(1,0)="Sepia"
        ''' Picturebox1.image=objetoTratamiento.Secuencia(PasosSecuencia,bmp)</code></example>
        ''' </summary>
        ''' <param name="datosSecuencia">Indica la secuencia de operaciones que se van a realizar. Debe ser una matriz bidimensional y en cada fila debe estar en primer lugar 
        ''' el nombre de la transformación y en los restantes lugares (columnas) los diferentes parámetros (si los hubiera).</param>
        ''' <param name="bmp">Imagen que se va a transformar. Se debe pasar en formato Bitmap.</param>
        ''' <returns>Devuelve un bitmap</returns>
        ''' <remarks>Para ver los nombres de las diferentes funciones, revisar documentación del desarrollador.</remarks>
        Function Secuencia(ByVal datosSecuencia(,) As String, ByVal bmp As Bitmap) As Bitmap

            Dim bmpSalida As Bitmap = bmp.Clone(New Rectangle(0, 0, bmp.Width, bmp.Height), Imaging.PixelFormat.DontCare)

            For i = 0 To datosSecuencia.GetUpperBound(0)
                Select Case datosSecuencia(i, 0)
                    Case "Blanco y negro"
                        bmpSalida = Me.BlancoNegro(bmpSalida, datosSecuencia(i, 1))
                    Case "Escala de grises"
                        bmpSalida = Me.EscalaGrises(bmpSalida, datosSecuencia(i, 1))
                    Case "Brillo"
                        bmpSalida = Me.Brillo(bmpSalida, datosSecuencia(i, 1))
                    Case "Invertir colores (rojo, verde, azul)"
                        bmpSalida = Me.Invertir(bmpSalida, Convert.ToBoolean(datosSecuencia(i, 1)), Convert.ToBoolean(datosSecuencia(i, 2)), Convert.ToBoolean(datosSecuencia(i, 3)))
                    Case "Sepia"
                        bmpSalida = Me.sepia(bmpSalida)
                    Case "Filtros básicos (rojo, verde, azul)"
                        bmpSalida = Me.filtrosBasicos(bmpSalida, Convert.ToBoolean(datosSecuencia(i, 1)), Convert.ToBoolean(datosSecuencia(i, 2)), Convert.ToBoolean(datosSecuencia(i, 3)))
                    Case "RGB a (BGR, GRB, RBG)"
                        bmpSalida = Me.RGBto(bmpSalida, Convert.ToBoolean(datosSecuencia(i, 1)), Convert.ToBoolean(datosSecuencia(i, 2)), Convert.ToBoolean(datosSecuencia(i, 3)))
                    Case "Redimensionar"
                        bmpSalida = Me.Redimensionar(bmpSalida, New Rectangle(0, 0, datosSecuencia(i, 1), datosSecuencia(i, 2)), Drawing2D.InterpolationMode.HighQualityBicubic)
                    Case "Contraste (recomendado)"
                        bmpSalida = Me.Contraste(bmpSalida, datosSecuencia(i, 1))
                    Case "Contraste"
                        bmpSalida = Me.ContrasteEstirar(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2))
                    Case "Correción de gamma"
                        bmpSalida = Me.Gamma(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2), datosSecuencia(i, 3))
                    Case "Exposición"
                        bmpSalida = Me.Exposicion(bmpSalida, datosSecuencia(i, 1))
                    Case "Modificar canales"
                        bmpSalida = Me.Canales(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2), datosSecuencia(i, 3), datosSecuencia(i, 4))
                    Case "Reducir colores"
                        bmpSalida = Me.reducircolores(bmpSalida, 127 - (datosSecuencia(i, 1) / 2))
                    Case "Filtrar colores (rojo)"
                        bmpSalida = Me.filtroColoresRango(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2), datosSecuencia(i, 3))
                    Case "Filtrar colores (verde)"
                        bmpSalida = Me.filtroColoresRango(bmpSalida, 0, 0, 0, datosSecuencia(i, 1), datosSecuencia(i, 2), datosSecuencia(i, 3))
                    Case "Filtrar colores (azul)"
                        bmpSalida = Me.filtroColoresRango(bmpSalida, 0, 0, 0, 0, 0, 0, datosSecuencia(i, 1), datosSecuencia(i, 2), datosSecuencia(i, 3))
                    Case "Detectar contornos"
                        bmpSalida = Me.contornos(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2), datosSecuencia(i, 3), datosSecuencia(i, 4))
                    Case "Operación aritmética - Suma"
                        bmpSalida = Me.Suma(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2), datosSecuencia(i, 3), datosSecuencia(i, 4), False)
                    Case "Operación aritmética - Resta"
                        bmpSalida = Me.Resta(bmpSalida, -datosSecuencia(i, 1), -datosSecuencia(i, 2), -datosSecuencia(i, 3), -datosSecuencia(i, 4), False)
                    Case "Operación aritmética - División"
                        bmpSalida = Me.Division(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2), datosSecuencia(i, 3), datosSecuencia(i, 4), False)
                    Case "Operación aritmética - Multiplicación"
                        bmpSalida = Me.Multiplicacion(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2), datosSecuencia(i, 3), datosSecuencia(i, 4), False)
                    Case "Operación lógicas - AND"
                        bmpSalida = Me.OperAND(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2), datosSecuencia(i, 3), datosSecuencia(i, 4), False)
                    Case "Operación lógicas - OR"
                        bmpSalida = Me.OperOR(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2), datosSecuencia(i, 3), datosSecuencia(i, 4), False)
                    Case "Operación lógicas - XOR"
                        bmpSalida = Me.OperXOR(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2), datosSecuencia(i, 3), datosSecuencia(i, 4), False)
                    Case "Reflexión horizontal"
                        bmpSalida = Me.Reflexion(bmpSalida, True, False)
                    Case "Reflexión vertical"
                        bmpSalida = Me.Reflexion(bmpSalida, False, True)
                    Case "Traslación"
                        bmpSalida = Me.Traslacion(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2))
                    Case "Voltear"
                        bmpSalida = Me.Volteados(bmpSalida, Volteado(datosSecuencia(i, 1)))
                    Case "Density Slicing automático"
                        'Calculamos el número de colores
                        Dim matrizStringColores() As String = {"Red", "Green", "Blue", "Black", "White", "Yellow", "Maroon", "Gray", "LightGreen", "LightBlue", "Orange", "Pink", "Gold", "DarkBlue", "DarkGreen"}
                        Dim matrizColores(datosSecuencia(i, 1) - 1) As Color
                        For ii = 0 To CInt(datosSecuencia(i, 1)) - 1
                            matrizColores(ii) = Color.FromName(matrizStringColores(ii).ToString)
                        Next
                        If Convert.ToBoolean(datosSecuencia(i, 2)) = True Then 'Si es normalizada
                            bmpSalida = Me.DensitySlicingNormalizado(bmpSalida, datosSecuencia(i, 1), matrizColores)
                        Else
                            bmpSalida = Me.DensitySlicing(bmpSalida, datosSecuencia(i, 1), matrizColores)
                        End If
                    Case "Sobel total"
                        bmpSalida = Me.sobelTotal(bmpSalida)
                    Case "Desenfoque - Distorsión"
                        bmpSalida = Me.Distorsion(bmpSalida, datosSecuencia(i, 1))
                    Case "Desenfoque - Movimiento"
                        bmpSalida = Me.desenfoque(bmpSalida, datosSecuencia(i, 1), datosSecuencia(i, 2))
                    Case "Desenfoque - Blur"
                        Dim objetoMascara As New TratamientoImagenes.Mascaras
                        Dim mascara = objetoMascara.LOW9
                        bmpSalida = Me.mascara3x3RGB(bmp, mascara, , )
                    Case "Pixelado"
                        bmpSalida = Me.Pixelar(bmp, datosSecuencia(i, 1))
                    Case "Cuadrícula"
                        bmpSalida = Me.cuadricula(bmp, Color.FromName(datosSecuencia(i, 2)), Color.FromName(datosSecuencia(i, 4)), datosSecuencia(i, 1), datosSecuencia(i, 3))
                    Case "Sombra de vidrio"
                        bmpSalida = Me.SombraVidrio(bmp, datosSecuencia(i, 1), Convert.ToBoolean(datosSecuencia(i, 2)))
                    Case "Trocear imagen - Tres partes"
                        bmpSalida = Me.ImagenTresPartes(bmp)
                    Case "Trocear imagen - Seis partes"
                        bmpSalida = Me.ImagenSeisPartes(bmp)
                    Case "Ruido aleatorio"
                        bmpSalida = Me.RuidoAleatorio(bmp, datosSecuencia(i, 1))
                    Case "Ruido desplazado"
                        bmpSalida = Me.RuidoProgresivo(bmp, datosSecuencia(i, 1), Convert.ToBoolean(datosSecuencia(i, 2)))
                    Case "Óleo"
                        bmpSalida = Me.Oleo(bmp, datosSecuencia(i, 1), 127 - (datosSecuencia(i, 2) / 2))
                    Case "Efecto Marte"
                        bmpSalida = Me.EfectoMarte(bmp)
                    Case "Efecto antiguo sobreexpuesto"
                        bmpSalida = Me.EfectoAntigSobreex(bmp)
                    Case "Efecto marino"
                        bmpSalida = Me.EfectoMarino(bmp)
                    Case "Aumentar rasgos"
                        bmpSalida = Me.EfectoAumentarRasgos(bmp)
                    Case "Disminuir rasgos"
                        bmpSalida = Me.EfectoDisminuirRasgos(bmp)
                    Case "Contorno sombreado - Contenido"
                        bmpSalida = Me.EfectoContornoSombreado(bmp)
                    Case "Contorno sombreado - Desmedido"
                        bmpSalida = Me.EfectoContornoSombreado2(bmp)
                    Case "Aumentar luz"
                        bmpSalida = Me.EfectoAumentarLuz(bmp)
                End Select

            Next

            Return bmpSalida
        End Function

        ''' <summary>
        ''' Función que a partir del nombre de un volteo, devuelve un RotateFlipType
        ''' </summary>
        ''' <param name="VolteadoSelec">Nombre del volteo.</param>
        ''' <returns>Devuelve un RotateFlipType</returns>
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
#End Region
      
    End Class
End Namespace



