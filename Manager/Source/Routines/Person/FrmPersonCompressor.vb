Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmPersonCompressor
    Private _PersonForm As FrmPerson
    Private _Person As Person
    Private _PersonCompressor As PersonCompressor
    Private _PersonCompressorShadow As PersonCompressor
    Private _Deleting As Boolean
    Private _Loading As Boolean
    Private _User As User
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
    Public Sub New(Person As Person, PersonCompressor As PersonCompressor, PersonForm As FrmPerson)
        InitializeComponent()
        _Person = Person
        _PersonCompressor = PersonCompressor
        _PersonCompressorShadow = PersonCompressor.Clone()
        _PersonForm = PersonForm
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        DgvNavigator.DataGridView = _PersonForm.DgvCompressor
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub Frm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvlWorkedHourSellable.Load()
        DgvlElapsedDaySellable.Load()
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        Dim Response As DialogResult
        Dim Revert As Boolean
        If BtnSave.Enabled Then
            Response = CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo)
            If Response = DialogResult.No Then
                Revert = True
            ElseIf Response = DialogResult.Yes Then
                If Not PreSave() Then
                    Revert = True
                    DgvNavigator.CancelNextMove = True
                End If
            End If
            If Revert Then
                For Each PersonCompressorSellable As PersonCompressorSellable In _PersonCompressor.WorkedHourSellables.ToArray.Reverse
                    If Not _PersonCompressorShadow.WorkedHourSellables.Any(Function(x) x.Equals(PersonCompressorSellable)) Then
                        _PersonCompressor.WorkedHourSellables.Remove(PersonCompressorSellable)
                    End If
                Next PersonCompressorSellable
                For Each ShadowPersonCompressorSellable As PersonCompressorSellable In _PersonCompressorShadow.WorkedHourSellables
                    If Not _PersonCompressor.WorkedHourSellables.Any(Function(x) x.Equals(ShadowPersonCompressorSellable)) Then
                        _PersonCompressor.WorkedHourSellables.Add(ShadowPersonCompressorSellable)
                    End If
                Next ShadowPersonCompressorSellable
                For Each PersonCompressorSellable As PersonCompressorSellable In _PersonCompressor.ElapsedDaySellables.ToArray.Reverse
                    If Not _PersonCompressorShadow.ElapsedDaySellables.Any(Function(x) x.Equals(PersonCompressorSellable)) Then
                        _PersonCompressor.ElapsedDaySellables.Remove(PersonCompressorSellable)
                    End If
                Next PersonCompressorSellable
                For Each ShadowPersonCompressorSellable As PersonCompressorSellable In _PersonCompressorShadow.ElapsedDaySellables
                    If Not _PersonCompressor.ElapsedDaySellables.Any(Function(x) x.Equals(ShadowPersonCompressorSellable)) Then
                        _PersonCompressor.ElapsedDaySellables.Add(ShadowPersonCompressorSellable)
                    End If
                Next ShadowPersonCompressorSellable
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        If _PersonForm.DgvCompressor.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _PersonCompressor = _Person.Compressors.Single(Function(x) x.Guid = _PersonForm.DgvCompressor.SelectedRows(0).Cells("Guid").Value)
            _PersonCompressorShadow = _PersonCompressor.Clone()
            LoadForm()
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim Response As DialogResult
        Dim Revert As Boolean
        If Not Locator.GetInstance(Of Session).AutoCloseApp Then
            If Not _Deleting AndAlso BtnSave.Enabled Then
                Response = CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo)
                If Response = DialogResult.No Then
                    Revert = True
                ElseIf Response = DialogResult.Yes Then
                    If Not PreSave() Then
                        e.Cancel = True
                        Revert = True
                    End If
                End If
                If Revert Then
                    For Each PersonCompressorSellable As PersonCompressorSellable In _PersonCompressor.WorkedHourSellables.ToArray.Reverse
                        If Not _PersonCompressorShadow.WorkedHourSellables.Any(Function(x) x.Equals(PersonCompressorSellable)) Then
                            _PersonCompressor.WorkedHourSellables.Remove(PersonCompressorSellable)
                        End If
                    Next PersonCompressorSellable
                    For Each ShadowPersonCompressorSellable As PersonCompressorSellable In _PersonCompressorShadow.WorkedHourSellables
                        If Not _PersonCompressor.WorkedHourSellables.Any(Function(x) x.Equals(ShadowPersonCompressorSellable)) Then
                            _PersonCompressor.WorkedHourSellables.Add(ShadowPersonCompressorSellable)
                        End If
                    Next ShadowPersonCompressorSellable
                    For Each PersonCompressorSellable As PersonCompressorSellable In _PersonCompressor.ElapsedDaySellables.ToArray.Reverse
                        If Not _PersonCompressorShadow.ElapsedDaySellables.Any(Function(x) x.Equals(PersonCompressorSellable)) Then
                            _PersonCompressor.ElapsedDaySellables.Remove(PersonCompressorSellable)
                        End If
                    Next PersonCompressorSellable
                    For Each ShadowPersonCompressorSellable As PersonCompressorSellable In _PersonCompressorShadow.ElapsedDaySellables
                        If Not _PersonCompressor.ElapsedDaySellables.Any(Function(x) x.Equals(ShadowPersonCompressorSellable)) Then
                            _PersonCompressor.ElapsedDaySellables.Add(ShadowPersonCompressorSellable)
                        End If
                    Next ShadowPersonCompressorSellable
                End If
            End If
            _Deleting = False
        End If
    End Sub
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then
                    For Each PersonCompressorSellable As PersonCompressorSellable In _PersonCompressor.WorkedHourSellables.ToArray.Reverse
                        If Not _PersonCompressorShadow.WorkedHourSellables.Any(Function(x) x.Equals(PersonCompressorSellable)) Then
                            _PersonCompressor.WorkedHourSellables.Remove(PersonCompressorSellable)
                        End If
                    Next PersonCompressorSellable
                    For Each ShadowPersonCompressorSellable As PersonCompressorSellable In _PersonCompressorShadow.WorkedHourSellables
                        If Not _PersonCompressor.WorkedHourSellables.Any(Function(x) x.Equals(ShadowPersonCompressorSellable)) Then
                            _PersonCompressor.WorkedHourSellables.Add(ShadowPersonCompressorSellable)
                        End If
                    Next ShadowPersonCompressorSellable
                End If
            End If
        End If
        _PersonCompressor = New PersonCompressor()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _PersonForm.DgvCompressor.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _PersonCompressor = _Person.Compressors.Single(Function(x) x.Guid = _PersonForm.DgvCompressor.SelectedRows(0).Cells("Guid").Value)
                _Person.Compressors.Remove(_PersonCompressor)
                _PersonForm.DgvCompressor.Fill(_Person.Compressors)
                _PersonForm.DgvCompressorLayout.Load()
                _Deleting = True
                Dispose()
                _PersonForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub TcPersonCompressor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcPersonCompressor.SelectedIndexChanged
        If TcPersonCompressor.SelectedTab Is TabMain Then
            Size = New Size(475, 265)
            FormBorderStyle = FormBorderStyle.FixedSingle
            WindowState = FormWindowState.Normal
            MaximizeBox = False
        Else
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Maximized
            MaximizeBox = True
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.PersonCompressor, _PersonCompressor.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
            If _PersonCompressor.Status = SimpleStatus.Active Then
                CMessageBox.Show("O registro foi marcado para ser inativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active)
            If _PersonCompressor.Status = SimpleStatus.Inactive Then
                CMessageBox.Show("O registro foi marcado para ser ativado, salve para concluir a alteração.", CMessageBoxType.Information, CMessageBoxButtons.OK)
            End If
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
    End Sub
    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles QbxCompressor.TextChanged, TxtSerialNumber.TextChanged, TxtPatrimony.TextChanged, TxtSector.TextChanged, DbxUnitCapacity.TextChanged, TxtNote.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub TxtNote_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles TxtNote.LinkClicked
        Process.Start(e.LinkText)
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        TcPersonCompressor.SelectedTab = TabMain
        TcMaintenance.SelectedTab = TabWorkedHourSellable
        LblOrderValue.Text = If(_PersonCompressor.IsSaved, _PersonForm.DgvCompressor.SelectedRows(0).Cells("Order").Value, 0)
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_PersonCompressor.Status)
        LblCreationValue.Text = _PersonCompressor.Creation
        QbxCompressor.Unfreeze()
        QbxCompressor.Freeze(_PersonCompressor.CompressorID)
        TxtSerialNumber.Text = _PersonCompressor.SerialNumber
        TxtPatrimony.Text = _PersonCompressor.Patrimony
        TxtSector.Text = _PersonCompressor.Sector
        DbxUnitCapacity.Text = _PersonCompressor.UnitCapacity
        TxtNote.Text = _PersonCompressor.Note
        If Not _PersonCompressor.IsSaved Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        DgvWorkedHourSellable.Fill(_PersonCompressor.WorkedHourSellables)
        DgvElapsedDaySellable.Fill(_PersonCompressor.ElapsedDaySellables)
        BtnSave.Enabled = False
        QbxCompressor.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(QbxCompressor.Text) Then
            TcPersonCompressor.SelectedTab = TabMain
            EprValidation.SetError(LblCompressor, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblCompressor, ErrorIconAlignment.MiddleRight)
            QbxCompressor.Select()
            Return False
        ElseIf Not QbxCompressor.IsFreezed Then
            TcPersonCompressor.SelectedTab = TabMain
            EprValidation.SetError(LblCompressor, "Compressor não encontrado.")
            EprValidation.SetIconAlignment(LblCompressor, ErrorIconAlignment.MiddleRight)
            QbxCompressor.Select()
            Return False
        ElseIf DbxUnitCapacity.DecimalValue <= 0 Then
            TcPersonCompressor.SelectedTab = TabMain
            EprValidation.SetError(LblUnitCapacity, "A capacidade da unidade deve ser maior que 0.")
            EprValidation.SetIconAlignment(LblUnitCapacity, ErrorIconAlignment.MiddleRight)
            DbxUnitCapacity.Select()
            Return False
        ElseIf _PersonCompressor.WorkedHourSellables.Any(Function(x) x.Capacity = 0) Then
            TcPersonCompressor.SelectedTab = TabMaintenance
            TcMaintenance.SelectedTab = TabWorkedHourSellable
            EprValidation.SetError(TsWorkedHourSellable, "Informe a capacidade de todos os itens controlados por hora trabalhada.")
            EprValidation.SetIconAlignment(TsWorkedHourSellable, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsWorkedHourSellable, -90)
            DgvWorkedHourSellable.Select()
            Return False
        ElseIf _PersonCompressor.ElapsedDaySellables.Any(Function(x) x.Capacity = 0) Then
            TcPersonCompressor.SelectedTab = TabMaintenance
            TcMaintenance.SelectedTab = TabElapsedDaySellable
            EprValidation.SetError(TsElapsedDaySellable, "Informe a capacidade de todos os itens controlados por dias corridos.")
            EprValidation.SetIconAlignment(TsElapsedDaySellable, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsElapsedDaySellable, -90)
            DgvElapsedDaySellable.Select()
            Return False
        ElseIf Not _PersonCompressor.WorkedHourSellables.Any(Function(x) x.SellableBind = CompressorSellableBindType.AirFilter) Then
            TcPersonCompressor.SelectedTab = TabMaintenance
            TcMaintenance.SelectedTab = TabWorkedHourSellable
            EprValidation.SetError(TsWorkedHourSellable, "Pelo menos um item precisa estar vinculado com filtro de ar.")
            EprValidation.SetIconAlignment(TsWorkedHourSellable, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsWorkedHourSellable, -90)
            DgvWorkedHourSellable.Select()
            Return False
        ElseIf Not _PersonCompressor.WorkedHourSellables.Any(Function(x) x.SellableBind = CompressorSellableBindType.OilFilter) Then
            TcPersonCompressor.SelectedTab = TabMaintenance
            TcMaintenance.SelectedTab = TabWorkedHourSellable
            EprValidation.SetError(TsWorkedHourSellable, "Pelo menos um item precisa estar vinculado com filtro de óleo.")
            EprValidation.SetIconAlignment(TsWorkedHourSellable, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsWorkedHourSellable, -90)
            DgvWorkedHourSellable.Select()
            Return False
        ElseIf Not _PersonCompressor.WorkedHourSellables.Any(Function(x) x.SellableBind = CompressorSellableBindType.Separator) Then
            TcPersonCompressor.SelectedTab = TabMaintenance
            TcMaintenance.SelectedTab = TabWorkedHourSellable
            EprValidation.SetError(TsWorkedHourSellable, "Pelo menos um item precisa estar vinculado com separador.")
            EprValidation.SetIconAlignment(TsWorkedHourSellable, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsWorkedHourSellable, -90)
            DgvWorkedHourSellable.Select()
            Return False
        ElseIf Not _PersonCompressor.WorkedHourSellables.Any(Function(x) x.SellableBind = CompressorSellableBindType.Oil) Then
            TcPersonCompressor.SelectedTab = TabMaintenance
            TcMaintenance.SelectedTab = TabWorkedHourSellable
            EprValidation.SetError(TsWorkedHourSellable, "Pelo menos um item precisa estar vinculado com óleo")
            EprValidation.SetIconAlignment(TsWorkedHourSellable, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsWorkedHourSellable, -90)
            DgvWorkedHourSellable.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        TxtSector.Text = TxtSector.Text.Trim.ToUnaccented()
        TxtSerialNumber.Text = TxtSerialNumber.Text.Trim.ToUnaccented()
        TxtPatrimony.Text = TxtPatrimony.Text.Trim.ToUnaccented()
        TxtNote.Text = TxtNote.Text.ToUpper.ToUnaccented()
        If IsValidFields() Then
            If _PersonCompressor.IsSaved Then
                With _Person.Compressors.Single(Function(x) x.Guid = _PersonCompressor.Guid)
                    .Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                    .Compressor = New Lazy(Of Compressor)(Function() New Compressor().Load(QbxCompressor.FreezedPrimaryKey, False))
                    .CompressorID = QbxCompressor.FreezedPrimaryKey
                    .CompressorName = QbxCompressor.Text
                    .SerialNumber = TxtSerialNumber.Text
                    .Patrimony = TxtPatrimony.Text
                    .Sector = TxtSector.Text
                    .UnitCapacity = DbxUnitCapacity.Text
                    .Note = TxtNote.Text
                End With
            Else
                _PersonCompressor.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _PersonCompressor.Compressor = New Lazy(Of Compressor)(Function() New Compressor().Load(QbxCompressor.FreezedPrimaryKey, False))
                _PersonCompressor.CompressorID = QbxCompressor.FreezedPrimaryKey
                _PersonCompressor.CompressorName = QbxCompressor.Text
                _PersonCompressor.SerialNumber = TxtSerialNumber.Text
                _PersonCompressor.Patrimony = TxtPatrimony.Text
                _PersonCompressor.Sector = TxtSector.Text
                _PersonCompressor.UnitCapacity = DbxUnitCapacity.Text
                _PersonCompressor.Note = TxtNote.Text
                _PersonCompressor.SetIsSaved(True)
                _Person.Compressors.Add(_PersonCompressor)
            End If
            _PersonForm.DgvCompressor.Fill(_Person.Compressors)
            _PersonForm.DgvCompressorLayout.Load()
            BtnSave.Enabled = False
            If Not _PersonCompressor.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _PersonForm.DgvCompressor.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _PersonCompressor.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _PersonForm.DgvCompressor.SelectedRows(0).Cells("Order").Value
            _PersonForm.EprValidation.Clear()
            _PersonForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnView.Visible = False
        BtnNew.Visible = False
        BtnFilter.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub QbxCompressor_Enter(sender As Object, e As EventArgs) Handles QbxCompressor.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxCompressor.IsFreezed And _User.CanWrite(Routine.Compressor)
        BtnNew.Visible = _User.CanWrite(Routine.Compressor)
        BtnFilter.Visible = _User.CanAccess(Routine.Compressor)
    End Sub
    Private Sub QbxCompressor_Leave(sender As Object, e As EventArgs) Handles QbxCompressor.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxCompressor_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxCompressor.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnView.Visible = QbxCompressor.IsFreezed And _User.CanWrite(Routine.Compressor)
        If Not _Loading Then BtnImport.Visible = QbxCompressor.IsFreezed
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Compressor As Compressor
        Dim Form As FrmCompressor
        Compressor = New Compressor
        Form = New FrmCompressor(Compressor)
        Form.ShowDialog()
        EprValidation.Clear()
        If Compressor.ID > 0 Then
            QbxCompressor.Freeze(Compressor.ID)
        End If
        QbxCompressor.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim Form As New FrmCompressor(New Compressor().Load(QbxCompressor.FreezedPrimaryKey, True))
        Form.ShowDialog()
        QbxCompressor.Freeze(QbxCompressor.FreezedPrimaryKey)
        QbxCompressor.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New CompressorQueriedBoxFilter(), QbxCompressor)
        FilterForm.Text = "Filtro de Compressores"
        FilterForm.ShowDialog()
        QbxCompressor.Select()
    End Sub
    Private Sub BtnIncludeWorkedHourSellable_Click(sender As Object, e As EventArgs) Handles BtnIncludeWorkedHourSellable.Click
        Dim Form As New FrmPersonCompressorSellableWorkedHour(_PersonCompressor, New PersonCompressorSellable(CompressorSellableControlType.WorkedHour), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditWorkedHourSellable_Click(sender As Object, e As EventArgs) Handles BtnEditWorkedHourSellable.Click
        Dim Form As FrmPersonCompressorSellableWorkedHour
        Dim PersonCompressorWorkedHourSellable As PersonCompressorSellable
        If DgvWorkedHourSellable.SelectedRows.Count = 1 Then
            PersonCompressorWorkedHourSellable = _PersonCompressor.WorkedHourSellables.Single(Function(X) X.Guid = DgvWorkedHourSellable.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmPersonCompressorSellableWorkedHour(_PersonCompressor, PersonCompressorWorkedHourSellable, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteWorkedHourSellable_Click(sender As Object, e As EventArgs) Handles BtnDeleteWorkedHourSellable.Click
        Dim WorkedHourSellable As PersonCompressorSellable
        If DgvWorkedHourSellable.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                WorkedHourSellable = _PersonCompressor.WorkedHourSellables.Single(Function(X) X.Guid = DgvWorkedHourSellable.SelectedRows(0).Cells("Guid").Value)
                _PersonCompressor.WorkedHourSellables.Remove(WorkedHourSellable)
                DgvWorkedHourSellable.Fill(_PersonCompressor.WorkedHourSellables)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnIncludeElapsedDaySellable_Click(sender As Object, e As EventArgs) Handles BtnIncludeElapsedDaySellable.Click
        Dim Form As New FrmPersonCompressorSellableElapsedDay(_PersonCompressor, New PersonCompressorSellable(CompressorSellableControlType.ElapsedDay), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditElapsedDaySellable_Click(sender As Object, e As EventArgs) Handles BtnEditElapsedDaySellable.Click
        Dim Form As FrmPersonCompressorSellableElapsedDay
        Dim ElapsedDaySellable As PersonCompressorSellable
        If DgvElapsedDaySellable.SelectedRows.Count = 1 Then
            ElapsedDaySellable = _PersonCompressor.ElapsedDaySellables.Single(Function(X) X.Guid = DgvElapsedDaySellable.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmPersonCompressorSellableElapsedDay(_PersonCompressor, ElapsedDaySellable, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteElapsedDaySellable_Click(sender As Object, e As EventArgs) Handles BtnDeleteElapsedDaySellable.Click
        Dim ElapsedDaySellable As PersonCompressorSellable
        If DgvElapsedDaySellable.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                ElapsedDaySellable = _PersonCompressor.ElapsedDaySellables.Single(Function(X) X.Guid = DgvElapsedDaySellable.SelectedRows(0).Cells("Guid").Value)
                _PersonCompressor.ElapsedDaySellables.Remove(ElapsedDaySellable)
                DgvElapsedDaySellable.Fill(_PersonCompressor.ElapsedDaySellables)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvSellable_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvWorkedHourSellable.CellFormatting, DgvElapsedDaySellable.CellFormatting
        Dim Dgv As DataGridView = sender
        If e.ColumnIndex = Dgv.Columns("Status").Index Then
            Select Case e.Value
                Case Is = SimpleStatus.Active
                    e.Value = EnumHelper.GetEnumDescription(SimpleStatus.Active)
                    e.CellStyle.ForeColor = Color.DarkBlue
                Case Is = SimpleStatus.Inactive
                    e.Value = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
                    e.CellStyle.ForeColor = Color.DarkRed
            End Select
        ElseIf e.ColumnIndex = Dgv.Columns("Quantity").Index Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            e.CellStyle.Format = "N2"
        ElseIf e.ColumnIndex = Dgv.Columns("Capacity").Index Then
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            e.CellStyle.Format = "N0"
        End If
    End Sub
    Private Sub DgvWorkedHourSellable_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvWorkedHourSellable.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvWorkedHourSellable.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditWorkedHourSellable.PerformClick()
        End If
    End Sub
    Private Sub DgvElapsedDaySellable_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvElapsedDaySellable.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvElapsedDaySellable.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditElapsedDaySellable.PerformClick()
        End If
    End Sub
    Private Sub TxtFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilterWorkedHourSellable.KeyPress, TxtFilterElapsedDaySellable.KeyPress
        Dim LstChar As New List(Of Char) From {" ", ".", ",", "-", "/", "(", ")", "+", "*", "%", "&", "@", "#", "$", "<", ">", "\"}
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not LstChar.Contains(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtFilterWorkedHourSellable_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterWorkedHourSellable.TextChanged
        FilterWorkedHourSellable()
    End Sub
    Private Sub FilterWorkedHourSellable()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1} OR {2}",
                                                 "Name LIKE '%@VALUE%'",
                                                 "Code LIKE '%@VALUE%'",
                                                 "Convert([Product], 'System.String') LIKE '%@VALUE%'"
                                            )
        If DgvWorkedHourSellable.DataSource IsNot Nothing Then
            Table = DgvWorkedHourSellable.DataSource
            View = Table.DefaultView
            If TxtFilterWorkedHourSellable.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterWorkedHourSellable.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub TxtFilterElapsedDaySellable_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterElapsedDaySellable.TextChanged
        FilterElapsedDaySellable()
    End Sub
    Private Sub FilterElapsedDaySellable()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1} OR {2}",
                                                 "Name LIKE '%@VALUE%'",
                                                 "Code LIKE '%@VALUE%'",
                                                 "Convert([Product], 'System.String') LIKE '%@VALUE%'"
                                            )
        If DgvElapsedDaySellable.DataSource IsNot Nothing Then
            Table = DgvElapsedDaySellable.DataSource
            View = Table.DefaultView
            If TxtFilterElapsedDaySellable.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterElapsedDaySellable.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub DgvWorkedHourSellable_SelectionChanged(sender As Object, e As EventArgs) Handles DgvWorkedHourSellable.SelectionChanged
        If DgvWorkedHourSellable.SelectedRows.Count = 0 Then
            BtnEditWorkedHourSellable.Enabled = False
            BtnDeleteWorkedHourSellable.Enabled = False
        Else
            BtnEditWorkedHourSellable.Enabled = True
            BtnDeleteWorkedHourSellable.Enabled = True
        End If
    End Sub
    Private Sub DgvElapsedDaySellable_SelectionChanged(sender As Object, e As EventArgs) Handles DgvElapsedDaySellable.SelectionChanged
        If DgvElapsedDaySellable.SelectedRows.Count = 0 Then
            BtnEditElapsedDaySellable.Enabled = False
            BtnDeleteElapsedDaySellable.Enabled = False
        Else
            BtnEditElapsedDaySellable.Enabled = True
            BtnDeleteElapsedDaySellable.Enabled = True
        End If
    End Sub
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Dim Form As FrmPersonCompressorImport
        Cursor = Cursors.WaitCursor
        Form = New FrmPersonCompressorImport(New Compressor().Load(QbxCompressor.FreezedPrimaryKey, False), _PersonCompressor)
        If Form.ShowDialog() = DialogResult.OK Then
            Cursor = Cursors.WaitCursor


            colocar a coluna productid e serviceid no datagridview

            Dim tb As DataTable = CType(Form.DgvWorkedHourSellable.DataSource, DataTable)

            For Each Row As DataGridViewRow In Form.DgvWorkedHourSellable.Rows
                If Row.Cells("X").Value = True Then
                    Dim Sellable As New PersonCompressorSellable(CompressorSellableControlType.WorkedHour) With {
                        .Status = SimpleStatus.Active,
                        .Sellable = New Lazy(Of Sellable)(Function()
                                                              If Row.Cells("productid") IsNot DBNull.Value Then
                                                                  Return New Product().Load(Row.Cells("productid").Value, False)
                                                              Else
                                                                  Return New Service().Load(Row.Cells("serviceid").Value, False)
                                                              End If
                                                          End Function),
                        .SellableID = Row.Cells("SellableID").Value,
                        .Code = Row.Cells("Code").Value,
                        .Name = Row.Cells("Name").Value,
                        .Quantity = Row.Cells("Quantity").Value
                    }
                    _PersonCompressor.WorkedHourSellables.Add(Sellable)
                    _PersonCompressor.WorkedHourSellables.Last.SetIsSaved(True)
                    BtnSave.Enabled = True
                End If
            Next Row
            For Each Row As DataGridViewRow In Form.DgvElapsedDaySellable.Rows
                If Row.Cells("X").Value = True Then
                    Dim Sellable As New PersonCompressorSellable(CompressorSellableControlType.ElapsedDay) With {
                        .Status = SimpleStatus.Active,
                        .Sellable = New Lazy(Of Sellable)(Function() Row.Cells("SellableID").Value),
                        .SellableID = Row.Cells("SellableID").Value,
                        .Code = Row.Cells("Code").Value,
                        .Name = Row.Cells("Name").Value,
                        .Quantity = Row.Cells("Quantity").Value
                    }
                    _PersonCompressor.ElapsedDaySellables.Add(Sellable)
                    _PersonCompressor.ElapsedDaySellables.Last.SetIsSaved(True)
                    BtnSave.Enabled = True
                End If
            Next Row
        End If
        DgvWorkedHourSellable.Fill(_PersonCompressor.WorkedHourSellables)
        DgvElapsedDaySellable.Fill(_PersonCompressor.ElapsedDaySellables)
        EprValidation.Clear()
        Cursor = Cursors.Default
    End Sub
    Private Sub TxtFilterWorkedHourSellable_Enter(sender As Object, e As EventArgs) Handles TxtFilterWorkedHourSellable.Enter
        EprInformation.SetError(TsWorkedHourSellable, "Filtrando os campos: Código e Produto/Serviço.")
        EprInformation.SetIconAlignment(TsWorkedHourSellable, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsWorkedHourSellable, -365)
    End Sub
    Private Sub TxtFilterWorkedHourSellable_Leave(sender As Object, e As EventArgs) Handles TxtFilterWorkedHourSellable.Leave
        EprInformation.Clear()
    End Sub
    Private Sub TxtFilterElapsedDaySellable_Enter(sender As Object, e As EventArgs) Handles TxtFilterElapsedDaySellable.Enter
        EprInformation.SetError(TsElapsedDaySellable, "Filtrando os campos: Código e Produto/Serviço.")
        EprInformation.SetIconAlignment(TsElapsedDaySellable, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsElapsedDaySellable, -365)
    End Sub
    Private Sub TxtFilterElapsedDaySellable_Leave(sender As Object, e As EventArgs) Handles TxtFilterElapsedDaySellable.Leave
        EprInformation.Clear()
    End Sub
    Private Sub DgvWorkedHourSellable_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvWorkedHourSellable.DataSourceChanged
        FilterWorkedHourSellable()
    End Sub
    Private Sub DgvElapsedDaySellable_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvElapsedDaySellable.DataSourceChanged
        FilterElapsedDaySellable()
    End Sub
End Class