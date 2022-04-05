Public Class frmDuplicateFinder

    Dim DatapackPath As String
    Dim PathAmount As String

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        If String.IsNullOrEmpty(tbDatapackPath.Text) = False Then
            If My.Computer.FileSystem.DirectoryExists(tbDatapackPath.Text) Then
                btnCheck.Enabled = False
                btnCheck.Text = "Checking..."
                MsgBox("Duplicate finder will now search for duplicates in the selected datapack. This may take a while.", MsgBoxStyle.Information, "Duplicate checker")
                lvDuplicates.Clear()
                lvDuplicates.Columns.Add("Item")
                lvDuplicates.Columns(0).Width = 256
                lvDuplicates.Columns.Add("Loot Table")
                lvDuplicates.Columns(1).Width = 266
                CallChecker()
                MsgBox("Checking for duplicates is complete." + vbNewLine + "You can see the results in the list down below.", MsgBoxStyle.Information, "Duplicate checker")
                btnCheck.Enabled = True
                btnCheck.Text = "Check"
            Else
                MsgBox("The datapack path you have entered is not valid.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Please enter a datapack path!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub CallChecker()
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
    End Sub

    Private Sub CheckLootTable(ItemAmount As Integer, LootTable As String)

        'Setup variables
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
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "count" + frmMain.qm + ": 2") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "count" + frmMain.qm + ": 2", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "count" + frmMain.qm + ": 3") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "count" + frmMain.qm + ": 3", "")
        End If
        If rtbWithDuplicates.Text.Contains("" + frmMain.qm + "count" + frmMain.qm + ": 5") Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace("" + frmMain.qm + "count" + frmMain.qm + ": 5", "")
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

        rtbWithoutDuplicates.Text = rtbWithDuplicates.Text

        'Remove empty lines from rtbWithDuplicates
        Dim WithoutEmptyLines As New List(Of String)
        For Each s As String In rtbWithDuplicates.Lines
            If Not s.Trim.Equals(String.Empty) Then
                WithoutEmptyLines.Add(s)
            End If
        Next
        rtbWithDuplicates.Lines = WithoutEmptyLines.ToArray

        'Remove empty lines from rtbWithoutDuplicates
        Dim WithoutEmptyLines2 As New List(Of String)
        For Each s As String In rtbWithoutDuplicates.Lines
            If Not s.Trim.Equals(String.Empty) Then
                WithoutEmptyLines2.Add(s)
            End If
        Next
        rtbWithoutDuplicates.Lines = WithoutEmptyLines2.ToArray

        'Remove duplicates from rtbWithoutDuplicates
        Dim WithoutDuplicates As New List(Of String)(rtbWithoutDuplicates.Lines)
        For i As Integer = WithoutDuplicates.Count - 1 To 1 Step -1
            If WithoutDuplicates(i) = WithoutDuplicates(i - 1) Then
                WithoutDuplicates.RemoveAt(i)
            End If
        Next
        rtbWithoutDuplicates.Lines = WithoutDuplicates.ToArray

        'Compare lines from rtbWithDuplicates to rtbWithoutDuplicates
        Dim LinesWith As String() = rtbWithDuplicates.Lines
        Dim LinesWithout As String() = rtbWithoutDuplicates.Lines
        Dim CheckLine As Integer = 0
        Dim CheckLineWith As Integer = 0
        Dim CheckLineWithout As Integer = 0
        Dim DoLoop As Boolean = True
        Dim NumLinesWith As Integer = rtbWithDuplicates.Lines.Length
        Dim TempItem As String

        While DoLoop = True
            If CheckLineWith = NumLinesWith Then
                DoLoop = False
            Else
                TempItem = LinesWith(CheckLineWith)
                LinesWith(CheckLineWith).Replace(LinesWith(CheckLineWith), "")
                If LinesWith.Contains(TempItem) Then
                    rtbDuplicates.AppendText(TempItem + vbNewLine)
                End If
                CheckLineWith = CheckLineWith + 1
                rtbreplace.Lines = LinesWith
                rtbreplace.Text.Replace(TempItem, "")
                LinesWith = rtbreplace.Lines
            End If
        End While

        rtbWithDuplicates.Lines = LinesWith

        'Remove quotationmarks from item names
        If rtbWithDuplicates.Text.Contains(frmMain.qm) Then
            rtbWithDuplicates.Text = rtbWithDuplicates.Text.Replace(frmMain.qm, "")
        End If

        'Remove empty lines from rtbWithDuplicates
        Dim WithoutEmptyLines3 As New List(Of String)
        For Each s As String In rtbWithDuplicates.Lines
            If Not s.Trim.Equals(String.Empty) Then
                WithoutEmptyLines3.Add(s)
            End If
        Next
        rtbWithDuplicates.Lines = WithoutEmptyLines3.ToArray

        'Remove duplicates from rtbWithoutDuplicates
        Dim WithoutDuplicates2 As New List(Of String)(rtbWithDuplicates.Lines)
        For i As Integer = WithoutDuplicates2.Count - 1 To 1 Step -1
            If WithoutDuplicates2(i) = WithoutDuplicates2(i - 1) Then
                WithoutDuplicates2.RemoveAt(i)
            End If
        Next
        rtbWithDuplicates.Lines = WithoutDuplicates2.ToArray

        'Remove Non-Duplicates
        Dim NumLinesOnlyDups As Integer = rtbWithDuplicates.Lines.Length
        Dim DoLoopNum As Integer
        Dim str(1) As String
        Dim itm As ListViewItem


        While DoLoopNum < NumLinesOnlyDups
            str(0) = rtbWithDuplicates.Lines(DoLoopNum)
            str(1) = PathAmount + LootTable
            itm = New ListViewItem(str)
            lvDuplicates.Items.Add(itm)
            DoLoopNum = DoLoopNum + 1
        End While
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        fbdMainFolderPath.ShowDialog()
        tbDatapackPath.Text = fbdMainFolderPath.SelectedPath
    End Sub

    Private Sub tbDatapackPath_TextChanged(sender As Object, e As EventArgs) Handles tbDatapackPath.TextChanged
        DatapackPath = tbDatapackPath.Text + "/data/randomitemgiver/loot_tables/"
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        MsgBox("Please note that loot tables for potions, enchanted books, lingering arrows and suspicious stews are not supported yet as well as datapacks for version 1.17." + vbNewLine + vbNewLine + "Support for these will be added in a future version.", MsgBoxStyle.Exclamation, "Warning")
    End Sub

    Private Sub frmDuplicateFinder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class