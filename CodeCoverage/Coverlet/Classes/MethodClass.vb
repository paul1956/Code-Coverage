﻿' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.
Public Class MethodClass

    Sub New(mDocumentLongName As String, mMethodNode As TreeNode, mMethodLongName As String)
        _DocumentLongName = mDocumentLongName
        _MethodNode = mMethodNode
        _MethodLongName = mMethodLongName
        MethodShortName = MethodNameTrimmed(mMethodLongName)
    End Sub

    Sub New()
        _DocumentLongName = ""
        _MethodNode = New TreeNode
        _MethodLongName = ""
        MethodShortName = ""
    End Sub

    Public ReadOnly Property DocumentLongName As String
    Public ReadOnly Property MethodLongName As String
    Public ReadOnly Property MethodNode As TreeNode
    Public ReadOnly Property MethodShortName As String

    Private Shared Function MethodNameTrimmed(key As String) As String
        Contracts.Contract.Requires(key IsNot Nothing)
        Dim Index As Integer = key.IndexOf("::", StringComparison.InvariantCulture)
        Dim MethodNameWithParameters As String = key.Substring(Index + 2)
        If MethodNameWithParameters.Length <= 70 Then
            Return MethodNameWithParameters
        End If
        Index = MethodNameWithParameters.IndexOf("(", StringComparison.InvariantCultureIgnoreCase)
        If Index > 0 AndAlso Index < 70 Then
            Return String.Concat(MethodNameWithParameters.AsSpan(0, 70), "...)")
        End If
        Return String.Concat(MethodNameWithParameters.AsSpan(0, Math.Min(70, MethodNameWithParameters.Length)), "...")
    End Function

End Class
