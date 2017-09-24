Imports System.ComponentModel

<ToolboxBitmap(GetType(System.Drawing.Icon), "Resources.StandardIcon")> _
Public Class MessageBox

    Dim MessageDialogResult As MessageDialogResults

    Dim m_Message As String = Nothing
    Dim m_MessageTitle As String = Nothing
    Dim m_MessageFormIcon As Icon = Nothing
    Dim m_MessageIcon As MessageIcons = MessageIcons.Information
    Dim m_MessageButton As MessageButtons = MessageButtons.OKCancel
    Dim m_ShowDoNotShowAgainCheckBox As Boolean = False
    Dim m_IsDoNotShowAgainCheckBoxChecked As Boolean = False

    Enum MessageDialogResults

        OK = 1

        Cancel = 2

        Yes = 3

        No = 4

        Help = 5

        Retry = 6

        Save = 7

        DoNotSave = 8

    End Enum

    Enum MessageButtons

        OKOnly = 1

        OKCancel = 2

        YesNo = 3

        YesNoCancel = 4

        OKHelp = 5

        RetryCancel = 6

        SaveDoNotSaveCancel = 7

    End Enum

    Enum MessageIcons

        Information = 1

        Question = 2

        Critical = 3

        Exlamation = 4

    End Enum

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    ''' <summary>
    ''' Creates a new MessageBox.
    ''' </summary>
    ''' <param name="Message">The message to show.</param>
    ''' <param name="MessageButton">The button style.</param>
    ''' <param name="MessageIcon">The icon to show.</param>
    ''' <param name="Title">The title.</param>
    ''' <param name="Icon">The icon to the form.</param>
    ''' <param name="IsDoNotShowAgainCheckBoxChecked"></param>
    ''' <param name="ShowDoNotShowAgainCheckBox"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Message As String, Optional ByVal MessageButton As MessageButtons = MessageButtons.OKOnly, Optional ByVal MessageIcon As MessageIcons = MessageIcons.Information, Optional ByVal Title As String = "", Optional ByVal Icon As Icon = Nothing, Optional ByVal ShowDoNotShowAgainCheckBox As Boolean = False, Optional ByVal IsDoNotShowAgainCheckBoxChecked As Boolean = False)

        InitializeComponent()

        m_Message = Message

        m_MessageButton = MessageButton

        m_MessageIcon = MessageIcon

        m_MessageTitle = Title

        m_MessageFormIcon = Icon

        m_ShowDoNotShowAgainCheckBox = ShowDoNotShowAgainCheckBox

        m_IsDoNotShowAgainCheckBoxChecked = IsDoNotShowAgainCheckBoxChecked

    End Sub

    ''' <summary>
    ''' Gets or sets the MessageBoxText.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the MessageBoxText.")> _
    Public Property Message As String
        Get
            Return m_Message
        End Get
        Set(ByVal value As String)
            m_Message = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the MessageTitle.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the MessageTitle.")> _
    Public Property MessageTitle As String
        Get
            Return m_MessageTitle
        End Get
        Set(ByVal value As String)
            m_MessageTitle = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the MessageBoxIcon.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the MessageBoxIcon.")> <DefaultValue("")> _
    Public Property MessageBoxIcon As Icon
        Get
            Return m_MessageFormIcon
        End Get
        Set(ByVal value As Icon)
            m_MessageFormIcon = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the MessageIcon.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the MessageIcon.")> <DefaultValue(MessageIcons.Information)> _
    Public Property MessageIcon As MessageIcons
        Get
            Return m_MessageIcon
        End Get
        Set(ByVal value As MessageIcons)
            m_MessageIcon = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the MessageButton.
    ''' </summary>
    ''' <remarks></remarks>
    <Description("Gets or sets the MessageButton.")> <DefaultValue(MessageButtons.OKCancel)> _
    Public Property MessageButton As MessageButtons
        Get
            Return m_MessageButton
        End Get
        Set(ByVal value As MessageButtons)
            m_MessageButton = value
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets indicating if the DoNotShowAgainCheckBox is visible.
    ''' </summary>
    ''' <remarks></remarks>
    <DefaultValue(False)> _
    <Description("Gets or sets indicating if the DoNotShowAgainCheckBox is visible.")> _
    Public Property ShowDoNotShowAgainCheckBox As Boolean
        Get
            Return m_ShowDoNotShowAgainCheckBox
        End Get
        Set(ByVal value As Boolean)
            m_ShowDoNotShowAgainCheckBox = value
        End Set
    End Property

    ''' <summary>
    ''' Gets the result of the DoNotShowAgainCheckBox.
    ''' </summary>
    ''' <remarks></remarks>
    <DefaultValue(False)> _
    <Description("Gets or sets indicating if the DoNotShowAgainCheckBox is checked.")> _
     Public Property IsDoNotShowAgainCheckBoxChecked As Boolean
        Get
            Return m_IsDoNotShowAgainCheckBoxChecked
        End Get
        Set(ByVal value As Boolean)
            m_IsDoNotShowAgainCheckBoxChecked = value
        End Set
    End Property

    ''' <summary>
    ''' Show's the MessageBoxDialog.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function ShowDialog() As MessageDialogResults

        Dim Dialog As New frmMessageBox(m_Message, m_MessageButton, m_MessageIcon, m_MessageTitle, m_MessageFormIcon, m_ShowDoNotShowAgainCheckBox, m_IsDoNotShowAgainCheckBoxChecked)

        If Dialog.ShowDialog() = DialogResult.Cancel Then
            m_IsDoNotShowAgainCheckBoxChecked = Dialog.DoNotShowAgainCheckBox.Checked

            Return Dialog.MessageDialogResult
        Else
            Return MessageDialogResults.Cancel
        End If

    End Function

End Class
