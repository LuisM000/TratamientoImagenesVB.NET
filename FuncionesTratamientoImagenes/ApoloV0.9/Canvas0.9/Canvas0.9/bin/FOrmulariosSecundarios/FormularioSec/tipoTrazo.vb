Imports System.Reflection

Public Class TipoTrazo

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        cambiar(ColorDialog1.Color, NumericUpDown1.Value, ComboBox1.Text)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            cambiar(ColorDialog1.Color, NumericUpDown1.Value, ComboBox1.Text)

        End If
    End Sub

    Private Sub TipoTrazo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        NumericUpDown1.Value = My.Settings.TrazoAnch
        ColorDialog1.Color = My.Settings.TrazoColor
        Dim formato As String
        Select Case My.Settings.TrazoForm
            Case "normal"
                formato = "Continua"
            Case "disc1"
                formato = "Discontinua 1"
            Case "disc2"
                formato = "Discontinua 2"
            Case "disc3"
                formato = "Discontinua 3"
            Case "disc4"
                formato = "Discontinua 4"
            Case "disc5"
                formato = "Discontinua 5"

            Case Else
                formato = "Continua"
        End Select
        Dim colorType As Type = GetType(System.Drawing.Color)

        Dim propInfoList As PropertyInfo() = colorType.GetProperties(BindingFlags.[Static] Or BindingFlags.DeclaredOnly Or BindingFlags.[Public])

        For Each c As System.Reflection.PropertyInfo In propInfoList
            ComboBox3.Items.Add(c.Name)
        Next

        ComboBox3.SelectedItem = My.Settings.TrazoInter

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Settings.TrazoColor = ColorDialog1.Color
        My.Settings.TrazoAnch = NumericUpDown1.Value
        My.Settings.TrazoInter = ComboBox3.SelectedItem

        Dim formato As String
        Select Case ComboBox1.Text
            Case "Continua"
                formato = "normal"
            Case "Discontinua 1"
                formato = "disc1"
            Case "Discontinua 2"
                formato = "disc2"
            Case "Discontinua 3"
                formato = "disc3"
            Case "Discontinua 4"
                formato = "disc4"
            Case "Discontinua 5"
                formato = "disc5"

            Case Else
                formato = "normal"
        End Select
        My.Settings.TrazoForm = formato

        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub




    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        cambiar(ColorDialog1.Color, NumericUpDown1.Value, ComboBox1.Text)
        Timer1.Enabled = False
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        cambiar(ColorDialog1.Color, NumericUpDown1.Value, ComboBox1.Text)


    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        My.Settings.TrazoInter = ComboBox3.SelectedItem
        cambiar(ColorDialog1.Color, NumericUpDown1.Value, ComboBox1.Text)

    End Sub
    Sub cambiar(ByVal color As Color, ByVal ancho As Integer, ByVal tipo As String)
        Dim dashValues As Single()
        Select Case ComboBox1.Text
            Case "Continua"
                dashValues = {9999, 1, 1, 1}
            Case "Discontinua 1"
                dashValues = {5, 2, 15, 4}
            Case "Discontinua 2"
                dashValues = {1, 2, 1, 2}
            Case "Discontinua 3"
                dashValues = {5, 1, 5, 1}
            Case "Discontinua 4"
                dashValues = {10, 1, 1, 1}
            Case "Discontinua 5"
                dashValues = {2, 3, 15, 9}

            Case Else
                dashValues = {9999, 1, 1, 1}
        End Select

        Dim lapiz As New Pen(ColorDialog1.Color, NumericUpDown1.Value)
        lapiz.DashPattern = dashValues
        Dim Picture1 As Graphics = PictureBox1.CreateGraphics
        PictureBox1.Refresh()

       

        Select Case My.Settings.TrazoInter
            Case "AliceBlue"
                Picture1.FillRectangle(Brushes.AliceBlue, 0, 0, 150, 150)
            Case "AntiqueWhite"
                Picture1.FillRectangle(Brushes.AntiqueWhite, 0, 0, 150, 150)
            Case "Aqua"
                Picture1.FillRectangle(Brushes.Aqua, 0, 0, 150, 150)
            Case "Aquamarine"
                Picture1.FillRectangle(Brushes.Aquamarine, 0, 0, 150, 150)
            Case "Azure"
                Picture1.FillRectangle(Brushes.Azure, 0, 0, 150, 150)
            Case "Beige"
                Picture1.FillRectangle(Brushes.Beige, 0, 0, 150, 150)
            Case "Bisque"
                Picture1.FillRectangle(Brushes.Bisque, 0, 0, 150, 150)
            Case "Black"
                Picture1.FillRectangle(Brushes.Black, 0, 0, 150, 150)
            Case "BlanchedAlmond"
                Picture1.FillRectangle(Brushes.BlanchedAlmond, 0, 0, 150, 150)
            Case "Blue"
                Picture1.FillRectangle(Brushes.Blue, 0, 0, 150, 150)
            Case "BlueViolet"
                Picture1.FillRectangle(Brushes.BlueViolet, 0, 0, 150, 150)
            Case "Brown"
                Picture1.FillRectangle(Brushes.Brown, 0, 0, 150, 150)
            Case "BurlyWood"
                Picture1.FillRectangle(Brushes.BurlyWood, 0, 0, 150, 150)
            Case "CadetBlue"
                Picture1.FillRectangle(Brushes.CadetBlue, 0, 0, 150, 150)
            Case "Chartreuse"
                Picture1.FillRectangle(Brushes.Chartreuse, 0, 0, 150, 150)
            Case "Chocolate"
                Picture1.FillRectangle(Brushes.Chocolate, 0, 0, 150, 150)
            Case "Coral"
                Picture1.FillRectangle(Brushes.Coral, 0, 0, 150, 150)
            Case "CornflowerBlue"
                Picture1.FillRectangle(Brushes.CornflowerBlue, 0, 0, 150, 150)
            Case "Cornsilk"
                Picture1.FillRectangle(Brushes.Cornsilk, 0, 0, 150, 150)
            Case "Crimson"
                Picture1.FillRectangle(Brushes.Crimson, 0, 0, 150, 150)
            Case "Cyan"
                Picture1.FillRectangle(Brushes.Cyan, 0, 0, 150, 150)
            Case "DarkCyan"
                Picture1.FillRectangle(Brushes.DarkCyan, 0, 0, 150, 150)
            Case "DarkGoldenrod"
                Picture1.FillRectangle(Brushes.DarkGoldenrod, 0, 0, 150, 150)
            Case "DarkGray"
                Picture1.FillRectangle(Brushes.DarkGray, 0, 0, 150, 150)
            Case "DarkGreen"
                Picture1.FillRectangle(Brushes.DarkGreen, 0, 0, 150, 150)
            Case "DarkKhaki"
                Picture1.FillRectangle(Brushes.DarkKhaki, 0, 0, 150, 150)
            Case "DarkMagenta"
                Picture1.FillRectangle(Brushes.DarkMagenta, 0, 0, 150, 150)
            Case "DarkOliveGreen"
                Picture1.FillRectangle(Brushes.DarkOliveGreen, 0, 0, 150, 150)
            Case "DarkOrange"
                Picture1.FillRectangle(Brushes.DarkOrange, 0, 0, 150, 150)
            Case "DarkOrchid"
                Picture1.FillRectangle(Brushes.DarkOrchid, 0, 0, 150, 150)
            Case "DarkRed"
                Picture1.FillRectangle(Brushes.DarkRed, 0, 0, 150, 150)
            Case "DarkSalmon"
                Picture1.FillRectangle(Brushes.DarkSalmon, 0, 0, 150, 150)
            Case "DarkSeaGreen"
                Picture1.FillRectangle(Brushes.DarkSeaGreen, 0, 0, 150, 150)
            Case "DarkSlateBlue"
                Picture1.FillRectangle(Brushes.DarkSlateBlue, 0, 0, 150, 150)
            Case "DarkSlateGray"
                Picture1.FillRectangle(Brushes.DarkSlateGray, 0, 0, 150, 150)
            Case "DarkTurquoise"
                Picture1.FillRectangle(Brushes.DarkTurquoise, 0, 0, 150, 150)
            Case "DarkViolet"
                Picture1.FillRectangle(Brushes.DarkViolet, 0, 0, 150, 150)
            Case "DeepPink"
                Picture1.FillRectangle(Brushes.DeepPink, 0, 0, 150, 150)
            Case "DeepSkyBlue"
                Picture1.FillRectangle(Brushes.DeepSkyBlue, 0, 0, 150, 150)
            Case "DimGray"
                Picture1.FillRectangle(Brushes.DimGray, 0, 0, 150, 150)
            Case "DodgerBlue"
                Picture1.FillRectangle(Brushes.DodgerBlue, 0, 0, 150, 150)
            Case "Firebrick"
                Picture1.FillRectangle(Brushes.Firebrick, 0, 0, 150, 150)
            Case "FloralWhite"
                Picture1.FillRectangle(Brushes.FloralWhite, 0, 0, 150, 150)
            Case "ForestGreen"
                Picture1.FillRectangle(Brushes.ForestGreen, 0, 0, 150, 150)
            Case "Fuchsia"
                Picture1.FillRectangle(Brushes.Fuchsia, 0, 0, 150, 150)
            Case "Gainsboro"
                Picture1.FillRectangle(Brushes.Gainsboro, 0, 0, 150, 150)
            Case "GhostWhite"
                Picture1.FillRectangle(Brushes.GhostWhite, 0, 0, 150, 150)
            Case "Gold"
                Picture1.FillRectangle(Brushes.Gold, 0, 0, 150, 150)
            Case "Goldenrod"
                Picture1.FillRectangle(Brushes.Goldenrod, 0, 0, 150, 150)
            Case "Gray"
                Picture1.FillRectangle(Brushes.Gray, 0, 0, 150, 150)
            Case "Green"
                Picture1.FillRectangle(Brushes.Green, 0, 0, 150, 150)
            Case "GreenYellow"
                Picture1.FillRectangle(Brushes.GreenYellow, 0, 0, 150, 150)
            Case "Honeydew"
                Picture1.FillRectangle(Brushes.Honeydew, 0, 0, 150, 150)
            Case "HotPink"
                Picture1.FillRectangle(Brushes.HotPink, 0, 0, 150, 150)
            Case "IndianRed"
                Picture1.FillRectangle(Brushes.IndianRed, 0, 0, 150, 150)
            Case "Indigo"
                Picture1.FillRectangle(Brushes.Indigo, 0, 0, 150, 150)
            Case "Ivory"
                Picture1.FillRectangle(Brushes.Ivory, 0, 0, 150, 150)
            Case "Khaki"
                Picture1.FillRectangle(Brushes.Khaki, 0, 0, 150, 150)
            Case "Lavender"
                Picture1.FillRectangle(Brushes.Lavender, 0, 0, 150, 150)
            Case "LavenderBlush"
                Picture1.FillRectangle(Brushes.LavenderBlush, 0, 0, 150, 150)
            Case "LawnGreen"
                Picture1.FillRectangle(Brushes.LawnGreen, 0, 0, 150, 150)
            Case "LemonChiffon"
                Picture1.FillRectangle(Brushes.LemonChiffon, 0, 0, 150, 150)
            Case "LightBlue"
                Picture1.FillRectangle(Brushes.LightBlue, 0, 0, 150, 150)
            Case "LightCoral"
                Picture1.FillRectangle(Brushes.LightCoral, 0, 0, 150, 150)
            Case "LightCyan"
                Picture1.FillRectangle(Brushes.LightCyan, 0, 0, 150, 150)
            Case "LightGoldenrodYellow"
                Picture1.FillRectangle(Brushes.LightGoldenrodYellow, 0, 0, 150, 150)
            Case "LightGray"
                Picture1.FillRectangle(Brushes.LightGray, 0, 0, 150, 150)
            Case "LightGreen"
                Picture1.FillRectangle(Brushes.LightGreen, 0, 0, 150, 150)
            Case "LightPink"
                Picture1.FillRectangle(Brushes.LightPink, 0, 0, 150, 150)
            Case "LightSalmon"
                Picture1.FillRectangle(Brushes.LightSalmon, 0, 0, 150, 150)
            Case "LightSeaGreen"
                Picture1.FillRectangle(Brushes.LightSeaGreen, 0, 0, 150, 150)
            Case "LightSkyBlue"
                Picture1.FillRectangle(Brushes.LightSkyBlue, 0, 0, 150, 150)
            Case "LightSlateGray"
                Picture1.FillRectangle(Brushes.LightSlateGray, 0, 0, 150, 150)
            Case "LightSteelBlue"
                Picture1.FillRectangle(Brushes.LightSteelBlue, 0, 0, 150, 150)
            Case "LightYellow"
                Picture1.FillRectangle(Brushes.LightYellow, 0, 0, 150, 150)
            Case "Lime"
                Picture1.FillRectangle(Brushes.Lime, 0, 0, 150, 150)
            Case "LimeGreen"
                Picture1.FillRectangle(Brushes.LimeGreen, 0, 0, 150, 150)
            Case "Linen"
                Picture1.FillRectangle(Brushes.Linen, 0, 0, 150, 150)
            Case "Magenta"
                Picture1.FillRectangle(Brushes.Magenta, 0, 0, 150, 150)
            Case "Maroon"
                Picture1.FillRectangle(Brushes.Maroon, 0, 0, 150, 150)
            Case "MediumAquamarine"
                Picture1.FillRectangle(Brushes.MediumAquamarine, 0, 0, 150, 150)
            Case "MediumBlue"
                Picture1.FillRectangle(Brushes.MediumBlue, 0, 0, 150, 150)
            Case "MediumOrchid"
                Picture1.FillRectangle(Brushes.MediumOrchid, 0, 0, 150, 150)
            Case "MediumPurple"
                Picture1.FillRectangle(Brushes.MediumPurple, 0, 0, 150, 150)
            Case "MediumPurple"
                Picture1.FillRectangle(Brushes.MediumPurple, 0, 0, 150, 150)
            Case "MediumSeaGreen"
                Picture1.FillRectangle(Brushes.MediumSeaGreen, 0, 0, 150, 150)
            Case "MediumSlateBlue"
                Picture1.FillRectangle(Brushes.MediumSlateBlue, 0, 0, 150, 150)
            Case "MediumSpringGreen"
                Picture1.FillRectangle(Brushes.MediumSpringGreen, 0, 0, 150, 150)
            Case "MediumTurquoise"
                Picture1.FillRectangle(Brushes.MediumTurquoise, 0, 0, 150, 150)
            Case "MediumVioletRed"
                Picture1.FillRectangle(Brushes.MediumVioletRed, 0, 0, 150, 150)
            Case "MidnightBlue"
                Picture1.FillRectangle(Brushes.MidnightBlue, 0, 0, 150, 150)
            Case "MintCream"
                Picture1.FillRectangle(Brushes.MintCream, 0, 0, 150, 150)
            Case "MistyRose"
                Picture1.FillRectangle(Brushes.MistyRose, 0, 0, 150, 150)
            Case "Moccasin"
                Picture1.FillRectangle(Brushes.Moccasin, 0, 0, 150, 150)
            Case "NavajoWhite"
                Picture1.FillRectangle(Brushes.NavajoWhite, 0, 0, 150, 150)
            Case "Navy"
                Picture1.FillRectangle(Brushes.Navy, 0, 0, 150, 150)
            Case "OldLace"
                Picture1.FillRectangle(Brushes.OldLace, 0, 0, 150, 150)
            Case "Olive"
                Picture1.FillRectangle(Brushes.Olive, 0, 0, 150, 150)
            Case "OliveDrab"
                Picture1.FillRectangle(Brushes.OliveDrab, 0, 0, 150, 150)
            Case "Orange"
                Picture1.FillRectangle(Brushes.Orange, 0, 0, 150, 150)
            Case "OrangeRed"
                Picture1.FillRectangle(Brushes.OrangeRed, 0, 0, 150, 150)
            Case "Orchid"
                Picture1.FillRectangle(Brushes.Orchid, 0, 0, 150, 150)
            Case "PaleGoldenrod"
                Picture1.FillRectangle(Brushes.PaleGoldenrod, 0, 0, 150, 150)
            Case "PaleGreen"
                Picture1.FillRectangle(Brushes.PaleGreen, 0, 0, 150, 150)
            Case "PaleTurquoise"
                Picture1.FillRectangle(Brushes.PaleTurquoise, 0, 0, 150, 150)
            Case "PaleVioletRed"
                Picture1.FillRectangle(Brushes.PaleVioletRed, 0, 0, 150, 150)
            Case "PapayaWhip"
                Picture1.FillRectangle(Brushes.PapayaWhip, 0, 0, 150, 150)
            Case "PeachPuff"
                Picture1.FillRectangle(Brushes.PeachPuff, 0, 0, 150, 150)
            Case "Peru"
                Picture1.FillRectangle(Brushes.Peru, 0, 0, 150, 150)
            Case "Pink"
                Picture1.FillRectangle(Brushes.Pink, 0, 0, 150, 150)
            Case "Plum"
                Picture1.FillRectangle(Brushes.Plum, 0, 0, 150, 150)
            Case "PowderBlue"
                Picture1.FillRectangle(Brushes.PowderBlue, 0, 0, 150, 150)
            Case "Purple"
                Picture1.FillRectangle(Brushes.Purple, 0, 0, 150, 150)
            Case "Red"
                Picture1.FillRectangle(Brushes.Red, 0, 0, 150, 150)
            Case "RosyBrown"
                Picture1.FillRectangle(Brushes.RosyBrown, 0, 0, 150, 150)
            Case "RoyalBlue"
                Picture1.FillRectangle(Brushes.RoyalBlue, 0, 0, 150, 150)
            Case "SaddleBrown"
                Picture1.FillRectangle(Brushes.SaddleBrown, 0, 0, 150, 150)
            Case "Salmon"
                Picture1.FillRectangle(Brushes.Salmon, 0, 0, 150, 150)
            Case "SandyBrown"
                Picture1.FillRectangle(Brushes.SandyBrown, 0, 0, 150, 150)
            Case "SeaGreen"
                Picture1.FillRectangle(Brushes.SeaGreen, 0, 0, 150, 150)
            Case "SeaShell"
                Picture1.FillRectangle(Brushes.SeaShell, 0, 0, 150, 150)
            Case "Sienna"
                Picture1.FillRectangle(Brushes.Sienna, 0, 0, 150, 150)
            Case "Silver"
                Picture1.FillRectangle(Brushes.Silver, 0, 0, 150, 150)
            Case "SkyBlue"
                Picture1.FillRectangle(Brushes.SkyBlue, 0, 0, 150, 150)
            Case "SlateBlue"
                Picture1.FillRectangle(Brushes.SlateBlue, 0, 0, 150, 150)
            Case "SlateGray"
                Picture1.FillRectangle(Brushes.SlateGray, 0, 0, 150, 150)
            Case "Snow"
                Picture1.FillRectangle(Brushes.Snow, 0, 0, 150, 150)
            Case "SpringGreen"
                Picture1.FillRectangle(Brushes.SpringGreen, 0, 0, 150, 150)
            Case "SteelBlue"
                Picture1.FillRectangle(Brushes.SteelBlue, 0, 0, 150, 150)
            Case "Tan"
                Picture1.FillRectangle(Brushes.Tan, 0, 0, 150, 150)
            Case "Teal"
                Picture1.FillRectangle(Brushes.Teal, 0, 0, 150, 150)
            Case "Thistle"
                Picture1.FillRectangle(Brushes.Thistle, 0, 0, 150, 150)
            Case "Tomato"
                Picture1.FillRectangle(Brushes.Tomato, 0, 0, 150, 150)
            Case "Transparent"
                Picture1.FillRectangle(Brushes.Transparent, 0, 0, 150, 150)
            Case "Turquoise"
                Picture1.FillRectangle(Brushes.Turquoise, 0, 0, 150, 150)
            Case "Violet"
                Picture1.FillRectangle(Brushes.Violet, 0, 0, 150, 150)
            Case "Wheat"
                Picture1.FillRectangle(Brushes.Wheat, 0, 0, 150, 150)
            Case "White"
                Picture1.FillRectangle(Brushes.White, 0, 0, 150, 150)
            Case "WhiteSmoke"
                Picture1.FillRectangle(Brushes.WhiteSmoke, 0, 0, 150, 150)
            Case "Yellow"
                Picture1.FillRectangle(Brushes.Yellow, 0, 0, 150, 150)
            Case "YellowGreen"
                Picture1.FillRectangle(Brushes.YellowGreen, 0, 0, 150, 150)

            Case Else
                Picture1.FillRectangle(Brushes.Transparent, 0, 0, 150, 150)
        End Select

        Picture1.DrawRectangle(lapiz, 0, 0, 150, 150)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        My.Settings.TrazoAnch = 1
        My.Settings.TrazoColor = Color.Black
        My.Settings.TrazoForm = "normal"
        My.Settings.TrazoInter = "Transparent"
        NumericUpDown1.Value = 1
        ColorDialog1.Color = Color.Black
        ComboBox3.SelectedIndex = 0
        ComboBox1.SelectedIndex = 0

    End Sub
End Class