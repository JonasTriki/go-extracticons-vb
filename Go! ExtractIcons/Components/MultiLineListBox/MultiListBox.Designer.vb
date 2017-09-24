<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiListBox
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
        Me.LeftBorder = New System.Windows.Forms.Panel()
        Me.RightBorder = New System.Windows.Forms.Panel()
        Me.TopBorder = New System.Windows.Forms.Panel()
        Me.BottomBorder = New System.Windows.Forms.Panel()
        Me.ItemBox = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'LeftBorder
        '
        Me.LeftBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.LeftBorder.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftBorder.Location = New System.Drawing.Point(0, 0)
        Me.LeftBorder.Name = "LeftBorder"
        Me.LeftBorder.Size = New System.Drawing.Size(1, 302)
        Me.LeftBorder.TabIndex = 0
        '
        'RightBorder
        '
        Me.RightBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.RightBorder.Dock = System.Windows.Forms.DockStyle.Right
        Me.RightBorder.Location = New System.Drawing.Point(329, 0)
        Me.RightBorder.Name = "RightBorder"
        Me.RightBorder.Size = New System.Drawing.Size(1, 302)
        Me.RightBorder.TabIndex = 1
        '
        'TopBorder
        '
        Me.TopBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.TopBorder.Dock = System.Windows.Forms.DockStyle.Top
        Me.TopBorder.Location = New System.Drawing.Point(1, 0)
        Me.TopBorder.Name = "TopBorder"
        Me.TopBorder.Size = New System.Drawing.Size(328, 1)
        Me.TopBorder.TabIndex = 1
        '
        'BottomBorder
        '
        Me.BottomBorder.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.BottomBorder.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BottomBorder.Location = New System.Drawing.Point(1, 301)
        Me.BottomBorder.Name = "BottomBorder"
        Me.BottomBorder.Size = New System.Drawing.Size(328, 1)
        Me.BottomBorder.TabIndex = 2
        '
        'ItemBox
        '
        Me.ItemBox.AutoScroll = True
        Me.ItemBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemBox.Location = New System.Drawing.Point(1, 1)
        Me.ItemBox.Name = "ItemBox"
        Me.ItemBox.Size = New System.Drawing.Size(328, 300)
        Me.ItemBox.TabIndex = 3
        '
        'MultiColumnListBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.ItemBox)
        Me.Controls.Add(Me.BottomBorder)
        Me.Controls.Add(Me.TopBorder)
        Me.Controls.Add(Me.RightBorder)
        Me.Controls.Add(Me.LeftBorder)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MinimumSize = New System.Drawing.Size(330, 302)
        Me.Name = "MultiColumnListBox"
        Me.Size = New System.Drawing.Size(330, 302)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LeftBorder As System.Windows.Forms.Panel
    Friend WithEvents RightBorder As System.Windows.Forms.Panel
    Friend WithEvents TopBorder As System.Windows.Forms.Panel
    Friend WithEvents BottomBorder As System.Windows.Forms.Panel
    Private WithEvents ItemBox As System.Windows.Forms.Panel

End Class
