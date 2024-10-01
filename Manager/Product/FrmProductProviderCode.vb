Imports ControlLibrary
Imports ControlLibrary.Utility
Public Class FrmProductProviderCode
    Private _ProductForm As FrmProduct
    Private _Product As Product
    Private _ProductProviderCode As ProductProviderCode
    Private _Deleting As Boolean
    Private _Loading As Boolean
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
    Public Sub New(Product As Product, ProductProviderCode As ProductProviderCode, ProductForm As FrmProduct)
        InitializeComponent()
        _Product = Product
        _ProductProviderCode = ProductProviderCode
        _ProductForm = ProductForm
        LoadForm()
        DgvNavigator.DataGridView = _ProductForm.DgvProviderCode
        DgvNavigator.ActionBeforeMove = New Action(AddressOf BeforeDataGridViewRowMove)
        DgvNavigator.ActionAfterMove = New Action(AddressOf AfterDataGridViewRowMove)
        BtnLog.Visible = Locator.GetInstance(Of Session).User.Privilege.SeveralLogAccess
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
        If _ProductForm.DgvProviderCode.SelectedRows.Count = 1 Then
            Cursor = Cursors.WaitCursor
            _ProductProviderCode = _Product.ProviderCodes.Single(Function(x) x.Order = _ProductForm.DgvProviderCode.SelectedRows(0).Cells("Order").Value)
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
    Private Sub BtnInclude_Click(sender As Object, e As EventArgs) Handles BtnInclude.Click
        If BtnSave.Enabled Then
            If CMessageBox.Show("Houve alterações que ainda não foram salvas. Deseja salvar antes de continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                If Not PreSave() Then Exit Sub
            End If
        End If
        _ProductProviderCode = New ProductProviderCode()
        LoadForm()
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If _ProductForm.DgvProviderCode.SelectedRows.Count = 1 Then
            If CMessageBox.Show("O registro selecionado será excluído. Deseja continuar?", CMessageBoxType.Question, CMessageBoxButtons.YesNo) = DialogResult.Yes Then
                _ProductProviderCode = _Product.ProviderCodes.Single(Function(x) x.Order = _ProductForm.DgvProviderCode.SelectedRows(0).Cells("Order").Value)
                _Product.ProviderCodes.Remove(_ProductProviderCode)
                _Product.ProviderCodes.FillDataGridView(_ProductForm.DgvProviderCode)
                _ProductForm.DgvProviderCodeLayout.Load()
                _Deleting = True
                Dispose()
                _ProductForm.BtnSave.Enabled = True
            End If
        End If
    End Sub
    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim Frm As New FrmLog(Routine.ProductProviderCode, _ProductProviderCode.ID)
        Frm.ShowDialog()
    End Sub
    Private Sub TxtTextChanged(sender As Object, e As EventArgs) Handles TxtCode.TextChanged,
                                                                         QbxProvider.TextChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub CbxIsMainProvider_CheckedChanged(sender As Object, e As EventArgs) Handles CbxIsMainProvider.CheckedChanged
        EprValidation.Clear()
        If Not _Loading Then BtnSave.Enabled = True
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        PreSave()
    End Sub
    Private Sub LoadForm()
        _Loading = True
        LblOrderValue.Text = _ProductProviderCode.Order
        LblCreationValue.Text = _ProductProviderCode.Creation
        CbxIsMainProvider.Checked = _ProductProviderCode.IsMainProvider
        TxtCode.Text = _ProductProviderCode.Code
        QbxProvider.Unfreeze()
        QbxProvider.Freeze(_ProductProviderCode.Provider.ID)
        If _Product.ProviderCodes.Count = 0 Then
            CbxIsMainProvider.Checked = True
        End If
        If CbxIsMainProvider.Checked Then
            CbxIsMainProvider.Enabled = False
        Else
            CbxIsMainProvider.Enabled = True
        End If
        If _ProductProviderCode.Order = 0 Then
            BtnSave.Text = "Incluir"
            BtnDelete.Enabled = False
        Else
            BtnSave.Text = "Alterar"
            BtnDelete.Enabled = True
        End If
        BtnSave.Enabled = False
        TxtCode.Select()
        _Loading = False
    End Sub

    Private Function IsValidFields() As Boolean
        If String.IsNullOrWhiteSpace(TxtCode.Text) Then
            EprValidation.SetError(LblCode, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblCode, ErrorIconAlignment.MiddleRight)
            TxtCode.Select()
            Return False
        ElseIf String.IsNullOrWhiteSpace(QbxProvider.Text) Then
            EprValidation.SetError(LblProvider, "Campo obrigatório.")
            EprValidation.SetIconAlignment(LblProvider, ErrorIconAlignment.MiddleRight)
            QbxProvider.Select()
            Return False
        ElseIf Not QbxProvider.IsFreezed Then
            EprValidation.SetError(LblProvider, "Fornecedor não encontrado.")
            EprValidation.SetIconAlignment(LblProvider, ErrorIconAlignment.MiddleRight)
            QbxProvider.Select()
            Return False
        ElseIf Not _ProductProviderCode.IsSaved And _Product.ProviderCodes.Any(Function(x) x.Provider.ID = QbxProvider.FreezedPrimaryKey) Then
            EprValidation.SetError(LblProvider, "Já existe um código cadastrado para esse fornecedor.")
            EprValidation.SetIconAlignment(LblProvider, ErrorIconAlignment.MiddleRight)
            QbxProvider.Select()
            Return False
        ElseIf Not _ProductProviderCode.IsSaved And _Product.ProviderCodes.Any(Function(x) x.Code = TxtCode.Text) Then
            EprValidation.SetError(LblCode, "Já existe um fornecedor com esse código cadastrado.")
            EprValidation.SetIconAlignment(LblCode, ErrorIconAlignment.MiddleRight)
            TxtCode.Select()
            Return False
        End If
        Return True
    End Function
    Private Function PreSave() As Boolean
        Dim Row As DataGridViewRow
        TxtCode.Text = RemoveAccents(TxtCode.Text.Trim)
        If IsValidFields() Then
            If _ProductProviderCode.IsSaved Then
                _Product.ProviderCodes.Single(Function(x) x.Order = _ProductProviderCode.Order).IsMainProvider = CbxIsMainProvider.Checked
                _Product.ProviderCodes.Single(Function(x) x.Order = _ProductProviderCode.Order).Code = TxtCode.Text
                _Product.ProviderCodes.Single(Function(x) x.Order = _ProductProviderCode.Order).Provider = New Person().Load(QbxProvider.FreezedPrimaryKey, False)
            Else
                _ProductProviderCode = New ProductProviderCode()
                _ProductProviderCode.IsMainProvider = CbxIsMainProvider.Checked
                _ProductProviderCode.Code = TxtCode.Text
                _ProductProviderCode.Provider = New Person().Load(QbxProvider.FreezedPrimaryKey, False)
                _ProductProviderCode.IsSaved = True
                _Product.ProviderCodes.Add(_ProductProviderCode)
            End If
            If CbxIsMainProvider.Checked Then
                For Each Code As ProductProviderCode In _Product.ProviderCodes
                    If Code.Order <> _ProductProviderCode.Order Then
                        Code.IsMainProvider = False
                    End If
                Next Code
            End If
            _Product.ProviderCodes.FillDataGridView(_ProductForm.DgvProviderCode)
            LblOrderValue.Text = _ProductProviderCode.Order
            _ProductForm.DgvProviderCodeLayout.Load()
            BtnSave.Enabled = False
            If _ProductProviderCode.Order = 0 Then
                BtnSave.Text = "Incluir"
                BtnDelete.Enabled = False
            Else
                BtnSave.Text = "Alterar"
                BtnDelete.Enabled = True
            End If
            Row = _ProductForm.DgvProviderCode.Rows.Cast(Of DataGridViewRow).FirstOrDefault(Function(x) x.Cells("Order").Value = _ProductProviderCode.Order)
            If Row IsNot Nothing Then DgvNavigator.EnsureVisibleRow(Row.Index)
            _ProductForm.EprValidation.Clear()
            _ProductForm.BtnSave.Enabled = True
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
    Private Sub QbxProvider_Enter(sender As Object, e As EventArgs) Handles QbxProvider.Enter
        TmrQueriedBox.Stop()
        BtnView.Visible = QbxProvider.IsFreezed And Locator.GetInstance(Of Session).User.Privilege.PersonWrite
        BtnNew.Visible = Locator.GetInstance(Of Session).User.Privilege.PersonWrite
        BtnFilter.Visible = Locator.GetInstance(Of Session).User.Privilege.PersonAccess
    End Sub
    Private Sub QbxProvider_Leave(sender As Object, e As EventArgs) Handles QbxProvider.Leave
        TmrQueriedBox.Stop()
        TmrQueriedBox.Start()
    End Sub
    Private Sub QbxProvider_FreezedPrimaryKeyChanged(sender As Object, e As EventArgs) Handles QbxProvider.FreezedPrimaryKeyChanged
        If Not _Loading Then BtnView.Visible = QbxProvider.IsFreezed And Locator.GetInstance(Of Session).User.Privilege.PersonWrite
    End Sub
    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles BtnNew.Click
        Dim Provider As Person
        Dim Form As FrmPerson
        Provider = New Person
        Provider.IsProvider = True
        Form = New FrmPerson(Provider)
        Form.CbxIsProvider.Enabled = False
        Form.ShowDialog()
        EprValidation.Clear()
        If Provider.ID > 0 Then
            QbxProvider.Freeze(Provider.ID)
        End If
        QbxProvider.Select()
    End Sub
    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles BtnView.Click
        Dim Form As New FrmPerson(New Person().Load(QbxProvider.FreezedPrimaryKey, True))
        Form.CbxIsProvider.Enabled = False
        Form.ShowDialog()
        QbxProvider.Freeze(QbxProvider.FreezedPrimaryKey)
        QbxProvider.Select()
    End Sub
    Private Sub BtnFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
        Dim FilterForm As FrmFilter
        FilterForm = New FrmFilter(New PersonProviderQueriedBoxFilter(), QbxProvider)
        FilterForm.Text = "Filtro de Fornecedores"
        FilterForm.ShowDialog()
        QbxProvider.Select()
    End Sub
End Class