Imports System.IO
Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class IconItem

#Region " Class IsSelectedEventArgs "

    <Description("Provides data for the IsSelected event.")> _
    Public Class IsSelectedEventArgs
        Inherits EventArgs

        Private m_Icon As Icon
        Private m_ColorDepth As Integer
        Private m_Colors As Long
        Private m_IconSize As String
        Private m_Size As Size

        <Description("Initializes a new instance of the IsSelectedEventArgs class.")> _
        Public Sub New(ByVal Icon As Icon, ByVal ColorDepth As Integer, ByVal Colors As Long, ByVal Size As Size, ByVal IconSize As String)
            m_Icon = Icon
            m_ColorDepth = ColorDepth
            m_Colors = Colors
            m_IconSize = IconSize
            m_Size = Size
        End Sub

        <Description("Returns the control's icon.")> _
        Public ReadOnly Property Icon() As Icon
            Get
                Return m_Icon
            End Get
        End Property

        <Description("Returns the control's icon's colordepth.")> _
        Public ReadOnly Property ColorDepth() As Integer
            Get
                Return m_ColorDepth
            End Get
        End Property

        <Description("Returns the control's icon's color count.")> _
        Public ReadOnly Property Colors() As Long
            Get
                Return m_Colors
            End Get
        End Property

        <Description("Returns the control's icon's size in pixels.")> _
        Public ReadOnly Property Size() As Size
            Get
                Return m_Size
            End Get
        End Property

        <Description("Returns the control's icon's size.")> _
        Public ReadOnly Property IconSize() As String
            Get
                Return m_IconSize
            End Get
        End Property

    End Class

