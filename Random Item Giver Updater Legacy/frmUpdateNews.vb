Public Class frmUpdateNews

    '-- Event handlers --

    Private Sub frmUpdateNews_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load the design
        LoadDesign()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'Close the window
        Close()
    End Sub

    Private Sub llblFullChangelog_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblFullChangelog.LinkClicked
        'Show the changelog
        frmChangelog.ShowDialog()
    End Sub

    '-- Custom Methods --
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
            'Labels
            For Each ctrl As Control In Controls
                If TypeOf ctrl Is Label Then
                    ctrl.ForeColor = Color.White
                End If
            Next

            'Everything else
            BackColor = Color.FromArgb(50, 50, 50)
            llblFullChangelog.LinkColor = Color.LightBlue
        End If
    End Sub

    '-- Button animations --

    Private Sub btnOK_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOK.MouseDown
        If frmmain.design = "Dark" Then
            btnOK.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmmain.design = "Light" Then
            btnOK.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnOK_MouseEnter(sender As Object, e As EventArgs) Handles btnOK.MouseEnter
        If frmmain.design = "Dark" Then
            btnOK.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmmain.design = "Light" Then
            btnOK.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnOK_MouseLeave(sender As Object, e As EventArgs) Handles btnOK.MouseLeave
        If frmmain.design = "Dark" Then
            btnOK.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design = "Light" Then
            btnOK.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnOK_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOK.MouseUp
        If frmmain.design = "Dark" Then
            btnOK.BackgroundImage = My.Resources.imgButton
        ElseIf frmmain.design = "Light" Then
            btnOK.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub
End Class