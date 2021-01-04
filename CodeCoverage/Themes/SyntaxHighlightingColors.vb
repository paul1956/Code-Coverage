' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public NotInheritable Class SyntaxHighlightingColors

    Public Shared ReadOnly ColorMappingDictionary As New Dictionary(Of String, (ForeGround As Color, Background As Color))(StringComparer.OrdinalIgnoreCase) From {
         {"class name", (Color.FromArgb(0, 128, 128), Color.White)},
         {"comment", (Color.FromArgb(0, 100, 0), Color.White)},
         {"constant name", (Color.Black, Color.White)},
         {"default", (Color.Black, Color.White)},
         {"delegate name", (Color.FromArgb(0, 128, 128), Color.White)},
         {"enum name", (Color.FromArgb(0, 128, 128), Color.White)},
         {"enum member name", (Color.FromArgb(0, 128, 128), Color.White)},
         {"error", (Color.Red, Color.White)},
         {"excluded code", (Color.FromArgb(128, 128, 128), Color.White)},
         {"event name", (Color.Black, Color.White)},
         {"extension method name", (Color.Black, Color.White)},
         {"field name", (Color.Black, Color.White)},
         {"identifier", (Color.Black, Color.White)},
         {"interface name", (Color.FromArgb(0, 128, 128), Color.White)},
         {"keyword", (Color.FromArgb(0, 0, 255), Color.White)},
         {"keyword - control", (Color.FromArgb(143, 8, 196), Color.White)},
         {"label name", (Color.Black, Color.White)},
         {"local name", (Color.Black, Color.White)},
         {"method name", (Color.Black, Color.White)},
         {"module name", (Color.FromArgb(0, 128, 128), Color.White)},
         {"namespace name", (Color.Black, Color.White)},
         {"number", (Color.Black, Color.White)},
         {"operator", (Color.Black, Color.White)},
         {"operator - overloaded", (Color.Black, Color.White)},
         {"parameter name", (Color.Black, Color.White)},
         {"preprocessor keyword", (Color.Gray, Color.White)},
         {"preprocessor text", (Color.Black, Color.White)},
         {"property name", (Color.Black, Color.White)},
         {"punctuation", (Color.Black, Color.White)},
         {"static symbol", (Color.Black, Color.White)},
         {"string - escape character", (Color.Yellow, Color.White)},
         {"string - verbatim", (Color.FromArgb(128, 0, 0), Color.White)},
         {"string", (Color.FromArgb(163, 21, 21), Color.White)},
         {"struct name", (Color.FromArgb(43, 145, 175), Color.White)},
         {"text", (Color.Black, Color.White)},
         {"type parameter name", (Color.DarkGray, Color.White)},
         {"xml doc comment - attribute name", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml doc comment - attribute quotes", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml doc comment - attribute value", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml doc comment - cdata section", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml doc comment - comment", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml doc comment - delimiter", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml doc comment - entity reference", (Color.FromArgb(0, 128, 0), Color.White)},
         {"xml doc comment - name", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml doc comment - processing instruction", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml doc comment - text", (Color.FromArgb(0, 128, 0), Color.White)},
         {"xml literal - attribute name", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml literal - attribute quotes", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml literal - attribute value", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml literal - cdata section", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml literal - comment", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml literal - delimiter", (Color.FromArgb(100, 100, 185), Color.White)},
         {"xml literal - embedded expression", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml literal - entity reference", (Color.FromArgb(185, 100, 100), Color.White)},
         {"xml literal - name", (Color.FromArgb(132, 70, 70), Color.White)},
         {"xml literal - processing instruction", (Color.FromArgb(128, 128, 128), Color.White)},
         {"xml literal - text", (Color.FromArgb(85, 85, 85), Color.White)}
     }

    Public Shared ReadOnly DictionaryFilePath As String = Path.Combine(FileIO.SpecialDirectories.MyDocuments, "CodeHighlightingColorDictionary.csv")
    Public Shared Property BackgroundColor As Color = Color.White

    Private Shared Sub WriteColorDictionaryToFile(FPath As String)
        Dim FileStream As FileStream = File.OpenWrite(FPath)
        Dim sw As New StreamWriter(FileStream)
        sw.WriteLine($"Key,A,R,G,B,BA,BR,BG,BB")
        For Each kvp As KeyValuePair(Of String, (ForeGround As Color, Background As Color)) In SyntaxHighlightingColors.ColorMappingDictionary
            sw.WriteLine($"{kvp.Key},{kvp.Value.ForeGround.A},{kvp.Value.ForeGround.R},{kvp.Value.ForeGround.G},{kvp.Value.ForeGround.B},{kvp.Value.Background.A},{kvp.Value.Background.R},{kvp.Value.Background.G},{kvp.Value.Background.B}")
        Next
        sw.Flush()
        sw.Close()
        FileStream.Close()
    End Sub

    Public Shared Function GetColorFromName(Dic As Dictionary(Of String, (ForeGround As Color, Background As Color)), Name As String) As (ForegroundColor As Color, BackGroundColor As Color)
        If Dic Is Nothing Then
            Throw New ArgumentNullException(NameOf(Dic))
        End If
        Try
            If String.IsNullOrWhiteSpace(Name) Then
                Return Dic("default")
            End If
            Return Dic(Name)
        Catch ex As Exception
            Debug.Print($"GetColorFromName missing({Name})")
            Stop
            Return Dic("error")
        End Try
    End Function

    Public Shared Function GetColorNameList() As Dictionary(Of String, (Foreground As Color, Background As Color)).KeyCollection
        Return CoverageColors.ColorMappingDictionary.Keys
    End Function

    Public Shared Function LoadDictionaryFromTheme(CurrentTheme As Themes) As Dictionary(Of String, (ForeGround As Color, Background As Color))
        Return LoadDictionaryFromTheme(CurrentTheme, SyntaxHighlightingColors.ColorMappingDictionary)
    End Function

    Public Shared Function LoadDictionaryFromTheme(CurrentTheme As Themes, ThemeDictionary As Dictionary(Of String, (ForeGround As Color, Background As Color))) As Dictionary(Of String, (ForeGround As Color, Background As Color))
        If CurrentTheme Is Nothing Then
            Throw New ArgumentNullException(NameOf(CurrentTheme))
        End If
        If ThemeDictionary Is Nothing Then
            Throw New ArgumentNullException(NameOf(ThemeDictionary))
        End If
        Dim CategoryColorList As New List(Of ThemesThemeCategoryColor)
        For Each Cat As ThemesThemeCategory In CurrentTheme.Theme.Category
            If Cat.Name = "Text Editor Language Service Items" Then
                CategoryColorList.AddRange(Cat.Color)
            End If
        Next

        For Each Cat As ThemesThemeCategory In CurrentTheme.Theme.Category
            If Cat.Name = "Text Editor Language Service Items" Then
                Continue For
            End If
            For Each CategoryColor As ThemesThemeCategoryColor In Cat.Color
                Dim found As Boolean = False
                If SyntaxHighlightingColors.ColorMappingDictionary.ContainsKey(CategoryColor.Name) Then
                    For Each C As ThemesThemeCategoryColor In CategoryColorList
                        If C.Name = CategoryColor.Name Then
                            found = True
                            Exit For
                        End If
                    Next
                    If Not found Then
                        CategoryColorList.Add(CategoryColor)
                    End If
                End If
            Next
        Next
        BackgroundColor = CategoryColorList(0).Background.Source.ToColor
        For Each CategoryColor As ThemesThemeCategoryColor In CategoryColorList
            If ThemeDictionary.ContainsKey(CategoryColor.Name) Then
                ThemeDictionary(CategoryColor.Name) = (CategoryColor.Foreground.Source.ToColor, CategoryColor.Background.Source.ToColor)
            Else
                ThemeDictionary.Add(CategoryColor.Name, (CategoryColor.Foreground.Source.ToColor, CategoryColor.Background.Source.ToColor))
            End If
        Next
        Return ThemeDictionary
    End Function

    Public Shared Function LoadNewTheme(Filename As String) As Themes
        Dim CurrentTheme As Themes
        Using sr As New StreamReader(Filename)
            Using xr As XmlReader = XmlReader.Create(sr)
                CurrentTheme = CType(New XmlSerializer(GetType(Themes)).Deserialize(xr), Themes)
                ' "Text Editor Language Service Items"
            End Using
        End Using
        Return CurrentTheme
    End Function

    Public Shared Sub SetColor(name As String, value As (ForeGround As Color, Background As Color))
        SyntaxHighlightingColors.ColorMappingDictionary(name) = value
        WriteColorDictionaryToFile(DictionaryFilePath)
    End Sub

    Public Shared Sub UpdateDictionaryFromFile()
        If Not File.Exists(DictionaryFilePath) Then
            WriteColorDictionaryToFile(DictionaryFilePath)
            Exit Sub
        End If
        Dim FileStream As FileStream = File.OpenRead(DictionaryFilePath)
        Dim sr As New StreamReader(FileStream)
        Dim HeaderLine As String = sr.ReadLine()
        Dim ForeGroundOnlyFormat As Boolean = True = True
        If HeaderLine.Contains("BA", StringComparison.InvariantCulture) Then
            ForeGroundOnlyFormat = False
        End If
        While (sr.Peek() <> -1)
            Dim line As String = sr.ReadLine()
            Dim Split() As String = line.Split(","c)
            Dim key As String = Split(0)
            Dim ForeGroundA As Integer = Convert.ToInt32(Split(1), Globalization.CultureInfo.InvariantCulture)
            Dim ForeGroundR As Integer = Convert.ToInt32(Split(2), Globalization.CultureInfo.InvariantCulture)
            Dim ForeGroundG As Integer = Convert.ToInt32(Split(3), Globalization.CultureInfo.InvariantCulture)
            Dim ForeGroundB As Integer = Convert.ToInt32(Split(4), Globalization.CultureInfo.InvariantCulture)
            Dim BackGroundA As Integer
            Dim BackGroundR As Integer
            Dim BackGroundG As Integer
            Dim BackGroundB As Integer
            Dim BackGroundColor As Color
            If Not ForeGroundOnlyFormat Then
                BackGroundA = Convert.ToInt32(Split(1), Globalization.CultureInfo.InvariantCulture)
                BackGroundR = Convert.ToInt32(Split(2), Globalization.CultureInfo.InvariantCulture)
                BackGroundG = Convert.ToInt32(Split(3), Globalization.CultureInfo.InvariantCulture)
                BackGroundB = Convert.ToInt32(Split(4), Globalization.CultureInfo.InvariantCulture)
                BackGroundColor = Color.FromArgb(BackGroundA, BackGroundR, BackGroundG, BackGroundB)
            Else
                BackGroundColor = Color.White
            End If
            SyntaxHighlightingColors.ColorMappingDictionary(key) = (Color.FromArgb(ForeGroundA, ForeGroundR, ForeGroundG, ForeGroundB), BackGroundColor)
        End While
        sr.Close()
        FileStream.Close()
    End Sub

    Public Shared Sub WriteColorDictionaryToFile()
        Dim FileStream As FileStream = File.OpenWrite(DictionaryFilePath)
        Dim sw As New StreamWriter(FileStream)
        sw.WriteLine($"Key,A,R,G,B,BA,BR,BG,BB")
        For Each kvp As KeyValuePair(Of String, (ForeGround As Color, Background As Color)) In SyntaxHighlightingColors.ColorMappingDictionary
            sw.WriteLine($"{kvp.Key},{kvp.Value.ForeGround.A},{kvp.Value.ForeGround.R},{kvp.Value.ForeGround.G},{kvp.Value.ForeGround.B},{kvp.Value.Background.A},{kvp.Value.Background.R},{kvp.Value.Background.G},{kvp.Value.Background.B}")
        Next
        sw.Flush()
        sw.Close()
        FileStream.Close()
    End Sub

End Class
