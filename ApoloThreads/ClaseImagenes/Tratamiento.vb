Imports System.Xml
Imports System.Net
Namespace Apolo

    Public Delegate Sub ActualizamosImagen(ByVal bmp As Bitmap) 'Definimos el Tipo de evento
    Public Delegate Sub ActualizamosNombreImagen(ByVal NombreImagen() As String) 'Definimos el Tipo de evento

    Public Class TratamientoImagenes
        'Variables para controlar atrás/adelante 
        Public Shared imagenesGuardadas As New ArrayList 'Para ir atrás y adelante, Lo creamos como
        'Se crea como shared para que no se cree de nuevo en cada instancia
        Private Shared contadorImagenes As Integer 'Para saber en qué índice de las imágenesGUardadas estamos
        Private Shared Informacion As New ArrayList 'Para saber qué se hizo
        '************************************

        'Variables para controlar atrás/adelante imágenes originales
        Public Shared imagenOriginal As Bitmap 'Imagen original guardada
        'Se crea como shared para que no se cree de nuevo en cada instancia
        Private Shared InformacionOrig As String 'Para saber qué se hizo
        '************************************


        'Estado hilo
        Public Shared porcentaje(2) As String

        'Evento de tipo ActualizamosImagen
        Event actualizaBMP As ActualizamosImagen

        'Evento de tipo ActualizamosImagen
        Event actualizaNombreImagen As ActualizamosNombreImagen


        'Propiedad con el estado de la carga
        Public ReadOnly Property estadoCarga() As Array 'Propiedad con el estado de la carga
            Get
                'Serán dos valores, el porcentaje de carga y quién está realizando la acción
                Return porcentaje
            End Get
        End Property

        'Propiedades y métodos para hacer y rehacer el conjunto de imágenes
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
                    Return Informacion.Item(contadorImagenes - 1)
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

        Public ReadOnly Property ListadoTotalDeInfo() As ArrayList 'Toda la info de imágenes
            Get
                Return Informacion
            End Get
        End Property

        Public ReadOnly Property ListadoTotalDeImagenes() As ArrayList 'Todas las imágenes
            Get
                Return imagenesGuardadas
            End Get
        End Property

        'Almacenamos la imagen
        Private Sub guardarImagen(ByVal bmp As Bitmap, ByVal info As String) 'Para almacenar el bitmap y la información
            'Almacenamos la imagen con su información y añadimos +1 al contador
            If imagenesGuardadas.Count < 100 Then
                imagenesGuardadas.Add(bmp)
                contadorImagenes = imagenesGuardadas.Count
                Informacion.Add(info)
            Else
                'Con esto controlamos que si hemos almacenado más de 100 imágenes
                'Quitamos la primera y la nueva la incluimos en el último lugar
                imagenesGuardadas.RemoveAt(0)
                Informacion.RemoveAt(0)
                imagenesGuardadas.Add(bmp)
                Informacion.Add(info)
            End If
        End Sub

        'Liberar todas imágenes 
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
        Public Function EscalaGrises(ByVal bmp As Bitmap, Optional ByVal valorcontraste As Byte = 0) As Bitmap
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
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
            Return bmp3
        End Function
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
        Public Function sepia(ByVal bmp As Bitmap)
            Return filtroponderado(bmp, 0.393, 0.769, 0.189, 0.349, 0.686, 0.168, 0.272, 0.534, 0.131)
        End Function
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
                    'Cambiamos el contraste creando una rampa de contraste
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
        Public Function RGBto(ByVal bmp As Bitmap, Optional ByVal BGR As Boolean = False, Optional ByVal GRB As Boolean = True, Optional ByVal RBG As Boolean = False)
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp) 'Obtenemos valores
            porcentaje(0) = 0 'Actualizar el estado
            Dim TipoEstado As String = "RGB a"
            'Creamos el estado
            If BGR = True Then TipoEstado = "RGB a BGR" Else If GRB = True Then TipoEstado = "RGB a GRB" Else If RBG = True Then TipoEstado = "RGB a RBG"
            porcentaje(1) = TipoEstado
            Dim Rojo, Verde, Azul, alfa As Byte

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).B 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).R 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
                porcentaje(0) = ((i * 100) / bmp.Width) 'Actualizamos el estado
            Next
            porcentaje(1) = "Finalizado" 'Actualizamos el estado
            RaiseEvent actualizaBMP(bmp) 'generamos el evento
            guardarImagen(bmp, TipoEstado) 'Guardamos la imagen para poder hacer retroceso
            Return bmp
        End Function
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
        Public Function contornos(ByVal bmp As Bitmap, ByVal contorno As Integer, ByVal valorrojo As UInteger, ByVal valorverde As UInteger, ByVal valorazul As UInteger)
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
            tipoEstado = tipoEstado.Remove(tipoEstado.Count - 1) 'Eliminamos la última coma
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
            tipoEstado = tipoEstado.Remove(tipoEstado.Count - 1) 'Eliminamos la última coma
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
#Region "Subclase con conjunto de máscaras"
        Public Class mascaras
            Private coefmascara(2, 2) As Double

