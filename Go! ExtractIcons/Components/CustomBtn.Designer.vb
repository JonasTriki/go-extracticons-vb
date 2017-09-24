<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CustomBtn
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CustomBtn))
        Me.TextLabel = New System.Windows.Forms.Label()
        Me.DropDownBtn = New System.Windows.Forms.PictureBox()
        Me.IconBox = New System.Windows.Forms.PictureBox()
        CType(Me.DropDownBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IconBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextLabel
        '
        Me.TextLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextLabel.AutoEllipsis = True
        Me.TextLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.TextLabel.Location = New System.Drawing.Point(30, 5)
        Me.TextLabel.Name = "TextLabel"
        Me.TextLabel.Size = New System.Drawing.Size(46, 15)
        Me.TextLabel.TabIndex = 4
        Me.TextLabel.Text = "<Text>"
        '
        'DropDownBtn
        '
        Me.DropDownBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DropDownBtn.ErrorImage = Nothing
        Me.DropDownBtn.Image = CType(resources.GetObject("DropDownBtn.Image"), System.Drawing.Image)
        Me.DropDownBtn.InitialImage = Nothing
        Me.DropDownBtn.Location = New System.Drawing.Point(82, 10)
        Me.DropDownBtn.Name = "DropDownBtn"
        Me.DropDownBtn.Size = New System.Drawing.Size(5, 5)
        Me.DropDownBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.DropDownBtn.TabIndex = 5
        Me.DropDownBtn.TabStop = False
        '
        'IconBox
        '
        Me.IconBox.ErrorImage = Nothing
        Me.IconBox.InitialImage = Nothing
        Me.IconBox.Location = New System.Drawing.Point(12, 4)
        Me.IconBox.Name = "IconBox"
        Me.IconBox.Size = New System.Drawing.Size(16, 16)
        Me.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.IconBox.TabIndex = 6
        Me.IconBox.TabStop = False
        '
        'CustomBtn
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.BackgroundImage = Global.Go__ExtractIcons.My.Resources.Resources.CustomBtn_Normal
        Me.Controls.Add(Me.DropDownBtn)
        Me.Controls.Add(Me.TextLabel)
        Me.Controls.Add(Me.IconBox)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(0, 25)
        Me.Name = "CustomBtn"
        Me.Size = New System.Drawing.Size(100, 25)
        CType(Me.DropDownBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IconBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DropDownBtn As System.Windows.Forms.PictureBox
    Friend WithEvents TextLabel As System.Windows.Forms.Label
    Friend WithEvents IconBox As System.Windows.Forms.PictureBox

End Class
