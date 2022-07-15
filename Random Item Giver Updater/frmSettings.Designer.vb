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
        Me.lblEditProfiles = New System.Windows.Forms.Label()
        Me.btnQuitWithoutSaving = New System.Windows.Forms.Button()
        Me.btnSaveSettings = New System.Windows.Forms.Button()
        Me.btnClearTempFiles = New System.Windows.Forms.Button()
        Me.btnOpenProfileEditor = New System.Windows.Forms.Button()
        Me.cbLoadDefaultProfile = New System.Windows.Forms.CheckBox()
        Me.cbxDefaultProfile = New System.Windows.Forms.ComboBox()
        Me.tcSettings = New System.Windows.Forms.TabControl()
        Me.tpGeneral = New System.Windows.Forms.TabPage()
        Me.cbUseAdvancedViewByDefault = New System.Windows.Forms.CheckBox()
        Me.lblAdvancedViewByDefault = New System.Windows.Forms.Label()
        Me.tpSoftware = New System.Windows.Forms.TabPage()
        Me.btnExportSettings = New System.Windows.Forms.Button()
        Me.btnImportSettings = New System.Windows.Forms.Button()
        Me.lblImportExportSettings = New System.Windows.Forms.Label()
        Me.cbHideAlphaWarning = New System.Windows.Forms.CheckBox()
        Me.lblAlphaWarning = New System.Windows.Forms.Label()
        Me.lblLogging = New System.Windows.Forms.Label()
        Me.cbDisableLogging = New System.Windows.Forms.CheckBox()
        Me.btnViewTempDir = New System.Windows.Forms.Button()
        Me.lblTempFiles = New System.Windows.Forms.Label()
        Me.tpProfiles = New System.Windows.Forms.TabPage()
        Me.tpSchemes = New System.Windows.Forms.TabPage()
        Me.cbxDefaultScheme = New System.Windows.Forms.ComboBox()
        Me.lblEditSchemeEditor = New System.Windows.Forms.Label()
        Me.cbSelectDefaultScheme = New System.Windows.Forms.CheckBox()
        Me.tpListImporter = New System.Windows.Forms.TabPage()
        Me.cbDontImportVanillaItemsByDefault = New System.Windows.Forms.CheckBox()
        Me.lblDefaultSettingsItemImporter = New System.Windows.Forms.Label()
        Me.SettingsFilePreset = New System.Windows.Forms.RichTextBox()
        Me.ofdImportSettings = New System.Windows.Forms.OpenFileDialog()
        Me.fbdExportSettings = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblRestoreDefaultSchemes = New System.Windows.Forms.Label()
        Me.btnRestoreDefaultSchemes = New System.Windows.Forms.Button()
        Me.tcSettings.SuspendLayout()
        Me.tpGeneral.SuspendLayout()
        Me.tpSoftware.SuspendLayout()
        Me.tpProfiles.SuspendLayout()
        Me.tpSchemes.SuspendLayout()
        Me.tpListImporter.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(13, 13)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(84, 24)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Settings"
        '
        'lblEditProfiles
        '
        Me.lblEditProfiles.AutoSize = True
        Me.lblEditProfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditProfiles.Location = New System.Drawing.Point(10, 16)
        Me.lblEditProfiles.Name = "lblEditProfiles"
        Me.lblEditProfiles.Size = New System.Drawing.Size(442, 32)
        Me.lblEditProfiles.TabIndex = 9
        Me.lblEditProfiles.Text = "Edit your profiles which can be saved and loaded in the main window." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "These profi" &
    "les are a combination of datapack path and datapack version."
        '
        'btnQuitWithoutSaving
        '
        Me.btnQuitWithoutSaving.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitWithoutSaving.Location = New System.Drawing.Point(17, 384)
        Me.btnQuitWithoutSaving.Name = "btnQuitWithoutSaving"
        Me.btnQuitWithoutSaving.Size = New System.Drawing.Size(241, 27)
        Me.btnQuitWithoutSaving.TabIndex = 5
        Me.btnQuitWithoutSaving.Text = "Quit without saving"
        Me.btnQuitWithoutSaving.UseVisualStyleBackColor = True
        '
        'btnSaveSettings
        '
        Me.btnSaveSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveSettings.Location = New System.Drawing.Point(264, 384)
        Me.btnSaveSettings.Name = "btnSaveSettings"
        Me.btnSaveSettings.Size = New System.Drawing.Size(241, 27)
        Me.btnSaveSettings.TabIndex = 6
        Me.btnSaveSettings.Text = "Save settings"
        Me.btnSaveSettings.UseVisualStyleBackColor = True
        '
        'btnClearTempFiles
        '
        Me.btnClearTempFiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearTempFiles.Location = New System.Drawing.Point(9, 82)
        Me.btnClearTempFiles.Name = "btnClearTempFiles"
        Me.btnClearTempFiles.Size = New System.Drawing.Size(228, 23)
        Me.btnClearTempFiles.TabIndex = 8
        Me.btnClearTempFiles.Text = "Clear temporary files"
        Me.btnClearTempFiles.UseVisualStyleBackColor = True
        '
        'btnOpenProfileEditor
        '
        Me.btnOpenProfileEditor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenProfileEditor.Location = New System.Drawing.Point(13, 51)
        Me.btnOpenProfileEditor.Name = "btnOpenProfileEditor"
        Me.btnOpenProfileEditor.Size = New System.Drawing.Size(185, 25)
        Me.btnOpenProfileEditor.TabIndex = 10
        Me.btnOpenProfileEditor.Text = "Open Profile Editor"
        Me.btnOpenProfileEditor.UseVisualStyleBackColor = True
        '
        'cbLoadDefaultProfile
        '
        Me.cbLoadDefaultProfile.AutoSize = True
        Me.cbLoadDefaultProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLoadDefaultProfile.Location = New System.Drawing.Point(13, 93)
        Me.cbLoadDefaultProfile.Name = "cbLoadDefaultProfile"
        Me.cbLoadDefaultProfile.Size = New System.Drawing.Size(158, 20)
        Me.cbLoadDefaultProfile.TabIndex = 11
        Me.cbLoadDefaultProfile.Text = "Load profile by default"
        Me.cbLoadDefaultProfile.UseVisualStyleBackColor = True
        '
        'cbxDefaultProfile
        '
        Me.cbxDefaultProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDefaultProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDefaultProfile.FormattingEnabled = True
        Me.cbxDefaultProfile.Location = New System.Drawing.Point(13, 119)
        Me.cbxDefaultProfile.Name = "cbxDefaultProfile"
        Me.cbxDefaultProfile.Size = New System.Drawing.Size(301, 24)
        Me.cbxDefaultProfile.TabIndex = 12
        '
        'tcSettings
        '
        Me.tcSettings.Controls.Add(Me.tpGeneral)
        Me.tcSettings.Controls.Add(Me.tpSoftware)
        Me.tcSettings.Controls.Add(Me.tpProfiles)
        Me.tcSettings.Controls.Add(Me.tpSchemes)
        Me.tcSettings.Controls.Add(Me.tpListImporter)
        Me.tcSettings.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcSettings.Location = New System.Drawing.Point(17, 49)
        Me.tcSettings.Name = "tcSettings"
        Me.tcSettings.SelectedIndex = 0
        Me.tcSettings.Size = New System.Drawing.Size(488, 325)
        Me.tcSettings.TabIndex = 7
        '
        'tpGeneral
        '
        Me.tpGeneral.Controls.Add(Me.cbUseAdvancedViewByDefault)
        Me.tpGeneral.Controls.Add(Me.lblAdvancedViewByDefault)
        Me.tpGeneral.Location = New System.Drawing.Point(4, 25)
        Me.tpGeneral.Name = "tpGeneral"
        Me.tpGeneral.Size = New System.Drawing.Size(480, 296)
        Me.tpGeneral.TabIndex = 4
        Me.tpGeneral.Text = "General"
        Me.tpGeneral.UseVisualStyleBackColor = True
        '
        'cbUseAdvancedViewByDefault
        '
        Me.cbUseAdvancedViewByDefault.AutoSize = True
        Me.cbUseAdvancedViewByDefault.Location = New System.Drawing.Point(15, 62)
        Me.cbUseAdvancedViewByDefault.Name = "cbUseAdvancedViewByDefault"
        Me.cbUseAdvancedViewByDefault.Size = New System.Drawing.Size(206, 20)
        Me.cbUseAdvancedViewByDefault.TabIndex = 1
        Me.cbUseAdvancedViewByDefault.Text = "Use advanced view by default"
        Me.cbUseAdvancedViewByDefault.UseVisualStyleBackColor = True
        '
        'lblAdvancedViewByDefault
        '
        Me.lblAdvancedViewByDefault.AutoSize = True
        Me.lblAdvancedViewByDefault.Location = New System.Drawing.Point(12, 11)
        Me.lblAdvancedViewByDefault.Name = "lblAdvancedViewByDefault"
        Me.lblAdvancedViewByDefault.Size = New System.Drawing.Size(441, 48)
        Me.lblAdvancedViewByDefault.TabIndex = 0
        Me.lblAdvancedViewByDefault.Text = "By default, the software shows only some options in an easy view to make" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "it more" &
    " understandable for non-technical users. If you want to, you can" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "enable that th" &
    "e advanced view gets loaded by default."
        '
        'tpSoftware
        '
        Me.tpSoftware.Controls.Add(Me.btnExportSettings)
        Me.tpSoftware.Controls.Add(Me.btnImportSettings)
        Me.tpSoftware.Controls.Add(Me.lblImportExportSettings)
        Me.tpSoftware.Controls.Add(Me.cbHideAlphaWarning)
        Me.tpSoftware.Controls.Add(Me.lblAlphaWarning)
        Me.tpSoftware.Controls.Add(Me.lblLogging)
        Me.tpSoftware.Controls.Add(Me.cbDisableLogging)
        Me.tpSoftware.Controls.Add(Me.btnViewTempDir)
        Me.tpSoftware.Controls.Add(Me.lblTempFiles)
        Me.tpSoftware.Controls.Add(Me.btnClearTempFiles)
        Me.tpSoftware.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpSoftware.Location = New System.Drawing.Point(4, 25)
        Me.tpSoftware.Name = "tpSoftware"
        Me.tpSoftware.Padding = New System.Windows.Forms.Padding(3)
        Me.tpSoftware.Size = New System.Drawing.Size(480, 296)
        Me.tpSoftware.TabIndex = 1
        Me.tpSoftware.Text = "Software"
        Me.tpSoftware.UseVisualStyleBackColor = True
        '
        'btnExportSettings
        '
        Me.btnExportSettings.Location = New System.Drawing.Point(243, 258)
        Me.btnExportSettings.Name = "btnExportSettings"
        Me.btnExportSettings.Size = New System.Drawing.Size(228, 23)
        Me.btnExportSettings.TabIndex = 17
        Me.btnExportSettings.Text = "Export settings"
        Me.btnExportSettings.UseVisualStyleBackColor = True
        '
        'btnImportSettings
        '
        Me.btnImportSettings.Location = New System.Drawing.Point(9, 258)
        Me.btnImportSettings.Name = "btnImportSettings"
        Me.btnImportSettings.Size = New System.Drawing.Size(228, 23)
        Me.btnImportSettings.TabIndex = 16
        Me.btnImportSettings.Text = "Import settings"
        Me.btnImportSettings.UseVisualStyleBackColor = True
        '
        'lblImportExportSettings
        '
        Me.lblImportExportSettings.AutoSize = True
        Me.lblImportExportSettings.Location = New System.Drawing.Point(6, 239)
        Me.lblImportExportSettings.Name = "lblImportExportSettings"
        Me.lblImportExportSettings.Size = New System.Drawing.Size(241, 16)
        Me.lblImportExportSettings.TabIndex = 15
        Me.lblImportExportSettings.Text = "You can import and export settings files."
        '
        'cbHideAlphaWarning
        '
        Me.cbHideAlphaWarning.AutoSize = True
        Me.cbHideAlphaWarning.Location = New System.Drawing.Point(12, 202)
        Me.cbHideAlphaWarning.Name = "cbHideAlphaWarning"
        Me.cbHideAlphaWarning.Size = New System.Drawing.Size(188, 20)
        Me.cbHideAlphaWarning.TabIndex = 14
        Me.cbHideAlphaWarning.Text = "Hide alpha version warning"
        Me.cbHideAlphaWarning.UseVisualStyleBackColor = True
        '
        'lblAlphaWarning
        '
        Me.lblAlphaWarning.AutoSize = True
        Me.lblAlphaWarning.Location = New System.Drawing.Point(6, 183)
        Me.lblAlphaWarning.Name = "lblAlphaWarning"
        Me.lblAlphaWarning.Size = New System.Drawing.Size(288, 16)
        Me.lblAlphaWarning.TabIndex = 13
        Me.lblAlphaWarning.Text = "There is a warning shown when starting the app."
        '
        'lblLogging
        '
        Me.lblLogging.AutoSize = True
        Me.lblLogging.Location = New System.Drawing.Point(6, 123)
        Me.lblLogging.Name = "lblLogging"
        Me.lblLogging.Size = New System.Drawing.Size(464, 16)
        Me.lblLogging.TabIndex = 12
        Me.lblLogging.Text = "The software uses a log to make actions more clear and help with debugging."
        '
        'cbDisableLogging
        '
        Me.cbDisableLogging.AutoSize = True
        Me.cbDisableLogging.Location = New System.Drawing.Point(12, 142)
        Me.cbDisableLogging.Name = "cbDisableLogging"
        Me.cbDisableLogging.Size = New System.Drawing.Size(244, 20)
        Me.cbDisableLogging.TabIndex = 11
        Me.cbDisableLogging.Text = "Disable logging (Not recommended)"
        Me.cbDisableLogging.UseVisualStyleBackColor = True
        '
        'btnViewTempDir
        '
        Me.btnViewTempDir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewTempDir.Location = New System.Drawing.Point(243, 82)
        Me.btnViewTempDir.Name = "btnViewTempDir"
        Me.btnViewTempDir.Size = New System.Drawing.Size(228, 23)
        Me.btnViewTempDir.TabIndex = 10
        Me.btnViewTempDir.Text = "View temporary files directory"
        Me.btnViewTempDir.UseVisualStyleBackColor = True
        '
        'lblTempFiles
        '
        Me.lblTempFiles.AutoSize = True
        Me.lblTempFiles.Location = New System.Drawing.Point(9, 15)
        Me.lblTempFiles.Name = "lblTempFiles"
        Me.lblTempFiles.Size = New System.Drawing.Size(447, 64)
        Me.lblTempFiles.TabIndex = 9
        Me.lblTempFiles.Text = resources.GetString("lblTempFiles.Text")
        '
        'tpProfiles
        '
        Me.tpProfiles.Controls.Add(Me.cbxDefaultProfile)
        Me.tpProfiles.Controls.Add(Me.lblEditProfiles)
        Me.tpProfiles.Controls.Add(Me.cbLoadDefaultProfile)
        Me.tpProfiles.Controls.Add(Me.btnOpenProfileEditor)
        Me.tpProfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tpProfiles.Location = New System.Drawing.Point(4, 25)
        Me.tpProfiles.Name = "tpProfiles"
        Me.tpProfiles.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProfiles.Size = New System.Drawing.Size(480, 296)
        Me.tpProfiles.TabIndex = 0
        Me.tpProfiles.Text = "Datapack Profiles"
        Me.tpProfiles.UseVisualStyleBackColor = True
        '
        'tpSchemes
        '
        Me.tpSchemes.Controls.Add(Me.btnRestoreDefaultSchemes)
        Me.tpSchemes.Controls.Add(Me.lblRestoreDefaultSchemes)
        Me.tpSchemes.Controls.Add(Me.cbxDefaultScheme)
        Me.tpSchemes.Controls.Add(Me.lblEditSchemeEditor)
        Me.tpSchemes.Controls.Add(Me.cbSelectDefaultScheme)
        Me.tpSchemes.Location = New System.Drawing.Point(4, 25)
        Me.tpSchemes.Name = "tpSchemes"
        Me.tpSchemes.Size = New System.Drawing.Size(480, 296)
        Me.tpSchemes.TabIndex = 3
        Me.tpSchemes.Text = "Schemes"
        Me.tpSchemes.UseVisualStyleBackColor = True
        '
        'cbxDefaultScheme
        '
        Me.cbxDefaultScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDefaultScheme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDefaultScheme.FormattingEnabled = True
        Me.cbxDefaultScheme.Location = New System.Drawing.Point(16, 121)
        Me.cbxDefaultScheme.Name = "cbxDefaultScheme"
        Me.cbxDefaultScheme.Size = New System.Drawing.Size(301, 24)
        Me.cbxDefaultScheme.TabIndex = 16
        '
        'lblEditSchemeEditor
        '
        Me.lblEditSchemeEditor.AutoSize = True
        Me.lblEditSchemeEditor.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEditSchemeEditor.Location = New System.Drawing.Point(13, 12)
        Me.lblEditSchemeEditor.Name = "lblEditSchemeEditor"
        Me.lblEditSchemeEditor.Size = New System.Drawing.Size(450, 64)
        Me.lblEditSchemeEditor.TabIndex = 13
        Me.lblEditSchemeEditor.Text = resources.GetString("lblEditSchemeEditor.Text")
        '
        'cbSelectDefaultScheme
        '
        Me.cbSelectDefaultScheme.AutoSize = True
        Me.cbSelectDefaultScheme.Checked = True
        Me.cbSelectDefaultScheme.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSelectDefaultScheme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSelectDefaultScheme.Location = New System.Drawing.Point(16, 95)
        Me.cbSelectDefaultScheme.Name = "cbSelectDefaultScheme"
        Me.cbSelectDefaultScheme.Size = New System.Drawing.Size(176, 20)
        Me.cbSelectDefaultScheme.TabIndex = 15
        Me.cbSelectDefaultScheme.Text = "Select scheme by default"
        Me.cbSelectDefaultScheme.UseVisualStyleBackColor = True
        '
        'tpListImporter
        '
        Me.tpListImporter.Controls.Add(Me.cbDontImportVanillaItemsByDefault)
        Me.tpListImporter.Controls.Add(Me.lblDefaultSettingsItemImporter)
        Me.tpListImporter.Location = New System.Drawing.Point(4, 25)
        Me.tpListImporter.Name = "tpListImporter"
        Me.tpListImporter.Size = New System.Drawing.Size(480, 296)
        Me.tpListImporter.TabIndex = 2
        Me.tpListImporter.Text = "Item List Importer"
        Me.tpListImporter.UseVisualStyleBackColor = True
        '
        'cbDontImportVanillaItemsByDefault
        '
        Me.cbDontImportVanillaItemsByDefault.AutoSize = True
        Me.cbDontImportVanillaItemsByDefault.Checked = True
        Me.cbDontImportVanillaItemsByDefault.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbDontImportVanillaItemsByDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDontImportVanillaItemsByDefault.Location = New System.Drawing.Point(18, 35)
        Me.cbDontImportVanillaItemsByDefault.Name = "cbDontImportVanillaItemsByDefault"
        Me.cbDontImportVanillaItemsByDefault.Size = New System.Drawing.Size(235, 20)
        Me.cbDontImportVanillaItemsByDefault.TabIndex = 7
        Me.cbDontImportVanillaItemsByDefault.Text = "Don't import vanilla items by default"
        Me.cbDontImportVanillaItemsByDefault.UseVisualStyleBackColor = True
        '
        'lblDefaultSettingsItemImporter
        '
        Me.lblDefaultSettingsItemImporter.AutoSize = True
        Me.lblDefaultSettingsItemImporter.Location = New System.Drawing.Point(15, 16)
        Me.lblDefaultSettingsItemImporter.Name = "lblDefaultSettingsItemImporter"
        Me.lblDefaultSettingsItemImporter.Size = New System.Drawing.Size(300, 16)
        Me.lblDefaultSettingsItemImporter.TabIndex = 1
        Me.lblDefaultSettingsItemImporter.Text = "Select the default settings for the Item List Importer"
        '
        'SettingsFilePreset
        '
        Me.SettingsFilePreset.Location = New System.Drawing.Point(21, 469)
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
        '
        'lblRestoreDefaultSchemes
        '
        Me.lblRestoreDefaultSchemes.AutoSize = True
        Me.lblRestoreDefaultSchemes.Location = New System.Drawing.Point(13, 166)
        Me.lblRestoreDefaultSchemes.Name = "lblRestoreDefaultSchemes"
        Me.lblRestoreDefaultSchemes.Size = New System.Drawing.Size(454, 48)
        Me.lblRestoreDefaultSchemes.TabIndex = 9
        Me.lblRestoreDefaultSchemes.Text = resources.GetString("lblRestoreDefaultSchemes.Text")
        '
        'btnRestoreDefaultSchemes
        '
        Me.btnRestoreDefaultSchemes.Location = New System.Drawing.Point(16, 227)
        Me.btnRestoreDefaultSchemes.Name = "btnRestoreDefaultSchemes"
        Me.btnRestoreDefaultSchemes.Size = New System.Drawing.Size(301, 23)
        Me.btnRestoreDefaultSchemes.TabIndex = 17
        Me.btnRestoreDefaultSchemes.Text = "Restore Default Schemes"
        Me.btnRestoreDefaultSchemes.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(523, 422)
        Me.Controls.Add(Me.SettingsFilePreset)
        Me.Controls.Add(Me.tcSettings)
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
        Me.tcSettings.ResumeLayout(False)
        Me.tpGeneral.ResumeLayout(False)
        Me.tpGeneral.PerformLayout()
        Me.tpSoftware.ResumeLayout(False)
        Me.tpSoftware.PerformLayout()
        Me.tpProfiles.ResumeLayout(False)
        Me.tpProfiles.PerformLayout()
        Me.tpSchemes.ResumeLayout(False)
        Me.tpSchemes.PerformLayout()
        Me.tpListImporter.ResumeLayout(False)
        Me.tpListImporter.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents btnQuitWithoutSaving As Button
    Friend WithEvents btnSaveSettings As Button
    Friend WithEvents lblEditProfiles As Label
    Friend WithEvents btnClearTempFiles As Button
    Friend WithEvents cbxDefaultProfile As ComboBox
    Friend WithEvents cbLoadDefaultProfile As CheckBox
    Friend WithEvents btnOpenProfileEditor As Button
    Friend WithEvents tcSettings As TabControl
    Friend WithEvents tpProfiles As TabPage
    Friend WithEvents tpSoftware As TabPage
    Friend WithEvents lblTempFiles As Label
    Friend WithEvents btnViewTempDir As Button
    Friend WithEvents tpListImporter As TabPage
    Friend WithEvents lblLogging As Label
    Friend WithEvents cbDisableLogging As CheckBox
    Friend WithEvents cbDontImportVanillaItemsByDefault As CheckBox
    Friend WithEvents lblDefaultSettingsItemImporter As Label
    Friend WithEvents cbHideAlphaWarning As CheckBox
    Friend WithEvents lblAlphaWarning As Label
    Friend WithEvents tpSchemes As TabPage
    Friend WithEvents cbxDefaultScheme As ComboBox
    Friend WithEvents lblEditSchemeEditor As Label
    Friend WithEvents cbSelectDefaultScheme As CheckBox
    Friend WithEvents lblImportExportSettings As Label
    Friend WithEvents btnExportSettings As Button
    Friend WithEvents btnImportSettings As Button
    Friend WithEvents SettingsFilePreset As RichTextBox
    Friend WithEvents tpGeneral As TabPage
    Friend WithEvents cbUseAdvancedViewByDefault As CheckBox
    Friend WithEvents lblAdvancedViewByDefault As Label
    Friend WithEvents ofdImportSettings As OpenFileDialog
    Friend WithEvents fbdExportSettings As FolderBrowserDialog
    Friend WithEvents btnRestoreDefaultSchemes As Button
    Friend WithEvents lblRestoreDefaultSchemes As Label
End Class
