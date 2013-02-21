Imports ClaseImagenes.Apolo
Public Class Histogramas

    Dim objetoTratamiento As New TratamientoImagenes 'Instancia a la clase TratamientoImagenes
    Dim bmpP As New Bitmap(Principal.PictureBox2.Image) 'Imagen de principal
    Dim colorH As Color = Color.Red
    Dim valorH As Integer = 0

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
    Sub Recargar()
        bmpP = Principal.PictureBox2.Image
        ToolStripProgressBar2.Value = 0 'Ponemos la barra de progreso a 0
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
            'Borramos el posible contenido del chart
            Chart1.Series("Histog").Points.Clear()
            'Los ponesmos del colores correspondiente
            Chart1.Series("Histog").Color = colorH
            cargando() 'Controlamos la barra de progreso
        End If
    End Sub

    'Constructor del formulario (recibe parámetro color)
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
        ElseIf color = Drawing.Color.White Then 'alfa
            valorH = 3
        ElseIf color = Drawing.Color.Black Then 'escala de grises
            valorH = 4
        End If
    End Sub

    Private Sub Histogramas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolStripProgressBar2.Value = 0 'Ponemos la barra de progreso a 0
        ComboBox1.SelectedIndex = 0
        If BackgroundWorker1.IsBusy = False Then
            BackgroundWorker1.RunWorkerAsync()
            'Borramos el posible contenido del chart
            Chart1.Series("Histog").Points.Clear()
            'Los ponesmos del colores correspondiente
            Chart1.Series("Histog").Color = colorH
            cargando() 'Controlamos la barra de progreso
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim histoAcumulado = objetoTratamiento.histogramaAcumuladoH(bmpP)
        For i = 0 To UBound(histoAcumulado)
            SetChart(i + 1, histoAcumulado(i, valorH))
        Next
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        cargado() 'Controlamos la barra de progreso
    End Sub

    'Con este bloque podemos manejar un control (chart) desde un hilo ------
    '--------------------------------------
#Region "Delegado/invokeRequired"
    Delegate Sub SetHistoCallback(ByVal i As Integer, ByVal histo As ULong)

    Private Sub SetChart(ByVal i As Integer, ByVal histo As ULong)
        Try
            ' InvokeRequired required compares the thread ID of the
            ' calling thread to the thread ID of the creating thread.
            ' If these threads are different, it returns true.
            If Chart1.InvokeRequired Then
                Dim d As New SetHistoCallback(AddressOf SetChart)
                Me.Invoke(d, New Object() {i, histo})
            Else
                Chart1.Series("Histog").Points.AddXY(i, histo)
            End If
        Catch
        End Try
    End Sub
#End Region
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

   

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Recargar()
    End Sub

    'Con esto creamos histogramas de los diferentes colores
    'Histograma azul
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Cambiamos color y valorH y actualizamos
        colorH = Color.Blue
        valorH = 2
        Recargar()
    End Sub

    'Histograma verde
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        colorH = Color.Green
        valorH = 1
        Recargar()
    End Sub
    'Histograma rojo
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        colorH = Color.Red
        valorH = 0
        Recargar()
    End Sub
    'Hitograma grises
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        colorH = Color.Black
        valorH = 4
        Recargar()
    End Sub
    'Histograma alfa
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        colorH = Color.SlateGray
        valorH = 3
        Recargar()
    End Sub

    'Ordenazación de los controles al redimensionar la ventana
    Private Sub Histogramas_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Chart1.Location = New Size(-15, 0)
        Chart1.Width = Me.Width - 60
        Chart1.Height = Me.Height - 80
        Button1.Location = New Size(Me.Width - 72, Button1.Location.Y)
        Button2.Location = New Size(Me.Width - 72, Button2.Location.Y)
        Button3.Location = New Size(Me.Width - 72, Button3.Location.Y)
        Button4.Location = New Size(Me.Width - 72, Button4.Location.Y)
        Button5.Location = New Size(Me.Width - 72, Button5.Location.Y)
        Button6.Location = New Size(Me.Width - 72, Button6.Location.Y)
        ComboBox1.Location = New Size(Me.Width - (ComboBox1.Width + 32), Me.Height - 92)
    End Sub

  
End Class