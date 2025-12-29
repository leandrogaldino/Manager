Imports System.ComponentModel
Imports ControlLibrary
Imports ManagerCore

Public Class FrmLicenseKey

    Public Sub New()
        InitializeComponent()
        Dim LicenseService = Locator.GetInstance(Of LicenseService)
        Dim SessionModel = Locator.GetInstance(Of SessionModel)

    End Sub
    'Private Async Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
    'Dim LicenseResult As LicenseResultModel = Await _ViewModel.ProcessLicense()
    'If LicenseResult.Success Then
    '    DialogResult = DialogResult.OK
    'Else
    '    CMessageBox.Show(EnumHelper.GetEnumDescription(LicenseResult.Flag), CMessageBoxType.Warning)
    'End If
    'End Sub


    'QUANDO PROPRIEDADE MUDAR
    Private Sub UpdateUIForLicenseValidation(isValid As Boolean)
        If isValid Then
            BtnOK.Enabled = True
            PbxLoading.Image = My.Resources.ValidKey
            LblStatus.Text = "A licença fornecida é válida."
            LblStatus.ForeColor = Color.DarkGreen
        Else
            BtnOK.Enabled = False
            PbxLoading.Image = My.Resources.InvalidKey
            LblStatus.Text = "A licença fornecida é inválida."
            LblStatus.ForeColor = Color.DarkRed
        End If
    End Sub
    'Private Async Sub TxtKey_TextChanged(sender As Object, e As EventArgs) Handles TxtKeyPartA.TextChanged, TxtKeyPartB.TextChanged, TxtKeyPartC.TextChanged, TxtKeyPartD.TextChanged, TxtKeyPartE.TextChanged
    'If TxtKeyPartA.Text.Length + TxtKeyPartB.Text.Length + TxtKeyPartC.Text.Length + TxtKeyPartD.Text.Length + TxtKeyPartE.Text.Length = 25 Then
    '    _ViewModel.Key = String.Format("{0}-{1}-{2}-{3}-{4}", TxtKeyPartA.Text, TxtKeyPartB.Text, TxtKeyPartC.Text, TxtKeyPartD.Text, TxtKeyPartE.Text)
    '    Await _ViewModel.ValidateLicenseAsync()
    '    Height = 162
    '    PbxLoading.Visible = True
    'Else
    '    _ViewModel.IsValidKey = False
    '    Height = 130
    '    PbxLoading.Visible = False
    'End If
    'End Sub
    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtKeyPartA.KeyDown, TxtKeyPartB.KeyDown, TxtKeyPartC.KeyDown, TxtKeyPartD.KeyDown, TxtKeyPartE.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            Dim ClipboardText As String = Clipboard.GetText().Replace("-", Nothing).Trim
            If String.IsNullOrEmpty(ClipboardText) Then Exit Sub
            Dim Source As TextBox = DirectCast(sender, TextBox)
            Source.Text = ""
            DistributeText(ClipboardText, Source)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TxtKeyPartA.TextChanged, TxtKeyPartB.TextChanged, TxtKeyPartC.TextChanged, TxtKeyPartD.TextChanged, TxtKeyPartE.TextChanged
        Dim CurrentTextBox As TextBox = DirectCast(sender, TextBox)
        If Clipboard.ContainsText() AndAlso CurrentTextBox.Text.Length > CurrentTextBox.MaxLength Then
            Dim ClipboardText As String = Clipboard.GetText()
            CurrentTextBox.Text = ""
            DistributeText(ClipboardText, CurrentTextBox)
        End If
        If CurrentTextBox.Text.Length = CurrentTextBox.MaxLength Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub DistributeText(Text As String, Source As TextBox)
        Dim Textboxes As TextBox() = {TxtKeyPartA, TxtKeyPartB, TxtKeyPartC, TxtKeyPartD, TxtKeyPartE}
        Dim Index As Integer = Array.IndexOf(Textboxes, Source)
        Dim RemainingText As String = Text
        For i As Integer = Index To Textboxes.Length - 1
            Dim CurrentTextBox As TextBox = Textboxes(i)
            Dim AvailableSpace As Integer = CurrentTextBox.MaxLength - CurrentTextBox.Text.Length
            If AvailableSpace > 0 Then
                Dim TextPart As String = RemainingText.Substring(0, Math.Min(AvailableSpace, RemainingText.Length))
                CurrentTextBox.Text &= TextPart
                RemainingText = RemainingText.Substring(TextPart.Length)
                If RemainingText.Length = 0 Then Exit For
            End If
        Next
    End Sub
    Private Sub FrmLicense_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Height = 130
    End Sub
End Class
