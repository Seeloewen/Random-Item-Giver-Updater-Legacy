﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDuplicateFinder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDuplicateFinder))
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lvDuplicates = New System.Windows.Forms.ListView()
        Me.chItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cbLootTable = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tbDatapackPath = New System.Windows.Forms.TextBox()
        Me.fbdMainFolderPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.lblDuplicatesAmount = New System.Windows.Forms.Label()
        Me.bgwSearchForDuplicates = New System.ComponentModel.BackgroundWorker()
        Me.Quotationmark = New System.Windows.Forms.Label()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.lblChecking = New System.Windows.Forms.Label()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.btnLoadProfile = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(18, 14)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(185, 25)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Duplicate Finder"
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(20, 49)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(469, 32)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.Text = "This tool can be used to check if items appear in the loot table more than once." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Select the datapack you want to check:"
        '
        'lvDuplicates
        '
        Me.lvDuplicates.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chItem, Me.cbLootTable})
        Me.lvDuplicates.HideSelection = False
        Me.lvDuplicates.Location = New System.Drawing.Point(23, 168)
        Me.lvDuplicates.Name = "lvDuplicates"
        Me.lvDuplicates.Size = New System.Drawing.Size(527, 313)
        Me.lvDuplicates.TabIndex = 2
        Me.lvDuplicates.UseCompatibleStateImageBehavior = False
        Me.lvDuplicates.View = System.Windows.Forms.View.Details
        '
        'chItem
        '
        Me.chItem.Text = "Item"
        Me.chItem.Width = 256
        '
        'cbLootTable
        '
        Me.cbLootTable.Text = "Loot Table"
        Me.cbLootTable.Width = 266
        '
        'tbDatapackPath
        '
        Me.tbDatapackPath.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.tbDatapackPath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbDatapackPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDatapackPath.Location = New System.Drawing.Point(23, 93)
        Me.tbDatapackPath.Name = "tbDatapackPath"
        Me.tbDatapackPath.Size = New System.Drawing.Size(404, 19)
        Me.tbDatapackPath.TabIndex = 4
        '
        'fbdMainFolderPath
        '
        Me.fbdMainFolderPath.Description = "Select the datapack which you want to check."
        Me.fbdMainFolderPath.RootFolder = System.Environment.SpecialFolder.MyComputer
        '
        'lblDuplicatesAmount
        '
        Me.lblDuplicatesAmount.AutoSize = True
        Me.lblDuplicatesAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDuplicatesAmount.Location = New System.Drawing.Point(210, 494)
        Me.lblDuplicatesAmount.Name = "lblDuplicatesAmount"
        Me.lblDuplicatesAmount.Size = New System.Drawing.Size(174, 16)
        Me.lblDuplicatesAmount.TabIndex = 11
        Me.lblDuplicatesAmount.Text = "Found {0} duplicates in total."
        Me.lblDuplicatesAmount.Visible = False
        '
        'bgwSearchForDuplicates
        '
        Me.bgwSearchForDuplicates.WorkerReportsProgress = True
        '
        'Quotationmark
        '
        Me.Quotationmark.AutoSize = True
        Me.Quotationmark.Location = New System.Drawing.Point(508, 559)
        Me.Quotationmark.Name = "Quotationmark"
        Me.Quotationmark.Size = New System.Drawing.Size(12, 13)
        Me.Quotationmark.TabIndex = 13
        Me.Quotationmark.Text = """"
        '
        'ListView1
        '
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(12, 530)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(121, 97)
        Me.ListView1.TabIndex = 14
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(266, 600)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(100, 96)
        Me.RichTextBox1.TabIndex = 15
        Me.RichTextBox1.Text = ""
        '
        'lblChecking
        '
        Me.lblChecking.AutoSize = True
        Me.lblChecking.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChecking.Location = New System.Drawing.Point(19, 490)
        Me.lblChecking.Name = "lblChecking"
        Me.lblChecking.Size = New System.Drawing.Size(186, 20)
        Me.lblChecking.TabIndex = 10
        Me.lblChecking.Text = "Checking for duplicates..."
        Me.lblChecking.Visible = False
        '
        'pbProgress
        '
        Me.pbProgress.Location = New System.Drawing.Point(212, 490)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(338, 23)
        Me.pbProgress.TabIndex = 16
        Me.pbProgress.Visible = False
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
        Me.btnBrowse.Location = New System.Drawing.Point(433, 91)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(117, 23)
        Me.btnBrowse.TabIndex = 7
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnCheck
        '
        Me.btnCheck.BackgroundImage = Global.Random_Item_Giver_Updater_Legacy.My.Resources.Resources.imgButtonLight
        Me.btnCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCheck.FlatAppearance.BorderSize = 0
        Me.btnCheck.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCheck.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheck.ForeColor = System.Drawing.Color.Black
        Me.btnCheck.Location = New System.Drawing.Point(142, 125)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(142, 27)
        Me.btnCheck.TabIndex = 3
        Me.btnCheck.Text = "Check Datapack"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'btnLoadProfile
        '
        Me.btnLoadProfile.BackgroundImage = Global.Random_Item_Giver_Updater_Legacy.My.Resources.Resources.imgButtonLight
        Me.btnLoadProfile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLoadProfile.FlatAppearance.BorderSize = 0
        Me.btnLoadProfile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnLoadProfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnLoadProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadProfile.ForeColor = System.Drawing.Color.Black
        Me.btnLoadProfile.Location = New System.Drawing.Point(301, 125)
        Me.btnLoadProfile.Name = "btnLoadProfile"
        Me.btnLoadProfile.Size = New System.Drawing.Size(142, 27)
        Me.btnLoadProfile.TabIndex = 17
        Me.btnLoadProfile.Text = "Load Profile"
        Me.btnLoadProfile.UseVisualStyleBackColor = True
        '
        'frmDuplicateFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(572, 523)
        Me.Controls.Add(Me.btnLoadProfile)
        Me.Controls.Add(Me.lblChecking)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Quotationmark)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.tbDatapackPath)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.lvDuplicates)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.pbProgress)
        Me.Controls.Add(Me.lblDuplicatesAmount)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDuplicateFinder"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Duplicate Finder"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lvDuplicates As ListView
    Friend WithEvents chItem As ColumnHeader
    Friend WithEvents cbLootTable As ColumnHeader
    Friend WithEvents btnCheck As Button
    Friend WithEvents tbDatapackPath As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents fbdMainFolderPath As FolderBrowserDialog
    Friend WithEvents lblDuplicatesAmount As Label
	Friend WithEvents bgwSearchForDuplicates As System.ComponentModel.BackgroundWorker
	Friend WithEvents Quotationmark As Label
    Friend WithEvents ListView1 As ListView
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents lblChecking As Label
    Friend WithEvents pbProgress As ProgressBar
	Friend WithEvents btnLoadProfile As Button
End Class
