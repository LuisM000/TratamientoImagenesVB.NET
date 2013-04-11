Imports System.IO
Imports System.Xml.XPath
Imports System.Xml
Public Class ImportarExportarElementoEstructural
    Function devolverElementoEstructural(ByVal txt As TextBox)
        Dim texto As String = TextBox1.Text
        texto = texto.Replace(vbCrLf, " ")

        texto = texto.TrimEnd(" ") 'Eliminamos espacios finales

        Dim textoSeparado() As String
        textoSeparado = texto.Split(" ")
        If textoSeparado.Count Mod 2 = 0 Then 'Comprobamos si la matriz es cuadrada
            MessageBox.Show("El elemento estructural no es cuadrado o no es impar. Compruebe que no hay ningún espacio al final de cada línea y verifique que sea impar (3x3, 5x5).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim errorRetorno(0, 0) As String
            errorRetorno(0, 0) = "Error"
            Return errorRetorno
            Exit Function
        End If
        For i = 0 To textoSeparado.Count - 1 'Comprobamos si son todo números y son 0 o 1
            If (IsNumeric(textoSeparado(i)) = False) OrElse (textoSeparado(i) <> 1 And textoSeparado(i) <> 0) Then
                MessageBox.Show("Compruebe que todos los campos que conforman el elemento estructural son 1 o 0. Revise también que no haya espacios al final de cada línea.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim errorRetorno(0, 0) As String
                errorRetorno(0, 0) = "Error"
                Return errorRetorno
                Exit Function
            End If
        Next

        'En este bloque pasamos el elemento estructural a una matriz cuadrada (de dos dimensiones)
        Dim ElementoFormato(,) As String
        Dim ancho As Integer = Math.Sqrt(textoSeparado.Count) - 1
        ReDim ElementoFormato(ancho, ancho)
        Dim contador As Integer = 0
        For i = 0 To ancho
            For j = 0 To ancho
                ElementoFormato(i, j) = textoSeparado(contador)
                contador += 1
            Next
        Next
        Return ElementoFormato
    End Function
    Sub guardarElementoEstructural(ByVal nombreArchivo As String, ByVal elementoEstruc(,) As String)
        Try
            Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter(nombreArchivo & ".xml", System.Text.Encoding.UTF8)
            myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
            myXmlTextWriter.WriteStartDocument(False)

            'Crear el elemento de documento principal.
            myXmlTextWriter.WriteStartElement("Elemento_Estructural")

            For i = 0 To elementoEstruc.GetUpperBound(0)
                For j = 0 To elementoEstruc.GetUpperBound(1)
                    'Crear un elemento nuevo
                    myXmlTextWriter.WriteStartElement("Elemento")
                    myXmlTextWriter.WriteString(elementoEstruc(i, j))
                    ' y cerrar el elemento.
                    myXmlTextWriter.WriteEndElement()
                Next
            Next
            'Cerrar el elemento estructural.
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.Flush()
            myXmlTextWriter.Close()

            MessageBox.Show("¡Guardado con éxito!", "Exportar elemento estructural", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch e As System.ArgumentException
            MessageBox.Show("Caraceteres no válidos en el nombre del archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Function listaXML(ByVal rutaDirectorio As String) 'Listar los archivos xml de un directorio
        Dim folder As New DirectoryInfo(rutaDirectorio) 'Directorio
        Dim listaDearchivos As New ArrayList
        For Each file As FileInfo In folder.GetFiles() 'Comprobamos si los archivos xml
            If file.ToString.EndsWith(".xml") = True Then
                listaDearchivos.Add(file.ToString)
            End If
        Next
        Return listaDearchivos
    End Function
    Function comprobarEstructura(ByVal rutaArchivo As String)
        Try
            'Preparamos el archivo xml
            Dim NodeIter As XPathNodeIterator
            Dim docNav As New XPathDocument(rutaArchivo)
            Dim nav = docNav.CreateNavigator
            Dim ExBuscar As String
            ExBuscar = "Elemento_Estructural"

            Dim buscar As New ArrayList
            'Recorremos el xml
            NodeIter = nav.Select(ExBuscar)
            While (NodeIter.MoveNext())
                buscar.Add(NodeIter.Current.Value)
            End While

            If buscar.Count = 0 Then
                Return False
            Else
                Return True
            End If
        Catch
            Return False
        End Try
    End Function
    Function valoresElementoEstructural()
        Dim Estructural As New ArrayList
        Try
            Dim rutaArchivoimportar As String = System.IO.Directory.GetCurrentDirectory() & "\" & ListBox1.SelectedItem
            'Preparamos el xml
            Dim NodeIter As XPathNodeIterator
            Dim docNav As New XPathDocument(rutaArchivoimportar)
            Dim nav = docNav.CreateNavigator

            Dim Ex00 As String

            Ex00 = "Elemento_Estructural/Elemento"
            'Recorremos el xml
            NodeIter = nav.Select(Ex00)
            While (NodeIter.MoveNext())
                Estructural.Add(NodeIter.Current.Value)
            End While

        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("El archivo no se ha encontrado. Es posible que no haya activado la opción de guardar todas las peticiones HTTP de las diferentes sesiones." & vbCrLf & "Si desea activarlo, acceda al menú Configuración/Opciones/Registro y reinicie el programa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("Algo ha ocurrido, por favor, inténtelo más tarde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
        Return Estructural
    End Function
    Private Function verificarNombreArchivo(ByVal nombreArchivo As String) As Boolean
        verificarNombreArchivo = True

        Dim folder As New DirectoryInfo(System.IO.Directory.GetCurrentDirectory()) 'Directorio
        For Each file As FileInfo In folder.GetFiles() 'Comprobamos si hay un archivo igual
            If file.ToString = nombreArchivo & ".xml" Then
                verificarNombreArchivo = False
            End If
        Next

    End Function

    Public ElementoFormato(,) As Integer 'Lo declaro como público :(

    Private Sub ImportarExportarElementoEstructural_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ""
        TextBox2.Text = ""
        Erase ElementoFormato 'Borramos la variable global
        Label1.Text = "Cree su elemento estructural personalizado. Tenga en cuenta que el elemento debe ser cuadrado e" & vbCrLf & "impar (3x3, 7x7) y sólo puede contener 0 o 1."
        Dim listaDearchivos As New ArrayList
        'listamos los archivos xml del directorio(le enviamos el directorio actual)
        listaDearchivos = listaXML(System.IO.Directory.GetCurrentDirectory())

        ListBox1.Items.Clear() 'Borramos lo que había en el listbox

        For Each item In listaDearchivos 'Listamos los archivos compatibles
            If comprobarEstructura(System.IO.Directory.GetCurrentDirectory() & "\" & item) = True Then
                ListBox1.Items.Add(item)
            End If
        Next
    End Sub

    'Giardamos el elemento estructural
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.BackColor = Color.White
        If TextBox2.Text <> "" Then
            Dim elemento = devolverElementoEstructural(TextBox1)
            If elemento(0, 0) <> "Error" Then 'Comprobamos que no haya devuelto un error por fallo en el formato
                'Comprobamos que no haya un archivo igual en el directorio
                If verificarNombreArchivo(TextBox2.Text) = False Then
                    Dim respuesta As DialogResult = MessageBox.Show("Esta configuración ya existe, ¿desea sobreescribirla?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Select Case respuesta
                        Case Windows.Forms.DialogResult.Yes
                            guardarElementoEstructural(TextBox2.Text, elemento)
                        Case Windows.Forms.DialogResult.No
                            Exit Sub
                    End Select
                Else
                    guardarElementoEstructural(TextBox2.Text, elemento)
                End If
                ImportarExportarElementoEstructural_Load(sender, e) 'Actualizamos 
            End If
            Else
                TextBox2.BackColor = Color.Red
            End If
    End Sub

    Private Sub TextBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles TextBox2.MouseClick 'Borramos al hacer clic
        TextBox2.Text = ""
    End Sub

    'Cargamos el elemento estructural seleccionado y cerramos el formulario
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ListBox1.SelectedIndex <> -1 Then 'Si hay algún ítem seleccionado
            Dim Estructura = valoresElementoEstructural()
            'En este bloque pasamos el elemento estructural a una matriz cuadrada (de dos dimensiones)
            Dim ancho As Integer = Math.Sqrt(Estructura.Count) - 1
            ReDim ElementoFormato(ancho, ancho)
            Dim contador As Integer = 0
            For i = 0 To ancho
                For j = 0 To ancho
                    ElementoFormato(i, j) = Estructura(contador)
                    contador += 1
                Next
            Next
            Me.Close()
        End If
    End Sub

    'Borramos un elemento estrucutral seleccionado
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListBox1.SelectedIndex <> -1 Then 'Si hay algún ítem seleccionado
            Try
                Dim respuesta As DialogResult = MessageBox.Show("¿Realmente desea eliminar de forma permanente el archivo?", "Apolo threads", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Select Case respuesta
                    Case Windows.Forms.DialogResult.Yes 'Borramos el archivo
                        Dim ruta As String
                        ruta = System.IO.Directory.GetCurrentDirectory() & "\" & ListBox1.SelectedItem 'Seleccionamos la ruta del archivo a borrar
                        My.Computer.FileSystem.DeleteFile(ruta)
                    Case Windows.Forms.DialogResult.No
                        'No hacemos nada
                End Select
                'Recargamos el listbox
                ImportarExportarElementoEstructural_Load(sender, e)
            Catch
                MessageBox.Show("Algo ha fallado... inténtelo más tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Recargamos el listbox
                ImportarExportarElementoEstructural_Load(sender, e)
            End Try
        End If
    End Sub

    'Mostramos un ejemplo
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim objetoElemento As New Apolo.TratamientoImagenes.ElementoEstructural
        Dim elementoEstructural = objetoElemento.Disco9x9
        TextBox1.Text = ""
        For i = 0 To UBound(elementoEstructural)
            For j = 0 To UBound(elementoEstructural)
                TextBox1.Text = TextBox1.Text & elementoEstructural(i, j)
                If j <> UBound(elementoEstructural) Then 'Evitamos el espacio de final de línea
                    TextBox1.Text = TextBox1.Text & " "
                End If
            Next
            TextBox1.Text = TextBox1.Text & vbCrLf
        Next
        TextBox2.Text = "Elemento_estructural_de_disco_9x9"
    End Sub

    'Mostramos el elemento estructural que el usuario seleccione
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex <> -1 Then 'Si hay algún ítem seleccionado
            TextBox1.Text = ""
            TextBox2.Text = ""
            Dim Estructura = valoresElementoEstructural()
            'En este bloque pasamos el elemento estructural a una matriz cuadrada (de dos dimensiones)
            Dim ancho As Integer = Math.Sqrt(Estructura.Count) - 1
            Dim elementoFormatoAux(ancho, ancho) As Integer
            Dim contador As Integer = 0
            For i = 0 To ancho
                For j = 0 To ancho
                    elementoFormatoAux(i, j) = Estructura(contador)
                    contador += 1
                    TextBox1.Text = TextBox1.Text & elementoFormatoAux(i, j).ToString
                    If j <> UBound(elementoFormatoAux) Then 'Evitamos el espacio de final de línea
                        TextBox1.Text = TextBox1.Text & " "
                    End If
                Next
                TextBox1.Text = TextBox1.Text & vbCrLf
            Next
            TextBox2.Text = ListBox1.SelectedItem.ToString
        End If
    End Sub
End Class