Public Class frmItemImporter

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        ofdImportFromFile.ShowDialog()
        tbImportFromFile.Text = ofdImportFromFile.FileName
    End Sub

    Private Function AppendTextToRichtextbox(TextToAppend As String, Richtextboxtext As String) As String
        Return String.Join(Environment.NewLine, Richtextboxtext.
                       Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).
                       Select(Function(s) s & TextToAppend))
    End Function

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        If My.Computer.FileSystem.FileExists(tbImportFromFile.Text) Then
            btnImport.Text = "Importing..."
            btnImport.Enabled = False
            frmMain.WriteToLog("Importing item list from " + tbImportFromFile.Text, "Info")
            rtbItems.Clear()
            rtbItems.Text = My.Computer.FileSystem.ReadAllText(tbImportFromFile.Text)

            'Remove text if file was generated using TellMe Mod
            If rtbItems.Text.Contains("Registry name") Then
                rtbItems.Text = rtbItems.Text.Replace("Registry name", "")
            End If

            'Add quotation marks to avoid some issues
            rtbItems.Text = AppendTextToRichtextbox(frmMain.qm, rtbItems.Text)

            'Remove vanilla items
            If cbDontImportVanilla.Checked Then
                For Each line As String In rtbItems.Lines
                    If line.Contains("minecraft:") Then
                        rtbItems.Text = rtbItems.Text.Replace(line, "")
                    End If
                Next
            End If

            If rtbItems.Text.Contains(frmMain.qm) Then
                rtbItems.Text = rtbItems.Text.Replace(frmMain.qm, "")
            End If

            'Remove empty lines
            Dim WithoutEmptyLines As New List(Of String)
            For Each s As String In rtbItems.Lines
                If Not s.Trim.Equals(String.Empty) Then
                    WithoutEmptyLines.Add(s)
                End If
            Next
            rtbItems.Lines = WithoutEmptyLines.ToArray

            'Write text to text box in frmMain
            If String.IsNullOrEmpty(frmMain.rtbItem.Text) = False Then
                Select Case MsgBox("Do you want to overwrite the text, that is already entered in the main window?" + vbNewLine + vbNewLine + "Click 'yes' to overwrite, click 'no' to append, click 'cancel' to not add the text at all.", MsgBoxStyle.YesNoCancel, "Overwrite existing text")
                    Case Windows.Forms.DialogResult.Yes
                        frmMain.rtbItem.Text = rtbItems.Text
                        MsgBox("Items were successfully imported and existing text was overwritten!" + vbNewLine + "You can see them in the main window." + vbNewLine + vbNewLine + "Make sure to unselect 'Use the same prefix for all items' if you imported a list that contains prefixes!", MsgBoxStyle.Information, "Import completed")
                        frmMain.WriteToLog("Successfully imported item list to main window.", "Info")
                        Close()
                    Case Windows.Forms.DialogResult.No
                        frmMain.rtbItem.AppendText(vbNewLine + rtbItems.Text)
                        MsgBox("Items were successfully imported and appended to the existing text!" + vbNewLine + "You can see them in the main window." + vbNewLine + vbNewLine + "Make sure to unselect 'Use the same prefix for all items' if you imported a list that contains prefixes!", MsgBoxStyle.Information, "Import completed")
                        frmMain.WriteToLog("Successfully imported item list to main window.", "Info")
                        Close()
                    Case Windows.Forms.DialogResult.Cancel
                        MsgBox("Items were not imported.", MsgBoxStyle.Information, "Cancelled")
                End Select
            Else
                frmMain.rtbItem.Text = rtbItems.Text
                MsgBox("Items were successfully imported!" + vbNewLine + "You can see them in the main window." + vbNewLine + vbNewLine + "Make sure to unselect 'Use the same prefix for all items' if you imported a list that contains prefixes!", MsgBoxStyle.Information, "Import completed")
                frmMain.WriteToLog("Successfully imported item list to main window.", "Info")
                Close()
            End If

            btnImport.Text = "Import Item List"
            btnImport.Enabled = True
        ElseIf String.IsNullOrEmpty(tbImportFromFile.Text) Then
            MsgBox("Please select a file in the format .txt or .csv!", MsgBoxStyle.Critical, "Error")
        Else
            MsgBox("The selected file does not exist!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblCopyCommand.LinkClicked
        Clipboard.SetText("/tellme dump to-file csv items-registry-name-only")
        MsgBox("Copied the command to the clipboard!" + vbNewLine + "Paste it ingame with CTRL + V", MsgBoxStyle.Information, "Copied command")
        frmMain.WriteToLog("Copied command for Item List Importer to clipboard.", "Info")
    End Sub

    Private Sub frmItemImporter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbImportFromFile.Clear()

        If My.Settings.DontImportVanillaItemsByDefault = True Then
            cbDontImportVanilla.Checked = True
        Else
            cbDontImportVanilla.Checked = False
        End If
    End Sub

    Private Sub btnShowPreview_Click(sender As Object, e As EventArgs) Handles btnShowPreview.Click
        If My.Computer.FileSystem.FileExists(tbImportFromFile.Text) Then
            frmItemListPreview.ShowDialog()
        Else
            MsgBox("Please select a valid file to preview!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub
End Class