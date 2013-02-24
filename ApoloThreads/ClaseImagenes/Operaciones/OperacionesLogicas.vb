Imports ClaseImagenes.Apolo

Public Class OperacionesLogicas
    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal

    Sub modificarControles(ByVal minimoHS As Integer, ByVal maximoHS As Integer, ByVal valorLabel As Integer)
        For Each c As Control In Me.Controls
            If TypeOf c Is HScrollBar Then
                Dim hs As New HScrollBar
                hs = c
                hs.Minimum = minimoHS
                hs.Maximum = maximoHS
                hs.Value = valorLabel
            End If
        Next
        Label1.Text = valorLabel
        Label3.Text = valorLabel
        Label4.Text = valorLabel
        Label5.Text = valorLabel
    End Sub
    Private Sub Vincular(ByVal valor As Double)
        Label1.Text = valor
        HScrollBar1.Value = valor
        Label3.Text = valor
        HScrollBar2.Value = valor
        Label4.Text = valor
        HScrollBar3.Value = valor
        Label5.Text = valor
        HScrollBar4.Value = valor
    End Sub

#Region "Modicar controles"
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            modificarControles(0, 264, 0)
        End If
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            modificarControles(0, 264, 0)
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            modificarControles(0, 264, 255)
        End If
    End Sub
    Private Sub HScrollBar4_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar4.Scroll
        Label5.Text = HScrollBar4.Value
        If CheckBox2.Checked = True Then
            Vincular(HScrollBar4.Value)
        End If
    End Sub
    Private Sub HScrollBar3_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar3.Scroll
        Label4.Text = HScrollBar3.Value
        If CheckBox2.Checked = True Then
            Vincular(HScrollBar3.Value)
        End If
    End Sub
    Private Sub HScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar2.Scroll
        Label3.Text = HScrollBar2.Value
        If CheckBox2.Checked = True Then
            Vincular(HScrollBar2.Value)
        End If
    End Sub
    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Label1.Text = HScrollBar1.Value
        If CheckBox2.Checked = True Then
            Vincular(HScrollBar1.Value)
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click 'Restablecer
        If RadioButton2.Checked = True Then
            modificarControles(0, 264, 255)
        End If

        If RadioButton3.Checked = True Then
            modificarControles(0, 264, 0)
        End If

        If RadioButton4.Checked = True Then
            modificarControles(0, 264, 0)
        End If
    End Sub
#End Region

    Private Sub OperacionesLogicas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Size = New Size(565, 282)
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim alfa As Boolean = True
        If CheckBox1.Checked = True Then 'Comprobamos si queremos omitir el canal alfa
            alfa = True
        Else
            alfa = False
        End If

        If RadioButton2.Checked = True Then
            Principal.PictureBox1.Image = objetoTratamiento.OperAND(bmpP, HScrollBar1.Value, HScrollBar2.Value, HScrollBar3.Value, HScrollBar4.Value, alfa)
        End If

        If RadioButton3.Checked = True Then
            Principal.PictureBox1.Image = objetoTratamiento.OperOR(bmpP, HScrollBar1.Value, HScrollBar2.Value, HScrollBar3.Value, HScrollBar4.Value, alfa)
        End If

        If RadioButton4.Checked = True Then
            Principal.PictureBox1.Image = objetoTratamiento.OperXOR(bmpP, HScrollBar1.Value, HScrollBar2.Value, HScrollBar3.Value, HScrollBar4.Value, alfa)
        End If

    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class