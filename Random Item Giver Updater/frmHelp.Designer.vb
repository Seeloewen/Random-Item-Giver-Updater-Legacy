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
        Me.lblLastEditedAddItemsBasic = New System.Windows.Forms.Label()
        Me.lblSelectDatapackVersionBasic = New System.Windows.Forms.Label()
        Me.lblSelectDatapackFolderBasic = New System.Windows.Forms.Label()
        Me.lblSpecifyNBTTagBasic = New System.Windows.Forms.Label()
        Me.lblAddItemsToDatapackBasic = New System.Windows.Forms.Label()
        Me.lblSelectItemTypeBasic = New System.Windows.Forms.Label()
        Me.lblSelectItemIDBasic = New System.Windows.Forms.Label()
        Me.lblDescriptionAddItemsBasic = New System.Windows.Forms.Label()
        Me.llblWhatIsTheFastWayBasic = New System.Windows.Forms.LinkLabel()
        Me.llblHowToFindTheItemIDBasic = New System.Windows.Forms.LinkLabel()
        Me.pbAddItemsBasic = New System.Windows.Forms.PictureBox()
        Me.tpAddingItemsAdvanced = New System.Windows.Forms.TabPage()
        Me.lblLastEditedAddingItemsAdvanced = New System.Windows.Forms.Label()
        Me.SelectItemTypeAdvanced = New System.Windows.Forms.Label()
        Me.lblAddItemsToDatapackAdvanced = New System.Windows.Forms.Label()
        Me.lblSpecifyPrefixAndNBTTagAdvanced = New System.Windows.Forms.Label()
        Me.llblHowToFindItemIDAdvanced = New System.Windows.Forms.LinkLabel()
        Me.lblEnterItemIDHereAdvanced = New System.Windows.Forms.Label()
        Me.lblSelectDatapackVersionAdvanced = New System.Windows.Forms.Label()
        Me.lblSelectDatapackFolderAdvanced = New System.Windows.Forms.Label()
        Me.llblWhatsTheFastWayAdvanced = New System.Windows.Forms.LinkLabel()
        Me.pbAddItemsAdvanced = New System.Windows.Forms.PictureBox()
        Me.lblDescriptionAddingItemsAdvanced = New System.Windows.Forms.Label()
        Me.tpDuplicateFinder = New System.Windows.Forms.TabPage()
        Me.lblLastEditedDuplicateFinder = New System.Windows.Forms.Label()
        Me.lblBeginChecking = New System.Windows.Forms.Label()
        Me.lblDuplicateList = New System.Windows.Forms.Label()
        Me.lblChooseDatapack = New System.Windows.Forms.Label()
        Me.pbDuplicateFinder = New System.Windows.Forms.PictureBox()
        Me.lblDescriptionDuplicateFinder = New System.Windows.Forms.Label()
        Me.tpProfilesAndSchemes = New System.Windows.Forms.TabPage()
        Me.lblLastEditedProfilesAndSchemes = New System.Windows.Forms.Label()
        Me.lblDescriptionSchemes = New System.Windows.Forms.Label()
        Me.tpOther = New System.Windows.Forms.TabPage()
        Me.lblLastEditedOther = New System.Windows.Forms.Label()
        Me.llblTellMe = New System.Windows.Forms.LinkLabel()
        Me.llblOtherDiscord = New System.Windows.Forms.LinkLabel()
        Me.llblDatapackGithub = New System.Windows.Forms.LinkLabel()
        Me.llblDatapackPMC = New System.Windows.Forms.LinkLabel()
        Me.llblSoftwareGithub = New System.Windows.Forms.LinkLabel()
        Me.lblOther = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.pnlHelp = New System.Windows.Forms.Panel()
        Me.btnNavIntroduction = New System.Windows.Forms.Button()
        Me.btnNavOther = New System.Windows.Forms.Button()
        Me.btnNavProfilesAndSchemes = New System.Windows.Forms.Button()
        Me.btnNavDuplicateFinder = New System.Windows.Forms.Button()
        Me.btnNavAddingItemsAdvanced = New System.Windows.Forms.Button()
        Me.btnNavAddingItemsBasic = New System.Windows.Forms.Button()
        Me.btnNavSimpleOverview = New System.Windows.Forms.Button()
        Me.pbNavigationBar = New System.Windows.Forms.PictureBox()
        Me.tcHelp.SuspendLayout()
        Me.tpIntroduction.SuspendLayout()
        Me.tpSimpleOverview.SuspendLayout()
        Me.tpAddingItemsBasic.SuspendLayout()
        CType(Me.pbAddItemsBasic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAddingItemsAdvanced.SuspendLayout()
        CType(Me.pbAddItemsAdvanced, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDuplicateFinder.SuspendLayout()
        CType(Me.pbDuplicateFinder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpProfilesAndSchemes.SuspendLayout()
        Me.tpOther.SuspendLayout()
        Me.pnlHelp.SuspendLayout()
        CType(Me.pbNavigationBar, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tcHelp.Location = New System.Drawing.Point(-11, 3)
        Me.tcHelp.Name = "tcHelp"
        Me.tcHelp.SelectedIndex = 0
        Me.tcHelp.Size = New System.Drawing.Size(1118, 932)
        Me.tcHelp.TabIndex = 0
        '
        'tpIntroduction
        '
        Me.tpIntroduction.BackColor = System.Drawing.Color.White
        Me.tpIntroduction.Controls.Add(Me.llblDiscord)
        Me.tpIntroduction.Controls.Add(Me.lblLastEditedIntroduction)
        Me.tpIntroduction.Controls.Add(Me.lblIntroduction)
        Me.tpIntroduction.Location = New System.Drawing.Point(4, 25)
        Me.tpIntroduction.Name = "tpIntroduction"
        Me.tpIntroduction.Padding = New System.Windows.Forms.Padding(3)
        Me.tpIntroduction.Size = New System.Drawing.Size(1110, 903)
        Me.tpIntroduction.TabIndex = 0
        Me.tpIntroduction.Text = "Introduction"
        '
        'llblDiscord
        '
        Me.llblDiscord.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llblDiscord.AutoSize = True
        Me.llblDiscord.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblDiscord.Location = New System.Drawing.Point(13, 862)
        Me.llblDiscord.Name = "llblDiscord"
        Me.llblDiscord.Size = New System.Drawing.Size(237, 20)
        Me.llblDiscord.TabIndex = 5
        Me.llblDiscord.TabStop = True
        Me.llblDiscord.Text = "Louis9 Datapack Discord Server"
        '
        'lblLastEditedIntroduction
        '
        Me.lblLastEditedIntroduction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastEditedIntroduction.AutoSize = True
        Me.lblLastEditedIntroduction.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastEditedIntroduction.Location = New System.Drawing.Point(928, 870)
        Me.lblLastEditedIntroduction.Name = "lblLastEditedIntroduction"
        Me.lblLastEditedIntroduction.Size = New System.Drawing.Size(176, 20)
        Me.lblLastEditedIntroduction.TabIndex = 4
        Me.lblLastEditedIntroduction.Text = "Last edited: 25.02.2023"
        '
        'lblIntroduction
        '
        Me.lblIntroduction.AutoSize = True
        Me.lblIntroduction.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIntroduction.Location = New System.Drawing.Point(11, 16)
        Me.lblIntroduction.Name = "lblIntroduction"
        Me.lblIntroduction.Size = New System.Drawing.Size(1075, 320)
        Me.lblIntroduction.TabIndex = 0
        Me.lblIntroduction.Text = resources.GetString("lblIntroduction.Text")
        '
        'tpSimpleOverview
        '
        Me.tpSimpleOverview.BackColor = System.Drawing.Color.White
        Me.tpSimpleOverview.Controls.Add(Me.lblLastEditedSimpleOverview)
        Me.tpSimpleOverview.Controls.Add(Me.llblRIGPMC)
        Me.tpSimpleOverview.Controls.Add(Me.llblRIGGithub)
        Me.tpSimpleOverview.Controls.Add(Me.lblSimpleOverview)
        Me.tpSimpleOverview.Location = New System.Drawing.Point(4, 25)
        Me.tpSimpleOverview.Name = "tpSimpleOverview"
        Me.tpSimpleOverview.Size = New System.Drawing.Size(1110, 903)
        Me.tpSimpleOverview.TabIndex = 4
        Me.tpSimpleOverview.Text = "Simple Overview"
        '
        'lblLastEditedSimpleOverview
        '
        Me.lblLastEditedSimpleOverview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastEditedSimpleOverview.AutoSize = True
        Me.lblLastEditedSimpleOverview.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastEditedSimpleOverview.Location = New System.Drawing.Point(920, 870)
        Me.lblLastEditedSimpleOverview.Name = "lblLastEditedSimpleOverview"
        Me.lblLastEditedSimpleOverview.Size = New System.Drawing.Size(176, 20)
        Me.lblLastEditedSimpleOverview.TabIndex = 3
        Me.lblLastEditedSimpleOverview.Text = "Last edited: 25.02.2023"
        '
        'llblRIGPMC
        '
        Me.llblRIGPMC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llblRIGPMC.AutoSize = True
        Me.llblRIGPMC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblRIGPMC.Location = New System.Drawing.Point(14, 845)
        Me.llblRIGPMC.Name = "llblRIGPMC"
        Me.llblRIGPMC.Size = New System.Drawing.Size(361, 20)
        Me.llblRIGPMC.TabIndex = 2
        Me.llblRIGPMC.TabStop = True
        Me.llblRIGPMC.Text = "Random Item Giver Datapack on Planet Minecraft"
        '
        'llblRIGGithub
        '
        Me.llblRIGGithub.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llblRIGGithub.AutoSize = True
        Me.llblRIGGithub.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblRIGGithub.Location = New System.Drawing.Point(14, 870)
        Me.llblRIGGithub.Name = "llblRIGGithub"
        Me.llblRIGGithub.Size = New System.Drawing.Size(297, 20)
        Me.llblRIGGithub.TabIndex = 1
        Me.llblRIGGithub.TabStop = True
        Me.llblRIGGithub.Text = "Random Item Giver Datapack on GitHub"
        '
        'lblSimpleOverview
        '
        Me.lblSimpleOverview.AutoSize = True
        Me.lblSimpleOverview.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSimpleOverview.Location = New System.Drawing.Point(15, 13)
        Me.lblSimpleOverview.Name = "lblSimpleOverview"
        Me.lblSimpleOverview.Size = New System.Drawing.Size(1106, 300)
        Me.lblSimpleOverview.TabIndex = 0
        Me.lblSimpleOverview.Text = resources.GetString("lblSimpleOverview.Text")
        '
        'tpAddingItemsBasic
        '
        Me.tpAddingItemsBasic.AutoScroll = True
        Me.tpAddingItemsBasic.BackColor = System.Drawing.Color.White
        Me.tpAddingItemsBasic.Controls.Add(Me.lblLastEditedAddItemsBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblSelectDatapackVersionBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblSelectDatapackFolderBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblSpecifyNBTTagBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblAddItemsToDatapackBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblSelectItemTypeBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblSelectItemIDBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.lblDescriptionAddItemsBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.llblWhatIsTheFastWayBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.llblHowToFindTheItemIDBasic)
        Me.tpAddingItemsBasic.Controls.Add(Me.pbAddItemsBasic)
        Me.tpAddingItemsBasic.Location = New System.Drawing.Point(4, 25)
        Me.tpAddingItemsBasic.Name = "tpAddingItemsBasic"
        Me.tpAddingItemsBasic.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAddingItemsBasic.Size = New System.Drawing.Size(1110, 903)
        Me.tpAddingItemsBasic.TabIndex = 1
        Me.tpAddingItemsBasic.Text = "Adding Items (Basic)"
        '
        'lblLastEditedAddItemsBasic
        '
        Me.lblLastEditedAddItemsBasic.AutoSize = True
        Me.lblLastEditedAddItemsBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastEditedAddItemsBasic.ForeColor = System.Drawing.Color.Black
        Me.lblLastEditedAddItemsBasic.Location = New System.Drawing.Point(929, 869)
        Me.lblLastEditedAddItemsBasic.Name = "lblLastEditedAddItemsBasic"
        Me.lblLastEditedAddItemsBasic.Size = New System.Drawing.Size(176, 20)
        Me.lblLastEditedAddItemsBasic.TabIndex = 31
        Me.lblLastEditedAddItemsBasic.Text = "Last edited: 25.02.2023"
        '
        'lblSelectDatapackVersionBasic
        '
        Me.lblSelectDatapackVersionBasic.AutoSize = True
        Me.lblSelectDatapackVersionBasic.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblSelectDatapackVersionBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectDatapackVersionBasic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSelectDatapackVersionBasic.Location = New System.Drawing.Point(342, 203)
        Me.lblSelectDatapackVersionBasic.Name = "lblSelectDatapackVersionBasic"
        Me.lblSelectDatapackVersionBasic.Size = New System.Drawing.Size(185, 20)
        Me.lblSelectDatapackVersionBasic.TabIndex = 30
        Me.lblSelectDatapackVersionBasic.Text = "Select Datapack Version"
        '
        'lblSelectDatapackFolderBasic
        '
        Me.lblSelectDatapackFolderBasic.AutoSize = True
        Me.lblSelectDatapackFolderBasic.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblSelectDatapackFolderBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectDatapackFolderBasic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSelectDatapackFolderBasic.Location = New System.Drawing.Point(385, 151)
        Me.lblSelectDatapackFolderBasic.Name = "lblSelectDatapackFolderBasic"
        Me.lblSelectDatapackFolderBasic.Size = New System.Drawing.Size(168, 20)
        Me.lblSelectDatapackFolderBasic.TabIndex = 29
        Me.lblSelectDatapackFolderBasic.Text = "Select datapack folder"
        '
        'lblSpecifyNBTTagBasic
        '
        Me.lblSpecifyNBTTagBasic.AutoSize = True
        Me.lblSpecifyNBTTagBasic.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblSpecifyNBTTagBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpecifyNBTTagBasic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSpecifyNBTTagBasic.Location = New System.Drawing.Point(331, 479)
        Me.lblSpecifyNBTTagBasic.Name = "lblSpecifyNBTTagBasic"
        Me.lblSpecifyNBTTagBasic.Size = New System.Drawing.Size(123, 20)
        Me.lblSpecifyNBTTagBasic.TabIndex = 28
        Me.lblSpecifyNBTTagBasic.Text = "Specify NBT tag"
        '
        'lblAddItemsToDatapackBasic
        '
        Me.lblAddItemsToDatapackBasic.AutoSize = True
        Me.lblAddItemsToDatapackBasic.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.lblAddItemsToDatapackBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddItemsToDatapackBasic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAddItemsToDatapackBasic.Location = New System.Drawing.Point(578, 555)
        Me.lblAddItemsToDatapackBasic.Name = "lblAddItemsToDatapackBasic"
        Me.lblAddItemsToDatapackBasic.Size = New System.Drawing.Size(222, 20)
        Me.lblAddItemsToDatapackBasic.TabIndex = 27
        Me.lblAddItemsToDatapackBasic.Text = "Add the items to the datapack"
        '
        'lblSelectItemTypeBasic
        '
        Me.lblSelectItemTypeBasic.AutoSize = True
        Me.lblSelectItemTypeBasic.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblSelectItemTypeBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectItemTypeBasic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSelectItemTypeBasic.Location = New System.Drawing.Point(685, 289)
        Me.lblSelectItemTypeBasic.Name = "lblSelectItemTypeBasic"
        Me.lblSelectItemTypeBasic.Size = New System.Drawing.Size(115, 40)
        Me.lblSelectItemTypeBasic.TabIndex = 26
        Me.lblSelectItemTypeBasic.Text = "Select the type" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " of the items "
        '
        'lblSelectItemIDBasic
        '
        Me.lblSelectItemIDBasic.AutoSize = True
        Me.lblSelectItemIDBasic.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblSelectItemIDBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectItemIDBasic.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSelectItemIDBasic.Location = New System.Drawing.Point(385, 375)
        Me.lblSelectItemIDBasic.Name = "lblSelectItemIDBasic"
        Me.lblSelectItemIDBasic.Size = New System.Drawing.Size(149, 20)
        Me.lblSelectItemIDBasic.TabIndex = 25
        Me.lblSelectItemIDBasic.Text = "Enter Item IDs here"
        '
        'lblDescriptionAddItemsBasic
        '
        Me.lblDescriptionAddItemsBasic.AutoSize = True
        Me.lblDescriptionAddItemsBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescriptionAddItemsBasic.Location = New System.Drawing.Point(5, 613)
        Me.lblDescriptionAddItemsBasic.Name = "lblDescriptionAddItemsBasic"
        Me.lblDescriptionAddItemsBasic.Size = New System.Drawing.Size(1102, 220)
        Me.lblDescriptionAddItemsBasic.TabIndex = 24
        Me.lblDescriptionAddItemsBasic.Text = resources.GetString("lblDescriptionAddItemsBasic.Text")
        '
        'llblWhatIsTheFastWayBasic
        '
        Me.llblWhatIsTheFastWayBasic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llblWhatIsTheFastWayBasic.AutoSize = True
        Me.llblWhatIsTheFastWayBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblWhatIsTheFastWayBasic.Location = New System.Drawing.Point(192, 870)
        Me.llblWhatIsTheFastWayBasic.Name = "llblWhatIsTheFastWayBasic"
        Me.llblWhatIsTheFastWayBasic.Size = New System.Drawing.Size(166, 20)
        Me.llblWhatIsTheFastWayBasic.TabIndex = 21
        Me.llblWhatIsTheFastWayBasic.TabStop = True
        Me.llblWhatIsTheFastWayBasic.Text = "What is the 'fast way'?"
        '
        'llblHowToFindTheItemIDBasic
        '
        Me.llblHowToFindTheItemIDBasic.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.llblHowToFindTheItemIDBasic.AutoSize = True
        Me.llblHowToFindTheItemIDBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblHowToFindTheItemIDBasic.Location = New System.Drawing.Point(6, 870)
        Me.llblHowToFindTheItemIDBasic.Name = "llblHowToFindTheItemIDBasic"
        Me.llblHowToFindTheItemIDBasic.Size = New System.Drawing.Size(180, 20)
        Me.llblHowToFindTheItemIDBasic.TabIndex = 20
        Me.llblHowToFindTheItemIDBasic.TabStop = True
        Me.llblHowToFindTheItemIDBasic.Text = "How to find the item ID?"
        '
        'pbAddItemsBasic
        '
        Me.pbAddItemsBasic.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgAddingItemsBasic
        Me.pbAddItemsBasic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbAddItemsBasic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbAddItemsBasic.Location = New System.Drawing.Point(251, 17)
        Me.pbAddItemsBasic.Name = "pbAddItemsBasic"
        Me.pbAddItemsBasic.Size = New System.Drawing.Size(616, 571)
        Me.pbAddItemsBasic.TabIndex = 23
        Me.pbAddItemsBasic.TabStop = False
        '
        'tpAddingItemsAdvanced
        '
        Me.tpAddingItemsAdvanced.BackColor = System.Drawing.Color.White
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblLastEditedAddingItemsAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.SelectItemTypeAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblAddItemsToDatapackAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblSpecifyPrefixAndNBTTagAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.llblHowToFindItemIDAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblEnterItemIDHereAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblSelectDatapackVersionAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblSelectDatapackFolderAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.llblWhatsTheFastWayAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.pbAddItemsAdvanced)
        Me.tpAddingItemsAdvanced.Controls.Add(Me.lblDescriptionAddingItemsAdvanced)
        Me.tpAddingItemsAdvanced.ForeColor = System.Drawing.Color.Black
        Me.tpAddingItemsAdvanced.Location = New System.Drawing.Point(4, 25)
        Me.tpAddingItemsAdvanced.Name = "tpAddingItemsAdvanced"
        Me.tpAddingItemsAdvanced.Size = New System.Drawing.Size(1110, 903)
        Me.tpAddingItemsAdvanced.TabIndex = 2
        Me.tpAddingItemsAdvanced.Text = "Adding Items (Advanced)"
        '
        'lblLastEditedAddingItemsAdvanced
        '
        Me.lblLastEditedAddingItemsAdvanced.AutoSize = True
        Me.lblLastEditedAddingItemsAdvanced.BackColor = System.Drawing.Color.White
        Me.lblLastEditedAddingItemsAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastEditedAddingItemsAdvanced.Location = New System.Drawing.Point(929, 882)
        Me.lblLastEditedAddingItemsAdvanced.Name = "lblLastEditedAddingItemsAdvanced"
        Me.lblLastEditedAddingItemsAdvanced.Size = New System.Drawing.Size(176, 20)
        Me.lblLastEditedAddingItemsAdvanced.TabIndex = 33
        Me.lblLastEditedAddingItemsAdvanced.Text = "Last edited: 25.02.2023"
        '
        'SelectItemTypeAdvanced
        '
        Me.SelectItemTypeAdvanced.AutoSize = True
        Me.SelectItemTypeAdvanced.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.SelectItemTypeAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SelectItemTypeAdvanced.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.SelectItemTypeAdvanced.Location = New System.Drawing.Point(572, 357)
        Me.SelectItemTypeAdvanced.Name = "SelectItemTypeAdvanced"
        Me.SelectItemTypeAdvanced.Size = New System.Drawing.Size(119, 40)
        Me.SelectItemTypeAdvanced.TabIndex = 27
        Me.SelectItemTypeAdvanced.Text = "Select the type " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "of the items"
        '
        'lblAddItemsToDatapackAdvanced
        '
        Me.lblAddItemsToDatapackAdvanced.AutoSize = True
        Me.lblAddItemsToDatapackAdvanced.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.lblAddItemsToDatapackAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddItemsToDatapackAdvanced.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblAddItemsToDatapackAdvanced.Location = New System.Drawing.Point(572, 585)
        Me.lblAddItemsToDatapackAdvanced.Name = "lblAddItemsToDatapackAdvanced"
        Me.lblAddItemsToDatapackAdvanced.Size = New System.Drawing.Size(222, 20)
        Me.lblAddItemsToDatapackAdvanced.TabIndex = 28
        Me.lblAddItemsToDatapackAdvanced.Text = "Add the items to the datapack"
        '
        'lblSpecifyPrefixAndNBTTagAdvanced
        '
        Me.lblSpecifyPrefixAndNBTTagAdvanced.AutoSize = True
        Me.lblSpecifyPrefixAndNBTTagAdvanced.BackColor = System.Drawing.Color.FromArgb(CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer), CType(CType(127, Byte), Integer))
        Me.lblSpecifyPrefixAndNBTTagAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpecifyPrefixAndNBTTagAdvanced.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSpecifyPrefixAndNBTTagAdvanced.Location = New System.Drawing.Point(287, 451)
        Me.lblSpecifyPrefixAndNBTTagAdvanced.Name = "lblSpecifyPrefixAndNBTTagAdvanced"
        Me.lblSpecifyPrefixAndNBTTagAdvanced.Size = New System.Drawing.Size(196, 20)
        Me.lblSpecifyPrefixAndNBTTagAdvanced.TabIndex = 29
        Me.lblSpecifyPrefixAndNBTTagAdvanced.Text = "Specify prefix and NBT tag"
        '
        'llblHowToFindItemIDAdvanced
        '
        Me.llblHowToFindItemIDAdvanced.AutoSize = True
        Me.llblHowToFindItemIDAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblHowToFindItemIDAdvanced.Location = New System.Drawing.Point(10, 874)
        Me.llblHowToFindItemIDAdvanced.Name = "llblHowToFindItemIDAdvanced"
        Me.llblHowToFindItemIDAdvanced.Size = New System.Drawing.Size(180, 20)
        Me.llblHowToFindItemIDAdvanced.TabIndex = 30
        Me.llblHowToFindItemIDAdvanced.TabStop = True
        Me.llblHowToFindItemIDAdvanced.Text = "How to find the item ID?"
        '
        'lblEnterItemIDHereAdvanced
        '
        Me.lblEnterItemIDHereAdvanced.AutoSize = True
        Me.lblEnterItemIDHereAdvanced.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblEnterItemIDHereAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnterItemIDHereAdvanced.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblEnterItemIDHereAdvanced.Location = New System.Drawing.Point(311, 346)
        Me.lblEnterItemIDHereAdvanced.Name = "lblEnterItemIDHereAdvanced"
        Me.lblEnterItemIDHereAdvanced.Size = New System.Drawing.Size(149, 20)
        Me.lblEnterItemIDHereAdvanced.TabIndex = 24
        Me.lblEnterItemIDHereAdvanced.Text = "Enter Item IDs here"
        '
        'lblSelectDatapackVersionAdvanced
        '
        Me.lblSelectDatapackVersionAdvanced.AutoSize = True
        Me.lblSelectDatapackVersionAdvanced.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblSelectDatapackVersionAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectDatapackVersionAdvanced.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSelectDatapackVersionAdvanced.Location = New System.Drawing.Point(321, 186)
        Me.lblSelectDatapackVersionAdvanced.Name = "lblSelectDatapackVersionAdvanced"
        Me.lblSelectDatapackVersionAdvanced.Size = New System.Drawing.Size(185, 20)
        Me.lblSelectDatapackVersionAdvanced.TabIndex = 26
        Me.lblSelectDatapackVersionAdvanced.Text = "Select Datapack Version"
        '
        'lblSelectDatapackFolderAdvanced
        '
        Me.lblSelectDatapackFolderAdvanced.AutoSize = True
        Me.lblSelectDatapackFolderAdvanced.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.lblSelectDatapackFolderAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectDatapackFolderAdvanced.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblSelectDatapackFolderAdvanced.Location = New System.Drawing.Point(403, 138)
        Me.lblSelectDatapackFolderAdvanced.Name = "lblSelectDatapackFolderAdvanced"
        Me.lblSelectDatapackFolderAdvanced.Size = New System.Drawing.Size(168, 20)
        Me.lblSelectDatapackFolderAdvanced.TabIndex = 25
        Me.lblSelectDatapackFolderAdvanced.Text = "Select datapack folder"
        '
        'llblWhatsTheFastWayAdvanced
        '
        Me.llblWhatsTheFastWayAdvanced.AutoSize = True
        Me.llblWhatsTheFastWayAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblWhatsTheFastWayAdvanced.ForeColor = System.Drawing.Color.Black
        Me.llblWhatsTheFastWayAdvanced.Location = New System.Drawing.Point(209, 874)
        Me.llblWhatsTheFastWayAdvanced.Name = "llblWhatsTheFastWayAdvanced"
        Me.llblWhatsTheFastWayAdvanced.Size = New System.Drawing.Size(166, 20)
        Me.llblWhatsTheFastWayAdvanced.TabIndex = 31
        Me.llblWhatsTheFastWayAdvanced.TabStop = True
        Me.llblWhatsTheFastWayAdvanced.Text = "What is the 'fast way'?"
        '
        'pbAddItemsAdvanced
        '
        Me.pbAddItemsAdvanced.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgAddingItemsAdvanced
        Me.pbAddItemsAdvanced.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbAddItemsAdvanced.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbAddItemsAdvanced.Location = New System.Drawing.Point(236, 20)
        Me.pbAddItemsAdvanced.Name = "pbAddItemsAdvanced"
        Me.pbAddItemsAdvanced.Size = New System.Drawing.Size(605, 596)
        Me.pbAddItemsAdvanced.TabIndex = 22
        Me.pbAddItemsAdvanced.TabStop = False
        '
        'lblDescriptionAddingItemsAdvanced
        '
        Me.lblDescriptionAddingItemsAdvanced.AutoSize = True
        Me.lblDescriptionAddingItemsAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescriptionAddingItemsAdvanced.ForeColor = System.Drawing.Color.Black
        Me.lblDescriptionAddingItemsAdvanced.Location = New System.Drawing.Point(7, 629)
        Me.lblDescriptionAddingItemsAdvanced.Name = "lblDescriptionAddingItemsAdvanced"
        Me.lblDescriptionAddingItemsAdvanced.Size = New System.Drawing.Size(1101, 240)
        Me.lblDescriptionAddingItemsAdvanced.TabIndex = 23
        Me.lblDescriptionAddingItemsAdvanced.Text = resources.GetString("lblDescriptionAddingItemsAdvanced.Text")
        '
        'tpDuplicateFinder
        '
        Me.tpDuplicateFinder.BackColor = System.Drawing.Color.White
        Me.tpDuplicateFinder.Controls.Add(Me.lblLastEditedDuplicateFinder)
        Me.tpDuplicateFinder.Controls.Add(Me.lblBeginChecking)
        Me.tpDuplicateFinder.Controls.Add(Me.lblDuplicateList)
        Me.tpDuplicateFinder.Controls.Add(Me.lblChooseDatapack)
        Me.tpDuplicateFinder.Controls.Add(Me.pbDuplicateFinder)
        Me.tpDuplicateFinder.Controls.Add(Me.lblDescriptionDuplicateFinder)
        Me.tpDuplicateFinder.Location = New System.Drawing.Point(4, 25)
        Me.tpDuplicateFinder.Name = "tpDuplicateFinder"
        Me.tpDuplicateFinder.Size = New System.Drawing.Size(1110, 903)
        Me.tpDuplicateFinder.TabIndex = 3
        Me.tpDuplicateFinder.Text = "Duplicate Finder"
        '
        'lblLastEditedDuplicateFinder
        '
        Me.lblLastEditedDuplicateFinder.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLastEditedDuplicateFinder.AutoSize = True
        Me.lblLastEditedDuplicateFinder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastEditedDuplicateFinder.Location = New System.Drawing.Point(929, 879)
        Me.lblLastEditedDuplicateFinder.Name = "lblLastEditedDuplicateFinder"
        Me.lblLastEditedDuplicateFinder.Size = New System.Drawing.Size(176, 20)
        Me.lblLastEditedDuplicateFinder.TabIndex = 29
        Me.lblLastEditedDuplicateFinder.Text = "Last edited: 25.02.2023"
        '
        'lblBeginChecking
        '
        Me.lblBeginChecking.AutoSize = True
        Me.lblBeginChecking.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.lblBeginChecking.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBeginChecking.ForeColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblBeginChecking.Location = New System.Drawing.Point(461, 149)
        Me.lblBeginChecking.Name = "lblBeginChecking"
        Me.lblBeginChecking.Size = New System.Drawing.Size(117, 20)
        Me.lblBeginChecking.TabIndex = 28
        Me.lblBeginChecking.Text = "Begin checking"
        '
        'lblDuplicateList
        '
        Me.lblDuplicateList.AutoSize = True
        Me.lblDuplicateList.BackColor = System.Drawing.Color.White
        Me.lblDuplicateList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuplicateList.ForeColor = System.Drawing.Color.Blue
        Me.lblDuplicateList.Location = New System.Drawing.Point(461, 279)
        Me.lblDuplicateList.Name = "lblDuplicateList"
        Me.lblDuplicateList.Size = New System.Drawing.Size(165, 100)
        Me.lblDuplicateList.TabIndex = 26
        Me.lblDuplicateList.Text = "Here you will see a" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " list of the duplicates." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "It shows both the item" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ID and l" &
    "oot table."
        '
        'lblChooseDatapack
        '
        Me.lblChooseDatapack.AutoSize = True
        Me.lblChooseDatapack.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lblChooseDatapack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChooseDatapack.ForeColor = System.Drawing.Color.Blue
        Me.lblChooseDatapack.Location = New System.Drawing.Point(431, 111)
        Me.lblChooseDatapack.Name = "lblChooseDatapack"
        Me.lblChooseDatapack.Size = New System.Drawing.Size(134, 20)
        Me.lblChooseDatapack.TabIndex = 27
        Me.lblChooseDatapack.Text = "Choose datapack"
        '
        'pbDuplicateFinder
        '
        Me.pbDuplicateFinder.BackColor = System.Drawing.Color.White
        Me.pbDuplicateFinder.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgDuplicateFinderHelp
        Me.pbDuplicateFinder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbDuplicateFinder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbDuplicateFinder.Location = New System.Drawing.Point(230, 18)
        Me.pbDuplicateFinder.Name = "pbDuplicateFinder"
        Me.pbDuplicateFinder.Size = New System.Drawing.Size(589, 503)
        Me.pbDuplicateFinder.TabIndex = 0
        Me.pbDuplicateFinder.TabStop = False
        '
        'lblDescriptionDuplicateFinder
        '
        Me.lblDescriptionDuplicateFinder.AutoSize = True
        Me.lblDescriptionDuplicateFinder.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescriptionDuplicateFinder.Location = New System.Drawing.Point(3, 551)
        Me.lblDescriptionDuplicateFinder.Name = "lblDescriptionDuplicateFinder"
        Me.lblDescriptionDuplicateFinder.Size = New System.Drawing.Size(1056, 120)
        Me.lblDescriptionDuplicateFinder.TabIndex = 3
        Me.lblDescriptionDuplicateFinder.Text = resources.GetString("lblDescriptionDuplicateFinder.Text")
        '
        'tpProfilesAndSchemes
        '
        Me.tpProfilesAndSchemes.BackColor = System.Drawing.Color.White
        Me.tpProfilesAndSchemes.Controls.Add(Me.lblLastEditedProfilesAndSchemes)
        Me.tpProfilesAndSchemes.Controls.Add(Me.lblDescriptionSchemes)
        Me.tpProfilesAndSchemes.Location = New System.Drawing.Point(4, 25)
        Me.tpProfilesAndSchemes.Name = "tpProfilesAndSchemes"
        Me.tpProfilesAndSchemes.Padding = New System.Windows.Forms.Padding(3)
        Me.tpProfilesAndSchemes.Size = New System.Drawing.Size(1110, 903)
        Me.tpProfilesAndSchemes.TabIndex = 5
        Me.tpProfilesAndSchemes.Text = "Profiles and Schemes"
        '
        'lblLastEditedProfilesAndSchemes
        '
        Me.lblLastEditedProfilesAndSchemes.AutoSize = True
        Me.lblLastEditedProfilesAndSchemes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastEditedProfilesAndSchemes.Location = New System.Drawing.Point(938, 879)
        Me.lblLastEditedProfilesAndSchemes.Name = "lblLastEditedProfilesAndSchemes"
        Me.lblLastEditedProfilesAndSchemes.Size = New System.Drawing.Size(176, 20)
        Me.lblLastEditedProfilesAndSchemes.TabIndex = 33
        Me.lblLastEditedProfilesAndSchemes.Text = "Last edited: 25.02.2023"
        '
        'lblDescriptionSchemes
        '
        Me.lblDescriptionSchemes.AutoSize = True
        Me.lblDescriptionSchemes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescriptionSchemes.Location = New System.Drawing.Point(3, 18)
        Me.lblDescriptionSchemes.Name = "lblDescriptionSchemes"
        Me.lblDescriptionSchemes.Size = New System.Drawing.Size(1111, 220)
        Me.lblDescriptionSchemes.TabIndex = 24
        Me.lblDescriptionSchemes.Text = resources.GetString("lblDescriptionSchemes.Text")
        '
        'tpOther
        '
        Me.tpOther.BackColor = System.Drawing.Color.White
        Me.tpOther.Controls.Add(Me.lblLastEditedOther)
        Me.tpOther.Controls.Add(Me.llblTellMe)
        Me.tpOther.Controls.Add(Me.llblOtherDiscord)
        Me.tpOther.Controls.Add(Me.llblDatapackGithub)
        Me.tpOther.Controls.Add(Me.llblDatapackPMC)
        Me.tpOther.Controls.Add(Me.llblSoftwareGithub)
        Me.tpOther.Controls.Add(Me.lblOther)
        Me.tpOther.Location = New System.Drawing.Point(4, 25)
        Me.tpOther.Name = "tpOther"
        Me.tpOther.Size = New System.Drawing.Size(1110, 903)
        Me.tpOther.TabIndex = 6
        Me.tpOther.Text = "Other"
        '
        'lblLastEditedOther
        '
        Me.lblLastEditedOther.AutoSize = True
        Me.lblLastEditedOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastEditedOther.Location = New System.Drawing.Point(929, 879)
        Me.lblLastEditedOther.Name = "lblLastEditedOther"
        Me.lblLastEditedOther.Size = New System.Drawing.Size(176, 20)
        Me.lblLastEditedOther.TabIndex = 24
        Me.lblLastEditedOther.Text = "Last edited: 25.02.2023"
        '
        'llblTellMe
        '
        Me.llblTellMe.AutoSize = True
        Me.llblTellMe.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblTellMe.Location = New System.Drawing.Point(10, 875)
        Me.llblTellMe.Name = "llblTellMe"
        Me.llblTellMe.Size = New System.Drawing.Size(200, 20)
        Me.llblTellMe.TabIndex = 5
        Me.llblTellMe.TabStop = True
        Me.llblTellMe.Text = "TellMe Mod on CurseForge"
        '
        'llblOtherDiscord
        '
        Me.llblOtherDiscord.AutoSize = True
        Me.llblOtherDiscord.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblOtherDiscord.Location = New System.Drawing.Point(14, 468)
        Me.llblOtherDiscord.Name = "llblOtherDiscord"
        Me.llblOtherDiscord.Size = New System.Drawing.Size(297, 20)
        Me.llblOtherDiscord.TabIndex = 4
        Me.llblOtherDiscord.TabStop = True
        Me.llblOtherDiscord.Text = "Join the Louis9 Datapack Discord Server"
        '
        'llblDatapackGithub
        '
        Me.llblDatapackGithub.AutoSize = True
        Me.llblDatapackGithub.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblDatapackGithub.Location = New System.Drawing.Point(14, 311)
        Me.llblDatapackGithub.Name = "llblDatapackGithub"
        Me.llblDatapackGithub.Size = New System.Drawing.Size(221, 20)
        Me.llblDatapackGithub.TabIndex = 3
        Me.llblDatapackGithub.TabStop = True
        Me.llblDatapackGithub.Text = "Random Item Giver on Github"
        '
        'llblDatapackPMC
        '
        Me.llblDatapackPMC.AutoSize = True
        Me.llblDatapackPMC.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblDatapackPMC.Location = New System.Drawing.Point(12, 282)
        Me.llblDatapackPMC.Name = "llblDatapackPMC"
        Me.llblDatapackPMC.Size = New System.Drawing.Size(288, 20)
        Me.llblDatapackPMC.TabIndex = 2
        Me.llblDatapackPMC.TabStop = True
        Me.llblDatapackPMC.Text = "Random Item Giver on Planet Minecraft"
        '
        'llblSoftwareGithub
        '
        Me.llblSoftwareGithub.AutoSize = True
        Me.llblSoftwareGithub.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblSoftwareGithub.Location = New System.Drawing.Point(12, 222)
        Me.llblSoftwareGithub.Name = "llblSoftwareGithub"
        Me.llblSoftwareGithub.Size = New System.Drawing.Size(283, 20)
        Me.llblSoftwareGithub.TabIndex = 1
        Me.llblSoftwareGithub.TabStop = True
        Me.llblSoftwareGithub.Text = "Random Item Giver Updater on Github"
        '
        'lblOther
        '
        Me.lblOther.AutoSize = True
        Me.lblOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOther.Location = New System.Drawing.Point(12, 16)
        Me.lblOther.Name = "lblOther"
        Me.lblOther.Size = New System.Drawing.Size(1111, 440)
        Me.lblOther.TabIndex = 0
        Me.lblOther.Text = resources.GetString("lblOther.Text")
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(479, 13)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(183, 24)
        Me.lblHeader.TabIndex = 1
        Me.lblHeader.Text = "Help Documentary"
        '
        'pnlHelp
        '
        Me.pnlHelp.Controls.Add(Me.tcHelp)
        Me.pnlHelp.Location = New System.Drawing.Point(21, 48)
        Me.pnlHelp.Name = "pnlHelp"
        Me.pnlHelp.Size = New System.Drawing.Size(1101, 927)
        Me.pnlHelp.TabIndex = 10
        '
        'btnNavIntroduction
        '
        Me.btnNavIntroduction.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButtonSettingsNav
        Me.btnNavIntroduction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNavIntroduction.FlatAppearance.BorderSize = 0
        Me.btnNavIntroduction.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNavIntroduction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNavIntroduction.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavIntroduction.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavIntroduction.Location = New System.Drawing.Point(40, 48)
        Me.btnNavIntroduction.Name = "btnNavIntroduction"
        Me.btnNavIntroduction.Size = New System.Drawing.Size(143, 28)
        Me.btnNavIntroduction.TabIndex = 3
        Me.btnNavIntroduction.Text = "Introduction"
        Me.btnNavIntroduction.UseVisualStyleBackColor = True
        '
        'btnNavOther
        '
        Me.btnNavOther.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButtonSettingsNav
        Me.btnNavOther.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNavOther.FlatAppearance.BorderSize = 0
        Me.btnNavOther.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNavOther.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNavOther.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavOther.Location = New System.Drawing.Point(953, 48)
        Me.btnNavOther.Name = "btnNavOther"
        Me.btnNavOther.Size = New System.Drawing.Size(150, 28)
        Me.btnNavOther.TabIndex = 9
        Me.btnNavOther.Text = "Other"
        Me.btnNavOther.UseVisualStyleBackColor = True
        '
        'btnNavProfilesAndSchemes
        '
        Me.btnNavProfilesAndSchemes.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButtonSettingsNav
        Me.btnNavProfilesAndSchemes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnNavProfilesAndSchemes.FlatAppearance.BorderSize = 0
        Me.btnNavProfilesAndSchemes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNavProfilesAndSchemes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNavProfilesAndSchemes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavProfilesAndSchemes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavProfilesAndSchemes.Location = New System.Drawing.Point(803, 48)
        Me.btnNavProfilesAndSchemes.Name = "btnNavProfilesAndSchemes"
        Me.btnNavProfilesAndSchemes.Size = New System.Drawing.Size(150, 28)
        Me.btnNavProfilesAndSchemes.TabIndex = 8
        Me.btnNavProfilesAndSchemes.Text = "Profiles and Schemes"
        Me.btnNavProfilesAndSchemes.UseVisualStyleBackColor = True
        '
        'btnNavDuplicateFinder
        '
        Me.btnNavDuplicateFinder.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButtonSettingsNav
        Me.btnNavDuplicateFinder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNavDuplicateFinder.FlatAppearance.BorderSize = 0
        Me.btnNavDuplicateFinder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNavDuplicateFinder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNavDuplicateFinder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavDuplicateFinder.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavDuplicateFinder.Location = New System.Drawing.Point(653, 48)
        Me.btnNavDuplicateFinder.Name = "btnNavDuplicateFinder"
        Me.btnNavDuplicateFinder.Size = New System.Drawing.Size(150, 28)
        Me.btnNavDuplicateFinder.TabIndex = 7
        Me.btnNavDuplicateFinder.Text = "Duplicate Finder"
        Me.btnNavDuplicateFinder.UseVisualStyleBackColor = True
        '
        'btnNavAddingItemsAdvanced
        '
        Me.btnNavAddingItemsAdvanced.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButtonSettingsNav
        Me.btnNavAddingItemsAdvanced.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNavAddingItemsAdvanced.FlatAppearance.BorderSize = 0
        Me.btnNavAddingItemsAdvanced.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNavAddingItemsAdvanced.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNavAddingItemsAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavAddingItemsAdvanced.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavAddingItemsAdvanced.Location = New System.Drawing.Point(483, 48)
        Me.btnNavAddingItemsAdvanced.Name = "btnNavAddingItemsAdvanced"
        Me.btnNavAddingItemsAdvanced.Size = New System.Drawing.Size(170, 28)
        Me.btnNavAddingItemsAdvanced.TabIndex = 6
        Me.btnNavAddingItemsAdvanced.Text = "Adding Items (Advanced)"
        Me.btnNavAddingItemsAdvanced.UseVisualStyleBackColor = True
        '
        'btnNavAddingItemsBasic
        '
        Me.btnNavAddingItemsBasic.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButtonSettingsNav
        Me.btnNavAddingItemsBasic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNavAddingItemsBasic.FlatAppearance.BorderSize = 0
        Me.btnNavAddingItemsBasic.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNavAddingItemsBasic.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNavAddingItemsBasic.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavAddingItemsBasic.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavAddingItemsBasic.Location = New System.Drawing.Point(333, 48)
        Me.btnNavAddingItemsBasic.Name = "btnNavAddingItemsBasic"
        Me.btnNavAddingItemsBasic.Size = New System.Drawing.Size(150, 28)
        Me.btnNavAddingItemsBasic.TabIndex = 5
        Me.btnNavAddingItemsBasic.Text = "Adding Items (Basic)"
        Me.btnNavAddingItemsBasic.UseVisualStyleBackColor = True
        '
        'btnNavSimpleOverview
        '
        Me.btnNavSimpleOverview.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButtonSettingsNav
        Me.btnNavSimpleOverview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNavSimpleOverview.FlatAppearance.BorderSize = 0
        Me.btnNavSimpleOverview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnNavSimpleOverview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnNavSimpleOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNavSimpleOverview.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNavSimpleOverview.Location = New System.Drawing.Point(183, 48)
        Me.btnNavSimpleOverview.Name = "btnNavSimpleOverview"
        Me.btnNavSimpleOverview.Size = New System.Drawing.Size(150, 28)
        Me.btnNavSimpleOverview.TabIndex = 4
        Me.btnNavSimpleOverview.Text = "Simple Overview"
        Me.btnNavSimpleOverview.UseVisualStyleBackColor = True
        '
        'pbNavigationBar
        '
        Me.pbNavigationBar.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgHelpNavigationBar
        Me.pbNavigationBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbNavigationBar.Location = New System.Drawing.Point(12, 48)
        Me.pbNavigationBar.Name = "pbNavigationBar"
        Me.pbNavigationBar.Size = New System.Drawing.Size(1120, 28)
        Me.pbNavigationBar.TabIndex = 2
        Me.pbNavigationBar.TabStop = False
        '
        'frmHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1146, 982)
        Me.Controls.Add(Me.btnNavIntroduction)
        Me.Controls.Add(Me.btnNavOther)
        Me.Controls.Add(Me.btnNavProfilesAndSchemes)
        Me.Controls.Add(Me.btnNavDuplicateFinder)
        Me.Controls.Add(Me.btnNavAddingItemsAdvanced)
        Me.Controls.Add(Me.btnNavAddingItemsBasic)
        Me.Controls.Add(Me.btnNavSimpleOverview)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.pbNavigationBar)
        Me.Controls.Add(Me.pnlHelp)
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
        CType(Me.pbAddItemsAdvanced, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDuplicateFinder.ResumeLayout(False)
        Me.tpDuplicateFinder.PerformLayout()
        CType(Me.pbDuplicateFinder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpProfilesAndSchemes.ResumeLayout(False)
        Me.tpProfilesAndSchemes.PerformLayout()
        Me.tpOther.ResumeLayout(False)
        Me.tpOther.PerformLayout()
        Me.pnlHelp.ResumeLayout(False)
        CType(Me.pbNavigationBar, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents llblWhatIsTheFastWayBasic As LinkLabel
    Friend WithEvents lblSelectDatapackVersionBasic As Label
    Friend WithEvents lblSelectDatapackFolderBasic As Label
    Friend WithEvents lblSpecifyNBTTagBasic As Label
    Friend WithEvents lblAddItemsToDatapackBasic As Label
    Friend WithEvents lblSelectItemTypeBasic As Label
    Friend WithEvents lblSelectItemIDBasic As Label
    Friend WithEvents lblDescriptionAddItemsBasic As Label
    Friend WithEvents pbAddItemsBasic As PictureBox
    Friend WithEvents pbDuplicateFinder As PictureBox
    Friend WithEvents lblDescriptionDuplicateFinder As Label
    Friend WithEvents lblOther As Label
    Friend WithEvents llblDatapackGithub As LinkLabel
    Friend WithEvents llblDatapackPMC As LinkLabel
    Friend WithEvents llblSoftwareGithub As LinkLabel
    Friend WithEvents llblTellMe As LinkLabel
    Friend WithEvents llblOtherDiscord As LinkLabel
    Friend WithEvents lblLastEditedOther As Label
    Friend WithEvents pbNavigationBar As PictureBox
    Friend WithEvents btnNavIntroduction As Button
    Friend WithEvents btnNavSimpleOverview As Button
    Friend WithEvents btnNavAddingItemsBasic As Button
    Friend WithEvents btnNavAddingItemsAdvanced As Button
    Friend WithEvents btnNavDuplicateFinder As Button
    Friend WithEvents btnNavProfilesAndSchemes As Button
    Friend WithEvents btnNavOther As Button
    Friend WithEvents lblSpecifyPrefixAndNBTTagAdvanced As Label
    Friend WithEvents lblAddItemsToDatapackAdvanced As Label
    Friend WithEvents SelectItemTypeAdvanced As Label
    Friend WithEvents lblSelectDatapackVersionAdvanced As Label
    Friend WithEvents lblSelectDatapackFolderAdvanced As Label
    Friend WithEvents lblEnterItemIDHereAdvanced As Label
    Friend WithEvents lblDescriptionAddingItemsAdvanced As Label
    Friend WithEvents pbAddItemsAdvanced As PictureBox
    Friend WithEvents lblDescriptionSchemes As Label
    Friend WithEvents llblWhatsTheFastWayAdvanced As LinkLabel
    Friend WithEvents llblHowToFindItemIDAdvanced As LinkLabel
    Friend WithEvents pnlHelp As Panel
    Friend WithEvents lblBeginChecking As Label
    Friend WithEvents lblDuplicateList As Label
    Friend WithEvents lblChooseDatapack As Label
    Friend WithEvents lblLastEditedAddItemsBasic As Label
    Friend WithEvents lblLastEditedAddingItemsAdvanced As Label
    Friend WithEvents lblLastEditedDuplicateFinder As Label
    Friend WithEvents lblLastEditedProfilesAndSchemes As Label
End Class
