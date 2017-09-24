Imports System.ComponentModel

Public Class CustomBtn

    Dim m_ImageNormal As Image
    Dim m_ImageHover As Image
    Dim m_ImagePressed As Image
    Dim m_ImageDisabled As Image

    Dim m_LeftNormal As Image
    Dim m_LeftHover As Image
    Dim m_LeftPressed As Image
    Dim m_LeftDisabled As Image

    Dim m_BackNormal As Image
    Dim m_BackHover As Image
    Dim m_BackPressed As Image
    Dim m_BackDisabled As Image

    Dim m_RightNormal As Image
    Dim m_RightHover As Image
    Dim m_RightPressed As Image
    Dim m_RightDisabled As Image

    Dim MouseOverBtn As Boolean = False

    Dim DropDownListOpened As Boolean = False
    Private WithEvents m_DropDownList As ContextMenuStrip

    Dim m_IconVisible As Boolean = True

    Enum ImageStyles

        Normal = 1

        Hover = 2

        Pressed = 3

        Disabled = 4

    End Enum

    Private Sub SetImages(ByVal Style As ImageStyles)

        If Style = ImageStyles.Normal Then

            IconBox.Image = m_ImageNormal

            Me.BackgroundImage = My.Resources.CustomBtn_Normal

        ElseIf Style = ImageStyles.Hover Then

            IconBox.Image = m_ImageHover

            Me.BackgroundImage = My.Resources.CustomBtn_Hover

        ElseIf Style = ImageStyles.Pressed Then

            IconBox.Image = m_ImagePressed

            Me.BackgroundImage = My.Resources.CustomBtn_Pressed

        ElseIf Style = ImageStyles.Disabled Then

            IconBox.Image = m_ImageDisabled

            Me.BackgroundImage = My.Resources.CustomBtn_Disabled

        End If

    End Sub

    Private Sub CheckIconVisible()

        IconBox.Visible = m_IconVisible

        If m_IconVisible Then
            TextLabel.Location = New Point(30, 5)
        Else
            TextLabel.Location = New Point(5, 5)
        End If

    End Sub

    <Description("Gets or sets the dropdownlist to the custom button.")> _
    Public Property DropDownList As ContextMenuStrip
        Get
            Return m_DropDownList
        End Get
        Set(ByVal value As ContextMenuStrip)
            m_DropDownList = value
        End Set
    End Property

    <Description("Gets or sets indicating if the icon is visible")> <DefaultValue(True)> _
    Public Property IconVisible As Boolean
        Get
            Return m_IconVisible
        End Get
        Set(ByVal value As Boolean)
            m_IconVisible = value
            CheckIconVisible()
        End Set
    End Property

    <Description("Gets or sets the text to the custom button.")> _
    Public Property TextToBtn As String
        Get
            Return TextLabel.Text
        End Get
        Set(ByVal value As String)
            TextLabel.Text = value
        End Set
    End Property

    <Description("Gets or sets the textalign to the custom button.")> _
    Public Property TextAlignToBtn As ContentAlignment
        Get
            Return TextLabel.TextAlign
        End Get
        Set(ByVal value As ContentAlignment)
            TextLabel.TextAlign = value
        End Set
    End Property

    <Description("Gets or sets the image on the normal state.")> _
    Public Property ImageNormal As Image
        Get
            Return m_ImageNormal
        End Get
        Set(ByVal value As Image)
            m_ImageNormal = value
            IconBox.Image = value
        End Set
    End Property

    <Description("Gets or sets the image on the hover state.")> _
    Public Property ImageHover As Image
        Get
            Return m_ImageHover
        End Get
        Set(ByVal value As Image)
            m_ImageHover = value
        End Set
    End Property

    <Description("Gets or sets the image on the pressed state.")> _
    Public Property ImagePressed As Image
        Get
            Return m_ImagePressed
        End Get
        Set(ByVal value As Image)
            m_ImagePressed = value
        End Set
    End Property

    <Description("Gets or sets the image on the disabled state.")> _
    Public Property ImageDisabled As Image
        Get
            Return m_ImageDisabled
        End Get
        Set(ByVal value As Image)
            m_ImageDisabled = value
        End Set
    End Property

    <Description("Gets or sets the image to the left on the normal state.")> _
    Public Property LeftNormal As Image
        Get
            Return m_LeftNormal
        End Get
        Set(ByVal value As Image)
            m_LeftNormal = value
        End Set
    End Property

    <Description("Gets or sets the image to the left on the hover state.")> _
    Public Property LeftHover As Image
        Get
            Return m_LeftHover
        End Get
        Set(ByVal value As Image)
            m_LeftHover = value
        End Set
    End Property

    <Description("Gets or sets the image to the left on the pressed state.")> _
    Public Property LeftPressed As Image
        Get
            Return m_LeftPressed
        End Get
        Set(ByVal value As Image)
            m_LeftPressed = value
        End Set
    End Property

    <Description("Gets or sets the image to the left on the disabled state.")> _
    Public Property LeftDisabled As Image
        Get
            Return m_LeftDisabled
        End Get
        Set(ByVal value As Image)
            m_LeftDisabled = value
        End Set
    End Property

    <Description("Gets or sets the back image on the normal state.")> _
    Public Property BackNormal As Image
        Get
            Return m_BackNormal
        End Get
        Set(ByVal value As Image)
            m_BackNormal = value
        End Set
    End Property

    <Description("Gets or sets the back image on the hover state.")> _
    Public Property BackHover As Image
        Get
            Return m_BackHover
        End Get
        Set(ByVal value As Image)
            m_BackHover = value
        End Set
    End Property

    <Description("Gets or sets the back image on the pressed state.")> _
    Public Property BackPressed As Image
        Get
            Return m_BackPressed
        End Get
        Set(ByVal value As Image)
            m_BackPressed = value
        End Set
    End Property

    <Description("Gets or sets the back image on the disabled state.")> _
    Public Property BackDisabled As Image
        Get
            Return m_BackDisabled
        End Get
        Set(ByVal value As Image)
            m_BackDisabled = value
        End Set
    End Property

    <Description("Gets or sets the image to the right on the normal state.")> _
    Public Property RightNormal As Image
        Get
            Return m_RightNormal
        End Get
        Set(ByVal value As Image)
            m_RightNormal = value
        End Set
    End Property

    <Description("Gets or sets the image to the right on the hover state.")> _
    Public Property RightHover As Image
        Get
            Return m_RightHover
        End Get
        Set(ByVal value As Image)
            m_RightHover = value
        End Set
    End Property

    <Description("Gets or sets the image to the right on the pressed state.")> _
    Public Property RightPressed As Image
        Get
            Return m_RightPressed
        End Get
        Set(ByVal value As Image)
            m_RightPressed = value
        End Set
    End Property

    <Description("Gets or sets the image to the right on the disabled state.")> _
    Public Property RightDisabled As Image
        Get
            Return m_RightDisabled
        End Get
        Set(ByVal value As Image)
            m_RightDisabled = value
        End Set
    End Property

    Private Sub m_DropDownList_Closed(ByVal sender As Object, ByVal e As ToolStripDropDownClosedEventArgs) Handles m_DropDownList.Closed

        DropDownListOpened = False

        SetImages(ImageStyles.Normal)

    End Sub

    Private Sub m_DropDownList_Opened(ByVal sender As Object, ByVal e As EventArgs) Handles m_DropDownList.Opened

        DropDownListOpened = True

    End Sub

    Private Sub CustomBtn_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.EnabledChanged
        If Me.Enabled Then
            SetImages(ImageStyles.Normal)
        Else
            SetImages(ImageStyles.Disabled)
        End If
    End Sub

    Private Sub CustomBtn_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

        If Me.Enabled Then

            If Not DropDownListOpened Then

                MouseOverBtn = False

                SetImages(ImageStyles.Normal)

            End If

        End If

    End Sub

    Private Sub CustomBtn_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown, IconBox.MouseDown, TextLabel.MouseDown, DropDownBtn.MouseDown

        If e.Button = Windows.Forms.MouseButtons.Left Then

            If Me.Enabled Then

                If Not DropDownListOpened Then
                    SetImages(ImageStyles.Pressed)
                Else
                    DropDownList.Close()
                    DropDownListOpened = False
                End If

            End If

        End If

    End Sub

    Private Sub CustomBtn_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter, IconBox.MouseEnter, TextLabel.MouseEnter, DropDownBtn.MouseEnter

        If Me.Enabled And Not MouseOverBtn Then

            MouseOverBtn = True

            SetImages(ImageStyles.Hover)

        End If

    End Sub

    Private Sub CustomBtn_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave

        If Me.Enabled Then

            If Not DropDownListOpened Then

                MouseOverBtn = False

                SetImages(ImageStyles.Normal)

            End If

        End If

    End Sub

    Private Sub CustomBtn_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp, IconBox.MouseUp, TextLabel.MouseUp, DropDownBtn.MouseUp

        If Me.Enabled Then

            If MouseOverBtn Then
                SetImages(ImageStyles.Hover)

                If Not DropDownListOpened Then
                    If Not IsNothing(m_DropDownList) Then
                        m_DropDownList.Show(Me.Parent, Me.Parent.Width - m_DropDownList.Width - 4, Me.Parent.Height - 6)
                    End If
                Else
                    m_DropDownList.Close()
                End If

            Else
                SetImages(ImageStyles.Normal)
            End If

        End If

    End Sub
End Class
