<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.gbDatapack = New System.Windows.Forms.GroupBox()
        Me.llblWhy116disabled = New System.Windows.Forms.LinkLabel()
        Me.rbtnRIG116 = New System.Windows.Forms.RadioButton()
        Me.rbtnRIG117 = New System.Windows.Forms.RadioButton()
        Me.rbtnRIG118 = New System.Windows.Forms.RadioButton()
        Me.btnBrowseDatapackPath = New System.Windows.Forms.Button()
        Me.tbDatapackPath = New System.Windows.Forms.TextBox()
        Me.lblSelectDatapack = New System.Windows.Forms.Label()
        Me.gbItem = New System.Windows.Forms.GroupBox()
        Me.cbNormalItem = New System.Windows.Forms.CheckBox()
        Me.cbNBT = New System.Windows.Forms.CheckBox()
        Me.tbNBT = New System.Windows.Forms.TextBox()
        Me.tbSmallOutput = New System.Windows.Forms.TextBox()
        Me.lblOutput = New System.Windows.Forms.Label()
        Me.tbCustomPrefix = New System.Windows.Forms.TextBox()
        Me.cbCustomPrefix = New System.Windows.Forms.CheckBox()
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
        Me.tbID = New System.Windows.Forms.TextBox()
        Me.lblAddNewItems = New System.Windows.Forms.Label()
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
        Me.gbDatapack.SuspendLayout()
        Me.gbItem.SuspendLayout()
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
        Me.gbDatapack.Controls.Add(Me.llblWhy116disabled)
        Me.gbDatapack.Controls.Add(Me.rbtnRIG116)
        Me.gbDatapack.Controls.Add(Me.rbtnRIG117)
        Me.gbDatapack.Controls.Add(Me.rbtnRIG118)
        Me.gbDatapack.Controls.Add(Me.btnBrowseDatapackPath)
        Me.gbDatapack.Controls.Add(Me.tbDatapackPath)
        Me.gbDatapack.Controls.Add(Me.lblSelectDatapack)
        Me.gbDatapack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatapack.Location = New System.Drawing.Point(16, 63)
        Me.gbDatapack.Name = "gbDatapack"
        Me.gbDatapack.Size = New System.Drawing.Size(638, 98)
        Me.gbDatapack.TabIndex = 57
        Me.gbDatapack.TabStop = False
        Me.gbDatapack.Text = "Select datapack"
        '
        'llblWhy116disabled
        '
        Me.llblWhy116disabled.AutoSize = True
        Me.llblWhy116disabled.Location = New System.Drawing.Point(529, 70)
        Me.llblWhy116disabled.Name = "llblWhy116disabled"
        Me.llblWhy116disabled.Size = New System.Drawing.Size(18, 20)
        Me.llblWhy116disabled.TabIndex = 6
        Me.llblWhy116disabled.TabStop = True
        Me.llblWhy116disabled.Text = "?"
        '
        'rbtnRIG116
        '
        Me.rbtnRIG116.AutoSize = True
        Me.rbtnRIG116.Enabled = False
        Me.rbtnRIG116.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnRIG116.Location = New System.Drawing.Point(361, 71)
        Me.rbtnRIG116.Name = "rbtnRIG116"
        Me.rbtnRIG116.Size = New System.Drawing.Size(167, 20)
        Me.rbtnRIG116.TabIndex = 5
        Me.rbtnRIG116.Text = "Random Item Giver 1.16"
        Me.rbtnRIG116.UseVisualStyleBackColor = True
        '
        'rbtnRIG117
        '
        Me.rbtnRIG117.AutoSize = True
        Me.rbtnRIG117.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnRIG117.Location = New System.Drawing.Point(188, 71)
        Me.rbtnRIG117.Name = "rbtnRIG117"
        Me.rbtnRIG117.Size = New System.Drawing.Size(167, 20)
        Me.rbtnRIG117.TabIndex = 4
        Me.rbtnRIG117.Text = "Random Item Giver 1.17"
        Me.rbtnRIG117.UseVisualStyleBackColor = True
        '
        'rbtnRIG118
        '
        Me.rbtnRIG118.AutoSize = True
        Me.rbtnRIG118.Checked = True
        Me.rbtnRIG118.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnRIG118.Location = New System.Drawing.Point(15, 71)
        Me.rbtnRIG118.Name = "rbtnRIG118"
        Me.rbtnRIG118.Size = New System.Drawing.Size(167, 20)
        Me.rbtnRIG118.TabIndex = 3
        Me.rbtnRIG118.TabStop = True
        Me.rbtnRIG118.Text = "Random Item Giver 1.18"
        Me.rbtnRIG118.UseVisualStyleBackColor = True
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
        Me.lblSelectDatapack.Size = New System.Drawing.Size(323, 16)
        Me.lblSelectDatapack.TabIndex = 0
        Me.lblSelectDatapack.Text = "Please chose the datapack and which version it is for."
        '
        'gbItem
        '
        Me.gbItem.Controls.Add(Me.cbNormalItem)
        Me.gbItem.Controls.Add(Me.cbNBT)
        Me.gbItem.Controls.Add(Me.tbNBT)
        Me.gbItem.Controls.Add(Me.tbSmallOutput)
        Me.gbItem.Controls.Add(Me.lblOutput)
        Me.gbItem.Controls.Add(Me.tbCustomPrefix)
        Me.gbItem.Controls.Add(Me.cbCustomPrefix)
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
        Me.gbItem.Controls.Add(Me.tbID)
        Me.gbItem.Controls.Add(Me.lblAddNewItems)
        Me.gbItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbItem.Location = New System.Drawing.Point(16, 167)
        Me.gbItem.Name = "gbItem"
        Me.gbItem.Size = New System.Drawing.Size(638, 254)
        Me.gbItem.TabIndex = 58
        Me.gbItem.TabStop = False
        Me.gbItem.Text = "Add item"
        '
        'cbNormalItem
        '
        Me.cbNormalItem.AutoSize = True
        Me.cbNormalItem.Checked = True
        Me.cbNormalItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNormalItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNormalItem.Location = New System.Drawing.Point(449, 53)
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
        Me.cbNBT.Location = New System.Drawing.Point(15, 150)
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
        Me.tbNBT.Location = New System.Drawing.Point(15, 176)
        Me.tbNBT.Name = "tbNBT"
        Me.tbNBT.Size = New System.Drawing.Size(197, 22)
        Me.tbNBT.TabIndex = 78
        '
        'tbSmallOutput
        '
        Me.tbSmallOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSmallOutput.Location = New System.Drawing.Point(66, 219)
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
        Me.lblOutput.Location = New System.Drawing.Point(12, 219)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(48, 16)
        Me.lblOutput.TabIndex = 76
        Me.lblOutput.Text = "Output:"
        '
        'tbCustomPrefix
        '
        Me.tbCustomPrefix.Enabled = False
        Me.tbCustomPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCustomPrefix.Location = New System.Drawing.Point(15, 122)
        Me.tbCustomPrefix.Name = "tbCustomPrefix"
        Me.tbCustomPrefix.Size = New System.Drawing.Size(197, 22)
        Me.tbCustomPrefix.TabIndex = 75
        '
        'cbCustomPrefix
        '
        Me.cbCustomPrefix.AutoSize = True
        Me.cbCustomPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustomPrefix.Location = New System.Drawing.Point(15, 99)
        Me.cbCustomPrefix.Name = "cbCustomPrefix"
        Me.cbCustomPrefix.Size = New System.Drawing.Size(181, 20)
        Me.cbCustomPrefix.TabIndex = 73
        Me.cbCustomPrefix.Text = "Custom Prefix (Mod-Items)"
        Me.cbCustomPrefix.UseVisualStyleBackColor = True
        '
        'rbtnCommandBlock
        '
        Me.rbtnCommandBlock.AutoSize = True
        Me.rbtnCommandBlock.Enabled = False
        Me.rbtnCommandBlock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnCommandBlock.Location = New System.Drawing.Point(463, 124)
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
        Me.rbtnOtherItem.Location = New System.Drawing.Point(463, 148)
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
        Me.rbtnSpawnEgg.Location = New System.Drawing.Point(463, 101)
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
        Me.cbSplashPotion.Location = New System.Drawing.Point(294, 124)
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
        Me.cbLingeringPotion.Location = New System.Drawing.Point(294, 148)
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
        Me.cbTippedArrow.Location = New System.Drawing.Point(294, 174)
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
        Me.cbSuspiciousStew.Location = New System.Drawing.Point(294, 53)
        Me.cbSuspiciousStew.Name = "cbSuspiciousStew"
        Me.cbSuspiciousStew.Size = New System.Drawing.Size(117, 20)
        Me.cbSuspiciousStew.TabIndex = 66
        Me.cbSuspiciousStew.Text = "Supicious Stew"
        Me.cbSuspiciousStew.UseVisualStyleBackColor = True
        '
        'cbPotion
        '
        Me.cbPotion.AutoSize = True
        Me.cbPotion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPotion.Location = New System.Drawing.Point(294, 100)
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
        Me.cbEnchantedBook.Location = New System.Drawing.Point(294, 76)
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
        Me.cbCreativeOnly.Location = New System.Drawing.Point(449, 79)
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
        Me.lblID.Location = New System.Drawing.Point(12, 53)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(51, 16)
        Me.lblID.TabIndex = 60
        Me.lblID.Text = "Item ID:"
        '
        'tbID
        '
        Me.tbID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbID.Location = New System.Drawing.Point(15, 71)
        Me.tbID.Name = "tbID"
        Me.tbID.Size = New System.Drawing.Size(197, 22)
        Me.tbID.TabIndex = 57
        '
        'lblAddNewItems
        '
        Me.lblAddNewItems.AutoSize = True
        Me.lblAddNewItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddNewItems.Location = New System.Drawing.Point(12, 22)
        Me.lblAddNewItems.Name = "lblAddNewItems"
        Me.lblAddNewItems.Size = New System.Drawing.Size(261, 16)
        Me.lblAddNewItems.TabIndex = 56
        Me.lblAddNewItems.Text = "Add new items and blocks to the datapack."
        '
        'btnShowOutput
        '
        Me.btnShowOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowOutput.Location = New System.Drawing.Point(465, 429)
        Me.btnShowOutput.Name = "btnShowOutput"
        Me.btnShowOutput.Size = New System.Drawing.Size(189, 34)
        Me.btnShowOutput.TabIndex = 74
        Me.btnShowOutput.Text = "Show output"
        Me.btnShowOutput.UseVisualStyleBackColor = True
        '
        'btnAddItem
        '
        Me.btnAddItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddItem.Location = New System.Drawing.Point(16, 429)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(443, 34)
        Me.btnAddItem.TabIndex = 63
        Me.btnAddItem.Text = "Add item to datapack"
        Me.btnAddItem.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
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
        Me.SoftwareHelpToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.SoftwareHelpToolStripMenuItem.Text = "Software help"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(177, 6)
        '
        'ChangelogToolStripMenuItem
        '
        Me.ChangelogToolStripMenuItem.Name = "ChangelogToolStripMenuItem"
        Me.ChangelogToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.ChangelogToolStripMenuItem.Text = "Changelog"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
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
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(664, 476)
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
        Me.Text = "Random Item Giver Updater ALPHA 0.1.0"
        Me.gbDatapack.ResumeLayout(False)
        Me.gbDatapack.PerformLayout()
        Me.gbItem.ResumeLayout(False)
        Me.gbItem.PerformLayout()
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
    Friend WithEvents tbCustomPrefix As TextBox
    Friend WithEvents btnShowOutput As Button
    Friend WithEvents cbCustomPrefix As CheckBox
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
    Friend WithEvents tbID As TextBox
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
    Friend WithEvents rbtnRIG116 As RadioButton
    Friend WithEvents rbtnRIG117 As RadioButton
    Friend WithEvents rbtnRIG118 As RadioButton
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
    Friend WithEvents llblWhy116disabled As LinkLabel
End Class
