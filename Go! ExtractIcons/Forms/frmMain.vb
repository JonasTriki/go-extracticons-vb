Imports System.IO
Imports System.Net
Imports Microsoft.Win32
Imports System.ComponentModel
Imports System.Security.Permissions

Public Class frmMain

    ' New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2)

    Dim IconList As New List(Of Icon)
    Dim m_GetFileSize As String

    Dim Err As String
    Dim NoMatch As String
    Dim Success As String
    Dim GoExtractIconsWillNotStartWhenWindowsStarts As String
    Dim GoExtractIconsWillStartWhenWindowsStarts As String

    Dim _of As String
    Dim ExtractingIconsFromFile As String
    Dim ExtractingIconsFrom As String

    Dim LookingForIconsInTheFolder As String

    Dim IconsFound As String
    Dim IconFound As String
    Dim NoIconsFound As String

    Dim IndexShoudBeInRange As String
    Dim NoIconsInTheList As String
    Dim TheFileDoesNotExistOrIsEmpty As String
    Dim TheFileDoesNotExist As String
    Dim TheFile As String
    Dim IsNotAnValidWin32ExecutableOrDLL As String
    Dim AnUnexpectedErrorHasArrived As String
    Dim TheIconsToTheFileIsNotAvailableYouCantExtractIconsFromThisFile As String
    Dim TheIconsListShoudContainAtLeastOneIcon As String
    Dim TheIconIsEmpty As String
    Dim AreYouSureYouWannaRestartGoExtractIcons As String
    Dim GoExtractIconsIsMinimizedToTheSystemFieldToMaximizeTheApplicationAgainClickTheBubble As String
    Dim MoreThanOneIconIsSelected As String
    Dim _Name As String
    Dim ID As String
    Dim IconSize As String
    Dim Icons As String
    Dim FileName As String
    Dim FileSize As String
    Dim IconsInFile As String
    Dim CompleteFileName As String
    Dim SearchedFiles As String
    Dim SearchedFolders As String

    Dim _byte As String
    Dim YB As String
    Dim ZB As String
    Dim EB As String
    Dim PB As String
    Dim TB As String
    Dim GB As String
    Dim MB As String
    Dim KB As String

    Dim SelectedFileName As String
    Dim IsAllowedToAfterSelect As Boolean = True
    Dim IsLoading As Boolean = False

    Dim SearchBoxWT As String
    Dim INILangFile As IniFile

    Dim performSearching As Boolean = False
    Public DoRestart As Boolean = False

    Enum ItemModes

        SearchFolder = 1

        SearchFiles = 2

    End Enum

    Enum Errors

        IndexShoudBeInRange = 1

        NoIconsInTheList = 2

        TheFileDoesNotExistOrIsEmpty = 3

        TheFileDoesNotExist = 4

        TheFileIsNotAnValidWin32ExecutableOrDLL = 5

        AnUnexpectedErrorHasArrived = 6

        TheIconsToTheFileIsNotAvailableYouCantExtractIconsFromThisFile = 7

        TheIconsListShoudContainAtLeastOneIcon = 8

        TheIconIsEmpty = 9

    End Enum

    <DefaultValue(False)> _
    Public ReadOnly Property DoesItRunAtStartUp() As Boolean
        Get
            Return Not Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", False).GetValue("Go! ExtractIcons") Is Nothing
        End Get
    End Property

    Public Sub RunAtStartUp(Optional ByVal DoRun As Boolean = True)
        Dim Key As RegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)

        If DoRun Then
            Key.SetValue("Go! ExtractIcons", """" & Application.ExecutablePath & """")
            ShowMessageBox(GoExtractIconsWillStartWhenWindowsStarts, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Information, Success)
        ElseIf Not DoRun Then
            Key.DeleteValue("Go! ExtractIcons")
            ShowMessageBox(GoExtractIconsWillNotStartWhenWindowsStarts, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Information, Success)
        End If
    End Sub

    Public Sub CheckLANGFileExtension()

        Registry.ClassesRoot.CreateSubKey(".lang").SetValue("", "LanguageFile", RegistryValueKind.String)
        Registry.ClassesRoot.CreateSubKey("LanguageFile\shell\open\command").SetValue("", Application.ExecutablePath & " ""%1"" ", RegistryValueKind.String)
        Registry.ClassesRoot.CreateSubKey("LanguageFile\DefaultIcon").SetValue("", Application.ExecutablePath & "\LANG_Icons.ico")

        Shell32.UpdateRegistry()

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

    Public Function ShowError(ByVal Err As Errors, Optional ByVal ExtraText As String = Nothing) As MessageBox.MessageDialogResults

        Dim Message As String = Nothing

        If Err = Errors.IndexShoudBeInRange Then
            Message = IndexShoudBeInRange & ExtraText
        ElseIf Err = Errors.NoIconsInTheList Then
            Message = NoIconsInTheList
        ElseIf Err = Errors.TheFileDoesNotExistOrIsEmpty Then
            Message = TheFileDoesNotExistOrIsEmpty
        ElseIf Err = Errors.TheFileDoesNotExist Then
            Message = TheFileDoesNotExist
        ElseIf Err = Errors.TheFileIsNotAnValidWin32ExecutableOrDLL Then
            Message = TheFile & ExtraText & IsNotAnValidWin32ExecutableOrDLL
        ElseIf Err = Errors.AnUnexpectedErrorHasArrived Then
            Message = AnUnexpectedErrorHasArrived
        ElseIf Err = Errors.TheIconsToTheFileIsNotAvailableYouCantExtractIconsFromThisFile Then
            Message = TheIconsToTheFileIsNotAvailableYouCantExtractIconsFromThisFile
        ElseIf Err = Errors.TheIconsListShoudContainAtLeastOneIcon Then
            Message = TheIconsListShoudContainAtLeastOneIcon
        ElseIf Err = Errors.TheIconIsEmpty Then
            Message = TheIconIsEmpty
        End If

        Dim MessageBox As New MessageBox(Message, Go__ExtractIcons.MessageBox.MessageButtons.OKOnly, Go__ExtractIcons.MessageBox.MessageIcons.Exlamation)

        Return MessageBox.ShowDialog()

    End Function

    Public Function ShowMessageBox(ByVal Message As String, Optional ByVal MessageButton As MessageBox.MessageButtons = MessageBox.MessageButtons.OKOnly, Optional ByVal MessageIcon As MessageBox.MessageIcons = MessageBox.MessageIcons.Information, Optional ByVal Title As String = "", Optional ByVal Icon As Icon = Nothing, Optional ByVal ShowDoNotShowAgainCheckBox As Boolean = False, Optional ByVal IsDoNotShowAgainCheckBoxChecked As Boolean = False) As MessageBox.MessageDialogResults

        Dim MessageBox As New MessageBox(Message, MessageButton, MessageIcon, Title, Icon, ShowDoNotShowAgainCheckBox, IsDoNotShowAgainCheckBoxChecked)

        Return MessageBox.ShowDialog()

    End Function

    Public Sub LoadItemInfo(ByVal Item As ListViewItem)

        StatusLabel.Text = _Name & " " & Item.SubItems(0).Text & " | " & ID & " " & Item.SubItems(1).Text & " | " & IconSize & " " & Item.SubItems(2).Text & " | " & Icons & " " & Item.SubItems(3).Text & " | " & FileName & " " & Item.SubItems(4).Text & " | " & FileSize & " " & Item.SubItems(5).Text & " | " & IconsInFile & " " & Item.SubItems(6).Text & " | " & CompleteFileName & " " & Item.SubItems(7).Text

    End Sub

    Public Function CheckIfListViewCanSearch(ByVal ListView As ListView, ByVal Text As String) As Boolean
        Return Not IsNothing(ListView.FindItemWithText(Text, True, 0, True))
    End Function

    Dim lastSearchedTreeViewIndex As Integer = 0
    Dim lastSearchedIndex As Integer = 0
    Public Sub Search()
        If IconListView.Items.Count > 0 And CheckIfListViewCanSearch(IconListView, SearchBox.Text) Then
            Try
                If Not lastSearchedIndex = IconListView.SelectedIndices(0) Then lastSearchedIndex = IconListView.SelectedIndices(0)
            Catch ex As Exception
            End Try
            Dim Item As ListViewItem
            Try
                Item = IconListView.FindItemWithText(SearchBox.Text, True, lastSearchedIndex, True)
            Catch ex As Exception
                Item = Nothing
            End Try
            If Not IsNothing(Item) Then
                IconListView.Select()
                Dim i As Integer = 0
                Do Until i = IconListView.Items.Count
                    IconListView.Items(i).Selected = False
                    i += 1
                Loop
                Item.Selected = True
                Item.EnsureVisible()
                lastSearchedIndex = Item.Index + 1
            Else
                lastSearchedIndex = 0
                Search()
            End If
        Else
            If My.Settings.IconTreeView Then
                Dim NL As List(Of TreeNode) = New TreeNodes().GetAllNodes(IconTreeView.Nodes)
                Dim RL As New List(Of TreeNode)
                For Each n As TreeNode In NL
                    If n.Text.ToLower.Contains(SearchBox.Text.ToLower) Then
                        RL.Add(n)
                    End If
                    Application.DoEvents()
                Next
                Dim hasSearched As Boolean = False
                For i As Integer = 0 To RL.Count - 1
                    If i = lastSearchedTreeViewIndex Then
                        IconTreeView.Select()
                        IconTreeView.Focus()
                        IconTreeView.SelectedNode = RL(i)
                        lastSearchedTreeViewIndex = IconTreeView.SelectedNode.Index + 1
                        hasSearched = True
                    End If
                Next
                If Not hasSearched And RL.Count > 0 Then
                    IconTreeView.Select()
                    IconTreeView.Focus()
                    IconTreeView.SelectedNode = RL(0)
                    lastSearchedTreeViewIndex = IconTreeView.SelectedNode.Index + 1
                End If
            Else
                ShowMessageBox(NoMatch, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Information, Err)
            End If
        End If
    End Sub

    Public Sub ShowFileProperties(ByVal FileName As String)

        If My.Computer.FileSystem.FileExists(FileName) Then
            SystemFileProperties.ShowFileProperties(FileName)
        Else
            ShowMessageBox(TheFileDoesNotExist, MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation)
        End If

    End Sub

    Public Sub SaveIcon(ByVal Icon As Icon, ByVal FileName As String)

        Dim Stream As New StreamWriter(FileName)

        Icon.Save(Stream.BaseStream)

        Stream.Close()

    End Sub

    Public Sub CheckLang()

        INILangFile = New IniFile(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages").Item(My.Settings.Language))

        LoadLang()

    End Sub

    Public Sub LoadLang()

        'Errors = INILangFile.GetString("Errors", "")

        IndexShoudBeInRange = INILangFile.GetString("Errors", "IndexShoudBeInRange")
        NoIconsInTheList = INILangFile.GetString("Errors", "NoIconsInTheList")
        TheFileDoesNotExistOrIsEmpty = INILangFile.GetString("Errors", "TheFileDoesNotExistOrIsEmpty")
        TheFileDoesNotExist = INILangFile.GetString("Errors", "TheFileDoesNotExist")
        TheFile = INILangFile.GetString("Errors", "TheFile")
        IsNotAnValidWin32ExecutableOrDLL = INILangFile.GetString("Errors", "IsNotAnValidWin32ExecutableOrDLL")
        AnUnexpectedErrorHasArrived = INILangFile.GetString("Errors", "AnUnexpectedErrorHasArrived")
        TheIconsToTheFileIsNotAvailableYouCantExtractIconsFromThisFile = INILangFile.GetString("Errors", "TheIconsToTheFileIsNotAvailableYouCantExtractIconsFromThisFile")
        TheIconsListShoudContainAtLeastOneIcon = INILangFile.GetString("Errors", "TheIconsListShoudContainAtLeastOneIcon")
        TheIconIsEmpty = INILangFile.GetString("Errors", "TheIconIsEmpty")

        'SomeCommands = INILangFile.GetString("SomeCommands", "")

        Err = INILangFile.GetString("SomeCommands", "Error")
        NoMatch = INILangFile.GetString("SomeCommands", "NoMatch")
        Success = INILangFile.GetString("SomeCommands", "Success")
        GoExtractIconsWillNotStartWhenWindowsStarts = INILangFile.GetString("SomeCommands", "GoExtractIconsWillNotStartWhenWindowsStarts")
        GoExtractIconsWillStartWhenWindowsStarts = INILangFile.GetString("SomeCommands", "GoExtractIconsWillStartWhenWindowsStarts")
        AreYouSureYouWannaRestartGoExtractIcons = INILangFile.GetString("SomeCommands", "AreYouSureYouWannaRestartGoExtractIcons")
        GoExtractIconsIsMinimizedToTheSystemFieldToMaximizeTheApplicationAgainClickTheBubble = INILangFile.GetString("SomeCommands", "GoExtractIconsIsMinimizedToTheSystemFieldToMaximizeTheApplicationAgainClickTheBubble")
        MoreThanOneIconIsSelected = INILangFile.GetString("SomeCommands", "MoreThanOneIconIsSelected")
        NoIconsInTheList = INILangFile.GetString("SomeCommands", "NoIconsInTheList")
        _byte = INILangFile.GetString("SomeCommands", "Byte")
        YB = INILangFile.GetString("SomeCommands", "YB")
        ZB = INILangFile.GetString("SomeCommands", "ZB")
        EB = INILangFile.GetString("SomeCommands", "EB")
        PB = INILangFile.GetString("SomeCommands", "PB")
        TB = INILangFile.GetString("SomeCommands", "TB")
        GB = INILangFile.GetString("SomeCommands", "GB")
        MB = INILangFile.GetString("SomeCommands", "MB")
        KB = INILangFile.GetString("SomeCommands", "KB")
        _Name = INILangFile.GetString("SomeCommands", "Name")
        ID = INILangFile.GetString("SomeCommands", "ID")
        IconSize = INILangFile.GetString("SomeCommands", "IconSize")
        Icons = INILangFile.GetString("SomeCommands", "_Icons")
        FileName = INILangFile.GetString("SomeCommands", "FileName")
        FileSize = INILangFile.GetString("SomeCommands", "FileSize")
        IconsInFile = INILangFile.GetString("SomeCommands", "IconsInFile")
        CompleteFileName = INILangFile.GetString("SomeCommands", "CompleteFileName")
        ExtractingIconsFromFile = INILangFile.GetString("SomeCommands", "ExtractingIconsFromFile")
        ExtractingIconsFrom = INILangFile.GetString("SomeCommands", "ExtractingIconsFrom")
        LookingForIconsInTheFolder = INILangFile.GetString("SomeCommands", "LookingForIconsInTheFolder")
        IconsFound = INILangFile.GetString("SomeCommands", "IconsFound")
        IconFound = INILangFile.GetString("SomeCommands", "IconFound")
        NoIconsFound = INILangFile.GetString("SomeCommands", "NoIconsFound")
        _of = INILangFile.GetString("SomeCommands", "Of")

        'MenuBarButtons = INILangFile.GetString("MenuBarButtons", "")

        FilToolStripMenuItem.Text = INILangFile.GetString("MenuBarButtons", "File")
        RedigerToolStripMenuItem.Text = INILangFile.GetString("MenuBarButtons", "Edit")
        VisToolStripMenuItem.Text = INILangFile.GetString("MenuBarButtons", "View")
        VerktøyToolStripMenuItem.Text = INILangFile.GetString("MenuBarButtons", "Tools")
        HjelpToolStripMenuItem.Text = INILangFile.GetString("MenuBarButtons", "Help")

        'MenuBarFileButtons = INILangFile.GetString("MenuBarFileButtons", "")

        SøkEtterIkonerINettsideToolStripMenuItem.Text = INILangFile.GetString("MenuBarFileButtons", "SearchIconsInWebsite")
        SøkEtterIkonerToolStripMenuItem.Text = INILangFile.GetString("MenuBarFileButtons", "SearchIcons")
        LagreIkonerToolStripMenuItem.Text = INILangFile.GetString("MenuBarFileButtons", "SaveIcons")
        FilEgenskaperToolStripMenuItem.Text = INILangFile.GetString("MenuBarFileButtons", "FileProperties")
        EgenskaperToolStripMenuItem.Text = INILangFile.GetString("MenuBarFileButtons", "Properties")
        AvsluttToolStripMenuItem.Text = INILangFile.GetString("MenuBarFileButtons", "Exit")

        'MenuBarEditButtons = INILangFile.GetString("MenuBarEditButtons", "")

        KopierMerkertIkonToolStripMenuItem.Text = INILangFile.GetString("MenuBarEditButtons", "CopySelectedIcon")
        MerkAlleIkonerToolStripMenuItem1.Text = INILangFile.GetString("MenuBarEditButtons", "SelectAllIcons")
        FjernMerkeringToolStripMenuItem.Text = INILangFile.GetString("MenuBarEditButtons", "DeSelectAll")
        SøkEtterToolStripMenuItem.Text = INILangFile.GetString("MenuBarEditButtons", "Search")

        'MenuBarViewButtons = INILangFile.GetString("MenuBarViewButtons", "")

        IkonVisningToolStripMenuItem.Text = INILangFile.GetString("MenuBarViewButtons", "IconView")
        StoreIkonerToolStripMenuItem.Text = INILangFile.GetString("MenuBarViewButtons", "BigIcons")
        SmåIkonerToolStripMenuItem.Text = INILangFile.GetString("MenuBarViewButtons", "SmallIcons")
        StoreIkonerMedDetaljerToolStripMenuItem.Text = INILangFile.GetString("MenuBarViewButtons", "BigIconsWithDetails")
        ListeToolStripMenuItem.Text = INILangFile.GetString("MenuBarViewButtons", "List")
        DetaljerToolStripMenuItem.Text = INILangFile.GetString("MenuBarViewButtons", "Details")
        IkonTreToolStripMenuItem.Text = INILangFile.GetString("MenuBarViewButtons", "IconTree")
        MenylinjeToolStripMenuItem.Text = INILangFile.GetString("MenuBarViewButtons", "MenuBar")
        StatuslinjeToolStripMenuItem.Text = INILangFile.GetString("MenuBarViewButtons", "StatusBar")

        'MenuBarToolsButtons = INILangFile.GetString("MenuBarToolsButtons", "")

        AlternativerToolStripMenuItem.Text = INILangFile.GetString("MenuBarToolsButtons", "Options")
        ÅpneIkonFletterToolStripMenuItem.Text = INILangFile.GetString("MenuBarToolsButtons", "OpenIconMerge")

        'MenuBarHelpButtons = INILangFile.GetString("MenuBarHelpButtons", "")

        StartGoExtractIconsNårWindowsStarterToolStripMenuItem.Text = INILangFile.GetString("MenuBarHelpButtons", "StartGoExtractIconsWhenWindowsStarts")
        SeEtterOppdateringerToolStripMenuItem.Text = INILangFile.GetString("MenuBarHelpButtons", "CheckForUpdates")
        RestartGoExtractIconsToolStripMenuItem.Text = INILangFile.GetString("MenuBarHelpButtons", "RestartGoExtractIcons")
        OmGoExtractIconsToolStripMenuItem1.Text = INILangFile.GetString("MenuBarHelpButtons", "AboutGoExtractIcons")

        'Backward = INILangFile.GetString("Backward", "")

        Backward.ToolTipTitle = INILangFile.GetString("Backward", "ToolTipTitle")
        Backward.ToolTipText = INILangFile.GetString("Backward", "ToolTipText")

        'Forward = INILangFile.GetString("Forward", "")

        Forward.ToolTipTitle = INILangFile.GetString("Forward", "ToolTipTitle")
        Forward.ToolTipText = INILangFile.GetString("Forward", "ToolTipText")

        'FileInfo = INILangFile.GetString("FileInfo", "")

        FileInfo.ToolTipTitle = INILangFile.GetString("FileInfo", "ToolTipTitle")
        FileInfo.ToolTipText = INILangFile.GetString("FileInfo", "ToolTipText")

        'SearchIcons = INILangFile.GetString("SearchIcons", "")

        SearchIcons.ToolTipTitle = INILangFile.GetString("SearchIcons", "ToolTipTitle")
        SearchIcons.ToolTipText = INILangFile.GetString("SearchIcons", "ToolTipText")

        'SaveIcons = INILangFile.GetString("SaveIcons", "")

        SaveIcons.ToolTipTitle = INILangFile.GetString("SaveIcons", "ToolTipTitle")
        SaveIcons.ToolTipText = INILangFile.GetString("SaveIcons", "ToolTipText")

        'SearchBox = INILangFile.GetString("SearchBox", "")

        SearchBoxWT = INILangFile.GetString("SearchBox", "WatermarkText")
        SearchBox.Text = SearchBoxWT

        'SearchAfterIcon = INILangFile.GetString("SearchAfterIcon", "")

        SearchAfterIcon.ToolTipTitle = INILangFile.GetString("SearchAfterIcon", "ToolTipTitle")
        SearchAfterIcon.ToolTipText = INILangFile.GetString("SearchAfterIcon", "ToolTipText")

        'FileBtn = INILangFile.GetString("FileBtn", "")

        FileBtn.TextToBtn = INILangFile.GetString("FileBtn", "Text")

        'FileBtnContextMenuBarButtons = INILangFile.GetString("FileBtnContextMenuBarButtons", "")

        FilToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarButtons", "File")
        RedigerToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarButtons", "Edit")
        VisToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarButtons", "View")
        VerktøyToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarButtons", "Tools")
        HjelpToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarButtons", "Help")
        SøkEtterIkonerToolStripMenuItem4.Text = INILangFile.GetString("FileBtnContextMenuBarButtons", "SearchIcons")
        AlternativerToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarButtons", "Options")
        ÅpneIkonfletterToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarButtons", "OpenIconMerge")
        VisMenylinjenToolStripMenuItem.Text = INILangFile.GetString("FileBtnContextMenuBarButtons", "ShowMenuBar")
        AvsluttToolStripMenuItem2.Text = INILangFile.GetString("FileBtnContextMenuBarButtons", "Exit")

        'FileBtnContextMenuBarFileButtons = INILangFile.GetString("FileBtnContextMenuBarFileButtons", "")

        SøkEtterIkonerToolStripMenuItem5.Text = INILangFile.GetString("FileBtnContextMenuBarFileButtons", "SearchIcons")
        LagreIkonerToolStripMenuItem2.Text = INILangFile.GetString("FileBtnContextMenuBarFileButtons", "SaveIcons")
        FilEgenskaperToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarFileButtons", "FileProperties")
        EgenskaperToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarFileButtons", "Properties")
        AvsluttToolStripMenuItem3.Text = INILangFile.GetString("FileBtnContextMenuBarFileButtons", "Exit")

        'FileBtnContextMenuBarEditButtons = INILangFile.GetString("FileBtnContextMenuBarEditButtons", "")

        KopierMerkertIkonToolStripMenuItem3.Text = INILangFile.GetString("FileBtnContextMenuBarEditButtons", "CopySelectedIcon")
        MerkAlleIkonerToolStripMenuItem2.Text = INILangFile.GetString("FileBtnContextMenuBarEditButtons", "SelectAllIcons")
        FjernMerkeringToolStripMenuItem3.Text = INILangFile.GetString("FileBtnContextMenuBarEditButtons", "DeSelectAll")
        SøkEtterToolStripMenuItem3.Text = INILangFile.GetString("FileBtnContextMenuBarEditButtons", "Search")

        'FileBtnContextMenuBarViewButtons = INILangFile.GetString("FileBtnContextMenuBarViewButtons", "")

        IkonVisningToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarViewButtons", "IconView")
        StoreIkonerToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarViewButtons", "BigIcons")
        SmåIkonerToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarViewButtons", "SmallIcons")
        StoreIkonerMedDetaljerToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarViewButtons", "BigIconsWithDetails")
        ListeToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarViewButtons", "List")
        DetaljerToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarViewButtons", "Details")
        IkonTreToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarViewButtons", "IconTree")
        MenylinjeToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarViewButtons", "MenuBar")
        StatuslinjeToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarViewButtons", "StatusBar")

        'FileBtnContextMenuBarToolsButtons = INILangFile.GetString("FileBtnContextMenuBarToolsButtons", "")

        AlternativerToolStripMenuItem2.Text = INILangFile.GetString("FileBtnContextMenuBarToolsButtons", "Options")
        ÅpneIkonFletterToolStripMenuItem2.Text = INILangFile.GetString("FileBtnContextMenuBarToolsButtons", "OpenIconMerge")

        'FileBtnContextMenuBarHelpButtons = INILangFile.GetString("FileBtnContextMenuBarHelpButtons", "")

        StartGoExtractIconsNårWindowsStarterToolStripMenuItem1.Text = INILangFile.GetString("FileBtnContextMenuBarHelpButtons", "StartGoExtractIconsWhenWindowsStarts")
        SeEtterOppdateringerToolStripMenuItem2.Text = INILangFile.GetString("FileBtnContextMenuBarHelpButtons", "CheckForUpdates")
        RestartGoExtractIconsToolStripMenuItem2.Text = INILangFile.GetString("FileBtnContextMenuBarHelpButtons", "RestartGoExtractIcons")
        OmGoExtractIconsToolStripMenuItem2.Text = INILangFile.GetString("FileBtnContextMenuBarHelpButtons", "AboutGoExtractIcons")

        'IconTreeView = INILangFile.GetString("IconTreeView", "")

        SearchedFiles = INILangFile.GetString("IconTreeView", "SearchedFiles")
        SearchedFolders = INILangFile.GetString("IconTreeView", "SearchedFolders")

        'IconTreeViewContextMenuBarButtons = INILangFile.GetString("IconTreeViewContextMenuBarButtons", "")

        ÅpneEgenskaperForIkonToolStripMenuItem1.Text = INILangFile.GetString("IconTreeViewContextMenuBarButtons", "OpenPropertiesForIcon")
        ÅpneEgenskaperForFilToolStripMenuItem1.Text = INILangFile.GetString("IconTreeViewContextMenuBarButtons", "OpenPropertiesForFile")
        SøkEtterIkonerToolStripMenuItem3.Text = INILangFile.GetString("IconTreeViewContextMenuBarButtons", "SearchIcons")
        LagreIkonTilToolStripMenuItem.Text = INILangFile.GetString("IconTreeViewContextMenuBarButtons", "SaveIconTo")
        KopierMerkertIkonToolStripMenuItem2.Text = INILangFile.GetString("IconTreeViewContextMenuBarButtons", "CopySelectedIcon")
        SøkEtterToolStripMenuItem2.Text = INILangFile.GetString("IconTreeViewContextMenuBarButtons", "Search")

        'IconListView = INILangFile.GetString("IconListView", "")

        NameColumn.Text = INILangFile.GetString("IconListView", "Name")
        IDColumn.Text = INILangFile.GetString("IconListView", "ID")
        IconSizeColumn.Text = INILangFile.GetString("IconListView", "IconSize")
        IconsColumn.Text = INILangFile.GetString("IconListView", "Icons")
        FileNameColumn.Text = INILangFile.GetString("IconListView", "FileName")
        FileSizeColumn.Text = INILangFile.GetString("IconListView", "FileSize")
        TotalIconsColumn.Text = INILangFile.GetString("IconListView", "TotalIcons")
        CompleteFileNameColumn.Text = INILangFile.GetString("IconListView", "CompleteFileName")

        'IconListViewContextMenuBarButtons = INILangFile.GetString("IconListViewContextMenuBarButtons", "")

        ÅpneEgenskaperForIkonToolStripMenuItem.Text = INILangFile.GetString("IconListViewContextMenuBarButtons", "OpenPropertiesForIcon")
        ÅpneEgenskaperForFilToolStripMenuItem.Text = INILangFile.GetString("IconListViewContextMenuBarButtons", "OpenPropertiesForFile")
        SøkEtterIkonerToolStripMenuItem2.Text = INILangFile.GetString("IconListViewContextMenuBarButtons", "SearchIcons")
        LagreIkonerToolStripMenuItem1.Text = INILangFile.GetString("IconListViewContextMenuBarButtons", "SaveIcons")
        KopierMerkertIkonToolStripMenuItem1.Text = INILangFile.GetString("IconListViewContextMenuBarButtons", "CopySelectedIcon")
        MerkAlleIkonerToolStripMenuItem.Text = INILangFile.GetString("IconListViewContextMenuBarButtons", "SelectAllIcons")
        FjernMerkeringToolStripMenuItem2.Text = INILangFile.GetString("IconListViewContextMenuBarButtons", "DeSelectAll")
        SøkEtterToolStripMenuItem1.Text = INILangFile.GetString("IconListViewContextMenuBarButtons", "Search")

        'SearchBoxContextMenuBarButtons = INILangFile.GetString("SearchBoxContextMenuBarButtons", "")

        AngreToolStripMenuItem.Text = INILangFile.GetString("SearchBoxContextMenuBarButtons", "Undo")
        SlettAngreToolStripMenuItem.Text = INILangFile.GetString("SearchBoxContextMenuBarButtons", "ClearUndo")
        KopierToolStripMenuItem.Text = INILangFile.GetString("SearchBoxContextMenuBarButtons", "Copy")
        LimInnToolStripMenuItem.Text = INILangFile.GetString("SearchBoxContextMenuBarButtons", "Paste")
        LimInnOgSøkEtterToolStripMenuItem.Text = INILangFile.GetString("SearchBoxContextMenuBarButtons", "PasteAndSearch")
        KlippUtToolStripMenuItem.Text = INILangFile.GetString("SearchBoxContextMenuBarButtons", "Cut")
        MerkAltToolStripMenuItem.Text = INILangFile.GetString("SearchBoxContextMenuBarButtons", "SelectAll")
        FjernMerkeringToolStripMenuItem1.Text = INILangFile.GetString("SearchBoxContextMenuBarButtons", "DeSelectAll")
        SlettToolStripMenuItem.Text = INILangFile.GetString("SearchBoxContextMenuBarButtons", "Delete")
        SlettAltToolStripMenuItem.Text = INILangFile.GetString("SearchBoxContextMenuBarButtons", "ClearAll")

        'SystemIconContextMenuBarButtons = INILangFile.GetString("SystemIconContextMenuBarButtons", "")

        MinimerToolStripMenuItem.Text = INILangFile.GetString("SystemIconContextMenuBarButtons", "Minimize")
        MaksimerToolStripMenuItem.Text = INILangFile.GetString("SystemIconContextMenuBarButtons", "Maximize")
        SøkEtterIkonerToolStripMenuItem1.Text = INILangFile.GetString("SystemIconContextMenuBarButtons", "SearchIcons")
        SeEtterOppdateringerToolStripMenuItem1.Text = INILangFile.GetString("SystemIconContextMenuBarButtons", "CheckForUpdates")
        RestartGoExtractIconsToolStripMenuItem1.Text = INILangFile.GetString("SystemIconContextMenuBarButtons", "RestartGoExtractIcons")
        OmGoExtractIconsToolStripMenuItem.Text = INILangFile.GetString("SystemIconContextMenuBarButtons", "AboutGoExtractIcons")
        AvsluttToolStripMenuItem1.Text = INILangFile.GetString("SystemIconContextMenuBarButtons", "Exit")

    End Sub

    Public Sub SetProgressBarVisibility(ByVal Visible As Boolean)
        ProgressBar.Visible = Visible
        SpaceLabel.Visible = Visible
    End Sub

    Public Sub AddIconToListView(ByVal FileName As String)

        IconListView.Items.Clear()

        Dim IL As New List(Of Icon)

        IL = IconHelper.ExtractAllIcons(FileName)

        IconList.AddRange(IL)

        SetProgressBarVisibility(True)

        For i As Integer = 0 To IL.Count - 1

            On Error Resume Next

            StatusLabel.Text = ExtractingIconsFromFile & " (" & i + 1 & " " & _of & " " & IconList.Count & ")"

            ProgressBar.Maximum = IL.Count
            ProgressBar.Value = i + 1

            SmallImageList.Images.Add(My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")", IconHelper.GetBestFitIcon(IL(i), New Size(16, 16)))
            LargeImageList.Images.Add(My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")", IconHelper.GetBestFitIcon(IL(i), New Size(32, 32)))

            Dim Item As New ListViewItem(My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")", My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")")

            'Get the Icon File Size
            Dim Stream As New MemoryStream : IL(i).Save(Stream)

            With Item.SubItems
                .Add(i + 1)
                .Add(GetFileSize(Stream.Length))
                .Add(IconHelper.SplitGroupIcon(IL(i)).Count)
                .Add(My.Computer.FileSystem.GetFileInfo(FileName).Name)
                .Add(GetFileSize(My.Computer.FileSystem.GetFileInfo(FileName).Length))
                .Add(IL.Count)
                .Add(My.Computer.FileSystem.GetFileInfo(FileName).FullName)
            End With

            Stream.Close()

            Item.Tag = IL(i)

            IconListView.Items.Add(Item)

            Application.DoEvents()

        Next

        If My.Settings.IconTreeView Then

            If Not TreeViewImageList.Images.ContainsKey(IO.Path.GetExtension(FileName)) Then _
            TreeViewImageList.Images.Add(IO.Path.GetExtension(FileName), Shell32.GetIcon(FileName))

            Dim FileNode As New TreeNode

            FileNode.ImageKey = IO.Path.GetExtension(FileName)
            FileNode.SelectedImageKey = IO.Path.GetExtension(FileName)
            FileNode.StateImageKey = IO.Path.GetExtension(FileName)

            FileNode.Tag = "FileNode"
            FileNode.Name = "FileNode|" & FileName
            FileNode.Text = My.Computer.FileSystem.GetFileInfo(FileName).Name

            IconTreeView.Nodes("SearchedFilesNode|SearchedFilesNode").Nodes.Add(FileNode)

            FileNode.ExpandAll()
            IconTreeView.Focus()

            IconTreeView.SelectedNode = FileNode

            For i As Integer = 0 To IL.Count - 1

                StatusLabel.Text = ExtractingIconsFromFile & " (" & i + 1 & " " & _of & " " & IconList.Count & ")"

                ProgressBar.Maximum = IL.Count
                ProgressBar.Value = i + 1

                TreeViewImageList.Images.Add(My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")", IconHelper.GetBestFitIcon(IL(i), New Size(16, 16)))

                Dim ItemNode As New TreeNode

                ItemNode.ImageKey = My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")"
                ItemNode.SelectedImageKey = My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")"
                ItemNode.StateImageKey = My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")"

                ItemNode.Tag = IL(i)
                ItemNode.Name = "ItemNode|" & FileName
                ItemNode.Text = My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")"

                FileNode.Nodes.Add(ItemNode)

                If i = 0 Then
                    IconTreeView.SelectedNode = ItemNode
                End If

                Application.DoEvents()

            Next

        End If

        SetProgressBarVisibility(False)

    End Sub

    Dim loadingNode As TreeNode
    Private Sub ReloadItemsFromItemNode(ByVal Node As TreeNode, ByVal FileName As String)

        loadingNode = Node

        IconListView.Cursor = Cursors.WaitCursor
        IconListView.Visible = False

        IconListView.Items.Clear()

        IsLoading = True

        Dim fFileNames As New List(Of String)
        Dim fIL As New List(Of List(Of Icon))

        Dim IL As New List(Of Icon)

        If Split(Node.Name, "|")(0) = "FileNode" Then
            For Each n As TreeNode In Node.Nodes
                IL.Add(n.Tag)
                Application.DoEvents()
            Next
        ElseIf Split(Node.Name, "|")(0) = "ItemNode" Then
            For Each n As TreeNode In Node.Parent.Nodes
                IL.Add(n.Tag)
                Application.DoEvents()
            Next
        ElseIf Split(Node.Name, "|")(0) = "Folder" Then
            For Each n As TreeNode In Node.Nodes
                fFileNames.Add(Split(n.Name, "|")(1))
                Dim fNIL As New List(Of Icon)
                For Each ni As TreeNode In n.Nodes
                    fNIL.Add(ni.Tag)
                    Application.DoEvents()
                Next
                fIL.Add(fNIL)
                Application.DoEvents()
            Next
        End If

        SetProgressBarVisibility(True)
        IconList.Clear()

        If Split(Node.Name, "|")(0) = "Folder" Then
            Dim CountOfIcons As Integer = 0
            For Each f As String In fFileNames
                Dim icl As List(Of Icon) = fIL(fFileNames.IndexOf(f))
                IconList.AddRange(icl)
                CountOfIcons += IconListView.Items.Count
                For i As Integer = 0 To icl.Count - 1
                    If stopSearching Then Exit For
                    On Error Resume Next

                    StatusLabel.Text = ExtractingIconsFromFile & " (" & i + 1 & " " & _of & " " & icl.Count & ")"

                    ProgressBar.Maximum = icl.Count
                    ProgressBar.Value = i + 1

                    SmallImageList.Images.Add(My.Computer.FileSystem.GetFileInfo(f).Name & " (" & i + 1 + CountOfIcons - 1 & ")", IconHelper.GetBestFitIcon(icl(i), New Size(16, 16)))
                    LargeImageList.Images.Add(My.Computer.FileSystem.GetFileInfo(f).Name & " (" & i + 1 + CountOfIcons - 1 & ")", IconHelper.GetBestFitIcon(icl(i), New Size(32, 32)))

                    Dim Item As New ListViewItem(My.Computer.FileSystem.GetFileInfo(f).Name & " (" & i + 1 + CountOfIcons - 1 & ")", My.Computer.FileSystem.GetFileInfo(f).Name & " (" & i + 1 + CountOfIcons - 1 & ")")

                    'Get the Icon File Size
                    Dim Stream As New MemoryStream : icl(i).Save(Stream)

                    With Item.SubItems
                        .Add(i + 1)
                        .Add(GetFileSize(Stream.Length))
                        .Add(IconHelper.SplitGroupIcon(icl(i)).Count)
                        .Add(My.Computer.FileSystem.GetFileInfo(f).Name)
                        .Add(GetFileSize(f.Length))
                        .Add(icl.Count)
                        .Add(f)
                    End With

                    Stream.Close()

                    Item.Tag = icl(i)

                    IconListView.Items.Add(Item)

                    Application.DoEvents()

                Next
                Application.DoEvents()
            Next
        Else
            Dim Icons As List(Of Icon) = IL
            IconList.AddRange(IL)
            For i As Integer = 0 To Icons.Count - 1
                If stopSearching Then Exit For
                On Error Resume Next

                StatusLabel.Text = ExtractingIconsFromFile & " (" & i + 1 & " " & _of & " " & Icons.Count & ")"

                ProgressBar.Maximum = Icons.Count
                ProgressBar.Value = i + 1

                If Not SmallImageList.Images.ContainsKey(My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")") Then _
                SmallImageList.Images.Add(My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")", IconHelper.GetBestFitIcon(Icons(i), New Size(16, 16)))
                If Not LargeImageList.Images.ContainsKey(My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")") Then _
                LargeImageList.Images.Add(My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")", IconHelper.GetBestFitIcon(Icons(i), New Size(32, 32)))

                Dim Item As New ListViewItem(My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")", My.Computer.FileSystem.GetFileInfo(FileName).Name & " (" & i + 1 & ")")

                'Get the Icon File Size
                Dim Stream As New MemoryStream : Icons(i).Save(Stream)

                With Item.SubItems
                    .Add(i + 1)
                    .Add(GetFileSize(Stream.Length))
                    .Add(IconHelper.SplitGroupIcon(Icons(i)).Count)
                    .Add(My.Computer.FileSystem.GetFileInfo(FileName).Name)
                    .Add(GetFileSize(My.Computer.FileSystem.GetFileInfo(FileName).Length))
                    .Add(Icons.Count)
                    .Add(My.Computer.FileSystem.GetFileInfo(FileName).FullName)
                End With

                Stream.Close()

                Item.Tag = Icons(i)

                IconListView.Items.Add(Item)

                Application.DoEvents()

            Next
        End If

        If Icons.Count > 0 Then
            IconListView.Focus()
            IconListView.Items(0).Selected = True
        End If

        Me.Text = My.Computer.FileSystem.GetFileInfo(FileName).Name & " - Go! ExtractIcons"
        SystemIcon.Text = Me.Text

        IconToIconBox.Image = Shell32.GetIcon(FileName).ToBitmap

        StatusLabel.Text = IIf(IconListView.Items.Count <> 0, IIf(IconListView.Items.Count > 1, IconListView.Items.Count & " " & IconsFound, "1 " & IconFound), NoIconsFound)

        IconListView.Visible = True
        IconListView.Cursor = Cursors.Default
        IconListView.Focus()

        IsLoading = False

        loadingNode = Nothing

        SetProgressBarVisibility(False)

    End Sub

    Dim searchFolderFileList As New List(Of String)
    Dim searchFolderIconList As New List(Of List(Of Icon))
    Private Sub SearchFolder(ByVal Directory As String, ByVal SearchSubFolders As Boolean, ByVal ExtensionsToLookFor As String)

        For Each ext As String In ExtensionsToLookFor.Split(";")
            If stopSearching Then Exit For
            StatusLabel.Text = LookingForIconsInTheFolder & " """ & Directory & """..."
            For Each f As FileInfo In New DirectoryInfo(Directory).GetFiles(ext)
                If stopSearching Then Exit For
                StatusLabel.Text = LookingForIconsInTheFolder & " """ & f.FullName & """..."
                Dim IL As List(Of Icon) = IconHelper.ExtractAllIcons(f.FullName)
                If IL.Count > 0 Then
                    searchFolderIconList.Add(IL)
                    searchFolderFileList.Add(f.FullName)
                End If

                IconList.AddRange(IL)

                For i As Integer = 0 To IL.Count - 1

                    On Error Resume Next

                    StatusLabel.Text = ExtractingIconsFrom & " " & f.Name & "... (" & i + 1 & " " & _of & " " & IL.Count & ")"

                    ProgressBar.Maximum = IL.Count
                    ProgressBar.Value = i + 1

                    SmallImageList.Images.Add(f.Name & " (" & i + 1 + IconList.Count - 1 & ")", IconHelper.GetBestFitIcon(IL(i), New Size(16, 16)))
                    LargeImageList.Images.Add(f.Name & " (" & i + 1 + IconList.Count - 1 & ")", IconHelper.GetBestFitIcon(IL(i), New Size(32, 32)))

                    Dim Item As New ListViewItem(f.Name & " (" & i + 1 + IconList.Count - 1 & ")", f.Name & " (" & i + 1 + IconList.Count - 1 & ")")

                    'Get the Icon File Size
                    Dim Stream As New MemoryStream : IL(i).Save(Stream)

                    With Item.SubItems
                        .Add(i + 1)
                        .Add(GetFileSize(Stream.Length))
                        .Add(IconHelper.SplitGroupIcon(IL(i)).Count)
                        .Add(f.Name)
                        .Add(GetFileSize(f.Length))
                        .Add(IL.Count)
                        .Add(f.FullName)
                    End With

                    Stream.Close()

                    Item.Tag = IL(i)

                    IconListView.Items.Add(Item)

                    Application.DoEvents()

                Next

                Application.DoEvents()

            Next

            Application.DoEvents()

        Next

        If SearchSubFolders Then

            On Error Resume Next

            For Each subdirectory As DirectoryInfo In New DirectoryInfo(Directory).GetDirectories
                If stopSearching Then Exit For
                SearchFolder(subdirectory.FullName, SearchSubFolders, ExtensionsToLookFor)
                Application.DoEvents()
            Next

        End If

    End Sub

    Private stopSearching As Boolean = False

    Public Function PerformSearch(ByVal ItemText As String, ByVal ItemMode As ItemModes) As Boolean

        SetProgressBarVisibility(True)

        stopSearching = False

        IconListView.Cursor = Cursors.WaitCursor
        IconListView.Visible = False

        IsAllowedToAfterSelect = False

        IsLoading = True
        performSearching = True

        SmallImageList.Images.Clear()
        LargeImageList.Images.Clear()

        IconListView.Items.Clear()

        If ItemMode = ItemModes.SearchFiles Then

            IconList = IconHelper.ExtractAllIcons(ItemText)

            For i As Integer = 0 To IconList.Count - 1
                If stopSearching Then Exit For

                On Error Resume Next

                StatusLabel.Text = ExtractingIconsFromFile & " (" & i + 1 & " " & _of & " " & IconList.Count & ")"

                ProgressBar.Maximum = IconList.Count
                ProgressBar.Value = i + 1

                SmallImageList.Images.Add(My.Computer.FileSystem.GetFileInfo(ItemText).Name & " (" & i + 1 & ")", IconHelper.GetBestFitIcon(IconList(i), New Size(16, 16)))
                LargeImageList.Images.Add(My.Computer.FileSystem.GetFileInfo(ItemText).Name & " (" & i + 1 & ")", IconHelper.GetBestFitIcon(IconList(i), New Size(32, 32)))

                Dim Item As New ListViewItem(My.Computer.FileSystem.GetFileInfo(ItemText).Name & " (" & i + 1 & ")", My.Computer.FileSystem.GetFileInfo(ItemText).Name & " (" & i + 1 & ")")

                'Get the Icon File Size
                Dim Stream As New MemoryStream : IconList(i).Save(Stream)

                With Item.SubItems
                    .Add(i + 1)
                    .Add(GetFileSize(Stream.Length))
                    .Add(IconHelper.SplitGroupIcon(IconList(i)).Count)
                    .Add(My.Computer.FileSystem.GetFileInfo(ItemText).Name)
                    .Add(GetFileSize(My.Computer.FileSystem.GetFileInfo(ItemText).Length))
                    .Add(IconList.Count)
                    .Add(My.Computer.FileSystem.GetFileInfo(ItemText).FullName)
                End With

                Stream.Close()

                Item.Tag = IconList(i)

                IconListView.Items.Add(Item)

                Application.DoEvents()

            Next

            StatusLabel.Text = IIf(IconListView.Items.Count <> 0, IIf(IconListView.Items.Count > 1, IconListView.Items.Count & " " & IconsFound, "1 " & IconFound), NoIconsFound)

            If My.Settings.IconTreeView Then

                If Not TreeViewImageList.Images.ContainsKey(IO.Path.GetExtension(ItemText)) Then _
                TreeViewImageList.Images.Add(IO.Path.GetExtension(ItemText), Shell32.GetIcon(ItemText))

                Dim FileNode As New TreeNode

                FileNode.ImageKey = IO.Path.GetExtension(ItemText)
                FileNode.SelectedImageKey = IO.Path.GetExtension(ItemText)
                FileNode.StateImageKey = IO.Path.GetExtension(ItemText)

                FileNode.Tag = "FileNode"
                FileNode.Name = "FileNode|" & ItemText
                FileNode.Text = My.Computer.FileSystem.GetFileInfo(ItemText).Name

                IconTreeView.Nodes("SearchedFilesNode|SearchedFilesNode").Nodes.Add(FileNode)

                FileNode.ExpandAll()
                IconTreeView.Focus()

                IconTreeView.SelectedNode = FileNode

                For i As Integer = 0 To IconList.Count - 1
                    If stopSearching Then Exit For
                    TreeViewImageList.Images.Add(My.Computer.FileSystem.GetFileInfo(ItemText).Name & " (" & i + 1 & ")", IconHelper.GetBestFitIcon(IconList(i), New Size(16, 16)))

                    Dim ItemNode As New TreeNode

                    StatusLabel.Text = ExtractingIconsFromFile & " (" & i + 1 & " " & _of & " " & IconList.Count & ")"

                    ProgressBar.Maximum = IconList.Count
                    ProgressBar.Value = i + 1

                    ItemNode.ImageKey = My.Computer.FileSystem.GetFileInfo(ItemText).Name & " (" & i + 1 & ")"
                    ItemNode.SelectedImageKey = My.Computer.FileSystem.GetFileInfo(ItemText).Name & " (" & i + 1 & ")"
                    ItemNode.StateImageKey = My.Computer.FileSystem.GetFileInfo(ItemText).Name & " (" & i + 1 & ")"

                    ItemNode.Tag = IconList(i)
                    ItemNode.Name = "ItemNode|" & ItemText
                    ItemNode.Text = My.Computer.FileSystem.GetFileInfo(ItemText).Name & " (" & i + 1 & ")"

                    FileNode.Nodes.Add(ItemNode)

                    If i = 0 Then
                        IconTreeView.SelectedNode = ItemNode
                    End If

                    Application.DoEvents()

                Next

            End If

        ElseIf ItemMode = ItemModes.SearchFolder Then

            IconList.Clear()

            SearchFolder(ItemText, My.Settings.SearchSubFolders, "*.exe;*.dll;*.ico;*.icl;*.ocx;*.cpl;*.scr")
            If stopSearching Then stopSearching = False

            If My.Settings.IconTreeView Then

                Dim FolderNode As New TreeNode

                FolderNode.ImageKey = "ClosedFolder"
                FolderNode.SelectedImageKey = "ClosedFolder"
                FolderNode.StateImageKey = "ClosedFolder"

                FolderNode.Tag = "Folder"
                FolderNode.Name = "Folder|" & ItemText
                FolderNode.Text = My.Computer.FileSystem.GetDirectoryInfo(ItemText).Name

                FolderNode.ExpandAll()
                IconTreeView.Focus()

                IconTreeView.Nodes("SearchedFoldersNode|SearchedFoldersNode").Nodes.Add(FolderNode)

                For Each f As String In searchFolderFileList
                    If stopSearching Then Exit For

                    If Not TreeViewImageList.Images.ContainsKey(IO.Path.GetExtension(f)) Then _
                    TreeViewImageList.Images.Add(IO.Path.GetExtension(f), Shell32.GetIcon(f))

                    Dim FileNode As New TreeNode

                    FileNode.ImageKey = IO.Path.GetExtension(f)
                    FileNode.SelectedImageKey = IO.Path.GetExtension(f)
                    FileNode.StateImageKey = IO.Path.GetExtension(f)

                    FileNode.Tag = "FileNode"
                    FileNode.Name = "FileNode|" & f
                    FileNode.Text = IO.Path.GetFileName(f)

                    Dim icl As List(Of Icon) = searchFolderIconList(searchFolderFileList.IndexOf(f))
                    IconList.AddRange(icl)

                    For i As Integer = 0 To icl.Count - 1
                        If stopSearching Then Exit For

                        TreeViewImageList.Images.Add(IO.Path.GetFileName(f) & " (" & i + 1 & ")", IconHelper.GetBestFitIcon(icl(i), New Size(16, 16)))

                        Dim ItemNode As New TreeNode

                        ItemNode.ImageKey = IO.Path.GetFileName(f) & " (" & i + 1 & ")"
                        ItemNode.SelectedImageKey = IO.Path.GetFileName(f) & " (" & i + 1 & ")"
                        ItemNode.StateImageKey = IO.Path.GetFileName(f) & " (" & i + 1 & ")"

                        ItemNode.Tag = icl(i)
                        ItemNode.Name = "ItemNode|" & f
                        ItemNode.Text = IO.Path.GetFileName(f) & " (" & i + 1 & ")"

                        FileNode.Nodes.Add(ItemNode)

                        Application.DoEvents()

                    Next

                    FolderNode.Nodes.Add(FileNode)

                    Application.DoEvents()

                Next

            End If

        End If

        StatusLabel.Text = IIf(IconListView.Items.Count <> 0, IIf(IconListView.Items.Count > 1, IconListView.Items.Count & " " & IconsFound, "1 " & IconFound), NoIconsFound)

        Me.Text = My.Computer.FileSystem.GetFileInfo(ItemText).Name & " - Go! ExtractIcons"
        SystemIcon.Text = Me.Text

        IsLoading = False
        performSearching = False

        IsAllowedToAfterSelect = True

        SelectedFileName = ItemText

        If ItemMode = ItemModes.SearchFiles Then
            IconToIconBox.Image = Shell32.GetIcon(ItemText).ToBitmap
        ElseIf ItemMode = ItemModes.SearchFolder Then
            IconToIconBox.Image = My.Resources.ClosedFolder
        End If

        IconListView.Visible = True
        IconListView.Cursor = Cursors.Default
        IconListView.Focus()

        SetProgressBarVisibility(False)

        Return True

    End Function

    Public Sub CheckView()
        IconListView.View = My.Settings.View

        If My.Settings.View = View.LargeIcon Then

            StoreIkonerToolStripMenuItem.CheckState = CheckState.Indeterminate
            SmåIkonerToolStripMenuItem.CheckState = CheckState.Unchecked
            StoreIkonerMedDetaljerToolStripMenuItem.CheckState = CheckState.Unchecked
            ListeToolStripMenuItem.CheckState = CheckState.Unchecked
            DetaljerToolStripMenuItem.CheckState = CheckState.Unchecked

            StoreIkonerToolStripMenuItem1.CheckState = CheckState.Indeterminate
            SmåIkonerToolStripMenuItem1.CheckState = CheckState.Unchecked
            StoreIkonerMedDetaljerToolStripMenuItem1.CheckState = CheckState.Unchecked
            ListeToolStripMenuItem1.CheckState = CheckState.Unchecked
            DetaljerToolStripMenuItem1.CheckState = CheckState.Unchecked

            IconListView.LargeImageList = LargeImageList
            IconListView.SmallImageList = Nothing
            IconListView.StateImageList = Nothing

        ElseIf My.Settings.View = View.SmallIcon Then


            StoreIkonerToolStripMenuItem.CheckState = CheckState.Unchecked
            SmåIkonerToolStripMenuItem.CheckState = CheckState.Indeterminate
            StoreIkonerMedDetaljerToolStripMenuItem.CheckState = CheckState.Unchecked
            ListeToolStripMenuItem.CheckState = CheckState.Unchecked
            DetaljerToolStripMenuItem.CheckState = CheckState.Unchecked

            StoreIkonerToolStripMenuItem1.CheckState = CheckState.Unchecked
            SmåIkonerToolStripMenuItem1.CheckState = CheckState.Indeterminate
            StoreIkonerMedDetaljerToolStripMenuItem1.CheckState = CheckState.Unchecked
            ListeToolStripMenuItem1.CheckState = CheckState.Unchecked
            DetaljerToolStripMenuItem1.CheckState = CheckState.Unchecked

            IconListView.LargeImageList = Nothing
            IconListView.SmallImageList = SmallImageList
            IconListView.StateImageList = Nothing

        ElseIf My.Settings.View = View.Tile Then

            StoreIkonerToolStripMenuItem.CheckState = CheckState.Unchecked
            SmåIkonerToolStripMenuItem.CheckState = CheckState.Unchecked
            StoreIkonerMedDetaljerToolStripMenuItem.CheckState = CheckState.Indeterminate
            ListeToolStripMenuItem.CheckState = CheckState.Unchecked
            DetaljerToolStripMenuItem.CheckState = CheckState.Unchecked

            StoreIkonerToolStripMenuItem1.CheckState = CheckState.Unchecked
            SmåIkonerToolStripMenuItem1.CheckState = CheckState.Unchecked
            StoreIkonerMedDetaljerToolStripMenuItem1.CheckState = CheckState.Indeterminate
            ListeToolStripMenuItem1.CheckState = CheckState.Unchecked
            DetaljerToolStripMenuItem1.CheckState = CheckState.Unchecked

            IconListView.LargeImageList = LargeImageList
            IconListView.SmallImageList = Nothing
            IconListView.StateImageList = Nothing

        ElseIf My.Settings.View = View.List Then

            StoreIkonerToolStripMenuItem.CheckState = CheckState.Unchecked
            SmåIkonerToolStripMenuItem.CheckState = CheckState.Unchecked
            StoreIkonerMedDetaljerToolStripMenuItem.CheckState = CheckState.Unchecked
            ListeToolStripMenuItem.CheckState = CheckState.Indeterminate
            DetaljerToolStripMenuItem.CheckState = CheckState.Unchecked

            StoreIkonerToolStripMenuItem1.CheckState = CheckState.Unchecked
            SmåIkonerToolStripMenuItem1.CheckState = CheckState.Unchecked
            StoreIkonerMedDetaljerToolStripMenuItem1.CheckState = CheckState.Unchecked
            ListeToolStripMenuItem1.CheckState = CheckState.Indeterminate
            DetaljerToolStripMenuItem1.CheckState = CheckState.Unchecked

            IconListView.LargeImageList = Nothing
            IconListView.SmallImageList = SmallImageList
            IconListView.StateImageList = Nothing

        ElseIf My.Settings.View = View.Details Then

            StoreIkonerToolStripMenuItem.CheckState = CheckState.Unchecked
            SmåIkonerToolStripMenuItem.CheckState = CheckState.Unchecked
            StoreIkonerMedDetaljerToolStripMenuItem.CheckState = CheckState.Unchecked
            ListeToolStripMenuItem.CheckState = CheckState.Unchecked
            DetaljerToolStripMenuItem.CheckState = CheckState.Indeterminate

            StoreIkonerToolStripMenuItem1.CheckState = CheckState.Unchecked
            SmåIkonerToolStripMenuItem1.CheckState = CheckState.Unchecked
            StoreIkonerMedDetaljerToolStripMenuItem1.CheckState = CheckState.Unchecked
            ListeToolStripMenuItem1.CheckState = CheckState.Unchecked
            DetaljerToolStripMenuItem1.CheckState = CheckState.Indeterminate

            IconListView.LargeImageList = Nothing
            IconListView.SmallImageList = SmallImageList
            IconListView.StateImageList = Nothing

        End If
    End Sub

    Private Sub LoadSearchedFilesNode()

        TreeViewImageList.Images.Add("Document", My.Resources.Document)

        Dim Node As New TreeNode

        Node.ImageKey = "Document"
        Node.SelectedImageKey = "Document"
        Node.StateImageKey = "Document"

        Node.Tag = "SearchedFilesNode"
        Node.Name = "SearchedFilesNode|SearchedFilesNode"
        Node.Text = SearchedFiles

        IconTreeView.Nodes.Add(Node)

    End Sub

    Private Sub LoadSearchedFoldersNode()

        TreeViewImageList.Images.Add("ClosedFolder", My.Resources.ClosedFolder)

        Dim Node As New TreeNode

        Node.ImageKey = "ClosedFolder"
        Node.SelectedImageKey = "ClosedFolder"
        Node.StateImageKey = "ClosedFolder"

        Node.Tag = "SearchedFoldersNode"
        Node.Name = "SearchedFoldersNode|SearchedFoldersNode"
        Node.Text = SearchedFolders

        IconTreeView.Nodes.Add(Node)

    End Sub

    Private Sub frmMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If DoRestart Then
            Shell(Application.ExecutablePath)
        End If

    End Sub

    Private Sub frmMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        My.Settings.Location = Me.Location
        My.Settings.WindowState = Me.WindowState : If My.Settings.WindowState = FormWindowState.Maximized Or My.Settings.WindowState = FormWindowState.Minimized Then My.Settings.Location = New Point(279, 109)

        SystemIcon.Visible = False
    End Sub

    Private Sub frmMain_ResizeEnd(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ResizeEnd
        My.Settings.Size = Me.Size
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckLang()

        If My.Settings.IconTreeView Then
            LoadSearchedFilesNode()
            LoadSearchedFoldersNode()
        End If

        StartGoExtractIconsNårWindowsStarterToolStripMenuItem.Checked = DoesItRunAtStartUp()
        StartGoExtractIconsNårWindowsStarterToolStripMenuItem1.Checked = DoesItRunAtStartUp()

        CheckView()

        Me.Size = My.Settings.Size
        Me.Location = My.Settings.Location
        Me.WindowState = My.Settings.WindowState

        MenuBar.Visible = My.Settings.MenuBar
        MenylinjeToolStripMenuItem.Checked = My.Settings.MenuBar
        MenylinjeToolStripMenuItem1.Checked = My.Settings.MenuBar
        VisMenylinjenToolStripMenuItem.Checked = My.Settings.MenuBar

        StatusBar.Visible = My.Settings.StatusBar
        StatuslinjeToolStripMenuItem.Checked = My.Settings.StatusBar
        StatuslinjeToolStripMenuItem1.Checked = My.Settings.StatusBar

        IconTreeViewPanel.Visible = My.Settings.IconTreeView
        IkonTreToolStripMenuItem.Checked = My.Settings.IconTreeView
        IkonTreToolStripMenuItem1.Checked = My.Settings.IconTreeView

        If My.Settings.SearchIcons Then

            Dim Dialog As New frmOpenIcons

            If Dialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                If Dialog.IsClosed Then
                    If My.Settings.ItemTextIsFolder Then
                        PerformSearch(My.Settings.ItemText, ItemModes.SearchFolder)
                    Else
                        PerformSearch(My.Settings.ItemText, ItemModes.SearchFiles)
                    End If
                End If
            End If

        End If

        'CheckLANGFileExtension()

    End Sub

    Private Sub CheckThings_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckThings.Tick

        EgenskaperToolStripMenuItem.Enabled = IconListView.SelectedItems.Count = 1
        FilEgenskaperToolStripMenuItem.Enabled = IconListView.SelectedItems.Count = 1

        LagreIkonerToolStripMenuItem.Enabled = IconListView.SelectedItems.Count <> 0
        KopierMerkertIkonToolStripMenuItem.Enabled = IconListView.SelectedItems.Count = 1

        MerkAlleIkonerToolStripMenuItem.Enabled = IconListView.SelectedItems.Count <> IconListView.Items.Count
        FjernMerkeringToolStripMenuItem.Enabled = IconListView.SelectedItems.Count <> 0

        If SearchBox.Text = SearchBoxWT And SearchBox.ForeColor = Color.Gray Then
            SearchAfterIcon.Enabled = False
        Else
            SearchAfterIcon.Enabled = SearchBox.Text <> Nothing And SearchBox.ForeColor = Color.Black
        End If

    End Sub

    Private Sub CheckButtons_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckButtons.Tick

        Backward.Enabled = IconListView.SelectedItems.Count = 1
        Forward.Enabled = IconListView.SelectedItems.Count = 1

        FileInfo.Enabled = IconListView.SelectedItems.Count = 1

        SaveIcons.Enabled = IconListView.SelectedItems.Count <> 0

        SearchIcons.BtnMode = IIf(IsLoading, GoBtn.GoBtnModes.UseSecondImages, GoBtn.GoBtnModes.UseStandardImages)

    End Sub

    Private Sub SøkEtterIkonerINettsideToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SøkEtterIkonerINettsideToolStripMenuItem.Click

        Dim Dialog As New frmSearchIconsInWebsite(My.Settings.SearchIconsURL)

        Dialog.ShowDialog()

    End Sub

    Private Sub SøkEtterIkonerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SøkEtterIkonerToolStripMenuItem.Click

        Dim Dialog As New frmOpenIcons

        If Dialog.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
            If Dialog.IsClosed Then
                If My.Settings.ItemTextIsFolder Then
                    PerformSearch(My.Settings.ItemText, ItemModes.SearchFolder)
                Else
                    PerformSearch(My.Settings.ItemText, ItemModes.SearchFiles)
                End If
            End If
        End If

    End Sub

    Private Sub LagreIkonerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LagreIkonerToolStripMenuItem.Click

        Dim IList As New List(Of Icon)

        For i As Integer = 0 To IconListView.SelectedIndices.Count - 1
            IList.Add(IconList(IconListView.SelectedItems(i).Index))
        Next

        Dim NList As New List(Of String)
        Dim INList As New List(Of String)
        Dim IMCList As New List(Of String)

        For Each i As ListViewItem In IconListView.SelectedItems
            NList.Add(i.Text)
            INList.Add(i.SubItems(7).Text & "-" & i.SubItems(1).Text)
            IMCList.Add(i.SubItems(7).Text)
        Next

        Dim Dialog As New frmSaveIcons(IList, NList, INList, IMCList)

        Dialog.ShowDialog()

    End Sub

    Private Sub FilEgenskaperToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilEgenskaperToolStripMenuItem.Click

        ShowFileProperties(IconListView.SelectedItems(0).SubItems(7).Text)

    End Sub

    Private Sub EgenskaperToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EgenskaperToolStripMenuItem.Click

        Dim Dialog As New frmViewIcons(IconListView.SelectedItems(0).SubItems(1).Text, IconListView.SelectedItems(0).SubItems(7).Text, IconHelper.SplitGroupIcon(IconList(IconListView.SelectedItems(0).Index)))

        Dialog.ShowDialog()

    End Sub

    Private Sub AvsluttToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvsluttToolStripMenuItem1.Click

        SystemIcon.Visible = False

        Me.Close()

    End Sub

    Private Sub KopierMerkertIkonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KopierMerkertIkonToolStripMenuItem.Click

        Clipboard.SetImage(IconList(IconListView.SelectedItems(0).Index).ToBitmap)

    End Sub

    Private Sub MerkAlleIkonerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MerkAlleIkonerToolStripMenuItem1.Click

        For Each i As ListViewItem In IconListView.Items
            i.Selected = True
        Next

    End Sub

    Private Sub FjernMerkeringToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FjernMerkeringToolStripMenuItem.Click

        For Each i As ListViewItem In IconListView.SelectedItems
            i.Selected = False
        Next

    End Sub

    Private Sub SøkEtterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SøkEtterToolStripMenuItem.Click

        SearchBox.Focus()

    End Sub

    Private Sub StoreIkonerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StoreIkonerToolStripMenuItem.Click

        My.Settings.View = View.LargeIcon

        CheckView()

    End Sub

    Private Sub SmåIkonerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmåIkonerToolStripMenuItem.Click

        My.Settings.View = View.SmallIcon

        CheckView()

    End Sub

    Private Sub StoreIkonerMedDetaljerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StoreIkonerMedDetaljerToolStripMenuItem.Click

        My.Settings.View = View.Tile

        CheckView()

    End Sub

    Private Sub ListeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListeToolStripMenuItem.Click

        My.Settings.View = View.List

        CheckView()

    End Sub

    Private Sub DetaljerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetaljerToolStripMenuItem.Click

        My.Settings.View = View.Details

        CheckView()

    End Sub

    Private Sub IkonTreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IkonTreToolStripMenuItem.Click

        My.Settings.IconTreeView = IkonTreToolStripMenuItem.Checked

        IkonTreToolStripMenuItem1.Checked = My.Settings.IconTreeView

        IconTreeViewPanel.Visible = My.Settings.IconTreeView

        If My.Settings.IconTreeView Then

            IconTreeView.Nodes.Clear()

            LoadSearchedFilesNode()

            If Not SelectedFileName = Nothing Then

                If Not TreeViewImageList.Images.ContainsKey(IO.Path.GetExtension(SelectedFileName)) Then _
                TreeViewImageList.Images.Add(IO.Path.GetExtension(SelectedFileName), Shell32.GetIcon(SelectedFileName))

                Dim FileNode As New TreeNode

                FileNode.ImageKey = IO.Path.GetExtension(SelectedFileName)
                FileNode.SelectedImageKey = IO.Path.GetExtension(SelectedFileName)
                FileNode.StateImageKey = IO.Path.GetExtension(SelectedFileName)

                FileNode.Tag = "FileNode|" & SelectedFileName
                FileNode.Name = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name
                FileNode.Text = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name

                IconTreeView.Nodes("SearchedFilesNode|SearchedFilesNode").Nodes.Add(FileNode)

                FileNode.ExpandAll()
                IconTreeView.Focus()

                IconTreeView.SelectedNode = FileNode

                IconList = IconHelper.ExtractAllIcons(SelectedFileName)

                For i As Integer = 0 To IconList.Count - 1

                    StatusLabel.Text = ExtractingIconsFromFile & " (" & i + 1 & " " & _of & " " & IconList.Count & ")"

                    ProgressBar.Maximum = IconList.Count
                    ProgressBar.Value = i + 1

                    Dim ItemNode As New TreeNode

                    ItemNode.ImageKey = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name & " (" & i + 1 & ")"
                    ItemNode.SelectedImageKey = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name & " (" & i + 1 & ")"
                    ItemNode.StateImageKey = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name & " (" & i + 1 & ")"

                    ItemNode.Tag = "ItemNode|" & SelectedFileName
                    ItemNode.Name = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name & " (" & i + 1 & ")"
                    ItemNode.Text = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name & " (" & i + 1 & ")"

                    FileNode.Nodes.Add(ItemNode)

                    If i = 0 Then
                        IconTreeView.SelectedNode = ItemNode
                    End If

                Next

            End If

        Else

            IconTreeView.Nodes.Clear()

        End If

    End Sub

    Private Sub MenylinjeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenylinjeToolStripMenuItem.Click

        My.Settings.MenuBar = MenylinjeToolStripMenuItem.Checked

        MenylinjeToolStripMenuItem1.Checked = My.Settings.MenuBar
        VisMenylinjenToolStripMenuItem.Checked = My.Settings.MenuBar

        MenuBar.Visible = My.Settings.MenuBar

    End Sub

    Private Sub StatuslinjeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatuslinjeToolStripMenuItem.Click

        My.Settings.StatusBar = StatuslinjeToolStripMenuItem.Checked

        StatuslinjeToolStripMenuItem1.Checked = My.Settings.StatusBar

        StatusBar.Visible = My.Settings.StatusBar

    End Sub

    Private Sub ÅpneIkonFletterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÅpneIkonFletterToolStripMenuItem.Click

        Dim Dialog As New frmIconMerge

        Dialog.ShowDialog()

    End Sub

    Private Sub AlternativerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlternativerToolStripMenuItem.Click

        Dim Dialog As New frmOptions

        Dialog.ShowDialog()

    End Sub

    Private Sub StartGoExtractIconsNårWindowsStarterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartGoExtractIconsNårWindowsStarterToolStripMenuItem.Click

        RunAtStartUp(StartGoExtractIconsNårWindowsStarterToolStripMenuItem.Checked)

        StartGoExtractIconsNårWindowsStarterToolStripMenuItem1.Checked = StartGoExtractIconsNårWindowsStarterToolStripMenuItem.Checked

    End Sub

    Private Sub SeEtterOppdateringerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeEtterOppdateringerToolStripMenuItem.Click

        Dim Dialog As New frmCheckForUpdates

        Dialog.ShowDialog()

    End Sub

    Private Sub RestartGoExtractIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartGoExtractIconsToolStripMenuItem.Click

        If My.Settings.ShowRestartMessageBox Then

            Dim Dialog As New MessageBox(AreYouSureYouWannaRestartGoExtractIcons, MessageBox.MessageButtons.YesNoCancel, MessageBox.MessageIcons.Question, , , True)

            If Dialog.ShowDialog = MessageBox.MessageDialogResults.Yes Then

                My.Settings.ShowRestartMessageBox = Not Dialog.IsDoNotShowAgainCheckBoxChecked

                DoRestart = True

                Application.Exit()

            Else
                My.Settings.ShowRestartMessageBox = Not Dialog.IsDoNotShowAgainCheckBoxChecked
            End If

        Else

            DoRestart = True

            Application.Exit()

        End If

    End Sub

    Private Sub OmGoExtractIconsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OmGoExtractIconsToolStripMenuItem1.Click

        Dim Dialog As New frmAbout

        Dialog.ShowDialog()

    End Sub

    Private Sub Backward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Backward.Click
        Try
            Dim i As Integer = 0
            Dim s As Integer = IconListView.SelectedIndices(0) - 1
            Do Until i = IconListView.Items.Count
                IconListView.Items(i).Selected = False
                i += 1
            Loop
            IconListView.Items(s).Selected = True
        Catch ex As ArgumentOutOfRangeException

        End Try
    End Sub

    Private Sub Forward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Forward.Click
        Try
            Dim i As Integer = 0
            Dim s As Integer = IconListView.SelectedIndices(0) + 1
            Do Until i = IconListView.Items.Count
                IconListView.Items(i).Selected = False
                i += 1
            Loop
            IconListView.Items(s).Selected = True
        Catch ex As ArgumentOutOfRangeException

        End Try
    End Sub

    Private Sub FileInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileInfo.Click
        EgenskaperToolStripMenuItem.PerformClick()
    End Sub

    Private Sub SearchIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchIcons.Click
        If SearchIcons.BtnMode = GoBtn.GoBtnModes.UseStandardImages Then
            SøkEtterIkonerToolStripMenuItem.PerformClick()
        Else
            stopSearching = True
        End If
    End Sub

    Private Sub SaveIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveIcons.Click
        LagreIkonerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub SearchBox_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBox.Leave
        If SearchBox.Text = Nothing And SearchBox.ForeColor = Color.Black Then
            SearchBox.Text = SearchBoxWT
            SearchBox.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub SearchBox_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles SearchBox.MouseDown
        If SearchBox.Text = SearchBoxWT And SearchBox.ForeColor = Color.Gray Then
            SearchBox.Text = Nothing
            SearchBox.ForeColor = Color.Black
        End If
    End Sub

    Private Sub SearchBox_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBox.Enter
        If SearchBox.Text = SearchBoxWT And SearchBox.ForeColor = Color.Gray Then
            SearchBox.Text = Nothing
            SearchBox.ForeColor = Color.Black
        End If
    End Sub

    Private Sub SearchBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SearchBox.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            SearchAfterIcon.PerformClick()
        End If
    End Sub

    Private Sub SearchBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBox.TextChanged
        SearchAfterIcon.ToolTipText = "(""" & MakeTextDotts(SearchBox.Text, 100) & """)"
    End Sub

    Private Sub SearchAfterIcon_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchAfterIcon.MouseHover
        SearchAfterIcon.ToolTipText = "(""" & MakeTextDotts(SearchBox.Text, 100) & """)"
    End Sub

    Private Sub SearchAfterIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchAfterIcon.Click
        Search()
    End Sub

    Private Sub SearchBoxContextMenuBar_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SearchBoxContextMenuBar.Opening
        Dim CanPaste As Boolean
        Dim CanPasteBox As New RichTextBox

        Dim CPText As DataFormats.Format = DataFormats.GetFormat(DataFormats.Text)
        Dim CPUnicodeText As DataFormats.Format = DataFormats.GetFormat(DataFormats.UnicodeText)

        If CanPasteBox.CanPaste(CPText) Then
            CanPaste = True
        ElseIf CanPasteBox.CanPaste(CPUnicodeText) Then
            CanPaste = True
        Else
            CanPaste = False
        End If

        AngreToolStripMenuItem.Enabled = SearchBox.CanUndo
        SlettAngreToolStripMenuItem.Enabled = SearchBox.CanUndo

        KopierToolStripMenuItem.Enabled = SearchBox.SelectedText <> Nothing

        LimInnToolStripMenuItem.Enabled = CanPaste
        LimInnOgSøkEtterToolStripMenuItem.Enabled = CanPaste

        KlippUtToolStripMenuItem.Enabled = SearchBox.SelectedText <> Nothing

        MerkAltToolStripMenuItem.Enabled = SearchBox.SelectedText <> SearchBox.Text
        FjernMerkeringToolStripMenuItem1.Enabled = SearchBox.SelectedText <> Nothing

        SlettToolStripMenuItem.Enabled = SearchBox.SelectedText <> Nothing
        SlettAltToolStripMenuItem.Enabled = SearchBox.SelectedText <> SearchBox.Text
    End Sub

    Private Sub AngreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AngreToolStripMenuItem.Click
        SearchBox.Undo()
    End Sub

    Private Sub SlettAngreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlettAngreToolStripMenuItem.Click
        SearchBox.ClearUndo()
    End Sub

    Private Sub KopierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KopierToolStripMenuItem.Click
        SearchBox.Copy()
    End Sub

    Private Sub LimInnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LimInnToolStripMenuItem.Click
        SearchBox.Paste()
    End Sub

    Private Sub LimInnOgSøkEtterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LimInnOgSøkEtterToolStripMenuItem.Click
        SearchBox.Clear()
        SearchBox.Paste()
        SearchAfterIcon.PerformClick()
    End Sub

    Private Sub KlippUtToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlippUtToolStripMenuItem.Click
        SearchBox.Cut()
    End Sub

    Private Sub MerkAltToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MerkAltToolStripMenuItem.Click
        SearchBox.SelectAll()
    End Sub

    Private Sub FjernMerkeringToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FjernMerkeringToolStripMenuItem1.Click
        SearchBox.DeselectAll()
    End Sub

    Private Sub SlettToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlettToolStripMenuItem.Click
        SearchBox.SelectedText = ""
    End Sub

    Private Sub SlettAltToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SlettAltToolStripMenuItem.Click
        SearchBox.Clear()
    End Sub

    Private Sub FileBtnContextMenuBar_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles FileBtnContextMenuBar.Opening

        EgenskaperToolStripMenuItem1.Enabled = IconListView.SelectedItems.Count = 1
        FilEgenskaperToolStripMenuItem1.Enabled = IconListView.SelectedItems.Count = 1

        ÅpneEgenskaperForIkonToolStripMenuItem1.Enabled = IconListView.SelectedItems.Count = 1
        ÅpneEgenskaperForFilToolStripMenuItem1.Enabled = IconListView.SelectedItems.Count = 1

        LagreIkonerToolStripMenuItem2.Enabled = IconListView.SelectedItems.Count <> 0
        KopierMerkertIkonToolStripMenuItem2.Enabled = IconListView.SelectedItems.Count = 1

        MerkAlleIkonerToolStripMenuItem2.Enabled = IconListView.SelectedItems.Count <> IconListView.Items.Count
        FjernMerkeringToolStripMenuItem3.Enabled = IconListView.SelectedItems.Count <> 0

    End Sub

    Private Sub SøkEtterIkonerToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SøkEtterIkonerToolStripMenuItem5.Click
        SøkEtterIkonerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub LagreIkonerToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LagreIkonerToolStripMenuItem2.Click
        LagreIkonerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub FilEgenskaperToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FilEgenskaperToolStripMenuItem1.Click
        FilEgenskaperToolStripMenuItem.PerformClick()
    End Sub

    Private Sub EgenskaperToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EgenskaperToolStripMenuItem1.Click
        EgenskaperToolStripMenuItem.PerformClick()
    End Sub

    Private Sub AvsluttToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvsluttToolStripMenuItem3.Click
        AvsluttToolStripMenuItem1.PerformClick()
    End Sub

    Private Sub KopierMerkertIkonToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KopierMerkertIkonToolStripMenuItem3.Click
        KopierMerkertIkonToolStripMenuItem.PerformClick()
    End Sub

    Private Sub MerkAlleIkonerToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MerkAlleIkonerToolStripMenuItem2.Click
        MerkAlleIkonerToolStripMenuItem1.PerformClick()
    End Sub

    Private Sub FjernMerkeringToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FjernMerkeringToolStripMenuItem3.Click
        FjernMerkeringToolStripMenuItem.PerformClick()
    End Sub

    Private Sub SøkEtterToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SøkEtterToolStripMenuItem3.Click
        SøkEtterIkonerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub StoreIkonerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StoreIkonerToolStripMenuItem1.Click
        StoreIkonerMedDetaljerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub SmåIkonerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmåIkonerToolStripMenuItem1.Click
        SmåIkonerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub StoreIkonerMedDetaljerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StoreIkonerMedDetaljerToolStripMenuItem1.Click
        StoreIkonerMedDetaljerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ListeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListeToolStripMenuItem1.Click
        ListeToolStripMenuItem.PerformClick()
    End Sub

    Private Sub DetaljerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetaljerToolStripMenuItem1.Click
        DetaljerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub IkonTreToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IkonTreToolStripMenuItem1.Click

        My.Settings.IconTreeView = IkonTreToolStripMenuItem1.Checked

        IkonTreToolStripMenuItem.Checked = My.Settings.IconTreeView

        IconTreeViewPanel.Visible = My.Settings.IconTreeView

        If My.Settings.IconTreeView Then

            IconTreeView.Nodes.Clear()

            LoadSearchedFilesNode()

            If Not SelectedFileName = Nothing Then

                If Not TreeViewImageList.Images.ContainsKey(IO.Path.GetExtension(SelectedFileName)) Then _
                TreeViewImageList.Images.Add(IO.Path.GetExtension(SelectedFileName), Shell32.GetIcon(SelectedFileName))

                Dim FileNode As New TreeNode

                FileNode.ImageKey = IO.Path.GetExtension(SelectedFileName)
                FileNode.SelectedImageKey = IO.Path.GetExtension(SelectedFileName)
                FileNode.StateImageKey = IO.Path.GetExtension(SelectedFileName)

                FileNode.Tag = "FileNode|" & SelectedFileName
                FileNode.Name = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name
                FileNode.Text = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name

                IconTreeView.Nodes("SearchedFilesNode|SearchedFilesNode").Nodes.Add(FileNode)

                FileNode.ExpandAll()
                IconTreeView.Focus()

                IconTreeView.SelectedNode = FileNode

                IconList = IconHelper.ExtractAllIcons(SelectedFileName)

                For i As Integer = 0 To IconList.Count - 1

                    Dim ItemNode As New TreeNode

                    ItemNode.ImageKey = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name & " (" & i + 1 & ")"
                    ItemNode.SelectedImageKey = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name & " (" & i + 1 & ")"
                    ItemNode.StateImageKey = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name & " (" & i + 1 & ")"

                    ItemNode.Tag = "ItemNode|" & SelectedFileName
                    ItemNode.Name = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name & " (" & i + 1 & ")"
                    ItemNode.Text = My.Computer.FileSystem.GetFileInfo(SelectedFileName).Name & " (" & i + 1 & ")"

                    FileNode.Nodes.Add(ItemNode)

                    If i = 0 Then
                        IconTreeView.SelectedNode = ItemNode
                    End If

                Next

            End If

        Else

            IconTreeView.Nodes.Clear()

        End If

    End Sub

    Private Sub MenylinjeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenylinjeToolStripMenuItem1.Click

        My.Settings.MenuBar = MenylinjeToolStripMenuItem1.Checked

        MenylinjeToolStripMenuItem.Checked = My.Settings.MenuBar
        VisMenylinjenToolStripMenuItem.Checked = My.Settings.MenuBar

        MenuBar.Visible = My.Settings.MenuBar

    End Sub

    Private Sub StatuslinjeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StatuslinjeToolStripMenuItem1.Click

        My.Settings.StatusBar = StatuslinjeToolStripMenuItem1.Checked

        StatuslinjeToolStripMenuItem.Checked = My.Settings.StatusBar

        StatusBar.Visible = My.Settings.StatusBar

    End Sub

    Private Sub ÅpneIkonFletterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÅpneIkonFletterToolStripMenuItem2.Click
        ÅpneIkonFletterToolStripMenuItem.PerformClick()
    End Sub

    Private Sub AlternativerToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlternativerToolStripMenuItem2.Click
        AlternativerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub StartGoExtractIconsNårWindowsStarterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartGoExtractIconsNårWindowsStarterToolStripMenuItem1.Click

        RunAtStartUp(StartGoExtractIconsNårWindowsStarterToolStripMenuItem1.Checked)

        StartGoExtractIconsNårWindowsStarterToolStripMenuItem.Checked = StartGoExtractIconsNårWindowsStarterToolStripMenuItem1.Checked

    End Sub

    Private Sub SeEtterOppdateringerToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeEtterOppdateringerToolStripMenuItem2.Click
        SeEtterOppdateringerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub RestartGoExtractIconsToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartGoExtractIconsToolStripMenuItem2.Click
        RestartGoExtractIconsToolStripMenuItem.PerformClick()
    End Sub

    Private Sub OmGoExtractIconsToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OmGoExtractIconsToolStripMenuItem2.Click
        OmGoExtractIconsToolStripMenuItem1.PerformClick()
    End Sub

    Private Sub SøkEtterIkonerToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SøkEtterIkonerToolStripMenuItem4.Click
        SøkEtterIkonerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub AlternativerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AlternativerToolStripMenuItem1.Click
        AlternativerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ÅpneIkonfletterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÅpneIkonfletterToolStripMenuItem1.Click
        ÅpneIkonFletterToolStripMenuItem.PerformClick()
    End Sub

    Private Sub VisMenylinjenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VisMenylinjenToolStripMenuItem.Click

        My.Settings.MenuBar = VisMenylinjenToolStripMenuItem.Checked

        MenylinjeToolStripMenuItem.Checked = My.Settings.MenuBar
        MenylinjeToolStripMenuItem1.Checked = My.Settings.MenuBar

        MenuBar.Visible = My.Settings.MenuBar

    End Sub

    Private Sub AvsluttToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvsluttToolStripMenuItem2.Click
        AvsluttToolStripMenuItem1.PerformClick()
    End Sub

    Private Sub IconTreeViewContextMenuBar_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles IconTreeViewContextMenuBar.Opening

        ÅpneEgenskaperForIkonToolStripMenuItem1.Enabled = Split(IconTreeView.SelectedNode.Name, "|")(0) = "ItemNode"
        ÅpneEgenskaperForFilToolStripMenuItem1.Enabled = Split(IconTreeView.SelectedNode.Name, "|")(0) = "ItemNode"

        LagreIkonTilToolStripMenuItem.Enabled = Not IsNothing(IconTreeView.SelectedNode) And Split(IconTreeView.SelectedNode.Name, "|")(0) = "ItemNode"
        KopierMerkertIkonToolStripMenuItem2.Enabled = Not IsNothing(IconTreeView.SelectedNode) And Split(IconTreeView.SelectedNode.Name, "|")(0) = "ItemNode"

    End Sub

    Private Sub ÅpneEgenskaperForIkonToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÅpneEgenskaperForIkonToolStripMenuItem1.Click

        Dim IL As New List(Of Icon)

        IL.Add(IconTreeView.SelectedNode.Tag)

        Dim Dialog As New frmViewIcons(IconList.IndexOf(IconTreeView.SelectedNode.Tag), Split(IconTreeView.SelectedNode.Name, "|")(1), IL)

        Dialog.ShowDialog()

    End Sub

    Private Sub ÅpneEgenskaperForFilToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÅpneEgenskaperForFilToolStripMenuItem1.Click
        FilEgenskaperToolStripMenuItem.PerformClick()
    End Sub

    Private Sub SøkEtterIkonerToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SøkEtterIkonerToolStripMenuItem3.Click
        SøkEtterIkonerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub LagreIkonTilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LagreIkonTilToolStripMenuItem.Click

        Dim IList As New List(Of Icon)
        IList.Add(IconTreeView.SelectedNode.Tag)

        Dim NList As New List(Of String)
        NList.Add(IconTreeView.SelectedNode.Text)

        Dim INList As New List(Of String)
        INList.Add(Split(IconTreeView.SelectedNode.Name, "|")(1) & "-" & IconTreeView.SelectedNode.Parent.Nodes.IndexOf(IconTreeView.SelectedNode) + 1)

        Dim IMCList As New List(Of String)
        IMCList.Add(Split(IconTreeView.SelectedNode.Name, "|")(1))

        Dim Dialog As New frmSaveIcons(IList, NList, INList, IMCList)

        Dialog.ShowDialog()

    End Sub

    Private Sub KopierMerkertIkonToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KopierMerkertIkonToolStripMenuItem2.Click

        Clipboard.SetImage(DirectCast(IconTreeView.SelectedNode.Tag, Icon).ToBitmap)

    End Sub

    Private Sub SøkEtterToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SøkEtterToolStripMenuItem2.Click
        SearchBox.Focus()
    End Sub

    Private Sub IconListViewContextMenuBar_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles IconListViewContextMenuBar.Opening

        ÅpneEgenskaperForIkonToolStripMenuItem.Enabled = IconListView.SelectedItems.Count = 1
        ÅpneEgenskaperForFilToolStripMenuItem.Enabled = IconListView.SelectedItems.Count = 1

        LagreIkonerToolStripMenuItem1.Enabled = IconListView.SelectedItems.Count <> 0
        KopierMerkertIkonToolStripMenuItem1.Enabled = IconListView.SelectedItems.Count = 1

        MerkAlleIkonerToolStripMenuItem1.Enabled = IconListView.SelectedItems.Count <> IconListView.Items.Count
        FjernMerkeringToolStripMenuItem2.Enabled = IconListView.SelectedItems.Count <> 0

    End Sub

    Private Sub ÅpneEgenskaperForIkonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÅpneEgenskaperForIkonToolStripMenuItem.Click
        EgenskaperToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ÅpneEgenskaperForFilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÅpneEgenskaperForFilToolStripMenuItem.Click
        FilEgenskaperToolStripMenuItem.PerformClick()
    End Sub

    Private Sub SøkEtterIkonerToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SøkEtterIkonerToolStripMenuItem2.Click
        SøkEtterIkonerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub LagreIkonerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LagreIkonerToolStripMenuItem1.Click
        LagreIkonerToolStripMenuItem.PerformClick()
    End Sub

    Private Sub KopierMerkertIkonToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KopierMerkertIkonToolStripMenuItem1.Click
        KopierMerkertIkonToolStripMenuItem.PerformClick()
    End Sub

    Private Sub MerkAlleIkonerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MerkAlleIkonerToolStripMenuItem.Click
        MerkAlleIkonerToolStripMenuItem1.PerformClick()
    End Sub

    Private Sub FjernMerkeringToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FjernMerkeringToolStripMenuItem2.Click
        FjernMerkeringToolStripMenuItem.PerformClick()
    End Sub

    Private Sub SøkEtterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SøkEtterToolStripMenuItem1.Click
        SøkEtterToolStripMenuItem.PerformClick()
    End Sub

    Private Sub MinimerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MinimerToolStripMenuItem.Click
        MinimerToolStripMenuItem.Enabled = False
        MaksimerToolStripMenuItem.Enabled = True
        Me.Hide()
        SystemIcon.ShowBalloonTip(5000, "Go! ExtractIcons", GoExtractIconsIsMinimizedToTheSystemFieldToMaximizeTheApplicationAgainClickTheBubble, ToolTipIcon.Info)
    End Sub

    Private Sub MaksimerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaksimerToolStripMenuItem.Click
        MinimerToolStripMenuItem.Enabled = True
        MaksimerToolStripMenuItem.Enabled = False
        Me.Show()
    End Sub

    Private Sub SeEtterOppdateringerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SeEtterOppdateringerToolStripMenuItem1.Click

        Dim Dialog As New frmCheckForUpdates

        Dialog.ShowDialog()

    End Sub

    Private Sub RestartGoExtractIconsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestartGoExtractIconsToolStripMenuItem1.Click
        RestartGoExtractIconsToolStripMenuItem.PerformClick()
    End Sub

    Private Sub SøkEtterIkonerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SøkEtterIkonerToolStripMenuItem1.Click
        SearchIcons.PerformClick()
    End Sub

    Private Sub OmGoExtractIconsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OmGoExtractIconsToolStripMenuItem.Click

        Dim Dialog As New frmAbout

        Dialog.ShowDialog()

    End Sub

    Private Sub AvsluttToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvsluttToolStripMenuItem.Click
        SystemIcon.Visible = False
        Me.Close()
    End Sub

    Private Sub SystemIcon_BalloonTipClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SystemIcon.BalloonTipClicked
        MinimerToolStripMenuItem.Enabled = True
        MaksimerToolStripMenuItem.Enabled = False
        Me.Show()
    End Sub

    Private Sub IconListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IconListView.SelectedIndexChanged

        Try

            If IconList.Count > 0 Then

                If IconListView.SelectedItems.Count = 1 Then

                    LoadItemInfo(IconListView.SelectedItems(0))

                ElseIf IconListView.SelectedItems.Count = 0 Then

                    StatusLabel.Text = IIf(IconListView.Items.Count <> 0, IIf(IconListView.Items.Count > 1, IconListView.Items.Count & " ikoner funnet!", "1 ikon funnet!"), "Ingen ikoner funnet!")

                ElseIf IconListView.SelectedItems.Count > 1 Then

                    StatusLabel.Text = MoreThanOneIconIsSelected

                End If

            Else

                StatusLabel.Text = NoIconsInTheList

            End If

        Catch ex As Exception

            StatusLabel.Text = IIf(IconListView.Items.Count <> 0, IIf(IconListView.Items.Count > 1, IIf(IconListView.Items.Count <> 0, IIf(IconListView.Items.Count > 1, IconListView.Items.Count & " " & IconsFound, "1 " & IconFound), NoIconsFound), "1 " & IconFound), NoIconsFound)

        End Try

    End Sub

    Private Sub IconListView_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles IconListView.MouseDoubleClick
        If IconListView.SelectedItems().Count = 1 Then
            EgenskaperToolStripMenuItem.PerformClick()
        End If
    End Sub

    Private Sub IconListView_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles IconListView.DragEnter
        e.Effect = e.AllowedEffect
    End Sub

    Private Sub IconListView_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles IconListView.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            For Each File As String In e.Data.GetData(DataFormats.FileDrop)
                If File.EndsWith(".exe") Or File.EndsWith(".dll") Or File.EndsWith(".ico") Or File.EndsWith(".ocx") Or File.EndsWith(".cpl") Or File.EndsWith(".scr") Then
                    AddIconToListView(File)
                End If
            Next
        End If
    End Sub

    Private Sub IconTreeView_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles IconTreeView.NodeMouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If Split(e.Node.Name, "|")(0) = "ItemNode" Then

                Dim IL As New List(Of Icon)

                IL = IconHelper.SplitGroupIcon(e.Node.Tag)

                Dim Dialog As New frmViewIcons(IconList.IndexOf(e.Node.Tag), Split(e.Node.Name, "|")(1), IL)

                Dialog.ShowDialog()

            End If
        End If
    End Sub

    Private Sub IconTreeView_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles IconTreeView.AfterSelect
        Try
            If Split(e.Node.Name, "|")(0) = "FileNode" And Not Split(e.Node.Name, "|")(1) = SelectedFileName Or Split(e.Node.Name, "|")(0) = "ItemNode" And Not Split(e.Node.Name, "|")(1) = SelectedFileName Or Split(e.Node.Name, "|")(0) = "Folder" And Not Split(e.Node.Name, "|")(1) = SelectedFileName Then
                SelectedFileName = Split(e.Node.Name, "|")(1)
                If Not IsLoading Then
                    ReloadItemsFromItemNode(e.Node, SelectedFileName)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub IconTreeView_BeforeSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles IconTreeView.BeforeSelect
        If IsLoading And Not performSearching Then
            ' NOTES:
            ' e.Node = The node to select...
            ' loadingNode = The node which is loading right now...
            If Split(e.Node.Name, "|")(0) = "FileNode" Then
                If Split(loadingNode.Name, "|")(0) = "FileNode" Then
                    If Split(loadingNode.Name, "|")(1) = Split(e.Node.Name, "|")(1) Then
                        'OK...
                        e.Cancel = False
                    Else
                        'Not ok...
                        e.Cancel = True
                    End If
                ElseIf Split(loadingNode.Name, "|")(0) = "ItemNode" Then
                    If Split(loadingNode.Parent.Name, "|")(1) = Split(e.Node.Name, "|")(1) Then
                        'OK...
                        e.Cancel = False
                    Else
                        'Not ok...
                        e.Cancel = True
                    End If
                End If
            ElseIf Split(e.Node.Name, "|")(0) = "ItemNode" Then
                If Split(loadingNode.Name, "|")(0) = "FileNode" Then
                    If Split(loadingNode.Name, "|")(1) = Split(e.Node.Parent.Name, "|")(1) Then
                        'OK...
                        e.Cancel = False
                    Else
                        'Not ok...
                        e.Cancel = True
                    End If
                ElseIf Split(loadingNode.Name, "|")(0) = "ItemNode" Then
                    If Split(loadingNode.Parent.Name, "|")(1) = Split(e.Node.Parent.Name, "|")(1) Then
                        'OK...
                        e.Cancel = False
                    Else
                        'Not ok...
                        e.Cancel = True
                    End If
                End If
            ElseIf Split(e.Node.Name, "|")(0) = "Folder" Then
                If Split(loadingNode.Name, "|")(0) = "Folder" Then
                    If Split(loadingNode.Name, "|")(1) = Split(e.Node.Parent.Name, "|")(1) Then
                        'OK...
                        e.Cancel = False
                    Else
                        'Not ok...
                        e.Cancel = True
                    End If
                ElseIf Split(loadingNode.Name, "|")(0) = "ItemNode" Then
                    If Split(loadingNode.Parent.Parent.Name, "|")(1) = Split(e.Node.Name, "|")(1) Then
                        'OK...
                        e.Cancel = False
                    Else
                        'Not ok...
                        e.Cancel = True
                    End If
                ElseIf Split(loadingNode.Name, "|")(0) = "FileNode" Then
                    If Split(loadingNode.Parent.Name, "|")(1) = Split(e.Node.Name, "|")(1) Then
                        'OK...
                        e.Cancel = False
                    Else
                        'Not ok...
                        e.Cancel = True
                    End If
                End If
            End If
        End If
    End Sub
End Class