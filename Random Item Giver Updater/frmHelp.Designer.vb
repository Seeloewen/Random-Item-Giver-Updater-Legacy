<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHelp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHelp))
        Me.tcHelp = New System.Windows.Forms.TabControl()
        Me.tpIntroduction = New System.Windows.Forms.TabPage()
        Me.llblDiscord = New System.Windows.Forms.LinkLabel()
        Me.lblLastEditedIntroduction = New System.Windows.Forms.Label()
        Me.lblIntroduction = New System.Windows.Forms.Label()
        Me.tpSimpleOverview = New System.Windows.Forms.TabPage()
        Me.lblLastEditedSimpleOverview = New System.Windows.Forms.Label()
        Me.llblRIGPMC = New System.Windows.Forms.LinkLabel()
        Me.llblRIGGithub = New System.Windows.Forms.LinkLabel()
        Me.lblSimpleOverview = New System.Windows.Forms.Label()
        Me.tpAddingItemsBasic = New System.Windows.Forms.TabPage()
        Me.lblSelectDatapackVersionBasic = New System.Windows.Forms.Label()
        Me.lblSelectDatapackFolderBasic = New System.Windows.Forms.Label()
        Me.lblSpecifyNBTTagBasic = New System.Windows.Forms.Label()
        Me.lblAddItemsToDatapackBasic = New System.Windows.Forms.Label()
        Me.lblSelectItemTypeBasic = New System.Windows.Forms.Label()
        Me.lblSelectItemIDBasic = New System.Windows.Forms.Label()
        Me.lblDescriptionAddItemsBasic = New System.Windows.Forms.Label()
        Me.lblLastEditedAddingItemsBasic = New System.Windows.Forms.Label()
        Me.lblWhatIsTheFastWayBasic = New System.Windows.Forms.LinkLabel()
        Me.llblHowToFindTheItemIDBasic = New System.Windows.Forms.LinkLabel()
        Me.pbAddItemsBasic = New System.Windows.Forms.PictureBox()
        Me.tpAddingItemsAdvanced = New System.Windows.Forms.TabPage()
        Me.lblLastEditedAddingItemsAdvanced = New System.Windows.Forms.Label()
        Me.llblWhatsTheFastWayAdvanced = New System.Windows.Forms.LinkLabel()
        Me.llblHowToFindItemIDAdvanced = New System.Windows.Forms.LinkLabel()
        Me.lblSpecifyPrefixAndNBTTagAdvanced = New System.Windows.Forms.Label()
        Me.lblAddItemsToDatapackAdvanced = New System.Windows.Forms.Label()
        Me.SelectItemTypeAdvanced = New System.Windows.Forms.Label()
        Me.lblSelectDatapackVersionAdvanced = New System.Windows.Forms.Label()
        Me.lblSelectDatapackFolderAdvanced = New System.Windows.Forms.Label()
        Me.lblEnterItemIDHereAdvanced = New System.Windows.Forms.Label()
        Me.lblDescriptionAddingItemsAdvanced = New System.Windows.Forms.Label()
        Me.pbAddingItemsAdvanced = New System.Windows.Forms.PictureBox()
        Me.tpDuplicateFinder = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pbDuplicateFinder = New System.Windows.Forms.PictureBox()
        Me.tpProfilesAndSchemes = New System.Windows.Forms.TabPage()
        Me.lblLastEditedProfilesAndSchemes = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tpOther = New System.Windows.Forms.TabPage()
        Me.lblLastEditedOther = New System.Windows.Forms.Label()
        Me.llblTellMe = New System.Windows.Forms.LinkLabel()
        Me.llblOtherDiscord = New System.Windows.Forms.LinkLabel()
        Me.llblDatapackGithub = New System.Windows.Forms.LinkLabel()
        Me.llblDatapackPMC = New System.Windows.Forms.LinkLabel()
        Me.llblSoftwareGithub = New System.Windows.Forms.LinkLabel()
        Me.lblOther = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.tcHelp.SuspendLayout()
        Me.tpIntroduction.SuspendLayout()
        Me.tpSimpleOverview.SuspendLayout()
        Me.tpAddingItemsBasic.SuspendLayout()
        CType(Me.pbAddItemsBasic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAddingItemsAdvanced.SuspendLayout()
        CType(Me.pbAddingItemsAdvanced, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDuplicateFinder.SuspendLayout()
        CType(Me.pbDuplicateFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpProfilesAndSchemes.SuspendLayout()
        Me.tpOther.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcHelp
        '
        Me.tcHelp.Controls.Add(Me.tpIntroduction)
        Me.tcHelp.Controls.Add(Me.tpSimpleOverview)
        Me.tcHelp.Controls.Add(Me.tpAddingItemsBasic)
        Me.tcHelp.Controls.Add(Me.tpAddingItemsAdvanced)
        Me.tcHelp.Controls.Add(Me.tpDuplicateFinder)
        Me.tcHelp.Controls.Add(Me.tpProfilesAndSchemes)
        Me.tcHelp.Controls.Add(Me.tpOther)
        Me.tcHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tcHelp.Location = New System.Drawing.Point(13, 48)
        Me.tcHelp.Name = "tcHelp"
        Me.tcHelp.SelectedIndex = 0
        Me.tcHelp.Size = New System.Drawing.Size(795, 857)
        Me.tcHelp.TabIndex = 0
        '
        'tpIntroduction
        '
        Me.tpIntroduction.Controls.Add(Me.llblDiscord)
        Me.tpIntroduction.Controls.Add(Me.lblLastEditedIntroduction)
        Me.tpIntroduction.Controls.Add(Me.lblIntroduction)
        Me.tpIntroduction.Location = New System.Drawing.Point(4, 25)
        Me.tpIntroduction.Name = "tpIntroduction"
        Me.tpIntroduction.Padding = New System.Windows.Forms.Padding(3)
        Me.tpIntroduction.Size = New System.Drawing.Size(787, 828)
        Me.tpIntroduction.TabIndex = 0
        Me.tpIntroduction.Text = "Introduction"
        Me.tpIntroduction.UseVisualStyleBackColor = True
        '
        'llblDiscord
        '
        Me.llblDiscord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llblDiscord.AutoSize = True
        Me.llblDiscord.Location = New System.Drawing.Point(13, 787)
        Me.llblDiscord.Name = "llblDiscord"
        Me.llblDiscord.Size = New System.Drawing.Size(201, 16)
        Me.llblDiscord.TabIndex = 5
        Me.llblDiscord.TabStop = True
        Me.llblDiscord.Text = "Louis9 Datapack Discord Server"
        '
        'lblLastEditedIntroduction
        '
        Me.lblLastEditedIntroduction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastEditedIntroduction.AutoSize = True
        Me.lblLastEditedIntroduction.Location = New System.Drawing.Point(630, 787)
        Me.lblLastEditedIntroduction.Name = "lblLastEditedIntroduction"
        Me.lblLastEditedIntroduction.Size = New System.Drawing.Size(141, 16)
        Me.lblLastEditedIntroduction.TabIndex = 4
        Me.lblLastEditedIntroduction.Text = "Last edited: 13.10.2022"
        '
        'lblIntroduction
        '
        Me.lblIntroduction.AutoSize = True
        Me.lblIntroduction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntroduction.Location = New System.Drawing.Point(13, 12)
        Me.lblIntroduction.Name = "lblIntroduction"
        Me.lblIntroduction.Size = New System.Drawing.Size(768, 288)
        Me.lblIntroduction.TabIndex = 0
        Me.lblIntroduction.Text = resources.GetString("lblIntroduction.Text")
        '
        'tpSimpleOverview
        '
        Me.tpSimpleOverview.Controls.Add(Me.lblLastEditedSimpleOverview)
        Me.tpSimpleOverview.Controls.Add(Me.llblRIGPMC)
        Me.tpSimpleOverview.Controls.Add(Me.llblRIGGithub)
        Me.tpSimpleOverview.Controls.Add(Me.lblSimpleOverview)
        Me.tpSimpleOverview.Location = New System.Drawing.Point(4, 25)
        Me.tpSimpleOverview.Name = "tpSimpleOverview"
        Me.tpSimpleOverview.Size = New System.Drawing.Size(787, 828)
        Me.tpSimpleOverview.TabIndex = 4
        Me.tpSimpleOverview.Text = "Simple Overview"
        Me.tpSimpleOverview.UseVisualStyleBackColor = True
        '
        'lblLastEditedSimpleOverview
        '
        Me.lblLastEditedSimpleOverview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastEditedSimpleOverview.AutoSize = True
        Me.lblLastEditedSimpleOverview.Location = New System.Drawing.Point(627, 797)
        Me.lblLastEditedSimpleOverview.Name = "lblLastEditedSimpleOverview"
        Me.lblLastEditedSimpleOverview.Size = New System.Drawing.Size(141, 16)
        Me.lblLastEditedSimpleOverview.TabIndex = 3
        Me.lblLastEditedSimpleOverview.Text = "Last edited: 24.10.2022"
        '
        'llblRIGPMC
        '
        Me.llblRIGPMC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llblRIGPMC.AutoSize = True
        Me.llblRIGPMC.Location = New System.Drawing.Point(14, 772)
        Me.llblRIGPMC.Name = "llblRIGPMC"
        Me.llblRIGPMC.Size = New System.Drawing.Size(300, 16)
        Me.llblRIGPMC.TabIndex = 2
        Me.llblRIGPMC.TabStop = True
        Me.llblRIGPMC.Text = "Random Item Giver Datapack on Planet Minecraft"
        '
        'llblRIGGithub
        '
        Me.llblRIGGithub.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llblRIGGithub.AutoSize = True
        Me.llblRIGGithub.Location = New System.Drawing.Point(14, 797)
        Me.llblRIGGithub.Name = "llblRIGGithub"
        Me.llblRIGGithub.Size = New System.Drawing.Size(246, 16)
        Me.llblRIGGithub.TabIndex = 1
        Me.llblRIGGithub.TabStop = True
        Me.llblRIGGithub.Text = "Random Item Giver Datapack on GitHub"
        '
        'lblSimpleOverview
        '
        Me.lblSimpleOverview.AutoSize = True
        Me.lblSimpleOverview.Location = New System.Drawing.Point(15, 13)
        Me.lblSimpleOverview.Name = "lblSimpleOverview"
        Me.lblSimpleOverview.Size = New System.Drawing.Size(671, 288)
        Me.lblSimpleOverview.TabIndex = 0
        Me.lblSimpleOverview.Text = resources.GetString("lblSimpleOverview.Text")
        '
        'tpAddingItemsBasic
        '
        Me.tpAddingItemsBasic.AutoScroll = True
        Me.tpAddingItemsBasic.Controls.Add(Me.lblSelectDatapackVersionBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblSelectDatapackFolderBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblSpecifyNBTTagBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblAddItemsToDatapackBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblSelectItemTypeBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblSelectItemIDBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblDescriptionAddItemsBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblLastEditedAddingItemsBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblWhatIsTheFastWayBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.llblHowToFindTheItemIDBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.pbAddItemsBasic)
        Me.tpAddingItemsBasic.Location = New System.Drawing.Point(4, 25)
        Me.tpAddingItemsBasic.Name = "tpAddingItemsBasic"
        Me.tpAddingItemsBasic.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAddingItemsBasic.Size = New System.Drawing.Size(787, 828)
        Me.tpAddingItemsBasic.TabIndex = 1
        Me.tpAddingItemsBasic.Text = "Adding Items (Basic)"
        Me.tpAddingItemsBasic.UseVisualStyleBackColor = True
        '
        'lblSelectDatapackVersionBasic
        '
        Me.lblSelectDatapackVersionBasic.AutoSize = True
        Me.lblSelectDatapackVersionBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectDatapackVersionBasic.ForeColor = System.Drawing.Color.Red
        Me.lblSelectDatapackVersionBasic.Location = New System.Drawing.Point(179, 144)
        Me.lblSelectDatapackVersionBasic.Name = "lblSelectDatapackVersionBasic"
        Me.lblSelectDatapackVersionBasic.Size = New System.Drawing.Size(185, 20)
        Me.lblSelectDatapackVersionBasic.TabIndex = 30
        Me.lblSelectDatapackVersionBasic.Text = "Select Datapack Version"
        '
        'lblSelectDatapackFolderBasic
        '
        Me.lblSelectDatapackFolderBasic.AutoSize = True
        Me.lblSelectDatapackFolderBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectDatapackFolderBasic.ForeColor = System.Drawing.Color.Red
        Me.lblSelectDatapackFolderBasic.Location = New System.Drawing.Point(250, 86)
        Me.lblSelectDatapackFolderBasic.Name = "lblSelectDatapackFolderBasic"
        Me.lblSelectDatapackFolderBasic.Size = New System.Drawing.Size(168, 20)
        Me.lblSelectDatapackFolderBasic.TabIndex = 29
        Me.lblSelectDatapackFolderBasic.Text = "Select datapack folder"
        '
        'lblSpecifyNBTTagBasic
        '
        Me.lblSpecifyNBTTagBasic.AutoSize = True
        Me.lblSpecifyNBTTagBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpecifyNBTTagBasic.ForeColor = System.Drawing.Color.Red
        Me.lblSpecifyNBTTagBasic.Location = New System.Drawing.Point(120, 359)
        Me.lblSpecifyNBTTagBasic.Name = "lblSpecifyNBTTagBasic"
        Me.lblSpecifyNBTTagBasic.Size = New System.Drawing.Size(123, 20)
        Me.lblSpecifyNBTTagBasic.TabIndex = 28
        Me.lblSpecifyNBTTagBasic.Text = "Specify NBT tag"
        '
        'lblAddItemsToDatapackBasic
        '
        Me.lblAddItemsToDatapackBasic.AutoSize = True
        Me.lblAddItemsToDatapackBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddItemsToDatapackBasic.ForeColor = System.Drawing.Color.Red
        Me.lblAddItemsToDatapackBasic.Location = New System.Drawing.Point(201, 495)
        Me.lblAddItemsToDatapackBasic.Name = "lblAddItemsToDatapackBasic"
        Me.lblAddItemsToDatapackBasic.Size = New System.Drawing.Size(222, 20)
        Me.lblAddItemsToDatapackBasic.TabIndex = 27
        Me.lblAddItemsToDatapackBasic.Text = "Add the items to the datapack"
        '
        'lblSelectItemTypeBasic
        '
        Me.lblSelectItemTypeBasic.AutoSize = True
        Me.lblSelectItemTypeBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectItemTypeBasic.ForeColor = System.Drawing.Color.Red
        Me.lblSelectItemTypeBasic.Location = New System.Drawing.Point(500, 271)
        Me.lblSelectItemTypeBasic.Name = "lblSelectItemTypeBasic"
        Me.lblSelectItemTypeBasic.Size = New System.Drawing.Size(214, 40)
        Me.lblSelectItemTypeBasic.TabIndex = 26
        Me.lblSelectItemTypeBasic.Text = "Select the  type of the items  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in the ID textbox"
        '
        'lblSelectItemIDBasic
        '
        Me.lblSelectItemIDBasic.AutoSize = True
        Me.lblSelectItemIDBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectItemIDBasic.ForeColor = System.Drawing.Color.Red
        Me.lblSelectItemIDBasic.Location = New System.Drawing.Point(201, 280)
        Me.lblSelectItemIDBasic.Name = "lblSelectItemIDBasic"
        Me.lblSelectItemIDBasic.Size = New System.Drawing.Size(149, 20)
        Me.lblSelectItemIDBasic.TabIndex = 25
        Me.lblSelectItemIDBasic.Text = "Enter Item IDs here"
        '
        'lblDescriptionAddItemsBasic
        '
        Me.lblDescriptionAddItemsBasic.AutoSize = True
        Me.lblDescriptionAddItemsBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescriptionAddItemsBasic.Location = New System.Drawing.Point(25, 552)
        Me.lblDescriptionAddItemsBasic.Name = "lblDescriptionAddItemsBasic"
        Me.lblDescriptionAddItemsBasic.Size = New System.Drawing.Size(729, 192)
        Me.lblDescriptionAddItemsBasic.TabIndex = 24
        Me.lblDescriptionAddItemsBasic.Text = resources.GetString("lblDescriptionAddItemsBasic.Text")
        '
        'lblLastEditedAddingItemsBasic
        '
        Me.lblLastEditedAddingItemsBasic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastEditedAddingItemsBasic.AutoSize = True
        Me.lblLastEditedAddingItemsBasic.Location = New System.Drawing.Point(629, 797)
        Me.lblLastEditedAddingItemsBasic.Name = "lblLastEditedAddingItemsBasic"
        Me.lblLastEditedAddingItemsBasic.Size = New System.Drawing.Size(141, 16)
        Me.lblLastEditedAddingItemsBasic.TabIndex = 22
        Me.lblLastEditedAddingItemsBasic.Text = "Last edited: 25.10.2022"
        '
        'lblWhatIsTheFastWayBasic
        '
        Me.lblWhatIsTheFastWayBasic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblWhatIsTheFastWayBasic.AutoSize = True
        Me.lblWhatIsTheFastWayBasic.Location = New System.Drawing.Point(180, 797)
        Me.lblWhatIsTheFastWayBasic.Name = "lblWhatIsTheFastWayBasic"
        Me.lblWhatIsTheFastWayBasic.Size = New System.Drawing.Size(136, 16)
        Me.lblWhatIsTheFastWayBasic.TabIndex = 21
        Me.lblWhatIsTheFastWayBasic.TabStop = True
        Me.lblWhatIsTheFastWayBasic.Text = "What is the 'fast way'?"
        '
        'llblHowToFindTheItemIDBasic
        '
        Me.llblHowToFindTheItemIDBasic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llblHowToFindTheItemIDBasic.AutoSize = True
        Me.llblHowToFindTheItemIDBasic.Location = New System.Drawing.Point(18, 797)
        Me.llblHowToFindTheItemIDBasic.Name = "llblHowToFindTheItemIDBasic"
        Me.llblHowToFindTheItemIDBasic.Size = New System.Drawing.Size(144, 16)
        Me.llblHowToFindTheItemIDBasic.TabIndex = 20
        Me.llblHowToFindTheItemIDBasic.TabStop = True
        Me.llblHowToFindTheItemIDBasic.Text = "How to find the item ID?"
        '
        'pbAddItemsBasic
        '
        Me.pbAddItemsBasic.BackgroundImage = CType(resources.GetObject("pbAddItemsBasic.BackgroundImage"), System.Drawing.Image)
        Me.pbAddItemsBasic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbAddItemsBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbAddItemsBasic.Location = New System.Drawing.Point(64, 6)
        Me.pbAddItemsBasic.Name = "pbAddItemsBasic"
        Me.pbAddItemsBasic.Size = New System.Drawing.Size(667, 523)
        Me.pbAddItemsBasic.TabIndex = 23
        Me.pbAddItemsBasic.TabStop = False
        '
        'tpAddingItemsAdvanced
        '
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblLastEditedAddingItemsAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.llblWhatsTheFastWayAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.llblHowToFindItemIDAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblSpecifyPrefixAndNBTTagAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblAddItemsToDatapackAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.SelectItemTypeAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblSelectDatapackVersionAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblSelectDatapackFolderAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblEnterItemIDHereAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblDescriptionAddingItemsAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.pbAddingItemsAdvanced)
        Me.tpAddingItemsAdvanced.Location = New System.Drawing.Point(4, 25)
        Me.tpAddingItemsAdvanced.Name = "tpAddingItemsAdvanced"
        Me.tpAddingItemsAdvanced.Size = New System.Drawing.Size(787, 828)
        Me.tpAddingItemsAdvanced.TabIndex = 2
        Me.tpAddingItemsAdvanced.Text = "Adding Items (Advanced)"
        Me.tpAddingItemsAdvanced.UseVisualStyleBackColor = True
        '
        'lblLastEditedAddingItemsAdvanced
        '
        Me.lblLastEditedAddingItemsAdvanced.AutoSize = True
        Me.lblLastEditedAddingItemsAdvanced.Location = New System.Drawing.Point(629, 794)
        Me.lblLastEditedAddingItemsAdvanced.Name = "lblLastEditedAddingItemsAdvanced"
        Me.lblLastEditedAddingItemsAdvanced.Size = New System.Drawing.Size(141, 16)
        Me.lblLastEditedAddingItemsAdvanced.TabIndex = 21
        Me.lblLastEditedAddingItemsAdvanced.Text = "Last edited: 24.10.2022"
        '
        'llblWhatsTheFastWayAdvanced
        '
        Me.llblWhatsTheFastWayAdvanced.AutoSize = True
        Me.llblWhatsTheFastWayAdvanced.Location = New System.Drawing.Point(189, 794)
        Me.llblWhatsTheFastWayAdvanced.Name = "llblWhatsTheFastWayAdvanced"
        Me.llblWhatsTheFastWayAdvanced.Size = New System.Drawing.Size(136, 16)
        Me.llblWhatsTheFastWayAdvanced.TabIndex = 20
        Me.llblWhatsTheFastWayAdvanced.TabStop = True
        Me.llblWhatsTheFastWayAdvanced.Text = "What is the 'fast way'?"
        '
        'llblHowToFindItemIDAdvanced
        '
        Me.llblHowToFindItemIDAdvanced.AutoSize = True
        Me.llblHowToFindItemIDAdvanced.Location = New System.Drawing.Point(16, 794)
        Me.llblHowToFindItemIDAdvanced.Name = "llblHowToFindItemIDAdvanced"
        Me.llblHowToFindItemIDAdvanced.Size = New System.Drawing.Size(144, 16)
        Me.llblHowToFindItemIDAdvanced.TabIndex = 19
        Me.llblHowToFindItemIDAdvanced.TabStop = True
        Me.llblHowToFindItemIDAdvanced.Text = "How to find the item ID?"
        '
        'lblSpecifyPrefixAndNBTTagAdvanced
        '
        Me.lblSpecifyPrefixAndNBTTagAdvanced.AutoSize = True
        Me.lblSpecifyPrefixAndNBTTagAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpecifyPrefixAndNBTTagAdvanced.ForeColor = System.Drawing.Color.Red
        Me.lblSpecifyPrefixAndNBTTagAdvanced.Location = New System.Drawing.Point(114, 344)
        Me.lblSpecifyPrefixAndNBTTagAdvanced.Name = "lblSpecifyPrefixAndNBTTagAdvanced"
        Me.lblSpecifyPrefixAndNBTTagAdvanced.Size = New System.Drawing.Size(196, 20)
        Me.lblSpecifyPrefixAndNBTTagAdvanced.TabIndex = 18
        Me.lblSpecifyPrefixAndNBTTagAdvanced.Text = "Specify prefix and NBT tag"
        '
        'lblAddItemsToDatapackAdvanced
        '
        Me.lblAddItemsToDatapackAdvanced.AutoSize = True
        Me.lblAddItemsToDatapackAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddItemsToDatapackAdvanced.ForeColor = System.Drawing.Color.Red
        Me.lblAddItemsToDatapackAdvanced.Location = New System.Drawing.Point(205, 502)
        Me.lblAddItemsToDatapackAdvanced.Name = "lblAddItemsToDatapackAdvanced"
        Me.lblAddItemsToDatapackAdvanced.Size = New System.Drawing.Size(222, 20)
        Me.lblAddItemsToDatapackAdvanced.TabIndex = 17
        Me.lblAddItemsToDatapackAdvanced.Text = "Add the items to the datapack"
        '
        'SelectItemTypeAdvanced
        '
        Me.SelectItemTypeAdvanced.AutoSize = True
        Me.SelectItemTypeAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectItemTypeAdvanced.ForeColor = System.Drawing.Color.Red
        Me.SelectItemTypeAdvanced.Location = New System.Drawing.Point(401, 288)
        Me.SelectItemTypeAdvanced.Name = "SelectItemTypeAdvanced"
        Me.SelectItemTypeAdvanced.Size = New System.Drawing.Size(214, 40)
        Me.SelectItemTypeAdvanced.TabIndex = 16
        Me.SelectItemTypeAdvanced.Text = "Select the  type of the items  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "in the ID textbox"
        '
        'lblSelectDatapackVersionAdvanced
        '
        Me.lblSelectDatapackVersionAdvanced.AutoSize = True
        Me.lblSelectDatapackVersionAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectDatapackVersionAdvanced.ForeColor = System.Drawing.Color.Red
        Me.lblSelectDatapackVersionAdvanced.Location = New System.Drawing.Point(168, 135)
        Me.lblSelectDatapackVersionAdvanced.Name = "lblSelectDatapackVersionAdvanced"
        Me.lblSelectDatapackVersionAdvanced.Size = New System.Drawing.Size(185, 20)
        Me.lblSelectDatapackVersionAdvanced.TabIndex = 15
        Me.lblSelectDatapackVersionAdvanced.Text = "Select Datapack Version"
        '
        'lblSelectDatapackFolderAdvanced
        '
        Me.lblSelectDatapackFolderAdvanced.AutoSize = True
        Me.lblSelectDatapackFolderAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectDatapackFolderAdvanced.ForeColor = System.Drawing.Color.Red
        Me.lblSelectDatapackFolderAdvanced.Location = New System.Drawing.Point(240, 87)
        Me.lblSelectDatapackFolderAdvanced.Name = "lblSelectDatapackFolderAdvanced"
        Me.lblSelectDatapackFolderAdvanced.Size = New System.Drawing.Size(168, 20)
        Me.lblSelectDatapackFolderAdvanced.TabIndex = 14
        Me.lblSelectDatapackFolderAdvanced.Text = "Select datapack folder"
        '
        'lblEnterItemIDHereAdvanced
        '
        Me.lblEnterItemIDHereAdvanced.AutoSize = True
        Me.lblEnterItemIDHereAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnterItemIDHereAdvanced.ForeColor = System.Drawing.Color.Red
        Me.lblEnterItemIDHereAdvanced.Location = New System.Drawing.Point(139, 258)
        Me.lblEnterItemIDHereAdvanced.Name = "lblEnterItemIDHereAdvanced"
        Me.lblEnterItemIDHereAdvanced.Size = New System.Drawing.Size(149, 20)
        Me.lblEnterItemIDHereAdvanced.TabIndex = 13
        Me.lblEnterItemIDHereAdvanced.Text = "Enter Item IDs here"
        '
        'lblDescriptionAddingItemsAdvanced
        '
        Me.lblDescriptionAddingItemsAdvanced.AutoSize = True
        Me.lblDescriptionAddingItemsAdvanced.Location = New System.Drawing.Point(16, 560)
        Me.lblDescriptionAddingItemsAdvanced.Name = "lblDescriptionAddingItemsAdvanced"
        Me.lblDescriptionAddingItemsAdvanced.Size = New System.Drawing.Size(754, 224)
        Me.lblDescriptionAddingItemsAdvanced.TabIndex = 12
        Me.lblDescriptionAddingItemsAdvanced.Text = resources.GetString("lblDescriptionAddingItemsAdvanced.Text")
        '
        'pbAddingItemsAdvanced
        '
        Me.pbAddingItemsAdvanced.BackgroundImage = CType(resources.GetObject("pbAddingItemsAdvanced.BackgroundImage"), System.Drawing.Image)
        Me.pbAddingItemsAdvanced.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbAddingItemsAdvanced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbAddingItemsAdvanced.Location = New System.Drawing.Point(76, 14)
        Me.pbAddingItemsAdvanced.Name = "pbAddingItemsAdvanced"
        Me.pbAddingItemsAdvanced.Size = New System.Drawing.Size(610, 523)
        Me.pbAddingItemsAdvanced.TabIndex = 11
        Me.pbAddingItemsAdvanced.TabStop = False
        '
        'tpDuplicateFinder
        '
        Me.tpDuplicateFinder.Controls.Add(Me.Label5)
        Me.tpDuplicateFinder.Controls.Add(Me.Label4)
        Me.tpDuplicateFinder.Controls.Add(Me.Label3)
        Me.tpDuplicateFinder.Controls.Add(Me.Label2)
        Me.tpDuplicateFinder.Controls.Add(Me.Label1)
        Me.tpDuplicateFinder.Controls.Add(Me.pbDuplicateFinder)
        Me.tpDuplicateFinder.Location = New System.Drawing.Point(4, 25)
        Me.tpDuplicateFinder.Name = "tpDuplicateFinder"
        Me.tpDuplicateFinder.Size = New System.Drawing.Size(787, 828)
        Me.tpDuplicateFinder.TabIndex = 3
        Me.tpDuplicateFinder.Text = "Duplicate Finder"
        Me.tpDuplicateFinder.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(323, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 20)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Begin checking"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(634, 798)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 16)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Last edited: 24.10.2022"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(92, 498)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(595, 112)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = resources.GetString("Label3.Text")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(253, 94)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Choose datapack"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(302, 254)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 100)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Here you will see a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " list of the duplicates." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "It shows both the item" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ID and l" &
    "oot table."
        '
        'pbDuplicateFinder
        '
        Me.pbDuplicateFinder.BackgroundImage = CType(resources.GetObject("pbDuplicateFinder.BackgroundImage"), System.Drawing.Image)
        Me.pbDuplicateFinder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbDuplicateFinder.Location = New System.Drawing.Point(129, 16)
        Me.pbDuplicateFinder.Name = "pbDuplicateFinder"
        Me.pbDuplicateFinder.Size = New System.Drawing.Size(511, 451)
        Me.pbDuplicateFinder.TabIndex = 0
        Me.pbDuplicateFinder.TabStop = False
        '
        'tpProfilesAndSchemes
        '
        Me.tpProfilesAndSchemes.Controls.Add(Me.lblLastEditedProfilesAndSchemes)
        Me.tpProfilesAndSchemes.Controls.Add(Me.Label6)
        Me.tpProfilesAndSchemes.Location = New System.Drawing.Point(4, 25)
        Me.tpProfilesAndSchemes.Name = "tpProfilesAndSchemes"
        Me.tpProfilesAndSchemes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProfilesAndSchemes.Size = New System.Drawing.Size(787, 828)
        Me.tpProfilesAndSchemes.TabIndex = 5
        Me.tpProfilesAndSchemes.Text = "Profiles and Schemes"
        Me.tpProfilesAndSchemes.UseVisualStyleBackColor = True
        '
        'lblLastEditedProfilesAndSchemes
        '
        Me.lblLastEditedProfilesAndSchemes.AutoSize = True
        Me.lblLastEditedProfilesAndSchemes.Location = New System.Drawing.Point(623, 798)
        Me.lblLastEditedProfilesAndSchemes.Name = "lblLastEditedProfilesAndSchemes"
        Me.lblLastEditedProfilesAndSchemes.Size = New System.Drawing.Size(141, 16)
        Me.lblLastEditedProfilesAndSchemes.TabIndex = 23
        Me.lblLastEditedProfilesAndSchemes.Text = "Last edited: 01.11.2022"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(741, 224)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = resources.GetString("Label6.Text")
        '
        'tpOther
        '
        Me.tpOther.Controls.Add(Me.lblLastEditedOther)
        Me.tpOther.Controls.Add(Me.llblTellMe)
        Me.tpOther.Controls.Add(Me.llblOtherDiscord)
        Me.tpOther.Controls.Add(Me.llblDatapackGithub)
        Me.tpOther.Controls.Add(Me.llblDatapackPMC)
        Me.tpOther.Controls.Add(Me.llblSoftwareGithub)
        Me.tpOther.Controls.Add(Me.lblOther)
        Me.tpOther.Location = New System.Drawing.Point(4, 25)
        Me.tpOther.Name = "tpOther"
        Me.tpOther.Size = New System.Drawing.Size(787, 828)
        Me.tpOther.TabIndex = 6
        Me.tpOther.Text = "Other"
        Me.tpOther.UseVisualStyleBackColor = True
        '
        'lblLastEditedOther
        '
        Me.lblLastEditedOther.AutoSize = True
        Me.lblLastEditedOther.Location = New System.Drawing.Point(637, 798)
        Me.lblLastEditedOther.Name = "lblLastEditedOther"
        Me.lblLastEditedOther.Size = New System.Drawing.Size(141, 16)
        Me.lblLastEditedOther.TabIndex = 24
        Me.lblLastEditedOther.Text = "Last edited: 01.11.2022"
        '
        'llblTellMe
        '
        Me.llblTellMe.AutoSize = True
        Me.llblTellMe.Location = New System.Drawing.Point(15, 798)
        Me.llblTellMe.Name = "llblTellMe"
        Me.llblTellMe.Size = New System.Drawing.Size(171, 16)
        Me.llblTellMe.TabIndex = 5
        Me.llblTellMe.TabStop = True
        Me.llblTellMe.Text = "TellMe Mod on CurseForge"
        '
        'llblOtherDiscord
        '
        Me.llblOtherDiscord.AutoSize = True
        Me.llblOtherDiscord.Location = New System.Drawing.Point(12, 394)
        Me.llblOtherDiscord.Name = "llblOtherDiscord"
        Me.llblOtherDiscord.Size = New System.Drawing.Size(250, 16)
        Me.llblOtherDiscord.TabIndex = 4
        Me.llblOtherDiscord.TabStop = True
        Me.llblOtherDiscord.Text = "Join the Louis9 Datapack Discord Server"
        '
        'llblDatapackGithub
        '
        Me.llblDatapackGithub.AutoSize = True
        Me.llblDatapackGithub.Location = New System.Drawing.Point(12, 262)
        Me.llblDatapackGithub.Name = "llblDatapackGithub"
        Me.llblDatapackGithub.Size = New System.Drawing.Size(181, 16)
        Me.llblDatapackGithub.TabIndex = 3
        Me.llblDatapackGithub.TabStop = True
        Me.llblDatapackGithub.Text = "Random Item Giver on Github"
        '
        'llblDatapackPMC
        '
        Me.llblDatapackPMC.AutoSize = True
        Me.llblDatapackPMC.Location = New System.Drawing.Point(12, 236)
        Me.llblDatapackPMC.Name = "llblDatapackPMC"
        Me.llblDatapackPMC.Size = New System.Drawing.Size(238, 16)
        Me.llblDatapackPMC.TabIndex = 2
        Me.llblDatapackPMC.TabStop = True
        Me.llblDatapackPMC.Text = "Random Item Giver on Planet Minecraft"
        '
        'llblSoftwareGithub
        '
        Me.llblSoftwareGithub.AutoSize = True
        Me.llblSoftwareGithub.Location = New System.Drawing.Point(12, 184)
        Me.llblSoftwareGithub.Name = "llblSoftwareGithub"
        Me.llblSoftwareGithub.Size = New System.Drawing.Size(233, 16)
        Me.llblSoftwareGithub.TabIndex = 1
        Me.llblSoftwareGithub.TabStop = True
        Me.llblSoftwareGithub.Text = "Random Item Giver Updater on Github"
        '
        'lblOther
        '
        Me.lblOther.AutoSize = True
        Me.lblOther.Location = New System.Drawing.Point(12, 16)
        Me.lblOther.Name = "lblOther"
        Me.lblOther.Size = New System.Drawing.Size(766, 368)
        Me.lblOther.TabIndex = 0
        Me.lblOther.Text = resources.GetString("lblOther.Text")
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(13, 13)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(183, 24)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Text = "Help Documentary"
        '
        'frmHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(819, 917)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.tcHelp)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmHelp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Help Documentary"
        Me.tcHelp.ResumeLayout(False)
        Me.tpIntroduction.ResumeLayout(False)
        Me.tpIntroduction.PerformLayout()
        Me.tpSimpleOverview.ResumeLayout(False)
        Me.tpSimpleOverview.PerformLayout()
        Me.tpAddingItemsBasic.ResumeLayout(False)
        Me.tpAddingItemsBasic.PerformLayout()
        CType(Me.pbAddItemsBasic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAddingItemsAdvanced.ResumeLayout(False)
        Me.tpAddingItemsAdvanced.PerformLayout()
        CType(Me.pbAddingItemsAdvanced, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDuplicateFinder.ResumeLayout(False)
        Me.tpDuplicateFinder.PerformLayout()
        CType(Me.pbDuplicateFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpProfilesAndSchemes.ResumeLayout(False)
        Me.tpProfilesAndSchemes.PerformLayout()
        Me.tpOther.ResumeLayout(False)
        Me.tpOther.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tcHelp As TabControl
    Friend WithEvents tpIntroduction As TabPage
    Friend WithEvents tpAddingItemsBasic As TabPage
    Friend WithEvents lblHeader As Label
    Friend WithEvents tpAddingItemsAdvanced As TabPage
    Friend WithEvents tpSimpleOverview As TabPage
    Friend WithEvents tpDuplicateFinder As TabPage
    Friend WithEvents tpProfilesAndSchemes As TabPage
    Friend WithEvents tpOther As TabPage
    Friend WithEvents lblIntroduction As Label
    Friend WithEvents llblRIGPMC As LinkLabel
    Friend WithEvents llblRIGGithub As LinkLabel
    Friend WithEvents lblSimpleOverview As Label
    Friend WithEvents lblLastEditedSimpleOverview As Label
    Friend WithEvents llblDiscord As LinkLabel
    Friend WithEvents lblLastEditedIntroduction As Label
    Friend WithEvents llblHowToFindTheItemIDBasic As LinkLabel
    Friend WithEvents lblLastEditedAddingItemsAdvanced As Label
    Friend WithEvents llblWhatsTheFastWayAdvanced As LinkLabel
    Friend WithEvents llblHowToFindItemIDAdvanced As LinkLabel
    Friend WithEvents lblSpecifyPrefixAndNBTTagAdvanced As Label
    Friend WithEvents lblAddItemsToDatapackAdvanced As Label
    Friend WithEvents SelectItemTypeAdvanced As Label
    Friend WithEvents lblSelectDatapackVersionAdvanced As Label
    Friend WithEvents lblSelectDatapackFolderAdvanced As Label
    Friend WithEvents lblEnterItemIDHereAdvanced As Label
    Friend WithEvents lblDescriptionAddingItemsAdvanced As Label
    Friend WithEvents pbAddingItemsAdvanced As PictureBox
    Friend WithEvents lblWhatIsTheFastWayBasic As LinkLabel
    Friend WithEvents lblLastEditedAddingItemsBasic As Label
    Friend WithEvents lblSelectDatapackVersionBasic As Label
    Friend WithEvents lblSelectDatapackFolderBasic As Label
    Friend WithEvents lblSpecifyNBTTagBasic As Label
    Friend WithEvents lblAddItemsToDatapackBasic As Label
    Friend WithEvents lblSelectItemTypeBasic As Label
    Friend WithEvents lblSelectItemIDBasic As Label
    Friend WithEvents lblDescriptionAddItemsBasic As Label
    Friend WithEvents pbAddItemsBasic As PictureBox
    Friend WithEvents pbDuplicateFinder As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblLastEditedProfilesAndSchemes As Label
    Friend WithEvents lblOther As Label
    Friend WithEvents llblDatapackGithub As LinkLabel
    Friend WithEvents llblDatapackPMC As LinkLabel
    Friend WithEvents llblSoftwareGithub As LinkLabel
    Friend WithEvents llblTellMe As LinkLabel
    Friend WithEvents llblOtherDiscord As LinkLabel
    Friend WithEvents lblLastEditedOther As Label
End Class
