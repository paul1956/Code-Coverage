' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Public Module ProcessDirectoriesModule

    Public Sub LocalUseWaitCutsor(MeForm As Form1, Enable As Boolean)
        If MeForm Is Nothing Then
            Exit Sub
        End If
        If MeForm.UseWaitCursor <> Enable Then
            MeForm.UseWaitCursor = Enable
            Application.DoEvents()
        End If
    End Sub

End Module
