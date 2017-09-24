<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMessageBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMessageBox))
        Me.MsgIcon = New System.Windows.Forms.PictureBox()
        Me.MsgPanel = New System.Windows.Forms.Panel()
        Me.YesOrSaveButton = New System.Windows.Forms.Button()
        Me.ExitOrOKOrNoOrHelpButton = New System.Windows.Forms.Button()
        Me.OkOrNoOrYesOrRetryOrDoNotSaveButton = New System.Windows.Forms.Button()
        Me.DoNotShowAgainCheckBox = New System.Windows.Forms.CheckBox()
        Me.MsgText = New System.Windows.Forms.Label()
        Me.MsgTitle = New System.Windows.Forms.Label()
        CType(Me.MsgIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MsgPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'MsgIcon
        '
        Me.MsgIcon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.MsgIcon.ErrorImage = Nothing
        Me.MsgIcon.Image = CType(resources.GetObject("MsgIcon.Image"), System.Drawing.Image)
        Me.MsgIcon.InitialImage = Nothing
        Me.MsgIcon.Location = New System.Drawing.Point(12, 12)
        Me.MsgIcon.Name = "MsgIcon"
        Me.MsgIcon.Size = New System.Drawing.Size(48, 69)
        Me.MsgIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.MsgIcon.TabIndex = 0
        Me.MsgIcon.TabStop = False
        '
        'MsgPanel
        '
        Me.MsgPanel.BackColor = System.Drawing.Color.Transparent
        Me.MsgPanel.Controls.Add(Me.YesOrSaveButton)
        Me.MsgPanel.Controls.Add(Me.ExitOrOKOrNoOrHelpButton)
        Me.MsgPanel.Controls.Add(Me.OkOrNoOrYesOrRetryOrDoNotSaveButton)
        Me.MsgPanel.Controls.Add(Me.DoNotShowAgainCheckBox)
        Me.MsgPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.MsgPanel.Location = New System.Drawing.Point(0, 87)
        Me.MsgPanel.Name = "MsgPanel"
        Me.MsgPanel.Size = New System.Drawing.Size(511, 29)
        Me.MsgPanel.TabIndex = 2
        '
        'YesOrSaveButton
        '
        Me.YesOrSaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.YesOrSaveButton.Location = New System.Drawing.Point(235, 3)
        Me.YesOrSaveButton.Name = "YesOrSaveButton"
        Me.YesOrSaveButton.Size = New System.Drawing.Size(87, 23)
        Me.YesOrSaveButton.TabIndex = 2
        Me.YesOrSaveButton.Text = "Ja"
        Me.YesOrSaveButton.UseVisualStyleBackColor = True
        Me.YesOrSaveButton.Visible = False
        '
        'ExitOrOKOrNoOrHelpButton
        '
        Me.ExitOrOKOrNoOrHelpButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExitOrOKOrNoOrHelpButton.Location = New System.Drawing.Point(421, 3)
        Me.ExitOrOKOrNoOrHelpButton.Name = "ExitOrOKOrNoOrHelpButton"
        Me.ExitOrOKOrNoOrHelpButton.Size = New System.Drawing.Size(87, 23)
        Me.ExitOrOKOrNoOrHelpButton.TabIndex = 1
        Me.ExitOrOKOrNoOrHelpButton.Text = "Avbryt"
        Me.ExitOrOKOrNoOrHelpButton.UseVisualStyleBackColor = True
        '
        'OkOrNoOrYesOrRetryOrDoNotSaveButton
        '
        Me.OkOrNoOrYesOrRetryOrDoNotSaveButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkOrNoOrYesOrRetryOrDoNotSaveButton.Location = New System.Drawing.Point(328, 3)
        Me.OkOrNoOrYesOrRetryOrDoNotSaveButton.Name = "OkOrNoOrYesOrRetryOrDoNotSaveButton"
        Me.OkOrNoOrYesOrRetryOrDoNotSaveButton.Size = New System.Drawing.Size(87, 23)
        Me.OkOrNoOrYesOrRetryOrDoNotSaveButton.TabIndex = 0
        Me.OkOrNoOrYesOrRetryOrDoNotSaveButton.Text = "OK"
        Me.OkOrNoOrYesOrRetryOrDoNotSaveButton.UseVisualStyleBackColor = True
        '
        'DoNotShowAgainCheckBox
        '
        Me.DoNotShowAgainCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.DoNotShowAgainCheckBox.AutoSize = True
        Me.DoNotShowAgainCheckBox.Location = New System.Drawing.Point(19, 6)
        Me.DoNotShowAgainCheckBox.Name = "DoNotShowAgainCheckBox"
        Me.DoNotShowAgainCheckBox.Size = New System.Drawing.Size(203, 19)
        Me.DoNotShowAgainCheckBox.TabIndex = 3
        Me.DoNotShowAgainCheckBox.Text = "Ikke vis denne meldingen på nytt."
        Me.DoNotShowAgainCheckBox.UseVisualStyleBackColor = True
        Me.DoNotShowAgainCheckBox.Visible = False
        '
        'MsgText
        '
        Me.MsgText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MsgText.AutoEllipsis = True
        Me.MsgText.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MsgText.Location = New System.Drawing.Point(66, 33)
        Me.MsgText.Name = "MsgText"
        Me.MsgText.Size = New System.Drawing.Size(433, 48)
        Me.MsgText.TabIndex = 1
        Me.MsgText.Text = "<Text>"
        Me.MsgText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MsgTitle
        '
        Me.MsgTitle.AutoEllipsis = True
        Me.MsgTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MsgTitle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.MsgTitle.Location = New System.Drawing.Point(66, 12)
        Me.MsgTitle.Name = "MsgTitle"
        Me.MsgTitle.Size = New System.Drawing.Size(419, 21)
        Me.MsgTitle.TabIndex = 3
        Me.MsgTitle.Text = "<Title>"
        Me.MsgTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(511, 116)
        Me.Controls.Add(Me.MsgTitle)
        Me.Controls.Add(Me.MsgPanel)
        Me.Controls.Add(Me.MsgText)
        Me.Controls.Add(Me.MsgIcon)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(503, 144)
        Me.Name = "frmMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "<Form Title>"
        CType(Me.MsgIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MsgPanel.ResumeLayout(False)
        Me.MsgPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MsgIcon As System.Windows.Forms.PictureBox
    Friend WithEvents MsgPanel As System.Windows.Forms.Panel
    Friend WithEvents OkOrNoOrYesOrRetryOrDoNotSaveButton As System.Windows.Forms.Button
    Friend WithEvents ExitOrOKOrNoOrHelpButton As System.Windows.Forms.Button
    Friend WithEvents YesOrSaveButton As System.Windows.Forms.Button
    Friend WithEvents MsgText As System.Windows.Forms.Label
    Friend WithEvents MsgTitle As System.Windows.Forms.Label
    Friend WithEvents DoNotShowAgainCheckBox As System.Windows.Forms.CheckBox
End Class
