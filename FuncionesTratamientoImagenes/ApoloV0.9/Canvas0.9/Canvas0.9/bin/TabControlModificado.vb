Imports System.Drawing.Drawing2D
Public Class TabControlModificado

#Region " Colors "

    Dim clrBgGradientLeft As Color = Color.FromArgb(255, 235, 233, 237)
    Dim clrBgGradientRight As Color = Color.FromArgb(255, 251, 250, 251)
    Dim clrBorderBorder As Color = Color.FromArgb(255, 153, 175, 212)
    Dim clrBorderFill As Color = Color.FromArgb(255, 194, 207, 229)
    Dim clrBorderHighlight As Color = Color.FromArgb(255, 226, 229, 238)

    Dim clrTabBorder As Color = Color.FromArgb(255, 157, 157, 161)
    Dim clrTabShadow As Color = Color.FromArgb(255, 243, 243, 247)
    Dim clrTabGradientTop As Color = Color.White
    Dim clrTabGradientBottom As Color = Color.FromArgb(255, 244, 244, 248)

#End Region

#Region " Constants "

    Dim tabHeight As Integer = 20

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DrawMode = TabDrawMode.OwnerDrawFixed

        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
                 ControlStyles.DoubleBuffer Or _
                 ControlStyles.ResizeRedraw Or _
                 ControlStyles.UserPaint, True)

    End Sub

    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaintBackground(e)

        Dim totalRect As New Rectangle(0, 0, Me.Width, Me.Height)

        'gradient background
        'Dim bgGradient As New LinearGradientBrush(totalRect, clrBgGradientLeft, clrBgGradientRight, LinearGradientMode.Horizontal)
        'e.Graphics.FillRectangle(bgGradient, totalRect)

        'Brushes / pens
        Dim borderFill As New SolidBrush(clrBorderFill)
        Dim borderBorder As New Pen(clrBorderBorder)
        Dim borderHighlight As New Pen(clrBorderHighlight)

        'Rectangles
        Dim rectBorderFill As New Rectangle(2, tabHeight + 2, totalRect.Width - 4, totalRect.Height - tabHeight - 3)
        Dim rectBorderBorder As New Rectangle(3, tabHeight + 4, totalRect.Width - 7, totalRect.Height - tabHeight - 8)
        Dim rectBorderHighlight As New Rectangle(1, tabHeight + 1, totalRect.Width - 3, totalRect.Height - tabHeight - 3)
        Dim rectBorderOuter As New Rectangle(0, tabHeight, totalRect.Width - 1, totalRect.Height - tabHeight - 1)

        e.Graphics.FillRectangle(borderFill, rectBorderFill)
        e.Graphics.DrawRectangle(borderBorder, rectBorderBorder)
        e.Graphics.DrawRectangle(borderHighlight, rectBorderHighlight)

        'Draw rounder outer border (requires separate lines instead of DrawRectangle)
        e.Graphics.DrawLine(borderBorder, _
                            0, _
                            rectBorderOuter.Y + 2, _
                            0, _
                            rectBorderOuter.Bottom - 2)     'Left side
        e.Graphics.DrawLine(borderBorder, _
                            rectBorderOuter.Right, _
                            rectBorderOuter.Y + 2, _
                            rectBorderOuter.Right, _
                            rectBorderOuter.Bottom - 2)     'Right side
        e.Graphics.DrawLine(borderBorder, _
                            2, _
                            rectBorderOuter.Y, _
                            rectBorderOuter.Width - 2, _
                            rectBorderOuter.Y)              'Top
        e.Graphics.DrawLine(borderBorder, _
                            2, _
                            rectBorderOuter.Bottom, _
                            rectBorderOuter.Width - 2, _
                            rectBorderOuter.Bottom)         'Bottom

        'Corner points
        Dim bm As Bitmap = New Bitmap(1, 1)
        bm.SetPixel(0, 0, clrBorderBorder)
        e.Graphics.DrawImageUnscaled(bm, 1, rectBorderOuter.Y + 1)      'Top-left
        e.Graphics.DrawImageUnscaled(bm, 1, rectBorderOuter.Bottom - 1) 'Bottom-left
        e.Graphics.DrawImageUnscaled(bm, rectBorderOuter.Right - 1, rectBorderOuter.Y + 1)  'Top-right
        e.Graphics.DrawImageUnscaled(bm, rectBorderOuter.Right - 1, rectBorderOuter.Bottom - 1)  'Bottom-right

        borderFill.Dispose()
        borderBorder.Dispose()
        borderHighlight.Dispose()
        bm.Dispose()
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        'Brushes / pens
        Dim borderFill As New SolidBrush(clrBorderFill)
        Dim borderBorder As New Pen(clrBorderBorder)
        Dim tabShadow As New Pen(clrTabShadow)
        Dim inactiveTabBorder As New Pen(clrTabBorder)
        Dim bTabGrad As LinearGradientBrush
        Dim bm As New Bitmap(1, 1)

        ' Draw inactive tab headers
        ' Drawing in reverse order so they overlap properly
        Dim triangleWidth As Integer
        Dim triPoints() As Point
        Dim r As Rectangle

        bm.SetPixel(0, 0, clrTabBorder)
        For i As Integer = Me.TabPages.Count - 1 To 0 Step -1
            r = Me.GetTabRect(i)

            If Me.SelectedIndex <> i Then
                'Resize rectangle
                r = New Rectangle(r.X, r.Y + 4, r.Width + 6, r.Height - 8)
                triangleWidth = r.Height
                bTabGrad = New LinearGradientBrush(New Rectangle(r.X, r.Y, r.Width, r.Height + 1), clrTabGradientTop, clrTabGradientBottom, LinearGradientMode.Vertical)

                'Draw main background part (excluding sloping part)
                e.Graphics.FillRectangle(bTabGrad, r.X + triangleWidth, r.Y, r.Width - triangleWidth, r.Height + 1)
                'Draw part of the sloping background
                e.Graphics.FillRectangle(bTabGrad, r.X + 11, r.Y + 3, 2, 11)

                'Sloping part
                triPoints = New Point() {New Point(r.Left, r.Bottom + 1), _
                                         New Point(r.Left + triangleWidth - 2, r.Bottom + 1), _
                                         New Point(r.Left + triangleWidth - 2, r.Top + 2)}
                e.Graphics.FillPolygon(bTabGrad, triPoints)

                'Border
                e.Graphics.DrawLine(inactiveTabBorder, r.Left, r.Bottom, r.Left + triangleWidth - 2, r.Top + 2)
                e.Graphics.DrawLine(inactiveTabBorder, r.Left + triangleWidth + 2, r.Top, r.Right - 2, r.Top)
                e.Graphics.DrawLine(inactiveTabBorder, r.Right, r.Top + 2, r.Right, r.Bottom)
                e.Graphics.DrawImageUnscaled(bm, r.Right - 1, r.Top + 1)

                'Highlights
                e.Graphics.DrawLine(Pens.White, r.Left + 1, r.Bottom, r.Left + triangleWidth, r.Top + 1)
                e.Graphics.DrawLine(tabShadow, r.Right - 1, r.Top + 3, r.Right - 1, r.Bottom)

                'Left corner (rounded)
                e.Graphics.DrawImageUnscaled(bm, r.Left + triangleWidth - 1, r.Top + 2)
                e.Graphics.DrawImageUnscaled(bm, r.Left + triangleWidth, r.Top + 1)
                e.Graphics.DrawImageUnscaled(bm, r.Left + triangleWidth + 1, r.Top + 1)

                e.Graphics.DrawString(Me.TabPages(i).Text, Me.Font, Brushes.Black, r.X + 20, r.Y + 1)
            End If
        Next

        'Draw active tab header
        If Me.SelectedIndex <> -1 Then
            bm.SetPixel(0, 0, clrBorderBorder)

            'Resize rectangle
            r = Me.GetTabRect(Me.SelectedIndex)
            r = New Rectangle(r.X, r.Y + 2, r.Width + 6, r.Height - 5)

            'Hide part of main tabcontrol border by overlapping with a rectangle
            e.Graphics.FillRectangle(borderFill, r.X + 1, r.Y + 15, r.Width - 1, r.Height - 12)

            'Sloping part
            triangleWidth = r.Height
            bTabGrad = New LinearGradientBrush(New Rectangle(r.X, r.Y + 1, r.Width, r.Height), clrTabGradientTop, clrBorderFill, LinearGradientMode.Vertical)
            e.Graphics.FillRectangle(bTabGrad, r.X + triangleWidth, r.Y + 1, r.Width - triangleWidth, r.Height)
            e.Graphics.FillRectangle(bTabGrad, r.X + 14, r.Y + 3, 2, 14)

            triPoints = New Point() {New Point(r.Left, r.Bottom + 1), _
                                    New Point(r.Left + triangleWidth - 2, r.Bottom + 1), _
                                    New Point(r.Left + triangleWidth - 2, r.Top + 2)}

            'Border
            e.Graphics.FillPolygon(bTabGrad, triPoints)
            e.Graphics.DrawLine(borderBorder, r.Left, r.Bottom, r.Left + triangleWidth - 2, r.Top + 2)
            e.Graphics.DrawLine(borderBorder, r.Left + triangleWidth + 2, r.Top, r.Right - 2, r.Top)
            e.Graphics.DrawLine(borderBorder, r.Right, r.Top + 2, r.Right, r.Bottom)
            e.Graphics.DrawImageUnscaled(bm, r.Right - 1, r.Top + 1)

            'Highlights
            e.Graphics.DrawLine(Pens.White, r.Left + 1, r.Bottom, r.Left + triangleWidth, r.Top + 1)
            e.Graphics.DrawLine(Pens.White, r.Right - 1, r.Top + 3, r.Right - 1, r.Bottom)

            'Left corner (rounded)
            e.Graphics.DrawImageUnscaled(bm, r.Left + triangleWidth - 1, r.Top + 2)
            e.Graphics.DrawImageUnscaled(bm, r.Left + triangleWidth, r.Top + 1)
            e.Graphics.DrawImageUnscaled(bm, r.Left + triangleWidth + 1, r.Top + 1)

            e.Graphics.DrawString(Me.TabPages(Me.SelectedIndex).Text, New Font(Me.Font, FontStyle.Bold), Brushes.Black, r.X + triangleWidth, r.Y + 2)

        End If

        borderFill.Dispose()
        borderBorder.Dispose()
        tabShadow.Dispose()
        'borderHighlight.Dispose()
        inactiveTabBorder.Dispose()
        bm.Dispose()


        'Using Me.Invalidate fixes the glitch, but screws up design-time:
        'Me.Invalidate()
    End Sub


    Protected Overrides Sub OnSelectedIndexChanged(ByVal e As System.EventArgs)
        Me.Invalidate()
        MyBase.OnSelectedIndexChanged(e)
    End Sub

End Class
