Public Class Secuencia
    Dim valorMenos255a255(510) As Integer
    Dim valor0a255(255) As Integer
    Dim valor0aMenos255(255) As Integer
    Dim valor1a255(254) As Integer
    Dim valor1a500(499) As Integer
    Dim valor2a15(13) As Integer
    Dim valor1a20(19) As Integer
    Dim valor0a127(127) As Integer
    Dim valor0a10(10) As Integer
    Dim valor5a50(45) As Integer
    Dim valorBool(1) As String
    Dim valor1a5000(4999) As Integer
    Dim valor0a2000(2000) As Integer
    Dim valorMenos1a1con3decimales(2000) As Single
    Dim valorMenos255a255con2decimales(51000) As Single
    Dim valor0_01a255con2decimales(25499) As Single
    Dim valor0a5con2decimales(500) As Single
    Dim valor0a2con3decimales(2000) As Single
    Dim objetoTratamiento As New Apolo.TratamientoImagenes
    Dim ruta As String = ""
    Dim matrizStringColores() As String = {"Red", "Green", "Blue", "Black", "White", "Yellow", "Maroon", "Gray", "LightGreen", "LightBlue", "Orange", "Pink", "Gold", "DarkBlue", "DarkGreen"}
    Dim volteados() As String = {"RotateNoneFlipNone", "Rotate90FlipNone", "Rotate180FlipNone", "Rotate270FlipNone", "RotateNoneFlipX", "Rotate90FlipX", "Rotate180FlipX", "Rotate270FlipX", "RotateNoneFlipY", "Rotate90FlipY", "Rotate180FlipY", "Rotate270FlipY", "RotateNoneFlipXY", "Rotate90FlipXY", "Rotate180FlipXY", "Rotate270FlipXY"}

    Sub New() 'En el constructor creamos los rangos que luego se asignarán a los combos
        For i = -255 To 5000

            If i >= -255 And i <= 0 Then
                valor0aMenos255(i + 255) = i
            End If
            If i <= 255 Then
                valorMenos255a255(i + 255) = i
            End If
            If i >= 0 And i <= 255 Then
                valor0a255(i) = i
            End If
            If i >= 0 And i <= 10 Then
                valor0a10(i) = i
            End If
            If i >= 1 And i <= 500 Then
                valor1a500(i - 1) = i
            End If
            If i >= 2 And i <= 15 Then
                valor2a15(i - 2) = i
            End If
            If i >= 1 And i <= 20 Then
                valor1a20(i - 1) = i
            End If
            If i >= 1 And i <= 255 Then
                valor1a255(i - 1) = i
            End If
            If i >= 5 And i <= 50 Then
                valor5a50(i - 5) = i
            End If
            If i >= 0 And i <= 127 Then
                valor0a127(i) = i
            End If
            If i >= 0 And i <= 2000 Then
                valor0a2000(i) = i
            End If
            If i >= 1 Then
                valor1a5000(i - 1) = i
            End If
        Next
        For i = -25500 To 25500
            If i >= -25500 And i <= 25500 Then
                valorMenos255a255con2decimales(i + 25500) = i / 100
            End If
            If i >= 1 And i <= 25500 Then
                valor0_01a255con2decimales(i - 1) = i / 100
            End If
            If i >= -1000 And i <= 1000 Then
                valorMenos1a1con3decimales(i + 1000) = i / 1000
            End If
            If i >= 0 And i <= 500 Then
                valor0a5con2decimales(i) = i / 100
            End If
            If i >= 0 And i <= 2000 Then
                valor0a2con3decimales(i) = i / 1000
            End If
        Next
        valorBool(0) = "True"
        valorBool(1) = "False"

   
    End Sub

