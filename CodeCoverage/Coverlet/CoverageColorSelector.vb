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
            CoverageColors.ColorMappingDictionary(key) = (Color.FromArgb(ForeGroundA, ForeGroundR, ForeGroundG, ForeGroundB), BackGroundColor)
        End While
        sr.Close()
        FileStream.Close()
    End Sub

    Private Sub WriteColorDictionaryToFile(FPath As String)
        Dim FileStream As FileStream = File.OpenWrite(FPath)
        Dim sw As New StreamWriter(FileStream)
        sw.WriteLine($"Key,A,R,G,B,BA,BR,BG,BB")
        For Each kvp As KeyValuePair(Of String, (ForeGround As Color, Background As Color)) In CoverageColors.ColorMappingDictionary
            sw.WriteLine($"{kvp.Key},{kvp.Value.ForeGround.A},{kvp.Value.ForeGround.R},{kvp.Value.ForeGround.G},{kvp.Value.ForeGround.B},{kvp.Value.Background.A},{kvp.Value.Background.R},{kvp.Value.Background.G},{kvp.Value.Background.B}")
        Next
        sw.Flush()
        sw.Close()
        FileStream.Close()
    End Sub

    Friend Function GetColorFromName(Name As String) As (Foreground As Color, Background As Color)
        Try
            If String.IsNullOrWhiteSpace(Name) Then
                Return CodeColorSelector.ColorMappingDictionary("default")
            End If
            Return CodeColorSelector.ColorMappingDictionary(Name)
        Catch ex As Exception
            Debug.Print($"GetColorFromName missing({Name})")
            Stop
            Return CodeColorSelector.ColorMappingDictionary("error")
        End Try
    End Function

    Public Function GetColorNameList() As Dictionary(Of String, (Foreground As Color, Background As Color)).KeyCollection
        Return CoverageColors.ColorMappingDictionary.Keys
    End Function

    Public Sub SetColor(name As String, value As (Foreground As Color, Background As Color))
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
