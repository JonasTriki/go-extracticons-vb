Imports System.IO

Public Class frmIconMerge

    Dim SelectedIcon As Icon

    Dim FileName As String

    Dim SavedIcon As Boolean = False
    Dim OpenedOrNewIconChanged As Boolean = False
    Dim OpenedIcon As Boolean = False
    Dim NewIcon As Boolean = False
    Dim HasLoadedImage As Boolean = False
    Dim HasLoadedIconLibary As Boolean = False

    Dim bpp As String
    Dim NoIcon As String
    Dim EmptyIcon As String
    Dim Icons As String
    Dim IconMerge As String
    Dim ISize As String
    Dim ColorDepth As String
    Dim Colors As String
    Dim IconSize As String
    Dim SaveI As String
    Dim SaveIconAs As String
    Dim OpenIcon As String
    Dim AddNewIcon As String
    Dim NewI As String
    Dim TheIconIsTooBigToBeViewed As String
    Dim AreYouSureYouWannaRemoveTheSelectedIconFromTheList As String
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

    Dim IconList As New List(Of Icon)

    Private ReadOnly Property GetSelectedIndex() As Integer
        Get
            Dim rt As Integer = 0

            For Each IconItem As IconItem In LeftPanel.Controls
                If IconItem.Selected Then rt = LeftPanel.Controls.IndexOf(IconItem)
            Next

            Return rt
        End Get

    End Property

    Public Sub DrawTextToGraphics(ByVal g As Graphics, ByVal textToDraw As String, ByVal sizeToControl As Size, ByVal f As Font, ByVal foreColor As Color)

        Dim sb As New SolidBrush(foreColor)
        Dim sf As New StringFormat(StringFormatFlags.LineLimit)
        sf.Trimming = StringTrimming.EllipsisWord
        Dim ms As SizeF = g.MeasureString(textToDraw, f, sizeToControl, sf)
        Dim bounds As New RectangleF(New PointF((sizeToControl.Width - ms.Width) / 2, (sizeToControl.Height - ms.Height) / 2), New SizeF(sizeToControl.Width, sizeToControl.Height))

        g.DrawString(textToDraw, f, sb, bounds, sf)

    End Sub

    Public Sub CheckLang()

        INILangFile = New IniFile(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages").Item(My.Settings.Language))

        LoadLang()

    End Sub

    Public Sub LoadLang()

        'SomeCommands = INILangFile.GetString("SomeCommands", "")

        bpp = INILangFile.GetString("SomeCommands", "bpp")
        NoIcon = INILangFile.GetString("SomeCommands", "NoIcon")
        EmptyIcon = INILangFile.GetString("SomeCommands", "EmptyIcon")
        Icons = INILangFile.GetString("SomeCommands", "Icons")
        IconMerge = INILangFile.GetString("SomeCommands", "IconMerge")
        ISize = INILangFile.GetString("SomeCommands", "ISize")
        ColorDepth = INILangFile.GetString("SomeCommands", "ColorDepth")
        Colors = INILangFile.GetString("SomeCommands", "Colors")
        IconSize = INILangFile.GetString("SomeCommands", "IconSize")
        SaveI = INILangFile.GetString("SomeCommands", "SaveI")
        SaveIconAs = INILangFile.GetString("SomeCommands", "SaveIconAs")
        OpenIcon = INILangFile.GetString("SomeCommands", "OpenIcon")
        AddNewIcon = INILangFile.GetString("SomeCommands", "AddNewIcon")
        NewI = INILangFile.GetString("SomeCommands", "NewI")
        TheIconIsTooBigToBeViewed = INILangFile.GetString("SomeCommands", "TheIconIsTooBigToBeViewed")
        AreYouSureYouWannaRemoveTheSelectedIconFromTheList = INILangFile.GetString("SomeCommands", "AreYouSureYouWannaRemoveTheSelectedIconFromTheList")
        _byte = INILangFile.GetString("SomeCommands", "Byte")
        YB = INILangFile.GetString("SomeCommands", "YB")
        ZB = INILangFile.GetString("SomeCommands", "ZB")
        EB = INILangFile.GetString("SomeCommands", "EB")
        PB = INILangFile.GetString("SomeCommands", "PB")
        TB = INILangFile.GetString("SomeCommands", "TB")
        GB = INILangFile.GetString("SomeCommands", "GB")
        MB = INILangFile.GetString("SomeCommands", "MB")
        KB = INILangFile.GetString("SomeCommands", "KB")

        'frmIconMerge = INILangFile.GetString("frmIconMerge", "")

        Me.Text = INILangFile.GetString("frmIconMerge", "Text")

        'frmIconMergeMenuBarButtons = INILangFile.GetString("frmIconMergeMenuBarButtons", "")

        FilToolStripMenuItem.Text = INILangFile.GetString("frmIconMergeMenuBarButtons", "File")
        RedigerToolStripMenuItem.Text = INILangFile.GetString("frmIconMergeMenuBarButtons", "Edit")

        'frmIconMergeMenuBarFileButtons = INILangFile.GetString("frmIconMergeMenuBarFileButtons", "")

        NyttIkonToolStripMenuItem.Text = INILangFile.GetString("frmIconMergeMenuBarFileButtons", "NewIcon")
        ÅpneIkonToolStripMenuItem.Text = INILangFile.GetString("frmIconMergeMenuBarFileButtons", "OpenIcon")
        LukkIkonToolStripMenuItem.Text = INILangFile.GetString("frmIconMergeMenuBarFileButtons", "CloseIcon")
        LagreIkonToolStripMenuItem.Text = INILangFile.GetString("frmIconMergeMenuBarFileButtons", "SaveIcon")
        LagreIkonSomToolStripMenuItem.Text = INILangFile.GetString("frmIconMergeMenuBarFileButtons", "SaveIconAs")
        LukkToolStripMenuItem.Text = INILangFile.GetString("frmIconMergeMenuBarFileButtons", "Close")

        'frmIconMergeMenuBarEditButtons = INILangFile.GetString("frmIconMergeMenuBarEditButtons", "")

        LeggTilEtIkonToolStripMenuItem.Text = INILangFile.GetString("frmIconMergeMenuBarEditButtons", "AddNewIcon")
        FjernIkonToolStripMenuItem.Text = INILangFile.GetString("frmIconMergeMenuBarEditButtons", "RemoveSelectedIcon")

    End Sub

    Public Function ShowMessageBox(ByVal Message As String, Optional ByVal MessageButton As MessageBox.MessageButtons = MessageBox.MessageButtons.OKOnly, Optional ByVal MessageIcon As MessageBox.MessageIcons = MessageBox.MessageIcons.Information, Optional ByVal Title As String = "", Optional ByVal Icon As Icon = Nothing, Optional ByVal ShowDoNotShowAgainCheckBox As Boolean = False, Optional ByVal IsDoNotShowAgainCheckBoxChecked As Boolean = False) As MessageBox.MessageDialogResults

        Dim MessageBox As New MessageBox(Message, MessageButton, MessageIcon, Title, Icon, ShowDoNotShowAgainCheckBox, IsDoNotShowAgainCheckBoxChecked)

        Return MessageBox.ShowDialog()

    End Function

    Public Function SaveIcon(ByVal Icon As Icon, ByVal FileName As String) As Boolean

        Try
            If Not FileName.EndsWith(".ico") And Not FileName.EndsWith(".icl") Then

                Dim FullFileNameWithoutExtension As String = My.Computer.FileSystem.GetFileInfo(FileName).Directory.FullName & "\" & IO.Path.GetFileNameWithoutExtension(FileName)

                FileName = FullFileNameWithoutExtension & ".ico"

            End If

            Dim Stream As New StreamWriter(FileName)

            Icon.Save(Stream.BaseStream)

            Stream.Close()

        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Private Function GetIconSize(ByVal Icon As Icon) As Byte()

        Dim memStream As New MemoryStream : Icon.Save(memStream)

        Return memStream.ToArray

    End Function

    Public Function SaveIconLibary(ByVal IconList As List(Of Icon), ByVal FileName As String) As Boolean

        Try
            If Not FileName.EndsWith(".icl") Then

                Dim FullFileNameWithoutExtension As String = My.Computer.FileSystem.GetFileInfo(FileName).Directory.FullName & "\" & IO.Path.GetFileNameWithoutExtension(FileName)

                FileName = FullFileNameWithoutExtension & ".icl"

            End If

            Dim bStream As New BinaryWriter(New MemoryStream)

            For Each Icon As Icon In IconList
                bStream.Write(GetIconSize(Icon), 0, GetIconSize(Icon).Length)
            Next

            Dim ico As New Icon(bStream.BaseStream)

            Dim fStream As New StreamWriter(FileName)
            ico.Save(fStream.BaseStream)

            fStream.Close()

            Return True

        Catch ex As Exception
            Return False
        End Try

        Return True

    End Function

    Public Sub AddIconsToList(ByVal Icons As List(Of Icon))

        IconList.AddRange(Icons)

        LoadIcons()

        DirectCast(LeftPanel.Controls(LeftPanel.Controls.Count - 1), IconItem).Focus()

    End Sub

    Public Sub LoadIcons()

        LeftPanel.Controls.Clear()

        If IconList.Count > 0 Then

            For Each i As Icon In IconList

                Dim Item As New IconItem(i, bpp, NoIcon, EmptyIcon, _byte, YB, ZB, EB, PB, TB, GB, MB, KB)

                If IconList.IndexOf(i) > 0 Then
                    Item.Location = New Point(3, (123 * IconList.IndexOf(i)))
                Else
                    Item.Location = New Point(3, 6)
                End If

                AddHandler Item.IsSelected, AddressOf Item_IsSelected

                LeftPanel.Controls.Add(Item)

            Next

            DirectCast(LeftPanel.Controls(0), IconItem).Focus()

        Else

            SelectedIcon = Nothing

            IconPanel.Invalidate()

            StatusLabel.Text = ""

            NewIcon = False

            SavedIcon = False

            OpenedIcon = False

            OpenedOrNewIconChanged = False

            HasLoadedImage = False

            HasLoadedIconLibary = False

            FileName = Nothing

            Me.Text = IconMerge

        End If

    End Sub

    Private Sub Item_IsSelected(ByVal sender As Object, ByVal e As IconItem.IsSelectedEventArgs)

        SelectedIcon = e.Icon

        IconPanel.Invalidate()

        StatusLabel.Text = ISize & " " & e.Size.Width & "x" & e.Size.Height & " | " & ColorDepth & " " & e.ColorDepth & bpp & " | " & Colors & " " & e.Colors & " | " & IconSize & " " & e.IconSize

    End Sub

    Private Sub frmIconMaker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckLang()

    End Sub

    Private Sub CheckThings_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckThings.Tick

        LukkIkonToolStripMenuItem.Enabled = FileName <> Nothing

        LagreIkonToolStripMenuItem.Enabled = LeftPanel.Controls.Count > 0 And OpenedOrNewIconChanged
        LagreIkonSomToolStripMenuItem.Enabled = LeftPanel.Controls.Count > 0

        LeggTilEtIkonToolStripMenuItem.Enabled = OpenedIcon Or HasLoadedIconLibary Or NewIcon
        FjernIkonToolStripMenuItem.Enabled = Not IsNothing(SelectedIcon)

    End Sub

    Private Sub NyttIkonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NyttIkonToolStripMenuItem.Click

        Dim Dialog As New SaveFileDialog

        Dialog.Title = NewI
        Dialog.Filter = Icons & "|*.icl"
        Dialog.FileName = Nothing

        If Dialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            FileName = Dialog.FileName

            If LeftPanel.Controls.Count > 0 Then
                IconList.Clear()
            End If

            SelectedIcon = Nothing

            IconPanel.Invalidate()

            StatusLabel.Text = ""

            OpenedIcon = False

            OpenedOrNewIconChanged = False

            NewIcon = True

            SavedIcon = True

            HasLoadedImage = False

            HasLoadedIconLibary = False

            Me.Text = My.Computer.FileSystem.GetFileInfo(Dialog.FileName).Name & " - " & IconMerge

        End If

    End Sub

    Private Sub ÅpneIkonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ÅpneIkonToolStripMenuItem.Click

        Dim Dialog As New OpenFileDialog

        Dialog.Title = OpenIcon
        Dialog.Filter = "Alle støttede filer|*.ico; *.icl; *.png; *.gif; *.jpg; *.jpeg; *.bmp|Alle bilde filer|*.png; *.gif; *.jpg; *.jpeg; *.bmp|" & Shell32.GetFileType(".ico") & "|*.ico|" & Shell32.GetFileType(".icl") & "|*.icl|" & Shell32.GetFileType(".png") & "|*.png|" & Shell32.GetFileType(".gif") & "|*.gif|" & Shell32.GetFileType(".jpg") & "|*.jpg; *.jpeg|" & Shell32.GetFileType(".bmp") & "|*.bmp"
        Dialog.FileName = Nothing
        Dialog.Multiselect = False

        If Dialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            IconPanel.Invalidate()

            FileName = Dialog.FileName

            If Dialog.FileName.ToLower.EndsWith(".png") Or Dialog.FileName.ToLower.EndsWith(".jpg") Or Dialog.FileName.ToLower.EndsWith(".jpeg") Or Dialog.FileName.ToLower.EndsWith(".bmp") Or Dialog.FileName.ToLower.EndsWith(".gif") Then

                HasLoadedImage = True

                Dim IL As New List(Of Icon)

                IL.Add(IconConverter.ImageToIcon(Dialog.FileName))

                IconList = IL

            ElseIf Dialog.FileName.ToLower.EndsWith(".ico") Then

                OpenedIcon = True

                IconList = IconHelper.SplitGroupIcon(New Icon(Dialog.FileName))

            ElseIf Dialog.FileName.ToLower.EndsWith(".icl") Then

                HasLoadedIconLibary = True

                IconList = IconHelper.ExtractAllIcons(Dialog.FileName)

            End If

            LoadIcons()

            OpenedOrNewIconChanged = False

            NewIcon = False

            Me.Text = My.Computer.FileSystem.GetFileInfo(Dialog.FileName).Name & " - " & IconMerge

        End If

    End Sub

    Private Sub LukkIkonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LukkIkonToolStripMenuItem.Click

        IconList.Clear()

        LoadIcons()

    End Sub

    Private Sub LagreIkonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LagreIkonToolStripMenuItem.Click

        If SavedIcon And My.Computer.FileSystem.FileExists(FileName) Or OpenedOrNewIconChanged And My.Computer.FileSystem.FileExists(FileName) Then

            If HasLoadedImage Then

                Dim IL As New List(Of Icon)

                For Each Item As IconItem In LeftPanel.Controls
                    IL.Add(Item.Icon)
                Next

                If Not HasLoadedIconLibary Then
                    Dim Icon As Icon = IconHelper.Merge(IL)
                    SaveIcon(Icon, FileName)
                Else
                    SaveIconLibary(IL, FileName)
                End If

            Else

                If Not HasLoadedIconLibary Then
                    Dim Icon As Icon = IconHelper.Merge(IconList)
                    SaveIcon(Icon, FileName)
                Else
                    SaveIconLibary(IconList, FileName)
                End If

            End If

            OpenedOrNewIconChanged = False

        Else

            Dim Dialog As New SaveFileDialog

            Dialog.Title = SaveI
            Dialog.Filter = IIf(Not HasLoadedIconLibary, Shell32.GetFileType(".ico") & "|*.ico", Shell32.GetFileType(".icl") & "|*.icl")
            Dialog.FileName = Nothing

            If Dialog.ShowDialog = Windows.Forms.DialogResult.OK Then

                FileName = Dialog.FileName

                Dim Icon As Icon = IconHelper.Merge(IconList)

                SaveIcon(Icon, Dialog.FileName)

                SavedIcon = True

                OpenedOrNewIconChanged = False

            End If

        End If

    End Sub

    Private Sub LagreIkonSomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LagreIkonSomToolStripMenuItem.Click

        Dim Dialog As New SaveFileDialog

        Dialog.Title = SaveIconAs
        Dialog.Filter = "Alle støttede filer|*.ico; *.icl|" & Shell32.GetFileType(".ico") & "|*.ico" & Shell32.GetFileType(".icl") & "|*.icl"
        Dialog.FileName = FileName

        If Dialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            Dim Icon As Icon = IconHelper.Merge(IconList)

            SaveIcon(Icon, Dialog.FileName)

        End If

    End Sub

    Private Sub LukkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LukkToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub LeggTilEtIkonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeggTilEtIkonToolStripMenuItem.Click

        Dim Dialog As New OpenFileDialog

        Dialog.Title = AddNewIcon
        Dialog.Filter = "Alle støttede filer|*.ico; *.icl *.png; *.gif; *.jpg; *.jpeg; *.bmp|Alle bilde filer|*.png; *.gif; *.jpg; *.jpeg; *.bmp|" & Shell32.GetFileType(".ico") & "|*.ico|" & Shell32.GetFileType(".icl") & "|*.icl|" & Shell32.GetFileType(".png") & "|*.png|" & Shell32.GetFileType(".gif") & "|*.gif|" & Shell32.GetFileType(".jpg") & "|*.jpg; *.jpeg|" & Shell32.GetFileType(".bmp") & "|*.bmp"
        Dialog.FileName = Nothing
        Dialog.Multiselect = True

        If Dialog.ShowDialog = Windows.Forms.DialogResult.OK Then

            IconPanel.Invalidate()

            If NewIcon Then

                Dim IList As New List(Of Icon)

                For Each File As String In Dialog.FileNames

                    If File.ToLower.EndsWith(".png") Or File.ToLower.EndsWith(".jpg") Or File.ToLower.EndsWith(".jpeg") Or File.ToLower.EndsWith(".bmp") Or File.ToLower.EndsWith(".gif") Then

                        IList.Add(IconConverter.ImageToIcon(File))

                    ElseIf File.ToLower.EndsWith(".ico") Then

                        IList.Add(IconHelper.Merge(IconHelper.SplitGroupIcon(New Icon(File))))

                    ElseIf File.ToLower.EndsWith(".icl") Then

                        IList.Add(IconHelper.Merge(IconHelper.ExtractAllIcons(File)))

                    End If

                Next

                SaveIcon(IconHelper.Merge(IList), FileName)
                IconList = IList

                LoadIcons()

                DirectCast(LeftPanel.Controls(LeftPanel.Controls.Count - 1), IconItem).Focus()

                NewIcon = False

                OpenedIcon = True

            Else
                For Each File As String In Dialog.FileNames

                    If File.ToLower.EndsWith(".png") Or File.ToLower.EndsWith(".jpg") Or File.ToLower.EndsWith(".jpeg") Or File.ToLower.EndsWith(".bmp") Or File.ToLower.EndsWith(".gif") Then

                        Dim IL As New List(Of Icon)

                        IL.Add(IconConverter.ImageToIcon(File))

                        AddIconsToList(IL)

                    ElseIf File.ToLower.EndsWith(".ico") Then

                        AddIconsToList(IconHelper.SplitGroupIcon(New Icon(File)))

                    ElseIf File.ToLower.EndsWith(".icl") Then

                        AddIconsToList(IconHelper.ExtractAllIcons(File))

                    End If

                Next
            End If

            OpenedOrNewIconChanged = True

        End If

    End Sub

    Private Sub FjernIkonToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FjernIkonToolStripMenuItem.Click

        If My.Settings.ShowRemoveSelectedIconMessageBox Then

            Dim Dialog As New MessageBox(AreYouSureYouWannaRemoveTheSelectedIconFromTheList, MessageBox.MessageButtons.YesNoCancel, MessageBox.MessageIcons.Information, , , True)

            If Dialog.ShowDialog = MessageBox.MessageDialogResults.Yes Then

                My.Settings.ShowRemoveSelectedIconMessageBox = Not Dialog.IsDoNotShowAgainCheckBoxChecked

                IconList.Remove(SelectedIcon)

                SelectedIcon = Nothing

                IconPanel.Invalidate()

                StatusLabel.Text = ""

                LoadIcons()

                OpenedOrNewIconChanged = True

            Else

                My.Settings.ShowRemoveSelectedIconMessageBox = Not Dialog.IsDoNotShowAgainCheckBoxChecked

            End If

        Else

            IconList.Remove(SelectedIcon)

            SelectedIcon = Nothing

            IconPanel.Invalidate()

            StatusLabel.Text = ""

            LoadIcons()

            OpenedOrNewIconChanged = True

        End If

    End Sub

    Private Sub LeftPanel_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles LeftPanel.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            For Each File As String In e.Data.GetData(DataFormats.FileDrop)
                If File.ToLower.EndsWith(".ico") Or File.ToLower.EndsWith(".icl") Then
                    e.Effect = e.AllowedEffect
                End If
            Next
        End If
    End Sub

    Private Sub LeftPanel_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles LeftPanel.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            If DirectCast(e.Data.GetData(DataFormats.FileDrop), String())(0).EndsWith(".ico") Then
                FileName = DirectCast(e.Data.GetData(DataFormats.FileDrop), String())(0)
            End If

            For Each File As String In e.Data.GetData(DataFormats.FileDrop)
                If File.ToLower.EndsWith(".ico") Then
                    If OpenedIcon Or NewIcon Then

                        AddIconsToList(IconHelper.SplitGroupIcon(New Icon(File)))

                        OpenedOrNewIconChanged = True

                    Else

                        IconPanel.Invalidate()

                        IconList = IconHelper.SplitGroupIcon(New Icon(File))

                        LoadIcons()

                        OpenedIcon = True

                        OpenedOrNewIconChanged = DirectCast(e.Data.GetData(DataFormats.FileDrop), String()).Count > IconHelper.SplitGroupIcon(New Icon(File)).Count

                        NewIcon = False

                        Me.Text = My.Computer.FileSystem.GetFileInfo(FileName).Name & " - " & IconMerge

                    End If
                ElseIf File.ToLower.EndsWith(".icl") Then
                    If HasLoadedIconLibary Or NewIcon Then

                        AddIconsToList(IconHelper.ExtractAllIcons(File))

                        OpenedOrNewIconChanged = True

                    Else

                        IconPanel.Invalidate()

                        IconList = IconHelper.ExtractAllIcons(File)

                        LoadIcons()

                        HasLoadedIconLibary = True

                        OpenedOrNewIconChanged = DirectCast(e.Data.GetData(DataFormats.FileDrop), String()).Count > IconHelper.SplitGroupIcon(New Icon(File)).Count

                        NewIcon = False

                        Me.Text = My.Computer.FileSystem.GetFileInfo(FileName).Name & " - " & IconMerge

                    End If
                End If
            Next
        End If
    End Sub

    Private Sub IconPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles IconPanel.Paint

        If Not IsNothing(SelectedIcon) Then

            If SelectedIcon.Height > IconPanel.Height Or SelectedIcon.Width > IconPanel.Width Then

                DrawTextToGraphics(e.Graphics, TheIconIsTooBigToBeViewed, IconPanel.Size, New Font("Segoe UI", 9.0, FontStyle.Regular), Color.FromArgb(64, 64, 64))

            Else

                e.Graphics.DrawIcon(SelectedIcon, IIf(SelectedIcon.Width < IconPanel.Width, (IconPanel.Width - SelectedIcon.Width) / 2, 0), IIf(SelectedIcon.Height < IconPanel.Height, (IconPanel.Height - SelectedIcon.Height) / 2, 0))

            End If

        End If

    End Sub
End Class