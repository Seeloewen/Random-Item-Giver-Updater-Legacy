Public Class frmDuplicateFinder

    Dim DatapackPath As String
    Dim PathAmount As String
    Dim DatapackVersion As String

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        If String.IsNullOrEmpty(tbDatapackPath.Text) = False Then
            If My.Computer.FileSystem.DirectoryExists(tbDatapackPath.Text) Then
                btnCheck.Enabled = False
                lblChecking.Show()
                btnCheck.Text = "Checking..."
                MsgBox("Duplicate finder will now search for duplicates in the selected datapack. This may take a while." + vbNewLine + "The software might show the state " + frmMain.qm + "Not responding" + frmMain.qm + ", this is intended.", MsgBoxStyle.Information, "Duplicate checker")
                lvDuplicates.Clear()
                lvDuplicates.Columns.Add("Item")
                lvDuplicates.Columns(0).Width = 256
                lvDuplicates.Columns.Add("Loot Table")
                lvDuplicates.Columns(1).Width = 266
                CallChecker()
                MsgBox("Checking for duplicates is complete." + vbNewLine + "You can see the results in the list behind this message." + vbNewLine + "If the list is empty then there aren't any duplicates.", MsgBoxStyle.Information, "Duplicate checker")
                btnCheck.Enabled = True
                btnCheck.Text = "Check"
                lblChecking.Hide()
            Else
                MsgBox("The datapack path you have entered is not valid.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Please enter a datapack path!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub CallChecker()

        If DatapackVersion = "1.19" Or DatapackVersion = "1.18" Or DatapackVersion = "1.16" Then
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
            Catch ex As Exception
                MsgBox("Error: " + ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        ElseIf DatapackVersion = "1.17" Then
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
                MsgBox("Error: " + ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        ElseIf DatapackVersion = "None" Then
        Else
            MsgBox("An unknown error occured." + vbNewLine + "Cannot search for duplicates.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub CheckLootTable(ItemAmount As Integer, LootTable As String)

        'Setup variables
        If DatapackVersion = "1.17" Then
            PathAmount = ""
        Else
            If ItemAmount = 1 Then
                PathAmount = "1item/"
            ElseIf ItemAmount = 2 Then
                PathAmount = "2sameitems/"
            ElseIf ItemAmount = 3 Then
                PathAmount = "3sameitems/"
            ElseIf ItemAmount = 5 Then
                PathAmount = "5sameitems/"
            ElseIf ItemAmount = 10 Then
                PathAmount = "10sameitems/"
            ElseIf ItemAmount = 32 Then
                PathAmount = "32sameitems/"
            ElseIf ItemAmount = 64 Then
                PathAmount = "64sameitems/"
            End If
        End If

        'Load text into richtextbox
        rtbWithDuplicates.Text = My.Computer.FileSystem.ReadAllText(DatapackPath + PathAmount + LootTable + ".json")

        'Remove unnessecary characters from rtbWithDuplicates
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "type" + frmMain.qm + ": " + frmMain.qm + "minecraft:item" + frmMain.qm + ",") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "type" + frmMain.qm + ": " + frmMain.qm + "minecraft:item" + frmMain.qm + ",", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "entries" + frmMain.qm + ": [") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "entries" + frmMain.qm + ": [", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "rolls" + frmMain.qm + ": 1,") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "rolls" + frmMain.qm + ": 1,", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "pools" + frmMain.qm + ": [") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "pools" + frmMain.qm + ": [", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "name" + frmMain.qm + ": ") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "name" + frmMain.qm + ": ", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "functions" + frmMain.qm + ": [") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "functions" + frmMain.qm + ": [", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "function" + frmMain.qm + ": " + frmMain.qm + "minecraft:set_count" + frmMain.qm + ",") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "function" + frmMain.qm + ": " + frmMain.qm + "minecraft:set_count" + frmMain.qm + ",", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "count" + frmMain.qm + ": 10") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "count" + frmMain.qm + ": 10", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "count" + frmMain.qm + ": 32") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "count" + frmMain.qm + ": 32", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "count" + frmMain.qm + ": 64") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "count" + frmMain.qm + ": 64", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "count" + frmMain.qm + ": 2") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "count" + frmMain.qm + ": 2", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "count" + frmMain.qm + ": 3") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "count" + frmMain.qm + ": 3", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "count" + frmMain.qm + ": 5") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "count" + frmMain.qm + ": 5", "")
        End If
        If rtbWithDuplicates.Text.Contains("minecraft:") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("minecraft:", "")
        End If
        If rtbWithDuplicates.Text.Contains(" ") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace(" ", "")
        End If
        If rtbWithDuplicates.Text.Contains("{") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("{", "")
        End If
        If rtbWithDuplicates.Text.Contains("}") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("}", "")
        End If
        If rtbWithDuplicates.Text.Contains(",") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace(",", "")
        End If
        If rtbWithDuplicates.Text.Contains("]") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("]", "")
        End If

        'Remove empty lines from rtbWithDuplicates
        Dim WithoutEmptyLines As New List(Of String)
        For Each s As String In rtbWithDuplicates.Lines
            If Not s.Trim.Equals(String.Empty) Then
                WithoutEmptyLines.Add(s)
            End If
        Next
        rtbWithDuplicates.Lines = WithoutEmptyLines.ToArray

        'Find duplicate lines and put them into a list
        Dim duplicates As List(Of String) =
  rtbWithDuplicates.Lines.GroupBy(Function(n) n) _
  .Where(Function(g) g.Count() > 1) _
  .Select(Function(g) g.First) _
  .ToList()

        'Convert duplicate list to array and load into richtextbox
        Dim ArrayResult As String() = duplicates.ToArray
        rtbDuplicates.Lines = ArrayResult

        'Remove quotationmarks from item names in the duplicates richtextbox
        If rtbDuplicates.Text.Contains(frmMain.qm) Then
            rtbDuplicates.Text = rtbDuplicates.Text.Replace(frmMain.qm, "")
        End If

        'Log duplicates into listview
        Dim NumLinesOnlyDups As Integer = rtbDuplicates.Lines.Length
        Dim DoLoopNum As Integer
        Dim str(1) As String
        Dim itm As ListViewItem

        While DoLoopNum < NumLinesOnlyDups
            str(0) = rtbDuplicates.Lines(DoLoopNum)
            str(1) = PathAmount + LootTable
            itm = New ListViewItem(str)
            lvDuplicates.Items.Add(itm)
            DoLoopNum = DoLoopNum + 1
        End While
    End Sub

    Private Sub ChangeLineInrtbWithDuplicates(Num As Integer)
        Dim lines() As String = rtbWithDuplicates.Lines
        lines(Num) = ""
        rtbWithDuplicates.Lines = lines
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        fbdMainFolderPath.ShowDialog()
        tbDatapackPath.Text = fbdMainFolderPath.SelectedPath
    End Sub

    Private Sub tbDatapackPath_TextChanged(sender As Object, e As EventArgs) Handles tbDatapackPath.TextChanged
        Try
            DatapackPath = tbDatapackPath.Text + "/data/randomitemgiver/loot_tables/"

            Dim VersionString As String = System.IO.File.ReadAllLines(tbDatapackPath.Text + "/pack.mcmeta")(2)
            Dim ParseVersion As String = Replace(VersionString, "    " + frmMain.qm + "pack_format" + frmMain.qm + ": ", "")
            Dim Version As String = Replace(ParseVersion, ",", "")

            If Version = "10" Then
                DatapackVersion = "1.19"
            ElseIf Version = "9" Then
                DatapackVersion = "1.18"
            ElseIf Version = "8" Then
                DatapackVersion = "1.18"
            ElseIf Version = "7" Then
                DatapackVersion = "1.17"
            ElseIf Version = "6" Then
                DatapackVersion = "1.16"
            Else
                DatapackVersion = "Null"
            End If
        Catch ex As Exception
            MsgBox("Error: " + ex.Message + vbNewLine + vbNewLine + "The datapack path is not detected as valid and therefor the duplicate finder might fail.", MsgBoxStyle.Critical, "Error")
        End Try

    End Sub
End Class