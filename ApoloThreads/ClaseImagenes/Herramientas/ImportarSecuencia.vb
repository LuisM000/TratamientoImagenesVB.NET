Imports System.Xml.XPath
Imports System.IO

Public Class ImportarSecuencia
    Dim objetoSecuencia As New Secuencia

    Private Sub ImportarSecuencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim listaDearchivos As New ArrayList
        'listamos los archivos xml del directorio(le enviamos el directorio actual)
        listaDearchivos = listaXML(System.IO.Directory.GetCurrentDirectory() & "\Secuencia\")

        ListBox1.Items.Clear() 'Borramos lo que había en el listbox

        For Each item In listaDearchivos
            If comprobarEstilo(System.IO.Directory.GetCurrentDirectory() & "\Secuencia\" & item) = True Then
                ListBox1.Items.Add(item)
            End If
        Next
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

    Private Function comprobarEstilo(ByVal rutaArchivo As String)
        Try

            'Preparamos el archivo xml
            Dim NodeIter As XPathNodeIterator
            Dim docNav As New XPathDocument(rutaArchivo)
            Dim nav = docNav.CreateNavigator
            Dim ExBuscar As String
            ExBuscar = "Secuencia"


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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GrabarSecuencia.DataGridView1.Rows.Clear()
        GrabarSecuencia.rellenarGRidconXML(GrabarSecuencia.DataGridView1, System.IO.Directory.GetCurrentDirectory() & "\Secuencia\" & ListBox1.SelectedItem)
 
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ListBox1.SelectedIndex <> -1 Then 'Si hay algún ítem seleccionado
            Try
                Dim respuesta As DialogResult = MessageBox.Show("¿Realmente desea eliminar de forma permanente el archivo?", "Apolo thread", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Select Case respuesta
                    Case Windows.Forms.DialogResult.Yes 'Borramos el archivo
                        Dim ruta As String
                        ruta = System.IO.Directory.GetCurrentDirectory() & "\Secuencia\" & ListBox1.SelectedItem 'Seleccionamos la ruta del archivo a borrar
                        My.Computer.FileSystem.DeleteFile(ruta)
                    Case Windows.Forms.DialogResult.No
                        'No hacemos nada
                End Select
                'Recargamos el listbox
                ImportarSecuencia_Load(sender, e)
            Catch
                MessageBox.Show("Algo ha fallado... inténtelo más tarde", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Recargamos el listbox
                ImportarSecuencia_Load(sender, e)
            End Try
        End If
    End Sub
End Class