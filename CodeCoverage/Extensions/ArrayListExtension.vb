Imports System.Runtime.CompilerServices

Public Module ArrayListExtension

    <Extension>
    Public Function Find(Arr As ArrayList, Match As Predicate(Of MethodClass)) As MethodClass
        If Arr Is Nothing OrElse Arr.Count = 0 Then
            Return Nothing
        End If
        For Each m As MethodClass In Arr
            If Match(m) Then
                Return m
            End If
        Next
        Return Nothing
    End Function
End Module
