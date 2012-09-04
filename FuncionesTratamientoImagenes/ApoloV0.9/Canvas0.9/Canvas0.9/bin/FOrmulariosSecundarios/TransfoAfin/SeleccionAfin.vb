Public Class SeleccionAfin

    

    Private Sub Label1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        Label1.ForeColor = Color.Black
        Dim fuente As New Font("Modern No. 20", 12, FontStyle.Underline, GraphicsUnit.Point)
        Label1.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Black
        Dim fuente As New Font("Modern No. 20", 12, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub Label3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseEnter
        Label3.ForeColor = Color.Black
        Dim fuente As New Font("Modern No. 20", 12, FontStyle.Underline, GraphicsUnit.Point)
        Label3.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label3.MouseLeave
        Label3.ForeColor = Color.Black
        Dim fuente As New Font("Modern No. 20", 12, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Close()
        Afin.ShowDialog()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click
        Me.Close()
        TAfinPers.ShowDialog()
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click
        Me.Close()
    End Sub

    Private Sub Label2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseEnter
        Label2.ForeColor = Color.Black
        Dim fuente As New Font("Modern No. 20", 12, FontStyle.Underline, GraphicsUnit.Point)
        Label2.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Hand
    End Sub

    Private Sub Label2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label2.MouseLeave
        Label2.ForeColor = Color.Black
        Dim fuente As New Font("Modern No. 20", 12, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Font = fuente
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
End Class