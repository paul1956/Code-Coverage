Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class OptionsDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.ProjectDirectoryList = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.CodeCoverageComboBox = New System.Windows.Forms.ComboBox()
        Me.CodeCoverageLabel = New System.Windows.Forms.Label()
        Me.UpdateCodeCoverageColorButton = New System.Windows.Forms.Button()
        Me.SyntaxHighlighingColorsLabel = New System.Windows.Forms.Label()
        Me.SyntaxHighlighingColorsComboBox = New System.Windows.Forms.ComboBox()
        Me.UpdateSyntaxHighlighingColorsButton = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(362, 323)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(170, 33)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(4, 3)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(77, 27)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(89, 3)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(77, 27)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'ProjectDirectoryList
        '
        Me.ProjectDirectoryList.FormattingEnabled = True
        Me.ProjectDirectoryList.Location = New System.Drawing.Point(233, 17)
        Me.ProjectDirectoryList.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ProjectDirectoryList.Name = "ProjectDirectoryList"
        Me.ProjectDirectoryList.Size = New System.Drawing.Size(256, 23)
        Me.ProjectDirectoryList.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Directory to Start Folder Search"
        '
        'ColorDialog1
        '
        Me.ColorDialog1.AnyColor = True
        Me.ColorDialog1.FullOpen = True
        '
        'CodeCoverageComboBox
        '
        Me.CodeCoverageComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CodeCoverageComboBox.DropDownHeight = 400
        Me.CodeCoverageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CodeCoverageComboBox.DropDownWidth = 300
        Me.CodeCoverageComboBox.FormattingEnabled = True
        Me.CodeCoverageComboBox.IntegralHeight = False
        Me.CodeCoverageComboBox.Location = New System.Drawing.Point(35, 137)
        Me.CodeCoverageComboBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.CodeCoverageComboBox.MaxDropDownItems = 20
        Me.CodeCoverageComboBox.Name = "CodeCoverageComboBox"
        Me.CodeCoverageComboBox.Size = New System.Drawing.Size(454, 24)
        Me.CodeCoverageComboBox.TabIndex = 3
        '
        'CodeCoverageLabel
        '
        Me.CodeCoverageLabel.AutoSize = True
        Me.CodeCoverageLabel.Location = New System.Drawing.Point(35, 115)
        Me.CodeCoverageLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CodeCoverageLabel.Name = "CodeCoverageLabel"
        Me.CodeCoverageLabel.Size = New System.Drawing.Size(125, 15)
        Me.CodeCoverageLabel.TabIndex = 4
        Me.CodeCoverageLabel.Text = "Code Coverage Colors"
        '
        'UpdateCodeCoverageColorButton
        '
        Me.UpdateCodeCoverageColorButton.Location = New System.Drawing.Point(312, 97)
        Me.UpdateCodeCoverageColorButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.UpdateCodeCoverageColorButton.Name = "UpdateCodeCoverageColorButton"
        Me.UpdateCodeCoverageColorButton.Size = New System.Drawing.Size(177, 27)
        Me.UpdateCodeCoverageColorButton.TabIndex = 5
        Me.UpdateCodeCoverageColorButton.Text = "Update Code Coverage Color"
        Me.UpdateCodeCoverageColorButton.UseVisualStyleBackColor = True
        '
        'SyntaxHighlighingColorsLabel
        '
        Me.SyntaxHighlighingColorsLabel.AutoSize = True
        Me.SyntaxHighlighingColorsLabel.Location = New System.Drawing.Point(35, 197)
        Me.SyntaxHighlighingColorsLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.SyntaxHighlighingColorsLabel.Name = "SyntaxHighlighingColorsLabel"
        Me.SyntaxHighlighingColorsLabel.Size = New System.Drawing.Size(145, 15)
        Me.SyntaxHighlighingColorsLabel.TabIndex = 6
        Me.SyntaxHighlighingColorsLabel.Text = "Syntax Highlighing Colors"
        '
        'SyntaxHighlighingColorsComboBox
        '
        Me.SyntaxHighlighingColorsComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.SyntaxHighlighingColorsComboBox.DropDownHeight = 400
        Me.SyntaxHighlighingColorsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SyntaxHighlighingColorsComboBox.DropDownWidth = 300
        Me.SyntaxHighlighingColorsComboBox.FormattingEnabled = True
        Me.SyntaxHighlighingColorsComboBox.IntegralHeight = False
        Me.SyntaxHighlighingColorsComboBox.Location = New System.Drawing.Point(35, 224)
        Me.SyntaxHighlighingColorsComboBox.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.SyntaxHighlighingColorsComboBox.MaxDropDownItems = 20
        Me.SyntaxHighlighingColorsComboBox.Name = "SyntaxHighlighingColorsComboBox"
        Me.SyntaxHighlighingColorsComboBox.Size = New System.Drawing.Size(454, 24)
        Me.SyntaxHighlighingColorsComboBox.TabIndex = 7
        '
        'UpdateSyntaxHighlighingColorsButton
        '
        Me.UpdateSyntaxHighlighingColorsButton.Location = New System.Drawing.Point(312, 186)
        Me.UpdateSyntaxHighlighingColorsButton.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.UpdateSyntaxHighlighingColorsButton.Name = "UpdateSyntaxHighlighingColorsButton"
        Me.UpdateSyntaxHighlighingColorsButton.Size = New System.Drawing.Size(177, 27)
        Me.UpdateSyntaxHighlighingColorsButton.TabIndex = 8
        Me.UpdateSyntaxHighlighingColorsButton.Text = "Update Syntax Highlighing Colors"
        Me.UpdateSyntaxHighlighingColorsButton.UseVisualStyleBackColor = True
        '
        'OptionsDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(546, 370)
        Me.Controls.Add(Me.UpdateSyntaxHighlighingColorsButton)
        Me.Controls.Add(Me.SyntaxHighlighingColorsComboBox)
        Me.Controls.Add(Me.SyntaxHighlighingColorsLabel)
        Me.Controls.Add(Me.UpdateCodeCoverageColorButton)
        Me.Controls.Add(Me.CodeCoverageLabel)
        Me.Controls.Add(Me.CodeCoverageComboBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProjectDirectoryList)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "OptionsDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Options"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents ProjectDirectoryList As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents CodeCoverageComboBox As ComboBox
    Friend WithEvents CodeCoverageLabel As Label
    Friend WithEvents UpdateCodeCoverageColorButton As Button
    Friend WithEvents SyntaxHighlighingColorsLabel As Label
    Friend WithEvents SyntaxHighlighingColorsComboBox As ComboBox
    Friend WithEvents UpdateSyntaxHighlighingColorsButton As Button
End Class
