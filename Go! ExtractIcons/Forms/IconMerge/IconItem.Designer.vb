<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IconItem
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.SizeAndColorDepthLabel = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'IconPanel
        '
        Me.IconPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IconPanel.Location = New System.Drawing.Point(3, 3)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(96, 96)
        Me.IconPanel.TabIndex = 0
        '
        'SizeAndColorDepthLabel
        '
        Me.SizeAndColorDepthLabel.Location = New System.Drawing.Point(3, 99)
        Me.SizeAndColorDepthLabel.Name = "SizeAndColorDepthLabel"
        Me.SizeAndColorDepthLabel.Size = New System.Drawing.Size(96, 20)
        Me.SizeAndColorDepthLabel.TabIndex = 0
        '
        'IconItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.SizeAndColorDepthLabel)
        Me.Controls.Add(Me.IconPanel)
        Me.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.SystemColors.WindowText
        Me.MinimumSize = New System.Drawing.Size(102, 120)
        Me.Name = "IconItem"
        Me.Size = New System.Drawing.Size(102, 120)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents SizeAndColorDepthLabel As System.Windows.Forms.Panel

End Class
