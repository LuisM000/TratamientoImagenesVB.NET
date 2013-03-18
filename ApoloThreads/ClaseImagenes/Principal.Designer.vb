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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Principal))
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea3 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
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
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripSeparator()
        Me.AbrirCompiladorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem9 = New System.Windows.Forms.ToolStripSeparator()
        Me.CompartirImagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GggToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EdiciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeshacerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RehacerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImagenOriginalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ZoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZoomInteractivoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmpezarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PropiedadesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeshacerZoomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AjustarAPantallaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem10 = New System.Windows.Forms.ToolStripSeparator()
        Me.RegistroDeCambiosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefrescarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripSeparator()
        Me.CapturaDePantallaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopiarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PegarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem11 = New System.Windows.Forms.ToolStripSeparator()
        Me.PropiedadesDeLaImagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripSeparator()
        Me.HistogramasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DetalladoToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TodosToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripSeparator()
        Me.RedimensionarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlancoYNegroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EscalaDeGrisesToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BrilloToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContrasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Contraste1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Contraste2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GamaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.OperacionesGeométricasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReflexiónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TraslaciónToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VolteadosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripSeparator()
        Me.TransformaciónAfínToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualsesgarImagenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PersonalizadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OtrasOperacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DensitySlicingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AutomáticoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.CombinacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EfectoMarteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EfectoAntiguoSobreexpuestoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EfectoMarinoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AumentarRasgosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DisminuirRasgosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContornoSombreadoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContenidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesmedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColorearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesConDosImágenesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SumaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OperacionesLógicasToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnaglifoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComparadorDeImágenesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LocalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VecinosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloudToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarImágenesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccesoCarpetaPrivadaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HerramientasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistogramasAutomáticosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiberarMemoriaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarraAccesosRápidosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ActualizacionesAutomáticasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaEnLaWebToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NotificarUnErrorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyúdanosAMejorarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColaboraConElProyectoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComprobarActualizacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton8 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton9 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton13 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton18 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton11 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton12 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton14 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton15 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton17 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton16 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton19 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton21 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton20 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton22 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton23 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton24 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton25 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton26 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton27 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton28 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton29 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton30 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton31 = New System.Windows.Forms.ToolStripButton()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Chart3 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.NumTamanoPuntero = New System.Windows.Forms.NumericUpDown()
        Me.NumVentana = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.chbPuntero = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.NumZoom = New System.Windows.Forms.NumericUpDown()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
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
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ImagenActual = New System.Windows.Forms.ToolStripStatusLabel()
        Me.barraestado = New System.Windows.Forms.ToolStripProgressBar()
        Me.PorcentajeActual = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Estadoactual = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.MilímetrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CentímetrosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PulgadasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PíxelesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusImagen = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusColor = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorkerACTUALIZACION = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorkerACtual_Automaticas = New System.ComponentModel.BackgroundWorker()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.NumTamanoPuntero, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumVentana, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 50
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
        Me.AbrirImagenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirImagenToolStripMenuItem1, Me.CargarToolStripMenuItem, Me.BuscarImágenesEnLaWebToolStripMenuItem, Me.BuscarImágenesEnFacebookToolStripMenuItem, Me.CrearTapizToolStripMenuItem, Me.ToolStripMenuItem4, Me.GuardarComoToolStripMenuItem, Me.ToolStripMenuItem6, Me.AbrirCompiladorToolStripMenuItem, Me.ToolStripMenuItem9, Me.CompartirImagenToolStripMenuItem, Me.GggToolStripMenuItem})
        Me.AbrirImagenToolStripMenuItem.Name = "AbrirImagenToolStripMenuItem"
        Me.AbrirImagenToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.AbrirImagenToolStripMenuItem.Text = "Archivo"
        '
        'AbrirImagenToolStripMenuItem1
        '
        Me.AbrirImagenToolStripMenuItem1.Name = "AbrirImagenToolStripMenuItem1"
        Me.AbrirImagenToolStripMenuItem1.Size = New System.Drawing.Size(229, 22)
        Me.AbrirImagenToolStripMenuItem1.Text = "Abrir imagen"
        '
        'CargarToolStripMenuItem
        '
        Me.CargarToolStripMenuItem.Name = "CargarToolStripMenuItem"
        Me.CargarToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.CargarToolStripMenuItem.Text = "Abrir recurso web"
        '
        'BuscarImágenesEnLaWebToolStripMenuItem
        '
        Me.BuscarImágenesEnLaWebToolStripMenuItem.Name = "BuscarImágenesEnLaWebToolStripMenuItem"
        Me.BuscarImágenesEnLaWebToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.BuscarImágenesEnLaWebToolStripMenuItem.Text = "Buscar imágenes en la web"
        '
        'BuscarImágenesEnFacebookToolStripMenuItem
        '
        Me.BuscarImágenesEnFacebookToolStripMenuItem.Name = "BuscarImágenesEnFacebookToolStripMenuItem"
        Me.BuscarImágenesEnFacebookToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.BuscarImágenesEnFacebookToolStripMenuItem.Text = "Buscar imágenes en Facebook"
        '
        'CrearTapizToolStripMenuItem
        '
        Me.CrearTapizToolStripMenuItem.Name = "CrearTapizToolStripMenuItem"
        Me.CrearTapizToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.CrearTapizToolStripMenuItem.Text = "Crear tapiz"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(226, 6)
        '
        'GuardarComoToolStripMenuItem
        '
        Me.GuardarComoToolStripMenuItem.Name = "GuardarComoToolStripMenuItem"
        Me.GuardarComoToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.GuardarComoToolStripMenuItem.Text = "Guardar como..."
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(226, 6)
        '
        'AbrirCompiladorToolStripMenuItem
        '
        Me.AbrirCompiladorToolStripMenuItem.Name = "AbrirCompiladorToolStripMenuItem"
        Me.AbrirCompiladorToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.AbrirCompiladorToolStripMenuItem.Text = "Abrir compilador"
        '
        'ToolStripMenuItem9
        '
        Me.ToolStripMenuItem9.Name = "ToolStripMenuItem9"
        Me.ToolStripMenuItem9.Size = New System.Drawing.Size(226, 6)
        '
        'CompartirImagenToolStripMenuItem
        '
        Me.CompartirImagenToolStripMenuItem.Name = "CompartirImagenToolStripMenuItem"
        Me.CompartirImagenToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.CompartirImagenToolStripMenuItem.Text = "Compartir imagen"
        '
        'GggToolStripMenuItem
        '
        Me.GggToolStripMenuItem.Name = "GggToolStripMenuItem"
        Me.GggToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.GggToolStripMenuItem.Text = "ggg"
        '
        'EdiciónToolStripMenuItem
        '
        Me.EdiciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeshacerToolStripMenuItem, Me.RehacerToolStripMenuItem, Me.ImagenOriginalToolStripMenuItem, Me.ToolStripMenuItem1, Me.ZoomToolStripMenuItem, Me.ZoomToolStripMenuItem1, Me.ZoomInteractivoToolStripMenuItem, Me.DeshacerZoomToolStripMenuItem, Me.AjustarAPantallaToolStripMenuItem, Me.ToolStripMenuItem10, Me.RegistroDeCambiosToolStripMenuItem, Me.ActualizarToolStripMenuItem, Me.RefrescarToolStripMenuItem, Me.ToolStripMenuItem7, Me.CapturaDePantallaToolStripMenuItem, Me.CopiarToolStripMenuItem, Me.PegarToolStripMenuItem, Me.ToolStripMenuItem11, Me.PropiedadesDeLaImagenToolStripMenuItem})
        Me.EdiciónToolStripMenuItem.Name = "EdiciónToolStripMenuItem"
        Me.EdiciónToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.EdiciónToolStripMenuItem.Text = "Edición"
        '
        'DeshacerToolStripMenuItem
        '
        Me.DeshacerToolStripMenuItem.Name = "DeshacerToolStripMenuItem"
        Me.DeshacerToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.DeshacerToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.DeshacerToolStripMenuItem.Text = "Deshacer"
        '
        'RehacerToolStripMenuItem
        '
        Me.RehacerToolStripMenuItem.Name = "RehacerToolStripMenuItem"
        Me.RehacerToolStripMenuItem.ShortcutKeyDisplayString = ""
        Me.RehacerToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.RehacerToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.RehacerToolStripMenuItem.Text = "Rehacer"
        '
        'ImagenOriginalToolStripMenuItem
        '
        Me.ImagenOriginalToolStripMenuItem.Name = "ImagenOriginalToolStripMenuItem"
        Me.ImagenOriginalToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ImagenOriginalToolStripMenuItem.Text = "Imagen original"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(204, 6)
        '
        'ZoomToolStripMenuItem
        '
        Me.ZoomToolStripMenuItem.Name = "ZoomToolStripMenuItem"
        Me.ZoomToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.M), System.Windows.Forms.Keys)
        Me.ZoomToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ZoomToolStripMenuItem.Text = "Zoom +"
        '
        'ZoomToolStripMenuItem1
        '
        Me.ZoomToolStripMenuItem1.Name = "ZoomToolStripMenuItem1"
        Me.ZoomToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys)
        Me.ZoomToolStripMenuItem1.Size = New System.Drawing.Size(207, 22)
        Me.ZoomToolStripMenuItem1.Text = "Zoom -"
        '
        'ZoomInteractivoToolStripMenuItem
        '
        Me.ZoomInteractivoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EmpezarToolStripMenuItem, Me.PropiedadesToolStripMenuItem})
        Me.ZoomInteractivoToolStripMenuItem.Name = "ZoomInteractivoToolStripMenuItem"
        Me.ZoomInteractivoToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ZoomInteractivoToolStripMenuItem.Text = "Zoom interactivo"
        '
        'EmpezarToolStripMenuItem
        '
        Me.EmpezarToolStripMenuItem.Name = "EmpezarToolStripMenuItem"
        Me.EmpezarToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.EmpezarToolStripMenuItem.Text = "Empezar"
        '
        'PropiedadesToolStripMenuItem
        '
        Me.PropiedadesToolStripMenuItem.Name = "PropiedadesToolStripMenuItem"
        Me.PropiedadesToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.PropiedadesToolStripMenuItem.Text = "Propiedades"
        '
        'DeshacerZoomToolStripMenuItem
        '
        Me.DeshacerZoomToolStripMenuItem.Name = "DeshacerZoomToolStripMenuItem"
        Me.DeshacerZoomToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D0), System.Windows.Forms.Keys)
        Me.DeshacerZoomToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.DeshacerZoomToolStripMenuItem.Text = "Deshacer zoom"
        '
        'AjustarAPantallaToolStripMenuItem
        '
        Me.AjustarAPantallaToolStripMenuItem.Name = "AjustarAPantallaToolStripMenuItem"
        Me.AjustarAPantallaToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.AjustarAPantallaToolStripMenuItem.Text = "Ajustar a pantalla"
        '
        'ToolStripMenuItem10
        '
        Me.ToolStripMenuItem10.Name = "ToolStripMenuItem10"
        Me.ToolStripMenuItem10.Size = New System.Drawing.Size(204, 6)
        '
        'RegistroDeCambiosToolStripMenuItem
        '
        Me.RegistroDeCambiosToolStripMenuItem.Name = "RegistroDeCambiosToolStripMenuItem"
        Me.RegistroDeCambiosToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.RegistroDeCambiosToolStripMenuItem.Text = "Registro de cambios"
        '
        'ActualizarToolStripMenuItem
        '
        Me.ActualizarToolStripMenuItem.Name = "ActualizarToolStripMenuItem"
        Me.ActualizarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.ActualizarToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.ActualizarToolStripMenuItem.Text = "Actualizar"
        '
        'RefrescarToolStripMenuItem
        '
        Me.RefrescarToolStripMenuItem.Name = "RefrescarToolStripMenuItem"
        Me.RefrescarToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.RefrescarToolStripMenuItem.Text = "Refrescar"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(204, 6)
        '
        'CapturaDePantallaToolStripMenuItem
        '
        Me.CapturaDePantallaToolStripMenuItem.Name = "CapturaDePantallaToolStripMenuItem"
        Me.CapturaDePantallaToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.CapturaDePantallaToolStripMenuItem.Text = "Captura de pantalla"
        '
        'CopiarToolStripMenuItem
        '
        Me.CopiarToolStripMenuItem.Name = "CopiarToolStripMenuItem"
        Me.CopiarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.CopiarToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.CopiarToolStripMenuItem.Text = "Copiar"
        '
        'PegarToolStripMenuItem
        '
        Me.PegarToolStripMenuItem.Name = "PegarToolStripMenuItem"
        Me.PegarToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.PegarToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.PegarToolStripMenuItem.Text = "Pegar"
        '
        'ToolStripMenuItem11
        '
        Me.ToolStripMenuItem11.Name = "ToolStripMenuItem11"
        Me.ToolStripMenuItem11.Size = New System.Drawing.Size(204, 6)
        '
        'PropiedadesDeLaImagenToolStripMenuItem
        '
        Me.PropiedadesDeLaImagenToolStripMenuItem.Name = "PropiedadesDeLaImagenToolStripMenuItem"
        Me.PropiedadesDeLaImagenToolStripMenuItem.Size = New System.Drawing.Size(207, 22)
        Me.PropiedadesDeLaImagenToolStripMenuItem.Text = "Propiedades de la imagen"
        '
        'OperacionesBásicosToolStripMenuItem
        '
        Me.OperacionesBásicosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EscalaDeGrisesToolStripMenuItem, Me.EscalaDeGrisesToolStripMenuItem1, Me.InvertirColoresToolStripMenuItem, Me.SepiaToolStripMenuItem, Me.FiltrosBásicosToolStripMenuItem, Me.RGBAToolStripMenuItem, Me.ToolStripMenuItem5, Me.HistogramasToolStripMenuItem, Me.ToolStripMenuItem8, Me.RedimensionarToolStripMenuItem})
        Me.OperacionesBásicosToolStripMenuItem.Name = "OperacionesBásicosToolStripMenuItem"
        Me.OperacionesBásicosToolStripMenuItem.Size = New System.Drawing.Size(125, 20)
        Me.OperacionesBásicosToolStripMenuItem.Text = "Operaciones básicos"
        '
        'EscalaDeGrisesToolStripMenuItem
        '
        Me.EscalaDeGrisesToolStripMenuItem.Name = "EscalaDeGrisesToolStripMenuItem"
        Me.EscalaDeGrisesToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.EscalaDeGrisesToolStripMenuItem.Text = "Blanco y negro"
        '
        'EscalaDeGrisesToolStripMenuItem1
        '
        Me.EscalaDeGrisesToolStripMenuItem1.Name = "EscalaDeGrisesToolStripMenuItem1"
        Me.EscalaDeGrisesToolStripMenuItem1.Size = New System.Drawing.Size(154, 22)
        Me.EscalaDeGrisesToolStripMenuItem1.Text = "Escala de grises"
        '
        'InvertirColoresToolStripMenuItem
        '
        Me.InvertirColoresToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RGBToolStripMenuItem, Me.RojoToolStripMenuItem, Me.VerdeToolStripMenuItem, Me.AzulToolStripMenuItem})
        Me.InvertirColoresToolStripMenuItem.Name = "InvertirColoresToolStripMenuItem"
        Me.InvertirColoresToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
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
        Me.SepiaToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.SepiaToolStripMenuItem.Text = "Sepia"
        '
        'FiltrosBásicosToolStripMenuItem
        '
        Me.FiltrosBásicosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FiltroRojoToolStripMenuItem, Me.FiltroVerdeToolStripMenuItem, Me.FiltroAzulToolStripMenuItem})
        Me.FiltrosBásicosToolStripMenuItem.Name = "FiltrosBásicosToolStripMenuItem"
        Me.FiltrosBásicosToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.FiltrosBásicosToolStripMenuItem.Text = "Filtros básicos"
        '
        'FiltroRojoToolStripMenuItem
        '
        Me.FiltroRojoToolStripMenuItem.Name = "FiltroRojoToolStripMenuItem"
        Me.FiltroRojoToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.FiltroRojoToolStripMenuItem.Text = "Filtro rojo"
        '
        'FiltroVerdeToolStripMenuItem
        '
        Me.FiltroVerdeToolStripMenuItem.Name = "FiltroVerdeToolStripMenuItem"
        Me.FiltroVerdeToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.FiltroVerdeToolStripMenuItem.Text = "Filtro verde"
        '
        'FiltroAzulToolStripMenuItem
        '
        Me.FiltroAzulToolStripMenuItem.Name = "FiltroAzulToolStripMenuItem"
        Me.FiltroAzulToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.FiltroAzulToolStripMenuItem.Text = "Filtro azul"
        '
        'RGBAToolStripMenuItem
        '
        Me.RGBAToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BGRToolStripMenuItem, Me.GRBToolStripMenuItem, Me.RBGToolStripMenuItem})
        Me.RGBAToolStripMenuItem.Name = "RGBAToolStripMenuItem"
        Me.RGBAToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
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
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(151, 6)
        '
        'HistogramasToolStripMenuItem
        '
        Me.HistogramasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetalladoToolStripMenuItem1, Me.TodosToolStripMenuItem1})
        Me.HistogramasToolStripMenuItem.Name = "HistogramasToolStripMenuItem"
        Me.HistogramasToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
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
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        Me.ToolStripMenuItem8.Size = New System.Drawing.Size(151, 6)
        '
        'RedimensionarToolStripMenuItem
        '
        Me.RedimensionarToolStripMenuItem.Name = "RedimensionarToolStripMenuItem"
        Me.RedimensionarToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.RedimensionarToolStripMenuItem.Text = "Redimensionar"
        '
        'OperacionesBásicosPersonalizadasToolStripMenuItem
        '
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlancoYNegroToolStripMenuItem, Me.EscalaDeGrisesToolStripMenuItem2, Me.BrilloToolStripMenuItem1, Me.ContrasteToolStripMenuItem, Me.GamaToolStripMenuItem, Me.ExposiciónToolStripMenuItem1, Me.ModificarCanalesToolStripMenuItem1, Me.ReducirColoresToolStripMenuItem, Me.FiltrarColoresToolStripMenuItem, Me.MatrizToolStripMenuItem, Me.DetectarContornosToolStripMenuItem})
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem.Name = "OperacionesBásicosPersonalizadasToolStripMenuItem"
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem.Size = New System.Drawing.Size(205, 20)
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem.Text = "Operaciones básicos personalizadas"
        '
        'BlancoYNegroToolStripMenuItem
        '
        Me.BlancoYNegroToolStripMenuItem.Name = "BlancoYNegroToolStripMenuItem"
        Me.BlancoYNegroToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.BlancoYNegroToolStripMenuItem.Text = "Blanco y negro"
        '
        'EscalaDeGrisesToolStripMenuItem2
        '
        Me.EscalaDeGrisesToolStripMenuItem2.Name = "EscalaDeGrisesToolStripMenuItem2"
        Me.EscalaDeGrisesToolStripMenuItem2.Size = New System.Drawing.Size(185, 22)
        Me.EscalaDeGrisesToolStripMenuItem2.Text = "Escala de grises"
        '
        'BrilloToolStripMenuItem1
        '
        Me.BrilloToolStripMenuItem1.Name = "BrilloToolStripMenuItem1"
        Me.BrilloToolStripMenuItem1.Size = New System.Drawing.Size(185, 22)
        Me.BrilloToolStripMenuItem1.Text = "Brillo"
        '
        'ContrasteToolStripMenuItem
        '
        Me.ContrasteToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Contraste1ToolStripMenuItem, Me.Contraste2ToolStripMenuItem})
        Me.ContrasteToolStripMenuItem.Name = "ContrasteToolStripMenuItem"
        Me.ContrasteToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ContrasteToolStripMenuItem.Text = "Contraste"
        '
        'Contraste1ToolStripMenuItem
        '
        Me.Contraste1ToolStripMenuItem.Name = "Contraste1ToolStripMenuItem"
        Me.Contraste1ToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.Contraste1ToolStripMenuItem.Text = "Contraste 1 (recomendado)"
        '
        'Contraste2ToolStripMenuItem
        '
        Me.Contraste2ToolStripMenuItem.Name = "Contraste2ToolStripMenuItem"
        Me.Contraste2ToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.Contraste2ToolStripMenuItem.Text = "Contraste 2"
        '
        'GamaToolStripMenuItem
        '
        Me.GamaToolStripMenuItem.Name = "GamaToolStripMenuItem"
        Me.GamaToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.GamaToolStripMenuItem.Text = "Corrección de gamma"
        '
        'ExposiciónToolStripMenuItem1
        '
        Me.ExposiciónToolStripMenuItem1.Name = "ExposiciónToolStripMenuItem1"
        Me.ExposiciónToolStripMenuItem1.Size = New System.Drawing.Size(185, 22)
        Me.ExposiciónToolStripMenuItem1.Text = "Exposición"
        '
        'ModificarCanalesToolStripMenuItem1
        '
        Me.ModificarCanalesToolStripMenuItem1.Name = "ModificarCanalesToolStripMenuItem1"
        Me.ModificarCanalesToolStripMenuItem1.Size = New System.Drawing.Size(185, 22)
        Me.ModificarCanalesToolStripMenuItem1.Text = "Modificar canales"
        '
        'ReducirColoresToolStripMenuItem
        '
        Me.ReducirColoresToolStripMenuItem.Name = "ReducirColoresToolStripMenuItem"
        Me.ReducirColoresToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.ReducirColoresToolStripMenuItem.Text = "Reducir colores"
        '
        'FiltrarColoresToolStripMenuItem
        '
        Me.FiltrarColoresToolStripMenuItem.Name = "FiltrarColoresToolStripMenuItem"
        Me.FiltrarColoresToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.FiltrarColoresToolStripMenuItem.Text = "Filtrar colores"
        '
        'MatrizToolStripMenuItem
        '
        Me.MatrizToolStripMenuItem.Name = "MatrizToolStripMenuItem"
        Me.MatrizToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.MatrizToolStripMenuItem.Text = "Matriz"
        '
        'DetectarContornosToolStripMenuItem
        '
        Me.DetectarContornosToolStripMenuItem.Name = "DetectarContornosToolStripMenuItem"
        Me.DetectarContornosToolStripMenuItem.Size = New System.Drawing.Size(185, 22)
        Me.DetectarContornosToolStripMenuItem.Text = "Detectar contornos"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirImagenToolStripMenuItem, Me.EdiciónToolStripMenuItem, Me.OperacionesBásicosToolStripMenuItem, Me.OperacionesBásicosPersonalizadasToolStripMenuItem, Me.OperacionesAritméticasToolStripMenuItem, Me.MáscarasToolStripMenuItem, Me.EfectosToolStripMenuItem, Me.OperacionesConDosImágenesToolStripMenuItem, Me.CloudToolStripMenuItem, Me.HerramientasToolStripMenuItem, Me.AyudaToolStripMenuItem})
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
        Me.OperacionesAritméticasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OperacionesToolStripMenuItem, Me.OperacionesLógicasToolStripMenuItem, Me.OperacionesMorfológicasbetaToolStripMenuItem, Me.OperacionesGeométricasToolStripMenuItem, Me.OtrasOperacionesToolStripMenuItem})
        Me.OperacionesAritméticasToolStripMenuItem.Name = "OperacionesAritméticasToolStripMenuItem"
        Me.OperacionesAritméticasToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.OperacionesAritméticasToolStripMenuItem.Text = "Operaciones"
        '
        'OperacionesToolStripMenuItem
        '
        Me.OperacionesToolStripMenuItem.Name = "OperacionesToolStripMenuItem"
        Me.OperacionesToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.OperacionesToolStripMenuItem.Text = "Operaciones aritméticas"
        '
        'OperacionesLógicasToolStripMenuItem
        '
        Me.OperacionesLógicasToolStripMenuItem.Name = "OperacionesLógicasToolStripMenuItem"
        Me.OperacionesLógicasToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.OperacionesLógicasToolStripMenuItem.Text = "Operaciones lógicas"
        '
        'OperacionesMorfológicasbetaToolStripMenuItem
        '
        Me.OperacionesMorfológicasbetaToolStripMenuItem.Name = "OperacionesMorfológicasbetaToolStripMenuItem"
        Me.OperacionesMorfológicasbetaToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.OperacionesMorfológicasbetaToolStripMenuItem.Text = "Operaciones morfológicas (beta)"
        '
        'OperacionesGeométricasToolStripMenuItem
        '
        Me.OperacionesGeométricasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReflexiónToolStripMenuItem, Me.TraslaciónToolStripMenuItem2, Me.VolteadosToolStripMenuItem, Me.ToolStripMenuItem12, Me.TransformaciónAfínToolStripMenuItem1})
        Me.OperacionesGeométricasToolStripMenuItem.Name = "OperacionesGeométricasToolStripMenuItem"
        Me.OperacionesGeométricasToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.OperacionesGeométricasToolStripMenuItem.Text = "Operaciones geométricas"
        '
        'ReflexiónToolStripMenuItem
        '
        Me.ReflexiónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HorizontalToolStripMenuItem, Me.VerticalToolStripMenuItem})
        Me.ReflexiónToolStripMenuItem.Name = "ReflexiónToolStripMenuItem"
        Me.ReflexiónToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ReflexiónToolStripMenuItem.Text = "Reflexión"
        '
        'HorizontalToolStripMenuItem
        '
        Me.HorizontalToolStripMenuItem.Name = "HorizontalToolStripMenuItem"
        Me.HorizontalToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.HorizontalToolStripMenuItem.Text = "Horizontal"
        '
        'VerticalToolStripMenuItem
        '
        Me.VerticalToolStripMenuItem.Name = "VerticalToolStripMenuItem"
        Me.VerticalToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.VerticalToolStripMenuItem.Text = "Vertical"
        '
        'TraslaciónToolStripMenuItem2
        '
        Me.TraslaciónToolStripMenuItem2.Name = "TraslaciónToolStripMenuItem2"
        Me.TraslaciónToolStripMenuItem2.Size = New System.Drawing.Size(176, 22)
        Me.TraslaciónToolStripMenuItem2.Text = "Traslación"
        '
        'VolteadosToolStripMenuItem
        '
        Me.VolteadosToolStripMenuItem.Name = "VolteadosToolStripMenuItem"
        Me.VolteadosToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.VolteadosToolStripMenuItem.Text = "Voltear"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(173, 6)
        '
        'TransformaciónAfínToolStripMenuItem1
        '
        Me.TransformaciónAfínToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManualsesgarImagenToolStripMenuItem, Me.PersonalizadaToolStripMenuItem})
        Me.TransformaciónAfínToolStripMenuItem1.Name = "TransformaciónAfínToolStripMenuItem1"
        Me.TransformaciónAfínToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.TransformaciónAfínToolStripMenuItem1.Text = "Transformación afín"
        '
        'ManualsesgarImagenToolStripMenuItem
        '
        Me.ManualsesgarImagenToolStripMenuItem.Name = "ManualsesgarImagenToolStripMenuItem"
        Me.ManualsesgarImagenToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ManualsesgarImagenToolStripMenuItem.Text = "Manual (sesgar imagen)"
        '
        'PersonalizadaToolStripMenuItem
        '
        Me.PersonalizadaToolStripMenuItem.Name = "PersonalizadaToolStripMenuItem"
        Me.PersonalizadaToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.PersonalizadaToolStripMenuItem.Text = "Personalizada"
        '
        'OtrasOperacionesToolStripMenuItem
        '
        Me.OtrasOperacionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DensitySlicingToolStripMenuItem})
        Me.OtrasOperacionesToolStripMenuItem.Name = "OtrasOperacionesToolStripMenuItem"
        Me.OtrasOperacionesToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.OtrasOperacionesToolStripMenuItem.Text = "Otras operaciones"
        '
        'DensitySlicingToolStripMenuItem
        '
        Me.DensitySlicingToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AutomáticoToolStripMenuItem, Me.ManualToolStripMenuItem})
        Me.DensitySlicingToolStripMenuItem.Name = "DensitySlicingToolStripMenuItem"
        Me.DensitySlicingToolStripMenuItem.Size = New System.Drawing.Size(148, 22)
        Me.DensitySlicingToolStripMenuItem.Text = "Density slicing"
        '
        'AutomáticoToolStripMenuItem
        '
        Me.AutomáticoToolStripMenuItem.Name = "AutomáticoToolStripMenuItem"
        Me.AutomáticoToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.AutomáticoToolStripMenuItem.Text = "Automático"
        '
        'ManualToolStripMenuItem
        '
        Me.ManualToolStripMenuItem.Name = "ManualToolStripMenuItem"
        Me.ManualToolStripMenuItem.Size = New System.Drawing.Size(133, 22)
        Me.ManualToolStripMenuItem.Text = "Manual"
        '
        'MáscarasToolStripMenuItem
        '
        Me.MáscarasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PasoAltoToolStripMenuItem, Me.PasoBajoToolStripMenuItem, Me.BordesYContornosToolStripMenuItem, Me.MáscaraManualToolStripMenuItem, Me.SobelTotalToolStripMenuItem})
        Me.MáscarasToolStripMenuItem.Name = "MáscarasToolStripMenuItem"
        Me.MáscarasToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.MáscarasToolStripMenuItem.Text = "Máscaras"
        '
        'PasoAltoToolStripMenuItem
        '
        Me.PasoAltoToolStripMenuItem.Name = "PasoAltoToolStripMenuItem"
        Me.PasoAltoToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.PasoAltoToolStripMenuItem.Text = "Paso alto"
        '
        'PasoBajoToolStripMenuItem
        '
        Me.PasoBajoToolStripMenuItem.Name = "PasoBajoToolStripMenuItem"
        Me.PasoBajoToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.PasoBajoToolStripMenuItem.Text = "Paso bajo"
        '
        'BordesYContornosToolStripMenuItem
        '
        Me.BordesYContornosToolStripMenuItem.Name = "BordesYContornosToolStripMenuItem"
        Me.BordesYContornosToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.BordesYContornosToolStripMenuItem.Text = "Bordes y contornos"
        '
        'MáscaraManualToolStripMenuItem
        '
        Me.MáscaraManualToolStripMenuItem.Name = "MáscaraManualToolStripMenuItem"
        Me.MáscaraManualToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.MáscaraManualToolStripMenuItem.Text = "Máscara manual"
        '
        'SobelTotalToolStripMenuItem
        '
        Me.SobelTotalToolStripMenuItem.Name = "SobelTotalToolStripMenuItem"
        Me.SobelTotalToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.SobelTotalToolStripMenuItem.Text = "Sobel total"
        '
        'EfectosToolStripMenuItem
        '
        Me.EfectosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DesenfoqueToolStripMenuItem, Me.CuadrículaToolStripMenuItem, Me.SombraDeVidrioToolStripMenuItem, Me.SdaToolStripMenuItem, Me.RadmiToolStripMenuItem, Me.ÓleoToolStripMenuItem, Me.CombinacionesToolStripMenuItem})
        Me.EfectosToolStripMenuItem.Name = "EfectosToolStripMenuItem"
        Me.EfectosToolStripMenuItem.Size = New System.Drawing.Size(56, 20)
        Me.EfectosToolStripMenuItem.Text = "Efectos"
        '
        'DesenfoqueToolStripMenuItem
        '
        Me.DesenfoqueToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DesenfonqueDistorsiónToolStripMenuItem, Me.DesenfoqueMovimientoToolStripMenuItem, Me.DesenfoqueBLURToolStripMenuItem, Me.PixeladoToolStripMenuItem})
        Me.DesenfoqueToolStripMenuItem.Name = "DesenfoqueToolStripMenuItem"
        Me.DesenfoqueToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.DesenfoqueToolStripMenuItem.Text = "Desenfoque"
        '
        'DesenfonqueDistorsiónToolStripMenuItem
        '
        Me.DesenfonqueDistorsiónToolStripMenuItem.Name = "DesenfonqueDistorsiónToolStripMenuItem"
        Me.DesenfonqueDistorsiónToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.DesenfonqueDistorsiónToolStripMenuItem.Text = "Desenfonque distorsión"
        '
        'DesenfoqueMovimientoToolStripMenuItem
        '
        Me.DesenfoqueMovimientoToolStripMenuItem.Name = "DesenfoqueMovimientoToolStripMenuItem"
        Me.DesenfoqueMovimientoToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.DesenfoqueMovimientoToolStripMenuItem.Text = "Desenfoque movimiento"
        '
        'DesenfoqueBLURToolStripMenuItem
        '
        Me.DesenfoqueBLURToolStripMenuItem.Name = "DesenfoqueBLURToolStripMenuItem"
        Me.DesenfoqueBLURToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.DesenfoqueBLURToolStripMenuItem.Text = "Desenfoque (Blur)"
        '
        'PixeladoToolStripMenuItem
        '
        Me.PixeladoToolStripMenuItem.Name = "PixeladoToolStripMenuItem"
        Me.PixeladoToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.PixeladoToolStripMenuItem.Text = "Pixelado"
        '
        'CuadrículaToolStripMenuItem
        '
        Me.CuadrículaToolStripMenuItem.Name = "CuadrículaToolStripMenuItem"
        Me.CuadrículaToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CuadrículaToolStripMenuItem.Text = "Cuadrícula"
        '
        'SombraDeVidrioToolStripMenuItem
        '
        Me.SombraDeVidrioToolStripMenuItem.Name = "SombraDeVidrioToolStripMenuItem"
        Me.SombraDeVidrioToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.SombraDeVidrioToolStripMenuItem.Text = "Sombra de vidrio"
        '
        'SdaToolStripMenuItem
        '
        Me.SdaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TresPartesToolStripMenuItem, Me.SeisPartesToolStripMenuItem})
        Me.SdaToolStripMenuItem.Name = "SdaToolStripMenuItem"
        Me.SdaToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.SdaToolStripMenuItem.Text = "Trocear imagen"
        '
        'TresPartesToolStripMenuItem
        '
        Me.TresPartesToolStripMenuItem.Name = "TresPartesToolStripMenuItem"
        Me.TresPartesToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.TresPartesToolStripMenuItem.Text = "Tres partes"
        '
        'SeisPartesToolStripMenuItem
        '
        Me.SeisPartesToolStripMenuItem.Name = "SeisPartesToolStripMenuItem"
        Me.SeisPartesToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.SeisPartesToolStripMenuItem.Text = "Seis partes"
        '
        'RadmiToolStripMenuItem
        '
        Me.RadmiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PonerLosDosToolStripMenuItem, Me.SadToolStripMenuItem})
        Me.RadmiToolStripMenuItem.Name = "RadmiToolStripMenuItem"
        Me.RadmiToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
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
        Me.ÓleoToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.ÓleoToolStripMenuItem.Text = "Óleo"
        '
        'CombinacionesToolStripMenuItem
        '
        Me.CombinacionesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EfectoMarteToolStripMenuItem, Me.EfectoAntiguoSobreexpuestoToolStripMenuItem, Me.EfectoMarinoToolStripMenuItem, Me.AumentarRasgosToolStripMenuItem, Me.DisminuirRasgosToolStripMenuItem, Me.ContornoSombreadoToolStripMenuItem, Me.ColorearToolStripMenuItem})
        Me.CombinacionesToolStripMenuItem.Name = "CombinacionesToolStripMenuItem"
        Me.CombinacionesToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CombinacionesToolStripMenuItem.Text = "Combinaciones"
        '
        'EfectoMarteToolStripMenuItem
        '
        Me.EfectoMarteToolStripMenuItem.Name = "EfectoMarteToolStripMenuItem"
        Me.EfectoMarteToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.EfectoMarteToolStripMenuItem.Text = "Efecto Marte"
        '
        'EfectoAntiguoSobreexpuestoToolStripMenuItem
        '
        Me.EfectoAntiguoSobreexpuestoToolStripMenuItem.Name = "EfectoAntiguoSobreexpuestoToolStripMenuItem"
        Me.EfectoAntiguoSobreexpuestoToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.EfectoAntiguoSobreexpuestoToolStripMenuItem.Text = "Efecto antiguo sobreexpuesto"
        '
        'EfectoMarinoToolStripMenuItem
        '
        Me.EfectoMarinoToolStripMenuItem.Name = "EfectoMarinoToolStripMenuItem"
        Me.EfectoMarinoToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.EfectoMarinoToolStripMenuItem.Text = "Efecto marino"
        '
        'AumentarRasgosToolStripMenuItem
        '
        Me.AumentarRasgosToolStripMenuItem.Name = "AumentarRasgosToolStripMenuItem"
        Me.AumentarRasgosToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.AumentarRasgosToolStripMenuItem.Text = "Aumentar rasgos"
        '
        'DisminuirRasgosToolStripMenuItem
        '
        Me.DisminuirRasgosToolStripMenuItem.Name = "DisminuirRasgosToolStripMenuItem"
        Me.DisminuirRasgosToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.DisminuirRasgosToolStripMenuItem.Text = "Disminuir rasgos"
        '
        'ContornoSombreadoToolStripMenuItem
        '
        Me.ContornoSombreadoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ContenidoToolStripMenuItem, Me.DesmedidoToolStripMenuItem})
        Me.ContornoSombreadoToolStripMenuItem.Name = "ContornoSombreadoToolStripMenuItem"
        Me.ContornoSombreadoToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.ContornoSombreadoToolStripMenuItem.Text = "Contorno sombreado"
        '
        'ContenidoToolStripMenuItem
        '
        Me.ContenidoToolStripMenuItem.Name = "ContenidoToolStripMenuItem"
        Me.ContenidoToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ContenidoToolStripMenuItem.Text = "Contenido"
        '
        'DesmedidoToolStripMenuItem
        '
        Me.DesmedidoToolStripMenuItem.Name = "DesmedidoToolStripMenuItem"
        Me.DesmedidoToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.DesmedidoToolStripMenuItem.Text = "Desmedido"
        '
        'ColorearToolStripMenuItem
        '
        Me.ColorearToolStripMenuItem.Name = "ColorearToolStripMenuItem"
        Me.ColorearToolStripMenuItem.Size = New System.Drawing.Size(229, 22)
        Me.ColorearToolStripMenuItem.Text = "Aumentar luz"
        '
        'OperacionesConDosImágenesToolStripMenuItem
        '
        Me.OperacionesConDosImágenesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SumaToolStripMenuItem, Me.OperacionesLógicasToolStripMenuItem1, Me.AnaglifoToolStripMenuItem, Me.ComparadorDeImágenesToolStripMenuItem})
        Me.OperacionesConDosImágenesToolStripMenuItem.Name = "OperacionesConDosImágenesToolStripMenuItem"
        Me.OperacionesConDosImágenesToolStripMenuItem.Size = New System.Drawing.Size(180, 20)
        Me.OperacionesConDosImágenesToolStripMenuItem.Text = "Operaciones con dos imágenes"
        '
        'SumaToolStripMenuItem
        '
        Me.SumaToolStripMenuItem.Name = "SumaToolStripMenuItem"
        Me.SumaToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.SumaToolStripMenuItem.Text = "Operaciones aritméticas"
        '
        'OperacionesLógicasToolStripMenuItem1
        '
        Me.OperacionesLógicasToolStripMenuItem1.Name = "OperacionesLógicasToolStripMenuItem1"
        Me.OperacionesLógicasToolStripMenuItem1.Size = New System.Drawing.Size(206, 22)
        Me.OperacionesLógicasToolStripMenuItem1.Text = "Operaciones lógicas"
        '
        'AnaglifoToolStripMenuItem
        '
        Me.AnaglifoToolStripMenuItem.Name = "AnaglifoToolStripMenuItem"
        Me.AnaglifoToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.AnaglifoToolStripMenuItem.Text = "Anaglifo"
        '
        'ComparadorDeImágenesToolStripMenuItem
        '
        Me.ComparadorDeImágenesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LocalToolStripMenuItem, Me.VecinosToolStripMenuItem})
        Me.ComparadorDeImágenesToolStripMenuItem.Name = "ComparadorDeImágenesToolStripMenuItem"
        Me.ComparadorDeImágenesToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.ComparadorDeImágenesToolStripMenuItem.Text = "Comparador de imágenes"
        '
        'LocalToolStripMenuItem
        '
        Me.LocalToolStripMenuItem.Name = "LocalToolStripMenuItem"
        Me.LocalToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.LocalToolStripMenuItem.Text = "Local"
        '
        'VecinosToolStripMenuItem
        '
        Me.VecinosToolStripMenuItem.Name = "VecinosToolStripMenuItem"
        Me.VecinosToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.VecinosToolStripMenuItem.Text = "Vecinos"
        '
        'CloudToolStripMenuItem
        '
        Me.CloudToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuardarImágenesToolStripMenuItem, Me.CrearToolStripMenuItem, Me.AccesoCarpetaPrivadaToolStripMenuItem})
        Me.CloudToolStripMenuItem.Name = "CloudToolStripMenuItem"
        Me.CloudToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.CloudToolStripMenuItem.Text = "Cloud"
        '
        'GuardarImágenesToolStripMenuItem
        '
        Me.GuardarImágenesToolStripMenuItem.Name = "GuardarImágenesToolStripMenuItem"
        Me.GuardarImágenesToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.GuardarImágenesToolStripMenuItem.Text = "Compartir imagen"
        '
        'CrearToolStripMenuItem
        '
        Me.CrearToolStripMenuItem.Name = "CrearToolStripMenuItem"
        Me.CrearToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.CrearToolStripMenuItem.Text = "Crear carpeta privada"
        '
        'AccesoCarpetaPrivadaToolStripMenuItem
        '
        Me.AccesoCarpetaPrivadaToolStripMenuItem.Name = "AccesoCarpetaPrivadaToolStripMenuItem"
        Me.AccesoCarpetaPrivadaToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.AccesoCarpetaPrivadaToolStripMenuItem.Text = "Acceso carpeta privada"
        '
        'HerramientasToolStripMenuItem
        '
        Me.HerramientasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HistogramasAutomáticosToolStripMenuItem, Me.LiberarMemoriaToolStripMenuItem, Me.BarraAccesosRápidosToolStripMenuItem, Me.ActualizacionesAutomáticasToolStripMenuItem})
        Me.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem"
        Me.HerramientasToolStripMenuItem.Size = New System.Drawing.Size(87, 20)
        Me.HerramientasToolStripMenuItem.Text = "Herramientas"
        '
        'HistogramasAutomáticosToolStripMenuItem
        '
        Me.HistogramasAutomáticosToolStripMenuItem.Checked = True
        Me.HistogramasAutomáticosToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.HistogramasAutomáticosToolStripMenuItem.Name = "HistogramasAutomáticosToolStripMenuItem"
        Me.HistogramasAutomáticosToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.HistogramasAutomáticosToolStripMenuItem.Text = "Histogramas automáticos"
        '
        'LiberarMemoriaToolStripMenuItem
        '
        Me.LiberarMemoriaToolStripMenuItem.Name = "LiberarMemoriaToolStripMenuItem"
        Me.LiberarMemoriaToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.LiberarMemoriaToolStripMenuItem.Text = "Liberar memoria"
        '
        'BarraAccesosRápidosToolStripMenuItem
        '
        Me.BarraAccesosRápidosToolStripMenuItem.Checked = True
        Me.BarraAccesosRápidosToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.BarraAccesosRápidosToolStripMenuItem.Name = "BarraAccesosRápidosToolStripMenuItem"
        Me.BarraAccesosRápidosToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.BarraAccesosRápidosToolStripMenuItem.Text = "Barra accesos rápidos"
        '
        'ActualizacionesAutomáticasToolStripMenuItem
        '
        Me.ActualizacionesAutomáticasToolStripMenuItem.Name = "ActualizacionesAutomáticasToolStripMenuItem"
        Me.ActualizacionesAutomáticasToolStripMenuItem.Size = New System.Drawing.Size(218, 22)
        Me.ActualizacionesAutomáticasToolStripMenuItem.Text = "Actualizaciones automáticas"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaToolStripMenuItem1, Me.AyudaEnLaWebToolStripMenuItem, Me.NotificarUnErrorToolStripMenuItem, Me.AyúdanosAMejorarToolStripMenuItem, Me.ColaboraConElProyectoToolStripMenuItem, Me.ComprobarActualizacionesToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(51, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'AyudaToolStripMenuItem1
        '
        Me.AyudaToolStripMenuItem1.Name = "AyudaToolStripMenuItem1"
        Me.AyudaToolStripMenuItem1.Size = New System.Drawing.Size(213, 22)
        Me.AyudaToolStripMenuItem1.Text = "Ayuda"
        '
        'AyudaEnLaWebToolStripMenuItem
        '
        Me.AyudaEnLaWebToolStripMenuItem.Name = "AyudaEnLaWebToolStripMenuItem"
        Me.AyudaEnLaWebToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.AyudaEnLaWebToolStripMenuItem.Text = "Ayuda en la web"
        '
        'NotificarUnErrorToolStripMenuItem
        '
        Me.NotificarUnErrorToolStripMenuItem.Name = "NotificarUnErrorToolStripMenuItem"
        Me.NotificarUnErrorToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.NotificarUnErrorToolStripMenuItem.Text = "Notificar un error"
        '
        'AyúdanosAMejorarToolStripMenuItem
        '
        Me.AyúdanosAMejorarToolStripMenuItem.Name = "AyúdanosAMejorarToolStripMenuItem"
        Me.AyúdanosAMejorarToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.AyúdanosAMejorarToolStripMenuItem.Text = "Ayúdanos a mejorar"
        '
        'ColaboraConElProyectoToolStripMenuItem
        '
        Me.ColaboraConElProyectoToolStripMenuItem.Name = "ColaboraConElProyectoToolStripMenuItem"
        Me.ColaboraConElProyectoToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ColaboraConElProyectoToolStripMenuItem.Text = "Colabora con el proyecto"
        '
        'ComprobarActualizacionesToolStripMenuItem
        '
        Me.ComprobarActualizacionesToolStripMenuItem.Name = "ComprobarActualizacionesToolStripMenuItem"
        Me.ComprobarActualizacionesToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.ComprobarActualizacionesToolStripMenuItem.Text = "Comprobar actualizaciones"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(213, 22)
        Me.AcercaDeToolStripMenuItem.Text = "Acerca de Apolo"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.AllowDrop = True
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AllowDrop = True
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
        Me.SplitContainer1.SplitterDistance = 1063
        Me.SplitContainer1.TabIndex = 28
        '
        'Panel1
        '
        Me.Panel1.AllowDrop = True
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1061, 621)
        Me.Panel1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(617, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Label2"
        Me.Label2.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox3.Location = New System.Drawing.Point(584, 30)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(112, 100)
        Me.PictureBox3.TabIndex = 1
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = Global.ClaseImagenes.My.Resources.Resources.remastered_lena_512x512
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1059, 619)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AllowDrop = True
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Control
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton8, Me.ToolStripButton3, Me.ToolStripButton4, Me.ToolStripSeparator1, Me.ToolStripButton5, Me.ToolStripButton6, Me.ToolStripButton7, Me.ToolStripButton9, Me.ToolStripButton13, Me.ToolStripSeparator3, Me.ToolStripButton18, Me.ToolStripButton10, Me.ToolStripButton11, Me.ToolStripButton12, Me.ToolStripButton14, Me.ToolStripSeparator5, Me.ToolStripButton15, Me.ToolStripButton17, Me.ToolStripButton16, Me.ToolStripSeparator2, Me.ToolStripButton19, Me.ToolStripButton21, Me.ToolStripButton20, Me.ToolStripSeparator4, Me.ToolStripButton22, Me.ToolStripButton23, Me.ToolStripButton24, Me.ToolStripSeparator6, Me.ToolStripButton25, Me.ToolStripButton26, Me.ToolStripSeparator7, Me.ToolStripButton27, Me.ToolStripButton28, Me.ToolStripLabel1, Me.ToolStripButton29, Me.ToolStripSeparator8, Me.ToolStripButton30, Me.ToolStripButton31})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(10, 3, 3, 3)
        Me.ToolStrip1.Size = New System.Drawing.Size(1061, 45)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
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
        'ToolStripButton13
        '
        Me.ToolStripButton13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton13.Image = Global.ClaseImagenes.My.Resources.Resources.LenaOriginal
        Me.ToolStripButton13.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton13.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton13.Name = "ToolStripButton13"
        Me.ToolStripButton13.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton13.Text = "Imagen original"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton18
        '
        Me.ToolStripButton18.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton18.Image = Global.ClaseImagenes.My.Resources.Resources.Todohistogramas
        Me.ToolStripButton18.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton18.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton18.Name = "ToolStripButton18"
        Me.ToolStripButton18.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton18.Text = "Histogramas"
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
        'ToolStripButton12
        '
        Me.ToolStripButton12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton12.Image = Global.ClaseImagenes.My.Resources.Resources.LenaContorno
        Me.ToolStripButton12.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton12.Name = "ToolStripButton12"
        Me.ToolStripButton12.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton12.Text = "Detectar contornos"
        '
        'ToolStripButton14
        '
        Me.ToolStripButton14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton14.Image = Global.ClaseImagenes.My.Resources.Resources.LenaMenosColores
        Me.ToolStripButton14.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton14.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton14.Name = "ToolStripButton14"
        Me.ToolStripButton14.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton14.Text = "Reducir colores"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton15
        '
        Me.ToolStripButton15.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton15.Image = CType(resources.GetObject("ToolStripButton15.Image"), System.Drawing.Image)
        Me.ToolStripButton15.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton15.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton15.Name = "ToolStripButton15"
        Me.ToolStripButton15.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton15.Text = "Operaciones aritméticas"
        '
        'ToolStripButton17
        '
        Me.ToolStripButton17.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton17.Image = Global.ClaseImagenes.My.Resources.Resources.Voltear
        Me.ToolStripButton17.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton17.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton17.Name = "ToolStripButton17"
        Me.ToolStripButton17.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton17.Text = "Voltear"
        '
        'ToolStripButton16
        '
        Me.ToolStripButton16.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton16.Image = Global.ClaseImagenes.My.Resources.Resources.LenaAfinr
        Me.ToolStripButton16.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton16.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton16.Name = "ToolStripButton16"
        Me.ToolStripButton16.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton16.Text = "Transformación afín"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton19
        '
        Me.ToolStripButton19.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton19.Image = Global.ClaseImagenes.My.Resources.Resources.Mascara
        Me.ToolStripButton19.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton19.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton19.Name = "ToolStripButton19"
        Me.ToolStripButton19.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton19.Text = "Máscara manual"
        '
        'ToolStripButton21
        '
        Me.ToolStripButton21.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton21.Image = Global.ClaseImagenes.My.Resources.Resources.BordesContornos
        Me.ToolStripButton21.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton21.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton21.Name = "ToolStripButton21"
        Me.ToolStripButton21.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton21.Text = "Bordes y contornos"
        '
        'ToolStripButton20
        '
        Me.ToolStripButton20.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton20.Image = Global.ClaseImagenes.My.Resources.Resources.Sobel
        Me.ToolStripButton20.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton20.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton20.Name = "ToolStripButton20"
        Me.ToolStripButton20.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton20.Text = "Sobel total"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton22
        '
        Me.ToolStripButton22.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton22.Image = Global.ClaseImagenes.My.Resources.Resources.LenaRuido
        Me.ToolStripButton22.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton22.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton22.Name = "ToolStripButton22"
        Me.ToolStripButton22.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton22.Text = "Ruido"
        '
        'ToolStripButton23
        '
        Me.ToolStripButton23.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton23.Image = Global.ClaseImagenes.My.Resources.Resources.LenaSombraVidrio
        Me.ToolStripButton23.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton23.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton23.Name = "ToolStripButton23"
        Me.ToolStripButton23.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton23.Text = "Sombra de vidrio"
        '
        'ToolStripButton24
        '
        Me.ToolStripButton24.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton24.Image = Global.ClaseImagenes.My.Resources.Resources.LenaTrozos
        Me.ToolStripButton24.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton24.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton24.Name = "ToolStripButton24"
        Me.ToolStripButton24.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton24.Text = "Trocear imagen"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton25
        '
        Me.ToolStripButton25.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton25.Image = Global.ClaseImagenes.My.Resources.Resources.anaglifo
        Me.ToolStripButton25.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton25.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton25.Name = "ToolStripButton25"
        Me.ToolStripButton25.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton25.Text = "Anaglifo"
        '
        'ToolStripButton26
        '
        Me.ToolStripButton26.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton26.Image = Global.ClaseImagenes.My.Resources.Resources.Comparar
        Me.ToolStripButton26.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton26.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton26.Name = "ToolStripButton26"
        Me.ToolStripButton26.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton26.Text = "Comparar imágenes (vecinos)"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripButton27
        '
        Me.ToolStripButton27.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton27.Image = Global.ClaseImagenes.My.Resources.Resources.cloud_1
        Me.ToolStripButton27.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton27.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton27.Name = "ToolStripButton27"
        Me.ToolStripButton27.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton27.Text = "Compartir imagen"
        '
        'ToolStripButton28
        '
        Me.ToolStripButton28.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton28.Image = CType(resources.GetObject("ToolStripButton28.Image"), System.Drawing.Image)
        Me.ToolStripButton28.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton28.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton28.Name = "ToolStripButton28"
        Me.ToolStripButton28.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton28.Text = "Sesión privada"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(89, 15)
        '
        'ToolStripButton29
        '
        Me.ToolStripButton29.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton29.Image = Global.ClaseImagenes.My.Resources.Resources.ram
        Me.ToolStripButton29.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton29.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton29.Name = "ToolStripButton29"
        Me.ToolStripButton29.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton29.Text = "Liberar memoria"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 6)
        '
        'ToolStripButton30
        '
        Me.ToolStripButton30.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton30.Image = CType(resources.GetObject("ToolStripButton30.Image"), System.Drawing.Image)
        Me.ToolStripButton30.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton30.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton30.Name = "ToolStripButton30"
        Me.ToolStripButton30.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton30.Text = "Notificar error"
        '
        'ToolStripButton31
        '
        Me.ToolStripButton31.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton31.Image = Global.ClaseImagenes.My.Resources.Resources.Colabora
        Me.ToolStripButton31.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton31.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton31.Name = "ToolStripButton31"
        Me.ToolStripButton31.Size = New System.Drawing.Size(36, 36)
        Me.ToolStripButton31.Text = "Colabora"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
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
        Me.ToolTip1.SetToolTip(Me.Chart3, "Histograma azul")
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
        Me.ToolTip1.SetToolTip(Me.Chart2, "Histograma verde")
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
        Me.ToolTip1.SetToolTip(Me.Chart1, "Histograma rojo")
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(191, 422)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Registro cambios"
        '
        'TabPage3
        '
        Me.TabPage3.AutoScroll = True
        Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
        Me.TabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage3.Controls.Add(Me.Panel2)
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Controls.Add(Me.PictureBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(191, 422)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Zoom interactivo"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.NumTamanoPuntero)
        Me.Panel2.Controls.Add(Me.NumVentana)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.chbPuntero)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Location = New System.Drawing.Point(0, 197)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(189, 218)
        Me.Panel2.TabIndex = 2
        '
        'NumTamanoPuntero
        '
        Me.NumTamanoPuntero.Location = New System.Drawing.Point(101, 119)
        Me.NumTamanoPuntero.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumTamanoPuntero.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumTamanoPuntero.Name = "NumTamanoPuntero"
        Me.NumTamanoPuntero.Size = New System.Drawing.Size(48, 23)
        Me.NumTamanoPuntero.TabIndex = 29
        Me.NumTamanoPuntero.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'NumVentana
        '
        Me.NumVentana.Location = New System.Drawing.Point(120, 20)
        Me.NumVentana.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.NumVentana.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.NumVentana.Name = "NumVentana"
        Me.NumVentana.Size = New System.Drawing.Size(58, 23)
        Me.NumVentana.TabIndex = 27
        Me.NumVentana.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 121)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Tamaño:"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(62, 148)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(65, 23)
        Me.Button3.TabIndex = 25
        Me.Button3.Text = "Color"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'chbPuntero
        '
        Me.chbPuntero.AutoSize = True
        Me.chbPuntero.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chbPuntero.Location = New System.Drawing.Point(19, 94)
        Me.chbPuntero.Name = "chbPuntero"
        Me.chbPuntero.Size = New System.Drawing.Size(108, 19)
        Me.chbPuntero.TabIndex = 24
        Me.chbPuntero.Text = "Activar puntero"
        Me.chbPuntero.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 15)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Valor del zoom:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 15)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Tamaño ventana:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.PictureBox5)
        Me.GroupBox1.Controls.Add(Me.NumZoom)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 214)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Propiedades"
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.ClaseImagenes.My.Resources.Resources.help
        Me.PictureBox5.Location = New System.Drawing.Point(114, 55)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(16, 16)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 31
        Me.PictureBox5.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PictureBox5, "Pulse la tecla z y mueva la rueda del ratón para aumentar o disminuir el zoom.")
        '
        'NumZoom
        '
        Me.NumZoom.DecimalPlaces = 1
        Me.NumZoom.Increment = New Decimal(New Integer() {2, 0, 0, 65536})
        Me.NumZoom.Location = New System.Drawing.Point(136, 52)
        Me.NumZoom.Maximum = New Decimal(New Integer() {52, 0, 0, 65536})
        Me.NumZoom.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.NumZoom.Name = "NumZoom"
        Me.NumZoom.Size = New System.Drawing.Size(41, 23)
        Me.NumZoom.TabIndex = 28
        Me.NumZoom.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(27, 174)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(134, 23)
        Me.Button4.TabIndex = 30
        Me.Button4.Text = "Guardar cambios"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(61, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Zoom x2"
        '
        'PictureBox4
        '
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Location = New System.Drawing.Point(27, 33)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(150, 150)
        Me.PictureBox4.TabIndex = 0
        Me.PictureBox4.TabStop = False
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
        'StatusStrip2
        '
        Me.StatusStrip2.AllowDrop = True
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImagenActual, Me.barraestado, Me.PorcentajeActual, Me.Estadoactual, Me.ToolStripStatusLabel4, Me.ToolStripStatusLabel2, Me.ToolStripSplitButton1, Me.ToolStripStatusLabel3, Me.ToolStripStatusImagen, Me.ToolStripStatusColor})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 692)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip2.Size = New System.Drawing.Size(1276, 24)
        Me.StatusStrip2.TabIndex = 29
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'ImagenActual
        '
        Me.ImagenActual.Name = "ImagenActual"
        Me.ImagenActual.Size = New System.Drawing.Size(76, 19)
        Me.ImagenActual.Text = "Apolo thread"
        '
        'barraestado
        '
        Me.barraestado.Name = "barraestado"
        Me.barraestado.Size = New System.Drawing.Size(300, 18)
        '
        'PorcentajeActual
        '
        Me.PorcentajeActual.Name = "PorcentajeActual"
        Me.PorcentajeActual.Size = New System.Drawing.Size(35, 19)
        Me.PorcentajeActual.Text = "100%"
        '
        'Estadoactual
        '
        Me.Estadoactual.Name = "Estadoactual"
        Me.Estadoactual.Size = New System.Drawing.Size(60, 19)
        Me.Estadoactual.Text = "Finalizado"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(56, 19)
        Me.ToolStripStatusLabel4.Text = "Zoom: x1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(30, 19)
        Me.ToolStripStatusLabel2.Text = "(0,0)"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MilímetrosToolStripMenuItem, Me.CentímetrosToolStripMenuItem, Me.PulgadasToolStripMenuItem, Me.PíxelesToolStripMenuItem})
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(16, 22)
        Me.ToolStripSplitButton1.Text = "ToolStripSplitButton1"
        '
        'MilímetrosToolStripMenuItem
        '
        Me.MilímetrosToolStripMenuItem.CheckOnClick = True
        Me.MilímetrosToolStripMenuItem.Name = "MilímetrosToolStripMenuItem"
        Me.MilímetrosToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.MilímetrosToolStripMenuItem.Text = "Milímetros"
        '
        'CentímetrosToolStripMenuItem
        '
        Me.CentímetrosToolStripMenuItem.Name = "CentímetrosToolStripMenuItem"
        Me.CentímetrosToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.CentímetrosToolStripMenuItem.Text = "Centímetros"
        '
        'PulgadasToolStripMenuItem
        '
        Me.PulgadasToolStripMenuItem.CheckOnClick = True
        Me.PulgadasToolStripMenuItem.Name = "PulgadasToolStripMenuItem"
        Me.PulgadasToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.PulgadasToolStripMenuItem.Text = "Pulgadas"
        '
        'PíxelesToolStripMenuItem
        '
        Me.PíxelesToolStripMenuItem.Checked = True
        Me.PíxelesToolStripMenuItem.CheckOnClick = True
        Me.PíxelesToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PíxelesToolStripMenuItem.Name = "PíxelesToolStripMenuItem"
        Me.PíxelesToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.PíxelesToolStripMenuItem.Text = "Píxeles"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(251, 19)
        Me.ToolStripStatusLabel3.Text = "   (Pulse control y haga clic para recoger color)"
        '
        'ToolStripStatusImagen
        '
        Me.ToolStripStatusImagen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripStatusImagen.Name = "ToolStripStatusImagen"
        Me.ToolStripStatusImagen.Size = New System.Drawing.Size(0, 19)
        Me.ToolStripStatusImagen.Text = "ToolStripStatusLabel4"
        '
        'ToolStripStatusColor
        '
        Me.ToolStripStatusColor.Name = "ToolStripStatusColor"
        Me.ToolStripStatusColor.Size = New System.Drawing.Size(0, 19)
        '
        'BackgroundWorker2
        '
        Me.BackgroundWorker2.WorkerReportsProgress = True
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        '
        'BackgroundWorkerACTUALIZACION
        '
        '
        'BackgroundWorkerACtual_Automaticas
        '
        '
        'Principal
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1276, 716)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Apolo thread"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.NumTamanoPuntero, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumVentana, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumZoom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
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
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GuardarComoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton8 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton9 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
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
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HistogramasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetalladoToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TodosToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NotificarUnErrorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AbrirCompiladorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HerramientasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistogramasAutomáticosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip2 As System.Windows.Forms.StatusStrip
    Friend WithEvents ImagenActual As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents barraestado As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents PorcentajeActual As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Estadoactual As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents MilímetrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CentímetrosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PulgadasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PíxelesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusImagen As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusColor As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents AyúdanosAMejorarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColaboraConElProyectoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PropiedadesDeLaImagenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents RedimensionarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LiberarMemoriaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GamaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents CompartirImagenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloudToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuardarImágenesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccesoCarpetaPrivadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents AnaglifoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZoomToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeshacerZoomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents AjustarAPantallaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OperacionesGeométricasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReflexiónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TraslaciónToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransformaciónAfínToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VolteadosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ManualsesgarImagenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PersonalizadaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ZoomInteractivoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents EmpezarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PropiedadesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents NumTamanoPuntero As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumZoom As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumVentana As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents chbPuntero As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents OtrasOperacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DensitySlicingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutomáticoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManualToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CombinacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EfectoMarteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EfectoAntiguoSobreexpuestoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EfectoMarinoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AumentarRasgosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DisminuirRasgosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContornoSombreadoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContenidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesmedidoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColorearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton12 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton13 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton14 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton15 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton16 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton17 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton18 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton19 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton20 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton21 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BarraAccesosRápidosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton22 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton23 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton24 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton25 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton26 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton27 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton28 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton29 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton30 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton31 As System.Windows.Forms.ToolStripButton
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CapturaDePantallaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CopiarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PegarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem11 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AyudaToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaEnLaWebToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GggToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComprobarActualizacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorkerACTUALIZACION As System.ComponentModel.BackgroundWorker
    Friend WithEvents ActualizacionesAutomáticasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorkerACtual_Automaticas As System.ComponentModel.BackgroundWorker

End Class
