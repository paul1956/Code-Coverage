' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Namespace Coverlet.Core

    Public Class BranchInfo

        Public Property Line As Integer

        Public Property Offset As Integer

        Public Property EndOffset As Integer

        Public Property Path As Integer

        Public Property Ordinal As UInteger

        Public Property Hits As Integer

    End Class

    Public Class LinesDictionary
        Inherits SortedDictionary(Of Integer, Integer)
    End Class

    Public Class BranchesCollection
        Inherits List(Of BranchInfo)
    End Class

    Public Class Method

        Friend Sub New()

            Lines = New LinesDictionary

            Branches = New BranchesCollection()

        End Sub

        Public ReadOnly Property Lines As LinesDictionary

        Public ReadOnly Property Branches As BranchesCollection

    End Class

    Public Class MethodsDictionary
        Inherits Dictionary(Of String, Method)

    End Class

    Public Class ClassesDictionary
        Inherits Dictionary(Of String, MethodsDictionary)

    End Class

    Public Class DocumentsDictionary
        Inherits Dictionary(Of String, ClassesDictionary)

    End Class

    Public Class ModulesDictionary
        Inherits Dictionary(Of String, DocumentsDictionary)

    End Class

End Namespace
