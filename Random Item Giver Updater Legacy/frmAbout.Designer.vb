﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAbout))
        Me.lblBuild = New System.Windows.Forms.Label()
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.gbLicense = New System.Windows.Forms.GroupBox()
        Me.rtbLicense = New System.Windows.Forms.RichTextBox()
        Me.llblGithub = New System.Windows.Forms.LinkLabel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblCreator = New System.Windows.Forms.Label()
        Me.gbLicense.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblBuild
        '
        Me.lblBuild.AutoSize = True
        Me.lblBuild.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuild.Location = New System.Drawing.Point(78, 77)
        Me.lblBuild.Name = "lblBuild"
        Me.lblBuild.Size = New System.Drawing.Size(154, 20)
        Me.lblBuild.TabIndex = 4
        Me.lblBuild.Text = "Version {ver} ({date})"
        Me.lblBuild.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(20, 9)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(336, 58)
        Me.lblHeader.TabIndex = 3
        Me.lblHeader.Text = "Random Item Giver Updater" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(Legacy Version)"
        Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'gbLicense
        '
        Me.gbLicense.Controls.Add(Me.rtbLicense)
        Me.gbLicense.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbLicense.Location = New System.Drawing.Point(16, 145)
        Me.gbLicense.Name = "gbLicense"
        Me.gbLicense.Size = New System.Drawing.Size(344, 220)
        Me.gbLicense.TabIndex = 6
        Me.gbLicense.TabStop = False
        Me.gbLicense.Text = "License"
        '
        'rtbLicense
        '
        Me.rtbLicense.BackColor = System.Drawing.Color.White
        Me.rtbLicense.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbLicense.Location = New System.Drawing.Point(7, 22)
        Me.rtbLicense.Name = "rtbLicense"
        Me.rtbLicense.ReadOnly = True
        Me.rtbLicense.Size = New System.Drawing.Size(331, 192)
        Me.rtbLicense.TabIndex = 0
        Me.rtbLicense.Text = resources.GetString("rtbLicense.Text")
        '
        'llblGithub
        '
        Me.llblGithub.AutoSize = True
        Me.llblGithub.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblGithub.Location = New System.Drawing.Point(17, 372)
        Me.llblGithub.Name = "llblGithub"
        Me.llblGithub.Size = New System.Drawing.Size(341, 20)
        Me.llblGithub.TabIndex = 7
        Me.llblGithub.TabStop = True
        Me.llblGithub.Text = "Random Item Giver Updater Legacy - Github"
        '
        'btnOK
        '
        Me.btnOK.BackgroundImage = Global.Random_Item_Giver_Updater_Legacy.My.Resources.Resources.imgButtonLight
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.Black
        Me.btnOK.Location = New System.Drawing.Point(112, 405)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(148, 26)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblCreator
        '
        Me.lblCreator.AutoSize = True
        Me.lblCreator.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreator.Location = New System.Drawing.Point(12, 98)
        Me.lblCreator.Name = "lblCreator"
        Me.lblCreator.Size = New System.Drawing.Size(355, 40)
        Me.lblCreator.TabIndex = 8
        Me.lblCreator.Text = "Seeloewen (Louis)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "This software is not affiliated with Mojang Studios" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblCreator.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(372, 446)
        Me.Controls.Add(Me.lblCreator)
        Me.Controls.Add(Me.llblGithub)
        Me.Controls.Add(Me.gbLicense)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblBuild)
        Me.Controls.Add(Me.lblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        Me.gbLicense.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnOK As Button
    Friend WithEvents lblBuild As Label
    Friend WithEvents lblHeader As Label
    Friend WithEvents gbLicense As GroupBox
    Friend WithEvents rtbLicense As RichTextBox
    Friend WithEvents llblGithub As LinkLabel
    Friend WithEvents lblCreator As Label
End Class
