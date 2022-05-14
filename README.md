# Random Item Giver Updater

Since its become very hard to update and add items to the Random Item Giver Datapack, I've created a software that makes it very easy to add new items of all kinds.
The Software has a very simple UI and lots of help elements and explainations in case you don't understand something. It's designed to update every loot table automatically instead of you having to add all items by hand.

It is still work in progress but it already has several useful features.

## Adding items to datapack
The software allows you to easily add items to datapack. It supports all available versions of the datapack and new versions are added as fast as possible.
You can set a custom prefix and NBT tag and select the loot tables the item should be added to. It also has a detector to automatically detect which datapack version the selected datapack folder is. It also gives a warning if you try to add an item that already exists in the datapack to avoid duplicates.

![image](https://user-images.githubusercontent.com/74246933/168442584-e3ae4bf0-60d9-40b9-882a-a55c85aac8bb.png)

## Duplicate finder
If you think that you may have added an item twice or more or you just want to check you can use the duplicate finder to check if there are any duplicates in the Random Item Giver. Please note that it does not support the loot tables 'potions', 'lingering_potions', 'splash_potions', 'enchanted_books', 'tipped_arrows' and 'suspicious_stews', but every normal item loot table is supported.

![image](https://user-images.githubusercontent.com/74246933/163675991-333ba960-f0b8-496f-898b-aa97ef6e94c6.png)

## Item List Importer
If you want to import a list of items stored in a file you can use the Item List Importer! It supports importing .txt and .csv files containing item prefix and ID. It specially designed to work with the TellMe Mod files generated using the '/tellme dump to-file csv items-registry-name-only' command (https://www.curseforge.com/minecraft/mc-mods/tellme).

![image](https://user-images.githubusercontent.com/74246933/168442653-143d7008-b5a0-4c33-8bd3-8740ac456aa0.png)
