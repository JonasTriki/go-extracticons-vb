Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class GoGroupBox

    Dim m_BackgroundColor As Color = Color.FromArgb(255, 255, 255)

    Dim m_ForeColor As Color = Color.FromArgb(64, 64, 64)
    Dim m_Font As New Font("Segoe UI", 9.0, FontStyle.Regular)

    Dim m_BorderColor As Color = Color.FromArgb(180, 180, 180)
    Dim m_BorderSize As Single = 1

    Dim m_Title As String

    Public Function DrawArc(ByVal Rectangle As Rectangle, Optional ByVal Radius As Integer = 5) As GraphicsPath

        Dim Path As New GraphicsPath

        Path.AddArc(Rectangle.X, Rectangle.Y, Radius, Radius, 180, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Y, Radius, Radius, 270, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Height - Radius, Radius, Radius, 0, 90)
        Path.AddArc(Rectangle.X, Rectangle.Height - Radius, Radius, Radius, 90, 90)
        Path.CloseFigure()

        Return Path

    End Function

    Public Sub DrawTextToGraphics(ByVal g As Graphics, ByVal textToDraw As String, ByVal sizeToControl As Size, ByVal f As Font, ByVal foreColor As Color)

        Dim sb As New SolidBrush(foreColor)
        Dim sf As New StringFormat(StringFormatFlags.NoWrap)
        sf.Trimming = StringTrimming.EllipsisCharacter
        Dim ms As SizeF = g.MeasureString(textToDraw, f, sizeToControl, sf)
        Dim bounds As New RectangleF(New PointF((sizeToControl.Width - ms.Width) / 2, (sizeToControl.Height - ms.Height) / 2), New SizeF(sizeToControl.Width, sizeToControl.Height))

        g.DrawString(textToDraw, f, sb, bounds, sf)

    End Sub

    ''' <summary>
    ''' Gets or sets the font color to the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the font to the control.")> <Browsable(True)> _
    Public Shadows Property Font As Font
        Get
            Return m_Font
        End Get
        Set(ByVal value As Font)
            m_Font = value
            Me.Invalidate()
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the fore color to the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the fore color to the control.")> <Browsable(True)> _
    Public Shadows Property ForeColor As Color
        Get
            Return m_ForeColor
        End Get
        Set(ByVal value As Color)
            m_ForeColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the title to the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the title to the control.")> _
    Public Property Title As String
        Get
            Return m_Title
        End Get
        Set(ByVal value As String)
            m_Title = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the background color.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the background color.")> _
    Public Property BackgroundColor As Color
        Get
            Return m_BackgroundColor
        End Get
        Set(ByVal value As Color)
            m_BackgroundColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the border size on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the border size on the control.")> _
    Public Property BorderSize As Single
        Get
            Return m_BorderSize
        End Get
        Set(ByVal value As Single)
            m_BorderSize = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the border color on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the border color on the control.")> _
    Public Property BorderColor As Color
        Get
            Return m_BorderColor
        End Get
        Set(ByVal value As Color)
            m_BorderColor = value
            Me.Invalidate()
        End Set
    End Property

    Private Sub GoGroupBox_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        'Get the info for drawing text...
        Dim sb As New SolidBrush(m_ForeColor)
        Dim sf As New StringFormat(StringFormatFlags.NoWrap)
        sf.Trimming = StringTrimming.EllipsisCharacter
        Dim ms As SizeF = e.Graphics.MeasureString(m_Title, m_Font, Me.Size, sf)
        Dim bounds As New RectangleF(New PointF((Me.Width - ms.Width) / 2, 0), New SizeF(Me.Width, Me.Height))

        'Draw the border...
        e.Graphics.DrawPath(New Pen(m_BorderColor, m_BorderSize), DrawArc(New Rectangle(0, ms.Height / 2, Me.Width - 1, Me.Height - 1)))

        'Draw the rectangle background for the text...
        e.Graphics.FillRectangle(New SolidBrush(m_BackgroundColor), New Rectangle((Me.Width - ms.Width) / 2, 0, ms.Width, ms.Height))

        'Draw the text with the generated info...
        e.Graphics.DrawString(m_Title, m_Font, sb, bounds, sf)

    End Sub

    Private Sub GoGroupBox_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub

    <EditorBrowsable(EditorBrowsableState.Never)> <Browsable(False)> _
    Public Shadows Property BackColor As Color
        Get
        End Get
        Set(ByVal value As Color)
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Never)> <Browsable(False)> _
    Public Shadows Property BackgroundImage As Image
        Get
            Return Nothing
        End Get
        Set(ByVal value As Image)
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Never)> <Browsable(False)> _
    Public Shadows Property BackgroundImageLayout As ImageLayout
        Get
            Return ImageLayout.Tile
        End Get
        Set(ByVal value As ImageLayout)
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Never)> <Browsable(False)> _
    Public Shadows Property BorderStyle As BorderStyle
        Get
            Return BorderStyle.None
        End Get
        Set(ByVal value As BorderStyle)
        End Set
    End Property
End Class
