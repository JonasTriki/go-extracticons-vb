Public Class frmRenameName

    Public resultString As String

    Dim CanSetIsOK As Boolean = True
    Public IsOK As Boolean = False

    Dim m_FileName As String
    Dim m_FileNameExtenstion As String
    Dim m_FileNameFullFolder As String

    Public Sub New(ByVal fileName As String)

        InitializeComponent()

        m_FileName = fileName

    End Sub

    Private Sub CheckLoad()

        'Get the filename info...

        m_FileNameExtenstion = IO.Path.GetExtension(m_FileName)
        m_FileNameFullFolder = My.Computer.FileSystem.GetFileInfo(m_FileName).Directory.FullName

        'Set the text and the icon...

        txtName.Text = IO.Path.GetFileNameWithoutExtension(m_FileName)
        txtName.Icon = Shell32.GetIcon(m_FileName).ToBitmap
        txtName.Select()

    End Sub

    Private Sub frmRenameName_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckLoad()
    End Sub

    Private Sub frmRenameName_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If CanSetIsOK Then
            IsOK = False
        End If
    End Sub

    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtName.TextChanged
        btnOK.Enabled = txtName.Text <> IO.Path.GetFileNameWithoutExtension(m_FileName) Or txtName.Text <> ""
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        CanSetIsOK = False
        IsOK = True

        resultString = m_FileNameFullFolder & "\" & txtName.Text & m_FileNameExtenstion

        Me.Close()

    End Sub
End Class