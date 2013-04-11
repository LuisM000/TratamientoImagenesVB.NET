Imports System.IO
Imports System.Xml.XPath
Public Class ImportarMatriz

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
    Function comprobarMatriz(ByVal rutaArchivo As String)
        Try
            'Preparamos el archivo xml
            Dim NodeIter As XPathNodeIterator
            Dim docNav As New XPathDocument(rutaArchivo)
            Dim nav = docNav.CreateNavigator
            Dim ExBuscar As String
            ExBuscar = "Matriz"

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

    Private Sub ImportarMatriz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim listaDearchivos As New ArrayList
        'listamos los archivos xml del directorio(le enviamos el directorio actual)
        listaDearchivos = listaXML(System.IO.Directory.GetCurrentDirectory())

        ListBox1.Items.Clear() 'Borramos lo que había en el listbox

        For Each item In listaDearchivos
            If comprobarMatriz(System.IO.Directory.GetCurrentDirectory() & "\" & item) = True Then
                ListBox1.Items.Add(item)
            End If
        Next
    End Sub

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
                ImportarMatriz_Load(sender, e)
            Catch
                MessageBox.Show("Algo ha fallado... inténtelo más tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Recargamos el listbox
                ImportarMatriz_Load(sender, e)
            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListBox1.SelectedIndex <> -1 Then 'Si hay algún ítem seleccionado
            Dim mascara = valoresMatriz()
            Try
                Matriz.TextBox1.Text = mascara(0)
                Matriz.TextBox2.Text = mascara(1)
                Matriz.TextBox3.Text = mascara(2)
                Matriz.TextBox4.Text = mascara(3)
                Matriz.TextBox5.Text = mascara(4)
                Matriz.TextBox6.Text = mascara(5)
                Matriz.TextBox7.Text = mascara(6)
                Matriz.TextBox8.Text = mascara(7)
                Matriz.TextBox9.Text = mascara(8)
            Catch
            End Try
        Else
            Me.Close()
        End If
    End Sub

    Function valoresMatriz()
        Dim matriz As New ArrayList
        Try
            Dim rutaArchivoimportar As String = System.IO.Directory.GetCurrentDirectory() & "\" & ListBox1.SelectedItem
            'Preparamos el xml
            Dim NodeIter As XPathNodeIterator
            Dim docNav As New XPathDocument(rutaArchivoimportar)
            Dim nav = docNav.CreateNavigator

            Dim Ex00, Ex01, Ex02, Ex10, Ex11, Ex12, Ex20, Ex21, Ex22 As String

            Ex00 = "Matriz/Mat00"
            Ex01 = "Matriz/Mat01"
            Ex02 = "Matriz/Mat02"
            Ex10 = "Matriz/Mat10"
            Ex11 = "Matriz/Mat11"
            Ex12 = "Matriz/Mat12"
            Ex20 = "Matriz/Mat20"
            Ex21 = "Matriz/Mat21"
            Ex22 = "Matriz/Mat22"

            'Recorremos el xml
            NodeIter = nav.Select(Ex00)
            While (NodeIter.MoveNext())
                matriz.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex01)
            While (NodeIter.MoveNext())
                matriz.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex02)
            While (NodeIter.MoveNext())
                matriz.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex10)
            While (NodeIter.MoveNext())
                matriz.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex11)
            While (NodeIter.MoveNext())
                matriz.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex12)
            While (NodeIter.MoveNext())
                matriz.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex20)
            While (NodeIter.MoveNext())
                matriz.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex21)
            While (NodeIter.MoveNext())
                matriz.Add(NodeIter.Current.Value)
            End While
            NodeIter = nav.Select(Ex22)
            While (NodeIter.MoveNext())
                matriz.Add(NodeIter.Current.Value)
            End While
          

        Catch ex As System.IO.FileNotFoundException
            MessageBox.Show("El archivo no se ha encontrado. Es posible que no haya activado la opción de guardar todas las peticiones HTTP de las diferentes sesiones." & vbCrLf & "Si desea activarlo, acceda al menú Configuración/Opciones/Registro y reinicie el programa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Catch ex As Exception
            MessageBox.Show("Algo ha ocurrido, por favor, inténtelo más tarde.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End Try
        Return matriz
    End Function
End Class