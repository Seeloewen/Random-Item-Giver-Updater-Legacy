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
End Class