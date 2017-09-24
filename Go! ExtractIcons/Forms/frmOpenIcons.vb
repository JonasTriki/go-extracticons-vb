Public Class frmOpenIcons

    Dim m_GetFileSize As String

    Dim ExecutableFiles As String
    Dim AllFiles As String
    Dim PleaseChooseAFile As String
    Dim PleaseChooseAFolder As String
    Dim LoadingProcesses As String
    Dim Loading As String

    Dim CanSetIsClosed As Boolean = False
    Public IsClosed As Boolean = False

    Dim _byte As String
    Dim YB As String
    Dim ZB As String
    Dim EB As String
    Dim PB As String
    Dim TB As String
    Dim GB As String
    Dim MB As String
    Dim KB As String

    Dim INILangFile As IniFile

    Dim IsProcessesLoaded As Boolean = False

    Public Function MakeTextDotts(ByVal Text As String, ByVal MaxLenght As Integer) As String
        Dim MaxCount As Integer = MaxLenght
        Dim ReturnValue As String = Text
        If Text.Length >= MaxCount Then
            Dim TextWithoutDotts As String = Text
            Do Until TextWithoutDotts.Length = MaxCount - 3
                TextWithoutDotts = TextWithoutDotts.Remove(TextWithoutDotts.Length - 1, 1)
            Loop
            If TextWithoutDotts.Length = MaxCount - 3 Then
                Dim TextWithDotts As String = TextWithoutDotts & "..."
                ReturnValue = TextWithDotts
            End If
        Else
            ReturnValue = Text
        End If

        Return ReturnValue

    End Function

    Public Function GetFileSize(ByVal Size As Long) As String

        Dim ByteFileSize As Long = Size

        If ByteFileSize <= 999 Then
            'byte <= 999 byte
            m_GetFileSize = ByteFileSize & " " & _byte
        ElseIf ByteFileSize >= 1.0E+24 Then
            'YB >= 100000000000000000 byte, Value / 1.2089258196146291E+18
            m_GetFileSize = Math.Round((ByteFileSize / 1.2089258196146291E+18), 2) & " " & YB
        ElseIf ByteFileSize >= 1.0E+21 Then
            'ZB >= 1000000000000000 byte, Value / 1.1805916207174114E+17
            m_GetFileSize = Math.Round((ByteFileSize / 1.1805916207174114E+17), 2) & " " & ZB
        ElseIf ByteFileSize >= 1000000000000000000 Then
            'EB >= 10000000000000 byte, Value / 1152921504606846976
            m_GetFileSize = Math.Round((ByteFileSize / 1152921504606846976), 2) & " " & EB
        ElseIf ByteFileSize >= 1000000000000000 Then
            'PB >= 100000000000 byte, Value / 1125899906842624
            m_GetFileSize = Math.Round((ByteFileSize / 1125899906842624), 2) & " " & PB
        ElseIf ByteFileSize >= 1000000000000 Then
            'TB >= 1000000000 byte, Value / 1099511627776
            m_GetFileSize = Math.Round((ByteFileSize / 1099511627776), 2) & " " & TB
        ElseIf ByteFileSize >= 1000000000 Then
            'GB >= 10000000 byte, Value / 1073741824
            m_GetFileSize = Math.Round((ByteFileSize / 1073741824), 2) & " " & GB
        ElseIf ByteFileSize >= 1000000 Then
            'MB >= 1000000 byte, Value / 1048576
            m_GetFileSize = Math.Round((ByteFileSize / 1048576), 2) & " " & MB
        ElseIf ByteFileSize >= 1000 Then
            'KB >= 1000 byte, Value / 1024
            m_GetFileSize = Math.Round((ByteFileSize / 1024), 2) & " " & KB
        End If

        Return m_GetFileSize

    End Function

    Private Sub CheckEnabled()

        If My.Settings.SearchIconsInFiles Then

            ItemBox.Enabled = True
            SubFoldersCheckBox.Enabled = True
            OpenFolderButton.Enabled = True
            ChooseFolderButton.Enabled = True
            ChooseFileButton.Enabled = True

            ProcessInfoPanel.Enabled = False

            If Not ProcessListBox.SelectedItem = Nothing Then
                ProcessIconBox.Image = GrayScaleConverter.ColorImageToGrayScaleImage(Icon.ExtractAssociatedIcon(ProcessListBox.SelectedItem).ToBitmap)
            Else
                ProcessIconBox.Image = GrayScaleConverter.ColorImageToGrayScaleImage(My.Resources.Program_32)
            End If

            ProcessListBox.Enabled = False
            LoadProcessesAgain.Visible = False

        ElseIf My.Settings.SearchIconsInTheSeletedProcess Then

            ItemBox.Enabled = False
            SubFoldersCheckBox.Enabled = False
            OpenFolderButton.Enabled = False
            ChooseFolderButton.Enabled = False
            ChooseFileButton.Enabled = False

            ProcessInfoPanel.Enabled = True
            If Not ProcessListBox.SelectedItem = Nothing Then
                ProcessIconBox.Image = Icon.ExtractAssociatedIcon(ProcessListBox.SelectedItem).ToBitmap
            Else
                ProcessIconBox.Image = My.Resources.Program_32
            End If

            ProcessListBox.Enabled = True
            LoadProcessesAgain.Visible = True

            If Not IsProcessesLoaded Then
                LoadProcesses()
            End If

        End If

    End Sub

    Private Sub LoadSettings()

        SubFoldersCheckBox.Checked = My.Settings.SearchSubFolders

        If My.Settings.ItemTextIsFolder And Not My.Computer.FileSystem.DirectoryExists(My.Settings.ItemText) Then
            My.Settings.ItemText = My.Computer.FileSystem.SpecialDirectories.Desktop
        ElseIf Not My.Settings.ItemTextIsFolder And Not My.Computer.FileSystem.FileExists(My.Settings.ItemText) Then
            My.Settings.ItemText = "C:\Windows\System32\Shell32.dll"
        End If

        ItemBox.Text = My.Settings.ItemText

        If My.Settings.ItemTextIsFolder Then
            ItemBox.Icon = My.Resources.ClosedFolder
        Else
            ItemBox.Icon = Shell32.GetIcon(My.Settings.ItemText).ToBitmap
        End If

        ProcessIconBox.Image = GrayScaleConverter.ColorImageToGrayScaleImage(My.Resources.Program_32)

    End Sub

    Private Sub LoadProcesses()

        SearchIconsInFilesRadioButton.Enabled = False
        LoadProcessesAgain.Visible = False

        LoadingLabel.Visible = True

        LoadingTimer.Start()

        ProcessListBox.Items.Clear()

        For Each Process As Process In Process.GetProcesses(My.Computer.Name)

            Application.DoEvents()

            On Error Resume Next

            For i As Integer = 0 To Process.Modules.Count - 1
                If Process.Modules(i).FileName.EndsWith(".exe") Or Process.Modules(i).FileName.EndsWith(".dll") Or Process.Modules(i).FileName.EndsWith(".ico") Or Process.Modules(i).FileName.EndsWith(".icl") Or Process.Modules(i).FileName.EndsWith(".ocx") Or Process.Modules(i).FileName.EndsWith(".cpl") Or Process.Modules(i).FileName.EndsWith(".scr") Then
                    ProcessListBox.Items.Add(Process.Modules(i).FileName)
                End If
                Application.DoEvents()
            Next

            Application.DoEvents()

        Next

        IsProcessesLoaded = True

        ProcessListBox.Select() : ProcessListBox.SelectedItem = ProcessListBox.Items(0)

        LoadingTimer.Stop()
        LoadingLabel.Text = LoadingProcesses

        LoadingLabel.Visible = False

        SearchIconsInFilesRadioButton.Enabled = True
        LoadProcessesAgain.Visible = True

    End Sub

    Public Sub CheckLang()

        INILangFile = New IniFile(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages").Item(My.Settings.Language))

        LoadLang()

    End Sub

    Public Sub LoadLang()

        'SomeCommands = INILangFile.GetString("SomeCommands", "")

        ExecutableFiles = INILangFile.GetString("SomeCommands", "ExecutableFiles")
        AllFiles = INILangFile.GetString("SomeCommands", "AllFiles")
        PleaseChooseAFile = INILangFile.GetString("SomeCommands", "PleaseChooseAFile")
        PleaseChooseAFolder = INILangFile.GetString("SomeCommands", "PleaseChooseAFolder")
        LoadingProcesses = INILangFile.GetString("SomeCommands", "LoadingProcesses")
        Loading = INILangFile.GetString("SomeCommands", "Loading")
        _byte = INILangFile.GetString("SomeCommands", "Byte")
        YB = INILangFile.GetString("SomeCommands", "YB")
        ZB = INILangFile.GetString("SomeCommands", "ZB")
        EB = INILangFile.GetString("SomeCommands", "EB")
        PB = INILangFile.GetString("SomeCommands", "PB")
        TB = INILangFile.GetString("SomeCommands", "TB")
        GB = INILangFile.GetString("SomeCommands", "GB")
        MB = INILangFile.GetString("SomeCommands", "MB")
        KB = INILangFile.GetString("SomeCommands", "KB")

        'frmOpenIcons = INILangFile.GetString("frmOpenIcons", "")

        Me.Text = INILangFile.GetString("frmOpenIcons", "Text")

        'frmOpenIconsControls = INILangFile.GetString("frmOpenIconsControls", "")

        StartTabPage.Text = INILangFile.GetString("frmOpenIconsControls", "Basics")
        SearchIconsInFilesRadioButton.Text = INILangFile.GetString("frmOpenIconsControls", "SearchIconsInFiles")
        OpenFolderButton.Text = INILangFile.GetString("frmOpenIconsControls", "OpenFolder")
        SubFoldersCheckBox.Text = INILangFile.GetString("frmOpenIconsControls", "SearchInSubFolders")
        ChooseFolderButton.Text = INILangFile.GetString("frmOpenIconsControls", "ChooseFolder")
        ChooseFileButton.Text = INILangFile.GetString("frmOpenIconsControls", "ChooseFile")
        SearchIconsInTheSeletedProcessRadioButton.Text = INILangFile.GetString("frmOpenIconsControls", "SearchIconsInTheSeletedProcess")
        Label1.Text = INILangFile.GetString("frmOpenIconsControls", "Name")
        Label2.Text = INILangFile.GetString("frmOpenIconsControls", "Size")
        ProcessName.Text = INILangFile.GetString("frmOpenIconsControls", "ChooseAProgram")
        ProcessSize.Text = INILangFile.GetString("frmOpenIconsControls", "ChooseAProgram")
        LoadingLabel.Text = LoadingProcesses
        LoadProcessesAgain.Text = INILangFile.GetString("frmOpenIconsControls", "LoadProcessesAgain")
        SearchButton.Text = INILangFile.GetString("frmOpenIconsControls", "SearchIcons")
        ExitButton.Text = INILangFile.GetString("frmOpenIconsControls", "Close")

    End Sub

    Private Sub ProcessListBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProcessListBox.SelectedIndexChanged

        ProcessName.Text = Loading
        ProcessSize.Text = Loading

        ProcessIconBox.Image = My.Resources.Program_32

        ProcessIconBox.Image = Icon.ExtractAssociatedIcon(ProcessListBox.SelectedItem).ToBitmap

        ProcessName.Text = My.Computer.FileSystem.GetFileInfo(ProcessListBox.SelectedItem).Name
        ProcessSize.Text = GetFileSize(My.Computer.FileSystem.GetFileInfo(ProcessListBox.SelectedItem).Length)

    End Sub

    Private Sub frmOpenIcons_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If CanSetIsClosed Then
            IsClosed = True
        End If

    End Sub

    Private Sub frmOpenIcons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckLang()

        LoadSettings()

    End Sub

    Private Sub LoadingTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoadingTimer.Tick

        If LoadingLabel.Text = LoadingProcesses Then
            LoadingLabel.Text = LoadingProcesses & "."
        ElseIf LoadingLabel.Text = LoadingProcesses & "." Then
            LoadingLabel.Text = LoadingProcesses & ".."
        ElseIf LoadingLabel.Text = LoadingProcesses & ".." Then
            LoadingLabel.Text = LoadingProcesses & "..."
        ElseIf LoadingLabel.Text = LoadingProcesses & "..." Then
            LoadingLabel.Text = LoadingProcesses
        End If

    End Sub

    Private Sub CheckButton_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckButton.Tick

        OpenFolderButton.Enabled = My.Settings.ItemText <> Nothing And My.Settings.SearchIconsInFiles

    End Sub

    Private Sub SearchIconsInFilesRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchIconsInFilesRadioButton.CheckedChanged

        My.Settings.SearchIconsInFiles = SearchIconsInFilesRadioButton.Checked
        My.Settings.SearchIconsInTheSeletedProcess = False

        CheckEnabled()

    End Sub

    Private Sub SubFoldersCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubFoldersCheckBox.CheckedChanged

        My.Settings.SearchSubFolders = SubFoldersCheckBox.Checked

    End Sub

    Private Sub SearchIconsInTheSeletedProcessRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchIconsInTheSeletedProcessRadioButton.CheckedChanged

        My.Settings.SearchIconsInTheSeletedProcess = SearchIconsInTheSeletedProcessRadioButton.Checked
        My.Settings.SearchIconsInFiles = False

        CheckEnabled()

    End Sub

    Private Sub LoadProcessesAgain_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LoadProcessesAgain.LinkClicked

        IsProcessesLoaded = False

        LoadProcesses()

    End Sub

    Private Sub OpenFolderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFolderButton.Click
        If My.Settings.ItemTextIsFolder Then
            Shell("Explorer " & My.Settings.ItemText, AppWinStyle.NormalFocus)
        Else
            Shell("Explorer " & My.Computer.FileSystem.GetFileInfo(My.Settings.ItemText).Directory.FullName, AppWinStyle.NormalFocus)
        End If
    End Sub

    Private Sub ChooseFolderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChooseFolderButton.Click

        Dim Dialog As New FolderBrowserDialog

        Dialog.Description = PleaseChooseAFolder
        Dialog.ShowNewFolderButton = True

        If My.Settings.ItemTextIsFolder Then
            Dialog.SelectedPath = My.Settings.ItemText
        Else
            Dialog.SelectedPath = My.Computer.FileSystem.GetFileInfo(My.Settings.ItemText).Directory.FullName
        End If

        If Dialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            My.Settings.ItemTextIsFolder = True
            My.Settings.ItemText = Dialog.SelectedPath

            If My.Settings.ItemTextIsFolder Then
                ItemBox.Icon = My.Resources.ClosedFolder
            Else
                ItemBox.Icon = Shell32.GetIcon(My.Settings.ItemText).ToBitmap
            End If

            ItemBox.Text = My.Settings.ItemText

        End If

    End Sub

    Private Sub ChooseFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChooseFileButton.Click

        Dim Dialog As New OpenFileDialog

        Dialog.Title = PleaseChooseAFile
        Dialog.Filter = "Alle støttede filer(*.exe; *.dll; *.ico; *.icl; *.ocx; *.cpl; *.scr)|*.exe; *.dll; *.ico; *.icl; *.ocx; *.cpl; *.scr|" & AllFiles & "(*.*)|*.*"

        If My.Settings.ItemTextIsFolder Then
            Dialog.InitialDirectory = My.Settings.ItemText
        Else
            Dialog.FileName = My.Settings.ItemText
        End If

        If Dialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            My.Settings.ItemTextIsFolder = False
            My.Settings.ItemText = Dialog.FileName

            If My.Settings.ItemTextIsFolder Then
                ItemBox.Icon = My.Resources.ClosedFolder
            Else
                ItemBox.Icon = Shell32.GetIcon(My.Settings.ItemText).ToBitmap
            End If

            ItemBox.Text = My.Settings.ItemText

        End If

    End Sub

    Private Sub SearchButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchButton.Click

        If Not ProcessListBox.SelectedItem = Nothing And SearchIconsInTheSeletedProcessRadioButton.Checked Then
            My.Settings.ItemTextIsFolder = False
            My.Settings.ItemText = ProcessListBox.SelectedItem
            My.Settings.SearchSubFolders = SubFoldersCheckBox.Checked
            CanSetIsClosed = True
            Me.Close()
        Else
            My.Settings.SearchSubFolders = SubFoldersCheckBox.Checked
            CanSetIsClosed = True
            Me.Close()
        End If

    End Sub

    Private Sub ExitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitButton.Click
        My.Settings.SearchSubFolders = SubFoldersCheckBox.Checked
        CanSetIsClosed = False
        Me.Close()
    End Sub
End Class