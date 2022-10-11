Imports System.IO
Imports System.Environment

Public Class frmMain

    'General variables for the software
    Public qm As String
    Public AppData As String = GetFolderPath(SpecialFolder.ApplicationData)
    Public VersionLog As String = "0.3.2-a (28.09.2022)"
    Public SettingsVersion As Double = 1
    Dim SettingsArray As String()
    Dim LoadedSettingsVersion As Double
    Dim FirstLoadCompleted As Boolean = False

    'Profile variables
    Public ProfileDirectory As String = AppData + "\Random Item Giver Updater\Profiles\"
    Dim ProfileList As String()

    'Scheme variables
    Public SchemeDirectory As String = AppData + "\Random Item Giver Updater\Schemes\"
    Dim SchemeList As String()
    Dim LoadFromScheme As String
    Dim SchemeContent As String()

    'All variables that play a key role in updating the datapack
    Dim EditFileLastLineLength As String
    Dim EditFilePath As String
    Dim MainFolderPath As String
    Dim LineRemoveLoop As Integer
    Dim NBTtag As String
    Dim Prefix As String
    Dim ExceptionAddItem As String
    Dim DuplicateDetected As Boolean = False
    Dim FileTemp As String = "None"
    Dim ItemAmountPath As String
    Dim IgnoreDuplicates As Boolean = False
    Dim Item As String
    Dim FullItemName As String
    Dim ItemAddMode As String
    Dim ProgressStep As Double
    Dim Workerprogress As Double
    Dim AddItemResult As String

    'Variables that also exist as UI elements, needed for threading
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
    Dim SamePrefix As Boolean
    Dim CustomNBT As Boolean
    Dim ItemsList As String()
    Dim SamePrefixString As String
    Dim CustomNBTString As String
    Dim AddItemsFast As Boolean
    Dim Output As String
    Dim DatapackPath As String
    Dim DatapackVersion As String
    Dim CodeEnd As String()
    Dim Items2 As String()
    Dim Items3 As String()
    Dim Items5 As String()
    Dim Items10 As String()
    Dim Items32 As String()
    Dim Items64 As String()
    Dim ItemsRandomSame116 As String()
    Dim ItemsRandomSame119 As String()

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If My.Computer.FileSystem.DirectoryExists(AppData + "/Random Item Giver Updater/") = False Then
            My.Computer.FileSystem.CreateDirectory(AppData + "/Random Item Giver Updater/")
            WriteToLog("Created the 'Random Item Giver Updater' directory in the Appdata folder for application files.", "Info")
        End If

        WriteToLog("Random Item Giver Updater " + VersionLog, "Info")
        WriteToLog("You are running an alpha build, may be unstable!", "Warning")


        If My.Computer.FileSystem.FileExists(AppData + "\Random Item Giver Updater\FirstStartCompleted") = False Then
            My.Computer.FileSystem.WriteAllText(AppData + "\Random Item Giver Updater\FirstStartCompleted", "", False)
            If My.Computer.FileSystem.DirectoryExists(SchemeDirectory) = False Then
                My.Computer.FileSystem.CreateDirectory(SchemeDirectory)
            End If
            AddDefaultSchemes()
        End If

        InitializeLoadingSettings()
        InitializeProfilesAndSchemes()

        If My.Settings.DisableLogging = True Then
            frmOutput.rtbLog.Clear()
            If My.Computer.FileSystem.FileExists(AppData + "/Random Item Giver Updater/DebugLogTemp") Then
                My.Computer.FileSystem.DeleteFile(AppData + "/Random Item Giver Updater/DebugLogTemp")
            End If
        End If

        If My.Settings.HideAlphaWarning = False Then
            MsgBox("Warning: You are running an early alpha build of the Random Item Giver Updater." + vbNewLine + vbNewLine + "You have to expect to find bugs and incomplete features." + vbNewLine + vbNewLine + "Please give as much feedback as possible so the software can be improved!" + vbNewLine + vbNewLine + "Use this early alpha build at your own risk and with caution.", MsgBoxStyle.Exclamation, "Warning")
        End If

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

        If My.Settings.UseAdvancedViewByDefault = True Then
            EnableAdvancedView()
            cbEnableAdvancedView.Checked = True
        Else
            DisableAdvancedView()
            cbEnableAdvancedView.Checked = False
        End If
    End Sub

    Private Sub InitializeProfilesAndSchemes()
        WriteToLog("Loading profiles...", "Info")

        'Load profiles
        If My.Computer.FileSystem.DirectoryExists(ProfileDirectory) = False Then
            My.Computer.FileSystem.CreateDirectory(ProfileDirectory)
            WriteToLog("Created profile directory", "Info")
        End If

        GetProfileFiles(ProfileDirectory)

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
        'Load Schemes
        If My.Computer.FileSystem.DirectoryExists(SchemeDirectory) = False Then
            My.Computer.FileSystem.CreateDirectory(SchemeDirectory)
        End If

        cbxScheme.Items.Clear()
        GetSchemeFiles(SchemeDirectory)

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

    Sub GetProfileFiles(Path As String)
        If Path.Trim().Length = 0 Then
            Return
        End If

        ProfileList = Directory.GetFileSystemEntries(Path)

        Try
            For Each Profile As String In ProfileList
                If Directory.Exists(Profile) Then
                    GetProfileFiles(Profile)
                Else
                    Profile = Profile.Replace(Path, "")
                    Profile = Profile.Replace(".txt", "")
                    cbxDefaultProfile.Items.Add(Profile)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error: Could not load profiles. Please try again." + vbNewLine + "Exception: " + ex.Message)
            WriteToLog("Error when loading profiles for Main Window: " + ex.Message, "Error")
        End Try
    End Sub

    Sub GetSchemeFiles(Path As String)
        If Path.Trim().Length = 0 Then
            Return
        End If

        SchemeList = Directory.GetFileSystemEntries(Path)

        Try
            For Each Scheme As String In SchemeList
                If Directory.Exists(Scheme) Then
                    GetSchemeFiles(Scheme)
                Else
                    Scheme = Scheme.Replace(Path, "")
                    Scheme = Scheme.Replace(".txt", "")
                    cbxScheme.Items.Add(Scheme)
                End If
            Next
        Catch ex As Exception
            MsgBox("Error: Could not load schemes. Please try again." + vbNewLine + "Exception: " + ex.Message)
            WriteToLog("Error when loading schemes for Main Window: " + ex.Message, "Error")
        End Try
    End Sub

    Public Sub AddDefaultSchemes()
        'Normal Item
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Normal Item" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Suspicious Stew
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Suspicious Stew" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Enchanted Book
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Enchanted Book" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Potion
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Potion" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Splash Potion
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Splash Potion" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Lingering Potion
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Lingering Potion" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Tipped Arrow
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Tipped Arrow" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Goat Horn
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Goat Horn" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False", False)

        'Spawn Egg
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Spawn Egg" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False", False)

        'Command Block
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Command Block" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False", False)

        'Other Creative-Only Item
        My.Computer.FileSystem.WriteAllText(SchemeDirectory + "Other Creative-Only Item" + ".txt", "True" + vbNewLine + "minecraft" + vbNewLine + "False" + vbNewLine + "None" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True" + vbNewLine + "False" + vbNewLine + "False" + vbNewLine + "True", False)

        WriteToLog("Restored default schemes.", "Info")
    End Sub


    Private Sub btnAddItem_Click(sender As Object, e As EventArgs) Handles btnAddItem.Click
        btnAddItem.Hide()
        pbAddingItemsProgress.Value = 0
        Workerprogress = 0
        AddItemResult = "NONE"

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

        bgwAddItems.RunWorkerAsync()
    End Sub

    Private Sub bgwAddItems_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bgwAddItems.DoWork
        If My.Computer.FileSystem.DirectoryExists(DatapackPath) Then
            If ItemsList.Count > 99 And AddItemsFast = False Then
                Select Case MsgBox("Warning: You are trying to add 100 or more items." + vbNewLine + "This may take a long time to complete. It's recommended to enable 'Add Items Fast' to speed up the process." + vbNewLine + vbNewLine + "Are you sure you want to continue?", MessageBoxButtons.YesNo, "Warning")
                    Case Windows.Forms.DialogResult.Yes
                        WriteToLog("Adding 100+ items with normal method, this may take a while!", "Warning")

                        If AddItemsFast = True Then
                            ItemAddMode = "Fast"
                        Else
                            ItemAddMode = "Normal"
                        End If
                        IgnoreDuplicates = False
                        DuplicateDetected = False
                        EditFilePath = DatapackPath
                        WriteToLog("Preparing to add multiple items.", "Info")
                        ProgressStep = 100 / ItemsList.Count
                        AddMultipleItems()
                        AddItemResult = "success"
                    Case Windows.Forms.DialogResult.No
                        WriteToLog("Cancelled adding 100+ items.", "Info")
                End Select
            Else

                If AddItemsFast Then
                    ItemAddMode = "Fast"
                Else
                    ItemAddMode = "Normal"
                End If
                IgnoreDuplicates = False
                DuplicateDetected = False
                EditFilePath = DatapackPath

                If ItemsList.Length = 1 Then
                    Item = ItemsList(0)
                    WriteToLog("Preparing to add a single item.", "Info")
                    ProgressStep = 100 / ItemsList.Count
                    CallAddItem()
                    AddItemResult = "success"
                ElseIf ItemsList.Length = 0 Then
                Else
                    WriteToLog("Preparing to add multiple items.", "Info")
                    ProgressStep = 100 / ItemsList.Count
                    AddMultipleItems()
                    AddItemResult = "success"
                End If
            End If
        Else
            MsgBox("Please enter a datapack path!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub InitializeLoadingSettings()
        If My.Computer.FileSystem.FileExists(AppData + "/Random Item Giver Updater/settings.txt") Then
            SettingsArray = File.ReadAllLines(AppData + "/Random Item Giver Updater/settings.txt")
            LoadedSettingsVersion = SettingsArray(1).Replace("Version=", "")
            WriteToLog("Found settings version " + LoadedSettingsVersion.ToString, "Info")

            If LoadedSettingsVersion < SettingsVersion Then

                Select Case MsgBox("Your settings from a previous version were found." + vbNewLine + "Do you want to try to import them?" + vbNewLine + " This will overwrite your current settings.", MessageBoxButtons.YesNo, "Found older settings")
                    Case Windows.Forms.DialogResult.Yes
                        WriteToLog("Importing settings from older version. Please note that due to version differences not everything might be imported.", "Warning")
                        LoadSettings()
                        MsgBox("Finished Importing settings. Please note that not everything might have been imported due to the settings file being an older version.", MsgBoxStyle.Information, "Import older settings")
                        WriteToLog("Finished importing settings from older version.", "Info")
                    Case Windows.Forms.DialogResult.No
                        WriteToLog("Ignored settings from previous version. Creating new file, current one will be renamed to settings.old", "Info")
                        My.Computer.FileSystem.RenameFile(AppData + "/Random Item Giver Updater/settings.txt", "settings.old")
                        My.Computer.FileSystem.WriteAllText(AppData + "/Random Item Giver Updater/settings.txt", "", False)
                        frmSettings.SaveSettings(AppData + "/Random Item Giver Updater/settings.txt")
                End Select

            ElseIf LoadedSettingsVersion > SettingsVersion Then

                Select Case MsgBox("The settings file that was detected belongs to a newer version of the Random Item Giver Updater." + vbNewLine + "Loading it can cause issues. Do you still want to load it?", MessageBoxButtons.YesNo, "Found newer settings")
                    Case Windows.Forms.DialogResult.Yes
                        WriteToLog("Importing settings from newer version. Please note that due to version differences this can issues.", "Warning")
                        LoadSettings()
                        MsgBox("Finished Importing settings. Please note that not everything might work correctly.", MsgBoxStyle.Information, "Imported newer settings")
                        WriteToLog("Finished importing settings from newer version.", "Info")
                    Case Windows.Forms.DialogResult.No
                        WriteToLog("Ignored settings from newer version. Creating new file, current one will be renamed to settings.old", "Info")
                        My.Computer.FileSystem.RenameFile(AppData + "/Random Item Giver Updater/settings.txt", "settings.old")
                        My.Computer.FileSystem.WriteAllText(AppData + "/Random Item Giver Updater/settings.txt", "", False)
                        frmSettings.SaveSettings(AppData + "/Random Item Giver Updater/settings.txt")
                End Select

            Else

                WriteToLog("Loading settings...", "Info")
                LoadSettings()

            End If

        Else
            WriteToLog("Could not find settings file. Creating a new one (Version " + SettingsVersion.ToString + ").", "Warning")
            My.Computer.FileSystem.WriteAllText(AppData + "/Random Item Giver Updater/settings.txt", "", False)
            frmSettings.SaveSettings(AppData + "/Random Item Giver Updater/settings.txt")
        End If
    End Sub

    Private Sub LoadSettings()
        Try

            'Load general settings
            My.Settings.UseAdvancedViewByDefault = Convert.ToBoolean(SettingsArray(4).Replace("UseAdvancedViewByDefault=", ""))
            WriteToLog("Loaded setting " + SettingsArray(4), "Info")
            'Load software settings
            My.Settings.DisableLogging = Convert.ToBoolean(SettingsArray(7).Replace("DisableLogging=", ""))
            WriteToLog("Loaded setting " + SettingsArray(7), "Info")
            My.Settings.HideAlphaWarning = Convert.ToBoolean(SettingsArray(8).Replace("HideAlphaWarning=", ""))
            WriteToLog("Loaded setting " + SettingsArray(8), "Info")

            'Load datapack profiles settings
            My.Settings.LoadDefaultProfile = Convert.ToBoolean(SettingsArray(11).Replace("LoadDefaultProfile=", ""))
            WriteToLog("Loaded setting " + SettingsArray(11), "Info")
            My.Settings.DefaultProfile = SettingsArray(12).Replace("DefaultProfile=", "")
            WriteToLog("Loaded setting " + SettingsArray(12), "Info")

            'Load scheme settings
            My.Settings.SelectDefaultScheme = Convert.ToBoolean(SettingsArray(15).Replace("SelectDefaultScheme=", ""))
            WriteToLog("Loaded setting " + SettingsArray(15), "Info")
            My.Settings.DefaultScheme = SettingsArray(16).Replace("DefaultScheme=", "")
            WriteToLog("Loaded setting " + SettingsArray(16), "Info")

            'Load Item List Importer Settings
            My.Settings.DontImportVanillaItemsByDefault = Convert.ToBoolean(SettingsArray(19).Replace("DontImportVanillaItemsByDefault=", ""))
            WriteToLog("Loaded setting " + SettingsArray(19), "Info")

        Catch ex As Exception

            MsgBox("Could not load settings: " + ex.Message, MsgBoxStyle.Critical, "Error")
            WriteToLog("Could not load settings: " + ex.Message, "Error")

            Select Case MsgBox("An error occured while loading your settings. " + vbNewLine + "Do you want to reset your settings? This probably fixes the problem.", MsgBoxStyle.YesNo, "Error")
                Case Windows.Forms.DialogResult.Yes
                    My.Computer.FileSystem.WriteAllText(AppData + "/Random Item Giver Updater/settings.txt", "", False)
                    frmSettings.SaveSettings(AppData + "/Random Item Giver Updater/settings.txt")
                    MsgBox("Successfully reset your settings!" + vbNewLine + "Please restart the application for changes to take affect.", MsgBoxStyle.Information, "Reset settings")
                    WriteToLog("Successfully reset settings!", "Info")
                    Close()
            End Select

        End Try
    End Sub

    Private Sub EnableAdvancedView()
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
        gbItemID.Width = 242
        gbItemID.Height = 83
        gbItem.Width = 638
        gbItem.Height = 351
        Width = 683
        Height = 647
        WriteToLog("Enabled advanced view.", "Info")
    End Sub

    Private Sub DisableAdvancedView()
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
        gbItemID.Width = 395
        gbItemID.Height = 83
        gbItem.Width = 638
        gbItem.Height = 293
        Width = 683
        Height = 583
        WriteToLog("Disabled advanced view.", "Info")
    End Sub

    Private Sub AddMultipleItems()
        For Each line As String In ItemsList
            IgnoreDuplicates = False
            DuplicateDetected = False
            Item = line
            CallAddItem()
        Next
    End Sub

    Private Sub CallAddItem()

        If CreativeOnly = False Then
            CommandBlock = False
            OtherCreativeOnlyItem = False
            SpawnEgg = False
        End If

        If String.IsNullOrEmpty(Item) = False Then

            If DatapackVersion = "Version 1.16" Then

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

            ElseIf DatapackVersion = "Version 1.17" Then

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

            ElseIf DatapackVersion = "Version 1.18" Then

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

            ElseIf DatapackVersion = "Version 1.19" Then

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
            End If
            Workerprogress = Workerprogress + ProgressStep
            bgwAddItems.ReportProgress(Workerprogress)
            Invoke(Sub() tbSmallOutput.Text = Output)
        Else
            MsgBox("Please enter a text in the ID textbox!", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Public Sub WriteToLog(Message As String, Type As String)
        If My.Settings.DisableLogging = False Then
            If Type = "Error" Then
                If InvokeRequired = True Then
                    Invoke(Sub()
                               rtbLog.SelectionColor = Color.Red
                               rtbLog.AppendText("[" + DateTime.Now + "] " + "[ERROR] " + Message + vbNewLine)
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.Red
                    rtbLog.AppendText("[" + DateTime.Now + "] " + "[ERROR] " + Message + vbNewLine)
                End If
            ElseIf Type = "Info" Then
                If InvokeRequired = True Then
                    Invoke(Sub()
                               rtbLog.SelectionColor = Color.FromArgb(50, 177, 205)
                               rtbLog.AppendText("[" + DateTime.Now + "] " + "[INFO] " + Message + vbNewLine)
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.FromArgb(50, 177, 205)
                    rtbLog.AppendText("[" + DateTime.Now + "] " + "[INFO] " + Message + vbNewLine)
                End If
            ElseIf Type = "Warning" Then
                If InvokeRequired = True Then
                    Invoke(Sub()
                               rtbLog.SelectionColor = Color.DarkOrange
                               rtbLog.AppendText("[" + DateTime.Now + "] " + "[WARNING] " + Message + vbNewLine)
                           End Sub)
                Else
                    rtbLog.SelectionColor = Color.DarkOrange
                    rtbLog.AppendText("[" + DateTime.Now + "] " + "[WARNING] " + Message + vbNewLine)
                End If
            Else
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

    Private Sub rtbLog_TextChanged(sender As Object, e As EventArgs) Handles rtbLog.TextChanged
        rtbLog.SaveFile(AppData + "/Random Item Giver Updater/DebugLogTemp")
        frmOutput.rtbLog.LoadFile(AppData + "/Random Item Giver Updater/DebugLogTemp")
    End Sub

    Private Sub AddItem(Item_ID As String, Item_Amount As Integer, Version As String, Loot_Table As String)

        If DuplicateDetected = False Or (DuplicateDetected = False And IgnoreDuplicates = True) Then
            WriteToLog("-- Adding item --", "Info")
            ExceptionAddItem = ""

            If CustomNBT = True Then
                NBTtag = CustomNBTString
                WriteToLog("Adding NBT tag: " + NBTtag, "Info")
            Else
                NBTtag = "NONE"
                WriteToLog("No NBT tag selected.", "Info")
            End If

            If SamePrefix = True Then
                Prefix = SamePrefixString
                WriteToLog("Using the same prefix for all items: " + Prefix, "Info")
            Else
                WriteToLog("Not using the same prefix for all items, will read prefix from item list.", "Info")
            End If

            If SamePrefix = True Then
                FullItemName = Prefix + ":" + Item_ID
            Else
                FullItemName = Item_ID
            End If

            'Define ItemAmountPath depending on Item_Amount
            If Item_Amount = 1 Then
                ItemAmountPath = "1item\"
                WriteToLog("Item amount detected as 1, using default path for 1 item. ", "Info")
            ElseIf Item_Amount = "-1" Then
                ItemAmountPath = "randomamountsameitem\"
                WriteToLog("Item amount detected as random amount of same item, using default path for random amount of same item. ", "Info")
            ElseIf Item_Amount = "-2" Then
                ItemAmountPath = "randomamountdifitems\"
                WriteToLog("Item amount detected as random amount of different items, using default path for random amount of different items. ", "Info")
            ElseIf Item_Amount > 1 Then
                ItemAmountPath = Item_Amount.ToString + "sameitems\"
                WriteToLog("Item amount detected as bigger than 1, using path for multiple items.", "Info")
            End If


            'Check if item you want to add already exists
            If My.Computer.FileSystem.FileExists(EditFilePath + "\data\randomitemgiver\loot_tables\" + ItemAmountPath + Loot_Table + ".json") Then
                FileTemp = My.Computer.FileSystem.ReadAllText(EditFilePath + "\data\randomitemgiver\loot_tables\" + ItemAmountPath + Loot_Table + ".json")
            End If
            If FileTemp.Contains(qm + FullItemName + qm) = False Or IgnoreDuplicates = True Then
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
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\1item\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\1item\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "goat_horns" And Version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\1item\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
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
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\2sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items2) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\2sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items2) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "goat_horns" And Version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\2sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items2) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
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
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\3sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items3) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\3sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items3) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "goat_horns" And Version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\3sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items3) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
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
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\5sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items5) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\5sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items5) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "goat_horns" And Version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\5sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items5) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
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
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\10sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items10) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\10sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items10) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "goat_horns" And Version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\10sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items10) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
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
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\32sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items32) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\32sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items32) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "goat_horns" And Version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\32sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items32) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
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
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\64sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items64) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\64sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items64) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "goat_horns" And Version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\64sameitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(Items64) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            End If

                        ElseIf Item_Amount = "-1" And Version = "1.16" Then
                            LineRemoveLoop = 8

                            While LineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + Loot_Table + ".json")
                                Dim FileStreamEditFile As New FileStream(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + Loot_Table + ".json", FileMode.Open, FileAccess.ReadWrite)
                                EditFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - EditFileLastLineLength)
                                FileStreamEditFile.Close()

                                LineRemoveLoop = LineRemoveLoop - 1
                            End While

                            If Loot_Table = "main" OrElse Loot_Table = "main_without_creative-only" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_xvx" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_xxv" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vxx" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(ItemsRandomSame116) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(ItemsRandomSame116) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "goat_horns" And Version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(ItemsRandomSame116) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            End If

                        ElseIf Item_Amount = "-1" And Version = "1.19" Then
                            LineRemoveLoop = 8

                            While LineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + Loot_Table + ".json")
                                Dim FileStreamEditFile As New FileStream(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + Loot_Table + ".json", FileMode.Open, FileAccess.ReadWrite)
                                EditFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - EditFileLastLineLength)
                                FileStreamEditFile.Close()

                                LineRemoveLoop = LineRemoveLoop - 1
                            End While

                            If Loot_Table = "main" OrElse Loot_Table = "main_without_creative-only" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_xvx" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_xxv" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vxx" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(ItemsRandomSame119) + vbNewLine + "          ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(ItemsRandomSame119) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "goat_horns" And Version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountsameitem\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + ReturnArrayAsString(ItemsRandomSame119) + "," + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            End If

                        ElseIf Item_Amount = "-2" And (Version = "1.16" OrElse Version = "1.19") Then
                            LineRemoveLoop = 8

                            While LineRemoveLoop > 0
                                Dim EditFileLines() As String = IO.File.ReadAllLines(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountdifitems\" + Loot_Table + ".json")
                                Dim FileStreamEditFile As New FileStream(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountdifitems\" + Loot_Table + ".json", FileMode.Open, FileAccess.ReadWrite)
                                EditFileLastLineLength = EditFileLines.Last.Length.ToString

                                FileStreamEditFile.SetLength(FileStreamEditFile.Length - EditFileLastLineLength)
                                FileStreamEditFile.Close()

                                LineRemoveLoop = LineRemoveLoop - 1
                            End While

                            If Loot_Table = "main" OrElse Loot_Table = "main_without_creative-only" OrElse Loot_Table = "special_xvv" OrElse Loot_Table = "special_xvx" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_xxv" OrElse Loot_Table = "Special_xvv" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vvx" OrElse Loot_Table = "special_vxv" OrElse Loot_Table = "special_vxx" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountdifitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "suspicious_stews" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potions" OrElse Loot_Table = "splash_potions" OrElse Loot_Table = "lingering_potions" OrElse Loot_Table = "tipped_arrows" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountdifitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                            ElseIf Loot_Table = "goat_horns" And Version = "1.19" Then
                                My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\randomamountdifitems\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
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
                            My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                        ElseIf Loot_Table = "suspicious_stew" OrElse Loot_Table = "enchanted_books" OrElse Loot_Table = "potion" OrElse Loot_Table = "splash_potion" OrElse Loot_Table = "lingering_potion" OrElse Loot_Table = "tipped_arrow" Then
                            My.Computer.FileSystem.WriteAllText(EditFilePath + "\data\randomitemgiver\loot_tables\" + Loot_Table + ".json", vbNewLine + "        }," + vbNewLine + "        {" + vbNewLine + "          " + qm + "type" + qm + ": " + qm + "minecraft:item" + qm + "," + vbNewLine + "          " + qm + "name" + qm + ": " + qm + FullItemName + qm + "," + vbNewLine + "                    " + qm + "functions" + qm + ": [" + vbNewLine + "                        {" + vbNewLine + "                            " + qm + "function" + qm + ": " + qm + "set_nbt" + qm + "," + vbNewLine + "                            " + qm + "tag" + qm + ": " + qm + NBTtag + qm + vbNewLine + "                        }" + vbNewLine + "                    ]" + vbNewLine + ReturnArrayAsString(CodeEnd), True)
                        End If

                    End If

                Catch Exception As Exception
                    ExceptionAddItem = Exception.Message
                End Try

                If String.IsNullOrEmpty(ExceptionAddItem) Then
                    Output = "Succesfully added " + FullItemName + " to selected loot tables in Version " + Version + " (NBT: " + NBTtag + ")"
                    WriteToLog("Added item " + FullItemName + " to loot table " + Loot_Table + " with amount " + Item_Amount.ToString, "Info")
                Else
                    Output = "Error: " + ExceptionAddItem
                    WriteToLog("Error when adding item: " + ExceptionAddItem, "Error")
                End If

            Else
                WriteToLog("Detected duplicate When adding item.", "Info")
                Select Case MessageBox.Show("The item you are trying To add (" + FullItemName + ") already exists In the datapack." + vbNewLine + "Are you sure you want To add it again? This will result In duplicates.", "Warning", MessageBoxButtons.YesNo)
                    Case Windows.Forms.DialogResult.Yes
                        WriteToLog("Ignoring warning, adding duplicate.", "Info")
                        IgnoreDuplicates = True
                    Case Windows.Forms.DialogResult.No
                        WriteToLog("Not adding duplicate, cancelling.", "Info")
                        IgnoreDuplicates = False
                        DuplicateDetected = True
                        Output = "Cancelled adding " + FullItemName + " To " + Loot_Table + " In Version " + Version + " (NBT: " + NBTtag + ")"
                End Select
            End If
        End If
    End Sub

    Public Function ReturnArrayAsString(SourceArray As String())
        Dim FullString As String = ""
        For Each line As String In SourceArray
            FullString = FullString + line + vbNewLine
        Next
        FullString = FullString.Remove(FullString.Length - 2)
        Return FullString
    End Function

    Public Function ReturnListAsString(SourceArray As List(Of String))
        Dim FullString As String = ""
        For Each line As String In SourceArray
            FullString = FullString + line + vbNewLine
        Next
        FullString = FullString.Remove(FullString.Length - 2)
        Return FullString
    End Function

    Private Sub btnBrowseDatapackPath_Click(sender As Object, e As EventArgs) Handles btnBrowseDatapackPath.Click
        fbdMainFolderPath.ShowDialog()
        tbDatapackPath.Text = fbdMainFolderPath.SelectedPath
    End Sub

    Public Sub DetermineDatapackVersion()
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
                        WriteToLog("Detected unsupported datapack version. This may cause issues.", "Warning")
                        cbxVersion.SelectedItem = "Version 1.19"
                    ElseIf Version = "10" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.19"
                        WriteToLog("Detected datapack version 1.19.", "Info")
                        cbxVersion.SelectedItem = "Version 1.19"
                    ElseIf Version = "9" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.18"
                        WriteToLog("Detected datapack version 1.18.", "Info")
                        cbxVersion.SelectedItem = "Version 1.18"
                    ElseIf Version = "8" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.18. Please note that your version of 1.18 is outdated."
                        WriteToLog("Detected datapack version 1.18.", "Info")
                        cbxVersion.SelectedItem = "Version 1.18"
                    ElseIf Version = "7" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.17"
                        WriteToLog("Detected datapack version 1.17.", "Info")
                        cbxVersion.SelectedItem = "Version 1.17"
                    ElseIf Version = "6" Then
                        lblDatapackDetection.Text = "Detected datapack as version 1.16"
                        WriteToLog("Detected datapack version 1.16.", "Info")
                        cbxVersion.SelectedItem = "Version 1.16"
                    ElseIf Convert.ToInt32(Version) < 6 Then
                        lblDatapackDetection.Text = "Detected datapack, but version is most likely unsupported"
                        MsgBox("A datapack has been detected but the version number is smaller than 6." + vbNewLine + "This means that the datapack version is older than 1.15 which the Random Item Giver does not support." + vbNewLine + "The oldest available version has been selected but will most likely not work.", MsgBoxStyle.Exclamation, "Warning")
                        WriteToLog("Detected unsupported datapack version. This may cause issues.", "Warning")
                        cbxVersion.SelectedItem = "Version 1.16"
                    Else
                        lblDatapackDetection.Text = "Detected datapack, but could not determine version."
                        WriteToLog("Detected datapack, couldn't determine version.", "Error")
                    End If
                Catch ex As Exception
                    MsgBox("Error when selecting datapack: " + ex.Message, MsgBoxStyle.Critical, "Error")
                    lblDatapackDetection.Text = "Detected datapack, but could not determine version."
                    WriteToLog("Detected datapack, couldn't determine version.", "Error")
                    cbxVersion.SelectedItem = "Version 1.19"
                End Try
            Else
                lblDatapackDetection.Text = "Folder found, but could not detect datapack."
                WriteToLog("Couldn't detect datapack.", "Error")
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
        MsgBox("This feature is not available yet." + vbNewLine + "Its expected release will be in Version 0.4.0.", MsgBoxStyle.Exclamation, "Not available yet")
    End Sub

    Private Sub OutputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OutputToolStripMenuItem.Click
        frmOutput.Show()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        frmSettings.ShowDialog()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub OpenDatapackFolderToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenDatapackFolderToolStripMenuItem.Click
        If My.Computer.FileSystem.DirectoryExists(tbDatapackPath.Text) Then
            Process.Start("explorer.exe", tbDatapackPath.Text)
        Else
            MsgBox("Cannot open datapack folder, please select a valid path.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Private Sub cbCustomPrefix_CheckedChanged(sender As Object, e As EventArgs) Handles cbSamePrefix.CheckedChanged
        If cbSamePrefix.Checked Then
            tbSamePrefix.Enabled = True
            lblID.Text = "Items (ID)"
            SamePrefix = True
        Else
            tbSamePrefix.Enabled = False
            lblID.Text = "Items (Prefix:ID)"
            SamePrefix = False
        End If
    End Sub

    Private Sub cbNBT_CheckedChanged(sender As Object, e As EventArgs) Handles cbCustomNBT.CheckedChanged
        If cbCustomNBT.Checked Then
            tbCustomNBT.Enabled = True
            CustomNBT = True
        Else
            tbCustomNBT.Enabled = False
            CustomNBT = False
        End If
    End Sub

    Private Sub cbCreativeOnly_CheckedChanged(sender As Object, e As EventArgs) Handles cbCreativeOnly.CheckedChanged
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

    Private Sub btnShowOutput_Click(sender As Object, e As EventArgs) Handles btnShowOutput.Click
        frmOutput.Show()
    End Sub

    Private Sub FindDuplicatesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindDuplicatesToolStripMenuItem.Click
        frmDuplicateFinder.Show()
    End Sub

    Private Sub ImportItemListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportItemListToolStripMenuItem.Click
        frmItemImporter.ShowDialog()
    End Sub

    Private Sub cbAddItemsFast_CheckedChanged(sender As Object, e As EventArgs) Handles cbAddItemsFast.CheckedChanged
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
            MsgBox("This setting speeds up the process of adding items, narrowing it down to only a few seconds." + vbNewLine + "This is recommended if you need to add 100+ Items." + vbNewLine + vbNewLine + "Please note that if you enable this option, the items will only be added to the main loot table. This means that you won't be able to use the item settings in the datapack afterwards.", MsgBoxStyle.Information, "Enable Fast Item Adding")
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
        ItemsList = rtbItem.Lines
    End Sub

    Private Sub tbSamePrefix_TextChanged(sender As Object, e As EventArgs) Handles tbSamePrefix.TextChanged
        SamePrefixString = tbSamePrefix.Text
    End Sub

    Private Sub tbCustomNBT_TextChanged(sender As Object, e As EventArgs) Handles tbCustomNBT.TextChanged
        CustomNBTString = tbCustomNBT.Text
    End Sub

    Private Sub cbNormalItem_CheckedChanged(sender As Object, e As EventArgs) Handles cbNormalItem.CheckedChanged
        NormalItem = cbNormalItem.CheckState
    End Sub

    Private Sub cbSuspiciousStew_CheckedChanged(sender As Object, e As EventArgs) Handles cbSuspiciousStew.CheckedChanged
        SuspiciousStew = cbSuspiciousStew.CheckState
    End Sub

    Private Sub cbEnchantedBook_CheckedChanged(sender As Object, e As EventArgs) Handles cbEnchantedBook.CheckedChanged
        EnchantedBook = cbEnchantedBook.CheckState
    End Sub

    Private Sub cbPotion_CheckedChanged(sender As Object, e As EventArgs) Handles cbPotion.CheckedChanged
        Potion = cbPotion.CheckState
    End Sub

    Private Sub cbSplashPotion_CheckedChanged(sender As Object, e As EventArgs) Handles cbSplashPotion.CheckedChanged
        SplashPotion = cbSplashPotion.CheckState
    End Sub
    Private Sub cbLingeringPotion_CheckedChanged(sender As Object, e As EventArgs) Handles cbLingeringPotion.CheckedChanged
        LingeringPotion = cbLingeringPotion.CheckState
    End Sub

    Private Sub cbTippedArrow_CheckedChanged(sender As Object, e As EventArgs) Handles cbTippedArrow.CheckedChanged
        TippedArrow = cbTippedArrow.CheckState
    End Sub

    Private Sub cbGoatHorn_CheckedChanged(sender As Object, e As EventArgs) Handles cbGoatHorn.CheckedChanged
        GoatHorn = cbGoatHorn.CheckState
    End Sub

    Private Sub rbtnSpawnEgg_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnSpawnEgg.CheckedChanged
        If rbtnSpawnEgg.Checked Then
            SpawnEgg = True
        Else
            SpawnEgg = False
        End If
    End Sub

    Private Sub rbtnCommandBlock_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnCommandBlock.CheckedChanged
        If rbtnCommandBlock.Checked Then
            CommandBlock = True
        Else
            CommandBlock = False
        End If
    End Sub

    Private Sub rbtnOtherItem_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnOtherItem.CheckedChanged
        If rbtnOtherItem.Checked Then
            OtherCreativeOnlyItem = True
        Else
            OtherCreativeOnlyItem = False
        End If
    End Sub

    Private Sub tbDatapackPath_TextChanged(sender As Object, e As EventArgs) Handles tbDatapackPath.TextChanged
        DatapackPath = tbDatapackPath.Text
        If FirstLoadCompleted Then
            DetermineDatapackVersion()
        End If
    End Sub

    Private Sub cbxVersion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxVersion.SelectedIndexChanged
        DatapackVersion = cbxVersion.SelectedItem
    End Sub

    Private Sub bgwAddItems_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwAddItems.RunWorkerCompleted
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
        cbGoatHorn.Enabled = True
        rtbItem.Enabled = True
        cbSamePrefix.Enabled = True
        tbSamePrefix.Enabled = True
        cbCustomNBT.Enabled = True
        tbCustomNBT.Enabled = True
        cbAddItemsFast.Enabled = True
        cbxVersion.Enabled = True
        btnBrowseDatapackPath.Enabled = True
        tbDatapackPath.Enabled = True
        If AddItemResult = "success" Then
            MsgBox("Successfully added " + rtbItem.Lines.Count.ToString + " item(s)!", MsgBoxStyle.Information, "Added items")
        End If
        btnAddItem.Show()
    End Sub

    Private Sub bgwAddItems_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bgwAddItems.ProgressChanged
        pbAddingItemsProgress.Value = e.ProgressPercentage
    End Sub

    Private Sub cbEnableAdvancedView_CheckedChanged(sender As Object, e As EventArgs) Handles cbEnableAdvancedView.CheckedChanged
        If cbEnableAdvancedView.Checked Then
            EnableAdvancedView()
        Else
            DisableAdvancedView()
        End If
    End Sub

    Private Sub btnLoadProfile_Click(sender As Object, e As EventArgs) Handles btnLoadProfile.Click
        frmLoadProfileFrom.ShowDialog()
    End Sub

    Private Sub btnSaveProfile_Click(sender As Object, e As EventArgs) Handles btnSaveProfile.Click
        frmSaveProfileAs.ShowDialog()
    End Sub

    Private Sub frmMain_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        DetermineDatapackVersion()
        FirstLoadCompleted = True
    End Sub

    Private Sub cbxScheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxScheme.SelectedIndexChanged
        'Starts the whole loading process of the scheme
        InitializeLoadingScheme(cbxScheme.SelectedItem, False)
    End Sub

    Public Sub InitializeLoadingScheme(Scheme As String, ShowMessage As Boolean)
        'Checks if a scheme is selected. It then reads the content of the scheme file into the array. To avoid errors with the array being too small, it gets resized. The number represents the amount of settings.
        'It then starts to convert and load the scheme, see the the method below.
        If String.IsNullOrEmpty(Scheme) = False Then
            LoadFromScheme = SchemeDirectory + Scheme + ".txt"
            SchemeContent = File.ReadAllLines(LoadFromScheme)
            ReDim Preserve SchemeContent(16)
            CheckAndConvertScheme(Scheme, ShowMessage)
        Else
            MsgBox("Error: No scheme selected. Please select a scheme to load from.", MsgBoxStyle.Critical, "Error")
        End If
    End Sub

    Public Sub CheckAndConvertScheme(Scheme As String, ShowMessage As Boolean)
        'This checks if the scheme file that was loaded has enough lines, too few lines would mean that settings are missing, meaning the file is either too old or corrupted.
        'It will check for each required line if it is empty (required lines = the length of a healthy, normal scheme file). Make sure that the line amount it checks matches the amount of settings that are being saved.
        'If a line is empty, it will fill that line with a placeholder in the array so the profile can get loaded without errors. After loading the scheme, it gets automatically saved so the corrupted/old settings file gets fixed.
        'If no required line is empty and the file is fine, it will just load the scheme like normal.
        If (String.IsNullOrEmpty(SchemeContent(0)) OrElse String.IsNullOrEmpty(SchemeContent(1)) OrElse String.IsNullOrEmpty(SchemeContent(2)) OrElse String.IsNullOrEmpty(SchemeContent(3)) OrElse String.IsNullOrEmpty(SchemeContent(4)) OrElse String.IsNullOrEmpty(SchemeContent(5)) OrElse String.IsNullOrEmpty(SchemeContent(6)) OrElse String.IsNullOrEmpty(SchemeContent(7)) OrElse String.IsNullOrEmpty(SchemeContent(8)) OrElse String.IsNullOrEmpty(SchemeContent(9)) OrElse String.IsNullOrEmpty(SchemeContent(10)) OrElse String.IsNullOrEmpty(SchemeContent(11)) OrElse String.IsNullOrEmpty(SchemeContent(12)) OrElse String.IsNullOrEmpty(SchemeContent(13)) OrElse String.IsNullOrEmpty(SchemeContent(14)) OrElse String.IsNullOrEmpty(SchemeContent(15))) Then
            Select Case MsgBox("You are trying to load a scheme from an older version or a corrupted scheme. You need to update it in order to load it. You usually won't lose any settings. Do you want to continue?", MsgBoxStyle.YesNo, "Load old or corrupted scheme")
                Case Windows.Forms.DialogResult.Yes
                    If String.IsNullOrEmpty(SchemeContent(0)) Then
                        SchemeContent(0) = True
                    End If
                    If String.IsNullOrEmpty(SchemeContent(1)) Then
                        SchemeContent(1) = "minecraft"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(2)) Then
                        SchemeContent(2) = False
                    End If
                    If String.IsNullOrEmpty(SchemeContent(3)) Then
                        SchemeContent(3) = "None"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(4)) Then
                        SchemeContent(4) = "True"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(5)) Then
                        SchemeContent(5) = "False"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(6)) Then
                        SchemeContent(6) = "False"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(7)) Then
                        SchemeContent(7) = "False"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(8)) Then
                        SchemeContent(8) = "False"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(9)) Then
                        SchemeContent(9) = "False"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(10)) Then
                        SchemeContent(10) = "False"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(11)) Then
                        SchemeContent(11) = "False"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(12)) Then
                        SchemeContent(12) = "False"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(13)) Then
                        SchemeContent(13) = "False"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(14)) Then
                        SchemeContent(14) = "False"
                    End If
                    If String.IsNullOrEmpty(SchemeContent(15)) Then
                        SchemeContent(15) = "False"
                    End If
                    LoadScheme(Scheme, False)
                    UpdateScheme(Scheme)
                    MsgBox("Loaded and updated scheme. It should now work correctly!", MsgBoxStyle.Information, "Loaded and updated scheme")
                    WriteToLog("Loaded and updated scheme " + Scheme, "Info")
                Case Windows.Forms.DialogResult.No
                    MsgBox("Cancelled loading scheme.", MsgBoxStyle.Exclamation, "Warning")
            End Select
        Else
            LoadScheme(Scheme, ShowMessage)
            WriteToLog("Loaded scheme " + Scheme, "Info")
        End If
    End Sub

    Public Sub LoadScheme(Scheme As String, ShowMessage As Boolean)
        'Same Prefix Checkbox
        SamePrefix = Convert.ToBoolean(SchemeContent(0))
        If SamePrefix = True Then
            cbSamePrefix.Checked = True
        Else
            cbSamePrefix.Checked = False
        End If

        'Same Prefix Textbox
        If String.IsNullOrEmpty(tbSamePrefix.Text) Then
            tbSamePrefix.Text = "None"
        Else
            tbSamePrefix.Text = SchemeContent(1)
        End If

        'Custom NBT Checkbox
        CustomNBT = Convert.ToBoolean(SchemeContent(2))
        If CustomNBT = True Then
            cbCustomNBT.Checked = True
        Else
            cbCustomNBT.Checked = False
        End If

        'Custom NBT Textbox
        If String.IsNullOrEmpty(tbCustomNBT.Text) Then
            tbCustomNBT.Text = "None"
        Else
            tbCustomNBT.Text = SchemeContent(3)
        End If

        'Normal Item Checkbox
        NormalItem = Convert.ToBoolean(SchemeContent(4))
        If NormalItem = True Then
            cbNormalItem.Checked = True
        Else
            cbNormalItem.Checked = False
        End If

        'Suspicious Stew Checkbox
        SuspiciousStew = Convert.ToBoolean(SchemeContent(5))
        If SuspiciousStew = True Then
            cbSuspiciousStew.Checked = True
        Else
            cbSuspiciousStew.Checked = False
        End If

        'Enchanted Book Checkbox
        EnchantedBook = Convert.ToBoolean(SchemeContent(6))
        If EnchantedBook = True Then
            cbEnchantedBook.Checked = True
        Else
            cbEnchantedBook.Checked = False
        End If

        'Potion Book Checkbox
        Potion = Convert.ToBoolean(SchemeContent(7))
        If Potion = True Then
            cbPotion.Checked = True
        Else
            cbPotion.Checked = False
        End If

        'Splash Potion Checkbox
        SplashPotion = Convert.ToBoolean(SchemeContent(8))
        If SplashPotion = True Then
            cbSplashPotion.Checked = True
        Else
            cbSplashPotion.Checked = False
        End If

        'Lingering Potion Checkbox
        LingeringPotion = Convert.ToBoolean(SchemeContent(9))
        If LingeringPotion = True Then
            cbLingeringPotion.Checked = True
        Else
            cbLingeringPotion.Checked = False
        End If

        'Tipped Arrow Checkbox
        TippedArrow = Convert.ToBoolean(SchemeContent(10))
        If TippedArrow = True Then
            cbTippedArrow.Checked = True
        Else
            cbTippedArrow.Checked = False
        End If

        'Goat Horn Checkbox
        GoatHorn = Convert.ToBoolean(SchemeContent(11))
        If GoatHorn = True Then
            cbGoatHorn.Checked = True
        Else
            cbGoatHorn.Checked = False
        End If

        'Creative-Only Checkbox
        CreativeOnly = Convert.ToBoolean(SchemeContent(12))
        If CreativeOnly = True Then
            cbCreativeOnly.Checked = True

            'Spawn Egg Radiobutton
            SpawnEgg = Convert.ToBoolean(SchemeContent(13))
            If SpawnEgg = True Then
                rbtnSpawnEgg.Checked = True
            Else
                rbtnSpawnEgg.Checked = False
            End If

            'Command Block Radiobutton
            CommandBlock = Convert.ToBoolean(SchemeContent(14))
            If CommandBlock = True Then
                rbtnCommandBlock.Checked = True
            Else
                rbtnCommandBlock.Checked = False
            End If

            'Other Creative-Only Item Radiobutton
            OtherCreativeOnlyItem = Convert.ToBoolean(SchemeContent(15))
            If OtherCreativeOnlyItem = True Then
                rbtnOtherItem.Checked = True
            Else
                rbtnOtherItem.Checked = False
            End If
        Else
            cbCreativeOnly.Checked = False
        End If

        'If ShowMessage is enabled, it will show a messagebox when loading completes.
        If ShowMessage Then
            MsgBox("Loaded scheme " + Scheme + ".", MsgBoxStyle.Information, "Loaded profile")
        End If
    End Sub

    Public Sub UpdateScheme(SchemeName)

        'Save currently selected settings into Variables
        If rbtnSpawnEgg.Checked = True Then
            SpawnEgg = True
        Else
            SpawnEgg = False
        End If
        If rbtnCommandBlock.Checked = True Then
            CommandBlock = True
        Else
            SpawnEgg = False
        End If
        If rbtnOtherItem.Checked = True Then
            OtherCreativeOnlyItem = True
        Else
            OtherCreativeOnlyItem = False
        End If
        If cbSamePrefix.Checked Then
            SamePrefix = True
        Else
            SamePrefix = False
        End If
        If cbCustomNBT.Checked = True Then
            CustomNBT = True
        Else
            CustomNBT = False
        End If
        If cbNormalItem.Checked = True Then
            NormalItem = True
        Else
            NormalItem = False
        End If
        If cbSuspiciousStew.Checked = True Then
            SuspiciousStew = True
        Else
            SuspiciousStew = False
        End If
        If cbEnchantedBook.Checked = True Then
            EnchantedBook = True
        Else
            EnchantedBook = False
        End If
        If cbPotion.Checked = True Then
            Potion = True
        Else
            Potion = False
        End If
        If cbSplashPotion.Checked = True Then
            SplashPotion = True
        Else
            SplashPotion = False
        End If
        If cbLingeringPotion.Checked = True Then
            LingeringPotion = True
        Else
            LingeringPotion = False
        End If
        If cbTippedArrow.Checked = True Then
            TippedArrow = True
        Else
            TippedArrow = False
        End If
        If cbGoatHorn.Checked = True Then
            GoatHorn = True
        Else
            GoatHorn = False
        End If
        If cbCreativeOnly.Checked = True Then
            CreativeOnly = True
        Else
            CreativeOnly = False
        End If
        If String.IsNullOrEmpty(tbSamePrefix.Text) Then
            SamePrefixString = "minecraft"
        Else
            SamePrefixString = tbSamePrefix.Text
        End If
        If String.IsNullOrEmpty(tbCustomNBT.Text) Then
            CustomNBTString = "None"
        Else
            CustomNBTString = tbCustomNBT.Text
        End If

        'Update the selected scheme. This will save and overwrite the selected scheme without showing any warning or message. Used if a profile is old or corrupted.
        If String.IsNullOrEmpty(SchemeName) = False Then
            If My.Computer.FileSystem.DirectoryExists(SchemeDirectory) Then
                My.Computer.FileSystem.WriteAllText(SchemeDirectory + SchemeName + ".txt", SamePrefix.ToString + vbNewLine + SamePrefixString + vbNewLine + CustomNBT.ToString + vbNewLine + CustomNBTString + vbNewLine + NormalItem.ToString + vbNewLine + SuspiciousStew.ToString + vbNewLine + EnchantedBook.ToString + vbNewLine + Potion.ToString + vbNewLine + SplashPotion.ToString + vbNewLine + LingeringPotion.ToString + vbNewLine + TippedArrow.ToString + vbNewLine + GoatHorn.ToString + vbNewLine + CreativeOnly.ToString + vbNewLine + SpawnEgg.ToString + vbNewLine + CommandBlock.ToString + vbNewLine + OtherCreativeOnlyItem.ToString + vbNewLine, False)
            Else
                MsgBox("Error: Couldn't update scheme. Scheme directory does not exist. Please restart the application.", MsgBoxStyle.Critical, "Error")
            End If
        Else
            MsgBox("Error: Couldn't update scheme as the name is empty.", MsgBoxStyle.Critical, "Error")
        End If
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
        frmSaveSchemeAs.ShowDialog()
    End Sub

    Private Sub btnOverwriteSelectedScheme_Click(sender As Object, e As EventArgs) Handles btnOverwriteSelectedScheme.Click
        frmSaveSchemeAs.SaveScheme(cbxScheme.SelectedIndex, True)
    End Sub
End Class
