' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Public Class OptionsDialog
    Private _selectedColor As (ForeGround As Color, Background As Color)
    Private _selectedColorName As String = "default"

    Private Sub Cancel_Button_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub ThemeColorsComboBoxComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ThemeColorsComboBox.DrawItem
        If e.Index >= 0 Then
            Dim n As String = CType(sender, ComboBox).Items(e.Index).ToString()
            Using f As New Font("Consolas", 9, FontStyle.Regular)
                Dim c As Color = CoverageColorColors.GetColorFromName(n).Foreground
                Using b As Brush = New SolidBrush(c)
                    Dim rect As Rectangle = e.Bounds
                    Dim g As Graphics = e.Graphics
                    g.DrawString(n, f, Brushes.Black, rect.X, rect.Top)
                    g.FillRectangle(b, rect.X + 220, rect.Y + 2, rect.Width - 10, rect.Height - 6)
                End Using
            End Using
        End If
    End Sub

    Private Sub ThemeColorsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ThemeColorsComboBox.SelectedIndexChanged
        _selectedColorName = CStr(ThemeColorsComboBox.SelectedItem)
        _selectedColor = CoverageColorColors.GetColorFromName(_selectedColorName)
    End Sub

    Private Sub CodeCoverageComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles CodeCoverageComboBox.DrawItem
        If e.Index >= 0 Then
            Dim n As String = CType(sender, ComboBox).Items(e.Index).ToString()
            Using f As New Font("Segoe UI", 9, FontStyle.Regular)
                Dim c As (ForeGround As Color, Background As Color) = SyntaxHighlightingColors.GetColorFromName(CoverageColors.ColorMappingDictionary, n)
                Using b As Brush = New SolidBrush(c.ForeGround)
                    Dim rect As Rectangle = e.Bounds
                    Dim g As Graphics = e.Graphics
                    g.DrawString(n, f, Brushes.Black, rect.X, rect.Top)
                    g.FillRectangle(b, rect.X + 220, rect.Y + 2, rect.Width - 10, rect.Height - 6)
                End Using
            End Using
        End If
    End Sub

    Private Sub CodeCoverageComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CodeCoverageComboBox.SelectedIndexChanged
        _selectedColorName = CStr(CodeCoverageComboBox.SelectedItem)
        _selectedColor = SyntaxHighlightingColors.GetColorFromName(CoverageColors.ColorMappingDictionary, _selectedColorName)
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As EventArgs) Handles OK_Button.Click
        My.Settings.DefaultProjectDirectory = CType(ProjectDirectoryList.SelectedItem, MyListItem).Value
        My.Settings.Save()
        DialogResult = DialogResult.OK
        SyntaxHighlightingColors.WriteColorDictionaryToFile()
        CoverageColorColors.WriteColorDictionaryToFile()
        Close()
    End Sub

    Private Sub OptionsDialog_Load(sender As Object, e As EventArgs) Handles Me.Load
        ProjectDirectoryList.Items.Add(New MyListItem("Projects", GetLatestVisualStudioProjectPath))
        ProjectDirectoryList.Items.Add(New MyListItem("Repos", GetAlternetVisualStudioProjectsPath))
        ProjectDirectoryList.SelectedIndex = 0
        For i As Integer = 0 To ProjectDirectoryList.Items.Count - 1
            If CType(ProjectDirectoryList.Items(i), MyListItem).Value = My.Settings.DefaultProjectDirectory Then
                ProjectDirectoryList.SelectedIndex = i
                Exit For
            End If
        Next
        For Each Name As String In SyntaxHighlightingColors.GetColorNameList()
            CodeCoverageComboBox.Items.Add(Name)
        Next Name
        CodeCoverageComboBox.SelectedIndex = CodeCoverageComboBox.FindStringExact("default")

        For Each Name As String In CoverageColorColors.GetColorNameList()
            ThemeColorsComboBox.Items.Add(Name)
        Next Name
        ThemeColorsComboBox.SelectedIndex = ThemeColorsComboBox.FindStringExact("default")
    End Sub

    Private Sub UpdateThemeColorsButton_Click(sender As Object, e As EventArgs) Handles UpdateThemeColorsButton.Click
        ColorDialog1.Color = _selectedColor.ForeGround
        If ColorDialog1.ShowDialog <> DialogResult.Cancel Then
            CoverageColorColors.SetColor(ThemeColorsComboBox.Items(ThemeColorsComboBox.SelectedIndex).ToString, (ColorDialog1.Color, _selectedColor.Background))
            Application.DoEvents()
        End If

    End Sub

    Private Sub UpdateICodeCoverageColorButton_Button_Click(sender As Object, e As EventArgs) Handles UpdateCodeCoverageColorButton.Click
        ColorDialog1.Color = _selectedColor.ForeGround
        If ColorDialog1.ShowDialog <> DialogResult.Cancel Then
            SyntaxHighlightingColors.SetColor(CodeCoverageComboBox.Items(CodeCoverageComboBox.SelectedIndex).ToString, (ColorDialog1.Color, _selectedColor.Background))
            Application.DoEvents()
        End If
    End Sub

End Class
