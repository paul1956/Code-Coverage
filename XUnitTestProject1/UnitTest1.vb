' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Imports CodeCoverage.SyntaxHighlightingColors

Imports Xunit

Namespace XUnitTestProject1

    Public Class UnitTest1

        <Fact>
        Sub TestSub()
            Assert.Equal(GetColorFromName("").Foreground, Color.FromArgb(Color.Black.R, Color.Black.G, Color.Black.B))
            Assert.Equal(GetColorFromName("").Background, Color.FromArgb(Color.White.R, Color.White.G, Color.White.B))
            Assert.Equal(GetColorFromName("anything").Foreground, Color.FromArgb(Color.Red.R, Color.Red.G, Color.Red.B))
            Assert.Equal(GetColorFromName("anything").Background, Color.FromArgb(Color.White.R, Color.White.G, Color.White.B))
            Assert.Equal(GetColorFromName("default").Foreground, Color.FromArgb(Color.Black.R, Color.Black.G, Color.Black.B))
            Assert.Equal(GetColorFromName("default").Background, Color.FromArgb(Color.White.R, Color.White.G, Color.White.B))
            Assert.Equal(GetColorFromName("Default").Foreground, Color.FromArgb(Color.Black.R, Color.Black.G, Color.Black.B))
            Assert.Equal(GetColorFromName("Default").Background, Color.FromArgb(Color.White.R, Color.White.G, Color.White.B))
            Assert.Equal(GetColorFromName("keyword - control").Foreground, Color.FromArgb(143, 8, 196))
            Assert.Equal(GetColorFromName("keyword - control").Background, Color.FromArgb(Color.White.R, Color.White.G, Color.White.B))
        End Sub

    End Class

End Namespace
