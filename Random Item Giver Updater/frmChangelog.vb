Public Class frmChangelog

    '-- Event Handlers --

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'Close the window
        Close()
    End Sub

    Private Sub frmChangelog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load dark mode
        If My.Settings.Design = "Dark" Then
            lblHeader.ForeColor = Color.White
            gbChangelog.ForeColor = Color.White
            BackColor = Color.FromArgb(50, 50, 50)
            rtbChangelog.BackColor = Color.FromArgb(50, 50, 50)
            rtbChangelog.ForeColor = Color.White
        End If
    End Sub

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