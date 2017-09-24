<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIconColorDepthChangerFromIcon
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIconColorDepthChangerFromIcon))
        Me.llIconPreview = New System.Windows.Forms.Label()
        Me.pIcon = New System.Windows.Forms.Panel()
        Me.llCurrentIconColorDepth = New System.Windows.Forms.Label()
        Me.pSplitPreviews = New System.Windows.Forms.Panel()
        Me.llNewIconColorDepth = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pIconNew = New System.Windows.Forms.Panel()
        Me.cmIconColorDepths = New System.Windows.Forms.ComboBox()
        Me.pSplitPreviews2 = New System.Windows.Forms.Panel()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'llIconPreview
        '
        Me.llIconPreview.AutoEllipsis = True
        Me.llIconPreview.Location = New System.Drawing.Point(12, 9)
        Me.llIconPreview.Name = "llIconPreview"
        Me.llIconPreview.Size = New System.Drawing.Size(174, 15)
        Me.llIconPreview.TabIndex = 13
        Me.llIconPreview.Text = "Gjeldende ikon:"
        Me.llIconPreview.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pIcon
        '
        Me.pIcon.Location = New System.Drawing.Point(12, 27)
        Me.pIcon.Name = "pIcon"
        Me.pIcon.Size = New System.Drawing.Size(174, 130)
        Me.pIcon.TabIndex = 12
        '
        'llCurrentIconColorDepth
        '
        Me.llCurrentIconColorDepth.Location = New System.Drawing.Point(12, 166)
        Me.llCurrentIconColorDepth.Name = "llCurrentIconColorDepth"
        Me.llCurrentIconColorDepth.Size = New System.Drawing.Size(174, 15)
        Me.llCurrentIconColorDepth.TabIndex = 14
        Me.llCurrentIconColorDepth.Text = "Ingen ikon"
        Me.llCurrentIconColorDepth.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pSplitPreviews
        '
        Me.pSplitPreviews.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pSplitPreviews.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplitPreviews.Location = New System.Drawing.Point(200, 0)
        Me.pSplitPreviews.Name = "pSplitPreviews"
        Me.pSplitPreviews.Size = New System.Drawing.Size(1, 193)
        Me.pSplitPreviews.TabIndex = 14
        '
        'llNewIconColorDepth
        '
        Me.llNewIconColorDepth.Location = New System.Drawing.Point(216, 166)
        Me.llNewIconColorDepth.Name = "llNewIconColorDepth"
        Me.llNewIconColorDepth.Size = New System.Drawing.Size(109, 15)
        Me.llNewIconColorDepth.TabIndex = 17
        Me.llNewIconColorDepth.Text = "Ingen ikon"
        Me.llNewIconColorDepth.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.AutoEllipsis = True
        Me.Label2.Location = New System.Drawing.Point(216, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(174, 15)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Nytt ikon:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'pIconNew
        '
        Me.pIconNew.Location = New System.Drawing.Point(216, 27)
        Me.pIconNew.Name = "pIconNew"
        Me.pIconNew.Size = New System.Drawing.Size(174, 130)
        Me.pIconNew.TabIndex = 15
        '
        'cmIconColorDepths
        '
        Me.cmIconColorDepths.AutoCompleteCustomSource.AddRange(New String() {"0", "1", "2", "4", "8", "16", "24", "32"})
        Me.cmIconColorDepths.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmIconColorDepths.FormattingEnabled = True
        Me.cmIconColorDepths.Location = New System.Drawing.Point(331, 163)
        Me.cmIconColorDepths.Name = "cmIconColorDepths"
        Me.cmIconColorDepths.Size = New System.Drawing.Size(60, 23)
        Me.cmIconColorDepths.TabIndex = 18
        '
        'pSplitPreviews2
        '
        Me.pSplitPreviews2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pSplitPreviews2.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.pSplitPreviews2.Location = New System.Drawing.Point(0, 192)
        Me.pSplitPreviews2.Name = "pSplitPreviews2"
        Me.pSplitPreviews2.Size = New System.Drawing.Size(403, 1)
        Me.pSplitPreviews2.TabIndex = 15
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(315, 199)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "&Avbryt"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(234, 199)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 20
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmIconColorDepthChangerFromIcon
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(402, 229)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.pSplitPreviews2)
        Me.Controls.Add(Me.cmIconColorDepths)
        Me.Controls.Add(Me.llNewIconColorDepth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pIconNew)
        Me.Controls.Add(Me.llCurrentIconColorDepth)
        Me.Controls.Add(Me.pSplitPreviews)
        Me.Controls.Add(Me.llIconPreview)
        Me.Controls.Add(Me.pIcon)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIconColorDepthChangerFromIcon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Endre fargedybde..."
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents llIconPreview As System.Windows.Forms.Label
    Friend WithEvents pIcon As System.Windows.Forms.Panel
    Friend WithEvents llCurrentIconColorDepth As System.Windows.Forms.Label
    Friend WithEvents pSplitPreviews As System.Windows.Forms.Panel
    Friend WithEvents llNewIconColorDepth As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents pIconNew As System.Windows.Forms.Panel
    Friend WithEvents cmIconColorDepths As System.Windows.Forms.ComboBox
    Friend WithEvents pSplitPreviews2 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
End Class
