<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.DockPanel = New System.Windows.Forms.Panel()
        Me.RestartButton = New System.Windows.Forms.Button()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.StartTabPage = New System.Windows.Forms.TabPage()
        Me.ShowRemoveSelectedIconMessageBoxCheckBox = New System.Windows.Forms.CheckBox()
        Me.ShowRestartMessageBoxCheckBox = New System.Windows.Forms.CheckBox()
        Me.MessageBoxesLabel = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RemoveLangPackButton = New System.Windows.Forms.Button()
        Me.AddLangPackButton = New System.Windows.Forms.Button()
        Me.StartUpLabel = New System.Windows.Forms.Label()
        Me.Line = New System.Windows.Forms.Panel()
        Me.LangLabel = New System.Windows.Forms.Label()
        Me.DoNothingRadioButton = New System.Windows.Forms.RadioButton()
        Me.LangComboBox = New System.Windows.Forms.ComboBox()
        Me.SearchIconsRadioButton = New System.Windows.Forms.RadioButton()
        Me.RestartBar = New Go__ExtractIcons.InfoBar()
        Me.DockPanel.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.StartTabPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'DockPanel
        '
        Me.DockPanel.Controls.Add(Me.RestartButton)
        Me.DockPanel.Controls.Add(Me.OKButton)
        Me.DockPanel.Controls.Add(Me.TabControl1)
        Me.DockPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DockPanel.Location = New System.Drawing.Point(0, 24)
        Me.DockPanel.Name = "DockPanel"
        Me.DockPanel.Size = New System.Drawing.Size(564, 281)
        Me.DockPanel.TabIndex = 0
        '
        'RestartButton
        '
        Me.RestartButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RestartButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RestartButton.Location = New System.Drawing.Point(12, 246)
        Me.RestartButton.Name = "RestartButton"
        Me.RestartButton.Size = New System.Drawing.Size(175, 23)
        Me.RestartButton.TabIndex = 6
        Me.RestartButton.Text = "Restart Go! ExtractIcons"
        Me.RestartButton.UseVisualStyleBackColor = True
        Me.RestartButton.Visible = False
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OKButton.Location = New System.Drawing.Point(477, 246)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 5
        Me.OKButton.Text = "&OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.StartTabPage)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(540, 228)
        Me.TabControl1.TabIndex = 4
        '
        'StartTabPage
        '
        Me.StartTabPage.Controls.Add(Me.ShowRemoveSelectedIconMessageBoxCheckBox)
        Me.StartTabPage.Controls.Add(Me.ShowRestartMessageBoxCheckBox)
        Me.StartTabPage.Controls.Add(Me.MessageBoxesLabel)
        Me.StartTabPage.Controls.Add(Me.Panel1)
        Me.StartTabPage.Controls.Add(Me.RemoveLangPackButton)
        Me.StartTabPage.Controls.Add(Me.AddLangPackButton)
        Me.StartTabPage.Controls.Add(Me.StartUpLabel)
        Me.StartTabPage.Controls.Add(Me.Line)
        Me.StartTabPage.Controls.Add(Me.LangLabel)
        Me.StartTabPage.Controls.Add(Me.DoNothingRadioButton)
        Me.StartTabPage.Controls.Add(Me.LangComboBox)
        Me.StartTabPage.Controls.Add(Me.SearchIconsRadioButton)
        Me.StartTabPage.Location = New System.Drawing.Point(4, 24)
        Me.StartTabPage.Name = "StartTabPage"
        Me.StartTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.StartTabPage.Size = New System.Drawing.Size(532, 200)
        Me.StartTabPage.TabIndex = 0
        Me.StartTabPage.Text = "Generelt"
        Me.StartTabPage.UseVisualStyleBackColor = True
        '
        'ShowRemoveSelectedIconMessageBoxCheckBox
        '
        Me.ShowRemoveSelectedIconMessageBoxCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ShowRemoveSelectedIconMessageBoxCheckBox.AutoSize = True
        Me.ShowRemoveSelectedIconMessageBoxCheckBox.Checked = True
        Me.ShowRemoveSelectedIconMessageBoxCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowRemoveSelectedIconMessageBoxCheckBox.Location = New System.Drawing.Point(138, 90)
        Me.ShowRemoveSelectedIconMessageBoxCheckBox.Name = "ShowRemoveSelectedIconMessageBoxCheckBox"
        Me.ShowRemoveSelectedIconMessageBoxCheckBox.Size = New System.Drawing.Size(233, 19)
        Me.ShowRemoveSelectedIconMessageBoxCheckBox.TabIndex = 18
        Me.ShowRemoveSelectedIconMessageBoxCheckBox.Text = "Vis ved fjerning av ikoner i ikon fletter..."
        Me.ShowRemoveSelectedIconMessageBoxCheckBox.UseVisualStyleBackColor = True
        '
        'ShowRestartMessageBoxCheckBox
        '
        Me.ShowRestartMessageBoxCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.ShowRestartMessageBoxCheckBox.AutoSize = True
        Me.ShowRestartMessageBoxCheckBox.Checked = True
        Me.ShowRestartMessageBoxCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ShowRestartMessageBoxCheckBox.Location = New System.Drawing.Point(138, 65)
        Me.ShowRestartMessageBoxCheckBox.Name = "ShowRestartMessageBoxCheckBox"
        Me.ShowRestartMessageBoxCheckBox.Size = New System.Drawing.Size(227, 19)
        Me.ShowRestartMessageBoxCheckBox.TabIndex = 17
        Me.ShowRestartMessageBoxCheckBox.Text = "Vis ved restarting av Go! ExtractIcons..."
        Me.ShowRestartMessageBoxCheckBox.UseVisualStyleBackColor = True
        '
        'MessageBoxesLabel
        '
        Me.MessageBoxesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.MessageBoxesLabel.AutoSize = True
        Me.MessageBoxesLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MessageBoxesLabel.Location = New System.Drawing.Point(17, 66)
        Me.MessageBoxesLabel.Name = "MessageBoxesLabel"
        Me.MessageBoxesLabel.Size = New System.Drawing.Size(101, 15)
        Me.MessageBoxesLabel.TabIndex = 16
        Me.MessageBoxesLabel.Text = "Meldings bokser:"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(20, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(494, 1)
        Me.Panel1.TabIndex = 12
        '
        'RemoveLangPackButton
        '
        Me.RemoveLangPackButton.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.RemoveLangPackButton.Enabled = False
        Me.RemoveLangPackButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RemoveLangPackButton.Location = New System.Drawing.Point(138, 165)
        Me.RemoveLangPackButton.Name = "RemoveLangPackButton"
        Me.RemoveLangPackButton.Size = New System.Drawing.Size(185, 23)
        Me.RemoveLangPackButton.TabIndex = 12
        Me.RemoveLangPackButton.Text = "Fj&ern språkpakke"
        Me.RemoveLangPackButton.UseVisualStyleBackColor = True
        '
        'AddLangPackButton
        '
        Me.AddLangPackButton.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.AddLangPackButton.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AddLangPackButton.Location = New System.Drawing.Point(329, 165)
        Me.AddLangPackButton.Name = "AddLangPackButton"
        Me.AddLangPackButton.Size = New System.Drawing.Size(185, 23)
        Me.AddLangPackButton.TabIndex = 7
        Me.AddLangPackButton.Text = "&Legg til språkpakke"
        Me.AddLangPackButton.UseVisualStyleBackColor = True
        '
        'StartUpLabel
        '
        Me.StartUpLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.StartUpLabel.AutoSize = True
        Me.StartUpLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StartUpLabel.Location = New System.Drawing.Point(17, 21)
        Me.StartUpLabel.Name = "StartUpLabel"
        Me.StartUpLabel.Size = New System.Drawing.Size(85, 15)
        Me.StartUpLabel.TabIndex = 8
        Me.StartUpLabel.Text = "Ved oppstart: "
        '
        'Line
        '
        Me.Line.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Line.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(166, Byte), Integer))
        Me.Line.Location = New System.Drawing.Point(20, 121)
        Me.Line.Name = "Line"
        Me.Line.Size = New System.Drawing.Size(494, 1)
        Me.Line.TabIndex = 11
        '
        'LangLabel
        '
        Me.LangLabel.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LangLabel.AutoSize = True
        Me.LangLabel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LangLabel.Location = New System.Drawing.Point(17, 139)
        Me.LangLabel.Name = "LangLabel"
        Me.LangLabel.Size = New System.Drawing.Size(45, 15)
        Me.LangLabel.TabIndex = 6
        Me.LangLabel.Text = "Språk: "
        '
        'DoNothingRadioButton
        '
        Me.DoNothingRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.DoNothingRadioButton.AutoSize = True
        Me.DoNothingRadioButton.Location = New System.Drawing.Point(305, 19)
        Me.DoNothingRadioButton.Name = "DoNothingRadioButton"
        Me.DoNothingRadioButton.Size = New System.Drawing.Size(102, 19)
        Me.DoNothingRadioButton.TabIndex = 10
        Me.DoNothingRadioButton.Text = "Ikke gjør noe..."
        Me.DoNothingRadioButton.UseVisualStyleBackColor = True
        '
        'LangComboBox
        '
        Me.LangComboBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LangComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.LangComboBox.FormattingEnabled = True
        Me.LangComboBox.Location = New System.Drawing.Point(138, 136)
        Me.LangComboBox.Name = "LangComboBox"
        Me.LangComboBox.Size = New System.Drawing.Size(376, 23)
        Me.LangComboBox.Sorted = True
        Me.LangComboBox.TabIndex = 7
        '
        'SearchIconsRadioButton
        '
        Me.SearchIconsRadioButton.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.SearchIconsRadioButton.AutoSize = True
        Me.SearchIconsRadioButton.Checked = True
        Me.SearchIconsRadioButton.Location = New System.Drawing.Point(138, 19)
        Me.SearchIconsRadioButton.Name = "SearchIconsRadioButton"
        Me.SearchIconsRadioButton.Size = New System.Drawing.Size(116, 19)
        Me.SearchIconsRadioButton.TabIndex = 9
        Me.SearchIconsRadioButton.TabStop = True
        Me.SearchIconsRadioButton.Text = "Søk etter ikoner..."
        Me.SearchIconsRadioButton.UseVisualStyleBackColor = True
        '
        'RestartBar
        '
        Me.RestartBar.BackgroundImage = CType(resources.GetObject("RestartBar.BackgroundImage"), System.Drawing.Image)
        Me.RestartBar.CloseButtonContextMenuStrip = Nothing
        Me.RestartBar.Dock = System.Windows.Forms.DockStyle.Top
        Me.RestartBar.Icon = CType(resources.GetObject("RestartBar.Icon"), System.Drawing.Image)
        Me.RestartBar.Location = New System.Drawing.Point(0, 0)
        Me.RestartBar.Message = "Start Go! ExtractIcons på nytt for at endringen skal tre i kraft..."
        Me.RestartBar.Name = "RestartBar"
        Me.RestartBar.Size = New System.Drawing.Size(564, 24)
        Me.RestartBar.TabIndex = 2
        Me.RestartBar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RestartBar.Visible = False
        '
        'frmOptions
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(564, 305)
        Me.Controls.Add(Me.DockPanel)
        Me.Controls.Add(Me.RestartBar)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(570, 309)
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alternativer..."
        Me.DockPanel.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.StartTabPage.ResumeLayout(False)
        Me.StartTabPage.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DockPanel As System.Windows.Forms.Panel
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents StartTabPage As System.Windows.Forms.TabPage
    Friend WithEvents StartUpLabel As System.Windows.Forms.Label
    Friend WithEvents Line As System.Windows.Forms.Panel
    Friend WithEvents LangLabel As System.Windows.Forms.Label
    Friend WithEvents DoNothingRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents LangComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents SearchIconsRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents RestartButton As System.Windows.Forms.Button
    Friend WithEvents AddLangPackButton As System.Windows.Forms.Button
    Friend WithEvents RemoveLangPackButton As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ShowRemoveSelectedIconMessageBoxCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ShowRestartMessageBoxCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents MessageBoxesLabel As System.Windows.Forms.Label
    Friend WithEvents RestartBar As Go__ExtractIcons.InfoBar
End Class
