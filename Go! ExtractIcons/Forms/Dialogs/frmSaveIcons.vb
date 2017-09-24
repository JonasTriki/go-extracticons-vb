Imports System.IO
Public Class frmSaveIcons

    Dim m_GetFileSize As String

    Dim FDD As String

    Dim Success As String
    Dim Total As String
    Dim Icons As String
    Dim IsSaved As String

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

    Dim m_Icons As List(Of Icon)
    Dim m_ListOfNames As List(Of String)
    Dim m_ListOfIconFileNames As List(Of String)
    Dim m_ListOfIconFileNamesClean As List(Of String)

    Public Sub New(ByVal IconsToSave As List(Of Icon), ByVal ListOfNames As List(Of String), ByVal ListOfIconFileNames As List(Of String), ByVal ListOfIconFileNamesClean As List(Of String))

        InitializeComponent()

        m_Icons = IconsToSave
        m_ListOfNames = ListOfNames
        m_ListOfIconFileNames = ListOfIconFileNames
        m_ListOfIconFileNamesClean = ListOfIconFileNamesClean

    End Sub

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

    Public Function ShowMessageBox(ByVal Message As String, Optional ByVal MessageButton As MessageBox.MessageButtons = MessageBox.MessageButtons.OKOnly, Optional ByVal MessageIcon As MessageBox.MessageIcons = MessageBox.MessageIcons.Information, Optional ByVal Title As String = "", Optional ByVal Icon As Icon = Nothing, Optional ByVal ShowDoNotShowAgainCheckBox As Boolean = False, Optional ByVal IsDoNotShowAgainCheckBoxChecked As Boolean = False) As MessageBox.MessageDialogResults

        Dim MessageBox As New MessageBox(Message, MessageButton, MessageIcon, Title, Icon, ShowDoNotShowAgainCheckBox, IsDoNotShowAgainCheckBoxChecked)

        Return MessageBox.ShowDialog()

    End Function

    Public Sub CheckLang()

        INILangFile = New IniFile(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages").Item(My.Settings.Language))

        LoadLang()

    End Sub

    Public Sub LoadLang()

        'SomeCommands = INILangFile.GetString("SomeCommands", "")

        Success = INILangFile.GetString("SomeCommands", "Success")
        Total = INILangFile.GetString("SomeCommands", "Total")
        Icons = INILangFile.GetString("SomeCommands", "Icons")
        IsSaved = INILangFile.GetString("SomeCommands", "IsSaved")
        _byte = INILangFile.GetString("SomeCommands", "Byte")
        YB = INILangFile.GetString("SomeCommands", "YB")
        ZB = INILangFile.GetString("SomeCommands", "ZB")
        EB = INILangFile.GetString("SomeCommands", "EB")
        PB = INILangFile.GetString("SomeCommands", "PB")
        TB = INILangFile.GetString("SomeCommands", "TB")
        GB = INILangFile.GetString("SomeCommands", "GB")
        MB = INILangFile.GetString("SomeCommands", "MB")
        KB = INILangFile.GetString("SomeCommands", "KB")

        'frmSaveIcons = INILangFile.GetString("frmSaveIcons", "")

        Me.Text = INILangFile.GetString("frmSaveIcons", "Text")

        'frmSaveIconsControls = INILangFile.GetString("frmSaveIconsControls", "")

        FDD = INILangFile.GetString("frmSaveIconsControls", "FDD")
        SaveIconsToFolder.Text = INILangFile.GetString("frmSaveIconsControls", "SaveIconsToFolder")
        SaveIconsButton.Text = INILangFile.GetString("frmSaveIconsControls", "SaveIcons")
        CloseButton.Text = INILangFile.GetString("frmSaveIconsControls", "Close")

    End Sub

    Public Sub SaveIcon(ByVal Icon As Icon, ByVal FileName As String)

        Dim Stream As New StreamWriter(FileName)

        Icon.Save(Stream.BaseStream)

        Stream.Close()

    End Sub

    Private Sub CheckButton_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckButton.Tick

        SaveIconsButton.Enabled = Directory.Exists(FolderBox.Text)

    End Sub

    Private Sub frmSaveIcons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckLang()

        If My.Settings.SaveLocation = Nothing Then
            My.Settings.SaveLocation = My.Computer.FileSystem.SpecialDirectories.Desktop
        End If

        FolderBox.Text = My.Settings.SaveLocation

    End Sub

    Private Sub ChooseFolderButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChooseFolderButton.Click

        Dim Dialog As New FolderBrowserDialog

        Dialog.SelectedPath = FolderBox.Text
        Dialog.ShowNewFolderButton = True
        Dialog.Description = FDD

        If Dialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            FolderBox.Text = Dialog.SelectedPath

            My.Settings.SaveLocation = Dialog.SelectedPath

        End If

    End Sub

    Private Sub SaveIconsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveIconsButton.Click

        Dim m_Count As Integer = m_Icons.Count

        Dim m_IconSizes As Long = 0

        For i As Integer = 0 To m_Icons.Count - 1

            Dim Stream As New MemoryStream : m_Icons(i).Save(Stream) : m_IconSizes += Stream.Length

            If My.Computer.FileSystem.FileExists(FolderBox.Text & "\" & m_ListOfNames(i) & ".ico") Then

                Dim dlg As New frmFileAlreadyExists(m_ListOfIconFileNames(i), m_ListOfIconFileNamesClean(i), FolderBox.Text & "\" & m_ListOfNames(i) & ".ico")

                If dlg.ShowDialog = Windows.Forms.DialogResult.Cancel Then

                    Dim resultInfoEnumInfo As FileAlreadyExistsInfo.FileAlreadyExistsInfoEnum = dlg.resultInfo.EnumInfo

                    If resultInfoEnumInfo = FileAlreadyExistsInfo.FileAlreadyExistsInfoEnum.OverWriteFile Then
                        SaveIcon(m_Icons(i), FolderBox.Text & "\" & m_ListOfNames(i) & ".ico")
                    ElseIf resultInfoEnumInfo = FileAlreadyExistsInfo.FileAlreadyExistsInfoEnum.RenameFile Then
                        Dim dlgRN As New frmRenameName(FolderBox.Text & "\" & m_ListOfNames(i) & ".ico")
                        If dlgRN.ShowDialog = Windows.Forms.DialogResult.Cancel Then
                            If dlgRN.IsOK Then
                                SaveIcon(m_Icons(i), dlgRN.resultString)
                            End If
                        End If
                    ElseIf resultInfoEnumInfo = FileAlreadyExistsInfo.FileAlreadyExistsInfoEnum.OverWriteIfFileIsLarger Then
                        If My.Computer.FileSystem.GetFileInfo(FolderBox.Text & "\" & m_ListOfNames(i) & ".ico").Length > Stream.Length Then
                            SaveIcon(m_Icons(i), FolderBox.Text & "\" & m_ListOfNames(i) & ".ico")
                        End If
                    ElseIf resultInfoEnumInfo = FileAlreadyExistsInfo.FileAlreadyExistsInfoEnum.OverWriteIfFileIsSmaller Then
                        If My.Computer.FileSystem.GetFileInfo(FolderBox.Text & "\" & m_ListOfNames(i) & ".ico").Length < Stream.Length Then
                            SaveIcon(m_Icons(i), FolderBox.Text & "\" & m_ListOfNames(i) & ".ico")
                        End If
                    End If
                End If
            Else
                SaveIcon(m_Icons(i), FolderBox.Text & "\" & m_ListOfNames(i) & ".ico")
            End If

        Next

        ShowMessageBox(Total & " " & m_Count & " " & Icons & " " & IsSaved & "!" & vbCrLf & Total & " " & GetFileSize(m_IconSizes) & " " & IsSaved & "!", MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Information, Success)

        Me.Close()

    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub
End Class