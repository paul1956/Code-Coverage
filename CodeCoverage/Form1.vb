' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.
Option Explicit On
Option Infer Off
Option Strict On

Imports System.IO

Imports CodeCoverage.Coverlet.Core

Public Class Form1
    Private Const CoverageFileName As String = "Coverage.json"
    Private Const MRUTag As String = "MRU:"
    Private _solutionDirectory As String = ""
    Private _sourceExtension As String
    Public Property LoadedDocument As String
    Private Shared Function GetMenuItemOwnerItem(sender As Object) As ToolStripMenuItem
        Return CType(CType(sender, ToolStripMenuItem).OwnerItem, ToolStripMenuItem)
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Load all settings
        If My.Settings.UpgradeRequired Then
            My.Settings.Upgrade()
            My.Settings.UpgradeRequired = False
            My.Settings.Save()
        End If

        CoverageColorSelector.UpdateColorDictionaryFromFile()
        CodeColorSelector.UpdateColorDictionaryFromFile()

        If String.IsNullOrWhiteSpace(My.Settings.DefaultProjectDirectory) Then
            My.Settings.DefaultProjectDirectory = GetLatestVisualStudioProjectPath()
            My.Settings.Save()
            Application.DoEvents()
        End If
        Dim Last_jsonFile As String = My.Settings.Last_jsonFile
        Last_jsonFile = GetLatestJasonFile(Last_jsonFile)
        Width = Screen.PrimaryScreen.Bounds.Width
        Height = CInt(Screen.PrimaryScreen.Bounds.Height * 0.95)
        CenterToScreen()
    End Sub

    Private Function GetLatestJasonFile(Last_jsonFile As String) As String
        If Not String.IsNullOrWhiteSpace(Last_jsonFile) Then
            Dim TestResultsDirectory As String = ""
            If TryGetResultsDirectory(Last_jsonFile, TestResultsDirectory) Then
                Dim LatestCoverageFileDate As Date = Date.MinValue
                For Each Dir As String In Directory.GetDirectories(TestResultsDirectory)
                    Dim CoverageFileInfo As FileInfo = New FileInfo(Path.Combine(Dir, CoverageFileName))
                    If File.Exists(Path.Combine(Dir, CoverageFileName)) Then
                        If CoverageFileInfo.LastWriteTime >= LatestCoverageFileDate Then
                            LatestCoverageFileDate = CoverageFileInfo.LastWriteTime
                            Last_jsonFile = Path.Combine(Dir, CoverageFileName)
                            mnuFileOpenLast_jsonFile.Tag = Last_jsonFile
                            mnuFileOpenLast_jsonFile.Text = Path.Combine(CoverageFileInfo.Directory.Name, CoverageFileName)
                        End If
                    End If
                Next
            End If
            Dim jsonFileExists As Boolean = Not String.IsNullOrWhiteSpace(Last_jsonFile)
            mnuFileOpenLast_jsonFile.Visible = jsonFileExists
            mnuFileLastCoverageFile.Visible = jsonFileExists
            Application.DoEvents()
        End If
        My.Settings.Last_jsonFile = Last_jsonFile
        Return Last_jsonFile
    End Function

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        ResizeRichTextBuffers()
    End Sub

    Private Function GetSolutionDirectory(FullPath As String) As String
        Dim FullDirectoryName As String = New FileInfo(FullPath).Directory.FullName
        While FullDirectoryName.Length > 0
            If Directory.GetFiles(FullDirectoryName, "*.sln").Any Then
                Return FullDirectoryName
            End If
            FullDirectoryName = Directory.GetParent(FullDirectoryName)?.FullName
        End While
        Return ""
    End Function

    Private Sub LineNumbers_For_RichTextBoxSource_Resize(sender As Object, e As EventArgs) Handles LineNumbersForRichTextBoxSource.Resize
        ResizeRichTextBuffers()
    End Sub

    Private Sub mnu_MRUList_Click(sender As Object, e As EventArgs)
        ' open the file...
        MRU_AddTo(LoadedDocument, GetMenuItemOwnerItem(sender))
        LoadedDocument = CType(sender, ToolStripMenuItem).Text

        LoadDocument(Me)
    End Sub

    Friend Sub LoadDocument(MeForm As Form1)
        MeForm.Invoke(Sub()
                          'safe to access the form or controls in here
                          MeForm.LineNumbersForRichTextBoxSource.Visible = False
                          MeForm.ResizeRichTextBuffers()
                          Colorize(MeForm.RichTextBoxSource, MeForm.LoadedDocument, MeForm.ToolStripProgressBar1)
                          MeForm.LineNumbersForRichTextBoxSource.Visible = True
                          MeForm.ResizeRichTextBuffers()
                          MeForm.TSCoverageSummary.Text = $"{MeForm.LoadedDocument} Coverage - {CoverletTreeView.DocumentCoverageSummary}"
                          MeForm.TSFilePath.Text = LoadedDocument
                      End Sub)
    End Sub

    Private Sub mnu_MRUList_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Clipboard.SetText(CType(sender, ToolStripMenuItem).Text)
        End If
    End Sub

    Private Sub mnuCoverageOpenSourceFile_Click(sender As Object, e As EventArgs) Handles mnuCoverageOpenSourceFile.Click
        Dim LanguageExtension As String = _sourceExtension
        With OpenFileDialog1
            .AddExtension = True
            If .InitialDirectory.Length = 0 Then
                .InitialDirectory = _solutionDirectory
            End If
            .DefaultExt = LanguageExtension
            .FileName = ""
            .Filter = If(LanguageExtension = "vb", "VB Code Files (*.vb)|*.vb", "C# Code Files (*.cs)|*.cs")
            .Multiselect = False
            .ReadOnlyChecked = True
            .Title = $"Open {LanguageExtension.ToUpperInvariant} Source file"
            .ValidateNames = True
            If .ShowDialog = DialogResult.OK Then
                MRU_AddTo(OpenFileDialog1.FileName, GetMenuItemOwnerItem(sender))
                LineNumbersForRichTextBoxSource.Visible = False
                ResizeRichTextBuffers()
                Colorize(RichTextBoxSource, OpenFileDialog1.FileName, ToolStripProgressBar1)
                LineNumbersForRichTextBoxSource.Visible = True
                ResizeRichTextBuffers()
                With CoverletTreeView.DocumentCoverageSummary
                    TSCoverageSummary.Text = $"Document Coverage - {CoverletTreeView.DocumentCoverageSummary}"
                End With
                TSFilePath.Text = OpenFileDialog1.FileName
            End If
        End With
    End Sub

    Private Sub mnuFileExit_Click(sender As Object, e As EventArgs) Handles mnuFileExit.Click
        Close()
        End
    End Sub

    Private Sub mnuFileOpenCoverageFile_Click(sender As Object, e As EventArgs) Handles mnuFileOpenCoverageFile.Click
        With OpenFileDialog1
            .AddExtension = True
            .DefaultExt = "json"
            .FileName = "coverage"
            .Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
            .FilterIndex = 0
            .Multiselect = False
            .ReadOnlyChecked = True
            .Title = $"Open {CoverageFileName}"
            .ValidateNames = True
            If String.IsNullOrEmpty(.InitialDirectory) Then
                .InitialDirectory = My.Settings.DefaultProjectDirectory
            End If
            If .ShowDialog = DialogResult.OK Then
                mnuCoverage.Enabled = Not String.IsNullOrWhiteSpace(_solutionDirectory)
                _solutionDirectory = GetSolutionDirectory(OpenFileDialog1.FileName)
                OpenCoverageFileAndLoadTreeView(OpenFileDialog1.FileName)
            End If
        End With
    End Sub

    Private Sub mnuFileOpenLast_jsonFile_Click(sender As Object, e As EventArgs) Handles mnuFileOpenLast_jsonFile.Click
        Dim CoverageFileNameWithPath As String = CType(sender, ToolStripMenuItem).Tag.ToString
        Dim FileInfo As FileInfo = New FileInfo(CoverageFileNameWithPath)
        Text = $"Code Coverage, file {FileInfo.Name}, Last Updated {FileInfo.LastWriteTime.Date.ToShortDateString} {FileInfo.LastWriteTime.TimeOfDay.Hours}:{FileInfo.LastWriteTime.ToShortTimeString}"
        OpenCoverageFileAndLoadTreeView(CoverageFileNameWithPath)
    End Sub

    Private Sub mnuOptionsShowCodeCoverageJson_Click(sender As Object, e As EventArgs) Handles mnuOptionsShowCodeCoverageJson.Click
        CodeCoverageForm.Visible = mnuOptionsShowCodeCoverageJson.Checked
    End Sub

    Private Sub MRU_AddTo(Path As String, TopLevelMenu As ToolStripMenuItem)
        StatusStripCurrentFileName.Text = Path
        ' remove the item from the collection if exists so that we can
        ' re-add it to the beginning...
        If My.Settings.MRU_Data.Contains(Path) Then
            My.Settings.MRU_Data.Remove(Path)
        End If
        ' add to MRU list..
        My.Settings.MRU_Data.Add(Path)
        ' make sure there are only ever 5 items...
        While My.Settings.MRU_Data.Count > 5
            My.Settings.MRU_Data.RemoveAt(0)
        End While
        ' update UI..
        MRU_Update(TopLevelMenu)
    End Sub

    Private Sub MRU_Update(TopLevelMenu As ToolStripMenuItem)
        Dim Seperator As ToolStripSeparator = Nothing
        ' clear MRU menu items...
        Dim clsItems As New List(Of ToolStripItem)
        ' create a temporary collection containing every MRU menu item
        ' (identified by the tag text when added to the list)...
        For Each clsMenu As ToolStripItem In TopLevelMenu.DropDownItems
            If TypeOf clsMenu Is ToolStripSeparator Then
                Seperator = CType(clsMenu, ToolStripSeparator)
            End If
            If Not clsMenu.Tag Is Nothing Then
                If clsMenu.Tag.ToString().StartsWith(MRUTag, StringComparison.InvariantCulture) Then
                    clsItems.Add(clsMenu)
                End If
            End If
        Next
        ' iterate through list and remove each from menu...
        For Each clsMenu As ToolStripItem In clsItems
            RemoveHandler clsMenu.Click, AddressOf mnu_MRUList_Click
            RemoveHandler clsMenu.MouseDown, AddressOf mnu_MRUList_MouseDown
            TopLevelMenu.DropDownItems.Remove(clsMenu)
        Next
        ' display items (in reverse order so the most recent is on top)...
        For iCounter As Integer = My.Settings.MRU_Data.Count - 1 To 0 Step -1
            Dim sPath As String = My.Settings.MRU_Data(iCounter)
            ' create new ToolStripItem, displaying the name of the file...
            ' set the tag - identifies the ToolStripItem as an MRU item and
            ' contains the full path so it can be opened later...
            If File.Exists(sPath) Then

