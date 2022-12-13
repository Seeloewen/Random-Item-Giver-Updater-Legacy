Public Class frmSaveSchemeAs

    Dim SamePrefix As Boolean
    Dim CustomNBT As Boolean
    Dim NormalItem As Boolean
    Dim SuspiciousStew As Boolean
    Dim EnchantedBook As Boolean
    Dim Potion As Boolean
    Dim SplashPotion As Boolean
    Dim LingeringPotion As Boolean
    Dim TippedArrow As Boolean
    Dim GoatHorn As Boolean
    Dim CreativeOnly As Boolean
    Dim SpawnEgg As Boolean
    Dim CommandBlock As Boolean
    Dim OtherCreativeOnlyItem As Boolean
    Dim CustomNBTString As String
    Dim SamePrefixString As String

    ' -- Event handlers --

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Same scheme
        SaveScheme(tbSaveSchemeAs.Text, False)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Close window
        Close()
    End Sub

    Private Sub frmSaveSchemeAs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Clear existing text in the scheme name textbox
        tbSaveSchemeAs.Clear()
    End Sub

    ' -- Custom methods --

    Public Sub SaveScheme(NameSource As String, Overwrite As Boolean)
        'Save currently selected settings into Variables
        If frmMain.rbtnSpawnEgg.Checked = True Then
            SpawnEgg = True
        Else
            SpawnEgg = False
        End If
        If frmMain.rbtnCommandBlock.Checked = True Then
            CommandBlock = True
        Else
            SpawnEgg = False
        End If
        If frmMain.rbtnOtherItem.Checked = True Then
            OtherCreativeOnlyItem = True
        Else
            OtherCreativeOnlyItem = False
        End If
        If frmMain.cbSamePrefix.Checked Then
            SamePrefix = True
        Else
            SamePrefix = False
        End If
        If frmMain.cbCustomNBT.Checked = True Then
            CustomNBT = True
        Else
            CustomNBT = False
        End If
        If frmMain.cbNormalItem.Checked = True Then
            NormalItem = True
        Else
            NormalItem = False
        End If
        If frmMain.cbSuspiciousStew.Checked = True Then
            SuspiciousStew = True
        Else
            SuspiciousStew = False
        End If
        If frmMain.cbEnchantedBook.Checked = True Then
            EnchantedBook = True
        Else
            EnchantedBook = False
        End If
        If frmMain.cbPotion.Checked = True Then
            Potion = True
        Else
            Potion = False
        End If
        If frmMain.cbSplashPotion.Checked = True Then
            SplashPotion = True
        Else
            SplashPotion = False
        End If
        If frmMain.cbLingeringPotion.Checked = True Then
            LingeringPotion = True
        Else
            LingeringPotion = False
        End If
        If frmMain.cbTippedArrow.Checked = True Then
            TippedArrow = True
        Else
            TippedArrow = False
        End If
        If frmMain.cbGoatHorn.Checked = True Then
            GoatHorn = True
        Else
            GoatHorn = False
        End If
        If frmMain.cbCreativeOnly.Checked = True Then
            CreativeOnly = True
        Else
            CreativeOnly = False
        End If
        If String.IsNullOrEmpty(frmMain.tbSamePrefix.Text) Then
            SamePrefixString = "minecraft"
        Else
            SamePrefixString = frmMain.tbSamePrefix.Text
        End If
        If String.IsNullOrEmpty(frmMain.tbCustomNBT.Text) Then
            CustomNBTString = "None"
        Else
            CustomNBTString = frmMain.tbCustomNBT.Text
        End If

        'Saves the scheme. Firstly, it decides it checks if it needs to overwrite an existing scheme or not.
        'Then it checks if the scheme already exists or not. If it exists, it will show a warning, otherwise it will not.
        'It will then create a text file with the name set in NameSource and write the content of the variables to the file.
        'It will also reload the scheme combobox in main window
        'It sill show an error if NameSource is empty or ProfileDirectory doesn't exist.
        If Overwrite = False Then
            If String.IsNullOrEmpty(NameSource) = False Then
                If My.Computer.FileSystem.DirectoryExists(frmMain.SchemeDirectory) Then
                    If My.Computer.FileSystem.FileExists(frmMain.SchemeDirectory + NameSource + ".txt") Then
                        Select Case MsgBox("A scheme with this name already exists. Do you want to overwrite it?", vbQuestion + vbYesNo, "Scheme already exists")
                            Case Windows.Forms.DialogResult.Yes
                                My.Computer.FileSystem.WriteAllText(frmMain.SchemeDirectory + NameSource + ".txt", SamePrefix.ToString + vbNewLine + SamePrefixString + vbNewLine + CustomNBT.ToString + vbNewLine + CustomNBTString + vbNewLine + NormalItem.ToString + vbNewLine + SuspiciousStew.ToString + vbNewLine + EnchantedBook.ToString + vbNewLine + Potion.ToString + vbNewLine + SplashPotion.ToString + vbNewLine + LingeringPotion.ToString + vbNewLine + TippedArrow.ToString + vbNewLine + GoatHorn.ToString + vbNewLine + CreativeOnly.ToString + vbNewLine + SpawnEgg.ToString + vbNewLine + CommandBlock.ToString + vbNewLine + OtherCreativeOnlyItem.ToString + vbNewLine, False)
                                frmMain.cbxScheme.Items.Clear()
                                frmMain.GetSchemeFiles(frmMain.SchemeDirectory)
                                MsgBox("Scheme was overwritten and saved.", MsgBoxStyle.Information, "Overwritten and saved")
                                frmMain.WriteToLog("Saved and overwrote scheme " + NameSource, "Info")
                                Close()
                            Case Windows.Forms.DialogResult.No
                                MsgBox("Scheme was not overwritten. Please select a different scheme name.", MsgBoxStyle.Exclamation, "Profile not overwritten.")
                        End Select
                    Else
                        My.Computer.FileSystem.WriteAllText(frmMain.SchemeDirectory + NameSource + ".txt", SamePrefix.ToString + vbNewLine + frmMain.tbSamePrefix.Text + vbNewLine + CustomNBT.ToString + vbNewLine + frmMain.tbCustomNBT.Text + vbNewLine + NormalItem.ToString + vbNewLine + SuspiciousStew.ToString + vbNewLine + EnchantedBook.ToString + vbNewLine + Potion.ToString + vbNewLine + SplashPotion.ToString + vbNewLine + LingeringPotion.ToString + vbNewLine + TippedArrow.ToString + vbNewLine + GoatHorn.ToString + vbNewLine + CreativeOnly.ToString + vbNewLine + SpawnEgg.ToString + vbNewLine + CommandBlock.ToString + vbNewLine + OtherCreativeOnlyItem.ToString + vbNewLine, False)
                        frmMain.cbxScheme.Items.Clear()
                        frmMain.GetSchemeFiles(frmMain.SchemeDirectory)
                        MsgBox("Scheme was saved.", MsgBoxStyle.Information, "Saved")
                        frmMain.WriteToLog("Saved scheme " + NameSource, "Info")
                        Close()
                    End If
                Else
                    MsgBox("Error: Scheme directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
                End If
            Else
                MsgBox("Error: Scheme name is empty. Please enter a scheme name.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            If String.IsNullOrEmpty(NameSource) = False Then
                If My.Computer.FileSystem.DirectoryExists(frmMain.SchemeDirectory) Then
                    My.Computer.FileSystem.WriteAllText(frmMain.SchemeDirectory + NameSource + ".txt", SamePrefix.ToString + vbNewLine + frmMain.tbSamePrefix.Text + vbNewLine + CustomNBT.ToString + vbNewLine + frmMain.tbCustomNBT.Text + vbNewLine + NormalItem.ToString + vbNewLine + SuspiciousStew.ToString + vbNewLine + EnchantedBook.ToString + vbNewLine + Potion.ToString + vbNewLine + SplashPotion.ToString + vbNewLine + LingeringPotion.ToString + vbNewLine + TippedArrow.ToString + vbNewLine + GoatHorn.ToString + vbNewLine + CreativeOnly.ToString + vbNewLine + SpawnEgg.ToString + vbNewLine + CommandBlock.ToString + vbNewLine + OtherCreativeOnlyItem.ToString + vbNewLine, False)
                    frmMain.cbxScheme.Items.Clear()
                    frmMain.GetSchemeFiles(frmMain.SchemeDirectory)
                    MsgBox("Scheme was overwritten and saved.", MsgBoxStyle.Information, "Saved")
                    frmMain.WriteToLog("Saved and overwrote scheme " + NameSource, "Info")
                    Close()
                Else
                    MsgBox("Error: Scheme directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
                End If
            Else
                MsgBox("Error: Scheme name is empty. Please enter a scheme name.", MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Public Sub UpdateScheme(SchemeName)
        'Save currently selected settings into Variables
        If frmMain.rbtnSpawnEgg.Checked = True Then
            SpawnEgg = True
        Else
            SpawnEgg = False
        End If
        If frmMain.rbtnCommandBlock.Checked = True Then
            CommandBlock = True
        Else
            SpawnEgg = False
        End If
        If frmMain.rbtnOtherItem.Checked = True Then
            OtherCreativeOnlyItem = True
        Else
            OtherCreativeOnlyItem = False
        End If
        If frmMain.cbSamePrefix.Checked Then
            SamePrefix = True
        Else
            SamePrefix = False
        End If
        If frmMain.cbCustomNBT.Checked = True Then
            CustomNBT = True
        Else
            CustomNBT = False
        End If
        If frmMain.cbNormalItem.Checked = True Then
            NormalItem = True
        Else
            NormalItem = False
        End If
        If frmMain.cbSuspiciousStew.Checked = True Then
            SuspiciousStew = True
        Else
            SuspiciousStew = False
        End If
        If frmMain.cbEnchantedBook.Checked = True Then
            EnchantedBook = True
        Else
            EnchantedBook = False
        End If
        If frmMain.cbPotion.Checked = True Then
            Potion = True
        Else
            Potion = False
        End If
        If frmMain.cbSplashPotion.Checked = True Then
            SplashPotion = True
        Else
            SplashPotion = False
        End If
        If frmMain.cbLingeringPotion.Checked = True Then
            LingeringPotion = True
        Else
            LingeringPotion = False
        End If
        If frmMain.cbTippedArrow.Checked = True Then
            TippedArrow = True
        Else
            TippedArrow = False
        End If
        If frmMain.cbGoatHorn.Checked = True Then
            GoatHorn = True
        Else
            GoatHorn = False
        End If
        If frmMain.cbCreativeOnly.Checked = True Then
            CreativeOnly = True
        Else
            CreativeOnly = False
        End If
        If String.IsNullOrEmpty(frmMain.tbSamePrefix.Text) Then
            SamePrefixString = "minecraft"
        Else
            SamePrefixString = frmMain.tbSamePrefix.Text
        End If
        If String.IsNullOrEmpty(frmMain.tbCustomNBT.Text) Then
            CustomNBTString = "None"
        Else
            CustomNBTString = frmMain.tbCustomNBT.Text
        End If

        'Update the selected scheme. This will save and overwrite the selected scheme without showing any warning or message. Used if a scheme is old or corrupted.
        If String.IsNullOrEmpty(SchemeName) = False Then
            If My.Computer.FileSystem.DirectoryExists(frmMain.SchemeDirectory) Then
                My.Computer.FileSystem.WriteAllText(frmMain.SchemeDirectory + SchemeName + ".txt", SamePrefix.ToString + vbNewLine + SamePrefixString + vbNewLine + CustomNBT.ToString + vbNewLine + CustomNBTString + vbNewLine + NormalItem.ToString + vbNewLine + SuspiciousStew.ToString + vbNewLine + EnchantedBook.ToString + vbNewLine + Potion.ToString + vbNewLine + SplashPotion.ToString + vbNewLine + LingeringPotion.ToString + vbNewLine + TippedArrow.ToString + vbNewLine + GoatHorn.ToString + vbNewLine + CreativeOnly.ToString + vbNewLine + SpawnEgg.ToString + vbNewLine + CommandBlock.ToString + vbNewLine + OtherCreativeOnlyItem.ToString + vbNewLine, False)
            Else
                MsgBox("Error: Couldn't update scheme. Scheme directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Error: Couldn't update scheme as the name is empty.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub
End Class