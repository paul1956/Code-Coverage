' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Namespace Coverlet.Core

    Public Class BranchesCollection
        Inherits List(Of BranchInfo)

        Sub New()

        End Sub

    End Class

    Public Class BranchInfo

        Public Property EndOffset As Integer
        Public Property Hits As Integer
        Public Property Line As Integer

        Public Property Offset As Integer
        Public Property Ordinal As UInteger
        Public Property Path As Integer
    End Class

    Public Class ClassesDictionary
        Inherits Dictionary(Of String, MethodsDictionary)

        Sub New()

        End Sub

    End Class

    Public Class DocumentsDictionary
        Inherits Dictionary(Of String, ClassesDictionary)

        Sub New()

        End Sub

    End Class

    Public Class LinesDictionary
        Inherits SortedDictionary(Of Integer, Integer)

        Sub New()

        End Sub

    End Class

    Public Class Method

        Public Sub New()

            Lines = New LinesDictionary

            Branches = New BranchesCollection()

        End Sub

        Public ReadOnly Property Branches As BranchesCollection
        Public ReadOnly Property Lines As LinesDictionary
    End Class

    Public Class MethodsDictionary
        Inherits Dictionary(Of String, Method)

        Sub New()

        End Sub

    End Class

    Public Class ModulesDictionary
        Inherits Dictionary(Of String, DocumentsDictionary)

        Sub New()

        End Sub

    End Class

End Namespace
