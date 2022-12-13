Imports System.IO

Public Class frmProfileEditor

    'Variables needed by the software to work correctly
    Dim ProfileList As String()
    Dim ProfileContent As String()
    Dim LoadFromProfile As String

    'Variables that store profile settings
    Dim DatapackPath As String
    Dim DatapackVersion As String

    '-- Event handlers --

    Private Sub frmProfileEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Remove any content that may still be loaded
        cbxProfile.Items.Clear()
        cbxDatapackVersion.Items.Clear()
        tbDatapackPath.Text = ""

        'Mirror version combobox in frmMain to this combobox
        For Each Item As String In frmMain.cbxVersion.Items
            cbxDatapackVersion.Items.Add(Item)
        Next

        'Start getting names of all profiles
        GetFiles(frmMain.ProfileDirectory)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Close window
        Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'Delete the currently selected profile if it exists
        If My.Computer.FileSystem.FileExists(frmMain.ProfileDirectory + cbxProfile.SelectedItem + ".txt") Then
            My.Computer.FileSystem.DeleteFile(frmMain.ProfileDirectory + cbxProfile.SelectedItem + ".txt")
            MsgBox("Profile was deleted.", MsgBoxStyle.Information, "Deleted")
            cbxProfile.Items.Remove(cbxProfile.SelectedItem)
            frmMain.WriteToLog("Deleted profile " + cbxProfile.SelectedItem, "Info")
        Else
            MsgBox("Error: Profile does not exist.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub cbxProfile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProfile.SelectedIndexChanged
        'Begin loading the selected profile
        InitializeLoadingProfile(cbxProfile.SelectedItem, False)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Begin overwriting and saving the selected profile
        SaveProfile(cbxProfile.SelectedItem)
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'Select datapack path
        fbdProfileEditor.ShowDialog()
        tbDatapackPath.Text = fbdProfileEditor.SelectedPath
    End Sub

    ' -- Custom methods --

    Public Sub InitializeLoadingProfile(Profile As String, ShowMessage As Boolean)
        'Checks if a profile is selected. It then reads the content of the profile file into the array. To avoid errors with the array being too small, it gets resized. The number represents the amount of settings.
        'It then starts to convert and load the profile, see the the method below.
        If String.IsNullOrEmpty(Profile) = False Then
            LoadFromProfile = frmMain.ProfileDirectory + Profile + ".txt"
            ProfileContent = File.ReadAllLines(LoadFromProfile)
            ReDim Preserve ProfileContent(2)
            CheckAndConvertProfile(Profile, ShowMessage)
        Else
            MsgBox("Error: No profile selected. Please select a profile to load from.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Public Sub CheckAndConvertProfile(Profile As String, ShowMessage As Boolean)
        'This checks if the profile file that was loaded has enough lines, too few lines would mean that settings are missing, meaning the file is either too old or corrupted.
        'It will check for each required line if it is empty (required lines = the length of a healthy, normal profile file). Make sure that the line amount it checks matches the amount of settings that are being saved.
        'If a line is empty, it will fill that line with a placeholder in the array so the profile can get loaded without errors. After loading the profile, it gets automatically saved so the corrupted/old settings file gets fixed.
        'If no required line is empty and the file is fine, it will just load the profile like normal.
        If (String.IsNullOrEmpty(ProfileContent(0)) OrElse String.IsNullOrEmpty(ProfileContent(1))) Then
            Select Case MsgBox("You are trying to load a profile from an older version or a corrupted profile. You need to update it in order to load it. You usually won't lose any settings. Do you want to continue?", vbQuestion + vbYesNo, "Load old or corrupted profile")
                Case Windows.Forms.DialogResult.Yes
                    If String.IsNullOrEmpty(ProfileContent(0)) Then
                        ProfileContent(0) = "None"
                    End If
                    If String.IsNullOrEmpty(ProfileContent(1)) Then
                        ProfileContent(1) = "Version 1.19"
                    End If
                    LoadProfile(Profile, False)
                    SaveProfile(Profile)
                    MsgBox("Loaded and updated profile. It should now work correctly!", MsgBoxStyle.Information, "Loaded and updated profile")
                Case Windows.Forms.DialogResult.No
                    MsgBox("Cancelled loading profile.", MsgBoxStyle.Exclamation, "Warning")
            End Select
        Else
            LoadProfile(Profile, ShowMessage)
        End If
    End Sub

    Public Sub LoadProfile(Profile As String, ShowMessage As Boolean)
        'Load settings from profile
        tbDatapackPath.Text = ProfileContent(0)
        cbxDatapackVersion.Text = ProfileContent(1)

        'If ShowMessage is enabled, it will show a messagebox when loading completes.
        If ShowMessage Then
            MsgBox("Loaded profile " + Profile + ".", MsgBoxStyle.Information, "Loaded profile")
        End If
    End Sub

    Sub GetFiles(Path As String)
        'Gets all the profile files from the directory and puts their name into the combobox
        If Path.Trim().Length = 0 Then
            Return
        End If

        ProfileList = Directory.GetFileSystemEntries(Path)

        Try
            For Each Profile As String In ProfileList
                If Directory.Exists(Profile) Then
                    GetFiles(Profile)
                Else
                    Profile = Profile.Replace(Path, "")
                    Profile = Profile.Replace(".txt", "")
                    cbxProfile.Items.Add(Profile)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error: Could not load profiles. Please try again." + vbNewLine + "Exception: " + ex.Message)
            frmMain.WriteToLog("Error when loading profiles for Profile Manager: " + ex.Message, "Error")
        End Try
    End Sub

    Private Sub SaveProfile(ProfileName)
        'Save profile settings into variables. If no text is given, a placeholder will be inserted
        If String.IsNullOrEmpty(tbDatapackPath.Text) Then
            DatapackPath = tbDatapackPath.Text = "None"
        Else
            DatapackPath = tbDatapackPath.Text = frmMain.tbDatapackPath.Text
        End If
        If String.IsNullOrEmpty(cbxDatapackVersion.SelectedItem) Then
            DatapackVersion = cbxDatapackVersion.Text = "None"
        Else
            DatapackVersion = cbxDatapackVersion.SelectedItem
        End If

        'Update the selected profile. This will save and overwrite the selected profile without showing any warning or message. Used if a profile is old or corrupted.
        If String.IsNullOrEmpty(ProfileName) = False Then
            If My.Computer.FileSystem.DirectoryExists(frmMain.ProfileDirectory) Then
                My.Computer.FileSystem.WriteAllText(frmMain.ProfileDirectory + ProfileName + ".txt", DatapackPath + vbNewLine + DatapackVersion, False)
                frmMain.WriteToLog("Saved changes to profile " + ProfileName, "Info")
                MsgBox("Updated the selected profile.", MsgBoxStyle.Information, "Success")
            Else
                MsgBox("Error: Couldn't save profile. Profile directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Error: Couldn't save profile as the name is empty.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub
End Class