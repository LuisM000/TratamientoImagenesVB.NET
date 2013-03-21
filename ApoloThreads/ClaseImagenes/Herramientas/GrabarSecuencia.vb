Imports ClaseImagenes.Apolo
Imports System.IO
Imports System.Xml
Imports System.Xml.XPath

Public Class GrabarSecuencia
    Dim objetoSecuencia As New Secuencia
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal
    Dim objetoTratamiento As New TratamientoImagenes

#Region "Funciones controles"
    Sub ResetearControles(ByVal NumeroComboBoxActivos As Integer)
        For Each c As Control In Panel1.Controls
            If TypeOf c Is ComboBox Then
                c.Enabled = False
            End If
        Next
        For i = 0 To NumeroComboBoxActivos - 1
            Panel1.Controls(i).Enabled = True
        Next

    End Sub

    'Manjeamos el buscador----------------------------
    Private Sub txtBuscador_GotFocus(sender As Object, e As EventArgs) Handles txtBuscador.GotFocus
        If txtBuscador.Text = "Buscador de funciones" Then
            txtBuscador.Text = "" 'Borramos contenido
        End If
    End Sub

    Private Sub txtBuscador_TextChanged(sender As Object, e As EventArgs) Handles txtBuscador.TextChanged
        Dim returnValue As Boolean
        Dim comparisonType As StringComparison
        For i = listBoxFunciones.Items.Count - 1 To 0 Step -1
            returnValue = LCase(listBoxFunciones.Items(i)).StartsWith(LCase(txtBuscador.Text), comparisonType)
            If returnValue = True Then
                listBoxFunciones.ClearSelected() 'Borramos las selecciones anteriores
                txtBuscador.Focus() 'Establecemos el foco en el texbox
                listBoxFunciones.SetSelected(i, True)
            End If
        Next
    End Sub
    'FIN Manjeamos el buscador----------------------------

