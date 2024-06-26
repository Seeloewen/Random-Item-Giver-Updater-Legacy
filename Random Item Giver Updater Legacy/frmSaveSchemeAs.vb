﻿Public Class frmSaveSchemeAs

    Dim samePrefix As Boolean
    Dim customNBT As Boolean
    Dim normalItem As Boolean
    Dim suspiciousStew As Boolean
    Dim enchantedBook As Boolean
    Dim potion As Boolean
    Dim splashPotion As Boolean
    Dim lingeringPotion As Boolean
    Dim tippedArrow As Boolean
    Dim goatHorn As Boolean
    Dim creativeOnly As Boolean
    Dim spawnEgg As Boolean
    Dim commandBlock As Boolean
    Dim otherCreativeOnlyItem As Boolean
    Dim painting As Boolean
    Dim customNBTString As String
    Dim samePrefixString As String

    ' -- Event handlers --

    Private Sub frmSaveSchemeAs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load the design
        LoadDesign()

        'Clear existing text in the scheme name textbox
        tbSaveSchemeAs.Clear()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'Same scheme
        SaveScheme(tbSaveSchemeAs.Text, False)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        'Close window
        Close()
    End Sub

    ' -- Custom methods --

    Private Sub LoadDesign()
        'Load dark mode
        If frmMain.design = "Dark" Then
            lblSaveSchemeAs.ForeColor = Color.White
            tbSaveSchemeAs.ForeColor = Color.White
            tbSaveSchemeAs.BackColor = Color.DimGray
            BackColor = Color.FromArgb(50, 50, 50)
        End If

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
    End Sub

    Public Sub SaveScheme(nameSource As String, overwrite As Boolean)
        'Save currently selected settings into Variables
        spawnEgg = frmMain.rbtnSpawnEgg.Checked
        commandBlock = frmMain.rbtnCommandBlock.Checked
        otherCreativeOnlyItem = frmMain.rbtnOtherItem.Checked
        samePrefix = frmMain.cbSamePrefix.Checked
        customNBT = frmMain.cbCustomNBT.Checked
        normalItem = frmMain.cbNormalItem.Checked
        suspiciousStew = frmMain.cbSuspiciousStew.Checked
        enchantedBook = frmMain.cbEnchantedBook.Checked
        potion = frmMain.cbPotion.Checked
        splashPotion = frmMain.cbSplashPotion.Checked
        lingeringPotion = frmMain.cbLingeringPotion.Checked
        tippedArrow = frmMain.cbTippedArrow.Checked
        goatHorn = frmMain.cbGoatHorn.Checked
        creativeOnly = frmMain.cbCreativeOnly.Checked
        painting = frmMain.cbPainting.Checked

        If String.IsNullOrEmpty(frmMain.tbSamePrefix.Text) Then
            samePrefixString = "minecraft"
        Else
            samePrefixString = frmMain.tbSamePrefix.Text
        End If
        If String.IsNullOrEmpty(frmMain.tbCustomNBT.Text) Then
            customNBTString = "None"
        Else
            customNBTString = frmMain.tbCustomNBT.Text
        End If

        'Saves the scheme. Firstly, it decides it checks if it needs to overwrite an existing scheme or not.
        'Then it checks if the scheme already exists or not. If it exists, it will show a warning, otherwise it will not.
        'It will then create a text file with the name set in NameSource and write the content of the variables to the file.
        'It will also reload the scheme combobox in main window
        'It sill show an error if NameSource is empty or ProfileDirectory doesn't exist.
        If Not overwrite Then
            If Not String.IsNullOrEmpty(nameSource) Then
                If My.Computer.FileSystem.DirectoryExists(frmMain.schemeDirectory) Then
                    If My.Computer.FileSystem.FileExists($"{frmMain.schemeDirectory}{nameSource}.txt") Then
                        Select Case MsgBox("A scheme with this name already exists. Do you want to overwrite it?", vbQuestion + vbYesNo, "Scheme already exists")
                            Case Windows.Forms.DialogResult.Yes
                                My.Computer.FileSystem.WriteAllText($"{frmMain.schemeDirectory}{nameSource}.txt", samePrefix.ToString + vbNewLine + samePrefixString + vbNewLine + customNBT.ToString + vbNewLine + customNBTString + vbNewLine + normalItem.ToString + vbNewLine + suspiciousStew.ToString + vbNewLine + enchantedBook.ToString + vbNewLine + potion.ToString + vbNewLine + splashPotion.ToString + vbNewLine + lingeringPotion.ToString + vbNewLine + tippedArrow.ToString + vbNewLine + goatHorn.ToString + vbNewLine + creativeOnly.ToString + vbNewLine + spawnEgg.ToString + vbNewLine + commandBlock.ToString + vbNewLine + otherCreativeOnlyItem.ToString + vbNewLine + painting.ToString + vbNewLine, False)
                                frmMain.cbxScheme.Items.Clear()
                                frmMain.GetSchemeFiles(frmMain.schemeDirectory)
                                MsgBox("Scheme was overwritten and saved.", MsgBoxStyle.Information, "Overwritten and saved")
                                frmMain.WriteToLog($"Saved and overwrote scheme {nameSource}", "Info")
                                Close()
                            Case Windows.Forms.DialogResult.No
                                MsgBox("Scheme was not overwritten. Please select a different scheme name.", MsgBoxStyle.Exclamation, "Profile not overwritten.")
                        End Select
                    Else
                        My.Computer.FileSystem.WriteAllText($"{frmMain.schemeDirectory}{nameSource}.txt", samePrefix.ToString + vbNewLine + frmMain.tbSamePrefix.Text + vbNewLine + customNBT.ToString + vbNewLine + frmMain.tbCustomNBT.Text + vbNewLine + normalItem.ToString + vbNewLine + suspiciousStew.ToString + vbNewLine + enchantedBook.ToString + vbNewLine + potion.ToString + vbNewLine + splashPotion.ToString + vbNewLine + lingeringPotion.ToString + vbNewLine + tippedArrow.ToString + vbNewLine + goatHorn.ToString + vbNewLine + creativeOnly.ToString + vbNewLine + spawnEgg.ToString + vbNewLine + commandBlock.ToString + vbNewLine + otherCreativeOnlyItem.ToString + vbNewLine + painting.ToString + vbNewLine, False)
                        frmMain.cbxScheme.Items.Clear()
                        frmMain.GetSchemeFiles(frmMain.schemeDirectory)
                        MsgBox("Scheme was saved.", MsgBoxStyle.Information, "Saved")
                        frmMain.WriteToLog($"Saved scheme {nameSource}", "Info")
                        Close()
                    End If
                Else
                    MsgBox("Error: Scheme directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
                End If
            Else
                MsgBox("Error: Scheme name is empty. Please enter a scheme name.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            If Not String.IsNullOrEmpty(nameSource) Then
                If My.Computer.FileSystem.DirectoryExists(frmMain.schemeDirectory) Then
                    My.Computer.FileSystem.WriteAllText($"{frmMain.schemeDirectory}{nameSource}.txt", samePrefix.ToString + vbNewLine + frmMain.tbSamePrefix.Text + vbNewLine + customNBT.ToString + vbNewLine + frmMain.tbCustomNBT.Text + vbNewLine + normalItem.ToString + vbNewLine + suspiciousStew.ToString + vbNewLine + enchantedBook.ToString + vbNewLine + potion.ToString + vbNewLine + splashPotion.ToString + vbNewLine + lingeringPotion.ToString + vbNewLine + tippedArrow.ToString + vbNewLine + goatHorn.ToString + vbNewLine + creativeOnly.ToString + vbNewLine + spawnEgg.ToString + vbNewLine + commandBlock.ToString + vbNewLine + otherCreativeOnlyItem.ToString + vbNewLine + painting.ToString + vbNewLine, False)
                    frmMain.cbxScheme.Items.Clear()
                    frmMain.GetSchemeFiles(frmMain.schemeDirectory)
                    MsgBox("Scheme was overwritten and saved.", MsgBoxStyle.Information, "Saved")
                    frmMain.WriteToLog($"Saved and overwrote scheme {nameSource}", "Info")
                    Close()
                Else
                    MsgBox("Error: Scheme directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
                End If
            Else
                MsgBox("Error: Scheme name is empty. Please enter a scheme name.", MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Public Sub UpdateScheme(schemeName)
        'Save currently selected settings into Variables
        spawnEgg = frmMain.rbtnSpawnEgg.Checked
        commandBlock = frmMain.rbtnCommandBlock.Checked
        otherCreativeOnlyItem = frmMain.rbtnOtherItem.Checked
        samePrefix = frmMain.cbSamePrefix.Checked
        customNBT = frmMain.cbCustomNBT.Checked
        normalItem = frmMain.cbNormalItem.Checked
        suspiciousStew = frmMain.cbSuspiciousStew.Checked
        enchantedBook = frmMain.cbEnchantedBook.Checked
        potion = frmMain.cbPotion.Checked
        splashPotion = frmMain.cbSplashPotion.Checked
        lingeringPotion = frmMain.cbLingeringPotion.Checked
        tippedArrow = frmMain.cbTippedArrow.Checked
        goatHorn = frmMain.cbGoatHorn.Checked
        creativeOnly = frmMain.cbCreativeOnly.Checked
        painting = frmMain.cbPainting.Checked

        If String.IsNullOrEmpty(frmMain.tbSamePrefix.Text) Then
            samePrefixString = "minecraft"
        Else
            samePrefixString = frmMain.tbSamePrefix.Text
        End If
        If String.IsNullOrEmpty(frmMain.tbCustomNBT.Text) Then
            customNBTString = "None"
        Else
            customNBTString = frmMain.tbCustomNBT.Text
        End If

        'Update the selected scheme. This will save and overwrite the selected scheme without showing any warning or message. Used if a scheme is old or corrupted.
        If Not String.IsNullOrEmpty(schemeName) Then
            If My.Computer.FileSystem.DirectoryExists(frmMain.schemeDirectory) Then
                My.Computer.FileSystem.WriteAllText($"{frmMain.schemeDirectory}{schemeName}.txt", samePrefix.ToString + vbNewLine + samePrefixString + vbNewLine + customNBT.ToString + vbNewLine + customNBTString + vbNewLine + normalItem.ToString + vbNewLine + suspiciousStew.ToString + vbNewLine + enchantedBook.ToString + vbNewLine + potion.ToString + vbNewLine + splashPotion.ToString + vbNewLine + lingeringPotion.ToString + vbNewLine + tippedArrow.ToString + vbNewLine + goatHorn.ToString + vbNewLine + creativeOnly.ToString + vbNewLine + spawnEgg.ToString + vbNewLine + commandBlock.ToString + vbNewLine + otherCreativeOnlyItem.ToString + vbNewLine, False)
            Else
                MsgBox("Error: Couldn't update scheme. Scheme directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Error: Couldn't update scheme as the name is empty.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    '-- Button animations --

    Private Sub btnSave_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSave.MouseDown
        If frmMain.design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnSave_MouseEnter(sender As Object, e As EventArgs) Handles btnSave.MouseEnter
        If frmMain.design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnSave_MouseLeave(sender As Object, e As EventArgs) Handles btnSave.MouseLeave
        If frmMain.design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnSave_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSave.MouseUp
        If frmMain.design = "Dark" Then
            btnSave.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnSave.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnCancel_MouseDown(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseDown
        If frmMain.design = "Dark" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonClick
        ElseIf frmMain.design = "Light" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnCancel_MouseEnter(sender As Object, e As EventArgs) Handles btnCancel.MouseEnter
        If frmMain.design = "Dark" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonHover
        ElseIf frmMain.design = "Light" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnCancel_MouseLeave(sender As Object, e As EventArgs) Handles btnCancel.MouseLeave
        If frmMain.design = "Dark" Then
            btnCancel.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnCancel_MouseUp(sender As Object, e As MouseEventArgs) Handles btnCancel.MouseUp
        If frmMain.design = "Dark" Then
            btnCancel.BackgroundImage = My.Resources.imgButton
        ElseIf frmMain.design = "Light" Then
            btnCancel.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub
End Class