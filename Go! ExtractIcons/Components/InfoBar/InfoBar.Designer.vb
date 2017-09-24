<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InfoBar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InfoBar))
        Me.InfoCloseBtn = New System.Windows.Forms.PictureBox()
        Me.InfoIcon = New System.Windows.Forms.PictureBox()
        Me.InfoText = New System.Windows.Forms.Label()
        CType(Me.InfoCloseBtn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InfoIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InfoCloseBtn
        '
        Me.InfoCloseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InfoCloseBtn.BackColor = System.Drawing.Color.Transparent
        Me.InfoCloseBtn.ErrorImage = Nothing
        Me.InfoCloseBtn.Image = Global.Go__ExtractIcons.My.Resources.Resources.Close_Disabled
        Me.InfoCloseBtn.InitialImage = Nothing
        Me.InfoCloseBtn.Location = New System.Drawing.Point(707, 3)
        Me.InfoCloseBtn.Name = "InfoCloseBtn"
        Me.InfoCloseBtn.Size = New System.Drawing.Size(17, 16)
        Me.InfoCloseBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.InfoCloseBtn.TabIndex = 5
        Me.InfoCloseBtn.TabStop = False
        '
        'InfoIcon
        '
        Me.InfoIcon.BackColor = System.Drawing.Color.Transparent
        Me.InfoIcon.ErrorImage = Nothing
        Me.InfoIcon.Image = Global.Go__ExtractIcons.My.Resources.Resources.Info_Icon
        Me.InfoIcon.InitialImage = Nothing
        Me.InfoIcon.Location = New System.Drawing.Point(4, 3)
        Me.InfoIcon.Name = "InfoIcon"
        Me.InfoIcon.Size = New System.Drawing.Size(16, 16)
        Me.InfoIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoIcon.TabIndex = 3
        Me.InfoIcon.TabStop = False
        '
        'InfoText
        '
        Me.InfoText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InfoText.AutoEllipsis = True
        Me.InfoText.BackColor = System.Drawing.Color.Transparent
        Me.InfoText.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InfoText.Location = New System.Drawing.Point(26, 4)
        Me.InfoText.Name = "InfoText"
        Me.InfoText.Size = New System.Drawing.Size(676, 15)
        Me.InfoText.TabIndex = 4
        '
        'InfoBar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.Controls.Add(Me.InfoCloseBtn)
        Me.Controls.Add(Me.InfoIcon)
        Me.Controls.Add(Me.InfoText)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximumSize = New System.Drawing.Size(0, 24)
        Me.Name = "InfoBar"
        Me.Size = New System.Drawing.Size(728, 24)
        CType(Me.InfoCloseBtn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InfoIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InfoCloseBtn As System.Windows.Forms.PictureBox
    Friend WithEvents InfoIcon As System.Windows.Forms.PictureBox
    Friend WithEvents InfoText As System.Windows.Forms.Label

End Class
