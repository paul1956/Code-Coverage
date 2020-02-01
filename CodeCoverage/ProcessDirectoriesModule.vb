' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.
Option Explicit On
Option Infer Off
Option Strict On

Imports System.IO

Public Module ProcessDirectoriesModule

    Public Function GetFileTextFromStream(fileStream As Stream) As String
        Using sw As New StreamReader(fileStream)
            Dim SourceText As String = sw.ReadToEnd()
            sw.Close()
            Return SourceText
        End Using
    End Function

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