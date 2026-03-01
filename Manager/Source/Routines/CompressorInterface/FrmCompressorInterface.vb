Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient
Public Class FrmCompressorInterface
    Private _CompressorInterface As CompressorInterface
    Private _GridControl As UcCompressorInterfaceGrid
    Private _Grid As DataGridView
    Private _Filter As CompressorInterfaceFilter
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
    Public Sub New(CompressorInterface As CompressorInterface, GridControl As UcCompressorInterfaceGrid)
        InitializeComponent()
        _CompressorInterface = CompressorInterface
        _GridControl = GridControl
        _Grid = _GridControl.DgvData
        _Filter = CType(_GridControl.PgFilter.SelectedObject, CompressorInterfaceFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        LoadData()
    End Sub
    Public Sub New(CompressorInterface As CompressorInterface)
        InitializeComponent()
        _CompressorInterface = CompressorInterface
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        Height -= TsNavigation.Height
        LblName.Top -= TsNavigation.Height
        TxtName.Top -= TsNavigation.Height
        LblProduct.Top -= TsNavigation.Height
        QbxProduct.Top -= TsNavigation.Height
        FlpProduct.Top -= TsNavigation.Height
        LblDirection.Top -= TsNavigation.Height
        CbxDirection.Top -= TsNavigation.Height
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        LoadData()
    End Sub
    Private Sub LoadForm()
        CbxDirection.DataSource = EnumHelper.GetEnumDescriptions(Of CompressorInterfaceDirection).ToList()
        DgvNavigator.DataGridView = _Grid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _CompressorInterface.ID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_CompressorInterface.Status)
        LblCreationValue.Text = _CompressorInterface.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _CompressorInterface.Name
        QbxProduct.Unfreeze()
        QbxProduct.Freeze(_CompressorInterface.Product.Value.ID)
        CbxDirection.SelectedItem = EnumHelper.GetEnumDescription(_CompressorInterface.Direction)
        BtnDelete.Enabled = _CompressorInterface.ID > 0 And _User.CanDelete(Routine.CompressorInterface)
        Text = "Interface"
        If _CompressorInterface.LockInfo.IsLocked And Not _CompressorInterface.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _CompressorInterface.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _CompressorInterface.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
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
            _CompressorInterface.Load(_Grid.SelectedRows(0).Cells("id").Value, True)
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
        _Deleting = False
    End Sub
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not Save() Then Exit Sub
            End If
        End If
        _CompressorInterface = New CompressorInterface
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _CompressorInterface.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _CompressorInterface.LockInfo.IsLocked Or (_CompressorInterface.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _CompressorInterface.LockInfo.SessionToken) Then
                        _CompressorInterface.Delete()
                        If _Grid IsNot Nothing Then
                            _Filter.Filter()
                            _GridControl.DgvlCompressorInterface.Load()
                            _Grid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _CompressorInterface.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
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
        Using Form As New FrmLog(Routine.CompressorInterface, _CompressorInterface.ID)
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
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtName.TextChanged
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
            TxtName.Select()
            Return False
        ElseIf Not String.IsNullOrWhiteSpace(QbxProduct.Text) And Not QbxProduct.IsFreezed Then
            EprValidation.SetError(LblProduct, "Produto não encontrado.")
            EprValidation.SetIconAlignment(LblProduct, ErrorIconAlignment.MiddleRight)
            QbxProduct.Select()
            Return False
        End If
        Return True
    End Function
    Private Function Save() As Boolean
        Dim Row As DataGridViewRow
        TxtName.Text = TxtName.Text.Trim.ToUnaccented()
        If _CompressorInterface.LockInfo.IsLocked And _CompressorInterface.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _CompressorInterface.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                _CompressorInterface.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _CompressorInterface.Name = TxtName.Text
                _CompressorInterface.ProductID = QbxProduct.FreezedPrimaryKey
                _CompressorInterface.ProductName = QbxProduct.Text
                _CompressorInterface.Product = New Lazy(Of Product)(Function() New Product().Load(QbxProduct.FreezedPrimaryKey, False))
                _CompressorInterface.Direction = EnumHelper.GetEnumValue(Of CompressorInterfaceDirection)(CbxDirection.SelectedItem)
                Try
                    Cursor = Cursors.WaitCursor
                    _CompressorInterface.SaveChanges()
                    _CompressorInterface.Lock()
                    LblIDValue.Text = _CompressorInterface.ID
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.CompressorInterface)
                    If _GridControl IsNot Nothing Then
                        _Filter.Filter()
                        _GridControl.DgvlCompressorInterface.Load()
                        Row = _Grid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe uma interface cadastrada com esse nome.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
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
    Private Sub QbxProduct_Enter(sender As Object, e As EventArgs) Handles QbxProduct.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxProduct.IsFreezed And _User.CanWrite(Routine.Product)
        BtnNew.Visible = _User.CanWrite(Routine.Product)
        BtnFilter.Visible = _User.CanAccess(Routine.Product)
    End Sub
    Private Sub QbxProductLeave(sender As Object, e As EventArgs)
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxProduct_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxProduct.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnView.Visible = QbxProduct.IsFreezed And _User.CanWrite(Routine.Product)
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Product As New Product
        Using Form As New FrmProduct(Product)
            Form.ShowDialog()
        End Using
        EprValidation.Clear()
        If Product.ID > 0 Then
            QbxProduct.Freeze(Product.ID)
        End If
        QbxProduct.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Using Form As New FrmProduct(New Product().Load(QbxProduct.FreezedPrimaryKey, True))
            Form.ShowDialog()
        End Using
        QbxProduct.Freeze(QbxProduct.FreezedPrimaryKey)
        QbxProduct.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Using Form As New FrmFilter(New ProductQueriedBoxFilter(), QbxProduct) With {.Text = "Filtro de Produtos"}
            Form.ShowDialog()
        End Using
        QbxProduct.Select()
    End Sub
    Private Sub Frm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _CompressorInterface.Unlock()
    End Sub
End Class