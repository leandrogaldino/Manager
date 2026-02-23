Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient

Public Class FrmCompressor
    Private _Compressor As Compressor
    Private _GridControl As UcCompressorGrid
    Private _CompressorsGrid As DataGridView
    Private _Filter As CompressorFilter
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
    <DebuggerStepThrough>
    Protected Overrides Sub OnResize(e As EventArgs)
        Const _MouseButtonUp As Long = &HA0
        DefWndProc(New Message With {.Msg = _MouseButtonUp})
        MyBase.OnResize(e)
    End Sub
    Public Sub New(Compressor As Compressor, GridControl As UcCompressorGrid)
        InitializeComponent()
        _Compressor = Compressor
        _GridControl = GridControl
        _CompressorsGrid = _GridControl.DgvData
        _Filter = CType(_GridControl.PgFilter.SelectedObject, CompressorFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(Compressor As Compressor)
        InitializeComponent()
        _Compressor = Compressor
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        TcCompressor.Top -= TsNavigation.Height
        Height -= TsNavigation.Height
        _User = Locator.GetInstance(Of Session).User
        LoadData()
        LoadForm()
    End Sub
    Private Sub FrmCompressor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvlCompressorWorkedHourSellable.Load()
        DgvlCompressorElapsedDaySellable.Load()
    End Sub
    Private Sub LoadForm()
        ControlHelper.EnableControlDoubleBuffer(DgvCompressorWorkedHourSellable, True)
        ControlHelper.EnableControlDoubleBuffer(DgvCompressorElapsedDaySellable, True)
        DgvNavigator.DataGridView = _CompressorsGrid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _Compressor.ID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_Compressor.Status)
        LblCreationValue.Text = _Compressor.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _Compressor.Name
        QbxManufacturer.Unfreeze()
        QbxManufacturer.Freeze(_Compressor.Manufacturer.Value.ID)
        TxtFilterWorkedHourSellable.Clear()
        If _Compressor.WorkedHourSellables IsNot Nothing Then DgvCompressorWorkedHourSellable.Fill(_Compressor.WorkedHourSellables)
        TxtFilterWorkedHourSellable.Clear()
        If _Compressor.ElapsedDaySellables IsNot Nothing Then DgvCompressorElapsedDaySellable.Fill(_Compressor.ElapsedDaySellables)
        BtnDelete.Enabled = _Compressor.ID > 0 And _User.CanDelete(Routine.Compressor)
        Text = "Compressor"
        If _Compressor.LockInfo.IsLocked And Not _Compressor.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _Compressor.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _Compressor.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        TxtName.Select()
        _Loading = False
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then DgvNavigator.CancelNextMove = True
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        Try
            Cursor = Cursors.WaitCursor
            _Compressor.Load(_CompressorsGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO CP001", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If Not _Deleting AndAlso BtnSave.Enabled Then
            If BtnSave.Enabled Then
                If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not Save() Then e.Cancel = True
                End If
            End If
        End If
        If _GridControl IsNot Nothing Then
            DgvCompressorWorkedHourSellable.Fill(_Compressor.WorkedHourSellables)
            DgvCompressorElapsedDaySellable.Fill(_Compressor.ElapsedDaySellables)
        End If
        _Deleting = False
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then Exit Sub
            End If
        End If
        _Compressor = New Compressor
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _Compressor.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _Compressor.LockInfo.IsLocked Or (_Compressor.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _Compressor.LockInfo.SessionToken) Then
                        _Compressor.Delete()
                        If _CompressorsGrid IsNot Nothing Then
                            _Filter.Filter()
                            _GridControl.DgvlCompressor.Load()
                            _CompressorsGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _Compressor.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO CP002", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Using Form As New FrmLog(Routine.Compressor, _Compressor.ID)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BtnStatusValue_Click(sender As Object, e As EventArgs) Handles BtnStatusValue.Click
        If BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive)
        ElseIf BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Inactive) Then
            BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active)
        End If
        BtnSave.Enabled = True
    End Sub
    Private Sub BtnStatusValue_TextChanged(sender As Object, e As EventArgs) Handles BtnStatusValue.TextChanged
        EprValidation.Clear()
        BtnStatusValue.ForeColor = If(BtnStatusValue.Text = EnumHelper.GetEnumDescription(SimpleStatus.Active), Color.DarkBlue, Color.DarkRed)
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged, QbxManufacturer.TextChanged
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
        If String.IsNullOrWhiteSpace(TxtName.Text) Then
            EprValidation.SetError(LblName, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
            TcCompressor.SelectedTab = TabMain
            TxtName.Select()
            Return False
        ElseIf Not String.IsNullOrWhiteSpace(QbxManufacturer.Text) And Not QbxManufacturer.IsFreezed Then
            EprValidation.SetError(LblManufacturer, "Fabricante não encontrado.")
            EprValidation.SetIconAlignment(LblManufacturer, ErrorIconAlignment.MiddleRight)
            TcCompressor.SelectedTab = TabMain
            QbxManufacturer.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        TxtName.Text = TxtName.Text.Trim.ToUnaccented()
        If _Compressor.LockInfo.IsLocked And _Compressor.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _Compressor.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                _Compressor.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _Compressor.Name = TxtName.Text
                _Compressor.ManufacturerID = QbxManufacturer.FreezedPrimaryKey
                _Compressor.ManufacturerName = QbxManufacturer.Text
                _Compressor.Manufacturer = New Lazy(Of Person)(Function() New Person().Load(QbxManufacturer.FreezedPrimaryKey, False))
                Try
                    Cursor = Cursors.WaitCursor
                    _Compressor.SaveChanges()
                    _Compressor.Lock()
                    LblIDValue.Text = _Compressor.ID
                    DgvCompressorWorkedHourSellable.Fill(_Compressor.WorkedHourSellables)
                    DgvCompressorElapsedDaySellable.Fill(_Compressor.ElapsedDaySellables)
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.Compressor)
                    If _GridControl IsNot Nothing Then
                        _Filter.Filter()
                        _GridControl.DgvlCompressor.Load()
                        Row = _CompressorsGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe um compressor cadastrado com esse nome.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                        TcCompressor.SelectedTab = TabMain
                    Else
                        CMessageBox.Show("ERRO CP003", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    End If
                    Return False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Return False
            End If
        End If
    End Function
    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnView.Visible = False
        BtnNew.Visible = False
        BtnFilter.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub QbxManufacturer_Enter(sender As Object, e As EventArgs) Handles QbxManufacturer.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxManufacturer.IsFreezed And _User.CanWrite(Routine.Person)
        BtnNew.Visible = _User.CanWrite(Routine.Person)
        BtnFilter.Visible = _User.CanAccess(Routine.Person)
    End Sub
    Private Sub QbxManufacturer_Leave(sender As Object, e As EventArgs) Handles QbxManufacturer.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxManufacturer_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxManufacturer.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnView.Visible = QbxManufacturer.IsFreezed And _User.CanWrite(Routine.Person)
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Manufacturer As Person
        Manufacturer = New Person With {.IsProvider = True}
        Using Form As New FrmPerson(Manufacturer)
            Form.CbxIsProvider.Enabled = False
            Form.ShowDialog()
        End Using
        EprValidation.Clear()
        If Manufacturer.ID > 0 Then
            QbxManufacturer.Freeze(Manufacturer.ID)
        End If
        QbxManufacturer.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Using Form As New FrmPerson(New Person().Load(QbxManufacturer.FreezedPrimaryKey, True))
            Form.CbxIsProvider.Enabled = False
            Form.ShowDialog()
        End Using
        QbxManufacturer.Freeze(QbxManufacturer.FreezedPrimaryKey)
        QbxManufacturer.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Using Form As New FrmFilter(New PersonProviderQueriedBoxFilter(), QbxManufacturer) With {.Text = "Filtro de Fornecedores"}
            Form.ShowDialog()
        End Using
        QbxManufacturer.Select()
    End Sub
    Private Sub TcCompressor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcCompressor.SelectedIndexChanged
        If TcCompressor.SelectedTab Is TabMain Then
            Size = New Size(370, 270)
            FormBorderStyle = FormBorderStyle.FixedSingle
            WindowState = FormWindowState.Normal
            MaximizeBox = False
        Else
            FormBorderStyle = FormBorderStyle.Sizable
            WindowState = FormWindowState.Maximized
            MaximizeBox = True
        End If
    End Sub
    Private Sub BtnIncludeWorkedHourSellable_Click(sender As Object, e As EventArgs) Handles BtnIncludeWorkedHourSellable.Click
        Using Form As New FrmCompressorSellableWorkedHour(_Compressor, New CompressorSellable(CompressorSellableControlType.WorkedHour), Me)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BtnEditWorkedHourSellable_Click(sender As Object, e As EventArgs) Handles BtnEditWorkedHourSellable.Click
        Dim WorkedHourSellable As CompressorSellable
        If DgvCompressorWorkedHourSellable.SelectedRows.Count = 1 Then
            WorkedHourSellable = _Compressor.WorkedHourSellables.Single(Function(x) x.Guid = DgvCompressorWorkedHourSellable.SelectedRows(0).Cells("Guid").Value)
            Using Form As New FrmCompressorSellableWorkedHour(_Compressor, WorkedHourSellable, Me)
                Form.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub BtnDeleteWorkedHourSellable_Click(sender As Object, e As EventArgs) Handles BtnDeleteWorkedHourSellable.Click
        Dim WorkedHourSellable As CompressorSellable
        If DgvCompressorWorkedHourSellable.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                WorkedHourSellable = _Compressor.WorkedHourSellables.Single(Function(x) x.Guid = DgvCompressorWorkedHourSellable.SelectedRows(0).Cells("Guid").Value)
                _Compressor.WorkedHourSellables.Remove(WorkedHourSellable)
                DgvCompressorWorkedHourSellable.Fill(_Compressor.WorkedHourSellables)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvCompressorSellableWorkedHour_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvCompressorWorkedHourSellable.CellFormatting
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
        End If
    End Sub
    Private Sub DgvCompressorSellableWorkedHour_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvCompressorWorkedHourSellable.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvCompressorWorkedHourSellable.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditWorkedHourSellable.PerformClick()
        End If
    End Sub
    Private Sub TxtFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilterWorkedHourSellable.KeyPress,
                                                                                     TxtFilterElapsedDaySellable.KeyPress
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
        Dim Filter As String = String.Format("{0} OR {1}",
                                                 "Name LIKE '%@VALUE%'",
                                                 "Code LIKE '%@VALUE%'"
                                            )
        If DgvCompressorWorkedHourSellable.DataSource IsNot Nothing Then
            Table = DgvCompressorWorkedHourSellable.DataSource
            View = Table.DefaultView
            If TxtFilterWorkedHourSellable.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterWorkedHourSellable.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub DgvCompressorSellableWorkedHour_SelectionChanged(sender As Object, e As EventArgs) Handles DgvCompressorWorkedHourSellable.SelectionChanged
        If DgvCompressorWorkedHourSellable.SelectedRows.Count = 0 Then
            BtnEditWorkedHourSellable.Enabled = False
            BtnDeleteWorkedHourSellable.Enabled = False
        Else
            BtnEditWorkedHourSellable.Enabled = True
            BtnDeleteWorkedHourSellable.Enabled = True
        End If
    End Sub
    Private Sub BtnIncludeElapsedDaySellable_Click(sender As Object, e As EventArgs) Handles BtnIncludeElapsedDaySellable.Click
        Using Form As New FrmCompressorSellableElapsedDay(_Compressor, New CompressorSellable(CompressorSellableControlType.ElapsedDay), Me)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BBtnEditElapsedDaySellable_Click(sender As Object, e As EventArgs) Handles BtnEditElapsedDaySellable.Click
        Dim ElapsedDaySellable As CompressorSellable
        If DgvCompressorElapsedDaySellable.SelectedRows.Count = 1 Then
            ElapsedDaySellable = _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = DgvCompressorElapsedDaySellable.SelectedRows(0).Cells("Guid").Value)
            Using Form As New FrmCompressorSellableElapsedDay(_Compressor, ElapsedDaySellable, Me)
                Form.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub BtnDeleteElapsedDaySellable_Click(sender As Object, e As EventArgs) Handles BtnDeleteElapsedDaySellable.Click
        Dim ElapsedDaySellable As CompressorSellable
        If DgvCompressorElapsedDaySellable.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                ElapsedDaySellable = _Compressor.ElapsedDaySellables.Single(Function(x) x.Guid = DgvCompressorElapsedDaySellable.SelectedRows(0).Cells("Guid").Value)
                _Compressor.ElapsedDaySellables.Remove(ElapsedDaySellable)
                DgvCompressorElapsedDaySellable.Fill(_Compressor.ElapsedDaySellables)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    <DebuggerStepThrough>
    Private Sub DgvCompressorSellableElapsedDay_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DgvCompressorElapsedDaySellable.CellFormatting
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
        End If
    End Sub
    Private Sub DgvCompressorSellableElapsedDay_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvCompressorElapsedDaySellable.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvCompressorElapsedDaySellable.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditElapsedDaySellable.PerformClick()
        End If
    End Sub
    Private Sub TxtFilterElapsedDaySellable_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterElapsedDaySellable.TextChanged
        FilterElapsedDaySellable()
    End Sub
    Private Sub FilterElapsedDaySellable()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = String.Format("{0} OR {1}",
                                                 "Name LIKE '%@VALUE%'",
                                                 "Code LIKE '%@VALUE%'"
                                            )
        If DgvCompressorElapsedDaySellable.DataSource IsNot Nothing Then
            Table = DgvCompressorElapsedDaySellable.DataSource
            View = Table.DefaultView
            If TxtFilterElapsedDaySellable.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterElapsedDaySellable.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub DgvCompressorSellableElapsedDay_SelectionChanged(sender As Object, e As EventArgs) Handles DgvCompressorElapsedDaySellable.SelectionChanged
        If DgvCompressorElapsedDaySellable.SelectedRows.Count = 0 Then
            BtnEditElapsedDaySellable.Enabled = False
            BtnDeleteElapsedDaySellable.Enabled = False
        Else
            BtnEditElapsedDaySellable.Enabled = True
            BtnDeleteElapsedDaySellable.Enabled = True
        End If
    End Sub
    Private Sub TxtFilterWorkedHourSellable_Enter(sender As Object, e As EventArgs) Handles TxtFilterWorkedHourSellable.Enter
        EprInformation.SetError(TsMaintenanceHour, "Filtrando os campos: Código e Produto/Serviço.")
        EprInformation.SetIconAlignment(TsMaintenanceHour, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsMaintenanceHour, -365)
    End Sub
    Private Sub TxtFilterWorkedHourSellableLeave(sender As Object, e As EventArgs) Handles TxtFilterWorkedHourSellable.Leave
        EprInformation.Clear()
    End Sub
    Private Sub TxtFilterElapsedDay_Enter(sender As Object, e As EventArgs) Handles TxtFilterElapsedDaySellable.Enter
        EprInformation.SetError(TsMaintenanceDay, "Filtrando os campos: Código e Produto/Serviço.")
        EprInformation.SetIconAlignment(TsMaintenanceDay, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsMaintenanceDay, -365)
    End Sub
    Private Sub TxtFilterElapsedDay_Leave(sender As Object, e As EventArgs) Handles TxtFilterElapsedDaySellable.Leave
        EprInformation.Clear()
    End Sub
    Private Sub FrmCompressor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _Compressor.Unlock()
    End Sub
    Private Sub DgvCompressorSellableWorkedHour_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvCompressorWorkedHourSellable.DataSourceChanged
        FilterWorkedHourSellable()
    End Sub
    Private Sub DgvCompressorSellableElapsedDay_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvCompressorElapsedDaySellable.DataSourceChanged
        FilterElapsedDaySellable()
    End Sub

    Private Sub TcMaintenance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TcMaintenance.SelectedIndexChanged
        If TcMaintenance.SelectedTab Is TabWorkedHourSellable Then
            DgvlCompressorWorkedHourSellable.Load()
        Else
            DgvlCompressorElapsedDaySellable.Load()
        End If
    End Sub
End Class