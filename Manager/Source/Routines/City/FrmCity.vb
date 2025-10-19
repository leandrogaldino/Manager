Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient
Public Class FrmCity
    Private _City As City
    Private _GridControl As UcCityGrid
    Private _CitiesGrid As DataGridView
    Private _Filter As CityFilter
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
    Public Sub New(City As City, GridControl As UcCityGrid)
        InitializeComponent()
        _City = City
        _GridControl = GridControl
        _CitiesGrid = _GridControl.DgvData
        _Filter = CType(_GridControl.PgFilter.SelectedObject, CityFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadData()
        LoadForm()
    End Sub
    Public Sub New(City As City)
        InitializeComponent()
        _City = City
        _User = Locator.GetInstance(Of Session).User
        Height -= TsNavigation.Height
        LblName.Top -= TsNavigation.Height
        TxtName.Top -= TsNavigation.Height
        LblBIGSCode.Top -= TsNavigation.Height
        TxtBIGSCode.Top -= TsNavigation.Height
        LblState.Top -= TsNavigation.Height
        CbxStateName.Top -= TsNavigation.Height
        LblUF.Top -= TsNavigation.Height
        CbxStateShortName.Top -= TsNavigation.Height
        LblRoute.Top -= TsNavigation.Height
        PnRoute.Top -= TsNavigation.Height
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        LoadData()
        LoadForm()
    End Sub
    Private Sub LoadForm()
        DgvNavigator.DataGridView = _CitiesGrid
        ControlHelper.EnableControlDoubleBuffer(DgvRoute, True)
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _City.ID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_City.Status)
        LblCreationValue.Text = _City.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _City.Name
        TxtBIGSCode.Text = _City.BIGSCode
        CbxStateName.Text = _City.State.Name
        CbxStateShortName.Text = _City.State.ShortName
        DgvRoute.Fill(_City.Routes)
        Text = "Cidade"
        BtnDelete.Enabled = _City.ID > 0 And _User.CanDelete(Routine.City)
        If _City.LockInfo.IsLocked And Not _City.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _City.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _City.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Text &= " - SOMENTE LEITURA"
        End If
        BtnSave.Enabled = False
        TxtName.Select()
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
            _City.Load(_CitiesGrid.SelectedRows(0).Cells("id").Value, True)
            LoadData()
        Catch ex As Exception
            CMessageBox.Show("ERRO CT004", "Ocorreu um erro ao carregar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
        Finally
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Locator.GetInstance(Of Session).AutoCloseApp Then
            If Not _Deleting AndAlso BtnSave.Enabled Then
                If BtnSave.Enabled Then
                    If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                        If Not Save() Then e.Cancel = True
                    End If
                End If
            End If
            If _GridControl IsNot Nothing Then
                DgvRoute.Fill(_City.Routes)
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
        _City = New City
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _City.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _City.LockInfo.IsLocked Or (_City.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _City.LockInfo.SessionToken) Then
                        _City.Delete()
                        If _CitiesGrid IsNot Nothing Then
                            _Filter.Filter()
                            _GridControl.DgvCitiesLayout.Load()
                            _CitiesGrid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _City.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
                    End If
                End If
            Catch ex As MySqlException
                If ex.Number = MysqlError.ForeignKey Then
                    CMessageBox.Show("Esse registro não pode ser excluído pois já foi referenciado em outras rotinas.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                Else
                    CMessageBox.Show("ERRO CT005", "Ocorreu um erro ao excluir o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                End If
            Finally
                Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Using Form As New FrmLog(Routine.City, _City.ID)
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
    Private Sub Txt_TextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged, TxtBIGSCode.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub CbxStateShortName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxStateShortName.SelectedIndexChanged

        CbxStateName.SelectedIndex = CbxStateShortName.SelectedIndex
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub CbxStateName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CbxStateName.SelectedIndexChanged
        CbxStateShortName.SelectedIndex = CbxStateName.SelectedIndex
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
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
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Save()
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtName.Text) Then
            EprValidation.SetError(LblName, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblName, ErrorIconAlignment.MiddleRight)
            TxtName.Select()
            Return False
        ElseIf CbxStateName.SelectedIndex = -1 Then
            EprValidation.SetError(LblState, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblState, ErrorIconAlignment.MiddleRight)
            CbxStateName.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        TxtName.Text = TxtName.Text.Trim.ToUnaccented()
        If _City.LockInfo.IsLocked And _City.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _City.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                _City.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _City.Name = TxtName.Text
                _City.BIGSCode = TxtBIGSCode.Text
                _City.State = New State().Load(CbxStateName.SelectedIndex + 1)
                Try
                    Cursor = Cursors.WaitCursor
                    _City.SaveChanges()
                    _City.Lock()
                    LblIDValue.Text = _City.ID
                    DgvRoute.Fill(_City.Routes)
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.City)
                    If _GridControl IsNot Nothing Then
                        _Filter.Filter()
                        _GridControl.DgvCitiesLayout.Load()
                        Row = _CitiesGrid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe uma cidade cadastrada com esse nome.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
                    Else
                        CMessageBox.Show("ERRO CT006", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    End If
                    Return False
                Catch ex As Exception
                    CMessageBox.Show("ERRO CT007", "Ocorreu um erro salvar o registro.", CMessageBoxType.Error, CMessageBoxButtons.OK, ex)
                    Return False
                Finally
                    Cursor = Cursors.Default
                End Try
            Else
                Return False
            End If
        End If
    End Function
    Private Sub BtnIncludeRoute_Click(sender As Object, e As EventArgs) Handles BtnIncludeRoute.Click
        Using Form As New FrmCityRoute(_City, New CityRoute(), Me)
            Form.ShowDialog()
        End Using
    End Sub
    Private Sub BtnEditRoute_Click(sender As Object, e As EventArgs) Handles BtnEditRoute.Click
        Dim Route As CityRoute
        If DgvRoute.SelectedRows.Count = 1 Then
            Route = _City.Routes.Single(Function(x) x.Guid = DgvRoute.SelectedRows(0).Cells("Guid").Value)
            Using Form As New FrmCityRoute(_City, Route, Me)
                Form.ShowDialog()
            End Using
        End If
    End Sub
    Private Sub BtnDeleteRoute_Click(sender As Object, e As EventArgs) Handles BtnDeleteRoute.Click
        Dim Route As CityRoute
        If DgvRoute.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                Route = _City.Routes.Single(Function(x) x.Guid = DgvRoute.SelectedRows(0).Cells("Guid").Value)
                _City.Routes.Remove(Route)
                DgvRoute.Fill(_City.Routes)
                BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub DgvRoute_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles DgvRoute.MouseDoubleClick
        Dim ClickPlace As DataGridView.HitTestInfo = DgvRoute.HitTest(e.X, e.Y)
        If ClickPlace.Type = DataGridViewHitTestType.Cell Then
            BtnEditRoute.PerformClick()
        End If
    End Sub
    Private Sub TxtFilter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtFilterRoute.KeyPress

        Dim LstChar As New List(Of Char) From {" ", ".", ",", "-", "/", "(", ")", "+", "*", "%", "&", "@", "#", "$", "<", ">", "\"}
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsNumber(e.KeyChar) And Not LstChar.Contains(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Sub TxtFilterRoute_TextChanged(sender As Object, e As EventArgs) Handles TxtFilterRoute.TextChanged
        FilterRoute()
    End Sub
    Private Sub FilterRoute()
        Dim Table As DataTable
        Dim View As DataView
        Dim Filter As String = "Convert([Route], 'System.String') LIKE '%@VALUE%'"
        If DgvRoute.DataSource IsNot Nothing Then
            Table = DgvRoute.DataSource
            View = Table.DefaultView
            If TxtFilterRoute.Text <> Nothing Then
                Filter = Filter.Replace("@VALUE", TxtFilterRoute.Text.Replace("%", Nothing).Replace("*", Nothing))
                View.RowFilter = Filter
            Else
                View.RowFilter = Nothing
            End If
        End If
    End Sub
    Private Sub DgvRoute_SelectionChanged(sender As Object, e As EventArgs) Handles DgvRoute.SelectionChanged
        If DgvRoute.SelectedRows.Count = 0 Then
            BtnEditRoute.Enabled = False
            BtnDeleteRoute.Enabled = False
        Else
            BtnEditRoute.Enabled = True
            BtnDeleteRoute.Enabled = True
        End If
    End Sub
    Private Sub TxtFilterRoute_Enter(sender As Object, e As EventArgs) Handles TxtFilterRoute.Enter
        EprInformation.SetError(TsRoute, "Filtrando os campos: Rota.")
        EprInformation.SetIconAlignment(TsRoute, ErrorIconAlignment.MiddleLeft)
        EprInformation.SetIconPadding(TsRoute, -365)
    End Sub
    Private Sub TxtFilterRoute_Leave(sender As Object, e As EventArgs) Handles TxtFilterRoute.Leave
        EprInformation.Clear()
    End Sub
    Private Sub DgvRoute_DataSourceChanged(sender As Object, e As EventArgs) Handles DgvRoute.DataSourceChanged
        FilterRoute()
    End Sub
    Private Sub FrmCity_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _City.Unlock()
    End Sub

    Private Sub FrmCity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvlRouteLayout.Load()
    End Sub
End Class