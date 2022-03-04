Public Class frmAbout
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Close()
    End Sub

    Private Sub llblLicense_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblLicense.LinkClicked
        Process.Start("https://www.gnu.org/licenses/gpl-3.0.en.html")
    End Sub
End Class