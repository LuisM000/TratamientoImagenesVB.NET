Imports System.Windows.Forms

Public Class configu

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If CheckBox1.Checked = True Then
            My.Settings.vistapr = True
            My.Settings.vistapr = True
        Else
            My.Settings.vistapr = False
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

        My.Settings.Save()
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub configu_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
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

    End Sub

   
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim respuesta As DialogResult = MessageBox.Show("¿Está seguro de reestablecer la configuración inicial? Recuerde que también se perderá el formato de los trazos.", "Apolo v 0.9", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            Select respuesta
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
                My.Settings.Save()
                Me.Close()

            Case Windows.Forms.DialogResult.No
                Exit Sub
            Case Windows.Forms.DialogResult.Cancel
                Exit Sub
        End Select

    End Sub

   
End Class
