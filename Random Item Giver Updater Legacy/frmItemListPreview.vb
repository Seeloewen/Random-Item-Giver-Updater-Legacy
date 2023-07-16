
Public Class frmItemListPreview

    ' -- Event handlers --

    Private Sub frmItemListPreview_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Load user preferences
            LoadDesign()

            'Clear any existing text
            rtbItems.Clear()

            'Load full text from file specified in frmItemImporter
            rtbItems.Text = My.Computer.FileSystem.ReadAllText(frmItemListImporter.tbImportFromFile.Text)

            'Remove text if file was generated using TellMe Mod
            If rtbItems.Text.Contains("Registry name") Then
                rtbItems.Text = rtbItems.Text.Replace("Registry name", "")
            End If

            'Remove empty lines
            Dim withoutEmptyLines As New List(Of String)
            For Each line As String In rtbItems.Lines
                If Not line.Trim.Equals(String.Empty) Then
                    WithoutEmptyLines.Add(line)
                End If
            Next
            rtbItems.Lines = withoutEmptyLines.ToArray

        Catch ex As Exception
            MsgBox(String.Format("Error while loading the Item Preview: {0}", ex.Message), MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog(String.Format("Failed to load Item Preview from file {0}: {1}", frmItemListImporter.tbImportFromFile.Text, ex.Message), "Error")
        End Try
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'Close window
        Close()
    End Sub

    '-- Custom methods --

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
            gbItemList.ForeColor = Color.White
            rtbItems.BackColor = Color.FromArgb(50, 50, 50)
            rtbItems.ForeColor = Color.White
        End If
    End Sub

    '-- Button animations --

    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        If frmmain.design =  "Dark" Then
            btnOK.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmmain.design =  "Light" Then
            btnOK.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnOK_MouseEnter(sender As Object, e As EventArgs) Handles btnOK.MouseEnter
        If frmmain.design =  "Dark" Then
            btnOK.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmmain.design =  "Light" Then
            btnOK.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnOK_MouseLeave(sender As Object, e As EventArgs) Handles btnOK.MouseLeave
        If frmmain.design =  "Dark" Then
            btnOK.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design =  "Light" Then
            btnOK.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnOK_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOK.MouseUp
        If frmmain.design =  "Dark" Then
            btnOK.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design =  "Light" Then
            btnOK.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub
End Class