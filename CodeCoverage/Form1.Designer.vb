Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SourceLanguageVB = New System.Windows.Forms.RadioButton()
        Me.SourceLanguageCSharp = New System.Windows.Forms.RadioButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileOpenCoverageFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileLastCoverageFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileOpenLast_jsonFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuFileSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCoverage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCoverageOpenSourceFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuCoverageSep1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnuOptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptionsAdvanced = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuOptionsShowCodeCoverageJson = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabelCodeCoverage = New System.Windows.Forms.Label()
        Me.StatusStripCurrentFileName = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStripSpacer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.RichTextBoxSource = New System.Windows.Forms.RichTextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TSCoverageSummary = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSFilePath = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.LineNumbersForRichTextBoxSource = New LineNumbersForRichTextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SourceLanguageVB
        '
        resources.ApplyResources(Me.SourceLanguageVB, "SourceLanguageVB")
        Me.SourceLanguageVB.Checked = True
        Me.SourceLanguageVB.Name = "SourceLanguageVB"
        Me.SourceLanguageVB.TabStop = True
        Me.SourceLanguageVB.UseVisualStyleBackColor = True
        '
        'SourceLanguageCSharp
        '
        resources.ApplyResources(Me.SourceLanguageCSharp, "SourceLanguageCSharp")
        Me.SourceLanguageCSharp.Name = "SourceLanguageCSharp"
        Me.SourceLanguageCSharp.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(36, 36)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuCoverage, Me.mnuOptions, Me.mnuHelp})
        resources.ApplyResources(Me.MenuStrip1, "MenuStrip1")
        Me.MenuStrip1.Name = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileOpenCoverageFile, Me.mnuFileLastCoverageFile, Me.mnuFileSep1, Me.mnuFileExit})
        Me.mnuFile.Name = "mnuFile"
        resources.ApplyResources(Me.mnuFile, "mnuFile")
        '
        'mnuFileOpenCoverageFile
        '
        Me.mnuFileOpenCoverageFile.Name = "mnuFileOpenCoverageFile"
        resources.ApplyResources(Me.mnuFileOpenCoverageFile, "mnuFileOpenCoverageFile")
        '
        'mnuFileLastCoverageFile
        '
        Me.mnuFileLastCoverageFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFileOpenLast_jsonFile})
        Me.mnuFileLastCoverageFile.Name = "mnuFileLastCoverageFile"
        resources.ApplyResources(Me.mnuFileLastCoverageFile, "mnuFileLastCoverageFile")
        '
        'mnuFileOpenLast_jsonFile
        '
        Me.mnuFileOpenLast_jsonFile.Name = "mnuFileOpenLast_jsonFile"
        resources.ApplyResources(Me.mnuFileOpenLast_jsonFile, "mnuFileOpenLast_jsonFile")
        '
        'mnuFileSep1
        '
        Me.mnuFileSep1.Name = "mnuFileSep1"
        resources.ApplyResources(Me.mnuFileSep1, "mnuFileSep1")
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Name = "mnuFileExit"
        resources.ApplyResources(Me.mnuFileExit, "mnuFileExit")
        '
        'mnuCoverage
        '
        Me.mnuCoverage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuCoverageOpenSourceFile, Me.mnuCoverageSep1})
        resources.ApplyResources(Me.mnuCoverage, "mnuCoverage")
        Me.mnuCoverage.Name = "mnuCoverage"
        '
        'mnuCoverageOpenSourceFile
        '
        Me.mnuCoverageOpenSourceFile.Name = "mnuCoverageOpenSourceFile"
        resources.ApplyResources(Me.mnuCoverageOpenSourceFile, "mnuCoverageOpenSourceFile")
        '
        'mnuCoverageSep1
        '
        Me.mnuCoverageSep1.Name = "mnuCoverageSep1"
        resources.ApplyResources(Me.mnuCoverageSep1, "mnuCoverageSep1")
        '
        'mnuOptions
        '
        Me.mnuOptions.Checked = True
        Me.mnuOptions.CheckOnClick = True
        Me.mnuOptions.CheckState = System.Windows.Forms.CheckState.Checked
        Me.mnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuOptionsAdvanced, Me.mnuOptionsShowCodeCoverageJson})
        resources.ApplyResources(Me.mnuOptions, "mnuOptions")
        Me.mnuOptions.Name = "mnuOptions"
        '
        'mnuOptionsAdvanced
        '
        Me.mnuOptionsAdvanced.Name = "mnuOptionsAdvanced"
        resources.ApplyResources(Me.mnuOptionsAdvanced, "mnuOptionsAdvanced")
        '
        'mnuOptionsShowCodeCoverageJson
        '
        Me.mnuOptionsShowCodeCoverageJson.CheckOnClick = True
        resources.ApplyResources(Me.mnuOptionsShowCodeCoverageJson, "mnuOptionsShowCodeCoverageJson")
        Me.mnuOptionsShowCodeCoverageJson.Name = "mnuOptionsShowCodeCoverageJson"
        '
        'mnuHelp
        '
        Me.mnuHelp.Name = "mnuHelp"
        resources.ApplyResources(Me.mnuHelp, "mnuHelp")
        '
        'LabelCodeCoverage
        '
        resources.ApplyResources(Me.LabelCodeCoverage, "LabelCodeCoverage")
        Me.LabelCodeCoverage.Name = "LabelCodeCoverage"
        '
        'StatusStripCurrentFileName
        '
        Me.StatusStripCurrentFileName.BackColor = System.Drawing.SystemColors.Menu
        Me.StatusStripCurrentFileName.Name = "StatusStripCurrentFileName"
        resources.ApplyResources(Me.StatusStripCurrentFileName, "StatusStripCurrentFileName")
        '
        'StatusStripSpacer
        '
        Me.StatusStripSpacer.BackColor = System.Drawing.SystemColors.MenuBar
        resources.ApplyResources(Me.StatusStripSpacer, "StatusStripSpacer")
        Me.StatusStripSpacer.Name = "StatusStripSpacer"
        Me.StatusStripSpacer.Spring = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'RichTextBoxSource
        '
        resources.ApplyResources(Me.RichTextBoxSource, "RichTextBoxSource")
        Me.RichTextBoxSource.BackColor = System.Drawing.SystemColors.Window
        Me.RichTextBoxSource.DetectUrls = False
        Me.RichTextBoxSource.Name = "RichTextBoxSource"
        Me.RichTextBoxSource.ReadOnly = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSCoverageSummary, Me.TSFilePath, Me.ToolStripProgressBar1})
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.Name = "StatusStrip1"
        '
        'TSCoverageSummary
        '
        Me.TSCoverageSummary.Name = "TSCoverageSummary"
        resources.ApplyResources(Me.TSCoverageSummary, "TSCoverageSummary")
        '
        'TSFilePath
        '
        Me.TSFilePath.Name = "TSFilePath"
        resources.ApplyResources(Me.TSFilePath, "TSFilePath")
        Me.TSFilePath.Spring = True
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        resources.ApplyResources(Me.ToolStripProgressBar1, "ToolStripProgressBar1")
        '
        'LineNumbersForRichTextBoxSource
        '
        Me.LineNumbersForRichTextBoxSource.AutoSizing = True
        Me.LineNumbersForRichTextBoxSource.BackgroundGradientAlphaColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LineNumbersForRichTextBoxSource.BackgroundGradientBetaColor = System.Drawing.Color.LightSteelBlue
        Me.LineNumbersForRichTextBoxSource.BackgroundGradientDirection = System.Drawing.Drawing2D.LinearGradientMode.Horizontal
        Me.LineNumbersForRichTextBoxSource.BorderLinesColor = System.Drawing.Color.SlateGray
        Me.LineNumbersForRichTextBoxSource.BorderLinesStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.LineNumbersForRichTextBoxSource.BorderLinesThickness = 1.0!
        Me.LineNumbersForRichTextBoxSource.DockSide = LineNumbersForRichTextBox.LineNumberDockSides.Left
        Me.LineNumbersForRichTextBoxSource.GridLinesColor = System.Drawing.Color.SlateGray
        Me.LineNumbersForRichTextBoxSource.GridLinesStyle = System.Drawing.Drawing2D.DashStyle.Dot
        Me.LineNumbersForRichTextBoxSource.GridLinesThickness = 1.0!
        Me.LineNumbersForRichTextBoxSource.LineNumbersAlignment = System.Drawing.ContentAlignment.TopRight
        Me.LineNumbersForRichTextBoxSource.LineNumbersAntiAlias = True
        Me.LineNumbersForRichTextBoxSource.LineNumbersAsHexadecimal = False
        Me.LineNumbersForRichTextBoxSource.LineNumbersClippedByItemRectangle = True
        Me.LineNumbersForRichTextBoxSource.LineNumbersLeadingZeroes = True
        Me.LineNumbersForRichTextBoxSource.LineNumbersOffset = New System.Drawing.Size(0, 0)
        resources.ApplyResources(Me.LineNumbersForRichTextBoxSource, "LineNumbersForRichTextBoxSource")
        Me.LineNumbersForRichTextBoxSource.MarginLinesColor = System.Drawing.Color.SlateGray
        Me.LineNumbersForRichTextBoxSource.MarginLinesSide = LineNumbersForRichTextBox.LineNumberDockSides.Right
        Me.LineNumbersForRichTextBoxSource.MarginLinesStyle = System.Drawing.Drawing2D.DashStyle.Solid
        Me.LineNumbersForRichTextBoxSource.MarginLinesThickness = 1.0!
        Me.LineNumbersForRichTextBoxSource.Name = "LineNumbersForRichTextBoxSource"
        Me.LineNumbersForRichTextBoxSource.ParentRichTextBox = Me.RichTextBoxSource
        Me.LineNumbersForRichTextBoxSource.SeeThroughMode = False
        Me.LineNumbersForRichTextBoxSource.ShowBackgroundGradient = True
        Me.LineNumbersForRichTextBoxSource.ShowBorderLines = True
        Me.LineNumbersForRichTextBoxSource.ShowGridLines = True
        Me.LineNumbersForRichTextBoxSource.ShowLineNumbers = True
        Me.LineNumbersForRichTextBoxSource.ShowMarginLines = True
        Me.LineNumbersForRichTextBoxSource.TabStop = False
        '
        'Form1
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.LineNumbersForRichTextBoxSource)
        Me.Controls.Add(Me.RichTextBoxSource)
        Me.Controls.Add(Me.LabelCodeCoverage)
        Me.Controls.Add(Me.SourceLanguageCSharp)
        Me.Controls.Add(Me.SourceLanguageVB)
        Me.Controls.Add(Me.MenuStrip1)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SourceLanguageVB As RadioButton
    Friend WithEvents SourceLanguageCSharp As RadioButton
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents mnuOptions As ToolStripMenuItem
    Friend WithEvents mnuOptionsAdvanced As ToolStripMenuItem
    Friend WithEvents mnuHelp As ToolStripMenuItem
    Friend WithEvents LabelCodeCoverage As Label
    Friend WithEvents mnuFileExit As ToolStripMenuItem
    Friend WithEvents mnuFileSep1 As ToolStripSeparator
    Friend WithEvents mnuFileOpenCoverageFile As ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents mnuFileLastCoverageFile As ToolStripMenuItem
    Friend WithEvents StatusStripCurrentFileName As ToolStripStatusLabel
    Friend WithEvents StatusStripSpacer As ToolStripStatusLabel
    Friend WithEvents mnuCoverage As ToolStripMenuItem
    Friend WithEvents RichTextBoxSource As New System.Windows.Forms.RichTextBox()
    Friend WithEvents LineNumbersForRichTextBoxSource As LineNumbersForRichTextBox
    Friend WithEvents mnuOptionsShowCodeCoverageJson As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents TSCoverageSummary As ToolStripStatusLabel
    Friend WithEvents TSFilePath As ToolStripStatusLabel
    Friend WithEvents mnuFileOpenLast_jsonFile As ToolStripMenuItem
    Friend WithEvents mnuCoverageSep1 As ToolStripSeparator
    Friend WithEvents mnuCoverageOpenSourceFile As ToolStripMenuItem
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
End Class
