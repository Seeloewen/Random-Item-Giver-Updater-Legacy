Public Class frmAbout

    '-- Event Handlers --

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'Close the window
        Close()
    End Sub

    Private Sub llblLicense_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        'Open GNU GPL v3 website
        Process.Start("https://www.gnu.org/licenses/gpl-3.0.en.html")
    End Sub

    Private Sub llblGithub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblGithub.LinkClicked
        'Open Github Random Item Giver Updater Repository
        Process.Start("https://github.com/Seeloewen/Random-Item-Giver-Updater")
    End Sub

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            lblHeader.ForeColor = Color.White
            lblBuild.ForeColor = Color.White
            gbLicense.ForeColor = Color.White
            rtbLicense.BackColor = Color.FromArgb(50, 50, 50)
            BackColor = Color.FromArgb(50, 50, 50)
            rtbLicense.ForeColor = Color.White
            llblGithub.LinkColor = Color.LightBlue
        End If
    End Sub

    '-- Button animations --

    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        If frmMain.design = "Dark" Then
            btnOK.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnOK.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnOK_MouseEnter(sender As Object, e As EventArgs) Handles btnOK.MouseEnter
        If frmMain.design = "Dark" Then
            btnOK.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnOK.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnOK_MouseLeave(sender As Object, e As EventArgs) Handles btnOK.MouseLeave
        If frmMain.design = "Dark" Then
            btnOK.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnOK.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnOK_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOK.MouseUp
        If frmMain.design = "Dark" Then
            btnOK.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnOK.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub
End Class