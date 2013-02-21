Imports ClaseImagenes.Apolo
Imports System.IO
Imports System.Xml.XPath
Imports System.Xml

Public Class Matriz

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal
    Function comprobarDatos()
        For Each c As Control In Me.GroupBox1.Controls
            If TypeOf c Is TextBox Then
                If IsNumeric(c.Text) = False Then
                    c.BackColor = Color.Red
                Else
                    c.BackColor = Color.White
                End If
            End If
        Next
        Return comprobarColores()
    End Function
    Function comprobarColores()
        For Each c As Control In Me.GroupBox1.Controls
            If TypeOf c Is TextBox Then
                If c.BackColor = Color.Red Then
                    Return False
                    Exit Function
                End If
            End If
        Next
        Return True
    End Function
    Sub restablecer()
        For Each c As Control In Me.GroupBox1.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If
        Next
    End Sub

    Private Function verificarNombreArchivo(ByVal nombreArchivo As String) As Boolean
        verificarNombreArchivo = True

        Dim folder As New DirectoryInfo(System.IO.Directory.GetCurrentDirectory()) 'Directorio
        For Each file As FileInfo In folder.GetFiles() 'Comprobamos si hay un archivo igual
            If file.ToString = nombreArchivo & ".xml" Then
                verificarNombreArchivo = False
            End If
        Next

    End Function
    Sub guardarMatriz(ByVal nombreArchivo As String, ByVal matriz As ArrayList)
        Try
            Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter(nombreArchivo & ".xml", System.Text.Encoding.UTF8)
            myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
            myXmlTextWriter.WriteStartDocument(False)
            'Crear el elemento de documento principal.
            myXmlTextWriter.WriteStartElement("Matriz")

            'Crear un elemento llamado 'Mat(0,0)' con un nodo de texto
            ' y cerrar el elemento.
            myXmlTextWriter.WriteStartElement("Mat00")
            myXmlTextWriter.WriteString(matriz(0))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat01")
            myXmlTextWriter.WriteString(matriz(1))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat02")
            myXmlTextWriter.WriteString(matriz(2))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat10")
            myXmlTextWriter.WriteString(matriz(3))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat11")
            myXmlTextWriter.WriteString(matriz(4))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat12")
            myXmlTextWriter.WriteString(matriz(5))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat20")
            myXmlTextWriter.WriteString(matriz(6))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat21")
            myXmlTextWriter.WriteString(matriz(7))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat22")
            myXmlTextWriter.WriteString(matriz(8))
            myXmlTextWriter.WriteEndElement()

            'Cerrar el elemento Valores Matriz.
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.Flush()
            myXmlTextWriter.Close()

        Catch e As System.ArgumentException
            MessageBox.Show("Caraceteres no válidos en el nombre del archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub Matriz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False And comprobarDatos() = True Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Principal.PictureBox1.Image = objetoTratamiento.filtroponderado(bmpP, TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, TextBox9.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        restablecer()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If comprobarDatos() = False Then 'Comprobamos si hay algún error
            MessageBox.Show("Algo ha fallado. Revise los campos resaltados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim nombre = (InputBox("Introduzca el nombre de su matriz", "Guardar matriz", "Matriz_personalizada"))
        If nombre <> "" Then 'Comprobamos que el nombre no está vacío
            Dim DatosMatriz As New ArrayList({TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox8.Text, TextBox9.Text})

            'Comprobamos que no haya un archivo igual en el directorio
            If verificarNombreArchivo(nombre) = False Then
                Dim respuesta As DialogResult = MessageBox.Show("Esta configuración ya existe, ¿desea sobreescribirla?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Select Case respuesta
                    Case Windows.Forms.DialogResult.Yes
                        guardarMatriz(nombre, DatosMatriz)

                    Case Windows.Forms.DialogResult.No
                        Exit Sub
                End Select
            End If
            guardarMatriz(nombre, DatosMatriz)
        Else
            MessageBox.Show("Por favor, escriba un nombre válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ImportarMatriz.Show()
    End Sub
End Class