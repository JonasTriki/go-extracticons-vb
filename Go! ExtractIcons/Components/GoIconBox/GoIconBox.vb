Imports System.Drawing.Drawing2D
Imports System.ComponentModel

<DefaultEvent("IconChanged")> _
Public Class GoIconBox

    Dim m_IconStyle As IconDrawingStyle = IconDrawingStyle.Center

    Dim m_BorderColor As Color = Color.FromArgb(180, 180, 180)
    Dim m_BorderSize As Single = 1

    Dim m_Icon As Icon
    Dim m_ShowBorder As Boolean = True

    <Description("Occurs when the control has changed the icon.")> _
    Public Event IconChanged(ByVal sender As Object, ByVal e As IconChangedEventArgs)

#Region " Class IconChangedEventArgs "

    <Description("Provides data for GoIconBox.IconChanged event.")> _
    Public Class IconChangedEventArgs
        Inherits EventArgs

        Dim m_Icon As Icon
        Dim m_PreviousIcon As Icon

        <Description("Initializes a new instance of the GoIconBox.IconChangedgs class.")> _
        Public Sub New(ByVal Icon As Icon, ByVal PreviousIcon As Icon)
            m_Icon = Icon
            m_PreviousIcon = PreviousIcon
        End Sub

        <Description("Returns the control's icon.")> _
        Public ReadOnly Property Icon() As Icon
            Get
                Return m_Icon
            End Get
        End Property

        <Description("Returns the control's previous icon.")> _
        Public ReadOnly Property PreviousIcon() As Icon
            Get
                Return m_PreviousIcon
            End Get
        End Property

    End Class

#End Region

    Enum IconDrawingStyle

        Normal = 1

        Center = 2

        Stretch = 3

    End Enum

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

    ''' <summary>
    ''' Gets or sets the icon style on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the icon style on the control.")> _
    Public Property IconStyle As IconDrawingStyle
        Get
            Return m_IconStyle
        End Get
        Set(ByVal value As IconDrawingStyle)
            m_IconStyle = value
            Me.Invalidate()
        End Set
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
            RaiseEvent IconChanged(Me, New IconChangedEventArgs(m_Icon, value))
            m_Icon = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the border should be showed, or not.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the border should be showed, or not.")> _
    Public Property ShowBorder As Boolean
        Get
            Return m_ShowBorder
        End Get
        Set(ByVal value As Boolean)
            m_ShowBorder = value
            Me.Invalidate()
        End Set
    End Property

    Private Sub GoIconBox_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        If Not IsNothing(m_Icon) Then
            If m_IconStyle = IconDrawingStyle.Normal Then
                e.Graphics.DrawIcon(m_Icon, New Rectangle(0, 0, m_Icon.Width, m_Icon.Height))
            ElseIf m_IconStyle = IconDrawingStyle.Center Then
                If m_Icon.Height > Me.Height And m_Icon.Width > Me.Width Then
                    e.Graphics.DrawIcon(m_Icon, New Rectangle(0, 0, Me.Width, Me.Height))
                ElseIf m_Icon.Height > Me.Height Then
                    e.Graphics.DrawIcon(m_Icon, New Rectangle(IIf(m_Icon.Width < Me.Width, (Me.Width - m_Icon.Width) / 2, 0), IIf(m_Icon.Height < Me.Height, (Me.Height - m_Icon.Height) / 2, 0), m_Icon.Width, Me.Height))
                ElseIf m_Icon.Width > Me.Width Then
                    e.Graphics.DrawIcon(m_Icon, New Rectangle(IIf(m_Icon.Width < Me.Width, (Me.Width - m_Icon.Width) / 2, 0), IIf(m_Icon.Height < Me.Height, (Me.Height - m_Icon.Height) / 2, 0), Me.Width, m_Icon.Height))
                Else
                    e.Graphics.DrawIcon(m_Icon, IIf(m_Icon.Width < Me.Width, (Me.Width - m_Icon.Width) / 2, 0), IIf(m_Icon.Height < Me.Height, (Me.Height - m_Icon.Height) / 2, 0))
                End If
            ElseIf m_IconStyle = IconDrawingStyle.Stretch Then
                e.Graphics.DrawIcon(m_Icon, New Rectangle(0, 0, Me.Width, Me.Height))
            End If
        End If

        If m_ShowBorder Then
            e.Graphics.DrawPath(New Pen(m_BorderColor, m_BorderSize), DrawArc(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)))
        End If

    End Sub

    Private Sub GoIconBox_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.Invalidate()
    End Sub
End Class
