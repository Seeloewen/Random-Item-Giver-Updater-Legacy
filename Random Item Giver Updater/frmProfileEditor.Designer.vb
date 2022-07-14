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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.cbxProfile = New System.Windows.Forms.ComboBox()
        Me.gbEditProfile = New System.Windows.Forms.GroupBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblDatapackVersion = New System.Windows.Forms.Label()
        Me.cbxDatapackVersion = New System.Windows.Forms.ComboBox()
        Me.tbDatapackPath = New System.Windows.Forms.TextBox()
        Me.lblDatapackPath = New System.Windows.Forms.Label()
        Me.settings = New System.Windows.Forms.RichTextBox()
        Me.gbEditProfile.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(17, 213)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(126, 23)
        Me.btnClose.TabIndex = 17
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(17, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Choose the profile you want to edit:"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(233, 213)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(131, 23)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "Delete profile"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(454, 213)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(131, 23)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "Save changes"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'cbxProfile
        '
        Me.cbxProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProfile.FormattingEnabled = True
        Me.cbxProfile.Location = New System.Drawing.Point(17, 31)
        Me.cbxProfile.Name = "cbxProfile"
        Me.cbxProfile.Size = New System.Drawing.Size(266, 21)
        Me.cbxProfile.TabIndex = 13
        '
        'gbEditProfile
        '
        Me.gbEditProfile.Controls.Add(Me.btnBrowse)
        Me.gbEditProfile.Controls.Add(Me.lblDatapackVersion)
        Me.gbEditProfile.Controls.Add(Me.cbxDatapackVersion)
        Me.gbEditProfile.Controls.Add(Me.tbDatapackPath)
        Me.gbEditProfile.Controls.Add(Me.lblDatapackPath)
        Me.gbEditProfile.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbEditProfile.Location = New System.Drawing.Point(16, 58)
        Me.gbEditProfile.Name = "gbEditProfile"
        Me.gbEditProfile.Size = New System.Drawing.Size(569, 145)
        Me.gbEditProfile.TabIndex = 12
        Me.gbEditProfile.TabStop = False
        Me.gbEditProfile.Text = "Edit profile"
        '
        'btnBrowse
        '
        Me.btnBrowse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'cbxDatapackVersion
        '
        Me.cbxDatapackVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDatapackVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxDatapackVersion.FormattingEnabled = True
        Me.cbxDatapackVersion.Location = New System.Drawing.Point(18, 100)
        Me.cbxDatapackVersion.Name = "cbxDatapackVersion"
        Me.cbxDatapackVersion.Size = New System.Drawing.Size(235, 24)
        Me.cbxDatapackVersion.TabIndex = 18
        '
        'tbDatapackPath
        '
        Me.tbDatapackPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDatapackPath.Location = New System.Drawing.Point(18, 45)
        Me.tbDatapackPath.Name = "tbDatapackPath"
        Me.tbDatapackPath.Size = New System.Drawing.Size(425, 22)
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
        'frmProfileEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(597, 248)
        Me.Controls.Add(Me.settings)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cbxProfile)
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
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents cbxProfile As ComboBox
    Friend WithEvents gbEditProfile As GroupBox
    Friend WithEvents lblDatapackPath As Label
    Friend WithEvents tbDatapackPath As TextBox
    Friend WithEvents lblDatapackVersion As Label
    Friend WithEvents cbxDatapackVersion As ComboBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents settings As RichTextBox
End Class
