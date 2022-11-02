Public Class frmSaveProfileAs

    Dim DatapackPath As String
    Dim DatapackVersion As String

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        DatapackPath = frmMain.tbDatapackPath.Text
        DatapackVersion = frmMain.cbxVersion.Text

        If String.IsNullOrEmpty(tbSaveProfileAs.Text) = False Then
            If My.Computer.FileSystem.DirectoryExists(frmMain.ProfileDirectory) Then
                If My.Computer.FileSystem.FileExists(frmMain.ProfileDirectory + tbSaveProfileAs.Text + ".txt") Then
                    Select Case MessageBox.Show("A profile with this name already exists. Do you want to overwrite it?", vbQuestion + vbYesNo, "Profile already exists")
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
        Close()
    End Sub

    Private Sub frmSaveProfileAs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbSaveProfileAs.Clear()
    End Sub

    Public Sub UpdateProfile(ProfileName)
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
        If String.IsNullOrEmpty(ProfileName) = False Then
            If My.Computer.FileSystem.DirectoryExists(frmMain.ProfileDirectory) Then
                My.Computer.FileSystem.WriteAllText(frmMain.ProfileDirectory + ProfileName + ".txt", DatapackPath + vbNewLine + DatapackVersion, False)
            Else
                MsgBox("Error: Couldn't update profile. Profile directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Error: Couldn't update profile as the name is empty.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub
End Class