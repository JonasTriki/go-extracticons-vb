Public Class frmFileAlreadyExists

    Public resultInfo As New FileAlreadyExistsInfo

    Dim m_FileName As String
    Dim m_CleanFileName As String
    Dim m_SourceFileName As String

    Public Sub New(ByVal fileName As String, ByVal cleanFileName As String, ByVal sourceFileName As String)

        InitializeComponent()

        m_FileName = fileName
        m_CleanFileName = cleanFileName
        m_SourceFileName = sourceFileName

    End Sub

    Public Shared Function CutPath(ByVal inputPath As String, ByVal outputLength As Integer) As String

        Dim l As Integer = CInt((outputLength - 3) / 2)

        Dim leftString As String = Microsoft.VisualBasic.Left(inputPath, l)
        Dim rightString As String = Microsoft.VisualBasic.Right(inputPath, l)

        Do Until leftString.EndsWith("\")
            leftString = leftString.Remove(leftString.Length - 1, 1)
        Loop

        Do Until rightString.StartsWith("\")
            rightString = rightString.Remove(0, 1)
        Loop

        Return leftString & "..." & rightString

    End Function

    Public Function ConvertByteToHighestAvailable(ByVal Size As Long) As String

        Dim resultString As String = ""

        If Size <= 999 Then
            'byte <= 999 byte
            resultString = Size & " byte"
        ElseIf Size >= 1.0E+24 Then
            'YB >= 100000000000000000 byte, Value / 1.2089258196146291E+18
            resultString = Math.Round((Size / 1.2089258196146291E+18), 2) & " YB"
        ElseIf Size >= 1.0E+21 Then
            'ZB >= 1000000000000000 byte, Value / 1.1805916207174114E+17
            resultString = Math.Round((Size / 1.1805916207174114E+17), 2) & " ZB"
        ElseIf Size >= 1000000000000000000 Then
            'EB >= 10000000000000 byte, Value / 1152921504606846976
            resultString = Math.Round((Size / 1152921504606846976), 2) & " EB"
        ElseIf Size >= 1000000000000000 Then
            'PB >= 100000000000 byte, Value / 1125899906842624
            resultString = Math.Round((Size / 1125899906842624), 2) & " PB"
        ElseIf Size >= 1000000000000 Then
            'TB >= 1000000000 byte, Value / 1099511627776
            resultString = Math.Round((Size / 1099511627776), 2) & " TB"
        ElseIf Size >= 1000000000 Then
            'GB >= 10000000 byte, Value / 1073741824
            resultString = Math.Round((Size / 1073741824), 2) & " GB"
        ElseIf Size >= 1000000 Then
            'MB >= 1000000 byte, Value / 1048576
            resultString = Math.Round((Size / 1048576), 2) & " MB"
        ElseIf Size >= 1000 Then
            'KB >= 1000 byte, Value / 1024
            resultString = Math.Round((Size / 1024), 2) & " KB"
        End If

        Return resultString

    End Function

    Private Sub CheckLoad()

        'Run the sound...

        My.Computer.Audio.Play(My.Resources.Help_sound, AudioPlayMode.Background)

        'Load the "filename" info...

        lFileNameName.Text = IIf(m_FileName.Length >= 50, CutPath(m_FileName, 50), m_FileName)

        gibFileName.Icon = Shell32.GetIcon(m_CleanFileName)

        lName.Text = IO.Path.GetFileName(m_FileName)
        lFileSize.Text = ConvertByteToHighestAvailable(My.Computer.FileSystem.GetFileInfo(m_CleanFileName).Length)

        'Load the "source filename" info...

        lSourceFileNameName.Text = IIf(m_SourceFileName.Length >= 50, CutPath(m_SourceFileName, 50), m_SourceFileName)

        gibSourceFileName.Icon = Shell32.GetIcon(m_SourceFileName)

        lSourceName.Text = IO.Path.GetFileName(m_SourceFileName)
        lSourceFileSize.Text = ConvertByteToHighestAvailable(My.Computer.FileSystem.GetFileInfo(m_SourceFileName).Length)

    End Sub

    Private Sub frmFileAlreadyExists_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckLoad()
    End Sub

    Private Sub rbOverWriteFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOverWriteFile.CheckedChanged

    End Sub

    Private Sub rbRenameFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbRenameFile.CheckedChanged

    End Sub

    Private Sub rbOverWriteIfFileIsLarger_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOverWriteIfFileIsLarger.CheckedChanged

    End Sub

    Private Sub rbContinue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOverWriteIfFileIsSmaller.CheckedChanged

    End Sub

    Private Sub rbJumpOver_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbJumpOver.CheckedChanged

    End Sub

    Private Sub cbAlwaysUseThisOption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAlwaysUseThisOption.CheckedChanged

    End Sub

    Private Sub rbOnlyUseOptionOnCurrentList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOnlyUseOptionOnCurrentList.CheckedChanged

    End Sub

    Private Sub pDown_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pDown.Paint
        e.Graphics.DrawLine(New Pen(Color.FromArgb(160, 160, 160), 1), 0, 0, pDown.Width, 0)
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If rbOverWriteFile.Checked Then
            resultInfo.EnumInfo = FileAlreadyExistsInfo.FileAlreadyExistsInfoEnum.OverWriteFile
        ElseIf rbRenameFile.Checked Then
            resultInfo.EnumInfo = FileAlreadyExistsInfo.FileAlreadyExistsInfoEnum.RenameFile
        ElseIf rbOverWriteIfFileIsLarger.Checked Then
            resultInfo.EnumInfo = FileAlreadyExistsInfo.FileAlreadyExistsInfoEnum.OverWriteIfFileIsLarger
        ElseIf rbOverWriteIfFileIsSmaller.Checked Then
            resultInfo.EnumInfo = FileAlreadyExistsInfo.FileAlreadyExistsInfoEnum.OverWriteIfFileIsSmaller
        ElseIf rbJumpOver.Checked Then
            resultInfo.EnumInfo = FileAlreadyExistsInfo.FileAlreadyExistsInfoEnum.JumpOver
        End If

        resultInfo.AlwaysUseThisOption = cbAlwaysUseThisOption.Checked
        resultInfo.OnlyUseOptionOnCurrentList = cbOnlyUseOptionOnCurrentList.Checked

        Me.Close()

    End Sub
End Class