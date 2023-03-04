<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmItemListImporter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemListImporter))
        Me.lblImportDesc = New System.Windows.Forms.Label()
        Me.tbImportFromFile = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.ofdImportFromFile = New System.Windows.Forms.OpenFileDialog()
        Me.cbDontImportVanilla = New System.Windows.Forms.CheckBox()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.llblCopyCommand = New System.Windows.Forms.LinkLabel()
        Me.btnShowPreview = New System.Windows.Forms.Button()
        Me.rtbItems = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'lblImportDesc
        '
        Me.lblImportDesc.AutoSize = True
        Me.lblImportDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblImportDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportDesc.Location = New System.Drawing.Point(17, 49)
        Me.lblImportDesc.Name = "lblImportDesc"
        Me.lblImportDesc.Size = New System.Drawing.Size(544, 112)
        Me.lblImportDesc.TabIndex = 0
        Me.lblImportDesc.Text = resources.GetString("lblImportDesc.Text")
        '
        'tbImportFromFile
        '
        Me.tbImportFromFile.BackColor = System.Drawing.Color.Gainsboro
        Me.tbImportFromFile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbImportFromFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbImportFromFile.Location = New System.Drawing.Point(20, 192)
        Me.tbImportFromFile.Name = "tbImportFromFile"
        Me.tbImportFromFile.Size = New System.Drawing.Size(434, 19)
        Me.tbImportFromFile.TabIndex = 1
        '
        'btnBrowse
        '
        Me.btnBrowse.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBrowse.FlatAppearance.BorderSize = 0
        Me.btnBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.ForeColor = System.Drawing.Color.White
        Me.btnBrowse.Location = New System.Drawing.Point(460, 190)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(122, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.BackColor = System.Drawing.Color.Transparent
        Me.btnImport.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnImport.FlatAppearance.BorderSize = 0
        Me.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImport.ForeColor = System.Drawing.Color.White
        Me.btnImport.Location = New System.Drawing.Point(460, 236)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(122, 27)
        Me.btnImport.TabIndex = 3
        Me.btnImport.Text = "Import item list"
        Me.btnImport.UseVisualStyleBackColor = False
        '
        'ofdImportFromFile
        '
        Me.ofdImportFromFile.Title = "Select a text file..."
        '
        'cbDontImportVanilla
        '
        Me.cbDontImportVanilla.AutoSize = True
        Me.cbDontImportVanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDontImportVanilla.Location = New System.Drawing.Point(20, 238)
        Me.cbDontImportVanilla.Name = "cbDontImportVanilla"
        Me.cbDontImportVanilla.Size = New System.Drawing.Size(192, 22)
        Me.cbDontImportVanilla.TabIndex = 6
        Me.cbDontImportVanilla.Text = "Don't import vanilla items"
        Me.cbDontImportVanilla.UseVisualStyleBackColor = True
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(15, 13)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(194, 25)
        Me.lblHeader.TabIndex = 7
        Me.lblHeader.Text = "Item List Importer"
        '
        'llblCopyCommand
        '
        Me.llblCopyCommand.AutoSize = True
        Me.llblCopyCommand.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblCopyCommand.Location = New System.Drawing.Point(422, 145)
        Me.llblCopyCommand.Name = "llblCopyCommand"
        Me.llblCopyCommand.Size = New System.Drawing.Size(102, 16)
        Me.llblCopyCommand.TabIndex = 8
        Me.llblCopyCommand.TabStop = True
        Me.llblCopyCommand.Text = "Copy command"
        '
        'btnShowPreview
        '
        Me.btnShowPreview.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButton
        Me.btnShowPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnShowPreview.FlatAppearance.BorderSize = 0
        Me.btnShowPreview.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnShowPreview.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnShowPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShowPreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShowPreview.ForeColor = System.Drawing.Color.White
        Me.btnShowPreview.Location = New System.Drawing.Point(332, 235)
        Me.btnShowPreview.Name = "btnShowPreview"
        Me.btnShowPreview.Size = New System.Drawing.Size(122, 28)
        Me.btnShowPreview.TabIndex = 9
        Me.btnShowPreview.Text = "Show Preview"
        Me.btnShowPreview.UseVisualStyleBackColor = True
        '
        'rtbItems
        '
        Me.rtbItems.Location = New System.Drawing.Point(243, 344)
        Me.rtbItems.Name = "rtbItems"
        Me.rtbItems.Size = New System.Drawing.Size(100, 96)
        Me.rtbItems.TabIndex = 10
        Me.rtbItems.Text = ""
        '
        'frmItemListImporter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(598, 276)
        Me.Controls.Add(Me.rtbItems)
        Me.Controls.Add(Me.btnShowPreview)
        Me.Controls.Add(Me.llblCopyCommand)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.cbDontImportVanilla)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.tbImportFromFile)
        Me.Controls.Add(Me.lblImportDesc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemListImporter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item List Importer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblImportDesc As Label
    Friend WithEvents tbImportFromFile As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnImport As Button
    Friend WithEvents ofdImportFromFile As OpenFileDialog
    Friend WithEvents cbDontImportVanilla As CheckBox
    Friend WithEvents lblHeader As Label
    Friend WithEvents llblCopyCommand As LinkLabel
    Friend WithEvents btnShowPreview As Button
    Friend WithEvents rtbItems As RichTextBox
End Class
