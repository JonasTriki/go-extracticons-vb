<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.pbIcon = New System.Windows.Forms.PictureBox()
        Me.lTitle = New System.Windows.Forms.Label()
        Me.lVersion = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lCopyright = New System.Windows.Forms.Label()
        Me.lInfo = New System.Windows.Forms.Label()
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pbIcon
        '
        Me.pbIcon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbIcon.ErrorImage = Nothing
        Me.pbIcon.Image = CType(resources.GetObject("pbIcon.Image"), System.Drawing.Image)
        Me.pbIcon.InitialImage = Nothing
        Me.pbIcon.Location = New System.Drawing.Point(12, 12)
        Me.pbIcon.Name = "pbIcon"
        Me.pbIcon.Size = New System.Drawing.Size(128, 128)
        Me.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbIcon.TabIndex = 0
        Me.pbIcon.TabStop = False
        '
        'lTitle
        '
        Me.lTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lTitle.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lTitle.Location = New System.Drawing.Point(146, 9)
        Me.lTitle.Name = "lTitle"
        Me.lTitle.Size = New System.Drawing.Size(416, 47)
        Me.lTitle.TabIndex = 1
        Me.lTitle.Text = "Go! ExtractIcons"
        Me.lTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lVersion
        '
        Me.lVersion.AutoSize = True
        Me.lVersion.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lVersion.Location = New System.Drawing.Point(151, 56)
        Me.lVersion.Name = "lVersion"
        Me.lVersion.Size = New System.Drawing.Size(12, 15)
        Me.lVersion.TabIndex = 2
        Me.lVersion.Text = "?"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(487, 117)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 3
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lCopyright
        '
        Me.lCopyright.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lCopyright.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lCopyright.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lCopyright.Location = New System.Drawing.Point(146, 121)
        Me.lCopyright.Name = "lCopyright"
        Me.lCopyright.Size = New System.Drawing.Size(335, 15)
        Me.lCopyright.TabIndex = 4
        Me.lCopyright.Text = "?"
        Me.lCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lInfo
        '
        Me.lInfo.AutoSize = True
        Me.lInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lInfo.Location = New System.Drawing.Point(146, 82)
        Me.lInfo.Name = "lInfo"
        Me.lInfo.Size = New System.Drawing.Size(229, 30)
        Me.lInfo.TabIndex = 5
        Me.lInfo.Text = "This program is made by Go! Visual Team." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Please visit our site for more informat" & _
            "ion."
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(574, 152)
        Me.Controls.Add(Me.lInfo)
        Me.Controls.Add(Me.lCopyright)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lVersion)
        Me.Controls.Add(Me.lTitle)
        Me.Controls.Add(Me.pbIcon)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Om Go! ExtractIcons"
        CType(Me.pbIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lTitle As System.Windows.Forms.Label
    Friend WithEvents lVersion As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lCopyright As System.Windows.Forms.Label
    Friend WithEvents lInfo As System.Windows.Forms.Label
End Class
