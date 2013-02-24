Imports ClaseImagenes.Apolo

Public Class OperacionesAritmeticas
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
        If RadioButton2.Checked = True Or RadioButton3.Checked = True Then
            Label1.Text = valor
            HScrollBar1.Value = valor
            Label3.Text = valor
            HScrollBar2.Value = valor
            Label4.Text = valor
            HScrollBar3.Value = valor
            Label5.Text = valor
            HScrollBar4.Value = valor
        Else
            Label1.Text = valor
            HScrollBar1.Value = valor * 100
            Label3.Text = valor
            HScrollBar2.Value = valor * 100
            Label4.Text = valor
            HScrollBar3.Value = valor * 100
            Label5.Text = valor
            HScrollBar4.Value = valor * 100
        End If
       
    End Sub

#Region "Modicar controles"
    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            modificarControles(-255, 0, 0)
        End If
    End Sub
    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then
            modificarControles(1, 25509, 100)
            Label1.Text = 1 : Label3.Text = 1 : Label4.Text = 1 : Label5.Text = 1
        End If
    End Sub
    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        If RadioButton5.Checked = True Then
            modificarControles(-25500, 25509, 100)
            Label1.Text = 1 : Label3.Text = 1 : Label4.Text = 1 : Label5.Text = 1
        End If
    End Sub
    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            modificarControles(0, 255, 0)
        End If
    End Sub
    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        If RadioButton2.Checked = True Or RadioButton3.Checked = True Then
            Label1.Text = HScrollBar1.Value
            If CheckBox2.Checked = True Then
                Vincular(HScrollBar1.Value)
            End If
        Else
            Label1.Text = HScrollBar1.Value / 100
            If CheckBox2.Checked = True Then
                Vincular(HScrollBar1.Value / 100)
            End If
        End If
    End Sub

    Private Sub HScrollBar4_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar4.Scroll
        If RadioButton2.Checked = True Or RadioButton3.Checked = True Then
            Label5.Text = HScrollBar4.Value
            If CheckBox2.Checked = True Then
                Vincular(HScrollBar4.Value)
            End If
        Else
            Label5.Text = HScrollBar4.Value / 100
            If CheckBox2.Checked = True Then
                Vincular(HScrollBar4.Value / 100)
            End If
        End If
    End Sub

    Private Sub HScrollBar3_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar3.Scroll
        If RadioButton2.Checked = True Or RadioButton3.Checked = True Then
            Label4.Text = HScrollBar3.Value
            If CheckBox2.Checked = True Then
                Vincular(HScrollBar3.Value)
            End If
        Else
            Label4.Text = HScrollBar3.Value / 100
            If CheckBox2.Checked = True Then
                Vincular(HScrollBar3.Value / 100)
            End If
        End If
    End Sub

    Private Sub HScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar2.Scroll
        If RadioButton2.Checked = True Or RadioButton3.Checked = True Then
            Label3.Text = HScrollBar2.Value
            If CheckBox2.Checked = True Then
                Vincular(HScrollBar2.Value)
            End If
        Else
            Label3.Text = HScrollBar2.Value / 100
            If CheckBox2.Checked = True Then
                Vincular(HScrollBar2.Value / 100)
            End If
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If RadioButton2.Checked = True Then
            modificarControles(0, 255, 0)
        End If

        If RadioButton3.Checked = True Then
            modificarControles(-255, 0, 0)
        End If

        If RadioButton4.Checked = True Then
            modificarControles(1, 25509, 100)
            Label1.Text = 1 : Label3.Text = 1 : Label4.Text = 1 : Label5.Text = 1
        End If

        If RadioButton5.Checked = True Then
            modificarControles(-25500, 25509, 100)
            Label1.Text = 1 : Label3.Text = 1 : Label4.Text = 1 : Label5.Text = 1
        End If
    End Sub
#End Region


    Private Sub OperacionesAritmeticas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Principal.PictureBox1.Image = objetoTratamiento.Suma(bmpP, HScrollBar1.Value, HScrollBar2.Value, HScrollBar3.Value, HScrollBar4.Value, alfa)
        End If

        If RadioButton3.Checked = True Then
            Principal.PictureBox1.Image = objetoTratamiento.Resta(bmpP, -HScrollBar1.Value, -HScrollBar2.Value, -HScrollBar3.Value, -HScrollBar4.Value, alfa)
        End If

        If RadioButton4.Checked = True Then
            Principal.PictureBox1.Image = objetoTratamiento.Division(bmpP, HScrollBar1.Value / 100, HScrollBar2.Value / 100, HScrollBar3.Value / 100, HScrollBar4.Value / 100, alfa)
        End If

        If RadioButton5.Checked = True Then
            Principal.PictureBox1.Image = objetoTratamiento.Multiplicacion(bmpP, HScrollBar1.Value / 100, HScrollBar2.Value / 100, HScrollBar3.Value / 100, HScrollBar4.Value / 100, alfa)
        End If

    End Sub

  

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class