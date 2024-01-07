Imports System.IO

Public Class frmRenameProfile
    Private profile As String

    '-- Event Handlers --

    Private Sub frmRenameProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load the design
        LoadDesign()

        'Clear previous content
        tbRenameProfileTo.Clear()
    End Sub

    Public Overloads Sub ShowDialog(profile As String)
        'Set the profile and show the window
        Me.profile = profile
        ShowDialog()
    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click
        'Rename the profile that was (hopefully) passed along when the window was opened
        RenameProfile()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Close the window
        Close()
    End Sub


    '-- Custom Methods --

    Public Sub RenameProfile()
        'Check if a profile is loaded and if it exists, then rename the profile file and reload the profile files in the main window
        If String.IsNullOrEmpty(profile) = False Then
            If File.Exists(String.Format("{0}{1}.txt", frmMain.profileDirectory, profile)) Then
                My.Computer.FileSystem.RenameFile(String.Format("{0}{1}.txt", frmMain.profileDirectory, profile), String.Format("{0}.txt", tbRenameProfileTo.Text))
                MsgBox(String.Format("The profile '{0}' was successfully renamed to '{1}'!", profile, tbRenameProfileTo.Text), MsgBoxStyle.Information, "Renamed profile")
                frmMain.WriteToLog(String.Format("The profile '{0}' was successfully renamed to '{1}'!", profile, tbRenameProfileTo.Text), "Info")
                frmMain.GetProfileFiles(frmMain.profileDirectory)
                frmProfileEditor.GetFiles(frmMain.profileDirectory)
                frmProfileEditor.cbxProfile.Text = tbRenameProfileTo.Text
                Close()
            Else
                MsgBox("The selected profile was not found. Make sure the profile that you want to rename exists!", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Please load a profile in the Main Window in order to rename it!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Public Sub LoadDesign()
        'Load dark mode
        If frmMain.design = "Dark" Then
            lblSaveProfileAs.ForeColor = Color.White
            tbRenameProfileTo.ForeColor = Color.White
            tbRenameProfileTo.BackColor = Color.DimGray
            BackColor = Color.FromArgb(50, 50, 50)
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

    '-- Button Animations --

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

    Private Sub btnRename_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRename.MouseDown
        If frmMain.design = "Dark" Then
            btnRename.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnRename.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnRename_MouseEnter(sender As Object, e As EventArgs) Handles btnRename.MouseEnter
        If frmMain.design = "Dark" Then
            btnRename.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnRename.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnRename_MouseLeave(sender As Object, e As EventArgs) Handles btnRename.MouseLeave
        If frmMain.design = "Dark" Then
            btnRename.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnRename.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnRename_MouseUp(sender As Object, e As MouseEventArgs) Handles btnRename.MouseUp
        If frmMain.design = "Dark" Then
            btnRename.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnRename.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub
End Class