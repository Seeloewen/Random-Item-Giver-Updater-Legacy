﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(12, 13)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(307, 25)
        Me.lblHeader.TabIndex = 0
        Me.lblHeader.Text = "Version 0.4.1 - What's new?"
        '
        'lblNewsHeader1
        '
        Me.lblNewsHeader1.AutoSize = True
        Me.lblNewsHeader1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewsHeader1.Location = New System.Drawing.Point(13, 54)
        Me.lblNewsHeader1.Name = "lblNewsHeader1"
        Me.lblNewsHeader1.Size = New System.Drawing.Size(244, 24)
        Me.lblNewsHeader1.TabIndex = 1
        Me.lblNewsHeader1.Text = "Improved loading of settings"
        '
        'lblNewsDesc1
        '
        Me.lblNewsDesc1.AutoSize = True
        Me.lblNewsDesc1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNewsDesc1.Location = New System.Drawing.Point(17, 82)
        Me.lblNewsDesc1.Name = "lblNewsDesc1"
        Me.lblNewsDesc1.Size = New System.Drawing.Size(438, 32)
        Me.lblNewsDesc1.TabIndex = 2
        Me.lblNewsDesc1.Text = "When loading an old or corrupted settings file, it will now get automatically" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "re" &
    "paired, if possible."
        '
        'llblFullChangelog
        '
        Me.llblFullChangelog.AutoSize = True
        Me.llblFullChangelog.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.llblFullChangelog.Location = New System.Drawing.Point(17, 138)
        Me.llblFullChangelog.Name = "llblFullChangelog"
        Me.llblFullChangelog.Size = New System.Drawing.Size(143, 16)
        Me.llblFullChangelog.TabIndex = 3
        Me.llblFullChangelog.TabStop = True
        Me.llblFullChangelog.Text = "View the full changelog"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(345, 137)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(110, 23)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmUpdateNews
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(477, 172)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents lblNewsHeader1 As Label
    Friend WithEvents lblNewsDesc1 As Label
    Friend WithEvents llblFullChangelog As LinkLabel
    Friend WithEvents btnOK As Button
End Class
