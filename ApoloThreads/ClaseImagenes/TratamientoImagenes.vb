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

        'Estado hilo
        Public Shared porcentaje(2) As String

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

        Public ReadOnly Property ListadoTotalDeInfo() As ArrayList 'Imagen hacia delante
            Get
                Return Informacion
            End Get
        End Property

        Public ReadOnly Property ListadoTotalDeImagenes() As ArrayList 'Imagen hacia delante
            Get
                Return imagenesGuardadas
            End Get
        End Property

        'Almacenamos la imagen
        Private Sub guardarImagen(ByVal bmp As Bitmap, ByVal info As String) 'Para almacenar el bitmap y la información
            'Almacenamos la imagen con su información y añadimos +1 al contador
            If imagenesGuardadas.Count < 40 Then
                imagenesGuardadas.Add(bmp)
                contadorImagenes = imagenesGuardadas.Count
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
                    media = (rojoaux + verdeaux + azulaux) / 3
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
        Function Brillo(ByVal bmp As Bitmap, ByVal cantidad As Integer)
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
        Function Exposicion(ByVal bmp As Bitmap, ByVal valorSobreexposicion As Double)
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
        Function Canales(ByVal bmp As Bitmap, Optional ByVal canalrojo As Integer = 0, Optional ByVal canalverde As Integer = 0, Optional ByVal canalazul As Integer = 0, Optional ByVal canaalfa As Integer = 0)
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
        Function filtrosBasicos(ByVal bmp As Bitmap, Optional ByVal FRojo As Boolean = False, Optional ByVal FVerde As Boolean = False, Optional ByVal Fazul As Boolean = False)
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
        Function RGBto(ByVal bmp As Bitmap, Optional ByVal BGR As Boolean = False, Optional ByVal GRB As Boolean = True, Optional ByVal RBG As Boolean = False)
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
        Public Function reducircolores(ByVal bmp As Bitmap, ByVal valorcontraste As Byte)
            Dim bmp2 = bmp
            Dim Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Niveles = nivel(bmp2) 'Obtenemos valores
            Dim bmp3 As New Bitmap(bmp2.Width, bmp2.Height)
            porcentaje(0) = 0 'Actualizar el estado
            porcentaje(1) = "Reduciendo colores (" & valorcontraste & ")" 'Actualizar el estado
            Dim valoralto, valorbajo As Byte
            valorbajo = 128 - valorcontraste
            valoralto = 128 + valorcontraste
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
            guardarImagen(bmp3, "Reducir colores (" & valorcontraste & ")")
            Return bmp3
        End Function
        Function filtroColoresRango(ByVal bmp As Bitmap, Optional ByVal valorRojoinf As Byte = 0, Optional ByVal valorRojosup As Byte = 0, Optional ByVal salidaRojo As Byte = 0, Optional ByVal valorVerdeinf As Byte = 0, Optional ByVal valorVerdesup As Byte = 0, Optional ByVal salidaVerde As Byte = 0, Optional ByVal valorAzulinf As Byte = 0, Optional ByVal valorAzulsup As Byte = 0, Optional ByVal salidaAzul As Byte = 0)
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
        Function mascara3x3RGB(ByVal bmp As Bitmap, ByVal matrizMascara(,) As Double, Optional ByVal desviacion As Double = 0, Optional ByVal factor As Double = 1)
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
        Function mascara3x3Grises(ByVal bmp As Bitmap, ByVal matrizMascara(,) As Double, Optional ByVal desviacion As Double = 0, Optional ByVal factor As Double = 1)
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

        Function sobelTotal(ByVal bmp As Bitmap)
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

#Region "ClaseConMáscaras"


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
#End Region
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
#End Region
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
#End Region
        End Class
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
                        RaiseEvent actualizaNombreImagen({nombreImagen(.FileName), abrirImagen.Width, abrirImagen.Height, "Desde archivo"}) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
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
                RaiseEvent actualizaNombreImagen({nombreRecursoWeb(enlace), bmp.Width, bmp.Height, "Recurso web"}) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
                Return bmp
            Catch
                Dim bmp As Bitmap
                bmp = Nothing
                Return bmp
            End Try
        End Function


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
            guardarImagen(bmp, "Imagen original como recurso web") 'Almacenamos info y bitmap
            contadorImagenes = imagenesGuardadas.Count 'Lo asignamos como el contador actual
            RaiseEvent actualizaBMP(bmp) 'Generamos evento
            RaiseEvent actualizaNombreImagen({nombreRecursoWeb(direccionURL), bmp.Width, bmp.Height, "Recurso web"}) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
        End Sub

        Function abrirDragDrop(ByVal ruta As String) As Bitmap
            Try
                Dim bmp As New Bitmap(ruta)
                abrirDragDrop = bmp
                guardarImagen(abrirDragDrop, "Imagen original arrastrada") 'Almacenamos info y bitmap
                contadorImagenes = imagenesGuardadas.Count 'Lo asignamos como el contador actual
                RaiseEvent actualizaBMP(abrirDragDrop) 'Generamos evento
                RaiseEvent actualizaNombreImagen({nombreRecursoWeb(ruta), abrirDragDrop.Width, abrirDragDrop.Height, "Desde archivo (arrastrada)"}) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta) 'Generamos evento y enviamos nombre de la imagen a partir de la ruta
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
            auxiliar = rutaImagen
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
#End Region

    End Class

End Namespace