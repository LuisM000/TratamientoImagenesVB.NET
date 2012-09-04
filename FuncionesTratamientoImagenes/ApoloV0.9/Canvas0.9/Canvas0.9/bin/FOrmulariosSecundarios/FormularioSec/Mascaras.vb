Imports WindowsApplication1.Class1

Public Class Mascaras
    Dim objeto As New tratamiento.mascaras

    Private Sub ListBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseClick
        TextBox2.Text = ListBox1.SelectedItem
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim mascara(2, 2) As Double
        Select Case ListBox1.SelectedItem
            Case "Paso bajo coeficiente 9"
                mascara = objeto.tipodeMascara("LOW9")
            Case "Paso bajo coeficiente 10"
                mascara = objeto.tipodeMascara("LOW10")
            Case "Paso bajo coeficiente 12"
                mascara = objeto.tipodeMascara("LOW12")
            Case "Paso alto coeficiente 1a"
                mascara = objeto.tipodeMascara("HIGH1a")
            Case "Paso alto coeficiente 1b"
                mascara = objeto.tipodeMascara("HIGH1b")
            Case "Paso alto coeficiente 16"
                mascara = objeto.tipodeMascara("HIGH16")
            Case "Resta movimiento 1"
                mascara = objeto.tipodeMascara("Rest1")
            Case "Resta movimiento 2"
                mascara = objeto.tipodeMascara("Rest2")
            Case "Resta movimiento 3"
                mascara = objeto.tipodeMascara("Rest3")
            Case "Laplaciano 1"
                mascara = objeto.tipodeMascara("Lap1")
            Case "Laplaciano 2"
                mascara = objeto.tipodeMascara("Lap2")
            Case "Laplaciano 3"
                mascara = objeto.tipodeMascara("Lap3")
            Case "Laplaciano 4"
                mascara = objeto.tipodeMascara("Lap4")
            Case "Laplaciano horizontal"
                mascara = objeto.tipodeMascara("Lap5")
            Case "Laplaciano vertical"
                mascara = objeto.tipodeMascara("Lap6")
            Case "Laplaciano diagonal"
                mascara = objeto.tipodeMascara("Lap7")
            Case "Gradiente este"
                mascara = objeto.tipodeMascara("GradEste")
            Case "Gradiente sudeste"
                mascara = objeto.tipodeMascara("GradSudeste")
            Case "Gradiente sur"
                mascara = objeto.tipodeMascara("GradSur")
            Case "Gradiente oeste"
                mascara = objeto.tipodeMascara("GradOeste")
            Case "Gradiente noreste"
                mascara = objeto.tipodeMascara("GradNoroe")
            Case "Gradiente norte"
                mascara = objeto.tipodeMascara("GradNorte")
            Case "Embossing este"
                mascara = objeto.tipodeMascara("EmbEste")
            Case "Embossing sudeste"
                mascara = objeto.tipodeMascara("EmbSudeste")
            Case "Embossing sur"
                mascara = objeto.tipodeMascara("EmbSur")
            Case "Embossing oeste"
                mascara = objeto.tipodeMascara("EmbOeste")
            Case "Embossing noreste"
                mascara = objeto.tipodeMascara("EmbNoreste")
            Case "Embossing norte"
                mascara = objeto.tipodeMascara("EmbNorte")
            Case "Sobel horizontal"
                mascara = objeto.tipodeMascara("SobelH")
            Case "Sobel vertical"
                mascara = objeto.tipodeMascara("SobelV")
            Case "Sobel diagonal 1"
                mascara = objeto.tipodeMascara("SobelDiagonal1")
            Case "Sobel diagonal 2"
                mascara = objeto.tipodeMascara("SobelDiagonal2")
            Case "Prewitt horizontal"
                mascara = objeto.tipodeMascara("PrewittH")
            Case "Prewitt vertical"
                mascara = objeto.tipodeMascara("PrewittV")
            Case "Prewitt diagonal 1"
                mascara = objeto.tipodeMascara("PrewittDiag1")
            Case "Prewitt diagonal 2"
                mascara = objeto.tipodeMascara("PrewittDiag2")
            Case "Líneas verticales"
                mascara = objeto.tipodeMascara("Verticales")
            Case "Líneas horizontales"
                mascara = objeto.tipodeMascara("Horizontales")
            Case "Repujado"
                mascara = objeto.tipodeMascara("Repujado")
            Case "Kirsch 0º"
                mascara = objeto.tipodeMascara("Kirsch0")
            Case "Kirsch 45º"
                mascara = objeto.tipodeMascara("Kirsch45")
            Case "Kirsch 90º"
                mascara = objeto.tipodeMascara("Kirsch90")
            Case "Kirsch 135º"
                mascara = objeto.tipodeMascara("Kirsch135")
            Case "Kirsch 180º"
                mascara = objeto.tipodeMascara("Kirsch180")
            Case "Kirsch 225º"
                mascara = objeto.tipodeMascara("Kirsch225")
            Case "Kirsch 270º"
                mascara = objeto.tipodeMascara("Kirsch270")
            Case "Kirsch 315º"
                mascara = objeto.tipodeMascara("Kirsch315")
            Case "Frei-Chen horizontal"
                mascara = objeto.tipodeMascara("FRH")
            Case "Frei-Chen vertical"
                mascara = objeto.tipodeMascara("FRV")


        End Select
        For i = 0 To 2
            For j = 0 To 2
                mascara(i, j) = Math.Round(mascara(i, j), 4)
            Next
        Next

        TextBox1.Text = "  (" & mascara(0, 0) & vbTab & mascara(0, 1) & vbTab & mascara(0, 2) & " )" & vbCrLf &
          "  (" & mascara(1, 0) & vbTab & mascara(1, 1) & vbTab & mascara(1, 2) & " )" & vbCrLf &
           "  (" & mascara(2, 0) & vbTab & mascara(2, 1) & vbTab & mascara(2, 2) & " )" & vbCrLf

    End Sub


    Private Sub TextBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox2.MouseDown
        TextBox2.SelectAll()
    End Sub


    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        Dim returnValue As Boolean
        Dim comparisonType As StringComparison

        For i = ListBox1.Items.Count - 1 To 0 Step -1
            returnValue = LCase(ListBox1.Items(i)).StartsWith(LCase(TextBox2.Text), comparisonType)

            If returnValue = True Then
                ListBox1.SetSelected(i, True)

            End If

        Next
       

    End Sub

    Private Sub Mascaras_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        ListBox1.SelectedIndex = ListBox1.FindString("Paso bajo coeficiente 9")
        TextBox2.Select()
        TextBox2.Text = ListBox1.SelectedItem

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
    End Sub
End Class