#End Region

    Private Sub GrabarSecuencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listBoxFunciones.SelectedIndex = 0
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

    End Sub

    'Añadir datos al datagridview
    Private Sub btnAnadir_Click(sender As Object, e As EventArgs) Handles btnAnadir.Click
        If txtnombreFuncion.Text <> "" Then
            Dim datos(5) As String
            'Añadimos a toda la matriz un campo en blanco
            For i = 0 To datos.Length - 1
                datos(i) = ""
            Next
            datos(0) = (txtnombreFuncion.Text)
            If Combo1.Enabled = True Then
                datos(1) = (Combo1.SelectedItem.ToString)
            End If
            If combo2.Enabled = True Then
                datos(2) = (combo2.SelectedItem.ToString)
            End If
            If combo3.Enabled = True Then
                datos(3) = (combo3.SelectedItem.ToString)
            End If
            If combo4.Enabled = True Then
                datos(4) = (combo4.SelectedItem.ToString)
            End If
            If combo5.Enabled = True Then
                datos(5) = (combo5.SelectedItem.ToString)
            End If
            'lo añadimos
            DataGridView1.Rows.Add(datos)
        End If
    End Sub
    'Se selecciona alguna función del listbox
    Private Sub listBoxFunciones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listBoxFunciones.SelectedIndexChanged
        If txtBuscador.ContainsFocus = False Then
            BackgroundWorker2.RunWorkerAsync()
            txtnombreFuncion.Text = listBoxFunciones.SelectedItem.ToString
            txtdescripción.Text = objetoSecuencia.Textodescripcion(txtnombreFuncion.Text)
            Select Case listBoxFunciones.SelectedItem
                Case "Blanco y negro"
                    ResetearControles(1)

                    Combo1.DataSource = objetoSecuencia.valor1to255
                    Combo1.SelectedItem = 128

                Case "Escala de grises"
                    ResetearControles(1)

                    Combo1.DataSource = objetoSecuencia.valor0to127
                    Combo1.SelectedItem = 0
                Case "Brillo"
                    ResetearControles(1)

                    Combo1.DataSource = objetoSecuencia.valorMenos255to255
                    Combo1.SelectedItem = 10

                Case "Invertir colores (rojo, verde, azul)"
                    ResetearControles(3)

                    Combo1.DataSource = New ArrayList(objetoSecuencia.valorBooleano)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valorBooleano)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valorBooleano)
                    Combo1.SelectedIndex = 0
                    combo2.SelectedItem = 0
                Case "Sepia"
                    ResetearControles(0)
                Case "Filtros básicos (rojo, verde, azul)"
                    ResetearControles(3)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valorBooleano)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valorBooleano)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valorBooleano)
                    Combo1.SelectedIndex = 0
                    combo2.SelectedIndex = 1
                    combo3.SelectedIndex = 1
                Case "RGB a (BGR, GRB, RBG)"
                    ResetearControles(3)

                    Combo1.DataSource = New ArrayList(objetoSecuencia.valorBooleano)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valorBooleano)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valorBooleano)
                    Combo1.SelectedIndex = 0
                    combo2.SelectedIndex = 1
                    combo3.SelectedIndex = 1
                Case "Redimensionar"
                    ResetearControles(2)

                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor1to5000)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor1to5000)

                    Combo1.SelectedItem = 500
                    combo2.SelectedItem = 500

                Case "Contraste (recomendado)"
                    ResetearControles(1)
                    Combo1.DataSource = objetoSecuencia.valorMenos1to1y3decimales
                    Combo1.SelectedIndex = 1000


                Case "Contraste"
                    ResetearControles(2)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    Combo1.SelectedItem = 255
                    combo2.SelectedItem = 0

                Case "Correción de gamma"
                    ResetearControles(3)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0to5con2decimales)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0to5con2decimales)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valor0to5con2decimales)

                    Combo1.SelectedIndex = 100
                    combo2.SelectedIndex = 100
                    combo3.SelectedIndex = 100
                Case "Exposición"
                    ResetearControles(1)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0to2con3decimales)
                    Combo1.SelectedIndex = 1000

                Case "Modificar canales"
                    ResetearControles(4)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valorMenos255to255)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valorMenos255to255)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valorMenos255to255)
                    combo4.DataSource = New ArrayList(objetoSecuencia.valorMenos255to255)
                    Combo1.SelectedItem = 0
                    combo2.SelectedItem = 0
                    combo3.SelectedItem = 0
                    combo4.SelectedItem = 0
                Case "Reducir colores"
                    ResetearControles(1)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    Combo1.SelectedItem = 255
                Case "Filtrar colores (rojo)"
                    ResetearControles(3)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valor0to255)

                    Combo1.SelectedItem = 0
                    combo2.SelectedItem = 0
                    combo3.SelectedItem = 0

                Case "Filtrar colores (verde)"
                    ResetearControles(3)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valor0to255)

                    Combo1.SelectedItem = 0
                    combo2.SelectedItem = 0
                    combo3.SelectedItem = 0
                Case "Filtrar colores (azul)"
                    ResetearControles(3)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valor0to255)

                    Combo1.SelectedItem = 0
                    combo2.SelectedItem = 0
                    combo3.SelectedItem = 0

                Case "Detectar contornos"
                    ResetearControles(4)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor5to50)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo4.DataSource = New ArrayList(objetoSecuencia.valor0to255)

                    Combo1.SelectedItem = 20
                    combo2.SelectedItem = 70
                    combo3.SelectedItem = 150
                    combo4.SelectedItem = 29
                Case "Operación aritmética - Suma"
                    ResetearControles(4)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo4.DataSource = New ArrayList(objetoSecuencia.valor0to255)

                    Combo1.SelectedItem = 0
                    combo2.SelectedItem = 0
                    combo3.SelectedItem = 0
                    combo4.SelectedItem = 0

                Case "Operación aritmética - Resta"
                    ResetearControles(4)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0toMenos255)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0toMenos255)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valor0toMenos255)
                    combo4.DataSource = New ArrayList(objetoSecuencia.valor0toMenos255)

                    Combo1.SelectedItem = 0
                    combo2.SelectedItem = 0
                    combo3.SelectedItem = 0
                    combo4.SelectedItem = 0
                Case "Operación aritmética - División"
                    ResetearControles(4)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0_01to255con2decimales)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0_01to255con2decimales)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valor0_01to255con2decimales)
                    combo4.DataSource = New ArrayList(objetoSecuencia.valor0_01to255con2decimales)

                    Combo1.SelectedIndex = 99
                    combo2.SelectedIndex = 99
                    combo3.SelectedIndex = 99
                    combo4.SelectedIndex = 99

                Case "Operación aritmética - Multiplicación"
                    ResetearControles(4)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valorMenos255to255con2decimales)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valorMenos255to255con2decimales)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valorMenos255to255con2decimales)
                    combo4.DataSource = New ArrayList(objetoSecuencia.valorMenos255to255con2decimales)

                    Combo1.SelectedIndex = 25600
                    combo2.SelectedIndex = 25600
                    combo3.SelectedIndex = 25600
                    combo4.SelectedIndex = 25600

                Case "Operación lógicas - AND"
                    ResetearControles(4)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo4.DataSource = New ArrayList(objetoSecuencia.valor0to255)

                    Combo1.SelectedIndex = 255
                    combo2.SelectedIndex = 255
                    combo3.SelectedIndex = 255
                    combo4.SelectedIndex = 255

                Case "Operación lógicas - OR"
                    ResetearControles(4)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo4.DataSource = New ArrayList(objetoSecuencia.valor0to255)


                    Combo1.SelectedIndex = 0
                    combo2.SelectedIndex = 0
                    combo3.SelectedIndex = 0
                    combo4.SelectedIndex = 0

                Case "Operación lógicas - XOR"
                    ResetearControles(4)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo3.DataSource = New ArrayList(objetoSecuencia.valor0to255)
                    combo4.DataSource = New ArrayList(objetoSecuencia.valor0to255)

                    Combo1.SelectedIndex = 0
                    combo2.SelectedIndex = 0
                    combo3.SelectedIndex = 0
                    combo4.SelectedIndex = 0

                Case "Reflexión horizontal"
                    ResetearControles(0)

                Case "Reflexión vertical"
                    ResetearControles(0)

                Case "Traslación"
                    ResetearControles(2)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor0to2000)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valor0to2000)

                    Combo1.SelectedItem = 0
                    combo2.SelectedItem = 0

                Case "Voltear"
                    ResetearControles(1)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.ValorVolteados)
                    Combo1.SelectedIndex = 0

                Case "Density Slicing automático"
                    ResetearControles(2)
                    Combo1.DataSource = New ArrayList(objetoSecuencia.valor2to15)
                    combo2.DataSource = New ArrayList(objetoSecuencia.valorBooleano)

                    Combo1.SelectedItem = 5
                    combo2.SelectedIndex = 0
            End Select
        End If
       
    End Sub
    Dim pasos(,) As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            ReDim pasos(DataGridView1.Rows.Count - 1, 5)
            For i = 0 To pasos.GetUpperBound(0)
                pasos(i, 0) = DataGridView1.Item(0, i).Value
                pasos(i, 1) = DataGridView1.Item(1, i).Value
                pasos(i, 2) = DataGridView1.Item(2, i).Value
                pasos(i, 3) = DataGridView1.Item(3, i).Value
                pasos(i, 4) = DataGridView1.Item(4, i).Value
                pasos(i, 5) = DataGridView1.Item(5, i).Value
            Next
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Principal.PictureBox1.Image = objetoTratamiento.Secuencia(pasos, bmpP)

    End Sub
     
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        DataGridView1.Rows.Clear()
    End Sub



    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.Rows.Count = 0 Then 'Comprobamos si hay algo en el datagridview
            MessageBox.Show("No hay ninguna secuencia creada, por favor, añada alguna.", "Ayuda Apolo", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim nombre As String
        Me.TopMost = False
        nombre = (InputBox("Introduzca el nombre de su secuencia", "Guardar secuencia", "Secuencia_personalizada"))
        If nombre <> "" Then 'Comprobamos que el nombre no está vacío

            'Comprobamos que no haya un archivo igual en el directorio
            If verificarNombreArchivo(nombre) = False Then
                Dim respuesta As DialogResult = MessageBox.Show("Esta secuencia ya existe, ¿desea sobreescribirla?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error)
                Select Case respuesta
                    Case Windows.Forms.DialogResult.Yes
                        guardarDataGrid(DataGridView1, nombre)
                    Case Windows.Forms.DialogResult.No
                        Exit Sub
                End Select
            End If
            guardarDataGrid(DataGridView1, nombre)

        Else
            MessageBox.Show("Por favor, escriba un nombre válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ImportarSecuencia.ShowDialog()
    End Sub
#Region "Funciones XML"
    Private Function verificarNombreArchivo(ByVal nombreArchivo As String) As Boolean
        verificarNombreArchivo = True

        Dim folder As New DirectoryInfo(System.IO.Directory.GetCurrentDirectory() & "\Secuencia\") 'Directorio
        For Each file As FileInfo In folder.GetFiles() 'Comprobamos si hay un archivo igual
            If file.ToString = nombreArchivo & ".xml" Then
                verificarNombreArchivo = False
            End If
        Next

    End Function

    Private Sub guardarDataGrid(ByVal data As DataGridView, ByVal nombreArchivo As String)

        Try
            Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter(System.IO.Directory.GetCurrentDirectory() & "\Secuencia\" & nombreArchivo & ".xml", System.Text.Encoding.UTF8)
            myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
            myXmlTextWriter.WriteStartDocument(False)
            'Crear el elemento de documento principal.
            myXmlTextWriter.WriteStartElement("Secuencia")



            For filas As Integer = 0 To data.RowCount - 1
                myXmlTextWriter.WriteStartElement("Datos_secuencia")
                Dim parametro1, parametro2, parametro3, parametro4, parametro5 As String

                parametro1 = data.Item(1, filas).Value
                If parametro1 = "" Then parametro1 = "NO_DATA"
                parametro2 = data.Item(2, filas).Value
                If parametro2 = "" Then parametro2 = "NO_DATA"
                parametro3 = data.Item(3, filas).Value
                If parametro3 = "" Then parametro3 = "NO_DATA"
                parametro4 = data.Item(4, filas).Value
                If parametro4 = "" Then parametro4 = "NO_DATA"
                parametro5 = data.Item(5, filas).Value
                If parametro5 = "" Then parametro5 = "NO_DATA"

                'Crear un elemento llamado 'feature' con un nodo de texto
                ' y cerrar el elemento.
                myXmlTextWriter.WriteStartElement("Nombre")
                myXmlTextWriter.WriteString((data.Item(0, filas).Value))
                myXmlTextWriter.WriteEndElement()


                myXmlTextWriter.WriteStartElement("Parametro1")
                myXmlTextWriter.WriteString(parametro1)
                myXmlTextWriter.WriteEndElement()

                myXmlTextWriter.WriteStartElement("Parametro2")
                myXmlTextWriter.WriteString(parametro2)
                myXmlTextWriter.WriteEndElement()

                myXmlTextWriter.WriteStartElement("Parametro3")
                myXmlTextWriter.WriteString(parametro3)
                myXmlTextWriter.WriteEndElement()

                myXmlTextWriter.WriteStartElement("Parametro4")
                myXmlTextWriter.WriteString(parametro4)
                myXmlTextWriter.WriteEndElement()

                myXmlTextWriter.WriteStartElement("Parametro5")
                myXmlTextWriter.WriteString(parametro5)
                myXmlTextWriter.WriteEndElement()

                'Cerramos style
                myXmlTextWriter.WriteEndElement()
            Next


            'Cerrar el elemento primario secuencia.
            myXmlTextWriter.WriteEndElement()
            myXmlTextWriter.Flush()
            myXmlTextWriter.Close()

        Catch e As System.ArgumentException
            MessageBox.Show("Caraceteres no válidos en el nombre del archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub rellenarGRidconXML(ByVal grid As DataGridView, ByVal rutaXML As String)
        Try
            'Preparamos el xml
            Dim NodeIter As XPathNodeIterator
            Dim docNav As New XPathDocument(rutaXML)
            Dim nav = docNav.CreateNavigator

            Dim Exnom, Exparam1, Exparam2, Exparam3, Exparam4, Exparam5 As String

            Exnom = "Secuencia/Datos_secuencia/Nombre"
            Exparam1 = "Secuencia/Datos_secuencia/Parametro1"
            Exparam2 = "Secuencia/Datos_secuencia/Parametro2"
            Exparam3 = "Secuencia/Datos_secuencia/Parametro3"
            Exparam4 = "Secuencia/Datos_secuencia/Parametro4"
            Exparam5 = "Secuencia/Datos_secuencia/Parametro5"



            Dim nombre As New ArrayList
            Dim parametr1 As New ArrayList
            Dim parametr2 As New ArrayList
            Dim parametr3 As New ArrayList
            Dim parametr4 As New ArrayList
            Dim parametr5 As New ArrayList

            'Recorremos el xml
            NodeIter = nav.Select(Exnom)
            While (NodeIter.MoveNext())
                nombre.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Exparam1)
            While (NodeIter.MoveNext())
                parametr1.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Exparam2)
            While (NodeIter.MoveNext())
                parametr2.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Exparam3)
            While (NodeIter.MoveNext())
                parametr3.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Exparam4)
            While (NodeIter.MoveNext())
                parametr4.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Exparam5)
            While (NodeIter.MoveNext())
                parametr5.Add(NodeIter.Current.Value)
            End While

            For i = 0 To nombre.Count - 1
                grid.Rows.Add(nombre(i), parametr1(i), parametr2(i), parametr3(i), parametr4(i), parametr5(i))
            Next
        Catch e As System.IO.FileNotFoundException
            MessageBox.Show("El archivo no se ha encontrado. Es posible que no haya activado la opción de guardar todas las peticiones HTTP de las diferentes sesiones." & vbCrLf & "Si desea activarlo, acceda al menú Configuración/Opciones/Registro y reinicie el programa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch e As Exception
            MessageBox.Show("Algo ha ocurrido, por favor, inténtelo más tarde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try


    End Sub
#End Region


  

   
End Class