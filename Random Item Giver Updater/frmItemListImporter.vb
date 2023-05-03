Imports System.IO

Public Class frmItemListImporter

    Dim datapackPath As String
    Dim itemList As String()
    Dim dontImportVanillaItems As Boolean
    Dim result As String

    ' -- Event handlers --

    Private Sub frmItemImporter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load user preferences
        LoadDesign()

        'Clear out any existing text on first load
        tbImportFromFile.Clear()

        'Load settings
        If My.Settings.DontImportVanillaItemsByDefault = True Then
            cbDontImportVanilla.Checked = True
        Else
            cbDontImportVanilla.Checked = False
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'Open file browser for selecting file
        ofdImportFromFile.ShowDialog()
        tbImportFromFile.Text = ofdImportFromFile.FileName
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        'Begin import process by changing the controls
        btnImport.Text = "Importing..."
        btnImport.Enabled = False
        datapackPath = tbImportFromFile.Text
        dontImportVanillaItems = cbDontImportVanilla.CheckState
        result = "success"
        rtbItems.Clear()
        frmMain.WriteToLog("Importing item list from " + tbImportFromFile.Text, "Info")

        'Start item list import
        bgwItemListImporter.RunWorkerAsync()
    End Sub

    Private Sub llblCopyCommand_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblCopyCommand.LinkClicked
        'Copy command to clipboard
        Clipboard.SetText("/tellme dump to-file csv items-registry-name-only")
        MsgBox("Copied the command to the clipboard!" + vbNewLine + "Paste it ingame with CTRL + V", MsgBoxStyle.Information, "Copied command")
        frmMain.WriteToLog("Copied command for Item List Importer to clipboard.", "Info")
    End Sub

    Private Sub btnShowPreview_Click(sender As Object, e As EventArgs) Handles btnShowPreview.Click
        'Show preview of item list
        If My.Computer.FileSystem.FileExists(tbImportFromFile.Text) Then
            frmItemListPreview.ShowDialog()
        Else
            MsgBox("Please select a valid file to preview!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub bgwItemListImporter_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwItemListImporter.RunWorkerCompleted
        'Write text to text box in frmMain. If there is already text in frmMain it will ask whether it should overwrite the existing text.
        If result = "success" Then
            If String.IsNullOrEmpty(frmMain.rtbItem.Text) = False Then
                Select Case MsgBox("Do you want to overwrite the text, that is already entered in the main window?" + vbNewLine + vbNewLine + "Click 'yes' to overwrite, click 'no' to append, click 'cancel' to not add the text at all.", vbQuestion + vbYesNoCancel, "Overwrite existing text")
                    Case Windows.Forms.DialogResult.Yes
                        frmMain.rtbItem.Lines = itemList
                        MsgBox("Items were successfully imported and existing text was overwritten!" + vbNewLine + "You can see them in the main window." + vbNewLine + vbNewLine + "Make sure to unselect 'Use the same prefix for all items' if you imported a list that contains prefixes!", MsgBoxStyle.Information, "Import completed")
                        frmMain.WriteToLog("Successfully imported item list to main window.", "Info")
                        Close()
                    Case Windows.Forms.DialogResult.No
                        frmMain.rtbLog.AppendText(vbNewLine)
                        For x As Integer = 0 To itemList.Length - 1
                            frmMain.rtbLog.AppendText(itemList(x))
                        Next
                        MsgBox("Items were successfully imported and appended to the existing text!" + vbNewLine + "You can see them in the main window." + vbNewLine + vbNewLine + "Make sure to unselect 'Use the same prefix for all items' if you imported a list that contains prefixes!", MsgBoxStyle.Information, "Import completed")
                        frmMain.WriteToLog("Successfully imported item list to main window.", "Info")
                        Close()
                    Case Windows.Forms.DialogResult.Cancel
                        MsgBox("Items were not imported.", MsgBoxStyle.Information, "Cancelled")
                End Select
            Else
                frmMain.rtbItem.Lines = itemList
                MsgBox("Items were successfully imported!" + vbNewLine + "You can see them in the main window." + vbNewLine + vbNewLine + "Make sure to unselect 'Use the same prefix for all items' if you imported a list that contains prefixes!", MsgBoxStyle.Information, "Import completed")
                frmMain.WriteToLog("Successfully imported item list to main window.", "Info")
                Close()
            End If
        Else
            MsgBox("An error occured while importing items." + MsgBoxStyle.Information, "Error")
        End If

        'Reset controls to default state
        btnImport.Text = "Import Item List"
        btnImport.Enabled = True
    End Sub

    ' -- Custom methods --

    Private Sub bgwItemListImporter_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwItemListImporter.DoWork

        Try
            If My.Computer.FileSystem.FileExists(datapackPath) Then
                'Read item list from file
                itemList = File.ReadAllLines(datapackPath)

                'Remove text if file was generated using TellMe Mod
                For x As Integer = 0 To itemList.Length - 1
                    itemList(x) = itemList(x).Replace("Registry name", "")
                Next

                'Add quotation marks to avoid some issues
                For x As Integer = 0 To itemList.Length - 1
                    itemList(x) = frmMain.qm + itemList(x) + frmMain.qm
                Next

                'Remove vanilla items if enabled
                If dontImportVanillaItems = True Then
                    For x As Integer = 0 To itemList.Length - 1
                        itemList(x) = itemList(x).Replace("minecraft:", "")
                    Next
                End If

                'Remove quotation mark
                For x As Integer = 0 To itemList.Length - 1
                    itemList(x) = itemList(x).Replace(Chr(34), "")
                Next

                'Remove empty lines
                Dim withoutEmptyLines As New List(Of String)
                For x As Integer = 0 To itemList.Length - 1
                    If Not itemList(x).Trim.Equals(String.Empty) Then
                        withoutEmptyLines.Add(itemList(x))
                    End If
                Next
                itemList = withoutEmptyLines.ToArray

            ElseIf String.IsNullOrEmpty(datapackPath) Then
                MsgBox("Please select a valid file!", MsgBoxStyle.Critical, "Error")
                result = "failed"
            Else
                MsgBox("The selected file does not exist!", MsgBoxStyle.Critical, "Error")
                result = "failed"
            End If
        Catch ex As Exception
            MsgBox("An error occured while trying to import items: " + ex.Message, MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog("Importing items failed: " + ex.Message, "Error")
            result = "failed"
        End Try
    End Sub

    Private Sub LoadDesign()
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

        'Load dark mode
        If frmMain.design = "Dark" Then
            BackColor = Color.FromArgb(50, 50, 50)
            lblHeader.ForeColor = Color.White
            lblImportDesc.ForeColor = Color.White
            llblCopyCommand.LinkColor = Color.LightBlue
            tbImportFromFile.BackColor = Color.DimGray
            cbDontImportVanilla.ForeColor = Color.White
            tbImportFromFile.ForeColor = Color.White
        End If
    End Sub

    '-- Button animations --

    Private Sub btnBrowse_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBrowse.MouseDown
        If frmMain.design = "Dark" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnBrowse_MouseEnter(sender As Object, e As EventArgs) Handles btnBrowse.MouseEnter
        If frmMain.design = "Dark" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnBrowse_MouseLeave(sender As Object, e As EventArgs) Handles btnBrowse.MouseLeave
        If frmMain.design = "Dark" Then
            btnBrowse.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnBrowse_MouseUp(sender As Object, e As MouseEventArgs) Handles btnBrowse.MouseUp
        If frmMain.design = "Dark" Then
            btnBrowse.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnImport_MouseDown(sender As Object, e As MouseEventArgs) Handles btnImport.MouseDown
        If frmMain.design = "Dark" Then
            btnImport.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnImport.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnImport_MouseEnter(sender As Object, e As EventArgs) Handles btnImport.MouseEnter
        If frmMain.design = "Dark" Then
            btnImport.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnImport.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnImport_MouseLeave(sender As Object, e As EventArgs) Handles btnImport.MouseLeave
        If frmMain.design = "Dark" Then
            btnImport.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnImport.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnImport_MouseUp(sender As Object, e As MouseEventArgs) Handles btnImport.MouseUp
        If frmMain.design = "Dark" Then
            btnImport.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnImport.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnShowPreview_MouseDown(sender As Object, e As MouseEventArgs) Handles btnShowPreview.MouseDown
        If frmMain.design = "Dark" Then
            btnShowPreview.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnShowPreview.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnShowPreview_MouseEnter(sender As Object, e As EventArgs) Handles btnShowPreview.MouseEnter
        If frmMain.design = "Dark" Then
            btnShowPreview.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnShowPreview.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnShowPreview_MouseLeave(sender As Object, e As EventArgs) Handles btnShowPreview.MouseLeave
        If frmMain.design = "Dark" Then
            btnShowPreview.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnShowPreview.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnShowPreview_MouseUp(sender As Object, e As MouseEventArgs) Handles btnShowPreview.MouseUp
        If frmMain.design = "Dark" Then
            btnShowPreview.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnShowPreview.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub
End Class