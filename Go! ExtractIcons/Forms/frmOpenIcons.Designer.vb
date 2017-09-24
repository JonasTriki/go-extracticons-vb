<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpenIcons
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpenIcons))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.StartTabPage = New System.Windows.Forms.TabPage()
        Me.ItemBox = New Go__ExtractIcons.GoTextBox()
        Me.OpenFolderButton = New System.Windows.Forms.Button()
        Me.ProcessInfoPanel = New System.Windows.Forms.Panel()
        Me.ProcessName = New System.Windows.Forms.Label()
        Me.ProcessSize = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProcessListBox = New System.Windows.Forms.ListBox()
        Me.SearchIconsInTheSeletedProcessRadioButton = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ChooseFolderButton = New System.Windows.Forms.Button()
        Me.ChooseFileButton = New System.Windows.Forms.Button()
        Me.SubFoldersCheckBox = New System.Windows.Forms.CheckBox()
        Me.SearchIconsInFilesRadioButton = New System.Windows.Forms.RadioButton()
        Me.SearchButton = New System.Windows.Forms.Button()
        Me.ExitButton = New System.Windows.Forms.Button()
        Me.LoadingLabel = New System.Windows.Forms.Label()
        Me.LoadingTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LoadProcessesAgain = New System.Windows.Forms.LinkLabel()
        Me.CheckButton = New System.Windows.Forms.Timer(Me.components)
        Me.ProcessIconBox = New System.Windows.Forms.PictureBox()
        Me.TabControl1.SuspendLayout()
        Me.StartTabPage.SuspendLayout()
        Me.ProcessInfoPanel.SuspendLayout()
        CType(Me.ProcessIconBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.StartTabPage)
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(546, 232)
        Me.TabControl1.TabIndex = 0
        '
        'StartTabPage
        '
        Me.StartTabPage.Controls.Add(Me.ItemBox)
        Me.StartTabPage.Controls.Add(Me.OpenFolderButton)
        Me.StartTabPage.Controls.Add(Me.ProcessInfoPanel)
        Me.StartTabPage.Controls.Add(Me.ProcessListBox)
        Me.StartTabPage.Controls.Add(Me.SearchIconsInTheSeletedProcessRadioButton)
        Me.StartTabPage.Controls.Add(Me.Panel1)
        Me.StartTabPage.Controls.Add(Me.ChooseFolderButton)
        Me.StartTabPage.Controls.Add(Me.ChooseFileButton)
        Me.StartTabPage.Controls.Add(Me.SubFoldersCheckBox)
        Me.StartTabPage.Controls.Add(Me.SearchIconsInFilesRadioButton)
        Me.StartTabPage.Location = New System.Drawing.Point(4, 24)
        Me.StartTabPage.Name = "StartTabPage"
        Me.StartTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.StartTabPage.Size = New System.Drawing.Size(538, 204)
        Me.StartTabPage.TabIndex = 0
        Me.StartTabPage.Text = "Generelt"
        Me.StartTabPage.UseVisualStyleBackColor = True
        '
        'ItemBox
        '
        Me.ItemBox.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ItemBox.ContextMenuStrip = Nothing
        Me.ItemBox.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ItemBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItemBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ItemBox.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.ItemBox.Icon = Global.Go__ExtractIcons.My.Resources.Resources.Document
        Me.ItemBox.Location = New System.Drawing.Point(6, 38)
        Me.ItemBox.MinimumSize = New System.Drawing.Size(0, 22)
        Me.ItemBox.Name = "ItemBox"
        Me.ItemBox.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.ItemBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.ItemBox.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.ItemBox.Size = New System.Drawing.Size(520, 22)
        Me.ItemBox.TabIndex = 41
        '
        'OpenFolderButton
        '
        Me.OpenFolderButton.Image = Global.Go__ExtractIcons.My.Resources.Resources.ClosedFolder
        Me.OpenFolderButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OpenFolderButton.Location = New System.Drawing.Point(394, 6)
        Me.OpenFolderButton.Name = "OpenFolderButton"
        Me.OpenFolderButton.Size = New System.Drawing.Size(133, 27)
        Me.OpenFolderButton.TabIndex = 5
        Me.OpenFolderButton.Text = "Åpne mappe"
        Me.OpenFolderButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.OpenFolderButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.OpenFolderButton.UseVisualStyleBackColor = True
        '
        'ProcessInfoPanel
        '
        Me.ProcessInfoPanel.Controls.Add(Me.ProcessName)
        Me.ProcessInfoPanel.Controls.Add(Me.ProcessSize)
        Me.ProcessInfoPanel.Controls.Add(Me.Label2)
        Me.ProcessInfoPanel.Controls.Add(Me.Label1)
        Me.ProcessInfoPanel.Enabled = False
        Me.ProcessInfoPanel.Location = New System.Drawing.Point(15, 134)
        Me.ProcessInfoPanel.Name = "ProcessInfoPanel"
        Me.ProcessInfoPanel.Size = New System.Drawing.Size(229, 54)
        Me.ProcessInfoPanel.TabIndex = 40
        '
        'ProcessName
        '
        Me.ProcessName.AutoEllipsis = True
        Me.ProcessName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ProcessName.Location = New System.Drawing.Point(100, 1)
        Me.ProcessName.Name = "ProcessName"
        Me.ProcessName.Size = New System.Drawing.Size(126, 15)
        Me.ProcessName.TabIndex = 49
        Me.ProcessName.Text = "Velg et program..."
        '
        'ProcessSize
        '
        Me.ProcessSize.AutoEllipsis = True
        Me.ProcessSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ProcessSize.Location = New System.Drawing.Point(100, 23)
        Me.ProcessSize.Name = "ProcessSize"
        Me.ProcessSize.Size = New System.Drawing.Size(126, 15)
        Me.ProcessSize.TabIndex = 48
        Me.ProcessSize.Text = "Velg et program..."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 15)
        Me.Label2.TabIndex = 47
        Me.Label2.Text = "Størrelse: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 15)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Navn: "
        '
        'ProcessListBox
        '
        Me.ProcessListBox.Enabled = False
        Me.ProcessListBox.FormattingEnabled = True
        Me.ProcessListBox.HorizontalScrollbar = True
        Me.ProcessListBox.ItemHeight = 15
        Me.ProcessListBox.Location = New System.Drawing.Point(248, 109)
        Me.ProcessListBox.Name = "ProcessListBox"
        Me.ProcessListBox.Size = New System.Drawing.Size(279, 79)
        Me.ProcessListBox.Sorted = True
        Me.ProcessListBox.TabIndex = 39
        '
        'SearchIconsInTheSeletedProcessRadioButton
        '
        Me.SearchIconsInTheSeletedProcessRadioButton.AutoSize = True
        Me.SearchIconsInTheSeletedProcessRadioButton.Location = New System.Drawing.Point(6, 109)
        Me.SearchIconsInTheSeletedProcessRadioButton.Name = "SearchIconsInTheSeletedProcessRadioButton"
        Me.SearchIconsInTheSeletedProcessRadioButton.Size = New System.Drawing.Size(229, 19)
        Me.SearchIconsInTheSeletedProcessRadioButton.TabIndex = 38
        Me.SearchIconsInTheSeletedProcessRadioButton.Text = "Søk etter ikoner i den valgte prosessen:"
        Me.SearchIconsInTheSeletedProcessRadioButton.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(3, 99)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(528, 1)
        Me.Panel1.TabIndex = 37
        '
        'ChooseFolderButton
        '
        Me.ChooseFolderButton.Location = New System.Drawing.Point(242, 64)
        Me.ChooseFolderButton.Name = "ChooseFolderButton"
        Me.ChooseFolderButton.Size = New System.Drawing.Size(146, 27)
        Me.ChooseFolderButton.TabIndex = 36
        Me.ChooseFolderButton.Text = "Bla gjennom mapper..."
        Me.ChooseFolderButton.UseVisualStyleBackColor = True
        '
        'ChooseFileButton
        '
        Me.ChooseFileButton.Location = New System.Drawing.Point(394, 64)
        Me.ChooseFileButton.Name = "ChooseFileButton"
        Me.ChooseFileButton.Size = New System.Drawing.Size(133, 27)
        Me.ChooseFileButton.TabIndex = 35
        Me.ChooseFileButton.Text = "Bla gjennom filer..."
        Me.ChooseFileButton.UseVisualStyleBackColor = True
        '
        'SubFoldersCheckBox
        '
        Me.SubFoldersCheckBox.AutoSize = True
        Me.SubFoldersCheckBox.Checked = True
        Me.SubFoldersCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.SubFoldersCheckBox.Location = New System.Drawing.Point(6, 66)
        Me.SubFoldersCheckBox.Name = "SubFoldersCheckBox"
        Me.SubFoldersCheckBox.Size = New System.Drawing.Size(126, 19)
        Me.SubFoldersCheckBox.TabIndex = 34
        Me.SubFoldersCheckBox.Text = "Søk i undermapper"
        Me.SubFoldersCheckBox.UseVisualStyleBackColor = True
        '
        'SearchIconsInFilesRadioButton
        '
        Me.SearchIconsInFilesRadioButton.AutoSize = True
        Me.SearchIconsInFilesRadioButton.Checked = True
        Me.SearchIconsInFilesRadioButton.Location = New System.Drawing.Point(6, 13)
        Me.SearchIconsInFilesRadioButton.Name = "SearchIconsInFilesRadioButton"
        Me.SearchIconsInFilesRadioButton.Size = New System.Drawing.Size(145, 19)
        Me.SearchIconsInFilesRadioButton.TabIndex = 0
        Me.SearchIconsInFilesRadioButton.TabStop = True
        Me.SearchIconsInFilesRadioButton.Text = "Søk etter ikoner i filer..."
        Me.SearchIconsInFilesRadioButton.UseVisualStyleBackColor = True
        '
        'SearchButton
        '
        Me.SearchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SearchButton.Location = New System.Drawing.Point(299, 250)
        Me.SearchButton.Name = "SearchButton"
        Me.SearchButton.Size = New System.Drawing.Size(168, 27)
        Me.SearchButton.TabIndex = 1
        Me.SearchButton.Text = "Søk etter ikoner..."
        Me.SearchButton.UseVisualStyleBackColor = True
        '
        'ExitButton
        '
        Me.ExitButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitButton.Location = New System.Drawing.Point(473, 250)
        Me.ExitButton.Name = "ExitButton"
        Me.ExitButton.Size = New System.Drawing.Size(83, 27)
        Me.ExitButton.TabIndex = 2
        Me.ExitButton.Text = "Lukk"
        Me.ExitButton.UseVisualStyleBackColor = True
        '
        'LoadingLabel
        '
        Me.LoadingLabel.AutoSize = True
        Me.LoadingLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LoadingLabel.Location = New System.Drawing.Point(22, 219)
        Me.LoadingLabel.Name = "LoadingLabel"
        Me.LoadingLabel.Size = New System.Drawing.Size(110, 15)
        Me.LoadingLabel.TabIndex = 3
        Me.LoadingLabel.Text = "Laster inn prosesser"
        Me.LoadingLabel.Visible = False
        '
        'LoadingTimer
        '
        Me.LoadingTimer.Interval = 1000
        '
        'LoadProcessesAgain
        '
        Me.LoadProcessesAgain.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.LoadProcessesAgain.AutoSize = True
        Me.LoadProcessesAgain.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LoadProcessesAgain.LinkColor = System.Drawing.Color.Black
        Me.LoadProcessesAgain.Location = New System.Drawing.Point(22, 219)
        Me.LoadProcessesAgain.Name = "LoadProcessesAgain"
        Me.LoadProcessesAgain.Size = New System.Drawing.Size(149, 15)
        Me.LoadProcessesAgain.TabIndex = 4
        Me.LoadProcessesAgain.TabStop = True
        Me.LoadProcessesAgain.Text = "Last inn prosesser på nytt..."
        Me.LoadProcessesAgain.Visible = False
        Me.LoadProcessesAgain.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(74, Byte), Integer))
        '
        'CheckButton
        '
        Me.CheckButton.Enabled = True
        Me.CheckButton.Interval = 1
        '
        'ProcessIconBox
        '
        Me.ProcessIconBox.ErrorImage = Nothing
        Me.ProcessIconBox.Image = Global.Go__ExtractIcons.My.Resources.Resources.Program_32
        Me.ProcessIconBox.InitialImage = Nothing
        Me.ProcessIconBox.Location = New System.Drawing.Point(21, 170)
        Me.ProcessIconBox.Name = "ProcessIconBox"
        Me.ProcessIconBox.Size = New System.Drawing.Size(47, 45)
        Me.ProcessIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.ProcessIconBox.TabIndex = 41
        Me.ProcessIconBox.TabStop = False
        '
        'frmOpenIcons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(570, 289)
        Me.Controls.Add(Me.ProcessIconBox)
        Me.Controls.Add(Me.LoadProcessesAgain)
        Me.Controls.Add(Me.LoadingLabel)
        Me.Controls.Add(Me.ExitButton)
        Me.Controls.Add(Me.SearchButton)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(576, 28)
        Me.Name = "frmOpenIcons"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Søk etter ikon..."
        Me.TabControl1.ResumeLayout(False)
        Me.StartTabPage.ResumeLayout(False)
        Me.StartTabPage.PerformLayout()
        Me.ProcessInfoPanel.ResumeLayout(False)
        Me.ProcessInfoPanel.PerformLayout()
        CType(Me.ProcessIconBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents StartTabPage As System.Windows.Forms.TabPage
    Friend WithEvents SearchButton As System.Windows.Forms.Button
    Friend WithEvents ExitButton As System.Windows.Forms.Button
    Friend WithEvents SearchIconsInFilesRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents SubFoldersCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ChooseFolderButton As System.Windows.Forms.Button
    Friend WithEvents ChooseFileButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SearchIconsInTheSeletedProcessRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents ProcessInfoPanel As System.Windows.Forms.Panel
    Friend WithEvents ProcessName As System.Windows.Forms.Label
    Friend WithEvents ProcessSize As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProcessListBox As System.Windows.Forms.ListBox
    Friend WithEvents LoadingLabel As System.Windows.Forms.Label
    Friend WithEvents LoadingTimer As System.Windows.Forms.Timer
    Friend WithEvents LoadProcessesAgain As System.Windows.Forms.LinkLabel
    Friend WithEvents OpenFolderButton As System.Windows.Forms.Button
    Friend WithEvents CheckButton As System.Windows.Forms.Timer
    Friend WithEvents ProcessIconBox As System.Windows.Forms.PictureBox
    Friend WithEvents ItemBox As Go__ExtractIcons.GoTextBox
End Class
