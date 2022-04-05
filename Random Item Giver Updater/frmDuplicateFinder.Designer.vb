<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvDuplicates = New System.Windows.Forms.ListView()
        Me.chItem = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cbLootTable = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.tbDatapackPath = New System.Windows.Forms.TextBox()
        Me.rtbWithDuplicates = New System.Windows.Forms.RichTextBox()
        Me.rtbWithoutDuplicates = New System.Windows.Forms.RichTextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.fbdMainFolderPath = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.rtbDuplicates = New System.Windows.Forms.RichTextBox()
        Me.rtbreplace = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(18, 14)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(178, 25)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Duplicate finder"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(407, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "This tool can be used to check if items appear in the loot table twice." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Select t" &
    "he datapack you want to check"
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
        'btnCheck
        '
        Me.btnCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheck.Location = New System.Drawing.Point(213, 126)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(142, 27)
        Me.btnCheck.TabIndex = 3
        Me.btnCheck.Text = "Check"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'tbDatapackPath
        '
        Me.tbDatapackPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDatapackPath.Location = New System.Drawing.Point(23, 92)
        Me.tbDatapackPath.Name = "tbDatapackPath"
        Me.tbDatapackPath.Size = New System.Drawing.Size(404, 26)
        Me.tbDatapackPath.TabIndex = 4
        '
        'rtbWithDuplicates
        '
        Me.rtbWithDuplicates.Location = New System.Drawing.Point(23, 522)
        Me.rtbWithDuplicates.Name = "rtbWithDuplicates"
        Me.rtbWithDuplicates.Size = New System.Drawing.Size(527, 92)
        Me.rtbWithDuplicates.TabIndex = 5
        Me.rtbWithDuplicates.Text = ""
        '
        'rtbWithoutDuplicates
        '
        Me.rtbWithoutDuplicates.Location = New System.Drawing.Point(23, 620)
        Me.rtbWithoutDuplicates.Name = "rtbWithoutDuplicates"
        Me.rtbWithoutDuplicates.Size = New System.Drawing.Size(527, 92)
        Me.rtbWithoutDuplicates.TabIndex = 6
        Me.rtbWithoutDuplicates.Text = ""
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(433, 91)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(117, 27)
        Me.btnBrowse.TabIndex = 7
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'fbdMainFolderPath
        '
        Me.fbdMainFolderPath.Description = "Select the datapack which you want to check."
        '
        'btnHelp
        '
        Me.btnHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.Location = New System.Drawing.Point(500, 11)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(50, 37)
        Me.btnHelp.TabIndex = 8
        Me.btnHelp.Text = "!"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'rtbDuplicates
        '
        Me.rtbDuplicates.Location = New System.Drawing.Point(23, 718)
        Me.rtbDuplicates.Name = "rtbDuplicates"
        Me.rtbDuplicates.Size = New System.Drawing.Size(527, 92)
        Me.rtbDuplicates.TabIndex = 9
        Me.rtbDuplicates.Text = ""
        '
        'rtbreplace
        '
        Me.rtbreplace.Location = New System.Drawing.Point(23, 817)
        Me.rtbreplace.Name = "rtbreplace"
        Me.rtbreplace.Size = New System.Drawing.Size(527, 96)
        Me.rtbreplace.TabIndex = 10
        Me.rtbreplace.Text = ""
        '
        'frmDuplicateFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(572, 504)
        Me.Controls.Add(Me.rtbreplace)
        Me.Controls.Add(Me.rtbDuplicates)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.rtbWithoutDuplicates)
        Me.Controls.Add(Me.rtbWithDuplicates)
        Me.Controls.Add(Me.tbDatapackPath)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.lvDuplicates)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblHeader)
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
    Friend WithEvents Label2 As Label
    Friend WithEvents lvDuplicates As ListView
    Friend WithEvents chItem As ColumnHeader
    Friend WithEvents cbLootTable As ColumnHeader
    Friend WithEvents btnCheck As Button
    Friend WithEvents tbDatapackPath As TextBox
    Friend WithEvents rtbWithDuplicates As RichTextBox
    Friend WithEvents rtbWithoutDuplicates As RichTextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents fbdMainFolderPath As FolderBrowserDialog
    Friend WithEvents btnHelp As Button
    Friend WithEvents rtbDuplicates As RichTextBox
    Friend WithEvents rtbreplace As RichTextBox
End Class
