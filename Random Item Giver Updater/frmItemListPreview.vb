
Public Class frmItemListPreview

    ' -- Event handlers --

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'Close window
        Close()
    End Sub

    Private Sub frmItemListPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Clear any existing text
        rtbItems.Clear()

        'Load full text from file specified in frmItemImporter
        rtbItems.Text = My.Computer.FileSystem.ReadAllText(frmItemListImporter.tbImportFromFile.Text)

        'Remove text if file was generated using TellMe Mod
        If rtbItems.Text.Contains("Registry name") Then
            rtbItems.Text = rtbItems.Text.Replace("Registry name", "")
        End If

        'Add quotation marks to avoid some issues
        rtbItems.Text = AppendTextToRichtextbox(frmMain.qm, rtbItems.Text)

        'Remove quotation mark
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

        'Load dark mode
        If My.Settings.Design = "Dark" Then
            BackColor = Color.FromArgb(50, 50, 50)
            gbItemList.ForeColor = Color.White
            rtbItems.BackColor = Color.FromArgb(50, 50, 50)
            rtbItems.ForeColor = Color.White
        End If
    End Sub

    '-- Custom methods --

    Private Function AppendTextToRichtextbox(textToAppend As String, richtextboxtext As String) As String
        'Append text to Richtextbox... honestly unsure how this works.
        Return String.Join(Environment.NewLine, richtextboxtext.
                       Split(Environment.NewLine.ToArray(), StringSplitOptions.RemoveEmptyEntries).
                       Select(Function(s) s & textToAppend))
    End Function

    '-- Button animations --

    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        btnOK.BackgroundImage = My.Resources.imgButtonClick
    End Sub

    Private Sub btnOK_MouseEnter(sender As Object, e As EventArgs) Handles btnOK.MouseEnter
        btnOK.BackgroundImage = My.Resources.imgButtonHover
    End Sub

    Private Sub btnOK_MouseLeave(sender As Object, e As EventArgs) Handles btnOK.MouseLeave
        btnOK.BackgroundImage = My.Resources.imgButton
    End Sub

    Private Sub btnOK_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOK.MouseUp
        btnOK.BackgroundImage = My.Resources.imgButton
    End Sub
End Class