Imports ControlLibrary
Imports ControlLibrary.Extensions
Imports MySql.Data.MySqlClient

Public Class FrmCompressorUnit
    Private _CompressorUnit As CompressorUnit
    Private _GridControl As UcCompressorUnitGrid
    Private _Grid As DataGridView
    Private _Filter As CompressorUnitFilter
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
    Public Sub New(CompressorUnit As CompressorUnit, GridControl As UcCompressorUnitGrid)
        InitializeComponent()
        _CompressorUnit = CompressorUnit
        _GridControl = GridControl
        _Grid = _GridControl.DgvData
        _Filter = CType(_GridControl.PgFilter.SelectedObject, CompressorUnitFilter)
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        LoadData()
    End Sub
    Public Sub New(CompressorUnit As CompressorUnit)
        InitializeComponent()
        _CompressorUnit = CompressorUnit
        TsNavigation.Visible = False
        TsNavigation.Enabled = False
        LblStatus.Visible = False
        BtnStatusValue.Visible = False
        BtnStatusValue.Enabled = False
        Height -= TsNavigation.Height
        LblName.Height -= TsNavigation.Height
        TxtName.Height -= TsNavigation.Height
        LblProduct.Height -= TsNavigation.Height
        QbxProduct.Height -= TsNavigation.Height
        FlpProduct.Height -= TsNavigation.Height
        _User = Locator.GetInstance(Of Session).User
        LoadForm()
        LoadData()
    End Sub
    Private Sub LoadForm()
        DgvNavigator.DataGridView = _Grid
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = _User.CanAccess(Routine.Log)
    End Sub
    Private Sub LoadData()
        _Loading = True
        LblIDValue.Text = _CompressorUnit.ID
        BtnStatusValue.Text = EnumHelper.GetEnumDescription(_CompressorUnit.Status)
        LblCreationValue.Text = _CompressorUnit.Creation.ToString("dd/MM/yyyy")
        TxtName.Text = _CompressorUnit.Name
        QbxProduct.Unfreeze()
        QbxProduct.Freeze(_CompressorUnit.Product.Value.ID)
        BtnDelete.Enabled = _CompressorUnit.ID > 0 And _User.CanDelete(Routine.CompressorUnit)
        Text = "Unidade Compressora"
        If _CompressorUnit.LockInfo.IsLocked And Not _CompressorUnit.LockInfo.LockedBy.Equals(Locator.GetInstance(Of Session).User) And Not _CompressorUnit.LockInfo.SessionToken = Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Esse registro está sendo editado por {0}. Você não poderá salvar alterações.", _CompressorUnit.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
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
            _CompressorUnit.Load(_Grid.SelectedRows(0).Cells("id").Value, True)
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
        _CompressorUnit = New CompressorUnit
        LoadData()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _CompressorUnit.ID <> 0 Then
            Try
                Cursor = Cursors.WaitCursor
                If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                    If Not _CompressorUnit.LockInfo.IsLocked Or (_CompressorUnit.LockInfo.IsLocked And Locator.GetInstance(Of Session).Token = _CompressorUnit.LockInfo.SessionToken) Then
                        _CompressorUnit.Delete()
                        If _Grid IsNot Nothing Then
                            _Filter.Filter()
                            _GridControl.DgvlCompressorUnit.Load()
                            _Grid.ClearSelection()
                        End If
                        _Deleting = True
                        Dispose()
                    Else
                        CMessageBox.Show(String.Format("Não foi possível excluir, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _CompressorUnit.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
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
        Using Form As New FrmLog(Routine.CompressorUnit, _CompressorUnit.ID)
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
        If _CompressorUnit.LockInfo.IsLocked And _CompressorUnit.LockInfo.SessionToken <> Locator.GetInstance(Of Session).Token Then
            CMessageBox.Show(String.Format("Não foi possível salvar, esse registro foi aberto em modo somente leitura pois estava sendo utilizado por {0}.", _CompressorUnit.LockInfo.LockedBy.Value.Username.ToTitle()), CMessageBoxType.Information)
            Return False
        Else
            If IsValidFields() Then
                _CompressorUnit.Status = EnumHelper.GetEnumValue(Of SimpleStatus)(BtnStatusValue.Text)
                _CompressorUnit.Name = TxtName.Text
                _CompressorUnit.ProductID = QbxProduct.FreezedPrimaryKey
                _CompressorUnit.ProductName = QbxProduct.Text
                _CompressorUnit.Product = New Lazy(Of Product)(Function() New Product().Load(QbxProduct.FreezedPrimaryKey, False))
                Try
                    Cursor = Cursors.WaitCursor
                    _CompressorUnit.SaveChanges()
                    _CompressorUnit.Lock()
                    LblIDValue.Text = _CompressorUnit.ID
                    BtnSave.Enabled = False
                    BtnDelete.Enabled = _User.CanDelete(Routine.CompressorUnit)
                    If _GridControl IsNot Nothing Then
                        _Filter.Filter()
                        _GridControl.DgvlCompressorUnit.Load()
                        Row = _Grid.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("ID").Value = LblIDValue.Text)
                        If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
                        DgvNavigator.RefreshButtons()
                    End If
                    Return True
                Catch ex As MySqlException
                    If ex.Number = MysqlError.UniqueKey Then
                        CMessageBox.Show("Já existe uma unidade compressora cadastrada com esse nome.", CMessageBoxType.Warning, CMessageBoxButtons.OK)
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
        _CompressorUnit.Unlock()
    End Sub
End Class