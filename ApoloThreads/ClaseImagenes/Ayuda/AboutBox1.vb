Public NotInheritable Class AboutBox1
    Dim objetoActualizacion As New Actualizar 'Instancia a la clase actualizar
    Dim Actualizar() As String 'contendrá los datos de la actualización (datos del archivo descargado)

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Establezca el título del formulario.
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("Acerca de {0}", ApplicationTitle)
        ' Inicialice todo el texto mostrado en el cuadro Acerca de.
        ' TODO: personalice la información del ensamblado de la aplicación en el panel "Aplicación" del 
        '    cuadro de diálogo propiedades del proyecto (bajo el menú "Proyecto").
        Me.LabelProductName.Text = My.Application.Info.ProductName
        Me.LabelVersion.Text = String.Format("Versión {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description & vbCrLf & "¿Cuáles son los objetivos y finalidades de Apolo?" & vbCrLf & "El objetivo principal de Apolo es el conocimiento de las técnicas básicas para tratamiento digital de imágenes. Apolo no pretende ser rápido, Apolo pretende ser fácil. Fácil desde el punto de vista de la programación. Apolo podría reducir la velocidad de procesamiento (en muchas ocasiones) a la mitad, pero Apolo, por su filosofía, prefiere una claridad en todas sus funciones e instrucciones a una mayor velocidad de procesamiento. Y usted podría preguntarse por qué, porque el principal objetivo de Apolo es el aprendizaje de los algoritmos básicos de tratamiento de imágenes y eso se obtiene con claridad y simplicidad. Si no está convencido y cree que lo simple puede hacerse más rápido, no lo dude, entre en el menú Ayuda y pulse la opción ""Colabora con el proyecto"", ¡Apolo se lo agradecerá!"


        Actualizar = Nothing
        PictureBox1.Visible = True
        txtMejoras.Text = "Comprobando actualizaciones..."
        LinkLabel1.Visible = False
        'Comprobar actualizaciones
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If

    End Sub

   

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Actualizar = objetoActualizacion.ComprobarVersion()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        PictureBox1.Visible = False
        txtMejoras.Location = New Size(PictureBox1.Location.X, txtMejoras.Location.Y)
        Select Case Actualizar(0)
            Case "Error"
                txtMejoras.Text = "No se pudo conectar. Compruebe las actualizaciones más tarde."
            Case My.Application.Info.Version.ToString
                txtMejoras.Text = "Apolo está actualizado"
            Case Else
                txtMejoras.Text = "Hay una nueva versión disponible:" & vbCrLf
                txtMejoras.Text += "Versión: " & Actualizar(0) & vbCrLf & "Mejoras: " & vbCrLf
                For i = 1 To Actualizar.Length - 1
                    txtMejoras.Text += "*" & Actualizar(i) & vbCrLf
                Next
                LinkLabel1.Visible = True
                txtMejoras.ScrollBars = ScrollBars.Both
                Me.Height = 350
        End Select
    End Sub

    Private Sub OKButton_Click_1(sender As Object, e As EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_MouseClick(sender As Object, e As MouseEventArgs) Handles LinkLabel1.MouseClick
        Dim rutaArchivo As String
        If System.Environment.Is64BitOperatingSystem = True Then 'Comprobamos el tipo de sistema operativo
            rutaArchivo = objetoActualizacion.DescargarActualizacion(True)
        Else
            rutaArchivo = objetoActualizacion.DescargarActualizacion(False)
        End If
        If rutaArchivo <> "Error" Then
            Dim respuesta = MessageBox.Show("Si decide instalar la nueva actualización se cerrará Apolo, ¿está seguro de que desea actualizar ahora?", "Aviso instalador", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            If respuesta = Windows.Forms.DialogResult.Yes Then
                Process.Start(rutaArchivo)
                Application.Exit()
            End If
        Else
            txtMejoras.Text = "Algo ha ocurrido, no se ha podido descargar... Inténtelo más tarde."
        End If
       
    End Sub
End Class
