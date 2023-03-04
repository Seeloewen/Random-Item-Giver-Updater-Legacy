<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.btnQuitWithoutSaving = New System.Windows.Forms.Button()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.SettingsFilePreset = New System.Windows.Forms.RichTextBox()
        Me.ofdImportSettings = New System.Windows.Forms.OpenFileDialog()
        Me.fbdExportSettings = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblResetWarning = New System.Windows.Forms.Label()
        Me.btnResetSoftware = New System.Windows.Forms.Button()
        Me.lblResetSoftware = New System.Windows.Forms.Label()
        Me.btnExportSettings = New System.Windows.Forms.Button()
        Me.btnImportSettings = New System.Windows.Forms.Button()
        Me.lblImportExportSettings = New System.Windows.Forms.Label()
        Me.cbHideBetaWarning = New System.Windows.Forms.CheckBox()
        Me.lblBetaWarning = New System.Windows.Forms.Label()
        Me.lblLogging = New System.Windows.Forms.Label()
        Me.cbDisableLogging = New System.Windows.Forms.CheckBox()
        Me.btnViewTempDir = New System.Windows.Forms.Button()
        Me.lblTempFiles = New System.Windows.Forms.Label()
        Me.btnClearTempFiles = New System.Windows.Forms.Button()
        Me.gbGeneral1 = New System.Windows.Forms.GroupBox()
        Me.cbxDesign = New System.Windows.Forms.ComboBox()
        Me.lblDesign = New System.Windows.Forms.Label()
        Me.btnOpenLogDirectory = New System.Windows.Forms.Button()
        Me.cbAutoSaveLogs = New System.Windows.Forms.CheckBox()
        Me.lblAutoSaveLogs = New System.Windows.Forms.Label()
        Me.cbUseAdvancedViewByDefault = New System.Windows.Forms.CheckBox()
        Me.lblAdvancedViewByDefault = New System.Windows.Forms.Label()
        Me.gbGeneral2 = New System.Windows.Forms.GroupBox()
        Me.gbSchemes = New System.Windows.Forms.GroupBox()
        Me.cbxDefaultScheme = New System.Windows.Forms.ComboBox()
        Me.btnRestoreDefaultSchemes = New System.Windows.Forms.Button()
        Me.lblRestoreDefaultSchemes = New System.Windows.Forms.Label()
        Me.lblEditSchemeEditor = New System.Windows.Forms.Label()
        Me.cbSelectDefaultScheme = New System.Windows.Forms.CheckBox()
        Me.gbItemListImporter = New System.Windows.Forms.GroupBox()
        Me.cbDontImportVanillaItemsByDefault = New System.Windows.Forms.CheckBox()
        Me.lblDefaultSettingsItemImporter = New System.Windows.Forms.Label()
        Me.gbDatapackProfiles = New System.Windows.Forms.GroupBox()
        Me.cbxDefaultProfile = New System.Windows.Forms.ComboBox()
        Me.lblEditProfiles = New System.Windows.Forms.Label()
        Me.cbLoadDefaultProfile = New System.Windows.Forms.CheckBox()
        Me.btnOpenProfileEditor = New System.Windows.Forms.Button()
        Me.btnNavItemListImporter = New System.Windows.Forms.Button()
        Me.btnNavSchemes = New System.Windows.Forms.Button()
        Me.btnNavDatapackProfiles = New System.Windows.Forms.Button()
        Me.btnNavGeneral2 = New System.Windows.Forms.Button()
        Me.btnNavGeneral1 = New System.Windows.Forms.Button()
        Me.pbSettingsNavigationBar = New System.Windows.Forms.PictureBox()
        Me.gbGeneral1.SuspendLayout()
        Me.gbGeneral2.SuspendLayout()
        Me.gbSchemes.SuspendLayout()
        Me.gbItemListImporter.SuspendLayout()
        Me.gbDatapackProfiles.SuspendLayout()
        CType(Me.pbSettingsNavigationBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(61, 26)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(98, 25)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Settings"
        '
        'btnQuitWithoutSaving
        '
        Me.btnQuitWithoutSaving.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnQuitWithoutSaving.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnQuitWithoutSaving.FlatAppearance.BorderSize = 0
        Me.btnQuitWithoutSaving.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnQuitWithoutSaving.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnQuitWithoutSaving.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuitWithoutSaving.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitWithoutSaving.ForeColor = System.Drawing.Color.White
        Me.btnQuitWithoutSaving.Location = New System.Drawing.Point(232, 455)
        Me.btnQuitWithoutSaving.Name = "btnQuitWithoutSaving"
        Me.btnQuitWithoutSaving.Size = New System.Drawing.Size(250, 34)
        Me.btnQuitWithoutSaving.TabIndex = 5
        Me.btnQuitWithoutSaving.Text = "Quit without saving"
        Me.btnQuitWithoutSaving.UseVisualStyleBackColor = True
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnSaveSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSaveSettings.FlatAppearance.BorderSize = 0
        Me.btnSaveSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSaveSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveSettings.ForeColor = System.Drawing.Color.White
        Me.btnSaveSettings.Location = New System.Drawing.Point(488, 455)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(244, 34)
        Me.btnSaveSettings.TabIndex = 6
        Me.btnSaveSettings.Text = "Save settings"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'SettingsFilePreset
        '
        Me.SettingsFilePreset.Location = New System.Drawing.Point(17, 662)
        Me.SettingsFilePreset.Name = "SettingsFilePreset"
        Me.SettingsFilePreset.Size = New System.Drawing.Size(237, 133)
        Me.SettingsFilePreset.TabIndex = 8
        Me.SettingsFilePreset.Text = resources.GetString("SettingsFilePreset.Text")
        '
        'ofdImportSettings
        '
        Me.ofdImportSettings.Title = "Select settings file to import..."
        '
        'fbdExportSettings
        '
        Me.fbdExportSettings.Description = "Select the folder in which you want to save the exported settings file."
        Me.fbdExportSettings.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'lblResetWarning
        '
        Me.lblResetWarning.AutoSize = True
        Me.lblResetWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResetWarning.ForeColor = System.Drawing.Color.OrangeRed
        Me.lblResetWarning.Location = New System.Drawing.Point(244, 362)
        Me.lblResetWarning.Name = "lblResetWarning"
        Me.lblResetWarning.Size = New System.Drawing.Size(162, 16)
        Me.lblResetWarning.TabIndex = 33
        Me.lblResetWarning.Text = "Warning: Use with caution!"
        Me.lblResetWarning.Visible = False
        '
        'btnResetSoftware
        '
        Me.btnResetSoftware.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnResetSoftware.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnResetSoftware.FlatAppearance.BorderSize = 0
        Me.btnResetSoftware.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnResetSoftware.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnResetSoftware.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetSoftware.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetSoftware.ForeColor = System.Drawing.Color.White
        Me.btnResetSoftware.Location = New System.Drawing.Point(10, 359)
        Me.btnResetSoftware.Name = "btnResetSoftware"
        Me.btnResetSoftware.Size = New System.Drawing.Size(228, 23)
        Me.btnResetSoftware.TabIndex = 32
        Me.btnResetSoftware.Text = "Reset software"
        Me.btnResetSoftware.UseVisualStyleBackColor = True
        '
        'lblResetSoftware
        '
        Me.lblResetSoftware.AutoSize = True
        Me.lblResetSoftware.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResetSoftware.Location = New System.Drawing.Point(13, 304)
        Me.lblResetSoftware.Name = "lblResetSoftware"
        Me.lblResetSoftware.Size = New System.Drawing.Size(443, 48)
        Me.lblResetSoftware.TabIndex = 31
        Me.lblResetSoftware.Text = resources.GetString("lblResetSoftware.Text")
        '
        'btnExportSettings
        '
        Me.btnExportSettings.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnExportSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnExportSettings.FlatAppearance.BorderSize = 0
        Me.btnExportSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnExportSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnExportSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportSettings.ForeColor = System.Drawing.Color.White
        Me.btnExportSettings.Location = New System.Drawing.Point(244, 264)
        Me.btnExportSettings.Name = "btnExportSettings"
        Me.btnExportSettings.Size = New System.Drawing.Size(228, 23)
        Me.btnExportSettings.TabIndex = 30
        Me.btnExportSettings.Text = "Export settings"
        Me.btnExportSettings.UseVisualStyleBackColor = True
        '
        'btnImportSettings
        '
        Me.btnImportSettings.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnImportSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImportSettings.FlatAppearance.BorderSize = 0
        Me.btnImportSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnImportSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnImportSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImportSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImportSettings.ForeColor = System.Drawing.Color.White
        Me.btnImportSettings.Location = New System.Drawing.Point(10, 264)
        Me.btnImportSettings.Name = "btnImportSettings"
        Me.btnImportSettings.Size = New System.Drawing.Size(228, 23)
        Me.btnImportSettings.TabIndex = 29
        Me.btnImportSettings.Text = "Import settings"
        Me.btnImportSettings.UseVisualStyleBackColor = True
        '
        'lblImportExportSettings
        '
        Me.lblImportExportSettings.AutoSize = True
        Me.lblImportExportSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportExportSettings.Location = New System.Drawing.Point(7, 245)
        Me.lblImportExportSettings.Name = "lblImportExportSettings"
        Me.lblImportExportSettings.Size = New System.Drawing.Size(241, 16)
        Me.lblImportExportSettings.TabIndex = 28
        Me.lblImportExportSettings.Text = "You can import and export settings files."
        '
        'cbHideBetaWarning
        '
        Me.cbHideBetaWarning.AutoSize = True
        Me.cbHideBetaWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbHideBetaWarning.Location = New System.Drawing.Point(13, 208)
        Me.cbHideBetaWarning.Name = "cbHideBetaWarning"
        Me.cbHideBetaWarning.Size = New System.Drawing.Size(181, 20)
        Me.cbHideBetaWarning.TabIndex = 27
        Me.cbHideBetaWarning.Text = "Hide beta version warning"
        Me.cbHideBetaWarning.UseVisualStyleBackColor = True
        '
        'lblBetaWarning
        '
        Me.lblBetaWarning.AutoSize = True
        Me.lblBetaWarning.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBetaWarning.Location = New System.Drawing.Point(7, 189)
        Me.lblBetaWarning.Name = "lblBetaWarning"
        Me.lblBetaWarning.Size = New System.Drawing.Size(288, 16)
        Me.lblBetaWarning.TabIndex = 26
        Me.lblBetaWarning.Text = "There is a warning shown when starting the app."
        '
        'lblLogging
        '
        Me.lblLogging.AutoSize = True
        Me.lblLogging.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogging.Location = New System.Drawing.Point(7, 129)
        Me.lblLogging.Name = "lblLogging"
        Me.lblLogging.Size = New System.Drawing.Size(464, 16)
        Me.lblLogging.TabIndex = 25
        Me.lblLogging.Text = "The software uses a log to make actions more clear and help with debugging."
        '
        'cbDisableLogging
        '
        Me.cbDisableLogging.AutoSize = True
        Me.cbDisableLogging.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDisableLogging.Location = New System.Drawing.Point(13, 148)
        Me.cbDisableLogging.Name = "cbDisableLogging"
        Me.cbDisableLogging.Size = New System.Drawing.Size(244, 20)
        Me.cbDisableLogging.TabIndex = 24
        Me.cbDisableLogging.Text = "Disable logging (Not recommended)"
        Me.cbDisableLogging.UseVisualStyleBackColor = True
        '
        'btnViewTempDir
        '
        Me.btnViewTempDir.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnViewTempDir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnViewTempDir.FlatAppearance.BorderSize = 0
        Me.btnViewTempDir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnViewTempDir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnViewTempDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewTempDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewTempDir.ForeColor = System.Drawing.Color.White
        Me.btnViewTempDir.Location = New System.Drawing.Point(244, 89)
        Me.btnViewTempDir.Name = "btnViewTempDir"
        Me.btnViewTempDir.Size = New System.Drawing.Size(228, 23)
        Me.btnViewTempDir.TabIndex = 23
        Me.btnViewTempDir.Text = "View temporary files directory"
        Me.btnViewTempDir.UseVisualStyleBackColor = True
        '
        'lblTempFiles
        '
        Me.lblTempFiles.AutoSize = True
        Me.lblTempFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTempFiles.Location = New System.Drawing.Point(10, 21)
        Me.lblTempFiles.Name = "lblTempFiles"
        Me.lblTempFiles.Size = New System.Drawing.Size(447, 64)
        Me.lblTempFiles.TabIndex = 22
        Me.lblTempFiles.Text = resources.GetString("lblTempFiles.Text")
        '
        'btnClearTempFiles
        '
        Me.btnClearTempFiles.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnClearTempFiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClearTempFiles.FlatAppearance.BorderSize = 0
        Me.btnClearTempFiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnClearTempFiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnClearTempFiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearTempFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearTempFiles.ForeColor = System.Drawing.Color.White
        Me.btnClearTempFiles.Location = New System.Drawing.Point(10, 89)
        Me.btnClearTempFiles.Name = "btnClearTempFiles"
        Me.btnClearTempFiles.Size = New System.Drawing.Size(228, 23)
        Me.btnClearTempFiles.TabIndex = 21
        Me.btnClearTempFiles.Text = "Clear temporary files"
        Me.btnClearTempFiles.UseVisualStyleBackColor = True
        '
        'gbGeneral1
        '
        Me.gbGeneral1.Controls.Add(Me.cbxDesign)
        Me.gbGeneral1.Controls.Add(Me.lblDesign)
        Me.gbGeneral1.Controls.Add(Me.btnOpenLogDirectory)
        Me.gbGeneral1.Controls.Add(Me.cbAutoSaveLogs)
        Me.gbGeneral1.Controls.Add(Me.lblAutoSaveLogs)
        Me.gbGeneral1.Controls.Add(Me.cbUseAdvancedViewByDefault)
        Me.gbGeneral1.Controls.Add(Me.lblAdvancedViewByDefault)
        Me.gbGeneral1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGeneral1.Location = New System.Drawing.Point(232, 44)
        Me.gbGeneral1.Name = "gbGeneral1"
        Me.gbGeneral1.Size = New System.Drawing.Size(500, 400)
        Me.gbGeneral1.TabIndex = 21
        Me.gbGeneral1.TabStop = False
        Me.gbGeneral1.Text = "General #1"
        '
        'cbxDesign
        '
        Me.cbxDesign.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxDesign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDesign.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxDesign.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDesign.FormattingEnabled = True
        Me.cbxDesign.Items.AddRange(New Object() {"Light", "Dark"})
        Me.cbxDesign.Location = New System.Drawing.Point(9, 258)
        Me.cbxDesign.Name = "cbxDesign"
        Me.cbxDesign.Size = New System.Drawing.Size(210, 24)
        Me.cbxDesign.TabIndex = 20
        '
        'lblDesign
        '
        Me.lblDesign.AutoSize = True
        Me.lblDesign.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesign.Location = New System.Drawing.Point(6, 221)
        Me.lblDesign.Name = "lblDesign"
        Me.lblDesign.Size = New System.Drawing.Size(415, 32)
        Me.lblDesign.TabIndex = 19
        Me.lblDesign.Text = "If you want to change the visual appearance of your software, you can" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "switch the" &
    " design here."
        '
        'btnOpenLogDirectory
        '
        Me.btnOpenLogDirectory.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnOpenLogDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpenLogDirectory.FlatAppearance.BorderSize = 0
        Me.btnOpenLogDirectory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnOpenLogDirectory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnOpenLogDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenLogDirectory.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenLogDirectory.ForeColor = System.Drawing.Color.White
        Me.btnOpenLogDirectory.Location = New System.Drawing.Point(254, 167)
        Me.btnOpenLogDirectory.Name = "btnOpenLogDirectory"
        Me.btnOpenLogDirectory.Size = New System.Drawing.Size(196, 25)
        Me.btnOpenLogDirectory.TabIndex = 18
        Me.btnOpenLogDirectory.Text = "Open log directory"
        Me.btnOpenLogDirectory.UseVisualStyleBackColor = True
        '
        'cbAutoSaveLogs
        '
        Me.cbAutoSaveLogs.AutoSize = True
        Me.cbAutoSaveLogs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAutoSaveLogs.Location = New System.Drawing.Point(9, 170)
        Me.cbAutoSaveLogs.Name = "cbAutoSaveLogs"
        Me.cbAutoSaveLogs.Size = New System.Drawing.Size(168, 20)
        Me.cbAutoSaveLogs.TabIndex = 17
        Me.cbAutoSaveLogs.Text = "Automatically save logs"
        Me.cbAutoSaveLogs.UseVisualStyleBackColor = True
        '
        'lblAutoSaveLogs
        '
        Me.lblAutoSaveLogs.AutoSize = True
        Me.lblAutoSaveLogs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutoSaveLogs.Location = New System.Drawing.Point(6, 117)
        Me.lblAutoSaveLogs.Name = "lblAutoSaveLogs"
        Me.lblAutoSaveLogs.Size = New System.Drawing.Size(460, 48)
        Me.lblAutoSaveLogs.TabIndex = 16
        Me.lblAutoSaveLogs.Text = "If you want to keep track of your past actions, you can enable to automatically" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    "save logs when the app closes. Those files will be kept in the appdata " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "directo" &
    "ry of the app."
        '
        'cbUseAdvancedViewByDefault
        '
        Me.cbUseAdvancedViewByDefault.AutoSize = True
        Me.cbUseAdvancedViewByDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbUseAdvancedViewByDefault.Location = New System.Drawing.Point(9, 72)
        Me.cbUseAdvancedViewByDefault.Name = "cbUseAdvancedViewByDefault"
        Me.cbUseAdvancedViewByDefault.Size = New System.Drawing.Size(206, 20)
        Me.cbUseAdvancedViewByDefault.TabIndex = 15
        Me.cbUseAdvancedViewByDefault.Text = "Use advanced view by default"
        Me.cbUseAdvancedViewByDefault.UseVisualStyleBackColor = True
        '
        'lblAdvancedViewByDefault
        '
        Me.lblAdvancedViewByDefault.AutoSize = True
        Me.lblAdvancedViewByDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdvancedViewByDefault.Location = New System.Drawing.Point(6, 21)
        Me.lblAdvancedViewByDefault.Name = "lblAdvancedViewByDefault"
        Me.lblAdvancedViewByDefault.Size = New System.Drawing.Size(441, 48)
        Me.lblAdvancedViewByDefault.TabIndex = 14
        Me.lblAdvancedViewByDefault.Text = "By default, the software shows only some options in an easy view to make" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "it more" &
    " understandable for non-technical users. If you want to, you can" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "enable that th" &
    "e advanced view gets loaded by default."
        '
        'gbGeneral2
        '
        Me.gbGeneral2.Controls.Add(Me.lblResetWarning)
        Me.gbGeneral2.Controls.Add(Me.lblTempFiles)
        Me.gbGeneral2.Controls.Add(Me.btnResetSoftware)
        Me.gbGeneral2.Controls.Add(Me.btnClearTempFiles)
        Me.gbGeneral2.Controls.Add(Me.lblResetSoftware)
        Me.gbGeneral2.Controls.Add(Me.btnViewTempDir)
        Me.gbGeneral2.Controls.Add(Me.btnExportSettings)
        Me.gbGeneral2.Controls.Add(Me.cbDisableLogging)
        Me.gbGeneral2.Controls.Add(Me.btnImportSettings)
        Me.gbGeneral2.Controls.Add(Me.lblLogging)
        Me.gbGeneral2.Controls.Add(Me.lblImportExportSettings)
        Me.gbGeneral2.Controls.Add(Me.lblBetaWarning)
        Me.gbGeneral2.Controls.Add(Me.cbHideBetaWarning)
        Me.gbGeneral2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbGeneral2.Location = New System.Drawing.Point(228, 524)
        Me.gbGeneral2.Name = "gbGeneral2"
        Me.gbGeneral2.Size = New System.Drawing.Size(500, 400)
        Me.gbGeneral2.TabIndex = 22
        Me.gbGeneral2.TabStop = False
        Me.gbGeneral2.Text = "General #2"
        '
        'gbSchemes
        '
        Me.gbSchemes.Controls.Add(Me.cbxDefaultScheme)
        Me.gbSchemes.Controls.Add(Me.btnRestoreDefaultSchemes)
        Me.gbSchemes.Controls.Add(Me.lblRestoreDefaultSchemes)
        Me.gbSchemes.Controls.Add(Me.lblEditSchemeEditor)
        Me.gbSchemes.Controls.Add(Me.cbSelectDefaultScheme)
        Me.gbSchemes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSchemes.Location = New System.Drawing.Point(742, 524)
        Me.gbSchemes.Name = "gbSchemes"
        Me.gbSchemes.Size = New System.Drawing.Size(500, 400)
        Me.gbSchemes.TabIndex = 23
        Me.gbSchemes.TabStop = False
        Me.gbSchemes.Text = "Schemes"
        '
        'cbxDefaultScheme
        '
        Me.cbxDefaultScheme.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxDefaultScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDefaultScheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxDefaultScheme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDefaultScheme.FormattingEnabled = True
        Me.cbxDefaultScheme.Items.AddRange(New Object() {"Light", "Dark"})
        Me.cbxDefaultScheme.Location = New System.Drawing.Point(9, 129)
        Me.cbxDefaultScheme.Name = "cbxDefaultScheme"
        Me.cbxDefaultScheme.Size = New System.Drawing.Size(301, 24)
        Me.cbxDefaultScheme.TabIndex = 23
        '
        'btnRestoreDefaultSchemes
        '
        Me.btnRestoreDefaultSchemes.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnRestoreDefaultSchemes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRestoreDefaultSchemes.FlatAppearance.BorderSize = 0
        Me.btnRestoreDefaultSchemes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnRestoreDefaultSchemes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnRestoreDefaultSchemes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRestoreDefaultSchemes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestoreDefaultSchemes.ForeColor = System.Drawing.Color.White
        Me.btnRestoreDefaultSchemes.Location = New System.Drawing.Point(9, 236)
        Me.btnRestoreDefaultSchemes.Name = "btnRestoreDefaultSchemes"
        Me.btnRestoreDefaultSchemes.Size = New System.Drawing.Size(301, 23)
        Me.btnRestoreDefaultSchemes.TabIndex = 22
        Me.btnRestoreDefaultSchemes.Text = "Restore Default Schemes"
        Me.btnRestoreDefaultSchemes.UseVisualStyleBackColor = True
        '
        'lblRestoreDefaultSchemes
        '
        Me.lblRestoreDefaultSchemes.AutoSize = True
        Me.lblRestoreDefaultSchemes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRestoreDefaultSchemes.Location = New System.Drawing.Point(6, 175)
        Me.lblRestoreDefaultSchemes.Name = "lblRestoreDefaultSchemes"
        Me.lblRestoreDefaultSchemes.Size = New System.Drawing.Size(454, 48)
        Me.lblRestoreDefaultSchemes.TabIndex = 18
        Me.lblRestoreDefaultSchemes.Text = resources.GetString("lblRestoreDefaultSchemes.Text")
        '
        'lblEditSchemeEditor
        '
        Me.lblEditSchemeEditor.AutoSize = True
        Me.lblEditSchemeEditor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditSchemeEditor.Location = New System.Drawing.Point(6, 21)
        Me.lblEditSchemeEditor.Name = "lblEditSchemeEditor"
        Me.lblEditSchemeEditor.Size = New System.Drawing.Size(450, 64)
        Me.lblEditSchemeEditor.TabIndex = 19
        Me.lblEditSchemeEditor.Text = resources.GetString("lblEditSchemeEditor.Text")
        '
        'cbSelectDefaultScheme
        '
        Me.cbSelectDefaultScheme.AutoSize = True
        Me.cbSelectDefaultScheme.Checked = True
        Me.cbSelectDefaultScheme.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSelectDefaultScheme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSelectDefaultScheme.Location = New System.Drawing.Point(9, 104)
        Me.cbSelectDefaultScheme.Name = "cbSelectDefaultScheme"
        Me.cbSelectDefaultScheme.Size = New System.Drawing.Size(176, 20)
        Me.cbSelectDefaultScheme.TabIndex = 20
        Me.cbSelectDefaultScheme.Text = "Select scheme by default"
        Me.cbSelectDefaultScheme.UseVisualStyleBackColor = True
        '
        'gbItemListImporter
        '
        Me.gbItemListImporter.Controls.Add(Me.cbDontImportVanillaItemsByDefault)
        Me.gbItemListImporter.Controls.Add(Me.lblDefaultSettingsItemImporter)
        Me.gbItemListImporter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbItemListImporter.Location = New System.Drawing.Point(1259, 524)
        Me.gbItemListImporter.Name = "gbItemListImporter"
        Me.gbItemListImporter.Size = New System.Drawing.Size(500, 400)
        Me.gbItemListImporter.TabIndex = 24
        Me.gbItemListImporter.TabStop = False
        Me.gbItemListImporter.Text = "Item List Importer"
        '
        'cbDontImportVanillaItemsByDefault
        '
        Me.cbDontImportVanillaItemsByDefault.AutoSize = True
        Me.cbDontImportVanillaItemsByDefault.Checked = True
        Me.cbDontImportVanillaItemsByDefault.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbDontImportVanillaItemsByDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDontImportVanillaItemsByDefault.Location = New System.Drawing.Point(9, 40)
        Me.cbDontImportVanillaItemsByDefault.Name = "cbDontImportVanillaItemsByDefault"
        Me.cbDontImportVanillaItemsByDefault.Size = New System.Drawing.Size(235, 20)
        Me.cbDontImportVanillaItemsByDefault.TabIndex = 9
        Me.cbDontImportVanillaItemsByDefault.Text = "Don't import vanilla items by default"
        Me.cbDontImportVanillaItemsByDefault.UseVisualStyleBackColor = True
        '
        'lblDefaultSettingsItemImporter
        '
        Me.lblDefaultSettingsItemImporter.AutoSize = True
        Me.lblDefaultSettingsItemImporter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDefaultSettingsItemImporter.Location = New System.Drawing.Point(6, 21)
        Me.lblDefaultSettingsItemImporter.Name = "lblDefaultSettingsItemImporter"
        Me.lblDefaultSettingsItemImporter.Size = New System.Drawing.Size(300, 16)
        Me.lblDefaultSettingsItemImporter.TabIndex = 8
        Me.lblDefaultSettingsItemImporter.Text = "Select the default settings for the Item List Importer"
        '
        'gbDatapackProfiles
        '
        Me.gbDatapackProfiles.Controls.Add(Me.cbxDefaultProfile)
        Me.gbDatapackProfiles.Controls.Add(Me.lblEditProfiles)
        Me.gbDatapackProfiles.Controls.Add(Me.cbLoadDefaultProfile)
        Me.gbDatapackProfiles.Controls.Add(Me.btnOpenProfileEditor)
        Me.gbDatapackProfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatapackProfiles.Location = New System.Drawing.Point(759, 44)
        Me.gbDatapackProfiles.Name = "gbDatapackProfiles"
        Me.gbDatapackProfiles.Size = New System.Drawing.Size(500, 400)
        Me.gbDatapackProfiles.TabIndex = 25
        Me.gbDatapackProfiles.TabStop = False
        Me.gbDatapackProfiles.Text = "Datapack Profiles"
        '
        'cbxDefaultProfile
        '
        Me.cbxDefaultProfile.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxDefaultProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDefaultProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxDefaultProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDefaultProfile.FormattingEnabled = True
        Me.cbxDefaultProfile.Items.AddRange(New Object() {"Light", "Dark"})
        Me.cbxDefaultProfile.Location = New System.Drawing.Point(9, 124)
        Me.cbxDefaultProfile.Name = "cbxDefaultProfile"
        Me.cbxDefaultProfile.Size = New System.Drawing.Size(301, 24)
        Me.cbxDefaultProfile.TabIndex = 21
        '
        'lblEditProfiles
        '
        Me.lblEditProfiles.AutoSize = True
        Me.lblEditProfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditProfiles.Location = New System.Drawing.Point(6, 21)
        Me.lblEditProfiles.Name = "lblEditProfiles"
        Me.lblEditProfiles.Size = New System.Drawing.Size(442, 32)
        Me.lblEditProfiles.TabIndex = 13
        Me.lblEditProfiles.Text = "Edit your profiles which can be saved and loaded in the main window." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "These profi" &
    "les are a combination of datapack path and datapack version."
        '
        'cbLoadDefaultProfile
        '
        Me.cbLoadDefaultProfile.AutoSize = True
        Me.cbLoadDefaultProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLoadDefaultProfile.Location = New System.Drawing.Point(9, 98)
        Me.cbLoadDefaultProfile.Name = "cbLoadDefaultProfile"
        Me.cbLoadDefaultProfile.Size = New System.Drawing.Size(158, 20)
        Me.cbLoadDefaultProfile.TabIndex = 15
        Me.cbLoadDefaultProfile.Text = "Load profile by default"
        Me.cbLoadDefaultProfile.UseVisualStyleBackColor = True
        '
        'btnOpenProfileEditor
        '
        Me.btnOpenProfileEditor.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnOpenProfileEditor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOpenProfileEditor.FlatAppearance.BorderSize = 0
        Me.btnOpenProfileEditor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnOpenProfileEditor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnOpenProfileEditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOpenProfileEditor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenProfileEditor.ForeColor = System.Drawing.Color.White
        Me.btnOpenProfileEditor.Location = New System.Drawing.Point(9, 56)
        Me.btnOpenProfileEditor.Name = "btnOpenProfileEditor"
        Me.btnOpenProfileEditor.Size = New System.Drawing.Size(185, 25)
        Me.btnOpenProfileEditor.TabIndex = 14
        Me.btnOpenProfileEditor.Text = "Open Profile Editor"
        Me.btnOpenProfileEditor.UseVisualStyleBackColor = True
        '
        'btnNavItemListImporter
        '
        Me.btnNavItemListImporter.BackgroundImage = CType(resources.GetObject("btnNavItemListImporter.BackgroundImage"), System.Drawing.Image)
        Me.btnNavItemListImporter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNavItemListImporter.FlatAppearance.BorderSize = 0
        Me.btnNavItemListImporter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNavItemListImporter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNavItemListImporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavItemListImporter.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavItemListImporter.Location = New System.Drawing.Point(15, 239)
        Me.btnNavItemListImporter.Name = "btnNavItemListImporter"
        Me.btnNavItemListImporter.Size = New System.Drawing.Size(186, 37)
        Me.btnNavItemListImporter.TabIndex = 15
        Me.btnNavItemListImporter.Text = "Item List Importer"
        Me.btnNavItemListImporter.UseVisualStyleBackColor = True
        '
        'btnNavSchemes
        '
        Me.btnNavSchemes.BackgroundImage = CType(resources.GetObject("btnNavSchemes.BackgroundImage"), System.Drawing.Image)
        Me.btnNavSchemes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNavSchemes.FlatAppearance.BorderSize = 0
        Me.btnNavSchemes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNavSchemes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNavSchemes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavSchemes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavSchemes.Location = New System.Drawing.Point(15, 202)
        Me.btnNavSchemes.Name = "btnNavSchemes"
        Me.btnNavSchemes.Size = New System.Drawing.Size(186, 37)
        Me.btnNavSchemes.TabIndex = 14
        Me.btnNavSchemes.Text = "Schemes"
        Me.btnNavSchemes.UseVisualStyleBackColor = True
        '
        'btnNavDatapackProfiles
        '
        Me.btnNavDatapackProfiles.BackgroundImage = CType(resources.GetObject("btnNavDatapackProfiles.BackgroundImage"), System.Drawing.Image)
        Me.btnNavDatapackProfiles.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNavDatapackProfiles.FlatAppearance.BorderSize = 0
        Me.btnNavDatapackProfiles.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNavDatapackProfiles.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNavDatapackProfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavDatapackProfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavDatapackProfiles.Location = New System.Drawing.Point(15, 165)
        Me.btnNavDatapackProfiles.Name = "btnNavDatapackProfiles"
        Me.btnNavDatapackProfiles.Size = New System.Drawing.Size(186, 37)
        Me.btnNavDatapackProfiles.TabIndex = 13
        Me.btnNavDatapackProfiles.Text = "Datapack Profiles"
        Me.btnNavDatapackProfiles.UseVisualStyleBackColor = True
        '
        'btnNavGeneral2
        '
        Me.btnNavGeneral2.BackgroundImage = CType(resources.GetObject("btnNavGeneral2.BackgroundImage"), System.Drawing.Image)
        Me.btnNavGeneral2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNavGeneral2.FlatAppearance.BorderSize = 0
        Me.btnNavGeneral2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNavGeneral2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNavGeneral2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavGeneral2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavGeneral2.Location = New System.Drawing.Point(15, 128)
        Me.btnNavGeneral2.Name = "btnNavGeneral2"
        Me.btnNavGeneral2.Size = New System.Drawing.Size(186, 37)
        Me.btnNavGeneral2.TabIndex = 12
        Me.btnNavGeneral2.Text = "General #2"
        Me.btnNavGeneral2.UseVisualStyleBackColor = True
        '
        'btnNavGeneral1
        '
        Me.btnNavGeneral1.BackgroundImage = CType(resources.GetObject("btnNavGeneral1.BackgroundImage"), System.Drawing.Image)
        Me.btnNavGeneral1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNavGeneral1.FlatAppearance.BorderSize = 0
        Me.btnNavGeneral1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNavGeneral1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNavGeneral1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavGeneral1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavGeneral1.Location = New System.Drawing.Point(15, 91)
        Me.btnNavGeneral1.Name = "btnNavGeneral1"
        Me.btnNavGeneral1.Size = New System.Drawing.Size(186, 37)
        Me.btnNavGeneral1.TabIndex = 11
        Me.btnNavGeneral1.Text = "General #1"
        Me.btnNavGeneral1.UseVisualStyleBackColor = True
        '
        'pbSettingsNavigationBar
        '
        Me.pbSettingsNavigationBar.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgSettingsNavigationBar
        Me.pbSettingsNavigationBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbSettingsNavigationBar.Location = New System.Drawing.Point(3, 60)
        Me.pbSettingsNavigationBar.Name = "pbSettingsNavigationBar"
        Me.pbSettingsNavigationBar.Size = New System.Drawing.Size(211, 377)
        Me.pbSettingsNavigationBar.TabIndex = 10
        Me.pbSettingsNavigationBar.TabStop = False
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(744, 500)
        Me.Controls.Add(Me.gbDatapackProfiles)
        Me.Controls.Add(Me.gbItemListImporter)
        Me.Controls.Add(Me.gbSchemes)
        Me.Controls.Add(Me.gbGeneral2)
        Me.Controls.Add(Me.gbGeneral1)
        Me.Controls.Add(Me.btnNavItemListImporter)
        Me.Controls.Add(Me.btnNavSchemes)
        Me.Controls.Add(Me.btnNavDatapackProfiles)
        Me.Controls.Add(Me.btnNavGeneral2)
        Me.Controls.Add(Me.btnNavGeneral1)
        Me.Controls.Add(Me.pbSettingsNavigationBar)
        Me.Controls.Add(Me.SettingsFilePreset)
        Me.Controls.Add(Me.btnSaveSettings)
        Me.Controls.Add(Me.btnQuitWithoutSaving)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.gbGeneral1.ResumeLayout(False)
        Me.gbGeneral1.PerformLayout()
        Me.gbGeneral2.ResumeLayout(False)
        Me.gbGeneral2.PerformLayout()
        Me.gbSchemes.ResumeLayout(False)
        Me.gbSchemes.PerformLayout()
        Me.gbItemListImporter.ResumeLayout(False)
        Me.gbItemListImporter.PerformLayout()
        Me.gbDatapackProfiles.ResumeLayout(False)
        Me.gbDatapackProfiles.PerformLayout()
        CType(Me.pbSettingsNavigationBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents btnQuitWithoutSaving As Button
    Friend WithEvents btnSaveSettings As Button
    Friend WithEvents SettingsFilePreset As RichTextBox
    Friend WithEvents ofdImportSettings As OpenFileDialog
    Friend WithEvents fbdExportSettings As FolderBrowserDialog
    Friend WithEvents pbSettingsNavigationBar As PictureBox
    Friend WithEvents btnNavGeneral1 As Button
    Friend WithEvents btnNavGeneral2 As Button
    Friend WithEvents btnNavDatapackProfiles As Button
    Friend WithEvents btnNavSchemes As Button
    Friend WithEvents btnNavItemListImporter As Button
    Friend WithEvents lblResetWarning As Label
    Friend WithEvents btnResetSoftware As Button
    Friend WithEvents lblResetSoftware As Label
    Friend WithEvents btnExportSettings As Button
    Friend WithEvents btnImportSettings As Button
    Friend WithEvents lblImportExportSettings As Label
    Friend WithEvents cbHideBetaWarning As CheckBox
    Friend WithEvents lblBetaWarning As Label
    Friend WithEvents lblLogging As Label
    Friend WithEvents cbDisableLogging As CheckBox
    Friend WithEvents btnViewTempDir As Button
    Friend WithEvents lblTempFiles As Label
    Friend WithEvents btnClearTempFiles As Button
    Friend WithEvents gbGeneral1 As GroupBox
    Friend WithEvents cbxDesign As ComboBox
    Friend WithEvents lblDesign As Label
    Friend WithEvents btnOpenLogDirectory As Button
    Friend WithEvents cbAutoSaveLogs As CheckBox
    Friend WithEvents lblAutoSaveLogs As Label
    Friend WithEvents cbUseAdvancedViewByDefault As CheckBox
    Friend WithEvents lblAdvancedViewByDefault As Label
    Friend WithEvents gbGeneral2 As GroupBox
    Friend WithEvents gbSchemes As GroupBox
    Friend WithEvents gbItemListImporter As GroupBox
    Friend WithEvents gbDatapackProfiles As GroupBox
    Friend WithEvents btnRestoreDefaultSchemes As Button
    Friend WithEvents lblRestoreDefaultSchemes As Label
    Friend WithEvents lblEditSchemeEditor As Label
    Friend WithEvents cbSelectDefaultScheme As CheckBox
    Friend WithEvents cbDontImportVanillaItemsByDefault As CheckBox
    Friend WithEvents lblDefaultSettingsItemImporter As Label
    Friend WithEvents lblEditProfiles As Label
    Friend WithEvents cbLoadDefaultProfile As CheckBox
    Friend WithEvents btnOpenProfileEditor As Button
    Friend WithEvents cbxDefaultScheme As ComboBox
    Friend WithEvents cbxDefaultProfile As ComboBox
End Class
