﻿Imports System.IO

Public Class frmOutput

    '-- Event handlers --

    Private Sub frmOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load the design
        LoadDesign()

        'Try to read the log file. Create a new one if none exists.
        If My.Computer.FileSystem.FileExists($"{frmMain.appData}\Random Item Giver Updater Legacy\DebugLogTemp") Then
            rtbLog.LoadFile($"{frmMain.appData}\Random Item Giver Updater Legacy\DebugLogTemp")
        Else
            frmMain.WriteToLog("Error reading log file, creating new log..", "Error")
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
        sfdLog.FileName = $"Random_Item_Giver_Updater_Legacy_Log_{DateTime.Now}_Ver_{frmMain.versionLog}"
        sfdLog.FileName = sfdLog.FileName.Replace(":", "-").Replace(".", "-").Replace(" ", "_").Replace("(", "").Replace(")", "")

        If sfdLog.ShowDialog() = DialogResult.OK Then
            SaveLog(sfdLog.FileName, True)
        End If
    End Sub


    '-- Custom methods --

    Public Sub SaveLog(filePathAndName As String, showMessage As Boolean)
        'Save log to specified path
        My.Computer.FileSystem.WriteAllText(filePathAndName, rtbLog.Text, False)
        If showMessage Then
            MsgBox($"The log was successfully saved to{vbNewLine}{filePathAndName}", MsgBoxStyle.Information, "Saved log")
        End If
        frmMain.WriteToLog($"Saved log to {filePathAndName}", "Info")
    End Sub

    Private Sub LoadDesign()
        'Load dark mode
        If frmMain.design = "Dark" Then
            BackColor = Color.FromArgb(50, 50, 50)
            lblHeader.ForeColor = Color.White
            gbLog.ForeColor = Color.White
            rtbLog.BackColor = Color.FromArgb(50, 50, 50)
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

    '-- Button animations --

    Private Sub btnSave_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSave.MouseDown
        If frmMain.design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnSave_MouseEnter(sender As Object, e As EventArgs) Handles btnSave.MouseEnter
        If frmMain.design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnSave.MouseLeave
        If frmMain.design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnSave_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSave.MouseUp
        If frmMain.design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnClear_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClear.MouseDown
        If frmMain.design = "Dark" Then
            btnClear.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnClear.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnClear_MouseEnter(sender As Object, e As EventArgs) Handles btnClear.MouseEnter
        If frmMain.design = "Dark" Then
            btnClear.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnClear.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnClear_MouseLeave(sender As Object, e As EventArgs) Handles btnClear.MouseLeave
        If frmMain.design = "Dark" Then
            btnClear.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnClear.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnClear_MouseUp(sender As Object, e As MouseEventArgs) Handles btnClear.MouseUp
        If frmMain.design = "Dark" Then

        ElseIf frmMain.design = "Light" Then
            btnClear.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnClose_MouseDown(sender As Object, e As MouseEventArgs) Handles btnClose.MouseDown
        If frmMain.design = "Dark" Then
            btnClose.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnClose.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnClose_MouseEnter(sender As Object, e As EventArgs) Handles btnClose.MouseEnter
        If frmMain.design = "Dark" Then
            btnClose.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnClose.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnClose_MouseLeave(sender As Object, e As EventArgs) Handles btnClose.MouseLeave
        If frmMain.design = "Dark" Then
            btnClose.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnClose.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnClose_MouseUp(sender As Object, e As MouseEventArgs) Handles btnClose.MouseUp
        If frmMain.design = "Dark" Then
            btnClose.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnClose.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub
End Class