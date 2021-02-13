' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Public Class DirectoryClass

    Sub New(mShortName As String, mFullname As String, mDirectoryNode As TreeNode)
        _ShortName = mShortName
        _FullPath = mFullname
        _DirectoryNode = mDirectoryNode
    End Sub

    Public ReadOnly Property DirectoryNode As TreeNode
    Public ReadOnly Property FullPath As String
    Public ReadOnly Property ShortName As String
End Class
