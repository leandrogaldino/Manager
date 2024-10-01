Imports ControlLibrary
Imports ControlLibrary.Utility
Public Class FrmRequestPendingItems
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
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DbxInitialDate.Text = Today.AddMonths(-1).ToString("dd/MM/yyyy")
        DbxFinalDate.Text = Today.ToString("dd/MM/yyyy")
        DbxInitialDate.Select()
    End Sub
    Private Sub DateBox_TextChanged(sender As Object, e As EventArgs) Handles DbxInitialDate.TextChanged, DbxFinalDate.TextChanged
        If DbxInitialDate.Text.Replace("/", Nothing).Replace(" ", Nothing) <> Nothing And
            DbxFinalDate.Text.Replace("/", Nothing).Replace(" ", Nothing) <> Nothing Then
            BtnGenerate.Enabled = True
        Else
            BtnGenerate.Enabled = False
        End If
        EprValidation.Clear()
    End Sub
    Private Function IsValidFields() As Boolean
        If Not String.IsNullOrEmpty(DbxInitialDate.Text.Replace("/", Nothing).Trim()) And Not IsDate(DbxInitialDate.Text) Then
            EprValidation.SetError(LblInitialDate, "Data inválida.")
            EprValidation.SetIconAlignment(LblInitialDate, ErrorIconAlignment.MiddleRight)
            Return False
        ElseIf Not String.IsNullOrEmpty(DbxFinalDate.Text.Replace("/", Nothing).Trim()) And Not IsDate(DbxFinalDate.Text) Then
            EprValidation.SetError(LblFinalDate, "Data inválida.")
            EprValidation.SetIconAlignment(LblFinalDate, ErrorIconAlignment.MiddleRight)
            Return False
        ElseIf IsDate(DbxFinalDate.Text) And IsDate(DbxInitialDate.Text) AndAlso CDate(DbxFinalDate.Text) < CDate(DbxInitialDate.Text) Then
            EprValidation.SetError(LblFinalDate, "A data final não pode ser menor do que a data inicial.")
            EprValidation.SetIconAlignment(LblFinalDate, ErrorIconAlignment.MiddleRight)
            Return False
        End If
        Return True
    End Function
    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        Dim Result As ReportResult
        If IsValidFields() Then
            Try
                Cursor = Cursors.WaitCursor
                BtnGenerate.Enabled = False
                Result = RequestReport.ProcessPendingItems(DbxInitialDate.Text, DbxFinalDate.Text, CbxShowResponsible.Checked, CbxShowDestination.Checked)
                DialogResult = DialogResult.OK
                FrmMain.OpenTab(New FrmReport(Result), GetEnumDescription(Routine.RequestPendingItems))
            Catch ex As Exception
                CMessageBox.Show("ERRO RQ005", "Ocorreu um erro ao gerar o relatório.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
End Class