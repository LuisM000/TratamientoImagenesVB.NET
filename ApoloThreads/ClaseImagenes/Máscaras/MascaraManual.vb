Imports ClaseImagenes.Apolo
Imports System.IO
Imports System.Xml.XPath
Imports System.Xml

Public Class MascaraManual

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox1.Image) 'Imagen de principal


    Function ComprobarNumeros()
        For Each c As Control In Me.GroupBox1.Controls
            If TypeOf c Is TextBox Then
                If IsNumeric(c.Text) = False Then
                    c.BackColor = Color.Red
                Else
                    c.BackColor = Color.White
                End If
            End If
        Next
        TextBox10.BackColor = Color.White
        TextBox11.BackColor = Color.White
        If CheckBox1.Checked = True Then
            If IsNumeric(TextBox10.Text) = True Then
                TextBox10.BackColor = Color.White
            Else
                TextBox10.BackColor = Color.Red
            End If
        End If
        If CheckBox2.Checked = True Then
            If IsNumeric(TextBox11.Text) = True Then
                TextBox11.BackColor = Color.White
            Else
                TextBox11.BackColor = Color.Red
            End If
        End If
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
        For Each c As Control In Me.GroupBox2.Controls
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
        For Each c As Control In Me.GroupBox2.Controls
            If TypeOf c Is TextBox Then
                c.Text = ""
            End If
        Next
    End Sub
    Function ValoresMascara()
        Dim coefmascara(2, 2) As Double 'Máscara

        'Rellenamos la matriz
        coefmascara(0, 0) = CDbl(TextBox1.Text) : coefmascara(0, 1) = CDbl(TextBox2.Text) : coefmascara(0, 2) = CDbl(TextBox3.Text)
        coefmascara(1, 0) = CDbl(TextBox4.Text) : coefmascara(1, 1) = CDbl(TextBox5.Text) : coefmascara(1, 2) = CDbl(TextBox6.Text)
        coefmascara(2, 0) = CDbl(TextBox7.Text) : coefmascara(2, 1) = CDbl(TextBox8.Text) : coefmascara(2, 2) = CDbl(TextBox9.Text)
        Return coefmascara
    End Function
    Function valoresDesvFact()
        Dim desviFac(1) As Double
        desviFac(0) = 0
        desviFac(1) = 1
        If CheckBox1.Checked = True Then
            desviFac(0) = CDbl(TextBox10.Text)
        End If
        If CheckBox2.Checked = True Then
            desviFac(1) = CDbl(TextBox11.Text)
        End If
        Return desviFac
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
    Sub guardarMascara(ByVal nombreArchivo As String, ByVal mascara(,) As Double, ByVal desviacion As Double, ByVal factor As Double)
        Try
            Dim myXmlTextWriter As XmlTextWriter = New XmlTextWriter(nombreArchivo & ".xml", System.Text.Encoding.UTF8)
            myXmlTextWriter.Formatting = System.Xml.Formatting.Indented
            myXmlTextWriter.WriteStartDocument(False)
            'Crear el elemento de documento principal.
            myXmlTextWriter.WriteStartElement("Mascara")
            'Crear el elemento de documento principal.
            myXmlTextWriter.WriteStartElement("ValoresMatriz")


            'Crear un elemento llamado 'Mat(0,0)' con un nodo de texto
            ' y cerrar el elemento.
            myXmlTextWriter.WriteStartElement("Mat00")
            myXmlTextWriter.WriteString(mascara(0, 0))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat01")
            myXmlTextWriter.WriteString(mascara(0, 1))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat02")
            myXmlTextWriter.WriteString(mascara(0, 2))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat10")
            myXmlTextWriter.WriteString(mascara(1, 0))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat11")
            myXmlTextWriter.WriteString(mascara(1, 1))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat12")
            myXmlTextWriter.WriteString(mascara(1, 2))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat20")
            myXmlTextWriter.WriteString(mascara(2, 0))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat21")
            myXmlTextWriter.WriteString(mascara(2, 1))
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Mat22")
            myXmlTextWriter.WriteString(mascara(2, 2))
            myXmlTextWriter.WriteEndElement()

            'Cerrar el elemento Valores Matriz.
            myXmlTextWriter.WriteEndElement()


            'Crear un elemento llamado 'Desviacion y otro factor' con un nodo de texto
            ' y cerrar el elemento.
            myXmlTextWriter.WriteStartElement("Desviacion")
            myXmlTextWriter.WriteString(desviacion)
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.WriteStartElement("Factor")
            myXmlTextWriter.WriteString(factor)
            myXmlTextWriter.WriteEndElement()

            'Cerrar el elemento Mascara.
            myXmlTextWriter.WriteEndElement()

            myXmlTextWriter.Flush()
            myXmlTextWriter.Close()

        Catch e As System.ArgumentException
            MessageBox.Show("Caraceteres no válidos en el nombre del archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub



    Private Sub MascaraManual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RbRGB.Checked = True
        RBGrises.Checked = False
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Pintamos de rojo donde hay error 
        If ComprobarNumeros() = True Then 'Si no hay ninguno de rojo llamamos al hilo
            If BackgroundWorker1.IsBusy = False Then
                BackgroundWorker1.RunWorkerAsync()
            End If
        End If
    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim coefiMascara = ValoresMascara()
        Dim desvFact = valoresDesvFact()
        If RbRGB.Checked = True Then
            Principal.PictureBox1.Image = objetoTratamiento.mascara3x3RGB(bmpP, coefiMascara, desvFact(0), desvFact(1))
        Else
            Principal.PictureBox1.Image = objetoTratamiento.mascara3x3Grises(bmpP, coefiMascara, desvFact(0), desvFact(1))
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox11.Enabled = True
        Else
            TextBox11.Enabled = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox10.Enabled = True
        Else
            TextBox10.Enabled = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        restablecer()
    End Sub

    'Exportar como XML
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComprobarNumeros() = False Then 'Comprobamos si hay algún error
            MessageBox.Show("Algo ha fallado. Revise los campos resaltados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim nombre = (InputBox("Introduzca el nombre de su máscara", "Guardar máscara", "Mascara_personalizada"))
        If nombre <> "" Then 'Comprobamos que el nombre no está vacío
            Dim coefiMascara = ValoresMascara()
            Dim desvFact = valoresDesvFact()

            'Comprobamos que no haya un archivo igual en el directorio
            If verificarNombreArchivo(nombre) = False Then
                Dim respuesta As DialogResult = MessageBox.Show("Esta configuración ya existe, ¿desea sobreescribirla?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                Select Case respuesta
                    Case Windows.Forms.DialogResult.Yes
                        guardarMascara(nombre, coefiMascara, desvFact(0), desvFact(1))

                    Case Windows.Forms.DialogResult.No
                        Exit Sub
                End Select
            End If
            guardarMascara(nombre, coefiMascara, desvFact(0), desvFact(1))


        Else
            MessageBox.Show("Por favor, escriba un nombre válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

  
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ImportarMascara.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class