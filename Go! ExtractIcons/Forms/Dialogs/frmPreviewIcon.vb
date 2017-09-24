Public Class frmPreviewIcon

    Dim m_FileName As String
    Dim m_Icon As Icon

    Public Sub New(ByVal Icon As Icon, ByVal FileName As String)

        InitializeComponent()

        m_Icon = Icon
        m_FileName = FileName

    End Sub

    Private Sub CheckLoad()

        'Set the icon...

        gibPreviewIcon.Icon = m_Icon

        'Set the minimumsize and the size...

        If Not m_Icon.Width + 16 < 221 Then
            Me.MinimumSize = New Size(m_Icon.Width + 16, m_Icon.Height + 67)
        Else
            Me.MinimumSize = New Size(221, m_Icon.Height + 67)
        End If

        Me.Size = Me.MinimumSize

    End Sub

    Private Sub frmPreviewIcon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckLoad()
    End Sub

    Private Sub pDown_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pDown.Paint
        e.Graphics.DrawLine(New Pen(Color.FromArgb(160, 160, 160), 1), 0, 0, pDown.Width, 0)
    End Sub

    Private Sub btnSaveIconsTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveIconsTo.Click

        Dim IList As New List(Of Icon)
        IList.Add(m_Icon)

        Dim NList As New List(Of String)
        NList.Add(IO.Path.GetFileName(m_FileName))

        Dim FNList As New List(Of String)
        FNList.Add(m_FileName)

        Dim Dialog As New frmSaveIcons(IList, NList, FNList, NList)

        Dialog.ShowDialog()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class