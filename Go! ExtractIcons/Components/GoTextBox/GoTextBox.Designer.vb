<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GoTextBox
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
        Me.txtText = New System.Windows.Forms.TextBox()
        Me.pIcon = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'txtText
        '
        Me.txtText.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtText.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtText.Location = New System.Drawing.Point(26, 3)
        Me.txtText.Name = "txtText"
        Me.txtText.Size = New System.Drawing.Size(120, 16)
        Me.txtText.TabIndex = 0
        '
        'pIcon
        '
        Me.pIcon.BackColor = System.Drawing.SystemColors.Window
        Me.pIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pIcon.Location = New System.Drawing.Point(3, 3)
        Me.pIcon.Name = "pIcon"
        Me.pIcon.Size = New System.Drawing.Size(16, 16)
        Me.pIcon.TabIndex = 1
        '
        'GoTextBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pIcon)
        Me.Controls.Add(Me.txtText)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.MinimumSize = New System.Drawing.Size(0, 22)
        Me.Name = "GoTextBox"
        Me.Size = New System.Drawing.Size(150, 22)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents pIcon As System.Windows.Forms.Panel

End Class
