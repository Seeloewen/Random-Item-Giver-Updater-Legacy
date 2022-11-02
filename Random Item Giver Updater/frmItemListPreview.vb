Imports Microsoft.Win32

Public Class frmItemListPreview
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Close()
    End Sub

    Private Sub frmItemListPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rtbItems.Clear()

        'Load full text from file specified in frmItemImporter
        rtbItems.Text = My.Computer.FileSystem.ReadAllText(frmItemImporter.tbImportFromFile.Text)

        'Remove unnecessary text
        If rtbItems.Text.Contains("Registry name") Then
            rtbItems.Text = rtbItems.Text.Replace("Registry name", "")
        End If

        'Remove empty lines
        Dim WithoutEmptyLines As New List(Of String)
        For Each s As String In rtbItems.Lines
            If Not s.Trim.Equals(String.Empty) Then
                WithoutEmptyLines.Add(s)
            End If
        Next
        rtbItems.Lines = WithoutEmptyLines.ToArray
    End Sub
End Class