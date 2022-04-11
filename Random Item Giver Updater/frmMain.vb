Imports System.IO

Public Class frmMain

    'General variables for the software
    Public qm As String

    'All variables that play a key role in updating the datapack
    Dim EditFileLastLineLength As String
    Dim EditFilePath As String
    Dim MainFolderPath As String
    Dim LineRemoveLoop As Integer
    Dim NBTtag As String
    Dim Prefix As String
    Dim ExceptionAddItem As String
    Dim DuplicateDetected As Boolean = False
    Dim FileTemp As String
    Dim ItemAmountPath As String
    Dim IgnoreDuplicates As Boolean = False

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MsgBox("Warning: You are running an early alpha build of the Random Item Giver Updater." + vbNewLine + vbNewLine + "You have to expect to find bugs and incomplete features." + vbNewLine + vbNewLine + "Please give as much feedback as possible so the software can be improved!" + vbNewLine + vbNewLine + "Use this early test build at your own risk and with caution.", MsgBoxStyle.Exclamation, "Notice")
        qm = Quotationmark.Text
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        IgnoreDuplicates = False
        DuplicateDetected = False
        EditFilePath = tbDatapackPath.Text

        If rbtnRIG117.Checked Then
            MsgBox("Warning: Version 1.17 does not support the newest features of the Random Item Giver!" + vbNewLine + "It was last officially updated on 20.01.2022, Version 1.1.5", MsgBoxStyle.Exclamation, "Warning")
        End If

        If rbtnRIG119.Checked Then
            MsgBox("Warning: Version 1.19 is currently in Beta." + vbNewLine + "You can still use it but can't expect it to work properly.", MsgBoxStyle.Exclamation, "Warning")
        End If

        CallAddItem()
    End Sub

    Private Sub CallAddItem()
        If cbCreativeOnly.Checked = False Then
            rbtnCommandBlock.Checked = False
            rbtnOtherItem.Checked = False
            rbtnSpawnEgg.Checked = False
        End If

        If String.IsNullOrEmpty(tbID.Text) = False Then

            btnAddItem.Text = "Adding item..."

            If rbtnRIG116.Checked Then

                'Add item to loot tables for 1 item
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "1", "1.16", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "1", "1.16", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.16", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.16", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.16", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.16", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.16", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.16", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "1", "1.16", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "1", "1.16", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "1", "1.16", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "1", "1.16", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "1", "1.16", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "1", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 2 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "2", "1.16", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "2", "1.16", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.16", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.16", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.16", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.16", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.16", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.16", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "2", "1.16", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "2", "1.16", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "2", "1.16", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "2", "1.16", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "2", "1.16", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "2", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 3 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "3", "1.16", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "3", "1.16", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.16", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.16", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.16", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.16", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.16", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.16", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "3", "1.16", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "3", "1.16", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "3", "1.16", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "3", "1.16", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "3", "1.16", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "3", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 5 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "5", "1.16", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "5", "1.16", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.16", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.16", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.16", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.16", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.16", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.16", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "5", "1.16", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "5", "1.16", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "5", "1.16", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "5", "1.16", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "5", "1.16", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "5", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 10 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "10", "1.16", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "10", "1.16", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.16", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.16", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.16", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.16", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.16", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.16", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "10", "1.16", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "10", "1.16", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "10", "1.16", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "10", "1.16", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "10", "1.16", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "10", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 32 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "32", "1.16", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "32", "1.16", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.16", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.16", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.16", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.16", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.16", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.16", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "32", "1.16", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "32", "1.16", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "32", "1.16", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "32", "1.16", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "32", "1.16", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "32", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 64 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "64", "1.16", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "64", "1.16", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.16", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.16", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.16", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.16", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.16", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.16", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "64", "1.16", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "64", "1.16", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "64", "1.16", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "64", "1.16", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "64", "1.16", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "64", "1.16", "tipped_arrows")
                End If

            ElseIf rbtnRIG117.Checked Then

                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "1", "1.17", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "1", "1.17", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.17", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.17", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.17", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.17", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.17", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.17", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "1", "1.17", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "1", "1.17", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "1", "1.17", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "1", "1.17", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "1", "1.17", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "1", "1.17", "tipped_arrows")
                End If

            ElseIf rbtnRIG118.Checked Then

                'Add item to loot tables for 1 item
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "1", "1.18", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "1", "1.18", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.18", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.18", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.18", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.18", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.18", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.18", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "1", "1.18", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "1", "1.18", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "1", "1.18", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "1", "1.18", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "1", "1.18", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "1", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 2 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "2", "1.18", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "2", "1.18", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.18", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.18", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.18", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.18", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.18", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.18", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "2", "1.18", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "2", "1.18", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "2", "1.18", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "2", "1.18", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "2", "1.18", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "2", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 3 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "3", "1.18", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "3", "1.18", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.18", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.18", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.18", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.18", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.18", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.18", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "3", "1.18", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "3", "1.18", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "3", "1.18", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "3", "1.18", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "3", "1.18", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "3", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 5 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "5", "1.18", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "5", "1.18", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.18", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.18", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.18", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.18", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.18", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.18", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "5", "1.18", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "5", "1.18", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "5", "1.18", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "5", "1.18", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "5", "1.18", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "5", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 10 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "10", "1.18", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "10", "1.18", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.18", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.18", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.18", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.18", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.18", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.18", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "10", "1.18", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "10", "1.18", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "10", "1.18", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "10", "1.18", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "10", "1.18", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "10", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 32 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "32", "1.18", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "32", "1.18", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.18", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.18", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.18", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.18", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.18", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.18", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "32", "1.18", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "32", "1.18", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "32", "1.18", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "32", "1.18", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "32", "1.18", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "32", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 64 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "64", "1.18", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "64", "1.18", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.18", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.18", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.18", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.18", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.18", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.18", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "64", "1.18", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "64", "1.18", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "64", "1.18", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "64", "1.18", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "64", "1.18", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "64", "1.18", "tipped_arrows")
                End If

            ElseIf rbtnRIG119.Checked Then

                'Add item to loot tables for 1 item
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "1", "1.19", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "1", "1.19", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.19", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.19", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.19", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.19", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.19", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "1", "1.19", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "1", "1.19", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "1", "1.19", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "1", "1.19", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "1", "1.19", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "1", "1.19", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "1", "1.19", "tipped_arrows")
                End If

                'Add item to loot tables for 2 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "2", "1.19", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "2", "1.19", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.19", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.19", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.19", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.19", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.19", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "2", "1.19", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "2", "1.19", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "2", "1.19", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "2", "1.19", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "2", "1.19", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "2", "1.19", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "2", "1.19", "tipped_arrows")
                End If

                'Add item to loot tables for 3 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "3", "1.19", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "3", "1.19", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.19", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.19", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.19", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.19", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.19", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "3", "1.19", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "3", "1.19", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "3", "1.19", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "3", "1.19", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "3", "1.19", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "3", "1.19", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "3", "1.19", "tipped_arrows")
                End If

                'Add item to loot tables for 5 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "5", "1.19", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "5", "1.19", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.19", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.19", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.19", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.19", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.19", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "5", "1.19", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "5", "1.19", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "5", "1.19", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "5", "1.19", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "5", "1.19", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "5", "1.19", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "5", "1.19", "tipped_arrows")
                End If

                'Add item to loot tables for 10 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "10", "1.19", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "10", "1.19", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.19", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.19", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.19", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.19", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.19", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "10", "1.19", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "10", "1.19", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "10", "1.19", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "10", "1.19", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "10", "1.19", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "10", "1.19", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "10", "1.19", "tipped_arrows")
                End If

                'Add item to loot tables for 32 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "32", "1.19", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "32", "1.19", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.19", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.19", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.19", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.19", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.19", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "32", "1.19", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "32", "1.19", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "32", "1.19", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "32", "1.19", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "32", "1.19", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "32", "1.19", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "32", "1.19", "tipped_arrows")
                End If

                'Add item to loot tables for 64 items
                If cbNormalItem.Checked Then
                    AddItem(tbID.Text, "64", "1.19", "main")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked Then
                    AddItem(tbID.Text, "64", "1.19", "main_without_creative-only")
                End If
                If rbtnCommandBlock.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.19", "special_vxx")
                End If
                If rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.19", "special_vvx")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnOtherItem.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.19", "special_xvx")
                End If
                If rbtnSpawnEgg.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.19", "special_xvv")
                End If
                If rbtnSpawnEgg.Checked = False And rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.19", "special_xxv")
                End If
                If rbtnCommandBlock.Checked = False And cbNormalItem.Checked = True Then
                    AddItem(tbID.Text, "64", "1.19", "special_vxv")
                End If
                If cbSuspiciousStew.Checked Then
                    AddItem(tbID.Text, "64", "1.19", "suspicious_stews")
                End If
                If cbEnchantedBook.Checked Then
                    AddItem(tbID.Text, "64", "1.19", "enchanted_books")
                End If
                If cbPotion.Checked Then
                    AddItem(tbID.Text, "64", "1.19", "potions")
                End If
                If cbSplashPotion.Checked Then
                    AddItem(tbID.Text, "64", "1.19", "splash_potions")
                End If
                If cbLingeringPotion.Checked Then
                    AddItem(tbID.Text, "64", "1.19", "lingering_potions")
                End If
                If cbTippedArrow.Checked Then
                    AddItem(tbID.Text, "64", "1.19", "tipped_arrows")
                End If
            End If

            btnAddItem.Text = "Add item to datapack"
        Else
            MsgBox("Please enter a text in the ID textbox!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub AddItem(Item_ID As String, Item_Amount As Integer, Version As String, Loot_Table As String)

        If DuplicateDetected = False Or (DuplicateDetected = False And IgnoreDuplicates = True) Then
            ExceptionAddItem = ""

            If cbNBT.Checked Then
                NBTtag = tbNBT.Text
            Else
                NBTtag = "NONE"
            End If

            If cbCustomPrefix.Checked Then
                Prefix = tbCustomPrefix.Text
            Else
                Prefix = "minecraft"
            End If

            'Define ItemAmountPath depending on Item_Amount
            If Item_Amount = 1 Then
                ItemAmountPath = "1item\"
            ElseIf Item_Amount > 1 Then
                ItemAmountPath = Item_Amount.ToString + "sameitems\"
            End If

            'Check if item you want to add already exists
            FileTemp = My.Computer.FileSystem.ReadAllText(EditFilePath + "\data\randomitemgiver\loot_tables\" + ItemAmountPath + Loot_Table + ".json")

            If FileTemp.Contains(qm + Prefix + ":" + tbID.Text + qm) = False Or IgnoreDuplicates = True Then
                Try
                    If Version = "1.16" OrElse Version = "1.18" OrElse Version = "1.19" Then

                        If Item_Amount = 1 Then
                            LineRemoveLoop = 8

                            While LineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(EditFilePath + "\data\randomitemgiver\loot_tables\1item\" + Loot_Table + ".json")
                                Dim FileStreamEditFile As New FileStream(EditFilePath + "\data\randomitemgiver\loot_tables\1item\" + Loot_Table + ".json", FileMode.Open, FileAccess.ReadWrite)
                                EditFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - EditFileLastLineLength)
                                FileStreamEditFile.Close()

                                LineRemoveLoop = LineRemoveLoop - 1
                            End While

                            If Loot_Table = "main" OrElse Loot_Table = "main_without_creative-only" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_xvx" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_xxv" OrElse Loot_Table = "Special_xvv" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vxx" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\1item\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + vbNewLine + rtbCodeEnd.Text, True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\1item\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + rtbCodeEnd.Text, True)
                            End If

                        ElseIf Item_Amount = 2 Then
                            LineRemoveLoop = 8

                            While LineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(EditFilePath + "\data\randomitemgiver\loot_tables\2sameitems\" + Loot_Table + ".json")
                                Dim FileStreamEditFile As New FileStream(EditFilePath + "\data\randomitemgiver\loot_tables\2sameitems\" + Loot_Table + ".json", FileMode.Open, FileAccess.ReadWrite)
                                EditFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - EditFileLastLineLength)
                                FileStreamEditFile.Close()

                                LineRemoveLoop = LineRemoveLoop - 1
                            End While

                            If Loot_Table = "main" OrElse Loot_Table = "main_without_creative-only" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_xvx" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_xxv" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vxx" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\2sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + rtb2Items.Text + vbNewLine + "          ]" + vbNewLine + rtbCodeEnd.Text, True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\2sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + rtb2Items.Text + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + rtbCodeEnd.Text, True)
                            End If

                        ElseIf Item_Amount = 3 Then
                            LineRemoveLoop = 8

                            While LineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(EditFilePath + "\data\randomitemgiver\loot_tables\3sameitems\" + Loot_Table + ".json")
                                Dim FileStreamEditFile As New FileStream(EditFilePath + "\data\randomitemgiver\loot_tables\3sameitems\" + Loot_Table + ".json", FileMode.Open, FileAccess.ReadWrite)
                                EditFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - EditFileLastLineLength)
                                FileStreamEditFile.Close()

                                LineRemoveLoop = LineRemoveLoop - 1
                            End While

                            If Loot_Table = "main" OrElse Loot_Table = "main_without_creative-only" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_xvx" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_xxv" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vxx" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\3sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + rtb3Items.Text + vbNewLine + "          ]" + vbNewLine + rtbCodeEnd.Text, True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\3sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + rtb3Items.Text + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + rtbCodeEnd.Text, True)
                            End If

                        ElseIf Item_Amount = 5 Then
                            LineRemoveLoop = 8

                            While LineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(EditFilePath + "\data\randomitemgiver\loot_tables\5sameitems\" + Loot_Table + ".json")
                                Dim FileStreamEditFile As New FileStream(EditFilePath + "\data\randomitemgiver\loot_tables\5sameitems\" + Loot_Table + ".json", FileMode.Open, FileAccess.ReadWrite)
                                EditFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - EditFileLastLineLength)
                                FileStreamEditFile.Close()

                                LineRemoveLoop = LineRemoveLoop - 1
                            End While

                            If Loot_Table = "main" OrElse Loot_Table = "main_without_creative-only" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_xvx" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_xxv" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vxx" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\5sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + rtb5Items.Text + vbNewLine + "          ]" + vbNewLine + rtbCodeEnd.Text, True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\5sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + rtb5Items.Text + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + rtbCodeEnd.Text, True)
                            End If

                        ElseIf Item_Amount = 10 Then
                            LineRemoveLoop = 8

                            While LineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(EditFilePath + "\data\randomitemgiver\loot_tables\10sameitems\" + Loot_Table + ".json")
                                Dim FileStreamEditFile As New FileStream(EditFilePath + "\data\randomitemgiver\loot_tables\10sameitems\" + Loot_Table + ".json", FileMode.Open, FileAccess.ReadWrite)
                                EditFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - EditFileLastLineLength)
                                FileStreamEditFile.Close()

                                LineRemoveLoop = LineRemoveLoop - 1
                            End While

                            If Loot_Table = "main" OrElse Loot_Table = "main_without_creative-only" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_xvx" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_xxv" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vxx" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\10sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + rtb10Items.Text + vbNewLine + "          ]" + vbNewLine + rtbCodeEnd.Text, True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\10sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + rtb10Items.Text + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + rtbCodeEnd.Text, True)
                            End If

                        ElseIf Item_Amount = 32 Then
                            LineRemoveLoop = 8

                            While LineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(EditFilePath + "\data\randomitemgiver\loot_tables\32sameitems\" + Loot_Table + ".json")
                                Dim FileStreamEditFile As New FileStream(EditFilePath + "\data\randomitemgiver\loot_tables\32sameitems\" + Loot_Table + ".json", FileMode.Open, FileAccess.ReadWrite)
                                EditFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - EditFileLastLineLength)
                                FileStreamEditFile.Close()

                                LineRemoveLoop = LineRemoveLoop - 1
                            End While

                            If Loot_Table = "main" OrElse Loot_Table = "main_without_creative-only" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_xvx" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_xxv" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vxx" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\32sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + rtb32Items.Text + vbNewLine + "          ]" + vbNewLine + rtbCodeEnd.Text, True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\32sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + rtb32Items.Text + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + rtbCodeEnd.Text, True)
                            End If

                        ElseIf Item_Amount = 64 Then
                            LineRemoveLoop = 8

                            While LineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(EditFilePath + "\data\randomitemgiver\loot_tables\64sameitems\" + Loot_Table + ".json")
                                Dim FileStreamEditFile As New FileStream(EditFilePath + "\data\randomitemgiver\loot_tables\64sameitems\" + Loot_Table + ".json", FileMode.Open, FileAccess.ReadWrite)
                                EditFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - EditFileLastLineLength)
                                FileStreamEditFile.Close()

                                LineRemoveLoop = LineRemoveLoop - 1
                            End While

                            If Loot_Table = "main" OrElse Loot_Table = "main_without_creative-only" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_xvx" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_xxv" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vxx" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\64sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + rtb64Items.Text + vbNewLine + "          ]" + vbNewLine + rtbCodeEnd.Text, True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\64sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + rtb64Items.Text + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + rtbCodeEnd.Text, True)
                            End If

                        End If

                    ElseIf Version = "1.17" Then

                        'Convert Settings to 1.17 RIG format
                        If Loot_Table = "potions" Then
                            Loot_Table = "potion"
                        End If
                        If Loot_Table = "splash_potions" Then
                            Loot_Table = "splash_potion"
                        End If
                        If Loot_Table = "lingering_potions" Then
                            Loot_Table = "lingering_potion"
                        End If
                        If Loot_Table = "suspicious_stews" Then
                            Loot_Table = "suspicious_stew"
                        End If
                        If Loot_Table = "tipped_arrows" Then
                            Loot_Table = "tipped_arrow"
                        End If

                        LineRemoveLoop = 8

                        While LineRemoveLoop > 0
                            Dim EditFileLines() As String = IO.File.ReadAllLines(EditFilePath + "\data\randomitemgiver\loot_tables\" + Loot_Table + ".json")
                            Dim FileStreamEditFile As New FileStream(EditFilePath + "\data\randomitemgiver\loot_tables\" + Loot_Table + ".json", FileMode.Open, FileAccess.ReadWrite)
                            EditFileLastLineLength = EditFileLines.Last.Length.ToString

                            FileStreamEditFile.SetLength(FileStreamEditFile.Length - EditFileLastLineLength)
                            FileStreamEditFile.Close()

                            LineRemoveLoop = LineRemoveLoop - 1
                        End While

                        If Loot_Table = "main" OrElse Loot_Table = "main_without_creative-only" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_xvx" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_xxv" OrElse Loot_Table = "Special_xvv" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vxx" Then
                            My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + vbNewLine + rtbCodeEnd.Text, True)
                        ElseIf Loot_Table = "suspicious_stew" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potion" OrElse Loot_Table = "splash_potion" OrElse Loot_Table = "lingering_potion" OrElse Loot_Table = "tipped_arrow" Then
                            My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + Prefix + ":" + tbID.Text + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + rtbCodeEnd.Text, True)
                        End If

                    End If


                Catch Exception As Exception
                    ExceptionAddItem = Exception.Message
                End Try

                If String.IsNullOrEmpty(ExceptionAddItem) Then
                    frmOutput.rtbLog.AppendText("[" + DateTime.Now + "]" + " Succesfully added " + Prefix + ":" + tbID.Text + " to " + Loot_Table + " in Version " + Version + " (NBT: " + NBTtag + ")" + vbNewLine)
                    tbSmallOutput.Text = "Succesfully added " + Prefix + ":" + tbID.Text + " to " + Loot_Table + " in Version " + Version + " (NBT: " + NBTtag + ")"
                Else
                    tbSmallOutput.Text = "Error: " + ExceptionAddItem
                    frmOutput.rtbLog.AppendText("[" + DateTime.Now + "]" + " Error: " + ExceptionAddItem + vbNewLine)
                End If

            Else
                Select Case MessageBox.Show("The item you are trying to add already exists in the datapack." + vbNewLine + "Are you sure you want to add it again? This will result in duplicates.", "Warning", MessageBoxButtons.YesNo)
                    Case Windows.Forms.DialogResult.Yes
                        IgnoreDuplicates = True
                    Case Windows.Forms.DialogResult.No
                        IgnoreDuplicates = False
                        DuplicateDetected = True
                        tbSmallOutput.Text = "Cancelled adding " + Prefix + ":" + tbID.Text + " to " + Loot_Table + " in Version " + Version + " (NBT: " + NBTtag + ")"
                End Select
            End If
        End If
    End Sub

    Private Sub btnBrowseDatapackPath_Click(sender As Object, e As EventArgs) Handles btnBrowseDatapackPath.Click
        fbdMainFolderPath.ShowDialog()
        tbDatapackPath.Text = fbdMainFolderPath.SelectedPath

        'Detect version of the datapack
        If My.Computer.FileSystem.DirectoryExists(tbDatapackPath.Text) Then
            If My.Computer.FileSystem.FileExists(tbDatapackPath.Text + "/pack.mcmeta") Then

                Dim VersionString As String = System.IO.File.ReadAllLines(tbDatapackPath.Text + "/pack.mcmeta")(2)
                Dim ParseVersion As String = Replace(VersionString, "    " + qm + "pack_format" + qm + ": ", "")
                Dim Version As String = Replace(ParseVersion, ",", "")

                Try
                    If Convert.ToInt32(Version) > 10 Then
                        lblDatapackDetection.Text = "Detected datapack, but could not determine version"
                        MsgBox("A datapack has been detected but the Version number is greater than 10." + vbNewLine + "This means that the datapack is possibly newer than the software supports." + vbNewLine + "The newest available version in the software has been selected but is not guaranteed to work.", MsgBoxStyle.Exclamation, "Warning")
                        rbtnRIG119.Checked = True
                    ElseIf Version = "10" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.19"
                        rbtnRIG119.Checked = True
                    ElseIf Version = "9" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.18"
                        rbtnRIG118.Checked = True
                    ElseIf Version = "8" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.18. Please note that your version of 1.18 is outdated."
                        rbtnRIG118.Checked = True
                    ElseIf Version = "7" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.17"
                        rbtnRIG117.Checked = True
                    ElseIf Version = "6" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.16"
                        rbtnRIG116.Checked = True
                    ElseIf Convert.ToInt32(Version) < 6 Then
                        lblDatapackDetection.Text = "Detected datapack, but version is most likely unsupported"
                        MsgBox("A datapack has been detected but the version number is smaller than 6." + vbNewLine + "This means that the datapack version is older than 1.15 which the Random Item Giver does not support." + vbNewLine + "The oldest available version has been selected but will most likely not work.", MsgBoxStyle.Exclamation, "Warning")
                        rbtnRIG116.Checked = True
                    Else
                        lblDatapackDetection.Text = "Detected datapack, but could not determine version."
                    End If
                Catch ex As Exception
                    MsgBox("Error when selecting datapack: " + ex.Message, MsgBoxStyle.Critical, "Error")
                    lblDatapackDetection.Text = "Detected datapack, but could not determine version."
                    rbtnRIG119.Checked = True
                End Try
            Else
                    lblDatapackDetection.Text = "Folder found, but could not detect datapack."
            End If
        Else
            lblDatapackDetection.Text = "No datapack detected."
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.Show()
    End Sub

    Private Sub ChangelogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangelogToolStripMenuItem.Click
        frmChangelog.Show()
    End Sub

    Private Sub SoftwareHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SoftwareHelpToolStripMenuItem.Click
        MsgBox("Work in progress")
    End Sub

    Private Sub OutputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutputToolStripMenuItem.Click
        MsgBox("Work in progress")
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        MsgBox("Work in progress")
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub OpenDatapackFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDatapackFolderToolStripMenuItem.Click
        MsgBox("Work in progress")
    End Sub

    Private Sub cbCustomPrefix_CheckedChanged(sender As Object, e As EventArgs) Handles cbCustomPrefix.CheckedChanged
        If cbCustomPrefix.Checked Then
            tbCustomPrefix.Enabled = True
        Else
            tbCustomPrefix.Enabled = False
        End If
    End Sub

    Private Sub cbNBT_CheckedChanged(sender As Object, e As EventArgs) Handles cbNBT.CheckedChanged
        If cbNBT.Checked Then
            tbNBT.Enabled = True
        Else
            tbNBT.Enabled = False
        End If
    End Sub

    Private Sub cbCreativeOnly_CheckedChanged(sender As Object, e As EventArgs) Handles cbCreativeOnly.CheckedChanged
        If cbCreativeOnly.Checked Then
            rbtnOtherItem.Enabled = True
            rbtnCommandBlock.Enabled = True
            rbtnSpawnEgg.Enabled = True
        Else
            rbtnOtherItem.Enabled = False
            rbtnCommandBlock.Enabled = False
            rbtnSpawnEgg.Enabled = False
            rbtnSpawnEgg.Checked = False
            rbtnCommandBlock.Checked = False
            rbtnOtherItem.Checked = False
        End If
    End Sub

    Private Sub btnShowOutput_Click(sender As Object, e As EventArgs) Handles btnShowOutput.Click
        MsgBox("Work in progress")
    End Sub

    Private Sub FindDuplicatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindDuplicatesToolStripMenuItem.Click
        frmDuplicateFinder.Show()
    End Sub
End Class
