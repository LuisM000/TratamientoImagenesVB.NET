Option Explicit On
Option Strict On
Module Inicio

    Public Sub Main()

        If My.Settings.pantallainicial = True Then
            'Ejecutamos nuestra aplicación
            Application.EnableVisualStyles()
            Dim lofrmSplash As New SplashScreen1
            lofrmSplash.ShowDialog()
            Dim loPrincipal As New Principal
            Application.Run(loPrincipal)
        Else
            Dim loPrincipal As New Principal
            Application.Run(loPrincipal)
        End If
    End Sub
End Module



