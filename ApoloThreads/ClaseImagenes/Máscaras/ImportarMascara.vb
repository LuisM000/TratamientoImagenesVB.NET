Imports System.IO
Imports System.Xml.XPath

Public Class ImportarMascara

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
    Function comprobarMascara(ByVal rutaArchivo As String)
        Try
            'Preparamos el archivo xml
            Dim NodeIter As XPathNodeIterator
            Dim docNav As New XPathDocument(rutaArchivo)
            Dim nav = docNav.CreateNavigator
            Dim ExBuscar As String
            ExBuscar = "Mascara"

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
    Private Sub ImportarMascara_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim listaDearchivos As New ArrayList
        'listamos los archivos xml del directorio(le enviamos el directorio actual)
        listaDearchivos = listaXML(System.IO.Directory.GetCurrentDirectory())

        ListBox1.Items.Clear() 'Borramos lo que había en el listbox

        For Each item In listaDearchivos
            If comprobarMascara(System.IO.Directory.GetCurrentDirectory() & "\" & item) = True Then
                ListBox1.Items.Add(item)
            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim respuesta As DialogResult = MessageBox.Show("¿Realmente desea eliminar de forma permanente el archivo?", "Maps.NET", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            Select Case respuesta
                Case Windows.Forms.DialogResult.Yes 'Borramos el archivo
                    Dim ruta As String
                    ruta = System.IO.Directory.GetCurrentDirectory() & "\" & ListBox1.SelectedItem 'Seleccionamos la ruta del archivo a borrar
                    Kill(ruta)
                Case Windows.Forms.DialogResult.No
                    'No hacemos nada
            End Select
            'Recargamos el listbox
            ImportarMascara_Load(sender, e)
        Catch
            MessageBox.Show("Algo ha fallado... inténtelo más tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'Recargamos el listbox
            ImportarMascara_Load(sender, e)
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim mascara = valoresMascara()
        MascaraManual.TextBox1.Text = mascara(0)
        MascaraManual.TextBox2.Text = mascara(1)
        MascaraManual.TextBox3.Text = mascara(2)
        MascaraManual.TextBox4.Text = mascara(3)
        MascaraManual.TextBox5.Text = mascara(4)
        MascaraManual.TextBox6.Text = mascara(5)
        MascaraManual.TextBox7.Text = mascara(6)
        MascaraManual.TextBox8.Text = mascara(7)
        MascaraManual.TextBox9.Text = mascara(8)
        MascaraManual.TextBox10.Text = mascara(9)
        MascaraManual.TextBox11.Text = mascara(10)
        MascaraManual.CheckBox1.Checked = True : MascaraManual.CheckBox2.Checked = True
        MascaraManual.TextBox10.Enabled = True
        MascaraManual.TextBox11.Enabled = True
    End Sub
    Function valoresMascara()
        Dim mascara As New ArrayList
        Try
            Dim rutaArchivoimportar As String = System.IO.Directory.GetCurrentDirectory() & "\" & ListBox1.SelectedItem
            'Preparamos el xml
            Dim NodeIter As XPathNodeIterator
            Dim docNav As New XPathDocument(rutaArchivoimportar)
            Dim nav = docNav.CreateNavigator

            Dim Ex00, Ex01, Ex02, Ex10, Ex11, Ex12, Ex20, Ex21, Ex22, Exdesv, Exfac As String

            Ex00 = "Mascara/ValoresMatriz/Mat00"
            Ex01 = "Mascara/ValoresMatriz/Mat01"
            Ex02 = "Mascara/ValoresMatriz/Mat02"
            Ex10 = "Mascara/ValoresMatriz/Mat10"
            Ex11 = "Mascara/ValoresMatriz/Mat11"
            Ex12 = "Mascara/ValoresMatriz/Mat12"
            Ex20 = "Mascara/ValoresMatriz/Mat20"
            Ex21 = "Mascara/ValoresMatriz/Mat21"
            Ex22 = "Mascara/ValoresMatriz/Mat22"

            Exdesv = "Mascara/Desviacion"
            Exfac = "Mascara/Factor"



            'Recorremos el xml
            NodeIter = nav.Select(Ex00)
            While (NodeIter.MoveNext())
                mascara.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex01)
            While (NodeIter.MoveNext())
                mascara.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex02)
            While (NodeIter.MoveNext())
                mascara.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex10)
            While (NodeIter.MoveNext())
                mascara.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex11)
            While (NodeIter.MoveNext())
                mascara.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex12)
            While (NodeIter.MoveNext())
                mascara.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex20)
            While (NodeIter.MoveNext())
                mascara.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex21)
            While (NodeIter.MoveNext())
                mascara.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex22)
            While (NodeIter.MoveNext())
                mascara.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Exdesv)
            While (NodeIter.MoveNext())
                mascara.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Exfac)
            While (NodeIter.MoveNext())
                mascara.Add(NodeIter.Current.Value)
            End While

        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("El archivo no se ha encontrado. Es posible que no haya activado la opción de guardar todas las peticiones HTTP de las diferentes sesiones." & vbCrLf & "Si desea activarlo, acceda al menú Configuración/Opciones/Registro y reinicie el programa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("Algo ha ocurrido, por favor, inténtelo más tarde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
        Return mascara
    End Function
End Class