Public Class frmSaveProfileAs

    Dim DatapackPath As String
    Dim DatapackVersion As String

    '-- Event handlers --
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Get datapack path and version from selected settings in main window
        DatapackPath = frmMain.tbDatapackPath.Text
        DatapackVersion = frmMain.cbxVersion.Text

        'Saves the profile. It checks if the profile already exists or not. If it exists, it will show a warning, otherwise it will not.
        'It will then create a text file with the name set in ProfileName and write the content of the variable to the file.
        'It will show an error if ProfileName is empty or ProfileDirectory doesn't exist.
        If String.IsNullOrEmpty(tbSaveProfileAs.Text) = False Then
            If My.Computer.FileSystem.DirectoryExists(frmMain.ProfileDirectory) Then
                If My.Computer.FileSystem.FileExists(frmMain.ProfileDirectory + tbSaveProfileAs.Text + ".txt") Then
                    Select Case MsgBox("A profile with this name already exists. Do you want to overwrite it?", vbQuestion + vbYesNo, "Profile already exists")
                        Case Windows.Forms.DialogResult.Yes
                            My.Computer.FileSystem.WriteAllText(frmMain.ProfileDirectory + tbSaveProfileAs.Text + ".txt", DatapackPath + vbNewLine + DatapackVersion, False)
                            MsgBox("Profile was overwritten and saved.", MsgBoxStyle.Information, "Overwritten and saved")
                            frmMain.WriteToLog("Saved and overwrote profile " + tbSaveProfileAs.Text, "Info")
                            Close()
                        Case Windows.Forms.DialogResult.No
                            MsgBox("Profile was not overwritten. Please select a different profile name.", MsgBoxStyle.Exclamation, "Profile not overwritten.")
                    End Select
                Else
                    My.Computer.FileSystem.WriteAllText(frmMain.ProfileDirectory + tbSaveProfileAs.Text + ".txt", DatapackPath + vbNewLine + DatapackVersion, False)
                    MsgBox("Profile was saved.", MsgBoxStyle.Information, "Saved")
                    frmMain.WriteToLog("Saved profile " + tbSaveProfileAs.Text, "Info")
                    Close()
                End If
            Else
                MsgBox("Error: Profile directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Error: Profile name is empty. Please enter a profile name.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Close window
        Close()
    End Sub

    Private Sub frmSaveProfileAs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set appearance of buttons depending on selected design
        For Each ctrl As Control In Controls.OfType(Of Button)
            If frmmain.design =  "Dark" Then
                ctrl.ForeColor = Color.White
                ctrl.BackgroundImage = My.Resources.imgButton
            ElseIf frmmain.design =  "Light" Then
                ctrl.ForeColor = Color.Black
                ctrl.BackgroundImage = My.Resources.imgButtonLight
            End If
        Next

        'Clear existing text in name textbox
        tbSaveProfileAs.Clear()

        'Load dark mode
        If frmmain.design =  "Dark" Then
            lblSaveProfileAs.ForeColor = Color.White
            BackColor = Color.FromArgb(50, 50, 50)
            tbSaveProfileAs.ForeColor = Color.White
            tbSaveProfileAs.BackColor = Color.DimGray
        End If
    End Sub

    ' -- Custom methods --

    Public Sub UpdateProfile(profileName)
        'Save profile settings into variables. If no text is given, a placeholder will be inserted
        If String.IsNullOrEmpty(frmMain.tbDatapackPath.Text) Then
            DatapackPath = frmMain.tbDatapackPath.Text = "None"
        Else
            DatapackPath = frmMain.tbDatapackPath.Text = frmMain.tbDatapackPath.Text
        End If
        If String.IsNullOrEmpty(frmMain.cbxVersion.SelectedItem) Then
            DatapackVersion = frmMain.cbxVersion.Text = "None"
        Else
            DatapackVersion = frmMain.cbxVersion.SelectedItem
        End If

        'Update the selected profile. This will save and overwrite the selected profile without showing any warning or message. Used if a profile is old or corrupted.
        If String.IsNullOrEmpty(profileName) = False Then
            If My.Computer.FileSystem.DirectoryExists(frmMain.profileDirectory) Then
                My.Computer.FileSystem.WriteAllText(frmMain.profileDirectory + profileName + ".txt", DatapackPath + vbNewLine + DatapackVersion, False)
            Else
                MsgBox("Error: Couldn't update profile. Profile directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Error: Couldn't update profile as the name is empty.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    '-- Button animations --

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
        If frmmain.design =  "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design =  "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnCancel_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseDown
        If frmmain.design =  "Dark" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmmain.design =  "Light" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnCancel_MouseEnter(sender As Object, e As EventArgs) Handles btnCancel.MouseEnter
        If frmmain.design =  "Dark" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmmain.design =  "Light" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnCancel_MouseLeave(sender As Object, e As EventArgs) Handles btnCancel.MouseLeave
        If frmmain.design =  "Dark" Then
            btnCancel.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design =  "Light" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnCancel_MouseUp(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseUp
        If frmmain.design =  "Dark" Then
            btnCancel.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design =  "Light" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub
End Class