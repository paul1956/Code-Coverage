Imports System.ComponentModel
Imports CodeCoverage.Coverlet.Core

Public Class CodeCoverageForm
    Private WithEvents BackgroundWorker1 As New BackgroundWorker
    Private ReadOnly _documentList As New List(Of DirectoryClass)
    Private ReadOnly _documentsStrLength As Integer = "Documents: ".Length

    Private ReadOnly _methodArrayList As New List(Of MethodClass)
    Private _dT As DataTable
    Private _dV As DataView
    Public Property CoverletResult As CoverletTreeView
    Public Property Initializing As Boolean = True
    Public Property RTFForm As Form1

    Private Shared Function GetTable(MethodList As List(Of MethodClass)) As DataTable
        ' Create new DataTable instance.
        Dim table As New DataTable
        If MethodList Is Nothing Then
            Return table
        End If
        ' Create four typed columns in the DataTable.
        table.Columns.Add("DocumentLongName", GetType(String))
        table.Columns.Add("MethodLongName", GetType(String))
        table.Columns.Add("MethodNode", GetType(TreeNode))
        table.Columns.Add("MethodShortName", GetType(String))

        table.Rows.Add("", "", Nothing, Nothing)
        For Each m As MethodClass In MethodList
            table.Rows.Add(m.DocumentLongName, m.MethodLongName, m.MethodNode, m.MethodShortName)
        Next
        Return table
    End Function

    Private Sub backgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ' Get the BackgroundWorker object that raised this event.
        RTFForm.LoadDocument(CType(e.Argument, Form1))
    End Sub

    Private Sub CodeCoverageForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If RTFForm Is Nothing Then
            RTFForm = New Form1
        End If
        TopMost = True
        Left = RTFForm.Right - (Width + 20)
        Top = RTFForm.Top + RTFForm.ToolStripProgressBar1.Height + (RTFForm.Height - RTFForm.ClientRectangle.Height)
        ToolStrip1.CanOverflow = True
        ToolStripLabel1.Overflow = ToolStripItemOverflow.Never
        ToolStripLabel2.Overflow = ToolStripItemOverflow.Never
        DocumentToolStripComboBox.AutoCompleteMode = AutoCompleteMode.Append
        MethodToolStripComboBox.AutoCompleteMode = AutoCompleteMode.Append
    End Sub

    Private Sub CodeCoverageForm_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        RTFForm.mnuOptionsShowCodeCoverageJson.Checked = Visible
    End Sub

    Private Sub DocumentToolStripComboBox_DropDown(sender As Object, e As EventArgs) Handles DocumentToolStripComboBox.DropDown
        Dim ToolStripCombo As ToolStripComboBox = CType(sender, ToolStripComboBox)
        Using graphics As Graphics = CreateGraphics()
            Dim maxWidth As Integer = 0
            For Each drv As DirectoryClass In ToolStripCombo.Items
                Dim area As SizeF = graphics.MeasureString(drv.ShortName, ToolStripCombo.Font)
                maxWidth = Math.Max(CInt(Math.Round(area.Width + 1)), maxWidth)
            Next drv
            ToolStripCombo.DropDownWidth = maxWidth + SystemInformation.VerticalScrollBarWidth
        End Using
    End Sub

    Private Sub DocumentToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DocumentToolStripComboBox.SelectedIndexChanged
        If Initializing Then
            Return
        End If
        Initializing = True
        Dim SelectedItem As DirectoryClass = CType(DocumentToolStripComboBox.SelectedItem, DirectoryClass)
        LoadDocumentIfNeeded(SelectedItem.FullPath)

        TreeView1.HideSelection = False
        TreeView1.SelectedNode = SelectedItem.DirectoryNode
        If SelectedItem.DirectoryNode IsNot Nothing Then
            TreeView1.SelectedNode.EnsureVisible()
            _dV.RowFilter = $"DocumentLongName = '{SelectedItem.FullPath}'"
        Else
            _dV.RowFilter = ""
        End If
        MethodToolStripComboBox.ComboBox.DataSource = _dV
        MethodToolStripComboBox.ComboBox.DisplayMember = "MethodShortName"
        MethodToolStripComboBox.SelectedIndex = -1
        Initializing = False
    End Sub

    Private Sub GotoLine(RTF_Box As RichTextBox, WantedLine_One_Based As Integer)
        Dim index As Integer = RTF_Box.GetFirstCharIndexFromLine(WantedLine_One_Based - 1)
        While index < RTF_Box.TextLength - 1
            If RTF_Box.Text.Substring(index, 1) <> " " Then
                Exit While
            End If
            index += 1
        End While
        RTF_Box.HideSelection = False
        RTF_Box.Select(index, 0)
        RTF_Box.ScrollToCaret()
        RTF_Box.Focus()
        Application.DoEvents()
    End Sub

    Private Sub LoadDocumentIfNeeded(DocumentName As String)
        If RTFForm.LoadedDocument <> DocumentName Then
            RTFForm.LoadedDocument = DocumentName
            If String.IsNullOrWhiteSpace(DocumentName) Then
                RTFForm.Text = ""
            Else
                ' Start the asynchronous operation.
                BackgroundWorker1.RunWorkerAsync(RTFForm)
                Cursor = Cursors.WaitCursor
                While BackgroundWorker1.IsBusy
                    Application.DoEvents()
                End While
                Cursor = Cursors.Default
                Application.DoEvents()
            End If
        End If
    End Sub

    Private Sub MethodToolStripComboBox_DropDown(sender As Object, e As EventArgs) Handles MethodToolStripComboBox.DropDown
        Dim ToolStripCombo As ToolStripComboBox = CType(sender, ToolStripComboBox)
        Using graphics As Graphics = CreateGraphics()
            Dim maxWidth As Integer = 0

            For Each SelectedItem As DataRowView In ToolStripCombo.Items
                Dim area As SizeF = graphics.MeasureString(SelectedItem.Item("MethodShortName").ToString(), ToolStripCombo.Font)
                Dim StringLength As Integer = CInt(Math.Round(area.Width + 1))
                If StringLength > maxWidth Then
                    maxWidth = StringLength
                End If
            Next
            ToolStripCombo.DropDownWidth = maxWidth + SystemInformation.VerticalScrollBarWidth
        End Using
    End Sub

    Private Sub MethodToolStripComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles MethodToolStripComboBox.SelectedIndexChanged
        If Initializing Then
            Return
        End If
        Dim TB As ToolStripComboBox = DirectCast(sender, ToolStripComboBox)
        If TB.SelectedIndex = -1 Then
            Return
        End If
        Dim SelectedItem As DataRowView = CType(TB.SelectedItem, DataRowView)
        If SelectedItem Is Nothing Then
            Exit Sub
        End If
        Dim MethodLongName As String = SelectedItem("MethodLongName").ToString
        TB.ToolTipText = MethodLongName
        Dim Node As TreeNode = _methodArrayList.Find(Function(x As MethodClass) x?.MethodLongName = MethodLongName)?.MethodNode
        If Node Is Nothing Then
            Exit Sub
        End If
        TreeView1.HideSelection = False
        TreeView1.SelectedNode = Node
        TreeView1.SelectedNode.EnsureVisible()
        LoadDocumentIfNeeded(Node.Parent.Parent.Text.Substring(_documentsStrLength))
        Dim PossibleLineNode As String = Node.Nodes(0)?.Tag?.ToString.Trim
        If PossibleLineNode = "Line:" Then
            Dim OneBasedLine As String = Node.Nodes(0).Text.Split(","c)(0).Substring("Line: ".Length)
            GotoLine(RTFForm.RichTextBoxSource, CInt(OneBasedLine))
        End If
    End Sub

    Private Sub TreeView1_DoubleClick(sender As Object, e As EventArgs) Handles TreeView1.DoubleClick
        If BackgroundWorker1.IsBusy Then
            Return
        End If
        Dim Node As TreeNode = CType(sender, TreeView).SelectedNode

        Select Case Node.Tag?.ToString.Trim
            Case "Modules:"
                ' Ignore
            Case "Documents:"
                LoadDocumentIfNeeded(Node.Text.Substring(_documentsStrLength))
            Case "Classes:"
                LoadDocumentIfNeeded(Node.Parent.Text.Substring(_documentsStrLength))
            Case "Methods:"
                LoadDocumentIfNeeded(Node.Parent.Parent.Text.Substring(_documentsStrLength))
            Case "Line:"
                LoadDocumentIfNeeded(Node.Parent.Parent.Parent.Text.Substring(_documentsStrLength))
                Dim OneBasedLine As String = Node.Text.Split(","c)(0).Substring("Line: ".Length)
                GotoLine(RTFForm.RichTextBoxSource, CInt(OneBasedLine))
            Case "Branches:"
                ' Ignore
            Case "Branch Line:"
                LoadDocumentIfNeeded(Node.Parent.Parent.Parent.Parent.Text.Substring(_documentsStrLength))
                Dim OneBasedLine As String = Node.Parent.Text.Split(","c)(0).Substring("Line: ".Length)
                GotoLine(RTFForm.RichTextBoxSource, CInt(OneBasedLine))
            Case "Offset: "
                ' Ignore
            Case "End Offset:"
                ' Ignore
            Case "Path:"
                ' Ignore
            Case "Ordinal:"
                ' Ignore
            Case "Hits:"
                ' Ignore
            Case Else
                ' Ignore
        End Select

    End Sub

    Public Sub LoadJSONFile(FileWithPath As String)
        CoverletResult = New CoverletTreeView(FileWithPath, TreeView1, _documentList, _methodArrayList)
        DocumentToolStripComboBox.ComboBox.DisplayMember = "ShortName"
        DocumentToolStripComboBox.ComboBox.ValueMember = "FullPath"
        DocumentToolStripComboBox.ComboBox.DataSource = _documentList

        MethodToolStripComboBox.ComboBox.DisplayMember = "MethodShortName"
        MethodToolStripComboBox.ComboBox.ValueMember = "MethodNode"

        _dT = GetTable(_methodArrayList)
        _dV = New DataView(_dT) With {
            .RowFilter = Nothing
        }
        DocumentToolStripComboBox.SelectedIndex = -1
        MethodToolStripComboBox.ComboBox.DataSource = _dT
        MethodToolStripComboBox.SelectedIndex = -1
        Initializing = False
    End Sub

    Private Sub CodeCoverageForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        _dT.Dispose()
        _dV.Dispose()
    End Sub

End Class