#Region "Paso bajo"
            Public Function LOW9()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
            Public Function LOW10()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1

                Return coefmascara
            End Function
            Public Function LOW12()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = 4 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
#End Region 'Máscaras de paso bajo
#Region "Paso alto"
            Public Function HIGH1a()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 9 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function HIGH1b()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 5 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function
            Public Function HIGH16()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 20 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function
#End Region 'Máscaras de paso alto
#Region "Bordes y contornos"
            Public Function Resta1()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function
            Public Function Resta2()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function
            Public Function Resta3()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function
            Public Function Laplaciana1()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = -4 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function
            Public Function Laplaciana2()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 4 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function
            Public Function Laplaciana3()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 8 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function Laplaciana4()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = -2 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = -2 : coefmascara(1, 1) = 4 : coefmascara(1, 2) = -2
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = -2 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
            Public Function LaplacianaDiagonal()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 4 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function LaplacianaHorizont()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function
            Public Function LaplacianaVertical()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function
            Public Function GradienteEste()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
            Public Function GradienteSudeste()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
            Public Function GradienteSur()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
            Public Function GradienteOeste()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function GradienteNoreste()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function GradienteNorte()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function EmbossingEste()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
            Public Function EmbossingSudeste()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
            Public Function EmbossingSur()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
            Public Function EmbossingOeste()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function EmbossingNoreste()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function EmbossingNorte()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function SobelV()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 2 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -2 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function SobelH()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 2 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -2
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function SobelDiagonal1()
                coefmascara(0, 0) = -2 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 2
                Return coefmascara
            End Function
            Public Function SobelDiagonal2()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 2
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = -2 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function
            Public Function PrewittVert()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 0 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 0
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
            Public Function PrewittHoriz()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function PrewittDiag1()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                Return coefmascara
            End Function
            Public Function PrewittDiag2()
                coefmascara(0, 0) = 0 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                Return coefmascara
            End Function
            Public Function LineasVerticales()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = 2 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = 2
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function LineasHorizontales()
                coefmascara(0, 0) = -1 : coefmascara(0, 1) = 2 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = -1
                coefmascara(2, 0) = -1 : coefmascara(2, 1) = 2 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
            Public Function Repujado()
                coefmascara(0, 0) = -2 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                coefmascara(1, 0) = -1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 1
                coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 2
                Return coefmascara
            End Function
            Public Function Kirsch0()
                coefmascara(0, 0) = -3 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = 5
                coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 5
                coefmascara(2, 0) = -3 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = 5
                Return coefmascara
            End Function
            Public Function Kirsch45()
                coefmascara(0, 0) = -3 : coefmascara(0, 1) = 5 : coefmascara(0, 2) = 5
                coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 5
                coefmascara(2, 0) = -3 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = -3
                Return coefmascara
            End Function
            Public Function Kirsch90()
                coefmascara(0, 0) = 5 : coefmascara(0, 1) = 5 : coefmascara(0, 2) = 5
                coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                coefmascara(2, 0) = -3 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = -3
                Return coefmascara
            End Function
            Public Function Kirsch135()
                coefmascara(0, 0) = 5 : coefmascara(0, 1) = 5 : coefmascara(0, 2) = 5
                coefmascara(1, 0) = 5 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                coefmascara(2, 0) = -3 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = -3
                Return coefmascara
            End Function
            Public Function Kirsch180()
                coefmascara(0, 0) = 5 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = -3
                coefmascara(1, 0) = 5 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                coefmascara(2, 0) = 5 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = -3
                Return coefmascara
            End Function
            Public Function Kirsch225()
                coefmascara(0, 0) = -3 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = -3
                coefmascara(1, 0) = 5 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                coefmascara(2, 0) = 5 : coefmascara(2, 1) = 5 : coefmascara(2, 2) = -3
                Return coefmascara
            End Function
            Public Function Kirsch270()
                coefmascara(0, 0) = -3 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = -3
                coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                coefmascara(2, 0) = 5 : coefmascara(2, 1) = 5 : coefmascara(2, 2) = 5
                Return coefmascara
            End Function
            Public Function Kirsch315()
                coefmascara(0, 0) = -3 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = -3
                coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 5
                coefmascara(2, 0) = -3 : coefmascara(2, 1) = 5 : coefmascara(2, 2) = 5
                Return coefmascara
            End Function
            Public Function FreichenHori()
                coefmascara(0, 0) = 1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                coefmascara(1, 0) = Math.Sqrt(2) : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -Math.Sqrt(2)
                coefmascara(2, 0) = 1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                Return coefmascara
            End Function
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
        Public Function sobelTotal(ByVal bmp As Bitmap)
            Dim bmp2 = bmp
            Dim bmp3 = bmp
            Dim bmp4 = bmp
            Dim bmp5 = bmp

            Dim objetoMascaras As New mascaras
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
        Public Class ElementoEstructural
            Private Estructura(,) As Integer
            Public Function Cuadrado3x3()
                ReDim Estructura(2, 2)
                For i = 0 To Estructura.GetUpperBound(0)
                    For j = 0 To Estructura.GetUpperBound(0)
                        Estructura(i, j) = 1
                    Next
                Next
                Return Estructura
            End Function
            Public Function Cuadrado5x5()
                ReDim Estructura(4, 4)
                For i = 0 To Estructura.GetUpperBound(0)
                    For j = 0 To Estructura.GetUpperBound(0)
                        Estructura(i, j) = 1
                    Next
                Next
                Return Estructura
            End Function
            Public Function Cuadrado7x7()
                ReDim Estructura(6, 6)
                For i = 0 To Estructura.GetUpperBound(0)
                    For j = 0 To Estructura.GetUpperBound(0)
                        Estructura(i, j) = 1
                    Next
                Next
                Return Estructura
            End Function
            Public Function Cuadrado9x9()
                ReDim Estructura(8, 8)
                For i = 0 To Estructura.GetUpperBound(0)
                    For j = 0 To Estructura.GetUpperBound(0)
                        Estructura(i, j) = 1
                    Next
                Next
                Return Estructura
            End Function
            Public Function CuadradoPersonal(ByVal tamañoLado As Integer)
                ReDim Estructura(tamañoLado - 1, tamañoLado - 1)
                For i = 0 To Estructura.GetUpperBound(0)
                    For j = 0 To Estructura.GetUpperBound(0)
                        Estructura(i, j) = 1
                    Next
                Next
                Return Estructura
            End Function

            Public Function Diamante3x3()
                ReDim Estructura(2, 2)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 1 : Estructura(0, 2) = 0
                Estructura(1, 0) = 1 : Estructura(1, 1) = 1 : Estructura(1, 2) = 1
                Estructura(2, 0) = 0 : Estructura(2, 1) = 1 : Estructura(2, 2) = 0
                Return Estructura
            End Function
            Public Function Diamante5x5()
                ReDim Estructura(4, 4)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 0 : Estructura(0, 2) = 1 : Estructura(0, 3) = 0 : Estructura(0, 4) = 0
                Estructura(1, 0) = 0 : Estructura(1, 1) = 1 : Estructura(1, 2) = 1 : Estructura(1, 3) = 1 : Estructura(1, 4) = 0
                Estructura(2, 0) = 1 : Estructura(2, 1) = 1 : Estructura(2, 2) = 1 : Estructura(2, 3) = 1 : Estructura(2, 4) = 1
                Estructura(3, 0) = 0 : Estructura(3, 1) = 1 : Estructura(3, 2) = 1 : Estructura(3, 3) = 1 : Estructura(3, 4) = 0
                Estructura(4, 0) = 0 : Estructura(4, 1) = 0 : Estructura(4, 2) = 1 : Estructura(4, 3) = 0 : Estructura(4, 4) = 0
                Return Estructura
            End Function
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

            Public Function Disco5x5()
                ReDim Estructura(4, 4)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 1 : Estructura(0, 2) = 1 : Estructura(0, 3) = 1 : Estructura(0, 4) = 0
                Estructura(1, 0) = 1 : Estructura(1, 1) = 1 : Estructura(1, 2) = 1 : Estructura(1, 3) = 1 : Estructura(1, 4) = 1
                Estructura(2, 0) = 1 : Estructura(2, 1) = 1 : Estructura(2, 2) = 1 : Estructura(2, 3) = 1 : Estructura(2, 4) = 1
                Estructura(3, 0) = 1 : Estructura(3, 1) = 1 : Estructura(3, 2) = 1 : Estructura(3, 3) = 1 : Estructura(3, 4) = 1
                Estructura(4, 0) = 0 : Estructura(4, 1) = 1 : Estructura(4, 2) = 1 : Estructura(4, 3) = 1 : Estructura(4, 4) = 0
                Return Estructura
            End Function
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

            Public Function DiagonalA3x3()
                ReDim Estructura(2, 2)
                Estructura(0, 0) = 1 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0
                Estructura(1, 0) = 0 : Estructura(1, 1) = 1 : Estructura(1, 2) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 0 : Estructura(2, 2) = 1
                Return Estructura
            End Function
            Public Function DiagonalA5x5()
                ReDim Estructura(4, 4)
                Estructura(0, 0) = 1 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0 : Estructura(0, 3) = 0 : Estructura(0, 4) = 0
                Estructura(1, 0) = 0 : Estructura(1, 1) = 1 : Estructura(1, 2) = 0 : Estructura(1, 3) = 0 : Estructura(1, 4) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 0 : Estructura(2, 2) = 1 : Estructura(2, 3) = 0 : Estructura(2, 4) = 0
                Estructura(3, 0) = 0 : Estructura(3, 1) = 0 : Estructura(3, 2) = 0 : Estructura(3, 3) = 1 : Estructura(3, 4) = 0
                Estructura(4, 0) = 0 : Estructura(4, 1) = 0 : Estructura(4, 2) = 0 : Estructura(4, 3) = 0 : Estructura(4, 4) = 1
                Return Estructura
            End Function
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

            Public Function DiagonalB3x3()
                ReDim Estructura(2, 2)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 0 : Estructura(0, 2) = 1
                Estructura(1, 0) = 0 : Estructura(1, 1) = 1 : Estructura(1, 2) = 0
                Estructura(2, 0) = 1 : Estructura(2, 1) = 0 : Estructura(2, 2) = 0
                Return Estructura
            End Function
            Public Function DiagonalB5x5()
                ReDim Estructura(4, 4)
                Estructura(0, 0) = 0 : Estructura(0, 1) = 0 : Estructura(0, 2) = 0 : Estructura(0, 3) = 0 : Estructura(0, 4) = 1
                Estructura(1, 0) = 0 : Estructura(1, 1) = 0 : Estructura(1, 2) = 0 : Estructura(1, 3) = 1 : Estructura(1, 4) = 0
                Estructura(2, 0) = 0 : Estructura(2, 1) = 0 : Estructura(2, 2) = 1 : Estructura(2, 3) = 0 : Estructura(2, 4) = 0
                Estructura(3, 0) = 0 : Estructura(3, 1) = 1 : Estructura(3, 2) = 0 : Estructura(3, 3) = 0 : Estructura(3, 4) = 0
                Estructura(4, 0) = 1 : Estructura(4, 1) = 0 : Estructura(4, 2) = 0 : Estructura(4, 3) = 0 : Estructura(4, 4) = 0
                Return Estructura
            End Function
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

        'Principales efectos sobre imágenes. Contiene funciones que devuelven bitmaps
