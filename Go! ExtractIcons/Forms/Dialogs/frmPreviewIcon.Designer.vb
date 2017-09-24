<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPreviewIcon
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreviewIcon))
        Me.pDown = New System.Windows.Forms.Panel()
        Me.btnSaveIconsTo = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.gibPreviewIcon = New Go__ExtractIcons.GoIconBox()
        Me.pDown.SuspendLayout()
        Me.SuspendLayout()
        '
        'pDown
        '
        Me.pDown.Controls.Add(Me.btnSaveIconsTo)
        Me.pDown.Controls.Add(Me.btnClose)
        Me.pDown.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pDown.Location = New System.Drawing.Point(0, 256)
        Me.pDown.Name = "pDown"
        Me.pDown.Size = New System.Drawing.Size(205, 29)
        Me.pDown.TabIndex = 1
        '
        'btnSaveIconsTo
        '
        Me.btnSaveIconsTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveIconsTo.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveIconsTo.Location = New System.Drawing.Point(3, 3)
        Me.btnSaveIconsTo.Name = "btnSaveIconsTo"
        Me.btnSaveIconsTo.Size = New System.Drawing.Size(118, 23)
        Me.btnSaveIconsTo.TabIndex = 4
        Me.btnSaveIconsTo.Text = "L&agre ikon til..."
        Me.btnSaveIconsTo.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(127, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "&Lukk"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'gibPreviewIcon
        '
        Me.gibPreviewIcon.BackColor = System.Drawing.Color.Transparent
        Me.gibPreviewIcon.BorderColor = System.Drawing.Color.FromArgb(CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(180, Byte), Integer))
        Me.gibPreviewIcon.BorderSize = 1.0!
        Me.gibPreviewIcon.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gibPreviewIcon.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gibPreviewIcon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.gibPreviewIcon.Icon = Nothing
        Me.gibPreviewIcon.IconStyle = Go__ExtractIcons.GoIconBox.IconDrawingStyle.Center
        Me.gibPreviewIcon.Location = New System.Drawing.Point(0, 0)
        Me.gibPreviewIcon.Name = "gibPreviewIcon"
        Me.gibPreviewIcon.ShowBorder = False
        Me.gibPreviewIcon.Size = New System.Drawing.Size(205, 256)
        Me.gibPreviewIcon.TabIndex = 0
        '
        'frmPreviewIcon
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(205, 285)
        Me.Controls.Add(Me.gibPreviewIcon)
        Me.Controls.Add(Me.pDown)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPreviewIcon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Forhåndsvisning..."
        Me.pDown.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gibPreviewIcon As Go__ExtractIcons.GoIconBox
    Friend WithEvents pDown As System.Windows.Forms.Panel
    Friend WithEvents btnSaveIconsTo As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
