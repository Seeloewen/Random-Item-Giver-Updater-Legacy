Public Class frmHelp

    Dim MsgItemID As String = "You can find the Item ID ingame. After pressing F3 + H, you can hover over an item in your inventory to see its prefix and ID. " + vbNewLine + vbNewLine + "An example would be 'minecraft:grass_block'" 'text, that displays in the Item ID help menu
    Dim MsgFastWay As String = "The fast way only adds the specified items to the 'main' loot table, which reduces loading times significantly. " + vbNewLine + vbNewLine + "Note that since the items don't get added to any other loot tables, the ingame settings like 'item amount' and 'item type' won't work correctly anymore." 'Text, that displays in the 'fast item' help menu

    '-- Event handlers --

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

    Private Sub llblHowToFindItemIDAdvanced_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblHowToFindItemIDAdvanced.LinkClicked
        'Open explanation of how to find the item ID
        MsgBox(MsgItemID, MsgBoxStyle.Question, "How to find the Item ID?")
    End Sub

    Private Sub llblWhatsTheFastWayAdvanced_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblWhatsTheFastWayAdvanced.LinkClicked
        'Open explanation of the fast way
        MsgBox(MsgFastWay, MsgBoxStyle.Question, "What is the 'fast way'?")
    End Sub

    Private Sub llblHowToFindTheItemIDBasic_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblHowToFindTheItemIDBasic.LinkClicked
        'Open explanation of how to find the item ID
        MsgBox(MsgItemID, MsgBoxStyle.Question, "How to find the Item ID?")
    End Sub

    Private Sub lblWhatIsTheFastWayBasic_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblWhatIsTheFastWayBasic.LinkClicked
        'Open explanation of the fast way
        MsgBox(MsgFastWay, MsgBoxStyle.Question, "What is the 'fast way'?")
    End Sub
End Class