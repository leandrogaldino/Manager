Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports DocumentFormat.OpenXml.Presentation
Imports MySql.Data.MySqlClient
Public Class FrmVisitSchedule
    Private _VisitSchedule As VisitSchedule
    Private _VisitSchedulesForm As FrmVisitSchedules
    Private _VisitSchedulesGrid As DataGridView
    Private _Filter As VisitScheduleFilter
    Private _Deleting As Boolean
    Private _Loading As Boolean
    Private _LoggedUser As User
    Private _UcVisitScheduleGeneratedItems As UcVisitScheduleGeneratedItems

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
        LblCallType.Top -= TsNavigation.Height
        CbxCallType.Top -= TsNavigation.Height
        LblScheduledDate.Top -= TsNavigation.Height
        DbxScheduledDate.Top -= TsNavigation.Height
        TbxScheduledTime.Top -= TsNavigation.Height
        LblPerformedDate.Top -= TsNavigation.Height
        TxtPerformedDate.Top -= TsNavigation.Height
        TxtPerformedTime.Top -= TsNavigation.Height
        LblGeneratedItems.Top -= TsNavigation.Height
        BtnGeneratedItems.Top -= TsNavigation.Height
        FlpCustomer.Top -= TsNavigation.Height
        LblCustomer.Top -= TsNavigation.Height
        QbxCustomer.Top -= TsNavigation.Height
        LblCompressor.Top -= TsNavigation.Height
        QbxCompressor.Top -= TsNavigation.Height
        FlpTechnician.Top -= TsNavigation.Height
        LblTechnician.Top -= TsNavigation.Height
        QbxTechnician.Top -= TsNavigation.Height
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
        CbxCallType.DataSource = EnumHelper.GetEnumDescriptions(Of CallType).OrderBy(Function(x) x).ToList()
        _UcVisitScheduleGeneratedItems = New UcVisitScheduleGeneratedItems()
        _CcoGeneratedItems.DropDownControl = _UcVisitScheduleGeneratedItems
        AddHandler _UcVisitScheduleGeneratedItems.ValueChanged, AddressOf UcVisitScheduleGeneratedItems_ValueChanged
        AddHandler _UcVisitScheduleGeneratedItems.EvaluationClick, AddressOf UcVisitScheduleGeneratedItems_EvaluationClick
        AddHandler _UcVisitScheduleGeneratedItems.VisitScheduleClick, AddressOf UcVisitScheduleGeneratedItems_VisitScheduleClick
    End Sub
    Private Sub UcVisitScheduleGeneratedItems_EvaluationClick(sender As Object, e As EventArgs)
        Dim Evaluation As Evaluation = If(sender, Nothing)
        Dim Frm As FrmEvaluation
        If Evaluation IsNot Nothing Then
            CcoGeneratedItems.CloseDropDown()
            If Evaluation.ID > 0 Then
                Frm = New FrmEvaluation(Evaluation)
                Frm.ShowDialog()
            Else
                CMessageBox.Show("Essa avaliação não existe mais.", CMessageBoxType.Information)
            End If
        End If
    End Sub
    Private Sub UcVisitScheduleGeneratedItems_VisitScheduleClick(sender As Object, e As EventArgs)
        Dim VisitSchedule As VisitSchedule = If(sender, Nothing)
        Dim Frm As FrmVisitSchedule
        If VisitSchedule IsNot Nothing Then
            CcoGeneratedItems.CloseDropDown()
            If VisitSchedule.ID > 0 Then
                Frm = New FrmVisitSchedule(VisitSchedule)
                ControlHelper.GetAllControls(Frm, False).ToList.ForEach(Sub(c) c.Enabled = False)
                Frm.PnButtons.Visible = False
                Frm.Height -= PnButtons.Height
                Frm.TsTitle.Visible = False
                Frm.LblCallType.Top -= TsTitle.Height
                Frm.CbxCallType.Top -= TsTitle.Height
                Frm.LblScheduledDate.Top -= TsTitle.Height
                Frm.DbxScheduledDate.Top -= TsTitle.Height
                Frm.TbxScheduledTime.Top -= TsTitle.Height
                Frm.LblPerformedDate.Top -= TsTitle.Height
                Frm.TxtPerformedDate.Top -= TsTitle.Height
                Frm.TxtPerformedTime.Top -= TsTitle.Height
                Frm.LblGeneratedItems.Top -= TsTitle.Height
                Frm.BtnGeneratedItems.Top -= TsTitle.Height
                Frm.FlpCustomer.Top -= TsTitle.Height
                Frm.LblCustomer.Top -= TsTitle.Height
                Frm.QbxCustomer.Top -= TsTitle.Height
                Frm.LblCompressor.Top -= TsTitle.Height
                Frm.QbxCompressor.Top -= TsTitle.Height
                Frm.FlpTechnician.Top -= TsTitle.Height
                Frm.LblTechnician.Top -= TsTitle.Height
                Frm.QbxTechnician.Top -= TsTitle.Height
                Frm.LblInstructions.Top -= TsTitle.Height
                Frm.TxtInstructions.Top -= TsTitle.Height
                Frm.LblGeneratedItems.Visible = False
                Frm.BtnGeneratedItems.Visible = False
                Frm.ShowDialog()
            Else
                CMessageBox.Show("Esse agendamento não existe mais.", CMessageBoxType.Information)
            End If
        End If
    End Sub
    Private Sub UcVisitScheduleGeneratedItems_ValueChanged(sender As Object, e As EventArgs)
        Dim HasEvaluation As String
        Dim HasSchedule As String
        HasEvaluation = If(_UcVisitScheduleGeneratedItems.EvaluationID > 0, "Sim", "Não")
        HasSchedule = If(_UcVisitScheduleGeneratedItems.ScheduleID > 0, "Sim", "Não")
        BtnGeneratedItems.Text = $"{HasEvaluation} | {HasSchedule}"
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _VisitSchedule.ID
        CbxCallType.Text = EnumHelper.GetEnumDescription(_VisitSchedule.CallType)
        DbxScheduledDate.Date = _VisitSchedule.ScheduledDate
        TbxScheduledTime.FromDateTime(_VisitSchedule.ScheduledDate)
        TxtPerformedDate.Text = If(_VisitSchedule.PerformedDate.HasValue, _VisitSchedule.PerformedDate.Value.ToString("dd/MM/yyyy"), String.Empty)
        TxtPerformedTime.Text = If(_VisitSchedule.PerformedDate.HasValue, _VisitSchedule.PerformedDate.Value.ToString("HH:mm"), String.Empty)
        _UcVisitScheduleGeneratedItems.EvaluationID = _VisitSchedule.EvaluationID
        _UcVisitScheduleGeneratedItems.ScheduleID = _VisitSchedule.OverridedVisitScheduleID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_VisitSchedule.Status)
        LblCreationValue.Text = _VisitSchedule.Creation.ToString("dd/MM/yyyy")
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
        BtnDelete.Enabled = Not String.IsNullOrEmpty(_VisitSchedule.ID) > 0 And _LoggedUser.CanDelete(Routine.VisitSchedule)
        Text = "Agendamento de Visita"
        If _VisitSchedule.LockInfo.IsLocked And Not _VisitSchedule.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _VisitSchedule.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _VisitSchedule.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Text = "Agendamento de Visita - SOMENTE LEITURA"
        End If
        If _VisitSchedule.Status = VisitScheduleStatus.Finished Then
            Text = "Agendamento de Visita - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        CbxCallType.Select()
        _Loading = False
        _UcVisitScheduleGeneratedItems.EvaluationID = 15
        _UcVisitScheduleGeneratedItems.ScheduleID = 1
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
            CMessageBox.Show("ERRO VS004", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
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
                    CMessageBox.Show("ERRO VS005", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(VisitScheduleStatus.Pending) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(VisitScheduleStatus.Canceled)
            If _VisitSchedule.Status = VisitScheduleStatus.Pending Then
                CMessageBox.Show("O registro foi marcado para ser cancelado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(VisitScheduleStatus.Canceled) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(VisitScheduleStatus.Pending)
            If _VisitSchedule.Status = VisitScheduleStatus.Canceled Then
                CMessageBox.Show("O registro foi marcado para pendente, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        Dim NewColor As Color = Color.Chocolate
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(VisitScheduleStatus.Pending) Then
            NewColor = Color.DarkBlue
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(VisitScheduleStatus.Canceled) Then
            NewColor = Color.DarkRed
        End If
        BtnStatusValue.ForeColor = NewColor
        LblStatusValue.Text = BtnStatusValue.Text
        LblStatusValue.ForeColor = BtnStatusValue.ForeColor
        BtnStatusValue.Visible = (BtnStatusValue.Text = EnumHelper.GetEnumDescription(VisitScheduleStatus.Pending) Or (BtnStatusValue.Text = EnumHelper.GetEnumDescription(VisitScheduleStatus.Canceled)))
        LblStatusValue.Visible = (BtnStatusValue.Text <> EnumHelper.GetEnumDescription(VisitScheduleStatus.Pending) And (BtnStatusValue.Text <> EnumHelper.GetEnumDescription(VisitScheduleStatus.Canceled)))
    End Sub
    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtInstructions.TextChanged, QbxCustomer.TextChanged, QbxCompressor.TextChanged, CbxCallType.SelectedIndexChanged, DbxScheduledDate.TextChanged, TbxScheduledTime.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub Rbt_TextChanged(sender As Object, e As EventArgs)
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
        If CbxCallType.Text = "" Then
            EprValidation.SetError(LblCallType, "Selecione um tipo de visita.")
            EprValidation.SetIconAlignment(LblCallType, ErrorIconAlignment.MiddleRight)
            LblCallType.Select()
            Return False
        ElseIf Not IsDate(DbxScheduledDate.Text) Then
            EprValidation.SetError(LblScheduledDate, "Data inválida")
            EprValidation.SetIconAlignment(LblScheduledDate, ErrorIconAlignment.MiddleRight)
            DbxScheduledDate.Select()
            Return False
        ElseIf IsDate(DbxScheduledDate.Text) AndAlso CDate(DbxScheduledDate.Date) < Today Then
            EprValidation.SetError(LblScheduledDate, "A data da visita precisa ser maior que hoje.")
            EprValidation.SetIconAlignment(LblScheduledDate, ErrorIconAlignment.MiddleRight)
            DbxScheduledDate.Select()
            Return False
        ElseIf Not TbxScheduledTime.Time.HasValue Then
            EprValidation.SetError(LblScheduledDate, "Hora inválida.")
            EprValidation.SetIconAlignment(LblScheduledDate, ErrorIconAlignment.MiddleRight)
            TbxScheduledTime.Select()
            Return False
        ElseIf DbxScheduledDate.Date = Today And Not TbxScheduledTime.Time > Now.TimeOfDay Then
            EprValidation.SetError(LblScheduledDate, "A hora da visita deve ser posterior ao momento atual.")
            EprValidation.SetIconAlignment(LblScheduledDate, ErrorIconAlignment.MiddleRight)
            TbxScheduledTime.Select()
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
        TxtInstructions.Text = TxtInstructions.Text.Trim().ToUnaccented()
        If _VisitSchedule.LockInfo.IsLocked AndAlso _VisitSchedule.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show($"Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {_VisitSchedule.LockInfo.LockedBy.Value.Username.ToTitle()}.", CMessageBoxType.Information)
            Return False
        End If
        If _VisitSchedule.Status = VisitScheduleStatus.Finished Then
            CMessageBox.Show("Não foi possível salvar, esse agendamento já foi finalizado.", CMessageBoxType.Information)
            Return False
        End If
        If Not IsValidFields() Then Return False
        _VisitSchedule.Status = EnumHelper.GetEnumValue(Of VisitScheduleStatus)(BtnStatusValue.Text)
        _VisitSchedule.CallType = EnumHelper.GetEnumValue(Of CallType)(CbxCallType.SelectedItem)
        _VisitSchedule.ScheduledDate = DbxScheduledDate.Date.Value + TbxScheduledTime.Time.Value
        _VisitSchedule.PerformedDate = If(Not String.IsNullOrEmpty(TxtPerformedDate.Text) AndAlso IsDate(TxtPerformedDate.Text), CType(CDate(TxtPerformedDate.Text) + TimeSpan.Parse(TxtPerformedTime.Text), Date?), Nothing)
        _VisitSchedule.Customer = New Person().Load(QbxCustomer.FreezedPrimaryKey, False)
        _VisitSchedule.Compressor = _VisitSchedule.Customer.Compressors.Single(Function(x) x.ID = QbxCompressor.FreezedPrimaryKey)
        _VisitSchedule.Instructions = TxtInstructions.Text
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
                Row = _VisitSchedulesGrid.Rows.Cast(Of DataGridViewRow)().FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                DgvNavigator.RefreshButtons()
            End If
            Return True
        Catch ex As Exception
            CMessageBox.Show("ERRO VS006", "Ocorreu um erro ao salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
            Return False
        Finally
            Cursor = Cursors.Default
        End Try
    End Function
    Private Sub TmrCustomer_Tick(sender As Object, e As EventArgs) Handles TmrCustomer.Tick
        BtnViewCustomer.Visible = False
        BtnNewCustomer.Visible = False
        BtnFilterCustomer.Visible = False
        TmrCustomer.Stop()
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

    Private Sub Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _VisitSchedule.Unlock()
    End Sub

End Class