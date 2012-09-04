Imports System.Windows.Forms
Imports WindowsApplication1.Principal

Public Class configu
    Dim Panelcolor As Color


    Private Sub configu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panelcolor = My.Settings.ColorPanel
        dlgcolor.Color = My.Settings.ColorPanel
        If My.Settings.vistapr = True Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If

        If My.Settings.pantallainicial = True Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If
        If My.Settings.animacion = True Then
            CheckBox3.Checked = True
        Else
            CheckBox3.Checked = False
        End If

        If My.Settings.actualizacion = True Then
            CheckBox4.Checked = True
        Else
            CheckBox4.Checked = False
        End If

        If My.Settings.salir = True Then
            CheckBox5.Checked = True
        Else
            CheckBox5.Checked = False
        End If

        If My.Settings.Original = True Then
            CheckBox6.Checked = True
        Else
            CheckBox6.Checked = False
        End If

        If My.Settings.MensajeClon = True Then
            CheckBox7.Checked = True
        Else
            CheckBox7.Checked = False
        End If

        If My.Settings.MensajeFiltro = True Then
            CheckBox8.Checked = True
        Else
            CheckBox8.Checked = False
        End If

        If My.Settings.MensajeClonParcial = True Then
            CheckBox9.Checked = True
        Else
            CheckBox9.Checked = False
        End If

        If My.Settings.MensajesFiltroParc = True Then
            CheckBox10.Checked = True
        Else
            CheckBox10.Checked = False
        End If

        If My.Settings.BarraLateral = True Then
            CheckBox11.Checked = True
        Else
            CheckBox11.Checked = False
        End If

        If My.Settings.MensajeRecortar = True Then
            CheckBox12.Checked = True
        Else
            CheckBox12.Checked = False
        End If

        If My.Settings.Pantallapresentación = True Then
            CheckBox13.Checked = True
        Else
            CheckBox13.Checked = False
        End If

        If My.Settings.MensajeSegmentacion = True Then
            CheckBox14.Checked = True
        Else
            CheckBox14.Checked = False
        End If

        If My.Settings.MensajeBorrar = True Then
            CheckBox15.Checked = True
        Else
            CheckBox15.Checked = False
        End If


        seleccionarBorde(My.Settings.TipoBorde)

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim respuesta As DialogResult = MessageBox.Show("¿Está seguro de reestablecer la configuración inicial? Recuerde que también se perderá el formato de los trazos.", "Apolo v 0.9", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
        Select Case respuesta
            Case Windows.Forms.DialogResult.Yes
                My.Settings.vistapr = True
                My.Settings.actualizacion = True
                My.Settings.animacion = True
                My.Settings.pantallainicial = True
                My.Settings.salir = True
                My.Settings.Original = True
                My.Settings.TrazoAnch = 1
                My.Settings.TrazoColor = Color.Black
                My.Settings.TrazoForm = "normal"
                My.Settings.TrazoInter = "Transparent"
                My.Settings.MensajeClon = True
                My.Settings.AltoClon = 8
                My.Settings.AnchoClon = 8
                My.Settings.MensajeFiltro = True
                My.Settings.AltoFIltro = 3
                My.Settings.AnchoFIltro = 3
                My.Settings.RojoFi = 50
                My.Settings.VErdeFi = 50
                My.Settings.AzulFi = 50
                My.Settings.Porcentaje = 50
                My.Settings.AnchoclonPar = 8
                My.Settings.AltoclonPar = 8
                My.Settings.MensajeClonParcial = True
                My.Settings.MensajesFiltroParc = True
                My.Settings.AltoFpar = 5
                My.Settings.AnchoFpar = 5
                My.Settings.ColorPanel = Color.Silver
                My.Settings.BarraLateral = True
                My.Settings.TipoBorde = "single"
                My.Settings.MensajeRecortar = True
                My.Settings.Pantallapresentación = True
                My.Settings.MensajeSegmentacion = True
                My.Settings.AlfaSe = 0
                My.Settings.RojoSe = 0
                My.Settings.VerdeSe = 0
                My.Settings.AzulSe = 0
                My.Settings.AlfaBorrar = 0
                My.Settings.RojoBorrar = 0
                My.Settings.VerdeBorrar = 0
                My.Settings.AzulBorrar = 0
                My.Settings.AnchoBorrar = 10
                My.Settings.AltoBorrar = 10
                My.Settings.MensajeBorrar = True
                My.Settings.Save()
                Me.Close()

            Case Windows.Forms.DialogResult.No
                Exit Sub
            Case Windows.Forms.DialogResult.Cancel
                Exit Sub
        End Select

    End Sub

 

    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If CheckBox1.Checked = True Then
            My.Settings.vistapr = True
        Else
            My.Settings.vistapr = False
        End If

        If CheckBox2.Checked = True Then
            My.Settings.pantallainicial = True
        Else
            My.Settings.pantallainicial = False
        End If

        If CheckBox3.Checked = True Then
            My.Settings.animacion = True
        Else
            My.Settings.animacion = False
        End If

        If CheckBox4.Checked = True Then
            My.Settings.actualizacion = True
        Else
            My.Settings.actualizacion = False
        End If

        If CheckBox5.Checked = True Then
            My.Settings.salir = True
        Else
            My.Settings.salir = False
        End If

        If CheckBox6.Checked = True Then
            My.Settings.Original = True
        Else
            My.Settings.Original = False
        End If

        If CheckBox7.Checked = True Then
            My.Settings.MensajeClon = True
        Else
            My.Settings.MensajeClon = False
        End If

        If CheckBox8.Checked = True Then
            My.Settings.MensajeFiltro = True
        Else
            My.Settings.MensajeFiltro = False
        End If

        If CheckBox9.Checked = True Then
            My.Settings.MensajeClonParcial = True
        Else
            My.Settings.MensajeClonParcial = False
        End If

        If CheckBox10.Checked = True Then
            My.Settings.MensajesFiltroParc = True
        Else
            My.Settings.MensajesFiltroParc = False
        End If
        If CheckBox11.Checked = True Then
            My.Settings.BarraLateral = True
        Else
            My.Settings.BarraLateral = False
        End If
        My.Settings.TipoBorde = seleccionarBordeF(ComboBox1.SelectedItem)
        If CheckBox12.Checked = True Then
            My.Settings.MensajeRecortar = True
        Else
            My.Settings.MensajeRecortar = False
        End If
        If CheckBox13.Checked = True Then
            My.Settings.Pantallapresentación = True
        Else
            My.Settings.Pantallapresentación = False
        End If
        If CheckBox14.Checked = True Then
            My.Settings.MensajeSegmentacion = True
        Else
            My.Settings.MensajeSegmentacion = False
        End If
        If CheckBox15.Checked = True Then
            My.Settings.MensajeBorrar = True
        Else
            My.Settings.MensajeBorrar = False
        End If
        My.Settings.ColorPanel = Panelcolor
        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Sub seleccionarBorde(ByVal borde As String)
        Select Case borde
            Case "none"
                ComboBox1.SelectedIndex = 0
            Case "single"
                ComboBox1.SelectedIndex = 1
            Case "3d"
                ComboBox1.SelectedIndex = 2
            Case Else
                ComboBox1.SelectedIndex = 0
        End Select
    End Sub
    Function seleccionarBordeF(ByVal borde As String)
        Select Case ComboBox1.SelectedIndex
            Case 0
                borde = "none"
            Case 1
                borde = "single"
            Case 2
                borde = "3d"
            Case Else
                borde = "none"
        End Select
        Return borde
    End Function

    
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dlgcolor.ShowDialog = Windows.Forms.DialogResult.OK Then
            Panelcolor = dlgcolor.Color
        End If

    End Sub

    
     
End Class
