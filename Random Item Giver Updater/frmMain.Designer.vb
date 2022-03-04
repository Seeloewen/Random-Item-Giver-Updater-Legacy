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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cb2NormalItem = New System.Windows.Forms.CheckBox()
        Me.cb2NBT = New System.Windows.Forms.CheckBox()
        Me.tb2NBT = New System.Windows.Forms.TextBox()
        Me.tb2SmallOutput = New System.Windows.Forms.TextBox()
        Me.lbl2Output = New System.Windows.Forms.Label()
        Me.tb2CustomPrefix = New System.Windows.Forms.TextBox()
        Me.cb2CustomPrefix = New System.Windows.Forms.CheckBox()
        Me.rbtn2CommandBlock = New System.Windows.Forms.RadioButton()
        Me.rbtn2OtherItem = New System.Windows.Forms.RadioButton()
        Me.rbtn2SpawnEgg = New System.Windows.Forms.RadioButton()
        Me.cb2SplashPotion = New System.Windows.Forms.CheckBox()
        Me.cb2LingeringPotion = New System.Windows.Forms.CheckBox()
        Me.cb2TippedArrow = New System.Windows.Forms.CheckBox()
        Me.cb2SuspiciousStew = New System.Windows.Forms.CheckBox()
        Me.cb2Potion = New System.Windows.Forms.CheckBox()
        Me.cb2EnchantedBook = New System.Windows.Forms.CheckBox()
        Me.cb2CreativeOnly = New System.Windows.Forms.CheckBox()
        Me.lbl2ID = New System.Windows.Forms.Label()
        Me.tb2ID = New System.Windows.Forms.TextBox()
        Me.lbl2Explanation = New System.Windows.Forms.Label()
        Me.btn2ShowOutput = New System.Windows.Forms.Button()
        Me.btn2Add = New System.Windows.Forms.Button()
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
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 24)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Random Item Giver Updater"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(638, 98)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select datapack"
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton3.Location = New System.Drawing.Point(361, 71)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(167, 20)
        Me.RadioButton3.TabIndex = 5
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Text = "Random Item Giver 1.16"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(188, 71)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(167, 20)
        Me.RadioButton2.TabIndex = 4
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Random Item Giver 1.17"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(15, 71)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(167, 20)
        Me.RadioButton1.TabIndex = 3
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Random Item Giver 1.18"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(499, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(129, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(15, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(478, 22)
        Me.TextBox1.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(323, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Please chose the datapack and which version it is for."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cb2NormalItem)
        Me.GroupBox2.Controls.Add(Me.cb2NBT)
        Me.GroupBox2.Controls.Add(Me.tb2NBT)
        Me.GroupBox2.Controls.Add(Me.tb2SmallOutput)
        Me.GroupBox2.Controls.Add(Me.lbl2Output)
        Me.GroupBox2.Controls.Add(Me.tb2CustomPrefix)
        Me.GroupBox2.Controls.Add(Me.cb2CustomPrefix)
        Me.GroupBox2.Controls.Add(Me.rbtn2CommandBlock)
        Me.GroupBox2.Controls.Add(Me.rbtn2OtherItem)
        Me.GroupBox2.Controls.Add(Me.rbtn2SpawnEgg)
        Me.GroupBox2.Controls.Add(Me.cb2SplashPotion)
        Me.GroupBox2.Controls.Add(Me.cb2LingeringPotion)
        Me.GroupBox2.Controls.Add(Me.cb2TippedArrow)
        Me.GroupBox2.Controls.Add(Me.cb2SuspiciousStew)
        Me.GroupBox2.Controls.Add(Me.cb2Potion)
        Me.GroupBox2.Controls.Add(Me.cb2EnchantedBook)
        Me.GroupBox2.Controls.Add(Me.cb2CreativeOnly)
        Me.GroupBox2.Controls.Add(Me.lbl2ID)
        Me.GroupBox2.Controls.Add(Me.tb2ID)
        Me.GroupBox2.Controls.Add(Me.lbl2Explanation)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(16, 167)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(638, 254)
        Me.GroupBox2.TabIndex = 58
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add item"
        '
        'cb2NormalItem
        '
        Me.cb2NormalItem.AutoSize = True
        Me.cb2NormalItem.Checked = True
        Me.cb2NormalItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cb2NormalItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb2NormalItem.Location = New System.Drawing.Point(449, 53)
        Me.cb2NormalItem.Name = "cb2NormalItem"
        Me.cb2NormalItem.Size = New System.Drawing.Size(98, 20)
        Me.cb2NormalItem.TabIndex = 80
        Me.cb2NormalItem.Text = "Normal item"
        Me.cb2NormalItem.UseVisualStyleBackColor = True
        '
        'cb2NBT
        '
        Me.cb2NBT.AutoSize = True
        Me.cb2NBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb2NBT.Location = New System.Drawing.Point(15, 150)
        Me.cb2NBT.Name = "cb2NBT"
        Me.cb2NBT.Size = New System.Drawing.Size(171, 20)
        Me.cb2NBT.TabIndex = 79
        Me.cb2NBT.Text = "NBT Tag (Potions, etc...)"
        Me.cb2NBT.UseVisualStyleBackColor = True
        '
        'tb2NBT
        '
        Me.tb2NBT.Enabled = False
        Me.tb2NBT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb2NBT.Location = New System.Drawing.Point(15, 176)
        Me.tb2NBT.Name = "tb2NBT"
        Me.tb2NBT.Size = New System.Drawing.Size(197, 22)
        Me.tb2NBT.TabIndex = 78
        '
        'tb2SmallOutput
        '
        Me.tb2SmallOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb2SmallOutput.Location = New System.Drawing.Point(66, 219)
        Me.tb2SmallOutput.Multiline = True
        Me.tb2SmallOutput.Name = "tb2SmallOutput"
        Me.tb2SmallOutput.ReadOnly = True
        Me.tb2SmallOutput.Size = New System.Drawing.Size(562, 20)
        Me.tb2SmallOutput.TabIndex = 77
        '
        'lbl2Output
        '
        Me.lbl2Output.AutoSize = True
        Me.lbl2Output.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2Output.Location = New System.Drawing.Point(12, 219)
        Me.lbl2Output.Name = "lbl2Output"
        Me.lbl2Output.Size = New System.Drawing.Size(48, 16)
        Me.lbl2Output.TabIndex = 76
        Me.lbl2Output.Text = "Output:"
        '
        'tb2CustomPrefix
        '
        Me.tb2CustomPrefix.Enabled = False
        Me.tb2CustomPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb2CustomPrefix.Location = New System.Drawing.Point(15, 122)
        Me.tb2CustomPrefix.Name = "tb2CustomPrefix"
        Me.tb2CustomPrefix.Size = New System.Drawing.Size(197, 22)
        Me.tb2CustomPrefix.TabIndex = 75
        '
        'cb2CustomPrefix
        '
        Me.cb2CustomPrefix.AutoSize = True
        Me.cb2CustomPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb2CustomPrefix.Location = New System.Drawing.Point(15, 99)
        Me.cb2CustomPrefix.Name = "cb2CustomPrefix"
        Me.cb2CustomPrefix.Size = New System.Drawing.Size(181, 20)
        Me.cb2CustomPrefix.TabIndex = 73
        Me.cb2CustomPrefix.Text = "Custom Prefix (Mod-Items)"
        Me.cb2CustomPrefix.UseVisualStyleBackColor = True
        '
        'rbtn2CommandBlock
        '
        Me.rbtn2CommandBlock.AutoSize = True
        Me.rbtn2CommandBlock.Enabled = False
        Me.rbtn2CommandBlock.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtn2CommandBlock.Location = New System.Drawing.Point(463, 124)
        Me.rbtn2CommandBlock.Name = "rbtn2CommandBlock"
        Me.rbtn2CommandBlock.Size = New System.Drawing.Size(124, 20)
        Me.rbtn2CommandBlock.TabIndex = 72
        Me.rbtn2CommandBlock.TabStop = True
        Me.rbtn2CommandBlock.Text = "Command Block"
        Me.rbtn2CommandBlock.UseVisualStyleBackColor = True
        '
        'rbtn2OtherItem
        '
        Me.rbtn2OtherItem.AutoSize = True
        Me.rbtn2OtherItem.Enabled = False
        Me.rbtn2OtherItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtn2OtherItem.Location = New System.Drawing.Point(463, 148)
        Me.rbtn2OtherItem.Name = "rbtn2OtherItem"
        Me.rbtn2OtherItem.Size = New System.Drawing.Size(169, 20)
        Me.rbtn2OtherItem.TabIndex = 71
        Me.rbtn2OtherItem.TabStop = True
        Me.rbtn2OtherItem.Text = "Other Creative-Only item"
        Me.rbtn2OtherItem.UseVisualStyleBackColor = True
        '
        'rbtn2SpawnEgg
        '
        Me.rbtn2SpawnEgg.AutoSize = True
        Me.rbtn2SpawnEgg.Enabled = False
        Me.rbtn2SpawnEgg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtn2SpawnEgg.Location = New System.Drawing.Point(463, 101)
        Me.rbtn2SpawnEgg.Name = "rbtn2SpawnEgg"
        Me.rbtn2SpawnEgg.Size = New System.Drawing.Size(94, 20)
        Me.rbtn2SpawnEgg.TabIndex = 70
        Me.rbtn2SpawnEgg.TabStop = True
        Me.rbtn2SpawnEgg.Text = "Spawn Egg"
        Me.rbtn2SpawnEgg.UseVisualStyleBackColor = True
        '
        'cb2SplashPotion
        '
        Me.cb2SplashPotion.AutoSize = True
        Me.cb2SplashPotion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb2SplashPotion.Location = New System.Drawing.Point(294, 124)
        Me.cb2SplashPotion.Name = "cb2SplashPotion"
        Me.cb2SplashPotion.Size = New System.Drawing.Size(109, 20)
        Me.cb2SplashPotion.TabIndex = 69
        Me.cb2SplashPotion.Text = "Splash Potion"
        Me.cb2SplashPotion.UseVisualStyleBackColor = True
        '
        'cb2LingeringPotion
        '
        Me.cb2LingeringPotion.AutoSize = True
        Me.cb2LingeringPotion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb2LingeringPotion.Location = New System.Drawing.Point(294, 148)
        Me.cb2LingeringPotion.Name = "cb2LingeringPotion"
        Me.cb2LingeringPotion.Size = New System.Drawing.Size(122, 20)
        Me.cb2LingeringPotion.TabIndex = 68
        Me.cb2LingeringPotion.Text = "Lingering Potion"
        Me.cb2LingeringPotion.UseVisualStyleBackColor = True
        '
        'cb2TippedArrow
        '
        Me.cb2TippedArrow.AutoSize = True
        Me.cb2TippedArrow.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb2TippedArrow.Location = New System.Drawing.Point(294, 174)
        Me.cb2TippedArrow.Name = "cb2TippedArrow"
        Me.cb2TippedArrow.Size = New System.Drawing.Size(107, 20)
        Me.cb2TippedArrow.TabIndex = 67
        Me.cb2TippedArrow.Text = "Tipped Arrow"
        Me.cb2TippedArrow.UseVisualStyleBackColor = True
        '
        'cb2SuspiciousStew
        '
        Me.cb2SuspiciousStew.AutoSize = True
        Me.cb2SuspiciousStew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb2SuspiciousStew.Location = New System.Drawing.Point(294, 53)
        Me.cb2SuspiciousStew.Name = "cb2SuspiciousStew"
        Me.cb2SuspiciousStew.Size = New System.Drawing.Size(117, 20)
        Me.cb2SuspiciousStew.TabIndex = 66
        Me.cb2SuspiciousStew.Text = "Supicious Stew"
        Me.cb2SuspiciousStew.UseVisualStyleBackColor = True
        '
        'cb2Potion
        '
        Me.cb2Potion.AutoSize = True
        Me.cb2Potion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb2Potion.Location = New System.Drawing.Point(294, 100)
        Me.cb2Potion.Name = "cb2Potion"
        Me.cb2Potion.Size = New System.Drawing.Size(64, 20)
        Me.cb2Potion.TabIndex = 65
        Me.cb2Potion.Text = "Potion"
        Me.cb2Potion.UseVisualStyleBackColor = True
        '
        'cb2EnchantedBook
        '
        Me.cb2EnchantedBook.AutoSize = True
        Me.cb2EnchantedBook.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb2EnchantedBook.Location = New System.Drawing.Point(294, 76)
        Me.cb2EnchantedBook.Name = "cb2EnchantedBook"
        Me.cb2EnchantedBook.Size = New System.Drawing.Size(125, 20)
        Me.cb2EnchantedBook.TabIndex = 64
        Me.cb2EnchantedBook.Text = "Enchanted Book"
        Me.cb2EnchantedBook.UseVisualStyleBackColor = True
        '
        'cb2CreativeOnly
        '
        Me.cb2CreativeOnly.AutoSize = True
        Me.cb2CreativeOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cb2CreativeOnly.Location = New System.Drawing.Point(449, 79)
        Me.cb2CreativeOnly.Name = "cb2CreativeOnly"
        Me.cb2CreativeOnly.Size = New System.Drawing.Size(107, 20)
        Me.cb2CreativeOnly.TabIndex = 61
        Me.cb2CreativeOnly.Text = "Creative-Only"
        Me.cb2CreativeOnly.UseVisualStyleBackColor = True
        '
        'lbl2ID
        '
        Me.lbl2ID.AutoSize = True
        Me.lbl2ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2ID.Location = New System.Drawing.Point(12, 53)
        Me.lbl2ID.Name = "lbl2ID"
        Me.lbl2ID.Size = New System.Drawing.Size(51, 16)
        Me.lbl2ID.TabIndex = 60
        Me.lbl2ID.Text = "Item ID:"
        '
        'tb2ID
        '
        Me.tb2ID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tb2ID.Location = New System.Drawing.Point(15, 71)
        Me.tb2ID.Name = "tb2ID"
        Me.tb2ID.Size = New System.Drawing.Size(197, 22)
        Me.tb2ID.TabIndex = 57
        '
        'lbl2Explanation
        '
        Me.lbl2Explanation.AutoSize = True
        Me.lbl2Explanation.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2Explanation.Location = New System.Drawing.Point(12, 22)
        Me.lbl2Explanation.Name = "lbl2Explanation"
        Me.lbl2Explanation.Size = New System.Drawing.Size(261, 16)
        Me.lbl2Explanation.TabIndex = 56
        Me.lbl2Explanation.Text = "Add new items and blocks to the datapack."
        '
        'btn2ShowOutput
        '
        Me.btn2ShowOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2ShowOutput.Location = New System.Drawing.Point(465, 429)
        Me.btn2ShowOutput.Name = "btn2ShowOutput"
        Me.btn2ShowOutput.Size = New System.Drawing.Size(189, 34)
        Me.btn2ShowOutput.TabIndex = 74
        Me.btn2ShowOutput.Text = "Show output"
        Me.btn2ShowOutput.UseVisualStyleBackColor = True
        '
        'btn2Add
        '
        Me.btn2Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn2Add.Location = New System.Drawing.Point(16, 429)
        Me.btn2Add.Name = "btn2Add"
        Me.btn2Add.Size = New System.Drawing.Size(443, 34)
        Me.btn2Add.TabIndex = 63
        Me.btn2Add.Text = "Add item to datapack"
        Me.btn2Add.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(668, 24)
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
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(668, 476)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn2Add)
        Me.Controls.Add(Me.btn2ShowOutput)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Random Item Giver Updater"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cb2NormalItem As CheckBox
    Friend WithEvents cb2NBT As CheckBox
    Friend WithEvents tb2NBT As TextBox
    Friend WithEvents tb2SmallOutput As TextBox
    Friend WithEvents lbl2Output As Label
    Friend WithEvents tb2CustomPrefix As TextBox
    Friend WithEvents btn2ShowOutput As Button
    Friend WithEvents cb2CustomPrefix As CheckBox
    Friend WithEvents rbtn2CommandBlock As RadioButton
    Friend WithEvents rbtn2OtherItem As RadioButton
    Friend WithEvents rbtn2SpawnEgg As RadioButton
    Friend WithEvents cb2SplashPotion As CheckBox
    Friend WithEvents cb2LingeringPotion As CheckBox
    Friend WithEvents cb2TippedArrow As CheckBox
    Friend WithEvents cb2SuspiciousStew As CheckBox
    Friend WithEvents cb2Potion As CheckBox
    Friend WithEvents cb2EnchantedBook As CheckBox
    Friend WithEvents cb2CreativeOnly As CheckBox
    Friend WithEvents lbl2ID As Label
    Friend WithEvents tb2ID As TextBox
    Friend WithEvents lbl2Explanation As Label
    Friend WithEvents btn2Add As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
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
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents OutputToolStripMenuItem As ToolStripMenuItem
End Class
