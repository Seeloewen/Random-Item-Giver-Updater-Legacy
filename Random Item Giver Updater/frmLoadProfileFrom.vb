Imports System.IO

Public Class frmLoadProfileFrom

    Dim ProfileList As String()
    Dim LoadFromProfile As String
    Dim DatapackPath As String
    Dim DatapackVersion As String

    Private Sub frmLoadProfileFrom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.DirectoryExists(frmMain.ProfileDirectory) Then
            cbxProfiles.Items.Clear()
            GetFiles(frmMain.ProfileDirectory)
        Else
            MsgBox("Error: Profile directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub
    Sub GetFiles(Path As String)
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
                    cbxProfiles.Items.Add(Profile)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error: Could not load profiles. Please try again." + vbNewLine + "Exception: " + ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            LoadProfile(cbxProfiles.SelectedItem, True)
        Catch ex As Exception
            Select Case MsgBox("Error when loading profile. It might be corrupted or outdated. Do you want to delete it?" + vbNewLine + "If you choose 'no', you will be asked again next time you load the profile.", MessageBoxButtons.YesNo)
                Case Windows.Forms.DialogResult.Yes
                    My.Computer.FileSystem.DeleteFile(frmMain.ProfileDirectory + cbxProfiles.SelectedItem + ".txt")
                    cbxProfiles.Items.Remove(cbxProfiles.SelectedItem)
                    MsgBox("Successfully deleted the corrupted profile.", MsgBoxStyle.Information, "Deleted profile")
            End Select
        End Try
    End Sub

    Public Sub LoadProfile(Profile, ShowMessage)
        If String.IsNullOrEmpty(Profile) = False Then
            LoadFromProfile = frmMain.ProfileDirectory + Profile + ".txt"
            settings.Text = My.Computer.FileSystem.ReadAllText(LoadFromProfile)

            frmMain.tbDatapackPath.Text = settings.Lines(0)
            frmMain.cbxVersion.Text = settings.Lines(1)

            If ShowMessage Then
                MsgBox("Loaded profile " + Profile + ".", MsgBoxStyle.Information, "Loaded profile")
            End If

            Close()
        Else
            MsgBox("Error: No profile selected. Please select a profile to load from.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub
End Class