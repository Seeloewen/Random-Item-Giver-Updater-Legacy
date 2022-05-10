Public Class frmItemImporter

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        ofdImportFromFile.ShowDialog()
        tbImportFromFile.Text = ofdImportFromFile.FileName
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        If My.Computer.FileSystem.FileExists(tbImportFromFile.Text) Then
            btnImport.Text = "Importing..."
            btnImport.Enabled = False
            frmMain.WriteToLog("-- Importing item list --", "Info")
            rtbItems.Text = My.Computer.FileSystem.ReadAllText(tbImportFromFile.Text)

            'Remove text if file was generated using TellMe Mod
            If rtbItems.Text.Contains("Registry name") Then
                rtbItems.Text = rtbItems.Text.Replace("Registry name", "")
            End If

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
            frmMain.rtbItem.Text = rtbItems.Text

            btnImport.Text = "Import Item List"
            btnImport.Enabled = True
            MsgBox("Items were successfully imported!" + vbNewLine + "You can see them in the main window." + vbNewLine + vbNewLine + "Make sure to unselect 'Use the same prefix for all items'.", MsgBoxStyle.Information, "Import completed")
            frmMain.WriteToLog("Successfully imported item list to main window.", "Info")
            Close()
        ElseIf String.IsNullOrEmpty(tbImportFromFile.Text) Then
            MsgBox("Please select a file in the format .txt or .csv!", MsgBoxStyle.Critical, "Error")
        Else
            MsgBox("The selected file does not exist!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llbl.LinkClicked
        Clipboard.SetText("/tellme dump to-file csv items-registry-name-only")
        MsgBox("Copied the command to the clipboard!" + vbNewLine + "Paste it ingame with CTRL + V", MsgBoxStyle.Information, "Copied command")
        frmMain.WriteToLog("Copied command for Item List Importer to clipboard.", "Info")
    End Sub
End Class