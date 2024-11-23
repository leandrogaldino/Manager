Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient
Imports Syncfusion.Windows.Forms

Public Class FrmVisitSchedule
    Private _VisitSchedule As VisitSchedule
    Private _VisitSchedulesForm As FrmVisitSchedules
    Private _VisitSchedulesGrid As DataGridView
    Private _Filter As VisitScheduleFilter
    Private _Deleting As Boolean
    Private _Loading As Boolean
    Private _LoggedUser As User
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
    <DebuggerStepThrough>
    Protected Overrides Sub OnResize(e As EventArgs)
        Const _MouseButtonUp As Long = &HA0
        DefWndProc(New Message With {.Msg = _MouseButtonUp})
        MyBase.OnResize(e)
    End Sub
    Public Sub New(VisitSchedule As VisitSchedule, VisitSchedulesForm As FrmVisitSchedules)
        InitializeComponent()
        _VisitSchedule = VisitSchedule
        _VisitSchedulesForm = VisitSchedulesForm
        _VisitSchedulesGrid = _VisitSchedulesForm.DgvData
        _Filter = CType(_VisitSchedulesForm.PgFilter.SelectedObject, VisitScheduleFilter)
        _LoggedUser = Locator.GetInstance(Of Session).User
        LoadForm()
        LoadData()
    End Sub
    Public Sub New(VisitSchedule As VisitSchedule)
        InitializeComponent()
        _VisitSchedule = VisitSchedule
        _LoggedUser = Locator.GetInstance(Of Session).User
        Height -= TsNavigation.Height
        RbtGathering.Top -= TsNavigation.Height
        RbtPreventive.Top -= TsNavigation.Height
        RbtCalled.Top -= TsNavigation.Height
        RbtContract.Top -= TsNavigation.Height
        FlpCustomer.Top -= TsNavigation.Height
        LblCustomer.Top -= TsNavigation.Height
        QbxCustomer.Top -= TsNavigation.Height
        LblCompressor.Top -= TsNavigation.Height
        QbxCompressor.Top -= TsNavigation.Height
        LblInstructions.Top -= TsNavigation.Height
        TxtInstructions.Top -= TsNavigation.Height
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        LoadForm()
        LoadData()
    End Sub
    Private Sub LoadForm()
        DgvNavigator.DataGridView = _VisitSchedulesGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _LoggedUser.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _VisitSchedule.ID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_VisitSchedule.Status)


        LblCreationValue.Text = _VisitSchedule.Creation.ToString("dd/MM/yyyy")


        RbtGathering.Checked = _VisitSchedule.VisitType = VisitScheduleType.Gathering
        RbtPreventive.Checked = _VisitSchedule.VisitType = VisitScheduleType.Preventive
        RbtCalled.Checked = _VisitSchedule.VisitType = VisitScheduleType.Called
        RbtContract.Checked = _VisitSchedule.VisitType = VisitScheduleType.Contract






        QbxCompressor.Conditions.Clear()
        QbxCompressor.Parameters.Clear()
        QbxCompressor.Conditions.Add(New QueriedBox.Condition With {.TableNameOrAlias = "personcompressor", .FieldName = "statusid", .[Operator] = "=", .Value = "@statusid"})
        QbxCompressor.Parameters.Add(New QueriedBox.Parameter With {.ParameterName = "@statusid", .ParameterValue = 0})
        QbxCompressor.Conditions.Add(New QueriedBox.Condition With {.TableNameOrAlias = "personcompressor", .FieldName = "personid", .[Operator] = "=", .Value = "@personid"})
        QbxCompressor.Parameters.Add(New QueriedBox.Parameter With {.ParameterName = "@personid", .ParameterValue = QbxCustomer.FreezedPrimaryKey})
        QbxCustomer.Unfreeze()
        QbxCustomer.Freeze(_VisitSchedule.Customer.ID)
        QbxCompressor.Unfreeze()
        QbxCompressor.Freeze(_VisitSchedule.Compressor.ID)

        TxtInstructions.Text = _VisitSchedule.Instructions

        BtnDelete.Enabled = _VisitSchedule.ID > 0 And _LoggedUser.CanDelete(Routine.VisitSchedule)
        Text = "Agendamento de Visita"
        If _VisitSchedule.LockInfo.IsLocked And Not _VisitSchedule.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _VisitSchedule.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _VisitSchedule.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        QbxCustomer.Select()
        _Loading = False
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then
                    DgvNavigator.CancelNextMove = True
                End If
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        Try
            Cursor = Cursors.WaitCursor
            _VisitSchedule.Load(_VisitSchedulesGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO RT001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not Locator.GetInstance(Of Session).AutoCloseApp Then
            If Not _Deleting AndAlso BtnSave.Enabled Then
                If BtnSave.Enabled Then
                    If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                        If Not Save() Then e.Cancel = True
                    End If
                End If
            End If
            _Deleting = False
        End If
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then Exit Sub
            End If
        End If
        _VisitSchedule = New VisitSchedule
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _VisitSchedule.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _VisitSchedule.LockInfo.IsLocked Or (_VisitSchedule.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _VisitSchedule.LockInfo.SessionToken) Then
                        _VisitSchedule.Delete()
                        If _VisitSchedulesGrid IsNot Nothing Then
                            _Filter.Filter()
                            _VisitSchedulesForm.DgvlVisitScheduleLayout.Load()
                            _VisitSchedulesGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _VisitSchedule.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO RT002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.VisitSchedule, _VisitSchedule.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(VisitScheduleStatus.Pending) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(VisitScheduleStatus.Canceled)
            If _VisitSchedule.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser cancelado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(VisitScheduleStatus.Canceled) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(VisitScheduleStatus.Pending)
            If _VisitSchedule.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser cancelado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)

        LblStatusValue.Text = BtnStatusValue.Text
        LblStatusValue.ForeColor = BtnStatusValue.ForeColor

    End Sub
    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtInstructions.TextChanged, QbxCustomer.TextChanged, QbxCompressor.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub Rbt_TextChanged(sender As Object, e As EventArgs) Handles RbtPreventive.CheckedChanged, RbtGathering.CheckedChanged, RbtContract.CheckedChanged, RbtCalled.CheckedChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Insert And e.Control Then
            If BtnInclude.Enabled Then BtnInclude.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.Delete And e.Control Then
            If BtnDelete.Enabled Then BtnDelete.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.S And e.Control Then
            If BtnSave.Enabled Then BtnSave.PerformClick()
            e.SuppressKeyPress = True
        ElseIf e.KeyCode = Keys.F And e.Control Then
            BtnClose.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Save()
    End Sub
    Private Function IsValidFields() As Boolean
        Dim AnyChecked As Boolean = RbtGathering.Checked Or RbtPreventive.Checked Or RbtCalled.Checked Or RbtContract.Checked
        If Not AnyChecked Then
            EprValidation.SetError(RbtContract, "Marque qual é o tipo da visita.")
            EprValidation.SetIconAlignment(RbtContract, ErrorIconAlignment.MiddleRight)
            RbtGathering.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(QbxCustomer.Text) Then
            EprValidation.SetError(LblCustomer, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblCustomer, ErrorIconAlignment.MiddleRight)
            QbxCustomer.Select()
            Return False
        ElseIf Not QbxCustomer.IsFreezed Then
            EprValidation.SetError(LblCustomer, "Cliente não encontrado.")
            EprValidation.SetIconAlignment(LblCustomer, ErrorIconAlignment.MiddleRight)
            QbxCustomer.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(QbxCompressor.Text) Then
            EprValidation.SetError(LblCompressor, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblCompressor, ErrorIconAlignment.MiddleRight)
            QbxCompressor.Select()
            Return False
        ElseIf Not QbxCompressor.IsFreezed Then
            EprValidation.SetError(LblCompressor, "Compressor não encontrado.")
            EprValidation.SetIconAlignment(LblCompressor, ErrorIconAlignment.MiddleRight)
            QbxCompressor.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        TxtInstructions.Text = TxtInstructions.Text.Trim.ToUnaccented()
        If _VisitSchedule.LockInfo.IsLocked And _VisitSchedule.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _VisitSchedule.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                _VisitSchedule.Status = EnumHelper.GetEnumValue(Of VisitScheduleStatus)(BtnStatusValue.Text)
                _VisitSchedule.Customer = New Person().Load(QbxCustomer.FreezedPrimaryKey, False)
                _VisitSchedule.Compressor = _VisitSchedule.Customer.Compressors.Single(Function(x) x.ID = QbxCompressor.FreezedPrimaryKey)
                Try
                    Cursor = Cursors.WaitCursor
                    _VisitSchedule.SaveChanges()
                    _VisitSchedule.Lock()
                    LblIDValue.Text = _VisitSchedule.ID
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _LoggedUser.CanDelete(Routine.Route)
                    If _VisitSchedulesForm IsNot Nothing Then
                        _Filter.Filter()
                        _VisitSchedulesForm.DgvlVisitScheduleLayout.Load()
                        Row = _VisitSchedulesGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    CMessageBox.Show("ERRO RT003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Return False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Return False
            End If
        End If
    End Function

    Private Sub TmrCustomer_Tick(sender As Object, e As EventArgs) Handles TmrCustomer.Tick

    End Sub
    Private Sub QbxCustomer_Enter(sender As Object, e As EventArgs) Handles QbxCustomer.Enter
        TmrCustomer.Stop()
        BtnViewCustomer.Visible = QbxCustomer.IsFreezed And _LoggedUser.CanWrite(Routine.Person)
        BtnNewCustomer.Visible = _LoggedUser.CanWrite(Routine.Person)
        BtnFilterCustomer.Visible = _LoggedUser.CanAccess(Routine.Person)
    End Sub
    Private Sub QbxCustomer_Leave(sender As Object, e As EventArgs) Handles QbxCustomer.Leave
        TmrCustomer.Stop()
        TmrCustomer.Start()
    End Sub
    Private Sub QbxCustomer_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxCustomer.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnViewCustomer.Visible = QbxCustomer.IsFreezed And _LoggedUser.CanWrite(Routine.Person)
        QbxCompressor.Unfreeze()
        If QbxCompressor.Conditions.Count = 2 Then QbxCompressor.Conditions.RemoveAt(1)
        If QbxCompressor.Parameters.Count = 2 Then QbxCompressor.Parameters.RemoveAt(1)
        QbxCompressor.Conditions.Clear()
        QbxCompressor.Parameters.Clear()
        QbxCompressor.Conditions.Add(New QueriedBox.Condition With {.TableNameOrAlias = "personcompressor", .FieldName = "statusid", .[Operator] = "=", .Value = "@statusid"})
        QbxCompressor.Parameters.Add(New QueriedBox.Parameter With {.ParameterName = "@statusid", .ParameterValue = 0})
        QbxCompressor.Conditions.Add(New QueriedBox.Condition With {.TableNameOrAlias = "personcompressor", .FieldName = "personid", .[Operator] = "=", .Value = "@personid"})
        QbxCompressor.Parameters.Add(New QueriedBox.Parameter With {.ParameterName = "@personid", .ParameterValue = QbxCustomer.FreezedPrimaryKey})
        If QbxCustomer.IsFreezed Then
            QbxCompressor.Enabled = True
        Else
            QbxCompressor.Enabled = False
        End If
    End Sub
    Private Sub BtnNewCustomer_Click(sender As Object, e As EventArgs) Handles BtnNewCustomer.Click
        Dim Customer As Person
        Dim Form As FrmPerson
        Customer = New Person With {
            .IsCustomer = True,
            .ControlMaintenance = True
        }
        Form = New FrmPerson(Customer)
        Form.CbxIsCustomer.Enabled = False
        Form.CbxMaintenance.Enabled = False
        Form.ShowDialog()
        EprValidation.Clear()
        If Customer.ID > 0 Then
            QbxCustomer.Freeze(Customer.ID)
        End If
        QbxCustomer.Select()
    End Sub
    Private Sub BtnViewCustomer_Click(sender As Object, e As EventArgs) Handles BtnViewCustomer.Click
        Dim Form As New FrmPerson(New Person().Load(QbxCustomer.FreezedPrimaryKey, True))
        Dim FreezedCustomerID As Long = QbxCustomer.FreezedPrimaryKey
        Dim FreezedCompressorID As Long = QbxCompressor.FreezedPrimaryKey
        Form.CbxIsCustomer.Enabled = False
        Form.CbxMaintenance.Enabled = False
        Form.ShowDialog()
        _Loading = True
        QbxCustomer.Unfreeze()
        QbxCustomer.Freeze(FreezedCustomerID)
        QbxCompressor.Unfreeze()
        QbxCompressor.Freeze(FreezedCompressorID)
        QbxCustomer.Select()
        _Loading = False
    End Sub
    Private Sub BtnFilterCustomer_Click(sender As Object, e As EventArgs) Handles BtnFilterCustomer.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New PersonCustomerQueriedBoxFilter("Sim"), QbxCustomer) With {
            .Text = "Filtro de Clientes"
        }
        FilterForm.ShowDialog()
        QbxCustomer.Select()
    End Sub

    Private Sub FrmRoute_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _VisitSchedule.Unlock()
    End Sub

    Private Sub BtnEvaluation_Click(sender As Object, e As EventArgs) Handles BtnEvaluation.Click
        Using Frm As New FrmEvaluation(_VisitSchedule.Evaluation.Value)
            Frm.ShowDialog()
        End Using
    End Sub
End Class