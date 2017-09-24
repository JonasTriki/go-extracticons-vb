<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchIconsInWebsite
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchIconsInWebsite))
        Me.FaviconImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.lvResults = New System.Windows.Forms.ListView()
        Me.ColumnIconName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnIconSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnIconURL = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnIconLine = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.llResults = New System.Windows.Forms.Label()
        Me.pLine = New System.Windows.Forms.Panel()
        Me.btnSearchIcons = New System.Windows.Forms.Button()
        Me.btnOpenURL = New System.Windows.Forms.Button()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.llStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.llSpring = New System.Windows.Forms.ToolStripStatusLabel()
        Me.llInternetConection = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnSaveIcons = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnPoperitiesForIcon = New System.Windows.Forms.Button()
        Me.CheckBtns = New System.Windows.Forms.Timer(Me.components)
        Me.rbSearchAfterIconsInThisURL = New System.Windows.Forms.RadioButton()
        Me.rbSearchAfterIconsInHTMLDocumentFile = New System.Windows.Forms.RadioButton()
        Me.pLineTop = New System.Windows.Forms.Panel()
        Me.btnBrowseFiles = New System.Windows.Forms.Button()
        Me.btnOpenFile = New System.Windows.Forms.Button()
        Me.txtHTMLDoc = New Go__ExtractIcons.GoTextBox()
        Me.txtURL = New Go__ExtractIcons.GoTextBox()
        Me.StatusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'FaviconImageList
        '
        Me.FaviconImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.FaviconImageList.ImageSize = New System.Drawing.Size(16, 16)
        Me.FaviconImageList.TransparentColor = System.Drawing.Color.Transparent
        '
        'lvResults
        '
        Me.lvResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvResults.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnIconName, Me.ColumnIconSize, Me.ColumnIconURL, Me.ColumnIconLine})
        Me.lvResults.FullRowSelect = True
        Me.lvResults.GridLines = True
        Me.lvResults.HideSelection = False
        Me.lvResults.Location = New System.Drawing.Point(17, 172)
        Me.lvResults.MultiSelect = False
        Me.lvResults.Name = "lvResults"
        Me.lvResults.Size = New System.Drawing.Size(665, 182)
        Me.lvResults.SmallImageList = Me.FaviconImageList
        Me.lvResults.TabIndex = 66
        Me.lvResults.UseCompatibleStateImageBehavior = False
        Me.lvResults.View = System.Windows.Forms.View.Details
        '
        'ColumnIconName
        '
        Me.ColumnIconName.Text = "Navn"
        Me.ColumnIconName.Width = 124
        '
        'ColumnIconSize
        '
        Me.ColumnIconSize.Text = "Størrelse"
        Me.ColumnIconSize.Width = 102
        '
        'ColumnIconURL
        '
        Me.ColumnIconURL.Text = "Nettadresse"
        Me.ColumnIconURL.Width = 422
        '
        'ColumnIconLine
        '
        Me.ColumnIconLine.Text = "Kommando linje"
        Me.ColumnIconLine.Width = 308
        '
        'llResults
        '
        Me.llResults.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llResults.AutoSize = True
        Me.llResults.Location = New System.Drawing.Point(13, 145)
        Me.llResults.Name = "llResults"
        Me.llResults.Size = New System.Drawing.Size(62, 15)
        Me.llResults.TabIndex = 76
        Me.llResults.Text = "Resultater:"
        '
        'pLine
        '
        Me.pLine.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.pLine.Location = New System.Drawing.Point(-3, 152)
        Me.pLine.Name = "pLine"
        Me.pLine.Size = New System.Drawing.Size(700, 1)
        Me.pLine.TabIndex = 74
        '
        'btnSearchIcons
        '
        Me.btnSearchIcons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearchIcons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearchIcons.Location = New System.Drawing.Point(548, 139)
        Me.btnSearchIcons.Name = "btnSearchIcons"
        Me.btnSearchIcons.Size = New System.Drawing.Size(133, 27)
        Me.btnSearchIcons.TabIndex = 75
        Me.btnSearchIcons.Text = "Søk etter ikoner..."
        Me.btnSearchIcons.UseVisualStyleBackColor = True
        '
        'btnOpenURL
        '
        Me.btnOpenURL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOpenURL.Image = Global.Go__ExtractIcons.My.Resources.Resources.Document
        Me.btnOpenURL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOpenURL.Location = New System.Drawing.Point(548, 80)
        Me.btnOpenURL.Name = "btnOpenURL"
        Me.btnOpenURL.Size = New System.Drawing.Size(134, 27)
        Me.btnOpenURL.TabIndex = 72
        Me.btnOpenURL.Text = "Åpne nettside"
        Me.btnOpenURL.UseVisualStyleBackColor = True
        '
        'StatusBar
        '
        Me.StatusBar.BackgroundImage = CType(resources.GetObject("StatusBar.BackgroundImage"), System.Drawing.Image)
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.llStatus, Me.llSpring, Me.llInternetConection})
        Me.StatusBar.Location = New System.Drawing.Point(0, 395)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(694, 22)
        Me.StatusBar.TabIndex = 77
        Me.StatusBar.Text = "StatusStrip1"
        '
        'llStatus
        '
        Me.llStatus.Name = "llStatus"
        Me.llStatus.Size = New System.Drawing.Size(116, 17)
        Me.llStatus.Text = "Ingen nettside søkt..."
        '
        'llSpring
        '
        Me.llSpring.Name = "llSpring"
        Me.llSpring.Size = New System.Drawing.Size(417, 17)
        Me.llSpring.Spring = True
        '
        'llInternetConection
        '
        Me.llInternetConection.Image = Global.Go__ExtractIcons.My.Resources.Resources.InternetConOff
        Me.llInternetConection.Name = "llInternetConection"
        Me.llInternetConection.Size = New System.Drawing.Size(146, 17)
        Me.llInternetConection.Text = "Internet forbindelse: Av"
        '
        'btnSaveIcons
        '
        Me.btnSaveIcons.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveIcons.Enabled = False
        Me.btnSaveIcons.Location = New System.Drawing.Point(460, 360)
        Me.btnSaveIcons.Name = "btnSaveIcons"
        Me.btnSaveIcons.Size = New System.Drawing.Size(158, 23)
        Me.btnSaveIcons.TabIndex = 81
        Me.btnSaveIcons.Text = "Lagre ikoner til..."
        Me.btnSaveIcons.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(624, 360)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(58, 23)
        Me.btnClose.TabIndex = 80
        Me.btnClose.Text = "Lukk"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnPoperitiesForIcon
        '
        Me.btnPoperitiesForIcon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPoperitiesForIcon.Enabled = False
        Me.btnPoperitiesForIcon.Location = New System.Drawing.Point(16, 360)
        Me.btnPoperitiesForIcon.Name = "btnPoperitiesForIcon"
        Me.btnPoperitiesForIcon.Size = New System.Drawing.Size(158, 23)
        Me.btnPoperitiesForIcon.TabIndex = 82
        Me.btnPoperitiesForIcon.Text = "Egenskaper for ikon..."
        Me.btnPoperitiesForIcon.UseVisualStyleBackColor = True
        '
        'CheckBtns
        '
        Me.CheckBtns.Enabled = True
        Me.CheckBtns.Interval = 1
        '
        'rbSearchAfterIconsInThisURL
        '
        Me.rbSearchAfterIconsInThisURL.AutoSize = True
        Me.rbSearchAfterIconsInThisURL.Location = New System.Drawing.Point(13, 86)
        Me.rbSearchAfterIconsInThisURL.Name = "rbSearchAfterIconsInThisURL"
        Me.rbSearchAfterIconsInThisURL.Size = New System.Drawing.Size(204, 19)
        Me.rbSearchAfterIconsInThisURL.TabIndex = 83
        Me.rbSearchAfterIconsInThisURL.Text = "Søk etter ikoner i denne nettsiden:"
        Me.rbSearchAfterIconsInThisURL.UseVisualStyleBackColor = True
        '
        'rbSearchAfterIconsInHTMLDocumentFile
        '
        Me.rbSearchAfterIconsInHTMLDocumentFile.AutoSize = True
        Me.rbSearchAfterIconsInHTMLDocumentFile.Checked = True
        Me.rbSearchAfterIconsInHTMLDocumentFile.Location = New System.Drawing.Point(12, 12)
        Me.rbSearchAfterIconsInHTMLDocumentFile.Name = "rbSearchAfterIconsInHTMLDocumentFile"
        Me.rbSearchAfterIconsInHTMLDocumentFile.Size = New System.Drawing.Size(225, 19)
        Me.rbSearchAfterIconsInHTMLDocumentFile.TabIndex = 84
        Me.rbSearchAfterIconsInHTMLDocumentFile.TabStop = True
        Me.rbSearchAfterIconsInHTMLDocumentFile.Text = "Søk etter ikoner i HTML-dokument fil:"
        Me.rbSearchAfterIconsInHTMLDocumentFile.UseVisualStyleBackColor = True
        '
        'pLineTop
        '
        Me.pLineTop.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pLineTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer), CType(CType(161, Byte), Integer))
        Me.pLineTop.Location = New System.Drawing.Point(0, 72)
        Me.pLineTop.Name = "pLineTop"
        Me.pLineTop.Size = New System.Drawing.Size(700, 1)
        Me.pLineTop.TabIndex = 85
        '
        'btnBrowseFiles
        '
        Me.btnBrowseFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseFiles.Location = New System.Drawing.Point(649, 41)
        Me.btnBrowseFiles.Name = "btnBrowseFiles"
        Me.btnBrowseFiles.Size = New System.Drawing.Size(32, 24)
        Me.btnBrowseFiles.TabIndex = 93
        Me.btnBrowseFiles.Text = "..."
        Me.btnBrowseFiles.UseVisualStyleBackColor = True
        '
        'btnOpenFile
        '
        Me.btnOpenFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOpenFile.Image = Global.Go__ExtractIcons.My.Resources.Resources.Document
        Me.btnOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOpenFile.Location = New System.Drawing.Point(548, 8)
        Me.btnOpenFile.Name = "btnOpenFile"
        Me.btnOpenFile.Size = New System.Drawing.Size(134, 27)
        Me.btnOpenFile.TabIndex = 94
        Me.btnOpenFile.Text = "Åpne fil"
        Me.btnOpenFile.UseVisualStyleBackColor = True
        '
        'txtHTMLDoc
        '
        Me.txtHTMLDoc.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtHTMLDoc.ContextMenuStrip = Nothing
        Me.txtHTMLDoc.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtHTMLDoc.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHTMLDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtHTMLDoc.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtHTMLDoc.Icon = Global.Go__ExtractIcons.My.Resources.Resources.Document
        Me.txtHTMLDoc.IsReadOnly = True
        Me.txtHTMLDoc.Location = New System.Drawing.Point(16, 42)
        Me.txtHTMLDoc.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtHTMLDoc.Name = "txtHTMLDoc"
        Me.txtHTMLDoc.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtHTMLDoc.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtHTMLDoc.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtHTMLDoc.Size = New System.Drawing.Size(627, 22)
        Me.txtHTMLDoc.TabIndex = 92
        '
        'txtURL
        '
        Me.txtURL.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtURL.ContextMenuStrip = Nothing
        Me.txtURL.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.txtURL.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtURL.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.txtURL.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtURL.Icon = Global.Go__ExtractIcons.My.Resources.Resources.Document
        Me.txtURL.Location = New System.Drawing.Point(16, 112)
        Me.txtURL.MinimumSize = New System.Drawing.Size(0, 22)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.txtURL.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtURL.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.txtURL.Size = New System.Drawing.Size(665, 22)
        Me.txtURL.TabIndex = 91
        '
        'frmSearchIconsInWebsite
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(694, 417)
        Me.Controls.Add(Me.btnOpenFile)
        Me.Controls.Add(Me.btnBrowseFiles)
        Me.Controls.Add(Me.txtHTMLDoc)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.pLineTop)
        Me.Controls.Add(Me.rbSearchAfterIconsInHTMLDocumentFile)
        Me.Controls.Add(Me.rbSearchAfterIconsInThisURL)
        Me.Controls.Add(Me.btnPoperitiesForIcon)
        Me.Controls.Add(Me.btnSaveIcons)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.StatusBar)
        Me.Controls.Add(Me.btnSearchIcons)
        Me.Controls.Add(Me.lvResults)
        Me.Controls.Add(Me.llResults)
        Me.Controls.Add(Me.pLine)
        Me.Controls.Add(Me.btnOpenURL)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSearchIconsInWebsite"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Søk etter ikoner i nettside..."
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FaviconImageList As System.Windows.Forms.ImageList
    Friend WithEvents lvResults As System.Windows.Forms.ListView
    Friend WithEvents ColumnIconName As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnIconSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnIconURL As System.Windows.Forms.ColumnHeader
    Friend WithEvents llResults As System.Windows.Forms.Label
    Friend WithEvents pLine As System.Windows.Forms.Panel
    Friend WithEvents btnSearchIcons As System.Windows.Forms.Button
    Friend WithEvents btnOpenURL As System.Windows.Forms.Button
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents llStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents llSpring As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents llInternetConection As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnSaveIcons As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnPoperitiesForIcon As System.Windows.Forms.Button
    Friend WithEvents CheckBtns As System.Windows.Forms.Timer
    Friend WithEvents ColumnIconLine As System.Windows.Forms.ColumnHeader
    Friend WithEvents rbSearchAfterIconsInThisURL As System.Windows.Forms.RadioButton
    Friend WithEvents rbSearchAfterIconsInHTMLDocumentFile As System.Windows.Forms.RadioButton
    Friend WithEvents pLineTop As System.Windows.Forms.Panel
    Friend WithEvents txtURL As Go__ExtractIcons.GoTextBox
    Friend WithEvents txtHTMLDoc As Go__ExtractIcons.GoTextBox
    Friend WithEvents btnBrowseFiles As System.Windows.Forms.Button
    Friend WithEvents btnOpenFile As System.Windows.Forms.Button
End Class
