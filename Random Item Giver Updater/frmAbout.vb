Public Class frmAbout
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Close()
    End Sub

    Private Sub llblLicense_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Process.Start("https://www.gnu.org/licenses/gpl-3.0.en.html")
    End Sub

    Private Sub llblGithub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblGithub.LinkClicked
        Process.Start("https://github.com/Seeloewen/Random-Item-Giver-Updater")
    End Sub
End Class