Public Class frmCheckForUpdates

    Dim ClockIndex As Integer = 1

    Private Function GetVersion() As String

        Dim ftp As System.Net.FtpWebRequest = System.Net.FtpWebRequest.Create("ftp://ftp.govisualteam.comoj.com/public_html/eiversion.txt")

        ftp.Credentials = New System.Net.NetworkCredential("a4020624", "Jonas12")
        ftp.KeepAlive = False
        ftp.UseBinary = True
        ftp.Method = System.Net.WebRequestMethods.Ftp.DownloadFile

        Using response As System.Net.FtpWebResponse = ftp.GetResponse
            Using datastream As IO.Stream = response.GetResponseStream
                Using sr As New IO.StreamReader(datastream)
                    Return sr.ReadToEnd()
                    sr.Close()
                End Using
                datastream.Close()
            End Using
            response.Close()
        End Using

    End Function

    Private Sub CheckForUpdates()

        ClockTimer.Start()

        Dim StreamReader As IO.StreamReader = Nothing
        Dim NewVer As String = GetVersion()
        Dim CurrentVer As String = My.Application.Info.Version.ToString

        If Not CurrentVer = NewVer Then
            StatusLabel.Font = New Font(StatusLabel.Font, FontStyle.Bold)
            StatusLabel.Text = "Ny version tilgjengelig! (" & NewVer & ")"
        Else
            StatusLabel.Font = New Font(StatusLabel.Font, FontStyle.Regular)
            StatusLabel.Text = "Du har den nyeste versionen (" & NewVer & ")"
        End If

        ClockTimer.Stop()

        ClockBox.Image = My.Resources.UpdateVersionSuccesfullyLoaded

    End Sub

    Private Sub ClockTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClockTimer.Tick
        If ClockIndex = 1 Then
            ClockIndex = 2
            ClockBox.Image = My.Resources.Clock_2
        ElseIf ClockIndex = 2 Then
            ClockIndex = 3
            ClockBox.Image = My.Resources.Clock_3
        ElseIf ClockIndex = 3 Then
            ClockIndex = 4
            ClockBox.Image = My.Resources.Clock_4
        ElseIf ClockIndex = 4 Then
            ClockIndex = 5
            ClockBox.Image = My.Resources.Clock_5
        ElseIf ClockIndex = 5 Then
            ClockIndex = 6
            ClockBox.Image = My.Resources.Clock_6
        ElseIf ClockIndex = 6 Then
            ClockIndex = 7
            ClockBox.Image = My.Resources.Clock_7
        ElseIf ClockIndex = 7 Then
            ClockIndex = 8
            ClockBox.Image = My.Resources.Clock_8
        ElseIf ClockIndex = 8 Then
            ClockIndex = 9
            ClockBox.Image = My.Resources.Clock_8
        ElseIf ClockIndex = 9 Then
            ClockIndex = 10
            ClockBox.Image = My.Resources.Clock_10
        ElseIf ClockIndex = 10 Then
            ClockIndex = 11
            ClockBox.Image = My.Resources.Clock_11
        ElseIf ClockIndex = 11 Then
            ClockIndex = 12
            ClockBox.Image = My.Resources.Clock_12
        ElseIf ClockIndex = 12 Then
            ClockIndex = 13
            ClockBox.Image = My.Resources.Clock_13
        ElseIf ClockIndex = 13 Then
            ClockIndex = 14
            ClockBox.Image = My.Resources.Clock_14
        ElseIf ClockIndex = 14 Then
            ClockIndex = 15
            ClockBox.Image = My.Resources.Clock_15
        ElseIf ClockIndex = 15 Then
            ClockIndex = 16
            ClockBox.Image = My.Resources.Clock_16
        ElseIf ClockIndex = 16 Then
            ClockIndex = 1
            ClockBox.Image = My.Resources.Clock_1
        End If
    End Sub

    Private Sub frmCheckForUpdates_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CheckForUpdates()

    End Sub

    Private Sub DownPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DownPanel.Paint

        e.Graphics.DrawLine(New Pen(Color.FromArgb(160, 160, 160), 1), 0, 0, DownPanel.Width, 0)

    End Sub

    Private Sub DownloadUpdateBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadUpdateBtn.Click

    End Sub
End Class