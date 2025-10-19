Imports ControlLibrary
Imports MySql.Data.MySqlClient

Public Class FrmCashSheet
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
    Private Sub FrmCashReportPerResponsible_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CbxFlow.DataSource = CashFlow.GetCashFlows()
            CbxFlow.DisplayMember = "Name"
            CbxFlow.ValueMember = "ID"
            If CbxFlow.Items.Count > 0 Then CbxFlow.SelectedIndex = 0
            DbxInitialDate.Text = Today.AddMonths(-1).ToString("dd/MM/yyyy")
            DbxFinalDate.Text = Today.ToString("dd/MM/yyyy")
            DbxInitialDate.Select()
        Catch ex As Exception
            CMessageBox.Show("ERRO CS008", "Ocorreu um erro ao carregar os fluxos de caixa.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        End Try
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
        If String.IsNullOrEmpty(CbxFlow.Text) Then
            EprValidation.SetError(LblFlow, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblFlow, ErrorIconAlignment.MiddleRight)
            CbxFlow.Select()
            Return False
        ElseIf Not IsDate(DbxInitialDate.Text) Then
            EprValidation.SetError(LblInitialDate, "Data inválida.")
            EprValidation.SetIconAlignment(LblInitialDate, ErrorIconAlignment.MiddleRight)
            DbxInitialDate.Select()
            Return False
        ElseIf Not IsDate(DbxFinalDate.Text) Then
            EprValidation.SetError(LblFinalDate, "Data inválida.")
            EprValidation.SetIconAlignment(LblFinalDate, ErrorIconAlignment.MiddleRight)
            DbxFinalDate.Select()
            Return False
        ElseIf CDate(DbxFinalDate.Text) < CDate(DbxInitialDate.Text) Then
            EprValidation.SetError(LblFinalDate, "A data final não pode ser menor do que a data inicial.")
            EprValidation.SetIconAlignment(LblFinalDate, ErrorIconAlignment.MiddleRight)
            DbxInitialDate.Select()
            Return False
        End If
        Return True
    End Function
    Private Sub BtnGenerate_Click(sender As Object, e As EventArgs) Handles BtnGenerate.Click
        Dim Session = Locator.GetInstance(Of Session)
        Dim Result As ReportResult
        If IsValidFields() Then
            Cursor = Cursors.WaitCursor
            Try
                Dim Table As New DataTable
                Using Con As New MySqlConnection(Session.Setting.Database.GetConnectionString())
                    Using Cmd As New MySqlCommand("SELECT ID FROM Cash WHERE cashflowid = @cashflowid AND creation BETWEEN @initialdate AND @finaldate;", Con)
                        Cmd.Parameters.AddWithValue("@cashflowid", CbxFlow.SelectedValue)
                        Cmd.Parameters.AddWithValue("@initialdate", CDate(DbxInitialDate.Text))
                        Cmd.Parameters.AddWithValue("@finaldate", CDate(DbxFinalDate.Text))
                        Using Adp As New MySqlDataAdapter(Cmd)
                            Adp.Fill(Table)
                        End Using
                    End Using
                End Using
                If Table.Rows.Count > 0 Then
                    Dim c As Cash
                    Dim cs As New List(Of Cash)
                    For Each Row As DataRow In Table.Rows
                        c = New Cash
                        c.Load(Row.Item("id"), False)
                        cs.Add(c)
                    Next Row
                    BtnGenerate.Enabled = False
                    Result = CashReport.ProcessCashSheet(cs)
                    If Result IsNot Nothing Then
                        DialogResult = DialogResult.OK
                        FrmMain.OpenTab(New UcReport(Result), EnumHelper.GetEnumDescription(Routine.CashItemResponsible))
                    Else
                        CMessageBox.Show("Não existem despesas lançadas nesse período.", CMessageBoxType.Information)
                    End If
                Else
                    CMessageBox.Show("Não existem caixas lançados nesse período.", CMessageBoxType.Information)
                End If
            Catch ex As Exception
                CMessageBox.Show("ERRO CS010", "Ocorreu um erro ao gerar o relatório.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
End Class