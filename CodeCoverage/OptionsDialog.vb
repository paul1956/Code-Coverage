Imports System.Drawing
Imports System.Windows.Forms

Public Class OptionsDialog
    Private _selectedColor As Color
    Private _selectedColorName As String = "default"

    Private Sub Cancel_Button_Click(sender As Object, e As System.EventArgs) Handles Cancel_Button.Click
        DialogResult = DialogResult.Cancel
        Close()
    End Sub

    Private Sub CoverageColor_ComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles CoverageColor_ComboBox.DrawItem
        If e.Index >= 0 Then
            Dim n As String = CType(sender, ComboBox).Items(e.Index).ToString()
            Using f As New Font("Arial", 9, FontStyle.Regular)
                Dim c As Color = CoverageColorSelector.GetColorFromName(n)
                Using b As Brush = New SolidBrush(c)
                    Dim rect As Rectangle = e.Bounds
                    Dim g As Graphics = e.Graphics
                    g.DrawString(n, f, Brushes.Black, rect.X, rect.Top)
                    g.FillRectangle(b, rect.X + 220, rect.Y + 2, rect.Width - 10, rect.Height - 6)
                End Using
            End Using
        End If
    End Sub

    Private Sub CoverageColor_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CoverageColor_ComboBox.SelectedIndexChanged
        _selectedColorName = CStr(CoverageColor_ComboBox.SelectedItem)
        _selectedColor = CoverageColorSelector.GetColorFromName(_selectedColorName)
    End Sub

    Private Sub ItemColor_ComboBox_DrawItem(sender As Object, e As DrawItemEventArgs) Handles ItemColor_ComboBox.DrawItem
        If e.Index >= 0 Then
            Dim n As String = CType(sender, ComboBox).Items(e.Index).ToString()
            Using f As New Font("Arial", 9, FontStyle.Regular)
                Dim c As Color = CodeColorSelector.GetColorFromName(n)
                Using b As Brush = New SolidBrush(c)
                    Dim rect As Rectangle = e.Bounds
                    Dim g As Graphics = e.Graphics
                    g.DrawString(n, f, Brushes.Black, rect.X, rect.Top)
                    g.FillRectangle(b, rect.X + 220, rect.Y + 2, rect.Width - 10, rect.Height - 6)
                End Using
            End Using
        End If
    End Sub

    Private Sub ItemColor_ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ItemColor_ComboBox.SelectedIndexChanged
        _selectedColorName = CStr(ItemColor_ComboBox.SelectedItem)
        _selectedColor = CodeColorSelector.GetColorFromName(_selectedColorName)
    End Sub

    Private Sub OK_Button_Click(sender As Object, e As System.EventArgs) Handles OK_Button.Click
        DialogResult = DialogResult.OK
        CodeColorSelector.WriteColorDictionaryToFile()
        CoverageColorSelector.WriteColorDictionaryToFile()
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
        For Each Name As String In CodeColorSelector.GetColorNameList()
            ItemColor_ComboBox.Items.Add(Name)
        Next Name
        ItemColor_ComboBox.SelectedIndex = ItemColor_ComboBox.FindStringExact("default")

        For Each Name As String In CoverageColorSelector.GetColorNameList()
            CoverageColor_ComboBox.Items.Add(Name)
        Next Name
        CoverageColor_ComboBox.SelectedIndex = CoverageColor_ComboBox.FindStringExact("default")
    End Sub

    Private Sub UpdateCoverageColor_Click(sender As Object, e As EventArgs) Handles UpdateCoverageColor.Click
        ColorDialog1.Color = _selectedColor
        If ColorDialog1.ShowDialog <> DialogResult.Cancel Then
            CoverageColorSelector.SetColor(CoverageColor_ComboBox.Items(CoverageColor_ComboBox.SelectedIndex).ToString, ColorDialog1.Color)
            Application.DoEvents()
        End If

    End Sub

    Private Sub UpdateItemColor_Button_Click(sender As Object, e As EventArgs) Handles UpdateItemColor_Button.Click
        ColorDialog1.Color = _selectedColor
        If ColorDialog1.ShowDialog <> DialogResult.Cancel Then
            CodeColorSelector.SetColor(ItemColor_ComboBox.Items(ItemColor_ComboBox.SelectedIndex).ToString, ColorDialog1.Color)
            Application.DoEvents()
        End If
    End Sub
End Class
