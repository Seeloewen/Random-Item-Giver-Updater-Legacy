Imports System.ComponentModel.Design
Imports System.IO

Public Class frmDuplicateFinder

    'Variables
    Dim DatapackPath As String = "None"
    Dim PathAmount As String = "None"
    Dim DatapackVersion As String = "None"
    Dim WithDuplicates As String()
    Dim WithDuplicatesArray As String()
    Dim DuplicatesOnly As String()
    Dim DuplicateFinderResult As String
    Dim DuplicateFinderProgress As Double
    Dim BackGroundWorkerProgress As Double

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
            BackColor = Color.FromArgb(50, 50, 50)
            lvDuplicates.BackColor = Color.FromArgb(50, 50, 50)
            lblHeader.ForeColor = Color.White
            lblDescription.ForeColor = Color.White
            tbDatapackPath.BackColor = Color.DimGray
            tbDatapackPath.ForeColor = Color.White
            lvDuplicates.ForeColor = Color.White
            lblChecking.ForeColor = Color.White
            lblDuplicatesAmount.ForeColor = Color.White
        End If
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        'If datapack path isn't empty, begin checking for duplicates. If empty, a warning will be shown.
        If String.IsNullOrEmpty(tbDatapackPath.Text) = False Then
            'Check if entered path is valid, if not, show error.
            If My.Computer.FileSystem.DirectoryExists(tbDatapackPath.Text) Then
                'Check if the datapack is valid
                CheckDatapack()

                'Reset previous progress to 0
                BackGroundWorkerProgress = 0
                DuplicateFinderProgress = 0
                pbProgress.Value = 0

                'Set result to success. If an error occurs during the check process, this will be changed. If not, this value will stay until the end.
                DuplicateFinderResult = "success"

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
                frmMain.WriteToLog("-- Checking for duplicates --", "Info")

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

        'Announce if searching for duplicates completed or failed
        If DuplicateFinderResult = "success" Then
            lblDuplicatesAmount.Text = "Found " + lvDuplicates.Items.Count.ToString + " duplicates In total."
            frmMain.WriteToLog("Checking For duplicates completed. Found " + lvDuplicates.Items.Count.ToString + " duplicates totally.", "Info")
            pbProgress.Value = 100
            MsgBox("Checking For duplicates Is complete." + vbNewLine + "You can see the results In the list behind this message." + vbNewLine + "If the list Is empty then there aren't any duplicates.", MsgBoxStyle.Information, "Duplicate checker")
        Else
            lblDuplicatesAmount.Text = "Searching for duplicates failed."
            frmMain.WriteToLog("Searching for duplicates failed with 1 or more errors.", "Error")
        End If

        'Report progress
        pbProgress.Value = 100

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
            DatapackPath = String.Format("{0}/data/randomitemgiver/loot_tables/", tbDatapackPath.Text)
            Dim Version As String = System.IO.File.ReadAllLines(String.Format("{0}/pack.mcmeta", tbDatapackPath.Text))(2).Replace("    ""pack_format"": ", "").Replace(",", "")

            If Version = "16" OrElse Version = "17" OrElse Version = "18" OrElse Version = "19" OrElse Version = "20" OrElse Version = "21" OrElse Version = "22" OrElse Version = "23" OrElse Version = "24" OrElse Version = "25" OrElse Version = "26" Then
                DatapackVersion = "1.20.2+"
            ElseIf Version = "15" Then
                If File.Exists(tbDatapackPath.Text + "/updater.txt") Then
                    DatapackVersion = "1.20.1"
                Else
                    DatapackVersion = "1.20"
                End If
            ElseIf Version = "14" OrElse Version = "13" Then
                DatapackVersion = "1.20"
            ElseIf Version = "12" OrElse Version = "11" OrElse Version = "10" Then
                DatapackVersion = "1.19"
            ElseIf Version = "9" OrElse Version = "8" Then
                DatapackVersion = "1.18"
            ElseIf Version = "7" Then
                DatapackVersion = "1.17"
            ElseIf Version = "6" Then
                DatapackVersion = "1.16"
            Else
                DatapackVersion = "Null"
            End If

            frmMain.WriteToLog(String.Format("Detected datapack as version {0} In duplicate finder", DatapackVersion), "Info")
        Catch ex As Exception
            MsgBox("Error " + ex.Message + vbNewLine + vbNewLine + "Searching for duplicates may fail since the datapack is invalid.", MsgBoxStyle.Critical, "Error")
            frmMain.WriteToLog("Selected datapack in duplicate finder is invalid.", "Error")
        End Try
    End Sub

    Private Sub InitializeChecking()
        'Decide which loot tables to check depending on the datapack version
        If DatapackVersion = "1.20.2+" Then

            'Set progress step
            DuplicateFinderProgress = 2.5

            Try
                '1 item
                CheckLootTable(1, "normal_items")
                CheckLootTable(1, "other_items")
                CheckLootTable(1, "command_blocks")
                CheckLootTable(1, "spawn_eggs")

                '2 items
                CheckLootTable(2, "normal_items")
                CheckLootTable(2, "other_items")
                CheckLootTable(2, "command_blocks")
                CheckLootTable(2, "spawn_eggs")

                '3 items
                CheckLootTable(3, "normal_items")
                CheckLootTable(3, "other_items")
                CheckLootTable(3, "command_blocks")
                CheckLootTable(3, "spawn_eggs")

                '5 items
                CheckLootTable(5, "normal_items")
                CheckLootTable(5, "other_items")
                CheckLootTable(5, "command_blocks")
                CheckLootTable(5, "spawn_eggs")

                '10 items
                CheckLootTable(10, "normal_items")
                CheckLootTable(10, "other_items")
                CheckLootTable(10, "command_blocks")
                CheckLootTable(10, "spawn_eggs")

                '32 items
                CheckLootTable(32, "normal_items")
                CheckLootTable(32, "other_items")
                CheckLootTable(32, "command_blocks")
                CheckLootTable(32, "spawn_eggs")

                '64 items
                CheckLootTable(64, "normal_items")
                CheckLootTable(64, "other_items")
                CheckLootTable(64, "command_blocks")
                CheckLootTable(64, "spawn_eggs")

                'Random amount of same items
                CheckLootTable(-1, "normal_items")
                CheckLootTable(-1, "other_items")
                CheckLootTable(-1, "command_blocks")
                CheckLootTable(-1, "spawn_eggs")

                'Random amount of different items
                CheckLootTable(-2, "normal_items")
                CheckLootTable(-2, "other_items")
                CheckLootTable(-2, "command_blocks")
                CheckLootTable(-2, "spawn_eggs")

            Catch ex As Exception
                MsgBox(String.Format("Error: {0}", ex.Message), MsgBoxStyle.Critical, "Error")
                DuplicateFinderResult = "failed"
            End Try

        ElseIf DatapackVersion = "1.20.1" OrElse DatapackVersion = "1.20" OrElse DatapackVersion = "1.19" Or DatapackVersion = "1.18" Or DatapackVersion = "1.16" Then
            '1.18 has less loot tables (missing the 'Random Amount Same/Different Item' ones), so the progress should be higher
            If DatapackVersion = "1.18" Then
                DuplicateFinderProgress = 1.78
            Else
                DuplicateFinderProgress = 1.38
            End If

            Try
                '1 item
                CheckLootTable(1, "main")
                CheckLootTable(1, "main_without_creative-only")
                CheckLootTable(1, "special_vvx")
                CheckLootTable(1, "special_vxv")
                CheckLootTable(1, "special_vxx")
                CheckLootTable(1, "special_xvv")
                CheckLootTable(1, "special_xvx")
                CheckLootTable(1, "special_xxv")

                '2 items
                CheckLootTable(2, "main")
                CheckLootTable(2, "main_without_creative-only")
                CheckLootTable(2, "special_vvx")
                CheckLootTable(2, "special_vxv")
                CheckLootTable(2, "special_vxx")
                CheckLootTable(2, "special_xvv")
                CheckLootTable(2, "special_xvx")
                CheckLootTable(2, "special_xxv")

                '3 items
                CheckLootTable(3, "main")
                CheckLootTable(3, "main_without_creative-only")
                CheckLootTable(3, "special_vvx")
                CheckLootTable(3, "special_vxv")
                CheckLootTable(3, "special_vxx")
                CheckLootTable(3, "special_xvv")
                CheckLootTable(3, "special_xvx")
                CheckLootTable(3, "special_xxv")

                '5 items
                CheckLootTable(5, "main")
                CheckLootTable(5, "main_without_creative-only")
                CheckLootTable(5, "special_vvx")
                CheckLootTable(5, "special_vxv")
                CheckLootTable(5, "special_vxx")
                CheckLootTable(5, "special_xvv")
                CheckLootTable(5, "special_xvx")
                CheckLootTable(5, "special_xxv")

                '10 items
                CheckLootTable(10, "main")
                CheckLootTable(10, "main_without_creative-only")
                CheckLootTable(10, "special_vvx")
                CheckLootTable(10, "special_vxv")
                CheckLootTable(10, "special_vxx")
                CheckLootTable(10, "special_xvv")
                CheckLootTable(10, "special_xvx")
                CheckLootTable(10, "special_xxv")

                '32 items
                CheckLootTable(32, "main")
                CheckLootTable(32, "main_without_creative-only")
                CheckLootTable(32, "special_vvx")
                CheckLootTable(32, "special_vxv")
                CheckLootTable(32, "special_vxx")
                CheckLootTable(32, "special_xvv")
                CheckLootTable(32, "special_xvx")
                CheckLootTable(32, "special_xxv")

                '64 items
                CheckLootTable(64, "main")
                CheckLootTable(64, "main_without_creative-only")
                CheckLootTable(64, "special_vvx")
                CheckLootTable(64, "special_vxv")
                CheckLootTable(64, "special_vxx")
                CheckLootTable(64, "special_xvv")
                CheckLootTable(64, "special_xvx")
                CheckLootTable(64, "special_xxv")

                If DatapackVersion = "1.20" OrElse DatapackVersion = "1.19" OrElse DatapackVersion = "1.16" Then
                    'Random amount of same items
                    CheckLootTable(-1, "main")
                    CheckLootTable(-1, "main_without_creative-only")
                    CheckLootTable(-1, "special_vvx")
                    CheckLootTable(-1, "special_vxv")
                    CheckLootTable(-1, "special_vxx")
                    CheckLootTable(-1, "special_xvv")
                    CheckLootTable(-1, "special_xvx")
                    CheckLootTable(-1, "special_xxv")

                    'Random amount of different items
                    CheckLootTable(-2, "main")
                    CheckLootTable(-2, "main_without_creative-only")
                    CheckLootTable(-2, "special_vvx")
                    CheckLootTable(-2, "special_vxv")
                    CheckLootTable(-2, "special_vxx")
                    CheckLootTable(-2, "special_xvv")
                    CheckLootTable(-2, "special_xvx")
                    CheckLootTable(-2, "special_xxv")
                End If

            Catch ex As Exception
                MsgBox(String.Format("Error: {0}", ex.Message), MsgBoxStyle.Critical, "Error")
                DuplicateFinderResult = "failed"
            End Try
        ElseIf DatapackVersion = "1.17" Then
            DuplicateFinderProgress = 12.5
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
                MsgBox(String.Format("Error: {0}", ex.Message), MsgBoxStyle.Critical, "Error")
                DuplicateFinderResult = "failed"
            End Try
        ElseIf DatapackVersion = "Null" Then
            DuplicateFinderResult = "failed"
            MsgBox("The datapack version could not be determined." + vbNewLine + "Cannot search for duplicates.", MsgBoxStyle.Critical, "Error")
        Else
            DuplicateFinderResult = "failed"
            MsgBox("An unknown error occured." + vbNewLine + "Cannot search for duplicates.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub CheckLootTable(itemAmount As Integer, lootTable As String) 'Check a single loot table for duplicates
        'Setup variables depending on the datapack version and Item Amount
        If DatapackVersion = "1.17" Then
            PathAmount = ""
        Else
            If DatapackVersion = "1.20.1" OrElse DatapackVersion = "1.20.2+" Then
                If itemAmount = 1 Then
                    PathAmount = "01item/"
                ElseIf itemAmount = 2 Then
                    PathAmount = "02sameitems/"
                ElseIf itemAmount = 3 Then
                    PathAmount = "03sameitems/"
                ElseIf itemAmount = 5 Then
                    PathAmount = "05sameitems/"
                End If
            Else
                If itemAmount = 1 Then
                    PathAmount = "1item/"
                ElseIf itemAmount = 2 Then
                    PathAmount = "2sameitems/"
                ElseIf itemAmount = 3 Then
                    PathAmount = "3sameitems/"
                ElseIf itemAmount = 5 Then
                    PathAmount = "5sameitems/"
                End If
            End If
            If itemAmount = 10 Then
                PathAmount = "10sameitems/"
            ElseIf itemAmount = 32 Then
                PathAmount = "32sameitems/"
            ElseIf itemAmount = 64 Then
                PathAmount = "64sameitems/"
            ElseIf itemAmount = -1 Then
                PathAmount = "randomamountsameitem/"
            ElseIf itemAmount = -2 Then
                PathAmount = "randomamountdifitems/"
            End If
        End If

        'Load text from file into Array
        WithDuplicates = File.ReadAllLines(DatapackPath + PathAmount + lootTable + ".json")

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
                "minecraft:",
                "{",
                "}",
                ",",
                "]",
                " "
            }

        'Remove unnessecary characters from WithDuplicates
        For x As Integer = 0 To WithDuplicates.Length - 1
            For Each text As String In textToRemove
                WithDuplicates(x) = WithDuplicates(x).Replace(text, "")
            Next
        Next

        'Remove empty lines from WithDuplicates
        Dim WithoutEmptyLines As New List(Of String)
        For Each line As String In WithDuplicates
            If Not line.Trim.Equals(String.Empty) Then
                WithoutEmptyLines.Add(line)
            End If
        Next
        WithDuplicates = WithoutEmptyLines.ToArray

        'Find duplicate lines and put them into a list
        Dim duplicates As List(Of String) =
                   WithDuplicates.GroupBy(Function(n) n) _
                   .Where(Function(g) g.Count() > 1) _
                   .Select(Function(g) g.First) _
                   .ToList()

        'Convert duplicate list to array and load into richtextbox
        DuplicatesOnly = duplicates.ToArray

        'Remove quotationmarks from item names in the duplicates richtextbox
        For x As Integer = 0 To DuplicatesOnly.Length - 1
            DuplicatesOnly(x) = DuplicatesOnly(x).Replace("""", "")
        Next

        'Log duplicates into listview
        Dim numLinesOnlyDups As Integer = DuplicatesOnly.Length
        Dim doLoopNum As Integer
        Dim str(1) As String
        Dim item As ListViewItem

        While doLoopNum < numLinesOnlyDups
            str(0) = DuplicatesOnly(doLoopNum)
            str(1) = PathAmount + lootTable
            item = New ListViewItem(str)
            Invoke(Sub() lvDuplicates.Items.Add(item))
            doLoopNum = doLoopNum + 1
        End While

        'Report aand log that the process has finished
        BackGroundWorkerProgress = BackGroundWorkerProgress + DuplicateFinderProgress
        bgwSearchForDuplicates.ReportProgress(BackGroundWorkerProgress)
        frmMain.WriteToLog(String.Format("Completed checking {0}", lootTable), "Info")
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