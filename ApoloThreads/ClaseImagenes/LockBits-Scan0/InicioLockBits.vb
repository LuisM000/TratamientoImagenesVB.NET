Public Class InicioLockBits

    Private Sub InicioLockBits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each c As Object In Me.Controls
            If c.GetType Is GetType(Label) Then
                AddHandler DirectCast(c, Label).MouseEnter, AddressOf dentroMouse
                AddHandler DirectCast(c, Label).MouseLeave, AddressOf fueraMouse
            End If
        Next
    End Sub
    Sub dentroMouse(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Hand
        DirectCast(sender, Label).Font = New Font(Label1.Font, FontStyle.Bold)
    End Sub
    Sub fueraMouse(ByVal sender As Object, ByVal e As System.EventArgs)
        Me.Cursor = Cursors.Default
        DirectCast(sender, Label).Font = New Font(Label1.Font, FontStyle.Regular)
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Dim Process1 As New Process
        Process1.StartInfo.RedirectStandardOutput = True
        Process1.StartInfo.FileName = System.IO.Directory.GetCurrentDirectory().ToString & "\SubprogramasApolo\ImageMDI.exe"
        Process1.StartInfo.UseShellExecute = False
        Process1.StartInfo.CreateNoWindow = True
        Process1.Start()
        'A la espera de que se cierre...
        Process1.WaitForExit()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Dim Process1 As New Process
        Process1.StartInfo.RedirectStandardOutput = True
        Process1.StartInfo.FileName = System.IO.Directory.GetCurrentDirectory().ToString & "\SubprogramasApolo\WebCam.exe"
        Process1.StartInfo.UseShellExecute = False
        Process1.StartInfo.CreateNoWindow = True
        Process1.Start()
        'A la espera de que se cierre...
        Process1.WaitForExit()
    End Sub
End Class