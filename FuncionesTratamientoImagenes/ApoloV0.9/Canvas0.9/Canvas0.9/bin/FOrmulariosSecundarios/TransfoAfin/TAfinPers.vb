Imports WindowsApplication1.Class1
Imports WindowsApplication1.Class2
Imports System.Drawing.Imaging

Public Class TAfinPers
    Public Matriz(,) As System.Drawing.Color
    Dim objeto As New tratamiento
    Dim objetoform As New trataformu
    Dim clic As Integer = 1



    Public Function Transpuesta(ByVal Matriz1(,) As Double) As Double(,)
        'Creamos la matriz transpuesta
        Dim MatrizTranspuesta(Matriz1.GetUpperBound(1), Matriz1.GetUpperBound(0)) As Double
        'Declaración de variables auxiliares
        Dim i, j As Short
        'Doble bucle para efectuar la transposición
        For i = 0 To Matriz1.GetUpperBound(0)
            For j = 0 To Matriz1.GetUpperBound(1)
                MatrizTranspuesta(j, i) = Matriz1(i, j)
            Next
        Next
        'Es necesario esta sentencia para que la función devuelva la matriz calculada
        Return MatrizTranspuesta
    End Function
    Public Function Suma(ByVal Matriz1(,) As Double, ByVal Matriz2(,) As Double) As Double(,)
        'Comprobación de que las dos matrices son del mismo orden, 
        If Not Matriz1.GetUpperBound(0) = Matriz2.GetUpperBound(0) AndAlso _
                    Matriz1.GetUpperBound(1) = Matriz2.GetUpperBound(1) Then Exit Function
        'Creamos la matriz suma
        Dim MatrizSuma(Matriz1.GetUpperBound(0), Matriz1.GetUpperBound(1)) As Double
        'Declaración de variables auxiliares
        Dim i, j As Short
        'Doble bucle para efectuar la suma
        For i = 0 To Matriz1.GetUpperBound(0)
            For j = 0 To Matriz1.GetUpperBound(1)
                MatrizSuma(i, j) = Matriz1(i, j) + Matriz2(i, j)
            Next
        Next
        'Es necesario esta sentencia para que la función devuelva la matriz calculada
        Return MatrizSuma
    End Function
    Public Function Producto(ByVal Matriz1(,) As Double, ByVal Matriz2(,) As Double) As Double(,)
        'Comprobación de que las dos matrices son multiplicables
        If Not Matriz1.GetUpperBound(1) = Matriz2.GetUpperBound(0) Then Exit Function
        'Creamos la matriz producto
        Dim MatrizProducto(Matriz1.GetUpperBound(0), Matriz2.GetUpperBound(1)) As Double
        'Declaración de variables auxiliares
        Dim i, j, k As Short
        'Triple bucle para efectuar el producto
        For i = 0 To MatrizProducto.GetUpperBound(0)
            For j = 0 To MatrizProducto.GetUpperBound(1)
                For k = 0 To Matriz1.GetUpperBound(1)
                    MatrizProducto(i, j) = MatrizProducto(i, j) + _
                                            Matriz1(i, k) * Matriz2(k, j)
                Next
            Next
        Next
        'Es necesario esta sentencia para que la función devuelva la matriz calculada
        Return MatrizProducto
    End Function
    Public Function Inversa(ByVal Matriz3(,) As Double) As Double(,)
        'Método de inversión: matriz de paso
        'Comprobación de que la matriz es cuadrada
        If Not Matriz3.GetUpperBound(0) = Matriz3.GetUpperBound(1) Then Exit Function
        'Creamos dos matrices auxiliares
        Dim Matriz1(Matriz3.GetUpperBound(0), Matriz3.GetUpperBound(1)) As Double
        Dim Matriz2(Matriz3.GetUpperBound(0), Matriz3.GetUpperBound(1)) As Double
        'Creamos la matriz inversa
        Dim MatrizInversa(Matriz1.GetUpperBound(0), Matriz1.GetUpperBound(1)) As Double
        'Declaración de variables auxiliares
        Dim i, j, k As Short
        Dim factor As Double
        'Copia de la matriz original
        For i = 0 To Matriz1.GetUpperBound(0)
            For j = 0 To Matriz1.GetUpperBound(0)
                Matriz1(i, j) = Matriz3(i, j)
            Next
        Next
        'Matriz de Paso inicial = Matriz Identidad (todo ceros excepto la diagonal formada por "unos")
        For i = 0 To MatrizInversa.GetUpperBound(0)
            Matriz2(i, i) = 1
        Next
        'Se diagonaliza la matriz original y se aplican las mismas operaciones a la matriz de paso
        For j = 0 To Matriz1.GetUpperBound(0)
            For i = 0 To Matriz1.GetUpperBound(0)
                If i <> j Then
                    If Matriz1(i, j) = 0 Then GoTo CUIDADO
                    factor = Matriz1(j, j) / Matriz1(i, j)
                    For k = 0 To Matriz2.GetUpperBound(0)
                        Matriz1(i, k) = Matriz1(j, k) - factor * Matriz1(i, k)
                        Matriz2(i, k) = Matriz2(j, k) - factor * Matriz2(i, k)
                    Next
