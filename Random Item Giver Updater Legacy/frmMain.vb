Imports System.Environment
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices

Partial Class frmMain

    'General variables for the software
    Public appData As String = GetFolderPath(SpecialFolder.ApplicationData) 'Appdata directory
    Public versionLog As String = "0.5.4-Dev (14.06.2024)" 'Version that gets displayed in the log
    Public rawVersion As String = "0.5.4-Dev"
    Public settingsVersion As Double = 4 'Current version of the settings file that the app is using
    Dim settingsArray As String() 'Array which the settings will be loaded in
    Dim loadedSettingsVersion As Double 'Version of the settings file that gets loaded
    Dim firstLoadCompleted As Boolean = False 'Whether application is loaded or not. Used for the datapack version detection.
    Dim actionRunning As Boolean = False 'Whether an action is running or not
    Dim settingsFile As String = $"{appData}\Random Item Giver Updater Legacy\settings.txt" 'Location of the settings file
    Public logDirectory As String = $"{appData}\Random Item Giver Updater Legacy\Logs\" 'Directory where the log files are saved
    Public datapackPathExtension As String
    Dim logFileName As String 'File name of the log file
    Public design As String = "System Default" 'Selected design
    Dim osVersion As Version = Environment.OSVersion.Version
    Public rtbLog As RichTextBox = New RichTextBox()
    Public cbxDefaultProfile As ComboBox = New ComboBox()

    'Profile variables
    Public profileDirectory As String = appData + "\Random Item Giver Updater Legacy\Profiles\" 'Directory where the profiles are located
    Dim profileList As String() 'Contains a list of loaded profiles

    'Scheme variables
    Public schemeDirectory As String = appData + "\Random Item Giver Updater Legacy\Schemes\" 'Directory where the schemes are located
    Dim schemeList As String() 'Contains a list of loaded schemes
    Dim loadFromScheme As String 'Scheme that gets loaded
    Dim schemeContent As String() 'Content that the scheme contains

    'All variables that play a key role in updating the datapack
    Dim editFileLastLineLength As String 'Length of the last line of the file that gets edited
    Dim lineRemoveLoop As Integer 'Used for the loop that removes the last lines when adding items
    Dim exceptionAddItem As String 'Contains the ExceptionMessage when adding items
    Dim duplicateDetected As Boolean = False 'Whether a duplicate was detected or not
    Dim ignoreDuplicates As Boolean = False 'Whether duplicates should be automatically ignored
    Dim item As String 'Name of the item that gets added
    Dim itemAddMode As String 'Mode that the item gets added in (Either 'Normal' or 'Fast')
    Dim progressStep As Double 'Step size that the progressbar makes
    Dim workerProgress As Double 'Progress of the BackGroundWorker that adds the items
    Dim addItemResult As String 'Result of adding the items (Whether it failed or succeeded)
    Dim totalItemAmount As Integer 'Total amount of items that are being added
    Dim totalDuplicatesIgnored As Integer 'Total amount of duplicates that were ignored during the item adding process

    'Variables that also exist as UI elements, needed for threading
    Dim normalItem As Boolean
    Dim suspiciousStew As Boolean
    Dim enchantedBook As Boolean
    Dim potion As Boolean
    Dim splashPotion As Boolean
    Dim lingeringPotion As Boolean
    Dim tippedArrow As Boolean
    Dim goatHorn As Boolean
    Dim painting As Boolean
    Dim creativeOnly As Boolean
    Dim spawnEgg As Boolean
    Dim commandBlock As Boolean
    Dim otherCreativeOnlyItem As Boolean
    Dim samePrefix As Boolean
    Dim customNBT As Boolean
    Dim itemsList As String()
    Dim samePrefixString As String
    Dim customNBTString As String
    Dim addItemsFast As Boolean
    Dim output As String
    Dim datapackPath As String
    Dim datapackVersion As String


    '-- Event handlers --

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Convert old main directory to new one, if necessary
        If My.Computer.FileSystem.FileExists($"{appData}\Random Item Giver Updater\FirstStartCompleted") And Not My.Computer.FileSystem.DirectoryExists($"{appData}\Random Item Giver Updater Legacy\") Then
            Rename($"{appData}\Random Item Giver Updater", $"{appData}\Random Item Giver Updater Legacy")
        End If

        'Create directory in appdata if it doesnt exist already
        If Not My.Computer.FileSystem.DirectoryExists($"{appData}\Random Item Giver Updater Legacy\") Then
            My.Computer.FileSystem.CreateDirectory($"{appData}\Random Item Giver Updater Legacy\")
            WriteToLog("Created the 'Random Item Giver Updater Legacy' directory in the Appdata folder for application files.", "Info")
        End If

        'Post initial log text
        WriteToLog($"Random Item Giver Updater Legacy {versionLog}", "Info")
        WriteToLog("You are running a legacy build, please be aware of issues that may occur!", "Warning")

        'Add click event of frmMain to every control in frmMain
        For Each ctrl As Control In Controls
            If Not ctrl.Equals(btnHamburger) Then
                AddHandler ctrl.Click, AddressOf frmMain_MouseClick
            End If
        Next
        AddHandler rtbItem.TextChanged, AddressOf rtbLog_TextChanged

        'If software gets started for the first time, add default schemes and create file that indicates that the software was started once already.
        If Not My.Computer.FileSystem.FileExists($"{appData}\Random Item Giver Updater Legacy\FirstStartCompleted") Then
            My.Computer.FileSystem.WriteAllText($"{appData}\Random Item Giver Updater Legacy\FirstStartCompleted", "", False)
            If Not My.Computer.FileSystem.DirectoryExists(schemeDirectory) Then
                My.Computer.FileSystem.CreateDirectory(schemeDirectory)
            End If
            AddDefaultSchemes()
        End If

        'Initialize User Settings and Preferences
        CheckOS()
        InitializeLoadingSettings()
        InitializeProfilesAndSchemes()
        DetermineDesign()
        LoadDesign()

        'Disable log if setting is enabled
        If My.Settings.DisableLogging Then
            frmOutput.rtbLog.Clear()
            If My.Computer.FileSystem.FileExists($"{appData}\Random Item Giver Updater Legacy\DebugLogTemp") Then
                My.Computer.FileSystem.DeleteFile($"{appData}\Random Item Giver Updater Legacy\DebugLogTemp")
            End If
        End If

        'Hide Legacy Warning if setting is enabled
        If Not My.Settings.HideLegacyWarning Then
            MsgBox("Warning: You are running a legacy version of the Random Item Giver Updater." + vbNewLine + vbNewLine + "You have to expect to find bugs or other issues." + vbNewLine + vbNewLine + "Please note that this version of the software will no longer receive major content updates!" + vbNewLine + vbNewLine + "Things may break, you should use this software at your own risk and with caution.", MsgBoxStyle.Exclamation, "Warning")
        End If

        'Load advanced view setting
        If My.Settings.UseAdvancedViewByDefault Then
            EnableAdvancedView()
            cbEnableAdvancedView.Checked = True
        Else
            DisableAdvancedView()
            cbEnableAdvancedView.Checked = False
        End If

        'Check whether this is the first start of the app
        CheckForFirstStart()
    End Sub

    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        'Check if datapack path exists
        If My.Computer.FileSystem.DirectoryExists(datapackPath) Then
            'Reset previous progress
            pbAddingItemsProgress.Value = 0
            workerProgress = 0
            totalDuplicatesIgnored = 0
            addItemResult = "success"

            'Disable all user input while the process runs
            DisableInput()

            'Set total amount of items and start the backgroundworker that adds the items
            totalItemAmount = rtbItem.Lines.Count
            bgwAddItems.RunWorkerAsync()
        Else
            MsgBox("Please enter a valid datapack path!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub bgwAddItems_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwAddItems.DoWork
        'Checks if there are 100 or more Items being added while AddItemsFast is disabled and will show a warning if thats the case
        If itemsList.Count >= 100 And Not addItemsFast Then
            Select Case MsgBox("Warning: You are trying to add 100 or more items." + vbNewLine + "This may take a long time to complete. It's recommended to enable 'Fast Item Adding' to speed up the process." + vbNewLine + vbNewLine + "Are you sure you want to continue?", vbExclamation + vbYesNo, "Warning")
                Case Windows.Forms.DialogResult.Yes
                    'Sets ItemAddMode. This should be redundant in this case, despite of this I will still leave it there to be save
                    If addItemsFast Then
                        itemAddMode = "Fast"
                    Else
                        itemAddMode = "Normal"
                    End If

                    'Resets variables used to detect duplicates
                    ignoreDuplicates = False
                    duplicateDetected = False

                    WriteToLog($"Adding {totalItemAmount} items. This can take a while depending on the mode and amount of items.", "Info")

                    'Calculate ProgressStep
                    progressStep = 100 / itemsList.Count

                    'Start adding the items
                    BeginAddingItems()
            End Select
        Else
            'Resets variables used to detect duplicates
            ignoreDuplicates = False
            duplicateDetected = False

            'Sets ItemAddMode
            If addItemsFast Then
                itemAddMode = "Fast"
            Else
                itemAddMode = "Normal"
            End If

            'Start the corresponding method for adding items depending on the amount. Will also calculate ProgressStep and post result afterwards.
            WriteToLog($"Adding {totalItemAmount} item(s)...", "Info")
            progressStep = 100 / itemsList.Count
            BeginAddingItems()

        End If
    End Sub

    Private Sub rtbLog_TextChanged(sender As Object, e As EventArgs)
        'Update log file and log in output window
        rtbLog.SaveFile($"{appData}\Random Item Giver Updater Legacy\DebugLogTemp")
        frmOutput.rtbLog.LoadFile($"{appData}\Random Item Giver Updater Legacy\DebugLogTemp")
    End Sub

    Private Sub btnHamburger_Click(sender As Object, e As EventArgs) Handles btnHamburger.Click
        'Show menu with different options
        If cmsHamburgerButton.Visible Then
            cmsHamburgerButton.Hide()
        Else
            cmsHamburgerButton.Show(btnHamburger, 0, btnHamburger.Top + 40)
        End If
    End Sub

    Private Sub btnBrowseDatapackPath_Click(sender As Object, e As EventArgs) Handles btnBrowseDatapackPath.Click
        'Show folder browser dialog to select datapack path
        fbdMainFolderPath.ShowDialog()
        tbDatapackPath.Text = fbdMainFolderPath.SelectedPath
    End Sub

    Private Sub cbCustomPrefix_CheckedChanged(sender As Object, e As EventArgs) Handles cbSamePrefix.CheckedChanged
        'Toggle the custom prefix setting
        If cbSamePrefix.Checked Then
            tbSamePrefix.Enabled = True
            gbItemID.Text = "Items (ID)"
            samePrefix = True
        Else
            tbSamePrefix.Enabled = False
            gbItemID.Text = "Items (Prefix:ID)"
            samePrefix = False
        End If
    End Sub

    Private Sub cbNBT_CheckedChanged(sender As Object, e As EventArgs) Handles cbCustomNBT.CheckedChanged
        'Toggle the custom NBT tag setting
        tbCustomNBT.Enabled = cbCustomNBT.CheckState
        customNBT = cbCustomNBT.CheckState
    End Sub

    Private Sub cbCreativeOnly_CheckedChanged(sender As Object, e As EventArgs) Handles cbCreativeOnly.CheckedChanged
        'Toggle the creative-only setting
        creativeOnly = cbCreativeOnly.CheckState
        rbtnOtherItem.Enabled = cbCreativeOnly.CheckState
        rbtnCommandBlock.Enabled = cbCreativeOnly.CheckState
        rbtnSpawnEgg.Enabled = cbCreativeOnly.CheckState
    End Sub

    Private Sub btnShowOutput_Click(sender As Object, e As EventArgs)
        'Open log window
        frmOutput.Show()
    End Sub

    Private Sub cbAddItemsFast_CheckedChanged(sender As Object, e As EventArgs) Handles cbAddItemsFast.CheckedChanged
        'Toggle fast item adding method
        If cbAddItemsFast.Checked Then
            addItemsFast = True
            cbCreativeOnly.Checked = False
            cbCreativeOnly.Enabled = False
            cbSuspiciousStew.Enabled = False
            cbSuspiciousStew.Checked = False
            cbEnchantedBook.Enabled = False
            cbEnchantedBook.Checked = False
            cbPotion.Enabled = False
            cbPotion.Checked = False
            cbSplashPotion.Enabled = False
            cbSplashPotion.Checked = False
            cbLingeringPotion.Enabled = False
            cbLingeringPotion.Checked = False
            cbTippedArrow.Enabled = False
            cbTippedArrow.Checked = False
            cbGoatHorn.Enabled = False
            cbGoatHorn.Checked = False
            cbCustomNBT.Enabled = False
            cbCustomNBT.Checked = False
            tbCustomNBT.Enabled = False
            cbPainting.Enabled = False
            cbPainting.Enabled = False
            MsgBox("This setting speeds up the process of adding items, narrowing it down to only a few seconds in most cases." + vbNewLine + "This is recommended if you need to add 100+ Items." + vbNewLine + vbNewLine + "Please note that if you enable this option, the items will only be added to the main loot table. This means that you won't be able to use the item settings in the datapack afterwards.", MsgBoxStyle.Information, "Enable Fast Item Adding")
        Else
            addItemsFast = False
            cbCreativeOnly.Checked = False
            cbCreativeOnly.Enabled = True
            cbSuspiciousStew.Enabled = True
            cbSuspiciousStew.Checked = False
            cbEnchantedBook.Enabled = True
            cbEnchantedBook.Checked = False
            cbPotion.Enabled = True
            cbPotion.Checked = False
            cbSplashPotion.Enabled = True
            cbSplashPotion.Checked = False
            cbLingeringPotion.Enabled = True
            cbLingeringPotion.Checked = False
            cbTippedArrow.Enabled = True
            cbTippedArrow.Checked = False
            cbCustomNBT.Enabled = True
            cbCustomNBT.Checked = False
            If cbAddItemsFast.Checked = False Then
                If datapackVersion = "Version 1.20" OrElse datapackVersion = "Version 1.19.4" OrElse datapackVersion = "Version 1.20.1" OrElse datapackVersion = "Version 1.20.2 - 1.20.4" OrElse datapackVersion = "Version 1.20.5 - 1.20.6" OrElse datapackVersion = "Version 1.21" Then
                    cbPainting.Enabled = True
                    cbGoatHorn.Enabled = True
                ElseIf datapackVersion = "Version 1.19 - 1.19.3" Then
                    cbPainting.Enabled = False
                    cbGoatHorn.Enabled = True
                ElseIf datapackVersion = "Version 1.16.2 - 1.16.5" OrElse datapackVersion = "Version 1.17 - 1.17.1" OrElse datapackVersion = "Version 1.18 - 1.18.2" Then
                    cbPainting.Enabled = False
                    cbGoatHorn.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub rtbItem_TextChanged(sender As Object, e As EventArgs) Handles rtbItem.TextChanged
        'Pass text onto the variable
        itemsList = rtbItem.Lines

        'Check the amount of items (lines) and change recommendation of checkbox for fast item adding
        If rtbItem.Lines.Count >= 100 Then
            cbAddItemsFast.Text = "Enable Fast Item Adding (Recommended)"
        Else
            cbAddItemsFast.Text = "Enable Fast Item Adding"
        End If

        'Display amount of items in the total items label
        lblItemsTotal.Text = $"Total amount of items: {rtbItem.Lines.Count}"
    End Sub

    Private Sub tbSamePrefix_TextChanged(sender As Object, e As EventArgs) Handles tbSamePrefix.TextChanged
        'Pass text onto the variable
        samePrefixString = tbSamePrefix.Text
    End Sub

    Private Sub tbCustomNBT_TextChanged(sender As Object, e As EventArgs) Handles tbCustomNBT.TextChanged
        'Pass text onto the variable
        customNBTString = tbCustomNBT.Text
    End Sub

    Private Sub cbNormalItem_CheckedChanged(sender As Object, e As EventArgs) Handles cbNormalItem.CheckedChanged
        'Pass checkstate onto the variable
        normalItem = cbNormalItem.CheckState
    End Sub

    Private Sub cbSuspiciousStew_CheckedChanged(sender As Object, e As EventArgs) Handles cbSuspiciousStew.CheckedChanged
        'Pass checkstate onto the variable
        suspiciousStew = cbSuspiciousStew.CheckState
    End Sub

    Private Sub cbEnchantedBook_CheckedChanged(sender As Object, e As EventArgs) Handles cbEnchantedBook.CheckedChanged
        'Pass checkstate onto the variable
        enchantedBook = cbEnchantedBook.CheckState
    End Sub

    Private Sub cbPotion_CheckedChanged(sender As Object, e As EventArgs) Handles cbPotion.CheckedChanged
        'Pass checkstate onto the variable
        potion = cbPotion.CheckState
    End Sub

    Private Sub cbSplashPotion_CheckedChanged(sender As Object, e As EventArgs) Handles cbSplashPotion.CheckedChanged
        'Pass checkstate onto the variable
        splashPotion = cbSplashPotion.CheckState
    End Sub
    Private Sub cbLingeringPotion_CheckedChanged(sender As Object, e As EventArgs) Handles cbLingeringPotion.CheckedChanged
        'Pass checkstate onto the variable
        lingeringPotion = cbLingeringPotion.CheckState
    End Sub

    Private Sub cbTippedArrow_CheckedChanged(sender As Object, e As EventArgs) Handles cbTippedArrow.CheckedChanged
        'Pass checkstate onto the variable
        tippedArrow = cbTippedArrow.CheckState
    End Sub

    Private Sub cbGoatHorn_CheckedChanged(sender As Object, e As EventArgs) Handles cbGoatHorn.CheckedChanged
        'Pass checkstate onto the variable
        goatHorn = cbGoatHorn.CheckState
    End Sub

    Private Sub cbPainting_CheckedChanged(sender As Object, e As EventArgs) Handles cbPainting.CheckedChanged
        'Pass checkstate onto the variable
        painting = cbPainting.CheckState
    End Sub

    Private Sub rbtnSpawnEgg_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSpawnEgg.CheckedChanged
        'Pass checkstate onto the variable
        spawnEgg = rbtnSpawnEgg.Checked
    End Sub

    Private Sub rbtnCommandBlock_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCommandBlock.CheckedChanged
        'Pass checkstate onto the variable
        commandBlock = rbtnCommandBlock.Checked
    End Sub

    Private Sub rbtnOtherItem_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOtherItem.CheckedChanged
        'Pass checkstate onto the variable
        otherCreativeOnlyItem = rbtnOtherItem.Checked
    End Sub

    Private Sub tbDatapackPath_TextChanged(sender As Object, e As EventArgs) Handles tbDatapackPath.TextChanged
        'Pass checkstate onto the variable
        datapackPath = tbDatapackPath.Text
        If firstLoadCompleted Then
            DetermineDatapackVersion()
        End If
    End Sub

    Private Sub cbxVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxVersion.SelectedIndexChanged
        'Pass text onto the variable
        datapackVersion = cbxVersion.SelectedItem

        'Toggle certain checkboxes depending on selected version
        If cbAddItemsFast.Checked = False Then
            If datapackVersion = "Version 1.20.5 - 1.20.6" OrElse datapackVersion = "Version 1.21" Then
                cbCustomNBT.Text = "Item Stack Component"
                cbPainting.Enabled = True
                cbGoatHorn.Enabled = True
            ElseIf datapackVersion = "Version 1.20" OrElse datapackVersion = "Version 1.19.4" OrElse datapackVersion = "Version 1.20.1" OrElse datapackVersion = "Version 1.20.2 - 1.20.4" Then
                cbCustomNBT.Text = "NBT Tag"
                cbPainting.Enabled = True
                cbGoatHorn.Enabled = True
            ElseIf datapackVersion = "Version 1.19 - 1.19.3" Then
                cbCustomNBT.Text = "NBT Tag"
                cbPainting.Enabled = False
                cbGoatHorn.Enabled = True
            ElseIf datapackVersion = "Version 1.16.2 - 1.16.5" OrElse datapackVersion = "Version 1.17 - 1.17.1" OrElse datapackVersion = "Version 1.18 - 1.18.2" Then
                cbCustomNBT.Text = "NBT Tag"
                cbPainting.Enabled = False
                cbGoatHorn.Enabled = False
            End If
        End If
    End Sub

    Private Sub bgwAddItems_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwAddItems.RunWorkerCompleted
        'When adding the items is complete, enable all menu controls again and set progress to 100%
        pbAddingItemsProgress.Value = 100
        EnableInput()

        'If result is "success" show messagebox. This variable would've been changed if an error occured.
        If rtbItem.Lines.Count > totalDuplicatesIgnored Then
            If addItemResult = "success" Then
                MsgBox($"Successfully added {rtbItem.Lines.Count - totalDuplicatesIgnored} item(s)!", MsgBoxStyle.Information, "Added items")
                WriteToLog($"Successfully added {rtbItem.Lines.Count - totalDuplicatesIgnored} items", "Info")
            ElseIf addItemResult = "error" Then
                MsgBox($"Failed to add {rtbItem.Lines.Count - totalDuplicatesIgnored} items.", MsgBoxStyle.Critical, "Error")
            End If
        End If

        'Show 'Add item to datapack' button which also hides the progress bar and show total amount of items in richtextbox again
        btnAddItem.Show()
        lblItemsTotal.Text = $"Total amount of items: {rtbItem.Lines.Count}"
    End Sub

    Private Sub bgwAddItems_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwAddItems.ProgressChanged
        'Set progressbar value to current worker progress
        pbAddingItemsProgress.Value = e.ProgressPercentage
    End Sub

    Private Sub cbEnableAdvancedView_CheckedChanged(sender As Object, e As EventArgs) Handles cbEnableAdvancedView.CheckedChanged
        'Toggle advanced view
        If cbEnableAdvancedView.Checked Then
            EnableAdvancedView()
        Else
            DisableAdvancedView()
        End If
    End Sub

    Private Sub btnLoadProfile_Click(sender As Object, e As EventArgs) Handles btnLoadProfile.Click
        'Open the Load profile dialog
        frmLoadProfileFrom.ShowDialog("Main")
    End Sub

    Private Sub btnSaveProfile_Click(sender As Object, e As EventArgs) Handles btnSaveProfile.Click
        'Open the Save profile dialog
        frmSaveProfileAs.ShowDialog()
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'When starting the application, run initial datapack detection and set firstloadcompleted to true. This variable is used to determine whether the startup process has been completed
        DetermineDatapackVersion()
        firstLoadCompleted = True
    End Sub

    Private Sub cbxScheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxScheme.SelectedIndexChanged
        'Starts the whole loading process of the scheme
        InitializeLoadingScheme(cbxScheme.SelectedItem, False)
    End Sub

    Private Sub btnDeleteSelectedScheme_Click(sender As Object, e As EventArgs) Handles btnDeleteSelectedScheme.Click
        'Delete the currently selected scheme if it exists
        If My.Computer.FileSystem.FileExists($"{schemeDirectory}{cbxScheme.SelectedItem}.txt") Then
            My.Computer.FileSystem.DeleteFile($"{schemeDirectory}{cbxScheme.SelectedItem}.txt")
            MsgBox($"Scheme {cbxScheme.SelectedItem} was deleted.", MsgBoxStyle.Information, "Deleted")
            WriteToLog($"Deleted scheme {cbxScheme.SelectedItem}", "Info")
            cbxScheme.Items.Remove(cbxScheme.SelectedItem)
        Else
            MsgBox("Error: Scheme does not exist.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub btnSaveAsNewScheme_Click(sender As Object, e As EventArgs) Handles btnSaveAsNewScheme.Click
        'Open save scheme dialog
        frmSaveSchemeAs.ShowDialog()
    End Sub

    Private Sub btnOverwriteSelectedScheme_Click(sender As Object, e As EventArgs) Handles btnOverwriteSelectedScheme.Click
        'Overwrite the currently selected scheme
        frmSaveSchemeAs.SaveScheme(cbxScheme.SelectedItem, True)
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        'If the user wants to close the application while an item adding process is still running, it will show a confirmation warning
        If bgwAddItems.IsBusy Then
            If MsgBox("There is an action still in progress. " + vbNewLine + "Are you sure you want to exit? This will stop the currently running action.", vbQuestion + vbYesNo, "Exit application") <> DialogResult.Yes Then
                e.Cancel = True
            End If
        End If

        'Save log file if auto save is enabled
        If My.Settings.AutoSaveLogs Then
            logFileName = $"Random_Item_Giver_Updater_Legacy_Log_{DateTime.Now}_Ver_{versionLog}"
            logFileName = logFileName.Replace(":", "-").Replace(".", "-").Replace(" ", "_").Replace("(", "").Replace(")", "")
            logFileName = $"{logDirectory}{logFileName}.txt"
            frmOutput.SaveLog(logFileName, False)
        End If
    End Sub


    Private Sub EinstellungenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EinstellungenToolStripMenuItem.Click
        'Reset hamburger button to default state
        btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton

        'Show settings window
        frmSettings.Show()
    End Sub

    Private Sub OutputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutputToolStripMenuItem.Click
        'Reset hamburger button to default state
        btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton

        'Show output window
        frmOutput.Show()
    End Sub

    Private Sub DToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentationToolStripMenuItem.Click
        'Reset hamburger button to default state
        btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton

        'Show help documentary window
        frmHelp.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        'Reset hamburger button to default state
        btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton

        'Show about dialog
        frmAbout.ShowDialog()
    End Sub

    Private Sub ChangelogToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangelogToolStripMenuItem.Click
        'Reset hamburger button to default state
        btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton

        'Show changelog dialog
        frmChangelog.ShowDialog()
    End Sub

    Private Sub DuplicateFinderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DuplicateFinderToolStripMenuItem.Click
        'Reset hamburger button to default state
        btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton

        'Show duplicate finder
        frmDuplicateFinder.Show()
    End Sub

    Private Sub ItemListImporterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemListImporterToolStripMenuItem.Click
        'Reset hamburger button to default state
        btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton

        'Show item list importer
        frmItemListImporter.ShowDialog()
    End Sub

    Private Sub btnRenameScheme_Click(sender As Object, e As EventArgs) Handles btnRenameScheme.Click
        'Check if a scheme is loaded and open the scheme renaming window
        If Not String.IsNullOrEmpty(cbxScheme.Text) Then
            frmRenameScheme.ShowDialog(cbxScheme.Text)
        Else
            MsgBox("Please load a scheme in order to rename it.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    '-- Custom methods --

    Private Sub DisableInput()
        'Disable input for controls
        btnAddItem.Hide()
        cbCreativeOnly.Enabled = False
        rbtnCommandBlock.Enabled = False
        rbtnSpawnEgg.Enabled = False
        rbtnOtherItem.Enabled = False
        cbNormalItem.Enabled = False
        cbSuspiciousStew.Enabled = False
        cbEnchantedBook.Enabled = False
        cbPotion.Enabled = False
        cbSplashPotion.Enabled = False
        cbLingeringPotion.Enabled = False
        cbTippedArrow.Enabled = False
        cbGoatHorn.Enabled = False
        rtbItem.Enabled = False
        cbSamePrefix.Enabled = False
        tbSamePrefix.Enabled = False
        cbCustomNBT.Enabled = False
        tbCustomNBT.Enabled = False
        cbAddItemsFast.Enabled = False
        cbxVersion.Enabled = False
        btnBrowseDatapackPath.Enabled = False
        tbDatapackPath.Enabled = False
        cbPainting.Enabled = False
    End Sub

    Private Sub EnableInput()
        'Enable input for controls
        cbCreativeOnly.Enabled = True
        rbtnCommandBlock.Enabled = True
        rbtnSpawnEgg.Enabled = True
        rbtnOtherItem.Enabled = True
        cbNormalItem.Enabled = True
        cbSuspiciousStew.Enabled = True
        cbEnchantedBook.Enabled = True
        cbPotion.Enabled = True
        cbSplashPotion.Enabled = True
        cbLingeringPotion.Enabled = True
        cbTippedArrow.Enabled = True
        rtbItem.Enabled = True
        cbSamePrefix.Enabled = True
        If cbSamePrefix.Checked Then
            tbSamePrefix.Enabled = True
        End If
        cbCustomNBT.Enabled = True
        If cbCustomNBT.Checked Then
            tbCustomNBT.Enabled = True
        End If
        cbAddItemsFast.Enabled = True
        cbxVersion.Enabled = True
        btnBrowseDatapackPath.Enabled = True
        tbDatapackPath.Enabled = True
        'Only enable some settings depending on version of datapack
        If cbxVersion.SelectedItem = "Version 1.19.4" OrElse cbxVersion.SelectedItem = "Version 1.20" OrElse cbxVersion.SelectedItem = "Version 1.20.1" OrElse cbxVersion.SelectedItem = "Version 1.20.2 - 1.20.4" OrElse cbxVersion.SelectedItem = "Version 1.20.5 - 1.20.6" OrElse cbxVersion.SelectedItem = "Version 1.21" Then
            cbPainting.Enabled = True
            cbGoatHorn.Enabled = True
        ElseIf cbxVersion.SelectedItem = "Version 1.19 - 1.19.3" Then
            cbGoatHorn.Enabled = True
        End If
    End Sub

    Private Sub CheckOS()
        'Check whether the software runs under a supported OS or not (Supported: Windows 8.1+)
        If (osVersion.Major = 6 And osVersion.Minor = 0) OrElse (osVersion.Major = 6 And osVersion.Minor = 1) OrElse (osVersion.Major = 6 And osVersion.Minor = 2) Then
            MsgBox("You are using an Operating System that is no longer officially supported by the software. Errors and other problems may occur and you will not receive support.", MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub

    Public Sub DetermineDesign()
        'Check which setting is selected
        If My.Settings.Design = "Dark" Then
            design = "Dark"
        ElseIf My.Settings.Design = "Light" Then
            design = "Light"
        ElseIf My.Settings.Design = "System Default" Then
            'Check the registry key for Windows App Design to get current design
            Dim registryKey As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", True)
            If registryKey IsNot Nothing Then
                Dim value As Object = registryKey.GetValue("AppsUseLightTheme")
                If value IsNot Nothing AndAlso TypeOf value Is Integer Then
                    If CInt(value) = 0 Then 'Dark design
                        WriteToLog("Determined dark design based on registry key value", "Info")
                        design = "Dark"
                    Else 'Light design
                        WriteToLog("Determined light design based on registry key value", "Info")
                        design = "Light"
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub LoadDesign()
        'Load darkmode
        If design = "Dark" Then

            BackColor = Color.FromArgb(50, 50, 50)

            'Textboxes
            For Each ctrl As Control In Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.ForeColor = Color.White
                    ctrl.BackColor = Color.FromArgb(100, 100, 100)
                End If
            Next

            'Labels
            For Each ctrl As Control In Controls
                If TypeOf ctrl Is Label Then
                    If ctrl.Name = "lblBoxAddItemHeader" Or ctrl.Name = "lblBoxSelectDatapackHeader" Then
                        ctrl.ForeColor = Color.Black
                        ctrl.BackColor = Color.FromArgb(195, 195, 195)
                    ElseIf ctrl.Name = "lblHeader" Or ctrl.Name = "lblItemsTotal" Then
                        ctrl.ForeColor = Color.White
                        ctrl.BackColor = Color.FromArgb(50, 50, 50)
                    Else
                        ctrl.ForeColor = Color.White
                        ctrl.BackColor = Color.FromArgb(127, 127, 127)
                    End If
                End If
            Next

            'Checkboxes and radio buttons
            For Each ctrl As Control In Controls
                If TypeOf ctrl Is CheckBox Or TypeOf ctrl Is RadioButton Then
                    ctrl.ForeColor = Color.White
                    ctrl.BackColor = Color.FromArgb(127, 127, 127)
                End If
            Next

            'Comboboxes
            For Each ctrl As Control In Controls
                If TypeOf ctrl Is ComboBox Then
                    ctrl.ForeColor = Color.White
                    ctrl.BackColor = Color.FromArgb(105, 105, 105)
                End If
            Next

            'Everything else
            rtbItem.ForeColor = Color.White
            rtbItem.BackColor = Color.FromArgb(100, 100, 100)
            cmsHamburgerButton.BackColor = Color.DimGray
            cmsHamburgerButton.ForeColor = Color.White
            DuplicateFinderToolStripMenuItem.BackColor = Color.DimGray
            pbSelectDatapack.BackgroundImage = My.Resources.imgBackgroundPath
            pbAddItem.BackgroundImage = My.Resources.imgBackgroundItem
            gbItemID.ForeColor = Color.White
            gbItemID.BackColor = Color.FromArgb(127, 127, 127)
        End If

        'Set appearance of buttons depending on selected design
        For Each btn As Button In Controls.OfType(Of Button)
            If Not btn.Equals(btnHamburger) Then
                If design = "Dark" Then
                    btn.ForeColor = Color.White
                    btn.BackgroundImage = My.Resources.imgButton
                ElseIf design = "Light" Then
                    btn.ForeColor = Color.Black
                    btn.BackgroundImage = My.Resources.imgButtonLight
                End If
            End If
            If (Not btn.Equals(btnHamburger)) And (Not btn.Equals(btnAddItem)) Then
                If design = "Light" Then
                    btn.BackColor = Color.FromArgb(207, 207, 207)
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(207, 207, 207)
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(207, 207, 207)
                ElseIf design = "Dark" Then
                    btn.BackColor = Color.FromArgb(127, 127, 127)
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(127, 127, 127)
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(127, 127, 127)
                End If
            End If
        Next
    End Sub

    Private Sub CheckForFirstStart()
        'Check if application was already started once using this version. If not, show update news
        If My.Computer.FileSystem.FileExists($"{appData}\Random Item Giver Updater Legacy\FirstStart_{rawVersion}") = False Then
            My.Computer.FileSystem.WriteAllText($"{appData}\Random Item Giver Updater Legacy\FirstStart_{rawVersion}", "", False)
            frmUpdateNews.ShowDialog()
        End If
    End Sub

    Public Sub InitializeLoadingScheme(scheme As String, showMessage As Boolean)
        'Checks if a scheme is selected. It then reads the content of the scheme file into the array. To avoid errors with the array being too small, it gets resized. The number represents the amount of settings.
        'It then starts to convert and load the scheme, see the the method below.
        If String.IsNullOrEmpty(scheme) = False Then
            loadFromScheme = $"{schemeDirectory}{scheme}.txt"
            schemeContent = File.ReadAllLines(loadFromScheme)
            ReDim Preserve schemeContent(17)
            CheckAndConvertScheme(scheme, showMessage)
        Else
            MsgBox("Error: No scheme selected. Please select a scheme to load from.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Public Sub CheckAndConvertScheme(scheme As String, showMessage As Boolean)
        'This checks if the scheme file that was loaded has enough lines, too few lines would mean that settings are missing, meaning the file is either too old or corrupted.
        'It will check for each required line if it is empty (required lines = the length of a healthy, normal scheme file). Make sure that the line amount it checks matches the amount of settings that are being saved.
        'If a line is empty, it will fill that line with a placeholder in the array so the profile can get loaded without errors. After loading the scheme, it gets automatically saved so the corrupted/old settings file gets fixed.
        'If no required line is empty and the file is fine, it will just load the scheme like normal.
        If (String.IsNullOrEmpty(schemeContent(0)) OrElse String.IsNullOrEmpty(schemeContent(1)) OrElse String.IsNullOrEmpty(schemeContent(2)) OrElse String.IsNullOrEmpty(schemeContent(3)) OrElse String.IsNullOrEmpty(schemeContent(4)) OrElse String.IsNullOrEmpty(schemeContent(5)) OrElse String.IsNullOrEmpty(schemeContent(6)) OrElse String.IsNullOrEmpty(schemeContent(7)) OrElse String.IsNullOrEmpty(schemeContent(8)) OrElse String.IsNullOrEmpty(schemeContent(9)) OrElse String.IsNullOrEmpty(schemeContent(10)) OrElse String.IsNullOrEmpty(schemeContent(11)) OrElse String.IsNullOrEmpty(schemeContent(12)) OrElse String.IsNullOrEmpty(schemeContent(13)) OrElse String.IsNullOrEmpty(schemeContent(14)) OrElse String.IsNullOrEmpty(schemeContent(15)) OrElse String.IsNullOrEmpty(schemeContent(16))) Then
            Select Case MsgBox("You are trying to load a scheme from an older version or a corrupted scheme. You need to update it in order to load it. You usually won't lose any settings. Do you want to continue?", vbQuestion + vbYesNo, "Load old or corrupted scheme")
                Case Windows.Forms.DialogResult.Yes
                    If String.IsNullOrEmpty(schemeContent(0)) Then
                        schemeContent(0) = True
                    End If
                    If String.IsNullOrEmpty(schemeContent(1)) Then
                        schemeContent(1) = "minecraft"
                    End If
                    If String.IsNullOrEmpty(schemeContent(2)) Then
                        schemeContent(2) = False
                    End If
                    If String.IsNullOrEmpty(schemeContent(3)) Then
                        schemeContent(3) = "None"
                    End If
                    If String.IsNullOrEmpty(schemeContent(4)) Then
                        schemeContent(4) = "True"
                    End If
                    If String.IsNullOrEmpty(schemeContent(5)) Then
                        schemeContent(5) = "False"
                    End If
                    If String.IsNullOrEmpty(schemeContent(6)) Then
                        schemeContent(6) = "False"
                    End If
                    If String.IsNullOrEmpty(schemeContent(7)) Then
                        schemeContent(7) = "False"
                    End If
                    If String.IsNullOrEmpty(schemeContent(8)) Then
                        schemeContent(8) = "False"
                    End If
                    If String.IsNullOrEmpty(schemeContent(9)) Then
                        schemeContent(9) = "False"
                    End If
                    If String.IsNullOrEmpty(schemeContent(10)) Then
                        schemeContent(10) = "False"
                    End If
                    If String.IsNullOrEmpty(schemeContent(11)) Then
                        schemeContent(11) = "False"
                    End If
                    If String.IsNullOrEmpty(schemeContent(12)) Then
                        schemeContent(12) = "False"
                    End If
                    If String.IsNullOrEmpty(schemeContent(13)) Then
                        schemeContent(13) = "False"
                    End If
                    If String.IsNullOrEmpty(schemeContent(14)) Then
                        schemeContent(14) = "False"
                    End If
                    If String.IsNullOrEmpty(schemeContent(15)) Then
                        schemeContent(15) = "False"
                    End If
                    If String.IsNullOrEmpty(schemeContent(16)) Then
                        schemeContent(16) = "False"
                    End If
                    LoadScheme(scheme, False)
                    UpdateScheme(scheme)
                    MsgBox("Loaded and updated scheme. It should now work correctly!", MsgBoxStyle.Information, "Loaded and updated scheme")
                    WriteToLog($"Loaded and updated scheme {scheme}", "Info")
                Case Windows.Forms.DialogResult.No
                    MsgBox("Cancelled loading scheme.", MsgBoxStyle.Exclamation, "Warning")
            End Select
        Else
            LoadScheme(scheme, showMessage)
            WriteToLog($"Loaded scheme {scheme}", "Info")
        End If
    End Sub

    Public Sub LoadScheme(scheme As String, showMessage As Boolean)
        'Same Prefix Checkbox
        samePrefix = Convert.ToBoolean(schemeContent(0))
        cbSamePrefix.Checked = samePrefix

        'Same Prefix Textbox
        If String.IsNullOrEmpty(tbSamePrefix.Text) Then
            tbSamePrefix.Text = "None"
        Else
            tbSamePrefix.Text = schemeContent(1)
        End If

        'Custom NBT Checkbox
        customNBT = Convert.ToBoolean(schemeContent(2))
        cbCustomNBT.Checked = customNBT

        'Custom NBT Textbox
        If String.IsNullOrEmpty(tbCustomNBT.Text) Then
            tbCustomNBT.Text = "None"
        Else
            tbCustomNBT.Text = schemeContent(3)
        End If

        'Normal Item Checkbox
        normalItem = Convert.ToBoolean(schemeContent(4))
        cbNormalItem.Checked = normalItem

        'Suspicious Stew Checkbox
        suspiciousStew = Convert.ToBoolean(schemeContent(5))
        cbSuspiciousStew.Checked = suspiciousStew

        'Enchanted Book Checkbox
        enchantedBook = Convert.ToBoolean(schemeContent(6))
        cbEnchantedBook.Checked = enchantedBook

        'Potion Book Checkbox
        potion = Convert.ToBoolean(schemeContent(7))
        cbPotion.Checked = potion

        'Splash Potion Checkbox
        splashPotion = Convert.ToBoolean(schemeContent(8))
        cbSplashPotion.Checked = splashPotion

        'Lingering Potion Checkbox
        lingeringPotion = Convert.ToBoolean(schemeContent(9))
        cbLingeringPotion.Checked = lingeringPotion

        'Tipped Arrow Checkbox
        tippedArrow = Convert.ToBoolean(schemeContent(10))
        cbTippedArrow.Checked = tippedArrow

        'Goat Horn Checkbox
        goatHorn = Convert.ToBoolean(schemeContent(11))
        cbGoatHorn.Checked = goatHorn

        'Creative-Only Checkbox
        creativeOnly = Convert.ToBoolean(schemeContent(12))
        cbCreativeOnly.Checked = creativeOnly
        If creativeOnly = True Then
            'Spawn Egg Radiobutton
            spawnEgg = Convert.ToBoolean(schemeContent(13))
            rbtnSpawnEgg.Checked = spawnEgg

            'Command Block Radiobutton
            commandBlock = Convert.ToBoolean(schemeContent(14))
            rbtnCommandBlock.Checked = commandBlock

            'Other Creative-Only Item Radiobutton
            otherCreativeOnlyItem = Convert.ToBoolean(schemeContent(15))
            rbtnOtherItem.Checked = otherCreativeOnlyItem
        End If

        'Painting Checkbox
        painting = Convert.ToBoolean(schemeContent(16))
        cbPainting.Checked = painting

        'If ShowMessage is enabled, it will show a messagebox when loading completes.
        If showMessage Then
            MsgBox($"Loaded scheme {scheme}.", MsgBoxStyle.Information, "Loaded profile")
        End If
    End Sub

    Public Sub UpdateScheme(schemeName)
        'Save currently selected settings into Variables
        spawnEgg = rbtnSpawnEgg.Checked
        commandBlock = rbtnCommandBlock.Checked
        otherCreativeOnlyItem = rbtnOtherItem.Checked
        samePrefix = cbSamePrefix.Checked
        customNBT = cbCustomNBT.Checked
        normalItem = cbNormalItem.Checked
        suspiciousStew = cbSuspiciousStew.Checked
        enchantedBook = cbEnchantedBook.Checked
        potion = cbPotion.Checked
        splashPotion = cbSplashPotion.Checked
        lingeringPotion = cbLingeringPotion.Checked
        tippedArrow = cbTippedArrow.Checked
        goatHorn = cbGoatHorn.Checked
        creativeOnly = cbCreativeOnly.Checked
        painting = cbPainting.Checked

        If String.IsNullOrEmpty(tbSamePrefix.Text) Then
            samePrefixString = "minecraft"
        Else
            samePrefixString = tbSamePrefix.Text
        End If
        If String.IsNullOrEmpty(tbCustomNBT.Text) Then
            customNBTString = "None"
        Else
            customNBTString = tbCustomNBT.Text
        End If

        'Update the selected scheme. This will save and overwrite the selected scheme without showing any warning or message. Used if a profile is old or corrupted.
        If Not String.IsNullOrEmpty(schemeName) Then
            If My.Computer.FileSystem.DirectoryExists(schemeDirectory) Then
                My.Computer.FileSystem.WriteAllText($"{schemeDirectory}{schemeName}.txt", samePrefix.ToString + vbNewLine + samePrefixString + vbNewLine + customNBT.ToString + vbNewLine + customNBTString + vbNewLine + normalItem.ToString + vbNewLine + suspiciousStew.ToString + vbNewLine + enchantedBook.ToString + vbNewLine + potion.ToString + vbNewLine + splashPotion.ToString + vbNewLine + lingeringPotion.ToString + vbNewLine + tippedArrow.ToString + vbNewLine + goatHorn.ToString + vbNewLine + creativeOnly.ToString + vbNewLine + spawnEgg.ToString + vbNewLine + commandBlock.ToString + vbNewLine + otherCreativeOnlyItem.ToString + vbNewLine + painting.ToString + vbNewLine, False)
            Else
                MsgBox("Error: Couldn't update scheme. Scheme directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Error: Couldn't update scheme as the name is empty.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub


    Public Sub DetermineDatapackVersion()
        'Detect version of the datapack
        If My.Computer.FileSystem.DirectoryExists(tbDatapackPath.Text) Then

            'If the datapack contains a pack.mcmeta, read the line containing the version number and remove the unnecessary content to only show version number
            'Based on that number, it will set the datapack version. If the version is unknown, it will show a warning (Too old/too high)
            If My.Computer.FileSystem.FileExists($"{tbDatapackPath.Text}\pack.mcmeta") Then

                Dim versionString As String = File.ReadAllLines($"{tbDatapackPath.Text}\pack.mcmeta")(2)
                Dim parseVersion As String = Replace(versionString, "    " + Chr(34) + "pack_format" + Chr(34) + ": ", "")
                Dim version As Integer = Convert.ToInt32(Replace(parseVersion, ",", ""))

                Try
                    Select Case version
                        Case > 48
                            lblDatapackDetection.Text = "Detected datapack, but could not determine version"
                            MsgBox("A datapack has been detected but the pack format is greater than 48." + vbNewLine + "This means that the datapack is possibly newer than the software supports." + vbNewLine + "The newest available version in the software has been selected but is not guaranteed to work.", MsgBoxStyle.Exclamation, "Warning")
                            WriteToLog($"Detected unsupported datapack version. This may cause issues. (Pack format {version})", "Warning")
                            cbxVersion.SelectedItem = "Version 1.21"
                        Case 48
                            lblDatapackDetection.Text = "Detected datapack as version 1.21."
                            WriteToLog($"Detected datapack version 1.21 (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.21"
                        Case 42 To 47
                            lblDatapackDetection.Text = "Detected datapack as version 1.21 Snapshot."
                            WriteToLog($"Detected datapack version 1.21 Snapshot (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.21"
                        Case 41
                            lblDatapackDetection.Text = "Detected datapack as version 1.20.5 - 1.20.6."
                            WriteToLog($"Detected datapack version 1.20.5 - 1.20.6 (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.20.5 - 1.20.6"
                        Case 27 To 40
                            lblDatapackDetection.Text = "Detected datapack as version 1.20.5 - 1.20.6 Snapshot."
                            WriteToLog($"Detected datapack version 1.20.5 - 1.20.6 Snapshot (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.20.5 - 1.20.6"
                        Case 26
                            lblDatapackDetection.Text = "Detected datapack as version 1.20.3 - 1.20.4."
                            WriteToLog($"Detected datapack version 1.20.3 - 1.20.4 (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.20.2 - 1.20.4"
                        Case 19 To 25
                            lblDatapackDetection.Text = "Detected datapack as version 1.20.3 Snapshot."
                            WriteToLog($"Detected datapack version 1.20.3 Snapshot (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.20.2 - 1.20.4"
                        Case 18
                            lblDatapackDetection.Text = "Detected datapack as version 1.20.2."
                            WriteToLog($"Detected datapack version 1.20.2 (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.20.2 - 1.20.4"
                        Case 16 To 17
                            lblDatapackDetection.Text = "Detected datapack as version 1.20.2 Snapshot."
                            WriteToLog($"Detected datapack version 1.20.2 Snapshot (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.20.2 - 1.20.4"
                        Case 15
                            If My.Computer.FileSystem.FileExists($"{tbDatapackPath.Text}\updater.txt") Then
                                lblDatapackDetection.Text = "Detected datapack as version 1.20.1."
                                WriteToLog($"Detected datapack version 1.20.1 (Pack format {version})", "Info")
                                cbxVersion.SelectedItem = "Version 1.20.1"
                            Else
                                lblDatapackDetection.Text = "Detected datapack as version 1.20."
                                WriteToLog($"Detected datapack version 1.20 (Pack format {version})", "Info")
                                cbxVersion.SelectedItem = "Version 1.20"
                            End If
                        Case 13 To 14
                            lblDatapackDetection.Text = "Detected datapack as version 1.20 Snapshot."
                            WriteToLog($"Detected datapack version 1.20 Snapshot (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.20"
                        Case 12
                            lblDatapackDetection.Text = "Detected datapack as version 1.19.4."
                            WriteToLog($"Detected datapack version 1.19.4 (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.19.4"
                        Case 11
                            lblDatapackDetection.Text = "Detected datapack as version 1.19.4 Snapshot."
                            WriteToLog($"Detected datapack version 1.19.4 Snapshot (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.19.4"
                        Case 10
                            lblDatapackDetection.Text = "Detected datapack as version 1.19 - 1.19.3."
                            WriteToLog($"Detected datapack version 1.19 - 1.19.3 (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.19 - 1.19.3"
                        Case 9
                            lblDatapackDetection.Text = "Detected datapack as version 1.18.2."
                            WriteToLog($"Detected datapack version 1.18.2 (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.18 - 1.18.2"
                        Case 8
                            lblDatapackDetection.Text = "Detected datapack as version 1.18 - 1.18.1 (Outdated)"
                            WriteToLog($"Detected datapack version 1.18 - 1.18.1 (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.18 - 1.18.2"
                        Case 7
                            lblDatapackDetection.Text = "Detected datapack as version 1.17 - 1.17.1."
                            WriteToLog($"Detected datapack version 1.17 - 1.17.1 (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.17 - 1.17.1"
                        Case 6
                            lblDatapackDetection.Text = "Detected datapack as version 1.16.2 - 1.16.5."
                            WriteToLog($"Detected datapack version 1.16.2 - 1.16.5 (Pack format {version})", "Info")
                            cbxVersion.SelectedItem = "Version 1.16.2 - 1.16.5"
                        Case < 6
                            lblDatapackDetection.Text = "Detected datapack, but version is most likely unsupported"
                            MsgBox("A datapack has been detected but the pack format is smaller than 6." + vbNewLine + "This means that the datapack version is older than 1.15 which the Random Item Giver does not support." + vbNewLine + "The oldest available version has been selected but will most likely not work.", MsgBoxStyle.Exclamation, "Warning")
                            WriteToLog($"Detected unsupported datapack version. This may cause issues. (Pack format {version})", "Warning")
                            cbxVersion.SelectedItem = "Version 1.16.2 - 1.16.5"
                        Case Else
                            lblDatapackDetection.Text = "Detected datapack, but could not determine version."
                            WriteToLog("Detected datapack, but could not determine version.", "Error")
                    End Select

                    'Since Snapshot 24w21a, datapacks use a slightly different folder structure
                    If version >= 45 Then
                        datapackPathExtension = "\data\randomitemgiver\loot_table\"
                    Else
                        datapackPathExtension = "\data\randomitemgiver\loot_tables\"
                    End If
                Catch ex As Exception
                    MsgBox($"Error when selecting datapack: {ex.Message}", MsgBoxStyle.Critical, "Error")
                    lblDatapackDetection.Text = "Detected datapack, but could not determine version."
                    WriteToLog("Detected datapack, couldn't determine version.", "Error")
                    cbxVersion.SelectedItem = "Version 1.21"
                End Try
            Else
                lblDatapackDetection.Text = "Folder found, but could not detect datapack."
                WriteToLog("Couldn't detect datapack.", "Error")
            End If
        Else
            lblDatapackDetection.Text = "No datapack detected."
        End If

    End Sub

    Private Sub AddItem(itemID As String, itemAmount As Integer, version As String, lootTable As String)

        'If no duplicate has been detected or duplicates are simply ignored
        If duplicateDetected = False Or ignoreDuplicates = True Then

            'Empty the exception
            exceptionAddItem = ""

            'Set up item amount path
            Dim itemAmountPath As String = ""
            Select Case itemAmount
                Case 1
                    If version = "1.16" OrElse version = "1.18" OrElse version = "1.19" Then
                        itemAmountPath = "1item\"
                    ElseIf version = "1.20.1" OrElse version = "1.20.2" OrElse version = "1.20.5" Then
                        itemAmountPath = "01item\"
                    End If
                Case -1
                    itemAmountPath = "randomamountsameitem\"
                Case -2
                    itemAmountPath = "randomamountdifitems\"
                Case > 1
                    If (version = "1.20.1" OrElse version = "1.20.2" OrElse version = "1.20.5") And (itemAmount = 1 OrElse itemAmount = 2 OrElse itemAmount = 3 OrElse itemAmount = 5) Then
                        itemAmountPath = $"0{itemAmount}sameitems\"
                    Else
                        itemAmountPath = $"{itemAmount}sameitems\"
                    End If
            End Select

            'Check if the loot table exists and try to load it. If it fails, stop adding item.
            Dim file As String = ""
            Try
                If My.Computer.FileSystem.FileExists($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json") Then
                    file = My.Computer.FileSystem.ReadAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json")
                End If
            Catch ex As Exception
                WriteToLog($"Could not add item {itemID} to loot table {lootTable} for amount {itemAmount} and version {version}. {ex.Message}", "Error")
                Return
            End Try

            'Item attributes
            Dim nbtTag As String = ""
            Dim itemStackComponent = ""
            Dim prefix As String = ""
            Dim fullItemName As String = ""

            'If the item you want to add does not exist or duplicates are ignored add items depending on version and loot table
            If file.Contains("""fullItemName""") = False Or ignoreDuplicates = True Then
                Try

                    'Set custom NTB tag and prefix
                    If version = "1.20.5" Then
                        If customNBT = True Then
                            itemStackComponent = customNBTString
                        Else
                            itemStackComponent = "NONE"
                        End If
                    Else
                        If customNBT = True Then
                            nbtTag = customNBTString.Replace("""", "\""") 'Fix quotiation marks in NBT tags
                        Else
                            nbtTag = "NONE"
                        End If
                    End If

                    'Determine the full item name based on the item ID
                    If samePrefix = True Then
                        prefix = samePrefixString
                        fullItemName = $"{prefix}:{itemID}"
                    Else
                        fullItemName = itemID
                    End If

                    'Set up item construct and item amount path based on item amount
                    Dim itemConstruct As String = ""
                    Select Case itemAmount
                        Case 2
                            itemConstruct = items02
                        Case 3
                            itemConstruct = items03
                        Case 5
                            itemConstruct = items05
                        Case 10
                            itemConstruct = items10
                        Case 32
                            itemConstruct = items32
                        Case 64
                            itemConstruct = items64
                        Case -1
                            If version = "1.20.2" OrElse version = "1.20.1" OrElse version = "1.20.5" Then
                                itemConstruct = randomAmountSameItem1_20_2
                            ElseIf version = "1.19" Then
                                itemConstruct = randomAmountSameItem1_19
                            ElseIf version = "1.16" Then
                                itemConstruct = randomAmountSameItem1_16
                            End If
                    End Select

                    'Version 1.20.2
                    If version = "1.20.5" Then

                        'Remove the last few lines to allow for new items to be added
                        Dim bracketCount As Integer = 0
                        Dim editFileLines As List(Of String) = IO.File.ReadAllLines($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json").ToList()

                        Dim line As Integer = editFileLines.Count - 1
                        While bracketCount < 5
                            If editFileLines(line).Contains("}") OrElse editFileLines(line).Contains("]") Then
                                bracketCount += 1
                            End If

                            editFileLines.Remove(editFileLines(line))
                            line -= 1
                        End While
                        IO.File.WriteAllLines($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json", editFileLines)

                        'Add the item based on item amount
                        If itemAmount = 1 OrElse itemAmount = -2 Then

                            'Add the item to the corresponding loot table
                            If Not cbCustomNBT.Checked Then
                                My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json",
                                                                    "        }," + vbNewLine +
                                                                    "        {" + vbNewLine +
                                                                    "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                    $"          ""name"": ""{fullItemName}""" + vbNewLine +
                                                                    endPart, True)
                            ElseIf cbCustomNBT.Checked Then
                                My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json",
                                                                    "        }," + vbNewLine +
                                                                    "        {" + vbNewLine +
                                                                    "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                    $"          ""name"": ""{fullItemName}""," + vbNewLine +
                                                                    "                    ""functions"": [" + vbNewLine +
                                                                    "                        {" + vbNewLine +
                                                                    "                            ""function"": ""set_components""," + vbNewLine +
                                                                    "                            ""components"": {" + vbNewLine +
                                                                    itemStackComponent + vbNewLine +
                                                                    "                           }" + vbNewLine +
                                                                    "                        }" + vbNewLine +
                                                                    "                    ]" + vbNewLine +
                                                                    endPart, True)
                            End If
                        Else
                            'Add the item to the corresponding loot table
                            If Not cbCustomNBT.Checked Then
                                My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json",
                                                                    "        }," + vbNewLine +
                                                                    "        {" + vbNewLine +
                                                                    "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                    $"          ""name"": ""{fullItemName}""," + vbNewLine +
                                                                    itemConstruct + vbNewLine +
                                                                    "          ]" + vbNewLine +
                                                                    endPart, True)
                            ElseIf cbCustomNBT.Checked Then
                                My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json",
                                                                    "        }," + vbNewLine +
                                                                    "        {" + vbNewLine +
                                                                    "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                    $"          ""name"": ""{fullItemName}""," + vbNewLine +
                                                                    $"{itemConstruct}," + vbNewLine +
                                                                    "                        {" + vbNewLine +
                                                                    "                            ""function"": ""set_components""," + vbNewLine +
                                                                    "                            ""components"": {" + vbNewLine +
                                                                    itemStackComponent + vbNewLine +
                                                                    "                           }" + vbNewLine +
                                                                    "                        }" + vbNewLine +
                                                                    "                    ]" + vbNewLine +
                                                                    endPart, True)
                            End If
                        End If

                        'Version 1.20.2
                    ElseIf version = "1.20.2" Then

                        'Remove the last few lines to allow for new items to be added
                        Dim bracketCount As Integer = 0
                        Dim editFileLines As List(Of String) = New List(Of String)
                        Using reader As New StreamReader($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json")
                            While Not reader.EndOfStream
                                Dim l As String = reader.ReadLine()
                                editFileLines.Add(l)
                            End While
                        End Using

                        Dim line As Integer = editFileLines.Count - 1
                        While bracketCount < 5
                            If editFileLines(line).Contains("}") OrElse editFileLines(line).Contains("]") Then
                                bracketCount += 1
                            End If

                            editFileLines.Remove(editFileLines(line))
                            line -= 1
                        End While
                        IO.File.WriteAllLines($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json", editFileLines)

                        'Add the item based on item amount
                        If itemAmount = 1 OrElse itemAmount = -2 Then

                            'Add the item to the corresponding loot table
                            If (lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And Not cbCustomNBT.Checked Then
                                My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json",
                                                                    "        }," + vbNewLine +
                                                                    "        {" + vbNewLine +
                                                                    "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                    $"          ""name"": ""{fullItemName}""" + vbNewLine +
                                                                    endPart, True)
                            ElseIf ((lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json",
                                                                    "        }," + vbNewLine +
                                                                    "        {" + vbNewLine +
                                                                    "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                    $"          ""name"": ""{fullItemName}""," + vbNewLine +
                                                                    "                    ""functions"": [" + vbNewLine +
                                                                    "                        {" + vbNewLine +
                                                                    "                            ""function"": ""set_nbt""," + vbNewLine +
                                                                    $"                            ""tag"": ""{nbtTag}""" + vbNewLine +
                                                                    "                        }" + vbNewLine +
                                                                    "                    ]" + vbNewLine +
                                                                    endPart, True)
                            End If
                        Else
                            'Add the item to the corresponding loot table
                            If (lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json",
                                                                    "        }," + vbNewLine +
                                                                    "        {" + vbNewLine +
                                                                    "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                    $"          ""name"": ""{fullItemName}""," + vbNewLine +
                                                                    itemConstruct + vbNewLine +
                                                                    "          ]" + vbNewLine +
                                                                    endPart, True)
                            ElseIf ((lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json",
                                                                    "        }," + vbNewLine +
                                                                    "        {" + vbNewLine +
                                                                    "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                    $"          ""name"": ""{fullItemName}""," + vbNewLine +
                                                                    $"{itemConstruct}," + vbNewLine +
                                                                    "                        {" + vbNewLine +
                                                                    "                            ""function"": ""set_nbt""," + vbNewLine +
                                                                    $"                            ""tag"": ""{nbtTag}""" + vbNewLine +
                                                                    "                        }" + vbNewLine +
                                                                    "                    ]" + vbNewLine +
                                                                    endPart, True)
                            End If

                        End If

                    ElseIf version = "1.16" Or version = "1.18" Or version = "1.19" Or version = "1.20.1" Then

                        'Remove the last few lines to allow for new items to be added
                        Dim bracketCount As Integer = 0
                        Dim editFileLines As List(Of String) = New List(Of String)
                        Using reader As New StreamReader($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json")
                            While Not reader.EndOfStream
                                Dim l As String = reader.ReadLine()
                                editFileLines.Add(l)
                            End While
                        End Using

                        Dim line As Integer = editFileLines.Count - 1
                        While bracketCount < 5
                            If editFileLines(line).Contains("}") OrElse editFileLines(line).Contains("]") Then
                                bracketCount += 1
                            End If

                            editFileLines.Remove(editFileLines(line))
                            line -= 1
                        End While
                        IO.File.WriteAllLines($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json", editFileLines)

                        'Remove the items from the specific loot tables
                        If itemAmount = 1 OrElse itemAmount = -2 Then
                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json",
                                                                   "        }," + vbNewLine +
                                                                    "        {" + vbNewLine +
                                                                    "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                    $"          ""name"": ""{fullItemName}""" + vbNewLine +
                                                                    endPart, True)
                            ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json",
                                                                    "        }," + vbNewLine +
                                                                    "        {" + vbNewLine +
                                                                    "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                    $"          ""name"": ""{fullItemName}""," + vbNewLine +
                                                                    "                    ""functions"": [" + vbNewLine +
                                                                    "                        {" + vbNewLine +
                                                                    "                            ""function"": ""set_nbt""," + vbNewLine +
                                                                    $"                            ""tag"": ""{nbtTag}""" + vbNewLine +
                                                                    "                        }" + vbNewLine +
                                                                    "                    ]" + vbNewLine +
                                                                    endPart, True)
                            End If
                        Else

                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json",
                                                                    "        }," + vbNewLine +
                                                                    "        {" + vbNewLine +
                                                                    "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                    $"          ""name"": ""{fullItemName}""," + vbNewLine +
                                                                    itemConstruct + vbNewLine +
                                                                    "          ]" + vbNewLine +
                                                                    endPart, True)
                            ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json",
                                                                    "        }," + vbNewLine +
                                                                    "        {" + vbNewLine +
                                                                    "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                    $"          ""name"": ""{fullItemName}""," + vbNewLine +
                                                                    $"{itemConstruct}," + vbNewLine +
                                                                    "                        {" + vbNewLine +
                                                                    "                            ""function"": ""set_nbt""," + vbNewLine +
                                                                    $"                            ""tag"": ""{nbtTag}""" + vbNewLine +
                                                                    "                        }" + vbNewLine +
                                                                    "                    ]" + vbNewLine +
                                                                    endPart, True)
                            End If
                        End If
                    ElseIf version = "1.17" Then
                        'Convert Settings to 1.17 RIG format
                        If lootTable = "potions" Then
                            lootTable = "potion"
                        End If
                        If lootTable = "splash_potions" Then
                            lootTable = "splash_potion"
                        End If
                        If lootTable = "lingering_potions" Then
                            lootTable = "lingering_potion"
                        End If
                        If lootTable = "suspicious_stews" Then
                            lootTable = "suspicious_stew"
                        End If
                        If lootTable = "tipped_arrows" Then
                            lootTable = "tipped_arrow"
                        End If

                        'Remove the last few lines to allow for new items to be added
                        Dim bracketCount As Integer = 0
                        Dim editFileLines As List(Of String) = New List(Of String)
                        Using reader As New StreamReader($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json")
                            While Not reader.EndOfStream
                                Dim l As String = reader.ReadLine()
                                editFileLines.Add(l)
                            End While
                        End Using

                        Dim line As Integer = editFileLines.Count - 1
                        While bracketCount < 5
                            If editFileLines(line).Contains("}") OrElse editFileLines(line).Contains("]") Then
                                bracketCount += 1
                            End If

                            editFileLines.Remove(editFileLines(line))
                            line -= 1
                        End While
                        IO.File.WriteAllLines($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json", editFileLines)

                        'Add the item to the corresponding loot table
                        If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                            My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{lootTable}.json",
                                                               "        }," + vbNewLine +
                                                                "        {" + vbNewLine +
                                                                "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                $"          ""name"": ""{fullItemName}""" + vbNewLine +
                                                                endPart, True)
                        ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stew" OrElse lootTable = "enchanted_books" OrElse lootTable = "potion" OrElse lootTable = "splash_potion" OrElse lootTable = "lingering_potion" OrElse lootTable = "tipped_arrow") Then
                            My.Computer.FileSystem.WriteAllText($"{datapackPath}{datapackPathExtension}{lootTable}.json",
                                                                "        }," + vbNewLine +
                                                                "        {" + vbNewLine +
                                                                "          ""type"": ""minecraft:item""," + vbNewLine +
                                                                $"          ""name"": ""{fullItemName}""," + vbNewLine +
                                                                "                    ""functions"": [" + vbNewLine +
                                                                "                        {" + vbNewLine +
                                                                "                            ""function"": ""set_nbt""," + vbNewLine +
                                                                $"                            ""tag"": ""{nbtTag}""" + vbNewLine +
                                                                "                        }" + vbNewLine +
                                                                "                    ]" + vbNewLine +
                                                                endPart, True)
                        End If
                    End If

                    'The software sometimes sneaks in additional brackets that shouldn't be there - I couldn't figure out why, so here's a temporary fix
                    Dim fileLines As List(Of String) = IO.File.ReadAllLines($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json").ToList()
                    Dim removalFileLines As List(Of Integer) = New List(Of Integer)

                    For i As Integer = 0 To fileLines.Count - 1
                        If i + 3 <= fileLines.Count - 1 Then
                            If fileLines(i).Contains("}") And fileLines(i + 1).Contains("},") And fileLines(i + 2).Contains("{") And fileLines(i + 3).Contains("""type""") Then
                                removalFileLines.Add(i)
                            End If
                        End If
                    Next

                    For Each i As Integer In removalFileLines
                        fileLines.RemoveAt(i)
                    Next
                    IO.File.WriteAllLines($"{datapackPath}{datapackPathExtension}{itemAmountPath}{lootTable}.json", fileLines)

                Catch ex As Exception
                    exceptionAddItem = ex.Message
                    addItemResult = "error"
                End Try

                'If not exception was found show completion message, otherwise show exception
                If String.IsNullOrEmpty(exceptionAddItem) Then
                    output = $"Succesfully added {fullItemName} to selected loot tables in Version {version} (NBT: {nbtTag})"
                Else
                    output = $"Error: {exceptionAddItem}"
                End If
                exceptionAddItem = ""

            Else
                'If duplicate exists show option to either ignore it or cancel 
                Select Case MsgBox($"The item you are trying To add ({fullItemName}) already exists In the datapack.{vbNewLine}Are you sure you want To add it again? This will result In duplicates.", vbExclamation + vbYesNo, "Warning")
                    Case Windows.Forms.DialogResult.Yes
                        ignoreDuplicates = True
                        AddItem(itemID, itemAmount, version, lootTable)
                    Case Windows.Forms.DialogResult.No
                        ignoreDuplicates = False
                        duplicateDetected = True
                        output = $"Cancelled adding {fullItemName} To {lootTable} In Version {version} (NBT: {nbtTag})"
                        totalDuplicatesIgnored += 1
                End Select
            End If
        End If
    End Sub

    'Returns an Array as a string
    Public Function ReturnArrayAsString(sourceArray As String())
        Dim FullString As String = ""
        For Each line As String In sourceArray
            FullString = FullString + line + vbNewLine
        Next
        FullString = FullString.Remove(FullString.Length - 2)
        Return FullString
    End Function

    'Returns a List as a string
    Public Function ReturnListAsString(sourceList As List(Of String))
        Dim FullString As String = ""
        For Each line As String In sourceList
            FullString = FullString + line + vbNewLine
        Next
        FullString = FullString.Remove(FullString.Length - 2)
        Return FullString
    End Function

    Private Sub InitializeLoadingSettings()
        If My.Computer.FileSystem.FileExists(settingsFile) Then
            Try
                'Try to load settings and determine version
                settingsArray = File.ReadAllLines(settingsFile)
                loadedSettingsVersion = settingsArray(1).Replace("Version=", "")
                WriteToLog($"Found settings version {loadedSettingsVersion}", "Info")

                'Resize array so all settings can fit in it (Array size = Amount of lines that the settings file should have)
                ReDim Preserve settingsArray(22)
                ConvertSettings(settingsFile)
            Catch ex As Exception
                MsgBox($"Error when loading settings: {ex.Message}", MsgBoxStyle.Critical, "Error")
                WriteToLog($"Error when loading settings: {ex.Message}", "Error")
            End Try

        Else
            'Show error and create new settings file if none exists
            WriteToLog($"Could not find settings file. Creating a new one (Version {settingsVersion}).", "Warning")
            My.Computer.FileSystem.WriteAllText(settingsFile, "", False)
            frmSettings.SaveSettings(settingsFile)
        End If

        'Check if log directory exists and create it if not
        If My.Computer.FileSystem.DirectoryExists(logDirectory) = False Then
            My.Computer.FileSystem.CreateDirectory(logDirectory)
        End If
    End Sub

    Public Sub ConvertSettings(file As String)
        'This checks if the settings file that was loaded has enough lines, too few lines would mean that settings are missing, meaning the file is either too old or corrupted.
        'It will check for each required line if it is empty (required lines = the length of a healthy, normal profile file). Make sure that the line amount it checks matches the amount of settings that are being saved.
        'If a line is empty, it will fill that line with a placeholder in the array so the settings can get loaded without errors. After loading the settings, it gets automatically saved so the corrupted/old settings file gets fixed.
        'If no required line is empty and the file is fine, it will just load the profile like normal.
        If SettingsFaulty() = True Then
            Select Case MsgBox("You are trying to load settings from an older/newer version or your settings are corrupted. You need to fix them in order to load them. You usually won't lose any settings. Do you want to continue?", vbQuestion + vbYesNo, "Load old or corrupted profile")
                Case Windows.Forms.DialogResult.Yes
                    WriteToLog("Converting settings to newer version...", "Info")
                    'Change version to the newest one to avoid further detections
                    settingsArray(1) = frmSettings.SettingsFilePreset.Lines(1)
                    'Check every line. If the line doesnt match any of the possible options, enter the default value
                    If (settingsArray(0) = "#Random Item Giver Updater Legacy Settings File") = False Then
                        settingsArray(0) = frmSettings.SettingsFilePreset.Lines(0)
                    End If
                    If (settingsArray(2) = "/") = False Then
                        settingsArray(2) = frmSettings.SettingsFilePreset.Lines(2)
                    End If
                    If (settingsArray(3) = "#General1") = False Then
                        settingsArray(3) = frmSettings.SettingsFilePreset.Lines(3)
                    End If
                    If ((settingsArray(4) = "UseAdvancedViewByDefault=True" = False And settingsArray(4) = "UseAdancedViewByDefault=False")) = False Then
                        settingsArray(4) = frmSettings.SettingsFilePreset.Lines(4)
                    End If
                    If ((settingsArray(5) = "AutoSaveLogs=True" = False And settingsArray(5) = "AutoSaveLogs=False")) = False Then
                        settingsArray(5) = frmSettings.SettingsFilePreset.Lines(5)
                    End If
                    If ((settingsArray(6) = "Design=Light" = False And settingsArray(6) = "Design=Dark" And settingsArray(6) = "Design=System Default")) = False Then
                        settingsArray(6) = frmSettings.SettingsFilePreset.Lines(6)
                    End If
                    If (settingsArray(7) = "/") = False Then
                        settingsArray(7) = frmSettings.SettingsFilePreset.Lines(7)
                    End If
                    If (settingsArray(8) = "#General2") = False Then
                        settingsArray(8) = frmSettings.SettingsFilePreset.Lines(8)
                    End If
                    If ((settingsArray(9) = "DisableLogging=True" = False And settingsArray(9) = "DisableLogging=False" = False)) Then
                        settingsArray(9) = frmSettings.SettingsFilePreset.Lines(9)
                    End If
                    If ((settingsArray(10) = "HideLegacyWarning=True" = False And settingsArray(10) = "HideLegacyWarning=False" = False)) Then
                        settingsArray(10) = frmSettings.SettingsFilePreset.Lines(10)
                    End If
                    If (settingsArray(11) = "/") = False Then
                        settingsArray(11) = frmSettings.SettingsFilePreset.Lines(11)
                    End If
                    If (settingsArray(12) = "#Datapack Profiles") = False Then
                        settingsArray(12) = frmSettings.SettingsFilePreset.Lines(12)
                    End If
                    If ((settingsArray(13) = "LoadDefaultProfile=True" = False And settingsArray(13) = "LoadDefaultProfile=False" = False)) Then
                        settingsArray(13) = frmSettings.SettingsFilePreset.Lines(13)
                    End If
                    If String.IsNullOrEmpty(settingsArray(14)) Then
                        settingsArray(14) = frmSettings.SettingsFilePreset.Lines(14)
                    End If
                    If (settingsArray(15) = "/") = False Then
                        settingsArray(15) = frmSettings.SettingsFilePreset.Lines(15)
                    End If
                    If (settingsArray(16) = "#Schemes") = False Then
                        settingsArray(16) = frmSettings.SettingsFilePreset.Lines(16)
                    End If
                    If (settingsArray(17) = "SelectDefaultScheme=True" = False And settingsArray(17) = "SelectDefaultScheme=False" = False) Then
                        settingsArray(17) = frmSettings.SettingsFilePreset.Lines(17)
                    End If
                    If String.IsNullOrEmpty(settingsArray(16)) Then
                        settingsArray(18) = frmSettings.SettingsFilePreset.Lines(18)
                    End If
                    If (settingsArray(19) = "/") = False Then
                        settingsArray(19) = frmSettings.SettingsFilePreset.Lines(19)
                    End If
                    If (settingsArray(20) = "#Item List Importer") = False Then
                        settingsArray(20) = frmSettings.SettingsFilePreset.Lines(20)
                    End If
                    If ((settingsArray(21) = "DontImportVanillaItemsByDefault=True") = False And (settingsArray(21) = "DontImportVanillaItemsByDefault=False") = False) Then
                        settingsArray(21) = frmSettings.SettingsFilePreset.Lines(21)
                    End If
                    System.IO.File.WriteAllLines(settingsFile, settingsArray)
                    LoadSettings()
                    MsgBox("Loaded and converted settings. They should now work correctly!", MsgBoxStyle.Information, "Loaded and updated profile")
                    WriteToLog("Loaded and converted settings.", "Info")
                Case Windows.Forms.DialogResult.No
                    WriteToLog("Ignored settings from newer version. Creating new file, current one will be renamed to settings.old", "Info")
                    My.Computer.FileSystem.RenameFile(settingsFile, "settings.old")
                    My.Computer.FileSystem.WriteAllText(settingsFile, "", False)
                    frmSettings.ResetSettings(settingsFile)
                    LoadSettings()
            End Select
        Else
            LoadSettings()
        End If
    End Sub

    Public Function SettingsFaulty() As Boolean
        'Checks if the settings that are loaded are faulty
        If (settingsArray(0) = "#Random Item Giver Updater Legacy Settings File") = False Then
            Return True
        ElseIf (settingsArray(1) = "Version=" + settingsVersion.ToString) = False Then
            Return True
        ElseIf (settingsArray(2) = "/") = False Then
            Return True
        ElseIf (settingsArray(3) = "#General1") = False Then
            Return True
        ElseIf ((settingsArray(4) = "UseAdvancedViewByDefault=True" = False And settingsArray(4) = "UseAdvancedViewByDefault=False" = False)) Then
            Return True
        ElseIf ((settingsArray(5) = "AutoSaveLogs=True" = False And settingsArray(5) = "AutoSaveLogs=False" = False)) Then
            Return True
        ElseIf ((settingsArray(6) = "Design=Light" = False And settingsArray(6) = "Design=Dark" = False And settingsArray(6) = "Design=System Default" = False)) Then
            Return True
        ElseIf (settingsArray(7) = "/") = False Then
            Return True
        ElseIf (settingsArray(8) = "#General2") = False Then
            Return True
        ElseIf ((settingsArray(9) = "DisableLogging=True" = False And settingsArray(9) = "DisableLogging=False" = False)) Then
            Return True
        ElseIf ((settingsArray(10) = "HideLegacyWarning=True" = False And settingsArray(10) = "HideLegacyWarning=False" = False)) Then
            Return True
        ElseIf (settingsArray(11) = "/") = False Then
            Return True
        ElseIf (settingsArray(12) = "#Datapack Profiles") = False Then
            Return True
        ElseIf ((settingsArray(13) = "LoadDefaultProfile=True" = False And settingsArray(13) = "LoadDefaultProfile=False" = False)) Then
            Return True
        ElseIf String.IsNullOrEmpty(settingsArray(14)) Then
            Return True
        ElseIf (settingsArray(15) = "/") = False Then
            Return True
        ElseIf (settingsArray(16) = "#Schemes") = False Then
            Return True
        ElseIf ((settingsArray(17) = "SelectDefaultScheme=True" = False And settingsArray(17) = "SelectDefaultScheme=False" = False)) Then
            Return True
        ElseIf String.IsNullOrEmpty(settingsArray(18)) Then
            Return True
        ElseIf (settingsArray(19) = "/") = False Then
            Return True
        ElseIf (settingsArray(20) = "#Item List Importer") = False Then
            Return True
        ElseIf ((settingsArray(21) = "DontImportVanillaItemsByDefault=True" = False And settingsArray(21) = "DontImportVanillaItemsByDefault=False" = False)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub LoadSettings()
        WriteToLog("Loading settings...", "Info")

        Try

            'Load general 1 settings
            My.Settings.UseAdvancedViewByDefault = Convert.ToBoolean(settingsArray(4).Replace("UseAdvancedViewByDefault=", ""))
            WriteToLog("Loaded setting " + settingsArray(4), "Info")
            My.Settings.AutoSaveLogs = Convert.ToBoolean(settingsArray(5).Replace("AutoSaveLogs=", ""))
            WriteToLog("Loaded setting " + settingsArray(5), "Info")
            My.Settings.Design = settingsArray(6).Replace("Design=", "")
            WriteToLog("Loaded setting " + settingsArray(6), "Info")

            'Load general 2 settings
            My.Settings.DisableLogging = Convert.ToBoolean(settingsArray(9).Replace("DisableLogging=", ""))
            WriteToLog("Loaded setting " + settingsArray(9), "Info")
            My.Settings.HideLegacyWarning = Convert.ToBoolean(settingsArray(10).Replace("HideLegacyWarning=", ""))
            WriteToLog("Loaded setting " + settingsArray(10), "Info")

            'Load datapack profiles settings
            My.Settings.LoadDefaultProfile = Convert.ToBoolean(settingsArray(13).Replace("LoadDefaultProfile=", ""))
            WriteToLog("Loaded setting " + settingsArray(13), "Info")
            My.Settings.DefaultProfile = settingsArray(14).Replace("DefaultProfile=", "")
            WriteToLog("Loaded setting " + settingsArray(14), "Info")

            'Load scheme settings
            My.Settings.SelectDefaultScheme = Convert.ToBoolean(settingsArray(17).Replace("SelectDefaultScheme=", ""))
            WriteToLog("Loaded setting " + settingsArray(17), "Info")
            My.Settings.DefaultScheme = settingsArray(18).Replace("DefaultScheme=", "")
            WriteToLog("Loaded setting " + settingsArray(18), "Info")

            'Load Item List Importer Settings
            My.Settings.DontImportVanillaItemsByDefault = Convert.ToBoolean(settingsArray(21).Replace("DontImportVanillaItemsByDefault=", ""))
            WriteToLog("Loaded setting " + settingsArray(21), "Info")

        Catch ex As Exception

            MsgBox($"Could not load settings: {ex.Message}", MsgBoxStyle.Critical, "Error")
            WriteToLog($"Could not load settings: {ex.Message}", "Error")

            'If loading settings failed, show an option to reset settings
            Select Case MsgBox("An error occured while loading your settings. " + vbNewLine + "Do you want to reset your settings? This probably fixes the problem.", vbCritical + vbYesNo, "Error")
                Case Windows.Forms.DialogResult.Yes
                    My.Computer.FileSystem.WriteAllText(settingsFile, "", False)
                    frmSettings.SaveSettings(settingsFile)
                    MsgBox("Successfully reset your settings!" + vbNewLine + "Please restart the application for changes to take affect.", MsgBoxStyle.Information, "Reset settings")
                    WriteToLog("Successfully reset settings!", "Info")
                    Close()
            End Select

        End Try
    End Sub

    Private Sub EnableAdvancedView()
        'Show more options for selecting loot table, prefix and schemes
        cbNormalItem.Show()
        cbSuspiciousStew.Show()
        cbEnchantedBook.Show()
        cbPotion.Show()
        cbSplashPotion.Show()
        cbLingeringPotion.Show()
        cbTippedArrow.Show()
        cbGoatHorn.Show()
        cbSamePrefix.Show()
        tbSamePrefix.Show()
        btnOverwriteSelectedScheme.Show()
        btnSaveAsNewScheme.Show()
        btnDeleteSelectedScheme.Show()
        cbPainting.Show()
        btnRenameScheme.Show()

        'Change position and dimensions of some controls
        cbEnableAdvancedView.Top = 677
        cbEnableAdvancedView.Left = 42
        cbAddItemsFast.Top = 651
        cbAddItemsFast.Left = 42
        Width = 735
        Height = 847
        gbItemID.Height = 140
        gbItemID.Width = 259
    End Sub

    Private Sub DisableAdvancedView()
        'Hide advanced options for selecting loot table, prefix and schemes
        cbNormalItem.Hide()
        cbSuspiciousStew.Hide()
        cbEnchantedBook.Hide()
        cbPotion.Hide()
        cbSplashPotion.Hide()
        cbLingeringPotion.Hide()
        cbTippedArrow.Hide()
        cbGoatHorn.Hide()
        cbSamePrefix.Hide()
        tbSamePrefix.Hide()
        btnOverwriteSelectedScheme.Hide()
        btnSaveAsNewScheme.Hide()
        btnDeleteSelectedScheme.Hide()
        cbPainting.Hide()
        btnRenameScheme.Hide()

        cbAddItemsFast.Top = 532
        cbAddItemsFast.Left = 320
        cbEnableAdvancedView.Top = 560
        cbEnableAdvancedView.Left = 320
        Width = 735
        Height = 732
        gbItemID.Height = 140
        gbItemID.Width = 429
    End Sub

    Private Sub BeginAddingItems()
        'Add all items in the textbox line by line
        For Each line As String In itemsList
            ignoreDuplicates = False
            duplicateDetected = False
            item = line
            CallAddItem()
        Next
    End Sub

    Private Sub CallAddItem()

        'Disable the creative-only options if 'creative-only' is generally disabled
        If Not creativeOnly Then
            commandBlock = False
            otherCreativeOnlyItem = False
            spawnEgg = False
        End If

        'Beginn adding items for the specific version if string is not empty
        If String.IsNullOrEmpty(item) = False Then

            If datapackVersion = "Version 1.16.2 - 1.16.5" Then

                Dim ItemAmount As Integer = 1

                'Go through all the loot tables
                For i As Integer = 1 To 9

                    'Add the item to all the loot tables
                    If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                        AddItem(item, ItemAmount, "1.16", "main")
                    End If
                    If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "main_without_creative-only")
                    End If
                    If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "special_vxx")
                    End If
                    If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "special_vvx")
                    End If
                    If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "special_xvx")
                    End If
                    If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "special_xvv")
                    End If
                    If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "special_xxv")
                    End If
                    If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "special_vxv")
                    End If
                    If suspiciousStew And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "suspicious_stews")
                    End If
                    If enchantedBook And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "enchanted_books")
                    End If
                    If potion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "potions")
                    End If
                    If splashPotion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "splash_potions")
                    End If
                    If lingeringPotion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "lingering_potions")
                    End If
                    If tippedArrow And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.16", "tipped_arrows")
                    End If

                    'Select the new item amount based on the old one
                    Select Case ItemAmount
                        Case 1
                            ItemAmount = 2
                        Case 2
                            ItemAmount = 3
                        Case 3
                            ItemAmount = 5
                        Case 5
                            ItemAmount = 10
                        Case 10
                            ItemAmount = 32
                        Case 32
                            ItemAmount = 64
                        Case 64
                            ItemAmount = -1
                        Case -1
                            ItemAmount = -2
                    End Select
                Next

            ElseIf datapackVersion = "Version 1.17 - 1.17.1" Then

                Dim ItemAmount As Integer = 1

                'Add the item to all the loot tables
                If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                    AddItem(item, ItemAmount, "1.17", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, ItemAmount, "1.17", "tipped_arrows")
                End If


            ElseIf datapackVersion = "Version 1.18 - 1.18.2" Then

                Dim ItemAmount As Integer = 1

                'Go through all the loot tables
                For i As Integer = 1 To 7

                    'Add the item to all the loot tables
                    If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                        AddItem(item, ItemAmount, "1.18", "main")
                    End If
                    If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "main_without_creative-only")
                    End If
                    If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "special_vxx")
                    End If
                    If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "special_vvx")
                    End If
                    If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "special_xvx")
                    End If
                    If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "special_xvv")
                    End If
                    If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "special_xxv")
                    End If
                    If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "special_vxv")
                    End If
                    If suspiciousStew And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "suspicious_stews")
                    End If
                    If enchantedBook And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "enchanted_books")
                    End If
                    If potion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "potions")
                    End If
                    If splashPotion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "splash_potions")
                    End If
                    If lingeringPotion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "lingering_potions")
                    End If
                    If tippedArrow And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.18", "tipped_arrows")
                    End If

                    'Select the new item amount based on the old one
                    Select Case ItemAmount
                        Case 1
                            ItemAmount = 2
                        Case 2
                            ItemAmount = 3
                        Case 3
                            ItemAmount = 5
                        Case 5
                            ItemAmount = 10
                        Case 10
                            ItemAmount = 32
                        Case 32
                            ItemAmount = 64
                    End Select
                Next

            ElseIf datapackVersion = "Version 1.19 - 1.19.3" OrElse datapackVersion = "Version 1.19.4" OrElse datapackVersion = "Version 1.20" Then

                Dim ItemAmount As Integer = 1

                'Go through all the loot tables
                For i As Integer = 1 To 9

                    'Add the item to all the loot tables
                    If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                        AddItem(item, ItemAmount, "1.19", "main")
                    End If
                    If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "main_without_creative-only")
                    End If
                    If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "special_vxx")
                    End If
                    If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "special_vvx")
                    End If
                    If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "special_xvx")
                    End If
                    If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "special_xvv")
                    End If
                    If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "special_xxv")
                    End If
                    If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "special_vxv")
                    End If
                    If suspiciousStew And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "suspicious_stews")
                    End If
                    If enchantedBook And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "enchanted_books")
                    End If
                    If potion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "potions")
                    End If
                    If splashPotion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "splash_potions")
                    End If
                    If lingeringPotion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "lingering_potions")
                    End If
                    If tippedArrow And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "tipped_arrows")
                    End If
                    If goatHorn And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.19", "goat_horns")
                    End If
                    If datapackVersion = "Version 1.19.4" OrElse datapackVersion = "Version 1.20" Then
                        If painting And itemAddMode = "Normal" Then
                            AddItem(item, ItemAmount, "1.19", "paintings")
                        End If
                    End If

                    'Select the new item amount based on the old one
                    Select Case ItemAmount
                        Case 1
                            ItemAmount = 2
                        Case 2
                            ItemAmount = 3
                        Case 3
                            ItemAmount = 5
                        Case 5
                            ItemAmount = 10
                        Case 10
                            ItemAmount = 32
                        Case 32
                            ItemAmount = 64
                        Case 64
                            ItemAmount = -1
                        Case -1
                            ItemAmount = -2
                    End Select
                Next


            ElseIf datapackVersion = "Version 1.20.1" Then
                Dim ItemAmount As Integer = 1

                'Go through all the loot tables
                For i As Integer = 1 To 9

                    'Add the item to all the loot tables
                    If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                        AddItem(item, ItemAmount, "1.20.1", "main")
                    End If
                    If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "main_without_creative-only")
                    End If
                    If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "special_vxx")
                    End If
                    If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "special_vvx")
                    End If
                    If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "special_xvx")
                    End If
                    If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "special_xvv")
                    End If
                    If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "special_xxv")
                    End If
                    If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "special_vxv")
                    End If
                    If suspiciousStew And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "suspicious_stews")
                    End If
                    If enchantedBook And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "enchanted_books")
                    End If
                    If potion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "potions")
                    End If
                    If splashPotion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "splash_potions")
                    End If
                    If lingeringPotion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "lingering_potions")
                    End If
                    If tippedArrow And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "tipped_arrows")
                    End If
                    If goatHorn And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "goat_horns")
                    End If
                    If painting And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.1", "paintings")
                    End If

                    'Select the new item amount based on the old one
                    Select Case ItemAmount
                        Case 1
                            ItemAmount = 2
                        Case 2
                            ItemAmount = 3
                        Case 3
                            ItemAmount = 5
                        Case 5
                            ItemAmount = 10
                        Case 10
                            ItemAmount = 32
                        Case 32
                            ItemAmount = 64
                        Case 64
                            ItemAmount = -1
                        Case -1
                            ItemAmount = -2
                    End Select
                Next
            ElseIf datapackVersion = "Version 1.20.2 - 1.20.4" Then

                Dim ItemAmount As Integer = 1

                'Go through all the loot tables
                For i As Integer = 1 To 9

                    'Add the item to all the loot tables
                    If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                        AddItem(item, ItemAmount, "1.20.2", "normal_items")
                    End If
                    If otherCreativeOnlyItem = True And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.2", "other_items")
                    End If
                    If spawnEgg = True And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.2", "spawn_eggs")
                    End If
                    If commandBlock = True And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.2", "command_blocks")
                    End If
                    If suspiciousStew And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.2", "suspicious_stews")
                    End If
                    If enchantedBook And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.2", "enchanted_books")
                    End If
                    If potion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.2", "potions")
                    End If
                    If splashPotion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.2", "splash_potions")
                    End If
                    If lingeringPotion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.2", "lingering_potions")
                    End If
                    If tippedArrow And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.2", "tipped_arrows")
                    End If
                    If goatHorn And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.2", "goat_horns")
                    End If
                    If painting And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.2", "paintings")
                    End If

                    'Select the new item amount based on the old one
                    Select Case ItemAmount
                        Case 1
                            ItemAmount = 2
                        Case 2
                            ItemAmount = 3
                        Case 3
                            ItemAmount = 5
                        Case 5
                            ItemAmount = 10
                        Case 10
                            ItemAmount = 32
                        Case 32
                            ItemAmount = 64
                        Case 64
                            ItemAmount = -1
                        Case -1
                            ItemAmount = -2
                    End Select
                Next

            ElseIf datapackVersion = "Version 1.20.5 - 1.20.6" OrElse datapackVersion = "Version 1.21" Then

                Dim ItemAmount As Integer = 1

                'Go through all the loot tables
                For i As Integer = 1 To 9

                    'Add the item to all the loot tables
                    If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                        AddItem(item, ItemAmount, "1.20.5", "normal_items")
                    End If
                    If otherCreativeOnlyItem = True And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.5", "other_items")
                    End If
                    If spawnEgg = True And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.5", "spawn_eggs")
                    End If
                    If commandBlock = True And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.5", "command_blocks")
                    End If
                    If suspiciousStew And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.5", "suspicious_stews")
                    End If
                    If enchantedBook And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.5", "enchanted_books")
                    End If
                    If potion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.5", "potions")
                    End If
                    If splashPotion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.5", "splash_potions")
                    End If
                    If lingeringPotion And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.5", "lingering_potions")
                    End If
                    If tippedArrow And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.5", "tipped_arrows")
                    End If
                    If goatHorn And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.5", "goat_horns")
                    End If
                    If painting And itemAddMode = "Normal" Then
                        AddItem(item, ItemAmount, "1.20.5", "paintings")
                    End If

                    'Select the new item amount based on the old one
                    Select Case ItemAmount
                        Case 1
                            ItemAmount = 2
                        Case 2
                            ItemAmount = 3
                        Case 3
                            ItemAmount = 5
                        Case 5
                            ItemAmount = 10
                        Case 10
                            ItemAmount = 32
                        Case 32
                            ItemAmount = 64
                        Case 64
                            ItemAmount = -1
                        Case -1
                            ItemAmount = -2
                    End Select
                Next
            End If

            'Update And report workerprogress
            workerProgress += progressStep
            bgwAddItems.ReportProgress(workerProgress)
            Invoke(Sub() tbSmallOutput.Text = output)
            totalItemAmount -= 1
            Invoke(Sub() lblItemsTotal.Text = $"Adding items... ({totalItemAmount} items remaining)")
        Else
            MsgBox("Please enter a text in the ID textbox!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Public Sub WriteToLog(message As String, type As String)
        'Write a message to log depending on the message type. Contains several invokes incase it gets called from the BackGroundWorker. Not entirely sure if that's neccessary, but it's there.
        If My.Settings.DisableLogging = False Then
            If type = "Error" Then
                If InvokeRequired = True Then
                    Invoke(Sub()
                               rtbLog.SelectionColor = Color.Red
                               rtbLog.AppendText($"[{DateTime.Now}] [ERROR] {message}{vbNewLine}")
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.Red
                    rtbLog.AppendText($"[{DateTime.Now}] [ERROR] {message}{vbNewLine}")
                End If
            ElseIf type = "Info" Then
                If InvokeRequired = True Then
                    Invoke(Sub()
                               rtbLog.SelectionColor = Color.FromArgb(50, 177, 205)
                               rtbLog.AppendText($"[{DateTime.Now}] [INFO] {message}{vbNewLine}")
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.FromArgb(50, 177, 205)
                    rtbLog.AppendText($"[{DateTime.Now}] [INFO] {message}{vbNewLine}")
                End If
            ElseIf type = "Warning" Then
                If InvokeRequired = True Then
                    Invoke(Sub()
                               rtbLog.SelectionColor = Color.DarkOrange
                               rtbLog.AppendText($"[{DateTime.Now}] [WARNING] {message}{vbNewLine}")
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.DarkOrange
                    rtbLog.AppendText($"[{DateTime.Now}] [WARNING] {message}{vbNewLine}")
                End If
            Else 'If type is invalid
                If InvokeRequired = True Then
                    Invoke(Sub()
                               rtbLog.SelectionColor = Color.Red
                               rtbLog.AppendText("Critical Log Error: Invalid type received" + vbNewLine)
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.Red
                    rtbLog.AppendText("Critical Log Error: Invalid type received" + vbNewLine)
                End If
            End If
        End If
    End Sub

    Private Sub InitializeProfilesAndSchemes()
        WriteToLog("Loading profiles...", "Info")

        'Check if profile directory exists and create it if it is missing
        If Not My.Computer.FileSystem.DirectoryExists(profileDirectory) Then
            My.Computer.FileSystem.CreateDirectory(profileDirectory)
            WriteToLog("Created profile directory", "Info")
        End If

        'Load profile files from specified directory
        GetProfileFiles(profileDirectory)

        'Load default profile if option is enabled
        If My.Settings.LoadDefaultProfile Then
            frmSettings.cbLoadDefaultProfile.Checked = True
            If Not String.IsNullOrEmpty(My.Settings.DefaultProfile) Then
                If My.Computer.FileSystem.FileExists($"{profileDirectory}{My.Settings.DefaultProfile}.txt") Then
                    cbxDefaultProfile.SelectedItem = My.Settings.DefaultProfile
                    frmLoadProfileFrom.InitializeLoadingProfile(cbxDefaultProfile.SelectedItem, False)
                    WriteToLog($"Loaded default profile {cbxDefaultProfile.SelectedItem}", "Info")
                Else
                    frmSettings.Show()
                    frmSettings.cbLoadDefaultProfile.Checked = False
                    My.Settings.LoadDefaultProfile = False
                    frmSettings.SaveSettings($"{appData}/Random Item Giver Updater Legacy/settings.txt")
                    frmSettings.Close()
                    WriteToLog("Error when loading profile: Default profile doesn't exist. Disabled 'Load profile by default' option.", "Error")
                End If
            Else
                frmSettings.Show()
                frmSettings.cbLoadDefaultProfile.Checked = False
                My.Settings.LoadDefaultProfile = False
                frmSettings.SaveSettings($"{appData}/Random Item Giver Updater Legacy/settings.txt")
                frmSettings.Close()
                WriteToLog("Error when loading profile: Default profile is empty. Disabled 'Load profile by default' option.", "Error")
            End If
        Else
            WriteToLog("No default profile selected.", "Info")
        End If

        WriteToLog("Completed loading profiles!", "Info")
        WriteToLog("Loading schemes...", "Info")

        'Check if scheme directory exists
        If Not My.Computer.FileSystem.DirectoryExists(schemeDirectory) Then
            My.Computer.FileSystem.CreateDirectory(schemeDirectory)
        End If

        'Clear list of already existing schemes and load new list of schemes
        cbxScheme.Items.Clear()
        GetSchemeFiles(schemeDirectory)

        'Select default scheme if enabled
        If My.Settings.SelectDefaultScheme Then
            frmSettings.cbSelectDefaultScheme.Checked = True
            If Not String.IsNullOrEmpty(My.Settings.DefaultScheme) Then
                If My.Computer.FileSystem.FileExists($"{schemeDirectory}{My.Settings.DefaultScheme}.txt") Then
                    cbxScheme.SelectedItem = My.Settings.DefaultScheme
                Else
                    frmSettings.Show()
                    frmSettings.cbSelectDefaultScheme.Checked = False
                    My.Settings.SelectDefaultScheme = False
                    frmSettings.SaveSettings($"{appData}/Random Item Giver Updater Legacy/settings.txt")
                    frmSettings.Close()
                    WriteToLog("Error when loading scheme: Default scheme doesn't exist. Disabled 'Select scheme by default' option.", "Error")
                End If
            Else
                frmSettings.Show()
                frmSettings.cbSelectDefaultScheme.Checked = False
                My.Settings.SelectDefaultScheme = False
                frmSettings.SaveSettings($"{appData}/Random Item Giver Updater Legacy/settings.txt")
                frmSettings.Close()
                WriteToLog("Error when loading scheme: Default scheme is empty. Disabled 'Select scheme by default' option.", "Error")
            End If
        Else
            WriteToLog("No default scheme selected", "Info")
        End If

        WriteToLog("Completed loading schemes!", "Info")
    End Sub

    Sub GetProfileFiles(path As String)
        'Clear previous entries
        cbxDefaultProfile.Items.Clear()

        'Gets all sub-directories that exist in the specified directory and add them to the combobox for profiles
        If path.Trim().Length = 0 Then
            Return
        End If

        profileList = Directory.GetFileSystemEntries(path)

        Try
            For Each Profile As String In profileList
                If Directory.Exists(Profile) Then
                    GetProfileFiles(Profile)
                Else
                    Profile = Profile.Replace(path, "").Replace(".txt", "")
                    cbxDefaultProfile.Items.Add(Profile)
                End If
            Next
        Catch ex As Exception
            MsgBox($"Error: Could not load profiles. Please try again.{vbNewLine}Exception: {ex.Message}", MsgBoxStyle.Critical, "Error")
            WriteToLog($"Error when loading profiles for Main Window: {ex.Message}", "Error")
        End Try
    End Sub

    Sub GetSchemeFiles(path As String)
        'Clear previous entries
        cbxScheme.Items.Clear()

        'Gets all sub-directories that exist in the specified directory and add them to the combobox for schemes
        If path.Trim().Length = 0 Then
            Return
        End If

        schemeList = Directory.GetFileSystemEntries(path)

        Try
            For Each Scheme As String In schemeList
                If Directory.Exists(Scheme) Then
                    GetSchemeFiles(Scheme)
                Else
                    Scheme = Scheme.Replace(path, "").Replace(".txt", "")
                    cbxScheme.Items.Add(Scheme)
                End If
            Next
        Catch ex As Exception
            MsgBox($"Error: Could not load schemes. Please try again.{vbNewLine}Exception: {ex.Message}", MsgBoxStyle.Critical, "Error")
            WriteToLog($"Error when loading schemes for Main Window: {ex.Message}", "Error")
        End Try
    End Sub

    Public Sub AddDefaultSchemes() 'Creates profiles for the default schemes. Overwrites existing ones.
        'Normal Item
        My.Computer.FileSystem.WriteAllText($"{schemeDirectory} Normal Item.txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Suspicious Stew
        My.Computer.FileSystem.WriteAllText($"{schemeDirectory} Suspicious Stew.txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Enchanted Book
        My.Computer.FileSystem.WriteAllText($"{schemeDirectory} Enchanted Book.txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Potion
        My.Computer.FileSystem.WriteAllText($"{schemeDirectory} Potion.txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Splash Potion
        My.Computer.FileSystem.WriteAllText($"{schemeDirectory} Splash Potion.txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Lingering Potion
        My.Computer.FileSystem.WriteAllText($"{schemeDirectory} Lingering Potion.txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Tipped Arrow
        My.Computer.FileSystem.WriteAllText($"{schemeDirectory} Tipped Arrow.txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Goat Horn
        My.Computer.FileSystem.WriteAllText($"{schemeDirectory} Goat Horn.txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Spawn Egg
        My.Computer.FileSystem.WriteAllText($"{schemeDirectory} Spawn Egg.txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Command Block
        My.Computer.FileSystem.WriteAllText($"{schemeDirectory} Command Block.txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False", False)

        'Other Creative-Only Item
        My.Computer.FileSystem.WriteAllText($"{schemeDirectory} Other Creative-Only Item.txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False", False)

        'Painting
        My.Computer.FileSystem.WriteAllText($"{schemeDirectory} Painting.txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True", False)

        WriteToLog("Restored default schemes.", "Info")
    End Sub

    '-- Button animations --

    Private Sub btnHamburger_MouseDown(sender As Object, e As MouseEventArgs) Handles btnHamburger.MouseDown
        If design = "Light" Then
            btnHamburger.BackgroundImage = My.Resources.imgHamburgerButtonClick
        ElseIf design = "Dark" Then
            btnHamburger.BackgroundImage = My.Resources.imgHamburgerButtonDarkClick
        End If
    End Sub

    Private Sub btnHamburger_MouseEnter(sender As Object, e As EventArgs) Handles btnHamburger.MouseEnter
        If design = "Light" Then
            btnHamburger.BackgroundImage = My.Resources.imgHamburgerButtonHover
        ElseIf design = "Dark" Then
            btnHamburger.BackgroundImage = My.Resources.imgHamburgerButtonDarkHover
        End If
    End Sub

    Private Sub btnHamburger_MouseLeave(sender As Object, e As EventArgs) Handles btnHamburger.MouseLeave
        If cmsHamburgerButton.Visible = False Then
            If design = "Light" Then
                btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton
            ElseIf design = "Dark" Then
                btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton
            End If
        End If
    End Sub

    Private Sub btnHamburger_MouseUp(sender As Object, e As MouseEventArgs) Handles btnHamburger.MouseUp
        If cmsHamburgerButton.Visible = False Then
            If design = "Light" Then
                btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton
            ElseIf design = "Dark" Then
                btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton
            End If
        End If
    End Sub

    Private Sub frmMain_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        'Reset hamburger button to default state
        btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton
    End Sub

    Private Sub btnAddItem_MouseDown(sender As Object, e As MouseEventArgs) Handles btnAddItem.MouseDown
        If design = "Dark" Then
            btnAddItem.BackgroundImage = My.Resources.imgButtonClick
        ElseIf design = "Light" Then
            btnAddItem.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub


    Private Sub btnAddItem_MouseEnter(sender As Object, e As EventArgs) Handles btnAddItem.MouseEnter
        If design = "Dark" Then
            btnAddItem.BackgroundImage = My.Resources.imgButtonHover
        ElseIf design = "Light" Then
            btnAddItem.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnAddItem_MouseLeave(sender As Object, e As EventArgs) Handles btnAddItem.MouseLeave
        If design = "Dark" Then
            btnAddItem.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnAddItem.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnAddItem_MouseUp(sender As Object, e As MouseEventArgs) Handles btnAddItem.MouseUp
        If design = "Dark" Then
            btnAddItem.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnAddItem.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnSaveAsNewScheme_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSaveAsNewScheme.MouseDown
        If design = "Dark" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButtonClick
        ElseIf design = "Light" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnSaveAsNewScheme_MouseEnter(sender As Object, e As EventArgs) Handles btnSaveAsNewScheme.MouseEnter
        If design = "Dark" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButtonHover
        ElseIf design = "Light" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnSaveAsNewScheme_MouseLeave(sender As Object, e As EventArgs) Handles btnSaveAsNewScheme.MouseLeave
        If design = "Dark" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnSaveAsNewScheme_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSaveAsNewScheme.MouseUp
        If design = "Dark" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnOverwriteSelectedScheme_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOverwriteSelectedScheme.MouseDown
        If design = "Dark" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButtonClick
        ElseIf design = "Light" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnOverwriteSelectedScheme_MouseEnter(sender As Object, e As EventArgs) Handles btnOverwriteSelectedScheme.MouseEnter
        If design = "Dark" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButtonHover
        ElseIf design = "Light" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnOverwriteSelectedScheme_MouseLeave(sender As Object, e As EventArgs) Handles btnOverwriteSelectedScheme.MouseLeave
        If design = "Dark" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnOverwriteSelectedScheme_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOverwriteSelectedScheme.MouseUp
        If design = "Dark" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnDeleteSelectedScheme_MouseDown(sender As Object, e As MouseEventArgs) Handles btnDeleteSelectedScheme.MouseDown
        If design = "Dark" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButtonClick
        ElseIf design = "Light" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnDeleteSelectedScheme_MouseEnter(sender As Object, e As EventArgs) Handles btnDeleteSelectedScheme.MouseEnter
        If design = "Dark" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButtonHover
        ElseIf design = "Light" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnDeleteSelectedScheme_MouseLeave(sender As Object, e As EventArgs) Handles btnDeleteSelectedScheme.MouseLeave
        If design = "Dark" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnDeleteSelectedScheme_MouseUp(sender As Object, e As MouseEventArgs) Handles btnDeleteSelectedScheme.MouseUp
        If design = "Dark" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnBrowseDatapackPath_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBrowseDatapackPath.MouseDown
        If design = "Dark" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButtonClick
        ElseIf design = "Light" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnBrowseDatapackPath_MouseEnter(sender As Object, e As EventArgs) Handles btnBrowseDatapackPath.MouseEnter
        If design = "Dark" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButtonHover
        ElseIf design = "Light" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnBrowseDatapackPath_MouseLeave(sender As Object, e As EventArgs) Handles btnBrowseDatapackPath.MouseLeave
        If design = "Dark" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnBrowseDatapackPath_MouseUp(sender As Object, e As MouseEventArgs) Handles btnBrowseDatapackPath.MouseUp
        If design = "Dark" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnLoadProfile_MouseDown(sender As Object, e As MouseEventArgs) Handles btnLoadProfile.MouseDown
        If design = "Dark" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonClick
        ElseIf design = "Light" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnLoadProfile_MouseEnter(sender As Object, e As EventArgs) Handles btnLoadProfile.MouseEnter
        If design = "Dark" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonHover
        ElseIf design = "Light" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnLoadProfile_MouseLeave(sender As Object, e As EventArgs) Handles btnLoadProfile.MouseLeave
        If design = "Dark" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnLoadProfile_MouseUp(sender As Object, e As MouseEventArgs) Handles btnLoadProfile.MouseUp
        If design = "Dark" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnSaveProfile_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSaveProfile.MouseDown
        If design = "Dark" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButtonClick
        ElseIf design = "Light" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnSaveProfile_MouseEnter(sender As Object, e As EventArgs) Handles btnSaveProfile.MouseEnter
        If design = "Dark" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButtonHover
        ElseIf design = "Light" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnSaveProfile_MouseLeave(sender As Object, e As EventArgs) Handles btnSaveProfile.MouseLeave
        If design = "Dark" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnSaveProfile_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSaveProfile.MouseUp
        If design = "Dark" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnRenameScheme_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRenameScheme.MouseDown
        If design = "Dark" Then
            btnRenameScheme.BackgroundImage = My.Resources.imgButtonClick
        ElseIf design = "Light" Then
            btnRenameScheme.BackgroundImage = My.Resources.imgButtonClickLight
        End If
    End Sub

    Private Sub btnRenameScheme_MouseEnter(sender As Object, e As EventArgs) Handles btnRenameScheme.MouseEnter
        If design = "Dark" Then
            btnRenameScheme.BackgroundImage = My.Resources.imgButtonHover
        ElseIf design = "Light" Then
            btnRenameScheme.BackgroundImage = My.Resources.imgButtonHoverLight
        End If
    End Sub

    Private Sub btnRenameScheme_MouseLeave(sender As Object, e As EventArgs) Handles btnRenameScheme.MouseLeave
        If design = "Dark" Then
            btnRenameScheme.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnRenameScheme.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub btnRenameScheme_MouseUp(sender As Object, e As MouseEventArgs) Handles btnRenameScheme.MouseUp
        If design = "Dark" Then
            btnRenameScheme.BackgroundImage = My.Resources.imgButton
        ElseIf design = "Light" Then
            btnRenameScheme.BackgroundImage = My.Resources.imgButtonLight
        End If
    End Sub

    Private Sub ToolsToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles ToolsToolStripMenuItem.MouseEnter
        If design = "Dark" Then
            'Get the sub menu
            Dim subMenu As ToolStripDropDownMenu = DirectCast(sender, ToolStripMenuItem).DropDown

            'Set background and foreground color
            subMenu.BackColor = Color.DimGray
            subMenu.ForeColor = Color.White
        End If
    End Sub

    Private Sub HelpToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.MouseEnter
        If design = "Dark" Then
            'Get the sub menu
            Dim subMenu As ToolStripDropDownMenu = DirectCast(sender, ToolStripMenuItem).DropDown

            'Set background and foreground color
            subMenu.BackColor = Color.DimGray
            subMenu.ForeColor = Color.White
        End If
    End Sub

    '-- String Templates --

    Dim items02 As String =
    "          ""functions"": [" + vbNewLine +
    "            {" + vbNewLine +
    "              ""function"": ""minecraft:set_count""," + vbNewLine +
    "              ""count"": 2" + vbNewLine +
    "            }"

    Dim items03 As String =
    "          ""functions"": [" + vbNewLine +
    "            {" + vbNewLine +
    "              ""function"": ""minecraft:set_count""," + vbNewLine +
    "              ""count"": 3" + vbNewLine +
    "            }"

    Dim items05 As String =
    "          ""functions"": [" + vbNewLine +
    "            {" + vbNewLine +
    "              ""function"": ""minecraft:set_count""," + vbNewLine +
    "              ""count"": 5" + vbNewLine +
    "            }"

    Dim items10 As String =
    "          ""functions"": [" + vbNewLine +
    "            {" + vbNewLine +
    "              ""function"": ""minecraft:set_count""," + vbNewLine +
    "              ""count"": 10" + vbNewLine +
    "            }"

    Dim items32 As String =
    "          ""functions"": [" + vbNewLine +
    "            {" + vbNewLine +
    "              ""function"": ""minecraft:set_count""," + vbNewLine +
    "              ""count"": 32" + vbNewLine +
    "            }"

    Dim items64 As String =
    "          ""functions"": [" + vbNewLine +
    "            {" + vbNewLine +
    "              ""function"": ""minecraft:set_count""," + vbNewLine +
    "              ""count"": 64" + vbNewLine +
    "            }"

    Dim endPart As String =
    "        }" + vbNewLine +
    "      ]" + vbNewLine +
    "    }" + vbNewLine +
    "  ]" + vbNewLine +
    "}"

    Dim randomAmountSameItem1_16 As String =
    "          ""functions"": [" + vbNewLine +
    "            {" + vbNewLine +
    "              ""function"": ""minecraft:set_count""," + vbNewLine +
    "              ""count"": {" + vbNewLine +
    "                ""min"": 1," + vbNewLine +
    "                ""max"": 64" + vbNewLine +
    "              }" + vbNewLine +
    "            }"

    Dim randomAmountSameItem1_19 As String =
    "          ""functions"": [" + vbNewLine +
    "            {" + vbNewLine +
    "              ""function"": ""minecraft:set_count""," + vbNewLine +
    "                ""count"": {" + vbNewLine +
    "                  ""type"": ""minecraft:score""," + vbNewLine +
    "                  ""target"": {" + vbNewLine +
    "                    ""type"": ""minecraft:fixed""," + vbNewLine +
    "                    ""name"": ""out""" + vbNewLine +
    "                }," + vbNewLine +
    "                ""score"": ""RandomAmountSameItemsGen""" + vbNewLine +
    "              }" + vbNewLine +
    "            }"

    Dim randomAmountSameItem1_20_2 As String =
    "          ""functions"": [" + vbNewLine +
    "            {" + vbNewLine +
    "              ""function"": ""minecraft:set_count""," + vbNewLine +
    "                ""count"": {" + vbNewLine +
    "                  ""type"": ""minecraft:score""," + vbNewLine +
    "                  ""target"": {" + vbNewLine +
    "                    ""type"": ""minecraft:fixed""," + vbNewLine +
    "                    ""name"": ""RandomItemGiver""" + vbNewLine +
    "                }," + vbNewLine +
    "                ""score"": ""RandomAmountSameItemsNumber""" + vbNewLine +
    "              }" + vbNewLine +
    "            }"

End Class