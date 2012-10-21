Module VariablesGlobales
    Public Picture1 As Bitmap
    Public aceptar As Boolean
    Public valorumbral As Integer
    Public bmpentreForm As Bitmap
    Public valorVistPre As Boolean
    Public rojo, verde, azul As Byte
    Public colorh, colorv As System.Drawing.Color
    Public valorH, valorV As UInteger
    Public empezar As Boolean
    Public rojof, rojofs, verdef, verdefs, azulf, azulfs As Byte
    Public rojoIn, rojoSup, rojosal As Byte
    Public verdeIn, verdeSup, verdesal As Byte
    Public azulIn, azulSup, azulsal As Byte
    Public valorcolor As Byte
    Public formucolores As Boolean
    Public bmpunir1, bmpunir2 As Bitmap
    Public rojoaleatorio, verdealeatorio, azulaleatorio As Byte
    Public valoraleat As Integer
    Public bitmapPic As Bitmap
    Public mosaicohorizontal, mosaicovertical As Byte
    Public canalrojo, canalverde, canalazul As Integer
    Public zoom As Integer
    Public bmpzoom As Bitmap
    Public anularzoom As Boolean
    Public x1, y1 As Integer
    Public x2, y2 As Integer
    Public tipoPuntero As String
    Public valorcontorno, numerocolores As Byte
    Public bmpauxhist As Bitmap
    Public pasoMascara(2, 2) As Double
    Public factorP, desviacionP As Double
    Public grisO As Boolean
    Public valorexposi As Double
    Public r1, r2, r3, g1, g2, g3, b1, b2, b3 As Double
    Public bmpGuardar As Bitmap
    Public degH, degH1 As Integer
    Public degV, degV1 As Integer
    Public textoImagen As String
    Public tipofuente As Font
    Public colorFuente As Color
    Public copiaimagenZoom As Bitmap
    Public escala As Double
    Public imagenRecurso As Bitmap
    Public colorB As Color = Color.Transparent
    Public anchoB, altoB As Integer
    Public volteado As SByte
    Public puntosPol(200) As Point
    Public contadorPoli As Integer = 0
    Public clonarVal As Boolean = True
    Public puntoClon As Boolean
    Public puntoClon2 As Boolean
    Public puntoAclonar, puntoAclonarAux As Point
    Public anchoClonar, altoCLonar As Integer
    Public FiltroVal As Boolean
    Public FiltroInicio As Boolean
    Public clonarParVal As Boolean
    Public puntoClonPar As Boolean
    Public puntoClonPar2 As Boolean
    Public puntoAclonarPar, puntoAclonarParAux As Point
    Public FiltroBNN, FiltroInicioBN, originala As Boolean
    Public pasoFiltrPer As Boolean
    Public filtroPersonalString1, filtroPersonalString2 As String
    Public rectanguloRec As Rectangle
    Public imagenAntesRec As Bitmap
    Public ruta2 As String
    Public bmpsegmentacion As Bitmap
    Public BorrarVal As Boolean
    Public borrarInicio As Boolean
    Public giro, tranX, tranY, escX, escY As Double
    Public bmpAfin As Bitmap
    Public bmpAfinRetorno, bmpAfinRetornoPer As Bitmap
    Public afinImagen, afinImagenper As Boolean
    Public interpolar As Byte
    Public datos2 As New ArrayList
    Public url As String
    Public IMGBing As Bitmap
    Public urlFB As String
    Public fotos As New ArrayList 'Contenedor de los enlaces
End Module
