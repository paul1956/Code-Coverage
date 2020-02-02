Imports System.IO

Public Module CoverageColorSelector

    Private ReadOnly FullPath As String = Path.Combine(FileIO.SpecialDirectories.MyDocuments, "CodeCoverageColorDictionary.csv")

    Private Sub UpdateColorDictionaryFromFile(FPath As String)
        If Not File.Exists(FPath) Then
            WriteColorDictionaryToFile(FPath)
            Exit Sub
        End If
        Dim FileStream As FileStream = File.OpenRead(FPath)
        Dim sr As New StreamReader(FileStream)
        sr.ReadLine()
        While (sr.Peek() <> -1)
            Dim line As String = sr.ReadLine()
            Dim Split() As String = line.Split(","c)
            Dim key As String = Split(0)
            Dim A As Integer = Convert.ToInt32(Split(1), Globalization.CultureInfo.InvariantCulture)
            Dim R As Integer = Convert.ToInt32(Split(2), Globalization.CultureInfo.InvariantCulture)
            Dim G As Integer = Convert.ToInt32(Split(3), Globalization.CultureInfo.InvariantCulture)
            Dim B As Integer = Convert.ToInt32(Split(4), Globalization.CultureInfo.InvariantCulture)
            CoverageColors.ColorMappingDictionary(key) = Color.FromArgb(A, R, G, B)
        End While
        sr.Close()
        FileStream.Close()
    End Sub

    Private Sub WriteColorDictionaryToFile(FPath As String)
        Dim FileStream As FileStream = File.OpenWrite(FPath)
        Dim sw As New StreamWriter(FileStream)
        sw.WriteLine($"Key,A,R,G,B")
        For Each kvp As KeyValuePair(Of String, Color) In CoverageColors.ColorMappingDictionary
            sw.WriteLine($"{kvp.Key},{kvp.Value.A},{kvp.Value.R},{kvp.Value.G},{kvp.Value.B}")
        Next
        sw.Flush()
        sw.Close()
        FileStream.Close()
    End Sub

    Friend Function GetColorFromName(Name As String) As Color
        Try
            If String.IsNullOrWhiteSpace(Name) Then
                Return CoverageColors.ColorMappingDictionary("default")
            End If
            Return CoverageColors.ColorMappingDictionary(Name)
        Catch ex As Exception
            Debug.Print($"GetColorFromName missing({Name})")
            Stop
            Return CoverageColors.ColorMappingDictionary("error")
        End Try
    End Function

    Public Function GetColorNameList() As Dictionary(Of String, Color).KeyCollection
        Return CoverageColors.ColorMappingDictionary.Keys
    End Function

    Public Sub SetColor(name As String, value As Color)
        CoverageColors.ColorMappingDictionary(name) = value
        WriteColorDictionaryToFile(FullPath)
    End Sub

    Public Sub UpdateColorDictionaryFromFile()
        UpdateColorDictionaryFromFile(FullPath)
    End Sub

    Public Sub WriteColorDictionaryToFile()
        WriteColorDictionaryToFile(FullPath)
    End Sub

End Module
