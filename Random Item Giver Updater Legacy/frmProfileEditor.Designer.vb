<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmProfileEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProfileEditor))
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblChooseProfile = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.gbEditProfile = New System.Windows.Forms.GroupBox()
        Me.cbxDatapackVersion = New System.Windows.Forms.ComboBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblDatapackVersion = New System.Windows.Forms.Label()
        Me.tbDatapackPath = New System.Windows.Forms.TextBox()
        Me.lblDatapackPath = New System.Windows.Forms.Label()
        Me.settings = New System.Windows.Forms.RichTextBox()
        Me.fbdProfileEditor = New System.Windows.Forms.FolderBrowserDialog()
        Me.cbxProfile = New System.Windows.Forms.ComboBox()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.gbEditProfile.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.BackgroundImage = Global.Random_Item_Giver_Updater_Legacy.My.Resources.Resources.imgButtonLight
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(17, 260)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(190, 27)
        Me.btnClose.TabIndex = 17
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblChooseProfile
        '
        Me.lblChooseProfile.AutoSize = True
        Me.lblChooseProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChooseProfile.Location = New System.Drawing.Point(14, 42)
        Me.lblChooseProfile.Name = "lblChooseProfile"
        Me.lblChooseProfile.Size = New System.Drawing.Size(212, 16)
        Me.lblChooseProfile.TabIndex = 16
        Me.lblChooseProfile.Text = "Choose the profile you want to edit:"
        '
        'btnDelete
        '
        Me.btnDelete.BackgroundImage = Global.Random_Item_Giver_Updater_Legacy.My.Resources.Resources.imgButtonLight
        Me.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDelete.FlatAppearance.BorderSize = 0
        Me.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.Black
        Me.btnDelete.Location = New System.Drawing.Point(213, 260)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(188, 27)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "Delete profile"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.BackgroundImage = Global.Random_Item_Giver_Updater_Legacy.My.Resources.Resources.imgButtonLight
        Me.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Location = New System.Drawing.Point(407, 260)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(177, 27)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save changes"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'gbEditProfile
        '
        Me.gbEditProfile.Controls.Add(Me.cbxDatapackVersion)
        Me.gbEditProfile.Controls.Add(Me.btnBrowse)
        Me.gbEditProfile.Controls.Add(Me.lblDatapackVersion)
        Me.gbEditProfile.Controls.Add(Me.tbDatapackPath)
        Me.gbEditProfile.Controls.Add(Me.lblDatapackPath)
        Me.gbEditProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEditProfile.Location = New System.Drawing.Point(16, 97)
        Me.gbEditProfile.Name = "gbEditProfile"
        Me.gbEditProfile.Size = New System.Drawing.Size(569, 153)
        Me.gbEditProfile.TabIndex = 12
        Me.gbEditProfile.TabStop = False
        Me.gbEditProfile.Text = "Edit profile"
        '
        'cbxDatapackVersion
        '
        Me.cbxDatapackVersion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxDatapackVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDatapackVersion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxDatapackVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDatapackVersion.FormattingEnabled = True
        Me.cbxDatapackVersion.Items.AddRange(New Object() {"DONT EDIT THE ENTRIES IN HERE! THEY ARE DIRECTLY PULLED FROM THE MAIN WINDOW!"})
        Me.cbxDatapackVersion.Location = New System.Drawing.Point(18, 100)
        Me.cbxDatapackVersion.Name = "cbxDatapackVersion"
        Me.cbxDatapackVersion.Size = New System.Drawing.Size(246, 24)
        Me.cbxDatapackVersion.TabIndex = 23
        '
        'btnBrowse
        '
        Me.btnBrowse.BackgroundImage = Global.Random_Item_Giver_Updater_Legacy.My.Resources.Resources.imgButtonLight
        Me.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBrowse.FlatAppearance.BorderSize = 0
        Me.btnBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.ForeColor = System.Drawing.Color.Black
        Me.btnBrowse.Location = New System.Drawing.Point(450, 45)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(113, 23)
        Me.btnBrowse.TabIndex = 20
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblDatapackVersion
        '
        Me.lblDatapackVersion.AutoSize = True
        Me.lblDatapackVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatapackVersion.Location = New System.Drawing.Point(15, 81)
        Me.lblDatapackVersion.Name = "lblDatapackVersion"
        Me.lblDatapackVersion.Size = New System.Drawing.Size(116, 16)
        Me.lblDatapackVersion.TabIndex = 19
        Me.lblDatapackVersion.Text = "Datapack version:"
        '
        'tbDatapackPath
        '
        Me.tbDatapackPath.BackColor = System.Drawing.Color.Gainsboro
        Me.tbDatapackPath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbDatapackPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDatapackPath.Location = New System.Drawing.Point(18, 47)
        Me.tbDatapackPath.Name = "tbDatapackPath"
        Me.tbDatapackPath.Size = New System.Drawing.Size(425, 19)
        Me.tbDatapackPath.TabIndex = 18
        '
        'lblDatapackPath
        '
        Me.lblDatapackPath.AutoSize = True
        Me.lblDatapackPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatapackPath.Location = New System.Drawing.Point(15, 26)
        Me.lblDatapackPath.Name = "lblDatapackPath"
        Me.lblDatapackPath.Size = New System.Drawing.Size(98, 16)
        Me.lblDatapackPath.TabIndex = 0
        Me.lblDatapackPath.Text = "Datapack path:"
        '
        'settings
        '
        Me.settings.Location = New System.Drawing.Point(69, 314)
        Me.settings.Name = "settings"
        Me.settings.Size = New System.Drawing.Size(140, 35)
        Me.settings.TabIndex = 18
        Me.settings.Text = ""
        '
        'fbdProfileEditor
        '
        Me.fbdProfileEditor.Description = "Select a datapack folder..."
        Me.fbdProfileEditor.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'cbxProfile
        '
        Me.cbxProfile.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxProfile.FormattingEnabled = True
        Me.cbxProfile.Location = New System.Drawing.Point(17, 61)
        Me.cbxProfile.Name = "cbxProfile"
        Me.cbxProfile.Size = New System.Drawing.Size(322, 24)
        Me.cbxProfile.TabIndex = 21
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(13, 9)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(130, 24)
        Me.lblHeader.TabIndex = 22
        Me.lblHeader.Text = "Profile Editor"
        '
        'frmProfileEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(597, 296)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.cbxProfile)
        Me.Controls.Add(Me.settings)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblChooseProfile)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gbEditProfile)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmProfileEditor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Profile Editor"
        Me.gbEditProfile.ResumeLayout(False)
        Me.gbEditProfile.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents lblChooseProfile As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents gbEditProfile As GroupBox
    Friend WithEvents lblDatapackPath As Label
    Friend WithEvents tbDatapackPath As TextBox
    Friend WithEvents lblDatapackVersion As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents settings As RichTextBox
    Friend WithEvents fbdProfileEditor As FolderBrowserDialog
    Friend WithEvents cbxProfile As ComboBox
    Friend WithEvents lblHeader As Label
    Friend WithEvents cbxDatapackVersion As ComboBox
End Class
