Imports System.Drawing.Drawing2D

Public Class frmIconColorDepthChangerFromIcon

    Dim m_NewIcon As Icon
    Dim m_CurrentIcon As Icon

    Dim CanSetIsOK As Boolean = True
    Public IsOK As Boolean = False
    Public ResultIcon As Icon

    Public Sub New(ByVal CurrentIcon As Icon)

        InitializeComponent()

        m_CurrentIcon = CurrentIcon
        m_NewIcon = m_CurrentIcon
        pIcon.Invalidate()
        pIconNew.Invalidate()

    End Sub

    Public Function DrawArc(ByVal Rectangle As Rectangle, Optional ByVal Radius As Integer = 4) As GraphicsPath

        Dim Path As New GraphicsPath

        Path.AddArc(Rectangle.X, Rectangle.Y, Radius, Radius, 180, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Y, Radius, Radius, 270, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Height - Radius, Radius, Radius, 0, 90)
        Path.AddArc(Rectangle.X, Rectangle.Height - Radius, Radius, Radius, 90, 90)
        Path.CloseFigure()

        Return Path

    End Function

    Private Sub frmIconColorDepthChangerFromIcon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmIconColorDepthChangerFromIcon_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If CanSetIsOK Then
            IsOK = False
        End If
    End Sub

    Private Sub pIcon_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pIcon.Paint

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        If Not IsNothing(m_CurrentIcon) Then

            If m_CurrentIcon.Height > pIcon.Height - 25 Or m_CurrentIcon.Width > pIcon.Width - 25 Then

                Dim f As New Font("Segoe UI", 9.0, FontStyle.Regular)
                Dim sb As New SolidBrush(Color.FromArgb(64, 64, 64))
                Dim sf As New StringFormat(StringFormatFlags.LineLimit)
                sf.Trimming = StringTrimming.EllipsisWord
                Dim ms As SizeF = e.Graphics.MeasureString("Ikonet er for stort til å bli forhåndsvist!", f, pIcon.Size, sf)
                Dim bounds As New RectangleF(New PointF((pIcon.Width - ms.Width) / 2, (pIcon.Height - ms.Height) / 2), New SizeF(pIcon.Width, pIcon.Height))

                e.Graphics.DrawString("Ikonet er for stort til å bli forhåndsvist!", f, sb, bounds, sf)

            Else

                If pIcon.Height = m_CurrentIcon.Height - 25 And pIcon.Width = m_CurrentIcon.Width - 25 Then

                    e.Graphics.DrawIcon(m_CurrentIcon, 25, 25)

                ElseIf pIcon.Height = m_CurrentIcon.Height Then

                    e.Graphics.DrawIcon(m_CurrentIcon, 25, (pIcon.Height - m_CurrentIcon.Height) / 2)

                ElseIf pIcon.Width = m_CurrentIcon.Width Then

                    e.Graphics.DrawIcon(m_CurrentIcon, (pIcon.Width - m_CurrentIcon.Width) / 2, 25)

                Else

                    e.Graphics.DrawIcon(m_CurrentIcon, (pIcon.Width - m_CurrentIcon.Width) / 2, (pIcon.Height - m_CurrentIcon.Height) / 2)

                End If

            End If

            llCurrentIconColorDepth.Text = m_CurrentIcon.Width & " x " & m_CurrentIcon.Height & " - " & New IconInfo(m_CurrentIcon).ColorDepth & "-Bits"

        End If

        e.Graphics.DrawPath(New Pen(Color.FromArgb(197, 197, 197), 1), DrawArc(New Rectangle(0, 0, pIcon.Width - 1, pIcon.Height - 1), 5))

        e.Graphics.Dispose()

    End Sub

    Private Sub pIconNew_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pIconNew.Paint

        m_NewIcon = IconHelper.ChangeIconColorDepth(m_NewIcon, ColorDepth.Depth8Bit)

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        If Not IsNothing(m_NewIcon) Then

            If m_NewIcon.Height > pIcon.Height - 25 Or m_NewIcon.Width > pIcon.Width - 25 Then

                Dim f As New Font("Segoe UI", 9.0, FontStyle.Regular)
                Dim sb As New SolidBrush(Color.FromArgb(64, 64, 64))
                Dim sf As New StringFormat(StringFormatFlags.LineLimit)
                sf.Trimming = StringTrimming.EllipsisWord
                Dim ms As SizeF = e.Graphics.MeasureString("Ikonet er for stort til å bli forhåndsvist!", f, pIcon.Size, sf)
                Dim bounds As New RectangleF(New PointF((pIcon.Width - ms.Width) / 2, (pIcon.Height - ms.Height) / 2), New SizeF(pIcon.Width, pIcon.Height))

                e.Graphics.DrawString("Ikonet er for stort til å bli forhåndsvist!", f, sb, bounds, sf)

            Else

                If pIcon.Height = m_NewIcon.Height - 25 And pIcon.Width = m_NewIcon.Width - 25 Then

                    e.Graphics.DrawIcon(m_NewIcon, 25, 25)

                ElseIf pIcon.Height = m_NewIcon.Height Then

                    e.Graphics.DrawIcon(m_NewIcon, 25, (pIcon.Height - m_NewIcon.Height) / 2)

                ElseIf pIcon.Width = m_NewIcon.Width Then

                    e.Graphics.DrawIcon(m_NewIcon, (pIcon.Width - m_NewIcon.Width) / 2, 25)

                Else

                    e.Graphics.DrawIcon(m_NewIcon, (pIcon.Width - m_NewIcon.Width) / 2, (pIcon.Height - m_NewIcon.Height) / 2)

                End If

            End If

            llNewIconColorDepth.Text = m_NewIcon.Width & " x " & m_NewIcon.Height & " - " & New IconInfo(m_NewIcon).ColorDepth & "-Bits"

        End If

        e.Graphics.DrawPath(New Pen(Color.FromArgb(197, 197, 197), 1), DrawArc(New Rectangle(0, 0, pIcon.Width - 1, pIcon.Height - 1), 5))

        e.Graphics.Dispose()

    End Sub

    Private Sub cmIconColorDepths_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmIconColorDepths.SelectedIndexChanged

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        CanSetIsOK = False
        IsOK = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        CanSetIsOK = True
        Me.Close()
    End Sub
End Class