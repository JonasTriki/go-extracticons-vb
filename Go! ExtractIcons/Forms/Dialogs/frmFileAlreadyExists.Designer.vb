<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFileAlreadyExists
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFileAlreadyExists))
        Me.lFileName = New System.Windows.Forms.Label()
        Me.lFileNameName = New System.Windows.Forms.Label()
        Me.lPleaseChooseOneOfTheOptions = New System.Windows.Forms.Label()
        Me.lSourceFileNameName = New System.Windows.Forms.Label()
        Me.lSourceFileName = New System.Windows.Forms.Label()
        Me.lName = New System.Windows.Forms.Label()
        Me.lFileSize = New System.Windows.Forms.Label()
        Me.lSourceFileSize = New System.Windows.Forms.Label()
        Me.lSourceName = New System.Windows.Forms.Label()
        Me.rbOverWriteFile = New System.Windows.Forms.RadioButton()
        Me.rbRenameFile = New System.Windows.Forms.RadioButton()
        Me.rbOverWriteIfFileIsSmaller = New System.Windows.Forms.RadioButton()
        Me.rbOverWriteIfFileIsLarger = New System.Windows.Forms.RadioButton()
        Me.rbJumpOver = New System.Windows.Forms.RadioButton()
        Me.cbAlwaysUseThisOption = New System.Windows.Forms.CheckBox()
        Me.cbOnlyUseOptionOnCurrentList = New System.Windows.Forms.CheckBox()
        Me.pDown = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.ggbOptions = New Go__ExtractIcons.GoGroupBox()
        Me.gibSourceFileName = New Go__ExtractIcons.GoIconBox()
        Me.gibFileName = New Go__ExtractIcons.GoIconBox()
        Me.pDown.SuspendLayout()
        Me.SuspendLayout()
        '
        'lFileName
        '
        Me.lFileName.AutoSize = True
        Me.lFileName.Location = New System.Drawing.Point(12, 33)
        Me.lFileName.Name = "lFileName"
        Me.lFileName.Size = New System.Drawing.Size(48, 15)
        Me.lFileName.TabIndex = 1
        Me.lFileName.Text = "Filnavn:"
        '
        'lFileNameName
        '
        Me.lFileNameName.AutoSize = True
        Me.lFileNameName.Location = New System.Drawing.Point(12, 54)
        Me.lFileNameName.Name = "lFileNameName"
        Me.lFileNameName.Size = New System.Drawing.Size(12, 15)
        Me.lFileNameName.TabIndex = 2
        Me.lFileNameName.Text = "?"
        '
        'lPleaseChooseOneOfTheOptions
        '
        Me.lPleaseChooseOneOfTheOptions.AutoSize = True
        Me.lPleaseChooseOneOfTheOptions.Location = New System.Drawing.Point(12, 9)
        Me.lPleaseChooseOneOfTheOptions.Name = "lPleaseChooseOneOfTheOptions"
        Me.lPleaseChooseOneOfTheOptions.Size = New System.Drawing.Size(176, 15)
        Me.lPleaseChooseOneOfTheOptions.TabIndex = 3
        Me.lPleaseChooseOneOfTheOptions.Text = "Venligst velg et av alternativene:"
        '
        'lSourceFileNameName
        '
        Me.lSourceFileNameName.AutoSize = True
        Me.lSourceFileNameName.Location = New System.Drawing.Point(12, 136)
        Me.lSourceFileNameName.Name = "lSourceFileNameName"
        Me.lSourceFileNameName.Size = New System.Drawing.Size(12, 15)
        Me.lSourceFileNameName.TabIndex = 6
        Me.lSourceFileNameName.Text = "?"
        '
        'lSourceFileName
        '
        Me.lSourceFileName.AutoSize = True
        Me.lSourceFileName.Location = New System.Drawing.Point(12, 115)
        Me.lSourceFileName.Name = "lSourceFileName"
        Me.lSourceFileName.Size = New System.Drawing.Size(66, 15)
        Me.lSourceFileName.TabIndex = 5
        Me.lSourceFileName.Text = "Målfilnavn:"
        '
        'lName
        '
        Me.lName.AutoSize = True
        Me.lName.Location = New System.Drawing.Point(53, 74)
        Me.lName.Name = "lName"
        Me.lName.Size = New System.Drawing.Size(38, 15)
        Me.lName.TabIndex = 8
        Me.lName.Text = "Navn:"
        '
        'lFileSize
        '
        Me.lFileSize.AutoSize = True
        Me.lFileSize.Location = New System.Drawing.Point(53, 91)
        Me.lFileSize.Name = "lFileSize"
        Me.lFileSize.Size = New System.Drawing.Size(55, 15)
        Me.lFileSize.TabIndex = 9
        Me.lFileSize.Text = "Størrelse:"
        '
        'lSourceFileSize
        '
        Me.lSourceFileSize.AutoSize = True
        Me.lSourceFileSize.Location = New System.Drawing.Point(53, 173)
        Me.lSourceFileSize.Name = "lSourceFileSize"
        Me.lSourceFileSize.Size = New System.Drawing.Size(55, 15)
        Me.lSourceFileSize.TabIndex = 11
        Me.lSourceFileSize.Text = "Størrelse:"
        '
        'lSourceName
        '
        Me.lSourceName.AutoSize = True
        Me.lSourceName.Location = New System.Drawing.Point(53, 156)
        Me.lSourceName.Name = "lSourceName"
        Me.lSourceName.Size = New System.Drawing.Size(38, 15)
        Me.lSourceName.TabIndex = 10
        Me.lSourceName.Text = "Navn:"
        '
        'rbOverWriteFile
        '
        Me.rbOverWriteFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbOverWriteFile.AutoSize = True
        Me.rbOverWriteFile.Checked = True
        Me.rbOverWriteFile.Location = New System.Drawing.Point(330, 31)
        Me.rbOverWriteFile.Name = "rbOverWriteFile"
        Me.rbOverWriteFile.Size = New System.Drawing.Size(89, 19)
        Me.rbOverWriteFile.TabIndex = 15
        Me.rbOverWriteFile.TabStop = True
        Me.rbOverWriteFile.Text = "Skriv over fil"
        Me.rbOverWriteFile.UseVisualStyleBackColor = True
        '
        'rbRenameFile
        '
        Me.rbRenameFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbRenameFile.AutoSize = True
        Me.rbRenameFile.Location = New System.Drawing.Point(330, 56)
        Me.rbRenameFile.Name = "rbRenameFile"
        Me.rbRenameFile.Size = New System.Drawing.Size(89, 19)
        Me.rbRenameFile.TabIndex = 16
        Me.rbRenameFile.Text = "Gi nytt navn"
        Me.rbRenameFile.UseVisualStyleBackColor = True
        '
        'rbOverWriteIfFileIsSmaller
        '
        Me.rbOverWriteIfFileIsSmaller.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbOverWriteIfFileIsSmaller.AutoSize = True
        Me.rbOverWriteIfFileIsSmaller.Location = New System.Drawing.Point(330, 106)
        Me.rbOverWriteIfFileIsSmaller.Name = "rbOverWriteIfFileIsSmaller"
        Me.rbOverWriteIfFileIsSmaller.Size = New System.Drawing.Size(178, 19)
        Me.rbOverWriteIfFileIsSmaller.TabIndex = 17
        Me.rbOverWriteIfFileIsSmaller.Text = "Overskriv hvis filen er mindre"
        Me.rbOverWriteIfFileIsSmaller.UseVisualStyleBackColor = True
        '
        'rbOverWriteIfFileIsLarger
        '
        Me.rbOverWriteIfFileIsLarger.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbOverWriteIfFileIsLarger.AutoSize = True
        Me.rbOverWriteIfFileIsLarger.Location = New System.Drawing.Point(330, 81)
        Me.rbOverWriteIfFileIsLarger.Name = "rbOverWriteIfFileIsLarger"
        Me.rbOverWriteIfFileIsLarger.Size = New System.Drawing.Size(170, 19)
        Me.rbOverWriteIfFileIsLarger.TabIndex = 18
        Me.rbOverWriteIfFileIsLarger.Text = "Overskriv hvis filen er større"
        Me.rbOverWriteIfFileIsLarger.UseVisualStyleBackColor = True
        '
        'rbJumpOver
        '
        Me.rbJumpOver.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rbJumpOver.AutoSize = True
        Me.rbJumpOver.Location = New System.Drawing.Point(330, 131)
        Me.rbJumpOver.Name = "rbJumpOver"
        Me.rbJumpOver.Size = New System.Drawing.Size(81, 19)
        Me.rbJumpOver.TabIndex = 19
        Me.rbJumpOver.Text = "Hopp over"
        Me.rbJumpOver.UseVisualStyleBackColor = True
        '
        'cbAlwaysUseThisOption
        '
        Me.cbAlwaysUseThisOption.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbAlwaysUseThisOption.AutoSize = True
        Me.cbAlwaysUseThisOption.Location = New System.Drawing.Point(320, 166)
        Me.cbAlwaysUseThisOption.Name = "cbAlwaysUseThisOption"
        Me.cbAlwaysUseThisOption.Size = New System.Drawing.Size(178, 19)
        Me.cbAlwaysUseThisOption.TabIndex = 20
        Me.cbAlwaysUseThisOption.Text = "Bruk alltid denne handlingen"
        Me.cbAlwaysUseThisOption.UseVisualStyleBackColor = True
        '
        'cbOnlyUseOptionOnCurrentList
        '
        Me.cbOnlyUseOptionOnCurrentList.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbOnlyUseOptionOnCurrentList.AutoSize = True
        Me.cbOnlyUseOptionOnCurrentList.Location = New System.Drawing.Point(320, 191)
        Me.cbOnlyUseOptionOnCurrentList.Name = "cbOnlyUseOptionOnCurrentList"
        Me.cbOnlyUseOptionOnCurrentList.Size = New System.Drawing.Size(170, 19)
        Me.cbOnlyUseOptionOnCurrentList.TabIndex = 21
        Me.cbOnlyUseOptionOnCurrentList.Text = "Bruk bare på nåværende kø"
        Me.cbOnlyUseOptionOnCurrentList.UseVisualStyleBackColor = True
        '
        'pDown
        '
        Me.pDown.Controls.Add(Me.btnOK)
        Me.pDown.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pDown.Location = New System.Drawing.Point(0, 218)
        Me.pDown.Name = "pDown"
        Me.pDown.Size = New System.Drawing.Size(616, 29)
        Me.pDown.TabIndex = 22
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(538, 3)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'ggbOptions
        '
        Me.ggbOptions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ggbOptions.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ggbOptions.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.ggbOptions.BorderSize = 1.0!
        Me.ggbOptions.Location = New System.Drawing.Point(320, 12)
        Me.ggbOptions.Name = "ggbOptions"
        Me.ggbOptions.Size = New System.Drawing.Size(284, 148)
        Me.ggbOptions.TabIndex = 14
        Me.ggbOptions.Title = "Alternativer"
        '
        'gibSourceFileName
        '
        Me.gibSourceFileName.BackColor = System.Drawing.Color.Transparent
        Me.gibSourceFileName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.gibSourceFileName.BorderSize = 1.0!
        Me.gibSourceFileName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gibSourceFileName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.gibSourceFileName.Icon = CType(resources.GetObject("gibSourceFileName.Icon"), System.Drawing.Icon)
        Me.gibSourceFileName.IconStyle = Go__ExtractIcons.GoIconBox.IconDrawingStyle.Center
        Me.gibSourceFileName.Location = New System.Drawing.Point(15, 156)
        Me.gibSourceFileName.Name = "gibSourceFileName"
        Me.gibSourceFileName.ShowBorder = True
        Me.gibSourceFileName.Size = New System.Drawing.Size(32, 32)
        Me.gibSourceFileName.TabIndex = 13
        '
        'gibFileName
        '
        Me.gibFileName.BackColor = System.Drawing.Color.Transparent
        Me.gibFileName.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.gibFileName.BorderSize = 1.0!
        Me.gibFileName.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gibFileName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.gibFileName.Icon = CType(resources.GetObject("gibFileName.Icon"), System.Drawing.Icon)
        Me.gibFileName.IconStyle = Go__ExtractIcons.GoIconBox.IconDrawingStyle.Center
        Me.gibFileName.Location = New System.Drawing.Point(15, 74)
        Me.gibFileName.Name = "gibFileName"
        Me.gibFileName.ShowBorder = True
        Me.gibFileName.Size = New System.Drawing.Size(32, 32)
        Me.gibFileName.TabIndex = 12
        '
        'frmFileAlreadyExists
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(616, 247)
        Me.Controls.Add(Me.pDown)
        Me.Controls.Add(Me.cbOnlyUseOptionOnCurrentList)
        Me.Controls.Add(Me.cbAlwaysUseThisOption)
        Me.Controls.Add(Me.rbJumpOver)
        Me.Controls.Add(Me.rbOverWriteIfFileIsLarger)
        Me.Controls.Add(Me.rbOverWriteIfFileIsSmaller)
        Me.Controls.Add(Me.rbRenameFile)
        Me.Controls.Add(Me.rbOverWriteFile)
        Me.Controls.Add(Me.ggbOptions)
        Me.Controls.Add(Me.gibSourceFileName)
        Me.Controls.Add(Me.gibFileName)
        Me.Controls.Add(Me.lSourceFileSize)
        Me.Controls.Add(Me.lSourceName)
        Me.Controls.Add(Me.lFileSize)
        Me.Controls.Add(Me.lName)
        Me.Controls.Add(Me.lSourceFileNameName)
        Me.Controls.Add(Me.lSourceFileName)
        Me.Controls.Add(Me.lPleaseChooseOneOfTheOptions)
        Me.Controls.Add(Me.lFileNameName)
        Me.Controls.Add(Me.lFileName)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFileAlreadyExists"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Målfilen eksisterer allerede!"
        Me.pDown.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lFileName As System.Windows.Forms.Label
    Friend WithEvents lFileNameName As System.Windows.Forms.Label
    Friend WithEvents lPleaseChooseOneOfTheOptions As System.Windows.Forms.Label
    Friend WithEvents lSourceFileNameName As System.Windows.Forms.Label
    Friend WithEvents lSourceFileName As System.Windows.Forms.Label
    Friend WithEvents lName As System.Windows.Forms.Label
    Friend WithEvents lFileSize As System.Windows.Forms.Label
    Friend WithEvents lSourceFileSize As System.Windows.Forms.Label
    Friend WithEvents lSourceName As System.Windows.Forms.Label
    Friend WithEvents gibFileName As Go__ExtractIcons.GoIconBox
    Friend WithEvents gibSourceFileName As Go__ExtractIcons.GoIconBox
    Friend WithEvents ggbOptions As Go__ExtractIcons.GoGroupBox
    Friend WithEvents rbOverWriteFile As System.Windows.Forms.RadioButton
    Friend WithEvents rbRenameFile As System.Windows.Forms.RadioButton
    Friend WithEvents rbOverWriteIfFileIsSmaller As System.Windows.Forms.RadioButton
    Friend WithEvents rbOverWriteIfFileIsLarger As System.Windows.Forms.RadioButton
    Friend WithEvents rbJumpOver As System.Windows.Forms.RadioButton
    Friend WithEvents cbAlwaysUseThisOption As System.Windows.Forms.CheckBox
    Friend WithEvents cbOnlyUseOptionOnCurrentList As System.Windows.Forms.CheckBox
    Friend WithEvents pDown As System.Windows.Forms.Panel
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
