Imports System.IO
Imports System.Drawing.Drawing2D

Public Class frmViewIcons

    Dim m_IconID As Integer
    Dim m_FileName As String
    Dim m_Folder As String
    Dim m_Icons As List(Of Icon)

    Dim m_GetFileSize As String

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

    Dim TheIconIsTooBigToBeViewed As String
    Dim MoreThanOneIconIsSelected As String
    Dim PleaseChooseAnIcon As String

    Dim drawPleaseChooseAndIcon As Boolean = False
    Dim drawMoreThanOneIconIsSelected As Boolean = False

    Dim BPP As String

    Dim m_Icon As Icon

    Public Sub New(ByVal IconID As Integer, ByVal FileName As String, ByVal Icons As List(Of Icon))

        InitializeComponent()

        m_IconID = IconID

        m_FileName = FileName

        m_Icons = Icons

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

    Private Sub FillListView(ByVal Icons As List(Of Icon))

        For i As Integer = 0 To Icons.Count - 1

            Dim Item As New ListViewItem(i + 1)

            Item.Tag = Icons(i)

            With Item.SubItems

                .Add(Icons(i).Size.Width & " x " & Icons(i).Size.Height)
                .Add(New IconInfo(Icons(i)).ColorDepth & BPP)
                .Add(New IconInfo(Icons(i)).ColorCount)

                'Get the Icon Size
                Dim Stream As New MemoryStream : Icons(i).Save(Stream)
                .Add(GetFileSize(Stream.Length))

            End With

            IconListView.Items.Add(Item)

        Next

        IconListView.Select() : IconListView.Items(0).Selected = True

    End Sub

    Public Sub CheckLang()

        INILangFile = New IniFile(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages").Item(My.Settings.Language))

        LoadLang()

    End Sub

    Public Sub LoadLang()

        'SomeCommands = INILangFile.GetString("SomeCommands", "")

        TheIconIsTooBigToBeViewed = INILangFile.GetString("SomeCommands", "TheIconIsTooBigToBeViewed")
        MoreThanOneIconIsSelected = INILangFile.GetString("SomeCommands", "MoreThanOneIconIsSelected")
        PleaseChooseAnIcon = INILangFile.GetString("SomeCommands", "PleaseChooseAnIcon")
        BPP = INILangFile.GetString("SomeCommands", "BPP")
        _byte = INILangFile.GetString("SomeCommands", "Byte")
        YB = INILangFile.GetString("SomeCommands", "YB")
        ZB = INILangFile.GetString("SomeCommands", "ZB")
        EB = INILangFile.GetString("SomeCommands", "EB")
        PB = INILangFile.GetString("SomeCommands", "PB")
        TB = INILangFile.GetString("SomeCommands", "TB")
        GB = INILangFile.GetString("SomeCommands", "GB")
        MB = INILangFile.GetString("SomeCommands", "MB")
        KB = INILangFile.GetString("SomeCommands", "KB")

        'frmViewIcons = INILangFile.GetString("frmViewIcons", "")

        Me.Text = INILangFile.GetString("frmViewIcons", "Text") & " " & IO.Path.GetFileName(m_FileName)

        'frmViewIconsControls = INILangFile.GetString("frmViewIconsControls", "")

        StartTabPage.Text = INILangFile.GetString("frmViewIconsControls", "Basics") & ": "
        IFileName.Text = INILangFile.GetString("frmViewIconsControls", "Filename") & ": "
        IID.Text = INILangFile.GetString("frmViewIconsControls", "IconID") & ": "
        ISize.Text = INILangFile.GetString("frmViewIconsControls", "Size") & ": "
        IColorDepth.Text = INILangFile.GetString("frmViewIconsControls", "ColorDepth") & ": "
        IDimensions.Text = INILangFile.GetString("frmViewIconsControls", "Dimensions") & ": "
        IColors.Text = INILangFile.GetString("frmViewIconsControls", "Colors") & ": "
        IconPreviewLabel.Text = INILangFile.GetString("frmViewIconsControls", "Preview") & ": "
        IDColumn.Text = INILangFile.GetString("frmViewIconsControls", "ID")
        DimensionsColumn.Text = INILangFile.GetString("frmViewIconsControls", "Dimensions")
        ColorDepthColumn.Text = INILangFile.GetString("frmViewIconsControls", "ColorDepth")
        ColorsColumn.Text = INILangFile.GetString("frmViewIconsControls", "Colors")
        SizeColumn.Text = INILangFile.GetString("frmViewIconsControls", "Size")
        CopyIconButton.Text = INILangFile.GetString("frmViewIconsControls", "CopyIcon")
        SaveIconsToButton.Text = INILangFile.GetString("frmViewIconsControls", "SaveIconsTo")
        CloseButton.Text = INILangFile.GetString("frmViewIconsControls", "Close")

    End Sub

    Public Sub SaveIcon(ByVal Icon As Icon, ByVal FileName As String)

        Dim Stream As New StreamWriter(FileName)

        Icon.Save(Stream.BaseStream)

        Stream.Close()

    End Sub

    Public Sub DrawTextToGraphics(ByVal g As Graphics, ByVal textToDraw As String, ByVal sizeToControl As Size, ByVal f As Font, ByVal foreColor As Color)

        Dim sb As New SolidBrush(foreColor)
        Dim sf As New StringFormat(StringFormatFlags.LineLimit)
        sf.Trimming = StringTrimming.EllipsisWord
        Dim ms As SizeF = g.MeasureString(textToDraw, f, sizeToControl, sf)
        Dim bounds As New RectangleF(New PointF((sizeToControl.Width - ms.Width) / 2, (sizeToControl.Height - ms.Height) / 2), New SizeF(sizeToControl.Width, sizeToControl.Height))

        g.DrawString(textToDraw, f, sb, bounds, sf)

    End Sub

    Public Function DrawArc(ByVal Rectangle As Rectangle, Optional ByVal Radius As Integer = 4) As GraphicsPath

        Dim Path As New GraphicsPath

        Path.AddArc(Rectangle.X, Rectangle.Y, Radius, Radius, 180, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Y, Radius, Radius, 270, 90)
        Path.AddArc(Rectangle.Width - Radius, Rectangle.Height - Radius, Radius, Radius, 0, 90)
        Path.AddArc(Rectangle.X, Rectangle.Height - Radius, Radius, Radius, 90, 90)
        Path.CloseFigure()

        Return Path

    End Function

    Private Sub IconPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles IconPanel.Paint

        Dim g As Graphics = e.Graphics

        If drawPleaseChooseAndIcon Then

            DrawTextToGraphics(g, PleaseChooseAnIcon, IconPanel.Size, New Font("Segoe UI", 9.0, FontStyle.Regular), Color.FromArgb(64, 64, 64))

        ElseIf drawMoreThanOneIconIsSelected Then

            DrawTextToGraphics(g, MoreThanOneIconIsSelected, IconPanel.Size, New Font("Segoe UI", 9.0, FontStyle.Regular), Color.FromArgb(64, 64, 64))

        Else

            If m_Icon.Height > IconPanel.Height Or m_Icon.Width > IconPanel.Width Then

                DrawTextToGraphics(g, TheIconIsTooBigToBeViewed, IconPanel.Size, New Font("Segoe UI", 9.0, FontStyle.Regular), Color.FromArgb(64, 64, 64))

                IconFileName.Text = IO.Path.GetFileName(m_FileName)
                IconID.Text = IconListView.SelectedItems(0).Text
                IconSize.Text = IconListView.SelectedItems(0).SubItems(4).Text
                IconDimensions.Text = IconListView.SelectedItems(0).SubItems(1).Text
                IconColorDepth.Text = IconListView.SelectedItems(0).SubItems(2).Text
                IconColorDepth.LinkBehavior = LinkBehavior.SystemDefault
                IconColorDepth.Enabled = True
                IconColors.Text = IconListView.SelectedItems(0).SubItems(3).Text

            Else

                If IconPanel.Height = m_Icon.Height And IconPanel.Width = m_Icon.Width Then

                    g.DrawIcon(m_Icon, 0, 0)

                ElseIf IconPanel.Height = m_Icon.Height Then

                    g.DrawIcon(m_Icon, 0, (IconPanel.Height - m_Icon.Height) / 2)

                ElseIf IconPanel.Width = m_Icon.Width Then

                    g.DrawIcon(m_Icon, (IconPanel.Width - m_Icon.Width) / 2, 0)

                Else

                    g.DrawIcon(m_Icon, (IconPanel.Width - m_Icon.Width) / 2, (IconPanel.Height - m_Icon.Height) / 2)

                End If

            End If

        End If

        g.SmoothingMode = SmoothingMode.AntiAlias

        g.DrawPath(New Pen(Color.FromArgb(197, 197, 197), 1), DrawArc(New Rectangle(0, 0, IconPanel.Width - 1, IconPanel.Height - 1), 5))

        g.Dispose()

    End Sub

    Private Sub IconListView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IconListView.SelectedIndexChanged

        Try

            If IconListView.SelectedItems().Count = 0 Then

                'Reset values
                drawPleaseChooseAndIcon = True
                drawMoreThanOneIconIsSelected = False
                IconPanel.Invalidate()

                IconFileName.Text = PleaseChooseAnIcon
                IconID.Text = PleaseChooseAnIcon
                IconSize.Text = PleaseChooseAnIcon
                IconDimensions.Text = PleaseChooseAnIcon
                IconColorDepth.Text = PleaseChooseAnIcon
                IconColorDepth.LinkBehavior = LinkBehavior.NeverUnderline
                IconColorDepth.Enabled = False
                IconColors.Text = PleaseChooseAnIcon

            ElseIf IconListView.SelectedItems().Count > 1 Then

                'Reset values
                drawPleaseChooseAndIcon = False
                drawMoreThanOneIconIsSelected = True
                IconPanel.Invalidate()

                IconFileName.Text = PleaseChooseAnIcon
                IconID.Text = PleaseChooseAnIcon
                IconSize.Text = PleaseChooseAnIcon
                IconDimensions.Text = PleaseChooseAnIcon
                IconColorDepth.Text = PleaseChooseAnIcon
                IconColorDepth.LinkBehavior = LinkBehavior.NeverUnderline
                IconColorDepth.Enabled = False
                IconColors.Text = PleaseChooseAnIcon

            Else

                IconColorDepth.LinkBehavior = LinkBehavior.SystemDefault
                IconColorDepth.Enabled = True

                'Load information
                drawPleaseChooseAndIcon = False
                drawMoreThanOneIconIsSelected = False
                m_Icon = IconListView.SelectedItems(0).Tag
                IconPanel.Invalidate()

                IconFileName.Text = IO.Path.GetFileName(m_FileName)
                IconID.Text = IconListView.SelectedItems(0).Text
                IconSize.Text = IconListView.SelectedItems(0).SubItems(4).Text
                IconDimensions.Text = IconListView.SelectedItems(0).SubItems(1).Text
                IconColorDepth.Text = IconListView.SelectedItems(0).SubItems(2).Text
                IconColors.Text = IconListView.SelectedItems(0).SubItems(3).Text

            End If

        Catch ex As ArgumentOutOfRangeException

        End Try

    End Sub

    Private Sub CheckButtons_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckButtons.Tick

        CopyIconButton.Enabled = IconListView.SelectedItems().Count = 1

        SaveIconsToButton.Enabled = IconListView.SelectedItems().Count > 0

    End Sub

    Private Sub frmViewIcons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckLang()

        FillListView(m_Icons)

    End Sub

    Private Sub IconColorDepth_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles IconColorDepth.LinkClicked

        Dim Dialog As New frmIconColorDepthChangerFromIcon(IconListView.SelectedItems(0).Tag)

        If Dialog.ShowDialog = Windows.Forms.DialogResult.Cancel Then
            If Dialog.IsOK Then
                IconListView.SelectedItems(0).Tag = Dialog.ResultIcon
            End If
        End If

    End Sub

    Private Sub CopyIconButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyIconButton.Click

        Clipboard.SetImage(DirectCast(IconListView.SelectedItems(0).Tag, Icon).ToBitmap)

    End Sub

    Private Sub SaveIconsToButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveIconsToButton.Click

        Dim IList As New List(Of Icon)

        For i As Integer = 0 To IconListView.SelectedIndices.Count - 1

            IList.Add(m_Icons(IconListView.SelectedItems(i).Index))

        Next

        Dim INList As New List(Of String)
        Dim NList As New List(Of String)
        Dim IMCList As New List(Of String)

        For Each i As ListViewItem In IconListView.SelectedItems
            NList.Add(i.Text)
            INList.Add(m_FileName & "-" & i.Index + 1)
            IMCList.Add(m_FileName)
        Next

        Dim Dialog As New frmSaveIcons(IList, NList, INList, IMCList)

        Dialog.ShowDialog()

    End Sub

    Private Sub CloseButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub IconListView_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles IconListView.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then

            Dim Dialog As New frmPreviewIcon(m_Icons(IconListView.SelectedItems(0).Index), m_FileName)

            Dialog.ShowDialog()

        End If
    End Sub
End Class