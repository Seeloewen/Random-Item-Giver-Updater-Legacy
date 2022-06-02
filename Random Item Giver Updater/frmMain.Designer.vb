<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.gbDatapack = New System.Windows.Forms.GroupBox()
        Me.lblDatapackDetection = New System.Windows.Forms.Label()
        Me.btnBrowseDatapackPath = New System.Windows.Forms.Button()
        Me.tbDatapackPath = New System.Windows.Forms.TextBox()
        Me.lblSelectDatapack = New System.Windows.Forms.Label()
        Me.gbItem = New System.Windows.Forms.GroupBox()
        Me.cbGoatHorn = New System.Windows.Forms.CheckBox()
        Me.cbNormalItem = New System.Windows.Forms.CheckBox()
        Me.cbNBT = New System.Windows.Forms.CheckBox()
        Me.tbNBT = New System.Windows.Forms.TextBox()
        Me.tbSmallOutput = New System.Windows.Forms.TextBox()
        Me.lblOutput = New System.Windows.Forms.Label()
        Me.tbSamePrefix = New System.Windows.Forms.TextBox()
        Me.cbSamePrefix = New System.Windows.Forms.CheckBox()
        Me.rbtnCommandBlock = New System.Windows.Forms.RadioButton()
        Me.rbtnOtherItem = New System.Windows.Forms.RadioButton()
        Me.rbtnSpawnEgg = New System.Windows.Forms.RadioButton()
        Me.cbSplashPotion = New System.Windows.Forms.CheckBox()
        Me.cbLingeringPotion = New System.Windows.Forms.CheckBox()
        Me.cbTippedArrow = New System.Windows.Forms.CheckBox()
        Me.cbSuspiciousStew = New System.Windows.Forms.CheckBox()
        Me.cbPotion = New System.Windows.Forms.CheckBox()
        Me.cbEnchantedBook = New System.Windows.Forms.CheckBox()
        Me.cbCreativeOnly = New System.Windows.Forms.CheckBox()
        Me.lblID = New System.Windows.Forms.Label()
        Me.lblAddNewItems = New System.Windows.Forms.Label()
        Me.gbItemID = New System.Windows.Forms.GroupBox()
        Me.rtbItem = New System.Windows.Forms.RichTextBox()
        Me.btnShowOutput = New System.Windows.Forms.Button()
        Me.btnAddItem = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenDatapackFolderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.OutputToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindDuplicatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportItemListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SoftwareHelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ChangelogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.fbdMainFolderPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.Quotationmark = New System.Windows.Forms.Label()
        Me.rtbCodeEnd = New System.Windows.Forms.RichTextBox()
        Me.rtb64Items = New System.Windows.Forms.RichTextBox()
        Me.rtb32Items = New System.Windows.Forms.RichTextBox()
        Me.rtb10Items = New System.Windows.Forms.RichTextBox()
        Me.rtb3Items = New System.Windows.Forms.RichTextBox()
        Me.rtb5Items = New System.Windows.Forms.RichTextBox()
        Me.rtb2Items = New System.Windows.Forms.RichTextBox()
        Me.rtbLog = New System.Windows.Forms.RichTextBox()
        Me.cbxVersion = New System.Windows.Forms.ComboBox()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.gbDatapack.SuspendLayout()
        Me.gbItem.SuspendLayout()
        Me.gbItemID.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(12, 33)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(340, 24)
        Me.lblHeader.TabIndex = 56
        Me.lblHeader.Text = "Random Item Giver Updater ALPHA"
        '
        'gbDatapack
        '
        Me.gbDatapack.Controls.Add(Me.lblVersion)
        Me.gbDatapack.Controls.Add(Me.cbxVersion)
        Me.gbDatapack.Controls.Add(Me.lblDatapackDetection)
        Me.gbDatapack.Controls.Add(Me.btnBrowseDatapackPath)
        Me.gbDatapack.Controls.Add(Me.tbDatapackPath)
        Me.gbDatapack.Controls.Add(Me.lblSelectDatapack)
        Me.gbDatapack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatapack.Location = New System.Drawing.Point(16, 63)
        Me.gbDatapack.Name = "gbDatapack"
        Me.gbDatapack.Size = New System.Drawing.Size(638, 127)
        Me.gbDatapack.TabIndex = 57
        Me.gbDatapack.TabStop = False
        Me.gbDatapack.Text = "Select datapack"
        '
        'lblDatapackDetection
        '
        Me.lblDatapackDetection.AutoSize = True
        Me.lblDatapackDetection.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatapackDetection.ForeColor = System.Drawing.Color.Black
        Me.lblDatapackDetection.Location = New System.Drawing.Point(14, 70)
        Me.lblDatapackDetection.Name = "lblDatapackDetection"
        Me.lblDatapackDetection.Size = New System.Drawing.Size(156, 18)
        Me.lblDatapackDetection.TabIndex = 7
        Me.lblDatapackDetection.Text = "No datapack detected."
        '
        'btnBrowseDatapackPath
        '
        Me.btnBrowseDatapackPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseDatapackPath.Location = New System.Drawing.Point(499, 41)
        Me.btnBrowseDatapackPath.Name = "btnBrowseDatapackPath"
        Me.btnBrowseDatapackPath.Size = New System.Drawing.Size(129, 23)
        Me.btnBrowseDatapackPath.TabIndex = 2
        Me.btnBrowseDatapackPath.Text = "Browse"
        Me.btnBrowseDatapackPath.UseVisualStyleBackColor = True
        '
        'tbDatapackPath
        '
        Me.tbDatapackPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDatapackPath.Location = New System.Drawing.Point(15, 42)
        Me.tbDatapackPath.Name = "tbDatapackPath"
        Me.tbDatapackPath.Size = New System.Drawing.Size(478, 22)
        Me.tbDatapackPath.TabIndex = 1
        '
        'lblSelectDatapack
        '
        Me.lblSelectDatapack.AutoSize = True
        Me.lblSelectDatapack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectDatapack.Location = New System.Drawing.Point(12, 22)
        Me.lblSelectDatapack.Name = "lblSelectDatapack"
        Me.lblSelectDatapack.Size = New System.Drawing.Size(331, 16)
        Me.lblSelectDatapack.TabIndex = 0
        Me.lblSelectDatapack.Text = "Please choose the datapack and which version it is for."
        '
        'gbItem
        '
        Me.gbItem.Controls.Add(Me.cbGoatHorn)
        Me.gbItem.Controls.Add(Me.cbNormalItem)
        Me.gbItem.Controls.Add(Me.cbNBT)
        Me.gbItem.Controls.Add(Me.tbNBT)
        Me.gbItem.Controls.Add(Me.tbSmallOutput)
        Me.gbItem.Controls.Add(Me.lblOutput)
        Me.gbItem.Controls.Add(Me.tbSamePrefix)
        Me.gbItem.Controls.Add(Me.cbSamePrefix)
        Me.gbItem.Controls.Add(Me.rbtnCommandBlock)
        Me.gbItem.Controls.Add(Me.rbtnOtherItem)
        Me.gbItem.Controls.Add(Me.rbtnSpawnEgg)
        Me.gbItem.Controls.Add(Me.cbSplashPotion)
        Me.gbItem.Controls.Add(Me.cbLingeringPotion)
        Me.gbItem.Controls.Add(Me.cbTippedArrow)
        Me.gbItem.Controls.Add(Me.cbSuspiciousStew)
        Me.gbItem.Controls.Add(Me.cbPotion)
        Me.gbItem.Controls.Add(Me.cbEnchantedBook)
        Me.gbItem.Controls.Add(Me.cbCreativeOnly)
        Me.gbItem.Controls.Add(Me.lblID)
        Me.gbItem.Controls.Add(Me.lblAddNewItems)
        Me.gbItem.Controls.Add(Me.gbItemID)
        Me.gbItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbItem.Location = New System.Drawing.Point(16, 196)
        Me.gbItem.Name = "gbItem"
        Me.gbItem.Size = New System.Drawing.Size(638, 300)
        Me.gbItem.TabIndex = 58
        Me.gbItem.TabStop = False
        Me.gbItem.Text = "Add item"
        '
        'cbGoatHorn
        '
        Me.cbGoatHorn.AutoSize = True
        Me.cbGoatHorn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGoatHorn.Location = New System.Drawing.Point(300, 230)
        Me.cbGoatHorn.Name = "cbGoatHorn"
        Me.cbGoatHorn.Size = New System.Drawing.Size(87, 20)
        Me.cbGoatHorn.TabIndex = 83
        Me.cbGoatHorn.Text = "Goat Horn"
        Me.cbGoatHorn.UseVisualStyleBackColor = True
        '
        'cbNormalItem
        '
        Me.cbNormalItem.AutoSize = True
        Me.cbNormalItem.Checked = True
        Me.cbNormalItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNormalItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNormalItem.Location = New System.Drawing.Point(300, 61)
        Me.cbNormalItem.Name = "cbNormalItem"
        Me.cbNormalItem.Size = New System.Drawing.Size(98, 20)
        Me.cbNormalItem.TabIndex = 80
        Me.cbNormalItem.Text = "Normal item"
        Me.cbNormalItem.UseVisualStyleBackColor = True
        '
        'cbNBT
        '
        Me.cbNBT.AutoSize = True
        Me.cbNBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNBT.Location = New System.Drawing.Point(14, 205)
        Me.cbNBT.Name = "cbNBT"
        Me.cbNBT.Size = New System.Drawing.Size(171, 20)
        Me.cbNBT.TabIndex = 79
        Me.cbNBT.Text = "NBT Tag (Potions, etc...)"
        Me.cbNBT.UseVisualStyleBackColor = True
        '
        'tbNBT
        '
        Me.tbNBT.Enabled = False
        Me.tbNBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbNBT.Location = New System.Drawing.Point(14, 231)
        Me.tbNBT.Name = "tbNBT"
        Me.tbNBT.Size = New System.Drawing.Size(242, 22)
        Me.tbNBT.TabIndex = 78
        '
        'tbSmallOutput
        '
        Me.tbSmallOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSmallOutput.Location = New System.Drawing.Point(66, 268)
        Me.tbSmallOutput.Multiline = True
        Me.tbSmallOutput.Name = "tbSmallOutput"
        Me.tbSmallOutput.ReadOnly = True
        Me.tbSmallOutput.Size = New System.Drawing.Size(562, 20)
        Me.tbSmallOutput.TabIndex = 77
        '
        'lblOutput
        '
        Me.lblOutput.AutoSize = True
        Me.lblOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutput.Location = New System.Drawing.Point(12, 268)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(48, 16)
        Me.lblOutput.TabIndex = 76
        Me.lblOutput.Text = "Output:"
        '
        'tbSamePrefix
        '
        Me.tbSamePrefix.Enabled = False
        Me.tbSamePrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSamePrefix.Location = New System.Drawing.Point(14, 177)
        Me.tbSamePrefix.Name = "tbSamePrefix"
        Me.tbSamePrefix.Size = New System.Drawing.Size(242, 22)
        Me.tbSamePrefix.TabIndex = 75
        Me.tbSamePrefix.Text = "minecraft"
        '
        'cbSamePrefix
        '
        Me.cbSamePrefix.AutoSize = True
        Me.cbSamePrefix.Checked = True
        Me.cbSamePrefix.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSamePrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSamePrefix.Location = New System.Drawing.Point(14, 154)
        Me.cbSamePrefix.Name = "cbSamePrefix"
        Me.cbSamePrefix.Size = New System.Drawing.Size(214, 20)
        Me.cbSamePrefix.TabIndex = 73
        Me.cbSamePrefix.Text = "Use the same prefix for all items"
        Me.cbSamePrefix.UseVisualStyleBackColor = True
        '
        'rbtnCommandBlock
        '
        Me.rbtnCommandBlock.AutoSize = True
        Me.rbtnCommandBlock.Enabled = False
        Me.rbtnCommandBlock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnCommandBlock.Location = New System.Drawing.Point(463, 106)
        Me.rbtnCommandBlock.Name = "rbtnCommandBlock"
        Me.rbtnCommandBlock.Size = New System.Drawing.Size(124, 20)
        Me.rbtnCommandBlock.TabIndex = 72
        Me.rbtnCommandBlock.TabStop = True
        Me.rbtnCommandBlock.Text = "Command Block"
        Me.rbtnCommandBlock.UseVisualStyleBackColor = True
        '
        'rbtnOtherItem
        '
        Me.rbtnOtherItem.AutoSize = True
        Me.rbtnOtherItem.Enabled = False
        Me.rbtnOtherItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnOtherItem.Location = New System.Drawing.Point(463, 130)
        Me.rbtnOtherItem.Name = "rbtnOtherItem"
        Me.rbtnOtherItem.Size = New System.Drawing.Size(169, 20)
        Me.rbtnOtherItem.TabIndex = 71
        Me.rbtnOtherItem.TabStop = True
        Me.rbtnOtherItem.Text = "Other Creative-Only item"
        Me.rbtnOtherItem.UseVisualStyleBackColor = True
        '
        'rbtnSpawnEgg
        '
        Me.rbtnSpawnEgg.AutoSize = True
        Me.rbtnSpawnEgg.Enabled = False
        Me.rbtnSpawnEgg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSpawnEgg.Location = New System.Drawing.Point(463, 83)
        Me.rbtnSpawnEgg.Name = "rbtnSpawnEgg"
        Me.rbtnSpawnEgg.Size = New System.Drawing.Size(94, 20)
        Me.rbtnSpawnEgg.TabIndex = 70
        Me.rbtnSpawnEgg.TabStop = True
        Me.rbtnSpawnEgg.Text = "Spawn Egg"
        Me.rbtnSpawnEgg.UseVisualStyleBackColor = True
        '
        'cbSplashPotion
        '
        Me.cbSplashPotion.AutoSize = True
        Me.cbSplashPotion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSplashPotion.Location = New System.Drawing.Point(300, 154)
        Me.cbSplashPotion.Name = "cbSplashPotion"
        Me.cbSplashPotion.Size = New System.Drawing.Size(109, 20)
        Me.cbSplashPotion.TabIndex = 69
        Me.cbSplashPotion.Text = "Splash Potion"
        Me.cbSplashPotion.UseVisualStyleBackColor = True
        '
        'cbLingeringPotion
        '
        Me.cbLingeringPotion.AutoSize = True
        Me.cbLingeringPotion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLingeringPotion.Location = New System.Drawing.Point(300, 178)
        Me.cbLingeringPotion.Name = "cbLingeringPotion"
        Me.cbLingeringPotion.Size = New System.Drawing.Size(122, 20)
        Me.cbLingeringPotion.TabIndex = 68
        Me.cbLingeringPotion.Text = "Lingering Potion"
        Me.cbLingeringPotion.UseVisualStyleBackColor = True
        '
        'cbTippedArrow
        '
        Me.cbTippedArrow.AutoSize = True
        Me.cbTippedArrow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTippedArrow.Location = New System.Drawing.Point(300, 204)
        Me.cbTippedArrow.Name = "cbTippedArrow"
        Me.cbTippedArrow.Size = New System.Drawing.Size(107, 20)
        Me.cbTippedArrow.TabIndex = 67
        Me.cbTippedArrow.Text = "Tipped Arrow"
        Me.cbTippedArrow.UseVisualStyleBackColor = True
        '
        'cbSuspiciousStew
        '
        Me.cbSuspiciousStew.AutoSize = True
        Me.cbSuspiciousStew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSuspiciousStew.Location = New System.Drawing.Point(300, 83)
        Me.cbSuspiciousStew.Name = "cbSuspiciousStew"
        Me.cbSuspiciousStew.Size = New System.Drawing.Size(124, 20)
        Me.cbSuspiciousStew.TabIndex = 66
        Me.cbSuspiciousStew.Text = "Suspicious Stew"
        Me.cbSuspiciousStew.UseVisualStyleBackColor = True
        '
        'cbPotion
        '
        Me.cbPotion.AutoSize = True
        Me.cbPotion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPotion.Location = New System.Drawing.Point(300, 130)
        Me.cbPotion.Name = "cbPotion"
        Me.cbPotion.Size = New System.Drawing.Size(64, 20)
        Me.cbPotion.TabIndex = 65
        Me.cbPotion.Text = "Potion"
        Me.cbPotion.UseVisualStyleBackColor = True
        '
        'cbEnchantedBook
        '
        Me.cbEnchantedBook.AutoSize = True
        Me.cbEnchantedBook.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEnchantedBook.Location = New System.Drawing.Point(300, 106)
        Me.cbEnchantedBook.Name = "cbEnchantedBook"
        Me.cbEnchantedBook.Size = New System.Drawing.Size(125, 20)
        Me.cbEnchantedBook.TabIndex = 64
        Me.cbEnchantedBook.Text = "Enchanted Book"
        Me.cbEnchantedBook.UseVisualStyleBackColor = True
        '
        'cbCreativeOnly
        '
        Me.cbCreativeOnly.AutoSize = True
        Me.cbCreativeOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCreativeOnly.Location = New System.Drawing.Point(449, 61)
        Me.cbCreativeOnly.Name = "cbCreativeOnly"
        Me.cbCreativeOnly.Size = New System.Drawing.Size(107, 20)
        Me.cbCreativeOnly.TabIndex = 61
        Me.cbCreativeOnly.Text = "Creative-Only"
        Me.cbCreativeOnly.UseVisualStyleBackColor = True
        '
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblID.Location = New System.Drawing.Point(12, 50)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(63, 16)
        Me.lblID.TabIndex = 60
        Me.lblID.Text = "Items (ID)"
        '
        'lblAddNewItems
        '
        Me.lblAddNewItems.AutoSize = True
        Me.lblAddNewItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddNewItems.Location = New System.Drawing.Point(12, 24)
        Me.lblAddNewItems.Name = "lblAddNewItems"
        Me.lblAddNewItems.Size = New System.Drawing.Size(261, 16)
        Me.lblAddNewItems.TabIndex = 56
        Me.lblAddNewItems.Text = "Add new items and blocks to the datapack."
        '
        'gbItemID
        '
        Me.gbItemID.Controls.Add(Me.rtbItem)
        Me.gbItemID.Location = New System.Drawing.Point(14, 65)
        Me.gbItemID.Name = "gbItemID"
        Me.gbItemID.Size = New System.Drawing.Size(242, 83)
        Me.gbItemID.TabIndex = 82
        Me.gbItemID.TabStop = False
        '
        'rtbItem
        '
        Me.rtbItem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbItem.Location = New System.Drawing.Point(6, 18)
        Me.rtbItem.Name = "rtbItem"
        Me.rtbItem.Size = New System.Drawing.Size(230, 58)
        Me.rtbItem.TabIndex = 81
        Me.rtbItem.Text = ""
        '
        'btnShowOutput
        '
        Me.btnShowOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowOutput.Location = New System.Drawing.Point(465, 502)
        Me.btnShowOutput.Name = "btnShowOutput"
        Me.btnShowOutput.Size = New System.Drawing.Size(189, 34)
        Me.btnShowOutput.TabIndex = 74
        Me.btnShowOutput.Text = "Show output"
        Me.btnShowOutput.UseVisualStyleBackColor = True
        '
        'btnAddItem
        '
        Me.btnAddItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddItem.Location = New System.Drawing.Point(16, 502)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(443, 34)
        Me.btnAddItem.TabIndex = 63
        Me.btnAddItem.Text = "Add item to datapack"
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(664, 24)
        Me.MenuStrip1.TabIndex = 65
        Me.MenuStrip1.Text = "msMain"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenDatapackFolderToolStripMenuItem, Me.ToolStripSeparator3, Me.OutputToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ToolStripSeparator2, Me.CloseToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenDatapackFolderToolStripMenuItem
        '
        Me.OpenDatapackFolderToolStripMenuItem.Name = "OpenDatapackFolderToolStripMenuItem"
        Me.OpenDatapackFolderToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.OpenDatapackFolderToolStripMenuItem.Text = "Datapack folder"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(154, 6)
        '
        'OutputToolStripMenuItem
        '
        Me.OutputToolStripMenuItem.Name = "OutputToolStripMenuItem"
        Me.OutputToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.OutputToolStripMenuItem.Text = "Output"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(154, 6)
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(157, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindDuplicatesToolStripMenuItem, Me.ImportItemListToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'FindDuplicatesToolStripMenuItem
        '
        Me.FindDuplicatesToolStripMenuItem.Name = "FindDuplicatesToolStripMenuItem"
        Me.FindDuplicatesToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.FindDuplicatesToolStripMenuItem.Text = "Duplicate Finder"
        '
        'ImportItemListToolStripMenuItem
        '
        Me.ImportItemListToolStripMenuItem.Name = "ImportItemListToolStripMenuItem"
        Me.ImportItemListToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ImportItemListToolStripMenuItem.Text = "Item List Importer"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SoftwareHelpToolStripMenuItem, Me.ToolStripSeparator1, Me.ChangelogToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'SoftwareHelpToolStripMenuItem
        '
        Me.SoftwareHelpToolStripMenuItem.Name = "SoftwareHelpToolStripMenuItem"
        Me.SoftwareHelpToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.SoftwareHelpToolStripMenuItem.Text = "Software help"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(143, 6)
        '
        'ChangelogToolStripMenuItem
        '
        Me.ChangelogToolStripMenuItem.Name = "ChangelogToolStripMenuItem"
        Me.ChangelogToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.ChangelogToolStripMenuItem.Text = "Changelog"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'fbdMainFolderPath
        '
        Me.fbdMainFolderPath.Description = "Select the datapack which you want to edit."
        '
        'Quotationmark
        '
        Me.Quotationmark.AutoSize = True
        Me.Quotationmark.Location = New System.Drawing.Point(869, 219)
        Me.Quotationmark.Name = "Quotationmark"
        Me.Quotationmark.Size = New System.Drawing.Size(12, 13)
        Me.Quotationmark.TabIndex = 82
        Me.Quotationmark.Text = """"
        '
        'rtbCodeEnd
        '
        Me.rtbCodeEnd.Location = New System.Drawing.Point(901, 217)
        Me.rtbCodeEnd.Name = "rtbCodeEnd"
        Me.rtbCodeEnd.Size = New System.Drawing.Size(49, 45)
        Me.rtbCodeEnd.TabIndex = 81
        Me.rtbCodeEnd.Text = "        }" & Global.Microsoft.VisualBasic.ChrW(10) & "      ]" & Global.Microsoft.VisualBasic.ChrW(10) & "    }" & Global.Microsoft.VisualBasic.ChrW(10) & "  ]" & Global.Microsoft.VisualBasic.ChrW(10) & "}"
        '
        'rtb64Items
        '
        Me.rtb64Items.Location = New System.Drawing.Point(927, 166)
        Me.rtb64Items.Name = "rtb64Items"
        Me.rtb64Items.Size = New System.Drawing.Size(49, 45)
        Me.rtb64Items.TabIndex = 80
        Me.rtb64Items.Text = "          ""functions"": [" & Global.Microsoft.VisualBasic.ChrW(10) & "            {" & Global.Microsoft.VisualBasic.ChrW(10) & "              ""function"": ""minecraft:set_c" &
    "ount""," & Global.Microsoft.VisualBasic.ChrW(10) & "              ""count"": 64" & Global.Microsoft.VisualBasic.ChrW(10) & "            }"
        '
        'rtb32Items
        '
        Me.rtb32Items.Location = New System.Drawing.Point(872, 166)
        Me.rtb32Items.Name = "rtb32Items"
        Me.rtb32Items.Size = New System.Drawing.Size(49, 45)
        Me.rtb32Items.TabIndex = 79
        Me.rtb32Items.Text = "          ""functions"": [" & Global.Microsoft.VisualBasic.ChrW(10) & "            {" & Global.Microsoft.VisualBasic.ChrW(10) & "              ""function"": ""minecraft:set_c" &
    "ount""," & Global.Microsoft.VisualBasic.ChrW(10) & "              ""count"": 32" & Global.Microsoft.VisualBasic.ChrW(10) & "            }"
        '
        'rtb10Items
        '
        Me.rtb10Items.Location = New System.Drawing.Point(927, 115)
        Me.rtb10Items.Name = "rtb10Items"
        Me.rtb10Items.Size = New System.Drawing.Size(49, 45)
        Me.rtb10Items.TabIndex = 78
        Me.rtb10Items.Text = "          ""functions"": [" & Global.Microsoft.VisualBasic.ChrW(10) & "            {" & Global.Microsoft.VisualBasic.ChrW(10) & "              ""function"": ""minecraft:set_c" &
    "ount""," & Global.Microsoft.VisualBasic.ChrW(10) & "              ""count"": 10" & Global.Microsoft.VisualBasic.ChrW(10) & "            }"
        '
        'rtb3Items
        '
        Me.rtb3Items.Location = New System.Drawing.Point(927, 63)
        Me.rtb3Items.Name = "rtb3Items"
        Me.rtb3Items.Size = New System.Drawing.Size(49, 45)
        Me.rtb3Items.TabIndex = 77
        Me.rtb3Items.Text = "          ""functions"": [" & Global.Microsoft.VisualBasic.ChrW(10) & "            {" & Global.Microsoft.VisualBasic.ChrW(10) & "              ""function"": ""minecraft:set_c" &
    "ount""," & Global.Microsoft.VisualBasic.ChrW(10) & "              ""count"": 3" & Global.Microsoft.VisualBasic.ChrW(10) & "            }"
        '
        'rtb5Items
        '
        Me.rtb5Items.Location = New System.Drawing.Point(872, 115)
        Me.rtb5Items.Name = "rtb5Items"
        Me.rtb5Items.Size = New System.Drawing.Size(49, 45)
        Me.rtb5Items.TabIndex = 76
        Me.rtb5Items.Text = "          ""functions"": [" & Global.Microsoft.VisualBasic.ChrW(10) & "            {" & Global.Microsoft.VisualBasic.ChrW(10) & "              ""function"": ""minecraft:set_c" &
    "ount""," & Global.Microsoft.VisualBasic.ChrW(10) & "              ""count"": 5" & Global.Microsoft.VisualBasic.ChrW(10) & "            }"
        '
        'rtb2Items
        '
        Me.rtb2Items.Location = New System.Drawing.Point(872, 63)
        Me.rtb2Items.Name = "rtb2Items"
        Me.rtb2Items.Size = New System.Drawing.Size(49, 45)
        Me.rtb2Items.TabIndex = 75
        Me.rtb2Items.Text = "          ""functions"": [" & Global.Microsoft.VisualBasic.ChrW(10) & "            {" & Global.Microsoft.VisualBasic.ChrW(10) & "              ""function"": ""minecraft:set_c" &
    "ount""," & Global.Microsoft.VisualBasic.ChrW(10) & "              ""count"": 2" & Global.Microsoft.VisualBasic.ChrW(10) & "            }"
        '
        'rtbLog
        '
        Me.rtbLog.Location = New System.Drawing.Point(102, 706)
        Me.rtbLog.Name = "rtbLog"
        Me.rtbLog.Size = New System.Drawing.Size(51, 54)
        Me.rtbLog.TabIndex = 83
        Me.rtbLog.Text = ""
        '
        'cbxVersion
        '
        Me.cbxVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxVersion.FormattingEnabled = True
        Me.cbxVersion.Items.AddRange(New Object() {"Version 1.16", "Version 1.17", "Version 1.18", "Version 1.19"})
        Me.cbxVersion.Location = New System.Drawing.Point(79, 94)
        Me.cbxVersion.Name = "cbxVersion"
        Me.cbxVersion.Size = New System.Drawing.Size(241, 24)
        Me.cbxVersion.TabIndex = 8
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(17, 97)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(56, 16)
        Me.lblVersion.TabIndex = 9
        Me.lblVersion.Text = "Version:"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(664, 545)
        Me.Controls.Add(Me.rtbLog)
        Me.Controls.Add(Me.Quotationmark)
        Me.Controls.Add(Me.rtbCodeEnd)
        Me.Controls.Add(Me.rtb64Items)
        Me.Controls.Add(Me.rtb32Items)
        Me.Controls.Add(Me.rtb10Items)
        Me.Controls.Add(Me.rtb3Items)
        Me.Controls.Add(Me.rtb5Items)
        Me.Controls.Add(Me.rtb2Items)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.gbItem)
        Me.Controls.Add(Me.gbDatapack)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.btnAddItem)
        Me.Controls.Add(Me.btnShowOutput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Random Item Giver Updater ALPHA 0.2.2"
        Me.gbDatapack.ResumeLayout(False)
        Me.gbDatapack.PerformLayout()
        Me.gbItem.ResumeLayout(False)
        Me.gbItem.PerformLayout()
        Me.gbItemID.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents gbDatapack As GroupBox
    Friend WithEvents gbItem As GroupBox
    Friend WithEvents cbNormalItem As CheckBox
    Friend WithEvents cbNBT As CheckBox
    Friend WithEvents tbNBT As TextBox
    Friend WithEvents tbSmallOutput As TextBox
    Friend WithEvents lblOutput As Label
    Friend WithEvents tbSamePrefix As TextBox
    Friend WithEvents btnShowOutput As Button
    Friend WithEvents cbSamePrefix As CheckBox
    Friend WithEvents rbtnCommandBlock As RadioButton
    Friend WithEvents rbtnOtherItem As RadioButton
    Friend WithEvents rbtnSpawnEgg As RadioButton
    Friend WithEvents cbSplashPotion As CheckBox
    Friend WithEvents cbLingeringPotion As CheckBox
    Friend WithEvents cbTippedArrow As CheckBox
    Friend WithEvents cbSuspiciousStew As CheckBox
    Friend WithEvents cbPotion As CheckBox
    Friend WithEvents cbEnchantedBook As CheckBox
    Friend WithEvents cbCreativeOnly As CheckBox
    Friend WithEvents lblID As Label
    Friend WithEvents lblAddNewItems As Label
    Friend WithEvents btnAddItem As Button
    Friend WithEvents btnBrowseDatapackPath As Button
    Friend WithEvents tbDatapackPath As TextBox
    Friend WithEvents lblSelectDatapack As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OpenDatapackFolderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SoftwareHelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ChangelogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents OutputToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents fbdMainFolderPath As FolderBrowserDialog
    Friend WithEvents Quotationmark As Label
    Friend WithEvents rtbCodeEnd As RichTextBox
    Friend WithEvents rtb64Items As RichTextBox
    Friend WithEvents rtb32Items As RichTextBox
    Friend WithEvents rtb10Items As RichTextBox
    Friend WithEvents rtb3Items As RichTextBox
    Friend WithEvents rtb5Items As RichTextBox
    Friend WithEvents rtb2Items As RichTextBox
    Friend WithEvents lblDatapackDetection As Label
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FindDuplicatesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportItemListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents rtbItem As RichTextBox
    Friend WithEvents gbItemID As GroupBox
    Friend WithEvents rtbLog As RichTextBox
    Friend WithEvents cbGoatHorn As CheckBox
    Friend WithEvents lblVersion As Label
    Friend WithEvents cbxVersion As ComboBox
End Class
