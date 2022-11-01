Public Class frmHelp

    Dim MsgItemID As String = "You can find the Item ID ingame. After pressing F3 + H, you can hover over an item in your inventory to see its prefix and ID. " + vbNewLine + vbNewLine + "An example would be 'minecraft:grass_block'"
    Dim MsgFastWay As String = "The fast way only adds the specified items to the 'main' loot table, which reduces loading times significantly. " + vbNewLine + vbNewLine + "Note that since the items don't get added to any other loot tables, the ingame settings like 'item amount' and 'item type' won't work correctly anymore."

    Private Sub llblRIGPMC_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblRIGPMC.LinkClicked
        'Open Planet Minecraft webpage of the Random Item Giver Datapack
        Process.Start("https://www.planetminecraft.com/data-pack/random-item-giver-datapack-1-0-0-minecraft-1-16-2/")
    End Sub

    Private Sub llblRIGGithub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblRIGGithub.LinkClicked
        'Open GitHub webpage of the Random Item Giver Datapack
        Process.Start("https://github.com/Seeloewen/Random-Item-Giver-Datapack")
    End Sub

    Private Sub llblDiscord_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblDiscord.LinkClicked
        Process.Start("https://discord.gg/YAc2CcZPm3")
    End Sub

    Private Sub llblHowToFindTheItemIDBasic_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblHowToFindTheItemIDBasic.LinkClicked
        MsgBox(MsgItemID, MsgBoxStyle.Question, "How to find the Item ID?")
    End Sub

    Private Sub lblWhatIsTheFastWayBasic_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblWhatIsTheFastWayBasic.LinkClicked
        MsgBox(MsgFastWay, MsgBoxStyle.Question, "What is the 'fast way'?")
    End Sub

    Private Sub llblRIG117Note_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblRIG117Note.LinkClicked
        MsgBox("The 1.17 version of the Random Item Giver contains some duplicates by default. This is because the version is outdated and it was never fixed.", MsgBoxStyle.Exclamation, "Note about Random Item Giver 1.17")
    End Sub

    Private Sub llblTellMe_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblTellMe.LinkClicked
        Process.Start("https://www.curseforge.com/minecraft/mc-mods/tellme")
    End Sub

    Private Sub llblOtherDiscord_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblOtherDiscord.LinkClicked
        Process.Start("https://discord.gg/YAc2CcZPm3")
    End Sub

    Private Sub llblDatapackPMC_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblDatapackPMC.LinkClicked
        Process.Start("https://www.planetminecraft.com/data-pack/random-item-giver-datapack-1-0-0-minecraft-1-16-2/")
    End Sub

    Private Sub llblSoftwareGithub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblSoftwareGithub.LinkClicked
        Process.Start("https://github.com/Seeloewen/Random-Item-Giver-Updater")
    End Sub

    Private Sub llblDatapackGithub_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblDatapackGithub.LinkClicked
        Process.Start("https://github.com/Seeloewen/Random-Item-Giver-Datapack")
    End Sub

    Private Sub llblHowToFindItemIDAdvanced_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblHowToFindItemIDAdvanced.LinkClicked
        MsgBox(MsgItemID, MsgBoxStyle.Question, "How to find the Item ID?")
    End Sub

    Private Sub llblWhatsTheFastWayAdvanced_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblWhatsTheFastWayAdvanced.LinkClicked
        MsgBox(MsgFastWay, MsgBoxStyle.Question, "What is the 'fast way'?")
    End Sub
End Class