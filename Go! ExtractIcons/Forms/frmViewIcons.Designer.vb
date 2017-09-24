<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewIcons
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewIcons))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.StartTabPage = New System.Windows.Forms.TabPage()
        Me.IconColorDepth = New System.Windows.Forms.LinkLabel()
        Me.IconColors = New System.Windows.Forms.Label()
        Me.IColors = New System.Windows.Forms.Label()
        Me.SaveIconsToButton = New System.Windows.Forms.Button()
        Me.CopyIconButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.IconListView = New System.Windows.Forms.ListView()
        Me.IDColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.DimensionsColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColorDepthColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColorsColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SizeColumn = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.IconPreviewLabel = New System.Windows.Forms.Label()
        Me.IColorDepth = New System.Windows.Forms.Label()
        Me.IconDimensions = New System.Windows.Forms.Label()
        Me.IDimensions = New System.Windows.Forms.Label()
        Me.IconSize = New System.Windows.Forms.Label()
        Me.ISize = New System.Windows.Forms.Label()
        Me.IconID = New System.Windows.Forms.Label()
        Me.IID = New System.Windows.Forms.Label()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.IconFileName = New System.Windows.Forms.Label()
        Me.IFileName = New System.Windows.Forms.Label()
        Me.CheckButtons = New System.Windows.Forms.Timer(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.StartTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.StartTabPage)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(531, 414)
        Me.TabControl1.TabIndex = 0
        '
        'StartTabPage
        '
        Me.StartTabPage.Controls.Add(Me.IconColorDepth)
        Me.StartTabPage.Controls.Add(Me.IconColors)
        Me.StartTabPage.Controls.Add(Me.IColors)
        Me.StartTabPage.Controls.Add(Me.SaveIconsToButton)
        Me.StartTabPage.Controls.Add(Me.CopyIconButton)
        Me.StartTabPage.Controls.Add(Me.CloseButton)
        Me.StartTabPage.Controls.Add(Me.IconListView)
        Me.StartTabPage.Controls.Add(Me.IconPreviewLabel)
        Me.StartTabPage.Controls.Add(Me.IColorDepth)
        Me.StartTabPage.Controls.Add(Me.IconDimensions)
        Me.StartTabPage.Controls.Add(Me.IDimensions)
        Me.StartTabPage.Controls.Add(Me.IconSize)
        Me.StartTabPage.Controls.Add(Me.ISize)
        Me.StartTabPage.Controls.Add(Me.IconID)
        Me.StartTabPage.Controls.Add(Me.IID)
        Me.StartTabPage.Controls.Add(Me.IconPanel)
        Me.StartTabPage.Controls.Add(Me.IconFileName)
        Me.StartTabPage.Controls.Add(Me.IFileName)
        Me.StartTabPage.Location = New System.Drawing.Point(4, 24)
        Me.StartTabPage.Name = "StartTabPage"
        Me.StartTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.StartTabPage.Size = New System.Drawing.Size(523, 386)
        Me.StartTabPage.TabIndex = 0
        Me.StartTabPage.Text = "Generelt"
        Me.StartTabPage.UseVisualStyleBackColor = True
        '
        'IconColorDepth
        '
        Me.IconColorDepth.ActiveLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.IconColorDepth.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconColorDepth.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.IconColorDepth.Enabled = False
        Me.IconColorDepth.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.IconColorDepth.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.IconColorDepth.LinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.IconColorDepth.Location = New System.Drawing.Point(181, 117)
        Me.IconColorDepth.Name = "IconColorDepth"
        Me.IconColorDepth.Size = New System.Drawing.Size(150, 15)
        Me.IconColorDepth.TabIndex = 17
        Me.IconColorDepth.TabStop = True
        Me.IconColorDepth.Text = "Venligst velg ett ikon..."
        Me.IconColorDepth.VisitedLinkColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        '
        'IconColors
        '
        Me.IconColors.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconColors.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.IconColors.Location = New System.Drawing.Point(181, 143)
        Me.IconColors.Name = "IconColors"
        Me.IconColors.Size = New System.Drawing.Size(150, 15)
        Me.IconColors.TabIndex = 16
        Me.IconColors.Text = "Venligst velg ett ikon..."
        '
        'IColors
        '
        Me.IColors.AutoSize = True
        Me.IColors.Location = New System.Drawing.Point(12, 143)
        Me.IColors.Name = "IColors"
        Me.IColors.Size = New System.Drawing.Size(78, 15)
        Me.IColors.TabIndex = 15
        Me.IColors.Text = "Antall farger: "
        '
        'SaveIconsToButton
        '
        Me.SaveIconsToButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveIconsToButton.Location = New System.Drawing.Point(275, 355)
        Me.SaveIconsToButton.Name = "SaveIconsToButton"
        Me.SaveIconsToButton.Size = New System.Drawing.Size(158, 25)
        Me.SaveIconsToButton.TabIndex = 14
        Me.SaveIconsToButton.Text = "Lagre ikon(er) til..."
        Me.SaveIconsToButton.UseVisualStyleBackColor = True
        '
        'CopyIconButton
        '
        Me.CopyIconButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CopyIconButton.Location = New System.Drawing.Point(15, 355)
        Me.CopyIconButton.Name = "CopyIconButton"
        Me.CopyIconButton.Size = New System.Drawing.Size(97, 25)
        Me.CopyIconButton.TabIndex = 13
        Me.CopyIconButton.Text = "Kopier ikon"
        Me.CopyIconButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.Location = New System.Drawing.Point(439, 355)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 25)
        Me.CloseButton.TabIndex = 12
        Me.CloseButton.Text = "Lukk"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'IconListView
        '
        Me.IconListView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconListView.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.IDColumn, Me.DimensionsColumn, Me.ColorDepthColumn, Me.ColorsColumn, Me.SizeColumn})
        Me.IconListView.FullRowSelect = True
        Me.IconListView.Location = New System.Drawing.Point(15, 172)
        Me.IconListView.Name = "IconListView"
        Me.IconListView.Size = New System.Drawing.Size(499, 177)
        Me.IconListView.TabIndex = 1
        Me.IconListView.UseCompatibleStateImageBehavior = False
        Me.IconListView.View = System.Windows.Forms.View.Details
        '
        'IDColumn
        '
        Me.IDColumn.Text = "ID"
        Me.IDColumn.Width = 89
        '
        'DimensionsColumn
        '
        Me.DimensionsColumn.Text = "Dimensjoner"
        Me.DimensionsColumn.Width = 89
        '
        'ColorDepthColumn
        '
        Me.ColorDepthColumn.Text = "Fargedybde"
        Me.ColorDepthColumn.Width = 89
        '
        'ColorsColumn
        '
        Me.ColorsColumn.Text = "Antall farger"
        Me.ColorsColumn.Width = 119
        '
        'SizeColumn
        '
        Me.SizeColumn.Text = "Størrelse"
        Me.SizeColumn.Width = 89
        '
        'IconPreviewLabel
        '
        Me.IconPreviewLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPreviewLabel.AutoEllipsis = True
        Me.IconPreviewLabel.Location = New System.Drawing.Point(340, 8)
        Me.IconPreviewLabel.Name = "IconPreviewLabel"
        Me.IconPreviewLabel.Size = New System.Drawing.Size(174, 15)
        Me.IconPreviewLabel.TabIndex = 11
        Me.IconPreviewLabel.Text = "Forhåndsvisning: "
        Me.IconPreviewLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'IColorDepth
        '
        Me.IColorDepth.AutoSize = True
        Me.IColorDepth.Location = New System.Drawing.Point(12, 116)
        Me.IColorDepth.Name = "IColorDepth"
        Me.IColorDepth.Size = New System.Drawing.Size(75, 15)
        Me.IColorDepth.TabIndex = 9
        Me.IColorDepth.Text = "Fargedybde: "
        '
        'IconDimensions
        '
        Me.IconDimensions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconDimensions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.IconDimensions.Location = New System.Drawing.Point(181, 90)
        Me.IconDimensions.Name = "IconDimensions"
        Me.IconDimensions.Size = New System.Drawing.Size(150, 15)
        Me.IconDimensions.TabIndex = 8
        Me.IconDimensions.Text = "Venligst velg ett ikon..."
        '
        'IDimensions
        '
        Me.IDimensions.AutoSize = True
        Me.IDimensions.Location = New System.Drawing.Point(12, 90)
        Me.IDimensions.Name = "IDimensions"
        Me.IDimensions.Size = New System.Drawing.Size(80, 15)
        Me.IDimensions.TabIndex = 7
        Me.IDimensions.Text = "Dimensjoner: "
        '
        'IconSize
        '
        Me.IconSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconSize.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.IconSize.Location = New System.Drawing.Point(181, 65)
        Me.IconSize.Name = "IconSize"
        Me.IconSize.Size = New System.Drawing.Size(150, 15)
        Me.IconSize.TabIndex = 6
        Me.IconSize.Text = "Venligst velg ett ikon..."
        '
        'ISize
        '
        Me.ISize.AutoSize = True
        Me.ISize.Location = New System.Drawing.Point(12, 65)
        Me.ISize.Name = "ISize"
        Me.ISize.Size = New System.Drawing.Size(58, 15)
        Me.ISize.TabIndex = 5
        Me.ISize.Text = "Størrelse: "
        '
        'IconID
        '
        Me.IconID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.IconID.Location = New System.Drawing.Point(181, 38)
        Me.IconID.Name = "IconID"
        Me.IconID.Size = New System.Drawing.Size(150, 15)
        Me.IconID.TabIndex = 4
        Me.IconID.Text = "Venligst velg ett ikon..."
        '
        'IID
        '
        Me.IID.AutoSize = True
        Me.IID.Location = New System.Drawing.Point(12, 38)
        Me.IID.Name = "IID"
        Me.IID.Size = New System.Drawing.Size(50, 15)
        Me.IID.TabIndex = 3
        Me.IID.Text = "Ikon ID: "
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Location = New System.Drawing.Point(340, 30)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(174, 130)
        Me.IconPanel.TabIndex = 2
        '
        'IconFileName
        '
        Me.IconFileName.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconFileName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.IconFileName.Location = New System.Drawing.Point(181, 12)
        Me.IconFileName.Name = "IconFileName"
        Me.IconFileName.Size = New System.Drawing.Size(150, 15)
        Me.IconFileName.TabIndex = 1
        Me.IconFileName.Text = "Venligst velg ett ikon..."
        '
        'IFileName
        '
        Me.IFileName.AutoSize = True
        Me.IFileName.Location = New System.Drawing.Point(12, 12)
        Me.IFileName.Name = "IFileName"
        Me.IFileName.Size = New System.Drawing.Size(51, 15)
        Me.IFileName.TabIndex = 0
        Me.IFileName.Text = "Filnavn: "
        '
        'CheckButtons
        '
        Me.CheckButtons.Enabled = True
        Me.CheckButtons.Interval = 1
        '
        'frmViewIcons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(555, 438)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmViewIcons"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Egenskaper for ?"
        Me.TabControl1.ResumeLayout(False)
        Me.StartTabPage.ResumeLayout(False)
        Me.StartTabPage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents StartTabPage As System.Windows.Forms.TabPage
    Friend WithEvents IDimensions As System.Windows.Forms.Label
    Friend WithEvents IconSize As System.Windows.Forms.Label
    Friend WithEvents ISize As System.Windows.Forms.Label
    Friend WithEvents IconID As System.Windows.Forms.Label
    Friend WithEvents IID As System.Windows.Forms.Label
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents IconFileName As System.Windows.Forms.Label
    Friend WithEvents IFileName As System.Windows.Forms.Label
    Friend WithEvents IconPreviewLabel As System.Windows.Forms.Label
    Friend WithEvents IColorDepth As System.Windows.Forms.Label
    Friend WithEvents IconDimensions As System.Windows.Forms.Label
    Friend WithEvents IconListView As System.Windows.Forms.ListView
    Friend WithEvents IDColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents DimensionsColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColorDepthColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents SizeColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents SaveIconsToButton As System.Windows.Forms.Button
    Friend WithEvents CopyIconButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents CheckButtons As System.Windows.Forms.Timer
    Friend WithEvents ColorsColumn As System.Windows.Forms.ColumnHeader
    Friend WithEvents IconColors As System.Windows.Forms.Label
    Friend WithEvents IColors As System.Windows.Forms.Label
    Friend WithEvents IconColorDepth As System.Windows.Forms.LinkLabel
End Class
