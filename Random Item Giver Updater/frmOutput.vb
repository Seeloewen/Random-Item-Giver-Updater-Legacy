Public Class frmOutput

    Private Sub frmOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.FileExists(frmMain.AppData + "/Random Item Giver Updater/DebugLogTemp") Then
            rtbLog.LoadFile(frmMain.AppData + "/Random Item Giver Updater/DebugLogTemp")
        Else
            frmMain.WriteToLog("-- Error reading log file, creating new log --", "Error")
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        rtbLog.Clear()
        frmMain.rtbLog.Clear()
        MsgBox("Successfully cleared the log!", MsgBoxStyle.Information, "Cleared log")
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        sfdLog.FileName = "Random_Item_Giver_Log_" + DateTime.Now + "_Ver_" + frmMain.version
        sfdLog.FileName = sfdLog.FileName.Replace(":", "-")
        sfdLog.FileName = sfdLog.FileName.Replace(".", "-")
        sfdLog.FileName = sfdLog.FileName.Replace(" ", "_")
        sfdLog.FileName = sfdLog.FileName.Replace("(", "")
        sfdLog.FileName = sfdLog.FileName.Replace(")", "")
        sfdLog.ShowDialog()
    End Sub

    Private Sub sfdLog_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles sfdLog.FileOk
        My.Computer.FileSystem.WriteAllText(sfdLog.FileName, rtbLog.Text, False)
        MsgBox("The log was successfully saved to" + vbNewLine + sfdLog.FileName, MsgBoxStyle.Information, "Saved log")
        frmMain.WriteToLog("Saved log to " + sfdLog.FileName, "Info")
    End Sub

    Private Sub sfdLog_HelpRequest(sender As Object, e As EventArgs) Handles sfdLog.HelpRequest
        MsgBox("Help can be found within the software or on the Discord Server!", MsgBoxStyle.Information, "Help")
    End Sub
End Class