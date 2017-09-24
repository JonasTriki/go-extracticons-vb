Imports System.IO
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class MultiItem

#Region " Class IsSelectedEventArgs "

    <Description("Provides data for the GoVisualTeam.ToolKit.MultiItem.IsSelected event.")> _
    Public Class IsSelectedEventArgs
        Inherits EventArgs

        Private m_Icon As Icon
        Private m_Title As String
        Private m_Text As String

        <Description("Initializes a new instance of the GoVisualTeam.ToolKit.MultiItem.IsSelectedEventArgs class.")> _
        Public Sub New(ByVal Icon As Icon, ByVal Title As String, ByVal Text As String)
            m_Icon = Icon
            m_Title = Title
            m_Text = Text
        End Sub

        <Description("Returns the control's icon.")> _
        Public ReadOnly Property Icon() As Icon
            Get
                Return m_Icon
            End Get
        End Property

        <Description("Returns the control's icon.")> _
        Public ReadOnly Property Title() As String
            Get
                Return m_Title
            End Get
        End Property

        <Description("Returns the control's icon.")> _
        Public ReadOnly Property Text() As String
            Get
                Return m_Text
            End Get
        End Property

    End Class

#End Region

    Dim m_Selected As Boolean = False
    Dim m_Hover As Boolean = False

    Dim m_FontBoldOnSelect As Boolean = True
    Dim m_FontUnderLineOnHover As Boolean = True

    Dim m_DisabledLineColor As Color = Color.FromArgb(227, 227, 227)
    Dim m_SelectedLineColor As Color = Color.FromArgb(166, 166, 166)

    Dim m_ContextMenuStrip As ContextMenuStrip

    Dim m_HideSelection As Boolean = False

    Dim m_View As Views = Views.Normal

    Dim m_Icon As Icon

    Dim PreviousExtraTitleWidth As Integer

    Dim AllowedToCheckExtraTitle As Boolean = False

    <Description("Occurs when the control select's.")> _
    Public Event IsSelected(ByVal sender As Object, ByVal e As IsSelectedEventArgs)

    Public Sub New()

        InitializeComponent()

        Me.Size = New Size(337, 56)

        LoadView(m_View)

    End Sub

    Public Sub New(ByVal Owner As MultiListBox, ByVal Icon As Icon, ByVal Title As String, ByVal Text As String)

        InitializeComponent()

        Me.Size = New Size(337, 56)

        m_View = Owner.View

        LoadView(m_View)

        Me.Dock = DockStyle.Top

        m_Icon = Icon

        IconBox.Invalidate()

        TitleLabel.Text = Title

        TextLabel.Text = Text

    End Sub

    Public Sub New(ByVal Owner As MultiListBox, ByVal Icon As Icon, ByVal Title As String, ByVal ExtraTitle As String, ByVal Text As String)

        InitializeComponent()

        Me.Size = New Size(337, 56)

        m_View = Owner.View

        LoadView(m_View)

        Me.Dock = DockStyle.Top

        m_Icon = Icon

        IconBox.Invalidate()

        TitleLabel.Text = Title

        ExtraTitleLabel.Text = ExtraTitle

        TextLabel.Text = Text

    End Sub

    Public Sub New(ByVal Icon As Icon, ByVal Title As String, ByVal Text As String)

        InitializeComponent()

        Me.Size = New Size(337, 56)

        LoadView(m_View)

        Me.Dock = DockStyle.Top

        m_Icon = Icon

        IconBox.Invalidate()

        TitleLabel.Text = Title

        TextLabel.Text = Text

    End Sub

    Public Sub New(ByVal Icon As Icon, ByVal Title As String, ByVal ExtraTitle As String, ByVal Text As String)

        InitializeComponent()

        Me.Size = New Size(337, 56)

        LoadView(m_View)

        Me.Dock = DockStyle.Top

        m_Icon = Icon

        IconBox.Invalidate()

        TitleLabel.Text = Text

        ExtraTitleLabel.Text = ExtraTitle

        TextLabel.Text = Title

    End Sub

    Enum Views

        Small = 25

        Normal = 44

        Large = 56

    End Enum

    Private Sub LoadView(ByVal View As Views)

        If View = Views.Small Then

            ExtraTitleLabel.Visible = True

            Me.Height = View

            IconBox.Width = View - 6

            TitleLabel.Location = New Point(22, 4)
            TitleLabel.Width = Me.Width - (View + 2)

            TextLabel.Location = New Point(22, 24)
            TextLabel.Width += Me.Width - (View + 2)

        ElseIf View = Views.Normal Then

            ExtraTitleLabel.Visible = False

            Me.Height = View

            IconBox.Width = View - 6

            TitleLabel.Location = New Point(41, 4)
            TextLabel.Width += Me.Width - (View + 2)

            TextLabel.Location = New Point(41, 24)
            TextLabel.Width += Me.Width - (View + 2)

        ElseIf View = Views.Large Then

            ExtraTitleLabel.Visible = False

            Me.Height = View

            IconBox.Width = View - 6

            TitleLabel.Location = New Point(53, 4)
            TextLabel.Width += Me.Width - (View + 2)

            TextLabel.Location = New Point(53, 24)
            TextLabel.Width += Me.Width - (View + 2)

        End If

    End Sub

    Private Sub SetBorderColor(ByVal Color As Color)

        TopBorder.BackColor = Color

        RightBorder.BackColor = Color

        BottomBorder.BackColor = Color

        LeftBorder.BackColor = Color

    End Sub

    Private Sub CheckAndSetExtraTitleSize()

        Dim w As Integer = ExtraTitleLabel.Width - PreviousExtraTitleWidth

        MsgBox(w)

        ExtraTitleLabel.Location = New Point(ExtraTitleLabel.Location.X - w, ExtraTitleLabel.Location.Y)

        TitleLabel.Width -= w

    End Sub

    Private Sub CheckTitleAndTextLabel()

        If m_Selected Then
            TitleLabel.Font = New Font(TitleLabel.Font.FontFamily.Name, TitleLabel.Font.Size, DirectCast(IIf(m_FontBoldOnSelect, FontStyle.Bold, FontStyle.Regular), FontStyle))
            TextLabel.Font = New Font(TextLabel.Font.FontFamily.Name, TextLabel.Font.Size, FontStyle.Regular)
        ElseIf m_Hover Then
            TitleLabel.Font = New Font(TitleLabel.Font.FontFamily.Name, TitleLabel.Font.Size, DirectCast(IIf(m_FontUnderLineOnHover, FontStyle.Underline, FontStyle.Regular), FontStyle))
            TextLabel.Font = New Font(TextLabel.Font.FontFamily.Name, TextLabel.Font.Size, FontStyle.Regular)
        Else
            TitleLabel.Font = New Font(TitleLabel.Font.FontFamily.Name, TitleLabel.Font.Size, FontStyle.Regular)
            TextLabel.Font = New Font(TextLabel.Font.FontFamily.Name, TextLabel.Font.Size, FontStyle.Regular)
        End If

    End Sub

    ''' <summary>
    ''' Gets or sets the view to the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the view to the control.")> <DefaultValue(Views.Normal)> _
    Public Property View As Views
        Get
            Return m_View
        End Get
        Set(ByVal value As Views)
            m_View = value
            LoadView(value)
        End Set
    End Property

    ''' <summary>
    ''' Removes highlighting from the control when the control does not have focus.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Removes highlighting from the control when the control does not have focus.")> <DefaultValue(False)> _
    Public Property HideSelection As Boolean
        Get
            Return m_HideSelection
        End Get
        Set(ByVal value As Boolean)
            m_HideSelection = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the title on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the title to the control.")> _
    Public Property Title As String
        Get
            Return TitleLabel.Text
        End Get
        Set(ByVal value As String)
            TitleLabel.Text = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the extra title on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the extra title to the control.")> _
    Public Property ExtraTitle As String
        Get
            Return ExtraTitleLabel.Text
        End Get
        Set(ByVal value As String)
            PreviousExtraTitleWidth = ExtraTitleLabel.Width
            ExtraTitleLabel.Text = value
            AllowedToCheckExtraTitle = True
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the text on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the text to the control.")> <Browsable(True)> _
    Public Overloads Property Text As String
        Get
            Return TextLabel.Text
        End Get
        Set(ByVal value As String)
            TextLabel.Text = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the font on the title.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the font to the title.")> _
    Public Property TitleFont As Font
        Get
            Return TitleLabel.Font
        End Get
        Set(ByVal value As Font)
            TitleLabel.Font = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the font on the extra title.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the font to the extra title.")> _
    Public Property ExtraTitleFont As Font
        Get
            Return ExtraTitleLabel.Font
        End Get
        Set(ByVal value As Font)
            ExtraTitleLabel.Font = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the font on the text.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the font to the text.")> _
    Public Property TextFont As Font
        Get
            Return TextLabel.Font
        End Get
        Set(ByVal value As Font)
            TextLabel.Font = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the textalgin on the title.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the textalgin to the title.")> _
    Public Property TitleTextAlgin As ContentAlignment
        Get
            Return TitleLabel.TextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            TitleLabel.TextAlign = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the textalgin on the extra title.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the textalgin to the extra title.")> _
    Public Property ExtraTitleTextAlgin As ContentAlignment
        Get
            Return ExtraTitleLabel.TextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            ExtraTitleLabel.TextAlign = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the textalgin on the text.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the textalgin to the text.")> _
    Public Property TextTextAlgin As ContentAlignment
        Get
            Return TextLabel.TextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            TextLabel.TextAlign = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the contextmenustrip on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the contextmenustrip to the control.")> _
    Public Overloads Property ContextMenuStrip As ContextMenuStrip
        Get
            Return m_ContextMenuStrip
        End Get
        Set(ByVal value As ContextMenuStrip)
            m_ContextMenuStrip = value
        End Set
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

    ''' <summary>
    ''' Gets or sets the icon on the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the icon to the control.")> _
    Public Property Icon As Icon
        Get
            Return m_Icon
        End Get
        Set(ByVal value As Icon)
            m_Icon = value
            IconBox.Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the control is going have bold font on select.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the control is going have bold font on select.")> <DefaultValue(True)> _
    Public Property FontBoldOnSelect As Boolean
        Get
            Return m_FontBoldOnSelect
        End Get
        Set(ByVal value As Boolean)
            m_FontBoldOnSelect = value
            CheckTitleAndTextLabel()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the control is going have underline font on hover.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets indicating if the control is going have underline font on hover.")> <DefaultValue(True)> _
    Public Property FontUnderLineOnHover As Boolean
        Get
            Return m_FontUnderLineOnHover
        End Get
        Set(ByVal value As Boolean)
            m_FontUnderLineOnHover = value
            CheckTitleAndTextLabel()
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the disabled linecolor to the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the disabled linecolor to the control.")> _
    Public Property DisabledLineColor As Color
        Get
            Return m_DisabledLineColor
        End Get
        Set(ByVal value As Color)
            m_DisabledLineColor = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the selected linecolor to the control.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the selected linecolor to the control.")> _
    Public Property SelectedLineColor As Color
        Get
            Return m_SelectedLineColor
        End Get
        Set(ByVal value As Color)
            m_SelectedLineColor = value
        End Set
    End Property

    Private Sub Controls_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles IconBox.MouseLeave, TextLabel.MouseLeave, TitleLabel.MouseLeave, TopBorder.MouseLeave, RightBorder.MouseLeave, BottomBorder.MouseLeave, LeftBorder.MouseLeave, Me.MouseLeave
        If Not m_Selected Then
            m_Hover = False
            CheckTitleAndTextLabel()
        End If
    End Sub

    Private Sub Controls_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles IconBox.MouseEnter, TextLabel.MouseEnter, TitleLabel.MouseEnter, TopBorder.MouseEnter, RightBorder.MouseEnter, BottomBorder.MouseEnter, LeftBorder.MouseEnter, Me.MouseEnter
        If Not m_Selected Then
            m_Selected = False
            m_Hover = True
            CheckTitleAndTextLabel()
        End If
    End Sub

    Private Sub Controls_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus, IconBox.GotFocus, TextLabel.GotFocus, TitleLabel.GotFocus, TopBorder.GotFocus, RightBorder.GotFocus, BottomBorder.GotFocus, LeftBorder.GotFocus, Me.GotFocus
        Focus()
        m_Selected = True
        m_Hover = False
        RaiseEvent IsSelected(sender, New IsSelectedEventArgs(m_Icon, TitleLabel.Text, TextLabel.Text))
        SetBorderColor(m_SelectedLineColor)
        CheckTitleAndTextLabel()
    End Sub

    Private Sub Controls_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles IconBox.MouseDown, TextLabel.MouseDown, TitleLabel.MouseDown, TopBorder.MouseDown, RightBorder.MouseDown, BottomBorder.MouseDown, LeftBorder.MouseDown, Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Focus()
            m_Selected = True
            m_Hover = False
            RaiseEvent IsSelected(sender, New IsSelectedEventArgs(m_Icon, TitleLabel.Text, TextLabel.Text))
            SetBorderColor(m_SelectedLineColor)
            CheckTitleAndTextLabel()
        End If
    End Sub

    Private Sub Controls_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Leave, IconBox.Leave, TextLabel.Leave, TitleLabel.Leave, TopBorder.Leave, RightBorder.Leave, BottomBorder.Leave, LeftBorder.Leave, Me.Leave
        m_Hover = False
        m_Selected = False
        SetBorderColor(m_DisabledLineColor)
        CheckTitleAndTextLabel()
    End Sub

    Private Sub Controls_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.LostFocus, IconBox.LostFocus, TextLabel.LostFocus, TitleLabel.LostFocus, TopBorder.LostFocus, RightBorder.LostFocus, BottomBorder.LostFocus, LeftBorder.LostFocus, Me.LostFocus
        If m_HideSelection Then
            m_Hover = False
            m_Selected = False
            SetBorderColor(m_DisabledLineColor)
            CheckTitleAndTextLabel()
        End If
    End Sub

    Private Sub Controls_MouseClick(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles MyBase.MouseClick, IconBox.MouseClick, TextLabel.MouseClick, TitleLabel.MouseClick, TopBorder.MouseClick, RightBorder.MouseClick, BottomBorder.MouseClick, LeftBorder.MouseClick, Me.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Not IsNothing(m_ContextMenuStrip) Then
                m_ContextMenuStrip.Show(sender, e.Location.X, e.Location.Y)
            End If
        End If
    End Sub

    Private Sub IconBox_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles IconBox.Paint

        If Not IsNothing(m_Icon) Then

            If m_Icon.Height > IconBox.Height Or m_Icon.Width > IconBox.Width Then

                e.Graphics.DrawIcon(m_Icon, New Rectangle(0, 0, IconBox.Width, IconBox.Height))

            Else

                e.Graphics.DrawIcon(m_Icon, IIf(m_Icon.Width < IconBox.Width, (IconBox.Width - m_Icon.Width) / 2, 0), IIf(m_Icon.Height < IconBox.Height, (IconBox.Height - m_Icon.Height) / 2, 0))

            End If

        End If

    End Sub

    Private Sub ExtraTitleLabel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExtraTitleLabel.TextChanged
        If AllowedToCheckExtraTitle Then
            CheckAndSetExtraTitleSize()
            AllowedToCheckExtraTitle = False
        End If
    End Sub
End Class