#Disable Warning CA2000 ' Dispose objects before losing scope
                Dim clsItem As New ToolStripMenuItem(sPath) With {
                .Tag = MRUTag & sPath
                }
#Enable Warning CA2000 ' Dispose objects before losing scope
                ' hook into the click event handler so we can open the file later...
                AddHandler clsItem.Click, AddressOf mnu_MRUList_Click
                AddHandler clsItem.MouseDown, AddressOf mnu_MRUList_MouseDown
                ' insert into DropDownItems list...
                TopLevelMenu.DropDownItems.Insert(TopLevelMenu.DropDownItems.Count, clsItem)
            End If
        Next
        ' show separator...
        My.Settings.Save()
        If My.Settings.MRU_Data.Count > 0 Then
            Seperator.Visible = True
        Else
            Seperator.Visible = False
        End If
    End Sub

    Private Sub OpenCoverageFileAndLoadTreeView(FileWithPath As String)
        My.Settings.Last_jsonFile = FileWithPath
        My.Settings.Save()
        CodeCoverageForm.RTFForm = Me
        CodeCoverageForm.LoadJSONFile(FileWithPath)
        CodeCoverageForm.Show()
        mnuCoverage.Enabled = True
    End Sub

    Private Sub ResizeRichTextBuffers()
        Dim LineNumberInputWidth As Integer = If(LineNumbersForRichTextBoxSource.Visible, LineNumbersForRichTextBoxSource.Width, 0)
        RichTextBoxSource.Width = ClientSize.Width - LineNumberInputWidth
        RichTextBoxSource.Left = LineNumberInputWidth
        RichTextBoxSource.Height = ClientRectangle.Height - (MenuStrip1.Height + StatusStrip1.Height + 2)
        Application.DoEvents()
    End Sub

    Private Sub SourceLanguageCSharp_CheckedChanged(sender As Object, e As EventArgs) Handles SourceLanguageCSharp.CheckedChanged
        If CType(sender, RadioButton).Checked Then
            RichTextBoxSource.Text = ""
            Text = "C#"
            _sourceExtension = "cs"
            SourceLanguageVB.Checked = False
        End If
    End Sub

    Private Sub SourceLanguageVB_CheckedChanged(sender As Object, e As EventArgs) Handles SourceLanguageVB.CheckedChanged
        If CType(sender, RadioButton).Checked Then
            RichTextBoxSource.Text = ""
            Text = "Visual Basic"
            _sourceExtension = "vb"
            SourceLanguageCSharp.Checked = False
        End If
    End Sub

    Private Sub StatusStripCurrentFileName_MouseDown(sender As Object, e As MouseEventArgs) Handles StatusStripCurrentFileName.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Clipboard.SetText(text:=CType(sender, ToolStripStatusLabel).Text)
        End If
    End Sub

    Private Shared Function TryGetResultsDirectory(Last_jsonFile As String, ByRef TestResultsDirectory As String) As Boolean
        Dim TestResultsDirectoryInfo As DirectoryInfo = Directory.GetParent(Last_jsonFile).Parent
        If TestResultsDirectoryInfo.Name = "TestResults" Then
            TestResultsDirectory = TestResultsDirectoryInfo.FullName
            Return True
        End If
        Return False
    End Function

    Protected Overrides Sub OnLoad(e As EventArgs)
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        ' enable events...
        MyBase.OnLoad(e)

        ' load MRU...
        If My.Settings.MRU_Data Is Nothing Then
            My.Settings.MRU_Data = New Specialized.StringCollection
        End If
        ' display MRU if there are any items to display...
        MRU_Update(mnuCoverage)
    End Sub

    Private Sub MnuOptionsAdvanced_Click(sender As Object, e As EventArgs) Handles mnuOptionsAdvanced.Click
        OptionsDialog.ShowDialog(Me)
    End Sub

    Private Sub MnuFile_Click(sender As Object, e As EventArgs) Handles mnuFile.Click
        GetLatestJasonFile(My.Settings.Last_jsonFile)
    End Sub

End Class
