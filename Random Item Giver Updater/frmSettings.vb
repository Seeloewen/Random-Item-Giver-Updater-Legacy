Imports System.IO

Public Class frmSettings

    Dim SettingsArray As String()
    Dim ProfileList As String()
    Dim SchemeList As String()

    ' -- Event handlers --
    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        'If the settings file exists, save settings. If none exists, create one first.
        If My.Computer.FileSystem.FileExists(frmMain.AppData + "/Random Item Giver Updater/settings.txt") Then
            SaveSettings(frmMain.AppData + "/Random Item Giver Updater/settings.txt")
        Else
            My.Computer.FileSystem.WriteAllText(frmMain.AppData + "/Random Item Giver Updater/settings.txt", "", False)
            SaveSettings(frmMain.AppData + "/Random Item Giver Updater/settings.txt")
        End If

        'Close settings
        MsgBox("Your settings were successfully saved!", MsgBoxStyle.Information, "Saved settings")
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
            MsgBox("Cannot open directory, please select a valid path.", MsgBoxStyle.Critical, "Error")
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
            File.WriteAllLines(fbdExportSettings.SelectedPath + "\RandomItemGiverSettingsExported.txt", File.ReadAllLines(frmMain.AppData + "/Random Item Giver Updater/settings.txt"))
            MsgBox("Successfully exported your settings to " + fbdExportSettings.SelectedPath + "\RandomItemGiverSettingsExported.txt", MsgBoxStyle.Information, "Successfully exported settings")
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
        Select Case MsgBox("Warning: Resetting the software deletes all user settings, profiles, schemes and other files saved by the application. This does NOT uninstall the software, only delete its user preferences. Only continue if you know what you are doing. Are you sure you want to continue?", vbExclamation + vbYesNo, "Reset software")
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
    End Sub

    ' -- Custom methods --

    Public Sub ResetSettings(Path)
        'Reset settings to default and write to file.
        SettingsArray = SettingsFilePreset.Lines
        File.WriteAllLines(Path, SettingsArray)
    End Sub

    Sub GetProfileFiles(Path As String)
        'Gets all the profile files from the directory and puts their name into the combobox
        If Path.Trim().Length = 0 Then
            Return
        End If

        ProfileList = Directory.GetFileSystemEntries(Path)

        Try
            For Each Profile As String In ProfileList
                If Directory.Exists(Profile) Then
                    GetProfileFiles(Profile)
                Else
                    Profile = Profile.Replace(Path, "")
                    Profile = Profile.Replace(".txt", "")
                    cbxDefaultProfile.Items.Add(Profile)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error: Could not load profiles. Please try again." + vbNewLine + "Exception: " + ex.Message)
            frmMain.WriteToLog("Error when loading profiles for Settings: " + ex.Message, "Error")
        End Try
    End Sub

    Sub GetSchemeFiles(Path As String)
        'Gets all the scheme files from the directory and puts their name into the combobox
        If Path.Trim().Length = 0 Then
            Return
        End If

        SchemeList = Directory.GetFileSystemEntries(Path)

        Try
            For Each Scheme As String In SchemeList
                If Directory.Exists(Scheme) Then
                    GetSchemeFiles(Scheme)
                Else
                    Scheme = Scheme.Replace(Path, "")
                    Scheme = Scheme.Replace(".txt", "")
                    cbxDefaultScheme.Items.Add(Scheme)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error: Could not load schemes. Please try again." + vbNewLine + "Exception: " + ex.Message)
            frmMain.WriteToLog("Error when loading schemes for Settings: " + ex.Message, "Error")
        End Try
    End Sub

    Public Sub SaveSettings(SettingsFile As String)
        'Save the settings into the settings array
        Try
            frmMain.WriteToLog("Saving settings...", "Info")
            ResetSettings(SettingsFile)

            'Load settings into array
            SettingsArray = File.ReadAllLines(SettingsFile)

            'Set current version number in settings file
            SettingsArray(1) = "Version=" + frmMain.SettingsVersion.ToString
            frmMain.WriteToLog("Set new version number to " + frmMain.SettingsVersion.ToString, "Info")

            'Save general settings
            If cbUseAdvancedViewByDefault.Checked Then
                My.Settings.UseAdvancedViewByDefault = True
            Else
                My.Settings.UseAdvancedViewByDefault = False
            End If
            SettingsArray(4) = "UseAdvancedViewByDefault=" + My.Settings.UseAdvancedViewByDefault.ToString
            frmMain.WriteToLog("Saved setting " + SettingsArray(4), "Info")

            'Save software Settings
            If cbDisableLogging.Checked Then
                My.Settings.DisableLogging = True
            Else
                My.Settings.DisableLogging = False
                frmOutput.rtbLog.Clear()
            End If
            SettingsArray(7) = "DisableLogging=" + My.Settings.DisableLogging.ToString
            frmMain.WriteToLog("Saved setting " + SettingsArray(7), "Info")

            If cbHideBetaWarning.Checked Then
                My.Settings.HideAlphaWarning = True
            Else
                My.Settings.HideAlphaWarning = False
            End If
            SettingsArray(8) = "HideAlphaWarning=" + My.Settings.HideAlphaWarning.ToString
            frmMain.WriteToLog("Saved setting " + SettingsArray(8), "Info")

            'Save datapack profiles settings
            If cbLoadDefaultProfile.Checked Then
                My.Settings.LoadDefaultProfile = True
                My.Settings.DefaultProfile = cbxDefaultProfile.SelectedItem
            Else
                My.Settings.LoadDefaultProfile = False
            End If
            SettingsArray(11) = "LoadDefaultProfile=" + My.Settings.LoadDefaultProfile.ToString
            frmMain.WriteToLog("Saved setting " + SettingsArray(11), "Info")
            SettingsArray(12) = "DefaultProfile=" + My.Settings.DefaultProfile
            frmMain.WriteToLog("Saved setting " + SettingsArray(12), "Info")

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
            SettingsArray(15) = "SelectDefaultScheme=" + My.Settings.SelectDefaultScheme.ToString
            frmMain.WriteToLog("Saved setting " + SettingsArray(15), "Info")
            SettingsArray(16) = "DefaultScheme=" + My.Settings.DefaultScheme
            frmMain.WriteToLog("Saved setting " + SettingsArray(16), "Info")

            'Save Item List Importer Settings
            If cbDontImportVanillaItemsByDefault.Checked Then
                My.Settings.DontImportVanillaItemsByDefault = True
            Else
                My.Settings.DontImportVanillaItemsByDefault = False
            End If
            SettingsArray(19) = "DontImportVanillaItemsByDefault=" + My.Settings.DontImportVanillaItemsByDefault.ToString
            frmMain.WriteToLog("Saved setting " + SettingsArray(19), "Info")

            'Write settings array to file
            File.WriteAllLines(frmMain.AppData + "/Random Item Giver Updater/settings.txt", SettingsArray)
        Catch ex As Exception
            MsgBox("Could not save settings: " + ex.Message, MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog("Could not save settings: " + ex.Message, "Error")
        End Try
    End Sub
End Class