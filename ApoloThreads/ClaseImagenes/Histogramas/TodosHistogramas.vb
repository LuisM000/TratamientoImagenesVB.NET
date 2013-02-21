Imports ClaseImagenes.Apolo
Public Class TodosHistogramas
    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal

    Sub cargando()
        ToolStripProgressBar2.Style = ProgressBarStyle.Marquee
        ToolStripStatusLabel1.Text = "Cargando histograma"
        ToolStripProgressBar2.Size = New Size(100, ToolStripProgressBar1.Size.Height)
        ToolStripProgressBar2.MarqueeAnimationSpeed = 30
    End Sub
    Sub cargado()
        Try
            ToolStripStatusLabel1.Text = "Histograma cargado"
            ToolStripProgressBar2.Size = New Size(100, ToolStripProgressBar1.Size.Height)
            ToolStripProgressBar2.Style = ProgressBarStyle.Continuous
            ToolStripProgressBar2.Value = 100
        Catch
        End Try
    End Sub
    Sub recargar()
        bmpP = Principal.PictureBox2.Image
        ToolStripProgressBar2.Value = 0 'Ponemos la barra de progreso a 0
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
            'Borramos el posible contenido del chart
            Chart1.Series("Histog").Points.Clear()
            Chart2.Series("Histog").Points.Clear()
            Chart3.Series("Histog").Points.Clear()
            Chart4.Series("Histog").Points.Clear()
            'Los ponesmos del colores correspondiente
            Chart1.Series("Histog").Color = Color.Red
            Chart2.Series("Histog").Color = Color.Green
            Chart3.Series("Histog").Color = Color.Blue
            Chart4.Series("Histog").Color = Color.Black
            cargando() 'Controlamos la barra de progreso
        End If

    End Sub
    Private Sub TodosHistogramas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripProgressBar2.Value = 0 'Ponemos la barra de progreso a 0
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
            'Borramos el posible contenido del chart
            Chart1.Series("Histog").Points.Clear()
            Chart2.Series("Histog").Points.Clear()
            Chart3.Series("Histog").Points.Clear()
            Chart4.Series("Histog").Points.Clear()
            'Los ponesmos del colores correspondiente
            Chart1.Series("Histog").Color = Color.Red
            Chart2.Series("Histog").Color = Color.Green
            Chart3.Series("Histog").Color = Color.Blue
            Chart4.Series("Histog").Color = Color.Black
            cargando() 'Controlamos la barra de progreso
        End If

    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim histoAcumulado = objetoTratamiento.histogramaAcumuladoH(bmpP)
        For i = 0 To UBound(histoAcumulado)
            SetChart(i + 1, histoAcumulado(i, 0), histoAcumulado(i, 1), histoAcumulado(i, 2), histoAcumulado(i, 4))
        Next
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        cargado() 'Controlamos la barra de progreso
    End Sub


    'Con este bloque podemos manejar los controles chart desde un hilo ------
    '--------------------------------------
#Region "Delegado/invokeRequired"
    Delegate Sub SetHistoCallback(ByVal i As Integer, ByVal histoR As ULong, ByVal histoG As ULong, ByVal histoB As ULong, ByVal histoGrises As ULong)

    Private Sub SetChart(ByVal i As Integer, ByVal histoR As ULong, ByVal histoG As ULong, ByVal histoB As ULong, ByVal histoGrises As ULong)
        Try
            ' InvokeRequired required compares the thread ID of the
            ' calling thread to the thread ID of the creating thread.
            ' If these threads are different, it returns true.
            If Chart1.InvokeRequired Then
                Dim d As New SetHistoCallback(AddressOf SetChart)
                Me.Invoke(d, New Object() {i, histoR, histoG, histoB, histoG})
            Else
                Chart1.Series("Histog").Points.AddXY(i, histoR)
                Chart2.Series("Histog").Points.AddXY(i, histoG)
                Chart3.Series("Histog").Points.AddXY(i, histoB)
                Chart4.Series("Histog").Points.AddXY(i, histoGrises)
            End If
        Catch
        End Try
    End Sub
#End Region
    '-----------------------------------------------------------------------

    'Botón recargar
    Private Sub RecargarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecargarToolStripMenuItem.Click
        recargar()
    End Sub

    'Ajustamos los chart
    Private Sub TodosHistogramas_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        TableLayoutPanel1.Size = New Size(Me.Width, Me.Height - 80)
        Chart1.Size = Me.Size
        Chart2.Size = Me.Size
        Chart3.Size = Me.Size
        Chart4.Size = Me.Size
    End Sub

#Region "Cambiar tipo de gráfica"
    Sub quitarCheck()
        ÁreasplineToolStripMenuItem.Checked = False
        ÁreaToolStripMenuItem.Checked = False
        ColumnasToolStripMenuItem.Checked = False
        LíneasplineToolStripMenuItem.Checked = False
        LíneaToolStripMenuItem.Checked = False
    End Sub
    Private Sub ÁreasplineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÁreasplineToolStripMenuItem.Click
        quitarCheck()
        ÁreasplineToolStripMenuItem.Checked = True
        Chart1.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.SplineArea
        Chart2.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.SplineArea
        Chart3.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.SplineArea
        Chart4.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.SplineArea
    End Sub

    Private Sub ÁreaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÁreaToolStripMenuItem.Click
        quitarCheck()
        ÁreaToolStripMenuItem.Checked = True
        Chart1.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Area
        Chart2.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Area
        Chart3.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Area
        Chart4.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Area
    End Sub

    Private Sub ColumnasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ColumnasToolStripMenuItem.Click
        quitarCheck()
        ColumnasToolStripMenuItem.Checked = True
        Chart1.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Column
        Chart2.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Column
        Chart3.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Column
        Chart4.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Column
    End Sub

    Private Sub LíneasplineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LíneasplineToolStripMenuItem.Click
        quitarCheck()
        LíneasplineToolStripMenuItem.Checked = True
        Chart1.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Spline
        Chart2.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Spline
        Chart3.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Spline
        Chart4.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Spline
    End Sub

    Private Sub LíneaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LíneaToolStripMenuItem.Click
        quitarCheck()
        LíneaToolStripMenuItem.Checked = True
        Chart1.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart2.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart3.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart4.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Line
    End Sub
#End Region
End Class