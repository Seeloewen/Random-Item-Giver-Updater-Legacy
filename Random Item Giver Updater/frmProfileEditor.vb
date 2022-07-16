Imports System.IO

Public Class frmProfileEditor

    Dim DatapackPath As String
    Dim DatapackVersion As String
    Dim ProfileList As String()
    Dim LoadFromProfile As String


    Private Sub frmProfileEditor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxProfile.Items.Clear()
        cbxDatapackVersion.Items.Clear()
        tbDatapackPath.Text = ""

        For Each Item As String In frmMain.cbxVersion.Items
            cbxDatapackVersion.Items.Add(Item)
        Next

        GetFiles(frmMain.ProfileDirectory)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrEmpty(cbxProfile.SelectedItem) = False Then
            My.Computer.FileSystem.DeleteFile(frmMain.ProfileDirectory + cbxProfile.SelectedItem + ".txt")
            MsgBox("Profile was deleted.", MsgBoxStyle.Information, "Deleted")
            frmMain.WriteToLog("Deleted profile " + cbxProfile.SelectedItem, "Info")
            cbxProfile.Items.Remove(cbxProfile.SelectedItem)
        Else
            MsgBox("Error: Profile directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub cbxProfile_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxProfile.SelectedIndexChanged
        LoadProfile(cbxProfile.SelectedItem)
    End Sub

    Private Sub LoadProfile(Profile)
        If String.IsNullOrEmpty(Profile) = False Then
            LoadFromProfile = frmMain.ProfileDirectory + Profile + ".txt"
            settings.Text = My.Computer.FileSystem.ReadAllText(LoadFromProfile)

            tbDatapackPath.Text = settings.Lines(0)
            cbxDatapackVersion.Text = settings.Lines(1)
        Else
            MsgBox("Error: Unknown error when loading profile.", MsgBoxStyle.Exclamation, "Error")
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
                    cbxProfile.Items.Add(Profile)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error: Could not load profiles. Please try again." + vbNewLine + "Exception: " + ex.Message)
            frmMain.WriteToLog("Error when loading profiles for Profile Manager: " + ex.Message, "Error")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        DatapackPath = tbDatapackPath.Text
        DatapackVersion = cbxDatapackVersion.SelectedItem

        If String.IsNullOrEmpty(cbxProfile.SelectedItem) = False Then
            If My.Computer.FileSystem.DirectoryExists(frmMain.ProfileDirectory) Then
                My.Computer.FileSystem.WriteAllText(frmMain.ProfileDirectory + cbxProfile.SelectedItem + ".txt", DatapackPath + vbNewLine + DatapackVersion, False)
                MsgBox("Profile was overwritten and saved.", MsgBoxStyle.Information, "Overwritten and saved")
                frmMain.WriteToLog("Saved and overwrote profile " + cbxProfile.SelectedItem, "Info")
            Else
                MsgBox("Error: No profile selected.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Error: Profile directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        fbdProfileEditor.ShowDialog()
        tbDatapackPath.Text = fbdProfileEditor.SelectedPath
    End Sub
End Class