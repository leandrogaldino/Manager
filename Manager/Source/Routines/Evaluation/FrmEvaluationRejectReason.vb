Imports ControlLibrary.Extensions
Public Class FrmEvaluationRejectReason
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        TxtReason.Text = TxtReason.Text.ToUnaccented()
        If IsValidFields() Then
            DialogResult = DialogResult.OK
        End If
    End Sub
    Private Sub TxtReason_TextChanged(sender As Object, e As EventArgs) Handles TxtReason.TextChanged
        EprValidation.Clear()
        BtnSave.Enabled = True
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrEmpty(TxtReason.Text) Then
            EprValidation.SetError(LblReason, "É preciso informar um motivo.")
            EprValidation.SetIconAlignment(LblReason, ErrorIconAlignment.MiddleRight)
            TxtReason.Select()
            Return False
        End If
        Return True
    End Function
End Class