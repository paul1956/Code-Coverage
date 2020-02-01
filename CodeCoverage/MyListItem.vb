Public Class MyListItem
    Sub New(pText As String, pValue As String)
        _Text = pText
        _Value = pValue
    End Sub

    Public ReadOnly Property Text() As String

    Public ReadOnly Property Value() As String

    Public Overrides Function ToString() As String
        Return Text
    End Function

End Class
