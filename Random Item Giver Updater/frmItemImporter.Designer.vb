<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemImporter
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemImporter))
        Me.lblImportDesc = New System.Windows.Forms.Label()
        Me.tbImportFromFile = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnImport = New System.Windows.Forms.Button()
        Me.ofdImportFromFile = New System.Windows.Forms.OpenFileDialog()
        Me.rtbItems = New System.Windows.Forms.RichTextBox()
        Me.cbDontImportVanilla = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.llbl = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lblImportDesc
        '
        Me.lblImportDesc.AutoSize = True
        Me.lblImportDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportDesc.Location = New System.Drawing.Point(17, 54)
        Me.lblImportDesc.Name = "lblImportDesc"
        Me.lblImportDesc.Size = New System.Drawing.Size(542, 64)
        Me.lblImportDesc.TabIndex = 0
        Me.lblImportDesc.Text = resources.GetString("lblImportDesc.Text")
        '
        'tbImportFromFile
        '
        Me.tbImportFromFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbImportFromFile.Location = New System.Drawing.Point(20, 132)
        Me.tbImportFromFile.Name = "tbImportFromFile"
        Me.tbImportFromFile.Size = New System.Drawing.Size(434, 22)
        Me.tbImportFromFile.TabIndex = 1
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowse.Location = New System.Drawing.Point(460, 131)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(122, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImport.Location = New System.Drawing.Point(230, 201)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(127, 27)
        Me.btnImport.TabIndex = 3
        Me.btnImport.Text = "Import item list"
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'ofdImportFromFile
        '
        Me.ofdImportFromFile.Title = "Select a text file..."
        '
        'rtbItems
        '
        Me.rtbItems.Location = New System.Drawing.Point(68, 314)
        Me.rtbItems.Name = "rtbItems"
        Me.rtbItems.Size = New System.Drawing.Size(346, 158)
        Me.rtbItems.TabIndex = 5
        Me.rtbItems.Text = ""
        '
        'cbDontImportVanilla
        '
        Me.cbDontImportVanilla.AutoSize = True
        Me.cbDontImportVanilla.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDontImportVanilla.Location = New System.Drawing.Point(20, 164)
        Me.cbDontImportVanilla.Name = "cbDontImportVanilla"
        Me.cbDontImportVanilla.Size = New System.Drawing.Size(480, 22)
        Me.cbDontImportVanilla.TabIndex = 6
        Me.cbDontImportVanilla.Text = "Don't import vanilla items (Recommended when using the TellMe file)"
        Me.cbDontImportVanilla.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 25)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Item List Importer"
        '
        'llbl
        '
        Me.llbl.AutoSize = True
        Me.llbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llbl.Location = New System.Drawing.Point(470, 102)
        Me.llbl.Name = "llbl"
        Me.llbl.Size = New System.Drawing.Size(102, 16)
        Me.llbl.TabIndex = 8
        Me.llbl.TabStop = True
        Me.llbl.Text = "Copy command"
        '
        'frmItemImporter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(594, 240)
        Me.Controls.Add(Me.llbl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbDontImportVanilla)
        Me.Controls.Add(Me.rtbItems)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.tbImportFromFile)
        Me.Controls.Add(Me.lblImportDesc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemImporter"
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
    Friend WithEvents rtbItems As RichTextBox
    Friend WithEvents cbDontImportVanilla As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents llbl As LinkLabel
End Class
