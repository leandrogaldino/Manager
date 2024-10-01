Imports ControlLibrary
Public Class FrmEvaluationPart
    Private _Part As EvaluationPart
    Private _Loading As Boolean
    Public Sub New(Part As EvaluationPart)
        InitializeComponent()
        _Loading = True
        _Part = Part
        TxtItem.Text = _Part.Part.ItemNameOrProduct
        DbxCapacity.Text = _Part.CurrentCapacity
        CbxSold.Checked = _Part.Sold
        CbxLost.Checked = _Part.Lost
        BtnSave.Enabled = False
        _Loading = False
    End Sub
    <DebuggerStepThrough>
    Protected Overrides Sub DefWndProc(ByRef m As Message)
        Const _MouseButtonDown As Long = &HA1
        Const _MouseButtonUp As Long = &HA0
        Const _CloseButton As Long = 20
        If CLng(m.Msg) = _MouseButtonDown And Not m.WParam = _CloseButton Then
            If Opacity <> 0.5 Then Opacity = 0.5
        ElseIf CLng(m.Msg) = _MouseButtonUp Then
            If Opacity <> 1.0 Then Opacity = 1.0
        End If
        MyBase.DefWndProc(m)
    End Sub
    Private Sub CbxSold_CheckedChanged(sender As Object, e As EventArgs) Handles CbxSold.CheckedChanged
        If CbxSold.Checked Then
            CbxLost.Checked = False
            If DbxCapacity.DecimalValue <> _Part.Part.Capacity And Not _Loading Then
                If CMessageBox.Show("Deseja resetar a capacidade?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    DbxCapacity.Text = _Part.Part.Capacity
                End If
            End If
        End If
    End Sub
    Private Sub CbxLost_CheckedChanged(sender As Object, e As EventArgs) Handles CbxLost.CheckedChanged
        If CbxLost.Checked Then
            CbxSold.Checked = False
            If DbxCapacity.DecimalValue <> _Part.Part.Capacity And Not _Loading Then
                If CMessageBox.Show("Deseja resetar a capacidade?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    DbxCapacity.Text = _Part.Part.Capacity
                End If
            End If
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Save()
    End Sub

    Private Sub Save()
        _Part.CurrentCapacity = DbxCapacity.DecimalValue
        _Part.Sold = CbxSold.Checked
        _Part.Lost = CbxLost.Checked
        DialogResult = DialogResult.OK
    End Sub

    Private Sub ValuesChanged(sender As Object, e As EventArgs) Handles DbxCapacity.TextChanged, CbxLost.CheckedChanged, CbxSold.CheckedChanged
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub DbxCapacity_KeyDown(sender As Object, e As KeyEventArgs) Handles DbxCapacity.KeyDown
        If e.KeyCode = Keys.Enter Then
            BtnSave.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            BtnClose.PerformClick()
        End If
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Locator.GetInstance(Of Session).AutoCloseApp Then
            If DialogResult <> DialogResult.OK Then
                If BtnSave.Enabled Then
                    If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                        Save()
                    End If
                End If
            End If
        End If
    End Sub
End Class