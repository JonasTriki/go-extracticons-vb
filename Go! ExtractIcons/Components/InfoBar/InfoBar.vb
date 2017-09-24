Imports System.ComponentModel

Public Class InfoBar

    Dim MouseOverCloseButton As Boolean

    Dim m_Message As String

    Dim m_ContextMenuStrip As ContextMenuStrip
    Dim m_CloseButtonContextMenuStrip As ContextMenuStrip

    Public Sub New()

        InitializeComponent()

        Me.MaximumSize = New Size(0, 24)
        Me.MinimumSize = New Size(41, 24)

        Me.Dock = DockStyle.Top

    End Sub

    <Description("Get or sets the message to the control.")> <DefaultValue(True)> _
    Public Property Message() As String
        Get
            Return m_Message
        End Get
        Set(ByVal value As String)
            m_Message = value
            InfoText.Text = m_Message
        End Set
    End Property

    <Description("Get or sets the font to the control.")> _
    Public Overloads Property Font() As Font
        Get
            Return InfoText.Font
        End Get
        Set(ByVal value As Font)
            InfoText.Font = value
        End Set
    End Property

    <Description("Get or sets indicating if the close button is visible.")> <DefaultValue(True)> _
    Public Property CloseButtonVisible() As Boolean
        Get
            Return InfoCloseBtn.Visible
        End Get
        Set(ByVal value As Boolean)
            InfoCloseBtn.Visible = value
        End Set
    End Property

    <Description("Get or sets indicating if the close button is enabled.")> <DefaultValue(True)> _
    Public Property CloseButtonEnabled() As Boolean
        Get
            Return InfoCloseBtn.Enabled
        End Get
        Set(ByVal value As Boolean)
            InfoCloseBtn.Enabled = value
        End Set
    End Property

    <Description("Get or sets the CloseButtonContextMenuStrip for the control.")> _
    Public Property CloseButtonContextMenuStrip() As ContextMenuStrip
        Get
            Return m_CloseButtonContextMenuStrip
        End Get
        Set(ByVal value As ContextMenuStrip)
            m_CloseButtonContextMenuStrip = value
        End Set
    End Property

    <Description("Get or sets the ContextMenuStrip for the control.")> _
    Public Overloads Property ContextMenuStrip() As ContextMenuStrip
        Get
            Return m_ContextMenuStrip
        End Get
        Set(ByVal value As ContextMenuStrip)
            m_ContextMenuStrip = value
        End Set
    End Property

    <Description("Gets or sets the textalgin to the control.")> _
    <Browsable(True)> <DefaultValue(ContentAlignment.TopLeft)> _
    Public Property TextAlign() As ContentAlignment
        Get
            Return InfoText.TextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            InfoText.TextAlign = value
        End Set
    End Property

    <Description("Gets or sets the icon to the control.")> _
    Public Property Icon() As Image
        Get
            Return InfoIcon.Image
        End Get
        Set(ByVal value As Image)
            InfoIcon.Image = value
        End Set
    End Property

    Private Sub InfoCloseBtn_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoCloseBtn.MouseEnter
        If InfoCloseBtn.Enabled Then
            InfoCloseBtn.Image = My.Resources.Close_Hover
        End If
    End Sub

    Private Sub InfoCloseBtn_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles InfoCloseBtn.MouseDown
        If InfoCloseBtn.Enabled Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                InfoCloseBtn.Image = My.Resources.Close_Pressed
            End If
        End If
    End Sub

    Private Sub InfoCloseBtn_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles InfoCloseBtn.MouseUp
        If InfoCloseBtn.Enabled Then
            If e.Button = Windows.Forms.MouseButtons.Left And MouseOverCloseButton Then
                InfoCloseBtn.Image = My.Resources.Close_Hover
                Me.Visible = False
            End If
        End If
    End Sub

    Private Sub InfoCloseBtn_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles InfoCloseBtn.MouseHover
        If InfoCloseBtn.Enabled Then
            MouseOverCloseButton = True
        End If
    End Sub

    Private Sub InfoCloseBtn_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoCloseBtn.MouseLeave
        If InfoCloseBtn.Enabled Then
            MouseOverCloseButton = False
            InfoCloseBtn.Image = My.Resources.Close
        End If
    End Sub

    Private Sub InfoCloseBtn_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InfoCloseBtn.EnabledChanged
        If InfoCloseBtn.Enabled Then
            InfoCloseBtn.Image = My.Resources.Close
        Else
            InfoCloseBtn.Image = My.Resources.Close_Disabled
        End If
    End Sub

    Private Sub InfoBar_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If InfoCloseBtn.Enabled Then
            InfoCloseBtn.Image = My.Resources.Close
        End If
    End Sub

    Private Sub InfoBar_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        If InfoCloseBtn.Enabled Then
            InfoCloseBtn.Image = My.Resources.Close_Disabled
        End If
    End Sub

    Private Sub InfoBar_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible Then
            My.Computer.Audio.Play(My.Resources.Information_sound, AudioPlayMode.Background)
        End If
    End Sub

    Private Sub InfoCloseBtn_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles InfoCloseBtn.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Not IsNothing(m_CloseButtonContextMenuStrip) Then
                m_CloseButtonContextMenuStrip.Show(Me.ParentForm, New Point(MousePosition.X - Me.ParentForm.Location.X - 8, MousePosition.Y - Me.ParentForm.Location.Y - 31))
            End If
        End If
    End Sub

    Private Sub InfoText_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles InfoText.MouseClick, InfoIcon.MouseClick, MyBase.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Not IsNothing(m_ContextMenuStrip) Then
                m_ContextMenuStrip.Show(Me.ParentForm, New Point(MousePosition.X - Me.ParentForm.Location.X - 8, MousePosition.Y - Me.ParentForm.Location.Y - 30))
            End If
        End If
    End Sub

#Region " Obsolete properties "

    <Browsable(False)> _
    <EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property MinimumSize() As Size
        Get
        End Get
        Set(ByVal value As Size)
        End Set
    End Property

    <Browsable(False)> _
    <EditorBrowsable(EditorBrowsableState.Never)> _
    Public Overrides Property MaximumSize() As Size
        Get
        End Get
        Set(ByVal value As Size)
        End Set
    End Property

#End Region

    Private Sub InfoBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        InfoText.Text = m_Message

    End Sub
End Class

