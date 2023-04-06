<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLoadProfileFrom
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLoadProfileFrom))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.lblLoadProfileFrom = New System.Windows.Forms.Label()
        Me.cbxProfiles = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButtonLight
        Me.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.Black
        Me.btnCancel.Location = New System.Drawing.Point(253, 69)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(109, 23)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.BackgroundImage = Global.Random_Item_Giver_Updater.My.Resources.Resources.imgButtonLight
        Me.btnLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLoad.FlatAppearance.BorderSize = 0
        Me.btnLoad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.ForeColor = System.Drawing.Color.Black
        Me.btnLoad.Location = New System.Drawing.Point(138, 69)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(109, 23)
        Me.btnLoad.TabIndex = 7
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'lblLoadProfileFrom
        '
        Me.lblLoadProfileFrom.AutoSize = True
        Me.lblLoadProfileFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadProfileFrom.Location = New System.Drawing.Point(12, 11)
        Me.lblLoadProfileFrom.Name = "lblLoadProfileFrom"
        Me.lblLoadProfileFrom.Size = New System.Drawing.Size(116, 16)
        Me.lblLoadProfileFrom.TabIndex = 5
        Me.lblLoadProfileFrom.Text = "Load profile from..."
        '
        'cbxProfiles
        '
        Me.cbxProfiles.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cbxProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbxProfiles.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxProfiles.FormattingEnabled = True
        Me.cbxProfiles.Items.AddRange(New Object() {"Light", "Dark"})
        Me.cbxProfiles.Location = New System.Drawing.Point(15, 33)
        Me.cbxProfiles.Name = "cbxProfiles"
        Me.cbxProfiles.Size = New System.Drawing.Size(347, 24)
        Me.cbxProfiles.TabIndex = 21
        '
        'frmLoadProfileFrom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(374, 103)
        Me.Controls.Add(Me.cbxProfiles)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.lblLoadProfileFrom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoadProfileFrom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Load profile from..."
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnLoad As Button
    Friend WithEvents lblLoadProfileFrom As Label
    Friend WithEvents cbxProfiles As ComboBox
End Class