#Region "Valores para los combos"

    Public ReadOnly Property valorMenos255to255() As Integer()
        Get
            Return valorMenos255a255
        End Get
    End Property

    Public ReadOnly Property valor0to255() As Integer()
        Get
            Return valor0a255
        End Get
    End Property
    Public ReadOnly Property valor1to255() As Integer()
        Get
            Return valor1a255
        End Get
    End Property

    Public ReadOnly Property valor0toMenos255() As Integer()
        Get
            Return valor0aMenos255
        End Get
    End Property
    Public ReadOnly Property valor5to50() As Integer()
        Get
            Return valor5a50
        End Get
    End Property

    Public ReadOnly Property valor2to15() As Integer()
        Get
            Return valor2a15
        End Get
    End Property

    Public ReadOnly Property valor1to500() As Integer()
        Get
            Return valor1a500
        End Get
    End Property
    Public ReadOnly Property valor1to20() As Integer()
        Get
            Return valor1a20
        End Get
    End Property
    Public ReadOnly Property valor0to10() As Integer()
        Get
            Return valor0a10
        End Get
    End Property
    Public ReadOnly Property valor0to127() As Integer()
        Get
            Return valor0a127
        End Get
    End Property

    Public ReadOnly Property valor0to2000() As Integer()
        Get
            Return valor0a2000
        End Get
    End Property
    Public ReadOnly Property valor1to5000() As Integer()
        Get
            Return valor1a5000
        End Get
    End Property
    Public ReadOnly Property valorMenos1to1y3decimales() As Single()
        Get
            Return valorMenos1a1con3decimales
        End Get
    End Property

    Public ReadOnly Property valorMenos255to255con2decimales() As Single()
        Get
            Return valorMenos255a255con2decimales
        End Get
    End Property
    Public ReadOnly Property valor0_01to255con2decimales() As Single()
        Get
            Return valor0_01a255con2decimales
        End Get
    End Property
    Public ReadOnly Property valor0to5con2decimales() As Single()
        Get
            Return valor0a5con2decimales
        End Get
    End Property


    Public ReadOnly Property valor0to2con3decimales() As Single()
        Get
            Return valor0a2con3decimales
        End Get
    End Property
    Public ReadOnly Property valorBooleano() As String()
        Get
            Return valorBool
        End Get
    End Property
    Public ReadOnly Property ValorVolteados() As String()
        Get
            Return volteados
        End Get
    End Property
    Public ReadOnly Property MatrizconColores() As String()
        Get
            Return matrizStringColores
        End Get
    End Property
