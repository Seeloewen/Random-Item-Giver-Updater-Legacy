Imports System.IO

Public Class frmProfileEditor

    'Variables needed by the software to work correctly
    Dim profileList As String()
    Dim profileContent As String()
    Dim loadFromProfile As String

    'Variables that store profile settings
    Dim datapackPath As String
    Dim datapackVersion As String

    '-- Event handlers --

    Private Sub frmProfileEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load the design
        LoadDesign()

        'Remove any content that may still be loaded
        cbxProfile.Items.Clear()
        cbxDatapackVersion.Items.Clear()
        tbDatapackPath.Text = ""

        'Mirror version combobox in frmMain to this combobox
        For Each item As String In frmMain.cbxVersion.Items
            cbxDatapackVersion.Items.Add(item)
        Next

        'Start getting names of all profiles
        GetFiles(frmMain.profileDirectory)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Close window
        Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'Delete the currently selected profile if it exists
        If My.Computer.FileSystem.FileExists(String.Format("{0}{1}.txt", frmMain.profileDirectory, cbxProfile.SelectedItem)) Then
            My.Computer.FileSystem.DeleteFile(String.Format("{0}{1}.txt", frmMain.profileDirectory, cbxProfile.SelectedItem))
            cbxProfile.Items.Remove(cbxProfile.SelectedItem)
            MsgBox("Profile was deleted.", MsgBoxStyle.Information, "Deleted")
            frmMain.WriteToLog(String.Format("Deleted profile {0}", cbxProfile.SelectedItem), "Info")
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

    Private Sub LoadDesign()
        'Load dark mode
        If frmMain.design = "Dark" Then
            lblHeader.ForeColor = Color.White
            BackColor = Color.FromArgb(50, 50, 50)
            lblChooseProfile.ForeColor = Color.White
            cbxDatapackVersion.BackColor = Color.DimGray
            cbxDatapackVersion.ForeColor = Color.White
            gbEditProfile.ForeColor = Color.White
            lblDatapackPath.ForeColor = Color.White
            tbDatapackPath.ForeColor = Color.White
            tbDatapackPath.BackColor = Color.DimGray
            lblDatapackPath.ForeColor = Color.White
            cbxProfile.ForeColor = Color.White
            cbxProfile.BackColor = Color.DimGray
        End If

        'Set appearance of buttons depending on selected design
        For Each ctrl As Control In Controls.OfType(Of Button)
            If frmmain.design = "Dark" Then
                ctrl.ForeColor = Color.White
                ctrl.BackgroundImage = My.Resources.imgButton
            ElseIf frmmain.design = "Light" Then
                ctrl.ForeColor = Color.Black
                ctrl.BackgroundImage = My.Resources.imgButtonLight
            End If
        Next
    End Sub

    Public Sub InitializeLoadingProfile(profile As String, showMessage As Boolean)
        'Checks if a profile is selected. It then reads the content of the profile file into the array. To avoid errors with the array being too small, it gets resized. The number represents the amount of settings.
        'It then starts to convert and load the profile, see the the method below.
        If String.IsNullOrEmpty(profile) = False Then
            loadFromProfile = String.Format("{0}{1}.txt", frmMain.profileDirectory, profile)
            profileContent = File.ReadAllLines(loadFromProfile)
            ReDim Preserve profileContent(2)
            CheckAndConvertProfile(profile, showMessage)
        Else
            MsgBox("Error: No profile selected. Please select a profile to load from.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Public Sub CheckAndConvertProfile(profile As String, showMessage As Boolean)
        'This checks if the profile file that was loaded has enough lines, too few lines would mean that settings are missing, meaning the file is either too old or corrupted.
        'It will check for each required line if it is empty (required lines = the length of a healthy, normal profile file). Make sure that the line amount it checks matches the amount of settings that are being saved.
        'If a line is empty, it will fill that line with a placeholder in the array so the profile can get loaded without errors. After loading the profile, it gets automatically saved so the corrupted/old settings file gets fixed.
        'If no required line is empty and the file is fine, it will just load the profile like normal.
        If (String.IsNullOrEmpty(profileContent(0)) OrElse String.IsNullOrEmpty(profileContent(1))) Then
            Select Case MsgBox("You are trying to load a profile from an older version or a corrupted profile. You need to update it in order to load it. You usually won't lose any settings. Do you want to continue?", vbQuestion + vbYesNo, "Load old or corrupted profile")
                Case Windows.Forms.DialogResult.Yes
                    If String.IsNullOrEmpty(profileContent(0)) Then
                        profileContent(0) = "None"
                    End If
                    If String.IsNullOrEmpty(profileContent(1)) Then
                        profileContent(1) = "Version 1.20.1"
                    End If
                    LoadProfile(profile, False)
                    SaveProfile(profile)
                    MsgBox("Loaded and updated profile. It should now work correctly!", MsgBoxStyle.Information, "Loaded and updated profile")
                Case Windows.Forms.DialogResult.No
                    MsgBox("Cancelled loading profile.", MsgBoxStyle.Exclamation, "Warning")
            End Select
        Else
            LoadProfile(profile, showMessage)
        End If
    End Sub

    Public Sub LoadProfile(profile As String, showMessage As Boolean)
        'Load settings from profile
        tbDatapackPath.Text = profileContent(0)
        cbxDatapackVersion.Text = profileContent(1)

        'If ShowMessage is enabled, it will show a messagebox when loading completes.
        If showMessage Then
            MsgBox(String.Format("Loaded profile {0}.", profile), MsgBoxStyle.Information, "Loaded profile")
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
            MsgBox(String.Format("Error: Could not load profiles. Please try again.{0}Exception: {1}", vbNewLine, ex.Message))
            frmMain.WriteToLog(String.Format("Error when loading profiles for Profile Manager: {0}", ex.Message), "Error")
        End Try
    End Sub

    Private Sub SaveProfile(profileName)
        'Save profile settings into variables. If no text is given, a placeholder will be inserted
        If String.IsNullOrEmpty(tbDatapackPath.Text) Then
            datapackPath = "None"
        Else
            datapackPath = tbDatapackPath.Text
        End If
        If String.IsNullOrEmpty(cbxDatapackVersion.SelectedItem) Then
            datapackVersion = "None"
        Else
            datapackVersion = cbxDatapackVersion.SelectedItem
        End If

        'Update the selected profile. This will save and overwrite the selected profile without showing any warning or message. Used if a profile is old or corrupted.
        If String.IsNullOrEmpty(profileName) = False Then
            If My.Computer.FileSystem.DirectoryExists(frmMain.profileDirectory) Then
                My.Computer.FileSystem.WriteAllText(String.Format("{0}{1}.txt", frmMain.profileDirectory, profileName), datapackPath + vbNewLine + datapackVersion, False)
                frmMain.WriteToLog(String.Format("Saved changes to profile {0}", profileName), "Info")
                MsgBox("Updated the selected profile.", MsgBoxStyle.Information, "Success")
            Else
                MsgBox("Error: Couldn't save profile. Profile directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Error: Couldn't save profile as the name is empty.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    '-- Button animations --

    Private Sub btnBrowse_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBrowse.MouseDown
        If frmmain.design =  "Dark" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmmain.design =  "Light" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnBrowse_MouseEnter(sender As Object, e As EventArgs) Handles btnBrowse.MouseEnter
        If frmmain.design =  "Dark" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmmain.design =  "Light" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnBrowse_MouseLeave(sender As Object, e As EventArgs) Handles btnBrowse.MouseLeave
        If frmmain.design =  "Dark" Then
            btnBrowse.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design =  "Light" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnBrowse_MouseUp(sender As Object, e As MouseEventArgs) Handles btnBrowse.MouseUp
        If frmmain.design =  "Dark" Then
            btnBrowse.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design =  "Light" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnClose_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClose.MouseDown
        If frmmain.design =  "Dark" Then
            btnClose.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmmain.design =  "Light" Then
            btnClose.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        If frmmain.design =  "Dark" Then
            btnClose.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmmain.design =  "Light" Then
            btnClose.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        If frmmain.design =  "Dark" Then
            btnClose.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design =  "Light" Then
            btnClose.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnClose_MouseUp(sender As Object, e As MouseEventArgs) Handles btnClose.MouseUp
        If frmmain.design =  "Dark" Then
            btnClose.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design =  "Light" Then
            btnClose.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnDelete_MouseDown(sender As Object, e As MouseEventArgs) Handles btnDelete.MouseDown
        If frmmain.design =  "Dark" Then
            btnDelete.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmmain.design =  "Light" Then
            btnDelete.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnDelete_MouseEnter(sender As Object, e As EventArgs) Handles btnDelete.MouseEnter
        If frmmain.design =  "Dark" Then
            btnDelete.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmmain.design =  "Light" Then
            btnDelete.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnDelete_MouseLeave(sender As Object, e As EventArgs) Handles btnDelete.MouseLeave
        If frmmain.design =  "Dark" Then
            btnDelete.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design =  "Light" Then
            btnDelete.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnDelete_MouseUp(sender As Object, e As MouseEventArgs) Handles btnDelete.MouseUp
        If frmmain.design =  "Dark" Then
            btnDelete.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design =  "Light" Then
            btnDelete.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnSave_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSave.MouseDown
        If frmmain.design =  "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmmain.design =  "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnSave_MouseEnter(sender As Object, e As EventArgs) Handles btnSave.MouseEnter
        If frmmain.design =  "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmmain.design =  "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnSave.MouseLeave
        If frmmain.design =  "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design =  "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnSave_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSave.MouseUp
        If frmmain.design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub
End Class