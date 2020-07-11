' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.
Imports System.IO
Imports System.Runtime.CompilerServices

Imports CodeCoverage
Imports CodeCoverage.Coverlet.Core

Imports Microsoft.CodeAnalysis

Imports VBMsgBox

Public Module ColorRTB

    Private Sub BuildLineTables(ConversionBuffer As RichTextBox, ByRef LineStarts() As Integer, ByRef LineEnds() As Integer)
        Dim MaxLines As Integer = ConversionBuffer.Lines.Length
        'The True Line Numbers In A conversionBuffer Start At 0, This Essentially
        'Makes It To Where You Can Specify Line 1 And Be Highlighting Line 0
        'In All Actuality
        'To Handle Out Of Range Errors, We Will Exit The Sub If The LineNumber Is
        'Greater Than The Highest Available Line In The conversionBuffer
        'We Begin Indexing The Start And End Points For Each Line
        For I As Integer = 0 To ConversionBuffer.Lines.Length - 1
            'We Index Each Lines Starting Point Here
            LineStarts(I) = ConversionBuffer.GetFirstCharIndexFromLine(I)
            'Determine If We Are At The Last Line In The conversionBuffer
            If I < ConversionBuffer.Lines.Length - 1 Then
                'For All Of The Line Endings, Except For The Last One, We Are Using
                'The Beginning Of The Next Line - 1 To Determine Our Ending For The
                'Current Line.
                'Assign The EndingPoint For The Current Line
                LineEnds(I) = ConversionBuffer.GetFirstCharIndexFromLine(I + 1) - 1
            Else
                'The Last Line's Ending Point Will Be The Length Of The Entire
                'Text In The conversionBuffer
                'Assign The EndingPoint For The Last Line
                LineEnds(I) = ConversionBuffer.Text.Length
            End If
        Next

    End Sub

    Private Function ProcessMethod(conversionBuffer As RichTextBox, lineStarts() As Integer, lineEnds() As Integer, method As Method) As CoverageSummary
        Dim MethodSummary As New CoverageSummary
        conversionBuffer.HideSelection = False
        For Each line As KeyValuePair(Of Integer, Integer) In method.Lines
            Dim LineNumber As Integer = line.Key - 1
            If LineNumber > conversionBuffer.Lines.Length - 1 Then
                MsgBox("Line number greater then number of lines in buffer.", Title:="In Process Method")
                Return New CoverageSummary
            End If
            conversionBuffer.SelectionStart = lineStarts(LineNumber)
            ' The Length Is The Difference Between The LineEnds And LineStarts Arrays
            conversionBuffer.SelectionLength = lineEnds(LineNumber) - lineStarts(LineNumber)
            Dim SpaceLength As Integer = conversionBuffer.SelectedText.SpaceCount

            conversionBuffer.SelectionLength = 2
            If line.Value > 0 Then
                conversionBuffer.SelectionBackColor = CoverageColors.LineHit
                MethodSummary.IncrementLinesHit(line.Value)
            Else
                conversionBuffer.SelectionBackColor = CoverageColors.LineMissed
            End If
            MethodSummary.IncrementTotalLines()
        Next
        For Each Branch As BranchInfo In method.Branches
            Dim LineNumber As Integer = Branch.Line - 1
            If LineNumber > conversionBuffer.Lines.Length - 1 Then
                MsgBox("Branch Line greater then number of lines in buffer.", Title:="In Process Method")
                Return New CoverageSummary
            End If
            'Set The Selection Starting Point From The Newly Created LineStarts Array
            conversionBuffer.SelectionStart = lineStarts(LineNumber)
            'Set The Selection Length From The Newly Created Arrays
            ' The Length Is The Difference Between The LineEnds And LineStarts Arrays
            conversionBuffer.SelectionLength = lineEnds(LineNumber) - lineStarts(LineNumber)
            Dim SpaceLength As Integer = conversionBuffer.SelectedText.SpaceCount
            If Branch.Hits > 0 Then
                conversionBuffer.SelectionStart += 2
                conversionBuffer.SelectionLength = 2
                conversionBuffer.SelectionBackColor = CoverageColors.BranchHit
                MethodSummary.IncrementBranchesHit()
            Else
                conversionBuffer.SelectionStart += 4
                conversionBuffer.SelectionLength = 2
                conversionBuffer.SelectionBackColor = CoverageColors.BranchMissed
            End If
            MethodSummary.IncrementTotalBranches()
        Next
        If MethodSummary.LinesHit > 0 OrElse MethodSummary.BranchesHit > 0 Then
            MethodSummary.IncrementMethodsHit()
        End If
        MethodSummary.IncrementTotalMethods()
        Return MethodSummary
    End Function

    <Extension>
    Private Function SpaceCount(LineText As String) As Integer
        If Not LineText.Any Then
            Return 0
        End If
        For i As Integer = 0 To LineText.Length - 1
            If LineText(i) = " " Then
                Continue For
            End If
            Return i
        Next
        Return LineText.Length - 1
    End Function

    Friend Sub Colorize(CallingForm As Form1, TextToCompile As String, ConversionBuffer As RichTextBox, FileName As String, ProgressBar As ToolStripProgressBar)
        Dim FileSummaryStaticics As New CoverageSummary

        Dim FragmentRange As IEnumerable(Of Range) = GetClassifiedRanges(TextToCompile, LanguageNames.VisualBasic)
        Try ' Prevent crash when exiting
            Dim Progress As New ReportProgress(ProgressBar)
            Progress.SetTotalItems(TextToCompile.SplitLines.Length)
            With ConversionBuffer
                .Clear()
                .Select(.TextLength, 0)
                Dim ClassforFile As ClassesDictionary = CoverletTreeView.GetModule(FileName)
                ConversionBuffer.SelectionStart = 0
                ConversionBuffer.SelectionLength = 0
                ConversionBuffer.ScrollToCaret()
                ConversionBuffer.Suspend
                Dim currentColor As Color = Nothing
                For i As Integer = 0 To FragmentRange.Count - 1
                    Dim _Range As Range = FragmentRange(i)
                    .Select(.TextLength, 0)
                    Dim ClassificationColor As (ForegroundColor As Color, BackGroundColor As Color) = GetColorFromName(_Range.ClassificationType)
                    .SelectionColor = ClassificationColor.ForegroundColor
                    .SelectionBackColor = ClassificationColor.BackGroundColor
                    .AppendText(_Range.Text)
                    If _Range.Text.Contains(vbLf, StringComparison.OrdinalIgnoreCase) Then
                        Progress.UpdateProgress(_Range.Text.Count(CType(vbLf, Char)))
                        Application.DoEvents()
                    End If
                Next i
                ConversionBuffer.Resume
                Dim MaxLines As Integer = ConversionBuffer.Lines.Length - 1
                Dim LineStarts(0 To MaxLines) As Integer
                Dim LineEnds(0 To MaxLines) As Integer
                BuildLineTables(ConversionBuffer, LineStarts, LineEnds)
                For Each _Methods As MethodsDictionary In ClassforFile.Values
                    For Each _Method As Method In _Methods.Values
                        Dim MethodHit As Boolean = False
                        Application.DoEvents()
                        FileSummaryStaticics.Add(ProcessMethod(ConversionBuffer, LineStarts, LineEnds, _Method))
                    Next
                Next
                .Select(0, 0)
                .ScrollToCaret()
                CallingForm.LabelCodeCoverage.Text = $"Project Coverage - {FileSummaryStaticics}"
            End With
        Catch ex As Exception
            Stop
        End Try
    End Sub

    Friend Sub Colorize(CallingForm As Form1, ConversionBuffer As RichTextBox, FileName As String, ProgressBar As ToolStripProgressBar)
        Try ' Prevent crash when exiting
            With ConversionBuffer
                .Clear()
                .Select(.TextLength, 0)
                Dim TextToCompile As String = Nothing
                Using FileStream As FileStream = File.OpenRead(FileName)
                    TextToCompile = GetFileTextFromStream(FileStream)
                    Application.DoEvents()
                    Colorize(CallingForm, TextToCompile, ConversionBuffer, FileName, ProgressBar)
                End Using

            End With
        Catch ex As Exception
            Stop
        End Try
    End Sub

End Module
