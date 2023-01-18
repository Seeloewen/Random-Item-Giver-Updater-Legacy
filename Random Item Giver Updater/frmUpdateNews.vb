Public Class frmUpdateNews

    '-- Event handlers --

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Close()
    End Sub

    Private Sub llblFullChangelog_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblFullChangelog.LinkClicked
        frmChangelog.ShowDialog()
    End Sub
End Class