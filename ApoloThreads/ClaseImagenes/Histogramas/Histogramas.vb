Imports ClaseImagenes.Apolo
Public Class Histogramas

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox1.Image) 'Imagen de principal
    Dim colorH As Color = Color.Red
    Dim valorH As Integer = 0

    Sub cargando()
        ToolStripProgressBar2.Style = ProgressBarStyle.Marquee
        ToolStripStatusLabel1.Text = "Cargando histograma"
        ToolStripProgressBar2.Size = New Size(100, ToolStripProgressBar1.Size.Height)
        ToolStripProgressBar2.MarqueeAnimationSpeed = 30
    End Sub
    Sub cargado()
        ToolStripStatusLabel1.Text = "Histograma cargado"
        ToolStripProgressBar2.Size = New Size(100, ToolStripProgressBar1.Size.Height)
        ToolStripProgressBar2.Style = ProgressBarStyle.Continuous
        ToolStripProgressBar2.Value = 100
    End Sub

    Sub New(ByVal color As Color)  'Recibimos variables en el constructor
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        colorH = color
        'Asignamos, en función del color, qué canal seleccionaremos
        If color = Drawing.Color.Red Then
            valorH = 0
        ElseIf color = Drawing.Color.Green Then
            valorH = 1
        ElseIf color = Drawing.Color.Blue Then
            valorH = 2
        End If
    End Sub

    Private Sub Histogramas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripProgressBar2.Value = 0 'Ponemos la barra de progreso a 0
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
            'Los ponesmos del colores correspondiente
            Chart1.Series("Histog").Color = colorH
            cargando()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim histoAcumulado = objetoTratamiento.histogramaAcumulado(bmpP)
        For i = 0 To UBound(histoAcumulado)
            SetChart(i + 1, histoAcumulado(i, valorH))
        Next
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        cargado()
    End Sub

    'Con este bloque podemos manejar un control (chart) desde un hilo ------
    '--------------------------------------
    Delegate Sub SetHistoCallback(ByVal i As Integer, ByVal histo As ULong)

    Private Sub SetChart(ByVal i As Integer, ByVal histo As ULong)
        ' InvokeRequired required compares the thread ID of the
        ' calling thread to the thread ID of the creating thread.
        ' If these threads are different, it returns true.
        If Chart1.InvokeRequired Then
            Dim d As New SetHistoCallback(AddressOf SetChart)
            Me.Invoke(d, New Object() {i, histo})
        Else
            Chart1.Series("Histog").Points.AddXY(i, histo)
        End If
    End Sub
    '-----------------------------------------------------------------------

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedIndex
            Case 0
                Chart1.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.SplineArea
            Case 1
                Chart1.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Area
            Case 2
                Chart1.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Column
            Case 3
                Chart1.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Spline
            Case 4
                Chart1.Series("Histog").ChartType = DataVisualization.Charting.SeriesChartType.Line
        End Select
    End Sub

    Private Sub Histogramas_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Chart1.Location = New Size(-15, 0)
        Chart1.Width = Me.Width - 60
        Chart1.Height = Me.Height - 60
        haciendolo resizable.... hay que mover el combobox y poner un minimo al formulario
    End Sub
End Class