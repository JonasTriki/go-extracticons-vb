Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Design
Imports System.Security.Permissions
Imports System.Security
Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.ComTypes

<DefaultEvent("TextChanged")> _
Public Class GoTextBox

    Dim m_Disabled As Boolean
    Dim m_Selected As Boolean
    Dim m_Hover As Boolean

    Dim m_NormalIcon As Image
    Dim m_DisabledIcon As Image

    Dim m_BackgroundColor As Color = Color.FromArgb(255, 255, 255)

    Dim m_NormalBorderColor As Color = Color.FromArgb(160, 160, 160)
    Dim m_HoverBorderColor As Color = Color.FromArgb(130, 130, 130)
    Dim m_SelectedBorderColor As Color = Color.FromArgb(130, 130, 130)
    Dim m_DisabledBorderColor As Color = Color.FromArgb(180, 180, 180)

    Dim m_CutRadius As Integer = 5
    Dim m_ContextMenuStrip As ContextMenuStrip

    Dim m_ShowIcon As Boolean = True

    <Description("Occurs when the text changes.")> _
    Public Shadows Event TextChanged As EventHandler

    Public Sub New()

        InitializeComponent()

        Me.Size = New Size(150, 22)

    End Sub

    Private Sub CheckIconVisibility()

        If m_ShowIcon Then

            pIcon.Visible = True

            txtText.Location = New Point(26, 3)
            txtText.Size = New Size(Me.Width - 30, Me.Height)

            Me.Invalidate()

        Else

            pIcon.Visible = False

            txtText.Location = New Point(4, 3)
            txtText.Size = New Size(Me.Width - 8, Me.Height)

            Me.Invalidate()

        End If

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
    ''' Gets or sets the image to be previewed.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the image to be previewed.")> <DefaultValue(True)> _
    Public Property Icon As Image
        Get
            Return pIcon.BackgroundImage
        End Get
        Set(ByVal value As Image)
            If Not IsNothing(value) Then
                m_NormalIcon = value
                m_DisabledIcon = GrayScaleConverter.ColorImageToGrayScaleImage(value)
                pIcon.BackgroundImage = IIf(Enabled, m_NormalIcon, m_DisabledIcon)
            Else
                m_NormalIcon = Nothing
                m_DisabledIcon = Nothing
                pIcon.BackgroundImage = Nothing
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the icon should be showed, or not.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the icon should be showed, or not.")> <DefaultValue(True)> _
    Public Property ShowIcon As Boolean
        Get
            Return m_ShowIcon
        End Get
        Set(ByVal value As Boolean)
            m_ShowIcon = value
            CheckIconVisibility()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the cut for the radius on the border.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the cut for the radius on the border.")> <DefaultValue(5)> _
    Public Property CutRadius As Integer
        Get
            Return m_CutRadius
        End Get
        Set(ByVal value As Integer)
            m_CutRadius = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the context menu strip.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the context menu strip.")> <DefaultValue(False)> _
    Public Shadows Property ContextMenuStrip As ContextMenuStrip
        Get
            Return m_ContextMenuStrip
        End Get
        Set(ByVal value As ContextMenuStrip)
            If Not m_ContextMenuStrip Is value Then
                If Not value Is Nothing Then
                    m_ContextMenuStrip = value
                    MyBase.ContextMenuStrip = value
                    txtText.ContextMenuStrip = value
                    pIcon.ContextMenuStrip = value
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the textbox should use the system password char, or not.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the textbox should use the system password char, or not.")> <DefaultValue(False)> _
    Public Property UseSystemPasswordChar As Boolean
        Get
            Return txtText.UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            txtText.UseSystemPasswordChar = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the password char.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the password char.")> _
    Public Property PasswordChar As Char
        Get
            Return txtText.PasswordChar
        End Get
        Set(ByVal value As Char)
            txtText.PasswordChar = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the textbox should be multiline, or not.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the textbox should be multiline, or not.")> <DefaultValue(False)> _
    Public Property MultiLine As Boolean
        Get
            Return txtText.Multiline
        End Get
        Set(ByVal value As Boolean)
            txtText.Multiline = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the textbox should be read only, or not.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the textbox should be read only, or not.")> <DefaultValue(False)> _
    Public Property IsReadOnly As Boolean
        Get
            Return txtText.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            txtText.ReadOnly = value
            txtText.BackColor = m_BackgroundColor
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the text to the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the text to the control.")> <Browsable(True)> _
    Public Shadows Property Text As String
        Get
            Return txtText.Text
        End Get
        Set(ByVal value As String)
            txtText.Text = value
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
    ''' Gets or sets the normal border color.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the normal border color.")> _
    Public Property NormalBorderColor As Color
        Get
            Return m_NormalBorderColor
        End Get
        Set(ByVal value As Color)
            m_NormalBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the hover border color.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the hover border color.")> _
    Public Property HoverBorderColor As Color
        Get
            Return m_HoverBorderColor
        End Get
        Set(ByVal value As Color)
            m_HoverBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the selected border color.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the selected border color.")> _
    Public Property SelectedBorderColor As Color
        Get
            Return m_SelectedBorderColor
        End Get
        Set(ByVal value As Color)
            m_SelectedBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the disabled border color.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the disabled border color.")> _
    Public Property DisabledBorderColor As Color
        Get
            Return m_DisabledBorderColor
        End Get
        Set(ByVal value As Color)
            m_DisabledBorderColor = value
            Me.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Return's the control's disabled state.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Return's the control's disabled state.")> _
    Public ReadOnly Property Disabled As Boolean
        Get
            Return m_Disabled
        End Get
    End Property

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

    Private Sub txtText_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtText.TextChanged
        RaiseEvent TextChanged(sender, e)
    End Sub

    Private Sub GoTextBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Invalidate()
    End Sub

    Private Sub GoTextBox_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.EnabledChanged

        m_Disabled = Not Enabled

        pIcon.Enabled = Enabled
        pIcon.BackgroundImage = IIf(Enabled, m_NormalIcon, m_DisabledIcon)

        txtText.BackColor = m_BackgroundColor

        Me.Invalidate()

    End Sub

    Private Sub GoTextBox_FontChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FontChanged
        txtText.Font = Me.Font
    End Sub

    Private Sub GoTextBox_ForeColorChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ForeColorChanged
        txtText.ForeColor = Me.ForeColor
    End Sub

    Private Sub GoTextBox_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint

        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

        'Fill the background color...
        e.Graphics.FillPath(New SolidBrush(m_BackgroundColor), DrawArc(New Rectangle(0, 0, Me.Width, Me.Height), m_CutRadius))

        'Draw the border...
        If m_Disabled Then
            e.Graphics.DrawPath(New Pen(m_DisabledBorderColor, 1), DrawArc(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), m_CutRadius))
        ElseIf m_Selected Then
            e.Graphics.DrawPath(New Pen(m_SelectedBorderColor, 1), DrawArc(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), m_CutRadius))
        ElseIf m_Hover Then
            e.Graphics.DrawPath(New Pen(m_HoverBorderColor, 1), DrawArc(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), m_CutRadius))
        Else
            e.Graphics.DrawPath(New Pen(m_NormalBorderColor, 1), DrawArc(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), m_CutRadius))
        End If

        If m_ShowIcon Then

            'Draw the border line, for the icon box...
            If m_Disabled Then
                e.Graphics.DrawLine(New Pen(m_DisabledBorderColor, 1), 22, 0, 22, Me.Height - 1)
            ElseIf m_Selected Then
                e.Graphics.DrawLine(New Pen(m_SelectedBorderColor, 1), 22, 0, 22, Me.Height - 1)
            ElseIf m_Hover Then
                e.Graphics.DrawLine(New Pen(m_HoverBorderColor, 1), 22, 0, 22, Me.Height - 1)
            Else
                e.Graphics.DrawLine(New Pen(m_NormalBorderColor, 1), 22, 0, 22, Me.Height - 1)
            End If

        End If

    End Sub

    Private Sub Controls_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave, txtText.MouseLeave, pIcon.MouseLeave
        If Not m_Selected Then
            m_Hover = False
            Me.Invalidate()
        End If
    End Sub

    Private Sub Controls_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter, txtText.MouseEnter, pIcon.MouseEnter
        If Not m_Selected Then
            m_Hover = True
            Me.Invalidate()
        End If
    End Sub

    Private Sub Controls_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus, Me.GotFocus, txtText.GotFocus, pIcon.GotFocus
        If Not m_Selected Then
            Focus()
            m_Selected = True
            m_Hover = False
            Me.Invalidate()
            txtText.Focus()
            txtText.Select()
        End If
    End Sub

    Private Sub Controls_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, txtText.MouseDown, pIcon.MouseDown
        m_Selected = True
        m_Hover = False
        Me.Invalidate()
        txtText.Focus()
        txtText.Select()
    End Sub

    Private Sub Controls_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave, Me.Leave
        If m_Hover Or m_Selected Then
            m_Hover = False
            m_Selected = False
            Me.Invalidate()
        End If
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