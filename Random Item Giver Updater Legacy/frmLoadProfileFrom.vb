Imports System.IO

Public Class frmLoadProfileFrom

    'Variables needed for the software to work correctly
    Dim profileList As String()
    Dim profileContent As String()
    Dim loadFromProfile As String
    Dim destination As String

    'Variables that store profile content
    Dim datapackPath As String
    Dim datapackVersion As String

    '-- Event handlers --

    ' Konstruktor, der die Argumente entgegennimmt
    Overloads Sub ShowDialog(destination As String)
        'Set the destination
        Me.destination = destination

        'Actually show the window
        ShowDialog()
    End Sub

    Private Sub frmLoadProfileFrom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load the design
        LoadDesign()

        'Checks if the profile directory exists. If yes, it clears the combobox to avoid duplicates and it starts getting all available profiles, see method below
        If My.Computer.FileSystem.DirectoryExists(frmMain.profileDirectory) Then
            cbxProfiles.Items.Clear()
            GetFiles(frmMain.profileDirectory)
        Else
            MsgBox("Error: Profile directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Close window
        Close()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        'Starts the whole loading process
        InitializeLoadingProfile(cbxProfiles.SelectedItem, True)
    End Sub

    '-- Custom methods --

    Private Sub LoadDesign()
        'Load dark mode
        If frmMain.design = "Dark" Then
            BackColor = Color.FromArgb(50, 50, 50)
            lblLoadProfileFrom.ForeColor = Color.White
            cbxProfiles.BackColor = Color.DimGray
            cbxProfiles.ForeColor = Color.White
        End If

        'Set appearance of buttons depending on selected design
        For Each ctrl As Control In Controls.OfType(Of Button)
            If frmMain.design = "Dark" Then
                ctrl.ForeColor = Color.White
                ctrl.BackgroundImage = My.Resources.imgButton
            ElseIf frmMain.design = "Light" Then
                ctrl.ForeColor = Color.Black
                ctrl.BackgroundImage = My.Resources.imgButtonLight
            End If
        Next
    End Sub

    Public Sub LoadProfile(profile As String, showMessage As Boolean)
        'Load settings from profile to the selected destination
        If destination = "Main" Then
            frmMain.tbDatapackPath.Text = profileContent(0)
            frmMain.cbxVersion.Text = profileContent(1)
        ElseIf destination = "Duplicate Finder" Then
            frmDuplicateFinder.tbDatapackPath.Text = profileContent(0)
        End If

        'If ShowMessage is enabled, it will show a messagebox when loading completes.
        If showMessage Then
            MsgBox($"Loaded profile {profile}.", MsgBoxStyle.Information, "Loaded profile")
        End If
    End Sub

    Public Sub InitializeLoadingProfile(profile As String, showMessage As Boolean)
        'Checks if a profile is selected. It then reads the content of the profile file into the array. To avoid errors with the array being too small, it gets resized. The number represents the amount of settings.
        'It then starts to convert and load the profile, see the the method below.
        Try
            If Not String.IsNullOrEmpty(profile) Then
                loadFromProfile = $"{frmMain.profileDirectory}{profile}.txt"
                profileContent = File.ReadAllLines(loadFromProfile)
                ReDim Preserve profileContent(2)
                CheckAndConvertProfile(profile, showMessage)
                Close()
            Else
                MsgBox("Error: No profile selected. Please select a profile to load from.", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MsgBox($"Failed to load profile. {ex.Message})", MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog($"Error while loading profile: {ex.Message}", "Error")
        End Try
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
                        profileContent(1) = "Version 1.21"
                    End If
                    LoadProfile(profile, False)
                    frmSaveProfileAs.UpdateProfile(profile)
                    MsgBox("Loaded and updated profile. It should now work correctly!", MsgBoxStyle.Information, "Loaded and updated profile")
                    frmMain.WriteToLog($"Loaded and updated profile {profile}", "Info")
                Case Windows.Forms.DialogResult.No
                    MsgBox("Cancelled loading profile.", MsgBoxStyle.Exclamation, "Warning")
            End Select
        Else
            LoadProfile(profile, showMessage)
            frmMain.WriteToLog($"Loaded profile {profile}", "Info")
        End If
    End Sub

    Sub GetFiles(path As String)
        'Gets all the profile files from the directory and puts their name into the combobox
        If path.Trim().Length = 0 Then
            Return
        End If

        profileList = Directory.GetFileSystemEntries(path)

        Try
            For Each Profile As String In profileList
                If Directory.Exists(Profile) Then
                    GetFiles(Profile)
                Else
                    Profile = Profile.Replace(path, "").Replace(".txt", "")
                    cbxProfiles.Items.Add(Profile)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error: Could not load profiles. Please try again." + vbNewLine + $"Exception: {ex.Message}", MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog($"Error when loading profiles for 'Load Profile from': {ex.Message }", "Error")
        End Try
    End Sub

    '-- Button animations --

    Private Sub btnLoad_MouseDown(sender As Object, e As MouseEventArgs) Handles btnLoad.MouseDown
        If frmMain.design = "Dark" Then
            btnLoad.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnLoad.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnLoad_MouseEnter(sender As Object, e As EventArgs) Handles btnLoad.MouseEnter
        If frmMain.design = "Dark" Then
            btnLoad.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnLoad.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnLoad_MouseLeave(sender As Object, e As EventArgs) Handles btnLoad.MouseLeave
        If frmMain.design = "Dark" Then
            btnLoad.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnLoad.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnLoad_MouseUp(sender As Object, e As MouseEventArgs) Handles btnLoad.MouseUp
        If frmMain.design = "Dark" Then
            btnLoad.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnLoad.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnCancel_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseDown
        If frmMain.design = "Dark" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnCancel_MouseEnter(sender As Object, e As EventArgs) Handles btnCancel.MouseEnter
        If frmMain.design = "Dark" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnCancel_MouseLeave(sender As Object, e As EventArgs) Handles btnCancel.MouseLeave
        If frmMain.design = "Dark" Then
            btnCancel.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnCancel_MouseUp(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseUp
        If frmMain.design = "Dark" Then
            btnCancel.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub
End Class