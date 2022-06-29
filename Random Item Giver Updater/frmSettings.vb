Imports System.IO

Public Class frmSettings

    Dim SettingsArray As String()

    Private Sub btnSaveSettings_Click(sender As Object, e As EventArgs) Handles btnSaveSettings.Click
        SaveSettings()
        MsgBox("Your settings were successfully saved!", MsgBoxStyle.Information, "Saved settings")
    End Sub

    Public Sub SaveSettings()
        'Load settings into array
        SettingsArray = File.ReadAllLines(frmMain.AppData + "/Random Item Giver Updater/settings.txt")

        'Set current version number in settings file
        SettingsArray(1) = "Version=" + frmMain.SettingsVersion.ToString

        'Save software Settings
        If cbDisableLogging.Checked Then
            My.Settings.DisableLogging = True
        Else
            My.Settings.DisableLogging = False
        End If
        SettingsArray(4) = "DisableLogging=" + My.Settings.DisableLogging.ToString

        If cbHideAlphaWarning.Checked Then
            My.Settings.HideAlphaWarning = True
        Else
            My.Settings.HideAlphaWarning = False
        End If
        SettingsArray(5) = "HideAlphaWarning=" + My.Settings.HideAlphaWarning.ToString
        'MsgBox(frmMain.ReturnArrayAsString(SettingsArray))

        'Save datapack profiles settings
        If cbLoadDefaultProfile.Checked Then
            My.Settings.LoadDefaultProfile = True
            My.Settings.DefaultProfile = cbxDefaultProfile.Text
        Else
            My.Settings.LoadDefaultProfile = False
        End If
        SettingsArray(8) = "LoadDefaultProfile=" + My.Settings.LoadDefaultProfile.ToString
        SettingsArray(9) = "DefaultProfile=" + My.Settings.DefaultProfile

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
        SettingsArray(12) = "SelectDefaultScheme=" + My.Settings.SelectDefaultScheme.ToString
        SettingsArray(13) = "DefaultScheme=" + My.Settings.DefaultScheme

        'Save Item List Importer Settings#
        If cbDontImportVanillaItemsByDefault.Checked Then
            My.Settings.DontImportVanillaItemsByDefault = True
        Else
            My.Settings.DontImportVanillaItemsByDefault = False
        End If
        SettingsArray(16) = "DontImportVanillaItemsByDefault=" + My.Settings.DontImportVanillaItemsByDefault.ToString

        File.WriteAllLines(frmMain.AppData + "/Random Item Giver Updater/settings.txt", SettingsArray)
    End Sub

    Private Sub cbSelectDefaultScheme_CheckedChanged(sender As Object, e As EventArgs) Handles cbSelectDefaultScheme.CheckedChanged
        If cbSelectDefaultScheme.Checked Then
            cbxDefaultScheme.Enabled = True
        Else
            cbxDefaultScheme.Enabled = False
        End If
    End Sub

    Private Sub cbLoadDefaultProfile_CheckedChanged(sender As Object, e As EventArgs) Handles cbLoadDefaultProfile.CheckedChanged
        If cbLoadDefaultProfile.Checked Then
            cbxDefaultProfile.Enabled = True
        Else
            cbxDefaultProfile.Enabled = False
        End If
    End Sub
End Class