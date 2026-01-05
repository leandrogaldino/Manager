Imports System.ComponentModel
Imports System.Drawing
Imports CoreSuite.Controls
Imports CoreSuite.Helpers
Imports CoreSuite.Infrastructure
Imports ManagerCore

Public Class FrmLicenseKey

    Private ReadOnly _LicenseService As LicenseService
    Private ReadOnly _LicenseResult As LicenseResultModel
    Private _IsValidKey As Boolean

    Public Sub New()
        InitializeComponent()
        _LicenseService = Locator.GetInstance(Of LicenseService)
        _LicenseResult = Locator.GetInstance(Of SessionModel).ManagerLicenseResult
    End Sub


    Private Sub BuildKey()
        '_Key = $"{TxtKeyPartA.Text}-{TxtKeyPartB.Text}-{TxtKeyPartC.Text}-{TxtKeyPartD.Text}-{TxtKeyPartE.Text}"
    End Sub



    Private Async Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Await _LicenseService.GetOnlineLicense()
    End Sub

    Private Sub TxtKey_TextChanged(sender As Object, e As EventArgs) Handles TxtKeyPartA.TextChanged, TxtKeyPartB.TextChanged, TxtKeyPartC.TextChanged, TxtKeyPartD.TextChanged, TxtKeyPartE.TextChanged
        BtnSave.Enabled = True
    End Sub

    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtKeyPartA.KeyDown, TxtKeyPartB.KeyDown, TxtKeyPartC.KeyDown, TxtKeyPartD.KeyDown, TxtKeyPartE.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            Dim ClipboardText = Clipboard.GetText().Replace("-", "").Trim()
            If String.IsNullOrEmpty(ClipboardText) Then Exit Sub
            Dim Source = DirectCast(sender, TextBox)
            Source.Text = ""
            DistributeText(ClipboardText, Source)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TxtKeyPartA.TextChanged, TxtKeyPartB.TextChanged, TxtKeyPartC.TextChanged, TxtKeyPartD.TextChanged, TxtKeyPartE.TextChanged
        Dim Current = DirectCast(sender, TextBox)
        If Clipboard.ContainsText() AndAlso Current.Text.Length > Current.MaxLength Then
            Dim clipboardText = Clipboard.GetText()
            Current.Text = ""
            DistributeText(clipboardText, Current)
        End If
        If Current.Text.Length = Current.MaxLength Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub DistributeText(text As String, source As TextBox)
        Dim TextBoxes As TextBox() = {TxtKeyPartA, TxtKeyPartB, TxtKeyPartC, TxtKeyPartD, TxtKeyPartE}
        Dim Index = Array.IndexOf(TextBoxes, source)
        Dim Remaining = text
        For i = Index To TextBoxes.Length - 1
            Dim TextBox = TextBoxes(i)
            Dim Avalilable = TextBox.MaxLength - TextBox.Text.Length
            If Avalilable > 0 Then
                Dim Part = Remaining.Substring(0, Math.Min(Avalilable, Remaining.Length))
                TextBox.Text &= Part
                Remaining = Remaining.Substring(Part.Length)
                If Remaining.Length = 0 Then Exit For
            End If
        Next
    End Sub
End Class
