Imports System.IO

Public Class frmDuplicateFinder

    'Variables
    Dim datapackPath As String = "None"
    Dim pathAmount As String = "None"
    Dim datapackVersion As String = "None"
    Dim withDuplicates As String()
    Dim withDuplicatesArray As String()
    Dim duplicatesOnly As String()
    Dim duplicateFinderResult As String
    Dim duplicateFinderProgress As Double
    Dim backgroundWorkerProgress As Double

    '-- Event Handlers --

    Private Sub frmDuplicateFinder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            lvDuplicates.BackColor = Color.FromArgb(50, 50, 50)
            lvDuplicates.ForeColor = Color.White
            tbDatapackPath.BackColor = Color.DimGray
            tbDatapackPath.ForeColor = Color.White
        End If
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        'If datapack path isn't empty, begin checking for duplicates. If empty, a warning will be shown.
        If Not String.IsNullOrEmpty(tbDatapackPath.Text) Then
            'Check if entered path is valid, if not, show error.
            If My.Computer.FileSystem.DirectoryExists(tbDatapackPath.Text) Then
                'Check if the datapack is valid
                CheckDatapack()

                'Reset previous progress to 0
                backgroundWorkerProgress = 0
                duplicateFinderProgress = 0
                pbProgress.Value = 0

                'Set result to success. If an error occurs during the check process, this will be changed. If not, this value will stay until the end.
                duplicateFinderResult = "success"

                'Change controls to show progress
                btnCheck.Text = "Checking..."
                btnCheck.Enabled = False
                btnBrowse.Enabled = False
                btnLoadProfile.Enabled = False
                tbDatapackPath.Enabled = False
                lblDuplicatesAmount.Hide()
                lblChecking.Show()
                pbProgress.Show()

                'Announce that process has begun and write to log
                MsgBox("Duplicate finder will now search for duplicates in the selected datapack. This may take a while.", MsgBoxStyle.Information, "Duplicate Finder")
                frmMain.WriteToLog("Checking for duplicates...", "Info")

                'Clear duplicate list as it might contain previous entries
                lvDuplicates.Clear()
                lvDuplicates.Columns.Add("Item")
                lvDuplicates.Columns(0).Width = 256
                lvDuplicates.Columns.Add("Loot Table")
                lvDuplicates.Columns(1).Width = 266

                'Start the BackGroundWorker for the actual process
                bgwSearchForDuplicates.RunWorkerAsync()
            Else
                MsgBox("The datapack path you have entered is not valid.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Please enter a datapack path!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        'Open FolderBrowserDialog for selecting a datapack path 
        fbdMainFolderPath.ShowDialog()
        tbDatapackPath.Text = fbdMainFolderPath.SelectedPath
    End Sub

    Private Sub bgwSearchForDuplicates_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwSearchForDuplicates.RunWorkerCompleted

        'Report progress
        pbProgress.Value = 100

        'Announce if searching for duplicates completed or failed
        If duplicateFinderResult = "success" Then
            lblDuplicatesAmount.Text = $"Found {lvDuplicates.Items.Count} duplicates In total."
            frmMain.WriteToLog($"Checking For duplicates completed. Found {lvDuplicates.Items.Count} duplicates in total.", "Info")
            MsgBox("Checking For duplicates is complete." + vbNewLine + "You can see the results in the list behind this message." + vbNewLine + "If the list is empty then there aren't any duplicates.", MsgBoxStyle.Information, "Duplicate Finder")
        Else
            lblDuplicatesAmount.Text = "Searching for duplicates failed."
            frmMain.WriteToLog("Searching for duplicates failed with 1 or more errors.", "Error")
        End If

        'Change controls back to normal state
        btnCheck.Enabled = True
        btnBrowse.Enabled = True
        tbDatapackPath.Enabled = True
        btnLoadProfile.Enabled = True
        lblChecking.Hide()
        lblDuplicatesAmount.Show()
        pbProgress.Hide()
        btnCheck.Text = "Check"
    End Sub

    Private Sub bgwSearchForDuplicates_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwSearchForDuplicates.ProgressChanged
        'Synchronize ProgressBar with BackGroundWorker progress
        pbProgress.Value = e.ProgressPercentage
    End Sub

    Private Sub bgwSearchForDuplicates_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwSearchForDuplicates.DoWork
        'Begin the duplicate finder process
        InitializeChecking()
    End Sub

    Private Sub btnLoadProfile_Click(sender As Object, e As EventArgs) Handles btnLoadProfile.Click
        'Show profile loader
        frmLoadProfileFrom.ShowDialog("Duplicate Finder")
    End Sub

    '-- Custom Methods --
    Private Sub CheckDatapack()
        'Check the datapack version by reading the pack format in the pack.mcmeta file
        Try
            Dim version As Integer = File.ReadAllLines($"{tbDatapackPath.Text}/pack.mcmeta")(2).Replace("    ""pack_format"": ", "").Replace(",", "")

            Select Case version
                Case 48 To 71
                    datapackVersion = "1.21"
                Case 16 To 47
                    datapackVersion = "1.20.2"
                Case 15
                    If File.Exists($"{tbDatapackPath.Text}/updater.txt") Then
                        datapackVersion = "1.20.1"
                    Else
                        datapackVersion = "1.20"
                    End If
                Case 14 Or 13
                    datapackVersion = "1.20"
                Case 10 To 12
                    datapackVersion = "1.19"
                Case 8 Or 9
                    datapackVersion = "1.18"
                Case 7
                    datapackVersion = "1.17"
                Case 6
                    datapackVersion = "1.16"
                Case Else
                    datapackVersion = "Null"
            End Select

            If datapackVersion = "1.21" Then
                datapackPath = $"{tbDatapackPath.Text}/data/randomitemgiver/loot_table/"
            Else
                datapackPath = $"{tbDatapackPath.Text}/data/randomitemgiver/loot_tables/"
            End If

            frmMain.WriteToLog($"Detected datapack as version {datapackVersion} In duplicate finder", "Info")
        Catch ex As Exception
            MsgBox($"Error {ex.Message}" + +vbNewLine + vbNewLine + "Searching for duplicates may fail since the datapack is invalid.", MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog("Selected datapack in duplicate finder is invalid.", "Error")
        End Try
    End Sub

    Private Sub InitializeChecking()
        'Decide which loot tables to check depending on the datapack version
        If datapackVersion = "1.20.2" OrElse datapackVersion = "1.21" Then

            'Set progress step
            duplicateFinderProgress = 2.5

            Try

                Dim amount As Integer = 1
                For i As Integer = 1 To 9
                    '1 item
                    CheckLootTable(amount, "normal_items")
                    CheckLootTable(amount, "other_items")
                    CheckLootTable(amount, "command_blocks")
                    CheckLootTable(amount, "spawn_eggs")

                    Select Case amount
                        Case 1
                            amount = 2
                        Case 2
                            amount = 3
                        Case 3
                            amount = 5
                        Case 5
                            amount = 10
                        Case 10
                            amount = 32
                        Case 32
                            amount = 64
                        Case 64
                            amount = -1
                        Case -1
                            amount = -2
                    End Select
                Next

            Catch ex As Exception
                MsgBox($"Error: {ex.Message}", "Error")
                duplicateFinderResult = "failed"
            End Try

        ElseIf datapackVersion = "1.20.1" OrElse datapackVersion = "1.20" OrElse datapackVersion = "1.19" Or datapackVersion = "1.16" Then
            'Set progress step
            duplicateFinderProgress = 1.38

            Try

                Dim amount As Integer = 1
                For i As Integer = 1 To 9
                    '1 item
                    CheckLootTable(amount, "main")
                    CheckLootTable(amount, "main_without_creative-only")
                    CheckLootTable(amount, "special_vvx")
                    CheckLootTable(amount, "special_vxv")
                    CheckLootTable(amount, "special_vxx")
                    CheckLootTable(amount, "special_xvv")
                    CheckLootTable(amount, "special_xvx")
                    CheckLootTable(amount, "special_xxv")

                    Select Case amount
                        Case 1
                            amount = 2
                        Case 2
                            amount = 3
                        Case 3
                            amount = 5
                        Case 5
                            amount = 10
                        Case 10
                            amount = 32
                        Case 32
                            amount = 64
                        Case 64
                            amount = -1
                        Case -1
                            amount = -2
                    End Select
                Next
            Catch ex As Exception
                MsgBox(String.Format("Error: {0}", ex.Message), MsgBoxStyle.Critical, "Error")
                duplicateFinderResult = "failed"
            End Try
        ElseIf datapackVersion = "1.18" Then
            '1.18 has less loot tables (missing the 'Random Amount Same/Different Item' ones), so the progress should be higher
            duplicateFinderProgress = 1.78

            Try
                Dim amount As Integer = 1
                For i As Integer = 1 To 7
                    '1 item
                    CheckLootTable(amount, "main")
                    CheckLootTable(amount, "main_without_creative-only")
                    CheckLootTable(amount, "special_vvx")
                    CheckLootTable(amount, "special_vxv")
                    CheckLootTable(amount, "special_vxx")
                    CheckLootTable(amount, "special_xvv")
                    CheckLootTable(amount, "special_xvx")
                    CheckLootTable(amount, "special_xxv")

                    Select Case amount
                        Case 1
                            amount = 2
                        Case 2
                            amount = 3
                        Case 3
                            amount = 5
                        Case 5
                            amount = 10
                        Case 10
                            amount = 32
                        Case 32
                            amount = 64
                    End Select
                Next
            Catch ex As Exception
                MsgBox($"Error: {ex.Message}", "Error")
                duplicateFinderResult = "failed"
            End Try
        ElseIf datapackVersion = "1.17" Then
            duplicateFinderProgress = 12.5
            Try
                CheckLootTable(1, "main")
                CheckLootTable(1, "main_without_creative-only")
                CheckLootTable(1, "special_vvx")
                CheckLootTable(1, "special_vxv")
                CheckLootTable(1, "special_vxx")
                CheckLootTable(1, "special_xvv")
                CheckLootTable(1, "special_xvx")
                CheckLootTable(1, "special_xxv")
            Catch ex As Exception
                MsgBox($"Error: {ex.Message}", MsgBoxStyle.Critical, "Error")
                duplicateFinderResult = "failed"
            End Try
        ElseIf datapackVersion = "Null" Then
            duplicateFinderResult = "failed"
            MsgBox("The datapack version could not be determined." + vbNewLine + "Cannot search for duplicates.", MsgBoxStyle.Critical, "Error")
        Else
            duplicateFinderResult = "failed"
            MsgBox("An unknown error occured." + vbNewLine + "Cannot search for duplicates.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub CheckLootTable(itemAmount As Integer, lootTable As String) 'Check a single loot table for duplicates
        'Setup variables depending on the datapack version and Item Amount
        If datapackVersion = "1.17" Then
            pathAmount = ""
        Else
            If datapackVersion = "1.20.1" OrElse datapackVersion = "1.20.2" OrElse datapackVersion = "1.21" Then
                If itemAmount = 1 Then
                    pathAmount = "01item/"
                ElseIf itemAmount = 2 Then
                    pathAmount = "02sameitems/"
                ElseIf itemAmount = 3 Then
                    pathAmount = "03sameitems/"
                ElseIf itemAmount = 5 Then
                    pathAmount = "05sameitems/"
                End If
            Else
                If itemAmount = 1 Then
                    pathAmount = "1item/"
                ElseIf itemAmount = 2 Then
                    pathAmount = "2sameitems/"
                ElseIf itemAmount = 3 Then
                    pathAmount = "3sameitems/"
                ElseIf itemAmount = 5 Then
                    pathAmount = "5sameitems/"
                End If
            End If
            If itemAmount = 10 Then
                pathAmount = "10sameitems/"
            ElseIf itemAmount = 32 Then
                pathAmount = "32sameitems/"
            ElseIf itemAmount = 64 Then
                pathAmount = "64sameitems/"
            ElseIf itemAmount = -1 Then
                pathAmount = "randomamountsameitem/"
            ElseIf itemAmount = -2 Then
                pathAmount = "randomamountdifitems/"
            End If
        End If

        'Load text from file into Array
        withDuplicates = File.ReadAllLines($"{datapackPath}{pathAmount}{lootTable}.json")

        'Set list of text that has to be removed
        Dim textToRemove As String() =
            {
                """type"": ""minecraft:item"",",
                """type"": ""item"",",
                """rolls"": {",
                """min"": 1,",
                """max"": 64",
                """name"": ""out""",
                """name"": ""RandomItemGiver""",
                """entries"": [",
                """rolls"": 1,",
                """pools"": [",
                """name"": ",
                """functions"": [",
                """function"": ""minecraft:set_count"",",
                """count"": 10",
                """count"": 32",
                """count"": 64",
                """count"": 2",
                """count"": 3",
                """count"": 5",
                """count"": {",
                """type"": ""minecraft:score"",",
                """target"": {",
                """type"": ""minecraft:fixed"",",
                """score"": ""RandomAmountSameItemsGen""",
                """score"": ""RandomAmountSameItemsNumber""",
                """score"": ""rig_RandomAmountSameItemsNumber""",
                "minecraft:",
                "{",
                "}",
                ",",
                "]",
                " "
            }

        'Remove unnessecary characters from WithDuplicates
        For x As Integer = 0 To withDuplicates.Length - 1
            For Each text As String In textToRemove
                withDuplicates(x) = withDuplicates(x).Replace(text, "")
            Next
        Next

        'Remove empty lines from WithDuplicates
        Dim WithoutEmptyLines As New List(Of String)
        For Each line As String In withDuplicates
            If Not line.Trim.Equals(String.Empty) Then
                WithoutEmptyLines.Add(line)
            End If
        Next
        withDuplicates = WithoutEmptyLines.ToArray

        'Find duplicate lines and put them into a list
        Dim duplicates As List(Of String) =
                   withDuplicates.GroupBy(Function(n) n) _
                   .Where(Function(g) g.Count() > 1) _
                   .Select(Function(g) g.First) _
                   .ToList()

        'Convert duplicate list to array and load into richtextbox
        duplicatesOnly = duplicates.ToArray

        'Remove quotationmarks from item names in the duplicates richtextbox
        For x As Integer = 0 To duplicatesOnly.Length - 1
            duplicatesOnly(x) = duplicatesOnly(x).Replace("""", "")
        Next

        'Log duplicates into listview
        Dim numLinesOnlyDups As Integer = duplicatesOnly.Length
        Dim doLoopNum As Integer
        Dim str(1) As String
        Dim item As ListViewItem

        While doLoopNum < numLinesOnlyDups
            str(0) = duplicatesOnly(doLoopNum)
            str(1) = pathAmount + lootTable
            item = New ListViewItem(str)
            Invoke(Sub() lvDuplicates.Items.Add(item))
            doLoopNum = doLoopNum + 1
        End While

        'Report aand log that the process has finished
        backgroundWorkerProgress += duplicateFinderProgress
        bgwSearchForDuplicates.ReportProgress(backgroundWorkerProgress)
        frmMain.WriteToLog($"Completed checking {lootTable}", "Info")
    End Sub

    '-- Button animations --

    Private Sub btnBrowse_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBrowse.MouseDown
        If frmMain.design = "Dark" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnBrowse_MouseEnter(sender As Object, e As EventArgs) Handles btnBrowse.MouseEnter
        If frmMain.design = "Dark" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnBrowse_MouseLeave(sender As Object, e As EventArgs) Handles btnBrowse.MouseLeave
        If frmMain.design = "Dark" Then
            btnBrowse.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnBrowse_MouseUp(sender As Object, e As MouseEventArgs) Handles btnBrowse.MouseUp
        If frmMain.design = "Dark" Then
            btnBrowse.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnBrowse.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnCheck_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCheck.MouseDown
        If frmMain.design = "Dark" Then
            btnCheck.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnCheck.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnCheck_MouseEnter(sender As Object, e As EventArgs) Handles btnCheck.MouseEnter
        If frmMain.design = "Dark" Then
            btnCheck.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnCheck.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnCheck_MouseLeave(sender As Object, e As EventArgs) Handles btnCheck.MouseLeave
        If frmMain.design = "Dark" Then
            btnCheck.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnCheck.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnCheck_MouseUp(sender As Object, e As MouseEventArgs) Handles btnCheck.MouseUp
        If frmMain.design = "Dark" Then
            btnCheck.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnCheck.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnLoadProfile_MouseDown(sender As Object, e As MouseEventArgs) Handles btnLoadProfile.MouseDown
        If frmMain.design = "Dark" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnLoadProfile_MouseEnter(sender As Object, e As EventArgs) Handles btnLoadProfile.MouseEnter
        If frmMain.design = "Dark" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnLoadProfile_MouseLeave(sender As Object, e As EventArgs) Handles btnLoadProfile.MouseLeave
        If frmMain.design = "Dark" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnLoadProfile_MouseUp(sender As Object, e As MouseEventArgs) Handles btnLoadProfile.MouseUp
        If frmMain.design = "Dark" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub
End Class