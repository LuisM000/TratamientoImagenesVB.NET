<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Principal
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
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ImagenActual = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BarraEstado = New System.Windows.Forms.ToolStripProgressBar()
        Me.PorcentajeActual = New System.Windows.Forms.ToolStripStatusLabel()
        Me.EstadoActual = New System.Windows.Forms.ToolStripStatusLabel()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.AbrirImagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirImagenToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CargarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarImágenesEnLaWebToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarImágenesEnFacebookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearTapizToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.GuardarComoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdiciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeshacerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RehacerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeCambiosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefrescarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImagenOriginalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesBásicosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EscalaDeGrisesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EscalaDeGrisesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvertirColoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RGBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RojoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerdeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AzulToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SepiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltrosBásicosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltroRojoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltroVerdeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltroAzulToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RGBAToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BGRToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GRBToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RBGToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReflexiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.HistogramasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetalladoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlancoYNegroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EscalaDeGrisesToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BrilloToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContrasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Contraste1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Contraste2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExposiciónToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarCanalesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReducirColoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltrarColoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatrizToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetectarContornosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OperacionesAritméticasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesLógicasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesMorfológicasbetaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MáscarasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasoAltoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasoBajoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BordesYContornosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MáscaraManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobelTotalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EfectosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesenfoqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesenfonqueDistorsiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesenfoqueMovimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesenfoqueBLURToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PixeladoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuadrículaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SombraDeVidrioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SdaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TresPartesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeisPartesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RadmiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PonerLosDosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÓleoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesConDosImágenesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SumaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesLógicasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComparadorDeImágenesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VecinosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransformacionesGeométricasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReflexiónToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TraslaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RotaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ErrorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Chart3 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AbrirImagenToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarImagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefrescarToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizarToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ArchivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirImagenToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirRecursoWebToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarImágenesEnLaWebToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BuscarImágenesEnFacebookToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearTapizToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdiciónToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeshacerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RehacerToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeCambiosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefrescarToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ImagenOriginalToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesBásicasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlancoYNegroToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EscalaDeGrisesToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.InvertirColoresToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RGBToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RojoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerdeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AzulToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SepiaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltrosBásicosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltroRojoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltroVerdeToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltroAzulToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RGBAToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BGRToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GRBToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RBGToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReflexiónToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.HorizontalToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerticalToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesBásicasPersonalizadasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlancoYNegroToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EscalaDeGrisesToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BrilloToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContrasteToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Contraste1recomendadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Contraste2ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExposiciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarCanalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReducirColoresToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltrarColoresToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatrizToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetectarContornosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesAritméticasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesLógicasToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesMorfológicasbetaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MáscarasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasoAltoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasoBajoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BordesYContornosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MáscaraManualToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobelTotalToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.EfectosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.DenfoqueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DenfoqueDistorsiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DenfoqueMovimientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DenfoqueBlurToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PixeladoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuadrículaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TrocearImagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TresPartesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeisPartesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RuidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RuidoAleatorioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RuidoDesplazadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesConDosImágenesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesAritméticasToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesLógicasToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransformacionesGeométricasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReflexiónToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TraslaciónToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RotaciónToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.TransformaciónAfínToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotificarUnErrorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImagenActual, Me.BarraEstado, Me.PorcentajeActual, Me.EstadoActual})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 692)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1276, 24)
        Me.StatusStrip1.TabIndex = 27
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ImagenActual
        '
        Me.ImagenActual.Name = "ImagenActual"
        Me.ImagenActual.Size = New System.Drawing.Size(76, 19)
        Me.ImagenActual.Text = "Apolo thread"
        '
        'BarraEstado
        '
        Me.BarraEstado.Name = "BarraEstado"
        Me.BarraEstado.Size = New System.Drawing.Size(583, 18)
        '
        'PorcentajeActual
        '
        Me.PorcentajeActual.Name = "PorcentajeActual"
        Me.PorcentajeActual.Size = New System.Drawing.Size(35, 19)
        Me.PorcentajeActual.Text = "100%"
        '
        'EstadoActual
        '
        Me.EstadoActual.Name = "EstadoActual"
        Me.EstadoActual.Size = New System.Drawing.Size(60, 19)
        Me.EstadoActual.Text = "Finalizado"
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 300
        '
        'AbrirImagenToolStripMenuItem
        '
        Me.AbrirImagenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirImagenToolStripMenuItem1, Me.CargarToolStripMenuItem, Me.BuscarImágenesEnLaWebToolStripMenuItem, Me.BuscarImágenesEnFacebookToolStripMenuItem, Me.CrearTapizToolStripMenuItem, Me.ToolStripMenuItem4, Me.GuardarComoToolStripMenuItem})
        Me.AbrirImagenToolStripMenuItem.Name = "AbrirImagenToolStripMenuItem"
        Me.AbrirImagenToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.AbrirImagenToolStripMenuItem.Text = "Archivo"
        '
        'AbrirImagenToolStripMenuItem1
        '
        Me.AbrirImagenToolStripMenuItem1.Name = "AbrirImagenToolStripMenuItem1"
        Me.AbrirImagenToolStripMenuItem1.Size = New System.Drawing.Size(233, 22)
        Me.AbrirImagenToolStripMenuItem1.Text = "Abrir imagen"
        '
        'CargarToolStripMenuItem
        '
        Me.CargarToolStripMenuItem.Name = "CargarToolStripMenuItem"
        Me.CargarToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.CargarToolStripMenuItem.Text = "Abrir recurso web"
        '
        'BuscarImágenesEnLaWebToolStripMenuItem
        '
        Me.BuscarImágenesEnLaWebToolStripMenuItem.Name = "BuscarImágenesEnLaWebToolStripMenuItem"
        Me.BuscarImágenesEnLaWebToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.BuscarImágenesEnLaWebToolStripMenuItem.Text = "Buscar imágenes en la web"
        '
        'BuscarImágenesEnFacebookToolStripMenuItem
        '
        Me.BuscarImágenesEnFacebookToolStripMenuItem.Name = "BuscarImágenesEnFacebookToolStripMenuItem"
        Me.BuscarImágenesEnFacebookToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.BuscarImágenesEnFacebookToolStripMenuItem.Text = "Buscar imágenes en Facebook"
        '
        'CrearTapizToolStripMenuItem
        '
        Me.CrearTapizToolStripMenuItem.Name = "CrearTapizToolStripMenuItem"
        Me.CrearTapizToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.CrearTapizToolStripMenuItem.Text = "Crear tapiz"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(230, 6)
        '
        'GuardarComoToolStripMenuItem
        '
        Me.GuardarComoToolStripMenuItem.Name = "GuardarComoToolStripMenuItem"
        Me.GuardarComoToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.GuardarComoToolStripMenuItem.Text = "Guardar como..."
        '
        'EdiciónToolStripMenuItem
        '
        Me.EdiciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeshacerToolStripMenuItem, Me.RehacerToolStripMenuItem, Me.RegistroDeCambiosToolStripMenuItem, Me.ActualizarToolStripMenuItem, Me.RefrescarToolStripMenuItem, Me.ToolStripMenuItem1, Me.ImagenOriginalToolStripMenuItem})
        Me.EdiciónToolStripMenuItem.Name = "EdiciónToolStripMenuItem"
        Me.EdiciónToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.EdiciónToolStripMenuItem.Text = "Edición"
        '
        'DeshacerToolStripMenuItem
        '
        Me.DeshacerToolStripMenuItem.Name = "DeshacerToolStripMenuItem"
        Me.DeshacerToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.DeshacerToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.DeshacerToolStripMenuItem.Text = "Deshacer"
        '
        'RehacerToolStripMenuItem
        '
        Me.RehacerToolStripMenuItem.Name = "RehacerToolStripMenuItem"
        Me.RehacerToolStripMenuItem.ShortcutKeyDisplayString = ""
        Me.RehacerToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RehacerToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.RehacerToolStripMenuItem.Text = "Rehacer"
        '
        'RegistroDeCambiosToolStripMenuItem
        '
        Me.RegistroDeCambiosToolStripMenuItem.Name = "RegistroDeCambiosToolStripMenuItem"
        Me.RegistroDeCambiosToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.RegistroDeCambiosToolStripMenuItem.Text = "Registro de cambios"
        '
        'ActualizarToolStripMenuItem
        '
        Me.ActualizarToolStripMenuItem.Name = "ActualizarToolStripMenuItem"
        Me.ActualizarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ActualizarToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ActualizarToolStripMenuItem.Text = "Actualizar"
        '
        'RefrescarToolStripMenuItem
        '
        Me.RefrescarToolStripMenuItem.Name = "RefrescarToolStripMenuItem"
        Me.RefrescarToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.RefrescarToolStripMenuItem.Text = "Refrescar"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(178, 6)
        '
        'ImagenOriginalToolStripMenuItem
        '
        Me.ImagenOriginalToolStripMenuItem.Name = "ImagenOriginalToolStripMenuItem"
        Me.ImagenOriginalToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ImagenOriginalToolStripMenuItem.Text = "Imagen original"
        '
        'OperacionesBásicosToolStripMenuItem
        '
        Me.OperacionesBásicosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EscalaDeGrisesToolStripMenuItem, Me.EscalaDeGrisesToolStripMenuItem1, Me.InvertirColoresToolStripMenuItem, Me.SepiaToolStripMenuItem, Me.FiltrosBásicosToolStripMenuItem, Me.RGBAToolStripMenuItem, Me.ReflexiónToolStripMenuItem, Me.ToolStripMenuItem5, Me.HistogramasToolStripMenuItem})
        Me.OperacionesBásicosToolStripMenuItem.Name = "OperacionesBásicosToolStripMenuItem"
        Me.OperacionesBásicosToolStripMenuItem.Size = New System.Drawing.Size(127, 20)
        Me.OperacionesBásicosToolStripMenuItem.Text = "Operaciones básicos"
        '
        'EscalaDeGrisesToolStripMenuItem
        '
        Me.EscalaDeGrisesToolStripMenuItem.Name = "EscalaDeGrisesToolStripMenuItem"
        Me.EscalaDeGrisesToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.EscalaDeGrisesToolStripMenuItem.Text = "Blanco y negro"
        '
        'EscalaDeGrisesToolStripMenuItem1
        '
        Me.EscalaDeGrisesToolStripMenuItem1.Name = "EscalaDeGrisesToolStripMenuItem1"
        Me.EscalaDeGrisesToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
        Me.EscalaDeGrisesToolStripMenuItem1.Text = "Escala de grises"
        '
        'InvertirColoresToolStripMenuItem
        '
        Me.InvertirColoresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RGBToolStripMenuItem, Me.RojoToolStripMenuItem, Me.VerdeToolStripMenuItem, Me.AzulToolStripMenuItem})
        Me.InvertirColoresToolStripMenuItem.Name = "InvertirColoresToolStripMenuItem"
        Me.InvertirColoresToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.InvertirColoresToolStripMenuItem.Text = "Invertir colores"
        '
        'RGBToolStripMenuItem
        '
        Me.RGBToolStripMenuItem.Name = "RGBToolStripMenuItem"
        Me.RGBToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.RGBToolStripMenuItem.Text = "RGB"
        '
        'RojoToolStripMenuItem
        '
        Me.RojoToolStripMenuItem.Name = "RojoToolStripMenuItem"
        Me.RojoToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.RojoToolStripMenuItem.Text = "Rojo"
        '
        'VerdeToolStripMenuItem
        '
        Me.VerdeToolStripMenuItem.Name = "VerdeToolStripMenuItem"
        Me.VerdeToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.VerdeToolStripMenuItem.Text = "Verde"
        '
        'AzulToolStripMenuItem
        '
        Me.AzulToolStripMenuItem.Name = "AzulToolStripMenuItem"
        Me.AzulToolStripMenuItem.Size = New System.Drawing.Size(104, 22)
        Me.AzulToolStripMenuItem.Text = "Azul"
        '
        'SepiaToolStripMenuItem
        '
        Me.SepiaToolStripMenuItem.Name = "SepiaToolStripMenuItem"
        Me.SepiaToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.SepiaToolStripMenuItem.Text = "Sepia"
        '
        'FiltrosBásicosToolStripMenuItem
        '
        Me.FiltrosBásicosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FiltroRojoToolStripMenuItem, Me.FiltroVerdeToolStripMenuItem, Me.FiltroAzulToolStripMenuItem})
        Me.FiltrosBásicosToolStripMenuItem.Name = "FiltrosBásicosToolStripMenuItem"
        Me.FiltrosBásicosToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.FiltrosBásicosToolStripMenuItem.Text = "Filtros básicos"
        '
        'FiltroRojoToolStripMenuItem
        '
        Me.FiltroRojoToolStripMenuItem.Name = "FiltroRojoToolStripMenuItem"
        Me.FiltroRojoToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.FiltroRojoToolStripMenuItem.Text = "Filtro rojo"
        '
        'FiltroVerdeToolStripMenuItem
        '
        Me.FiltroVerdeToolStripMenuItem.Name = "FiltroVerdeToolStripMenuItem"
        Me.FiltroVerdeToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.FiltroVerdeToolStripMenuItem.Text = "Filtro verde"
        '
        'FiltroAzulToolStripMenuItem
        '
        Me.FiltroAzulToolStripMenuItem.Name = "FiltroAzulToolStripMenuItem"
        Me.FiltroAzulToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.FiltroAzulToolStripMenuItem.Text = "Filtro azul"
        '
        'RGBAToolStripMenuItem
        '
        Me.RGBAToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BGRToolStripMenuItem, Me.GRBToolStripMenuItem, Me.RBGToolStripMenuItem})
        Me.RGBAToolStripMenuItem.Name = "RGBAToolStripMenuItem"
        Me.RGBAToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.RGBAToolStripMenuItem.Text = "RGB a..."
        '
        'BGRToolStripMenuItem
        '
        Me.BGRToolStripMenuItem.Name = "BGRToolStripMenuItem"
        Me.BGRToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.BGRToolStripMenuItem.Text = "BGR"
        '
        'GRBToolStripMenuItem
        '
        Me.GRBToolStripMenuItem.Name = "GRBToolStripMenuItem"
        Me.GRBToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.GRBToolStripMenuItem.Text = "GRB"
        '
        'RBGToolStripMenuItem
        '
        Me.RBGToolStripMenuItem.Name = "RBGToolStripMenuItem"
        Me.RBGToolStripMenuItem.Size = New System.Drawing.Size(96, 22)
        Me.RBGToolStripMenuItem.Text = "RBG"
        '
        'ReflexiónToolStripMenuItem
        '
        Me.ReflexiónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HorizontalToolStripMenuItem, Me.VerticalToolStripMenuItem})
        Me.ReflexiónToolStripMenuItem.Name = "ReflexiónToolStripMenuItem"
        Me.ReflexiónToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.ReflexiónToolStripMenuItem.Text = "Reflexión"
        '
        'HorizontalToolStripMenuItem
        '
        Me.HorizontalToolStripMenuItem.Name = "HorizontalToolStripMenuItem"
        Me.HorizontalToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.HorizontalToolStripMenuItem.Text = "Horizontal"
        '
        'VerticalToolStripMenuItem
        '
        Me.VerticalToolStripMenuItem.Name = "VerticalToolStripMenuItem"
        Me.VerticalToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.VerticalToolStripMenuItem.Text = "Vertical"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(152, 6)
        '
        'HistogramasToolStripMenuItem
        '
        Me.HistogramasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetalladoToolStripMenuItem1, Me.TodosToolStripMenuItem1})
        Me.HistogramasToolStripMenuItem.Name = "HistogramasToolStripMenuItem"
        Me.HistogramasToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.HistogramasToolStripMenuItem.Text = "Histogramas"
        '
        'DetalladoToolStripMenuItem1
        '
        Me.DetalladoToolStripMenuItem1.Name = "DetalladoToolStripMenuItem1"
        Me.DetalladoToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.DetalladoToolStripMenuItem1.Text = "Detallado"
        '
        'TodosToolStripMenuItem1
        '
        Me.TodosToolStripMenuItem1.Name = "TodosToolStripMenuItem1"
        Me.TodosToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.TodosToolStripMenuItem1.Text = "Todos"
        '
        'OperacionesBásicosPersonalizadasToolStripMenuItem
        '
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlancoYNegroToolStripMenuItem, Me.EscalaDeGrisesToolStripMenuItem2, Me.BrilloToolStripMenuItem1, Me.ContrasteToolStripMenuItem, Me.ExposiciónToolStripMenuItem1, Me.ModificarCanalesToolStripMenuItem1, Me.ReducirColoresToolStripMenuItem, Me.FiltrarColoresToolStripMenuItem, Me.MatrizToolStripMenuItem, Me.DetectarContornosToolStripMenuItem})
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem.Name = "OperacionesBásicosPersonalizadasToolStripMenuItem"
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem.Size = New System.Drawing.Size(207, 20)
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem.Text = "Operaciones básicos personalizadas"
        '
        'BlancoYNegroToolStripMenuItem
        '
        Me.BlancoYNegroToolStripMenuItem.Name = "BlancoYNegroToolStripMenuItem"
        Me.BlancoYNegroToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.BlancoYNegroToolStripMenuItem.Text = "Blanco y negro"
        '
        'EscalaDeGrisesToolStripMenuItem2
        '
        Me.EscalaDeGrisesToolStripMenuItem2.Name = "EscalaDeGrisesToolStripMenuItem2"
        Me.EscalaDeGrisesToolStripMenuItem2.Size = New System.Drawing.Size(175, 22)
        Me.EscalaDeGrisesToolStripMenuItem2.Text = "Escala de grises"
        '
        'BrilloToolStripMenuItem1
        '
        Me.BrilloToolStripMenuItem1.Name = "BrilloToolStripMenuItem1"
        Me.BrilloToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.BrilloToolStripMenuItem1.Text = "Brillo"
        '
        'ContrasteToolStripMenuItem
        '
        Me.ContrasteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Contraste1ToolStripMenuItem, Me.Contraste2ToolStripMenuItem})
        Me.ContrasteToolStripMenuItem.Name = "ContrasteToolStripMenuItem"
        Me.ContrasteToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.ContrasteToolStripMenuItem.Text = "Contraste"
        '
        'Contraste1ToolStripMenuItem
        '
        Me.Contraste1ToolStripMenuItem.Name = "Contraste1ToolStripMenuItem"
        Me.Contraste1ToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.Contraste1ToolStripMenuItem.Text = "Contraste 1 (recomendado)"
        '
        'Contraste2ToolStripMenuItem
        '
        Me.Contraste2ToolStripMenuItem.Name = "Contraste2ToolStripMenuItem"
        Me.Contraste2ToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.Contraste2ToolStripMenuItem.Text = "Contraste 2"
        '
        'ExposiciónToolStripMenuItem1
        '
        Me.ExposiciónToolStripMenuItem1.Name = "ExposiciónToolStripMenuItem1"
        Me.ExposiciónToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.ExposiciónToolStripMenuItem1.Text = "Exposición"
        '
        'ModificarCanalesToolStripMenuItem1
        '
        Me.ModificarCanalesToolStripMenuItem1.Name = "ModificarCanalesToolStripMenuItem1"
        Me.ModificarCanalesToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.ModificarCanalesToolStripMenuItem1.Text = "Modificar canales"
        '
        'ReducirColoresToolStripMenuItem
        '
        Me.ReducirColoresToolStripMenuItem.Name = "ReducirColoresToolStripMenuItem"
        Me.ReducirColoresToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.ReducirColoresToolStripMenuItem.Text = "Reducir colores"
        '
        'FiltrarColoresToolStripMenuItem
        '
        Me.FiltrarColoresToolStripMenuItem.Name = "FiltrarColoresToolStripMenuItem"
        Me.FiltrarColoresToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.FiltrarColoresToolStripMenuItem.Text = "Filtrar colores"
        '
        'MatrizToolStripMenuItem
        '
        Me.MatrizToolStripMenuItem.Name = "MatrizToolStripMenuItem"
        Me.MatrizToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.MatrizToolStripMenuItem.Text = "Matriz"
        '
        'DetectarContornosToolStripMenuItem
        '
        Me.DetectarContornosToolStripMenuItem.Name = "DetectarContornosToolStripMenuItem"
        Me.DetectarContornosToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.DetectarContornosToolStripMenuItem.Text = "Detectar contornos"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirImagenToolStripMenuItem, Me.EdiciónToolStripMenuItem, Me.OperacionesBásicosToolStripMenuItem, Me.OperacionesBásicosPersonalizadasToolStripMenuItem, Me.OperacionesAritméticasToolStripMenuItem, Me.MáscarasToolStripMenuItem, Me.EfectosToolStripMenuItem, Me.OperacionesConDosImágenesToolStripMenuItem, Me.TransformacionesGeométricasToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.ShowItemToolTips = True
        Me.MenuStrip1.Size = New System.Drawing.Size(1276, 24)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OperacionesAritméticasToolStripMenuItem
        '
        Me.OperacionesAritméticasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperacionesToolStripMenuItem, Me.OperacionesLógicasToolStripMenuItem, Me.OperacionesMorfológicasbetaToolStripMenuItem})
        Me.OperacionesAritméticasToolStripMenuItem.Name = "OperacionesAritméticasToolStripMenuItem"
        Me.OperacionesAritméticasToolStripMenuItem.Size = New System.Drawing.Size(85, 20)
        Me.OperacionesAritméticasToolStripMenuItem.Text = "Operaciones"
        '
        'OperacionesToolStripMenuItem
        '
        Me.OperacionesToolStripMenuItem.Name = "OperacionesToolStripMenuItem"
        Me.OperacionesToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.OperacionesToolStripMenuItem.Text = "Operaciones aritméticas"
        '
        'OperacionesLógicasToolStripMenuItem
        '
        Me.OperacionesLógicasToolStripMenuItem.Name = "OperacionesLógicasToolStripMenuItem"
        Me.OperacionesLógicasToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.OperacionesLógicasToolStripMenuItem.Text = "Operaciones lógicas"
        '
        'OperacionesMorfológicasbetaToolStripMenuItem
        '
        Me.OperacionesMorfológicasbetaToolStripMenuItem.Name = "OperacionesMorfológicasbetaToolStripMenuItem"
        Me.OperacionesMorfológicasbetaToolStripMenuItem.Size = New System.Drawing.Size(247, 22)
        Me.OperacionesMorfológicasbetaToolStripMenuItem.Text = "Operaciones morfológicas (beta)"
        '
        'MáscarasToolStripMenuItem
        '
        Me.MáscarasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PasoAltoToolStripMenuItem, Me.PasoBajoToolStripMenuItem, Me.BordesYContornosToolStripMenuItem, Me.MáscaraManualToolStripMenuItem, Me.SobelTotalToolStripMenuItem})
        Me.MáscarasToolStripMenuItem.Name = "MáscarasToolStripMenuItem"
        Me.MáscarasToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.MáscarasToolStripMenuItem.Text = "Máscaras"
        '
        'PasoAltoToolStripMenuItem
        '
        Me.PasoAltoToolStripMenuItem.Name = "PasoAltoToolStripMenuItem"
        Me.PasoAltoToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.PasoAltoToolStripMenuItem.Text = "Paso alto"
        '
        'PasoBajoToolStripMenuItem
        '
        Me.PasoBajoToolStripMenuItem.Name = "PasoBajoToolStripMenuItem"
        Me.PasoBajoToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.PasoBajoToolStripMenuItem.Text = "Paso bajo"
        '
        'BordesYContornosToolStripMenuItem
        '
        Me.BordesYContornosToolStripMenuItem.Name = "BordesYContornosToolStripMenuItem"
        Me.BordesYContornosToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.BordesYContornosToolStripMenuItem.Text = "Bordes y contornos"
        '
        'MáscaraManualToolStripMenuItem
        '
        Me.MáscaraManualToolStripMenuItem.Name = "MáscaraManualToolStripMenuItem"
        Me.MáscaraManualToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.MáscaraManualToolStripMenuItem.Text = "Máscara manual"
        '
        'SobelTotalToolStripMenuItem
        '
        Me.SobelTotalToolStripMenuItem.Name = "SobelTotalToolStripMenuItem"
        Me.SobelTotalToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.SobelTotalToolStripMenuItem.Text = "Sobel total"
        '
        'EfectosToolStripMenuItem
        '
        Me.EfectosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DesenfoqueToolStripMenuItem, Me.CuadrículaToolStripMenuItem, Me.SombraDeVidrioToolStripMenuItem, Me.SdaToolStripMenuItem, Me.RadmiToolStripMenuItem, Me.ÓleoToolStripMenuItem})
        Me.EfectosToolStripMenuItem.Name = "EfectosToolStripMenuItem"
        Me.EfectosToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.EfectosToolStripMenuItem.Text = "Efectos"
        '
        'DesenfoqueToolStripMenuItem
        '
        Me.DesenfoqueToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DesenfonqueDistorsiónToolStripMenuItem, Me.DesenfoqueMovimientoToolStripMenuItem, Me.DesenfoqueBLURToolStripMenuItem, Me.PixeladoToolStripMenuItem})
        Me.DesenfoqueToolStripMenuItem.Name = "DesenfoqueToolStripMenuItem"
        Me.DesenfoqueToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.DesenfoqueToolStripMenuItem.Text = "Desenfoque"
        '
        'DesenfonqueDistorsiónToolStripMenuItem
        '
        Me.DesenfonqueDistorsiónToolStripMenuItem.Name = "DesenfonqueDistorsiónToolStripMenuItem"
        Me.DesenfonqueDistorsiónToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.DesenfonqueDistorsiónToolStripMenuItem.Text = "Desenfonque distorsión"
        '
        'DesenfoqueMovimientoToolStripMenuItem
        '
        Me.DesenfoqueMovimientoToolStripMenuItem.Name = "DesenfoqueMovimientoToolStripMenuItem"
        Me.DesenfoqueMovimientoToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.DesenfoqueMovimientoToolStripMenuItem.Text = "Desenfoque movimiento"
        '
        'DesenfoqueBLURToolStripMenuItem
        '
        Me.DesenfoqueBLURToolStripMenuItem.Name = "DesenfoqueBLURToolStripMenuItem"
        Me.DesenfoqueBLURToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.DesenfoqueBLURToolStripMenuItem.Text = "Desenfoque (Blur)"
        '
        'PixeladoToolStripMenuItem
        '
        Me.PixeladoToolStripMenuItem.Name = "PixeladoToolStripMenuItem"
        Me.PixeladoToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.PixeladoToolStripMenuItem.Text = "Pixelado"
        '
        'CuadrículaToolStripMenuItem
        '
        Me.CuadrículaToolStripMenuItem.Name = "CuadrículaToolStripMenuItem"
        Me.CuadrículaToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.CuadrículaToolStripMenuItem.Text = "Cuadrícula"
        '
        'SombraDeVidrioToolStripMenuItem
        '
        Me.SombraDeVidrioToolStripMenuItem.Name = "SombraDeVidrioToolStripMenuItem"
        Me.SombraDeVidrioToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.SombraDeVidrioToolStripMenuItem.Text = "Sombra de vidrio"
        '
        'SdaToolStripMenuItem
        '
        Me.SdaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TresPartesToolStripMenuItem, Me.SeisPartesToolStripMenuItem})
        Me.SdaToolStripMenuItem.Name = "SdaToolStripMenuItem"
        Me.SdaToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.SdaToolStripMenuItem.Text = "Trocear imagen"
        '
        'TresPartesToolStripMenuItem
        '
        Me.TresPartesToolStripMenuItem.Name = "TresPartesToolStripMenuItem"
        Me.TresPartesToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.TresPartesToolStripMenuItem.Text = "Tres partes"
        '
        'SeisPartesToolStripMenuItem
        '
        Me.SeisPartesToolStripMenuItem.Name = "SeisPartesToolStripMenuItem"
        Me.SeisPartesToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.SeisPartesToolStripMenuItem.Text = "Seis partes"
        '
        'RadmiToolStripMenuItem
        '
        Me.RadmiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PonerLosDosToolStripMenuItem, Me.SadToolStripMenuItem})
        Me.RadmiToolStripMenuItem.Name = "RadmiToolStripMenuItem"
        Me.RadmiToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.RadmiToolStripMenuItem.Text = "Ruido"
        '
        'PonerLosDosToolStripMenuItem
        '
        Me.PonerLosDosToolStripMenuItem.Name = "PonerLosDosToolStripMenuItem"
        Me.PonerLosDosToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.PonerLosDosToolStripMenuItem.Text = "Ruido aleatorio"
        '
        'SadToolStripMenuItem
        '
        Me.SadToolStripMenuItem.Name = "SadToolStripMenuItem"
        Me.SadToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.SadToolStripMenuItem.Text = "Ruido desplazado"
        '
        'ÓleoToolStripMenuItem
        '
        Me.ÓleoToolStripMenuItem.Name = "ÓleoToolStripMenuItem"
        Me.ÓleoToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.ÓleoToolStripMenuItem.Text = "Óleo"
        '
        'OperacionesConDosImágenesToolStripMenuItem
        '
        Me.OperacionesConDosImágenesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SumaToolStripMenuItem, Me.OperacionesLógicasToolStripMenuItem1, Me.ComparadorDeImágenesToolStripMenuItem})
        Me.OperacionesConDosImágenesToolStripMenuItem.Name = "OperacionesConDosImágenesToolStripMenuItem"
        Me.OperacionesConDosImágenesToolStripMenuItem.Size = New System.Drawing.Size(184, 20)
        Me.OperacionesConDosImágenesToolStripMenuItem.Text = "Operaciones con dos imágenes"
        '
        'SumaToolStripMenuItem
        '
        Me.SumaToolStripMenuItem.Name = "SumaToolStripMenuItem"
        Me.SumaToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.SumaToolStripMenuItem.Text = "Operaciones aritméticas"
        '
        'OperacionesLógicasToolStripMenuItem1
        '
        Me.OperacionesLógicasToolStripMenuItem1.Name = "OperacionesLógicasToolStripMenuItem1"
        Me.OperacionesLógicasToolStripMenuItem1.Size = New System.Drawing.Size(211, 22)
        Me.OperacionesLógicasToolStripMenuItem1.Text = "Operaciones lógicas"
        '
        'ComparadorDeImágenesToolStripMenuItem
        '
        Me.ComparadorDeImágenesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LocalToolStripMenuItem, Me.VecinosToolStripMenuItem})
        Me.ComparadorDeImágenesToolStripMenuItem.Name = "ComparadorDeImágenesToolStripMenuItem"
        Me.ComparadorDeImágenesToolStripMenuItem.Size = New System.Drawing.Size(211, 22)
        Me.ComparadorDeImágenesToolStripMenuItem.Text = "Comparador de imágenes"
        '
        'LocalToolStripMenuItem
        '
        Me.LocalToolStripMenuItem.Name = "LocalToolStripMenuItem"
        Me.LocalToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.LocalToolStripMenuItem.Text = "Local"
        '
        'VecinosToolStripMenuItem
        '
        Me.VecinosToolStripMenuItem.Name = "VecinosToolStripMenuItem"
        Me.VecinosToolStripMenuItem.Size = New System.Drawing.Size(115, 22)
        Me.VecinosToolStripMenuItem.Text = "Vecinos"
        '
        'TransformacionesGeométricasToolStripMenuItem
        '
        Me.TransformacionesGeométricasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReflexiónToolStripMenuItem1, Me.TraslaciónToolStripMenuItem, Me.RotaciónToolStripMenuItem, Me.ErrorToolStripMenuItem, Me.TransformaciónAfínToolStripMenuItem})
        Me.TransformacionesGeométricasToolStripMenuItem.Name = "TransformacionesGeométricasToolStripMenuItem"
        Me.TransformacionesGeométricasToolStripMenuItem.Size = New System.Drawing.Size(182, 20)
        Me.TransformacionesGeométricasToolStripMenuItem.Text = "Transformaciones geométricas"
        '
        'ReflexiónToolStripMenuItem1
        '
        Me.ReflexiónToolStripMenuItem1.Name = "ReflexiónToolStripMenuItem1"
        Me.ReflexiónToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.ReflexiónToolStripMenuItem1.Text = "Reflexión"
        '
        'TraslaciónToolStripMenuItem
        '
        Me.TraslaciónToolStripMenuItem.Name = "TraslaciónToolStripMenuItem"
        Me.TraslaciónToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.TraslaciónToolStripMenuItem.Text = "Traslación"
        '
        'RotaciónToolStripMenuItem
        '
        Me.RotaciónToolStripMenuItem.Name = "RotaciónToolStripMenuItem"
        Me.RotaciónToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.RotaciónToolStripMenuItem.Text = "Rotación"
        '
        'ErrorToolStripMenuItem
        '
        Me.ErrorToolStripMenuItem.Name = "ErrorToolStripMenuItem"
        Me.ErrorToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.ErrorToolStripMenuItem.Text = "Error"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PictureBox2)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.SplitContainer1.Panel2MinSize = 165
        Me.SplitContainer1.Size = New System.Drawing.Size(1276, 668)
        Me.SplitContainer1.SplitterDistance = 1070
        Me.SplitContainer1.TabIndex = 28
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1068, 621)
        Me.Panel1.TabIndex = 3
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton8, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripSeparator2, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripButton7, Me.ToolStripButton9, Me.ToolStripSeparator3, Me.ToolStripSeparator4, Me.ToolStripButton10, Me.ToolStripButton11})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.ToolStrip1.Size = New System.Drawing.Size(1068, 45)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(1, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(199, 448)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Chart3)
        Me.TabPage1.Controls.Add(Me.Chart2)
        Me.TabPage1.Controls.Add(Me.Chart1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(191, 420)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Histogramas"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(30, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(147, 29)
        Me.Button2.TabIndex = 11
        Me.Button2.Text = "Ver histogramas reales"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(33, 384)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(147, 29)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Actualizar histograma"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Chart3
        '
        Me.Chart3.BackColor = System.Drawing.SystemColors.Control
        ChartArea1.Name = "ChartArea1"
        Me.Chart3.ChartAreas.Add(ChartArea1)
        Me.Chart3.Location = New System.Drawing.Point(4, 45)
        Me.Chart3.Name = "Chart3"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series1.IsVisibleInLegend = False
        Series1.Name = "Azul"
        Me.Chart3.Series.Add(Series1)
        Me.Chart3.Size = New System.Drawing.Size(173, 131)
        Me.Chart3.TabIndex = 9
        Me.Chart3.Text = "Histograma azul"
        '
        'Chart2
        '
        Me.Chart2.BackColor = System.Drawing.SystemColors.Control
        ChartArea2.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea2)
        Me.Chart2.Location = New System.Drawing.Point(4, 139)
        Me.Chart2.Name = "Chart2"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series2.IsVisibleInLegend = False
        Series2.Name = "Verde"
        Me.Chart2.Series.Add(Series2)
        Me.Chart2.Size = New System.Drawing.Size(173, 131)
        Me.Chart2.TabIndex = 8
        Me.Chart2.Text = "Histograma verde"
        '
        'Chart1
        '
        Me.Chart1.BackColor = System.Drawing.SystemColors.Control
        ChartArea3.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea3)
        Me.Chart1.Location = New System.Drawing.Point(4, 247)
        Me.Chart1.Name = "Chart1"
        Series3.ChartArea = "ChartArea1"
        Series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea
        Series3.IsVisibleInLegend = False
        Series3.Name = "Rojo"
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Size = New System.Drawing.Size(173, 131)
        Me.Chart1.TabIndex = 7
        Me.Chart1.Text = "Histograma rojo"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(191, 420)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Registro cambios"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(29, 497)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "-- Vista general --"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirImagenToolStripMenuItem3, Me.GuardarImagenToolStripMenuItem, Me.RefrescarToolStripMenuItem2, Me.ActualizarToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ArchivoToolStripMenuItem, Me.EdiciónToolStripMenuItem1, Me.OperacionesBásicasToolStripMenuItem, Me.OperacionesBásicasPersonalizadasToolStripMenuItem, Me.OperacionesToolStripMenuItem1, Me.MáscarasToolStripMenuItem1, Me.EfectosToolStripMenuItem1, Me.OperacionesConDosImágenesToolStripMenuItem1, Me.TransformacionesGeométricasToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(262, 296)
        '
        'AbrirImagenToolStripMenuItem3
        '
        Me.AbrirImagenToolStripMenuItem3.Name = "AbrirImagenToolStripMenuItem3"
        Me.AbrirImagenToolStripMenuItem3.Size = New System.Drawing.Size(261, 22)
        Me.AbrirImagenToolStripMenuItem3.Text = "Abrir imagen"
        '
        'GuardarImagenToolStripMenuItem
        '
        Me.GuardarImagenToolStripMenuItem.Name = "GuardarImagenToolStripMenuItem"
        Me.GuardarImagenToolStripMenuItem.Size = New System.Drawing.Size(261, 22)
        Me.GuardarImagenToolStripMenuItem.Text = "Guardar imagen"
        '
        'RefrescarToolStripMenuItem2
        '
        Me.RefrescarToolStripMenuItem2.Name = "RefrescarToolStripMenuItem2"
        Me.RefrescarToolStripMenuItem2.Size = New System.Drawing.Size(261, 22)
        Me.RefrescarToolStripMenuItem2.Text = "Refrescar"
        '
        'ActualizarToolStripMenuItem2
        '
        Me.ActualizarToolStripMenuItem2.Name = "ActualizarToolStripMenuItem2"
        Me.ActualizarToolStripMenuItem2.Size = New System.Drawing.Size(261, 22)
        Me.ActualizarToolStripMenuItem2.Text = "Actualizar"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(258, 6)
        '
        'ArchivoToolStripMenuItem
        '
        Me.ArchivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirImagenToolStripMenuItem2, Me.AbrirRecursoWebToolStripMenuItem, Me.BuscarImágenesEnLaWebToolStripMenuItem1, Me.BuscarImágenesEnFacebookToolStripMenuItem1, Me.CrearTapizToolStripMenuItem1})
        Me.ArchivoToolStripMenuItem.Name = "ArchivoToolStripMenuItem"
        Me.ArchivoToolStripMenuItem.Size = New System.Drawing.Size(261, 22)
        Me.ArchivoToolStripMenuItem.Text = "Archivo"
        '
        'AbrirImagenToolStripMenuItem2
        '
        Me.AbrirImagenToolStripMenuItem2.Name = "AbrirImagenToolStripMenuItem2"
        Me.AbrirImagenToolStripMenuItem2.Size = New System.Drawing.Size(233, 22)
        Me.AbrirImagenToolStripMenuItem2.Text = "Abrir imagen"
        '
        'AbrirRecursoWebToolStripMenuItem
        '
        Me.AbrirRecursoWebToolStripMenuItem.Name = "AbrirRecursoWebToolStripMenuItem"
        Me.AbrirRecursoWebToolStripMenuItem.Size = New System.Drawing.Size(233, 22)
        Me.AbrirRecursoWebToolStripMenuItem.Text = "Abrir recurso web"
        '
        'BuscarImágenesEnLaWebToolStripMenuItem1
        '
        Me.BuscarImágenesEnLaWebToolStripMenuItem1.Name = "BuscarImágenesEnLaWebToolStripMenuItem1"
        Me.BuscarImágenesEnLaWebToolStripMenuItem1.Size = New System.Drawing.Size(233, 22)
        Me.BuscarImágenesEnLaWebToolStripMenuItem1.Text = "Buscar imágenes en la web"
        '
        'BuscarImágenesEnFacebookToolStripMenuItem1
        '
        Me.BuscarImágenesEnFacebookToolStripMenuItem1.Name = "BuscarImágenesEnFacebookToolStripMenuItem1"
        Me.BuscarImágenesEnFacebookToolStripMenuItem1.Size = New System.Drawing.Size(233, 22)
        Me.BuscarImágenesEnFacebookToolStripMenuItem1.Text = "Buscar imágenes en Facebook"
        '
        'CrearTapizToolStripMenuItem1
        '
        Me.CrearTapizToolStripMenuItem1.Name = "CrearTapizToolStripMenuItem1"
        Me.CrearTapizToolStripMenuItem1.Size = New System.Drawing.Size(233, 22)
        Me.CrearTapizToolStripMenuItem1.Text = "Crear tapiz"
        '
        'EdiciónToolStripMenuItem1
        '
        Me.EdiciónToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeshacerToolStripMenuItem1, Me.RehacerToolStripMenuItem1, Me.RegistroDeCambiosToolStripMenuItem1, Me.ActualizarToolStripMenuItem1, Me.RefrescarToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ImagenOriginalToolStripMenuItem1})
        Me.EdiciónToolStripMenuItem1.Name = "EdiciónToolStripMenuItem1"
        Me.EdiciónToolStripMenuItem1.Size = New System.Drawing.Size(261, 22)
        Me.EdiciónToolStripMenuItem1.Text = "Edición"
        '
        'DeshacerToolStripMenuItem1
        '
        Me.DeshacerToolStripMenuItem1.Name = "DeshacerToolStripMenuItem1"
        Me.DeshacerToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.DeshacerToolStripMenuItem1.Text = "Deshacer"
        '
        'RehacerToolStripMenuItem1
        '
        Me.RehacerToolStripMenuItem1.Name = "RehacerToolStripMenuItem1"
        Me.RehacerToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.RehacerToolStripMenuItem1.Text = "Rehacer"
        '
        'RegistroDeCambiosToolStripMenuItem1
        '
        Me.RegistroDeCambiosToolStripMenuItem1.Name = "RegistroDeCambiosToolStripMenuItem1"
        Me.RegistroDeCambiosToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.RegistroDeCambiosToolStripMenuItem1.Text = "Registro de cambios"
        '
        'ActualizarToolStripMenuItem1
        '
        Me.ActualizarToolStripMenuItem1.Name = "ActualizarToolStripMenuItem1"
        Me.ActualizarToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.ActualizarToolStripMenuItem1.Text = "Actualizar"
        '
        'RefrescarToolStripMenuItem1
        '
        Me.RefrescarToolStripMenuItem1.Name = "RefrescarToolStripMenuItem1"
        Me.RefrescarToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.RefrescarToolStripMenuItem1.Text = "Refrescar"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(178, 6)
        '
        'ImagenOriginalToolStripMenuItem1
        '
        Me.ImagenOriginalToolStripMenuItem1.Name = "ImagenOriginalToolStripMenuItem1"
        Me.ImagenOriginalToolStripMenuItem1.Size = New System.Drawing.Size(181, 22)
        Me.ImagenOriginalToolStripMenuItem1.Text = "Imagen original"
        '
        'OperacionesBásicasToolStripMenuItem
        '
        Me.OperacionesBásicasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlancoYNegroToolStripMenuItem1, Me.EscalaDeGrisesToolStripMenuItem3, Me.InvertirColoresToolStripMenuItem1, Me.SepiaToolStripMenuItem1, Me.FiltrosBásicosToolStripMenuItem1, Me.RGBAToolStripMenuItem1, Me.ReflexiónToolStripMenuItem2})
        Me.OperacionesBásicasToolStripMenuItem.Name = "OperacionesBásicasToolStripMenuItem"
        Me.OperacionesBásicasToolStripMenuItem.Size = New System.Drawing.Size(261, 22)
        Me.OperacionesBásicasToolStripMenuItem.Text = "Operaciones básicas"
        '
        'BlancoYNegroToolStripMenuItem1
        '
        Me.BlancoYNegroToolStripMenuItem1.Name = "BlancoYNegroToolStripMenuItem1"
        Me.BlancoYNegroToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
        Me.BlancoYNegroToolStripMenuItem1.Text = "Blanco y negro"
        '
        'EscalaDeGrisesToolStripMenuItem3
        '
        Me.EscalaDeGrisesToolStripMenuItem3.Name = "EscalaDeGrisesToolStripMenuItem3"
        Me.EscalaDeGrisesToolStripMenuItem3.Size = New System.Drawing.Size(155, 22)
        Me.EscalaDeGrisesToolStripMenuItem3.Text = "Escala de grises"
        '
        'InvertirColoresToolStripMenuItem1
        '
        Me.InvertirColoresToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RGBToolStripMenuItem1, Me.RojoToolStripMenuItem1, Me.VerdeToolStripMenuItem1, Me.AzulToolStripMenuItem1})
        Me.InvertirColoresToolStripMenuItem1.Name = "InvertirColoresToolStripMenuItem1"
        Me.InvertirColoresToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
        Me.InvertirColoresToolStripMenuItem1.Text = "Invertir colores"
        '
        'RGBToolStripMenuItem1
        '
        Me.RGBToolStripMenuItem1.Name = "RGBToolStripMenuItem1"
        Me.RGBToolStripMenuItem1.Size = New System.Drawing.Size(104, 22)
        Me.RGBToolStripMenuItem1.Text = "RGB"
        '
        'RojoToolStripMenuItem1
        '
        Me.RojoToolStripMenuItem1.Name = "RojoToolStripMenuItem1"
        Me.RojoToolStripMenuItem1.Size = New System.Drawing.Size(104, 22)
        Me.RojoToolStripMenuItem1.Text = "Rojo"
        '
        'VerdeToolStripMenuItem1
        '
        Me.VerdeToolStripMenuItem1.Name = "VerdeToolStripMenuItem1"
        Me.VerdeToolStripMenuItem1.Size = New System.Drawing.Size(104, 22)
        Me.VerdeToolStripMenuItem1.Text = "Verde"
        '
        'AzulToolStripMenuItem1
        '
        Me.AzulToolStripMenuItem1.Name = "AzulToolStripMenuItem1"
        Me.AzulToolStripMenuItem1.Size = New System.Drawing.Size(104, 22)
        Me.AzulToolStripMenuItem1.Text = "Azul"
        '
        'SepiaToolStripMenuItem1
        '
        Me.SepiaToolStripMenuItem1.Name = "SepiaToolStripMenuItem1"
        Me.SepiaToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
        Me.SepiaToolStripMenuItem1.Text = "Sepia"
        '
        'FiltrosBásicosToolStripMenuItem1
        '
        Me.FiltrosBásicosToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FiltroRojoToolStripMenuItem1, Me.FiltroVerdeToolStripMenuItem1, Me.FiltroAzulToolStripMenuItem1})
        Me.FiltrosBásicosToolStripMenuItem1.Name = "FiltrosBásicosToolStripMenuItem1"
        Me.FiltrosBásicosToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
        Me.FiltrosBásicosToolStripMenuItem1.Text = "Filtros básicos"
        '
        'FiltroRojoToolStripMenuItem1
        '
        Me.FiltroRojoToolStripMenuItem1.Name = "FiltroRojoToolStripMenuItem1"
        Me.FiltroRojoToolStripMenuItem1.Size = New System.Drawing.Size(133, 22)
        Me.FiltroRojoToolStripMenuItem1.Text = "Filtro rojo"
        '
        'FiltroVerdeToolStripMenuItem1
        '
        Me.FiltroVerdeToolStripMenuItem1.Name = "FiltroVerdeToolStripMenuItem1"
        Me.FiltroVerdeToolStripMenuItem1.Size = New System.Drawing.Size(133, 22)
        Me.FiltroVerdeToolStripMenuItem1.Text = "Filtro verde"
        '
        'FiltroAzulToolStripMenuItem1
        '
        Me.FiltroAzulToolStripMenuItem1.Name = "FiltroAzulToolStripMenuItem1"
        Me.FiltroAzulToolStripMenuItem1.Size = New System.Drawing.Size(133, 22)
        Me.FiltroAzulToolStripMenuItem1.Text = "Filtro azul"
        '
        'RGBAToolStripMenuItem1
        '
        Me.RGBAToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BGRToolStripMenuItem1, Me.GRBToolStripMenuItem1, Me.RBGToolStripMenuItem1})
        Me.RGBAToolStripMenuItem1.Name = "RGBAToolStripMenuItem1"
        Me.RGBAToolStripMenuItem1.Size = New System.Drawing.Size(155, 22)
        Me.RGBAToolStripMenuItem1.Text = "RGB a..."
        '
        'BGRToolStripMenuItem1
        '
        Me.BGRToolStripMenuItem1.Name = "BGRToolStripMenuItem1"
        Me.BGRToolStripMenuItem1.Size = New System.Drawing.Size(96, 22)
        Me.BGRToolStripMenuItem1.Text = "BGR"
        '
        'GRBToolStripMenuItem1
        '
        Me.GRBToolStripMenuItem1.Name = "GRBToolStripMenuItem1"
        Me.GRBToolStripMenuItem1.Size = New System.Drawing.Size(96, 22)
        Me.GRBToolStripMenuItem1.Text = "GRB"
        '
        'RBGToolStripMenuItem1
        '
        Me.RBGToolStripMenuItem1.Name = "RBGToolStripMenuItem1"
        Me.RBGToolStripMenuItem1.Size = New System.Drawing.Size(96, 22)
        Me.RBGToolStripMenuItem1.Text = "RBG"
        '
        'ReflexiónToolStripMenuItem2
        '
        Me.ReflexiónToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HorizontalToolStripMenuItem1, Me.VerticalToolStripMenuItem1})
        Me.ReflexiónToolStripMenuItem2.Name = "ReflexiónToolStripMenuItem2"
        Me.ReflexiónToolStripMenuItem2.Size = New System.Drawing.Size(155, 22)
        Me.ReflexiónToolStripMenuItem2.Text = "Reflexión"
        '
        'HorizontalToolStripMenuItem1
        '
        Me.HorizontalToolStripMenuItem1.Name = "HorizontalToolStripMenuItem1"
        Me.HorizontalToolStripMenuItem1.Size = New System.Drawing.Size(129, 22)
        Me.HorizontalToolStripMenuItem1.Text = "Horizontal"
        '
        'VerticalToolStripMenuItem1
        '
        Me.VerticalToolStripMenuItem1.Name = "VerticalToolStripMenuItem1"
        Me.VerticalToolStripMenuItem1.Size = New System.Drawing.Size(129, 22)
        Me.VerticalToolStripMenuItem1.Text = "Vertical"
        '
        'OperacionesBásicasPersonalizadasToolStripMenuItem
        '
        Me.OperacionesBásicasPersonalizadasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlancoYNegroToolStripMenuItem2, Me.EscalaDeGrisesToolStripMenuItem4, Me.BrilloToolStripMenuItem, Me.ContrasteToolStripMenuItem1, Me.ExposiciónToolStripMenuItem, Me.ModificarCanalesToolStripMenuItem, Me.ReducirColoresToolStripMenuItem1, Me.FiltrarColoresToolStripMenuItem1, Me.MatrizToolStripMenuItem1, Me.DetectarContornosToolStripMenuItem1})
        Me.OperacionesBásicasPersonalizadasToolStripMenuItem.Name = "OperacionesBásicasPersonalizadasToolStripMenuItem"
        Me.OperacionesBásicasPersonalizadasToolStripMenuItem.Size = New System.Drawing.Size(261, 22)
        Me.OperacionesBásicasPersonalizadasToolStripMenuItem.Text = "Operaciones básicas personalizadas"
        '
        'BlancoYNegroToolStripMenuItem2
        '
        Me.BlancoYNegroToolStripMenuItem2.Name = "BlancoYNegroToolStripMenuItem2"
        Me.BlancoYNegroToolStripMenuItem2.Size = New System.Drawing.Size(175, 22)
        Me.BlancoYNegroToolStripMenuItem2.Text = "Blanco y negro"
        '
        'EscalaDeGrisesToolStripMenuItem4
        '
        Me.EscalaDeGrisesToolStripMenuItem4.Name = "EscalaDeGrisesToolStripMenuItem4"
        Me.EscalaDeGrisesToolStripMenuItem4.Size = New System.Drawing.Size(175, 22)
        Me.EscalaDeGrisesToolStripMenuItem4.Text = "Escala de grises"
        '
        'BrilloToolStripMenuItem
        '
        Me.BrilloToolStripMenuItem.Name = "BrilloToolStripMenuItem"
        Me.BrilloToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.BrilloToolStripMenuItem.Text = "Brillo"
        '
        'ContrasteToolStripMenuItem1
        '
        Me.ContrasteToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Contraste1recomendadoToolStripMenuItem, Me.Contraste2ToolStripMenuItem1})
        Me.ContrasteToolStripMenuItem1.Name = "ContrasteToolStripMenuItem1"
        Me.ContrasteToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.ContrasteToolStripMenuItem1.Text = "Contraste"
        '
        'Contraste1recomendadoToolStripMenuItem
        '
        Me.Contraste1recomendadoToolStripMenuItem.Name = "Contraste1recomendadoToolStripMenuItem"
        Me.Contraste1recomendadoToolStripMenuItem.Size = New System.Drawing.Size(219, 22)
        Me.Contraste1recomendadoToolStripMenuItem.Text = "Contraste 1 (recomendado)"
        '
        'Contraste2ToolStripMenuItem1
        '
        Me.Contraste2ToolStripMenuItem1.Name = "Contraste2ToolStripMenuItem1"
        Me.Contraste2ToolStripMenuItem1.Size = New System.Drawing.Size(219, 22)
        Me.Contraste2ToolStripMenuItem1.Text = "Contraste 2"
        '
        'ExposiciónToolStripMenuItem
        '
        Me.ExposiciónToolStripMenuItem.Name = "ExposiciónToolStripMenuItem"
        Me.ExposiciónToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.ExposiciónToolStripMenuItem.Text = "Exposición"
        '
        'ModificarCanalesToolStripMenuItem
        '
        Me.ModificarCanalesToolStripMenuItem.Name = "ModificarCanalesToolStripMenuItem"
        Me.ModificarCanalesToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.ModificarCanalesToolStripMenuItem.Text = "Modificar canales"
        '
        'ReducirColoresToolStripMenuItem1
        '
        Me.ReducirColoresToolStripMenuItem1.Name = "ReducirColoresToolStripMenuItem1"
        Me.ReducirColoresToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.ReducirColoresToolStripMenuItem1.Text = "Reducir colores"
        '
        'FiltrarColoresToolStripMenuItem1
        '
        Me.FiltrarColoresToolStripMenuItem1.Name = "FiltrarColoresToolStripMenuItem1"
        Me.FiltrarColoresToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.FiltrarColoresToolStripMenuItem1.Text = "Filtrar colores"
        '
        'MatrizToolStripMenuItem1
        '
        Me.MatrizToolStripMenuItem1.Name = "MatrizToolStripMenuItem1"
        Me.MatrizToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.MatrizToolStripMenuItem1.Text = "Matriz"
        '
        'DetectarContornosToolStripMenuItem1
        '
        Me.DetectarContornosToolStripMenuItem1.Name = "DetectarContornosToolStripMenuItem1"
        Me.DetectarContornosToolStripMenuItem1.Size = New System.Drawing.Size(175, 22)
        Me.DetectarContornosToolStripMenuItem1.Text = "Detectar contornos"
        '
        'OperacionesToolStripMenuItem1
        '
        Me.OperacionesToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperacionesAritméticasToolStripMenuItem1, Me.OperacionesLógicasToolStripMenuItem2, Me.OperacionesMorfológicasbetaToolStripMenuItem1})
        Me.OperacionesToolStripMenuItem1.Name = "OperacionesToolStripMenuItem1"
        Me.OperacionesToolStripMenuItem1.Size = New System.Drawing.Size(261, 22)
        Me.OperacionesToolStripMenuItem1.Text = "Operaciones"
        '
        'OperacionesAritméticasToolStripMenuItem1
        '
        Me.OperacionesAritméticasToolStripMenuItem1.Name = "OperacionesAritméticasToolStripMenuItem1"
        Me.OperacionesAritméticasToolStripMenuItem1.Size = New System.Drawing.Size(247, 22)
        Me.OperacionesAritméticasToolStripMenuItem1.Text = "Operaciones aritméticas"
        '
        'OperacionesLógicasToolStripMenuItem2
        '
        Me.OperacionesLógicasToolStripMenuItem2.Name = "OperacionesLógicasToolStripMenuItem2"
        Me.OperacionesLógicasToolStripMenuItem2.Size = New System.Drawing.Size(247, 22)
        Me.OperacionesLógicasToolStripMenuItem2.Text = "Operaciones lógicas"
        '
        'OperacionesMorfológicasbetaToolStripMenuItem1
        '
        Me.OperacionesMorfológicasbetaToolStripMenuItem1.Name = "OperacionesMorfológicasbetaToolStripMenuItem1"
        Me.OperacionesMorfológicasbetaToolStripMenuItem1.Size = New System.Drawing.Size(247, 22)
        Me.OperacionesMorfológicasbetaToolStripMenuItem1.Text = "Operaciones morfológicas (beta)"
        '
        'MáscarasToolStripMenuItem1
        '
        Me.MáscarasToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PasoAltoToolStripMenuItem1, Me.PasoBajoToolStripMenuItem1, Me.BordesYContornosToolStripMenuItem1, Me.MáscaraManualToolStripMenuItem1, Me.SobelTotalToolStripMenuItem1})
        Me.MáscarasToolStripMenuItem1.Name = "MáscarasToolStripMenuItem1"
        Me.MáscarasToolStripMenuItem1.Size = New System.Drawing.Size(261, 22)
        Me.MáscarasToolStripMenuItem1.Text = "Máscaras"
        '
        'PasoAltoToolStripMenuItem1
        '
        Me.PasoAltoToolStripMenuItem1.Name = "PasoAltoToolStripMenuItem1"
        Me.PasoAltoToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.PasoAltoToolStripMenuItem1.Text = "Paso alto"
        '
        'PasoBajoToolStripMenuItem1
        '
        Me.PasoBajoToolStripMenuItem1.Name = "PasoBajoToolStripMenuItem1"
        Me.PasoBajoToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.PasoBajoToolStripMenuItem1.Text = "Paso bajo"
        '
        'BordesYContornosToolStripMenuItem1
        '
        Me.BordesYContornosToolStripMenuItem1.Name = "BordesYContornosToolStripMenuItem1"
        Me.BordesYContornosToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.BordesYContornosToolStripMenuItem1.Text = "Bordes y contornos"
        '
        'MáscaraManualToolStripMenuItem1
        '
        Me.MáscaraManualToolStripMenuItem1.Name = "MáscaraManualToolStripMenuItem1"
        Me.MáscaraManualToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.MáscaraManualToolStripMenuItem1.Text = "Máscara manual"
        '
        'SobelTotalToolStripMenuItem1
        '
        Me.SobelTotalToolStripMenuItem1.Name = "SobelTotalToolStripMenuItem1"
        Me.SobelTotalToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.SobelTotalToolStripMenuItem1.Text = "Sobel total"
        '
        'EfectosToolStripMenuItem1
        '
        Me.EfectosToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DenfoqueToolStripMenuItem, Me.CuadrículaToolStripMenuItem1, Me.TrocearImagenToolStripMenuItem, Me.RuidoToolStripMenuItem})
        Me.EfectosToolStripMenuItem1.Name = "EfectosToolStripMenuItem1"
        Me.EfectosToolStripMenuItem1.Size = New System.Drawing.Size(261, 22)
        Me.EfectosToolStripMenuItem1.Text = "Efectos"
        '
        'DenfoqueToolStripMenuItem
        '
        Me.DenfoqueToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DenfoqueDistorsiónToolStripMenuItem, Me.DenfoqueMovimientoToolStripMenuItem, Me.DenfoqueBlurToolStripMenuItem, Me.PixeladoToolStripMenuItem1})
        Me.DenfoqueToolStripMenuItem.Name = "DenfoqueToolStripMenuItem"
        Me.DenfoqueToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.DenfoqueToolStripMenuItem.Text = "Denfoque"
        '
        'DenfoqueDistorsiónToolStripMenuItem
        '
        Me.DenfoqueDistorsiónToolStripMenuItem.Name = "DenfoqueDistorsiónToolStripMenuItem"
        Me.DenfoqueDistorsiónToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.DenfoqueDistorsiónToolStripMenuItem.Text = "Denfoque distorsión"
        '
        'DenfoqueMovimientoToolStripMenuItem
        '
        Me.DenfoqueMovimientoToolStripMenuItem.Name = "DenfoqueMovimientoToolStripMenuItem"
        Me.DenfoqueMovimientoToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.DenfoqueMovimientoToolStripMenuItem.Text = "Denfoque movimiento"
        '
        'DenfoqueBlurToolStripMenuItem
        '
        Me.DenfoqueBlurToolStripMenuItem.Name = "DenfoqueBlurToolStripMenuItem"
        Me.DenfoqueBlurToolStripMenuItem.Size = New System.Drawing.Size(194, 22)
        Me.DenfoqueBlurToolStripMenuItem.Text = "Denfoque (Blur)"
        '
        'PixeladoToolStripMenuItem1
        '
        Me.PixeladoToolStripMenuItem1.Name = "PixeladoToolStripMenuItem1"
        Me.PixeladoToolStripMenuItem1.Size = New System.Drawing.Size(194, 22)
        Me.PixeladoToolStripMenuItem1.Text = "Pixelado"
        '
        'CuadrículaToolStripMenuItem1
        '
        Me.CuadrículaToolStripMenuItem1.Name = "CuadrículaToolStripMenuItem1"
        Me.CuadrículaToolStripMenuItem1.Size = New System.Drawing.Size(157, 22)
        Me.CuadrículaToolStripMenuItem1.Text = "Cuadrícula"
        '
        'TrocearImagenToolStripMenuItem
        '
        Me.TrocearImagenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TresPartesToolStripMenuItem1, Me.SeisPartesToolStripMenuItem1})
        Me.TrocearImagenToolStripMenuItem.Name = "TrocearImagenToolStripMenuItem"
        Me.TrocearImagenToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.TrocearImagenToolStripMenuItem.Text = "Trocear imagen"
        '
        'TresPartesToolStripMenuItem1
        '
        Me.TresPartesToolStripMenuItem1.Name = "TresPartesToolStripMenuItem1"
        Me.TresPartesToolStripMenuItem1.Size = New System.Drawing.Size(131, 22)
        Me.TresPartesToolStripMenuItem1.Text = "Tres partes"
        '
        'SeisPartesToolStripMenuItem1
        '
        Me.SeisPartesToolStripMenuItem1.Name = "SeisPartesToolStripMenuItem1"
        Me.SeisPartesToolStripMenuItem1.Size = New System.Drawing.Size(131, 22)
        Me.SeisPartesToolStripMenuItem1.Text = "Seis partes"
        '
        'RuidoToolStripMenuItem
        '
        Me.RuidoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RuidoAleatorioToolStripMenuItem, Me.RuidoDesplazadoToolStripMenuItem})
        Me.RuidoToolStripMenuItem.Name = "RuidoToolStripMenuItem"
        Me.RuidoToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.RuidoToolStripMenuItem.Text = "Ruido"
        '
        'RuidoAleatorioToolStripMenuItem
        '
        Me.RuidoAleatorioToolStripMenuItem.Name = "RuidoAleatorioToolStripMenuItem"
        Me.RuidoAleatorioToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.RuidoAleatorioToolStripMenuItem.Text = "Ruido aleatorio"
        '
        'RuidoDesplazadoToolStripMenuItem
        '
        Me.RuidoDesplazadoToolStripMenuItem.Name = "RuidoDesplazadoToolStripMenuItem"
        Me.RuidoDesplazadoToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.RuidoDesplazadoToolStripMenuItem.Text = "Ruido desplazado"
        '
        'OperacionesConDosImágenesToolStripMenuItem1
        '
        Me.OperacionesConDosImágenesToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperacionesAritméticasToolStripMenuItem2, Me.OperacionesLógicasToolStripMenuItem3})
        Me.OperacionesConDosImágenesToolStripMenuItem1.Name = "OperacionesConDosImágenesToolStripMenuItem1"
        Me.OperacionesConDosImágenesToolStripMenuItem1.Size = New System.Drawing.Size(261, 22)
        Me.OperacionesConDosImágenesToolStripMenuItem1.Text = "Operaciones con dos imágenes"
        '
        'OperacionesAritméticasToolStripMenuItem2
        '
        Me.OperacionesAritméticasToolStripMenuItem2.Name = "OperacionesAritméticasToolStripMenuItem2"
        Me.OperacionesAritméticasToolStripMenuItem2.Size = New System.Drawing.Size(201, 22)
        Me.OperacionesAritméticasToolStripMenuItem2.Text = "Operaciones aritméticas"
        '
        'OperacionesLógicasToolStripMenuItem3
        '
        Me.OperacionesLógicasToolStripMenuItem3.Name = "OperacionesLógicasToolStripMenuItem3"
        Me.OperacionesLógicasToolStripMenuItem3.Size = New System.Drawing.Size(201, 22)
        Me.OperacionesLógicasToolStripMenuItem3.Text = "Operaciones lógicas"
        '
        'TransformacionesGeométricasToolStripMenuItem1
        '
        Me.TransformacionesGeométricasToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReflexiónToolStripMenuItem3, Me.TraslaciónToolStripMenuItem1, Me.RotaciónToolStripMenuItem1})
        Me.TransformacionesGeométricasToolStripMenuItem1.Name = "TransformacionesGeométricasToolStripMenuItem1"
        Me.TransformacionesGeométricasToolStripMenuItem1.Size = New System.Drawing.Size(261, 22)
        Me.TransformacionesGeométricasToolStripMenuItem1.Text = "Transformaciones geométricas"
        '
        'ReflexiónToolStripMenuItem3
        '
        Me.ReflexiónToolStripMenuItem3.Name = "ReflexiónToolStripMenuItem3"
        Me.ReflexiónToolStripMenuItem3.Size = New System.Drawing.Size(128, 22)
        Me.ReflexiónToolStripMenuItem3.Text = "Reflexión"
        '
        'TraslaciónToolStripMenuItem1
        '
        Me.TraslaciónToolStripMenuItem1.Name = "TraslaciónToolStripMenuItem1"
        Me.TraslaciónToolStripMenuItem1.Size = New System.Drawing.Size(128, 22)
        Me.TraslaciónToolStripMenuItem1.Text = "Traslación"
        '
        'RotaciónToolStripMenuItem1
        '
        Me.RotaciónToolStripMenuItem1.Name = "RotaciónToolStripMenuItem1"
        Me.RotaciónToolStripMenuItem1.Size = New System.Drawing.Size(128, 22)
        Me.RotaciónToolStripMenuItem1.Text = "Rotación"
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'TransformaciónAfínToolStripMenuItem
        '
        Me.TransformaciónAfínToolStripMenuItem.Name = "TransformaciónAfínToolStripMenuItem"
        Me.TransformaciónAfínToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.TransformaciónAfínToolStripMenuItem.Text = "Transformación afín"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NotificarUnErrorToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'NotificarUnErrorToolStripMenuItem
        '
        Me.NotificarUnErrorToolStripMenuItem.Name = "NotificarUnErrorToolStripMenuItem"
        Me.NotificarUnErrorToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.NotificarUnErrorToolStripMenuItem.Text = "Notificar un error"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.ClaseImagenes.My.Resources.Resources.remastered_lena_512x512
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Padding = New System.Windows.Forms.Padding(5)
        Me.PictureBox1.Size = New System.Drawing.Size(1066, 619)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.ClaseImagenes.My.Resources.Resources.image_add
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton1.Text = "Abrir imagen"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.ClaseImagenes.My.Resources.Resources.image_link
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton2.Text = "Abrir recurso web"
        '
        'ToolStripButton8
        '
        Me.ToolStripButton8.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton8.Image = Global.ClaseImagenes.My.Resources.Resources.picture_save
        Me.ToolStripButton8.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton8.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton8.Name = "ToolStripButton8"
        Me.ToolStripButton8.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton8.Text = "Guardar como"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.ClaseImagenes.My.Resources.Resources.BingIcono
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton3.Text = "Abrir desde Bing"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = Global.ClaseImagenes.My.Resources.Resources.facebook
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton4.Text = "Abrir desde Facebook"
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton5.Image = Global.ClaseImagenes.My.Resources.Resources.arrow_undo
        Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton5.Text = "Deshacer"
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton6.Image = Global.ClaseImagenes.My.Resources.Resources.arrow_redo
        Me.ToolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton6.Text = "Rehacer"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton7.Image = Global.ClaseImagenes.My.Resources.Resources.arrow_refresh
        Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton7.Text = "Refrescar"
        '
        'ToolStripButton9
        '
        Me.ToolStripButton9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton9.Image = Global.ClaseImagenes.My.Resources.Resources.system_software_update
        Me.ToolStripButton9.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton9.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton9.Name = "ToolStripButton9"
        Me.ToolStripButton9.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton9.Text = "Actualizar"
        '
        'ToolStripButton10
        '
        Me.ToolStripButton10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton10.Image = Global.ClaseImagenes.My.Resources.Resources.LENAblanconegro
        Me.ToolStripButton10.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton10.Name = "ToolStripButton10"
        Me.ToolStripButton10.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton10.Text = "Blanco y negro"
        '
        'ToolStripButton11
        '
        Me.ToolStripButton11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton11.Image = Global.ClaseImagenes.My.Resources.Resources.lenagrises1
        Me.ToolStripButton11.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton11.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton11.Name = "ToolStripButton11"
        Me.ToolStripButton11.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton11.Text = "Escala de grises"
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Image = Global.ClaseImagenes.My.Resources.Resources.remastered_lena_512x512
        Me.PictureBox2.Location = New System.Drawing.Point(2, 514)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(150, 150)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1276, 716)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Apolo thread"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents BarraEstado As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents PorcentajeActual As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents EstadoActual As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImagenActual As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents AbrirImagenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirImagenToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CargarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarImágenesEnLaWebToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EdiciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeshacerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RehacerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefrescarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesBásicosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EscalaDeGrisesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EscalaDeGrisesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertirColoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RGBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RojoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerdeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AzulToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SepiaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiltrosBásicosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiltroRojoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiltroVerdeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiltroAzulToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RGBAToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BGRToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GRBToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RBGToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesBásicosPersonalizadasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlancoYNegroToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BrilloToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExposiciónToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarCanalesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents RegistroDeCambiosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EscalaDeGrisesToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReducirColoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiltrarColoresToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MáscarasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasoAltoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasoBajoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BordesYContornosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarImágenesEnFacebookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MáscaraManualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatrizToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SobelTotalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EfectosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CuadrículaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearTapizToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReflexiónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SombraDeVidrioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SdaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TresPartesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeisPartesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RadmiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesenfoqueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesenfoqueMovimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesenfonqueDistorsiónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesenfoqueBLURToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PonerLosDosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PixeladoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ImagenOriginalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesConDosImágenesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SumaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransformacionesGeométricasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReflexiónToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TraslaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RotaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContrasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Contraste1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Contraste2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetectarContornosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesAritméticasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesLógicasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesLógicasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesMorfológicasbetaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActualizarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ArchivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirImagenToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirRecursoWebToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarImágenesEnLaWebToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BuscarImágenesEnFacebookToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearTapizToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EdiciónToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeshacerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RehacerToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RegistroDeCambiosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActualizarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefrescarToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents OperacionesBásicasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesBásicasPersonalizadasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MáscarasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EfectosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesConDosImágenesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransformacionesGeométricasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImagenOriginalToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AbrirImagenToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarImagenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefrescarToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActualizarToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BlancoYNegroToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EscalaDeGrisesToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InvertirColoresToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RGBToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RojoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerdeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AzulToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SepiaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiltrosBásicosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiltroRojoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiltroVerdeToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiltroAzulToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RGBAToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BGRToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GRBToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RBGToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReflexiónToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HorizontalToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerticalToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BlancoYNegroToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EscalaDeGrisesToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BrilloToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContrasteToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Contraste1recomendadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Contraste2ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExposiciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModificarCanalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReducirColoresToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FiltrarColoresToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatrizToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetectarContornosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesAritméticasToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesLógicasToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesMorfológicasbetaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasoAltoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasoBajoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BordesYContornosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MáscaraManualToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SobelTotalToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DenfoqueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DenfoqueDistorsiónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DenfoqueMovimientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DenfoqueBlurToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PixeladoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CuadrículaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TrocearImagenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TresPartesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SeisPartesToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RuidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RuidoAleatorioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RuidoDesplazadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesAritméticasToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesLógicasToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReflexiónToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TraslaciónToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RotaciónToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GuardarComoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton11 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Chart3 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents ComparadorDeImágenesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LocalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VecinosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ÓleoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ErrorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HistogramasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetalladoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TodosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransformaciónAfínToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotificarUnErrorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
