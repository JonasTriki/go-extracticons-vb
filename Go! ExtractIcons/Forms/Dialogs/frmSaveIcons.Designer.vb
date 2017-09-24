<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSaveIcons
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSaveIcons))
        Me.SaveIconsToFolder = New System.Windows.Forms.Label()
        Me.ChooseFolderButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.SaveIconsButton = New System.Windows.Forms.Button()
        Me.CheckButton = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBox = New Go__ExtractIcons.GoTextBox()
        Me.SuspendLayout()
        '
        'SaveIconsToFolder
        '
        Me.SaveIconsToFolder.AutoSize = True
        Me.SaveIconsToFolder.Location = New System.Drawing.Point(12, 9)
        Me.SaveIconsToFolder.Name = "SaveIconsToFolder"
        Me.SaveIconsToFolder.Size = New System.Drawing.Size(131, 15)
        Me.SaveIconsToFolder.TabIndex = 0
        Me.SaveIconsToFolder.Text = "Lagre ikoner til mappe: "
        '
        'ChooseFolderButton
        '
        Me.ChooseFolderButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChooseFolderButton.Location = New System.Drawing.Point(497, 31)
        Me.ChooseFolderButton.Name = "ChooseFolderButton"
        Me.ChooseFolderButton.Size = New System.Drawing.Size(27, 22)
        Me.ChooseFolderButton.TabIndex = 34
        Me.ChooseFolderButton.Text = "..."
        Me.ChooseFolderButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.Location = New System.Drawing.Point(466, 59)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(58, 23)
        Me.CloseButton.TabIndex = 35
        Me.CloseButton.Text = "Lukk"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'SaveIconsButton
        '
        Me.SaveIconsButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SaveIconsButton.Enabled = False
        Me.SaveIconsButton.Location = New System.Drawing.Point(302, 59)
        Me.SaveIconsButton.Name = "SaveIconsButton"
        Me.SaveIconsButton.Size = New System.Drawing.Size(158, 23)
        Me.SaveIconsButton.TabIndex = 36
        Me.SaveIconsButton.Text = "Lagre ikoner..."
        Me.SaveIconsButton.UseVisualStyleBackColor = True
        '
        'CheckButton
        '
        Me.CheckButton.Enabled = True
        Me.CheckButton.Interval = 1
        '
        'FolderBox
        '
        Me.FolderBox.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.FolderBox.ContextMenuStrip = Nothing
        Me.FolderBox.DisabledBorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.FolderBox.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FolderBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FolderBox.HoverBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.FolderBox.Icon = Global.Go__ExtractIcons.My.Resources.Resources.ClosedFolder
        Me.FolderBox.Location = New System.Drawing.Point(12, 31)
        Me.FolderBox.MinimumSize = New System.Drawing.Size(0, 22)
        Me.FolderBox.Name = "FolderBox"
        Me.FolderBox.NormalBorderColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.FolderBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.FolderBox.SelectedBorderColor = System.Drawing.Color.FromArgb(CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.FolderBox.Size = New System.Drawing.Size(479, 22)
        Me.FolderBox.TabIndex = 37
        '
        'frmSaveIcons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(536, 94)
        Me.Controls.Add(Me.FolderBox)
        Me.Controls.Add(Me.SaveIconsButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.ChooseFolderButton)
        Me.Controls.Add(Me.SaveIconsToFolder)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSaveIcons"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lagre ikoner til..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SaveIconsToFolder As System.Windows.Forms.Label
    Friend WithEvents ChooseFolderButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents SaveIconsButton As System.Windows.Forms.Button
    Friend WithEvents CheckButton As System.Windows.Forms.Timer
    Friend WithEvents FolderBox As Go__ExtractIcons.GoTextBox
End Class
