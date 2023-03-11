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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.cbxVersion = New System.Windows.Forms.ComboBox()
        Me.lblDatapackDetection = New System.Windows.Forms.Label()
        Me.tbDatapackPath = New System.Windows.Forms.TextBox()
        Me.lblSelectDatapack = New System.Windows.Forms.Label()
        Me.cbEnableAdvancedView = New System.Windows.Forms.CheckBox()
        Me.cbxScheme = New System.Windows.Forms.ComboBox()
        Me.lblScheme = New System.Windows.Forms.Label()
        Me.cbAddItemsFast = New System.Windows.Forms.CheckBox()
        Me.cbGoatHorn = New System.Windows.Forms.CheckBox()
        Me.cbNormalItem = New System.Windows.Forms.CheckBox()
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
        Me.lblAddNewItems = New System.Windows.Forms.Label()
        Me.gbItemID = New System.Windows.Forms.GroupBox()
        Me.rtbItem = New System.Windows.Forms.RichTextBox()
        Me.cbCustomNBT = New System.Windows.Forms.CheckBox()
        Me.tbCustomNBT = New System.Windows.Forms.TextBox()
        Me.fbdMainFolderPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.Quotationmark = New System.Windows.Forms.Label()
        Me.rtbCodeEnd = New System.Windows.Forms.RichTextBox()
        Me.rtbItems64 = New System.Windows.Forms.RichTextBox()
        Me.rtbItems32 = New System.Windows.Forms.RichTextBox()
        Me.rtbItems10 = New System.Windows.Forms.RichTextBox()
        Me.rtbItems3 = New System.Windows.Forms.RichTextBox()
        Me.rtbItems5 = New System.Windows.Forms.RichTextBox()
        Me.rtbItems2 = New System.Windows.Forms.RichTextBox()
        Me.rtbLog = New System.Windows.Forms.RichTextBox()
        Me.pbAddingItemsProgress = New System.Windows.Forms.ProgressBar()
        Me.bgwAddItems = New System.ComponentModel.BackgroundWorker()
        Me.lblItemsTotal = New System.Windows.Forms.Label()
        Me.cbxDefaultProfile = New System.Windows.Forms.ComboBox()
        Me.rtbItemsRandomSame119 = New System.Windows.Forms.RichTextBox()
        Me.rtbItemsRandomSame116 = New System.Windows.Forms.RichTextBox()
        Me.lblBoxSelectDatapackHeader = New System.Windows.Forms.Label()
        Me.lblBoxAddItemHeader = New System.Windows.Forms.Label()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DuplicateFinderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemListImporterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsHamburgerButton = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EinstellungenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OutputToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DocumentaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangelogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnAddItem = New System.Windows.Forms.Button()
        Me.pbLine = New System.Windows.Forms.PictureBox()
        Me.pbHeader = New System.Windows.Forms.PictureBox()
        Me.btnHamburger = New System.Windows.Forms.Button()
        Me.btnDeleteSelectedScheme = New System.Windows.Forms.Button()
        Me.btnLoadProfile = New System.Windows.Forms.Button()
        Me.btnOverwriteSelectedScheme = New System.Windows.Forms.Button()
        Me.btnSaveProfile = New System.Windows.Forms.Button()
        Me.btnSaveAsNewScheme = New System.Windows.Forms.Button()
        Me.btnBrowseDatapackPath = New System.Windows.Forms.Button()
        Me.pbSelectDatapack = New System.Windows.Forms.PictureBox()
        Me.pbAddItem = New System.Windows.Forms.PictureBox()
        Me.DToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbPainting = New System.Windows.Forms.CheckBox()
        Me.gbItemID.SuspendLayout()
        Me.cmsHamburgerButton.SuspendLayout()
        CType(Me.pbLine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbSelectDatapack, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbAddItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(85, 25)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(428, 29)
        Me.lblHeader.TabIndex = 56
        Me.lblHeader.Text = "Random Item Giver Updater (BETA)"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ForeColor = System.Drawing.Color.White
        Me.lblVersion.Location = New System.Drawing.Point(34, 229)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(64, 16)
        Me.lblVersion.TabIndex = 9
        Me.lblVersion.Text = "Version:"
        '
        'cbxVersion
        '
        Me.cbxVersion.BackColor = System.Drawing.Color.DimGray
        Me.cbxVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxVersion.ForeColor = System.Drawing.Color.White
        Me.cbxVersion.FormattingEnabled = True
        Me.cbxVersion.Items.AddRange(New Object() {"Version 1.16.2 - 1.16.5", "Version 1.17 - 1.17.1", "Version 1.18 - 1.18.2", "Version 1.19 - 1.19.3", "Version 1.19.4"})
        Me.cbxVersion.Location = New System.Drawing.Point(101, 226)
        Me.cbxVersion.Name = "cbxVersion"
        Me.cbxVersion.Size = New System.Drawing.Size(241, 24)
        Me.cbxVersion.TabIndex = 8
        '
        'lblDatapackDetection
        '
        Me.lblDatapackDetection.AutoSize = True
        Me.lblDatapackDetection.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblDatapackDetection.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatapackDetection.ForeColor = System.Drawing.Color.White
        Me.lblDatapackDetection.Location = New System.Drawing.Point(36, 195)
        Me.lblDatapackDetection.Name = "lblDatapackDetection"
        Me.lblDatapackDetection.Size = New System.Drawing.Size(156, 18)
        Me.lblDatapackDetection.TabIndex = 7
        Me.lblDatapackDetection.Text = "No datapack detected."
        '
        'tbDatapackPath
        '
        Me.tbDatapackPath.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.tbDatapackPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbDatapackPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDatapackPath.ForeColor = System.Drawing.Color.White
        Me.tbDatapackPath.Location = New System.Drawing.Point(37, 163)
        Me.tbDatapackPath.Name = "tbDatapackPath"
        Me.tbDatapackPath.Size = New System.Drawing.Size(478, 22)
        Me.tbDatapackPath.TabIndex = 1
        '
        'lblSelectDatapack
        '
        Me.lblSelectDatapack.AutoSize = True
        Me.lblSelectDatapack.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblSelectDatapack.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectDatapack.ForeColor = System.Drawing.Color.White
        Me.lblSelectDatapack.Location = New System.Drawing.Point(36, 141)
        Me.lblSelectDatapack.Name = "lblSelectDatapack"
        Me.lblSelectDatapack.Size = New System.Drawing.Size(274, 16)
        Me.lblSelectDatapack.TabIndex = 0
        Me.lblSelectDatapack.Text = "Choose the datapack that you want to modify."
        '
        'cbEnableAdvancedView
        '
        Me.cbEnableAdvancedView.AutoSize = True
        Me.cbEnableAdvancedView.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbEnableAdvancedView.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEnableAdvancedView.ForeColor = System.Drawing.Color.White
        Me.cbEnableAdvancedView.Location = New System.Drawing.Point(42, 677)
        Me.cbEnableAdvancedView.Name = "cbEnableAdvancedView"
        Me.cbEnableAdvancedView.Size = New System.Drawing.Size(166, 20)
        Me.cbEnableAdvancedView.TabIndex = 89
        Me.cbEnableAdvancedView.Text = "Enable Advanced View"
        Me.cbEnableAdvancedView.UseVisualStyleBackColor = False
        '
        'cbxScheme
        '
        Me.cbxScheme.BackColor = System.Drawing.Color.DimGray
        Me.cbxScheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxScheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxScheme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxScheme.ForeColor = System.Drawing.Color.White
        Me.cbxScheme.FormattingEnabled = True
        Me.cbxScheme.Location = New System.Drawing.Point(490, 342)
        Me.cbxScheme.Name = "cbxScheme"
        Me.cbxScheme.Size = New System.Drawing.Size(179, 24)
        Me.cbxScheme.TabIndex = 88
        '
        'lblScheme
        '
        Me.lblScheme.AutoSize = True
        Me.lblScheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblScheme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScheme.ForeColor = System.Drawing.Color.White
        Me.lblScheme.Location = New System.Drawing.Point(417, 345)
        Me.lblScheme.Name = "lblScheme"
        Me.lblScheme.Size = New System.Drawing.Size(67, 16)
        Me.lblScheme.TabIndex = 87
        Me.lblScheme.Text = "Scheme:"
        '
        'cbAddItemsFast
        '
        Me.cbAddItemsFast.AutoSize = True
        Me.cbAddItemsFast.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbAddItemsFast.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAddItemsFast.ForeColor = System.Drawing.Color.White
        Me.cbAddItemsFast.Location = New System.Drawing.Point(42, 651)
        Me.cbAddItemsFast.Name = "cbAddItemsFast"
        Me.cbAddItemsFast.Size = New System.Drawing.Size(295, 20)
        Me.cbAddItemsFast.TabIndex = 84
        Me.cbAddItemsFast.Text = "Enable Fast Item Adding (Not recommended)"
        Me.cbAddItemsFast.UseVisualStyleBackColor = False
        '
        'cbGoatHorn
        '
        Me.cbGoatHorn.AutoSize = True
        Me.cbGoatHorn.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbGoatHorn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbGoatHorn.ForeColor = System.Drawing.Color.White
        Me.cbGoatHorn.Location = New System.Drawing.Point(326, 567)
        Me.cbGoatHorn.Name = "cbGoatHorn"
        Me.cbGoatHorn.Size = New System.Drawing.Size(87, 20)
        Me.cbGoatHorn.TabIndex = 83
        Me.cbGoatHorn.Text = "Goat Horn"
        Me.cbGoatHorn.UseVisualStyleBackColor = False
        '
        'cbNormalItem
        '
        Me.cbNormalItem.AutoSize = True
        Me.cbNormalItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbNormalItem.Checked = True
        Me.cbNormalItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNormalItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNormalItem.ForeColor = System.Drawing.Color.White
        Me.cbNormalItem.Location = New System.Drawing.Point(326, 385)
        Me.cbNormalItem.Name = "cbNormalItem"
        Me.cbNormalItem.Size = New System.Drawing.Size(98, 20)
        Me.cbNormalItem.TabIndex = 80
        Me.cbNormalItem.Text = "Normal Item"
        Me.cbNormalItem.UseVisualStyleBackColor = False
        '
        'tbSmallOutput
        '
        Me.tbSmallOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.tbSmallOutput.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.tbSmallOutput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbSmallOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSmallOutput.ForeColor = System.Drawing.Color.White
        Me.tbSmallOutput.Location = New System.Drawing.Point(101, 711)
        Me.tbSmallOutput.Multiline = True
        Me.tbSmallOutput.Name = "tbSmallOutput"
        Me.tbSmallOutput.ReadOnly = True
        Me.tbSmallOutput.Size = New System.Drawing.Size(568, 20)
        Me.tbSmallOutput.TabIndex = 77
        '
        'lblOutput
        '
        Me.lblOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOutput.AutoSize = True
        Me.lblOutput.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOutput.ForeColor = System.Drawing.Color.White
        Me.lblOutput.Location = New System.Drawing.Point(40, 712)
        Me.lblOutput.Name = "lblOutput"
        Me.lblOutput.Size = New System.Drawing.Size(55, 16)
        Me.lblOutput.TabIndex = 76
        Me.lblOutput.Text = "Output:"
        '
        'tbSamePrefix
        '
        Me.tbSamePrefix.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.tbSamePrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbSamePrefix.Enabled = False
        Me.tbSamePrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSamePrefix.ForeColor = System.Drawing.Color.White
        Me.tbSamePrefix.Location = New System.Drawing.Point(42, 612)
        Me.tbSamePrefix.Name = "tbSamePrefix"
        Me.tbSamePrefix.Size = New System.Drawing.Size(258, 22)
        Me.tbSamePrefix.TabIndex = 75
        Me.tbSamePrefix.Text = "minecraft"
        '
        'cbSamePrefix
        '
        Me.cbSamePrefix.AutoSize = True
        Me.cbSamePrefix.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbSamePrefix.Checked = True
        Me.cbSamePrefix.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSamePrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSamePrefix.ForeColor = System.Drawing.Color.White
        Me.cbSamePrefix.Location = New System.Drawing.Point(42, 586)
        Me.cbSamePrefix.Name = "cbSamePrefix"
        Me.cbSamePrefix.Size = New System.Drawing.Size(214, 20)
        Me.cbSamePrefix.TabIndex = 73
        Me.cbSamePrefix.Text = "Use the same prefix for all items"
        Me.cbSamePrefix.UseVisualStyleBackColor = False
        '
        'rbtnCommandBlock
        '
        Me.rbtnCommandBlock.AutoSize = True
        Me.rbtnCommandBlock.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.rbtnCommandBlock.Enabled = False
        Me.rbtnCommandBlock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnCommandBlock.ForeColor = System.Drawing.Color.White
        Me.rbtnCommandBlock.Location = New System.Drawing.Point(503, 432)
        Me.rbtnCommandBlock.Name = "rbtnCommandBlock"
        Me.rbtnCommandBlock.Size = New System.Drawing.Size(124, 20)
        Me.rbtnCommandBlock.TabIndex = 72
        Me.rbtnCommandBlock.TabStop = True
        Me.rbtnCommandBlock.Text = "Command Block"
        Me.rbtnCommandBlock.UseVisualStyleBackColor = False
        '
        'rbtnOtherItem
        '
        Me.rbtnOtherItem.AutoSize = True
        Me.rbtnOtherItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.rbtnOtherItem.Enabled = False
        Me.rbtnOtherItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnOtherItem.ForeColor = System.Drawing.Color.White
        Me.rbtnOtherItem.Location = New System.Drawing.Point(503, 453)
        Me.rbtnOtherItem.Name = "rbtnOtherItem"
        Me.rbtnOtherItem.Size = New System.Drawing.Size(169, 20)
        Me.rbtnOtherItem.TabIndex = 71
        Me.rbtnOtherItem.TabStop = True
        Me.rbtnOtherItem.Text = "Other Creative-Only item"
        Me.rbtnOtherItem.UseVisualStyleBackColor = False
        '
        'rbtnSpawnEgg
        '
        Me.rbtnSpawnEgg.AutoSize = True
        Me.rbtnSpawnEgg.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.rbtnSpawnEgg.Enabled = False
        Me.rbtnSpawnEgg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSpawnEgg.ForeColor = System.Drawing.Color.White
        Me.rbtnSpawnEgg.Location = New System.Drawing.Point(503, 411)
        Me.rbtnSpawnEgg.Name = "rbtnSpawnEgg"
        Me.rbtnSpawnEgg.Size = New System.Drawing.Size(94, 20)
        Me.rbtnSpawnEgg.TabIndex = 70
        Me.rbtnSpawnEgg.TabStop = True
        Me.rbtnSpawnEgg.Text = "Spawn Egg"
        Me.rbtnSpawnEgg.UseVisualStyleBackColor = False
        '
        'cbSplashPotion
        '
        Me.cbSplashPotion.AutoSize = True
        Me.cbSplashPotion.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbSplashPotion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSplashPotion.ForeColor = System.Drawing.Color.White
        Me.cbSplashPotion.Location = New System.Drawing.Point(326, 489)
        Me.cbSplashPotion.Name = "cbSplashPotion"
        Me.cbSplashPotion.Size = New System.Drawing.Size(109, 20)
        Me.cbSplashPotion.TabIndex = 69
        Me.cbSplashPotion.Text = "Splash Potion"
        Me.cbSplashPotion.UseVisualStyleBackColor = False
        '
        'cbLingeringPotion
        '
        Me.cbLingeringPotion.AutoSize = True
        Me.cbLingeringPotion.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbLingeringPotion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbLingeringPotion.ForeColor = System.Drawing.Color.White
        Me.cbLingeringPotion.Location = New System.Drawing.Point(326, 463)
        Me.cbLingeringPotion.Name = "cbLingeringPotion"
        Me.cbLingeringPotion.Size = New System.Drawing.Size(122, 20)
        Me.cbLingeringPotion.TabIndex = 68
        Me.cbLingeringPotion.Text = "Lingering Potion"
        Me.cbLingeringPotion.UseVisualStyleBackColor = False
        '
        'cbTippedArrow
        '
        Me.cbTippedArrow.AutoSize = True
        Me.cbTippedArrow.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbTippedArrow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbTippedArrow.ForeColor = System.Drawing.Color.White
        Me.cbTippedArrow.Location = New System.Drawing.Point(326, 515)
        Me.cbTippedArrow.Name = "cbTippedArrow"
        Me.cbTippedArrow.Size = New System.Drawing.Size(107, 20)
        Me.cbTippedArrow.TabIndex = 67
        Me.cbTippedArrow.Text = "Tipped Arrow"
        Me.cbTippedArrow.UseVisualStyleBackColor = False
        '
        'cbSuspiciousStew
        '
        Me.cbSuspiciousStew.AutoSize = True
        Me.cbSuspiciousStew.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbSuspiciousStew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSuspiciousStew.ForeColor = System.Drawing.Color.White
        Me.cbSuspiciousStew.Location = New System.Drawing.Point(326, 541)
        Me.cbSuspiciousStew.Name = "cbSuspiciousStew"
        Me.cbSuspiciousStew.Size = New System.Drawing.Size(124, 20)
        Me.cbSuspiciousStew.TabIndex = 66
        Me.cbSuspiciousStew.Text = "Suspicious Stew"
        Me.cbSuspiciousStew.UseVisualStyleBackColor = False
        '
        'cbPotion
        '
        Me.cbPotion.AutoSize = True
        Me.cbPotion.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbPotion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPotion.ForeColor = System.Drawing.Color.White
        Me.cbPotion.Location = New System.Drawing.Point(326, 437)
        Me.cbPotion.Name = "cbPotion"
        Me.cbPotion.Size = New System.Drawing.Size(64, 20)
        Me.cbPotion.TabIndex = 65
        Me.cbPotion.Text = "Potion"
        Me.cbPotion.UseVisualStyleBackColor = False
        '
        'cbEnchantedBook
        '
        Me.cbEnchantedBook.AutoSize = True
        Me.cbEnchantedBook.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbEnchantedBook.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbEnchantedBook.ForeColor = System.Drawing.Color.White
        Me.cbEnchantedBook.Location = New System.Drawing.Point(326, 411)
        Me.cbEnchantedBook.Name = "cbEnchantedBook"
        Me.cbEnchantedBook.Size = New System.Drawing.Size(125, 20)
        Me.cbEnchantedBook.TabIndex = 64
        Me.cbEnchantedBook.Text = "Enchanted Book"
        Me.cbEnchantedBook.UseVisualStyleBackColor = False
        '
        'cbCreativeOnly
        '
        Me.cbCreativeOnly.AutoSize = True
        Me.cbCreativeOnly.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbCreativeOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCreativeOnly.ForeColor = System.Drawing.Color.White
        Me.cbCreativeOnly.Location = New System.Drawing.Point(490, 385)
        Me.cbCreativeOnly.Name = "cbCreativeOnly"
        Me.cbCreativeOnly.Size = New System.Drawing.Size(107, 20)
        Me.cbCreativeOnly.TabIndex = 61
        Me.cbCreativeOnly.Text = "Creative-Only"
        Me.cbCreativeOnly.UseVisualStyleBackColor = False
        '
        'lblAddNewItems
        '
        Me.lblAddNewItems.AutoSize = True
        Me.lblAddNewItems.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblAddNewItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddNewItems.ForeColor = System.Drawing.Color.White
        Me.lblAddNewItems.Location = New System.Drawing.Point(39, 345)
        Me.lblAddNewItems.Name = "lblAddNewItems"
        Me.lblAddNewItems.Size = New System.Drawing.Size(261, 16)
        Me.lblAddNewItems.TabIndex = 56
        Me.lblAddNewItems.Text = "Add new items and blocks to the datapack."
        '
        'gbItemID
        '
        Me.gbItemID.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.gbItemID.Controls.Add(Me.rtbItem)
        Me.gbItemID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbItemID.ForeColor = System.Drawing.Color.White
        Me.gbItemID.Location = New System.Drawing.Point(41, 373)
        Me.gbItemID.Name = "gbItemID"
        Me.gbItemID.Size = New System.Drawing.Size(259, 140)
        Me.gbItemID.TabIndex = 82
        Me.gbItemID.TabStop = False
        Me.gbItemID.Text = "Items (ID)"
        '
        'rtbItem
        '
        Me.rtbItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbItem.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.rtbItem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbItem.ForeColor = System.Drawing.Color.White
        Me.rtbItem.Location = New System.Drawing.Point(6, 18)
        Me.rtbItem.Name = "rtbItem"
        Me.rtbItem.Size = New System.Drawing.Size(247, 116)
        Me.rtbItem.TabIndex = 81
        Me.rtbItem.Text = ""
        '
        'cbCustomNBT
        '
        Me.cbCustomNBT.AutoSize = True
        Me.cbCustomNBT.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbCustomNBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbCustomNBT.ForeColor = System.Drawing.Color.White
        Me.cbCustomNBT.Location = New System.Drawing.Point(42, 532)
        Me.cbCustomNBT.Name = "cbCustomNBT"
        Me.cbCustomNBT.Size = New System.Drawing.Size(82, 20)
        Me.cbCustomNBT.TabIndex = 79
        Me.cbCustomNBT.Text = "NBT Tag"
        Me.cbCustomNBT.UseVisualStyleBackColor = False
        '
        'tbCustomNBT
        '
        Me.tbCustomNBT.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.tbCustomNBT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbCustomNBT.Enabled = False
        Me.tbCustomNBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCustomNBT.ForeColor = System.Drawing.Color.White
        Me.tbCustomNBT.Location = New System.Drawing.Point(42, 558)
        Me.tbCustomNBT.Name = "tbCustomNBT"
        Me.tbCustomNBT.Size = New System.Drawing.Size(258, 22)
        Me.tbCustomNBT.TabIndex = 78
        '
        'fbdMainFolderPath
        '
        Me.fbdMainFolderPath.Description = "Select the datapack which you want to edit."
        Me.fbdMainFolderPath.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'Quotationmark
        '
        Me.Quotationmark.AutoSize = True
        Me.Quotationmark.Location = New System.Drawing.Point(1120, 432)
        Me.Quotationmark.Name = "Quotationmark"
        Me.Quotationmark.Size = New System.Drawing.Size(12, 13)
        Me.Quotationmark.TabIndex = 82
        Me.Quotationmark.Text = """"
        '
        'rtbCodeEnd
        '
        Me.rtbCodeEnd.Location = New System.Drawing.Point(1101, 378)
        Me.rtbCodeEnd.Name = "rtbCodeEnd"
        Me.rtbCodeEnd.Size = New System.Drawing.Size(49, 45)
        Me.rtbCodeEnd.TabIndex = 81
        Me.rtbCodeEnd.Text = "        }" & Global.Microsoft.VisualBasic.ChrW(10) & "      ]" & Global.Microsoft.VisualBasic.ChrW(10) & "    }" & Global.Microsoft.VisualBasic.ChrW(10) & "  ]" & Global.Microsoft.VisualBasic.ChrW(10) & "}"
        '
        'rtbItems64
        '
        Me.rtbItems64.Location = New System.Drawing.Point(1156, 327)
        Me.rtbItems64.Name = "rtbItems64"
        Me.rtbItems64.Size = New System.Drawing.Size(49, 45)
        Me.rtbItems64.TabIndex = 80
        Me.rtbItems64.Text = "          ""functions"": [" & Global.Microsoft.VisualBasic.ChrW(10) & "            {" & Global.Microsoft.VisualBasic.ChrW(10) & "              ""function"": ""minecraft:set_c" &
    "ount""," & Global.Microsoft.VisualBasic.ChrW(10) & "              ""count"": 64" & Global.Microsoft.VisualBasic.ChrW(10) & "            }"
        '
        'rtbItems32
        '
        Me.rtbItems32.Location = New System.Drawing.Point(1101, 327)
        Me.rtbItems32.Name = "rtbItems32"
        Me.rtbItems32.Size = New System.Drawing.Size(49, 45)
        Me.rtbItems32.TabIndex = 79
        Me.rtbItems32.Text = "          ""functions"": [" & Global.Microsoft.VisualBasic.ChrW(10) & "            {" & Global.Microsoft.VisualBasic.ChrW(10) & "              ""function"": ""minecraft:set_c" &
    "ount""," & Global.Microsoft.VisualBasic.ChrW(10) & "              ""count"": 32" & Global.Microsoft.VisualBasic.ChrW(10) & "            }"
        '
        'rtbItems10
        '
        Me.rtbItems10.Location = New System.Drawing.Point(1156, 276)
        Me.rtbItems10.Name = "rtbItems10"
        Me.rtbItems10.Size = New System.Drawing.Size(49, 45)
        Me.rtbItems10.TabIndex = 78
        Me.rtbItems10.Text = "          ""functions"": [" & Global.Microsoft.VisualBasic.ChrW(10) & "            {" & Global.Microsoft.VisualBasic.ChrW(10) & "              ""function"": ""minecraft:set_c" &
    "ount""," & Global.Microsoft.VisualBasic.ChrW(10) & "              ""count"": 10" & Global.Microsoft.VisualBasic.ChrW(10) & "            }"
        '
        'rtbItems3
        '
        Me.rtbItems3.Location = New System.Drawing.Point(1156, 224)
        Me.rtbItems3.Name = "rtbItems3"
        Me.rtbItems3.Size = New System.Drawing.Size(49, 45)
        Me.rtbItems3.TabIndex = 77
        Me.rtbItems3.Text = "          ""functions"": [" & Global.Microsoft.VisualBasic.ChrW(10) & "            {" & Global.Microsoft.VisualBasic.ChrW(10) & "              ""function"": ""minecraft:set_c" &
    "ount""," & Global.Microsoft.VisualBasic.ChrW(10) & "              ""count"": 3" & Global.Microsoft.VisualBasic.ChrW(10) & "            }"
        '
        'rtbItems5
        '
        Me.rtbItems5.Location = New System.Drawing.Point(1101, 276)
        Me.rtbItems5.Name = "rtbItems5"
        Me.rtbItems5.Size = New System.Drawing.Size(49, 45)
        Me.rtbItems5.TabIndex = 76
        Me.rtbItems5.Text = "          ""functions"": [" & Global.Microsoft.VisualBasic.ChrW(10) & "            {" & Global.Microsoft.VisualBasic.ChrW(10) & "              ""function"": ""minecraft:set_c" &
    "ount""," & Global.Microsoft.VisualBasic.ChrW(10) & "              ""count"": 5" & Global.Microsoft.VisualBasic.ChrW(10) & "            }"
        '
        'rtbItems2
        '
        Me.rtbItems2.Location = New System.Drawing.Point(1101, 224)
        Me.rtbItems2.Name = "rtbItems2"
        Me.rtbItems2.Size = New System.Drawing.Size(49, 45)
        Me.rtbItems2.TabIndex = 75
        Me.rtbItems2.Text = "          ""functions"": [" & Global.Microsoft.VisualBasic.ChrW(10) & "            {" & Global.Microsoft.VisualBasic.ChrW(10) & "              ""function"": ""minecraft:set_c" &
    "ount""," & Global.Microsoft.VisualBasic.ChrW(10) & "              ""count"": 2" & Global.Microsoft.VisualBasic.ChrW(10) & "            }"
        '
        'rtbLog
        '
        Me.rtbLog.Location = New System.Drawing.Point(1221, 224)
        Me.rtbLog.Name = "rtbLog"
        Me.rtbLog.Size = New System.Drawing.Size(51, 54)
        Me.rtbLog.TabIndex = 83
        Me.rtbLog.Text = ""
        '
        'pbAddingItemsProgress
        '
        Me.pbAddingItemsProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbAddingItemsProgress.Location = New System.Drawing.Point(365, 768)
        Me.pbAddingItemsProgress.Name = "pbAddingItemsProgress"
        Me.pbAddingItemsProgress.Size = New System.Drawing.Size(307, 23)
        Me.pbAddingItemsProgress.TabIndex = 84
        '
        'bgwAddItems
        '
        Me.bgwAddItems.WorkerReportsProgress = True
        Me.bgwAddItems.WorkerSupportsCancellation = True
        '
        'lblItemsTotal
        '
        Me.lblItemsTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblItemsTotal.AutoSize = True
        Me.lblItemsTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblItemsTotal.Location = New System.Drawing.Point(23, 766)
        Me.lblItemsTotal.Name = "lblItemsTotal"
        Me.lblItemsTotal.Size = New System.Drawing.Size(208, 24)
        Me.lblItemsTotal.TabIndex = 86
        Me.lblItemsTotal.Text = "Total amount of items: 0"
        '
        'cbxDefaultProfile
        '
        Me.cbxDefaultProfile.FormattingEnabled = True
        Me.cbxDefaultProfile.Location = New System.Drawing.Point(1278, 224)
        Me.cbxDefaultProfile.Name = "cbxDefaultProfile"
        Me.cbxDefaultProfile.Size = New System.Drawing.Size(121, 21)
        Me.cbxDefaultProfile.TabIndex = 87
        '
        'rtbItemsRandomSame119
        '
        Me.rtbItemsRandomSame119.Location = New System.Drawing.Point(1156, 378)
        Me.rtbItemsRandomSame119.Name = "rtbItemsRandomSame119"
        Me.rtbItemsRandomSame119.Size = New System.Drawing.Size(49, 45)
        Me.rtbItemsRandomSame119.TabIndex = 89
        Me.rtbItemsRandomSame119.Text = resources.GetString("rtbItemsRandomSame119.Text")
        '
        'rtbItemsRandomSame116
        '
        Me.rtbItemsRandomSame116.Location = New System.Drawing.Point(1156, 429)
        Me.rtbItemsRandomSame116.Name = "rtbItemsRandomSame116"
        Me.rtbItemsRandomSame116.Size = New System.Drawing.Size(49, 45)
        Me.rtbItemsRandomSame116.TabIndex = 90
        Me.rtbItemsRandomSame116.Text = resources.GetString("rtbItemsRandomSame116.Text")
        '
        'lblBoxSelectDatapackHeader
        '
        Me.lblBoxSelectDatapackHeader.AutoSize = True
        Me.lblBoxSelectDatapackHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.lblBoxSelectDatapackHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxSelectDatapackHeader.ForeColor = System.Drawing.Color.Black
        Me.lblBoxSelectDatapackHeader.Location = New System.Drawing.Point(64, 105)
        Me.lblBoxSelectDatapackHeader.Name = "lblBoxSelectDatapackHeader"
        Me.lblBoxSelectDatapackHeader.Size = New System.Drawing.Size(127, 20)
        Me.lblBoxSelectDatapackHeader.TabIndex = 92
        Me.lblBoxSelectDatapackHeader.Text = "Select Datapack"
        '
        'lblBoxAddItemHeader
        '
        Me.lblBoxAddItemHeader.AutoSize = True
        Me.lblBoxAddItemHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(195, Byte), Integer), CType(CType(195, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.lblBoxAddItemHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBoxAddItemHeader.ForeColor = System.Drawing.Color.Black
        Me.lblBoxAddItemHeader.Location = New System.Drawing.Point(64, 304)
        Me.lblBoxAddItemHeader.Name = "lblBoxAddItemHeader"
        Me.lblBoxAddItemHeader.Size = New System.Drawing.Size(74, 20)
        Me.lblBoxAddItemHeader.TabIndex = 94
        Me.lblBoxAddItemHeader.Text = "Add Item"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DuplicateFinderToolStripMenuItem, Me.ItemListImporterToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(133, 26)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'DuplicateFinderToolStripMenuItem
        '
        Me.DuplicateFinderToolStripMenuItem.BackColor = System.Drawing.Color.White
        Me.DuplicateFinderToolStripMenuItem.Image = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgDuplicateFinder
        Me.DuplicateFinderToolStripMenuItem.Name = "DuplicateFinderToolStripMenuItem"
        Me.DuplicateFinderToolStripMenuItem.Size = New System.Drawing.Size(204, 26)
        Me.DuplicateFinderToolStripMenuItem.Text = "Duplicate Finder"
        '
        'ItemListImporterToolStripMenuItem
        '
        Me.ItemListImporterToolStripMenuItem.Image = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgItemListImporter
        Me.ItemListImporterToolStripMenuItem.Name = "ItemListImporterToolStripMenuItem"
        Me.ItemListImporterToolStripMenuItem.Size = New System.Drawing.Size(204, 26)
        Me.ItemListImporterToolStripMenuItem.Text = "Item List Importer"
        '
        'cmsHamburgerButton
        '
        Me.cmsHamburgerButton.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EinstellungenToolStripMenuItem, Me.OutputToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.cmsHamburgerButton.Name = "cmsHamburgerButton"
        Me.cmsHamburgerButton.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.cmsHamburgerButton.Size = New System.Drawing.Size(134, 108)
        '
        'EinstellungenToolStripMenuItem
        '
        Me.EinstellungenToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EinstellungenToolStripMenuItem.Image = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgSettings
        Me.EinstellungenToolStripMenuItem.Name = "EinstellungenToolStripMenuItem"
        Me.EinstellungenToolStripMenuItem.Size = New System.Drawing.Size(133, 26)
        Me.EinstellungenToolStripMenuItem.Text = "Settings"
        '
        'OutputToolStripMenuItem
        '
        Me.OutputToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OutputToolStripMenuItem.Image = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgOutput
        Me.OutputToolStripMenuItem.Name = "OutputToolStripMenuItem"
        Me.OutputToolStripMenuItem.Size = New System.Drawing.Size(133, 26)
        Me.OutputToolStripMenuItem.Text = "Output"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DocumentaryToolStripMenuItem, Me.ChangelogToolStripMenuItem, Me.AboutToolStripMenuItem1})
        Me.HelpToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(133, 26)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'DocumentaryToolStripMenuItem
        '
        Me.DocumentaryToolStripMenuItem.Image = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgHelp
        Me.DocumentaryToolStripMenuItem.Name = "DocumentaryToolStripMenuItem"
        Me.DocumentaryToolStripMenuItem.Size = New System.Drawing.Size(174, 26)
        Me.DocumentaryToolStripMenuItem.Text = "Documentary"
        '
        'ChangelogToolStripMenuItem
        '
        Me.ChangelogToolStripMenuItem.Image = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgUpdate
        Me.ChangelogToolStripMenuItem.Name = "ChangelogToolStripMenuItem"
        Me.ChangelogToolStripMenuItem.Size = New System.Drawing.Size(174, 26)
        Me.ChangelogToolStripMenuItem.Text = "Changelog"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Image = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgAbout
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(174, 26)
        Me.AboutToolStripMenuItem1.Text = "About"
        '
        'btnAddItem
        '
        Me.btnAddItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAddItem.BackColor = System.Drawing.Color.Transparent
        Me.btnAddItem.BackgroundImage = CType(resources.GetObject("btnAddItem.BackgroundImage"), System.Drawing.Image)
        Me.btnAddItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddItem.FlatAppearance.BorderSize = 0
        Me.btnAddItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnAddItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddItem.ForeColor = System.Drawing.Color.White
        Me.btnAddItem.Location = New System.Drawing.Point(345, 759)
        Me.btnAddItem.Name = "btnAddItem"
        Me.btnAddItem.Size = New System.Drawing.Size(344, 37)
        Me.btnAddItem.TabIndex = 63
        Me.btnAddItem.Text = "Add item to datapack"
        Me.btnAddItem.UseVisualStyleBackColor = False
        '
        'pbLine
        '
        Me.pbLine.BackgroundImage = CType(resources.GetObject("pbLine.BackgroundImage"), System.Drawing.Image)
        Me.pbLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbLine.Location = New System.Drawing.Point(1, 68)
        Me.pbLine.Name = "pbLine"
        Me.pbLine.Size = New System.Drawing.Size(716, 16)
        Me.pbLine.TabIndex = 98
        Me.pbLine.TabStop = False
        '
        'pbHeader
        '
        Me.pbHeader.BackgroundImage = CType(resources.GetObject("pbHeader.BackgroundImage"), System.Drawing.Image)
        Me.pbHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbHeader.Location = New System.Drawing.Point(18, 9)
        Me.pbHeader.Name = "pbHeader"
        Me.pbHeader.Size = New System.Drawing.Size(56, 56)
        Me.pbHeader.TabIndex = 97
        Me.pbHeader.TabStop = False
        '
        'btnHamburger
        '
        Me.btnHamburger.BackgroundImage = CType(resources.GetObject("btnHamburger.BackgroundImage"), System.Drawing.Image)
        Me.btnHamburger.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnHamburger.FlatAppearance.BorderSize = 0
        Me.btnHamburger.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnHamburger.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnHamburger.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHamburger.Location = New System.Drawing.Point(651, 16)
        Me.btnHamburger.Name = "btnHamburger"
        Me.btnHamburger.Size = New System.Drawing.Size(48, 49)
        Me.btnHamburger.TabIndex = 96
        Me.btnHamburger.UseVisualStyleBackColor = True
        '
        'btnDeleteSelectedScheme
        '
        Me.btnDeleteSelectedScheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnDeleteSelectedScheme.BackgroundImage = CType(resources.GetObject("btnDeleteSelectedScheme.BackgroundImage"), System.Drawing.Image)
        Me.btnDeleteSelectedScheme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDeleteSelectedScheme.FlatAppearance.BorderSize = 0
        Me.btnDeleteSelectedScheme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnDeleteSelectedScheme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnDeleteSelectedScheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDeleteSelectedScheme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDeleteSelectedScheme.ForeColor = System.Drawing.Color.White
        Me.btnDeleteSelectedScheme.Location = New System.Drawing.Point(490, 658)
        Me.btnDeleteSelectedScheme.Name = "btnDeleteSelectedScheme"
        Me.btnDeleteSelectedScheme.Size = New System.Drawing.Size(179, 32)
        Me.btnDeleteSelectedScheme.TabIndex = 90
        Me.btnDeleteSelectedScheme.Text = "Delete selected scheme"
        Me.btnDeleteSelectedScheme.UseVisualStyleBackColor = False
        '
        'btnLoadProfile
        '
        Me.btnLoadProfile.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnLoadProfile.BackgroundImage = CType(resources.GetObject("btnLoadProfile.BackgroundImage"), System.Drawing.Image)
        Me.btnLoadProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLoadProfile.FlatAppearance.BorderSize = 0
        Me.btnLoadProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnLoadProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnLoadProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadProfile.ForeColor = System.Drawing.Color.White
        Me.btnLoadProfile.Location = New System.Drawing.Point(386, 226)
        Me.btnLoadProfile.Name = "btnLoadProfile"
        Me.btnLoadProfile.Size = New System.Drawing.Size(129, 24)
        Me.btnLoadProfile.TabIndex = 13
        Me.btnLoadProfile.Text = "Load profile"
        Me.btnLoadProfile.UseVisualStyleBackColor = False
        '
        'btnOverwriteSelectedScheme
        '
        Me.btnOverwriteSelectedScheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnOverwriteSelectedScheme.BackgroundImage = CType(resources.GetObject("btnOverwriteSelectedScheme.BackgroundImage"), System.Drawing.Image)
        Me.btnOverwriteSelectedScheme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOverwriteSelectedScheme.FlatAppearance.BorderSize = 0
        Me.btnOverwriteSelectedScheme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnOverwriteSelectedScheme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnOverwriteSelectedScheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOverwriteSelectedScheme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOverwriteSelectedScheme.ForeColor = System.Drawing.Color.White
        Me.btnOverwriteSelectedScheme.Location = New System.Drawing.Point(490, 620)
        Me.btnOverwriteSelectedScheme.Name = "btnOverwriteSelectedScheme"
        Me.btnOverwriteSelectedScheme.Size = New System.Drawing.Size(179, 32)
        Me.btnOverwriteSelectedScheme.TabIndex = 86
        Me.btnOverwriteSelectedScheme.Text = "Overwrite selected scheme"
        Me.btnOverwriteSelectedScheme.UseVisualStyleBackColor = False
        '
        'btnSaveProfile
        '
        Me.btnSaveProfile.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnSaveProfile.BackgroundImage = CType(resources.GetObject("btnSaveProfile.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSaveProfile.FlatAppearance.BorderSize = 0
        Me.btnSaveProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnSaveProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnSaveProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveProfile.ForeColor = System.Drawing.Color.White
        Me.btnSaveProfile.Location = New System.Drawing.Point(521, 226)
        Me.btnSaveProfile.Name = "btnSaveProfile"
        Me.btnSaveProfile.Size = New System.Drawing.Size(129, 24)
        Me.btnSaveProfile.TabIndex = 12
        Me.btnSaveProfile.Text = "Save profile"
        Me.btnSaveProfile.UseVisualStyleBackColor = False
        '
        'btnSaveAsNewScheme
        '
        Me.btnSaveAsNewScheme.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnSaveAsNewScheme.BackgroundImage = CType(resources.GetObject("btnSaveAsNewScheme.BackgroundImage"), System.Drawing.Image)
        Me.btnSaveAsNewScheme.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSaveAsNewScheme.FlatAppearance.BorderSize = 0
        Me.btnSaveAsNewScheme.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnSaveAsNewScheme.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnSaveAsNewScheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveAsNewScheme.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSaveAsNewScheme.ForeColor = System.Drawing.Color.White
        Me.btnSaveAsNewScheme.Location = New System.Drawing.Point(490, 582)
        Me.btnSaveAsNewScheme.Name = "btnSaveAsNewScheme"
        Me.btnSaveAsNewScheme.Size = New System.Drawing.Size(179, 32)
        Me.btnSaveAsNewScheme.TabIndex = 85
        Me.btnSaveAsNewScheme.Text = "Save as new scheme"
        Me.btnSaveAsNewScheme.UseVisualStyleBackColor = False
        '
        'btnBrowseDatapackPath
        '
        Me.btnBrowseDatapackPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnBrowseDatapackPath.BackgroundImage = CType(resources.GetObject("btnBrowseDatapackPath.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowseDatapackPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBrowseDatapackPath.FlatAppearance.BorderSize = 0
        Me.btnBrowseDatapackPath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnBrowseDatapackPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.btnBrowseDatapackPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowseDatapackPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowseDatapackPath.ForeColor = System.Drawing.Color.White
        Me.btnBrowseDatapackPath.Location = New System.Drawing.Point(521, 162)
        Me.btnBrowseDatapackPath.Name = "btnBrowseDatapackPath"
        Me.btnBrowseDatapackPath.Size = New System.Drawing.Size(129, 23)
        Me.btnBrowseDatapackPath.TabIndex = 2
        Me.btnBrowseDatapackPath.Text = "Browse"
        Me.btnBrowseDatapackPath.UseVisualStyleBackColor = False
        '
        'pbSelectDatapack
        '
        Me.pbSelectDatapack.BackgroundImage = CType(resources.GetObject("pbSelectDatapack.BackgroundImage"), System.Drawing.Image)
        Me.pbSelectDatapack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbSelectDatapack.Location = New System.Drawing.Point(12, 103)
        Me.pbSelectDatapack.Name = "pbSelectDatapack"
        Me.pbSelectDatapack.Size = New System.Drawing.Size(696, 180)
        Me.pbSelectDatapack.TabIndex = 91
        Me.pbSelectDatapack.TabStop = False
        '
        'pbAddItem
        '
        Me.pbAddItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbAddItem.BackgroundImage = CType(resources.GetObject("pbAddItem.BackgroundImage"), System.Drawing.Image)
        Me.pbAddItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbAddItem.Location = New System.Drawing.Point(12, 303)
        Me.pbAddItem.Name = "pbAddItem"
        Me.pbAddItem.Size = New System.Drawing.Size(696, 461)
        Me.pbAddItem.TabIndex = 93
        Me.pbAddItem.TabStop = False
        '
        'DToolStripMenuItem
        '
        Me.DToolStripMenuItem.Image = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgHelp
        Me.DToolStripMenuItem.Name = "DToolStripMenuItem"
        Me.DToolStripMenuItem.Size = New System.Drawing.Size(180, 26)
        Me.DToolStripMenuItem.Text = "Documentary"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Image = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgAbout
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(180, 26)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'cbPainting
        '
        Me.cbPainting.AutoSize = True
        Me.cbPainting.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.cbPainting.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPainting.ForeColor = System.Drawing.Color.White
        Me.cbPainting.Location = New System.Drawing.Point(326, 591)
        Me.cbPainting.Name = "cbPainting"
        Me.cbPainting.Size = New System.Drawing.Size(74, 20)
        Me.cbPainting.TabIndex = 99
        Me.cbPainting.Text = "Painting"
        Me.cbPainting.UseVisualStyleBackColor = False
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(719, 808)
        Me.Controls.Add(Me.cbPainting)
        Me.Controls.Add(Me.btnAddItem)
        Me.Controls.Add(Me.pbLine)
        Me.Controls.Add(Me.pbHeader)
        Me.Controls.Add(Me.btnHamburger)
        Me.Controls.Add(Me.btnDeleteSelectedScheme)
        Me.Controls.Add(Me.lblBoxAddItemHeader)
        Me.Controls.Add(Me.cbEnableAdvancedView)
        Me.Controls.Add(Me.cbxScheme)
        Me.Controls.Add(Me.lblBoxSelectDatapackHeader)
        Me.Controls.Add(Me.lblScheme)
        Me.Controls.Add(Me.btnLoadProfile)
        Me.Controls.Add(Me.btnOverwriteSelectedScheme)
        Me.Controls.Add(Me.btnSaveProfile)
        Me.Controls.Add(Me.btnSaveAsNewScheme)
        Me.Controls.Add(Me.rtbItemsRandomSame116)
        Me.Controls.Add(Me.cbAddItemsFast)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.cbGoatHorn)
        Me.Controls.Add(Me.rtbItemsRandomSame119)
        Me.Controls.Add(Me.cbNormalItem)
        Me.Controls.Add(Me.cbxVersion)
        Me.Controls.Add(Me.tbSmallOutput)
        Me.Controls.Add(Me.lblOutput)
        Me.Controls.Add(Me.lblDatapackDetection)
        Me.Controls.Add(Me.tbSamePrefix)
        Me.Controls.Add(Me.cbxDefaultProfile)
        Me.Controls.Add(Me.cbSamePrefix)
        Me.Controls.Add(Me.btnBrowseDatapackPath)
        Me.Controls.Add(Me.rbtnCommandBlock)
        Me.Controls.Add(Me.lblItemsTotal)
        Me.Controls.Add(Me.rbtnOtherItem)
        Me.Controls.Add(Me.tbDatapackPath)
        Me.Controls.Add(Me.rbtnSpawnEgg)
        Me.Controls.Add(Me.cbSplashPotion)
        Me.Controls.Add(Me.lblSelectDatapack)
        Me.Controls.Add(Me.cbLingeringPotion)
        Me.Controls.Add(Me.rtbLog)
        Me.Controls.Add(Me.cbTippedArrow)
        Me.Controls.Add(Me.Quotationmark)
        Me.Controls.Add(Me.cbSuspiciousStew)
        Me.Controls.Add(Me.rtbCodeEnd)
        Me.Controls.Add(Me.cbPotion)
        Me.Controls.Add(Me.rtbItems64)
        Me.Controls.Add(Me.cbEnchantedBook)
        Me.Controls.Add(Me.rtbItems32)
        Me.Controls.Add(Me.cbCreativeOnly)
        Me.Controls.Add(Me.rtbItems10)
        Me.Controls.Add(Me.rtbItems3)
        Me.Controls.Add(Me.lblAddNewItems)
        Me.Controls.Add(Me.gbItemID)
        Me.Controls.Add(Me.rtbItems5)
        Me.Controls.Add(Me.cbCustomNBT)
        Me.Controls.Add(Me.rtbItems2)
        Me.Controls.Add(Me.tbCustomNBT)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.pbSelectDatapack)
        Me.Controls.Add(Me.pbAddItem)
        Me.Controls.Add(Me.pbAddingItemsProgress)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Random Item Giver Updater BETA 0.5.0 Dev"
        Me.gbItemID.ResumeLayout(False)
        Me.cmsHamburgerButton.ResumeLayout(False)
        CType(Me.pbLine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbHeader, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbSelectDatapack, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbAddItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents cbNormalItem As CheckBox
    Friend WithEvents cbCustomNBT As CheckBox
    Friend WithEvents tbCustomNBT As TextBox
    Friend WithEvents tbSmallOutput As TextBox
    Friend WithEvents lblOutput As Label
    Friend WithEvents tbSamePrefix As TextBox
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
    Friend WithEvents lblAddNewItems As Label
    Friend WithEvents btnAddItem As Button
    Friend WithEvents btnBrowseDatapackPath As Button
    Friend WithEvents tbDatapackPath As TextBox
    Friend WithEvents lblSelectDatapack As Label
    Friend WithEvents fbdMainFolderPath As FolderBrowserDialog
    Friend WithEvents Quotationmark As Label
    Friend WithEvents rtbCodeEnd As RichTextBox
    Friend WithEvents rtbItems64 As RichTextBox
    Friend WithEvents rtbItems32 As RichTextBox
    Friend WithEvents rtbItems10 As RichTextBox
    Friend WithEvents rtbItems3 As RichTextBox
    Friend WithEvents rtbItems5 As RichTextBox
    Friend WithEvents rtbItems2 As RichTextBox
    Friend WithEvents lblDatapackDetection As Label
    Friend WithEvents rtbItem As RichTextBox
    Friend WithEvents gbItemID As GroupBox
    Friend WithEvents rtbLog As RichTextBox
    Friend WithEvents cbGoatHorn As CheckBox
    Friend WithEvents lblVersion As Label
    Friend WithEvents cbxVersion As ComboBox
    Friend WithEvents cbAddItemsFast As CheckBox
    Friend WithEvents pbAddingItemsProgress As ProgressBar
    Friend WithEvents bgwAddItems As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblItemsTotal As Label
    Friend WithEvents btnLoadProfile As Button
    Friend WithEvents btnSaveProfile As Button
    Friend WithEvents cbxScheme As ComboBox
    Friend WithEvents lblScheme As Label
    Friend WithEvents btnOverwriteSelectedScheme As Button
    Friend WithEvents btnSaveAsNewScheme As Button
    Friend WithEvents cbEnableAdvancedView As CheckBox
    Friend WithEvents cbxDefaultProfile As ComboBox
    Friend WithEvents btnDeleteSelectedScheme As Button
    Friend WithEvents rtbItemsRandomSame119 As RichTextBox
    Friend WithEvents rtbItemsRandomSame116 As RichTextBox
    Friend WithEvents pbSelectDatapack As PictureBox
    Friend WithEvents lblBoxSelectDatapackHeader As Label
    Friend WithEvents pbAddItem As PictureBox
    Friend WithEvents lblBoxAddItemHeader As Label
    Friend WithEvents btnHamburger As Button
    Friend WithEvents pbHeader As PictureBox
    Friend WithEvents pbLine As PictureBox
    Friend WithEvents EinstellungenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OutputToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cmsHamburgerButton As ContextMenuStrip
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DuplicateFinderToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ItemListImporterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DocumentaryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangelogToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents cbPainting As CheckBox
End Class