CUIDADO:
                End If
            Next
        Next
        'Se divide cada elemento de la diagonal por si mismo y se consigue:
        '       * En la matriz original la Matriz Identidad
        '       * A la derecha la matriz de Paso = Inversa de la Matriz normal
        For i = 0 To Matriz1.GetUpperBound(0)
            factor = Matriz1(i, i)
            'En la matriz original sólo se divide la diagonal porque el resto es cero (ya esdiagonal)
            'Si quieres ver cómo se modifica la matriz original activa la siguiente línea
            Matriz1(i, i) = Matriz1(i, i) / factor
            For j = 0 To Matriz1.GetUpperBound(0)
                MatrizInversa(i, j) = Matriz2(i, j) / factor
            Next
        Next
        'Es necesario esta sentencia para que la función devuelva la matriz calculada
        Return MatrizInversa
    End Function


    Public Structure Punto
        Dim X As Double
        Dim Y As Double
    End Structure

    Private Sub TAfinPers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
        PictureBox1.Image = bmpAfin
        PictureBox2.Image = bmpAfin
        PictureBox1.Visible = True
        PictureBox2.Visible = False
        SplitContainer1.SplitterDistance = Me.Size.Width - 300
        Panel1.Location = New Point(56, 30)
        Panel2.Location = New Point(15, (Me.Size.Height - Panel2.Size.Height) - 100)
        objetoform.refrescar(PictureBox1, SplitContainer1.Panel1) 'Refrescamos Picture y Panel
        CheckBox1.Checked = True
        TextBox11.Text = ""
        TextBox12.Text = ""
        TextBox13.Text = ""
        TextBox14.Text = ""
        TextBox15.Text = ""
        TextBox16.Text = ""
        TextBox17.Text = ""
        TextBox18.Text = ""
        TextBox26.Text = ""
        TextBox25.Text = ""
        TextBox23.Text = ""
        TextBox24.Text = ""
        TextBox21.Text = ""
        TextBox22.Text = ""
        TextBox20.Text = ""
        TextBox19.Text = ""
    End Sub


    Private Sub PictureBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove
        Dim mouseDownLocation As New Point(e.X, e.Y)
        ToolStripStatusLabel3.Text = "Coordenadas " & mouseDownLocation.X & "," & mouseDownLocation.Y
        ToolStripStatusLabel4.Text = "Coordenadas " & mouseDownLocation.X & "," & mouseDownLocation.Y
     
    End Sub

    Private Sub PictureBox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove
        Dim mouseDownLocation As New Point(e.X, e.Y)
        ToolStripStatusLabel3.Text = "Coordenadas " & mouseDownLocation.X & "," & mouseDownLocation.Y
        ToolStripStatusLabel4.Text = "Coordenadas " & mouseDownLocation.X & "," & mouseDownLocation.Y
    End Sub



    Private Sub AbrirImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirImagenToolStripMenuItem.Click
        PictureBox1.Image = objeto.abirImagen() 'Abrimos imagen y al PictureBox
        objetoform.refrescar(PictureBox1, SplitContainer1.Panel1) 'Refrescamos Picture y Panel
        Me.Text = objeto.nombreImagen 'nombre al formulario
        PictureBox1.Visible = True
        PictureBox2.Visible = False
    End Sub

    Private Sub GuardarImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarImagenToolStripMenuItem.Click
        objeto.guardarcomo(PictureBox2.Image) 'Guardamos imagen
    End Sub

    Private Sub SalirAlProgramaPrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirAlProgramaPrincipalToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub EnviarImagenAlProgramaPrincipalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarImagenAlProgramaPrincipalToolStripMenuItem.Click
        afinImagenper = True
        bmpAfinRetornoPer = PictureBox2.Image
        Dim pregunta = MessageBox.Show("La imagen ha sido enviada. ¿Desea cerrar el módulo de transformación afín?", "Apolo v0.9", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
        If pregunta = Windows.Forms.DialogResult.OK Then
            Me.Close()
        End If
    End Sub

    Private Sub AbrirImagenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AbrirImagenToolStripMenuItem1.Click
        AbrirImagenToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub GuardarImagenToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuardarImagenToolStripMenuItem1.Click
        GuardarImagenToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub EnviarImagenAlProgramaPrincipalToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EnviarImagenAlProgramaPrincipalToolStripMenuItem1.Click
        EnviarImagenAlProgramaPrincipalToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub SalirAlProgramaPrincipalToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirAlProgramaPrincipalToolStripMenuItem1.Click
        SalirAlProgramaPrincipalToolStripMenuItem_Click(sender, e)
    End Sub



    Private Sub PictureBox1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseClick
        Dim localizacion As Point = e.Location
        If RadioButton1.Checked = True Then
            Select Case clic
                Case 1
                    TextBox11.Text = localizacion.X
                    TextBox12.Text = localizacion.Y
                Case 2
                    TextBox13.Text = localizacion.X
                    TextBox14.Text = localizacion.Y
                Case 3
                    TextBox15.Text = localizacion.X
                    TextBox16.Text = localizacion.Y
                Case 4
                    TextBox17.Text = localizacion.X
                    TextBox18.Text = localizacion.Y
            End Select
        Else
            Select Case clic
                Case 1
                    TextBox26.Text = localizacion.X
                    TextBox25.Text = localizacion.Y
                Case 2
                    TextBox23.Text = localizacion.X
                    TextBox24.Text = localizacion.Y
                Case 3
                    TextBox21.Text = localizacion.X
                    TextBox22.Text = localizacion.Y
                Case 4
                    TextBox20.Text = localizacion.X
                    TextBox19.Text = localizacion.Y
            End Select
        End If
        clic = clic + 1
        If clic > 4 Then
            clic = 1
        End If


    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        clic = 1
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        clic = 1
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PictureBox2.Visible = True
        PictureBox1.Visible = False
        Dim i, j As Long
        ReDim Matriz(PictureBox1.Image.Width - 1, PictureBox1.Image.Height - 1)
        Dim bmpAux As New Bitmap(PictureBox1.Image)
        For i = 0 To PictureBox1.Image.Width - 1
            For j = 0 To PictureBox1.Image.Height - 1
                Matriz(i, j) = bmpAux.GetPixel(i, j)
            Next
        Next

        Dim Origen(3), Destino(3) As Punto
        Dim tamaño As Integer
        Origen(0).X = Val(TextBox11.Text)
        Origen(0).Y = Val(TextBox12.Text)
        Origen(1).X = Val(TextBox13.Text)
        Origen(1).Y = Val(TextBox14.Text)
        Origen(2).X = Val(TextBox15.Text)
        Origen(2).Y = Val(TextBox16.Text)
        Origen(3).X = Val(TextBox17.Text)
        Origen(3).Y = Val(TextBox18.Text)

        If ComboBox1.Text = "" Then
            tamaño = 2
        Else
            tamaño = ComboBox1.Text
        End If




        Destino(0).X = Val(TextBox26.Text)
        Destino(0).Y = Val(TextBox25.Text)
        Destino(1).X = Val(TextBox23.Text)
        Destino(1).Y = Val(TextBox24.Text)
        Destino(2).X = Val(TextBox21.Text)
        Destino(2).Y = Val(TextBox22.Text)
        Destino(3).X = Val(TextBox20.Text)
        Destino(3).Y = Val(TextBox19.Text)

        'Declaración de matrices
        Dim A(3 * 2 + 1, 3 * 2 + 1) As Double
        Dim L(3 * 2 + 1, 0) As Double
        'Declaración de variables auxiliares

        'Matriz de diseño
        For i = 0 To 3
            'Primera fila
            A(2 * i, 0) = (Origen(i).X)
            A(2 * i, 1) = (Origen(i).Y)
            A(2 * i, 2) = 1
            A(2 * i, 3) = 0
            A(2 * i, 4) = 0
            A(2 * i, 5) = 0
            A(2 * i, 6) = -(Origen(i).X) * (Destino(i).X)
            A(2 * i, 7) = -(Origen(i).Y) * (Destino(i).X)
            'Segunda fila
            A(2 * i + 1, 0) = 0
            A(2 * i + 1, 1) = 0
            A(2 * i + 1, 2) = 0
            A(2 * i + 1, 3) = (Origen(i).X)
            A(2 * i + 1, 4) = (Origen(i).Y)
            A(2 * i + 1, 5) = 1
            A(2 * i + 1, 6) = -(Origen(i).X) * (Destino(i).Y)
            A(2 * i + 1, 7) = -(Origen(i).Y) * (Destino(i).Y)
        Next
        'Matriz de términos independientes
        For i = 0 To Origen.GetUpperBound(0)
            L(2 * i, 0) = Destino(i).X
            L(2 * i + 1, 0) = Destino(i).Y
        Next
        'Cálculo de parámetros
        Dim N As Double(,) = Producto(Transpuesta(A), A)
        Dim N_inv As Double(,) = Inversa(N)
        Dim T As Double(,) = Producto(Transpuesta(A), L)
        Dim X As Double(,) = Producto(N_inv, T)
        Dim Rojo, Verde, Azul As Byte
        Dim bmp As New Bitmap(Matriz.GetUpperBound(0) * tamaño, Matriz.GetUpperBound(1) * tamaño)
        Dim img As Image
        img = CType(bmp, Image)
        PictureBox2.Image = img
        SplitContainer1.Panel1.AutoScrollMinSize = PictureBox2.Image.Size
        PictureBox2.Refresh()
        For i = 0 To Matriz.GetUpperBound(0)
            For j = 0 To Matriz.GetUpperBound(1)
                Rojo = Matriz(i, j).R
                Verde = Matriz(i, j).G
                Azul = Matriz(i, j).B
                Dim X_Dest, Y_Dest As Short
                X_Dest = (X(0, 0) * i + X(1, 0) * j + X(2, 0)) / (X(6, 0) * i + X(7, 0) * j + 1)
                Y_Dest = (X(3, 0) * i + X(4, 0) * j + X(5, 0)) / (X(6, 0) * i + X(7, 0) * j + 1)
                If (X_Dest + 100 < 0 Or Y_Dest + 100 < 0) Or (X_Dest + 100 > Matriz.GetUpperBound(0) * tamaño) Or (Y_Dest > Matriz.GetUpperBound(1) * tamaño) Then
                    If tamaño = 9 Then
                        MessageBox.Show("Transformación fuera del rango de la imagen", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        PictureBox2.Visible = False
                        PictureBox1.Visible = True
                        Exit Sub
                    Else
                        MessageBox.Show("Compruebe el tamaño", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        PictureBox2.Visible = False
                        PictureBox1.Visible = True
                        Exit Sub
                    End If
                Else
                    bmp.SetPixel(X_Dest + 100, Y_Dest + 100, Color.FromArgb(Rojo, Verde, Azul))

                End If
            Next
            'Esto es solo para que se refresque línea a línea
            img = CType(bmp, Image)
            PictureBox2.Image = img
            PictureBox2.Refresh()
        Next
        If CheckBox1.Checked = True Then
            Cargando.Text = "Reconstruyendo imagen..."
            Cargando.Show()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim bmpI As New Bitmap(PictureBox2.Image)
            If interpolar <> 0 Then
                PictureBox2.Image = objeto.interpolarAfin(bmpI, interpolar)
            Else
                PictureBox2.Image = objeto.interpolarAfin(bmpI)
            End If

            PictureBox2.Visible = True
            PictureBox1.Visible = False
            Cargando.Close()
            Cargando.Text = "Cargando"
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
        Me.Refresh()
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PictureBox2.Visible = False
        PictureBox1.Visible = True
        objetoform.refrescar(PictureBox1, SplitContainer1.Panel1) 'Refrescamos Picture y Panel
    End Sub

    
    Private Sub ReconstruirImagenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReconstruirImagenToolStripMenuItem.Click
        If PictureBox2.Visible = True Then
            Cargando.Text = "Reconstruyendo imagen..."
            Cargando.Show()
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            Dim bmpI As New Bitmap(PictureBox2.Image)
            If interpolar <> 0 Then
                PictureBox2.Image = objeto.interpolarAfin(bmpI, interpolar)
            Else
                PictureBox2.Image = objeto.interpolarAfin(bmpI)
            End If

            PictureBox2.Visible = True
            PictureBox1.Visible = False
            Cargando.Close()
            Cargando.Text = "Cargando"
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End If
    End Sub

    Private Sub PropiedadesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropiedadesToolStripMenuItem.Click
        ReconPPp.ShowDialog()
    End Sub

End Class