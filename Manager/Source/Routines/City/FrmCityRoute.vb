Imports ControlLibrary
Imports ControlLibrary.Extensions
Public Class FrmCityRoute
    Private _CityForm As FrmCity
    Private _City As City
    Private _CityRoute As CityRoute
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
    Public Sub New(City As City, CityRoute As CityRoute, CityForm As FrmCity)
        InitializeComponent()
        _City = City
        _CityRoute = CityRoute
        _CityForm = CityForm
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        DgvNavigator.DataGridView = _CityForm.DgvRoute
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub BeforeDataGridViewRowMove()
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then
                    DgvNavigator.CancelNextMove = True
                End If
            End If
        End If
    End Sub
    Private Sub AfterDataGridViewRowMove()
        If _CityForm.DgvRoute.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _CityRoute = _City.Routes.Single(Function(x) x.Guid = _CityForm.DgvRoute.SelectedRows(0).Cells("Guid").Value)
            LoadForm()
            Cursor = Cursors.Default
        End If
    End Sub
    Private Sub Form_Closing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not Locator.GetInstance(Of Session).AutoCloseApp Then
            If Not _Deleting AndAlso BtnSave.Enabled Then
                If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not PreSave() Then e.Cancel = True
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
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.CityRoute, _CityRoute.ID)
        Frm.ShowDialog()
    End Sub

    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles QbxRoute.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = If(_CityRoute.IsSaved, _CityForm.DgvRoute.SelectedRows(0).Cells("Order").Value, 0)
        LblCreationValue.Text = _CityRoute.Creation
        QbxRoute.Unfreeze()
        QbxRoute.Freeze(_CityRoute.Route.ID)
        If Not _CityRoute.IsSaved Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        QbxRoute.Select()
        _Loading = False
    End Sub
    Private Function IsValidFields() As Boolean
        If String.IsNullOrEmpty(QbxRoute.Text) Then
            EprValidation.SetError(LblRoute, "Campo Obrigatório.")
            EprValidation.SetIconAlignment(LblRoute, ErrorIconAlignment.MiddleRight)
            QbxRoute.Select()
            Return False
        ElseIf Not QbxRoute.IsFreezed Then
            EprValidation.SetError(LblRoute, "Rota não encontrada.")
            EprValidation.SetIconAlignment(LblRoute, ErrorIconAlignment.MiddleRight)
            QbxRoute.Select()
            Return False
        ElseIf _City.Routes.Any(Function(x) x.Route.ID = QbxRoute.FreezedPrimaryKey) Then
            EprValidation.SetError(LblRoute, "Essa rota já faz parte dessa cidade.")
            EprValidation.SetIconAlignment(LblRoute, ErrorIconAlignment.MiddleRight)
            QbxRoute.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        If IsValidFields() Then
            If _CityRoute.IsSaved Then
                _City.Routes.Single(Function(x) x.Guid = _CityRoute.Guid).Route = New Route().Load(QbxRoute.FreezedPrimaryKey, False)
            Else
                _CityRoute = New CityRoute With {
                    .Route = New Route().Load(QbxRoute.FreezedPrimaryKey, False)
                }
                _CityRoute.SetIsSaved(True)
                _City.Routes.Add(_CityRoute)
            End If
            _CityForm.DgvRoute.Fill(_City.Routes)
            BtnSave.Enabled = False
            If Not _CityRoute.IsSaved Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _CityForm.DgvRoute.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Guid").Value = _CityRoute.Guid)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            LblOrderValue.Text = _CityForm.DgvRoute.SelectedRows(0).Cells("Order").Value
            _CityForm.EprValidation.Clear()
            _CityForm.BtnSave.Enabled = True
            DgvNavigator.RefreshButtons()
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub QbxRoute_Enter(sender As Object, e As EventArgs) Handles QbxRoute.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxRoute.IsFreezed And _User.CanWrite(Routine.Route)
        BtnNew.Visible = _User.CanWrite(Routine.Route)
        BtnFilter.Visible = _User.CanAccess(Routine.Route)
    End Sub
    Private Sub QbxRoute_Leave(sender As Object, e As EventArgs) Handles QbxRoute.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Route As Route
        Dim Form As FrmRoute
        Route = New Route
        Form = New FrmRoute(Route)
        Form.ShowDialog()
        EprValidation.Clear()
        If Route.ID > 0 Then
            QbxRoute.Freeze(Route.ID)
        End If
        QbxRoute.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim Form As New FrmRoute(New Route().Load(QbxRoute.FreezedPrimaryKey, True))
        Form.ShowDialog()
        QbxRoute.Freeze(QbxRoute.FreezedPrimaryKey)
        QbxRoute.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New RouteQueriedBoxFilter(), QbxRoute)
        FilterForm.Text = "Filtro de Rotas"
        FilterForm.ShowDialog()
        QbxRoute.Select()
    End Sub
    Private Sub TmrQueriedBox_Tick(sender As Object, e As EventArgs) Handles TmrQueriedBox.Tick
        BtnView.Visible = False
        BtnNew.Visible = False
        BtnFilter.Visible = False
        TmrQueriedBox.Stop()
    End Sub
    Private Sub QbxRoute_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxRoute.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnView.Visible = QbxRoute.IsFreezed And _User.CanWrite(Routine.Route)
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then Exit Sub
            End If
        End If
        _CityRoute = New CityRoute()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _CityForm.DgvRoute.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _CityRoute = _City.Routes.Single(Function(x) x.Guid = _CityForm.DgvRoute.SelectedRows(0).Cells("Guid").Value)
                _City.Routes.Remove(_CityRoute)
                _CityForm.DgvRoute.Fill(_City.Routes)
                _Deleting = True
                Dispose()
                _CityForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
End Class