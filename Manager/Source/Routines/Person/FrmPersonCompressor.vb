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
        DgvPartWorkedHourLayout.Load()
        DgvPartElapsedDayLayout.Load()
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
                For Each PersonCompressorPart As PersonCompressorPart In _PersonCompressor.PartsWorkedHour.ToArray.Reverse
                    If Not _PersonCompressorShadow.PartsWorkedHour.Any(Function(x) x.Equals(PersonCompressorPart)) Then
                        _PersonCompressor.PartsWorkedHour.Remove(PersonCompressorPart)
                    End If
                Next PersonCompressorPart
                For Each ShadowPersonCompressorPart As PersonCompressorPart In _PersonCompressorShadow.PartsWorkedHour
                    If Not _PersonCompressor.PartsWorkedHour.Any(Function(x) x.Equals(ShadowPersonCompressorPart)) Then
                        _PersonCompressor.PartsWorkedHour.Add(ShadowPersonCompressorPart)
                    End If
                Next ShadowPersonCompressorPart
                For Each PersonCompressorPart As PersonCompressorPart In _PersonCompressor.PartsElapsedDay.ToArray.Reverse
                    If Not _PersonCompressorShadow.PartsElapsedDay.Any(Function(x) x.Equals(PersonCompressorPart)) Then
                        _PersonCompressor.PartsElapsedDay.Remove(PersonCompressorPart)
                    End If
                Next PersonCompressorPart
                For Each ShadowPersonCompressorPart As PersonCompressorPart In _PersonCompressorShadow.PartsElapsedDay
                    If Not _PersonCompressor.PartsElapsedDay.Any(Function(x) x.Equals(ShadowPersonCompressorPart)) Then
                        _PersonCompressor.PartsElapsedDay.Add(ShadowPersonCompressorPart)
                    End If
                Next ShadowPersonCompressorPart
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
                    For Each PersonCompressorPart As PersonCompressorPart In _PersonCompressor.PartsWorkedHour.ToArray.Reverse
                        If Not _PersonCompressorShadow.PartsWorkedHour.Any(Function(x) x.Equals(PersonCompressorPart)) Then
                            _PersonCompressor.PartsWorkedHour.Remove(PersonCompressorPart)
                        End If
                    Next PersonCompressorPart
                    For Each ShadowPersonCompressorPart As PersonCompressorPart In _PersonCompressorShadow.PartsWorkedHour
                        If Not _PersonCompressor.PartsWorkedHour.Any(Function(x) x.Equals(ShadowPersonCompressorPart)) Then
                            _PersonCompressor.PartsWorkedHour.Add(ShadowPersonCompressorPart)
                        End If
                    Next ShadowPersonCompressorPart
                    For Each PersonCompressorPart As PersonCompressorPart In _PersonCompressor.PartsElapsedDay.ToArray.Reverse
                        If Not _PersonCompressorShadow.PartsElapsedDay.Any(Function(x) x.Equals(PersonCompressorPart)) Then
                            _PersonCompressor.PartsElapsedDay.Remove(PersonCompressorPart)
                        End If
                    Next PersonCompressorPart
                    For Each ShadowPersonCompressorPart As PersonCompressorPart In _PersonCompressorShadow.PartsElapsedDay
                        If Not _PersonCompressor.PartsElapsedDay.Any(Function(x) x.Equals(ShadowPersonCompressorPart)) Then
                            _PersonCompressor.PartsElapsedDay.Add(ShadowPersonCompressorPart)
                        End If
                    Next ShadowPersonCompressorPart
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
                    For Each PersonCompressorPart As PersonCompressorPart In _PersonCompressor.PartsWorkedHour.ToArray.Reverse
                        If Not _PersonCompressorShadow.PartsWorkedHour.Any(Function(x) x.Equals(PersonCompressorPart)) Then
                            _PersonCompressor.PartsWorkedHour.Remove(PersonCompressorPart)
                        End If
                    Next PersonCompressorPart
                    For Each ShadowPersonCompressorPart As PersonCompressorPart In _PersonCompressorShadow.PartsWorkedHour
                        If Not _PersonCompressor.PartsWorkedHour.Any(Function(x) x.Equals(ShadowPersonCompressorPart)) Then
                            _PersonCompressor.PartsWorkedHour.Add(ShadowPersonCompressorPart)
                        End If
                    Next ShadowPersonCompressorPart
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
        TcMaintenance.SelectedTab = TabPartWorkedHour
        LblOrderValue.Text = If(_PersonCompressor.IsSaved, _PersonForm.DgvCompressor.SelectedRows(0).Cells("Order").Value, 0)
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_PersonCompressor.Status)
        LblCreationValue.Text = _PersonCompressor.Creation
        QbxCompressor.Unfreeze()
        QbxCompressor.Freeze(_PersonCompressor.Compressor.ID)
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
        DgvPartWorkedHour.Fill(_PersonCompressor.PartsWorkedHour)
        DgvPartElapsedDay.Fill(_PersonCompressor.PartsElapsedDay)
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
        ElseIf _PersonCompressor.PartsWorkedHour.Any(Function(x) x.Capacity = 0) Then
            TcPersonCompressor.SelectedTab = TabMaintenance
            TcMaintenance.SelectedTab = TabPartWorkedHour
            EprValidation.SetError(TsPartWorkedHour, "Informe a capacidade de todos os itens controlados por hora trabalhada.")
            EprValidation.SetIconAlignment(TsPartWorkedHour, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsPartWorkedHour, -90)
            DgvPartWorkedHour.Select()
            Return False
        ElseIf _PersonCompressor.PartsElapsedDay.Any(Function(x) x.Capacity = 0) Then
            TcPersonCompressor.SelectedTab = TabMaintenance
            TcMaintenance.SelectedTab = TabPartElapsedDay
            EprValidation.SetError(TsPartElapsedDay, "Informe a capacidade de todos os itens controlados por dias corridos.")
            EprValidation.SetIconAlignment(TsPartElapsedDay, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsPartElapsedDay, -90)
            DgvPartElapsedDay.Select()
            Return False
        ElseIf Not _PersonCompressor.PartsWorkedHour.Any(Function(x) x.PartBind = CompressorPartBindType.AirFilter) Then
            TcPersonCompressor.SelectedTab = TabMaintenance
            TcMaintenance.SelectedTab = TabPartWorkedHour
            EprValidation.SetError(TsPartWorkedHour, "Pelo menos um item precisa estar vinculado com filtro de ar.")
            EprValidation.SetIconAlignment(TsPartWorkedHour, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsPartWorkedHour, -90)
            DgvPartWorkedHour.Select()
            Return False
        ElseIf Not _PersonCompressor.PartsWorkedHour.Any(Function(x) x.PartBind = CompressorPartBindType.OilFilter) Then
            TcPersonCompressor.SelectedTab = TabMaintenance
            TcMaintenance.SelectedTab = TabPartWorkedHour
            EprValidation.SetError(TsPartWorkedHour, "Pelo menos um item precisa estar vinculado com filtro de óleo.")
            EprValidation.SetIconAlignment(TsPartWorkedHour, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsPartWorkedHour, -90)
            DgvPartWorkedHour.Select()
        ElseIf Not _PersonCompressor.PartsWorkedHour.Any(Function(x) x.PartBind = CompressorPartBindType.Separator) Then
            TcPersonCompressor.SelectedTab = TabMaintenance
            TcMaintenance.SelectedTab = TabPartWorkedHour
            EprValidation.SetError(TsPartWorkedHour, "Pelo menos um item precisa estar vinculado com separador.")
            EprValidation.SetIconAlignment(TsPartWorkedHour, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsPartWorkedHour, -90)
            DgvPartWorkedHour.Select()
        ElseIf Not _PersonCompressor.PartsWorkedHour.Any(Function(x) x.PartBind = CompressorPartBindType.Oil) Then
            TcPersonCompressor.SelectedTab = TabMaintenance
            TcMaintenance.SelectedTab = TabPartWorkedHour
            EprValidation.SetError(TsPartWorkedHour, "Pelo menos um item precisa estar vinculado com óleo")
            EprValidation.SetIconAlignment(TsPartWorkedHour, ErrorIconAlignment.MiddleLeft)
            EprValidation.SetIconPadding(TsPartWorkedHour, -90)
            DgvPartWorkedHour.Select()
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
                _Person.Compressors.Single(Function(x) x.Guid = _PersonCompressor.Guid).Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _Person.Compressors.Single(Function(x) x.Guid = _PersonCompressor.Guid).Compressor = New Compressor().Load(QbxCompressor.FreezedPrimaryKey, False)
                _Person.Compressors.Single(Function(x) x.Guid = _PersonCompressor.Guid).SerialNumber = TxtSerialNumber.Text
                _Person.Compressors.Single(Function(x) x.Guid = _PersonCompressor.Guid).Patrimony = TxtPatrimony.Text
                _Person.Compressors.Single(Function(x) x.Guid = _PersonCompressor.Guid).Sector = TxtSector.Text
                _Person.Compressors.Single(Function(x) x.Guid = _PersonCompressor.Guid).UnitCapacity = DbxUnitCapacity.Text
                _Person.Compressors.Single(Function(x) x.Guid = _PersonCompressor.Guid).Note = TxtNote.Text
            Else
                _PersonCompressor.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _PersonCompressor.Compressor = New Compressor().Load(QbxCompressor.FreezedPrimaryKey, False)
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
    Private Sub BtnIncludeCompressorPartWorkedHour_Click(sender As Object, e As EventArgs) Handles BtnIncludeCompressorPartWorkedHour.Click
        Dim Form As New FrmPersonCompressorPartWorkedHour(_PersonCompressor, New PersonCompressorPart(CompressorPartType.WorkedHour), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditCompressorPartWorkedHour_Click(sender As Object, e As EventArgs) Handles BtnEditCompressorPartWorkedHour.Click
        Dim Form As FrmPersonCompressorPartWorkedHour
        Dim PersonCompressorPartWorkedHour As PersonCompressorPart
        If DgvPartWorkedHour.SelectedRows.Count = 1 Then
            PersonCompressorPartWorkedHour = _PersonCompressor.PartsWorkedHour.Single(Function(X) X.Guid = DgvPartWorkedHour.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmPersonCompressorPartWorkedHour(_PersonCompressor, PersonCompressorPartWorkedHour, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeleteCompressorPartWorkedHour_Click(sender As Object, e As EventArgs) Handles BtnDeleteCompressorPartWorkedHour.Click
        Dim PartWorkedHour As PersonCompressorPart
        If DgvPartWorkedHour.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                PartWorkedHour = _PersonCompressor.PartsWorkedHour.Single(Function(X) X.Guid = DgvPartWorkedHour.SelectedRows(0).Cells("Guid").Value)
                _PersonCompressor.PartsWorkedHour.Remove(PartWorkedHour)
                DgvPartWorkedHour.Fill(_PersonCompressor.PartsWorkedHour)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnIncludePartElapsedDay_Click(sender As Object, e As EventArgs) Handles BtnIncludePartElapsedDay.Click
        Dim Form As New FrmPersonCompressorPartElapsedDay(_PersonCompressor, New PersonCompressorPart(CompressorPartType.ElapsedDay), Me)
        Form.ShowDialog()
    End Sub
    Private Sub BtnEditPartElapsedDay_Click(sender As Object, e As EventArgs) Handles BtnEditPartElapsedDay.Click
        Dim Form As FrmPersonCompressorPartElapsedDay
        Dim PartElapsedDay As PersonCompressorPart
        If DgvPartElapsedDay.SelectedRows.Count = 1 Then
            PartElapsedDay = _PersonCompressor.PartsElapsedDay.Single(Function(X) X.Guid = DgvPartElapsedDay.SelectedRows(0).Cells("Guid").Value)
            Form = New FrmPersonCompressorPartElapsedDay(_PersonCompressor, PartElapsedDay, Me)
            Form.ShowDialog()
        End If
    End Sub
    Private Sub BtnDeletePartElapsedDay_Click(sender As Object, e As EventArgs) Handles BtnDeletePartElapsedDay.Click
        Dim PartElapsedDay As PersonCompressorPart
        If DgvPartElapsedDay.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                PartElapsedDay = _PersonCompressor.PartsElapsedDay.Single(Function(X) X.Guid = DgvPartElapsedDay.SelectedRows(0).Cells("Guid").Value)
                _PersonCompressor.PartsElapsedDay.Remove(PartElapsedDay)
                DgvPartElapsedDay.Fill(_PersonCompressor.PartsElapsedDay)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvPart_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvPartWorkedHour.CellFormatting, DgvPartElapsedDay.CellFormatting
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
    Private Sub DgvPartWorkedHour_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvPartWorkedHour.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvPartWorkedHour.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditCompressorPartWorkedHour.PerformClick()
        End If
    End Sub
    Private Sub DgvPartElapsedDay_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvPartElapsedDay.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvPartElapsedDay.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditPartElapsedDay.PerformClick()
        End If
    End Sub
    Private Sub TxtFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilterPartWorkedHour.KeyPress, TxtFilterPartElapsedDay.KeyPress
        Dim LstChar As New List(Of Char) From {" ", ".", ",", "-", "/", "(", ")", "+", "*", "%", "&", "@", "#", "$", "<", ">", "\"}
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not LstChar.Contains(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtFilterPartWorkedHour_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterPartWorkedHour.TextChanged
        FilterPartWorkedHour()
    End Sub
    Private Sub FilterPartWorkedHour()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1} OR {2}",
                                                 "ItemNameOrProduct LIKE '%@VALUE%'",
                                                 "Code LIKE '%@VALUE%'",
                                                 "Convert([Product], 'System.String') LIKE '%@VALUE%'"
                                            )
        If DgvPartWorkedHour.DataSource IsNot Nothing Then
            Table = DgvPartWorkedHour.DataSource
            View = Table.DefaultView
            If TxtFilterPartWorkedHour.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterPartWorkedHour.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub TxtFilterPartElapsedDay_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterPartElapsedDay.TextChanged
        FilterPartElapsedDay()
    End Sub
    Private Sub FilterPartElapsedDay()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1} OR {2}",
                                                 "ItemNameOrProduct LIKE '%@VALUE%'",
                                                 "Code LIKE '%@VALUE%'",
                                                 "Convert([Product], 'System.String') LIKE '%@VALUE%'"
                                            )
        If DgvPartElapsedDay.DataSource IsNot Nothing Then
            Table = DgvPartElapsedDay.DataSource
            View = Table.DefaultView
            If TxtFilterPartElapsedDay.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterPartElapsedDay.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub DgvPartWorkedHour_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPartWorkedHour.SelectionChanged
        If DgvPartWorkedHour.SelectedRows.Count = 0 Then
            BtnEditCompressorPartWorkedHour.Enabled = False
            BtnDeleteCompressorPartWorkedHour.Enabled = False
        Else
            BtnEditCompressorPartWorkedHour.Enabled = True
            BtnDeleteCompressorPartWorkedHour.Enabled = True
        End If
    End Sub
    Private Sub DgvPartElapsedDay_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPartElapsedDay.SelectionChanged
        If DgvPartElapsedDay.SelectedRows.Count = 0 Then
            BtnEditPartElapsedDay.Enabled = False
            BtnDeletePartElapsedDay.Enabled = False
        Else
            BtnEditPartElapsedDay.Enabled = True
            BtnDeletePartElapsedDay.Enabled = True
        End If
    End Sub
    Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
        Dim Form As FrmPersonCompressorImport
        Cursor = Cursors.WaitCursor
        Form = New FrmPersonCompressorImport(New Compressor().Load(QbxCompressor.FreezedPrimaryKey, False), _PersonCompressor)
        If Form.ShowDialog() = DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            For Each Row As DataGridViewRow In Form.DgvPartWorkedHour.Rows
                If Row.Cells("X").Value = True Then
                    _PersonCompressor.PartsWorkedHour.Add(New PersonCompressorPart(CompressorPartType.WorkedHour) With {.Status = SimpleStatus.Active, .ItemName = Row.Cells("ItemName").Value, .Product = New Lazy(Of Product)(Function() Row.Cells("Product").Value), .Quantity = Row.Cells("Quantity").Value})
                    _PersonCompressor.PartsWorkedHour.Last.SetIsSaved(True)
                    BtnSave.Enabled = True
                End If
            Next Row
            For Each Row As DataGridViewRow In Form.DgvPartElapsedDay.Rows
                If Row.Cells("X").Value = True Then
                    _PersonCompressor.PartsElapsedDay.Add(New PersonCompressorPart(CompressorPartType.ElapsedDay) With {.Status = SimpleStatus.Active, .ItemName = Row.Cells("ItemName").Value, .Product = New Lazy(Of Product)(Function() Row.Cells("Product").Value), .Quantity = Row.Cells("Quantity").Value})
                    _PersonCompressor.PartsElapsedDay.Last.SetIsSaved(True)
                    BtnSave.Enabled = True
                End If
            Next Row
        End If
        DgvPartWorkedHour.Fill(_PersonCompressor.PartsWorkedHour)
        DgvPartElapsedDay.Fill(_PersonCompressor.PartsElapsedDay)
        EprValidation.Clear()
        Cursor = Cursors.Default
    End Sub
    Private Sub TxtFilterPartWorkedHour_Enter(sender As Object, e As EventArgs) Handles TxtFilterPartWorkedHour.Enter
        EprInformation.SetError(TsPartWorkedHour, "Filtrando os campos: Código e Item.")
        EprInformation.SetIconAlignment(TsPartWorkedHour, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsPartWorkedHour, -365)
    End Sub
    Private Sub TxtFilterPartWorkedHour_Leave(sender As Object, e As EventArgs) Handles TxtFilterPartWorkedHour.Leave
        EprInformation.Clear()
    End Sub
    Private Sub TxtFilterPartElapsedDay_Enter(sender As Object, e As EventArgs) Handles TxtFilterPartElapsedDay.Enter
        EprInformation.SetError(TsPartElapsedDay, "Filtrando os campos: Código e Item.")
        EprInformation.SetIconAlignment(TsPartElapsedDay, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsPartElapsedDay, -365)
    End Sub
    Private Sub TxtFilterPartElapsedDay_Leave(sender As Object, e As EventArgs) Handles TxtFilterPartElapsedDay.Leave
        EprInformation.Clear()
    End Sub
    Private Sub DgvPartWorkedHour_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvPartWorkedHour.DataSourceChanged
        FilterPartWorkedHour()
    End Sub
    Private Sub DgvPartElapsedDay_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvPartElapsedDay.DataSourceChanged
        FilterPartElapsedDay()
    End Sub
End Class