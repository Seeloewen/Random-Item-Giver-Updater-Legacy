Imports System.IO
Imports System.Runtime.CompilerServices

Public Class frmRenameScheme


    Private scheme As String

    '-- Event Handlers --

    Private Sub frmRenameScheme_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load the design
        LoadDesign()

        'Clear previous content
        tbRenameSchemeTo.Clear()
    End Sub

    Public Overloads Sub ShowDialog(scheme As String)
        'Set the scheme and show the window
        Me.scheme = scheme
        ShowDialog()
    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click
        'Rename the scheme that was (hopefully) passed along when the window was opened
        RenameScheme()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Close the window
        Close()
    End Sub


    '-- Custom Methods --

    Public Sub RenameScheme()
        'Check if a scheme is loaded and if it exists, then rename the scheme file and reload the scheme files in the main window
        If String.IsNullOrEmpty(scheme) = False Then
            If File.Exists(String.Format("{0}{1}.txt", frmMain.schemeDirectory, scheme)) Then
                My.Computer.FileSystem.RenameFile(String.Format("{0}{1}.txt", frmMain.schemeDirectory, scheme), String.Format("{0}.txt", tbRenameSchemeTo.Text))
                MsgBox(String.Format("The scheme '{0}' was successfully renamed to '{1}'!", scheme, tbRenameSchemeTo.Text), MsgBoxStyle.Information, "Renamed Scheme")
                frmMain.WriteToLog(String.Format("The scheme '{0}' was successfully renamed to '{1}'!", scheme, tbRenameSchemeTo.Text), "Info")
                frmMain.GetSchemeFiles(frmMain.schemeDirectory)
                frmMain.cbxScheme.Text = tbRenameSchemeTo.Text
                Close()
            Else
                MsgBox("The selected scheme was not found. Make sure the scheme that you want to rename exists!", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Please load a scheme in the Main Window in order to rename it!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Public Sub LoadDesign()
        'Load dark mode
        If frmMain.design = "Dark" Then
            lblSaveSchemeAs.ForeColor = Color.White
            tbRenameSchemeTo.ForeColor = Color.White
            tbRenameSchemeTo.BackColor = Color.DimGray
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