#End Region

    Dim m_Selected As Boolean = False
    Dim m_Hover As Boolean = False

    Dim m_Icon As Icon
    Dim m_IconDeth As String

    Dim m_bpp As String
    Dim m_NoIcon As String
    Dim m_EmptyIcon As String

    Dim m_byte As String
    Dim m_YB As String
    Dim m_ZB As String
    Dim m_EB As String
    Dim m_PB As String
    Dim m_TB As String
    Dim m_GB As String
    Dim m_MB As String
    Dim m_KB As String

    Dim m_GetFileSize As String

    Dim m_ForeColor As Color = Color.FromArgb(64, 64, 64)
    Dim m_Font As Font = Me.Font
    Dim m_Text As String

    <Description("Occurs when the control select's.")> _
    Public Event IsSelected(ByVal sender As Object, ByVal e As IsSelectedEventArgs)

    Public Sub New()

        InitializeComponent()

        Me.Size = New Size(102, 120)

    End Sub

    Public Sub New(ByVal Icon As Icon, ByVal bpp As String, ByVal NoIcon As String, ByVal EmptyIcon As String, ByVal _byte As String, ByVal YB As String, ByVal ZB As String, ByVal EB As String, ByVal PB As String, ByVal TB As String, ByVal GB As String, ByVal MB As String, ByVal KB As String)

        InitializeComponent()

        Me.Size = New Size(102, 120)

        m_Icon = Icon

        m_bpp = bpp

        m_EmptyIcon = m_EmptyIcon

        m_NoIcon = NoIcon

        m_byte = _byte

        m_YB = YB

        m_ZB = ZB

        m_EB = EB

        m_PB = PB

        m_TB = TB

        m_GB = GB

        m_MB = MB

        m_KB = KB

        IconPanel.Invalidate()

        CheckSizeAndColorDepth()

    End Sub

    Private Function GetFileSize(ByVal Size As Long) As String

        Dim ByteFileSize As Long = Size

        If ByteFileSize <= 999 Then
            'byte <= 999 byte
            m_GetFileSize = ByteFileSize & " " & m_byte
        ElseIf ByteFileSize >= 1.0E+24 Then
            'YB >= 100000000000000000 byte, Value / 1.2089258196146291E+18
            m_GetFileSize = Math.Round((ByteFileSize / 1.2089258196146291E+18), 2) & " " & m_YB
        ElseIf ByteFileSize >= 1.0E+21 Then
            'ZB >= 1000000000000000 byte, Value / 1.1805916207174114E+17
            m_GetFileSize = Math.Round((ByteFileSize / 1.1805916207174114E+17), 2) & " " & m_ZB
        ElseIf ByteFileSize >= 1000000000000000000 Then
            'EB >= 10000000000000 byte, Value / 1152921504606846976
            m_GetFileSize = Math.Round((ByteFileSize / 1152921504606846976), 2) & " " & m_EB
        ElseIf ByteFileSize >= 1000000000000000 Then
            'PB >= 100000000000 byte, Value / 1125899906842624
            m_GetFileSize = Math.Round((ByteFileSize / 1125899906842624), 2) & " " & m_PB
        ElseIf ByteFileSize >= 1000000000000 Then
            'TB >= 1000000000 byte, Value / 1099511627776
            m_GetFileSize = Math.Round((ByteFileSize / 1099511627776), 2) & " " & m_TB
        ElseIf ByteFileSize >= 1000000000 Then
            'GB >= 10000000 byte, Value / 1073741824
            m_GetFileSize = Math.Round((ByteFileSize / 1073741824), 2) & " " & m_GB
        ElseIf ByteFileSize >= 1000000 Then
            'MB >= 1000000 byte, Value / 1048576
            m_GetFileSize = Math.Round((ByteFileSize / 1048576), 2) & " " & m_MB
        ElseIf ByteFileSize >= 1000 Then
            'KB >= 1000 byte, Value / 1024
            m_GetFileSize = Math.Round((ByteFileSize / 1024), 2) & " " & m_KB
        End If

        Return m_GetFileSize

    End Function

    Public Sub DrawTextToGraphics(ByVal g As Graphics, ByVal textToDraw As String, ByVal sizeToControl As Size, ByVal f As Font, ByVal foreColor As Color)

        Dim sb As New SolidBrush(foreColor)
        Dim sf As New StringFormat(StringFormatFlags.NoWrap)
        sf.Trimming = StringTrimming.EllipsisCharacter
        Dim ms As SizeF = g.MeasureString(textToDraw, f, sizeToControl, sf)
        Dim bounds As New RectangleF(New PointF((sizeToControl.Width - ms.Width) / 2, (sizeToControl.Height - ms.Height) / 2), New SizeF(sizeToControl.Width, sizeToControl.Height))

        g.DrawString(textToDraw, f, sb, bounds, sf)

    End Sub

    Private Sub CheckSizeAndColorDepth()

        m_Text = m_NoIcon

        If m_Selected Then
            m_Font = New Font(Me.Font, DirectCast(IIf(m_Selected, FontStyle.Bold, FontStyle.Regular), FontStyle))
        ElseIf m_Hover Then
            m_Font = New Font(Me.Font, FontStyle.Underline)
        Else
            m_Font = New Font(Me.Font, FontStyle.Regular)
        End If

        If Not IsNothing(m_Icon) Then

            Dim Size As Size = m_Icon.Size
            Dim ColorDepth As String = New IconInfo(m_Icon).ColorDepth & m_bpp

            m_Text = Size.Width & "x" & Size.Height & " - " & ColorDepth

        Else

            m_Text = m_NoIcon

        End If

        SizeAndColorDepthLabel.Invalidate()

    End Sub

    Public Function DrawArc(ByVal Rectangle As Rectangle, Optional ByVal Radius As Integer = 5) As GraphicsPath

        Dim Path As New GraphicsPath

        Path.AddArc(Rectangle.X, Rectangle.Y, Radius, Radius, 180, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Y, Radius, Radius, 270, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Height - Radius, Radius, Radius, 0, 90)
        Path.AddArc(Rectangle.X, Rectangle.Height - Radius, Radius, Radius, 90, 90)
        Path.CloseFigure()

        Return Path

    End Function

    ''' <summary>
    ''' Return's the controls selected state.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Return's the control's selected state.")> _
    Public ReadOnly Property Selected As Boolean
        Get
            Return m_Selected
        End Get
    End Property

    ''' <summary>
    ''' Return's the controls hover state.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Return's the control's hover state.")> _
    Public ReadOnly Property Hover As Boolean
        Get
            Return m_Hover
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets the icon on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the icon on the control.")> _
    Public Property Icon As Icon
        Get
            Return m_Icon
        End Get
        Set(ByVal value As Icon)
            m_Icon = value
            CheckSizeAndColorDepth()
            IconPanel.Invalidate()
        End Set
    End Property

    Private Sub Controls_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles IconPanel.MouseLeave, SizeAndColorDepthLabel.MouseLeave
        If Not m_Selected Then
            m_Hover = False
            CheckSizeAndColorDepth()
        End If
    End Sub

    Private Sub Controls_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles IconPanel.MouseEnter, SizeAndColorDepthLabel.MouseEnter
        If Not m_Selected Then
            m_Selected = False
            m_Hover = True
            CheckSizeAndColorDepth()
        End If
    End Sub

    Private Sub Controls_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus, IconPanel.GotFocus
        Focus()
        m_Selected = True
        m_Hover = False
        Dim IconStream As New MemoryStream : m_Icon.Save(IconStream) : RaiseEvent IsSelected(sender, New IsSelectedEventArgs(m_Icon, New IconInfo(m_Icon).ColorDepth, New IconInfo(m_Icon).ColorCount, m_Icon.Size, GetFileSize(IconStream.Length)))
        IconPanel.Invalidate()
        CheckSizeAndColorDepth()
    End Sub

    Private Sub Controls_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles IconPanel.MouseDown, SizeAndColorDepthLabel.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Focus()
            m_Selected = True
            m_Hover = False
            Dim IconStream As New MemoryStream : m_Icon.Save(IconStream) : RaiseEvent IsSelected(sender, New IsSelectedEventArgs(m_Icon, New IconInfo(m_Icon).ColorDepth, New IconInfo(m_Icon).ColorCount, m_Icon.Size, GetFileSize(IconStream.Length)))
            IconPanel.Invalidate()
            CheckSizeAndColorDepth()
        End If
    End Sub

    Private Sub Controls_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave, IconPanel.Leave
        m_Hover = False
        m_Selected = False
        IconPanel.Invalidate()
        CheckSizeAndColorDepth()
    End Sub

    Private Sub IconItem_FontChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FontChanged
        m_Font = Me.Font
        Me.Invalidate()
    End Sub

    Private Sub IconPanel_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles IconPanel.Paint

        If Not IsNothing(m_Icon) Then

            If m_Icon.Height > IconPanel.Height Or m_Icon.Width > IconPanel.Width Then

                e.Graphics.DrawIcon(m_Icon, New Rectangle(0, 0, IconPanel.Width, IconPanel.Height))

            Else

                e.Graphics.DrawIcon(m_Icon, IIf(m_Icon.Width < IconPanel.Width, (IconPanel.Width - m_Icon.Width) / 2, 0), IIf(m_Icon.Height < IconPanel.Height, (IconPanel.Height - m_Icon.Height) / 2, 0))

            End If

        End If

        Dim BorderPen As New Pen(Color.FromArgb(166, 166, 166), 1)

        If m_Selected Then
            BorderPen.Color = Color.FromArgb(166, 166, 166)
        ElseIf m_Hover Then
            BorderPen.Color = Color.FromArgb(227, 227, 227)
        Else
            BorderPen.Color = Color.FromArgb(255, 255, 255)
        End If

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        e.Graphics.DrawPath(BorderPen, DrawArc(New Rectangle(0, 0, IconPanel.Width - 1, IconPanel.Height - 1)))

        BorderPen.Dispose()

        e.Graphics.Dispose()

    End Sub

    Private Sub SizeAndColorDepthLabel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SizeAndColorDepthLabel.Paint

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        DrawTextToGraphics(e.Graphics, m_Text, SizeAndColorDepthLabel.Size, m_Font, m_ForeColor)

    End Sub

    Private Sub IconItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub
End Class
