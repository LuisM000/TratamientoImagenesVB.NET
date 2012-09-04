Public Class Filtrpersonal

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Select Case ComboBox1.SelectedIndex
            Case 0
                filtroPersonalString1 = "original"
            Case 1
                filtroPersonalString1 = "BN"
            Case 2
                filtroPersonalString1 = "gris"
            Case 3
                filtroPersonalString1 = "invertir"
            Case 4
                filtroPersonalString1 = "sepia"
            Case 5
                filtroPersonalString1 = "etiopiaH"
            Case 6
                filtroPersonalString1 = "etiopiaV"
            Case 7
                filtroPersonalString1 = "rojo"
            Case 8
                filtroPersonalString1 = "verde"
            Case 9
                filtroPersonalString1 = "azul"
            Case 10
                filtroPersonalString1 = "BGR"
            Case 11
                filtroPersonalString1 = "GRB"
            Case 12
                filtroPersonalString1 = "RBG"
            Case 13
                filtroPersonalString1 = "contornos"
            Case 14
                filtroPersonalString1 = "reducir"
            Case 15
                filtroPersonalString1 = "oleo"
            Case 16
                filtroPersonalString1 = "x5"
            Case 17
                filtroPersonalString1 = "x7"
            Case Else
                filtroPersonalString1 = "original"
        End Select


        Select Case ComboBox2.SelectedIndex
            Case 0
                filtroPersonalString2 = "original"
            Case 1
                filtroPersonalString2 = "BN"
            Case 2
                filtroPersonalString2 = "gris"
            Case 3
                filtroPersonalString2 = "invertir"
            Case 4
                filtroPersonalString2 = "sepia"
            Case 5
                filtroPersonalString2 = "etiopiaH"
            Case 6
                filtroPersonalString2 = "etiopiaV"
            Case 7
                filtroPersonalString2 = "rojo"
            Case 8
                filtroPersonalString2 = "verde"
            Case 9
                filtroPersonalString2 = "azul"
            Case 10
                filtroPersonalString2 = "BGR"
            Case 11
                filtroPersonalString2 = "GRB"
            Case 12
                filtroPersonalString2 = "RBG"
            Case 13
                filtroPersonalString2 = "contornos"
            Case 14
                filtroPersonalString2 = "reducir"
            Case 15
                filtroPersonalString2 = "oleo"
            Case 16
                filtroPersonalString2 = "x5"
            Case 17
                filtroPersonalString2 = "x7"
            Case Else
                filtroPersonalString2 = "original"
        End Select
        pasoFiltrPer = True
        Me.Close()
    End Sub
End Class