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

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveScheme(tbSaveSchemeAs.Text, False)
    End Sub

    Public Sub SaveScheme(NameSource As String, Overwrite As Boolean)
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

        If Overwrite = False Then
            If String.IsNullOrEmpty(NameSource) = False Then
                If My.Computer.FileSystem.DirectoryExists(frmMain.SchemeDirectory) Then
                    If My.Computer.FileSystem.FileExists(frmMain.SchemeDirectory + NameSource + ".txt") Then
                        Select Case MessageBox.Show("A scheme with this name already exists. Do you want to overwrite it?", "Scheme already exists", MessageBoxButtons.YesNo)
                            Case Windows.Forms.DialogResult.Yes
                                My.Computer.FileSystem.WriteAllText(frmMain.SchemeDirectory + NameSource + ".txt", SamePrefix.ToString + vbNewLine + frmMain.tbSamePrefix.Text + vbNewLine + CustomNBT.ToString + vbNewLine + frmMain.tbCustomNBT.Text + vbNewLine + NormalItem.ToString + vbNewLine + SuspiciousStew.ToString + vbNewLine + EnchantedBook.ToString + vbNewLine + Potion.ToString + vbNewLine + SplashPotion.ToString + vbNewLine + LingeringPotion.ToString + vbNewLine + TippedArrow.ToString + vbNewLine + GoatHorn.ToString + vbNewLine + CreativeOnly.ToString + vbNewLine + SpawnEgg.ToString + vbNewLine + CommandBlock.ToString + vbNewLine + OtherCreativeOnlyItem.ToString + vbNewLine, False)
                                frmMain.cbxScheme.Items.Clear()
                                frmMain.GetSchemeFiles(frmMain.SchemeDirectory)
                                MsgBox("Scheme was overwritten and saved.", MsgBoxStyle.Information, "Overwritten and saved")
                                Close()
                            Case Windows.Forms.DialogResult.No
                                MsgBox("Scheme was not overwritten. Please select a different scheme name.", MsgBoxStyle.Exclamation, "Profile not overwritten.")
                        End Select
                    Else
                        My.Computer.FileSystem.WriteAllText(frmMain.SchemeDirectory + NameSource + ".txt", SamePrefix.ToString + vbNewLine + frmMain.tbSamePrefix.Text + vbNewLine + CustomNBT.ToString + vbNewLine + frmMain.tbCustomNBT.Text + vbNewLine + NormalItem.ToString + vbNewLine + SuspiciousStew.ToString + vbNewLine + EnchantedBook.ToString + vbNewLine + Potion.ToString + vbNewLine + SplashPotion.ToString + vbNewLine + LingeringPotion.ToString + vbNewLine + TippedArrow.ToString + vbNewLine + GoatHorn.ToString + vbNewLine + CreativeOnly.ToString + vbNewLine + SpawnEgg.ToString + vbNewLine + CommandBlock.ToString + vbNewLine + OtherCreativeOnlyItem.ToString + vbNewLine, False)
                        frmMain.cbxScheme.Items.Clear()
                        frmMain.GetSchemeFiles(frmMain.SchemeDirectory)
                        MsgBox("Scheme was saved.", MsgBoxStyle.Information, "Saved")
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
                    MsgBox("Scheme was saved.", MsgBoxStyle.Information, "Saved")
                    Close()
                Else
                    MsgBox("Error: Scheme directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
                End If
            Else
                MsgBox("Error: Scheme name is empty. Please enter a scheme name.", MsgBoxStyle.Critical, "Error")
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub frmSaveSchemeAs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbSaveSchemeAs.Clear()
    End Sub
End Class