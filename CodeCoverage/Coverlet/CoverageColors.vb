Imports System.Drawing

Public NotInheritable Class CoverageColors

    Public Shared ReadOnly ColorMappingDictionary As New Dictionary(Of String, Color) From {
      {"Default", Color.FromArgb(255, 255, 255, 255)},
      {"Branch Hit", Color.LightGreen},
      {"Branch Missed", Color.LightPink},
      {"Line Hit", Color.LightGreen},
      {"Line Missed", Color.LightPink},
      {"Method Hit", Color.LightGreen},
      {"Method Missed", Color.LightPink}
}

    Public Shared Property BackColorDefault As Color
        Get
            Return ColorMappingDictionary("Default")
        End Get
        Set(value As Color)
            ColorMappingDictionary("Default") = value
        End Set
    End Property

    Public Shared Property BranchHit As Color
        Get
            Return ColorMappingDictionary("Branch Hit")
        End Get
        Set(value As Color)
            ColorMappingDictionary("Branch Hit") = value
        End Set
    End Property

    Public Shared Property BranchMissed As Color
        Get
            Return ColorMappingDictionary("Branch Missed")
        End Get
        Set(value As Color)
            ColorMappingDictionary("Branch Missed") = value
        End Set
    End Property

    Public Shared Property LineHit As Color
        Get
            Return ColorMappingDictionary("Line Hit")
        End Get
        Set(value As Color)
            ColorMappingDictionary("Line Hit") = value
        End Set
    End Property

    Public Shared Property LineMissed As Color
        Get
            Return ColorMappingDictionary("Line Missed")
        End Get
        Set(value As Color)
            ColorMappingDictionary("Line Missed") = value
        End Set
    End Property

    Public Shared Property MethodHit As Color
        Get
            Return ColorMappingDictionary("Method Hit")
        End Get
        Set(value As Color)
            ColorMappingDictionary("Method Hit") = value
        End Set
    End Property

    Public Shared Property MethodMissed As Color
        Get
            Return ColorMappingDictionary("Method Missed")
        End Get
        Set(value As Color)
            ColorMappingDictionary("Method Missed") = value
        End Set
    End Property
End Class
