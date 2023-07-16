Public Class frmHelp

    Dim msgItemID As String = "You can find the Item ID ingame. After pressing F3 + H, you can hover over an item in your inventory to see its prefix and ID." + vbNewLine + vbNewLine + "An example would be 'minecraft:grass_block'" 'text, that displays in the Item ID help menu
    Dim msgFastWay As String = "The fast way only adds the specified items to the 'main' loot table, which reduces loading times significantly. " + vbNewLine + vbNewLine + "Note that since the items don't get added to any other loot tables, the ingame settings like 'item amount' and 'item type' won't work correctly anymore." 'Text, that displays in the 'fast item' help menu
    Dim selectedPage As Integer = 1

    '-- Event handlers --

    Private Sub frmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Load user preferences
        LoadDesign()

        'Show default settings page
        selectedPage = 1
        If frmMain.design = "Dark" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        ElseIf frmMain.design = "Light" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        End If
    End Sub

    Private Sub llblRIGPMC_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblRIGPMC.LinkClicked
        'Open Planet Minecraft webpage of the Random Item Giver Datapack
        Process.Start("https://www.planetminecraft.com/data-pack/random-item-giver-datapack-1-0-0-minecraft-1-16-2/")
    End Sub

    Private Sub llblRIGGithub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblRIGGithub.LinkClicked
        'Open GitHub webpage of the Random Item Giver Datapack
        Process.Start("https://github.com/Seeloewen/Random-Item-Giver-Datapack")
    End Sub

    Private Sub llblDiscord_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblDiscord.LinkClicked
        'Open Louis9's discord
        Process.Start("https://discord.gg/YAc2CcZPm3")
    End Sub

    Private Sub llblTellMe_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblTellMe.LinkClicked
        'Open TellMe curseforge page
        Process.Start("https://www.curseforge.com/minecraft/mc-mods/tellme")
    End Sub

    Private Sub llblOtherDiscord_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblOtherDiscord.LinkClicked
        'Open Louis9's discord
        Process.Start("https://discord.gg/YAc2CcZPm3")
    End Sub

    Private Sub llblDatapackPMC_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblDatapackPMC.LinkClicked
        'Open Random Item Giver Planet Minecraft page
        Process.Start("https://www.planetminecraft.com/data-pack/random-item-giver-datapack-1-0-0-minecraft-1-16-2/")
    End Sub

    Private Sub llblSoftwareGithub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblSoftwareGithub.LinkClicked
        'Open Random Item Giver Updater Github page
        Process.Start("https://github.com/Seeloewen/Random-Item-Giver-Updater")
    End Sub

    Private Sub llblDatapackGithub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblDatapackGithub.LinkClicked
        'Open Random Item Giver datapack Github page
        Process.Start("https://github.com/Seeloewen/Random-Item-Giver-Datapack")
    End Sub

    Private Sub llblNewVersion_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblNewVersion.LinkClicked
        'Open GitHub page of new version
        Process.Start("https://github.com/Seeloewen/Random-Item-Giver-Updater")
    End Sub

    Private Sub llblHowToFindItemIDAdvanced_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblHowToFindItemIDAdvanced.Click
        'Open explanation of how to find the item ID
        MsgBox(msgItemID, MsgBoxStyle.Question, "How to find the Item ID?")
    End Sub

    Private Sub llblWhatsTheFastWayAdvanced_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblWhatsTheFastWayAdvanced.Click
        'Open explanation of the fast way
        MsgBox(msgFastWay, MsgBoxStyle.Question, "What is the 'fast way'?")
    End Sub

    Private Sub llblHowToFindTheItemIDBasic_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblHowToFindTheItemIDBasic.LinkClicked
        'Open explanation of how to find the item ID
        MsgBox(msgItemID, MsgBoxStyle.Question, "How to find the Item ID?")
    End Sub

    Private Sub lblWhatIsTheFastWayBasic_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblWhatIsTheFastWayBasic.LinkClicked
        'Open explanation of the fast way
        MsgBox(msgFastWay, MsgBoxStyle.Question, "What is the 'fast way'?")
    End Sub

    '-- Custom methods --

    Private Sub LoadDesign()
        'Load dark mode
        If frmMain.design = "Dark" Then
            lblHeader.ForeColor = Color.White
            BackColor = Color.FromArgb(50, 50, 50)
            tpIntroduction.BackColor = Color.FromArgb(50, 50, 50)
            lblIntroduction.ForeColor = Color.White
            llblDiscord.LinkColor = Color.LightBlue
            lblLastEditedIntroduction.ForeColor = Color.White
            tpSimpleOverview.BackColor = Color.FromArgb(50, 50, 50)
            lblSimpleOverview.ForeColor = Color.White
            lblLastEditedSimpleOverview.ForeColor = Color.White
            llblRIGPMC.LinkColor = Color.LightBlue
            llblRIGGithub.LinkColor = Color.LightBlue
            pbAddItemsBasic.BackgroundImage = My.Resources.imgAddingItemsBasicDark
            lblAddItemsToDatapackBasic.ForeColor = Color.White
            tpAddingItemsBasic.BackColor = Color.FromArgb(50, 50, 50)
            btnNavIntroduction.ForeColor = Color.White
            btnNavSimpleOverview.ForeColor = Color.White
            btnNavAddingItemsBasic.ForeColor = Color.White
            btnNavAddingItemsAdvanced.ForeColor = Color.White
            btnNavDuplicateFinder.ForeColor = Color.White
            btnNavProfilesAndSchemes.ForeColor = Color.White
            btnNavOther.ForeColor = Color.White
            llblHowToFindTheItemIDBasic.LinkColor = Color.LightBlue
            llblWhatIsTheFastWayBasic.LinkColor = Color.LightBlue
            lblLastEditedAddItemsBasic.ForeColor = Color.White
            pbAddItemsAdvanced.BackgroundImage = My.Resources.imgAddingItemsAdvancedDark
            lblLastEditedAddingItemsAdvanced.ForeColor = Color.White
            llblHowToFindItemIDAdvanced.LinkColor = Color.LightBlue
            llblWhatsTheFastWayAdvanced.LinkColor = Color.LightBlue
            lblLastEditedAddingItemsAdvanced.ForeColor = Color.White
            pbDuplicateFinder.BackgroundImage = My.Resources.imgDuplicateFinderDarkHelp
            lblChooseDatapack.BackColor = Color.FromArgb(105, 105, 105)
            lblChooseDatapack.ForeColor = Color.FromArgb(128, 255, 255)
            lblDuplicateList.ForeColor = Color.FromArgb(128, 255, 255)
            lblDuplicateList.BackColor = Color.FromArgb(50, 50, 50)
            lblDescriptionDuplicateFinder.ForeColor = Color.White
            lblLastEditedDuplicateFinder.ForeColor = Color.White
            lblLastEditedProfilesAndSchemes.ForeColor = Color.White
            tpAddingItemsAdvanced.BackColor = Color.FromArgb(50, 50, 50)
            tpDuplicateFinder.BackColor = Color.FromArgb(50, 50, 50)
            tpProfilesAndSchemes.BackColor = Color.FromArgb(50, 50, 50)
            lblDescriptionSchemes.ForeColor = Color.White
            lblDescriptionAddingItemsAdvanced.ForeColor = Color.White
            lblDescriptionAddItemsBasic.ForeColor = Color.White
            tpOther.BackColor = Color.FromArgb(50, 50, 50)
            lblOther.ForeColor = Color.White
            lblBeginChecking.ForeColor = Color.FromArgb(121, 255, 255)
            lblBeginChecking.BackColor = Color.FromArgb(68, 68, 68)
            lblSelectDatapackFolderAdvanced.ForeColor = Color.FromArgb(121, 255, 255)
            lblSelectDatapackFolderAdvanced.BackColor = Color.FromArgb(100, 100, 100)
            lblSelectDatapackVersionAdvanced.ForeColor = Color.FromArgb(121, 255, 255)
            lblSelectDatapackVersionAdvanced.BackColor = Color.FromArgb(100, 100, 100)
            lblEnterItemIDHereAdvanced.ForeColor = Color.FromArgb(121, 255, 255)
            lblEnterItemIDHereAdvanced.BackColor = Color.FromArgb(100, 100, 100)
            lblSelectItemTypeAdvanced.ForeColor = Color.FromArgb(121, 255, 255)
            lblSelectItemTypeAdvanced.BackColor = Color.FromArgb(127, 127, 127)
            lblSpecifyPrefixAndNBTTagAdvanced.ForeColor = Color.FromArgb(121, 255, 255)
            lblSpecifyPrefixAndNBTTagAdvanced.BackColor = Color.FromArgb(127, 127, 127)
            lblAddItemsToDatapackAdvanced.ForeColor = Color.FromArgb(121, 255, 255)
            lblAddItemsToDatapackAdvanced.BackColor = Color.FromArgb(68, 68, 68)
            lblSelectDatapackFolderBasic.ForeColor = Color.FromArgb(121, 255, 255)
            lblSelectDatapackFolderBasic.BackColor = Color.FromArgb(100, 100, 100)
            lblSelectDatapackVersionBasic.ForeColor = Color.FromArgb(121, 255, 255)
            lblSelectDatapackVersionBasic.BackColor = Color.FromArgb(100, 100, 100)
            lblSelectItemTypeBasic.ForeColor = Color.FromArgb(121, 255, 255)
            lblSelectItemTypeBasic.BackColor = Color.FromArgb(127, 127, 127)
            lblSelectItemIDBasic.ForeColor = Color.FromArgb(121, 255, 255)
            lblSelectItemIDBasic.BackColor = Color.FromArgb(100, 100, 100)
            lblSpecifyNBTTagBasic.ForeColor = Color.FromArgb(121, 255, 255)
            lblSpecifyNBTTagBasic.BackColor = Color.FromArgb(100, 100, 100)
            lblAddItemsToDatapackBasic.ForeColor = Color.FromArgb(121, 255, 255)
            lblAddItemsToDatapackBasic.BackColor = Color.FromArgb(68, 68, 68)
            llblDatapackPMC.LinkColor = Color.LightBlue
            llblDatapackGithub.LinkColor = Color.LightBlue
            llblSoftwareGithub.LinkColor = Color.LightBlue
            llblOtherDiscord.LinkColor = Color.LightBlue
            llblTellMe.LinkColor = Color.LightBlue
            lblLastEditedOther.ForeColor = Color.White
            llblNewVersion.LinkColor = Color.LightBlue
            pbNavigationBar.BackgroundImage = My.Resources.imgHelpNavigationBarDark
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavDark
        End If
    End Sub

    '-- Button animations --

    Private Sub btnNavIntroduction_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavIntroduction.MouseDown
        If frmmain.design =  "Light" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmmain.design =  "Dark" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavIntroduction_MouseEnter(sender As Object, e As EventArgs) Handles btnNavIntroduction.MouseEnter
        If (selectedPage = 1) = False Then
            If frmmain.design =  "Light" Then
                btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf frmmain.design =  "Dark" Then
                btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavIntroduction_MouseLeave(sender As Object, e As EventArgs) Handles btnNavIntroduction.MouseLeave
        If (selectedPage = 1) = False Then
            If frmmain.design =  "Light" Then
                btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavIntroduction_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavIntroduction.MouseUp
        If (selectedPage = 1) = False Then
            If frmmain.design =  "Light" Then
                btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavSimpleOverview_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavSimpleOverview.MouseDown
        If frmmain.design =  "Light" Then
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmmain.design =  "Dark" Then
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavSimpleOverview_MouseEnter(sender As Object, e As EventArgs) Handles btnNavSimpleOverview.MouseEnter
        If (selectedPage = 2) = False Then
            If frmmain.design =  "Light" Then
                btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf frmmain.design =  "Dark" Then
                btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavSimpleOverview_MouseLeave(sender As Object, e As EventArgs) Handles btnNavSimpleOverview.MouseLeave
        If (selectedPage = 2) = False Then
            If frmmain.design =  "Light" Then
                btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavSimpleOverview_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavSimpleOverview.MouseUp
        If (selectedPage = 2) = False Then
            If frmmain.design =  "Light" Then
                btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavAddingItemsBasic_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavAddingItemsBasic.MouseDown
        If frmmain.design =  "Light" Then
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmmain.design =  "Dark" Then
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavAddingItemsBasic_MouseEnter(sender As Object, e As EventArgs) Handles btnNavAddingItemsBasic.MouseEnter
        If (selectedPage = 3) = False Then
            If frmmain.design =  "Light" Then
                btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf frmmain.design =  "Dark" Then
                btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavAddingItemsBasic_MouseLeave(sender As Object, e As EventArgs) Handles btnNavAddingItemsBasic.MouseLeave
        If (selectedPage = 3) = False Then
            If frmmain.design =  "Light" Then
                btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavAddingItemsBasic_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavAddingItemsBasic.MouseUp
        If (selectedPage = 3) = False Then
            If frmmain.design =  "Light" Then
                btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavAddingItemsAdvanced_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavAddingItemsAdvanced.MouseDown
        If frmmain.design =  "Light" Then
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmmain.design =  "Dark" Then
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavAddingItemsAdvanced_MouseEnter(sender As Object, e As EventArgs) Handles btnNavAddingItemsAdvanced.MouseEnter
        If (selectedPage = 4) = False Then
            If frmmain.design =  "Light" Then
                btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf frmmain.design =  "Dark" Then
                btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavAddingItemsAdvanced_MouseLeave(sender As Object, e As EventArgs) Handles btnNavAddingItemsAdvanced.MouseLeave
        If (selectedPage = 4) = False Then
            If frmmain.design =  "Light" Then
                btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavAddingItemsAdvanced_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavAddingItemsAdvanced.MouseUp
        If (selectedPage = 4) = False Then
            If frmmain.design =  "Light" Then
                btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavDuplicateFinder_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavDuplicateFinder.MouseDown
        If frmmain.design =  "Light" Then
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmmain.design =  "Dark" Then
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavDuplicateFinder_MouseEnter(sender As Object, e As EventArgs) Handles btnNavDuplicateFinder.MouseEnter
        If (selectedPage = 5) = False Then
            If frmmain.design =  "Light" Then
                btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf frmmain.design =  "Dark" Then
                btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavDuplicateFinder_MouseLeave(sender As Object, e As EventArgs) Handles btnNavDuplicateFinder.MouseLeave
        If (selectedPage = 5) = False Then
            If frmmain.design =  "Light" Then
                btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavDuplicateFinder_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavDuplicateFinder.MouseUp
        If (selectedPage = 5) = False Then
            If frmmain.design =  "Light" Then
                btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavProfilesAndSchemes_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavProfilesAndSchemes.MouseDown
        If frmmain.design =  "Light" Then
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmmain.design =  "Dark" Then
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavProfilesAndSchemes_MouseEnter(sender As Object, e As EventArgs) Handles btnNavProfilesAndSchemes.MouseEnter
        If (selectedPage = 6) = False Then
            If frmmain.design =  "Light" Then
                btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf frmmain.design =  "Dark" Then
                btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavProfilesAndSchemes_MouseLeave(sender As Object, e As EventArgs) Handles btnNavProfilesAndSchemes.MouseLeave
        If (selectedPage = 6) = False Then
            If frmmain.design =  "Light" Then
                btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavProfilesAndSchemes_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavProfilesAndSchemes.MouseUp
        If (selectedPage = 6) = False Then
            If frmmain.design =  "Light" Then
                btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavOther_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNavOther.MouseDown
        If frmmain.design =  "Light" Then
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmmain.design =  "Dark" Then
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If
    End Sub

    Private Sub btnNavOther_MouseEnter(sender As Object, e As EventArgs) Handles btnNavOther.MouseEnter
        If (selectedPage = 7) = False Then
            If frmmain.design =  "Light" Then
                btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavHover
            ElseIf frmmain.design =  "Dark" Then
                btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavDarkHover
            End If
        End If
    End Sub

    Private Sub btnNavOther_MouseLeave(sender As Object, e As EventArgs) Handles btnNavOther.MouseLeave
        If (selectedPage = 7) = False Then
            If frmmain.design =  "Light" Then
                btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavOther_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNavOther.MouseUp
        If (selectedPage = 7) = False Then
            If frmmain.design =  "Light" Then
                btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNav
            ElseIf frmmain.design =  "Dark" Then
                btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            End If
        End If
    End Sub

    Private Sub btnNavIntroduction_Click(sender As Object, e As EventArgs) Handles btnNavIntroduction.Click
        'Change button design
        If frmmain.design =  "Light" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf frmmain.design =  "Dark" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavDark
        End If

        'Show corresponding settings page
        selectedPage = 1
        tcHelp.SelectedIndex = 0
    End Sub

    Private Sub btnNavSimpleOverview_Click(sender As Object, e As EventArgs) Handles btnNavSimpleOverview.Click
        'Change button design
        If frmmain.design =  "Light" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf frmmain.design =  "Dark" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavDark
        End If

        'Show corresponding settings page
        selectedPage = 2
        tcHelp.SelectedIndex = 1
    End Sub

    Private Sub btnNavAddingItemsBasic_Click(sender As Object, e As EventArgs) Handles btnNavAddingItemsBasic.Click
        'Change button design
        If frmmain.design =  "Light" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf frmmain.design =  "Dark" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavDark
        End If

        'Show corresponding settings page
        selectedPage = 3
        tcHelp.SelectedIndex = 2
    End Sub

    Private Sub btnNavAddingItemsAdvanced_Click(sender As Object, e As EventArgs) Handles btnNavAddingItemsAdvanced.Click
        'Change button design
        If frmmain.design =  "Light" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf frmmain.design =  "Dark" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavDark
        End If

        'Show corresponding settings page
        selectedPage = 4
        tcHelp.SelectedIndex = 3
    End Sub

    Private Sub btnNavDuplicateFinder_Click(sender As Object, e As EventArgs) Handles btnNavDuplicateFinder.Click
        'Change button design
        If frmmain.design =  "Light" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf frmmain.design =  "Dark" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavDark
        End If

        'Show corresponding settings page
        selectedPage = 5
        tcHelp.SelectedIndex = 4
    End Sub

    Private Sub btnNavProfilesAndSchemes_Click(sender As Object, e As EventArgs) Handles btnNavProfilesAndSchemes.Click
        'Change button design
        If frmmain.design =  "Light" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavClick
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNav
        ElseIf frmmain.design =  "Dark" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavDark
        End If

        'Show corresponding settings page
        selectedPage = 6
        tcHelp.SelectedIndex = 5
    End Sub

    Private Sub btnNavOther_Click(sender As Object, e As EventArgs) Handles btnNavOther.Click
        'Change button design
        If frmmain.design = "Light" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNav
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavClick
        ElseIf frmmain.design = "Dark" Then
            btnNavIntroduction.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavSimpleOverview.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsBasic.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavAddingItemsAdvanced.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavDuplicateFinder.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavProfilesAndSchemes.BackgroundImage = My.Resources.imgButtonSettingsNavDark
            btnNavOther.BackgroundImage = My.Resources.imgButtonSettingsNavDarkClick
        End If

        'Show corresponding settings page
        selectedPage = 7
        tcHelp.SelectedIndex = 6
    End Sub
End Class