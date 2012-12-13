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
        Me.EdiciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeshacerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RehacerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RegistroDeCambiosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefrescarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BlancoYNegroToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EscalaDeGrisesToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BrilloToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExposiciónToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ModificarCanalesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReducirColoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FiltrarColoresToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatrizToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MáscarasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasoAltoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasoBajoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BordesYContornosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MáscaraManualToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SobelTotalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EfectosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesenfocarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CuadrículaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SombraDeVidrioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SdaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TresPartesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeisPartesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RadmiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesenFOQUEEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
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
        Me.StatusStrip1.Size = New System.Drawing.Size(1284, 24)
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
        Me.AbrirImagenToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirImagenToolStripMenuItem1, Me.CargarToolStripMenuItem, Me.BuscarImágenesEnLaWebToolStripMenuItem, Me.BuscarImágenesEnFacebookToolStripMenuItem, Me.CrearTapizToolStripMenuItem})
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
        'EdiciónToolStripMenuItem
        '
        Me.EdiciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeshacerToolStripMenuItem, Me.RehacerToolStripMenuItem, Me.RegistroDeCambiosToolStripMenuItem, Me.RefrescarToolStripMenuItem})
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
        'RefrescarToolStripMenuItem
        '
        Me.RefrescarToolStripMenuItem.Name = "RefrescarToolStripMenuItem"
        Me.RefrescarToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.RefrescarToolStripMenuItem.Text = "Refrescar"
        '
        'OperacionesBásicosToolStripMenuItem
        '
        Me.OperacionesBásicosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EscalaDeGrisesToolStripMenuItem, Me.EscalaDeGrisesToolStripMenuItem1, Me.InvertirColoresToolStripMenuItem, Me.SepiaToolStripMenuItem, Me.FiltrosBásicosToolStripMenuItem, Me.RGBAToolStripMenuItem, Me.ReflexiónToolStripMenuItem})
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
        'OperacionesBásicosPersonalizadasToolStripMenuItem
        '
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BlancoYNegroToolStripMenuItem, Me.EscalaDeGrisesToolStripMenuItem2, Me.BrilloToolStripMenuItem1, Me.ExposiciónToolStripMenuItem1, Me.ModificarCanalesToolStripMenuItem1, Me.ReducirColoresToolStripMenuItem, Me.FiltrarColoresToolStripMenuItem, Me.MatrizToolStripMenuItem})
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem.Name = "OperacionesBásicosPersonalizadasToolStripMenuItem"
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem.Size = New System.Drawing.Size(207, 20)
        Me.OperacionesBásicosPersonalizadasToolStripMenuItem.Text = "Operaciones básicos personalizadas"
        '
        'BlancoYNegroToolStripMenuItem
        '
        Me.BlancoYNegroToolStripMenuItem.Name = "BlancoYNegroToolStripMenuItem"
        Me.BlancoYNegroToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.BlancoYNegroToolStripMenuItem.Text = "Blanco y negro"
        '
        'EscalaDeGrisesToolStripMenuItem2
        '
        Me.EscalaDeGrisesToolStripMenuItem2.Name = "EscalaDeGrisesToolStripMenuItem2"
        Me.EscalaDeGrisesToolStripMenuItem2.Size = New System.Drawing.Size(167, 22)
        Me.EscalaDeGrisesToolStripMenuItem2.Text = "Escala de grises"
        '
        'BrilloToolStripMenuItem1
        '
        Me.BrilloToolStripMenuItem1.Name = "BrilloToolStripMenuItem1"
        Me.BrilloToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.BrilloToolStripMenuItem1.Text = "Brillo"
        '
        'ExposiciónToolStripMenuItem1
        '
        Me.ExposiciónToolStripMenuItem1.Name = "ExposiciónToolStripMenuItem1"
        Me.ExposiciónToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.ExposiciónToolStripMenuItem1.Text = "Exposición"
        '
        'ModificarCanalesToolStripMenuItem1
        '
        Me.ModificarCanalesToolStripMenuItem1.Name = "ModificarCanalesToolStripMenuItem1"
        Me.ModificarCanalesToolStripMenuItem1.Size = New System.Drawing.Size(167, 22)
        Me.ModificarCanalesToolStripMenuItem1.Text = "Modificar canales"
        '
        'ReducirColoresToolStripMenuItem
        '
        Me.ReducirColoresToolStripMenuItem.Name = "ReducirColoresToolStripMenuItem"
        Me.ReducirColoresToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ReducirColoresToolStripMenuItem.Text = "Reducir colores"
        '
        'FiltrarColoresToolStripMenuItem
        '
        Me.FiltrarColoresToolStripMenuItem.Name = "FiltrarColoresToolStripMenuItem"
        Me.FiltrarColoresToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.FiltrarColoresToolStripMenuItem.Text = "Filtrar colores"
        '
        'MatrizToolStripMenuItem
        '
        Me.MatrizToolStripMenuItem.Name = "MatrizToolStripMenuItem"
        Me.MatrizToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.MatrizToolStripMenuItem.Text = "Matriz"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirImagenToolStripMenuItem, Me.EdiciónToolStripMenuItem, Me.OperacionesBásicosToolStripMenuItem, Me.OperacionesBásicosPersonalizadasToolStripMenuItem, Me.MáscarasToolStripMenuItem, Me.EfectosToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.ShowItemToolTips = True
        Me.MenuStrip1.Size = New System.Drawing.Size(1284, 24)
        Me.MenuStrip1.TabIndex = 18
        Me.MenuStrip1.Text = "MenuStrip1"
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
        Me.EfectosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DesenFOQUEEToolStripMenuItem, Me.DesenfocarToolStripMenuItem, Me.CuadrículaToolStripMenuItem, Me.SombraDeVidrioToolStripMenuItem, Me.SdaToolStripMenuItem, Me.RadmiToolStripMenuItem})
        Me.EfectosToolStripMenuItem.Name = "EfectosToolStripMenuItem"
        Me.EfectosToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.EfectosToolStripMenuItem.Text = "Efectos"
        '
        'DesenfocarToolStripMenuItem
        '
        Me.DesenfocarToolStripMenuItem.Name = "DesenfocarToolStripMenuItem"
        Me.DesenfocarToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.DesenfocarToolStripMenuItem.Text = "Desenfocar"
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
        Me.RadmiToolStripMenuItem.Name = "RadmiToolStripMenuItem"
        Me.RadmiToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.RadmiToolStripMenuItem.Text = "Ruido"
        '
        'DesenFOQUEEToolStripMenuItem
        '
        Me.DesenFOQUEEToolStripMenuItem.Name = "DesenFOQUEEToolStripMenuItem"
        Me.DesenFOQUEEToolStripMenuItem.Size = New System.Drawing.Size(164, 22)
        Me.DesenFOQUEEToolStripMenuItem.Text = "Distorsión"
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
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PictureBox2)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.SplitContainer1.Panel2MinSize = 165
        Me.SplitContainer1.Size = New System.Drawing.Size(1284, 668)
        Me.SplitContainer1.SplitterDistance = 1115
        Me.SplitContainer1.TabIndex = 28
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1113, 666)
        Me.Panel1.TabIndex = 0
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Padding = New System.Windows.Forms.Padding(5)
        Me.PictureBox1.Size = New System.Drawing.Size(1113, 666)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
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
        Me.ClientSize = New System.Drawing.Size(1284, 716)
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
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
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
    Friend WithEvents DesenfocarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents DesenFOQUEEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
