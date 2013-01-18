<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TodosHistogramas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ChartArea45 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series45 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea46 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series46 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea47 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series47 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea48 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series48 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Chart4 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart3 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ToolStripProgressBar2 = New System.Windows.Forms.ToolStripProgressBar()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.HerramientasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RecargarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TipoDeGráficoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÁreasplineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÁreaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColumnasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LíneasplineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LíneaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Chart4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Chart4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Chart3, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Chart2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Chart1, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(-6, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(920, 383)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Chart4
        '
        Me.Chart4.BackColor = System.Drawing.SystemColors.Control
        ChartArea45.Name = "ChartArea1"
        Me.Chart4.ChartAreas.Add(ChartArea45)
        Me.Chart4.Location = New System.Drawing.Point(463, 194)
        Me.Chart4.Name = "Chart4"
        Series45.ChartArea = "ChartArea1"
        Series45.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series45.IsVisibleInLegend = False
        Series45.Name = "Histog"
        Series45.YValuesPerPoint = 2
        Me.Chart4.Series.Add(Series45)
        Me.Chart4.Size = New System.Drawing.Size(454, 186)
        Me.Chart4.TabIndex = 12
        Me.Chart4.Text = "Histograma"
        Me.ToolTip1.SetToolTip(Me.Chart4, "Histograma escala de grises")
        '
        'Chart3
        '
        Me.Chart3.BackColor = System.Drawing.SystemColors.Control
        ChartArea46.Name = "ChartArea1"
        Me.Chart3.ChartAreas.Add(ChartArea46)
        Me.Chart3.Location = New System.Drawing.Point(3, 194)
        Me.Chart3.Name = "Chart3"
        Series46.ChartArea = "ChartArea1"
        Series46.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series46.IsVisibleInLegend = False
        Series46.Name = "Histog"
        Series46.YValuesPerPoint = 2
        Me.Chart3.Series.Add(Series46)
        Me.Chart3.Size = New System.Drawing.Size(454, 186)
        Me.Chart3.TabIndex = 11
        Me.Chart3.Text = "Histograma"
        Me.ToolTip1.SetToolTip(Me.Chart3, "Histograma azul")
        '
        'Chart2
        '
        Me.Chart2.BackColor = System.Drawing.SystemColors.Control
        ChartArea47.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea47)
        Me.Chart2.Location = New System.Drawing.Point(463, 3)
        Me.Chart2.Name = "Chart2"
        Series47.ChartArea = "ChartArea1"
        Series47.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series47.IsVisibleInLegend = False
        Series47.Name = "Histog"
        Series47.YValuesPerPoint = 2
        Me.Chart2.Series.Add(Series47)
        Me.Chart2.Size = New System.Drawing.Size(454, 185)
        Me.Chart2.TabIndex = 10
        Me.Chart2.Text = "Histograma"
        Me.ToolTip1.SetToolTip(Me.Chart2, "Histograma verde")
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.SystemColors.Control
        ChartArea48.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea48)
        Me.Chart1.Location = New System.Drawing.Point(3, 3)
        Me.Chart1.Name = "Chart1"
        Series48.ChartArea = "ChartArea1"
        Series48.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series48.IsVisibleInLegend = False
        Series48.Name = "Histog"
        Series48.YValuesPerPoint = 2
        Me.Chart1.Series.Add(Series48)
        Me.Chart1.Size = New System.Drawing.Size(454, 185)
        Me.Chart1.TabIndex = 9
        Me.Chart1.Text = "Histograma"
        Me.ToolTip1.SetToolTip(Me.Chart1, "Histograma rojo")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripProgressBar1, Me.ToolStripProgressBar2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 373)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(914, 22)
        Me.StatusStrip1.TabIndex = 6
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(0, 16)
        Me.ToolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        '
        'ToolStripProgressBar2
        '
        Me.ToolStripProgressBar2.Name = "ToolStripProgressBar2"
        Me.ToolStripProgressBar2.Size = New System.Drawing.Size(100, 16)
        '
        'BackgroundWorker1
        '
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HerramientasToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(914, 24)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HerramientasToolStripMenuItem
        '
        Me.HerramientasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RecargarToolStripMenuItem, Me.TipoDeGráficoToolStripMenuItem})
        Me.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem"
        Me.HerramientasToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.HerramientasToolStripMenuItem.Text = "Herramientas"
        '
        'RecargarToolStripMenuItem
        '
        Me.RecargarToolStripMenuItem.Name = "RecargarToolStripMenuItem"
        Me.RecargarToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.RecargarToolStripMenuItem.Text = "Recargar"
        '
        'TipoDeGráficoToolStripMenuItem
        '
        Me.TipoDeGráficoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ÁreasplineToolStripMenuItem, Me.ÁreaToolStripMenuItem, Me.ColumnasToolStripMenuItem, Me.LíneasplineToolStripMenuItem, Me.LíneaToolStripMenuItem})
        Me.TipoDeGráficoToolStripMenuItem.Name = "TipoDeGráficoToolStripMenuItem"
        Me.TipoDeGráficoToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.TipoDeGráficoToolStripMenuItem.Text = "Tipo de gráfico"
        '
        'ÁreasplineToolStripMenuItem
        '
        Me.ÁreasplineToolStripMenuItem.Checked = True
        Me.ÁreasplineToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ÁreasplineToolStripMenuItem.Name = "ÁreasplineToolStripMenuItem"
        Me.ÁreasplineToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ÁreasplineToolStripMenuItem.Text = "Área (spline)"
        '
        'ÁreaToolStripMenuItem
        '
        Me.ÁreaToolStripMenuItem.Name = "ÁreaToolStripMenuItem"
        Me.ÁreaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ÁreaToolStripMenuItem.Text = "Área"
        '
        'ColumnasToolStripMenuItem
        '
        Me.ColumnasToolStripMenuItem.Name = "ColumnasToolStripMenuItem"
        Me.ColumnasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ColumnasToolStripMenuItem.Text = "Columnas"
        '
        'LíneasplineToolStripMenuItem
        '
        Me.LíneasplineToolStripMenuItem.Name = "LíneasplineToolStripMenuItem"
        Me.LíneasplineToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LíneasplineToolStripMenuItem.Text = "Línea (spline)"
        '
        'LíneaToolStripMenuItem
        '
        Me.LíneaToolStripMenuItem.Name = "LíneaToolStripMenuItem"
        Me.LíneaToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.LíneaToolStripMenuItem.Text = "Línea"
        '
        'TodosHistogramas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(914, 395)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(300, 300)
        Me.Name = "TodosHistogramas"
        Me.Text = "Histogramas"
        Me.TopMost = True
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Chart4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Chart4 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart3 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents ToolStripProgressBar2 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HerramientasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RecargarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TipoDeGráficoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÁreasplineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÁreaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColumnasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LíneasplineToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LíneaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
