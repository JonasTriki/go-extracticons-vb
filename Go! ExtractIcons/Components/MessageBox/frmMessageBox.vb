Public Class frmMessageBox

    Public MessageDialogResult As MessageDialogResults = MessageDialogResults.Cancel

    Dim m_Message As String = Nothing
    Dim m_MessageTitle As String = Nothing
    Dim m_MessageFormIcon As Icon = Nothing
    Dim m_MessageIcon As MessageIcons = MessageIcons.Information
    Dim m_MessageButton As MessageButtons = MessageButtons.OKCancel
    Dim m_ShowDoNotShowAgainCheckBox As Boolean = False
    Dim m_IsDoNotShowAgainCheckBoxChecked As Boolean = False

    Dim INILangFile As IniFile

    Dim OK As String
    Dim Cancel As String
    Dim Yes As String
    Dim No As String
    Dim Help As String
    Dim Retry As String
    Dim Save As String
    Dim DoNotSave As String

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

        Exclamation = 4

    End Enum

    Public Sub New()

        InitializeComponent()

    End Sub

    Public Sub New(ByVal Message As String, ByVal MessageButton As MessageButtons, ByVal MessageIcon As MessageIcons, ByVal MessageTitle As String, Optional ByVal MessageFormIcon As Icon = Nothing, Optional ByVal ShowDoNotShowAgainCheckBox As Boolean = False, Optional ByVal IsDoNotShowAgainCheckBoxChecked As Boolean = False)

        InitializeComponent()

        m_Message = Message

        m_MessageButton = MessageButton

        m_MessageIcon = MessageIcon

        m_MessageTitle = MessageTitle

        m_MessageFormIcon = MessageFormIcon

        m_ShowDoNotShowAgainCheckBox = ShowDoNotShowAgainCheckBox

        m_IsDoNotShowAgainCheckBoxChecked = IsDoNotShowAgainCheckBoxChecked

    End Sub

    Private Sub CheckLoad()

        'Bring messagebox to front...
        Me.BringToFront()

        'Run the Sound

        If m_MessageIcon = MessageIcons.Information Then

            My.Computer.Audio.Play(My.Resources.Information_sound, AudioPlayMode.Background)

        ElseIf m_MessageIcon = MessageIcons.Question Then

            My.Computer.Audio.Play(My.Resources.Help_sound, AudioPlayMode.Background)

        ElseIf m_MessageIcon = MessageIcons.Critical Then

            My.Computer.Audio.Play(My.Resources.Critical_sound, AudioPlayMode.Background)

        ElseIf m_MessageIcon = MessageIcons.Exclamation Then

            My.Computer.Audio.Play(My.Resources.Exlamation_sound, AudioPlayMode.Background)

        End If

        'Set the Text.

        MsgText.Text = m_Message

        'Set the Icon.

        If m_MessageIcon = MessageIcons.Information Then

            MsgIcon.Image = SystemIcons.Information.ToBitmap

        ElseIf m_MessageIcon = MessageIcons.Question Then

            MsgIcon.Image = SystemIcons.Question.ToBitmap

        ElseIf m_MessageIcon = MessageIcons.Critical Then

            MsgIcon.Image = SystemIcons.Error.ToBitmap

        ElseIf m_MessageIcon = MessageIcons.Exclamation Then

            MsgIcon.Image = SystemIcons.Exclamation.ToBitmap

        End If

        'Check and fix Buttons.

        If m_MessageButton = MessageButtons.OKOnly Then

            YesOrSaveButton.Visible = False : OkOrNoOrYesOrRetryOrDoNotSaveButton.Visible = False : ExitOrOKOrNoOrHelpButton.Text = OK

        ElseIf m_MessageButton = MessageButtons.OKCancel Then

            YesOrSaveButton.Visible = False : OkOrNoOrYesOrRetryOrDoNotSaveButton.Visible = True : OkOrNoOrYesOrRetryOrDoNotSaveButton.Text = OK : ExitOrOKOrNoOrHelpButton.Text = Cancel

        ElseIf m_MessageButton = MessageButtons.YesNo Then

            YesOrSaveButton.Visible = False : OkOrNoOrYesOrRetryOrDoNotSaveButton.Text = Yes : ExitOrOKOrNoOrHelpButton.Text = No

        ElseIf m_MessageButton = MessageButtons.YesNoCancel Then

            YesOrSaveButton.Visible = True : YesOrSaveButton.Text = Yes : OkOrNoOrYesOrRetryOrDoNotSaveButton.Text = No : ExitOrOKOrNoOrHelpButton.Text = Cancel

        ElseIf m_MessageButton = MessageButtons.OKHelp Then

            YesOrSaveButton.Visible = False : OkOrNoOrYesOrRetryOrDoNotSaveButton.Text = OK : ExitOrOKOrNoOrHelpButton.Text = Help

        ElseIf m_MessageButton = MessageButtons.RetryCancel Then

            YesOrSaveButton.Visible = False : OkOrNoOrYesOrRetryOrDoNotSaveButton.Text = Retry : ExitOrOKOrNoOrHelpButton.Text = Cancel

        ElseIf m_MessageButton = MessageButtons.SaveDoNotSaveCancel Then

            YesOrSaveButton.Visible = True : YesOrSaveButton.Text = Save : OkOrNoOrYesOrRetryOrDoNotSaveButton.Text = DoNotSave : ExitOrOKOrNoOrHelpButton.Text = Cancel

        End If

        'Check and set the Title.

        If m_MessageTitle = Nothing Then

            m_MessageTitle = My.Application.Info.Title

        End If

        Me.Text = m_MessageTitle

        MsgTitle.Text = m_MessageTitle

        'Check and set the FormIcon.

        If IsNothing(m_MessageFormIcon) Then

            Me.ShowIcon = False

        Else

            Me.Icon = m_MessageFormIcon

        End If

        'Check the DoNotShowAgainCheckBox

        DoNotShowAgainCheckBox.Checked = m_IsDoNotShowAgainCheckBoxChecked
        DoNotShowAgainCheckBox.Visible = m_ShowDoNotShowAgainCheckBox

    End Sub

    Public Sub CheckLang()

        INILangFile = New IniFile(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages").Item(My.Settings.Language))

        LoadLang()

    End Sub

    Public Sub LoadLang()

        'MessageBoxCommands = INILangFile.GetString("MessageBoxCommands", "")

        DoNotShowAgainCheckBox.Text = INILangFile.GetString("MessageBoxCommands", "DoNotShowThisMessageBoxAgain")
        OK = INILangFile.GetString("MessageBoxCommands", "OK")
        Cancel = INILangFile.GetString("MessageBoxCommands", "Cancel")
        Yes = INILangFile.GetString("MessageBoxCommands", "Yes")
        No = INILangFile.GetString("MessageBoxCommands", "No")
        Help = INILangFile.GetString("MessageBoxCommands", "Help")
        Retry = INILangFile.GetString("MessageBoxCommands", "Retry")
        Save = INILangFile.GetString("MessageBoxCommands", "Save")
        DoNotSave = INILangFile.GetString("MessageBoxCommands", "DoNotSave")

    End Sub

    Private Sub frmMessageBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckLang()

        CheckLoad()

    End Sub

    Private Sub MsgPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MsgPanel.Paint

        Dim BorderPen As New Pen(Color.FromArgb(166, 166, 166), 1)

        e.Graphics.DrawLine(BorderPen, 0, 0, Me.Width, 0)

        BorderPen.Dispose()

        e.Graphics.Dispose()

    End Sub

    Private Sub YesOrSaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YesOrSaveButton.Click

        If YesOrSaveButton.Text = Yes Then

            MessageDialogResult = MessageDialogResults.Yes

            Me.Close()

        ElseIf YesOrSaveButton.Text = Save Then

            MessageDialogResult = MessageDialogResults.Save

            Me.Close()

        End If

    End Sub

    Private Sub OKOrNoOrYesOrRetryOrDoNotSaveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OkOrNoOrYesOrRetryOrDoNotSaveButton.Click

        If OkOrNoOrYesOrRetryOrDoNotSaveButton.Text = OK Then

            MessageDialogResult = MessageDialogResults.OK

            Me.Close()

        ElseIf OkOrNoOrYesOrRetryOrDoNotSaveButton.Text = No Then

            MessageDialogResult = MessageDialogResults.No

            Me.Close()

        ElseIf OkOrNoOrYesOrRetryOrDoNotSaveButton.Text = Yes Then

            MessageDialogResult = MessageDialogResults.Yes

            Me.Close()

        ElseIf OkOrNoOrYesOrRetryOrDoNotSaveButton.Text = Retry Then

            MessageDialogResult = MessageDialogResults.Retry

            Me.Close()

        ElseIf OkOrNoOrYesOrRetryOrDoNotSaveButton.Text = DoNotSave Then

            MessageDialogResult = MessageDialogResults.DoNotSave

            Me.Close()

        End If

    End Sub

    Private Sub ExitOrOKOrNoOrHelpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitOrOKOrNoOrHelpButton.Click

        If ExitOrOKOrNoOrHelpButton.Text = Cancel Then

            MessageDialogResult = MessageDialogResults.Cancel

            Me.Close()

        ElseIf ExitOrOKOrNoOrHelpButton.Text = OK Then

            MessageDialogResult = MessageDialogResults.OK

            Me.Close()

        ElseIf ExitOrOKOrNoOrHelpButton.Text = No Then

            MessageDialogResult = MessageDialogResults.No

            Me.Close()

        ElseIf ExitOrOKOrNoOrHelpButton.Text = Help Then

            MessageDialogResult = MessageDialogResults.Help

            Me.Close()

        End If

    End Sub
End Class