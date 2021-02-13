' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Public NotInheritable Class CoverageColors

    Public Shared ReadOnly ColorMappingDictionary As New Dictionary(Of String, (Foreground As Color, Background As Color)) From {
      {"Default", (Color.FromArgb(255, 255, 255, 255), Color.White)},
      {"Branch Hit", (Color.LightGreen, Color.White)},
      {"Branch Missed", (Color.LightPink, Color.White)},
      {"Line Hit", (Color.LightGreen, Color.White)},
      {"Line Missed", (Color.LightPink, Color.White)},
      {"Method Hit", (Color.LightGreen, Color.White)},
      {"Method Missed", (Color.LightPink, Color.White)}
}

    Public Shared Property BranchHit As Color
        Get
            Return ColorMappingDictionary("Branch Hit").Foreground
        End Get
        Set(value As Color)
            ColorMappingDictionary("Branch Hit") = (value, ColorMappingDictionary("Default").Background)
        End Set
    End Property

    Public Shared Property BranchMissed As Color
        Get
            Return ColorMappingDictionary("Branch Missed").Foreground
        End Get
        Set(value As Color)
            ColorMappingDictionary("Branch Missed") = (value, ColorMappingDictionary("Default").Background)
        End Set
    End Property

    Public Shared Property LineHit As Color
        Get
            Return ColorMappingDictionary("Line Hit").Foreground
        End Get
        Set(value As Color)
            ColorMappingDictionary("Line Hit") = (value, ColorMappingDictionary("Default").Background)
        End Set
    End Property

    Public Shared Property LineMissed As Color
        Get
            Return ColorMappingDictionary("Line Missed").Foreground
        End Get
        Set(value As Color)
            ColorMappingDictionary("Line Missed") = (value, ColorMappingDictionary("Default").Background)
        End Set
    End Property

    Public Shared Property MethodHit As Color
        Get
            Return ColorMappingDictionary("Method Hit").Foreground
        End Get
        Set(value As Color)
            ColorMappingDictionary("Method Hit") = (value, ColorMappingDictionary("Default").Background)
        End Set
    End Property

    Public Shared Property MethodMissed As Color
        Get
            Return ColorMappingDictionary("Method Missed").Foreground
        End Get
        Set(value As Color)
            ColorMappingDictionary("Method Missed") = (value, ColorMappingDictionary("Default").Background)
        End Set
    End Property

End Class
