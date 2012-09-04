Imports System.IO

Public Class Class1


    Public Class tratamiento
        Public BItmapOriginal As Bitmap
        Public rutaimagen As String
        Public Niveles(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
        Public Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
        Public NivelesClon(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
        Public NivelesFiltro(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
        Public NivelesEsp(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
        Public NivelesEspaux(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
      

        Private Sub nivel(ByVal bmp As Bitmap)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            'Este primer bloque, guarda los niveles digitales de la imagen en la variable Niveles
            Dim i, j As Long

            ReDim Niveles(bmp.Width - 1, bmp.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            Dim bmp2 As New Bitmap(bmp)
            undo(bmp2)
            For i = 0 To bmp.Width - 1 'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 1 'Recorremos la matriz a lo largo
                    Niveles(i, j) = bmp.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                Next
            Next
        End Sub

        Private Sub nivelauxiliar(ByVal bmp As Bitmap)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            'Este primer bloque, guarda los niveles digitales de la imagen en la variable Niveles
            Dim i, j As Long

            ReDim Niveles2(bmp.Width - 1, bmp.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            Dim bmp2 As New Bitmap(bmp)
            undo(bmp2)
            For i = 0 To bmp.Width - 1 'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 1 'Recorremos la matriz a lo largo
                    Niveles2(i, j) = bmp.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                Next
            Next
        End Sub


        Public Function grises(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim media As Double 'Variable para calcular la media
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    rojoaux = Niveles(i, j).R
                    verdeaux = Niveles(i, j).G
                    azulaux = Niveles(i, j).B
                    media = CInt((rojoaux + verdeaux + azulaux) / 3)
                    Rojo = media
                    Verde = media
                    Azul = media
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
            Next
            Return bmp
        End Function

        Function ruido(ByVal bmp As Bitmap, Optional ByVal valorRuido As Integer = 10, Optional ByVal colorRojo As Byte = 0, Optional ByVal colorVerde As Byte = 0, Optional ByVal colorAzul As Byte = 0)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim Random As New Random()
            Dim numero As Integer
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    numero = Random.Next(1, valorRuido)
                    If numero = 1 Then
                        bmp.SetPixel(i, j, Color.FromArgb(colorRojo, colorVerde, colorAzul)) 'Asignamos a bmp los colores invertidos
                    Else
                        Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                        Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                        Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                        alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                    End If
                Next
            Next
            Return bmp
        End Function

        Function ruidoaleatorio(ByVal bmp As Bitmap)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim Random As New Random()
            Dim numero, numero2 As Integer
            Dim color1, color2, color3 As Integer

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    numero2 = Random.Next(1, 50)
                    numero = Random.Next(1, numero2)
                    If numero = 1 Then
                        color1 = Random.Next(0, 255) : color2 = Random.Next(0, 255) : color3 = Random.Next(0, 255) : alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, color1, color2, color3)) 'Asignamos a bmp los colores invertidos
                    Else
                        Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                        Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                        Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                        alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                    End If
                Next
            Next
            Return bmp
        End Function

        Function ruidoaleatorioColor(ByVal bmp As Bitmap, Optional ByVal valorRuido As Integer = 10)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim Random As New Random()
            Dim numero As Integer
            Dim color1, color2, color3 As Integer
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    numero = Random.Next(1, valorRuido)
                    If numero = 1 Then
                        color1 = Random.Next(0, 255) : color2 = Random.Next(0, 255) : color3 = Random.Next(0, 255) : alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, color1, color2, color3)) 'Asignamos a bmp los colores invertidos
                    Else
                        Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                        Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                        Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                        alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                    End If
                Next
            Next
            Return bmp
        End Function

        Function invertir(ByVal bmp As Bitmap)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = 255 - (Niveles(i, j).R) 'Realizamos la inversión de los colores
                    Verde = 255 - (Niveles(i, j).G) 'Realizamos la inversión de los colores
                    Azul = 255 - (Niveles(i, j).B) 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function
        Function invertirrojo(ByVal bmp As Bitmap)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = 255 - (Niveles(i, j).R) 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function
        Function invertirverde(ByVal bmp As Bitmap)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Verde = 255 - (Niveles(i, j).G) 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function
        Function invertirazul(ByVal bmp As Bitmap)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Azul = 255 - (Niveles(i, j).B) 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function sepia(ByVal bmp As Bitmap)
            Return filtroponderado(bmp, 0.393, 0.769, 0.189, 0.349, 0.686, 0.168, 0.272, 0.534, 0.131)
        End Function


        Public Function blanconegro(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim media As Double 'Variable para calcular la media
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            'para que no se desborde
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
            Next

            Return bmp
        End Function


        Public Function blanconegro(ByVal bmp As Bitmap, ByVal valortope As Byte)

            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim media As Double 'Variable para calcular la media
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            'para que no se desborde
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
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
            Next

            Return bmp
        End Function

        Public Function etiopia(ByVal bmp As Bitmap, Optional ByVal Horizontal As Boolean = True)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim media As Double 'Variable para calcular la media
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            If Horizontal = False Then
                For i = 0 To Niveles.GetUpperBound(0) / 3  'Recorremos la matriz
                    For j = 0 To Niveles.GetUpperBound(1)
                        rojoaux = Niveles(i, j).R
                        verdeaux = Niveles(i, j).G
                        azulaux = Niveles(i, j).B
                        'Calculamos la media conviertiendo el resultado en un integer (CInt)
                        media = CInt((rojoaux + verdeaux + azulaux) / 3)
                        Rojo = 0
                        Verde = media
                        Azul = 0
                        alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                    Next
                Next
                For i = Niveles.GetUpperBound(0) / 3 To (Niveles.GetUpperBound(0) / 3) * 2  'Recorremos la matriz
                    For j = 0 To Niveles.GetUpperBound(1)
                        rojoaux = Niveles(i, j).R
                        verdeaux = Niveles(i, j).G
                        azulaux = Niveles(i, j).B
                        'Calculamos la media conviertiendo el resultado en un integer (CInt)
                        media = CInt((rojoaux + verdeaux + azulaux) / 3)
                        Rojo = media
                        Verde = media
                        Azul = 0
                        alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                    Next
                Next
                For i = (Niveles.GetUpperBound(0) / 3) * 2 To Niveles.GetUpperBound(0) 'Recorremos la matriz
                    For j = 0 To Niveles.GetUpperBound(1)
                        rojoaux = Niveles(i, j).R
                        verdeaux = Niveles(i, j).G
                        azulaux = Niveles(i, j).B
                        'Calculamos la media conviertiendo el resultado en un integer (CInt)
                        media = CInt((rojoaux + verdeaux + azulaux) / 3)
                        Rojo = media
                        Verde = 0
                        Azul = 0
                        alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                    Next
                Next
            Else
                For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                    For j = 0 To Niveles.GetUpperBound(1) / 3
                        rojoaux = Niveles(i, j).R
                        verdeaux = Niveles(i, j).G
                        azulaux = Niveles(i, j).B
                        'Calculamos la media conviertiendo el resultado en un integer (CInt)
                        media = CInt((rojoaux + verdeaux + azulaux) / 3)
                        Rojo = 0
                        Verde = media
                        Azul = 0
                        alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                    Next
                Next
                For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                    For j = Niveles.GetUpperBound(1) / 3 To (Niveles.GetUpperBound(1) / 3) * 2
                        rojoaux = Niveles(i, j).R
                        verdeaux = Niveles(i, j).G
                        azulaux = Niveles(i, j).B
                        'Calculamos la media conviertiendo el resultado en un integer (CInt)
                        media = CInt((rojoaux + verdeaux + azulaux) / 3)
                        Rojo = media
                        Verde = media
                        Azul = 0
                        alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                    Next
                Next
                For i = 0 To Niveles.GetUpperBound(0) 'Recorremos la matriz
                    For j = (Niveles.GetUpperBound(1) / 3) * 2 To Niveles.GetUpperBound(1)
                        rojoaux = Niveles(i, j).R
                        verdeaux = Niveles(i, j).G
                        azulaux = Niveles(i, j).B
                        'Calculamos la media conviertiendo el resultado en un integer (CInt)
                        media = CInt((rojoaux + verdeaux + azulaux) / 3)
                        Rojo = media
                        Verde = 0
                        Azul = 0
                        alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                    Next
                Next
            End If
            Return bmp
        End Function


        Function aumentarbrillo(ByVal bmp As Bitmap, ByVal cantidad As Byte)
            nivel(bmp)
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
                    AuxiliarR = AuxiliarR2 + cantidad 'Aumentamos en 20 unidades el color rojo
                    AuxiliarG = AuxiliarG2 + cantidad 'Aumentamos en 20 unidades el color verde
                    AuxiliarB = AuxiliarB2 + cantidad 'Aumentamos en 20 unidades el color azul
                    'Comprobamos que no hay valores no válidos, es decir, mayores de 255
                    'Si hay valores mayores, los igualamos a 255
                    If AuxiliarR > 255 Then AuxiliarR = 255
                    If AuxiliarG > 255 Then AuxiliarG = 255
                    If AuxiliarB > 255 Then AuxiliarB = 255
                    Rojo = AuxiliarR
                    Verde = AuxiliarG
                    Azul = AuxiliarB
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function


        Function disminuirbrillo(ByVal bmp As Bitmap, ByVal cantidad As Byte)
            nivel(bmp)
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
                    AuxiliarR = AuxiliarR2 - cantidad 'Aumentamos en 20 unidades el color rojo
                    AuxiliarG = AuxiliarG2 - cantidad 'Aumentamos en 20 unidades el color verde
                    AuxiliarB = AuxiliarB2 - cantidad 'Aumentamos en 20 unidades el color azul
                    'Comprobamos que no hay valores no válidos, es decir, mayores de 255
                    'Si hay valores mayores, los igualamos a 255
                    If AuxiliarR < 0 Then AuxiliarR = 0
                    If AuxiliarG < 0 Then AuxiliarG = 0
                    If AuxiliarB < 0 Then AuxiliarB = 0
                    Rojo = AuxiliarR
                    Verde = AuxiliarG
                    Azul = AuxiliarB
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function


        Function exposicion(ByVal bmp As Bitmap, Optional ByVal valorSobreexposicion As Double = 1)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            If valorSobreexposicion = 0 Then valorSobreexposicion = 0.001
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojo = Niveles(i, j).R / valorSobreexposicion 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G / valorSobreexposicion 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).B / valorSobreexposicion 'Realizamos la inversión de los colores
                    If Rojo > 255 Then Rojo = 255
                    If Verde > 255 Then Verde = 255
                    If Azul > 255 Then Azul = 255
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function modificarCanales(ByVal bmp As Bitmap, Optional ByVal canalrojo As Integer = 0, Optional ByVal canalverde As Integer = 0, Optional ByVal canalazul As Integer = 0)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux As Double 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojoaux = Niveles(i, j).R + canalrojo 'Realizamos la inversión de los colores
                    Verdeuax = Niveles(i, j).G + canalverde 'Realizamos la inversión de los colores
                    Azulaux = Niveles(i, j).B + canalazul 'Realizamos la inversión de los colores
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeuax > 255 Then Verdeuax = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If Rojoaux < 0 Then Rojoaux = 0
                    If Verdeuax < 0 Then Verdeuax = 0
                    If Azulaux < 0 Then Azulaux = 0
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function Calor(ByVal bmp As Bitmap)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux As Double 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojoaux = Niveles(i, j).R + 20  'Realizamos la inversión de los colores
                    Verdeuax = Niveles(i, j).G + 8 'Realizamos la inversión de los colores
                    Azulaux = Niveles(i, j).B  'Realizamos la inversión de los colores
                    If Rojoaux > 180 And Verdeuax > 180 Then
                        Rojoaux = Rojoaux + 30
                        Verdeuax = Verdeuax + 30
                    End If
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeuax > 255 Then Verdeuax = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If Rojoaux < 0 Then Rojoaux = 0
                    If Verdeuax < 0 Then Verdeuax = 0
                    If Azulaux < 0 Then Azulaux = 0
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function
        Function desierto(ByVal bmp As Bitmap)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux As Double 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojoaux = Niveles(i, j).R + 20  'Realizamos la inversión de los colores
                    Verdeuax = Niveles(i, j).G + 20 'Realizamos la inversión de los colores
                    Azulaux = Niveles(i, j).B  'Realizamos la inversión de los colores
                    If Rojoaux > 120 And Verdeuax > 120 Then
                        Rojoaux = Rojoaux + 40
                        Verdeuax = Verdeuax + 40
                    End If
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeuax > 255 Then Verdeuax = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If Rojoaux < 0 Then Rojoaux = 0
                    If Verdeuax < 0 Then Verdeuax = 0
                    If Azulaux < 0 Then Azulaux = 0
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function
        Function hielo(ByVal bmp As Bitmap)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux As Double 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojoaux = Niveles(i, j).R - 5  'Realizamos la inversión de los colores
                    Verdeuax = Niveles(i, j).G + 5 'Realizamos la inversión de los colores
                    Azulaux = Niveles(i, j).B + 35    'Realizamos la inversión de los colores
                    If Azulaux > 150 Then
                        Azulaux=Azulaux+35
                    End If
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeuax > 255 Then Verdeuax = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If Rojoaux < 0 Then Rojoaux = 0
                    If Verdeuax < 0 Then Verdeuax = 0
                    If Azulaux < 0 Then Azulaux = 0
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function
        Function naturaleza(ByVal bmp As Bitmap)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeuax, Azulaux As Double 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojoaux = Niveles(i, j).R - 10  'Realizamos la inversión de los colores
                    Verdeuax = Niveles(i, j).G + 10 'Realizamos la inversión de los colores
                    Azulaux = Niveles(i, j).B    'Realizamos la inversión de los colores
                    If Verdeuax > 120 And Azulaux < 50 And Rojoaux < 50 Then
                        Verdeuax = Verdeuax + 35
                    End If
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeuax > 255 Then Verdeuax = 255
                    If Azulaux > 255 Then Azulaux = 255
                    If Rojoaux < 0 Then Rojoaux = 0
                    If Verdeuax < 0 Then Verdeuax = 0
                    If Azulaux < 0 Then Azulaux = 0
                    Rojo = Rojoaux : Verde = Verdeuax : Azul = Azulaux
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function filtrorojo(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            'Calculamos la media, y asignamos el color al rojo y al resto 0
            'Calculamos la media de los tres colores
            Dim media As Double 'Variable para calcular la media
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            'para que no se desborde
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    rojoaux = Niveles(i, j).R
                    verdeaux = Niveles(i, j).G
                    azulaux = Niveles(i, j).B
                    'Calculamos la media conviertiendo el resultado en un integer (CInt)
                    media = CInt((rojoaux + verdeaux + azulaux) / 3)
                    Rojo = media
                    Verde = 0
                    Azul = 0
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next

            Return bmp
        End Function


        Function filtroazul(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            'Calculamos la media, y asignamos el color al rojo y al resto 0
            'Calculamos la media de los tres colores
            Dim media As Double 'Variable para calcular la media
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            'para que no se desborde
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    rojoaux = Niveles(i, j).R
                    verdeaux = Niveles(i, j).G
                    azulaux = Niveles(i, j).B
                    'Calculamos la media conviertiendo el resultado en un integer (CInt)
                    media = CInt((rojoaux + verdeaux + azulaux) / 3)
                    Rojo = 0
                    Verde = 0
                    Azul = media
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next

            Return bmp
        End Function

        Function filtroverde(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            'Calculamos la media, y asignamos el color al rojo y al resto 0
            'Calculamos la media de los tres colores
            Dim media As Double 'Variable para calcular la media
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            'para que no se desborde
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    rojoaux = Niveles(i, j).R
                    verdeaux = Niveles(i, j).G
                    azulaux = Niveles(i, j).B
                    'Calculamos la media conviertiendo el resultado en un integer (CInt)
                    media = CInt((rojoaux + verdeaux + azulaux) / 3)
                    Rojo = 0
                    Verde = media
                    Azul = 0
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next

            Return bmp
        End Function


        Function RGBtoBGR(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).B 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).R 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function RGBtoGRB(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function RGBtoRBG(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).B 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).G 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function doscolorescanaldefecto(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    If Rojo <= 127 Then Rojo = 0 Else Rojo = 128

                    Verde = Niveles(i, j).G  'Realizamos la inversión de los colores
                    If Verde <= 127 Then Verde = 0 Else Verde = 128

                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    If Azul <= 127 Then Azul = 0 Else Azul = 128
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function doscolorescanalexceso(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    If Rojo <= 127 Then Rojo = 127 Else Rojo = 255

                    Verde = Niveles(i, j).G  'Realizamos la inversión de los colores
                    If Verde <= 127 Then Verde = 127 Else Verde = 255

                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    If Azul <= 127 Then Azul = 127 Else Azul = 255
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function cuatrocolorescanaldefecto(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores


            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Select Case Rojo
                        Case 0 To 63
                            Rojo = 0
                        Case 64 To 127
                            Rojo = 64
                        Case 128 To 191
                            Rojo = 128
                        Case 192 To 255
                            Rojo = 192
                    End Select

                    Verde = Niveles(i, j).G  'Realizamos la inversión de los colores
                    Select Case Verde
                        Case 0 To 63
                            Verde = 0
                        Case 64 To 127
                            Verde = 64
                        Case 128 To 191
                            Verde = 128
                        Case 192 To 255
                            Verde = 192
                    End Select

                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    Select Case Azul
                        Case 0 To 63
                            Azul = 0
                        Case 64 To 127
                            Azul = 64
                        Case 128 To 191
                            Azul = 128
                        Case 192 To 255
                            Azul = 192
                    End Select
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function
        Function cuatrocolorescanalexceso(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Select Case Rojo
                        Case 0 To 63
                            Rojo = 63
                        Case 64 To 127
                            Rojo = 127
                        Case 128 To 191
                            Rojo = 191
                        Case 192 To 255
                            Rojo = 255
                    End Select

                    Verde = Niveles(i, j).G  'Realizamos la inversión de los colores
                    Select Case Verde
                        Case 0 To 63
                            Verde = 63
                        Case 64 To 127
                            Verde = 127
                        Case 128 To 191
                            Verde = 191
                        Case 192 To 255
                            Verde = 255
                    End Select

                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    Select Case Azul
                        Case 0 To 63
                            Azul = 63
                        Case 64 To 127
                            Azul = 127
                        Case 128 To 191
                            Azul = 191
                        Case 192 To 255
                            Azul = 255
                    End Select
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function ochocolorescanaldefecto(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojo = Niveles(i, j).R
                    Select Case Rojo
                        Case 0 To 31
                            Rojo = 0
                        Case 32 To 63
                            Rojo = 32
                        Case 64 To 95
                            Rojo = 64
                        Case 96 To 127
                            Rojo = 96
                        Case 128 To 159
                            Rojo = 128
                        Case 160 To 191
                            Rojo = 160
                        Case 192 To 223
                            Rojo = 192
                        Case 224 To 255
                            Rojo = 224
                    End Select

                    Verde = Niveles(i, j).G  'Realizamos la inversión de los colores
                    Select Case Verde
                        Case 0 To 31
                            Verde = 0
                        Case 32 To 63
                            Verde = 32
                        Case 64 To 95
                            Verde = 64
                        Case 96 To 127
                            Verde = 96
                        Case 128 To 159
                            Verde = 128
                        Case 160 To 191
                            Verde = 160
                        Case 192 To 223
                            Verde = 192
                        Case 224 To 255
                            Verde = 224
                    End Select

                    Azul = Niveles(i, j).B
                    Select Case Azul
                        Case 0 To 31
                            Azul = 0
                        Case 32 To 63
                            Azul = 32
                        Case 64 To 95
                            Azul = 64
                        Case 96 To 127
                            Azul = 96
                        Case 128 To 159
                            Azul = 128
                        Case 160 To 191
                            Azul = 160
                        Case 192 To 223
                            Azul = 192
                        Case 224 To 255
                            Azul = 224
                    End Select
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function
        Function ochocolorescanalexceso(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojo = Niveles(i, j).R
                    Select Case Rojo
                        Case 0 To 31
                            Rojo = 31
                        Case 32 To 63
                            Rojo = 63
                        Case 64 To 95
                            Rojo = 95
                        Case 96 To 127
                            Rojo = 127
                        Case 128 To 159
                            Rojo = 159
                        Case 160 To 191
                            Rojo = 191
                        Case 192 To 223
                            Rojo = 223
                        Case 224 To 255
                            Rojo = 255
                    End Select


                    Verde = Niveles(i, j).G  'Realizamos la inversión de los colores
                    Select Case Verde
                        Case 0 To 31
                            Verde = 31
                        Case 32 To 63
                            Verde = 63
                        Case 64 To 95
                            Verde = 95
                        Case 96 To 127
                            Verde = 127
                        Case 128 To 159
                            Verde = 159
                        Case 160 To 191
                            Verde = 191
                        Case 192 To 223
                            Verde = 223
                        Case 224 To 255
                            Verde = 255
                    End Select

                    Azul = Niveles(i, j).B
                    Select Case Azul
                        Case 0 To 31
                            Azul = 31
                        Case 32 To 63
                            Azul = 63
                        Case 64 To 95
                            Azul = 95
                        Case 96 To 127
                            Azul = 127
                        Case 128 To 159
                            Azul = 159
                        Case 160 To 191
                            Azul = 191
                        Case 192 To 223
                            Azul = 223
                        Case 224 To 255
                            Azul = 255
                    End Select

                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function dieciseiscolorescanaldefecto(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojo = Niveles(i, j).R
                    Select Case Rojo
                        Case 0 To 15
                            Rojo = 0
                        Case 16 To 31
                            Rojo = 16
                        Case 32 To 47
                            Rojo = 32
                        Case 48 To 63
                            Rojo = 48
                        Case 64 To 79
                            Rojo = 64
                        Case 80 To 95
                            Rojo = 80
                        Case 96 To 111
                            Rojo = 96
                        Case 112 To 127
                            Rojo = 112
                        Case 128 To 143
                            Rojo = 128
                        Case 144 To 159
                            Rojo = 144
                        Case 160 To 175
                            Rojo = 160
                        Case 176 To 191
                            Rojo = 176
                        Case 192 To 207
                            Rojo = 192
                        Case 208 To 223
                            Rojo = 208
                        Case 224 To 239
                            Rojo = 224
                        Case 240 To 255
                            Rojo = 240
                    End Select

                    Verde = Niveles(i, j).G  'Realizamos la inversión de los colores
                    Select Case Verde
                        Case 0 To 15
                            Verde = 0
                        Case 16 To 31
                            Verde = 16
                        Case 32 To 47
                            Verde = 32
                        Case 48 To 63
                            Verde = 48
                        Case 64 To 79
                            Verde = 64
                        Case 80 To 95
                            Verde = 80
                        Case 96 To 111
                            Verde = 96
                        Case 112 To 127
                            Verde = 112
                        Case 128 To 143
                            Verde = 128
                        Case 144 To 159
                            Verde = 144
                        Case 160 To 175
                            Verde = 160
                        Case 176 To 191
                            Verde = 176
                        Case 192 To 207
                            Verde = 192
                        Case 208 To 223
                            Verde = 208
                        Case 224 To 239
                            Verde = 224
                        Case 240 To 255
                            Verde = 240
                    End Select



                    Azul = Niveles(i, j).B
                    Select Case Azul
                        Case 0 To 15
                            Azul = 0
                        Case 16 To 31
                            Azul = 16
                        Case 32 To 47
                            Azul = 32
                        Case 48 To 63
                            Azul = 48
                        Case 64 To 79
                            Azul = 64
                        Case 80 To 95
                            Azul = 80
                        Case 96 To 111
                            Azul = 96
                        Case 112 To 127
                            Azul = 112
                        Case 128 To 143
                            Azul = 128
                        Case 144 To 159
                            Azul = 144
                        Case 160 To 175
                            Azul = 160
                        Case 176 To 191
                            Azul = 176
                        Case 192 To 207
                            Azul = 192
                        Case 208 To 223
                            Azul = 208
                        Case 224 To 239
                            Azul = 224
                        Case 240 To 255
                            Azul = 240
                    End Select
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function dieciseiscolorescanalexceso(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojo = Niveles(i, j).R
                    Select Case Rojo
                        Case 0 To 15
                            Rojo = 15
                        Case 16 To 31
                            Rojo = 31
                        Case 32 To 47
                            Rojo = 47
                        Case 48 To 63
                            Rojo = 63
                        Case 64 To 79
                            Rojo = 79
                        Case 80 To 95
                            Rojo = 95
                        Case 96 To 111
                            Rojo = 111
                        Case 112 To 127
                            Rojo = 127
                        Case 128 To 143
                            Rojo = 143
                        Case 144 To 159
                            Rojo = 159
                        Case 160 To 175
                            Rojo = 175
                        Case 176 To 191
                            Rojo = 191
                        Case 192 To 207
                            Rojo = 207
                        Case 208 To 223
                            Rojo = 223
                        Case 224 To 239
                            Rojo = 239
                        Case 240 To 255
                            Rojo = 255
                    End Select

                    Verde = Niveles(i, j).G  'Realizamos la inversión de los colores
                    Select Case Verde
                        Case 0 To 15
                            Verde = 15
                        Case 16 To 31
                            Verde = 31
                        Case 32 To 47
                            Verde = 47
                        Case 48 To 63
                            Verde = 63
                        Case 64 To 79
                            Verde = 79
                        Case 80 To 95
                            Verde = 95
                        Case 96 To 111
                            Verde = 111
                        Case 112 To 127
                            Verde = 127
                        Case 128 To 143
                            Verde = 143
                        Case 144 To 159
                            Verde = 159
                        Case 160 To 175
                            Verde = 175
                        Case 176 To 191
                            Verde = 191
                        Case 192 To 207
                            Verde = 207
                        Case 208 To 223
                            Verde = 223
                        Case 224 To 239
                            Verde = 239
                        Case 240 To 255
                            Verde = 255
                    End Select



                    Azul = Niveles(i, j).B
                    Select Case Azul
                        Case 0 To 15
                            Azul = 15
                        Case 16 To 31
                            Azul = 31
                        Case 32 To 47
                            Azul = 47
                        Case 48 To 63
                            Azul = 63
                        Case 64 To 79
                            Azul = 79
                        Case 80 To 95
                            Azul = 95
                        Case 96 To 111
                            Azul = 111
                        Case 112 To 127
                            Azul = 127
                        Case 128 To 143
                            Azul = 143
                        Case 144 To 159
                            Azul = 159
                        Case 160 To 175
                            Azul = 175
                        Case 176 To 191
                            Azul = 191
                        Case 192 To 207
                            Azul = 207
                        Case 208 To 223
                            Azul = 223
                        Case 224 To 239
                            Azul = 239
                        Case 240 To 255
                            Azul = 255
                    End Select
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function
        Public Function reducircolores(ByVal bmp As Bitmap, ByVal valorcontraste As Byte)
            nivel(bmp)
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
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
            Next
            Return bmp
        End Function

        Public Function reducircoloresgris(ByVal bmp As Bitmap, ByVal valorcontraste As Byte)
            nivel(bmp)
            Dim valoralto, valorbajo, alfa As Byte
            valorbajo = 128 - valorcontraste
            valoralto = 128 + valorcontraste
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            Dim media As Double 'Variable para calcular la media
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    rojoaux = Niveles(i, j).R
                    verdeaux = Niveles(i, j).G
                    azulaux = Niveles(i, j).B
                    media = CInt((rojoaux + verdeaux + azulaux) / 3)
                    If media >= valorbajo And media <= valoralto Then
                        If (media - valorbajo) <= (valoralto - media) Then
                            media = valorbajo
                        Else
                            media = valoralto
                        End If
                    End If
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, media, media, media))
                Next
            Next
            Return bmp
        End Function



        Function mascara3x3RGB(ByVal bmp As Bitmap, ByVal matrizMascara(,) As Double, Optional ByVal desviacion As Double = 0, Optional ByVal factor As Double = 1)

            Dim SumaRojo, SumaVerde, SumaAzul, SumaMascara As Long
            Dim Rojo, verde, azul, alfa As Integer
            nivel(bmp)

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
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, verde, azul))
                Next
            Next

            Return bmp
        End Function

        Function mascara3x3Gris(ByVal bmp As Bitmap, ByVal matrizMascara(,) As Double, Optional ByVal desviacion As Double = 0, Optional ByVal factor As Double = 1)

            Dim SumaRojo, SumaVerde, SumaAzul, SumaMascara As Long
            Dim Rojo, verde, azul, grises, alfa As Integer

            nivel(bmp)

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
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, grises, grises, grises))
                Next
            Next

            Return bmp
        End Function

        '*********************************************************************************************
        '*********************************************************************************************
        'Clase anidada para gestión de máscaras

        Public Class mascaras
            Private Tipomascara As String
            Private coefmascara(2, 2) As Double
            Private objeto As New tratamiento
            Private Sub matrizCoef(ByVal Tipomascara As String)
                Select Case Tipomascara
                    Case "LOW9"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                        coefmascara(1, 0) = 1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                    Case "LOW10"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                        coefmascara(1, 0) = 1 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                    Case "LOW12"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                        coefmascara(1, 0) = 1 : coefmascara(1, 1) = 4 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                    Case "HIGH1a"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 9 : coefmascara(1, 2) = -1
                        coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                    Case "HIGH1b"
                        coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 5 : coefmascara(1, 2) = -1
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                    Case "HIGH16"
                        coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 20 : coefmascara(1, 2) = -1
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                    Case "Rest1"
                        coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = 0 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 0
                    Case "Rest2"
                        coefmascara(0, 0) = 0 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 0
                    Case "Rest3"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = 0 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 0
                    Case "Lap1"
                        coefmascara(0, 0) = 0 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = 1 : coefmascara(1, 1) = -4 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 0
                    Case "Lap2"
                        coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 4 : coefmascara(1, 2) = -1
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                    Case "Lap3"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 8 : coefmascara(1, 2) = -1
                        coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                    Case "Lap4"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = -2 : coefmascara(0, 2) = 1
                        coefmascara(1, 0) = -2 : coefmascara(1, 1) = 4 : coefmascara(1, 2) = -2
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = -2 : coefmascara(2, 2) = 1
                    Case "Lap5"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = 0 : coefmascara(1, 1) = 4 : coefmascara(1, 2) = 0
                        coefmascara(2, 0) = -1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                    Case "Lap6"
                        coefmascara(0, 0) = 0 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = 0 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = 0
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                    Case "Lap7"
                        coefmascara(0, 0) = 0 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = -1
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 0
                    Case "GradEste"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = -1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                    Case "GradSudeste"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 1
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                    Case "GradSur"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = 1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                    Case "GradOeste"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = 1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = -1
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = -1
                    Case "GradNoroe"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                        coefmascara(1, 0) = 1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = -1
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                    Case "GradNorte"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                        coefmascara(1, 0) = 1 : coefmascara(1, 1) = -2 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                    Case "EmbEste"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = 1
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = -1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = 1
                    Case "EmbSudeste"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                    Case "EmbSur"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = 0 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                    Case "EmbOeste"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = 1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = -1
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                    Case "EmbNoreste"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = 1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = -1
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                    Case "EmbNorte"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                        coefmascara(1, 0) = 0 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 0
                        coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                    Case "SobelV"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 2 : coefmascara(0, 2) = 1
                        coefmascara(1, 0) = 0 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 0
                        coefmascara(2, 0) = -1 : coefmascara(2, 1) = -2 : coefmascara(2, 2) = -1
                    Case "SobelH"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = 2 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -2
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                    Case "SobelDiagonal1"
                        coefmascara(0, 0) = -2 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 2
                    Case "SobelDiagonal2"
                        coefmascara(0, 0) = 0 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 2
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = -2 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0

                    Case "PrewittV"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = 0 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 0
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                    Case "PrewittH"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = 1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -1
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                    Case "PrewittDiag1"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 1
                    Case "PrewittDiag2"
                        coefmascara(0, 0) = 0 : coefmascara(0, 1) = 1 : coefmascara(0, 2) = 1
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = 0
                    Case "Verticales"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = 2 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = 2
                        coefmascara(2, 0) = -1 : coefmascara(2, 1) = -1 : coefmascara(2, 2) = -1
                    Case "Horizontales"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = 2 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 2 : coefmascara(1, 2) = -1
                        coefmascara(2, 0) = -1 : coefmascara(2, 1) = 2 : coefmascara(2, 2) = -1
                    Case "Repujado"
                        coefmascara(0, 0) = -2 : coefmascara(0, 1) = -1 : coefmascara(0, 2) = 0
                        coefmascara(1, 0) = -1 : coefmascara(1, 1) = 1 : coefmascara(1, 2) = 1
                        coefmascara(2, 0) = 0 : coefmascara(2, 1) = 1 : coefmascara(2, 2) = 2
                    Case "Kirsch0"
                        coefmascara(0, 0) = -3 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = 5
                        coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 5
                        coefmascara(2, 0) = -3 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = 5
                    Case "Kirsch45"
                        coefmascara(0, 0) = -3 : coefmascara(0, 1) = 5 : coefmascara(0, 2) = 5
                        coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 5
                        coefmascara(2, 0) = -3 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = -3
                    Case "Kirsch90"
                        coefmascara(0, 0) = 5 : coefmascara(0, 1) = 5 : coefmascara(0, 2) = 5
                        coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                        coefmascara(2, 0) = -3 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = -3
                    Case "Kirsch135"
                        coefmascara(0, 0) = 5 : coefmascara(0, 1) = 5 : coefmascara(0, 2) = 5
                        coefmascara(1, 0) = 5 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                        coefmascara(2, 0) = -3 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = -3
                    Case "Kirsch180"
                        coefmascara(0, 0) = 5 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = -3
                        coefmascara(1, 0) = 5 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                        coefmascara(2, 0) = 5 : coefmascara(2, 1) = -3 : coefmascara(2, 2) = -3
                    Case "Kirsch225"
                        coefmascara(0, 0) = -3 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = -3
                        coefmascara(1, 0) = 5 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                        coefmascara(2, 0) = 5 : coefmascara(2, 1) = 5 : coefmascara(2, 2) = -3
                    Case "Kirsch270"
                        coefmascara(0, 0) = -3 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = -3
                        coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -3
                        coefmascara(2, 0) = 5 : coefmascara(2, 1) = 5 : coefmascara(2, 2) = 5
                    Case "Kirsch315"
                        coefmascara(0, 0) = -3 : coefmascara(0, 1) = -3 : coefmascara(0, 2) = -3
                        coefmascara(1, 0) = -3 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 5
                        coefmascara(2, 0) = -3 : coefmascara(2, 1) = 5 : coefmascara(2, 2) = 5
                    Case "FRH"
                        coefmascara(0, 0) = 1 : coefmascara(0, 1) = 0 : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = Math.Sqrt(2) : coefmascara(1, 1) = 0 : coefmascara(1, 2) = -Math.Sqrt(2)
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = 0 : coefmascara(2, 2) = -1
                    Case "FRV"
                        coefmascara(0, 0) = -1 : coefmascara(0, 1) = -Math.Sqrt(2) : coefmascara(0, 2) = -1
                        coefmascara(1, 0) = 0 : coefmascara(1, 1) = 0 : coefmascara(1, 2) = 0
                        coefmascara(2, 0) = 1 : coefmascara(2, 1) = Math.Sqrt(2) : coefmascara(2, 2) = 1

                End Select
            End Sub
            Function tipodeMascara(ByVal nombreMascara As String)

                matrizCoef(nombreMascara)
                Return coefmascara

            End Function
            Function LowPasscoef9(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "LOW9"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function

            Function LowPasscoef10(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "LOW10"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function

            Function LowPasscoef12(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "LOW12"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function

            Function HighPasscoef1a(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "HIGH1a"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function

            Function HighPasscoef1b(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "HIGH1b"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function

            Function HighPasscoef16(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "HIGH16"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function

            Function RealceBordesResta1(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Rest1"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function RealceBordesResta2(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Rest2"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function RealceBordesResta3(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Rest3"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function

            Function BordeLaplaciano1(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Lap1"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function BordeLaplaciano2(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Lap2"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function BordeLaplaciano3(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Lap3"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function BordeLaplaciano4(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Lap4"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function BordeLaplacianoDiagon(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Lap5"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function BordeLaplacianoHoriz(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Lap6"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function BordeLaplacianoVertic(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Lap7"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function ContornoGradienteEste(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "GradEste"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function ContornoGradienteSudeste(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "GradSudeste"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function ContornoGradienteSur(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "GradSur"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function ContornoGradienteOeste(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "GradOeste"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function ContornoGradienteNoroeste(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "GradNoroe"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function ContornoGradienteNorte(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "GradNorte"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function RelieveBordeEste(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "EmbEste"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function RelieveBordeSudeste(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "EmbSudeste"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function RelieveBordeSur(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "EmbSur"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function RelieveBordeOeste(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "EmbOeste"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function RelieveBordeNoreste(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "EmbNoreste"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function RelieveBordeNorte(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "EmbNorte"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function SobelHorizontal(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "SobelH"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function SobelVertical(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "SobelV"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function SobelHorizontal2(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "SobelH"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, 0, 4)
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, 0, 4)
                Return bmp

            End Function
            Function SobelVertical2(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "SobelV"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, 0, 4)
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, 0, 4)
                Return bmp

            End Function
            Function SobelDiagonal1a(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "SobelDiagonal1"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function SobelDiagonal2a(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "SobelDiagonal2"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function SobelDiagonal1b(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "SobelDiagonal1"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, 0, 4)
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, 0, 4)
                Return bmp

            End Function
            Function SobelDiagonal2b(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "SobelDiagonal2"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, 0, 4)
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, 0, 4)
                Return bmp

            End Function

            Function PrewittHoriz(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "PrewittH"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function PrewittVert(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "PrewittV"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function PrewittDiagonal1(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "PrewittDiag1"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function PrewittDiagonal2(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "PrewittDiag2"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function

            Function PrewittHoriz2(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "PrewittH"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , 3)
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , 3)
                Return bmp

            End Function
            Function PrewittVert2(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "PrewittV"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , 3)
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , 3)
                Return bmp

            End Function
            Function PrewittDiagonal1b(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "PrewittDiag1"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , 3)
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , 3)
                Return bmp

            End Function
            Function PrewittDiagonal2b(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "PrewittDiag2"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , 3)
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , 3)
                Return bmp
            End Function
            Function lineasVerticales(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Verticales"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function lineasHorizontales(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Horizontales"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function repujado(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Repujado"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function bordesKirsch0º(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Kirsch0"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function bordesKirsch45º(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Kirsch45"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function bordesKirsch90º(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Kirsch90"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function bordesKirsch135º(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Kirsch135"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function bordesKirsch180º(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Kirsch180"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function bordesKirsch225º(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Kirsch225"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function bordesKirsch270º(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Kirsch270"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function
            Function bordesKirsch315º(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "Kirsch315"
                matrizCoef(Tipomascara)

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , )
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , )
                Return bmp

            End Function

            Function FreiChenHori(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "FRH"
                matrizCoef(Tipomascara)
                Dim cuenta As Double
                cuenta = 1 / (2 + Math.Sqrt(2))

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , cuenta)
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , cuenta)
                Return bmp

            End Function

            Function FreiChenVert(ByVal bmp As Bitmap, Optional ByVal gris As Boolean = False)
                Tipomascara = "FRV"
                matrizCoef(Tipomascara)
                Dim cuenta As Double
                cuenta = 1 / (2 + Math.Sqrt(2))

                If gris = True Then bmp = objeto.mascara3x3Gris(bmp, coefmascara, , cuenta)
                If gris = False Then bmp = objeto.mascara3x3RGB(bmp, coefmascara, , cuenta)
                Return bmp

            End Function








        End Class


        '*********************************************************************************************
        '*********************************************************************************************
        'Fin de clase



        Function filtroponderado(ByVal bmp As Bitmap, Optional ByVal Rr As Double = 1, Optional ByVal Rg As Double = 0, Optional ByVal Rb As Double = 0, Optional ByVal Gr As Double = 0, Optional ByVal Gg As Double = 1, Optional ByVal Gb As Double = 0, Optional ByVal Br As Double = 0, Optional ByVal Bg As Double = 0, Optional ByVal Bb As Double = 1)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeaux, Azulaux As UInteger 'Declaramos tres variables que almacenarán los colores

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = (Niveles(i, j).R) 'Realizamos la inversión de los colores
                    Verde = (Niveles(i, j).G) 'Realizamos la inversión de los colores
                    Azul = (Niveles(i, j).B) 'Realizamos la inversión de los colores
                    Rojoaux = CInt(Rojo * Rr + Verde * Rg + Azul * Rb)
                    Verdeaux = CInt(Rojo * Gr + Verde * Gg + Azul * Gb)
                    Azulaux = CInt(Rojo * Br + Verde * Bg + Azul * Bb)
                    If Rojoaux > 255 Then Rojoaux = 255
                    If Verdeaux > 255 Then Verdeaux = 255
                    If Azulaux > 255 Then Azulaux = 255
                    Rojo = Rojoaux : Verde = Verdeaux : Azul = Azulaux
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos

                Next
            Next
            Return bmp
        End Function


        Function desenfoqueHorizontal(ByVal bmp As Bitmap, Optional ByVal desenfoque As Short = 2)
            nivel(bmp)
            Dim desenfoquePos, desenfoqueNeg As Short
            If desenfoque > 0 Then desenfoquePos = desenfoque : desenfoqueNeg = 0 Else desenfoqueNeg = desenfoque : desenfoquePos = 0

            Dim Rojoaux, Verdeaux, Azulaux As UInteger 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux1, Verdeaux1, Azulaux1 As UInteger 'Declaramos tres variables que almacenarán los colores
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 - desenfoqueNeg To Niveles.GetUpperBound(0) - desenfoquePos  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojoaux = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Rojoaux1 = Niveles(i + desenfoque, j).R 'Realizamos la inversión de los colores
                    Verdeaux = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Verdeaux1 = Niveles(i + desenfoque, j).G 'Realizamos la inversión de los colores
                    Azulaux = Niveles(i, j).B 'Realizamos la inversión de los colores
                    Azulaux1 = Niveles(i + desenfoque, j).B 'Realizamos la inversión de los colores
                    Rojoaux = CInt(Rojoaux + Rojoaux1) / 2
                    Verdeaux = CInt(Verdeaux + Verdeaux1) / 2
                    Azulaux = CInt(Azulaux + Azulaux1) / 2
                    Rojo = Rojoaux : Verde = Verdeaux : Azul = Azulaux
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function desenfoqueVertical(ByVal bmp As Bitmap, Optional ByVal desenfoque As Short = 2)
            nivel(bmp)
            Dim desenfoquePos, desenfoqueNeg As Short
            If desenfoque > 0 Then desenfoquePos = desenfoque : desenfoqueNeg = 0 Else desenfoqueNeg = desenfoque : desenfoquePos = 0

            Dim Rojoaux, Verdeaux, Azulaux As UInteger 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux1, Verdeaux1, Azulaux1 As UInteger 'Declaramos tres variables que almacenarán los colores
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)   'Recorremos la matriz
                For j = 0 - desenfoqueNeg To Niveles.GetUpperBound(1) - desenfoquePos
                    Rojoaux = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Rojoaux1 = Niveles(i, j + desenfoque).R 'Realizamos la inversión de los colores
                    Verdeaux = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Verdeaux1 = Niveles(i, j + desenfoque).G 'Realizamos la inversión de los colores
                    Azulaux = Niveles(i, j).B 'Realizamos la inversión de los colores
                    Azulaux1 = Niveles(i, j + desenfoque).B 'Realizamos la inversión de los colores
                    Rojoaux = CInt(Rojoaux + Rojoaux1) / 2
                    Verdeaux = CInt(Verdeaux + Verdeaux1) / 2
                    Azulaux = CInt(Azulaux + Azulaux1) / 2
                    Rojo = Rojoaux : Verde = Verdeaux : Azul = Azulaux
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function desenfoqueHorVert(ByVal bmp As Bitmap, Optional ByVal desenfoqueHor As Short = 2, Optional ByVal desenfoqueVer As Short = 2)
            nivel(bmp)
            Dim desenfoquePos, desenfoqueNeg As Short
            If desenfoqueHor > 0 Then desenfoquePos = desenfoqueHor : desenfoqueNeg = 0 Else desenfoqueNeg = desenfoqueHor : desenfoquePos = 0

            Dim desenfoquePos1, desenfoqueNeg1 As Short
            If desenfoqueVer > 0 Then desenfoquePos1 = desenfoqueVer : desenfoqueNeg1 = 0 Else desenfoqueNeg1 = desenfoqueVer : desenfoquePos1 = 0


            Dim Rojoaux, Verdeaux, Azulaux As UInteger 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux1, Verdeaux1, Azulaux1 As UInteger 'Declaramos tres variables que almacenarán los colores
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 - desenfoqueNeg To Niveles.GetUpperBound(0) - desenfoquePos   'Recorremos la matriz
                For j = 0 - desenfoqueNeg1 To Niveles.GetUpperBound(1) - desenfoquePos1
                    Rojoaux = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Rojoaux1 = Niveles(i + desenfoqueHor, j + desenfoqueVer).R 'Realizamos la inversión de los colores
                    Verdeaux = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Verdeaux1 = Niveles(i + desenfoqueHor, j + desenfoqueVer).G 'Realizamos la inversión de los colores
                    Azulaux = Niveles(i, j).B 'Realizamos la inversión de los colores
                    Azulaux1 = Niveles(i + desenfoqueHor, j + desenfoqueVer).B 'Realizamos la inversión de los colores
                    Rojoaux = CInt(Rojoaux + Rojoaux1) / 2
                    Verdeaux = CInt(Verdeaux + Verdeaux1) / 2
                    Azulaux = CInt(Azulaux + Azulaux1) / 2
                    Rojo = Rojoaux : Verde = Verdeaux : Azul = Azulaux
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function



        Function contornos(ByVal bmp As Bitmap, ByVal contorno As Integer)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim i, j As Long
            Dim color1 As Color
            Dim bmp2 As New Bitmap(bmp)
            undo(bmp2)
            Dim almacen(,) As Integer
            ReDim almacen(bmp.Width, bmp.Height)
            'para que no se desborde
            For i = 0 To bmp.Width - 1 'Recorremos la matriz
                For j = 0 To bmp.Height - 1
                    color1 = bmp.GetPixel(i, j)
                    almacen(i, j) = (color1.R * 70 + color1.G * 150 + color1.B * 29) / 256
                Next
            Next
            For i = 1 To bmp.Width - 1
                For j = 1 To bmp.Height - 1
                    If Math.Abs(almacen(i, j) - almacen(i, j - 1)) > contorno Or Math.Abs(almacen(i, j) - almacen(i - 1, j)) > contorno Then
                        bmp.SetPixel(i, j, Color.Black)
                    Else
                        bmp.SetPixel(i, j, Color.White)
                    End If
                Next
            Next
            Return bmp
        End Function

        Function contornos(ByVal bmp As Bitmap, ByVal contorno As Integer, ByVal valorrojo As UInteger, ByVal valorverde As UInteger, ByVal valorazul As UInteger)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim i, j As Long
            Dim color1 As Color
            Dim bmp2 As New Bitmap(bmp)
            undo(bmp2)
            Dim almacen(,) As Integer
            ReDim almacen(bmp.Width, bmp.Height)
            'para que no se desborde
            For i = 0 To bmp.Width - 1 'Recorremos la matriz
                For j = 0 To bmp.Height - 1
                    color1 = bmp.GetPixel(i, j)
                    almacen(i, j) = (color1.R * valorrojo + color1.G * valorverde + color1.B * valorazul) / 256
                Next
            Next
            For i = 1 To bmp.Width - 1
                For j = 1 To bmp.Height - 1
                    If Math.Abs(almacen(i, j) - almacen(i, j - 1)) > contorno Or Math.Abs(almacen(i, j) - almacen(i - 1, j)) > contorno Then
                        bmp.SetPixel(i, j, Color.Black)
                    Else
                        bmp.SetPixel(i, j, Color.White)
                    End If
                Next
            Next
            Return bmp

        End Function

        Function cuadricula(ByVal bmp As Bitmap, Optional ByVal horizontal As Integer = 20, Optional ByVal vertical As Integer = 20, Optional ByVal mensajeaviso As Boolean = False)

            If mensajeaviso = True Then If horizontal = 0 Or vertical = 0 Then MessageBox.Show("El valor no puede ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : Return bmp
            nivel(bmp)
            For i = 0 To Niveles.GetUpperBound(0) Step horizontal   'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0))
                Next
            Next
            quitar2(bmp, vertical)

            Return bmp
        End Function
        Private Function quitar2(ByVal bmp As Bitmap, ByVal vertical As Integer)
            nivel(bmp)

            For i = 0 To Niveles.GetUpperBound(0)   'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1) Step vertical
                    bmp.SetPixel(i, j, Color.FromArgb(0, 0, 0))
                Next
            Next
            Return bmp
        End Function

        Function cuadriculaColor(ByVal bmp As Bitmap, ByVal colorHorizontal As Color, ByVal colorVertical As Color, Optional ByVal horizontal As Integer = 20, Optional ByVal vertical As Integer = 20, Optional ByVal mensajeaviso As Boolean = False)

            If mensajeaviso = True Then If horizontal = 0 Or vertical = 0 Then MessageBox.Show("El valor no puede ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error) : Return bmp
            nivel(bmp)
            For i = 0 To Niveles.GetUpperBound(0) Step horizontal   'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    bmp.SetPixel(i, j, colorHorizontal)
                Next
            Next
            quitar2Color(bmp, vertical, colorVertical)

            Return bmp
        End Function
        Private Function quitar2Color(ByVal bmp As Bitmap, ByVal vertical As Integer, ByVal colorVertical As Color)
            nivel(bmp)

            For i = 0 To Niveles.GetUpperBound(0)   'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1) Step vertical
                    bmp.SetPixel(i, j, colorVertical)
                Next
            Next
            Return bmp
        End Function
        Function reducirX2bitmap(ByVal bmp As Bitmap, Optional ByVal ancho As Boolean = True, Optional ByVal alto As Boolean = True)
            If (ancho = True And alto = True) Then
                Dim bmpaxu As New Bitmap(bmp, bmp.Width / 2, bmp.Height / 2)
                Return bmpaxu
            ElseIf (ancho = True And alto = False) Then
                Dim bmpaxu As New Bitmap(bmp, bmp.Width / 2, bmp.Height)
                Return bmpaxu
            Else
                Dim bmpaxu As New Bitmap(bmp, bmp.Width, bmp.Height / 2)
                Return bmpaxu
            End If
        End Function

        Function reducirX2(ByVal bmp As Bitmap, Optional ByVal ancho As Boolean = True, Optional ByVal alto As Boolean = True)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            If (ancho = True And alto = True) Then
                bmp = reducirancho(bmp)
                bmp = reduciralto(bmp)

            End If

            If (ancho = True And alto = False) Then
                bmp = reducirancho(bmp)

            End If
            If (ancho = False And alto = True) Then
                bmp = reduciralto(bmp)

            End If
            undo(bmp)
            Return bmp

        End Function

        Function aumentarX2bitmap(ByVal bmp As Bitmap, Optional ByVal ancho As Boolean = True, Optional ByVal alto As Boolean = True)
            If (ancho = True And alto = True) Then
                Dim bmpaxu As New Bitmap(bmp, bmp.Width * 2, bmp.Height * 2)
                Return bmpaxu
            ElseIf (ancho = True And alto = False) Then
                Dim bmpaxu As New Bitmap(bmp, bmp.Width * 2, bmp.Height)
                Return bmpaxu
            Else
                Dim bmpaxu As New Bitmap(bmp, bmp.Width, bmp.Height * 2)
                Return bmpaxu
            End If
        End Function

        Function aumentarX2(ByVal bmp As Bitmap, Optional ByVal ancho As Boolean = True, Optional ByVal alto As Boolean = True)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            If (ancho = True And alto = True) Then
                bmp = aumentarancho(bmp)
                bmp = aumentaralto(bmp)

            End If

            If (ancho = True And alto = False) Then
                bmp = aumentarancho(bmp)

            End If
            If (ancho = False And alto = True) Then
                bmp = aumentaralto(bmp)

            End If
            undo(bmp)
            Return bmp

        End Function
        Private Function aumentarancho(ByVal bmp As Bitmap)

            Dim width, height As Integer
            width = bmp.Width * 2 - 1
            If width Mod 2 <> 0 Then width -= 1

            height = bmp.Height
            Dim bmp2 As New Bitmap(width, height)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen

            ReDim Niveles2(width - 1, height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            Dim b As Integer
            Dim rojoaux, verdeaux, azulaux As Byte 'Variables auxiliares
            For i = 0 To width - 1  'Recorremos la matriz a lo ancho
                For j = 0 To height - 1 'Recorremos la matriz a lo largo
                    b = i / 2
                    Niveles2(i, j) = bmp.GetPixel(b, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                    rojoaux = Niveles2(i, j).R
                    verdeaux = Niveles2(i, j).G
                    azulaux = Niveles2(i, j).B
                    bmp2.SetPixel(i, j, Color.FromArgb(rojoaux, verdeaux, azulaux))
                Next
            Next
            Return bmp2
        End Function

        Private Function aumentaralto(ByVal bmp As Bitmap)

            Dim width, height As Integer
            height = bmp.Height * 2 - 1
            If height Mod 2 <> 0 Then height -= 1

            width = bmp.Width
            Dim bmp2 As New Bitmap(width, height)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen

            ReDim Niveles2(width - 1, height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            Dim b As Integer
            Dim rojoaux, verdeaux, azulaux As Byte 'Variables auxiliares
            For i = 0 To width - 1  'Recorremos la matriz a lo ancho
                For j = 0 To height - 1 'Recorremos la matriz a lo largo
                    b = j / 2
                    Niveles2(i, j) = bmp.GetPixel(i, b) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                    rojoaux = Niveles2(i, j).R
                    verdeaux = Niveles2(i, j).G
                    azulaux = Niveles2(i, j).B
                    bmp2.SetPixel(i, j, Color.FromArgb(rojoaux, verdeaux, azulaux))
                Next
            Next
            Return bmp2
        End Function

        Private Function reducirancho(ByVal bmp As Bitmap)

            Dim width, height As Integer
            width = bmp.Width / 2
            If bmp.Width Mod 2 <> 0 Then width += 1
            height = bmp.Height
            Dim bmp2 As New Bitmap(width, height)
            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            ReDim Niveles2(width - 1, bmp.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            Dim b As Integer
            Dim rojoaux, verdeaux, azulaux As Byte 'Variables auxiliares
            For i = 0 To bmp.Width - 1 Step 2 'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 1 'Recorremos la matriz a lo largo
                    b = i / 2
                    Niveles2(b, j) = bmp.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                    rojoaux = Niveles2(b, j).R
                    verdeaux = Niveles2(b, j).G
                    azulaux = Niveles2(b, j).B
                    bmp2.SetPixel(b, j, Color.FromArgb(rojoaux, verdeaux, azulaux))
                Next
            Next
            Return bmp2
        End Function

        Private Function reduciralto(ByVal bmp As Bitmap)

            Dim width, height As Integer
            height = bmp.Height / 2
            If bmp.Height Mod 2 <> 0 Then height += 1
            width = bmp.Width
            Dim bmp2 As New Bitmap(width, height)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen

            ReDim Niveles2(width - 1, bmp.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            Dim b As Integer
            Dim rojoaux, verdeaux, azulaux As Byte 'Variables auxiliares
            For i = 0 To bmp.Width - 1  'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 1 Step 2 'Recorremos la matriz a lo largo
                    b = j / 2
                    Niveles2(i, b) = bmp.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                    rojoaux = Niveles2(i, b).R
                    verdeaux = Niveles2(i, b).G
                    azulaux = Niveles2(i, b).B
                    bmp2.SetPixel(i, b, Color.FromArgb(rojoaux, verdeaux, azulaux))
                Next
            Next

            Return bmp2
        End Function


        Function reducirX2interpolado(ByVal bmp As Bitmap, Optional ByVal ancho As Boolean = True, Optional ByVal alto As Boolean = True)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            If (ancho = True And alto = True) Then
                bmp = reduciranchoInterpolado(bmp)
                bmp = reduciraltoInterpolado(bmp)

            End If

            If (ancho = True And alto = False) Then
                bmp = reduciranchoInterpolado(bmp)

            End If
            If (ancho = False And alto = True) Then
                bmp = reduciraltoInterpolado(bmp)

            End If
            undo(bmp)
            Return bmp

        End Function

        Function aumentarX2interpolado(ByVal bmp As Bitmap, Optional ByVal ancho As Boolean = True, Optional ByVal alto As Boolean = True)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            If (ancho = True And alto = True) Then
                bmp = aumentaranchoInterpolado(bmp)
                bmp = aumentaraltoInterpolado(bmp)

            End If

            If (ancho = True And alto = False) Then
                bmp = aumentaranchoInterpolado(bmp)

            End If
            If (ancho = False And alto = True) Then
                bmp = aumentaraltoInterpolado(bmp)

            End If
            undo(bmp)
            Return bmp

        End Function


        Private Function reduciraltoInterpolado(ByVal bmp As Bitmap)
            Dim height As Integer
            height = bmp.Height / 2
            If bmp.Height Mod 2 <> 0 Then height += 1
            Dim bmpInterpolado As New Bitmap(bmp.Width, height)
            Dim Nivelesinterpolados(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            ReDim Nivelesinterpolados(bmpInterpolado.Width - 1, bmpInterpolado.Height - 1)
            Dim b As Integer
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            Dim rojoaux1, verdeaux1, azulaux1 As Double 'Variables auxiliares
            Dim rojointerp, verdeinterp, azuliinterp As Double
            nivel(bmp)
            For i = 0 To bmp.Width - 1  'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 2 'Recorremos la matriz a lo largo
                    rojoaux = Niveles(i, j).R
                    rojoaux1 = Niveles(i, j + 1).R
                    rojointerp = CInt((rojoaux + rojoaux1) / 2)
                    verdeaux = Niveles(i, j).G
                    verdeaux1 = Niveles(i, j + 1).G
                    verdeinterp = CInt((verdeaux + verdeaux1) / 2)
                    azulaux = Niveles(i, j).B
                    azulaux1 = Niveles(i, j + 1).B
                    azuliinterp = CInt((azulaux + azulaux1) / 2)
                    b = j / 2
                    bmpInterpolado.SetPixel(i, b, Color.FromArgb(rojointerp, verdeinterp, azuliinterp))

                Next
            Next
            Return bmpInterpolado
        End Function


        Private Function reduciranchoInterpolado(ByVal bmp As Bitmap)
            Dim width As Integer
            width = bmp.Width / 2
            If bmp.Width Mod 2 <> 0 Then width += 1
            Dim bmpInterpolado As New Bitmap(width, bmp.Height)
            Dim Nivelesinterpolados(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            ReDim Nivelesinterpolados(bmpInterpolado.Width - 1, bmpInterpolado.Height - 1)
            Dim b As Integer
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            Dim rojoaux1, verdeaux1, azulaux1 As Double 'Variables auxiliares
            Dim rojointerp, verdeinterp, azuliinterp As Double
            nivel(bmp)
            For i = 0 To bmp.Width - 2  'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 1 'Recorremos la matriz a lo largo
                    rojoaux = Niveles(i, j).R
                    rojoaux1 = Niveles(i + 1, j).R
                    rojointerp = CInt((rojoaux + rojoaux1) / 2)
                    verdeaux = Niveles(i, j).G
                    verdeaux1 = Niveles(i + 1, j).G
                    verdeinterp = CInt((verdeaux + verdeaux1) / 2)
                    azulaux = Niveles(i, j).B
                    azulaux1 = Niveles(i + 1, j).B
                    azuliinterp = CInt((azulaux + azulaux1) / 2)
                    b = i / 2
                    bmpInterpolado.SetPixel(b, j, Color.FromArgb(rojointerp, verdeinterp, azuliinterp))
                Next
            Next
            Return bmpInterpolado
        End Function


        Private Function aumentaraltoInterpolado(ByVal bmp As Bitmap)

            Dim bmp2 As New Bitmap(bmp.Width, bmp.Height * 2 - 1)
            Dim bmpInterpolado As New Bitmap(bmp.Width, bmp.Height - 1)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Dim Nivelesinterpolados(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen

            ReDim Niveles2(bmp.Width - 1, bmp.Height * 2 - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            ReDim Nivelesinterpolados(bmp.Width - 1, bmp.Height - 1)

            Dim b As Integer
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            Dim rojoaux1, verdeaux1, azulaux1 As Double 'Variables auxiliares
            Dim rojointerp, verdeinterp, azuliinterp As Double
            nivel(bmp)
            For i = 0 To bmp.Width - 1  'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 2 'Recorremos la matriz a lo largo
                    rojoaux = Niveles(i, j).R
                    rojoaux1 = Niveles(i, j + 1).R
                    rojointerp = CInt((rojoaux + rojoaux1) / 2)
                    verdeaux = Niveles(i, j).G
                    verdeaux1 = Niveles(i, j + 1).G
                    verdeinterp = CInt((verdeaux + verdeaux1) / 2)
                    azulaux = Niveles(i, j).B
                    azulaux1 = Niveles(i, j + 1).B
                    azuliinterp = CInt((azulaux + azulaux1) / 2)
                    bmpInterpolado.SetPixel(i, j, Color.FromArgb(rojointerp, verdeinterp, azuliinterp))
                    Nivelesinterpolados(i, j) = bmpInterpolado.GetPixel(i, j)
                Next

            Next
            For i = 0 To bmp2.Width - 1  'Recorremos la matriz a lo ancho
                For j = 0 To bmp2.Height - 2 Step 2 'Recorremos la matriz a lo largo
                    b = j / 2
                    rojoaux = Niveles(i, b).R
                    verdeaux = Niveles(i, b).G
                    azulaux = Niveles(i, b).B
                    bmp2.SetPixel(i, j, Color.FromArgb(rojoaux, verdeaux, azulaux))

                Next
            Next
            For i = 0 To bmp2.Width - 1  'Recorremos la matriz a lo ancho
                For j = 1 To bmp2.Height - 2 Step 2 'Recorremos la matriz a lo largo
                    b = j / 2
                    rojoaux = Nivelesinterpolados(i, b).R
                    verdeaux = Nivelesinterpolados(i, b).G
                    azulaux = Nivelesinterpolados(i, b).B
                    bmp2.SetPixel(i, j, Color.FromArgb(rojoaux, verdeaux, azulaux))

                Next
            Next
            Return bmp2
        End Function

        Private Function aumentaranchoInterpolado(ByVal bmp As Bitmap)

            Dim bmp2 As New Bitmap(bmp.Width * 2 - 1, bmp.Height)
            Dim bmpInterpolado As New Bitmap(bmp.Width - 1, bmp.Height)

            Dim Niveles2(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen
            Dim Nivelesinterpolados(,) As System.Drawing.Color 'Almacenará los niveles digitales de la imagen

            ReDim Niveles2(bmp.Width * 2 - 1, bmp.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            ReDim Nivelesinterpolados(bmp.Width - 1, bmp.Height - 1)

            Dim b As Integer
            Dim rojoaux, verdeaux, azulaux As Double 'Variables auxiliares
            Dim rojoaux1, verdeaux1, azulaux1 As Double 'Variables auxiliares
            Dim rojointerp, verdeinterp, azuliinterp As Double

            nivel(bmp)


            For i = 0 To bmp.Width - 2  'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 1 'Recorremos la matriz a lo largo
                    rojoaux = Niveles(i, j).R
                    rojoaux1 = Niveles(i + 1, j).R
                    rojointerp = CInt((rojoaux + rojoaux1) / 2)
                    verdeaux = Niveles(i, j).G
                    verdeaux1 = Niveles(i + 1, j).G
                    verdeinterp = CInt((verdeaux + verdeaux1) / 2)
                    azulaux = Niveles(i, j).B
                    azulaux1 = Niveles(i + 1, j).B
                    azuliinterp = CInt((azulaux + azulaux1) / 2)
                    bmpInterpolado.SetPixel(i, j, Color.FromArgb(rojointerp, verdeinterp, azuliinterp))
                    Nivelesinterpolados(i, j) = bmpInterpolado.GetPixel(i, j)
                Next

            Next

            For i = 0 To bmp2.Width - 2 Step 2  'Recorremos la matriz a lo ancho
                For j = 0 To bmp2.Height - 1 'Recorremos la matriz a lo largo
                    b = i / 2
                    rojoaux = Niveles(b, j).R
                    verdeaux = Niveles(b, j).G
                    azulaux = Niveles(b, j).B
                    bmp2.SetPixel(i, j, Color.FromArgb(rojoaux, verdeaux, azulaux))

                Next
            Next

            For i = 1 To bmp2.Width - 2 Step 2  'Recorremos la matriz a lo ancho
                For j = 0 To bmp2.Height - 1 'Recorremos la matriz a lo largo
                    b = i / 2
                    rojoaux = Nivelesinterpolados(b, j).R
                    verdeaux = Nivelesinterpolados(b, j).G
                    azulaux = Nivelesinterpolados(b, j).B
                    bmp2.SetPixel(i, j, Color.FromArgb(rojoaux, verdeaux, azulaux))

                Next
            Next
            Return bmp2
        End Function

        Function redimensionar(ByVal bmp As Bitmap, Optional ByVal ancho As Integer = 500, Optional ByVal alto As Integer = 500)

            Dim bmpaxu As New Bitmap(bmp, ancho, alto)
            Return bmpaxu

        End Function

        Function relacion4_3(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim ancho, alto As Integer
            ancho = bmp.Width
            alto = bmp.Height
            alto = (alto / 4) * 3
            Dim bmpaux As New Bitmap(bmp, ancho, alto)
            Return bmpaux
        End Function
        Function relacion16_9(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim ancho, alto As Integer
            ancho = bmp.Width
            alto = bmp.Height
            alto = (alto / 16) * 9
            Dim bmpaux As New Bitmap(bmp, ancho, alto)
            Return bmpaux
        End Function
        Function relacion3_2(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim ancho, alto As Integer
            ancho = bmp.Width
            alto = bmp.Height
            alto = (alto / 3) * 2
            Dim bmpaux As New Bitmap(bmp, ancho, alto)
            Return bmpaux
        End Function
        Function relacion185_100(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim ancho, alto As Integer
            ancho = bmp.Width
            alto = bmp.Height
            alto = (alto / 1.85) * 1
            Dim bmpaux As New Bitmap(bmp, ancho, alto)
            Return bmpaux
        End Function
        Function relacion239_100(ByVal bmp As Bitmap)
            nivel(bmp)
            Dim ancho, alto As Integer
            ancho = bmp.Width
            alto = bmp.Height
            alto = (alto / 2.39) * 1
            Dim bmpaux As New Bitmap(bmp, ancho, alto)
            Return bmpaux
        End Function


        Function filtro(ByVal bmp As Bitmap, Optional ByVal valorRed As Byte = 0, Optional ByVal salidaRed As Byte = 0, Optional ByVal valorGreen As Byte = 0, Optional ByVal salidaGreen As Byte = 0, Optional ByVal valorBlue As Byte = 0, Optional ByVal salidaBlue As Byte = 0)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R
                    If Rojo = valorRed And salidaRed <> -1 And salidaRed <= 255 Then
                        Rojo = salidaRed
                    End If
                    Verde = Niveles(i, j).G
                    If Verde = valorGreen And salidaGreen <> -1 And salidaGreen <= 255 Then
                        Verde = salidaGreen
                    End If
                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    If Azul = valorBlue And salidaBlue <> -1 And salidaBlue <= 255 Then
                        Azul = salidaBlue
                    End If
                    alfa = Niveles(i, j).A
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        Function filtroRangoRed(ByVal bmp As Bitmap, ByVal valorRedinf As Byte, ByVal valorRedsup As Byte, ByVal salidaRed As Byte)

            If valorRedinf > valorRedsup Then
                MessageBox.Show("El valor inferior debe ser mayor que el superior", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return bmp
            Else
                nivel(bmp)
                Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
                For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                    For j = 0 To Niveles.GetUpperBound(1)
                        Rojo = Niveles(i, j).R
                        If Rojo >= valorRedinf And Rojo <= valorRedsup Then
                            Rojo = salidaRed
                        End If

                        Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                        Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                        alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                    Next
                Next
                Return bmp
            End If
        End Function


        Function filtroRangoBlue(ByVal bmp As Bitmap, ByVal valorBlueinf As Byte, ByVal valorBluesup As Byte, ByVal salidaBlue As Byte)

            If valorBlueinf > valorBluesup Then
                MessageBox.Show("El valor inferior debe ser mayor que el superior", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return bmp
            Else
                nivel(bmp)
                Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
                For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                    For j = 0 To Niveles.GetUpperBound(1)
                        Azul = Niveles(i, j).B
                        If Azul >= valorBlueinf And Azul <= valorBluesup Then
                            Azul = salidaBlue
                        End If

                        Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                        Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                        alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                    Next
                Next
                Return bmp
            End If
        End Function


        Function filtroRangoGreen(ByVal bmp As Bitmap, ByVal valorGreeninf As Byte, ByVal valorGreensup As Byte, ByVal salidaGreen As Byte)

            If valorGreeninf > valorGreensup Then
                MessageBox.Show("El valor inferior debe ser mayor que el superior", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return bmp
            Else
                nivel(bmp)
                Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
                For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                    For j = 0 To Niveles.GetUpperBound(1)
                        Verde = Niveles(i, j).G
                        If Verde >= valorGreeninf And Verde <= valorGreensup Then
                            Verde = salidaGreen
                        End If
                        Rojo = Niveles(i, j).R
                        Azul = Niveles(i, j).B
                        alfa = Niveles(i, j).A
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                    Next
                Next
                Return bmp
            End If
        End Function

        Public Function unir(ByVal bmp As Bitmap, ByVal bmp2 As Bitmap)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim PicColor1, PicColor2 As Color
            Dim r, g, b As Integer
            Dim x As Integer
            Dim y As Integer
            Dim alto, ancho As Integer
            Dim bmp3 As New Bitmap(bmp)
            undo(bmp3)


            Dim imgtemp1 As New Bitmap(bmp)
            Dim imgtemp2 As New Bitmap(bmp2)

            If imgtemp1.Height > imgtemp2.Height Then alto = imgtemp2.Height Else alto = imgtemp1.Height
            If imgtemp1.Width > imgtemp2.Width Then ancho = imgtemp2.Width Else ancho = imgtemp1.Width
            Dim imgtemp3 As New Bitmap(ancho, alto)

            Dim imgtemp4 As New Bitmap(bmp, imgtemp3.Width, imgtemp3.Height)
            Dim imgtemp5 As New Bitmap(bmp2, imgtemp3.Width, imgtemp3.Height)




            For x = 0 To imgtemp3.Width - 1
                For y = 0 To imgtemp3.Height - 1
                    PicColor1 = imgtemp4.GetPixel(x, y)
                    PicColor2 = imgtemp5.GetPixel(x, y)
                    r = (CInt(PicColor1.R) + CInt(PicColor2.R)) / 2
                    g = (CInt(PicColor1.G) + CInt(PicColor2.G)) / 2
                    b = (CInt(PicColor1.B) + CInt(PicColor2.B)) / 2
                    imgtemp3.SetPixel(x, y, Color.FromArgb(r, g, b))
                Next
            Next
            Return imgtemp3

        End Function


        Sub histogramaR(ByVal bmp As Bitmap, ByVal PictureBoxHistograma As PictureBox, Optional ByVal formato As Boolean = True)
            Dim Picture1 As Graphics = PictureBoxHistograma.CreateGraphics
            Dim pincelborde As Pen
            pincelborde = New Pen(Color.Black, 1)
            If formato = True Then
                PictureBoxHistograma.Width = 258
                Dim colorfondo As New Color
                colorfondo = Color.LightGray
                Picture1.Clear(colorfondo)
                Picture1.DrawRectangle(pincelborde, New Rectangle(New Point(0, 0), New Size(257, PictureBoxHistograma.Height - 1)))

            End If

            nivel(bmp)
            Dim Rojo As Byte 'Declaramos tres variables que almacenarán los colores
            Dim matrizRojo(255) As UInteger
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    matrizRojo(Rojo) += 1
                Next
            Next


            Dim lapizRojo As Pen
            lapizRojo = New Pen(Color.Red, 1)
            Dim valoreshistalto(255) As UInteger
            Dim masalto As UInteger
            Dim coef_reduc As Double

            valoreshistalto = matrizRojo.Clone
            Array.Sort(valoreshistalto)
            masalto = valoreshistalto(255)
            coef_reduc = PictureBoxHistograma.Height / masalto

            For i = 0 To 255
                matrizRojo(i) = CInt(matrizRojo(i) * coef_reduc)
                Picture1.DrawLine(lapizRojo, i + 1, PictureBoxHistograma.Height, i + 1, PictureBoxHistograma.Height - matrizRojo(i))

            Next

            If formato = True Then Picture1.DrawRectangle(pincelborde, New Rectangle(New Point(0, 0), New Size(257, PictureBoxHistograma.Height - 1)))


        End Sub


        Sub histogramaG(ByVal bmp As Bitmap, ByVal PictureBoxHistograma As PictureBox, Optional ByVal formato As Boolean = True)
            Dim Picture1 As Graphics = PictureBoxHistograma.CreateGraphics
            Dim pincelborde As Pen
            pincelborde = New Pen(Color.Black, 1)
            If formato = True Then
                PictureBoxHistograma.Width = 258
                Dim colorfondo As New Color
                colorfondo = Color.LightGray
                Picture1.Clear(colorfondo)
                Picture1.DrawRectangle(pincelborde, New Rectangle(New Point(0, 0), New Size(257, PictureBoxHistograma.Height - 1)))

            End If

            nivel(bmp)
            Dim Verde As Byte 'Declaramos tres variables que almacenarán los colores
            Dim matrizVerde(255) As UInteger
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                    matrizVerde(Verde) += 1
                Next
            Next


            Dim lapizRojo As Pen
            lapizRojo = New Pen(Color.Green, 1)
            Dim valoreshistalto(255) As UInteger
            Dim masalto As UInteger
            Dim coef_reduc As Double

            valoreshistalto = matrizVerde.Clone
            Array.Sort(valoreshistalto)
            masalto = valoreshistalto(255)
            coef_reduc = PictureBoxHistograma.Height / masalto

            For i = 0 To 255
                matrizVerde(i) = CInt(matrizVerde(i) * coef_reduc)
                Picture1.DrawLine(lapizRojo, i + 1, PictureBoxHistograma.Height, i + 1, PictureBoxHistograma.Height - matrizVerde(i))

            Next

            If formato = True Then Picture1.DrawRectangle(pincelborde, New Rectangle(New Point(0, 0), New Size(257, PictureBoxHistograma.Height - 1)))

        End Sub

        Sub histogramaB(ByVal bmp As Bitmap, ByVal PictureBoxHistograma As PictureBox, Optional ByVal formato As Boolean = True)
            Dim Picture1 As Graphics = PictureBoxHistograma.CreateGraphics
            Dim pincelborde As Pen
            pincelborde = New Pen(Color.Black, 1)
            If formato = True Then
                PictureBoxHistograma.Width = 258
                Dim colorfondo As New Color
                colorfondo = Color.LightGray
                Picture1.Clear(colorfondo)
                Picture1.DrawRectangle(pincelborde, New Rectangle(New Point(0, 0), New Size(257, PictureBoxHistograma.Height - 1)))

            End If

            nivel(bmp)
            Dim azul As Byte 'Declaramos tres variables que almacenarán los colores
            Dim matrizAzul(255) As UInteger

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    matrizAzul(azul) += 1
                Next
            Next


            Dim lapizRojo As Pen
            lapizRojo = New Pen(Color.Blue, 1)
            Dim valoreshistalto(255) As UInteger
            Dim masalto As UInteger
            Dim coef_reduc As Double

            valoreshistalto = matrizAzul.Clone
            Array.Sort(valoreshistalto)
            masalto = valoreshistalto(255)
            coef_reduc = PictureBoxHistograma.Height / masalto

            For i = 0 To 255
                matrizAzul(i) = CInt(matrizAzul(i) * coef_reduc)
                Picture1.DrawLine(lapizRojo, i + 1, PictureBoxHistograma.Height, i + 1, PictureBoxHistograma.Height - matrizAzul(i))

            Next

            If formato = True Then Picture1.DrawRectangle(pincelborde, New Rectangle(New Point(0, 0), New Size(257, PictureBoxHistograma.Height - 1)))

        End Sub

        Sub histogramaGris(ByVal bmp As Bitmap, ByVal PictureBoxHistograma As PictureBox, Optional ByVal formato As Boolean = True)

            Dim Picture1 As Graphics = PictureBoxHistograma.CreateGraphics
            Dim pincelborde As Pen
            pincelborde = New Pen(Color.Black, 1)
            If formato = True Then
                PictureBoxHistograma.Width = 258
                Dim colorfondo As New Color
                colorfondo = Color.LightGray
                Picture1.Clear(colorfondo)
                Picture1.DrawRectangle(pincelborde, New Rectangle(New Point(0, 0), New Size(257, PictureBoxHistograma.Height - 1)))

            End If

            nivel(bmp)
            Dim gris As Byte 'Declaramos tres variables que almacenarán los colores
            Dim rojoaux, verdeaux, azulaux As Double
            Dim media As Double
            Dim matrizGris(255) As UInteger

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    rojoaux = Niveles(i, j).R
                    verdeaux = Niveles(i, j).G
                    azulaux = Niveles(i, j).B
                    media = CInt((rojoaux + verdeaux + azulaux) / 3)
                    gris = media 'Realizamos la inversión de los colores
                    matrizGris(gris) += 1
                Next
            Next


            Dim lapizRojo As Pen
            lapizRojo = New Pen(Color.Black, 1)
            Dim valoreshistalto(255) As UInteger
            Dim masalto As UInteger
            Dim coef_reduc As Double

            valoreshistalto = matrizGris.Clone
            Array.Sort(valoreshistalto)
            masalto = valoreshistalto(255)
            coef_reduc = PictureBoxHistograma.Height / masalto

            For i = 0 To 255
                matrizGris(i) = CInt(matrizGris(i) * coef_reduc)
                Picture1.DrawLine(lapizRojo, i + 1, PictureBoxHistograma.Height, i + 1, PictureBoxHistograma.Height - matrizGris(i))

            Next

            If formato = True Then Picture1.DrawRectangle(pincelborde, New Rectangle(New Point(0, 0), New Size(257, PictureBoxHistograma.Height - 1)))

        End Sub

        Sub tabla(ByVal bmp As Bitmap, ByVal DataGridView1 As DataGridView, Optional ByVal Mensajeaviso As Boolean = False, Optional ByVal FormatoCeldas As Boolean = True)

            If Mensajeaviso = True Then MessageBox.Show("Tenga paciencia, esto puede demorarse unos minutos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()
            Dim colum1, colum2, colum3 As New DataGridViewTextBoxColumn

            colum1.Name = "Red"
            colum2.Name = "Green"
            colum3.Name = "Blue"

            DataGridView1.Columns.Add(colum1)
            DataGridView1.Columns.Add(colum2)
            DataGridView1.Columns.Add(colum3)
            nivel(bmp)
            If FormatoCeldas = True Then
                With DataGridView1
                    .BorderStyle = BorderStyle.Fixed3D
                    .CellBorderStyle = DataGridViewCellBorderStyle.Sunken
                    .RowHeadersBorderStyle = _
                        DataGridViewHeaderBorderStyle.Raised
                    .ColumnHeadersBorderStyle = _
                        DataGridViewHeaderBorderStyle.Raised
                    .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    .AdvancedColumnHeadersBorderStyle.All = DataGridViewAdvancedCellBorderStyle.Inset
                End With

            End If

            Dim Rojo, Verde, Azul As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = (Niveles(i, j).R) 'Realizamos la inversión de los colores
                    Verde = (Niveles(i, j).G) 'Realizamos la inversión de los colores
                    Azul = (Niveles(i, j).B) 'Realizamos la inversión de los 
                    DataGridView1.Rows.Add(Rojo, Verde, Azul)
                Next
            Next

        End Sub

        Sub undo(ByVal Pic As Bitmap)

            Picture1 = Pic

        End Sub

        Function undo()
            Return Picture1
        End Function

        Function original()
            Return BItmapOriginal
        End Function

        Function abirImagen(Optional filtrado As Integer = 1)

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
                    BItmapOriginal = Image.FromFile(.FileName)
                    rutaimagen = .FileName
                    Return rutaimagen
                Else
                    Return "-1"
                End If
            End With
        End Function

        Function nombreImagen()
            Dim auxiliar, auxiliar2, nombre_imagen As String
            Dim nombre_imagen2() As String
            auxiliar = rutaimagen
            nombre_imagen2 = Split(auxiliar, "\")
            auxiliar2 = UBound(nombre_imagen2)
            nombre_imagen = nombre_imagen2(auxiliar2)
            Return nombre_imagen
        End Function
        Function extraenombre(ByVal rutaImagene As String)
            Dim auxiliar, auxiliar2, nombre_imagen As String
            Dim nombre_imagen2() As String
            auxiliar = rutaImagene
            nombre_imagen2 = Split(auxiliar, "\")
            auxiliar2 = UBound(nombre_imagen2)
            nombre_imagen = nombre_imagen2(auxiliar2)
            Return nombre_imagen
        End Function
        Function nombreRecurso(ByVal url As String)
            Dim auxiliar, auxiliar2, nombre_imagen As String
            Dim nombre_imagen2() As String
            auxiliar = url
            nombre_imagen2 = Split(auxiliar, "/")
            auxiliar2 = UBound(nombre_imagen2)
            nombre_imagen = nombre_imagen2(auxiliar2)
            Return nombre_imagen
        End Function

        Function cargarrecursoweb(ByVal enlace As String)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Try
                Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(enlace)
                Dim response As System.Net.WebResponse = request.GetResponse()
                Dim responseStream As System.IO.Stream = response.GetResponseStream()
                Dim bmp As New Bitmap(responseStream)
                BItmapOriginal = bmp
                Return bmp

            Catch
                Dim value As New String("error.jpg")
                Dim bmp2 As New Bitmap(value)
                Return bmp2

            End Try
        End Function

        Function cargarrecursoweb(ByVal enlace As String, ByVal imageneError As Image)
            Try
                Dim request As System.Net.WebRequest = System.Net.WebRequest.Create(enlace)
                Dim response As System.Net.WebResponse = request.GetResponse()
                Dim responseStream As System.IO.Stream = response.GetResponseStream()
                Dim bmp As New Bitmap(responseStream)
                Return bmp

            Catch ex As System.Net.WebException
                Dim bmp2 As New Bitmap(imageneError)
                Return bmp2
            Catch ex As UriFormatException
                Dim bmp2 As New Bitmap(imageneError)
                Return bmp2
            End Try

        End Function

        Sub guardarcomo(ByVal bmp As Bitmap, Optional ByVal filtrado As Integer = 3)
            Dim salvar As New SaveFileDialog
            With salvar
                .Filter = "Ficheros BMP|*.bmp" & _
                          "|Ficheros GIF|*.gif" & _
                          "|Ficheros JPG o JPEG|*.jpg;*.jpeg" & _
                          "|Ficheros PNG|*.png" & _
                          "|Ficheros TIFF|*.tif"
                .FilterIndex = filtrado
                .FileName = nombreImagen()
                If (.ShowDialog() = Windows.Forms.DialogResult.OK) Then

                    If salvar.FileName <> "" Then
                        Dim fs As System.IO.FileStream = CType(salvar.OpenFile(), System.IO.FileStream)
                        Select Case salvar.FilterIndex
                            Case 1
                                bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp)
                            Case 2
                                bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Gif)
                            Case 3
                                bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg)
                            Case 4
                                bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Png)
                            Case 5
                                bmp.Save(fs, System.Drawing.Imaging.ImageFormat.Tiff)
                        End Select
                        fs.Close()
                    End If
                End If
            End With
        End Sub
        Private Declare Function SystemParametersInfo Lib "user32" Alias "SystemParametersInfoA" (ByVal uAction As Integer, ByVal uParam As Integer, ByVal lpvParam As String, ByVal fuWinIni As Integer) As Integer
        Sub FondoPantalla(ByVal bmp As Bitmap)
            Const SETDESKWALLPAPER = 20 'Fondo de pantalla
            Const UPDATEINIFILE = &H1 'Fondo de pantalla
            Dim ruta As String
            ruta = System.IO.Directory.GetCurrentDirectory() & "\fondo.jpg"
            bmp.Save(ruta, System.Drawing.Imaging.ImageFormat.Jpeg)
            SystemParametersInfo(SETDESKWALLPAPER, 0, ruta, UPDATEINIFILE)
            My.Computer.FileSystem.DeleteFile(ruta, FileIO.UIOption.AllDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
        End Sub

        Function PropiedadesBitmap(ByVal bmp As Bitmap)

            Dim objeto As New tratamiento
            Dim matrizpropiedades(5) As String
            matrizpropiedades(1) = bmp.Height
            matrizpropiedades(2) = bmp.Width
            matrizpropiedades(3) = bmp.HorizontalResolution
            matrizpropiedades(4) = bmp.VerticalResolution
            matrizpropiedades(5) = bmp.PixelFormat

            Return matrizpropiedades

        End Function

       

        'Efectos
        Function polaroid(ByVal bmp As Bitmap)

            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            Dim bmpaxu As New Bitmap(bmp.Width + 50, bmp.Height + 150)


            For i = 0 To 24  'Recorremos la matriz
                For j = 0 To bmpaxu.Height - 1
                    bmpaxu.SetPixel(i, j, Color.FromArgb(240, 240, 240))
                Next
            Next
            For i = bmpaxu.Width - 25 To bmpaxu.Width - 1 'Recorremos la matriz
                For j = 0 To bmpaxu.Height - 1
                    bmpaxu.SetPixel(i, j, Color.FromArgb(240, 240, 240))
                Next
            Next

            For i = 0 To bmpaxu.Width - 1 'Recorremos la matriz
                For j = 0 To 24
                    bmpaxu.SetPixel(i, j, Color.FromArgb(240, 240, 240))
                Next
            Next
            For i = 0 To bmpaxu.Width - 1 'Recorremos la matriz
                For j = 24 + bmp.Height - 1 To bmpaxu.Height - 1
                    bmpaxu.SetPixel(i, j, Color.FromArgb(240, 240, 240))
                Next
            Next

            For i = 24 To bmp.Width + 23  'Recorremos la matriz
                For j = 24 To (bmp.Height + 23)
                    Rojo = Niveles(i - 24, j - 24).R
                    Verde = Niveles(i - 24, j - 24).G
                    Azul = Niveles(i - 24, j - 24).B
                    alfa = Niveles(i - 24, j - 24).A
                    bmpaxu.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
            Next
            For i = 23 To bmp.Width + 24  'Recorremos la matriz
                bmpaxu.SetPixel(i, 23, Color.FromArgb(0, 0, 0))
                bmpaxu.SetPixel(i, 24 + bmp.Height, Color.FromArgb(0, 0, 0))
            Next
            For i = 23 To bmp.Height + 24  'Recorremos la matriz
                bmpaxu.SetPixel(23, i, Color.FromArgb(0, 0, 0))
                bmpaxu.SetPixel(24 + bmp.Width, i, Color.FromArgb(0, 0, 0))
            Next
            For i = 0 To bmpaxu.Width - 1 'Recorremos la matriz
                bmpaxu.SetPixel(i, 0, Color.FromArgb(0, 0, 0))
                bmpaxu.SetPixel(i, 1, Color.FromArgb(0, 0, 0))
                bmpaxu.SetPixel(i, bmpaxu.Height - 1, Color.FromArgb(0, 0, 0))
                bmpaxu.SetPixel(i, bmpaxu.Height - 2, Color.FromArgb(0, 0, 0))
            Next

            For i = 0 To bmpaxu.Height - 1 'Recorremos la matriz
                bmpaxu.SetPixel(0, i, Color.FromArgb(0, 0, 0))
                bmpaxu.SetPixel(1, i, Color.FromArgb(0, 0, 0))
                bmpaxu.SetPixel(bmpaxu.Width - 1, i, Color.FromArgb(0, 0, 0))
                bmpaxu.SetPixel(bmpaxu.Width - 2, i, Color.FromArgb(0, 0, 0))
            Next



            Return bmpaxu
        End Function

        Function pixelarX3(ByVal bmp As Bitmap)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 1 To Niveles.GetUpperBound(0) - 1 Step 3 'Recorremos la matriz
                For j = 1 To Niveles.GetUpperBound(1) - 1 Step 3
                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    For mi = -1 To 1
                        For mj = -1 To 1
                            bmp.SetPixel(i + mi, j + mj, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                        Next
                    Next

                Next
            Next
            Return bmp
        End Function

        Function pixelarX3interpolado(ByVal bmp As Bitmap)
            Dim objeto As New tratamiento
            Dim interpolado(2, 2) As Double
            interpolado(0, 0) = 1 : interpolado(0, 1) = 1 : interpolado(0, 2) = 1
            interpolado(1, 0) = 1 : interpolado(1, 1) = 1 : interpolado(1, 2) = 1
            interpolado(2, 0) = 1 : interpolado(2, 1) = 1 : interpolado(2, 2) = 1
            bmp = objeto.mascara3x3RGB(bmp, interpolado)
            nivel(bmp)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 1 To Niveles.GetUpperBound(0) - 1 Step 3 'Recorremos la matriz
                For j = 1 To Niveles.GetUpperBound(1) - 1 Step 3
                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    For mi = -1 To 1
                        For mj = -1 To 1
                            bmp.SetPixel(i + mi, j + mj, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                        Next
                    Next
                Next
            Next
            Return bmp
        End Function

        Function pixelarX5(ByVal bmp As Bitmap)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 2 To Niveles.GetUpperBound(0) - 2 Step 5 'Recorremos la matriz
                For j = 2 To Niveles.GetUpperBound(1) - 2 Step 5
                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    For mi = -2 To 2
                        For mj = -2 To 2
                            bmp.SetPixel(i + mi, j + mj, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                        Next
                    Next

                Next
            Next
            Return bmp
        End Function

        Function pixelarX7(ByVal bmp As Bitmap)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            For i = 3 To Niveles.GetUpperBound(0) - 3 Step 7 'Recorremos la matriz
                For j = 3 To Niveles.GetUpperBound(1) - 3 Step 7
                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    For mi = -3 To 3
                        For mj = -3 To 3
                            bmp.SetPixel(i + mi, j + mj, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                        Next
                    Next

                Next
            Next
            Return bmp
        End Function

        Function mosaico(ByVal bmp As Bitmap, Optional ByVal numeromosaicohorizontal As Byte = 5, Optional ByVal numeromosaicovertical As Byte = 5)

            Dim ancho = bmp.Width / numeromosaicohorizontal
            Dim alto = bmp.Height / numeromosaicovertical
            Dim bmpaux As New Bitmap(bmp, bmp.Width / numeromosaicohorizontal, bmp.Height / numeromosaicovertical)
            nivel(bmpaux)
            Dim ifinal, iinicial As Long
            Dim jfinal, jinicial As Long
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores


            For s = 0 To numeromosaicovertical - 1
                Select Case s
                    Case 0
                        jinicial = 0 : jfinal = jinicial + Niveles.GetUpperBound(1)
                    Case 1
                        jinicial = Niveles.GetUpperBound(1) : jfinal = jinicial + Niveles.GetUpperBound(1)
                    Case 2
                        jinicial = Niveles.GetUpperBound(1) * 2 : jfinal = jinicial + Niveles.GetUpperBound(1)
                    Case 3
                        jinicial = Niveles.GetUpperBound(1) * 3 : jfinal = jinicial + Niveles.GetUpperBound(1)
                    Case 4
                        jinicial = Niveles.GetUpperBound(1) * 4 : jfinal = jinicial + Niveles.GetUpperBound(1)
                    Case 5
                        jinicial = Niveles.GetUpperBound(1) * 5 : jfinal = jinicial + Niveles.GetUpperBound(1)
                    Case 6
                        jinicial = Niveles.GetUpperBound(1) * 6 : jfinal = jinicial + Niveles.GetUpperBound(1)
                    Case 7
                        jinicial = Niveles.GetUpperBound(1) * 7 : jfinal = jinicial + Niveles.GetUpperBound(1)
                    Case 8
                        jinicial = Niveles.GetUpperBound(1) * 8 : jfinal = jinicial + Niveles.GetUpperBound(1)
                    Case 9
                        jinicial = Niveles.GetUpperBound(1) * 9 : jfinal = jinicial + Niveles.GetUpperBound(1)

                End Select

                For r = 0 To numeromosaicohorizontal - 1

                    Select Case r
                        Case 0
                            iinicial = 0 : ifinal = iinicial + Niveles.GetUpperBound(0)
                        Case 1
                            iinicial = Niveles.GetUpperBound(0) : ifinal = iinicial + Niveles.GetUpperBound(0)
                        Case 2
                            iinicial = Niveles.GetUpperBound(0) * 2 : ifinal = iinicial + Niveles.GetUpperBound(0)
                        Case 3
                            iinicial = Niveles.GetUpperBound(0) * 3 : ifinal = iinicial + Niveles.GetUpperBound(0)
                        Case 4
                            iinicial = Niveles.GetUpperBound(0) * 4 : ifinal = iinicial + Niveles.GetUpperBound(0)
                        Case 5
                            iinicial = Niveles.GetUpperBound(0) * 5 : ifinal = iinicial + Niveles.GetUpperBound(0)
                        Case 6
                            iinicial = Niveles.GetUpperBound(0) * 6 : ifinal = iinicial + Niveles.GetUpperBound(0)
                        Case 7
                            iinicial = Niveles.GetUpperBound(0) * 7 : ifinal = iinicial + Niveles.GetUpperBound(0)
                        Case 8
                            iinicial = Niveles.GetUpperBound(0) * 8 : ifinal = iinicial + Niveles.GetUpperBound(0)
                        Case 9
                            iinicial = Niveles.GetUpperBound(0) * 9 : ifinal = iinicial + Niveles.GetUpperBound(0)

                    End Select



                    For i = iinicial To ifinal 'Recorremos la matriz
                        For j = jinicial To jfinal

                            Rojo = Niveles(i - iinicial, j - jinicial).R 'Realizamos la inversión de los colores
                            Verde = Niveles(i - iinicial, j - jinicial).G 'Realizamos la inversión de los colores
                            Azul = Niveles(i - iinicial, j - jinicial).B 'Realizamos la inversión de los colores
                            alfa = Niveles(i - iinicial, j - jinicial).A
                            bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                        Next
                    Next

                Next
            Next

            nivel(bmp)
            Dim ancho2, alto2 As Integer
            ancho2 = ifinal
            alto2 = jfinal
            Dim bmpfinal As New Bitmap(ancho2, alto2)


            For i = 0 To ancho2 - 1
                For j = 0 To alto2 - 1
                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    bmpfinal.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next

            Dim bmpfinal2 As New Bitmap(bmpfinal, bmp.Width, bmp.Height)
            Return bmpfinal2


        End Function

        Function Oleo(ByVal bmp As Bitmap, Optional ByVal contorno As Byte = 30, Optional ByVal colores As Byte = 210)
            Dim bmp2 As New Bitmap(bmp)

            bmp = Me.contornos(bmp, contorno)

            colores = (256 - colores) / 2
            If colores Mod 2 <> 0 Then colores = colores - 1
            If colores >= 128 Then colores = 127

            bmp2 = Me.reducircolores(bmp2, colores)


            Dim objeto As New tratamiento.mascaras
            bmp2 = objeto.LowPasscoef12(bmp2, False)

            Dim bmp3 As New Bitmap(bmp.Width, bmp.Height)


            nivel(bmp)
            nivelauxiliar(bmp2)

            Dim Rojo, Verde, Azul As Byte 'Declaramos tres variables que almacenarán los colores
            Dim Rojo2, Verde2, Azul2 As Byte 'Declaramos tres variables que almacenarán los colores
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    Rojo2 = Niveles2(i, j).R 'Realizamos la inversión de los colores
                    Verde2 = Niveles2(i, j).G 'Realizamos la inversión de los colores
                    Azul2 = Niveles2(i, j).B 'Realizamos la inversión de los colores
                    If Rojo = 0 And Verde = 0 And Azul = 0 Then
                        bmp3.SetPixel(i, j, Color.FromArgb(Rojo + 50, Verde + 50, Azul + 50)) 'Asignamos a bmp los colores invertidos
                    Else
                        bmp3.SetPixel(i, j, Color.FromArgb(Rojo2, Verde2, Azul2)) 'Asignamos a bmp los colores invertidos
                    End If
                Next
            Next

            Return bmp3
        End Function

        Public Function degradadoHorizontal(ByVal bmp As Bitmap, Optional ByVal minimoHoriz As UInteger = 0, Optional ByVal maximoHoriz As UInteger = 0)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            Dim minimohorizontal As Double = (minimoHoriz * Niveles.GetUpperBound(0)) / 100
            Dim maximohorizontal As Double = (Niveles.GetUpperBound(0) / 100) * maximoHoriz
            Dim valorDegradadoH As Double = ((minimoHoriz + maximoHoriz * 255) / 100) / Niveles.GetUpperBound(0)
            Dim acumulado As UInteger = 1
            Dim degradadoHorizont As UInteger
            Dim alfaaux As Integer

            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                If (i > minimohorizontal And i < maximohorizontal) Then
                    degradadoHorizont = CInt(valorDegradadoH * acumulado)
                    acumulado = acumulado + 1
                End If
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojo = Niveles(i, j).R
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).B
                    If degradadoHorizont > 255 Then degradadoHorizont = 255
                    alfaaux = Niveles(i, j).A
                    alfaaux = alfaaux - degradadoHorizont
                    If alfaaux < 0 Then alfaaux = 0
                    alfa = alfaaux

                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
            Next
            Return bmp
        End Function


        Public Function degradadoVertical(ByVal bmp As Bitmap, Optional ByVal minimoVert As UInteger = 0, Optional ByVal maximoVert As UInteger = 0)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim minimovertical As Double = (minimoVert * Niveles.GetUpperBound(1)) / 100
            Dim maximovertical As Double = (Niveles.GetUpperBound(1) / 100) * maximoVert
            Dim valorDegradadoV As Double = ((minimoVert + maximoVert * 255) / 100) / Niveles.GetUpperBound(1)
            Dim acumulado2 As UInteger = 1
            Dim degradadoVerti As UInteger
            Dim alfaaux As Integer


            For i = 0 To Niveles.GetUpperBound(1)  'Recorremos la matriz
                If (i > minimovertical And i < maximovertical) Then
                    degradadoVerti = CInt(valorDegradadoV * acumulado2)
                    acumulado2 = acumulado2 + 1
                End If
                For j = 0 To Niveles.GetUpperBound(0)
                    Rojo = Niveles(j, i).R
                    Verde = Niveles(j, i).G
                    Azul = Niveles(j, i).B
                    If degradadoVerti > 255 Then degradadoVerti = 255
                    alfaaux = Niveles(j, i).A
                    alfaaux = alfaaux - degradadoVerti
                    If alfaaux < 0 Then alfaaux = 0
                    alfa = alfaaux
                    bmp.SetPixel(j, i, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
            Next
            Return bmp
        End Function

        Public Function degradadoVerticalInvertido(ByVal bmp As Bitmap, Optional ByVal minimoVert As UInteger = 0, Optional ByVal maximoVert As UInteger = 0)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim minimovertical As Double = (minimoVert * Niveles.GetUpperBound(1)) / 100
            Dim maximovertical As Double = (Niveles.GetUpperBound(1) / 100) * maximoVert
            Dim valorDegradadoV As Double = ((minimoVert + maximoVert * 255) / 100) / Niveles.GetUpperBound(1)
            Dim acumulado2 As UInteger = 1
            Dim degradadoVerti As UInteger
            Dim alfaaux As Integer


            For i = Niveles.GetUpperBound(1) To 0 Step -1 'Recorremos la matriz
                If (i > minimovertical And i < maximovertical) Then
                    degradadoVerti = CInt(valorDegradadoV * acumulado2)
                    acumulado2 = acumulado2 + 1
                End If
                For j = 0 To Niveles.GetUpperBound(0)
                    Rojo = Niveles(j, i).R
                    Verde = Niveles(j, i).G
                    Azul = Niveles(j, i).B
                    If degradadoVerti > 255 Then degradadoVerti = 255
                    alfaaux = Niveles(j, i).A
                    alfaaux = alfaaux - degradadoVerti
                    If alfaaux < 0 Then alfaaux = 0
                    alfa = alfaaux
                    bmp.SetPixel(j, i, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
            Next
            Return bmp
        End Function

        Public Function degradadoHorizontalInvertido(ByVal bmp As Bitmap, Optional ByVal minimoHoriz As UInteger = 0, Optional ByVal maximoHoriz As UInteger = 0)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores

            Dim minimohorizontal As Double = (minimoHoriz * Niveles.GetUpperBound(0)) / 100
            Dim maximohorizontal As Double = (Niveles.GetUpperBound(0) / 100) * maximoHoriz
            Dim valorDegradadoH As Double = ((minimoHoriz + maximoHoriz * 255) / 100) / Niveles.GetUpperBound(0)
            Dim acumulado As UInteger = 1
            Dim degradadoHorizont As UInteger
            Dim alfaaux As Integer

            For i = Niveles.GetUpperBound(0) To 0 Step -1  'Recorremos la matriz
                If (i > minimohorizontal And i < maximohorizontal) Then
                    degradadoHorizont = CInt(valorDegradadoH * acumulado)
                    acumulado = acumulado + 1
                End If
                For j = 0 To Niveles.GetUpperBound(1)

                    Rojo = Niveles(i, j).R
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).B
                    If degradadoHorizont > 255 Then degradadoHorizont = 255
                    alfaaux = Niveles(i, j).A
                    alfaaux = alfaaux - degradadoHorizont
                    If alfaaux < 0 Then alfaaux = 0
                    alfa = alfaaux

                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul))
                Next
            Next
            Return bmp
        End Function

        Public Function clonar(ByVal bmp As Bitmap, ByVal PuntoI As Point, ByVal puntoF As Point, Optional ByVal ancho As Integer = 3, Optional ByVal alto As Integer = 3)

            If clonarVal = True Then
                nivelclon(bmp)
            Else
                Dim i, j As Long
                Dim contador As Integer = 0
                Dim rojoaux(), verdeaux(), azulaux(), alfa() As Double 'Variables auxiliares
                If ancho >= alto Then
                    Dim valorMatr As Integer = (ancho * 2 + 1) * (ancho * 2 + 1)
                    ReDim rojoaux(valorMatr), verdeaux(valorMatr), azulaux(valorMatr), alfa(valorMatr)
                Else
                    Dim valorMatr As Integer = (alto * 2 + 1) * (alto * 2 + 1)
                    ReDim rojoaux(valorMatr), verdeaux(valorMatr), azulaux(valorMatr), alfa(valorMatr)
                End If

                For i = PuntoI.X - ancho To PuntoI.X + ancho
                    For j = PuntoI.Y - alto To PuntoI.Y + alto
                        Try
                            rojoaux(contador) = NivelesClon(i, j).R
                            verdeaux(contador) = NivelesClon(i, j).G
                            azulaux(contador) = NivelesClon(i, j).B
                            alfa(contador) = NivelesClon(i, j).A
                            contador = contador + 1
                        Catch
                        End Try
                    Next
                Next
                contador = 0
                For i = puntoF.X - ancho To puntoF.X + ancho
                    For j = puntoF.Y - alto To puntoF.Y + alto
                        Try
                            bmp.SetPixel(i, j, Color.FromArgb(alfa(contador), rojoaux(contador), verdeaux(contador), azulaux(contador)))
                            contador = contador + 1
                        Catch
                        End Try
                    Next
                Next

            End If
            clonarVal = False
            Return bmp
        End Function

        Private Sub nivelclon(ByVal bmp As Bitmap)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            'Este primer bloque, guarda los niveles digitales de la imagen en la variable Niveles
            Dim i, j As Long

            ReDim NivelesClon(bmp.Width - 1, bmp.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            Dim bmp2 As New Bitmap(bmp)
            undo(bmp2)
            For i = 0 To bmp.Width - 1 'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 1 'Recorremos la matriz a lo largo
                    NivelesClon(i, j) = bmp.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                Next
            Next
        End Sub

        Public Function filtroLocal(ByVal bmp As Bitmap, ByVal PuntoI As Point, Optional ByVal ancho As Integer = 3, Optional ByVal alto As Integer = 3, Optional ByVal valorRojo As Integer = 50, Optional ByVal valorVerde As Integer = 50, Optional ByVal valorAzul As Integer = 50)

            If FiltroVal = True Then
                nivelfiltro(bmp)
            Else
                Dim i, j As Long
                Dim contador As Integer = 0
                Dim rojoaux(), verdeaux(), azulaux(), alfa() As Double 'Variables auxiliares
                If ancho >= alto Then
                    Dim valorMatr As Integer = (ancho * 2 + 1) * (ancho * 2 + 1)
                    ReDim rojoaux(valorMatr), verdeaux(valorMatr), azulaux(valorMatr), alfa(valorMatr)
                Else
                    Dim valorMatr As Integer = (alto * 2 + 1) * (alto * 2 + 1)
                    ReDim rojoaux(valorMatr), verdeaux(valorMatr), azulaux(valorMatr), alfa(valorMatr)
                End If
                contador = 0
                For i = PuntoI.X - ancho To PuntoI.X + ancho
                    For j = PuntoI.Y - alto To PuntoI.Y + alto
                        Try
                            rojoaux(contador) = NivelesFiltro(i, j).R + valorRojo
                            verdeaux(contador) = NivelesFiltro(i, j).G + valorVerde
                            azulaux(contador) = NivelesFiltro(i, j).B + valorAzul
                            alfa(contador) = NivelesFiltro(i, j).A
                            If rojoaux(contador) > 255 Then rojoaux(contador) = 255
                            If verdeaux(contador) > 255 Then verdeaux(contador) = 255
                            If azulaux(contador) > 255 Then azulaux(contador) = 255
                            If rojoaux(contador) < 0 Then rojoaux(contador) = 0
                            If verdeaux(contador) < 0 Then verdeaux(contador) = 0
                            If azulaux(contador) < 0 Then azulaux(contador) = 0
                            bmp.SetPixel(i, j, Color.FromArgb(alfa(contador), rojoaux(contador), verdeaux(contador), azulaux(contador)))
                            contador = contador + 1
                        Catch
                        End Try
                    Next
                Next

            End If
            FiltroVal = False
            Return bmp
        End Function
        Private Sub nivelfiltro(ByVal bmp As Bitmap)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            'Este primer bloque, guarda los niveles digitales de la imagen en la variable Niveles
            Dim i, j As Long

            ReDim NivelesFiltro(bmp.Width - 1, bmp.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            Dim bmp2 As New Bitmap(bmp)
            undo(bmp2)
            For i = 0 To bmp.Width - 1 'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 1 'Recorremos la matriz a lo largo
                    NivelesFiltro(i, j) = bmp.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                Next
            Next
        End Sub

        Public Function clonarParcial(ByVal bmp As Bitmap, ByVal PuntoI As Point, ByVal puntoF As Point, Optional ByVal ancho As Integer = 3, Optional ByVal alto As Integer = 3, Optional ByVal porcentaje As Byte = 50)

            If clonarParVal = True Then
                nivelclon(bmp)
            Else
                Dim i, j As Long
                Dim contador As Integer = 0
                Dim rojoaux(), verdeaux(), azulaux(), alfa() As Double 'Variables auxiliares
                If ancho >= alto Then
                    Dim valorMatr As Integer = (ancho * 2 + 1) * (ancho * 2 + 1)
                    ReDim rojoaux(valorMatr), verdeaux(valorMatr), azulaux(valorMatr), alfa(valorMatr)
                Else
                    Dim valorMatr As Integer = (alto * 2 + 1) * (alto * 2 + 1)
                    ReDim rojoaux(valorMatr), verdeaux(valorMatr), azulaux(valorMatr), alfa(valorMatr)
                End If

                For i = PuntoI.X - ancho To PuntoI.X + ancho
                    For j = PuntoI.Y - alto To PuntoI.Y + alto
                        Try
                            rojoaux(contador) = NivelesClon(i, j).R
                            verdeaux(contador) = NivelesClon(i, j).G
                            azulaux(contador) = NivelesClon(i, j).B
                            alfa(contador) = NivelesClon(i, j).A
                            contador = contador + 1
                        Catch
                        End Try
                    Next
                Next
                contador = 0
                Dim porcentaje1 = (100 - porcentaje) / 100
                Dim porcentaje2 = porcentaje / 100
                For i = puntoF.X - ancho To puntoF.X + ancho
                    For j = puntoF.Y - alto To puntoF.Y + alto
                        Try
                            rojoaux(contador) = CInt(((rojoaux(contador) * porcentaje2) + (NivelesClon(i, j).R) * porcentaje1))
                            verdeaux(contador) = CInt(((verdeaux(contador) * porcentaje2) + (NivelesClon(i, j).G) * porcentaje1))
                            azulaux(contador) = CInt(((azulaux(contador) * porcentaje2) + (NivelesClon(i, j).B) * porcentaje1))
                            bmp.SetPixel(i, j, Color.FromArgb(alfa(contador), rojoaux(contador), verdeaux(contador), azulaux(contador)))
                            contador = contador + 1
                        Catch
                        End Try
                    Next
                Next

            End If
            clonarParVal = False
            Return bmp
        End Function


        Public Function filtroBN(ByVal bmp As Bitmap, ByVal PuntoI As Point, Optional ByVal ancho As Integer = 3, Optional ByVal alto As Integer = 3, Optional ByVal Imgoriginal As Boolean = True, Optional ByVal tipoDeFiltro As String = "gris", Optional ByVal tipoDeFiltroOriginal As String = "original")

            If FiltroBNN = True Then
                Dim bmpaux2 As New Bitmap(bmp)
                Dim bmp2 As Bitmap
                Select Case tipoDeFiltro
                    Case "original"
                        bmp2 = bmpaux2
                    Case "gris"
                        bmp2 = grises(bmpaux2)
                    Case "invertir"
                        bmp2 = invertir(bmpaux2)
                    Case "BN"
                        bmp2 = blanconegro(bmpaux2)
                    Case "sepia"
                        bmp2 = sepia(bmpaux2)
                    Case "rojo"
                        bmp2 = filtrorojo(bmpaux2)
                    Case "verde"
                        bmp2 = filtroverde(bmpaux2)
                    Case "azul"
                        bmp2 = filtroazul(bmpaux2)
                    Case "BGR"
                        bmp2 = RGBtoBGR(bmpaux2)
                    Case "GRB"
                        bmp2 = RGBtoGRB(bmpaux2)
                    Case "RBG"
                        bmp2 = RGBtoRBG(bmpaux2)
                    Case "contornos"
                        bmp2 = contornos(bmpaux2, 20)
                    Case "reducir"
                        bmp2 = reducircolores(bmpaux2, 50)
                    Case "oleo"
                        bmp2 = Oleo(bmpaux2)
                    Case "etiopiaH"
                        bmp2 = etiopia(bmpaux2)
                    Case "etiopiaV"
                        bmp2 = etiopia(bmpaux2, False)
                    Case "x5"
                        bmp2 = pixelarX5(bmpaux2)
                    Case "x7"
                        bmp2 = pixelarX7(bmpaux2)

                    Case Else
                        bmp2 = grises(bmpaux2)

                End Select

                Select Case tipoDeFiltroOriginal
                    Case "original"
                        nivelEsp(bmp)
                    Case "gris"
                        bmp = grises(bmp)
                        nivelEsp(bmp)
                    Case "invertir"
                        bmp = invertir(bmp)
                        nivelEsp(bmp)
                    Case "BN"
                        bmp = blanconegro(bmp)
                        nivelEsp(bmp)
                    Case "sepia"
                        bmp = sepia(bmp)
                        nivelEsp(bmp)
                    Case "rojo"
                        bmp = filtrorojo(bmp)
                        nivelEsp(bmp)
                    Case "verde"
                        bmp = filtroverde(bmp)
                        nivelEsp(bmp)
                    Case "azul"
                        bmp = filtroazul(bmp)
                        nivelEsp(bmp)
                    Case "BGR"
                        bmp = RGBtoBGR(bmp)
                        nivelEsp(bmp)
                    Case "GRB"
                        bmp = RGBtoGRB(bmp)
                        nivelEsp(bmp)
                    Case "RBG"
                        bmp = RGBtoRBG(bmp)
                        nivelEsp(bmp)
                    Case "contornos"
                        bmp = contornos(bmp, 20)
                        nivelEsp(bmp)
                    Case "reducir"
                        bmp = reducircolores(bmp, 50)
                        nivelEsp(bmp)
                    Case "oleo"
                        bmp = Oleo(bmp)
                        nivelEsp(bmp)
                    Case "etiopiaH"
                        bmp = etiopia(bmp)
                        nivelEsp(bmp)
                    Case "etiopiaV"
                        bmp = etiopia(bmp, False)
                        nivelEsp(bmp)
                    Case "x5"
                        bmp = pixelarX5(bmp)
                        nivelEsp(bmp)
                    Case "x7"
                        bmp = pixelarX7(bmp)
                        nivelEsp(bmp)
                    Case Else
                        nivelEsp(bmp)
                End Select

                nivelEspaux(bmp2)
                bmp = bmp2


            Else
                Dim i, j As Long
                Dim contador As Integer = 0
                Dim rojoaux(), verdeaux(), azulaux(), alfa() As Double 'Variables auxiliares
                If ancho >= alto Then
                    Dim valorMatr As Integer = (ancho * 2 + 1) * (ancho * 2 + 1)
                    ReDim rojoaux(valorMatr), verdeaux(valorMatr), azulaux(valorMatr), alfa(valorMatr)
                Else
                    Dim valorMatr As Integer = (alto * 2 + 1) * (alto * 2 + 1)
                    ReDim rojoaux(valorMatr), verdeaux(valorMatr), azulaux(valorMatr), alfa(valorMatr)
                End If
                If Imgoriginal = False Then
                    For i = PuntoI.X - ancho To PuntoI.X + ancho
                        For j = PuntoI.Y - alto To PuntoI.Y + alto
                            Try
                                rojoaux(contador) = NivelesEsp(i, j).R
                                verdeaux(contador) = NivelesEsp(i, j).G
                                azulaux(contador) = NivelesEsp(i, j).B
                                alfa(contador) = NivelesEsp(i, j).A
                                bmp.SetPixel(i, j, Color.FromArgb(alfa(contador), rojoaux(contador), verdeaux(contador), azulaux(contador)))
                                contador = contador + 1
                            Catch
                            End Try
                        Next
                    Next
                Else

                    For i = PuntoI.X - ancho To PuntoI.X + ancho
                        For j = PuntoI.Y - alto To PuntoI.Y + alto
                            Try
                                rojoaux(contador) = NivelesEspaux(i, j).R
                                verdeaux(contador) = NivelesEspaux(i, j).G
                                azulaux(contador) = NivelesEspaux(i, j).B
                                alfa(contador) = NivelesEspaux(i, j).A
                                bmp.SetPixel(i, j, Color.FromArgb(alfa(contador), rojoaux(contador), verdeaux(contador), azulaux(contador)))
                                contador = contador + 1
                            Catch
                            End Try
                        Next
                    Next
                End If
            End If
            FiltroBNN = False
            Return bmp
        End Function
        Public Function segmentacion(ByVal bmp As Bitmap, ByVal punto As Point, Optional ByVal rojoF As Byte = 0, Optional ByVal verdeF As Byte = 0, Optional ByVal azulF As Byte = 0, Optional ByVal alfaF As Byte = 0, Optional ByVal ancho As Byte = 10, Optional ByVal alto As Byte = 10)
            nivel(bmp)
            Dim bmp2 As New Bitmap(31, 31)
            Dim Rojo, Verde, Azul, alfa As Byte 'Declaramos tres variables que almacenarán los colores
            Dim i1, j1, contador As Integer
            i1 = -1
            Dim rojoM(960), verdeM(960), azulM(960) As Byte

            ancho = CInt(ancho / 2)
            alto = CInt(alto / 2)
            For i = punto.X - ancho To punto.X + ancho  'Recorremos la matriz
                i1 = i1 + 1
                j1 = -1
                For j = punto.Y - alto To punto.Y + alto  '
                    j1 = j1 + 1
                    Rojo = Niveles(i, j).R  'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G  'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).B  'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    rojoM(contador) = Rojo
                    verdeM(contador) = Verde
                    azulM(contador) = Azul
                    contador = contador + 1
                Next
            Next

            Dim rojoV, verdeV, azulV As Byte
            Dim rojoD, verdeD, azulD As Byte

            Array.Sort(rojoM)
            Array.Sort(verdeM)
            Array.Sort(azulM)
            rojoD = rojoM(0)
            rojoV = rojoM(960)
            verdeD = verdeM(0)
            verdeV = verdeM(960)
            azulD = azulM(0)
            azulV = azulM(960)
            For i = 0 To Niveles.GetUpperBound(0)  'Recorremos la matriz
                For j = 0 To Niveles.GetUpperBound(1)
                    Rojo = Niveles(i, j).R 'Realizamos la inversión de los colores
                    Verde = Niveles(i, j).G 'Realizamos la inversión de los colores
                    Azul = Niveles(i, j).B 'Realizamos la inversión de los colores
                    alfa = Niveles(i, j).A
                    If (Rojo >= rojoD And Rojo <= rojoV) And (Verde >= verdeD And Verde <= verdeV) And (Azul >= azulD And Azul <= azulV) Then
                        bmp.SetPixel(i, j, Color.FromArgb(alfaF, rojoF, verdeF, azulF))
                    Else
                        bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                    End If

                Next
            Next
            Return bmp


        End Function

        Public Function Borrar(ByVal bmp As Bitmap, ByVal PuntoI As Point, Optional ByVal ancho As Integer = 3, Optional ByVal alto As Integer = 3, Optional ByVal valorRojo As Integer = 50, Optional ByVal valorVerde As Integer = 50, Optional ByVal valorAzul As Integer = 50, Optional ByVal valorAlfa As Integer = 255)

            If BorrarVal = True Then
                nivelfiltro(bmp)
            Else
                Dim i, j As Long
                Dim contador As Integer = 0
                Dim rojoaux(), verdeaux(), azulaux(), alfa() As Double 'Variables auxiliares
                If ancho >= alto Then
                    Dim valorMatr As Integer = (ancho * 2 + 1) * (ancho * 2 + 1)
                    ReDim rojoaux(valorMatr), verdeaux(valorMatr), azulaux(valorMatr), alfa(valorMatr)
                Else
                    Dim valorMatr As Integer = (alto * 2 + 1) * (alto * 2 + 1)
                    ReDim rojoaux(valorMatr), verdeaux(valorMatr), azulaux(valorMatr), alfa(valorMatr)
                End If
                contador = 0
                For i = PuntoI.X - ancho To PuntoI.X + ancho
                    For j = PuntoI.Y - alto To PuntoI.Y + alto
                        Try
                            rojoaux(contador) = valorRojo
                            verdeaux(contador) = valorVerde
                            azulaux(contador) = valorAzul
                            alfa(contador) = valorAlfa
                            If rojoaux(contador) > 255 Then rojoaux(contador) = 255
                            If verdeaux(contador) > 255 Then verdeaux(contador) = 255
                            If azulaux(contador) > 255 Then azulaux(contador) = 255
                            If alfa(contador) > 255 Then alfa(contador) = 255
                            If rojoaux(contador) < 0 Then rojoaux(contador) = 0
                            If verdeaux(contador) < 0 Then verdeaux(contador) = 0
                            If azulaux(contador) < 0 Then azulaux(contador) = 0
                            If alfa(contador) < 0 Then alfa(contador) = 0
                            bmp.SetPixel(i, j, Color.FromArgb(alfa(contador), rojoaux(contador), verdeaux(contador), azulaux(contador)))
                            contador = contador + 1
                        Catch
                        End Try
                    Next
                Next

            End If
            BorrarVal = False
            Return bmp
        End Function

        Function interpolarAfin(ByVal bmp As Bitmap, Optional ByVal NumeroVecinos As Integer = 1)
            nivel(bmp)

            Dim Rojo, Verde, Azul, alfa As Integer 'Declaramos tres variables que almacenarán los colores
            Dim Rojoaux, Verdeaux, Azulaux, alfaaux As Integer 'Declaramos tres variables que almacenarán los colores
            Dim contador As Integer
            For i = NumeroVecinos To Niveles.GetUpperBound(0) - NumeroVecinos  'Recorremos la matriz
                For j = NumeroVecinos To Niveles.GetUpperBound(1) - NumeroVecinos

                    Rojo = Niveles(i, j).R
                    Verde = Niveles(i, j).G
                    Azul = Niveles(i, j).B
                    alfa = Niveles(i, j).A
                    Rojoaux = 0 : Verdeaux = 0 : Azulaux = 0 : alfaaux = 0 : contador = 0
                    If alfa = 0 Then
                        For ii = i - NumeroVecinos To i + NumeroVecinos
                            For jj = j - NumeroVecinos To j + NumeroVecinos
                                If Niveles(ii, jj).A <> 0 Then
                                    contador = contador + 1
                                    Rojoaux = Rojoaux + Niveles(ii, jj).R
                                    Verdeaux = Verdeaux + Niveles(ii, jj).G
                                    Azulaux = Azulaux + Niveles(ii, jj).B
                                    'alfaaux = alfaaux + Niveles(ii, jj).A
                                End If
                            Next
                        Next
                        If contador <> 0 Then
                            Rojo = Rojoaux / contador
                            Verde = Verdeaux / contador
                            Azul = Azulaux / contador
                            'alfa = alfaaux / contador
                            alfa = 255
                        End If

                    End If
                    bmp.SetPixel(i, j, Color.FromArgb(alfa, Rojo, Verde, Azul)) 'Asignamos a bmp los colores invertidos
                Next
            Next
            Return bmp
        End Function

        '        Function TransformaciónAfín(ByVal bmp As Bitmap, ByVal MatrizEntrada4puntos() As Point, ByVal MatrizSalida4puntos() As Point, ByVal TamañoImagenSalida As Byte)
        '            nivel(bmp)
        '            Dim A(Niveles.GetUpperBound(0) * 2 + 1, Niveles.GetUpperBound(0) * 2 + 1) As Double
        '            Dim L(Niveles.GetUpperBound(0) * 2 + 1, 0) As Double
        '            'Declaración de variables auxiliares
        '            Dim i, j As Short
        '            'Matriz de diseño
        '            For i = 0 To Niveles.GetUpperBound(0)
        '                'Primera fila
        '                A(2 * i, 0) = (MatrizEntrada4puntos(i).X)
        '                A(2 * i, 1) = (MatrizEntrada4puntos(i).Y)
        '                A(2 * i, 2) = 1
        '                A(2 * i, 3) = 0
        '                A(2 * i, 4) = 0
        '                A(2 * i, 5) = 0
        '                A(2 * i, 6) = -(MatrizEntrada4puntos(i).X) * (MatrizSalida4puntos(i).X)
        '                A(2 * i, 7) = -(MatrizEntrada4puntos(i).Y) * (MatrizSalida4puntos(i).X)
        '                'Segunda fila
        '                A(2 * i + 1, 0) = 0
        '                A(2 * i + 1, 1) = 0
        '                A(2 * i + 1, 2) = 0
        '                A(2 * i + 1, 3) = (MatrizEntrada4puntos(i).X)
        '                A(2 * i + 1, 4) = (MatrizEntrada4puntos(i).Y)
        '                A(2 * i + 1, 5) = 1
        '                A(2 * i + 1, 6) = -(MatrizEntrada4puntos(i).X) * (MatrizSalida4puntos(i).Y)
        '                A(2 * i + 1, 7) = -(MatrizEntrada4puntos(i).Y) * (MatrizSalida4puntos(i).Y)
        '            Next
        '            'Matriz de términos independientes
        '            For i = 0 To Niveles.GetUpperBound(0)
        '                L(2 * i, 0) = MatrizSalida4puntos(i).X
        '                L(2 * i + 1, 0) = MatrizSalida4puntos(i).Y
        '            Next
        '            Dim N As Double(,) = Producto(Transpuesta(A), A)
        '            Dim N_inv As Double(,) = Inversa(N)
        '            Dim T As Double(,) = Producto(Transpuesta(A), L)
        '            Dim X As Double(,) = Producto(N_inv, T)
        '            Dim Rojo, Verde, Azul As Byte
        '            Dim bmp2 As New Bitmap(Niveles.GetUpperBound(0) * TamañoImagenSalida, Niveles.GetUpperBound(1) * TamañoImagenSalida)
        '            Dim img As Image
        '            img = CType(bmp2, Image)
        '            For i = 0 To Niveles.GetUpperBound(0)
        '                For j = 0 To Niveles.GetUpperBound(1)
        '                    Rojo = Niveles(i, j).R
        '                    Verde = Niveles(i, j).G
        '                    Azul = Niveles(i, j).B
        '                    Dim X_Dest, Y_Dest As Short
        '                    X_Dest = (X(0, 0) * i + X(1, 0) * j + X(2, 0)) / (X(6, 0) * i + X(7, 0) * j + 1)
        '                    Y_Dest = (X(3, 0) * i + X(4, 0) * j + X(5, 0)) / (X(6, 0) * i + X(7, 0) * j + 1)
        '                    If (X_Dest + 100 < 0 Or Y_Dest + 100 < 0) Or (X_Dest + 100 > Niveles.GetUpperBound(0) * TamañoImagenSalida) Or (Y_Dest > Niveles.GetUpperBound(1) * TamañoImagenSalida) Then
        '                        If TamañoImagenSalida = 9 Then
        '                            MessageBox.Show("Transformación fuera del rango de la imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '                            Exit Function
        '                        Else
        '                            MessageBox.Show("Compruebe el tamaño", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '                            Exit Function
        '                        End If
        '                    Else
        '                        bmp.SetPixel(X_Dest + 100, Y_Dest + 100, Color.FromArgb(Rojo, Verde, Azul))

        '                    End If
        '                Next
        '            Next
        '            Return bmp


        '        End Function

        '        Public Function Transpuesta(ByVal Matriz1(,) As Double) As Double(,)
        '            'Creamos la matriz transpuesta
        '            Dim MatrizTranspuesta(Matriz1.GetUpperBound(1), Matriz1.GetUpperBound(0)) As Double
        '            'Declaración de variables auxiliares
        '            Dim i, j As Short
        '            'Doble bucle para efectuar la transposición
        '            For i = 0 To Matriz1.GetUpperBound(0)
        '                For j = 0 To Matriz1.GetUpperBound(1)
        '                    MatrizTranspuesta(j, i) = Matriz1(i, j)
        '                Next
        '            Next
        '            'Es necesario esta sentencia para que la función devuelva la matriz calculada
        '            Return MatrizTranspuesta
        '        End Function
        '        Public Function Suma(ByVal Matriz1(,) As Double, ByVal Matriz2(,) As Double) As Double(,)
        '            'Comprobación de que las dos matrices son del mismo orden, 
        '            If Not Matriz1.GetUpperBound(0) = Matriz2.GetUpperBound(0) AndAlso _
        '                        Matriz1.GetUpperBound(1) = Matriz2.GetUpperBound(1) Then Exit Function
        '            'Creamos la matriz suma
        '            Dim MatrizSuma(Matriz1.GetUpperBound(0), Matriz1.GetUpperBound(1)) As Double
        '            'Declaración de variables auxiliares
        '            Dim i, j As Short
        '            'Doble bucle para efectuar la suma
        '            For i = 0 To Matriz1.GetUpperBound(0)
        '                For j = 0 To Matriz1.GetUpperBound(1)
        '                    MatrizSuma(i, j) = Matriz1(i, j) + Matriz2(i, j)
        '                Next
        '            Next
        '            'Es necesario esta sentencia para que la función devuelva la matriz calculada
        '            Return MatrizSuma
        '        End Function
        '        Public Function Producto(ByVal Matriz1(,) As Double, ByVal Matriz2(,) As Double) As Double(,)
        '            'Comprobación de que las dos matrices son multiplicables
        '            If Not Matriz1.GetUpperBound(1) = Matriz2.GetUpperBound(0) Then Exit Function
        '            'Creamos la matriz producto
        '            Dim MatrizProducto(Matriz1.GetUpperBound(0), Matriz2.GetUpperBound(1)) As Double
        '            'Declaración de variables auxiliares
        '            Dim i, j, k As Short
        '            'Triple bucle para efectuar el producto
        '            For i = 0 To MatrizProducto.GetUpperBound(0)
        '                For j = 0 To MatrizProducto.GetUpperBound(1)
        '                    For k = 0 To Matriz1.GetUpperBound(1)
        '                        MatrizProducto(i, j) = MatrizProducto(i, j) + _
        '                                                Matriz1(i, k) * Matriz2(k, j)
        '                    Next
        '                Next
        '            Next
        '            'Es necesario esta sentencia para que la función devuelva la matriz calculada
        '            Return MatrizProducto
        '        End Function
        '        Public Function Inversa(ByVal Matriz3(,) As Double) As Double(,)
        '            'Método de inversión: matriz de paso
        '            'Comprobación de que la matriz es cuadrada
        '            If Not Matriz3.GetUpperBound(0) = Matriz3.GetUpperBound(1) Then Exit Function
        '            'Creamos dos matrices auxiliares
        '            Dim Matriz1(Matriz3.GetUpperBound(0), Matriz3.GetUpperBound(1)) As Double
        '            Dim Matriz2(Matriz3.GetUpperBound(0), Matriz3.GetUpperBound(1)) As Double
        '            'Creamos la matriz inversa
        '            Dim MatrizInversa(Matriz1.GetUpperBound(0), Matriz1.GetUpperBound(1)) As Double
        '            'Declaración de variables auxiliares
        '            Dim i, j, k As Short
        '            Dim factor As Double
        '            'Copia de la matriz original
        '            For i = 0 To Matriz1.GetUpperBound(0)
        '                For j = 0 To Matriz1.GetUpperBound(0)
        '                    Matriz1(i, j) = Matriz3(i, j)
        '                Next
        '            Next
        '            'Matriz de Paso inicial = Matriz Identidad (todo ceros excepto la diagonal formada por "unos")
        '            For i = 0 To MatrizInversa.GetUpperBound(0)
        '                Matriz2(i, i) = 1
        '            Next
        '            'Se diagonaliza la matriz original y se aplican las mismas operaciones a la matriz de paso
        '            For j = 0 To Matriz1.GetUpperBound(0)
        '                For i = 0 To Matriz1.GetUpperBound(0)
        '                    If i <> j Then
        '                        If Matriz1(i, j) = 0 Then GoTo CUIDADO
        '                        factor = Matriz1(j, j) / Matriz1(i, j)
        '                        For k = 0 To Matriz2.GetUpperBound(0)
        '                            Matriz1(i, k) = Matriz1(j, k) - factor * Matriz1(i, k)
        '                            Matriz2(i, k) = Matriz2(j, k) - factor * Matriz2(i, k)
        '                        Next
        'CUIDADO:
        '                    End If
        '                Next
        '            Next
        '            'Se divide cada elemento de la diagonal por si mismo y se consigue:
        '            '       * En la matriz original la Matriz Identidad
        '            '       * A la derecha la matriz de Paso = Inversa de la Matriz normal
        '            For i = 0 To Matriz1.GetUpperBound(0)
        '                factor = Matriz1(i, i)
        '                'En la matriz original sólo se divide la diagonal porque el resto es cero (ya esdiagonal)
        '                'Si quieres ver cómo se modifica la matriz original activa la siguiente línea
        '                Matriz1(i, i) = Matriz1(i, i) / factor
        '                For j = 0 To Matriz1.GetUpperBound(0)
        '                    MatrizInversa(i, j) = Matriz2(i, j) / factor
        '                Next
        '            Next
        '            'Es necesario esta sentencia para que la función devuelva la matriz calculada
        '            Return MatrizInversa
        '        End Function


        Private Sub nivelEsp(ByVal bmp As Bitmap)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            'Este primer bloque, guarda los niveles digitales de la imagen en la variable Niveles
            Dim i, j As Long

            ReDim NivelesEsp(bmp.Width - 1, bmp.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            Dim bmp2 As New Bitmap(bmp)
            undo(bmp2)
            For i = 0 To bmp.Width - 1 'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 1 'Recorremos la matriz a lo largo
                    NivelesEsp(i, j) = bmp.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                Next
            Next
        End Sub

        Private Sub nivelEspaux(ByVal bmp As Bitmap)
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            'Este primer bloque, guarda los niveles digitales de la imagen en la variable Niveles
            Dim i, j As Long

            ReDim NivelesEspaux(bmp.Width - 1, bmp.Height - 1)  'Asignamos a la matriz las dimensiones de la imagen -1 *
            Dim bmp2 As New Bitmap(bmp)
            undo(bmp2)
            For i = 0 To bmp.Width - 1 'Recorremos la matriz a lo ancho
                For j = 0 To bmp.Height - 1 'Recorremos la matriz a lo largo
                    NivelesEspaux(i, j) = bmp.GetPixel(i, j) 'Con el método GetPixel, asignamos para cada celda de la matriz el color con sus valores RGB.
                Next
            Next
        End Sub


    End Class

    
End Class
