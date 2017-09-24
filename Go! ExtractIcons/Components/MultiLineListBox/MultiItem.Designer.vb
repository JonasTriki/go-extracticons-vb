<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiItem
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
        Me.TextLabel = New System.Windows.Forms.Label()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.BottomBorder = New System.Windows.Forms.Panel()
        Me.TopBorder = New System.Windows.Forms.Panel()
        Me.RightBorder = New System.Windows.Forms.Panel()
        Me.LeftBorder = New System.Windows.Forms.Panel()
        Me.IconBox = New System.Windows.Forms.Panel()
        Me.ExtraTitleLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextLabel
        '
        Me.TextLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextLabel.AutoEllipsis = True
        Me.TextLabel.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextLabel.Location = New System.Drawing.Point(53, 24)
        Me.TextLabel.Name = "TextLabel"
        Me.TextLabel.Size = New System.Drawing.Size(279, 25)
        Me.TextLabel.TabIndex = 3
        Me.TextLabel.Text = "<Text>" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<Text>"
        '
        'TitleLabel
        '
        Me.TitleLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TitleLabel.AutoEllipsis = True
        Me.TitleLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.Location = New System.Drawing.Point(53, 4)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(200, 15)
        Me.TitleLabel.TabIndex = 4
        Me.TitleLabel.Text = "<Title>"
        '
        'BottomBorder
        '
        Me.BottomBorder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BottomBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.BottomBorder.Location = New System.Drawing.Point(4, 52)
        Me.BottomBorder.Name = "BottomBorder"
        Me.BottomBorder.Size = New System.Drawing.Size(329, 1)
        Me.BottomBorder.TabIndex = 8
        '
        'TopBorder
        '
        Me.TopBorder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TopBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.TopBorder.Location = New System.Drawing.Point(4, 3)
        Me.TopBorder.Name = "TopBorder"
        Me.TopBorder.Size = New System.Drawing.Size(329, 1)
        Me.TopBorder.TabIndex = 7
        '
        'RightBorder
        '
        Me.RightBorder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RightBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.RightBorder.Location = New System.Drawing.Point(333, 3)
        Me.RightBorder.Name = "RightBorder"
        Me.RightBorder.Size = New System.Drawing.Size(1, 50)
        Me.RightBorder.TabIndex = 6
        '
        'LeftBorder
        '
        Me.LeftBorder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LeftBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer), CType(CType(227, Byte), Integer))
        Me.LeftBorder.Location = New System.Drawing.Point(3, 3)
        Me.LeftBorder.Name = "LeftBorder"
        Me.LeftBorder.Size = New System.Drawing.Size(1, 50)
        Me.LeftBorder.TabIndex = 5
        '
        'IconBox
        '
        Me.IconBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IconBox.BackColor = System.Drawing.Color.Transparent
        Me.IconBox.Location = New System.Drawing.Point(3, 3)
        Me.IconBox.Name = "IconBox"
        Me.IconBox.Size = New System.Drawing.Size(50, 50)
        Me.IconBox.TabIndex = 2
        '
        'ExtraTitleLabel
        '
        Me.ExtraTitleLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExtraTitleLabel.AutoSize = True
        Me.ExtraTitleLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExtraTitleLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ExtraTitleLabel.Location = New System.Drawing.Point(257, 4)
        Me.ExtraTitleLabel.MaximumSize = New System.Drawing.Size(250, 0)
        Me.ExtraTitleLabel.Name = "ExtraTitleLabel"
        Me.ExtraTitleLabel.Size = New System.Drawing.Size(74, 15)
        Me.ExtraTitleLabel.TabIndex = 9
        Me.ExtraTitleLabel.Text = "<Extra Title>"
        Me.ExtraTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ExtraTitleLabel.Visible = False
        '
        'MultiItem
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ExtraTitleLabel)
        Me.Controls.Add(Me.BottomBorder)
        Me.Controls.Add(Me.TopBorder)
        Me.Controls.Add(Me.RightBorder)
        Me.Controls.Add(Me.LeftBorder)
        Me.Controls.Add(Me.IconBox)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.TextLabel)
        Me.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "MultiItem"
        Me.Size = New System.Drawing.Size(337, 56)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextLabel As System.Windows.Forms.Label
    Friend WithEvents TitleLabel As System.Windows.Forms.Label
    Friend WithEvents BottomBorder As System.Windows.Forms.Panel
    Friend WithEvents TopBorder As System.Windows.Forms.Panel
    Friend WithEvents RightBorder As System.Windows.Forms.Panel
    Friend WithEvents LeftBorder As System.Windows.Forms.Panel
    Friend WithEvents IconBox As System.Windows.Forms.Panel
    Friend WithEvents ExtraTitleLabel As System.Windows.Forms.Label

End Class
