Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CodeCoverageForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            If disposing AndAlso _dT IsNot Nothing Then
                _dT.Dispose()
            End If
            If disposing AndAlso _dV IsNot Nothing Then
                _dV.Dispose()
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
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.DocumentToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.MethodToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Location = New System.Drawing.Point(0, 25)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.Size = New System.Drawing.Size(950, 425)
        Me.TreeView1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.DocumentToolStripComboBox, Me.ToolStripLabel2, Me.MethodToolStripComboBox})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(950, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel1.Text = "Document"
        '
        'DocumentToolStripComboBox
        '
        Me.DocumentToolStripComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.DocumentToolStripComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.DocumentToolStripComboBox.DropDownWidth = 300
        Me.DocumentToolStripComboBox.Name = "DocumentToolStripComboBox"
        Me.DocumentToolStripComboBox.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never
        Me.DocumentToolStripComboBox.Size = New System.Drawing.Size(300, 25)
        Me.DocumentToolStripComboBox.Sorted = True
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripLabel2.Text = "Method"
        '
        'MethodToolStripComboBox
        '
        Me.MethodToolStripComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.MethodToolStripComboBox.DropDownWidth = 450
        Me.MethodToolStripComboBox.Name = "MethodToolStripComboBox"
        Me.MethodToolStripComboBox.Size = New System.Drawing.Size(400, 25)
        Me.MethodToolStripComboBox.Sorted = True
        '
        'CodeCoverageForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(950, 450)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "CodeCoverageForm"
        Me.Text = "Code Coverage"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents DocumentToolStripComboBox As ToolStripComboBox
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents MethodToolStripComboBox As ToolStripComboBox
End Class
