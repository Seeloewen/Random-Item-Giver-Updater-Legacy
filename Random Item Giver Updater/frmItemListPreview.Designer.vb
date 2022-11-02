<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemListPreview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmItemListPreview))
        Me.gbItemList = New System.Windows.Forms.GroupBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.rtbItems = New System.Windows.Forms.RichTextBox()
        Me.gbItemList.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbItemList
        '
        Me.gbItemList.Controls.Add(Me.rtbItems)
        Me.gbItemList.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbItemList.Location = New System.Drawing.Point(13, 13)
        Me.gbItemList.Name = "gbItemList"
        Me.gbItemList.Size = New System.Drawing.Size(566, 390)
        Me.gbItemList.TabIndex = 0
        Me.gbItemList.TabStop = False
        Me.gbItemList.Text = "Item list"
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(227, 411)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(132, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'rtbItems
        '
        Me.rtbItems.BackColor = System.Drawing.Color.White
        Me.rtbItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbItems.Location = New System.Drawing.Point(6, 25)
        Me.rtbItems.Name = "rtbItems"
        Me.rtbItems.ReadOnly = True
        Me.rtbItems.Size = New System.Drawing.Size(554, 359)
        Me.rtbItems.TabIndex = 0
        Me.rtbItems.Text = ""
        '
        'frmItemListPreview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(591, 446)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.gbItemList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemListPreview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item List Importer - List Preview"
        Me.gbItemList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gbItemList As GroupBox
    Friend WithEvents rtbItems As RichTextBox
    Friend WithEvents btnOK As Button
End Class
