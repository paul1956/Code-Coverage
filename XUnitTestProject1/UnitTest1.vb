﻿' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Imports System.IO

Imports CodeCoverage
Imports CodeCoverage.SyntaxHighlightingColors

Imports Xunit

Namespace XUnitTestProject1

    Public Class UnitTest1

        <Fact>
        Sub TestSub()
            Assert.Equal(GetColorFromName("Default").ForegroundColor, Color.Black)
            Assert.Equal(GetColorFromName("default").ForegroundColor, Color.Black)
            Assert.Equal(GetColorFromName("").ForegroundColor, Color.Black)
            Assert.Equal(GetColorFromName("anything").ForegroundColor, Color.Red)
            Assert.Equal(GetColorFromName("event name").ForegroundColor, Color.Black)
        End Sub

        <Fact>
        Sub TestThemes()
            Dim ExecutablePath As String = Reflection.Assembly.GetExecutingAssembly().Location
            Dim ExecutableDirectory As String = Directory.GetParent(ExecutablePath).FullName
            Dim ThemePath As String = Path.Combine(ExecutableDirectory, "Assets", "BigFace.xml")
            Dim CurrentTheme As Themes = LoadNewTheme(ThemePath)
            Dim TempDictionary As New Dictionary(Of String, (ForeGround As Color, Background As Color))(StringComparer.OrdinalIgnoreCase)
            LoadDictionaryFromTheme(CurrentTheme, TempDictionary)
            Stop
        End Sub

    End Class

End Namespace
