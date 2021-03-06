﻿Imports ClaseImagenes.Apolo
Public Class Desenfocar

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal

    Private Sub Vincular(ByVal valor As Double)
        Label1.Text = valor
        HScrollBar1.Value = valor
        Label4.Text = valor
        HScrollBar2.Value = valor
    End Sub

    Private Sub Desenfocar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HScrollBar1.Maximum = bmpP.Width / 3 'Asignamos el máximo y mínimo como el ancho de la imagen
        HScrollBar1.Minimum = -bmpP.Width / 3
        HScrollBar2.Maximum = bmpP.Height / 3 'Asignamos el máximo y mínimo como el alto de la imagen
        HScrollBar2.Minimum = -bmpP.Height / 3
        HScrollBar1.Value = 0
        Label1.Text = HScrollBar1.Value
        HScrollBar2.Value = 0
        Label4.Text = HScrollBar1.Value
        'Asignamos el gestor que controle cuando sale imagen
        AddHandler objetoTratamiento.actualizaBMP, New ActualizamosImagen(AddressOf Principal.actualizarPicture)
        'Asignamos el gestor que controle cuando se abre una imagen nueva
        AddHandler objetoTratamiento.actualizaNombreImagen, New ActualizamosNombreImagen(AddressOf Principal.actualizarNombrePicture)

    End Sub

    Private Sub HScrollBar1_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar1.Scroll
        Label1.Text = HScrollBar1.Value
        If CheckBox1.Checked = True Then
            Vincular(HScrollBar1.Value)
        End If
    End Sub

    Private Sub HScrollBar2_Scroll(sender As Object, e As ScrollEventArgs) Handles HScrollBar2.Scroll
        Label4.Text = HScrollBar2.Value
        If CheckBox1.Checked = True Then
            Vincular(HScrollBar2.Value)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        HScrollBar1.Value = 0
        HScrollBar2.Value = 0
        Label1.Text = 0
        Label4.Text = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Principal.PictureBox1.Image = objetoTratamiento.desenfoque(bmpP, -HScrollBar1.Value, -HScrollBar2.Value)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class