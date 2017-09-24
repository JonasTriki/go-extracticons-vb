<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIconMerge
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIconMerge))
        Me.MenuBar = New System.Windows.Forms.MenuStrip()
        Me.FilToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NyttIkonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÅpneIkonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LukkIkonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.LagreIkonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LagreIkonSomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.LukkToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RedigerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeggTilEtIkonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.FjernIkonToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeftPanel = New System.Windows.Forms.Panel()
        Me.IconPanel = New System.Windows.Forms.Panel()
        Me.StatusBar = New System.Windows.Forms.StatusStrip()
        Me.StatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SpringLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CheckThings = New System.Windows.Forms.Timer(Me.components)
        Me.MenuBar.SuspendLayout()
        Me.StatusBar.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuBar
        '
        Me.MenuBar.BackgroundImage = CType(resources.GetObject("MenuBar.BackgroundImage"), System.Drawing.Image)
        Me.MenuBar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.MenuBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FilToolStripMenuItem, Me.RedigerToolStripMenuItem})
        Me.MenuBar.Location = New System.Drawing.Point(0, 0)
        Me.MenuBar.Name = "MenuBar"
        Me.MenuBar.Size = New System.Drawing.Size(735, 24)
        Me.MenuBar.TabIndex = 0
        '
        'FilToolStripMenuItem
        '
        Me.FilToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NyttIkonToolStripMenuItem, Me.ÅpneIkonToolStripMenuItem, Me.ToolStripSeparator1, Me.LukkIkonToolStripMenuItem, Me.ToolStripSeparator4, Me.LagreIkonToolStripMenuItem, Me.LagreIkonSomToolStripMenuItem, Me.ToolStripSeparator2, Me.LukkToolStripMenuItem})
        Me.FilToolStripMenuItem.Name = "FilToolStripMenuItem"
        Me.FilToolStripMenuItem.Size = New System.Drawing.Size(31, 20)
        Me.FilToolStripMenuItem.Text = "Fil"
        '
        'NyttIkonToolStripMenuItem
        '
        Me.NyttIkonToolStripMenuItem.Name = "NyttIkonToolStripMenuItem"
        Me.NyttIkonToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NyttIkonToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.NyttIkonToolStripMenuItem.Text = "Nytt ikon..."
        '
        'ÅpneIkonToolStripMenuItem
        '
        Me.ÅpneIkonToolStripMenuItem.Name = "ÅpneIkonToolStripMenuItem"
        Me.ÅpneIkonToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ÅpneIkonToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ÅpneIkonToolStripMenuItem.Text = "Åpne ikon..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(224, 6)
        '
        'LukkIkonToolStripMenuItem
        '
        Me.LukkIkonToolStripMenuItem.Enabled = False
        Me.LukkIkonToolStripMenuItem.Name = "LukkIkonToolStripMenuItem"
        Me.LukkIkonToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.W), System.Windows.Forms.Keys)
        Me.LukkIkonToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.LukkIkonToolStripMenuItem.Text = "Lukk ikon"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(224, 6)
        '
        'LagreIkonToolStripMenuItem
        '
        Me.LagreIkonToolStripMenuItem.Enabled = False
        Me.LagreIkonToolStripMenuItem.Name = "LagreIkonToolStripMenuItem"
        Me.LagreIkonToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.LagreIkonToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.LagreIkonToolStripMenuItem.Text = "Lagre ikon..."
        '
        'LagreIkonSomToolStripMenuItem
        '
        Me.LagreIkonSomToolStripMenuItem.Enabled = False
        Me.LagreIkonSomToolStripMenuItem.Name = "LagreIkonSomToolStripMenuItem"
        Me.LagreIkonSomToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Alt) _
                    Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.LagreIkonSomToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.LagreIkonSomToolStripMenuItem.Text = "Lagre ikon som..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(224, 6)
        '
        'LukkToolStripMenuItem
        '
        Me.LukkToolStripMenuItem.Name = "LukkToolStripMenuItem"
        Me.LukkToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F4), System.Windows.Forms.Keys)
        Me.LukkToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.LukkToolStripMenuItem.Text = "Lukk"
        '
        'RedigerToolStripMenuItem
        '
        Me.RedigerToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LeggTilEtIkonToolStripMenuItem, Me.ToolStripSeparator3, Me.FjernIkonToolStripMenuItem})
        Me.RedigerToolStripMenuItem.Name = "RedigerToolStripMenuItem"
        Me.RedigerToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.RedigerToolStripMenuItem.Text = "Rediger"
        '
        'LeggTilEtIkonToolStripMenuItem
        '
        Me.LeggTilEtIkonToolStripMenuItem.Enabled = False
        Me.LeggTilEtIkonToolStripMenuItem.Name = "LeggTilEtIkonToolStripMenuItem"
        Me.LeggTilEtIkonToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.A), System.Windows.Forms.Keys)
        Me.LeggTilEtIkonToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.LeggTilEtIkonToolStripMenuItem.Text = "Legg til et ikon..."
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(200, 6)
        '
        'FjernIkonToolStripMenuItem
        '
        Me.FjernIkonToolStripMenuItem.Enabled = False
        Me.FjernIkonToolStripMenuItem.Name = "FjernIkonToolStripMenuItem"
        Me.FjernIkonToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete
        Me.FjernIkonToolStripMenuItem.Size = New System.Drawing.Size(203, 22)
        Me.FjernIkonToolStripMenuItem.Text = "Fjern ikon..."
        '
        'LeftPanel
        '
        Me.LeftPanel.AllowDrop = True
        Me.LeftPanel.AutoScroll = True
        Me.LeftPanel.BackgroundImage = CType(resources.GetObject("LeftPanel.BackgroundImage"), System.Drawing.Image)
        Me.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.LeftPanel.Location = New System.Drawing.Point(0, 24)
        Me.LeftPanel.Name = "LeftPanel"
        Me.LeftPanel.Size = New System.Drawing.Size(125, 512)
        Me.LeftPanel.TabIndex = 1
        '
        'IconPanel
        '
        Me.IconPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.IconPanel.Location = New System.Drawing.Point(125, 24)
        Me.IconPanel.Name = "IconPanel"
        Me.IconPanel.Size = New System.Drawing.Size(610, 512)
        Me.IconPanel.TabIndex = 3
        '
        'StatusBar
        '
        Me.StatusBar.AutoSize = False
        Me.StatusBar.BackgroundImage = CType(resources.GetObject("StatusBar.BackgroundImage"), System.Drawing.Image)
        Me.StatusBar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusLabel, Me.SpringLabel})
        Me.StatusBar.Location = New System.Drawing.Point(0, 536)
        Me.StatusBar.Name = "StatusBar"
        Me.StatusBar.Size = New System.Drawing.Size(735, 24)
        Me.StatusBar.SizingGrip = False
        Me.StatusBar.TabIndex = 4
        '
        'StatusLabel
        '
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(0, 19)
        '
        'SpringLabel
        '
        Me.SpringLabel.Name = "SpringLabel"
        Me.SpringLabel.Size = New System.Drawing.Size(720, 19)
        Me.SpringLabel.Spring = True
        '
        'CheckThings
        '
        Me.CheckThings.Enabled = True
        Me.CheckThings.Interval = 1
        '
        'frmIconMerge
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(735, 560)
        Me.Controls.Add(Me.IconPanel)
        Me.Controls.Add(Me.LeftPanel)
        Me.Controls.Add(Me.MenuBar)
        Me.Controls.Add(Me.StatusBar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuBar
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmIconMerge"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ikon fletter..."
        Me.MenuBar.ResumeLayout(False)
        Me.MenuBar.PerformLayout()
        Me.StatusBar.ResumeLayout(False)
        Me.StatusBar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuBar As System.Windows.Forms.MenuStrip
    Friend WithEvents LeftPanel As System.Windows.Forms.Panel
    Friend WithEvents IconPanel As System.Windows.Forms.Panel
    Friend WithEvents StatusBar As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FilToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ÅpneIkonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LagreIkonSomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CheckThings As System.Windows.Forms.Timer
    Friend WithEvents NyttIkonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LukkToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LagreIkonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RedigerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LeggTilEtIkonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents FjernIkonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpringLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents LukkIkonToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
End Class
