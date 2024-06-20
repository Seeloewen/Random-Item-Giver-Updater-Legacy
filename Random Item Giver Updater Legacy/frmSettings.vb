Imports System.IO

Public Class frmSettings

    Dim settingsArray As String()
    Dim profileList As String()
    Dim schemeList As String()
    Dim selectedPage As Integer = 1

    ' -- Event handlers --

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load the design
        LoadDesign()

        'Load settings
        cbUseAdvancedViewByDefault.Checked = My.Settings.UseAdvancedViewByDefault
        cbAutoSaveLogs.Checked = My.Settings.AutoSaveLogs
        cbDisableLogging.Checked = My.Settings.DisableLogging
        cbHideBetaWarning.Checked = My.Settings.HideLegacyWarning
        cbLoadDefaultProfile.Checked = My.Settings.LoadDefaultProfile
        cbSelectDefaultScheme.Checked = My.Settings.SelectDefaultScheme
        cbDontImportVanillaItemsByDefault.Checked = My.Settings.DontImportVanillaItemsByDefault

        If My.Settings.Design = "Light" Then
            cbxDesign.SelectedIndex = 0
        ElseIf My.Settings.Design = "Dark" Then
            cbxDesign.SelectedIndex = 1
        ElseIf My.Settings.Design = "System Default" Then
            cbxDesign.SelectedIndex = 2
        End If

        'Load profiles
        If My.Computer.FileSystem.DirectoryExists(frmMain.profileDirectory) = False Then
            My.Computer.FileSystem.CreateDirectory(frmMain.profileDirectory)
        End If

        cbxDefaultProfile.Items.Clear()
        GetProfileFiles(frmMain.profileDirectory)

        If My.Settings.LoadDefaultProfile Then
            cbLoadDefaultProfile.Checked = True
            If Not String.IsNullOrEmpty(My.Settings.DefaultProfile) Then
                If My.Computer.FileSystem.FileExists($"{frmMain.profileDirectory}{My.Settings.DefaultProfile}.txt") Then
                    cbxDefaultProfile.SelectedItem = My.Settings.DefaultProfile
                Else
                    MsgBox("Error: Default profile no longer exists. Option will be disabled automatically.", MsgBoxStyle.Critical, "Error")
                    cbLoadDefaultProfile.Checked = False
                    My.Settings.LoadDefaultProfile = False
                End If
            Else
                MsgBox("Error: Could not load default profile as it is empty. Option will be disabled automatically.", MsgBoxStyle.Critical, "Error")
                cbLoadDefaultProfile.Checked = False
                My.Settings.LoadDefaultProfile = False
            End If
        End If

        'Load Schemes
        If Not My.Computer.FileSystem.DirectoryExists(frmMain.schemeDirectory) Then
            My.Computer.FileSystem.CreateDirectory(frmMain.schemeDirectory)
        End If

        cbxDefaultScheme.Items.Clear()
        GetSchemeFiles(frmMain.schemeDirectory)

        If My.Settings.SelectDefaultScheme Then
            cbSelectDefaultScheme.Checked = True
            If Not String.IsNullOrEmpty(My.Settings.DefaultScheme) Then
                If My.Computer.FileSystem.FileExists($"{frmMain.schemeDirectory}{My.Settings.DefaultScheme}.txt") Then
                    cbxDefaultScheme.SelectedItem = My.Settings.DefaultScheme
                Else
                    MsgBox("Error: Default scheme no longer exists. Option will be disabled automatically.", MsgBoxStyle.Critical, "Error")
                    cbSelectDefaultScheme.Checked = False
                    My.Settings.SelectDefaultScheme = False
                End If
            Else
                MsgBox("Error: Could not load default scheme as it is empty. Option will be disabled automatically.", MsgBoxStyle.Critical, "Error")
                cbSelectDefaultScheme.Checked = False
                My.Settings.SelectDefaultScheme = False
            End If
        End If

        'Hide reset warning
        lblResetWarning.Hide()

        'Move all group boxes to the right position
        gbGeneral1.Top = 44
        gbGeneral1.Left = 232
        gbGeneral2.Top = 44
        gbGeneral2.Left = 232
        gbDatapackProfiles.Top = 44
        gbDatapackProfiles.Left = 232
        gbSchemes.Top = 44
        gbSchemes.Left = 232
        gbItemListImporter.Top = 44
        gbItemListImporter.Left = 232

        'Show default settings page
        selectedPage = 1
        If frmMain.design = "Dark" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        ElseIf frmMain.design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        End If
        gbGeneral1.Show()
        gbGeneral2.Hide()
        gbDatapackProfiles.Hide()
        gbSchemes.Hide()
        gbItemListImporter.Hide()
    End Sub

    Private Sub btnOpenLogDirectory_Click(sender As Object, e As EventArgs) Handles btnOpenLogDirectory.Click
        If My.Computer.FileSystem.DirectoryExists(frmMain.logDirectory) Then
            Process.Start("explorer.exe", frmMain.logDirectory)
        Else
            MsgBox("Cannot find log directory, please restart the application.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        'If the settings file exists, save settings. If none exists, create one first.
        If My.Computer.FileSystem.FileExists($"{frmMain.appData}/Random Item Giver Updater Legacy/settings.txt") Then
            SaveSettings($"{frmMain.appData}/Random Item Giver Updater Legacy/settings.txt")
        Else
            My.Computer.FileSystem.WriteAllText($"{frmMain.appData}/Random Item Giver Updater Legacy/settings.txt", "", False)
            SaveSettings($"{frmMain.appData}/Random Item Giver Updater Legacy/settings.txt")
        End If

        'Close settings
        MsgBox("Your settings were successfully saved!" + vbNewLine + "You may need to restart the software for changes to take effect.", MsgBoxStyle.Information, "Saved settings")
        Close()
    End Sub

    Private Sub btnQuitWithoutSaving_Click(sender As Object, e As EventArgs) Handles btnQuitWithoutSaving.Click
        'Show confirmation warning when trying to quit without saving
        Select Case MsgBox("Are you sure you want to quit without saving your settings?", vbQuestion + vbYesNo, "Quit without saving")
            Case Windows.Forms.DialogResult.Yes
                Close()
        End Select
    End Sub

    Private Sub cbSelectDefaultScheme_CheckedChanged(sender As Object, e As EventArgs) Handles cbSelectDefaultScheme.CheckedChanged
        'Toggle Default Scheme option
        If cbSelectDefaultScheme.Checked Then
            cbxDefaultScheme.Enabled = True
        Else
            cbxDefaultScheme.Enabled = False
        End If
    End Sub

    Private Sub cbLoadDefaultProfile_CheckedChanged(sender As Object, e As EventArgs) Handles cbLoadDefaultProfile.CheckedChanged
        'Toggle Default Profile option
        If cbLoadDefaultProfile.Checked Then
            cbxDefaultProfile.Enabled = True
        Else
            cbxDefaultProfile.Enabled = False
        End If
    End Sub

    Private Sub btnNavGeneral1_Click(sender As Object, e As EventArgs) Handles btnNavGeneral1.Click
        'Change button design
        If frmMain.design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf frmMain.design = "Dark" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDark
        End If

        'Show corresponding settings page
        selectedPage = 1
        gbGeneral1.Show()
        gbGeneral2.Hide()
        gbDatapackProfiles.Hide()
        gbSchemes.Hide()
        gbItemListImporter.Hide()
    End Sub

    Private Sub btnNavGeneral2_Click(sender As Object, e As EventArgs) Handles btnNavGeneral2.Click
        'Change button design
        If frmMain.design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf frmMain.design = "Dark" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDark
        End If

        'Show corresponding settings page
        selectedPage = 2
        gbGeneral1.Hide()
        gbGeneral2.Show()
        gbDatapackProfiles.Hide()
        gbSchemes.Hide()
        gbItemListImporter.Hide()
    End Sub

    Private Sub btnNavDatapackProfiles_Click(sender As Object, e As EventArgs) Handles btnNavDatapackProfiles.Click
        'Change button design
        If frmMain.design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf frmMain.design = "Dark" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDark
        End If

        'Show corresponding settings page
        selectedPage = 3
        gbGeneral1.Hide()
        gbGeneral2.Hide()
        gbDatapackProfiles.Show()
        gbSchemes.Hide()
        gbItemListImporter.Hide()
    End Sub

    Private Sub btnNavSchemes_Click(sender As Object, e As EventArgs) Handles btnNavSchemes.Click
        'Change button design
        If frmMain.design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf frmMain.design = "Dark" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDark
        End If

        'Show corresponding settings page
        selectedPage = 4
        gbGeneral1.Hide()
        gbGeneral2.Hide()
        gbDatapackProfiles.Hide()
        gbSchemes.Show()
        gbItemListImporter.Hide()
    End Sub

    Private Sub btnNavItemListImporter_Click(sender As Object, e As EventArgs) Handles btnNavItemListImporter.Click
        'Change button design
        If frmMain.design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmMain.design = "Dark" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If

        'Show corresponding settings page
        selectedPage = 5
        gbGeneral1.Hide()
        gbGeneral2.Hide()
        gbDatapackProfiles.Hide()
        gbSchemes.Hide()
        gbItemListImporter.Show()
    End Sub
    Private Sub btnClearTempFiles_Click(sender As Object, e As EventArgs) Handles btnClearTempFiles.Click
        'Deletes all temporary files created by the application: Old settings files and Temporary log files
        Try
            If My.Computer.FileSystem.FileExists($"{frmMain.appData}\Random Item Giver Updater Legacy\settings.old") Then
                My.Computer.FileSystem.DeleteFile($"{frmMain.appData}\Random Item Giver Updater Legacy\settings.old")
            End If
            If My.Computer.FileSystem.FileExists($"{frmMain.appData}\Random Item Giver Updater Legacy\DebugLogTemp") Then
                My.Computer.FileSystem.DeleteFile($"{frmMain.appData}\Random Item Giver Updater Legacy\DebugLogTemp")
            End If
            MsgBox("Successfully deleted all temporary files.", MsgBoxStyle.Information, "Cleared temporary files")
            frmMain.WriteToLog("Deleted all temporary files.", "Info")
        Catch ex As Exception
            MsgBox($"Could not delete temporary files: {ex.Message}", MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog($"Could not delete temporary files: {ex.Message}", "Error")
        End Try
    End Sub

    Private Sub btnViewTempDir_Click(sender As Object, e As EventArgs) Handles btnViewTempDir.Click
        'Open directory, where the application saves its temporary files in explorer.
        If My.Computer.FileSystem.DirectoryExists($"{frmMain.appData}\Random Item Giver Updater Legacy") Then
            Process.Start("explorer.exe", $"{frmMain.appData}\Random Item Giver Updater Legacy")
        Else
            MsgBox("Cannot find directory, please restart the application.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnImportSettings_Click(sender As Object, e As EventArgs) Handles btnImportSettings.Click
        'Open settings import dialog
        ofdImportSettings.ShowDialog()
    End Sub

    Private Sub ofdImportSettings_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdImportSettings.FileOk
        frmMain.WriteToLog("Importing settings...", "Info")

        'Read lines from selected file into the main settings file and restart application to apply them
        Try
            File.WriteAllLines($"{frmMain.appData}\Random Item Giver Updater Legacy\settings.txt", File.ReadAllLines(ofdImportSettings.FileName))
            MsgBox("Successfully imported settings!" + vbNewLine + "Click 'OK' to close the application and apply them.", MsgBoxStyle.Information, "Imported settings")
            frmMain.WriteToLog($"Successfully imported settings from file {ofdImportSettings.FileName}", "Info")
            frmMain.Close()
        Catch ex As Exception
            MsgBox($"Could not import settings: {ex.Message}", MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog($"Could not import settings: {ex.Message}", "Error")
        End Try
    End Sub

    Private Sub btnExportSettings_Click(sender As Object, e As EventArgs) Handles btnExportSettings.Click
        fbdExportSettings.ShowDialog()

        'Saves a copy of the settings file to the selected location
        Try
            File.WriteAllLines($"{fbdExportSettings.SelectedPath}\RandomItemGiverUpdaterLegacySettingsExported.txt", File.ReadAllLines($"{frmMain.appData}/Random Item Giver Updater Legacy/settings.txt"))
            MsgBox($"Successfully exported your settings to {fbdExportSettings.SelectedPath}\RandomItemGiverUpdaterLegacySettingsExported.txt", MsgBoxStyle.Information, "Successfully exported settings")
        Catch ex As Exception
            MsgBox($"Could not export settings: {ex.Message}", MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog($"Could not export settings: {ex.Message}", "Error")
        End Try
    End Sub

    Private Sub btnOpenProfileEditor_Click(sender As Object, e As EventArgs) Handles btnOpenProfileEditor.Click
        'Show profile editor
        frmProfileEditor.ShowDialog()
    End Sub

    Private Sub btnRestoreDefaultSchemes_Click(sender As Object, e As EventArgs) Handles btnRestoreDefaultSchemes.Click
        'Add all default schemes back to the main window
        frmMain.AddDefaultSchemes()
        MsgBox("Default Schemes were successfully restored! You may need to restart the application to see them.", MsgBoxStyle.Information, "Restored Default Schemes")
    End Sub

    Private Sub btnResetSoftware_MouseEnter(sender As Object, e As EventArgs) Handles btnResetSoftware.MouseEnter
        'Show warning label when mouse enters the reset button
        lblResetWarning.Show()
    End Sub

    Private Sub btnResetSoftware_MouseLeave(sender As Object, e As EventArgs) Handles btnResetSoftware.MouseLeave
        'Hide warning label when mouse leaves the reset button
        lblResetWarning.Hide()
    End Sub

    Private Sub btnResetSoftware_Click(sender As Object, e As EventArgs) Handles btnResetSoftware.Click
        'Show warning that all settings, profiles, schemes etc. will be deleted. If continued, it will delete the mentioned files, reset the internal settings and close the application
        Select Case MsgBox("Warning: Resetting the software deletes all user settings, profiles, schemes and other files saved by the application. This does NOT uninstall the software, but rather delete its user preferences. Only continue if you know what you are doing. Are you sure you want to continue?", vbExclamation + vbYesNo, "Reset software")
            Case Windows.Forms.DialogResult.Yes
                My.Computer.FileSystem.DeleteDirectory($"{frmMain.appData}/Random Item Giver Updater Legacy/", FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Settings.Reset()
                MsgBox("All profiles, schemes, user settings and other application files have been deleted. The software will now close.", MsgBoxStyle.Information, "Cancelled")
                frmMain.Close()
            Case Windows.Forms.DialogResult.No
                MsgBox("Cancelled. No changes have been made.", MsgBoxStyle.Information, "Cancelled")
        End Select
    End Sub

    ' -- Custom methods --

    Private Sub LoadDesign()
        'Load darkmode
        If frmMain.design = "Dark" Then
            'Images
            pbSettingsNavigationBar.BackgroundImage = My.Resources.imgSettingsNavigationBarDark
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDark

            'Textboxes
            For Each ctrl As Control In Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.ForeColor = Color.White
                    ctrl.BackColor = Color.FromArgb(100, 100, 100)
                End If
            Next

            'Groupboxes
            For Each ctrl As Control In Controls
                If TypeOf ctrl Is GroupBox Then
                    ctrl.ForeColor = Color.White
                End If
            Next

            'Labels
            For Each ctrl As Control In Controls
                If TypeOf ctrl Is Label Then
                    ctrl.ForeColor = Color.White
                End If
            Next

            'Checkboxes and radio buttons
            For Each ctrl As Control In Controls
                If TypeOf ctrl Is CheckBox Or TypeOf ctrl Is RadioButton Then
                    ctrl.ForeColor = Color.White
                End If
            Next

            'Comboboxes
            For Each ctrl As Control In Controls
                If TypeOf ctrl Is Button Then
                    btnNavGeneral1.ForeColor = Color.White
                    btnNavGeneral2.ForeColor = Color.White
                    btnNavDatapackProfiles.ForeColor = Color.White
                    btnNavSchemes.ForeColor = Color.White
                    btnNavItemListImporter.ForeColor = Color.White
                End If
            Next

            'Everything else
            BackColor = Color.FromArgb(50, 50, 50)
            cbxDesign.BackColor = Color.DimGray
            cbxDefaultProfile.BackColor = Color.DimGray
            cbxDefaultScheme.BackColor = Color.DimGray
            cbxDesign.ForeColor = Color.White
            cbxDefaultProfile.ForeColor = Color.White
            cbxDefaultScheme.ForeColor = Color.White
        End If

        'Set appearance of buttons depending on selected design
        For Each ctrl As Control In Controls.OfType(Of Button)
            If (Not ctrl.Equals(btnNavGeneral1)) And (Not ctrl.Equals(btnNavGeneral2)) And (Not ctrl.Equals(btnNavDatapackProfiles)) And (Not ctrl.Equals(btnNavSchemes)) And (Not ctrl.Equals(btnNavItemListImporter)) Then
                If frmMain.design = "Dark" Then
                    ctrl.ForeColor = Color.White
                    ctrl.BackgroundImage = My.Resources.imgButton
                ElseIf frmMain.design = "Light" Then
                    ctrl.ForeColor = Color.Black
                    ctrl.BackgroundImage = My.Resources.imgButtonLight
                End If
            End If
        Next

        For Each ctrl As Control In gbGeneral1.Controls.OfType(Of Button)
            If frmMain.design = "Dark" Then
                ctrl.ForeColor = Color.White
                ctrl.BackgroundImage = My.Resources.imgButton
            ElseIf frmMain.design = "Light" Then
                ctrl.ForeColor = Color.Black
                ctrl.BackgroundImage = My.Resources.imgButtonLight
            End If
        Next

        For Each ctrl As Control In gbGeneral2.Controls.OfType(Of Button)
            If frmMain.design = "Dark" Then
                ctrl.ForeColor = Color.White
                ctrl.BackgroundImage = My.Resources.imgButton
            ElseIf frmMain.design = "Light" Then
                ctrl.ForeColor = Color.Black
                ctrl.BackgroundImage = My.Resources.imgButtonLight
            End If
        Next

        For Each ctrl As Control In gbSchemes.Controls.OfType(Of Button)
            If frmMain.design = "Dark" Then
                ctrl.ForeColor = Color.White
                ctrl.BackgroundImage = My.Resources.imgButton
            ElseIf frmMain.design = "Light" Then
                ctrl.ForeColor = Color.Black
                ctrl.BackgroundImage = My.Resources.imgButtonLight
            End If
        Next

        For Each ctrl As Control In gbItemListImporter.Controls.OfType(Of Button)
            If frmMain.design = "Dark" Then
                ctrl.ForeColor = Color.White
                ctrl.BackgroundImage = My.Resources.imgButton
            ElseIf frmMain.design = "Light" Then
                ctrl.ForeColor = Color.Black
                ctrl.BackgroundImage = My.Resources.imgButtonLight
            End If
        Next

        For Each ctrl As Control In gbDatapackProfiles.Controls.OfType(Of Button)
            If frmMain.design = "Dark" Then
                ctrl.ForeColor = Color.White
                ctrl.BackgroundImage = My.Resources.imgButton
            ElseIf frmMain.design = "Light" Then
                ctrl.ForeColor = Color.Black
                ctrl.BackgroundImage = My.Resources.imgButtonLight
            End If
        Next
    End Sub

    Public Sub ResetSettings(path)
        'Reset settings to default and write to file.
        settingsArray = SettingsFilePreset.Lines
        File.WriteAllLines(path, settingsArray)
    End Sub

    Sub GetProfileFiles(path As String)
        'Gets all the profile files from the directory and puts their name into the combobox
        If path.Trim().Length = 0 Then
            Return
        End If

        profileList = Directory.GetFileSystemEntries(path)

        Try
            For Each Profile As String In profileList
                If Directory.Exists(Profile) Then
                    GetProfileFiles(Profile)
                Else
                    Profile = Profile.Replace(path, "").Replace(".txt", "")
                    cbxDefaultProfile.Items.Add(Profile)
                End If
            Next
        Catch ex As Exception
            MsgBox($"Error: Could not load profiles. Please try again.{vbNewLine}Exception: {ex.Message}")
            frmMain.WriteToLog($"Error when loading profiles for Settings: {ex.Message}", "Error")
        End Try
    End Sub

    Sub GetSchemeFiles(path As String)
        'Gets all the scheme files from the directory and puts their name into the combobox
        If path.Trim().Length = 0 Then
            Return
        End If

        schemeList = Directory.GetFileSystemEntries(path)

        Try
            For Each Scheme As String In schemeList
                If Directory.Exists(Scheme) Then
                    GetSchemeFiles(Scheme)
                Else
                    Scheme = Scheme.Replace(path, "").Replace(".txt", "")
                    cbxDefaultScheme.Items.Add(Scheme)
                End If
            Next
        Catch ex As Exception
            MsgBox($"Error: Could not load schemes. Please try again.{vbNewLine}Exception: {ex.Message}")
            frmMain.WriteToLog($"Error when loading schemes for Settings: {ex.Message}", "Error")
        End Try
    End Sub

    Public Sub SaveSettings(settingsFile As String)
        'Save the settings into the settings array
        Try
            frmMain.WriteToLog("Saving settings...", "Info")
            ResetSettings(settingsFile)

            'Load settings into array
            settingsArray = File.ReadAllLines(settingsFile)

            'Set current version number in settings file
            settingsArray(1) = $"Version={frmMain.settingsVersion}"
            frmMain.WriteToLog($"Set version number to {frmMain.settingsVersion}", "Info")

            'Save general 1 settings
            My.Settings.UseAdvancedViewByDefault = cbUseAdvancedViewByDefault.Checked
            settingsArray(4) = $"UseAdvancedViewByDefault={My.Settings.UseAdvancedViewByDefault}"
            frmMain.WriteToLog($"Saved setting {settingsArray(4)}", "Info")

            My.Settings.AutoSaveLogs = cbAutoSaveLogs.Checked
            settingsArray(5) = $"AutoSaveLogs={My.Settings.AutoSaveLogs}"
            frmMain.WriteToLog($"Saved setting {settingsArray(5)}", "Info")

            If cbxDesign.SelectedIndex = 0 Then
                My.Settings.Design = "Light"
            ElseIf cbxDesign.SelectedIndex = 1 Then
                My.Settings.Design = "Dark"
            ElseIf cbxDesign.SelectedIndex = 2 Then
                My.Settings.Design = "System Default"
            End If
            settingsArray(6) = $"Design={My.Settings.Design}"
            frmMain.WriteToLog($"Saved setting {settingsArray(6)}", "Info")

            'Save general 2 Settings
            If cbDisableLogging.Checked Then
                My.Settings.DisableLogging = True
            Else
                My.Settings.DisableLogging = False
                frmOutput.rtbLog.Clear()
            End If
            settingsArray(9) = $"DisableLogging={My.Settings.DisableLogging}"
            frmMain.WriteToLog($"Saved setting {settingsArray(9)}", "Info")

            My.Settings.HideLegacyWarning = cbHideBetaWarning.Checked
            settingsArray(10) = $"HideLegacyWarning={My.Settings.HideLegacyWarning}"
            frmMain.WriteToLog($"Saved setting {settingsArray(10)}", "Info")

            'Save datapack profiles settings
            If cbLoadDefaultProfile.Checked Then
                My.Settings.LoadDefaultProfile = True
                My.Settings.DefaultProfile = cbxDefaultProfile.SelectedItem
            Else
                My.Settings.LoadDefaultProfile = False
            End If
            settingsArray(13) = $"LoadDefaultProfile={My.Settings.LoadDefaultProfile}"
            frmMain.WriteToLog($"Saved setting {settingsArray(13)}", "Info")
            settingsArray(14) = $"DefaultProfile={My.Settings.DefaultProfile}"
            frmMain.WriteToLog($"Saved setting {settingsArray(14)}", "Info")

            'Save scheme settings
            If cbSelectDefaultScheme.Checked Then
                My.Settings.SelectDefaultScheme = True
                My.Settings.DefaultScheme = cbxDefaultScheme.Text
            Else
                My.Settings.SelectDefaultScheme = False
            End If
            If String.IsNullOrEmpty(My.Settings.DefaultScheme) Then
                My.Settings.DefaultScheme = "Normal Item"
            End If
            settingsArray(17) = $"SelectDefaultScheme={My.Settings.SelectDefaultScheme}"
            frmMain.WriteToLog($"Saved setting {settingsArray(17)}", "Info")
            settingsArray(18) = $"DefaultScheme={My.Settings.DefaultScheme}"
            frmMain.WriteToLog($"Saved setting {settingsArray(18)}", "Info")

            'Save Item List Importer Settings
            My.Settings.DontImportVanillaItemsByDefault = cbDontImportVanillaItemsByDefault.Checked
            settingsArray(21) = $"DontImportVanillaItemsByDefault={My.Settings.DontImportVanillaItemsByDefault}"
            frmMain.WriteToLog($"Saved setting {settingsArray(21)}", "Info")

            'Write settings array to file
            File.WriteAllLines($"{frmMain.appData}/Random Item Giver Updater Legacy/settings.txt", settingsArray)
        Catch ex As Exception
            MsgBox($"Could not save settings: {ex.Message}", MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog($"Could not save settings: {ex.Message}", "Error")
        End Try
    End Sub

    '-- Button animations --

    Private Sub btnNavGeneral1_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavGeneral1.MouseDown
        If frmMain.design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmMain.design = "Dark" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavGeneral1_MouseEnter(sender As Object, e As EventArgs) Handles btnNavGeneral1.MouseEnter
        If (selectedPage = 1) = False Then
            If frmMain.design = "Light" Then
                btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf frmMain.design = "Dark" Then
                btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavGeneral1_MouseLeave(sender As Object, e As EventArgs) Handles btnNavGeneral1.MouseLeave
        If (selectedPage = 1) = False Then
            If frmMain.design = "Light" Then
                btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmMain.design = "Dark" Then
                btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavGeneral1_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavGeneral1.MouseUp
        If (selectedPage = 1) = False Then
            If frmMain.design = "Light" Then
                btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmMain.design = "Dark" Then
                btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavGeneral2_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavGeneral2.MouseDown
        If frmMain.design = "Light" Then
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmMain.design = "Dark" Then
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavGeneral2_MouseEnter(sender As Object, e As EventArgs) Handles btnNavGeneral2.MouseEnter
        If (selectedPage = 2) = False Then
            If frmMain.design = "Light" Then
                btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf frmMain.design = "Dark" Then
                btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavGeneral2_MouseLeave(sender As Object, e As EventArgs) Handles btnNavGeneral2.MouseLeave
        If (selectedPage = 2) = False Then
            If frmMain.design = "Light" Then
                btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmMain.design = "Dark" Then
                btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavGeneral2_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavGeneral2.MouseUp
        If (selectedPage = 2) = False Then
            If frmMain.design = "Light" Then
                btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmMain.design = "Dark" Then
                btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavDatapackProfiles_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavDatapackProfiles.MouseDown
        If frmMain.design = "Light" Then
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmMain.design = "Dark" Then
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavDatapackProfiles_MouseEnter(sender As Object, e As EventArgs) Handles btnNavDatapackProfiles.MouseEnter
        If (selectedPage = 3) = False Then
            If frmMain.design = "Light" Then
                btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf frmMain.design = "Dark" Then
                btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavDatapackProfiles_MouseLeave(sender As Object, e As EventArgs) Handles btnNavDatapackProfiles.MouseLeave
        If (selectedPage = 3) = False Then
            If frmMain.design = "Light" Then
                btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmMain.design = "Dark" Then
                btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavDatapackProfiles_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavDatapackProfiles.MouseUp
        If (selectedPage = 3) = False Then
            If frmMain.design = "Light" Then
                btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmMain.design = "Dark" Then
                btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavSchemes_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavSchemes.MouseDown
        If frmMain.design = "Light" Then
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmMain.design = "Dark" Then
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavSchemes_MouseEnter(sender As Object, e As EventArgs) Handles btnNavSchemes.MouseEnter
        If (selectedPage = 4) = False Then
            If frmMain.design = "Light" Then
                btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf frmMain.design = "Dark" Then
                btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavSchemes_MouseLeave(sender As Object, e As EventArgs) Handles btnNavSchemes.MouseLeave
        If (selectedPage = 4) = False Then
            If frmMain.design = "Light" Then
                btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmMain.design = "Dark" Then
                btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavSchemes_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavSchemes.MouseUp
        If (selectedPage = 4) = False Then
            If frmMain.design = "Light" Then
                btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmMain.design = "Dark" Then
                btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavItemListImporter_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavItemListImporter.MouseDown
        If frmMain.design = "Light" Then
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmMain.design = "Dark" Then
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavItemListImporter_MouseEnter(sender As Object, e As EventArgs) Handles btnNavItemListImporter.MouseEnter
        If (selectedPage = 5) = False Then
            If frmMain.design = "Light" Then
                btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf frmMain.design = "Dark" Then
                btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavItemListImporter_MouseLeave(sender As Object, e As EventArgs) Handles btnNavItemListImporter.MouseLeave
        If (selectedPage = 5) = False Then
            If frmMain.design = "Light" Then
                btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmMain.design = "Dark" Then
                btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavItemListImporter_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavItemListImporter.MouseUp
        If (selectedPage = 5) = False Then
            If frmMain.design = "Light" Then
                btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmMain.design = "Dark" Then
                btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnSaveSettings_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSaveSettings.MouseDown
        If frmMain.design = "Dark" Then
            btnSaveSettings.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnSaveSettings.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnSaveSettings_MouseEnter(sender As Object, e As EventArgs) Handles btnSaveSettings.MouseEnter
        If frmMain.design = "Dark" Then
            btnSaveSettings.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnSaveSettings.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnSaveSettings_MouseLeave(sender As Object, e As EventArgs) Handles btnSaveSettings.MouseLeave
        If frmMain.design = "Dark" Then
            btnSaveSettings.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnSaveSettings.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnSaveSettings_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSaveSettings.MouseUp
        If frmMain.design = "Dark" Then
            btnSaveSettings.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnSaveSettings.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnQuitWithoutSaving_MouseDown(sender As Object, e As MouseEventArgs) Handles btnQuitWithoutSaving.MouseDown
        If frmMain.design = "Dark" Then
            btnQuitWithoutSaving.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnQuitWithoutSaving.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnQuitWithoutSaving_MouseEnter(sender As Object, e As EventArgs) Handles btnQuitWithoutSaving.MouseEnter
        If frmMain.design = "Dark" Then
            btnQuitWithoutSaving.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnQuitWithoutSaving.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnQuitWithoutSaving_MouseLeave(sender As Object, e As EventArgs) Handles btnQuitWithoutSaving.MouseLeave
        If frmMain.design = "Dark" Then
            btnQuitWithoutSaving.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnQuitWithoutSaving.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnQuitWithoutSaving_MouseUp(sender As Object, e As MouseEventArgs) Handles btnQuitWithoutSaving.MouseUp
        If frmMain.design = "Dark" Then
            btnQuitWithoutSaving.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnQuitWithoutSaving.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnOpenLogDirectory_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOpenLogDirectory.MouseDown
        If frmMain.design = "Dark" Then
            btnOpenLogDirectory.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnOpenLogDirectory.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnOpenLogDirectory_MouseEnter(sender As Object, e As EventArgs) Handles btnOpenLogDirectory.MouseEnter
        If frmMain.design = "Dark" Then
            btnOpenLogDirectory.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnOpenLogDirectory.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnOpenLogDirectory_MouseLeave(sender As Object, e As EventArgs) Handles btnOpenLogDirectory.MouseLeave
        If frmMain.design = "Dark" Then
            btnOpenLogDirectory.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnOpenLogDirectory.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnOpenLogDirectory_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOpenLogDirectory.MouseUp
        If frmMain.design = "Dark" Then
            btnOpenLogDirectory.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnOpenLogDirectory.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnClearTempFiles_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClearTempFiles.MouseDown
        If frmMain.design = "Dark" Then
            btnClearTempFiles.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnClearTempFiles.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnClearTempFiles_MouseEnter(sender As Object, e As EventArgs) Handles btnClearTempFiles.MouseEnter
        If frmMain.design = "Dark" Then
            btnClearTempFiles.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnClearTempFiles.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnClearTempFiles_MouseLeave(sender As Object, e As EventArgs) Handles btnClearTempFiles.MouseLeave
        If frmMain.design = "Dark" Then
            btnClearTempFiles.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnClearTempFiles.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnClearTempFiles_MouseUp(sender As Object, e As MouseEventArgs) Handles btnClearTempFiles.MouseUp
        If frmMain.design = "Dark" Then
            btnClearTempFiles.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnClearTempFiles.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnViewTempDir_MouseDown(sender As Object, e As MouseEventArgs) Handles btnViewTempDir.MouseDown
        If frmMain.design = "Dark" Then
            btnViewTempDir.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnViewTempDir.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnViewTempDir_MouseEnter(sender As Object, e As EventArgs) Handles btnViewTempDir.MouseEnter
        If frmMain.design = "Dark" Then
            btnViewTempDir.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnViewTempDir.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnViewTempDir_MouseLeave(sender As Object, e As EventArgs) Handles btnViewTempDir.MouseLeave
        If frmMain.design = "Dark" Then
            btnViewTempDir.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnViewTempDir.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnViewTempDir_MouseUp(sender As Object, e As MouseEventArgs) Handles btnViewTempDir.MouseUp
        If frmMain.design = "Dark" Then
            btnViewTempDir.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnViewTempDir.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnImportSettings_MouseDown(sender As Object, e As MouseEventArgs) Handles btnImportSettings.MouseDown
        If frmMain.design = "Dark" Then
            btnImportSettings.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnImportSettings.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnImportSettings_MouseEnter(sender As Object, e As EventArgs) Handles btnImportSettings.MouseEnter
        If frmMain.design = "Dark" Then
            btnImportSettings.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnImportSettings.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnImportSettings_MouseLeave(sender As Object, e As EventArgs) Handles btnImportSettings.MouseLeave
        If frmMain.design = "Dark" Then
            btnImportSettings.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnImportSettings.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnImportSettings_MouseUp(sender As Object, e As MouseEventArgs) Handles btnImportSettings.MouseUp
        If frmMain.design = "Dark" Then
            btnImportSettings.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnImportSettings.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnExportSettings_MouseDown(sender As Object, e As MouseEventArgs) Handles btnExportSettings.MouseDown
        If frmMain.design = "Dark" Then
            btnExportSettings.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnExportSettings.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnExportSettings_MouseEnter(sender As Object, e As EventArgs) Handles btnExportSettings.MouseEnter
        If frmMain.design = "Dark" Then
            btnExportSettings.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnExportSettings.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnExportSettings_MouseLeave(sender As Object, e As EventArgs) Handles btnExportSettings.MouseLeave
        If frmMain.design = "Dark" Then
            btnExportSettings.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnExportSettings.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnExportSettings_MouseUp(sender As Object, e As MouseEventArgs) Handles btnExportSettings.MouseUp
        If frmMain.design = "Dark" Then
            btnExportSettings.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnExportSettings.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnResetSoftware_MouseDown(sender As Object, e As MouseEventArgs) Handles btnResetSoftware.MouseDown
        If frmMain.design = "Dark" Then
            btnResetSoftware.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnResetSoftware.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnResetSoftware_MouseEnter_1(sender As Object, e As EventArgs) Handles btnResetSoftware.MouseEnter
        If frmMain.design = "Dark" Then
            btnResetSoftware.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnResetSoftware.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnResetSoftware_MouseLeave_1(sender As Object, e As EventArgs) Handles btnResetSoftware.MouseLeave
        If frmMain.design = "Dark" Then
            btnResetSoftware.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnResetSoftware.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnResetSoftware_MouseUp(sender As Object, e As MouseEventArgs) Handles btnResetSoftware.MouseUp
        If frmMain.design = "Dark" Then
            btnResetSoftware.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnResetSoftware.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnOpenProfileEditor_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOpenProfileEditor.MouseDown
        If frmMain.design = "Dark" Then
            btnOpenProfileEditor.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnOpenProfileEditor.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnOpenProfileEditor_MouseEnter(sender As Object, e As EventArgs) Handles btnOpenProfileEditor.MouseEnter
        If frmMain.design = "Dark" Then
            btnOpenProfileEditor.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnOpenProfileEditor.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnOpenProfileEditor_MouseLeave(sender As Object, e As EventArgs) Handles btnOpenProfileEditor.MouseLeave
        If frmMain.design = "Dark" Then
            btnOpenProfileEditor.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnOpenProfileEditor.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnOpenProfileEditor_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOpenProfileEditor.MouseUp
        If frmMain.design = "Dark" Then
            btnOpenProfileEditor.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnOpenProfileEditor.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnRestoreDefaultSchemes_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRestoreDefaultSchemes.MouseDown
        If frmMain.design = "Dark" Then
            btnRestoreDefaultSchemes.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnRestoreDefaultSchemes.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnRestoreDefaultSchemes_MouseEnter(sender As Object, e As EventArgs) Handles btnRestoreDefaultSchemes.MouseEnter
        If frmMain.design = "Dark" Then
            btnRestoreDefaultSchemes.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnRestoreDefaultSchemes.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnRestoreDefaultSchemes_MouseLeave(sender As Object, e As EventArgs) Handles btnRestoreDefaultSchemes.MouseLeave
        If frmMain.design = "Dark" Then
            btnRestoreDefaultSchemes.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnRestoreDefaultSchemes.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnRestoreDefaultSchemes_MouseUp(sender As Object, e As MouseEventArgs) Handles btnRestoreDefaultSchemes.MouseUp
        If frmMain.design = "Dark" Then
            btnRestoreDefaultSchemes.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnRestoreDefaultSchemes.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub
End Class