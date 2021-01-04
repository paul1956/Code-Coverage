Imports System.IO

Namespace Coverlet.Core

    Partial Public Class CoverletTreeView
        Private Const BranchesTag As String = "Branches:"
        Private Const BranchLine As String = "Branch Line:"
        Private Const ClassesTag As String = "Classes:"
        Private Const CodeCoverageTag As String = "CodeCoverage"
        Private Const DocumentsTag As String = "Documents:"
        Private Const LineTag As String = "Line:"
        Private Const MethodsTag As String = "Methods:"
        Private Const ModulesTag As String = "Modules:"
        Private Shared BranchInfoList As List(Of BranchInfo)

        Friend Sub New(JSONFileWithPath As String, TreeView1 As TreeView, ByRef DocumentList As List(Of DirectoryClass), MethodsList As List(Of MethodClass))
            Dim jsonString As String
            jsonString = File.ReadAllText(JSONFileWithPath)
            DocumentCoverageModifiedDate = File.GetLastWriteTime(JSONFileWithPath)
            DocumentCoverageSummary = New CoverageSummary

            _CodeCoverageRoot = Text.Json.JsonSerializer.Deserialize(Of ModulesDictionary)(jsonString)

            Dim FileInfo As FileInfo = New FileInfo(JSONFileWithPath)
            Dim parentNode As TreeNode = TreeView1.Nodes.Add($"Code Coverage, file {FileInfo.Directory.Name}{Path.PathSeparator}{FileInfo.Name}, Last Updated {FileInfo.LastWriteTime.Date.ToShortDateString} {FileInfo.LastWriteTime.TimeOfDay.Hours}:{FileInfo.LastWriteTime.ToShortTimeString}")
            TreeView1.Nodes(0).Tag = CodeCoverageTag
            populate1ModulesTreeView(CodeCoverageRoot, parentNode, DocumentList, MethodsList)
            parentNode.Expand()
        End Sub

        Public Shared ReadOnly Property CodeCoverageRoot As ModulesDictionary
        Public Shared Property DocumentCoverageModifiedDate As Date
        Public Shared Property DocumentCoverageSummary As CoverageSummary

        Private Shared Function ColorParentNodes(parentNode As TreeNode, NodeColor As Color) As TreeNode
            Dim TempNode As TreeNode = parentNode
            While TempNode IsNot Nothing AndAlso TempNode.Tag?.ToString <> CodeCoverageTag
                If TempNode.BackColor.IsEmpty OrElse NodeColor = CoverageColors.LineHit OrElse NodeColor = CoverageColors.BranchHit OrElse NodeColor = CoverageColors.MethodHit Then
                    TempNode.BackColor = NodeColor
                End If
                If TempNode.Parent Is Nothing Then
                    Return TempNode
                End If
                TempNode = TempNode.Parent
            End While
            Return parentNode
        End Function

        Private Shared Function GetBranchSummary(LineBranchList As List(Of BranchInfo), key As Integer) As String
            LineBranchList.AddRange(BranchInfoList.Where(Function(x) (x.Line = key)))
            If LineBranchList.Count = 0 Then
                Return "Branch= ""False"""
            End If
            Dim HitLines As Integer = LineBranchList.Where(Function(x) (x.Hits > 0)).Count

            Return $"Branch= ""True"" Condition-Coverage=""{CInt((HitLines / LineBranchList.Count) * 100)}%"" ({HitLines}/{LineBranchList.Count}) "
        End Function

        Private Shared Sub populate1ModulesTreeView(childObjects As ModulesDictionary, parentNode As TreeNode, DocumentList As List(Of DirectoryClass), MethodList As List(Of MethodClass))
            If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then
                For Each ngObject As KeyValuePair(Of String, DocumentsDictionary) In childObjects
                    Dim childNode As New TreeNode($"{ModulesTag} {ngObject.Key}") With {
                        .Tag = ModulesTag
                    }
                    parentNode.Nodes.Add(childNode)
                    populate2DocumentsTreeView(ngObject.Value, childNode, DocumentList, MethodList)
                Next
            End If
        End Sub

        Private Shared Sub populate2DocumentsTreeView(childObjects As DocumentsDictionary, parentNode As TreeNode, DocumentList As List(Of DirectoryClass), MethodsList As List(Of MethodClass))
            DocumentList.Add(New DirectoryClass("", "", Nothing))
            If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then
                For Each ngObject As KeyValuePair(Of String, ClassesDictionary) In childObjects
                    Dim DocumentLongName As String = ngObject.Key
                    Dim childNode As New TreeNode($"{DocumentsTag} {DocumentLongName}") With {
                        .Tag = DocumentsTag
                    }
                    DocumentList.Add(New DirectoryClass(Path.GetFileName(ngObject.Key), DocumentLongName, childNode))
                    parentNode.Nodes.Add(childNode)
                    Dim PathToDocument As String = childNode.Text.Substring(DocumentsTag.Length).Trim
                    If Not File.Exists(PathToDocument) Then
                        childNode.Name = $"{DocumentsTag} {PathToDocument} no longer exists"
                        childNode.BackColor = Color.White
                        childNode.ForeColor = Color.Red
                        childNode.ToolTipText = String.Empty
                        'childNode = childNode.Parent
                        Continue For
                    End If
                    If File.GetLastWriteTime(PathToDocument) > DocumentCoverageModifiedDate Then
                        childNode.Name = $"{DocumentsTag} {PathToDocument} does not match coverage files"
                        childNode.BackColor = Color.Yellow
                        childNode.ForeColor = Color.Black
                        childNode.ToolTipText = $"{DocumentsTag} Obsolete: file has changed"
                        'childNode = childNode.Parent
                        Continue For
                    End If
                    Dim ClassCoverageSummary As New CoverageSummary
                    populate3ClassesTreeView(ngObject.Value, childNode, ClassCoverageSummary, MethodsList, DocumentLongName)
                    DocumentCoverageSummary.Add(ClassCoverageSummary)
                Next
                parentNode.ToolTipText = DocumentCoverageSummary.ToString
            End If
        End Sub

        Private Shared Sub populate3ClassesTreeView(childObjects As ClassesDictionary, parentNode As TreeNode, ClassesCoverageSummary As CoverageSummary, MethodsList As List(Of MethodClass), DocumentLongName As String)
            If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then
                For Each ngObject As KeyValuePair(Of String, MethodsDictionary) In childObjects

                    Dim childNode As New TreeNode($"{ClassesTag} {ngObject.Key}") With {
                        .Tag = ClassesTag
                    }
                    parentNode.Nodes.Add(childNode)
                    Dim MethodsCoverageSummary As New CoverageSummary
                    populate4MethodsTreeView(ngObject.Value, childNode, MethodsCoverageSummary, MethodsList, DocumentLongName)
                    ClassesCoverageSummary.Add(MethodsCoverageSummary)
                Next
            End If
            parentNode.ToolTipText = ClassesCoverageSummary.ToString
        End Sub

        Private Shared Sub populate4MethodsTreeView(childObjects As MethodsDictionary, parentNode As TreeNode, ByRef MethodsCoverageSummary As CoverageSummary, MethodsList As List(Of MethodClass), DocumentLongName As String)
            If childObjects IsNot Nothing AndAlso childObjects.Count > 0 Then
                For Each ngObject As KeyValuePair(Of String, Method) In childObjects
                    Dim childNode As New TreeNode($"Methods: {ngObject.Key}") With {
                        .Tag = MethodsTag
                    }
                    MethodsList.Add(New MethodClass(DocumentLongName, childNode, ngObject.Key))
                    parentNode.Nodes.Add(childNode)
                    Dim MethodCoverageSummary As New CoverageSummary
                    populate5MethodTreeView(ngObject.Value, childNode, MethodCoverageSummary)
                    MethodsCoverageSummary.Add(MethodCoverageSummary)
                Next
            End If
            parentNode.ToolTipText = MethodsCoverageSummary.ToString
        End Sub

        Private Shared Sub populate5MethodTreeView(childObjects As Method, parentNode As TreeNode, ByRef MethodCoverageSummary As CoverageSummary)
            If childObjects.Branches.Count > 0 Then
                BranchInfoList = childObjects.Branches.OrderBy(Function(x) x.Line).
                    ThenBy(Function(x) x.Ordinal).
                    ThenBy(Function(x) x.Path).ToList()
            Else
                BranchInfoList = New List(Of BranchInfo)
            End If
            Dim MethodHit As Boolean = False
            If childObjects.Lines.Count > 0 Then
                For Each ngObject As KeyValuePair(Of Integer, Integer) In childObjects.Lines
                    Dim LineBranchList As New List(Of BranchInfo)
                    Dim Node As TreeNode = New TreeNode($"{LineTag} {ngObject.Key}, Hits: {ngObject.Value} branch = {GetBranchSummary(LineBranchList, ngObject.Key)}") With {
                        .Tag = LineTag
                    }
                    If ngObject.Value > 0 Then
                        MethodCoverageSummary.IncrementLinesHit(ngObject.Value)
                        MethodHit = True
                        Node.BackColor = CoverageColors.LineHit
                        parentNode = ColorParentNodes(parentNode, CoverageColors.LineHit)
                    Else
                        Node.BackColor = CoverageColors.LineMissed
                    End If
                    parentNode.Nodes.Add(Node)
                    MethodCoverageSummary.IncrementTotalLines()
                    For Each BranchObject As BranchInfo In LineBranchList
                        MethodHit = MethodHit Or populate6BranchInfoTreeView(BranchObject, Node, MethodCoverageSummary)
                    Next
                Next
            End If
            If MethodHit Then
                MethodCoverageSummary.IncrementMethodsHit()
                parentNode = ColorParentNodes(parentNode, CoverageColors.MethodHit)
            Else
                parentNode = ColorParentNodes(parentNode, CoverageColors.MethodMissed)
            End If
            MethodCoverageSummary.IncrementTotalMethods()
            parentNode.ToolTipText = MethodCoverageSummary.ToString
        End Sub

        ''' <summary>
        ''' Returns True is anything hit
        ''' </summary>
        ''' <param name="childObjects"></param>
        ''' <param name="parentNode"></param>
        Private Shared Function populate6BranchInfoTreeView(childObjects As BranchInfo, parentNode As TreeNode, ByRef MethodCoverageSummary As CoverageSummary) As Boolean
            Dim Hit As Boolean = False
            Dim BackColor As Color = CoverageColors.BranchMissed
            If childObjects IsNot Nothing Then
                If childObjects.Hits > 0 Then
                    MethodCoverageSummary.IncrementBranchesHit()
                    BackColor = CoverageColors.BranchHit
                    Hit = True
                End If
                MethodCoverageSummary.IncrementTotalBranches()
                parentNode.Nodes.Add(New TreeNode($"{BranchesTag} Hits: {childObjects.Hits} Ordinal: {childObjects.Ordinal} Path: {childObjects.Path}") With {
                                     .Tag = BranchLine, .BackColor = BackColor}
                                     )
            End If
            ColorParentNodes(parentNode, BackColor)
            Return Hit
        End Function

        Public Shared Function GetModule(FileNameWithPath As String) As ClassesDictionary
            If CodeCoverageRoot IsNot Nothing AndAlso CodeCoverageRoot.Count > 0 Then
                For Each ngObject As KeyValuePair(Of String, DocumentsDictionary) In CodeCoverageRoot
                    For Each d As KeyValuePair(Of String, ClassesDictionary) In ngObject.Value
                        If d.Key = FileNameWithPath Then
                            Return d.Value
                        End If
                    Next
                Next
            End If
            Return Nothing
        End Function

    End Class

End Namespace