#Region "Efectos"
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

#End Region

        'Suma/Resta/multip/división/Unión/AND/OR/XOR de DOS imágenes. Devuelve un bitmap con el alto/ancho del bitmap más pequeño
#Region "operaciones con dos imágenes"
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
#End Region

        'Comparador de imágenes a partir de dos bitmaps
#Region "comparar dos imágenes"
        Public Function CompararDosImagenes(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap)
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
        Public Function CompararDosImagenesVecinos(ByVal bmp1 As Bitmap, ByVal bmp2 As Bitmap, Optional ByVal DistanciaVecinos As Integer = 1, Optional ByVal PasoAlto As Boolean = False, Optional ByVal Grafica As Integer = 0, Optional ComparadorRapido As Boolean = False)
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
                Dim objmascara As New TratamientoImagenes.mascaras
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
        Sub actualizarNombreTapiz(ByVal nombre As String, ByVal ancho As Integer, ByVal alto As Integer)
            RaiseEvent actualizaNombreImagen({nombre, ancho, alto, "Imagen tapiz"}) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
        End Sub

        'Se abre imagen desde archivo
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

        'Se abre imagen desde una URL
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
        Function nombreImagen(ByVal rutaImagen As String)
            Dim auxiliar, auxiliar2, nombre_imagen As String
            Dim nombre_imagen2() As String
            auxiliar = rutaImagen
            nombre_imagen2 = Split(auxiliar, "\")
            auxiliar2 = UBound(nombre_imagen2)
            nombre_imagen = nombre_imagen2(auxiliar2)
            Return nombre_imagen
        End Function 'Nombre desde archivo
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
        'Duplicamos la función (histogramaAcumulado, histogramaAcumuladoH) para que no haya fallos con los hilos)
        Public Function histogramaAcumulado(ByVal bmp As Bitmap)
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
        Function capturarPantalla()
            Dim tamaño As Size = Screen.PrimaryScreen.Bounds.Size 'Establecemos el tamaño de la captura
            Dim Bm As New Bitmap(tamaño.Width, tamaño.Height) 'Creamos un bitmap con ese tamaño
            Dim Gf As Graphics 'Objeto graphics
            Gf = Graphics.FromImage(Bm)
            Gf.CopyFromScreen(0, 0, 0, 0, tamaño) 'Capturamos la pantalla

            Return Bm

        End Function
#End Region


    End Class
End Namespace