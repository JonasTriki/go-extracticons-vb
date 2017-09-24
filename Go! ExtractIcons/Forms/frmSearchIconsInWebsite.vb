Imports System.IO
Imports System.Net

Public Class frmSearchIconsInWebsite

    Dim faviconGetterInfo As FAVICONANDTITLEGETTERINFO
    Dim m_URL As String

    Dim isLoadingSettings As Boolean
    Dim networkConnection As Boolean

    Public Sub New(ByVal URL As String)

        InitializeComponent()

        m_URL = URL

    End Sub

    Private Function GetUriScheme(ByVal URL As String) As String
        Dim Scheme As String = ""
        Dim Request As WebRequest = WebRequest.Create(URL)
        Try
            Dim Response As WebResponse = Request.GetResponse
            Scheme = Response.ResponseUri.Scheme
            Response.Close()
            Request = Nothing
            Return Scheme
        Catch Ex As Exception
            Request = Nothing
            Return ""
        End Try
    End Function

    Private Function FixURL(ByVal URL As String) As String
        URL = IIf(Not URL.StartsWith("http://"), "http://" & URL, URL)
        Dim scheme As String = GetUriScheme("http://" & New Uri(URL).Host)
        If Not scheme = "" Then
            Return scheme & Mid(URL, URL.IndexOf(":") + 1)
        Else
            Return ""
        End If
    End Function

    Private Function NetworkConnectionIsOn() As Boolean
        If Not My.Computer.Network.IsAvailable Then Return False
        Dim WebRequest As WebRequest = WebRequest.Create(New Uri("http://www.Microsoft.com/"))
        Try
            Dim WebResponse As WebResponse = WebRequest.GetResponse
            WebResponse.Close()
            WebRequest = Nothing
            Return True
        Catch Ex As Exception
            WebRequest = Nothing
            Return False
        End Try
    End Function

    Public Function ShowMessageBox(ByVal Message As String, Optional ByVal MessageButton As MessageBox.MessageButtons = MessageBox.MessageButtons.OKOnly, Optional ByVal MessageIcon As MessageBox.MessageIcons = MessageBox.MessageIcons.Information, Optional ByVal Title As String = "", Optional ByVal Icon As Icon = Nothing, Optional ByVal ShowDoNotShowAgainCheckBox As Boolean = False, Optional ByVal IsDoNotShowAgainCheckBoxChecked As Boolean = False) As MessageBox.MessageDialogResults

        Dim MessageBox As New MessageBox(Message, MessageButton, MessageIcon, Title, Icon, ShowDoNotShowAgainCheckBox, IsDoNotShowAgainCheckBoxChecked)

        Return MessageBox.ShowDialog()

    End Function

    Private Function GetImageFromURL(ByVal URL As String) As Image
        Try
            Dim FIcon As Image = Image.FromStream(HttpWebRequest.Create(URL).GetResponse().GetResponseStream())
            If IsNothing(FIcon) Then
                Return Nothing
            Else
                Return FIcon
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function GetIconFromURL(ByVal URL As String) As Icon
        Try
            Dim FIcon As New Icon(HttpWebRequest.Create(URL).GetResponse().GetResponseStream())
            If IsNothing(FIcon) Then
                Return Nothing
            Else
                Return FIcon
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Function CheckIcon(ByVal URL As String) As Icon
        Try
            Return IIf(Not IsNothing(GetImageFromURL(URL)), IconConverter.ImageToIcon(GetImageFromURL(URL)), Nothing)
        Catch ex As ArgumentNullException
            Return IIf(Not IsNothing(GetIconFromURL(URL)), GetIconFromURL(URL), Nothing)
        End Try
    End Function

    Public Function ByteToHighestAvailable(ByVal Size As Long) As String

        Dim Result As String = ""

        If Size <= 999 Then
            'byte <= 999 byte
            Result &= Size & " Byte"
        ElseIf Size >= 1.0E+24 Then
            'YB >= 100000000000000000 byte, Value / 1.2089258196146291E+18
            Result = Math.Round((Size / 1.2089258196146291E+18), 2) & " YB"
        ElseIf Size >= 1.0E+21 Then
            'ZB >= 1000000000000000 byte, Value / 1.1805916207174114E+17
            Result = Math.Round((Size / 1.1805916207174114E+17), 2) & " ZB"
        ElseIf Size >= 1000000000000000000 Then
            'EB >= 10000000000000 byte, Value / 1152921504606846976
            Result = Math.Round((Size / 1152921504606846976), 2) & " EB"
        ElseIf Size >= 1000000000000000 Then
            'PB >= 100000000000 byte, Value / 1125899906842624
            Result = Math.Round((Size / 1125899906842624), 2) & " PB"
        ElseIf Size >= 1000000000000 Then
            'TB >= 1000000000 byte, Value / 1099511627776
            Result = Math.Round((Size / 1099511627776), 2) & " TB"
        ElseIf Size >= 1000000000 Then
            'GB >= 10000000 byte, Value / 1073741824
            Result = Math.Round((Size / 1073741824), 2) & " GB"
        ElseIf Size >= 1000000 Then
            'MB >= 1000000 byte, Value / 1048576
            Result = Math.Round((Size / 1048576), 2) & " MB"
        ElseIf Size >= 1000 Then
            'KB >= 1000 byte, Value / 1024
            Result = Math.Round((Size / 1024), 2) & " KB"
        End If

        Return Result

    End Function

    Private Function SearchIconsFromHTML(ByVal HTML As String) As Boolean

        FaviconImageList.Images.Clear()
        lvResults.Items.Clear()

        Dim CommandList As New List(Of String)
        Dim URLList As New List(Of String)
        Dim IconList As New List(Of Icon)

        For Each ICONINFO As ICONGETTERINFO In New IconGetter().GetAllIconsFromHTML(HTML)
            URLList.Add(IIf(ICONINFO.URL <> "", ICONINFO.URL, "Ukjent URL"))
            IconList.Add(CheckIcon(ICONINFO.URL))
            CommandList.Add(ICONINFO.CommandLine)
            Application.DoEvents()
        Next

        For i As Integer = 0 To IconList.Count - 1

            If Not IconList(i) Is Nothing Then

                On Error Resume Next

                llStatus.Text = "Søker etter ikoner... (" & i + 1 & " av " & URLList.Count & ")"

                FaviconImageList.Images.Add(i, IconHelper.GetBestFitIcon(IconList(i), New Size(16, 16)))

                Dim Item As New ListViewItem(IO.Path.GetFileName(URLList(i)), i)

                'Get the Icon File Size
                Dim Stream As New MemoryStream : IconList(i).Save(Stream)

                With Item.SubItems
                    .Add(ByteToHighestAvailable(Stream.Length))
                    .Add(URLList(i))
                    .Add(CommandList(i))
                End With

                Stream.Close()

                Item.Tag = IconList(i)

                lvResults.Items.Add(Item)

            End If

            Application.DoEvents()

        Next

        llStatus.Text = IIf(URLList.Count > 1, URLList.Count & " ikoner funnet i nettsiden """ & IO.Path.GetFileName(My.Settings.SearchIconsHTMLDocumentFile) & """", "1 ikon funnet i nettsiden """ & IO.Path.GetFileName(My.Settings.SearchIconsHTMLDocumentFile) & """")

        Return True

    End Function

    Private Function SearchIcons(ByVal URL As String) As Boolean

        FaviconImageList.Images.Clear()
        lvResults.Items.Clear()

        Dim CommandList As New List(Of String)
        Dim URLList As New List(Of String)
        Dim IconList As New List(Of Icon)

        For Each ICONINFO As ICONGETTERINFO In New IconGetter().GetAllIcons(URL)
            URLList.Add(ICONINFO.URL)
            IconList.Add(CheckIcon(ICONINFO.URL))
            CommandList.Add(ICONINFO.CommandLine)
            Application.DoEvents()
        Next

        For i As Integer = 0 To URLList.Count - 1

            On Error Resume Next

            llStatus.Text = "Søker etter ikoner... (" & i + 1 & " av " & URLList.Count & ")"

            FaviconImageList.Images.Add(i, IconHelper.GetBestFitIcon(IconList(i), New Size(16, 16)))

            Dim Item As New ListViewItem(IO.Path.GetFileName(URLList(i)), i)

            'Get the Icon File Size
            Dim Stream As New MemoryStream : IconList(i).Save(Stream)

            With Item.SubItems
                .Add(ByteToHighestAvailable(Stream.Length))
                .Add(URLList(i))
                .Add(CommandList(i))
            End With

            Stream.Close()

            Item.Tag = IconList(i)

            lvResults.Items.Add(Item)

            Application.DoEvents()

        Next

        llStatus.Text = IIf(URLList.Count > 1, URLList.Count & " ikoner funnet i nettsiden """ & txtURL.Text & """", "1 ikon funnet i nettsiden """ & txtURL.Text & """")

        Return True

    End Function

    Private Sub CheckMode(ByVal NetworkConnection As Boolean, ByVal FirstLoad As Boolean)

        isLoadingSettings = True

        If NetworkConnection Then

            rbSearchAfterIconsInHTMLDocumentFile.Checked = My.Settings.SearchIconsInHTMLDocumentFile
            rbSearchAfterIconsInThisURL.Checked = My.Settings.SearchIconsInThisURL

            btnOpenFile.Enabled = My.Settings.SearchIconsInHTMLDocumentFile
            txtHTMLDoc.Enabled = My.Settings.SearchIconsInHTMLDocumentFile
            btnBrowseFiles.Enabled = My.Settings.SearchIconsInHTMLDocumentFile

            btnOpenURL.Enabled = My.Settings.SearchIconsInThisURL
            txtURL.Enabled = My.Settings.SearchIconsInThisURL
            btnSearchIcons.Enabled = True

            txtHTMLDoc.Text = My.Settings.SearchIconsHTMLDocumentFile
            txtHTMLDoc.Icon = Shell32.GetIcon(IO.Path.GetFileName(My.Settings.SearchIconsHTMLDocumentFile)).ToBitmap

            btnOpenFile.Image = txtHTMLDoc.Icon

            If My.Settings.SearchIconsInHTMLDocumentFile Then
                Me.Text = """" & IO.Path.GetFileName(My.Settings.SearchIconsHTMLDocumentFile)& """ - Søk etter ikoner i nettside..."
            End If

            If FirstLoad Then
                LoadSettings(m_URL)
            End If

        Else

            rbSearchAfterIconsInHTMLDocumentFile.Checked = True
            rbSearchAfterIconsInThisURL.Checked = False

            btnOpenFile.Enabled = True
            txtHTMLDoc.Enabled = True
            btnBrowseFiles.Enabled = True

            btnOpenURL.Enabled = False
            txtURL.Enabled = False
            btnSearchIcons.Enabled = True

            txtHTMLDoc.Text = My.Settings.SearchIconsHTMLDocumentFile
            txtHTMLDoc.Icon = Shell32.GetIcon(IO.Path.GetFileName(My.Settings.SearchIconsHTMLDocumentFile)).ToBitmap

            btnOpenFile.Image = txtHTMLDoc.Icon

        End If

        isLoadingSettings = False

    End Sub

    Private Sub LoadSettings(ByVal URL As String)

        faviconGetterInfo = New FaviconAndTitleGetter().GetFaviconAndTitleInfo(URL)

        If My.Settings.SearchIconsInThisURL Then
            If Not faviconGetterInfo.Title = "" Then
                Me.Text = """" & faviconGetterInfo.Title & """ - Søk etter ikoner i nettside..."
            Else
                Me.Text = "Ingen titel - Søk etter ikoner i nettside..."
            End If
        End If

        If Not faviconGetterInfo.FaviconURL = "" Then

            Dim fIcon As Image = faviconGetterInfo.FaviconAsImage

            txtURL.Text = URL

            If Not IsNothing(fIcon) Then
                btnOpenURL.Image = New Bitmap(fIcon, New Size(16, 16))
                txtURL.Icon = fIcon
            Else
                btnOpenURL.Image = My.Resources.Document
                txtURL.Icon = My.Resources.Document
            End If

        Else

            txtURL.Text = URL

            btnOpenURL.Image = My.Resources.Document
            txtURL.Icon = My.Resources.Document

        End If

    End Sub

    Private Sub frmSearchIconsInWebsite_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtURL.Text = "http://www."
        If NetworkConnectionIsOn() Then
            llInternetConection.Text = "Internet forbindelse: På"
            llInternetConection.Image = My.Resources.InternetCon
            networkConnection = True
            CheckMode(True, True)
        Else
            llInternetConection.Text = "Internet forbindelse: Av"
            llInternetConection.Image = My.Resources.InternetConOff
            networkConnection = False
            CheckMode(False, True)
            ShowMessageBox("Internett forbindelsen er av!", MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Critical, "Feil!", Me.Icon)
        End If
    End Sub

    Private Sub CheckBtns_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBtns.Tick

        btnPoperitiesForIcon.Enabled = lvResults.SelectedItems.Count > 0

        btnSaveIcons.Enabled = lvResults.Items.Count > 0

    End Sub

    Private Sub rbSearchAfterIconsInHTMLDocumentFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSearchAfterIconsInHTMLDocumentFile.CheckedChanged
        My.Settings.SearchIconsInHTMLDocumentFile = rbSearchAfterIconsInHTMLDocumentFile.Checked
        If My.Settings.SearchIconsInHTMLDocumentFile Then
            If Not isLoadingSettings Then
                CheckMode(networkConnection, False)
            End If
        End If
    End Sub

    Private Sub btnOpenFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFile.Click
        If My.Computer.FileSystem.FileExists(My.Settings.SearchIconsHTMLDocumentFile) Then
            Process.Start(My.Settings.SearchIconsHTMLDocumentFile)
        End If
    End Sub

    Private Sub btnBrowseFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseFiles.Click

        Dim dlg As New OpenFileDialog

        dlg.Title = "Venligst velg et HTML-dokument..."
        dlg.Filter = Shell32.GetFileType(".html") & "|*.html; *.htm"
        dlg.FileName = My.Settings.SearchIconsHTMLDocumentFile
        dlg.Multiselect = False

        If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then

            My.Settings.SearchIconsHTMLDocumentFile = dlg.FileName

            txtHTMLDoc.Text = My.Settings.SearchIconsHTMLDocumentFile
            txtHTMLDoc.Icon = Shell32.GetIcon(IO.Path.GetFileName(My.Settings.SearchIconsHTMLDocumentFile)).ToBitmap

            btnOpenFile.Image = txtHTMLDoc.Icon

        End If

    End Sub

    Private Sub rbSearchAfterIconsInThisURL_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSearchAfterIconsInThisURL.CheckedChanged
        My.Settings.SearchIconsInThisURL = rbSearchAfterIconsInThisURL.Checked
        If My.Settings.SearchIconsInThisURL Then
            If Not isLoadingSettings Then
                CheckMode(networkConnection, False)
            End If
        End If
    End Sub

    Private Sub btnOpenURL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenURL.Click
        Process.Start(txtURL.Text)
    End Sub

    Private Sub btnSearchIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchIcons.Click
        If My.Settings.SearchIconsInHTMLDocumentFile Then
            If My.Computer.FileSystem.FileExists(My.Settings.SearchIconsHTMLDocumentFile) Then

                Dim htmlSourceCode As String = My.Computer.FileSystem.ReadAllText(My.Settings.SearchIconsHTMLDocumentFile)

                If Not htmlSourceCode = "" Then
                    SearchIconsFromHTML(htmlSourceCode)
                Else
                    ShowMessageBox("Nettsiden """ & My.Settings.SearchIconsHTMLDocumentFile & """ er tom!", MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation, "Feil!", Me.Icon)
                End If
            Else
                ShowMessageBox("Nettsiden """ & My.Settings.SearchIconsHTMLDocumentFile & """ eksisterer ikke!", MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation, "Feil!", Me.Icon)
            End If
            If lvResults.Items.Count = 0 Then
                llStatus.Text = "Ingen ikoner funnet i nettsiden"
                ShowMessageBox("Ingen ikoner funnet i nettsiden """ & IO.Path.GetFileName(My.Settings.SearchIconsHTMLDocumentFile) & """.", MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation, "Feil!", Me.Icon)
            End If
        Else
            If Not My.Settings.SearchIconsURL = txtURL.Text Then
                Dim fixedURL As String = FixURL(txtURL.Text)
                My.Settings.SearchIconsURL = IIf(fixedURL <> "", fixedURL, txtURL.Text)
                txtURL.Text = My.Settings.SearchIconsURL
                LoadSettings(My.Settings.SearchIconsURL)
            End If
            If SearchIcons(My.Settings.SearchIconsURL) Then
                If lvResults.Items.Count = 0 Then
                    If Not faviconGetterInfo.FaviconURL = "" Then

                        Dim favicon As Icon = GetIconFromURL(faviconGetterInfo.FaviconURL)

                        If IsNothing(favicon) Then favicon = IconConverter.ImageToIcon(GetImageFromURL(faviconGetterInfo.FaviconURL))

                        If Not IsNothing(favicon) Then

                            On Error Resume Next

                            FaviconImageList.Images.Add(faviconGetterInfo.FaviconURL, New Icon(favicon, New Size(16, 16)))

                            Dim Item As New ListViewItem(IO.Path.GetFileName(faviconGetterInfo.FaviconURL), faviconGetterInfo.FaviconURL)

                            'Get the Icon File Size
                            Dim Stream As New MemoryStream : favicon.Save(Stream)

                            With Item.SubItems
                                .Add(ByteToHighestAvailable(Stream.Length))
                                .Add(faviconGetterInfo.FaviconURL)
                                .Add(IIf(faviconGetterInfo.FaviconURLCommandLine = "", "Ingen kommando linje", faviconGetterInfo.FaviconURLCommandLine))
                            End With

                            Stream.Close()

                            Item.Tag = favicon

                            lvResults.Items.Add(Item)

                            llStatus.Text = "1 ikon funnet i nettsiden"

                            Application.DoEvents()

                        End If

                    End If
                End If
            End If
            If lvResults.Items.Count = 0 Then
                llStatus.Text = "Ingen ikoner funnet i nettsiden"
                ShowMessageBox("Ingen ikoner funnet i nettsiden """ & txtURL.Text & """.", MessageBox.MessageButtons.OKOnly, MessageBox.MessageIcons.Exlamation, "Feil!", Me.Icon)
            End If
        End If
    End Sub

    Private Sub lvResults_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvResults.SelectedIndexChanged
        If lvResults.SelectedItems.Count > 0 Then
            llStatus.Text = "Navn: " & lvResults.SelectedItems(0).Text & " | Størrelse: " & lvResults.SelectedItems(0).SubItems(1).Text
        Else
            llStatus.Text = IIf(lvResults.Items.Count > 1, lvResults.Items.Count & " ikoner funnet i nettsiden", "1 ikon funnet i nettsiden")
        End If
    End Sub

    Private Sub lvResults_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvResults.MouseDoubleClick
        If e.Button = Windows.Forms.MouseButtons.Left Then

            Dim Dialog As New frmViewIcons(lvResults.SelectedIndices(0), "\" & lvResults.SelectedItems(0).Text, IconHelper.SplitGroupIcon(lvResults.SelectedItems(0).Tag))

            Dialog.ShowDialog()

        End If
    End Sub

    Private Sub btnPoperitiesForIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPoperitiesForIcon.Click

        Dim Dialog As New frmViewIcons(lvResults.SelectedIndices(0), "\" & lvResults.SelectedItems(0).Text, IconHelper.SplitGroupIcon(lvResults.SelectedItems(0).Tag))

        Dialog.ShowDialog()

    End Sub

    Private Sub btnSaveIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveIcons.Click

        Dim IList As New List(Of Icon)

        For i As Integer = 0 To lvResults.SelectedIndices.Count - 1
            IList.Add(lvResults.SelectedItems(0).Tag)
        Next

        Dim NList As New List(Of String)
        Dim INList As New List(Of String)
        Dim IMCList As New List(Of String)

        For Each i As ListViewItem In lvResults.SelectedItems
            NList.Add(i.Text)
            INList.Add("\" & i.Text)
            IMCList.Add(i.Text)
        Next

        Dim Dialog As New frmSaveIcons(IList, NList, INList, IMCList)

        Dialog.ShowDialog()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class