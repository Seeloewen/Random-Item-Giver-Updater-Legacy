<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateNews
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdateNews))
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblNewsHeader1 = New System.Windows.Forms.Label()
        Me.lblNewsDesc1 = New System.Windows.Forms.Label()
        Me.llblFullChangelog = New System.Windows.Forms.LinkLabel()
        Me.lblNewsDesc2 = New System.Windows.Forms.Label()
        Me.lblNewsHeader2 = New System.Windows.Forms.Label()
        Me.lblNewsDesc3 = New System.Windows.Forms.Label()
        Me.lblNewsHeader3 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnOK = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(59, 14)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(307, 25)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Version 0.5.3 - What's new?"
        '
        'lblNewsHeader1
        '
        Me.lblNewsHeader1.AutoSize = True
        Me.lblNewsHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewsHeader1.Location = New System.Drawing.Point(16, 56)
        Me.lblNewsHeader1.Name = "lblNewsHeader1"
        Me.lblNewsHeader1.Size = New System.Drawing.Size(235, 24)
        Me.lblNewsHeader1.TabIndex = 1
        Me.lblNewsHeader1.Text = "Support for newer versions"
        '
        'lblNewsDesc1
        '
        Me.lblNewsDesc1.AutoSize = True
        Me.lblNewsDesc1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewsDesc1.Location = New System.Drawing.Point(17, 82)
        Me.lblNewsDesc1.Name = "lblNewsDesc1"
        Me.lblNewsDesc1.Size = New System.Drawing.Size(434, 32)
        Me.lblNewsDesc1.TabIndex = 2
        Me.lblNewsDesc1.Text = "The software now supports pack versions 16 to 26. This also comes with " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "compatib" &
    "ility for 1.20.2 to 1.20.4."
        '
        'llblFullChangelog
        '
        Me.llblFullChangelog.AutoSize = True
        Me.llblFullChangelog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblFullChangelog.Location = New System.Drawing.Point(17, 308)
        Me.llblFullChangelog.Name = "llblFullChangelog"
        Me.llblFullChangelog.Size = New System.Drawing.Size(143, 16)
        Me.llblFullChangelog.TabIndex = 3
        Me.llblFullChangelog.TabStop = True
        Me.llblFullChangelog.Text = "View the full changelog"
        '
        'lblNewsDesc2
        '
        Me.lblNewsDesc2.AutoSize = True
        Me.lblNewsDesc2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewsDesc2.Location = New System.Drawing.Point(17, 155)
        Me.lblNewsDesc2.Name = "lblNewsDesc2"
        Me.lblNewsDesc2.Size = New System.Drawing.Size(456, 48)
        Me.lblNewsDesc2.TabIndex = 6
        Me.lblNewsDesc2.Text = "The Duplicate Finder has been reworked to fix several long-standing issues " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and " &
    "to ensure better performance. Compatibility for newer versions of the" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Datapack " &
    "was also added."
        '
        'lblNewsHeader2
        '
        Me.lblNewsHeader2.AutoSize = True
        Me.lblNewsHeader2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewsHeader2.Location = New System.Drawing.Point(16, 131)
        Me.lblNewsHeader2.Name = "lblNewsHeader2"
        Me.lblNewsHeader2.Size = New System.Drawing.Size(217, 24)
        Me.lblNewsHeader2.TabIndex = 5
        Me.lblNewsHeader2.Text = "Duplicate Finder Rework"
        '
        'lblNewsDesc3
        '
        Me.lblNewsDesc3.AutoSize = True
        Me.lblNewsDesc3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewsDesc3.Location = New System.Drawing.Point(17, 250)
        Me.lblNewsDesc3.Name = "lblNewsDesc3"
        Me.lblNewsDesc3.Size = New System.Drawing.Size(433, 32)
        Me.lblNewsDesc3.TabIndex = 9
        Me.lblNewsDesc3.Text = "You can now rename your profiles and schemes however you like! A few" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "performance" &
    " improvements and bug fixes have also been implemented."
        '
        'lblNewsHeader3
        '
        Me.lblNewsHeader3.AutoSize = True
        Me.lblNewsHeader3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewsHeader3.Location = New System.Drawing.Point(16, 225)
        Me.lblNewsHeader3.Name = "lblNewsHeader3"
        Me.lblNewsHeader3.Size = New System.Drawing.Size(217, 24)
        Me.lblNewsHeader3.TabIndex = 8
        Me.lblNewsHeader3.Text = "Additional Improvements"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.Random_Item_Giver_Updater_Legacy.My.Resources.Resources.imgUpdate
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(12, 5)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(41, 40)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.BackgroundImage = Global.Random_Item_Giver_Updater_Legacy.My.Resources.Resources.imgButtonLight
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(367, 304)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(110, 25)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmUpdateNews
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(489, 342)
        Me.Controls.Add(Me.lblNewsDesc3)
        Me.Controls.Add(Me.lblNewsHeader3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblNewsDesc2)
        Me.Controls.Add(Me.lblNewsHeader2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.llblFullChangelog)
        Me.Controls.Add(Me.lblNewsDesc1)
        Me.Controls.Add(Me.lblNewsHeader1)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdateNews"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Random Item Giver Updater was successfully installed!"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents lblNewsHeader1 As Label
    Friend WithEvents lblNewsDesc1 As Label
    Friend WithEvents llblFullChangelog As LinkLabel
    Friend WithEvents btnOK As Button
    Friend WithEvents lblNewsDesc2 As Label
    Friend WithEvents lblNewsHeader2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblNewsDesc3 As Label
    Friend WithEvents lblNewsHeader3 As Label
End Class
