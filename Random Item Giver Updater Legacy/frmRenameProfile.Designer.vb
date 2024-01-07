<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRenameProfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRenameProfile))
        Me.tbRenameProfileTo = New System.Windows.Forms.TextBox()
        Me.lblSaveProfileAs = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnRename = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'tbRenameProfileTo
        '
        Me.tbRenameProfileTo.BackColor = System.Drawing.Color.Gainsboro
        Me.tbRenameProfileTo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbRenameProfileTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbRenameProfileTo.Location = New System.Drawing.Point(20, 36)
        Me.tbRenameProfileTo.Name = "tbRenameProfileTo"
        Me.tbRenameProfileTo.Size = New System.Drawing.Size(338, 19)
        Me.tbRenameProfileTo.TabIndex = 17
        '
        'lblSaveProfileAs
        '
        Me.lblSaveProfileAs.AutoSize = True
        Me.lblSaveProfileAs.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaveProfileAs.Location = New System.Drawing.Point(17, 12)
        Me.lblSaveProfileAs.Name = "lblSaveProfileAs"
        Me.lblSaveProfileAs.Size = New System.Drawing.Size(123, 16)
        Me.lblSaveProfileAs.TabIndex = 16
        Me.lblSaveProfileAs.Text = "Rename Profile to..."
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Global.Random_Item_Giver_Updater_Legacy.My.Resources.Resources.imgButtonLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(249, 67)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(109, 23)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseMnemonic = False
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnRename
        '
        Me.btnRename.BackgroundImage = Global.Random_Item_Giver_Updater_Legacy.My.Resources.Resources.imgButtonLight
        Me.btnRename.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRename.FlatAppearance.BorderSize = 0
        Me.btnRename.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnRename.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRename.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRename.ForeColor = System.Drawing.Color.Black
        Me.btnRename.Location = New System.Drawing.Point(134, 67)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New System.Drawing.Size(109, 23)
        Me.btnRename.TabIndex = 18
        Me.btnRename.Text = "Rename"
        Me.btnRename.UseVisualStyleBackColor = True
        '
        'frmRenameProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 102)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnRename)
        Me.Controls.Add(Me.tbRenameProfileTo)
        Me.Controls.Add(Me.lblSaveProfileAs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRenameProfile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rename Profile"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnRename As Button
    Friend WithEvents tbRenameProfileTo As TextBox
    Friend WithEvents lblSaveProfileAs As Label
End Class
