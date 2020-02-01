Public Class CoverageSummary
    Private _branchesHit As Long
    Private _lineHits As Long
    Private _linesHit As Long
    Private _maxLineCount As Long
    Private _methodsHit As Long
    Private _totalBranches As Long
    Private _totalLines As Long
    Private _totalMethods As Long
    Public ReadOnly Property BranchesHit As Long
        Get
            Return _branchesHit
        End Get
    End Property

    Public ReadOnly Property LineHits As Long
        Get
            Return _lineHits
        End Get
    End Property

    Public ReadOnly Property LinesHit As Long
        Get
            Return _linesHit
        End Get
    End Property

    Public ReadOnly Property MaxLineCount As Long
        Get
            Return _maxLineCount
        End Get
    End Property
    Public ReadOnly Property MethodsHit As Long
        Get
            Return _methodsHit
        End Get
    End Property

    Public ReadOnly Property TotalBranches As Long
        Get
            Return _totalBranches
        End Get
    End Property

    Public ReadOnly Property TotalLines As Long
        Get
            Return _totalLines
        End Get
    End Property

    Public ReadOnly Property TotalMethods As Long
        Get
            Return _totalMethods
        End Get
    End Property
    Friend Sub Add(Value As CoverageSummary)
        _branchesHit += Value.BranchesHit
        _lineHits += Value.LineHits
        _linesHit += Value.LinesHit
        _maxLineCount += Value.MaxLineCount
        _methodsHit += Value.MethodsHit
        _totalBranches += Value.TotalBranches
        _totalLines += Value.TotalLines
        _totalMethods += Value.TotalMethods
    End Sub

    Public Sub IncrementBranchesHit()
        _branchesHit += 1
    End Sub

    Public Sub IncrementLinesHit(HitCount As Long)
        _lineHits += HitCount
        If _lineHits > _maxLineCount Then
            _maxLineCount = _lineHits
        End If
        _linesHit += 1
    End Sub

    Public Sub IncrementMethodsHit()
        _methodsHit += 1
    End Sub

    Public Sub IncrementTotalBranches()
        _totalBranches += 1
    End Sub

    Public Sub IncrementTotalLines()
        _totalLines += 1
    End Sub

    Public Sub IncrementTotalMethods()
        _totalMethods += 1
    End Sub

    Public Overrides Function ToString() As String
        Dim TempString As String = ""
        If TotalLines > 0 Then
            TempString = $"Line Coverage = {Math.Round(LinesHit / TotalLines * 100, 2, MidpointRounding.AwayFromZero) }% "
        End If
        If TotalBranches > 0 Then
            TempString &= $"Branch Coverage ={Math.Round(BranchesHit / TotalBranches * 100, 2, MidpointRounding.AwayFromZero)}% "
        End If
        If _totalMethods > 0 Then
            TempString &= $"Methods Coverage ={Math.Round(MethodsHit / TotalMethods * 100, 2, MidpointRounding.AwayFromZero)}% "
        End If
        TempString &= $"Max Line Count = {MaxLineCount.ToString("N0", Globalization.CultureInfo.InvariantCulture)}"
        Return TempString
    End Function

End Class
