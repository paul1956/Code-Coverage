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
