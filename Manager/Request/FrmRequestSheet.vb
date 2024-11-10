Imports ControlLibrary
Imports ControlLibrary.Utility
Public Class FrmRequestSheet
    Private _Request As Request
    Private _ShowAlert As Boolean
    Public Sub New(Request As Request, ShowAlert As Boolean)
        InitializeComponent()
        _Request = Request
        _ShowAlert = ShowAlert
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
    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        Dim Result As ReportResult
        If _ShowAlert Then CMessageBox.Show("A requisição foi modificada sem ser salva. O relatório será gerado com base nos dados previamente salvos.", CMessageBoxType.Information)
        Try
            Cursor = Cursors.WaitCursor
            BtnGenerate.Enabled = False
            Result = RequestReport.ProcessRequestSheet(_Request, CbxShowCode.Checked, CbxShowReturned.Checked, CbxShowApplied.Checked, CbxShowLossed.Checked, CbxShowPending.Checked)
            DialogResult = DialogResult.OK
            FrmMain.OpenTab(New FrmReport(Result), GetEnumDescription(Routine.RequestSheetReport))
            CMessageBox.Show("O Relátório foi gerado na tela inicial.", CMessageBoxType.Information)
        Catch ex As Exception
            CMessageBox.Show("ERRO RQ010", "Ocorreu um erro ao gerar o relatório.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

End Class