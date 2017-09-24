<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCheckForUpdates
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCheckForUpdates))
        Me.ClockTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ClockBox = New System.Windows.Forms.PictureBox()
        Me.StatusLabelBack = New System.Windows.Forms.Label()
        Me.DownPanel = New System.Windows.Forms.Panel()
        Me.DownloadUpdateBtn = New System.Windows.Forms.Button()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.StatusLabel = New System.Windows.Forms.Label()
        CType(Me.ClockBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DownPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'ClockTimer
        '
        Me.ClockTimer.Interval = 50
        '
        'ClockBox
        '
        Me.ClockBox.ErrorImage = Nothing
        Me.ClockBox.Image = Global.Go__ExtractIcons.My.Resources.Resources.Clock_1
        Me.ClockBox.InitialImage = Nothing
        Me.ClockBox.Location = New System.Drawing.Point(12, 12)
        Me.ClockBox.Name = "ClockBox"
        Me.ClockBox.Size = New System.Drawing.Size(16, 16)
        Me.ClockBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ClockBox.TabIndex = 3
        Me.ClockBox.TabStop = False
        '
        'StatusLabelBack
        '
        Me.StatusLabelBack.AutoSize = True
        Me.StatusLabelBack.Location = New System.Drawing.Point(34, 13)
        Me.StatusLabelBack.Name = "StatusLabelBack"
        Me.StatusLabelBack.Size = New System.Drawing.Size(42, 15)
        Me.StatusLabelBack.TabIndex = 2
        Me.StatusLabelBack.Text = "Status:"
        '
        'DownPanel
        '
        Me.DownPanel.Controls.Add(Me.DownloadUpdateBtn)
        Me.DownPanel.Controls.Add(Me.ProgressBar)
        Me.DownPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DownPanel.Location = New System.Drawing.Point(0, 41)
        Me.DownPanel.Name = "DownPanel"
        Me.DownPanel.Size = New System.Drawing.Size(284, 31)
        Me.DownPanel.TabIndex = 4
        '
        'DownloadUpdateBtn
        '
        Me.DownloadUpdateBtn.Enabled = False
        Me.DownloadUpdateBtn.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DownloadUpdateBtn.Location = New System.Drawing.Point(204, 4)
        Me.DownloadUpdateBtn.Name = "DownloadUpdateBtn"
        Me.DownloadUpdateBtn.Size = New System.Drawing.Size(75, 23)
        Me.DownloadUpdateBtn.TabIndex = 1
        Me.DownloadUpdateBtn.Text = "Last ned"
        Me.DownloadUpdateBtn.UseVisualStyleBackColor = True
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(6, 7)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(192, 18)
        Me.ProgressBar.TabIndex = 0
        '
        'StatusLabel
        '
        Me.StatusLabel.AutoSize = True
        Me.StatusLabel.Location = New System.Drawing.Point(72, 13)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(169, 15)
        Me.StatusLabel.TabIndex = 5
        Me.StatusLabel.Text = "Ser etter nyere oppdateringer..."
        '
        'frmCheckForUpdates
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(284, 72)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.DownPanel)
        Me.Controls.Add(Me.ClockBox)
        Me.Controls.Add(Me.StatusLabelBack)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCheckForUpdates"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Se etter oppdateringer..."
        CType(Me.ClockBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DownPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ClockTimer As System.Windows.Forms.Timer
    Friend WithEvents ClockBox As System.Windows.Forms.PictureBox
    Friend WithEvents StatusLabelBack As System.Windows.Forms.Label
    Friend WithEvents DownPanel As System.Windows.Forms.Panel
    Friend WithEvents DownloadUpdateBtn As System.Windows.Forms.Button
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
End Class
