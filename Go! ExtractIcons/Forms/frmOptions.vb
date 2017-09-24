Public Class frmOptions

    Dim INILangFile As IniFile

    Dim PleaseChooseALanguagePack As String
    Dim LANGFiles As String
    Dim AreYouSureThatYouWannaDeleteThisLanguagePackPermanently As String

    Public Function ShowMessageBox(ByVal Message As String, Optional ByVal MessageButton As MessageBox.MessageButtons = MessageBox.MessageButtons.OKOnly, Optional ByVal MessageIcon As MessageBox.MessageIcons = MessageBox.MessageIcons.Information, Optional ByVal Title As String = "", Optional ByVal Icon As Icon = Nothing, Optional ByVal ShowDoNotShowAgainCheckBox As Boolean = False, Optional ByVal IsDoNotShowAgainCheckBoxChecked As Boolean = False) As MessageBox.MessageDialogResults

        Dim MessageBox As New MessageBox(Message, MessageButton, MessageIcon, Title, Icon, ShowDoNotShowAgainCheckBox, IsDoNotShowAgainCheckBoxChecked)

        Return MessageBox.ShowDialog()

    End Function

    Public Function GetLangIndex(ByVal Lang As String) As String

        Dim str As String = My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages").IndexOf(Lang & ".lang")

        If str.Contains("-") Then
            str = str.Replace("-", "")
        End If

        Return str

    End Function

    Public Sub LoadSettings()

        SearchIconsRadioButton.Checked = My.Settings.SearchIcons
        DoNothingRadioButton.Checked = Not My.Settings.SearchIcons

        ShowRestartMessageBoxCheckBox.Checked = My.Settings.ShowRestartMessageBox
        ShowRemoveSelectedIconMessageBoxCheckBox.Checked = My.Settings.ShowRemoveSelectedIconMessageBox

    End Sub

    Public Sub LoadLanguages()

        LangComboBox.Items.Clear()

        For Each Lang As String In My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages")

            LangComboBox.Items.Add(IO.Path.GetFileNameWithoutExtension(Lang))

        Next

        LangComboBox.SelectedIndex = My.Settings.Language

    End Sub

    Public Sub CheckLangPosition()

        My.Settings.Language = GetLangIndex(My.Settings.LanguageName)

        LoadLanguages()

    End Sub

    Public Sub CheckLang()

        LoadLanguages()

        INILangFile = New IniFile(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages").Item(My.Settings.Language))

        LoadLang()

    End Sub

    Public Sub LoadLang()

        'SomeCommands = INILangFile.GetString("SomeCommands", "")

        PleaseChooseALanguagePack = INILangFile.GetString("SomeCommands", "PleaseChooseALanguagePack")
        LANGFiles = INILangFile.GetString("SomeCommands", "LANGFiles")
        AreYouSureThatYouWannaDeleteThisLanguagePackPermanently = INILangFile.GetString("SomeCommands", "AreYouSureThatYouWannaDeleteThisLanguagePackPermanently")

        'frmOptions = INILangFile.GetString("frmOptions", "")

        Me.Text = INILangFile.GetString("frmOptions", "Text")

        'frmOptionsControls = INILangFile.GetString("frmOptionsControls", "")

        RestartBar.Message = INILangFile.GetString("frmOptionsControls", "RestartGoExtractIconsForThisChangeToTakeEffect")
        StartTabPage.Text = INILangFile.GetString("frmOptionsControls", "Basics")
        StartUpLabel.Text = INILangFile.GetString("frmOptionsControls", "StartUp")
        SearchIconsRadioButton.Text = INILangFile.GetString("frmOptionsControls", "SearchIcons")
        DoNothingRadioButton.Text = INILangFile.GetString("frmOptionsControls", "DoNothing")
        MessageBoxesLabel.Text = INILangFile.GetString("frmOptionsControls", "MessageBoxes")
        ShowRestartMessageBoxCheckBox.Text = INILangFile.GetString("frmOptionsControls", "ShowRestartMessageBox")
        ShowRemoveSelectedIconMessageBoxCheckBox.Text = INILangFile.GetString("frmOptionsControls", "ShowRemoveSelectedIconMessageBox")
        LangLabel.Text = INILangFile.GetString("frmOptionsControls", "Language")
        RemoveLangPackButton.Text = INILangFile.GetString("frmOptionsControls", "RemoveLangPack")
        AddLangPackButton.Text = INILangFile.GetString("frmOptionsControls", "AddLangPack")
        RestartButton.Text = INILangFile.GetString("frmOptionsControls", "Restart")
        OKButton.Text = INILangFile.GetString("frmOptionsControls", "OK")

    End Sub

    Private Sub frmOptions_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

        My.Settings.SearchIcons = SearchIconsRadioButton.Checked
        My.Settings.Language = LangComboBox.SelectedIndex
        My.Settings.LanguageName = LangComboBox.SelectedItem

        My.Settings.ShowRestartMessageBox = ShowRestartMessageBoxCheckBox.CheckAlign
        My.Settings.ShowRemoveSelectedIconMessageBox = ShowRemoveSelectedIconMessageBoxCheckBox.Checked

    End Sub

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckLang()

        LoadSettings()

    End Sub

    Private Sub LangComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LangComboBox.SelectedIndexChanged

        RestartBar.Visible = LangComboBox.SelectedIndex <> My.Settings.Language

        RestartButton.Visible = LangComboBox.SelectedIndex <> My.Settings.Language

        RemoveLangPackButton.Enabled = LangComboBox.SelectedIndex <> My.Settings.Language

        If RestartBar.Visible Then
            Me.Size = New Size(570, 333)
        Else
            Me.Size = New Size(570, 303)
        End If

    End Sub

    Private Sub RemoveLangPackButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RemoveLangPackButton.Click

        If ShowMessageBox(AreYouSureThatYouWannaDeleteThisLanguagePackPermanently, MessageBox.MessageButtons.YesNoCancel) = Go__ExtractIcons.MessageBox.MessageDialogResults.Yes Then

            If IO.Path.GetFileNameWithoutExtension(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages").Item(LangComboBox.SelectedIndex)) = LangComboBox.SelectedItem Then
                MsgBox("Sucess!")
            Else
                MsgBox(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages").Item(LangComboBox.SelectedIndex))
            End If

            'My.Computer.FileSystem.DeleteFile(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages").Item(LangComboBox.SelectedIndex + 1))

            'LangComboBox.Items.RemoveAt(LangComboBox.SelectedIndex)

            'CheckLangPosition()

        End If

    End Sub

    Private Sub AddLangPackButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddLangPackButton.Click

        Dim Dialog As New OpenFileDialog

        Dialog.Title = PleaseChooseALanguagePack
        Dialog.Filter = LANGFiles & "|*.lang"
        Dialog.Multiselect = False

        If Dialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim LangFile As New IniFile(Dialog.FileName)

            If LangFile.GetString("IsGoExtractIconsLangFile", "TrueOrFalse") = "True" Then

                My.Computer.FileSystem.CopyFile(Dialog.FileName, Application.StartupPath & "\Languages\" & My.Computer.FileSystem.GetFileInfo(Dialog.FileName).Name)

                LangComboBox.Items.Add(IO.Path.GetFileNameWithoutExtension(Dialog.FileName))

                If LangComboBox.Items.IndexOf(IO.Path.GetFileNameWithoutExtension(Dialog.FileName)) >= 1 Then
                    My.Settings.Language += 1
                End If

                LoadLanguages()

            End If

        End If

    End Sub

    Private Sub RestartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartButton.Click

        frmMain.DoRestart = True

        Application.Exit()

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub
End Class