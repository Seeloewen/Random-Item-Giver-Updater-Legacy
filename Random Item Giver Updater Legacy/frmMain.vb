Imports System.Environment
Imports System.IO

Public Class frmMain

    'General variables for the software
    Public appData As String = GetFolderPath(SpecialFolder.ApplicationData) 'Appdata directory
    Public versionLog As String = "0.5.2 (18.07.2023)" 'Version that gets displayed in the log
    Public rawVersion As String = "0.5.2"
    Public settingsVersion As Double = 4 'Current version of the settings file that the app is using
    Dim settingsArray As String() 'Array which the settings will be loaded in
    Dim loadedSettingsVersion As Double 'Version of the settings file that gets loaded
    Dim firstLoadCompleted As Boolean = False 'Whether application is loaded or not. Used for the datapack version detection.
    Dim actionRunning As Boolean = False 'Whether an action is running or not
    Dim settingsFile As String = appData + "\Random Item Giver Updater Legacy\settings.txt" 'Location of the settings file
    Public logDirectory As String = appData + "\Random Item Giver Updater Legacy\Logs\" 'Directory where the log files are saved
    Dim logFileName As String 'File name of the log file
    Public design As String = "System Default" 'Selected design
    Dim osVersion As Version = Environment.OSVersion.Version

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
    Dim nbtTag As String 'The NBT Tag that gets added
    Dim prefix As String 'The prefix the items use
    Dim exceptionAddItem As String 'Contains the ExceptionMessage when adding items
    Dim duplicateDetected As Boolean = False 'Whether a duplicate was detected or not
    Dim fileTemp As String = "None" 'Temporary store of string loaded from a text file. Used to detect duplicates
    Dim itemAmountPath As String 'Part of a directory depending on Item Amount
    Dim ignoreDuplicates As Boolean = False 'Whether duplicates should be automatically ignored
    Dim item As String 'Name of the item that gets added
    Dim fullItemName As String 'Name of the item with prefix
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
    Dim codeEnd As String()
    Dim items2 As String()
    Dim items3 As String()
    Dim items5 As String()
    Dim items10 As String()
    Dim items32 As String()
    Dim items64 As String()
    Dim itemsRandomSame116 As String()
    Dim itemsRandomSame119 As String()
    Dim itemsRandomSame1202 As String()


    '-- Event handlers --

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Convert old main directory to new one, if necessary
        If My.Computer.FileSystem.FileExists(appData + "\Random Item Giver Updater\FirstStartCompleted") And My.Computer.FileSystem.DirectoryExists(appData + "\Random Item Giver Updater Legacy\") = False Then
            Rename(appData + "\Random Item Giver Updater", appData + "\Random Item Giver Updater Legacy")
        End If

        'Create directory in appdata if it doesnt exist already
        If My.Computer.FileSystem.DirectoryExists(appData + "\Random Item Giver Updater Legacy\") = False Then
            My.Computer.FileSystem.CreateDirectory(appData + "\Random Item Giver Updater Legacy\")
            WriteToLog("Created the 'Random Item Giver Updater Legacy' directory in the Appdata folder for application files.", "Info")
        End If

        'Post initial log text
        WriteToLog(String.Format("Random Item Giver Updater Legacy {0}", versionLog), "Info")
        WriteToLog("You are running a legacy build, please be aware of issues that may occur!", "Warning")

        'Add click event of frmMain to every control in frmMain
        For Each ctrl As Control In Controls
            If Not ctrl.Equals(btnHamburger) Then
                AddHandler ctrl.Click, AddressOf frmMain_MouseClick
            End If
        Next

        'If software gets started for the first time, add default schemes and create file that indicates that the software was started once already.
        If My.Computer.FileSystem.FileExists(appData + "\Random Item Giver Updater Legacy\FirstStartCompleted") = False Then
            My.Computer.FileSystem.WriteAllText(appData + "\Random Item Giver Updater Legacy\FirstStartCompleted", "", False)
            If My.Computer.FileSystem.DirectoryExists(schemeDirectory) = False Then
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
        If My.Settings.DisableLogging = True Then
            frmOutput.rtbLog.Clear()
            If My.Computer.FileSystem.FileExists(appData + "\Random Item Giver Updater Legacy\DebugLogTemp") Then
                My.Computer.FileSystem.DeleteFile(appData + "\Random Item Giver Updater Legacy\DebugLogTemp")
            End If
        End If

        'Hide Legacy Warning if setting is enabled
        If My.Settings.HideLegacyWarning = False Then
            MsgBox("Warning: You are running a legacy version of the Random Item Giver Updater." + vbNewLine + vbNewLine + "You have to expect to find bugs or other issues." + vbNewLine + vbNewLine + "Please note that this version of the software will no longer receive major content updates!" + vbNewLine + vbNewLine + "Things may break, you should use this software at your own risk and with caution.", MsgBoxStyle.Exclamation, "Warning")
        End If

        'Define several variables (I know I could probably do this way easier but... yeah)
        codeEnd = rtbCodeEnd.Lines
        items2 = rtbItems2.Lines
        items3 = rtbItems3.Lines
        items5 = rtbItems5.Lines
        items10 = rtbItems10.Lines
        items32 = rtbItems32.Lines
        items64 = rtbItems64.Lines
        itemsRandomSame116 = rtbItemsRandomSame116.Lines
        itemsRandomSame119 = rtbItemsRandomSame119.Lines
        itemsRandomSame1202 = rtbItemsRandomSame1202.Lines

        'Load advanced view setting
        If My.Settings.UseAdvancedViewByDefault = True Then
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

            'Disable input so settings can't be changed while items are being added
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

            'Set total amount of items and start the backgroundworker that adds the items
            totalItemAmount = rtbItem.Lines.Count
            bgwAddItems.RunWorkerAsync()
        Else
            MsgBox("Please enter a datapack path!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub bgwAddItems_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwAddItems.DoWork
        'Checks if there are 100 or more Items being added while AddItemsFast is disabled and will show a warning if thats the case
        If itemsList.Count >= 100 And addItemsFast = False Then
            Select Case MsgBox("Warning: You are trying to add 100 or more items." + vbNewLine + "This may take a long time to complete. It's recommended to enable 'Add Items Fast' to speed up the process." + vbNewLine + vbNewLine + "Are you sure you want to continue?", vbExclamation + vbYesNo, "Warning")
                Case Windows.Forms.DialogResult.Yes
                    'Sets ItemAddMode. This should be redundant in this case, despite of this I will still leave it there to be save
                    If addItemsFast = True Then
                        itemAddMode = "Fast"
                    Else
                        itemAddMode = "Normal"
                    End If

                    'Resets variables used to detect duplicates
                    ignoreDuplicates = False
                    duplicateDetected = False

                    WriteToLog(String.Format("Adding {0} items...", totalItemAmount), "Info")

                    'Calculate ProgressStep
                    progressStep = 100 / itemsList.Count

                    'Start adding the items
                    AddMultipleItems()
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
            If itemsList.Length = 1 Then
                item = itemsList(0)
                WriteToLog(String.Format("Adding 1 item..."), "Info")
                progressStep = 100 / itemsList.Count
                CallAddItem()
            ElseIf itemsList.Length > 1 Then
                WriteToLog(String.Format("Adding {0} items...", totalItemAmount), "Info")
                progressStep = 100 / itemsList.Count
                AddMultipleItems()
            End If
        End If
    End Sub

    Private Sub rtbLog_TextChanged(sender As Object, e As EventArgs) Handles rtbLog.TextChanged
        'Update log file and log in output window
        rtbLog.SaveFile(String.Format("{0}\Random Item Giver Updater Legacy\DebugLogTemp", appData))
        frmOutput.rtbLog.LoadFile(String.Format("{0}\Random Item Giver Updater Legacy\DebugLogTemp", appData))
    End Sub

    Private Sub btnHamburger_Click(sender As Object, e As EventArgs) Handles btnHamburger.Click
        'Show menu with different options
        If cmsHamburgerButton.Visible = True Then
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
        If cbCustomNBT.Checked Then
            tbCustomNBT.Enabled = True
            customNBT = True
        Else
            tbCustomNBT.Enabled = False
            customNBT = False
        End If
    End Sub

    Private Sub cbCreativeOnly_CheckedChanged(sender As Object, e As EventArgs) Handles cbCreativeOnly.CheckedChanged
        'Toggle the creative-only setting
        If cbCreativeOnly.Checked Then
            creativeOnly = True
            rbtnOtherItem.Enabled = True
            rbtnCommandBlock.Enabled = True
            rbtnSpawnEgg.Enabled = True
        Else
            creativeOnly = False
            rbtnOtherItem.Enabled = False
            rbtnCommandBlock.Enabled = False
            rbtnSpawnEgg.Enabled = False
        End If
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
                If datapackVersion = "Version 1.20" OrElse datapackVersion = "Version 1.19.4" OrElse datapackVersion = "Version 1.20.1" OrElse datapackVersion = "Version 1.20.2 - 1.20.4" Then
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
        If rtbItem.Lines.Count > 99 Then
            cbAddItemsFast.Text = "Enable Fast Item Adding (Recommended)"
        ElseIf rtbItems10.Lines.Count < 99 Then
            cbAddItemsFast.Text = "Enable Fast Item Adding"
        End If

        'Display amount of items in the total items label
        lblItemsTotal.Text = String.Format("Total amount of items: {0}", rtbItem.Lines.Count)
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
        If rbtnSpawnEgg.Checked Then
            spawnEgg = True
        Else
            spawnEgg = False
        End If
    End Sub

    Private Sub rbtnCommandBlock_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCommandBlock.CheckedChanged
        'Pass checkstate onto the variable
        If rbtnCommandBlock.Checked Then
            commandBlock = True
        Else
            commandBlock = False
        End If
    End Sub

    Private Sub rbtnOtherItem_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOtherItem.CheckedChanged
        'Pass checkstate onto the variable
        If rbtnOtherItem.Checked Then
            otherCreativeOnlyItem = True
        Else
            otherCreativeOnlyItem = False
        End If
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
            If datapackVersion = "Version 1.20" OrElse datapackVersion = "Version 1.19.4" OrElse datapackVersion = "Version 1.20.1" OrElse datapackVersion = "Version 1.20.2 - 1.20.4" Then
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
    End Sub

    Private Sub bgwAddItems_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwAddItems.RunWorkerCompleted
        'When adding the items is complete, enable all menu controls again and set progress to 100%
        pbAddingItemsProgress.Value = 100
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
        tbSamePrefix.Enabled = True
        cbCustomNBT.Enabled = True
        tbCustomNBT.Enabled = True
        cbAddItemsFast.Enabled = True
        cbxVersion.Enabled = True
        btnBrowseDatapackPath.Enabled = True
        tbDatapackPath.Enabled = True
        If cbxVersion.SelectedItem = "Version 1.19.4" OrElse cbxVersion.SelectedItem = "Version 1.20" OrElse cbxVersion.SelectedItem = "Version 1.20.1" OrElse cbxVersion.SelectedItem = "Version 1.20.2 - 1.20.4" Then
            cbPainting.Enabled = True
            cbGoatHorn.Enabled = True
        ElseIf cbxVersion.SelectedItem = "Version 1.19 - 1.19.3" Then
            cbGoatHorn.Enabled = True
        End If

        'If result is "success" show messagebox. This variable would've been changed if an error occured.
        If rtbItem.Lines.Count > totalDuplicatesIgnored Then
            If addItemResult = "success" Then
                MsgBox(String.Format("Successfully added {0} item(s)!", rtbItem.Lines.Count - totalDuplicatesIgnored), MsgBoxStyle.Information, "Added items")
                WriteToLog(String.Format("Successfully added {0} items", rtbItem.Lines.Count - totalDuplicatesIgnored), "Info")
            ElseIf addItemResult = "error" Then
                MsgBox(String.Format("Failed to add {0} items.", rtbItem.Lines.Count - totalDuplicatesIgnored), MsgBoxStyle.Critical, "Error")
            End If
        End If

        'Show 'Add item to datapack' button which also hides the progress bar and show total amount of items in richtextbox again
        btnAddItem.Show()
        lblItemsTotal.Text = String.Format("Total amount of items: {0}", rtbItem.Lines.Count)
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
        If My.Computer.FileSystem.FileExists(schemeDirectory + cbxScheme.SelectedItem + ".txt") Then
            My.Computer.FileSystem.DeleteFile(schemeDirectory + cbxScheme.SelectedItem + ".txt")
            MsgBox("Scheme was deleted.", MsgBoxStyle.Information, "Deleted")
            WriteToLog(String.Format("Deleted scheme {0}", cbxScheme.SelectedItem), "Info")
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
        If My.Settings.AutoSaveLogs = True Then
            logFileName = String.Format("Random_Item_Giver_Updater_Legacy_Log_{0}_Ver_{1}", DateTime.Now, versionLog)
            logFileName = logFileName.Replace(":", "-")
            logFileName = logFileName.Replace(".", "-")
            logFileName = logFileName.Replace(" ", "_")
            logFileName = logFileName.Replace("(", "")
            logFileName = logFileName.Replace(")", "")
            logFileName = String.Format("{0}{1}.txt", logDirectory, logFileName)
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
        If String.IsNullOrEmpty(cbxScheme.Text) = False Then
            frmRenameScheme.ShowDialog(cbxScheme.Text)
        Else
            MsgBox("Please load a scheme in order to rename it.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    '-- Custom methods --

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
            lblHeader.ForeColor = Color.White
            lblItemsTotal.ForeColor = Color.White
            cmsHamburgerButton.BackColor = Color.DimGray
            cmsHamburgerButton.ForeColor = Color.White
            DuplicateFinderToolStripMenuItem.BackColor = Color.DimGray
            pbSelectDatapack.BackgroundImage = My.Resources.imgBackgroundPath
            lblBoxSelectDatapackHeader.BackColor = Color.FromArgb(195, 195, 195)
            lblSelectDatapack.ForeColor = Color.White
            lblSelectDatapack.BackColor = Color.FromArgb(127, 127, 127)
            tbDatapackPath.ForeColor = Color.White
            tbDatapackPath.BackColor = Color.FromArgb(100, 100, 100)
            lblDatapackDetection.ForeColor = Color.White
            lblDatapackDetection.BackColor = Color.FromArgb(127, 127, 127)
            lblVersion.ForeColor = Color.White
            lblVersion.BackColor = Color.FromArgb(127, 127, 127)
            cbxVersion.ForeColor = Color.White
            cbxVersion.BackColor = Color.FromArgb(105, 105, 105)
            pbAddItem.BackgroundImage = My.Resources.imgBackgroundItem
            lblBoxAddItemHeader.BackColor = Color.FromArgb(195, 195, 195)
            lblAddNewItems.ForeColor = Color.White
            lblAddNewItems.BackColor = Color.FromArgb(127, 127, 127)
            lblScheme.ForeColor = Color.White
            lblScheme.BackColor = Color.FromArgb(127, 127, 127)
            cbxScheme.ForeColor = Color.White
            cbxScheme.BackColor = Color.FromArgb(105, 105, 105)
            gbItemID.ForeColor = Color.White
            gbItemID.BackColor = Color.FromArgb(127, 127, 127)
            cbCustomNBT.ForeColor = Color.White
            cbCustomNBT.BackColor = Color.FromArgb(127, 127, 127)
            tbCustomNBT.ForeColor = Color.White
            tbCustomNBT.BackColor = Color.FromArgb(100, 100, 100)
            cbSamePrefix.ForeColor = Color.White
            cbSamePrefix.BackColor = Color.FromArgb(127, 127, 127)
            tbSamePrefix.ForeColor = Color.White
            tbSamePrefix.BackColor = Color.FromArgb(100, 100, 100)
            cbEnableAdvancedView.ForeColor = Color.White
            cbEnableAdvancedView.BackColor = Color.FromArgb(127, 127, 127)
            cbAddItemsFast.ForeColor = Color.White
            cbAddItemsFast.BackColor = Color.FromArgb(127, 127, 127)
            lblOutput.ForeColor = Color.White
            lblOutput.BackColor = Color.FromArgb(127, 127, 127)
            rtbItem.ForeColor = Color.White
            rtbItem.BackColor = Color.FromArgb(100, 100, 100)
            tbSmallOutput.ForeColor = Color.White
            tbSmallOutput.BackColor = Color.FromArgb(100, 100, 100)
            cbNormalItem.ForeColor = Color.White
            cbNormalItem.BackColor = Color.FromArgb(127, 127, 127)
            cbEnchantedBook.ForeColor = Color.White
            cbEnchantedBook.BackColor = Color.FromArgb(127, 127, 127)
            cbPotion.ForeColor = Color.White
            cbPotion.BackColor = Color.FromArgb(127, 127, 127)
            cbLingeringPotion.ForeColor = Color.White
            cbLingeringPotion.BackColor = Color.FromArgb(127, 127, 127)
            cbSplashPotion.ForeColor = Color.White
            cbSplashPotion.BackColor = Color.FromArgb(127, 127, 127)
            cbTippedArrow.ForeColor = Color.White
            cbTippedArrow.BackColor = Color.FromArgb(127, 127, 127)
            cbSuspiciousStew.ForeColor = Color.White
            cbSuspiciousStew.BackColor = Color.FromArgb(127, 127, 127)
            cbGoatHorn.ForeColor = Color.White
            cbGoatHorn.BackColor = Color.FromArgb(127, 127, 127)
            cbPainting.ForeColor = Color.White
            cbPainting.BackColor = Color.FromArgb(127, 127, 127)
            cbCreativeOnly.ForeColor = Color.White
            cbCreativeOnly.BackColor = Color.FromArgb(127, 127, 127)
            rbtnSpawnEgg.ForeColor = Color.White
            rbtnSpawnEgg.BackColor = Color.FromArgb(127, 127, 127)
            rbtnCommandBlock.ForeColor = Color.White
            rbtnCommandBlock.BackColor = Color.FromArgb(127, 127, 127)
            rbtnOtherItem.ForeColor = Color.White
            rbtnOtherItem.BackColor = Color.FromArgb(127, 127, 127)
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
        If My.Computer.FileSystem.FileExists(String.Format("{0}\Random Item Giver Updater Legacy\FirstStart_{1}", appData, rawVersion)) = False Then
            My.Computer.FileSystem.WriteAllText(String.Format("{0}\Random Item Giver Updater Legacy\FirstStart_{1}", appData, rawVersion), "", False)
            frmUpdateNews.ShowDialog()
        End If
    End Sub

    Public Sub InitializeLoadingScheme(scheme As String, showMessage As Boolean)
        'Checks if a scheme is selected. It then reads the content of the scheme file into the array. To avoid errors with the array being too small, it gets resized. The number represents the amount of settings.
        'It then starts to convert and load the scheme, see the the method below.
        If String.IsNullOrEmpty(scheme) = False Then
            loadFromScheme = String.Format("{0}{1}.txt", schemeDirectory, scheme)
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
                    WriteToLog(String.Format("Loaded and updated scheme {0}", scheme), "Info")
                Case Windows.Forms.DialogResult.No
                    MsgBox("Cancelled loading scheme.", MsgBoxStyle.Exclamation, "Warning")
            End Select
        Else
            LoadScheme(scheme, showMessage)
            WriteToLog(String.Format("Loaded scheme {0}", scheme), "Info")
        End If
    End Sub

    Public Sub LoadScheme(scheme As String, showMessage As Boolean)
        'Same Prefix Checkbox
        samePrefix = Convert.ToBoolean(schemeContent(0))
        If samePrefix = True Then
            cbSamePrefix.Checked = True
        Else
            cbSamePrefix.Checked = False
        End If

        'Same Prefix Textbox
        If String.IsNullOrEmpty(tbSamePrefix.Text) Then
            tbSamePrefix.Text = "None"
        Else
            tbSamePrefix.Text = schemeContent(1)
        End If

        'Custom NBT Checkbox
        customNBT = Convert.ToBoolean(schemeContent(2))
        If customNBT = True Then
            cbCustomNBT.Checked = True
        Else
            cbCustomNBT.Checked = False
        End If

        'Custom NBT Textbox
        If String.IsNullOrEmpty(tbCustomNBT.Text) Then
            tbCustomNBT.Text = "None"
        Else
            tbCustomNBT.Text = schemeContent(3)
        End If

        'Normal Item Checkbox
        normalItem = Convert.ToBoolean(schemeContent(4))
        If normalItem = True Then
            cbNormalItem.Checked = True
        Else
            cbNormalItem.Checked = False
        End If

        'Suspicious Stew Checkbox
        suspiciousStew = Convert.ToBoolean(schemeContent(5))
        If suspiciousStew = True Then
            cbSuspiciousStew.Checked = True
        Else
            cbSuspiciousStew.Checked = False
        End If

        'Enchanted Book Checkbox
        enchantedBook = Convert.ToBoolean(schemeContent(6))
        If enchantedBook = True Then
            cbEnchantedBook.Checked = True
        Else
            cbEnchantedBook.Checked = False
        End If

        'Potion Book Checkbox
        potion = Convert.ToBoolean(schemeContent(7))
        If potion = True Then
            cbPotion.Checked = True
        Else
            cbPotion.Checked = False
        End If

        'Splash Potion Checkbox
        splashPotion = Convert.ToBoolean(schemeContent(8))
        If splashPotion = True Then
            cbSplashPotion.Checked = True
        Else
            cbSplashPotion.Checked = False
        End If

        'Lingering Potion Checkbox
        lingeringPotion = Convert.ToBoolean(schemeContent(9))
        If lingeringPotion = True Then
            cbLingeringPotion.Checked = True
        Else
            cbLingeringPotion.Checked = False
        End If

        'Tipped Arrow Checkbox
        tippedArrow = Convert.ToBoolean(schemeContent(10))
        If tippedArrow = True Then
            cbTippedArrow.Checked = True
        Else
            cbTippedArrow.Checked = False
        End If

        'Goat Horn Checkbox
        goatHorn = Convert.ToBoolean(schemeContent(11))
        If goatHorn = True Then
            cbGoatHorn.Checked = True
        Else
            cbGoatHorn.Checked = False
        End If

        'Creative-Only Checkbox
        creativeOnly = Convert.ToBoolean(schemeContent(12))
        If creativeOnly = True Then
            cbCreativeOnly.Checked = True

            'Spawn Egg Radiobutton
            spawnEgg = Convert.ToBoolean(schemeContent(13))
            If spawnEgg = True Then
                rbtnSpawnEgg.Checked = True
            Else
                rbtnSpawnEgg.Checked = False
            End If

            'Command Block Radiobutton
            commandBlock = Convert.ToBoolean(schemeContent(14))
            If commandBlock = True Then
                rbtnCommandBlock.Checked = True
            Else
                rbtnCommandBlock.Checked = False
            End If

            'Other Creative-Only Item Radiobutton
            otherCreativeOnlyItem = Convert.ToBoolean(schemeContent(15))
            If otherCreativeOnlyItem = True Then
                rbtnOtherItem.Checked = True
            Else
                rbtnOtherItem.Checked = False
            End If
        Else
            cbCreativeOnly.Checked = False
        End If

        'Painting Checkbox
        painting = Convert.ToBoolean(schemeContent(16))
        If painting = True Then
            cbPainting.Checked = True
        Else
            cbPainting.Checked = False
        End If

        'If ShowMessage is enabled, it will show a messagebox when loading completes.
        If showMessage Then
            MsgBox(String.Format("Loaded scheme {0}.", scheme), MsgBoxStyle.Information, "Loaded profile")
        End If
    End Sub

    Public Sub UpdateScheme(schemeName)

        'Save currently selected settings into Variables
        If rbtnSpawnEgg.Checked = True Then
            spawnEgg = True
        Else
            spawnEgg = False
        End If
        If rbtnCommandBlock.Checked = True Then
            commandBlock = True
        Else
            spawnEgg = False
        End If
        If rbtnOtherItem.Checked = True Then
            otherCreativeOnlyItem = True
        Else
            otherCreativeOnlyItem = False
        End If
        If cbSamePrefix.Checked Then
            samePrefix = True
        Else
            samePrefix = False
        End If
        If cbCustomNBT.Checked = True Then
            customNBT = True
        Else
            customNBT = False
        End If
        If cbNormalItem.Checked = True Then
            normalItem = True
        Else
            normalItem = False
        End If
        If cbSuspiciousStew.Checked = True Then
            suspiciousStew = True
        Else
            suspiciousStew = False
        End If
        If cbEnchantedBook.Checked = True Then
            enchantedBook = True
        Else
            enchantedBook = False
        End If
        If cbPotion.Checked = True Then
            potion = True
        Else
            potion = False
        End If
        If cbSplashPotion.Checked = True Then
            splashPotion = True
        Else
            splashPotion = False
        End If
        If cbLingeringPotion.Checked = True Then
            lingeringPotion = True
        Else
            lingeringPotion = False
        End If
        If cbTippedArrow.Checked = True Then
            tippedArrow = True
        Else
            tippedArrow = False
        End If
        If cbGoatHorn.Checked = True Then
            goatHorn = True
        Else
            goatHorn = False
        End If
        If cbCreativeOnly.Checked = True Then
            creativeOnly = True
        Else
            creativeOnly = False
        End If
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
        If cbPainting.Checked = True Then
            painting = True
        Else
            painting = False
        End If

        'Update the selected scheme. This will save and overwrite the selected scheme without showing any warning or message. Used if a profile is old or corrupted.
        If String.IsNullOrEmpty(schemeName) = False Then
            If My.Computer.FileSystem.DirectoryExists(schemeDirectory) Then
                My.Computer.FileSystem.WriteAllText(String.Format("{0}{1}.txt", schemeDirectory, schemeName), samePrefix.ToString + vbNewLine + samePrefixString + vbNewLine + customNBT.ToString + vbNewLine + customNBTString + vbNewLine + normalItem.ToString + vbNewLine + suspiciousStew.ToString + vbNewLine + enchantedBook.ToString + vbNewLine + potion.ToString + vbNewLine + splashPotion.ToString + vbNewLine + lingeringPotion.ToString + vbNewLine + tippedArrow.ToString + vbNewLine + goatHorn.ToString + vbNewLine + creativeOnly.ToString + vbNewLine + spawnEgg.ToString + vbNewLine + commandBlock.ToString + vbNewLine + otherCreativeOnlyItem.ToString + vbNewLine + painting.ToString + vbNewLine, False)
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
            If My.Computer.FileSystem.FileExists(tbDatapackPath.Text + "/pack.mcmeta") Then

                Dim versionString As String = System.IO.File.ReadAllLines(String.Format("{0}/pack.mcmeta", tbDatapackPath.Text))(2)
                Dim parseVersion As String = Replace(versionString, "    " + Chr(34) + "pack_format" + Chr(34) + ": ", "")
                Dim version As String = Convert.ToInt32(Replace(parseVersion, ",", ""))

                Try
                    If version > 26 Then
                        lblDatapackDetection.Text = "Detected datapack, but could not determine version"
                        MsgBox("A datapack has been detected but the pack format is greater than 15." + vbNewLine + "This means that the datapack is possibly newer than the software supports." + vbNewLine + "The newest available version in the software has been selected but is not guaranteed to work.", MsgBoxStyle.Exclamation, "Warning")
                        WriteToLog(String.Format("Detected unsupported datapack version. This may cause issues. (Pack format {0})", version), "Warning")
                        cbxVersion.SelectedItem = "Version 1.20.2 - 1.20.4"
                    ElseIf version = "26" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.20.3 - 1.20.4."
                        WriteToLog(String.Format("Detected datapack version 1.20.3 - 1.20.4 (Pack format {0})", version), "Info")
                        cbxVersion.SelectedItem = "Version 1.20.2 - 1.20.4"
                    ElseIf version = "19" OrElse version = "20" OrElse version = "21" OrElse version = "22" OrElse version = "23" OrElse version = "24" OrElse version = "25" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.20.3 Snapshot."
                        WriteToLog(String.Format("Detected datapack version 1.20.3 Snapshot (Pack format {0})", version), "Info")
                        cbxVersion.SelectedItem = "Version 1.20.2 - 1.20.4"
                    ElseIf version = "18" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.20.2."
                        WriteToLog(String.Format("Detected datapack version 1.20.2 (Pack format {0})", version), "Info")
                        cbxVersion.SelectedItem = "Version 1.20.2 - 1.20.4"
                    ElseIf version = "16" OrElse version = "17" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.20.2 Snapshot."
                        WriteToLog(String.Format("Detected datapack version 1.20.2 Snapshot (Pack format {0})", version), "Info")
                        cbxVersion.SelectedItem = "Version 1.20.2 - 1.20.4"
                    ElseIf version = "15" Then
                        If My.Computer.FileSystem.FileExists(tbDatapackPath.Text + "/updater.txt") Then
                            lblDatapackDetection.Text = "Detected datapack as version 1.20.1."
                            WriteToLog(String.Format("Detected datapack version 1.20.1 (Pack format {0})", version), "Info")
                            cbxVersion.SelectedItem = "Version 1.20.1"
                        Else
                            lblDatapackDetection.Text = "Detected datapack as version 1.20."
                            WriteToLog(String.Format("Detected datapack version 1.20 (Pack format {0})", version), "Info")
                            cbxVersion.SelectedItem = "Version 1.20"
                        End If
                    ElseIf version = "13" OrElse version = "14" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.20 Snapshot."
                        WriteToLog(String.Format("Detected datapack version 1.20 Snapshot (Pack format {0})", version), "Info")
                        cbxVersion.SelectedItem = "Version 1.20"
                    ElseIf version = "12" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.19.4."
                        WriteToLog(String.Format("Detected datapack version 1.19.4 (Pack format {0})", version), "Info")
                        cbxVersion.SelectedItem = "Version 1.19.4"
                    ElseIf version = "11" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.19.4 Snapshot."
                        WriteToLog(String.Format("Detected datapack version 1.19.4 Snapshot (Pack format {0})", version), "Info")
                        cbxVersion.SelectedItem = "Version 1.19.4"
                    ElseIf version = "10" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.19 - 1.19.3."
                        WriteToLog(String.Format("Detected datapack version 1.19 - 1.19.3 (Pack format {0})", version), "Info")
                        cbxVersion.SelectedItem = "Version 1.19 - 1.19.3"
                    ElseIf version = "9" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.18.2."
                        WriteToLog(String.Format("Detected datapack version 1.18.2 (Pack format {0})", version), "Info")
                        cbxVersion.SelectedItem = "Version 1.18 - 1.18.2"
                    ElseIf version = "8" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.18 - 1.18.1 (Outdated)"
                        WriteToLog(String.Format("Detected datapack version 1.18 - 1.18.1 (Pack format {0})", version), "Info")
                        cbxVersion.SelectedItem = "Version 1.18 - 1.18.2"
                    ElseIf version = "7" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.17 - 1.17.1."
                        WriteToLog(String.Format("Detected datapack version 1.17 - 1.17.1 (Pack format {0})", version), "Info")
                        cbxVersion.SelectedItem = "Version 1.17 - 1.17.1"
                    ElseIf version = "6" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.16.2 - 1.16.5."
                        WriteToLog(String.Format("Detected datapack version 1.16.2 - 1.16.5 (Pack format {0})", version), "Info")
                        cbxVersion.SelectedItem = "Version 1.16.2 - 1.16.5"
                    ElseIf Convert.ToInt32(version) < 6 Then
                        lblDatapackDetection.Text = "Detected datapack, but version is most likely unsupported"
                        MsgBox("A datapack has been detected but the pack format is smaller than 6." + vbNewLine + "This means that the datapack version is older than 1.15 which the Random Item Giver does not support." + vbNewLine + "The oldest available version has been selected but will most likely not work.", MsgBoxStyle.Exclamation, "Warning")
                        WriteToLog(String.Format("Detected unsupported datapack version. This may cause issues. (Pack format {0})", version), "Warning")
                        cbxVersion.SelectedItem = "Version 1.16.2 - 1.16.5"
                    Else
                        lblDatapackDetection.Text = "Detected datapack, but could not determine version."
                        WriteToLog("Detected datapack, but could not determine version.", "Error")
                    End If
                Catch ex As Exception
                    MsgBox(String.Format("Error when selecting datapack: {0}", ex.Message), MsgBoxStyle.Critical, "Error")
                    lblDatapackDetection.Text = "Detected datapack, but could not determine version."
                    WriteToLog("Detected datapack, couldn't determine version.", "Error")
                    cbxVersion.SelectedItem = "Version 1.20.2 - 1.20.4"
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

            'Set custom NTB tag and prefix
            If customNBT = True Then
                nbtTag = customNBTString.Replace(Chr(34), "\" + Chr(34)) 'Fix quotiation marks in NBT tags
            Else
                nbtTag = "NONE"
            End If

            'Determine the full item name based on the item ID
            If samePrefix = True Then
                prefix = samePrefixString
                fullItemName = String.Format("{0}:{1}", prefix, itemID)
            Else
                fullItemName = itemID
            End If

            'Define ItemAmountPath depending on itemAmount
            If itemAmount = 1 Then
                If version = "1.16" OrElse version = "1.18" OrElse version = "1.19" Then
                    itemAmountPath = "1item\"
                ElseIf version = "1.20.1" OrElse version = "1.20.2" Then
                    itemAmountPath = "01item\"
                End If
            ElseIf itemAmount = "-1" Then
                itemAmountPath = "randomamountsameitem\"
            ElseIf itemAmount = "-2" Then
                itemAmountPath = "randomamountdifitems\"
            ElseIf itemAmount > 1 Then
                If (version = "1.20.1" OrElse version = "1.20.2") And (itemAmount = 1 OrElse itemAmount = 2 OrElse itemAmount = 3 OrElse itemAmount = 5) Then
                    itemAmountPath = String.Format("0{0}sameitems\", itemAmount)
                Else
                    itemAmountPath = String.Format("{0}sameitems\", itemAmount)
                End If
            End If

            'Check if item you want to add already exists
            If My.Computer.FileSystem.FileExists(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json") Then
                fileTemp = My.Computer.FileSystem.ReadAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
            End If

            'If the item you want to add does not exist or duplicates are ignored add items depending on version and loot table
            If fileTemp.Contains(Chr(34) + fullItemName + Chr(34)) = False Or ignoreDuplicates = True Then
                Try
                    If version = "1.20.2" Then
                        If itemAmount = 1 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + "                    " + Chr(34) + "functions" + Chr(34) + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 2 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items2) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items2) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 3 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items3) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items3) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 5 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items5) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items5) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 10 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items10) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items10) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 32 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items32) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items32) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 64 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items64) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items64) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = "-1" Then

                            'Set itemsRandomSame based on version
                            Dim itemsRandomSame As String() = {""}
                            itemsRandomSame = itemsRandomSame1202

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(itemsRandomSame) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(itemsRandomSame) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = "-2" Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "normal_items" OrElse lootTable = "other_items" OrElse lootTable = "command_blocks" OrElse lootTable = "spawn_eggs") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + "                    " + Chr(34) + "functions" + Chr(34) + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If
                        End If
                    ElseIf version = "1.16" OrElse version = "1.18" OrElse version = "1.19" OrElse version = "1.20.1" Then

                        If itemAmount = 1 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + "                    " + Chr(34) + "functions" + Chr(34) + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 2 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items2) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items2) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 3 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items3) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items3) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 5 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items5) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items5) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 10 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items10) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items10) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 32 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items32) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items32) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 64 Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items64) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(items64) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = "-1" And (version = "1.16" OrElse version = "1.19") Then

                            'Set itemsRandomSame based on version
                            Dim itemsRandomSame As String() = {""}
                            If version = "1.16" Then
                                itemsRandomSame = itemsRandomSame116
                            ElseIf version = "1.19" Then
                                itemsRandomSame = itemsRandomSame119
                            End If

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(itemsRandomSame) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + ReturnArrayAsString(itemsRandomSame) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = "-2" And (version = "1.16" OrElse version = "1.19") Then

                            'Remove the last few lines to allow for new items to be added
                            lineRemoveLoop = 8
                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString
                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()
                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            'Add the item to the corresponding loot table
                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" OrElse lootTable = "goat_horns" OrElse lootTable = "paintings") Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + "                    " + Chr(34) + "functions" + Chr(34) + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
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
                        lineRemoveLoop = 8
                        While lineRemoveLoop > 0
                            Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + lootTable + ".json")
                            Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                            editFileLastLineLength = EditFileLines.Last.Length.ToString
                            FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                            FileStreamEditFile.Close()
                            lineRemoveLoop = lineRemoveLoop - 1
                        End While

                        'Add the item to the corresponding loot table
                        If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                            My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + vbNewLine + ReturnArrayAsString(codeEnd), True)
                        ElseIf ((lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True) OrElse (lootTable = "suspicious_stew" OrElse lootTable = "enchanted_books" OrElse lootTable = "potion" OrElse lootTable = "splash_potion" OrElse lootTable = "lingering_potion" OrElse lootTable = "tipped_arrow") Then
                            My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + lootTable + ".json", "        }," + vbNewLine + "        {" + vbNewLine + "          " + Chr(34) + "type" + Chr(34) + ": " + Chr(34) + "minecraft:item" + Chr(34) + "," + vbNewLine + "          " + Chr(34) + "name" + Chr(34) + ": " + Chr(34) + fullItemName + Chr(34) + "," + vbNewLine + "                    " + Chr(34) + "functions" + Chr(34) + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + Chr(34) + "function" + Chr(34) + ": " + Chr(34) + "set_nbt" + Chr(34) + "," + vbNewLine + "                            " + Chr(34) + "tag" + Chr(34) + ": " + Chr(34) + nbtTag + Chr(34) + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                        End If

                    End If

                Catch Exception As Exception
                    exceptionAddItem = Exception.Message
                    addItemResult = "error"
                End Try

                'If not exception was found show completion message, otherwise show exception
                If String.IsNullOrEmpty(exceptionAddItem) Then
                    output = String.Format("Succesfully added {0} to selected loot tables in Version {1} (NBT: {2})", fullItemName, version, nbtTag)
                Else
                    output = String.Format("Error: {0}", exceptionAddItem)
                End If
                exceptionAddItem = ""

            Else
                'If duplicate exists show option to either ignore it or cancel 
                Select Case MsgBox(String.Format("The item you are trying To add ({0}) already exists In the datapack.{1}Are you sure you want To add it again? This will result In duplicates.", fullItemName, vbNewLine), vbExclamation + vbYesNo, "Warning")
                    Case Windows.Forms.DialogResult.Yes
                        ignoreDuplicates = True
                        AddItem(itemID, itemAmount, version, lootTable)
                    Case Windows.Forms.DialogResult.No
                        ignoreDuplicates = False
                        duplicateDetected = True
                        output = String.Format("Cancelled adding {0} To {1} In Version {2} (NBT: {3})", fullItemName, lootTable, version, nbtTag)
                        totalDuplicatesIgnored = totalDuplicatesIgnored + 1
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
                WriteToLog(String.Format("Found settings version {0}", loadedSettingsVersion), "Info")

                'Resize array so all settings can fit in it (Array size = Amount of lines that the settings file should have)
                ReDim Preserve settingsArray(22)
                ConvertSettings(settingsFile)
            Catch ex As Exception
                MsgBox(String.Format("Error when loading settings: {0}", ex.Message), MsgBoxStyle.Critical, "Error")
                WriteToLog(String.Format("Error when loading settings: {0}", ex.Message), "Error")
            End Try

        Else
            'Show error and create new settings file if none exists
            WriteToLog(String.Format("Could not find settings file. Creating a new one (Version {0}).", settingsVersion), "Warning")
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

            MsgBox(String.Format("Could not load settings: {0}", ex.Message), MsgBoxStyle.Critical, "Error")
            WriteToLog(String.Format("Could not load settings: {0}", ex.Message), "Error")

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

        'Change position and dimensions of some controls
        cbEnableAdvancedView.Top = 677
        cbEnableAdvancedView.Left = 42
        cbAddItemsFast.Top = 651
        cbAddItemsFast.Left = 42
        Width = 735
        Height = 847
        gbItemID.Height = 140
        gbItemID.Width = 259

        WriteToLog("Enabled advanced view.", "Info")
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

        cbAddItemsFast.Top = 532
        cbAddItemsFast.Left = 320
        cbEnableAdvancedView.Top = 560
        cbEnableAdvancedView.Left = 320
        Width = 735
        Height = 732
        gbItemID.Height = 140
        gbItemID.Width = 429

        WriteToLog("Disabled advanced view.", "Info")
    End Sub

    Private Sub AddMultipleItems()
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
        If creativeOnly = False Then
            commandBlock = False
            otherCreativeOnlyItem = False
            spawnEgg = False
        End If

        'Beginn adding items for the specific version if string is not empty

        If String.IsNullOrEmpty(item) = False Then

            If datapackVersion = "Version 1.16.2 - 1.16.5" Then

                'Add item to loot tables for 1 item
                If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                    AddItem(item, "1", "1.16", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 2 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 3 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 5 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 10 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 32 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 64 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.16", "tipped_arrows")
                End If

                'Add item to loot table for random amount of same items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.16", "tipped_arrows")
                End If

                'Add item to loot table for random amount of different items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.16", "tipped_arrows")
                End If

            ElseIf datapackVersion = "Version 1.17 - 1.17.1" Then

                If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                    AddItem(item, "1", "1.17", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.17", "tipped_arrows")
                End If

            ElseIf datapackVersion = "Version 1.18 - 1.18.2" Then

                'Add item to loot tables for 1 item
                If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                    AddItem(item, "1", "1.18", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 2 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 3 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 5 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 10 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 32 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 64 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.18", "tipped_arrows")
                End If

            ElseIf datapackVersion = "Version 1.19 - 1.19.3" OrElse datapackVersion = "Version 1.19.4" OrElse datapackVersion = "Version 1.20" Then

                'Add item to loot tables for 1 item
                If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                    AddItem(item, "1", "1.19", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.19", "goat_horns")
                End If
                If datapackVersion = "1.19.4" OrElse datapackVersion = "1.20" Then
                    If painting And itemAddMode = "Normal" Then
                        AddItem(item, "1", "1.19", "paintings")
                    End If
                End If

                'Add item to loot tables for 2 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.19", "goat_horns")
                End If
                If datapackVersion = "1.19.4" OrElse datapackVersion = "1.20" Then
                    If painting And itemAddMode = "Normal" Then
                        AddItem(item, "2", "1.19", "paintings")
                    End If
                End If

                'Add item to loot tables for 3 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.19", "goat_horns")
                End If
                If datapackVersion = "1.19.4" OrElse datapackVersion = "1.20" Then
                    If painting And itemAddMode = "Normal" Then
                        AddItem(item, "3", "1.19", "paintings")
                    End If
                End If

                'Add item to loot tables for 5 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.19", "goat_horns")
                End If
                If datapackVersion = "1.19.4" OrElse datapackVersion = "1.20" Then
                    If painting And itemAddMode = "Normal" Then
                        AddItem(item, "5", "1.19", "paintings")
                    End If
                End If

                'Add item to loot tables for 10 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.19", "goat_horns")
                End If
                If datapackVersion = "1.19.4" OrElse datapackVersion = "1.20" Then
                    If painting And itemAddMode = "Normal" Then
                        AddItem(item, "10", "1.19", "paintings")
                    End If
                End If

                'Add item to loot tables for 32 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.19", "goat_horns")
                End If
                If datapackVersion = "1.19.4" OrElse datapackVersion = "1.20" Then
                    If painting And itemAddMode = "Normal" Then
                        AddItem(item, "32", "1.19", "paintings")
                    End If
                End If

                'Add item to loot tables for 64 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.19", "goat_horns")
                End If
                If datapackVersion = "1.19.4" OrElse datapackVersion = "1.20" Then
                    If painting And itemAddMode = "Normal" Then
                        AddItem(item, "64", "1.19", "paintings")
                    End If
                End If

                'Add item to loot tables for random amount of same items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.19", "goat_horns")
                End If
                If datapackVersion = "1.19.4" OrElse datapackVersion = "1.20" Then
                    If painting And itemAddMode = "Normal" Then
                        AddItem(item, "-1", "1.19", "paintings")
                    End If
                End If

                'Add item to loot tables for random amount of different items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.19", "goat_horns")
                End If
                If datapackVersion = "1.19.4" OrElse datapackVersion = "1.20" Then
                    If painting And itemAddMode = "Normal" Then
                        AddItem(item, "-2", "1.19", "paintings")
                    End If
                End If

            ElseIf datapackVersion = "Version 1.20.1" Then

                'Add item to loot tables for 1 item
                If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                    AddItem(item, "1", "1.20.1", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.1", "paintings")
                End If

                'Add item to loot tables for 2 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.1", "paintings")
                End If

                'Add item to loot tables for 3 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.1", "paintings")
                End If

                'Add item to loot tables for 5 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.1", "paintings")
                End If

                'Add item to loot tables for 10 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.1", "paintings")
                End If

                'Add item to loot tables for 32 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.1", "paintings")
                End If

                'Add item to loot tables for 64 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.1", "paintings")
                End If

                'Add item to loot tables for random amount of same items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.1", "paintings")
                End If

                'Add item to loot tables for random amount of different items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "main")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "main_without_creative-only")
                End If
                If commandBlock = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "special_vxx")
                End If
                If otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "special_vvx")
                End If
                If spawnEgg = False And otherCreativeOnlyItem = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "special_xvx")
                End If
                If spawnEgg = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "special_xvv")
                End If
                If spawnEgg = False And commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "special_xxv")
                End If
                If commandBlock = False And normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "special_vxv")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.1", "paintings")
                End If
            ElseIf datapackVersion = "Version 1.20.2 - 1.20.4" Then

                'Add item to loot tables for 1 item
                If normalItem And (itemAddMode = "Normal" Or itemAddMode = "Fast") Then
                    AddItem(item, "1", "1.20.2", "normal_items")
                End If
                If otherCreativeOnlyItem = True And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.2", "other_items")
                End If
                If spawnEgg = True And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.2", "spawn_eggs")
                End If
                If commandBlock = True And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.2", "command_blocks")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.2", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.2", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.2", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.2", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.2", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.2", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.2", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "1", "1.20.2", "paintings")
                End If

                'Add item to loot tables for 2 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.2", "normal_items")
                End If
                If otherCreativeOnlyItem = True And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.2", "other_items")
                End If
                If spawnEgg = True And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.2", "spawn_eggs")
                End If
                If commandBlock = True And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.2", "command_blocks")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.2", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.2", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.2", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.2", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.2", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.2", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.2", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "2", "1.20.2", "paintings")
                End If

                'Add item to loot tables for 3 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.2", "normal_items")
                End If
                If otherCreativeOnlyItem = True And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.2", "other_items")
                End If
                If spawnEgg = True And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.2", "spawn_eggs")
                End If
                If commandBlock = True And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.2", "command_blocks")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.2", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.2", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.2", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.2", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.2", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.2", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.2", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "3", "1.20.2", "paintings")
                End If

                'Add item to loot tables for 5 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.2", "normal_items")
                End If
                If otherCreativeOnlyItem = True And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.2", "other_items")
                End If
                If spawnEgg = True And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.2", "spawn_eggs")
                End If
                If commandBlock = True And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.2", "command_blocks")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.2", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.2", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.2", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.2", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.2", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.2", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.2", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "5", "1.20.2", "paintings")
                End If

                'Add item to loot tables for 10 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.2", "normal_items")
                End If
                If otherCreativeOnlyItem = True And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.2", "other_items")
                End If
                If spawnEgg = True And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.2", "spawn_eggs")
                End If
                If commandBlock = True And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.2", "command_blocks")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.2", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.2", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.2", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.2", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.2", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.2", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.2", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "10", "1.20.2", "paintings")
                End If

                'Add item to loot tables for 32 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.2", "normal_items")
                End If
                If otherCreativeOnlyItem = True And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.2", "other_items")
                End If
                If spawnEgg = True And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.2", "spawn_eggs")
                End If
                If commandBlock = True And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.2", "command_blocks")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.2", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.2", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.2", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.2", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.2", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.2", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.2", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "32", "1.20.2", "paintings")
                End If

                'Add item to loot tables for 64 items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.2", "normal_items")
                End If
                If otherCreativeOnlyItem = True And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.2", "other_items")
                End If
                If spawnEgg = True And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.2", "spawn_eggs")
                End If
                If commandBlock = True And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.2", "command_blocks")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.2", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.2", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.2", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.2", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.2", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.2", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.2", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "64", "1.20.2", "paintings")
                End If

                'Add item to loot tables for random amount of same items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.2", "normal_items")
                End If
                If otherCreativeOnlyItem = True And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.2", "other_items")
                End If
                If spawnEgg = True And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.2", "spawn_eggs")
                End If
                If commandBlock = True And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.2", "command_blocks")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.2", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.2", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.2", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.2", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.2", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.2", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.2", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "-1", "1.20.2", "paintings")
                End If

                'Add item to loot tables for random amount of different items
                If normalItem And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.2", "normal_items")
                End If
                If otherCreativeOnlyItem = True And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.2", "other_items")
                End If
                If spawnEgg = True And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.2", "spawn_eggs")
                End If
                If commandBlock = True And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.2", "command_blocks")
                End If
                If suspiciousStew And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.2", "suspicious_stews")
                End If
                If enchantedBook And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.2", "enchanted_books")
                End If
                If potion And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.2", "potions")
                End If
                If splashPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.2", "splash_potions")
                End If
                If lingeringPotion And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.2", "lingering_potions")
                End If
                If tippedArrow And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.2", "tipped_arrows")
                End If
                If goatHorn And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.2", "goat_horns")
                End If
                If painting And itemAddMode = "Normal" Then
                    AddItem(item, "-2", "1.20.2", "paintings")
                End If
            End If

            'Update And report workerprogress
            workerProgress = workerProgress + progressStep
            bgwAddItems.ReportProgress(workerProgress)
            Invoke(Sub() tbSmallOutput.Text = output)
            totalItemAmount = totalItemAmount - 1
            Invoke(Sub() lblItemsTotal.Text = String.Format("Adding items... ({0} items remaining)", totalItemAmount))
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
                               rtbLog.AppendText(String.Format("[{0}] [ERROR] {1}{2}", DateTime.Now, message, vbNewLine))
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.Red
                    rtbLog.AppendText(String.Format("[{0}] [ERROR] {1}{2}", DateTime.Now, message, vbNewLine))
                End If
            ElseIf type = "Info" Then
                If InvokeRequired = True Then
                    Invoke(Sub()
                               rtbLog.SelectionColor = Color.FromArgb(50, 177, 205)
                               rtbLog.AppendText(String.Format("[{0}] [INFO] {1}{2}", DateTime.Now, message, vbNewLine))
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.FromArgb(50, 177, 205)
                    rtbLog.AppendText(String.Format("[{0}] [INFO] {1}{2}", DateTime.Now, message, vbNewLine))
                End If
            ElseIf type = "Warning" Then
                If InvokeRequired = True Then
                    Invoke(Sub()
                               rtbLog.SelectionColor = Color.DarkOrange
                               rtbLog.AppendText(String.Format("[{0}] [WARNING] {1}{2}", DateTime.Now, message, vbNewLine))
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.DarkOrange
                    rtbLog.AppendText(String.Format("[{0}] [WARNING] {1}{2}", DateTime.Now, message, vbNewLine))
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
        If My.Computer.FileSystem.DirectoryExists(profileDirectory) = False Then
            My.Computer.FileSystem.CreateDirectory(profileDirectory)
            WriteToLog("Created profile directory", "Info")
        End If

        'Load profile files from specified directory
        GetProfileFiles(profileDirectory)

        'Load default profile if option is enabled
        If My.Settings.LoadDefaultProfile = True Then
            frmSettings.cbLoadDefaultProfile.Checked = True
            If String.IsNullOrEmpty(My.Settings.DefaultProfile) = False Then
                If My.Computer.FileSystem.FileExists(profileDirectory + My.Settings.DefaultProfile + ".txt") Then
                    cbxDefaultProfile.SelectedItem = My.Settings.DefaultProfile
                    frmLoadProfileFrom.InitializeLoadingProfile(cbxDefaultProfile.SelectedItem, False)
                    WriteToLog("Loaded default profile " + cbxDefaultProfile.SelectedItem, "Info")
                Else
                    frmSettings.Show()
                    frmSettings.cbLoadDefaultProfile.Checked = False
                    My.Settings.LoadDefaultProfile = False
                    frmSettings.SaveSettings(String.Format("{0}/Random Item Giver Updater Legacy/settings.txt", appData))
                    frmSettings.Close()
                    WriteToLog("Error when loading profile: Default profile doesn't exist. Disabled 'Load profile by default' option.", "Error")
                End If
            Else
                frmSettings.Show()
                frmSettings.cbLoadDefaultProfile.Checked = False
                My.Settings.LoadDefaultProfile = False
                frmSettings.SaveSettings(String.Format("{0}/Random Item Giver Updater Legacy/settings.txt", appData))
                frmSettings.Close()
                WriteToLog("Error when loading profile: Default profile is empty. Disabled 'Load profile by default' option.", "Error")
            End If
        Else
            WriteToLog("No default profile selected.", "Info")
        End If

        WriteToLog("Completed loading profiles!", "Info")
        WriteToLog("Loading schemes...", "Info")

        'Check if scheme directory exists
        If My.Computer.FileSystem.DirectoryExists(schemeDirectory) = False Then
            My.Computer.FileSystem.CreateDirectory(schemeDirectory)
        End If

        'Clear list of already existing schemes and load new list of schemes
        cbxScheme.Items.Clear()
        GetSchemeFiles(schemeDirectory)

        'Select default scheme if enabled
        If My.Settings.SelectDefaultScheme = True Then
            frmSettings.cbSelectDefaultScheme.Checked = True
            If String.IsNullOrEmpty(My.Settings.DefaultScheme) = False Then
                If My.Computer.FileSystem.FileExists(String.Format("{0}{1}.txt", schemeDirectory, My.Settings.DefaultScheme)) Then
                    cbxScheme.SelectedItem = My.Settings.DefaultScheme
                Else
                    frmSettings.Show()
                    frmSettings.cbSelectDefaultScheme.Checked = False
                    My.Settings.SelectDefaultScheme = False
                    frmSettings.SaveSettings(String.Format("{0}/Random Item Giver Updater Legacy/settings.txt", appData))
                    frmSettings.Close()
                    WriteToLog("Error when loading scheme: Default scheme doesn't exist. Disabled 'Select scheme by default' option.", "Error")
                End If
            Else
                frmSettings.Show()
                frmSettings.cbSelectDefaultScheme.Checked = False
                My.Settings.SelectDefaultScheme = False
                frmSettings.SaveSettings(String.Format("{0}/Random Item Giver Updater Legacy/settings.txt", appData))
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
                    Profile = Profile.Replace(path, "")
                    Profile = Profile.Replace(".txt", "")
                    cbxDefaultProfile.Items.Add(Profile)
                End If
            Next
        Catch ex As Exception
            MsgBox(String.Format("Error: Could not load profiles. Please try again.{0}Exception: {1}", vbNewLine, ex.Message), MsgBoxStyle.Critical, "Error")
            WriteToLog(String.Format("Error when loading profiles for Main Window: {0}", ex.Message), "Error")
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
                    Scheme = Scheme.Replace(path, "")
                    Scheme = Scheme.Replace(".txt", "")
                    cbxScheme.Items.Add(Scheme)
                End If
            Next
        Catch ex As Exception
            MsgBox(String.Format("Error: Could not load schemes. Please try again.{0}Exception: {1}", vbNewLine, ex.Message), MsgBoxStyle.Critical, "Error")
            WriteToLog(String.Format("Error when loading schemes for Main Window: {0}", ex.Message), "Error")
        End Try
    End Sub

    Public Sub AddDefaultSchemes() 'Creates profiles for the default schemes. Overwrites existing ones.
        'Normal Item
        My.Computer.FileSystem.WriteAllText(schemeDirectory + "Normal Item" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Suspicious Stew
        My.Computer.FileSystem.WriteAllText(schemeDirectory + "Suspicious Stew" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Enchanted Book
        My.Computer.FileSystem.WriteAllText(schemeDirectory + "Enchanted Book" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Potion
        My.Computer.FileSystem.WriteAllText(schemeDirectory + "Potion" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Splash Potion
        My.Computer.FileSystem.WriteAllText(schemeDirectory + "Splash Potion" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Lingering Potion
        My.Computer.FileSystem.WriteAllText(schemeDirectory + "Lingering Potion" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Tipped Arrow
        My.Computer.FileSystem.WriteAllText(schemeDirectory + "Tipped Arrow" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Goat Horn
        My.Computer.FileSystem.WriteAllText(schemeDirectory + "Goat Horn" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Spawn Egg
        My.Computer.FileSystem.WriteAllText(schemeDirectory + "Spawn Egg" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Command Block
        My.Computer.FileSystem.WriteAllText(schemeDirectory + "Command Block" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False", False)

        'Other Creative-Only Item
        My.Computer.FileSystem.WriteAllText(schemeDirectory + "Other Creative-Only Item" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False", False)

        'Painting
        My.Computer.FileSystem.WriteAllText(schemeDirectory + "Painting" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True", False)

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
End Class