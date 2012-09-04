Imports WindowsApplication1.Class1
Imports WindowsApplication1.Class2

Public Class Recurso
    Dim objetorec As New tratamiento
    Dim objetoform As New trataformu 'Objeto de la clase para formulario
    Dim vistapreviaI As Boolean
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
           
                Dim url As String
                url = TextBox1.Text
                imagenRecurso = objetorec.cargarrecursoweb(url)

            Principal.Text = objetorec.nombreRecurso(TextBox1.Text)
            Principal.ToolStripStatusLabel5.Text = objetorec.nombreRecurso(TextBox1.Text)
        Catch ex As Exception
            Principal.PictureBox1.Image = objetorec.cargarrecursoweb("sin recurso")
            objetoform.refrescar(Principal.PictureBox1, Principal.Panel1)
            Principal.Text = "Recurso no encontrado"

        End Try

        Principal.Text = objetorec.nombreRecurso(TextBox1.Text)
        vistapreviaI = False
        Me.Close()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim url As String
        url = TextBox1.Text
        PictureBox1.Image = objetorec.cargarrecursoweb(url)
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        Dim tamaño As New Size(669, 313)
        Me.MinimumSize = tamaño
        Me.MaximumSize = tamaño

        Dim localizacion As New Size(200, 243)
        Button1.Location = localizacion

        Dim localizacion2 As New Size(337, 243)
        Button3.Location = localizacion2
        PictureBox1.Visible = True
        vistapreviaI = True

    End Sub

    Private Sub Recurso_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PictureBox1.BorderStyle = BorderStyle.None
        PictureBox1.Visible = False
        Dim tamaño As New Size(669, 128)
        Me.MinimumSize = tamaño
        Me.MaximumSize = tamaño

        Dim localizacion As New Size(200, 48)
        Button1.Location = localizacion

        Dim localizacion2 As New Size(337, 48)
        Button3.Location = localizacion2
        TextBox1.Select()
        TextBox1.Text = TextBox1.Text

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
End Class