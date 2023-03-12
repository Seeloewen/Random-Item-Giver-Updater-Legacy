Imports System.IO

Public Class frmSettings

    Dim settingsArray As String()
    Dim profileList As String()
    Dim schemeList As String()

    Dim selectedPage As Integer = 1

    ' -- Event handlers --
    Private Sub btnOpenLogDirectory_Click(sender As Object, e As EventArgs) Handles btnOpenLogDirectory.Click
        If My.Computer.FileSystem.DirectoryExists(frmMain.LogDirectory) Then
            Process.Start("explorer.exe", frmMain.LogDirectory)
        Else
            MsgBox("Cannot find log directory, please restart the application.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        'If the settings file exists, save settings. If none exists, create one first.
        If My.Computer.FileSystem.FileExists(frmMain.AppData + "/Random Item Giver Updater/settings.txt") Then
            SaveSettings(frmMain.AppData + "/Random Item Giver Updater/settings.txt")
        Else
            My.Computer.FileSystem.WriteAllText(frmMain.AppData + "/Random Item Giver Updater/settings.txt", "", False)
            SaveSettings(frmMain.AppData + "/Random Item Giver Updater/settings.txt")
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

    Private Sub cbSelectDefaultScheme_CheckedChanged(sender As Object, e As EventArgs) Handles cbLoadDefaultProfile.CheckedChanged
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
        If My.Settings.Design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf My.Settings.Design = "Dark" Then
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
        If My.Settings.Design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf My.Settings.Design = "Dark" Then
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
        If My.Settings.Design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf My.Settings.Design = "Dark" Then
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
        If My.Settings.Design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf My.Settings.Design = "Dark" Then
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
        If My.Settings.Design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf My.Settings.Design = "Dark" Then
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
            If My.Computer.FileSystem.FileExists(frmMain.AppData + "/Random Item Giver Updater/settings.old") Then
                My.Computer.FileSystem.DeleteFile(frmMain.AppData + "/Random Item Giver Updater/settings.old")
            End If
            If My.Computer.FileSystem.FileExists(frmMain.AppData + "/Random Item Giver Updater/DebugLogTemp") Then
                My.Computer.FileSystem.DeleteFile(frmMain.AppData + "/Random Item Giver Updater/DebugLogTemp")
            End If
            MsgBox("Successfully deleted all temporary files.", MsgBoxStyle.Information, "Cleared temporary files")
            frmMain.WriteToLog("Deleted all temporary files.", "Info")
        Catch ex As Exception
            MsgBox("Could not delete temporary files: " + ex.Message, MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog("Could not delete temporary files: " + ex.Message, "Error")
        End Try
    End Sub

    Private Sub btnViewTempDir_Click(sender As Object, e As EventArgs) Handles btnViewTempDir.Click
        'Open directory, where the application saves its temporary files in explorer.
        If My.Computer.FileSystem.DirectoryExists(frmMain.AppData + "\Random Item Giver Updater") Then
            Process.Start("explorer.exe", frmMain.AppData + "\Random Item Giver Updater")
        Else
            MsgBox("Cannot find directory, please restart the application.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnImportSettings_Click(sender As Object, e As EventArgs) Handles btnImportSettings.Click
        'Open settings import dialog
        ofdImportSettings.ShowDialog()
    End Sub

    Private Sub ofdImportSettings_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdImportSettings.FileOk
        frmMain.WriteToLog("-- Importing settings --", "Info")

        'Read lines from selected file into the main settings file and restart application to apply them
        Try
            File.WriteAllLines(frmMain.AppData + "/Random Item Giver Updater/settings.txt", File.ReadAllLines(ofdImportSettings.FileName))
            MsgBox("Successfully imported settings!" + vbNewLine + "Click 'OK' to close the application and apply them.", MsgBoxStyle.Information, "Imported settings")
            frmMain.WriteToLog("Successfully imported settings from file " + ofdImportSettings.FileName, "Info")
            frmMain.Close()
        Catch ex As Exception
            MsgBox("Could not import settings: " + ex.Message, MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog("Could not import settings: " + ex.Message, "Error")
        End Try
    End Sub

    Private Sub btnExportSettings_Click(sender As Object, e As EventArgs) Handles btnExportSettings.Click
        fbdExportSettings.ShowDialog()

        'Saves a copy of the settings file to the selected location
        Try
            File.WriteAllLines(fbdExportSettings.SelectedPath + "\RandomItemGiverUpdaterSettingsExported.txt", File.ReadAllLines(frmMain.AppData + "/Random Item Giver Updater/settings.txt"))
            MsgBox("Successfully exported your settings to " + fbdExportSettings.SelectedPath + "\RandomItemGiverUpdaterSettingsExported.txt", MsgBoxStyle.Information, "Successfully exported settings")
        Catch ex As Exception
            MsgBox("Could not export settings: " + ex.Message, MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog("Could not export settings: " + ex.Message, "Error")
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
                My.Computer.FileSystem.DeleteDirectory(frmMain.AppData + "/Random Item Giver Updater/", FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Settings.Reset()
                MsgBox("All profiles, schemes, user settings and other application files have been deleted. The software will now close.", MsgBoxStyle.Information, "Cancelled")
                frmMain.Close()
            Case Windows.Forms.DialogResult.No
                MsgBox("Cancelled. No changes have been made.", MsgBoxStyle.Information, "Cancelled")
        End Select
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load settings
        If My.Settings.UseAdvancedViewByDefault = True Then
            cbUseAdvancedViewByDefault.Checked = True
        Else
            cbUseAdvancedViewByDefault.Checked = False
        End If

        If My.Settings.AutoSaveLogs = True Then
            cbAutoSaveLogs.Checked = True
        Else
            cbAutoSaveLogs.Checked = False
        End If

        If My.Settings.Design = "Light" Then
            cbxDesign.SelectedIndex = 0
        ElseIf My.Settings.Design = "Dark" Then
            cbxDesign.SelectedIndex = 1
        End If

        If My.Settings.DisableLogging = True Then
            cbDisableLogging.Checked = True
        Else
            cbDisableLogging.Checked = False
        End If

        If My.Settings.HideAlphaWarning = True Then
            cbHideBetaWarning.Checked = True
        Else
            cbHideBetaWarning.Checked = False
        End If

        If My.Settings.LoadDefaultProfile = True Then
            cbLoadDefaultProfile.Checked = True
        Else
            cbLoadDefaultProfile.Checked = False
        End If

        If My.Settings.SelectDefaultScheme = True Then
            cbSelectDefaultScheme.Checked = True
        Else
            cbSelectDefaultScheme.Checked = False
        End If

        If My.Settings.DontImportVanillaItemsByDefault = True Then
            cbDontImportVanillaItemsByDefault.Checked = True
        Else
            cbDontImportVanillaItemsByDefault.Checked = False
        End If

        'Load profiles
        If My.Computer.FileSystem.DirectoryExists(frmMain.ProfileDirectory) = False Then
            My.Computer.FileSystem.CreateDirectory(frmMain.ProfileDirectory)
        End If

        cbxDefaultProfile.Items.Clear()
        GetProfileFiles(frmMain.ProfileDirectory)

        If My.Settings.LoadDefaultProfile = True Then
            cbLoadDefaultProfile.Checked = True
            If String.IsNullOrEmpty(My.Settings.DefaultProfile) = False Then
                If My.Computer.FileSystem.FileExists(frmMain.ProfileDirectory + My.Settings.DefaultProfile + ".txt") Then
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
        If My.Computer.FileSystem.DirectoryExists(frmMain.SchemeDirectory) = False Then
            My.Computer.FileSystem.CreateDirectory(frmMain.SchemeDirectory)
        End If

        cbxDefaultScheme.Items.Clear()
        GetSchemeFiles(frmMain.SchemeDirectory)

        If My.Settings.SelectDefaultScheme = True Then
            cbSelectDefaultScheme.Checked = True
            If String.IsNullOrEmpty(My.Settings.DefaultScheme) = False Then
                If My.Computer.FileSystem.FileExists(frmMain.SchemeDirectory + My.Settings.DefaultScheme + ".txt") Then
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

        'Load darkmode
        If My.Settings.Design = "Dark" Then
            lblHeader.ForeColor = Color.White
            gbGeneral1.ForeColor = Color.White
            gbGeneral2.ForeColor = Color.White
            gbDatapackProfiles.ForeColor = Color.White
            gbSchemes.ForeColor = Color.White
            gbItemListImporter.ForeColor = Color.White
            BackColor = Color.FromArgb(50, 50, 50)
            pbSettingsNavigationBar.BackgroundImage = My.Resources.imgSettingsNavigationBarDark
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            lblAdvancedViewByDefault.ForeColor = Color.White
            cbUseAdvancedViewByDefault.ForeColor = Color.White
            lblAutoSaveLogs.ForeColor = Color.White
            cbAutoSaveLogs.ForeColor = Color.White
            lblDesign.ForeColor = Color.White
            cbxDesign.BackColor = Color.DimGray
            cbxDesign.ForeColor = Color.White
            lblEditProfiles.ForeColor = Color.White
            cbLoadDefaultProfile.ForeColor = Color.White
            cbxDefaultProfile.BackColor = Color.DimGray
            cbxDefaultProfile.ForeColor = Color.White
            lblTempFiles.ForeColor = Color.White
            lblLogging.ForeColor = Color.White
            cbDisableLogging.ForeColor = Color.White
            lblBetaWarning.ForeColor = Color.White
            cbHideBetaWarning.ForeColor = Color.White
            lblImportExportSettings.ForeColor = Color.White
            lblResetSoftware.ForeColor = Color.White
            lblEditSchemeEditor.ForeColor = Color.White
            cbSelectDefaultScheme.ForeColor = Color.White
            cbxDefaultScheme.ForeColor = Color.White
            cbxDefaultScheme.BackColor = Color.DimGray
            lblRestoreDefaultSchemes.ForeColor = Color.White
            lblDefaultSettingsItemImporter.ForeColor = Color.White
            cbDontImportVanillaItemsByDefault.ForeColor = Color.White
            btnNavGeneral1.ForeColor = Color.White
            btnNavGeneral2.ForeColor = Color.White
            btnNavDatapackProfiles.ForeColor = Color.White
            btnNavSchemes.ForeColor = Color.White
            btnNavItemListImporter.ForeColor = Color.White
        End If

        'Show default settings page
        selectedPage = 1
        If My.Settings.Design = "Dark" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        ElseIf My.Settings.Design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        End If
        gbGeneral1.Show()
        gbGeneral2.Hide()
        gbDatapackProfiles.Hide()
        gbSchemes.Hide()
        gbItemListImporter.Hide()
    End Sub

    ' -- Custom methods --

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
                    Profile = Profile.Replace(path, "")
                    Profile = Profile.Replace(".txt", "")
                    cbxDefaultProfile.Items.Add(Profile)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error: Could not load profiles. Please try again." + vbNewLine + "Exception: " + ex.Message)
            frmMain.WriteToLog("Error when loading profiles for Settings: " + ex.Message, "Error")
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
                    Scheme = Scheme.Replace(path, "")
                    Scheme = Scheme.Replace(".txt", "")
                    cbxDefaultScheme.Items.Add(Scheme)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error: Could not load schemes. Please try again." + vbNewLine + "Exception: " + ex.Message)
            frmMain.WriteToLog("Error when loading schemes for Settings: " + ex.Message, "Error")
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
            settingsArray(1) = "Version=" + frmMain.settingsVersion.ToString
            frmMain.WriteToLog("Set new version number to " + frmMain.settingsVersion.ToString, "Info")

            'Save general 1 settings
            If cbUseAdvancedViewByDefault.Checked Then
                My.Settings.UseAdvancedViewByDefault = True
            Else
                My.Settings.UseAdvancedViewByDefault = False
            End If
            settingsArray(4) = "UseAdvancedViewByDefault=" + My.Settings.UseAdvancedViewByDefault.ToString
            frmMain.WriteToLog("Saved setting " + settingsArray(4), "Info")
            If cbAutoSaveLogs.Checked Then
                My.Settings.AutoSaveLogs = True
            Else
                My.Settings.AutoSaveLogs = False
            End If
            settingsArray(5) = "AutoSaveLogs=" + My.Settings.AutoSaveLogs.ToString
            If cbxDesign.SelectedIndex = 0 Then
                My.Settings.Design = "Light"
            ElseIf cbxDesign.SelectedIndex = 1 Then
                My.Settings.Design = "Dark"
            End If
            settingsArray(6) = "Design=" + My.Settings.Design

            'Save general 2 Settings
            If cbDisableLogging.Checked Then
                My.Settings.DisableLogging = True
            Else
                My.Settings.DisableLogging = False
                frmOutput.rtbLog.Clear()
            End If
            settingsArray(9) = "DisableLogging=" + My.Settings.DisableLogging.ToString
            frmMain.WriteToLog("Saved setting " + settingsArray(9), "Info")

            If cbHideBetaWarning.Checked Then
                My.Settings.HideAlphaWarning = True
            Else
                My.Settings.HideAlphaWarning = False
            End If
            settingsArray(10) = "HideAlphaWarning=" + My.Settings.HideAlphaWarning.ToString
            frmMain.WriteToLog("Saved setting " + settingsArray(10), "Info")

            'Save datapack profiles settings
            If cbLoadDefaultProfile.Checked Then
                My.Settings.LoadDefaultProfile = True
                My.Settings.DefaultProfile = cbxDefaultProfile.SelectedItem
            Else
                My.Settings.LoadDefaultProfile = False
            End If
            settingsArray(13) = "LoadDefaultProfile=" + My.Settings.LoadDefaultProfile.ToString
            frmMain.WriteToLog("Saved setting " + settingsArray(13), "Info")
            settingsArray(14) = "DefaultProfile=" + My.Settings.DefaultProfile
            frmMain.WriteToLog("Saved setting " + settingsArray(14), "Info")

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
            settingsArray(17) = "SelectDefaultScheme=" + My.Settings.SelectDefaultScheme.ToString
            frmMain.WriteToLog("Saved setting " + settingsArray(17), "Info")
            settingsArray(18) = "DefaultScheme=" + My.Settings.DefaultScheme
            frmMain.WriteToLog("Saved setting " + settingsArray(18), "Info")

            'Save Item List Importer Settings
            If cbDontImportVanillaItemsByDefault.Checked Then
                My.Settings.DontImportVanillaItemsByDefault = True
            Else
                My.Settings.DontImportVanillaItemsByDefault = False
            End If
            settingsArray(21) = "DontImportVanillaItemsByDefault=" + My.Settings.DontImportVanillaItemsByDefault.ToString
            frmMain.WriteToLog("Saved setting " + settingsArray(21), "Info")

            'Write settings array to file
            File.WriteAllLines(frmMain.appData + "/Random Item Giver Updater/settings.txt", settingsArray)
        Catch ex As Exception
            MsgBox("Could not save settings: " + ex.Message, MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog("Could not save settings: " + ex.Message, "Error")
        End Try
    End Sub

    '-- Button animations --

    Private Sub btnNavGeneral1_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavGeneral1.MouseDown
        If My.Settings.Design = "Light" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf My.Settings.Design = "Dark" Then
            btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavGeneral1_MouseEnter(sender As Object, e As EventArgs) Handles btnNavGeneral1.MouseEnter
        If (selectedPage = 1) = False Then
            If My.Settings.Design = "Light" Then
                btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf My.Settings.Design = "Dark" Then
                btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavGeneral1_MouseLeave(sender As Object, e As EventArgs) Handles btnNavGeneral1.MouseLeave
        If (selectedPage = 1) = False Then
            If My.Settings.Design = "Light" Then
                btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf My.Settings.Design = "Dark" Then
                btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavGeneral1_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavGeneral1.MouseUp
        If (selectedPage = 1) = False Then
            If My.Settings.Design = "Light" Then
                btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf My.Settings.Design = "Dark" Then
                btnNavGeneral1.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavGeneral2_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavGeneral2.MouseDown
        If My.Settings.Design = "Light" Then
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf My.Settings.Design = "Dark" Then
            btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavGeneral2_MouseEnter(sender As Object, e As EventArgs) Handles btnNavGeneral2.MouseEnter
        If (selectedPage = 2) = False Then
            If My.Settings.Design = "Light" Then
                btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf My.Settings.Design = "Dark" Then
                btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavGeneral2_MouseLeave(sender As Object, e As EventArgs) Handles btnNavGeneral2.MouseLeave
        If (selectedPage = 2) = False Then
            If My.Settings.Design = "Light" Then
                btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf My.Settings.Design = "Dark" Then
                btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavGeneral2_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavGeneral2.MouseUp
        If (selectedPage = 2) = False Then
            If My.Settings.Design = "Light" Then
                btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf My.Settings.Design = "Dark" Then
                btnNavGeneral2.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavDatapackProfiles_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavDatapackProfiles.MouseDown
        If My.Settings.Design = "Light" Then
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf My.Settings.Design = "Dark" Then
            btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavDatapackProfiles_MouseEnter(sender As Object, e As EventArgs) Handles btnNavDatapackProfiles.MouseEnter
        If (selectedPage = 3) = False Then
            If My.Settings.Design = "Light" Then
                btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf My.Settings.Design = "Dark" Then
                btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavDatapackProfiles_MouseLeave(sender As Object, e As EventArgs) Handles btnNavDatapackProfiles.MouseLeave
        If (selectedPage = 3) = False Then
            If My.Settings.Design = "Light" Then
                btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf My.Settings.Design = "Dark" Then
                btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavDatapackProfiles_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavDatapackProfiles.MouseUp
        If (selectedPage = 3) = False Then
            If My.Settings.Design = "Light" Then
                btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf My.Settings.Design = "Dark" Then
                btnNavDatapackProfiles.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavSchemes_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavSchemes.MouseDown
        If My.Settings.Design = "Light" Then
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf My.Settings.Design = "Dark" Then
            btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavSchemes_MouseEnter(sender As Object, e As EventArgs) Handles btnNavSchemes.MouseEnter
        If (selectedPage = 4) = False Then
            If My.Settings.Design = "Light" Then
                btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf My.Settings.Design = "Dark" Then
                btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavSchemes_MouseLeave(sender As Object, e As EventArgs) Handles btnNavSchemes.MouseLeave
        If (selectedPage = 4) = False Then
            If My.Settings.Design = "Light" Then
                btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf My.Settings.Design = "Dark" Then
                btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavSchemes_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavSchemes.MouseUp
        If (selectedPage = 4) = False Then
            If My.Settings.Design = "Light" Then
                btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf My.Settings.Design = "Dark" Then
                btnNavSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavItemListImporter_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavItemListImporter.MouseDown
        If My.Settings.Design = "Light" Then
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf My.Settings.Design = "Dark" Then
            btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavItemListImporter_MouseEnter(sender As Object, e As EventArgs) Handles btnNavItemListImporter.MouseEnter
        If (selectedPage = 5) = False Then
            If My.Settings.Design = "Light" Then
                btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf My.Settings.Design = "Dark" Then
                btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavItemListImporter_MouseLeave(sender As Object, e As EventArgs) Handles btnNavItemListImporter.MouseLeave
        If (selectedPage = 5) = False Then
            If My.Settings.Design = "Light" Then
                btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf My.Settings.Design = "Dark" Then
                btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavItemListImporter_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavItemListImporter.MouseUp
        If (selectedPage = 5) = False Then
            If My.Settings.Design = "Light" Then
                btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf My.Settings.Design = "Dark" Then
                btnNavItemListImporter.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnSaveSettings_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSaveSettings.MouseDown
        btnSaveSettings.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnSaveSettings_MouseEnter(sender As Object, e As EventArgs) Handles btnSaveSettings.MouseEnter
        btnSaveSettings.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnSaveSettings_MouseLeave(sender As Object, e As EventArgs) Handles btnSaveSettings.MouseLeave
        btnSaveSettings.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnSaveSettings_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSaveSettings.MouseUp
        btnSaveSettings.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnQuitWithoutSaving_MouseDown(sender As Object, e As MouseEventArgs) Handles btnQuitWithoutSaving.MouseDown
        btnQuitWithoutSaving.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnQuitWithoutSaving_MouseEnter(sender As Object, e As EventArgs) Handles btnQuitWithoutSaving.MouseEnter
        btnQuitWithoutSaving.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnQuitWithoutSaving_MouseLeave(sender As Object, e As EventArgs) Handles btnQuitWithoutSaving.MouseLeave
        btnQuitWithoutSaving.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnQuitWithoutSaving_MouseUp(sender As Object, e As MouseEventArgs) Handles btnQuitWithoutSaving.MouseUp
        btnQuitWithoutSaving.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnOpenLogDirectory_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOpenLogDirectory.MouseDown
        btnOpenLogDirectory.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnOpenLogDirectory_MouseEnter(sender As Object, e As EventArgs) Handles btnOpenLogDirectory.MouseEnter
        btnOpenLogDirectory.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnOpenLogDirectory_MouseLeave(sender As Object, e As EventArgs) Handles btnOpenLogDirectory.MouseLeave
        btnOpenLogDirectory.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnOpenLogDirectory_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOpenLogDirectory.MouseUp
        btnOpenLogDirectory.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnClearTempFiles_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClearTempFiles.MouseDown
        btnClearTempFiles.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnClearTempFiles_MouseEnter(sender As Object, e As EventArgs) Handles btnClearTempFiles.MouseEnter
        btnClearTempFiles.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnClearTempFiles_MouseLeave(sender As Object, e As EventArgs) Handles btnClearTempFiles.MouseLeave
        btnClearTempFiles.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnClearTempFiles_MouseUp(sender As Object, e As MouseEventArgs) Handles btnClearTempFiles.MouseUp
        btnClearTempFiles.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnViewTempDir_MouseDown(sender As Object, e As MouseEventArgs) Handles btnViewTempDir.MouseDown
        btnViewTempDir.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnViewTempDir_MouseEnter(sender As Object, e As EventArgs) Handles btnViewTempDir.MouseEnter
        btnViewTempDir.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnViewTempDir_MouseLeave(sender As Object, e As EventArgs) Handles btnViewTempDir.MouseLeave
        btnViewTempDir.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnViewTempDir_MouseUp(sender As Object, e As MouseEventArgs) Handles btnViewTempDir.MouseUp
        btnViewTempDir.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnImportSettings_MouseDown(sender As Object, e As MouseEventArgs) Handles btnImportSettings.MouseDown
        btnImportSettings.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnImportSettings_MouseEnter(sender As Object, e As EventArgs) Handles btnImportSettings.MouseEnter
        btnImportSettings.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnImportSettings_MouseLeave(sender As Object, e As EventArgs) Handles btnImportSettings.MouseLeave
        btnImportSettings.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnImportSettings_MouseUp(sender As Object, e As MouseEventArgs) Handles btnImportSettings.MouseUp
        btnImportSettings.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnExportSettings_MouseDown(sender As Object, e As MouseEventArgs) Handles btnExportSettings.MouseDown
        btnExportSettings.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnExportSettings_MouseEnter(sender As Object, e As EventArgs) Handles btnExportSettings.MouseEnter
        btnExportSettings.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnExportSettings_MouseLeave(sender As Object, e As EventArgs) Handles btnExportSettings.MouseLeave
        btnExportSettings.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnExportSettings_MouseUp(sender As Object, e As MouseEventArgs) Handles btnExportSettings.MouseUp
        btnExportSettings.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnResetSoftware_MouseDown(sender As Object, e As MouseEventArgs) Handles btnResetSoftware.MouseDown
        btnResetSoftware.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnResetSoftware_MouseEnter_1(sender As Object, e As EventArgs) Handles btnResetSoftware.MouseEnter
        btnResetSoftware.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnResetSoftware_MouseLeave_1(sender As Object, e As EventArgs) Handles btnResetSoftware.MouseLeave
        btnResetSoftware.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnResetSoftware_MouseUp(sender As Object, e As MouseEventArgs) Handles btnResetSoftware.MouseUp
        btnResetSoftware.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnOpenProfileEditor_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOpenProfileEditor.MouseDown
        btnOpenProfileEditor.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnOpenProfileEditor_MouseEnter(sender As Object, e As EventArgs) Handles btnOpenProfileEditor.MouseEnter
        btnOpenProfileEditor.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnOpenProfileEditor_MouseLeave(sender As Object, e As EventArgs) Handles btnOpenProfileEditor.MouseLeave
        btnOpenProfileEditor.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnOpenProfileEditor_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOpenProfileEditor.MouseUp
        btnOpenProfileEditor.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnRestoreDefaultSchemes_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRestoreDefaultSchemes.MouseDown
        btnRestoreDefaultSchemes.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnRestoreDefaultSchemes_MouseEnter(sender As Object, e As EventArgs) Handles btnRestoreDefaultSchemes.MouseEnter
        btnRestoreDefaultSchemes.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnRestoreDefaultSchemes_MouseLeave(sender As Object, e As EventArgs) Handles btnRestoreDefaultSchemes.MouseLeave
        btnRestoreDefaultSchemes.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnRestoreDefaultSchemes_MouseUp(sender As Object, e As MouseEventArgs) Handles btnRestoreDefaultSchemes.MouseUp
        btnRestoreDefaultSchemes.BackgroundImage = My.Resources.imgButton
    End Sub
End Class