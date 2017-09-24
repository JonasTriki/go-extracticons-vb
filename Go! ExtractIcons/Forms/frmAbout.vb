Public Class frmAbout

    Dim Copyright As String
    Dim ThisProgramIsMadeByGoVisualTeamForMoreInformationPleaseVisitOurSite As String

    Dim INILangFile As IniFile

    Public Sub CheckLang()

        INILangFile = New IniFile(My.Computer.FileSystem.GetFiles(Application.StartupPath & "\Languages").Item(My.Settings.Language))

        LoadLang()

    End Sub

    Public Sub LoadLang()

        'frmAbout = INILangFile.GetString("frmAbout","")

        Me.Text = INILangFile.GetString("frmAbout", "Text")

        'frmAboutControls = INILangFile.GetString("frmAboutControls","")

        ThisProgramIsMadeByGoVisualTeamForMoreInformationPleaseVisitOurSite = INILangFile.GetString("frmAboutControls", "ThisProgramIsMadeByGoVisualTeamForMoreInformationPleaseVisitOurSite").Replace("&NEWLINE&", vbNewLine)

        'SomeCommands = INILangFile.GetString("SomeCommands","")

        Copyright = INILangFile.GetString("SomeCommands", "Copyright")

    End Sub

    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckLang()

        lVersion.Text = My.Application.Info.Version.ToString
        lInfo.Text = ThisProgramIsMadeByGoVisualTeamForMoreInformationPleaseVisitOurSite
        lCopyright.Text = Copyright

    End Sub

    Private Sub pbIcon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbIcon.Click
        Process.Start("http://www.govisualteam.comoj.com/")
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class