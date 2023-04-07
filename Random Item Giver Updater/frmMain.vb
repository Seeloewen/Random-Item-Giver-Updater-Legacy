Imports System.Environment
Imports System.IO

Public Class frmMain

    'General variables for the software
    Public qm As String 'Quotation mark
    Public appData As String = GetFolderPath(SpecialFolder.ApplicationData) 'Appdata directory
    Public versionLog As String = "0.5.0-b (12.03.2023)" 'Version that gets displayed in the log
    Public rawVersion As String = "0.5.0-b"
    Public settingsVersion As Double = 3 'Current version of the settings file that the app is using
    Dim settingsArray As String() 'Array which the settings will be loaded in
    Dim loadedSettingsVersion As Double 'Version of the settings file that gets loaded
    Dim firstLoadCompleted As Boolean = False 'Whether application is loaded or not. Used for the datapack version detection.
    Dim actionRunning As Boolean = False 'Whether an action is running or not
    Dim settingsFile As String = appData + "\Random Item Giver Updater\settings.txt" 'Location of the settings file
    Public logDirectory As String = appData + "\Random Item Giver Updater\Logs\"
    Dim logFileName As String

    'Profile variables
    Public profileDirectory As String = appData + "\Random Item Giver Updater\Profiles\" 'Directory where the profiles are located
    Dim profileList As String() 'Contains a list of loaded profiles

    'Scheme variables
    Public schemeDirectory As String = appData + "\Random Item Giver Updater\Schemes\" 'Directory where the schemes are located
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


    '-- Event handlers --

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Add click event of frmMain to every control in frmMain
        For Each ctrl As Control In Controls
            If Not ctrl.Equals(btnHamburger) Then
                AddHandler ctrl.Click, AddressOf frmMain_MouseClick
            End If
        Next

        'Set appearance of buttons depending on selected design
        For Each btn As Button In Controls.OfType(Of Button)
            If Not btn.Equals(btnHamburger) Then
                If My.Settings.Design = "Dark" Then
                    btn.ForeColor = Color.White
                    btn.BackgroundImage = My.Resources.imgButton
                ElseIf My.Settings.Design = "Light" Then
                    btn.ForeColor = Color.Black
                    btn.BackgroundImage = My.Resources.imgButtonLight
                End If
            End If
            If (Not btn.Equals(btnHamburger)) And (Not btn.Equals(btnAddItem)) Then
                If My.Settings.Design = "Light" Then
                    btn.BackColor = Color.FromArgb(207, 207, 207)
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(207, 207, 207)
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(207, 207, 207)
                ElseIf My.Settings.Design = "Dark" Then
                    btn.BackColor = Color.FromArgb(127, 127, 127)
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(127, 127, 127)
                    btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(127, 127, 127)
                End If
            End If
        Next

        'Create directory in appdata if it doesnt exist already
        If My.Computer.FileSystem.DirectoryExists(AppData + "\Random Item Giver Updater\") = False Then
            My.Computer.FileSystem.CreateDirectory(AppData + "\Random Item Giver Updater\")
            WriteToLog("Created the 'Random Item Giver Updater' directory in the Appdata folder for application files.", "Info")
        End If

        'Post initial log text
        WriteToLog("Random Item Giver Updater " + VersionLog, "Info")
        WriteToLog("You are running a beta build, issues may occur!", "Warning")

        'If software gets started for the first time, add default schemes and create file that indicates that the software was started once already.
        If My.Computer.FileSystem.FileExists(AppData + "\Random Item Giver Updater\FirstStartCompleted") = False Then
            My.Computer.FileSystem.WriteAllText(AppData + "\Random Item Giver Updater\FirstStartCompleted", "", False)
            If My.Computer.FileSystem.DirectoryExists(SchemeDirectory) = False Then
                My.Computer.FileSystem.CreateDirectory(SchemeDirectory)
            End If
            AddDefaultSchemes()
        End If

        'Initialize User Settings and Preferences
        InitializeLoadingSettings()
        InitializeProfilesAndSchemes()
        LoadDarkmode()

        'Disable log if setting is enabled
        If My.Settings.DisableLogging = True Then
            frmOutput.rtbLog.Clear()
            If My.Computer.FileSystem.FileExists(AppData + "\Random Item Giver Updater\DebugLogTemp") Then
                My.Computer.FileSystem.DeleteFile(AppData + "\Random Item Giver Updater\DebugLogTemp")
            End If
        End If

        'Hide Beta Warning if setting is enabled
        If My.Settings.HideAlphaWarning = False Then
            MsgBox("Warning: You are running a beta version of the Random Item Giver Updater." + vbNewLine + vbNewLine + "You have to expect to find bugs or other issues." + vbNewLine + vbNewLine + "Please give as much feedback as possible so the software can be improved!" + vbNewLine + vbNewLine + "Things normally shouldn't break, though use this software at your own risk and with caution.", MsgBoxStyle.Exclamation, "Warning")
        End If

        'Define several variables (I know I could probably do this way easier but... yeah)
        qm = Quotationmark.Text
        CodeEnd = rtbCodeEnd.Lines
        Items2 = rtbItems2.Lines
        Items3 = rtbItems3.Lines
        Items5 = rtbItems5.Lines
        Items10 = rtbItems10.Lines
        Items32 = rtbItems32.Lines
        Items64 = rtbItems64.Lines
        ItemsRandomSame116 = rtbItemsRandomSame116.Lines
        ItemsRandomSame119 = rtbItemsRandomSame119.Lines

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
            addItemResult = "NONE"

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
        'Checks if there are more than 99 Items being added while AddItemsFast is disabled and will show a warning if thats the case
        If itemsList.Count > 99 And addItemsFast = False Then
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

                    WriteToLog("Adding " + totalItemAmount.ToString + " items...", "Info")

                    'Calculate ProgressStep
                    progressStep = 100 / itemsList.Count

                    'Start adding the items
                    AddMultipleItems()

                    'Set result after items where added.
                    addItemResult = "success"
            End Select
        Else
            'Sets ItemAddMode
            If addItemsFast Then
                itemAddMode = "Fast"
            Else
                itemAddMode = "Normal"
            End If

            'Resets variables used to detect duplicates
            ignoreDuplicates = False
            duplicateDetected = False

            'Start the corresponding method for adding items depending on the amount. Will also calculate ProgressStep and post result afterwards.
            If itemsList.Length = 1 Then
                item = itemsList(0)
                WriteToLog("Adding " + totalItemAmount.ToString + " items...", "Info")
                progressStep = 100 / itemsList.Count
                CallAddItem()
                addItemResult = "success"
            ElseIf itemsList.Length = 0 Then
            Else
                WriteToLog("Adding " + totalItemAmount.ToString + " items...", "Info")
                progressStep = 100 / itemsList.Count
                AddMultipleItems()
                addItemResult = "success"
            End If
        End If
    End Sub

    Private Sub rtbLog_TextChanged(sender As Object, e As EventArgs) Handles rtbLog.TextChanged
        'Updadte log file and log in output window
        rtbLog.SaveFile(AppData + "\Random Item Giver Updater\DebugLogTemp")
        frmOutput.rtbLog.LoadFile(AppData + "\Random Item Giver Updater\DebugLogTemp")
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
            SamePrefix = True
        Else
            tbSamePrefix.Enabled = False
            gbItemID.Text = "Items (Prefix:ID)"
            SamePrefix = False
        End If
    End Sub

    Private Sub cbNBT_CheckedChanged(sender As Object, e As EventArgs) Handles cbCustomNBT.CheckedChanged
        'Toggle the custom NBT tag setting
        If cbCustomNBT.Checked Then
            tbCustomNBT.Enabled = True
            CustomNBT = True
        Else
            tbCustomNBT.Enabled = False
            CustomNBT = False
        End If
    End Sub

    Private Sub cbCreativeOnly_CheckedChanged(sender As Object, e As EventArgs) Handles cbCreativeOnly.CheckedChanged
        'Toggle the creative-only setting
        If cbCreativeOnly.Checked Then
            CreativeOnly = True
            rbtnOtherItem.Enabled = True
            rbtnCommandBlock.Enabled = True
            rbtnSpawnEgg.Enabled = True
        Else
            CreativeOnly = False
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
            AddItemsFast = True
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
            MsgBox("This setting speeds up the process of adding items, narrowing it down to only a few seconds in most cases." + vbNewLine + "This is recommended if you need to add 100+ Items." + vbNewLine + vbNewLine + "Please note that if you enable this option, the items will only be added to the main loot table. This means that you won't be able to use the item settings in the datapack afterwards.", MsgBoxStyle.Information, "Enable Fast Item Adding")
        Else
            AddItemsFast = False
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
            cbGoatHorn.Enabled = True
            cbGoatHorn.Checked = False
            cbCustomNBT.Enabled = True
            cbCustomNBT.Checked = False
        End If
    End Sub

    Private Sub rtbItem_TextChanged(sender As Object, e As EventArgs) Handles rtbItem.TextChanged
        'Pass text onto the variable
        ItemsList = rtbItem.Lines

        'Check the amount of items (lines) and change recommendation of checkbox for fast item adding
        If rtbItem.Lines.Count > 99 Then
            cbAddItemsFast.Text = "Enable Fast Item Adding (Recommended)"
        ElseIf rtbItems10.Lines.Count < 99 Then
            cbAddItemsFast.Text = "Enable Fast Item Adding (Not recommended)"
        End If

        'Display amount of items in the total items label
        lblItemsTotal.Text = "Total amount of items: " + rtbItem.Lines.Count.ToString
    End Sub

    Private Sub tbSamePrefix_TextChanged(sender As Object, e As EventArgs) Handles tbSamePrefix.TextChanged
        'Pass text onto the variable
        SamePrefixString = tbSamePrefix.Text
    End Sub

    Private Sub tbCustomNBT_TextChanged(sender As Object, e As EventArgs) Handles tbCustomNBT.TextChanged
        'Pass text onto the variable
        CustomNBTString = tbCustomNBT.Text
    End Sub

    Private Sub cbNormalItem_CheckedChanged(sender As Object, e As EventArgs) Handles cbNormalItem.CheckedChanged
        'Pass checkstate onto the variable
        NormalItem = cbNormalItem.CheckState
    End Sub

    Private Sub cbSuspiciousStew_CheckedChanged(sender As Object, e As EventArgs) Handles cbSuspiciousStew.CheckedChanged
        'Pass checkstate onto the variable
        SuspiciousStew = cbSuspiciousStew.CheckState
    End Sub

    Private Sub cbEnchantedBook_CheckedChanged(sender As Object, e As EventArgs) Handles cbEnchantedBook.CheckedChanged
        'Pass checkstate onto the variable
        EnchantedBook = cbEnchantedBook.CheckState
    End Sub

    Private Sub cbPotion_CheckedChanged(sender As Object, e As EventArgs) Handles cbPotion.CheckedChanged
        'Pass checkstate onto the variable
        Potion = cbPotion.CheckState
    End Sub

    Private Sub cbSplashPotion_CheckedChanged(sender As Object, e As EventArgs) Handles cbSplashPotion.CheckedChanged
        'Pass checkstate onto the variable
        SplashPotion = cbSplashPotion.CheckState
    End Sub
    Private Sub cbLingeringPotion_CheckedChanged(sender As Object, e As EventArgs) Handles cbLingeringPotion.CheckedChanged
        'Pass checkstate onto the variable
        LingeringPotion = cbLingeringPotion.CheckState
    End Sub

    Private Sub cbTippedArrow_CheckedChanged(sender As Object, e As EventArgs) Handles cbTippedArrow.CheckedChanged
        'Pass checkstate onto the variable
        TippedArrow = cbTippedArrow.CheckState
    End Sub

    Private Sub cbGoatHorn_CheckedChanged(sender As Object, e As EventArgs) Handles cbGoatHorn.CheckedChanged
        'Pass checkstate onto the variable
        GoatHorn = cbGoatHorn.CheckState
    End Sub

    Private Sub cbPainting_CheckedChanged(sender As Object, e As EventArgs) Handles cbPainting.CheckedChanged
        'Pass checkstate onto the variable
        Painting = cbPainting.CheckState
    End Sub

    Private Sub rbtnSpawnEgg_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSpawnEgg.CheckedChanged
        'Pass checkstate onto the variable
        If rbtnSpawnEgg.Checked Then
            SpawnEgg = True
        Else
            SpawnEgg = False
        End If
    End Sub

    Private Sub rbtnCommandBlock_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCommandBlock.CheckedChanged
        'Pass checkstate onto the variable
        If rbtnCommandBlock.Checked Then
            CommandBlock = True
        Else
            CommandBlock = False
        End If
    End Sub

    Private Sub rbtnOtherItem_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOtherItem.CheckedChanged
        'Pass checkstate onto the variable
        If rbtnOtherItem.Checked Then
            OtherCreativeOnlyItem = True
        Else
            OtherCreativeOnlyItem = False
        End If
    End Sub

    Private Sub tbDatapackPath_TextChanged(sender As Object, e As EventArgs) Handles tbDatapackPath.TextChanged
        'Pass checkstate onto the variable
        DatapackPath = tbDatapackPath.Text
        If FirstLoadCompleted Then
            DetermineDatapackVersion()
        End If
    End Sub

    Private Sub cbxVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxVersion.SelectedIndexChanged
        'Pass text onto the variable
        DatapackVersion = cbxVersion.SelectedItem

        'Toggle certain checkboxes depending on selected version
        If DatapackVersion = "Version 1.19.4" Then
            cbPainting.Enabled = True
            cbGoatHorn.Enabled = True
        ElseIf DatapackVersion = "Version 1.19 - 1.19.3" Then
            cbPainting.Enabled = False
            cbGoatHorn.Enabled = True
        ElseIf DatapackVersion = "Version 1.18 - 1.18.2" Then
            cbPainting.Enabled = False
            cbGoatHorn.Enabled = False
        ElseIf DatapackVersion = "Version 1.17 - 1.17.1" Then
            cbPainting.Enabled = False
            cbGoatHorn.Enabled = False
        ElseIf DatapackVersion = "Version 1.16.2 - 1.16.5" Then
            cbPainting.Enabled = False
            cbGoatHorn.Enabled = False
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
        If cbxVersion.SelectedItem = "Version 1.19.4" Then
            cbPainting.Enabled = True
            cbGoatHorn.Enabled = True
        ElseIf cbxVersion.SelectedItem = "Version 1.19 - 1.19.3" Then
            cbGoatHorn.Enabled = True
        End If

        'If result is "success" show messagebox. This variable would've been changed if an error occured.
        If AddItemResult = "success" Then
            MsgBox("Successfully added " + rtbItem.Lines.Count.ToString + " item(s)!", MsgBoxStyle.Information, "Added items")
            WriteToLog("Successfully added  " + rtbItem.Lines.Count.ToString + " items", "Info")
        End If

        'Show 'Add item to datapack' button which also hides the progress bar and show total amount of items in richtextbox again
        btnAddItem.Show()
        lblItemsTotal.Text = "Total amount of items: " + rtbItem.Lines.Count.ToString
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
        frmLoadProfileFrom.ShowDialog()
    End Sub

    Private Sub btnSaveProfile_Click(sender As Object, e As EventArgs) Handles btnSaveProfile.Click
        'Open the Save profile dialog
        frmSaveProfileAs.ShowDialog()
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        'When starting the application, run initial datapack detection and set firstloadcompleted to true. This variable is used to determine whether the startup process has been completed
        DetermineDatapackVersion()
        FirstLoadCompleted = True
    End Sub

    Private Sub cbxScheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxScheme.SelectedIndexChanged
        'Starts the whole loading process of the scheme
        InitializeLoadingScheme(cbxScheme.SelectedItem, False)
    End Sub

    Private Sub btnDeleteSelectedScheme_Click(sender As Object, e As EventArgs) Handles btnDeleteSelectedScheme.Click
        'Delete the currently selected scheme if it exists
        If My.Computer.FileSystem.FileExists(SchemeDirectory + cbxScheme.SelectedItem + ".txt") Then
            My.Computer.FileSystem.DeleteFile(SchemeDirectory + cbxScheme.SelectedItem + ".txt")
            MsgBox("Scheme was deleted.", MsgBoxStyle.Information, "Deleted")
            WriteToLog("Deleted scheme " + cbxScheme.SelectedItem, "Info")
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
            LogFileName = "Random_Item_Giver_Updater_Log_" + DateTime.Now + "_Ver_" + VersionLog
            LogFileName = LogFileName.Replace(":", "-")
            LogFileName = LogFileName.Replace(".", "-")
            LogFileName = LogFileName.Replace(" ", "_")
            LogFileName = LogFileName.Replace("(", "")
            LogFileName = LogFileName.Replace(")", "")
            LogFileName = LogDirectory + LogFileName + ".txt"
            frmOutput.SaveLog(LogFileName, False)
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

    Private Sub DToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DocumentaryToolStripMenuItem.Click
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

    '-- Custom methods --

    Private Sub LoadDarkmode()
        If My.Settings.Design = "Dark" Then
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
    End Sub

    Private Sub CheckForFirstStart()
        'Check if application was already started once using this version. If not, show update news
        If My.Computer.FileSystem.FileExists(AppData + "\Random Item Giver Updater\FirstStart_" + RawVersion) = False Then
            My.Computer.FileSystem.WriteAllText(AppData + "\Random Item Giver Updater\FirstStart_" + RawVersion, "", False)
            frmUpdateNews.ShowDialog()
        End If
    End Sub

    Public Sub InitializeLoadingScheme(scheme As String, showMessage As Boolean)
        'Checks if a scheme is selected. It then reads the content of the scheme file into the array. To avoid errors with the array being too small, it gets resized. The number represents the amount of settings.
        'It then starts to convert and load the scheme, see the the method below.
        If String.IsNullOrEmpty(scheme) = False Then
            loadFromScheme = schemeDirectory + scheme + ".txt"
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
                    WriteToLog("Loaded and updated scheme " + scheme, "Info")
                Case Windows.Forms.DialogResult.No
                    MsgBox("Cancelled loading scheme.", MsgBoxStyle.Exclamation, "Warning")
            End Select
        Else
            LoadScheme(scheme, showMessage)
            WriteToLog("Loaded scheme " + scheme, "Info")
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
            MsgBox("Loaded scheme " + scheme + ".", MsgBoxStyle.Information, "Loaded profile")
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
                My.Computer.FileSystem.WriteAllText(schemeDirectory + schemeName + ".txt", samePrefix.ToString + vbNewLine + samePrefixString + vbNewLine + customNBT.ToString + vbNewLine + customNBTString + vbNewLine + normalItem.ToString + vbNewLine + suspiciousStew.ToString + vbNewLine + enchantedBook.ToString + vbNewLine + potion.ToString + vbNewLine + splashPotion.ToString + vbNewLine + lingeringPotion.ToString + vbNewLine + tippedArrow.ToString + vbNewLine + goatHorn.ToString + vbNewLine + creativeOnly.ToString + vbNewLine + spawnEgg.ToString + vbNewLine + commandBlock.ToString + vbNewLine + otherCreativeOnlyItem.ToString + vbNewLine + painting.ToString + vbNewLine, False)
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

                Dim versionString As String = System.IO.File.ReadAllLines(tbDatapackPath.Text + "/pack.mcmeta")(2)
                Dim parseVersion As String = Replace(VersionString, "    " + qm + "pack_format" + qm + ": ", "")
                Dim version As String = Replace(ParseVersion, ",", "")

                Try
                    If Convert.ToInt32(Version) > 11 Then
                        lblDatapackDetection.Text = "Detected datapack, but could not determine version"
                        MsgBox("A datapack has been detected but the Version number is greater than 11." + vbNewLine + "This means that the datapack is possibly newer than the software supports." + vbNewLine + "The newest available version in the software has been selected but is not guaranteed to work.", MsgBoxStyle.Exclamation, "Warning")
                        WriteToLog("Detected unsupported datapack version. This may cause issues.", "Warning")
                        cbxVersion.SelectedItem = "Version 1.19.4"
                    ElseIf Version = "11" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.19.4."
                        WriteToLog("Detected datapack version 1.19.4.", "Info")
                        cbxVersion.SelectedItem = "Version 1.19.4"
                    ElseIf Version = "10" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.19 - 1.19.3."
                        WriteToLog("Detected datapack version 1.19 - 1.19.3.", "Info")
                        cbxVersion.SelectedItem = "Version 1.19 - 1.19.3"
                    ElseIf Version = "9" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.18.2."
                        WriteToLog("Detected datapack version 1.18.2.", "Info")
                        cbxVersion.SelectedItem = "Version 1.18 - 1.18.2"
                    ElseIf Version = "8" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.18 - 1.18.1. Please note that your version of 1.18 is outdated."
                        WriteToLog("Detected datapack version 1.18 - 1.18.1.", "Info")
                        cbxVersion.SelectedItem = "Version 1.18 - 1.18.2"
                    ElseIf Version = "7" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.17 - 1.17.1."
                        WriteToLog("Detected datapack version 1.17 - 1.17.1.", "Info")
                        cbxVersion.SelectedItem = "Version 1.17 - 1.17.1"
                    ElseIf Version = "6" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.16.2 - 1.16.5."
                        WriteToLog("Detected datapack version 1.16.2 - 1.16.5.", "Info")
                        cbxVersion.SelectedItem = "Version 1.16.2 - 1.16.5"
                    ElseIf Convert.ToInt32(Version) < 6 Then
                        lblDatapackDetection.Text = "Detected datapack, but version is most likely unsupported"
                        MsgBox("A datapack has been detected but the version number is smaller than 6." + vbNewLine + "This means that the datapack version is older than 1.15 which the Random Item Giver does not support." + vbNewLine + "The oldest available version has been selected but will most likely not work.", MsgBoxStyle.Exclamation, "Warning")
                        WriteToLog("Detected unsupported datapack version. This may cause issues.", "Warning")
                        cbxVersion.SelectedItem = "Version 1.16.2 - 1.16.5"
                    Else
                        lblDatapackDetection.Text = "Detected datapack, but could not determine version."
                        WriteToLog("Detected datapack, couldn't determine version.", "Error")
                    End If
                Catch ex As Exception
                    MsgBox("Error when selecting datapack: " + ex.Message, MsgBoxStyle.Critical, "Error")
                    lblDatapackDetection.Text = "Detected datapack, but could not determine version."
                    WriteToLog("Detected datapack, couldn't determine version.", "Error")
                    cbxVersion.SelectedItem = "Version 1.19.4"
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
                nbtTag = customNBTString.Replace(qm, "\" + qm) 'Fix quotiation marks in NBT tags
            Else
                nbtTag = "NONE"
            End If

            'Determine the full item name based on the item ID
            If samePrefix = True Then
                prefix = samePrefixString
                fullItemName = prefix + ":" + itemID
            Else
                fullItemName = itemID
            End If

            'Define ItemAmountPath depending on itemAmount
            If itemAmount = 1 Then
                itemAmountPath = "1item\"
            ElseIf itemAmount = "-1" Then
                itemAmountPath = "randomamountsameitem\"
            ElseIf itemAmount = "-2" Then
                itemAmountPath = "randomamountdifitems\"
            ElseIf itemAmount > 1 Then
                itemAmountPath = itemAmount.ToString + "sameitems\"
            End If


            'Check if item you want to add already exists
            If My.Computer.FileSystem.FileExists(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json") Then
                fileTemp = My.Computer.FileSystem.ReadAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + itemAmountPath + lootTable + ".json")
            End If

            'If the item you want to add does not exist or duplicates are ignored add items depending on version and loot table
            If fileTemp.Contains(qm + fullItemName + qm) = False Or ignoreDuplicates = True Then
                Try
                    If version = "1.16" OrElse version = "1.18" OrElse version = "1.19" Then

                        If itemAmount = 1 Then
                            lineRemoveLoop = 8

                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\1item\" + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\1item\" + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()

                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\1item\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\1item\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\1item\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "goat_horns" OrElse lootTable = "paintings" And version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\1item\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 2 Then
                            lineRemoveLoop = 8

                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\2sameitems\" + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\2sameitems\" + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()

                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\2sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items2) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\2sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items2) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\2sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items2) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "goat_horns" OrElse lootTable = "paintings" And version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\2sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items2) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 3 Then
                            lineRemoveLoop = 8

                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\3sameitems\" + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\3sameitems\" + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()

                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\3sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items3) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\3sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items3) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\3sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items3) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "goat_horns" OrElse lootTable = "paintings" And version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\3sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items3) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 5 Then
                            lineRemoveLoop = 8

                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\5sameitems\" + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\5sameitems\" + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()

                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\5sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items5) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\5sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items5) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\5sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items5) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "goat_horns" OrElse lootTable = "paintings" And version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\5sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items5) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 10 Then
                            lineRemoveLoop = 8

                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\10sameitems\" + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\10sameitems\" + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()

                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\10sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items10) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\10sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items10) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\10sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items10) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "goat_horns" OrElse lootTable = "paintings" And version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\10sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items10) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 32 Then
                            lineRemoveLoop = 8

                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\32sameitems\" + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\32sameitems\" + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()

                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\32sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items32) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\32sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items32) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\32sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items32) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "goat_horns" OrElse lootTable = "paintings" And version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\32sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items32) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = 64 Then
                            lineRemoveLoop = 8

                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\64sameitems\" + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\64sameitems\" + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()

                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\64sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items64) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\64sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items64) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\64sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items64) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "goat_horns" OrElse lootTable = "paintings" And version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\64sameitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(items64) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = "-1" And version = "1.16" Then
                            lineRemoveLoop = 8

                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()

                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(itemsRandomSame116) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(itemsRandomSame116) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(itemsRandomSame116) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "goat_horns" OrElse lootTable = "paintings" And version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(itemsRandomSame116) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = "-1" And version = "1.19" Then
                            lineRemoveLoop = 8

                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()

                                lineRemoveLoop = lineRemoveLoop - 1
                            End While

                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(itemsRandomSame119) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(itemsRandomSame119) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(itemsRandomSame119) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "goat_horns" OrElse lootTable = "paintings" And version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + ReturnArrayAsString(itemsRandomSame119) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            End If

                        ElseIf itemAmount = "-2" And (version = "1.16" OrElse version = "1.19") Then
                            lineRemoveLoop = 8

                            While lineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\randomamountdifitems\" + lootTable + ".json")
                                Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\randomamountdifitems\" + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                                editFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                                FileStreamEditFile.Close()

                                lineRemoveLoop = lineRemoveLoop - 1
                            End While
                            If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\randomamountdifitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\randomamountdifitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "suspicious_stews" OrElse lootTable = "enchanted_books" OrElse lootTable = "potions" OrElse lootTable = "splash_potions" OrElse lootTable = "lingering_potions" OrElse lootTable = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\randomamountdifitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                            ElseIf lootTable = "goat_horns" OrElse lootTable = "paintings" And version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\randomamountdifitems\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
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

                        lineRemoveLoop = 8

                        While lineRemoveLoop > 0
                            Dim EditFileLines() As String = IO.File.ReadAllLines(datapackPath + "\data\randomitemgiver\loot_tables\" + lootTable + ".json")
                            Dim FileStreamEditFile As New FileStream(datapackPath + "\data\randomitemgiver\loot_tables\" + lootTable + ".json", FileMode.Open, FileAccess.ReadWrite)
                            editFileLastLineLength = EditFileLines.Last.Length.ToString

                            FileStreamEditFile.SetLength(FileStreamEditFile.Length - editFileLastLineLength)
                            FileStreamEditFile.Close()

                            lineRemoveLoop = lineRemoveLoop - 1
                        End While

                        If (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = False Then
                            My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + vbNewLine + ReturnArrayAsString(codeEnd), True)
                        ElseIf (lootTable = "main" OrElse lootTable = "main_without_creative-only" OrElse lootTable = "special_xvv" OrElse lootTable = "special_xvx" OrElse lootTable = "special_vvx" OrElse lootTable = "special_xxv" OrElse lootTable = "Special_xvv" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vvx" OrElse lootTable = "special_vxv" OrElse lootTable = "special_vxx") And cbCustomNBT.Checked = True Then
                            My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                        ElseIf lootTable = "suspicious_stew" OrElse lootTable = "enchanted_books" OrElse lootTable = "potion" OrElse lootTable = "splash_potion" OrElse lootTable = "lingering_potion" OrElse lootTable = "tipped_arrow" Then
                            My.Computer.FileSystem.WriteAllText(datapackPath + "\data\randomitemgiver\loot_tables\" + lootTable + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + fullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + nbtTag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(codeEnd), True)
                        End If

                    End If

                Catch Exception As Exception
                    exceptionAddItem = Exception.Message
                End Try

                'If not exception was found show completion message, otherwise show exception
                If String.IsNullOrEmpty(exceptionAddItem) Then
                    output = "Succesfully added " + fullItemName + " to selected loot tables in Version " + version + " (NBT: " + nbtTag + ")"
                Else
                    output = "Error: " + exceptionAddItem
                End If

            Else
                'If duplicate exists show option to either ignore it or cancel 
                Select Case MsgBox("The item you are trying To add (" + fullItemName + ") already exists In the datapack." + vbNewLine + "Are you sure you want To add it again? This will result In duplicates.", vbExclamation + vbYesNo, "Warning")
                    Case Windows.Forms.DialogResult.Yes
                        ignoreDuplicates = True
                        AddItem(itemID, itemAmount, version, lootTable)
                    Case Windows.Forms.DialogResult.No
                        ignoreDuplicates = False
                        duplicateDetected = True
                        output = "Cancelled adding " + fullItemName + " To " + lootTable + " In Version " + version + " (NBT: " + nbtTag + ")"
                End Select
            End If
        End If
    End Sub

    'This function is mainly used for debugging, returns an Array as a string
    Public Function ReturnArrayAsString(sourceArray As String())
        Dim FullString As String = ""
        For Each line As String In sourceArray
            FullString = FullString + line + vbNewLine
        Next
        FullString = FullString.Remove(FullString.Length - 2)
        Return FullString
    End Function

    'This function is mainly used for debugging, returns a List as a string
    Public Function ReturnListAsString(sourceList As List(Of String))
        Dim FullString As String = ""
        For Each line As String In sourceList
            FullString = FullString + line + vbNewLine
        Next
        FullString = FullString.Remove(FullString.Length - 2)
        Return FullString
    End Function

    Private Sub InitializeLoadingSettings()
        If My.Computer.FileSystem.FileExists(SettingsFile) Then
            Try
                'Try to load settings and determine version
                SettingsArray = File.ReadAllLines(SettingsFile)
                LoadedSettingsVersion = SettingsArray(1).Replace("Version=", "")
                WriteToLog("Found settings version " + LoadedSettingsVersion.ToString, "Info")

                'Resize array so all settings can fit in it (Array size = Amount of lines that the settings file should have)
                ReDim Preserve SettingsArray(22)
                ConvertSettings(SettingsFile)
            Catch ex As Exception
                MsgBox("Error when loading settings: " + ex.Message, MsgBoxStyle.Critical, "Error")
                WriteToLog("Error when loading settings: " + ex.Message, "Error")
            End Try

        Else
            'Show error and create new settings file if none exists
            WriteToLog("Could not find settings file. Creating a new one (Version " + SettingsVersion.ToString + ").", "Warning")
            My.Computer.FileSystem.WriteAllText(SettingsFile, "", False)
            frmSettings.SaveSettings(SettingsFile)
        End If

        'Check if log directory exists and create it if not
        If My.Computer.FileSystem.DirectoryExists(LogDirectory) = False Then
            My.Computer.FileSystem.CreateDirectory(LogDirectory)
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
                    If (settingsArray(0) = "#Random Item Giver Settings File") = False Then
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
                    If ((settingsArray(5) = "AutoSaveLogs=True" = False And settingsArray(4) = "AutoSaveLogs=False")) = False Then
                        settingsArray(5) = frmSettings.SettingsFilePreset.Lines(5)
                    End If
                    If ((settingsArray(5) = "Design=Light" = False And settingsArray(4) = "Design=Dark")) = False Then
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
                    If ((settingsArray(10) = "HideAlphaWarning=True" = False And settingsArray(10) = "HideAlphaWarning=False" = False)) Then
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
        If (SettingsArray(0) = "#Random Item Giver Settings File") = False Then
            Return True
        ElseIf (SettingsArray(1) = "Version=" + SettingsVersion.ToString) = False Then
            Return True
        ElseIf (SettingsArray(2) = "/") = False Then
            Return True
        ElseIf (SettingsArray(3) = "#General1") = False Then
            Return True
        ElseIf ((SettingsArray(4) = "UseAdvancedViewByDefault=True" = False And SettingsArray(4) = "UseAdvancedViewByDefault=False" = False)) Then
            Return True
        ElseIf ((SettingsArray(5) = "AutoSaveLogs=True" = False And SettingsArray(5) = "AutoSaveLogs=False" = False)) Then
            Return True
        ElseIf ((SettingsArray(6) = "Design=Light" = False And SettingsArray(6) = "Design=Dark" = False)) Then
            Return True
        ElseIf (SettingsArray(7) = "/") = False Then
            Return True
        ElseIf (SettingsArray(8) = "#General2") = False Then
            Return True
        ElseIf ((SettingsArray(9) = "DisableLogging=True" = False And SettingsArray(9) = "DisableLogging=False" = False)) Then
            Return True
        ElseIf ((SettingsArray(10) = "HideAlphaWarning=True" = False And SettingsArray(10) = "HideAlphaWarning=False" = False)) Then
            Return True
        ElseIf (SettingsArray(11) = "/") = False Then
            Return True
        ElseIf (SettingsArray(12) = "#Datapack Profiles") = False Then
            Return True
        ElseIf ((SettingsArray(13) = "LoadDefaultProfile=True" = False And SettingsArray(13) = "LoadDefaultProfile=False" = False)) Then
            Return True
        ElseIf String.IsNullOrEmpty(SettingsArray(14)) Then
            Return True
        ElseIf (SettingsArray(15) = "/") = False Then
            Return True
        ElseIf (SettingsArray(16) = "#Schemes") = False Then
            Return True
        ElseIf ((SettingsArray(17) = "SelectDefaultScheme=True" = False And SettingsArray(17) = "SelectDefaultScheme=False" = False)) Then
            Return True
        ElseIf String.IsNullOrEmpty(SettingsArray(18)) Then
            Return True
        ElseIf (SettingsArray(19) = "/") = False Then
            Return True
        ElseIf (SettingsArray(20) = "#Item List Importer") = False Then
            Return True
        ElseIf ((SettingsArray(21) = "DontImportVanillaItemsByDefault=True" = False And SettingsArray(21) = "DontImportVanillaItemsByDefault=False" = False)) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub LoadSettings()
        WriteToLog("Loading settings...", "Info")

        Try

            'Load general 1 settings
            My.Settings.UseAdvancedViewByDefault = Convert.ToBoolean(SettingsArray(4).Replace("UseAdvancedViewByDefault=", ""))
            WriteToLog("Loaded setting " + SettingsArray(4), "Info")
            My.Settings.AutoSaveLogs = Convert.ToBoolean(SettingsArray(5).Replace("AutoSaveLogs=", ""))
            WriteToLog("Loaded setting " + SettingsArray(5), "Info")
            My.Settings.Design = SettingsArray(6).Replace("Design=", "")
            WriteToLog("Loaded setting " + SettingsArray(6), "Info")

            'Load general 2 settings
            My.Settings.DisableLogging = Convert.ToBoolean(SettingsArray(9).Replace("DisableLogging=", ""))
            WriteToLog("Loaded setting " + SettingsArray(9), "Info")
            My.Settings.HideAlphaWarning = Convert.ToBoolean(SettingsArray(10).Replace("HideAlphaWarning=", ""))
            WriteToLog("Loaded setting " + SettingsArray(10), "Info")

            'Load datapack profiles settings
            My.Settings.LoadDefaultProfile = Convert.ToBoolean(SettingsArray(13).Replace("LoadDefaultProfile=", ""))
            WriteToLog("Loaded setting " + SettingsArray(13), "Info")
            My.Settings.DefaultProfile = SettingsArray(14).Replace("DefaultProfile=", "")
            WriteToLog("Loaded setting " + SettingsArray(14), "Info")

            'Load scheme settings
            My.Settings.SelectDefaultScheme = Convert.ToBoolean(SettingsArray(17).Replace("SelectDefaultScheme=", ""))
            WriteToLog("Loaded setting " + SettingsArray(17), "Info")
            My.Settings.DefaultScheme = SettingsArray(18).Replace("DefaultScheme=", "")
            WriteToLog("Loaded setting " + SettingsArray(18), "Info")

            'Load Item List Importer Settings
            My.Settings.DontImportVanillaItemsByDefault = Convert.ToBoolean(SettingsArray(21).Replace("DontImportVanillaItemsByDefault=", ""))
            WriteToLog("Loaded setting " + SettingsArray(21), "Info")

        Catch ex As Exception

            MsgBox("Could not load settings: " + ex.Message, MsgBoxStyle.Critical, "Error")
            WriteToLog("Could not load settings: " + ex.Message, "Error")

            'If loading settings failed, show an option to reset settings
            Select Case MsgBox("An error occured while loading your settings. " + vbNewLine + "Do you want to reset your settings? This probably fixes the problem.", vbCritical + vbYesNo, "Error")
                Case Windows.Forms.DialogResult.Yes
                    My.Computer.FileSystem.WriteAllText(SettingsFile, "", False)
                    frmSettings.SaveSettings(SettingsFile)
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
        For Each line As String In ItemsList
            IgnoreDuplicates = False
            DuplicateDetected = False
            Item = line
            CallAddItem()
        Next
    End Sub

    Private Sub CallAddItem()

        'Disable the creative-only options if 'creative-only' is generally disabled
        If CreativeOnly = False Then
            CommandBlock = False
            OtherCreativeOnlyItem = False
            SpawnEgg = False
        End If

        'Beginn adding items for the specific version if string is not empty

        If String.IsNullOrEmpty(Item) = False Then

            If DatapackVersion = "Version 1.16.2 - 1.16.5" Then

                'Add item to loot tables for 1 item
                If NormalItem And (ItemAddMode = "Normal" Or ItemAddMode = "Fast") Then
                    AddItem(Item, "1", "1.16", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 2 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 3 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 5 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 10 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 32 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.16", "tipped_arrows")
                End If

                'Add item to loot tables for 64 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.16", "tipped_arrows")
                End If

                'Add item to loot table for random amount of same items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.16", "tipped_arrows")
                End If

                'Add item to loot table for random amount of different items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.16", "tipped_arrows")
                End If

            ElseIf DatapackVersion = "Version 1.17 - 1.17.1" Then

                If NormalItem And (ItemAddMode = "Normal" Or ItemAddMode = "Fast") Then
                    AddItem(Item, "1", "1.17", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.17", "tipped_arrows")
                End If

            ElseIf DatapackVersion = "Version 1.18 - 1.18.2" Then

                'Add item to loot tables for 1 item
                If NormalItem And (ItemAddMode = "Normal" Or ItemAddMode = "Fast") Then
                    AddItem(Item, "1", "1.18", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 2 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 3 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 5 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 10 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 32 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.18", "tipped_arrows")
                End If

                'Add item to loot tables for 64 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.18", "tipped_arrows")
                End If

            ElseIf DatapackVersion = "Version 1.19 - 1.19.3" OrElse DatapackVersion = "Version 1.19.4" Then

                'Add item to loot tables for 1 item
                If NormalItem And (ItemAddMode = "Normal" Or ItemAddMode = "Fast") Then
                    AddItem(Item, "1", "1.19", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "tipped_arrows")
                End If
                If GoatHorn And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "goat_horns")
                End If
                If Painting And ItemAddMode = "Normal" Then
                    AddItem(Item, "1", "1.19", "paintings")
                End If

                'Add item to loot tables for 2 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "tipped_arrows")
                End If
                If GoatHorn And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "goat_horns")
                End If
                If Painting And ItemAddMode = "Normal" Then
                    AddItem(Item, "2", "1.19", "paintings")
                End If

                'Add item to loot tables for 3 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "tipped_arrows")
                End If
                If GoatHorn And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "goat_horns")
                End If
                If Painting And ItemAddMode = "Normal" Then
                    AddItem(Item, "3", "1.19", "paintings")
                End If

                'Add item to loot tables for 5 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "tipped_arrows")
                End If
                If GoatHorn And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "goat_horns")
                End If
                If Painting And ItemAddMode = "Normal" Then
                    AddItem(Item, "5", "1.19", "paintings")
                End If

                'Add item to loot tables for 10 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "tipped_arrows")
                End If
                If GoatHorn And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "goat_horns")
                End If
                If Painting And ItemAddMode = "Normal" Then
                    AddItem(Item, "10", "1.19", "paintings")
                End If

                'Add item to loot tables for 32 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "tipped_arrows")
                End If
                If GoatHorn And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "goat_horns")
                End If
                If Painting And ItemAddMode = "Normal" Then
                    AddItem(Item, "32", "1.19", "paintings")
                End If

                'Add item to loot tables for 64 items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "tipped_arrows")
                End If
                If GoatHorn And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "goat_horns")
                End If
                If Painting And ItemAddMode = "Normal" Then
                    AddItem(Item, "64", "1.19", "paintings")
                End If

                'Add item to loot tables for random amount of same items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "tipped_arrows")
                End If
                If GoatHorn And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "goat_horns")
                End If
                If Painting And ItemAddMode = "Normal" Then
                    AddItem(Item, "-1", "1.19", "paintings")
                End If

                'Add item to loot tables for random amount of different items
                If NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "main")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "main_without_creative-only")
                End If
                If CommandBlock = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "special_vxx")
                End If
                If OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "special_vvx")
                End If
                If SpawnEgg = False And OtherCreativeOnlyItem = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "special_xvx")
                End If
                If SpawnEgg = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "special_xvv")
                End If
                If SpawnEgg = False And CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "special_xxv")
                End If
                If CommandBlock = False And NormalItem And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "special_vxv")
                End If
                If SuspiciousStew And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "suspicious_stews")
                End If
                If EnchantedBook And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "enchanted_books")
                End If
                If Potion And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "potions")
                End If
                If SplashPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "splash_potions")
                End If
                If LingeringPotion And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "lingering_potions")
                End If
                If TippedArrow And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "tipped_arrows")
                End If
                If GoatHorn And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "goat_horns")
                End If
                If Painting And ItemAddMode = "Normal" Then
                    AddItem(Item, "-2", "1.19", "paintings")
                End If
            End If

            'Update And report workerprogress
            Workerprogress = Workerprogress + ProgressStep
            bgwAddItems.ReportProgress(Workerprogress)
            Invoke(Sub() tbSmallOutput.Text = Output)
            TotalItemAmount = TotalItemAmount - 1
            Invoke(Sub() lblItemsTotal.Text = "Adding items... (" + TotalItemAmount.ToString + " items remaining)")
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
                               rtbLog.AppendText("[" + DateTime.Now + "] " + "[ERROR] " + message + vbNewLine)
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.Red
                    rtbLog.AppendText("[" + DateTime.Now + "] " + "[ERROR] " + message + vbNewLine)
                End If
            ElseIf type = "Info" Then
                If InvokeRequired = True Then
                    Invoke(Sub()
                               rtbLog.SelectionColor = Color.FromArgb(50, 177, 205)
                               rtbLog.AppendText("[" + DateTime.Now + "] " + "[INFO] " + message + vbNewLine)
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.FromArgb(50, 177, 205)
                    rtbLog.AppendText("[" + DateTime.Now + "] " + "[INFO] " + message + vbNewLine)
                End If
            ElseIf type = "Warning" Then
                If InvokeRequired = True Then
                    Invoke(Sub()
                               rtbLog.SelectionColor = Color.DarkOrange
                               rtbLog.AppendText("[" + DateTime.Now + "] " + "[WARNING] " + message + vbNewLine)
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.DarkOrange
                    rtbLog.AppendText("[" + DateTime.Now + "] " + "[WARNING] " + message + vbNewLine)
                End If
            Else 'If type is invalid
                If InvokeRequired = True Then
                    Invoke(Sub()
                               rtbLog.SelectionColor = Color.Red
                               rtbLog.AppendText("--> Critical Log Error: Invalid type received" + vbNewLine)
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.Red
                    rtbLog.AppendText("--> Critical Log Error: Invalid type received" + vbNewLine)
                End If
            End If
        End If
    End Sub

    Private Sub InitializeProfilesAndSchemes()
        WriteToLog("Loading profiles...", "Info")

        'Check if profile directory exists and create it if it is missing
        If My.Computer.FileSystem.DirectoryExists(ProfileDirectory) = False Then
            My.Computer.FileSystem.CreateDirectory(ProfileDirectory)
            WriteToLog("Created profile directory", "Info")
        End If

        'Load profile files from specified directory
        GetProfileFiles(ProfileDirectory)

        'Load default profile if option is enabled
        If My.Settings.LoadDefaultProfile = True Then
            frmSettings.cbLoadDefaultProfile.Checked = True
            If String.IsNullOrEmpty(My.Settings.DefaultProfile) = False Then
                If My.Computer.FileSystem.FileExists(ProfileDirectory + My.Settings.DefaultProfile + ".txt") Then
                    cbxDefaultProfile.SelectedItem = My.Settings.DefaultProfile
                    frmLoadProfileFrom.InitializeLoadingProfile(cbxDefaultProfile.SelectedItem, False)
                    WriteToLog("Loaded default profile " + cbxDefaultProfile.SelectedItem, "Info")
                Else
                    frmSettings.Show()
                    frmSettings.cbLoadDefaultProfile.Checked = False
                    My.Settings.LoadDefaultProfile = False
                    frmSettings.SaveSettings(AppData + "/Random Item Giver Updater/settings.txt")
                    frmSettings.Close()
                    WriteToLog("Error when loading profile: Default profile doesn't exist. Disabled 'Load profile by default' option.", "Error")
                End If
            Else
                frmSettings.Show()
                frmSettings.cbLoadDefaultProfile.Checked = False
                My.Settings.LoadDefaultProfile = False
                frmSettings.SaveSettings(AppData + "/Random Item Giver Updater/settings.txt")
                frmSettings.Close()
                WriteToLog("Error when loading profile: Default profile is empty. Disabled 'Load profile by default' option.", "Error")
            End If
        Else
            WriteToLog("No default profile selected.", "Info")
        End If

        WriteToLog("Completed loading profiles!", "Info")
        WriteToLog("Loading schemes...", "Info")

        'Check if scheme directory exists
        If My.Computer.FileSystem.DirectoryExists(SchemeDirectory) = False Then
            My.Computer.FileSystem.CreateDirectory(SchemeDirectory)
        End If

        'Clear list of already existing schemes and load new list of schemes
        cbxScheme.Items.Clear()
        GetSchemeFiles(SchemeDirectory)

        'Select default scheme if enabled
        If My.Settings.SelectDefaultScheme = True Then
            frmSettings.cbSelectDefaultScheme.Checked = True
            If String.IsNullOrEmpty(My.Settings.DefaultScheme) = False Then
                If My.Computer.FileSystem.FileExists(SchemeDirectory + My.Settings.DefaultScheme + ".txt") Then
                    cbxScheme.SelectedItem = My.Settings.DefaultScheme
                Else
                    frmSettings.Show()
                    frmSettings.cbSelectDefaultScheme.Checked = False
                    My.Settings.SelectDefaultScheme = False
                    frmSettings.SaveSettings(AppData + "/Random Item Giver Updater/settings.txt")
                    frmSettings.Close()
                    WriteToLog("Error when loading scheme: Default scheme doesn't exist. Disabled 'Select scheme by default' option.", "Error")
                End If
            Else
                frmSettings.Show()
                frmSettings.cbSelectDefaultScheme.Checked = False
                My.Settings.SelectDefaultScheme = False
                frmSettings.SaveSettings(AppData + "/Random Item Giver Updater/settings.txt")
                frmSettings.Close()
                WriteToLog("Error when loading scheme: Default scheme is empty. Disabled 'Select scheme by default' option.", "Error")
            End If
        Else
            WriteToLog("No default scheme selected", "Info")
        End If

        WriteToLog("Completed loading schemes!", "Info")
    End Sub

    Sub GetProfileFiles(path As String)
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
            MsgBox("Error: Could not load profiles. Please try again." + vbNewLine + "Exception: " + ex.Message, MsgBoxStyle.Critical, "Error")
            WriteToLog("Error when loading profiles for Main Window: " + ex.Message, "Error")
        End Try
    End Sub

    Sub GetSchemeFiles(path As String)
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
            MsgBox("Error: Could not load schemes. Please try again." + vbNewLine + "Exception: " + ex.Message, MsgBoxStyle.Critical, "Error")
            WriteToLog("Error when loading schemes for Main Window: " + ex.Message, "Error")
        End Try
    End Sub

    Public Sub AddDefaultSchemes() 'Creates profiles for the default schemes. Overwrites existing ones.
        'Normal Item
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Normal Item" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Suspicious Stew
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Suspicious Stew" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Enchanted Book
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Enchanted Book" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Potion
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Potion" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Splash Potion
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Splash Potion" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Lingering Potion
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Lingering Potion" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Tipped Arrow
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Tipped Arrow" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Goat Horn
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Goat Horn" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Spawn Egg
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Spawn Egg" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Command Block
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Command Block" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False", False)

        'Other Creative-Only Item
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Other Creative-Only Item" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False", False)

        'Painting
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Painting" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True", False)

        WriteToLog("Restored default schemes.", "Info")
    End Sub

    '-- Button animations --

    Private Sub btnHamburger_MouseDown(sender As Object, e As MouseEventArgs) Handles btnHamburger.MouseDown
        If My.Settings.Design = "Light" Then
            btnHamburger.BackgroundImage = My.Resources.imgHamburgerButtonClick
        ElseIf My.Settings.Design = "Dark" Then
            btnHamburger.BackgroundImage = My.Resources.imgHamburgerButtonDarkClick
        End If
    End Sub

    Private Sub btnHamburger_MouseEnter(sender As Object, e As EventArgs) Handles btnHamburger.MouseEnter
        If My.Settings.Design = "Light" Then
            btnHamburger.BackgroundImage = My.Resources.imgHamburgerButtonHover
        ElseIf My.Settings.Design = "Dark" Then
            btnHamburger.BackgroundImage = My.Resources.imgHamburgerButtonDarkHover
        End If
    End Sub

    Private Sub btnHamburger_MouseLeave(sender As Object, e As EventArgs) Handles btnHamburger.MouseLeave
        If cmsHamburgerButton.Visible = False Then
            If My.Settings.Design = "Light" Then
                btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton
            ElseIf My.Settings.Design = "Dark" Then
                btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton
            End If
        End If
    End Sub

    Private Sub btnHamburger_MouseUp(sender As Object, e As MouseEventArgs) Handles btnHamburger.MouseUp
        If cmsHamburgerButton.Visible = False Then
            If My.Settings.Design = "Light" Then
                btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton
            ElseIf My.Settings.Design = "Dark" Then
                btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton
            End If
        End If
    End Sub

    Private Sub frmMain_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        'Reset hamburger button to default state
        btnHamburger.BackgroundImage = My.Resources.imgHamburgerButton
    End Sub

    Private Sub btnAddItem_MouseDown(sender As Object, e As MouseEventArgs) Handles btnAddItem.MouseDown
        If My.Settings.Design = "Dark" Then
            btnAddItem.BackgroundImage = My.Resources.imgButtonClick
        ElseIf My.Settings.Design = "Light" Then
            btnAddItem.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub


    Private Sub btnAddItem_MouseEnter(sender As Object, e As EventArgs) Handles btnAddItem.MouseEnter
        If My.Settings.Design = "Dark" Then
            btnAddItem.BackgroundImage = My.Resources.imgButtonHover
        ElseIf My.Settings.Design = "Light" Then
            btnAddItem.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnAddItem_MouseLeave(sender As Object, e As EventArgs) Handles btnAddItem.MouseLeave
        If My.Settings.Design = "Dark" Then
            btnAddItem.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnAddItem.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnAddItem_MouseUp(sender As Object, e As MouseEventArgs) Handles btnAddItem.MouseUp
        If My.Settings.Design = "Dark" Then
            btnAddItem.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnAddItem.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnSaveAsNewScheme_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSaveAsNewScheme.MouseDown
        If My.Settings.Design = "Dark" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButtonClick
        ElseIf My.Settings.Design = "Light" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnSaveAsNewScheme_MouseEnter(sender As Object, e As EventArgs) Handles btnSaveAsNewScheme.MouseEnter
        If My.Settings.Design = "Dark" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButtonHover
        ElseIf My.Settings.Design = "Light" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnSaveAsNewScheme_MouseLeave(sender As Object, e As EventArgs) Handles btnSaveAsNewScheme.MouseLeave
        If My.Settings.Design = "Dark" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnSaveAsNewScheme_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSaveAsNewScheme.MouseUp
        If My.Settings.Design = "Dark" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnSaveAsNewScheme.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnOverwriteSelectedScheme_MouseDown(sender As Object, e As MouseEventArgs) Handles btnOverwriteSelectedScheme.MouseDown
        If My.Settings.Design = "Dark" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButtonClick
        ElseIf My.Settings.Design = "Light" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnOverwriteSelectedScheme_MouseEnter(sender As Object, e As EventArgs) Handles btnOverwriteSelectedScheme.MouseEnter
        If My.Settings.Design = "Dark" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButtonHover
        ElseIf My.Settings.Design = "Light" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnOverwriteSelectedScheme_MouseLeave(sender As Object, e As EventArgs) Handles btnOverwriteSelectedScheme.MouseLeave
        If My.Settings.Design = "Dark" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnOverwriteSelectedScheme_MouseUp(sender As Object, e As MouseEventArgs) Handles btnOverwriteSelectedScheme.MouseUp
        If My.Settings.Design = "Dark" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnOverwriteSelectedScheme.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnDeleteSelectedScheme_MouseDown(sender As Object, e As MouseEventArgs) Handles btnDeleteSelectedScheme.MouseDown
        If My.Settings.Design = "Dark" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButtonClick
        ElseIf My.Settings.Design = "Light" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnDeleteSelectedScheme_MouseEnter(sender As Object, e As EventArgs) Handles btnDeleteSelectedScheme.MouseEnter
        If My.Settings.Design = "Dark" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButtonHover
        ElseIf My.Settings.Design = "Light" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnDeleteSelectedScheme_MouseLeave(sender As Object, e As EventArgs) Handles btnDeleteSelectedScheme.MouseLeave
        If My.Settings.Design = "Dark" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnDeleteSelectedScheme_MouseUp(sender As Object, e As MouseEventArgs) Handles btnDeleteSelectedScheme.MouseUp
        If My.Settings.Design = "Dark" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnDeleteSelectedScheme.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnBrowseDatapackPath_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBrowseDatapackPath.MouseDown
        If My.Settings.Design = "Dark" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButtonClick
        ElseIf My.Settings.Design = "Light" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnBrowseDatapackPath_MouseEnter(sender As Object, e As EventArgs) Handles btnBrowseDatapackPath.MouseEnter
        If My.Settings.Design = "Dark" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButtonHover
        ElseIf My.Settings.Design = "Light" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnBrowseDatapackPath_MouseLeave(sender As Object, e As EventArgs) Handles btnBrowseDatapackPath.MouseLeave
        If My.Settings.Design = "Dark" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnBrowseDatapackPath_MouseUp(sender As Object, e As MouseEventArgs) Handles btnBrowseDatapackPath.MouseUp
        If My.Settings.Design = "Dark" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnBrowseDatapackPath.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnLoadProfile_MouseDown(sender As Object, e As MouseEventArgs) Handles btnLoadProfile.MouseDown
        If My.Settings.Design = "Dark" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonClick
        ElseIf My.Settings.Design = "Light" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnLoadProfile_MouseEnter(sender As Object, e As EventArgs) Handles btnLoadProfile.MouseEnter
        If My.Settings.Design = "Dark" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonHover
        ElseIf My.Settings.Design = "Light" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnLoadProfile_MouseLeave(sender As Object, e As EventArgs) Handles btnLoadProfile.MouseLeave
        If My.Settings.Design = "Dark" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnLoadProfile_MouseUp(sender As Object, e As MouseEventArgs) Handles btnLoadProfile.MouseUp
        If My.Settings.Design = "Dark" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnLoadProfile.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnSaveProfile_MouseDown(sender As Object, e As MouseEventArgs) Handles btnSaveProfile.MouseDown
        If My.Settings.Design = "Dark" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButtonClick
        ElseIf My.Settings.Design = "Light" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButtonClickLight
        End If

    End Sub

    Private Sub btnSaveProfile_MouseEnter(sender As Object, e As EventArgs) Handles btnSaveProfile.MouseEnter
        If My.Settings.Design = "Dark" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButtonHover
        ElseIf My.Settings.Design = "Light" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButtonHoverLight
        End If

    End Sub

    Private Sub btnSaveProfile_MouseLeave(sender As Object, e As EventArgs) Handles btnSaveProfile.MouseLeave
        If My.Settings.Design = "Dark" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub btnSaveProfile_MouseUp(sender As Object, e As MouseEventArgs) Handles btnSaveProfile.MouseUp
        If My.Settings.Design = "Dark" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButton
        ElseIf My.Settings.Design = "Light" Then
            btnSaveProfile.BackgroundImage = My.Resources.imgButtonLight
        End If

    End Sub

    Private Sub ToolsToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles ToolsToolStripMenuItem.MouseEnter
        If My.Settings.Design = "Dark" Then
            'Get the sub menu
            Dim subMenu As ToolStripDropDownMenu = DirectCast(sender, ToolStripMenuItem).DropDown

            'Set background and foreground color
            subMenu.BackColor = Color.DimGray
            subMenu.ForeColor = Color.White
        End If
    End Sub

    Private Sub HelpToolStripMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.MouseEnter
        If My.Settings.Design = "Dark" Then
            'Get the sub menu
            Dim subMenu As ToolStripDropDownMenu = DirectCast(sender, ToolStripMenuItem).DropDown

            'Set background and foreground color
            subMenu.BackColor = Color.DimGray
            subMenu.ForeColor = Color.White
        End If
    End Sub
End Class