#End Region

   

    'Descripción
    Function Textodescripcion(ByVal nombreFuncion As String) As String
        Dim cadenaDescripcion As String = ""
        Select Case nombreFuncion
            Case "Blanco y negro"
                cadenaDescripcion = "Parámetro 1: seleccione el valor umbral."
            Case "Escala de grises"
                cadenaDescripcion = "Parámetro 1: modifique el valor de la escala."
            Case "Brillo"
                cadenaDescripcion = "Parámetro 1: aumente o disminuya el brillo." & vbCrLf & "*Nota: el valor 0 no altera la composición de la imagen."
            Case "Invertir colores (rojo, verde, azul)"
                cadenaDescripcion = "Parámetro 1: indique si se va a invertir el color rojo." & vbCrLf & "Parámetro 2: indique si se va a invertir el color verde." & vbCrLf & "Parámetro 3: indique si se va a invertir el color azul."
            Case "Sepia"
                cadenaDescripcion = "Sin parámetros."
            Case "Filtros básicos (rojo, verde, azul)"
                cadenaDescripcion = "Parámetro 1: indique si se va a aplicar filtro rojo a la imagen." & vbCrLf & "Parámetro 2: indique si se va a aplicar filtro verde a la imagen." & vbCrLf & "Parámetro 3: indique si se va a aplicar filtro azul a la imagen." & vbCrLf & "*Nota: sólo se aplica un filtro. Si por ejemplo selecciona valor (Parámetro 1) rojo=true, el resto de parámetros se obviarán  y sólo se aplicará el filtro rojo."
            Case "RGB a (BGR, GRB, RBG)"
                cadenaDescripcion = "Parámetro 1: indique si se van a cambiar los valores RGB a BGR." & vbCrLf & "Parámetro 2: indique si se van a cambiar los valores RGB a GRB." & vbCrLf & "Parámetro 3: indique si se van a cambiar los valores RGB a RBG." & vbCrLf & "*Nota: sólo se aplica un cambio. Si por ejemplo selecciona valor (Parámetro 1) BGR=true, el resto de parámetros se obviarán y sólo se aplicará la transformación BGR."
            Case "Redimensionar"
                cadenaDescripcion = "Parámetro 1: tamaño en píxeles del ancho de la imagen." & vbCrLf & "Parámetro 2: tamaño en píxeles del alto de la imagen."
            Case "Contraste (recomendado)"
                cadenaDescripcion = "Parámetro 1: aumente o disminuya el nivel de contraste."
            Case "Contraste"
                cadenaDescripcion = "Parámetro 1: seleccione el valor máximo de niveles RGB." & vbCrLf & "Parámetro 2: seleccione el valor mínimo de niveles RGB." & vbCrLf & "*Nota: el valor máximo debe ser superior al mínimo. En caso contrario no se producirá ningún efecto sobre la imagen."
            Case "Correción de gamma"
                cadenaDescripcion = "Parámetro 1: seleccione el valor de gamma para el color rojo." & vbCrLf & "Parámetro 2: seleccione el valor de gamma para el color verde." & vbCrLf & "Parámetro 3: seleccione el valor de gamma para el color azul." & vbCrLf & "*Nota: el valor 1 no altera la composición de la imagen."
            Case "Exposición"
                cadenaDescripcion = "Parámetro 1: seleccione el valor de exposición que quiera aplicar a la imagen." & vbCrLf & "*Nota: el valor 1 no altera la composición de la imagen."
            Case "Modificar canales"
                cadenaDescripcion = "Parámetro 1: aumenta o diminuye el valor del canal rojo." & vbCrLf & "Parámetro 2: aumenta o diminuye el valor del canal verde." & vbCrLf & "Parámetro 3: aumenta o diminuye el valor del canal azul." & vbCrLf & "Parámetro 4: aumenta o diminuye el valor del canal alfa." & vbCrLf & "*Nota: el valor 0 no altera la composición del canal de la imagen."
            Case "Reducir colores"
                cadenaDescripcion = "Parámetro 1: selecione el número de colores por canal." & vbCrLf & "*Nota: el valor 255 no altera la composición de la imagen."
            Case "Filtrar colores (rojo)"
                cadenaDescripcion = "Parámetro 1: selecione el valor inferior del rango (canal rojo)." & vbCrLf & "Parámetro 2: selecione el valor superior del rango (canal rojo)." & vbCrLf & "Parámetro 3: seleccione el valor de salida para los valores incluidos en el rango (canal rojo)."
            Case "Filtrar colores (verde)"
                cadenaDescripcion = "Parámetro 1: selecione el valor inferior del rango (canal verde)." & vbCrLf & "Parámetro 2: selecione el valor superior del rango (canal verde)." & vbCrLf & "Parámetro 3: seleccione el valor de salida para los valores incluidos en el rango (canal verde)."
            Case "Filtrar colores (azul)"
                cadenaDescripcion = "Parámetro 1: selecione el valor inferior del rango (canal azul)." & vbCrLf & "Parámetro 2: selecione el valor superior del rango (canal azul)." & vbCrLf & "Parámetro 3: seleccione el valor de salida para los valores incluidos en el rango (canal azul)."
            Case "Detectar contornos"
                cadenaDescripcion = "Parámetro 1: seleccione el valor tope para detectar contorno." & vbCrLf & "Parámetro 2: selecione el valor para el canal rojo." & vbCrLf & "Parámetro 3: selecione el valor para el canal verde." & vbCrLf & "Parámetro 4: selecione el valor para el canal azul." & vbCrLf & "*Nota: el primer parámetro cuanto mayor sea, menos contornos detectará y viceversa."
            Case "Operación aritmética - Suma"
                cadenaDescripcion = "Parámetro 1: aumenta el valor del canal rojo." & vbCrLf & "Parámetro 2: aumenta el valor del canal verde." & vbCrLf & "Parámetro 3: aumenta el valor del canal azul." & vbCrLf & "Parámetro 4: aumenta el valor del canal alfa." & vbCrLf & "*Nota: el valor 0 no altera la composición del canal de la imagen."
            Case "Operación aritmética - Resta"
                cadenaDescripcion = "Parámetro 1: disminuye el valor del canal rojo." & vbCrLf & "Parámetro 2: disminuye el valor del canal verde." & vbCrLf & "Parámetro 3: disminuye el valor del canal azul." & vbCrLf & "Parámetro 4: disminuye el valor del canal alfa." & vbCrLf & "*Nota: el valor 0 no altera la composición del canal de la imagen."
            Case "Operación aritmética - División"
                cadenaDescripcion = "Parámetro 1: divide entre el valor del canal rojo." & vbCrLf & "Parámetro 2: divide entre el valor del canal verde." & vbCrLf & "Parámetro 3: divide entre el valor del canal azul." & vbCrLf & "Parámetro 4: divide entre el valor del canal alfa." & vbCrLf & "*Nota: el valor 1 no altera la composición del canal de la imagen."
            Case "Operación aritmética - Multiplicación"
                cadenaDescripcion = "Parámetro 1: multiplica por el valor del canal rojo." & vbCrLf & "Parámetro 2: multiplica por el valor del canal verde." & vbCrLf & "Parámetro 3: multiplica por el valor del canal azul." & vbCrLf & "Parámetro 4: multiplica por el valor del canal alfa." & vbCrLf & "*Nota: el valor 1 no altera la composición del canal de la imagen."
            Case "Operación lógicas - AND"
                cadenaDescripcion = "Parámetro 1: aplica el operador AND al valor del canal rojo." & vbCrLf & "Parámetro 2: aplica el operador AND al valor del canal verde." & vbCrLf & "Parámetro 3: aplica el operador AND al valor del canal azul." & vbCrLf & "Parámetro 4: aplica el operador AND al valor del canal alfa." & vbCrLf & "*Nota: el valor 255 no altera la composición del canal de la imagen."
            Case "Operación lógicas - OR"
                cadenaDescripcion = "Parámetro 1: aplica el operador OR al valor del canal rojo." & vbCrLf & "Parámetro 2: aplica el operador OR al valor del canal verde." & vbCrLf & "Parámetro 3: aplica el operador OR al valor del canal azul." & vbCrLf & "Parámetro 4: aplica el operador OR al valor del canal alfa." & vbCrLf & "*Nota: el valor 0 no altera la composición del canal de la imagen."
            Case "Operación lógicas - XOR"
                cadenaDescripcion = "Parámetro 1: aplica el operador XOR al valor del canal rojo." & vbCrLf & "Parámetro 2: aplica el operador XOR al valor del canal verde." & vbCrLf & "Parámetro 3: aplica el operador XOR al valor del canal azul." & vbCrLf & "Parámetro 4: aplica el operador XOR al valor del canal alfa." & vbCrLf & "*Nota: el valor 0 no altera la composición del canal de la imagen. El valor 255 invierte el canal."
            Case "Reflexión horizontal"
                cadenaDescripcion = "Sin parámetros."
            Case "Reflexión vertical"
                cadenaDescripcion = "Sin parámetros."
            Case "Traslación"
                cadenaDescripcion = "Parámetro 1: indica el número de píxeles que se va a trasladar la imagen en el eje x." & vbCrLf & "Parámetro 2: indica el número de píxeles que se va a trasladar la imagen en el eje y." & vbCrLf & "*Nota: el valor 0 tanto en x como en y no altera la posicion de la imagen."
            Case "Voltear"
                cadenaDescripcion = "Parámetro 1: indica que tipo de volteo que se va a realizar." & vbCrLf & "*Nota: la opción -RotateNoneFlipNone- no afecta a la imagen." & vbCrLf & "*Nota: para ver la información completa de los giros, revisar documentación."
            Case "Density Slicing automático"
                cadenaDescripcion = "Parámetro 1: estable el número de divisiones que se aplicarán a la imagen." & vbCrLf & "Parámetro 2: indica si, previo a aplicar la función, se va a normalizar el histograma."
            Case "Sobel total"
                cadenaDescripcion = "Sin parámetros."
            Case "Desenfoque - Distorsión"
                cadenaDescripcion = "Parámetro 1: indica el nivel de distorsión que se va a aplicar." & vbCrLf & "*Nota: el valor 0 no aplica distorsión a la imagen."
            Case "Desenfoque - Movimiento"
                cadenaDescripcion = "Parámetro 1: indica el desplazamiento en x del desenfoque." & vbCrLf & "Parámetro 2: indica el desplazamiento en y del desenfoque." & vbCrLf & "*Nota: el valor 0 en ambos parámetros no aplica desplazamiento en la imagen."
            Case "Desenfoque - Blur"
                cadenaDescripcion = "Sin parámetros."
            Case "Pixelado"
                cadenaDescripcion = "Parámetro 1: indica el número de píxeles que se utilizarán para la transformación."
            Case "Cuadrícula"
                cadenaDescripcion = "Parámetro 1: indica el espacio horizontal (en píxeles) entre las líneas verticales." & vbCrLf & "Parámetro 2: indica el color de las líneas verticales." & vbCrLf & "Parámetro 3: indica el espacio vertical (en píxeles) entre las líneas horizontales." & vbCrLf & "Parámetro 4: indica el color de las líneas horizontales."
            Case "Sombra de vidrio"
                cadenaDescripcion = "Parámetro 1: indica el tamaño de la sombra que se creará." & vbCrLf & "Parámetro 2: si la opción es True, la sombra mostrada se atenuará modificando el canal alfa, en caso contrario, la sombra será sólida."
            Case "Trocear imagen - Tres partes"
                cadenaDescripcion = "Sin parámetros."
            Case "Trocear imagen - Seis partes"
                cadenaDescripcion = "Sin parámetros."
            Case "Ruido aleatorio"
                cadenaDescripcion = "Parámetro 1: indica el grado de aleatoriedad de la función."
            Case "Ruido desplazado"
                cadenaDescripcion = "Parámetro 1: indica el valor máximo que se va a aplicar a un píxel concreto." & vbCrLf & "Parámetro 2: si esta opción es True, el ruido se aplicará en escala de grises."
            Case "Óleo"
                cadenaDescripcion = "Parámetro 1: el valor del contorno." & vbCrLf & "Parámetro 2: indica el número de colores por canal de la imagen." & vbCrLf & "*Nota: si el valor número de colores es 255 no se aplicará reducción alguna de colores."
            Case "Efecto Marte"
                cadenaDescripcion = "Sin parámetros."
            Case "Efecto antiguo sobreexpuesto"
                cadenaDescripcion = "Sin parámetros."
            Case "Efecto marino"
                  cadenaDescripcion = "Sin parámetros."
            Case "Aumentar rasgos"
                  cadenaDescripcion = "Sin parámetros."
            Case "Disminuir rasgos"
                   cadenaDescripcion = "Sin parámetros."
            Case "Contorno sombreado - Contenido"
                  cadenaDescripcion = "Sin parámetros."
            Case "Contorno sombreado - Desmedido"
                cadenaDescripcion = "Sin parámetros."
            Case "Aumentar luz"
                cadenaDescripcion = "Sin parámetros."
        End Select
        Return cadenaDescripcion
    End Function

End Class
