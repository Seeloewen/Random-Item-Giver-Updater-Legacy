Public Class frmOutput

    '-- Event handlers --

    Private Sub frmOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set appearance of buttons depending on selected design
        For Each ctrl As Control In Controls.OfType(Of Button)
            If My.Settings.Design = "Dark" Then
                ctrl.ForeColor = Color.White
                ctrl.BackgroundImage = My.Resources.imgButton
            ElseIf My.Settings.Design = "Light" Then
                ctrl.ForeColor = Color.Black
                ctrl.BackgroundImage = My.Resources.imgButtonLight
            End If
        Next

        'Try to read the log file. Create a new one if none exists.
        If My.Computer.FileSystem.FileExists(frmMain.appData + "/Random Item Giver Updater/DebugLogTemp") Then
            rtbLog.LoadFile(frmMain.appData + "/Random Item Giver Updater/DebugLogTemp")
        Else
            frmMain.WriteToLog("-- Error reading log file, creating new log --", "Error")
        End If

        'Load dark mode
        If My.Settings.Design = "Dark" Then
            BackColor = Color.FromArgb(50, 50, 50)
            lblHeader.ForeColor = Color.White
            gbLog.ForeColor = Color.White
            rtbLog.BackColor = Color.FromArgb(50, 50, 50)
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'Close the window
        Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Clear the log in both windows
        rtbLog.Clear()
        frmMain.rtbLog.Clear()
        MsgBox("Successfully cleared the log!", MsgBoxStyle.Information, "Cleared log")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Prepare file name for saving the log and show dialog
        sfdLog.FileName = "Random_Item_Giver_Updater_Log_" + DateTime.Now + "_Ver_" + frmMain.VersionLog
        sfdLog.FileName = sfdLog.FileName.Replace(":", "-")
        sfdLog.FileName = sfdLog.FileName.Replace(".", "-")
        sfdLog.FileName = sfdLog.FileName.Replace(" ", "_")
        sfdLog.FileName = sfdLog.FileName.Replace("(", "")
        sfdLog.FileName = sfdLog.FileName.Replace(")", "")
        sfdLog.ShowDialog()
        SaveLog(sfdLog.FileName, True)
    End Sub

    Public Sub SaveLog(filePathAndName As String, showMessage As Boolean)
        'Save log to specified path
        My.Computer.FileSystem.WriteAllText(filePathAndName, rtbLog.Text, False)
        If showMessage = True Then
            MsgBox("The log was successfully saved to" + vbNewLine + filePathAndName, MsgBoxStyle.Information, "Saved log")
        End If
        frmMain.WriteToLog("Saved log to " + filePathAndName, "Info")
    End Sub

    '-- Button animations --

    Private Sub btnSave_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSave.MouseDown
        If My.Settings.Design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButtonClick
        ElseIf My.Settings.Design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnSave_MouseEnter(sender As Object, e As EventArgs) Handles btnSave.MouseEnter
        If My.Settings.Design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButtonHover
        ElseIf My.Settings.Design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnSave.MouseLeave
        If My.Settings.Design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnSave_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSave.MouseUp
        If My.Settings.Design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnClear_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClear.MouseDown
        If My.Settings.Design = "Dark" Then
            btnClear.BackgroundImage = My.Resources.imgButtonClick
        ElseIf My.Settings.Design = "Light" Then
            btnClear.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnClear_MouseEnter(sender As Object, e As EventArgs) Handles btnClear.MouseEnter
        If My.Settings.Design = "Dark" Then
            btnClear.BackgroundImage = My.Resources.imgButtonHover
        ElseIf My.Settings.Design = "Light" Then
            btnClear.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnClear_MouseLeave(sender As Object, e As EventArgs) Handles btnClear.MouseLeave
        If My.Settings.Design = "Dark" Then
            btnClear.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnClear.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnClear_MouseUp(sender As Object, e As MouseEventArgs) Handles btnClear.MouseUp
        If My.Settings.Design = "Dark" Then

        ElseIf My.Settings.Design = "Light" Then
            btnClear.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnClose_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClose.MouseDown
        If My.Settings.Design = "Dark" Then
            btnClose.BackgroundImage = My.Resources.imgButtonClick
        ElseIf My.Settings.Design = "Light" Then
            btnClose.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        If My.Settings.Design = "Dark" Then
            btnClose.BackgroundImage = My.Resources.imgButtonHover
        ElseIf My.Settings.Design = "Light" Then
            btnClose.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        If My.Settings.Design = "Dark" Then
            btnClose.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnClose.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnClose_MouseUp(sender As Object, e As MouseEventArgs) Handles btnClose.MouseUp
        If My.Settings.Design = "Dark" Then
            btnClose.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnClose.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub
End Class