' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Imports System.Runtime.CompilerServices

Imports Microsoft.CodeAnalysis

Public Module StringExtensions

    <Extension()>
    Public Function Count(value As String, ch As Char) As Integer
        Contracts.Contract.Requires(value IsNot Nothing)
        Return value.Count(Function(c As Char) c = ch)
    End Function

End Module
