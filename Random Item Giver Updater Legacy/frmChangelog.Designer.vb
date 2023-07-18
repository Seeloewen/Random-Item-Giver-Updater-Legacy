<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmChangelog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmChangelog))
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.rtbChangelog = New System.Windows.Forms.RichTextBox()
        Me.gbChangelog = New System.Windows.Forms.GroupBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.gbChangelog.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(12, 12)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(112, 24)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Changelog"
        '
        'rtbChangelog
        '
        Me.rtbChangelog.BackColor = System.Drawing.Color.White
        Me.rtbChangelog.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbChangelog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbChangelog.Location = New System.Drawing.Point(15, 19)
        Me.rtbChangelog.Name = "rtbChangelog"
        Me.rtbChangelog.ReadOnly = True
        Me.rtbChangelog.Size = New System.Drawing.Size(424, 322)
        Me.rtbChangelog.TabIndex = 1
        Me.rtbChangelog.Text = resources.GetString("rtbChangelog.Text")
        '
        'gbChangelog
        '
        Me.gbChangelog.Controls.Add(Me.rtbChangelog)
        Me.gbChangelog.Location = New System.Drawing.Point(12, 39)
        Me.gbChangelog.Name = "gbChangelog"
        Me.gbChangelog.Size = New System.Drawing.Size(445, 353)
        Me.gbChangelog.TabIndex = 3
        Me.gbChangelog.TabStop = False
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
        Me.btnOK.Location = New System.Drawing.Point(167, 399)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(133, 24)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmChangelog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(469, 434)
        Me.Controls.Add(Me.gbChangelog)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmChangelog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Changelog"
        Me.gbChangelog.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents rtbChangelog As RichTextBox
    Friend WithEvents btnOK As Button
    Friend WithEvents gbChangelog As GroupBox
End Class
