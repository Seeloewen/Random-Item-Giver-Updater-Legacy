Public Class frmOutput

    '-- Event handlers --

    Private Sub frmOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Try to read the log file. Create a new one if none exists.
        If My.Computer.FileSystem.FileExists(frmMain.AppData + "/Random Item Giver Updater/DebugLogTemp") Then
            rtbLog.LoadFile(frmMain.AppData + "/Random Item Giver Updater/DebugLogTemp")
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
        btnSave.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnSave_MouseEnter(sender As Object, e As EventArgs) Handles btnSave.MouseEnter
        btnSave.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnSave.MouseLeave
        btnSave.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnSave_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSave.MouseUp
        btnSave.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnClear_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClear.MouseDown
        btnClear.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnClear_MouseEnter(sender As Object, e As EventArgs) Handles btnClear.MouseEnter
        btnClear.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnClear_MouseLeave(sender As Object, e As EventArgs) Handles btnClear.MouseLeave
        btnClear.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnClear_MouseUp(sender As Object, e As MouseEventArgs) Handles btnClear.MouseUp
        btnClear.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnClose_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClose.MouseDown
        btnClose.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        btnClose.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        btnClose.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnClose_MouseUp(sender As Object, e As MouseEventArgs) Handles btnClose.MouseUp
        btnClose.BackgroundImage = My.Resources.imgButton
    End Sub
End Class