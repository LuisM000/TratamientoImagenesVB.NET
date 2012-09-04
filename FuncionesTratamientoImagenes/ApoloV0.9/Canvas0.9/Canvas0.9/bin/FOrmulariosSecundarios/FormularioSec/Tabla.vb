Imports WindowsApplication1.Class2

Public Class Tabla

    Private Sub ExportarToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExportarToolStripMenuItem.Click
        Dim objetoform As New trataformu 'Objeto de la clase para formulario
        objetoform.PasarExcel(DataGridView1)
    End Sub
End Class